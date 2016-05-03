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

        /* public static void UpgradeFrom1_0To2_0()
        {
            try
            {
                ClassDataAccess.ExecuteQuery("ALTER TABLE AccountInfo ADD COLUMN MortgageBalance double");
            }
            catch { }
            try
            {
                ClassDataAccess.ExecuteQuery("ALTER TABLE TransactionInfo DROP COLUMN AmountPeriod");
                ClassDataAccess.ExecuteQuery("ALTER TABLE TransactionInfo ADD COLUMN Category smallint"); 
                ClassDataAccess.ExecuteQuery("ALTER TABLE TransactionInfo ADD COLUMN Type smallint");
                ClassDataAccess.ExecuteQuery("ALTER TABLE TransactionInfo ADD COLUMN InterestRate double");
                ClassDataAccess.ExecuteQuery("ALTER TABLE TransactionInfo ADD COLUMN PretPaiementType smallint");
                ClassDataAccess.ExecuteQuery("ALTER TABLE TransactionInfo ADD COLUMN PretPaiement double");
                ClassDataAccess.ExecuteQuery("ALTER TABLE TransactionInfo ADD COLUMN PretType smallint");
                ClassDataAccess.ExecuteQuery("ALTER TABLE TransactionInfo ADD COLUMN RemoveFromAnnualReport smallint");
                ClassDataAccess.ExecuteQuery("UPDATE TransactionInfo SET Type=0 WHERE IsRevenu=true");
                ClassDataAccess.ExecuteQuery("UPDATE TransactionInfo SET Type=2 WHERE IsTransfer=true");
                ClassDataAccess.ExecuteQuery("UPDATE TransactionInfo SET Type=1 WHERE IsTransfer=false AND IsRevenu=false");
                ClassDataAccess.ExecuteQuery("ALTER TABLE TransactionInfo DROP COLUMN IsRevenu");
                ClassDataAccess.ExecuteQuery("ALTER TABLE TransactionInfo DROP COLUMN IsTransfer");
                ClassDataAccess.ExecuteQuery("CREATE TABLE Category (Id smallint, Name char(50))");
                ClassDataAccess.ExecuteQuery("UPDATE TransactionInfo Set Category = 0, InterestRate = 0, PretPaiementType = 0, PretPaiement = 0, PretType = 0, RemoveFromAnnualReport = false");
            }
            catch {}
            
            OleDbConnection DBConnection;
            if (ClassDataAccess.OpenDataSource(out DBConnection))
            {
                OleDbTransaction MyTransaction = DBConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                try
                {
                    ClassDataAccess.ExecuteCommand("DELETE * FROM Category", MyTransaction, DBConnection);
                    ClassDataAccess.ExecuteCommand("INSERT INTO Category VALUES ( " + 0 + ", 'Autres'" + " )", MyTransaction, DBConnection);
                    ClassDataAccess.ExecuteCommand("INSERT INTO Category VALUES ( " + 1 + ", 'Economies'" + " )", MyTransaction, DBConnection);
                    ClassDataAccess.ExecuteCommand("INSERT INTO Category VALUES ( " + 2 + ", 'Electricité/chauffage'" + " )", MyTransaction, DBConnection);
                    ClassDataAccess.ExecuteCommand("INSERT INTO Category VALUES ( " + 3 + ", 'Enfants'" + " )", MyTransaction, DBConnection);
                    ClassDataAccess.ExecuteCommand("INSERT INTO Category VALUES ( " + 4 + ", 'Epicerie'" + " )", MyTransaction, DBConnection);
                    ClassDataAccess.ExecuteCommand("INSERT INTO Category VALUES ( " + 5 + ", 'Prêt/Hypothèque'" + " )", MyTransaction, DBConnection);
                    ClassDataAccess.ExecuteCommand("INSERT INTO Category VALUES ( " + 6 + ", 'Loisirs'" + " )", MyTransaction, DBConnection);
                    ClassDataAccess.ExecuteCommand("INSERT INTO Category VALUES ( " + 7 + ", 'Maison'" + " )", MyTransaction, DBConnection);
                    ClassDataAccess.ExecuteCommand("INSERT INTO Category VALUES ( " + 8 + ", 'Salaire'" + " )", MyTransaction, DBConnection);
                    ClassDataAccess.ExecuteCommand("INSERT INTO Category VALUES ( " + 9 + ", 'Subv. gouvernement'" + " )", MyTransaction, DBConnection);
                    ClassDataAccess.ExecuteCommand("INSERT INTO Category VALUES ( " + 10 + ", 'Taxes/Assurances'" + " )", MyTransaction, DBConnection);
                    ClassDataAccess.ExecuteCommand("INSERT INTO Category VALUES ( " + 11 + ", 'Télécomunications'" + " )", MyTransaction, DBConnection);
                    ClassDataAccess.ExecuteCommand("INSERT INTO Category VALUES ( " + 12 + ", 'Voitures'" + " )", MyTransaction, DBConnection);
                    ClassDataAccess.ExecuteCommand("INSERT INTO Category VALUES ( " + 13 + ", 'Epicerie'" + " )", MyTransaction, DBConnection);
                    ClassDataAccess.ExecuteCommand("INSERT INTO Category VALUES ( " + 14 + ", 'Essence'" + " )", MyTransaction, DBConnection);

                    MyTransaction.Commit();
                    ClassDataAccess.CloseDataSource(DBConnection);
                }
                catch
                {
                    MyTransaction.Rollback();
                    ClassDataAccess.CloseDataSource(DBConnection);
                }
            }
        }*/
    }

}
