namespace qltv.DTO
{
    // Đối tượng truyền tải dữ liệu (Data Transfer Object) hỗ trợ trích xuất báo cáo thống kê
    public class BaoCaoDTO
    {
        // Tiêu đề của mục báo cáo (ví dụ: Tổng số sách, Sách mượn nhiều nhất)
        public string Title
        {
            get;
            set;
        }

        // Số lượng thống kê tương ứng với tiêu đề
        public int Count
        {
            get;
            set;
        }

        // Tổng số tiền (áp dụng cho các báo cáo tài chính như doanh thu tiền phạt, chi phí nhập sách)
        public decimal TotalAmount
        {
            get;
            set;
        }
    }
}