namespace qltv
{
    partial class QuanLySach
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
            this.dgvBooks = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelInputs = new Guna.UI2.WinForms.Guna2Panel();
            this.txtQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAuthor = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPublisher = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPubYear = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboDanhMuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBookName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBookID = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
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
            this.txtSearch.PlaceholderText = "Tìm kiếm sách...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(300, 40);
            this.txtSearch.TabIndex = 0;
            // 
            // dgvBooks
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvBooks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBooks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvBooks.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBooks.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBooks.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooks.EnableHeadersVisualStyles = false;
            this.dgvBooks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBooks.Location = new System.Drawing.Point(0, 80);
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.RowHeadersVisible = false;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(700, 520);
            this.dgvBooks.TabIndex = 1;
            this.dgvBooks.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBooks.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvBooks.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvBooks.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvBooks.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvBooks.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvBooks.ThemeStyle.RowsStyle.Height = 22;
            // 
            // panelInputs
            // 
            this.panelInputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelInputs.Controls.Add(this.lblTitle);
            this.panelInputs.Controls.Add(this.txtPublisher);
            this.panelInputs.Controls.Add(this.txtPubYear);
            this.panelInputs.Controls.Add(this.cboDanhMuc);
            this.panelInputs.Controls.Add(this.txtPrice);
            this.panelInputs.Controls.Add(this.txtQuantity);
            this.panelInputs.Controls.Add(this.txtAuthor);
            this.panelInputs.Controls.Add(this.txtBookName);
            this.panelInputs.Controls.Add(this.txtBookID);
            this.panelInputs.Controls.Add(this.btnSave);
            this.panelInputs.Controls.Add(this.btnCancel);
            this.panelInputs.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInputs.Location = new System.Drawing.Point(700, 80);
            this.panelInputs.Name = "panelInputs";
            this.panelInputs.Size = new System.Drawing.Size(300, 520);
            this.panelInputs.TabIndex = 2;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderRadius = 5;
            this.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuantity.DefaultText = "";
            this.txtQuantity.Location = new System.Drawing.Point(20, 330);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PasswordChar = '\0';
            this.txtQuantity.PlaceholderText = "Số lượng tồn";
            this.txtQuantity.SelectedText = "";
            this.txtQuantity.Size = new System.Drawing.Size(260, 36);
            this.txtQuantity.TabIndex = 8;
            // 
            // txtAuthor
            // 
            this.txtAuthor.BorderRadius = 5;
            this.txtAuthor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAuthor.DefaultText = "";
            this.txtAuthor.Location = new System.Drawing.Point(20, 180);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.PasswordChar = '\0';
            this.txtAuthor.PlaceholderText = "Tác giả";
            this.txtAuthor.SelectedText = "";
            this.txtAuthor.Size = new System.Drawing.Size(125, 36);
            this.txtAuthor.TabIndex = 3;
            // 
            // txtPublisher
            // 
            this.txtPublisher.BorderRadius = 5;
            this.txtPublisher.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPublisher.DefaultText = "";
            this.txtPublisher.Location = new System.Drawing.Point(155, 180);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.PasswordChar = '\0';
            this.txtPublisher.PlaceholderText = "Nhà XB";
            this.txtPublisher.SelectedText = "";
            this.txtPublisher.Size = new System.Drawing.Size(125, 36);
            this.txtPublisher.TabIndex = 4;
            // 
            // txtPubYear
            // 
            this.txtPubYear.BorderRadius = 5;
            this.txtPubYear.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPubYear.DefaultText = "";
            this.txtPubYear.Location = new System.Drawing.Point(20, 230);
            this.txtPubYear.Name = "txtPubYear";
            this.txtPubYear.PasswordChar = '\0';
            this.txtPubYear.PlaceholderText = "Năm XB";
            this.txtPubYear.SelectedText = "";
            this.txtPubYear.Size = new System.Drawing.Size(125, 36);
            this.txtPubYear.TabIndex = 5;
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.BackColor = System.Drawing.Color.Transparent;
            this.cboDanhMuc.BorderRadius = 5;
            this.cboDanhMuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.FocusedColor = System.Drawing.Color.Empty;
            this.cboDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboDanhMuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.ItemHeight = 30;
            this.cboDanhMuc.Location = new System.Drawing.Point(20, 280);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(260, 36);
            this.cboDanhMuc.TabIndex = 7;
            // 
            // txtPrice
            // 
            this.txtPrice.BorderRadius = 5;
            this.txtPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrice.DefaultText = "";
            this.txtPrice.Location = new System.Drawing.Point(155, 230);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.PasswordChar = '\0';
            this.txtPrice.PlaceholderText = "Giá sách";
            this.txtPrice.SelectedText = "";
            this.txtPrice.Size = new System.Drawing.Size(125, 36);
            this.txtPrice.TabIndex = 6;
            // 
            // txtBookName
            // 
            this.txtBookName.BorderRadius = 5;
            this.txtBookName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBookName.DefaultText = "";
            this.txtBookName.Location = new System.Drawing.Point(20, 130);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.PasswordChar = '\0';
            this.txtBookName.PlaceholderText = "Tên sách";
            this.txtBookName.SelectedText = "";
            this.txtBookName.Size = new System.Drawing.Size(260, 36);
            this.txtBookName.TabIndex = 2;
            // 
            // txtBookID
            // 
            this.txtBookID.BorderRadius = 5;
            this.txtBookID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBookID.DefaultText = "";
            this.txtBookID.Location = new System.Drawing.Point(20, 80);
            this.txtBookID.Name = "txtBookID";
            this.txtBookID.PasswordChar = '\0';
            this.txtBookID.PlaceholderText = "Mã sách";
            this.txtBookID.SelectedText = "";
            this.txtBookID.Size = new System.Drawing.Size(260, 36);
            this.txtBookID.TabIndex = 1;
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
            this.btnSave.TabIndex = 9;
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
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Hủy";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(141, 21);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "CHI TIẾT SÁCH";
            // 
            // QuanLySach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvBooks);
            this.Controls.Add(this.panelInputs);
            this.Controls.Add(this.panelTop);
            this.Name = "QuanLySach";
            this.Size = new System.Drawing.Size(1000, 600);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
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
        private Guna.UI2.WinForms.Guna2DataGridView dgvBooks;
        private Guna.UI2.WinForms.Guna2Panel panelInputs;
        private Guna.UI2.WinForms.Guna2TextBox txtQuantity;
        private Guna.UI2.WinForms.Guna2TextBox txtAuthor;
        private Guna.UI2.WinForms.Guna2TextBox txtPublisher;
        private Guna.UI2.WinForms.Guna2TextBox txtPubYear;
        private Guna.UI2.WinForms.Guna2ComboBox cboDanhMuc;
        private Guna.UI2.WinForms.Guna2TextBox txtPrice;
        private Guna.UI2.WinForms.Guna2TextBox txtBookName;
        private Guna.UI2.WinForms.Guna2TextBox txtBookID;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
    }
}
