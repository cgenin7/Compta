namespace Compta
{
    partial class ChartPredictedBalanceWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 150D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, -30D);
            this.chartPredictedBalances = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelIncomesToCome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartPredictedBalances)).BeginInit();
            this.SuspendLayout();
            // 
            // chartPredictedBalances
            // 
            this.chartPredictedBalances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartPredictedBalances.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.LabelStyle.Angle = 90;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisX.LabelStyle.Interval = 1D;
            chartArea1.AxisX.LabelStyle.IntervalOffset = 1D;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.LabelStyle.Format = "C0";
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            chartArea1.Name = "ChartArea1";
            this.chartPredictedBalances.ChartAreas.Add(chartArea1);
            this.chartPredictedBalances.Location = new System.Drawing.Point(0, 74);
            this.chartPredictedBalances.Margin = new System.Windows.Forms.Padding(0);
            this.chartPredictedBalances.MinimumSize = new System.Drawing.Size(664, 211);
            this.chartPredictedBalances.Name = "chartPredictedBalances";
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "DrawingStyle=Cylinder, LabelStyle=Top, MaxPixelPointWidth=10";
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.LabelBackColor = System.Drawing.Color.Transparent;
            series1.Name = "Series1";
            dataPoint1.Color = System.Drawing.Color.Green;
            dataPoint1.LabelBackColor = System.Drawing.Color.White;
            dataPoint2.Color = System.Drawing.Color.Red;
            dataPoint2.LabelBackColor = System.Drawing.Color.White;
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.SmartLabelStyle.Enabled = false;
            series1.SmartLabelStyle.MovingDirection = ((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles)(((((((((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Top | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Bottom) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Right) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Left) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopLeft) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopRight) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomLeft) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomRight) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Center)));
            this.chartPredictedBalances.Series.Add(series1);
            this.chartPredictedBalances.Size = new System.Drawing.Size(1536, 658);
            this.chartPredictedBalances.TabIndex = 169;
            this.chartPredictedBalances.Text = "chart1";
            this.chartPredictedBalances.Click += new System.EventHandler(this.chartPredictedBalances_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(1507, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(29, 30);
            this.buttonClose.TabIndex = 170;
            this.buttonClose.Text = "x";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelIncomesToCome
            // 
            this.labelIncomesToCome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIncomesToCome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelIncomesToCome.Location = new System.Drawing.Point(126, 20);
            this.labelIncomesToCome.Name = "labelIncomesToCome";
            this.labelIncomesToCome.Size = new System.Drawing.Size(1378, 44);
            this.labelIncomesToCome.TabIndex = 171;
            this.labelIncomesToCome.Text = "SOLDES PRÉDITS";
            this.labelIncomesToCome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChartPredictedBalanceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1536, 741);
            this.ControlBox = false;
            this.Controls.Add(this.labelIncomesToCome);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.chartPredictedBalances);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChartPredictedBalanceWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChartPredictedBalanceWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.chartPredictedBalances)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPredictedBalances;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelIncomesToCome;
    }
}