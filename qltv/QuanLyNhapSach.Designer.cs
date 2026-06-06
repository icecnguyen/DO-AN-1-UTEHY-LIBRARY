namespace qltv
{
    partial class QuanLyNhapSach
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new Guna.UI2.WinForms.Guna2Panel();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.dgvDetails = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.dgvImports = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panelInputs = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalText = new System.Windows.Forms.Label();
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.dgvTempItems = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnRemoveItem = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddItem = new Guna.UI2.WinForms.Guna2Button();
            this.txtUnitPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtQuantity = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboBook = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboNhaCungCap = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtImportID = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImports)).BeginInit();
            this.panelInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempItems)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnDelete);
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
            this.btnDelete.Text = "Xóa Phiếu";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BorderRadius = 10;
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(740, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 40);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Lập Phiếu Mới";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 15;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Location = new System.Drawing.Point(20, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Tìm kiếm phiếu nhập...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(300, 40);
            this.txtSearch.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.lblDetailsTitle);
            this.panelLeft.Controls.Add(this.dgvDetails);
            this.panelLeft.Controls.Add(this.lblHistoryTitle);
            this.panelLeft.Controls.Add(this.dgvImports);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 80);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(650, 520);
            this.panelLeft.TabIndex = 1;
            // 
            // lblDetailsTitle
            // 
            this.lblDetailsTitle.AutoSize = true;
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetailsTitle.Location = new System.Drawing.Point(20, 260);
            this.lblDetailsTitle.Name = "lblDetailsTitle";
            this.lblDetailsTitle.Size = new System.Drawing.Size(161, 19);
            this.lblDetailsTitle.TabIndex = 3;
            this.lblDetailsTitle.Text = "Chi tiết phiếu nhập chọn";
            // 
            // dgvDetails
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetails.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetails.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetails.EnableHeadersVisualStyles = false;
            this.dgvDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvDetails.Location = new System.Drawing.Point(20, 290);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(610, 210);
            this.dgvDetails.TabIndex = 2;
            // 
            // lblHistoryTitle
            // 
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.Location = new System.Drawing.Point(20, 10);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(161, 19);
            this.lblHistoryTitle.TabIndex = 1;
            this.lblHistoryTitle.Text = "Lịch sử các phiếu nhập";
            // 
            // dgvImports
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dgvImports.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvImports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvImports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvImports.BackgroundColor = System.Drawing.Color.White;
            this.dgvImports.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvImports.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvImports.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvImports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvImports.ColumnHeadersHeight = 30;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvImports.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvImports.EnableHeadersVisualStyles = false;
            this.dgvImports.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvImports.Location = new System.Drawing.Point(20, 40);
            this.dgvImports.Name = "dgvImports";
            this.dgvImports.RowHeadersVisible = false;
            this.dgvImports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvImports.Size = new System.Drawing.Size(610, 200);
            this.dgvImports.TabIndex = 0;
            // 
            // panelInputs
            // 
            this.panelInputs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelInputs.Controls.Add(this.lblTotalText);
            this.panelInputs.Controls.Add(this.lblTotalMoney);
            this.panelInputs.Controls.Add(this.dgvTempItems);
            this.panelInputs.Controls.Add(this.btnRemoveItem);
            this.panelInputs.Controls.Add(this.btnAddItem);
            this.panelInputs.Controls.Add(this.txtUnitPrice);
            this.panelInputs.Controls.Add(this.txtQuantity);
            this.panelInputs.Controls.Add(this.cboBook);
            this.panelInputs.Controls.Add(this.cboNhaCungCap);
            this.panelInputs.Controls.Add(this.txtImportID);
            this.panelInputs.Controls.Add(this.btnSave);
            this.panelInputs.Controls.Add(this.btnCancel);
            this.panelInputs.Controls.Add(this.lblTitle);
            this.panelInputs.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelInputs.Location = new System.Drawing.Point(650, 80);
            this.panelInputs.Name = "panelInputs";
            this.panelInputs.Size = new System.Drawing.Size(350, 520);
            this.panelInputs.TabIndex = 2;
            // 
            // lblTotalText
            // 
            this.lblTotalText.AutoSize = true;
            this.lblTotalText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalText.Location = new System.Drawing.Point(20, 425);
            this.lblTotalText.Name = "lblTotalText";
            this.lblTotalText.Size = new System.Drawing.Size(76, 19);
            this.lblTotalText.TabIndex = 17;
            this.lblTotalText.Text = "Tổng tiền:";
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.AutoSize = true;
            this.lblTotalMoney.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTotalMoney.Location = new System.Drawing.Point(100, 423);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(58, 21);
            this.lblTotalMoney.TabIndex = 16;
            this.lblTotalMoney.Text = "0 VND";
            // 
            // dgvTempItems
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dgvTempItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvTempItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTempItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvTempItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTempItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTempItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTempItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvTempItems.ColumnHeadersHeight = 25;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTempItems.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvTempItems.EnableHeadersVisualStyles = false;
            this.dgvTempItems.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvTempItems.Location = new System.Drawing.Point(20, 290);
            this.dgvTempItems.Name = "dgvTempItems";
            this.dgvTempItems.RowHeadersVisible = false;
            this.dgvTempItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTempItems.Size = new System.Drawing.Size(310, 120);
            this.dgvTempItems.TabIndex = 15;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.BorderRadius = 5;
            this.btnRemoveItem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRemoveItem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnRemoveItem.ForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.Location = new System.Drawing.Point(230, 250);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(100, 30);
            this.btnRemoveItem.TabIndex = 14;
            this.btnRemoveItem.Text = "Xóa dòng";
            // 
            // btnAddItem
            // 
            this.btnAddItem.BorderRadius = 5;
            this.btnAddItem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAddItem.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Location = new System.Drawing.Point(20, 250);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(200, 30);
            this.btnAddItem.TabIndex = 13;
            this.btnAddItem.Text = "Thêm vào phiếu";
            // 
            // txtUnitPrice
            // 
            this.txtUnitPrice.BorderRadius = 5;
            this.txtUnitPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUnitPrice.DefaultText = "";
            this.txtUnitPrice.Location = new System.Drawing.Point(180, 205);
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.PasswordChar = '\0';
            this.txtUnitPrice.PlaceholderText = "Đơn giá nhập";
            this.txtUnitPrice.SelectedText = "";
            this.txtUnitPrice.Size = new System.Drawing.Size(150, 36);
            this.txtUnitPrice.TabIndex = 12;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderRadius = 5;
            this.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuantity.DefaultText = "";
            this.txtQuantity.Location = new System.Drawing.Point(20, 205);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.PasswordChar = '\0';
            this.txtQuantity.PlaceholderText = "Số lượng";
            this.txtQuantity.SelectedText = "";
            this.txtQuantity.Size = new System.Drawing.Size(150, 36);
            this.txtQuantity.TabIndex = 11;
            // 
            // cboBook
            // 
            this.cboBook.BackColor = System.Drawing.Color.Transparent;
            this.cboBook.BorderRadius = 5;
            this.cboBook.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBook.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBook.FocusedColor = System.Drawing.Color.Empty;
            this.cboBook.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboBook.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboBook.FormattingEnabled = true;
            this.cboBook.ItemHeight = 30;
            this.cboBook.Location = new System.Drawing.Point(20, 160);
            this.cboBook.Name = "cboBook";
            this.cboBook.Size = new System.Drawing.Size(310, 36);
            this.cboBook.TabIndex = 10;
            // 
            // cboNhaCungCap
            // 
            this.cboNhaCungCap.BackColor = System.Drawing.Color.Transparent;
            this.cboNhaCungCap.BorderRadius = 5;
            this.cboNhaCungCap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboNhaCungCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCungCap.FocusedColor = System.Drawing.Color.Empty;
            this.cboNhaCungCap.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboNhaCungCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboNhaCungCap.FormattingEnabled = true;
            this.cboNhaCungCap.ItemHeight = 30;
            this.cboNhaCungCap.Location = new System.Drawing.Point(20, 115);
            this.cboNhaCungCap.Name = "cboNhaCungCap";
            this.cboNhaCungCap.Size = new System.Drawing.Size(310, 36);
            this.cboNhaCungCap.TabIndex = 9;
            // 
            // txtImportID
            // 
            this.txtImportID.BorderRadius = 5;
            this.txtImportID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtImportID.DefaultText = "";
            this.txtImportID.Location = new System.Drawing.Point(20, 70);
            this.txtImportID.Name = "txtImportID";
            this.txtImportID.PasswordChar = '\0';
            this.txtImportID.PlaceholderText = "Mã phiếu nhập";
            this.txtImportID.SelectedText = "";
            this.txtImportID.Size = new System.Drawing.Size(310, 36);
            this.txtImportID.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 10;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(185, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 45);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu Phiếu";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(20, 460);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 45);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(185, 21);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "LẬP PHIẾU NHẬP SÁCH";
            // 
            // QuanLyNhapSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelInputs);
            this.Controls.Add(this.panelTop);
            this.Name = "QuanLyNhapSach";
            this.Size = new System.Drawing.Size(1000, 600);
            this.panelTop.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImports)).EndInit();
            this.panelInputs.ResumeLayout(false);
            this.panelInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTempItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panelTop;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Panel panelLeft;
        private Guna.UI2.WinForms.Guna2DataGridView dgvImports;
        private Guna.UI2.WinForms.Guna2Panel panelInputs;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.Label lblDetailsTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvDetails;
        private Guna.UI2.WinForms.Guna2ComboBox cboNhaCungCap;
        private Guna.UI2.WinForms.Guna2TextBox txtImportID;
        private Guna.UI2.WinForms.Guna2ComboBox cboBook;
        private Guna.UI2.WinForms.Guna2TextBox txtUnitPrice;
        private Guna.UI2.WinForms.Guna2TextBox txtQuantity;
        private Guna.UI2.WinForms.Guna2Button btnAddItem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTempItems;
        private Guna.UI2.WinForms.Guna2Button btnRemoveItem;
        private System.Windows.Forms.Label lblTotalText;
        private System.Windows.Forms.Label lblTotalMoney;
    }
}
