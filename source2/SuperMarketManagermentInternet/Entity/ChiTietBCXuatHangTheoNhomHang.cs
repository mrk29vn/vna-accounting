using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class ChiTietBCXuatHangTheoNhomHang
    {
        string maNhomHang;
        string tenNhomHang;
        string maHangHoa;
        string tenHangHoa;
        int tongSoLuongXuat;
        public ChiTietBCXuatHangTheoNhomHang()
        {
            
        }
        public ChiTietBCXuatHangTheoNhomHang(string maNhomHang, string tenNhomHang, string maHangHoa, string tenHangHoa, int tongSoLuongXuat)
        {
            this.maNhomHang = maNhomHang;
            this.tenNhomHang = tenNhomHang;
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
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

        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }

        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }

        public int TongSoLuongXuat
        {
            get { return tongSoLuongXuat; }
            set { tongSoLuongXuat = value; }
        }
    }
}
