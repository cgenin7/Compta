namespace Compta
{
    partial class AddBudgetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBudgetForm));
            this.comboBoxExistingNames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxCopyFromOldBudget = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxNewBudgetYear = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNewBudgetName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxExistingNames
            // 
            this.comboBoxExistingNames.FormattingEnabled = true;
            this.comboBoxExistingNames.Location = new System.Drawing.Point(194, 109);
            this.comboBoxExistingNames.Name = "comboBoxExistingNames";
            this.comboBoxExistingNames.Size = new System.Drawing.Size(175, 21);
            this.comboBoxExistingNames.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Année du nouveau budget:";
            // 
            // checkBoxCopyFromOldBudget
            // 
            this.checkBoxCopyFromOldBudget.AutoSize = true;
            this.checkBoxCopyFromOldBudget.Location = new System.Drawing.Point(16, 110);
            this.checkBoxCopyFromOldBudget.Name = "checkBoxCopyFromOldBudget";
            this.checkBoxCopyFromOldBudget.Size = new System.Drawing.Size(170, 17);
            this.checkBoxCopyFromOldBudget.TabIndex = 4;
            this.checkBoxCopyFromOldBudget.Text = "Copier les données du budget:";
            this.checkBoxCopyFromOldBudget.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(213, 165);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Annuler";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(294, 165);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxNewBudgetYear
            // 
            this.textBoxNewBudgetYear.Location = new System.Drawing.Point(195, 24);
            this.textBoxNewBudgetYear.Name = "textBoxNewBudgetYear";
            this.textBoxNewBudgetYear.Size = new System.Drawing.Size(174, 20);
            this.textBoxNewBudgetYear.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nom du nouveau budget:";
            // 
            // textBoxNewBudgetName
            // 
            this.textBoxNewBudgetName.Location = new System.Drawing.Point(195, 65);
            this.textBoxNewBudgetName.Name = "textBoxNewBudgetName";
            this.textBoxNewBudgetName.Size = new System.Drawing.Size(174, 20);
            this.textBoxNewBudgetName.TabIndex = 9;
            // 
            // AddBudgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 215);
            this.Controls.Add(this.textBoxNewBudgetName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNewBudgetYear);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.checkBoxCopyFromOldBudget);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxExistingNames);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddBudgetForm";
            this.Text = "Ajouter un nouveau budget";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxExistingNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxCopyFromOldBudget;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxNewBudgetYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNewBudgetName;
    }
}