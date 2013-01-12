using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
  public  class XuatHang
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
        private string maHDBanHang;

        public string MaHDBanHang
        {
            get { return maHDBanHang; }
            set { maHDBanHang = value; }
        }
        private DateTime ngayBan;

        public DateTime NgayBan
        {
            get { return ngayBan; }
            set { ngayBan = value; }
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
        public XuatHang()
        { }
        public XuatHang(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public XuatHang(string hanhdong, string makhachhang)
        {
            this.hanhDong = hanhdong;
            this.maKhachHang = makhachhang;
        }
        public XuatHang(string hanhdong, string makhachhang, string mahdbanhang, DateTime ngayban, string hinhthucthanhtoan, string ghichu, string tongtienthanhtoan)
        {
            this.hanhDong = hanhdong;
            this.maKhachHang = makhachhang;
            this.maHDBanHang = mahdbanhang;
            this.ngayBan = ngayban;
            this.hinhThucThanhToan = hinhthucthanhtoan;
            this.tongTienThanhToan = tongtienthanhtoan;

        }
    }
}
