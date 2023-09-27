using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Data.OleDb;
using ComptaCommun;

namespace ComptaDB
{
    public class PlacementInfoData
    {
        public static SortedList GetPlacementsInfo() // ID, TPlacementInfo
        {
            int placementId;
            return GetPlacementsInfo(null, out placementId);
        }

        public static SortedList GetPlacementsInfo(TPlacementInfo placementToFind, out int placementId)
        {
            OleDbConnection DBConnection;
            SortedList placements = new SortedList();

            placementId = -1;
            if (ClassDataAccess.OpenPlacementsDataSource(out DBConnection))
            {
                //create the command object and store the sql query
                OleDbCommand aCommand = new OleDbCommand("SELECT * FROM PlacementInfo ORDER BY ID, Type", DBConnection);
                try
                {
                    //create the datareader object to connect to table
                    OleDbDataReader aReader = aCommand.ExecuteReader();

                    //Iterate through the database
                    while (aReader.Read())
                    {
                        TPlacementInfo info = new TPlacementInfo();
                        try
                        {
                            info.m_ID = aReader.GetInt32(0);
                            info.m_Amount = aReader.GetDouble(1);
                            info.m_Date = aReader.GetDateTime(2);
                            info.m_PlacementType = (EPlacementType)aReader.GetInt32(3);
                            info.m_IsRendement = aReader.GetBoolean(4);
                            if (placementToFind != null)
                            {
                                if (info.m_Date.Date == placementToFind.m_Date.Date && info.m_IsRendement == placementToFind.m_IsRendement && info.m_PlacementType == placementToFind.m_PlacementType)
                                {
                                    placementId = info.m_ID;
                                }
                            }
                        }
                        catch (InvalidCastException)
                        {
                        }

                        placements.Add(info.m_ID, info);
                    }

                    aReader.Close();
                }
                catch (OleDbException)
                {
                    ClassDataAccess.CloseDataSource(DBConnection);
                    return placements;
                }
                ClassDataAccess.CloseDataSource(DBConnection);
                return placements;
            }
            return null;
        }

        public static void SavePlacementsInfo(SortedList placements, out Exception exception)
        {
            OleDbConnection DBConnection;

            exception = null;
            if (ClassDataAccess.OpenPlacementsDataSource(out DBConnection))
            {
                OleDbTransaction MyTransaction = DBConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                try
                {
                    ClassDataAccess.ExecuteCommand("DELETE FROM PlacementInfo", MyTransaction, DBConnection);

                    if (placements != null)
                    {
                        foreach (TPlacementInfo info in placements.Values)
                        {
                            //create the command object and store the sql query
                            ClassDataAccess.ExecuteCommand("INSERT INTO PlacementInfo VALUES ( " + info.m_ID + ", '" + info.m_Amount + "', '" +
                                info.m_Date + "', " + (int)info.m_PlacementType + ", " + info.m_IsRendement + ")", MyTransaction, DBConnection);
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

        public static void SavePlacement(TPlacementInfo placement, out Exception exception)
        {
            OleDbConnection DBConnection;

            exception = null;
            if (ClassDataAccess.OpenPlacementsDataSource(out DBConnection))
            {
                OleDbTransaction MyTransaction = DBConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                try
                {
                    //create the command object and store the sql query
                    ClassDataAccess.ExecuteCommand("INSERT INTO PlacementInfo (Amount, PlacementDate, Type, IsRendement) VALUES ( " + placement.m_Amount + ", '" +
                        placement.m_Date + "', " + (int)placement.m_PlacementType + ", " + placement.m_IsRendement + ")", MyTransaction, DBConnection);
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

        public static void DeletePlacement(int ID)
        {
            OleDbConnection DBConnection;

            if (ClassDataAccess.OpenPlacementsDataSource(out DBConnection))
            {
                OleDbTransaction MyTransaction = DBConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                try
                {
                    //create the command object and store the sql query
                    ClassDataAccess.ExecuteCommand("DELETE FROM PlacementInfo WHERE ID = " + ID, MyTransaction, DBConnection);
                    MyTransaction.Commit();
                    ClassDataAccess.CloseDataSource(DBConnection);
                }
                catch (Exception e)
                {
                    MyTransaction.Rollback();
                    ClassDataAccess.CloseDataSource(DBConnection);
                }
            }
            
        }
    }
}
