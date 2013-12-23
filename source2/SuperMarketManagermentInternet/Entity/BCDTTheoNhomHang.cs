using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCDTTheoNhomHang
    {
        private string maNhomHang;
        private string tenNhomHang;
        private string maHangHoa;
        private DateTime ngayBan;
        private string tenHangHoa;
        private string maHDBanHang;
        private double thanhToanNgay;
        private string hanhDong;
        private string tongTien;
        private DateTime truoc;
        private DateTime sau;

        public BCDTTheoNhomHang() { }
        public BCDTTheoNhomHang(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public BCDTTheoNhomHang(string hanhDong, string maNhomHang,DateTime truoc,DateTime sau)
        {
            this.hanhDong = hanhDong;
            this.maNhomHang = maNhomHang;
            this.truoc = truoc;
            this.sau = sau;
        }
        public BCDTTheoNhomHang(string maNhomHang, string tenNhomHang, string maHangHoa, DateTime ngayBan, string tenHangHoa, string maHDBanHang, double tongTienThanhToan)
        {
            this.maNhomHang = maNhomHang;
            this.tenNhomHang = tenNhomHang;
            this.maHangHoa = maHangHoa;
            this.ngayBan = ngayBan;
            this.tenHangHoa = tenHangHoa;
            this.maHDBanHang = maHDBanHang;
            this.thanhToanNgay = tongTienThanhToan;
        }

        public BCDTTheoNhomHang(string hanhDong, string maNhomHang, string tenNhomHang, string tongTien)
        {
            this.hanhDong = hanhDong;
            this.maNhomHang = maNhomHang;
            this.tenNhomHang = tenNhomHang;
            this.tongTien = tongTien;
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
        public DateTime NgayBan
        {
            get { return ngayBan; }
            set { ngayBan = value; }
        }


        public string MaHDBanHang
        {
            get { return maHDBanHang; }
            set { maHDBanHang = value; }
        }

        public double ThanhToanNgay
        {
            get { return thanhToanNgay; }
            set { thanhToanNgay = value; }
        }

        public string TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        public DateTime Truoc
        {
            get { return truoc; }
            set { truoc = value; }
        }
        public DateTime Sau
        {
            get { return sau; }
            set { sau = value; }
        }

    }
}
