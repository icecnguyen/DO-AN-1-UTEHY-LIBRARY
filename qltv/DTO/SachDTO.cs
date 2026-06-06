namespace qltv.DTO
{
    // Đối tượng truyền tải dữ liệu quản lý thông tin cấu trúc của một cuốn sách
    public class SachDTO
    {
        // Mã định danh sách (Khóa chính)
        public string MaSach 
        {
            get;
            set;
        }
        
        // Tên đầy đủ của cuốn sách
        public string TenSach 
        {
            get;
            set;
        }
        
        // Khóa ngoại liên kết tới bảng Danh Mục sách
        public string MaDM 
        {
            get;
            set;
        }
        
        // Tác giả của cuốn sách
        public string TacGia 
        {
            get;
            set;
        }
        
        // Tên nhà xuất bản phát hành cuốn sách
        public string NhaXB 
        {
            get;
            set;
        }
        
        // Năm xuất bản (Cho phép giá trị NULL đối với những cuốn sách không xác định rõ năm xuất bản)
        public int? NamXB 
        {
            get;
            set;
        } 
        
        // Giá niêm yết của cuốn sách
        public decimal? GiaSach 
        {
            get;
            set;
        } 
        
        // Số lượng sách hiện đang tồn kho (Chỉ số quan trọng để quản lý tình trạng mượn/trả và nhập hàng)
        public int SoLuongTon 
        {
            get;
            set;
        }
    }
}