using System;
using System.Data;
using qltv.DAL;
using qltv.DTO;

namespace qltv.BLL
{
    public class SachBLL
    {
        // Khởi tạo đối tượng DAL để tương tác với dữ liệu sách trong cơ sở dữ liệu
        private SachDAL _sachDAL = new SachDAL();

        // Lấy danh sách toàn bộ sách có trong hệ thống
        public DataTable LayTatCaSach()
        {
            return _sachDAL.LayTatCaSach();
        }

        // Tìm kiếm thông tin sách dựa trên từ khóa (hỗ trợ tìm kiếm đa trường)
        public DataTable TimKiemSach(string tuKhoa)
        {
            return _sachDAL.TimKiemSach(tuKhoa);
        }

        // Thực hiện thêm mới một cuốn sách vào hệ thống
        public bool ThemSach(SachDTO sach)
        {
            // Kiểm tra tính hợp lệ của các trường dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(sach.MaSach))
            {
                throw new ArgumentException("Mã sách không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(sach.TenSach))
            {
                throw new ArgumentException("Tên sách không được để trống.");
            }
            
            // Kiểm tra số lượng tồn kho hợp lệ
            if (sach.SoLuongTon < 0)
            {
                throw new ArgumentException("Số lượng tồn kho không hợp lệ (không được âm).");
            }

            // Kiểm tra trùng lặp mã sách trong hệ thống
            if (_sachDAL.KiemTraTonTaiMaSach(sach.MaSach))
            {
                throw new ArgumentException("Mã sách đã tồn tại trong hệ thống.");
            }

            // Tiến hành thêm thông tin sách vào cơ sở dữ liệu
            return _sachDAL.ThemSach(sach);
        }

        // Cập nhật thông tin của một cuốn sách hiện có
        public bool CapNhatSach(SachDTO sach)
        {
            // Kiểm tra tính hợp lệ của các trường dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(sach.MaSach))
            {
                throw new ArgumentException("Mã sách không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(sach.TenSach))
            {
                throw new ArgumentException("Tên sách không được để trống.");
            }
            if (sach.SoLuongTon < 0)
            {
                throw new ArgumentException("Số lượng tồn kho không hợp lệ (không được âm).");
            }

            // Kiểm tra tính tồn tại của cuốn sách trước khi cập nhật
            if (!_sachDAL.KiemTraTonTaiMaSach(sach.MaSach))
            {
                throw new ArgumentException("Cuốn sách không tồn tại trong hệ thống hoặc đã bị xóa.");
            }

            return _sachDAL.CapNhatSach(sach);
        }

        // Xóa thông tin sách khỏi hệ thống
        public bool XoaSach(string maSach)
        {
            if (string.IsNullOrWhiteSpace(maSach))
            {
                throw new ArgumentException("Mã sách cần xóa không được để trống.");
            }

            // Kiểm tra tính tồn tại của cuốn sách trước khi xóa
            if (!_sachDAL.KiemTraTonTaiMaSach(maSach))
            {
                throw new ArgumentException("Cuốn sách không tồn tại trong hệ thống.");
            }

            return _sachDAL.XoaSach(maSach);
        }
    }
}