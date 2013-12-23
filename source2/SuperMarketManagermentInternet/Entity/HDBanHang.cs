using System;

namespace Entities
{
    [Serializable]
    public class HDBanHang
    {
        private int hDBanHangID;
        private string maHDBanHang;
        private DateTime ngayBan;
        private string maKhachHang;
        private string tenKhachHang;
        private string noHienThoi;
        private string nguoiNhanHang;
        private string hinhThucThanhToan;
        private string maKho;
        private DateTime hanThanhToam;
        private string maDonDatHang;
        private string maNhanVien;
        private string maTienTe;
        private string chietKhau;
        private string thanhToanNgay;
        private string thanhToanKhiLapPhieu;
        private string thueGTGT;
        private string tongTienThanhToan;
        private Boolean loaiHoaDon;
        private string maThe;
        private string giaTriThe;
        private string ghiChu;
        private Boolean deleted;
        private string hanhDong;
        private string cot;
        private string khachTra;
        private string chietKhauTongHoaDon;
        private string maTheGiaTri = string.Empty;
        private string giaTriTheGiaTri = "0";

        public string MaTheGiaTri
        {
            get { return maTheGiaTri; }
            set { maTheGiaTri = value; }
        }

        public string GiaTriTheGiaTri
        {
            get { return giaTriTheGiaTri; }
            set { giaTriTheGiaTri = value; }
        }

        public string ChietKhauTongHoaDon
        {
            get { return chietKhauTongHoaDon; }
            set { chietKhauTongHoaDon = value; }
        }

        public string KhachTra
        {
            get { return khachTra; }
            set { khachTra = value; }
        }
        public string Cot
        {
            get { return cot; }
            set { cot = value; }
        }

        private string kieu;
        public string Kieu
        {
            get { return kieu; }
            set { kieu = value; }
        }

        private string giaTri;
        public string GiaTri
        {
            get { return giaTri; }
            set { giaTri = value; }
        }
        private string maKH;
        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }

        public HDBanHang()
        { }
        public HDBanHang(string Hanhdong, string cot, string giaTri, string kieu, string maKH)
        {
            this.hanhDong = Hanhdong;
            this.cot = cot;
            this.giaTri = giaTri;
            this.kieu = kieu;
            this.maKH = maKH;
        }
        public HDBanHang(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public HDBanHang(string hanhDong, string maKho)
        {
            this.hanhDong = hanhDong;
            this.maKho = maKho;
        }
        public HDBanHang(string hanhDong, string maHDBanHang, string thanhToanNgay)
        {
            this.hanhDong = hanhDong;
            this.maHDBanHang = maHDBanHang;
            this.thanhToanNgay = thanhToanNgay;
        }
        public HDBanHang(string hanhDong, int hDBanHangID)
        {
            this.hanhDong = hanhDong;
            this.hDBanHangID = hDBanHangID;
        }
        public HDBanHang(string hanhDong, int hDBanHangID, string maHDBanHang, DateTime ngayBan, string maKhachHang, string noHienThoi,
            string nguoiNhanHang, string hinhThucThanhToan, string maKho, DateTime hanThanhToam, string maDonDatHang,
            string maNhanVien, string maTienTe, string chietKhau, string thanhToanNgay, string thanhToanKhiLapPhieu, string thueGTGT, string tongTienThanhToan,
            Boolean loaiHoaDon, string maThe, string giaTriThe, string ghiChu, Boolean deleted, string tenDangNhap, string KhachTra, string ChietKhauTongHoaDon, string maTheGiaTri, string giaTriTheGiaTri)
        {
            this.maThe = maThe;
            this.giaTriThe = giaTriThe;
            this.tenDangNhap = tenDangNhap;
            this.hanhDong = hanhDong;
            this.hDBanHangID = hDBanHangID;
            this.maHDBanHang = maHDBanHang;
            this.ngayBan = ngayBan;
            this.maKhachHang = maKhachHang;
            this.noHienThoi = noHienThoi;
            this.nguoiNhanHang = nguoiNhanHang;
            this.hinhThucThanhToan = hinhThucThanhToan;
            this.maKho = maKho;
            this.hanThanhToam = hanThanhToam;
            this.maDonDatHang = maDonDatHang;
            this.maNhanVien = maNhanVien;
            this.maTienTe = maTienTe;
            this.chietKhau = chietKhau;
            this.thanhToanNgay = thanhToanNgay;
            this.thanhToanKhiLapPhieu = thanhToanKhiLapPhieu;
            this.thueGTGT = thueGTGT;
            this.tongTienThanhToan = tongTienThanhToan;
            this.loaiHoaDon = loaiHoaDon;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.khachTra = KhachTra;
            this.ChietKhauTongHoaDon = ChietKhauTongHoaDon;
            this.maTheGiaTri = maTheGiaTri;
            this.giaTriTheGiaTri = giaTriTheGiaTri;
        }
        public HDBanHang(string hanhDong, int hDBanHangID, string maHDBanHang, DateTime ngayBan, string maKhachHang, string tenKhachHang, string noHienThoi,
            string nguoiNhanHang, string hinhThucThanhToan, string maKho, DateTime hanThanhToam, string maDonDatHang,
            string maNhanVien, string maTienTe, string chietKhau, string thanhToanNgay, string thueGTGT, string tongTienThanhToan,
            Boolean loaiHoaDon, string ghiChu, Boolean deleted)
        {
            this.hanhDong = hanhDong;
            this.hDBanHangID = hDBanHangID;
            this.maHDBanHang = maHDBanHang;
            this.ngayBan = ngayBan;
            this.maKhachHang = maKhachHang;
            this.tenKhachHang = tenKhachHang;
            this.noHienThoi = noHienThoi;
            this.nguoiNhanHang = nguoiNhanHang;
            this.hinhThucThanhToan = hinhThucThanhToan;
            this.maKho = maKho;
            this.hanThanhToam = hanThanhToam;
            this.maDonDatHang = maDonDatHang;
            this.maNhanVien = maNhanVien;
            this.maTienTe = maTienTe;
            this.chietKhau = chietKhau;
            this.thanhToanNgay = thanhToanNgay;
            this.thueGTGT = thueGTGT;
            this.tongTienThanhToan = tongTienThanhToan;
            this.loaiHoaDon = loaiHoaDon;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        public string HanhDong
        {
            get { return this.hanhDong; }
            set
            {
                this.hanhDong = value;
            }
        }

        public int HDBanHangID
        {
            get { return this.hDBanHangID; }
            set
            {
                this.hDBanHangID = value;
            }
        }
        public string MaHDBanHang
        {
            get { return this.maHDBanHang; }
            set
            {
                this.maHDBanHang = value;
            }
        }
        public DateTime NgayBan
        {
            get { return this.ngayBan; }
            set { this.ngayBan = value; }
        }
        public string MaKhachHang
        {
            get { return this.maKhachHang; }
            set { this.maKhachHang = value; }
        }
        public string TenKhachHang
        {
            get { return this.tenKhachHang; }
            set { this.tenKhachHang = value; }
        }
        public string NoHienThoi
        {
            get { return this.noHienThoi; }
            set { this.noHienThoi = value; }
        }
        public string NguoiNhanHang
        {
            get { return this.nguoiNhanHang; }
            set { this.nguoiNhanHang = value; }
        }
        public string HinhThucThanhToan
        {
            get { return this.hinhThucThanhToan; }
            set { this.hinhThucThanhToan = value; }
        }
        public string MaKho
        {
            get { return this.maKho; }
            set { this.maKho = value; }
        }
        public DateTime HanThanhToam
        {
            get { return this.hanThanhToam; }
            set { this.hanThanhToam = value; }
        }
        public string MaDonDatHang
        {
            get { return this.maDonDatHang; }
            set { this.maDonDatHang = value; }
        }
        public string MaNhanVien
        {
            get { return this.maNhanVien; }
            set { this.maNhanVien = value; }
        }
        public string MaTienTe
        {
            get { return this.maTienTe; }
            set { this.maTienTe = value; }
        }
        public string ChietKhau
        {
            get { return this.chietKhau; }
            set { this.chietKhau = value; }
        }
        public string ThanhToanNgay
        {
            get { return this.thanhToanNgay; }
            set { this.thanhToanNgay = value; }
        }

        public string ThanhToanKhiLapPhieu
        {
            get { return this.thanhToanKhiLapPhieu; }
            set { this.thanhToanKhiLapPhieu = value; }
        }
        public string ThueGTGT
        {
            get { return this.thueGTGT; }
            set { this.thueGTGT = value; }
        }
        public string TongTienThanhToan
        {
            get { return this.tongTienThanhToan; }
            set { this.tongTienThanhToan = value; }
        }
        public Boolean LoaiHoaDon
        {
            get { return this.loaiHoaDon; }
            set { this.loaiHoaDon = value; }
        }
        public string MaThe
        {
            get { return this.maThe; }
            set { this.maThe = value; }
        }
        public string GiaTriThe
        {
            get { return this.giaTriThe; }
            set { this.giaTriThe = value; }
        }
        public string GhiChu
        {
            get { return this.ghiChu; }
            set { this.ghiChu = value; }
        }
        public Boolean Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }
        private string tenDangNhap;
        public string TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }

        Entities.ChiTietHDBanHang[] chitiethdbanhang;
        public Entities.ChiTietHDBanHang[] ChiTietHDBanHang
        {
            get { return chitiethdbanhang; }
            set { chitiethdbanhang = value; }
        }
        Entities.DonDatHang dondathang;
        public Entities.DonDatHang DonDatHang
        {
            get { return dondathang; }
            set { dondathang = value; }
        }
        Entities.ChiTietKhoHangTheoHoaHonNhap[] chitietkhohangtheohoadonnhap;
        public Entities.ChiTietKhoHangTheoHoaHonNhap[] ChiTietKhoHangTheoHoaHonNhap
        {
            get { return chitietkhohangtheohoadonnhap; }
            set { chitietkhohangtheohoadonnhap = value; }
        }
        Entities.KhachHang khachhang;
        public Entities.KhachHang KhachHang
        {
            get { return khachhang; }
            set { khachhang = value; }
        }
        Entities.TheVip thevip;
        public Entities.TheVip TheVip
        {
            get { return thevip; }
            set { thevip = value; }
        }
        Entities.TheGiamGia thegiamgia;
        public Entities.TheGiamGia TheGiamGia
        {
            get { return thegiamgia; }
            set { thegiamgia = value; }
        }

    }
}