using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ChiTietKhoHangTheoMa
    {
        private string makho;

        private string maHangHoa;

        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }

        public string Makho
        {
            get { return makho; }
            set { makho = value; }
        }
         private string tenkho;

         public string Tenkho
         {
             get { return tenkho; }
             set { tenkho = value; }
         }
         private string tenhang;

         public string Tenhang
         {
             get { return tenhang; }
             set { tenhang = value; }
         }
         private int soluong;

         public int Soluong
         {
             get { return soluong; }
             set { soluong = value; }
         }
         private string gianhap;

         public string Gianhap
         {
             get { return gianhap; }
             set { gianhap = value; }
         }
        
        
         private DateTime ngaynhap;

         public DateTime Ngaynhap
         {
             get { return ngaynhap; }
             set { ngaynhap = value; }
         }
         private DateTime ngayhethan;

         public DateTime Ngayhethan
         {
             get { return ngayhethan; }
             set { ngayhethan = value; }
         }
         private string tongtien;

         public string TongTien
         {
             get { return tongtien; }
             set { tongtien = value; }
         }
         public ChiTietKhoHangTheoMa() { }
         public ChiTietKhoHangTheoMa(string makho, string tenkho, string tenhang, int soluong, string gianhap, DateTime ngaynhap,DateTime ngayhethan ,string tongtien)
         {
             this.makho = makho;
             this.tenkho = tenkho;
             this.tenhang = tenhang;
             this.soluong = soluong;
             this.gianhap = gianhap;
             this.ngaynhap = ngaynhap;
             this.ngayhethan = ngayhethan;
             this.tongtien = tongtien;
         }
    }
}
