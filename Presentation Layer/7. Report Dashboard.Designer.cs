namespace Phumla_Kamnandi.Presentation_Layer
{
    partial class Report_Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report_Dashboard));
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
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblPhumla = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.btnAboutUs = new Guna.UI2.WinForms.Guna2Button();
            this.btnMakeAReservation = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdateAReservation = new Guna.UI2.WinForms.Guna2Button();
            this.btnGuestEnquiries = new Guna.UI2.WinForms.Guna2Button();
            this.btnReports = new Guna.UI2.WinForms.Guna2Button();
            this.btnOkay = new Guna.UI2.WinForms.Guna2Button();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.btnLastMonth = new Guna.UI2.WinForms.Guna2Button();
            this.btnLast30Days = new Guna.UI2.WinForms.Guna2Button();
            this.btnLast7days = new Guna.UI2.WinForms.Guna2Button();
            this.btnToday = new Guna.UI2.WinForms.Guna2Button();
            this.btnCustom = new Guna.UI2.WinForms.Guna2Button();
            this.panelResevations = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNumberOfReservations = new System.Windows.Forms.Label();
            this.lblnumberofres = new System.Windows.Forms.Label();
            this.panelRevenue = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRvenue = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.panelProfit = new Guna.UI2.WinForms.Guna2Panel();
            this.lblProfit = new System.Windows.Forms.Label();
            this.lblTotalProfit = new System.Windows.Forms.Label();
            this.chartRevenueByDate = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRevenueBySeason = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartCumulativeRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.leftPanel.SuspendLayout();
            this.panelResevations.SuspendLayout();
            this.panelRevenue.SuspendLayout();
            this.panelProfit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueByDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueBySeason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCumulativeRevenue)).BeginInit();
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
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
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
            // btnLastMonth
            // 
            this.btnLastMonth.AutoRoundedCorners = true;
            this.btnLastMonth.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLastMonth.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLastMonth.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLastMonth.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLastMonth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLastMonth.ForeColor = System.Drawing.Color.White;
            this.btnLastMonth.Location = new System.Drawing.Point(1632, 26);
            this.btnLastMonth.Name = "btnLastMonth";
            this.btnLastMonth.Size = new System.Drawing.Size(180, 31);
            this.btnLastMonth.TabIndex = 8;
            this.btnLastMonth.Text = "Last Month";
            // 
            // btnLast30Days
            // 
            this.btnLast30Days.AutoRoundedCorners = true;
            this.btnLast30Days.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLast30Days.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLast30Days.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLast30Days.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLast30Days.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLast30Days.ForeColor = System.Drawing.Color.White;
            this.btnLast30Days.Location = new System.Drawing.Point(1446, 25);
            this.btnLast30Days.Name = "btnLast30Days";
            this.btnLast30Days.Size = new System.Drawing.Size(180, 33);
            this.btnLast30Days.TabIndex = 9;
            this.btnLast30Days.Text = "Last 30 Days";
            // 
            // btnLast7days
            // 
            this.btnLast7days.AutoRoundedCorners = true;
            this.btnLast7days.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLast7days.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLast7days.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLast7days.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLast7days.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLast7days.ForeColor = System.Drawing.Color.White;
            this.btnLast7days.Location = new System.Drawing.Point(1260, 26);
            this.btnLast7days.Name = "btnLast7days";
            this.btnLast7days.Size = new System.Drawing.Size(180, 32);
            this.btnLast7days.TabIndex = 10;
            this.btnLast7days.Text = "Last 7 Days";
            // 
            // btnToday
            // 
            this.btnToday.AutoRoundedCorners = true;
            this.btnToday.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnToday.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnToday.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnToday.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnToday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnToday.ForeColor = System.Drawing.Color.White;
            this.btnToday.Location = new System.Drawing.Point(1074, 26);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(180, 32);
            this.btnToday.TabIndex = 11;
            this.btnToday.Text = "Today";
            // 
            // btnCustom
            // 
            this.btnCustom.AutoRoundedCorners = true;
            this.btnCustom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCustom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCustom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCustom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCustom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCustom.ForeColor = System.Drawing.Color.White;
            this.btnCustom.Location = new System.Drawing.Point(888, 26);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(180, 31);
            this.btnCustom.TabIndex = 12;
            this.btnCustom.Text = "Custom";
            // 
            // panelResevations
            // 
            this.panelResevations.BackColor = System.Drawing.Color.White;
            this.panelResevations.Controls.Add(this.lblnumberofres);
            this.panelResevations.Controls.Add(this.lblNumberOfReservations);
            this.panelResevations.Location = new System.Drawing.Point(359, 76);
            this.panelResevations.Name = "panelResevations";
            this.panelResevations.Size = new System.Drawing.Size(257, 81);
            this.panelResevations.TabIndex = 13;
            // 
            // lblNumberOfReservations
            // 
            this.lblNumberOfReservations.AutoSize = true;
            this.lblNumberOfReservations.Location = new System.Drawing.Point(26, 10);
            this.lblNumberOfReservations.Name = "lblNumberOfReservations";
            this.lblNumberOfReservations.Size = new System.Drawing.Size(152, 16);
            this.lblNumberOfReservations.TabIndex = 0;
            this.lblNumberOfReservations.Text = "Number of Reservations";
            // 
            // lblnumberofres
            // 
            this.lblnumberofres.AutoSize = true;
            this.lblnumberofres.Location = new System.Drawing.Point(87, 41);
            this.lblnumberofres.Name = "lblnumberofres";
            this.lblnumberofres.Size = new System.Drawing.Size(21, 16);
            this.lblnumberofres.TabIndex = 1;
            this.lblnumberofres.Text = "10\r\n";
            // 
            // panelRevenue
            // 
            this.panelRevenue.BackColor = System.Drawing.Color.White;
            this.panelRevenue.Controls.Add(this.lblRvenue);
            this.panelRevenue.Controls.Add(this.lblTotalRevenue);
            this.panelRevenue.Location = new System.Drawing.Point(633, 76);
            this.panelRevenue.Name = "panelRevenue";
            this.panelRevenue.Size = new System.Drawing.Size(328, 81);
            this.panelRevenue.TabIndex = 14;
            // 
            // lblRvenue
            // 
            this.lblRvenue.AutoSize = true;
            this.lblRvenue.Location = new System.Drawing.Point(109, 41);
            this.lblRvenue.Name = "lblRvenue";
            this.lblRvenue.Size = new System.Drawing.Size(21, 16);
            this.lblRvenue.TabIndex = 1;
            this.lblRvenue.Text = "10\r\n";
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Location = new System.Drawing.Point(62, 10);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(93, 16);
            this.lblTotalRevenue.TabIndex = 0;
            this.lblTotalRevenue.Text = "Tota Revenue";
            // 
            // panelProfit
            // 
            this.panelProfit.BackColor = System.Drawing.Color.White;
            this.panelProfit.Controls.Add(this.lblProfit);
            this.panelProfit.Controls.Add(this.lblTotalProfit);
            this.panelProfit.Location = new System.Drawing.Point(981, 76);
            this.panelProfit.Name = "panelProfit";
            this.panelProfit.Size = new System.Drawing.Size(831, 81);
            this.panelProfit.TabIndex = 15;
            // 
            // lblProfit
            // 
            this.lblProfit.AutoSize = true;
            this.lblProfit.Location = new System.Drawing.Point(109, 41);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(21, 16);
            this.lblProfit.TabIndex = 1;
            this.lblProfit.Text = "10\r\n";
            // 
            // lblTotalProfit
            // 
            this.lblTotalProfit.AutoSize = true;
            this.lblTotalProfit.Location = new System.Drawing.Point(62, 10);
            this.lblTotalProfit.Name = "lblTotalProfit";
            this.lblTotalProfit.Size = new System.Drawing.Size(71, 16);
            this.lblTotalProfit.TabIndex = 0;
            this.lblTotalProfit.Text = "Total Profit";
            // 
            // chartRevenueByDate
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRevenueByDate.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chartRevenueByDate.Legends.Add(legend1);
            this.chartRevenueByDate.Location = new System.Drawing.Point(359, 174);
            this.chartRevenueByDate.Name = "chartRevenueByDate";
            this.chartRevenueByDate.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            this.chartRevenueByDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartRevenueByDate.Series.Add(series1);
            this.chartRevenueByDate.Size = new System.Drawing.Size(881, 303);
            this.chartRevenueByDate.TabIndex = 16;
            this.chartRevenueByDate.Text = "Gross Revenue";
            title1.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Gross Revenue";
            title1.Text = "Gross Revenue";
            this.chartRevenueByDate.Titles.Add(title1);
            // 
            // chartRevenueBySeason
            // 
            chartArea2.Name = "ChartArea1";
            this.chartRevenueBySeason.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Name = "Legend1";
            this.chartRevenueBySeason.Legends.Add(legend2);
            this.chartRevenueBySeason.Location = new System.Drawing.Point(1260, 174);
            this.chartRevenueBySeason.Name = "chartRevenueBySeason";
            this.chartRevenueBySeason.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            this.chartRevenueBySeason.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.LabelForeColor = System.Drawing.Color.White;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartRevenueBySeason.Series.Add(series2);
            this.chartRevenueBySeason.Size = new System.Drawing.Size(552, 640);
            this.chartRevenueBySeason.TabIndex = 17;
            this.chartRevenueBySeason.Text = "Gross Revenue";
            title2.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Revenue By Season";
            title2.Text = "Revenue By Season";
            this.chartRevenueBySeason.Titles.Add(title2);
            // 
            // chartCumulativeRevenue
            // 
            chartArea3.Name = "ChartArea1";
            this.chartCumulativeRevenue.ChartAreas.Add(chartArea3);
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend3.Name = "Legend1";
            this.chartCumulativeRevenue.Legends.Add(legend3);
            this.chartCumulativeRevenue.Location = new System.Drawing.Point(359, 490);
            this.chartCumulativeRevenue.Name = "chartCumulativeRevenue";
            this.chartCumulativeRevenue.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Chocolate;
            this.chartCumulativeRevenue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartCumulativeRevenue.Series.Add(series3);
            this.chartCumulativeRevenue.Size = new System.Drawing.Size(881, 324);
            this.chartCumulativeRevenue.TabIndex = 18;
            this.chartCumulativeRevenue.Text = "Revenue";
            title3.Alignment = System.Drawing.ContentAlignment.TopLeft;
            title3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title3.Name = "Revenue";
            title3.Text = "Revenue by Room";
            this.chartCumulativeRevenue.Titles.Add(title3);
            // 
            // Report_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(218)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(1826, 826);
            this.Controls.Add(this.chartCumulativeRevenue);
            this.Controls.Add(this.chartRevenueBySeason);
            this.Controls.Add(this.chartRevenueByDate);
            this.Controls.Add(this.panelProfit);
            this.Controls.Add(this.panelRevenue);
            this.Controls.Add(this.panelResevations);
            this.Controls.Add(this.btnCustom);
            this.Controls.Add(this.btnToday);
            this.Controls.Add(this.btnLast7days);
            this.Controls.Add(this.btnLast30Days);
            this.Controls.Add(this.btnLastMonth);
            this.Controls.Add(this.btnOkay);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Report_Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.panelResevations.ResumeLayout(false);
            this.panelResevations.PerformLayout();
            this.panelRevenue.ResumeLayout(false);
            this.panelRevenue.PerformLayout();
            this.panelProfit.ResumeLayout(false);
            this.panelProfit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueByDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueBySeason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCumulativeRevenue)).EndInit();
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
        private Guna.UI2.WinForms.Guna2Button btnLastMonth;
        private Guna.UI2.WinForms.Guna2Button btnLast30Days;
        private Guna.UI2.WinForms.Guna2Button btnLast7days;
        private Guna.UI2.WinForms.Guna2Button btnToday;
        private Guna.UI2.WinForms.Guna2Button btnCustom;
        private Guna.UI2.WinForms.Guna2Panel panelResevations;
        private System.Windows.Forms.Label lblnumberofres;
        private System.Windows.Forms.Label lblNumberOfReservations;
        private Guna.UI2.WinForms.Guna2Panel panelRevenue;
        private System.Windows.Forms.Label lblRvenue;
        private System.Windows.Forms.Label lblTotalRevenue;
        private Guna.UI2.WinForms.Guna2Panel panelProfit;
        private System.Windows.Forms.Label lblProfit;
        private System.Windows.Forms.Label lblTotalProfit;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenueByDate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenueBySeason;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCumulativeRevenue;
    }
}