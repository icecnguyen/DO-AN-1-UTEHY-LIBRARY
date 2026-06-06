using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace qltv
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG
            // backdoor bỏ qua đăng nhập để debug nhanh hơn trong quá trình phát triển, chỉ có hiệu lực khi chạy ở chế độ debug
            PhienLamViec.Username = "admin";
            PhienLamViec.Role = 1;
            PhienLamViec.EmployeeID = "123";
            Application.Run(new TrangChu());
#else
            // nếu là release, chạy ứng dụng bình thường
            Application.Run(new DangNhap());
#endif
        }
    }
}