using System;
using System.Collections.Generic;
using System.Text;
using ComptaDB;
using ComptaCommun;

namespace Comptability
{
    public class ClassValidateCalculations
    {
        public bool ValidateInfo(Dictionary<int, TTransactionInfo> transactions, TPredictedBalance predictedBalance, out string errorMsg)
        {
            double incomes = predictedBalance.Incomes;
            double expenses = predictedBalance.Expenses;
            
            m_startPredictionDate = predictedBalance.StartPredictionDate;
            m_endPredictionDate = predictedBalance.EndPredictionDate;
            m_accountId = predictedBalance.AccountId;
            errorMsg = "";
            m_transactions = transactions;
            
            if (Math.Abs(incomes - CalculateIncomesAtPredictionDate(ref errorMsg)) > 0.01)
                return false;
            if (Math.Abs(expenses - CalculateExpensesAtPredictionDate(ref errorMsg)) > 0.01)
                return false;
            return true;
        }

        public static double CalculatePeriodicBalance(TTransactionInfo info, DateTime startPredictionDate, DateTime endTime)
        {
            if (info.m_Type == EType.e_Pret)
            {
                TTransactionInfo copyInfo = new TTransactionInfo(info);
                return ClassMortgage.CalculatePret(info.m_StartDate, endTime, ref copyInfo);
            }

            int nbPeriods;
            if (info.m_TransactionMode == ETransactionMode.e_Automatique)
            {
                nbPeriods = GetNbPeriods(info, startPredictionDate, endTime, false);
                return nbPeriods * info.m_Amount;
            }
            else
            {
                nbPeriods = GetNbPeriods(info, startPredictionDate, endTime, true);
                double amountAlreadyPayed = GetAmountAlreadyPayed(info, nbPeriods);
                return info.m_Amount * nbPeriods - amountAlreadyPayed;
            }
        }

        private double CalculateIncomesAtPredictionDate(ref string errorMsg)
        {
            double totalIncomes = 0;

            foreach (TTransactionInfo info in m_transactions.Values)
            {
                if (info.m_Type == EType.e_Income && info.m_AccountId == m_accountId)
                {
                    double balance = CalculateTransactionBalance(info);
                    if (Math.Abs(balance - info.m_Balance) > 0.01)
                        errorMsg += "Le solde de la transaction " + info.m_TransactionName + " est incorrect. Il devrait être de " + ClassTools.ConvertDoubleToString(balance) +
                            " au lieu de " + ClassTools.ConvertDoubleToString(info.m_Balance) + ".\r\n";
                    totalIncomes += balance;
                }
            }
            return totalIncomes;            
        }

        private double CalculateExpensesAtPredictionDate(ref string errorMsg)
        {
            double totalExpenses = 0;

            foreach (TTransactionInfo info in m_transactions.Values)
            {
                if ((info.m_Type == EType.e_Expense || info.m_Type == EType.e_Pret) && info.m_AccountId == m_accountId)
                {
                    double balance = CalculateTransactionBalance(info);
                    if (Math.Abs(balance - info.m_Balance) > 0.01)
                        errorMsg += "Le solde de la transaction " + info.m_TransactionName + " est incorrect. Il devrait être de " + ClassTools.ConvertDoubleToString(balance) +
                            " au lieu de " + ClassTools.ConvertDoubleToString(info.m_Balance) + ". Amount=" + info.m_Amount + "\r\n";
                    totalExpenses += balance;
                }
            }
            return totalExpenses;    
        }

        private double CalculateTransactionBalance(TTransactionInfo info)
        {
            DateTime endTime = info.m_EndDate.Date <= m_endPredictionDate.Date ? info.m_EndDate : m_endPredictionDate;

            if (info.m_Type == EType.e_Pret)
                endTime = m_endPredictionDate;

            switch (info.m_eTransactionType)
            { 
                case ETransactionType.e_OneShotTransaction:
                    return CalculateOneShotBalance(info);
                case ETransactionType.e_TwoTimesInMonthTransaction:
                case ETransactionType.e_PeriodicTransaction:
                    return CalculatePeriodicBalance(info, m_startPredictionDate, endTime); 
            }
            return 0;
        }

        private double CalculateOneShotBalance(TTransactionInfo info)
        {
            if (info.m_TransactionMode == ETransactionMode.e_Automatique)
            {
                if (info.m_StartDate.Date >= m_startPredictionDate.Date && info.m_StartDate.Date <= m_endPredictionDate.Date)
                {
                    return info.m_Amount;
                }
            }
            else
            {
                if (info.m_StartDate.Date <= m_endPredictionDate.Date)
                {
                    double amountPayed = 0;
                    bool bCompleted = info.m_AmountAlreadyPayed.StartsWith("C");

                    if (bCompleted && info.m_TransactionMode == ETransactionMode.e_Manual)
                        return 0;

                    string sAmountAlreadyPayed = info.m_AmountAlreadyPayed.Replace("C", "").Replace("$", "").Trim();
                    string[] amountPayedArray = sAmountAlreadyPayed.Split(';');
                    if (amountPayedArray.Length > 0)
                    {
                        if (double.TryParse(amountPayedArray[0], out amountPayed))
                        {
                            return info.m_Amount - amountPayed;
                        }
                    }
                }
            }
            return 0;
        }

        private static int GetNbMonthPeriods(TTransactionInfo info, DateTime startPredictionDate, DateTime endTime, int timeInMonth, bool fullPeriod)
        {
            DateTime startTime = info.m_StartDate;

            if (timeInMonth <= 0)
                timeInMonth = 1;

            int nbMonthPeriods = 0;
            if (timeInMonth == Util.LAST_DAY_OF_MONTH) // last day of month
            {
                startTime = new DateTime(startTime.Year, startTime.Month, 1).AddMonths(1).AddDays(-1);
            }
            else
            {
                if (startTime.Date.Day <= timeInMonth)
                    startTime = new DateTime(startTime.Year, startTime.Month, timeInMonth);
                else
                    startTime = new DateTime(startTime.Year, startTime.Month, timeInMonth).AddMonths(info.m_Period);
            }
            if (!fullPeriod)
            {
                while (startTime.Date < startPredictionDate.Date && startTime.Date <= endTime.Date)
                {
                    if (timeInMonth == Util.LAST_DAY_OF_MONTH) // last day of month
                    {
                        if (startTime.Month + info.m_Period + 1 > 12)
                            startTime = new DateTime(startTime.Year + 1, 1, 1).AddDays(-1);
                        else
                            startTime = new DateTime(startTime.Year, startTime.Month + info.m_Period, 1).AddMonths(1).AddDays(-1);
                    }
                    else
                        startTime = startTime.AddMonths(info.m_Period);
                }
            }

            while (startTime.Date <= endTime.Date)
            {
                nbMonthPeriods++;

                if (timeInMonth == Util.LAST_DAY_OF_MONTH) // last day of month
                {
                    if (startTime.Month + info.m_Period + 1 > 12)
                    {
                        startTime = new DateTime(startTime.Year + 1, 1, 1).AddDays(-1);
                        if (startTime.Date <= endTime.Date)
                            nbMonthPeriods++;
                        break;
                    }
                    else
                        startTime = new DateTime(startTime.Year, startTime.Month + info.m_Period, 1).AddMonths(1).AddDays(-1);
                }
                else
                    startTime = startTime.AddMonths(info.m_Period);
            }
            return nbMonthPeriods;
        }

        public static int GetNbPeriods(TTransactionInfo info, DateTime startPredictionDate, DateTime endTime, bool fullPeriod)
        {
            int nb = 0;
            DateTime startTime = info.m_StartDate.Date;

            if (info.m_eTransactionType == ETransactionType.e_TwoTimesInMonthTransaction)
            {
                int nbMonthsPeriods = GetNbMonthPeriods(info, startPredictionDate, endTime, info.m_FirstTimeInMonth, fullPeriod);
                nbMonthsPeriods += GetNbMonthPeriods(info, startPredictionDate, endTime, info.m_SecondTimeInMonth, fullPeriod);
                return nbMonthsPeriods;
            }

            switch (info.m_PeriodLength)
            {
                case EPeriodLength.e_PerDay:
                    nb = 0;
                    if (!fullPeriod)
                    {
                        while (startTime.Date < startPredictionDate.Date)
                        {
                            startTime = startTime.AddDays(info.m_Period);
                        }
                    }
                    while (startTime.Date <= endTime.Date)
                    {
                        nb++;
                        startTime = startTime.AddDays(info.m_Period);
                    }
                    return nb;
                case EPeriodLength.e_PerWeek:
                case EPeriodLength.e_PerWeekAccelerated:
                    nb = 0;
                    if (!fullPeriod)
                    {
                        while (startTime.Date < startPredictionDate.Date)
                        {
                            startTime = startTime.AddDays(7 * info.m_Period);
                        }
                    }
                    while (startTime.Date <= endTime.Date)
                    {
                        nb++;
                        startTime = startTime.AddDays(7 * info.m_Period);
                    }
                    return nb;
                case EPeriodLength.e_PerMonth:
                    int nbMonthsPeriods = GetNbMonthPeriods(info, startPredictionDate, endTime, info.m_FirstTimeInMonth, fullPeriod);
                    return nbMonthsPeriods;
                case EPeriodLength.e_PerYear:
                    nb = 0;
                    if (!fullPeriod)
                    {
                        while (startTime.Date < startPredictionDate.Date)
                        {
                            startTime = startTime.AddYears(info.m_Period);
                        }
                    }
                    while (startTime.Date <= endTime.Date)
                    {
                        nb++;
                        startTime = startTime.AddYears(info.m_Period);
                    }
                    return nb;
            }
            return 0;
        }

        private static double GetAmountAlreadyPayed(TTransactionInfo info, int nbPeriods)
        {
            double amountAlreadyPayed = 0;
            string[] amounts = info.m_AmountAlreadyPayed.Split(';');

            if (amounts != null)
            {
                bool bSetComplete = false;
                for (int i = amounts.Length-1; i >= 0; i--)
                {
                    if (i < nbPeriods)
                    {
                        double amount = 0;
                        double.TryParse(amounts[i].Replace("C", "").Replace("$", "").Trim(), out amount);
                        if (bSetComplete && !amounts[i].StartsWith("C"))
                            amounts[i] = "C" + amounts[i];
                        if (!bSetComplete && (amounts[i].StartsWith("C") || amount != 0))
                            bSetComplete = true;
                    }
                }
                for (int i = 0; i < amounts.Length && i < nbPeriods; i++)
                {
                    double amount = 0;
                    double.TryParse(amounts[i].Replace("C", "").Replace("$", "").Trim(), out amount);

                    if (amounts[i].StartsWith("C"))
                        amountAlreadyPayed += info.m_Amount;
                    else
                    {
                        amountAlreadyPayed += (amount > info.m_Amount ? info.m_Amount : amount);
                    }
                }
            }
            return amountAlreadyPayed;
        }

        private DateTime m_startPredictionDate;
        private DateTime m_endPredictionDate;
        private int m_accountId;
        private Dictionary<int, TTransactionInfo> m_transactions;
    }
}
