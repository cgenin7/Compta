using System;
using System.Collections.Generic;
using System.Text;
using ComptaCommun;

namespace Comptability
{
    public class ClassCalculation
    {
        #region Public methods

        public static double CalculateTransactionsAtPredictionDate(Dictionary<int, TTransactionInfo> transactions, ref TPredictedBalance predictedBalance, bool IsRevenu)
        {
            double balance = 0;
            if (!IsRevenu)
            {
                predictedBalance.TotalPrets = 0;
                predictedBalance.TotalPretsRemaining = 0;
            }
                
            int year = predictedBalance.StartPredictionDate.Year;

            if (transactions != null)
            {
                foreach (int transID in transactions.Keys)
                {
                    TTransactionInfo info = transactions[transID];

                    bool infoIsRevenu = (info.m_Type == EType.e_Income);
                    
                    if (info.m_AccountId == predictedBalance.AccountId && infoIsRevenu == IsRevenu)
                    {
                        double transactionBalance = GetTransactionBalance(predictedBalance.StartPredictionDate, predictedBalance.EndPredictionDate, ref info);
                        double totalAmountPaiedForTheYear = ClassAnnualCalculation.GetAnnualTransactionBalance(year, info);
                        info.m_TotalAmountPaiedForTheYear = totalAmountPaiedForTheYear;
            
                        if (info.m_Type == EType.e_Pret)
                        {
                            if (info.m_PretType == EPretType.e_MortgageLinkedToAccount || info.m_PretType == EPretType.e_PretLinkedToAccount)
                            {
                                double interestNotYetPaied = 0;
                                if (predictedBalance.EndPredictionDate.Date == new DateTime(LocalSettings.BudgetYear, 12, 31).Date)
                                    interestNotYetPaied = ClassMortgage.GetInterestNotYetPaied(info);
                                predictedBalance.TotalPretsRemaining += (info.m_PretRemainingAmount - interestNotYetPaied);
                            }
                            predictedBalance.TotalPrets += transactionBalance;
                            predictedBalance.TotalPretsForTheYear += totalAmountPaiedForTheYear;
                        }
                        balance += transactionBalance;

                        if (IsRevenu)
                            predictedBalance.IncomesForTheYear += totalAmountPaiedForTheYear;
                        else
                            predictedBalance.ExpensesForTheYear += totalAmountPaiedForTheYear;
                    }
                }
            }
            return balance;
        }

        public static double GetTotalAmountPayed(TTransactionInfo info, int nbPeriods, out double amountReallyPayed, out int nbCompletedPaiements)
        {
            string[] amounts = info.m_AmountAlreadyPayed.Split(';');
            double totalPayed = 0;
            nbCompletedPaiements = 0;
            amountReallyPayed = 0;

            if (amounts != null)
            {
                bool completed = false;
                for (int i = amounts.Length - 1; i >= 0; i--)
                {
                    if (i < nbPeriods)
                    {
                        double amount = 0;
                        string sAmount = amounts[i];
                        double.TryParse(sAmount.Replace("C", "").Replace("$", "").Trim(), out amount);
                        if (completed && !sAmount.StartsWith("C"))
                            amounts[i] = "C" + sAmount;
                        else if (sAmount.StartsWith("C") || amount != 0)
                            completed = true;
                    }
                }

                for (int i = 0; i < amounts.Length && i < nbPeriods; i++)
                {
                    double amount;
                    string sAmount = amounts[i];
                    bool bCompleted = false;
                    if (sAmount.StartsWith("C"))
                    {
                        bCompleted = true;
                        nbCompletedPaiements++;
                        sAmount = sAmount.Replace("C", "");
                    }
                    if (double.TryParse(sAmount, out amount))
                    {
                        if (bCompleted)
                        {
                            amountReallyPayed += amount;
                            totalPayed += info.m_Amount;
                        }
                        else
                            totalPayed += Math.Min(amount, info.m_Amount);
                    }
                }
            }
            return totalPayed;
        }

        public static double GetTransactionBalance(DateTime ActualDate, DateTime PredictionDate, ref TTransactionInfo info)
        {
            info.m_Warning = "";
            info.m_FirstPaiementDate = DateTime.MinValue;
            info.m_LastPaiementDate = DateTime.MinValue;

            if (info.m_Type == EType.e_Pret)
                info.m_Balance = ClassMortgage.CalculatePret(ActualDate, PredictionDate, ref info);
            else if (info.m_eTransactionType == ETransactionType.e_OneShotTransaction)
                info.m_Balance = GetOneShotTransactionBalance(ActualDate, PredictionDate, ref info);
            else
                info.m_Balance = GetOtherTransactionsBalance(ActualDate, PredictionDate, ref info);
            return info.m_Balance;
        }

        #endregion

        #region Private methods

        private static double GetOneShotTransactionBalance(DateTime ActualDate, DateTime PredictionDate, ref TTransactionInfo info)
        {
            // transaction is not in the period considered
            if (info.m_StartDate.Date > PredictionDate.Date)
                return 0;

            info.m_TotalNbPaiements = 1;
            if (info.m_TransactionMode == ETransactionMode.e_Automatique)
            {
                if (info.m_StartDate.Date >= ActualDate.Date)
                    return info.m_Amount;
            }
            else
            {
                double AmountRemaining = info.m_Amount - GetTotalAmountPayed(info, 1);
                if (info.m_StartDate.Date < ActualDate.Date && AmountRemaining > 0)
                    if (info.m_Type == EType.e_Income)
                        info.m_Warning = "La date de la transaction est expirée mais le montant n'a pas été encaissé.";
                    else
                        info.m_Warning = "La date de la transaction est expirée mais le montant n'a pas été déboursé.";
                else if (AmountRemaining < 0)
                    info.m_Warning = "Le montant restant est négatif pour cette transaction.";
                return AmountRemaining;
            }
            return 0;
        }

        private static double GetOtherTransactionsBalance(DateTime ActualDate, DateTime PredictionDate, ref TTransactionInfo info)
        {
            int NbRemainingPaiements;
            double AmountRemainingInPeriod;
            double TotalAmount;
            DateTime EndDate = (info.m_EndDate.Date < PredictionDate.Date ? info.m_EndDate : PredictionDate);

            // Transactions based on month periods
            if (info.m_PeriodLength == EPeriodLength.e_PerMonth || info.m_eTransactionType == ETransactionType.e_TwoTimesInMonthTransaction)
            {
                AmountRemainingInPeriod = GetMonthsPaiements(ActualDate, EndDate, info, false);
                TotalAmount = GetMonthsPaiements(ActualDate, EndDate, info, true);

                if (info.m_TransactionMode == ETransactionMode.e_Automatique)
                    return AmountRemainingInPeriod;
                return GetAmountForManualTransactions(TotalAmount, AmountRemainingInPeriod, info.m_TotalNbPaiements, info);
            }
            // Transactions not based on month periods
            NbRemainingPaiements = GetNbPaiements(ActualDate, EndDate, ref info, false);
            double AmountPerPaiement = info.m_Amount;

            int TotalNbPaiements = GetNbPaiements(ActualDate, EndDate, ref info, true);
            TotalAmount = AmountPerPaiement * TotalNbPaiements;

            AmountRemainingInPeriod = AmountPerPaiement * NbRemainingPaiements;

            if (info.m_TransactionMode == ETransactionMode.e_Automatique)
                return AmountRemainingInPeriod;
            return GetAmountForManualTransactions(TotalAmount, AmountRemainingInPeriod, TotalNbPaiements, info);
        }

        private static int GetNbPaiements(DateTime ActualDate, DateTime EndDate, ref TTransactionInfo info, bool AllPaiementsInPeriod)
        {
            int NbDaysPerPaiement = info.m_Period * GetNbDaysInPeriod(info.m_PeriodLength);
            int NbRemainingPaiements = 0;

            DateTime FirstPaiementDate = info.m_StartDate;

            if (!AllPaiementsInPeriod)
            {
                while (FirstPaiementDate.Date < ActualDate.Date)
                {
                    if (info.m_PeriodLength == EPeriodLength.e_PerYear)
                        FirstPaiementDate = FirstPaiementDate.AddYears(info.m_Period);
                    else
                        FirstPaiementDate = FirstPaiementDate.AddDays(NbDaysPerPaiement);
                }
                info.m_FirstPaiementDate = FirstPaiementDate;
            }
            if (info.m_PeriodLength == EPeriodLength.e_PerYear)
            {
                NbRemainingPaiements = 0;
                while (FirstPaiementDate.Date <= EndDate.Date)
                {
                    NbRemainingPaiements++;
                    FirstPaiementDate = FirstPaiementDate.AddYears(info.m_Period);
                    if (!AllPaiementsInPeriod)
                        info.m_LastPaiementDate = FirstPaiementDate;
                }
            }
            else if (FirstPaiementDate.Date <= EndDate.Date)
            {
                TimeSpan timeRemaining = EndDate - FirstPaiementDate;
                int NbRemainingDays = (int)timeRemaining.TotalDays;
                if (NbRemainingDays >= 0)
                    NbRemainingPaiements = (NbRemainingDays / NbDaysPerPaiement) + 1;
                if (!AllPaiementsInPeriod)
                    info.m_LastPaiementDate = info.m_FirstPaiementDate.AddDays((NbRemainingPaiements - 1) * NbDaysPerPaiement);
            }
            else
                info.m_FirstPaiementDate = DateTime.MinValue;
            if (AllPaiementsInPeriod)
                info.m_TotalNbPaiements = NbRemainingPaiements;
            else
                info.m_NbRemainingPaiements = NbRemainingPaiements;

            return NbRemainingPaiements;
        }

        private static double GetMonthsPaiements(DateTime ActualDate, DateTime EndDate, TTransactionInfo info, bool AllPaiementsInPeriod)
        {
            int FirstTimeInMonth = info.m_FirstTimeInMonth, SecondTimeInMonth = info.m_SecondTimeInMonth;
            double TotalAmount = 0;
            double NbMonthsWithoutPaiement = info.m_Period;
            int NbPaiements = 0;

            DateTime FirstPaiementDate = info.m_StartDate;

            if (info.m_eTransactionType == ETransactionType.e_TwoTimesInMonthTransaction)
                info.m_Period = 1;

            if (!AllPaiementsInPeriod)
                FirstPaiementDate = GetMonthFirstPaiementDate(ActualDate, FirstPaiementDate, info);

            DateTime myDate = FirstPaiementDate;
            DateTime StartPaiementDate = myDate;

            while (myDate.Date <= EndDate.Date)
            {
                if (NbMonthsWithoutPaiement >= info.m_Period)
                {
                    NbMonthsWithoutPaiement = 0;
                    if (info.m_FirstTimeInMonth == Util.LAST_DAY_OF_MONTH) 
                        FirstTimeInMonth = DateTime.DaysInMonth(myDate.Year, myDate.Month);
                    if (info.m_SecondTimeInMonth == Util.LAST_DAY_OF_MONTH) 
                        SecondTimeInMonth = DateTime.DaysInMonth(myDate.Year, myDate.Month);

                    DateTime FirstTimeDate = myDate.AddDays(FirstTimeInMonth - myDate.Day);
                    if (myDate.Day <= FirstTimeInMonth && FirstTimeDate.Date <= EndDate.Date)
                    {
                        if (!AllPaiementsInPeriod && info.m_FirstPaiementDate == DateTime.MinValue)
                            info.m_FirstPaiementDate = FirstTimeDate;
                        TotalAmount += info.m_Amount;
                        info.m_LastPaiementDate = FirstTimeDate;
                        StartPaiementDate = FirstTimeDate.AddDays(1);
                        NbPaiements++;
                    }
                    if (info.m_eTransactionType == ETransactionType.e_TwoTimesInMonthTransaction)
                    {
                        DateTime SecondTimeDate = myDate.AddDays(SecondTimeInMonth - myDate.Day);
                        if (myDate.Day <= SecondTimeInMonth && SecondTimeDate.Date <= EndDate.Date)
                        {
                            if (!AllPaiementsInPeriod && info.m_FirstPaiementDate == DateTime.MinValue)
                                info.m_FirstPaiementDate = SecondTimeDate;
                            TotalAmount += info.m_Amount;
                            info.m_LastPaiementDate = SecondTimeDate;
                            StartPaiementDate = SecondTimeDate.AddDays(1);
                            NbPaiements++;
                        }
                    }
                }
                myDate = myDate.AddMonths(1);
                myDate = myDate.AddDays((myDate.Day - 1) * -1);
                NbMonthsWithoutPaiement++;
            }
            if (AllPaiementsInPeriod)
                info.m_TotalNbPaiements = NbPaiements;
            else
                info.m_NbRemainingPaiements = NbPaiements;
            return TotalAmount;
        }

        private static int GetNbDaysInPeriod(EPeriodLength PeriodLength)
        {
            if (PeriodLength == EPeriodLength.e_PerWeek || PeriodLength == EPeriodLength.e_PerWeekAccelerated)
                return 7;
            return 1;
        }

        public static DateTime GetMonthFirstPaiementDate(DateTime ActualDate, DateTime StartDate, TTransactionInfo info)
        {
            int FirstTimeInMonth = info.m_FirstTimeInMonth, SecondTimeInMonth = info.m_SecondTimeInMonth;
            double NbMonthsWithoutPaiement = info.m_Period;
            DateTime myDate, TempDate;

            if (StartDate.Date > ActualDate.Date)
                return StartDate;
            myDate = StartDate.Date;
            do
            {
                if (info.m_FirstTimeInMonth == Util.LAST_DAY_OF_MONTH) 
                    FirstTimeInMonth = DateTime.DaysInMonth(myDate.Year, myDate.Month);
                if (info.m_SecondTimeInMonth == Util.LAST_DAY_OF_MONTH) 
                    SecondTimeInMonth = DateTime.DaysInMonth(myDate.Year, myDate.Month);

                if (myDate.Day <= FirstTimeInMonth)
                {
                    TempDate = myDate.AddDays(FirstTimeInMonth - myDate.Day);
                    if (TempDate.Date >= ActualDate.Date && NbMonthsWithoutPaiement == info.m_Period)
                        break;
                    myDate = TempDate;
                }
                if (info.m_eTransactionType == ETransactionType.e_TwoTimesInMonthTransaction)
                {
                    if (myDate.Day <= SecondTimeInMonth)
                    {
                        TempDate = myDate.AddDays(SecondTimeInMonth - myDate.Day);
                        if (TempDate.Date >= ActualDate.Date && NbMonthsWithoutPaiement == info.m_Period)
                        {
                            if (myDate.Day == FirstTimeInMonth)
                                myDate = myDate.AddDays(1);
                            break;
                        }
                        myDate = TempDate;
                    }
                }

                myDate = myDate.AddMonths(1);
                myDate = myDate.AddDays((myDate.Day - 1) * -1);
                if (NbMonthsWithoutPaiement == info.m_Period)
                    NbMonthsWithoutPaiement = 0;
                NbMonthsWithoutPaiement++;
            } while (myDate.Date <= info.m_EndDate);

            return myDate;
        }

        private static double GetAmountForManualTransactions(double TotalAmount, double AmountRemainingInPeriod, int nbPeriods, TTransactionInfo info)
        {
            double AmountPayedForThePeriod = GetTotalAmountPayed(info, nbPeriods);
            double AmountThatShouldHaveBeenPayedForThePeriod = TotalAmount - AmountRemainingInPeriod;
            if (AmountThatShouldHaveBeenPayedForThePeriod - AmountPayedForThePeriod >= 0.01)
            {
                if (info.m_Type == EType.e_Expense)
                    info.m_Warning = "Le montant restant à dépenser d'ici le " + ClassTools.ConvertDateToString(info.m_EndDate) + " est de " + ClassTools.ConvertCurrencyToString(TotalAmount - AmountPayedForThePeriod) + ". Il devrait être de " + ClassTools.ConvertCurrencyToString(TotalAmount - AmountThatShouldHaveBeenPayedForThePeriod) + ".";
                else
                    info.m_Warning = "Le montant restant à recevoir d'ici le " + ClassTools.ConvertDateToString(info.m_EndDate) + " est de " + ClassTools.ConvertCurrencyToString(TotalAmount - AmountPayedForThePeriod) + ". Il devrait être de " + ClassTools.ConvertCurrencyToString(TotalAmount - AmountThatShouldHaveBeenPayedForThePeriod) + ".";
            }
            else if (AmountPayedForThePeriod - AmountThatShouldHaveBeenPayedForThePeriod >= 0.01)
            {
                double amountInAdvance = LastAmountEntered(info.m_AmountAlreadyPayed);
                if (amountInAdvance > 0)
                {
                    if (info.m_Type == EType.e_Income)
                        info.m_Warning = ClassTransactions.GOOD_NEWS + ClassTools.ConvertCurrencyToString(amountInAdvance) + " ont été reçu en avance.";
                    else if (info.m_Type == EType.e_Expense)
                        info.m_Warning = ClassTransactions.GOOD_NEWS + ClassTools.ConvertCurrencyToString(amountInAdvance) + " ont été payés en avance.";
                }
            }
            else if (TotalAmount - AmountRemainingInPeriod < 0)
                info.m_Warning = "Le montant restant est négatif pour cette transaction.";
            return TotalAmount - AmountPayedForThePeriod;
        }

        private static double GetTotalAmountPayed(TTransactionInfo info, int nbPeriods)
        {
            int nbCompletedPaiements;
            double amountReallyPayed;
            return GetTotalAmountPayed(info, nbPeriods, out amountReallyPayed, out nbCompletedPaiements);
        }

        private static double LastAmountEntered(string amountAlreadyPayed)
        {
            string[] amounts = amountAlreadyPayed.Split(';');

            if (amounts != null && amounts.Length > 0)
            {
                string sAmount = amounts[amounts.Length - 1].Replace("C", "");
                double amount;
                if (double.TryParse(sAmount, out amount))
                {
                    return amount;
                }
            }
            return 0;
        }

        #endregion
    }
}
