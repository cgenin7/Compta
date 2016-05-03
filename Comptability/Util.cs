using System;
using System.Collections.Generic;
using System.Text;
using ComptaCommun;

namespace Comptability
{
    public class Util
    {
        public static DateTime GetFirstPaiementDate(TTransactionInfo info, DateTime date)
        {
            int nbDaysInPeriod;
            return GetFirstPaiementDate(info, date, out nbDaysInPeriod);
        }

        public static DateTime GetFirstPaiementDate(TTransactionInfo info, DateTime date, out int nbDaysInPeriod)
        {
            nbDaysInPeriod = 1;
            
            if (IsBasedOnMonth(info))
            {
                return GetNextPaiementDate(info, date.AddDays(-1), 1, out nbDaysInPeriod);
            }
            if (info.m_eTransactionType == ETransactionType.e_PeriodicTransaction)
            {
                switch (info.m_PeriodLength)
                {
                    case EPeriodLength.e_PerDay:
                        nbDaysInPeriod = info.m_Period;
                        break;
                    case EPeriodLength.e_PerWeek:
                    case EPeriodLength.e_PerWeekAccelerated:
                        nbDaysInPeriod = info.m_Period * 7;
                        break;
                    case EPeriodLength.e_PerYear:
                        nbDaysInPeriod = info.m_Period * 365;
                        break;
                }
            }
            return info.m_StartDate;
        }

        public static DateTime GetNextPaiementDate(TTransactionInfo info, DateTime date, out int nbDaysInPeriod)
        {
            return GetNextPaiementDate(info, date, info.m_Period, out nbDaysInPeriod);
        }

        public static DateTime GetNextPaiementDate(TTransactionInfo info, DateTime date)
        {
            int nbDaysInPeriod;
            return GetNextPaiementDate(info, date, info.m_Period, out nbDaysInPeriod);
        }

        public static int GetNbPeriods(TTransactionInfo info, DateTime startDate, DateTime endDate)
        {
            List<DateTime> periodDates;
            return GetNbPeriods(info, startDate, endDate, out periodDates);
        }

        public static int GetNbPeriods(TTransactionInfo info, DateTime startDate, DateTime endDate, out List<DateTime> periodDates)
        {
            periodDates = new List<DateTime>();

            int nbPeriods = 0;

            if (info.m_eTransactionType == ETransactionType.e_OneShotTransaction)
            {
                if (info.m_StartDate.Date >= startDate.Date && info.m_StartDate.Date <= endDate.Date)
                {
                    periodDates.Add(info.m_StartDate);
                    return 1;
                }
                else
                    return 0;
            }
            else
            {
                DateTime nextDate = GetFirstPaiementDate(info, startDate);

                while (nextDate.Date < startDate.Date)
                    nextDate = GetNextPaiementDate(info, startDate);

                while (nextDate.Date <= endDate.Date)
                {
                    periodDates.Add(nextDate);
                    nbPeriods++;
                    nextDate = GetNextPaiementDate(info, nextDate);
                }
                // special case for a period a every week starting on january first and ending on december 31, otherwise it gives 53 weeks instead of 52
                if (info.m_PeriodLength == EPeriodLength.e_PerWeek && startDate.Day == 1 && startDate.Month == 1 && endDate.Day == 31 && endDate.Month == 12)
                    nbPeriods--;
            }

            return nbPeriods;
        }

        public static bool IsBasedOnMonth(TTransactionInfo info)
        {
            return (info.m_eTransactionType == ETransactionType.e_TwoTimesInMonthTransaction ||
                info.m_eTransactionType == ETransactionType.e_PeriodicTransaction && info.m_PeriodLength == EPeriodLength.e_PerMonth) ;
        }

        private static DateTime GetNextPaiementDate(TTransactionInfo info, DateTime date, int period, out int nbDaysInPeriod)
        {
            DateTime nextPaiementDate = date;
            nbDaysInPeriod = 0;

            if (info.m_eTransactionType == ETransactionType.e_TwoTimesInMonthTransaction)
                info.m_Period = 1;
            if (info.m_Period <= 0)
                info.m_Period = 1;

            if (IsBasedOnMonth(info))
            {
                nextPaiementDate = GetMonthNextPaiementDate(info, date, period);
            }
            else if (info.m_eTransactionType == ETransactionType.e_PeriodicTransaction)
            {
                if (info.m_PeriodLength == EPeriodLength.e_PerYear)
                    nextPaiementDate = nextPaiementDate.AddYears(info.m_Period);
                else if (info.m_PeriodLength == EPeriodLength.e_PerWeek || info.m_PeriodLength == EPeriodLength.e_PerWeekAccelerated)
                    nextPaiementDate = nextPaiementDate.AddDays(7 * info.m_Period);
                else if (info.m_PeriodLength == EPeriodLength.e_PerDay)
                    nextPaiementDate = nextPaiementDate.AddDays(info.m_Period);
            }
            nbDaysInPeriod = (int)nextPaiementDate.Date.Subtract(date.Date).TotalDays;
            return nextPaiementDate;
        }

        private static DateTime GetMonthNextPaiementDate(TTransactionInfo info, DateTime date, int period)
        {
            DateTime nextPaiementDate = date;
            int lastDayOfMonth = DateTime.DaysInMonth(nextPaiementDate.Year, nextPaiementDate.Month);

            int firstTime = (info.m_FirstTimeInMonth == LAST_DAY_OF_MONTH ? lastDayOfMonth : info.m_FirstTimeInMonth);
            int secondTime = (info.m_SecondTimeInMonth == LAST_DAY_OF_MONTH ? lastDayOfMonth : info.m_SecondTimeInMonth);

            if (nextPaiementDate.Day < firstTime)
            {
                if (firstTime <= lastDayOfMonth)
                    nextPaiementDate = new DateTime(nextPaiementDate.Year, nextPaiementDate.Month, firstTime);
                else
                    nextPaiementDate = GetDateForNextMonth(info, nextPaiementDate, period);
            }
            else if (nextPaiementDate.Day >= firstTime)
            {
                if (info.m_eTransactionType == ETransactionType.e_TwoTimesInMonthTransaction)
                {
                    if (nextPaiementDate.Day < secondTime)
                        if (secondTime <= lastDayOfMonth)
                            nextPaiementDate = new DateTime(nextPaiementDate.Year, nextPaiementDate.Month, secondTime);
                        else
                            nextPaiementDate = GetDateForNextMonth(info, nextPaiementDate, period);
                    else
                        nextPaiementDate = GetDateForNextMonth(info, nextPaiementDate, period);
                }
                else
                    nextPaiementDate = GetDateForNextMonth(info, nextPaiementDate, period);
            }
            else
                nextPaiementDate = GetDateForNextMonth(info, nextPaiementDate, period);
            return nextPaiementDate;
        }

        private static DateTime GetDateForNextMonth(TTransactionInfo info, DateTime nextPaiementDate, int period)
        {
            nextPaiementDate = nextPaiementDate.AddMonths(period);
            int lastDayOfMonth = DateTime.DaysInMonth(nextPaiementDate.Year, nextPaiementDate.Month);
            int firstTime = (info.m_FirstTimeInMonth == LAST_DAY_OF_MONTH ? lastDayOfMonth : info.m_FirstTimeInMonth);
            if (firstTime > lastDayOfMonth)
                return GetDateForNextMonth(info, nextPaiementDate, period);
            nextPaiementDate = new DateTime(nextPaiementDate.Year, nextPaiementDate.Month, firstTime);

            return nextPaiementDate;
        }

        public const int LAST_DAY_OF_MONTH = 29;
    }
}
