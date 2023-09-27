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
    public partial class AccountsCurrentBalanceForm : Form
    {
        public AccountsCurrentBalanceForm(string accountName)
        {
            InitializeComponent();
            labelSolde.Text = "Solde actuel du compte " + accountName + ": ";
            textBoxCurrentBalance.Text = ClassTools.ConvertDoubleToString(m_currentBalance);
            textBoxCurrentBalance.LostFocus += new EventHandler(textBoxCurrentBalance_LostFocus);
            textBoxCurrentBalance.GotFocus += new EventHandler(textBoxCurrentBalance_GotFocus);
        }

        void textBoxCurrentBalance_GotFocus(object sender, EventArgs e)
        {
            textBoxCurrentBalance.TextChanged -= textBoxCurrentBalance_TextChanged;
            Utils.SetBackFormula(textBoxCurrentBalance);
            textBoxCurrentBalance.TextChanged += textBoxCurrentBalance_TextChanged;
        }

        void textBoxCurrentBalance_LostFocus(object sender, EventArgs e)
        {
            Utils.SetResultFromFormula(textBoxCurrentBalance);
        }

        public double CurrentBalance
        {
            get { return m_currentBalance; }
            set 
            { 
                m_currentBalance = value;
                textBoxCurrentBalance.Text = ClassTools.ConvertDoubleToString(m_currentBalance); 
            }
        }
        
        private void textBoxCurrentBalance_TextChanged(object sender, EventArgs e)
        {
            m_currentBalance = Utils.ConvertToDouble(textBoxCurrentBalance.Text);
        }

        private double m_currentBalance = 0;

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
