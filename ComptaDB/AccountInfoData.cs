using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data.OleDb;
using ComptaCommun;

namespace ComptaDB
{
    public class AccountInfoData
    {
        public static Dictionary<int, TAccountInfo> GetAccountsInfo() // Array of TAccountInfo
        {
            OleDbConnection DBConnection;
            Dictionary<int, TAccountInfo> accountsInfo = new Dictionary<int, TAccountInfo>();

            if (ClassDataAccess.OpenComptaDataSource(out DBConnection))
            {
                //create the command object and store the sql query
                OleDbCommand aCommand = new OleDbCommand("SELECT * FROM AccountInfo ORDER BY ID", DBConnection);
                try
                {
                    //create the datareader object to connect to table
                    OleDbDataReader aReader = aCommand.ExecuteReader();

                    //Iterate through the database
                    while (aReader.Read())
                    {
                        TAccountInfo info = new TAccountInfo();

                        info.AccountId = aReader.GetInt16(0);
                        info.AccountName = aReader.GetString(1);
                        info.Balance = aReader.GetDouble(2);
                        try
                        {
                            info.StartPrediction = aReader.GetDateTime(3);
                        }
                        catch
                        {
                            info.StartPrediction = DateTime.Now;
                        }
                        info.PredictionDate = aReader.GetDateTime(4);
                        info.IncomesAtPredictionDate = aReader.GetDouble(5);
                        info.ExpensesAtPredictionDate = aReader.GetDouble(6);

                        try
                        {
                            info.Note = aReader.GetString(7);
                            info.MortgageBalance = aReader.GetDouble(8);
                        }
                        catch 
                        {
                            // CGe add log
                        }
                        
                        accountsInfo.Add(info.AccountId, info);
                    }

                    aReader.Close();
                }
                catch (OleDbException)
                {
                    ClassDataAccess.CloseDataSource(DBConnection);
                    return null;
                }
                ClassDataAccess.CloseDataSource(DBConnection);
                return accountsInfo;
            }
            return null;
        }

        public static void SaveAccountsInfo(Dictionary<int, TAccountInfo> accountsInfo, out Exception exception) // Array of TAccountInfo
        {
            OleDbConnection DBConnection;

            exception = null;
            if (ClassDataAccess.OpenComptaDataSource(out DBConnection))
            {
                OleDbTransaction MyTransaction = DBConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                try
                {
                    ClassDataAccess.ExecuteCommand("DELETE FROM AccountInfo", MyTransaction, DBConnection);

                    int i = 0;
                    foreach (TAccountInfo info in accountsInfo.Values)
                    {
                        if (info != null)
                        {
                            //create the command object and store the sql query
                            ClassDataAccess.ExecuteCommand("INSERT INTO AccountInfo VALUES ( " + info.AccountId + ", '" + info.AccountName + "', " + info.Balance.ToString(NumberFormatInfo.InvariantInfo) +
                                ", '" + info.StartPrediction.ToShortDateString() + "', '" + info.PredictionDate.ToShortDateString() + "', " + info.IncomesAtPredictionDate.ToString(NumberFormatInfo.InvariantInfo) + ", " +
                                info.ExpensesAtPredictionDate.ToString(NumberFormatInfo.InvariantInfo) + ", '" + info.Note.Replace("'", "''") + "', " + info.MortgageBalance.ToString(NumberFormatInfo.InvariantInfo) + ")", 
                                MyTransaction, DBConnection);
                            i++;
                        }
                    }
                    MyTransaction.Commit();
                    ClassDataAccess.CloseDataSource(DBConnection);
                }
                catch (Exception e)
                {
                    exception = e;
                    MyTransaction.Rollback();
                    ClassDataAccess.CloseDataSource(DBConnection);
                }
            }
        }

        public static void AddAccountInfo(TAccountInfo info)
        {
            ClassDataAccess.ExecuteQuery("INSERT INTO AccountInfo VALUES ( " + info.AccountId + ", '" + info.AccountName + "', " + info.Balance.ToString(NumberFormatInfo.InvariantInfo) +
                                ", '" + info.StartPrediction.ToShortDateString() + "', '" + info.PredictionDate.ToShortDateString() + "', " + info.IncomesAtPredictionDate.ToString(NumberFormatInfo.InvariantInfo) + ", " +
                                info.ExpensesAtPredictionDate.ToString(NumberFormatInfo.InvariantInfo) + ", '" + info.Note.Replace("'", "''") + "', " + info.MortgageBalance.ToString(NumberFormatInfo.InvariantInfo) + ")");
        }

        public static void DeleteAccountInfo(int accountId)
        {
            ClassDataAccess.ExecuteQuery("DELETE FROM TransactionInfo WHERE AccountId = " + accountId);
            ClassDataAccess.ExecuteQuery("DELETE FROM TransactionInfo WHERE TransferAccountId = " + accountId);
            ClassDataAccess.ExecuteQuery("DELETE FROM HistoryInfo WHERE AccountId = " + accountId);
            ClassDataAccess.ExecuteQuery("DELETE FROM AccountInfo WHERE ID = " + accountId);
        }

        public static void RenameAccount(int accountId, string newName)
        {
            ClassDataAccess.ExecuteQuery("UPDATE AccountInfo Set AccountName = '" + newName + "' WHERE ID = " + accountId);
        }

    }
}
