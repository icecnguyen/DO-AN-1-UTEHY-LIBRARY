using System;
using System.Data;
using System.Windows.Forms;
using qltv.BLL;

namespace qltv
{
    public partial class QuanLyBaoCao : UserControl
    {
        private BaoCaoBLL _baoCaoBLL = new BaoCaoBLL();

        public QuanLyBaoCao()
        {
            InitializeComponent();
            this.Load += UCReports_Load;
            btnGenerate.Click += BtnGenerate_Click;
            btnExportExcel.Click += BtnExportExcel_Click;
            btnPrintBorrow.Click += BtnPrintBorrow_Click;
            btnPrintFine.Click += BtnPrintFine_Click;
            btnPrintImport.Click += BtnPrintImport_Click;
        }

        private void UCReports_Load(object sender, EventArgs e)
        {
            PopulateReportTypes();
        }

        private void PopulateReportTypes()
        {
            cmbReportType.Items.Clear();
            cmbReportType.Items.Add("Tổng quan kho");
            cmbReportType.Items.Add("Sách sắp hết (<= 5)");
            cmbReportType.Items.Add("Sách theo danh mục");
            cmbReportType.Items.Add("Thẻ hết hạn");
            cmbReportType.Items.Add("Độc giả bị cấm mượn");
            cmbReportType.Items.Add("Số sách quá hạn chưa trả");
            cmbReportType.Items.Add("Sách được mượn nhiều nhất (top 10)");
            cmbReportType.Items.Add("Báo cáo doanh thu tiền phạt");
            cmbReportType.Items.Add("Chi phí nhập sách");

            if (cmbReportType.Items.Count > 0)
            {
                cmbReportType.SelectedIndex = 0;
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedItem == null) return;

            try
            {
                DateTime fromDate = dtpFromDate.Value;
                DateTime toDate = dtpToDate.Value;
                string selectedReport = cmbReportType.SelectedItem.ToString();

                // Kiểm tra phân quyền truy cập cho cấp nhân viên/thủ thư
                if (PhienLamViec.Role != 1 && (selectedReport == "Báo cáo doanh thu tiền phạt" || selectedReport == "Chi phí nhập sách"))
                {
                    MessageBox.Show("Bạn không đủ quyền hạn để truy cập báo cáo này!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                switch (selectedReport)
                {
                    case "Tổng quan kho":
                        dgvReports.DataSource = _baoCaoBLL.LayTongQuanKho();
                        break;
                    case "Sách sắp hết (<= 5)":
                        dgvReports.DataSource = _baoCaoBLL.LaySachSapHet();
                        break;
                    case "Sách theo danh mục":
                        dgvReports.DataSource = _baoCaoBLL.LaySachTheoDanhMuc();
                        break;
                    case "Thẻ hết hạn":
                        dgvReports.DataSource = _baoCaoBLL.LayTheHetHan();
                        break;
                    case "Độc giả bị cấm mượn":
                        dgvReports.DataSource = _baoCaoBLL.LayDocGiaBiCam();
                        break;
                    case "Số sách quá hạn chưa trả":
                        dgvReports.DataSource = _baoCaoBLL.LaySachQuaHan();
                        break;
                    case "Sách được mượn nhiều nhất (top 10)":
                        dgvReports.DataSource = _baoCaoBLL.LayTopSachMuonNhieuNhat(fromDate, toDate);
                        break;
                    case "Báo cáo doanh thu tiền phạt":
                        dgvReports.DataSource = _baoCaoBLL.LayDoanhThuTienPhat(fromDate, toDate);
                        break;
                    case "Chi phí nhập sách":
                        dgvReports.DataSource = _baoCaoBLL.LayChiPhiNhapSach(fromDate, toDate);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedItem != null)
            {
                string selectedReport = cmbReportType.SelectedItem.ToString();
                if (PhienLamViec.Role != 1 && (selectedReport == "Báo cáo doanh thu tiền phạt" || selectedReport == "Chi phí nhập sách"))
                {
                    MessageBox.Show("Bạn không đủ quyền hạn để xuất báo cáo này!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            ExportToExcel(dgvReports);
        }

        private void ExportToExcel(DataGridView dgv)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook (*.xls)|*.xls";
                sfd.FileName = "BaoCao_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                        {
                            sw.WriteLine("<html xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\">");
                            sw.WriteLine("<head><meta http-equiv=Content-Type content=\"text/html; charset=utf-8\"></head>");
                            sw.WriteLine("<body>");
                            sw.WriteLine("<table border='1' style='border-collapse:collapse;'>");

                            // Headers
                            sw.WriteLine("  <tr style='background-color:#2c3e50; color:#ffffff; font-weight:bold;'>");
                            foreach (DataGridViewColumn col in dgv.Columns)
                            {
                                if (col.Visible)
                                {
                                    sw.WriteLine($"    <th style='padding:5px;'>{col.HeaderText}</th>");
                                }
                            }
                            sw.WriteLine("  </tr>");

                            // Data rows
                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                if (row.IsNewRow) continue;
                                sw.WriteLine("  <tr>");
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.OwningColumn.Visible)
                                    {
                                        string value = cell.Value != null ? cell.Value.ToString() : "";
                                        value = value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
                                        sw.WriteLine($"    <td style='padding:5px;'>{value}</td>");
                                    }
                                }
                                sw.WriteLine("  </tr>");
                            }

                            sw.WriteLine("</table>");
                            sw.WriteLine("</body>");
                            sw.WriteLine("</html>");
                        }
                        MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnPrintBorrow_Click(object sender, EventArgs e)
        {
            PrintReport("phieu_muon", txtDocID.Text.Trim());
        }

        private void BtnPrintFine_Click(object sender, EventArgs e)
        {
            PrintReport("bien_lai_phat", txtDocID.Text.Trim());
        }

        private void BtnPrintImport_Click(object sender, EventArgs e)
        {
            PrintReport("phieu_nhap", txtDocID.Text.Trim());
        }

        private void PrintReport(string type, string docId)
        {
            if (string.IsNullOrEmpty(docId))
            {
                MessageBox.Show("Vui lòng nhập Mã phiếu/Biên lai cần in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                FormXemIn viewer = new FormXemIn(type, docId);
                viewer.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo in ấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
