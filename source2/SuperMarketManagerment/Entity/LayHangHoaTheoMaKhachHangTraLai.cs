using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class LayHangHoaTheoMaKhachHangTraLai
    {
        private string mahanghoa;

        public string Mahanghoa
        {
            get { return mahanghoa; }
            set { mahanghoa = value; }
        }
        private string tenhanghoa;

        public string Tenhanghoa
        {
            get { return tenhanghoa; }
            set { tenhanghoa = value; }
        }
        private int soluong;

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        private string giaban;

        public string Giaban
        {
            get { return giaban; }
            set { giaban = value; }
        }
       
       
        private string phantramchietkhau;
        public string Phantramchietkhau
        {
            get { return phantramchietkhau; }
            set { phantramchietkhau = value; }
        }
        
        private string chietkhau;

        public string Chietkhau
        {
            get { return chietkhau; }
            set { chietkhau = value; }
        }
        private string tongtien;

        public string Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }

        private string thuegiatrigiatang;

        public string Thuegiatrigiatang
        {
            get { return thuegiatrigiatang; }
            set { thuegiatrigiatang = value; }
        }

         public LayHangHoaTheoMaKhachHangTraLai() { }
         public LayHangHoaTheoMaKhachHangTraLai(string mahanghoa, string tenhanghoa, int soluong, string giaban, string phantramchietkhau, string chietkhau, string tongtien) 
         {
             this.mahanghoa = mahanghoa;
             this.tenhanghoa = tenhanghoa;
             this.soluong = soluong;
             this.giaban = giaban;
             this.phantramchietkhau = phantramchietkhau;
             this.chietkhau = chietkhau;
             this.tongtien = tongtien;
         }
         public LayHangHoaTheoMaKhachHangTraLai(string mahanghoa, string tenhanghoa, int soluong, string giaban, string phantramchietkhau, string chietkhau, string tongtien,string thue)
         {
             this.mahanghoa = mahanghoa;
             this.tenhanghoa = tenhanghoa;
             this.soluong = soluong;
             this.giaban = giaban;
             this.phantramchietkhau = phantramchietkhau;
             this.chietkhau = chietkhau;
             this.tongtien = tongtien;
             this.thuegiatrigiatang = thue;
         }
    }
}
