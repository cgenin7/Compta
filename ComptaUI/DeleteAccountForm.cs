using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Comptability;
using ComptaCommun;

namespace Compta
{
    public partial class DeleteAccountForm : Form
    {
        public DeleteAccountForm(FormMain form, string currentAccountName)
        {
            m_form = form;
            InitializeComponent();

            Dictionary<int, TAccountInfo> accounts = ClassAccounts.GetAccounts().AccountsInfo;
            if (accounts != null)
            {
                foreach (TAccountInfo account in accounts.Values)
                {
                    comboBoxComptes.Items.Add(account.AccountName);
                    if (string.Compare(account.AccountName, currentAccountName, false) == 0)
                    {
                        comboBoxComptes.Text = account.AccountName;
                    }
                }
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (m_form != null)
            {
                m_form.NewName = comboBoxComptes.Text;
            }
        }

        private FormMain m_form;

    }
}
