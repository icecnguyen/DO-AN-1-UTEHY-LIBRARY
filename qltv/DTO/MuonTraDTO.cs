using System;

namespace qltv.DTO
{
    // Đối tượng truyền tải dữ liệu chứa thông tin tổng quát của một phiếu mượn sách
    public class MuonTraDTO
    {
        // Mã phiếu mượn (Khóa chính)
        public string MaPhieu 
        {
            get;
            set;
        }
        
        // Khóa ngoại liên kết tới thông tin Độc Giả
        public string MaDG
        {
            get;
            set;
        }
        
        // Khóa ngoại liên kết tới thông tin Nhân Viên thực hiện lập phiếu
        public string MaNV 
        {
            get;
            set;
        }
        
        // Ngày thực hiện thao tác mượn sách
        public DateTime NgayMuon 
        {
            get;
            set;
        }
        
        // Thời hạn yêu cầu trả sách
        public DateTime NgayHenTra 
        {
            get;
            set;
        }
        
        // Thuộc tính hỗ trợ truyền mã sách khi thực hiện nghiệp vụ mượn sách mới
        public string MaSach 
        {
            get;
            set;
        } 
    }   
}