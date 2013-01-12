using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCTonKhoTheoNhomHang
    {
        private string maNhomHang;
        private string tenNhomHang;
        private string maHangHoa;
        private string tenHangHoa;
        private string tenKho;
        private DateTime hanSuDung;
        private int soLuong;
        private string hanhDong;

        public BCTonKhoTheoNhomHang() { }
        public BCTonKhoTheoNhomHang(string hanhDong, string maNhomHang)
        {
            this.hanhDong = hanhDong;
            this.maNhomHang = maNhomHang;
        }
        public BCTonKhoTheoNhomHang(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public BCTonKhoTheoNhomHang(string maNhomHang, string tenNhomHang, string maHangHoa, string tenHangHoa, string tenKho, DateTime hanSuDung, int soLuong, string hanhDong)
        {
            this.maNhomHang = maNhomHang;
            this.tenNhomHang = tenNhomHang;
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.tenKho = tenKho;
            this.hanSuDung = hanSuDung;
            this.soLuong = soLuong;
            this.hanhDong = hanhDong;
        }

        public string MaNhomHang
        {
            get { return this.maNhomHang; }
            set { this.maNhomHang = value; }
        }
        public string TenNhomHang
        {
            get { return this.tenNhomHang; }
            set { this.tenNhomHang = value; }
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
        public string TenKho
        {
            get { return this.tenKho; }
            set { this.tenKho = value; }
        }
        public DateTime HanSuDung
        {
            get { return this.hanSuDung; }
            set { this.hanSuDung = value; }
        }
        public int SoLuong
        {
            get { return this.soLuong; }
            set { this.soLuong = value; }
        }
        public string HanhDong
        {
            get { return this.hanhDong; }
            set { this.hanhDong = value; }
        }
    }
}
