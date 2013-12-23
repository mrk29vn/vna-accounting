using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCNhapHangTheoKho
    {
        string sTT;

        public string STT
        {
            get { return sTT; }
            set { sTT = value; }
        }
        string maKho;

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
        string tenKho;

        public string TenKho
        {
            get { return tenKho; }
            set { tenKho = value; }
        }
        int tongSoLuongNhap;

        public int TongSoLuongNhap
        {
            get { return tongSoLuongNhap; }
            set { tongSoLuongNhap = value; }
        }

         public BCNhapHangTheoKho()
         {
             
         }

         public BCNhapHangTheoKho(string sTT, string maKho, string tenKho, int tongSoLuongNhap)
         {
             this.sTT = sTT;
             this.maKho = maKho;
             this.tenKho = tenKho;
             this.tongSoLuongNhap = tongSoLuongNhap;
         }
    }
}
