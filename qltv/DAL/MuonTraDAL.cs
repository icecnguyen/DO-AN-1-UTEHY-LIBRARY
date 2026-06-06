using System;
using System.Data;
using System.Data.SqlClient;
using qltv.DTO;

namespace qltv.DAL
{
    public class MuonTraDAL
    {
        public DataTable LayTatCaPhieuMuon()
        {
            string query = @"
                SELECT 
                    pmt.ma_phieu AS [Mã Phiếu], 
                    pmt.ma_dg AS [Mã Độc Giả], 
                    dg.ho_ten AS [Tên Độc Giả],
                    ctmt.ma_sach AS [Mã Sách], 
                    s.ten_sach AS [Tên Sách],
                    pmt.ngay_lap AS [Ngày Mượn], 
                    ctmt.ngay_hen_tra AS [Ngày Hẹn Trả], 
                    ctmt.ngay_tra_thuc_te AS [Ngày Trả Thực Tế], 
                    ctmt.tien_phat AS [Tiền Phạt],
                    ctmt.tinh_trang AS [Tình Trạng]
                FROM phieu_muon_tra pmt
                JOIN chi_tiet_muon_tra ctmt ON pmt.ma_phieu = ctmt.ma_phieu
                JOIN doc_gia dg ON pmt.ma_dg = dg.ma_dg
                JOIN sach s ON ctmt.ma_sach = s.ma_sach";
            return DbHelper.GetData(query);
        }

        public DataTable TimKiemPhieuMuon(string keyword)
        {
            string query = @"
                SELECT 
                    pmt.ma_phieu AS [Mã Phiếu], 
                    pmt.ma_dg AS [Mã Độc Giả], 
                    dg.ho_ten AS [Tên Độc Giả],
                    ctmt.ma_sach AS [Mã Sách], 
                    s.ten_sach AS [Tên Sách],
                    pmt.ngay_lap AS [Ngày Mượn], 
                    ctmt.ngay_hen_tra AS [Ngày Hẹn Trả], 
                    ctmt.ngay_tra_thuc_te AS [Ngày Trả Thực Tế], 
                    ctmt.tien_phat AS [Tiền Phạt],
                    ctmt.tinh_trang AS [Tình Trạng]
                FROM phieu_muon_tra pmt
                JOIN chi_tiet_muon_tra ctmt ON pmt.ma_phieu = ctmt.ma_phieu
                JOIN doc_gia dg ON pmt.ma_dg = dg.ma_dg
                JOIN sach s ON ctmt.ma_sach = s.ma_sach
                WHERE pmt.ma_phieu LIKE @Keyword 
                   OR pmt.ma_dg LIKE @Keyword 
                   OR dg.ho_ten LIKE @Keyword 
                   OR ctmt.ma_sach LIKE @Keyword 
                   OR s.ten_sach LIKE @Keyword";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };
            return DbHelper.GetData(query, parameters);
        }

        public bool KiemTraTonTaiDocGia(string maDG)
        {
            string query = "SELECT COUNT(*) FROM doc_gia WHERE ma_dg = @MaDG";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaDG", maDG)
            };
            DataTable dt = DbHelper.GetData(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        public bool KiemTraTonTaiSach(string maSach)
        {
            string query = "SELECT COUNT(*) FROM sach WHERE ma_sach = @MaSach";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSach", maSach)
            };
            DataTable dt = DbHelper.GetData(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        public int LaySoLuongSach(string maSach)
        {
            string query = "SELECT so_luong_ton FROM sach WHERE ma_sach = @MaSach";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaSach", maSach)
            };
            DataTable dt = DbHelper.GetData(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["so_luong_ton"]);
            }
            return 0;
        }

        public bool KiemTraTonTaiPhieuMuon(string maPhieu)
        {
            string query = "SELECT COUNT(*) FROM phieu_muon_tra WHERE ma_phieu = @MaPhieu";
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

        public string LayDocGiaMuon(string maPhieu)
        {
            string query = "SELECT ma_dg FROM phieu_muon_tra WHERE ma_phieu = @MaPhieu";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhieu", maPhieu)
            };
            DataTable dt = DbHelper.GetData(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ma_dg"].ToString();
            }
            return null;
        }

        public bool KiemTraTonTaiChiTietMuon(string maPhieu, string maSach)
        {
            string query = "SELECT COUNT(*) FROM chi_tiet_muon_tra WHERE ma_phieu = @MaPhieu AND ma_sach = @MaSach";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaPhieu", maPhieu),
                new SqlParameter("@MaSach", maSach)
            };
            DataTable dt = DbHelper.GetData(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        public string LayMaNVMacDinh()
        {
            string query = "SELECT TOP 1 ma_nv FROM nhan_vien ORDER BY ma_nv ASC";
            DataTable dt = DbHelper.GetData(query);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["ma_nv"].ToString();
            }
            return null;
        }

        public bool MuonSach(MuonTraDTO loan)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Tạo phiếu mượn nếu chưa tồn tại
                        if (!KiemTraTonTaiPhieuMuon(loan.MaPhieu))
                        {
                            string queryPmt = "INSERT INTO phieu_muon_tra (ma_phieu, ma_dg, ma_nv, ngay_lap) VALUES (@MaPhieu, @MaDG, @MaNV, @NgayMuon)";
                            using (SqlCommand cmdPmt = new SqlCommand(queryPmt, conn, trans))
                            {
                                cmdPmt.Parameters.AddWithValue("@MaPhieu", loan.MaPhieu);
                                cmdPmt.Parameters.AddWithValue("@MaDG", loan.MaDG);
                                cmdPmt.Parameters.AddWithValue("@MaNV", loan.MaNV);
                                cmdPmt.Parameters.AddWithValue("@NgayMuon", loan.NgayMuon);
                                cmdPmt.ExecuteNonQuery();
                            }
                        }

                        // 2. Thực thi thêm chi tiết phiếu mượn
                        string queryCtmt = @"
                            INSERT INTO chi_tiet_muon_tra (ma_phieu, ma_sach, ngay_hen_tra, ngay_tra_thuc_te, tinh_trang, tien_phat) 
                            VALUES (@MaPhieu, @MaSach, @NgayHenTra, NULL, @TinhTrang, 0)";
                        using (SqlCommand cmdCtmt = new SqlCommand(queryCtmt, conn, trans))
                        {
                            cmdCtmt.Parameters.AddWithValue("@MaPhieu", loan.MaPhieu);
                            cmdCtmt.Parameters.AddWithValue("@MaSach", loan.MaSach);
                            cmdCtmt.Parameters.AddWithValue("@NgayHenTra", loan.NgayHenTra);
                            cmdCtmt.Parameters.AddWithValue("@TinhTrang", "Đang mượn");
                            cmdCtmt.ExecuteNonQuery();
                        }

                        // 3. Cập nhật giảm số lượng sách trong kho
                        string queryBook = "UPDATE sach SET so_luong_ton = so_luong_ton - 1 WHERE ma_sach = @MaSach";
                        using (SqlCommand cmdBook = new SqlCommand(queryBook, conn, trans))
                        {
                            cmdBook.Parameters.AddWithValue("@MaSach", loan.MaSach);
                            cmdBook.ExecuteNonQuery();
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

        public bool TraSach(string maPhieu, string maSach, DateTime ngayTraThucTe, decimal tienPhat, string tinhTrang)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Update return date and fine
                        string queryCtmt = @"
                            UPDATE chi_tiet_muon_tra 
                            SET ngay_tra_thuc_te = @NgayTra, 
                                tien_phat = @TienPhat, 
                                tinh_trang = @TinhTrang 
                            WHERE ma_phieu = @MaPhieu AND ma_sach = @MaSach";
                        using (SqlCommand cmdCtmt = new SqlCommand(queryCtmt, conn, trans))
                        {
                            cmdCtmt.Parameters.AddWithValue("@MaPhieu", maPhieu);
                            cmdCtmt.Parameters.AddWithValue("@MaSach", maSach);
                            cmdCtmt.Parameters.AddWithValue("@NgayTra", ngayTraThucTe);
                            cmdCtmt.Parameters.AddWithValue("@TienPhat", tienPhat);
                            cmdCtmt.Parameters.AddWithValue("@TinhTrang", (object)tinhTrang ?? DBNull.Value);
                            cmdCtmt.ExecuteNonQuery();
                        }

                        // 2. Increment stock quantity
                        string queryBook = "UPDATE sach SET so_luong_ton = so_luong_ton + 1 WHERE ma_sach = @MaSach";
                        using (SqlCommand cmdBook = new SqlCommand(queryBook, conn, trans))
                        {
                            cmdBook.Parameters.AddWithValue("@MaSach", maSach);
                            cmdBook.ExecuteNonQuery();
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
    }
}