using System;
using System.Collections.Generic;
using System.Data.OleDb;
using ComptaCommun;

namespace ComptaDB
{
    public class CategoryData
    {
        public static List<TCategoryInfo> GetCategories()
        {
            OleDbConnection DBConnection;
            List<TCategoryInfo> categoryInfo = new List<TCategoryInfo>();

            if (ClassDataAccess.OpenComptaDataSource(out DBConnection))
            {
                //create the command object and store the sql query
                OleDbCommand aCommand = new OleDbCommand("SELECT * FROM Category ORDER BY Id", DBConnection);
                try
                {
                    //create the datareader object to connect to table
                    OleDbDataReader aReader = aCommand.ExecuteReader();

                    //Iterate through the database
                    while (aReader.Read())
                    {
                        TCategoryInfo info = new TCategoryInfo();

                        try
                        {
                            info.Id = aReader.GetInt16(0);
                            info.Name = aReader.GetString(1).Trim();

                            categoryInfo.Add(info);
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
                return categoryInfo;
            }
            return null;
        }
    }
}
