using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
   public class LSGDHangHoa
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
        private string maHangHoa;

        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }
        private string tenHangHoa;

        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }
        private string maDonViTinh;

        public string MaDonViTinh
        {
            get { return maDonViTinh; }
            set { maDonViTinh = value; }
        }
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private string maThueGiaTriGiaTang;

        public string MaThueGiaTriGiaTang
        {
            get { return maThueGiaTriGiaTang; }
            set { maThueGiaTriGiaTang = value; }
        }
        private string tongTienThanhToan;

        public string TongTienThanhToan
        {
            get { return tongTienThanhToan; }
            set { tongTienThanhToan = value; }
        }
       public LSGDHangHoa()
       { }
       public LSGDHangHoa(string hanhdong)
       {
           this.hanhDong = hanhdong;
       }
       public LSGDHangHoa(string hanhdong,string makhachhang)
       {
           this.hanhDong = hanhdong;
           this.maKhachHang = makhachhang;
       }
       public LSGDHangHoa(string hanhdong,string makhachhang,string mahanghoa,string tenhanghoa,string madonvitinh,int soluong,string mathuegiatrigiatang,string tongtienthanhtoan)
       {
           this.hanhDong = hanhdong;
           this.maKhachHang = makhachhang;
           this.maHangHoa = mahanghoa;
           this.tenHangHoa = tenhanghoa;
           this.maDonViTinh = madonvitinh;
           this.soLuong = soluong;
           this.maThueGiaTriGiaTang = mathuegiatrigiatang;
           this.tongTienThanhToan = tongtienthanhtoan;
       }
    }
}
