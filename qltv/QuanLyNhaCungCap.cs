using System;
using System.Data;
using System.Windows.Forms;
using qltv.BLL;
using qltv.DTO;

namespace qltv
{
    public partial class QuanLyNhaCungCap : UserControl
    {
        private NhaCungCapBLL _nhaCungCapBLL = new NhaCungCapBLL();
        private bool _Them = false;
        private bool _Sua = false;

        public QuanLyNhaCungCap()
        {
            InitializeComponent();
            this.Load += UCQuanLyNhaCungCap_Load;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            dgvSuppliers.SelectionChanged += DgvNhaCungCap_SelectionChanged;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void UCQuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            dgvSuppliers.ReadOnly = true;
            LoadData();
            SetState(false);
        }

        private void LoadData()
        {
            try
            {
                dgvSuppliers.DataSource = _nhaCungCapBLL.LayTatCaNhaCungCap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetState(bool isEditMode)
        {
            txtSupplierID.ReadOnly = !isEditMode || _Sua;
            txtSupplierName.ReadOnly = !isEditMode;
            txtSupplierPhone.ReadOnly = !isEditMode;
            txtSupplierAddress.ReadOnly = !isEditMode;
            txtSupplierEmail.ReadOnly = !isEditMode;
            txtSupplierContact.ReadOnly = !isEditMode;

            btnSave.Enabled = isEditMode;
            btnCancel.Enabled = isEditMode;

            btnAdd.Enabled = !isEditMode;
            btnEdit.Enabled = !isEditMode;
            btnDelete.Enabled = !isEditMode;

            dgvSuppliers.Enabled = !isEditMode;
            txtSearch.Enabled = !isEditMode;
        }

        private void ClearInputs()
        {
            txtSupplierID.Clear();
            txtSupplierName.Clear();
            txtSupplierPhone.Clear();
            txtSupplierAddress.Clear();
            txtSupplierEmail.Clear();
            txtSupplierContact.Clear();
        }

        private void HienThiNhaCungCapDaChon()
        {
            if (dgvSuppliers.SelectedRows.Count > 0 && dgvSuppliers.SelectedRows[0].Cells[0].Value != null)
            {
                DataGridViewRow row = dgvSuppliers.SelectedRows[0];
                txtSupplierID.Text = row.Cells["Mã NCC"].Value.ToString();
                txtSupplierName.Text = row.Cells["Tên Nhà Cung Cấp"].Value.ToString();
                txtSupplierPhone.Text = row.Cells["Số Điện Thoại"].Value != DBNull.Value ? row.Cells["Số Điện Thoại"].Value.ToString() : "";
                txtSupplierAddress.Text = row.Cells["Địa Chỉ"].Value != DBNull.Value ? row.Cells["Địa Chỉ"].Value.ToString() : "";
                txtSupplierEmail.Text = row.Cells["Email"].Value != DBNull.Value ? row.Cells["Email"].Value.ToString() : "";
                txtSupplierContact.Text = row.Cells["Người Liên Hệ"].Value != DBNull.Value ? row.Cells["Người Liên Hệ"].Value.ToString() : "";
            }
            else
            {
                ClearInputs();
            }
        }

        private void DgvNhaCungCap_SelectionChanged(object sender, EventArgs e)
        {
            if (!_Them && !_Sua)
            {
                HienThiNhaCungCapDaChon();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            _Them = true;
            ClearInputs();
            SetState(true);
            txtSupplierID.Focus();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count == 0 || dgvSuppliers.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _Them = false;
            _Sua = true;
            SetState(true);
            txtSupplierName.Focus();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _Them = false;
            _Sua = false;
            SetState(false);
            HienThiNhaCungCapDaChon();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count == 0 || dgvSuppliers.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNCC = dgvSuppliers.SelectedRows[0].Cells["Mã NCC"].Value.ToString();
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhà cung cấp '{maNCC}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_nhaCungCapBLL.XoaNhaCungCap(maNCC))
                    {
                        MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                NhaCungCapDTO ncc = new NhaCungCapDTO
                {
                    MaNCC = txtSupplierID.Text.Trim(),
                    TenNCC = txtSupplierName.Text.Trim(),
                    SDT = txtSupplierPhone.Text.Trim(),
                    DiaChi = txtSupplierAddress.Text.Trim(),
                    Email = txtSupplierEmail.Text.Trim(),
                    NguoiLienHe = txtSupplierContact.Text.Trim()
                };

                if (_Them)
                {
                    if (_nhaCungCapBLL.ThemNhaCungCap(ncc))
                    {
                        MessageBox.Show("Thêm mới nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (_Sua)
                {
                    if (_nhaCungCapBLL.CapNhatNhaCungCap(ncc))
                    {
                        MessageBox.Show("Cập nhật thông tin nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                _Them = false;
                _Sua = false;
                SetState(false);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadData();
            }
            else
            {
                try
                {
                    dgvSuppliers.DataSource = _nhaCungCapBLL.TimKiemNhaCungCap(keyword);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

