using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ComptaCommun;

namespace Compta
{
    public partial class ChartWindow : Form
    {
        public ChartWindow(int year, int accountId)
        {
            InitializeComponent();

            ComptaCharts.InitializeChartAnnuals(chartMain, year, accountId, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chartMain_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
