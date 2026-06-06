using System;
using System.Data;
using qltv.DAL;
using qltv.DTO;

namespace qltv.BLL
{
    public class DocGiaBLL
    {
        // Khởi tạo đối tượng DAL để tương tác với cơ sở dữ liệu
        private DocGiaDAL _docGiaDAL = new DocGiaDAL();

        // Lấy danh sách toàn bộ độc giả
        public DataTable LayTatCaDocGia()
        {
            return _docGiaDAL.LayTatCaDocGia();
        }

        // Tìm kiếm thông tin độc giả dựa trên từ khóa
        public DataTable TimKiemDocGia(string tuKhoa)
        {
            return _docGiaDAL.TimKiemDocGia(tuKhoa);
        }

        // Thực hiện thêm mới thẻ độc giả
        public bool ThemDocGia(DocGiaDTO docGia)
        {
            // Kiểm tra các trường dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(docGia.MaDG))
            {
                throw new ArgumentException("Mã độc giả không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(docGia.HoTen))
            {
                throw new ArgumentException("Họ tên độc giả không được để trống.");
            }
            
            // Kiểm tra định dạng số điện thoại
            if (!string.IsNullOrWhiteSpace(docGia.SDT))
            {
                if (docGia.SDT.Length != 10 || !KiemTraLaSo(docGia.SDT))
                {
                    throw new ArgumentException("Số điện thoại không hợp lệ (phải bao gồm đúng 10 chữ số).");
                }
            }

            // Kiểm tra trùng lặp mã độc giả trong hệ thống
            if (_docGiaDAL.KiemTraTonTaiMaDG(docGia.MaDG))
            {
                throw new ArgumentException("Mã độc giả đã tồn tại trong hệ thống.");
            }

            return _docGiaDAL.ThemDocGia(docGia);
        }

        // Thực hiện cập nhật thông tin thẻ độc giả
        public bool CapNhatDocGia(DocGiaDTO docGia)
        {
            // Kiểm tra các trường dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(docGia.MaDG))
            {
                throw new ArgumentException("Mã độc giả không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(docGia.HoTen))
            {
                throw new ArgumentException("Họ tên không được để trống.");
            }
            
            // Kiểm tra định dạng số điện thoại
            if (!string.IsNullOrWhiteSpace(docGia.SDT))
            {
                if (docGia.SDT.Length != 10 || !KiemTraLaSo(docGia.SDT))
                {
                    throw new ArgumentException("Số điện thoại không hợp lệ (phải bao gồm đúng 10 chữ số).");
                }
            }

            // Kiểm tra sự tồn tại của độc giả trước khi cập nhật
            if (!_docGiaDAL.KiemTraTonTaiMaDG(docGia.MaDG))
            {
                throw new ArgumentException("Độc giả không tồn tại trong hệ thống.");
            }

            return _docGiaDAL.CapNhatDocGia(docGia);
        }

        // Thực hiện xóa thẻ độc giả khỏi hệ thống
        public bool XoaDocGia(string maDG)
        {
            if (string.IsNullOrWhiteSpace(maDG))
            {
                throw new ArgumentException("Mã độc giả cần xóa không được để trống.");
            }

            // Kiểm tra sự tồn tại của độc giả
            if (!_docGiaDAL.KiemTraTonTaiMaDG(maDG))
            {
                throw new ArgumentException("Độc giả không tồn tại hoặc đã bị xóa trước đó.");
            }

            return _docGiaDAL.XoaDocGia(maDG);
        }

        // Hàm hỗ trợ kiểm tra chuỗi có chỉ chứa ký tự số hay không
        private bool KiemTraLaSo(string input)
        {
            foreach (char c in input)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }
    }
}