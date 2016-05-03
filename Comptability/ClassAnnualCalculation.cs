using System;
using System.Collections.Generic;
using System.Text;
using ComptaCommun;

namespace Comptability
{
    public class ClassAnnualCalculation
    {
        public static TAnnualRepartitionInfo CalculateAnnualTransactions(Dictionary<int, TTransactionInfo> transactions, int year, int accountId)
        {
            TAnnualRepartitionInfo annualInfo = new TAnnualRepartitionInfo();

            if (transactions != null)
            {
                foreach (int transID in transactions.Keys)
                {
                    TTransactionInfo info = transactions[transID];

                    string sCategory = ClassTools.GetCategory(info.m_Category, ClassTransactions.GetTransactions().Categories);

                    if (AddInAnnualReport(info, accountId))
                        CalculateAnnualTransaction(year, info, accountId, annualInfo);
                }
            }

            return annualInfo;
        }

        public static double GetAnnualTransactionBalance(int year, TTransactionInfo info)
        {
            switch (info.m_eTransactionType)
            {
                case ETransactionType.e_OneShotTransaction:
                    if (info.m_StartDate.Year == year)
                        return info.m_Amount;
                    break;
                case ETransactionType.e_PeriodicTransaction:
                case ETransactionType.e_TwoTimesInMonthTransaction:
                    return GetAnnualPeriodicBalance(year, info);
            }
            return 0;
        }

        private static bool AddInAnnualReport(TTransactionInfo info, int accountId)
        {
            if (accountId == -1 || info.m_AccountId == accountId)
            {
                if (!info.m_RemoveFromAnnualReport)
                    return true;
            }
            return false;
        }

        private static void CalculateAnnualTransaction(int year, TTransactionInfo info, int accountId, TAnnualRepartitionInfo annualInfo)
        {
            EType detailType = EType.e_Expense;
            double amount = GetAnnualTransactionBalance(year, info);

            if (Math.Abs(amount) >= 0.01)
            {
                if (info.m_Type == EType.e_Income)
                {
                    annualInfo.TotalIncomes += amount;
                    detailType = EType.e_Income;
                    AddEntry(info, detailType, annualInfo, amount);
                }
                if (info.m_Type == EType.e_Expense || info.m_Type == EType.e_Pret)
                {
                    annualInfo.TotalExpenses += amount;
                    detailType = EType.e_Expense;
                    AddEntry(info, detailType, annualInfo, amount);
                }
            }
        }

        private static void AddEntry(TTransactionInfo info, EType detailType, TAnnualRepartitionInfo annualInfo, double amount)
        {
            TCategoryDetails details;

            string key = info.m_Category.ToString() + detailType;
            if (annualInfo.CategoryDetails.ContainsKey(key))
                details = annualInfo.CategoryDetails[key];
            else
                details = new TCategoryDetails();
            details.CategoryAmount += amount;
            details.CategoryId = info.m_Category;
            details.Type = detailType;
            
            annualInfo.CategoryDetails[key] = details;
        }

        private static double GetAnnualPeriodicBalance(int year, TTransactionInfo info)
        {
            DateTime startDate = info.m_StartDate;
            DateTime endDate = info.m_EndDate;

            if (endDate.Year > year)
                endDate = new DateTime(year, 12, 31);

            if (info.m_Type == EType.e_Pret)
            {
                while (startDate.Year < year)
                    startDate = Util.GetNextPaiementDate(info, startDate);
            }

            if (startDate.Year == year && endDate.Year == year)
            {
                int nbPeriods = Util.GetNbPeriods(info, startDate, endDate);
                if (info.m_Type == EType.e_Pret)
                    return nbPeriods * info.m_PretAmountPerPaiement;
                return nbPeriods * info.m_Amount;
            }
            return 0;
        }
    }
}
