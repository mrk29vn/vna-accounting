using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{[Serializable]
    public class BCNhapHangTheoNhom
    {
        private string maNhomHang;
        private string tenNhomHang;
        private string tongNhap;
        private string hanhDong;

        public BCNhapHangTheoNhom() { }
        public BCNhapHangTheoNhom(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public BCNhapHangTheoNhom(string hanhDong, string maNhomHang, string tenNhomHang, string tongNhap)
        {
            this.hanhDong = hanhDong;
            this.maNhomHang = maNhomHang;
            this.tenNhomHang = tenNhomHang;
            this.tongNhap = tongNhap;
        }
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        public string MaNhomHang
        {
            get { return maNhomHang; }
            set { maNhomHang = value; }
        }
        public string TenNhomHang
        {
            get { return this.tenNhomHang; }
            set { this.tenNhomHang = value; }
        }

        public string TongNhap
        {
            get { return tongNhap; }
            set { tongNhap = value; }
        }
    }
}
