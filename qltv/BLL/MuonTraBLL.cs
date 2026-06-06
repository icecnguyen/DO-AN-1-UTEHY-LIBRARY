using System;
using System.Data;
using qltv.DAL;
using qltv.DTO;

namespace qltv.BLL
{
    public class MuonTraBLL
    {
        // Khởi tạo đối tượng DAL để tương tác với cơ sở dữ liệu mượn trả
        private MuonTraDAL _muonTraDAL = new MuonTraDAL();

        // Lấy danh sách toàn bộ phiếu mượn sách
        public DataTable LayTatCaPhieuMuon()
        {
            return _muonTraDAL.LayTatCaPhieuMuon();
        }

        // Tìm kiếm phiếu mượn sách theo từ khóa
        public DataTable TimKiemPhieuMuon(string tuKhoa)
        {
            return _muonTraDAL.TimKiemPhieuMuon(tuKhoa);
        }

        // Xử lý nghiệp vụ khi độc giả mượn sách
        public bool MuonSach(MuonTraDTO phieuMuon)
        {
            // 1. Kiểm tra tính hợp lệ của các trường dữ liệu bắt buộc
            if (string.IsNullOrWhiteSpace(phieuMuon.MaPhieu))
            {
                throw new ArgumentException("Mã phiếu không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(phieuMuon.MaDG))
            {
                throw new ArgumentException("Mã độc giả không được để trống.");
            }
            if (string.IsNullOrWhiteSpace(phieuMuon.MaSach))
            {
                throw new ArgumentException("Mã sách không được để trống.");
            }
            
            // Kiểm tra mốc thời gian mượn trả
            if (phieuMuon.NgayHenTra < phieuMuon.NgayMuon)
            {
                throw new ArgumentException("Ngày hẹn trả không thể diễn ra trước ngày mượn.");
            }

            // 2. Kiểm tra sự tồn tại của độc giả và sách trong hệ thống
            if (!_muonTraDAL.KiemTraTonTaiDocGia(phieuMuon.MaDG))
            {
                throw new ArgumentException("Độc giả không tồn tại trong hệ thống.");
            }
            if (!_muonTraDAL.KiemTraTonTaiSach(phieuMuon.MaSach))
            {
                throw new ArgumentException("Sách không tồn tại trong thư viện.");
            }

            // 3. Kiểm tra số lượng tồn kho của sách
            int soLuongTon = _muonTraDAL.LaySoLuongSach(phieuMuon.MaSach);
            if (soLuongTon <= 0)
            {
                throw new ArgumentException("Sách này hiện đã hết trong kho.");
            }

            // 4. Nếu phiếu mượn đã tồn tại, kiểm tra tính nhất quán của độc giả mượn
            if (_muonTraDAL.KiemTraTonTaiPhieuMuon(phieuMuon.MaPhieu))
            {
                string maDGCu = _muonTraDAL.LayDocGiaMuon(phieuMuon.MaPhieu);
                if (maDGCu != null && !maDGCu.Equals(phieuMuon.MaDG, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException($"Phiếu mượn '{phieuMuon.MaPhieu}' đã được lập cho độc giả '{maDGCu}'.");
                }
            }

            // 5. Kiểm tra trùng lặp chi tiết mượn (một phiếu không được mượn cùng 1 cuốn sách nhiều lần)
            if (_muonTraDAL.KiemTraTonTaiChiTietMuon(phieuMuon.MaPhieu, phieuMuon.MaSach))
            {
                throw new ArgumentException("Sách này đã tồn tại trong chi tiết phiếu mượn hiện tại.");
            }

            // 6. Gán mã nhân viên thực hiện thao tác lập phiếu
            string maNV = PhienLamViec.EmployeeID;
            if (string.IsNullOrWhiteSpace(maNV))
            {
                maNV = _muonTraDAL.LayMaNVMacDinh();
            }
            if (string.IsNullOrWhiteSpace(maNV))
            {
                throw new ArgumentException("Lỗi hệ thống: Không xác định được nhân viên lập phiếu.");
            }
            phieuMuon.MaNV = maNV;

            return _muonTraDAL.MuonSach(phieuMuon);
        }

        // Xử lý nghiệp vụ khi độc giả trả sách
        public bool TraSach(string maPhieu, string maSach, DateTime ngayHenTra, DateTime? ngayTraThucTe, string tinhTrang)
        {
            if (string.IsNullOrWhiteSpace(maPhieu) || string.IsNullOrWhiteSpace(maSach))
            {
                throw new ArgumentException("Mã phiếu và mã sách không được để trống khi thực hiện trả sách.");
            }

            // Kiểm tra sự tồn tại của sách trong phiếu mượn tương ứng
            if (!_muonTraDAL.KiemTraTonTaiChiTietMuon(maPhieu, maSach))
            {
                throw new ArgumentException("Chi tiết phiếu mượn không khớp với thông tin sách.");
            }

            // Kiểm tra trạng thái trả sách
            if (ngayTraThucTe.HasValue)
            {
                throw new ArgumentException("Cuốn sách này đã được trả trên hệ thống.");
            }

            // Tính toán tiền phạt nếu trả sách trễ hạn
            DateTime homNay = DateTime.Today;
            decimal tienPhat = 0;
            int soNgayTre = (homNay - ngayHenTra).Days;
            
            if (soNgayTre > 0)
            {
                tienPhat = soNgayTre * 5000;
            }
            if (string.IsNullOrWhiteSpace(tinhTrang))
            {
                tinhTrang = "Bình thường";
            }

            return _muonTraDAL.TraSach(maPhieu, maSach, homNay, tienPhat, tinhTrang);
        }
    }
}