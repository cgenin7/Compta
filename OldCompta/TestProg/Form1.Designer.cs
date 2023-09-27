namespace TestProg
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.textBoxFirst = new System.Windows.Forms.TextBox();
            this.labelFirst = new System.Windows.Forms.Label();
            this.textBoxSecond = new System.Windows.Forms.TextBox();
            this.buttonGetNextTime = new System.Windows.Forms.Button();
            this.labelNextTime = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPeriod = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelFirstTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonNbPeriods = new System.Windows.Forms.Button();
            this.labelNbPeriods = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.datePeriodEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.datePeriodStart = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.listBoxPeriodDates = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.textBoxAmortissmentMonths = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxPretType = new System.Windows.Forms.ComboBox();
            this.radioPaiementPerPeriod = new System.Windows.Forms.RadioButton();
            this.radioAmortissement = new System.Windows.Forms.RadioButton();
            this.textBoxPaiementPerPeriod = new System.Windows.Forms.TextBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxInterestRate = new System.Windows.Forms.TextBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Date";
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(163, 22);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(124, 20);
            this.dateStart.TabIndex = 1;
            this.dateStart.ValueChanged += new System.EventHandler(this.dateStart_ValueChanged);
            // 
            // textBoxFirst
            // 
            this.textBoxFirst.Location = new System.Drawing.Point(163, 179);
            this.textBoxFirst.Name = "textBoxFirst";
            this.textBoxFirst.Size = new System.Drawing.Size(124, 20);
            this.textBoxFirst.TabIndex = 2;
            this.textBoxFirst.Text = "1";
            // 
            // labelFirst
            // 
            this.labelFirst.AutoSize = true;
            this.labelFirst.Location = new System.Drawing.Point(42, 187);
            this.labelFirst.Name = "labelFirst";
            this.labelFirst.Size = new System.Drawing.Size(91, 13);
            this.labelFirst.TabIndex = 3;
            this.labelFirst.Text = "First time in month";
            // 
            // textBoxSecond
            // 
            this.textBoxSecond.Location = new System.Drawing.Point(163, 225);
            this.textBoxSecond.Name = "textBoxSecond";
            this.textBoxSecond.Size = new System.Drawing.Size(124, 20);
            this.textBoxSecond.TabIndex = 4;
            this.textBoxSecond.Text = "15";
            // 
            // buttonGetNextTime
            // 
            this.buttonGetNextTime.Location = new System.Drawing.Point(163, 269);
            this.buttonGetNextTime.Name = "buttonGetNextTime";
            this.buttonGetNextTime.Size = new System.Drawing.Size(99, 23);
            this.buttonGetNextTime.TabIndex = 6;
            this.buttonGetNextTime.Text = "Get next time";
            this.buttonGetNextTime.UseVisualStyleBackColor = true;
            this.buttonGetNextTime.Click += new System.EventHandler(this.buttonGetNextTime_Click);
            // 
            // labelNextTime
            // 
            this.labelNextTime.AutoSize = true;
            this.labelNextTime.Location = new System.Drawing.Point(186, 305);
            this.labelNextTime.Name = "labelNextTime";
            this.labelNextTime.Size = new System.Drawing.Size(51, 13);
            this.labelNextTime.TabIndex = 7;
            this.labelNextTime.Text = "Next time";
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "OneShot",
            "Day",
            "Week",
            "Month",
            "Year",
            "TwoTimesInMonth"});
            this.comboBoxType.Location = new System.Drawing.Point(163, 108);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(124, 21);
            this.comboBoxType.TabIndex = 10;
            this.comboBoxType.Text = "Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Period";
            // 
            // textBoxPeriod
            // 
            this.textBoxPeriod.Location = new System.Drawing.Point(163, 144);
            this.textBoxPeriod.Name = "textBoxPeriod";
            this.textBoxPeriod.Size = new System.Drawing.Size(124, 20);
            this.textBoxPeriod.TabIndex = 13;
            this.textBoxPeriod.Text = "1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Get first time";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonFirstTime_Click);
            // 
            // labelFirstTime
            // 
            this.labelFirstTime.AutoSize = true;
            this.labelFirstTime.Location = new System.Drawing.Point(46, 305);
            this.labelFirstTime.Name = "labelFirstTime";
            this.labelFirstTime.Size = new System.Drawing.Size(48, 13);
            this.labelFirstTime.TabIndex = 15;
            this.labelFirstTime.Text = "First time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Second time in month";
            // 
            // buttonNbPeriods
            // 
            this.buttonNbPeriods.Location = new System.Drawing.Point(346, 108);
            this.buttonNbPeriods.Name = "buttonNbPeriods";
            this.buttonNbPeriods.Size = new System.Drawing.Size(130, 23);
            this.buttonNbPeriods.TabIndex = 17;
            this.buttonNbPeriods.Text = "Get number of periods";
            this.buttonNbPeriods.UseVisualStyleBackColor = true;
            this.buttonNbPeriods.Click += new System.EventHandler(this.buttonNbPeriods_Click);
            // 
            // labelNbPeriods
            // 
            this.labelNbPeriods.AutoSize = true;
            this.labelNbPeriods.Location = new System.Drawing.Point(500, 113);
            this.labelNbPeriods.Name = "labelNbPeriods";
            this.labelNbPeriods.Size = new System.Drawing.Size(58, 13);
            this.labelNbPeriods.TabIndex = 20;
            this.labelNbPeriods.Text = "Nb periods";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "End Date";
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(163, 66);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(124, 20);
            this.dateEnd.TabIndex = 22;
            // 
            // datePeriodEnd
            // 
            this.datePeriodEnd.Location = new System.Drawing.Point(425, 72);
            this.datePeriodEnd.Name = "datePeriodEnd";
            this.datePeriodEnd.Size = new System.Drawing.Size(145, 20);
            this.datePeriodEnd.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(343, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "End";
            // 
            // datePeriodStart
            // 
            this.datePeriodStart.Location = new System.Drawing.Point(425, 23);
            this.datePeriodStart.Name = "datePeriodStart";
            this.datePeriodStart.Size = new System.Drawing.Size(145, 20);
            this.datePeriodStart.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(343, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Start";
            // 
            // listBoxPeriodDates
            // 
            this.listBoxPeriodDates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxPeriodDates.FormattingEnabled = true;
            this.listBoxPeriodDates.Location = new System.Drawing.Point(327, 145);
            this.listBoxPeriodDates.Name = "listBoxPeriodDates";
            this.listBoxPeriodDates.Size = new System.Drawing.Size(441, 381);
            this.listBoxPeriodDates.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 336);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Amount";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(193, 336);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(126, 20);
            this.textBoxAmount.TabIndex = 28;
            this.textBoxAmount.Text = "100 000";
            // 
            // textBoxAmortissmentMonths
            // 
            this.textBoxAmortissmentMonths.Location = new System.Drawing.Point(193, 409);
            this.textBoxAmortissmentMonths.Name = "textBoxAmortissmentMonths";
            this.textBoxAmortissmentMonths.Size = new System.Drawing.Size(126, 20);
            this.textBoxAmortissmentMonths.TabIndex = 30;
            this.textBoxAmortissmentMonths.Text = "120";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(48, 479);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Type";
            // 
            // comboBoxPretType
            // 
            this.comboBoxPretType.FormattingEnabled = true;
            this.comboBoxPretType.Items.AddRange(new object[] {
            "Mortgage",
            "MortgageLinked",
            "Pret",
            "PretLinked"});
            this.comboBoxPretType.Location = new System.Drawing.Point(195, 476);
            this.comboBoxPretType.Name = "comboBoxPretType";
            this.comboBoxPretType.Size = new System.Drawing.Size(126, 21);
            this.comboBoxPretType.TabIndex = 32;
            this.comboBoxPretType.Text = "Mortgage";
            // 
            // radioPaiementPerPeriod
            // 
            this.radioPaiementPerPeriod.AutoSize = true;
            this.radioPaiementPerPeriod.Checked = true;
            this.radioPaiementPerPeriod.Location = new System.Drawing.Point(49, 373);
            this.radioPaiementPerPeriod.Name = "radioPaiementPerPeriod";
            this.radioPaiementPerPeriod.Size = new System.Drawing.Size(119, 17);
            this.radioPaiementPerPeriod.TabIndex = 34;
            this.radioPaiementPerPeriod.TabStop = true;
            this.radioPaiementPerPeriod.Text = "Paiement per period";
            this.radioPaiementPerPeriod.UseVisualStyleBackColor = true;
            // 
            // radioAmortissement
            // 
            this.radioAmortissement.AutoSize = true;
            this.radioAmortissement.Location = new System.Drawing.Point(49, 409);
            this.radioAmortissement.Name = "radioAmortissement";
            this.radioAmortissement.Size = new System.Drawing.Size(124, 17);
            this.radioAmortissement.TabIndex = 35;
            this.radioAmortissement.Text = "Amortissment months";
            this.radioAmortissement.UseVisualStyleBackColor = true;
            // 
            // textBoxPaiementPerPeriod
            // 
            this.textBoxPaiementPerPeriod.Location = new System.Drawing.Point(193, 372);
            this.textBoxPaiementPerPeriod.Name = "textBoxPaiementPerPeriod";
            this.textBoxPaiementPerPeriod.Size = new System.Drawing.Size(126, 20);
            this.textBoxPaiementPerPeriod.TabIndex = 36;
            this.textBoxPaiementPerPeriod.Text = "920";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(49, 506);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(75, 23);
            this.buttonCalculate.TabIndex = 37;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 443);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 39;
            this.label9.Text = "Interest rate";
            // 
            // textBoxInterestRate
            // 
            this.textBoxInterestRate.Location = new System.Drawing.Point(193, 443);
            this.textBoxInterestRate.Name = "textBoxInterestRate";
            this.textBoxInterestRate.Size = new System.Drawing.Size(126, 20);
            this.textBoxInterestRate.TabIndex = 38;
            this.textBoxInterestRate.Text = "5";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(48, 543);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(37, 13);
            this.labelResult.TabIndex = 40;
            this.labelResult.Text = "Result";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 577);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxInterestRate);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.textBoxPaiementPerPeriod);
            this.Controls.Add(this.radioAmortissement);
            this.Controls.Add(this.radioPaiementPerPeriod);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBoxPretType);
            this.Controls.Add(this.textBoxAmortissmentMonths);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.listBoxPeriodDates);
            this.Controls.Add(this.datePeriodEnd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.datePeriodStart);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelNbPeriods);
            this.Controls.Add(this.buttonNbPeriods);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelFirstTime);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxPeriod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.labelNextTime);
            this.Controls.Add(this.buttonGetNextTime);
            this.Controls.Add(this.textBoxSecond);
            this.Controls.Add(this.labelFirst);
            this.Controls.Add(this.textBoxFirst);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.TextBox textBoxFirst;
        private System.Windows.Forms.Label labelFirst;
        private System.Windows.Forms.TextBox textBoxSecond;
        private System.Windows.Forms.Button buttonGetNextTime;
        private System.Windows.Forms.Label labelNextTime;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPeriod;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelFirstTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonNbPeriods;
        private System.Windows.Forms.Label labelNbPeriods;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker datePeriodEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker datePeriodStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBoxPeriodDates;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.TextBox textBoxAmortissmentMonths;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxPretType;
        private System.Windows.Forms.RadioButton radioPaiementPerPeriod;
        private System.Windows.Forms.RadioButton radioAmortissement;
        private System.Windows.Forms.TextBox textBoxPaiementPerPeriod;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxInterestRate;
        private System.Windows.Forms.Label labelResult;
    }
}

