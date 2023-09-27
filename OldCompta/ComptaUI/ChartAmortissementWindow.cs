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
    public partial class ChartAmortissementWindow : Form
    {
        public ChartAmortissementWindow(TTransactionInfo info)
        {
            InitializeComponent();
            ComptaCharts.InitializeChartInvestissement(chartAmortissement, info, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chartAmortissement_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
