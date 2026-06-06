using System;
using System.Data;
using System.Data.SqlClient;
using qltv.DTO;

namespace qltv.DAL
{
    // Lớp truy xuất dữ liệu xử lý thông tin danh mục sách
    public class DanhMucDAL
    {
        // Lấy danh sách toàn bộ danh mục sách từ cơ sở dữ liệu
        public DataTable LayTatCaDanhMuc()
        {
            string query = "SELECT ma_dm AS [Mã Danh Mục], ten_dm AS [Tên Danh Mục], mo_ta AS [Mô Tả] FROM danh_muc";
            return DbHelper.GetData(query);
        }

        // Kiểm tra sự tồn tại của mã danh mục trong hệ thống
        public bool KiemTraTonTaiMaDM(string maDM)
        {
            string query = "SELECT COUNT(*) FROM danh_muc WHERE ma_dm = @MaDM";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaDM", maDM)
            };
            DataTable dt = DbHelper.GetData(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        // Thực thi thêm mới danh mục vào cơ sở dữ liệu
        public bool ThemDanhMuc(DanhMucDTO cat)
        {
            string query = "INSERT INTO danh_muc (ma_dm, ten_dm, mo_ta) VALUES (@MaDM, @TenDM, @MoTa)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaDM", cat.MaDM),
                new SqlParameter("@TenDM", cat.TenDM),
                new SqlParameter("@MoTa", (object)cat.MoTa ?? DBNull.Value)
            };
            return DbHelper.Execute(query, parameters);
        }

        // Thực thi cập nhật thông tin danh mục
        public bool CapNhatDanhMuc(DanhMucDTO cat)
        {
            string query = "UPDATE danh_muc SET ten_dm = @TenDM, mo_ta = @MoTa WHERE ma_dm = @MaDM";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaDM", cat.MaDM),
                new SqlParameter("@TenDM", cat.TenDM),
                new SqlParameter("@MoTa", (object)cat.MoTa ?? DBNull.Value)
            };
            return DbHelper.Execute(query, parameters);
        }

        // Thực thi xóa danh mục khỏi hệ thống
        public bool XoaDanhMuc(string maDM)
        {
            string query = "DELETE FROM danh_muc WHERE ma_dm = @MaDM";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaDM", maDM)
            };
            return DbHelper.Execute(query, parameters);
        }

        // Tìm kiếm danh mục theo từ khóa
        public DataTable TimKiemDanhMuc(string keyword)
        {
            string query = "SELECT ma_dm AS [Mã Danh Mục], ten_dm AS [Tên Danh Mục], mo_ta AS [Mô Tả] FROM danh_muc WHERE ma_dm LIKE @Keyword OR ten_dm LIKE @Keyword OR mo_ta LIKE @Keyword";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };
            return DbHelper.GetData(query, parameters);
        }
    }
}