using System;
using System.Data;
using qltv.DAL;

namespace qltv.BLL
{
    public class TaiKhoanBLL
    {
        // Khởi tạo đối tượng DAL để tương tác với dữ liệu tài khoản
        private TaiKhoanDAL _taiKhoanDAL = new TaiKhoanDAL();

        // Thực hiện xác thực đăng nhập người dùng vào hệ thống
        public bool DangNhap(string taiKhoan, string matKhau, out int phanQuyen, out string maNV)
        {
            // Thiết lập giá trị mặc định cho phân quyền và mã nhân viên
            phanQuyen = 2; 
            maNV = null;

            // Kiểm tra tính hợp lệ của thông tin đăng nhập
            if (string.IsNullOrWhiteSpace(taiKhoan))
            {
                throw new ArgumentException("Tên đăng nhập không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(matKhau))
            {
                throw new ArgumentException("Mật khẩu không được để trống.");
            }

            // Tiến hành kiểm tra thông tin đăng nhập từ cơ sở dữ liệu
            DataTable dt = _taiKhoanDAL.KiemTraDangNhap(taiKhoan, matKhau);
            if (dt != null && dt.Rows.Count > 0)
            {
                // Truy xuất thông tin phân quyền và mã nhân viên khi đăng nhập thành công
                phanQuyen = Convert.ToInt32(dt.Rows[0]["phan_quyen"]);
                maNV = _taiKhoanDAL.LayMaNVTuTenTK(taiKhoan);
                return true;
            }
            
            return false;
        }
    }
}