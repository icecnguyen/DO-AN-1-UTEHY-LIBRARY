namespace qltv.DTO
{
    // Đối tượng truyền tải dữ liệu quản lý thông tin đối tác cung cấp sách
    public class NhaCungCapDTO
    {
        // Mã định danh nhà cung cấp (Khóa chính)
        public string MaNCC 
        {
            get;
            set;
        }
        
        // Tên đầy đủ của nhà cung cấp
        public string TenNCC 
        {
            get;
            set;
        }
        
        // Số điện thoại liên hệ của nhà cung cấp
        public string SDT 
        {
            get;
            set;
        }
        
        // Địa chỉ trụ sở làm việc
        public string DiaChi 
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
        
        // Tên người đại diện hoặc nhân viên liên hệ trực tiếp
        public string NguoiLienHe 
        {
            get;
            set;
        } 
    }
}