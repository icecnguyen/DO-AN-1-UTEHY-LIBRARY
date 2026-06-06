using System;
using System.Collections.Generic;
using System.Data;
using qltv.DAL;
using qltv.DTO;

namespace qltv.BLL
{
    public class NhapSachBLL
    {
        // Khởi tạo đối tượng DAL để tương tác với cơ sở dữ liệu
        private NhapSachDAL _nhapSachDAL = new NhapSachDAL();

        // Lấy danh sách toàn bộ phiếu nhập sách
        public DataTable LayTatCaPhieuNhap()
        {
            return _nhapSachDAL.LayTatCaPhieuNhap();
        }

        // Lấy chi tiết các cuốn sách trong một phiếu nhập cụ thể
        public DataTable LayChiTietPhieuNhap(string maPhieu)
        {
            if (string.IsNullOrWhiteSpace(maPhieu))
            {
                throw new ArgumentException("Mã phiếu nhập không được để trống.");
            }
                
            return _nhapSachDAL.LayChiTietPhieuNhap(maPhieu);
        }

        // Thực hiện thêm mới phiếu nhập và danh sách chi tiết phiếu nhập
        public bool ThemPhieuNhap(PhieuNhapSachDTO phieuNhap, List<ChiTietPhieuNhapDTO> danhSachChiTiet)
        {
            // Kiểm tra các trường dữ liệu bắt buộc của phiếu nhập
            if (string.IsNullOrWhiteSpace(phieuNhap.MaPhieuNhap))
            {
                throw new ArgumentException("Mã phiếu nhập không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(phieuNhap.MaNV))
            {
                throw new ArgumentException("Mã nhân viên không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(phieuNhap.MaNCC))
            {
                throw new ArgumentException("Mã nhà cung cấp không được để trống.");
            }
            if (danhSachChiTiet == null || danhSachChiTiet.Count == 0)
            {
                throw new ArgumentException("Danh sách chi tiết phiếu nhập không được trống.");
            }

            // Kiểm tra trùng lặp mã phiếu nhập trong cơ sở dữ liệu
            if (_nhapSachDAL.KiemTraTonTaiMaPhieuNhap(phieuNhap.MaPhieuNhap))
            {
                throw new ArgumentException("Mã phiếu nhập đã tồn tại trong hệ thống.");
            }

            // Tính toán tổng tiền của phiếu nhập dựa trên chi tiết sách
            decimal tongTien = 0;
            foreach (var chiTiet in danhSachChiTiet)
            {
                if (string.IsNullOrWhiteSpace(chiTiet.MaSach))
                {
                    throw new ArgumentException("Tồn tại sách không có mã trong chi tiết phiếu nhập.");
                }
                if (chiTiet.SoLuong <= 0)
                {
                    throw new ArgumentException("Số lượng nhập phải lớn hơn 0.");
                }
                if (chiTiet.DonGia <= 0)
                {
                    throw new ArgumentException("Đơn giá nhập sách phải lớn hơn 0.");
                }
                
                // Thành tiền = Số lượng x Đơn giá
                tongTien += (chiTiet.SoLuong * chiTiet.DonGia);
            }
            phieuNhap.TongTien = tongTien;
            phieuNhap.NgayNhap = DateTime.Now; // Gán ngày nhập mặc định là ngày hiện tại

            // Thực thi lưu phiếu nhập và chi tiết thông qua DAL (sử dụng Transaction)
            return _nhapSachDAL.ThemPhieuNhap(phieuNhap, danhSachChiTiet);
        }

        // Xóa một phiếu nhập (DAL sẽ tự động xóa các chi tiết liên quan)
        public bool XoaPhieuNhap(string maPhieu)
        {
            if (string.IsNullOrWhiteSpace(maPhieu))
            {
                throw new ArgumentException("Mã phiếu nhập cần xóa không được để trống.");
            }
                
            // Kiểm tra sự tồn tại của phiếu nhập trước khi xóa
            if (!_nhapSachDAL.KiemTraTonTaiMaPhieuNhap(maPhieu))
            {
                throw new ArgumentException("Phiếu nhập không tồn tại trong hệ thống.");
            }
                
            return _nhapSachDAL.XoaPhieuNhap(maPhieu);
        }

        // Tìm kiếm phiếu nhập theo từ khóa
        public DataTable TimKiemPhieuNhap(string tuKhoa)
        {
            return _nhapSachDAL.TimKiemPhieuNhap(tuKhoa);
        }
    }
}