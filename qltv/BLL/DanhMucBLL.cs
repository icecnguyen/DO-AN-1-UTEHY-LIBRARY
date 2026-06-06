using System;
using System.Data;
using qltv.DAL;
using qltv.DTO;

namespace qltv.BLL
{
    public class DanhMucBLL
    {
        // Khởi tạo đối tượng DAL để tương tác với cơ sở dữ liệu
        private DanhMucDAL _danhMucDAL = new DanhMucDAL();

        // Lấy danh sách toàn bộ danh mục sách
        public DataTable LayTatCaDanhMuc()
        {
            return _danhMucDAL.LayTatCaDanhMuc();
        }

        // Thực hiện thêm mới một danh mục
        public bool ThemDanhMuc(DanhMucDTO danhMuc)
        {
            // Kiểm tra các trường dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(danhMuc.MaDM))
            {
                throw new ArgumentException("Mã danh mục không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(danhMuc.TenDM))
            {
                throw new ArgumentException("Tên danh mục không được để trống.");
            }
            // Kiểm tra trùng lặp mã danh mục trong hệ thống
            if (_danhMucDAL.KiemTraTonTaiMaDM(danhMuc.MaDM))
            {
                throw new ArgumentException("Mã danh mục này đã tồn tại.");
            }
            
            return _danhMucDAL.ThemDanhMuc(danhMuc);
        }

        // Thực hiện cập nhật thông tin danh mục
        public bool CapNhatDanhMuc(DanhMucDTO danhMuc)
        {
            // Kiểm tra các trường dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(danhMuc.MaDM))
            {
                throw new ArgumentException("Mã danh mục không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(danhMuc.TenDM))
            {
                throw new ArgumentException("Tên danh mục không được để trống.");
            }
            // Kiểm tra sự tồn tại của danh mục trước khi cập nhật
            if (!_danhMucDAL.KiemTraTonTaiMaDM(danhMuc.MaDM))
            {
                throw new ArgumentException("Danh mục này không tồn tại trong hệ thống.");
            }

            return _danhMucDAL.CapNhatDanhMuc(danhMuc);
        }

        // Thực hiện xóa danh mục khỏi hệ thống
        public bool XoaDanhMuc(string maDM)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(maDM))
            {
                throw new ArgumentException("Mã danh mục cần xóa không được để trống.");
            }

            // Kiểm tra sự tồn tại của danh mục
            if (!_danhMucDAL.KiemTraTonTaiMaDM(maDM))
            {
                throw new ArgumentException("Danh mục này không tồn tại hoặc đã bị xóa.");
            }
            
            return _danhMucDAL.XoaDanhMuc(maDM);
        }

        // Tìm kiếm danh mục dựa trên từ khóa
        public DataTable TimKiemDanhMuc(string tuKhoa)
        {
            return _danhMucDAL.TimKiemDanhMuc(tuKhoa);
        }
    }
}