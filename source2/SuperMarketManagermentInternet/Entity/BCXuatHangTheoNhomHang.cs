using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class BCXuatHangTheoNhomHang
    {
        string maNhomHang;

        string tenNhomHang;

        int tongSoLuongXuat;

         public BCXuatHangTheoNhomHang()
         {
             
         }

         public BCXuatHangTheoNhomHang(string sTT, string maNhomHang, string tenNhomHang, int tongSoLuongXuat)
         {
           
             this.maNhomHang = maNhomHang;
             this.tenNhomHang = tenNhomHang;
             this.tongSoLuongXuat = tongSoLuongXuat;
         }

         public string MaNhomHang
         {
             get { return maNhomHang; }
             set { maNhomHang = value; }
         }

         public string TenNhomHang
         {
             get { return tenNhomHang; }
             set { tenNhomHang = value; }
         }

         public int TongSoLuongXuat
         {
             get { return tongSoLuongXuat; }
             set { tongSoLuongXuat = value; }
         }
    }
}
