using System;
using System.Data;
using System.Data.SqlClient;
using qltv.DTO;

namespace qltv.DAL
{
    // Lớp truy xuất dữ liệu xử lý thông tin sách
    public class SachDAL
    {
        // Lấy danh sách toàn bộ sách (bao gồm tên danh mục tương ứng)
        public DataTable LayTatCaSach()
        {
            string query = @"
                SELECT s.ma_sach AS [Mã Sách], 
                       s.ten_sach AS [Tên Sách], 
                       s.tac_gia AS [Tác Giả], 
                       s.nha_xb AS [Nhà XB], 
                       s.nam_xb AS [Năm XB], 
                       dm.ten_dm AS [Danh Mục], 
                       s.so_luong_ton AS [Số Lượng Tồn], 
                       s.gia_sach AS [Giá Sách],
                       s.ma_dm AS [Mã DM]
                FROM sach s 
                LEFT JOIN danh_muc dm ON s.ma_dm = dm.ma_dm";
            return DbHelper.GetData(query);
        }

        // Tìm kiếm thông tin sách dựa trên từ khóa (mã, tên, tác giả, v.v.)
        public DataTable TimKiemSach(string keyword)
        {
            string query = @"
                SELECT s.ma_sach AS [Mã Sách], 
                       s.ten_sach AS [Tên Sách], 
                       s.tac_gia AS [Tác Giả], 
                       s.nha_xb AS [Nhà XB], 
                       s.nam_xb AS [Năm XB], 
                       dm.ten_dm AS [Danh Mục], 
                       s.so_luong_ton AS [Số Lượng Tồn], 
                       s.gia_sach AS [Giá Sách],
                       s.ma_dm AS [Mã DM]
                FROM sach s 
                LEFT JOIN danh_muc dm ON s.ma_dm = dm.ma_dm 
                WHERE s.ma_sach LIKE @Keyword 
                   OR s.ten_sach LIKE @Keyword 
                   OR s.tac_gia LIKE @Keyword
                   OR s.nha_xb LIKE @Keyword
                   OR dm.ten_dm LIKE @Keyword";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };
            return DbHelper.GetData(query, parameters);
        }

        // Kiểm tra sự tồn tại của mã sách trong hệ thống
        public bool KiemTraTonTaiMaSach(string bookId)
        {
            string query = "SELECT COUNT(*) FROM sach WHERE ma_sach = @BookID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BookID", bookId)
            };
            DataTable dt = DbHelper.GetData(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        // Thực thi thêm mới sách vào cơ sở dữ liệu
        public bool ThemSach(SachDTO book)
        {
            string query = "INSERT INTO sach (ma_sach, ten_sach, tac_gia, nha_xb, nam_xb, ma_dm, so_luong_ton, gia_sach) VALUES (@BookID, @BookName, @Author, @Publisher, @PubYear, @CatID, @Quantity, @Price)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BookID", book.MaSach),
                new SqlParameter("@BookName", book.TenSach),
                new SqlParameter("@Author", (object)book.TacGia ?? DBNull.Value),
                new SqlParameter("@Publisher", (object)book.NhaXB ?? DBNull.Value),
                new SqlParameter("@PubYear", book.NamXB == 0 ? DBNull.Value : (object)book.NamXB),
                new SqlParameter("@CatID", (object)book.MaDM ?? DBNull.Value),
                new SqlParameter("@Quantity", book.SoLuongTon),
                new SqlParameter("@Price", book.GiaSach)
            };
            return DbHelper.Execute(query, parameters);
        }

        // Thực thi cập nhật thông tin sách
        public bool CapNhatSach(SachDTO book)
        {
            string query = "UPDATE sach SET ten_sach = @BookName, tac_gia = @Author, nha_xb = @Publisher, nam_xb = @PubYear, ma_dm = @CatID, so_luong_ton = @Quantity, gia_sach = @Price WHERE ma_sach = @BookID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BookID", book.MaSach),
                new SqlParameter("@BookName", book.TenSach),
                new SqlParameter("@Author", (object)book.TacGia ?? DBNull.Value),
                new SqlParameter("@Publisher", (object)book.NhaXB ?? DBNull.Value),
                new SqlParameter("@PubYear", book.NamXB == 0 ? DBNull.Value : (object)book.NamXB),
                new SqlParameter("@CatID", (object)book.MaDM ?? DBNull.Value),
                new SqlParameter("@Quantity", book.SoLuongTon),
                new SqlParameter("@Price", book.GiaSach)
            };
            return DbHelper.Execute(query, parameters);
        }

        // Thực thi xóa sách khỏi hệ thống
        public bool XoaSach(string bookId)
        {
            string query = "DELETE FROM sach WHERE ma_sach = @BookID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BookID", bookId)
            };
            return DbHelper.Execute(query, parameters);
        }
    }
}