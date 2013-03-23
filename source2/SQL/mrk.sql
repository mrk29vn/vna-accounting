use SupermarketManagementDHT
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
-- 23/03/2013
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