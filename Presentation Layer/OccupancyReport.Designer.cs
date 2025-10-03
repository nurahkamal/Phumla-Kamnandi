namespace Phumla_Kamnandi.Presentation_Layer
{
    partial class OccupancyReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OccupancyReport));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnExit = new Guna.UI2.WinForms.Guna2ImageButton();
            this.chartDailyOccupancy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRoomUtilization = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartGuestTrends = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSeasonalRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyOccupancy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRoomUtilization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGuestTrends)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSeasonalRevenue)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(153)))), ((int)(((byte)(127)))));
            this.panel1.Controls.Add(this.picBoxLogo);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 812);
            this.panel1.TabIndex = 1;
            // 
            // picBoxLogo
            // 
            this.picBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("picBoxLogo.Image")));
            this.picBoxLogo.Location = new System.Drawing.Point(101, 41);
            this.picBoxLogo.Name = "picBoxLogo";
            this.picBoxLogo.Size = new System.Drawing.Size(151, 143);
            this.picBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxLogo.TabIndex = 1;
            this.picBoxLogo.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(65)))), ((int)(((byte)(57)))));
            this.lblWelcome.Location = new System.Drawing.Point(31, 206);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(288, 124);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome to the \r\nPhumla Kamnandi \r\nHotel Reservation System\r\n\r\n";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnExit.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnExit.HoverState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnExit.ImageRotate = 0F;
            this.btnExit.ImageSize = new System.Drawing.Size(40, 40);
            this.btnExit.Location = new System.Drawing.Point(1674, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.btnExit.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnExit.Size = new System.Drawing.Size(76, 64);
            this.btnExit.TabIndex = 6;
            this.btnExit.UseTransparentBackground = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // chartDailyOccupancy
            // 
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Format = "MMM dd";
            chartArea1.AxisY.Maximum = 5D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Rooms Occupied";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY2.Maximum = 100D;
            chartArea1.AxisY2.Minimum = 0D;
            chartArea1.AxisY2.Title = "Occupancy Rate %";
            chartArea1.Name = "ChartArea1";
            this.chartDailyOccupancy.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartDailyOccupancy.Legends.Add(legend1);
            this.chartDailyOccupancy.Location = new System.Drawing.Point(369, 105);
            this.chartDailyOccupancy.Name = "chartDailyOccupancy";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsValueShownAsLabel = true;
            series1.Label = "{0}%";
            series1.Legend = "Legend1";
            series1.Name = "OccupancyRate";
            series1.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Black;
            series2.Legend = "Legend1";
            series2.Name = "RoomsOccupied";
            this.chartDailyOccupancy.Series.Add(series1);
            this.chartDailyOccupancy.Series.Add(series2);
            this.chartDailyOccupancy.Size = new System.Drawing.Size(600, 300);
            this.chartDailyOccupancy.TabIndex = 7;
            this.chartDailyOccupancy.Text = "chart1";
            // 
            // chartRoomUtilization
            // 
            chartArea2.Name = "ChartArea1";
            this.chartRoomUtilization.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartRoomUtilization.Legends.Add(legend2);
            this.chartRoomUtilization.Location = new System.Drawing.Point(990, 105);
            this.chartRoomUtilization.Name = "chartRoomUtilization";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series3.Color = System.Drawing.Color.SeaGreen;
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "OccupiedRooms";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            series4.IsValueShownAsLabel = true;
            series4.Legend = "Legend1";
            series4.Name = "AvailableRooms";
            this.chartRoomUtilization.Series.Add(series3);
            this.chartRoomUtilization.Series.Add(series4);
            this.chartRoomUtilization.Size = new System.Drawing.Size(464, 300);
            this.chartRoomUtilization.TabIndex = 8;
            this.chartRoomUtilization.Text = "chart1";
            // 
            // chartGuestTrends
            // 
            chartArea3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.Center;
            chartArea3.Name = "ChartArea1";
            chartArea3.ShadowOffset = 2;
            this.chartGuestTrends.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartGuestTrends.Legends.Add(legend3);
            this.chartGuestTrends.Location = new System.Drawing.Point(369, 432);
            this.chartGuestTrends.Name = "chartGuestTrends";
            series5.BorderColor = System.Drawing.Color.DarkOrange;
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series5.Color = System.Drawing.Color.Orange;
            series5.Legend = "Legend1";
            series5.Name = "GuestCount";
            this.chartGuestTrends.Series.Add(series5);
            this.chartGuestTrends.Size = new System.Drawing.Size(600, 300);
            this.chartGuestTrends.TabIndex = 9;
            this.chartGuestTrends.Text = "chart1";
            // 
            // chartSeasonalRevenue
            // 
            chartArea4.Name = "ChartArea1";
            this.chartSeasonalRevenue.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartSeasonalRevenue.Legends.Add(legend4);
            this.chartSeasonalRevenue.Location = new System.Drawing.Point(990, 432);
            this.chartSeasonalRevenue.Name = "chartSeasonalRevenue";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series6.IsValueShownAsLabel = true;
            series6.LabelFormat = "{0:C}";
            series6.Legend = "Legend1";
            series6.Name = "SeasonalRevenue";
            series6.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            this.chartSeasonalRevenue.Series.Add(series6);
            this.chartSeasonalRevenue.Size = new System.Drawing.Size(464, 300);
            this.chartSeasonalRevenue.TabIndex = 10;
            this.chartSeasonalRevenue.Text = "chart1";
            // 
            // OccupancyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(218)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(1808, 810);
            this.Controls.Add(this.chartSeasonalRevenue);
            this.Controls.Add(this.chartGuestTrends);
            this.Controls.Add(this.chartRoomUtilization);
            this.Controls.Add(this.chartDailyOccupancy);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OccupancyReport";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyOccupancy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRoomUtilization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGuestTrends)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSeasonalRevenue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picBoxLogo;
        private System.Windows.Forms.Label lblWelcome;
        private Guna.UI2.WinForms.Guna2ImageButton btnExit;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDailyOccupancy;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRoomUtilization;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGuestTrends;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSeasonalRevenue;
    }
}