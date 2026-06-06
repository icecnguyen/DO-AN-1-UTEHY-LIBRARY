using System;
using System.Data;
using System.Windows.Forms;
using qltv.BLL;
using qltv.DTO;

namespace qltv
{
    public partial class QuanLySach : UserControl
    {
        // Khởi tạo đối tượng BLL xử lý nghiệp vụ
        private SachBLL _sachBLL = new SachBLL();
        private DanhMucBLL _danhMucBLL = new DanhMucBLL();
        
        // Các cờ trạng thái kiểm soát hành vi Thêm hoặc Sửa dữ liệu
        private bool _Them = false;
        private bool _Sua = false;

        public QuanLySach()
        {
            InitializeComponent();
            
            // Khởi tạo và đăng ký các sự kiện tương tác giao diện
            this.Load += UCQuanLySach_Load;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            dgvBooks.SelectionChanged += DgvBooks_SelectionChanged;
        }

        // Sự kiện xảy ra khi UserControl bắt đầu tải giao diện
        private void UCQuanLySach_Load(object sender, EventArgs e)
        {
            dgvBooks.ReadOnly = true; // Khóa lưới dữ liệu, chỉ cho phép xem
            LoadData();               // Gọi hàm hiển thị toàn bộ danh sách sách
            LoadCategories();         // Gọi hàm tải danh mục sách vào Combobox
            SetState(false);          // Ban đầu chỉ hiển thị, khóa chỉnh sửa
        }

        // Nạp danh mục thể loại sách từ cơ sở dữ liệu vào ComboBox danh mục
        private void LoadCategories()
        {
            try
            {
                cboDanhMuc.DataSource = _danhMucBLL.LayTatCaDanhMuc();
                cboDanhMuc.DisplayMember = "Tên Danh Mục"; // Cột dữ liệu hiển thị chữ cho người dùng xem
                cboDanhMuc.ValueMember = "Mã Danh Mục";    // Giá trị khóa chính (Mã danh mục) ẩn phía sau
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tải toàn bộ danh sách sách hiện có từ cơ sở dữ liệu lên DataGridView
        private void LoadData()
        {
            try
            {
                dgvBooks.DataSource = _sachBLL.LayTatCaSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thiết lập trạng thái ReadOnly của các ô nhập liệu và cho phép/khóa các nút chức năng
        // Thông số: True: Đang chỉnh sửa (Thêm/Sửa), False: Chỉ xem
        private void SetState(bool isEditMode)
        {
            txtBookID.Enabled = isEditMode && _Them; // Chỉ cho phép nhập mã sách khi thêm mới, sửa sách thì khóa mã
            txtBookName.ReadOnly = !isEditMode;
            txtAuthor.ReadOnly = !isEditMode;
            txtPublisher.ReadOnly = !isEditMode;
            txtPubYear.ReadOnly = !isEditMode;
            cboDanhMuc.Enabled = isEditMode;
            txtPrice.ReadOnly = !isEditMode;
            txtQuantity.ReadOnly = !isEditMode;

            btnSave.Enabled = isEditMode;   // Nút Lưu chỉ sáng khi ở chế độ chỉnh sửa
            btnCancel.Enabled = isEditMode; // Nút Hủy chỉ sáng khi ở chế độ chỉnh sửa

            btnAdd.Enabled = !isEditMode;    // Khóa các nút chức năng chính khi đang nhập liệu
            btnEdit.Enabled = !isEditMode;
            btnDelete.Enabled = !isEditMode;
            txtSearch.Enabled = !isEditMode;

            dgvBooks.Enabled = !isEditMode;  // Khóa lưới dữ liệu để người dùng tránh click đổi dòng khi đang nhập
        }

        // Làm sạch các ô thông tin nhập liệu để chuẩn bị cho lượt nhập mới
        private void ClearInputs()
        {
            txtBookID.Clear();
            txtBookName.Clear();
            txtAuthor.Clear();
            txtPublisher.Clear();
            txtPubYear.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            if (cboDanhMuc.Items.Count > 0) cboDanhMuc.SelectedIndex = 0;
        }

        // Lấy thông tin sách đang được click chọn trên lưới và đưa lên các ô textbox tương ứng
        private void DisplaySelectedBook()
        {
            if (dgvBooks.SelectedRows.Count > 0 && dgvBooks.SelectedRows[0].Cells[0].Value != null)
            {
                DataGridViewRow row = dgvBooks.SelectedRows[0];
                txtBookID.Text = row.Cells["Mã Sách"].Value.ToString();
                txtBookName.Text = row.Cells["Tên Sách"].Value.ToString();
                txtAuthor.Text = row.Cells["Tác Giả"].Value != DBNull.Value ? row.Cells["Tác Giả"].Value.ToString() : "";
                txtPublisher.Text = row.Cells["Nhà XB"].Value != DBNull.Value ? row.Cells["Nhà XB"].Value.ToString() : "";
                txtPubYear.Text = row.Cells["Năm XB"].Value != DBNull.Value ? row.Cells["Năm XB"].Value.ToString() : "";
                txtPrice.Text = row.Cells["Giá Sách"].Value != DBNull.Value ? row.Cells["Giá Sách"].Value.ToString() : "";
                txtQuantity.Text = row.Cells["Số Lượng Tồn"].Value.ToString();
                if (row.Cells["Mã DM"].Value != DBNull.Value && row.Cells["Mã DM"].Value != null)
                {
                    cboDanhMuc.SelectedValue = row.Cells["Mã DM"].Value.ToString();
                }
            }
            else
            {
                ClearInputs();
            }
        }

        // Sự kiện xảy ra khi người dùng thay đổi dòng chọn trên DataGridView
        private void DgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (!_Them && !_Sua)
            {
                DisplaySelectedBook();
            }
        }

        // Sự kiện click nút Thêm sách mới
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            _Them = true;
            _Sua = false;
            ClearInputs();
            SetState(true);
            txtBookID.Focus(); // Tự động đưa con trỏ nhập liệu vào ô Mã sách
        }

        // Sự kiện click nút Chỉnh sửa sách
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0 || dgvBooks.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Vui lòng chọn quyển sách cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _Them = false;
            _Sua = true;
            SetState(true);
            txtBookName.Focus(); // Đưa con trỏ nhập liệu vào ô Tên sách (Mã sách đã bị khóa không cho sửa)
        }

        // Sự kiện click nút Hủy bỏ thao tác chỉnh sửa hiện tại
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _Them = false;
            _Sua = false;
            SetState(false);
            DisplaySelectedBook(); // Điền lại thông tin cũ trước khi sửa
        }

        // Sự kiện click nút Xóa quyển sách được chọn
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count == 0 || dgvBooks.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Vui lòng chọn quyển sách cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string bookId = dgvBooks.SelectedRows[0].Cells["Mã Sách"].Value.ToString();
            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sách '{bookId}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_sachBLL.XoaSach(bookId))
                    {
                        MessageBox.Show("Xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Nạp lại bảng danh sách sách sau khi xóa thành công
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Sự kiện click nút Lưu để thực thi việc Thêm hoặc Sửa quyển sách
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra định dạng số lượng tồn nhập vào
                if (!int.TryParse(txtQuantity.Text.Trim(), out int qty) || qty < 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên không âm hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra định dạng năm xuất bản (nếu có nhập)
                int pubYear = 0;
                if (!string.IsNullOrEmpty(txtPubYear.Text.Trim()))
                {
                    if (!int.TryParse(txtPubYear.Text.Trim(), out pubYear) || pubYear <= 0)
                    {
                        MessageBox.Show("Năm xuất bản phải là số nguyên dương hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Kiểm tra định dạng đơn giá (nếu có nhập)
                decimal price = 0;
                if (!string.IsNullOrEmpty(txtPrice.Text.Trim()))
                {
                    if (!decimal.TryParse(txtPrice.Text.Trim(), out price) || price < 0)
                    {
                        MessageBox.Show("Giá sách phải là số dương hợp lệ.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Khởi tạo DTO SachDTO đóng gói thông tin để chuyển sang tầng nghiệp vụ BLL
                SachDTO book = new SachDTO
                {
                    MaSach = txtBookID.Text.Trim(),
                    TenSach = txtBookName.Text.Trim(),
                    TacGia = txtAuthor.Text.Trim(),
                    NhaXB = txtPublisher.Text.Trim(),
                    NamXB = pubYear,
                    GiaSach = price,
                    SoLuongTon = qty,
                    MaDM = cboDanhMuc.SelectedValue != null ? cboDanhMuc.SelectedValue.ToString() : null
                };

                if (_Them)
                {
                    // Thực thi thêm mới sách
                    if (_sachBLL.ThemSach(book))
                    {
                        MessageBox.Show("Thêm mới sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (_Sua)
                {
                    // Thực thi cập nhật sách
                    if (_sachBLL.CapNhatSach(book))
                    {
                        MessageBox.Show("Cập nhật thông tin sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Lưu thành công thì đưa form về trạng thái Xem bình thường
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

        // Sự kiện tìm kiếm sách khi gõ từ khóa (Real-time Search)
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData(); // Ô tìm kiếm trống -> Hiện toàn bộ
            }
            else
            {
                try
                {
                    dgvBooks.DataSource = _sachBLL.TimKiemSach(keyword); // Gọi BLL tìm sách theo từ khóa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
