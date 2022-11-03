using System;
using System.Collections;
using System.Collections.Generic;

namespace ComptaCommun
{
    /// <summary>
    /// Summary description for ClassDataAccess.
    /// </summary>
    /// 
    public class TWarningInfo
    {
        public bool m_IsRevenu;
        public int m_TransactionNo;
        public string m_Warning;
    }

    public class TAccountInfo
    {
        public int AccountId;
        public String AccountName;
        public double Balance;
        public DateTime StartPrediction;
        public DateTime PredictionDate;
        public double IncomesAtPredictionDate;
        public double TransferIncomes;
        public double ExpensesAtPredictionDate;
        public double TransferExpenses;
        public string Note;
        public double MortgageBalance;
        public bool RemoveFromSummary;

        // Not Saved in DB
        public ArrayList m_Warnings; // Contains TWarningInfo, not saved in database

        public double PredictedBalanceAtEndDate
        {
            get { return Balance + IncomesAtPredictionDate - ExpensesAtPredictionDate + MortgageBalance;  }
        }

        public TAccountInfo()
        {
            PredictionDate = DateTime.Today.AddYears(1).Date;
            IncomesAtPredictionDate = 0;
            ExpensesAtPredictionDate = 0;
            Note = "";
        }
    }

    public class TToComeInfo: TDisplayInfo
    {
        public TToComeInfo(string displayString, int id, int orderId, EType type, int accountId, double nextPaymentAmount):
            base(displayString, id, orderId, type, accountId)
        {
            NextPaymentAmount = nextPaymentAmount;
        }

        public double NextPaymentAmount { get; private set; }
    }

    public class TDisplayInfo
    {
        public TDisplayInfo(string displayString, int id, int orderId, EType type, int accountId)
        {
            DisplayString = displayString;
            ID = id;
            DataType = type;
            AccountId = accountId;
        }

        public string DisplayString;
        public int ID;
        public int OrderIndex;
        public EType DataType;
        public DateTime Date;
        public int AccountId;
     
        public override string ToString()
        {
            return DisplayString;
        }
    }

    public enum EType
    {
        e_Income = 0,
        e_Expense = 1
    }

 
    public class THistoryInfo
    {
        public DateTime m_HistoryDate;
        public DateTime m_PredictionDate = DateTime.MinValue;
        public int m_AccountId;
        public double m_Incomes;
        public double m_Expenses;
        public double m_TransferIncomes;
        public double m_TransferExpenses;
        public double m_AccountBalance;
    }

    public enum ETransactionType
    {
        e_OneShotTransaction = 0,
        e_PeriodicTransaction = 1,
        e_TwoTimesInMonthTransaction = 3
    };

    public enum EPeriodLength
    {
        e_PerDay,
        e_PerWeek,
        e_PerMonth,
        e_PerYear
    };

    public class TTransactionInfo
    {
        public ETransactionType m_eTransactionType;

        public int m_ID;
        public int m_OrderID;
        public EType m_Type;
        public int m_AccountId = -1;
        public string m_TransactionName;
        public double m_Amount;
        public int m_Category;
        public bool m_RemoveFromAnnualReport;

        // OneShotTransaction, PeriodicTransaction, OneTimeInMonthTransaction, TwoTimesInMonthTransaction
        public DateTime m_StartDate;

        // PeriodicTransaction, OneTimeInMonthTransaction, TwoTimesInMonthTransaction
        public DateTime m_EndDate = DateTime.MinValue;

        // PeriodicTransaction
        public int m_Period;
        public EPeriodLength m_PeriodLength; // day, week, month or year

        // OneTimeInMonthTransaction, TwoTimesInMonthTransaction 
        public int m_FirstTimeInMonth; // 29 = Last day of month

        // TwoTimesInMonthTransaction
        public int m_SecondTimeInMonth; // 29 = Last day of month 

        public string m_AmountAlreadyPayed;
        public string m_Note;
        public ETransactionMode m_TransactionMode;
        
        // not saved in database
        public string m_Warning = "";
        public double m_Balance;
        public DateTime m_FirstPaiementDate;
        public DateTime m_LastPaiementDate;
        public int m_NbRemainingPaiements;
        public int m_TotalNbPaiements;
       
        public double m_TotalAmountPaiedForTheYear; // 

        public TTransactionInfo()
        {
        }

        public TTransactionInfo(TTransactionInfo info)
        {
            m_AccountId = info.m_AccountId;
            m_Amount = info.m_Amount;
            m_AmountAlreadyPayed = info.m_AmountAlreadyPayed;
            m_Balance = info.m_Balance;
            m_EndDate = info.m_EndDate;
            m_eTransactionType = info.m_eTransactionType;
            m_FirstPaiementDate = info.m_FirstPaiementDate;
            m_FirstTimeInMonth = info.m_FirstTimeInMonth;
            m_ID = info.m_ID;
            m_OrderID = info.m_OrderID;
            m_TransactionMode = info.m_TransactionMode;
            m_LastPaiementDate = info.m_LastPaiementDate;
            m_NbRemainingPaiements = info.m_NbRemainingPaiements;
            m_Note = info.m_Note;
            m_Period = info.m_Period;
            m_PeriodLength = info.m_PeriodLength;
            m_SecondTimeInMonth = info.m_SecondTimeInMonth;
            m_StartDate = info.m_StartDate;
            m_TotalNbPaiements = info.m_TotalNbPaiements;
            m_TransactionName = info.m_TransactionName;
            m_Type = info.m_Type;
            m_Warning = info.m_Warning;
            m_Category = info.m_Category;
            m_RemoveFromAnnualReport = info.m_RemoveFromAnnualReport;
        }

        public bool IsEqual(TTransactionInfo info)
        {
            if (info.m_Amount != m_Amount)
                return false;
            if (info.m_TransactionMode != ETransactionMode.e_Automatique && info.m_AmountAlreadyPayed != m_AmountAlreadyPayed)
                return false;
            if (info.m_eTransactionType != m_eTransactionType)
                return false;
            if (info.m_FirstTimeInMonth != m_FirstTimeInMonth)
                return false;
            if (info.m_TransactionMode != m_TransactionMode)
                return false;
            if (info.m_Type != m_Type)
                return false;
            if (info.m_Note != m_Note)
                return false;
            if (info.m_Period != m_Period)
                return false;
            if (info.m_PeriodLength != m_PeriodLength)
                return false;
            if (info.m_SecondTimeInMonth != m_SecondTimeInMonth)
                return false;
            if (info.m_StartDate.Date != m_StartDate.Date)
                return false;
            if (info.m_TransactionName != m_TransactionName)
                return false;
            if (info.m_Category != m_Category)
                return false;
            if (info.m_RemoveFromAnnualReport != m_RemoveFromAnnualReport)
                return false;
            return true;
        }
    }

    public enum ETransactionMode
    {
        e_Manual,
        e_Automatique
    }

    public class TPaiementInfo
    {
        public int TransactionId;
        public DateTime PaiementDate;
        public double Amount;
        public bool IsCompleted;
    }

    public class TCategoryInfo
    {
        public int Id;
        public string Name;
    }

    public class TAnnualRepartitionInfo
    {
        public Dictionary<string, TCategoryDetails> CategoryDetails = new Dictionary<string, TCategoryDetails>();
        public double TotalIncomes;
        public double TotalExpenses;
    }

    public class TCategoryDetails
    {
        public int CategoryId;
        public EType Type;
        public double CategoryAmount;
    }

    public class TPredictedBalance
    {
        public TPredictedBalance(int accountId, DateTime startPredictionDate, DateTime endPredictionDate)
        {
            AccountId = accountId;
            StartPredictionDate = startPredictionDate;
            EndPredictionDate = endPredictionDate;
        }

        public int AccountId { get; private set; }
        public DateTime StartPredictionDate { get; private set; }
        public DateTime EndPredictionDate { get; private set; }
        public double Incomes;
        public double Expenses;
        public double TotalPretsRemaining;
        public double TotalPrets;

        public double IncomesForTheYear;
        public double ExpensesForTheYear;
        public double TotalPretsForTheYear;
    }
}
