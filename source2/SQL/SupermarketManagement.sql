USE master
 IF EXISTS (SELECT * FROM sysdatabases WHERE name = 'SupermarketManagementDHT')
 DROP DATABASE SupermarketManagementDHT
GO
---create database
create database SupermarketManagementDHT
go
use SupermarketManagementDHT

--                          Khuyen mai theo so luong
go
create table KhuyenMaiSoLuong
(
	Id int identity primary key,
	MaHangHoa varchar(50) not null,
	TenHangHoa nvarchar(200) not null,
	NgayBatDau datetime,
	NgayKetThuc datetime,
	SoLuong float,
	GiaBanBuon float,
	GiaBanLe float
)

--								Thẻ giảm giá
GO
create table TheGiamGia
(
	TheGiamGiaID int identity primary key,
	MaTheGiamGia varchar(50) not null,
	MaKhachHang varchar(50) not null,
	GiaTriThe float not null,
	GiaTriConLai float not null,
	NgayBatDau datetime,
	NgayKetThuc datetime,
	Deleted bit
)
go
--								Quy đổi đơn vị tính
create table QuyDoiDonViTinh
(
	QuyDoiDonViTinhID int identity primary key,
	MaQuyDoiDonViTinh varchar(50) not null,
	MaHangQuyDoi nvarchar(50) not null,
	TenHangQuyDoi nvarchar(200) not null,
	MaDonViTinh nvarchar(50) not null,
	SoLuongQuyDoi int not null,
	MaHangDuocQuyDoi nvarchar(50) not null,
	TenHangDuocQuyDoi nvarchar(200) not null,
	MaDonViTinhDuocQuyDoi nvarchar(50) not null,
	SoLuongDuocQuyDoi int not null,
	Deleted bit
)
go

create table GoiHang
(
	GoiHangID	int		identity	primary key,
	MaKho	VARCHAR(20),
	MaGoiHang	varchar (50) not null,
	TenGoiHang	nvarchar	(200),
	MaNhomHang varchar(50),
	TenNhomHang nvarchar(200),
	GiaNhap float,
	GiaBanBuon float,
	GiaBanLe float,
	Deleted bit
)
go
create table ChiTietGoiHang
(
	ChiTietGoiHangID	int	identity(1,1)primary key,
	MaGoiHang	varchar (50) not null,
	MaHangHoa	varchar(50) not null,
	TenHangHoa	nvarchar(200),
	SoLuong	float,
	GiaNhap float,
	GiaBanBuon float,
	GiaBanLe float,
)
go
CREATE TABLE LoaiHang
(
	LoaiHangID	INT PRIMARY KEY identity(1,1) not null,
	MaLoaiHang	VARCHAR(20) not null unique,
	TenLoaiHang	nVARCHAR(200) not null,
	GhiChu	nVARCHAR(250),
	Deleted	BIT
	
)
GO
CREATE TABLE NhomHang
(
	NhomHangID	INT PRIMARY KEY identity(1,1)Not Null,
	MaNhomHang	nVARCHAR(20)	Not Null unique,
	MaLoaiHang VARCHAR(20),
	TenNhomHang	nVARCHAR(200)	Not Null,
	GhiChu	nVARCHAR(250)	,
	Deleted	BIT	
)
GO

CREATE TABLE Thue
(
	ThueID	INT PRIMARY KEY	Not Null identity(1,1),
	MaThue	VARCHAR(20)	Not Null unique,
	GiaTriThue	FLOAT	Not Null,
	TenThue	nVARCHAR(100),
	GhiChu	nVARCHAR(100),
	Deleted	BIT,
)
GO
CREATE TABLE NhaSX
(
	NhaSXID	INT	Not Null	PRIMARY KEY	identity(1,1),
	MaNhaSX	nVARCHAR(20)	Not Null unique,
	TenNhaSX	nVARCHAR(200)	Not Null,
	TenLH	nVARCHAR(200),
	DiaChi	nVARCHAR(200),
	DienThoai	VARCHAR(20),
	Fax	VARCHAR	(20),
	Email	VARCHAR	(50),
	WebSite	VARCHAR(50),
	GhiChu	nVARCHAR(200),
	Deleted	BIT	DEFAULT 0
)
GO
CREATE TABLE DVT
(
	DVTID	INT	Not Null PRIMARY KEY identity(1,1),	
	MaDonViTinh	VARCHAR(20)	Not Null unique,
	TenDonViTinh	nVARCHAR(200),
	GhiChu	nVARCHAR(100),
	Deleted	BIT	DEFAULT 0
)
GO
CREATE TABLE HangHoa
(
	HangHoaID	INT	Not Null PRIMARY KEY identity(1,1),
	MaHangHoa	VARCHAR(50)	Not Null unique,
	MaNhomHangHoa	nVARCHAR(20), 
	TenHangHoa	nVARCHAR(200),
	MaNhaSanXuat	nVARCHAR	(20),
	MaVachNhaSanXuat	VARCHAR(20),
	MaDonViTinh	VARCHAR(20),
	GiaNhap	FLOAT,				
	GiaBanBuon	FLOAT,
	GiaBanLe	FLOAT,				
	MaThueGiaTriGiaTang	VARCHAR	(20),
	KieuHangHoa	nVARCHAR(200),
	SeriLo	nVARCHAR(200),
	MucDatHang	INT	,		
	MucTonToiThieu	INT	,
	GhiChu	nVARCHAR(100),
	Deleted	BIT DEFAULT 0
)
GO
CREATE TABLE CapNhatGia
(
	CapNhatGiaID	INT	Not Null PRIMARY KEY	identity(1,1)	,
	MaCapNhatGia	VARCHAR(20)	Not Null unique,
	NgayBatDau	DATETIME	Not Null,
	NgayKetThuc	DATETIME	Not Null,
	MaHangHoa	VARCHAR(50),		
	PhanTramGiaBanBuon	FLOAT,
	PhanTramGiaBanLe	FLOAT,
	GiaNhap	FLOAT,
	Trangthai	BIT,				
	GhiChu	nVARCHAR(200),
	Deleted	BIT	DEFAULT 0	
)
GO

CREATE TABLE KhachHang
(
	KhachHangID	INT	Not Null PRIMARY KEY identity(1,1),	
	MaKH	nVARCHAR(20)	Not Null unique,
	Ten	nVARCHAR(200)	Not Null,
	DiaChi	nVARCHAR(200),
	DienThoai	nVARCHAR(20),
	Fax	nVARCHAR(20),
	Email	nVARCHAR(50),
	MST	nVARCHAR(20),
	DuNo	FLOAT,				
	HanMucTT	FLOAT,	
	CongTy 	nVARCHAR(200),
	NgaySinh DATETIME,
	MaVung 	INT,
	Mobi nVARCHAR(100),
	NgayThamGia DATETIME,
	GiaoDichCuoi DATETIME,
	NgungTheoDoi 	BIT,
	Website	VARCHAR(200),
	NgaySua DATETIME,		
	GhiChu	nVARCHAR(200),
	Deleted	BIT	DEFAULT 0
)
GO
CREATE TABLE NhaCungCap
(
	NhaCungCapID	INT	Not Null PRIMARY KEY identity(1,1),		
	MaNhaCungCap	nVARCHAR(20)	Not Null unique,
	TenNhaCungCap	nVARCHAR(200)	Not Null,
	DiaChi	nVARCHAR(200),
	DienThoai	nVARCHAR(20),
	Email	nVARCHAR(50),
	Fax	nVARCHAR(20),
	NguoiLienHe	nVARCHAR(200),
	MST	nVARCHAR(20),
	DuNo	FLOAT,
	Website VARCHAR(200),
	GhiChu	nVARCHAR(100),				
	Deleted	BIT	DEFAULT 0
)
GO
CREATE TABLE NhomTKKeToan
(
	NhomTKKeToanID INT identity(1,1) PRIMARY KEY,
	MaNhomTKKeToan VARCHAR(20) unique,
	TenNhomTKKeToan nVARCHAR(200),
	GhiChu nVARCHAR(100),
	Deleted BIT DEFAULT 0
)
GO
CREATE TABLE PhongBan
(
	PhongBanID	INT	Not Null PRIMARY KEY identity(1,1),
	MaPhongBan	VARCHAR(20)	Not Null unique,
	TenPhongBan	nVARCHAR(200)	Not Null,
	GhiChu	nVARCHAR(100),
	Deleted	BIT DEFAULT	0
)
GO
CREATE TABLE NhanVien
(
	NhanVienID	INT	Not Null PRIMARY KEY identity(1,1),		
	MaNhanVien	nVARCHAR(20)	Not Null unique,
	TenNhanVien	nVARCHAR(200)	Not Null,	
	MaPhongBan	VARCHAR(20)	Not Null,
	DCThuongTru	nVARCHAR(200),
	DCTamTru	nVARCHAR(200),
	DienThoaiCD	nVARCHAR(20),
	DienThoaiDD	VARCHAR(20),
	Email	nVARCHAR(50),
	CMND	nVARCHAR(20)	Not Null,
	NgayCap	DATETIME,	
	NoiCap	nVARCHAR(100),				
	NgaySinh	DATETIME,				
	GhiChu	nVARCHAR(100),				
	Deleted	BIT	DEFAULT 0	
)
GO
CREATE TABLE KhoHang
(
	KhoHangID	INT	Not Null PRIMARY KEY identity(1,1),
	MaKho	VARCHAR(20)	Not Null unique,
	TenKho	nVARCHAR(200)	Not Null,
	DiaChi	nVARCHAR(200),
	DienThoai	nVARCHAR(20),
	MaNhanVien nVARCHAR(20),
	GhiChu	nVARCHAR(200),
	Deleted	BIT	
)
CREATE TABLE ChiTietKhoHang
(
	MaKho	VARCHAR(20),
	MaHangHoa	VARCHAR(50),
	SoLuong	INT,	
	NgayNhap	DATETIME,
	HanSuDung	datetime,			
	GhiChu	nVARCHAR(200),
	Deleted BIT	DEFAULT 0
)


GO

CREATE TABLE TKKeToan
(
	TKKeToanID	INT	Not Null PRIMARY KEY identity(1,1),		
	MaTKKeToan	VARCHAR(20)	Not Null unique,
	MaNhomTKKeToan VARCHAR(20),
	TenTaiKhoan	nVARCHAR(200)	Not Null,
	GhiChu	nVARCHAR(100),
	Deleted	BIT DEFAULT	0	
)
GO
CREATE TABLE TienTe
(
	TienteID	INT	Not Null PRIMARY KEY identity(1,1),
	MaTienTe	VARCHAR(20)	Not Null unique,
	TenTienTe	nVARCHAR(200)	Not Null,
	TenTienTeChan	nVARCHAR(200),
	TenTienTeLe	nVARCHAR(200),
	BieuTuong	VARCHAR(10),
	DonViLamTron	INT	,			
	GhiChu	nVARCHAR(100),
	Deleted	BIT	DEFAULT 0	
)
GO
----------------------------------hungvv--------------------------------------------------------------
GO
CREATE TABLE DonDatHang
(
	DonDatHangID                    INT	Not Null PRIMARY KEY identity(1,1),
	MaDonDatHang	                VARCHAR(20)	Not Null unique,
	LoaiDonDatHang                  BIT,
	NgayDonHang	                    DATETIME,	
	MaNhaCungCap                    nVARCHAR(20),
	NoHienThoi	                    FLOAT,	
	TrangThaiDonDatHang	            nVARCHAR(20),
	NgayNhapDuKien	                DATETIME,
	HinhThucThanhToan	            nVARCHAR(20),
	MaKho	                        VARCHAR(20),
	MaNhanVien	                    nVARCHAR(20),
	MaTienTe	                    VARCHAR(20),
	ThueGTGT	                    FLOAT,
	Phivanchuyen	                FLOAT,
	PhiKhac	                        FLOAT,		
	GhiChu	                        nVARCHAR(100),
	Deleted	                        BIT	DEFAULT 0,
	MaKhachHang						nvarchar(20)
)
GO
----------------------------------hungvv--------------------------------------------------------------
GO
CREATE TABLE ChiTietDonHang
(
	MaDonDatHang	VARCHAR(20),
	MaHangHoa	VARCHAR(50) not null,
	TenHangHoa nvarchar(200),
	SoLuong	INT	Not Null,
	DonGia float,
	Thue float,
	PhanTramChietKhau	FLOAT,	
	GhiChu	nVARCHAR(100),		
	Deleted	BIT DEFAULT 0	
)
GO
CREATE TABLE HDBanHang
(
	HDBanHangID	INT	Not Null PRIMARY KEY identity(1,1),
	MaHDBanHang	VARCHAR(20)	Not Null unique,
	NgayBan	DATETIME,				
	MaKhachHang	nVARCHAR(20),
	NoHienThoi	FLOAT,				
	NguoiNhanHang	nVARCHAR(200),
	HinhThucThanhToan	nVARCHAR(200),
	MaKho	VARCHAR(20),
	HanThanhToam	DATETIME,	
	MaDonDatHang VARCHAR(20),
	MaNhanVien	nVARCHAR(20),
	MaTienTe	VARCHAR(20),
	ChietKhau	FLOAT,
	ThanhToanNgay	FLOAT,		
	ThanhToanKhiLapPhieu Float,		
	ThueGTGT	FLOAT,			
	TongTienThanhToan	FLOAT,
	LoaiHoaDon	BIT	,	
	MaThe varchar(20),
	GiaTriThe float,
	GhiChu	nVARCHAR(100),				
	Deleted	BIT DEFAULT 0,
	KhachTra float,
	ChietKhauTongHoaDon float,
	MaTheGiaTri varchar(20),
	GiaTriTheGiaTri float,
)
----------------------------------hungvv--------------------------------------------------------------
GO
CREATE TABLE KhachHangTraLai
(
	KhachHangTraLaiID	                     INT	Not Null PRIMARY KEY identity(1,1),		
	MaKhachHangTraLai	                     VARCHAR(20)	Not Null unique,
	NgayNhap	                             DATETIME,		
	MaKhachHang	                             nVARCHAR(20),
	NoHienThoi	                             FLOAT,
	NguoiTra	                             nVARCHAR(200),
	HinhThucThanhToan	                     nVARCHAR(200),
	HanThanhToan	                         DATETIME,				
	MaHoaDonMuaHang	                         VARCHAR(20),
	MaKho	                                 VARCHAR(20),
	MaTienTe	                             VARCHAR(20),
	TienBoiThuong	                         FLOAT,				
	ThanhToanNgay	                         FLOAT,				
	ThueGTGT	                             FLOAT,			
	GhiChu	                                 nVARCHAR(100),				
	Deleted	                                 BIT DEFAULT 0	
)
GO
----------------------------------hungvv--------------------------------------------------------------
GO
CREATE TABLE ChiTietKhachHangTraLai
(
	MaKhachHangTraLai	                     VARCHAR(20),
	MaHangHoa	                             VARCHAR(50),
	TenHangHoa								nvarchar(200),	
	SoLuong	                                 int	Not Null,			
	PhanTramChietKhau	                     FLOAT,	
	DonGia float,
	Thue float,			
	GhiChu	                                 nVARCHAR(100),				
	Deleted	                                 BIT	DEFAULT 0
)
GO
----------------------------------hungvv--------------------------------------------------------------
GO
CREATE TABLE HoaDonNhap
(
	HoaDonNhapID	                        INT	Not Null PRIMARY KEY identity(1,1),
	MaHoaDonNhap	                        VARCHAR(20)	Not Null unique,
	NgayNhap	                            DATETIME,				
	MaNhaCungCap	                        nVARCHAR(20),
	NoHienThoi	                            FLOAT,
	NguoiGiaoHang	                        nVARCHAR(200),
	HinhThucThanhToan	                    nVARCHAR(200),
	MaKho	                                VARCHAR(20),
	HanThanhToan	                        DATETIME,		
	MaDonDatHang	                        VARCHAR(20),
	MaTienTe	                            VARCHAR(20),
	ChietKhau	                            FLOAT,
	ThanhToanNgay	                        FLOAT,
	ThueGTGT	                            FLOAT,			
	TongTien	                            FLOAT,				
	GhiChu	                                nVARCHAR(100),				
	Deleted	                                BIT DEFAULT 0,
	ThanhToanSauKhiLapPhieu	                FLOAT	
)
GO
----------------------------------hungvv--------------------------------------------------------------
GO
CREATE TABLE ChiTietHoaDonNhap
(
	MaHoaDonNhap	                        VARCHAR(20),
	MaHangHoa	                            VARCHAR(50),
	SoLuong	                                INT	Not Null,			
	PhanTramChietKhau	                    FLOAT,		
	DonGia									Float,
	Thue									Float,		
	GhiChu	                                nVARCHAR(100),				
	Deleted	                                BIT DEFAULT 0
)
GO
CREATE TABLE KMThuChi
(
	ThuChiID	INT	Not Null PRIMARY KEY identity(1,1),
	MaKhoanMuc	VARCHAR(20)	Not Null unique,
	TenKhoanMuc	nVARCHAR(200),
	LoaiKM	BIT	,			
	DoiTuong	nVARCHAR(200),
	NoTK	VARCHAR(20) ,
	CoTK	VARCHAR(20) ,
	GhiChu	nVARCHAR(100),
	Deleted	BIT	DEFAULT 0
)
GO
CREATE TABLE ChiTietHDBanHang
(
	MaHDBanHang	VARCHAR(20),
	MaHangHoa	VARCHAR(50),
	TenHangHoa nvarchar(200),
	SoLuong	INT	Not Null,
	DonGia float,
	Thue float,
	PhanTramChietKhau	FLOAT,
	GhiChu	nVARCHAR(100),
	Deleted	BIT	DEFAULT 0	
)
GO
----------------------------------hungvv--------------------------------------------------------------
GO
CREATE TABLE TraLaiNCC
(
	TraLaiNCCID	                    INT	Not Null PRIMARY KEY identity(1,1),
	MaHDTraLaiNCC	                VARCHAR(20)	Not Null unique,
	Ngaytra	                        DATETIME,	
	MaNCC	                        nVARCHAR(20),
	NoHienThoi	                    FLOAT,
	NguoiNhanHang	                nVARCHAR(200),
	HinhThucThanhToan	            nVARCHAR(200),
	MaHoaDonNhap	                VARCHAR	(20),
	MaKho	                        VARCHAR	(20),
	MaTienTe	                    VARCHAR(20),
	TienBoiThuong	                FLOAT,
	ThanhToanNgay	                FLOAT,				
	ThueGTGT	                    FLOAT,			
	GhiChu	                        nVARCHAR(100),				
	Deleted	                        BIT DEFAULT 0
)
GO
----------------------------------hungvv--------------------------------------------------------------
GO
CREATE TABLE ChiTietTraLaiNCC
(
	MaHDTraLaiNCC	                VARCHAR(20),
	MaHangHoa	                VARCHAR(50),
	SoLuong	                        INT	Not Null,
	DonGia						FLOAT,
	Thue						Float,
	PhanTramChietKhau	        FLOAT,
	GhiChu	                        nVARCHAR(100),
	Deleted	                        BIT DEFAULT 0
)
GO
CREATE TABLE PhieuDieuChuyenKho
(
	PhieuDieuChuyenKhoID	INT	Not Null PRIMARY KEY identity(1,1),
	MaPhieuDieuChuyenKho	VARCHAR(20)	Not Null unique,
	NgayDieuChuyen	DATETIME,		
	TuKho	VARCHAR(20),
	DenKho	VARCHAR(20),
	MaHoaDonNhap VARCHAR(20),
	XacNhan	BIT,
	GhiChu	nVARCHAR(100),
	Deleted	BIT	DEFAULT 0	
)
GO
CREATE TABLE ChiTietPhieuDieuChuyenKho
(
	MaPhieuDieuChuyenKho	VARCHAR(20),
	MaHangHoa	VARCHAR(50),
	SoLuong	INT	Not Null,
	GhiChu	nVARCHAR(100),
	Deleted	BIT DEFAULT 0	
)
GO

CREATE TABLE CapNhatGiaKhachHang
(
	CapNhatGiaKhachHangID INT identity PRIMARY KEY,
	MaCapNhatGiaKhachHang VARCHAR(20) unique,
	MaHangHoa VARCHAR(50),
	MaKhachHang nVARCHAR(20),
	NgayBatDau DATETIME,
	NgayKetThuc DATETIME,
	PhanTramChietKhau FLOAT,
	Deleted BIT
)
GO
CREATE TABLE UpdateGiaHangHoa
(
	UpdateGiaHangHoaID INT identity PRIMARY KEY,
	MaUpdateGiaHangHoa VARCHAR(20) unique,
	MaHangHoa VARCHAR(50),
	GiaBanBuonCu FLOAT,
	GiaBanBuonMoi FLOAT,
	GiaBanLeCu FLOAT,
	GiaBanLeMoi FLOAT,
	NgayThayDoi DATETIME
)

----------------------------------hungvv--------------------------------------------------------------
GO
CREATE TABLE KiemKeKho
(
	PhieuKiemKeKhoID	              INT Not Null PRIMARY KEY identity(1,1),
	MaKiemKe	                      VARCHAR(20) Not Null unique,
	NgayKiemKe	                          DATETIME,	
	MaKho	                              VARCHAR(20),
	GhiChu	                              nVARCHAR(100),			
	Deleted	                              BIT DEFAULT 0	
)
GO
----------------------------------hungvv--------------------------------------------------------------
GO
CREATE TABLE ChiTietKiemKeKho
(
	MaPhieuKiemKe	                      VARCHAR(20),
	MaHangHoa	                      VARCHAR(50),
	TonThucTe	                      INT	Not Null,
	TonSoSach	                      INT	Not Null,			
	LyDo	                              nVARCHAR(200),
	GhiChu	                              nVARCHAR(100),			
	Deleted	                              BIT DEFAULT	0
)


GO
CREATE TABLE PhieuTTCuaKH
(
	PhieuTTCuaKHID	INT	Not Null PRIMARY KEY identity(1,1),
	MaPhieuTTCuaKH	VARCHAR(20)	Not Null unique,
	NgayLap	DATETIME,				
	MaKhachHang	nVARCHAR(20),
	NoHienThoi	FLOAT,
	NguoiNop	nVARCHAR(200),
	MaTienTe VARCHAR(20),
	GhiChu	nVARCHAR(100),		
	Deleted	BIT	DEFAULT 0	
)
GO
CREATE TABLE ChiTietPhieuTTCuaKH
(
	MaHDBanHang	VARCHAR(20),
	MaPhieuTTCuaKH	VARCHAR(20),
	TongTien FLOAT,
	TienNo FLOAT,
	ThanhToan	FLOAT,				
	TrangThai	BIT,			
	GhiChu	nVARCHAR(100),				
	Deleted	BIT	DEFAULT 0	
)
GO
CREATE TABLE PhieuTTNCC
(
	PhieuTTNCCID	INT	Not Null PRIMARY KEY identity(1,1),
	MaPhieuTTNCC	VARCHAR(20)	Not Null  unique,
	NgayLap	DATETIME,				
	MaNCC	nVARCHAR(20),
	NoHienThoi	FLOAT,
	Nguoinhan	nVARCHAR(200),
	MaTienTe	VARCHAR	(20),
	GhiChu	nVARCHAR(100),				
	Deleted	BIT	DEFAULT 0	
)
GO
CREATE TABLE ChiTietPhieuTTNCC
(
	MaHoaDonNhap	VARCHAR(20),
	MaPhieuTTNCC	VARCHAR(20),
	TongTien FLOAT,
	TienNo FLOAT,
	ThanhToan	FLOAT,
	TrangThai	BIT,			
	GhiChu	nVARCHAR(100),				
	Deleted	BIT	DEFAULT 0	
)
GO
CREATE TABLE PhieuThu
(
	PhieuThuID	INT	Not Null PRIMARY KEY identity(1,1),
	MaPhieuThu	VARCHAR(20)	Not Null unique,
	NgayLap	DATETIME,				
	LoaiPhieu	nVARCHAR(20),
	MaKho	VARCHAR(20),
	MaNhomHang	nVARCHAR(20),
	KhoanMuc	nVARCHAR(200),
	DoiTuong	nVARCHAR(20),
	NguoiNopTien	nVARCHAR(200),
	NguoiNhanTien	nVARCHAR(20),
	NoTaiKhoan	VARCHAR(20),
	CoTaiKhoan	VARCHAR(20),
	TongTienThanhToan	FLOAT,				
	MaTienTe	VARCHAR(20),
	TrangThai	BIT	,
	GhiChu	nVARCHAR(100),
	Deleted	BIT DEFAULT 0	
)
GO
CREATE TABLE PhieuXuatHuy
(
	PhieuXuatHuyID	INT	Not Null PRIMARY KEY identity(1,1),
	MaPhieuXuatHuy	VARCHAR(20)	Not Null  unique,
	NgayLap	DATETIME,		
	MaNhanVien	nVARCHAR(20),
	MaKho	VARCHAR(20),
	TrangThai	BIT	,
	Tongtien	FLOAT,
	GhiChu	nVARCHAR(100),				
	Deleted	BIT	DEFAULT 0	
)
GO
CREATE TABLE ChiTietXuatHuy
(
	MaPhieuXuatHuy	VARCHAR(20),
	MaHangHoa	VARCHAR(50),
	SoLuong	INT,
	GhiChu	nVARCHAR(100),
	Deleted	BIT	DEFAULT 0	
)
GO
GO
Create TABLE CongTy
(
	CongTyID INT IDENTITY(1,1) NOT NULL PRIMARY KEY CLUSTERED ,
	MaCongTy VARCHAR(20) NULL,
	TenCongTy nVARCHAR(200) NULL,
	DiaChi nVARCHAR(200) NULL,
	SoDienThoai nVARCHAR(20) NULL,
	Email nVARCHAR(50) NULL,
	Website nVARCHAR(50) NULL,
	Fax nVARCHAR(20) NULL
)

CREATE TABLE SoDuKho
(
	SoDuKhoID int identity(1,1) primary key,
	MaSoDuKho varchar(20),
	MaKho varchar(20),
	MaHangHoa varchar(50),
 	SoDuDauKy int,
	NgayKetChuyen datetime,
	SoDuCuoiKy int,
	TrangThai bit
)

CREATE TABLE SoDuCongNo
(
	SoDuCongNoID int identity(1,1) primary key,
	MaSoDuCongNo varchar(20),
	MaDoiTuong varchar(20),
	TenDoiTuong nvarchar(200),
	DiaChi nvarchar(200),
 	SoDuDauKy float,
	NgayKetChuyen datetime,
	SoDuCuoiKy float,
	LoaiDoiTuong bit,
	TrangThai bit
)
CREATE TABLE SoDuSoQuy
(
	SoDuSoQuyID int identity(1,1) primary key,
	MaSoDuSoQuy varchar(20),
 	SoDuDauKy float,
	NgayKetChuyen datetime,
	SoDuCuoiKy float,
	TrangThai bit
)
create table TheVip
(
TheID int primary key identity,
MaKhachHang varchar(50),
MaThe varchar(50) unique,
GiaTriThe float,
GiaTriConLai float,
GhiChu nvarchar(100),
SoDiem float,
Deleted bit
)


-- Table GiaVon
GO
IF OBJECT_ID(N'[dbo].[GiaVon]') IS NOT NULL
 DROP table [dbo].[GiaVon]
GO
CREATE TABLE [dbo].[GiaVon](
	[GiaVonID]	INT	Not Null PRIMARY KEY identity(1,1),
	[MaKho] [VARCHAR](20) NULL,
	[MaHangHoa] [VARCHAR] (50) NULL,
	[SoLuong] [INT] NULL,
	[Gia] [FLOAT] NULL,
)

go
IF OBJECT_ID(N'[dbo].[GiaVonBanHang]') IS NOT NULL
 DROP table [dbo].[GiaVonBanHang]
go
Create table GiaVonBanHang
(
ID int primary key identity,
MaHoaDon varchar(50),
MaHangHoa varchar(50),
GiaVon float
)

CREATE TABLE NhomQuyen
(
	NhomQuyenID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	TenNhomQuyen nVARCHAR(50) NOT NULL UNIQUE,
	isDeleted bit default 1
	
)
GO
CREATE TABLE TaiKhoan
(
	TenDangNhap nVARCHAR(200) NOT NULL PRIMARY KEY,
	MatKhauDangNhap nVARCHAR(200) NOT NULL,
	KhoaTaiKhoan BIT NULL,
	NhanVienID nVARCHAR(20),
	Administrator BIT NULL,
	TenNhomQuyen nvarchar(50)
)
GO
CREATE TABLE  Quyen
(
	QuyenID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	TenForm nVARCHAR(50) NOT NULL UNIQUE,
	Ten nvarchar(100) not null
)
GO
CREATE TABLE ChiTietQuyen
(
	TenNhomQuyen nvarchar(50) NOT NULL,
	TenForm nvarchar(50) NOT NULL,
	QuyenThem BIT NULL,
	QuyenSua BIT NULL,
	QuyenXoa BIT NULL,
	QuyenXem BIT NULL,
	SaoLuuDuLieu BIT NULL,
	CapNhatDuLieu BIT NULL
)
go
--										INSERT DATA
insert into PhongBan values ('PB_0000',N'Phòng Quản Trị','N/A',0)
insert into NhanVien values('NV_0000',N'Quản Trị','PB_0000','N/A','N/A','N/A','N/A','N/A','N/A','02/02/2002','N/A','01/01/1991','N/A',0	)

--										NhomQuyen
insert into NhomQuyen values ('Admin',0)
insert into NhomQuyen values ('NhanVienBanHang',0)
insert into NhomQuyen values ('QuanLyKho',0)
insert into NhomQuyen values ('Temp',0)

--										TaiKhoan
insert into TaiKhoan values ('DHTVIETNAM','DHT12345',	0 ,'NV_0000' ,1,'Admin')
insert into TaiKhoan values ('ltsoft','ltsoft',	0 ,'NV_0000' ,1,'Admin')
--insert into TaiKhoan values ('ddk','ddk',	0 ,'NV_0000' ,1,'Admin')
--insert into TaiKhoan values ('sonnt','sonnt',0 ,'NV_0002' ,0,'Admin')
--insert into TaiKhoan values ('lamnv','lamnv',	0 ,'NV_0003' ,0,'Admin')
--insert into TaiKhoan values ('NVBanHang1','NVBanHang1',0,'NV_0004' ,0,'NhanVienBanHang')
--insert into TaiKhoan values ('NVBanHang2','NVBanHang2',	0 ,'NV_0006' ,0,'NhanVienBanHang')
--insert into TaiKhoan values ('QLKho1','QLKho1',	0 ,'NV_0007' ,0,'QuanLyKho')
--insert into TaiKhoan values ('QLKho2','QLKho2',	0 ,'NV_0007' ,0,'QuanLyKho')

--										Quyen
insert into Quyen values('frmQuanLyBanBuon',N'Bán Buôn')--Bắt đầu 
insert into Quyen values('frmQuanLyBanLe',N'Bán Lẻ')
insert into Quyen values('frmQuanLyCongTy', 'Công Ty')
insert into Quyen values('frmQuanLyGoiHang', N'Gói Hàng')
insert into Quyen values('frmQuanLyQuyDoiDonViTinh', N'Quy Đổi Đơn Vị Tính')
insert into Quyen values('frmQuanLyDonDatHang',N'Đơn Đặt Hàng')
insert into Quyen values('frmQuanLyDVT',N'Đơn Vị Tính')
insert into Quyen values('frmQuanLyHangHoa',N'Hàng Hóa')
insert into Quyen values('frmQuanLyKhachHang',N'Khách Hàng')
insert into Quyen values('frmQuanLyKhachHangTraLaiHang',N'Khách Hàng Trả Lại')
insert into Quyen values('frmQuanLyKhoHang',N'Kho Hàng')
insert into Quyen values('frmQuanLyKiemKeKho',N'Kiêm Kê Kho')
insert into Quyen values('frmQuanlyKMthuchi',N'Khoản Mục Thu Chi')
insert into Quyen values('frmQuanLyloaihanghoa',N'Loại Hàng Hóa')
insert into Quyen values('frmQuanLyMaVach',N'In Mã Vạch')
insert into Quyen values('frmQuanLyNhaCungCap',N'Nhà Cung Cấp')
insert into Quyen values('frmQuanlynhanvien',N'Nhân Viên')
insert into Quyen values('frmQuanLyNhapKho',N'Nhập Kho')
insert into Quyen values('frmQuanLyNhomHangHoa',N'Nhóm Hàng Hóa')
insert into Quyen values('frmQuanLyNhomTKKeToan' ,'Nhóm Tài Khoản Kế Toán')
insert into Quyen values('frmQuanLyPhieuChi',N'Phiếu Chi')
insert into Quyen values('frmQuanLyPhieuThanhToanCuaKH',N'Phiếu Thanh Toán Của Khách Hàng')
insert into Quyen values('frmQuanLyPhieuThanhToanNCC',N'Phiếu Thanh Toán Của Nhà Cung Cấp')
insert into Quyen values('frmQuanLyPhieuThu',N'Phiếu Thu')
insert into Quyen values('frmQuanLyPhieuXuatHuy',N'Phiếu Xuất Hủy')
insert into Quyen values('frmXacNhanPhieuXuatHuy',N'Xác Nhận Phiếu Xuất Hủy')
insert into Quyen values('frmQuanlyphongban',N'Phòng Ban')
insert into Quyen values('frmQuanLyTaiKhoanKeToan',N'Tài Khoản Kế Toán')
insert into Quyen values('frmQuanLyThue',N'Thuế')
insert into Quyen values('frmQuanlytiente',N'Tiền Tệ')
insert into Quyen values('frmQuanLyTraLaiNhaCungCap',N'Trả Lại Nhà Cung Cấp')
insert into Quyen values('frmCongNo',N'Công Nợ')
insert into Quyen values('frmHienThi_DieuChuyenKhoNoiBo',N'Điều Chuyển Kho Nội Bộ')
insert into Quyen values('frmHienThi_XacNhanDieuChuyenKho',N'Xác Nhận Điều Chuyển Kho')--Kết Thúc Các form
insert into Quyen values('frmBaoCaoBarcode',N'In Mã Vạch')--Bắt Đầu
insert into Quyen values('frmBCCongNoKhachHang',N'Báo Cáo Công Nợ Khách Hàng')
insert into Quyen values('frmBCCongNoNhaCungCap',N'Báo Cáo Công Nợ Nhà Cung Cấp')
insert into Quyen values('frmtg',N'Báo Cáo Doanh Thu Theo Thời Gian')
insert into Quyen values('frmBCDoanhThuHangHoa',N'Báo Cáo Doanh Thu Theo Hàng Hóa')
insert into Quyen values('frmBCDoanhThuNhanVien',N'Báo Cáo Doanh Thu Theo Nhân Viên')
insert into Quyen values('frmBCDoanhThuNhomHang',N'Báo Cáo Doanh Thu Theo Nhóm Hàng')
insert into Quyen values('frmBCLaiLo',N'Báo Cáo Lãi Lỗ')
insert into Quyen values('frmBCMucTonToiThieuToiDa',N'Báo Cáo Mức Tồn Tối Thiểu-Tối Đa')
insert into Quyen values('frmBCTonKhoTheoKho',N'Báo Cáo Tồn Kho Theo Kho')
insert into Quyen values('frmBCTonKhoTheoNhomHang',N'Báo Cáo Tồn Kho Theo Nhóm Hàng')
insert into Quyen values('frmBCXuatHangTheoHangHoa',N'Báo Cáo Xuất Hàng Theo Hàng hóa')
insert into Quyen values('frmBCXuatHangTheoNhomHang',N'Báo Cáo Xuất Hàng Theo Nhóm Hàng')
insert into Quyen values('frmBCXuatHangTheoTungKho',N'Báo Cáo Xuất Hàng Theo Từng Kho')
insert into Quyen values('frmBCXuatNhapTonLoaiHang',N'Báo Cáo Xuất Nhập Tồn Theo Loại Hàng')
insert into Quyen values('frmBCXuatNhapTonPhieuXuatNhap',N'Báo Cáo Xuất Nhập Tồn Theo Phiếu Xuất Nhập')
insert into Quyen values('frmBCXuatNhapTonTheoKho',N'Báo Cáo Xuất Nhập Tồn Theo Kho')--Kết Thúc Báo cáo
insert into Quyen values('frmSoDuKhachHang',N'Số Dư Khách Hàng')
insert into Quyen values('frmSoDuKhoHang',N'Số Dư Kho Hàng')
insert into Quyen values('frmSoDuSoQuy',N'Số Dư Sổ Quỹ')
insert into Quyen values('frmSoquy',N'Sổ Quỹ')--kết thúc lần 2 :D
insert into Quyen values('frmBCNhapHangTheoKho',N'Báo Cáo Nhập Theo Kho')--Hàng còn sót lại
insert into Quyen values('frmBCNhapHangTheoNhom',N'Báo Cáo Nhập Theo Nhóm Hàng')
insert into Quyen values('frmBCNhapHangTheoMatHang',N'Báo Cáo Nhập Theo Mặt Hàng')
insert into Quyen values('frmBCXuatNhapTonNhomHang',N'Báo Cáo Xuất Nhập Tồn Theo Nhóm Hàng')
insert into Quyen values('BCChiTietHangHoa',N'Báo Cáo Chi Tiết Hàng Hóa')
insert into Quyen values('frmTinhDiemThuong',N'Tính Điểm Thưởng')
insert into Quyen values('frmTimKiemChungTu',N'Tìm Kiếm Chứng Từ')
insert into Quyen values('frmBCXuatHangTheoThoiGian',N'Báo Cáo Xuất Hàng Theo Thời Gian')
insert into Quyen values('frmBCNhapHangTheoThoiGian',N'Báo Cáo Nhập Hàng Theo Thời Gian')
insert into Quyen values('frmCaiDatKho',N'Cài Đặt Kho')
insert into Quyen values('frmBCThue',N'Báo Cáo Thuế')
insert into Quyen values('frmBCXuatHuyHangHoa',N'Báo Cáo Xuất Hủy Hàng Hóa')
insert into Quyen values('frmBCTraLaiNCC',N'Báo Cáo Trả Lại Nhà Cung Cấp')
insert into Quyen values('frmBCKhachHangTraHang',N'Báo Cáo Khách Hàng Trả Lại')
insert into Quyen values('frmBaoCaoHanSuDung',N'Báo Cáo Hàng Hết Hạn')
--insert into Quyen values('frmTongHopXNT',N'Tổng Hợp Xuất Nhập Tồn')
insert into Quyen values('frmBaoCaoTongHopThuChi',N'Báo Cáo Tổng Hợp Thu Chi')
insert into Quyen values('frmBCThuTienTheGiaTri',N'Báo Cáo Thu Tiền Thẻ Giá Trị')
insert into Quyen values('frmBCTienTonKho',N'Báo Cáo Tiền Tồn Kho')


--										ChiTietQuyen
insert into ChiTietQuyen values('Admin','frmBCXuatHangTheoThoiGian',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCNhapHangTheoThoiGian',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyBanBuon',1,1,1,1,1,1)--Bắt đầu 
insert into ChiTietQuyen values('Admin','frmQuanLyBanLe',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyCongTy',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmCaiDatKho',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyGoiHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyQuyDoiDonViTinh',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyDonDatHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyDVT',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyHangHoa',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyKhachHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyKhachHangTraLaiHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyKhoHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyKiemKeKho',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanlyKMthuchi',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyloaihanghoa',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyMaVach',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyNhaCungCap',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanlynhanvien',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyNhapKho',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyNhomHangHoa',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyNhomTKKeToan' ,1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyPhieuChi',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyPhieuThanhToanCuaKH',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyPhieuThanhToanNCC',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyPhieuThu',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyPhieuXuatHuy',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmXacNhanPhieuXuatHuy',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanlyphongban',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyTaiKhoanKeToan',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyThue',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanlytiente',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmQuanLyTraLaiNhaCungCap',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmCongNo',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmHienThi_DieuChuyenKhoNoiBo',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmHienThi_XacNhanDieuChuyenKho',1,1,1,1,1,1)--Kết Thúc Các form
insert into ChiTietQuyen values('Admin','frmBaoCaoBarcode',1,1,1,1,1,1)--Bắt Đầu
insert into ChiTietQuyen values('Admin','frmBCCongNoKhachHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCCongNoNhaCungCap',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmtg',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCDoanhThuHangHoa',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCDoanhThuNhanVien',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCDoanhThuNhomHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCLaiLo',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCMucTonToiThieuToiDa',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCTonKhoTheoKho',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCTonKhoTheoNhomHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCXuatHangTheoHangHoa',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCXuatHangTheoNhomHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCXuatHangTheoTungKho',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCXuatNhapTonLoaiHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCXuatNhapTonPhieuXuatNhap',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCXuatNhapTonTheoKho',1,1,1,1,1,1)--Kết Thúc Báo cáo
insert into ChiTietQuyen values('Admin','frmSoDuKhachHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmSoDuKhoHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmSoDuSoQuy',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmSoquy',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCNhapHangTheoKho',1,1,1,1,1,1)--Hàng còn sót lại
insert into ChiTietQuyen values('Admin','frmBCNhapHangTheoNhom',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCNhapHangTheoMatHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCXuatNhapTonNhomHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','BCChiTietHangHoa',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmTinhDiemThuong',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmTimKiemChungTu',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCThue',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCXuatHuyHangHoa',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCTraLaiNCC',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCKhachHangTraHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBaoCaoHanSuDung',1,1,1,1,1,1)
--insert into ChiTietQuyen values('Admin','frmTongHopXNT',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBaoCaoTongHopThuChi',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCThuTienTheGiaTri',1,1,1,1,1,1)
insert into ChiTietQuyen values('Admin','frmBCTienTonKho',1,1,1,1,1,1)

insert into ChiTietQuyen values('NhanVienBanHang','frmBCXuatHangTheoThoiGian',1,1,1,1,1,1)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCNhapHangTheoThoiGian',1,1,1,1,1,1)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyBanBuon',1,1,1,1,1,1)--Bắt đầu 
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyBanLe',1,1,1,1,1,1)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyCongTy',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmCaiDatKho',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyGoiHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyQuyDoiDonViTinh',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyDonDatHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyDVT',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyHangHoa',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyKhachHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyKhachHangTraLaiHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyKhoHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyKiemKeKho',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanlyKMthuchi',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyloaihanghoa',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyMaVach',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyNhaCungCap',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanlynhanvien',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyNhapKho',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyNhomHangHoa',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyNhomTKKeToan' ,0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyPhieuChi',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyPhieuThanhToanCuaKH',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyPhieuThanhToanNCC',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyPhieuThu',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyPhieuXuatHuy',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmXacNhanPhieuXuatHuy',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanlyphongban',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyTaiKhoanKeToan',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyThue',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanlytiente',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmQuanLyTraLaiNhaCungCap',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmCongNo',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmHienThi_DieuChuyenKhoNoiBo',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmHienThi_XacNhanDieuChuyenKho',0,0,0,0,0,0)--Kết Thúc Các form
insert into ChiTietQuyen values('NhanVienBanHang','frmBaoCaoBarcode',0,0,0,0,0,0)--Bắt Đầu
insert into ChiTietQuyen values('NhanVienBanHang','frmBCCongNoKhachHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCCongNoNhaCungCap',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmtg',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCDoanhThuHangHoa',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCDoanhThuNhanVien',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCDoanhThuNhomHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCLaiLo',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCMucTonToiThieuToiDa',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCTonKhoTheoKho',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCTonKhoTheoNhomHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCXuatHangTheoHangHoa',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCXuatHangTheoNhomHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCXuatHangTheoTungKho',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCXuatNhapTonLoaiHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCXuatNhapTonPhieuXuatNhap',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCXuatNhapTonTheoKho',0,0,0,0,0,0)--Kết Thúc Báo cáo
insert into ChiTietQuyen values('NhanVienBanHang','frmSoDuKhachHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmSoDuKhoHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmSoDuSoQuy',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmSoquy',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCNhapHangTheoKho',0,0,0,0,0,0)--Hàng còn sót lại
insert into ChiTietQuyen values('NhanVienBanHang','frmBCNhapHangTheoNhom',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCNhapHangTheoMatHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCXuatNhapTonNhomHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','BCChiTietHangHoa',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmTinhDiemThuong',1,1,1,1,1,1)
insert into ChiTietQuyen values('NhanVienBanHang','frmTimKiemChungTu',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCThue',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCXuatHuyHangHoa',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCTraLaiNCC',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCKhachHangTraHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBaoCaoHanSuDung',0,0,0,0,0,0)
--insert into ChiTietQuyen values('NhanVienBanHang','frmTongHopXNT',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBaoCaoTongHopThuChi',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCThuTienTheGiaTri',0,0,0,0,0,0)
insert into ChiTietQuyen values('NhanVienBanHang','frmBCTienTonKho',0,0,0,0,0,0)

insert into ChiTietQuyen values('QuanLyKho','frmBCXuatHangTheoThoiGian',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmBCNhapHangTheoThoiGian',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyBanBuon',0,0,0,0,0,0)--Bắt đầu 
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyBanLe',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyCongTy',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmCaiDatKho',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyGoiHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyQuyDoiDonViTinh',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyDonDatHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyDVT',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyHangHoa',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyKhachHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyKhachHangTraLaiHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyKhoHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyKiemKeKho',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmQuanlyKMthuchi',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyloaihanghoa',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyMaVach',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyNhaCungCap',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanlynhanvien',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyNhapKho',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyNhomHangHoa',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyNhomTKKeToan' ,0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyPhieuChi',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyPhieuThanhToanCuaKH',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyPhieuThanhToanNCC',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyPhieuThu',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyPhieuXuatHuy',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmXacNhanPhieuXuatHuy',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanlyphongban',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyTaiKhoanKeToan',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyThue',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanlytiente',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmQuanLyTraLaiNhaCungCap',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmCongNo',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmHienThi_DieuChuyenKhoNoiBo',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmHienThi_XacNhanDieuChuyenKho',0,0,0,0,0,0)--Kết Thúc Các form
insert into ChiTietQuyen values('QuanLyKho','frmBaoCaoBarcode',0,0,0,0,0,0)--Bắt Đầu
insert into ChiTietQuyen values('QuanLyKho','frmBCCongNoKhachHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmBCCongNoNhaCungCap',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmtg',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmBCDoanhThuHangHoa',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmBCDoanhThuNhanVien',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmBCDoanhThuNhomHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmBCLaiLo',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmBCMucTonToiThieuToiDa',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmBCTonKhoTheoKho',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmBCTonKhoTheoNhomHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmBCXuatHangTheoHangHoa',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmBCXuatHangTheoNhomHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmBCXuatHangTheoTungKho',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmBCXuatNhapTonLoaiHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmBCXuatNhapTonPhieuXuatNhap',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmBCXuatNhapTonTheoKho',1,1,1,1,1,1)--Kết Thúc Báo cáo
insert into ChiTietQuyen values('QuanLyKho','frmSoDuKhachHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmSoDuKhoHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmSoDuSoQuy',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmSoquy',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmBCNhapHangTheoKho',1,1,1,1,1,1)--Hàng còn sót lại
insert into ChiTietQuyen values('QuanLyKho','frmBCNhapHangTheoNhom',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmBCNhapHangTheoMatHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmBCXuatNhapTonNhomHang',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','BCChiTietHangHoa',1,1,1,1,1,1)
insert into ChiTietQuyen values('QuanLyKho','frmTinhDiemThuong',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmTimKiemChungTu',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmBCThue',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmBCXuatHuyHangHoa',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmBCTraLaiNCC',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmBCKhachHangTraHang',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmBaoCaoHanSuDung',0,0,0,0,0,0)
--insert into ChiTietQuyen values('QuanLyKho','frmTongHopXNT',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmBaoCaoTongHopThuChi',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmBCThuTienTheGiaTri',0,0,0,0,0,0)
insert into ChiTietQuyen values('QuanLyKho','frmBCTienTonKho',0,0,0,0,0,0)

---================================ 
use SupermarketManagementDHT
--								Điểm thưởng khách hàng
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DiemThuongKhachHang]') AND type in (N'U'))
DROP TABLE [dbo].[DiemThuongKhachHang]
GO
create table DiemThuongKhachHang
(
DiemThuongKhachHangID	int primary key identity,
MaDiemThuongKhachHang	varchar(50) unique not null,
MaKhachHang	varchar(50) not null,
TenKhachHang	nvarchar(200),
TongDiem	int,
DiemDaDung	int,
DiemConLai int,
GhiChu	nvarchar(200),
Deleted	bit
)
go
--								Tỷ lệ tính
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TyLeTinh]') AND type in (N'U'))
DROP TABLE [dbo].[TyLeTinh]
GO
create table TyLeTinh
(
TyLeTinhID	int primary key identity,
MaTyLeTinh	varchar(50),
SoTien	float,
NgayNhap	DateTime,
GhiChu	nvarchar(200),
Deleted	bit
)
go
--								Chi Tiết Thẻ Giảm Giá
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ChiTietTheGiamGia]') AND type in (N'U'))
DROP TABLE [dbo].[ChiTietTheGiamGia]
GO
create table ChiTietTheGiamGia
(
ChiTietTheGiamGiaID int identity primary key,
MaTheGiamGia varchar(50),
MaKhachHang varchar(50),
TenKhachHang nvarchar(200),
GiaTriThe float,
NgayThu datetime,
MaPhieuThu varchar(20),
Deleted bit
)
go