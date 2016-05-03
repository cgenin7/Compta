using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Comptability;
using ComptaCommun;

namespace TestProg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dateStart.Value = new DateTime(DateTime.Now.Year, 1,1);
            dateEnd.Value = new DateTime(DateTime.Now.Year, 12, 31);
            datePeriodStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            datePeriodEnd.Value = datePeriodStart.Value.AddMonths(3);
        }

        private void buttonGetNextTime_Click(object sender, EventArgs e)
        {
            TTransactionInfo info = FillTransactionInfo();

            m_dateNext = Util.GetNextPaiementDate(info, m_dateNext);
            labelNextTime.Text = m_dateNext.ToShortDateString();
        }

        private void dateStart_ValueChanged(object sender, EventArgs e)
        {
            m_dateNext = dateStart.Value;
            labelNextTime.Text = m_dateNext.ToShortDateString();
        }

        private void buttonFirstTime_Click(object sender, EventArgs e)
        {
            TTransactionInfo info = FillTransactionInfo();
            DateTime dateFirst = Util.GetFirstPaiementDate(info, dateStart.Value);
            labelFirstTime.Text = dateFirst.ToShortDateString();
            m_dateNext = dateFirst;
            labelNextTime.Text = dateFirst.ToShortDateString();
        }

        private TTransactionInfo FillTransactionInfo()
        {
            TTransactionInfo info = new TTransactionInfo();

            info.m_StartDate = dateStart.Value;
            info.m_EndDate = dateEnd.Value;

            if (!int.TryParse(textBoxPeriod.Text, out info.m_Period))
                MessageBox.Show("La période entrée n'est pas valide.");

            if (!int.TryParse(textBoxFirst.Text, out info.m_FirstTimeInMonth))
                MessageBox.Show("La valeur pour le 1er jour dans le mois n'est pas valide.");
            if (!int.TryParse(textBoxSecond.Text, out info.m_SecondTimeInMonth))
                MessageBox.Show("La valeur pour le 2ème jour dans le mois n'est pas valide.");
            
            switch (comboBoxType.Text)
            {
                case "OneShot":
                    info.m_eTransactionType = ETransactionType.e_OneShotTransaction;
                    break;
                case "Day":
                    info.m_eTransactionType = ETransactionType.e_PeriodicTransaction;
                    info.m_PeriodLength = EPeriodLength.e_PerDay;
                    break;
                case "Week":
                    info.m_eTransactionType = ETransactionType.e_PeriodicTransaction;
                    info.m_PeriodLength = EPeriodLength.e_PerWeek;
                    break;
                case "Month":
                    info.m_eTransactionType = ETransactionType.e_PeriodicTransaction;
                    info.m_PeriodLength = EPeriodLength.e_PerMonth;
                    break;
                case "Year":
                    info.m_eTransactionType = ETransactionType.e_PeriodicTransaction;
                    info.m_PeriodLength = EPeriodLength.e_PerYear;
                    break;
                case "TwoTimesInMonth":
                    info.m_eTransactionType = ETransactionType.e_TwoTimesInMonthTransaction;
                    break;
            }

            switch (comboBoxPretType.Text)
            {
                case "Mortgage":
                    info.m_PretType = EPretType.e_Mortgage;
                    break;
                case "MortgageLinked":
                    info.m_PretType = EPretType.e_MortgageLinkedToAccount;
                    break;
                case "Pret":
                    info.m_PretType = EPretType.e_Pret;
                    break;
                case "PretLinked":
                    info.m_PretType = EPretType.e_PretLinkedToAccount;
                    break;
            }

            if (radioAmortissement.Checked)
            {
                info.m_PretAmountPerPaiement = 0;
                if (!int.TryParse(textBoxAmortissmentMonths.Text, out info.m_PretAmortissementMonths))
                    MessageBox.Show("Le nombre de mois entré n'est pas valide.");
                info.m_PretPaiementType = EPretPaiementType.e_AmortissementMonths;
            }
            else 
            {
                info.m_PretAmortissementMonths = 0;
                if (!double.TryParse(textBoxPaiementPerPeriod.Text, out info.m_PretAmountPerPaiement))
                    MessageBox.Show("Le paiement entré n'est pas valide.");
                info.m_PretPaiementType = EPretPaiementType.e_FixedPaiements;
            }
            if (!double.TryParse(textBoxInterestRate.Text, out info.m_PretInterestRate))
                MessageBox.Show("Le taux d'intérêt entré n'est pas valide.");

            if (!double.TryParse(textBoxAmount.Text, out info.m_Amount))
                MessageBox.Show("Le montant entré n'est pas valide.");

            return info;
        }

        private void buttonNbPeriods_Click(object sender, EventArgs e)
        {
            TTransactionInfo info = FillTransactionInfo();

            List<DateTime> periodDates;
            labelNbPeriods.Text = Util.GetNbPeriods(info, datePeriodStart.Value, datePeriodEnd.Value, out periodDates).ToString();

            listBoxPeriodDates.Items.Clear();
            foreach (DateTime date in periodDates)
            {
                listBoxPeriodDates.Items.Add(date.DayOfWeek + " " + date.ToLongDateString());
            }
        }

        private DateTime m_dateNext;

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            TTransactionInfo info = FillTransactionInfo();

            ClassMortgage.CalculatePret(DateTime.Now, new DateTime(DateTime.Now.Year, 12, 31), ref info);

            labelResult.Text = "AmountPerPaiement: " + ClassTools.ConvertCurrencyToString(info.m_PretAmountPerPaiement) + " - Number of paiements: " + info.m_TotalNbPaiements + " - RemainingAmount: " + ClassTools.ConvertCurrencyToString(info.m_PretRemainingAmount) + " - EndDate: " + ClassTools.ConvertDateToString(info.m_EndDate);
            listBoxPeriodDates.Items.Clear();

            foreach (TPretAmortissement pretAm in info.m_PretAmortissementList)
            {
                listBoxPeriodDates.Items.Add(ClassTools.ConvertDateToString(pretAm.PaiementDate) + " - Capital: " + ClassTools.ConvertCurrencyToString(pretAm.CapitalPaied) + " - Interest: " + ClassTools.ConvertCurrencyToString(pretAm.InterestPaied) + " - Amount remaining: " + ClassTools.ConvertCurrencyToString(pretAm.RemainingAmount));
            }

            textBoxPaiementPerPeriod.Text = ClassTools.ConvertDoubleToString(info.m_PretAmountPerPaiement);
        }
    }
}

