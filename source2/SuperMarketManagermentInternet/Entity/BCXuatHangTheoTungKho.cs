using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class BCXuatHangTheoTungKho
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
        int tongSoLuongXuat;

        public int TongSoLuongXuat
        {
            get { return tongSoLuongXuat; }
            set { tongSoLuongXuat = value; }
        }

         public BCXuatHangTheoTungKho()
         {
             
         }

         public BCXuatHangTheoTungKho(string sTT, string maKho, string tenKho, int tongSoLuongXuat)
         {
             this.sTT = sTT;
             this.maKho = maKho;
             this.tenKho = tenKho;
             this.tongSoLuongXuat = tongSoLuongXuat;
         }

    }
}
