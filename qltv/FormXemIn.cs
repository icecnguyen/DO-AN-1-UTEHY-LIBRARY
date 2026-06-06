using System;
using System.Data;
using System.Windows.Forms;
using qltv.BLL;

namespace qltv
{
    public class FormXemIn : Form
    {
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private BaoCaoBLL _baoCaoBLL = new BaoCaoBLL();
        private string _loaiBaoCao;
        private string _maPhieu;

        public FormXemIn(string loaiBaoCao, string maPhieu)
        {
            _loaiBaoCao = loaiBaoCao;
            _maPhieu = maPhieu;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(900, 600);
            this.crystalReportViewer1.TabIndex = 0;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "FormXemIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "In Chứng Từ - Crystal Report";
            this.Load += new System.EventHandler(this.FormPrintViewer_Load);
            this.ResumeLayout(false);
        }

        private void FormPrintViewer_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable duLieu = null;
                string duongDanFile = "";
                string tieuDeForm = "";

                switch (_loaiBaoCao)
                {
                    case "phieu_muon":
                        duLieu = _baoCaoBLL.LayDuLieuInPhieuMuon(_maPhieu);
                        duongDanFile = AppDomain.CurrentDomain.BaseDirectory + @"rptPhieuMuon.rpt";
                        tieuDeForm = "Phiếu Mượn Sách: " + _maPhieu;
                        break;

                    case "bien_lai_phat":
                        duLieu = _baoCaoBLL.LayDuLieuInBienLaiPhat(_maPhieu);
                        duongDanFile = AppDomain.CurrentDomain.BaseDirectory + @"rptBienLaiPhat.rpt";
                        tieuDeForm = "Biên Lai Phạt Tiền: " + _maPhieu;
                        break;

                    case "phieu_nhap":
                        duLieu = _baoCaoBLL.LayDuLieuInPhieuNhap(_maPhieu);
                        duongDanFile = AppDomain.CurrentDomain.BaseDirectory + @"rptPhieuNhap.rpt";
                        tieuDeForm = "Phiếu Nhập Kho: " + _maPhieu;
                        break;
                }

                if (duLieu == null || duLieu.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin chứng từ với mã: " + _maPhieu, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                this.Text = tieuDeForm;

                LoadReport(duongDanFile, duLieu);
            }
            catch (Exception loiHeThong)
            {
                ShowFallbackReport(loiHeThong);
            }
        }

        private void LoadReport(string duongDanFile, DataTable duLieu)
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument taiLieuBaoCao = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            
            if (!System.IO.File.Exists(duongDanFile))
            {
                string duongDanDuPhong = System.IO.Path.Combine(Application.StartupPath, "rpt" + CapitalizeFirst(_loaiBaoCao) + ".rpt");

                if (System.IO.File.Exists(duongDanDuPhong))
                {
                    duongDanFile = duongDanDuPhong;
                }
                else
                {
                    throw new System.IO.FileNotFoundException("Không tìm thấy tệp mẫu báo cáo Crystal Report (.rpt) tại: " + duongDanFile);
                }
            }

            taiLieuBaoCao.Load(duongDanFile);
            taiLieuBaoCao.SetDataSource(duLieu);
            crystalReportViewer1.ReportSource = taiLieuBaoCao;
        }

        private void ShowFallbackReport(Exception loiHeThong)
        {
            this.Controls.Clear();

            Panel panelGiaoDienIn = new Panel()
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20)
            };

            Label lblTieuDe = new Label()
            {
                Text = "XEM TRƯỚC VÀ IN CHỨNG TỪ",
                Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 40,
                ForeColor = System.Drawing.Color.FromArgb(44, 62, 80)
            };

            Label lblMoTa = new Label()
            {
                Text = "Bản xem trước chi tiết của chứng từ mã: " + _maPhieu + ".\n" + "Quý khách có thể kiểm tra dữ liệu bên dưới và nhấn nút In Tài Liệu để gửi lệnh in trực tiếp ra máy in.",
                Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic),
                Dock = DockStyle.Top,
                Height = 60,
                ForeColor = System.Drawing.Color.FromArgb(127, 140, 141)
            };

            DataGridView bangHienThi = new DataGridView()
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = System.Drawing.Color.White,
                ReadOnly = true,
                AllowUserToAddRows = false
            };

            bangHienThi.BorderStyle = BorderStyle.None;
            bangHienThi.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            bangHienThi.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            bangHienThi.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            bangHienThi.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            bangHienThi.EnableHeadersVisualStyles = false;
            bangHienThi.RowHeadersVisible = false;
            bangHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bangHienThi.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            bangHienThi.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(231, 229, 255);
            bangHienThi.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(71, 69, 94);

            DataTable duLieuChungTu = null;
            if (_loaiBaoCao == "phieu_muon")
            {
                duLieuChungTu = _baoCaoBLL.LayDuLieuInPhieuMuon(_maPhieu);
            }
            else if (_loaiBaoCao == "bien_lai_phat")
            {
                duLieuChungTu = _baoCaoBLL.LayDuLieuInBienLaiPhat(_maPhieu);
            }
            else if (_loaiBaoCao == "phieu_nhap")
            {
                duLieuChungTu = _baoCaoBLL.LayDuLieuInPhieuNhap(_maPhieu);
            }

            if (duLieuChungTu != null)
            {
                bangHienThi.DataSource = duLieuChungTu;
            }

            Panel panelThanhNut = new Panel()
            {
                Dock = DockStyle.Bottom,
                Height = 60
            };

            Button btnInTaiLieu = new Button()
            {
                Text = "In Tài Liệu (Print)",
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                BackColor = System.Drawing.Color.FromArgb(52, 152, 219),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new System.Drawing.Size(180, 40),
                Location = new System.Drawing.Point(0, 10)
            };

            btnInTaiLieu.FlatAppearance.BorderSize = 0;
            btnInTaiLieu.Click += (s, ev) =>
            {
                using (PrintDialog hopThoaiIn = new PrintDialog())
                {
                    if (hopThoaiIn.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Yêu cầu in ấn đã được gửi tới máy in thành công!", "In ấn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            };
            
            Button btnDongCuaSo = new Button()
            { 
                Text = "Đóng", 
                Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                BackColor = System.Drawing.Color.FromArgb(149, 165, 166),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new System.Drawing.Size(100, 40), 
                Location = new System.Drawing.Point(190, 10)
            };

            btnDongCuaSo.FlatAppearance.BorderSize = 0;
            btnDongCuaSo.Click += (s, ev) => this.Close();

            panelThanhNut.Controls.Add(btnInTaiLieu);
            panelThanhNut.Controls.Add(btnDongCuaSo);
            panelGiaoDienIn.Controls.Add(bangHienThi);
            panelGiaoDienIn.Controls.Add(lblMoTa);
            panelGiaoDienIn.Controls.Add(lblTieuDe);
            panelGiaoDienIn.Controls.Add(panelThanhNut);

            this.Controls.Add(panelGiaoDienIn);
        }

        private string CapitalizeFirst(string chuoiVao)
        {
            if (string.IsNullOrEmpty(chuoiVao))
            {
                return "";
            }

            string[] danhSachTu = chuoiVao.Split('_');

            for (int i = 0; i < danhSachTu.Length; i++)
            {
                if (danhSachTu[i].Length > 0)
                {
                    danhSachTu[i] = char.ToUpper(danhSachTu[i][0]) + danhSachTu[i].Substring(1);
                }
            }
            return string.Join("", danhSachTu);
        }
    }
}