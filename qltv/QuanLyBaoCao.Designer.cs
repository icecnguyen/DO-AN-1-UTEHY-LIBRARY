namespace qltv
{
    partial class QuanLyBaoCao
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbReportType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpFromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnGenerate = new Guna.UI2.WinForms.Guna2Button();
            this.panelRight = new Guna.UI2.WinForms.Guna2Panel();
            this.btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            this.grpPrintDocument = new System.Windows.Forms.GroupBox();
            this.lblDocID = new System.Windows.Forms.Label();
            this.txtDocID = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnPrintBorrow = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrintFine = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrintImport = new Guna.UI2.WinForms.Guna2Button();
            this.dgvReports = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelTop.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.grpPrintDocument.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnGenerate);
            this.panelTop.Controls.Add(this.dtpToDate);
            this.panelTop.Controls.Add(this.dtpFromDate);
            this.panelTop.Controls.Add(this.cmbReportType);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 80);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(232, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO THỐNG KÊ";
            // 
            // cmbReportType
            // 
            this.cmbReportType.BackColor = System.Drawing.Color.Transparent;
            this.cmbReportType.BorderRadius = 5;
            this.cmbReportType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbReportType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbReportType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbReportType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbReportType.ItemHeight = 30;
            this.cmbReportType.Location = new System.Drawing.Point(270, 22);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(260, 36);
            this.cmbReportType.TabIndex = 1;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.BorderRadius = 5;
            this.dtpFromDate.Checked = true;
            this.dtpFromDate.FillColor = System.Drawing.Color.White;
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(545, 22);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(125, 36);
            this.dtpFromDate.TabIndex = 2;
            this.dtpFromDate.Value = new System.DateTime(2026, 1, 1, 0, 0, 0, 0);
            // 
            // dtpToDate
            // 
            this.dtpToDate.BorderRadius = 5;
            this.dtpToDate.Checked = true;
            this.dtpToDate.FillColor = System.Drawing.Color.White;
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(680, 22);
            this.dtpToDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(125, 36);
            this.dtpToDate.TabIndex = 3;
            this.dtpToDate.Value = new System.DateTime(2026, 12, 31, 0, 0, 0, 0);
            // 
            // btnGenerate
            // 
            this.btnGenerate.BorderRadius = 10;
            this.btnGenerate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(820, 22);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(115, 36);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Thống Kê";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelRight.Controls.Add(this.grpPrintDocument);
            this.panelRight.Controls.Add(this.btnExportExcel);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(740, 80);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(260, 520);
            this.panelRight.TabIndex = 2;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BorderRadius = 10;
            this.btnExportExcel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(20, 20);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(220, 45);
            this.btnExportExcel.TabIndex = 0;
            this.btnExportExcel.Text = "Xuất file Excel";
            // 
            // grpPrintDocument
            // 
            this.grpPrintDocument.Controls.Add(this.btnPrintImport);
            this.grpPrintDocument.Controls.Add(this.btnPrintFine);
            this.grpPrintDocument.Controls.Add(this.btnPrintBorrow);
            this.grpPrintDocument.Controls.Add(this.txtDocID);
            this.grpPrintDocument.Controls.Add(this.lblDocID);
            this.grpPrintDocument.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPrintDocument.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.grpPrintDocument.Location = new System.Drawing.Point(20, 95);
            this.grpPrintDocument.Name = "grpPrintDocument";
            this.grpPrintDocument.Size = new System.Drawing.Size(220, 330);
            this.grpPrintDocument.TabIndex = 1;
            this.grpPrintDocument.TabStop = false;
            this.grpPrintDocument.Text = "Xuất Chứng Từ";
            // 
            // lblDocID
            // 
            this.lblDocID.AutoSize = true;
            this.lblDocID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocID.Location = new System.Drawing.Point(15, 30);
            this.lblDocID.Name = "lblDocID";
            this.lblDocID.Size = new System.Drawing.Size(95, 15);
            this.lblDocID.TabIndex = 0;
            this.lblDocID.Text = "Mã Phiếu/Biên lai:";
            // 
            // txtDocID
            // 
            this.txtDocID.BorderRadius = 5;
            this.txtDocID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDocID.DefaultText = "";
            this.txtDocID.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocID.Location = new System.Drawing.Point(15, 52);
            this.txtDocID.Name = "txtDocID";
            this.txtDocID.PasswordChar = '\0';
            this.txtDocID.PlaceholderText = "Nhập mã phiếu...";
            this.txtDocID.SelectedText = "";
            this.txtDocID.Size = new System.Drawing.Size(190, 36);
            this.txtDocID.TabIndex = 1;
            // 
            // btnPrintBorrow
            // 
            this.btnPrintBorrow.BorderRadius = 5;
            this.btnPrintBorrow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnPrintBorrow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBorrow.ForeColor = System.Drawing.Color.White;
            this.btnPrintBorrow.Location = new System.Drawing.Point(15, 110);
            this.btnPrintBorrow.Name = "btnPrintBorrow";
            this.btnPrintBorrow.Size = new System.Drawing.Size(190, 38);
            this.btnPrintBorrow.TabIndex = 2;
            this.btnPrintBorrow.Text = "In Phiếu Mượn Sách";
            // 
            // btnPrintFine
            // 
            this.btnPrintFine.BorderRadius = 5;
            this.btnPrintFine.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnPrintFine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintFine.ForeColor = System.Drawing.Color.White;
            this.btnPrintFine.Location = new System.Drawing.Point(15, 165);
            this.btnPrintFine.Name = "btnPrintFine";
            this.btnPrintFine.Size = new System.Drawing.Size(190, 38);
            this.btnPrintFine.TabIndex = 3;
            this.btnPrintFine.Text = "In Biên Lai Phạt Tiền";
            // 
            // btnPrintImport
            // 
            this.btnPrintImport.BorderRadius = 5;
            this.btnPrintImport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnPrintImport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintImport.ForeColor = System.Drawing.Color.White;
            this.btnPrintImport.Location = new System.Drawing.Point(15, 220);
            this.btnPrintImport.Name = "btnPrintImport";
            this.btnPrintImport.Size = new System.Drawing.Size(190, 38);
            this.btnPrintImport.TabIndex = 4;
            this.btnPrintImport.Text = "In Phiếu Nhập Kho";
            // 
            // dgvReports
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvReports.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReports.BackgroundColor = System.Drawing.Color.White;
            this.dgvReports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReports.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReports.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReports.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReports.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReports.EnableHeadersVisualStyles = false;
            this.dgvReports.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReports.Location = new System.Drawing.Point(0, 80);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.RowHeadersVisible = false;
            this.dgvReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReports.Size = new System.Drawing.Size(740, 520);
            this.dgvReports.TabIndex = 1;
            // 
            // QuanLyBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvReports);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelTop);
            this.Name = "QuanLyBaoCao";
            this.Size = new System.Drawing.Size(1000, 600);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.grpPrintDocument.ResumeLayout(false);
            this.grpPrintDocument.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ComboBox cmbReportType;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFromDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpToDate;
        private Guna.UI2.WinForms.Guna2Button btnGenerate;
        private Guna.UI2.WinForms.Guna2Panel panelRight;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
        private System.Windows.Forms.GroupBox grpPrintDocument;
        private System.Windows.Forms.Label lblDocID;
        private Guna.UI2.WinForms.Guna2TextBox txtDocID;
        private Guna.UI2.WinForms.Guna2Button btnPrintBorrow;
        private Guna.UI2.WinForms.Guna2Button btnPrintFine;
        private Guna.UI2.WinForms.Guna2Button btnPrintImport;
        private Guna.UI2.WinForms.Guna2DataGridView dgvReports;
    }
}
