using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data.OleDb;
using ComptaCommun;

namespace ComptaDB
{
    public class TransactionInfoData
    {
        public static Dictionary<int, TTransactionInfo> GetTransactionsInfo()
        {
            int transactionId;
            return GetTransactionsInfo(null, out transactionId);
        }

        public static Dictionary<int, TTransactionInfo> GetTransactionsInfo(TTransactionInfo transactionToFind, out int transactionId)
        {
            return GetTransactionsInfo(transactionToFind, out transactionId, true);
        }

        public static void SaveTransaction(TTransactionInfo info, bool isNewTransaction)
        {
            OleDbConnection DBConnection;

            if (ClassDataAccess.OpenComptaDataSource(out DBConnection))
            {
                OleDbTransaction MyTransaction = DBConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                try
                {
                    if (isNewTransaction)
                        ClassDataAccess.ExecuteCommand(FormatInsertTransaction(info), MyTransaction, DBConnection);
                    else
                        ClassDataAccess.ExecuteCommand(FormatUpdateTransactionInfoValues(info), MyTransaction, DBConnection);
                    MyTransaction.Commit();
                    ClassDataAccess.CloseDataSource(DBConnection);
                }
                catch
                {
                    MyTransaction.Rollback();
                    ClassDataAccess.CloseDataSource(DBConnection);
                    throw;
                }
            }
        }

        public static void SaveTransactionsInfo(Dictionary<int, TTransactionInfo> transactions, int AccountId)
        {
            OleDbConnection DBConnection;

            if (ClassDataAccess.OpenComptaDataSource(out DBConnection))
            {
                OleDbTransaction MyTransaction = DBConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                try
                {
                    ClassDataAccess.ExecuteCommand("DELETE FROM TransactionInfo WHERE AccountId = " + AccountId, MyTransaction, DBConnection);

                    if (transactions != null)
                    {
                        foreach (int transID in transactions.Keys)
                        {
                            TTransactionInfo info = transactions[transID] as TTransactionInfo;
                            if (info.m_AccountId == AccountId)
                            {
                                //create the command object and store the sql query
                                ClassDataAccess.ExecuteCommand(FormatInsertTransaction(info), MyTransaction, DBConnection);
                            }
                        }
                    }
                    MyTransaction.Commit();
                    ClassDataAccess.CloseDataSource(DBConnection);
                }
                catch
                {
                    MyTransaction.Rollback();
                    ClassDataAccess.CloseDataSource(DBConnection);
                    throw;
                }
            }
        }

        public static void DeleteTransaction(int transactionId)
        {
            ClassDataAccess.ExecuteQuery("DELETE FROM TransactionInfo WHERE ID = " + transactionId);
        }

        private static Dictionary<int, TTransactionInfo> GetTransactionsInfo(TTransactionInfo transactionToFind, out int transactionId, bool performUpgrade)
        {
            OleDbConnection DBConnection;
            Dictionary<int, TTransactionInfo> transactions = new Dictionary<int, TTransactionInfo>();

            transactionId = -1;
            if (ClassDataAccess.OpenComptaDataSource(out DBConnection))
            {
                //create the command object and store the sql query
                OleDbCommand aCommand = new OleDbCommand("SELECT * FROM TransactionInfo ORDER BY RemoveFromAnnualReport, Category, OrderId", DBConnection);
                try
                {
                    //create the datareader object to connect to table
                    OleDbDataReader aReader = aCommand.ExecuteReader();

                    //Iterate through the database
                    while (aReader.Read())
                    {
                        TTransactionInfo info = new TTransactionInfo();

                        info.m_ID = aReader.GetInt32(0);
                        info.m_AccountId = aReader.GetInt16(1);
                        info.m_TransactionName = aReader.GetString(2);
                        info.m_eTransactionType = (ETransactionType)aReader.GetInt16(3);
                        info.m_Amount = aReader.GetDouble(4);
                        info.m_StartDate = aReader.GetDateTime(5);
                        info.m_EndDate = aReader.GetDateTime(6);
                        info.m_Period = aReader.GetInt16(7);
                        info.m_PeriodLength = (EPeriodLength)aReader.GetInt16(8);
                        info.m_FirstTimeInMonth = aReader.GetInt16(9);
                        info.m_FirstTimeInMonth = (info.m_FirstTimeInMonth > 29 ? 29 : info.m_FirstTimeInMonth);
                        info.m_SecondTimeInMonth = aReader.GetInt16(10);
                        info.m_SecondTimeInMonth = (info.m_SecondTimeInMonth > 29 ? 29 : info.m_SecondTimeInMonth);
                        info.m_AmountAlreadyPayed = aReader.GetString(11);
                        info.m_Note = aReader.GetString(12);
                        info.m_TransactionMode = (ETransactionMode)aReader.GetInt16(13);
                        //info.m_nextVirementDate = aReader.GetDateTime(16);
                        //info.m_nextVirementAmount = aReader.GetDouble(17);
                        info.m_Category = aReader.GetInt16(18);
                        info.m_Type = (EType)aReader.GetInt16(19);
                        
                        info.m_RemoveFromAnnualReport = (aReader.GetInt16(24) == 0 ? false : true);
                        info.m_OrderID = aReader.GetInt16(26);
                        if (transactionToFind != null)
                        {
                            if (transactionToFind.IsEqual(info))
                                transactionId = info.m_ID;
                        }

                        transactions.Add(info.m_ID, info);
                    }

                    aReader.Close();
                }
                catch (Exception ex)
                {
                    ClassDataAccess.CloseDataSource(DBConnection);
                    throw ex;
                }
                ClassDataAccess.CloseDataSource(DBConnection);
                return transactions;
            }
            return null;
        }

        private static string FormatInsertTransaction(TTransactionInfo info)
        {
            return $@"INSERT INTO TransactionInfo (AccountId, TransactionName, Category, TransactionType, Amount, StartDate, EndDate, Period, PeriodLength,
                FirstTimeInMonth, SecondTimeInMonth, AmountAlreadyPayed, Notes, TransactionMode, Type, RemoveFromAnnualReport, OrderID) 
                VALUES ({info.m_AccountId}, '{info.m_TransactionName.Replace("'", "''")}', {info.m_Category}, {(int)info.m_eTransactionType}, 
                {info.m_Amount.ToString(NumberFormatInfo.InvariantInfo)}, '{info.m_StartDate.ToShortDateString()}', '{info.m_EndDate.ToShortDateString()}', 
                {info.m_Period}, {(int)info.m_PeriodLength}, {info.m_FirstTimeInMonth}, {info.m_SecondTimeInMonth}, '{info.m_AmountAlreadyPayed}', '{info.m_Note.Replace("'", "''")}', 
                {(int)info.m_TransactionMode}, {(int)info.m_Type}, {info.m_RemoveFromAnnualReport}, {info.m_OrderID})";
        }

        private static string FormatUpdateTransactionInfoValues(TTransactionInfo info)
        {
            return $@"UPDATE TransactionInfo SET AccountId = {info.m_AccountId}, TransactionName = '{info.m_TransactionName.Replace("'", "''")}', Category = {info.m_Category}, 
                TransactionType = {(int)info.m_eTransactionType}, Amount = {info.m_Amount.ToString(NumberFormatInfo.InvariantInfo)}, StartDate = '{info.m_StartDate.ToShortDateString()}', 
                EndDate = '{info.m_EndDate.ToShortDateString()}', Period = {info.m_Period}, PeriodLength = {(int)info.m_PeriodLength}, FirstTimeInMonth = {info.m_FirstTimeInMonth},
                SecondTimeInMonth = {info.m_SecondTimeInMonth}, AmountAlreadyPayed = '{info.m_AmountAlreadyPayed}', Notes = '{info.m_Note.Replace("'", "''")}', 
                TransactionMode = {(int)info.m_TransactionMode}, Type = {(int)info.m_Type}, RemoveFromAnnualReport = {info.m_RemoveFromAnnualReport}, OrderID = {info.m_OrderID} 
                WHERE ID = {info.m_ID}";
        }

    }
}
