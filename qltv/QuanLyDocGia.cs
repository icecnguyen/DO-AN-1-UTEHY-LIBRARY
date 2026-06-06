using System;
using System.Data;
using System.Windows.Forms;
using qltv.BLL;
using qltv.DTO;

namespace qltv
{
    public partial class QuanLyDocGia : UserControl
    {
        private DocGiaBLL _docGiaBLL = new DocGiaBLL();
        private bool _Them = false;
        private bool _Sua = false;

        public QuanLyDocGia()
        {
            InitializeComponent();
            this.Load += UCReaders_Load;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            dgvReaders.SelectionChanged += DgvReaders_SelectionChanged;
        }

        private void UCReaders_Load(object sender, EventArgs e)
        {
            dgvReaders.ReadOnly = true;
            LoadData();
            SetState(false);
        }

        private void LoadData()
        {
            try
            {
                dgvReaders.DataSource = _docGiaBLL.LayTatCaDocGia();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách độc giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetState(bool isEditMode)
        {
            // Cấp quyền chỉnh sửa văn bản khi kích hoạt chế độ Thêm/Sửa
            txtReaderID.Enabled = isEditMode && _Them; // Chỉ cho sửa Mã Độc giả khi thêm mới
            txtReaderName.ReadOnly = !isEditMode;
            txtPhone.ReadOnly = !isEditMode;
            dtpBirthDate.Enabled = isEditMode;
            cboGender.Enabled = isEditMode;
            txtDept.ReadOnly = !isEditMode;
            txtEmail.ReadOnly = !isEditMode;
            dtpExpiryDate.Enabled = isEditMode;
            cboStatus.Enabled = isEditMode;

            // Điều chỉnh trạng thái hiển thị của các phím chức năng
            btnSave.Enabled = isEditMode;
            btnCancel.Enabled = isEditMode;

            btnAdd.Enabled = !isEditMode;
            btnEdit.Enabled = !isEditMode;
            btnDelete.Enabled = !isEditMode;
            txtSearch.Enabled = !isEditMode;

            // Cấp quyền lựa chọn dữ liệu lưới khi không trong tiến trình chỉnh sửa
            dgvReaders.Enabled = !isEditMode;
        }

        private void ClearInputs()
        {
            txtReaderID.Clear();
            txtReaderName.Clear();
            txtPhone.Clear();
            txtDept.Clear();
            txtEmail.Clear();
            dtpBirthDate.Value = DateTime.Today.AddYears(-18);
            dtpExpiryDate.Value = DateTime.Today.AddYears(4);
            if (cboGender.Items.Count > 0) cboGender.SelectedIndex = 0;
            if (cboStatus.Items.Count > 0) cboStatus.SelectedIndex = 0;
        }

        private void DisplaySelectedReader()
        {
            if (dgvReaders.SelectedRows.Count > 0 && dgvReaders.SelectedRows[0].Cells[0].Value != null)
            {
                DataGridViewRow row = dgvReaders.SelectedRows[0];
                txtReaderID.Text = row.Cells["Mã Độc Giả"].Value.ToString();
                txtReaderName.Text = row.Cells["Họ Tên"].Value.ToString();
                txtPhone.Text = row.Cells["Số Điện Thoại"].Value != DBNull.Value ? row.Cells["Số Điện Thoại"].Value.ToString() : "";
                
                if (row.Cells["Ngày Sinh"].Value != DBNull.Value && row.Cells["Ngày Sinh"].Value != null)
                    dtpBirthDate.Value = Convert.ToDateTime(row.Cells["Ngày Sinh"].Value);
                else
                    dtpBirthDate.Value = DateTime.Today;

                if (row.Cells["Giới Tính"].Value != null)
                {
                    string gioiTinhStr = row.Cells["Giới Tính"].Value.ToString();
                    cboGender.SelectedIndex = gioiTinhStr == "Nam" ? 0 : 1;
                }

                txtDept.Text = row.Cells["Khoa"].Value != DBNull.Value ? row.Cells["Khoa"].Value.ToString() : "";
                txtEmail.Text = row.Cells["Email"].Value != DBNull.Value ? row.Cells["Email"].Value.ToString() : "";

                if (row.Cells["Ngày Hết Hạn"].Value != DBNull.Value && row.Cells["Ngày Hết Hạn"].Value != null)
                    dtpExpiryDate.Value = Convert.ToDateTime(row.Cells["Ngày Hết Hạn"].Value);
                else
                    dtpExpiryDate.Value = DateTime.Today;

                if (row.Cells["Trạng Thái"].Value != null)
                {
                    string trangThaiStr = row.Cells["Trạng Thái"].Value.ToString();
                    cboStatus.SelectedIndex = trangThaiStr == "Hoạt động" ? 0 : 1;
                }
            }
            else
            {
                ClearInputs();
            }
        }

        private void DgvReaders_SelectionChanged(object sender, EventArgs e)
        {
            if (!_Them && !_Sua)
            {
                DisplaySelectedReader();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            _Them = true;
            _Sua = false;
            ClearInputs();
            SetState(true);
            txtReaderID.Focus();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvReaders.SelectedRows.Count == 0 || dgvReaders.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Vui lòng chọn độc giả cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Them = false;
            _Sua = true;
            SetState(true);
            txtReaderName.Focus();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _Them = false;
            _Sua = false;
            SetState(false);
            DisplaySelectedReader();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvReaders.SelectedRows.Count == 0 || dgvReaders.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Vui lòng chọn độc giả cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string readerId = dgvReaders.SelectedRows[0].Cells["Mã Độc Giả"].Value.ToString();
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa độc giả '{readerId}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_docGiaBLL.XoaDocGia(readerId))
                    {
                        MessageBox.Show("Xóa độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                DocGiaDTO reader = new DocGiaDTO
                {
                    MaDG = txtReaderID.Text.Trim(),
                    HoTen = txtReaderName.Text.Trim(),
                    NgaySinh = dtpBirthDate.Value,
                    GioiTinh = cboGender.SelectedIndex == 0,
                    Khoa = txtDept.Text.Trim(),
                    SDT = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    NgayHetHan = dtpExpiryDate.Value,
                    TrangThai = cboStatus.SelectedIndex == 0
                };

                if (_Them)
                {
                    if (_docGiaBLL.ThemDocGia(reader))
                    {
                        MessageBox.Show("Thêm mới độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (_Sua)
                {
                    if (_docGiaBLL.CapNhatDocGia(reader))
                    {
                        MessageBox.Show("Cập nhật thông tin độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
            }
            else
            {
                try
                {
                    dgvReaders.DataSource = _docGiaBLL.TimKiemDocGia(keyword);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
