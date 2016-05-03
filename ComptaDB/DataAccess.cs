using System;
using System.Data.OleDb;
using System.Globalization;
using System.Collections.Generic;
using ComptaCommun;

namespace ComptaDB
{
    public class ClassDataAccess
    {
        public static string GetNote()
        {
            OleDbConnection DBConnection;
            string Note = "";

            if (ClassDataAccess.OpenComptaDataSource(out DBConnection))
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
                    ClassDataAccess.CloseDataSource(DBConnection);
                    return "";
                }
                ClassDataAccess.CloseDataSource(DBConnection);
                return Note;
            }
            return "";
        }

        internal static bool OpenComptaDataSource(out OleDbConnection DBConnection)
        {
            //create the database connection
            DBConnection = new OleDbConnection("Provider= Microsoft.ACE.OLEDB.12.0;Data Source=" + LocalSettings.DatabasePath);
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
            catch (OleDbException ex)
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

            if (ClassDataAccess.OpenComptaDataSource(out DBConnection))
            {
                try
                {
                    OleDbCommand MyCommand = new OleDbCommand(SQLQuery, DBConnection);

                    MyCommand.ExecuteNonQuery();

                    ClassDataAccess.CloseDataSource(DBConnection);
                }
                catch (Exception ex)
                {
                    ClassDataAccess.CloseDataSource(DBConnection);
                    throw ex;
                }
            }
        }

    }
}
