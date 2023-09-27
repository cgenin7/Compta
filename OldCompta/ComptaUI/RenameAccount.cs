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

namespace Compta
{
    public partial class RenameAccount : Form
    {
        public RenameAccount(FormMain form)
        {
            m_form = form;
            InitializeComponent();
            FillComboBoxAccounts();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            m_form.OldName = comboBoxAccounts.Text;
            m_form.NewName = textBoxNewName.Text;

            if (string.IsNullOrEmpty(m_form.OldName) || string.IsNullOrEmpty(m_form.NewName))
                MessageBox.Show("L'ancien et le nouveau nom de compte ne peuvent pas être vides.");
        }

        private void FillComboBoxAccounts()
        {
            Dictionary<int, TAccountInfo> accounts = ClassAccounts.GetAccounts().AccountsInfo;
            comboBoxAccounts.Items.Clear();

            if (accounts != null)
            {
                foreach (TAccountInfo account in accounts.Values)
                    comboBoxAccounts.Items.Add(account.AccountName);
            }
        }

        private FormMain m_form;
    }
}
