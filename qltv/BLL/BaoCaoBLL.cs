using System;
using System.Data;
using qltv.DAL;

namespace qltv.BLL
{
    public class BaoCaoBLL
    {
        // Khởi tạo đối tượng DAL để tương tác với cơ sở dữ liệu
        private BaoCaoDAL _baoCaoDAL = new BaoCaoDAL();

        // 1. Lấy thông tin tổng quan về kho sách
        public DataTable LayTongQuanKho()
        {
            return _baoCaoDAL.LayTongQuanKho();
        }

        // 2. Lấy danh sách các cuốn sách sắp hết trong kho
        public DataTable LaySachSapHet()
        {
            return _baoCaoDAL.LaySachSapHet();
        }

        // 3. Lấy danh sách sách phân loại theo danh mục
        public DataTable LaySachTheoDanhMuc()
        {
            return _baoCaoDAL.LaySachTheoDanhMuc();
        }

        // 4. Lấy danh sách thẻ độc giả đã hết hạn
        public DataTable LayTheHetHan()
        {
            return _baoCaoDAL.LayTheHetHan();
        }

        // 5. Lấy danh sách độc giả đang bị cấm mượn
        public DataTable LayDocGiaBiCam()
        {
            return _baoCaoDAL.LayDocGiaBiCam();
        }

        // 6. Lấy danh sách sách quá hạn chưa trả
        public DataTable LaySachQuaHan()
        {
            return _baoCaoDAL.LaySachQuaHan(DateTime.Now);
        }

        // 7. Lấy danh sách sách được mượn nhiều nhất trong một khoảng thời gian
        public DataTable LayTopSachMuonNhieuNhat(DateTime tuNgay, DateTime denNgay)
        {
            KiemTraNgay(tuNgay, denNgay);
            return _baoCaoDAL.LayTopSachMuon(tuNgay, denNgay);
        }

        // 8. Lấy báo cáo doanh thu tiền phạt trong một khoảng thời gian
        public DataTable LayDoanhThuTienPhat(DateTime tuNgay, DateTime denNgay)
        {
            KiemTraNgay(tuNgay, denNgay);
            return _baoCaoDAL.LayDoanhThuPhat(tuNgay, denNgay);
        }

        // 9. Lấy báo cáo chi phí nhập sách trong một khoảng thời gian
        public DataTable LayChiPhiNhapSach(DateTime tuNgay, DateTime denNgay)
        {
            KiemTraNgay(tuNgay, denNgay);
            return _baoCaoDAL.LayChiPhiNhapSach(tuNgay, denNgay);
        }

        // 10. Trích xuất dữ liệu để in phiếu mượn sách
        public DataTable LayDuLieuInPhieuMuon(string maPhieu)
        {
            if (string.IsNullOrEmpty(maPhieu))
            {
                throw new ArgumentException("Không thể in do mã phiếu trống.");
            }
            return _baoCaoDAL.LayDuLieuInPhieuMuon(maPhieu);
        }

        // 11. Trích xuất dữ liệu để in biên lai thu tiền phạt
        public DataTable LayDuLieuInBienLaiPhat(string maPhieu)
        {
            if (string.IsNullOrEmpty(maPhieu))
            {
                throw new ArgumentException("Không thể in do mã biên lai trống.");
            }
            return _baoCaoDAL.LayDuLieuInBienLaiPhat(maPhieu);
        }

        // 12. Trích xuất dữ liệu để in phiếu nhập sách
        public DataTable LayDuLieuInPhieuNhap(string maPhieuNhap)
        {
            if (string.IsNullOrEmpty(maPhieuNhap))
            {
                throw new ArgumentException("Không thể in do mã phiếu nhập trống.");
            }
            return _baoCaoDAL.LayDuLieuInPhieuNhap(maPhieuNhap);
        }

        // Kiểm tra tính hợp lệ của mốc thời gian (Từ ngày phải nhỏ hơn hoặc bằng Đến ngày)
        private void KiemTraNgay(DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay > denNgay)
            {
                throw new ArgumentException("Lỗi logic: 'Từ ngày' không được lớn hơn 'Đến ngày'.");
            }
        }
    }
}