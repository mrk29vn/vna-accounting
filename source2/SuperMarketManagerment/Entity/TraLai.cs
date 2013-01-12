using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
  public  class TraLai
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
        private string maKhachHangTraLai;

        public string MaKhachHangTraLai
        {
            get { return maKhachHangTraLai; }
            set { maKhachHangTraLai = value; }
        }
        private DateTime ngayNhap;

        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
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
        private string thanhToanNgay;

        public string ThanhToanNgay
        {
            get { return thanhToanNgay; }
            set { thanhToanNgay = value; }
        }
        public TraLai()
        { }
        public TraLai(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public TraLai(string hanhdong,string makhachhang)
        {
            this.hanhDong = hanhdong;
            this.maKhachHang = makhachhang;
        }
        public TraLai(string hanhdong,string makhachhang, string makhachhangtralai, DateTime ngaynhap, string hinhthucthanhtoan,
            string ghichu, string thanhtoanngay)
        {
            this.hanhDong = hanhdong;
            this.maKhachHang = makhachhang;
            this.maKhachHangTraLai = makhachhangtralai;
            this.ngayNhap = ngaynhap;
            this.hinhThucThanhToan = hinhthucthanhtoan;
            this.ghiChu = ghichu;
            this.thanhToanNgay = thanhtoanngay ;

        }
    }
}
