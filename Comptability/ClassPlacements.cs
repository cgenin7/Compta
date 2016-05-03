using System;
using System.Collections;
using System.Collections.Generic;
using ComptaCommun;
using ComptaDB;

namespace Comptability
{
    public class ClassPlacements
    {
        public SortedList Placements // ID, TPlacementInfo
        {
            get { return m_Placements; }
        }

        #region Public Methods

        public static ClassPlacements GetPlacements()
        {
            if (m_sPlacements == null)
                m_sPlacements = new ClassPlacements();
            return m_sPlacements;
        }

        public void LoadPlacementsFromDataStorage(TPlacementInfo placementToFind, out int placementId)
        {
            m_Placements = PlacementInfoData.GetPlacementsInfo(placementToFind, out placementId);
        }

        public void LoadPlacementsFromDataStorage()
        {
            m_Placements = PlacementInfoData.GetPlacementsInfo();
        }

        public void SavePlacementInDataStorage(TPlacementInfo placement, out Exception exception)
        {
            exception = null;
            if (m_Placements != null)
            {
                PlacementInfoData.SavePlacement(placement, out exception);
            }
        }

        public void SavePlacementsInDataStorage(out Exception exception)
        {
            exception = null;
            if (m_Placements != null)
            {
                PlacementInfoData.SavePlacementsInfo(m_Placements, out exception);
            }
        }

        public double CalculateProfit(ref TPlacementInfo rendement, out double percentage, out double percentagePerYear)
        {
            double profit;
            double investissementTotal = 0;
            
            List<TPlacementInfo> placementsForThisRendement = new List<TPlacementInfo>();

            if (m_Placements != null)
            {
                foreach (TPlacementInfo placement in m_Placements.Values)
                {
                    if (!placement.m_IsRendement && placement.m_PlacementType == rendement.m_PlacementType && placement.m_Date.Date <= rendement.m_Date.Date)
                    {
                        investissementTotal += placement.m_Amount;
                        placementsForThisRendement.Add(placement);
                    }
                }
            }

            profit = rendement.m_Amount - investissementTotal;
            if (investissementTotal == 0)
                percentage = 0;
            else
                percentage = 100*profit/investissementTotal;

            percentagePerYear = CalculatePercentagePerYear(rendement, placementsForThisRendement, investissementTotal);
            return profit;
        }

        public double CalculateTotalPercentPerYear(double totalPlacement, double totalRendement)
        {
            double totalPercentPerYear = 0;
            DateTime lastRendementTime = DateTime.MinValue;

            List<TPlacementInfo> lastRendements = new List<TPlacementInfo>();

            // Get last rendements only
            if (m_Placements != null)
            {
                foreach (TPlacementInfo rendement in m_Placements.Values)
                {
                    if (rendement.m_IsRendement)
                    {
                        if (lastRendementTime.Date < rendement.m_Date.Date)
                        {
                            lastRendementTime = rendement.m_Date;
                            lastRendements.Clear();
                        }
                        if (lastRendementTime.Date == rendement.m_Date.Date)
                        {
                            lastRendements.Add(rendement);
                        }
                    }
                }
            }

            // Calculate percentage per year
            foreach (TPlacementInfo rendement in lastRendements)
            {
                if (rendement.m_IsRendement)
                {
                    if (rendement.m_InvestissementTotal > 0)
                    {
                        double pound = 0;
                        if (totalPlacement != 0)
                            pound = rendement.m_InvestissementTotal/totalPlacement;
                        totalPercentPerYear += pound*rendement.m_PercentagePerYear;
                    }
                }
            }
            return totalPercentPerYear;
        }

        #endregion

        #region Private Methods

        private ClassPlacements()
        {
        }

        private double CalculatePercentagePerYear(TPlacementInfo rendement, List<TPlacementInfo> placementsForThisRendement, double investissementTotal)
        {
            List<TProfitInfo> profitInfos = new List<TProfitInfo>();

            rendement.m_InvestissementTotal = investissementTotal;

            double totalNbOfDollarsAndMonths = 0;
            foreach (TPlacementInfo placement in placementsForThisRendement)
            {
                int nbMonths = (rendement.m_Date.Year - placement.m_Date.Year) * 12 + rendement.m_Date.Month - placement.m_Date.Month;
                totalNbOfDollarsAndMonths += placement.m_Amount * nbMonths;
            }

            double rendementForOneDollarAndOneMonth = 0;
            if (totalNbOfDollarsAndMonths != 0)
                rendementForOneDollarAndOneMonth = (rendement.m_Amount - investissementTotal) / totalNbOfDollarsAndMonths;

            foreach (TPlacementInfo placement in placementsForThisRendement)
            {
                int totalNbMonths = (rendement.m_Date.Year - placement.m_Date.Year) * 12 + rendement.m_Date.Month - placement.m_Date.Month;
                double profitForPlacement = placement.m_Amount * rendementForOneDollarAndOneMonth * totalNbMonths;
                double percentForPlacement = 0;
                if (placement.m_Amount != 0)
                    percentForPlacement = 100 * profitForPlacement / placement.m_Amount;
                
                TProfitInfo profitInfo = new TProfitInfo();
                if (totalNbMonths == 0)
                    profitInfo.PercentPerYear = 0;
                else
                    profitInfo.PercentPerYear = 12 * percentForPlacement / totalNbMonths;
                if (investissementTotal == 0)
                    profitInfo.Pound = 0;
                else
                    profitInfo.Pound = placement.m_Amount * 100 / investissementTotal;
                profitInfos.Add(profitInfo);
            }

            rendement.m_PercentagePerYear = 0;
            foreach (TProfitInfo profitInfo in profitInfos)
            {
                rendement.m_PercentagePerYear += profitInfo.PercentPerYear * profitInfo.Pound / 100;
            }
            return rendement.m_PercentagePerYear;
        }

        #endregion

        private SortedList m_Placements; //ID, TPlacementInfo
        private static ClassPlacements m_sPlacements;

        private class TProfitInfo
        {
            public double PercentPerYear;
            public double Pound;
        }
    }
    
}
