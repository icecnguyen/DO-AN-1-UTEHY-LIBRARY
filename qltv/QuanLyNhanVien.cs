using System;
using System.Data;
using System.Windows.Forms;
using qltv.BLL;
using qltv.DTO;

namespace qltv
{
    public partial class QuanLyNhanVien : UserControl
    {
        // Khởi tạo đối tượng BLL xử lý nghiệp vụ
        private NhanVienBLL _nhanVienBLL = new NhanVienBLL();
        
        // Các cờ trạng thái kiểm soát hành vi Thêm hoặc Sửa dữ liệu
        private bool _Them = false;
        private bool _Sua = false;

        public QuanLyNhanVien()
        {
            InitializeComponent();
            
            // Khởi tạo và đăng ký các sự kiện tương tác giao diện
            this.Load += UCEmployees_Load;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            dgvEmployees.SelectionChanged += DgvEmployees_SelectionChanged;
            chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
        }

        // Xử lý sự kiện hiển thị mật khẩu dạng văn bản rõ
        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Thay đổi ký tự ẩn mật khẩu dựa trên trạng thái CheckBox
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }

        // Xử lý sự kiện Load Form: Khởi tạo dữ liệu ban đầu
        private void UCEmployees_Load(object sender, EventArgs e)
        {
            // Kiểm tra phân quyền truy cập chức năng Quản trị hệ thống
            if (PhienLamViec.Role != 1)
            {
                MessageBox.Show("Bạn không có quyền truy cập vào chức năng Quản lý Nhân viên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Visible = false;
                return;
            }
            
            // Vô hiệu hóa tính năng chỉnh sửa trực tiếp trên DataGridView
            dgvEmployees.ReadOnly = true;
            
            // Nạp dữ liệu từ cơ sở dữ liệu
            LoadData();
            
            // Thiết lập trạng thái ban đầu: Khóa các điều khiển nhập liệu
            SetState(false);
        }

        // Tải toàn bộ danh sách lên giao diện DataGridView
        private void LoadData()
        {
            try
            {
                dgvEmployees.DataSource = _nhanVienBLL.LayTatCaNhanVien();
                
                // Ẩn cột mật khẩu để đảm bảo tính bảo mật dữ liệu
                if (dgvEmployees.Columns["Mật Khẩu"] != null)
                {
                    dgvEmployees.Columns["Mật Khẩu"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thay đổi trạng thái khóa/mở khóa của các điều khiển nhập liệu
        private void SetState(bool isEditMode)
        {
            // Trường Mã chỉ cho phép nhập khi ở chế độ Thêm mới
            txtEmployeeID.ReadOnly = !(isEditMode && _Them);
            
            // Mở khóa các trường thông tin khi kích hoạt chế độ chỉnh sửa
            txtFullName.ReadOnly = !isEditMode;
            dtpBirthDate.Enabled = isEditMode;
            cboGender.Enabled = isEditMode;
            txtPhone.ReadOnly = !isEditMode;
            txtCCCD.ReadOnly = !isEditMode;
            txtEmail.ReadOnly = !isEditMode;
            txtAddress.ReadOnly = !isEditMode;
            dtpJoinDate.Enabled = isEditMode;
            
            // Xử lý logic hiển thị trường Tài khoản
            if (_Them)
            {
                txtUsername.ReadOnly = !isEditMode;
            }
            else
            {
                // Ngăn chặn chỉnh sửa tên tài khoản đối với quản trị viên cấp cao
                string currentUsername = txtUsername.Text.Trim();
                if (currentUsername.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    txtUsername.ReadOnly = true;
                }
                else
                {
                    txtUsername.ReadOnly = !isEditMode;
                }
            }
            
            txtPassword.ReadOnly = !isEditMode;
            chkShowPassword.Enabled = isEditMode;

            // Cập nhật trạng thái các phím chức năng tương ứng với chế độ làm việc
            btnSave.Enabled = isEditMode;
            btnCancel.Enabled = isEditMode;

            btnAdd.Enabled = !isEditMode;
            btnEdit.Enabled = !isEditMode;
            btnDelete.Enabled = !isEditMode;
            txtSearch.Enabled = !isEditMode;

            // Vô hiệu hóa lựa chọn dòng trên DataGridView khi đang ở chế độ chỉnh sửa
            dgvEmployees.Enabled = !isEditMode;
        }

        // Xóa dữ liệu hiển thị trên các điều khiển nhập liệu
        private void ClearInputs()
        {
            txtEmployeeID.Clear();
            txtFullName.Clear();
            dtpBirthDate.Value = DateTime.Today.AddYears(-20); // Mặc định để tuổi là 20 cho hợp lý
            cboGender.SelectedIndex = 0;
            txtPhone.Clear();
            txtCCCD.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            dtpJoinDate.Value = DateTime.Today;
            txtUsername.Clear();
            txtPassword.Clear();
            chkShowPassword.Checked = false;
        }

        // Đồng bộ hóa dữ liệu từ dòng được chọn trên lưới xuống các trường nhập liệu
        private void DisplaySelectedEmployee()
        {
            if (dgvEmployees.SelectedRows.Count > 0 && dgvEmployees.SelectedRows[0].Cells[0].Value != null)
            {
                DataGridViewRow row = dgvEmployees.SelectedRows[0];
                txtEmployeeID.Text = row.Cells["Mã NV"].Value.ToString();
                txtFullName.Text = row.Cells["Họ Tên"].Value.ToString();
                
                // Xử lý ngoại lệ đối với dữ liệu ngày sinh có thể mang giá trị NULL
                if (row.Cells["Ngày Sinh"].Value != DBNull.Value && row.Cells["Ngày Sinh"].Value != null)
                {
                    dtpBirthDate.Value = Convert.ToDateTime(row.Cells["Ngày Sinh"].Value);
                }
                else
                {
                    dtpBirthDate.Value = DateTime.Today.AddYears(-20);
                }

                if (row.Cells["Giới Tính"].Value != DBNull.Value && row.Cells["Giới Tính"].Value != null)
                {
                    cboGender.SelectedIndex = (row.Cells["Giới Tính"].Value.ToString() == "Nam") ? 0 : 1;
                }
                else
                {
                    cboGender.SelectedIndex = 0;
                }

                txtPhone.Text = row.Cells["Số Điện Thoại"].Value != DBNull.Value ? row.Cells["Số Điện Thoại"].Value.ToString() : "";
                txtCCCD.Text = row.Cells["CCCD"].Value != DBNull.Value ? row.Cells["CCCD"].Value.ToString() : "";
                txtEmail.Text = row.Cells["Email"].Value != DBNull.Value ? row.Cells["Email"].Value.ToString() : "";
                txtAddress.Text = row.Cells["Địa Chỉ"].Value != DBNull.Value ? row.Cells["Địa Chỉ"].Value.ToString() : "";

                if (row.Cells["Ngày Vào Làm"].Value != DBNull.Value && row.Cells["Ngày Vào Làm"].Value != null)
                {
                    dtpJoinDate.Value = Convert.ToDateTime(row.Cells["Ngày Vào Làm"].Value);
                }
                else
                {
                    dtpJoinDate.Value = DateTime.Today;
                }

                txtUsername.Text = row.Cells["Tài Khoản"].Value != DBNull.Value ? row.Cells["Tài Khoản"].Value.ToString() : "";
                txtPassword.Text = row.Cells["Mật Khẩu"].Value != DBNull.Value ? row.Cells["Mật Khẩu"].Value.ToString() : "";
            }
            else
            {
                ClearInputs(); // Làm sạch form khi không có dòng hợp lệ nào được chọn
            }
        }

        // Xử lý sự kiện thay đổi lựa chọn dòng trên DataGridView
        private void DgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            // Hạn chế đồng bộ dữ liệu khi đang trong tiến trình Thêm hoặc Sửa
            if (!_Them && !_Sua)
            {
                DisplaySelectedEmployee();
            }
        }

        // Xử lý sự kiện kích hoạt nút Thêm mới
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            _Them = true;
            _Sua = false;
            ClearInputs();
            SetState(true);
            txtEmployeeID.Focus(); // Đặt tiêu điểm vào ô nhập liệu đầu tiên
        }

        // Xử lý sự kiện kích hoạt nút Chỉnh sửa
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            // Xác thực điều kiện lựa chọn dữ liệu trước khi thực thi
            if (dgvEmployees.SelectedRows.Count == 0 || dgvEmployees.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Them = false;
            _Sua = true;
            SetState(true);
            txtFullName.Focus(); // Đặt tiêu điểm vào ô hợp lệ
        }

        // Xử lý sự kiện kích hoạt nút Hủy thao tác
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _Them = false;
            _Sua = false;
            SetState(false);
            DisplaySelectedEmployee(); // Khôi phục hiển thị dữ liệu gốc khi Hủy thao tác
        }

        // Xử lý sự kiện kích hoạt nút Xóa dữ liệu
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0 || dgvEmployees.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvEmployees.SelectedRows[0];
            string employeeId = row.Cells["Mã NV"].Value.ToString();
            string username = row.Cells["Tài Khoản"].Value != DBNull.Value ? row.Cells["Tài Khoản"].Value.ToString() : "";

            // Ngăn chặn rủi ro vô tình xóa tài khoản quản trị hệ thống
            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không thể xóa tài khoản admin hệ thống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại xác nhận hành động xóa dữ liệu
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên '{employeeId}' và tài khoản liên kết không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_nhanVienBLL.XoaNhanVien(employeeId, username))
                    {
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Làm mới lại danh sách sau khi thao tác thành công
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Xử lý sự kiện kích hoạt nút Lưu thông tin
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo đối tượng DTO và thu thập thông tin từ giao diện
                NhanVienDTO emp = new NhanVienDTO
                {
                    MaNV = txtEmployeeID.Text.Trim(),
                    HoTen = txtFullName.Text.Trim(),
                    NgaySinh = dtpBirthDate.Value,
                    GioiTinh = cboGender.SelectedIndex == 0,
                    SDT = txtPhone.Text.Trim(),
                    CCCD = txtCCCD.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    DiaChi = txtAddress.Text.Trim(),
                    NgayVaoLam = dtpJoinDate.Value,
                    TenTK = txtUsername.Text.Trim(),
                    MatKhau = txtPassword.Text
                };

                if (_Them)
                {
                    // Gọi hàm thực thi nghiệp vụ Thêm mới
                    if (_nhanVienBLL.ThemNhanVien(emp))
                    {
                        MessageBox.Show("Thêm mới nhân viên và tạo tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (_Sua)
                {
                    // Gọi hàm thực thi nghiệp vụ Cập nhật thông tin
                    if (_nhanVienBLL.CapNhatNhanVien(emp))
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Thiết lập lại trạng thái form sau khi hoàn tất giao dịch
                _Them = false;
                _Sua = false;
                SetState(false);
                LoadData();
            }
            catch (Exception ex)
            {
                // Bắt và hiển thị các ngoại lệ nghiệp vụ phát sinh từ BLL
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xử lý sự kiện tìm kiếm dữ liệu theo thời gian thực (Real-time Search)
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                // Khôi phục danh sách gốc khi ô tìm kiếm rỗng
                LoadData();
            }
            else
            {
                try
                {
                    dgvEmployees.DataSource = _nhanVienBLL.TimKiemNhanVien(keyword);
                    // Đảm bảo tính bảo mật mật khẩu trong kết quả tìm kiếm
                    if (dgvEmployees.Columns["Mật Khẩu"] != null)
                    {
                        dgvEmployees.Columns["Mật Khẩu"].Visible = false;
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
