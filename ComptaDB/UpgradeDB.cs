using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace ComptaDB
{
    public class UpgradeDB
    {
        public static void UpgradeTables()
        {
            OleDbConnection DBConnection;
            
            if (ClassDataAccess.OpenComptaDataSource(out DBConnection))
            {
                OleDbTransaction MyTransaction = DBConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                //create the command object and store the sql query
                OleDbCommand aCommand = new OleDbCommand("SELECT * FROM VersionInfo", DBConnection, MyTransaction);
                try
                {
                    OleDbDataReader aReader = aCommand.ExecuteReader();

                    //Iterate through the database
                    if (aReader.Read())
                    {
                        int majorVersion = aReader.GetInt16(0);
                        int minorVersion = aReader.GetInt16(1);

                        if (majorVersion < 2)
                            UpgradeFrom1To2(MyTransaction, DBConnection);
                        if (majorVersion < 3)
                            UpgradeFrom2To3(MyTransaction, DBConnection);
                    }
                    else
                        UpgradeFrom1To2(MyTransaction, DBConnection);
                }
                catch // version table not yet created, create it
                {
                    ClassDataAccess.ExecuteCommand("CREATE TABLE VersionInfo (MajorVersion smallint, MinorVersion smallint)", MyTransaction, DBConnection);
                    UpgradeFrom1To2(MyTransaction, DBConnection);
                }
                MyTransaction.Commit();
            }
        }

        public static void UpgradeFrom1To2(OleDbTransaction MyTransaction, OleDbConnection DBConnection)
        {
            ClassDataAccess.ExecuteCommand("DELETE * FROM VersionInfo", MyTransaction, DBConnection);

            try
            {
                ClassDataAccess.ExecuteCommand("ALTER TABLE TransactionInfo ADD COLUMN PretInterestsPaiedDay int", MyTransaction, DBConnection);
            }
            catch { }
            ClassDataAccess.ExecuteCommand("INSERT INTO VersionInfo VALUES (2, 0)", MyTransaction, DBConnection);
        }

        public static void UpgradeFrom2To3(OleDbTransaction MyTransaction, OleDbConnection DBConnection)
        {
            ClassDataAccess.ExecuteCommand("DELETE * FROM VersionInfo", MyTransaction, DBConnection);

            try
            {
                ClassDataAccess.ExecuteCommand("ALTER TABLE TransactionInfo ADD COLUMN OrderID smallint", MyTransaction, DBConnection);
            }
            catch { }
            ClassDataAccess.ExecuteCommand("INSERT INTO VersionInfo VALUES (3, 0)", MyTransaction, DBConnection);
        }
    }

}
