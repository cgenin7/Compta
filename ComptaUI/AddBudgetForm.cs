using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Compta
{
    public partial class AddBudgetForm : Form
    {
        public AddBudgetForm()
        {
            InitializeComponent();

            Utils.FillComboBudgetName(comboBoxExistingNames);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Success = false;

            if (checkBoxCopyFromOldBudget.Checked)
                OldBudgetName = comboBoxExistingNames.Text;
            else
                OldBudgetName = "";

            NewBudgetName = textBoxNewBudgetYear.Text + textBoxNewBudgetName.Text;

            int newBudgetYear;
            if (int.TryParse(textBoxNewBudgetYear.Text, out newBudgetYear))
            {
                if (newBudgetYear < 1900 || newBudgetYear > 3000)
                {
                    MessageBox.Show("L'année du nouveau budget est invalide");
                    return;
                }
                Success = true;
            }
            else
            {
                MessageBox.Show("L'année du nouveau budget est invalide");
            }
        }

        public bool Success;
        public string NewBudgetName {get; private set;}
        public string OldBudgetName {get; private set;}
    }
}
