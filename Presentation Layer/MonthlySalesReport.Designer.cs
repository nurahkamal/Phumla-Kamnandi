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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrint = new Guna.UI2.WinForms.Guna2Button();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(153)))), ((int)(((byte)(127)))));
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.picBoxLogo);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 975);
            this.panel1.TabIndex = 2;
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
            this.btnPrint.Location = new System.Drawing.Point(65, 268);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(135, 29);
            this.btnPrint.TabIndex = 21;
            this.btnPrint.Text = "Print";
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
            // MonthlySalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(177)))), ((int)(((byte)(159)))));
            this.ClientSize = new System.Drawing.Size(1540, 845);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnPrint;
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
    }
}