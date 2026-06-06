using System;
using System.Windows.Forms;
using qltv.BLL;

namespace qltv
{
    public partial class DangNhap : Form
    {
        private TaiKhoanBLL _taiKhoanBLL = new TaiKhoanBLL();

        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text; // Truy xuất mật khẩu nguyên bản từ trường nhập liệu

                int role;
                string employeeId;

                if (_taiKhoanBLL.DangNhap(username, password, out role, out employeeId))
                {
                    PhienLamViec.Username = username;
                    PhienLamViec.Role = role;
                    PhienLamViec.EmployeeID = employeeId;

                    this.Hide();
                    TrangChu homeForm = new TrangChu();
                    homeForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
