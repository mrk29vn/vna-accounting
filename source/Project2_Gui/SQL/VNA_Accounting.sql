USE MASTER
 IF EXISTS (SELECT * FROM SYSDATABASES WHERE name = 'VNAAccounting')
 DROP DATABASE VNAAccounting
GO
CREATE DATABASE VNAAccounting
GO
USE VNAAccounting
GO
--USE VNAAccounting
--						1.Account
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type in (N'U'))
DROP TABLE [dbo].[Account]
GO
CREATE TABLE Account
(
	AccountID INT PRIMARY KEY IDENTITY,
	UserName nVARCHAR(200) NOT NULL,
	PassWord nVARCHAR(200) NOT NULL,
	PermissionCode nvarchar(50),
	EmployeeCode nVARCHAR(50),
	Administrator BIT,
	LockedAccount BIT
)
GO
--USE VNAAccounting
--						2.Permission
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Permission]') AND type in (N'U'))
DROP TABLE [dbo].[Permission]
GO
CREATE TABLE Permission
(
	PermissionID INT PRIMARY KEY IDENTITY,
	PermissionCode nVARCHAR(50) NOT NULL,
	PermissionName nVARCHAR(200)
)
GO
--USE VNAAccounting
--						2.PermissionDetail
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PermissionDetail]') AND type in (N'U'))
DROP TABLE [dbo].[PermissionDetail]
GO
CREATE TABLE PermissionDetail
(
	PermissionDetailID INT PRIMARY KEY IDENTITY,
	PermissionCode nVARCHAR(50) NOT NULL,
	FormCode nVARCHAR(50) NOT NULL,
	FormName nVARCHAR(200),
	PerView BIT
)
GO
--USE VNAAccounting
--						3.NhanVien
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NhanVien]') AND type in (N'U'))
DROP TABLE [dbo].[NhanVien]
GO
CREATE TABLE NhanVien
(
	NhanVienID INT PRIMARY KEY IDENTITY,
	MaNhanVien nVARCHAR(50),
	TenNhanVien nVARCHAR(200),
	SCMND nVARCHAR(200),
	SoDienThoai nVARCHAR(200),
	Email nVARCHAR(200),
	GioiTinh nVARCHAR(200),
	NgaySinh nVARCHAR(200),
	DiaChi nVARCHAR(200)
)
GO
--------------------------------------------------------------------------DANH MỤC
--USE VNAAccounting
--						TaiKhoanKeToan
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaiKhoanKeToan]') AND type in (N'U'))
DROP TABLE [dbo].[TaiKhoanKeToan]
GO
CREATE TABLE TaiKhoanKeToan
(
	TaiKhoanKeToanID INT PRIMARY KEY IDENTITY,
	MaTaiKhoanKeToan nVARCHAR(50),
	TenTaiKhoanKeToan nVARCHAR(200),
	TenTaiKhoanKeToanKhac nVARCHAR(200),
	MaNgoaiTe nVARCHAR(50),
	TaiKhoanMe nVARCHAR(200),
	TaiKhoanTheoDoiCongNo nVARCHAR(200),	--0:tài khoản không theo dõi công nợ chi tiết, 1:tài khoản có theo dõi công nợ chi tiết
	TaiKhoanSoCai nVARCHAR(200),			--0:tài khoản không phải là tài khoản sổ cái, 1:tài khoản sổ cái
	LoaiTaiKhoan nVARCHAR(200),				--Ex: 12 - tài khoản tài sản và nợ phải thu (đầu 1,2)
	PhanXuong nVARCHAR(200),
	BoPhanHachToan nVARCHAR(200),
	BacTaiKhoan nVARCHAR(200)
)
GO
USE VNAAccounting
--						Phi
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Phi]') AND type in (N'U'))
DROP TABLE [dbo].[Phi]
GO
CREATE TABLE Phi
(
	PhiID INT PRIMARY KEY IDENTITY,
	MaPhi nVARCHAR(50),
	TenPhi nVARCHAR(200)
)
GO
--------------------------------------------------------------------------DANH MỤC TÀI SẢN CỐ ĐỊNH
--USE VNAAccounting
--						NguonVon
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NguonVon]') AND type in (N'U'))
DROP TABLE [dbo].[NguonVon]
GO
CREATE TABLE NguonVon
(
	NguonVonID INT PRIMARY KEY IDENTITY,
	MaNguonVon nVARCHAR(50),
	TenNguonVon nVARCHAR(200)
)
GO
--USE VNAAccounting
--						LyDoTangGiamTaiSan
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LyDoTangGiamTaiSan]') AND type in (N'U'))
DROP TABLE [dbo].[LyDoTangGiamTaiSan]
GO
CREATE TABLE LyDoTangGiamTaiSan
(
	LyDoTangGiamTaiSanID INT PRIMARY KEY IDENTITY,
	LoaiTangGiamTaiSan BIT,
	MaLyDoTangGiamTaiSan nVARCHAR(50),
	TenLyDoTangGiamTaiSan nVARCHAR(200)
)
GO
--USE VNAAccounting
--						LoaiTaiSan
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoaiTaiSan]') AND type in (N'U'))
DROP TABLE [dbo].[LoaiTaiSan]
GO
CREATE TABLE LoaiTaiSan
(
	LoaiTaiSanID INT PRIMARY KEY IDENTITY,
	MaLoaiTaiSan nVARCHAR(50),
	TenLoaiTaiSan nVARCHAR(200)
)
GO
--USE VNAAccounting
--						PhanNhomTaiSan
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhanNhomTaiSan]') AND type in (N'U'))
DROP TABLE [dbo].[PhanNhomTaiSan]
GO
CREATE TABLE PhanNhomTaiSan
(
	PhanNhomTaiSanID INT PRIMARY KEY IDENTITY,
	MaPhanNhomTaiSan nVARCHAR(50),
	TenPhanNhomTaiSan nVARCHAR(200),
	KieuPhanNhomTaiSan nVARCHAR(50)
)
GO
USE VNAAccounting
--						ThietBi
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ThietBi]') AND type in (N'U'))
DROP TABLE [dbo].[ThietBi]
GO
CREATE TABLE ThietBi
(
	ThietBiID INT PRIMARY KEY IDENTITY,
	MaThietBi nVARCHAR(50),
	TenThietBi nVARCHAR(200)
)
GO
USE VNAAccounting
--						BoPhanSuDung
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BoPhanSuDung]') AND type in (N'U'))
DROP TABLE [dbo].[BoPhanSuDung]
GO
CREATE TABLE BoPhanSuDung
(
	BoPhanSuDungID INT PRIMARY KEY IDENTITY,
	MaBoPhanSuDung nVARCHAR(50),
	TenBoPhanSuDung nVARCHAR(200)
)
GO
USE VNAAccounting
--						Phi
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Phi]') AND type in (N'U'))
DROP TABLE [dbo].[Phi]
GO
CREATE TABLE Phi
(
	PhiID INT PRIMARY KEY IDENTITY,
	MaPhi nVARCHAR(50),
	TenPhi nVARCHAR(200)
)
GO
USE VNAAccounting
--						PhanXuong
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhanXuong]') AND type in (N'U'))
DROP TABLE [dbo].[PhanXuong]
GO
CREATE TABLE PhanXuong
(
	PhanXuongID INT PRIMARY KEY IDENTITY,
	MaPhanXuong nVARCHAR(50),
	TenPhanXuong nVARCHAR(200)
)
GO
USE VNAAccounting
--						BoPhanHachToan
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BoPhanHachToan]') AND type in (N'U'))
DROP TABLE [dbo].[BoPhanHachToan]
GO
CREATE TABLE BoPhanHachToan
(
	BoPhanHachToanID INT PRIMARY KEY IDENTITY,
	MaBoPhanHachToan nVARCHAR(50),
	TenBoPhanHachToan nVARCHAR(200)
)
GO
USE VNAAccounting
--						TaiSan
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TaiSan]') AND type in (N'U'))
DROP TABLE [dbo].[TaiSan]
GO
CREATE TABLE TaiSan
(
	TaiSanID INT PRIMARY KEY IDENTITY,
	MaTaiSan nVARCHAR(50),
	TenTaiSan nVARCHAR(200),
	MaLoaiTaiSan nVARCHAR(50),
	MaLyDoTangGiamTaiSan nVARCHAR(50),
	NgayTangTaiSan Datetime,
	NgayTinhKhauHao Datetime,
	SoKyKhauHao nVARCHAR(200),
	MaBoPhanHachToan nVARCHAR(50),
	MaPhanXuong nVARCHAR(50),
	MaPhi nVARCHAR(50),
	MaBoPhanSuDung nVARCHAR(50),
	TKTaiSan nVARCHAR(50),
	TKKhauHao nVARCHAR(50),
	TKChiPhi nVARCHAR(50),
	PhanNhom1 nVARCHAR(200),
	PhanNhom2 nVARCHAR(200),
	PhanNhom3 nVARCHAR(200),
	
	TenKhac nVARCHAR(200),
	SoHieuTaiSan nVARCHAR(200),
	ThongSoKyThuat nVARCHAR(200),
	NuocSanXuat nVARCHAR(200),
	NamSanXuat nVARCHAR(200),
	NgayDuaVaoSuDung Datetime,
	NgayDinhChiSuDung Datetime,
	LyDoDinhChi nVARCHAR(200),
	GhiChu nVARCHAR(200)
)
GO
USE VNAAccounting
--						ChiTietTaiSan
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChiTietTaiSan]') AND type in (N'U'))
DROP TABLE [dbo].[ChiTietTaiSan]
GO
CREATE TABLE ChiTietTaiSan
(
	ChiTietTaiSanID INT PRIMARY KEY IDENTITY,
	MaTaiSan nVARCHAR(50),
	
	MaNguonVon nVARCHAR(50),
	NgayChungTu Datetime,
	SoChungTu nVARCHAR(200),
	NguyenGia float,
	GiaTriDaKhauHao float,
	GiaTriConLai float,
	GiaTriKhauHao1Ky float,
	DienGiai nVARCHAR(200)
)
GO
USE VNAAccounting
--						PhuTungKemTheo
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhuTungKemTheo]') AND type in (N'U'))
DROP TABLE [dbo].[PhuTungKemTheo]
GO
CREATE TABLE PhuTungKemTheo
(
	PhuTungKemTheoID INT PRIMARY KEY IDENTITY,
	MaTaiSan nVARCHAR(50),
	MaPhuTungKemTheo nVARCHAR(50),
	TenPhuTungKemTheo nVARCHAR(200),
	DVT nVARCHAR(200),
	SoLuong float,
	GiaTri float,
	GhiChu nVARCHAR(200)
)
GO
--------------------------------------------------------------------------NGHIỆP VỤ TÀI SẢN CỐ ĐỊNH
USE VNAAccounting
--						DieuChinhGiaTriTaiSan
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DieuChinhGiaTriTaiSan]') AND type in (N'U'))
DROP TABLE [dbo].[DieuChinhGiaTriTaiSan]
GO
CREATE TABLE DieuChinhGiaTriTaiSan
(
	DieuChinhGiaTriTaiSanID INT PRIMARY KEY IDENTITY,
	Loai BIT,	--Loại tăng tài sản 1, Loại giảm tài sản 0
	MaTaiSan nVARCHAR(50),
	Nam nVARCHAR(200),
	Ky nVARCHAR(200),
	NgayChungTu Datetime,
	SoChungTu nVARCHAR(200),
	MaNguonVon nVARCHAR(50),
	MaLyDoTangGiamTaiSan nVARCHAR(50),
	NguyenGia float,
	GiaTriDaKhauHao float,
	GiaTriConLai float,
	GiaTriKhauHao1Ky float,
	DienGiai nVARCHAR(200)
)
GO
USE VNAAccounting
--						GiamTaiSanCoDinh
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GiamTaiSanCoDinh]') AND type in (N'U'))
DROP TABLE [dbo].[GiamTaiSanCoDinh]
GO
CREATE TABLE GiamTaiSanCoDinh
(
	GiamTaiSanCoDinhID INT PRIMARY KEY IDENTITY,
	MaGiamTaiSanCoDinh nVARCHAR(50),
	MaTaiSan nVARCHAR(50),
	MaLyDoTangGiamTaiSan nVARCHAR(50),
	NgayGiam Datetime,
	NgayKetThucKhauHao Datetime,
	SoChungTu nVARCHAR(200),
	LyDo nVARCHAR(200)
)
GO
USE VNAAccounting
--						ThoiKhauHaoTaiSan
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ThoiKhauHaoTaiSan]') AND type in (N'U'))
DROP TABLE [dbo].[ThoiKhauHaoTaiSan]
GO
CREATE TABLE ThoiKhauHaoTaiSan
(
	ThoiKhauHaoTaiSanID INT PRIMARY KEY IDENTITY,
	MaThoiKhauHaoTaiSan nVARCHAR(50),
	MaTaiSan nVARCHAR(50),
	NgayThoiKhauHao Datetime
)
GO
USE VNAAccounting
--						DieuChuyenBoPhanSuDung
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DieuChuyenBoPhanSuDung]') AND type in (N'U'))
DROP TABLE [dbo].[DieuChuyenBoPhanSuDung]
GO
CREATE TABLE DieuChuyenBoPhanSuDung
(
	DieuChuyenBoPhanSuDungID INT PRIMARY KEY IDENTITY,
	MaDieuChuyenBoPhanSuDung nVARCHAR(50),
	MaTaiSan nVARCHAR(50),
	Nam nVARCHAR(200),
	Ky nVARCHAR(200),
	MaBoPhanSuDung nVARCHAR(50),
	TKTaiSan nVARCHAR(50),
	TKKhauHao nVARCHAR(50),
	TKChiPhi nVARCHAR(50)
)
GO
