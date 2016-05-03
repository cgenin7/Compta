using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data.OleDb;
using ComptaCommun;

namespace ComptaDB
{
    public class HistoryInfoData
    {
        public static List<THistoryInfo> GetHistoryInfo(int AccountId)
        {
            OleDbConnection DBConnection;
            List<THistoryInfo> HistoryInfo = new List<THistoryInfo>();

            if (ClassDataAccess.OpenComptaDataSource(out DBConnection))
            {
                //create the command object and store the sql query
                OleDbCommand aCommand = new OleDbCommand("SELECT * FROM HistoryInfo WHERE AccountId = " + AccountId + " ORDER BY HistoryDate", DBConnection);
                try
                {
                    //create the datareader object to connect to table
                    OleDbDataReader aReader = aCommand.ExecuteReader();

                    //Iterate through the database
                    while (aReader.Read())
                    {
                        THistoryInfo info = new THistoryInfo();

                        try
                        {
                            info.m_HistoryDate = aReader.GetDateTime(0);
                            info.m_AccountId = aReader.GetInt16(1);
                            info.m_Incomes = aReader.GetDouble(2);
                            info.m_Expenses = aReader.GetDouble(3);
                            info.m_AccountBalance = aReader.GetDouble(4);
                            
                            try // new fields, not in old db
                            {
                                info.m_TransferIncomes = aReader.GetDouble(5);
                                info.m_TransferExpenses = aReader.GetDouble(6);
                                info.m_MortgageBalance = aReader.GetDouble(7);
                                info.m_PredictionDate = aReader.GetDateTime(10);
                            }
                            catch
                            { }

                            HistoryInfo.Add(info);
                        }
                        catch (InvalidCastException)
                        {
                        }
                    }

                    aReader.Close();
                }
                catch (OleDbException)
                {
                    ClassDataAccess.CloseDataSource(DBConnection);
                    return null;
                }
                ClassDataAccess.CloseDataSource(DBConnection);
                return HistoryInfo;
            }
            return null;
        }

        public static void SaveHistoryInfo(List<THistoryInfo> HistoryInfo, int AccountId, out Exception exception)
        {
            OleDbConnection DBConnection;

            exception = null;
            if (ClassDataAccess.OpenComptaDataSource(out DBConnection))
            {
                OleDbTransaction MyTransaction = DBConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                try
                {
                    ClassDataAccess.ExecuteCommand("DELETE FROM HistoryInfo WHERE AccountId = " + AccountId, MyTransaction, DBConnection);

                    for (int i = 0; i < HistoryInfo.Count; i++)
                    {
                        THistoryInfo historyInfo = HistoryInfo[i];
                        if (historyInfo != null)
                        {
                            //create the command object and store the sql query
                            try  // new fields, not present in old DB
                            {
                                ClassDataAccess.ExecuteCommand(FormatHistoryStartCmd(historyInfo) + ", " + historyInfo.m_TransferIncomes.ToString(NumberFormatInfo.InvariantInfo) + ", " +
                                    historyInfo.m_TransferExpenses.ToString(NumberFormatInfo.InvariantInfo) + ", " + historyInfo.m_MortgageBalance.ToString(NumberFormatInfo.InvariantInfo) + ", '" + historyInfo.m_PredictionDate.ToShortDateString() + "' )", MyTransaction, DBConnection);
                            }
                            catch
                            {
                                historyInfo.m_Expenses += historyInfo.m_TransferExpenses;
                                historyInfo.m_Incomes += historyInfo.m_TransferIncomes;
                                ClassDataAccess.ExecuteCommand(FormatHistoryShortCmd(historyInfo) + " )", MyTransaction, DBConnection);
                            }
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

        public static void DeleteHistory(int AccountId)
        {
            ClassDataAccess.ExecuteQuery("DELETE FROM HistoryInfo WHERE AccountId = " + AccountId);
        }

        private static string FormatHistoryStartCmd(THistoryInfo info)
        {
            return "INSERT INTO HistoryInfo (HistoryDate, AccountId, Income, Expenses, AccountBalance, TransferIncome, TransferExpenses, MortgageBalance, PredictionDate) VALUES ( '" + info.m_HistoryDate.ToShortDateString() + "', " + info.m_AccountId +
                                    ", " + info.m_Incomes.ToString(NumberFormatInfo.InvariantInfo) + ", " +
                                    info.m_Expenses.ToString(NumberFormatInfo.InvariantInfo) + ", " + info.m_AccountBalance.ToString(NumberFormatInfo.InvariantInfo);
        }

        private static string FormatHistoryShortCmd(THistoryInfo info)
        {
            return "INSERT INTO HistoryInfo (HistoryDate, AccountId, Income, Expenses, AccountBalance) VALUES ( '" + info.m_HistoryDate.ToShortDateString() + "', " + info.m_AccountId +
                                    ", " + info.m_Incomes.ToString(NumberFormatInfo.InvariantInfo) + ", " +
                                    info.m_Expenses.ToString(NumberFormatInfo.InvariantInfo) + ", " + info.m_AccountBalance.ToString(NumberFormatInfo.InvariantInfo);
        }
    }
}
