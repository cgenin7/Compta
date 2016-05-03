using System;
using System.Globalization;
using System.Collections.Generic;

namespace ComptaCommun
{
	/// <summary>
	/// Summary description for ClassTools.
	/// </summary>
	public class ClassTools
	{
        public static string GetConfigDir()
        {
            return LocalSettings.UIDirectory + "\\" + DATA_DIR + "\\";
        }

        public static bool IsInt( String sValue )
		{
			if ( sValue == "" )
				return false;
			try
			{
				Convert.ToInt32( sValue );
			}
			catch ( InvalidCastException )
			{
				return false;
			}
			catch ( FormatException )
			{
				return false;
			}
			return true;
		}

		public static bool IsDouble( String sValue )
		{
			if ( sValue == "" )
				return false;
			try
			{
				Convert.ToDouble( sValue );
			}
			catch ( InvalidCastException )
			{
				return false;
			}
			catch ( FormatException )
			{
				return false;
			}
			return true;
		}

		public static string ConvertCurrencyToString( double Value, bool putCents = true )
		{
            string sResult;
            if (putCents)
                sResult = Value.ToString("N2");
            else
                sResult = Value.ToString("N0");
			sResult += " $";
            if (NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator == ".")
                sResult = sResult.Replace(".00", "");
            else
                sResult = sResult.Replace(",00", "");
			return sResult;
		}

        public static string ConvertDateToString(DateTime date)
        {
            string sDate = date.ToString("dd MMMM yyyy");
            if (sDate.StartsWith("01 "))
                sDate = "1er" + sDate.Substring(2);
            return sDate;
        }

        public static string ConvertDoubleToString(double Value)
        {
            string Result = Value.ToString( "N2" );
            if ( NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator == "." )
                Result = Result.Replace( ".00", "" );
            else
                Result = Result.Replace( ",00", "" );
            return Result;
        }

        public static EPlacementType ConvertPlacementType(string type)
        {
            switch (type)
            {
                case "REER 1":
                    return EPlacementType.e_REER1;
                case "REER 2":
                    return EPlacementType.e_REER2;
                case "CELI 1":
                    return EPlacementType.e_CELI1;
                case "CELI 2":
                    return EPlacementType.e_CELI2;
                case "REEE":
                    return EPlacementType.e_REEE;
            }
            return EPlacementType.e_Unknown;
        }

        public static string ConvertPlacementType(EPlacementType type)
        {
            switch (type)
            {
                case EPlacementType.e_REER1:
                    return "REER 1";
                case EPlacementType.e_REER2:
                    return "REER 2";
                case EPlacementType.e_CELI1:
                    return "CELI 1";
                case EPlacementType.e_CELI2:
                    return "CELI 2";
                case EPlacementType.e_REEE:
                    return "REEE";
            }
            return "Unknown";
        }

        public static string GetCategory(int categoryId, List<TCategoryInfo> infos)
        {
            if (infos != null)
            {
                foreach (TCategoryInfo info in infos)
                {
                    if (info.Id == categoryId)
                        return info.Name.Trim();
                }
            }
            return "";
        }

        public static int GetCategory(string categoryName, List<TCategoryInfo> infos)
        {
            if (infos != null)
            {
                foreach (TCategoryInfo info in infos)
                {
                    if (info.Name.Trim() == categoryName.Trim())
                        return info.Id;
                }
            }
            return 0;
        }

	    public static double Abs( double Nb )
		{
			if ( Nb < 0 )
				return Nb * (-1);
			return Nb;
		}

		public static int Mod( int Nb, int Modulo )
		{
			if ( Modulo == 0)
				return 0;
			int Division = Nb / Modulo;
			return Nb - Division * Modulo;
		}

		public static int GetNbMonthsBetweenDates( DateTime FirstDate, DateTime SecondDate )
		{
			int NbMonthsBetweenDates = 0;
			if ( FirstDate.Date < SecondDate.Date )
			{
				while ( FirstDate.Month != SecondDate.Month || FirstDate.Year != SecondDate.Year ) 
				{
					NbMonthsBetweenDates++;
					FirstDate = FirstDate.AddMonths(1);
				}
			}
			return NbMonthsBetweenDates;	
		}

		public static int GetNbOpenDaysBetweenDates( DateTime FirstDate, DateTime SecondDate )
		{
			int NbOpenDays = 0;

			while ( FirstDate.Date <= SecondDate.Date )
			{
				if ( FirstDate.DayOfWeek != DayOfWeek.Saturday && FirstDate.DayOfWeek != DayOfWeek.Sunday )
					NbOpenDays++;
				FirstDate = FirstDate.AddDays(1);
			}
			return NbOpenDays;
		}

        public static void SortDictionaryOnAmount(ref Dictionary<string, TCategoryDetails> details)
        {
            Dictionary<string, TCategoryDetails> sortedDetails = new Dictionary<string,TCategoryDetails>();
            bool atLeastOneChanged = false;

            if (details.Count <= 1)
                return;
            
            do
            {
                atLeastOneChanged = false;
                double maxValue = 0;
                string maxKey = "";

                foreach (string key in details.Keys)
                {
                    TCategoryDetails info = details[key];
                    if (maxValue <= info.CategoryAmount)
                    {
                        maxValue = info.CategoryAmount;
                        maxKey = key;
                    }
                }

                if (!String.IsNullOrEmpty(maxKey))
                {
                    sortedDetails.Add(maxKey, details[maxKey]);
                    details.Remove(maxKey);
                    atLeastOneChanged = true;
                }
            } while (details.Count > 0 && atLeastOneChanged);
            details = sortedDetails;
        }

        private const string DATA_DIR = "data";
	}
}
