using System;
using System.Data;
using qltv.DAL;
using qltv.DTO;

namespace qltv.BLL
{
    // Lớp xử lý nghiệp vụ liên quan đến nhân viên và tài khoản
    public class NhanVienBLL
    {
        // Khởi tạo đối tượng DAL để tương tác với cơ sở dữ liệu nhân viên
        private NhanVienDAL _nhanVienDAL = new NhanVienDAL();

        // Lấy danh sách toàn bộ nhân viên trong hệ thống
        public DataTable LayTatCaNhanVien()
        {
            return _nhanVienDAL.LayTatCaNhanVien();
        }

        // Tìm kiếm nhân viên dựa trên từ khóa (Mã, Tên, SĐT, CCCD, Email, v.v.)
        public DataTable TimKiemNhanVien(string tuKhoa)
        {
            return _nhanVienDAL.TimKiemNhanVien(tuKhoa);
        }

        // Thực hiện thêm mới một nhân viên và khởi tạo tài khoản tương ứng
        public bool ThemNhanVien(NhanVienDTO nhanVien)
        {
            // Kiểm tra các trường dữ liệu bắt buộc của nhân viên và tài khoản
            if (string.IsNullOrWhiteSpace(nhanVien.MaNV))
            {
                throw new ArgumentException("Mã nhân viên không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(nhanVien.HoTen))
            {
                throw new ArgumentException("Họ tên nhân viên không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(nhanVien.CCCD))
            {
                throw new ArgumentException("Số CCCD không được để trống.");
            }
            if (nhanVien.CCCD.Length != 12 || !System.Text.RegularExpressions.Regex.IsMatch(nhanVien.CCCD, @"^[0-9]+$"))
            {
                throw new ArgumentException("Số CCCD không hợp lệ (yêu cầu đúng 12 chữ số).");
            }
            if (string.IsNullOrWhiteSpace(nhanVien.TenTK))
            {
                throw new ArgumentException("Tên tài khoản không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(nhanVien.MatKhau))
            {
                throw new ArgumentException("Mật khẩu không được để trống.");
            }

            // Kiểm tra trùng lặp dữ liệu quan trọng (Mã nhân viên, CCCD, Tên tài khoản)
            if (_nhanVienDAL.KiemTraTonTaiMaNV(nhanVien.MaNV))
            {
                throw new ArgumentException("Mã nhân viên đã tồn tại trong hệ thống.");
            }
            if (_nhanVienDAL.KiemTraTonTaiCCCD(nhanVien.CCCD))
            {
                throw new ArgumentException("Số CCCD đã tồn tại trong hệ thống.");
            }
            if (_nhanVienDAL.KiemTraTonTaiTenTK(nhanVien.TenTK))
            {
                throw new ArgumentException("Tên tài khoản đăng ký đã được sử dụng.");
            }

            return _nhanVienDAL.ThemNhanVien(nhanVien);
        }

        // Thực hiện cập nhật thông tin nhân viên và tài khoản đăng nhập
        public bool CapNhatNhanVien(NhanVienDTO nhanVien)
        {
            if (string.IsNullOrWhiteSpace(nhanVien.MaNV))
            {
                throw new ArgumentException("Mã nhân viên không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(nhanVien.HoTen))
            {
                throw new ArgumentException("Họ tên nhân viên không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(nhanVien.CCCD))
            {
                throw new ArgumentException("Số CCCD không được để trống.");
            }
            if (nhanVien.CCCD.Length != 12 || !System.Text.RegularExpressions.Regex.IsMatch(nhanVien.CCCD, @"^[0-9]+$"))
            {
                throw new ArgumentException("Số CCCD không hợp lệ (yêu cầu đúng 12 chữ số).");
            }
            if (string.IsNullOrWhiteSpace(nhanVien.TenTK))
            {
                throw new ArgumentException("Tên tài khoản không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(nhanVien.MatKhau))
            {
                throw new ArgumentException("Mật khẩu không được để trống.");
            }

            if (!_nhanVienDAL.KiemTraTonTaiMaNV(nhanVien.MaNV))
            {
                throw new ArgumentException("Mã nhân viên không tồn tại trong hệ thống.");
            }
            if (_nhanVienDAL.KiemTraTonTaiCCCD(nhanVien.CCCD, nhanVien.MaNV))
            {
                throw new ArgumentException("Số CCCD này đã được đăng ký bởi nhân viên khác.");
            }

            return _nhanVienDAL.CapNhatNhanVien(nhanVien);
        }

        // Thực hiện xóa hồ sơ nhân viên và vô hiệu hóa tài khoản liên kết
        public bool XoaNhanVien(string maNV, string tenTK)
        {
            if (string.IsNullOrWhiteSpace(maNV))
            {
                throw new ArgumentException("Mã nhân viên cần xóa không được để trống.");
            }

            if (!_nhanVienDAL.KiemTraTonTaiMaNV(maNV))
            {
                throw new ArgumentException("Mã nhân viên không tồn tại trong hệ thống.");
            }

            return _nhanVienDAL.XoaNhanVien(maNV, tenTK);
        }
    }
}