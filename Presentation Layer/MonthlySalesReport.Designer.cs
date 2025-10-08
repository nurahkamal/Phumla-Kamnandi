namespace Phumla_Kamnandi.Presentation_Layer
{
    partial class MonthlySalesReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonthlySalesReport));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrintSummary = new Guna.UI2.WinForms.Guna2Button();
            this.picBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnExit = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnOkay = new Guna.UI2.WinForms.Guna2Button();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.chartSalesTrend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSeasonalRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDailyRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPaymentsByDate = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartGuestDistribution = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnToday = new Guna.UI2.WinForms.Guna2Button();
            this.btnLastSevenDays = new Guna.UI2.WinForms.Guna2Button();
            this.btnThisMonth = new Guna.UI2.WinForms.Guna2Button();
            this.btnDecember = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSeasonalRevenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyRevenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPaymentsByDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGuestDistribution)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(153)))), ((int)(((byte)(127)))));
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.btnPrintSummary);
            this.panel1.Controls.Add(this.picBoxLogo);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 1200);
            this.panel1.TabIndex = 2;
            // 
            // btnPrint
            // 
            this.btnPrint.AutoRoundedCorners = true;
            this.btnPrint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrint.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(93)))), ((int)(((byte)(71)))));
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(72, 370);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(180, 36);
            this.btnPrint.TabIndex = 22;
            this.btnPrint.Text = "Print Report";
            // 
            // btnPrintSummary
            // 
            this.btnPrintSummary.AutoRoundedCorners = true;
            this.btnPrintSummary.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrintSummary.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrintSummary.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrintSummary.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrintSummary.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(93)))), ((int)(((byte)(71)))));
            this.btnPrintSummary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrintSummary.ForeColor = System.Drawing.Color.White;
            this.btnPrintSummary.Location = new System.Drawing.Point(72, 330);
            this.btnPrintSummary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintSummary.Name = "btnPrintSummary";
            this.btnPrintSummary.Size = new System.Drawing.Size(180, 36);
            this.btnPrintSummary.TabIndex = 21;
            this.btnPrintSummary.Text = "Print Summary";
            // 
            // picBoxLogo
            // 
            this.picBoxLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("picBoxLogo.Image")));
            this.picBoxLogo.Location = new System.Drawing.Point(101, 41);
            this.picBoxLogo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxLogo.Name = "picBoxLogo";
            this.picBoxLogo.Size = new System.Drawing.Size(150, 142);
            this.picBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxLogo.TabIndex = 1;
            this.picBoxLogo.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(65)))), ((int)(((byte)(57)))));
            this.lblWelcome.Location = new System.Drawing.Point(17, 204);
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
            this.btnExit.Location = new System.Drawing.Point(1981, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.btnExit.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnExit.Size = new System.Drawing.Size(56, 48);
            this.btnExit.TabIndex = 7;
            this.btnExit.UseTransparentBackground = true;
            // 
            // btnOkay
            // 
            this.btnOkay.AutoRoundedCorners = true;
            this.btnOkay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOkay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOkay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOkay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOkay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOkay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(99)))));
            this.btnOkay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOkay.ForeColor = System.Drawing.Color.White;
            this.btnOkay.Location = new System.Drawing.Point(796, 28);
            this.btnOkay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(69, 36);
            this.btnOkay.TabIndex = 22;
            this.btnOkay.Text = "OK";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.AutoRoundedCorners = true;
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.CustomFormat = "MMM dd, yyyy";
            this.dtpEndDate.FillColor = System.Drawing.Color.Wheat;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(591, 28);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpEndDate.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 36);
            this.dtpEndDate.TabIndex = 21;
            this.dtpEndDate.Value = new System.DateTime(2025, 12, 1, 0, 0, 0, 0);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.AutoRoundedCorners = true;
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.CustomFormat = "MMM dd, yyyy";
            this.dtpStartDate.FillColor = System.Drawing.Color.Wheat;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(373, 28);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStartDate.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 36);
            this.dtpStartDate.TabIndex = 20;
            this.dtpStartDate.Value = new System.DateTime(2025, 12, 1, 0, 0, 0, 0);
            // 
            // chartSalesTrend
            // 
            this.chartSalesTrend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(193)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineWidth = 0;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineWidth = 0;
            chartArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(193)))));
            chartArea1.Name = "ChartArea1";
            this.chartSalesTrend.ChartAreas.Add(chartArea1);
            legend1.Alignment = System.Drawing.StringAlignment.Far;
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(193)))));
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartSalesTrend.Legends.Add(legend1);
            this.chartSalesTrend.Location = new System.Drawing.Point(373, 150);
            this.chartSalesTrend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartSalesTrend.Name = "chartSalesTrend";
            this.chartSalesTrend.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            series1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.Maroon;
            series1.MarkerBorderWidth = 4;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "SalesTrend";
            this.chartSalesTrend.Series.Add(series1);
            this.chartSalesTrend.Size = new System.Drawing.Size(1147, 255);
            this.chartSalesTrend.TabIndex = 27;
            this.chartSalesTrend.Text = "chart1";
            title1.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title1.Name = "Sales Trend Over Time";
            title1.Text = "Sales Trend Over Time";
            this.chartSalesTrend.Titles.Add(title1);
            // 
            // chartSeasonalRevenue
            // 
            this.chartSeasonalRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(193)))));
            chartArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(193)))));
            chartArea2.Name = "ChartArea1";
            this.chartSeasonalRevenue.ChartAreas.Add(chartArea2);
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(193)))));
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chartSeasonalRevenue.Legends.Add(legend2);
            this.chartSeasonalRevenue.Location = new System.Drawing.Point(1545, 150);
            this.chartSeasonalRevenue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartSeasonalRevenue.Name = "chartSeasonalRevenue";
            this.chartSeasonalRevenue.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "SeasonalRevenue";
            this.chartSeasonalRevenue.Series.Add(series2);
            this.chartSeasonalRevenue.Size = new System.Drawing.Size(471, 571);
            this.chartSeasonalRevenue.TabIndex = 28;
            this.chartSeasonalRevenue.Text = "chart1";
            title2.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title2.Name = "Revenue by Season Period";
            title2.Text = "Revenue by Season Period";
            this.chartSeasonalRevenue.Titles.Add(title2);
            // 
            // chartDailyRevenue
            // 
            this.chartDailyRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(193)))));
            chartArea3.AxisX.IsMarginVisible = false;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea3.AxisX.MajorGrid.LineWidth = 0;
            chartArea3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(193)))));
            chartArea3.Name = "ChartArea1";
            this.chartDailyRevenue.ChartAreas.Add(chartArea3);
            legend3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(193)))));
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            this.chartDailyRevenue.Legends.Add(legend3);
            this.chartDailyRevenue.Location = new System.Drawing.Point(927, 421);
            this.chartDailyRevenue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartDailyRevenue.Name = "chartDailyRevenue";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.Sienna;
            series3.Legend = "Legend1";
            series3.Name = "DailyRevenue";
            this.chartDailyRevenue.Series.Add(series3);
            this.chartDailyRevenue.Size = new System.Drawing.Size(593, 300);
            this.chartDailyRevenue.TabIndex = 29;
            this.chartDailyRevenue.Text = "chart1";
            title3.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title3.Name = "Daily Revenue";
            title3.Text = "Daily Revenue";
            this.chartDailyRevenue.Titles.Add(title3);
            // 
            // chartPaymentsByDate
            // 
            this.chartPaymentsByDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(193)))));
            chartArea4.AxisX.IsMarginVisible = false;
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea4.AxisX.MajorGrid.LineWidth = 0;
            chartArea4.AxisY.IsMarginVisible = false;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea4.AxisY.MajorGrid.LineWidth = 0;
            chartArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(193)))));
            chartArea4.Name = "ChartArea1";
            this.chartPaymentsByDate.ChartAreas.Add(chartArea4);
            legend4.Alignment = System.Drawing.StringAlignment.Far;
            legend4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(193)))));
            legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend4.IsTextAutoFit = false;
            legend4.Name = "Legend1";
            this.chartPaymentsByDate.Legends.Add(legend4);
            this.chartPaymentsByDate.Location = new System.Drawing.Point(375, 421);
            this.chartPaymentsByDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartPaymentsByDate.Name = "chartPaymentsByDate";
            series4.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            series4.BackSecondaryColor = System.Drawing.Color.Chocolate;
            series4.BorderColor = System.Drawing.Color.Maroon;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            series4.LabelBackColor = System.Drawing.Color.Transparent;
            series4.Legend = "Legend1";
            series4.Name = "BookingsCount";
            this.chartPaymentsByDate.Series.Add(series4);
            this.chartPaymentsByDate.Size = new System.Drawing.Size(543, 300);
            this.chartPaymentsByDate.TabIndex = 30;
            this.chartPaymentsByDate.Text = "chart1";
            title4.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title4.Name = "Payments by Date";
            title4.Text = "Payments by Date";
            this.chartPaymentsByDate.Titles.Add(title4);
            // 
            // chartGuestDistribution
            // 
            this.chartGuestDistribution.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(193)))));
            chartArea5.AxisX.IsMarginVisible = false;
            chartArea5.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea5.AxisX.MajorGrid.LineWidth = 0;
            chartArea5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(193)))));
            chartArea5.Name = "ChartArea1";
            this.chartGuestDistribution.ChartAreas.Add(chartArea5);
            legend5.Alignment = System.Drawing.StringAlignment.Far;
            legend5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(210)))), ((int)(((byte)(193)))));
            legend5.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            legend5.IsTextAutoFit = false;
            legend5.Name = "Legend1";
            this.chartGuestDistribution.Legends.Add(legend5);
            this.chartGuestDistribution.Location = new System.Drawing.Point(373, 740);
            this.chartGuestDistribution.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartGuestDistribution.Name = "chartGuestDistribution";
            this.chartGuestDistribution.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series5.Legend = "Legend1";
            series5.Name = "PaymentsCount";
            series5.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            this.chartGuestDistribution.Series.Add(series5);
            this.chartGuestDistribution.Size = new System.Drawing.Size(1643, 311);
            this.chartGuestDistribution.TabIndex = 31;
            this.chartGuestDistribution.Text = "chart1";
            title5.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title5.Name = "Guest Count Distribution";
            title5.Text = "Guest Count Distribution";
            this.chartGuestDistribution.Titles.Add(title5);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(364, 84);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(677, 46);
            this.lblTitle.TabIndex = 32;
            this.lblTitle.Text = "Phumla Kamnandi Hotels - Sales Report\r\n";
            // 
            // btnToday
            // 
            this.btnToday.AutoRoundedCorners = true;
            this.btnToday.BackColor = System.Drawing.Color.Transparent;
            this.btnToday.BorderRadius = 17;
            this.btnToday.CheckedState.FillColor = System.Drawing.Color.White;
            this.btnToday.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnToday.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnToday.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnToday.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnToday.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnToday.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnToday.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(93)))), ((int)(((byte)(71)))));
            this.btnToday.FocusedColor = System.Drawing.Color.Wheat;
            this.btnToday.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnToday.ForeColor = System.Drawing.Color.White;
            this.btnToday.Location = new System.Drawing.Point(1225, 28);
            this.btnToday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(180, 36);
            this.btnToday.TabIndex = 33;
            this.btnToday.Text = "Today";
            // 
            // btnLastSevenDays
            // 
            this.btnLastSevenDays.AutoRoundedCorners = true;
            this.btnLastSevenDays.BackColor = System.Drawing.Color.Transparent;
            this.btnLastSevenDays.BorderRadius = 17;
            this.btnLastSevenDays.CheckedState.FillColor = System.Drawing.Color.Wheat;
            this.btnLastSevenDays.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnLastSevenDays.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLastSevenDays.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLastSevenDays.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLastSevenDays.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLastSevenDays.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLastSevenDays.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(93)))), ((int)(((byte)(71)))));
            this.btnLastSevenDays.FocusedColor = System.Drawing.Color.Wheat;
            this.btnLastSevenDays.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnLastSevenDays.ForeColor = System.Drawing.Color.White;
            this.btnLastSevenDays.Location = new System.Drawing.Point(1411, 28);
            this.btnLastSevenDays.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLastSevenDays.Name = "btnLastSevenDays";
            this.btnLastSevenDays.Size = new System.Drawing.Size(180, 36);
            this.btnLastSevenDays.TabIndex = 34;
            this.btnLastSevenDays.Text = "Last 7 Days";
            // 
            // btnThisMonth
            // 
            this.btnThisMonth.AutoRoundedCorners = true;
            this.btnThisMonth.BackColor = System.Drawing.Color.Transparent;
            this.btnThisMonth.BorderRadius = 17;
            this.btnThisMonth.CheckedState.FillColor = System.Drawing.Color.Wheat;
            this.btnThisMonth.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnThisMonth.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnThisMonth.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThisMonth.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThisMonth.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThisMonth.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThisMonth.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(93)))), ((int)(((byte)(71)))));
            this.btnThisMonth.FocusedColor = System.Drawing.Color.Wheat;
            this.btnThisMonth.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnThisMonth.ForeColor = System.Drawing.Color.White;
            this.btnThisMonth.Location = new System.Drawing.Point(1596, 28);
            this.btnThisMonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThisMonth.Name = "btnThisMonth";
            this.btnThisMonth.Size = new System.Drawing.Size(180, 36);
            this.btnThisMonth.TabIndex = 35;
            this.btnThisMonth.Text = "This Month";
            // 
            // btnDecember
            // 
            this.btnDecember.AutoRoundedCorners = true;
            this.btnDecember.BackColor = System.Drawing.Color.Transparent;
            this.btnDecember.BorderRadius = 17;
            this.btnDecember.CheckedState.FillColor = System.Drawing.Color.Wheat;
            this.btnDecember.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDecember.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDecember.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDecember.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDecember.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDecember.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDecember.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(93)))), ((int)(((byte)(71)))));
            this.btnDecember.FocusedColor = System.Drawing.Color.Wheat;
            this.btnDecember.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnDecember.ForeColor = System.Drawing.Color.White;
            this.btnDecember.Location = new System.Drawing.Point(1781, 28);
            this.btnDecember.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDecember.Name = "btnDecember";
            this.btnDecember.Size = new System.Drawing.Size(180, 36);
            this.btnDecember.TabIndex = 36;
            this.btnDecember.Text = "December";
            // 
            // MonthlySalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(177)))), ((int)(((byte)(159)))));
            this.ClientSize = new System.Drawing.Size(1942, 1088);
            this.Controls.Add(this.btnDecember);
            this.Controls.Add(this.btnThisMonth);
            this.Controls.Add(this.btnLastSevenDays);
            this.Controls.Add(this.btnToday);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.chartGuestDistribution);
            this.Controls.Add(this.chartPaymentsByDate);
            this.Controls.Add(this.chartDailyRevenue);
            this.Controls.Add(this.chartSeasonalRevenue);
            this.Controls.Add(this.chartSalesTrend);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MonthlySalesReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MonthlySalesReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSeasonalRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPaymentsByDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGuestDistribution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnPrintSummary;
        private System.Windows.Forms.PictureBox picBoxLogo;
        private System.Windows.Forms.Label lblWelcome;
        private Guna.UI2.WinForms.Guna2ImageButton btnExit;
        private Guna.UI2.WinForms.Guna2Button btnOkay;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalesTrend;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSeasonalRevenue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDailyRevenue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPaymentsByDate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGuestDistribution;
        private Guna.UI2.WinForms.Guna2Button btnPrint;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnToday;
        private Guna.UI2.WinForms.Guna2Button btnLastSevenDays;
        private Guna.UI2.WinForms.Guna2Button btnThisMonth;
        private Guna.UI2.WinForms.Guna2Button btnDecember;
    }
}