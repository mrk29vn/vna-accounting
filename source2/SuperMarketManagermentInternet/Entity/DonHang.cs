using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
   public class DonHang
    {
         
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private string maKhachHang;

        public string MaKhachHang
        {
            get { return maKhachHang; }
            set { maKhachHang = value; }
        }
        private string maDonDatHang;

        public string MaDonDatHang
        {
            get { return maDonDatHang; }
            set { maDonDatHang = value; }
        }
        private DateTime ngayDonHang;

        public DateTime NgayDonHang
        {
            get { return ngayDonHang; }
            set { ngayDonHang = value; }
        }
        private string hinhThucThanhToan;

        public string HinhThucThanhToan
        {
            get { return hinhThucThanhToan; }
            set { hinhThucThanhToan = value; }
        }
        private string ghiChu;

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        private string tongTienThanhToan;

        public string TongTienThanhToan
        {
            get { return tongTienThanhToan; }
            set { tongTienThanhToan = value; }
        }
        public DonHang()
        { }
        public DonHang(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public DonHang(string hanhdong,string makhachhang)
        {
            this.hanhDong = hanhdong;
            this.maKhachHang = makhachhang;
        }
        public DonHang(string hanhdong,string makhachhang, string madondathang, DateTime ngaydonhang, string hinhthucthanhtoan, string ghichu, string tongtienthanhtoan)
        {
            this.hanhDong = hanhdong;
            this.maKhachHang = makhachhang;
            this.MaDonDatHang = madondathang;
            this.ngayDonHang = ngaydonhang;
            this.hinhThucThanhToan = hinhthucthanhtoan;
            this.ghiChu = ghichu;
            this.tongTienThanhToan = tongtienthanhtoan;
        }
    }
}
