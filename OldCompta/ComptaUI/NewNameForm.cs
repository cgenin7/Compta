using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Compta
{
    public partial class NewNameForm : Form
    {
        public NewNameForm(FormMain form)
        {
            m_form = form;
            InitializeComponent();
        }

        public NewNameForm(FormMain form, string sTitle, string name)
        {
            m_form = form;
            InitializeComponent();
            Text = sTitle;
            labelName.Text = name;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            m_form.NewName = textBoxName.Text;
            if (string.IsNullOrEmpty(m_form.NewName))
                MessageBox.Show("Le nom du compte ne peut pas être vide.");
        }

        private FormMain m_form;
    }
}
