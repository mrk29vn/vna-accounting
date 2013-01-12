using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class HienThi_ChiTiet_DonDatHang
    {
        private string hanhDong;
        private string maHangHoa;
        private string tenHangHoa;
        private int soLuongDat;
        private string giaGoc;
        private string giabanbuon;
        private string giabanle;
        private string phanTramChietKhau;
        private string giaNhap;
        private string chietKhau;
        private string tongTien;
        private string thuegiatrigiatang;

       
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }
        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }
        public int SoLuongDat
        {
            get { return soLuongDat; }
            set { soLuongDat = value; }
        }
        public string GiaGoc
        {
            get { return giaGoc; }
            set { giaGoc = value; }
        }
        public string Giabanbuon
        {
            get { return giabanbuon; }
            set { giabanbuon = value; }
        }
        public string Giabanle
        {
            get { return giabanle; }
            set { giabanle = value; }
        }
        public string PhanTramChietKhau
        {
            get { return phanTramChietKhau; }
            set { phanTramChietKhau = value; }
        }
        public string Thuegiatrigiatang
        {
            get { return thuegiatrigiatang; }
            set { thuegiatrigiatang = value; }
        }
        public string GiaNhap
        {
            get { return giaNhap; }
            set { giaNhap = value; }
        }
        public string ChietKhau
        {
            get { return chietKhau; }
            set { chietKhau = value; }
        }
        public string TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        private string ngayhethan;

        public string Ngayhethan
        {
            get { return ngayhethan; }
            set { ngayhethan = value; }
        }
        public HienThi_ChiTiet_DonDatHang() { }
        public HienThi_ChiTiet_DonDatHang(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public HienThi_ChiTiet_DonDatHang(string hanhdong, string mahang)
        {
            this.hanhDong = hanhdong;
            this.maHangHoa = mahang;
        }

        public HienThi_ChiTiet_DonDatHang(string hanhdong, string mahang, string tenhang, int soluong, string giagoc, string giabanbuon, string giabanle, string phantram, string thue, string gianhap, string chietkhau, string tongtien)
        {
            this.hanhDong = hanhdong;
            this.maHangHoa = mahang;
            this.tenHangHoa = tenhang;
            this.soLuongDat = soluong;
            this.giaGoc = giagoc;
            this.giabanbuon = giabanbuon;
            this.giabanle = giabanle;
            this.phanTramChietKhau = phantram;
            this.thuegiatrigiatang = thue;
            this.giaNhap = gianhap;
            this.chietKhau = chietkhau;
            this.tongTien = tongtien;
           
        }
        public HienThi_ChiTiet_DonDatHang(string mahang, string tenhang, int soluong, string giagoc, string phantram, string gianhap, string chietkhau)
        {
            this.maHangHoa = mahang;
            this.tenHangHoa = tenhang;
            this.soLuongDat = soluong;
            this.giaGoc = giagoc;
            this.phanTramChietKhau = phantram;
            this.giaNhap = gianhap;
            this.chietKhau = chietkhau;
        }
        public HienThi_ChiTiet_DonDatHang(string mahang, string tenhang, int soluong, string giagoc, string phantram, string gianhap, string chietkhau,string tongtien,string ngayhethan)
        {
            this.maHangHoa = mahang;
            this.tenHangHoa = tenhang;
            this.soLuongDat = soluong;
            this.giaGoc = giagoc;
            this.phanTramChietKhau = phantram;
            this.giaNhap = gianhap;
            this.chietKhau = chietkhau;
            this.tongTien = tongtien;
            this.ngayhethan = ngayhethan;
        }
        public HienThi_ChiTiet_DonDatHang(string mahang, string tenhang, int soluong, string giagoc, string phantram, string chietkhau)
        {
            this.maHangHoa = mahang;
            this.tenHangHoa = tenhang;
            this.soLuongDat = soluong;
            this.giaGoc = giagoc;
            this.phanTramChietKhau = phantram;
            this.chietKhau = chietkhau;
        }
    }
}
