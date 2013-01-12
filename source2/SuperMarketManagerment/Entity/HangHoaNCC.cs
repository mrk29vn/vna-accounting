using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
   public class HangHoaNCC
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
        private string thueGTGT;

        public string ThueGTGT
        {
            get { return thueGTGT; }
            set { thueGTGT = value; }
        }
        private string tongTien;

        public string TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
         public HangHoaNCC()
         { }
         public HangHoaNCC(string hanhdong)
         {
             this.hanhDong = hanhdong;
         }
         public HangHoaNCC(string hanhdong, string manhacungcap)
         {
             this.hanhDong = hanhdong;
             this.maNhaCungCap = manhacungcap;
         }
         public HangHoaNCC(string hanhdong, string manhacungcap, string mahanghoa, string tenhanghoa, string madonvitinh, int soluong, string thuegtgt, string tongtien)
         {
             this.hanhDong = hanhdong;
             this.maNhaCungCap = manhacungcap;
             this.maHangHoa = mahanghoa;
             this.tenHangHoa = tenhanghoa;
             this.maDonViTinh = madonvitinh;
             this.soLuong = soluong;
             this.thueGTGT = thuegtgt;
             this.tongTien = tongtien;
         }
    }
}
