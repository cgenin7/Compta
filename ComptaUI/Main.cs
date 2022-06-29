using System;
using System.Drawing;
using System.Collections;
using System.Security.Permissions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using System.Data;
using Comptability;
using ComptaCommun;
using ComptaDB;
using System.Reflection;
using System.IO;
using System.Drawing.Drawing2D;
using Compta.CustomControls;
using System.Threading;

// FormMain size : 1019;732
// Tab size : 994;679
// Tab position : 19;3
namespace Compta
{
	/// <summary>
	/// Summary description for FormMain.
	/// </summary>
    [System.ComponentModel.DesignerCategory("form")]
	public partial class FormMain : Form // CustomizedForm
	{
        #region Private Form variables

        private System.Windows.Forms.ImageList imageList;
        private TabControlEx tabControlLeft;
		private System.Windows.Forms.TabPage tabPageCompte1;
		private System.Windows.Forms.TabPage tabPageCompte3;
        private System.Windows.Forms.TabPage tabPageCompte2;
        private System.ComponentModel.IContainer components;
        private ToolTip toolTipRevenus1;
        private ToolTip toolTipExpenses2;
        private ToolTip toolTipToCome0;
        private ToolTip toolTipToComeIncome;
        private MenuStrip menuStripMain;
        private ToolStripMenuItem fichierToolStripMenuItem;
        private ToolStripMenuItem créerUnNouveauBudgetToolStripMenuItem;
        private ToolStripMenuItem quitterToolStripMenuItem;
        private ToolStripMenuItem comptesToolStripMenuItem;
        private ToolStripMenuItem ajouterUnCompteToolStripMenuItem;
        private ToolStripMenuItem renommerUnCompteToolStripMenuItem;
        private ToolStripMenuItem supprimerUnCompteToolStripMenuItem;
        private ToolTip toolTipPrets4;
        private ToolStripMenuItem toolStripMenuItem1;
        private TabPage tabPageHistorique;
        private Label labelTitleHistorique5;
        private Button buttonEffacer5;
        private ListBox ListBoxHistorique5;
        private TabPage tabPageDépenses;
        private CheckBox checkBoxRemoveFromAnnualReport2;
        private Label labelCategory2;
        private ComboBox comboBoxCategory2;
        private DataGridView dataGridAmountAlreadyPayed2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewCheckBoxColumn Complete;
        private TextBox textBoxPeriod2;
        private TextBox textBoxAmount2;
        private TextBox textBoxTransactionName2;
        private TextBox TextBoxNotes2;
        private Panel panel2;
        private RadioButton radioButtonIsAutomatic2;
        private RadioButton radioButtonIsManual2;
        private Button buttonDownExpenses;
        private Button buttonUpExpenses;
        private Label labelTotalExpenses;
        private Label labelTitleDépenses2;
        private Label labelDollar2;
        private Label labelNotes2;
        private ComboBox comboBoxPeriodLength2;
        private ComboBox comboBoxFirstTimeInMonth2;
        private Label labelAmount2;
        private Label labelTransactionName2;
        private DateTimePicker dateEnd2;
        private DateTimePicker dateStart2;
        private Label labelEndDate2;
        private Label labelStartDate2;
        private RadioButton radioTwoTimesInMonthTrans2;
        private RadioButton radioPeriodicTrans2;
        private RadioButton radioOneShotTrans2;
        private Button buttonNewDepense2;
        private ListBox ListBoxDepenses2;
        private Label labelPeriod2;
        private Panel panelBalanceAndButtons2;
        private Label labelWarning2;
        private Label labelBalance2;
        private Button buttonSaveDepense2;
        private Button buttonExpenseCancel2;
        private Button buttonDelDepense2;
        private ComboBox comboBoxSecondTimeInMonth2;
        private Label labelFirstTimeInMonth2;
        private Label labelSecondTimeInMonth2;
        private TabPage tabPageRevenus;
        private CheckBox checkBoxRemoveFromAnnualReport1;
        private Label labelCategory1;
        private ComboBox comboBoxCategory1;
        private Panel panelBalanceAndButtons1;
        private Label labelWarning1;
        private Label labelBalance1;
        private Button buttonSaveRevenu1;
        private Button buttonDelRevenu1;
        private Button buttonIncomeCancel1;
        private DataGridView dataGridAmountAlreadyPayed1;
        private DataGridViewTextBoxColumn TestDate;
        private DataGridViewTextBoxColumn TestValue;
        private DataGridViewCheckBoxColumn Completed;
        private TextBox textBoxPeriod1;
        private TextBox textBoxAmount1;
        private TextBox textBoxTransactionName1;
        private TextBox TextBoxNotes1;
        private ListBox ListBoxRevenus1;
        private Panel panel1;
        private RadioButton radioButtonIsAutomatic1;
        private RadioButton radioButtonIsManual1;
        private Button buttonDownIncome;
        private Button buttonUpIncome;
        private Label labelRevenuTotal;
        private Label labelNotes1;
        private Label labelTitleRevenus1;
        private Label labelDollar1;
        private ComboBox comboBoxPeriodLength1;
        private ComboBox comboBoxSecondTimeInMonth1;
        private ComboBox comboBoxFirstTimeInMonth1;
        private Label labelSecondTimeInMonth1;
        private Label labelFirstTimeInMonth1;
        private Label labelAmount1;
        private Label labelTransactionName1;
        private DateTimePicker dateEnd1;
        private DateTimePicker dateStart1;
        private Label labelEndDate1;
        private Label labelStartDate1;
        private RadioButton radioTwoTimesInMonthTrans1;
        private RadioButton radioPeriodicTrans1;
        private RadioButton radioOneShotTrans1;
        private Button buttonNewRevenu1;
        private Label labelPeriod1;
        private TabPage tabPageSolde;
        private ListBoxSortedByDate listBoxToComeExpense;
        private TextBox TextBoxNotes0;
        private TextBox textBox1;
        private TextBox textBoxSoldesPredits;
        private TextBox textBoxSoldeActuel0;
        private Button buttonMaximizeChart;
        private Label labelAnnualProfits;
        private ComboBox comboBoxBudgetName;
        private Label labelBudgetYear;
        private Label labelPredictedBalance0;
        private Label labelNotes0;
        private Label labelAVenir;
        private Label labelDollar0;
        private Label labelSoldeActuel0;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPredictedBalances;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnnuals;
        private TabControlEx tabControlMain;
        private TabPage tabPageLeftSummary;
        private Label labelPredictedDate0;
        private ListBoxSortedByDate listBoxToComeIncome;
        private Label label1;
        private ToolStripMenuItem aProposToolStripMenuItem;


        #endregion

        public FormMain()
        {
            InitializeComponent();

            LocalSettings.UIDirectory = Environment.CurrentDirectory;
            LocalSettings.LoadLocalSettings();

            try
            {
                InitializeDisplayData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }

            menuStripMain.Paint += new PaintEventHandler(menuStripMain_Paint);
            menuStripMain.RenderMode = ToolStripRenderMode.Professional;
            menuStripMain.Renderer = new ToolStripProfessionalRenderer(new CustomProfessionalColors());

            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("Impossible d'ouvrir deux fois le logiciel.");
            }
        }

        private int m_incomesMouseOverIndex = -1;
        private int m_expensesMouseOverIndex = -1;
        private int m_toComeMouseOverIndex = -1;
        private int m_lastTabControlIndex = -1;

        #region General Events

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            try
            {
                File.Copy(LocalSettings.DatabasePath, LocalSettings.DatabaseBackupPath, true);

                SelectAccount accountForm = new SelectAccount(LocalSettings.DatabaseName);
                if (accountForm.ShowDialog(this) == DialogResult.OK)
                    LocalSettings.DatabaseName = accountForm.DatabaseName;
                else
                    Close();

                m_tabPageLeftSummary = tabControlLeft.TabPages[TAB_SUMMARY];
                m_tabPageSolde = tabControlMain.TabPages["tabPageSolde"];
                m_tabPageIncomes = tabControlMain.TabPages["tabPageRevenus"];
                m_tabPageExpenses = tabControlMain.TabPages["tabPageDépenses"];
                m_tabPageHistorique = tabControlMain.TabPages["tabPageHistorique"];

                if (!File.Exists(LocalSettings.DatabasePath))
                    System.IO.File.Copy(ClassTools.GetConfigDir() + "EmptyBudget.mdb", LocalSettings.DatabasePath, false);

                comboBoxBudgetName.SelectedIndexChanged -= new System.EventHandler(this.comboBoxBudgetYear_SelectedIndexChanged);
                Utils.FillComboBudgetName(comboBoxBudgetName);
                comboBoxBudgetName.SelectedIndexChanged += new System.EventHandler(this.comboBoxBudgetYear_SelectedIndexChanged);

                LoadInfoFromDatabase(false, true);
                AdjustTabs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Voulez vous sauvegarder vos changement?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    LocalSettings.SaveLocalSettings();
                    SaveHistoryInfo();
                }
                else
                {
                    File.Copy(LocalSettings.DatabaseBackupPath, LocalSettings.DatabasePath, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = (Exception)e.Exception;
            MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            Application.Exit();
        }

        void menuStripMain_Paint(object sender, PaintEventArgs e)
        {
            Brush myBrush = new LinearGradientBrush(e.ClipRectangle, ControlPaint.Light(CustomColors.DarkGrey), ControlPaint.LightLight(CustomColors.LightGrey), LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(myBrush, e.ClipRectangle);
        }

	    /// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

        /*
		MonthlyPaiement = amountToPay x interestRatePerMonth / (1 – (1 + interestRatePerMonth)exp(–nbMonths))
		 */
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 150D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, -30D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabPageCompte1 = new System.Windows.Forms.TabPage();
            this.tabPageCompte3 = new System.Windows.Forms.TabPage();
            this.tabPageCompte2 = new System.Windows.Forms.TabPage();
            this.toolTipRevenus1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipExpenses2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipToCome0 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipToComeIncome = new System.Windows.Forms.ToolTip(this.components);
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.créerUnNouveauBudgetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comptesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnCompteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renommerUnCompteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerUnCompteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipPrets4 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlMain = new Compta.CustomControls.TabControlEx();
            this.tabPageSolde = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxToComeIncome = new Compta.ListBoxSortedByDate();
            this.listBoxToComeExpense = new Compta.ListBoxSortedByDate();
            this.TextBoxNotes0 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxSoldesPredits = new System.Windows.Forms.TextBox();
            this.textBoxSoldeActuel0 = new System.Windows.Forms.TextBox();
            this.buttonMaximizeChart = new System.Windows.Forms.Button();
            this.labelAnnualProfits = new System.Windows.Forms.Label();
            this.comboBoxBudgetName = new System.Windows.Forms.ComboBox();
            this.labelBudgetYear = new System.Windows.Forms.Label();
            this.labelPredictedBalance0 = new System.Windows.Forms.Label();
            this.labelPredictedDate0 = new System.Windows.Forms.Label();
            this.labelNotes0 = new System.Windows.Forms.Label();
            this.labelAVenir = new System.Windows.Forms.Label();
            this.labelDollar0 = new System.Windows.Forms.Label();
            this.labelSoldeActuel0 = new System.Windows.Forms.Label();
            this.chartPredictedBalances = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAnnuals = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPageRevenus = new System.Windows.Forms.TabPage();
            this.checkBoxRemoveFromAnnualReport1 = new System.Windows.Forms.CheckBox();
            this.labelCategory1 = new System.Windows.Forms.Label();
            this.comboBoxCategory1 = new System.Windows.Forms.ComboBox();
            this.panelBalanceAndButtons1 = new System.Windows.Forms.Panel();
            this.labelWarning1 = new System.Windows.Forms.Label();
            this.labelBalance1 = new System.Windows.Forms.Label();
            this.buttonSaveRevenu1 = new System.Windows.Forms.Button();
            this.buttonDelRevenu1 = new System.Windows.Forms.Button();
            this.buttonIncomeCancel1 = new System.Windows.Forms.Button();
            this.dataGridAmountAlreadyPayed1 = new System.Windows.Forms.DataGridView();
            this.TestDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Completed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBoxPeriod1 = new System.Windows.Forms.TextBox();
            this.textBoxAmount1 = new System.Windows.Forms.TextBox();
            this.textBoxTransactionName1 = new System.Windows.Forms.TextBox();
            this.TextBoxNotes1 = new System.Windows.Forms.TextBox();
            this.ListBoxRevenus1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonIsAutomatic1 = new System.Windows.Forms.RadioButton();
            this.radioButtonIsManual1 = new System.Windows.Forms.RadioButton();
            this.buttonDownIncome = new System.Windows.Forms.Button();
            this.buttonUpIncome = new System.Windows.Forms.Button();
            this.labelRevenuTotal = new System.Windows.Forms.Label();
            this.labelNotes1 = new System.Windows.Forms.Label();
            this.labelTitleRevenus1 = new System.Windows.Forms.Label();
            this.labelDollar1 = new System.Windows.Forms.Label();
            this.comboBoxPeriodLength1 = new System.Windows.Forms.ComboBox();
            this.labelFirstTimeInMonth1 = new System.Windows.Forms.Label();
            this.labelAmount1 = new System.Windows.Forms.Label();
            this.labelTransactionName1 = new System.Windows.Forms.Label();
            this.dateEnd1 = new System.Windows.Forms.DateTimePicker();
            this.dateStart1 = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate1 = new System.Windows.Forms.Label();
            this.labelStartDate1 = new System.Windows.Forms.Label();
            this.radioTwoTimesInMonthTrans1 = new System.Windows.Forms.RadioButton();
            this.radioPeriodicTrans1 = new System.Windows.Forms.RadioButton();
            this.radioOneShotTrans1 = new System.Windows.Forms.RadioButton();
            this.buttonNewRevenu1 = new System.Windows.Forms.Button();
            this.comboBoxSecondTimeInMonth1 = new System.Windows.Forms.ComboBox();
            this.labelPeriod1 = new System.Windows.Forms.Label();
            this.labelSecondTimeInMonth1 = new System.Windows.Forms.Label();
            this.comboBoxFirstTimeInMonth1 = new System.Windows.Forms.ComboBox();
            this.tabPageDépenses = new System.Windows.Forms.TabPage();
            this.checkBoxRemoveFromAnnualReport2 = new System.Windows.Forms.CheckBox();
            this.labelCategory2 = new System.Windows.Forms.Label();
            this.comboBoxCategory2 = new System.Windows.Forms.ComboBox();
            this.dataGridAmountAlreadyPayed2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Complete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBoxPeriod2 = new System.Windows.Forms.TextBox();
            this.textBoxAmount2 = new System.Windows.Forms.TextBox();
            this.textBoxTransactionName2 = new System.Windows.Forms.TextBox();
            this.TextBoxNotes2 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonIsAutomatic2 = new System.Windows.Forms.RadioButton();
            this.radioButtonIsManual2 = new System.Windows.Forms.RadioButton();
            this.buttonDownExpenses = new System.Windows.Forms.Button();
            this.buttonUpExpenses = new System.Windows.Forms.Button();
            this.labelTotalExpenses = new System.Windows.Forms.Label();
            this.labelTitleDépenses2 = new System.Windows.Forms.Label();
            this.labelDollar2 = new System.Windows.Forms.Label();
            this.labelNotes2 = new System.Windows.Forms.Label();
            this.comboBoxPeriodLength2 = new System.Windows.Forms.ComboBox();
            this.labelAmount2 = new System.Windows.Forms.Label();
            this.labelTransactionName2 = new System.Windows.Forms.Label();
            this.dateEnd2 = new System.Windows.Forms.DateTimePicker();
            this.dateStart2 = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate2 = new System.Windows.Forms.Label();
            this.labelStartDate2 = new System.Windows.Forms.Label();
            this.radioTwoTimesInMonthTrans2 = new System.Windows.Forms.RadioButton();
            this.radioPeriodicTrans2 = new System.Windows.Forms.RadioButton();
            this.radioOneShotTrans2 = new System.Windows.Forms.RadioButton();
            this.buttonNewDepense2 = new System.Windows.Forms.Button();
            this.ListBoxDepenses2 = new System.Windows.Forms.ListBox();
            this.labelPeriod2 = new System.Windows.Forms.Label();
            this.panelBalanceAndButtons2 = new System.Windows.Forms.Panel();
            this.labelWarning2 = new System.Windows.Forms.Label();
            this.labelBalance2 = new System.Windows.Forms.Label();
            this.buttonSaveDepense2 = new System.Windows.Forms.Button();
            this.buttonExpenseCancel2 = new System.Windows.Forms.Button();
            this.buttonDelDepense2 = new System.Windows.Forms.Button();
            this.labelFirstTimeInMonth2 = new System.Windows.Forms.Label();
            this.labelSecondTimeInMonth2 = new System.Windows.Forms.Label();
            this.comboBoxFirstTimeInMonth2 = new System.Windows.Forms.ComboBox();
            this.comboBoxSecondTimeInMonth2 = new System.Windows.Forms.ComboBox();
            this.tabPageHistorique = new System.Windows.Forms.TabPage();
            this.labelTitleHistorique5 = new System.Windows.Forms.Label();
            this.buttonEffacer5 = new System.Windows.Forms.Button();
            this.ListBoxHistorique5 = new System.Windows.Forms.ListBox();
            this.tabControlLeft = new Compta.CustomControls.TabControlEx();
            this.tabPageLeftSummary = new System.Windows.Forms.TabPage();
            this.menuStripMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageSolde.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPredictedBalances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnnuals)).BeginInit();
            this.tabPageRevenus.SuspendLayout();
            this.panelBalanceAndButtons1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAmountAlreadyPayed1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPageDépenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAmountAlreadyPayed2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelBalanceAndButtons2.SuspendLayout();
            this.tabPageHistorique.SuspendLayout();
            this.tabControlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            // 
            // tabPageCompte1
            // 
            this.tabPageCompte1.Location = new System.Drawing.Point(0, 0);
            this.tabPageCompte1.Name = "tabPageCompte1";
            this.tabPageCompte1.Size = new System.Drawing.Size(200, 100);
            this.tabPageCompte1.TabIndex = 0;
            // 
            // tabPageCompte3
            // 
            this.tabPageCompte3.Location = new System.Drawing.Point(0, 0);
            this.tabPageCompte3.Name = "tabPageCompte3";
            this.tabPageCompte3.Size = new System.Drawing.Size(200, 100);
            this.tabPageCompte3.TabIndex = 0;
            // 
            // tabPageCompte2
            // 
            this.tabPageCompte2.Location = new System.Drawing.Point(0, 0);
            this.tabPageCompte2.Name = "tabPageCompte2";
            this.tabPageCompte2.Size = new System.Drawing.Size(200, 100);
            this.tabPageCompte2.TabIndex = 0;
            // 
            // menuStripMain
            // 
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.comptesToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStripMain.Size = new System.Drawing.Size(1518, 24);
            this.menuStripMain.TabIndex = 4;
            this.menuStripMain.Text = "menuStrip1";
            this.menuStripMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStripMain_ItemClicked);
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.créerUnNouveauBudgetToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // créerUnNouveauBudgetToolStripMenuItem
            // 
            this.créerUnNouveauBudgetToolStripMenuItem.Name = "créerUnNouveauBudgetToolStripMenuItem";
            this.créerUnNouveauBudgetToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.créerUnNouveauBudgetToolStripMenuItem.Text = "Créer un nouveau budget ...";
            this.créerUnNouveauBudgetToolStripMenuItem.Click += new System.EventHandler(this.créerUnNouveauBudgetToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // comptesToolStripMenuItem
            // 
            this.comptesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUnCompteToolStripMenuItem,
            this.renommerUnCompteToolStripMenuItem,
            this.supprimerUnCompteToolStripMenuItem});
            this.comptesToolStripMenuItem.Name = "comptesToolStripMenuItem";
            this.comptesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.comptesToolStripMenuItem.Text = "Comptes";
            // 
            // ajouterUnCompteToolStripMenuItem
            // 
            this.ajouterUnCompteToolStripMenuItem.Name = "ajouterUnCompteToolStripMenuItem";
            this.ajouterUnCompteToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.ajouterUnCompteToolStripMenuItem.Text = "Ajouter un compte";
            this.ajouterUnCompteToolStripMenuItem.Click += new System.EventHandler(this.ajouterUnCompteToolStripMenuItem_Click);
            // 
            // renommerUnCompteToolStripMenuItem
            // 
            this.renommerUnCompteToolStripMenuItem.Name = "renommerUnCompteToolStripMenuItem";
            this.renommerUnCompteToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.renommerUnCompteToolStripMenuItem.Text = "Renommer un compte";
            this.renommerUnCompteToolStripMenuItem.Click += new System.EventHandler(this.renommerUnCompteToolStripMenuItem_Click);
            // 
            // supprimerUnCompteToolStripMenuItem
            // 
            this.supprimerUnCompteToolStripMenuItem.Name = "supprimerUnCompteToolStripMenuItem";
            this.supprimerUnCompteToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.supprimerUnCompteToolStripMenuItem.Text = "Supprimer un compte";
            this.supprimerUnCompteToolStripMenuItem.Click += new System.EventHandler(this.supprimerUnCompteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aProposToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.aProposToolStripMenuItem.Text = "A propos ...";
            this.aProposToolStripMenuItem.Click += new System.EventHandler(this.aProposToolStripMenuItem_Click);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageSolde);
            this.tabControlMain.Controls.Add(this.tabPageRevenus);
            this.tabControlMain.Controls.Add(this.tabPageDépenses);
            this.tabControlMain.Controls.Add(this.tabPageHistorique);
            this.tabControlMain.Location = new System.Drawing.Point(19, 24);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.ShowToolTips = true;
            this.tabControlMain.Size = new System.Drawing.Size(1505, 774);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageSolde
            // 
            this.tabPageSolde.AutoScroll = true;
            this.tabPageSolde.AutoScrollMinSize = new System.Drawing.Size(1225, 650);
            this.tabPageSolde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.tabPageSolde.Controls.Add(this.label1);
            this.tabPageSolde.Controls.Add(this.listBoxToComeIncome);
            this.tabPageSolde.Controls.Add(this.listBoxToComeExpense);
            this.tabPageSolde.Controls.Add(this.TextBoxNotes0);
            this.tabPageSolde.Controls.Add(this.textBox1);
            this.tabPageSolde.Controls.Add(this.textBoxSoldesPredits);
            this.tabPageSolde.Controls.Add(this.textBoxSoldeActuel0);
            this.tabPageSolde.Controls.Add(this.buttonMaximizeChart);
            this.tabPageSolde.Controls.Add(this.labelAnnualProfits);
            this.tabPageSolde.Controls.Add(this.comboBoxBudgetName);
            this.tabPageSolde.Controls.Add(this.labelBudgetYear);
            this.tabPageSolde.Controls.Add(this.labelPredictedBalance0);
            this.tabPageSolde.Controls.Add(this.labelPredictedDate0);
            this.tabPageSolde.Controls.Add(this.labelNotes0);
            this.tabPageSolde.Controls.Add(this.labelAVenir);
            this.tabPageSolde.Controls.Add(this.labelDollar0);
            this.tabPageSolde.Controls.Add(this.labelSoldeActuel0);
            this.tabPageSolde.Controls.Add(this.chartPredictedBalances);
            this.tabPageSolde.Controls.Add(this.chartAnnuals);
            this.tabPageSolde.Location = new System.Drawing.Point(4, 22);
            this.tabPageSolde.Name = "tabPageSolde";
            this.tabPageSolde.Size = new System.Drawing.Size(1497, 748);
            this.tabPageSolde.TabIndex = 0;
            this.tabPageSolde.Text = "Solde des comptes";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 23);
            this.label1.TabIndex = 141;
            this.label1.Text = "Revenus d\'ici 2 semaines";
            // 
            // listBoxToComeIncome
            // 
            this.listBoxToComeIncome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxToComeIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.listBoxToComeIncome.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxToComeIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxToComeIncome.FormattingEnabled = true;
            this.listBoxToComeIncome.ItemHeight = 16;
            this.listBoxToComeIncome.Location = new System.Drawing.Point(15, 440);
            this.listBoxToComeIncome.MinimumSize = new System.Drawing.Size(531, 148);
            this.listBoxToComeIncome.Name = "listBoxToComeIncome";
            this.listBoxToComeIncome.Size = new System.Drawing.Size(760, 148);
            this.listBoxToComeIncome.TabIndex = 140;
            this.listBoxToComeIncome.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxToComeIncome_DrawItem);
            this.listBoxToComeIncome.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxToComeIncome_MouseDoubleClick);
            this.listBoxToComeIncome.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxToComeIncome_MouseMove);
            // 
            // listBoxToComeExpense
            // 
            this.listBoxToComeExpense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxToComeExpense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.listBoxToComeExpense.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxToComeExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxToComeExpense.FormattingEnabled = true;
            this.listBoxToComeExpense.ItemHeight = 16;
            this.listBoxToComeExpense.Location = new System.Drawing.Point(15, 250);
            this.listBoxToComeExpense.MinimumSize = new System.Drawing.Size(531, 148);
            this.listBoxToComeExpense.Name = "listBoxToComeExpense";
            this.listBoxToComeExpense.Size = new System.Drawing.Size(760, 148);
            this.listBoxToComeExpense.TabIndex = 8;
            this.listBoxToComeExpense.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxToCome0_DrawItem);
            this.listBoxToComeExpense.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxToCome0_MouseDoubleClick);
            this.listBoxToComeExpense.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxToCome0_MouseMove);
            // 
            // TextBoxNotes0
            // 
            this.TextBoxNotes0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxNotes0.BackColor = System.Drawing.Color.White;
            this.TextBoxNotes0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxNotes0.Location = new System.Drawing.Point(15, 625);
            this.TextBoxNotes0.Multiline = true;
            this.TextBoxNotes0.Name = "TextBoxNotes0";
            this.TextBoxNotes0.Size = new System.Drawing.Size(785, 107);
            this.TextBoxNotes0.TabIndex = 10;
            this.TextBoxNotes0.TextChanged += new System.EventHandler(this.TextBoxNotes0_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(809, 250);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 22);
            this.textBox1.TabIndex = 136;
            this.textBox1.Text = "Répartition annuelle:";
            // 
            // textBoxSoldesPredits
            // 
            this.textBoxSoldesPredits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSoldesPredits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.textBoxSoldesPredits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSoldesPredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSoldesPredits.Location = new System.Drawing.Point(735, 14);
            this.textBoxSoldesPredits.Multiline = true;
            this.textBoxSoldesPredits.Name = "textBoxSoldesPredits";
            this.textBoxSoldesPredits.Size = new System.Drawing.Size(709, 18);
            this.textBoxSoldesPredits.TabIndex = 120;
            this.textBoxSoldesPredits.Text = "Soldes prédits:";
            this.textBoxSoldesPredits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSoldeActuel0
            // 
            this.textBoxSoldeActuel0.BackColor = System.Drawing.Color.White;
            this.textBoxSoldeActuel0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSoldeActuel0.Location = new System.Drawing.Point(212, 39);
            this.textBoxSoldeActuel0.Name = "textBoxSoldeActuel0";
            this.textBoxSoldeActuel0.Size = new System.Drawing.Size(124, 22);
            this.textBoxSoldeActuel0.TabIndex = 4;
            this.textBoxSoldeActuel0.Text = "  0";
            this.textBoxSoldeActuel0.GotFocus += new System.EventHandler(this.textBoxSoldeActuel0_GotFocus);
            this.textBoxSoldeActuel0.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSoldeActuel0_KeyUp);
            this.textBoxSoldeActuel0.LostFocus += new System.EventHandler(this.textBoxSoldeActuel0_LostFocus);
            // 
            // buttonMaximizeChart
            // 
            this.buttonMaximizeChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMaximizeChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMaximizeChart.Location = new System.Drawing.Point(1178, 652);
            this.buttonMaximizeChart.Name = "buttonMaximizeChart";
            this.buttonMaximizeChart.Size = new System.Drawing.Size(25, 25);
            this.buttonMaximizeChart.TabIndex = 139;
            this.buttonMaximizeChart.Text = "+";
            this.buttonMaximizeChart.UseVisualStyleBackColor = true;
            this.buttonMaximizeChart.Click += new System.EventHandler(this.buttonMaximizeChart_Click);
            // 
            // labelAnnualProfits
            // 
            this.labelAnnualProfits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAnnualProfits.BackColor = System.Drawing.Color.Transparent;
            this.labelAnnualProfits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAnnualProfits.ForeColor = System.Drawing.Color.Green;
            this.labelAnnualProfits.Location = new System.Drawing.Point(815, 708);
            this.labelAnnualProfits.Name = "labelAnnualProfits";
            this.labelAnnualProfits.Size = new System.Drawing.Size(413, 16);
            this.labelAnnualProfits.TabIndex = 138;
            this.labelAnnualProfits.Text = "Surplus annuel de 400 $ (3%).";
            this.labelAnnualProfits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxBudgetName
            // 
            this.comboBoxBudgetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBudgetName.FormattingEnabled = true;
            this.comboBoxBudgetName.Location = new System.Drawing.Point(212, 39);
            this.comboBoxBudgetName.Name = "comboBoxBudgetName";
            this.comboBoxBudgetName.Size = new System.Drawing.Size(144, 24);
            this.comboBoxBudgetName.TabIndex = 3;
            // 
            // labelBudgetYear
            // 
            this.labelBudgetYear.AutoSize = true;
            this.labelBudgetYear.BackColor = System.Drawing.Color.Transparent;
            this.labelBudgetYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBudgetYear.Location = new System.Drawing.Point(23, 45);
            this.labelBudgetYear.Name = "labelBudgetYear";
            this.labelBudgetYear.Size = new System.Drawing.Size(60, 16);
            this.labelBudgetYear.TabIndex = 132;
            this.labelBudgetYear.Text = "Budget:";
            this.labelBudgetYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPredictedBalance0
            // 
            this.labelPredictedBalance0.AutoSize = true;
            this.labelPredictedBalance0.BackColor = System.Drawing.Color.Transparent;
            this.labelPredictedBalance0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPredictedBalance0.ForeColor = System.Drawing.Color.Green;
            this.labelPredictedBalance0.Location = new System.Drawing.Point(209, 79);
            this.labelPredictedBalance0.Name = "labelPredictedBalance0";
            this.labelPredictedBalance0.Size = new System.Drawing.Size(27, 16);
            this.labelPredictedBalance0.TabIndex = 5;
            this.labelPredictedBalance0.Text = "0 $";
            // 
            // labelPredictedDate0
            // 
            this.labelPredictedDate0.AutoSize = true;
            this.labelPredictedDate0.BackColor = System.Drawing.Color.Transparent;
            this.labelPredictedDate0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPredictedDate0.Location = new System.Drawing.Point(23, 79);
            this.labelPredictedDate0.Name = "labelPredictedDate0";
            this.labelPredictedDate0.Size = new System.Drawing.Size(179, 16);
            this.labelPredictedDate0.TabIndex = 129;
            this.labelPredictedDate0.Text = "Solde à la fin de l\'année:";
            this.labelPredictedDate0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNotes0
            // 
            this.labelNotes0.BackColor = System.Drawing.Color.Transparent;
            this.labelNotes0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotes0.Location = new System.Drawing.Point(24, 599);
            this.labelNotes0.Name = "labelNotes0";
            this.labelNotes0.Size = new System.Drawing.Size(96, 23);
            this.labelNotes0.TabIndex = 18;
            this.labelNotes0.Text = "Notes";
            // 
            // labelAVenir
            // 
            this.labelAVenir.BackColor = System.Drawing.Color.Transparent;
            this.labelAVenir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAVenir.Location = new System.Drawing.Point(24, 224);
            this.labelAVenir.Name = "labelAVenir";
            this.labelAVenir.Size = new System.Drawing.Size(271, 23);
            this.labelAVenir.TabIndex = 16;
            this.labelAVenir.Text = "Dépenses d\'ici 2 semaines";
            this.labelAVenir.Click += new System.EventHandler(this.labelAVenir_Click);
            // 
            // labelDollar0
            // 
            this.labelDollar0.BackColor = System.Drawing.Color.Transparent;
            this.labelDollar0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDollar0.Location = new System.Drawing.Point(342, 43);
            this.labelDollar0.Name = "labelDollar0";
            this.labelDollar0.Size = new System.Drawing.Size(14, 16);
            this.labelDollar0.TabIndex = 2;
            this.labelDollar0.Text = "$";
            // 
            // labelSoldeActuel0
            // 
            this.labelSoldeActuel0.AutoSize = true;
            this.labelSoldeActuel0.BackColor = System.Drawing.Color.Transparent;
            this.labelSoldeActuel0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSoldeActuel0.Location = new System.Drawing.Point(23, 44);
            this.labelSoldeActuel0.Name = "labelSoldeActuel0";
            this.labelSoldeActuel0.Size = new System.Drawing.Size(174, 16);
            this.labelSoldeActuel0.TabIndex = 0;
            this.labelSoldeActuel0.Text = "Solde actuel du compte:";
            this.labelSoldeActuel0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chartPredictedBalances
            // 
            this.chartPredictedBalances.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chartPredictedBalances.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.LabelStyle.Angle = 90;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.Interval = 1D;
            chartArea1.AxisX.LabelStyle.IntervalOffset = 1D;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.LabelStyle.Format = "C0";
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            chartArea1.Name = "ChartArea1";
            this.chartPredictedBalances.ChartAreas.Add(chartArea1);
            this.chartPredictedBalances.Location = new System.Drawing.Point(549, 26);
            this.chartPredictedBalances.Margin = new System.Windows.Forms.Padding(0);
            this.chartPredictedBalances.MinimumSize = new System.Drawing.Size(664, 211);
            this.chartPredictedBalances.Name = "chartPredictedBalances";
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "MaxPixelPointWidth=10, LabelStyle=Top, DrawingStyle=Cylinder";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelBackColor = System.Drawing.Color.Transparent;
            series1.Name = "Series1";
            dataPoint1.Color = System.Drawing.Color.Green;
            dataPoint1.LabelBackColor = System.Drawing.Color.White;
            dataPoint2.Color = System.Drawing.Color.Red;
            dataPoint2.LabelBackColor = System.Drawing.Color.White;
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.SmartLabelStyle.Enabled = false;
            series1.SmartLabelStyle.MovingDirection = ((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles)(((((((((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Top | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Bottom) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Right) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Left) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopLeft) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopRight) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomLeft) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomRight) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Center)));
            this.chartPredictedBalances.Series.Add(series1);
            this.chartPredictedBalances.Size = new System.Drawing.Size(906, 211);
            this.chartPredictedBalances.TabIndex = 135;
            this.chartPredictedBalances.Text = "chart1";
            this.chartPredictedBalances.Click += new System.EventHandler(this.chartPredictedBalances_Click);
            // 
            // chartAnnuals
            // 
            this.chartAnnuals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chartAnnuals.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 60F;
            this.chartAnnuals.ChartAreas.Add(chartArea2);
            this.chartAnnuals.Location = new System.Drawing.Point(809, 276);
            this.chartAnnuals.Margin = new System.Windows.Forms.Padding(0);
            this.chartAnnuals.MinimumSize = new System.Drawing.Size(655, 394);
            this.chartAnnuals.Name = "chartAnnuals";
            this.chartAnnuals.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Color = System.Drawing.Color.Transparent;
            series2.Name = "Series1";
            series2.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.No;
            series2.SmartLabelStyle.MaxMovingDistance = 0D;
            this.chartAnnuals.Series.Add(series2);
            this.chartAnnuals.Size = new System.Drawing.Size(655, 429);
            this.chartAnnuals.TabIndex = 134;
            this.chartAnnuals.Text = "chart1";
            this.chartAnnuals.Click += new System.EventHandler(this.chartAnnuals_Click);
            // 
            // tabPageRevenus
            // 
            this.tabPageRevenus.AutoScroll = true;
            this.tabPageRevenus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.tabPageRevenus.Controls.Add(this.checkBoxRemoveFromAnnualReport1);
            this.tabPageRevenus.Controls.Add(this.labelCategory1);
            this.tabPageRevenus.Controls.Add(this.comboBoxCategory1);
            this.tabPageRevenus.Controls.Add(this.panelBalanceAndButtons1);
            this.tabPageRevenus.Controls.Add(this.dataGridAmountAlreadyPayed1);
            this.tabPageRevenus.Controls.Add(this.textBoxPeriod1);
            this.tabPageRevenus.Controls.Add(this.textBoxAmount1);
            this.tabPageRevenus.Controls.Add(this.textBoxTransactionName1);
            this.tabPageRevenus.Controls.Add(this.TextBoxNotes1);
            this.tabPageRevenus.Controls.Add(this.ListBoxRevenus1);
            this.tabPageRevenus.Controls.Add(this.panel1);
            this.tabPageRevenus.Controls.Add(this.buttonDownIncome);
            this.tabPageRevenus.Controls.Add(this.buttonUpIncome);
            this.tabPageRevenus.Controls.Add(this.labelRevenuTotal);
            this.tabPageRevenus.Controls.Add(this.labelNotes1);
            this.tabPageRevenus.Controls.Add(this.labelTitleRevenus1);
            this.tabPageRevenus.Controls.Add(this.labelDollar1);
            this.tabPageRevenus.Controls.Add(this.comboBoxPeriodLength1);
            this.tabPageRevenus.Controls.Add(this.labelFirstTimeInMonth1);
            this.tabPageRevenus.Controls.Add(this.labelAmount1);
            this.tabPageRevenus.Controls.Add(this.labelTransactionName1);
            this.tabPageRevenus.Controls.Add(this.dateEnd1);
            this.tabPageRevenus.Controls.Add(this.dateStart1);
            this.tabPageRevenus.Controls.Add(this.labelEndDate1);
            this.tabPageRevenus.Controls.Add(this.labelStartDate1);
            this.tabPageRevenus.Controls.Add(this.radioTwoTimesInMonthTrans1);
            this.tabPageRevenus.Controls.Add(this.radioPeriodicTrans1);
            this.tabPageRevenus.Controls.Add(this.radioOneShotTrans1);
            this.tabPageRevenus.Controls.Add(this.buttonNewRevenu1);
            this.tabPageRevenus.Controls.Add(this.comboBoxSecondTimeInMonth1);
            this.tabPageRevenus.Controls.Add(this.labelPeriod1);
            this.tabPageRevenus.Controls.Add(this.labelSecondTimeInMonth1);
            this.tabPageRevenus.Controls.Add(this.comboBoxFirstTimeInMonth1);
            this.tabPageRevenus.Location = new System.Drawing.Point(4, 22);
            this.tabPageRevenus.Name = "tabPageRevenus";
            this.tabPageRevenus.Size = new System.Drawing.Size(1497, 748);
            this.tabPageRevenus.TabIndex = 1;
            this.tabPageRevenus.Text = "Revenus";
            // 
            // checkBoxRemoveFromAnnualReport1
            // 
            this.checkBoxRemoveFromAnnualReport1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxRemoveFromAnnualReport1.Location = new System.Drawing.Point(1081, 147);
            this.checkBoxRemoveFromAnnualReport1.Name = "checkBoxRemoveFromAnnualReport1";
            this.checkBoxRemoveFromAnnualReport1.Size = new System.Drawing.Size(178, 17);
            this.checkBoxRemoveFromAnnualReport1.TabIndex = 10;
            this.checkBoxRemoveFromAnnualReport1.Text = "Exclure du bilan annuel";
            this.checkBoxRemoveFromAnnualReport1.UseVisualStyleBackColor = true;
            // 
            // labelCategory1
            // 
            this.labelCategory1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCategory1.AutoSize = true;
            this.labelCategory1.Location = new System.Drawing.Point(1078, 110);
            this.labelCategory1.Name = "labelCategory1";
            this.labelCategory1.Size = new System.Drawing.Size(55, 13);
            this.labelCategory1.TabIndex = 127;
            this.labelCategory1.Text = "Catégorie:";
            // 
            // comboBoxCategory1
            // 
            this.comboBoxCategory1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCategory1.FormattingEnabled = true;
            this.comboBoxCategory1.Location = new System.Drawing.Point(1241, 107);
            this.comboBoxCategory1.MaxDropDownItems = 20;
            this.comboBoxCategory1.Name = "comboBoxCategory1";
            this.comboBoxCategory1.Size = new System.Drawing.Size(211, 21);
            this.comboBoxCategory1.TabIndex = 9;
            // 
            // panelBalanceAndButtons1
            // 
            this.panelBalanceAndButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBalanceAndButtons1.Controls.Add(this.labelWarning1);
            this.panelBalanceAndButtons1.Controls.Add(this.labelBalance1);
            this.panelBalanceAndButtons1.Controls.Add(this.buttonSaveRevenu1);
            this.panelBalanceAndButtons1.Controls.Add(this.buttonDelRevenu1);
            this.panelBalanceAndButtons1.Controls.Add(this.buttonIncomeCancel1);
            this.panelBalanceAndButtons1.Location = new System.Drawing.Point(1066, 611);
            this.panelBalanceAndButtons1.Name = "panelBalanceAndButtons1";
            this.panelBalanceAndButtons1.Size = new System.Drawing.Size(413, 121);
            this.panelBalanceAndButtons1.TabIndex = 125;
            // 
            // labelWarning1
            // 
            this.labelWarning1.BackColor = System.Drawing.Color.Transparent;
            this.labelWarning1.ForeColor = System.Drawing.Color.Red;
            this.labelWarning1.Location = new System.Drawing.Point(12, 58);
            this.labelWarning1.Name = "labelWarning1";
            this.labelWarning1.Size = new System.Drawing.Size(386, 26);
            this.labelWarning1.TabIndex = 4;
            this.labelWarning1.Text = "Le montant restant d\'ici au 15 septembre 2012 est de 1654 $. Il devrait être de 5" +
    "40 $. ";
            // 
            // labelBalance1
            // 
            this.labelBalance1.BackColor = System.Drawing.Color.Transparent;
            this.labelBalance1.Location = new System.Drawing.Point(12, 17);
            this.labelBalance1.Name = "labelBalance1";
            this.labelBalance1.Size = new System.Drawing.Size(389, 41);
            this.labelBalance1.TabIndex = 0;
            this.labelBalance1.Text = "D\'ici au 31 décembre 2012: 150 $ restant à dépenser sur un total de 1250 $. Proch" +
    "ain versement de 1456 $ le 5 mars 2012. Montant dépensé en moyenne par 2 semaine" +
    "s: 580 $.";
            // 
            // buttonSaveRevenu1
            // 
            this.buttonSaveRevenu1.BackColor = System.Drawing.Color.Transparent;
            this.buttonSaveRevenu1.Location = new System.Drawing.Point(158, 85);
            this.buttonSaveRevenu1.Name = "buttonSaveRevenu1";
            this.buttonSaveRevenu1.Size = new System.Drawing.Size(88, 23);
            this.buttonSaveRevenu1.TabIndex = 1;
            this.buttonSaveRevenu1.Text = "Sauvegarder";
            this.buttonSaveRevenu1.UseVisualStyleBackColor = false;
            this.buttonSaveRevenu1.Click += new System.EventHandler(this.buttonSaveRevenu1_Click);
            // 
            // buttonDelRevenu1
            // 
            this.buttonDelRevenu1.BackColor = System.Drawing.Color.Transparent;
            this.buttonDelRevenu1.Location = new System.Drawing.Point(320, 85);
            this.buttonDelRevenu1.Name = "buttonDelRevenu1";
            this.buttonDelRevenu1.Size = new System.Drawing.Size(56, 23);
            this.buttonDelRevenu1.TabIndex = 3;
            this.buttonDelRevenu1.Text = "Effacer";
            this.buttonDelRevenu1.UseVisualStyleBackColor = false;
            this.buttonDelRevenu1.Click += new System.EventHandler(this.buttonDelRevenu1_Click);
            // 
            // buttonIncomeCancel1
            // 
            this.buttonIncomeCancel1.BackColor = System.Drawing.Color.Transparent;
            this.buttonIncomeCancel1.Location = new System.Drawing.Point(252, 85);
            this.buttonIncomeCancel1.Name = "buttonIncomeCancel1";
            this.buttonIncomeCancel1.Size = new System.Drawing.Size(62, 23);
            this.buttonIncomeCancel1.TabIndex = 2;
            this.buttonIncomeCancel1.Text = "Annuler";
            this.buttonIncomeCancel1.UseVisualStyleBackColor = false;
            this.buttonIncomeCancel1.Click += new System.EventHandler(this.buttonIncomeCancel1_Click);
            // 
            // dataGridAmountAlreadyPayed1
            // 
            this.dataGridAmountAlreadyPayed1.AllowUserToAddRows = false;
            this.dataGridAmountAlreadyPayed1.AllowUserToDeleteRows = false;
            this.dataGridAmountAlreadyPayed1.AllowUserToResizeColumns = false;
            this.dataGridAmountAlreadyPayed1.AllowUserToResizeRows = false;
            this.dataGridAmountAlreadyPayed1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridAmountAlreadyPayed1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridAmountAlreadyPayed1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridAmountAlreadyPayed1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.dataGridAmountAlreadyPayed1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridAmountAlreadyPayed1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridAmountAlreadyPayed1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridAmountAlreadyPayed1.ColumnHeadersHeight = 4;
            this.dataGridAmountAlreadyPayed1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridAmountAlreadyPayed1.ColumnHeadersVisible = false;
            this.dataGridAmountAlreadyPayed1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TestDate,
            this.TestValue,
            this.Completed});
            this.dataGridAmountAlreadyPayed1.Location = new System.Drawing.Point(1066, 439);
            this.dataGridAmountAlreadyPayed1.MultiSelect = false;
            this.dataGridAmountAlreadyPayed1.Name = "dataGridAmountAlreadyPayed1";
            this.dataGridAmountAlreadyPayed1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridAmountAlreadyPayed1.RowHeadersVisible = false;
            this.dataGridAmountAlreadyPayed1.Size = new System.Drawing.Size(386, 166);
            this.dataGridAmountAlreadyPayed1.TabIndex = 22;
            // 
            // TestDate
            // 
            this.TestDate.DataPropertyName = "TestDate";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.TestDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.TestDate.HeaderText = "";
            this.TestDate.Name = "TestDate";
            this.TestDate.ReadOnly = true;
            this.TestDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TestDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TestDate.Width = 5;
            // 
            // TestValue
            // 
            this.TestValue.DataPropertyName = "TestValue";
            this.TestValue.HeaderText = "";
            this.TestValue.Name = "TestValue";
            this.TestValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TestValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TestValue.Width = 5;
            // 
            // Completed
            // 
            this.Completed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Completed.FalseValue = "false";
            this.Completed.HeaderText = "Column1";
            this.Completed.IndeterminateValue = "false";
            this.Completed.Name = "Completed";
            this.Completed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Completed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Completed.TrueValue = "true";
            this.Completed.Width = 5;
            // 
            // textBoxPeriod1
            // 
            this.textBoxPeriod1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPeriod1.Location = new System.Drawing.Point(1356, 244);
            this.textBoxPeriod1.Name = "textBoxPeriod1";
            this.textBoxPeriod1.Size = new System.Drawing.Size(40, 20);
            this.textBoxPeriod1.TabIndex = 17;
            this.textBoxPeriod1.Visible = false;
            // 
            // textBoxAmount1
            // 
            this.textBoxAmount1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAmount1.BackColor = System.Drawing.Color.White;
            this.textBoxAmount1.Location = new System.Drawing.Point(1241, 78);
            this.textBoxAmount1.Name = "textBoxAmount1";
            this.textBoxAmount1.Size = new System.Drawing.Size(71, 20);
            this.textBoxAmount1.TabIndex = 8;
            this.textBoxAmount1.GotFocus += new System.EventHandler(this.textBoxAmount1_GotFocus);
            this.textBoxAmount1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxAmount1_KeyUp);
            this.textBoxAmount1.LostFocus += new System.EventHandler(this.textBoxAmount1_LostFocus);
            // 
            // textBoxTransactionName1
            // 
            this.textBoxTransactionName1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTransactionName1.BackColor = System.Drawing.Color.White;
            this.textBoxTransactionName1.Location = new System.Drawing.Point(1241, 48);
            this.textBoxTransactionName1.Name = "textBoxTransactionName1";
            this.textBoxTransactionName1.Size = new System.Drawing.Size(211, 20);
            this.textBoxTransactionName1.TabIndex = 7;
            // 
            // TextBoxNotes1
            // 
            this.TextBoxNotes1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxNotes1.BackColor = System.Drawing.Color.White;
            this.TextBoxNotes1.Location = new System.Drawing.Point(1126, 313);
            this.TextBoxNotes1.Multiline = true;
            this.TextBoxNotes1.Name = "TextBoxNotes1";
            this.TextBoxNotes1.Size = new System.Drawing.Size(326, 51);
            this.TextBoxNotes1.TabIndex = 21;
            // 
            // ListBoxRevenus1
            // 
            this.ListBoxRevenus1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxRevenus1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ListBoxRevenus1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListBoxRevenus1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ListBoxRevenus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxRevenus1.HorizontalScrollbar = true;
            this.ListBoxRevenus1.ItemHeight = 16;
            this.ListBoxRevenus1.Location = new System.Drawing.Point(16, 48);
            this.ListBoxRevenus1.Name = "ListBoxRevenus1";
            this.ListBoxRevenus1.Size = new System.Drawing.Size(996, 644);
            this.ListBoxRevenus1.TabIndex = 3;
            this.ListBoxRevenus1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBoxRevenus1_DrawItem);
            this.ListBoxRevenus1.SelectedIndexChanged += new System.EventHandler(this.ListBoxRevenus1_SelectedIndexChanged);
            this.ListBoxRevenus1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ListBoxRevenus1_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.radioButtonIsAutomatic1);
            this.panel1.Controls.Add(this.radioButtonIsManual1);
            this.panel1.Location = new System.Drawing.Point(1066, 367);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 71);
            this.panel1.TabIndex = 123;
            // 
            // radioButtonIsAutomatic1
            // 
            this.radioButtonIsAutomatic1.AutoSize = true;
            this.radioButtonIsAutomatic1.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonIsAutomatic1.Location = new System.Drawing.Point(12, 5);
            this.radioButtonIsAutomatic1.Name = "radioButtonIsAutomatic1";
            this.radioButtonIsAutomatic1.Size = new System.Drawing.Size(260, 17);
            this.radioButtonIsAutomatic1.TabIndex = 0;
            this.radioButtonIsAutomatic1.Text = "Revenu déposé automatiquement dans le compte";
            this.radioButtonIsAutomatic1.UseVisualStyleBackColor = false;
            this.radioButtonIsAutomatic1.CheckedChanged += new System.EventHandler(this.radioButtonIsAutomatic1_CheckedChanged);
            // 
            // radioButtonIsManual1
            // 
            this.radioButtonIsManual1.AutoSize = true;
            this.radioButtonIsManual1.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonIsManual1.Checked = true;
            this.radioButtonIsManual1.Location = new System.Drawing.Point(12, 28);
            this.radioButtonIsManual1.Name = "radioButtonIsManual1";
            this.radioButtonIsManual1.Size = new System.Drawing.Size(244, 17);
            this.radioButtonIsManual1.TabIndex = 1;
            this.radioButtonIsManual1.TabStop = true;
            this.radioButtonIsManual1.Text = "Revenu déposé manuellement dans le compte";
            this.radioButtonIsManual1.UseVisualStyleBackColor = false;
            this.radioButtonIsManual1.CheckedChanged += new System.EventHandler(this.radioButtonIsManual1_CheckedChanged);
            // 
            // buttonDownIncome
            // 
            this.buttonDownIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDownIncome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDownIncome.BackgroundImage")));
            this.buttonDownIncome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDownIncome.FlatAppearance.BorderSize = 0;
            this.buttonDownIncome.Location = new System.Drawing.Point(1021, 78);
            this.buttonDownIncome.Name = "buttonDownIncome";
            this.buttonDownIncome.Size = new System.Drawing.Size(25, 25);
            this.buttonDownIncome.TabIndex = 6;
            this.buttonDownIncome.UseVisualStyleBackColor = true;
            this.buttonDownIncome.Click += new System.EventHandler(this.buttonDownIncome_Click);
            // 
            // buttonUpIncome
            // 
            this.buttonUpIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpIncome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonUpIncome.BackgroundImage")));
            this.buttonUpIncome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUpIncome.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.buttonUpIncome.FlatAppearance.BorderSize = 0;
            this.buttonUpIncome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AliceBlue;
            this.buttonUpIncome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.buttonUpIncome.Location = new System.Drawing.Point(1021, 48);
            this.buttonUpIncome.Name = "buttonUpIncome";
            this.buttonUpIncome.Size = new System.Drawing.Size(25, 25);
            this.buttonUpIncome.TabIndex = 5;
            this.buttonUpIncome.UseVisualStyleBackColor = true;
            this.buttonUpIncome.Click += new System.EventHandler(this.buttonUpIncome_Click);
            // 
            // labelRevenuTotal
            // 
            this.labelRevenuTotal.AutoSize = true;
            this.labelRevenuTotal.Location = new System.Drawing.Point(12, 703);
            this.labelRevenuTotal.Name = "labelRevenuTotal";
            this.labelRevenuTotal.Size = new System.Drawing.Size(81, 13);
            this.labelRevenuTotal.TabIndex = 116;
            this.labelRevenuTotal.Text = "Revenu Total : ";
            // 
            // labelNotes1
            // 
            this.labelNotes1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNotes1.BackColor = System.Drawing.Color.Transparent;
            this.labelNotes1.Location = new System.Drawing.Point(1078, 313);
            this.labelNotes1.Name = "labelNotes1";
            this.labelNotes1.Size = new System.Drawing.Size(40, 16);
            this.labelNotes1.TabIndex = 111;
            this.labelNotes1.Text = "Notes :";
            // 
            // labelTitleRevenus1
            // 
            this.labelTitleRevenus1.BackColor = System.Drawing.Color.Transparent;
            this.labelTitleRevenus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleRevenus1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.labelTitleRevenus1.Location = new System.Drawing.Point(3, 8);
            this.labelTitleRevenus1.Name = "labelTitleRevenus1";
            this.labelTitleRevenus1.Size = new System.Drawing.Size(773, 23);
            this.labelTitleRevenus1.TabIndex = 104;
            this.labelTitleRevenus1.Text = "Revenus";
            this.labelTitleRevenus1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDollar1
            // 
            this.labelDollar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDollar1.BackColor = System.Drawing.Color.Transparent;
            this.labelDollar1.Location = new System.Drawing.Point(1316, 78);
            this.labelDollar1.Name = "labelDollar1";
            this.labelDollar1.Size = new System.Drawing.Size(15, 16);
            this.labelDollar1.TabIndex = 103;
            this.labelDollar1.Text = "$";
            this.labelDollar1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxPeriodLength1
            // 
            this.comboBoxPeriodLength1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPeriodLength1.Items.AddRange(new object[] {
            "jours",
            "sem.",
            "mois",
            "ans"});
            this.comboBoxPeriodLength1.Location = new System.Drawing.Point(1402, 244);
            this.comboBoxPeriodLength1.Name = "comboBoxPeriodLength1";
            this.comboBoxPeriodLength1.Size = new System.Drawing.Size(50, 21);
            this.comboBoxPeriodLength1.TabIndex = 18;
            this.comboBoxPeriodLength1.Text = "jours";
            this.comboBoxPeriodLength1.Visible = false;
            this.comboBoxPeriodLength1.SelectedIndexChanged += new System.EventHandler(this.comboBoxPeriodLength1_SelectedIndexChanged);
            // 
            // labelFirstTimeInMonth1
            // 
            this.labelFirstTimeInMonth1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFirstTimeInMonth1.AutoSize = true;
            this.labelFirstTimeInMonth1.BackColor = System.Drawing.Color.Transparent;
            this.labelFirstTimeInMonth1.Location = new System.Drawing.Point(1241, 276);
            this.labelFirstTimeInMonth1.Name = "labelFirstTimeInMonth1";
            this.labelFirstTimeInMonth1.Size = new System.Drawing.Size(50, 13);
            this.labelFirstTimeInMonth1.TabIndex = 60;
            this.labelFirstTimeInMonth1.Text = "1ère fois:";
            this.labelFirstTimeInMonth1.Visible = false;
            // 
            // labelAmount1
            // 
            this.labelAmount1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAmount1.BackColor = System.Drawing.Color.Transparent;
            this.labelAmount1.Location = new System.Drawing.Point(1078, 78);
            this.labelAmount1.Name = "labelAmount1";
            this.labelAmount1.Size = new System.Drawing.Size(104, 16);
            this.labelAmount1.TabIndex = 59;
            this.labelAmount1.Text = "Montant :";
            // 
            // labelTransactionName1
            // 
            this.labelTransactionName1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTransactionName1.BackColor = System.Drawing.Color.Transparent;
            this.labelTransactionName1.Location = new System.Drawing.Point(1078, 48);
            this.labelTransactionName1.Name = "labelTransactionName1";
            this.labelTransactionName1.Size = new System.Drawing.Size(120, 16);
            this.labelTransactionName1.TabIndex = 55;
            this.labelTransactionName1.Text = "Nom du revenu :";
            // 
            // dateEnd1
            // 
            this.dateEnd1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEnd1.CustomFormat = "dd MMM yyyy";
            this.dateEnd1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd1.Location = new System.Drawing.Point(1356, 212);
            this.dateEnd1.MaxDate = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.dateEnd1.MinDate = new System.DateTime(2011, 1, 1, 0, 0, 0, 0);
            this.dateEnd1.Name = "dateEnd1";
            this.dateEnd1.Size = new System.Drawing.Size(96, 20);
            this.dateEnd1.TabIndex = 16;
            this.dateEnd1.Value = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.dateEnd1.Visible = false;
            // 
            // dateStart1
            // 
            this.dateStart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateStart1.CustomFormat = "dd MMM yyyy";
            this.dateStart1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStart1.Location = new System.Drawing.Point(1356, 180);
            this.dateStart1.MaxDate = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.dateStart1.MinDate = new System.DateTime(2011, 1, 1, 0, 0, 0, 0);
            this.dateStart1.Name = "dateStart1";
            this.dateStart1.Size = new System.Drawing.Size(96, 20);
            this.dateStart1.TabIndex = 15;
            this.dateStart1.Value = new System.DateTime(2011, 1, 1, 0, 0, 0, 0);
            // 
            // labelEndDate1
            // 
            this.labelEndDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEndDate1.BackColor = System.Drawing.Color.Transparent;
            this.labelEndDate1.Location = new System.Drawing.Point(1241, 212);
            this.labelEndDate1.Name = "labelEndDate1";
            this.labelEndDate1.Size = new System.Drawing.Size(116, 20);
            this.labelEndDate1.TabIndex = 52;
            this.labelEndDate1.Text = "Dernier paiement le:";
            this.labelEndDate1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelEndDate1.Visible = false;
            // 
            // labelStartDate1
            // 
            this.labelStartDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStartDate1.BackColor = System.Drawing.Color.Transparent;
            this.labelStartDate1.Location = new System.Drawing.Point(1241, 180);
            this.labelStartDate1.Name = "labelStartDate1";
            this.labelStartDate1.Size = new System.Drawing.Size(110, 20);
            this.labelStartDate1.TabIndex = 49;
            this.labelStartDate1.Text = "Paiement le:";
            this.labelStartDate1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioTwoTimesInMonthTrans1
            // 
            this.radioTwoTimesInMonthTrans1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioTwoTimesInMonthTrans1.BackColor = System.Drawing.Color.Transparent;
            this.radioTwoTimesInMonthTrans1.Location = new System.Drawing.Point(1078, 245);
            this.radioTwoTimesInMonthTrans1.Name = "radioTwoTimesInMonthTrans1";
            this.radioTwoTimesInMonthTrans1.Size = new System.Drawing.Size(153, 17);
            this.radioTwoTimesInMonthTrans1.TabIndex = 14;
            this.radioTwoTimesInMonthTrans1.Text = "Revenu 2 fois par &mois";
            this.radioTwoTimesInMonthTrans1.UseVisualStyleBackColor = false;
            this.radioTwoTimesInMonthTrans1.CheckedChanged += new System.EventHandler(this.radioTwoTimesInMonthTrans1_CheckedChanged);
            // 
            // radioPeriodicTrans1
            // 
            this.radioPeriodicTrans1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioPeriodicTrans1.BackColor = System.Drawing.Color.Transparent;
            this.radioPeriodicTrans1.Location = new System.Drawing.Point(1078, 213);
            this.radioPeriodicTrans1.Name = "radioPeriodicTrans1";
            this.radioPeriodicTrans1.Size = new System.Drawing.Size(153, 20);
            this.radioPeriodicTrans1.TabIndex = 12;
            this.radioPeriodicTrans1.Text = "Revenu &périodique";
            this.radioPeriodicTrans1.UseVisualStyleBackColor = false;
            this.radioPeriodicTrans1.CheckedChanged += new System.EventHandler(this.radioPeriodicTrans1_CheckedChanged);
            // 
            // radioOneShotTrans1
            // 
            this.radioOneShotTrans1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioOneShotTrans1.BackColor = System.Drawing.Color.Transparent;
            this.radioOneShotTrans1.Checked = true;
            this.radioOneShotTrans1.Location = new System.Drawing.Point(1078, 180);
            this.radioOneShotTrans1.Name = "radioOneShotTrans1";
            this.radioOneShotTrans1.Size = new System.Drawing.Size(136, 20);
            this.radioOneShotTrans1.TabIndex = 11;
            this.radioOneShotTrans1.TabStop = true;
            this.radioOneShotTrans1.Text = "Revenu &unique";
            this.radioOneShotTrans1.UseVisualStyleBackColor = false;
            this.radioOneShotTrans1.CheckedChanged += new System.EventHandler(this.radioOneShotTrans1_CheckedChanged);
            // 
            // buttonNewRevenu1
            // 
            this.buttonNewRevenu1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewRevenu1.BackColor = System.Drawing.Color.Transparent;
            this.buttonNewRevenu1.Location = new System.Drawing.Point(908, 696);
            this.buttonNewRevenu1.Name = "buttonNewRevenu1";
            this.buttonNewRevenu1.Size = new System.Drawing.Size(104, 23);
            this.buttonNewRevenu1.TabIndex = 4;
            this.buttonNewRevenu1.Text = "Nouveau revenu";
            this.buttonNewRevenu1.UseVisualStyleBackColor = false;
            this.buttonNewRevenu1.Click += new System.EventHandler(this.buttonNewRevenu1_Click);
            // 
            // comboBoxSecondTimeInMonth1
            // 
            this.comboBoxSecondTimeInMonth1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSecondTimeInMonth1.Items.AddRange(new object[] {
            "1er",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "dernier jour"});
            this.comboBoxSecondTimeInMonth1.Location = new System.Drawing.Point(1356, 276);
            this.comboBoxSecondTimeInMonth1.Name = "comboBoxSecondTimeInMonth1";
            this.comboBoxSecondTimeInMonth1.Size = new System.Drawing.Size(96, 21);
            this.comboBoxSecondTimeInMonth1.TabIndex = 20;
            this.comboBoxSecondTimeInMonth1.Text = "15";
            this.comboBoxSecondTimeInMonth1.Visible = false;
            // 
            // labelPeriod1
            // 
            this.labelPeriod1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPeriod1.AutoSize = true;
            this.labelPeriod1.BackColor = System.Drawing.Color.Transparent;
            this.labelPeriod1.Location = new System.Drawing.Point(1241, 247);
            this.labelPeriod1.Name = "labelPeriod1";
            this.labelPeriod1.Size = new System.Drawing.Size(49, 13);
            this.labelPeriod1.TabIndex = 62;
            this.labelPeriod1.Text = "Période :";
            this.labelPeriod1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPeriod1.Visible = false;
            // 
            // labelSecondTimeInMonth1
            // 
            this.labelSecondTimeInMonth1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSecondTimeInMonth1.AutoSize = true;
            this.labelSecondTimeInMonth1.BackColor = System.Drawing.Color.Transparent;
            this.labelSecondTimeInMonth1.Location = new System.Drawing.Point(1241, 276);
            this.labelSecondTimeInMonth1.Name = "labelSecondTimeInMonth1";
            this.labelSecondTimeInMonth1.Size = new System.Drawing.Size(55, 13);
            this.labelSecondTimeInMonth1.TabIndex = 61;
            this.labelSecondTimeInMonth1.Text = "2ème fois:";
            this.labelSecondTimeInMonth1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSecondTimeInMonth1.Visible = false;
            // 
            // comboBoxFirstTimeInMonth1
            // 
            this.comboBoxFirstTimeInMonth1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFirstTimeInMonth1.Items.AddRange(new object[] {
            "1er",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "dernier jour"});
            this.comboBoxFirstTimeInMonth1.Location = new System.Drawing.Point(1356, 276);
            this.comboBoxFirstTimeInMonth1.Name = "comboBoxFirstTimeInMonth1";
            this.comboBoxFirstTimeInMonth1.Size = new System.Drawing.Size(96, 21);
            this.comboBoxFirstTimeInMonth1.TabIndex = 54;
            this.comboBoxFirstTimeInMonth1.Text = "1er";
            this.comboBoxFirstTimeInMonth1.Visible = false;
            // 
            // tabPageDépenses
            // 
            this.tabPageDépenses.AutoScroll = true;
            this.tabPageDépenses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.tabPageDépenses.Controls.Add(this.checkBoxRemoveFromAnnualReport2);
            this.tabPageDépenses.Controls.Add(this.labelCategory2);
            this.tabPageDépenses.Controls.Add(this.comboBoxCategory2);
            this.tabPageDépenses.Controls.Add(this.dataGridAmountAlreadyPayed2);
            this.tabPageDépenses.Controls.Add(this.textBoxPeriod2);
            this.tabPageDépenses.Controls.Add(this.textBoxAmount2);
            this.tabPageDépenses.Controls.Add(this.textBoxTransactionName2);
            this.tabPageDépenses.Controls.Add(this.TextBoxNotes2);
            this.tabPageDépenses.Controls.Add(this.panel2);
            this.tabPageDépenses.Controls.Add(this.buttonDownExpenses);
            this.tabPageDépenses.Controls.Add(this.buttonUpExpenses);
            this.tabPageDépenses.Controls.Add(this.labelTotalExpenses);
            this.tabPageDépenses.Controls.Add(this.labelTitleDépenses2);
            this.tabPageDépenses.Controls.Add(this.labelDollar2);
            this.tabPageDépenses.Controls.Add(this.labelNotes2);
            this.tabPageDépenses.Controls.Add(this.comboBoxPeriodLength2);
            this.tabPageDépenses.Controls.Add(this.labelAmount2);
            this.tabPageDépenses.Controls.Add(this.labelTransactionName2);
            this.tabPageDépenses.Controls.Add(this.dateEnd2);
            this.tabPageDépenses.Controls.Add(this.dateStart2);
            this.tabPageDépenses.Controls.Add(this.labelEndDate2);
            this.tabPageDépenses.Controls.Add(this.labelStartDate2);
            this.tabPageDépenses.Controls.Add(this.radioTwoTimesInMonthTrans2);
            this.tabPageDépenses.Controls.Add(this.radioPeriodicTrans2);
            this.tabPageDépenses.Controls.Add(this.radioOneShotTrans2);
            this.tabPageDépenses.Controls.Add(this.buttonNewDepense2);
            this.tabPageDépenses.Controls.Add(this.ListBoxDepenses2);
            this.tabPageDépenses.Controls.Add(this.labelPeriod2);
            this.tabPageDépenses.Controls.Add(this.panelBalanceAndButtons2);
            this.tabPageDépenses.Controls.Add(this.labelFirstTimeInMonth2);
            this.tabPageDépenses.Controls.Add(this.labelSecondTimeInMonth2);
            this.tabPageDépenses.Controls.Add(this.comboBoxFirstTimeInMonth2);
            this.tabPageDépenses.Controls.Add(this.comboBoxSecondTimeInMonth2);
            this.tabPageDépenses.Location = new System.Drawing.Point(4, 22);
            this.tabPageDépenses.Name = "tabPageDépenses";
            this.tabPageDépenses.Size = new System.Drawing.Size(1497, 748);
            this.tabPageDépenses.TabIndex = 2;
            this.tabPageDépenses.Text = "Dépenses";
            // 
            // checkBoxRemoveFromAnnualReport2
            // 
            this.checkBoxRemoveFromAnnualReport2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxRemoveFromAnnualReport2.Location = new System.Drawing.Point(1085, 137);
            this.checkBoxRemoveFromAnnualReport2.Name = "checkBoxRemoveFromAnnualReport2";
            this.checkBoxRemoveFromAnnualReport2.Size = new System.Drawing.Size(176, 17);
            this.checkBoxRemoveFromAnnualReport2.TabIndex = 8;
            this.checkBoxRemoveFromAnnualReport2.Text = "Exclure du bilan annuel";
            this.checkBoxRemoveFromAnnualReport2.UseVisualStyleBackColor = true;
            // 
            // labelCategory2
            // 
            this.labelCategory2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCategory2.AutoSize = true;
            this.labelCategory2.Location = new System.Drawing.Point(1082, 107);
            this.labelCategory2.Name = "labelCategory2";
            this.labelCategory2.Size = new System.Drawing.Size(55, 13);
            this.labelCategory2.TabIndex = 153;
            this.labelCategory2.Text = "Catégorie:";
            // 
            // comboBoxCategory2
            // 
            this.comboBoxCategory2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCategory2.FormattingEnabled = true;
            this.comboBoxCategory2.Location = new System.Drawing.Point(1255, 104);
            this.comboBoxCategory2.MaxDropDownItems = 20;
            this.comboBoxCategory2.Name = "comboBoxCategory2";
            this.comboBoxCategory2.Size = new System.Drawing.Size(211, 21);
            this.comboBoxCategory2.TabIndex = 7;
            // 
            // dataGridAmountAlreadyPayed2
            // 
            this.dataGridAmountAlreadyPayed2.AllowUserToAddRows = false;
            this.dataGridAmountAlreadyPayed2.AllowUserToDeleteRows = false;
            this.dataGridAmountAlreadyPayed2.AllowUserToResizeColumns = false;
            this.dataGridAmountAlreadyPayed2.AllowUserToResizeRows = false;
            this.dataGridAmountAlreadyPayed2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridAmountAlreadyPayed2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridAmountAlreadyPayed2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridAmountAlreadyPayed2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.dataGridAmountAlreadyPayed2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridAmountAlreadyPayed2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridAmountAlreadyPayed2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridAmountAlreadyPayed2.ColumnHeadersHeight = 4;
            this.dataGridAmountAlreadyPayed2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridAmountAlreadyPayed2.ColumnHeadersVisible = false;
            this.dataGridAmountAlreadyPayed2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Complete});
            this.dataGridAmountAlreadyPayed2.Location = new System.Drawing.Point(1070, 429);
            this.dataGridAmountAlreadyPayed2.MultiSelect = false;
            this.dataGridAmountAlreadyPayed2.Name = "dataGridAmountAlreadyPayed2";
            this.dataGridAmountAlreadyPayed2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridAmountAlreadyPayed2.RowHeadersVisible = false;
            this.dataGridAmountAlreadyPayed2.Size = new System.Drawing.Size(413, 183);
            this.dataGridAmountAlreadyPayed2.TabIndex = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TestDate";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 5;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TestValue";
            this.dataGridViewTextBoxColumn2.HeaderText = "";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 5;
            // 
            // Complete
            // 
            this.Complete.FalseValue = "false";
            this.Complete.HeaderText = "Column1";
            this.Complete.IndeterminateValue = "false";
            this.Complete.Name = "Complete";
            this.Complete.TrueValue = "true";
            this.Complete.Width = 5;
            // 
            // textBoxPeriod2
            // 
            this.textBoxPeriod2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPeriod2.Location = new System.Drawing.Point(1370, 229);
            this.textBoxPeriod2.Name = "textBoxPeriod2";
            this.textBoxPeriod2.Size = new System.Drawing.Size(40, 20);
            this.textBoxPeriod2.TabIndex = 15;
            this.textBoxPeriod2.Visible = false;
            // 
            // textBoxAmount2
            // 
            this.textBoxAmount2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAmount2.BackColor = System.Drawing.Color.White;
            this.textBoxAmount2.Location = new System.Drawing.Point(1255, 76);
            this.textBoxAmount2.Name = "textBoxAmount2";
            this.textBoxAmount2.Size = new System.Drawing.Size(71, 20);
            this.textBoxAmount2.TabIndex = 6;
            this.textBoxAmount2.GotFocus += new System.EventHandler(this.textBoxAmount2_GotFocus);
            this.textBoxAmount2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxAmount2_KeyUp);
            this.textBoxAmount2.LostFocus += new System.EventHandler(this.textBoxAmount2_LostFocus);
            // 
            // textBoxTransactionName2
            // 
            this.textBoxTransactionName2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTransactionName2.BackColor = System.Drawing.Color.White;
            this.textBoxTransactionName2.Location = new System.Drawing.Point(1255, 48);
            this.textBoxTransactionName2.Name = "textBoxTransactionName2";
            this.textBoxTransactionName2.Size = new System.Drawing.Size(210, 20);
            this.textBoxTransactionName2.TabIndex = 5;
            // 
            // TextBoxNotes2
            // 
            this.TextBoxNotes2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxNotes2.BackColor = System.Drawing.Color.White;
            this.TextBoxNotes2.Location = new System.Drawing.Point(1127, 297);
            this.TextBoxNotes2.Multiline = true;
            this.TextBoxNotes2.Name = "TextBoxNotes2";
            this.TextBoxNotes2.Size = new System.Drawing.Size(338, 69);
            this.TextBoxNotes2.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.radioButtonIsAutomatic2);
            this.panel2.Controls.Add(this.radioButtonIsManual2);
            this.panel2.Location = new System.Drawing.Point(1070, 366);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 57);
            this.panel2.TabIndex = 150;
            // 
            // radioButtonIsAutomatic2
            // 
            this.radioButtonIsAutomatic2.AutoSize = true;
            this.radioButtonIsAutomatic2.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonIsAutomatic2.Checked = true;
            this.radioButtonIsAutomatic2.Location = new System.Drawing.Point(12, 11);
            this.radioButtonIsAutomatic2.Name = "radioButtonIsAutomatic2";
            this.radioButtonIsAutomatic2.Size = new System.Drawing.Size(249, 17);
            this.radioButtonIsAutomatic2.TabIndex = 0;
            this.radioButtonIsAutomatic2.TabStop = true;
            this.radioButtonIsAutomatic2.Text = "Dépense prélevée automatiquement du compte";
            this.radioButtonIsAutomatic2.UseVisualStyleBackColor = false;
            this.radioButtonIsAutomatic2.CheckedChanged += new System.EventHandler(this.radioButtonIsAutomatic2_CheckedChanged);
            // 
            // radioButtonIsManual2
            // 
            this.radioButtonIsManual2.AutoSize = true;
            this.radioButtonIsManual2.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonIsManual2.Location = new System.Drawing.Point(12, 34);
            this.radioButtonIsManual2.Name = "radioButtonIsManual2";
            this.radioButtonIsManual2.Size = new System.Drawing.Size(233, 17);
            this.radioButtonIsManual2.TabIndex = 1;
            this.radioButtonIsManual2.Text = "Dépense prélevée manuellement du compte";
            this.radioButtonIsManual2.UseVisualStyleBackColor = false;
            this.radioButtonIsManual2.CheckedChanged += new System.EventHandler(this.radioButtonIsManual2_CheckedChanged);
            // 
            // buttonDownExpenses
            // 
            this.buttonDownExpenses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDownExpenses.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDownExpenses.BackgroundImage")));
            this.buttonDownExpenses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDownExpenses.FlatAppearance.BorderSize = 0;
            this.buttonDownExpenses.Location = new System.Drawing.Point(1032, 78);
            this.buttonDownExpenses.Name = "buttonDownExpenses";
            this.buttonDownExpenses.Size = new System.Drawing.Size(25, 25);
            this.buttonDownExpenses.TabIndex = 4;
            this.buttonDownExpenses.UseVisualStyleBackColor = true;
            this.buttonDownExpenses.Click += new System.EventHandler(this.buttonDownExpenses_Click);
            // 
            // buttonUpExpenses
            // 
            this.buttonUpExpenses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpExpenses.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonUpExpenses.BackgroundImage")));
            this.buttonUpExpenses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUpExpenses.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.buttonUpExpenses.FlatAppearance.BorderSize = 0;
            this.buttonUpExpenses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AliceBlue;
            this.buttonUpExpenses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.buttonUpExpenses.Location = new System.Drawing.Point(1032, 48);
            this.buttonUpExpenses.Name = "buttonUpExpenses";
            this.buttonUpExpenses.Size = new System.Drawing.Size(25, 25);
            this.buttonUpExpenses.TabIndex = 3;
            this.buttonUpExpenses.UseVisualStyleBackColor = true;
            this.buttonUpExpenses.Click += new System.EventHandler(this.buttonUpExpenses_Click);
            // 
            // labelTotalExpenses
            // 
            this.labelTotalExpenses.AutoSize = true;
            this.labelTotalExpenses.Location = new System.Drawing.Point(13, 708);
            this.labelTotalExpenses.Name = "labelTotalExpenses";
            this.labelTotalExpenses.Size = new System.Drawing.Size(99, 13);
            this.labelTotalExpenses.TabIndex = 114;
            this.labelTotalExpenses.Text = "Dépenses Totales: ";
            // 
            // labelTitleDépenses2
            // 
            this.labelTitleDépenses2.BackColor = System.Drawing.Color.Transparent;
            this.labelTitleDépenses2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleDépenses2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.labelTitleDépenses2.Location = new System.Drawing.Point(3, 8);
            this.labelTitleDépenses2.Name = "labelTitleDépenses2";
            this.labelTitleDépenses2.Size = new System.Drawing.Size(760, 23);
            this.labelTitleDépenses2.TabIndex = 105;
            this.labelTitleDépenses2.Text = "Dépenses";
            this.labelTitleDépenses2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDollar2
            // 
            this.labelDollar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDollar2.BackColor = System.Drawing.Color.Transparent;
            this.labelDollar2.Location = new System.Drawing.Point(1337, 76);
            this.labelDollar2.Name = "labelDollar2";
            this.labelDollar2.Size = new System.Drawing.Size(16, 16);
            this.labelDollar2.TabIndex = 102;
            this.labelDollar2.Text = "$";
            this.labelDollar2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNotes2
            // 
            this.labelNotes2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNotes2.BackColor = System.Drawing.Color.Transparent;
            this.labelNotes2.Location = new System.Drawing.Point(1082, 297);
            this.labelNotes2.Name = "labelNotes2";
            this.labelNotes2.Size = new System.Drawing.Size(40, 16);
            this.labelNotes2.TabIndex = 98;
            this.labelNotes2.Text = "Notes :";
            // 
            // comboBoxPeriodLength2
            // 
            this.comboBoxPeriodLength2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPeriodLength2.Items.AddRange(new object[] {
            "jours",
            "sem.",
            "mois",
            "ans"});
            this.comboBoxPeriodLength2.Location = new System.Drawing.Point(1416, 229);
            this.comboBoxPeriodLength2.Name = "comboBoxPeriodLength2";
            this.comboBoxPeriodLength2.Size = new System.Drawing.Size(49, 21);
            this.comboBoxPeriodLength2.TabIndex = 16;
            this.comboBoxPeriodLength2.Text = "jours";
            this.comboBoxPeriodLength2.Visible = false;
            this.comboBoxPeriodLength2.SelectedIndexChanged += new System.EventHandler(this.comboBoxPeriodLength2_SelectedIndexChanged);
            // 
            // labelAmount2
            // 
            this.labelAmount2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAmount2.BackColor = System.Drawing.Color.Transparent;
            this.labelAmount2.Location = new System.Drawing.Point(1082, 78);
            this.labelAmount2.Name = "labelAmount2";
            this.labelAmount2.Size = new System.Drawing.Size(104, 16);
            this.labelAmount2.TabIndex = 91;
            this.labelAmount2.Text = "Montant :";
            // 
            // labelTransactionName2
            // 
            this.labelTransactionName2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTransactionName2.BackColor = System.Drawing.Color.Transparent;
            this.labelTransactionName2.Location = new System.Drawing.Point(1082, 48);
            this.labelTransactionName2.Name = "labelTransactionName2";
            this.labelTransactionName2.Size = new System.Drawing.Size(120, 16);
            this.labelTransactionName2.TabIndex = 89;
            this.labelTransactionName2.Text = "Nom de la dépense :";
            // 
            // dateEnd2
            // 
            this.dateEnd2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEnd2.CustomFormat = "dd MMM yyyy";
            this.dateEnd2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd2.Location = new System.Drawing.Point(1370, 197);
            this.dateEnd2.Name = "dateEnd2";
            this.dateEnd2.Size = new System.Drawing.Size(96, 20);
            this.dateEnd2.TabIndex = 14;
            this.dateEnd2.Value = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.dateEnd2.Visible = false;
            // 
            // dateStart2
            // 
            this.dateStart2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateStart2.CustomFormat = "dd MMM yyyy";
            this.dateStart2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStart2.Location = new System.Drawing.Point(1370, 165);
            this.dateStart2.Name = "dateStart2";
            this.dateStart2.Size = new System.Drawing.Size(96, 20);
            this.dateStart2.TabIndex = 13;
            // 
            // labelEndDate2
            // 
            this.labelEndDate2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEndDate2.BackColor = System.Drawing.Color.Transparent;
            this.labelEndDate2.Location = new System.Drawing.Point(1251, 195);
            this.labelEndDate2.Name = "labelEndDate2";
            this.labelEndDate2.Size = new System.Drawing.Size(112, 20);
            this.labelEndDate2.TabIndex = 86;
            this.labelEndDate2.Text = "Dernier paiement le:";
            this.labelEndDate2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelEndDate2.Visible = false;
            // 
            // labelStartDate2
            // 
            this.labelStartDate2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStartDate2.BackColor = System.Drawing.Color.Transparent;
            this.labelStartDate2.Location = new System.Drawing.Point(1251, 165);
            this.labelStartDate2.Name = "labelStartDate2";
            this.labelStartDate2.Size = new System.Drawing.Size(112, 20);
            this.labelStartDate2.TabIndex = 83;
            this.labelStartDate2.Text = "Paiement le:";
            this.labelStartDate2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioTwoTimesInMonthTrans2
            // 
            this.radioTwoTimesInMonthTrans2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioTwoTimesInMonthTrans2.BackColor = System.Drawing.Color.Transparent;
            this.radioTwoTimesInMonthTrans2.Location = new System.Drawing.Point(1085, 228);
            this.radioTwoTimesInMonthTrans2.Name = "radioTwoTimesInMonthTrans2";
            this.radioTwoTimesInMonthTrans2.Size = new System.Drawing.Size(152, 17);
            this.radioTwoTimesInMonthTrans2.TabIndex = 12;
            this.radioTwoTimesInMonthTrans2.Text = "Dépense 2 fois par &mois";
            this.radioTwoTimesInMonthTrans2.UseVisualStyleBackColor = false;
            this.radioTwoTimesInMonthTrans2.CheckedChanged += new System.EventHandler(this.radioTwoTimesInMonthTrans2_CheckedChanged);
            // 
            // radioPeriodicTrans2
            // 
            this.radioPeriodicTrans2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioPeriodicTrans2.BackColor = System.Drawing.Color.Transparent;
            this.radioPeriodicTrans2.Location = new System.Drawing.Point(1085, 193);
            this.radioPeriodicTrans2.Name = "radioPeriodicTrans2";
            this.radioPeriodicTrans2.Size = new System.Drawing.Size(152, 24);
            this.radioPeriodicTrans2.TabIndex = 10;
            this.radioPeriodicTrans2.Text = "Dépense &périodique";
            this.radioPeriodicTrans2.UseVisualStyleBackColor = false;
            this.radioPeriodicTrans2.CheckedChanged += new System.EventHandler(this.radioPeriodicTrans2_CheckedChanged);
            // 
            // radioOneShotTrans2
            // 
            this.radioOneShotTrans2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioOneShotTrans2.BackColor = System.Drawing.Color.Transparent;
            this.radioOneShotTrans2.Checked = true;
            this.radioOneShotTrans2.Location = new System.Drawing.Point(1085, 163);
            this.radioOneShotTrans2.Name = "radioOneShotTrans2";
            this.radioOneShotTrans2.Size = new System.Drawing.Size(136, 24);
            this.radioOneShotTrans2.TabIndex = 9;
            this.radioOneShotTrans2.TabStop = true;
            this.radioOneShotTrans2.Text = "Dépense &unique";
            this.radioOneShotTrans2.UseVisualStyleBackColor = false;
            this.radioOneShotTrans2.CheckedChanged += new System.EventHandler(this.radioOneShotTrans2_CheckedChanged);
            // 
            // buttonNewDepense2
            // 
            this.buttonNewDepense2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewDepense2.BackColor = System.Drawing.Color.Transparent;
            this.buttonNewDepense2.Location = new System.Drawing.Point(922, 697);
            this.buttonNewDepense2.Name = "buttonNewDepense2";
            this.buttonNewDepense2.Size = new System.Drawing.Size(104, 24);
            this.buttonNewDepense2.TabIndex = 2;
            this.buttonNewDepense2.Text = "Nouvelle dépense";
            this.buttonNewDepense2.UseVisualStyleBackColor = false;
            this.buttonNewDepense2.Click += new System.EventHandler(this.buttonNewDepense2_Click);
            // 
            // ListBoxDepenses2
            // 
            this.ListBoxDepenses2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxDepenses2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ListBoxDepenses2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListBoxDepenses2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ListBoxDepenses2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxDepenses2.HorizontalScrollbar = true;
            this.ListBoxDepenses2.ItemHeight = 16;
            this.ListBoxDepenses2.Location = new System.Drawing.Point(16, 48);
            this.ListBoxDepenses2.Name = "ListBoxDepenses2";
            this.ListBoxDepenses2.Size = new System.Drawing.Size(1010, 644);
            this.ListBoxDepenses2.TabIndex = 1;
            this.ListBoxDepenses2.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListBoxDepenses2_DrawItem);
            this.ListBoxDepenses2.SelectedIndexChanged += new System.EventHandler(this.ListBoxDepenses2_SelectedIndexChanged);
            this.ListBoxDepenses2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ListBoxDepenses2_MouseMove);
            // 
            // labelPeriod2
            // 
            this.labelPeriod2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPeriod2.AutoSize = true;
            this.labelPeriod2.BackColor = System.Drawing.Color.Transparent;
            this.labelPeriod2.Location = new System.Drawing.Point(1251, 230);
            this.labelPeriod2.Name = "labelPeriod2";
            this.labelPeriod2.Size = new System.Drawing.Size(49, 13);
            this.labelPeriod2.TabIndex = 94;
            this.labelPeriod2.Text = "Période :";
            this.labelPeriod2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPeriod2.Visible = false;
            // 
            // panelBalanceAndButtons2
            // 
            this.panelBalanceAndButtons2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBalanceAndButtons2.Controls.Add(this.labelWarning2);
            this.panelBalanceAndButtons2.Controls.Add(this.labelBalance2);
            this.panelBalanceAndButtons2.Controls.Add(this.buttonSaveDepense2);
            this.panelBalanceAndButtons2.Controls.Add(this.buttonExpenseCancel2);
            this.panelBalanceAndButtons2.Controls.Add(this.buttonDelDepense2);
            this.panelBalanceAndButtons2.Location = new System.Drawing.Point(1070, 623);
            this.panelBalanceAndButtons2.Name = "panelBalanceAndButtons2";
            this.panelBalanceAndButtons2.Size = new System.Drawing.Size(413, 109);
            this.panelBalanceAndButtons2.TabIndex = 151;
            // 
            // labelWarning2
            // 
            this.labelWarning2.BackColor = System.Drawing.Color.Transparent;
            this.labelWarning2.ForeColor = System.Drawing.Color.Red;
            this.labelWarning2.Location = new System.Drawing.Point(12, 53);
            this.labelWarning2.Name = "labelWarning2";
            this.labelWarning2.Size = new System.Drawing.Size(389, 26);
            this.labelWarning2.TabIndex = 5;
            this.labelWarning2.Text = "Avertissement:";
            // 
            // labelBalance2
            // 
            this.labelBalance2.BackColor = System.Drawing.Color.Transparent;
            this.labelBalance2.Location = new System.Drawing.Point(12, 12);
            this.labelBalance2.Name = "labelBalance2";
            this.labelBalance2.Size = new System.Drawing.Size(389, 42);
            this.labelBalance2.TabIndex = 0;
            this.labelBalance2.Text = "Solde: earejr erjewjr rejwiorjwer weriorjaweo erjwioawejr rwejiorjwerji reweairji" +
    "owe raweiorjawer erawer wa feahfwehf efiue fhew fefhuiwefh wefhweuihf wefhweuihf" +
    " wehfuiwef ";
            // 
            // buttonSaveDepense2
            // 
            this.buttonSaveDepense2.BackColor = System.Drawing.Color.Transparent;
            this.buttonSaveDepense2.Location = new System.Drawing.Point(156, 80);
            this.buttonSaveDepense2.Name = "buttonSaveDepense2";
            this.buttonSaveDepense2.Size = new System.Drawing.Size(98, 22);
            this.buttonSaveDepense2.TabIndex = 1;
            this.buttonSaveDepense2.Text = "Sauvegarder";
            this.buttonSaveDepense2.UseVisualStyleBackColor = false;
            this.buttonSaveDepense2.Click += new System.EventHandler(this.buttonSaveDepense2_Click);
            // 
            // buttonExpenseCancel2
            // 
            this.buttonExpenseCancel2.BackColor = System.Drawing.Color.Transparent;
            this.buttonExpenseCancel2.Location = new System.Drawing.Point(267, 80);
            this.buttonExpenseCancel2.Name = "buttonExpenseCancel2";
            this.buttonExpenseCancel2.Size = new System.Drawing.Size(60, 22);
            this.buttonExpenseCancel2.TabIndex = 2;
            this.buttonExpenseCancel2.Text = "Annuler";
            this.buttonExpenseCancel2.UseVisualStyleBackColor = false;
            this.buttonExpenseCancel2.Click += new System.EventHandler(this.buttonExpenseCancel2_Click);
            // 
            // buttonDelDepense2
            // 
            this.buttonDelDepense2.BackColor = System.Drawing.Color.Transparent;
            this.buttonDelDepense2.Location = new System.Drawing.Point(345, 80);
            this.buttonDelDepense2.Name = "buttonDelDepense2";
            this.buttonDelDepense2.Size = new System.Drawing.Size(56, 22);
            this.buttonDelDepense2.TabIndex = 3;
            this.buttonDelDepense2.Text = "Effacer";
            this.buttonDelDepense2.UseVisualStyleBackColor = false;
            this.buttonDelDepense2.Click += new System.EventHandler(this.buttonDelDepense2_Click);
            // 
            // labelFirstTimeInMonth2
            // 
            this.labelFirstTimeInMonth2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFirstTimeInMonth2.AutoSize = true;
            this.labelFirstTimeInMonth2.BackColor = System.Drawing.Color.Transparent;
            this.labelFirstTimeInMonth2.Location = new System.Drawing.Point(1251, 263);
            this.labelFirstTimeInMonth2.Name = "labelFirstTimeInMonth2";
            this.labelFirstTimeInMonth2.Size = new System.Drawing.Size(50, 13);
            this.labelFirstTimeInMonth2.TabIndex = 92;
            this.labelFirstTimeInMonth2.Text = "1ère fois:";
            this.labelFirstTimeInMonth2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelFirstTimeInMonth2.Visible = false;
            // 
            // labelSecondTimeInMonth2
            // 
            this.labelSecondTimeInMonth2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSecondTimeInMonth2.AutoSize = true;
            this.labelSecondTimeInMonth2.BackColor = System.Drawing.Color.Transparent;
            this.labelSecondTimeInMonth2.Location = new System.Drawing.Point(1251, 264);
            this.labelSecondTimeInMonth2.Name = "labelSecondTimeInMonth2";
            this.labelSecondTimeInMonth2.Size = new System.Drawing.Size(55, 13);
            this.labelSecondTimeInMonth2.TabIndex = 93;
            this.labelSecondTimeInMonth2.Text = "2ème fois:";
            this.labelSecondTimeInMonth2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSecondTimeInMonth2.Visible = false;
            // 
            // comboBoxFirstTimeInMonth2
            // 
            this.comboBoxFirstTimeInMonth2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFirstTimeInMonth2.Items.AddRange(new object[] {
            "1er",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "dernier jour"});
            this.comboBoxFirstTimeInMonth2.Location = new System.Drawing.Point(1370, 261);
            this.comboBoxFirstTimeInMonth2.Name = "comboBoxFirstTimeInMonth2";
            this.comboBoxFirstTimeInMonth2.Size = new System.Drawing.Size(96, 21);
            this.comboBoxFirstTimeInMonth2.TabIndex = 18;
            this.comboBoxFirstTimeInMonth2.Text = "1er";
            this.comboBoxFirstTimeInMonth2.Visible = false;
            // 
            // comboBoxSecondTimeInMonth2
            // 
            this.comboBoxSecondTimeInMonth2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSecondTimeInMonth2.Items.AddRange(new object[] {
            "1er",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "dernier jour"});
            this.comboBoxSecondTimeInMonth2.Location = new System.Drawing.Point(1370, 260);
            this.comboBoxSecondTimeInMonth2.Name = "comboBoxSecondTimeInMonth2";
            this.comboBoxSecondTimeInMonth2.Size = new System.Drawing.Size(96, 21);
            this.comboBoxSecondTimeInMonth2.TabIndex = 90;
            this.comboBoxSecondTimeInMonth2.Text = "15";
            this.comboBoxSecondTimeInMonth2.Visible = false;
            // 
            // tabPageHistorique
            // 
            this.tabPageHistorique.AutoScroll = true;
            this.tabPageHistorique.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.tabPageHistorique.Controls.Add(this.labelTitleHistorique5);
            this.tabPageHistorique.Controls.Add(this.buttonEffacer5);
            this.tabPageHistorique.Controls.Add(this.ListBoxHistorique5);
            this.tabPageHistorique.Location = new System.Drawing.Point(4, 22);
            this.tabPageHistorique.Name = "tabPageHistorique";
            this.tabPageHistorique.Size = new System.Drawing.Size(1497, 748);
            this.tabPageHistorique.TabIndex = 4;
            this.tabPageHistorique.Text = "Historique";
            // 
            // labelTitleHistorique5
            // 
            this.labelTitleHistorique5.BackColor = System.Drawing.Color.Transparent;
            this.labelTitleHistorique5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleHistorique5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.labelTitleHistorique5.Location = new System.Drawing.Point(3, 8);
            this.labelTitleHistorique5.Name = "labelTitleHistorique5";
            this.labelTitleHistorique5.Size = new System.Drawing.Size(974, 23);
            this.labelTitleHistorique5.TabIndex = 135;
            this.labelTitleHistorique5.Text = "Historique";
            this.labelTitleHistorique5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonEffacer5
            // 
            this.buttonEffacer5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEffacer5.BackColor = System.Drawing.Color.Transparent;
            this.buttonEffacer5.Location = new System.Drawing.Point(1390, 663);
            this.buttonEffacer5.Name = "buttonEffacer5";
            this.buttonEffacer5.Size = new System.Drawing.Size(80, 24);
            this.buttonEffacer5.TabIndex = 1;
            this.buttonEffacer5.Text = "Effacer";
            this.buttonEffacer5.UseVisualStyleBackColor = false;
            this.buttonEffacer5.Click += new System.EventHandler(this.buttonEffacer4_Click);
            // 
            // ListBoxHistorique5
            // 
            this.ListBoxHistorique5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxHistorique5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ListBoxHistorique5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListBoxHistorique5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBoxHistorique5.HorizontalScrollbar = true;
            this.ListBoxHistorique5.ItemHeight = 16;
            this.ListBoxHistorique5.Location = new System.Drawing.Point(24, 48);
            this.ListBoxHistorique5.Name = "ListBoxHistorique5";
            this.ListBoxHistorique5.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBoxHistorique5.Size = new System.Drawing.Size(1446, 516);
            this.ListBoxHistorique5.TabIndex = 0;
            // 
            // tabControlLeft
            // 
            this.tabControlLeft.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlLeft.Controls.Add(this.tabPageLeftSummary);
            this.tabControlLeft.Location = new System.Drawing.Point(0, 43);
            this.tabControlLeft.Multiline = true;
            this.tabControlLeft.Name = "tabControlLeft";
            this.tabControlLeft.SelectedIndex = 0;
            this.tabControlLeft.Size = new System.Drawing.Size(24, 755);
            this.tabControlLeft.TabIndex = 3;
            this.tabControlLeft.SelectedIndexChanged += new System.EventHandler(this.tabControlLeft_SelectedIndexChanged);
            // 
            // tabPageLeftSummary
            // 
            this.tabPageLeftSummary.Location = new System.Drawing.Point(23, 4);
            this.tabPageLeftSummary.Name = "tabPageLeftSummary";
            this.tabPageLeftSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLeftSummary.Size = new System.Drawing.Size(0, 747);
            this.tabPageLeftSummary.TabIndex = 2;
            this.tabPageLeftSummary.Text = "Sommaire";
            this.tabPageLeftSummary.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1518, 790);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.tabControlLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(1278, 718);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planificateur de budget familial";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageSolde.ResumeLayout(false);
            this.tabPageSolde.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPredictedBalances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnnuals)).EndInit();
            this.tabPageRevenus.ResumeLayout(false);
            this.tabPageRevenus.PerformLayout();
            this.panelBalanceAndButtons1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAmountAlreadyPayed1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageDépenses.ResumeLayout(false);
            this.tabPageDépenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAmountAlreadyPayed2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelBalanceAndButtons2.ResumeLayout(false);
            this.tabPageHistorique.ResumeLayout(false);
            this.tabControlLeft.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        
        private void comboBoxBudgetYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez vous sauvegarder vos changement?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                LocalSettings.SaveLocalSettings();
                SaveHistoryInfo();
            }
            else
            {
                File.Copy(LocalSettings.DatabaseBackupPath, LocalSettings.DatabasePath, true);
            }

            LocalSettings.DatabaseName = comboBoxBudgetName.Text.Trim();

            File.Copy(LocalSettings.DatabasePath, LocalSettings.DatabaseBackupPath, true);
            LoadInfoFromDatabase();
            AdjustTabs();
        }

        void TextBoxNotes0_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Exception exception;
                int currentAccountId = GetSelectedAccountId();
                if (currentAccountId != -1)
                {
                    TAccountInfo accountInfo = ClassAccounts.GetAccounts().AccountsInfo[currentAccountId];
                    accountInfo.Note = TextBoxNotes0.Text;

                    ClassAccounts.GetAccounts().SaveAccountsInDataStorage(out exception);
                    if (exception != null)
                    {
                        MessageBox.Show(exception.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void listBoxToCome0_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                DrawListBoxItemsWithColors(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void listBoxToCome0_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listBoxToComeExpense.SelectedIndex >= 0)
                {
                    TDisplayInfo info = listBoxToComeExpense.Items[listBoxToComeExpense.SelectedIndex] as TDisplayInfo;

                    if (m_currentAccountId == -1)
                    {
                        string accountName = ClassAccounts.GetAccounts().GetAccountNameFromId(info.AccountId);
                        tabControlLeft.SelectedTab = tabControlLeft.TabPages[accountName];
                    }
                    if (info != null)
                    {
                        int id = GetListIndexFromId(ListBoxDepenses2, info.ID);
                        if (id >= 0)
                            ListBoxDepenses2.SelectedIndex = id;
                        tabControlMain.SelectedIndex = 2;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void listBoxToCome0_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                AddWarningTooltip(ref m_toComeMouseOverIndex, listBoxToComeExpense, toolTipToCome0, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void listBoxToComeIncome_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                DrawListBoxItemsWithColors(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void listBoxToComeIncome_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listBoxToComeIncome.SelectedIndex >= 0)
                {
                    TDisplayInfo info = listBoxToComeIncome.Items[listBoxToComeIncome.SelectedIndex] as TDisplayInfo;

                    if (m_currentAccountId == -1)
                    {
                        string accountName = ClassAccounts.GetAccounts().GetAccountNameFromId(info.AccountId);
                        tabControlLeft.SelectedTab = tabControlLeft.TabPages[accountName];
                    }
                    if (info != null)
                    {
                        int id = GetListIndexFromId(ListBoxRevenus1, info.ID);
                        if (id >= 0)
                            ListBoxRevenus1.SelectedIndex = id;
                        tabControlMain.SelectedIndex = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void listBoxToComeIncome_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                AddWarningTooltip(ref m_toComeMouseOverIndex, listBoxToComeIncome, toolTipToComeIncome, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void ListBoxDepenses2_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                DrawListBoxItemsWithColors(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        void ListBoxDepenses2_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                AddWarningTooltip(ref m_expensesMouseOverIndex, ListBoxDepenses2, toolTipExpenses2, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void ListBoxRevenus1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                DrawListBoxItemsWithColors(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        void ListBoxRevenus1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                AddWarningTooltip(ref m_incomesMouseOverIndex, ListBoxRevenus1, toolTipRevenus1, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void ListBoxRevenus1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                m_incomesDisplayData.SelectedIndexChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void ListBoxDepenses2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                m_expensesDisplayData.SelectedIndexChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        
        void tabControlLeft_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdjustTabs();
        }

        void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.Compare(tabControlLeft.SelectedTab.Name, TAB_SUMMARY) == 0)
                return;
            try
            {
                switch (m_lastTabControlIndex)
                {
                    case 1:
                        m_incomesDisplayData.SavePartialTransaction();
                        break;
                    case 2:
                        m_expensesDisplayData.SavePartialTransaction();
                        break;
                }
                switch (tabControlMain.SelectedIndex)
                {
                    case 1:
                        m_incomesDisplayData.SetDefaultSelectedIndex();
                        ListBoxRevenus1.Focus();
                        break;
                    case 2:
                        m_expensesDisplayData.SetDefaultSelectedIndex();
                        ListBoxDepenses2.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
            m_lastTabControlIndex = tabControlMain.SelectedIndex;
        }

        #endregion

        #region Transaction info modified events

        private void radioOneShotTrans1_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (m_incomesDisplayData != null)
                    m_incomesDisplayData.UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void radioPeriodicTrans1_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (m_incomesDisplayData != null)
                    m_incomesDisplayData.UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void radioOneTimeInMonthTrans1_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (m_incomesDisplayData != null)
                    m_incomesDisplayData.UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void radioTwoTimesInMonthTrans1_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (m_incomesDisplayData != null)
                    m_incomesDisplayData.UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void radioButtonIsManual1_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (m_incomesDisplayData != null)
                    m_incomesDisplayData.TransactionModeChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }
        private void radioButtonIsAutomatic1_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (m_incomesDisplayData != null)
                    m_incomesDisplayData.TransactionModeChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void comboBoxAmountPeriod2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (m_expensesDisplayData != null)
                    m_expensesDisplayData.UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void comboBoxPeriodLength1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_incomesDisplayData != null)
                    m_incomesDisplayData.UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void comboBoxPeriodLength2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_expensesDisplayData != null)
                    m_expensesDisplayData.UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void radioOneShotTrans2_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (m_expensesDisplayData != null)
                    m_expensesDisplayData.UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void radioPeriodicTrans2_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (m_expensesDisplayData != null)
                    m_expensesDisplayData.UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void radioOneTimeInMonthTrans2_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (m_expensesDisplayData != null)
                    m_expensesDisplayData.UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void radioTwoTimesInMonthTrans2_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (m_expensesDisplayData != null)
                    m_expensesDisplayData.UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void radioButtonIsManual2_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (m_expensesDisplayData != null)
                    m_expensesDisplayData.TransactionModeChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void radioButtonIsAutomatic2_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (m_expensesDisplayData != null)
                    m_expensesDisplayData.TransactionModeChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        #endregion

        #region Buttons click events

        private void buttonMaximizeChart_Click(object sender, EventArgs e)
        {
            ChartWindow chartWindow = new ChartWindow(LocalSettings.BudgetYear, m_currentAccountId);
            chartWindow.ShowDialog(this);
        }

        private void buttonNewRevenu1_Click(object sender, EventArgs e)
        {
            try
            {
                m_incomesDisplayData.AddNewTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonIncomeCancel1_Click(object sender, EventArgs e)
        {
            try
            {
                m_incomesDisplayData.CancelPartialTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonSaveRevenu1_Click(object sender, EventArgs e)
        {
            try
            {
                m_incomesDisplayData.SaveTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonDelRevenu1_Click(object sender, EventArgs e)
        {
            try
            {
                m_incomesDisplayData.DeleteTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonNewDepense2_Click(object sender, EventArgs e)
        {
            try
            {
                m_expensesDisplayData.AddNewTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonSaveDepense2_Click(object sender, EventArgs e)
        {
            try
            {
                m_expensesDisplayData.SaveTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }


        private void buttonExpenseCancel2_Click(object sender, EventArgs e)
        {
            try
            {
                m_expensesDisplayData.CancelPartialTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonDelDepense2_Click(object sender, EventArgs e)
        {
            try
            {
                m_expensesDisplayData.DeleteTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

      

        private void buttonEffacer4_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteHistorique();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonUpIncome_Click(object sender, EventArgs e)
        {
            try
            {
                PutItemUpInList(ListBoxRevenus1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonDownIncome_Click(object sender, EventArgs e)
        {
            try
            {
                PutItemDownInList(ListBoxRevenus1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonUpExpenses_Click(object sender, EventArgs e)
        {
            try
            {
                PutItemUpInList(ListBoxDepenses2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonDownExpenses_Click(object sender, EventArgs e)
        {
            try
            {
                PutItemDownInList(ListBoxDepenses2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        #endregion

        #region Menu click events

        private void créerUnNouveauBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddBudgetForm form = new AddBudgetForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.Success)
                    {
                        try
                        {
                            string newFileName = form.NewBudgetName + ".mdb";
                            string newFilePath = ClassTools.GetConfigDir() + newFileName;
                            if (System.IO.File.Exists(newFilePath))
                            {
                                if (MessageBox.Show("Un budget avec le même nom existe déjà. Voulez-vous le remplacer? Attention, vous perdrez toutes vos données.", "Avertissement", MessageBoxButtons.YesNo) == DialogResult.No)
                                    return;
                            }
                            if (!string.IsNullOrEmpty(form.OldBudgetName))
                            {
                                System.IO.File.Copy(ClassTools.GetConfigDir() + form.OldBudgetName + ".mdb", newFilePath, true);
                            }
                            else
                                System.IO.File.Copy(ClassTools.GetConfigDir() + "EmptyBudget.mdb", newFilePath, true);

                            LocalSettings.DatabaseName = form.NewBudgetName;
                            comboBoxBudgetName.SelectedIndexChanged -= new System.EventHandler(this.comboBoxBudgetYear_SelectedIndexChanged);
                            Utils.FillComboBudgetName(comboBoxBudgetName);
                            comboBoxBudgetName.SelectedIndexChanged += new System.EventHandler(this.comboBoxBudgetYear_SelectedIndexChanged);
            
                            LoadInfoFromDatabase(!string.IsNullOrEmpty(form.OldBudgetName));
                            AdjustTabs();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Impossible de sauver le budget sous le nom " + NewName + ": " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void menuStripMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ajouterUnCompteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewNameForm newAccountForm = new NewNameForm(this, "Nouveau compte", "Nom du compte");

                if (newAccountForm.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(NewName))
                    {
                        AddAccount(NewName);
                        LoadInfoFromDatabase();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void renommerUnCompteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RenameAccount form = new RenameAccount(this);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(NewName))
                    {
                        int oldAccountId = ClassAccounts.GetAccounts().GetAccountIdFromName(OldName);
                        if (oldAccountId != -1)
                        {
                            AccountInfoData.RenameAccount(oldAccountId, NewName);
                            ClassAccounts.GetAccounts().GetSpecificAccount(oldAccountId).AccountName = NewName;
                            LoadInfoFromDatabase();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void supprimerUnCompteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteAccountForm form = new DeleteAccountForm(this, ClassAccounts.GetAccounts().GetAccountNameFromId(m_currentAccountId));

                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(NewName))
                    {
                        if (MessageBox.Show("Etes-vous sûr de vouloir supprimer le compte " + NewName + "?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            int accountId = ClassAccounts.GetAccounts().GetAccountIdFromName(NewName);
                            if (accountId > -1)
                            {
                                AccountInfoData.DeleteAccountInfo(accountId);
                                ClassAccounts.GetAccounts().AccountsInfo.Remove(accountId);
                                LoadInfoFromDatabase();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        #endregion

        #region Formula Text Boxes

        void textBoxSoldeActuel0_GotFocus(object sender, EventArgs e)
        {
            Utils.SetBackFormula(textBoxSoldeActuel0);
        }

        void textBoxSoldeActuel0_LostFocus(object sender, EventArgs e)
        {
            SoldeActuelChanged();
        }

        void textBoxSoldeActuel0_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SoldeActuelChanged();
            }
        }

        void textBoxAmountAlreadyPayed1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSaveRevenu1.Focus();
            }
        }

        void textBoxAmountAlreadyPayed2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSaveDepense2.Focus();
            }
        }

        void textBoxAmount1_GotFocus(object sender, EventArgs e)
        {
            Utils.SetBackFormula(textBoxAmount1);
        }

        void textBoxAmount1_LostFocus(object sender, EventArgs e)
        {
            Utils.SetResultFromFormula(textBoxAmount1);
        }

        void textBoxAmount1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSaveRevenu1.Focus();
            }
        }

        void textBoxAmount2_GotFocus(object sender, EventArgs e)
        {
            Utils.SetBackFormula(textBoxAmount2);
        }

        void textBoxAmount2_LostFocus(object sender, EventArgs e)
        {
            Utils.SetResultFromFormula(textBoxAmount2);
        }

        void textBoxAmount2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSaveDepense2.Focus();
            }
        }

        #endregion

        private void chartAnnuals_Click(object sender, EventArgs e)
        {
            ChartWindow chartWindow = new ChartWindow(LocalSettings.BudgetYear, m_currentAccountId);
            chartWindow.ShowDialog(this);
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog(this);
        }

        private void ChangeTitles()
        {
            /*string accountName = ClassAccounts.GetAccounts().GetAccountNameFromId(m_currentAccountId);
            labelTitleRevenus1.Text = "Revenus - " + accountName;
            labelTitleDépenses2.Text = "Dépenses - " + accountName;
            labelTitleVirements3.Text = "Virements - " + accountName;
            labelTitlePrêt4.Text = "Prêts / Hypothèques - " + accountName;
            labelTitleHistorique5.Text = "Historique - " + accountName;*/
        }

        private void chartPredictedBalances_Click(object sender, EventArgs e)
        {
            DateTime endDate = CurrentEndPredictionDate;
            DateTime startDate = (DateTime.Now.Date >= CurrentStartPredictionDate.Date ? DateTime.Now.AddDays(1) : CurrentStartPredictionDate);
            double soldeActuel = Utils.ConvertToDouble(textBoxSoldeActuel0.Text.Trim());

            var chartWindow = new ChartPredictedBalanceWindow(this, startDate, endDate, soldeActuel, EPeriodLength.e_PerWeek);
            chartWindow.ShowDialog(this);
        }

        private void labelAVenir_Click(object sender, EventArgs e)
        {

        }
    }
}
