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
                        try
                        {
                            Note = aReader.GetString(0);
                        }
                        catch (InvalidCastException)
                        {
                        }
                    }

                    aReader.Close();
                }
                catch (OleDbException)
                {
                    CloseDataSource(DBConnection);
                    return "";
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
                return false;
            }
            return true;
        }

        internal static bool OpenPlacementsDataSource(out OleDbConnection DBConnection)
        {
            //create the database connection
            DBConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + LocalSettings.PlacementsPath);
            try
            {
                DBConnection.Open();
            }
            catch 
            {
                return false;
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
                catch (Exception ex)
                {
                    CloseDataSource(DBConnection);
                    throw ex;
                }
            }
        }

    }
}
