using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class NhapHangTheoKho
    {
        private string hoaDonNhap;
        private string ngayNhap;
        private string tenHang;
        private int soLuong;
        private Double tongTien;

        public string HoaDonNhap
        {
            get { return hoaDonNhap; }
            set { hoaDonNhap = value; }
        }
        public string NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }
        public string TenHang
        {
            get { return tenHang; }
            set { tenHang = value; }
        }
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        public Double TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        public NhapHangTheoKho() { }
        public NhapHangTheoKho(string hoaDonNhap, string ngayNhap, string tenHang, int soLuong, Double tongTien)
        { 
            this.hoaDonNhap = hoaDonNhap;
            this.ngayNhap = ngayNhap;
            this.tenHang = tenHang;
            this.soLuong = soLuong;
            this.tongTien = tongTien;
        }
    }
}
