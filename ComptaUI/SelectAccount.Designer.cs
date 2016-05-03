namespace Compta
{
    partial class SelectAccount
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
            this.comboBoxBudgetName = new System.Windows.Forms.ComboBox();
            this.labelBudgetYear = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxBudgetName
            // 
            this.comboBoxBudgetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.comboBoxBudgetName.FormattingEnabled = true;
            this.comboBoxBudgetName.Location = new System.Drawing.Point(108, 28);
            this.comboBoxBudgetName.Name = "comboBoxBudgetName";
            this.comboBoxBudgetName.Size = new System.Drawing.Size(252, 21);
            this.comboBoxBudgetName.TabIndex = 2;
            // 
            // labelBudgetYear
            // 
            this.labelBudgetYear.AutoSize = true;
            this.labelBudgetYear.BackColor = System.Drawing.Color.Transparent;
            this.labelBudgetYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelBudgetYear.Location = new System.Drawing.Point(26, 31);
            this.labelBudgetYear.Name = "labelBudgetYear";
            this.labelBudgetYear.Size = new System.Drawing.Size(44, 13);
            this.labelBudgetYear.TabIndex = 134;
            this.labelBudgetYear.Text = "Budget:";
            this.labelBudgetYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(285, 64);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 136;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ButtonNext
            // 
            this.ButtonNext.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonNext.Location = new System.Drawing.Point(193, 64);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(75, 23);
            this.ButtonNext.TabIndex = 1;
            this.ButtonNext.Text = "Suivant";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // SelectAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 109);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.comboBoxBudgetName);
            this.Controls.Add(this.labelBudgetYear);
            this.Name = "SelectAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sélectionner le budget";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxBudgetName;
        private System.Windows.Forms.Label labelBudgetYear;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button ButtonNext;
    }
}