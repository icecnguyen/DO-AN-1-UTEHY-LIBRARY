using System;
using System.Data;
using System.Windows.Forms;
using qltv.BLL;
using qltv.DTO;

namespace qltv
{
    public partial class QuanLyMuonTra : UserControl
    {
        private MuonTraBLL _muonTraBLL = new MuonTraBLL();
        private bool _Them = false;

        public QuanLyMuonTra()
        {
            InitializeComponent();
            this.Load += UCBorrowReturn_Load;
            btnBorrow.Click += BtnBorrow_Click;
            btnReturn.Click += BtnReturn_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            dgvLoans.SelectionChanged += DgvLoans_SelectionChanged;
            btnPrintBorrow.Click += BtnPrintBorrow_Click;
            btnPrintFine.Click += BtnPrintFine_Click;
        }

        private void UCBorrowReturn_Load(object sender, EventArgs e)
        {
            dgvLoans.ReadOnly = true;
            LoadData();
            SetState(false);
        }

        private void LoadData()
        {
            try
            {
                dgvLoans.DataSource = _muonTraBLL.LayTatCaPhieuMuon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách phiếu mượn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetState(bool isEditMode)
        {
            txtLoanID.ReadOnly = !isEditMode;
            txtBookID.ReadOnly = !isEditMode;
            txtReaderID.ReadOnly = !isEditMode;
            dtpBorrowDate.Enabled = isEditMode;
            dtpReturnDate.Enabled = isEditMode;

            btnSave.Enabled = isEditMode;
            btnCancel.Enabled = isEditMode;

            btnBorrow.Enabled = !isEditMode;
            btnReturn.Enabled = !isEditMode;
            txtSearch.Enabled = !isEditMode;

            dgvLoans.Enabled = !isEditMode;
        }

        private void ClearInputs()
        {
            txtLoanID.Clear();
            txtBookID.Clear();
            txtReaderID.Clear();
            dtpBorrowDate.Value = DateTime.Today;
            dtpReturnDate.Value = DateTime.Today.AddDays(14);
        }

        private void DisplaySelectedLoan()
        {
            if (dgvLoans.SelectedRows.Count > 0 && dgvLoans.SelectedRows[0].Cells[0].Value != null)
            {
                DataGridViewRow row = dgvLoans.SelectedRows[0];
                txtLoanID.Text = row.Cells["Mã Phiếu"].Value.ToString();
                txtBookID.Text = row.Cells["Mã Sách"].Value.ToString();
                txtReaderID.Text = row.Cells["Mã Độc Giả"].Value.ToString();
                dtpBorrowDate.Value = Convert.ToDateTime(row.Cells["Ngày Mượn"].Value);
                dtpReturnDate.Value = Convert.ToDateTime(row.Cells["Ngày Hẹn Trả"].Value);
            }
            else
            {
                ClearInputs();
            }
        }

        private void DgvLoans_SelectionChanged(object sender, EventArgs e)
        {
            if (!_Them)
            {
                DisplaySelectedLoan();
            }
        }

        private void BtnBorrow_Click(object sender, EventArgs e)
        {
            _Them = true;
            ClearInputs();
            SetState(true);
            txtLoanID.Focus();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            _Them = false;
            SetState(false);
            DisplaySelectedLoan();
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            if (dgvLoans.SelectedRows.Count == 0 || dgvLoans.SelectedRows[0].Cells[0].Value == null)
            {
                MessageBox.Show("Vui lòng chọn bản ghi mượn sách cần trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvLoans.SelectedRows[0];
            string maPhieu = row.Cells["Mã Phiếu"].Value.ToString();
            string maSach = row.Cells["Mã Sách"].Value.ToString();
            DateTime ngayHenTra = Convert.ToDateTime(row.Cells["Ngày Hẹn Trả"].Value);

            object ngayTraVal = row.Cells["Ngày Trả Thực Tế"].Value;
            if (ngayTraVal != DBNull.Value && ngayTraVal != null)
            {
                MessageBox.Show("Sách này đã được trả trước đó.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int tre = (DateTime.Today - ngayHenTra.Date).Days;
            decimal tienPhat = tre > 0 ? tre * 5000 : 0;

            string confirmMsg = $"Xác nhận trả sách '{maSach}' trong phiếu '{maPhieu}'?";
            if (tienPhat > 0)
            {
                confirmMsg += $"\nLưu ý: Độc giả trả trễ {tre} ngày. Số tiền phạt dự kiến: {tienPhat:N0} VND";
            }

            DialogResult result = MessageBox.Show(confirmMsg, "Xác nhận trả sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string tinhTrang = Prompt.ShowDialog("Nhập tình trạng sách khi trả (để trống nếu bình thường):", "Tình trạng sách khi trả", "Bình thường");
                if (tinhTrang == null)
                {
                    return; // User cancelled
                }

                try
                {
                    if (_muonTraBLL.TraSach(maPhieu, maSach, ngayHenTra, null, tinhTrang))
                    {
                        string successMsg = "Trả sách thành công!";
                        if (tienPhat > 0)
                        {
                            successMsg += $"\nĐã ghi nhận phí phạt trễ hạn: {tienPhat:N0} VND";
                        }
                        MessageBox.Show(successMsg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MuonTraDTO loan = new MuonTraDTO
                {
                    MaPhieu = txtLoanID.Text.Trim(),
                    MaDG = txtReaderID.Text.Trim(),
                    MaSach = txtBookID.Text.Trim(),
                    NgayMuon = dtpBorrowDate.Value,
                    NgayHenTra = dtpReturnDate.Value
                };

                if (_muonTraBLL.MuonSach(loan))
                {
                    MessageBox.Show("Lập phiếu mượn sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Them = false;
                    SetState(false);
                    LoadData();
                }
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
                    dgvLoans.DataSource = _muonTraBLL.TimKiemPhieuMuon(keyword);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnPrintBorrow_Click(object sender, EventArgs e)
        {
            string loanId = txtLoanID.Text.Trim();
            if (string.IsNullOrEmpty(loanId))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập mã phiếu mượn cần in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                FormXemIn viewer = new FormXemIn("phieu_muon", loanId);
                viewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo in: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrintFine_Click(object sender, EventArgs e)
        {
            string loanId = txtLoanID.Text.Trim();
            if (string.IsNullOrEmpty(loanId))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập mã phiếu mượn cần in biên lai phạt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                FormXemIn viewer = new FormXemIn("bien_lai_phat", loanId);
                viewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo in: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption, string defaultValue = "")
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Width = 350, Text = text };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 350, Text = defaultValue };
            Button confirmation = new Button() { Text = "Xác nhận", Left = 150, Width = 100, Top = 90, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Hủy bỏ", Left = 270, Width = 100, Top = 90, DialogResult = DialogResult.Cancel };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancel.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : null;
        }
    }
}
