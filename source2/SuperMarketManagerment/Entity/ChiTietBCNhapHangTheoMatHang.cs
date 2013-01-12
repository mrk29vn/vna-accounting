using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class ChiTietBCNhapHangTheoMatHang
    {
        private string maHangHoa;
        private string tenHangHoa;
        private int soLuong;
        private string maHoaDon;
        private string ngayNhap;
        public ChiTietBCNhapHangTheoMatHang() { }
        public ChiTietBCNhapHangTheoMatHang(string maHangHoa, string tenHangHoa, int soLuong,string maHoaDon,string ngayNhap)
        {
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.soLuong = soLuong;
            this.maHoaDon = maHoaDon;
            this.ngayNhap = ngayNhap;
        }
        public string MaHangHoa
        {
            get { return this.maHangHoa; }
            set { this.maHangHoa = value; }
        }
        public string TenHangHoa
        {
            get { return this.tenHangHoa; }
            set { this.tenHangHoa = value; }
        }
        public int SoLuong
        {
            get { return this.soLuong; }
            set { this.soLuong = value; }
        }
        public string MaHoaDon
        {
            get { return this.maHoaDon; }
            set { this.maHoaDon = value; }
        }
        public string NgayNhap
        {
            get { return this.ngayNhap; }
            set { this.ngayNhap = value; }
        }
    }
}
