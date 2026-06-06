using System;
using System.Data;
using System.Data.SqlClient;
using qltv.DTO;

namespace qltv.DAL
{
    // Lớp truy xuất dữ liệu xử lý thông tin độc giả (thẻ thư viện)
    public class DocGiaDAL
    {
        // Lấy danh sách toàn bộ độc giả từ cơ sở dữ liệu
        public DataTable LayTatCaDocGia()
        {
            string query = @"
                SELECT ma_dg AS [Mã Độc Giả], 
                       ho_ten AS [Họ Tên], 
                       ngay_sinh AS [Ngày Sinh], 
                       CASE WHEN gioi_tinh = 1 THEN N'Nam' ELSE N'Nữ' END AS [Giới Tính], 
                       khoa AS [Khoa], 
                       sdt AS [Số Điện Thoại], 
                       email AS [Email], 
                       ngay_het_han AS [Ngày Hết Hạn], 
                       CASE WHEN trang_thai = 1 THEN N'Hoạt động' ELSE N'Khóa' END AS [Trạng Thái] 
                FROM doc_gia";
            return DbHelper.GetData(query);
        }

        // Tìm kiếm thông tin độc giả dựa trên từ khóa (mã, tên, số điện thoại, v.v.)
        public DataTable TimKiemDocGia(string keyword)
        {
            string query = @"
                SELECT ma_dg AS [Mã Độc Giả], 
                       ho_ten AS [Họ Tên], 
                       ngay_sinh AS [Ngày Sinh], 
                       CASE WHEN gioi_tinh = 1 THEN N'Nam' ELSE N'Nữ' END AS [Giới Tính], 
                       khoa AS [Khoa], 
                       sdt AS [Số Điện Thoại], 
                       email AS [Email], 
                       ngay_het_han AS [Ngày Hết Hạn], 
                       CASE WHEN trang_thai = 1 THEN N'Hoạt động' ELSE N'Khóa' END AS [Trạng Thái] 
                FROM doc_gia 
                WHERE ma_dg LIKE @Keyword 
                   OR ho_ten LIKE @Keyword 
                   OR khoa LIKE @Keyword 
                   OR sdt LIKE @Keyword
                   OR email LIKE @Keyword";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };
            return DbHelper.GetData(query, parameters);
        }

        // Kiểm tra sự tồn tại của mã độc giả trong hệ thống
        public bool KiemTraTonTaiMaDG(string readerId)
        {
            string query = "SELECT COUNT(*) FROM doc_gia WHERE ma_dg = @ReaderID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ReaderID", readerId)
            };
            DataTable dt = DbHelper.GetData(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        // Thực thi thêm mới hồ sơ độc giả vào cơ sở dữ liệu
        public bool ThemDocGia(DocGiaDTO reader)
        {
            string query = "INSERT INTO doc_gia (ma_dg, ho_ten, ngay_sinh, gioi_tinh, khoa, sdt, email, ngay_het_han, trang_thai) VALUES (@ReaderID, @ReaderName, @BirthDate, @Gender, @Dept, @Phone, @Email, @ExpiryDate, @Status)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ReaderID", reader.MaDG),
                new SqlParameter("@ReaderName", reader.HoTen),
                new SqlParameter("@BirthDate", (object)reader.NgaySinh ?? DBNull.Value),
                new SqlParameter("@Gender", (object)reader.GioiTinh ?? DBNull.Value),
                new SqlParameter("@Dept", (object)reader.Khoa ?? DBNull.Value),
                new SqlParameter("@Phone", (object)reader.SDT ?? DBNull.Value),
                new SqlParameter("@Email", (object)reader.Email ?? DBNull.Value),
                new SqlParameter("@ExpiryDate", (object)reader.NgayHetHan ?? DBNull.Value),
                new SqlParameter("@Status", reader.TrangThai)
            };
            return DbHelper.Execute(query, parameters);
        }

        // Thực thi cập nhật thông tin hồ sơ độc giả
        public bool CapNhatDocGia(DocGiaDTO reader)
        {
            string query = "UPDATE doc_gia SET ho_ten = @ReaderName, ngay_sinh = @BirthDate, gioi_tinh = @Gender, khoa = @Dept, sdt = @Phone, email = @Email, ngay_het_han = @ExpiryDate, trang_thai = @Status WHERE ma_dg = @ReaderID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ReaderID", reader.MaDG),
                new SqlParameter("@ReaderName", reader.HoTen),
                new SqlParameter("@BirthDate", (object)reader.NgaySinh ?? DBNull.Value),
                new SqlParameter("@Gender", (object)reader.GioiTinh ?? DBNull.Value),
                new SqlParameter("@Dept", (object)reader.Khoa ?? DBNull.Value),
                new SqlParameter("@Phone", (object)reader.SDT ?? DBNull.Value),
                new SqlParameter("@Email", (object)reader.Email ?? DBNull.Value),
                new SqlParameter("@ExpiryDate", (object)reader.NgayHetHan ?? DBNull.Value),
                new SqlParameter("@Status", reader.TrangThai)
            };
            return DbHelper.Execute(query, parameters);
        }

        // Thực thi xóa hồ sơ độc giả khỏi hệ thống
        public bool XoaDocGia(string readerId)
        {
            string query = "DELETE FROM doc_gia WHERE ma_dg = @ReaderID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ReaderID", readerId)
            };
            return DbHelper.Execute(query, parameters);
        }
    }
}