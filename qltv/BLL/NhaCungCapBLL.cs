using System;
using System.Data;
using qltv.DAL;
using qltv.DTO;

namespace qltv.BLL
{
    public class NhaCungCapBLL
    {
        // Khởi tạo đối tượng DAL để tương tác với cơ sở dữ liệu
        private NhaCungCapDAL _nhaCungCapDAL = new NhaCungCapDAL();

        // Lấy danh sách toàn bộ nhà cung cấp
        public DataTable LayTatCaNhaCungCap()
        {
            return _nhaCungCapDAL.LayTatCaNhaCungCap();
        }

        // Thực hiện thêm mới nhà cung cấp
        public bool ThemNhaCungCap(NhaCungCapDTO ncc)
        {
            // Kiểm tra tính hợp lệ của các trường dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(ncc.MaNCC))
            {
                throw new ArgumentException("Mã nhà cung cấp không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(ncc.TenNCC))
            {
                throw new ArgumentException("Tên nhà cung cấp không được để trống.");
            }
            // Kiểm tra trùng lặp mã nhà cung cấp
            if (_nhaCungCapDAL.KiemTraTonTaiMaNCC(ncc.MaNCC))
            {
                throw new ArgumentException("Mã nhà cung cấp đã tồn tại trong hệ thống.");
            }

            return _nhaCungCapDAL.ThemNhaCungCap(ncc);
        }

        // Thực hiện cập nhật thông tin nhà cung cấp
        public bool CapNhatNhaCungCap(NhaCungCapDTO ncc)
        {
            // Kiểm tra tính hợp lệ của các trường dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(ncc.MaNCC))
            {
                throw new ArgumentException("Mã nhà cung cấp không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(ncc.TenNCC))
            {
                throw new ArgumentException("Tên nhà cung cấp không được để trống.");
            }
            // Kiểm tra sự tồn tại của nhà cung cấp trước khi cập nhật
            if (!_nhaCungCapDAL.KiemTraTonTaiMaNCC(ncc.MaNCC))
            {
                throw new ArgumentException("Nhà cung cấp không tồn tại trong hệ thống.");
            }

            return _nhaCungCapDAL.CapNhatNhaCungCap(ncc);
        }

        // Thực hiện xóa nhà cung cấp khỏi hệ thống
        public bool XoaNhaCungCap(string maNCC)
        {
            if (string.IsNullOrWhiteSpace(maNCC))
            {
                throw new ArgumentException("Mã nhà cung cấp cần xóa không được để trống.");
            }
            // Kiểm tra sự tồn tại của nhà cung cấp trước khi xóa
            if (!_nhaCungCapDAL.KiemTraTonTaiMaNCC(maNCC))
            {
                throw new ArgumentException("Nhà cung cấp không tồn tại trong hệ thống.");
            }

            return _nhaCungCapDAL.XoaNhaCungCap(maNCC);
        }

        // Tìm kiếm nhà cung cấp theo từ khóa
        public DataTable TimKiemNhaCungCap(string tuKhoa)
        {
            return _nhaCungCapDAL.TimKiemNhaCungCap(tuKhoa);
        }
    }
}