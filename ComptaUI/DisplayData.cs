using System;
using System.Windows.Forms;
using System.Collections.Generic;
using ComptaCommun;
using Comptability;
using System.Drawing;

namespace Compta
{
    /// <summary>
	/// Summary description for DisplayData.
	/// </summary>
	public class DisplayData
	{
		public DisplayData(FormMain main, UIControlsStruct controls, EventHandler selectedIndexChangedEvent, EType dataType)
		{
			m_main = main;
            m_dataType = dataType;
            m_selectedIndexChangedEvent = selectedIndexChangedEvent;
			UIControls = controls;
            m_originalLabelFirstTimeInMonthLocation = UIControls.LabelFirstTimeInMonth.Location;
            m_originalComboBoxFirstTimeInMonthLocation = UIControls.ComboBoxFirstTimeInMonth.Location;
            m_originalPanelLocationY = UIControls.PanelBalanceAndButtons.Location.Y;
		}

        public void InitializeAll()
        {
            m_lastTransactionIndex = -1;
            m_inNewTransaction = false;
            m_lastDisplayedTransaction = null;
            UIControls.ButtonCancelTransaction.Enabled = false;
        }

        public void AddNewTransaction()
        {
            if (TransactionChanged(m_lastDisplayedTransaction))
                if (MessageBox.Show("La transaction a changé. Voulez-vous la sauvegarder?", "Sauvegarder", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveTransaction(m_lastTransactionIndex);

            m_inNewTransaction = true;
            UIControls.ButtonNewTransaction.Enabled = false;
            UIControls.ButtonDeleteTransaction.Enabled = false;
            UIControls.ButtonCancelTransaction.Enabled = true;
            InitializeAllFields();
        }

        public void CancelPartialTransaction()
        {
            if (UIControls.TransactionListBox.Items.Count <= 0)
            {
                ChangeAllControlsVisibility(false);
                UIControls.ButtonCancelTransaction.Enabled = false;
            }
            else
            {
                InitializeAllFields();
                TransferFromStructureToForm(m_lastDisplayedTransaction);
                UIControls.ButtonCancelTransaction.Enabled = true;
            }
            m_inNewTransaction = false;
            UIControls.ButtonNewTransaction.Enabled = true;
        }

        public void SaveTransaction() 
        {
            SaveTransaction(UIControls.TransactionListBox.SelectedIndex);
        }

        public void SaveTransaction(int transToSaveIndex)
        {
            int curSelIndex = UIControls.TransactionListBox.SelectedIndex;
            Dictionary<int, TTransactionInfo> transactions = ClassTransactions.GetTransactions().Transactions;
            Exception exception = null;

            m_lastDisplayedTransaction = TransferFromFormToStructure(transToSaveIndex);
            if (m_lastDisplayedTransaction != null)
            {
                string textToDisplay = TextFormatter.FormatTransactionText(m_lastDisplayedTransaction);

                if (m_lastDisplayedTransaction.m_TransactionMode == ETransactionMode.e_Automatique)
                    m_lastDisplayedTransaction.m_AmountAlreadyPayed = "0";

                if (m_inNewTransaction)  // New transaction
                {
                    curSelIndex = UIControls.TransactionListBox.Items.Count;
                    transToSaveIndex = curSelIndex;
                    ClassTransactions.GetTransactions().AddTransactionInDataStorage(m_lastDisplayedTransaction, out exception);
                    if (exception != null)
                    {
                        MessageBox.Show(exception.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    ClassTransactions.GetTransactions().LoadTransactionFromDataStorage(m_lastDisplayedTransaction, out m_lastDisplayedTransaction.m_ID);
                    transactions.Add(m_lastDisplayedTransaction.m_ID, m_lastDisplayedTransaction);
                }
                else // Existing transaction
                {
                    if (transToSaveIndex >= 0)
                    {
                        TDisplayInfo info = UIControls.TransactionListBox.Items[transToSaveIndex] as TDisplayInfo;
                        if (info != null)
                        {
                            if (info.ID >= 0 && transactions.ContainsKey(info.ID))
                            {
                                transactions[info.ID] = m_lastDisplayedTransaction;
                                ClassTransactions.GetTransactions().UpdateTransactionInDataStorage(m_lastDisplayedTransaction, out exception);
                                if (exception != null)
                                {
                                    MessageBox.Show(exception.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Impossible de trouver la transaction avec l'ID " + info.ID, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

                TDisplayInfo displayInfo = new TDisplayInfo(textToDisplay, m_lastDisplayedTransaction.m_ID, m_lastDisplayedTransaction.m_Type, m_lastDisplayedTransaction.m_AccountId);
                if (m_inNewTransaction)
                {
                    UIControls.TransactionListBox.Items.Add(displayInfo);
                }
                
                m_inNewTransaction = false;

                UIControls.TransactionListBox.SelectedIndex = curSelIndex;
                UIControls.ButtonNewTransaction.Enabled = true;
                UIControls.ButtonCancelTransaction.Enabled = false;
                UIControls.ButtonDeleteTransaction.Enabled = true;
            }

            if (m_lastDisplayedTransaction != null)
                FillAmountAlreadyPayed(m_lastDisplayedTransaction);
            m_main.UpdateBalances();
            
            if (m_lastDisplayedTransaction != null)
            {
                TransferFromStructureToForm(m_lastDisplayedTransaction);
                UIControls.TransactionListBox.Items[transToSaveIndex] = new TDisplayInfo(TextFormatter.FormatTransactionText(m_lastDisplayedTransaction), m_lastDisplayedTransaction.m_ID, m_lastDisplayedTransaction.m_Type, m_lastDisplayedTransaction.m_AccountId);

                // Add transaction info in ToCome list if something is going on for the next month
                if (m_lastDisplayedTransaction.m_Type == EType.e_Income || m_lastDisplayedTransaction.m_Type == EType.e_Expense || m_lastDisplayedTransaction.m_Type == EType.e_Pret)
                {
                    m_main.AddToComeTransaction(m_lastDisplayedTransaction);
                }
            }
            UIControls.TransactionListBox.Refresh();
        }

        public void DeleteTransaction()
        {
            int curSelection = UIControls.TransactionListBox.SelectedIndex;

            if (curSelection >= 0)
            {
                if (MessageBox.Show("Etes-vous sûr de vouloir effacer cette entrée?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    TDisplayInfo info = UIControls.TransactionListBox.Items[curSelection] as TDisplayInfo;
                    if (info != null && info.ID != -1)
                    {
                        Exception exception;
                        Dictionary<int, TTransactionInfo> transactions = ClassTransactions.GetTransactions().Transactions;
                        if (transactions.ContainsKey(info.ID))
                        {
                            transactions.Remove(info.ID);
                            m_lastDisplayedTransaction = null;

                            ClassTransactions.GetTransactions().DeleteTransactionFromDataStorage(info.ID, out exception);
                            if (exception != null)
                            {
                                MessageBox.Show(exception.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            UIControls.TransactionListBox.Items.RemoveAt(curSelection);

                            if (curSelection > 0)
                            {
                                m_lastTransactionIndex = -1;
                                UIControls.TransactionListBox.SelectedIndex = (curSelection - 1);
                            }
                            if (UIControls.TransactionListBox.Items.Count <= 0)
                            {
                                InitializeAllFields();
                                ChangeAllControlsVisibility(false);
                                UIControls.ButtonCancelTransaction.Enabled = false;
                                m_lastTransactionIndex = -1;
                            }
                            m_main.DeleteToComeTransaction(info.ID);
                        }
                    }
                    m_lastTransactionIndex = -1;
                    if (curSelection == 0 && UIControls.TransactionListBox.Items.Count > 0)
                        UIControls.TransactionListBox.SelectedIndex = 0;
                    else if (curSelection > 0)
                        UIControls.TransactionListBox.SelectedIndex = curSelection - 1;
                    m_main.UpdateBalances();
                }
            }
        }

        public void SelectedIndexChanged()
        {
            int index = UIControls.TransactionListBox.SelectedIndex;
            if (index >= 0)
            {
                if (m_lastTransactionIndex != UIControls.TransactionListBox.SelectedIndex)
                {
                    SavePartialTransaction();
                }

                InitializeAllFields();
                m_lastDisplayedTransaction = DisplaySelectedTransaction();
                m_lastTransactionIndex = index;
                ChangeListBoxSelectedIndex(index);
                UIControls.ButtonCancelTransaction.Enabled = true;
            }
        }

        public void SavePartialTransaction()
        {
            if (TransactionChanged(m_lastDisplayedTransaction))
                if (MessageBox.Show("La transaction a changé. Voulez-vous la sauvegarder?", "Sauvegarder", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveTransaction(m_lastTransactionIndex);
                else
                    CancelPartialTransaction();
                        
        }

        public void SetDefaultSelectedIndex()
        {
            if (UIControls.TransactionListBox.Items.Count > 0 && UIControls.TransactionListBox.SelectedIndex == -1)
            {
                if (m_lastTransactionIndex < 0)
                    UIControls.TransactionListBox.SelectedIndex = 0;
                else
                {
                    if (m_lastTransactionIndex < UIControls.TransactionListBox.Items.Count)
                        UIControls.TransactionListBox.SelectedIndex = m_lastTransactionIndex;
                }
            }
        }

        public void TransactionModeChanged()
        {
            if (m_bManualCheck)
            {
                if (m_lastDisplayedTransaction != null)
                {
                    if (!UIControls.RadioButtonIsAutomatic.Checked)
                    {
                        m_lastDisplayedTransaction.m_TransactionMode = ETransactionMode.e_Manual;
                        if (!m_inNewTransaction)
                            FillAmountAlreadyPayed(m_lastDisplayedTransaction);
                    }
                    else
                    {
                        m_lastDisplayedTransaction.m_TransactionMode = ETransactionMode.e_Automatique;
                    }
                }
                UpdateButtonsState();
            }
        }

        public bool AddTransactionInList(TTransactionInfo info)
        {
            return UpdateTransactionInList(info, UIControls.TransactionListBox.Items.Count);
        }

        public bool UpdateTransactionInList(TTransactionInfo info, int listIndex)
        {   
            string textToDisplay = TextFormatter.FormatTransactionText(info);

            if (textToDisplay != "")
            {
                TDisplayInfo displayInfo = new TDisplayInfo(textToDisplay, info.m_ID, info.m_Type, info.m_AccountId);
                if (listIndex == UIControls.TransactionListBox.Items.Count) // new transaction
                {
                    UIControls.TransactionListBox.Items.Add(displayInfo);
                }
                else
                    UIControls.TransactionListBox.Items[listIndex] = displayInfo;
            }
            // Add transaction info in ToCome list if something is going on for the next month
            if (info.m_Type == EType.e_Income || info.m_Type == EType.e_Expense || info.m_Type == EType.e_Pret)
            {
                m_main.AddToComeTransaction(info);
            }
            return textToDisplay != "";
        }

        public void UpdateButtonsState()
		{
            if (UIControls.RadioOneShotTrans != null && UIControls.RadioOneShotTrans.Checked)
            {
                UIControls.LabelStartDate.Text = "Paiement le:";
                if (UIControls.LabelEndDate != null) 
                    UIControls.LabelEndDate.Visible = false;
                if (UIControls.DateEnd != null)
                    UIControls.DateEnd.Visible = false;
                UIControls.LabelPeriod.Visible = false;
                UIControls.TextBoxPeriod.Visible = false;
                UIControls.ComboBoxPeriodLength.Visible = false;
                UIControls.LabelFirstTimeInMonth.Visible = false;
                UIControls.ComboBoxFirstTimeInMonth.Visible = false;
                UIControls.LabelSecondTimeInMonth.Visible = false;
                UIControls.ComboBoxSecondTimeInMonth.Visible = false;
            }
            else
            {
                UIControls.LabelStartDate.Text = "1er paiement le:";
                if (UIControls.LabelEndDate != null)
                    UIControls.LabelEndDate.Visible = true;
                if (UIControls.DateEnd != null) 
                    UIControls.DateEnd.Visible = true;

                if (UIControls.RadioPeriodicTrans.Checked)
                {
                    UIControls.LabelPeriod.Visible = true;
                    UIControls.TextBoxPeriod.Visible = true;
                    UIControls.ComboBoxPeriodLength.Visible = true;
                    if ((EPeriodLength)UIControls.ComboBoxPeriodLength.SelectedIndex == EPeriodLength.e_PerMonth)
                    {
                        UIControls.LabelFirstTimeInMonth.Visible = true;
                        UIControls.LabelFirstTimeInMonth.Text = "Jour dans le mois:";
                        UIControls.ComboBoxFirstTimeInMonth.Visible = true;
                        UIControls.LabelFirstTimeInMonth.Location = m_originalLabelFirstTimeInMonthLocation;
                        UIControls.ComboBoxFirstTimeInMonth.Location = m_originalComboBoxFirstTimeInMonthLocation;
                        UIControls.LabelFirstTimeInMonth.Visible = true;
                        UIControls.ComboBoxFirstTimeInMonth.Visible = true;
                    }
                    else
                    {
                        UIControls.LabelFirstTimeInMonth.Visible = false;
                        UIControls.ComboBoxFirstTimeInMonth.Visible = false;
                    }
                    UIControls.LabelSecondTimeInMonth.Visible = false;
                    UIControls.ComboBoxSecondTimeInMonth.Visible = false;
                }
                else
                {
                    UIControls.LabelPeriod.Visible = false;
                    UIControls.TextBoxPeriod.Visible = false;
                    UIControls.ComboBoxPeriodLength.Visible = false;
                    UIControls.LabelFirstTimeInMonth.Visible = true;
                    UIControls.ComboBoxFirstTimeInMonth.Visible = true;
                    if (UIControls.RadioTwoTimesInMonthTrans.Checked)
                    {
                        UIControls.LabelFirstTimeInMonth.Text = "1ère fois:";
                        UIControls.LabelFirstTimeInMonth.Location = UIControls.LabelPeriod.Location;
                        UIControls.ComboBoxFirstTimeInMonth.Location = UIControls.TextBoxPeriod.Location;
                        UIControls.LabelSecondTimeInMonth.Visible = true;
                        UIControls.ComboBoxSecondTimeInMonth.Visible = true;
                        UIControls.LabelSecondTimeInMonth.Location = m_originalLabelFirstTimeInMonthLocation;
                        UIControls.ComboBoxSecondTimeInMonth.Location = m_originalComboBoxFirstTimeInMonthLocation;
                    }
                    else 
                    {
                        UIControls.LabelFirstTimeInMonth.Location = m_originalLabelFirstTimeInMonthLocation;
                        UIControls.ComboBoxFirstTimeInMonth.Location = m_originalComboBoxFirstTimeInMonthLocation;
                    }
                }
            }
            if (UIControls.RadioButtonIsAutomatic.Checked)
            {
                UIControls.DataGridAmountAlreadyPayed.Visible = false;
                UIControls.PanelBalanceAndButtons.Location = new Point(UIControls.PanelBalanceAndButtons.Location.X, UIControls.DataGridAmountAlreadyPayed.Location.Y);
            }
            else
            {
                UIControls.DataGridAmountAlreadyPayed.Visible = true;
                UIControls.PanelBalanceAndButtons.Location = new Point(UIControls.PanelBalanceAndButtons.Location.X, m_originalPanelLocationY);
            }
            if (m_dataType == EType.e_Pret)
            {
                EPretType pretType = (EPretType)UIControls.ComboBoxPretType.SelectedIndex;
                UIControls.ComboBoxInterestsPaiedDay.Visible = (pretType == EPretType.e_MortgageLinkedToAccount);
                UIControls.LabelInterestsPaiedDay.Visible = (pretType == EPretType.e_MortgageLinkedToAccount);
            }
		}

		public bool ValidateData()
		{
			if ( UIControls.TextBoxTransactionName.Text.Length == 0 )
			{
				MessageBox.Show( m_main, "Le nom de la transaction ne peut être vide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return false;
			}
            if (UIControls.TextBoxTransactionName.Text.Length > m_TransactionNameMaxLength)
			{
				MessageBox.Show( m_main, "Le nom de la transaction ne doit pas dépasser " + m_TransactionNameMaxLength.ToString() + " caractères.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return false;
			}
			if ( !ClassTools.IsDouble( UIControls.TextBoxAmount.Text ) )
			{
				MessageBox.Show( m_main, "Vous devez entrer un chiffre pour le montant.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return false;
			}
            if (UIControls.TextBoxPeriod.Visible && !ClassTools.IsInt(UIControls.TextBoxPeriod.Text))
			{
				MessageBox.Show( m_main, "Vous devez entrer un chiffre pour la période.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return false;
			}
			return true;
		}

        public TTransactionInfo TransferFromFormToStructure()
        {
            return TransferFromFormToStructure(UIControls.TransactionListBox.SelectedIndex);
        }

        public TTransactionInfo TransferFromFormToStructure(int listIndex)
		{
            TTransactionInfo info = new TTransactionInfo();

            if (listIndex >= 0)
            {
                TDisplayInfo displayInfo = UIControls.TransactionListBox.Items[listIndex] as TDisplayInfo;
                if (displayInfo != null)
                    info.m_ID = displayInfo.ID;
            }

			if (UIControls.RadioOneShotTrans != null && UIControls.RadioOneShotTrans.Checked )
				info.m_eTransactionType = ETransactionType.e_OneShotTransaction;
			else if ( UIControls.RadioPeriodicTrans.Checked )
				info.m_eTransactionType = ETransactionType.e_PeriodicTransaction;
			else if ( UIControls.RadioTwoTimesInMonthTrans.Checked )
				info.m_eTransactionType = ETransactionType.e_TwoTimesInMonthTransaction;

            info.m_AccountId = m_main.CurrentAccountId;
            info.m_Type = m_dataType;
            info.m_TransactionName = UIControls.TextBoxTransactionName.Text;
            if (UIControls.ComboBoxCategory != null)    
                info.m_Category = ClassTools.GetCategory(UIControls.ComboBoxCategory.Text, ClassTransactions.GetTransactions().Categories);
            info.m_Amount = Utils.ConvertToDouble(UIControls.TextBoxAmount.Text);

            info.m_Period = Utils.ConvertToInt(UIControls.TextBoxPeriod.Text);
            info.m_PeriodLength = (EPeriodLength)UIControls.ComboBoxPeriodLength.SelectedIndex;

            info.m_StartDate = UIControls.DateStart.Value;
            if (UIControls.DateEnd != null)
                info.m_EndDate = UIControls.DateEnd.Value;

            info.m_FirstTimeInMonth = Utils.GetDayFromComboText(UIControls.ComboBoxFirstTimeInMonth.Text);
            info.m_SecondTimeInMonth = Utils.GetDayFromComboText(UIControls.ComboBoxSecondTimeInMonth.Text);
            info.m_AmountAlreadyPayed = GetAmountAlreadyPayedFromForm();
            info.m_Note = UIControls.TextBoxNotes.Text;
            info.m_TransactionMode = UIControls.RadioButtonIsAutomatic.Checked ? ETransactionMode.e_Automatique : ETransactionMode.e_Manual;
            info.m_RemoveFromAnnualReport = UIControls.CheckBoxRemoveFromAnnualReport.Checked;
            
            if (info.m_Type == EType.e_Pret)
            {
                info.m_PretType = (EPretType)UIControls.ComboBoxPretType.SelectedIndex;
                info.m_PretInterestRate = Utils.ConvertToDouble(UIControls.TextBoxPretInterestRate.Text, true);
                info.m_PretPaiementType = (EPretPaiementType)UIControls.ComboBoxPretPaiementType.SelectedIndex;
                if (info.m_PretPaiementType == EPretPaiementType.e_FixedPaiements)
                {
                    info.m_PretAmountPerPaiement = Utils.ConvertToDouble(UIControls.TextBoxPretPaiementAmount.Text);
                }
                else
                {
                    info.m_PretAmortissementMonths = Utils.ConvertToInt(UIControls.TextBoxPretPaiementAmount.Text);
                    if (info.m_PretPaiementType == EPretPaiementType.e_AmortissementYears)
                        info.m_PretAmortissementMonths *= 12;
                }
                info.m_PretInterestsPaiedDay = Utils.GetDayFromComboText(UIControls.ComboBoxInterestsPaiedDay.Text);
            }
            return info;
		}

		public void TransferFromStructureToForm(TTransactionInfo info)
		{
            SetMinAndMaxDates();

            if (UIControls.ComboBoxPeriodLength.Items.Count >= 5)
                UIControls.ComboBoxPeriodLength.Items.RemoveAt(4); // Accelerated paiement

            UIControls.TextBoxTransactionName.Text = info.m_TransactionName;
            if (UIControls.ComboBoxCategory != null)
                UIControls.ComboBoxCategory.Text = ClassTools.GetCategory(info.m_Category, ClassTransactions.GetTransactions().Categories);
            UIControls.CheckBoxRemoveFromAnnualReport.Checked = info.m_RemoveFromAnnualReport;
            UIControls.TextBoxNotes.Text = info.m_Note;

            if (UIControls.RadioOneShotTrans != null)
                UIControls.RadioOneShotTrans.Checked = (info.m_eTransactionType == ETransactionType.e_OneShotTransaction);
            UIControls.RadioPeriodicTrans.Checked = (info.m_eTransactionType == ETransactionType.e_PeriodicTransaction);
            UIControls.RadioTwoTimesInMonthTrans.Checked = (info.m_eTransactionType == ETransactionType.e_TwoTimesInMonthTransaction);

            UIControls.TextBoxAmount.Text = info.m_Amount.ToString();
            UIControls.TextBoxAmount.Tag = UIControls.TextBoxAmount.Text;
            UIControls.TextBoxPeriod.Text = info.m_Period.ToString();
            if (info.m_Type == EType.e_Pret && info.m_PretPaiementType != EPretPaiementType.e_FixedPaiements)
                if (UIControls.ComboBoxPeriodLength.Items.Count < 5)
                    UIControls.ComboBoxPeriodLength.Items.Add(Utils.ACCELERATED_PAIEMENTS);
            if (UIControls.ComboBoxPeriodLength.Items.Count > (int)info.m_PeriodLength)
                UIControls.ComboBoxPeriodLength.SelectedIndex = (int)info.m_PeriodLength;

            UIControls.ComboBoxFirstTimeInMonth.SelectedIndex = (info.m_FirstTimeInMonth > 0 ? info.m_FirstTimeInMonth - 1 : 0);
            UIControls.ComboBoxSecondTimeInMonth.SelectedIndex = (info.m_SecondTimeInMonth > 0 ? info.m_SecondTimeInMonth - 1 : 0);

            m_bManualCheck = false;
            UIControls.RadioButtonIsManual.Checked = (info.m_TransactionMode == ETransactionMode.e_Manual);
            UIControls.RadioButtonIsAutomatic.Checked = (info.m_TransactionMode == ETransactionMode.e_Automatique);
            m_bManualCheck = true;

            FillAmountAlreadyPayed(info);

            UIControls.LabelBalance.Text = TextFormatter.GetLabelBalance(info, m_main.CurrentEndPredictionDate, m_dataType);
            UIControls.LabelWarning.Text = info.m_Warning.Replace(ClassTransactions.GOOD_NEWS, "");
            if (info.m_Warning.StartsWith(ClassTransactions.GOOD_NEWS))
                UIControls.LabelWarning.ForeColor = Color.Green;
            else
                UIControls.LabelWarning.ForeColor = Color.Red;

            bool bSave = false;
            try
            {
                UIControls.DateStart.Value = info.m_StartDate;
            }
            catch
            {
                UIControls.DateStart.Value = new DateTime(LocalSettings.BudgetYear, info.m_StartDate.Month, info.m_StartDate.Day);
                bSave = true;
            }
            try
            {
                if (UIControls.DateEnd != null)
                    UIControls.DateEnd.Value = info.m_EndDate;
            }
            catch
            {
                if (UIControls.DateEnd != null)
                    UIControls.DateEnd.Value = new DateTime(LocalSettings.BudgetYear, info.m_EndDate.Month, info.m_EndDate.Day);
                bSave = true;
            }

            if (bSave)
            {
                SaveTransaction(UIControls.TransactionListBox.SelectedIndex);
                UIControls.TransactionListBox.Focus();
            }
            
            if (info.m_Type == EType.e_Pret)
            {
                UIControls.ComboBoxPretType.SelectedIndex = (int)info.m_PretType;
                UIControls.TextBoxPretInterestRate.Text = ClassTools.ConvertDoubleToString(info.m_PretInterestRate);
                UIControls.ComboBoxPretPaiementType.SelectedIndex = (int)info.m_PretPaiementType;
                if (info.m_PretPaiementType == EPretPaiementType.e_FixedPaiements)
                {
                    UIControls.TextBoxPretPaiementAmount.Text = ClassTools.ConvertDoubleToString(info.m_PretAmountPerPaiement);
                }
                else
                {
                    int amortissement = info.m_PretAmortissementMonths;
                    if (info.m_PretPaiementType == EPretPaiementType.e_AmortissementYears)
                        amortissement /= 12;
                    UIControls.TextBoxPretPaiementAmount.Text = amortissement.ToString();
                }
                if (info.m_PretInterestsPaiedDay >= 0)
                    UIControls.ComboBoxInterestsPaiedDay.SelectedIndex = (info.m_PretInterestsPaiedDay > 0 ? info.m_PretInterestsPaiedDay - 1 : 0); 
            }
		}

        public void ChangeAllControlsVisibility(bool isVisible)
        {
            UIControls.TextBoxTransactionName.Visible = isVisible;
            UIControls.LabelCategory.Visible = isVisible;
            UIControls.ComboBoxCategory.Visible = isVisible;
            UIControls.CheckBoxRemoveFromAnnualReport.Visible = isVisible;
            UIControls.LabelTransactionName.Visible = isVisible;
            UIControls.LabelAmount.Visible = isVisible;
            UIControls.LabelDollar.Visible = isVisible;
            if (UIControls.RadioOneShotTrans != null)
                UIControls.RadioOneShotTrans.Visible = isVisible;
            UIControls.LabelStartDate.Visible = isVisible;
            if (UIControls.LabelEndDate != null)
                UIControls.LabelEndDate.Visible = isVisible;
            UIControls.DateStart.Visible = isVisible;
            if (UIControls.DateEnd != null)
                UIControls.DateEnd.Visible = isVisible;
            UIControls.LabelPeriod.Visible = isVisible;
            UIControls.TextBoxPeriod.Visible = isVisible;
            UIControls.ComboBoxPeriodLength.Visible = isVisible;
            UIControls.LabelFirstTimeInMonth.Visible = isVisible;
            UIControls.ComboBoxFirstTimeInMonth.Visible = isVisible;
            UIControls.LabelSecondTimeInMonth.Visible = isVisible;
            UIControls.ComboBoxSecondTimeInMonth.Visible = isVisible;
            UIControls.RadioPeriodicTrans.Visible = isVisible;
            UIControls.RadioTwoTimesInMonthTrans.Visible = isVisible;
            UIControls.RadioButtonIsManual.Visible = isVisible;
            UIControls.RadioButtonIsAutomatic.Visible = isVisible;
            UIControls.DataGridAmountAlreadyPayed.Visible = isVisible;
            UIControls.TextBoxAmount.Visible = isVisible;
            UIControls.LabelDollar.Visible = isVisible;
            UIControls.LabelBalance.Visible = isVisible;
            UIControls.LabelWarning.Visible = isVisible;
            UIControls.TextBoxNotes.Visible = isVisible;
            UIControls.LabelNotes.Visible = isVisible;
            UIControls.ButtonDeleteTransaction.Visible = isVisible;
            UIControls.ButtonSaveTransaction.Visible = isVisible;
            UIControls.ButtonCancelTransaction.Visible = isVisible;
            if (m_dataType == EType.e_Pret)
            {
                UIControls.ComboBoxPretType.Visible = isVisible;
                UIControls.TextBoxPretInterestRate.Visible = isVisible;
                UIControls.ComboBoxPretPaiementType.Visible = isVisible;
                UIControls.TextBoxPretPaiementAmount.Visible = isVisible;
                UIControls.LabelPretType.Visible = isVisible;
                UIControls.LabelInterestRate.Visible = isVisible;
                UIControls.LabelPercent.Visible = isVisible;
                UIControls.LabelPaiementType.Visible = isVisible;
                UIControls.LabelInterestsPaiedDay.Visible = isVisible;
                UIControls.ComboBoxInterestsPaiedDay.Visible = isVisible;
            }
        }

        public void InitializeAllFields()
        {
            MakeFieldsVisible();

            m_bManualCheck = false;
            UIControls.RadioButtonIsAutomatic.Checked = true;
            if (UIControls.RadioOneShotTrans != null)
            {
                UIControls.RadioOneShotTrans.Checked = true;
                UIControls.RadioPeriodicTrans.Checked = false;
            }
            else
            {
                UIControls.RadioPeriodicTrans.Checked = true;
            }
            
            m_bManualCheck = true;
            
            UIControls.TextBoxTransactionName.Text = "";
            if (UIControls.ComboBoxCategory != null) 
                UIControls.ComboBoxCategory.SelectedIndex = 0;
            UIControls.CheckBoxRemoveFromAnnualReport.Checked = false;
            UIControls.TextBoxAmount.Text = "0";
            UIControls.TextBoxAmount.Tag = null;
            UIControls.DataGridAmountAlreadyPayed.Rows.Clear();
            UIControls.DataGridAmountAlreadyPayed.Visible = false;
            UIControls.PanelBalanceAndButtons.Location = new Point(UIControls.PanelBalanceAndButtons.Location.X, UIControls.DataGridAmountAlreadyPayed.Location.Y);
            UIControls.TextBoxNotes.Text = "";
            UIControls.LabelWarning.Text = "";
            SetMinAndMaxDates();
            UIControls.DateStart.Value = new DateTime(LocalSettings.BudgetYear, 1, 1);
            if (UIControls.DateEnd != null) 
                UIControls.DateEnd.Value = new DateTime(LocalSettings.BudgetYear, 12, 31);
            UIControls.TextBoxPeriod.Text = "1";
            UIControls.ComboBoxPeriodLength.SelectedIndex = 0;
            UIControls.ComboBoxFirstTimeInMonth.Text = "1er";
            UIControls.ComboBoxSecondTimeInMonth.Text = "15";
            UIControls.LabelBalance.Text = ""; 
            UIControls.LabelWarning.Text = "";

            if (m_dataType == EType.e_Pret)
            {
                UIControls.ComboBoxPretType.SelectedIndex = 0;
                UIControls.TextBoxPretInterestRate.Text = "0";
                UIControls.ComboBoxPretPaiementType.SelectedIndex = 0;
                UIControls.TextBoxPretPaiementAmount.Text = "0";
                if (UIControls.ComboBoxPeriodLength.Items.Count < 5)
                    UIControls.ComboBoxPeriodLength.Items.Add(Utils.ACCELERATED_PAIEMENTS);
                UIControls.LabelInterestsPaiedDay.Visible = false;
                UIControls.ComboBoxInterestsPaiedDay.Visible = false;
            }
        }

        public void MakeFieldsVisible()
        {
            UIControls.LabelTransactionName.Visible = true;
            UIControls.TextBoxTransactionName.Visible = true;
            UIControls.LabelCategory.Visible = true;
            UIControls.ComboBoxCategory.Visible = true;
            UIControls.CheckBoxRemoveFromAnnualReport.Visible = true;
            UIControls.LabelAmount.Visible = true;
            UIControls.TextBoxAmount.Visible = true;
            UIControls.LabelDollar.Visible = true;
            UIControls.RadioButtonIsManual.Visible = true;
            UIControls.RadioButtonIsAutomatic.Visible = true;
            UIControls.DataGridAmountAlreadyPayed.Visible = true;
            UIControls.LabelNotes.Visible = true;
            UIControls.TextBoxNotes.Visible = true;
            if (UIControls.RadioOneShotTrans != null) 
                UIControls.RadioOneShotTrans.Visible = true;
            UIControls.RadioPeriodicTrans.Visible = true;
            UIControls.RadioTwoTimesInMonthTrans.Visible = true;
            UIControls.LabelStartDate.Visible = true;
            UIControls.DateStart.Visible = true;
            UIControls.ComboBoxFirstTimeInMonth.Visible = false;
            UIControls.ComboBoxSecondTimeInMonth.Visible = false;
            UIControls.ButtonDeleteTransaction.Visible = true;
            UIControls.ButtonCancelTransaction.Visible = true;
            UIControls.ButtonSaveTransaction.Visible = true;
            UIControls.LabelBalance.Visible = true;
            UIControls.LabelWarning.Visible = true;

            if (m_dataType == EType.e_Pret)
            {
                UIControls.LabelPeriod.Visible = true;
                UIControls.ComboBoxPeriodLength.Visible = true;
                UIControls.TextBoxPeriod.Visible = true;
                UIControls.ComboBoxPretType.Visible = true;
                UIControls.TextBoxPretInterestRate.Visible = true;
                UIControls.ComboBoxPretPaiementType.Visible = true;
                UIControls.TextBoxPretPaiementAmount.Visible = true;
                UIControls.LabelPretType.Visible = true;
                UIControls.LabelInterestRate.Visible = true;
                UIControls.LabelPercent.Visible = true;
                UIControls.LabelPaiementType.Visible = true;
            }
        }

        private bool TransactionChanged(TTransactionInfo oldInfo)
        {
            if (oldInfo != null)
            {
                TTransactionInfo currentInfo = TransferFromFormToStructure();
                if (currentInfo != null)
                    return (!currentInfo.IsEqual(oldInfo));
            }
            return false;
        }

        private void ChangeListBoxSelectedIndex(int index)
        {
            UIControls.TransactionListBox.SelectedIndexChanged -= m_selectedIndexChangedEvent;
            UIControls.TransactionListBox.SelectedIndex = index;
            UIControls.TransactionListBox.SelectedIndexChanged += m_selectedIndexChangedEvent;
        }

        private void SetMinAndMaxDates()
        {
            if (m_dataType != EType.e_Pret)
            {
                UIControls.DateStart.MaxDate = new DateTime(2098, 12, 31);
                UIControls.DateStart.MinDate = new DateTime(LocalSettings.BudgetYear, 1, 1);
                UIControls.DateStart.MaxDate = new DateTime(LocalSettings.BudgetYear, 12, 31);
                if (UIControls.DateEnd != null)
                {
                    UIControls.DateEnd.MaxDate = new DateTime(2098, 12, 31);
                    UIControls.DateEnd.MinDate = new DateTime(LocalSettings.BudgetYear, 1, 1);
                    UIControls.DateEnd.MaxDate = new DateTime(LocalSettings.BudgetYear, 12, 31);
                }
            }
        }

        private TTransactionInfo DisplaySelectedTransaction()
        {
            int index = UIControls.TransactionListBox.SelectedIndex;
            if (index >= 0)
            {
                TDisplayInfo info = UIControls.TransactionListBox.Items[index] as TDisplayInfo;

                if (info != null)
                {
                    Dictionary<int, TTransactionInfo> transactions = ClassTransactions.GetTransactions().Transactions;
                    if (transactions.ContainsKey(info.ID))
                    {
                        TTransactionInfo newTransactionToDisplay = transactions[info.ID];

                        m_lastDisplayedTransaction = newTransactionToDisplay;
                        TransferFromStructureToForm(m_lastDisplayedTransaction);
                        UpdateButtonsState();
                        return transactions[info.ID];
                    }
                }
            }
            return null;
        }

        private void FillAmountAlreadyPayed(TTransactionInfo info)
        {
            try
            {
                List<DateTime> dates = new List<DateTime>();
                UIControls.DataGridAmountAlreadyPayed.Rows.Clear();

                ClassTransactions.GetTransactions().FillPaiementDates(info, m_main.CurrentEndPredictionDate, dates);

                AddAmountAlreadyPayedInDataGrid(dates, info.m_AmountAlreadyPayed, info.m_TransactionMode);
                info.m_AmountAlreadyPayed = GetAmountAlreadyPayedFromForm(); // to make sure it is up to date and won't send wrong transaction changed message
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void AddAmountAlreadyPayedInDataGrid(List<DateTime> dates, string amountAlreadyPayed, ETransactionMode mode)
        {
            int i = 0;
            string[] amounts = amountAlreadyPayed.Split(';');

            dates.Sort();

            UIControls.DataGridAmountAlreadyPayed.Columns[2].Visible = (mode == ETransactionMode.e_Manual);
            
            foreach (DateTime date in dates)
            {
                UIControls.DataGridAmountAlreadyPayed.Rows.Add();
                DataGridViewRow row = UIControls.DataGridAmountAlreadyPayed.Rows[i];
                if (m_dataType == EType.e_Expense || m_dataType == EType.e_Pret)
                    row.Cells[0].Value = "Paiement effectué le " + ClassTools.ConvertDateToString(date) + ":";
                else
                    row.Cells[0].Value = "Revenu déposé le " + ClassTools.ConvertDateToString(date) + ":";
                bool bCompleted = false;
                if (amounts != null && i < amounts.Length)
                {
                    string sAmount = amounts[i];
                    bCompleted = sAmount.StartsWith("C");
                    row.Cells[2].Value = bCompleted ? "true" : "false";
                    row.Cells[1].Value = sAmount.Replace("C", "") + " $";
                }
                else
                    row.Cells[1].Value = 0 + " $";
                // Check if some are completed after this one. If yes, set this one as completed
                if (!bCompleted)
                    if (ShouldBeCompleted(amounts, i))
                        row.Cells[2].Value = "true";
                i++;
            }
        }

        private bool ShouldBeCompleted(string[] amounts, int i)
        {
            int index = i;
            while (++index < amounts.Length) // if next one is set as completed, or # 0, set this one as completed too
            {
                string sNextAmount = amounts[index];
                double nextAmount;
                double.TryParse(sNextAmount.Replace("C", ""), out nextAmount);

                if (sNextAmount.StartsWith("C") || nextAmount != 0)
                {
                    return true;
                }
            }
            return false;
        }

        private string GetAmountAlreadyPayedFromForm()
        {
            string sAmountAlreadyPayed = "";
            for (int i = 0; i < UIControls.DataGridAmountAlreadyPayed.Rows.Count; i++)
            {
                DataGridViewRow row = UIControls.DataGridAmountAlreadyPayed.Rows[i];
                if (!string.IsNullOrEmpty(sAmountAlreadyPayed))
                {
                    sAmountAlreadyPayed += ";";
                }
                object value = row.Cells[1].Value;
                if (value == null)
                    value = "0";
                if (row.Cells[2].Value != null)
                    if (string.Compare(row.Cells[2].Value.ToString(), "true", true) == 0)
                        sAmountAlreadyPayed += "C";
                string sValue = value.ToString().Replace("$", "").Trim();
                sAmountAlreadyPayed += ClassTools.ConvertDoubleToString(FormulaParser.Calculate(sValue));
            }
            if (string.IsNullOrEmpty(sAmountAlreadyPayed))
                sAmountAlreadyPayed = "0";
            return sAmountAlreadyPayed;
        }

        public TTransactionInfo LastDisplayedTransaction { get { return m_lastDisplayedTransaction; } }

        private UIControlsStruct UIControls;
        private TTransactionInfo m_lastDisplayedTransaction = new TTransactionInfo();
        private int m_lastTransactionIndex = -1;
        private bool m_inNewTransaction;
        private EventHandler m_selectedIndexChangedEvent;

        private Point m_originalLabelFirstTimeInMonthLocation;
        private Point m_originalComboBoxFirstTimeInMonthLocation;
        private int m_originalPanelLocationY;

        private FormMain m_main;
        private EType m_dataType;
        private const int m_AccountNameMaxLength = 15;
		private const int m_TransactionNameMaxLength = 250;
        private bool m_bManualCheck = true;
	}

    public struct UIControlsStruct
    {
        public ListBox TransactionListBox;
        public Label LabelAmount;
        public Label LabelDollar;
        public RadioButton RadioOneShotTrans;
        public Label LabelStartDate;
        public Label LabelEndDate;
        public DateTimePicker DateStart;
        public DateTimePicker DateEnd;
        public Label LabelPeriod;
        public TextBox TextBoxPeriod;
        public ComboBox ComboBoxPeriodLength;
        public Label LabelFirstTimeInMonth;
        public ComboBox ComboBoxFirstTimeInMonth;
        public Label LabelSecondTimeInMonth;
        public ComboBox ComboBoxSecondTimeInMonth;
        public RadioButton RadioPeriodicTrans;
        public RadioButton RadioTwoTimesInMonthTrans;
        public RadioButton RadioButtonIsManual;
        public RadioButton RadioButtonIsAutomatic;
        public DataGridView DataGridAmountAlreadyPayed;
        public TextBox TextBoxTransactionName;
        public TextBox TextBoxAmount;
        public TextBox TextBoxNotes;
        public Label LabelBalance;
        public Label LabelWarning;
        public Label LabelVirement;
        public Label LabelTransactionName;
        public Label LabelNotes;
        public Panel PanelBalanceAndButtons; 
        public Button ButtonNewTransaction;
        public Button ButtonDeleteTransaction;
        public Button ButtonSaveTransaction;
        public Button ButtonCancelTransaction;
        public Label LabelCategory;
        public ComboBox ComboBoxCategory;
        public CheckBox CheckBoxRemoveFromAnnualReport;

        public ComboBox ComboBoxPretType;
        public TextBox TextBoxPretInterestRate;
        public ComboBox ComboBoxPretPaiementType;
        public TextBox TextBoxPretPaiementAmount;
        public Label LabelPretType;
        public Label LabelInterestRate;
        public Label LabelPercent;
        public Label LabelPaiementType;
        public Label LabelInterestsPaiedDay;
        public ComboBox ComboBoxInterestsPaiedDay;
    }
}
