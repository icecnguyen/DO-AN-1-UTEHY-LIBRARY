-- Tạo cơ sở dữ liệu
CREATE DATABASE qltv;
GO
USE qltv;
GO

-- 1. Bảng Tài khoản (Hỗ trợ phân quyền hệ thống)
CREATE TABLE tai_khoan (
    ten_tk VARCHAR(50) PRIMARY KEY,
    mat_khau VARCHAR(255) NOT NULL, 
    phan_quyen INT NOT NULL -- 1: Admin, 2: Thủ thư
);

-- 2. Bảng Nhân viên (Gắn liền với tài khoản theo quan hệ 1:1 hoặc 1:n)
CREATE TABLE nhan_vien (
    ma_nv VARCHAR(20) PRIMARY KEY,
    ho_ten NVARCHAR(100) NOT NULL,
    ngay_sinh DATE,
    gioi_tinh BIT, -- 1: Nam, 0: Nữ
    cccd VARCHAR(12) UNIQUE,
    sdt VARCHAR(10),
    email VARCHAR(100),
    dia_chi NVARCHAR(255),
    ngay_vao_lam DATETIME DEFAULT GETDATE(),
    ten_tk VARCHAR(50) CONSTRAINT FK_NV_TK FOREIGN KEY REFERENCES tai_khoan(ten_tk)
);

-- 3. Bảng Độc giả (Sinh viên/Giảng viên UTEHY)
CREATE TABLE doc_gia (
    ma_dg VARCHAR(20) PRIMARY KEY,
    ho_ten NVARCHAR(100) NOT NULL,
    ngay_sinh DATE,
    gioi_tinh BIT,
    khoa NVARCHAR(100),
    sdt VARCHAR(10),
    email VARCHAR(100),
    ngay_het_han DATETIME,
    trang_thai INT DEFAULT 1 -- 1: Hoạt động, 0: Khóa
);

-- 4. Bảng Danh mục (Phân loại sách)
CREATE TABLE danh_muc (
    ma_dm VARCHAR(20) PRIMARY KEY,
    ten_dm NVARCHAR(100) NOT NULL,
    mo_ta NVARCHAR(255)
);

-- 5. Bảng Nhà cung cấp
CREATE TABLE nha_cung_cap (
    ma_ncc VARCHAR(20) PRIMARY KEY,
    ten_ncc NVARCHAR(100) NOT NULL,
    sdt VARCHAR(10),
    dia_chi NVARCHAR(255),
    email VARCHAR(100),
    nguoi_lien_he NVARCHAR(100)
);

-- 6. Bảng Sách (Bổ sung thuộc tính giá sách và số lượng tồn)
CREATE TABLE sach (
    ma_sach VARCHAR(20) PRIMARY KEY,
    ten_sach NVARCHAR(200) NOT NULL,
    tac_gia NVARCHAR(100),
    nha_xb NVARCHAR(100),
    nam_xb INT,
    ma_dm VARCHAR(20) CONSTRAINT FK_Sach_DM FOREIGN KEY REFERENCES danh_muc(ma_dm),
    so_luong_ton INT DEFAULT 0 CONSTRAINT CK_SoLuong CHECK (so_luong_ton >= 0),
    gia_sach DECIMAL(18, 2)
);

-- 7. Bảng Phiếu mượn trả
CREATE TABLE phieu_muon_tra (
    ma_phieu VARCHAR(20) PRIMARY KEY,
    ma_dg VARCHAR(20) CONSTRAINT FK_Phieu_DG FOREIGN KEY REFERENCES doc_gia(ma_dg),
    ma_nv VARCHAR(20) CONSTRAINT FK_Phieu_NV FOREIGN KEY REFERENCES nhan_vien(ma_nv),
    ngay_lap DATETIME DEFAULT GETDATE()
);

-- 8. Chi tiết mượn trả (Quan hệ Composition: Xóa phiếu chính sẽ tự động xóa chi tiết)
CREATE TABLE chi_tiet_muon_tra (
    ma_phieu VARCHAR(20) CONSTRAINT FK_CTMT_Phieu FOREIGN KEY REFERENCES phieu_muon_tra(ma_phieu) ON DELETE CASCADE,
    ma_sach VARCHAR(20) CONSTRAINT FK_CTMT_Sach FOREIGN KEY REFERENCES sach(ma_sach),
    ngay_hen_tra DATETIME NOT NULL,
    ngay_tra_thuc_te DATETIME NULL,
    tinh_trang NVARCHAR(100),
    tien_phat DECIMAL(18, 2) DEFAULT 0,
    PRIMARY KEY (ma_phieu, ma_sach)
);

-- 9. Bảng Phiếu nhập sách
CREATE TABLE phieu_nhap_sach (
    ma_phieu_nhap VARCHAR(20) PRIMARY KEY,
    ma_nv VARCHAR(20) CONSTRAINT FK_PN_NV FOREIGN KEY REFERENCES nhan_vien(ma_nv),
    ma_ncc VARCHAR(20) CONSTRAINT FK_PN_NCC FOREIGN KEY REFERENCES nha_cung_cap(ma_ncc),
    ngay_nhap DATETIME DEFAULT GETDATE(),
    tong_tien DECIMAL(18, 2) DEFAULT 0
);

-- 10. Chi tiết phiếu nhập
CREATE TABLE chi_tiet_phieu_nhap (
    ma_phieu_nhap VARCHAR(20) CONSTRAINT FK_CTPN_Phieu FOREIGN KEY REFERENCES phieu_nhap_sach(ma_phieu_nhap) ON DELETE CASCADE,
    ma_sach VARCHAR(20) CONSTRAINT FK_CTPN_Sach FOREIGN KEY REFERENCES sach(ma_sach),
    so_luong INT NOT NULL CONSTRAINT CK_SLNhap CHECK (so_luong > 0),
    don_gia DECIMAL(18, 2) NOT NULL,
    PRIMARY KEY (ma_phieu_nhap, ma_sach)
);