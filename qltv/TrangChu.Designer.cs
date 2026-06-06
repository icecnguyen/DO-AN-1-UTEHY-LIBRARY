namespace qltv
{
    partial class TrangChu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnReports = new Guna.UI2.WinForms.Guna2Button();
            this.btnBookImport = new Guna.UI2.WinForms.Guna2Button();
            this.btnBorrowReturn = new Guna.UI2.WinForms.Guna2Button();
            this.btnSuppliers = new Guna.UI2.WinForms.Guna2Button();
            this.btnCategories = new Guna.UI2.WinForms.Guna2Button();
            this.btnEmployees = new Guna.UI2.WinForms.Guna2Button();
            this.btnReaders = new Guna.UI2.WinForms.Guna2Button();
            this.btnBooks = new Guna.UI2.WinForms.Guna2Button();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelMain = new Guna.UI2.WinForms.Guna2Panel();
            this.panelSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.btnBookImport);
            this.panelSidebar.Controls.Add(this.btnBorrowReturn);
            this.panelSidebar.Controls.Add(this.btnSuppliers);
            this.panelSidebar.Controls.Add(this.btnCategories);
            this.panelSidebar.Controls.Add(this.btnEmployees);
            this.panelSidebar.Controls.Add(this.btnReaders);
            this.panelSidebar.Controls.Add(this.btnBooks);
            this.panelSidebar.Controls.Add(this.lblLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 700);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnReports
            // 
            this.btnReports.BorderRadius = 5;
            this.btnReports.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnReports.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(107)))), ((int)(((byte)(192)))));
            this.btnReports.FillColor = System.Drawing.Color.Transparent;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(10, 480);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(200, 45);
            this.btnReports.TabIndex = 8;
            this.btnReports.Text = "Báo Cáo - Thống Kê";
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnBookImport
            // 
            this.btnBookImport.BorderRadius = 5;
            this.btnBookImport.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnBookImport.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(107)))), ((int)(((byte)(192)))));
            this.btnBookImport.FillColor = System.Drawing.Color.Transparent;
            this.btnBookImport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBookImport.ForeColor = System.Drawing.Color.White;
            this.btnBookImport.Location = new System.Drawing.Point(10, 430);
            this.btnBookImport.Name = "btnBookImport";
            this.btnBookImport.Size = new System.Drawing.Size(200, 45);
            this.btnBookImport.TabIndex = 7;
            this.btnBookImport.Text = "Quản Lý Nhập Sách";
            this.btnBookImport.Click += new System.EventHandler(this.btnBookImport_Click);
            // 
            // btnBorrowReturn
            // 
            this.btnBorrowReturn.BorderRadius = 5;
            this.btnBorrowReturn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnBorrowReturn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(107)))), ((int)(((byte)(192)))));
            this.btnBorrowReturn.FillColor = System.Drawing.Color.Transparent;
            this.btnBorrowReturn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBorrowReturn.ForeColor = System.Drawing.Color.White;
            this.btnBorrowReturn.Location = new System.Drawing.Point(10, 380);
            this.btnBorrowReturn.Name = "btnBorrowReturn";
            this.btnBorrowReturn.Size = new System.Drawing.Size(200, 45);
            this.btnBorrowReturn.TabIndex = 6;
            this.btnBorrowReturn.Text = "Quản Lý Mượn - Trả Sách";
            this.btnBorrowReturn.Click += new System.EventHandler(this.btnBorrowReturn_Click);
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.BorderRadius = 5;
            this.btnSuppliers.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSuppliers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(107)))), ((int)(((byte)(192)))));
            this.btnSuppliers.FillColor = System.Drawing.Color.Transparent;
            this.btnSuppliers.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSuppliers.ForeColor = System.Drawing.Color.White;
            this.btnSuppliers.Location = new System.Drawing.Point(10, 330);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(200, 45);
            this.btnSuppliers.TabIndex = 5;
            this.btnSuppliers.Text = "Quản Lý Nhà Cung Cấp";
            this.btnSuppliers.Click += new System.EventHandler(this.btnSuppliers_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.BorderRadius = 5;
            this.btnCategories.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnCategories.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(107)))), ((int)(((byte)(192)))));
            this.btnCategories.FillColor = System.Drawing.Color.Transparent;
            this.btnCategories.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCategories.ForeColor = System.Drawing.Color.White;
            this.btnCategories.Location = new System.Drawing.Point(10, 280);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(200, 45);
            this.btnCategories.TabIndex = 4;
            this.btnCategories.Text = "Quản Lý Danh Mục";
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.BorderRadius = 5;
            this.btnEmployees.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnEmployees.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(107)))), ((int)(((byte)(192)))));
            this.btnEmployees.FillColor = System.Drawing.Color.Transparent;
            this.btnEmployees.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEmployees.ForeColor = System.Drawing.Color.White;
            this.btnEmployees.Location = new System.Drawing.Point(10, 230);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(200, 45);
            this.btnEmployees.TabIndex = 3;
            this.btnEmployees.Text = "Quản Lý Nhân Viên";
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnReaders
            // 
            this.btnReaders.BorderRadius = 5;
            this.btnReaders.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnReaders.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(107)))), ((int)(((byte)(192)))));
            this.btnReaders.FillColor = System.Drawing.Color.Transparent;
            this.btnReaders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReaders.ForeColor = System.Drawing.Color.White;
            this.btnReaders.Location = new System.Drawing.Point(10, 180);
            this.btnReaders.Name = "btnReaders";
            this.btnReaders.Size = new System.Drawing.Size(200, 45);
            this.btnReaders.TabIndex = 2;
            this.btnReaders.Text = "Quản Lý Độc Giả";
            this.btnReaders.Click += new System.EventHandler(this.btnReaders_Click);
            // 
            // btnBooks
            // 
            this.btnBooks.BorderRadius = 5;
            this.btnBooks.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnBooks.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(107)))), ((int)(((byte)(192)))));
            this.btnBooks.FillColor = System.Drawing.Color.Transparent;
            this.btnBooks.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBooks.ForeColor = System.Drawing.Color.White;
            this.btnBooks.Location = new System.Drawing.Point(10, 130);
            this.btnBooks.Name = "btnBooks";
            this.btnBooks.Size = new System.Drawing.Size(200, 45);
            this.btnBooks.TabIndex = 1;
            this.btnBooks.Text = "Quản Lý Sách";
            this.btnBooks.Click += new System.EventHandler(this.btnBooks_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(20, 30);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(181, 30);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "UTEHY LIBRARY";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(220, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1080, 700);
            this.panelMain.TabIndex = 1;
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.Name = "TrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Thư viện UTEHY";
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelSidebar;
        private Guna.UI2.WinForms.Guna2Button btnBooks;
        private System.Windows.Forms.Label lblLogo;
        private Guna.UI2.WinForms.Guna2Button btnReports;
        private Guna.UI2.WinForms.Guna2Button btnBookImport;
        private Guna.UI2.WinForms.Guna2Button btnBorrowReturn;
        private Guna.UI2.WinForms.Guna2Button btnSuppliers;
        private Guna.UI2.WinForms.Guna2Button btnCategories;
        private Guna.UI2.WinForms.Guna2Button btnEmployees;
        private Guna.UI2.WinForms.Guna2Button btnReaders;
        private Guna.UI2.WinForms.Guna2Panel panelMain;
    }
}
