namespace qltv.DTO
{
    // Đối tượng truyền tải dữ liệu quản lý thông tin các danh mục phân loại sách
    public class DanhMucDTO
    {
        // Mã định danh danh mục (Khóa chính)
        public string MaDM
        {
            get;
            set;
        }
        
        // Tên hiển thị của danh mục sách
        public string TenDM 
        {
            get;
            set;
        }
        
        // Thông tin mô tả chi tiết về danh mục
        public string MoTa 
        {
            get;
            set;
        }
    }   
}