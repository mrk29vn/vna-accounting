using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCTonKhoTheoNhomHangDGV
    {
        private string hanhDong;
        private string maNhomHang;
        private string tenNhomHang;
        private string soLuong;
        public BCTonKhoTheoNhomHangDGV() { }
        public BCTonKhoTheoNhomHangDGV(string hanhDong,string maNhomHang,string tenNhomHang, string soLuong)
        {
            this.hanhDong = hanhDong;
            this.maNhomHang = maNhomHang;
            this.tenNhomHang = tenNhomHang;

            this.soLuong = soLuong;
        }
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public string MaNhomHang
        {
            get { return this.maNhomHang; }
            set
            {
                this.maNhomHang = value;
            }
        }
        public string TenNhomHang
        {
            get { return this.tenNhomHang; }
            set
            {
                this.tenNhomHang = value;
            }
        }
        public string SoLuong
        {
            get { return this.soLuong; }
            set { this.soLuong = value; }
        }
    }
}
