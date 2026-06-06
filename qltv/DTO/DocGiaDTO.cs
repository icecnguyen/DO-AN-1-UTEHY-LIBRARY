using System;

namespace qltv.DTO
{
    // Đối tượng truyền tải dữ liệu quản lý thông tin khách hàng mượn sách (Độc giả)
    public class DocGiaDTO
    {
        // Mã định danh độc giả (Khóa chính)
        public string MaDG
        {
            get;
            set;
        }
        
        // Họ và tên đầy đủ của độc giả
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
        
        // Khoa hoặc đơn vị trực thuộc của độc giả (ví dụ: CNTT, Kinh Tế)
        public string Khoa 
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
        
        // Địa chỉ thư điện tử
        public string Email 
        {
            get;
            set;
        }
        
        // Ngày hết hạn của thẻ thư viện
        public DateTime? NgayHetHan 
        {
            get;
            set;
        }
        
        // Trạng thái hoạt động của thẻ (true: Đang hoạt động, false: Đã khóa)
        public bool TrangThai 
        {
            get;
            set;
        }
    }   
}