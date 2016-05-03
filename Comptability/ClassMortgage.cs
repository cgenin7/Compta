using System;
using System.Collections.Generic;
using System.Text;
using ComptaCommun;

namespace Comptability
{
    public class ClassMortgage
    {
        public static double CalculatePret(DateTime actualDate, DateTime predictionDate, ref TTransactionInfo info)
        {
            if (info.m_Amount == 0 || (info.m_PretAmortissementMonths == 0 && info.m_PretAmountPerPaiement == 0))
                return 0;

            info.m_PretAmortissementList = new List<TPretAmortissement>();
                
            if (info.m_PretPaiementType == EPretPaiementType.e_FixedPaiements)
                return CalculateFixPret(actualDate, predictionDate, ref info);
            else
                return CalculateAmortissementPret(actualDate, predictionDate, ref info);
        }

        public static double GetInterestNotYetPaied(TTransactionInfo info)
        {
            double monthlyInterest = FixPretMonthlyInterestsPaid(info.m_PretInterestRate, info.m_PretRemainingAmount);
            int nbDaysNotPaied = 0;
            int nbDaysInPeriod = 30;
            DateTime lastPaimentDate;
            DateTime nextPaimentDate;

            if (DateTime.Now.Day != info.m_PretInterestsPaiedDay)
            {
                if (DateTime.Now.Day < info.m_PretInterestsPaiedDay)
                {
                    DateTime lastMonth = DateTime.Now.AddMonths(-1);
                    lastPaimentDate = new DateTime(lastMonth.Year, lastMonth.Month, info.m_PretInterestsPaiedDay);
                    nextPaimentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, info.m_PretInterestsPaiedDay);
                
                }
                else
                {
                    lastPaimentDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, info.m_PretInterestsPaiedDay);
                    DateTime nextMonth = DateTime.Now.AddMonths(1);
                    nextPaimentDate = new DateTime(nextMonth.Year, nextMonth.Month, info.m_PretInterestsPaiedDay);
                }

                nbDaysNotPaied = (int)(DateTime.Now - lastPaimentDate).TotalDays;
                nbDaysInPeriod = (int)(nextPaimentDate - lastPaimentDate).TotalDays;
                return nbDaysNotPaied * monthlyInterest / nbDaysInPeriod; 
            }
            return 0;
        }

        public static double CalculateFixPret(DateTime actualDate, DateTime predictionDate, ref TTransactionInfo info)
        {
            if (info.m_PretAmountPerPaiement > 0)
            {
                info.m_EndDate = CalculateFixPretEndDate(ref info);
                int nbPaiementsAlreadyMade = Util.GetNbPeriods(info, info.m_StartDate, DateTime.Now);

                info.m_PretRemainingAmount = CalculateRemainingAmountAtSpecifiedDate(info, DateTime.Now);
                if (info.m_PretRemainingAmount <= 0)
                {
                    info.m_PretRemainingAmount = 0;
                    return 0;
                }
                int nbRemainingPaiements;
                
                DateTime startDate = info.m_StartDate;
                if (info.m_StartDate <= DateTime.Now)
                {
                    while (startDate.Year < predictionDate.Year || startDate < DateTime.Now)
                    {
                        DateTime newDate = Util.GetNextPaiementDate(info, startDate);
                        if (startDate.Date == newDate.Date)  //CGe log error
                            break;
                        startDate = newDate;
                    }
                }
                DateTime endDate = info.m_EndDate.Year <= predictionDate.Year ? info.m_EndDate : predictionDate;
                nbRemainingPaiements = Util.GetNbPeriods(info, startDate, endDate);
                
                double remainingAmountInPeriod = nbRemainingPaiements * info.m_PretAmountPerPaiement;
                return (remainingAmountInPeriod < info.m_PretRemainingAmount ? remainingAmountInPeriod : info.m_PretRemainingAmount);
            }
            return 0;
        }

        private static DateTime CalculateFixPretEndDate(ref TTransactionInfo info)
        {
            int nbDaysInPeriod;
            double remainingAmount = info.m_Amount;
            DateTime paiementDate = Util.GetFirstPaiementDate(info, info.m_StartDate, out nbDaysInPeriod);
            
            info.m_TotalNbPaiements = 0;

            if (info.m_PretAmortissementList == null)
                info.m_PretAmortissementList = new List<TPretAmortissement>();

            if (info.m_PretAmountPerPaiement > 0)
            {
                while (remainingAmount > 0.01)
                {
                    TPretAmortissement pretAmortissement = new TPretAmortissement();
                    pretAmortissement.PaiementDate = paiementDate;
                    if (info.m_eTransactionType == ETransactionType.e_TwoTimesInMonthTransaction)
                        pretAmortissement.InterestPaied = FixPretMonthlyInterestsPaid(info.m_PretInterestRate/2, remainingAmount);
                    else if (info.m_eTransactionType == ETransactionType.e_PeriodicTransaction && info.m_PeriodLength == EPeriodLength.e_PerMonth)
                        pretAmortissement.InterestPaied = FixPretMonthlyInterestsPaid(info.m_PretInterestRate*info.m_Period, remainingAmount);
                    else
                        pretAmortissement.InterestPaied = FixPretInterestsPaid(info.m_PretInterestRate, remainingAmount, nbDaysInPeriod);
                    pretAmortissement.CapitalPaied = info.m_PretAmountPerPaiement - pretAmortissement.InterestPaied;
                    pretAmortissement.NbDaysInPeriod = nbDaysInPeriod;

                    if (pretAmortissement.CapitalPaied <= 0)
                        break;

                    remainingAmount -= pretAmortissement.CapitalPaied;
                    if (remainingAmount < 0)
                        remainingAmount = 0;
                    pretAmortissement.RemainingAmount = remainingAmount;
                    info.m_PretAmortissementList.Add(pretAmortissement);

                    info.m_TotalNbPaiements++;

                    if (remainingAmount > 0.01)
                    {
                        paiementDate = Util.GetNextPaiementDate(info, paiementDate, out nbDaysInPeriod);
                        if (nbDaysInPeriod == 0) // CGe add error log
                            break;
                    }
                }
            }
            return paiementDate;
        }

        /*
         The following formula is used to calculate the fixed monthly payment (P) required to fully amortize a loan of L dollars over a term of n months 
         at a monthly interest rate of c. [If the quoted rate is 6%, for example, c is .06/12 or .005]. 
         P = L[c(1 + c)exp(n)]/[(1 + c)exp(n) - 1] 
         The next formula is used to calculate the remaining loan balance (B) of a fixed payment loan after p months. 
         B = L[(1 + c)n - (1 + c)p]/[(1 + c)n - 1] 
         */
        /*
         M = P [ i(1 + i)exp(n) ] / [ (1 + i)exp(n) - 1] 
         M = The monthly payment 
         P = The principal, or the amount of money being borrowed 
         i = The interest for each compounding period, or the interest per month for a standard mortgage 
         n = The number of compounding periods, or the number of months for a standard mortgage 
         */
        private static double CalculateAmortissementPret(DateTime actualDate, DateTime predictionDate, ref TTransactionInfo info)
        {
            info.m_PretAmountPerPaiement = GetAmountPerPaiement(info);

            return CalculateFixPret(actualDate, predictionDate, ref info);
        }

        private static double GetAmountPerPaiement(TTransactionInfo info)
        {
            double monthlyPaiements = info.m_Amount / info.m_PretAmortissementMonths;
            if (info.m_PretInterestRate > 0)
            {
                double interestRatePerMonth = info.m_PretInterestRate / 1200.0;
                monthlyPaiements = (info.m_Amount * interestRatePerMonth / (1 - Math.Pow(1 + interestRatePerMonth, -info.m_PretAmortissementMonths)));
            }

            double amountPerPaiement = monthlyPaiements;

            switch (info.m_eTransactionType)
            {
                case ETransactionType.e_PeriodicTransaction:
                    switch (info.m_PeriodLength)
                    {
                        case EPeriodLength.e_PerDay:
                            amountPerPaiement = monthlyPaiements * 12 * info.m_Period / 365;
                            break;
                        case EPeriodLength.e_PerWeek:
                            amountPerPaiement = monthlyPaiements * 12 * info.m_Period / 52;
                            break;
                        case EPeriodLength.e_PerMonth:
                            amountPerPaiement = monthlyPaiements * info.m_Period;
                            break;
                        case EPeriodLength.e_PerYear:
                            amountPerPaiement = monthlyPaiements * 12;
                            break;
                        case EPeriodLength.e_PerWeekAccelerated:
                            amountPerPaiement = monthlyPaiements * 12 * info.m_Period / 48;
                            break;
                    }
                    break;
                case ETransactionType.e_TwoTimesInMonthTransaction:
                    amountPerPaiement = monthlyPaiements / 2;
                    break;
            }
            return amountPerPaiement;
        }

        public static double GetAmountPerMonth(double amountPerPaiement, TTransactionInfo info)
        {
            double amountPerMonth = amountPerPaiement;

            switch (info.m_eTransactionType)
            {
                case ETransactionType.e_PeriodicTransaction:
                    switch (info.m_PeriodLength)
                    {
                        case EPeriodLength.e_PerDay:
                            amountPerMonth = amountPerPaiement * 365 / 12 / info.m_Period;
                            break;
                        case EPeriodLength.e_PerWeek:
                            amountPerMonth = amountPerPaiement * 48 / 12 / info.m_Period;
                            break;
                        case EPeriodLength.e_PerMonth:
                            amountPerMonth = amountPerPaiement / info.m_Period;
                            break;
                        case EPeriodLength.e_PerYear:
                            amountPerMonth = amountPerPaiement / 12 / info.m_Period;
                            break;
                        case EPeriodLength.e_PerWeekAccelerated:
                            amountPerMonth = amountPerPaiement * 52 / 12 / info.m_Period;
                            break;
                    }
                    break;
                case ETransactionType.e_TwoTimesInMonthTransaction:
                    amountPerPaiement = amountPerPaiement / 2;
                    break;
            }
            return amountPerMonth;
        }

        private static double FixPretMonthlyInterestsPaid(double interestRate, double remainingAmount)
        {
            double interest = 0;
            if (interestRate > 0)
            {
                interest = (remainingAmount * interestRate / 100.0) / 12.0;
            }
            return interest;
        }

        private static double FixPretInterestsPaid(double interestRate, double remainingAmount, int nbDaysInPeriod)
        {
            double interest = 0;
            if (interestRate > 0)
            {
                interest = (remainingAmount * nbDaysInPeriod * interestRate / 100.0) / 365.0;
            }
            return interest;
        }

        private static double CalculateRemainingAmountAtSpecifiedDate(TTransactionInfo info, DateTime date)
        {
            int nbDaysInPeriod;
            double remainingAmount = info.m_Amount;
            DateTime paiementDate = Util.GetFirstPaiementDate(info, info.m_StartDate, out nbDaysInPeriod);

            info.m_TotalNbPaiements = 0;

            if (info.m_PretAmountPerPaiement > 0)
            {
                while (paiementDate.Date <= date.Date && remainingAmount > 0.01)
                {
                    TPretAmortissement pretAmortissement = new TPretAmortissement();
                    pretAmortissement.PaiementDate = paiementDate;
                    if (info.m_eTransactionType == ETransactionType.e_TwoTimesInMonthTransaction)
                        pretAmortissement.InterestPaied = FixPretMonthlyInterestsPaid(info.m_PretInterestRate / 2, remainingAmount);
                    else if (info.m_eTransactionType == ETransactionType.e_PeriodicTransaction && info.m_PeriodLength == EPeriodLength.e_PerMonth)
                        pretAmortissement.InterestPaied = FixPretMonthlyInterestsPaid(info.m_PretInterestRate * info.m_Period, remainingAmount);
                    else
                        pretAmortissement.InterestPaied = FixPretInterestsPaid(info.m_PretInterestRate, remainingAmount, nbDaysInPeriod);
                    pretAmortissement.CapitalPaied = info.m_PretAmountPerPaiement - pretAmortissement.InterestPaied;

                    if (pretAmortissement.CapitalPaied <= 0)
                        break;

                    remainingAmount -= pretAmortissement.CapitalPaied;
                    if (remainingAmount < 0)
                        remainingAmount = 0;
                    pretAmortissement.RemainingAmount = remainingAmount;
                    //info.m_PretAmortissementList.Add(pretAmortissement);

                    info.m_TotalNbPaiements++;

                    if (remainingAmount > 0.01)
                    {
                        paiementDate = Util.GetNextPaiementDate(info, paiementDate, out nbDaysInPeriod);
                        if (nbDaysInPeriod == 0) // CGe add error log
                            break;
                    }
                }
            }
            return remainingAmount;
        }
    }
}
