using System;
using System.Data;
using System.Windows.Forms;
using qltv.BLL;
using qltv.DTO;

namespace qltv
{
    /// <summary>
    /// Giao diện UserControl quản lý danh mục sách (Thể loại sách)
    /// Hỗ trợ các chức năng: Xem danh sách, Thêm mới, Chỉnh sửa, Xóa và Tìm kiếm danh mục sách.
    /// </summary>
    public partial class QuanLyDanhMuc : UserControl
    {
        // Khởi tạo đối tượng BLL xử lý nghiệp vụ
        private DanhMucBLL _danhMucBLL = new DanhMucBLL();
        
        // Các cờ trạng thái kiểm soát hành vi Thêm hoặc Sửa dữ liệu
        private bool _Them = false;
        private bool _Sua = false;

        public QuanLyDanhMuc()
        {
            InitializeComponent();
            
            // Khởi tạo và đăng ký các sự kiện tương tác giao diện
            this.Load += UCQuanLyDanhMuc_Load;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            dgvDanhMuc.SelectionChanged += DgvDanhMuc_SelectionChanged;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        // Sự kiện Load Form: Thiết lập hiển thị dữ liệu ban đầu
        private void UCQuanLyDanhMuc_Load(object sender, EventArgs e)
        {
            dgvDanhMuc.ReadOnly = true; // Chỉ cho phép xem trên lưới dữ liệu, không sửa trực tiếp
            LoadData();                 // Gọi hàm tải dữ liệu từ CSDL
            SetState(false);            // Ban đầu khóa các ô nhập liệu, chỉ hiện nút chức năng chính
        }

        // Tải toàn bộ danh sách danh mục sách từ cơ sở dữ liệu lên DataGridView
        private void LoadData()
        {
            try
            {
                dgvDanhMuc.DataSource = _danhMucBLL.LayTatCaDanhMuc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thiết lập trạng thái kích hoạt (Enable/ReadOnly) của các nút và textbox nhập liệu
        // Thông số: True: Chế độ Thêm/Sửa (mở khóa textbox, khóa nút chức năng phụ), False: Chế độ Xem
        private void SetState(bool isEditMode)
        {
            txtMaDM.ReadOnly = !isEditMode || _Sua; // Khi đang sửa thì không cho thay đổi Mã danh mục
            txtTenDM.ReadOnly = !isEditMode;
            txtMoTa.ReadOnly = !isEditMode;

            btnSave.Enabled = isEditMode;   // Nút Lưu chỉ dùng khi ở chế độ chỉnh sửa
            btnCancel.Enabled = isEditMode; // Nút Hủy chỉ dùng khi ở chế độ chỉnh sửa

            btnAdd.Enabled = !isEditMode;    // Các nút chức năng chính chỉ dùng khi không chỉnh sửa
            btnEdit.Enabled = !isEditMode;
            btnDelete.Enabled = !isEditMode;

            dgvDanhMuc.Enabled = !isEditMode; // Khóa Grid view khi đang nhập liệu để tránh đổi dòng nửa chừng
            txtSearch.Enabled = !isEditMode;
        }

        // Làm sạch nội dung các ô textbox nhập liệu
        private void ClearInputs()
        {
            txtMaDM.Clear();
            txtTenDM.Clear();
            txtMoTa.Clear();
        }

        // Hiển thị thông tin của dòng danh mục đang được lựa chọn lên các ô nhập liệu
        private void HienThiDanhMucDaChon()
        {
            if (dgvDanhMuc.SelectedRows.Count > 0 && dgvDanhMuc.SelectedRows[0].Cells[0].Value != null)
            {
                DataGridViewRow row = dgvDanhMuc.SelectedRows[0];
                txtMaDM.Text = row.Cells["Mã Danh Mục"].Value.ToString();
                txtTenDM.Text = row.Cells["Tên Danh Mục"].Value.ToString();
                txtMoTa.Text = row.Cells["Mô Tả"].Value != DBNull.Value ? row.Cells["Mô Tả"].Value.ToString() : "";
            }
            else
            {
                ClearInputs();
            }
        }

        // Sự kiện khi người dùng chọn một dòng khác trên DataGridView
        private void DgvDanhMuc_SelectionChanged(object sender, EventArgs e)
        {
            if (!_Them && !_Sua)
            {
                HienThiDanhMucDaChon(); // Chỉ tự động điền thông tự khi không ở chế độ Thêm/Sửa
            }
        }

        // Sự kiện kích hoạt nút Thêm mới
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            _Them = true;
            _Sua = false;
            ClearInputs();
            SetState(true);
            txtMaDM.Focus(); // Con trỏ chuột tự động trỏ vào Mã danh mục
        }

        // Sự kiện kích hoạt nút Sửa thông tin
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDanhMuc.SelectedRows.Count == 0 || dgvDanhMuc.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _Them = false;
            _Sua = true;
            SetState(true);
            txtTenDM.Focus(); // Không sửa được mã, đưa con trỏ vào ô Tên danh mục để bắt đầu chỉnh sửa
        }

        // Sự kiện kích hoạt nút Hủy bỏ thao tác hiện tại
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _Them = false;
            _Sua = false;
            SetState(false);
            HienThiDanhMucDaChon(); // Trả lại thông tin ban đầu trước khi sửa/thêm
        }

        // Sự kiện kích hoạt nút Xóa danh mục
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDanhMuc.SelectedRows.Count == 0 || dgvDanhMuc.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maDM = dgvDanhMuc.SelectedRows[0].Cells["Mã Danh Mục"].Value.ToString();
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa danh mục '{maDM}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_danhMucBLL.XoaDanhMuc(maDM))
                    {
                        MessageBox.Show("Xóa danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Cập nhật lại Grid dữ liệu sau khi xóa
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Sự kiện kích hoạt nút Lưu (Thực thi nghiệp vụ Thêm hoặc Sửa đổi thông tin)
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Khởi tạo DTO chứa dữ liệu mới thu thập từ giao diện
                DanhMucDTO cat = new DanhMucDTO
                {
                    MaDM = txtMaDM.Text.Trim(),
                    TenDM = txtTenDM.Text.Trim(),
                    MoTa = txtMoTa.Text.Trim()
                };

                if (_Them)
                {
                    // Thực thi thêm mới danh mục
                    if (_danhMucBLL.ThemDanhMuc(cat))
                    {
                        MessageBox.Show("Thêm mới danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (_Sua)
                {
                    // Thực thi cập nhật thông tin
                    if (_danhMucBLL.CapNhatDanhMuc(cat))
                    {
                        MessageBox.Show("Cập nhật thông tin danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Trả về chế độ Xem bình thường sau khi Lưu thành công
                _Them = false;
                _Sua = false;
                SetState(false);
                LoadData(); // Tải lại danh sách
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tìm kiếm danh mục theo thời gian thực (Real-time Search) khi gõ phím
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadData(); // Nếu ô tìm kiếm rỗng thì hiện toàn bộ
            }
            else
            {
                try
                {
                    dgvDanhMuc.DataSource = _danhMucBLL.TimKiemDanhMuc(keyword); // Lọc theo từ khóa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

