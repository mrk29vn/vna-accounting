using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class GiaVonBanHang
    {
        public const string HanhDong = "HanhDong";
        public const string MaHoaDon = "MaHoaDon";
        public const string MaHangHoa = "MaHangHoa";
        public const string GiaVon = "giaVon";
        public const string Insert = "exec sp_insertGiaVonBanHang @MaHoaDon,@MaHangHoa,@GiaVon";
        public const string Select = "exec sp_selectGiaVonBanHang @HanhDong,@MaHoaDon,@MaHangHoa";
    }

    public class Constants
    {
        #region Img
        public const string lnkNhanVien = "lnkNhanVien";
        public const string lnkNhaCungCap = "lnkNhaCungCap";
        public const string lnkKhachHang = "lnkKhachHang";
        public const string lnkKhoHang = "lnkKhoHang";
        public const string lnkThue = "lnkThue";
        public const string lnkDonViTinh = "lnkDonViTinh";
        public const string lnkLoaiHangHoa = "lnkLoaiHangHoa";
        public const string lnkNhomHangHoa = "lnkNhomHangHoa";
        public const string lnkTaiKhoanKT = "lnkTaiKhoanKT";
        public const string lnkKhoanMuc = "lnkKhoanMuc";
        public const string lnkSoQuy = "lnkSoQuy";
        public const string lnkSoDuDauKy = "lnkSoDuDauKy";
        public const string lnkKetChuyenSoDu = "lnkKetChuyenSoDu";
        public const string lnkDonDatHang = "lnkDonDatHang";
        public const string lnkBanBuon = "lnkBanBuon";
        public const string lnkBanLe = "lnkBanLe";
        public const string lnkKiemKeKho = "lnkKiemKeKho";
        public const string lnkInTemMaVach = "lnkInTemMaVach";
        public const string BCDoanhThu = "BCDoanhThu";
        public const string BCTonKho = "BCTonKho";
        public const string BCXuatHang = "BCXuatHang";
        public const string BCNhapHang = "BCNhapHang";
        public const string BCCongNo = "BCCongNo";
        public const string lnkTienTe = "lnkTienTe";
        public const string lnkNhapKho = "lnkNhapKho";
        public const string lnkNhomTKKT = "lnkNhomTKKT";
        public const string lnkPhieuThu = "lnkPhieuThu";
        public const string lnkPhieuChi = "lnkPhieuChi";
        public const string lnklbPhongBan = "lnklbPhongBan";
        public const string lnkDieuChuyenKho = "lnkDieuChuyenKho";
        public const string lnkXNDieuChuyenKho = "lnkXNDieuChuyenKho";
        public const string lnkPhieuXuatHuy = "lnkPhieuXuatHuy";
        public const string lnkXNPhieuXuatHuy = "lnkXNPhieuXuatHuy";
        public const string lnkKhachHangTraLai = "lnkKhachHangTraLai";
        public const string lnkTraLaiNCC = "lnkTraLaiNCC";
        public const string lnkNhapSoDuTonKho = "lnkNhapSoDuTonKho";
        public const string lnkHangHoa = "lnkHangHoa";
        public const string lnkcongty = "lnkcongty";
        public const string lnkgoihang = "lnkgoihang";
        public const string lnkquydoi = "lnkquydoi";
        public const string imgDHT = "imgDHT";


        public const string bcDTTheoTG = "bcDTTheoTG";
        public const string bcDTTheoNV = "bcDTTheoNV";
        public const string bcDTTheoNhomHang = "bcDTTheoNhomHang";
        public const string bcDTTheoHangHoa = "bcDTTheoHangHoa";
        public const string bcLaiLo = "bcLaiLo";

        public const string bcCNTheoNCC = "bcCNTheoNCC";
        public const string bcCNTheoKH = "bcCNTheoKH";
        public const string bcXHTheoKho = "bcXHTheoKho";
        public const string bcXHTheoNhomHang = "bcXHTheoNhomHang";
        public const string bcXHTheoHangHoa = "bcXHTheoHangHoa";
        public const string bcNHTheoKho = "bcNHTheoKho";
        public const string bcNHTheoNhomHang = "bcNHTheoNhomHang";
        public const string bcNHTheoHangHoa = "bcNHTheoHangHoa";
        public const string bcNHTheoTG = "bcNHTheoTG";
        
        public const string bcTonKhoTheoKho = "bcTonKhoTheoKho";
        public const string bcTonKhoTheoNhomHang = "bcTonKhoTheoNhomHang";
        public const string bcXNTTheoKho = "bcXNTTheoKho";
        public const string bcXNTTheoNhomHang = "bcXNTTheoNhomHang";
        public const string bcXNTTheoPhieuXuatHuy = "bcXNTTheoPhieuXuatHuy";
        public const string bcXNTTheoLoaiHang = "bcXNTTheoLoaiHang";
        public const string bcXHTheoTG = "bcXHTheoTG";
        public const string bcMucTonToiThieuToiDa = "bcMucTonToiThieuToiDa";
        #endregion

        public class Sql
        {
            public Sql() { }
            #region Constants - Sơn

            public string SelectAllNhanVien = "exec sp_SelectNhanViensAll";
            public string SelectAllPhongBan = "exec sp_SelectPhongBansAll";
            public string SelectAllTienTe = "exec sp_SelectTienTesAll";
            public string SelectAllTKKeToan = "exec sp_SelectTKKeToansAll";
            public string SelectAllTKNganHang = "exec sp_SelectTKNganHangsAll";
            public string SelectAllKMThuChi = "exec sp_SelectKMThuChisAll";
            public string SelectAllNhomTKKeToan = "exec sp_SelectNhomTKKeToansAll";
            public string SelectAllPhieuDieuChuyenKhoNoiBo = "exec sp_SelectPhieuDieuChuyenKhoNoiBosAll";
            public string SelectAllChiTietPhieuDieuChuyenKho = "exec sp_SelectChiTietPhieuDieuChuyenKhoNoiBosAll";
            public string SelectAllChiTietKhoHang = "exec sp_SelectChiTietKhoHangsAll";
            public string SelectAllCapNhatGia = "exec sp_SelectCapNhatGiasAll";
            public string SelectAllSoDuKho = "exec sp_SelectSoDuKhosAll";

            public string InsertUpdateNhanVien = "exec sp_XuLy_NhanVien @HanhDong,@NhanVienID,@MaNhanVien,@TenNhanVien, @MaPhongBan, @DCThuongTru, @DCTamTru, @DienThoaiCD, @DienThoaiDD, @Email, @CMND, @NgayCap, @NoiCap, @NgaySinh, @GhiChu,@Deleted";
            public string InsertUpdatePhongBan = "exec sp_XuLy_PhongBan @HanhDong, @PhongBanID, @MaPhongBan, @TenPhongBan, @GhiChu, @Deleted";
            public string InsertUpdateTienTe = "exec sp_XuLy_TienTe @HanhDong, @TienteID, @MaTienTe, @TenTienTe, @TenTienTeChan, @TenTienTeLe, @BieuTuong, @DonViLamTron, @GhiChu, @Deleted";
            public string InsertUpdateTKKeToan = "exec sp_XuLy_TKKeToan @HanhDong, @TKKeToanID, @MaTKKeToan,@MaNhomTKKeToan, @TenTaiKhoan, @GhiChu, @Deleted";
            public string InsertUpdateTKNganHang = "exec sp_XuLy_TKNganHang @HanhDong, @TKNganHangID, @MaTKNganHang, @SoTK, @MaTienTe, @SoDu,@SoSecKeTiep, @NguoiLienHe, @DiaChi, @DienThoai, @Email, @Website, @Ghichu, @Laisuat, @Deleted";
            public string InsertUpdateKMThuChi = "exec sp_XuLy_KMThuChi @HanhDong, @ThuChiID, @MaKhoanMuc, @TenKhoanMuc, @LoaiKM, @DoiTuong, @NoTK,@CoTK, @GhiChu, @Deleted";
            public string InsertUpdateNhomTKKeToan = "exec sp_Xuly_NhomTKKeToan @HanhDong, @NhomTKKeToanID, @MaNhomTKKeToan, @TenNhomTKKeToan, @GhiChu, @Deleted";
            public string InsertUpdatePhieuDieuChuyenKhoNoiBo = "exec sp_Xuly_PhieuDieuChuyenKhoNoiBo @HanhDong, @PhieuDieuChuyenKhoID, @MaPhieuDieuChuyenKho,@NgayDieuChuyen, @TuKho , @DenKho,@MaHoaDonNhap,@XacNhan,@GhiChu,@Deleted ";
            public string InsertUpdateChiTietPhieuDieuChuyenKho = "exec sp_XuLy_ChiTietPhieuDieuChuyenKho @HanhDong, @MaPhieuDieuChuyenKho , @MaHangHoa, @SoLuong, @GhiChu,@Deleted ";
            public string InsertUpdateCapNhatGia = "exec sp_Xuly_CapNhatGia @HanhDong, @CapNhatGiaID, @MaCapNhatGia, @NgayBatDau,@NgayKetThuc,@MaHangHoa,@PhanTramGiaBanBuon,@PhanTramGiaBanLe,@GiaNhap,@TrangThai,@GhiChu,@Deleted";
            public string InsertUpdateSoDuKho = "exec sp_Xuly_SoDuKho @HanhDong, @SoDuKhoID, @MaSoDuKho,@MaKho,@MaHangHoa, @SoDuDauKy,@NgayKetChuyen,@SoDuCuoiKy,@TrangThai";

            public string DeleteHDBanHang = "exec sp_DeleteHDBanHang @maHDBanHang";
            public string DeleteNhanVien = "exec sp_Xoa_NhanVien @HanhDong,@NhanVienID";
            public string DeleteTienTe = "exec sp_Xoa_TienTe @HanhDong, @TienTeID";
            public string DeleteTKKeToan = "exec sp_Xoa_TKKeToan @HanhDong,@TKKeToanID";
            public string DeleteTKNganHang = "exec sp_Xoa_TKNganHang @HanhDong,@TKNganHangID";
            public string DeletePhongBan = "exec sp_Xoa_PhongBan @HanhDong,@PhongBanID";
            public string DeleteKMThuChi = "exec sp_Xoa_KMThuChi @HanhDong,@ThuChiID";
            public string DeleteNhomTKKeToan = "exec sp_Xoa_NhomTKKeToan @HanhDong,@NhomTKKeToanID";
            public string DeletePhieuDieuChuyenKhoNoiBo = "exec sp_Xoa_PhieuDieuChuyenKhoNoiBo @HanhDong, @PhieuDieuChuyenKhoID";
            public string DeleteChiTietPhieuDieuChuyenKho = "exec sp_XoaChiTietPhieuDieuChuyenKho @HanhDong, @MaPhieuDieuChuyenKho";
            public string DeleteCapNhatGia = "exec sp_Xoa_CapNhatGia @HanhDong,@CapNhatGiaID";
            public string DeleteSoDuKho = "exec sp_Xoa_SoDuKho @HanhDong,@SoDuKhoID";


            #endregion
            #region Constants - Hòa
            // Begin user case của Hòa

            public string BCDTTheoNhanVienTheoMa = "exec sp_selectDoanhThuTheoMaNhanVien @ID,@Truoc,@Sau";
            public string BCDTTheoNhomHangTheoma = "exec sp_selectDoanhThuTheoMaNhomHang @ID,@Truoc,@Sau";
            public string BCDTTheoHangHoaTheoMa = "sp_selectDoanhThuTheoMaMatHang @ID,@Truoc,@Sau";
            public string SelectPhieuThuTheoma = "exec sp_selectPhieuThuTheoMa @ID";
            public string SelectHDN = "exec sp_SelectHoaDonNhap";
            public string SelectSoDuCongNo = "exec sp_SelectSoDuCongNo";
            public string SelectSoDuSoQuy = "exec sp_SelectSoDuSoQuy";
            public string BCHDBanLE = "exec sp_selectHoaDonBanHangTheoHoaDon @MaHDBanHang";
            public string BCDTTheoNhanVien = "exec sp_selectDoanhThuTheoNhanVien";
            public string BCDTTheoThang = "exec sp_selectHDBanHangTheoThang @Thang, @Nam";
            public string BCDTTheoKhoangThoiGian = "exec sp_selectHDBanHangTheoKhoangThoiGian @Truoc, @Sau";
            public string BCDTTheoNgay = "exec sp_selectHDBanHangTheoNgay @Ngay";
            public string BCDTTheoNhomHang = "exec sp_selectDoanhThuTheoNhomHang";
            public string BCDTTheoHangHoa = "sp_selectDoanhThuTheoMatHang";
            public string SelectQuayThuNgan = "exec sp_SelectQuayThuNgansAll";
            public string SelectChiTietXuatHuy = "exec sp_SelectChiTietXuatHuysAll @MaPhieuXuatHuy";
            public string SelectChiTietPhieuTTCuaKH = "exec sp_SelectChiTietPhieuTTCuaKHsAll @MaPhieuTTCuaKH";
            public string SelectChiTietPhieuTTNCC = "exec sp_SelectChiTietPhieuTTNCCsAll @MaPhieuTTNCC";
            public string SelectPhieuThu = "exec sp_SelectPhieuThusAll";
            public string SelectPhieuTTCuaKH = "exec sp_SelectPhieuTTCuaKHsAll";
            public string SelectPhieuTTNCC = "exec sp_SelectPhieuTTNCCsAll";
            public string SelectPhieuXuatHuy = "exec sp_SelectPhieuXuatHuysAll";
            public string SelectHDBanHang = "exec sp_SelectHDBanHangsAll";
            public string SelectChiTietHDBanHang = "exec sp_SelectChiTietHDBanHangsAll @MaHDBanHang";
            public string SelectTheGiamGia = "exec sp_SelectTheGiamGia";


            public string InsertSoDuCongNo = "exec sp_InsertSoDuCongNo @MaSoDuCongNo,@MaDoiTuong,@TenDoiTuong,@DiaChi,@SoDuDauKy,@NgayKetChuyen,@SoDuCuoiKy,@LoaiDoiTuong,@TrangThai";
            public string UpdateTinhTrangSoDuCongNo = "exec sp_UpdateSoDuCongNo @MaSoDuCongNo,@SoDuCuoiKy,@LoaiDoiTuong";
            public string UpdateTinhTrangSoDuSoQuy = "exec sp_UpdateTrangThaiSoDuSoQuy @MaSoDuSoQuy";
            public string InsertSoDuSoQuy = "exec sp_InsertSoDuSoQuy @MaSoDuSoQuy,@SoDuDauKy,@NgayKetChuyen,@SoDuCuoiKy,@TrangThai";
            public string UpdateSoDuSoQuy = "exec sp_UpdateSoDuSoQuy @SoDuSoQuyID,@SoDuCuoiKy";
            public string UpdateThanhToanNgayHoaDonNhap = "exec sp_XuLy_ThanhToanNgayHDN @MaHoaDonNhap,@ThanhToanSauKhiLapPhieu";
            public string UpdateDuNoNCC = "exec sp_XuLy_NoHienThoiNCC @MaNhaCungCap,@DuNo";
            public string UpdateDuNoNCCC = "exec sp_XuLy_NoHienThoiNCCC @MaNhaCungCap,@DuNo";
            public string UpdateTinhTrang = "exec sp_XacNhan_PhieuXuatHuy @MaPhieuXuatHuy";
            public string UpdateThanhToanngay = "exec sp_XuLy_ThanhToanNgay @MaHDBanHang,@ThanhToanNgay";
            public string UpdateDuNo = "exec sp_XuLy_NoHienThoi @MaKH,@DuNo";
            public string UpdateDuNoKH = "exec sp_XuLy_NoHienThoiKH @MaKH,@DuNo";
            public string UpdateSoLuong = "exec sp_TruSoLuong @MaKho, @MaHangHoa , @SoLuong";
            public string InsertUpdateChiTietHDBanHangMang = "exec sp_InsertUpdate_ChiTietHDBanHang @HanhDong,@MaHDBanHang,@MaHangHoa,@TenHangHoa,@SoLuong,@DonGia,@Thue,@PhanTramChietKhau,@GhiChu,@Deleted";
            public string InsertUpdateChiTietXuatHuyMang = "exec sp_InsertUpdate_ChiTietXuatHuy @HanhDong,@MaPhieuXuatHuy,@MaHangHoa,@SoLuong,@GhiChu,@Deleted";
            public string InsertUpdateChiTietHDBanHang = "exec sp_XuLy_ChiTietHDBanHang @HanhDong,@MaHDBanHang,@MaHangHoa,@TenHangHoa,@SoLuong,@DonGia,@Thue,@PhanTramChietKhau,@GhiChu,@Deleted";
            public string InsertUpdateHDBanHang = "exec sp_XuLy_HDBanHang @HanhDong,@HDBanHangID,@MaHDBanHang,@NgayBan,@MaKhachHang,@NoHienThoi,@NguoiNhanHang,@HinhThucThanhToan,@MaKho,@HanThanhToam ,@MaDonDatHang,@MaNhanVien,@MaTienTe,@ChietKhau,@ThanhToanNgay,@ThanhToanKhiLapPhieu,@ThueGTGT,@TongTienThanhToan,@LoaiHoaDon,@MaThe,@GiaTriThe,@GhiChu,@Deleted,@KhachTra,@ChietKhauTongHoaDon,@MaTheGiaTri,@GiaTriTheGiaTri";
            public string InsertUpdateChiTietXuatHuy = "exec sp_XuLy_ChiTietXuatHuy @HanhDong,@MaPhieuXuatHuy,@MaHangHoa,@SoLuong,@GhiChu,@Deleted";
            public string InsertUpdateChiTietPhieuTTCuaKH = "exec sp_XuLy_ChiTietPhieuTTCuaKH @HanhDong,@MaHDBanHang,@MaPhieuTTCuaKH,@TongTien,@TienNo,@ThanhToan,@TrangThai,@GhiChu,@Deleted";
            public string InsertUpdateChiTietPhieuTTNCC = "exec sp_XuLy_ChiTietPhieuTTNCC @HanhDong,@MaHoaDonNhap,@MaPhieuTTNCC,@TongTien,@TienNo,@ThanhToan,@TrangThai,@GhiChu,@Deleted";
            public string InsertUpdatePhieuThu = "exec sp_XuLy_PhieuThu @HanhDong,@PhieuThuID, @MaPhieuThu,@NgayLap,@LoaiPhieu,@MaKho,@MaNhomHang,@KhoanMuc,@DoiTuong,@NguoiNopTien,@NguoiNhanTien,@NoTaiKhoan,@CoTaiKhoan,@TongTienThanhToan,@MaTienTe,@TrangThai,@GhiChu,@Deleted";
            public string InsertUpdatePhieuTTCuaKH = "exec sp_XuLy_PhieuTTCuaKH @HanhDong,@PhieuTTCuaKHID, @MaPhieuTTCuaKH,@NgayLap,@MaKhachHang,@NoHienThoi,@NguoiNop,@MaTienTe,@GhiChu,@Deleted";
            public string InsertUpdatePhieuTTNCC = "exec sp_XuLy_PhieuTTNCC @HanhDong,@PhieuTTNCCID, @MaPhieuTTNCC,@NgayLap,@MaNCC,@NoHienThoi ,@Nguoinhan,@MaTienTe,@GhiChu,@Deleted";
            public string InsertUpdatePhieuXuatHuy = "exec sp_XuLy_PhieuXuatHuy @HanhDong,@PhieuXuatHuyID, @MaPhieuXuatHuy,@NgayLap,@MaNhanVien,@MaKho,@TrangThai,@Tongtien,@GhiChu,@Deleted";
            public string InsertTheGiamGia = "exec sp_InsertUpdateTheGiamGia @MaTheGiamGia,@MaKhachHang,@GiaTriThe,@NgayBatDau,@NgayKetThuc";
            public string UpdateTheGiamGia = "exec sp_UpdateTheGiamGia @MaTheGiamGia,@GiaTriConLai";

            public string DeleteSoDuCongNo = "exec sp_DeleteSoDuCongNo @MaSoDuCongNo";
            public string DeleteSoDuSoQuy = "exec sp_DeleteSoDuSoQuy @MaSoDuSoQuy";
            public string DeleteChiTietBanHang = "exec sp_Xoa_ChiTietHDBanHang @HanhDong,@HDBanHangID,@@MaHangHoa";
            public string DeleteHDBangHang = "exec sp_Xoa_HDBanHang @HanhDong,@HDBanHangID";
            public string DeleteChiTietXuatHuy = "exec sp_Xoa_ChiTietXuatHuy @HanhDong,@MaPhieuXuatHuy,@MaHangHoa";
            public string DeleteChiTietPhieuTTCuaKH = "exec sp_Xoa_ChiTietPhieuTTCuaKH @HanhDong,@MaHDBanHang,@MaPhieuTTCuaKH";
            public string DeleteChiTietPhieuTTNCC = "exec sp_Xoa_ChiTietPhieuTTNCC @HanhDong,@MaHoaDonNhap,@MaPhieuTTNCC";
            public string DeletePhieuThu = "exec sp_Xoa_PhieuThu @HanhDong,@PhieuThuID";
            public string DeletePhieuTTCuaKH = "exec sp_Xoa_PhieuTTCuaKH @HanhDong,@PhieuTTCuaKHID";
            public string DeletePhieuTTNCC = "exec sp_Xoa_PhieuTTNCC @HanhDong,@PhieuTTNCCID";
            public string DeletePhieuXuatHuy = "exec sp_Xoa_PhieuXuatHuy @HanhDong,@PhieuXuatHuyID";
            public string DeleteTheGiamGia = "exec sp_DeleteTheGiamGia @MaTheGiamGia";

            public string LayTenNhomHang = "exec sp_LayTenNhomHang";
            public string LayTenTienTe = "exec sp_LayTenTT";
            public string LayTenKhoHang = "exec sp_LayTenKhoHang";
            public string LayNoTK = "exec sp_LayNoTK";
            public string LayCoTK = "exec sp_LayCoTK";
            public string LayKMThuChi = "exec sp_LayKMThuChi @Loai";
            public string LayID = "exec sp_Lay_ID @table";
            // End user case của Hòa
            #endregion
            #region Constants - Hương
            #region Gói Hàng
            public class GoiHang
            {
                public const string TieuDeXuLyThem = "Xử Lý Gói Hàng - Thêm";
                public const string TieuDeXuLySua = "Xử Lý Gói Hàng - Sửa";

                public const string SelectGoiHang = "exec sp_SelectGoiHang";
                public const string SelectTheoMaGoiHang = "exec sp_SelectGoiHangTheoMa @MaGoiHang";
                public const string InsertUpdateGoiHang = "exec sp_XuLy_GoiHang @HanhDong,@GoiHangID,@MaKho,@MaGoiHang,@TenGoiHang,@MaNhomHang,@TenNhomHang,@GiaNhap,@GiaBanBuon,@GiaBanLe,@Deleted";
                public const string DeleteGoiHang = "exec sp_Xoa_GoiHang @GoiHangID";

               

                public const string txtMaGoiHang = "txtmagoihang";
                public const string txtTenGoiHang = "txttengoihang";
                public const string txtGiaNhap = "txtgianhap";
                public const string txtGiaBanBuon = "txtgiabanbuon";
                public const string txtGiaBanLe = "txtgiabanle";
                public const string txtMaHangHoa = "txtmahanghoa";
                public const string txtTenHangHoa = "txttenhanghoa";
                public const string txtSoLuong = "txtsoluong";
                public const string txtGiaNhapGH = "txtgianhapgh";
                public const string txtGiaBanBuonGH = "txtgiabanbuongh";
                public const string txtGiaBanLeGH = "txtgiabanlegh";
            }
            #endregion


            #region Chi Tiết Gói Hàng
            public class ChiTietGoiHang
            {

                public const string SelectChiTietGoiHang = "exec sp_SelectChiTietGoiHang";
                public const string InsertUpdateChiTietGoiHang = "exec sp_XuLy_ChiTietGoiHang @HanhDong,@ChiTietGoiHangID,@MaGoiHang,@MaHangHoa,@TenHangHoa,@SoLuong,@GiaNhap,@GiaBanBuon,@GiaBanLe";
                public const string DeleteChiTietGoiHang = "exec sp_DeleteChiTietGoiHang @MaGoiHang";

              

            }
            #endregion

            #region Quy Đổi Đơn Vị Tính
            public class QuyDoiDonViTinh
            {
                public const string TieuDeXuLyThem = "Xử Lý Quy Đổi Đơn Vị Tính - Thêm";
                public const string TieuDeXuLySua = "Xử Lý Quy Đổi Đơn Vị Tính - Sửa";

                public const string SelectQuyDoiDonViTinh = "exec sp_SelectQuyDoiDonViTinh";
                public const string SelectQuyDoiDonViTinhTheoMa = "exec sp_SelectQuyDoiDVTTheoMa @MaHangDuocQuyDoi";
                public const string TimQuyDoi = "exec sp_LayQuyDoiDonViTinh @MaDonViTinh,@MaHangQuyDoi";
                public const string InsertUpdateQuyDoiDonViTinh = "exec sp_XuLy_QuyDoiDonViTinh @HanhDong,@QuyDoiDonViTinhID,@MaQuyDoiDonViTinh,@MaHangQuyDoi,@TenHangQuyDoi,@MaDonViTinh,@SoLuongQuyDoi,@MaHangDuocQuyDoi,@TenHangDuocQuyDoi,@MaDonViTinhDuocQuyDoi,@SoLuongDuocQuyDoi,@Deleted";
                public const string DeleteQuyDoiDonViTinh = "exec sp_Xoa_QuyDoiDonViTinh @QuyDoiDonViTinhID ";

              
                public const string txtMaHangDuocQuyDoi = "txtmahangduocquydoi";
                public const string txtTenHangDuocQuyDoi = "txttenhangduocquydoi";
                public const string txtDonViTinh = "txtdonvitinh";
                public const string txtSoLuongDuocQuyDoi = "txtsoluongduocquydoi";
                public const string txtMaHangQuyDoi = "txtmahangquydoi";
                public const string txtTenHangQuyDoi = "txttenhangquydoi";
                public const string txtDonViTinhQuyDoi = "txtdonvitinhquydoi";
                public const string txtSoLuongQuyDoi = "txtsoluongquydoi";
            }

            #endregion
            // Hương
            //===================Select Khách Hàng, Nhà cung cấp, Nhà sản xuất, Nhóm khách hàng-----------------------
            public string SelectKhachHangsAll = "exec sp_SelectKhachHangsAll";
            public string SelectNhaCungCapsAll = "exec sp_SelectNhaCungCapsAll";
            public string SelectNhaSXesAll = "exec sp_SelectNhaSXsAll";
            public string SelectNhomKHsAll = "exec sp_SelectNhomKHsAll";
            public string DonHang = "exec sp_DonHang @MaKhachHang";
            public string XuatHang = "exec sp_XuatHang @MaKhachHang";
            public string TraLai = "exec sp_TraLai @MaKhachHang";
            public string ThanhToan = "exec sp_ThanhToan @MaKhachHang";
            public string LSGDHangHoa = "exec sp_HangHoa @MaKhachHang";
            public string TheoHangHoa = "exec sp_TheoHangHoa";
            public string TheoNhomHang = "exec sp_TheoNhomHang";
            public string DonHangNCC = "exec sp_DonHangNCC @MaNhaCungCap";
            public string LSGDNhapMua = "exec  sp_NhapMua @MaNhaCungCap";
            public string LSGDTraLaiNCC = "exec sp_TraLaiNCC @MaNhaCungCap";
            public string LSGDThanhToanNCC = "exec sp_ThanhToanNCC @MaNhaCungCap";
            public string LSGDHangHoaNCC = "exec sp_HangHoaNCC @MaNhaCungCap";
            public string CapNhatGiaKH = "exec sp_SelectCapNhatGiaKhachHang @MaKhachHang";
            public string SelectCongTy = "exec sp_SelectCongTy";
            public string SelectThue = "exec sp_SelectThue";
            public string SelectChiTietHangHoa = "exec sp_BCChiTietHangHoa";
            public string BaoCaoNhapHangTheoMatHang = "exec sp_BaoCaoNhapHangTheoMatHang";
            public string BaoCaoNhapHangTheoNhomHang = "exec sp_BaoCaoNhapHangTheoNhomHang";


            //==================InsertUpdate Khách Hàng, Nhà cung cấp, Nhà sản xuất, Nhóm khách hàng=================
            public string InsertUpdateThue = "exec sp_XuLy_Thue @HanhDong,@ThueID,@MaThue,@GiaTriThue,@TenThue,@GhiChu,@Deleted";
            public string InsertUpdateCongTy = "exec sp_XuLy_CongTy @HanhDong,@CongTyID,@MaCongTy,@TenCongTy,@DiaChi,@SoDienThoai,@Email,@Website,@Fax";
            public string InsertCapNhatGiaKH = "exec sp_InsertCapNhatGiaKhacHang @HanhDong,@CapNhatGiaKhachHangID, @MaCapNhatGiaKhachHang,@MaHangHoa,@MaKhachHang,@NgayBatDau,@NgayKetThuc,@PhanTramChietKhau,@Deleted";
            public string InsertUpdateKhachHang = "exec sp_XuLy_KhachHang @HanhDong,@KhachHangID,@MaKH,@Ten,@DiaChi,@DienThoai,@Fax,@Email,@MST,@DuNo,@HanMucTT,@CongTy,@NgaySinh,@MaVung,@Mobi,@Ngungtheodoi,@Website,@GhiChu,@Deleted";
            public string InsertUpdateNhaCungCap = "exec sp_XuLy_NhaCungCap @HanhDong,@NhaCungCapID,@MaNhaCungCap,@TenNhaCungCap,@DiaChi,@DienThoai,@Email,@Fax,@NguoiLienHe,@MST,@DuNo,@Website,@GhiChu,@Deleted";
            public string InsertUpdateNhaSX = "exec sp_XuLy_NhaSX @HanhDong,@NhaSXID,@MaNhaSX,@TenNhaSX,@TenLH,@DiaChi,@DienThoai,@Fax,@Email,@WebSite,@GhiChu,@Deleted ";
            public string InsertUpdateNhomKH = "exec sp_XuLy_NhomKH @HanhDong,@NhomKHID,@MaNhomKH,@TenNhomKH,@LoaiKH,@GhiChu,@Deleted";

            //=========================Delete Khách Hàng, Nhà cung cấp, Nhà sản xuất, Nhóm khách hàng===============
            public string DeleteThue = "exec sp_Xoa_Thue @HanhDong,@ThueID";
            public string DeleteCapNhatGiaKH = "exec sp_Xoa_CapNhatGiaKhachHang @HanhDong,@CapNhatGiaKhachHangID";
            public string DeleteKhachHang = "exec sp_Xoa_KhachHang @HanhDong,@KhachHangID";
            public string DeleteNhaCungCap = "exec sp_Xoa_NhaCungCap @HanhDong,@NhaCungCapID";
            public string DeleteNhaSX = "exec sp_Xoa_NhaSX @HanhDong,@NhaSXID";
            public string DeleteNhomKH = "exec sp_Xoa_NhomKH @HanhDong, @NhomKHID";
            //End
            #endregion
            #region hungvv=================================================================================================================
            //ket noi lay ten server
            public string ConnectionString = "Data Source=localhost;Initial Catalog=master;Integrated Security=True;";
            //lay ten server
            public string selectServerName = "SELECT name from sys.servers";
            //lay ten database
            public string selectDatabase = "SELECT name FROM sys.databases";
            // file xml ConnectionsName
            public string ConfigXML = @"\Config.xml";
            public string KeywordConfigXML = "SupermarketManagement";
            public string Connect = "Connect";
            public string DataSource = "DataSource";
            public string DataSourceValues = "SERVER";
            public string UserID = "UserID";
            public string UserIDValues = "sa";
            public string Password = "Password";
            public string PasswordValues = "123456";
            public string InitialCatalog = "InitialCatalog";
            public string InitialCatalogValues = "SupermarketManagement";
            // file xml ServerConfig
            public string ServerConfig = @"\ServerConfig.xml";
            public string KeywordServerConfig = "ConnectionServer";
            public string Config = "Config";
            public string Server = "Server";
            public string IP = "IP";
            public string Port = "Port";
            //dia chi IP
            public string IPValues = "localhost";
            public string PortValues = "2011";
            //lay top (1) ID cua cac bang
            public string ColumnNameID = "ColumnNameID";
            //cai dat kho
            public string tenfile = @"\setup.xml";
            public string setup = "setup";
            #endregion
            #region hungvv===========================================================================================================================================
            /// <summary>
            /// vuong hung =======================DonDatHang===================
            /// </summary>
            public string sp_XuLy_DonDatHang = "exec sp_XuLy_DonDatHang @HanhDong ,@DonDatHangID,@MaDonDatHang ,@LoaiDonDatHang ,@NgayDonHang ,@MaNhaCungCap ,@NoHienThoi ,@TrangThaiDonDatHang ,@NgayNhapDuKien ,@HinhThucThanhToan ,@MaKho ,@MaNhanVien ,@MaTienTe ,@ThueGTGT,@Phivanchuyen,@PhiKhac,@GhiChu ,@Deleted,@MaKhachHang";
            public string sp_Xoa_DonDatHang = "exec sp_Xoa_DonDatHang @HanhDong,@MaDonDatHang";
            public string sp_LayBang_DonDatHang = "exec sp_LayBang_DonDatHang @MaDonDatHang";
            /// <summary>
            /// vuong hung======================chitietdondathang================================
            /// </summary>
            public string sp_XuLy_ChiTietDonDatHang = "exec XuLy_ChiTietDonDatHang @HanhDong,@MaDonDatHang,@MaHangHoa,@TenHangHoa,@SoLuong,@DonGia,@Thue,@PhanTramChietKhau,@GhiChu,@Deleted";
            public string sp_Xoa_ChiTietDonDatHang = "exec Xoa_ChiTietDonDatHang @HanhDong,@MaDonDatHang,@MaHangHoa";
            public string sp_LayBang_ChiTietDonDatHang = "exec sp_LayBang_ChiTietDonDatHang";

            /// <summary>
            /// vuong hung =======================HoaDonNhap=============================
            /// </summary>
            public string sp_XuLy_HoaDonNhap = "exec sp_XuLy_HoaDonNhap @HanhDong,@HoaDonNhapID,@MaHoaDonNhap,@NgayNhap,@MaNhaCungCap,@NoHienThoi,@NguoiGiaoHang,@HinhThucThanhToan,@MaKho,@HanThanhToan,@MaDonDatHang,@MaTienTe,@ChietKhau,@ThanhToanNgay,@ThueGTGT,@TongTien,@GhiChu,@Deleted,@ThanhToanSauKhiLapPhieu";
            public string sp_Xoa_HoaDonNhap = "exec sp_Xoa_HoaDonNhap @HanhDong,@MaHoaDonNhap";
            public string sp_LayBang_HoaDonNhap = "exec sp_LayBang_HoaDonNhap @MaHoaDonNhap,@MaKho";
            /// <summary>
            /// vuong hung =======================chi tiet HoaDonNhap=============================
            /// </summary>
            public string sp_XuLy_ChiTietHoaDonNhap = "exec sp_XuLy_ChiTietHoaDonNhap @HanhDong ,@MaHoaDonNhap,@MaHangHoa,@SoLuong,@PhanTramChietKhau,	@DonGia,@Thue,@GhiChu	,@Deleted";
            public string sp_Xoa_ChiTietHoaDonNhap = "exec sp_Xoa_ChiTietHoaDonNhap @HanhDong,@MaHoaDonNhap,@MaHangHoa";
            public string sp_LayBang_ChiTietHoaDonNhap = "exec sp_LayBang_ChiTietHoaDonNhap";

            /// <summary>
            /// vuong hung ========================KhachHangTraLai=============================
            /// </summary>
            public string sp_XuLy_KhachHangTraLai = "exec sp_XuLy_KhachHangTraLai @HanhDong ,@KhachHangTraLaiID,@MaKhachHangTraLai,@NgayNhap,@MaKhachHang,@NoHienThoi,@NguoiTra,@HinhThucThanhToan,@HanThanhToan,@MaHoaDonMuaHang,@MaKho ,@MaTienTe,@TienBoiThuong, @ThanhToanNgay,@ThueGTGT,@GhiChu,@Deleted";
            public string sp_Xoa_KhachHangTraLai = "exec sp_Xoa_KhachHangTraLai @HanhDong,@MaKhachHangTraLai";
            public string sp_LayBang_KhachHangTraLai = "exec sp_LayBang_KhachHangTraLai @MaKhachHangTraLai";
            /// <summary>
            /// vuong hung ========================chi tiet KhachHangTraLai=============================
            /// </summary>
            public string sp_XuLy_ChiTietKhachHangTraLai = "exec sp_XuLy_ChiTietKhachHangTraLai @HanhDong,@MaKhachHangTraLai,@MaHangHoa,@TenHangHoa,@SoLuong,@PhanTramChietKhau, @DonGia,@Thue,@GhiChu,@Deleted,@MaKho";
            public string sp_Xoa_ChiTietKhachHangTraLai = "exec sp_Xoa_ChiTietKhachHangTraLai @HanhDong ,@MaKhachHangTraLai	,@MaHangHoa";
            public string sp_LayBang_ChiTietKhachHangTraLai = "exec sp_LayBang_ChiTietKhachHangTraLai";


            /// <summary>
            /// vuong hung =========================TraLaiNhaCungCap=====================================
            /// </summary>
            public string sp_XuLy_TraLaiNhaCungCap = "exec sp_XuLy_TraLaiNhaCungCap @HanhDong,@TraLaiNCCID,@MaHDTraLaiNCC,@Ngaytra,@MaNCC,@NoHienThoi,@NguoiNhanHang,@HinhThucThanhToan,@MaHoaDonNhap,@MaKho,@MaTienTe,@TienBoiThuong,@ThanhToanNgay,@ThueGTGT,@GhiChu,@Deleted";
            public string sp_Xoa_TraLaiNhaCungCap = "exec sp_Xoa_TraLaiNhaCungCap @HanhDong,@MaHDTraLaiNCC";
            public string sp_LayBang_TraLaiNhaCungCap = "exec sp_LayBang_TraLaiNhaCungCap @MaHDTraLaiNCC";
            /// <summary>
            /// vuong hung =========================chi tiet TraLaiNhaCungCap=====================================
            /// </summary>
            public string sp_XuLy_ChiTietTraLaiNhaCungCap = "exec sp_XuLy_ChiTietTraLaiNhaCungCap @HanhDong ,@MaHDTraLaiNCC, @MaHangHoa, @SoLuong, @DonGia, @Thue, @PhanTramChietKhau, @GhiChu	,@Deleted, @MaKho";
            public string sp_Xoa_ChiTietTraLaiNhaCungCap = "exec sp_Xoa_ChiTietTraLaiNhaCungCap @HanhDong ,@MaHDTraLaiNCC,@MaHangHoa";
            public string sp_LayBang_ChiTietTraLaiNhaCungCap = "exec sp_LayBang_ChiTietTraLaiNhaCungCap";

            /// <summary>
            /// vuong hung =========================Kiem ke kho=====================================
            /// </summary>
            public string sp_XuLy_KiemKeKho = "exec sp_XuLy_KiemKeKho @HanhDong,@PhieuKiemKeKhoID,@MaKiemKe,@NgayKiemKe,@MaKho ,@GhiChu,@Deleted";
            public string sp_Xoa_KiemKeKho = "exec sp_Xoa_KiemKeKho @HanhDong,@MaKiemKe";
            public string sp_LayBang_KiemKeKho = "exec sp_LayBang_KiemKeKho @MaKiemKe";
            /// <summary>
            /// vuong hung =========================chi tiet Kiem ke kho=====================================
            /// </summary>
            public string sp_XuLy_ChiTietKiemKeKho = "exec sp_XuLy_ChiTietKiemKeKho @HanhDong ,@MaPhieuKiemKe,@MaHangHoa,@TonThucTe,@TonSoSach,	@LyDo	,@GhiChu	,@Deleted";
            public string sp_Xoa_ChiTietKiemKeKho = "exec sp_Xoa_ChiTietKiemKeKho @HanhDong ,@MaPhieuKiemKe,@MaHangHoa";
            public string sp_LayBang_ChiTietKiemKeKho = "exec sp_LayBang_ChiTietKiemKeKho @MaPhieuKiemKe";

            /// <summary>
            /// =================================lay cot ID top 1====================================================
            /// </summary>
            public string sp_Tim_ID = "exec sp_Tim_ID";
            public string sp_Lay_ID = "exec sp_Lay_ID";
            public string sp_Tim_ID_HoaDonNhap = "exec sp_Tim_ID_HoaDonNhap";
            public string sp_LayBang_KhoHang = "exec sp_LayBang_KhoHang";
            public string sp_LayBang_TienTe = "exec sp_LayBang_TienTe";
            public string sp_LayBang_NhanViens = "exec sp_LayBang_NhanVien";
            public string sp_LayBang_HangHoa = "exec sp_LayBang_HangHoa @MaHangHoa";
            public string sp_LayBang_NhaCungCap = "exec sp_LayBang_NhaCungCap @MaNhaCungCap";
            public string sp_LayBang_ThongTinKhachHang = "exec sp_LayBang_ThongTinKhachHang @MaKH";
            public string sp_LayBang_ThongTinDonDatHang = "exec sp_LayBang_ThongTinDonDatHang @MaDonDatHang";
            public string sp_LayBang_ThongTinMaDonDatHang = "exec sp_LayBang_ThongTinMaDonDatHang";
            public string sp_LayID_KhachHangTraLai = "exec sp_LayID_KhachHangTraLai";
            //kiem tra ma hang hoa
            public string sp_KiemTraMa = "exec sp_KiemTraMa  @MaHangHoa,@TenHangHoa";
            public string sp_CongKho = "exec sp_CongKho @MaKho,@MaHangHoa,@SoLuong ";
            public string sp_TruKho = "exec sp_TruKho @MaKho,@MaHangHoa,@SoLuong ";
            #endregion
            #region Constants - Luân
            /// <summary>
            /// SQl cua Luan
            /// </summary>
            /// 
            public string SelectHHTheoKho = "exec sp_SelectHHTrongKho";
            public string SelectAllThue = "exec sp_SelectThue";
            public string SelectAllHangHoa = "exec sp_SelectHangHoasAll";
            public string SelectAllNhomHangHoa = "exec sp_SelectNhomHangsAll";
            public string SelectAllLoaiHangHoa = "exec sp_SelectLoaiHangsAll";
            public string SelectAllKhoHang = "exec sp_SelectKhoHangsAll";
            public string SelectAllDVT = "exec sp_SelectDVTsAll";
            public string SelectAllLoaiThue = "exec sp_SelectLoaiThuesAll";

            public string InsertUpdateHangHoa = "exec sp_XuLy_HangHoa @HanhDong,@MaHangHoa,@MaNhomHangHoa,@TenHangHoa,@MaDonViTinh,@GiaNhap,@GiaBanBuon,@GiaBanLe,@MaThueGiaTriGiaTang,@KieuHangHoa,@SeriLo,@MucDatHang,@MucTonToiThieu,@GhiChu,@Deleted ";
            public string InsertUpdateNhomHangHoa = "exec sp_XuLy_NhomHangHoa @HanhDong,@NhomHangID,@MaNhomHang,@MaLoaiHang, @TenNhomHang,@GhiChu,@Deleted";
            public string InsertUpdateLoaiHangHoa = "exec sp_XuLy_LoaiHangHoa @HanhDong,@LoaiHangID,@MaLoaiHang,@TenLoaiHang,@GhiChu,@Deleted";
            public string InsertUpdateKhoHang = "exec sp_XuLy_KhoHang @HanhDong,@KhoHangID,@MaKho,@TenKho,@DiaChi,@DienThoai,@MaNhanVien,@GhiChu,@Deleted";
            public string InsertUpdateDVT = "exec sp_XuLy_DVT @HanhDong,@DVTID,@MaDonViTinh,@TenDonViTinh,@GhiChu,@Deleted";
            public string InsertUpdateLoaiThue = "exec sp_XuLy_LoaiThue @HangDong,@LoaiThueID,@MaLoaiThue,@TenLoaiThue,@GhiChu,@Deleted";

            public string DeleteHangHoa = "exec sp_Xoa_HangHoa @HanhDong,@HangHoaID";
            public string DeleteNhomHangHoa = "exec sp_Xoa_NhomHangHoa @HanhDong,@NhomHangID";
            public string DeleteLoaiHangHoa = "exec sp_Xoa_LoaiHangHoa @HanhDong,@LoaiHangID";
            public string DeleteKhoHang = "exec sp_Xoa_KhoHang @HanhDong,@KhoHangID";
            public string DeleteDVT = "exec sp_Xoa_DVT @HanhDong,@DVTID";
            public string DeleteLoaiThue = "exec sp_Xoa_LoaiThue @HanhDong,@LoaiThueID";
            //End
            #endregion
            #region Hưởng
            public string LogIn = "exec sp_LogIn @TenDangNhap,@MatKhauDangNhap";
            public string selectTaiKhoan = "sp_selectTaiKhoan";
            public string selectNhomQuyen = "sp_selectNhomQuyen";
            public string selectChiTietQuyen = "exec sp_selectChiTietQuyen @TenNhomQuyen";
            public string updateChiTietQuyen = "exec sp_updateChiTietQuyen @TenNhomQuyen,@TenForm ,@QuyenThem ,@QuyenSua ,@QuyenXoa ,@QuyenXem ,@SaoLuuDuLieu ,@CapNhatDuLieu ";
            public string insertNhomQuyen = "exec sp_insertNhomQuyen @TenNhomQuyen";
            public string deleteNhomQuyen = "exec sp_deleteNhomQuyen @TenNhomQuyen";
            public string insertTaiKhoan = "exec sp_insertTaiKhoan @TenDangNhap ,@MatKhauDangNhap ,@KhoaTaiKhoan ,@NhanVienID ,@Administrator ,@TenNhomQuyen ";
            public string updateTaiKhoan = "exec sp_updateTaiKhoan @TenDangNhap ,@MatKhauDangNhap ,@KhoaTaiKhoan ,@NhanVienID ,@Administrator ,@TenNhomQuyen ";
            public string deleteTaiKhoan = "exec sp_deleteTaiKhoan @TenDangNhap";
            public string selectBCTonKhoTheoKhoTheoMa = "exec sp_BCTonKhoTheoKhoTheoMa @MaKho";
            public string SelectBCTonKhoTheoKho ="exec sp_BCTonKhoTheoKho";
            public string selectBCTonKhoTheoNhomHangTheoMa = "exec sp_BCTonKhoTheoNhomHangTheoMa @MaNhomHang";
            public string selectBCTonKhoTheoNhomHang = "exec sp_BCTonKhoTheoNhomHang";
            public string selectTheVipTheoMaKhachHang = "exec sp_selectTheVipTheoMaKhachHang @MaKhachHang";
            public string selectTheVipAll = "exec sp_selectTheVipAll";
            public string insertTheVip = "exec sp_insertTheVip @MaKhachHang ,@MaThe ,@GiaTriThe ,@GiaTriConLai ,@GhiChu,@SoDiem";
            public string updateTheVip = "exec sp_updateGiaTriConLaiTheVip @MaThe ,@GiaTriConLai";
            public string deleteTheVip = "exec sp_deleteTheVip @MaThe";
            #endregion
        }
        #region Hưởng
        public class BCTonKhoTheoNhomHang
        {
            public string MaNhomHang = "MaNhomHang";
            public string TenNhomHang = "TenNhomHang";
            public string MaHangHoa = "MaHangHoa";
            public string TenHangHoa = "TenHangHoa";
            public string TenKho = "TenKho";
            public string HanSuDung = "HanSuDung";
            public string SoLuong = "SoLuong";
            public string HanhDong = "HanhDong";
        }
        public class BCTonKhoTheoKho
        {
            public string MaKho = "MaKho";
            public string TenKho = "TenKho";
            public string MaHangHoa = "MaHangHoa";
            public string TenHangHoa = "TenHangHoa";
            public string NgayNhap = "NgayNhap";
            public string HanSuDung = "HanSuDung";
            public string SoLuong = "SoLuong";
            public string HanhDong = "HanhDong";
        }
        public class TaiKhoan
        {
            public TaiKhoan() { }
            public string TenDangNhap = "TenDangNhap";
            public string MatKhauDangNhap = "MatKhauDangNhap";
            public string KhoaTaiKhoan = "KhoaTaiKhoan";
            public string NhanVienID = "NhanVienID";
            public string Administrator = "Administrator";
            public string TenNhomQuyen = "TenNhomQuyen";
            public string TenNhanVien = "TenNhanVien";
        }
        public class NhomQuyen
        {
            public NhomQuyen() { }
            public string NhomQuyenID = "NhomQuyenID";
            public string TenNhomQuyen = "TenNhomQuyen";
            public string isDeleted = "isDeleted";
        }
        public class ChiTietQuyen
        {
            public ChiTietQuyen() { }
            public string TenNhomQuyen = "TenNhomQuyen";
            public string TenForm = "TenForm";
            public string Ten = "Ten";
            public string QuyenThem = "QuyenThem";
            public string QuyenSua = "QuyenSua";
            public string QuyenXoa = "QuyenXoa";
            public string QuyenXem = "QuyenXem";
            public string SaoLuuDuLieu = "SaoLuuDuLieu";
            public string CapNhatDuLieu = "CapNhatDuLieu";
        }
        public class Quyen
        {
            public Quyen() { }
            public string QuyenID = "QuyenID";
            public string TenForm = "TenForm";
            public string Ten = "Ten";
        }
        #endregion

        #region UserCase - Sơn
        public class NhanVien
        {
            public NhanVien()
            {
            }
            public string HanhDong = "HanhDong";
            public string NhanVienID = "NhanVienID";
            public string MaNhanVien = "MaNhanVien";
            public string TenNhanVien = "TenNhanVien";
            public string MaPhongBan = "MaPhongBan";
            public string DCThuongTru = "DCThuongTru";
            public string DCTamTru = "DCTamTru";
            public string DienThoaiCD = "DienThoaiCD";
            public string DienThoaiDD = "DienThoaiDD";
            public string Email = "Email";
            public string CMND = "CMND";
            public string NgayCap = "NgayCap";
            public string NoiCap = "NoiCap";
            public string NgaySinh = "NgaySinh";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        public class PhongBan
        {
            public PhongBan()
            {
            }
            public string HanhDong = "HanhDong";
            public string PhongBanID = "PhongBanID";
            public string MaPhongBan = "MaPhongBan";
            public string TenPhongBan = "TenPhongBan";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        public class SoDuKho
        {
            public SoDuKho()
            {
            }
            public string HanhDong = "HanhDong";
            public string SoDuKhoID = "SoDuKhoID";
            public string MaSoDuKho = "MaSoDuKho";
            public string MaKho = "MaKho";
            public string MaHangHoa = "MaHangHoa";
            public string SoDuDauKy = "SoDuDauKy";
            public string NgayKetChuyen = "NgayKetChuyen";
            public string SoDuCuoiKy = "SoDuCuoiKy";
            public string TrangThai = "TrangThai";
        }

        public class CapNhatGia
        {
            public CapNhatGia()
            {
            }
            public string HanhDong = "HanhDong";
            public string CapNhatGiaID = "CapNhatGiaID";
            public string MaCapNhatGia = "MaCapNhatGia";
            public string NgayBatDau = "NgayBatDau";
            public string NgayKetThuc = "NgayKetThuc";
            public string MaHangHoa = "MaHangHoa";
            public string PhanTramGiaBanBuon = "PhanTramGiaBanBuon";
            public string PhanTramGiaBanLe = "PhanTramGiaBanLe";
            public string GiaNhap = "GiaNhap";
            public string Trangthai = "Trangthai";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        public class NhomTKKeToan
        {
            public NhomTKKeToan()
            {
            }
            public string HanhDong = "HanhDong";
            public string NhomTKKeToanID = "NhomTKKeToanID";
            public string MaNhomTKKeToan = "MaNhomTKKeToan";
            public string TenNhomTKKeToan = "TenNhomTKKeToan";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        public class TienTe
        {
            public TienTe()
            {

            }
            public string HanhDong = "HanhDong";
            public string TienteID = "TienteID";
            public string MaTienTe = "MaTienTe";
            public string TenTienTe = "TenTienTe";
            public string TenTienTeChan = "TenTienTeChan";
            public string TenTienTeLe = "TenTienTeLe";
            public string BieuTuong = "BieuTuong";
            public string DonViLamTron = "DonViLamTron";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        public class TKKeToan
        {
            public TKKeToan()
            {
            }
            public string HanhDong = "HanhDong";
            public string TKKeToanID = "TKKeToanID";
            public string MaTKKeToan = "MaTKKeToan";
            public string TenTaiKhoan = "TenTaiKhoan";
            public string MaNhomTKKT = "MaNhomTKKeToan";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        public class TKNganHang
        {
            public TKNganHang() { }
            public string HanhDong = "HanhDong";
            public string TKNganHangID = "TKNganHangID";
            public string MaTKNganHang = "MaTKNganHang";
            public string SoTK = "SoTK";
            public string MaTienTe = "MaTienTe";
            public string SoDu = "SoDu";
            public string SoSecKeTiep = "SoSecKeTiep";
            public string NguoiLienHe = "NguoiLienHe";
            public string DiaChi = "DiaChi";
            public string DienThoai = "DienThoai";
            public string Email = "Email";
            public string Website = "Website";
            public string Laisuat = "Laisuat";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        public class KMThuChi
        {
            public KMThuChi() { }
            public string HanhDong = "HanhDong";
            public string ThuChiID = "ThuChiID";
            public string MaKhoanMuc = "MaKhoanMuc";
            public string TenKhoanMuc = "TenKhoanMuc";
            public string NoTK = "NoTK";
            public string CoTK = "CoTK";
            public string LoaiKM = "LoaiKM";
            public string DoiTuong = "DoiTuong";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        public class PhieuDieuChuyenKhoNoiBo
        {
            public PhieuDieuChuyenKhoNoiBo() { }
            public string HanhDong = "HanhDong";
            public string PhieuDieuChuyenKhoID = "PhieuDieuChuyenKhoID";
            public string MaPhieuDieuChuyenKho = "MaPhieuDieuChuyenKho";
            public string NgayDieuChuyen = "NgayDieuChuyen";
            public string TuKho = "TuKho";
            public string DenKho = "DenKho";
            public string MaHoaDonNhap = "MaHoaDonNhap";
            public string XacNhan = "XacNhan";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        public class ChiTietPhieuDieuChuyenKho
        {
            public ChiTietPhieuDieuChuyenKho() { }
            public string HanhDong = "HanhDong";
            public string MaPhieuDieuChuyenKho = "MaPhieuDieuChuyenKho";
            public string MaHangHoa = "MaHangHoa";
            public string SoLuong = "SoLuong";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        #endregion
        #region User Case - Hòa
        public class TheGiamGia
        {
            public TheGiamGia() { }
            public string HanhDong = "HanhDong";
            public string MaKhachHang = "MaKhachHang";
            public string MaTheGiamGia = "MaTheGiamGia";
            public string GiaTriThe = "GiaTriThe";
            public string GiaTriConLai = "GiaTriConLai";
            public string NgayBatDau = "NgayBatDau";
            public string NgayKetThuc = "NgayKetThuc";
            public string Deleted = "Deleted";
        }
        public class TheVip
        {
            public TheVip() { }
            public string HanhDong = "HanhDong";
            public string MaKhachHang = "MaKhachHang";
            public string MaThe = "MaThe";
            public string GiaTriThe = "GiaTriThe";
            public string GiaTriConLai = "GiaTriConLai";
            public string GhiChu = "GhiChu";
            public string SoDiem = "SoDiem";
            public string Deleted = "Deleted";
        }
        public class BCHDBanBuon
        {
            public BCHDBanBuon() { }
            public string HanhDong = "HanhDong";
            public string MaHDBanHang = "MaHDBanHang";
            public string NguoiNhanHang = "NguoiNhanHang";
            public string TenHangHoa = "TenHangHoa";
            public string SoLuong = "SoLuong";
            public string NgayBan = "NgayBan";
            public string GiaBanBuon = "GiaBanBuon";
            public string TongTienThanhToan = "TongTienThanhToan";
        }
        public class BCHDBanLe
        {
            public BCHDBanLe() { }
            public string HanhDong = "HanhDong";
            public string MaHDBanHang = "MaHDBanHang";
            public string TenHangHoa = "TenHangHoa";
            public string SoLuong = "SoLuong";
            public string GiaBanLe = "GiaBanLe";
            public string TongTienThanhToan = "TongTienThanhToan";
        }
        public class BCDTTheoNhanVien
        {
            public BCDTTheoNhanVien() { }
            public string HanhDong = "HanhDong";
            public string MaNhanVien = "MaNhanVien";
            public string TenNhanVien = "TenNhanVien";
            public string MaHDBanHang = "MaHDBanHang";
            public string NgayBan = "NgayBan";
            public string ThanhToanNgay = "ThanhToanNgay";
            public string ThanhToanKhiLapPhieu = "ThanhToanKhiLapPhieu";
        }
        public class BCDTTheoThoiGian
        {
            public BCDTTheoThoiGian() { }
            public string HanhDong = "HanhDong";
            public string MaHDBanHang = "MaHDBanHang";
            public string NgayBan = "NgayBan";
            public string ThanhToanNgay = "ThanhToanNgay";
            public string ThanhToanKhiLapPhieu = "ThanhToanKhiLapPhieu";
        }
        public class BCDTTheoNhomHang
        {
            public BCDTTheoNhomHang() { }
            public string HanhDong = "HanhDong";
            public string MaNhomHang = "MaNhomHang";
            public string TenNhomHang = "TenNhomHang";
            public string MaHangHoa = "MaHangHoa";
            public string NgayBan = "NgayBan";
            public string TenHangHoa = "TenHangHoa";
            public string MaHDBanHang = "MaHDBanHang";
            public string ThanhToanNgay = "ThanhToanNgay";
        }
        public class BCDTTheoHangHoa
        {
            public BCDTTheoHangHoa() { }
            public string HanhDong = "HanhDong";
            public string MaHangHoa = "MaHangHoa";
            public string TenHangHoa = "TenHangHoa";
            public string NgayBan = "NgayBan";
            public string MaHDBanHang = "MaHDBanHang";
            public string ThanhToanNgay = "ThanhToanNgay";
        }
        public class Thue
        {
            public Thue() { }
            public string HanhDong = "HanhDong";
            public string ThueID = "ThueID";
            public string MaThue = "MaThue";
            public string TenThue = "TenThue";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";

        }
        public class HDBanHang
        {
            public HDBanHang() { }
            public string HanhDong = "HanhDong";
            public string HDBanHangID = "HDBanHangID";
            public string MaHDBanHang = "MaHDBanHang";
            public string MaKhachHang = "MaKhachHang";
            public string NgayBan = "NgayBan";
            public string NoHienThoi = "NoHienThoi";
            public string NguoiNhanHang = "NguoiNhanHang";
            public string HinhThucThanhToan = "HinhThucThanhToan";
            public string MaKho = "MaKho";
            public string DieuKienThanhToan = "DieuKienThanhToan";
            public string HanThanhToam = "HanThanhToam";
            public string MaDonDatHang = "MaDonDatHang";
            public string MaNhanVien = "MaNhanVien";
            public string QuayThuNganID = "QuayThuNganID";
            public string MaTienTe = "MaTienTe";
            public string ChietKhau = "ChietKhau";
            public string ThanhToanNgay = "ThanhToanNgay";
            public string ThueGTGT = "ThueGTGT";
            public string TongTienThanhToan = "TongTienThanhToan";
            public string ThanhToanKhiLapPhieu = "ThanhToanKhiLapPhieu";
            public string LoaiHoaDon = "LoaiHoaDon";
            public string MaThe = "MaThe";
            public string GiaTriThe = "GiaTriThe";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
            public string KhachTra = "KhachTra";
            public string ChietKhauTongHoaDon = "ChietKhauTongHoaDon";
            public string MaTheGiaTri = "MaTheGiaTri";
            public string GiaTriTheGiaTri = "GiaTriTheGiaTri";
        }
        public class ChiTietHDBanHang
        {
            public ChiTietHDBanHang() { }
            public string HanhDong = "HanhDong";
            public string MaHDBanHang = "MaHDBanHang";
            public string MaHangHoa = "MaHangHoa";
            public string TenHangHoa = "TenHangHoa";
            public string SoLuong = "SoLuong";
            public string DonGia = "DonGia";
            public string Thue = "Thue";
            public string PhanTramChietKhau = "PhanTramChietKhau";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        public class PhieuTTCuaKH
        {
            public PhieuTTCuaKH()
            {
            }

            public string HanhDong = "HanhDong";
            public string PhieuTTCuaKHID = "PhieuTTCuaKHID";
            public string MaPhieuTTCuaKH = "MaPhieuTTCuaKH";
            public string NgayLap = "NgayLap";
            public string MaKhachHang = "MaKhachHang";
            public string NoHienThoi = "NoHienThoi";
            public string NguoiNop = "NguoiNop";
            public string MaTienTe = "MaTienTe";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        public class ChiTietPhieuTTCuaKH
        {
            public ChiTietPhieuTTCuaKH()
            {
            }
            public string HanhDong = "HanhDong";
            public string MaHDBanHang = "MaHDBanHang";
            public string MaPhieuTTCuaKH = "MaPhieuTTCuaKH";
            public string TongTien = "TongTien";
            public string TienNo = "TienNo";
            public string ThanhToan = "ThanhToan";
            public string TrangThai = "TrangThai";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        public class PhieuTTNCC
        {
            public PhieuTTNCC()
            {
            }
            public string HanhDong = "HanhDong";
            public string PhieuTTNCCID = "PhieuTTNCCID";
            public string MaPhieuTTNCC = "MaPhieuTTNCC";
            public string NgayLap = "NgayLap";
            public string MaNCC = "MaNCC";
            public string NoHienThoi = "NoHienThoi";
            public string Nguoinhan = "Nguoinhan";
            public string MaTienTe = "MaTienTe";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        public class ChiTietPhieuTTNCC
        {
            public ChiTietPhieuTTNCC()
            {
            }
            public string HanhDong = "HanhDong";
            public string MaHoaDonNhap = "MaHoaDonNhap";
            public string MaPhieuTTNCC = "MaPhieuTTNCC";
            public string TongTien = "TongTien";
            public string TienNo = "TienNo";
            public string ThanhToan = "ThanhToan";
            public string TrangThai = "TrangThai";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        public class PhieuXuatHuy
        {
            public PhieuXuatHuy()
            {
            }
            public string HanhDong = "HanhDong";
            public string PhieuXuatHuyID = "PhieuXuatHuyID";
            public string MaPhieuXuatHuy = "MaPhieuXuatHuy";
            public string NgayLap = "NgayLap";
            public string MaNhanVien = "MaNhanVien";
            public string MaKho = "MaKho";
            public string TrangThai = "TrangThai";
            public string Tongtien = "Tongtien";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        public class ChiTietXuatHuy
        {
            public ChiTietXuatHuy()
            {
            }
            public string HanhDong = "HanhDong";
            public string MaPhieuXuatHuy = "MaPhieuXuatHuy";
            public string MaHangHoa = "MaHangHoa";
            public string SoLuong = "SoLuong";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        public class PhieuThu
        {
            public PhieuThu()
            {
            }
            public string HanhDong = "HanhDong";
            public string PhieuThuID = "PhieuThuID";
            public string MaPhieuThu = "MaPhieuThu";
            public string NgayLap = "NgayLap";
            public string LoaiPhieu = "LoaiPhieu";
            public string MaKho = "MaKho";
            public string MaNhomHang = "MaNhomHang";
            public string KhoanMuc = "KhoanMuc";
            public string DoiTuong = "DoiTuong";
            public string NguoiNopTien = "NguoiNopTien";
            public string NguoiNhanTien = "NguoiNhanTien";
            public string MaTKNganHang = "MaTKNganHang";
            public string NoTaiKhoan = "NoTaiKhoan";
            public string CoTaiKhoan = "CoTaiKhoan";
            public string TongTienThanhToan = "TongTienThanhToan";
            public string MaTienTe = "MaTienTe";
            public string TrangThai = "TrangThai";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        public class SoQuy
        {
            public SoQuy() { }
            public string HanhDong = "HanhDong";
            public string SoDuSoQuyID = "SoDuSoQuyID";
            public string MaSoDuSoQuy = "MaSoDuSoQuy";
            public string SoDuDauKy = "SoDuDauKy";
            public string NgayKetChuyen = "NgayKetChuyen";
            public string SoDuCuoiKy = "SoDuCuoiKy";
            public string TrangThai = "TrangThai";
        }
        public class CongNo
        {
            public CongNo() { }
            public string HanhDong = "HanhDong";
            public string SoDuCongNoID = "SoDuCongNoID";
            public string MaSoDuCongNo = "MaSoDuCongNo";
            public string MaDoiTuong = "MaDoiTuong";
            public string TenDoiTuong = "TenDoiTuong";
            public string DiaChi = "DiaChi";
            public string SoDuDauKy = "SoDuDauKy";
            public string NgayKetChuyen = "NgayKetChuyen";
            public string SoDuCuoiKy = "SoDuCuoiKy";
            public string LoaiDoiTuong = "LoaiDoiTuong";
            public string TrangThai = "TrangThai";
        }
        public class QuayThuNgan
        {
            public QuayThuNgan() { }
            public string HanhDong = "HanhDong";
            public string QuayThuNganID = "QuayThuNganID";
            public string TenQuayThuNgan = "TenQuayThuNgan";
            public string DiaDiem = "DiaDiem";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        #endregion
        #region User Case - Hương
        /// <summary>
        /// phần use case của Hương
        /// </summary>
        //----------------BCChiTietHangHoa---------
        public class BCChiTietHangHoa
        {
            public BCChiTietHangHoa()
            { }
            public string HanhDong = "HanhDong";
            public string MaHangHoa = "MaHangHoa";
            public string TenNhomHang = "TenNhomHang";
            public string TenHangHoa = "TenHangHoa";
            public string TenDonViTinh = "TenDonViTinh";
            public string GiaNhap = "GiaNhap";
            public string GiaBanBuon = "GiaBanBuon";
            public string GiaBanLe = "GiaBanLe";
            public string MucDatHang = "MucDatHang";
            public string MucTonToiThieu = "MucTonToiThieu";
        }
        //--------------- quy đổi đơn vị tính -----------
        public class QuyDoiDonViTinh
        {
            public QuyDoiDonViTinh()
            { }
            public const string HanhDong = "HanhDong";
            public const string QuyDoiDonViTinhID = "QuyDoiDonViTinhID";
            public const string MaQuyDoiDonViTinh = "MaQuyDoiDonViTinh";
            public const string MaHangQuyDoi = "MaHangQuyDoi";
            public const string TenHangQuyDoi = "TenHangQuyDoi";
            public const string MaDonViTinh = "MaDonViTinh";
            public const string SoLuongQuyDoi = "SoLuongQuyDoi";
            public const string MaHangDuocQuyDoi = "MaHangDuocQuyDoi";
            public const string TenHangDuocQuyDoi = "TenHangDuocQuyDoi";
            public const string MaDonViTinhDuocQuyDoi = "MaDonViTinhDuocQuyDoi";
            public const string SoLuongDuocQuyDoi = "SoLuongDuocQuyDoi";
            public const string Deleted = "Deleted";


        }
        //---------------- chi tiết gói hàng -----
        public class ChiTietGoiHang
        {
            public ChiTietGoiHang()
            { }
            public const string HanhDong = "HanhDong";
            public const string ChiTietGoiHangID = "ChiTietGoiHangID";
            public const string MaGoiHang = "MaGoiHang";
            public const string MaHangHoa = "MaHangHoa";
            public const string TenHangHoa = "TenHangHoa";
            public const string SoLuong = "SoLuong";
            public const string GiaNhap = "GiaNhap";
            public const string GiaBanBuon = "GiaBanBuon";
            public const string GiaBanLe = "GiaBanLe";
        }
        //---------------- gói Hàng ---------
        public class GoiHang
        {
            public GoiHang()
            { }
            public const string HanhDong = "HanhDong";
            public const string GoiHangID = "GoiHangID";
            public const string MaKho = "MaKho";
            public const string MaGoiHang = "MaGoiHang";
            public const string TenGoiHang = "TenGoiHang";
            public const string MaNhomHang = "MaNhomHang";
            public const string TenNhomHang = "TenNhomHang";
            public const string GiaNhap = "GiaNhap";
            public const string GiaBanBuon = "GiaBanBuon";
            public const string GiaBanLe = "GiaBanLe";
            public const string Deleted = "Deleted";
        }
        //-----------------Thuế--------------
        public class ThueH
        {
            public ThueH()
            { }
            public string HanhDong = "HanhDong";
            public string ThueID = "ThueID";
            public string MaThue = "MaThue";
            public string GiaTriThue = "GiaTriThue";
            public string TenThue = "TenThue";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        //--------------DonHangNCC------------
        public class DonHangNCC
        {
            public DonHangNCC()
            { }
            public string HanhDong = "HanhDong";
            public string MaNhaCungCap = "MaNhaCungCap";
            public string MaDonDatHang = "MaDonDatHang";
            public string NgayDonHang = "NgayDonHang";
            public string TrangThaiDonDatHang = "TrangThaiDonDatHang";
            public string HinhThucThanhToan = "HinhThucThanhToan";
            public string TongTien = "TongTien";
        }
        //-------------hàng hóa NCC--------
        public class HangHoaNCC
        {
            public HangHoaNCC()
            { }
            public string HanhDong = "HanhDong";
            public string MaNhaCungCap = "MaNhaCungCap";
            public string MaHangHoa = "MaHangHoa";
            public string TenHangHoa = "TenHangHoa";
            public string MaDonViTinh = "MaDonViTinh";
            public string SoLuong = "SoLuong";
            public string ThueGTGT = "ThueGTGT";
            public string TongTien = "TongTien";
        }
        //--------------Công Ty------------------
        public class CongTy
        {
            public CongTy()
            { }
            public string HanhDong = "HanhDong";
            public string CongTyID = "CongTyID";
            public string MaCongTy = "MaCongTy";
            public string TenCongTy = "TenCongTy";
            public string DiaChi = "DiaChi";
            public string SoDienThoai = "SoDienThoai";
            public string Email = "Email";
            public string Website = "Website";
            public string Fax = "Fax";
        }
        //---------------------Nhà Sản xuất--------------
        public class NhaSX
        {
            public NhaSX()
            {
            }
            public string HanhDong = "HanhDong";
            public string NhaSXID = "NhaSXID";
            public string MaNhaSX = "MaNhaSX";
            public string TenNhaSX = "TenNhaSX";
            public string TenLH = "TenLH";
            public string DiaChi = "DiaChi";
            public string DienThoai = "DienThoai";
            public string Fax = "Fax";
            public string Email = "Email";
            public string WebSite = "WebSite";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        /// <summary>
        /// hương ------------------Nhóm Khách hàng
        /// </summary>
        public class NhomKH
        {
            public NhomKH()
            {
            }
            public string HanhDong = "HanhDong";
            public string NhomKHID = "NhomKHID";
            public string MaNhomKH = "MaNhomKH";
            public string TenNhomKH = "TenNhomKH";
            public string LoaiKH = "LoaiKH";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        /// <summary>
        /// hương---------------------Khách Hàng
        /// </summary>
        public class KhachHang
        {
            public KhachHang()
            {
            }
            public string HanhDong = "HanhDong";
            public string KhachHangID = "KhachHangID";
            public string MaKH = "MaKH";
            public string Ten = "Ten";
            public string DiaChi = "DiaChi";
            public string DienThoai = "DienThoai";
            public string Fax = "Fax";
            public string Email = "Email";
            public string MST = "MST";
            public string DuNo = "DuNo";
            public string HanMucTT = "HanMucTT";
            public string CongTy = "CongTy";
            public string NgaySinh = "NgaySinh";
            public string MaVung = "MaVung";
            public string Mobi = "Mobi";
            public string Ngaythamgia = "Ngaythamgia";
            public string Giaodichcuoi = "Giaodichcuoi";
            public string Ngungtheodoi = "Ngungtheodoi";
            public string Website = "Website";
            public string Ngaysua = "Ngaysua";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        /// <summary>
        /// hương-----------------Nhà Cung Cấp-------------
        /// </summary>
        public class NhaCungCap
        {
            public NhaCungCap()
            {
            }
            public string HanhDong = "HanhDong";
            public string NhaCungCapID = "NhaCungCapID";
            public string MaNhaCungCap = "MaNhaCungCap";
            public string TenNhaCungCap = "TenNhaCungCap";
            public string DiaChi = "DiaChi";
            public string DienThoai = "DienThoai";
            public string Email = "Email";
            public string Fax = "Fax";
            public string NguoiLienHe = "NguoiLienHe";
            public string MST = "MST";
            public string DuNo = "DuNo";
            public string Website = "Website";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        /// <summary>
        /// đơn hàng
        /// </summary>
        public class DonHang
        {
            public DonHang()
            {

            }
            public string HanhDong = "HanhDong";
            public string MaKhachHang = "MaKhachHang";
            public string MaDonDatHang = "MaDonDatHang";
            public string NgayDonHang = "NgayDonHang";
            public string HinhThucThanhToan = "HinhThucThanhToan";
            public string GhiChu = "GhiChu";
            public string TongTienThanhToan = "TongTienThanhToan";
        }
        /// <summary>
        /// xuất hủy
        /// </summary>
        public class XuatHang
        {
            public XuatHang()
            {

            }
            public string HanhDong = "HanhDong";
            public string MaKhachHang = "MaKhachHang";
            public string MaHDBanHang = "MaHDBanHang";
            public string NgayBan = "NgayBan";
            public string HinhThucThanhToan = "HinhThucThanhToan";
            public string GhiChu = "GhiChu";
            public string TongTienThanhToan = "TongTienThanhToan";
        }
        /// <summary>
        /// trả lại
        /// </summary>
        public class TraLai
        {
            public TraLai()
            {

            }
            public string HanhDong = "HanhDong";
            public string MaKhachHang = "MaKhachHang";
            public string MaKhachHangTraLai = "MaKhachHangTraLai";
            public string NgayNhap = "NgayNhap";
            public string HinhThucThanhToan = "HinhThucThanhToan";
            public string GhiChu = "GhiChu";
            public string ThanhToanNgay = "ThanhToanNgay";
        }
        /// <summary>
        /// thanh toán
        /// </summary>
        public class ThanhToan
        {
            public ThanhToan()
            {

            }
            public string HanhDong = "HanhDong";
            public string MaKhachHang = "MaKhachHang";
            public string MaPhieuTTCuaKH = "MaPhieuTTCuaKH";
            public string NgayLap = "NgayLap";
            public string TrangThai = "TrangThai";
            public string GhiChu = "GhiChu";
            public string Thanhtoan = "ThanhToan";
        }
        /// <summary>
        /// hàng hóa
        /// </summary>
        public class LSGDHangHoa
        {
            public LSGDHangHoa()
            {

            }
            public string HanhDong = "HanhDong";
            public string MaKhachHang = "MaKhachHang";
            public string MaHangHoa = "MaHangHoa";
            public string TenHangHoa = "TenHangHoa";
            public string MaDonViTinh = "MaDonViTinh";
            public string SoLuong = "SoLuong";
            public string MaThueGiaTriGiaTang = "MaThueGiaTriGiaTang";
            public string TongTienThanhToan = "TongTienThanhToan";
        }
        /// <summary>
        /// theo hàng hóa
        /// </summary>
        public class TheoHangHoa
        {
            public TheoHangHoa()
            {

            }
            public string HanhDong = "HanhDong";
            public string MaHangHoa = "MaHangHoa";
            public string NgayBatDau = "NgayBatDau";
            public string NgayKetThuc = "NgayKetThuc";
            public string GiaBanBuon = "GiaBanBuon";
            public string GiaBanLe = "GiaBanLe";
            public string GhiChu = "GhiChu";
        }
        /// <summary>
        /// theo nhóm hàng
        /// </summary>
        public class TheoNhomHang
        {
            public TheoNhomHang()
            {

            }
            public string HanhDong = "HanhDong";
            public string MaNhomHangHoa = "MaNhomHangHoa";
            public string KieuHangHoa = "KieuHangHoa";
            public string NgayBatDau = "NgayBatDau";
            public string NgayKetThuc = "NgayKetThuc";
            public string GhiChu = "GhiChu";
        }
        /// <summary>
        /// nhập mua
        /// </summary>
        public class LSGDNhapMua
        {
            public LSGDNhapMua()
            {

            }
            public string HanhDong = "HanhDong";
            public string MaNhaCungCap = "MaNhaCungCap";
            public string MaHoaDonNhap = "MaHoaDonNhap";
            public string NgayNhap = "NgayNhap";
            public string HinhThucThanhToan = "HinhThucThanhToan";
            public string GhiChu = "GhiChu";
            public string TongTien = "TongTien";
        }
        /// <summary>
        /// trả lại NCC
        /// </summary>
        public class LSGDTraLaiNCC
        {
            public LSGDTraLaiNCC()
            {

            }
            public string HanhDong = "HanhDong";
            public string MaNhaCungCap = "MaNhaCungCap";
            public string MaHDTraLaiNCC = "MaHDTraLaiNCC";
            public string Ngaytra = "Ngaytra";
            public string HinhThucThanhToan = "HinhThucThanhToan";
            public string GhiChu = "GhiChu";
            public string ThanhToanNgay = "ThanhToanNgay";
        }
        /// <summary>
        /// thanh toán NCC
        /// </summary>
        public class LSGDTTNCC
        {
            public LSGDTTNCC()
            {

            }
            public string HanhDong = "HanhDong";
            public string MaNhaCungCap = "MaNhaCungCap";
            public string MaPhieuTTNCC = "MaPhieuTTNCC";
            public string NgayLap = "NgayLap";
            public string TrangThai = "TrangThai";
            public string GhiChu = "GhiChu";
            public string ThanhToan = "ThanhToan";
        }
        /// <summary>
        /// cập nhật giá khách hàng
        /// </summary>
        public class CapNhatGiaKH
        {
            public CapNhatGiaKH()
            {

            }
            public string HanhDong = "HanhDong";
            public string CapNhatGiaKhachHangID = "CapNhatGiaKhachHangID";
            public string MaCapNhatGiaKhachHang = "MaCapNhatGiaKhachHang";
            public string MaHangHoa = "MaHangHoa";
            public string MaKhachHang = "MaKhachHang";
            public string NgayBatDau = "NgayBatDau";
            public string NgayKetThuc = "NgayKetThuc";
            public string PhanTramChietKhau = "PhanTramChietKhau";
            public string Deleted = "Deleted";
        }
        /// <summary>
        /// báo cáo nhập hàng theo mặt hàng
        /// </summary>
        public class BaoCapNhapHangTheoMatHang
        {
            public BaoCapNhapHangTheoMatHang()
            {

            }
            public string HanhDong = "HanhDong";
            public string MaKho = "MaKho";
            public string MaHoaDonNhap = "MaHoaDonNhap";
            public string TenHangHoa = "TenHangHoa";
            public string NgayNhap = "NgayNhap";
            public string SoLuong = "SoLuong";
            public string TongTien = "TongTien";
        }
        /// <summary>
        /// báo cáo nhập hàng theo nhóm hàng
        /// </summary>
        public class BaoCapNhapHangTheoNhomHang
        {
            public BaoCapNhapHangTheoNhomHang()
            {

            }
            public string HanhDong = "HanhDong";
            public string MaNhomHang = "MaNhomHang";
            public string TenKho = "TenKho";
            public string TenHangHoa = "TenHangHoa";
            public string NgayNhap = "NgayNhap";
            public string SoLuong = "Soluong";
            public string TongTien = "TongTien";
        }
        #endregion

        #region hungvv=======================================================================================================================
        public class BienChung
        {
            public BienChung() { }
            //ma hang hoa
            public string MaHangHoa = "MaHangHoa";
        }
        /// <summary>
        /// hungvv ===========================================================
        /// </summary>
        public class SelectID
        {
            public SelectID() { }
            public string ColumnNameID = "ColumnNameID";
        }
        /// <summary>
        /// hungvv ===========================================================
        /// </summary>
        public class ThongTinDatHang
        {
            public ThongTinDatHang() { }

            public string MaHangHoa = "MaHangHoa";
            public string TenHangHoa = "TenHangHoa";
            public string GiaNhap = "GiaNhap";
        }
        /// <summary>
        /// hungvv ===========================================================
        /// </summary>
        public class ThongTinMaDonDatHang
        {
            public ThongTinMaDonDatHang() { }

            public string MaDonDatHang = "MaDonDatHang";
            public string NgayDonHang = "NgayDonHang";
            public string SoLuong = "SoLuong";
            public string GiaNhap = "GiaNhap";
            public string PhanTramChietKhau = "PhanTramChietKhau";
        }
        /// <summary>
        ///  hungvv ===========================================================
        /// </summary>
        public class HienThi_ChiTiet_DonDatHang
        {
            public string maHangHoa = "MaHangHoa";
            public string tenHangHoa = "TenHangHoa";
            public string soLuongDat = "SoLuong";
            public string giaGoc = "GiaNhap";
            public string phanTramChietKhau = "PhanTramChietKhau";
            public string MaDonDatHang = "MaDonDatHang";
            public string MaKhachHang = "MaKhachHang";
        }
        /// <summary>
        /// hungvv ===========================================================
        /// </summary>
        public class ThongTinNhanVien
        {
            public ThongTinNhanVien() { }

            public string MaNhanVien = "MaNhanVien";
            public string TenNhanVien = "TenNhanVien";
        }
        /// <summary>
        /// hungvv ===========================================================
        /// </summary>
        public class ThongTinNhaCungCap
        {
            public ThongTinNhaCungCap() { }

            public string MaNhaCungCap = "MaNhaCungCap";
            public string TenNhaCungCap = "TenNhaCungCap";
            public string DiaChi = "DiaChi";
        }
        /// <summary>
        /// hungvv ===========================================================
        /// </summary>
        public class ThongTinKhachHang
        {
            public ThongTinKhachHang() { }

            public string MaKH = "MaKH";
            public string Ten = "Ten";
            public string DiaChi = "DiaChi";
        }
        /// <summary>
        /// vuong van hung  ============DonDatHang=============
        /// </summary>
        public class DonDatHang
        {
            public DonDatHang() { }

            public string HanhDong = "HanhDong";
            public string DonDatHangID = "DonDatHangID";
            public string MaDonDatHang = "MaDonDatHang";
            public string LoaiDonDatHang = "LoaiDonDatHang";
            public string NgayDonHang = "NgayDonHang";
            public string MaNhaCungCap = "MaNhaCungCap";
            public string NoHienThoi = "NoHienThoi";
            public string TrangThaiDonDatHang = "TrangThaiDonDatHang";
            public string NgayNhapDuKien = "NgayNhapDuKien";
            public string HinhThucThanhToan = "HinhThucThanhToan";
            public string MaKho = "MaKho";
            public string MaNhanVien = "MaNhanVien";
            public string MaTienTe = "MaTienTe";
            public string ThueGTGT = "ThueGTGT";
            public string Phivanchuyen = "Phivanchuyen";
            public string PhiKhac = "PhiKhac";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
            public string MaKhachHang = "MaKhachHang";
        }

        /// <summary>
        /// vuong van hung  ============ChiTietDonDatHang=============
        /// </summary>
        public class ChiTietDonDatHang
        {
            public ChiTietDonDatHang() { }

            public string HanhDong = "HanhDong";
            public string MaDonDatHang = "MaDonDatHang";
            public string MaHangHoa = "MaHangHoa";
            public string SoLuong = "SoLuong";
            public string PhanTramChietKhau = "PhanTramChietKhau";
            public string DonGia = "DonGia";
            public string Thue = "Thue";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        /// <summary>
        /// vuong van hung ====================HoaDonNhap==================
        /// </summary>
        public class HoaDonNhap
        {
            public HoaDonNhap() { }

            public string HanhDong = "HanhDong";
            public string HoaDonNhapID = "HoaDonNhapID";
            public string MaHoaDonNhap = "MaHoaDonNhap";
            public string NgayNhap = "NgayNhap";
            public string MaNhaCungCap = "MaNhaCungCap";
            public string NoHienThoi = "NoHienThoi";
            public string NguoiGiaoHang = "NguoiGiaoHang";
            public string HinhThucThanhToan = "HinhThucThanhToan";
            public string MaKho = "MaKho";
            public string DieuKienThanhToan = "DieuKienThanhToan";
            public string HanThanhToan = "HanThanhToan";
            public string MaDonDatHang = "MaDonDatHang";
            public string MaTienTe = "MaTienTe";
            public string ChietKhau = "ChietKhau";
            public string ThanhToanNgay = "ThanhToanNgay";
            public string ThueGTGT = "ThueGTGT";
            public string TongTien = "TongTien";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        /// <summary>
        /// vuong hung ====================================chi tiet hoa don nhap ========================================
        /// </summary>
        public class ChiTietHoaDonNhap
        {
            public string HanhDong = "HanhDong";
            public string MaHoaDonNhap = "MaHoaDonNhap";
            public string MaHangHoa = "MaHangHoa";
            public string SoLuong = "SoLuong";
            public string PhanTramChietKhau = "PhanTramChietKhau";
            public string DonGia = "DonGia";
            public string Thue = "Thue";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        /// <summary>
        /// vuong van hung ====================KhachHangTraLai===========================
        /// </summary>
        public class KhachHangTraLai
        {
            public KhachHangTraLai() { }

            public string HanhDong = "HanhDong";
            public string MaKhachHangTraLai = "MaKhachHangTraLai";
            public string NgayNhap = "NgayNhap";
            public string MaKhachHang = "MaKhachHang";
            public string NoHienThoi = "NoHienThoi";
            public string NguoiTra = "NguoiTra";
            public string HinhThucThanhToan = "HinhThucThanhToan";
            public string HanThanhToan = "HanThanhToan";
            public string MaHoaDonMuaHang = "MaHoaDonMuaHang";
            public string MaKho = "MaKho";
            public string MaTienTe = "MaTienTe";
            public string TienBoiThuong = "TienBoiThuong";
            public string ThanhToanNgay = "ThanhToanNgay";
            public string ThueGTGT = "ThueGTGT";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        /// <summary>
        /// vuong hung ==================================chi tiet khach hang tra lai=======================================
        /// </summary>
        public class ChiTietKhachHangTraLai
        {
            public string HanhDong = "HanhDong";
            public string MaKhachHangTraLai = "MaKhachHangTraLai";
            public string MaHangHoa = "MaHangHoa";
            public string SoLuong = "SoLuong";
            public string PhanTramChietKhau = "PhanTramChietKhau";
            public string DonGia = "DonGia";
            public string Thue = "Thue";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
            public string MaKho = "MaKho";
        }

        /// <summary>
        /// vuong van hung ======================TraLaiNhaCungCap=========================
        /// </summary>
        public class TraLaiNhaCungCap
        {
            public TraLaiNhaCungCap() { }

            public string HanhDong = "HanhDong";
            public string TraLaiNCCID = "TraLaiNCCID";
            public string MaHDTraLaiNCC = "MaHDTraLaiNCC";
            public string Ngaytra = "Ngaytra";
            public string MaNCC = "MaNCC";
            public string NoHienThoi = "NoHienThoi";
            public string NguoiNhanHang = "NguoiNhanHang";
            public string HinhThucThanhToan = "HinhThucThanhToan";
            public string DieuKienThanhToan = "DieuKienThanhToan";
            public string MaHoaDonNhap = "MaHoaDonNhap";
            public string MaKho = "MaKho";
            public string MaTienTe = "MaTienTe";
            public string TienBoiThuong = "TienBoiThuong";
            public string ThanhToanNgay = "ThanhToanNgay";
            public string ThueGTGT = "ThueGTGT";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        /// <summary>
        /// vuong hung ==================================chi tiet TraLaiNhaCungCap=======================================
        /// </summary>
        public class ChiTieTraLaiNhaCungCap
        {
            public string HanhDong = "HanhDong";
            public string MaHDTraLaiNCC = "MaHDTraLaiNCC";
            public string MaHangHoa = "MaHangHoa";
            public string SoLuong = "SoLuong";
            public string DonGia = "DonGia";
            public string Thue = "Thue";
            public string PhanTramChietKhau = "PhanTramChietKhau";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        /// <summary>
        /// vuong hung ================================kiem ke kho ==========================================================
        /// </summary>
        public class KiemKeKho
        {
            public string HanhDong = "HanhDong";
            public string PhieuKiemKeKhoID = "PhieuKiemKeKhoID";
            public string MaKiemKe = "MaKiemKe";
            public string NgayKiemKe = "NgayKiemKe";
            public string MaKho = "MaKho";
            public string TenKho = "TenKho";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        /// <summary>
        /// vuong hung ==================================chi tiet kiêm ke kho=======================================
        /// </summary>
        public class ChiTietKiemKeKho
        {
            public string HanhDong = "HanhDong";
            public string MaPhieuKiemKe = "MaPhieuKiemKe";
            public string MaHangHoa = "MaHangHoa";
            public string TenHangHoa = "TenHangHoa";
            public string TonThucTe = "TonThucTe";
            public string TonSoSach = "TonSoSach";
            public string LyDo = "LyDo";
            public string Gia = "GiaNhap";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }
        #endregion

        #region User Case - Luân
        /// <summary>
        /// Phần user case của Luân
        /// </summary>
        /// 
        public class HangHoa
        {
            public HangHoa() { }
            public string HanhDong = "HanhDong";
            public string HangHoaID = "HangHoaID";
            public string MaHangHoa = "MaHangHoa";
            public string MaNhomHangHoa = "MaNhomHangHoa";
            public string TenNhomHangHoa = "TenNhomHangHoa";
            public string TenHangHoa = "TenHangHoa";
            public string MaDonViTinh = "MaDonViTinh";
            public string TenDonViTinh = "TenDonViTinh";
            public string GiaNhap = "GiaNhap";
            public string GiaBanBuon = "GiaBanBuon";
            public string GiaBanLe = "GiaBanLe";
            public string MaThueGiaTriGiaTang = "MaThueGiaTriGiaTang";
            public string TenThueGiaTriGiaTang = "TenThueGiaTriGiaTang";
            public string KieuHangHoa = "KieuHangHoa";
            public string SeriLo = "SeriLo";
            public string MucDatHang = "MucDatHang";
            public string MucTonToiThieu = "MucTonToiThieu";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        public class HangHoaSTATIC
        {
            public static string HanhDong = "HanhDong";
            public static string HangHoaID = "HangHoaID";
            public static string MaHangHoa = "MaHangHoa";
            public static string MaNhomHangHoa = "MaNhomHangHoa";
            public static string TenNhomHangHoa = "TenNhomHangHoa";
            public static string TenHangHoa = "TenHangHoa";
            public static string MaDonViTinh = "MaDonViTinh";
            public static string TenDonViTinh = "TenDonViTinh";
            public static string GiaNhap = "GiaNhap";
            public static string GiaBanBuon = "GiaBanBuon";
            public static string GiaBanLe = "GiaBanLe";
            public static string MaThueGiaTriGiaTang = "MaThueGiaTriGiaTang";
            public static string TenThueGiaTriGiaTang = "TenThueGiaTriGiaTang";
            public static string KieuHangHoa = "KieuHangHoa";
            public static string SeriLo = "SeriLo";
            public static string MucDatHang = "MucDatHang";
            public static string MucTonToiThieu = "MucTonToiThieu";
            public static string GhiChu = "GhiChu";
            public static string Deleted = "Deleted";
        }

        public class NhomHangHoa
        {
            public NhomHangHoa() { }
            public string HanhDong = "HanhDong";
            public string NhomHangID = "NhomHangID";
            public string MaNhomHang = "MaNhomHang";
            public string MaLoaiHang = "MaLoaiHang";
            public string TenNhomHang = "TenNhomHang";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        public class LoaiHangHoa
        {
            public LoaiHangHoa() { }
            public string HanhDong = "HanhDong";
            public string LoaiHangID = "LoaiHangID";
            public string MaLoaiHang = "MaLoaiHang";
            public string TenLoaiHang = "TenLoaiHang";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        public class KhoHang
        {
            public KhoHang() { }
            public string HanhDong = "HanhDong";
            public string KhoHangID = "KhoHangID";
            public string MaKho = "MaKho";
            public string TenKho = "TenKho";
            public string DiaChi = "DiaChi";
            public string DienThoai = "DienThoai";
            public string MaNhanVien = "MaNhanVien";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        public class DVT
        {
            public DVT() { }
            public string HanhDong = "HanhDong";
            public string DVTID = "DVTID";
            public string MaDonViTinh = "MaDonViTinh";
            public string TenDonViTinh = "TenDonViTinh";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        public class LoaiThue
        {
            public LoaiThue() { }
            public string HanhDong = "HanhDong";
            public string LoaiThueID = "LoaiThueID";
            public string MaLoaiThue = "MaLoaiThue";
            public string TenLoaiThue = "TenLoaiThue";
            public string GhiChu = "GhiChu";
            public string Deleted = "Deleted";
        }

        #endregion

    }
}
