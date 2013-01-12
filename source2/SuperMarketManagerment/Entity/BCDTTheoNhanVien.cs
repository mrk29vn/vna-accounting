using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCDTTheoNhanVien
    {
        private string maNhanVien;
        private string tenNhanVien;
        private string maHDBanHang;
        private DateTime ngayBan;
        private double thanhToanNgay;
        private string tongTien;
        private string hanhDong;
        private double thanhToanKhiLapPhieu;
        private double tongTienThanhToan;
        double giaTriThe = 0;
        double giaTriTheGiaTri = 0;
        double tongTienThucThu = 0;

        public double GiaTriThe
        {
            get { return giaTriThe; }
            set { giaTriThe = value; }
        }
        public double GiaTriTheGiaTri
        {
            get { return giaTriTheGiaTri; }
            set { giaTriTheGiaTri = value; }
        }
        public double TongTienThucThu
        {
            get { return tongTienThucThu; }
            set { tongTienThucThu = value; }
        }

        public double TongTienThanhToan
        {
            get { return tongTienThanhToan; }
            set { tongTienThanhToan = value; }
        }
        DateTime truoc;
        DateTime sau;
        public BCDTTheoNhanVien() 
        {
            this.maNhanVien = "";
            this.tenNhanVien = "";
            this.maHDBanHang = "";
            this.ngayBan = new DateTime();
            this.thanhToanNgay = 0;
            this.tongTien = "";
            this.hanhDong = "";
            this.thanhToanKhiLapPhieu = 0;
            this.tongTienThanhToan = 0;
            this.truoc = new DateTime();
            this.sau = new DateTime();
        }
        public BCDTTheoNhanVien(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public BCDTTheoNhanVien(string hanhDong,string maNhanVien,DateTime truoc,DateTime sau)
        {
            this.hanhDong = hanhDong;
            this.maNhanVien = maNhanVien;
            this.truoc = truoc;
            this.sau = sau;
        }

        public BCDTTheoNhanVien(string maNhanVien, string tenNhanVien, string maHDBanHang, DateTime ngayBan, double thanhToanNgay,double thanhToanKhiLapPhieu)
        {
            this.maNhanVien = maNhanVien;
            this.tenNhanVien = tenNhanVien;
            this.maHDBanHang = maHDBanHang;
            this.ngayBan = ngayBan;
            this.thanhToanNgay = thanhToanNgay;
            this.thanhToanKhiLapPhieu = thanhToanKhiLapPhieu;
        }
        public BCDTTheoNhanVien(string hanhDong, string maNhanVien, string tenNhanVien, string tongTien)
        {
            this.hanhDong = hanhDong;
            this.maNhanVien = maNhanVien;
            this.tenNhanVien = tenNhanVien;
            this.tongTien = tongTien;
        }
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }

        public string TenNhanVien
        {
            get { return this.tenNhanVien; }
            set { this.tenNhanVien = value; }
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
        public double ThanhToanKhiLapPhieu
        {
            get { return this.thanhToanKhiLapPhieu; }
            set { this.thanhToanKhiLapPhieu = value; }
        }

    }
}
