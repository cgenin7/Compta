using System;
using System.Collections.Generic;
using ComptaCommun;
using ComptaDB;

namespace Comptability
{
	/// <summary>
	/// 
	/// </summary>
	public class ClassTransactions
	{
        public Dictionary<int, TTransactionInfo> Transactions
		{
			get { return m_Transactions; }
		}

        public List<TCategoryInfo> Categories
        {
            get { return m_Categories; }
        }

		#region Public Methods

		public static ClassTransactions GetTransactions()
		{
			if ( m_sTransactions == null )
				m_sTransactions = new ClassTransactions();
			return m_sTransactions;
		}

        public void LoadTransactionsFromDataStorage(TTransactionInfo transactionToFind, out int placementId)
        {
            m_Transactions = TransactionInfoData.GetTransactionsInfo(transactionToFind, out placementId);
        }

		public void LoadTransactionsFromDataStorage( )
		{
            m_Transactions = TransactionInfoData.GetTransactionsInfo();
		}

        public void LoadCategoriesFromDataStorage()
        {
            m_Categories = CategoryData.GetCategories();
        }

        public void ReinitializeAllTransactions(out Exception ex)
        {
            int currentYear = LocalSettings.BudgetYear;
            ex = null;

            if (m_Transactions != null)
            {
                foreach (TTransactionInfo info in m_Transactions.Values)
                {
                    if (info.m_Type != EType.e_Pret)
                    {
                        info.m_AmountAlreadyPayed = "0";
                        info.m_StartDate = new DateTime(currentYear, info.m_StartDate.Month, info.m_StartDate.Day);
                        info.m_EndDate = new DateTime(currentYear, info.m_EndDate.Month, info.m_EndDate.Day);
                    }
                }
                SaveTransactionsInDataStorage(out ex);
            }
        }

        public void VerifyTransactionDates(out Exception ex)
        {
            int currentYear = LocalSettings.BudgetYear;
            bool changesDone = false;
            ex = null;

            foreach (TTransactionInfo info in m_Transactions.Values)
            {
                if (info.m_Type != EType.e_Pret)
                {
                    if (info.m_StartDate.Year != currentYear)
                    {
                        info.m_StartDate = new DateTime(currentYear, info.m_StartDate.Month, info.m_StartDate.Day);
                        changesDone = true;
                    }
                    if (info.m_EndDate.Year != currentYear)
                    {
                        info.m_EndDate = new DateTime(currentYear, info.m_EndDate.Month, info.m_EndDate.Day);
                        changesDone = true;
                    }
                }
            }
            if (changesDone)
                SaveTransactionsInDataStorage(out ex);
        }

        public void SaveTransactionsInDataStorage(out Exception exception)
		{
            exception = null;
            Dictionary<int, TAccountInfo> accountsInfo = ClassAccounts.GetAccounts().AccountsInfo;
			foreach (TAccountInfo account in accountsInfo.Values)
			{
                if (account != null)
				{
                    SaveTransactionsInDataStorage(account.AccountId, out exception);
				}
			}
		}

        public void AddTransactionInDataStorage(TTransactionInfo info, out Exception exception)
		{
            TransactionInfoData.SaveTransaction(info, true, out exception);
        }

        public void UpdateTransactionInDataStorage(TTransactionInfo info, out Exception exception)
        {
            TransactionInfoData.SaveTransaction(info, false, out exception);
        }

        public void LoadTransactionFromDataStorage(TTransactionInfo transactionToFind, out int transactionId)
        {
            m_Transactions = TransactionInfoData.GetTransactionsInfo(transactionToFind, out transactionId);
        }

        public void SaveTransactionsInDataStorage(int AccountId, out Exception exception)
		{
            exception = null;
			if ( m_Transactions != null )
			{
                TransactionInfoData.SaveTransactionsInfo(m_Transactions, AccountId, out exception);
			}
		}

        public void DeleteTransactionFromDataStorage(int transactionId, out Exception exception)
        {
            exception = null;
            if (m_Transactions != null)
            {
                TransactionInfoData.DeleteTransaction(transactionId, out exception);
            }
        }

        public TAnnualRepartitionInfo CalculateAnnualTransactions(int year, int AccountId)
        {
            return ClassAnnualCalculation.CalculateAnnualTransactions(m_Transactions, year, AccountId);
		}

         public int GetSelectedIndex(int ListIndex, int AccountId, bool IsRevenu)
		{
			int NbEltsInList = 0;
            foreach (int transID in m_Transactions.Keys)
            {
				TTransactionInfo info = m_Transactions[transID];

                bool infoIsRevenu = info.m_Type == EType.e_Income;
                if (info.m_AccountId == AccountId &&
					infoIsRevenu == IsRevenu )
					NbEltsInList++;
				if ( NbEltsInList == (ListIndex+1) )
					return transID;
			}
			return -1;
		}

		public DateTime AddMonthPeriod( DateTime myDate, TTransactionInfo info )
		{
			return myDate;
		}

        public void FillPaiementDates(TTransactionInfo info, DateTime endPredictionDate, List<DateTime> dates)
        {
            DateTime endDate = (info.m_EndDate.Date < endPredictionDate.Date ? info.m_EndDate.Date : endPredictionDate.Date);
            if (info.m_TransactionMode != ETransactionMode.e_Automatique)
            {
                switch (info.m_eTransactionType)
                {
                    case ETransactionType.e_OneShotTransaction:
                        if (info.m_StartDate.Date <= endPredictionDate.Date)
                            dates.Add(info.m_StartDate);
                        break;
                    case ETransactionType.e_PeriodicTransaction:
                        FillPeriodicDates(info, endDate, dates);
                        break;
                    case ETransactionType.e_TwoTimesInMonthTransaction:
                        FillMonthDates(info.m_StartDate, info.m_FirstTimeInMonth, endDate, dates);
                        FillMonthDates(info.m_StartDate, info.m_SecondTimeInMonth, endDate, dates);
                        dates.Sort();
                        if (dates.Count >= 2 && dates[dates.Count - 2].Date > DateTime.Now.Date)
                            dates.RemoveAt(dates.Count - 1);
                        break;
                }
            }
        }

        #endregion

		#region Private Methods

		private ClassTransactions()
		{
		}

        private bool FillPeriodicDates(TTransactionInfo info, DateTime endPredictionDate, List<DateTime> dates)
        {
            if (info.m_Period <= 0)
                return false;

            DateTime paiementDate = info.m_StartDate;
            DateTime endDisplayDate = DateTime.Now.Date < endPredictionDate.Date ? DateTime.Now : endPredictionDate;
            switch (info.m_PeriodLength)
            {
                case EPeriodLength.e_PerDay:
                    while (paiementDate.Date <= endDisplayDate)
                    {
                        dates.Add(paiementDate);
                        paiementDate = paiementDate.AddDays(info.m_Period);
                    }
                    if (paiementDate.Date <= endPredictionDate.Date)
                        dates.Add(paiementDate);
                    break;
                case EPeriodLength.e_PerWeek:
                    while (paiementDate.Date <= endDisplayDate.Date)
                    {
                        dates.Add(paiementDate);
                        paiementDate = paiementDate.AddDays(info.m_Period * 7);
                    }
                    if (paiementDate.Date <= endPredictionDate.Date)
                        dates.Add(paiementDate);
                    break;
                case EPeriodLength.e_PerMonth:
                    FillMonthDates(info.m_StartDate, info.m_FirstTimeInMonth, endPredictionDate, info.m_Period, dates);
                    break;
                case EPeriodLength.e_PerYear:
                    while (paiementDate.Date <= endDisplayDate.Date)
                    {
                        dates.Add(paiementDate);
                        paiementDate = paiementDate.AddYears(info.m_Period);
                    }
                    if (paiementDate.Date <= endPredictionDate.Date)
                        dates.Add(paiementDate);
                    break;
            }
            return true;
        }

        private bool FillMonthDates(DateTime startDate, int timeInMonth, DateTime endDate, List<DateTime> dates)
        {
            return FillMonthDates(startDate, timeInMonth, endDate, 1, dates);
        }

        private bool FillMonthDates(DateTime startDate, int timeInMonth, DateTime endDate, int period, List<DateTime> dates)
        {
            DateTime paiementDate = startDate;
            if (timeInMonth == Util.LAST_DAY_OF_MONTH) //last day of month
                paiementDate = new DateTime(paiementDate.Year, paiementDate.Month, 1).AddMonths(1).AddDays(-1);
            else
            {
                if (paiementDate.Day > timeInMonth)
                    paiementDate = paiementDate.AddMonths(period);
                // CGe if 29, 30 or 31, may be invalid for some month
                paiementDate = new DateTime(paiementDate.Year, paiementDate.Month, timeInMonth);
            }
            while (paiementDate.Date <= DateTime.Now.Date)
            {
                if (timeInMonth == Util.LAST_DAY_OF_MONTH || timeInMonth == paiementDate.Day)
                    dates.Add(paiementDate);
                if (timeInMonth == Util.LAST_DAY_OF_MONTH) //last day of month
                    paiementDate = new DateTime(paiementDate.Year, paiementDate.Month, 1).AddMonths(period+1).AddDays(-1);
                else
                    paiementDate = paiementDate.AddMonths(period);
            }
            if (paiementDate.Date <= endDate.Date)
                dates.Add(paiementDate);
            return true;
        }

		#endregion

        private Dictionary<int, TTransactionInfo> m_Transactions;
        private List<TCategoryInfo> m_Categories;
		private static ClassTransactions m_sTransactions;
        public static string GOOD_NEWS = "GoodNews";
	}
}
