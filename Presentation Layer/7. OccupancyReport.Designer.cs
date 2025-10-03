namespace Phumla_Kamnandi.Presentation_Layer
{
    partial class _7OccupancyReport
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblPhumla = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.btnReports = new Guna.UI2.WinForms.Guna2Button();
            this.btnGuestEnquiries = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdateAReservation = new Guna.UI2.WinForms.Guna2Button();
            this.btnMakeAReservation = new Guna.UI2.WinForms.Guna2Button();
            this.btnAboutUs = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.btnOkay = new Guna.UI2.WinForms.Guna2Button();
            this.chartRoomsBySeason = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnGenerateReport = new Guna.UI2.WinForms.Guna2Button();
            this.chartRoomOccupancyOverTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRoomsByDay = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDeposits = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDailyDeposits = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTotalDeposits = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRoomsBySeason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRoomOccupancyOverTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRoomsByDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDeposits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyDeposits)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.AutoRoundedCorners = true;
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.CustomFormat = "MMM dd, yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(586, 25);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 32);
            this.dtpEndDate.TabIndex = 1;
            this.dtpEndDate.Value = new System.DateTime(2025, 9, 24, 19, 34, 0, 243);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.AutoRoundedCorners = true;
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.CustomFormat = "MMM dd, yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(359, 25);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 32);
            this.dtpStartDate.TabIndex = 2;
            this.dtpStartDate.Value = new System.DateTime(2025, 9, 24, 19, 34, 0, 243);
            // 
            // lblPhumla
            // 
            this.lblPhumla.AutoSize = true;
            this.lblPhumla.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhumla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(65)))), ((int)(((byte)(57)))));
            this.lblPhumla.Location = new System.Drawing.Point(5, 153);
            this.lblPhumla.Name = "lblPhumla";
            this.lblPhumla.Size = new System.Drawing.Size(321, 28);
            this.lblPhumla.TabIndex = 3;
            this.lblPhumla.Text = "Phumla Kamnandi Hotel Group";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Location = new System.Drawing.Point(86, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(155, 127);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 4;
            this.pictureBoxLogo.TabStop = false;
            // 
            // leftPanel
            // 
            this.leftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(153)))), ((int)(((byte)(127)))));
            this.leftPanel.Controls.Add(this.btnReports);
            this.leftPanel.Controls.Add(this.btnGuestEnquiries);
            this.leftPanel.Controls.Add(this.btnUpdateAReservation);
            this.leftPanel.Controls.Add(this.btnMakeAReservation);
            this.leftPanel.Controls.Add(this.btnAboutUs);
            this.leftPanel.Controls.Add(this.btnExit);
            this.leftPanel.Controls.Add(this.pictureBoxLogo);
            this.leftPanel.Controls.Add(this.lblPhumla);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(329, 826);
            this.leftPanel.TabIndex = 5;
            // 
            // btnReports
            // 
            this.btnReports.AutoRoundedCorners = true;
            this.btnReports.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(65)))), ((int)(((byte)(57)))));
            this.btnReports.BorderThickness = 2;
            this.btnReports.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnReports.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnReports.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnReports.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnReports.FillColor = System.Drawing.Color.White;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(65)))), ((int)(((byte)(57)))));
            this.btnReports.Location = new System.Drawing.Point(37, 530);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(252, 47);
            this.btnReports.TabIndex = 25;
            this.btnReports.Text = "View Reports";
            // 
            // btnGuestEnquiries
            // 
            this.btnGuestEnquiries.AutoRoundedCorners = true;
            this.btnGuestEnquiries.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(65)))), ((int)(((byte)(57)))));
            this.btnGuestEnquiries.BorderThickness = 2;
            this.btnGuestEnquiries.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuestEnquiries.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuestEnquiries.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuestEnquiries.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuestEnquiries.FillColor = System.Drawing.Color.White;
            this.btnGuestEnquiries.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGuestEnquiries.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(65)))), ((int)(((byte)(57)))));
            this.btnGuestEnquiries.Location = new System.Drawing.Point(37, 446);
            this.btnGuestEnquiries.Name = "btnGuestEnquiries";
            this.btnGuestEnquiries.Size = new System.Drawing.Size(252, 47);
            this.btnGuestEnquiries.TabIndex = 24;
            this.btnGuestEnquiries.Text = "Guest Enquiries";
            // 
            // btnUpdateAReservation
            // 
            this.btnUpdateAReservation.AutoRoundedCorners = true;
            this.btnUpdateAReservation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(65)))), ((int)(((byte)(57)))));
            this.btnUpdateAReservation.BorderThickness = 2;
            this.btnUpdateAReservation.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdateAReservation.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdateAReservation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdateAReservation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdateAReservation.FillColor = System.Drawing.Color.White;
            this.btnUpdateAReservation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdateAReservation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(65)))), ((int)(((byte)(57)))));
            this.btnUpdateAReservation.Location = new System.Drawing.Point(37, 363);
            this.btnUpdateAReservation.Name = "btnUpdateAReservation";
            this.btnUpdateAReservation.Size = new System.Drawing.Size(252, 47);
            this.btnUpdateAReservation.TabIndex = 23;
            this.btnUpdateAReservation.Text = "Update a Reservation";
            // 
            // btnMakeAReservation
            // 
            this.btnMakeAReservation.AutoRoundedCorners = true;
            this.btnMakeAReservation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(65)))), ((int)(((byte)(57)))));
            this.btnMakeAReservation.BorderThickness = 2;
            this.btnMakeAReservation.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMakeAReservation.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMakeAReservation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMakeAReservation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMakeAReservation.FillColor = System.Drawing.Color.White;
            this.btnMakeAReservation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakeAReservation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(65)))), ((int)(((byte)(57)))));
            this.btnMakeAReservation.Location = new System.Drawing.Point(37, 283);
            this.btnMakeAReservation.Name = "btnMakeAReservation";
            this.btnMakeAReservation.Size = new System.Drawing.Size(252, 47);
            this.btnMakeAReservation.TabIndex = 22;
            this.btnMakeAReservation.Text = "Make a Reservation";
            // 
            // btnAboutUs
            // 
            this.btnAboutUs.AutoRoundedCorners = true;
            this.btnAboutUs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(65)))), ((int)(((byte)(57)))));
            this.btnAboutUs.BorderThickness = 2;
            this.btnAboutUs.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAboutUs.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAboutUs.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAboutUs.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAboutUs.FillColor = System.Drawing.Color.White;
            this.btnAboutUs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAboutUs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(65)))), ((int)(((byte)(57)))));
            this.btnAboutUs.Location = new System.Drawing.Point(37, 212);
            this.btnAboutUs.Name = "btnAboutUs";
            this.btnAboutUs.Size = new System.Drawing.Size(252, 47);
            this.btnAboutUs.TabIndex = 21;
            this.btnAboutUs.Text = "About Us";
            // 
            // btnExit
            // 
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(75, 619);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(180, 45);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOkay
            // 
            this.btnOkay.AutoRoundedCorners = true;
            this.btnOkay.DefaultAutoSize = true;
            this.btnOkay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOkay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOkay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOkay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOkay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnOkay.ForeColor = System.Drawing.Color.White;
            this.btnOkay.Location = new System.Drawing.Point(807, 26);
            this.btnOkay.Name = "btnOkay";
            this.btnOkay.Size = new System.Drawing.Size(51, 31);
            this.btnOkay.TabIndex = 6;
            this.btnOkay.Text = "OK";
            this.btnOkay.Click += new System.EventHandler(this.btnOkay_Click);
            // 
            // chartRoomsBySeason
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRoomsBySeason.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRoomsBySeason.Legends.Add(legend1);
            this.chartRoomsBySeason.Location = new System.Drawing.Point(383, 153);
            this.chartRoomsBySeason.Name = "chartRoomsBySeason";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Legend = "Legend1";
            series1.Name = "Guests";
            this.chartRoomsBySeason.Series.Add(series1);
            this.chartRoomsBySeason.Size = new System.Drawing.Size(507, 300);
            this.chartRoomsBySeason.TabIndex = 13;
            this.chartRoomsBySeason.Text = "chart1";
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerateReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerateReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenerateReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGenerateReport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(458, 82);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(180, 45);
            this.btnGenerateReport.TabIndex = 26;
            this.btnGenerateReport.Text = "Generate";
            // 
            // chartRoomOccupancyOverTime
            // 
            chartArea2.Name = "ChartArea1";
            this.chartRoomOccupancyOverTime.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartRoomOccupancyOverTime.Legends.Add(legend2);
            this.chartRoomOccupancyOverTime.Location = new System.Drawing.Point(1236, 153);
            this.chartRoomOccupancyOverTime.Name = "chartRoomOccupancyOverTime";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeColumn;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Occupancy";
            series2.YValuesPerPoint = 2;
            this.chartRoomOccupancyOverTime.Series.Add(series2);
            this.chartRoomOccupancyOverTime.Size = new System.Drawing.Size(757, 300);
            this.chartRoomOccupancyOverTime.TabIndex = 27;
            this.chartRoomOccupancyOverTime.Text = "chart1";
            // 
            // chartRoomsByDay
            // 
            chartArea3.Name = "ChartArea1";
            this.chartRoomsByDay.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartRoomsByDay.Legends.Add(legend3);
            this.chartRoomsByDay.Location = new System.Drawing.Point(383, 473);
            this.chartRoomsByDay.Name = "chartRoomsByDay";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "RoomsOccupied";
            this.chartRoomsByDay.Series.Add(series3);
            this.chartRoomsByDay.Size = new System.Drawing.Size(507, 300);
            this.chartRoomsByDay.TabIndex = 28;
            this.chartRoomsByDay.Text = "chart1";
            // 
            // chartDeposits
            // 
            chartArea4.Name = "ChartArea1";
            this.chartDeposits.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartDeposits.Legends.Add(legend4);
            this.chartDeposits.Location = new System.Drawing.Point(916, 153);
            this.chartDeposits.Name = "chartDeposits";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.Legend = "Legend1";
            series4.Name = "Deposits";
            this.chartDeposits.Series.Add(series4);
            this.chartDeposits.Size = new System.Drawing.Size(300, 300);
            this.chartDeposits.TabIndex = 29;
            this.chartDeposits.Text = "chart1";
            // 
            // chartDailyDeposits
            // 
            chartArea5.Name = "ChartArea1";
            this.chartDailyDeposits.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartDailyDeposits.Legends.Add(legend5);
            this.chartDailyDeposits.Location = new System.Drawing.Point(993, 494);
            this.chartDailyDeposits.Name = "chartDailyDeposits";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "DailyDeposits";
            this.chartDailyDeposits.Series.Add(series5);
            this.chartDailyDeposits.Size = new System.Drawing.Size(776, 343);
            this.chartDailyDeposits.TabIndex = 30;
            this.chartDailyDeposits.Text = "chart1";
            // 
            // lblTotalDeposits
            // 
            this.lblTotalDeposits.AutoSize = true;
            this.lblTotalDeposits.Location = new System.Drawing.Point(896, 101);
            this.lblTotalDeposits.Name = "lblTotalDeposits";
            this.lblTotalDeposits.Size = new System.Drawing.Size(44, 16);
            this.lblTotalDeposits.TabIndex = 31;
            this.lblTotalDeposits.Text = "label1";
            // 
            // _7OccupancyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(218)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(1826, 826);
            this.Controls.Add(this.lblTotalDeposits);
            this.Controls.Add(this.chartDailyDeposits);
            this.Controls.Add(this.chartDeposits);
            this.Controls.Add(this.chartRoomsByDay);
            this.Controls.Add(this.chartRoomOccupancyOverTime);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.chartRoomsBySeason);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "_7OccupancyReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this._7OccupancyReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRoomsBySeason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRoomOccupancyOverTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRoomsByDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDeposits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyDeposits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblPhumla;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel leftPanel;
        private Guna.UI2.WinForms.Guna2Button btnAboutUs;
        private Guna.UI2.WinForms.Guna2Button btnMakeAReservation;
        private Guna.UI2.WinForms.Guna2Button btnUpdateAReservation;
        private Guna.UI2.WinForms.Guna2Button btnGuestEnquiries;
        private Guna.UI2.WinForms.Guna2Button btnReports;
        private Guna.UI2.WinForms.Guna2Button btnOkay;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRoomsBySeason;
        private Guna.UI2.WinForms.Guna2Button btnGenerateReport;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRoomOccupancyOverTime;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRoomsByDay;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDeposits;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDailyDeposits;
        private System.Windows.Forms.Label lblTotalDeposits;
    }
}