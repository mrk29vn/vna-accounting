using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class TimKiemChungTu
    {
        private string hanhDong;
        private string maChungTu;
        private string tenChungTu;
        private DateTime ngayLap;
        private string maHang;
        private string tenHang;
        private string soLuong;
        private string donGia;
        private double thanhTien;
        private string maNhomHang;
        private string tenNhomHang;
        private string ghiChu;
        private double tongTien;

        public TimKiemChungTu(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public TimKiemChungTu(string maChungTu, string tenChungTu, DateTime ngayLap, string ghiChu,double tongTien)
        {
            this.maChungTu = maChungTu;
            this.tenChungTu = tenChungTu;
            this.ngayLap = ngayLap;
            this.ghiChu = ghiChu;
            this.tongTien = tongTien;
        }
        public TimKiemChungTu(string maChungTu, string tenChungTu, string maHang, string tenHang, string maNhomHang, string tenNhomHang, string soLuong, string donGia, string ghiChu, double thanhTien)
        {
            this.maChungTu = maChungTu;
            this.tenChungTu = tenChungTu;
            this.donGia = donGia;
            this.maHang = maHang;
            this.tenHang = tenHang;
            this.maNhomHang = maNhomHang;
            this.tenNhomHang = tenNhomHang;
            this.soLuong = soLuong;
            this.thanhTien = thanhTien;
            this.ghiChu = ghiChu;
        }

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public string MaChungTu
        {
            get { return maChungTu; }
            set { maChungTu = value; }
        }
        public string TenChungTu
        {
            get { return tenChungTu; }
            set { tenChungTu = value; }
        }
        public DateTime NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }
        public string MaHang
        {
            get { return maHang; }
            set { maHang = value; }
        }
        public string TenHang
        {
            get { return this.tenHang; }
            set { this.tenHang = value; }
        }
        public string SoLuong
        {
            get { return this.soLuong; }
            set { this.soLuong = value; }
        }
        public string DonGia
        {
            get { return this.donGia; }
            set { this.donGia = value; }
        }
        public double ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
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
        public string GhiChu
        {
            get { return this.ghiChu; }
            set { this.ghiChu = value; }
        }
        public double TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
    }
}
