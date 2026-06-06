using System;
using System.Data;
using System.Data.SqlClient;

namespace qltv.DAL
{
    // Lớp truy xuất dữ liệu xử lý đăng nhập và tài khoản
    public class TaiKhoanDAL
    {
        // Xác thực thông tin đăng nhập của người dùng
        public DataTable KiemTraDangNhap(string username, string password)
        {
            // Câu lệnh truy vấn kiểm tra tài khoản và mật khẩu
            string query = "SELECT ten_tk, phan_quyen FROM tai_khoan WHERE ten_tk = @Username AND mat_khau = @Password";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
            };
            return DbHelper.GetData(query, parameters);
        }

        // Truy xuất mã nhân viên dựa trên tên tài khoản đăng nhập
        public string LayMaNVTuTenTK(string username)
        {
            // Câu lệnh truy vấn lấy thông tin mã nhân viên
            string query = "SELECT ma_nv FROM nhan_vien WHERE ten_tk = @Username";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username)
            };
            DataTable dt = DbHelper.GetData(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ma_nv"].ToString();
            }
            return null;
        }
    }
}