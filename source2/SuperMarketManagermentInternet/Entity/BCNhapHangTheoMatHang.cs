using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class BCNhapHangTheoMatHang
    {
        private int hanhDong;
        private string maHangHoa;
        private string tenHangHoa;
        private int soLuong;
        public BCNhapHangTheoMatHang() { }
        public BCNhapHangTheoMatHang(int hanhDong,string maHangHoa, string tenHangHoa, int soLuong)
        {
            this.hanhDong = hanhDong;
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.soLuong = soLuong;
        }
        public int HanhDong
        {
            get { return this.hanhDong; }
            set { this.hanhDong = value; }
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
    }
}
