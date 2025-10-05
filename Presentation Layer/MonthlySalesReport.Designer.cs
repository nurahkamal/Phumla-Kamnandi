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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title11 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title12 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend13 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title13 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend14 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title14 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title15 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrintSummary = new Guna.UI2.WinForms.Guna2Button();
            this.picBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnExit = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnOkay = new Guna.UI2.WinForms.Guna2Button();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnDecember = new Guna.UI2.WinForms.Guna2Button();
            this.btnThisMonth = new Guna.UI2.WinForms.Guna2Button();
            this.btnLastSevenDays = new Guna.UI2.WinForms.Guna2Button();
            this.btnToday = new Guna.UI2.WinForms.Guna2Button();
            this.chartSalesTrend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSeasonalRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDailyRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPaymentsByDate = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartGuestDistribution = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnPrint = new Guna.UI2.WinForms.Guna2Button();
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
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 975);
            this.panel1.TabIndex = 2;
            // 
            // btnPrintSummary
            // 
            this.btnPrintSummary.AutoRoundedCorners = true;
            this.btnPrintSummary.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrintSummary.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrintSummary.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrintSummary.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrintSummary.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrintSummary.ForeColor = System.Drawing.Color.White;
            this.btnPrintSummary.Location = new System.Drawing.Point(65, 268);
            this.btnPrintSummary.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintSummary.Name = "btnPrintSummary";
            this.btnPrintSummary.Size = new System.Drawing.Size(135, 29);
            this.btnPrintSummary.TabIndex = 21;
            this.btnPrintSummary.Text = "Print Summary";
            // 
            // picBoxLogo
            // 
            this.picBoxLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("picBoxLogo.Image")));
            this.picBoxLogo.Location = new System.Drawing.Point(76, 33);
            this.picBoxLogo.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxLogo.Name = "picBoxLogo";
            this.picBoxLogo.Size = new System.Drawing.Size(113, 116);
            this.picBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxLogo.TabIndex = 1;
            this.picBoxLogo.TabStop = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(65)))), ((int)(((byte)(57)))));
            this.lblWelcome.Location = new System.Drawing.Point(13, 166);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(239, 100);
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
            this.btnExit.Location = new System.Drawing.Point(1486, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.PressedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.btnExit.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnExit.Size = new System.Drawing.Size(42, 39);
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
            this.btnOkay.FillColor = System.Drawing.Color.Transparent;
            this.btnOkay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOkay.ForeColor = System.Drawing.Color.White;
            this.btnOkay.Location = new System.Drawing.Point(597, 23);
            this.btnOkay.Margin = new System.Windows.Forms.Padding(2);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(52, 29);
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
            this.dtpEndDate.Location = new System.Drawing.Point(443, 23);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpEndDate.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(150, 29);
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
            this.dtpStartDate.Location = new System.Drawing.Point(280, 23);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpStartDate.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(150, 29);
            this.dtpStartDate.TabIndex = 20;
            this.dtpStartDate.Value = new System.DateTime(2025, 12, 1, 0, 0, 0, 0);
            // 
            // btnDecember
            // 
            this.btnDecember.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(54)))));
            this.btnDecember.BorderRadius = 2;
            this.btnDecember.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(86)))), ((int)(((byte)(49)))));
            this.btnDecember.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDecember.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDecember.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDecember.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDecember.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDecember.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(86)))), ((int)(((byte)(49)))));
            this.btnDecember.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnDecember.ForeColor = System.Drawing.Color.White;
            this.btnDecember.Location = new System.Drawing.Point(1318, 23);
            this.btnDecember.Margin = new System.Windows.Forms.Padding(2);
            this.btnDecember.Name = "btnDecember";
            this.btnDecember.Size = new System.Drawing.Size(135, 29);
            this.btnDecember.TabIndex = 26;
            this.btnDecember.Text = "December 2025";
            // 
            // btnThisMonth
            // 
            this.btnThisMonth.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(54)))));
            this.btnThisMonth.BorderRadius = 2;
            this.btnThisMonth.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.btnThisMonth.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnThisMonth.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThisMonth.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThisMonth.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThisMonth.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThisMonth.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(86)))), ((int)(((byte)(49)))));
            this.btnThisMonth.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(238)))));
            this.btnThisMonth.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnThisMonth.ForeColor = System.Drawing.Color.White;
            this.btnThisMonth.Location = new System.Drawing.Point(1190, 23);
            this.btnThisMonth.Margin = new System.Windows.Forms.Padding(2);
            this.btnThisMonth.Name = "btnThisMonth";
            this.btnThisMonth.Size = new System.Drawing.Size(135, 29);
            this.btnThisMonth.TabIndex = 25;
            this.btnThisMonth.Text = "This Month";
            // 
            // btnLastSevenDays
            // 
            this.btnLastSevenDays.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(70)))), ((int)(((byte)(54)))));
            this.btnLastSevenDays.BorderRadius = 2;
            this.btnLastSevenDays.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(86)))), ((int)(((byte)(49)))));
            this.btnLastSevenDays.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLastSevenDays.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLastSevenDays.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLastSevenDays.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLastSevenDays.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLastSevenDays.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(86)))), ((int)(((byte)(49)))));
            this.btnLastSevenDays.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnLastSevenDays.ForeColor = System.Drawing.Color.White;
            this.btnLastSevenDays.Location = new System.Drawing.Point(1057, 23);
            this.btnLastSevenDays.Margin = new System.Windows.Forms.Padding(2);
            this.btnLastSevenDays.Name = "btnLastSevenDays";
            this.btnLastSevenDays.Size = new System.Drawing.Size(135, 29);
            this.btnLastSevenDays.TabIndex = 24;
            this.btnLastSevenDays.Text = "Last 7 Days";
            // 
            // btnToday
            // 
            this.btnToday.BackColor = System.Drawing.Color.Transparent;
            this.btnToday.BorderRadius = 3;
            this.btnToday.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(86)))), ((int)(((byte)(49)))));
            this.btnToday.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnToday.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnToday.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnToday.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnToday.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnToday.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(86)))), ((int)(((byte)(49)))));
            this.btnToday.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnToday.ForeColor = System.Drawing.Color.White;
            this.btnToday.Location = new System.Drawing.Point(923, 23);
            this.btnToday.Margin = new System.Windows.Forms.Padding(2);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(135, 29);
            this.btnToday.TabIndex = 23;
            this.btnToday.Text = "Today";
            // 
            // chartSalesTrend
            // 
            chartArea11.Name = "ChartArea1";
            this.chartSalesTrend.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.chartSalesTrend.Legends.Add(legend11);
            this.chartSalesTrend.Location = new System.Drawing.Point(280, 122);
            this.chartSalesTrend.Name = "chartSalesTrend";
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series11.Legend = "Legend1";
            series11.Name = "SalesTrend";
            this.chartSalesTrend.Series.Add(series11);
            this.chartSalesTrend.Size = new System.Drawing.Size(860, 207);
            this.chartSalesTrend.TabIndex = 27;
            this.chartSalesTrend.Text = "chart1";
            title11.Name = "Sales Trend Over Time";
            title11.Text = "Sales Trend Over Time";
            this.chartSalesTrend.Titles.Add(title11);
            // 
            // chartSeasonalRevenue
            // 
            chartArea12.Name = "ChartArea1";
            this.chartSeasonalRevenue.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this.chartSeasonalRevenue.Legends.Add(legend12);
            this.chartSeasonalRevenue.Location = new System.Drawing.Point(1159, 122);
            this.chartSeasonalRevenue.Name = "chartSeasonalRevenue";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series12.Legend = "Legend1";
            series12.Name = "SeasonalRevenue";
            this.chartSeasonalRevenue.Series.Add(series12);
            this.chartSeasonalRevenue.Size = new System.Drawing.Size(353, 464);
            this.chartSeasonalRevenue.TabIndex = 28;
            this.chartSeasonalRevenue.Text = "chart1";
            title12.Name = "Revenue by Season Period";
            title12.Text = "Revenue by Season Period";
            this.chartSeasonalRevenue.Titles.Add(title12);
            // 
            // chartDailyRevenue
            // 
            chartArea13.Name = "ChartArea1";
            this.chartDailyRevenue.ChartAreas.Add(chartArea13);
            legend13.Name = "Legend1";
            this.chartDailyRevenue.Legends.Add(legend13);
            this.chartDailyRevenue.Location = new System.Drawing.Point(695, 342);
            this.chartDailyRevenue.Name = "chartDailyRevenue";
            series13.ChartArea = "ChartArea1";
            series13.Legend = "Legend1";
            series13.Name = "DailyRevenue";
            this.chartDailyRevenue.Series.Add(series13);
            this.chartDailyRevenue.Size = new System.Drawing.Size(445, 244);
            this.chartDailyRevenue.TabIndex = 29;
            this.chartDailyRevenue.Text = "chart1";
            title13.Name = "Daily Revenue";
            title13.Text = "Daily Revenue";
            this.chartDailyRevenue.Titles.Add(title13);
            // 
            // chartPaymentsByDate
            // 
            chartArea14.Name = "ChartArea1";
            this.chartPaymentsByDate.ChartAreas.Add(chartArea14);
            legend14.Name = "Legend1";
            this.chartPaymentsByDate.Legends.Add(legend14);
            this.chartPaymentsByDate.Location = new System.Drawing.Point(280, 342);
            this.chartPaymentsByDate.Name = "chartPaymentsByDate";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series14.Legend = "Legend1";
            series14.Name = "BookingsCount";
            this.chartPaymentsByDate.Series.Add(series14);
            this.chartPaymentsByDate.Size = new System.Drawing.Size(407, 244);
            this.chartPaymentsByDate.TabIndex = 30;
            this.chartPaymentsByDate.Text = "chart1";
            title14.Name = "Payments by Date";
            title14.Text = "Payments by Date";
            this.chartPaymentsByDate.Titles.Add(title14);
            // 
            // chartGuestDistribution
            // 
            chartArea15.Name = "ChartArea1";
            this.chartGuestDistribution.ChartAreas.Add(chartArea15);
            legend15.Name = "Legend1";
            this.chartGuestDistribution.Legends.Add(legend15);
            this.chartGuestDistribution.Location = new System.Drawing.Point(280, 600);
            this.chartGuestDistribution.Name = "chartGuestDistribution";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series15.Legend = "Legend1";
            series15.Name = "PaymentsCount";
            this.chartGuestDistribution.Series.Add(series15);
            this.chartGuestDistribution.Size = new System.Drawing.Size(1232, 279);
            this.chartGuestDistribution.TabIndex = 31;
            this.chartGuestDistribution.Text = "chart1";
            title15.Name = "Guest Count Distribution";
            title15.Text = "Guest Count Distribution";
            this.chartGuestDistribution.Titles.Add(title15);
            // 
            // btnPrint
            // 
            this.btnPrint.AutoRoundedCorners = true;
            this.btnPrint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrint.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(65, 313);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(135, 29);
            this.btnPrint.TabIndex = 22;
            this.btnPrint.Text = "Print Report";
            // 
            // MonthlySalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(177)))), ((int)(((byte)(159)))));
            this.ClientSize = new System.Drawing.Size(1556, 884);
            this.Controls.Add(this.chartGuestDistribution);
            this.Controls.Add(this.chartPaymentsByDate);
            this.Controls.Add(this.chartDailyRevenue);
            this.Controls.Add(this.chartSeasonalRevenue);
            this.Controls.Add(this.chartSalesTrend);
            this.Controls.Add(this.btnDecember);
            this.Controls.Add(this.btnThisMonth);
            this.Controls.Add(this.btnLastSevenDays);
            this.Controls.Add(this.btnToday);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MonthlySalesReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSeasonalRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPaymentsByDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGuestDistribution)).EndInit();
            this.ResumeLayout(false);

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
        private Guna.UI2.WinForms.Guna2Button btnDecember;
        private Guna.UI2.WinForms.Guna2Button btnThisMonth;
        private Guna.UI2.WinForms.Guna2Button btnLastSevenDays;
        private Guna.UI2.WinForms.Guna2Button btnToday;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalesTrend;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSeasonalRevenue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDailyRevenue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPaymentsByDate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGuestDistribution;
        private Guna.UI2.WinForms.Guna2Button btnPrint;
    }
}