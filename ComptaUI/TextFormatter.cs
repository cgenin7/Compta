using System;
using ComptaCommun;
using Comptability;

namespace Compta
{
	/// <summary>
	/// Summary description for TextFormatter.
	/// </summary>
	public class TextFormatter
	{
        public static string FormatTransactionText(TTransactionInfo info)
        {
            if (info.m_Type == EType.e_Income)
                return FormatRevenuText(info);
            return FormatDepenseText(info);
        }

        public static string FormatToComeTransactionText(TTransactionInfo info, DateTime nextPaiementDate)
        {
            string sToCome = info.m_TransactionName + ": ";

            if (info.m_Type == EType.e_Income)
                sToCome += "revenu de ";
            if (info.m_Type == EType.e_Expense)
                sToCome += "dépense de ";
            sToCome += ClassTools.ConvertCurrencyToString(info.m_Balance) + " le " + ClassTools.ConvertDateToString(nextPaiementDate);
            
            return sToCome;
        }

		public static string FormatAvertissementText( TTransactionInfo info )
		{
			if ( !string.IsNullOrEmpty(info.m_Warning))
			{
                string type = "Revenu '";
                
                switch (info.m_Type)
                {
                    case EType.e_Income:
                        type = "Revenu '";
                        break;
                    case EType.e_Expense: 
                        type = "Dépense '";
                        break;
                }
				return (type + info.m_TransactionName + "' : " + info.m_Warning);
			}
			return "";
		}

		public static string FormatHistorique( THistoryInfo info )
		{
            double balance = info.m_AccountBalance + info.m_Incomes - info.m_Expenses;

            string sHistorique = $"Le {ClassTools.ConvertDateToString(info.m_HistoryDate)}, le solde prédit pour la fin de l'année était de " +
                $"{ClassTools.ConvertCurrencyToString(balance)}. (Solde: {ClassTools.ConvertCurrencyToString(info.m_AccountBalance)}, " +
                $"revenus: {ClassTools.ConvertCurrencyToString(info.m_Incomes)}, " +
                $"dépenses: {ClassTools.ConvertCurrencyToString(info.m_Expenses)}";
            
            sHistorique += " )";
            return sHistorique;
		}

		private static String FormatRevenuText(TTransactionInfo info)
        {
            String TransText = "";

            if (info.m_Type == EType.e_Income)
            {
                TransText += info.m_TransactionName + ": ";
                TransText += "revenu de " + ClassTools.ConvertCurrencyToString( info.m_Amount );
                TransText += FormatPeriod(info);
                TransText += ". " + ClassTools.ConvertCurrencyToString(info.m_Balance) + GetBalanceText(info.m_Type, info.m_TransactionMode, info.m_EndDate);
            }
            return TransText;
        }


        private static String FormatDepenseText(TTransactionInfo info)
        {
            String TransText = "";

            if (info.m_Type == EType.e_Expense)
            {
                TransText += info.m_TransactionName + ": ";
                TransText += "dépense de " + ClassTools.ConvertCurrencyToString(info.m_Amount);
                TransText += FormatPeriod(info);
                TransText += ". " + ClassTools.ConvertCurrencyToString(info.m_Balance) + GetBalanceText(info.m_Type, info.m_TransactionMode, info.m_EndDate);
            }
            return TransText;
        }

        public static string GetBalanceText(EType dataType, ETransactionMode mode, DateTime endDate)
        {
            string sBalanceText = GetBalanceText(dataType, mode);
            sBalanceText += "d'ici au " + ClassTools.ConvertDateToString(endDate) + ".";
            return sBalanceText;
        }

        public static string GetBalanceText(EType dataType, ETransactionMode mode)
        {
            if (dataType == EType.e_Income)
                return " restant à recevoir ";
            return " restant à dépenser ";
            
        }

        public static string GetLabelBalance(TTransactionInfo info, DateTime endPredictionDate, EType dataType)
        {
            string sLabelBalance = "D'ici au " + ClassTools.ConvertDateToString(endPredictionDate) + ": ";
            sLabelBalance += ClassTools.ConvertCurrencyToString(info.m_Balance, false) + TextFormatter.GetBalanceText(dataType, info.m_TransactionMode);

            if (info.m_TransactionMode == ETransactionMode.e_Automatique)
            {
                if (info.m_eTransactionType == ETransactionType.e_OneShotTransaction)
                {
                    sLabelBalance += FormatAlreadyPayedText(info.m_Amount - info.m_Balance, info.m_Amount);
                }
                else
                {
                    double totalAmount = info.m_TotalNbPaiements * info.m_Amount;
                    if (totalAmount - info.m_TotalAmountPaiedForTheYear > 0.01)
                    {
                    #if (DEBUG)
                        if (!m_warningSent)
                        {
                            System.Windows.Forms.MessageBox.Show("Erreur dans les calculs pour le solde annuel de la transaction " + info.m_TransactionName);
                            m_warningSent = true;
                        }
                    #endif
                    }
                    sLabelBalance += "sur un total de " + ClassTools.ConvertCurrencyToString(totalAmount);
                    if (info.m_FirstPaiementDate != DateTime.MinValue)
                        sLabelBalance += " - Prochain paiement le " + ClassTools.ConvertDateToString(info.m_FirstPaiementDate);
                    if (info.m_LastPaiementDate != DateTime.MinValue)
                        sLabelBalance += " - Dernier paiement le " + ClassTools.ConvertDateToString(info.m_LastPaiementDate);
                }
            }
            else if (info.m_TransactionMode == ETransactionMode.e_Manual)
            {
                int nbCompletedPaiements;
                double amountReallyPayed;
                double amountAlreadyPayed = ClassCalculation.GetTotalAmountPayed(info, info.m_TotalNbPaiements, out amountReallyPayed, out nbCompletedPaiements);
                double totalToPay = info.m_TotalNbPaiements * info.m_Amount;
                if (totalToPay - info.m_TotalAmountPaiedForTheYear > 0.01)
                {
                    #if (DEBUG)
                        if (!m_warningSent)
                        {
                            System.Windows.Forms.MessageBox.Show("Erreur dans les calculs pour le solde annuel de la transaction " + info.m_TransactionName);
                            m_warningSent = true;
                        }
                    #endif
                }
                sLabelBalance += FormatAlreadyPayedText(amountAlreadyPayed, totalToPay);
                if (info.m_eTransactionType != ETransactionType.e_OneShotTransaction && nbCompletedPaiements > 0)
                {
                    double averageAmountPayedPerPeriod = amountReallyPayed / nbCompletedPaiements;
                    sLabelBalance += " - Montant payé en moyenne" + FormatPeriod(info) + ": " + ClassTools.ConvertCurrencyToString(averageAmountPayedPerPeriod);
                }
            }
            return sLabelBalance + ".";
        }

        private static string FormatAlreadyPayedText(double amountAlreadyPayed, double totalToPay)
        {
            string sAlreadyPayedText;
            if (Math.Abs(amountAlreadyPayed - totalToPay) > 0.01)
            {
                sAlreadyPayedText = " - " + ClassTools.ConvertCurrencyToString(amountAlreadyPayed) + " payé sur un total de " + ClassTools.ConvertCurrencyToString(totalToPay);
            }
            else
            {
                sAlreadyPayedText = " - Paiement total de " + ClassTools.ConvertCurrencyToString(amountAlreadyPayed) + " complété";
            }
            return sAlreadyPayedText;
        }

        private static string FormatPaiement(int paiements)
        {
            if (paiements <= 1)
                return " paiement";
            return " paiements";
        }

        private static string GetAccountNameFromId(int id)
        {
            return ClassAccounts.GetAccounts().GetAccountNameFromId(id);
        }

        private static string FormatPeriod( TTransactionInfo info )
		{
            String TransText = "";

			if (info.m_eTransactionType == ETransactionType.e_OneShotTransaction)
            {
                TransText += " le " + ClassTools.ConvertDateToString(info.m_StartDate);
            }
            else if (info.m_eTransactionType == ETransactionType.e_PeriodicTransaction)
            {
                TransText += " par ";
                if (info.m_Period > 1)
                    TransText += info.m_Period + " ";
                TransText += GetPeriodLength(info.m_PeriodLength);
            }
            else if (info.m_eTransactionType == ETransactionType.e_TwoTimesInMonthTransaction)
            {
                TransText += " le " + FormatDayInMonth(info.m_FirstTimeInMonth) + " et le " + FormatDayInMonth(info.m_SecondTimeInMonth) + " de chaque mois";
            }
			return TransText;
		}

        private static string FormatDayInMonth(int dayInMonth)
        {
            string sDay = dayInMonth.ToString();
            if (dayInMonth == 1)
                sDay = "1er";
            else if (dayInMonth == Util.LAST_DAY_OF_MONTH)
                sDay = "dernier jour";
            return sDay;                 
        }

		private static string GetPeriodLength( EPeriodLength period )
		{
			switch ( period )
			{
				case EPeriodLength.e_PerDay:
					return "jours";
             	case EPeriodLength.e_PerWeek:
					return "semaines";
				case EPeriodLength.e_PerMonth:
					return "mois";
				case EPeriodLength.e_PerYear:
					return "ans";
			}
			return "";
		}

		private static string GetDayInMonth( int dayNb )
		{
			if ( dayNb == 1 )
				return "1er";
            if (dayNb == Util.LAST_DAY_OF_MONTH)
				return "dernier jour";
			return dayNb.ToString();
		}

        #if (DEBUG)
        private static bool m_warningSent = false;
        #endif
	}
}
