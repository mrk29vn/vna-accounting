using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
   public class LSGDNhapMua
    {
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private string maNhaCungCap;

        public string MaNhaCungCap
        {
            get { return maNhaCungCap; }
            set { maNhaCungCap = value; }
        }
        private string maHoaDonNhap;

        public string MaHoaDonNhap
        {
            get { return maHoaDonNhap; }
            set { maHoaDonNhap = value; }
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
        private string tongTien;

        public string TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }

        public LSGDNhapMua()
        { }
        public LSGDNhapMua(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public LSGDNhapMua(string hanhdong,string manhacungcap)
        {
            this.hanhDong = hanhdong;
            this.maNhaCungCap = manhacungcap;
        }
        public LSGDNhapMua(string hanhdong,string manhacungcap,string mahoadonnhap,DateTime ngaynhap,string hinhthucthanhtoan,string ghichu,string tongtien)
        {
            this.hanhDong = hanhdong;
            this.maNhaCungCap = manhacungcap;
            this.maHoaDonNhap = mahoadonnhap;
            this.ngayNhap = ngaynhap;
            this.hinhThucThanhToan = hinhthucthanhtoan;
            this.ghiChu = ghichu;
            this.tongTien = tongtien;
        }
    }
}
