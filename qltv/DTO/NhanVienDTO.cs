using System;

namespace qltv.DTO
{
    // Đối tượng truyền tải dữ liệu quản lý thông tin cơ bản của nhân viên thư viện
    public class NhanVienDTO
    {
        // Mã định danh nhân viên (Khóa chính)
        public string MaNV
        {
            get;
            set;
        }
        
        // Họ và tên đầy đủ của nhân viên
        public string HoTen 
        {
            get;
            set;
        }
        
        // Ngày tháng năm sinh
        public DateTime? NgaySinh 
        {
            get;
            set;
        }
        
        // Giới tính (true: Nam, false: Nữ)
        public bool? GioiTinh 
        {
            get;
            set;
        }
        
        // Số điện thoại liên hệ
        public string SDT 
        {
            get;
            set;
        }
        
        // Số Căn cước công dân
        public string CCCD 
        {
            get;
            set;
        }
        
        // Địa chỉ thư điện tử
        public string Email 
        {
            get;
            set;
        }
        
        // Địa chỉ thường trú
        public string DiaChi 
        {
            get;
            set;
        }
        
        // Ngày bắt đầu làm việc tại thư viện
        public DateTime? NgayVaoLam 
        {
            get;
            set;
        }
        
        // Tên tài khoản đăng nhập hệ thống tương ứng với nhân viên
        public string TenTK 
        {
            get;
            set;
        }
        
        // Mật khẩu đăng nhập (Sử dụng trong các thao tác thêm mới/cập nhật tài khoản)
        public string MatKhau 
        {
            get;
            set;
        } 
    }
}