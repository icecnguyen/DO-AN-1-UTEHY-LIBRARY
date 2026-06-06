using System;
using System.Data;
using System.Data.SqlClient;
using qltv.DTO;

namespace qltv.DAL
{
    // Lớp truy xuất dữ liệu xử lý thông tin nhân viên và tài khoản
    public class NhanVienDAL
    {
        // Lấy danh sách toàn bộ nhân viên từ cơ sở dữ liệu
        public DataTable LayTatCaNhanVien()
        {
            string query = @"
                SELECT nv.ma_nv AS [Mã NV], 
                       nv.ho_ten AS [Họ Tên], 
                       nv.ngay_sinh AS [Ngày Sinh], 
                       CASE WHEN nv.gioi_tinh = 1 THEN N'Nam' ELSE N'Nữ' END AS [Giới Tính], 
                       nv.sdt AS [Số Điện Thoại], 
                       nv.cccd AS [CCCD], 
                       nv.email AS [Email], 
                       nv.dia_chi AS [Địa Chỉ], 
                       nv.ngay_vao_lam AS [Ngày Vào Làm], 
                       nv.ten_tk AS [Tài Khoản], 
                       tk.mat_khau AS [Mật Khẩu] 
                FROM nhan_vien nv 
                LEFT JOIN tai_khoan tk ON nv.ten_tk = tk.ten_tk";
            return DbHelper.GetData(query);
        }

        // Tìm kiếm thông tin nhân viên theo từ khóa (mã, tên, số điện thoại, email, v.v.)
        public DataTable TimKiemNhanVien(string keyword)
        {
            string query = @"
                SELECT nv.ma_nv AS [Mã NV], 
                       nv.ho_ten AS [Họ Tên], 
                       nv.ngay_sinh AS [Ngày Sinh], 
                       CASE WHEN nv.gioi_tinh = 1 THEN N'Nam' ELSE N'Nữ' END AS [Giới Tính], 
                       nv.sdt AS [Số Điện Thoại], 
                       nv.cccd AS [CCCD], 
                       nv.email AS [Email], 
                       nv.dia_chi AS [Địa Chỉ], 
                       nv.ngay_vao_lam AS [Ngày Vào Làm], 
                       nv.ten_tk AS [Tài Khoản], 
                       tk.mat_khau AS [Mật Khẩu]
                FROM nhan_vien nv 
                LEFT JOIN tai_khoan tk ON nv.ten_tk = tk.ten_tk
                WHERE nv.ma_nv LIKE @Keyword 
                   OR nv.ho_ten LIKE @Keyword 
                   OR nv.sdt LIKE @Keyword 
                   OR nv.cccd LIKE @Keyword 
                   OR nv.email LIKE @Keyword
                   OR nv.dia_chi LIKE @Keyword
                   OR nv.ten_tk LIKE @Keyword";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };
            return DbHelper.GetData(query, parameters);
        }

        // Kiểm tra sự tồn tại của mã nhân viên trong hệ thống
        public bool KiemTraTonTaiMaNV(string maNV)
        {
            string query = "SELECT COUNT(*) FROM nhan_vien WHERE ma_nv = @MaNV";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNV", maNV)
            };
            DataTable dt = DbHelper.GetData(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        // Kiểm tra sự tồn tại của tên tài khoản đăng nhập trong hệ thống
        public bool KiemTraTonTaiTenTK(string username)
        {
            string query = "SELECT COUNT(*) FROM tai_khoan WHERE ten_tk = @Username";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username)
            };
            DataTable dt = DbHelper.GetData(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        // Kiểm tra sự tồn tại của Căn cước công dân (tránh trùng lặp khi thêm hoặc cập nhật)
        public bool KiemTraTonTaiCCCD(string cccd, string excludeMaNV = null)
        {
            string query;
            SqlParameter[] parameters;
            if (string.IsNullOrEmpty(excludeMaNV))
            {
                query = "SELECT COUNT(*) FROM nhan_vien WHERE cccd = @CCCD";
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@CCCD", cccd)
                };
            }
            else
            {
                query = "SELECT COUNT(*) FROM nhan_vien WHERE cccd = @CCCD AND ma_nv != @ExcludeMaNV";
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@CCCD", cccd),
                    new SqlParameter("@ExcludeMaNV", excludeMaNV)
                };
            }
            DataTable dt = DbHelper.GetData(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        // Thực thi thêm mới nhân viên và tài khoản cấp phát (sử dụng Transaction)
        public bool ThemNhanVien(NhanVienDTO emp)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string queryTk = "INSERT INTO tai_khoan (ten_tk, mat_khau, phan_quyen) VALUES (@Username, @Password, @Role)";
                        using (SqlCommand cmdTk = new SqlCommand(queryTk, conn, trans))
                        {
                            cmdTk.Parameters.AddWithValue("@Username", emp.TenTK);
                            cmdTk.Parameters.AddWithValue("@Password", emp.MatKhau);
                            cmdTk.Parameters.AddWithValue("@Role", 2);
                            cmdTk.ExecuteNonQuery();
                        }

                        string queryNv = "INSERT INTO nhan_vien (ma_nv, ho_ten, ngay_sinh, gioi_tinh, sdt, cccd, email, dia_chi, ngay_vao_lam, ten_tk) VALUES (@MaNV, @HoTen, @NgaySinh, @GioiTinh, @SDT, @CCCD, @Email, @DiaChi, @NgayVaoLam, @TenTK)";
                        using (SqlCommand cmdNv = new SqlCommand(queryNv, conn, trans))
                        {
                            cmdNv.Parameters.AddWithValue("@MaNV", emp.MaNV);
                            cmdNv.Parameters.AddWithValue("@HoTen", emp.HoTen);
                            cmdNv.Parameters.AddWithValue("@NgaySinh", (object)emp.NgaySinh ?? DBNull.Value);
                            cmdNv.Parameters.AddWithValue("@GioiTinh", (object)emp.GioiTinh ?? DBNull.Value);
                            cmdNv.Parameters.AddWithValue("@SDT", (object)emp.SDT ?? DBNull.Value);
                            cmdNv.Parameters.AddWithValue("@CCCD", (object)emp.CCCD ?? DBNull.Value);
                            cmdNv.Parameters.AddWithValue("@Email", (object)emp.Email ?? DBNull.Value);
                            cmdNv.Parameters.AddWithValue("@DiaChi", (object)emp.DiaChi ?? DBNull.Value);
                            cmdNv.Parameters.AddWithValue("@NgayVaoLam", (object)emp.NgayVaoLam ?? DBNull.Value);
                            cmdNv.Parameters.AddWithValue("@TenTK", emp.TenTK);
                            cmdNv.ExecuteNonQuery();
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

        // Thực thi cập nhật thông tin nhân viên và thay đổi tài khoản nếu có (sử dụng Transaction)
        public bool CapNhatNhanVien(NhanVienDTO emp)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Truy xuất tên tài khoản hiện tại của nhân viên
                        string oldUsername = null;
                        string queryGetOld = "SELECT ten_tk FROM nhan_vien WHERE ma_nv = @MaNV";
                        using (SqlCommand cmdGetOld = new SqlCommand(queryGetOld, conn, trans))
                        {
                            cmdGetOld.Parameters.AddWithValue("@MaNV", emp.MaNV);
                            object obj = cmdGetOld.ExecuteScalar();
                            if (obj != DBNull.Value && obj != null)
                            {
                                oldUsername = obj.ToString();
                            }
                        }

                        // 2. Xử lý logic thay đổi hoặc cấp mới tài khoản
                        if (!string.IsNullOrEmpty(emp.TenTK))
                        {
                            if (oldUsername == null)
                            {
                                // Thực thi thêm tài khoản mới nếu chưa tồn tại
                                // Kiểm tra tên tài khoản mới đã tồn tại chưa
                                string queryCheck = "SELECT COUNT(*) FROM tai_khoan WHERE ten_tk = @Username";
                                using (SqlCommand cmdCheck = new SqlCommand(queryCheck, conn, trans))
                                {
                                    cmdCheck.Parameters.AddWithValue("@Username", emp.TenTK);
                                    if (Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0)
                                    {
                                        throw new ArgumentException("Tên tài khoản mới đã tồn tại trong hệ thống.");
                                    }
                                }

                                // Thực thi thêm mới tài khoản vào cơ sở dữ liệu
                                string queryIns = "INSERT INTO tai_khoan (ten_tk, mat_khau, phan_quyen) VALUES (@Username, @Password, @Role)";
                                using (SqlCommand cmdIns = new SqlCommand(queryIns, conn, trans))
                                {
                                    cmdIns.Parameters.AddWithValue("@Username", emp.TenTK);
                                    cmdIns.Parameters.AddWithValue("@Password", emp.MatKhau);
                                    cmdIns.Parameters.AddWithValue("@Role", 2);
                                    cmdIns.ExecuteNonQuery();
                                }
                            }
                            else if (!oldUsername.Equals(emp.TenTK, StringComparison.OrdinalIgnoreCase))
                            {
                                // Trường hợp tên tài khoản bị thay đổi
                                // Kiểm tra sự tồn tại của tên tài khoản mới
                                string queryCheck = "SELECT COUNT(*) FROM tai_khoan WHERE ten_tk = @Username";
                                using (SqlCommand cmdCheck = new SqlCommand(queryCheck, conn, trans))
                                {
                                    cmdCheck.Parameters.AddWithValue("@Username", emp.TenTK);
                                    if (Convert.ToInt32(cmdCheck.ExecuteScalar()) > 0)
                                    {
                                        throw new ArgumentException("Tên tài khoản mới đã tồn tại trong hệ thống.");
                                    }
                                }

                                // Vô hiệu hóa liên kết tài khoản cũ trong bảng nhân viên trước khi xóa tài khoản
                                string queryNull = "UPDATE nhan_vien SET ten_tk = NULL WHERE ma_nv = @MaNV";
                                using (SqlCommand cmdNull = new SqlCommand(queryNull, conn, trans))
                                {
                                    cmdNull.Parameters.AddWithValue("@MaNV", emp.MaNV);
                                    cmdNull.ExecuteNonQuery();
                                }

                                // Khởi tạo tài khoản mới trong bảng tài khoản
                                string queryIns = "INSERT INTO tai_khoan (ten_tk, mat_khau, phan_quyen) VALUES (@Username, @Password, @Role)";
                                using (SqlCommand cmdIns = new SqlCommand(queryIns, conn, trans))
                                {
                                    cmdIns.Parameters.AddWithValue("@Username", emp.TenTK);
                                    cmdIns.Parameters.AddWithValue("@Password", emp.MatKhau);
                                    cmdIns.Parameters.AddWithValue("@Role", 2);
                                    cmdIns.ExecuteNonQuery();
                                }

                                // Cập nhật liên kết nhân viên với tài khoản mới tạo
                                string queryLink = "UPDATE nhan_vien SET ten_tk = @Username WHERE ma_nv = @MaNV";
                                using (SqlCommand cmdLink = new SqlCommand(queryLink, conn, trans))
                                {
                                    cmdLink.Parameters.AddWithValue("@Username", emp.TenTK);
                                    cmdLink.Parameters.AddWithValue("@MaNV", emp.MaNV);
                                    cmdLink.ExecuteNonQuery();
                                }

                                // Thực thi xóa tài khoản cũ (ngoại trừ tài khoản admin mặc định)
                                if (!oldUsername.Equals("admin", StringComparison.OrdinalIgnoreCase))
                                {
                                    string queryDel = "DELETE FROM tai_khoan WHERE ten_tk = @OldUsername";
                                    using (SqlCommand cmdDel = new SqlCommand(queryDel, conn, trans))
                                    {
                                        cmdDel.Parameters.AddWithValue("@OldUsername", oldUsername);
                                        cmdDel.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                // Trường hợp tên tài khoản không thay đổi
                                // Chỉ thực hiện cập nhật lại mật khẩu
                                string queryUpdTk = "UPDATE tai_khoan SET mat_khau = @Password WHERE ten_tk = @Username";
                                using (SqlCommand cmdUpdTk = new SqlCommand(queryUpdTk, conn, trans))
                                {
                                    cmdUpdTk.Parameters.AddWithValue("@Password", emp.MatKhau);
                                    cmdUpdTk.Parameters.AddWithValue("@Username", emp.TenTK);
                                    cmdUpdTk.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            // Xử lý khi trường tài khoản bị làm trống (để null liên kết tài khoản)
                            if (oldUsername != null)
                            {
                                string queryNull = "UPDATE nhan_vien SET ten_tk = NULL WHERE ma_nv = @MaNV";
                                using (SqlCommand cmdNull = new SqlCommand(queryNull, conn, trans))
                                {
                                    cmdNull.Parameters.AddWithValue("@MaNV", emp.MaNV);
                                    cmdNull.ExecuteNonQuery();
                                }

                                if (!oldUsername.Equals("admin", StringComparison.OrdinalIgnoreCase))
                                {
                                    string queryDel = "DELETE FROM tai_khoan WHERE ten_tk = @OldUsername";
                                    using (SqlCommand cmdDel = new SqlCommand(queryDel, conn, trans))
                                    {
                                        cmdDel.Parameters.AddWithValue("@OldUsername", oldUsername);
                                        cmdDel.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        // 3. Thực thi cập nhật các thông tin cá nhân còn lại của nhân viên
                        string queryNv = "UPDATE nhan_vien SET ho_ten = @HoTen, ngay_sinh = @NgaySinh, gioi_tinh = @GioiTinh, sdt = @SDT, cccd = @CCCD, email = @Email, dia_chi = @DiaChi, ngay_vao_lam = @NgayVaoLam WHERE ma_nv = @MaNV";
                        using (SqlCommand cmdNv = new SqlCommand(queryNv, conn, trans))
                        {
                            cmdNv.Parameters.AddWithValue("@HoTen", emp.HoTen);
                            cmdNv.Parameters.AddWithValue("@NgaySinh", (object)emp.NgaySinh ?? DBNull.Value);
                            cmdNv.Parameters.AddWithValue("@GioiTinh", (object)emp.GioiTinh ?? DBNull.Value);
                            cmdNv.Parameters.AddWithValue("@SDT", (object)emp.SDT ?? DBNull.Value);
                            cmdNv.Parameters.AddWithValue("@CCCD", (object)emp.CCCD ?? DBNull.Value);
                            cmdNv.Parameters.AddWithValue("@Email", (object)emp.Email ?? DBNull.Value);
                            cmdNv.Parameters.AddWithValue("@DiaChi", (object)emp.DiaChi ?? DBNull.Value);
                            cmdNv.Parameters.AddWithValue("@NgayVaoLam", (object)emp.NgayVaoLam ?? DBNull.Value);
                            cmdNv.Parameters.AddWithValue("@MaNV", emp.MaNV);
                            cmdNv.ExecuteNonQuery();
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

        // Thực thi xóa nhân viên và tài khoản liên kết
        public bool XoaNhanVien(string maNV, string tenTK)
        {
            using (SqlConnection conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        string queryNv = "DELETE FROM nhan_vien WHERE ma_nv = @MaNV";
                        using (SqlCommand cmdNv = new SqlCommand(queryNv, conn, trans))
                        {
                            cmdNv.Parameters.AddWithValue("@MaNV", maNV);
                            cmdNv.ExecuteNonQuery();
                        }

                        if (!string.IsNullOrEmpty(tenTK))
                        {
                            string queryTk = "DELETE FROM tai_khoan WHERE ten_tk = @TenTK";
                            using (SqlCommand cmdTk = new SqlCommand(queryTk, conn, trans))
                            {
                                cmdTk.Parameters.AddWithValue("@TenTK", tenTK);
                                cmdTk.ExecuteNonQuery();
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
    }
}
