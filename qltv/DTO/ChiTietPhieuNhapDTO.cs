namespace qltv.DTO
{
    // Đối tượng truyền tải dữ liệu lưu trữ thông tin chi tiết từng cuốn sách trong phiếu nhập
    public class ChiTietPhieuNhapDTO
    {
        // Khóa ngoại liên kết tới mã phiếu nhập tương ứng
        public string MaPhieuNhap
        {
            get;
            set;
        }
        
        // Mã sách được nhập vào kho
        public string MaSach
        {
            get;
            set;
        }
        
        // Số lượng sách nhập kho
        public int SoLuong
        {
            get;
            set;
        }
        
        // Đơn giá nhập của mỗi cuốn sách
        public decimal DonGia
        {
            get;
            set;
        }
    }   
}