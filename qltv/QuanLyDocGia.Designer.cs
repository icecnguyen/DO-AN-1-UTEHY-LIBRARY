namespace qltv
{
    partial class QuanLyDocGia
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
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvReaders = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelInputs = new Guna.UI2.WinForms.Guna2Panel();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpBirthDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cboGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDept = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpExpiryDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.cboStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtReaderName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtReaderID = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReaders)).BeginInit();
            this.panelInputs.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnDelete);
            this.panelTop.Controls.Add(this.btnEdit);
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Controls.Add(this.txtSearch);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 80);
            this.panelTop.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BorderRadius = 10;
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(880, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BorderRadius = 10;
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(770, 20);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 40);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BorderRadius = 10;
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(660, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 15;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Location = new System.Drawing.Point(20, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Tìm kiếm độc giả...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(300, 40);
            this.txtSearch.TabIndex = 0;
            // 
            // dgvReaders
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvReaders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReaders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReaders.BackgroundColor = System.Drawing.Color.White;
            this.dgvReaders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReaders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReaders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReaders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReaders.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReaders.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvReaders.EnableHeadersVisualStyles = false;
            this.dgvReaders.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReaders.Location = new System.Drawing.Point(0, 80);
            this.dgvReaders.Name = "dgvReaders";
            this.dgvReaders.RowHeadersVisible = false;
            this.dgvReaders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReaders.Size = new System.Drawing.Size(700, 520);
            this.dgvReaders.TabIndex = 1;
            // 
            // panelInputs
            // 
            this.panelInputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelInputs.Controls.Add(this.lblTitle);
            this.panelInputs.Controls.Add(this.dtpBirthDate);
            this.panelInputs.Controls.Add(this.cboGender);
            this.panelInputs.Controls.Add(this.txtEmail);
            this.panelInputs.Controls.Add(this.txtDept);
            this.panelInputs.Controls.Add(this.dtpExpiryDate);
            this.panelInputs.Controls.Add(this.cboStatus);
            this.panelInputs.Controls.Add(this.txtPhone);
            this.panelInputs.Controls.Add(this.txtReaderName);
            this.panelInputs.Controls.Add(this.txtReaderID);
            this.panelInputs.Controls.Add(this.btnSave);
            this.panelInputs.Controls.Add(this.btnCancel);
            this.panelInputs.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInputs.Location = new System.Drawing.Point(700, 80);
            this.panelInputs.Name = "panelInputs";
            this.panelInputs.Size = new System.Drawing.Size(300, 520);
            this.panelInputs.TabIndex = 2;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderRadius = 5;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.Location = new System.Drawing.Point(20, 230);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PasswordChar = '\0';
            this.txtPhone.PlaceholderText = "SĐT";
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(125, 36);
            this.txtPhone.TabIndex = 5;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.BorderRadius = 5;
            this.dtpBirthDate.Checked = true;
            this.dtpBirthDate.FillColor = System.Drawing.Color.White;
            this.dtpBirthDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(20, 180);
            this.dtpBirthDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpBirthDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(125, 36);
            this.dtpBirthDate.TabIndex = 3;
            // 
            // cboGender
            // 
            this.cboGender.BackColor = System.Drawing.Color.Transparent;
            this.cboGender.BorderRadius = 5;
            this.cboGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FocusedColor = System.Drawing.Color.Empty;
            this.cboGender.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboGender.FormattingEnabled = true;
            this.cboGender.ItemHeight = 30;
            this.cboGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGender.Location = new System.Drawing.Point(155, 180);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(125, 36);
            this.cboGender.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 5;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.Location = new System.Drawing.Point(155, 230);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "Email";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(125, 36);
            this.txtEmail.TabIndex = 6;
            // 
            // txtDept
            // 
            this.txtDept.BorderRadius = 5;
            this.txtDept.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDept.DefaultText = "";
            this.txtDept.Location = new System.Drawing.Point(20, 280);
            this.txtDept.Name = "txtDept";
            this.txtDept.PasswordChar = '\0';
            this.txtDept.PlaceholderText = "Khoa";
            this.txtDept.SelectedText = "";
            this.txtDept.Size = new System.Drawing.Size(260, 36);
            this.txtDept.TabIndex = 7;
            // 
            // dtpExpiryDate
            // 
            this.dtpExpiryDate.BorderRadius = 5;
            this.dtpExpiryDate.Checked = true;
            this.dtpExpiryDate.FillColor = System.Drawing.Color.White;
            this.dtpExpiryDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpiryDate.Location = new System.Drawing.Point(20, 330);
            this.dtpExpiryDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpExpiryDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpExpiryDate.Name = "dtpExpiryDate";
            this.dtpExpiryDate.Size = new System.Drawing.Size(260, 36);
            this.dtpExpiryDate.TabIndex = 8;
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.Transparent;
            this.cboStatus.BorderRadius = 5;
            this.cboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FocusedColor = System.Drawing.Color.Empty;
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.ItemHeight = 30;
            this.cboStatus.Items.AddRange(new object[] {
            "Hoạt động",
            "Khóa"});
            this.cboStatus.Location = new System.Drawing.Point(20, 380);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(260, 36);
            this.cboStatus.TabIndex = 9;
            // 
            // txtReaderName
            // 
            this.txtReaderName.BorderRadius = 5;
            this.txtReaderName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReaderName.DefaultText = "";
            this.txtReaderName.Location = new System.Drawing.Point(20, 130);
            this.txtReaderName.Name = "txtReaderName";
            this.txtReaderName.PasswordChar = '\0';
            this.txtReaderName.PlaceholderText = "Họ và tên";
            this.txtReaderName.SelectedText = "";
            this.txtReaderName.Size = new System.Drawing.Size(260, 36);
            this.txtReaderName.TabIndex = 2;
            // 
            // txtReaderID
            // 
            this.txtReaderID.BorderRadius = 5;
            this.txtReaderID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtReaderID.DefaultText = "";
            this.txtReaderID.Location = new System.Drawing.Point(20, 80);
            this.txtReaderID.Name = "txtReaderID";
            this.txtReaderID.PasswordChar = '\0';
            this.txtReaderID.PlaceholderText = "Mã độc giả";
            this.txtReaderID.SelectedText = "";
            this.txtReaderID.Size = new System.Drawing.Size(260, 36);
            this.txtReaderID.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 10;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(160, 440);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 45);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Lưu";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(20, 440);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Hủy";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(170, 21);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "THÔNG TIN ĐỘC GIẢ";
            // 
            // QuanLyDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvReaders);
            this.Controls.Add(this.panelInputs);
            this.Controls.Add(this.panelTop);
            this.Name = "QuanLyDocGia";
            this.Size = new System.Drawing.Size(1000, 600);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReaders)).EndInit();
            this.panelInputs.ResumeLayout(false);
            this.panelInputs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2DataGridView dgvReaders;
        private Guna.UI2.WinForms.Guna2Panel panelInputs;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpBirthDate;
        private Guna.UI2.WinForms.Guna2ComboBox cboGender;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtDept;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpExpiryDate;
        private Guna.UI2.WinForms.Guna2ComboBox cboStatus;
        private Guna.UI2.WinForms.Guna2TextBox txtReaderName;
        private Guna.UI2.WinForms.Guna2TextBox txtReaderID;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
    }
}
