using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace qltv.DAL
{
    // Lớp tiện ích hỗ trợ thực thi các truy vấn và tương tác cơ sở dữ liệu
    public class DbHelper
    {
        // Chuỗi kết nối đến cơ sở dữ liệu SQL Server
        private static string connectionString = @"Server=.;Database=qltv;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Thực thi truy vấn trả về kết quả dạng bảng (DataTable)
        public static DataTable GetData(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        // Thực thi các câu lệnh thay đổi dữ liệu (INSERT, UPDATE, DELETE) và trả về kết quả thành công/thất bại
        public static bool Execute(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}