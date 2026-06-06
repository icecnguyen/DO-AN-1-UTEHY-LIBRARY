namespace qltv
{
    partial class QuanLyNhaCungCap
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
            this.dgvSuppliers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelInputs = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSupplierPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSupplierAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSupplierEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSupplierContact = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSupplierName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtSupplierID = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
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
            this.btnDelete.TabIndex = 2;
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
            this.btnEdit.TabIndex = 3;
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
            this.txtSearch.PlaceholderText = "Tìm kiếm nhà cung cấp...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(300, 40);
            this.txtSearch.TabIndex = 0;
            // 
            // dgvSuppliers
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvSuppliers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSuppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuppliers.BackgroundColor = System.Drawing.Color.White;
            this.dgvSuppliers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSuppliers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSuppliers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSuppliers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSuppliers.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSuppliers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSuppliers.EnableHeadersVisualStyles = false;
            this.dgvSuppliers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvSuppliers.Location = new System.Drawing.Point(0, 80);
            this.dgvSuppliers.Name = "dgvSuppliers";
            this.dgvSuppliers.RowHeadersVisible = false;
            this.dgvSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSuppliers.Size = new System.Drawing.Size(700, 520);
            this.dgvSuppliers.TabIndex = 1;
            // 
            // panelInputs
            // 
            this.panelInputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelInputs.Controls.Add(this.lblTitle);
            this.panelInputs.Controls.Add(this.txtSupplierPhone);
            this.panelInputs.Controls.Add(this.txtSupplierAddress);
            this.panelInputs.Controls.Add(this.txtSupplierEmail);
            this.panelInputs.Controls.Add(this.txtSupplierContact);
            this.panelInputs.Controls.Add(this.txtSupplierName);
            this.panelInputs.Controls.Add(this.txtSupplierID);
            this.panelInputs.Controls.Add(this.btnSave);
            this.panelInputs.Controls.Add(this.btnCancel);
            this.panelInputs.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInputs.Location = new System.Drawing.Point(700, 80);
            this.panelInputs.Name = "panelInputs";
            this.panelInputs.Size = new System.Drawing.Size(300, 520);
            this.panelInputs.TabIndex = 2;
            // 
            // txtSupplierPhone
            // 
            this.txtSupplierPhone.BorderRadius = 5;
            this.txtSupplierPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSupplierPhone.DefaultText = "";
            this.txtSupplierPhone.Location = new System.Drawing.Point(20, 180);
            this.txtSupplierPhone.Name = "txtSupplierPhone";
            this.txtSupplierPhone.PasswordChar = '\0';
            this.txtSupplierPhone.PlaceholderText = "Số điện thoại";
            this.txtSupplierPhone.SelectedText = "";
            this.txtSupplierPhone.Size = new System.Drawing.Size(260, 36);
            this.txtSupplierPhone.TabIndex = 3;
            // 
            // txtSupplierAddress
            // 
            this.txtSupplierAddress.BorderRadius = 5;
            this.txtSupplierAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSupplierAddress.DefaultText = "";
            this.txtSupplierAddress.Location = new System.Drawing.Point(20, 230);
            this.txtSupplierAddress.Name = "txtSupplierAddress";
            this.txtSupplierAddress.PasswordChar = '\0';
            this.txtSupplierAddress.PlaceholderText = "Địa chỉ";
            this.txtSupplierAddress.SelectedText = "";
            this.txtSupplierAddress.Size = new System.Drawing.Size(260, 36);
            this.txtSupplierAddress.TabIndex = 4;
            // 
            // txtSupplierEmail
            // 
            this.txtSupplierEmail.BorderRadius = 5;
            this.txtSupplierEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSupplierEmail.DefaultText = "";
            this.txtSupplierEmail.Location = new System.Drawing.Point(20, 280);
            this.txtSupplierEmail.Name = "txtSupplierEmail";
            this.txtSupplierEmail.PasswordChar = '\0';
            this.txtSupplierEmail.PlaceholderText = "Email";
            this.txtSupplierEmail.SelectedText = "";
            this.txtSupplierEmail.Size = new System.Drawing.Size(260, 36);
            this.txtSupplierEmail.TabIndex = 5;
            // 
            // txtSupplierContact
            // 
            this.txtSupplierContact.BorderRadius = 5;
            this.txtSupplierContact.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSupplierContact.DefaultText = "";
            this.txtSupplierContact.Location = new System.Drawing.Point(20, 330);
            this.txtSupplierContact.Name = "txtSupplierContact";
            this.txtSupplierContact.PasswordChar = '\0';
            this.txtSupplierContact.PlaceholderText = "Người liên hệ";
            this.txtSupplierContact.SelectedText = "";
            this.txtSupplierContact.Size = new System.Drawing.Size(260, 36);
            this.txtSupplierContact.TabIndex = 6;
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.BorderRadius = 5;
            this.txtSupplierName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSupplierName.DefaultText = "";
            this.txtSupplierName.Location = new System.Drawing.Point(20, 130);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.PasswordChar = '\0';
            this.txtSupplierName.PlaceholderText = "Tên nhà cung cấp";
            this.txtSupplierName.SelectedText = "";
            this.txtSupplierName.Size = new System.Drawing.Size(260, 36);
            this.txtSupplierName.TabIndex = 2;
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.BorderRadius = 5;
            this.txtSupplierID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSupplierID.DefaultText = "";
            this.txtSupplierID.Location = new System.Drawing.Point(20, 80);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.PasswordChar = '\0';
            this.txtSupplierID.PlaceholderText = "Mã nhà cung cấp";
            this.txtSupplierID.SelectedText = "";
            this.txtSupplierID.Size = new System.Drawing.Size(260, 36);
            this.txtSupplierID.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 10;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(160, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 45);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(20, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(209, 21);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "THÔNG TIN NHÀ CUNG CẤP";
            // 
            // QuanLyNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSuppliers);
            this.Controls.Add(this.panelInputs);
            this.Controls.Add(this.panelTop);
            this.Name = "QuanLyNhaCungCap";
            this.Size = new System.Drawing.Size(1000, 600);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
            this.panelInputs.ResumeLayout(false);
            this.panelInputs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSuppliers;
        private Guna.UI2.WinForms.Guna2Panel panelInputs;
        private Guna.UI2.WinForms.Guna2TextBox txtSupplierPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtSupplierAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtSupplierEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtSupplierContact;
        private Guna.UI2.WinForms.Guna2TextBox txtSupplierName;
        private Guna.UI2.WinForms.Guna2TextBox txtSupplierID;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
    }
}
