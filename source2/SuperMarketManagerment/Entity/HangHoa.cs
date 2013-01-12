using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class HangHoa
    {
        string thaoTac = "";
        int stt = 0;

        public int Stt
        {
            get { return stt; }
            set { stt = value; }
        }

        public string ThaoTac
        {
            get { return thaoTac; }
            set { thaoTac = value; }
        }
        public string NhanVienID = "";
        public string TenDangNhap = "";
        private string hanhDong = "";
        private int hangHoaID = 0;
        private string maHangHoa = "";
        private string maNhomHangHoa = "";
        private string tenNhomHangHoa = "";

        private string tenHangHoa = "";
        private string maDonViTinh = "";
        private string tenDonViTinh = "";

        private string giaNhap = "";
        private string giaNhapSHOW = "";
        private string giaBanBuon = "";
        private string giaBanLe = "";
        private string giaBanLeSHOW = "";

        private string maThueGiaTriGiaTang = "";
        private string tenThueGiaTriGiaTang = "";

        private string kieuHangHoa = "";
        private string seriLo = "";
        private int mucDatHang = 0;
        private int mucTonToiThieu = 0;
        private string ghiChu = "";
        private bool deleted = false;
        private string maKho = "";

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }

        public HangHoa()
        { }
        public HangHoa(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public HangHoa(string hanhDong, int hangHoaID, string maHangHoa, string nhanvienID, string tenDangNhap)
        {
            this.hanhDong = hanhDong;
            this.hangHoaID = hangHoaID;
            this.maHangHoa = maHangHoa;
            this.NhanVienID = nhanvienID;
            this.TenDangNhap = tenDangNhap;
        }
        public HangHoa(string hanhDong, string maKho)
        {
            this.hanhDong = hanhDong;
            this.maKho = maKho;
        }
        public HangHoa(string hanhDong, int hangHoaID, string maHangHoa, string maNhomHangHoa, string tenNhomHangHoa, string tenHangHoa,
             string maDonViTinh, string tenDonViTinh, string giaNhap, string giaBanBuon, string giaBanLe,
            string maThueGiaTriGiaTang, string tenThueGiaTriGiaTang, string kieuHangHoa, string seriLo, int mucDatHang,
            int mucTonToiThieu, string ghiChu, bool deleted, string nhanvienID, string tenDangNhap)
        {
            this.hanhDong = hanhDong;
            this.hangHoaID = hangHoaID;
            this.maHangHoa = maHangHoa;
            this.maNhomHangHoa = maNhomHangHoa;
            this.tenNhomHangHoa = tenNhomHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.maDonViTinh = maDonViTinh;
            this.tenDonViTinh = tenDonViTinh;
            this.giaNhap = giaNhap;
            this.giaBanBuon = giaBanBuon;
            this.giaBanLe = giaBanLe;
            this.maThueGiaTriGiaTang = maThueGiaTriGiaTang;
            this.tenThueGiaTriGiaTang = tenThueGiaTriGiaTang;
            this.kieuHangHoa = kieuHangHoa;
            this.seriLo = seriLo;
            this.mucDatHang = mucDatHang;
            this.mucTonToiThieu = mucTonToiThieu;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.NhanVienID = nhanvienID;
            this.TenDangNhap = tenDangNhap;
        }

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        public int HangHoaID
        {
            get { return this.hangHoaID; }
            set
            {
                this.hangHoaID = value;
            }
        }
        public string MaHangHoa
        {
            get { return this.maHangHoa; }
            set
            {
                this.maHangHoa = value;
            }
        }
        public string MaNhomHangHoa
        {
            get { return this.maNhomHangHoa; }
            set { this.maNhomHangHoa = value; }
        }
        public string TenNhomHangHoa
        {
            get { return tenNhomHangHoa; }
            set { tenNhomHangHoa = value; }
        }
        public string TenHangHoa
        {
            get { return this.tenHangHoa; }
            set { this.tenHangHoa = value; }
        }

        public string MaDonViTinh
        {
            get { return this.maDonViTinh; }
            set { this.maDonViTinh = value; }
        }
        public string TenDonViTinh
        {
            get { return tenDonViTinh; }
            set { tenDonViTinh = value; }
        }
        public string GiaNhap
        {
            get { return this.giaNhap; }
            set { this.giaNhap = value; }
        }
        public string GiaNhapSHOW
        {
            get { return giaNhapSHOW; }
            set { giaNhapSHOW = value; }
        }
        public string GiaBanBuon
        {
            get { return this.giaBanBuon; }
            set { this.giaBanBuon = value; }
        }
        private string giaBanBuonSHOW = "";

        public string GiaBanBuonSHOW
        {
            get { return giaBanBuonSHOW; }
            set { giaBanBuonSHOW = value; }
        }
        public string GiaBanLe
        {
            get { return this.giaBanLe; }
            set { this.giaBanLe = value; }
        }
        public string GiaBanLeSHOW
        {
            get { return giaBanLeSHOW; }
            set { giaBanLeSHOW = value; }
        }
        public string MaThueGiaTriGiaTang
        {
            get { return this.maThueGiaTriGiaTang; }
            set { this.maThueGiaTriGiaTang = value; }
        }
        public string TenThueGiaTriGiaTang
        {
            get { return tenThueGiaTriGiaTang; }
            set { tenThueGiaTriGiaTang = value; }
        }
        public string KieuHangHoa
        {
            get { return this.kieuHangHoa; }
            set { this.kieuHangHoa = value; }
        }
        public string SeriLo
        {
            get { return this.seriLo; }
            set { this.seriLo = value; }
        }
        public int MucDatHang
        {
            get { return this.mucDatHang; }
            set { this.mucDatHang = value; }
        }
        public int MucTonToiThieu
        {
            get { return this.mucTonToiThieu; }
            set { this.mucTonToiThieu = value; }
        }
        public string GhiChu
        {
            get { return this.ghiChu; }
            set { this.ghiChu = value; }
        }
        public bool Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }

        private string cot;
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
        public HangHoa(string Hanhdong, string cot, string giaTri, string kieu)
        {
            this.hanhDong = Hanhdong;
            this.cot = cot;
            this.giaTri = giaTri;
            this.kieu = kieu;
        }
        public HangHoa(string Hanhdong, string cot, string giaTri, string kieu, string maKho)
        {
            this.hanhDong = Hanhdong;
            this.cot = cot;
            this.giaTri = giaTri;
            this.kieu = kieu;
            this.maKho = maKho;
        }
    }
}
