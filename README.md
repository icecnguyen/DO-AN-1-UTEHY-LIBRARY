# HỆ THỐNG QUẢN LÝ THƯ VIỆN UTEHY (UTEHY Library Management System)

Dự án **Hệ thống Quản lý Thư viện UTEHY** đã hoàn thành xây dựng và bàn giao 100% các tính năng nghiệp vụ. Đây là ứng dụng Desktop chuyên nghiệp dành cho cán bộ thư viện trường Đại học Sư phạm Kỹ thuật Hưng Yên (UTEHY).

---

## 📑 MỤC LỤC
1. [Tổng quan dự án](#-tổng-quan-dự-án)
2. [Công nghệ sử dụng](#-công-nghệ-sử-dụng)
3. [Cấu trúc thư mục mã nguồn](#-cấu-trúc-thư-mục-mã-nguồn)
4. [Mô hình Cơ sở dữ liệu (Database Schema)](#-mô-hình-cơ-sở-dữ-liệu-database-schema)
5. [Hướng dẫn cài đặt & Chạy dự án](#-hướng-dẫn-cài-đặt--chạy-dự-án)
6. [Đóng gói & Phát hành (Installer)](#-đóng-gói--phát-hành-installer)
7. [Trạng thái hoàn thành (Project Status)](#-trạng-thái-hoàn-thành-project-status)

---

## 🌟 TỔNG QUAN DỰ ÁN
Dự án **UTEHY Library Management System** được thiết kế nhằm hiện đại hóa quy trình quản trị nội bộ thư viện UTEHY, chuyển đổi phương pháp ghi chép sổ sách thủ công sang quản trị số hóa.

Hệ thống hỗ trợ đầy đủ các phân hệ nghiệp vụ cốt lõi:
*   **Xác thực & Phân quyền:** Đăng nhập an toàn, tự động phân quyền giữa vai trò Quản trị viên (Admin) và Nhân viên (Thủ thư).
*   **Quản lý danh mục:** Quản lý thông tin chi tiết Sách, Thể loại/Danh mục sách, và đối tác Nhà cung cấp.
*   **Quản lý độc giả:** Quản lý hồ sơ độc giả (Sinh viên, Giảng viên UTEHY), trạng thái thẻ và thời hạn thẻ.
*   **Quản lý nhân viên (Chỉ Admin):** Quản lý hồ sơ nhân sự, tự động cấp tài khoản tương ứng khi thêm mới nhân viên.
*   **Nghiệp vụ Mượn - Trả:** Lập phiếu mượn, xử lý trả sách và tự động tính tiền phạt trễ hạn hoặc hỏng sách.
*   **Quản lý Nhập sách:** Ghi nhận lịch sử nhập hàng và tự động cập nhật số lượng tồn kho thực tế của sách.
*   **Báo cáo & Thống kê:** Tổng hợp 9 biểu mẫu báo cáo (Kho sách, Doanh thu tiền phạt, Chi phí nhập sách...), hỗ trợ xuất dữ liệu ra Excel và in chứng từ.

---

## 💻 CÔNG NGHỆ SỬ DỤNG
*   **Ngôn ngữ lập trình:** C# (.NET Framework v4.8.1)
*   **Thư viện giao diện (UI Library):** Guna2 UI (`Guna.UI2.WinForms`) - Thiết kế phẳng, hiện đại và hỗ trợ bo góc, hiệu ứng hover mượt mà.
*   **Hệ quản trị CSDL:** Microsoft SQL Server
*   **Kết nối dữ liệu:** ADO.NET (`System.Data.SqlClient`) qua lớp tĩnh `DbHelper.cs`.
*   **Công cụ đóng gói:** Microsoft Visual Studio Installer Projects (Tạo file cài đặt tự động `.msi`).

---

## 📂 CẤU TRÚC THƯ MỤC MÃ NGUỒN
Mã nguồn dự án được tổ chức theo mô hình phân tầng gọn gàng và khoa học:
```text
qltv/
├── BLL/                    # Business Logic Layer (Xử lý nghiệp vụ & ràng buộc dữ liệu)
├── DAL/                    # Data Access Layer (Truy cập dữ liệu & thực thi SQL)
├── DTO/                    # Data Transfer Object (Mô hình hóa các thực thể)
├── Properties/             # Tài nguyên hệ thống và thông tin dự án
├── Program.cs              # Điểm khởi chạy ứng dụng (Start với form DangNhap)
├── DangNhap.cs / .Designer.cs # Form Đăng nhập
├── TrangChu.cs / .Designer.cs  # Form Trang chủ điều hướng (Chứa Sidebar & Panel điều khiển)
│
├── QuanLySach.cs              # [UserControl] Giao diện Quản lý Sách
├── QuanLyDocGia.cs            # [UserControl] Giao diện Quản lý Độc giả
├── QuanLyNhanVien.cs          # [UserControl] Giao diện Quản lý Nhân viên
├── QuanLyDanhMuc.cs         # [UserControl] Giao diện Quản lý Danh mục sách
├── QuanLyNhaCungCap.cs          # [UserControl] Giao diện Quản lý Nhà cung cấp
├── QuanLyMuonTra.cs       # [UserControl] Giao diện Quản lý Mượn - Trả sách
├── QuanLyBaoCao.cs            # [UserControl] Giao diện Báo cáo thống kê
│
├── schema.sql              # Script SQL tạo CSDL và bảng dữ liệu mẫu
├── packages.config         # Danh sách thư viện NuGet đã cài đặt
├── qltv.csproj             # File dự án Visual Studio
└── qltv.sln                # File Solution chính kết nối dự án chạy và dự án Setup
```

---

## 🗄️ MÔ HÌNH CƠ SỞ DỮ LIỆU (DATABASE SCHEMA)
Cơ sở dữ liệu của dự án có tên là `qltv`. Cấu trúc các bảng dữ liệu chính được định nghĩa trong file `schema.sql` gồm:
1.  `tai_khoan`: Quản lý tài khoản đăng nhập (Phân quyền `1`: Admin, `2`: Thủ thư).
2.  `nhan_vien`: Hồ sơ nhân viên liên kết 1-1 với tài khoản đăng nhập.
3.  `doc_gia`: Hồ sơ sinh viên, giảng viên mượn sách.
4.  `danh_muc`: Phân loại thể loại sách.
5.  `nha_cung_cap`: Thông tin đối tác cung cấp sách.
6.  `sach`: Quản lý thông tin sách và số lượng tồn kho.
7.  `phieu_muon_tra`: Giao dịch mượn trả tổng quát.
8.  `chi_tiet_muon_tra`: Chi tiết sách mượn, ngày hẹn trả, ngày trả thực tế và tiền phạt.
9.  `phieu_nhap_sach` & `chi_tiet_phieu_nhap`: Quản lý các đợt nhập sách mới từ đối tác.

---

## 🚀 HƯỚNG DẪN CÀI ĐẶT & CHẠY DỰ ÁN

Hãy thực hiện tuần tự các bước sau để chạy dự án trên máy tính mới:

### Bước 1: Khôi phục Cơ sở dữ liệu SQL Server
1. Mở phần mềm **SQL Server Management Studio (SSMS)**.
2. Mở file `schema.sql` đính kèm trong thư mục dự án.
3. Nhấn **Execute (F5)** để tự động tạo Database `qltv` cùng toàn bộ bảng dữ liệu và dữ liệu mẫu thử nghiệm.

### Bước 2: Thiết lập Chuỗi kết nối Database
Mở file `DAL/DbHelper.cs` và cập nhật Server kết nối tương ứng với SQL Server của bạn:
```csharp
private static string connectionString = @"Server=TEN_MAY_TINH_CUA_BAN;Database=qltv;Integrated Security=True;TrustServerCertificate=True;";
```
*(Nếu máy tính của bạn sử dụng tài khoản SQL Server Express mặc định, có thể dùng `Server=.` hoặc `Server=localhost`).*

### Bước 3: Mở Solution và Phục hồi NuGet
1. Mở Visual Studio (phiên bản 2019 hoặc 2022).
2. Mở file `qltv.sln`.
3. Nhấp chuột phải vào Solution `qltv` bên cột *Solution Explorer* và chọn **Restore NuGet Packages** để tự động tải về thư viện Guna2 UI.

---

## 📦 ĐÓNG GÓI & PHÁT HÀNH (INSTALLER)
Dự án tích hợp sẵn một Project Setup tên là **`qltv_build`** dùng để đóng gói thành bộ cài đặt tự động cho người dùng cuối:
1. Thiết lập cấu hình chạy của Visual Studio ở chế độ **`Release`** và nền tảng **`x64`**.
2. Nhấp chuột phải vào dự án **`qltv_build`** và chọn **`Build`**.
3. Sau khi quá trình biên dịch hoàn tất thành công, bạn sẽ tìm thấy file cài đặt dạng bộ cài tại đường dẫn:
   📂 `[Thư_mục_gốc_dự_án]/qltv_build/Release/qltv_build.msi` và `setup.exe`.

---

## 🟢 TRẠNG THÁI HOÀN THÀNH (PROJECT STATUS)
Dự án đã **hoàn thành 100%** tất cả các nghiệp vụ chức năng theo yêu cầu đặc tả đề tài:
*   **Hoàn chỉnh mô hình 3 lớp (3-Tier):** Tách biệt hoàn toàn giao diện (GUI), lớp xử lý nghiệp vụ (BLL) và lớp truy cập CSDL (DAL).
*   **Chuẩn hóa phân quyền đăng nhập:** Thủ thư đăng nhập sẽ bị làm mờ nút Quản lý nhân viên trên Sidebar, bấm vào hiển thị thông báo chặn quyền truy cập. Đồng thời chặn Thủ thư xem báo cáo tài chính.
*   **Vận hành CRUD mượt mà:** Tất cả 6 màn hình quản lý danh mục đều thực hiện Thêm, Sửa, Xóa, Lưu và Hủy dữ liệu trực tiếp vào SQL Server thông qua các Transaction an toàn.
*   **Tự động cập nhật tồn kho:** Tự động trừ tồn kho sách khi lập phiếu mượn, cộng lại tồn kho khi trả sách và tăng tồn kho tương ứng khi lập phiếu nhập sách mới.
*   **Tự động tính tiền phạt:** So sánh chênh lệch giữa ngày trả thực tế và ngày hẹn trả để tính chính xác số tiền phạt quá hạn.
*   **Báo cáo & In ấn dự phòng:** Hiển thị 9 loại báo cáo động trên lưới dữ liệu, hỗ trợ xuất Excel và in ấn chứng từ trực tiếp qua giao diện xem trước tích hợp cao cấp (Fallback Grid Viewer) mà không cần cài đặt Crystal Report Runtime phức tạp.


