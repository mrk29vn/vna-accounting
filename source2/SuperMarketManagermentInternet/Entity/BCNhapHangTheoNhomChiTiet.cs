using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCNhapHangTheoNhomChiTiet
    {
        private string maNhomHang;
        private string tenNhomHangHoa;        
        private string maHangHoa;
        private string tenHangHoa;
        private double soLuong;
        public BCNhapHangTheoNhomChiTiet(string maNhomHang, string tenNhomHang, string maHang, string tenHang, double tongNhap)
        {
            this.maNhomHang = maNhomHang;
            this.maHangHoa = maHang;
            this.tenHangHoa = tenHang;
            this.tenNhomHangHoa = tenNhomHang;
            this.soLuong = tongNhap;
        }
        public string MaNhomHang
        {
            get { return maNhomHang; }
            set { maNhomHang = value; }
        }
        public string TenNhomHangHoa
        {
            get { return this.tenNhomHangHoa; }
            set { this.tenNhomHangHoa = value; }
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
        public double SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }        
    }
}
