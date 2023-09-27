using System;
using System.Data.OleDb;
using ComptaCommun;

namespace ComptaDB
{
    public class ClassDataAccess
    {
        public static string GetNote()
        {
            OleDbConnection DBConnection;
            string Note = "";

            if (OpenComptaDataSource(out DBConnection))
            {
                //create the command object and store the sql query
                OleDbCommand aCommand = new OleDbCommand("SELECT * FROM Notes", DBConnection);
                try
                {
                    //create the datareader object to connect to table
                    OleDbDataReader aReader = aCommand.ExecuteReader();

                    //Iterate through the database
                    while (aReader.Read())
                    {
                        Note = aReader.GetString(0);
                    }

                    aReader.Close();
                }
                catch (OleDbException)
                {
                    CloseDataSource(DBConnection);
                    throw;
                }
                CloseDataSource(DBConnection);
                return Note;
            }
            return "";
        }

        internal static bool OpenComptaDataSource(out OleDbConnection DBConnection)
        {
            string connectionString = "Provider= Microsoft.ACE.OLEDB.12.0;Data Source=" + LocalSettings.DatabasePath;
            //create the database connection
            DBConnection = new OleDbConnection(connectionString);
            try
            {
                DBConnection.Open();
            }
            catch (OleDbException)
            {
                throw;
            }
            return true;
        }

        internal static void CloseDataSource(OleDbConnection DBConnection)
        {
            try
            {
                DBConnection.Close();
            }
            catch (OleDbException)
            {
            }
        }

        internal static void ExecuteCommand(string command, OleDbTransaction transaction, OleDbConnection DBConnection)
        {
            OleDbCommand MyCommand = new OleDbCommand(command, DBConnection);

            MyCommand.Transaction = transaction;
            MyCommand.ExecuteNonQuery();
        }

        internal static void ExecuteQuery(String SQLQuery)
        {
            OleDbConnection DBConnection;

            if (OpenComptaDataSource(out DBConnection))
            {
                try
                {
                    OleDbCommand MyCommand = new OleDbCommand(SQLQuery, DBConnection);

                    MyCommand.ExecuteNonQuery();

                    CloseDataSource(DBConnection);
                }
                catch
                {
                    CloseDataSource(DBConnection);
                    throw;
                }
            }
        }

    }
}
