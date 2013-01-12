using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
   public class ThanhToan
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
        private string maphieuTTcuaKH;

        public string MaphieuTTcuaKH
        {
            get { return maphieuTTcuaKH; }
            set { maphieuTTcuaKH = value; }
        }
        private DateTime ngayLap;

        public DateTime NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }

        private string trangThai;

        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
        private string ghiChu;

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        private string thanhToan;

        public string ThanhToan1
        {
            get { return thanhToan; }
            set { thanhToan = value; }
        }
         public ThanhToan()
         { }
         public ThanhToan(string hanhdong)
         {
             this.hanhDong = hanhdong;
         }
         public ThanhToan(string hanhdong,string makhachhang)
         {
             this.hanhDong = hanhdong;
             this.maKhachHang = makhachhang;
         }
         public ThanhToan(string hanhdong, string makhachhang, string maphieuttcuakh, DateTime ngaylap, string trangthai, string ghichu, string thanhtoan)
         {
             this.hanhDong = hanhdong;
             this.maKhachHang = makhachhang;
             this.maphieuTTcuaKH = maphieuttcuakh;
             this.ngayLap = ngaylap;
             this.thanhToan = thanhtoan;
             this.trangThai = trangthai;
             this.ghiChu = ghichu;
         }
    }
}
