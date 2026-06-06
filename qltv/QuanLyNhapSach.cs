using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using qltv.BLL;
using qltv.DTO;

namespace qltv
{
    public partial class QuanLyNhapSach : UserControl
    {
        private NhapSachBLL _nhapSachBLL = new NhapSachBLL();
        private NhaCungCapBLL _nhaCungCapBLL = new NhaCungCapBLL();
        private SachBLL _sachBLL = new SachBLL();

        private bool _Them = false;
        private DataTable _dtTemp;

        public QuanLyNhapSach()
        {
            InitializeComponent();
            this.Load += QuanLyNhapSach_Load;
            btnAdd.Click += BtnAdd_Click;
            btnDelete.Click += BtnDelete_Click;
            btnAddItem.Click += BtnAddItem_Click;
            btnRemoveItem.Click += BtnRemoveItem_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            dgvImports.SelectionChanged += DgvImports_SelectionChanged;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void QuanLyNhapSach_Load(object sender, EventArgs e)
        {
            dgvImports.ReadOnly = true;
            dgvDetails.ReadOnly = true;
            dgvTempItems.ReadOnly = true;

            LoadData();
            LoadComboboxData();
            InitTempTable();
            SetState(false);
        }

        private void LoadData()
        {
            try
            {
                dgvImports.DataSource = _nhapSachBLL.LayTatCaPhieuNhap();
                if (dgvImports.Rows.Count > 0)
                {
                    DisplaySelectedImport();
                }
                else
                {
                    dgvDetails.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải lịch sử nhập sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboboxData()
        {
            try
            {
                // Nạp danh sách Nhà cung cấp từ cơ sở dữ liệu
                DataTable dtSuppliers = _nhaCungCapBLL.LayTatCaNhaCungCap();
                cboNhaCungCap.DataSource = dtSuppliers;
                cboNhaCungCap.DisplayMember = "Tên Nhà Cung Cấp";
                cboNhaCungCap.ValueMember = "Mã NCC";

                // Nạp danh sách Sách từ cơ sở dữ liệu
                DataTable dtBooks = _sachBLL.LayTatCaSach();
                cboBook.DataSource = dtBooks;
                cboBook.DisplayMember = "Tên Sách";
                cboBook.ValueMember = "Mã Sách";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin danh mục hỗ trợ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitTempTable()
        {
            _dtTemp = new DataTable();
            _dtTemp.Columns.Add("Mã Sách");
            _dtTemp.Columns.Add("Tên Sách");
            _dtTemp.Columns.Add("Số Lượng", typeof(int));
            _dtTemp.Columns.Add("Đơn Giá", typeof(decimal));
            _dtTemp.Columns.Add("Thành Tiền", typeof(decimal));
            dgvTempItems.DataSource = _dtTemp;

            CalculateTotal();
        }

        private void SetState(bool isEditMode)
        {
            txtImportID.ReadOnly = !isEditMode;
            cboNhaCungCap.Enabled = isEditMode;
            cboBook.Enabled = isEditMode;
            txtQuantity.ReadOnly = !isEditMode;
            txtUnitPrice.ReadOnly = !isEditMode;

            btnAddItem.Enabled = isEditMode;
            btnRemoveItem.Enabled = isEditMode;
            dgvTempItems.Enabled = isEditMode;

            btnSave.Enabled = isEditMode;
            btnCancel.Enabled = isEditMode;

            btnAdd.Enabled = !isEditMode;
            btnDelete.Enabled = !isEditMode;
            txtSearch.Enabled = !isEditMode;
            dgvImports.Enabled = !isEditMode;
        }

        private void ClearInputs()
        {
            txtImportID.Clear();
            txtQuantity.Clear();
            txtUnitPrice.Clear();
            if (cboNhaCungCap.Items.Count > 0) cboNhaCungCap.SelectedIndex = 0;
            if (cboBook.Items.Count > 0) cboBook.SelectedIndex = 0;
            _dtTemp.Clear();
            CalculateTotal();
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (DataRow row in _dtTemp.Rows)
            {
                total += Convert.ToDecimal(row["Thành Tiền"]);
            }
            lblTotalMoney.Text = total.ToString("N0") + " VND";
        }

        private void DisplaySelectedImport()
        {
            if (dgvImports.SelectedRows.Count > 0 && dgvImports.SelectedRows[0].Cells[0].Value != null)
            {
                string maPhieu = dgvImports.SelectedRows[0].Cells["Mã Phiếu Nhập"].Value.ToString();
                try
                {
                    dgvDetails.DataSource = _nhapSachBLL.LayChiTietPhieuNhap(maPhieu);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải chi tiết phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                dgvDetails.DataSource = null;
            }
        }

        private void DgvImports_SelectionChanged(object sender, EventArgs e)
        {
            if (!_Them)
            {
                DisplaySelectedImport();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            _Them = true;
            ClearInputs();
            SetState(true);
            txtImportID.Focus();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _Them = false;
            ClearInputs();
            SetState(false);
            DisplaySelectedImport();
        }

        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            if (cboBook.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sách để nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), out int qty) || qty <= 0)
            {
                MessageBox.Show("Số lượng nhập phải là số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtUnitPrice.Text.Trim(), out decimal price) || price <= 0)
            {
                MessageBox.Show("Đơn giá nhập phải là số dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maSach = cboBook.SelectedValue.ToString();
            string tenSach = cboBook.Text;

            // Kiểm tra sự tồn tại của sách trong danh sách nhập tạm thời
            foreach (DataRow row in _dtTemp.Rows)
            {
                if (row["Mã Sách"].ToString() == maSach)
                {
                    // Cập nhật tăng số lượng sách
                    row["Số Lượng"] = Convert.ToInt32(row["Số Lượng"]) + qty;
                    row["Đơn Giá"] = price; // Update to latest price
                    row["Thành Tiền"] = Convert.ToInt32(row["Số Lượng"]) * price;
                    CalculateTotal();
                    txtQuantity.Clear();
                    txtUnitPrice.Clear();
                    return;
                }
            }

            // Thêm mới sách vào danh sách nhập nếu chưa tồn tại
            DataRow newRow = _dtTemp.NewRow();
            newRow["Mã Sách"] = maSach;
            newRow["Tên Sách"] = tenSach;
            newRow["Số Lượng"] = qty;
            newRow["Đơn Giá"] = price;
            newRow["Thành Tiền"] = qty * price;
            _dtTemp.Rows.Add(newRow);

            CalculateTotal();
            txtQuantity.Clear();
            txtUnitPrice.Clear();
        }

        private void BtnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvTempItems.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvTempItems.SelectedRows)
                {
                    if (row.DataBoundItem != null)
                    {
                        DataRowView drv = (DataRowView)row.DataBoundItem;
                        _dtTemp.Rows.Remove(drv.Row);
                    }
                }
                CalculateTotal();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng sách cần xóa khỏi danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string maPhieu = txtImportID.Text.Trim();
            if (string.IsNullOrEmpty(maPhieu))
            {
                MessageBox.Show("Mã phiếu nhập không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_dtTemp.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một quyển sách vào phiếu nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PhieuNhapSachDTO pn = new PhieuNhapSachDTO
                {
                    MaPhieuNhap = maPhieu,
                    MaNV = PhienLamViec.EmployeeID, // Linked with current active staff
                    MaNCC = cboNhaCungCap.SelectedValue.ToString()
                };

                List<ChiTietPhieuNhapDTO> listCt = new List<ChiTietPhieuNhapDTO>();
                foreach (DataRow row in _dtTemp.Rows)
                {
                    listCt.Add(new ChiTietPhieuNhapDTO
                    {
                        MaPhieuNhap = maPhieu,
                        MaSach = row["Mã Sách"].ToString(),
                        SoLuong = Convert.ToInt32(row["Số Lượng"]),
                        DonGia = Convert.ToDecimal(row["Đơn Giá"])
                    });
                }

                if (_nhapSachBLL.ThemPhieuNhap(pn, listCt))
                {
                    MessageBox.Show("Lập phiếu nhập sách và cập nhật kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Them = false;
                    SetState(false);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi lập phiếu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvImports.SelectedRows.Count == 0 || dgvImports.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập sách cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maPhieu = dgvImports.SelectedRows[0].Cells["Mã Phiếu Nhập"].Value.ToString();
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa phiếu nhập sách '{maPhieu}'? Hành động này sẽ tự động giảm trừ số lượng tồn kho tương ứng của các sách đã nhập.", "Xác nhận xóa phiếu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_nhapSachBLL.XoaPhieuNhap(maPhieu))
                    {
                        MessageBox.Show("Xóa phiếu nhập sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
            }
            else
            {
                try
                {
                    dgvImports.DataSource = _nhapSachBLL.TimKiemPhieuNhap(keyword);
                    if (dgvImports.Rows.Count > 0)
                    {
                        DisplaySelectedImport();
                    }
                    else
                    {
                        dgvDetails.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
