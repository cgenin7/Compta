namespace Compta
{
    partial class ChartAmortissementWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 150D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, -30D);
            this.button1 = new System.Windows.Forms.Button();
            this.chartAmortissement = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartAmortissement)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1140, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "x";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chartAmortissement
            // 
            this.chartAmortissement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartAmortissement.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.LabelStyle.Angle = 90;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.AxisX.LabelStyle.Interval = 1D;
            chartArea2.AxisX.LabelStyle.IntervalOffset = 1D;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.LabelStyle.Format = "C0";
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            chartArea2.Name = "ChartArea1";
            this.chartAmortissement.ChartAreas.Add(chartArea2);
            this.chartAmortissement.Location = new System.Drawing.Point(-3, 76);
            this.chartAmortissement.Margin = new System.Windows.Forms.Padding(0);
            this.chartAmortissement.MinimumSize = new System.Drawing.Size(664, 211);
            this.chartAmortissement.Name = "chartAmortissement";
            series2.ChartArea = "ChartArea1";
            series2.CustomProperties = "DrawingStyle=Cylinder, LabelStyle=Top, MaxPixelPointWidth=10";
            series2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.LabelBackColor = System.Drawing.Color.Transparent;
            series2.LabelFormat = "$";
            series2.Name = "Series1";
            dataPoint3.Color = System.Drawing.Color.Green;
            dataPoint3.LabelBackColor = System.Drawing.Color.White;
            dataPoint4.Color = System.Drawing.Color.Red;
            dataPoint4.LabelBackColor = System.Drawing.Color.White;
            series2.Points.Add(dataPoint3);
            series2.Points.Add(dataPoint4);
            series2.SmartLabelStyle.Enabled = false;
            series2.SmartLabelStyle.MovingDirection = ((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles)(((((((((System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Top | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Bottom) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Right) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Left) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopLeft) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.TopRight) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomLeft) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.BottomRight) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAlignmentStyles.Center)));
            this.chartAmortissement.Series.Add(series2);
            this.chartAmortissement.Size = new System.Drawing.Size(1137, 549);
            this.chartAmortissement.TabIndex = 165;
            this.chartAmortissement.Text = "chart1";
            this.chartAmortissement.Click += new System.EventHandler(this.chartAmortissement_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(105, 30);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(979, 38);
            this.textBox2.TabIndex = 166;
            this.textBox2.Text = "AMORTISSEMENT";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChartAmortissementWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 634);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.chartAmortissement);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChartAmortissementWindow";
            this.Text = "v";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.chartAmortissement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAmortissement;
        private System.Windows.Forms.TextBox textBox2;
    }
}