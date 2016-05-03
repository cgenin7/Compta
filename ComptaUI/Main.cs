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
        private TabPage tabPagePlacements;
        private Label labelProfitPlacements;
        private Label label12;
        private Label labelValeurPlacements;
        private Label label11;
        private Label label5;
        private Button buttonDeleteRendement;
        private Button buttonDeletePlacement;
        private Label labelRendementTotal;
        private Label labelInvestissementTotal;
        private Button buttonNouveauRendement;
        private ComboBox comboBoxRendement;
        private DateTimePicker dateRendement;
        private TextBox textBoxMontantRendement;
        private TextBox textBoxMontantPlacement;
        private Label label6;
        private Label label7;
        private Label label8;
        private ListBox listBoxRendements;
        private Button buttonNouveauPlacement;
        private Label labelTitlePlacements;
        private ListBox listBoxPlacements;
        private ComboBox comboBoxPlacement;
        private DateTimePicker datePlacement;
        private Label label4;
        private Label label3;
        private Label label2;
        private TabPage tabPagePrets;
        private ComboBox comboBoxInterestsPayDay;
        private Label labelInterestsPayDay;
        private TextBox textBox2;
        private TextBox textBoxInterestRate4;
        private TextBox textBoxPaiementAmount4;
        private DataGridView dataGridViewAmountAlreadyPayed4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private TextBox textBoxAmount4;
        private TextBox textBoxPretName4;
        private TextBox textBoxNotes4;
        private TextBox textBoxPeriod4;
        private Label labelCategory4;
        private ComboBox comboBoxCategory4;
        private CheckBox checkBoxRemoveFromAnnualReport4;
        private Label labelPercent4;
        private Label labelInterestRate4;
        private Label labelPaiementType4;
        private ComboBox comboBoxPaiementType4;
        private Label labelPretType4;
        private ComboBox comboBoxPretType4;
        private Panel panelBalanceAndButtons4;
        private Label labelWarning4;
        private Label labelBalance4;
        private Button buttonSavePret4;
        private Button buttonDeletePret4;
        private Button buttonCancelPret4;
        private Panel panel5;
        private RadioButton radioButtonIsAutomatic4;
        private RadioButton radioButtonIsManual4;
        private Label labelNotes4;
        private Label labelDollars4;
        private Label labelAmount4;
        private Label labelPretName4;
        private DateTimePicker dateStart4;
        private Label labelStartDate4;
        private RadioButton radioTwoTimesInMonthTrans4;
        private RadioButton radioPeriodicTrans4;
        private Label labelPeriod4;
        private Button buttonDownPrets;
        private Button buttonUpPrets;
        private ListBox listBoxPrets4;
        private Label labelPretTotal;
        private Label labelTitlePrêt4;
        private Button buttonNewPret;
        private ComboBox comboBoxSecondTimeInMonth4;
        private Label labelFirstTimeInMonth4;
        private Label labelSecondTimeInMonth4;
        private ComboBox comboBoxPeriodLength4;
        private ComboBox comboBoxFirstTimeInMonth4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAmortissement;
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
        private ListBoxSortedByDate listBoxToCome0;
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
        private ToolStripMenuItem aProposToolStripMenuItem;
        

		#endregion

        public FormMain()
        {
            //
            // Required for Windows Form Designer support
            //
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 150D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, -30D);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabPageCompte1 = new System.Windows.Forms.TabPage();
            this.tabPageCompte3 = new System.Windows.Forms.TabPage();
            this.tabPageCompte2 = new System.Windows.Forms.TabPage();
            this.toolTipRevenus1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipExpenses2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipToCome0 = new System.Windows.Forms.ToolTip(this.components);
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
            this.listBoxToCome0 = new Compta.ListBoxSortedByDate();
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
            this.comboBoxFirstTimeInMonth1 = new System.Windows.Forms.ComboBox();
            this.labelSecondTimeInMonth1 = new System.Windows.Forms.Label();
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
            this.labelPeriod1 = new System.Windows.Forms.Label();
            this.comboBoxSecondTimeInMonth1 = new System.Windows.Forms.ComboBox();
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
            this.comboBoxSecondTimeInMonth2 = new System.Windows.Forms.ComboBox();
            this.labelFirstTimeInMonth2 = new System.Windows.Forms.Label();
            this.labelSecondTimeInMonth2 = new System.Windows.Forms.Label();
            this.comboBoxFirstTimeInMonth2 = new System.Windows.Forms.ComboBox();
            this.tabPagePrets = new System.Windows.Forms.TabPage();
            this.comboBoxInterestsPayDay = new System.Windows.Forms.ComboBox();
            this.labelInterestsPayDay = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxInterestRate4 = new System.Windows.Forms.TextBox();
            this.textBoxPaiementAmount4 = new System.Windows.Forms.TextBox();
            this.dataGridViewAmountAlreadyPayed4 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBoxAmount4 = new System.Windows.Forms.TextBox();
            this.textBoxPretName4 = new System.Windows.Forms.TextBox();
            this.textBoxNotes4 = new System.Windows.Forms.TextBox();
            this.textBoxPeriod4 = new System.Windows.Forms.TextBox();
            this.labelCategory4 = new System.Windows.Forms.Label();
            this.comboBoxCategory4 = new System.Windows.Forms.ComboBox();
            this.checkBoxRemoveFromAnnualReport4 = new System.Windows.Forms.CheckBox();
            this.labelPercent4 = new System.Windows.Forms.Label();
            this.labelInterestRate4 = new System.Windows.Forms.Label();
            this.labelPaiementType4 = new System.Windows.Forms.Label();
            this.comboBoxPaiementType4 = new System.Windows.Forms.ComboBox();
            this.labelPretType4 = new System.Windows.Forms.Label();
            this.comboBoxPretType4 = new System.Windows.Forms.ComboBox();
            this.panelBalanceAndButtons4 = new System.Windows.Forms.Panel();
            this.labelWarning4 = new System.Windows.Forms.Label();
            this.labelBalance4 = new System.Windows.Forms.Label();
            this.buttonSavePret4 = new System.Windows.Forms.Button();
            this.buttonDeletePret4 = new System.Windows.Forms.Button();
            this.buttonCancelPret4 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioButtonIsAutomatic4 = new System.Windows.Forms.RadioButton();
            this.radioButtonIsManual4 = new System.Windows.Forms.RadioButton();
            this.labelNotes4 = new System.Windows.Forms.Label();
            this.labelDollars4 = new System.Windows.Forms.Label();
            this.labelAmount4 = new System.Windows.Forms.Label();
            this.labelPretName4 = new System.Windows.Forms.Label();
            this.dateStart4 = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate4 = new System.Windows.Forms.Label();
            this.radioTwoTimesInMonthTrans4 = new System.Windows.Forms.RadioButton();
            this.radioPeriodicTrans4 = new System.Windows.Forms.RadioButton();
            this.labelPeriod4 = new System.Windows.Forms.Label();
            this.buttonDownPrets = new System.Windows.Forms.Button();
            this.buttonUpPrets = new System.Windows.Forms.Button();
            this.listBoxPrets4 = new System.Windows.Forms.ListBox();
            this.labelPretTotal = new System.Windows.Forms.Label();
            this.labelTitlePrêt4 = new System.Windows.Forms.Label();
            this.buttonNewPret = new System.Windows.Forms.Button();
            this.labelFirstTimeInMonth4 = new System.Windows.Forms.Label();
            this.labelSecondTimeInMonth4 = new System.Windows.Forms.Label();
            this.comboBoxPeriodLength4 = new System.Windows.Forms.ComboBox();
            this.chartAmortissement = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBoxSecondTimeInMonth4 = new System.Windows.Forms.ComboBox();
            this.comboBoxFirstTimeInMonth4 = new System.Windows.Forms.ComboBox();
            this.tabPagePlacements = new System.Windows.Forms.TabPage();
            this.labelProfitPlacements = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelValeurPlacements = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDeleteRendement = new System.Windows.Forms.Button();
            this.buttonDeletePlacement = new System.Windows.Forms.Button();
            this.labelRendementTotal = new System.Windows.Forms.Label();
            this.labelInvestissementTotal = new System.Windows.Forms.Label();
            this.buttonNouveauRendement = new System.Windows.Forms.Button();
            this.comboBoxRendement = new System.Windows.Forms.ComboBox();
            this.dateRendement = new System.Windows.Forms.DateTimePicker();
            this.textBoxMontantRendement = new System.Windows.Forms.TextBox();
            this.textBoxMontantPlacement = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listBoxRendements = new System.Windows.Forms.ListBox();
            this.buttonNouveauPlacement = new System.Windows.Forms.Button();
            this.labelTitlePlacements = new System.Windows.Forms.Label();
            this.listBoxPlacements = new System.Windows.Forms.ListBox();
            this.comboBoxPlacement = new System.Windows.Forms.ComboBox();
            this.datePlacement = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.tabPagePrets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAmountAlreadyPayed4)).BeginInit();
            this.panelBalanceAndButtons4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAmortissement)).BeginInit();
            this.tabPagePlacements.SuspendLayout();
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
            this.tabControlMain.Controls.Add(this.tabPagePrets);
            this.tabControlMain.Controls.Add(this.tabPagePlacements);
            this.tabControlMain.Controls.Add(this.tabPageHistorique);
            this.tabControlMain.Location = new System.Drawing.Point(23, 28);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.ShowToolTips = true;
            this.tabControlMain.Size = new System.Drawing.Size(1504, 779);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageSolde
            // 
            this.tabPageSolde.AutoScroll = true;
            this.tabPageSolde.AutoScrollMinSize = new System.Drawing.Size(1225, 650);
            this.tabPageSolde.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.tabPageSolde.Controls.Add(this.listBoxToCome0);
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
            this.tabPageSolde.Location = new System.Drawing.Point(4, 25);
            this.tabPageSolde.Name = "tabPageSolde";
            this.tabPageSolde.Size = new System.Drawing.Size(1496, 750);
            this.tabPageSolde.TabIndex = 0;
            this.tabPageSolde.Text = "Solde des comptes";
            // 
            // listBoxToCome0
            // 
            this.listBoxToCome0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxToCome0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.listBoxToCome0.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxToCome0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxToCome0.FormattingEnabled = true;
            this.listBoxToCome0.ItemHeight = 16;
            this.listBoxToCome0.Location = new System.Drawing.Point(18, 288);
            this.listBoxToCome0.MinimumSize = new System.Drawing.Size(531, 148);
            this.listBoxToCome0.Name = "listBoxToCome0";
            this.listBoxToCome0.Size = new System.Drawing.Size(651, 276);
            this.listBoxToCome0.TabIndex = 8;
            this.listBoxToCome0.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxToCome0_DrawItem);
            this.listBoxToCome0.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxToCome0_MouseDoubleClick);
            this.listBoxToCome0.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxToCome0_MouseMove);
            // 
            // TextBoxNotes0
            // 
            this.TextBoxNotes0.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxNotes0.BackColor = System.Drawing.Color.White;
            this.TextBoxNotes0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxNotes0.Location = new System.Drawing.Point(18, 620);
            this.TextBoxNotes0.Multiline = true;
            this.TextBoxNotes0.Name = "TextBoxNotes0";
            this.TextBoxNotes0.Size = new System.Drawing.Size(651, 123);
            this.TextBoxNotes0.TabIndex = 10;
            this.TextBoxNotes0.TextChanged += new System.EventHandler(this.TextBoxNotes0_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(714, 272);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 26);
            this.textBox1.TabIndex = 136;
            this.textBox1.Text = "Répartition annuelle:";
            // 
            // textBoxSoldesPredits
            // 
            this.textBoxSoldesPredits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSoldesPredits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.textBoxSoldesPredits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSoldesPredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSoldesPredits.Location = new System.Drawing.Point(626, 16);
            this.textBoxSoldesPredits.Multiline = true;
            this.textBoxSoldesPredits.Name = "textBoxSoldesPredits";
            this.textBoxSoldesPredits.Size = new System.Drawing.Size(850, 21);
            this.textBoxSoldesPredits.TabIndex = 120;
            this.textBoxSoldesPredits.Text = "Soldes prédits:";
            this.textBoxSoldesPredits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxSoldeActuel0
            // 
            this.textBoxSoldeActuel0.BackColor = System.Drawing.Color.White;
            this.textBoxSoldeActuel0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSoldeActuel0.Location = new System.Drawing.Point(254, 45);
            this.textBoxSoldeActuel0.Name = "textBoxSoldeActuel0";
            this.textBoxSoldeActuel0.Size = new System.Drawing.Size(149, 22);
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
            this.buttonMaximizeChart.Location = new System.Drawing.Point(1151, 677);
            this.buttonMaximizeChart.Name = "buttonMaximizeChart";
            this.buttonMaximizeChart.Size = new System.Drawing.Size(30, 29);
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
            this.labelAnnualProfits.Location = new System.Drawing.Point(722, 725);
            this.labelAnnualProfits.Name = "labelAnnualProfits";
            this.labelAnnualProfits.Size = new System.Drawing.Size(459, 18);
            this.labelAnnualProfits.TabIndex = 138;
            this.labelAnnualProfits.Text = "Surplus annuel de 400 $ (3%).";
            this.labelAnnualProfits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxBudgetName
            // 
            this.comboBoxBudgetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxBudgetName.FormattingEnabled = true;
            this.comboBoxBudgetName.Location = new System.Drawing.Point(254, 45);
            this.comboBoxBudgetName.Name = "comboBoxBudgetName";
            this.comboBoxBudgetName.Size = new System.Drawing.Size(173, 24);
            this.comboBoxBudgetName.TabIndex = 3;
            // 
            // labelBudgetYear
            // 
            this.labelBudgetYear.AutoSize = true;
            this.labelBudgetYear.BackColor = System.Drawing.Color.Transparent;
            this.labelBudgetYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBudgetYear.Location = new System.Drawing.Point(28, 52);
            this.labelBudgetYear.Name = "labelBudgetYear";
            this.labelBudgetYear.Size = new System.Drawing.Size(61, 16);
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
            this.labelPredictedBalance0.Location = new System.Drawing.Point(251, 91);
            this.labelPredictedBalance0.Name = "labelPredictedBalance0";
            this.labelPredictedBalance0.Size = new System.Drawing.Size(28, 16);
            this.labelPredictedBalance0.TabIndex = 5;
            this.labelPredictedBalance0.Text = "0 $";
            // 
            // labelPredictedDate0
            // 
            this.labelPredictedDate0.AutoSize = true;
            this.labelPredictedDate0.BackColor = System.Drawing.Color.Transparent;
            this.labelPredictedDate0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPredictedDate0.Location = new System.Drawing.Point(28, 91);
            this.labelPredictedDate0.Name = "labelPredictedDate0";
            this.labelPredictedDate0.Size = new System.Drawing.Size(180, 16);
            this.labelPredictedDate0.TabIndex = 129;
            this.labelPredictedDate0.Text = "Solde à la fin de l\'année:";
            this.labelPredictedDate0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNotes0
            // 
            this.labelNotes0.BackColor = System.Drawing.Color.Transparent;
            this.labelNotes0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotes0.Location = new System.Drawing.Point(28, 590);
            this.labelNotes0.Name = "labelNotes0";
            this.labelNotes0.Size = new System.Drawing.Size(115, 26);
            this.labelNotes0.TabIndex = 18;
            this.labelNotes0.Text = "Notes";
            // 
            // labelAVenir
            // 
            this.labelAVenir.BackColor = System.Drawing.Color.Transparent;
            this.labelAVenir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAVenir.Location = new System.Drawing.Point(28, 260);
            this.labelAVenir.Name = "labelAVenir";
            this.labelAVenir.Size = new System.Drawing.Size(325, 26);
            this.labelAVenir.TabIndex = 16;
            this.labelAVenir.Text = "A venir d\'ici la fin du mois";
            // 
            // labelDollar0
            // 
            this.labelDollar0.BackColor = System.Drawing.Color.Transparent;
            this.labelDollar0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDollar0.Location = new System.Drawing.Point(410, 50);
            this.labelDollar0.Name = "labelDollar0";
            this.labelDollar0.Size = new System.Drawing.Size(17, 18);
            this.labelDollar0.TabIndex = 2;
            this.labelDollar0.Text = "$";
            // 
            // labelSoldeActuel0
            // 
            this.labelSoldeActuel0.AutoSize = true;
            this.labelSoldeActuel0.BackColor = System.Drawing.Color.Transparent;
            this.labelSoldeActuel0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSoldeActuel0.Location = new System.Drawing.Point(28, 51);
            this.labelSoldeActuel0.Name = "labelSoldeActuel0";
            this.labelSoldeActuel0.Size = new System.Drawing.Size(175, 16);
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
            this.chartPredictedBalances.Location = new System.Drawing.Point(402, 30);
            this.chartPredictedBalances.Margin = new System.Windows.Forms.Padding(0);
            this.chartPredictedBalances.MinimumSize = new System.Drawing.Size(664, 211);
            this.chartPredictedBalances.Name = "chartPredictedBalances";
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "DrawingStyle=Cylinder, LabelStyle=Top, MaxPixelPointWidth=10";
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
            this.chartPredictedBalances.Size = new System.Drawing.Size(1089, 243);
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
            this.chartAnnuals.Location = new System.Drawing.Point(714, 278);
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
            this.chartAnnuals.Size = new System.Drawing.Size(786, 455);
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
            this.tabPageRevenus.Controls.Add(this.comboBoxFirstTimeInMonth1);
            this.tabPageRevenus.Controls.Add(this.labelSecondTimeInMonth1);
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
            this.tabPageRevenus.Controls.Add(this.labelPeriod1);
            this.tabPageRevenus.Controls.Add(this.comboBoxSecondTimeInMonth1);
            this.tabPageRevenus.Location = new System.Drawing.Point(4, 25);
            this.tabPageRevenus.Name = "tabPageRevenus";
            this.tabPageRevenus.Size = new System.Drawing.Size(1496, 750);
            this.tabPageRevenus.TabIndex = 1;
            this.tabPageRevenus.Text = "Revenus";
            // 
            // checkBoxRemoveFromAnnualReport1
            // 
            this.checkBoxRemoveFromAnnualReport1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxRemoveFromAnnualReport1.Location = new System.Drawing.Point(1017, 170);
            this.checkBoxRemoveFromAnnualReport1.Name = "checkBoxRemoveFromAnnualReport1";
            this.checkBoxRemoveFromAnnualReport1.Size = new System.Drawing.Size(213, 19);
            this.checkBoxRemoveFromAnnualReport1.TabIndex = 10;
            this.checkBoxRemoveFromAnnualReport1.Text = "Exclure du bilan annuel";
            this.checkBoxRemoveFromAnnualReport1.UseVisualStyleBackColor = true;
            // 
            // labelCategory1
            // 
            this.labelCategory1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCategory1.AutoSize = true;
            this.labelCategory1.Location = new System.Drawing.Point(1013, 127);
            this.labelCategory1.Name = "labelCategory1";
            this.labelCategory1.Size = new System.Drawing.Size(70, 16);
            this.labelCategory1.TabIndex = 127;
            this.labelCategory1.Text = "Catégorie:";
            // 
            // comboBoxCategory1
            // 
            this.comboBoxCategory1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCategory1.FormattingEnabled = true;
            this.comboBoxCategory1.Location = new System.Drawing.Point(1208, 123);
            this.comboBoxCategory1.MaxDropDownItems = 20;
            this.comboBoxCategory1.Name = "comboBoxCategory1";
            this.comboBoxCategory1.Size = new System.Drawing.Size(254, 24);
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
            this.panelBalanceAndButtons1.Location = new System.Drawing.Point(999, 621);
            this.panelBalanceAndButtons1.Name = "panelBalanceAndButtons1";
            this.panelBalanceAndButtons1.Size = new System.Drawing.Size(495, 120);
            this.panelBalanceAndButtons1.TabIndex = 125;
            // 
            // labelWarning1
            // 
            this.labelWarning1.BackColor = System.Drawing.Color.Transparent;
            this.labelWarning1.ForeColor = System.Drawing.Color.Red;
            this.labelWarning1.Location = new System.Drawing.Point(14, 58);
            this.labelWarning1.Name = "labelWarning1";
            this.labelWarning1.Size = new System.Drawing.Size(464, 30);
            this.labelWarning1.TabIndex = 4;
            this.labelWarning1.Text = "Le montant restant d\'ici au 15 septembre 2012 est de 1654 $. Il devrait être de 5" +
    "40 $. ";
            // 
            // labelBalance1
            // 
            this.labelBalance1.BackColor = System.Drawing.Color.Transparent;
            this.labelBalance1.Location = new System.Drawing.Point(14, 10);
            this.labelBalance1.Name = "labelBalance1";
            this.labelBalance1.Size = new System.Drawing.Size(467, 48);
            this.labelBalance1.TabIndex = 0;
            this.labelBalance1.Text = "D\'ici au 31 décembre 2012: 150 $ restant à dépenser sur un total de 1250 $. Proch" +
    "ain versement de 1456 $ le 5 mars 2012. Montant dépensé en moyenne par 2 semaine" +
    "s: 580 $.";
            // 
            // buttonSaveRevenu1
            // 
            this.buttonSaveRevenu1.BackColor = System.Drawing.Color.Transparent;
            this.buttonSaveRevenu1.Location = new System.Drawing.Point(190, 89);
            this.buttonSaveRevenu1.Name = "buttonSaveRevenu1";
            this.buttonSaveRevenu1.Size = new System.Drawing.Size(105, 26);
            this.buttonSaveRevenu1.TabIndex = 1;
            this.buttonSaveRevenu1.Text = "Sauvegarder";
            this.buttonSaveRevenu1.UseVisualStyleBackColor = false;
            this.buttonSaveRevenu1.Click += new System.EventHandler(this.buttonSaveRevenu1_Click);
            // 
            // buttonDelRevenu1
            // 
            this.buttonDelRevenu1.BackColor = System.Drawing.Color.Transparent;
            this.buttonDelRevenu1.Location = new System.Drawing.Point(384, 89);
            this.buttonDelRevenu1.Name = "buttonDelRevenu1";
            this.buttonDelRevenu1.Size = new System.Drawing.Size(67, 26);
            this.buttonDelRevenu1.TabIndex = 3;
            this.buttonDelRevenu1.Text = "Effacer";
            this.buttonDelRevenu1.UseVisualStyleBackColor = false;
            this.buttonDelRevenu1.Click += new System.EventHandler(this.buttonDelRevenu1_Click);
            // 
            // buttonIncomeCancel1
            // 
            this.buttonIncomeCancel1.BackColor = System.Drawing.Color.Transparent;
            this.buttonIncomeCancel1.Location = new System.Drawing.Point(302, 89);
            this.buttonIncomeCancel1.Name = "buttonIncomeCancel1";
            this.buttonIncomeCancel1.Size = new System.Drawing.Size(75, 26);
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
            this.dataGridAmountAlreadyPayed1.Location = new System.Drawing.Point(1071, 479);
            this.dataGridAmountAlreadyPayed1.MultiSelect = false;
            this.dataGridAmountAlreadyPayed1.Name = "dataGridAmountAlreadyPayed1";
            this.dataGridAmountAlreadyPayed1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridAmountAlreadyPayed1.RowHeadersVisible = false;
            this.dataGridAmountAlreadyPayed1.Size = new System.Drawing.Size(391, 160);
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
            this.textBoxPeriod1.Location = new System.Drawing.Point(1347, 282);
            this.textBoxPeriod1.Name = "textBoxPeriod1";
            this.textBoxPeriod1.Size = new System.Drawing.Size(48, 22);
            this.textBoxPeriod1.TabIndex = 17;
            this.textBoxPeriod1.Visible = false;
            // 
            // textBoxAmount1
            // 
            this.textBoxAmount1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAmount1.BackColor = System.Drawing.Color.White;
            this.textBoxAmount1.Location = new System.Drawing.Point(1208, 90);
            this.textBoxAmount1.Name = "textBoxAmount1";
            this.textBoxAmount1.Size = new System.Drawing.Size(86, 22);
            this.textBoxAmount1.TabIndex = 8;
            this.textBoxAmount1.GotFocus += new System.EventHandler(this.textBoxAmount1_GotFocus);
            this.textBoxAmount1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxAmount1_KeyUp);
            this.textBoxAmount1.LostFocus += new System.EventHandler(this.textBoxAmount1_LostFocus);
            // 
            // textBoxTransactionName1
            // 
            this.textBoxTransactionName1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTransactionName1.BackColor = System.Drawing.Color.White;
            this.textBoxTransactionName1.Location = new System.Drawing.Point(1208, 55);
            this.textBoxTransactionName1.Name = "textBoxTransactionName1";
            this.textBoxTransactionName1.Size = new System.Drawing.Size(254, 22);
            this.textBoxTransactionName1.TabIndex = 7;
            // 
            // TextBoxNotes1
            // 
            this.TextBoxNotes1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxNotes1.BackColor = System.Drawing.Color.White;
            this.TextBoxNotes1.Location = new System.Drawing.Point(1071, 361);
            this.TextBoxNotes1.Multiline = true;
            this.TextBoxNotes1.Name = "TextBoxNotes1";
            this.TextBoxNotes1.Size = new System.Drawing.Size(391, 59);
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
            this.ListBoxRevenus1.Location = new System.Drawing.Point(19, 55);
            this.ListBoxRevenus1.Name = "ListBoxRevenus1";
            this.ListBoxRevenus1.Size = new System.Drawing.Size(915, 644);
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
            this.panel1.Location = new System.Drawing.Point(999, 423);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 82);
            this.panel1.TabIndex = 123;
            // 
            // radioButtonIsAutomatic1
            // 
            this.radioButtonIsAutomatic1.AutoSize = true;
            this.radioButtonIsAutomatic1.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonIsAutomatic1.Location = new System.Drawing.Point(14, 6);
            this.radioButtonIsAutomatic1.Name = "radioButtonIsAutomatic1";
            this.radioButtonIsAutomatic1.Size = new System.Drawing.Size(324, 20);
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
            this.radioButtonIsManual1.Location = new System.Drawing.Point(14, 32);
            this.radioButtonIsManual1.Name = "radioButtonIsManual1";
            this.radioButtonIsManual1.Size = new System.Drawing.Size(305, 20);
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
            this.buttonDownIncome.Location = new System.Drawing.Point(944, 90);
            this.buttonDownIncome.Name = "buttonDownIncome";
            this.buttonDownIncome.Size = new System.Drawing.Size(30, 29);
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
            this.buttonUpIncome.Location = new System.Drawing.Point(944, 55);
            this.buttonUpIncome.Name = "buttonUpIncome";
            this.buttonUpIncome.Size = new System.Drawing.Size(30, 29);
            this.buttonUpIncome.TabIndex = 5;
            this.buttonUpIncome.UseVisualStyleBackColor = true;
            this.buttonUpIncome.Click += new System.EventHandler(this.buttonUpIncome_Click);
            // 
            // labelRevenuTotal
            // 
            this.labelRevenuTotal.AutoSize = true;
            this.labelRevenuTotal.Location = new System.Drawing.Point(16, 713);
            this.labelRevenuTotal.Name = "labelRevenuTotal";
            this.labelRevenuTotal.Size = new System.Drawing.Size(98, 16);
            this.labelRevenuTotal.TabIndex = 116;
            this.labelRevenuTotal.Text = "Revenu Total : ";
            // 
            // labelNotes1
            // 
            this.labelNotes1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNotes1.BackColor = System.Drawing.Color.Transparent;
            this.labelNotes1.Location = new System.Drawing.Point(1013, 361);
            this.labelNotes1.Name = "labelNotes1";
            this.labelNotes1.Size = new System.Drawing.Size(48, 19);
            this.labelNotes1.TabIndex = 111;
            this.labelNotes1.Text = "Notes :";
            // 
            // labelTitleRevenus1
            // 
            this.labelTitleRevenus1.BackColor = System.Drawing.Color.Transparent;
            this.labelTitleRevenus1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleRevenus1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.labelTitleRevenus1.Location = new System.Drawing.Point(4, 9);
            this.labelTitleRevenus1.Name = "labelTitleRevenus1";
            this.labelTitleRevenus1.Size = new System.Drawing.Size(927, 27);
            this.labelTitleRevenus1.TabIndex = 104;
            this.labelTitleRevenus1.Text = "Revenus";
            this.labelTitleRevenus1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDollar1
            // 
            this.labelDollar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDollar1.BackColor = System.Drawing.Color.Transparent;
            this.labelDollar1.Location = new System.Drawing.Point(1298, 90);
            this.labelDollar1.Name = "labelDollar1";
            this.labelDollar1.Size = new System.Drawing.Size(19, 18);
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
            this.comboBoxPeriodLength1.Location = new System.Drawing.Point(1402, 282);
            this.comboBoxPeriodLength1.Name = "comboBoxPeriodLength1";
            this.comboBoxPeriodLength1.Size = new System.Drawing.Size(60, 24);
            this.comboBoxPeriodLength1.TabIndex = 18;
            this.comboBoxPeriodLength1.Text = "jours";
            this.comboBoxPeriodLength1.Visible = false;
            this.comboBoxPeriodLength1.SelectedIndexChanged += new System.EventHandler(this.comboBoxPeriodLength1_SelectedIndexChanged);
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
            this.comboBoxFirstTimeInMonth1.Location = new System.Drawing.Point(1347, 318);
            this.comboBoxFirstTimeInMonth1.Name = "comboBoxFirstTimeInMonth1";
            this.comboBoxFirstTimeInMonth1.Size = new System.Drawing.Size(115, 24);
            this.comboBoxFirstTimeInMonth1.TabIndex = 54;
            this.comboBoxFirstTimeInMonth1.Text = "1er";
            this.comboBoxFirstTimeInMonth1.Visible = false;
            // 
            // labelSecondTimeInMonth1
            // 
            this.labelSecondTimeInMonth1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSecondTimeInMonth1.AutoSize = true;
            this.labelSecondTimeInMonth1.BackColor = System.Drawing.Color.Transparent;
            this.labelSecondTimeInMonth1.Location = new System.Drawing.Point(1208, 318);
            this.labelSecondTimeInMonth1.Name = "labelSecondTimeInMonth1";
            this.labelSecondTimeInMonth1.Size = new System.Drawing.Size(69, 16);
            this.labelSecondTimeInMonth1.TabIndex = 61;
            this.labelSecondTimeInMonth1.Text = "2ème fois:";
            this.labelSecondTimeInMonth1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSecondTimeInMonth1.Visible = false;
            // 
            // labelFirstTimeInMonth1
            // 
            this.labelFirstTimeInMonth1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFirstTimeInMonth1.AutoSize = true;
            this.labelFirstTimeInMonth1.BackColor = System.Drawing.Color.Transparent;
            this.labelFirstTimeInMonth1.Location = new System.Drawing.Point(1208, 318);
            this.labelFirstTimeInMonth1.Name = "labelFirstTimeInMonth1";
            this.labelFirstTimeInMonth1.Size = new System.Drawing.Size(62, 16);
            this.labelFirstTimeInMonth1.TabIndex = 60;
            this.labelFirstTimeInMonth1.Text = "1ère fois:";
            this.labelFirstTimeInMonth1.Visible = false;
            // 
            // labelAmount1
            // 
            this.labelAmount1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAmount1.BackColor = System.Drawing.Color.Transparent;
            this.labelAmount1.Location = new System.Drawing.Point(1013, 90);
            this.labelAmount1.Name = "labelAmount1";
            this.labelAmount1.Size = new System.Drawing.Size(125, 18);
            this.labelAmount1.TabIndex = 59;
            this.labelAmount1.Text = "Montant :";
            // 
            // labelTransactionName1
            // 
            this.labelTransactionName1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTransactionName1.BackColor = System.Drawing.Color.Transparent;
            this.labelTransactionName1.Location = new System.Drawing.Point(1013, 55);
            this.labelTransactionName1.Name = "labelTransactionName1";
            this.labelTransactionName1.Size = new System.Drawing.Size(144, 19);
            this.labelTransactionName1.TabIndex = 55;
            this.labelTransactionName1.Text = "Nom du revenu :";
            // 
            // dateEnd1
            // 
            this.dateEnd1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEnd1.CustomFormat = "dd MMM yyyy";
            this.dateEnd1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd1.Location = new System.Drawing.Point(1347, 245);
            this.dateEnd1.MaxDate = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.dateEnd1.MinDate = new System.DateTime(2011, 1, 1, 0, 0, 0, 0);
            this.dateEnd1.Name = "dateEnd1";
            this.dateEnd1.Size = new System.Drawing.Size(115, 22);
            this.dateEnd1.TabIndex = 16;
            this.dateEnd1.Value = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.dateEnd1.Visible = false;
            // 
            // dateStart1
            // 
            this.dateStart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateStart1.CustomFormat = "dd MMM yyyy";
            this.dateStart1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStart1.Location = new System.Drawing.Point(1347, 208);
            this.dateStart1.MaxDate = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.dateStart1.MinDate = new System.DateTime(2011, 1, 1, 0, 0, 0, 0);
            this.dateStart1.Name = "dateStart1";
            this.dateStart1.Size = new System.Drawing.Size(115, 22);
            this.dateStart1.TabIndex = 15;
            this.dateStart1.Value = new System.DateTime(2011, 1, 1, 0, 0, 0, 0);
            // 
            // labelEndDate1
            // 
            this.labelEndDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEndDate1.BackColor = System.Drawing.Color.Transparent;
            this.labelEndDate1.Location = new System.Drawing.Point(1208, 245);
            this.labelEndDate1.Name = "labelEndDate1";
            this.labelEndDate1.Size = new System.Drawing.Size(140, 23);
            this.labelEndDate1.TabIndex = 52;
            this.labelEndDate1.Text = "Dernier paiement le:";
            this.labelEndDate1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelEndDate1.Visible = false;
            // 
            // labelStartDate1
            // 
            this.labelStartDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStartDate1.BackColor = System.Drawing.Color.Transparent;
            this.labelStartDate1.Location = new System.Drawing.Point(1208, 208);
            this.labelStartDate1.Name = "labelStartDate1";
            this.labelStartDate1.Size = new System.Drawing.Size(132, 23);
            this.labelStartDate1.TabIndex = 49;
            this.labelStartDate1.Text = "Paiement le:";
            this.labelStartDate1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioTwoTimesInMonthTrans1
            // 
            this.radioTwoTimesInMonthTrans1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioTwoTimesInMonthTrans1.BackColor = System.Drawing.Color.Transparent;
            this.radioTwoTimesInMonthTrans1.Location = new System.Drawing.Point(1013, 283);
            this.radioTwoTimesInMonthTrans1.Name = "radioTwoTimesInMonthTrans1";
            this.radioTwoTimesInMonthTrans1.Size = new System.Drawing.Size(183, 19);
            this.radioTwoTimesInMonthTrans1.TabIndex = 14;
            this.radioTwoTimesInMonthTrans1.Text = "Revenu 2 fois par &mois";
            this.radioTwoTimesInMonthTrans1.UseVisualStyleBackColor = false;
            this.radioTwoTimesInMonthTrans1.CheckedChanged += new System.EventHandler(this.radioTwoTimesInMonthTrans1_CheckedChanged);
            // 
            // radioPeriodicTrans1
            // 
            this.radioPeriodicTrans1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioPeriodicTrans1.BackColor = System.Drawing.Color.Transparent;
            this.radioPeriodicTrans1.Location = new System.Drawing.Point(1013, 246);
            this.radioPeriodicTrans1.Name = "radioPeriodicTrans1";
            this.radioPeriodicTrans1.Size = new System.Drawing.Size(183, 23);
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
            this.radioOneShotTrans1.Location = new System.Drawing.Point(1013, 208);
            this.radioOneShotTrans1.Name = "radioOneShotTrans1";
            this.radioOneShotTrans1.Size = new System.Drawing.Size(163, 23);
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
            this.buttonNewRevenu1.Location = new System.Drawing.Point(810, 705);
            this.buttonNewRevenu1.Name = "buttonNewRevenu1";
            this.buttonNewRevenu1.Size = new System.Drawing.Size(125, 27);
            this.buttonNewRevenu1.TabIndex = 4;
            this.buttonNewRevenu1.Text = "Nouveau revenu";
            this.buttonNewRevenu1.UseVisualStyleBackColor = false;
            this.buttonNewRevenu1.Click += new System.EventHandler(this.buttonNewRevenu1_Click);
            // 
            // labelPeriod1
            // 
            this.labelPeriod1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPeriod1.AutoSize = true;
            this.labelPeriod1.BackColor = System.Drawing.Color.Transparent;
            this.labelPeriod1.Location = new System.Drawing.Point(1209, 285);
            this.labelPeriod1.Name = "labelPeriod1";
            this.labelPeriod1.Size = new System.Drawing.Size(62, 16);
            this.labelPeriod1.TabIndex = 62;
            this.labelPeriod1.Text = "Période :";
            this.labelPeriod1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPeriod1.Visible = false;
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
            this.comboBoxSecondTimeInMonth1.Location = new System.Drawing.Point(1347, 318);
            this.comboBoxSecondTimeInMonth1.Name = "comboBoxSecondTimeInMonth1";
            this.comboBoxSecondTimeInMonth1.Size = new System.Drawing.Size(115, 24);
            this.comboBoxSecondTimeInMonth1.TabIndex = 20;
            this.comboBoxSecondTimeInMonth1.Text = "15";
            this.comboBoxSecondTimeInMonth1.Visible = false;
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
            this.tabPageDépenses.Controls.Add(this.comboBoxSecondTimeInMonth2);
            this.tabPageDépenses.Controls.Add(this.labelFirstTimeInMonth2);
            this.tabPageDépenses.Controls.Add(this.labelSecondTimeInMonth2);
            this.tabPageDépenses.Controls.Add(this.comboBoxFirstTimeInMonth2);
            this.tabPageDépenses.Location = new System.Drawing.Point(4, 25);
            this.tabPageDépenses.Name = "tabPageDépenses";
            this.tabPageDépenses.Size = new System.Drawing.Size(1496, 750);
            this.tabPageDépenses.TabIndex = 2;
            this.tabPageDépenses.Text = "Dépenses";
            // 
            // checkBoxRemoveFromAnnualReport2
            // 
            this.checkBoxRemoveFromAnnualReport2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxRemoveFromAnnualReport2.Location = new System.Drawing.Point(1005, 158);
            this.checkBoxRemoveFromAnnualReport2.Name = "checkBoxRemoveFromAnnualReport2";
            this.checkBoxRemoveFromAnnualReport2.Size = new System.Drawing.Size(211, 20);
            this.checkBoxRemoveFromAnnualReport2.TabIndex = 8;
            this.checkBoxRemoveFromAnnualReport2.Text = "Exclure du bilan annuel";
            this.checkBoxRemoveFromAnnualReport2.UseVisualStyleBackColor = true;
            // 
            // labelCategory2
            // 
            this.labelCategory2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCategory2.AutoSize = true;
            this.labelCategory2.Location = new System.Drawing.Point(1001, 123);
            this.labelCategory2.Name = "labelCategory2";
            this.labelCategory2.Size = new System.Drawing.Size(70, 16);
            this.labelCategory2.TabIndex = 153;
            this.labelCategory2.Text = "Catégorie:";
            // 
            // comboBoxCategory2
            // 
            this.comboBoxCategory2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCategory2.FormattingEnabled = true;
            this.comboBoxCategory2.Location = new System.Drawing.Point(1208, 120);
            this.comboBoxCategory2.MaxDropDownItems = 20;
            this.comboBoxCategory2.Name = "comboBoxCategory2";
            this.comboBoxCategory2.Size = new System.Drawing.Size(254, 24);
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
            this.dataGridAmountAlreadyPayed2.Location = new System.Drawing.Point(1070, 481);
            this.dataGridAmountAlreadyPayed2.MultiSelect = false;
            this.dataGridAmountAlreadyPayed2.Name = "dataGridAmountAlreadyPayed2";
            this.dataGridAmountAlreadyPayed2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridAmountAlreadyPayed2.RowHeadersVisible = false;
            this.dataGridAmountAlreadyPayed2.Size = new System.Drawing.Size(386, 140);
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
            this.textBoxPeriod2.Location = new System.Drawing.Point(1347, 264);
            this.textBoxPeriod2.Name = "textBoxPeriod2";
            this.textBoxPeriod2.Size = new System.Drawing.Size(48, 22);
            this.textBoxPeriod2.TabIndex = 15;
            this.textBoxPeriod2.Visible = false;
            // 
            // textBoxAmount2
            // 
            this.textBoxAmount2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAmount2.BackColor = System.Drawing.Color.White;
            this.textBoxAmount2.Location = new System.Drawing.Point(1208, 88);
            this.textBoxAmount2.Name = "textBoxAmount2";
            this.textBoxAmount2.Size = new System.Drawing.Size(86, 22);
            this.textBoxAmount2.TabIndex = 6;
            this.textBoxAmount2.GotFocus += new System.EventHandler(this.textBoxAmount2_GotFocus);
            this.textBoxAmount2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxAmount2_KeyUp);
            this.textBoxAmount2.LostFocus += new System.EventHandler(this.textBoxAmount2_LostFocus);
            // 
            // textBoxTransactionName2
            // 
            this.textBoxTransactionName2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTransactionName2.BackColor = System.Drawing.Color.White;
            this.textBoxTransactionName2.Location = new System.Drawing.Point(1208, 55);
            this.textBoxTransactionName2.Name = "textBoxTransactionName2";
            this.textBoxTransactionName2.Size = new System.Drawing.Size(252, 22);
            this.textBoxTransactionName2.TabIndex = 5;
            // 
            // TextBoxNotes2
            // 
            this.TextBoxNotes2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxNotes2.BackColor = System.Drawing.Color.White;
            this.TextBoxNotes2.Location = new System.Drawing.Point(1055, 343);
            this.TextBoxNotes2.Multiline = true;
            this.TextBoxNotes2.Name = "TextBoxNotes2";
            this.TextBoxNotes2.Size = new System.Drawing.Size(405, 79);
            this.TextBoxNotes2.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.radioButtonIsAutomatic2);
            this.panel2.Controls.Add(this.radioButtonIsManual2);
            this.panel2.Location = new System.Drawing.Point(987, 422);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(473, 66);
            this.panel2.TabIndex = 150;
            // 
            // radioButtonIsAutomatic2
            // 
            this.radioButtonIsAutomatic2.AutoSize = true;
            this.radioButtonIsAutomatic2.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonIsAutomatic2.Checked = true;
            this.radioButtonIsAutomatic2.Location = new System.Drawing.Point(14, 13);
            this.radioButtonIsAutomatic2.Name = "radioButtonIsAutomatic2";
            this.radioButtonIsAutomatic2.Size = new System.Drawing.Size(311, 20);
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
            this.radioButtonIsManual2.Location = new System.Drawing.Point(14, 39);
            this.radioButtonIsManual2.Name = "radioButtonIsManual2";
            this.radioButtonIsManual2.Size = new System.Drawing.Size(292, 20);
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
            this.buttonDownExpenses.Location = new System.Drawing.Point(941, 90);
            this.buttonDownExpenses.Name = "buttonDownExpenses";
            this.buttonDownExpenses.Size = new System.Drawing.Size(30, 29);
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
            this.buttonUpExpenses.Location = new System.Drawing.Point(941, 55);
            this.buttonUpExpenses.Name = "buttonUpExpenses";
            this.buttonUpExpenses.Size = new System.Drawing.Size(30, 29);
            this.buttonUpExpenses.TabIndex = 3;
            this.buttonUpExpenses.UseVisualStyleBackColor = true;
            this.buttonUpExpenses.Click += new System.EventHandler(this.buttonUpExpenses_Click);
            // 
            // labelTotalExpenses
            // 
            this.labelTotalExpenses.AutoSize = true;
            this.labelTotalExpenses.Location = new System.Drawing.Point(16, 717);
            this.labelTotalExpenses.Name = "labelTotalExpenses";
            this.labelTotalExpenses.Size = new System.Drawing.Size(126, 16);
            this.labelTotalExpenses.TabIndex = 114;
            this.labelTotalExpenses.Text = "Dépenses Totales: ";
            // 
            // labelTitleDépenses2
            // 
            this.labelTitleDépenses2.BackColor = System.Drawing.Color.Transparent;
            this.labelTitleDépenses2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleDépenses2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.labelTitleDépenses2.Location = new System.Drawing.Point(4, 9);
            this.labelTitleDépenses2.Name = "labelTitleDépenses2";
            this.labelTitleDépenses2.Size = new System.Drawing.Size(912, 27);
            this.labelTitleDépenses2.TabIndex = 105;
            this.labelTitleDépenses2.Text = "Dépenses";
            this.labelTitleDépenses2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDollar2
            // 
            this.labelDollar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDollar2.BackColor = System.Drawing.Color.Transparent;
            this.labelDollar2.Location = new System.Drawing.Point(1307, 88);
            this.labelDollar2.Name = "labelDollar2";
            this.labelDollar2.Size = new System.Drawing.Size(19, 18);
            this.labelDollar2.TabIndex = 102;
            this.labelDollar2.Text = "$";
            this.labelDollar2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelNotes2
            // 
            this.labelNotes2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNotes2.BackColor = System.Drawing.Color.Transparent;
            this.labelNotes2.Location = new System.Drawing.Point(1001, 343);
            this.labelNotes2.Name = "labelNotes2";
            this.labelNotes2.Size = new System.Drawing.Size(48, 18);
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
            this.comboBoxPeriodLength2.Location = new System.Drawing.Point(1402, 264);
            this.comboBoxPeriodLength2.Name = "comboBoxPeriodLength2";
            this.comboBoxPeriodLength2.Size = new System.Drawing.Size(58, 24);
            this.comboBoxPeriodLength2.TabIndex = 16;
            this.comboBoxPeriodLength2.Text = "jours";
            this.comboBoxPeriodLength2.Visible = false;
            this.comboBoxPeriodLength2.SelectedIndexChanged += new System.EventHandler(this.comboBoxPeriodLength2_SelectedIndexChanged);
            // 
            // labelAmount2
            // 
            this.labelAmount2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAmount2.BackColor = System.Drawing.Color.Transparent;
            this.labelAmount2.Location = new System.Drawing.Point(1001, 90);
            this.labelAmount2.Name = "labelAmount2";
            this.labelAmount2.Size = new System.Drawing.Size(125, 18);
            this.labelAmount2.TabIndex = 91;
            this.labelAmount2.Text = "Montant :";
            // 
            // labelTransactionName2
            // 
            this.labelTransactionName2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTransactionName2.BackColor = System.Drawing.Color.Transparent;
            this.labelTransactionName2.Location = new System.Drawing.Point(1001, 55);
            this.labelTransactionName2.Name = "labelTransactionName2";
            this.labelTransactionName2.Size = new System.Drawing.Size(144, 19);
            this.labelTransactionName2.TabIndex = 89;
            this.labelTransactionName2.Text = "Nom de la dépense :";
            // 
            // dateEnd2
            // 
            this.dateEnd2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEnd2.CustomFormat = "dd MMM yyyy";
            this.dateEnd2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd2.Location = new System.Drawing.Point(1347, 227);
            this.dateEnd2.Name = "dateEnd2";
            this.dateEnd2.Size = new System.Drawing.Size(115, 22);
            this.dateEnd2.TabIndex = 14;
            this.dateEnd2.Value = new System.DateTime(2011, 12, 31, 0, 0, 0, 0);
            this.dateEnd2.Visible = false;
            // 
            // dateStart2
            // 
            this.dateStart2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateStart2.CustomFormat = "dd MMM yyyy";
            this.dateStart2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStart2.Location = new System.Drawing.Point(1347, 190);
            this.dateStart2.Name = "dateStart2";
            this.dateStart2.Size = new System.Drawing.Size(115, 22);
            this.dateStart2.TabIndex = 13;
            // 
            // labelEndDate2
            // 
            this.labelEndDate2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelEndDate2.BackColor = System.Drawing.Color.Transparent;
            this.labelEndDate2.Location = new System.Drawing.Point(1204, 225);
            this.labelEndDate2.Name = "labelEndDate2";
            this.labelEndDate2.Size = new System.Drawing.Size(134, 23);
            this.labelEndDate2.TabIndex = 86;
            this.labelEndDate2.Text = "Dernier paiement le:";
            this.labelEndDate2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelEndDate2.Visible = false;
            // 
            // labelStartDate2
            // 
            this.labelStartDate2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStartDate2.BackColor = System.Drawing.Color.Transparent;
            this.labelStartDate2.Location = new System.Drawing.Point(1204, 190);
            this.labelStartDate2.Name = "labelStartDate2";
            this.labelStartDate2.Size = new System.Drawing.Size(134, 23);
            this.labelStartDate2.TabIndex = 83;
            this.labelStartDate2.Text = "Paiement le:";
            this.labelStartDate2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioTwoTimesInMonthTrans2
            // 
            this.radioTwoTimesInMonthTrans2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioTwoTimesInMonthTrans2.BackColor = System.Drawing.Color.Transparent;
            this.radioTwoTimesInMonthTrans2.Location = new System.Drawing.Point(1005, 263);
            this.radioTwoTimesInMonthTrans2.Name = "radioTwoTimesInMonthTrans2";
            this.radioTwoTimesInMonthTrans2.Size = new System.Drawing.Size(182, 20);
            this.radioTwoTimesInMonthTrans2.TabIndex = 12;
            this.radioTwoTimesInMonthTrans2.Text = "Dépense 2 fois par &mois";
            this.radioTwoTimesInMonthTrans2.UseVisualStyleBackColor = false;
            this.radioTwoTimesInMonthTrans2.CheckedChanged += new System.EventHandler(this.radioTwoTimesInMonthTrans2_CheckedChanged);
            // 
            // radioPeriodicTrans2
            // 
            this.radioPeriodicTrans2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioPeriodicTrans2.BackColor = System.Drawing.Color.Transparent;
            this.radioPeriodicTrans2.Location = new System.Drawing.Point(1005, 223);
            this.radioPeriodicTrans2.Name = "radioPeriodicTrans2";
            this.radioPeriodicTrans2.Size = new System.Drawing.Size(182, 27);
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
            this.radioOneShotTrans2.Location = new System.Drawing.Point(1005, 188);
            this.radioOneShotTrans2.Name = "radioOneShotTrans2";
            this.radioOneShotTrans2.Size = new System.Drawing.Size(163, 28);
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
            this.buttonNewDepense2.Location = new System.Drawing.Point(809, 705);
            this.buttonNewDepense2.Name = "buttonNewDepense2";
            this.buttonNewDepense2.Size = new System.Drawing.Size(125, 27);
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
            this.ListBoxDepenses2.Location = new System.Drawing.Point(19, 55);
            this.ListBoxDepenses2.Name = "ListBoxDepenses2";
            this.ListBoxDepenses2.Size = new System.Drawing.Size(915, 644);
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
            this.labelPeriod2.Location = new System.Drawing.Point(1204, 265);
            this.labelPeriod2.Name = "labelPeriod2";
            this.labelPeriod2.Size = new System.Drawing.Size(62, 16);
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
            this.panelBalanceAndButtons2.Location = new System.Drawing.Point(987, 624);
            this.panelBalanceAndButtons2.Name = "panelBalanceAndButtons2";
            this.panelBalanceAndButtons2.Size = new System.Drawing.Size(495, 126);
            this.panelBalanceAndButtons2.TabIndex = 151;
            // 
            // labelWarning2
            // 
            this.labelWarning2.BackColor = System.Drawing.Color.Transparent;
            this.labelWarning2.ForeColor = System.Drawing.Color.Red;
            this.labelWarning2.Location = new System.Drawing.Point(14, 59);
            this.labelWarning2.Name = "labelWarning2";
            this.labelWarning2.Size = new System.Drawing.Size(467, 30);
            this.labelWarning2.TabIndex = 5;
            this.labelWarning2.Text = "Avertissement:";
            // 
            // labelBalance2
            // 
            this.labelBalance2.BackColor = System.Drawing.Color.Transparent;
            this.labelBalance2.Location = new System.Drawing.Point(14, 6);
            this.labelBalance2.Name = "labelBalance2";
            this.labelBalance2.Size = new System.Drawing.Size(467, 49);
            this.labelBalance2.TabIndex = 0;
            this.labelBalance2.Text = "Solde: earejr erjewjr rejwiorjwer weriorjaweo erjwioawejr rwejiorjwerji reweairji" +
    "owe raweiorjawer erawer wa feahfwehf efiue fhew fefhuiwefh wefhweuihf wefhweuihf" +
    " wehfuiwef ";
            // 
            // buttonSaveDepense2
            // 
            this.buttonSaveDepense2.BackColor = System.Drawing.Color.Transparent;
            this.buttonSaveDepense2.Location = new System.Drawing.Point(209, 88);
            this.buttonSaveDepense2.Name = "buttonSaveDepense2";
            this.buttonSaveDepense2.Size = new System.Drawing.Size(96, 26);
            this.buttonSaveDepense2.TabIndex = 1;
            this.buttonSaveDepense2.Text = "Sauvegarder";
            this.buttonSaveDepense2.UseVisualStyleBackColor = false;
            this.buttonSaveDepense2.Click += new System.EventHandler(this.buttonSaveDepense2_Click);
            // 
            // buttonExpenseCancel2
            // 
            this.buttonExpenseCancel2.BackColor = System.Drawing.Color.Transparent;
            this.buttonExpenseCancel2.Location = new System.Drawing.Point(320, 88);
            this.buttonExpenseCancel2.Name = "buttonExpenseCancel2";
            this.buttonExpenseCancel2.Size = new System.Drawing.Size(72, 26);
            this.buttonExpenseCancel2.TabIndex = 2;
            this.buttonExpenseCancel2.Text = "Annuler";
            this.buttonExpenseCancel2.UseVisualStyleBackColor = false;
            this.buttonExpenseCancel2.Click += new System.EventHandler(this.buttonExpenseCancel2_Click);
            // 
            // buttonDelDepense2
            // 
            this.buttonDelDepense2.BackColor = System.Drawing.Color.Transparent;
            this.buttonDelDepense2.Location = new System.Drawing.Point(414, 88);
            this.buttonDelDepense2.Name = "buttonDelDepense2";
            this.buttonDelDepense2.Size = new System.Drawing.Size(67, 26);
            this.buttonDelDepense2.TabIndex = 3;
            this.buttonDelDepense2.Text = "Effacer";
            this.buttonDelDepense2.UseVisualStyleBackColor = false;
            this.buttonDelDepense2.Click += new System.EventHandler(this.buttonDelDepense2_Click);
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
            this.comboBoxSecondTimeInMonth2.Location = new System.Drawing.Point(1347, 300);
            this.comboBoxSecondTimeInMonth2.Name = "comboBoxSecondTimeInMonth2";
            this.comboBoxSecondTimeInMonth2.Size = new System.Drawing.Size(115, 24);
            this.comboBoxSecondTimeInMonth2.TabIndex = 90;
            this.comboBoxSecondTimeInMonth2.Text = "15";
            this.comboBoxSecondTimeInMonth2.Visible = false;
            // 
            // labelFirstTimeInMonth2
            // 
            this.labelFirstTimeInMonth2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFirstTimeInMonth2.AutoSize = true;
            this.labelFirstTimeInMonth2.BackColor = System.Drawing.Color.Transparent;
            this.labelFirstTimeInMonth2.Location = new System.Drawing.Point(1204, 303);
            this.labelFirstTimeInMonth2.Name = "labelFirstTimeInMonth2";
            this.labelFirstTimeInMonth2.Size = new System.Drawing.Size(62, 16);
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
            this.labelSecondTimeInMonth2.Location = new System.Drawing.Point(1204, 305);
            this.labelSecondTimeInMonth2.Name = "labelSecondTimeInMonth2";
            this.labelSecondTimeInMonth2.Size = new System.Drawing.Size(69, 16);
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
            this.comboBoxFirstTimeInMonth2.Location = new System.Drawing.Point(1347, 301);
            this.comboBoxFirstTimeInMonth2.Name = "comboBoxFirstTimeInMonth2";
            this.comboBoxFirstTimeInMonth2.Size = new System.Drawing.Size(115, 24);
            this.comboBoxFirstTimeInMonth2.TabIndex = 18;
            this.comboBoxFirstTimeInMonth2.Text = "1er";
            this.comboBoxFirstTimeInMonth2.Visible = false;
            // 
            // tabPagePrets
            // 
            this.tabPagePrets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.tabPagePrets.Controls.Add(this.comboBoxInterestsPayDay);
            this.tabPagePrets.Controls.Add(this.labelInterestsPayDay);
            this.tabPagePrets.Controls.Add(this.textBox2);
            this.tabPagePrets.Controls.Add(this.textBoxInterestRate4);
            this.tabPagePrets.Controls.Add(this.textBoxPaiementAmount4);
            this.tabPagePrets.Controls.Add(this.dataGridViewAmountAlreadyPayed4);
            this.tabPagePrets.Controls.Add(this.textBoxAmount4);
            this.tabPagePrets.Controls.Add(this.textBoxPretName4);
            this.tabPagePrets.Controls.Add(this.textBoxNotes4);
            this.tabPagePrets.Controls.Add(this.textBoxPeriod4);
            this.tabPagePrets.Controls.Add(this.labelCategory4);
            this.tabPagePrets.Controls.Add(this.comboBoxCategory4);
            this.tabPagePrets.Controls.Add(this.checkBoxRemoveFromAnnualReport4);
            this.tabPagePrets.Controls.Add(this.labelPercent4);
            this.tabPagePrets.Controls.Add(this.labelInterestRate4);
            this.tabPagePrets.Controls.Add(this.labelPaiementType4);
            this.tabPagePrets.Controls.Add(this.comboBoxPaiementType4);
            this.tabPagePrets.Controls.Add(this.labelPretType4);
            this.tabPagePrets.Controls.Add(this.comboBoxPretType4);
            this.tabPagePrets.Controls.Add(this.panelBalanceAndButtons4);
            this.tabPagePrets.Controls.Add(this.panel5);
            this.tabPagePrets.Controls.Add(this.labelNotes4);
            this.tabPagePrets.Controls.Add(this.labelDollars4);
            this.tabPagePrets.Controls.Add(this.labelAmount4);
            this.tabPagePrets.Controls.Add(this.labelPretName4);
            this.tabPagePrets.Controls.Add(this.dateStart4);
            this.tabPagePrets.Controls.Add(this.labelStartDate4);
            this.tabPagePrets.Controls.Add(this.radioTwoTimesInMonthTrans4);
            this.tabPagePrets.Controls.Add(this.radioPeriodicTrans4);
            this.tabPagePrets.Controls.Add(this.labelPeriod4);
            this.tabPagePrets.Controls.Add(this.buttonDownPrets);
            this.tabPagePrets.Controls.Add(this.buttonUpPrets);
            this.tabPagePrets.Controls.Add(this.listBoxPrets4);
            this.tabPagePrets.Controls.Add(this.labelPretTotal);
            this.tabPagePrets.Controls.Add(this.labelTitlePrêt4);
            this.tabPagePrets.Controls.Add(this.buttonNewPret);
            this.tabPagePrets.Controls.Add(this.labelFirstTimeInMonth4);
            this.tabPagePrets.Controls.Add(this.labelSecondTimeInMonth4);
            this.tabPagePrets.Controls.Add(this.comboBoxPeriodLength4);
            this.tabPagePrets.Controls.Add(this.chartAmortissement);
            this.tabPagePrets.Controls.Add(this.comboBoxSecondTimeInMonth4);
            this.tabPagePrets.Controls.Add(this.comboBoxFirstTimeInMonth4);
            this.tabPagePrets.Location = new System.Drawing.Point(4, 25);
            this.tabPagePrets.Name = "tabPagePrets";
            this.tabPagePrets.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePrets.Size = new System.Drawing.Size(1496, 750);
            this.tabPagePrets.TabIndex = 7;
            this.tabPagePrets.Text = "Prêts/Hypothèques";
            // 
            // comboBoxInterestsPayDay
            // 
            this.comboBoxInterestsPayDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxInterestsPayDay.Items.AddRange(new object[] {
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
            "29",
            "30",
            "31",
            "dernier jour"});
            this.comboBoxInterestsPayDay.Location = new System.Drawing.Point(1281, 226);
            this.comboBoxInterestsPayDay.Name = "comboBoxInterestsPayDay";
            this.comboBoxInterestsPayDay.Size = new System.Drawing.Size(98, 24);
            this.comboBoxInterestsPayDay.TabIndex = 167;
            this.comboBoxInterestsPayDay.Text = "15";
            this.comboBoxInterestsPayDay.Visible = false;
            // 
            // labelInterestsPayDay
            // 
            this.labelInterestsPayDay.AutoSize = true;
            this.labelInterestsPayDay.Location = new System.Drawing.Point(1001, 230);
            this.labelInterestsPayDay.Name = "labelInterestsPayDay";
            this.labelInterestsPayDay.Size = new System.Drawing.Size(266, 16);
            this.labelInterestsPayDay.TabIndex = 166;
            this.labelInterestsPayDay.Text = "Jour dans le mois de paiement des intérêts:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(23, 376);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(911, 21);
            this.textBox2.TabIndex = 165;
            this.textBox2.Text = "Paiements";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxInterestRate4
            // 
            this.textBoxInterestRate4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInterestRate4.BackColor = System.Drawing.Color.White;
            this.textBoxInterestRate4.Location = new System.Drawing.Point(1389, 159);
            this.textBoxInterestRate4.Name = "textBoxInterestRate4";
            this.textBoxInterestRate4.Size = new System.Drawing.Size(59, 22);
            this.textBoxInterestRate4.TabIndex = 8;
            // 
            // textBoxPaiementAmount4
            // 
            this.textBoxPaiementAmount4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPaiementAmount4.Location = new System.Drawing.Point(1281, 195);
            this.textBoxPaiementAmount4.Name = "textBoxPaiementAmount4";
            this.textBoxPaiementAmount4.Size = new System.Drawing.Size(97, 22);
            this.textBoxPaiementAmount4.TabIndex = 10;
            // 
            // dataGridViewAmountAlreadyPayed4
            // 
            this.dataGridViewAmountAlreadyPayed4.AllowUserToAddRows = false;
            this.dataGridViewAmountAlreadyPayed4.AllowUserToDeleteRows = false;
            this.dataGridViewAmountAlreadyPayed4.AllowUserToResizeColumns = false;
            this.dataGridViewAmountAlreadyPayed4.AllowUserToResizeRows = false;
            this.dataGridViewAmountAlreadyPayed4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAmountAlreadyPayed4.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewAmountAlreadyPayed4.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewAmountAlreadyPayed4.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.dataGridViewAmountAlreadyPayed4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAmountAlreadyPayed4.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewAmountAlreadyPayed4.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewAmountAlreadyPayed4.ColumnHeadersHeight = 4;
            this.dataGridViewAmountAlreadyPayed4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewAmountAlreadyPayed4.ColumnHeadersVisible = false;
            this.dataGridViewAmountAlreadyPayed4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewCheckBoxColumn2});
            this.dataGridViewAmountAlreadyPayed4.Location = new System.Drawing.Point(1121, 539);
            this.dataGridViewAmountAlreadyPayed4.MultiSelect = false;
            this.dataGridViewAmountAlreadyPayed4.Name = "dataGridViewAmountAlreadyPayed4";
            this.dataGridViewAmountAlreadyPayed4.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewAmountAlreadyPayed4.RowHeadersVisible = false;
            this.dataGridViewAmountAlreadyPayed4.Size = new System.Drawing.Size(357, 111);
            this.dataGridViewAmountAlreadyPayed4.TabIndex = 21;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TestDate";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn5.HeaderText = "";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 5;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TestValue";
            this.dataGridViewTextBoxColumn6.HeaderText = "";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 5;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn2.FalseValue = "false";
            this.dataGridViewCheckBoxColumn2.HeaderText = "Column1";
            this.dataGridViewCheckBoxColumn2.IndeterminateValue = "false";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn2.TrueValue = "true";
            this.dataGridViewCheckBoxColumn2.Width = 5;
            // 
            // textBoxAmount4
            // 
            this.textBoxAmount4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAmount4.BackColor = System.Drawing.Color.White;
            this.textBoxAmount4.Location = new System.Drawing.Point(1152, 160);
            this.textBoxAmount4.Name = "textBoxAmount4";
            this.textBoxAmount4.Size = new System.Drawing.Size(96, 22);
            this.textBoxAmount4.TabIndex = 7;
            // 
            // textBoxPretName4
            // 
            this.textBoxPretName4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPretName4.BackColor = System.Drawing.Color.White;
            this.textBoxPretName4.Location = new System.Drawing.Point(1152, 92);
            this.textBoxPretName4.Name = "textBoxPretName4";
            this.textBoxPretName4.Size = new System.Drawing.Size(322, 22);
            this.textBoxPretName4.TabIndex = 5;
            // 
            // textBoxNotes4
            // 
            this.textBoxNotes4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNotes4.BackColor = System.Drawing.Color.White;
            this.textBoxNotes4.Location = new System.Drawing.Point(1074, 403);
            this.textBoxNotes4.Multiline = true;
            this.textBoxNotes4.Name = "textBoxNotes4";
            this.textBoxNotes4.Size = new System.Drawing.Size(404, 79);
            this.textBoxNotes4.TabIndex = 20;
            // 
            // textBoxPeriod4
            // 
            this.textBoxPeriod4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPeriod4.Location = new System.Drawing.Point(1301, 328);
            this.textBoxPeriod4.Name = "textBoxPeriod4";
            this.textBoxPeriod4.Size = new System.Drawing.Size(34, 22);
            this.textBoxPeriod4.TabIndex = 16;
            this.textBoxPeriod4.Visible = false;
            // 
            // labelCategory4
            // 
            this.labelCategory4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCategory4.AutoSize = true;
            this.labelCategory4.Location = new System.Drawing.Point(1001, 128);
            this.labelCategory4.Name = "labelCategory4";
            this.labelCategory4.Size = new System.Drawing.Size(70, 16);
            this.labelCategory4.TabIndex = 163;
            this.labelCategory4.Text = "Catégorie:";
            // 
            // comboBoxCategory4
            // 
            this.comboBoxCategory4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCategory4.FormattingEnabled = true;
            this.comboBoxCategory4.Location = new System.Drawing.Point(1152, 125);
            this.comboBoxCategory4.MaxDropDownItems = 20;
            this.comboBoxCategory4.Name = "comboBoxCategory4";
            this.comboBoxCategory4.Size = new System.Drawing.Size(322, 24);
            this.comboBoxCategory4.TabIndex = 6;
            // 
            // checkBoxRemoveFromAnnualReport4
            // 
            this.checkBoxRemoveFromAnnualReport4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxRemoveFromAnnualReport4.Location = new System.Drawing.Point(1005, 258);
            this.checkBoxRemoveFromAnnualReport4.Name = "checkBoxRemoveFromAnnualReport4";
            this.checkBoxRemoveFromAnnualReport4.Size = new System.Drawing.Size(227, 20);
            this.checkBoxRemoveFromAnnualReport4.TabIndex = 11;
            this.checkBoxRemoveFromAnnualReport4.Text = "Exclure du bilan annuel";
            this.checkBoxRemoveFromAnnualReport4.UseVisualStyleBackColor = true;
            // 
            // labelPercent4
            // 
            this.labelPercent4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPercent4.AutoSize = true;
            this.labelPercent4.BackColor = System.Drawing.Color.Transparent;
            this.labelPercent4.Location = new System.Drawing.Point(1451, 165);
            this.labelPercent4.Name = "labelPercent4";
            this.labelPercent4.Size = new System.Drawing.Size(20, 16);
            this.labelPercent4.TabIndex = 160;
            this.labelPercent4.Text = "%";
            this.labelPercent4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelInterestRate4
            // 
            this.labelInterestRate4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInterestRate4.AutoSize = true;
            this.labelInterestRate4.BackColor = System.Drawing.Color.Transparent;
            this.labelInterestRate4.Location = new System.Drawing.Point(1277, 163);
            this.labelInterestRate4.Name = "labelInterestRate4";
            this.labelInterestRate4.Size = new System.Drawing.Size(94, 16);
            this.labelInterestRate4.TabIndex = 159;
            this.labelInterestRate4.Text = "Taux d\'intérêt :";
            // 
            // labelPaiementType4
            // 
            this.labelPaiementType4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPaiementType4.BackColor = System.Drawing.Color.Transparent;
            this.labelPaiementType4.Location = new System.Drawing.Point(1385, 195);
            this.labelPaiementType4.Name = "labelPaiementType4";
            this.labelPaiementType4.Size = new System.Drawing.Size(63, 18);
            this.labelPaiementType4.TabIndex = 157;
            this.labelPaiementType4.Text = "ans";
            this.labelPaiementType4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxPaiementType4
            // 
            this.comboBoxPaiementType4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPaiementType4.FormattingEnabled = true;
            this.comboBoxPaiementType4.Items.AddRange(new object[] {
            "Nombre d\'années d\'amortissement:",
            "Nombre de mois d\'amortissement:",
            "Montant fixe par paiement:"});
            this.comboBoxPaiementType4.Location = new System.Drawing.Point(1005, 194);
            this.comboBoxPaiementType4.MaxDropDownItems = 20;
            this.comboBoxPaiementType4.Name = "comboBoxPaiementType4";
            this.comboBoxPaiementType4.Size = new System.Drawing.Size(227, 24);
            this.comboBoxPaiementType4.TabIndex = 9;
            this.comboBoxPaiementType4.Text = "Nombre d\'années d\'amortissement:";
            this.comboBoxPaiementType4.SelectedIndexChanged += new System.EventHandler(this.comboBoxPaiementType4_SelectedIndexChanged);
            // 
            // labelPretType4
            // 
            this.labelPretType4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPretType4.BackColor = System.Drawing.Color.Transparent;
            this.labelPretType4.Location = new System.Drawing.Point(1001, 59);
            this.labelPretType4.Name = "labelPretType4";
            this.labelPretType4.Size = new System.Drawing.Size(108, 18);
            this.labelPretType4.TabIndex = 154;
            this.labelPretType4.Text = "Type d\'emprunt :";
            // 
            // comboBoxPretType4
            // 
            this.comboBoxPretType4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPretType4.FormattingEnabled = true;
            this.comboBoxPretType4.Items.AddRange(new object[] {
            "Prêt",
            "Hypothèque",
            "Marge de crédit hypothèquaire liée à ce compte",
            "Prêt consenti par ce compte"});
            this.comboBoxPretType4.Location = new System.Drawing.Point(1152, 59);
            this.comboBoxPretType4.MaxDropDownItems = 20;
            this.comboBoxPretType4.Name = "comboBoxPretType4";
            this.comboBoxPretType4.Size = new System.Drawing.Size(322, 24);
            this.comboBoxPretType4.TabIndex = 4;
            this.comboBoxPretType4.Text = "Prêt";
            this.comboBoxPretType4.SelectedIndexChanged += new System.EventHandler(this.comboBoxPretType4_SelectedIndexChanged);
            // 
            // panelBalanceAndButtons4
            // 
            this.panelBalanceAndButtons4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBalanceAndButtons4.Controls.Add(this.labelWarning4);
            this.panelBalanceAndButtons4.Controls.Add(this.labelBalance4);
            this.panelBalanceAndButtons4.Controls.Add(this.buttonSavePret4);
            this.panelBalanceAndButtons4.Controls.Add(this.buttonDeletePret4);
            this.panelBalanceAndButtons4.Controls.Add(this.buttonCancelPret4);
            this.panelBalanceAndButtons4.Location = new System.Drawing.Point(1074, 646);
            this.panelBalanceAndButtons4.Name = "panelBalanceAndButtons4";
            this.panelBalanceAndButtons4.Size = new System.Drawing.Size(404, 125);
            this.panelBalanceAndButtons4.TabIndex = 152;
            // 
            // labelWarning4
            // 
            this.labelWarning4.BackColor = System.Drawing.Color.Transparent;
            this.labelWarning4.ForeColor = System.Drawing.Color.Red;
            this.labelWarning4.Location = new System.Drawing.Point(17, 75);
            this.labelWarning4.Name = "labelWarning4";
            this.labelWarning4.Size = new System.Drawing.Size(391, 18);
            this.labelWarning4.TabIndex = 6;
            this.labelWarning4.Text = "Avertissement:";
            // 
            // labelBalance4
            // 
            this.labelBalance4.BackColor = System.Drawing.Color.Transparent;
            this.labelBalance4.Location = new System.Drawing.Point(14, 10);
            this.labelBalance4.Name = "labelBalance4";
            this.labelBalance4.Size = new System.Drawing.Size(392, 65);
            this.labelBalance4.TabIndex = 0;
            this.labelBalance4.Text = "Solde:";
            // 
            // buttonSavePret4
            // 
            this.buttonSavePret4.BackColor = System.Drawing.Color.Transparent;
            this.buttonSavePret4.Location = new System.Drawing.Point(140, 95);
            this.buttonSavePret4.Name = "buttonSavePret4";
            this.buttonSavePret4.Size = new System.Drawing.Size(96, 26);
            this.buttonSavePret4.TabIndex = 1;
            this.buttonSavePret4.Text = "Sauvegarder";
            this.buttonSavePret4.UseVisualStyleBackColor = false;
            this.buttonSavePret4.Click += new System.EventHandler(this.buttonSavePret4_Click);
            // 
            // buttonDeletePret4
            // 
            this.buttonDeletePret4.BackColor = System.Drawing.Color.Transparent;
            this.buttonDeletePret4.Location = new System.Drawing.Point(336, 95);
            this.buttonDeletePret4.Name = "buttonDeletePret4";
            this.buttonDeletePret4.Size = new System.Drawing.Size(67, 26);
            this.buttonDeletePret4.TabIndex = 3;
            this.buttonDeletePret4.Text = "Effacer";
            this.buttonDeletePret4.UseVisualStyleBackColor = false;
            this.buttonDeletePret4.Click += new System.EventHandler(this.buttonDeletePret4_Click);
            // 
            // buttonCancelPret4
            // 
            this.buttonCancelPret4.BackColor = System.Drawing.Color.Transparent;
            this.buttonCancelPret4.Location = new System.Drawing.Point(250, 95);
            this.buttonCancelPret4.Name = "buttonCancelPret4";
            this.buttonCancelPret4.Size = new System.Drawing.Size(74, 26);
            this.buttonCancelPret4.TabIndex = 2;
            this.buttonCancelPret4.Text = "Annuler";
            this.buttonCancelPret4.UseVisualStyleBackColor = false;
            this.buttonCancelPret4.Click += new System.EventHandler(this.buttonCancelPret4_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.radioButtonIsAutomatic4);
            this.panel5.Controls.Add(this.radioButtonIsManual4);
            this.panel5.Location = new System.Drawing.Point(1065, 483);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(413, 59);
            this.panel5.TabIndex = 150;
            // 
            // radioButtonIsAutomatic4
            // 
            this.radioButtonIsAutomatic4.AutoSize = true;
            this.radioButtonIsAutomatic4.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonIsAutomatic4.Checked = true;
            this.radioButtonIsAutomatic4.Enabled = false;
            this.radioButtonIsAutomatic4.Location = new System.Drawing.Point(14, 3);
            this.radioButtonIsAutomatic4.Name = "radioButtonIsAutomatic4";
            this.radioButtonIsAutomatic4.Size = new System.Drawing.Size(334, 20);
            this.radioButtonIsAutomatic4.TabIndex = 0;
            this.radioButtonIsAutomatic4.TabStop = true;
            this.radioButtonIsAutomatic4.Text = "Paiement déposé automatiquement dans le compte";
            this.radioButtonIsAutomatic4.UseVisualStyleBackColor = false;
            this.radioButtonIsAutomatic4.CheckedChanged += new System.EventHandler(this.radioButtonIsAutomatic4_CheckedChanged);
            // 
            // radioButtonIsManual4
            // 
            this.radioButtonIsManual4.AutoSize = true;
            this.radioButtonIsManual4.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonIsManual4.Enabled = false;
            this.radioButtonIsManual4.Location = new System.Drawing.Point(14, 30);
            this.radioButtonIsManual4.Name = "radioButtonIsManual4";
            this.radioButtonIsManual4.Size = new System.Drawing.Size(315, 20);
            this.radioButtonIsManual4.TabIndex = 1;
            this.radioButtonIsManual4.Text = "Paiement déposé manuellement dans le compte";
            this.radioButtonIsManual4.UseVisualStyleBackColor = false;
            this.radioButtonIsManual4.CheckedChanged += new System.EventHandler(this.radioButtonIsManual4_CheckedChanged);
            // 
            // labelNotes4
            // 
            this.labelNotes4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNotes4.BackColor = System.Drawing.Color.Transparent;
            this.labelNotes4.Location = new System.Drawing.Point(1005, 403);
            this.labelNotes4.Name = "labelNotes4";
            this.labelNotes4.Size = new System.Drawing.Size(48, 18);
            this.labelNotes4.TabIndex = 148;
            this.labelNotes4.Text = "Notes :";
            // 
            // labelDollars4
            // 
            this.labelDollars4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDollars4.BackColor = System.Drawing.Color.Transparent;
            this.labelDollars4.Location = new System.Drawing.Point(1248, 160);
            this.labelDollars4.Name = "labelDollars4";
            this.labelDollars4.Size = new System.Drawing.Size(20, 19);
            this.labelDollars4.TabIndex = 147;
            this.labelDollars4.Text = "$";
            this.labelDollars4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAmount4
            // 
            this.labelAmount4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAmount4.BackColor = System.Drawing.Color.Transparent;
            this.labelAmount4.Location = new System.Drawing.Point(1001, 164);
            this.labelAmount4.Name = "labelAmount4";
            this.labelAmount4.Size = new System.Drawing.Size(77, 18);
            this.labelAmount4.TabIndex = 143;
            this.labelAmount4.Text = "Montant :";
            // 
            // labelPretName4
            // 
            this.labelPretName4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPretName4.BackColor = System.Drawing.Color.Transparent;
            this.labelPretName4.Location = new System.Drawing.Point(1001, 92);
            this.labelPretName4.Name = "labelPretName4";
            this.labelPretName4.Size = new System.Drawing.Size(77, 19);
            this.labelPretName4.TabIndex = 141;
            this.labelPretName4.Text = "Nom :";
            // 
            // dateStart4
            // 
            this.dateStart4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateStart4.CustomFormat = "dd MMM yyyy";
            this.dateStart4.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStart4.Location = new System.Drawing.Point(1301, 290);
            this.dateStart4.MaxDate = new System.DateTime(2090, 12, 31, 0, 0, 0, 0);
            this.dateStart4.MinDate = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            this.dateStart4.Name = "dateStart4";
            this.dateStart4.Size = new System.Drawing.Size(177, 22);
            this.dateStart4.TabIndex = 15;
            this.dateStart4.Value = new System.DateTime(2011, 1, 1, 0, 0, 0, 0);
            // 
            // labelStartDate4
            // 
            this.labelStartDate4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStartDate4.AutoSize = true;
            this.labelStartDate4.BackColor = System.Drawing.Color.Transparent;
            this.labelStartDate4.Location = new System.Drawing.Point(1187, 292);
            this.labelStartDate4.Name = "labelStartDate4";
            this.labelStartDate4.Size = new System.Drawing.Size(103, 16);
            this.labelStartDate4.TabIndex = 135;
            this.labelStartDate4.Text = "1er paiement le:";
            this.labelStartDate4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioTwoTimesInMonthTrans4
            // 
            this.radioTwoTimesInMonthTrans4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioTwoTimesInMonthTrans4.BackColor = System.Drawing.Color.Transparent;
            this.radioTwoTimesInMonthTrans4.Location = new System.Drawing.Point(1005, 330);
            this.radioTwoTimesInMonthTrans4.Name = "radioTwoTimesInMonthTrans4";
            this.radioTwoTimesInMonthTrans4.Size = new System.Drawing.Size(182, 20);
            this.radioTwoTimesInMonthTrans4.TabIndex = 14;
            this.radioTwoTimesInMonthTrans4.Text = "Paiement 2 fois par &mois";
            this.radioTwoTimesInMonthTrans4.UseVisualStyleBackColor = false;
            this.radioTwoTimesInMonthTrans4.CheckedChanged += new System.EventHandler(this.radioTwoTimesInMonthTrans4_CheckedChanged);
            // 
            // radioPeriodicTrans4
            // 
            this.radioPeriodicTrans4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioPeriodicTrans4.BackColor = System.Drawing.Color.Transparent;
            this.radioPeriodicTrans4.Location = new System.Drawing.Point(1005, 292);
            this.radioPeriodicTrans4.Name = "radioPeriodicTrans4";
            this.radioPeriodicTrans4.Size = new System.Drawing.Size(156, 23);
            this.radioPeriodicTrans4.TabIndex = 12;
            this.radioPeriodicTrans4.Text = "Paiement &périodique";
            this.radioPeriodicTrans4.UseVisualStyleBackColor = false;
            this.radioPeriodicTrans4.CheckedChanged += new System.EventHandler(this.radioPeriodicTrans4_CheckedChanged);
            // 
            // labelPeriod4
            // 
            this.labelPeriod4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPeriod4.AutoSize = true;
            this.labelPeriod4.BackColor = System.Drawing.Color.Transparent;
            this.labelPeriod4.Location = new System.Drawing.Point(1187, 333);
            this.labelPeriod4.Name = "labelPeriod4";
            this.labelPeriod4.Size = new System.Drawing.Size(62, 16);
            this.labelPeriod4.TabIndex = 146;
            this.labelPeriod4.Text = "Période :";
            this.labelPeriod4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPeriod4.Visible = false;
            // 
            // buttonDownPrets
            // 
            this.buttonDownPrets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDownPrets.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDownPrets.BackgroundImage")));
            this.buttonDownPrets.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDownPrets.FlatAppearance.BorderSize = 0;
            this.buttonDownPrets.Location = new System.Drawing.Point(944, 90);
            this.buttonDownPrets.Name = "buttonDownPrets";
            this.buttonDownPrets.Size = new System.Drawing.Size(30, 29);
            this.buttonDownPrets.TabIndex = 3;
            this.buttonDownPrets.UseVisualStyleBackColor = true;
            this.buttonDownPrets.Click += new System.EventHandler(this.buttonDownPrets_Click);
            // 
            // buttonUpPrets
            // 
            this.buttonUpPrets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpPrets.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonUpPrets.BackgroundImage")));
            this.buttonUpPrets.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUpPrets.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.buttonUpPrets.FlatAppearance.BorderSize = 0;
            this.buttonUpPrets.FlatAppearance.MouseDownBackColor = System.Drawing.Color.AliceBlue;
            this.buttonUpPrets.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.buttonUpPrets.Location = new System.Drawing.Point(944, 55);
            this.buttonUpPrets.Name = "buttonUpPrets";
            this.buttonUpPrets.Size = new System.Drawing.Size(30, 29);
            this.buttonUpPrets.TabIndex = 2;
            this.buttonUpPrets.UseVisualStyleBackColor = true;
            this.buttonUpPrets.Click += new System.EventHandler(this.buttonUpPrets_Click);
            // 
            // listBoxPrets4
            // 
            this.listBoxPrets4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPrets4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.listBoxPrets4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBoxPrets4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxPrets4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPrets4.HorizontalScrollbar = true;
            this.listBoxPrets4.ItemHeight = 16;
            this.listBoxPrets4.Location = new System.Drawing.Point(19, 55);
            this.listBoxPrets4.Name = "listBoxPrets4";
            this.listBoxPrets4.Size = new System.Drawing.Size(915, 276);
            this.listBoxPrets4.TabIndex = 0;
            this.listBoxPrets4.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBoxPrets4_DrawItem);
            this.listBoxPrets4.SelectedIndexChanged += new System.EventHandler(this.listBoxPrets4_SelectedIndexChanged);
            this.listBoxPrets4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listBoxPrets4_MouseMove);
            // 
            // labelPretTotal
            // 
            this.labelPretTotal.AutoSize = true;
            this.labelPretTotal.Location = new System.Drawing.Point(16, 343);
            this.labelPretTotal.Name = "labelPretTotal";
            this.labelPretTotal.Size = new System.Drawing.Size(48, 16);
            this.labelPretTotal.TabIndex = 120;
            this.labelPretTotal.Text = "Total : ";
            // 
            // labelTitlePrêt4
            // 
            this.labelTitlePrêt4.BackColor = System.Drawing.Color.Transparent;
            this.labelTitlePrêt4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePrêt4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.labelTitlePrêt4.Location = new System.Drawing.Point(4, 9);
            this.labelTitlePrêt4.Name = "labelTitlePrêt4";
            this.labelTitlePrêt4.Size = new System.Drawing.Size(927, 27);
            this.labelTitlePrêt4.TabIndex = 118;
            this.labelTitlePrêt4.Text = "Prêts / Hypothèques";
            this.labelTitlePrêt4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonNewPret
            // 
            this.buttonNewPret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewPret.BackColor = System.Drawing.Color.Transparent;
            this.buttonNewPret.Location = new System.Drawing.Point(759, 337);
            this.buttonNewPret.Name = "buttonNewPret";
            this.buttonNewPret.Size = new System.Drawing.Size(176, 26);
            this.buttonNewPret.TabIndex = 1;
            this.buttonNewPret.Text = "Nouveau Prêt/Hypothèque";
            this.buttonNewPret.UseVisualStyleBackColor = false;
            this.buttonNewPret.Click += new System.EventHandler(this.buttonNewPret_Click);
            // 
            // labelFirstTimeInMonth4
            // 
            this.labelFirstTimeInMonth4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFirstTimeInMonth4.AutoSize = true;
            this.labelFirstTimeInMonth4.BackColor = System.Drawing.Color.Transparent;
            this.labelFirstTimeInMonth4.Location = new System.Drawing.Point(1187, 369);
            this.labelFirstTimeInMonth4.Name = "labelFirstTimeInMonth4";
            this.labelFirstTimeInMonth4.Size = new System.Drawing.Size(62, 16);
            this.labelFirstTimeInMonth4.TabIndex = 144;
            this.labelFirstTimeInMonth4.Text = "1ère fois:";
            this.labelFirstTimeInMonth4.Visible = false;
            // 
            // labelSecondTimeInMonth4
            // 
            this.labelSecondTimeInMonth4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSecondTimeInMonth4.AutoSize = true;
            this.labelSecondTimeInMonth4.BackColor = System.Drawing.Color.Transparent;
            this.labelSecondTimeInMonth4.Location = new System.Drawing.Point(1187, 369);
            this.labelSecondTimeInMonth4.Name = "labelSecondTimeInMonth4";
            this.labelSecondTimeInMonth4.Size = new System.Drawing.Size(69, 16);
            this.labelSecondTimeInMonth4.TabIndex = 145;
            this.labelSecondTimeInMonth4.Text = "2ème fois:";
            this.labelSecondTimeInMonth4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSecondTimeInMonth4.Visible = false;
            // 
            // comboBoxPeriodLength4
            // 
            this.comboBoxPeriodLength4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPeriodLength4.Items.AddRange(new object[] {
            "jours",
            "sem.",
            "mois",
            "ans",
            "sem. en accéléré"});
            this.comboBoxPeriodLength4.Location = new System.Drawing.Point(1343, 329);
            this.comboBoxPeriodLength4.Name = "comboBoxPeriodLength4";
            this.comboBoxPeriodLength4.Size = new System.Drawing.Size(135, 24);
            this.comboBoxPeriodLength4.TabIndex = 17;
            this.comboBoxPeriodLength4.Text = "jours";
            this.comboBoxPeriodLength4.Visible = false;
            this.comboBoxPeriodLength4.SelectedIndexChanged += new System.EventHandler(this.comboBoxPeriodLength4_SelectedIndexChanged);
            // 
            // chartAmortissement
            // 
            this.chartAmortissement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartAmortissement.BackColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.Interval = 1D;
            chartArea3.AxisX.LabelStyle.Angle = 90;
            chartArea3.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisX.LabelStyle.Interval = 1D;
            chartArea3.AxisX.LabelStyle.IntervalOffset = 1D;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.LabelStyle.Format = "C0";
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            chartArea3.Name = "ChartArea1";
            this.chartAmortissement.ChartAreas.Add(chartArea3);
            this.chartAmortissement.Location = new System.Drawing.Point(-48, 396);
            this.chartAmortissement.Margin = new System.Windows.Forms.Padding(0);
            this.chartAmortissement.MinimumSize = new System.Drawing.Size(664, 211);
            this.chartAmortissement.Name = "chartAmortissement";
            series3.ChartArea = "ChartArea1";
            series3.CustomProperties = "DrawingStyle=Cylinder, LabelStyle=Top, MaxPixelPointWidth=10";
            series3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsValueShownAsLabel = true;
            series3.LabelBackColor = System.Drawing.Color.Transparent;
            series3.LabelFormat = "$";
            series3.Name = "Series1";
            dataPoint3.Color = System.Drawing.Color.Green;
            dataPoint3.LabelBackColor = System.Drawing.Color.White;
            dataPoint4.Color = System.Drawing.Color.Red;
            dataPoint4.LabelBackColor = System.Drawing.Color.White;
            series3.Points.Add(dataPoint3);
            series3.Points.Add(dataPoint4);
            series3.SmartLabelStyle.Enabled = false;
            series3.SmartLabelStyle.MovingDirection = ((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles)(((((((((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Top | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Bottom) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Right) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Left) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopLeft) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopRight) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomLeft) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomRight) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Center)));
            this.chartAmortissement.Series.Add(series3);
            this.chartAmortissement.Size = new System.Drawing.Size(1154, 372);
            this.chartAmortissement.TabIndex = 164;
            this.chartAmortissement.Text = "chart1";
            this.chartAmortissement.Click += new System.EventHandler(this.chartAmortissement_Click);
            // 
            // comboBoxSecondTimeInMonth4
            // 
            this.comboBoxSecondTimeInMonth4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSecondTimeInMonth4.Items.AddRange(new object[] {
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
            this.comboBoxSecondTimeInMonth4.Location = new System.Drawing.Point(1304, 363);
            this.comboBoxSecondTimeInMonth4.Name = "comboBoxSecondTimeInMonth4";
            this.comboBoxSecondTimeInMonth4.Size = new System.Drawing.Size(170, 24);
            this.comboBoxSecondTimeInMonth4.TabIndex = 142;
            this.comboBoxSecondTimeInMonth4.Text = "15";
            this.comboBoxSecondTimeInMonth4.Visible = false;
            // 
            // comboBoxFirstTimeInMonth4
            // 
            this.comboBoxFirstTimeInMonth4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFirstTimeInMonth4.Items.AddRange(new object[] {
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
            this.comboBoxFirstTimeInMonth4.Location = new System.Drawing.Point(1302, 362);
            this.comboBoxFirstTimeInMonth4.Name = "comboBoxFirstTimeInMonth4";
            this.comboBoxFirstTimeInMonth4.Size = new System.Drawing.Size(172, 24);
            this.comboBoxFirstTimeInMonth4.TabIndex = 19;
            this.comboBoxFirstTimeInMonth4.Text = "1er";
            this.comboBoxFirstTimeInMonth4.Visible = false;
            // 
            // tabPagePlacements
            // 
            this.tabPagePlacements.AutoScroll = true;
            this.tabPagePlacements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.tabPagePlacements.Controls.Add(this.labelProfitPlacements);
            this.tabPagePlacements.Controls.Add(this.label12);
            this.tabPagePlacements.Controls.Add(this.labelValeurPlacements);
            this.tabPagePlacements.Controls.Add(this.label11);
            this.tabPagePlacements.Controls.Add(this.label5);
            this.tabPagePlacements.Controls.Add(this.buttonDeleteRendement);
            this.tabPagePlacements.Controls.Add(this.buttonDeletePlacement);
            this.tabPagePlacements.Controls.Add(this.labelRendementTotal);
            this.tabPagePlacements.Controls.Add(this.labelInvestissementTotal);
            this.tabPagePlacements.Controls.Add(this.buttonNouveauRendement);
            this.tabPagePlacements.Controls.Add(this.comboBoxRendement);
            this.tabPagePlacements.Controls.Add(this.dateRendement);
            this.tabPagePlacements.Controls.Add(this.textBoxMontantRendement);
            this.tabPagePlacements.Controls.Add(this.textBoxMontantPlacement);
            this.tabPagePlacements.Controls.Add(this.label6);
            this.tabPagePlacements.Controls.Add(this.label7);
            this.tabPagePlacements.Controls.Add(this.label8);
            this.tabPagePlacements.Controls.Add(this.listBoxRendements);
            this.tabPagePlacements.Controls.Add(this.buttonNouveauPlacement);
            this.tabPagePlacements.Controls.Add(this.labelTitlePlacements);
            this.tabPagePlacements.Controls.Add(this.listBoxPlacements);
            this.tabPagePlacements.Controls.Add(this.comboBoxPlacement);
            this.tabPagePlacements.Controls.Add(this.datePlacement);
            this.tabPagePlacements.Controls.Add(this.label4);
            this.tabPagePlacements.Controls.Add(this.label3);
            this.tabPagePlacements.Controls.Add(this.label2);
            this.tabPagePlacements.Location = new System.Drawing.Point(4, 25);
            this.tabPagePlacements.Name = "tabPagePlacements";
            this.tabPagePlacements.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePlacements.Size = new System.Drawing.Size(1496, 750);
            this.tabPagePlacements.TabIndex = 5;
            this.tabPagePlacements.Text = "Placements";
            // 
            // labelProfitPlacements
            // 
            this.labelProfitPlacements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProfitPlacements.AutoSize = true;
            this.labelProfitPlacements.BackColor = System.Drawing.Color.Transparent;
            this.labelProfitPlacements.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProfitPlacements.ForeColor = System.Drawing.Color.Green;
            this.labelProfitPlacements.Location = new System.Drawing.Point(897, -20);
            this.labelProfitPlacements.Margin = new System.Windows.Forms.Padding(0);
            this.labelProfitPlacements.Name = "labelProfitPlacements";
            this.labelProfitPlacements.Size = new System.Drawing.Size(28, 16);
            this.labelProfitPlacements.TabIndex = 162;
            this.labelProfitPlacements.Text = "0 $";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(674, -20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(162, 16);
            this.label12.TabIndex = 164;
            this.label12.Text = "Profit des placements:";
            // 
            // labelValeurPlacements
            // 
            this.labelValeurPlacements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelValeurPlacements.AutoSize = true;
            this.labelValeurPlacements.BackColor = System.Drawing.Color.Transparent;
            this.labelValeurPlacements.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValeurPlacements.ForeColor = System.Drawing.Color.Green;
            this.labelValeurPlacements.Location = new System.Drawing.Point(251, -20);
            this.labelValeurPlacements.Name = "labelValeurPlacements";
            this.labelValeurPlacements.Size = new System.Drawing.Size(28, 16);
            this.labelValeurPlacements.TabIndex = 161;
            this.labelValeurPlacements.Text = "0 $";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(28, -20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(171, 16);
            this.label11.TabIndex = 163;
            this.label11.Text = "Valeur des placements:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.label5.Location = new System.Drawing.Point(666, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(797, 27);
            this.label5.TabIndex = 160;
            this.label5.Text = "Rendements";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDeleteRendement
            // 
            this.buttonDeleteRendement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteRendement.BackColor = System.Drawing.Color.Transparent;
            this.buttonDeleteRendement.Location = new System.Drawing.Point(1398, 545);
            this.buttonDeleteRendement.Name = "buttonDeleteRendement";
            this.buttonDeleteRendement.Size = new System.Drawing.Size(69, 26);
            this.buttonDeleteRendement.TabIndex = 11;
            this.buttonDeleteRendement.Text = "Effacer";
            this.buttonDeleteRendement.UseVisualStyleBackColor = false;
            this.buttonDeleteRendement.Click += new System.EventHandler(this.buttonDeleteRendement_Click);
            // 
            // buttonDeletePlacement
            // 
            this.buttonDeletePlacement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeletePlacement.BackColor = System.Drawing.Color.Transparent;
            this.buttonDeletePlacement.Location = new System.Drawing.Point(570, 548);
            this.buttonDeletePlacement.Name = "buttonDeletePlacement";
            this.buttonDeletePlacement.Size = new System.Drawing.Size(69, 27);
            this.buttonDeletePlacement.TabIndex = 5;
            this.buttonDeletePlacement.Text = "Effacer";
            this.buttonDeletePlacement.UseVisualStyleBackColor = false;
            this.buttonDeletePlacement.Click += new System.EventHandler(this.buttonDeletePlacement_Click);
            // 
            // labelRendementTotal
            // 
            this.labelRendementTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRendementTotal.AutoSize = true;
            this.labelRendementTotal.Location = new System.Drawing.Point(674, 550);
            this.labelRendementTotal.Name = "labelRendementTotal";
            this.labelRendementTotal.Size = new System.Drawing.Size(109, 16);
            this.labelRendementTotal.TabIndex = 157;
            this.labelRendementTotal.Text = "Rendement total:";
            // 
            // labelInvestissementTotal
            // 
            this.labelInvestissementTotal.AutoSize = true;
            this.labelInvestissementTotal.Location = new System.Drawing.Point(22, 554);
            this.labelInvestissementTotal.Name = "labelInvestissementTotal";
            this.labelInvestissementTotal.Size = new System.Drawing.Size(128, 16);
            this.labelInvestissementTotal.TabIndex = 156;
            this.labelInvestissementTotal.Text = "Investissement total:";
            // 
            // buttonNouveauRendement
            // 
            this.buttonNouveauRendement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNouveauRendement.BackColor = System.Drawing.Color.Transparent;
            this.buttonNouveauRendement.Location = new System.Drawing.Point(677, 720);
            this.buttonNouveauRendement.Name = "buttonNouveauRendement";
            this.buttonNouveauRendement.Size = new System.Drawing.Size(125, 27);
            this.buttonNouveauRendement.TabIndex = 10;
            this.buttonNouveauRendement.Text = "Ajouter";
            this.buttonNouveauRendement.UseVisualStyleBackColor = false;
            this.buttonNouveauRendement.Click += new System.EventHandler(this.buttonNouveauRendement_Click);
            // 
            // comboBoxRendement
            // 
            this.comboBoxRendement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRendement.BackColor = System.Drawing.Color.White;
            this.comboBoxRendement.FormattingEnabled = true;
            this.comboBoxRendement.Items.AddRange(new object[] {
            "REER 1",
            "REER 2",
            "CELI 1",
            "CELI 2",
            "REEE"});
            this.comboBoxRendement.Location = new System.Drawing.Point(810, 676);
            this.comboBoxRendement.Name = "comboBoxRendement";
            this.comboBoxRendement.Size = new System.Drawing.Size(162, 24);
            this.comboBoxRendement.TabIndex = 9;
            this.comboBoxRendement.Text = "REER 1";
            // 
            // dateRendement
            // 
            this.dateRendement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateRendement.CustomFormat = "dd MMM yyyy";
            this.dateRendement.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateRendement.Location = new System.Drawing.Point(810, 639);
            this.dateRendement.Name = "dateRendement";
            this.dateRendement.Size = new System.Drawing.Size(162, 22);
            this.dateRendement.TabIndex = 8;
            // 
            // textBoxMontantRendement
            // 
            this.textBoxMontantRendement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMontantRendement.BackColor = System.Drawing.Color.White;
            this.textBoxMontantRendement.Location = new System.Drawing.Point(810, 602);
            this.textBoxMontantRendement.Name = "textBoxMontantRendement";
            this.textBoxMontantRendement.Size = new System.Drawing.Size(162, 22);
            this.textBoxMontantRendement.TabIndex = 7;
            this.textBoxMontantRendement.LostFocus += new System.EventHandler(this.textBoxMontantRendement_LostFocus);
            // 
            // textBoxMontantPlacement
            // 
            this.textBoxMontantPlacement.BackColor = System.Drawing.Color.White;
            this.textBoxMontantPlacement.Location = new System.Drawing.Point(158, 602);
            this.textBoxMontantPlacement.Name = "textBoxMontantPlacement";
            this.textBoxMontantPlacement.Size = new System.Drawing.Size(162, 22);
            this.textBoxMontantPlacement.TabIndex = 1;
            this.textBoxMontantPlacement.LostFocus += new System.EventHandler(this.textBoxMontantPlacement_LostFocus);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(674, 680);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 16);
            this.label6.TabIndex = 148;
            this.label6.Text = "Type de rendement:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(674, 639);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 147;
            this.label7.Text = "Date:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(674, 606);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 146;
            this.label8.Text = "Montant:";
            // 
            // listBoxRendements
            // 
            this.listBoxRendements.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRendements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.listBoxRendements.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBoxRendements.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxRendements.HorizontalScrollbar = true;
            this.listBoxRendements.ItemHeight = 16;
            this.listBoxRendements.Location = new System.Drawing.Point(670, 81);
            this.listBoxRendements.Name = "listBoxRendements";
            this.listBoxRendements.Size = new System.Drawing.Size(794, 452);
            this.listBoxRendements.TabIndex = 6;
            // 
            // buttonNouveauPlacement
            // 
            this.buttonNouveauPlacement.BackColor = System.Drawing.Color.Transparent;
            this.buttonNouveauPlacement.Location = new System.Drawing.Point(25, 720);
            this.buttonNouveauPlacement.Name = "buttonNouveauPlacement";
            this.buttonNouveauPlacement.Size = new System.Drawing.Size(125, 27);
            this.buttonNouveauPlacement.TabIndex = 4;
            this.buttonNouveauPlacement.Text = "Ajouter";
            this.buttonNouveauPlacement.UseVisualStyleBackColor = false;
            this.buttonNouveauPlacement.Click += new System.EventHandler(this.buttonNouveauPlacement_Click);
            // 
            // labelTitlePlacements
            // 
            this.labelTitlePlacements.BackColor = System.Drawing.Color.Transparent;
            this.labelTitlePlacements.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitlePlacements.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.labelTitlePlacements.Location = new System.Drawing.Point(22, 48);
            this.labelTitlePlacements.Name = "labelTitlePlacements";
            this.labelTitlePlacements.Size = new System.Drawing.Size(615, 27);
            this.labelTitlePlacements.TabIndex = 143;
            this.labelTitlePlacements.Text = "Placements";
            this.labelTitlePlacements.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBoxPlacements
            // 
            this.listBoxPlacements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPlacements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.listBoxPlacements.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBoxPlacements.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPlacements.HorizontalScrollbar = true;
            this.listBoxPlacements.ItemHeight = 16;
            this.listBoxPlacements.Location = new System.Drawing.Point(19, 83);
            this.listBoxPlacements.Name = "listBoxPlacements";
            this.listBoxPlacements.Size = new System.Drawing.Size(620, 452);
            this.listBoxPlacements.TabIndex = 0;
            // 
            // comboBoxPlacement
            // 
            this.comboBoxPlacement.BackColor = System.Drawing.Color.White;
            this.comboBoxPlacement.FormattingEnabled = true;
            this.comboBoxPlacement.Items.AddRange(new object[] {
            "REER 1",
            "REER 2",
            "CELI 1",
            "CELI 2",
            "REEE"});
            this.comboBoxPlacement.Location = new System.Drawing.Point(158, 676);
            this.comboBoxPlacement.Name = "comboBoxPlacement";
            this.comboBoxPlacement.Size = new System.Drawing.Size(162, 24);
            this.comboBoxPlacement.TabIndex = 3;
            this.comboBoxPlacement.Text = "REER 1";
            // 
            // datePlacement
            // 
            this.datePlacement.CustomFormat = "dd MMM yyyy";
            this.datePlacement.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePlacement.Location = new System.Drawing.Point(158, 639);
            this.datePlacement.Name = "datePlacement";
            this.datePlacement.Size = new System.Drawing.Size(162, 22);
            this.datePlacement.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 680);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Type de placement:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 639);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 606);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Montant:";
            // 
            // tabPageHistorique
            // 
            this.tabPageHistorique.AutoScroll = true;
            this.tabPageHistorique.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.tabPageHistorique.Controls.Add(this.labelTitleHistorique5);
            this.tabPageHistorique.Controls.Add(this.buttonEffacer5);
            this.tabPageHistorique.Controls.Add(this.ListBoxHistorique5);
            this.tabPageHistorique.Location = new System.Drawing.Point(4, 25);
            this.tabPageHistorique.Name = "tabPageHistorique";
            this.tabPageHistorique.Size = new System.Drawing.Size(1496, 750);
            this.tabPageHistorique.TabIndex = 4;
            this.tabPageHistorique.Text = "Historique";
            // 
            // labelTitleHistorique5
            // 
            this.labelTitleHistorique5.BackColor = System.Drawing.Color.Transparent;
            this.labelTitleHistorique5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleHistorique5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.labelTitleHistorique5.Location = new System.Drawing.Point(4, 9);
            this.labelTitleHistorique5.Name = "labelTitleHistorique5";
            this.labelTitleHistorique5.Size = new System.Drawing.Size(1168, 27);
            this.labelTitleHistorique5.TabIndex = 135;
            this.labelTitleHistorique5.Text = "Historique";
            this.labelTitleHistorique5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonEffacer5
            // 
            this.buttonEffacer5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEffacer5.BackColor = System.Drawing.Color.Transparent;
            this.buttonEffacer5.Location = new System.Drawing.Point(1367, 649);
            this.buttonEffacer5.Name = "buttonEffacer5";
            this.buttonEffacer5.Size = new System.Drawing.Size(96, 28);
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
            this.ListBoxHistorique5.Location = new System.Drawing.Point(29, 55);
            this.ListBoxHistorique5.Name = "ListBoxHistorique5";
            this.ListBoxHistorique5.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBoxHistorique5.Size = new System.Drawing.Size(1433, 564);
            this.ListBoxHistorique5.TabIndex = 0;
            // 
            // tabControlLeft
            // 
            this.tabControlLeft.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlLeft.Controls.Add(this.tabPageLeftSummary);
            this.tabControlLeft.Location = new System.Drawing.Point(0, 50);
            this.tabControlLeft.Multiline = true;
            this.tabControlLeft.Name = "tabControlLeft";
            this.tabControlLeft.SelectedIndex = 0;
            this.tabControlLeft.Size = new System.Drawing.Size(29, 758);
            this.tabControlLeft.TabIndex = 3;
            this.tabControlLeft.SelectedIndexChanged += new System.EventHandler(this.tabControlLeft_SelectedIndexChanged);
            // 
            // tabPageLeftSummary
            // 
            this.tabPageLeftSummary.Location = new System.Drawing.Point(25, 4);
            this.tabPageLeftSummary.Name = "tabPageLeftSummary";
            this.tabPageLeftSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLeftSummary.Size = new System.Drawing.Size(0, 750);
            this.tabPageLeftSummary.TabIndex = 2;
            this.tabPageLeftSummary.Text = "Sommaire";
            this.tabPageLeftSummary.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1518, 799);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.tabControlLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.MinimumSize = new System.Drawing.Size(1534, 838);
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
            this.tabPagePrets.ResumeLayout(false);
            this.tabPagePrets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAmountAlreadyPayed4)).EndInit();
            this.panelBalanceAndButtons4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartAmortissement)).EndInit();
            this.tabPagePlacements.ResumeLayout(false);
            this.tabPagePlacements.PerformLayout();
            this.tabPageHistorique.ResumeLayout(false);
            this.tabControlLeft.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

			Application.Run(new FormMain());
        }

        private int m_incomesMouseOverIndex = -1;
        private int m_expensesMouseOverIndex = -1;
        private int m_pretsMouseOverIndex = -1;
        private int m_toComeMouseOverIndex = -1;
        private int m_lastTabControlIndex = -1;

        #region General Events

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            try
            {
                SelectAccount accountForm = new SelectAccount(LocalSettings.DatabaseName);
                if (accountForm.ShowDialog(this) == DialogResult.OK)
                    LocalSettings.DatabaseName = accountForm.DatabaseName;
                else
                    Close();

                m_tabPageLeftSummary = tabControlLeft.TabPages[TAB_SUMMARY];
                m_tabPageSolde = tabControlMain.TabPages["tabPageSolde"];
                m_tabPageIncomes = tabControlMain.TabPages["tabPageRevenus"];
                m_tabPageExpenses = tabControlMain.TabPages["tabPageDépenses"];
                m_tabPagePrets = tabControlMain.TabPages["tabPagePrets"];
                m_tabPageHistorique = tabControlMain.TabPages["tabPageHistorique"];
                m_tabPagePlacements = tabControlMain.TabPages["tabPagePlacements"];
                
                if (!File.Exists(LocalSettings.DatabasePath))
                    System.IO.File.Copy(ClassTools.GetConfigDir() + "EmptyBudget.mdb", LocalSettings.DatabasePath, false);

                comboBoxBudgetName.SelectedIndexChanged -= new System.EventHandler(this.comboBoxBudgetYear_SelectedIndexChanged);
                Utils.FillComboBudgetName(comboBoxBudgetName);
                comboBoxBudgetName.SelectedIndexChanged += new System.EventHandler(this.comboBoxBudgetYear_SelectedIndexChanged);

                File.Copy(LocalSettings.DatabasePath, ClassTools.GetConfigDir() + LocalSettings.DatabaseName + "Backup.mdb", true);
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
                    File.Copy(ClassTools.GetConfigDir() + LocalSettings.DatabaseName + "Backup.mdb", LocalSettings.DatabasePath, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void comboBoxBudgetYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocalSettings.DatabaseName = comboBoxBudgetName.Text.Trim();

            File.Copy(LocalSettings.DatabasePath, ClassTools.GetConfigDir() + LocalSettings.DatabaseName + "Backup.mdb", true);
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
                if (listBoxToCome0.SelectedIndex >= 0)
                {
                    TDisplayInfo info = listBoxToCome0.Items[listBoxToCome0.SelectedIndex] as TDisplayInfo;

                    if (m_currentAccountId == -1)
                    {
                        string accountName = ClassAccounts.GetAccounts().GetAccountNameFromId(info.AccountId);
                        tabControlLeft.SelectedTab = tabControlLeft.TabPages[accountName];
                    }
                    if (info != null)
                    {
                        if (info.DataType == EType.e_Income)
                        {
                            int id = GetListIndexFromId(ListBoxRevenus1, info.ID);
                            if (id >= 0)
                                ListBoxRevenus1.SelectedIndex = id;
                            tabControlMain.SelectedIndex = 1;
                        }
                        else if (info.DataType == EType.e_Expense)
                        {
                            int id = GetListIndexFromId(ListBoxDepenses2, info.ID);
                            if (id >= 0)
                                ListBoxDepenses2.SelectedIndex = id;
                            tabControlMain.SelectedIndex = 2;
                        }
                        else if (info.DataType == EType.e_Pret)
                        {
                            int id = GetListIndexFromId(listBoxPrets4, info.ID);
                            if (id >= 0)
                                listBoxPrets4.SelectedIndex = id;
                            tabControlMain.SelectedIndex = 4;
                        }
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
                AddWarningTooltip(ref m_toComeMouseOverIndex, listBoxToCome0, toolTipToCome0, e);
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

        void listBoxPrets4_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                AddWarningTooltip(ref m_pretsMouseOverIndex, listBoxPrets4, toolTipPrets4, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        void listBoxPrets4_DrawItem(object sender, DrawItemEventArgs e)
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

        private void listBoxPrets4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                m_pretsDisplayData.SelectedIndexChanged();
                ComptaCharts.InitializeChartInvestissement(chartAmortissement, m_pretsDisplayData.LastDisplayedTransaction);
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
                    case 3:
                        m_pretsDisplayData.SavePartialTransaction();
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
                    case 3:
                        m_pretsDisplayData.SetDefaultSelectedIndex();
                        listBoxPrets4.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
            m_lastTabControlIndex = tabControlMain.SelectedIndex;
        }

        void textBoxMontantRendement_LostFocus(object sender, EventArgs e)
        {
            try
            {
                Utils.SetResultFromFormula(textBoxMontantRendement);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        void textBoxMontantPlacement_LostFocus(object sender, EventArgs e)
        {
            try
            {
                Utils.SetResultFromFormula(textBoxMontantPlacement);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
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

        private void radioOneShotTrans4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_pretsDisplayData != null)
                    m_pretsDisplayData.UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void radioPeriodicTrans4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_pretsDisplayData != null)
                    m_pretsDisplayData.UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void radioOneTimeInMonthTrans4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_pretsDisplayData != null)
                    m_pretsDisplayData.UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void radioTwoTimesInMonthTrans4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_pretsDisplayData != null)
                    m_pretsDisplayData.UpdateButtonsState();
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

        private void radioButtonIsManual4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_pretsDisplayData != null)
                    m_pretsDisplayData.TransactionModeChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void radioButtonIsAutomatic4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_pretsDisplayData != null)
                    m_pretsDisplayData.TransactionModeChanged();
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

        private void comboBoxPeriodLength4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_pretsDisplayData != null)
                    m_pretsDisplayData.UpdateButtonsState();
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

        private void buttonNewPret_Click(object sender, EventArgs e)
        {
            try
            {
                m_pretsDisplayData.AddNewTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonCancelPret4_Click(object sender, EventArgs e)
        {
            try
            {
                m_pretsDisplayData.CancelPartialTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonSavePret4_Click(object sender, EventArgs e)
        {
            try
            {
                m_pretsDisplayData.SaveTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonDeletePret4_Click(object sender, EventArgs e)
        {
            try
            {
                m_pretsDisplayData.DeleteTransaction();
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

        private void buttonNouveauPlacement_Click(object sender, EventArgs e)
        {
            try
            {
                AddPlacement(textBoxMontantPlacement.Text, datePlacement.Value, ClassTools.ConvertPlacementType(comboBoxPlacement.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonNouveauRendement_Click(object sender, EventArgs e)
        {
            try
            {
                AddPlacement(textBoxMontantRendement.Text, dateRendement.Value, ClassTools.ConvertPlacementType(comboBoxRendement.Text), true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonDeletePlacement_Click(object sender, EventArgs e)
        {
            try
            {
                TDisplayInfo displayInfo = listBoxPlacements.SelectedItem as TDisplayInfo;
                PlacementInfoData.DeletePlacement(displayInfo.ID);
                listBoxPlacements.Items.RemoveAt(listBoxPlacements.SelectedIndex);

                ClassPlacements.GetPlacements().LoadPlacementsFromDataStorage();
                AddPlacementsInList();
                if (listBoxPlacements.Items.Count > 0)
                    listBoxPlacements.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonDeleteRendement_Click(object sender, EventArgs e)
        {
            try
            {
                TDisplayInfo displayInfo = listBoxRendements.SelectedItem as TDisplayInfo;
                PlacementInfoData.DeletePlacement(displayInfo.ID);
                listBoxRendements.Items.RemoveAt(listBoxRendements.SelectedIndex);

                ClassPlacements.GetPlacements().LoadPlacementsFromDataStorage();
                AddPlacementsInList();
                if (listBoxRendements.Items.Count > 0)
                    listBoxRendements.SelectedIndex = 0;
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

        private void buttonUpPrets_Click(object sender, EventArgs e)
        {
            try
            {
                PutItemUpInList(listBoxPrets4);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
        }

        private void buttonDownPrets_Click(object sender, EventArgs e)
        {
            try
            {
                PutItemDownInList(listBoxPrets4);
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

        private void comboBoxPaiementType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPaiementType4.SelectedIndex)
            {
                case 0:
                    labelPaiementType4.Text = "ans";
                    if (comboBoxPeriodLength4.Items.Count < 5)
                        comboBoxPeriodLength4.Items.Add(Utils.ACCELERATED_PAIEMENTS);
                    break;
                case 1:
                    labelPaiementType4.Text = "mois";
                    if (comboBoxPeriodLength4.Items.Count < 5)
                        comboBoxPeriodLength4.Items.Add(Utils.ACCELERATED_PAIEMENTS);
                    break;
                case 2:
                    labelPaiementType4.Text = "$";
                    if (comboBoxPeriodLength4.Items.Count >= 5)
                        comboBoxPeriodLength4.Items.RemoveAt(4);
                    break;
            }
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog(this);
        }

        private void comboBoxPretType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_pretsDisplayData != null)
                    m_pretsDisplayData.UpdateButtonsState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " (" + ex.StackTrace + ")", "Erreur");
            }
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

        private void chartAmortissement_Click(object sender, EventArgs e)
        {
            ChartAmortissementWindow chartWindow = new ChartAmortissementWindow(m_pretsDisplayData.LastDisplayedTransaction);
            chartWindow.ShowDialog(this);
        }

        private void chartPredictedBalances_Click(object sender, EventArgs e)
        {
            DateTime endDate = CurrentEndPredictionDate;
            DateTime startDate = (DateTime.Now.Date >= CurrentStartPredictionDate.Date ? DateTime.Now.AddDays(1) : CurrentStartPredictionDate);
            double soldeActuel = Utils.ConvertToDouble(textBoxSoldeActuel0.Text.Trim());

            var chartWindow = new ChartPredictedBalanceWindow(this, startDate, endDate, soldeActuel, EPeriodLength.e_PerWeek);
            chartWindow.ShowDialog(this);
        }
    }
}
