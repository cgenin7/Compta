using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using Comptability;
using ComptaCommun;
using ComptaDB;

namespace Compta
{
    public partial class FormMain : Form // CustomizedForm
    {
        #region Private variables

        private int m_currentAccountId = -1;
        private DisplayData m_incomesDisplayData;
        private DisplayData m_expensesDisplayData;
        
        #endregion

        #region public properties

        public int CurrentAccountId
        {
            get { return m_currentAccountId; }
            set { m_currentAccountId = value; }
        }

        public string NewName { get; set; }
        public string OldName { get; set; }

        #endregion

        public void AddToComeTransaction(TTransactionInfo info)
        {
            if (info.m_Type == EType.e_Expense)
                AddToComeTransaction(info, listBoxToComeExpense);
            else
                AddToComeTransaction(info, listBoxToComeIncome);

            listBoxToComeExpense.Sorted = true;
            var totalExpenses = listBoxToComeExpense.GetTotalAmount();
            labelExpensesToCome.Text = $"{ClassTools.ConvertCurrencyToString(totalExpenses)} à dépenser dans les 7 prochains jours";

            listBoxToComeIncome.Sorted = true;
            var totalIncomes = listBoxToComeIncome.GetTotalAmount();
            labelIncomesToCome.Text = $"{ClassTools.ConvertCurrencyToString(totalIncomes)} à recevoir dans les 7 prochains jours";
        }

        private void AddToComeTransaction(TTransactionInfo info, ListBoxSortedByDate listBoxToCome)
        {
            listBoxToCome.Sorted = false;
            TTransactionInfo copyInfo = new TTransactionInfo(info);
            DateTime in7DaysTime = DateTime.Now.AddDays(7);
            bool bAdded = false;
            int itemInListIndex = GetListIndexFromId(listBoxToCome, copyInfo.m_ID);

            DateTime nextPaiementDate = copyInfo.m_FirstPaiementDate.Date;
            if (copyInfo.m_eTransactionType == ETransactionType.e_OneShotTransaction)
                nextPaiementDate = copyInfo.m_StartDate;

            if (!string.IsNullOrEmpty(info.m_Warning) && !info.m_Warning.StartsWith(ClassTransactions.GOOD_NEWS))
            {
                AddItemToCome(listBoxToCome, itemInListIndex, copyInfo, nextPaiementDate);
            }
            else
            {
                DateTime startDate = DateTime.Now;
                copyInfo.m_Balance = 0;
                while (nextPaiementDate.Date <= in7DaysTime.Date)
                {
                    ClassCalculation.GetTransactionBalance(startDate, nextPaiementDate, ref copyInfo, false);
                    if (copyInfo.m_Balance <= 0.01)
                        break;
                    
                    bAdded = true;
                    AddItemToCome(listBoxToCome, itemInListIndex, copyInfo, nextPaiementDate);

                    startDate = nextPaiementDate.AddDays(1);
                    DateTime oldNextPaimentDate = nextPaiementDate;
                    nextPaiementDate = Util.GetNextPaiementDate(copyInfo, nextPaiementDate);

                    if (oldNextPaimentDate.Date == nextPaiementDate.Date)
                        break;
                }
            }
            if (!bAdded && itemInListIndex >= 0)
                listBoxToCome.Items.RemoveAt(itemInListIndex);
        }

        public void AddItemToCome(ListBoxSortedByDate listBoxToCome, int itemInListIndex, TTransactionInfo copyInfo, DateTime nextPaiementDate)
        {
            var sAccountName = (m_currentAccountId == -1 ? ClassAccounts.GetAccounts().GetAccountNameFromId(copyInfo.m_AccountId) + " - " : "");

            var sToCome = sAccountName + TextFormatter.FormatToComeTransactionText(copyInfo, nextPaiementDate);

            TDisplayInfo displayInfo = new TDisplayInfo(sToCome, copyInfo.m_ID, copyInfo.m_OrderID, copyInfo.m_Type, copyInfo.m_AccountId, copyInfo.m_WarningAmount);

            displayInfo.Date = nextPaiementDate;
            if (itemInListIndex >= 0)
                listBoxToCome.Items[itemInListIndex] = displayInfo;
            else
                listBoxToCome.Items.Add(displayInfo);
        }

        public void DeleteToComeTransaction(TDisplayInfo info)
        {
            if (info.DataType == EType.e_Expense)
                DeleteToComeTransaction(info.ID, listBoxToComeExpense);
            else
                DeleteToComeTransaction(info.ID, listBoxToComeIncome);
        }

        private void DeleteToComeTransaction(int ID, ListBoxSortedByDate listBoxToCome)
        {
            int itemInListIndex = GetListIndexFromId(listBoxToCome, ID);
            if (itemInListIndex >= 0)
                listBoxToCome.Items.RemoveAt(itemInListIndex);
        }

        #region Private Methods

        private void ClearAllInfo()
        {
            labelPredictedBalance0.Text = "0 $";
            labelPredictedBalance0.ForeColor = Color.DarkGreen;
            chartAnnuals.Visible = false;
            chartPredictedBalances.Visible = false;
            listBoxToComeExpense.Items.Clear();
            listBoxToComeIncome.Items.Clear();
            TextBoxNotes0.Text = "";
            ListBoxRevenus1.Items.Clear(); 
            ListBoxDepenses2.Items.Clear();
            ListBoxHistorique5.Items.Clear();
        }

        private void LoadInfoFromDatabase(bool reinitializeAllTransactions = false, bool isFirstTime = false)
        {
            Text = "Planificateur de budget familial - " + LocalSettings.DatabaseName;
            DisableEvents();
            try
            {
                ClearAllInfo();

                CurrentStartPredictionDate = new DateTime(LocalSettings.BudgetYear, 1, 1);
                CurrentEndPredictionDate = new DateTime(LocalSettings.BudgetYear, 12, 31);

                UpgradeDB.UpgradeTables();

                ClassAccounts.GetAccounts().LoadAccountsFromDataStorage();

                ClassTransactions.GetTransactions().LoadCategoriesFromDataStorage();

                Utils.FillComboCategories(comboBoxCategory1);
                Utils.FillComboCategories(comboBoxCategory2);
                
                Dictionary<int, TAccountInfo> accountsInfo = ClassAccounts.GetAccounts().AccountsInfo;

                if (accountsInfo != null)
                {
                    if (accountsInfo.Count == 0)
                    {
                        AddAccount("Compte Principal");
                        accountsInfo = ClassAccounts.GetAccounts().AccountsInfo;
                    }

                    tabControlLeft.SelectedIndexChanged -= tabControlLeft_SelectedIndexChanged;
                    tabControlLeft.TabPages.Clear();
                    tabControlLeft.TabPages.Add(m_tabPageLeftSummary);
                        
                    ClassTransactions.GetTransactions().LoadTransactionsFromDataStorage();
                    
                    foreach (TAccountInfo account in accountsInfo.Values)
                    {
                        if (account != null)
                        {
                            int accountId = account.AccountId;
                            string accountName = ClassAccounts.GetAccounts().GetAccountNameFromId(accountId);

                            tabControlLeft.TabPages.Add(accountName);
                            tabControlLeft.TabPages[tabControlLeft.TabPages.Count - 1].Name = accountName;

                            if (isFirstTime)
                            {
                                AccountsCurrentBalanceForm balanceForm = new AccountsCurrentBalanceForm(accountName);
                                balanceForm.CurrentBalance = account.Balance;

                                if (balanceForm.ShowDialog(this) == DialogResult.OK)
                                    account.Balance = balanceForm.CurrentBalance;
                                else
                                    Close();
                            }
                            if (reinitializeAllTransactions)
                            {
                                ClassTransactions.GetTransactions().ReinitializeAllTransactions();
                                if (ClassHistory.GetHistory().HistoryInfo != null)
                                {
                                    ClassHistory.GetHistory().HistoryInfo.Clear();
                                    ClassHistory.GetHistory().SaveHistoryInDataStorage(m_currentAccountId);
                                }
                            }
                            DateTime startPredictionDate = (DateTime.Now.Date >= CurrentStartPredictionDate.Date ? DateTime.Now.AddDays(1) : CurrentStartPredictionDate);
                            TPredictedBalance tPredictedBalance = new TPredictedBalance(accountId, startPredictionDate, CurrentEndPredictionDate);
                            GetPredictedBalanceAtSpecificDate(account.Balance, ref tPredictedBalance);
                            account.ExpensesAtPredictionDate = tPredictedBalance.Expenses;
                            account.IncomesAtPredictionDate = tPredictedBalance.Incomes;
                            account.MortgageBalance = tPredictedBalance.TotalPretsRemaining;
                        }
                    }

                    tabControlLeft.SelectedIndexChanged += tabControlLeft_SelectedIndexChanged;

                    Exception exception;
                    ClassAccounts.GetAccounts().SaveAccountsInDataStorage(out exception);
                    if (exception != null)
                    {
                        MessageBox.Show(exception.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    InitializeAccount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
            ReenableEvents();
        }

        private void DisableEvents()
        {
            TextBoxNotes0.TextChanged -= TextBoxNotes0_TextChanged;
        }

        private void ReenableEvents()
        {
            TextBoxNotes0.TextChanged += TextBoxNotes0_TextChanged;
        }

        private void InitializeAccount()
        {
            try
            {
                int currentAccountId = GetSelectedAccountId();
                
                labelSoldeActuel0.Visible = (currentAccountId != -1);
                textBoxSoldeActuel0.Visible = (currentAccountId != -1);
                labelDollar0.Visible = (currentAccountId != -1);
                
                labelBudgetYear.Visible = (currentAccountId == -1);
                comboBoxBudgetName.Visible = (currentAccountId == -1);

                labelNotes0.Visible = (currentAccountId != -1);
                TextBoxNotes0.Visible = (currentAccountId != -1);

                if (currentAccountId != -1)
                    AddSpecificAccount(currentAccountId);
                else
                    AddAllAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void AddAllAccounts()
        {
            tabPageSolde.Text = "Solde des comptes";

            FillUpToComeForAllAccounts();
            
            FillUpSummaryInfo();

            FillUpPredictedBalances();
        }

        private void AddSpecificAccount(int currentAccountId)
        {
            Dictionary<int, TAccountInfo> accounts = ClassAccounts.GetAccounts().AccountsInfo;
            TAccountInfo accountInfo = accounts[currentAccountId];

            tabPageSolde.Text = "Solde";

            m_currentAccountId = accountInfo.AccountId;

            buttonNewRevenu1.Enabled = true;
            buttonNewDepense2.Enabled = true;
            
            textBoxSoldeActuel0.Text = "  " + accountInfo.Balance.ToString();
            textBoxSoldeActuel0.Tag = accountInfo.Balance.ToString();
            TextBoxNotes0.Text = accountInfo.Note;

            ClassHistory.GetHistory().LoadHistoryFromDataStorage(m_currentAccountId);

            ClassTransactions.GetTransactions().VerifyTransactionDates();
            
            FillUpControls();

            m_incomesDisplayData.InitializeAll();
            m_expensesDisplayData.InitializeAll();
            m_incomesDisplayData.SetDefaultSelectedIndex();
            m_expensesDisplayData.SetDefaultSelectedIndex();
            
            ChangeTitles();
        }

        private void AdjustTabs()
        {
            textBoxSoldeActuel0.GotFocus -= textBoxSoldeActuel0_GotFocus;
            textBoxSoldeActuel0.LostFocus -= textBoxSoldeActuel0_LostFocus;
            
            tabControlMain.TabPages.Clear();
            switch (tabControlLeft.SelectedTab.Name)
            {
                case TAB_SUMMARY:
                    tabControlMain.TabPages.Add(m_tabPageSolde);
                    m_currentAccountId = -1;
                    InitializeAccount();
                    break;
                default: // accounts
                    Dictionary<int, TAccountInfo> accountsInfo = ClassAccounts.GetAccounts().AccountsInfo;
                    tabControlMain.TabPages.Add(m_tabPageSolde);
                    tabControlMain.TabPages.Add(m_tabPageIncomes);
                    tabControlMain.TabPages.Add(m_tabPageExpenses);
                    tabControlMain.TabPages.Add(m_tabPageHistorique);
                    InitializeAccount();
                    break;
            }
            textBoxSoldeActuel0.GotFocus += textBoxSoldeActuel0_GotFocus;
            textBoxSoldeActuel0.LostFocus += textBoxSoldeActuel0_LostFocus;
        }

        private void AddAccount(string accountName)
        {
            TAccountInfo accountInfo = new TAccountInfo();
            accountInfo.AccountId = ClassAccounts.GetAccounts().FindNextAccountId();
            accountInfo.AccountName = accountName;
            accountInfo.StartPrediction = DateTime.Now;
            accountInfo.PredictionDate = new DateTime(DateTime.Now.Year, 12, 31);
            accountInfo.Balance = 0;
            ClassAccounts.GetAccounts().AccountsInfo.Add(accountInfo.AccountId, accountInfo);
            AccountInfoData.AddAccountInfo(accountInfo);
        }

        private int GetListIndexFromId(ListBox listBox, int ID)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                TDisplayInfo info = listBox.Items[i] as TDisplayInfo;
                if (info != null && info.ID == ID)
                    return i;
            }
            return -1;
        }

        private void FillUpControls()
        {
            try
            {
                FillUpPredictedBalances();
                FillUpGeneralInfo();
                FillUpListBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        public void UpdateBalances()
        {
            FillUpPredictedBalances();
            FillUpGeneralInfo();
        }

        private void FillUpSummaryInfo()
        {
            DateTime startPredictionDate = (DateTime.Now.Date >= CurrentStartPredictionDate.Date ? DateTime.Now.AddDays(1) : CurrentStartPredictionDate);
            double soldePredit = 0;

            foreach (TAccountInfo account in ClassAccounts.GetAccounts().AccountsInfo.Values)
            {
                if (!account.RemoveFromSummary)
                {
                    TPredictedBalance predictedBalance = new TPredictedBalance(account.AccountId, startPredictionDate, CurrentEndPredictionDate);
                    soldePredit += GetPredictedBalanceAtSpecificDate(account.Balance, ref predictedBalance);
                }
            }

            labelPredictedBalance0.Text = ClassTools.ConvertCurrencyToString(soldePredit);
            labelPredictedBalance0.ForeColor = soldePredit >= 0 ? Color.DarkGreen : Color.DarkRed;
        }

        private void FillUpGeneralInfo()
        {
            DateTime startPredictionDate = (DateTime.Now.Date >= CurrentStartPredictionDate.Date ? DateTime.Now.AddDays(1) : CurrentStartPredictionDate);
            TPredictedBalance predictedBalance = new TPredictedBalance(m_currentAccountId, startPredictionDate, CurrentEndPredictionDate);

            double soldeActuel = Utils.ConvertToDouble(textBoxSoldeActuel0.Text.Trim());
            
            double soldePredit = GetPredictedBalanceAtSpecificDate(soldeActuel, ref predictedBalance);
            
            Exception exception;
            TAccountInfo account = ClassAccounts.GetAccounts().AccountsInfo[m_currentAccountId];

            account.IncomesAtPredictionDate = predictedBalance.Incomes;
            account.TransferIncomes = predictedBalance.Incomes;
            account.ExpensesAtPredictionDate = predictedBalance.Expenses;
            account.TransferExpenses = predictedBalance.Expenses;
            account.MortgageBalance = predictedBalance.TotalPretsRemaining;
            
            ClassAccounts.GetAccounts().SaveAccountsInDataStorage(out exception);
            if (exception != null)
                MessageBox.Show(exception.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            labelRevenuTotal.Text = "Revenu annuel: " + ClassTools.ConvertCurrencyToString((int)predictedBalance.IncomesForTheYear) + ". " +
                ClassTools.ConvertCurrencyToString((int)predictedBalance.Incomes) + " restant à recevoir d'ici le " + ClassTools.ConvertDateToString(CurrentEndPredictionDate) + ".";
            labelTotalExpenses.Text = "Dépense annuelle: " + ClassTools.ConvertCurrencyToString((int)(predictedBalance.ExpensesForTheYear - predictedBalance.TotalPretsForTheYear));
            if (predictedBalance.TotalPretsForTheYear > 0)
                labelTotalExpenses.Text += " + " + ClassTools.ConvertCurrencyToString((int)predictedBalance.TotalPretsForTheYear) + " pour les prêts/hypothèques";
            labelTotalExpenses.Text += ". " + ClassTools.ConvertCurrencyToString((int)predictedBalance.Expenses) + " restant à dépenser d'ici le " + ClassTools.ConvertDateToString(CurrentEndPredictionDate) + ".";
    
            labelPredictedBalance0.Text = ClassTools.ConvertCurrencyToString(soldePredit);
            labelPredictedBalance0.ForeColor = soldePredit >= 0 ? Color.DarkGreen : Color.DarkRed;
            ListBoxHistorique5.Items.Clear();
            
            AddHistorique();

            listBoxToComeExpense.Select();
            listBoxToComeIncome.Select();

            ListBoxHistorique5.Select();
        }

        // Add transaction info in ToCome list if something is going on for the next month
        private void FillUpToComeForAllAccounts()
        {
            var accountsToExclude = ClassAccounts.GetAccounts().GetRemovedFromSummaryAccounts();

            listBoxToComeExpense.Items.Clear();
            listBoxToComeIncome.Items.Clear();

            Dictionary<int, TTransactionInfo> transactions = ClassTransactions.GetTransactions().Transactions;

            if (transactions != null)
            {
                foreach (int transID in transactions.Keys)
                {
                    TTransactionInfo info = transactions[transID];
                    if (info != null && !accountsToExclude.Contains(info.m_AccountId))
                        AddToComeTransaction(info);
                }
            }
        }

        private void FillUpListBoxes()
        {
            listBoxToComeExpense.Items.Clear();
            listBoxToComeIncome.Items.Clear();
            ListBoxRevenus1.Items.Clear();
            ListBoxDepenses2.Items.Clear();
            
            Dictionary<int, TTransactionInfo> transactions = ClassTransactions.GetTransactions().Transactions;
            
            if (transactions != null)
            {
                foreach (int transID in transactions.Keys)
                {
                    TTransactionInfo info = transactions[transID];
                    if (info != null)
                    {
                        if (info.m_AccountId == m_currentAccountId)
                        {
                            if (info.m_Type == EType.e_Income)
                                m_incomesDisplayData.AddTransactionInList(info);
                            else if (info.m_Type == EType.e_Expense)
                                m_expensesDisplayData.AddTransactionInList(info);
                        }
                    }
                }
            }
            
            if (ListBoxRevenus1.Items.Count <= 0)
                m_incomesDisplayData.ChangeAllControlsVisibility(false);
            if (ListBoxDepenses2.Items.Count <= 0)
                m_expensesDisplayData.ChangeAllControlsVisibility(false);
            ListBoxRevenus1.Select();
            ListBoxDepenses2.Select();
        }

        private void DrawListBoxLine(object sender, DrawItemEventArgs e, Color color, FontStyle fontStyle)
        {
            //
            // Draw the background of the ListBox control for each item.
            // Create a new Brush and initialize to a Black colored brush
            // by default.
            //
            ListBox listBox = ((ListBox)sender);
            e.DrawBackground();

            if (e.Index >= 0)
            {
                SolidBrush myBrush = new SolidBrush(color);
                Font customFont = new Font(e.Font, fontStyle);
                string strToWrite = listBox.Items[e.Index].ToString();
                e.Graphics.DrawString(strToWrite,
                        customFont, myBrush, e.Bounds, StringFormat.GenericDefault);
                Size textSize = TextRenderer.MeasureText(strToWrite, e.Font);
                if (textSize.Width + 10 > listBox.HorizontalExtent)
                    listBox.HorizontalExtent = textSize.Width + 10;
            }
            //
            // If the ListBox has focus, draw a focus rectangle 
            // around the selected item.
            //
            e.DrawFocusRectangle();
        }

        private void DrawListBoxItemsWithColors(object sender, DrawItemEventArgs e)
        {
            Color color = Color.Black;
            FontStyle fontStyle = FontStyle.Regular;

            if (e.Index >= 0)
            {
                ListBox listBox = sender as ListBox;
                if (listBox != null && listBox.Items.Count > e.Index)
                {
                    TDisplayInfo info = listBox.Items[e.Index] as TDisplayInfo;
                    if (info != null)
                    {
                        if (ClassTransactions.GetTransactions().Transactions.ContainsKey(info.ID))
                        {
                            TTransactionInfo transInfo = ClassTransactions.GetTransactions().Transactions[info.ID];
                            if (!string.IsNullOrEmpty(transInfo.m_Warning))
                            {
                                if (transInfo.m_Warning.StartsWith(ClassTransactions.GOOD_NEWS))
                                    color = Color.DarkGreen;
                                else
                                    color = Color.FromArgb(201, 44, 55);
                                fontStyle = FontStyle.Bold;
                            }
                            else if (transInfo.m_Balance == 0)
                            {
                                color = Color.FromArgb(180,180,180);
                            }
                        }
                    }
                }
            }
            DrawListBoxLine(sender, e, color, fontStyle);
        }

        private void AddWarningTooltip(ref int mouseOverIndex, ListBox listBox, ToolTip toolTip, MouseEventArgs e)
        {
            int newMouseOverIndex = listBox.IndexFromPoint(e.Location);

            if (mouseOverIndex != newMouseOverIndex)
            {
                mouseOverIndex = newMouseOverIndex;
                if (mouseOverIndex > -1 && mouseOverIndex < listBox.Items.Count)
                {
                    toolTip.Active = false;
                    TDisplayInfo displayInfo = listBox.Items[mouseOverIndex] as TDisplayInfo;
                    if (displayInfo != null)
                    {
                        if (ClassTransactions.GetTransactions().Transactions.ContainsKey(displayInfo.ID))
                        {
                            TTransactionInfo info = ClassTransactions.GetTransactions().Transactions[displayInfo.ID];
                            if (!string.IsNullOrEmpty(info.m_Warning))
                            {
                                toolTip.SetToolTip(listBox, info.m_Warning.Replace(ClassTransactions.GOOD_NEWS, ""));
                                toolTip.Active = true;
                            }
                        }
                    }
                }
            }
        }

        public double GetPredictedBalanceAtSpecificDate(double soldeActuel, ref TPredictedBalance predictedBalance)
        {
            Dictionary<int, TTransactionInfo> transactions = ClassTransactions.GetTransactions().Transactions;
            predictedBalance.Incomes = ClassCalculation.CalculateTransactionsAtPredictionDate(transactions, ref predictedBalance, true);
            predictedBalance.Expenses = ClassCalculation.CalculateTransactionsAtPredictionDate(transactions, ref predictedBalance, false);

            #if (DEBUG)
            ClassValidateCalculations validations = new ClassValidateCalculations();
            string errorMsg;
            if (!validations.ValidateInfo(ClassTransactions.GetTransactions().Transactions, predictedBalance, out errorMsg))
            {
                if (!m_warningSent)
                {
                    MessageBox.Show("Erreur dans les calculs pour le solde du " + ClassTools.ConvertDateToString(predictedBalance.EndPredictionDate) + ": "  + errorMsg, "Attention");
                    m_warningSent = true;
                }
            }
            #endif

            double soldePredit = soldeActuel + predictedBalance.Incomes - predictedBalance.Expenses;
            soldePredit += predictedBalance.TotalPretsRemaining;

            return soldePredit;
        }

        private void FillUpPredictedBalances()
        {
            DateTime startDate = (DateTime.Now.Date >= CurrentStartPredictionDate.Date ? DateTime.Now : CurrentStartPredictionDate);

            TAnnualRepartitionInfo annualInfo = ComptaCharts.InitializeChartAnnuals(chartAnnuals, LocalSettings.BudgetYear, m_currentAccountId, false);

            double total = annualInfo.TotalIncomes + annualInfo.TotalExpenses;
            double surplus = annualInfo.TotalIncomes - annualInfo.TotalExpenses;

            double percentage = 0;
            if (total != 0)
                percentage = 100 * surplus / total;

            if (surplus >= 0)
            {
                labelAnnualProfits.Text = "Surplus annuel de ";
                labelAnnualProfits.ForeColor = Color.DarkGreen;
            }
            else
            {
                labelAnnualProfits.Text = "Pertes annuelles de ";
                labelAnnualProfits.ForeColor = Color.DarkRed;
            }
            labelAnnualProfits.Text += ClassTools.ConvertCurrencyToString(surplus) + " (" + ClassTools.ConvertDoubleToString(percentage) + "%)";
            
            double soldeActuel = Utils.ConvertToDouble(textBoxSoldeActuel0.Text.Trim());

            var in15Days = startDate.AddDays(15);

            ComptaCharts.InitializeChartPredictedBalances(this, chartPredictedBalances, startDate, in15Days, soldeActuel, EPeriodLength.e_PerDay);
        }
        
      
        private void AddHistorique()
        {
            // Historique
            List<THistoryInfo> histories = ClassHistory.GetHistory().HistoryInfo;

            if (histories != null)
            {
                foreach (THistoryInfo historyInfo in histories)
                {
                    if (historyInfo.m_PredictionDate == DateTime.MinValue)
                        historyInfo.m_PredictionDate = CurrentEndPredictionDate;
                    ListBoxHistorique5.Items.Add(TextFormatter.FormatHistorique(historyInfo));
                }
            }
        }

        private void DeleteHistorique()
        {
            List<THistoryInfo> histories = ClassHistory.GetHistory().HistoryInfo;
            List<THistoryInfo> newHistories = new List<THistoryInfo>();

            if (histories != null)
            {
                for (int i = 0; i < histories.Count; i++ )
                {
                    if (!ListBoxHistorique5.SelectedIndices.Contains(i))
                    {
                        newHistories.Add(histories[i]);
                    }
                }
                ClassHistory.GetHistory().HistoryInfo = newHistories;
                ClassHistory.GetHistory().SaveHistoryInDataStorage(CurrentAccountId);

                while (ListBoxHistorique5.SelectedIndices.Count > 0)
                    ListBoxHistorique5.Items.RemoveAt(ListBoxHistorique5.SelectedIndices[0]);
                if (ListBoxHistorique5.Items.Count > 0)
                    ListBoxHistorique5.SelectedIndex = 0;
            }
        }

        private void SaveHistoryInfo()
        {
            Dictionary<int, TAccountInfo> accounts = ClassAccounts.GetAccounts().AccountsInfo;

            if (accounts != null)
            {
                // Save history info
                foreach (TAccountInfo account in accounts.Values)
                {
                    bool bEntryAlreadyEntered = false;
                    ClassHistory.GetHistory().LoadHistoryFromDataStorage(account.AccountId);
                    List<THistoryInfo> histories = ClassHistory.GetHistory().HistoryInfo;

                    if (histories != null)
                    {
                        for (int j = 0; j < histories.Count; j++)
                        {
                            if (histories[j].m_HistoryDate.Date == DateTime.Today.Date)
                            {
                                THistoryInfo history = histories[j];
                                FillHistoryInfo(ref history, account);
                                histories[j] = history;
                                bEntryAlreadyEntered = true;
                            }
                        }
                        if (!bEntryAlreadyEntered)
                        {
                            THistoryInfo info = new THistoryInfo();
                            FillHistoryInfo(ref info, account);
                            histories.Add(info);
                            histories[histories.Count - 1].m_HistoryDate = DateTime.Today;
                        }
                        ClassHistory.GetHistory().SaveHistoryInDataStorage(account.AccountId);
                    }
                }
            }
        }

        private int GetSelectedTransIndex(Hashtable listIndexes, int listBoxIndex)
        {
            if (listIndexes.ContainsKey(listBoxIndex))
            {
                int transIndex = (int)listIndexes[listBoxIndex];
                Dictionary<int, TTransactionInfo> transactions = ClassTransactions.GetTransactions().Transactions;

                if (transIndex < transactions.Count)
                {
                    return transIndex;
                }
            }
            return -1;
        }

        private void FillHistoryInfo(ref THistoryInfo historyInfo, TAccountInfo info)
        {
            historyInfo.m_AccountId = info.AccountId;
            historyInfo.m_PredictionDate = info.PredictionDate;
         
            historyInfo.m_Incomes = info.IncomesAtPredictionDate - info.TransferIncomes;
            historyInfo.m_TransferIncomes = info.TransferIncomes;
            historyInfo.m_Expenses = info.ExpensesAtPredictionDate - info.TransferExpenses;
            historyInfo.m_TransferExpenses = info.TransferExpenses;
            historyInfo.m_AccountBalance = info.Balance;
        }

        private void SoldeActuelChanged()
        {
            try
            {
                int currentAccountId = GetSelectedAccountId();
                if (currentAccountId >= 0)
                {
                    if (ClassAccounts.GetAccounts().AccountsInfo.Count > 0 && currentAccountId >= 0)
                    {
                        Utils.SetResultFromFormula(textBoxSoldeActuel0);
                        textBoxSoldeActuel0.Text = "  " + textBoxSoldeActuel0.Text;
                        object tag = textBoxSoldeActuel0.Tag;

                        Exception exception;
                        TAccountInfo accountInfo = ClassAccounts.GetAccounts().AccountsInfo[currentAccountId];
                        accountInfo.Balance = Utils.ConvertToDouble(textBoxSoldeActuel0.Text.Trim());

                        ClassAccounts.GetAccounts().SaveAccountsInDataStorage(out exception);
                        if (exception != null)
                        {
                            MessageBox.Show(exception.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        FillUpControls();

                        textBoxSoldeActuel0.Tag = tag;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void PutItemUpInList(ListBox listBoxToReorder)
        {
            int selectedIndex = listBoxToReorder.SelectedIndex;
            if (listBoxToReorder.SelectedIndex <= 0)
                return;

            int listBoxIndex1 = listBoxToReorder.SelectedIndex;
            int listBoxIndex2 = listBoxToReorder.SelectedIndex - 1;

            InvertIDs(listBoxToReorder, listBoxIndex1, listBoxIndex2);

            listBoxToReorder.SelectedIndex = selectedIndex - 1;
            ClassTransactions.GetTransactions().SaveTransactionsInDataStorage();
        }

        private void PutItemDownInList(ListBox listBoxToReorder)
        {
            int selectedIndex = listBoxToReorder.SelectedIndex;
            if (selectedIndex >= listBoxToReorder.Items.Count-1)
                return;

            int listBoxIndex1 = listBoxToReorder.SelectedIndex;
            int listBoxIndex2 = listBoxToReorder.SelectedIndex + 1;

            InvertIDs(listBoxToReorder, listBoxIndex1, listBoxIndex2);

            listBoxToReorder.SelectedIndex = selectedIndex + 1;
            ClassTransactions.GetTransactions().SaveTransactionsInDataStorage();
        }

        private void InvertIDs(ListBox listBoxToReorder, int listBoxIndex1, int listBoxIndex2)
        {
            TDisplayInfo info1 = listBoxToReorder.Items[listBoxIndex1] as TDisplayInfo;
            TDisplayInfo info2 = listBoxToReorder.Items[listBoxIndex2] as TDisplayInfo;

            info1.OrderIndex = listBoxIndex2;
            info2.OrderIndex = listBoxIndex1;

            if (ClassTransactions.GetTransactions().Transactions.ContainsKey(info1.ID) && ClassTransactions.GetTransactions().Transactions.ContainsKey(info2.ID))
            {
                TTransactionInfo transInfo1 = ClassTransactions.GetTransactions().Transactions[info1.ID];
                TTransactionInfo transInfo2 = ClassTransactions.GetTransactions().Transactions[info2.ID];
                transInfo1.m_OrderID = listBoxIndex2;
                transInfo2.m_OrderID = listBoxIndex1;
            }
            listBoxToReorder.Items[listBoxIndex1] = info2;
            listBoxToReorder.Items[listBoxIndex2] = info1;
        }
        
        private void InitializeDisplayData()
        {
            UIControlsStruct incomeControls = new UIControlsStruct();

            incomeControls.TransactionListBox = ListBoxRevenus1;
            incomeControls.RadioButtonIsManual = radioButtonIsManual1;
            incomeControls.RadioButtonIsAutomatic = radioButtonIsAutomatic1;
            incomeControls.ComboBoxFirstTimeInMonth = comboBoxFirstTimeInMonth1;
            incomeControls.ComboBoxPeriodLength = comboBoxPeriodLength1;
            incomeControls.ComboBoxSecondTimeInMonth = comboBoxSecondTimeInMonth1;
            incomeControls.DateEnd = dateEnd1;
            incomeControls.DateStart = dateStart1;
            incomeControls.LabelAmount = labelAmount1;
            incomeControls.LabelBalance = labelBalance1;
            incomeControls.LabelWarning = labelWarning1;
            incomeControls.LabelDollar = labelDollar1;
            incomeControls.LabelEndDate = labelEndDate1;
            incomeControls.LabelFirstTimeInMonth = labelFirstTimeInMonth1;
            incomeControls.LabelPeriod = labelPeriod1;
            incomeControls.LabelSecondTimeInMonth = labelSecondTimeInMonth1;
            incomeControls.LabelStartDate = labelStartDate1;
            incomeControls.LabelFirstTimeInMonth = labelFirstTimeInMonth1;
            incomeControls.LabelPeriod = labelPeriod1;
            incomeControls.LabelSecondTimeInMonth = labelSecondTimeInMonth1;
            incomeControls.LabelStartDate = labelStartDate1;
            incomeControls.RadioOneShotTrans = radioOneShotTrans1;
            incomeControls.RadioPeriodicTrans = radioPeriodicTrans1;
            incomeControls.RadioTwoTimesInMonthTrans = radioTwoTimesInMonthTrans1;
            incomeControls.TextBoxAmount = textBoxAmount1;
            incomeControls.DataGridAmountAlreadyPayed = dataGridAmountAlreadyPayed1;
            incomeControls.TextBoxNotes = TextBoxNotes1;
            incomeControls.TextBoxPeriod = textBoxPeriod1;
            incomeControls.TextBoxTransactionName = textBoxTransactionName1;
            incomeControls.LabelTransactionName = labelTransactionName1;
            incomeControls.LabelNotes = labelNotes1;
            incomeControls.PanelBalanceAndButtons = panelBalanceAndButtons1;
            incomeControls.ButtonNewTransaction = buttonNewRevenu1;
            incomeControls.ButtonDeleteTransaction = buttonDelRevenu1;
            incomeControls.ButtonSaveTransaction = buttonSaveRevenu1;
            incomeControls.ButtonCancelTransaction = buttonIncomeCancel1;
            incomeControls.LabelCategory = labelCategory1;
            incomeControls.ComboBoxCategory = comboBoxCategory1;
            incomeControls.CheckBoxRemoveFromAnnualReport = checkBoxRemoveFromAnnualReport1;

            m_incomesDisplayData = new DisplayData(this, incomeControls, ListBoxRevenus1_SelectedIndexChanged, EType.e_Income);

            UIControlsStruct expenseControls = new UIControlsStruct();

            expenseControls.TransactionListBox = ListBoxDepenses2;
            expenseControls.RadioButtonIsManual = radioButtonIsManual2;
            expenseControls.RadioButtonIsAutomatic = radioButtonIsAutomatic2;
            expenseControls.ComboBoxFirstTimeInMonth = comboBoxFirstTimeInMonth2;
            expenseControls.ComboBoxPeriodLength = comboBoxPeriodLength2;
            expenseControls.ComboBoxSecondTimeInMonth = comboBoxSecondTimeInMonth2;
            expenseControls.DateEnd = dateEnd2;
            expenseControls.DateStart = dateStart2;
            expenseControls.LabelAmount = labelAmount2;
            expenseControls.LabelBalance = labelBalance2;
            expenseControls.LabelWarning = labelWarning2;
            expenseControls.LabelDollar = labelDollar2;
            expenseControls.LabelEndDate = labelEndDate2;
            expenseControls.LabelFirstTimeInMonth = labelFirstTimeInMonth2;
            expenseControls.LabelPeriod = labelPeriod2;
            expenseControls.LabelSecondTimeInMonth = labelSecondTimeInMonth2;
            expenseControls.LabelStartDate = labelStartDate2;
            expenseControls.LabelFirstTimeInMonth = labelFirstTimeInMonth2;
            expenseControls.LabelPeriod = labelPeriod2;
            expenseControls.LabelSecondTimeInMonth = labelSecondTimeInMonth2;
            expenseControls.LabelStartDate = labelStartDate2;
            expenseControls.RadioOneShotTrans = radioOneShotTrans2;
            expenseControls.RadioPeriodicTrans = radioPeriodicTrans2;
            expenseControls.RadioTwoTimesInMonthTrans = radioTwoTimesInMonthTrans2;
            expenseControls.TextBoxAmount = textBoxAmount2;
            expenseControls.DataGridAmountAlreadyPayed = dataGridAmountAlreadyPayed2;
            expenseControls.TextBoxNotes = TextBoxNotes2;
            expenseControls.TextBoxPeriod = textBoxPeriod2;
            expenseControls.TextBoxTransactionName = textBoxTransactionName2;
            expenseControls.LabelTransactionName = labelTransactionName2;
            expenseControls.LabelNotes = labelNotes2;
            expenseControls.PanelBalanceAndButtons = panelBalanceAndButtons2;
            expenseControls.ButtonNewTransaction = buttonNewDepense2;
            expenseControls.ButtonDeleteTransaction = buttonDelDepense2;
            expenseControls.ButtonSaveTransaction = buttonSaveDepense2;
            expenseControls.ButtonCancelTransaction = buttonExpenseCancel2;
            expenseControls.LabelCategory = labelCategory2;
            expenseControls.ComboBoxCategory = comboBoxCategory2;
            expenseControls.CheckBoxRemoveFromAnnualReport = checkBoxRemoveFromAnnualReport2;

            m_expensesDisplayData = new DisplayData(this, expenseControls, ListBoxDepenses2_SelectedIndexChanged, EType.e_Expense);
        }

        private int GetSelectedAccountId()
        {
            if (tabControlLeft.SelectedTab.Name == TAB_SUMMARY) // All accounts
                return -1;

            string accountName = tabControlLeft.SelectedTab.Name;
            if (accountName != null)
                return ClassAccounts.GetAccounts().GetAccountIdFromName(accountName.Trim());
            else 
            {
                // CGe add Error log
                return -1;
            }
        }

        #endregion

        public DateTime CurrentEndPredictionDate;
        public DateTime CurrentStartPredictionDate;
        private TabPage m_tabPageSolde;
        private TabPage m_tabPageIncomes;
        private TabPage m_tabPageExpenses;
        private TabPage m_tabPageHistorique;
        private TabPage m_tabPageLeftSummary;
                
        private const string TAB_SUMMARY = "tabPageLeftSummary";
        
        #if (DEBUG)
        private bool m_warningSent = false;
        #endif
    }
}
