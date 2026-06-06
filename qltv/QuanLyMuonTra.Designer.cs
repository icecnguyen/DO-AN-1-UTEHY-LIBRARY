namespace qltv
{
    partial class QuanLyMuonTra
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
            this.btnReturn = new Guna.UI2.WinForms.Guna2Button();
            this.btnBorrow = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvLoans = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelInputs = new Guna.UI2.WinForms.Guna2Panel();
            this.dtpReturnDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpBorrowDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtReaderID = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBookID = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLoanID = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnPrintBorrow = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrintFine = new Guna.UI2.WinForms.Guna2Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).BeginInit();
            this.panelInputs.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnReturn);
            this.panelTop.Controls.Add(this.btnBorrow);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 80);
            this.panelTop.TabIndex = 0;
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.BorderRadius = 10;
            this.btnReturn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnReturn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(880, 20);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(100, 40);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "Trả sách";
            // 
            // btnBorrow
            // 
            this.btnBorrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrow.BorderRadius = 10;
            this.btnBorrow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnBorrow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBorrow.ForeColor = System.Drawing.Color.White;
            this.btnBorrow.Location = new System.Drawing.Point(770, 20);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(100, 40);
            this.btnBorrow.TabIndex = 1;
            this.btnBorrow.Text = "Mượn sách";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 15;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Location = new System.Drawing.Point(20, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Tìm kiếm phiếu mượn...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(300, 40);
            this.txtSearch.TabIndex = 0;
            // 
            // dgvLoans
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvLoans.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoans.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoans.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLoans.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLoans.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLoans.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLoans.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLoans.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLoans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoans.EnableHeadersVisualStyles = false;
            this.dgvLoans.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLoans.Location = new System.Drawing.Point(0, 80);
            this.dgvLoans.Name = "dgvLoans";
            this.dgvLoans.RowHeadersVisible = false;
            this.dgvLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoans.Size = new System.Drawing.Size(700, 520);
            this.dgvLoans.TabIndex = 1;
            // 
            // panelInputs
            // 
            this.panelInputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelInputs.Controls.Add(this.btnPrintFine);
            this.panelInputs.Controls.Add(this.btnPrintBorrow);
            this.panelInputs.Controls.Add(this.lblTitle);
            this.panelInputs.Controls.Add(this.dtpReturnDate);
            this.panelInputs.Controls.Add(this.dtpBorrowDate);
            this.panelInputs.Controls.Add(this.txtReaderID);
            this.panelInputs.Controls.Add(this.txtBookID);
            this.panelInputs.Controls.Add(this.txtLoanID);
            this.panelInputs.Controls.Add(this.btnSave);
            this.panelInputs.Controls.Add(this.btnCancel);
            this.panelInputs.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInputs.Location = new System.Drawing.Point(700, 80);
            this.panelInputs.Name = "panelInputs";
            this.panelInputs.Size = new System.Drawing.Size(300, 520);
            this.panelInputs.TabIndex = 2;
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.BorderRadius = 5;
            this.dtpReturnDate.Checked = true;
            this.dtpReturnDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.dtpReturnDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpReturnDate.ForeColor = System.Drawing.Color.White;
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReturnDate.Location = new System.Drawing.Point(20, 280);
            this.dtpReturnDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpReturnDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(260, 36);
            this.dtpReturnDate.TabIndex = 5;
            this.dtpReturnDate.Value = new System.DateTime(2026, 5, 11, 21, 56, 11, 0);
            // 
            // dtpBorrowDate
            // 
            this.dtpBorrowDate.BorderRadius = 5;
            this.dtpBorrowDate.Checked = true;
            this.dtpBorrowDate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.dtpBorrowDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpBorrowDate.ForeColor = System.Drawing.Color.White;
            this.dtpBorrowDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBorrowDate.Location = new System.Drawing.Point(20, 230);
            this.dtpBorrowDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpBorrowDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBorrowDate.Name = "dtpBorrowDate";
            this.dtpBorrowDate.Size = new System.Drawing.Size(260, 36);
            this.dtpBorrowDate.TabIndex = 4;
            this.dtpBorrowDate.Value = new System.DateTime(2026, 5, 11, 21, 56, 11, 0);
            // 
            // txtReaderID
            // 
            this.txtReaderID.BorderRadius = 5;
            this.txtReaderID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReaderID.DefaultText = "";
            this.txtReaderID.Location = new System.Drawing.Point(20, 180);
            this.txtReaderID.Name = "txtReaderID";
            this.txtReaderID.PasswordChar = '\0';
            this.txtReaderID.PlaceholderText = "Mã độc giả";
            this.txtReaderID.SelectedText = "";
            this.txtReaderID.Size = new System.Drawing.Size(260, 36);
            this.txtReaderID.TabIndex = 3;
            // 
            // txtBookID
            // 
            this.txtBookID.BorderRadius = 5;
            this.txtBookID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBookID.DefaultText = "";
            this.txtBookID.Location = new System.Drawing.Point(20, 130);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.PasswordChar = '\0';
            this.txtBookID.PlaceholderText = "Mã sách";
            this.txtBookID.SelectedText = "";
            this.txtBookID.Size = new System.Drawing.Size(260, 36);
            this.txtBookID.TabIndex = 2;
            // 
            // txtLoanID
            // 
            this.txtLoanID.BorderRadius = 5;
            this.txtLoanID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLoanID.DefaultText = "";
            this.txtLoanID.Location = new System.Drawing.Point(20, 80);
            this.txtLoanID.Name = "txtLoanID";
            this.txtLoanID.PasswordChar = '\0';
            this.txtLoanID.PlaceholderText = "Mã phiếu mượn";
            this.txtLoanID.SelectedText = "";
            this.txtLoanID.Size = new System.Drawing.Size(260, 36);
            this.txtLoanID.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 10;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(160, 340);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 45);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu phiếu";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(20, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(199, 21);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "THÔNG TIN MƯỢN TRẢ";
            // 
            // btnPrintBorrow
            // 
            this.btnPrintBorrow.BorderRadius = 10;
            this.btnPrintBorrow.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnPrintBorrow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrintBorrow.ForeColor = System.Drawing.Color.White;
            this.btnPrintBorrow.Location = new System.Drawing.Point(20, 405);
            this.btnPrintBorrow.Name = "btnPrintBorrow";
            this.btnPrintBorrow.Size = new System.Drawing.Size(120, 45);
            this.btnPrintBorrow.TabIndex = 9;
            this.btnPrintBorrow.Text = "In Phiếu Mượn";
            // 
            // btnPrintFine
            // 
            this.btnPrintFine.BorderRadius = 10;
            this.btnPrintFine.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnPrintFine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrintFine.ForeColor = System.Drawing.Color.White;
            this.btnPrintFine.Location = new System.Drawing.Point(160, 405);
            this.btnPrintFine.Name = "btnPrintFine";
            this.btnPrintFine.Size = new System.Drawing.Size(120, 45);
            this.btnPrintFine.TabIndex = 10;
            this.btnPrintFine.Text = "In Biên Lai Phạt";
            // 
            // QuanLyMuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvLoans);
            this.Controls.Add(this.panelInputs);
            this.Controls.Add(this.panelTop);
            this.Name = "QuanLyMuonTra";
            this.Size = new System.Drawing.Size(1000, 600);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoans)).EndInit();
            this.panelInputs.ResumeLayout(false);
            this.panelInputs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private Guna.UI2.WinForms.Guna2Button btnReturn;
        private Guna.UI2.WinForms.Guna2Button btnBorrow;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLoans;
        private Guna.UI2.WinForms.Guna2Panel panelInputs;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpReturnDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpBorrowDate;
        private Guna.UI2.WinForms.Guna2TextBox txtReaderID;
        private Guna.UI2.WinForms.Guna2TextBox txtBookID;
        private Guna.UI2.WinForms.Guna2TextBox txtLoanID;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnPrintBorrow;
        private Guna.UI2.WinForms.Guna2Button btnPrintFine;
    }
}
