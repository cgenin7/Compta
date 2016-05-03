using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComptaCommun;

namespace Compta
{
    public partial class SelectAccount : Form
    {
        public SelectAccount(string databaseName)
        {
            InitializeComponent();
            Utils.FillComboBudgetName(comboBoxBudgetName);
            comboBoxBudgetName.SelectedText = databaseName;
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            DatabaseName = comboBoxBudgetName.Text.Trim();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }

        public string DatabaseName { get; private set; }
    }
}
