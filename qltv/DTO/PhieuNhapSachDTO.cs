using System;

namespace qltv.DTO
{
    // Đối tượng truyền tải dữ liệu chứa thông tin tổng quát của một phiếu nhập sách
    // (Thông tin chi tiết các sách được nhập lưu trữ tại ChiTietPhieuNhapDTO)
    public class PhieuNhapSachDTO
    {
        // Mã phiếu nhập (Khóa chính)
        public string MaPhieuNhap
        {
            get;
            set;
        }
        
        // Khóa ngoại liên kết tới thông tin Nhân Viên thực hiện nhập hàng
        public string MaNV 
        {
            get;
            set;
        }
        
        // Khóa ngoại liên kết tới thông tin Nhà Cung Cấp sách
        public string MaNCC 
        {
            get;
            set;
        }
        
        // Ngày thực hiện thao tác nhập sách
        public DateTime NgayNhap 
        {
            get;
            set;
        }
        
        // Tổng giá trị của phiếu nhập hàng
        public decimal TongTien 
        {
            get;
            set;
        }
    }
}