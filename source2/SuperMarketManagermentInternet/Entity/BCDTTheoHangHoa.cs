using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCDTTheoHangHoa
    {
        private string maHangHoa;
        private DateTime ngayBan;
        private string tenHangHoa;
        private string maHDBanHang;
        private string hanhDong;
        private double thanhToanNgay;
        private string tongTien;
        DateTime truoc;
        DateTime sau;
        public BCDTTheoHangHoa() { }
        public BCDTTheoHangHoa(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public BCDTTheoHangHoa(string hanhDong,string maHangHoa,DateTime truoc, DateTime sau)
        {
            this.hanhDong = hanhDong;
            this.maHangHoa = maHangHoa;
            this.truoc = truoc;
            this.sau = sau;
        }
        public BCDTTheoHangHoa(string maHangHoa, string tenHangHoa, string maHDBanHang, DateTime ngayBan, double thanhToanNgay)
        {
            this.maHangHoa = maHangHoa;
            this.ngayBan = ngayBan;
            this.tenHangHoa = tenHangHoa;
            this.maHDBanHang = maHDBanHang;
            this.thanhToanNgay = thanhToanNgay;
        }
        public BCDTTheoHangHoa(string hanhDong, string maHangHoa, string tenHangHoa, string tongTien)
        {
            this.hanhDong = hanhDong;
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.tongTien = tongTien;
        }
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
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

        public string MaHDBanHang
        {
            get { return maHDBanHang; }
            set { maHDBanHang = value; }
        }

        public DateTime NgayBan
        {
            get { return ngayBan; }
            set { ngayBan = value; }
        }
        public double ThanhToanNgay
        {
            get { return this.thanhToanNgay; }
            set { this.thanhToanNgay = value; }
        }
        public string TongTien
        {
            get { return this.tongTien; }
            set { this.tongTien = value; }
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
