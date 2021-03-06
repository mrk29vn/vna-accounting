-- ============================= 1 =====================================
GO
USE SupermarketManagementDHT

go
-- Table Khuyen Mai Theo So Luong
--            Select All
IF OBJECT_ID(N'[dbo].[sp_SelectKMSL]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_SelectKMSL]
go
CREATE proc sp_SelectKMSL
as
select * from KhuyenMaiSoLuong
go
--            Select theo ma Hang hoa
 IF OBJECT_ID(N'[dbo].[sp_SelectKMSLTheoMa]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_SelectKMSLTheoMa]
go
CREATE proc sp_SelectKMSLTheoMa
	@MaHangHoa varchar(50)
as
select * from KhuyenMaiSoLuong
where MaHangHoa= @MaHangHoa

go

--            Insert 
IF OBJECT_ID(N'[dbo].[sp_InsertKMSL]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_InsertKMSL]
go
CREATE proc sp_InsertKMSL
	@Id int ,
	@MaHangHoa varchar(50) ,
	@TenHangHoa nvarchar(200) ,
	@NgayBatDau datetime,
	@NgayKetThuc datetime,
	@SoLuong float,
	@GiaBanBuon float,
	@GiaBanLe float
as
insert into KhuyenMaiSoLuong values(@MaHangHoa,@TenHangHoa,@NgayBatDau,@NgayKetThuc,@SoLuong,@GiaBanBuon,@GiaBanLe)
go
--            Update
IF OBJECT_ID(N'[dbo].[sp_UpdateKMSL]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_UpdateKMSL]
go
CREATE proc sp_UpdateKMSL
	@Id int ,
	@MaHangHoa varchar(50) ,
	@TenHangHoa nvarchar(200) ,
	@NgayBatDau datetime,
	@NgayKetThuc datetime,
	@SoLuong float,
	@GiaBanBuon float,
	@GiaBanLe float
as
Update KhuyenMaiSoLuong 
Set MaHangHoa = @MaHangHoa,
	TenHangHoa = @TenHangHoa,
	NgayBatDau = @NgayBatDau,
	NgayKetThuc = @NgayKetThuc,
	SoLuong = @SoLuong,
	GiaBanBuon = @GiaBanBuon,
	GiaBanLe = @GiaBanLe
where ID = @Id
go
--              Delete
IF OBJECT_ID(N'[dbo].[sp_DeleteKMSL]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_DeleteKMSL]
go
CREATE proc sp_DeleteKMSL
@MaHangHoa varchar(50)
as
Delete KhuyenMaiSoLuong
Where MaHangHoa=@MaHangHoa

-- =========================================== End Khuyen Mai So Luong ==============================



------------------------------------------------------------------------------------------------------------------------
-- Phiếu Thu
------------------------------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].[sp_SelectPhieuThusAll]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_SelectPhieuThusAll]
go
CREATE PROCEDURE [dbo].[sp_SelectPhieuThusAll]
AS
begin
SELECT * FROM	[dbo].[PhieuThu] 
end

go
IF OBJECT_ID(N'[dbo].sp_XuLy_PhieuThu') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_PhieuThu
go
CREATE PROCEDURE sp_XuLy_PhieuThu
	@HanhDong nvarchar(20),
	@PhieuThuID int,
	@MaPhieuThu varchar(20),
	@NgayLap datetime,
	@LoaiPhieu nvarchar(20),
	@MaKho varchar(20),
	@MaNhomHang nvarchar(20),
	@KhoanMuc nvarchar(200),
	@DoiTuong nvarchar(20),
	@NguoiNopTien nvarchar(200),
	@NguoiNhanTien nvarchar(20),
	@NoTaiKhoan varchar(20),
	@CoTaiKhoan varchar(20),
	@TongTienThanhToan money,
	@MaTienTe varchar(20),
	@TrangThai bit,
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO [dbo].[PhieuThu]
		([MaPhieuThu],[NgayLap],[LoaiPhieu],[MaKho],[MaNhomHang],[KhoanMuc],[DoiTuong],
		[NguoiNopTien],[NguoiNhanTien],
		[NoTaiKhoan],[CoTaiKhoan],[TongTienThanhToan],[MaTienTe],[TrangThai],[GhiChu],[Deleted])
		VALUES
		(@MaPhieuThu,@NgayLap,@LoaiPhieu,@MaKho,@MaNhomHang,@KhoanMuc,@DoiTuong,@NguoiNopTien,@NguoiNhanTien,@NoTaiKhoan,@CoTaiKhoan,
		@TongTienThanhToan,@MaTienTe,@TrangThai,@GhiChu,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE [dbo].[PhieuThu] SET
			[MaPhieuThu] = @MaPhieuThu,
			[NgayLap] = @NgayLap,
			[LoaiPhieu] = @LoaiPhieu,
			[MaKho] = @MaKho,
			[MaNhomHang] = @MaNhomHang,
			[KhoanMuc] = @KhoanMuc,
			[DoiTuong] = @DoiTuong,
			[NguoiNopTien] = @NguoiNopTien,
			[NguoiNhanTien] = @NguoiNhanTien,
			[NoTaiKhoan] = @NoTaiKhoan,
			[CoTaiKhoan] = @CoTaiKhoan,
			[TongTienThanhToan] = @TongTienThanhToan,
			[MaTienTe] = @MaTienTe,
			[TrangThai] = @TrangThai,
			[GhiChu] = @GhiChu,
			[Deleted] = @Deleted
		WHERE
			[PhieuThuID] = @PhieuThuID
	 END
END
GO
go
IF OBJECT_ID(N'[dbo].sp_Xoa_PhieuThu') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_PhieuThu
go
CREATE PROC sp_Xoa_PhieuThu
	@HanhDong nvarchar(20),
	@PhieuThuID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE PhieuThu SET Deleted = N'True'
		WHERE PhieuThuID = @PhieuThuID
	 END
END
GO

------------------------------------------------------------------------------------------------------------------------
-- Phiếu Thanh Toán Của Khách Hàng
------------------------------------------------------------------------------------------------------------------------
IF OBJECT_ID(N'[dbo].[sp_SelectPhieuTTCuaKHsAll]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_SelectPhieuTTCuaKHsAll]
go
CREATE PROCEDURE [dbo].[sp_SelectPhieuTTCuaKHsAll]
AS
begin
SELECT * FROM 	[dbo].[PhieuTTCuaKH]
end

--endregion

GO
IF OBJECT_ID(N'[dbo].sp_XuLy_PhieuTTCuaKH') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_PhieuTTCuaKH
go
CREATE PROCEDURE sp_XuLy_PhieuTTCuaKH
	@HanhDong nvarchar(20),
	@PhieuTTCuaKHID int,
	@MaPhieuTTCuaKH varchar(20),
	@NgayLap datetime,
	@MaKhachHang nvarchar(20),
	@NoHienThoi money,
	@NguoiNop nvarchar(200),
	@MaTienTe nvarchar(20),
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO [dbo].[PhieuTTCuaKH] ([MaPhieuTTCuaKH],[NgayLap],[MaKhachHang],[NoHienThoi],[NguoiNop],[MaTienTe],[GhiChu],[Deleted])
		VALUES (@MaPhieuTTCuaKH,@NgayLap,@MaKhachHang,@NoHienThoi,@NguoiNop,@MaTienTe,@GhiChu,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE [dbo].[PhieuTTCuaKH] SET
			[MaPhieuTTCuaKH] = @MaPhieuTTCuaKH,
			[NgayLap] = @NgayLap,
			[MaKhachHang] = @MaKhachHang,
			[NoHienThoi] = @NoHienThoi,
			[NguoiNop] = @NguoiNop,
			[MaTienTe] = @MaTienTe,
			[GhiChu] = @GhiChu,
			[Deleted] = @Deleted
		WHERE
			[PhieuTTCuaKHID] = @PhieuTTCuaKHID
	 END
END
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_PhieuTTCuaKH') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_PhieuTTCuaKH
go
CREATE PROC sp_Xoa_PhieuTTCuaKH
	@HanhDong nvarchar(20),
	@PhieuTTCuaKHID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE PhieuTTCuaKH SET Deleted = N'True'
		WHERE [PhieuTTCuaKHID] = @PhieuTTCuaKHID
	 END
END
GO
------------------------------------------------------------------------------------------------------------------------
-- Phiếu Thanh Toán Của Nhà Cung Cấp
------------------------------------------------------------------------------------------------------------------------

GO
IF OBJECT_ID(N'[dbo].[sp_SelectPhieuTTNCCsAll]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_SelectPhieuTTNCCsAll]
go
CREATE PROCEDURE [dbo].[sp_SelectPhieuTTNCCsAll]
AS
begin
SELECT * FROM 	[dbo].[PhieuTTNCC]
end
go
IF OBJECT_ID(N'[dbo].sp_XuLy_PhieuTTNCC') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_PhieuTTNCC
go
CREATE PROCEDURE sp_XuLy_PhieuTTNCC
	@HanhDong nvarchar(20),
	@PhieuTTNCCID int,
	@MaPhieuTTNCC varchar(20),
	@NgayLap datetime,
	@MaNCC nvarchar(20),
	@NoHienThoi money,
	@Nguoinhan nvarchar(200),
	@MaTienTe varchar(20),
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO [dbo].[PhieuTTNCC]
		([MaPhieuTTNCC],[NgayLap],[MaNCC],[NoHienThoi],[Nguoinhan],[MaTienTe],[GhiChu],[Deleted])
		VALUES (@MaPhieuTTNCC,@NgayLap,@MaNCC,@NoHienThoi,@Nguoinhan,@MaTienTe,@GhiChu,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE [dbo].[PhieuTTNCC] SET
			[MaPhieuTTNCC] = @MaPhieuTTNCC,
			[NgayLap] = @NgayLap,
			[MaNCC] = @MaNCC,
			[NoHienThoi] = @NoHienThoi,
			[Nguoinhan] = @Nguoinhan,
			[MaTienTe] = @MaTienTe,
			[GhiChu] = @GhiChu,
			[Deleted] = @Deleted
		WHERE
			[PhieuTTNCCID] = @PhieuTTNCCID
			 END
END
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_PhieuTTNCC') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_PhieuTTNCC
go
CREATE PROC sp_Xoa_PhieuTTNCC
	@HanhDong nvarchar(20),
	@PhieuTTNCCID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE [PhieuTTNCC] SET Deleted = N'True'
		WHERE PhieuTTNCCID = @PhieuTTNCCID
	 END
END
GO
------------------------------------------------------------------------------------------------------------------------
-- Phiếu Xuất Hủy
------------------------------------------------------------------------------------------------------------------------
IF OBJECT_ID(N'[dbo].[sp_SelectPhieuXuatHuysAll]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_SelectPhieuXuatHuysAll]
go
CREATE PROCEDURE [dbo].[sp_SelectPhieuXuatHuysAll]
AS
begin
SELECT * FROM 	[dbo].[PhieuXuatHuy]
end
go
IF OBJECT_ID(N'[dbo].sp_XuLy_PhieuXuatHuy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_PhieuXuatHuy
go
CREATE PROCEDURE sp_XuLy_PhieuXuatHuy
	@HanhDong nvarchar(20),
	@PhieuXuatHuyID int,
	@MaPhieuXuatHuy varchar(20),
	@NgayLap datetime,
	@MaNhanVien nvarchar(20),
	@MaKho varchar(20),
	@TrangThai bit,
	@Tongtien money,
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO PhieuXuatHuy ([MaPhieuXuatHuy],[NgayLap],[MaNhanVien],[MaKho],[TrangThai],[Tongtien],[GhiChu],[Deleted])
		VALUES (@MaPhieuXuatHuy,@NgayLap,@MaNhanVien,@MaKho,@TrangThai,@Tongtien,@GhiChu,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		UPDATE [dbo].[PhieuXuatHuy] SET
			[MaPhieuXuatHuy] = @MaPhieuXuatHuy,
			[NgayLap] = @NgayLap,
			[MaNhanVien] = @MaNhanVien,
			[MaKho] = @MaKho,
			[TrangThai] = @TrangThai,
			[Tongtien] = @Tongtien,
			[GhiChu] = @GhiChu,
			[Deleted] = @Deleted
		WHERE
			[PhieuXuatHuyID] = @PhieuXuatHuyID
	 END
END
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_PhieuXuatHuy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_PhieuXuatHuy
go
CREATE PROC sp_Xoa_PhieuXuatHuy
	@HanhDong nvarchar(20),
	@PhieuXuatHuyID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		delete from ChiTietXuatHuy where MaPhieuXuatHuy = (select MaPhieuXuatHuy from PhieuXuatHuy where PhieuXuatHuyID = @PhieuXuatHuyID)
		delete from PhieuXuatHuy WHERE PhieuXuatHuyID = @PhieuXuatHuyID
	 END
END
GO
------------------------------------------------------------------------------------------------------------------------
-- Chi Tiết Xuất Hủy
------------------------------------------------------------------------------------------------------------------------
IF OBJECT_ID(N'[dbo].[sp_SelectChiTietXuatHuysAll]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_SelectChiTietXuatHuysAll]
go
CREATE proc [dbo].[sp_SelectChiTietXuatHuysAll] @MaPhieuXuatHuy varchar(20)
as
begin
select * from ChiTietXuatHuy where MaPhieuXuatHuy = @MaPhieuXuatHuy
end

go
IF OBJECT_ID(N'[dbo].sp_XuLy_ChiTietXuatHuy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_ChiTietXuatHuy
go
CREATE PROCEDURE sp_XuLy_ChiTietXuatHuy
	@HanhDong nvarchar(20),
	@MaPhieuXuatHuy varchar(20),
	@MaHangHoa varchar(50),
	@SoLuong int,
	@GhiChu nvarchar(100)
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO ChiTietXuatHuy (MaPhieuXuatHuy,MaHangHoa,SoLuong,GhiChu,Deleted)
		values(@MaPhieuXuatHuy,@MaHangHoa,@SoLuong,@GhiChu,0)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		UPDATE [dbo].ChiTietXuatHuy SET
			SoLuong = @SoLuong,
			GhiChu = @GhiChu
		WHERE
			MaPhieuXuatHuy = @MaPhieuXuatHuy
			ANd MaHangHoa = @MaHangHoa
	 END
END
go
IF OBJECT_ID(N'[dbo].[sp_Xoa_ChiTietXuatHuy]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_Xoa_ChiTietXuatHuy]
go
CREATE PROC [dbo].[sp_Xoa_ChiTietXuatHuy]
	@HanhDong nvarchar(20),
	@MaPhieuXuatHuy varchar(20),
	@MaHangHoa varchar(50)
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE ChiTietXuatHuy SET Deleted = 1
		WHERE MaPhieuXuatHuy = @MaPhieuXuatHuy
			ANd MaHangHoa = @MaHangHoa
	 END
END
go
IF OBJECT_ID(N'[dbo].sp_InsertUpdate_ChiTietXuatHuy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_InsertUpdate_ChiTietXuatHuy
go
create proc sp_InsertUpdate_ChiTietXuatHuy
	@HanhDong varchar(20),
	@MaPhieuXuatHuy varchar(20),
	@MaHangHoa varchar(50),
	@SoLuong int,
	@GhiChu nvarchar(100),
	@Deleted bit
	as
	begin
	IF EXISTS(SELECT MaPhieuXuatHuy,MaHangHoa FROM [dbo].ChiTietXuatHuy WHERE MaPhieuXuatHuy = @MaPhieuXuatHuy and MaHangHoa=@MaHangHoa)
	BEGIN
		UPDATE [dbo].ChiTietXuatHuy SET
			SoLuong = @SoLuong,
			GhiChu = @GhiChu
		WHERE
			MaPhieuXuatHuy = @MaPhieuXuatHuy
			ANd MaHangHoa = @MaHangHoa
	end
	else
	begin
	INSERT INTO ChiTietXuatHuy (MaPhieuXuatHuy,MaHangHoa,SoLuong,GhiChu,Deleted)
		values(@MaPhieuXuatHuy,@MaHangHoa,@SoLuong,@GhiChu,0)
	end
	end
	go
------------------------------------------------------------------------------------------------------------------------
-- Chi Tiết Phiếu Thanh Toán Nhà Cung Cấp
------------------------------------------------------------------------------------------------------------------------
IF OBJECT_ID(N'[dbo].[sp_SelectChiTietPhieuTTNCCsAll]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_SelectChiTietPhieuTTNCCsAll]
go
CREATE proc [dbo].[sp_SelectChiTietPhieuTTNCCsAll] @MaPhieuTTNCC varchar(20)
as
begin
select * from ChiTietPhieuTTNCC where MaPhieuTTNCC = @MaPhieuTTNCC
end
go
IF OBJECT_ID(N'[dbo].[sp_Xoa_ChiTietPhieuTTNCC]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_Xoa_ChiTietPhieuTTNCC]
go
CREATE PROC [dbo].[sp_Xoa_ChiTietPhieuTTNCC]
	@HanhDong nvarchar(20),
	@MaHoaDonNhap varchar(20),
	@MaPhieuTTNCC varchar(20)
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE ChiTietPhieuTTNCC SET Deleted = N'True'
		WHERE MaHoaDonNhap = @MaHoaDonNhap
			ANd MaPhieuTTNCC = @MaPhieuTTNCC
	 END
END
go
IF OBJECT_ID(N'[dbo].[sp_XuLy_ChiTietPhieuTTNCC]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_XuLy_ChiTietPhieuTTNCC]
go
CREATE PROCEDURE [dbo].[sp_XuLy_ChiTietPhieuTTNCC]
	@HanhDong nvarchar(20),
	@MaHoaDonNhap varchar(20),
	@MaPhieuTTNCC varchar(20),
	@TongTien float,
	@TienNo float,
	@ThanhToan float,
	@TrangThai bit,	
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO ChiTietPhieuTTNCC (MaHoaDonNhap,MaPhieuTTNCC,TongTien,TienNo,ThanhToan,TrangThai,GhiChu,Deleted)
		values(@MaHoaDonNhap,@MaPhieuTTNCC,@TongTien,@TienNo,@ThanhToan,@TrangThai,@GhiChu,0)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		UPDATE [dbo].ChiTietPhieuTTNCC SET
			TrangThai = @TrangThai
		WHERE
			MaHoaDonNhap = @MaHoaDonNhap
			ANd MaPhieuTTNCC = @MaPhieuTTNCC
	 END
END
------------------------------------------------------------------------------------------------------------------------
-- Chi Tiết Phiếu Thanh Toán Của Khách Hàng
----------------------------------	--------------------------------------------------------------------------------------
go
IF OBJECT_ID(N'[dbo].[sp_SelectChiTietPhieuTTCuaKHsAll]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_SelectChiTietPhieuTTCuaKHsAll]
go
CREATE proc [dbo].[sp_SelectChiTietPhieuTTCuaKHsAll] @MaPhieuTTCuaKH varchar(20)
as
begin
select * from ChiTietPhieuTTCuaKH where MaPhieuTTCuaKH = @MaPhieuTTCuaKH
end
go
IF OBJECT_ID(N'[dbo].[sp_Xoa_ChiTietPhieuTTCuaKH]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_Xoa_ChiTietPhieuTTCuaKH]
go
CREATE PROC [dbo].[sp_Xoa_ChiTietPhieuTTCuaKH]
	@HanhDong nvarchar(20),
	@MaHDBanHang varchar(20),
	@MaPhieuTTCuaKH varchar(20)
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE ChiTietPhieuTTCuaKH SET Deleted = N'True'
		WHERE MaHDBanHang = @MaHDBanHang
			ANd MaPhieuTTCuaKH = @MaPhieuTTCuaKH
	 END
END
go
IF OBJECT_ID(N'[dbo].[sp_XuLy_ChiTietPhieuTTCuaKH]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_XuLy_ChiTietPhieuTTCuaKH]
go
CREATE PROCEDURE [dbo].[sp_XuLy_ChiTietPhieuTTCuaKH]
	@HanhDong nvarchar(20),
	@MaHDBanHang varchar(20),
	@MaPhieuTTCuaKH varchar(20),
	@TongTien float,
	@TienNo float,
	@ThanhToan float,
	@TrangThai bit,	
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO ChiTietPhieuTTCuaKH (MaHDBanHang,MaPhieuTTCuaKH,TongTien,TienNo,ThanhToan,TrangThai,GhiChu,Deleted)
		values(@MaHDBanHang,@MaPhieuTTCuaKH,@TongTien,@TienNo,@ThanhToan,@TrangThai,@GhiChu,0)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		UPDATE [dbo].ChiTietPhieuTTCuaKH SET
			TrangThai = @TrangThai
		WHERE
			MaHDBanHang = @MaHDBanHang
			ANd MaPhieuTTCuaKH = @MaPhieuTTCuaKH
	 END
END
------------------------------------------------------------------------------------------------------------------------
-- Hóa Đơn Bán Hàng
------------------------------------------------------------------------------------------------------------------------
go
IF OBJECT_ID(N'[dbo].sp_SelectHDBanHangsAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectHDBanHangsAll
go
create proc sp_SelectHDBanHangsAll
as
select * from HDBanHang
go
IF OBJECT_ID(N'[dbo].sp_XuLy_HDBanHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_HDBanHang
go
create proc sp_XuLy_HDBanHang
	@HanhDong nvarchar(20),
	@HDBanHangID int,
	@MaHDBanHang varchar(20),
	@NgayBan datetime,
	@MaKhachHang nvarchar(20),
	@NoHienThoi float,
	@NguoiNhanHang nvarchar(200),
	@HinhThucThanhToan nvarchar(200),
	@MaKho varchar(20),
	@HanThanhToam datetime,
	@MaDonDatHang varchar(20),
	@MaNhanVien nvarchar(20),
	@MaTienTe varchar(20),
	@ChietKhau float,
	@ThanhToanNgay float,
	@ThanhToanKhiLapPhieu float,
	@ThueGTGT float,
	@TongTienThanhToan float,
	@LoaiHoaDon bit,
	@MaThe varchar(20),
	@GiaTriThe float,
	@GhiChu nvarchar(100),
	@Deleted bit,
	@KhachTra float,
	@ChietKhauTongHoaDon float,
	@MaTheGiaTri varchar(20),
	@GiaTriTheGiaTri float
	
as
begin
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO [dbo].[HDBanHang] ([MaHDBanHang],[NgayBan],[MaKhachHang],[NoHienThoi],[NguoiNhanHang],[HinhThucThanhToan],
	[MaKho],[HanThanhToam],[MaDonDatHang],[MaNhanVien],[MaTienTe],[ChietKhau],
	[ThanhToanNgay],[ThanhToanKhiLapPhieu],[ThueGTGT],[TongTienThanhToan],[LoaiHoaDon],[MaThe],[GiaTriThe],[GhiChu],[Deleted],KhachTra,ChietKhauTongHoaDon,MaTheGiaTri,GiaTriTheGiaTri) 
	VALUES (@MaHDBanHang,@NgayBan,@MaKhachHang,@NoHienThoi,@NguoiNhanHang,@HinhThucThanhToan,@MaKho,
	@HanThanhToam,@MaDonDatHang,@MaNhanVien,@MaTienTe,@ChietKhau,@ThanhToanNgay,@ThanhToanKhiLapPhieu,@ThueGTGT,
	@TongTienThanhToan,@LoaiHoaDon,@MaThe,@GiaTriThe,@GhiChu,@Deleted,@KhachTra,@ChietKhauTongHoaDon,@MaTheGiaTri,@GiaTriTheGiaTri)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		UPDATE [dbo].[HDBanHang] SET [MaHDBanHang] = @MaHDBanHang,[NgayBan] = @NgayBan,[MaKhachHang] = @MaKhachHang,
		[NoHienThoi] = @NoHienThoi,[NguoiNhanHang] = @NguoiNhanHang,[HinhThucThanhToan] = @HinhThucThanhToan,
		[MaKho] = @MaKho,[HanThanhToam] = @HanThanhToam,[MaDonDatHang] = @MaDonDatHang,
		[MaNhanVien] = @MaNhanVien,[MaTienTe] = @MaTienTe,[ChietKhau] = @ChietKhau,
		[ThanhToanNgay] = @ThanhToanNgay,ThanhToanKhiLapPhieu = @ThanhToanKhiLapPhieu,[ThueGTGT] = @ThueGTGT,[TongTienThanhToan] = @TongTienThanhToan,
		[LoaiHoaDon] = @LoaiHoaDon,[MaThe] = @MaThe,[GiaTriThe] = @GiaTriThe,[GhiChu] = @GhiChu,[Deleted] = @Deleted
		WHERE
		[HDBanHangID] = @HDBanHangID
	 END
end
go
IF OBJECT_ID(N'[dbo].[sp_Xoa_HDBanHang]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_Xoa_HDBanHang]
go
CREATE PROC [dbo].[sp_Xoa_HDBanHang]
	@HanhDong nvarchar(20),
	@HDBanHangID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE [HDBanHang] SET Deleted = N'True'
		WHERE [HDBanHangID] = @HDBanHangID
	 END
END
------------------------------------------------------------------------------------------------------------------------
-- Chi Tiết Hóa Đơn Bán Hàng
------------------------------------------------------------------------------------------------------------------------
go
IF OBJECT_ID(N'[dbo].[sp_SelectChiTietHDBanHangsAll]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_SelectChiTietHDBanHangsAll]
go
CREATE proc [dbo].[sp_SelectChiTietHDBanHangsAll] @MaHDBanHang varchar(20)
as
begin
select * from ChiTietHDBanHang where MaHDBanHang = @MaHDBanHang
end
go
IF OBJECT_ID(N'[dbo].[sp_Xoa_ChiTietHDBanHang]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_Xoa_ChiTietHDBanHang]
go
CREATE PROC [dbo].[sp_Xoa_ChiTietHDBanHang]
	@HanhDong nvarchar(20),
	@MaHDBanHang varchar(20),
	@MaHangHoa varchar(50)
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE ChiTietHDBanHang SET Deleted = N'True'
		WHERE MaHDBanHang = @MaHDBanHang
			ANd MaHangHoa = @MaHangHoa
	 END
END
go
IF OBJECT_ID(N'[dbo].[sp_XuLy_ChiTietHDBanHang]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_XuLy_ChiTietHDBanHang]
go
CREATE PROCEDURE [dbo].[sp_XuLy_ChiTietHDBanHang]
	@HanhDong nvarchar(20),
	@MaHDBanHang varchar(20),
	@MaHangHoa varchar(50),
	@TenHangHoa nvarchar(200),
	@SoLuong int,
	@DonGia float,
	@Thue float,
	@PhanTramChietKhau float,	
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO ChiTietHDBanHang (MaHDBanHang,MaHangHoa,TenHangHoa,SoLuong,DonGia,Thue,PhanTramChietKhau,GhiChu,Deleted)
		values(@MaHDBanHang,@MaHangHoa,@TenHangHoa,@SoLuong,@DonGia,@Thue,@PhanTramChietKhau,@GhiChu,0)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		UPDATE [dbo].ChiTietHDBanHang SET
			SoLuong = @SoLuong,
			PhanTramChietKhau = @PhanTramChietKhau
		WHERE
			MaHDBanHang = @MaHDBanHang
			ANd MaHangHoa = @MaHangHoa
	 END
END
go
IF OBJECT_ID(N'[dbo].sp_InsertUpdate_ChiTietHDBanHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_InsertUpdate_ChiTietHDBanHang
go
create proc sp_InsertUpdate_ChiTietHDBanHang
	@HanhDong nvarchar(20),
	@MaHDBanHang varchar(20),
	@MaHangHoa varchar(50),
	@TenHangHoa nvarchar(200),
	@SoLuong int,
	@DonGia float,
	@Thue float,
	@PhanTramChietKhau float,	
	@GhiChu nvarchar(100),
	@Deleted bit
	as
	begin
	IF EXISTS(SELECT * FROM [dbo].ChiTietHDBanHang WHERE MaHDBanHang = @MaHDBanHang and MaHangHoa = @MaHangHoa)
	BEGIN
		UPDATE [dbo].ChiTietHDBanHang SET
			SoLuong = @SoLuong,
			PhanTramChietKhau = @PhanTramChietKhau
		WHERE
			MaHDBanHang = @MaHDBanHang
			ANd MaHangHoa = @MaHangHoa
	end
	else
	begin
	INSERT INTO ChiTietHDBanHang (MaHDBanHang,MaHangHoa,TenHangHoa,SoLuong,DonGia,Thue,PhanTramChietKhau,GhiChu,Deleted)
		values(@MaHDBanHang,@MaHangHoa,@TenHangHoa,@SoLuong,@DonGia,@Thue,@PhanTramChietKhau,@GhiChu,0)
	end
	end
	go
------------------------------------------------------------------------------------------------------------------------
-- Tài Khoản Kế Toán
------------------------------------------------------------------------------------------------------------------------
go
IF OBJECT_ID(N'[dbo].sp_LayNoTK') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayNoTK
go
create proc sp_LayNoTK
as
begin
select MaTKKeToan,Deleted from TKKeToan where MaTKKeToan like '111%'
end

go
IF OBJECT_ID(N'[dbo].sp_LayCoTK') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayCoTK
go
create proc sp_LayCoTK
as
begin
select MaTKKeToan,Deleted from TKKeToan where MaTKKeToan not like '111%'
end
go

------------------------------------------------------------------------------------------------------------------------
-- Khoản Mục Thu Chi - 0 la Phieu Thu - 1 la phieu chi
------------------------------------------------------------------------------------------------------------------------
IF OBJECT_ID(N'[dbo].sp_LayKMThuChi') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayKMThuChi
go
create proc sp_LayKMThuChi @Loai bit
as
begin
	select * from KMThuChi where LoaiKM = @Loai
end
go
------------------------------------------------------------------------------------------------------------------------
-- Lấy Top 1 = select top(1)[MaHDBanHang] as ID from [HDBanHang] order by [MaHDBanHang]desc
------------------------------------------------------------------------------------------------------------------------
IF OBJECT_ID(N'[dbo].sp_Lay_ID') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Lay_ID
go
create proc sp_Lay_ID
@table nvarchar(100)
as
begin
declare @col nvarchar(100),@col1 nvarchar(100), @sql nvarchar(150)
set @col = (select column_name from information_schema.columns where table_name = @table and ordinal_position=2)
set @sql= N'select ['+@col+'] as ID from ['+@table+'] order by ['+@col+']'+ 'desc'
exec sp_executesql @sql
end
go
------------------------------------------------------------------------------------------------------------------------
-- Trừ giá sản phẩm
------------------------------------------------------------------------------------------------------------------------
go
IF OBJECT_ID(N'[dbo].sp_SelectHHTrongKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectHHTrongKho
go
create proc sp_SelectHHTrongKho
as
select *  from HangHoa join ChiTietKhoHang on HangHoa.MaHangHoa = ChiTietKhoHang.MaHangHoa
go
IF OBJECT_ID(N'[dbo].sp_TruSoLuong') IS NOT NULL
 DROP PROCEDURE [dbo].sp_TruSoLuong
go
create proc sp_TruSoLuong @MaKho varchar(20), @MaHangHoa varchar(50), @SoLuong int
as
update ChiTietKhoHang
set SoLuong = SoLuong -  @SoLuong
where MaHangHoa = @MaHangHoa and MaKho = @MaKho
go
------------------------------------------------------------------------------------------------------------------------
-- Select Thuế
------------------------------------------------------------------------------------------------------------------------
IF OBJECT_ID(N'[dbo].sp_SelectThuesAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectThuesAll
go
create proc sp_SelectThuesAll
as
select * from Thue
------------------------------------------------------------------------------------------------------------------------
-- Báo Cáo
------------------------------------------------------------------------------------------------------------------------

--SELECT PhieuThuID, MaPhieuThu, NgayLap, LoaiPhieu, MaKho, MaNhomHang, KhoanMuc, DoiTuong, NguoiNopTien, NguoiNhanTien, MaTKNganHang, NoTaiKhoan, CoTaiKhoan, TongTienThanhToan, MaTienTe, TrangThai, GhiChu, Deleted FROM dbo.PhieuThu where MaPhieuThu='PT_0001'

go
IF OBJECT_ID(N'[dbo].sp_selectHDBanHangTheoNgay') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectHDBanHangTheoNgay
go
create proc sp_selectHDBanHangTheoNgay
@Ngay datetime
as
select * from HDBanHang where NgayBan=@Ngay and Deleted=0 
go
--exec sp_selectPhieuThuTheoNgay '01/01/2001'

--declare @ass nvarchar(10) =month('05/06/07')
--print @ass
IF OBJECT_ID(N'[dbo].sp_selectHDBanHangTheoThang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectHDBanHangTheoThang
go
create proc sp_selectHDBanHangTheoThang
@Thang int,
@Nam int
as
select * from HDBanHang where Month(NgayBan)=@Thang and Year(NgayBan)=@Nam and Deleted=0
go
--exec sp_selectPhieuThuTheoThang 1,2001

--declare @ass nvarchar(10) =month('05/06/07')
--print @ass
IF OBJECT_ID(N'[dbo].sp_selectHDBanHangTheoKhoangThoiGian') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectHDBanHangTheoKhoangThoiGian
go
create proc sp_selectHDBanHangTheoKhoangThoiGian
@Truoc datetime,
@Sau datetime
as
select * from HDBanHang where NgayBan between @Truoc and @Sau and Deleted=0
go
--exec sp_selectPhieuThuTheoKhoangThoiGian '01/01/2000','02/02/2002'

--declare @ass nvarchar(10) =month('05/06/07')
--print @ass
IF OBJECT_ID(N'[dbo].sp_selectHoaDonBanHangTheoHoaDon') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectHoaDonBanHangTheoHoaDon
go
create proc sp_selectHoaDonBanHangTheoHoaDon
@MaHDBanHang varchar(20)
as
select * from dbo.HangHoa join dbo.ChiTietHDBanHang on dbo.HangHoa.MaHangHoa=dbo.ChiTietHDBanHang.MaHangHoa join dbo.HDBanHang on dbo.ChiTietHDBanHang.MaHDBanHang = dbo.HDBanHang.MaHDBanHang
where dbo.HDBanHang.MaHDBanHang=@MaHDBanHang and
	 dbo.HangHoa.Deleted=0 and dbo.ChiTietHDBanHang.Deleted=0 and dbo.HDBanHang.Deleted=0
go
--exec sp_selectHoaDonBanHangTheoHoaDon 'HDBH_0001'
go
IF OBJECT_ID(N'[dbo].sp_selectBCTonKhoTheoTungKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectBCTonKhoTheoTungKho
go
create proc sp_selectBCTonKhoTheoTungKho
as
select * from dbo.KhoHang join dbo.ChiTietKhoHang on dbo.KhoHang.MaKho=dbo.ChiTietKhoHang.MaKho join dbo.HangHoa on dbo.ChiTietKhoHang.MaHangHoa=dbo.HangHoa.MaHangHoa
where dbo.KhoHang.Deleted=0 and dbo.ChiTietKhoHang.Deleted=0 and dbo.HangHoa.Deleted=0
go
IF OBJECT_ID(N'[dbo].sp_selectBCTonKhoTheoNhomHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectBCTonKhoTheoNhomHang
go
create proc sp_selectBCTonKhoTheoNhomHang
as
select * from  dbo.ChiTietKhoHang join dbo.HangHoa on dbo.ChiTietKhoHang.MaHangHoa=dbo.HangHoa.MaHangHoa join dbo.NhomHang on dbo.HangHoa.MaNhomHangHoa=dbo.NhomHang.MaNhomHang
where dbo.ChiTietKhoHang.Deleted=0 and dbo.HangHoa.Deleted=0 and dbo.NhomHang.Deleted=0
go 
IF OBJECT_ID(N'[dbo].sp_selectHDBanBuonTheoDonHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectHDBanBuonTheoDonHang
go
create proc sp_selectHDBanBuonTheoDonHang
@MaHDBanHang varchar(20)
as
select * from dbo.HangHoa join dbo.ChiTietHDBanHang on dbo.HangHoa.MaHangHoa=dbo.ChiTietHDBanHang.MaHangHoa join dbo.HDBanHang on dbo.ChiTietHDBanHang.MaHDBanHang = dbo.HDBanHang.MaHDBanHang 
where dbo.HangHoa.Deleted=0 and dbo.ChiTietHDBanHang.Deleted=0 and dbo.HDBanHang.Deleted=0 and  dbo.HDBanHang.MaHDBanHang=@MaHDBanHang
go
IF OBJECT_ID(N'[dbo].sp_selectHDBanBuonAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectHDBanBuonAll
go
create proc sp_selectHDBanBuonAll
as
select  HangHoa.HangHoaID, HangHoa.MaHangHoa, HangHoa.GiaNhap, HangHoa.GiaBanBuon, HangHoa.GiaBanLe, ChiTietHDBanHang.MaHDBanHang, 
                         ChiTietHDBanHang.SoLuong, HDBanHang.NgayBan, HDBanHang.MaKhachHang, HDBanHang.NguoiNhanHang, HDBanHang.MaDonDatHang, 
                         HDBanHang.MaNhanVien, HDBanHang.TongTienThanhToan, HDBanHang.LoaiHoaDon
 from dbo.HangHoa join dbo.ChiTietHDBanHang on dbo.HangHoa.MaHangHoa=dbo.ChiTietHDBanHang.MaHangHoa join dbo.HDBanHang on dbo.ChiTietHDBanHang.MaHDBanHang = dbo.HDBanHang.MaHDBanHang 
where dbo.HangHoa.Deleted=0 and dbo.ChiTietHDBanHang.Deleted=0 and dbo.HDBanHang.Deleted=0 and  dbo.HDBanHang.LoaiHoaDon='false'
go
IF OBJECT_ID(N'[dbo].sp_selectHDBanLeAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectHDBanLeAll
go
create proc sp_selectHDBanLeAll
as
select  HangHoa.HangHoaID, HangHoa.MaHangHoa, HangHoa.GiaNhap, HangHoa.GiaBanBuon, HangHoa.GiaBanLe, ChiTietHDBanHang.MaHDBanHang, 
                         ChiTietHDBanHang.SoLuong, HDBanHang.NgayBan, HDBanHang.MaKhachHang, HDBanHang.NguoiNhanHang, HDBanHang.MaDonDatHang, 
                         HDBanHang.MaNhanVien, HDBanHang.TongTienThanhToan, HDBanHang.LoaiHoaDon
 from dbo.HangHoa join dbo.ChiTietHDBanHang on dbo.HangHoa.MaHangHoa=dbo.ChiTietHDBanHang.MaHangHoa join dbo.HDBanHang on dbo.ChiTietHDBanHang.MaHDBanHang = dbo.HDBanHang.MaHDBanHang 
where dbo.HangHoa.Deleted=0 and dbo.ChiTietHDBanHang.Deleted=0 and dbo.HDBanHang.Deleted=0 and  dbo.HDBanHang.LoaiHoaDon='true'
go
IF OBJECT_ID(N'[dbo].sp_XuLy_NoHienThoi') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_NoHienThoi
go
create proc sp_XuLy_NoHienThoi @MaKH varchar(20),@DuNo float
as
begin
update KhachHang set DuNo = DuNo+ @DuNo where MaKH = @MaKH
end
go
IF OBJECT_ID(N'[dbo].sp_XuLy_NoHienThoiKH') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_NoHienThoiKH
go
	create proc sp_XuLy_NoHienThoiKH @MaKH varchar(20),@DuNo float
	as
	begin
	update KhachHang set DuNo = DuNo - @DuNo where MaKH = @MaKH
	end
go
IF OBJECT_ID(N'[dbo].sp_XuLy_ThanhToanNgay') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_ThanhToanNgay
go
create proc sp_XuLy_ThanhToanNgay @MaHDBanHang varchar(20),@ThanhToanNgay float
as
begin
update HDBanHang set ThanhToanNgay =ThanhToanNgay + @ThanhToanNgay where MaHDBanHang = @MaHDBanHang
end
go
IF OBJECT_ID(N'[dbo].sp_XacNhan_PhieuXuatHuy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XacNhan_PhieuXuatHuy
go
create proc sp_XacNhan_PhieuXuatHuy @MaPhieuXuatHuy varchar(20)
as
begin
update PhieuXuatHuy set TrangThai = 1 where MaPhieuXuatHuy = @MaPhieuXuatHuy 
end
go
IF OBJECT_ID(N'[dbo].sp_XuLy_NoHienThoiNCC') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_NoHienThoiNCC
go
create proc sp_XuLy_NoHienThoiNCC @MaNhaCungCap nvarchar(20),@DuNo float
as
begin
update NhaCungCap set DuNo =DuNo - @DuNo where MaNhaCungCap = @MaNhaCungCap
end
go
IF OBJECT_ID(N'[dbo].sp_XuLy_NoHienThoiNCCC') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_NoHienThoiNCCC
go
	create proc sp_XuLy_NoHienThoiNCCC @MaNhaCungCap nvarchar(20),@DuNo float
	as
	begin
	update NhaCungCap set DuNo =DuNo + @DuNo where MaNhaCungCap = @MaNhaCungCap
	end
go
IF OBJECT_ID(N'[dbo].sp_XuLy_ThanhToanNgayHDN') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_ThanhToanNgayHDN
go
create proc sp_XuLy_ThanhToanNgayHDN @MaHoaDonNhap varchar(20),@ThanhToanSauKhiLapPhieu float
as
begin
update HoaDonNhap set ThanhToanSauKhiLapPhieu = @ThanhToanSauKhiLapPhieu where MaHoaDonNhap = @MaHoaDonNhap
end
go
IF OBJECT_ID(N'[dbo].sp_SelectSoDuSoQuy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectSoDuSoQuy
go
create proc sp_SelectSoDuSoQuy
as
begin
select * from SoDuSoQuy
end
go
IF OBJECT_ID(N'[dbo].sp_InsertSoDuSoQuy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_InsertSoDuSoQuy
go
create proc sp_InsertSoDuSoQuy 
@MaSoDuSoQuy varchar(20),
@SoDuDauKy float,
@NgayKetChuyen datetime,
@SoDuCuoiKy float,
@TrangThai bit
as
begin
insert into SoDuSoQuy values(
	@MaSoDuSoQuy,@SoDuDauKy,@NgayKetChuyen,@SoDuCuoiKy,@TrangThai)
end
go
IF OBJECT_ID(N'[dbo].sp_UpdateSoDuSoQuy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_UpdateSoDuSoQuy
go
create proc sp_UpdateSoDuSoQuy @SoDuSoQuyID int, @SoDuCuoiKy float
as
begin
update SoDuSoQuy set TrangThai = 1, SoDuCuoiKy = @SoDuCuoiKy where SoDuSoQuyID = @SoDuSoQuyID
end
go
IF OBJECT_ID(N'[dbo].sp_DeleteSoDuSoQuy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_DeleteSoDuSoQuy
go
create proc sp_DeleteSoDuSoQuy
@MaSoDuSoQuy varchar(20)
as
begin
delete from SoDuSoQuy where MaSoDuSoQuy = @MaSoDuSoQuy
end
go
IF OBJECT_ID(N'[dbo].sp_SelectSoDuCongNo') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectSoDuCongNo
go
create proc sp_SelectSoDuCongNo
as
begin
select * from SoDuCongNo
end
go
IF OBJECT_ID(N'[dbo].sp_InsertSoDuCongNo') IS NOT NULL
 DROP PROCEDURE [dbo].sp_InsertSoDuCongNo
go
create proc sp_InsertSoDuCongNo
	@MaSoDuCongNo varchar(20),
	@MaDoiTuong varchar(20),
	@TenDoiTuong nvarchar(200),
	@DiaChi nvarchar(20),
	@SoDuDauKy float,
	@NgayKetChuyen datetime,
	@SoDuCuoiKy float,
	@LoaiDoiTuong bit,
	@TrangThai bit
as
begin
	insert into SoDuCongNo 
	values(
	@MaSoDuCongNo,@MaDoiTuong,@TenDoiTuong,@DiaChi,@SoDuDauKy,
	@NgayKetChuyen,@SoDuCuoiKy,@LoaiDoiTuong,@TrangThai)
end
go
IF OBJECT_ID(N'[dbo].sp_DeleteSoDuCongNo') IS NOT NULL
 DROP PROCEDURE [dbo].sp_DeleteSoDuCongNo
go
create proc sp_DeleteSoDuCongNo @MaSoDuCongNo varchar(20)
as
begin
delete from SoDuCongNo where MaSoDuCongNo = @MaSoDuCongNo
end
go
IF OBJECT_ID(N'[dbo].sp_UpdateSoDuCongNo') IS NOT NULL
 DROP PROCEDURE [dbo].sp_UpdateSoDuCongNo
go
create proc sp_UpdateSoDuCongNo @MaSoDuCongNo varchar(20),@SoDuCuoiKy float,@LoaiDoiTuong bit
as
begin
update SoDuCongNo set SoDuCuoiKy = @SoDuCuoiKy, TrangThai = 1 where MaSoDuCongNo = @MaSoDuCongNo and LoaiDoiTuong = @LoaiDoiTuong
end
go
IF OBJECT_ID(N'[dbo].[sp_XuLy_NhomHangHoa]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_XuLy_NhomHangHoa]
go
create PROCEDURE [dbo].[sp_XuLy_NhomHangHoa]
			@HanhDong nvarchar(20),
			@NhomHangID int,
			@MaNhomHang varchar(20),
			@MaLoaiHang varchar(20),
			@TenNhomHang nvarchar(200),
			@GhiChu nvarchar(250),
			@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO NhomHang
			(MaNhomHang,MaLoaiHang,TenNhomHang,GhiChu,Deleted) 
		VALUES 
			(@MaNhomHang,@MaLoaiHang,@TenNhomHang,@GhiChu,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE NhomHang
		 SET 
		 MaNhomHang = @MaNhomHang,
		 MaLoaiHang=@MaLoaiHang, 
		 TenNhomHang = @TenNhomHang,
		 GhiChu = @GhiChu
		WHERE NhomHangID = @NhomHangID
	 END
END
go
IF OBJECT_ID(N'[dbo].sp_SelectHoaDonNhap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectHoaDonNhap
go
create proc sp_SelectHoaDonNhap
as
begin
select * from HoaDonNhap
end
go
IF OBJECT_ID(N'[dbo].sp_DeleteHDBanHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_DeleteHDBanHang
go
create proc sp_DeleteHDBanHang
	@maHDBanHang varchar(20)
as
delete from ChiTietHDBanHang where MaHDBanHang = MaHDBanHang
delete from HDBanHang where MaHDBanHang = MaHDBanHang
go
IF OBJECT_ID(N'[dbo].sp_BCTonKhoTheoKhoTheoMa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_BCTonKhoTheoKhoTheoMa
go
create proc sp_BCTonKhoTheoKhoTheoMa
@MaKho varchar(20)
as
select * from KhoHang 
join ChiTietKhoHang on KhoHang.MaKho=ChiTietKhoHang.MaKho
join HangHoa on ChiTietKhoHang.MaHangHoa=HangHoa.MaHangHoa
where KhoHang.MaKho=@MaKho 
go
IF OBJECT_ID(N'[dbo].sp_BCTonKhoTheoKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_BCTonKhoTheoKho
go
create proc sp_BCTonKhoTheoKho
as
select * from KhoHang 
join ChiTietKhoHang on KhoHang.MaKho=ChiTietKhoHang.MaKho
join HangHoa on ChiTietKhoHang.MaHangHoa=HangHoa.MaHangHoa
go
IF OBJECT_ID(N'[dbo].sp_BCTonKhoTheoNhomHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_BCTonKhoTheoNhomHang
go
create proc sp_BCTonKhoTheoNhomHang
as
select * from NhomHang 
join  HangHoa on HangHoa.MaNhomHangHoa=NhomHang.MaNhomHang
join ChiTietKhoHang on ChiTietKhoHang.MaHangHoa=HangHoa.MaHangHoa
join KhoHang on ChiTietKhoHang.MaKho=KhoHang.MaKho
go
IF OBJECT_ID(N'[dbo].sp_BCTonKhoTheoNhomHangTheoMa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_BCTonKhoTheoNhomHangTheoMa
go
create proc sp_BCTonKhoTheoNhomHangTheoMa
@MaNhomHang varchar(20)
as
select * from NhomHang 
join  HangHoa on HangHoa.MaNhomHangHoa=NhomHang.MaNhomHang
join ChiTietKhoHang on ChiTietKhoHang.MaHangHoa=HangHoa.MaHangHoa
join KhoHang on ChiTietKhoHang.MaKho=KhoHang.MaKho
where NhomHang.MaNhomHang=@MaNhomHang

--============================= 2======================================================
GO
use SupermarketManagementDHT
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_XuLy_DonDatHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_DonDatHang
go
CREATE PROCEDURE sp_XuLy_DonDatHang
	@HanhDong nvarchar(20),
	@DonDatHangID int,
	@MaDonDatHang varchar(20),
	@LoaiDonDatHang bit,
	@NgayDonHang datetime,
	@MaNhaCungCap nvarchar(20),
	@NoHienThoi float,
	@TrangThaiDonDatHang nvarchar(20),
	@NgayNhapDuKien datetime,
	@HinhThucThanhToan nvarchar(20),
	@MaKho varchar(20),
	@MaNhanVien nvarchar(20),
	@MaTienTe varchar(20),
	@ThueGTGT float,
	@Phivanchuyen float,
	@PhiKhac float,
	@GhiChu nvarchar(250),
	@Deleted bit,
	@MaKhachHang nvarchar(20)
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO DonDatHang (MaDonDatHang,LoaiDonDatHang,NgayDonHang,MaNhaCungCap,NoHienThoi,TrangThaiDonDatHang,
			                    NgayNhapDuKien,HinhThucThanhToan,MaKho,MaNhanVien,MaTienTe,ThueGTGT,Phivanchuyen,PhiKhac,GhiChu,Deleted,MaKhachHang) 
		VALUES (@MaDonDatHang,@LoaiDonDatHang,@NgayDonHang,@MaNhaCungCap,@NoHienThoi,@TrangThaiDonDatHang,
			    @NgayNhapDuKien,@HinhThucThanhToan,@MaKho,@MaNhanVien,@MaTienTe,@ThueGTGT,@Phivanchuyen,@PhiKhac,@GhiChu,@Deleted,@MaKhachHang)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE DonDatHang
		 SET MaDonDatHang = @MaDonDatHang,
		     LoaiDonDatHang = @LoaiDonDatHang,
			 NgayDonHang = @NgayDonHang,
			 MaNhaCungCap = @MaNhaCungCap,
			 NoHienThoi = @NoHienThoi,
			 TrangThaiDonDatHang = @TrangThaiDonDatHang,
			 NgayNhapDuKien = @NgayNhapDuKien,
			 HinhThucThanhToan = @HinhThucThanhToan,
			 MaKho = @MaKho,
			 MaNhanVien = @MaNhanVien,
			 MaTienTe = @MaTienTe,
			 ThueGTGT = @ThueGTGT,
			 Phivanchuyen = @Phivanchuyen,
			 PhiKhac = @PhiKhac,
			 GhiChu = @GhiChu,
			 MaKhachHang=@MaKhachHang
		WHERE DonDatHangID=@DonDatHangID
	 END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_DonDatHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_DonDatHang
go
CREATE PROC sp_Xoa_DonDatHang
	@HanhDong nvarchar(20),
	@MaDonDatHang varchar(20)
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE DonDatHang 
		SET Deleted = N'True'
		WHERE MaDonDatHang = @MaDonDatHang
	 END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_DonDatHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_DonDatHang
go
CREATE PROCEDURE sp_LayBang_DonDatHang
	@MaDonDatHang varchar(20)
AS
	IF @MaDonDatHang=N''
	BEGIN
		SELECT DonDatHangID,MaDonDatHang ,LoaiDonDatHang,NgayDonHang , MaNhaCungCap, NoHienThoi,
			   TrangThaiDonDatHang , NgayNhapDuKien , HinhThucThanhToan,
			   MaKho,MaNhanVien , MaTienTe,ThueGTGT, Phivanchuyen, PhiKhac , GhiChu ,Deleted,MaKhachHang
		FROM DonDatHang Where Deleted = N'False'
	END
	ELSE
	BEGIN
		SELECT DonDatHangID,MaDonDatHang ,LoaiDonDatHang,NgayDonHang , MaNhaCungCap, NoHienThoi,
			   TrangThaiDonDatHang , NgayNhapDuKien , HinhThucThanhToan,
			   MaKho,MaNhanVien , MaTienTe,ThueGTGT, Phivanchuyen, PhiKhac , GhiChu ,Deleted,MaKhachHang
		FROM DonDatHang Where Deleted = N'False' AND MaDonDatHang like '%'+@MaDonDatHang+'%'
	END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_CapNhatTrangThaiDonDatHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_CapNhatTrangThaiDonDatHang
go
CREATE PROC sp_CapNhatTrangThaiDonDatHang
	@HanhDong nvarchar(20),
	@MaDonDatHang varchar(20),
	@TrangThaiDonDatHang nvarchar(20)
AS
BEGIN
	Declare @Error varchar(20)
	Set @Error=N'NO'
	IF @HanhDong =N'Check'
	BEGIN
		IF (Select COUNT(*) From DonDatHang Where MaDonDatHang=@MaDonDatHang And Deleted=N'False')>0
		BEGIN
			Set @Error=N'OK'
		END
		ELSE
		BEGIN
			Set @Error =N'NO'
		END
	END
	IF @HanhDong =N'Update'
	BEGIN
		Update DonDatHang
		Set TrangThaiDonDatHang=@TrangThaiDonDatHang
		Where MaDonDatHang=@MaDonDatHang And Deleted=N'False'
		IF @@ERROR=0
			Set @Error=N'OK'
		ELSE
			Set @Error=N'NO'
	END
	Select @Error AS ThongBao
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_ThongTinDonDatHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_ThongTinDonDatHang
go
CREATE PROCEDURE sp_LayBang_ThongTinDonDatHang
	@MaDonDatHang nvarchar(20)
as
begin
		SELECT a.MaHangHoa,a.TenHangHoa,b.SoLuong,a.GiaNhap,a.GiaBanBuon,a.GiaBanLe,b.PhanTramChietKhau,e.GiaTriThue
		FROM HangHoa a join ChiTietDonHang b
		on a.MaHangHoa = b.MaHangHoa join DonDatHang c
		on b.MaDonDatHang = c.MaDonDatHang join Thue e on a.MaThueGiaTriGiaTang = e.MaThue
		Where b.Deleted = N'False' and b.MaDonDatHang = @MaDonDatHang and c.Deleted=N'False' and a.Deleted=N'False'
end
GO
-----------------------------------------------------------------------------------------------------

GO
IF OBJECT_ID(N'[dbo].sp_LayHangHoaTheoMaHangHoa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayHangHoaTheoMaHangHoa
go
CREATE PROC sp_LayHangHoaTheoMaHangHoa
	@MaHangHoa varchar(50)
AS
BEGIN
	IF @MaHangHoa=''
	BEGIN
		SELECT a.MaHangHoa,a.TenHangHoa,a.GiaNhap,a.GiaBanBuon,a.GiaBanLe,e.GiaTriThue
		FROM HangHoa a join Thue e on a.MaThueGiaTriGiaTang = e.MaThue
		Where a.Deleted = N'False'
	END
	ELSE
	BEGIN
		SELECT a.MaHangHoa,a.TenHangHoa,a.GiaNhap,a.GiaBanBuon,a.GiaBanLe,e.GiaTriThue
		FROM HangHoa a join Thue e on a.MaThueGiaTriGiaTang = e.MaThue
		Where a.Deleted = N'False' and MaHangHoa = @MaHangHoa
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_XuLy_HoaDonNhap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_HoaDonNhap
go
CREATE PROCEDURE sp_XuLy_HoaDonNhap
	@HanhDong                               nvarchar(20),
	@HoaDonNhapID                           int,
	@MaHoaDonNhap	                        varchar(20),
	@NgayNhap	                            Datetime,				
	@MaNhaCungCap	                        nvarchar(20),
	@NoHienThoi	                            float,
	@NguoiGiaoHang	                        nvarchar(200),
	@HinhThucThanhToan	                    nvarchar(200),
	@MaKho	                                varchar(20) ,
	@HanThanhToan	                        Datetime,		
	@MaDonDatHang	                        varchar(20),
	@MaTienTe	                            varchar(20),
	@ChietKhau	                            float,
	@ThanhToanNgay	                        float,
	@ThueGTGT	                            float,			
	@TongTien	                            float,				
	@GhiChu	                                nvarchar(100),			
	@Deleted	                            bit,
	@ThanhToanSauKhiLapPhieu                 float
AS
BEGIN
	IF @MaDonDatHang='NULL' 
		Set @MaDonDatHang=NULL
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO HoaDonNhap 
		(MaHoaDonNhap,NgayNhap,MaNhaCungCap,NoHienThoi,NguoiGiaoHang,HinhThucThanhToan,
		 MaKho,HanThanhToan,MaDonDatHang,MaTienTe,ChietKhau,ThanhToanNgay,
		 ThueGTGT,TongTien,GhiChu,Deleted,ThanhToanSauKhiLapPhieu) 
		VALUES 
		(@MaHoaDonNhap,@NgayNhap,@MaNhaCungCap,@NoHienThoi,@NguoiGiaoHang,@HinhThucThanhToan,
		 @MaKho,@HanThanhToan,@MaDonDatHang,@MaTienTe,@ChietKhau,@ThanhToanNgay,@ThueGTGT,@TongTien,@GhiChu,@Deleted,@ThanhToanSauKhiLapPhieu)
	END
	IF @HanhDong = N'Update'
	BEGIN
		UPDATE HoaDonNhap
		SET MaHoaDonNhap = @MaHoaDonNhap,
			NgayNhap = @NgayNhap,
		    MaNhaCungCap = @MaNhaCungCap,
		    NoHienThoi = @NoHienThoi,
		    NguoiGiaoHang = @NguoiGiaoHang,
		    HinhThucThanhToan = @HinhThucThanhToan,
		    MaKho = @MaKho,
		    HanThanhToan = @HanThanhToan,
		    MaDonDatHang = @MaDonDatHang,
		    MaTienTe = @MaTienTe,
		    ChietKhau = @ChietKhau,
		    ThanhToanNgay = @ThanhToanNgay,
		    ThueGTGT = @ThueGTGT,
		    TongTien = @TongTien,
		    GhiChu = @GhiChu,
		    Deleted = N'False',
		    ThanhToanSauKhiLapPhieu = @ThanhToanSauKhiLapPhieu
		WHERE HoaDonNhapID = @HoaDonNhapID
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_HoaDonNhap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_HoaDonNhap
go
CREATE PROCEDURE sp_LayBang_HoaDonNhap
	@MaHoaDonNhap varchar(20),
	@MaKho varchar(20)
AS
	IF @MaHoaDonNhap=N''
	BEGIN
		SELECT HoaDonNhapID,MaHoaDonNhap,NgayNhap,MaNhaCungCap,NoHienThoi,NguoiGiaoHang,HinhThucThanhToan,
			   MaKho,HanThanhToan,MaDonDatHang,MaTienTe,ChietKhau,ThanhToanNgay,ThueGTGT,TongTien,GhiChu,Deleted,ThanhToanSauKhiLapPhieu
		FROM HoaDonNhap Where Deleted = N'False' and MaKho=@MaKho
	END
	ELSE
	BEGIN
	SELECT HoaDonNhapID,MaHoaDonNhap,NgayNhap,MaNhaCungCap,NoHienThoi,NguoiGiaoHang,HinhThucThanhToan,
			   MaKho,HanThanhToan,MaDonDatHang,MaTienTe,ChietKhau,ThanhToanNgay,ThueGTGT,TongTien,GhiChu,Deleted,ThanhToanSauKhiLapPhieu
		FROM HoaDonNhap Where Deleted = N'False' AND MaHoaDonNhap like '%'+@MaHoaDonNhap+'%' and MaKho=@MaKho
	END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_HoaDonNhap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_HoaDonNhap
go
CREATE PROC sp_Xoa_HoaDonNhap
	@HanhDong nvarchar(20),
	@MaHoaDonNhap varchar(20)
AS
BEGIN
	IF @HanhDong = N'Delete'
	BEGIN
		UPDATE HoaDonNhap SET Deleted = N'True'
		WHERE MaHoaDonNhap = @MaHoaDonNhap
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_XuLy_KhachHangTraLai') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_KhachHangTraLai
go
CREATE PROCEDURE sp_XuLy_KhachHangTraLai
	@HanhDong                                nvarchar(20),
	@KhachHangTraLaiID	                     int,
	@MaKhachHangTraLai	                     varchar(20),
	@NgayNhap	                             Datetime,		
	@MaKhachHang	                         nvarchar(20),
	@NoHienThoi	                             float,
	@NguoiTra	                             nvarchar(200),
	@HinhThucThanhToan	                     nvarchar(200),
	@HanThanhToan	                         Datetime,				
	@MaHoaDonMuaHang	                     varchar(20),
	@MaKho	                                 varchar(20) ,
	@MaTienTe	                             varchar(20),
	@TienBoiThuong	                         float,				
	@ThanhToanNgay	                         float,				
	@ThueGTGT	                             float,			
	@GhiChu	                                 nvarchar(100),				
	@Deleted	                             bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO KhachHangTraLai 
		(MaKhachHangTraLai,NgayNhap,MaKhachHang,NoHienThoi,NguoiTra,
		 HinhThucThanhToan,HanThanhToan,MaHoaDonMuaHang,
		 MaKho,MaTienTe,TienBoiThuong,ThanhToanNgay,ThueGTGT,GhiChu,Deleted) 
		 VALUES
		(@MaKhachHangTraLai,@NgayNhap,@MaKhachHang,@NoHienThoi,@NguoiTra,
		 @HinhThucThanhToan,@HanThanhToan,@MaHoaDonMuaHang,
		 @MaKho,@MaTienTe,@TienBoiThuong,@ThanhToanNgay,@ThueGTGT,@GhiChu,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		UPDATE KhachHangTraLai
		SET MaKhachHangTraLai = @MaKhachHangTraLai,
			NgayNhap = @NgayNhap,
		    MaKhachHang = @MaKhachHang,
		    NoHienThoi = @NoHienThoi,
		    NguoiTra = @NguoiTra,
		    HinhThucThanhToan = @HinhThucThanhToan,
		    HanThanhToan = @HanThanhToan,
		    MaHoaDonMuaHang = @MaHoaDonMuaHang,
		    MaKho = @MaKho,
		    MaTienTe = @MaTienTe,
		    TienBoiThuong = @TienBoiThuong,
		    ThanhToanNgay = @ThanhToanNgay,
		    ThueGTGT = @ThueGTGT,
		    GhiChu = @GhiChu
		WHERE KhachHangTraLaiID = @KhachHangTraLaiID
	 END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_KhachHangTraLai') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_KhachHangTraLai
go
CREATE PROCEDURE sp_LayBang_KhachHangTraLai
	@MaKhachHangTraLai varchar(20)
AS
BEGIN
	IF @MaKhachHangTraLai=N''
	BEGIN
		SELECT KhachHangTraLaiID, MaKhachHangTraLai, NgayNhap, MaKhachHang,
			   NoHienThoi, NguoiTra, HinhThucThanhToan, HanThanhToan,
			   MaHoaDonMuaHang, MaKho, MaTienTe, TienBoiThuong, ThanhToanNgay, ThueGTGT, GhiChu,Deleted
		FROM KhachHangTraLai Where Deleted = N'False'
	END
	ELSE
	BEGIN
		SELECT KhachHangTraLaiID, MaKhachHangTraLai, NgayNhap, MaKhachHang,
			   NoHienThoi, NguoiTra, HinhThucThanhToan, HanThanhToan,
			   MaHoaDonMuaHang, MaKho, MaTienTe, TienBoiThuong, ThanhToanNgay, ThueGTGT, GhiChu,Deleted
		FROM KhachHangTraLai Where Deleted = N'False' AND MaKhachHangTraLai like '%'+@MaKhachHangTraLai+'%'
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_KhachHangTraLai') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_KhachHangTraLai
go
CREATE PROC sp_Xoa_KhachHangTraLai
	@HanhDong nvarchar(20),
	@MaKhachHangTraLai varchar(20)
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE KhachHangTraLai SET Deleted = N'True'
		WHERE MaKhachHangTraLai = @MaKhachHangTraLai
	 END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_XuLy_KiemKeKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_KiemKeKho
go
CREATE PROCEDURE sp_XuLy_KiemKeKho
	@HanhDong nvarchar(20),
	@PhieuKiemKeKhoID int,
	@MaKiemKe	varchar(20),
	@NgayKiemKe	Datetime,	
	@MaKho	varchar(20) ,
	@GhiChu	nvarchar(100),			
	@Deleted bit	
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO KiemKeKho (MaKiemKe,NgayKiemKe,MaKho,GhiChu,Deleted )
		VALUES (@MaKiemKe,@NgayKiemKe,@MaKho,@GhiChu,@Deleted)
	END
	IF @HanhDong = N'Update'
	BEGIN
		UPDATE KiemKeKho
		SET MaKiemKe = @MaKiemKe,
			NgayKiemKe = @NgayKiemKe,
			MaKho = @MaKho,
			GhiChu = @GhiChu,
			Deleted = @Deleted
		WHERE PhieuKiemKeKhoID=@PhieuKiemKeKhoID
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_KiemKeKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_KiemKeKho
go
CREATE PROCEDURE sp_LayBang_KiemKeKho
	@MaKiemKe varchar(20)
AS
BEGIN
	IF @MaKiemKe=N''
	BEGIN
		SELECT PhieuKiemKeKhoID,MaKiemKe,NgayKiemKe,a.MaKho,b.TenKho,a.GhiChu,a.Deleted
		FROM KiemKeKho a join KhoHang b on a.MaKho=b.MaKho
		Where a.Deleted = N'False' AND b.Deleted=N'False' 
	END
	ELSE
	BEGIN
		SELECT PhieuKiemKeKhoID,MaKiemKe,NgayKiemKe,a.MaKho,b.TenKho,a.GhiChu,a.Deleted
		FROM KiemKeKho a join KhoHang b on a.MaKho=b.MaKho
		Where a.Deleted = N'False' AND b.Deleted=N'False'  AND MaKiemKe = @MaKiemKe
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_XuLy_TraLaiNhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_TraLaiNhaCungCap
go
CREATE PROCEDURE sp_XuLy_TraLaiNhaCungCap
	@HanhDong nvarchar(20),
	@TraLaiNCCID int,
	@MaHDTraLaiNCC varchar(20),
	@Ngaytra datetime,
	@MaNCC nvarchar(20),
	@NoHienThoi money,
	@NguoiNhanHang nvarchar(200),
	@HinhThucThanhToan nvarchar(200),
	@MaHoaDonNhap varchar(20),
	@MaKho varchar(20),
	@MaTienTe varchar(20),
	@TienBoiThuong float,
	@ThanhToanNgay float,
	@ThueGTGT float,
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO TraLaiNCC 
		(MaHDTraLaiNCC,Ngaytra,MaNCC,NoHienThoi,NguoiNhanHang,HinhThucThanhToan,MaHoaDonNhap,MaKho,MaTienTe,
		TienBoiThuong,ThanhToanNgay,ThueGTGT,GhiChu,Deleted)
		 VALUES 
		(@MaHDTraLaiNCC,@Ngaytra,@MaNCC,@NoHienThoi,@NguoiNhanHang,@HinhThucThanhToan,	
		 @MaHoaDonNhap,@MaKho,@MaTienTe,@TienBoiThuong,@ThanhToanNgay,@ThueGTGT,@GhiChu,@Deleted)
	END
	IF @HanhDong = N'Update'
	BEGIN
		UPDATE TraLaiNCC
		SET MaHDTraLaiNCC = @MaHDTraLaiNCC,
			Ngaytra = @Ngaytra,
			MaNCC = @MaNCC,
			NoHienThoi = @NoHienThoi,
			NguoiNhanHang = @NguoiNhanHang,
			HinhThucThanhToan = @HinhThucThanhToan,
			MaHoaDonNhap = @MaHoaDonNhap,
			MaKho = @MaKho,
			MaTienTe = @MaTienTe,
			TienBoiThuong = @TienBoiThuong,
			ThanhToanNgay = @ThanhToanNgay,
			ThueGTGT = @ThueGTGT,
			GhiChu = @GhiChu,
			Deleted = @Deleted
		WHERE TraLaiNCCID = @TraLaiNCCID
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_TraLaiNhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_TraLaiNhaCungCap
go
CREATE PROCEDURE sp_LayBang_TraLaiNhaCungCap
	@MaHDTraLaiNCC varchar(20)
AS
BEGIN
	IF @MaHDTraLaiNCC=N''
	BEGIN
		SELECT TraLaiNCCID,MaHDTraLaiNCC,Ngaytra,MaNCC,NoHienThoi,NguoiNhanHang,
			   HinhThucThanhToan,MaHoaDonNhap,MaKho,MaTienTe,
			   TienBoiThuong,ThanhToanNgay,ThueGTGT,GhiChu,Deleted
		FROM TraLaiNCC Where Deleted = N'False'
	END
	ELSE
	BEGIN
		SELECT TraLaiNCCID,MaHDTraLaiNCC,Ngaytra,MaNCC,NoHienThoi,NguoiNhanHang,
			   HinhThucThanhToan,MaHoaDonNhap,MaKho,MaTienTe,
			   TienBoiThuong,ThanhToanNgay,ThueGTGT,GhiChu,Deleted
		FROM TraLaiNCC Where Deleted = N'False' AND MaHDTraLaiNCC like '%'+MaHDTraLaiNCC+'%'
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_TraLaiNhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_TraLaiNhaCungCap
go
CREATE PROC sp_Xoa_TraLaiNhaCungCap
	@HanhDong nvarchar(20),
	@MaHDTraLaiNCC varchar(20)
AS
BEGIN
	IF @HanhDong = N'Delete'
	BEGIN
		UPDATE TraLaiNCC SET Deleted = N'True'
		WHERE MaHDTraLaiNCC = @MaHDTraLaiNCC
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_CongTy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_CongTy
go
CREATE PROC sp_LayBang_CongTy
	@MaCongTy varchar(20)
AS
BEGIN
	Declare @Kiemtra int
	Select @Kiemtra=COUNT(*) From CongTy Where MaCongTy=@MaCongTy
	IF @Kiemtra>0
	BEGIN
		SELECT CongTyID,MaCongTy ,TenCongTy,DiaChi,SoDienThoai,Email ,Website,Fax
		FROM CongTy
	END
	ELSE
	BEGIN
		SELECT CongTyID,MaCongTy ,TenCongTy,DiaChi,SoDienThoai,Email ,Website,Fax
		FROM CongTy 
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_ThongTinHienThiHoaDonNhap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_ThongTinHienThiHoaDonNhap
go
CREATE PROC sp_ThongTinHienThiHoaDonNhap
	@MaHoaDonNhap varchar(20),
	@MaKho varchar(20)
AS
BEGIN
	SELECT distinct(b.MaHangHoa),a.TenHangHoa,b.SoLuong,b.DonGia as 'GiaNhap',a.GiaBanBuon,a.GiaBanLe,b.PhanTramChietKhau,e.GiaTriThue,v.HanSuDung 
	FROM HangHoa a join Thue e 
	on a.MaThueGiaTriGiaTang = e.MaThue join ChiTietHoaDonNhap b
	on a.MaHangHoa = b.MaHangHoa join ChiTietKhoHang v
	on b.MaHangHoa = v.MaHangHoa
	Where b.MaHoaDonNhap=@MaHoaDonNhap AND b.Deleted=N'False' AND v.MaKho=@MaKho
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_ThongTinHoaDonBanHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_ThongTinHoaDonBanHang
go
CREATE PROCEDURE sp_ThongTinHoaDonBanHang
as
BEGIN
	Select MaHDBanHang,NgayBan,NguoiNhanHang,TongTienThanhToan From dbo.HDBanHang
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayDonDatHangNhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayDonDatHangNhaCungCap
go
CREATE PROC sp_LayDonDatHangNhaCungCap
AS
BEGIN
	Select a.MaDonDatHang,a.NgayDonHang,b.SoLuong, c.GiaNhap,b.PhanTramChietKhau
	From DonDatHang a join ChiTietDonHang b 
	on a.MaDonDatHang = b.MaDonDatHang join HangHoa c
	on b.MaHangHoa = c.MaHangHoa 
	WHERE a.Deleted=N'False' and a.LoaiDonDatHang=N'True' and a.TrangThaiDonDatHang=N'Đã thành công'
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayChiTietTraLaiNhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayChiTietTraLaiNhaCungCap
go
CREATE PROC sp_LayChiTietTraLaiNhaCungCap
	@MaNhaCungCap nvarchar(20)
AS
BEGIN
	Select a.MaDonDatHang,c.MaHangHoa,c.TenHangHoa,b.DonGia
	From DonDatHang a join ChiTietDonHang b 
	on a.MaDonDatHang = b.MaDonDatHang join HangHoa c
	on b.MaHangHoa = c.MaHangHoa 
	WHERE a.Deleted=N'False' and a.LoaiDonDatHang=N'True' and a.TrangThaiDonDatHang=N'Đã thành công' and a.MaNhaCungCap=@MaNhaCungCap
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_ChiTietDonDatHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_ChiTietDonDatHang
go
create PROCEDURE sp_LayBang_ChiTietDonDatHang
AS
BEGIN
	Select *
	From ChiTietDonHang Where Deleted = N'False'
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_ThongTinMaDonDatHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_ThongTinMaDonDatHang
go
CREATE PROCEDURE sp_LayBang_ThongTinMaDonDatHang
as
begin
	SELECT a.MaDonDatHang,a.NgayDonHang,b.SoLuong,c.GiaNhap,b.PhanTramChietKhau
	From  DonDatHang a join ChiTietDonHang b 
	on a.MaDonDatHang = b.MaDonDatHang join HangHoa c
	on b.MaHangHoa = c.MaHangHoa
	Where a.Deleted = N'False'
end
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_ChiTietTraLaiNhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_ChiTietTraLaiNhaCungCap
go
CREATE PROCEDURE sp_LayBang_ChiTietTraLaiNhaCungCap
AS
BEGIN
	SELECT MaHDTraLaiNCC,MaHangHoa ,SoLuong,DonGia,Thue,PhanTramChietKhau ,GhiChu,Deleted
    FROM ChiTietTraLaiNCC Where Deleted = N'False'
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_ChiTietKiemKeKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_ChiTietKiemKeKho
go
CREATE PROCEDURE sp_LayBang_ChiTietKiemKeKho
	@MaPhieuKiemKe varchar(20)
AS
BEGIN
	IF @MaPhieuKiemKe = N''
	BEGIN
		SELECT MaPhieuKiemKe ,MaHangHoa,TonThucTe ,TonSoSach ,LyDo ,GhiChu,Deleted
		FROM ChiTietKiemKeKho Where Deleted = N'False'
	END
	ELSE
	BEGIN
		SELECT a.MaPhieuKiemKe,a.MaHangHoa,TenHangHoa,TonThucTe ,TonSoSach ,LyDo ,GiaNhap
		FROM ChiTietKiemKeKho a join dbo.HangHoa b on a.MaHangHoa = b.MaHangHoa
		Where a.Deleted = N'False' and a.MaPhieuKiemKe=@MaPhieuKiemKe
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayTheoMaKiemKeKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayTheoMaKiemKeKho
go
Create PROCEDURE sp_LayTheoMaKiemKeKho
	@MaPhieuKiemKe varchar(20)
AS
BEGIN
		SELECT a.MaHangHoa,TenHangHoa ,a.TonSoSach ,a.TonThucTe,(a.TonThucTe - a.TonSoSach)AS N'ChenhLech',LyDo ,b.GiaNhap,((a.TonThucTe - a.TonSoSach)*b.GiaNhap)AS N'GiaChenhLech'
		FROM ChiTietKiemKeKho a join dbo.HangHoa b on a.MaHangHoa = b.MaHangHoa
		Where a.Deleted = N'False' and a.MaPhieuKiemKe=@MaPhieuKiemKe
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_ChiTietKhachHangTraLai') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_ChiTietKhachHangTraLai
go
CREATE PROCEDURE sp_LayBang_ChiTietKhachHangTraLai
AS
BEGIN
	SELECT KhachHangTraLaiID, MaKhachHangTraLai, NgayNhap, MaKhachHang,
		   NoHienThoi, NguoiTra, HinhThucThanhToan, HanThanhToan,
		   MaHoaDonMuaHang, MaKho, MaTienTe, TienBoiThuong, ThanhToanNgay, ThueGTGT, GhiChu,Deleted
	FROM KhachHangTraLai Where Deleted = N'False'
END
GO
-----------------------------------------------------------------------------------------------------
GO

-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_KiemTraMa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_KiemTraMa
go
CREATE  PROCEDURE sp_KiemTraMa
	 @MaHangHoa varchar(50),
	 @TenHangHoa nvarchar(50)
AS
BEGIN
	Declare @Trave varchar(20)
	IF (Select COUNT(*) From HangHoa WHERE MaHangHoa = @MaHangHoa AND Deleted = N'False')>0 OR
	   (Select COUNT(*) From GoiHang WHERE MaGoiHang=@MaHangHoa AND TenGoiHang=@TenHangHoa)>0
	BEGIN
		Set @Trave = 'OK'
	END
	ELSE
	BEGIN
		Set @Trave = 'NO'
	END
	Select @Trave AS ThongBao
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_XuLy_ChiTietHoaDonNhapKhoHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_ChiTietHoaDonNhapKhoHang
go
create PROCEDURE sp_XuLy_ChiTietHoaDonNhapKhoHang
	@HanhDong                               varchar(20),
	@MaKho	                                varchar(20),
	@MaHangHoa	                            varchar(50),
	@SoLuong	                            int,			
	@NgayNhap	                            datetime,	
	@HanSuDung								datetime,
	@GhiChu	                                nvarchar(100),		
	@Deleted	                            bit
AS
BEGIN
	IF @HanhDong = 'Insert'
	BEGIN
			IF (select COUNT(*) from ChiTietKhoHang where MaHangHoa=@MaHangHoa AND MaKho=@MaKho AND Deleted=N'False')>0
			BEGIN
				Declare @sl int
				select @sl=SoLuong from ChiTietKhoHang where MaHangHoa=@MaHangHoa AND MaKho=@MaKho 
				Update ChiTietKhoHang
				Set SoLuong=(@sl+@SoLuong)
					,HanSuDung = @HanSuDung
				Where MaKho=@MaKho AND MaHangHoa=@MaHangHoa AND Deleted=N'False'
			END
			ELSE
			BEGIN
				IF (select COUNT(*) from ChiTietKhoHang where MaHangHoa!=@MaHangHoa AND MaKho=@MaKho)>0
				BEGIN
					INSERT INTO ChiTietKhoHang(MaKho,MaHangHoa,SoLuong , NgayNhap,HanSuDung,GhiChu,Deleted)
					VALUES(@MaKho,@MaHangHoa,@SoLuong,@NgayNhap,@HanSuDung,@GhiChu,@Deleted)
				END
				ELSE
				BEGIN
					INSERT INTO ChiTietKhoHang(MaKho,MaHangHoa,SoLuong,NgayNhap,HanSuDung,GhiChu,Deleted)
					VALUES(@MaKho,@MaHangHoa,@SoLuong,@NgayNhap,@HanSuDung,@GhiChu,@Deleted)
				END
			END
	END
END

GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_HangHoa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_HangHoa
go
CREATE PROCEDURE sp_LayBang_HangHoa
	@MaHangHoa varchar(50)
as
begin
	IF @MaHangHoa=N''
	BEGIN
		SELECT a.MaHangHoa ,a.TenHangHoa ,a.GiaNhap,a.MucTonToiThieu,a.GiaBanBuon,a.GiaBanLe,b.GiaTriThue
		FROM HangHoa a join Thue b on a.MaThueGiaTriGiaTang=b.MaThue
		Where a.Deleted = N'False'
	END
	ELSE
	BEGIN
		SELECT a.MaHangHoa ,a.TenHangHoa ,a.GiaNhap,a.MucTonToiThieu,a.GiaBanBuon,a.GiaBanLe,b.GiaTriThue
		FROM HangHoa a join Thue b on a.MaThueGiaTriGiaTang=b.MaThue
		Where a.Deleted = N'False' AND MaHangHoa=@MaHangHoa
	END
end
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_KhoHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_KhoHang
go
CREATE PROCEDURE sp_LayBang_KhoHang
as
begin
	SELECT KhoHangID,MaKho,TenKho ,DiaChi ,DienThoai ,MaNhanVien ,GhiChu,Deleted 
	FROM KhoHang Where Deleted = N'False'
end
GO

-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_NhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_NhaCungCap
go
CREATE PROCEDURE sp_LayBang_NhaCungCap
	@MaNhaCungCap varchar(20)
as
begin
	IF @MaNhaCungCap=N''
	BEGIN
		SELECT MaNhaCungCap ,TenNhaCungCap ,DiaChi,DuNo
		FROM NhaCungCap Where Deleted = N'False'
	END
	ELSE
	BEGIN
		SELECT MaNhaCungCap ,TenNhaCungCap ,DiaChi,DuNo
		FROM NhaCungCap Where Deleted = N'False' AND MaNhaCungCap=@MaNhaCungCap
	END
end
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_ThongTinKhachHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_ThongTinKhachHang
go
CREATE PROCEDURE sp_LayBang_ThongTinKhachHang
	@MaKH varchar(20)
as
begin
	IF @MaKH=N''
	BEGIN
		SELECT  MaKH,Ten ,DiaChi,DuNo
		FROM KhachHang Where Deleted = N'False'
	END
	ELSE
	BEGIN
		SELECT  MaKH,Ten ,DiaChi,DuNo
		FROM KhachHang Where Deleted = N'False' AND MaKH=@MaKH
	END
end
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_ThongTinCongTy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_ThongTinCongTy
go
CREATE PROC sp_ThongTinCongTy
	@MaCongTy varchar(20)
AS
BEGIN
	IF @MaCongTy !=N''
	BEGIN
		Select MaCongTy,TenCongTy,DiaChi,SoDienThoai,Email,Website,Fax 
		From CongTy 
		Where MaCongTy=@MaCongTy
	END
	ELSE
	BEGIN
		Select MaCongTy,TenCongTy,DiaChi,SoDienThoai,Email,Website,Fax From CongTy 
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayCombox') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayCombox
go
create proc sp_LayCombox
	@tableName nvarchar(20),
	@columnID nvarchar(20),
	@columnName nvarchar(20)
as
begin
	declare @sql nvarchar(150)
	set @sql= N'select ['+@columnID+'] as ID,['+@columnName+'] from ['+@tableName+']  Where Deleted=N''False'''
	exec sp_executesql @sql
end
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_TienTe') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_TienTe
go
CREATE PROCEDURE sp_LayBang_TienTe
as
begin
	SELECT TienteID,MaTienTe ,TenTienTe,TenTienTeChan ,TenTienTeLe ,BieuTuong ,DonViLamTron ,GhiChu,Deleted
    FROM TienTe  Where Deleted = N'False'
end
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_BaoCao_XuatTheoKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_BaoCao_XuatTheoKho
go
CREATE PROCEDURE sp_BaoCao_XuatTheoKho
   @MaKho varchar(20),
   @NgayBan datetime
AS
BEGIN
	IF @NgayBan=N'' AND @MaKho!=N''
	BEGIN
		SELECT a.MaKho,a.MaNhanVien,c.TenHangHoa,b.SoLuong,a.TongTienThanhToan
		FROM HDBanHang a join ChiTietHDBanHang b
		on a.MaHDBanHang = b.MaHDBanHang join dbo.HangHoa c
		on b.MaHangHoa = c.MaHangHoa
		Where a.Deleted = N'False' AND a.MaKho=@MaKho
	END
	ELSE
	BEGIN
		IF @NgayBan!=N'' AND @MaKho!=N''
		BEGIN
			SELECT a.MaKho,a.MaNhanVien,c.TenHangHoa,b.SoLuong,a.TongTienThanhToan
			FROM HDBanHang a join ChiTietHDBanHang b
			on a.MaHDBanHang = b.MaHDBanHang join dbo.HangHoa c
			on b.MaHangHoa = c.MaHangHoa
			Where a.Deleted = N'False' AND a.MaKho=@MaKho AND a.NgayBan=@NgayBan
		END
		ELSE
		BEGIN
			SELECT a.MaKho,a.MaNhanVien,c.TenHangHoa,b.SoLuong,a.TongTienThanhToan
			FROM HDBanHang a join ChiTietHDBanHang b
			on a.MaHDBanHang = b.MaHDBanHang join dbo.HangHoa c
			on b.MaHangHoa = c.MaHangHoa
			Where a.Deleted = N'False'
		END
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_BaoCao_XuatTheoNhomHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_BaoCao_XuatTheoNhomHang
go
CREATE PROCEDURE sp_BaoCao_XuatTheoNhomHang
   @MaNhomHang varchar(20),
   @NgayBan datetime
AS
BEGIN
	IF @NgayBan=N'' AND @MaNhomHang!=N''
	BEGIN
		SELECT d.TenNhomHang,a.MaKho,c.TenHangHoa,b.SoLuong,a.TongTienThanhToan 
		From dbo.HDBanHang a join dbo.ChiTietHDBanHang b
		on a.MaHDBanHang=b.MaHDBanHang join dbo.HangHoa c
		on b.MaHangHoa=c.MaHangHoa join dbo.NhomHang d
		on c.MaNhomHangHoa=d.MaNhomHang
		Where a.Deleted = N'False' AND d.MaNhomHang=@MaNhomHang
	END
	ELSE
	BEGIN
		IF @NgayBan!=N'' AND @MaNhomHang!=N''
		BEGIN
			SELECT d.TenNhomHang,a.MaKho,c.TenHangHoa,b.SoLuong,a.TongTienThanhToan 
			From dbo.HDBanHang a join dbo.ChiTietHDBanHang b
			on a.MaHDBanHang=b.MaHDBanHang join dbo.HangHoa c
			on b.MaHangHoa=c.MaHangHoa join dbo.NhomHang d
			on c.MaNhomHangHoa=d.MaNhomHang
			Where a.Deleted = N'False' AND a.NgayBan=@NgayBan AND d.MaNhomHang=@MaNhomHang
		END
		ELSE
		BEGIN
			SELECT d.TenNhomHang,a.MaKho,c.TenHangHoa,b.SoLuong,a.TongTienThanhToan 
			From dbo.HDBanHang a join dbo.ChiTietHDBanHang b
			on a.MaHDBanHang=b.MaHDBanHang join dbo.HangHoa c
			on b.MaHangHoa=c.MaHangHoa join dbo.NhomHang d
			on c.MaNhomHangHoa=d.MaNhomHang
			Where a.Deleted = N'False'
		END
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_ChiTietHoaDonNhap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_ChiTietHoaDonNhap
go
CREATE PROCEDURE sp_LayBang_ChiTietHoaDonNhap
AS
	SELECT MaHoaDonNhap,MaHangHoa,SoLuong ,PhanTramChietKhau ,GhiChu,Deleted
	FROM ChiTietHoaDonNhap Where Deleted = N'False'
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_ChiTietHoaDonNhap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_ChiTietHoaDonNhap
go
CREATE PROC sp_Xoa_ChiTietHoaDonNhap
	@HanhDong nvarchar(20),
	@MaHoaDonNhap varchar(20),
	@MaHangHoa varchar(50)
AS
BEGIN
	IF @HanhDong = N'MaHoaDonNhap'
	BEGIN
		UPDATE ChiTietHoaDonNhap SET Deleted = N'True'
		WHERE MaHoaDonNhap = @MaHoaDonNhap
	END
	IF @HanhDong = N'MaHangHoa'
	BEGIN
		UPDATE ChiTietHoaDonNhap SET Deleted = N'True'
		WHERE MaHangHoa = @MaHangHoa
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_ChiTietKhachHangTraLai') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_ChiTietKhachHangTraLai
go
CREATE PROCEDURE sp_Xoa_ChiTietKhachHangTraLai
	@HanhDong                                nvarchar(20),
	@MaKhachHangTraLai	                     varchar(20),
	@MaHangHoa	                             varchar(50)
AS
BEGIN
	IF @HanhDong = 'MaKhachHangTraLai'
	BEGIN
		Update ChiTietKhachHangTraLai
		Set Deleted = 'True'
		Where MaKhachHangTraLai = @MaKhachHangTraLai
	END
	IF @HanhDong = 'MaHangHoa'
	BEGIN
		Update ChiTietKhachHangTraLai
		Set Deleted = 'True'
		Where MaHangHoa = @MaHangHoa
	END
END
GO
------------------------------------------------------------cong them so luong trong kho------------------
GO
IF OBJECT_ID(N'[dbo].sp_CongKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_CongKho
go
CREATE PROC sp_CongKho
	@MaKho varchar(20),
	@MaHangHoa varchar(50),
	@SoLuong int
AS
BEGIN
	Declare @sl int
	Select @sl=SoLuong from ChiTietKhoHang Where MaKho=@MaKho and MaHangHoa=@MaHangHoa and Deleted=N'False'
	--IF @sl>0
	--BEGIN
			Update ChiTietKhoHang
			Set SoLuong=(@sl+@SoLuong)
			Where MaKho=@MaKho and MaHangHoa=@MaHangHoa and Deleted=N'False'
	--END
	--ELSE
	--BEGIN
	--		Insert Into ChiTietKhoHang(MaKho,MaHangHoa,SoLuong,NgayNhap,HanSuDung,GhiChu,Deleted)
	--		Values(@MaKho,@MaHangHoa,@SoLuong,GETDATE(),GETDATE(),'Khách hàng trả lại hàng hãy nhập lại hạn sử dụng',0)
	--END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_XuLy_ChiTietKhachHangTraLai') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_ChiTietKhachHangTraLai
go
Create PROCEDURE sp_XuLy_ChiTietKhachHangTraLai
	@HanhDong                                nvarchar(20),
	@MaKhachHangTraLai	                     varchar(20),
	@MaHangHoa	                             varchar(50),
	@TenHangHoa nvarchar(200),
	@SoLuong	                             int,			
	@PhanTramChietKhau	                     float,	
	@DonGia									 float,
	@Thue									 float,				
	@GhiChu	                                 nvarchar(100),			
	@Deleted	                             bit,
	@MaKho                                   varchar(20)
AS
INSERT INTO  ChiTietKhachHangTraLai(MaKhachHangTraLai ,MaHangHoa ,TenHangHoa,SoLuong ,PhanTramChietKhau ,DonGia,Thue,GhiChu,Deleted) 
VALUES(@MaKhachHangTraLai ,@MaHangHoa ,@TenHangHoa,@SoLuong ,@PhanTramChietKhau ,@DonGia,@Thue,@GhiChu,@Deleted)
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_XuLy_ChiTietHoaDonNhap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_ChiTietHoaDonNhap
go
CREATE PROCEDURE sp_XuLy_ChiTietHoaDonNhap
	@HanhDong                               varchar(20),
	@MaHoaDonNhap	                        varchar(20),
	@MaHangHoa	                            varchar(50),
	@SoLuong	                            int,			
	@PhanTramChietKhau	                    float,	
	@DonGia float,
	@Thue float,			
	@GhiChu	                                nvarchar(100),		
	@Deleted	                            bit
AS
BEGIN
	IF @HanhDong = 'Insert'
	BEGIN
		IF ((Select COUNT(*) From ChiTietHoaDonNhap a Where a.MaHoaDonNhap=@MaHoaDonNhap AND a.MaHangHoa=@MaHangHoa AND a.Deleted=N'False')<=0)
		BEGIN
			INSERT INTO ChiTietHoaDonNhap(MaHoaDonNhap,MaHangHoa,SoLuong ,PhanTramChietKhau ,DonGia,Thue,GhiChu,Deleted)
			VALUES(@MaHoaDonNhap, @MaHangHoa, @SoLuong,@PhanTramChietKhau,@DonGia,@Thue,@GhiChu,@Deleted)
		END
		ELSE
		BEGIN
			Update ChiTietHoaDonNhap
			Set SoLuong=@SoLuong
			Where MaHoaDonNhap=@MaHoaDonNhap AND MaHangHoa=@MaHangHoa AND Deleted=N'False'
		END
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_XuLy_ChiTietKiemKeKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_ChiTietKiemKeKho
go
CREATE PROCEDURE sp_XuLy_ChiTietKiemKeKho
	@HanhDong                             nvarchar(20),
	@MaPhieuKiemKe	                      varchar(20),
	@MaHangHoa	                          varchar(50),
	@TonThucTe	                          int,
	@TonSoSach	                          int,			
	@LyDo	                              nvarchar(200),
	@GhiChu	                              nvarchar(100),			
	@Deleted	                          bit
AS
BEGIN
	    IF ((Select COUNT(*) From ChiTietKiemKeKho a Where a.MaPhieuKiemKe=@MaPhieuKiemKe AND a.MaHangHoa=@MaHangHoa AND a.Deleted=N'False')<=0)
		BEGIN
			INSERT INTO ChiTietKiemKeKho(MaPhieuKiemKe ,MaHangHoa,TonThucTe ,TonSoSach ,LyDo ,GhiChu ,Deleted)
			VALUES (@MaPhieuKiemKe,@MaHangHoa,@TonThucTe,@TonSoSach,@LyDo,@GhiChu,@Deleted)
		END
		ELSE
		BEGIN
			Update ChiTietKiemKeKho
			Set TonThucTe=@TonThucTe,
				TonSoSach=@TonSoSach,
				LyDo=@LyDo,
				GhiChu=@GhiChu
			Where MaPhieuKiemKe=@MaPhieuKiemKe AND MaHangHoa=@MaHangHoa AND Deleted=N'False'
		END
END
GO
------------------------------------------------------------tru so luong trong kho------------------
GO
IF OBJECT_ID(N'[dbo].sp_TruKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_TruKho
go
CREATE PROC sp_TruKho
	@MaKho varchar(20),
	@MaHangHoa varchar(50),
	@SoLuong int
AS
BEGIN
	Declare @sl int,@Error varchar(20)
			print @MaHangHoa
	IF @MaKho!='' AND @MaHangHoa!='' AND @SoLuong>0
	BEGIN
		Select @sl=SoLuong from ChiTietKhoHang Where MaKho=@MaKho and MaHangHoa=@MaHangHoa and Deleted=N'False'
		--IF @sl>@SoLuong
		--BEGIN
				Update ChiTietKhoHang
				Set SoLuong=(@sl-@SoLuong)
				Where MaKho=@MaKho and MaHangHoa=@MaHangHoa and Deleted=N'False'
				IF @@ERROR=0
				BEGIN
					Set @Error = N'OK'
				END
				ELSE
				BEGIN	
					Set @Error = N'NO'
				END
		--END
		--IF @sl<@SoLuong 
		--BEGIN
		--	Set @Error = N'NO'
		--END
		--IF @sl=@SoLuong 
		--BEGIN
		--		Update ChiTietKhoHang
		--		Set Deleted=N'False'
		--		Where MaKho=@MaKho and MaHangHoa=@MaHangHoa and Deleted=N'False'
		--		IF @@ERROR=0
		--		BEGIN
		--			Set @Error = N'OK'
		--		END
		--		ELSE
		--		BEGIN	
		--			Set @Error = N'NO'
		--		END
		--END
	END
	ELSE
	BEGIN
		Set @Error = N'OK'
	END
	Select @Error AS 'ThongBao'
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_XuLy_ChiTietTraLaiNhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_ChiTietTraLaiNhaCungCap
go
CREATE PROCEDURE sp_XuLy_ChiTietTraLaiNhaCungCap
	@HanhDong                       nvarchar(20),
	@MaHDTraLaiNCC	                varchar(20),
	@MaHangHoa	                    varchar(50) ,
	@SoLuong	                    float,
	@DonGia							float,
	@Thue							float,
	@PhanTramChietKhau	            float,
	@GhiChu	                        nvarchar(100),
	@Deleted	                    bit,
	@MaKho                          varchar(20)
AS
BEGIN
	    IF ((Select COUNT(*) From ChiTietTraLaiNCC Where MaHDTraLaiNCC=@MaHDTraLaiNCC AND MaHangHoa=@MaHangHoa AND Deleted=N'False')<=0)
		BEGIN
			INSERT INTO ChiTietTraLaiNCC(MaHDTraLaiNCC ,MaHangHoa ,SoLuong ,DonGia,Thue,PhanTramChietKhau ,GhiChu ,Deleted)
			VALUES(@MaHDTraLaiNCC ,@MaHangHoa,@SoLuong,@DonGia,@Thue,@PhanTramChietKhau ,@GhiChu ,@Deleted)
			IF @@ERROR = 0
			BEGIN
				exec sp_TruKho @MaKho,@MaHangHoa,@SoLuong
			END
		END
		ELSE
		BEGIN
			Update ChiTietTraLaiNCC
			Set SoLuong=@SoLuong,
				PhanTramChietKhau=@PhanTramChietKhau
			Where MaHDTraLaiNCC=@MaHDTraLaiNCC AND MaHangHoa=@MaHangHoa AND Deleted=N'False'
			IF @@ERROR = 0
			BEGIN
				exec sp_TruKho @MaKho,@MaHangHoa,@SoLuong
			END
		END
END
GO

-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].Xoa_ChiTietDonDatHang') IS NOT NULL
 DROP PROCEDURE [dbo].Xoa_ChiTietDonDatHang
go
CREATE PROCEDURE Xoa_ChiTietDonDatHang
	@HanhDong nvarchar(20),
	@MaDonDatHang nvarchar(20),
	@MaHangHoa nvarchar(50)
AS
BEGIN
	IF @HanhDong = 'MaDonDatHang'
	BEGIN
		Update ChiTietDonHang 
		Set Deleted = N'True'
		Where MaDonDatHang=@MaDonDatHang
	END
	IF @HanhDong = 'MaHangHoa'
	BEGIN
		Update ChiTietDonHang 
		Set Deleted = N'True'
		Where MaHangHoa=@MaHangHoa
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_CapNhat') IS NOT NULL
 DROP PROCEDURE [dbo].sp_CapNhat
go
CREATE PROC sp_CapNhat
	@HanhDong varchar(20),
	@MaCapNhat varchar(20)
AS
BEGIN
	IF @HanhDong=N'DonDatHang'
	BEGIN
		IF (Select COUNT(*) From ChiTietDonHang Where MaDonDatHang=@MaCapNhat AND Deleted=N'False')>0
		BEGIN
			Update ChiTietDonHang Set Deleted=N'True' Where MaDonDatHang=@MaCapNhat AND Deleted=N'False'
		END
	END
	IF @HanhDong=N'HoaDonNhap'
	BEGIN
		IF (Select COUNT(*) From ChiTietHoaDonNhap Where MaHoaDonNhap=@MaCapNhat AND Deleted=N'False')>0
		BEGIN
			Update ChiTietHoaDonNhap Set Deleted=N'True' Where MaHoaDonNhap=@MaCapNhat AND Deleted=N'False'
		END
	END
	IF @HanhDong=N'KhachHangTraLai'
	BEGIN
		IF (Select COUNT(*) From ChiTietKhachHangTraLai Where MaKhachHangTraLai=@MaCapNhat AND Deleted=N'False')>0
		BEGIN
			Update ChiTietKhachHangTraLai Set Deleted=N'True' Where MaKhachHangTraLai=@MaCapNhat AND Deleted=N'False'
		END
	END
	IF @HanhDong=N'TraLaiNhaCungCap'
	BEGIN
		IF (Select COUNT(*) From ChiTietTraLaiNCC Where MaHDTraLaiNCC=@MaCapNhat AND Deleted=N'False')>0
		begin
			Update ChiTietTraLaiNCC Set Deleted=N'True' Where MaHDTraLaiNCC=@MaCapNhat AND Deleted=N'False'
		end
	END
	IF @HanhDong=N'KiemKeKho'
	BEGIN
		IF (Select COUNT(*) From ChiTietKiemKeKho Where MaPhieuKiemKe=@MaCapNhat AND Deleted=N'False')>0
		begin
			Update ChiTietKiemKeKho Set Deleted=N'True' Where MaPhieuKiemKe=@MaCapNhat AND Deleted=N'False'
		end
	END
	IF @HanhDong=N'KhoHang'
	BEGIN
		IF (Select COUNT(*) From ChiTietKhoHang Where MaKho=@MaCapNhat AND Deleted=N'False')>0
		begin
		Update dbo.ChiTietKhoHang Set Deleted=N'True' Where MaKho=@MaCapNhat AND Deleted=N'False'
		end
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].XuLy_ChiTietDonDatHang') IS NOT NULL
 DROP PROCEDURE [dbo].XuLy_ChiTietDonDatHang
go
Create PROCEDURE XuLy_ChiTietDonDatHang
	@HanhDong nvarchar(20),
	@MaDonDatHang nvarchar(20),
	@MaHangHoa nvarchar(50),
	@TenHangHoa nvarchar(200),
	@SoLuong int,
	@DonGia float,
	@Thue float,
	@PhanTramChietKhau float,
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong=N'Insert'
	BEGIN
		INSERT INTO ChiTietDonHang (MaDonDatHang ,MaHangHoa,TenHangHoa,SoLuong,DonGia,Thue ,PhanTramChietKhau ,GhiChu ,Deleted)
		VALUES(@MaDonDatHang ,@MaHangHoa,@TenHangHoa,@SoLuong,@DonGia,@Thue ,@PhanTramChietKhau ,@GhiChu ,@Deleted) 
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_ChiTietKiemKeKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_ChiTietKiemKeKho
go
CREATE PROCEDURE sp_Xoa_ChiTietKiemKeKho
	@HanhDong                             nvarchar(20),
	@MaPhieuKiemKe	                      varchar(20),
	@MaHangHoa                            varchar(50)
AS
BEGIN
	IF @HanhDong = 'MaPhieuKiemKe'
	BEGIN
		Delete from ChiTietKiemKeKho
		Where MaPhieuKiemKe = @MaPhieuKiemKe
	END
	IF @HanhDong = 'MaHangHoa'
	BEGIN
		Delete from ChiTietKiemKeKho
		Where MaHangHoa = @MaHangHoa
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_ChiTietTraLaiNhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_ChiTietTraLaiNhaCungCap
go
CREATE PROCEDURE sp_Xoa_ChiTietTraLaiNhaCungCap
	@HanhDong                       nvarchar(20),
	@MaHDTraLaiNCC	                varchar(20),
	@MaHangHoa	                    varchar(50) 
AS
BEGIN
	IF @HanhDong = 'MaHDTraLaiNCC'
	BEGIN
		Update ChiTietTraLaiNCC
		Set Deleted = N'True'
		Where MaHDTraLaiNCC=@MaHDTraLaiNCC
	END
	IF @HanhDong = 'MaHangHoa'
	BEGIN
		Update ChiTietTraLaiNCC
		Set Deleted = N'True'
		Where MaHangHoa=@MaHangHoa
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayThongTinTienTe') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayThongTinTienTe
go
CREATE PROCEDURE sp_LayThongTinTienTe
AS
BEGIN
	BEGIN
		Select MaTienTe,TenTienTe,DonViLamTron from dbo.TienTe Where Deleted=N'False'
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_ThongTinHoaDonnhap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_ThongTinHoaDonnhap
go
CREATE PROCEDURE sp_LayBang_ThongTinHoaDonnhap
	@MaNhaCungCap varchar(20)
as
begin
	IF @MaNhaCungCap =N''
	BEGIN
		SELECT  MaDonDatHang,NgayDonHang,NgayNhapDuKien
		FROM DonDatHang Where Deleted = N'False' And TrangThaiDonDatHang!=N'Đã thành công'
	END
	IF @MaNhaCungCap!=N''
	BEGIN
		SELECT  MaDonDatHang,NgayDonHang,NgayNhapDuKien
		FROM DonDatHang Where Deleted = N'False' And TrangThaiDonDatHang!=N'Đã thành công' AND MaNhaCungCap=@MaNhaCungCap
	END
end
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_ThongTinMaVachHangHoa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_ThongTinMaVachHangHoa
go
CREATE PROCEDURE sp_LayBang_ThongTinMaVachHangHoa
as
begin
	SELECT  MaHangHoa,TenHangHoa,GiaNhap,GiaBanBuon,GiaBanLe,GhiChu
	FROM HangHoa Where Deleted = N'False'
end
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_MaVach') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_MaVach
go
CREATE PROCEDURE sp_LayBang_MaVach
	@MaHangHoa varchar(50),
	@TenHangHoa varchar(50)
as
begin
	SELECT @MaHangHoa,@TenHangHoa
end
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_KhachHangTraLaiHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_KhachHangTraLaiHang
go
create PROCEDURE sp_KhachHangTraLaiHang
	@MaKhachHang nvarchar(20),
	@MaHDBanHang varchar(20),
	@LoaiHoaDon varchar(20)
as
begin 
	IF @MaKhachHang!=N'' AND @LoaiHoaDon=N'BanBuon' AND @MaHDBanHang=N''
	BEGIN
		Select MaHDBanHang,NgayBan,TongTienThanhToan,NoHienThoi,MaKho
		From HDBanHang Where MaKhachHang=@MaKhachHang AND Deleted=0 AND LoaiHoaDon=0
	END
	else IF @MaKhachHang!=N'' AND @LoaiHoaDon=N'BanLe' AND @MaHDBanHang=N''
	BEGIN
		Select MaHDBanHang,NgayBan,TongTienThanhToan,NoHienThoi,MaKho
		From HDBanHang Where MaKhachHang=@MaKhachHang AND Deleted=0 AND LoaiHoaDon=1
	END
	else IF @MaHDBanHang!=N'' AND @MaKhachHang=N''
	BEGIN
		IF @LoaiHoaDon =N'BanBuon'
		BEGIN
			Select b.MaHangHoa,c.TenHangHoa,b.SoLuong,c.GiaBanBuon,b.PhanTramChietKhau,a.ChietKhau,a.TongTienThanhToan,a.ThueGTGT,a.MaKho
			From HDBanHang a join ChiTietHDBanHang b 
			on a.MaHDBanHang=b.MaHDBanHang join HangHoa c 
			on b.MaHangHoa=c.MaHangHoa
			Where b.MaHDBanHang=@MaHDBanHang AND b.Deleted=0 AND a.LoaiHoaDon=0
		END
		else IF @LoaiHoaDon =N'BanLe' AND @MaKhachHang=N''
		BEGIN
			Select b.MaHangHoa,c.TenHangHoa,b.SoLuong,c.GiaBanLe,b.PhanTramChietKhau,a.ChietKhau,a.TongTienThanhToan,a.ThueGTGT,a.MaKho
			From HDBanHang a join ChiTietHDBanHang b 
			on a.MaHDBanHang=b.MaHDBanHang join HangHoa c 
			on b.MaHangHoa=c.MaHangHoa
			Where b.MaHDBanHang=@MaHDBanHang AND b.Deleted=0 AND a.LoaiHoaDon=1
		END
	END
	else IF @MaHDBanHang='' AND @MaKhachHang=N''
	BEGIN
			Select MaHDBanHang,NgayBan,TongTienThanhToan,NoHienThoi,MaKho
		From HDBanHang Where Deleted=0 AND LoaiHoaDon=1
		END
end
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_TimHoaDonNhapTheoMaNhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_TimHoaDonNhapTheoMaNhaCungCap
go
CREATE PROCEDURE sp_TimHoaDonNhapTheoMaNhaCungCap
	@MaNhaCungCap nvarchar(20),
	@MaHoaDonNhap varchar(20)
as
begin
	IF @MaNhaCungCap!=''
	BEGIN
		Select MaHoaDonNhap,NgayNhap,TongTien,NoHienThoi,MaKho
		From HoaDonNhap Where MaNhaCungCap=@MaNhaCungCap
	END
	IF @MaHoaDonNhap !=N''
	BEGIN
		BEGIN
			Select b.MaHangHoa,c.TenHangHoa,b.SoLuong,c.GiaNhap,b.PhanTramChietKhau,a.ChietKhau,TongTien,a.ThueGTGT
			From HoaDonNhap a join ChiTietHoaDonNhap b 
			on a.MaHoaDonNhap=b.MaHoaDonNhap join HangHoa c 
			on b.MaHangHoa=c.MaHangHoa
			Where b.MaHoaDonNhap=@MaHoaDonNhap AND b.Deleted=N'False'
		END
	END
end
GO
-----------------------------------------------------------------------------------------------------
GO
--CREATE PROC sp_XemKhoHang
--	@MaKho nvarchar(20)
--AS
--BEGIN
--	 Select c.MaHangHoa,a.TenKho,c.TenHangHoa,b.SoLuong,c.GiaNhap,b.NgayNhap, (c.GiaNhap*b.SoLuong)AS 'TongTien'
--	 From dbo.KhoHang a join dbo.ChiTietKhoHang b 
--	 on a.MaKho=b.MaKho join dbo.HangHoa c on b.MaHangHoa=c.MaHangHoa
--	 where a.Deleted='False' AND a.MaKho=@MaKho
--END
--GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_TheoTenBang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_TheoTenBang
go
CREATE proc sp_LayBang_TheoTenBang
	@table nvarchar(100),
	@values nvarchar(50)
as
begin
	declare @col nvarchar(100), @sql nvarchar(150)
	set @col = (select column_name from information_schema.columns where table_name = @table and ordinal_position=2)
	set @sql= N'select top(1) * from ['+@table+'] Where ['+@col+'] ='''+@values+''''
	exec sp_executesql @sql
end
GO
-----------------------------------------------------------------kho hang-----------------------------
go
IF OBJECT_ID(N'[dbo].[sp_SelectKhoHangsAll]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_SelectKhoHangsAll]
go
CREATE PROCEDURE sp_SelectKhoHangsAll
AS
BEGIN
	SELECT *
	FROM KhoHang WHERE Deleted = 0
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_XuLy_KhoHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_KhoHang
go
Create PROCEDURE sp_XuLy_KhoHang	
				@HanhDong nvarchar(20),
				@KhoHangID int,
				@MaKho varchar(20),
				@TenKho nvarchar(200),
				@DiaChi nvarchar(200),
				@DienThoai nvarchar(20),
				@MaNhanVien	 nvarchar(20),
				@GhiChu nvarchar(250),
				@Deleted bit
AS
BEGIN
	Declare @Error varchar(20)
	Set @Error =N'NO'
	IF @HanhDong = N'Insert'
	BEGIN
		--IF(Select COUNT(*) From KhoHang Where MaNhanVien=@MaNhanVien AND Deleted=N'False')<=0
		--BEGIN
			INSERT INTO KhoHang (MaKho,TenKho,DiaChi,DienThoai,MaNhanVien,GhiChu,Deleted) 
			VALUES (@MaKho,@TenKho,@DiaChi,@DienThoai,@MaNhanVien,@GhiChu,@Deleted)
			IF @@ERROR=0
			BEGIN
				Set @Error =N'OK'
			END
			ELSE
			BEGIN
				Set @Error =N'NO'
			END
		--END
		--ELSE
		--BEGIN
			--Set @Error =N'NOS'
		--END
	END
	IF @HanhDong = N'Update'
	BEGIN
		--IF(Select COUNT(*) From KhoHang Where MaNhanVien=@MaNhanVien AND  MaKho!=@MaKho AND Deleted=N'False')<= 0
		--BEGIN
			UPDATE KhoHang
			SET MaKho=@MaKho,
				TenKho=@TenKho,
				DiaChi=@DiaChi,
				DienThoai=@DienThoai,
				MaNhanVien=@MaNhanVien,
				GhiChu=@GhiChu,
				Deleted=@Deleted
			WHERE KhoHangID = @KhoHangID AND Deleted=N'False'
			IF @@ERROR=0
			BEGIN
				Set @Error =N'OK'
			END
			ELSE
			BEGIN
				Set @Error =N'NO'
			END
		--END
		--ELSE
		--BEGIN
			--Set @Error =N'NOS'
		--END
	END
	Select @Error AS ThongBao
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_XemKhoHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XemKhoHang
go
Create PROC sp_XemKhoHang
	@MaKho nvarchar(20)
AS
BEGIN
	 Select a.MaKho,a.TenKho,c.TenHangHoa,c.GiaNhap,b.SoLuong,b.NgayNhap,b.HanSuDung ,(c.GiaNhap * b.SoLuong) As 'TongTien' ,c.MaHangHoa
	 From dbo.KhoHang a join dbo.ChiTietKhoHang b 
	 on a.MaKho=b.MaKho join dbo.HangHoa c on b.MaHangHoa=c.MaHangHoa
	 where a.Deleted='False' AND a.MaKho=@MaKho
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_KhoHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_KhoHang
go
CREATE PROC sp_Xoa_KhoHang
	@HanhDong nvarchar(20),
	@KhoHangID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE KhoHang SET Deleted = N'True'
		WHERE KhoHangID = @KhoHangID and Deleted = N'False'
	 END
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_KiemKeKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_KiemKeKho
go
CREATE PROC sp_Xoa_KiemKeKho
	@HanhDong nvarchar(20),
	@MaKiemKe varchar(20)
AS
BEGIN
	IF @HanhDong = N'Delete'
	BEGIN
		UPDATE KiemKeKho SET Deleted = N'True'
		WHERE MaKiemKe = @MaKiemKe
	END
END
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_KiemTraDonDatHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_KiemTraDonDatHang
go
CREATE PROC sp_KiemTraDonDatHang
	@HanhDong varchar(20),
	@MaDonDatHang varchar(20)
AS
BEGIN
	Declare @Error nvarchar(50),@LoaiDon nvarchar(20) 
	Set @Error=N'NO'
	Set @LoaiDon = N'NO'
	IF @HanhDong =N'ThanhCong'
	BEGIN
		IF (select COUNT(*) From DonDatHang Where MaDonDatHang=@MaDonDatHang AND Deleted=N'False' AND TrangThaiDonDatHang=N'Đã thành công')>0
		BEGIN
			select @LoaiDon=LoaiDonDatHang From DonDatHang Where MaDonDatHang=@MaDonDatHang AND Deleted=N'False' AND TrangThaiDonDatHang=N'Đã thành công'
			Set @Error='Yes'
		END
		ELSE
		BEGIN
			Set @Error=N'NO'
			Set @LoaiDon = N'NO'
		END
	END
	IF @HanhDong =N'ChuaThanhCong'
	BEGIN
		IF (select COUNT(*) From DonDatHang Where MaDonDatHang=@MaDonDatHang AND Deleted=N'False' AND TrangThaiDonDatHang=N'Đang mở')>0
		BEGIN
			select @LoaiDon=LoaiDonDatHang From DonDatHang Where MaDonDatHang=@MaDonDatHang AND Deleted=N'False' AND TrangThaiDonDatHang=N'Đang mở'
			Set @Error='Yes'
		END
		ELSE
		BEGIN
			Set @Error=N'NO'
			Set @LoaiDon = N'NO'
		END
	END
	IF @HanhDong =N'DaHuy'
	BEGIN
		IF (select COUNT(*) From DonDatHang Where MaDonDatHang=@MaDonDatHang AND Deleted=N'False' AND  TrangThaiDonDatHang!=N'Đã hủy')>0
		BEGIN
			select @LoaiDon=LoaiDonDatHang From DonDatHang Where MaDonDatHang=@MaDonDatHang AND Deleted=N'False' AND TrangThaiDonDatHang!=N'Đã hủy'
			Set @Error='Yes'
		END
		ELSE
		BEGIN
			Set @Error=N'NO'
			Set @LoaiDon = N'NO'
		END
	END
	Select @Error AS N'ThongBao',@LoaiDon AS N'KetQua'
END
GO
----------------------------------------------------------------------------------------------
GO
--CREATE PROC sp_LayHangHoaTheoMaKhachHangTraLai
--	@MaKhachHangTraLai varchar(20),
--	@LoaiHoaDon varchar(20)
--AS
--BEGIN
--	    IF @LoaiHoaDon =N'BanBuon'
--		BEGIN
--			Select a.MaHangHoa,b.TenHangHoa,a.SoLuong,b.GiaBanBuon,a.PhanTramChietKhau,c.GiaTriThue
--			From ChiTietKhachHangTraLai a join HangHoa b on a.MaHangHoa=b.MaHangHoa join Thue c
--			on b.MaThueGiaTriGiaTang=c.MaThue
--			Where a.MaKhachHangTraLai=@MaKhachHangTraLai AND b.Deleted=N'False'
--		END
--		IF @LoaiHoaDon =N'BanLe'
--		BEGIN
--			Select a.MaHangHoa,b.TenHangHoa,a.SoLuong,b.GiaBanLe,a.PhanTramChietKhau,c.GiaTriThue
--			From ChiTietKhachHangTraLai a join HangHoa b on a.MaHangHoa=b.MaHangHoa join Thue c
--			on b.MaThueGiaTriGiaTang=c.MaThue
--			Where a.MaKhachHangTraLai=@MaKhachHangTraLai AND b.Deleted=N'False'
--		END
--END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayHangHoaTheoMaKhachHangTraLai') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayHangHoaTheoMaKhachHangTraLai
go
Create PROC sp_LayHangHoaTheoMaKhachHangTraLai
	@MaKhachHangTraLai varchar(20),
	@MaKhachHang varchar(20),
	@MaHDBanHang varchar(20)
AS
BEGIN
	Declare @loai bit
	Select @loai=LoaiHoaDon From HDBanHang Where MaHDBanHang=@MaHDBanHang
	IF @loai=N'False'
	BEGIN
		Select b.MaHangHoa,b.TenHangHoa,b.SoLuong,b.DonGia,b.PhanTramChietKhau,b.Thue
		From KhachHangTraLai a join ChiTietKhachHangTraLai b 
		on a.MaKhachHangTraLai=b.MaKhachHangTraLai 
		Where a.MaKhachHangTraLai=@MaKhachHangTraLai AND a.MaKhachHang=@MaKhachHang AND a.MaHoaDonMuaHang=@MaHDBanHang 
	END
	else IF @loai=N'True'
	BEGIN
		--Select a.MaHangHoa,b.TenHangHoa,a.SoLuong,b.GiaBanLe,a.PhanTramChietKhau,c.GiaTriThue
		--	From ChiTietKhachHangTraLai a join HangHoa b on a.MaHangHoa=b.MaHangHoa join Thue c
		--	on b.MaThueGiaTriGiaTang=c.MaThue
		--	Where a.MaKhachHangTraLai=@MaKhachHangTraLai AND b.Deleted=N'False'
		Select b.MaHangHoa,b.TenHangHoa,b.SoLuong,b.DonGia,b.PhanTramChietKhau,b.Thue
		From KhachHangTraLai a join ChiTietKhachHangTraLai b 
		on a.MaKhachHangTraLai=b.MaKhachHangTraLai
		Where a.MaKhachHangTraLai=@MaKhachHangTraLai AND a.MaHoaDonMuaHang=@MaHDBanHang 
	END
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayHangHoaTheoMaTraLaiNhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayHangHoaTheoMaTraLaiNhaCungCap
go
CREATE PROC sp_LayHangHoaTheoMaTraLaiNhaCungCap
	@MaTraLaiNhaCungCap varchar(20)
AS
BEGIN
	Select a.MaHangHoa,b.TenHangHoa,a.SoLuong,a.DonGia,a.PhanTramChietKhau,a.Thue
	From ChiTietTraLaiNCC a join HangHoa b on a.MaHangHoa=b.MaHangHoa join Thue c
	on b.MaThueGiaTriGiaTang=c.MaThue
	Where a.MaHDTraLaiNCC=@MaTraLaiNhaCungCap AND b.Deleted=N'False'
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_BindingKhachHangTralaiHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_BindingKhachHangTralaiHang
go
CREATE PROCEDURE sp_BindingKhachHangTralaiHang
	@LoaiHoaDon varchar(20)
as
begin
 IF @LoaiHoaDon=N'BanBuon'
 BEGIN
  SELECT  distinct(a.MaKhachHang),b.Ten ,b.DiaChi,b.DuNo
  FROM HDBanHang a join KhachHang b on a.MaKhachHang=b.MaKH
  Where a.Deleted = N'False' AND a.LoaiHoaDon=N'False'
 END
 IF @LoaiHoaDon=N'BanLe'
 BEGIN
  SELECT  distinct(a.MaKhachHang),b.Ten ,b.DiaChi,b.DuNo
  FROM HDBanHang a join KhachHang b on a.MaKhachHang=b.MaKH
  Where a.Deleted = N'False' AND a.LoaiHoaDon=N'True'
 END
end
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_ThongTinTraLaiNhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_ThongTinTraLaiNhaCungCap
go
CREATE PROC sp_ThongTinTraLaiNhaCungCap
	@MaHoaDonNhap varchar(20)
AS
BEGIN
	Select a.MaHoaDonNhap,c.MaHangHoa,c.TenHangHoa,b.DonGia,b.SoLuong,b.Thue
	From HoaDonNhap a join ChiTietHoaDonNhap b 
	on a.MaHoaDonNhap = b.MaHoaDonNhap join HangHoa c
	on b.MaHangHoa = c.MaHangHoa join Thue d on c.MaThueGiaTriGiaTang=d.MaThue
	WHERE a.Deleted=N'False' AND a.MaHoaDonNhap=@MaHoaDonNhap
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_ChiTietKhachHangTraLaiTheoDonBanHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_ChiTietKhachHangTraLaiTheoDonBanHang
go
Create PROC sp_ChiTietKhachHangTraLaiTheoDonBanHang
	@MaHDBanHang nvarchar(20),
	@LoaiHoaDon varchar(20)
AS
BEGIN
	IF @LoaiHoaDon='BanBuon'
	BEGIN
		Select a.MaHDBanHang,b.MaHangHoa,b.TenHangHoa,b.DonGia,b.SoLuong,b.Thue
		From HDBanHang a join ChiTietHDBanHang b 
		on a.MaHDBanHang = b.MaHDBanHang 
		WHERE a.Deleted=N'False' and a.LoaiHoaDon=N'False' and a.MaHDBanHang=@MaHDBanHang
	END
	IF @LoaiHoaDon='BanLe'
	BEGIN
		Select a.MaHDBanHang,b.MaHangHoa,b.TenHangHoa,b.DonGia,b.SoLuong,b.Thue
		From HDBanHang a join ChiTietHDBanHang b 
		on a.MaHDBanHang = b.MaHDBanHang 
		WHERE a.Deleted=N'False' and a.LoaiHoaDon=N'True' and a.MaHDBanHang=@MaHDBanHang
	END
END
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_KiemKeHangHoa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_KiemKeHangHoa
go
CREATE PROCEDURE sp_KiemKeHangHoa
	@MaKho varchar(20)
as
begin
		SELECT distinct(b.MaHangHoa) ,c.TenHangHoa ,c.GiaNhap,c.MucTonToiThieu,b.SoLuong,c.GiaBanLe,d.GiaTriThue,c.GiaBanBuon
		FROM KhoHang a join ChiTietKhoHang b 
		on a.MaKho=b.MaKho join HangHoa c 
		on b.MaHangHoa=c.MaHangHoa  join Thue d 
		on c.MaThueGiaTriGiaTang=d.MaThue
		Where a.Deleted = N'False' AND a.MaKho=@MaKho
end
GO
-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_CapNhatNoNhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_CapNhatNoNhaCungCap
go
CREATE PROCEDURE sp_CapNhatNoNhaCungCap
	@MaNhaCungCap varchar(20),
	@DuNo float
as
begin
	Declare @sl float
	Select @sl=DuNo from NhaCungCap Where MaNhaCungCap=@MaNhaCungCap
	Update NhaCungCap
	Set DuNo=@sl+@DuNo  
	Where MaNhaCungCap=@MaNhaCungCap AND Deleted=N'False'
end
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_BaoCaoNhapHangTheoTungKhoTheoThoiGian') IS NOT NULL
 DROP PROCEDURE [dbo].sp_BaoCaoNhapHangTheoTungKhoTheoThoiGian
go
CREATE PROC sp_BaoCaoNhapHangTheoTungKhoTheoThoiGian
	@TuNgay varchar(10),
	@DenNgay varchar(10)
AS
BEGIN 
	Select distinct(a.MaHoaDonNhap),a.NgayNhap,a.MaKho,b.MaHangHoa,c.TenHangHoa,c.GiaNhap,b.SoLuong,
		   b.PhanTramChietKhau,a.ChietKhau,a.ThueGTGT,a.TongTien,a.ThanhToanNgay,d.GiaTriThue
	From HoaDonNhap a join ChiTietHoaDonNhap b 
	on a.MaHoaDonNhap=b.MaHoaDonNhap join HangHoa c
	on b.MaHangHoa=c.MaHangHoa join Thue d on c.MaThueGiaTriGiaTang=d.MaThue
	WHERE MONTH(a.NgayNhap) = @TuNgay AND YEAR(a.NgayNhap)=@DenNgay AND a.Deleted='False'
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_TimHangHoaTheoMaNhomHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_TimHangHoaTheoMaNhomHang
go
CREATE PROC sp_TimHangHoaTheoMaNhomHang
	@MaNhomHangHoa nvarchar(20)
AS
BEGIN
	Select MaNhomHangHoa,MaHangHoa,TenHangHoa,GiaNhap,GiaBanBuon,GiaBanLe 
	From HangHoa Where MaNhomHangHoa=@MaNhomHangHoa AND Deleted=N'False'
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_BaoCaoTraLaiNhaCungcapTheoKy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_BaoCaoTraLaiNhaCungcapTheoKy
go
CREATE PROC sp_BaoCaoTraLaiNhaCungcapTheoKy
	@TuNgay varchar(10),
	@DenNgay varchar(10)
AS
BEGIN
	Select distinct(a.MaHDTraLaiNCC),a.Ngaytra,a.MaKho,b.MaHangHoa,c.TenHangHoa,c.GiaNhap,b.SoLuong,
		   b.PhanTramChietKhau,a.TienBoiThuong,a.ThueGTGT,a.ThanhToanNgay,d.GiaTriThue
	From TraLaiNCC a join ChiTietTraLaiNCC b 
	on a.MaHDTraLaiNCC = b.MaHDTraLaiNCC join HangHoa c 
	on b.MaHangHoa=c.MaHangHoa join Thue d on c.MaThueGiaTriGiaTang=d.MaThue
	WHERE MONTH(a.Ngaytra) = @TuNgay AND YEAR(a.Ngaytra)=@DenNgay AND a.Deleted='False'
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_BaoCaoKhachHangTraLaiTheoKy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_BaoCaoKhachHangTraLaiTheoKy
go
CREATE PROC sp_BaoCaoKhachHangTraLaiTheoKy
	@TuNgay varchar(10),
	@DenNgay varchar(10)
AS
BEGIN
	Select distinct(a.MaKhachHangTraLai),a.NgayNhap,a.MaKhachHang,a.MaHoaDonMuaHang,a.MaKho,
			b.MaHangHoa,c.TenHangHoa,c.GiaBanBuon,c.GiaBanLe,b.SoLuong,
		   b.PhanTramChietKhau,a.TienBoiThuong,a.ThueGTGT,a.ThanhToanNgay,d.GiaTriThue
	From KhachHangTraLai a join ChiTietKhachHangTraLai b 
	on a.MaKhachHangTraLai = b.MaKhachHangTraLai join HangHoa c 
	on b.MaHangHoa=c.MaHangHoa join Thue d on c.MaThueGiaTriGiaTang=d.MaThue
	WHERE MONTH(a.NgayNhap) = @TuNgay AND YEAR(a.NgayNhap)=@DenNgay AND a.Deleted='False'
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_BaoCaoBanBuonBanLeTheoKy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_BaoCaoBanBuonBanLeTheoKy
go
CREATE PROC sp_BaoCaoBanBuonBanLeTheoKy
	@TuNgay varchar(10),
	@DenNgay varchar(10),
	@Loai varchar(20)
AS
BEGIN
	IF @Loai=N'BanBuon'
	BEGIN
		Select distinct(a.MaHDBanHang),a.NgayBan,a.MaKho,b.MaHangHoa,c.TenHangHoa,c.GiaBanBuon,b.SoLuong,
			   b.PhanTramChietKhau,a.ChietKhau,a.ThueGTGT,a.ThanhToanNgay,a.TongTienThanhToan,d.GiaTriThue
		From HDBanHang a join ChiTietHDBanHang b 
		on a.MaHDBanHang = b.MaHDBanHang join HangHoa c 
		on b.MaHangHoa=c.MaHangHoa join Thue d on c.MaThueGiaTriGiaTang=d.MaThue
		WHERE MONTH(a.NgayBan) = @TuNgay AND YEAR(a.NgayBan)=@DenNgay AND a.Deleted=N'False' AND a.LoaiHoaDon=N'False'
	END
	IF @Loai=N'BanLe'
	BEGIN
		Select distinct(a.MaHDBanHang),a.NgayBan,a.MaKho,b.MaHangHoa,c.TenHangHoa,c.GiaBanLe,b.SoLuong,
		   b.PhanTramChietKhau,a.ChietKhau,a.ThueGTGT,a.ThanhToanNgay,a.TongTienThanhToan,d.GiaTriThue
		From HDBanHang a join ChiTietHDBanHang b 
		on a.MaHDBanHang = b.MaHDBanHang join HangHoa c 
		on b.MaHangHoa=c.MaHangHoa join Thue d on c.MaThueGiaTriGiaTang=d.MaThue
		WHERE MONTH(a.NgayBan) = @TuNgay AND YEAR(a.NgayBan)=@DenNgay AND a.Deleted=N'False' AND a.LoaiHoaDon=N'True'
	END
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LaySoLuongKhachHangTraLaiTheoHoaDonBanHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LaySoLuongKhachHangTraLaiTheoHoaDonBanHang
go
CREATE PROC sp_LaySoLuongKhachHangTraLaiTheoHoaDonBanHang
	@MaHoaDonMuaHang nvarchar(20)
AS
BEGIN
		Select b.MaHangHoa,b.SoLuong
		From KhachHangTraLai a join ChiTietKhachHangTraLai b 
		on a.MaKhachHangTraLai = b.MaKhachHangTraLai
		WHERE a.Deleted=N'False' AND a.MaHoaDonMuaHang=@MaHoaDonMuaHang
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LaySoLuongDaMuaTheoHoaDonBanHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LaySoLuongDaMuaTheoHoaDonBanHang
go
CREATE PROC sp_LaySoLuongDaMuaTheoHoaDonBanHang
	@MaHDBanHang nvarchar(20)
AS
BEGIN
		Select b.MaHangHoa,b.SoLuong
		From HDBanHang a join ChiTietHDBanHang b 
		on a.MaHDBanHang = b.MaHDBanHang
		WHERE a.Deleted=N'False' AND a.MaHDBanHang=@MaHDBanHang
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LaySoLuongTraLaiNhaCungCapTheoHoaDonNhapHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LaySoLuongTraLaiNhaCungCapTheoHoaDonNhapHang
go
CREATE PROC sp_LaySoLuongTraLaiNhaCungCapTheoHoaDonNhapHang
	@MaHoaDonNhap varchar(20)
AS
BEGIN
		Select b.MaHangHoa,b.SoLuong
		From TraLaiNCC a join ChiTietTraLaiNCC b 
		on a.MaHDTraLaiNCC = b.MaHDTraLaiNCC
		WHERE a.Deleted=N'False' AND a.MaHoaDonNhap=@MaHoaDonNhap
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LaySoLuongDaNhapTheoHoaDonNhap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LaySoLuongDaNhapTheoHoaDonNhap
go
CREATE PROC sp_LaySoLuongDaNhapTheoHoaDonNhap
	@MaHoaDonNhap varchar(20)
AS
BEGIN
		Select b.MaHangHoa,b.SoLuong
		From HoaDonNhap a join ChiTietHoaDonNhap b 
		on a.MaHoaDonNhap = b.MaHoaDonNhap
		WHERE a.Deleted=N'False' AND a.MaHoaDonNhap=@MaHoaDonNhap
END

GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_CapNhatDuNoKhachHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_CapNhatDuNoKhachHang
go
CREATE PROC sp_CapNhatDuNoKhachHang
	@MaKhachHang varchar(20),
	@DuNo float
AS
BEGIN
	Update KhachHang
	Set DuNo= DuNo + @DuNo
	WHERE Deleted=N'False' AND MaKH=@MaKhachHang
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_CapNhatDuNoNhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_CapNhatDuNoNhaCungCap
go
CREATE PROC sp_CapNhatDuNoNhaCungCap
	@MaNhaCungCap varchar(20),
	@DuNo float
AS
BEGIN
	Update NhaCungCap
	Set DuNo=DuNo+@DuNo
	WHERE Deleted=N'False' AND MaNhaCungCap=@MaNhaCungCap
END
GO
----------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LaySoDuKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LaySoDuKho
go
CREATE PROC sp_LaySoDuKho
	@TuNgay varchar(10),
	@DenNgay varchar(10)
AS
BEGIN
		Select MaSoDuKho,MaHangHoa,SoDuDauKy,SoDuCuoiKy,NgayKetChuyen
		From SoDuKho
		WHERE MONTH(NgayKetChuyen) = @TuNgay AND YEAR(NgayKetChuyen)=@DenNgay
END
GO
GO
IF OBJECT_ID(N'[dbo].sp_DeleteSoDuKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_DeleteSoDuKho
go
Create proc sp_DeleteSoDuKho
@MaSoDuKho varchar(20)
as
Delete SoDuKho where MaSoDuKho=@MaSoDuKho

-----------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_LayBang_HangHoaTheoMaKhoHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LayBang_HangHoaTheoMaKhoHang
go
CREATE PROCEDURE sp_LayBang_HangHoaTheoMaKhoHang
	@MaKho varchar(50)
as
begin
		SELECT c.MaHangHoa ,a.TenHangHoa ,a.GiaNhap,c.SoLuong,a.GiaBanBuon,a.GiaBanLe,b.GiaTriThue
		FROM HangHoa a join Thue b
		on a.MaThueGiaTriGiaTang=b.MaThue join ChiTietKhoHang c
		on a.MaHangHoa=c.MaHangHoa
		Where a.Deleted = N'False' AND c.MaKho=@MaKho 
end
GO


--======================================== 3 ===========================================================
use SupermarketManagementDHT

go
--							Đăng Nhập
IF OBJECT_ID(N'[dbo].sp_LogIn') IS NOT NULL
 DROP PROCEDURE [dbo].sp_LogIn
go
create proc sp_LogIn
@TK nvarchar(200),
@MK nvarchar(200)
as
select * from dbo.TaiKhoan join dbo.NhanVien on dbo.TaiKhoan.NhanVienID=dbo.NhanVien.MaNhanVien
where dbo.TaiKhoan.KhoaTaiKhoan=0 and dbo.TaiKhoan.TenDangNhap=@TK and dbo.TaiKhoan.MatKhauDangNhap=@MK 

go
--							Lấy tất cả tài khoản
IF OBJECT_ID(N'[dbo].sp_selectTaiKhoan') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectTaiKhoan
go
create proc sp_selectTaiKhoan 
as
select * from dbo.TaiKhoan join dbo.NhanVien on dbo.TaiKhoan.NhanVienID=dbo.NhanVien.MaNhanVien
go
--							Lấy Tất cả nhóm Quyền
IF OBJECT_ID(N'[dbo].sp_selectNhomQuyen') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectNhomQuyen
go
create proc sp_selectNhomQuyen
as
select * from dbo.NhomQuyen
go
--							Lấy Chi Tiết Quyền
IF OBJECT_ID(N'[dbo].sp_selectChiTietQuyen') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectChiTietQuyen
go
create proc sp_selectChiTietQuyen
@TenNhomQuyen nvarchar(50)
as
select * from dbo.ChiTietQuyen join dbo.Quyen on dbo.ChiTietQuyen.TenForm=dbo.Quyen.TenForm where TenNhomQuyen=@TenNhomQuyen
go
--							Sửa Chi Tiết Quyền
IF OBJECT_ID(N'[dbo].sp_updateChiTietQuyen') IS NOT NULL
 DROP PROCEDURE [dbo].sp_updateChiTietQuyen
go
create proc sp_updateChiTietQuyen
@TenNhomQuyen nvarchar(50),
@TenForm nvarchar(50),
@QuyenThem BIT ,
@QuyenSua BIT ,
@QuyenXoa BIT ,
@QuyenXem BIT ,
@SaoLuuDuLieu BIT ,
@CapNhatDuLieu BIT 
as
update dbo.ChiTietQuyen set
QuyenThem=@QuyenThem,
QuyenSua=@QuyenSua,
QuyenXoa=@QuyenXoa,
QuyenXem=@QuyenXem,
SaoLuuDuLieu=@SaoLuuDuLieu,
CapNhatDuLieu=@CapNhatDuLieu
where TenNhomQuyen=@TenNhomQuyen and TenForm=@TenForm
GO
--								Thêm Nhóm Quyền
IF OBJECT_ID(N'[dbo].sp_insertNhomQuyen') IS NOT NULL
 DROP PROCEDURE [dbo].sp_insertNhomQuyen
go
create proc sp_insertNhomQuyen
@TenNhomQuyen nvarchar(50)
as
insert into dbo.NhomQuyen values(@TenNhomQuyen,1)
declare @sodem int
set @sodem= (select top(1)QuyenID from Quyen order by QuyenID desc)
while(@sodem>0)
begin
	declare @TenForm nvarchar(50)
	if(exists(select QuyenID from Quyen where QuyenID=@sodem))
	begin
		set @TenForm=(select TenForm from Quyen where QuyenID=@sodem)
		insert into dbo.ChiTietQuyen values(@TenNhomQuyen,@TenForm,0,0,0,0,0,0)
	end
	set @sodem=@sodem-1
end

go
--exec sp_insertNhomQuyen 'test'
go
--									Thêm Tài Khoản
IF OBJECT_ID(N'[dbo].sp_insertTaiKhoan') IS NOT NULL
 DROP PROCEDURE [dbo].sp_insertTaiKhoan
go
create proc sp_insertTaiKhoan
@TenDangNhap nVARCHAR(200) ,
@MatKhauDangNhap nVARCHAR(200),
@KhoaTaiKhoan BIT,
@NhanVienID nVARCHAR(20),
@Administrator bit,
@TenNhomQuyen nvarchar(50)
as 
insert into dbo.TaiKhoan values(@TenDangNhap,@MatKhauDangNhap,@KhoaTaiKhoan,@NhanVienID,@Administrator,@TenNhomQuyen)
go
--									Sửa Tài Khoản
IF OBJECT_ID(N'[dbo].sp_updateTaiKhoan') IS NOT NULL
 DROP PROCEDURE [dbo].sp_updateTaiKhoan
go
create proc sp_updateTaiKhoan
@TenDangNhap nVARCHAR(200) ,
@MatKhauDangNhap nVARCHAR(200),
@KhoaTaiKhoan BIT,
@NhanVienID nVARCHAR(20),
@Administrator bit,
@TenNhomQuyen nvarchar(50)
as 
update dbo.TaiKhoan set
MatKhauDangNhap=@MatKhauDangNhap,
KhoaTaiKhoan=@KhoaTaiKhoan,
NhanVienID=@NhanVienID,
Administrator=@Administrator,
TenNhomQuyen=@TenNhomQuyen
where TenDangNhap=@TenDangNhap
go
--							Xóa Tài Khoản
IF OBJECT_ID(N'[dbo].sp_deleteTaiKhoan') IS NOT NULL
 DROP PROCEDURE [dbo].sp_deleteTaiKhoan
go
create proc sp_deleteTaiKhoan
@TenDangNhap nvarchar(200)
as
delete from dbo.TaiKhoan where TenDangNhap=@TenDangNhap
go
--							Xóa Nhóm Quyền
IF OBJECT_ID(N'[dbo].sp_deleteNhomQuyen') IS NOT NULL
 DROP PROCEDURE [dbo].sp_deleteNhomQuyen
go
create proc sp_deleteNhomQuyen
@TenNhomQuyen nvarchar(50)
as
delete from dbo.ChiTietQuyen where TenNhomQuyen=@TenNhomQuyen
update dbo.TaiKhoan set
TenNhomQuyen='Temp'
where TenNhomQuyen=@TenNhomQuyen
delete from dbo.NhomQuyen where TenNhomQuyen=@TenNhomQuyen
go
--							select Báo báo doanh thu theo nhân viên
IF OBJECT_ID(N'[dbo].sp_selectDoanhThuTheoNhanVien') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectDoanhThuTheoNhanVien
go 
create proc sp_selectDoanhThuTheoNhanVien
as
select * from dbo.HDBanHang join dbo.NhanVien on dbo.HDBanHang.MaNhanVien=dbo.NhanVien.MaNhanVien where dbo.NhanVien.Deleted=0 and dbo.HDBanHang.Deleted=0 
go
IF OBJECT_ID(N'[dbo].sp_selectDoanhThuTheoMaNhanVien') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectDoanhThuTheoMaNhanVien
go 
create proc sp_selectDoanhThuTheoMaNhanVien
@ID varchar(20),
@Truoc datetime,
@Sau datetime
as
select * from dbo.HDBanHang join dbo.NhanVien on dbo.HDBanHang.MaNhanVien=dbo.NhanVien.MaNhanVien where dbo.NhanVien.Deleted=0 and dbo.HDBanHang.Deleted=0 
and dbo.NhanVien.MaNhanVien=@ID and NgayBan between @Truoc and @Sau
go
--							select Báo Cáo Doanh Thu Theo Mặt Hàng
IF OBJECT_ID(N'[dbo].sp_selectDoanhThuTheoMatHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectDoanhThuTheoMatHang
go 
create proc sp_selectDoanhThuTheoMatHang
as
select * from dbo.HangHoa join dbo.ChiTietHDBanHang on dbo.HangHoa.MaHangHoa=dbo.ChiTietHDBanHang.MaHangHoa join dbo.HDBanHang on dbo.ChiTietHDBanHang.MaHDBanHang = dbo.HDBanHang.MaHDBanHang
where dbo.HangHoa.Deleted=0 and dbo.ChiTietHDBanHang.Deleted=0 and dbo.HDBanHang.Deleted=0
go
IF OBJECT_ID(N'[dbo].sp_selectDoanhThuTheoMaMatHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectDoanhThuTheoMaMatHang
go 
create proc sp_selectDoanhThuTheoMaMatHang
@ID varchar(20),
@Truoc datetime,
@Sau datetime
as
select * from dbo.HangHoa join dbo.ChiTietHDBanHang on dbo.HangHoa.MaHangHoa=dbo.ChiTietHDBanHang.MaHangHoa 
							join dbo.HDBanHang on dbo.ChiTietHDBanHang.MaHDBanHang = dbo.HDBanHang.MaHDBanHang
where dbo.HangHoa.Deleted=0 and dbo.ChiTietHDBanHang.Deleted=0 and dbo.HDBanHang.Deleted=0
and dbo.HangHoa.MaHangHoa=@ID and NgayBan between @Truoc and @Sau 
go
--								select Báo Cáo Theo Nhóm Hàng
IF OBJECT_ID(N'[dbo].sp_selectDoanhThuTheoNhomHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectDoanhThuTheoNhomHang
go
create proc sp_selectDoanhThuTheoNhomHang
as
select * from dbo.NhomHang join dbo.HangHoa on dbo.NhomHang.MaNhomHang=dbo.HangHoa.MaNhomHangHoa join dbo.ChiTietHDBanHang on dbo.HangHoa.MaHangHoa=dbo.ChiTietHDBanHang.MaHangHoa join dbo.HDBanHang on dbo.ChiTietHDBanHang.MaHDBanHang=dbo.HDBanHang.MaHDBanHang
where dbo.NhomHang.Deleted=0 and dbo.HangHoa.Deleted=0 and dbo.ChiTietHDBanHang.Deleted=0
go
IF OBJECT_ID(N'[dbo].sp_selectDoanhThuTheoMaNhomHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectDoanhThuTheoMaNhomHang
go
create proc sp_selectDoanhThuTheoMaNhomHang
@ID varchar(20),
@Truoc datetime,
@Sau datetime
as
select * from dbo.NhomHang join dbo.HangHoa on dbo.NhomHang.MaNhomHang=dbo.HangHoa.MaNhomHangHoa join dbo.ChiTietHDBanHang on dbo.HangHoa.MaHangHoa=dbo.ChiTietHDBanHang.MaHangHoa join dbo.HDBanHang on dbo.ChiTietHDBanHang.MaHDBanHang=dbo.HDBanHang.MaHDBanHang
where dbo.NhomHang.Deleted=0 
	and dbo.HangHoa.Deleted=0 
	and dbo.ChiTietHDBanHang.Deleted=0
	and dbo.NhomHang.MaNhomHang=@ID 
	and NgayBan between @Truoc and @Sau
	
go
--								select Báo Cáo Phiếu Thu
IF OBJECT_ID(N'[dbo].sp_selectPhieuThuTheoMa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectPhieuThuTheoMa
go
create proc sp_selectPhieuThuTheoMa
@ID int
as
select * from PhieuThu where @ID=PhieuThu.PhieuThuID
go

--============================================= 4 MRK START ===================================================
go
use SuperMarketManagementDHT
go
--kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk
go
IF OBJECT_ID(N'[dbo].[sp_CongSoLuong_CHITIETKHOHANG_k29]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_CongSoLuong_CHITIETKHOHANG_k29]
go
CREATE proc sp_CongSoLuong_CHITIETKHOHANG_k29 
	@MaKho varchar(20), 
	@MaHangHoa varchar(50), 
	@SoLuong int
AS
BEGIN
	UPDATE ChiTietKhoHang
	SET [SoLuong] = SoLuong + @SoLuong
	WHERE ([MaHangHoa] = @MaHangHoa) and ([MaKho] = @MaKho)
END
go
--kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk
go
IF OBJECT_ID(N'[dbo].[sp_UpdateDuNo_K29]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_UpdateDuNo_K29]
go
CREATE proc sp_UpdateDuNo_K29 
	@ThaoTac nvarchar(299),
	@MaNhaCungCap varchar(20),
	@MaKH varchar(50), 
	@SoLuong float
AS
BEGIN
	IF (@ThaoTac = 'NCC_CONG')
	BEGIN
		UPDATE [SupermarketManagementDHT].[dbo].[NhaCungCap]
		SET [DuNo] = [DuNo] + @SoLuong
		WHERE ([MaNhaCungCap] = @MaNhaCungCap)
	END
	ELSE IF (@ThaoTac = 'NCC_TRU')
	BEGIN
		UPDATE [SupermarketManagementDHT].[dbo].[NhaCungCap]
		SET [DuNo] = [DuNo] - @SoLuong
		WHERE ([MaNhaCungCap] = @MaNhaCungCap)
	END
	ELSE IF (@ThaoTac = 'KH_CONG')
	BEGIN
		UPDATE [SupermarketManagementDHT].[dbo].[KhachHang]
		SET [DuNo] = [DuNo] + @SoLuong
		WHERE ([MaKH] = @MaKH)
	END
	ELSE IF (@ThaoTac = 'KH_TRU')
	BEGIN
		UPDATE [SupermarketManagementDHT].[dbo].[KhachHang]
		SET [DuNo] = [DuNo] - @SoLuong
		WHERE ([MaKH] = @MaKH)
	END
END
go
--kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk
go
IF OBJECT_ID(N'[dbo].[sp_CongSoLuong]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_CongSoLuong]
go
CREATE proc sp_CongSoLuong
	@MaKho varchar(20), 
	@MaHangHoa varchar(50), 
	@SoLuong int
AS
BEGIN
	UPDATE ChiTietKhoHang
	SET [SoLuong] = SoLuong + @SoLuong
	WHERE ([MaHangHoa] = @MaHangHoa) and ([MaKho] = @MaKho)
END
go
--kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk
go
IF OBJECT_ID(N'[dbo].[sp_LayBang_ThongTinMaVachTheVip]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_LayBang_ThongTinMaVachTheVip]
go
CREATE proc sp_LayBang_ThongTinMaVachTheVip
AS
BEGIN
	SELECT	TheVip.MaThe, KhachHang.Ten, TheVip.GiaTriThe, TheVip.GiaTriConLai, TheVip.GhiChu, TheVip.MaKhachHang
	FROM	KhachHang INNER JOIN TheVip ON KhachHang.MaKH = TheVip.MaKhachHang
	WHERE	(KhachHang.Deleted = 0) AND (TheVip.Deleted = 0)
END
go
--kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk
go
IF OBJECT_ID(N'[dbo].[sp_LayBang_ThongTinMaVachTheGiaTri]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_LayBang_ThongTinMaVachTheGiaTri]
go
CREATE proc sp_LayBang_ThongTinMaVachTheGiaTri
AS
BEGIN
	SELECT	TheGiamGia.MaTheGiamGia, KhachHang.Ten, TheGiamGia.GiaTriThe, TheGiamGia.GiaTriConLai, TheGiamGia.MaKhachHang
	FROM	KhachHang INNER JOIN TheGiamGia ON KhachHang.MaKH = TheGiamGia.MaKhachHang
	WHERE	(KhachHang.Deleted = 0) AND (TheGiamGia.Deleted = 0)
END
go
--kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk
go
IF OBJECT_ID(N'[dbo].[sp_KhachHang_MRK]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_KhachHang_MRK]
go
CREATE proc sp_KhachHang_MRK
	@ThaoTac nvarchar(299),
	--Set
	@MaKH nvarchar(20),
    @Ten nvarchar(200),
    @DiaChi nvarchar(200),
    @DienThoai nvarchar(20),
    @Fax nvarchar(20),
    @Email nvarchar(50),
    @MST nvarchar(20),
    @DuNo float,
    @HanMucTT float,
    @CongTy nvarchar(200),
    @NgaySinh datetime,
    @MaVung int,
    @Mobi nvarchar(100),
    @NgayThamGia datetime,
    @GiaoDichCuoi datetime,
    @NgungTheoDoi bit,
    @Website varchar(200),
    @NgaySua datetime,
    @GhiChu nvarchar(200),
    @Deleted bit,
	--Filter
	@MaKHk nvarchar(20),
    @Tenk nvarchar(200),
    @DiaChik nvarchar(200),
    @DienThoaik nvarchar(20),
    @Faxk nvarchar(20),
    @Emailk nvarchar(50),
    @MSTk nvarchar(20),
    @DuNok float,
    @HanMucTTk float,
    @CongTyk nvarchar(200),
    @NgaySinhk datetime,
    @MaVungk int,
    @Mobik nvarchar(100),
    @NgayThamGiak datetime,
    @GiaoDichCuoik datetime,
    @NgungTheoDoik bit,
    @Websitek varchar(200),
    @NgaySuak datetime,
    @GhiChuk nvarchar(200),
    @Deletedk bit
AS
BEGIN
	IF (@ThaoTac = 'Select_ALL_KHACHHANG')
	BEGIN
		SELECT 	[MaKH]
				,[Ten]
				,[DiaChi]
				,[DienThoai]
				,[Fax]
				,[Email]
				,[MST]
				,[DuNo]
				,[HanMucTT]
				,[CongTy]
				,[NgaySinh]
				,[MaVung]
				,[Mobi]
				,[NgayThamGia]
				,[GiaoDichCuoi]
				,[NgungTheoDoi]
				,[Website]
				,[NgaySua]
				,[GhiChu]
				,[Deleted]
		FROM [SupermarketManagementDHT].[dbo].[KhachHang] 
	END
	ELSE IF (@ThaoTac = 'Insert_KHACHHANG')
	BEGIN
		INSERT INTO [SupermarketManagementDHT].[dbo].[KhachHang]
			([MaKH]
           ,[Ten]
           ,[DiaChi]
           ,[DienThoai]
           ,[Fax]
           ,[Email]
           ,[MST]
           ,[DuNo]
           ,[HanMucTT]
           ,[CongTy]
           ,[NgaySinh]
           ,[MaVung]
           ,[Mobi]
           ,[NgayThamGia]
           ,[GiaoDichCuoi]
           ,[NgungTheoDoi]
           ,[Website]
           ,[NgaySua]
           ,[GhiChu]
           ,[Deleted])
		VALUES
           (@MaKH
           ,@Ten
           ,@DiaChi
           ,@DienThoai
           ,@Fax
           ,@Email
           ,@MST
           ,@DuNo
           ,@HanMucTT
           ,@CongTy
           ,@NgaySinh
           ,@MaVung
           ,@Mobi
           ,@NgayThamGia
           ,@GiaoDichCuoi
           ,@NgungTheoDoi
           ,@Website
           ,@NgaySua
           ,@GhiChu
           ,@Deleted)
	END
	ELSE IF (@ThaoTac = 'Update_TheoMaKH_KHACHHANG')
	BEGIN
		UPDATE [SupermarketManagementDHT].[dbo].[KhachHang]
		SET [MaKH] = @MaKH
			,[Ten] = @Ten
			,[DiaChi] = @DiaChi
			,[DienThoai] = @DienThoai
			,[Fax] = @Fax
			,[Email] = @Email
			,[MST] = @MST
			,[DuNo] = @DuNo
			,[HanMucTT] = @HanMucTT
			,[CongTy] = @CongTy
			,[NgaySinh] = @NgaySinh
			,[MaVung] = @MaVung
			,[Mobi] = @Mobi
			,[NgayThamGia] = @NgayThamGia
			,[GiaoDichCuoi] = @GiaoDichCuoi
			,[NgungTheoDoi] = @NgungTheoDoi
			,[Website] = @Website
			,[NgaySua] = @NgaySua
			,[GhiChu] = @GhiChu
			,[Deleted] = @Deleted
		WHERE ([MaKH] = @MaKHk)
	END
	ELSE IF (@ThaoTac = 'Delete_TheoMaKH_KHACHHANG')
	BEGIN
		DELETE FROM [SupermarketManagementDHT].[dbo].[KhachHang]
		WHERE ([MaKH] = @MaKHk)
	END
END
go
--kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk
go
IF OBJECT_ID(N'[dbo].[sp_TyLeTinh]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_TyLeTinh]
go
CREATE proc sp_TyLeTinh
	@ThaoTac nvarchar(299),
	--set
	@MaTyLeTinh VARCHAR(50),
	@SoTien FLOAT,
	@NgayNhap Datetime,
	@GhiChu NVARCHAR(200),
	@Deleted bit
AS
BEGIN
	IF (@ThaoTac = 'select')
	BEGIN
		SELECT 	*
		FROM [SupermarketManagementDHT].[dbo].[TyLeTinh]
		WHERE [Deleted] = 0
	END
	ELSE IF (@ThaoTac = 'insert')
	BEGIN
		INSERT INTO [SupermarketManagementDHT].[dbo].[TyLeTinh]
			([MaTyLeTinh]
           ,[SoTien]
		   ,[NgayNhap]
           ,[GhiChu]
           ,[Deleted])
		VALUES
           (@MaTyLeTinh
           ,@SoTien
           ,@NgayNhap
		   ,@GhiChu
           ,@Deleted)
	END
END
go
--kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk
go
IF OBJECT_ID(N'[dbo].[sp_DiemThuongKhachHang]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_DiemThuongKhachHang]
go
CREATE proc sp_DiemThuongKhachHang
	@ThaoTac nvarchar(299),
	--set
	@MaDiemThuongKhachHang varchar(50),
	@MaKhachHang	varchar(50),
	@TenKhachHang	nvarchar(200),
	@TongDiem	int,
	@DiemDaDung	int,
	@DiemConLai int,
	@GhiChu	nvarchar(200),
	@Deleted	bit
AS
BEGIN
	IF (@ThaoTac = 'select')
	BEGIN
		SELECT 	*
		FROM [SupermarketManagementDHT].[dbo].[DiemThuongKhachHang]
		WHERE [Deleted] = 0
	END
	ELSE IF (@ThaoTac = 'insert')
	BEGIN
		INSERT INTO [SupermarketManagementDHT].[dbo].[DiemThuongKhachHang]
			([MaDiemThuongKhachHang]
           ,[MaKhachHang]
		   ,[TenKhachHang]
           ,[TongDiem]
		   ,[DiemDaDung]
		   ,[DiemConLai]
           ,[GhiChu]
           ,[Deleted])
		VALUES
           (@MaDiemThuongKhachHang
           ,@MaKhachHang
           ,@TenKhachHang
		   ,@TongDiem
		   ,@DiemDaDung
           ,@DiemConLai
		   ,@GhiChu
           ,@Deleted)
	END
	ELSE IF (@ThaoTac = 'update')
	BEGIN
		UPDATE [SupermarketManagementDHT].[dbo].[DiemThuongKhachHang]
		SET [MaKhachHang] = @MaKhachHang
		   ,[TenKhachHang] = @TenKhachHang
           ,[TongDiem] = @TongDiem
		   ,[DiemDaDung] = @DiemDaDung
		   ,[DiemConLai] = @DiemConLai
           ,[GhiChu] = @GhiChu
           ,[Deleted] = @Deleted
		WHERE [MaDiemThuongKhachHang] = @MaDiemThuongKhachHang
	END
	ELSE IF (@ThaoTac = 'delete')
	BEGIN
		DELETE FROM [SupermarketManagementDHT].[dbo].[DiemThuongKhachHang]
		WHERE [MaDiemThuongKhachHang] = @MaDiemThuongKhachHang
	END
	ELSE IF (@ThaoTac = 'CapNhat')
	BEGIN
		IF (select COUNT(*) from DiemThuongKhachHang where MaKhachHang=@MaKhachHang AND Deleted=N'False')>0
		BEGIN
			--Đã có khách hàng trong bảng điểm thưởng khách hàng
			UPDATE [SupermarketManagementDHT].[dbo].[DiemThuongKhachHang]
			SET [TongDiem] = @TongDiem
				,[DiemDaDung] = @DiemDaDung
				,[DiemConLai] = @DiemConLai
			WHERE [MaKhachHang] = @MaKhachHang
		END
		ELSE
		BEGIN
			--Chưa có khách hàng trong bảng điểm thưởng khách hàng
			INSERT INTO [SupermarketManagementDHT].[dbo].[DiemThuongKhachHang]
				([MaDiemThuongKhachHang]
				,[MaKhachHang]
				,[TenKhachHang]
				,[TongDiem]
				,[DiemDaDung]
				,[DiemConLai]
				,[GhiChu]
				,[Deleted])
			VALUES
				(@MaDiemThuongKhachHang
				,@MaKhachHang
				,@TenKhachHang
				,@TongDiem
				,@DiemDaDung
				,@DiemConLai
				,@GhiChu
				,@Deleted)
		END
	END
END
go
--kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk
go
IF OBJECT_ID(N'[dbo].[sp_ChiTietTheGiamGia]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_ChiTietTheGiamGia]
go
CREATE proc sp_ChiTietTheGiamGia
	@ThaoTac nvarchar(299),
	--set
	@MaTheGiamGia varchar(50),
	@MaKhachHang	varchar(50),
	@TenKhachHang	nvarchar(200),
	@GiaTriThe float,
	@NgayThu datetime,
	@MaPhieuThu varchar(20),
	@Deleted bit
AS
BEGIN
	IF (@ThaoTac = 'select')
	BEGIN
		SELECT 	*
		FROM [SupermarketManagementDHT].[dbo].[ChiTietTheGiamGia]
		WHERE [Deleted] = 0
	END
	ELSE IF (@ThaoTac = 'insert')
	BEGIN
		INSERT INTO [SupermarketManagementDHT].[dbo].[ChiTietTheGiamGia]
			([MaTheGiamGia]
           ,[MaKhachHang]
		   ,[TenKhachHang]
           ,[GiaTriThe]
		   ,[NgayThu]
		   ,[MaPhieuThu]
           ,[Deleted])
		VALUES
           (@MaTheGiamGia
           ,@MaKhachHang
           ,@TenKhachHang
		   ,@GiaTriThe
		   ,@NgayThu
           ,@MaPhieuThu
           ,@Deleted)
	END
	ELSE IF (@ThaoTac = 'update')
	BEGIN
		UPDATE [SupermarketManagementDHT].[dbo].[ChiTietTheGiamGia]
		SET [MaKhachHang] = @MaKhachHang
		   ,[TenKhachHang] = @TenKhachHang
           ,[GiaTriThe] = @GiaTriThe
		   ,[NgayThu] = @NgayThu
		   ,[MaPhieuThu] = @MaPhieuThu
           ,[Deleted] = @Deleted
		WHERE [MaTheGiamGia] = @MaTheGiamGia
	END
	ELSE IF (@ThaoTac = 'delete')
	BEGIN
		DELETE FROM [SupermarketManagementDHT].[dbo].[ChiTietTheGiamGia]
		WHERE [MaTheGiamGia] = @MaTheGiamGia
	END
END
go
--kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk
go
IF OBJECT_ID(N'[dbo].[sp_HangHoaFIX]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_HangHoaFIX]
go
CREATE proc sp_HangHoaFIX
	@ThaoTac nvarchar(299),
	--set
	@MaHangHoa varchar(50),
	@MaNhomHangHoa nvarchar(20),
	@TenHangHoa nvarchar(20),
	@MaDonViTinh nvarchar(20),
	@GiaNhap float,
	@GiaBanBuon float,
	@GiaBanLe float,
	@MaThueGiaTriGiaTang nvarchar(20),
	@KieuHangHoa nvarchar(20),
	@SeriLo nvarchar(20),
	@MucDatHang nvarchar(20),
	@MucTonToiThieu nvarchar(20),
	@GhiChu nvarchar(250),
	@Deleted bit
AS
BEGIN
	IF (@ThaoTac = 'select')
	BEGIN
		SELECT HangHoaID,HangHoa.MaHangHoa,HangHoa.MaNhomHangHoa,NhomHang.TenNhomHang,HangHoa.TenHangHoa,HangHoa.MaDonViTinh,DVT.TenDonViTinh,HangHoa.GiaNhap,HangHoa.GiaBanBuon,HangHoa.GiaBanLe,HangHoa.MaThueGiaTriGiaTang,Thue.GiaTriThue,Thue.TenThue,HangHoa.KieuHangHoa,HangHoa.SeriLo,HangHoa.MucDatHang,HangHoa.MucTonToiThieu,HangHoa.GhiChu
		FROM HangHoa INNER JOIN DVT ON HangHoa.MaDonViTinh = DVT.MaDonViTinh 
					 INNER JOIN NhomHang ON HangHoa.MaNhomHangHoa = NhomHang.MaNhomHang
					 INNER JOIN Thue ON HangHoa.MaThueGiaTriGiaTang = Thue.MaThue
		WHERE HangHoa.Deleted = 0
	END
	ELSE IF (@ThaoTac = 'select_TheoMaHangHoa')
	BEGIN
		SELECT HangHoaID,HangHoa.MaHangHoa,HangHoa.MaNhomHangHoa,NhomHang.TenNhomHang,HangHoa.TenHangHoa,HangHoa.MaDonViTinh,DVT.TenDonViTinh,HangHoa.GiaNhap,HangHoa.GiaBanBuon,HangHoa.GiaBanLe,HangHoa.MaThueGiaTriGiaTang,Thue.GiaTriThue,Thue.TenThue,HangHoa.KieuHangHoa,HangHoa.SeriLo,HangHoa.MucDatHang,HangHoa.MucTonToiThieu,HangHoa.GhiChu
		FROM HangHoa INNER JOIN DVT ON HangHoa.MaDonViTinh = DVT.MaDonViTinh 
					 INNER JOIN NhomHang ON HangHoa.MaNhomHangHoa = NhomHang.MaNhomHang
					 INNER JOIN Thue ON HangHoa.MaThueGiaTriGiaTang = Thue.MaThue
		WHERE (HangHoa.Deleted = 0) AND (HangHoa.MaHangHoa = @MaHangHoa)
	END
	ELSE IF (@ThaoTac = 'select_TheoKho')
	BEGIN
		SELECT 	HangHoa.MaHangHoa,HangHoa.MaNhomHangHoa,NhomHang.TenNhomHang,HangHoa.TenHangHoa,HangHoa.MaDonViTinh,DVT.TenDonViTinh,HangHoa.GiaNhap,HangHoa.GiaBanBuon,HangHoa.GiaBanLe,HangHoa.MaThueGiaTriGiaTang,Thue.GiaTriThue,Thue.TenThue,HangHoa.KieuHangHoa,HangHoa.SeriLo,HangHoa.MucDatHang,HangHoa.MucTonToiThieu,HangHoa.GhiChu
		FROM HangHoa INNER JOIN ChiTietKhoHang ON HangHoa.MaHangHoa = ChiTietKhoHang.MaHangHoa 
					 INNER JOIN DVT ON HangHoa.MaDonViTinh = DVT.MaDonViTinh 
					 INNER JOIN NhomHang ON HangHoa.MaNhomHangHoa = NhomHang.MaNhomHang
					 INNER JOIN Thue ON HangHoa.MaThueGiaTriGiaTang = Thue.MaThue
		WHERE (HangHoa.Deleted = 0) AND (ChiTietKhoHang.MaKho = @GhiChu)
	END
	ELSE IF (@ThaoTac = 'insert')
	BEGIN
		INSERT INTO [SupermarketManagementDHT].[dbo].[HangHoa]
			([MaHangHoa]
           ,[MaNhomHangHoa]
		   ,[TenHangHoa]
           ,[MaDonViTinh]
		   ,[GiaNhap]
		   ,[GiaBanBuon]
		   ,[GiaBanLe]
		   ,[MaThueGiaTriGiaTang]
		   ,[KieuHangHoa]
		   ,[SeriLo]
		   ,[MucDatHang]
		   ,[MucTonToiThieu]
		   ,[GhiChu]
           ,[Deleted])
		VALUES
           (@MaHangHoa
           ,@MaNhomHangHoa
           ,@TenHangHoa
		   ,@MaDonViTinh
		   ,@GiaNhap
           ,@GiaBanBuon
		   ,@GiaBanLe
		   ,@MaThueGiaTriGiaTang
		   ,@KieuHangHoa
		   ,@SeriLo
		   ,@MucDatHang
		   ,@MucTonToiThieu
		   ,@GhiChu
           ,@Deleted)
	END
	ELSE IF (@ThaoTac = 'update')
	BEGIN
		UPDATE [SupermarketManagementDHT].[dbo].[HangHoa]
		SET [MaNhomHangHoa] = @MaNhomHangHoa
		   ,[TenHangHoa] = @TenHangHoa
           ,[MaDonViTinh] = @MaDonViTinh
		   ,[GiaNhap] = @GiaNhap
		   ,[GiaBanBuon] = @GiaBanBuon
           ,[GiaBanLe] = @GiaBanLe
		   ,[MaThueGiaTriGiaTang] = @MaThueGiaTriGiaTang
		   ,[KieuHangHoa] = @KieuHangHoa
		   ,[SeriLo] = @SeriLo
		   ,[MucDatHang] = @MucDatHang
		   ,[MucTonToiThieu] = @MucTonToiThieu
		   ,[GhiChu] = @GhiChu
		   ,[Deleted] = @Deleted
		WHERE [MaHangHoa] = @MaHangHoa
	END
	ELSE IF (@ThaoTac = 'delete')
	BEGIN
		DELETE FROM [SupermarketManagementDHT].[dbo].[HangHoa]
		WHERE [MaHangHoa] = @MaHangHoa
	END
END
go

--kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk
go
IF OBJECT_ID(N'[dbo].[sp_BCNhapHangTheoNhomHangFIX]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_BCNhapHangTheoNhomHangFIX]
go
CREATE proc sp_BCNhapHangTheoNhomHangFIX
	@ThaoTac nvarchar(299)
AS
BEGIN
	IF (@ThaoTac = 'HoaDonNhap')
	BEGIN
		SELECT MaHoaDonNhap,NgayNhap 
		FROM 	HoaDonNhap
		WHERE (Deleted = 0)
	END
	IF (@ThaoTac = 'ChiTietHoaDonNhap')
	BEGIN
		--SELECT ChiTietHoaDonNhap.MaHoaDonNhap,ChiTietHoaDonNhap.MaHangHoa,ChiTietHoaDonNhap.SoLuong
		--FROM 	ChiTietHoaDonNhap
		--WHERE (ChiTietHoaDonNhap.Deleted = 0)
		SELECT ChiTietHoaDonNhap.MaHoaDonNhap,ChiTietHoaDonNhap.MaHangHoa,ChiTietHoaDonNhap.SoLuong,HoaDonNhap.NgayNhap
		FROM	ChiTietHoaDonNhap INNER JOIN HoaDonNhap ON ChiTietHoaDonNhap.MaHoaDonNhap = HoaDonNhap.MaHoaDonNhap
		WHERE (ChiTietHoaDonNhap.Deleted = 0) and (HoaDonNhap.Deleted = 0)
	END
	ELSE IF (@ThaoTac = 'KhachHangTraLai')
	BEGIN
		SELECT MaKhachHangTraLai,NgayNhap 
		FROM 	KhachHangTraLai
		WHERE (Deleted = 0)
	END
	IF (@ThaoTac = '[ChiTietKhachHangTraLai]')
	BEGIN
		--SELECT ChiTietKhachHangTraLai.MaKhachHangTraLai,ChiTietKhachHangTraLai.MaHangHoa,ChiTietKhachHangTraLai.TenHangHoa,ChiTietKhachHangTraLai.SoLuong
		--FROM 	[ChiTietKhachHangTraLai]
		--WHERE ([ChiTietKhachHangTraLai].Deleted = 0)
		SELECT ChiTietKhachHangTraLai.MaKhachHangTraLai,ChiTietKhachHangTraLai.MaHangHoa,ChiTietKhachHangTraLai.TenHangHoa,ChiTietKhachHangTraLai.SoLuong,KhachHangTraLai.NgayNhap
		FROM 	ChiTietKhachHangTraLai INNER JOIN KhachHangTraLai ON ChiTietKhachHangTraLai.MaKhachHangTraLai = KhachHangTraLai.MaKhachHangTraLai
		WHERE (ChiTietKhachHangTraLai.Deleted = 0) and (KhachHangTraLai.Deleted = 0)
	END
	ELSE IF (@ThaoTac = 'HangHoaNhomHang')
	BEGIN
		SELECT HangHoa.MaHangHoa,HangHoa.TenHangHoa,NhomHang.MaNhomHang,NhomHang.TenNhomHang
		FROM NhomHang INNER JOIN HangHoa ON NhomHang.MaNhomHang = HangHoa.MaNhomHangHoa
		WHERE (HangHoa.Deleted = 0) and (NhomHang.Deleted = 0)
	END
	ELSE IF (@ThaoTac = 'NhomHang')
	BEGIN
		SELECT MaNhomHang,TenNhomHang FROM NhomHang WHERE (Deleted = 0)
	END
	ELSE IF (@ThaoTac = 'GoiHang')
	BEGIN
		SELECT MaGoiHang FROM GoiHang WHERE (Deleted = 0)
	END
	ELSE IF (@ThaoTac = 'ChiTietGoiHang')
	BEGIN
		SELECT MaGoiHang,MaHangHoa,TenHangHoa,SoLuong FROM ChiTietGoiHang
	END
END
go
--====================================== MRK END ===============================================

--====================================== 5 ===============================================

use SupermarketManagementDHT

------------------FIX
IF OBJECT_ID(N'[dbo].[sp_XuLy_ChiTietHoaDonNhapKhoHangFIX]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_XuLy_ChiTietHoaDonNhapKhoHangFIX]
go
create PROCEDURE sp_XuLy_ChiTietHoaDonNhapKhoHangFIX
	@HanhDong                               varchar(20),
	@MaKho	                                varchar(20),
	@MaHangHoa	                            varchar(50),
	@SoLuong	                            int,	-- Số lượng mới cho vào	
	@NgayNhap	                            datetime,	
	@HanSuDung								datetime,
	@GhiChu	                                nvarchar(100),		
	@Deleted	                            bit,
	@Gia									float	-- Giá mới cho vào
AS
BEGIN
	IF @HanhDong = 'Insert'
	BEGIN
			IF (select COUNT(*) from ChiTietKhoHang where MaHangHoa=@MaHangHoa AND MaKho=@MaKho AND Deleted=N'False')>0	--Có rồi thì update giá vốn
			BEGIN
				Declare @sl int	-- số lượng cũ	(số lượng mới là @SoLuong)
				select @sl=SoLuong from ChiTietKhoHang where MaHangHoa=@MaHangHoa AND MaKho=@MaKho
				Declare @gv float	-- giá vốn cũ	(giá vốn mới là @Gia)
				select @gv=Gia from GiaVon where MaHangHoa=@MaHangHoa AND MaKho=@MaKho
				-- update giá vốn
				Declare @gvOK float
				select @gvOK = ((@sl*@gv)+(@SoLuong*@Gia))/(@sl+@SoLuong)
				
				Update ChiTietKhoHang
				Set SoLuong=(@sl+@SoLuong)
					,HanSuDung = @HanSuDung
				Where MaKho=@MaKho AND MaHangHoa=@MaHangHoa AND Deleted=N'False'
				
				Update GiaVon
				Set SoLuong=(@sl+@SoLuong),Gia = @gvOK
				Where MaKho=@MaKho AND MaHangHoa=@MaHangHoa
			END
			ELSE
			BEGIN --Chưa có gì trong chi tiết kho hàng
				IF (select COUNT(*) from ChiTietKhoHang where MaHangHoa!=@MaHangHoa AND MaKho=@MaKho)>0
				BEGIN
					INSERT INTO ChiTietKhoHang(MaKho,MaHangHoa,SoLuong,NgayNhap,HanSuDung,GhiChu,Deleted)
					VALUES(@MaKho,@MaHangHoa,@SoLuong,@NgayNhap,@HanSuDung,@GhiChu,@Deleted)
					
					INSERT INTO GiaVon(MaKho,MaHangHoa,SoLuong,Gia)
					VALUES(@MaKho,@MaHangHoa,@SoLuong,@Gia)
				END
				ELSE
				BEGIN
					INSERT INTO ChiTietKhoHang(MaKho,MaHangHoa,SoLuong,NgayNhap,HanSuDung,GhiChu,Deleted)
					VALUES(@MaKho,@MaHangHoa,@SoLuong,@NgayNhap,@HanSuDung,@GhiChu,@Deleted)
					
					INSERT INTO GiaVon(MaKho,MaHangHoa,SoLuong,Gia)
					VALUES(@MaKho,@MaHangHoa,@SoLuong,@Gia)
				END
			END
	END
END

go
IF OBJECT_ID(N'[dbo].[sp_GiaVon]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_GiaVon]
go
CREATE proc sp_GiaVon 
	@ThaoTac nvarchar(299),
	--set
	@MaKho VARCHAR(20),
	@MaHangHoa VARCHAR(50),
	@SoLuong INT,
	@Gia FLOAT,
	--filter
	@MaKhok VARCHAR(20),
	@MaHangHoak VARCHAR(50),
	@SoLuongk INT,
	@Giak FLOAT
AS
BEGIN
	IF (@ThaoTac = 'Select_GIAVON')
	BEGIN
		SELECT 	[MaKho]
				,[MaHangHoa]
				,[SoLuong]
				,[Gia]
		FROM [SupermarketManagementDHT].[dbo].[GiaVon] 
	END
	ELSE IF (@ThaoTac = 'Insert_GIAVON')
	BEGIN
		INSERT INTO [SupermarketManagementDHT].[dbo].[GiaVon]
			([MaKho]
           ,[MaHangHoa]
           ,[SoLuong]
           ,[Gia])
		VALUES
           (@MaKho
           ,@MaHangHoa
           ,@SoLuong
           ,@Gia)
	END
	ELSE IF (@ThaoTac = 'Update_TheoMaKhoVaMaHangHoa_GIAVON')
	BEGIN
		UPDATE [SupermarketManagementDHT].[dbo].[GiaVon]
		SET [MaKho] = @MaKho
			,[MaHangHoa] = @MaHangHoa
			,[SoLuong] = @SoLuong
			,[Gia] = @Gia
		WHERE ([MaKho] = @MaKhok) and ([MaHangHoa] = @MaHangHoak)
	END
	ELSE IF (@ThaoTac = 'Delete_TheoMaKhoVaMaHangHoa_GIAVON')
	BEGIN
		DELETE FROM [SupermarketManagementDHT].[dbo].[GiaVon]
		WHERE ([MaKho] = @MaKhok) and ([MaHangHoa] = @MaHangHoak)
	END
END
go

--									Them Gia Von Ban Hang
go
IF OBJECT_ID(N'[dbo].[sp_insertGiaVonBanHang]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_insertGiaVonBanHang]
go
create proc sp_insertGiaVonBanHang
@MaHoaDon varchar(50),
@MaHangHoa varchar(50),
@GiaVon float
as 
insert into dbo.GiaVonBanHang values(@MaHoaDon,@MaHangHoa,@GiaVon)
go


--									Select Gia Von Ban Hang

IF OBJECT_ID(N'[dbo].[sp_selectGiaVonBanHang]') IS NOT NULL
 DROP PROCEDURE [dbo].[sp_selectGiaVonBanHang]
go
create proc sp_selectGiaVonBanHang
@HanhDong varchar(50),
@MaHoaDon varchar(50),
@MaHangHoa varchar(50)
as 
if(@HanhDong = 'SelectAll')
select * from GiaVonBanHang
if(@HanhDong = 'SelectBy')
select * from GiaVonBanHang where MaHoaDon = @MaHoaDon and MaHangHoa = @MaHangHoa
go

--======================================== 6 ========================================================
GO
USE SupermarketManagementDHT
GO

----------------------------
-- Select Nhóm Hàng Hóa
----------------------------
GO
IF OBJECT_ID(N'[dbo].sp_SelectNhomHangsAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectNhomHangsAll
go
CREATE PROCEDURE sp_SelectNhomHangsAll
	AS
BEGIN
Select * from NhomHang where Deleted=N'False'
END
GO
----------------------------
-- Select Loại Hàng 
----------------------------
GO
IF OBJECT_ID(N'[dbo].sp_SelectLoaiHangsAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectLoaiHangsAll
go
CREATE PROCEDURE sp_SelectLoaiHangsAll
	AS
BEGIN
Select LoaiHangID,MaLoaiHang,TenLoaiHang,GhiChu,Deleted
 from LoaiHang where Deleted=N'False'
END
GO
----------------------------
-- Select Kho Hàng
----------------------------
GO
--CREATE PROCEDURE sp_SelectKhoHangsAll
--	AS
--BEGIN
--Select * from KhoHang where Deleted=N'False'
--END
GO
----------------------------
-- Select DVT
----------------------------
GO
IF OBJECT_ID(N'[dbo].sp_SelectDVTsAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectDVTsAll
go
CREATE PROCEDURE sp_SelectDVTsAll
	AS
BEGIN
Select DVTID,MaDonViTinh,TenDonViTinh,GhiChu,Deleted
from DVT where Deleted=N'False'
END
GO

-----------------DVT-----
GO
IF OBJECT_ID(N'[dbo].sp_XuLy_DVT') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_DVT
go
CREATE PROCEDURE sp_XuLy_DVT
			@HanhDong nvarchar(20),
			@DVTID int,
			@MaDonViTinh varchar(20),
			@TenDonViTinh nvarchar(20),
			@GhiChu nvarchar(100),
			@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO DVT
			(MaDonViTinh,TenDonViTinh,GhiChu,Deleted) 
		VALUES 
			(@MaDonViTinh,@TenDonViTinh,@GhiChu,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE DVT
		 SET 
		 MaDonViTinh = @MaDonViTinh,
		 TenDonViTinh = @TenDonViTinh,
		 GhiChu = @GhiChu
		WHERE DVTID = @DVTID
	 END
END
GO
-----------Xóa DVT-----------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_DVT') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_DVT
go
CREATE PROC sp_Xoa_DVT
	@HanhDong nvarchar(20),
	@DVTID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE DVT SET Deleted = N'True'
		WHERE DVTID = @DVTID
	 END
END
GO
----------------------------
-- Select Loại Thuế
----------------------------
GO
IF OBJECT_ID(N'[dbo].sp_SelectLoaiThuesAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectLoaiThuesAll
go
CREATE PROCEDURE sp_SelectLoaiThuesAll
	AS
BEGIN
Select * from LoaiThue where Deleted=N'False'
END
GO
------------------------------------------------------------------------------------------------------------------------
-- Nhóm Hàng Hóa
------------------------------------------------------------------------------------------------------------------------
GO
--CREATE PROCEDURE sp_XuLy_NhomHangHoa
--			@HanhDong nvarchar(20),
--			@NhomHangID int,
--			@MaNhomHang varchar(20),
--			@MaLoaiHang varchar(20),
--			@TenNhomHang nvarchar(20),
--			@GhiChu nvarchar(250),
--			@Deleted bit
--AS
--BEGIN
--	IF @HanhDong = N'Insert'
--	BEGIN
--		INSERT INTO NhomHang
--			(MaNhomHang,MaLoaiHang,GhiChu,Deleted) 
--		VALUES 
--			(@MaNhomHang,@TenNhomHang,@GhiChu,@Deleted)
--	 END
--	 IF @HanhDong = N'Update'
--	 BEGIN
--		 UPDATE NhomHang
--		 SET 
--		 MaNhomHang = @MaNhomHang,
--		 MaLoaiHang=@MaLoaiHang, 
--		 TenNhomHang = @TenNhomHang,
--		 GhiChu = @GhiChu
--		WHERE NhomHangID = @NhomHangID
--	 END
--END
GO
------------------------------------------------------------------------------------------------------------------------
-- Nhóm Loại Hàng Hóa
------------------------------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_XuLy_LoaiHangHoa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_LoaiHangHoa
go
CREATE PROCEDURE sp_XuLy_LoaiHangHoa
			@HanhDong nvarchar(20),
			@LoaiHangID int,
			@MaLoaiHang varchar(20),
			@TenLoaiHang nvarchar(200),
			@GhiChu nvarchar(250),
			@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO LoaiHang
			(MaLoaiHang,TenLoaiHang,GhiChu,Deleted) 
		VALUES 
			(@MaLoaiHang,@TenLoaiHang,@GhiChu,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE LoaiHang
		 SET 
		 MaLoaiHang = @MaLoaiHang,
		 TenLoaiHang = @TenLoaiHang,
		 GhiChu = @GhiChu
		WHERE LoaiHangID = @LoaiHangID
	 END
END
GO
----------------------------------------------------------------------------------------------------------------
-- Xóa Nhóm Hàng Hóa
------------------------------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_NhomHangHoa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_NhomHangHoa
go
CREATE PROC sp_Xoa_NhomHangHoa
	@HanhDong nvarchar(20),
	@NhomHangID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE NhomHang SET Deleted = N'True'
		WHERE NhomHangID = @NhomHangID
	 END
END
GO
------------------------------------------------------------------------------------------------------------------------
-- Xóa Loại Hàng Hóa
------------------------------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_LoaiHangHoa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_LoaiHangHoa
go
CREATE PROC sp_Xoa_LoaiHangHoa
	@HanhDong nvarchar(20),
	@LoaiHangID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE LoaiHang SET Deleted = N'True'
		WHERE LoaiHangID = @LoaiHangID
	 END
END
GO

--================================== 7 son ======================================================

GO
USE SupermarketManagementDHT
GO
------------------------------
-- Nhân Viên				--
------------------------------
		------------------------------
		-- Select					--
		------------------------------
IF OBJECT_ID(N'[dbo].sp_SelectNhanViensAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectNhanViensAll
go
CREATE PROCEDURE sp_SelectNhanViensAll
	AS
BEGIN
Select * from NhanVien where Deleted=N'False'
END
Go
		------------------------------
		-- Insert AND Update		--
		------------------------------
IF OBJECT_ID(N'[dbo].sp_XuLy_NhanVien') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_NhanVien
go
CREATE PROCEDURE sp_XuLy_NhanVien
		@HanhDong nvarchar(20),
	@NhanVienID int,
	@MaNhanVien nvarchar(20),
	@TenNhanVien nvarchar(200),
	@MaPhongBan varchar(20),
	@DCThuongTru nvarchar(200),
	@DCTamTru nvarchar(200),
	@DienThoaiCD nvarchar(20),
	@DienThoaiDD nvarchar(20),
	@Email nvarchar(50),
	@CMND varchar(20),
	@NgayCap DateTime,
	@NoiCap nvarchar(20),
	@NgaySinh DateTime,
	@GhiChu nvarchar(100),
	@Deleted bit
	AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO NhanVien 
		VALUES 
			(@MaNhanVien,@TenNhanVien,@MaPhongBan,@DCThuongTru,@DCTamTru,
			 @DienThoaiCD,@DienThoaiDD,@Email,@CMND,@NgayCap,
			 @NoiCap,@NgaySinh,@GhiChu,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE NhanVien
		 SET MaNhanVien = @MaNhanVien,
			 TenNhanVien = @TenNhanVien,
			 MaPhongBan = @MaPhongBan,
			 DCThuongTru = @DCThuongTru,
			 DCTamTru = @DCTamTru,
			 DienThoaiCD = @DienThoaiCD,
			 DienThoaiDD = @DienThoaiDD,
			 Email = @Email,
			 CMND = @CMND,
			 NgayCap = @NgayCap,
			 NoiCap = @NoiCap,
			 NgaySinh = @NgaySinh,
			 GhiChu = @GhiChu
		WHERE NhanVienID = @NhanVienID
	 END
END
	
		------------------------------
		-- DELETE					--
		------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_NhanVien') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_NhanVien
go
CREATE PROC sp_Xoa_NhanVien
	@HanhDong nvarchar(20),
	@NhanVienID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE NhanVien SET Deleted = N'True'
		WHERE NhanVienID = @NhanVienID
	 END
END
GO
------------------------------
-- Phòng Ban				--
------------------------------
IF OBJECT_ID(N'[dbo].sp_SelectPhongBansAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectPhongBansAll
go
CREATE PROCEDURE sp_SelectPhongBansAll
	AS
BEGIN
Select * from PhongBan where Deleted=N'False'
END
GO
		------------------------------
		-- Insert AND Update		--
		------------------------------
IF OBJECT_ID(N'[dbo].sp_XuLy_PhongBan') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_PhongBan
go
CREATE PROCEDURE sp_XuLy_PhongBan
	@HanhDong nvarchar(20),
	@PhongBanID int,
	@MaPhongBan nvarchar(20),
	@TenPhongBan nvarchar(200),
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO PhongBan 
			(MaPhongBan,TenPhongBan,GhiChu,Deleted) 
		VALUES 
			(@MaPhongBan,@TenPhongBan,@GhiChu,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE PhongBan
		 SET MaPhongBan = @MaPhongBan,
			 TenPhongBan = @TenPhongBan,
			 GhiChu = @GhiChu
		WHERE PhongBanID = @PhongBanID
	 END
END
		------------------------------
		-- DELETE					--
		------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_PhongBan') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_PhongBan
go
CREATE PROC sp_Xoa_PhongBan
	@HanhDong nvarchar(20),
	@PhongBanID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE PhongBan SET Deleted = N'True'
		WHERE PhongBanID = @PhongBanID
	 END
END
------------------------------
-- Nhóm TK Kế Toán			--
------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_SelectNhomTKKeToansAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectNhomTKKeToansAll
go
CREATE PROCEDURE sp_SelectNhomTKKeToansAll
	AS
BEGIN
Select * from NhomTKKeToan where Deleted=N'False'
END
GO
		------------------------------
		-- Insert AND Update		--
		------------------------------
IF OBJECT_ID(N'[dbo].sp_XuLy_NhomTKKeToan') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_NhomTKKeToan
go
CREATE PROCEDURE sp_XuLy_NhomTKKeToan
	@HanhDong nvarchar(20),
	@NhomTKKeToanID int,
	@MaNhomTKKeToan nvarchar(20),
	@TenNhomTKKeToan nvarchar(200),
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO NhomTKKeToan 
			(MaNhomTKKeToan,TenNhomTKKeToan,GhiChu,Deleted) 
		VALUES 
			(@MaNhomTKKeToan,@TenNhomTKKeToan,@GhiChu,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE NhomTKKeToan
		 SET MaNhomTKKeToan = @MaNhomTKKeToan,
			 TenNhomTKKeToan = @TenNhomTKKeToan,
			 GhiChu = @GhiChu
		WHERE NhomTKKeToanID = @NhomTKKeToanID
	 END
END
		------------------------------
		-- DELETE					--
		------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_NhomTKKeToan') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_NhomTKKeToan
go
CREATE PROC sp_Xoa_NhomTKKeToan
	@HanhDong nvarchar(20),
	@NhomTKKeToanID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		delete NhomTKKeToan where NhomTKKeToanID=@NhomTKKeToanID
	 END
END
GO

------------------------------
-- Tiền Tệ					--
------------------------------
IF OBJECT_ID(N'[dbo].sp_SelectTienTesAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectTienTesAll
go
CREATE PROCEDURE sp_SelectTienTesAll
	AS
BEGIN
Select * from TienTe where Deleted=N'False'
END
GO
		------------------------------
		-- Insert AND Update		--
		------------------------------
IF OBJECT_ID(N'[dbo].sp_XuLy_TienTe') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_TienTe
go
CREATE PROCEDURE sp_XuLy_TienTe
	@HanhDong nvarchar(20),
	@TienteID int,
	@MaTienTe varchar(20),
	@TenTienTe nvarchar(200),
	@TenTienTeChan nvarchar(200),
	@TenTienTeLe nvarchar(200),
	@BieuTuong varchar(10),
	@DonViLamTron int,
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO TienTe 
			(MaTienTe,TenTienTe,TenTienTeChan,TenTienTeLe,BieuTuong,DonViLamTron,GhiChu,Deleted) 
		VALUES 
			(@MaTienTe,@TenTienTe,@TenTienTeChan,@TenTienTeLe,@BieuTuong,@DonViLamTron,@GhiChu,@Deleted) 
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE TienTe
		 SET MaTienTe = @MaTienTe,
			 TenTienTe = @TenTienTe,
			 TenTienTeChan= @TenTienTeChan,
			 TenTienTeLe=@TenTienTeLe,
			 BieuTuong=@BieuTuong,
			 DonViLamTron=@DonViLamTron,
			 GhiChu = @GhiChu
		WHERE TienteID = @TienteID
	 END
END
		------------------------------
		-- DELETE					--
		------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_TienTe') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_TienTe
go
CREATE PROC sp_Xoa_TienTe
	@HanhDong nvarchar(20),
	@TienTeID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE TienTe SET Deleted = N'True'
		WHERE TienteID = @TienTeID
	 END
END
GO
------------------------------
-- TK Kế Toán				--
------------------------------
IF OBJECT_ID(N'[dbo].sp_SelectTKKeToansAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectTKKeToansAll
go
CREATE PROCEDURE sp_SelectTKKeToansAll
	AS
BEGIN
Select * from TKKeToan where Deleted=N'False'
END
go

		------------------------------
		-- Insert AND Update		--
		------------------------------
IF OBJECT_ID(N'[dbo].sp_XuLy_TKKeToan') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_TKKeToan
go
CREATE PROCEDURE sp_XuLy_TKKeToan
	@HanhDong nvarchar(20),
	@TKKeToanID int,
	@MaTKKeToan varchar(20),
	@MaNhomTKKeToan varchar(20),
	@TenTaiKhoan nvarchar(200),
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO TKKeToan 
			(MaTKKeToan,MaNhomTKKeToan,TenTaiKhoan,GhiChu,Deleted) 
		VALUES 
			(@MaTKKeToan,@MaNhomTKKeToan,@TenTaiKhoan,@GhiChu,@Deleted) 
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE TKKeToan
		 SET MaTKKeToan = @MaTKKeToan,
			 MaNhomTKKeToan=@MaNhomTKKeToan,
			 TenTaiKhoan = @TenTaiKhoan,
			 GhiChu = @GhiChu
		WHERE TKKeToanID = @TKKeToanID
	 END
END
		------------------------------
		-- DELETE					--
		------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_TKKeToan') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_TKKeToan
go
CREATE PROC sp_Xoa_TKKeToan
	@HanhDong nvarchar(20),
	@TKKeToanID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		Delete TKKeToan WHERE TKKeToanID = @TKKeToanID
		
	 END
END
GO

------------------------------
-- TK Khoản Mục Thu Chi		--
------------------------------
IF OBJECT_ID(N'[dbo].sp_SelectKMThuChisAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectKMThuChisAll
go
CREATE PROCEDURE sp_SelectKMThuChisAll
	AS
BEGIN
Select * from KMThuChi where Deleted=N'False'
END
go

		------------------------------
		-- Insert AND Update		--
		------------------------------
IF OBJECT_ID(N'[dbo].sp_XuLy_KMThuChi') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_KMThuChi
go
CREATE PROCEDURE sp_XuLy_KMThuChi
	@HanhDong nvarchar(20),
	@ThuChiID nvarchar(20),
	@MaKhoanMuc nvarchar(20),
	@TenKhoanMuc nvarchar(200),
	@LoaiKM varchar(20),
	@DoiTuong varchar(20),
	@NoTK nvarchar(200),
	@CoTK nvarchar(200),
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO KMThuChi 
			(MaKhoanMuc,TenKhoanMuc,LoaiKM,DoiTuong,NoTK,CoTK,GhiChu,Deleted) 
		VALUES 
			(@MaKhoanMuc,@TenKhoanMuc,@LoaiKM,@DoiTuong,@NoTK,@CoTK,@GhiChu,@Deleted) 
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE KMThuChi
		 SET MaKhoanMuc = @MaKhoanMuc,
			 TenKhoanMuc = @TenKhoanMuc,
			 LoaiKM= @LoaiKM,
			 DoiTuong=@DoiTuong,
			 NoTK=@NoTK,
			 CoTK=@CoTK,
			 GhiChu = @GhiChu
		WHERE ThuChiID = @ThuChiID
	 END
END
		------------------------------
		-- DELETE					--
		------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_KMThuChi') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_KMThuChi
go
CREATE PROC sp_Xoa_KMThuChi
	@HanhDong nvarchar(20),
	@ThuChiID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE KMThuChi SET Deleted = N'True'
		WHERE ThuChiID = @ThuChiID
	 END
END
GO
IF OBJECT_ID(N'[dbo].sp_SelectPhieuDieuChuyenKhoNoiBosAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectPhieuDieuChuyenKhoNoiBosAll
go
CREATE PROCEDURE sp_SelectPhieuDieuChuyenKhoNoiBosAll
	AS
BEGIN
Select * from PhieuDieuChuyenKho where Deleted=N'False'
END
go


		------------------------------
		-- Insert AND Update		--
		------------------------------
IF OBJECT_ID(N'[dbo].sp_XuLy_PhieuDieuChuyenKhoNoiBo') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_PhieuDieuChuyenKhoNoiBo
go
CREATE PROCEDURE sp_XuLy_PhieuDieuChuyenKhoNoiBo
	@HanhDong nvarchar(20),
	@PhieuDieuChuyenKhoID int,
	@MaPhieuDieuChuyenKho nvarchar(20),
	@NgayDieuChuyen datetime,
	@TuKho varchar(20),
	@DenKho varchar(20),
	@MaHoaDonNhap varchar(20),
	@XacNhan bit,
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO PhieuDieuChuyenKho 
			(MaPhieuDieuChuyenKho ,NgayDieuChuyen ,TuKho ,DenKho ,MaHoaDonNhap ,XacNhan ,GhiChu ,Deleted ) 
		VALUES 
			(@MaPhieuDieuChuyenKho ,@NgayDieuChuyen ,@TuKho ,@DenKho ,@MaHoaDonNhap ,@XacNhan ,@GhiChu ,@Deleted ) 
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE PhieuDieuChuyenKho
		 SET 
			 MaPhieuDieuChuyenKho=@MaPhieuDieuChuyenKho ,
			 NgayDieuChuyen=@NgayDieuChuyen ,
			 TuKho=@TuKho ,
			 DenKho=@DenKho ,
			 MaHoaDonNhap=@MaHoaDonNhap ,
			 XacNhan=@XacNhan ,
			 GhiChu=@GhiChu
			 WHERE PhieuDieuChuyenKhoID=@PhieuDieuChuyenKhoID 
		
	 END
END
		------------------------------
		-- DELETE					--
		------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_PhieuDieuChuyenKhoNoiBo') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_PhieuDieuChuyenKhoNoiBo
go
CREATE PROC sp_Xoa_PhieuDieuChuyenKhoNoiBo
	@HanhDong nvarchar(20),
	@PhieuDieuChuyenKhoID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE PhieuDieuChuyenKho SET Deleted = N'True'
		WHERE PhieuDieuChuyenKhoID = @PhieuDieuChuyenKhoID
	 END
END
GO
IF OBJECT_ID(N'[dbo].sp_SelectChiTietPhieuDieuChuyenKhoNoiBosAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectChiTietPhieuDieuChuyenKhoNoiBosAll
go
Create PROCEDURE sp_SelectChiTietPhieuDieuChuyenKhoNoiBosAll
	AS
BEGIN
Select * from ChiTietPhieuDieuChuyenKho a join HangHoa b on a.MaHangHoa = b.MaHangHoa
where a.Deleted=N'False'
END
go


		------------------------------
		-- Insert AND Update		--
		------------------------------
IF OBJECT_ID(N'[dbo].sp_XuLy_ChiTietPhieuDieuChuyenKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_ChiTietPhieuDieuChuyenKho
go
CREATE PROCEDURE sp_XuLy_ChiTietPhieuDieuChuyenKho
	@HanhDong nvarchar(20),
	@MaPhieuDieuChuyenKho nvarchar(50),
	@MaHangHoa nvarchar(50),
	@SoLuong int,
	@GhiChu nvarchar(100),
	@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO ChiTietPhieuDieuChuyenKho 
			(MaPhieuDieuChuyenKho ,MaHangHoa ,SoLuong,GhiChu ) 
		VALUES 
			(@MaPhieuDieuChuyenKho ,@MaHangHoa ,@SoLuong,@GhiChu) 
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE ChiTietPhieuDieuChuyenKho
		 SET 
			 SoLuong=@SoLuong,
			 GhiChu=@GhiChu
			 WHERE (MaPhieuDieuChuyenKho=@MaPhieuDieuChuyenKho) and (MaHangHoa=@MaHangHoa)
		
	 END
END
		------------------------------
		-- DELETE					--
		------------------------------

GO
IF OBJECT_ID(N'[dbo].sp_SelectChiTietKhoHangsAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectChiTietKhoHangsAll
go
create PROCEDURE sp_SelectChiTietKhoHangsAll
	AS
BEGIN
Select * from ChiTietKhoHang where Deleted=N'False'
END

Go
IF OBJECT_ID(N'[dbo].sp_SelectCapNhatGiasAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectCapNhatGiasAll
go
CREATE PROCEDURE sp_SelectCapNhatGiasAll
	AS
BEGIN
Select * from CapNhatGia where Deleted=N'False'
END

Go

		------------------------------
		-- Insert AND Update		--
		------------------------------
IF OBJECT_ID(N'[dbo].sp_XuLy_CapNhatGia') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_CapNhatGia
go
CREATE PROCEDURE sp_XuLy_CapNhatGia
	@HanhDong nvarchar(20),
	@CapNhatGiaID int,
	@MaCapNhatGia nvarchar(20),
	@NgayBatDau Datetime,
	@NgayKetThuc Datetime,
	@MaHangHoa nvarchar(50),
	@PhanTramGiaBanBuon float,
	@PhanTramGiaBanLe float,
	@GiaNhap float,
	@TrangThai bit,
	@GhiChu nvarchar(100),
	@Deleted bit
	AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO CapNhatGia 
		VALUES 
			(@MaCapNhatGia,@NgayBatDau,@NgayKetThuc,@MaHangHoa,@PhanTramGiaBanBuon,
			 @PhanTramGiaBanLe,@GiaNhap,@TrangThai,@GhiChu,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE CapNhatGia
		 SET MaCapNhatGia = @MaCapNhatGia,
			 NgayBatDau = @NgayBatDau,
			 NgayKetThuc = @NgayKetThuc,
			 MaHangHoa = @MaHangHoa,
			 PhanTramGiaBanBuon = @PhanTramGiaBanBuon,
			 PhanTramGiaBanLe = @PhanTramGiaBanLe,
			 GiaNhap = @GiaNhap,
			 Trangthai = @TrangThai,
			 GhiChu = @GhiChu
		WHERE CapNhatGiaID = @CapNhatGiaID
	 END
END

	
		------------------------------
		-- DELETE					--
		------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_CapNhatGia') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_CapNhatGia
go
CREATE PROC sp_Xoa_CapNhatGia
	@HanhDong nvarchar(20),
	@CapNhatGiaID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE CapNhatGia SET Deleted = N'True'
		WHERE CapNhatGiaID = @CapNhatGiaID
	 END
END
Go
IF OBJECT_ID(N'[dbo].sp_XoaChiTietPhieuDieuChuyenKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XoaChiTietPhieuDieuChuyenKho
go
create proc sp_XoaChiTietPhieuDieuChuyenKho
@HanhDong nvarchar(20),
@MaPhieuDieuChuyenKho nvarchar(20)
as
Begin
	IF @HanhDong = N'Delete'
	 BEGIN
		Delete ChiTietPhieuDieuChuyenKho where MaPhieuDieuChuyenKho=@MaPhieuDieuChuyenKho
	 END
end
GO
--------------
-- Select SP
--------------
----------------------------
-- Select Hàng Hóa
----------------------------
GO
IF OBJECT_ID(N'[dbo].sp_SelectHangHoasAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectHangHoasAll
go
CREATE PROCEDURE sp_SelectHangHoasAll
	AS
BEGIN
Select * from HangHoa where Deleted=N'False'
END
GO

GO
IF OBJECT_ID(N'[dbo].sp_XuLy_HangHoa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_HangHoa
go
CREATE PROCEDURE sp_XuLy_HangHoa
			@HanhDong nvarchar(20),
			@MaHangHoa varchar(50),
			@MaNhomHangHoa nvarchar(20),
			@TenHangHoa nvarchar(200),
			@MaDonViTinh nvarchar(20),
			@GiaNhap float,
			@GiaBanBuon float,
			@GiaBanLe float,
			@MaThueGiaTriGiaTang nvarchar(20),
			@KieuHangHoa nvarchar(20),
			@SeriLo nvarchar(20),
			@MucDatHang nvarchar(20),
			@MucTonToiThieu nvarchar(20),
			@GhiChu nvarchar(250),
			@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO HangHoa 
			(MaHangHoa,MaNhomHangHoa,TenHangHoa,MaDonViTinh,GiaNhap,GiaBanBuon,GiaBanLe,MaThueGiaTriGiaTang,KieuHangHoa,SeriLo,MucDatHang,MucTonToiThieu,GhiChu,Deleted) 
		VALUES 
			(@MaHangHoa,@MaNhomHangHoa,@TenHangHoa,@MaDonViTinh,@GiaNhap,@GiaBanBuon,@GiaBanLe,@MaThueGiaTriGiaTang,@KieuHangHoa,@SeriLo,@MucDatHang,@MucTonToiThieu,@GhiChu,@Deleted )
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE HangHoa
		 SET 
				MaNhomHangHoa=@MaNhomHangHoa,
				TenHangHoa=@TenHangHoa,
				MaDonViTinh=@MaDonViTinh,
				GiaNhap=@GiaNhap,
				GiaBanBuon=@GiaBanBuon,
				GiaBanLe=@GiaBanLe,
				MathueGiaTriGiaTang=@MaThueGiaTriGiaTang,
				KieuHangHoa=@KieuHangHoa,
				SeriLo=@SeriLo,
				MucDatHang=@MucDatHang,
				MucTonToiThieu=@MucTonToiThieu,
				GhiChu=@GhiChu
		WHERE 	MaHangHoa=@MaHangHoa
	 END
END
GO
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_HangHoa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_HangHoa
go
CREATE PROC sp_Xoa_HangHoa
	@HanhDong nvarchar(20),
	@HangHoaID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE HangHoa SET Deleted = N'True'
		WHERE HangHoaID = @HangHoaID
	 END
END
GO

GO
IF OBJECT_ID(N'[dbo].sp_SelectSoDuKhosAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectSoDuKhosAll
go
CREATE PROCEDURE sp_SelectSoDuKhosAll
	AS
BEGIN
SELECT SoDuKho.MaSoDuKho,SoDuKho.MaKho,SoDuKho.MaHangHoa,HangHoa.TenHangHoa,SoDuKho.SoDuDauKy,SoDuKho.NgayKetChuyen,SoDuKho.SoDuCuoiKy,SoDuKho.TrangThai
	FROM SoDuKho INNER JOIN HangHoa ON SoDuKho.MaHangHoa = HangHoa.MaHangHoa
END
GO

GO
IF OBJECT_ID(N'[dbo].sp_XuLy_SoDuKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_SoDuKho
go
CREATE PROCEDURE sp_XuLy_SoDuKho
			@HanhDong nvarchar(20),
			@SoDuKhoID int,
			@MaSoDuKho varchar(20),
			@MaKho varchar(20),
			@MaHangHoa varchar(50),
			@SoDuDauKy int,
			@NgayKetChuyen Datetime,
			@SoDuCuoiKy float	,
			@TrangThai bit	
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO SoDuKho 
			(MaSoDuKho,MaHangHoa,MaKho,SoDuDauKy,NgayKetChuyen,SoDuCuoiKy,TrangThai) 
		VALUES 
			(@MaSoDuKho,@MaHangHoa,@MaKho,@SoDuDauKy,@NgayKetChuyen,@SoDuCuoiKy,@TrangThai)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE SoDuKho
		 SET 
				MaSoDuKho=@MaSoDuKho,
				MaKho=@MaKho,
				SoDuDauKy=@SoDuDauKy,
				MaHangHoa=@MaHangHoa,
				NgayKetChuyen=@NgayKetChuyen,
				SoDuCuoiKy=@SoDuCuoiKy,
				TrangThai=@TrangThai
		WHERE 	SoDuKhoID=@SoDuKhoID
	 END
END
GO
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_SoDuKho') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_SoDuKho
go
CREATE PROC sp_Xoa_SoDuKho
	@HanhDong nvarchar(20),
	@SoDuKhoID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		delete SoDuKho WHERE SoDuKhoID = @SoDuKhoID
	 END
END
GO


--======================================== 8 ========================================
use SupermarketManagementDHT
go
--							Thêm Thẻ Giám Giá
IF OBJECT_ID(N'[dbo].sp_InsertUpdateTheGiamGia') IS NOT NULL
 DROP PROCEDURE [dbo].sp_InsertUpdateTheGiamGia
go
create proc sp_InsertUpdateTheGiamGia
	@MaTheGiamGia varchar(50),
	@MaKhachHang varchar(50),
	@GiaTriThe float,
	@NgayBatDau datetime,
	@NgayKetThuc datetime
as
begin
insert into TheGiamGia values(@MaTheGiamGia,@MaKhachHang,@GiaTriThe,@GiaTriThe,@NgayBatDau,@NgayKetThuc,0)
end
go
--							Update thẻ giám giá
IF OBJECT_ID(N'[dbo].sp_UpdateTheGiamGia') IS NOT NULL
 DROP PROCEDURE [dbo].sp_UpdateTheGiamGia
go
create proc sp_UpdateTheGiamGia
	@MaTheGiamGia varchar(50),
	@GiaTriConLai float	
as
begin
update TheGiamGia set
	GiaTriConLai = @GiaTriConLai
	where MaTheGiamGia = @MaTheGiamGia
end
go
--							select
IF OBJECT_ID(N'[dbo].sp_SelectTheGiamGia') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectTheGiamGia
go
create proc sp_SelectTheGiamGia
	as
	select * from TheGiamGia where Deleted = 0
go
--							Delete
IF OBJECT_ID(N'[dbo].sp_DeleteTheGiamGia') IS NOT NULL
 DROP PROCEDURE [dbo].sp_DeleteTheGiamGia
go
create proc sp_DeleteTheGiamGia
	@MaTheGiamGia varchar(50)
as
begin
update TheGiamGia set
	Deleted = 1
	where MaTheGiamGia = @MaTheGiamGia
end
go
--							Thêm Thẻ VIP
IF OBJECT_ID(N'[dbo].sp_insertTheVip') IS NOT NULL
 DROP PROCEDURE [dbo].sp_insertTheVip
go
create proc sp_insertTheVip
@MaKhachHang varchar(50),
@MaThe varchar(50),
@GiaTriThe float,
@GiaTriConLai float,
@GhiChu nvarchar(100),
@SoDiem float
as
insert into TheVip values(@MaKhachHang,@MaThe,@GiaTriThe,@GiaTriConLai,@GhiChu,@SoDiem,0)
go
--							Sửa Thẻ Vip
IF OBJECT_ID(N'[dbo].sp_updateGiaTriConLaiTheVip') IS NOT NULL
 DROP PROCEDURE [dbo].sp_updateGiaTriConLaiTheVip
go
create proc sp_updateGiaTriConLaiTheVip
@MaThe varchar(50),
@GiaTriConLai float
as
update TheVip set
GiaTriConLai=@GiaTriConLai
where MaThe=@MaThe
go
--							Xóa Thẻ Vip
IF OBJECT_ID(N'[dbo].sp_deleteTheVip') IS NOT NULL
 DROP PROCEDURE [dbo].sp_deleteTheVip
go
create proc sp_deleteTheVip
@MaThe varchar(50)
as
update TheVip set
Deleted=1
where MaThe=@MaThe
go
--							Lấy Thẻ Vip
IF OBJECT_ID(N'[dbo].sp_selectTheVipTheoMaKhachHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectTheVipTheoMaKhachHang
go
create proc sp_selectTheVipTheoMaKhachHang
@MaKhachHang varchar(50)
as
select * from TheVip where MaKhachHang=@MaKhachHang
go
IF OBJECT_ID(N'[dbo].sp_selectTheVipAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_selectTheVipAll
go
create proc sp_selectTheVipAll
as
select * from TheVip

--==================================================== 9 =============================================
--drop huong
GO
USE SupermarketManagementDHT
GO
---------------- Select quy đổi đơn vị tính theo mã ----------
IF OBJECT_ID(N'[dbo].sp_SelectQuyDoiDVTTheoMa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectQuyDoiDVTTheoMa
go
CREATE PROCEDURE sp_SelectQuyDoiDVTTheoMa
	@MaHangDuocQuyDoi varchar(50)
	AS
	BEGIN
		SELECT * FROM QuyDoiDonViTinh WHERE MaHangDuocQuyDoi=@MaHangDuocQuyDoi
	END
	GO
--------------Select Quy Đổi Đơn Vị Tính -------------
IF OBJECT_ID(N'[dbo].sp_SelectQuyDoiDonViTinh') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectQuyDoiDonViTinh
go
CREATE PROCEDURE sp_SelectQuyDoiDonViTinh
AS
BEGIN
	SELECT QuyDoiDonViTinhID,MaQuyDoiDonViTinh,MaHangQuyDoi,TenHangQuyDoi,MaDonViTinh,SoLuongQuyDoi,MaHangDuocQuyDoi,
	TenHangDuocQuyDoi,MaDonViTinhDuocQuyDoi,SoLuongDuocQuyDoi,Deleted
	FROM QuyDoiDonViTinh WHERE Deleted='False'
END
GO
------------Xử Lý Quy Đổi Đơn Vị Tính --------------------
IF OBJECT_ID(N'[dbo].sp_XuLy_QuyDoiDonViTinh') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_QuyDoiDonViTinh
go
CREATE PROCEDURE sp_XuLy_QuyDoiDonViTinh
@HanhDong nvarchar(20),
@QuyDoiDonViTinhID int,
@MaQuyDoiDonViTinh nvarchar(50),
@MaHangQuyDoi nvarchar(50),
@TenHangQuyDoi nvarchar(200),
@MaDonViTinh nvarchar(50),
@SoLuongQuyDoi int,
@MaHangDuocQuyDoi nvarchar(50),
@TenHangDuocQuyDoi nvarchar(200),
@MaDonViTinhDuocQuyDoi nvarchar(50),
@SoLuongDuocQuyDoi int,
@Deleted bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO QuyDoiDonViTinh
			(MaQuyDoiDonViTinh,MaHangQuyDoi,TenHangQuyDoi,MaDonViTinh,SoLuongQuyDoi,MaHangDuocQuyDoi,
	TenHangDuocQuyDoi,MaDonViTinhDuocQuyDoi,SoLuongDuocQuyDoi,Deleted) 
		VALUES 
			(@MaQuyDoiDonViTinh,@MaHangQuyDoi,@TenHangQuyDoi,@MaDonViTinh,@SoLuongQuyDoi,@MaHangDuocQuyDoi,
	@TenHangDuocQuyDoi,@MaDonViTinhDuocQuyDoi,@SoLuongDuocQuyDoi,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE QuyDoiDonViTinh
		 SET 		 
		 MaHangQuyDoi = @MaHangQuyDoi,
		 TenHangQuyDoi=@TenHangQuyDoi,
		 MaDonViTinh=@MaDonViTinh,
		 SoLuongQuyDoi = @SoLuongQuyDoi,		
		 MaHangDuocQuyDoi=@MaHangDuocQuyDoi,
		 TenHangDuocQuyDoi=@TenHangDuocQuyDoi,
		 MaDonViTinhDuocQuyDoi=@MaDonViTinhDuocQuyDoi,
		 SoLuongDuocQuyDoi=@SoLuongDuocQuyDoi,
		 Deleted=Deleted
		WHERE MaQuyDoiDonViTinh = @MaQuyDoiDonViTinh
	 END
END
GO
------------Delete Quy Đổi Đơn vị Tính ------------
IF OBJECT_ID(N'[dbo].sp_Xoa_QuyDoiDonViTinh') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_QuyDoiDonViTinh
go
CREATE PROCEDURE sp_Xoa_QuyDoiDonViTinh
@QuyDoiDonViTinhID int
AS
BEGIN
	 BEGIN
		delete from QuyDoiDonViTinh WHERE QuyDoiDonViTinhID = @QuyDoiDonViTinhID
	 END
END
GO
-------------Select Gói Hàng--------------
IF OBJECT_ID(N'[dbo].sp_SelectGoiHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectGoiHang
go
Create PROCEDURE sp_SelectGoiHang
AS
BEGIN
	SELECT a.GoiHangID,a.MaKho,a.MaGoiHang,a.TenGoiHang,a.MaNhomHang,b.TenNhomHang,a.GiaNhap,a.GiaBanBuon,a.GiaBanLe,a.Deleted
	FROM GoiHang a join NhomHang b on a.MaNhomHang=b.MaNhomHang  WHERE a.Deleted='False'
END
GO
----------- Select gói hàng theo mã ---------
IF OBJECT_ID(N'[dbo].sp_SelectGoiHangTheoMa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectGoiHangTheoMa
go
CREATE PROCEDURE sp_SelectGoiHangTheoMa
	@MaGoiHang varchar(50)
AS
BEGIN
	select * from GoiHang where MaGoiHang = @MaGoiHang
END
GO
------------- Xử Lý Gói Hàng -------------
IF OBJECT_ID(N'[dbo].sp_XuLy_GoiHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_GoiHang
go
CREATE PROCEDURE sp_XuLy_GoiHang
@HanhDong nvarchar(20),
@GoiHangID int,
@MaKho VARCHAR(20),
@MaGoiHang varchar(50),
@TenGoiHang nvarchar(200),
@MaNhomHang varchar(50),
@TenNhomHang nvarchar(200),
@GiaNhap float,
@GiaBanBuon float,
@GiaBanLe float,
@Deleted bit
AS
BEGIN
		IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO GoiHang
			(MaKho,MaGoiHang,TenGoiHang,MaNhomHang,TenNhomHang,GiaNhap,GiaBanBuon,GiaBanLe,Deleted) 
		VALUES 
			(@Makho,@MaGoiHang,@TenGoiHang,@MaNhomHang,@TenNhomHang,@GiaNhap,@GiaBanBuon,@GiaBanLe,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE GoiHang
		 SET 	
		 MaKho=@MaKho,	 
		 TenGoiHang = @TenGoiHang,
		 MaNhomHang = @MaNhomHang,
		 TenNhomHang = @TenNhomHang,
		 GiaNhap = @GiaNhap,		
		 GiaBanBuon=@GiaBanBuon,
		 GiaBanLe=@GiaBanLe,
		 Deleted=@Deleted
		WHERE MaGoiHang = @MaGoiHang
	 END
END
GO
-------------Xóa Gói Hàng ----------------
IF OBJECT_ID(N'[dbo].sp_Xoa_GoiHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_GoiHang
go
CREATE PROCEDURE sp_Xoa_GoiHang
	@GoiHangID int
AS
BEGIN
	 BEGIN
		UPDATE GoiHang SET Deleted = N'True'
		WHERE GoiHangID = @GoiHangID
	 END
END
GO
-------------Select Chi Tiết Gói Hàng -------
IF OBJECT_ID(N'[dbo].sp_SelectChiTietGoiHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectChiTietGoiHang
go
CREATE PROCEDURE sp_SelectChiTietGoiHang
AS
BEGIN
	SELECT ChiTietGoiHangID,MaGoiHang,MaHangHoa,TenHangHoa,SoLuong,GiaNhap,GiaBanBuon,GiaBanLe
	FROM ChiTietGoiHang  
END
GO
------------- Xử Lý Chi Tiết Gói Hàng ------------
IF OBJECT_ID(N'[dbo].sp_XuLy_ChiTietGoiHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_ChiTietGoiHang
go
CREATE PROCEDURE sp_XuLy_ChiTietGoiHang
@HanhDong nvarchar(20),
@ChiTietGoiHangID int,
@MaGoiHang varchar(50),
@MaHangHoa varchar(50),
@TenHangHoa nvarchar(200),
@SoLuong float,
@GiaNhap float,
@GiaBanBuon float,
@GiaBanLe float
AS
BEGIN
		IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO ChiTietGoiHang
			(MaGoiHang,MaHangHoa,TenHangHoa,SoLuong,GiaNhap,GiaBanBuon,GiaBanLe) 
		VALUES 
			(@MaGoiHang,@MaHangHoa,@TenHangHoa,@SoLuong,@GiaNhap,@GiaBanBuon,@GiaBanLe)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE ChiTietGoiHang 
		 SET 		 
		 MaHangHoa = @MaHangHoa,
		 TenHangHoa = @TenHangHoa,		
		 SoLuong = @SoLuong,
		 GiaNhap = @GiaNhap,		
		 GiaBanBuon = @GiaBanBuon,
		 GiaBanLe = @GiaBanLe
		WHERE MaGoiHang = @MaGoiHang
	 END
END
GO
-------------Xóa chi Tiết gói hàng ---------
IF OBJECT_ID(N'[dbo].sp_DeleteChiTietGoiHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_DeleteChiTietGoiHang
go
CREATE PROCEDURE sp_DeleteChiTietGoiHang
	@MaGoiHang varchar(50)
as
delete from ChiTietGoiHang where MaGoiHang = @MaGoiHang
go

-------BCChiTietHangHoa-----------
IF OBJECT_ID(N'[dbo].sp_BCChiTietHangHoa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_BCChiTietHangHoa
go
CREATE PROCEDURE sp_BCChiTietHangHoa
AS
BEGIN
SELECT  MaHangHoa,TenNhomHang,TenHangHoa,TenDonViTinh,GiaNhap,GiaBanBuon,GiaBanLe,MucDatHang,MucTonToiThieu
FROM HangHoa a join  NhomHang b
	on a.MaNhomHangHoa=b.MaNhomHang join DVT c
	on a.MaDonViTinh=c.MaDonViTinh
END
--------Select Thuế------------
GO
IF OBJECT_ID(N'[dbo].sp_SelectThue') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectThue
go
CREATE PROCEDURE sp_SelectThue
	AS
BEGIN
Select ThueID,MaThue,GiaTriThue,TenThue,GhiChu,Deleted
from Thue where Deleted=N'False'
END
GO
--------------Thuế-----------------------------------------------
IF OBJECT_ID(N'[dbo].sp_XuLy_Thue') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_Thue
go
CREATE PROCEDURE sp_XuLy_Thue
	@HanhDong nvarchar(20),
	@ThueID int,
	@MaThue varchar(20),
	@GiaTriThue float,
	@TenThue nvarchar(100),
	@GhiChu nvarchar(100),
	@Deleted bit
AS
	BEGIN
		IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO Thue
			(MaThue,GiaTriThue,TenThue,GhiChu,Deleted) 
		VALUES 
			(@MaThue,@GiaTriThue,@TenThue,@GhiChu,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE Thue
		 SET 
		 MaThue = @MaThue,
		 GiaTriThue = @GiaTriThue,
		 TenThue = @TenThue,
		 GhiChu=@GhiChu,
		 Deleted=@Deleted
		WHERE ThueID = @ThueID
	 END
	END
GO
--------------xóa------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_Thue') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_Thue
go
CREATE PROC sp_Xoa_Thue
	@HanhDong nvarchar(20),
	@ThueID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE Thue SET Deleted = N'True'
		WHERE ThueID = @ThueID
	 END
END
GO
------------------------------------------------------------------------------------------------------------------------
---Công Ty---------
IF OBJECT_ID(N'[dbo].sp_XuLy_CongTy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_CongTy
go
Create PROCEDURE sp_XuLy_CongTy
	@HanhDong nvarchar(20),
	@CongTyID INT  ,
	@MaCongTy VARCHAR(20) ,
	@TenCongTy nVARCHAR(200) ,
	@DiaChi nVARCHAR(200) ,
	@SoDienThoai nVARCHAR(20),
	@Email nVARCHAR(50),
	@Website nVARCHAR(50),
	@Fax nVARCHAR(20)
AS
BEGIN
	DECLARE @ERROR varchar(50)
	IF @HanhDong = N'Insert'
	BEGIN
		IF((select COUNT(CongTyID) from  CongTy)>=1)
		BEGIN
			Set @ERROR=N''
		END
		IF((select COUNT(CongTyID) from  CongTy)<=0)
		BEGIN
				INSERT INTO CongTy 
				(MaCongTy,TenCongTy,DiaChi,SoDienThoai,Email,Website,Fax)
				VALUES (@MaCongTy,@TenCongTy,@DiaChi,@SoDienThoai,@Email,@Website,@Fax)
				IF @@ERROR=0
				BEGIN
					Set @ERROR=N'YES'
				END
				ELSE
				BEGIN
					Set @ERROR=N'Lỗi chưa thể thêm công ty !'
				END
		END
	END
	IF @HanhDong = N'Update'
	BEGIN
		IF((select COUNT(CongTyID) from  CongTy)>=1)
		BEGIN
			 UPDATE CongTy
			 SET
				MaCongTy = @MaCongTy ,
				TenCongTy = @TenCongTy  ,
				DiaChi = @DiaChi ,
				SoDienThoai = @SoDienThoai ,
				Email = @Email ,
				Website = @Website ,
				Fax = @Fax  
			 WHERE CongTyID = @CongTyID
			    IF @@ERROR=0
				BEGIN
					Set @ERROR=N'YES'
				END
				ELSE
				BEGIN
					Set @ERROR=N'Lỗi chưa thể thêm công ty !'
				END
		END
		IF((select COUNT(CongTyID) from  CongTy)<1)
		BEGIN
			Set @ERROR=N'Không có bản ghi nào để sửa !'
		END
	 END
	 select @ERROR AS ThongBao
END
GO
------------SELECT CONG TY--------------
IF OBJECT_ID(N'[dbo].sp_SelectCongTy') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectCongTy
go
CREATE PROCEDURE sp_SelectCongTy
AS
BEGIN
	SELECT CongTyID,MaCongTy,TenCongTy,DiaChi,SoDienThoai,Email,Website,Fax
	FROM CongTy
 END
 GO
------------------------------------------------------------------------------------------------------------------------
--KhachHang
------------------------------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_XuLy_KhachHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_KhachHang
go
Create PROCEDURE sp_XuLy_KhachHang
	@HanhDong		nvarchar(20),
	@KhachHangID	int	,
	@MaKH			nvarchar(20),
	@Ten			nvarchar(200),
	@DiaChi			nvarchar(200),
	@DienThoai		nvarchar(20),
	@Fax			nvarchar(20),
	@Email			nvarchar(50),
	@MST			nvarchar(20),
	@DuNo			float,				
	@HanMucTT		float,	
	@CongTy 		nvarchar(200),
	@NgaySinh 		datetime,
	@MaVung 		int,
	@Mobi 			nvarchar(100),
	@Ngungtheodoi 	bit,
	@Website		varchar(200),	
	@GhiChu			nvarchar(200),
	@Deleted		bit
AS
BEGIN

	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO KhachHang 
			(MaKH,Ten,DiaChi,DienThoai,Fax,Email,MST,DuNo,HanMucTT,CongTy,NgaySinh,MaVung,Mobi,Ngungtheodoi,Website,GhiChu,Deleted) 
		VALUES 
			(@MaKH,@Ten,@DiaChi,@DienThoai,@Fax,@Email,@MST,@DuNo,@HanMucTT,@CongTy,@NgaySinh,@MaVung,@Mobi,@Ngungtheodoi,@Website,@GhiChu,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE KhachHang
		 SET
			MaKH = @MaKH,
			 Ten=@Ten,
			 DiaChi = @DiaChi,
			 DienThoai=@DienThoai,
			 Fax=@Fax,
			 Email=@Email,
			 MST=@MST,
			 DuNo=@DuNo,
			 HanMucTT=@HanMucTT,
			 CongTy=@CongTy,
			 NgaySinh=@NgaySinh,
			 MaVung=@MaVung,
			 Mobi=@Mobi,
			 Ngungtheodoi=@Ngungtheodoi,
			 Website=@Website,
			 GhiChu=@GhiChu,
			 Deleted = @Deleted
		WHERE KhachHangID = @KhachHangID
	 END
END
GO
------------------------------------------------------------------------------------------------------------------------
-- Xóa
------------------------------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_KhachHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_KhachHang
go
CREATE PROC sp_Xoa_KhachHang
	@HanhDong nvarchar(20),
	@KhachHangID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE KhachHang SET Deleted = N'True'
		WHERE KhachHangID = @KhachHangID
	 END
END
GO
------------------------------------------------------------------------------------------------------------------------
--Select toan bang
------------------------------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_SelectKhachHangsAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectKhachHangsAll
go
CREATE PROCEDURE sp_SelectKhachHangsAll
AS
BEGIN
	SELECT KhachHangID,MaKH,Ten,DiaChi,DienThoai,Fax,Email,MST,DuNo,HanMucTT,CongTy,NgaySinh,MaVung,Mobi,Ngaythamgia,Giaodichcuoi,Ngungtheodoi,Website,Ngaysua,GhiChu,Deleted
	FROM KhachHang WHERE Deleted=N'False'
END
GO
------------------------------------------------------------------------------------------------------------------------
--NhaCungCap
------------------------------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_XuLy_NhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuLy_NhaCungCap
go
CREATE PROCEDURE sp_XuLy_NhaCungCap
	@HanhDong		nvarchar(20),
	@NhaCungCapID	int	,
	@MaNhaCungCap	nvarchar(20),
	@TenNhaCungCap	nvarchar(200),
	@DiaChi			nvarchar(200),
	@DienThoai		nvarchar(20),
	@Email			nvarchar(50),
	@Fax			nvarchar(20),
	@NguoiLienHe	nvarchar(200),
	@MST			nvarchar(20),				
	@DuNo			float,	
	@Website		varchar(200),				
	@GhiChu			nvarchar(100),
	@Deleted		bit
AS
BEGIN
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO NhaCungCap 
			(MaNhaCungCap,TenNhaCungCap,DiaChi,DienThoai,Email,Fax,NguoiLienHe,MST,DuNo,Website,GhiChu,Deleted) 
		VALUES 
			(@MaNhaCungCap,@TenNhaCungCap,@DiaChi,@DienThoai,@Email,@Fax,@NguoiLienHe,@MST,@DuNo,@Website,@GhiChu,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE NhaCungCap
		 SET 
			MaNhaCungCap = @MaNhaCungCap,
			 TenNhaCungCap=@TenNhaCungCap,
			 DiaChi = @DiaChi,
			 DienThoai=@DienThoai,			
			 Email=@Email,
			 Fax=@Fax,
			 NguoiLienHe=@NguoiLienHe,
			 MST=@MST,
			 DuNo=@DuNo,
			 Website=@Website,
			 GhiChu=@GhiChu,
			 Deleted = @Deleted
		WHERE NhaCungCapID = @NhaCungCapID
	 END
END
GO
------------------------------------------------------------------------------------------------------------------------
-- Xóa
------------------------------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_NhaCungCap') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_NhaCungCap
go
CREATE PROC sp_Xoa_NhaCungCap
	@HanhDong nvarchar(20),
	@NhaCungCapID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		UPDATE NhaCungCap SET Deleted = N'True'
		WHERE NhaCungCapID = @NhaCungCapID
	 END
END
GO
------------------------------------------------------------------------------------------------------------------------
--Select toan bang
------------------------------------------------------------------------------------------------------------------------
GO
IF OBJECT_ID(N'[dbo].sp_SelectNhaCungCapsAll') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectNhaCungCapsAll
go
CREATE PROCEDURE sp_SelectNhaCungCapsAll
AS
BEGIN
	SELECT NhaCungCapID,MaNhaCungCap,TenNhaCungCap,DiaChi,DienThoai,Email,Fax,NguoiLienHe,MST,DuNo,Website,GhiChu,Deleted
	FROM NhaCungCap WHERE Deleted=N'False'
END
GO
---------------
IF OBJECT_ID(N'[dbo].sp_DonHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_DonHang
go
create proc sp_DonHang
	@MaKhachHang nvarchar(20)
as
begin
IF @MaKhachHang !=N''
	BEGIN
	select b.MaKhachHang,a.MaDonDatHang,NgayDonHang,a.HinhThucThanhToan,a.GhiChu,TongTienThanhToan
	from DonDatHang a join  HDBanHang b
	on a.MaDonDatHang=b.MaDonDatHang join KhachHang c
	on b.MaKhachHang=c.MaKH
	where b.MaKhachHang=@MaKhachHang
	select MaDonDatHang from DonDatHang where LoaiDonDatHang='False' and TrangThaiDonDatHang='Đã thành công'
end
ELSE
	BEGIN
		Select b.MaKhachHang,a.MaDonDatHang,NgayDonHang,a.HinhThucThanhToan,a.GhiChu,TongTienThanhToan From DonDatHang a join HDBanHang b
		on a.MaDonDatHang=b.MaDonDatHang
	END
END
go
IF OBJECT_ID(N'[dbo].sp_XuatHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_XuatHang
go
create proc sp_XuatHang
	@MaKhachHang nvarchar(20)
as
begin
IF @MaKhachHang !=N''
	BEGIN
	select MaKhachHang,MaHDBanHang,NgayBan,HinhThucThanhToan,GhiChu,TongTienThanhToan
	from HDBanHang where MaKhachHang=@MaKhachHang
end
ELSE
	BEGIN
		Select MaKhachHang,MaHDBanHang,NgayBan,HinhThucThanhToan,GhiChu,TongTienThanhToan from HDBanHang
	END
END
go
IF OBJECT_ID(N'[dbo].sp_TraLai') IS NOT NULL
 DROP PROCEDURE [dbo].sp_TraLai
go
create proc sp_TraLai
	@MaKhachHang nvarchar(20)
as
begin
IF @MaKhachHang !=N''
	BEGIN
select  MaKhachHang,MaKhachHangTraLai,NgayNhap,HinhThucThanhToan,GhiChu,ThanhToanNgay
from KhachHangTraLai where MaKhachHang=@MaKhachHang
	end
ELSE
	BEGIN
		Select  MaKhachHang,MaKhachHangTraLai,NgayNhap,HinhThucThanhToan,GhiChu,ThanhToanNgay From KhachHangTraLai
	END
END
go
IF OBJECT_ID(N'[dbo].sp_ThanhToan') IS NOT NULL
 DROP PROCEDURE [dbo].sp_ThanhToan
go
create proc sp_ThanhToan
@MaKhachHang nvarchar(20)
as
begin
IF @MaKhachHang !=N''
	BEGIN
select MaKhachHang,a.MaPhieuTTCuaKH,NgayLap,TrangThai,a.GhiChu,ThanhToan
from 	dbo.ChiTietPhieuTTCuaKH a join dbo.PhieuTTCuaKH b
on a.MaPhieuTTCuaKH=b.MaPhieuTTCuaKH where MaKhachHang=@MaKhachHang
end

	BEGIN
		Select MaKhachHang,a.MaPhieuTTCuaKH,NgayLap,TrangThai,a.GhiChu,ThanhToan From PhieuTTCuaKH a join ChiTietPhieuTTCuaKH b
		on a.MaPhieuTTCuaKH=b.MaPhieuTTCuaKH
	END
END
go
IF OBJECT_ID(N'[dbo].sp_HangHoa') IS NOT NULL
 DROP PROCEDURE [dbo].sp_HangHoa
go
create proc sp_HangHoa
	@MaKhachHang nvarchar(20)
as
begin
IF @MaKhachHang !=N''
	BEGIN
select MaKhachHang,a.MaHangHoa,a.TenHangHoa,MaDonViTinh,SoLuong,ThueGTGT,TongTienThanhToan
from dbo.HangHoa a join dbo.ChiTietHDBanHang b
on a.MaHangHoa=b.MaHangHoa join dbo.HDBanHang c
on b.MaHDBanHang=c.MaHDBanHang where MaKhachHang=@MaKhachHang
end
	ELSE
	BEGIN
		Select MaKhachHang,a.MaHangHoa,a.TenHangHoa,MaDonViTinh,SoLuong,ThueGTGT,TongTienThanhToan
		from HangHoa a join ChiTietHDBanHang b
		on a.MaHangHoa=b.MaHangHoa join dbo.HDBanHang c
		on b.MaHDBanHang=c.MaHDBanHang 
	END
END
go

-------------NCC
IF OBJECT_ID(N'[dbo].sp_HangHoaNCC') IS NOT NULL
 DROP PROCEDURE [dbo].sp_HangHoaNCC
go
create proc sp_HangHoaNCC
	@MaNhaCungCap nvarchar(20)
as
begin
IF @MaNhaCungCap !=N''
	BEGIN
select MaNhaCungCap,a.MaHangHoa,a.TenHangHoa,MaDonViTinh,SoLuong,ThueGTGT,TongTien
from dbo.HangHoa a join dbo.ChiTietHoaDonNhap b
on a.MaHangHoa=b.MaHangHoa join dbo.HoaDonNhap c
on b.MaHoaDonNhap=c.MaHoaDonNhap where MaNhaCungCap=@MaNhaCungCap
end
	ELSE
	BEGIN
		Select MaNhaCungCap,a.MaHangHoa,a.TenHangHoa,MaDonViTinh,SoLuong,ThueGTGT,TongTien
		from  dbo.HangHoa a join dbo.ChiTietHoaDonNhap b
on a.MaHangHoa=b.MaHangHoa join dbo.HoaDonNhap c
on b.MaHoaDonNhap=c.MaHoaDonNhap
	END
END
go
IF OBJECT_ID(N'[dbo].sp_DonHangNCC') IS NOT NULL
 DROP PROCEDURE [dbo].sp_DonHangNCC
go
create proc sp_DonHangNCC
	@MaNhaCungCap nvarchar(20)
as
begin
	if @MaNhaCungCap != N''
	begin
		select a.MaDonDatHang,a.MaNhaCungCap, a.NgayDonHang,a.TrangThaiDonDatHang,a.HinhThucThanhToan,b.TongTien
		from DonDatHang a join HoaDonNhap b on a.MaDonDatHang = b.MaDonDatHang
		 where a.MaNhaCungCap=@MaNhaCungCap and a.LoaiDonDatHang=N'True' and a.TrangThaiDonDatHang=N'Đã thành công'
	end
	ELSE
		BEGIN
			Select a.MaDonDatHang,a.MaNhaCungCap,NgayDonHang,TrangThaiDonDatHang,a.HinhThucThanhToan,TongTien From DonDatHang a join HoaDonNhap b
			on a.MaDonDatHang=b.MaDonDatHang
		END
END
go
IF OBJECT_ID(N'[dbo].sp_NhapMua') IS NOT NULL
 DROP PROCEDURE [dbo].sp_NhapMua
go
create proc sp_NhapMua
@MaNhaCungCap nvarchar(20)
as
begin
if @MaNhaCungCap != N''
	begin
	select MaNhaCungCap,MaHoaDonNhap,NgayNhap,HinhThucThanhToan,GhiChu,TongTien
	from HoaDonNhap where MaNhaCungCap=@MaNhaCungCap
end
	BEGIN
			Select MaNhaCungCap, MaHoaDonNhap,NgayNhap,HinhThucThanhToan,GhiChu,TongTien from HoaDonNhap
		END
END
 go
IF OBJECT_ID(N'[dbo].sp_TraLaiNCC') IS NOT NULL
 DROP PROCEDURE [dbo].sp_TraLaiNCC
go
create proc sp_TraLaiNCC
@MaNCC nvarchar(20)
as
begin
if @MaNCC != N''
	begin
	select MaNCC,MaHDTraLaiNCC,Ngaytra,HinhThucThanhToan,GhiChu,ThanhToanNgay
	from TraLaiNCC where MaNCC=@MaNCC
end
BEGIN
		Select MaNCC,MaHDTraLaiNCC,Ngaytra,HinhThucThanhToan,GhiChu,ThanhToanNgay from TraLaiNCC
		END
END
go
IF OBJECT_ID(N'[dbo].sp_ThanhToanNCC') IS NOT NULL
 DROP PROCEDURE [dbo].sp_ThanhToanNCC
go
create proc sp_ThanhToanNCC
@MaNCC nvarchar(20)
as
begin
IF @MaNCC !=N''
	BEGIN
select MaNCC,a.MaPhieuTTNCC,NgayLap,TrangThai,a.GhiChu,ThanhToan
from 	dbo.PhieuTTNCC a join dbo.ChiTietPhieuTTNCC b
on a.MaPhieuTTNCC=b.MaPhieuTTNCC where MaNCC=@MaNCC
end
ELSE
	BEGIN
		Select MaNCC,a.MaPhieuTTNCC,NgayLap,TrangThai,a.GhiChu,ThanhToan From dbo.PhieuTTNCC a join dbo.ChiTietPhieuTTNCC b
on a.MaPhieuTTNCC=b.MaPhieuTTNCC
	END
END
go
IF OBJECT_ID(N'[dbo].sp_InsertCapNhatGiaKhacHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_InsertCapNhatGiaKhacHang
go
create proc sp_InsertCapNhatGiaKhacHang
	@HanhDong nvarchar(20),
	@CapNhatGiaKhachHangID int,
	@MaCapNhatGiaKhachHang varchar(20),
	@MaHangHoa varchar(50),
	@MaKhachHang nvarchar(20),
	@NgayBatDau datetime,
	@NgayKetThuc datetime,
	@PhanTramChietKhau float,
	@Deleted bit
as
begin
	IF @HanhDong = N'Insert'
	BEGIN
		INSERT INTO  CapNhatGiaKhachHang
			(MaCapNhatGiaKhachHang,MaHangHoa,MaKhachHang,NgayBatDau,NgayKetThuc,PhanTramChietKhau,Deleted) 
		VALUES 
			(@MaCapNhatGiaKhachHang,@MaHangHoa,@MaKhachHang,@NgayBatDau,@NgayKetThuc,@PhanTramChietKhau,@Deleted)
	 END
	 IF @HanhDong = N'Update'
	 BEGIN
		 UPDATE CapNhatGiaKhachHang
		 SET 
			MaCapNhatGiaKhachHang = @MaCapNhatGiaKhachHang,
			MaHangHoa = @MaHangHoa,
			MaKhachHang  = @MaKhachHang,
			NgayBatDau = @NgayBatDau,
			NgayKetThuc = @NgayKetThuc,
			PhanTramChietKhau = @PhanTramChietKhau,
			Deleted = @Deleted
		WHERE CapNhatGiaKhachHangID=@CapNhatGiaKhachHangID
	 END
end
GO
IF OBJECT_ID(N'[dbo].sp_Xoa_CapNhatGiaKhachHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_Xoa_CapNhatGiaKhachHang
go
Create PROC sp_Xoa_CapNhatGiaKhachHang
	@HanhDong nvarchar(20),
	@CapNhatGiaKhachHangID int
AS
BEGIN
	 IF @HanhDong = N'Delete'
	 BEGIN
		Delete CapNhatGiaKhachHang 
		WHERE CapNhatGiaKhachHangID = @CapNhatGiaKhachHangID
	 END
END
GO
IF OBJECT_ID(N'[dbo].sp_SelectCapNhatGiaKhachHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_SelectCapNhatGiaKhachHang
go
create proc sp_SelectCapNhatGiaKhachHang
	@MaKhachHang nvarchar(20)
as
begin
IF @MaKhachHang !=N''
	select * from CapNhatGiaKhachHang where MaKhachHang=@MaKhachHang
end
go
IF OBJECT_ID(N'[dbo].sp_BaoCaoNhapHangTheoNhomHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_BaoCaoNhapHangTheoNhomHang
go
create proc sp_BaoCaoNhapHangTheoNhomHang
as
begin
select * from dbo.NhomHang join dbo.HangHoa on dbo.NhomHang.MaNhomHang=dbo.HangHoa.MaNhomHangHoa
 join dbo.ChiTietHoaDonNhap 
	on dbo.HangHoa.MaHangHoa=dbo.ChiTietHoaDonNhap.MaHangHoa join dbo.HoaDonNhap 
	on dbo.ChiTietHoaDonNhap.MaHoaDonNhap=dbo.HoaDonNhap.MaHoaDonNhap join dbo.KhoHang 
	on dbo.HoaDonNhap.MaKho=KhoHang.MaKho join dbo.ChiTietKhoHang 
	on HoaDonNhap.MaKho=ChiTietKhoHang.MaKho where dbo.NhomHang.Deleted=0 and dbo.HangHoa.Deleted=0
	--select MaNhomHang,TenKho,b.TenHangHoa,d.NgayNhap,c.SoLuong,TongTien
	--from 	dbo.NhomHang a join dbo.HangHoa b
	--on a.MaNhomHang=b.MaNhomHangHoa join dbo.ChiTietHoaDonNhap c
	--on b.MaHangHoa=c.MaHangHoa join dbo.HoaDonNhap d
	--on c.MaHoaDonNhap=d.MaHoaDonNhap join dbo.KhoHang e
	--on d.MaKho=e.MaKho join dbo.ChiTietKhoHang f
	--on d.MaKho=f.MaKho
end
go
IF OBJECT_ID(N'[dbo].sp_BaoCaoNhapHangTheoMatHang') IS NOT NULL
 DROP PROCEDURE [dbo].sp_BaoCaoNhapHangTheoMatHang
go
create proc sp_BaoCaoNhapHangTheoMatHang
as
begin
select * from  dbo.KhoHang  join  dbo.HoaDonNhap 
	on dbo.KhoHang.MaKho=dbo.HoaDonNhap.MaKho join dbo.ChiTietHoaDonNhap 
	on dbo.HoaDonNhap.MaHoaDonNhap=dbo.ChiTietHoaDonNhap.MaHoaDonNhap join dbo.HangHoa 
	on dbo.ChiTietHoaDonNhap.MaHangHoa=dbo.HangHoa.MaHangHoa join dbo.ChiTietKhoHang 
	on dbo.KhoHang.MaKho=dbo.ChiTietKhoHang.MaKho where dbo.KhoHang.Deleted=0 and dbo.KhoHang.Deleted=0

end

--========================= 10 ============================




