USE MASTER
 IF EXISTS (SELECT * FROM SYSDATABASES WHERE name = 'VNAAccounting')
 DROP DATABASE VNAAccounting
GO
CREATE DATABASE VNAAccounting
GO
USE VNAAccounting
GO
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
--
