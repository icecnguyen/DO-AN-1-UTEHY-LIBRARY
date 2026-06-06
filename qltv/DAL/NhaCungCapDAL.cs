using System;
using System.Data;
using System.Data.SqlClient;
using qltv.DTO;

namespace qltv.DAL
{
    /// <summary>
    /// Lớp truy xuất dữ liệu (Data Access Layer - DAL) cho phân hệ Nhà Cung Cấp
    /// Thực hiện các truy vấn SQL trực tiếp lên bảng nha_cung_cap
    /// </summary>
    public class NhaCungCapDAL
    {
        // Lấy toàn bộ danh sách nhà cung cấp từ CSDL
        public DataTable LayTatCaNhaCungCap()
        {
            string query = "SELECT ma_ncc AS [Mã NCC], ten_ncc AS [Tên Nhà Cung Cấp], sdt AS [Số Điện Thoại], dia_chi AS [Địa Chỉ], email AS [Email], nguoi_lien_he AS [Người Liên Hệ] FROM nha_cung_cap";
            return DbHelper.GetData(query);
        }

        // Kiểm tra xem Mã nhà cung cấp đã có trong CSDL chưa
        public bool KiemTraTonTaiMaNCC(string maNCC)
        {
            string query = "SELECT COUNT(*) FROM nha_cung_cap WHERE ma_ncc = @MaNCC";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNCC", maNCC)
            };
            DataTable dt = DbHelper.GetData(query, parameters);
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]) > 0;
            }
            return false;
        }

        // Thêm mới bản ghi nhà cung cấp
        public bool ThemNhaCungCap(NhaCungCapDTO ncc)
        {
            string query = "INSERT INTO nha_cung_cap (ma_ncc, ten_ncc, sdt, dia_chi, email, nguoi_lien_he) VALUES (@MaNCC, @TenNCC, @SDT, @DiaChi, @Email, @NguoiLienHe)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNCC", ncc.MaNCC),
                new SqlParameter("@TenNCC", ncc.TenNCC),
                new SqlParameter("@SDT", (object)ncc.SDT ?? DBNull.Value),
                new SqlParameter("@DiaChi", (object)ncc.DiaChi ?? DBNull.Value),
                new SqlParameter("@Email", (object)ncc.Email ?? DBNull.Value),
                new SqlParameter("@NguoiLienHe", (object)ncc.NguoiLienHe ?? DBNull.Value)
            };
            return DbHelper.Execute(query, parameters);
        }

        // Cập nhật thông tin nhà cung cấp
        public bool CapNhatNhaCungCap(NhaCungCapDTO ncc)
        {
            string query = "UPDATE nha_cung_cap SET ten_ncc = @TenNCC, sdt = @SDT, dia_chi = @DiaChi, email = @Email, nguoi_lien_he = @NguoiLienHe WHERE ma_ncc = @MaNCC";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNCC", ncc.MaNCC),
                new SqlParameter("@TenNCC", ncc.TenNCC),
                new SqlParameter("@SDT", (object)ncc.SDT ?? DBNull.Value),
                new SqlParameter("@DiaChi", (object)ncc.DiaChi ?? DBNull.Value),
                new SqlParameter("@Email", (object)ncc.Email ?? DBNull.Value),
                new SqlParameter("@NguoiLienHe", (object)ncc.NguoiLienHe ?? DBNull.Value)
            };
            return DbHelper.Execute(query, parameters);
        }

        // Xóa nhà cung cấp theo mã
        public bool XoaNhaCungCap(string maNCC)
        {
            string query = "DELETE FROM nha_cung_cap WHERE ma_ncc = @MaNCC";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MaNCC", maNCC)
            };
            return DbHelper.Execute(query, parameters);
        }

        // Tìm kiếm nhà cung cấp theo từ khóa
        public DataTable TimKiemNhaCungCap(string keyword)
        {
            string query = "SELECT ma_ncc AS [Mã NCC], ten_ncc AS [Tên Nhà Cung Cấp], sdt AS [Số Điện Thoại], dia_chi AS [Địa Chỉ], email AS [Email], nguoi_lien_he AS [Người Liên Hệ] FROM nha_cung_cap WHERE ma_ncc LIKE @Keyword OR ten_ncc LIKE @Keyword OR sdt LIKE @Keyword OR dia_chi LIKE @Keyword OR email LIKE @Keyword OR nguoi_lien_he LIKE @Keyword";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", "%" + keyword + "%")
            };
            return DbHelper.GetData(query, parameters);
        }
    }
}


