namespace qltv
{
    partial class QuanLyDanhMuc
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
            this.dgvDanhMuc = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelInputs = new Guna.UI2.WinForms.Guna2Panel();
            this.txtTenDM = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMaDM = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMoTa = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
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
            this.txtSearch.PlaceholderText = "Tìm kiếm danh mục...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(300, 40);
            this.txtSearch.TabIndex = 0;
            // 
            // dgvDanhMuc
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDanhMuc.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhMuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhMuc.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhMuc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDanhMuc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDanhMuc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhMuc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhMuc.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhMuc.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhMuc.EnableHeadersVisualStyles = false;
            this.dgvDanhMuc.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDanhMuc.Location = new System.Drawing.Point(0, 80);
            this.dgvDanhMuc.Name = "dgvDanhMuc";
            this.dgvDanhMuc.RowHeadersVisible = false;
            this.dgvDanhMuc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhMuc.Size = new System.Drawing.Size(700, 520);
            this.dgvDanhMuc.TabIndex = 1;
            // 
            // panelInputs
            // 
            this.panelInputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelInputs.Controls.Add(this.lblTitle);
            this.panelInputs.Controls.Add(this.txtTenDM);
            this.panelInputs.Controls.Add(this.txtMaDM);
            this.panelInputs.Controls.Add(this.txtMoTa);
            this.panelInputs.Controls.Add(this.btnSave);
            this.panelInputs.Controls.Add(this.btnCancel);
            this.panelInputs.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInputs.Location = new System.Drawing.Point(700, 80);
            this.panelInputs.Name = "panelInputs";
            this.panelInputs.Size = new System.Drawing.Size(300, 520);
            this.panelInputs.TabIndex = 2;
            // 
            // txtTenDM
            // 
            this.txtTenDM.BorderRadius = 5;
            this.txtTenDM.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenDM.DefaultText = "";
            this.txtTenDM.Location = new System.Drawing.Point(20, 130);
            this.txtTenDM.Name = "txtTenDM";
            this.txtTenDM.PasswordChar = '\0';
            this.txtTenDM.PlaceholderText = "Tên danh mục";
            this.txtTenDM.SelectedText = "";
            this.txtTenDM.Size = new System.Drawing.Size(260, 36);
            this.txtTenDM.TabIndex = 2;
            // 
            // txtMaDM
            // 
            this.txtMaDM.BorderRadius = 5;
            this.txtMaDM.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaDM.DefaultText = "";
            this.txtMaDM.Location = new System.Drawing.Point(20, 80);
            this.txtMaDM.Name = "txtMaDM";
            this.txtMaDM.PasswordChar = '\0';
            this.txtMaDM.PlaceholderText = "Mã danh mục";
            this.txtMaDM.SelectedText = "";
            this.txtMaDM.Size = new System.Drawing.Size(260, 36);
            this.txtMaDM.TabIndex = 1;
            // 
            // txtMoTa
            // 
            this.txtMoTa.BorderRadius = 5;
            this.txtMoTa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMoTa.DefaultText = "";
            this.txtMoTa.Location = new System.Drawing.Point(20, 180);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.PasswordChar = '\0';
            this.txtMoTa.PlaceholderText = "Mô tả";
            this.txtMoTa.SelectedText = "";
            this.txtMoTa.Size = new System.Drawing.Size(260, 36);
            this.txtMoTa.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 10;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(160, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 45);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(20, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 45);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(176, 21);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "THÔNG TIN DANH MỤC";
            // 
            // QuanLyDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvDanhMuc);
            this.Controls.Add(this.panelInputs);
            this.Controls.Add(this.panelTop);
            this.Name = "QuanLyDanhMuc";
            this.Size = new System.Drawing.Size(1000, 600);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
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
        private Guna.UI2.WinForms.Guna2DataGridView dgvDanhMuc;
        private Guna.UI2.WinForms.Guna2Panel panelInputs;
        private Guna.UI2.WinForms.Guna2TextBox txtTenDM;
        private Guna.UI2.WinForms.Guna2TextBox txtMaDM;
        private Guna.UI2.WinForms.Guna2TextBox txtMoTa;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
    }
}
