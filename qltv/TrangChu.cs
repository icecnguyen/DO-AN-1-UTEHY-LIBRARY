using System;
using System.Windows.Forms;

namespace qltv
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
            CheckAuthorization();
        }

        private void CheckAuthorization()
        {
            if (PhienLamViec.Role == 2)
            {
                btnEmployees.FillColor = System.Drawing.Color.FromArgb(189, 195, 199);
                btnEmployees.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            }
        }

        private void LoadUC(UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void btnBooks_Click(object sender, EventArgs e) => LoadUC(new QuanLySach());
        private void btnReaders_Click(object sender, EventArgs e) => LoadUC(new QuanLyDocGia());
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            if (PhienLamViec.Role == 2)
            {
                MessageBox.Show("Bạn không đủ quyền hạn để truy cập mục Quản lý Nhân viên!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadUC(new QuanLyNhanVien());
        }
        private void btnCategories_Click(object sender, EventArgs e) => LoadUC(new QuanLyDanhMuc());
        private void btnSuppliers_Click(object sender, EventArgs e) => LoadUC(new QuanLyNhaCungCap());
        private void btnBorrowReturn_Click(object sender, EventArgs e) => LoadUC(new QuanLyMuonTra());
        private void btnBookImport_Click(object sender, EventArgs e) => LoadUC(new QuanLyNhapSach());
        private void btnReports_Click(object sender, EventArgs e) => LoadUC(new QuanLyBaoCao());
    }
}
