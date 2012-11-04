USE MASTER
 IF EXISTS (SELECT * FROM SYSDATABASES WHERE name = 'VNAAccounting')
 DROP DATABASE VNAAccounting
GO
CREATE DATABASE VNAAccounting
GO
USE VNAAccounting
GO
--USE MASTER
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
--USE MASTER
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
--USE MASTER
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
--USE MASTER
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
--USE MASTER
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
--USE MASTER
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
--USE MASTER
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
--USE MASTER
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
--USE MASTER
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
--USE MASTER
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
--USE MASTER
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
--USE MASTER
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
	SoHieuTaiSan nVARCHAR(200),	--0
	NuocSanXuat nVARCHAR(200),
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

