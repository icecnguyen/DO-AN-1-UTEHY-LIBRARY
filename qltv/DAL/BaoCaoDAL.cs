using System;
using System.Data;
using System.Data.SqlClient;

namespace qltv.DAL
{
    public class BaoCaoDAL
    {
        // 1. Tổng quan kho
        public DataTable LayTongQuanKho()
        {
            string query = @"
                SELECT
                    dm.ma_dm AS [Mã Danh Mục],
                    dm.ten_dm AS [Tên Danh Mục],
                    COUNT(s.ma_sach) AS [Số Đầu Sách],
                    SUM(ISNULL(s.so_luong_ton, 0)) AS [Tổng Số Lượng Tồn],
                    SUM(ISNULL(s.so_luong_ton, 0) * ISNULL(s.gia_sach, 0)) AS [Tổng Giá Trị]
                FROM danh_muc dm
                LEFT JOIN sach s ON dm.ma_dm = s.ma_dm
                GROUP BY dm.ma_dm, dm.ten_dm";

            return DbHelper.GetData(query);
        }

        // 2. Sách sắp hết (tồn <= 5)
        public DataTable LaySachSapHet()
        {
            string query = @"
                SELECT
                    s.ma_sach AS [Mã Sách],
                    s.ten_sach AS [Tên Sách],
                    s.tac_gia AS [Tác Giả],
                    dm.ten_dm AS [Danh Mục],
                    s.so_luong_ton AS [Số Lượng Tồn],
                    s.gia_sach AS [Giá Sách]
                FROM sach s
                LEFT JOIN danh_muc dm ON s.ma_dm = dm.ma_dm
                WHERE s.so_luong_ton <= 5
                ORDER BY s.so_luong_ton ASC";

            return DbHelper.GetData(query);
        }

        // 3. Sách theo danh mục
        public DataTable LaySachTheoDanhMuc()
        {
            string query = @"
                SELECT
                    dm.ten_dm AS [Tên Danh Mục],
                    s.ma_sach AS [Mã Sách],
                    s.ten_sach AS [Tên Sách],
                    s.tac_gia AS [Tác Giả],
                    s.nha_xb AS [Nhà Xuất Bản],
                    s.so_luong_ton AS [Số Lượng Tồn],
                    s.gia_sach AS [Giá Sách]
                FROM sach s
                INNER JOIN danh_muc dm ON s.ma_dm = dm.ma_dm
                ORDER BY dm.ten_dm, s.ten_sach";

            return DbHelper.GetData(query);
        }

        // 4. Thẻ hết hạn
        public DataTable LayTheHetHan()
        {
            string query = @"
                SELECT
                    ma_dg AS [Mã Độc Giả],
                    ho_ten AS [Tên Độc Giả],
                    sdt AS [Số Điện Thoại],
                    email AS [Email],
                    ngay_het_han AS [Ngày Hết Hạn],
                    CASE WHEN trang_thai = 1 THEN N'Hoạt động' ELSE N'Khóa' END AS [Trạng Thái]
                FROM doc_gia
                WHERE ngay_het_han <= GETDATE()
                ORDER BY ngay_het_han ASC";

            return DbHelper.GetData(query);
        }

        // 5. Độc giả bị cấm mượn
        public DataTable LayDocGiaBiCam()
        {
            string query = @"
                SELECT
                    ma_dg AS [Mã Độc Giả],
                    ho_ten AS [Tên Độc Giả],
                    sdt AS [Số Điện Thoại],
                    email AS [Email],
                    ngay_het_han AS [Ngày Hết Hạn],
                    N'Bị Cấm' AS [Trạng Thái]
                FROM doc_gia
                WHERE trang_thai = 0
                ORDER BY ho_ten ASC";

            return DbHelper.GetData(query);
        }

        // 6. Số sách quá hạn chưa trả
        public DataTable LaySachQuaHan(DateTime currentDate)
        {
            string query = @"
                SELECT 
                    ct.ma_phieu AS [Mã Phiếu],
                    dg.ma_dg AS [Mã Độc Giả],
                    dg.ho_ten AS [Tên Độc Giả],
                    s.ma_sach AS [Mã Sách],
                    s.ten_sach AS [Tên Sách],
                    ct.ngay_hen_tra AS [Ngày Hẹn Trả],
                    DATEDIFF(day, ct.ngay_hen_tra, @CurrentDate) AS [Số Ngày Trễ]
                FROM chi_tiet_muon_tra ct
                JOIN phieu_muon_tra p ON ct.ma_phieu = p.ma_phieu
                JOIN doc_gia dg ON p.ma_dg = dg.ma_dg
                JOIN sach s ON ct.ma_sach = s.ma_sach
                WHERE ct.ngay_tra_thuc_te IS NULL AND ct.ngay_hen_tra < @CurrentDate
                ORDER BY [Số Ngày Trễ] DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CurrentDate", currentDate)
            };

            return DbHelper.GetData(query, parameters);
        }

        // 7. Sách được mượn nhiều nhất (top 10)
        public DataTable LayTopSachMuon(DateTime fromDate, DateTime toDate)
        {
            string query = @"
                SELECT TOP 10
                    s.ma_sach AS [Mã Sách],
                    s.ten_sach AS [Tên Sách],
                    COUNT(ct.ma_sach) AS [Số Lần Mượn]
                FROM chi_tiet_muon_tra ct
                JOIN phieu_muon_tra p ON ct.ma_phieu = p.ma_phieu
                JOIN sach s ON ct.ma_sach = s.ma_sach
                WHERE p.ngay_lap >= @FromDate AND p.ngay_lap <= @ToDate
                GROUP BY s.ma_sach, s.ten_sach
                ORDER BY [Số Lần Mượn] DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            };

            return DbHelper.GetData(query, parameters);
        }

        // 8. Báo cáo doanh thu tiền phạt
        public DataTable LayDoanhThuPhat(DateTime fromDate, DateTime toDate)
        {
            string query = @"
                SELECT 
                    ct.ma_phieu AS [Mã Phiếu],
                    dg.ma_dg AS [Mã Độc Giả],
                    dg.ho_ten AS [Tên Độc Giả],
                    s.ten_sach AS [Tên Sách],
                    ct.ngay_tra_thuc_te AS [Ngày Trả Thực Tế],
                    ct.tien_phat AS [Tiền Phạt]
                FROM chi_tiet_muon_tra ct
                JOIN phieu_muon_tra p ON ct.ma_phieu = p.ma_phieu
                JOIN doc_gia dg ON p.ma_dg = dg.ma_dg
                JOIN sach s ON ct.ma_sach = s.ma_sach
                WHERE ct.tien_phat > 0 
                  AND ct.ngay_tra_thuc_te >= @FromDate 
                  AND ct.ngay_tra_thuc_te <= @ToDate
                ORDER BY ct.ngay_tra_thuc_te DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            };

            return DbHelper.GetData(query, parameters);
        }

        // 9. Chi phí nhập sách
        public DataTable LayChiPhiNhapSach(DateTime fromDate, DateTime toDate)
        {
            string query = @"
                SELECT 
                    pn.ma_phieu_nhap AS [Mã Phiếu Nhập],
                    nv.ho_ten AS [Nhân Viên Nhập],
                    ncc.ten_ncc AS [Nhà Cung Cấp],
                    pn.ngay_nhap AS [Ngày Nhập],
                    pn.tong_tien AS [Tổng Tiền]
                FROM phieu_nhap_sach pn
                LEFT JOIN nhan_vien nv ON pn.ma_nv = nv.ma_nv
                LEFT JOIN nha_cung_cap ncc ON pn.ma_ncc = ncc.ma_ncc
                WHERE pn.ngay_nhap >= @FromDate AND pn.ngay_nhap <= @ToDate
                ORDER BY pn.ngay_nhap DESC";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@FromDate", fromDate),
                new SqlParameter("@ToDate", toDate)
            };

            return DbHelper.GetData(query, parameters);
        }

        // 10. Lấy dữ liệu in Phiếu mượn sách
        public DataTable LayDuLieuInPhieuMuon(string maPhieu)
        {
            string query = @"
                SELECT 
                    p.ma_phieu AS [Mã Phiếu],
                    dg.ma_dg AS [Mã Độc Giả],
                    dg.ho_ten AS [Tên Độc Giả],
                    nv.ho_ten AS [Thủ Thư],
                    p.ngay_lap AS [Ngày Mượn],
                    ct.ma_sach AS [Mã Sách],
                    s.ten_sach AS [Tên Sách],
                    ct.ngay_hen_tra AS [Ngày Hẹn Trả]
                FROM phieu_muon_tra p
                JOIN doc_gia dg ON p.ma_dg = dg.ma_dg
                JOIN nhan_vien nv ON p.ma_nv = nv.ma_nv
                JOIN chi_tiet_muon_tra ct ON p.ma_phieu = ct.ma_phieu
                JOIN sach s ON ct.ma_sach = s.ma_sach
                WHERE p.ma_phieu = @MaPhieu";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhieu", maPhieu)
            };

            return DbHelper.GetData(query, parameters);
        }

        // 11. Lấy dữ liệu in Biên lai phạt tiền
        public DataTable LayDuLieuInBienLaiPhat(string maPhieu)
        {
            string query = @"
                SELECT 
                    ct.ma_phieu AS [Mã Phiếu],
                    dg.ma_dg AS [Mã Độc Giả],
                    dg.ho_ten AS [Tên Độc Giả],
                    ct.ma_sach AS [Mã Sách],
                    s.ten_sach AS [Tên Sách],
                    ct.ngay_hen_tra AS [Ngày Hẹn Trả],
                    ct.ngay_tra_thuc_te AS [Ngày Trả],
                    DATEDIFF(day, ct.ngay_hen_tra, ct.ngay_tra_thuc_te) AS [Số Ngày Trễ],
                    ct.tien_phat AS [Tiền Phạt]
                FROM chi_tiet_muon_tra ct
                JOIN phieu_muon_tra p ON ct.ma_phieu = p.ma_phieu
                JOIN doc_gia dg ON p.ma_dg = dg.ma_dg
                JOIN sach s ON ct.ma_sach = s.ma_sach
                WHERE ct.ma_phieu = @MaPhieu AND ct.tien_phat > 0";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhieu", maPhieu)
            };

            return DbHelper.GetData(query, parameters);
        }

        // 12. Lấy dữ liệu in Phiếu nhập kho
        public DataTable LayDuLieuInPhieuNhap(string maPhieuNhap)
        {
            string query = @"
                SELECT 
                    pn.ma_phieu_nhap AS [Mã Phiếu Nhập],
                    nv.ho_ten AS [Nhân Viên Nhập],
                    ncc.ten_ncc AS [Nhà Cung Cấp],
                    pn.ngay_nhap AS [Ngày Nhập],
                    ct.ma_sach AS [Mã Sách],
                    s.ten_sach AS [Tên Sách],
                    ct.so_luong AS [Số Lượng],
                    ct.don_gia AS [Đơn Giá],
                    (ct.so_luong * ct.don_gia) AS [Thành Tiền],
                    pn.tong_tien AS [Tổng Tiền Phiếu]
                FROM phieu_nhap_sach pn
                JOIN nhan_vien nv ON pn.ma_nv = nv.ma_nv
                JOIN nha_cung_cap ncc ON pn.ma_ncc = ncc.ma_ncc
                JOIN chi_tiet_phieu_nhap ct ON pn.ma_phieu_nhap = ct.ma_phieu_nhap
                JOIN sach s ON ct.ma_sach = s.ma_sach
                WHERE pn.ma_phieu_nhap = @MaPhieuNhap";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhieuNhap", maPhieuNhap)
            };

            return DbHelper.GetData(query, parameters);
        }
    }
}