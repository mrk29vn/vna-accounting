using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public  class BaoCaoNhapHangTheoNhomHang
    {
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private string maNhomHang;

        public string MaNhomHang
        {
            get { return maNhomHang; }
            set { maNhomHang = value; }
        }
        private string tenKho;

        public string TenKho
        {
            get { return tenKho; }
            set { tenKho = value; }
        }
        private string tenHangHoa;

        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }
        private DateTime ngayNhap;

        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private float tongTien;

        public float TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
         public BaoCaoNhapHangTheoNhomHang()
         { }
         public BaoCaoNhapHangTheoNhomHang(string hanhdong)
         {
             this.hanhDong = hanhdong;
         }
         public BaoCaoNhapHangTheoNhomHang(string manhomhang, string tenkho, string tenhanghoa, DateTime ngaynhap, int soluong, float tongtien)
         {
             this.maNhomHang = manhomhang;
             this.tenKho = tenkho;
             this.tenHangHoa =tenhanghoa;
             this.ngayNhap = ngaynhap;
             this.soLuong = soluong;
             this.tongTien = tongtien;
         }

    }
}
