using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using qltv.DTO;

namespace qltv.DAL
{
    // Lớp truy xuất dữ liệu xử lý thông tin nhập sách
    public class NhapSachDAL
    {
        // Lấy danh sách toàn bộ phiếu nhập sách từ cơ sở dữ liệu
        public DataTable LayTatCaPhieuNhap()
        {
            string query = @"
                SELECT pn.ma_phieu_nhap AS [Mã Phiếu Nhập], 
                       nv.ho_ten AS [Nhân Viên Nhập], 
                       ncc.ten_ncc AS [Nhà Cung Cấp], 
                       pn.ngay_nhap AS [Ngày Nhập], 
                       pn.tong_tien AS [Tổng Tiền] 
                FROM phieu_nhap_sach pn 
                LEFT JOIN nhan_vien nv ON pn.ma_nv = nv.ma_nv 
                LEFT JOIN nha_cung_cap ncc ON pn.ma_ncc = ncc.ma_ncc
                ORDER BY pn.ngay_nhap DESC";
            return DbHelper.GetData(query);
        }

        // Lấy thông tin chi tiết các cuốn sách trong một phiếu nhập cụ thể
        public DataTable LayChiTietPhieuNhap(string maPhieu)
        {
            string query = @"
                SELECT ct.ma_sach AS [Mã Sách], 
                       s.ten_sach AS [Tên Sách], 
                       ct.so_luong AS [Số Lượng], 
                       ct.don_gia AS [Đơn Giá], 
                       (ct.so_luong * ct.don_gia) AS [Thành Tiền] 
                FROM chi_tiet_phieu_nhap ct 
                JOIN sach s ON ct.ma_sach = s.ma_sach 
                WHERE ct.ma_phieu_nhap = @MaPhieu";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhieu", maPhieu)
            };
            return DbHelper.GetData(query, parameters);
        }

        // Kiểm tra sự tồn tại của mã phiếu nhập trong hệ thống
        public bool KiemTraTonTaiMaPhieuNhap(string maPhieu)
        {
            string query = "SELECT COUNT(*) FROM phieu_nhap_sach WHERE ma_phieu_nhap = @MaPhieu";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhieu", maPhieu)
            };
            DataTable dt = DbHelper.GetData(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        // Thực thi thêm mới phiếu nhập và danh sách chi tiết (sử dụng Transaction)
        public bool ThemPhieuNhap(PhieuNhapSachDTO pn, List<ChiTietPhieuNhapDTO> listCt)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Thực thi thêm phiếu nhập sách
                        string queryPn = "INSERT INTO phieu_nhap_sach (ma_phieu_nhap, ma_nv, ma_ncc, ngay_nhap, tong_tien) VALUES (@MaPhieu, @MaNV, @MaNCC, @NgayNhap, @TongTien)";
                        using (SqlCommand cmdPn = new SqlCommand(queryPn, conn, trans))
                        {
                            cmdPn.Parameters.AddWithValue("@MaPhieu", pn.MaPhieuNhap);
                            cmdPn.Parameters.AddWithValue("@MaNV", pn.MaNV);
                            cmdPn.Parameters.AddWithValue("@MaNCC", pn.MaNCC);
                            cmdPn.Parameters.AddWithValue("@NgayNhap", pn.NgayNhap);
                            cmdPn.Parameters.AddWithValue("@TongTien", pn.TongTien);
                            cmdPn.ExecuteNonQuery();
                        }

                        // 2. Thực thi thêm chi tiết phiếu nhập và cập nhật số lượng tồn kho
                        string queryCt = "INSERT INTO chi_tiet_phieu_nhap (ma_phieu_nhap, ma_sach, so_luong, don_gia) VALUES (@MaPhieu, @MaSach, @SoLuong, @DonGia)";
                        string queryUpdateStock = "UPDATE sach SET so_luong_ton = so_luong_ton + @SoLuong, gia_sach = @DonGia WHERE ma_sach = @MaSach";

                        foreach (var ct in listCt)
                        {
                            using (SqlCommand cmdCt = new SqlCommand(queryCt, conn, trans))
                            {
                                cmdCt.Parameters.AddWithValue("@MaPhieu", pn.MaPhieuNhap);
                                cmdCt.Parameters.AddWithValue("@MaSach", ct.MaSach);
                                cmdCt.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                                cmdCt.Parameters.AddWithValue("@DonGia", ct.DonGia);
                                cmdCt.ExecuteNonQuery();
                            }

                            using (SqlCommand cmdStock = new SqlCommand(queryUpdateStock, conn, trans))
                            {
                                cmdStock.Parameters.AddWithValue("@SoLuong", ct.SoLuong);
                                cmdStock.Parameters.AddWithValue("@DonGia", ct.DonGia);
                                cmdStock.Parameters.AddWithValue("@MaSach", ct.MaSach);
                                cmdStock.ExecuteNonQuery();
                            }
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        // Thực thi xóa phiếu nhập sách và hoàn trả số lượng sách tồn kho
        public bool XoaPhieuNhap(string maPhieu)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Lấy toàn bộ sách trong chi tiết để hoàn trả tồn kho
                        List<Tuple<string, int>> items = new List<Tuple<string, int>>();
                        string querySelect = "SELECT ma_sach, so_luong FROM chi_tiet_phieu_nhap WHERE ma_phieu_nhap = @MaPhieu";
                        using (SqlCommand cmdSelect = new SqlCommand(querySelect, conn, trans))
                        {
                            cmdSelect.Parameters.AddWithValue("@MaPhieu", maPhieu);
                            using (SqlDataReader reader = cmdSelect.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    items.Add(new Tuple<string, int>(reader["ma_sach"].ToString(), Convert.ToInt32(reader["so_luong"])));
                                }
                            }
                        }

                        // 2. Hoàn trả số lượng sách tồn kho
                        string queryRevert = "UPDATE sach SET so_luong_ton = so_luong_ton - @SoLuong WHERE ma_sach = @MaSach";
                        foreach (var item in items)
                        {
                            using (SqlCommand cmdRevert = new SqlCommand(queryRevert, conn, trans))
                            {
                                cmdRevert.Parameters.AddWithValue("@SoLuong", item.Item2);
                                cmdRevert.Parameters.AddWithValue("@MaSach", item.Item1);
                                cmdRevert.ExecuteNonQuery();
                            }
                        }

                        // 3. Xóa thông tin phiếu nhập (Chi tiết phiếu sẽ tự động xóa theo khóa ngoại)
                        string queryDel = "DELETE FROM phieu_nhap_sach WHERE ma_phieu_nhap = @MaPhieu";
                        using (SqlCommand cmdDel = new SqlCommand(queryDel, conn, trans))
                        {
                            cmdDel.Parameters.AddWithValue("@MaPhieu", maPhieu);
                            cmdDel.ExecuteNonQuery();
                        }

                        trans.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
                    }
                }
            }
        }

        // Tìm kiếm phiếu nhập theo từ khóa
        public DataTable TimKiemPhieuNhap(string keyword)
        {
            string query = @"
                SELECT pn.ma_phieu_nhap AS [Mã Phiếu Nhập], 
                       nv.ho_ten AS [Nhân Viên Nhập], 
                       ncc.ten_ncc AS [Nhà Cung Cấp], 
                       pn.ngay_nhap AS [Ngày Nhập], 
                       pn.tong_tien AS [Tổng Tiền] 
                FROM phieu_nhap_sach pn 
                LEFT JOIN nhan_vien nv ON pn.ma_nv = nv.ma_nv 
                LEFT JOIN nha_cung_cap ncc ON pn.ma_ncc = ncc.ma_ncc
                WHERE pn.ma_phieu_nhap LIKE @Keyword 
                   OR nv.ho_ten LIKE @Keyword 
                   OR ncc.ten_ncc LIKE @Keyword
                ORDER BY pn.ngay_nhap DESC";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };
            return DbHelper.GetData(query, parameters);
        }
    }
}
