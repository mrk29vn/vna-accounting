using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
  public  class BaoCaoNhapHangTheoMatHang
    {
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private string maKho;

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
        private string maHoaDonNhap;

        public string MaHoaDonNhap
        {
            get { return maHoaDonNhap; }
            set { maHoaDonNhap = value; }
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

        public BaoCaoNhapHangTheoMatHang()
        { }
        public BaoCaoNhapHangTheoMatHang(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public BaoCaoNhapHangTheoMatHang(string makho, string mahoadonnhap, string tenhanghoa,DateTime ngaynhap, int soluong, string gianhap,float tongtien)
        {
            this.maKho = makho;
            this.maHoaDonNhap = mahoadonnhap;
            this.tenHangHoa = tenhanghoa;
            this.ngayNhap = ngaynhap;
            this.soLuong = soluong;
            this.tongTien = tongtien;
        }
    }
}
