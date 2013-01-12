using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class HangHoaHienThi
    {
        private string tenHang;
        private string donGia;
        private string chietKhau;
        private string maHDBanHang;
        private string maHangHoa;
        private string soLuong;
        public string MaHDBanHang
        {
            get { return this.maHDBanHang; }
            set { this.maHDBanHang = value; }
        }
        public string MaHangHoa
        {
            get { return this.maHangHoa; }
            set { this.maHangHoa = value; }
        }

        public string TenHang
        {
            get { return this.tenHang; }
            set { this.tenHang = value; }
        }
        public string DonGia
        {
            get { return this.donGia; }
            set { this.donGia = value; }
        }
        public string SoLuong
        {
            get { return this.soLuong; }
            set { this.soLuong = value; }
        }
        public string ChietKhau
        {
            get { return this.chietKhau; }
            set { this.chietKhau = value; }
        }
        private string thueGTGT;
        public string ThueGTGT
        {
            get { return this.thueGTGT; }
            set { this.thueGTGT = value; }
        }
        private string thanhTien;
        public string ThanhTien
        {
            get { return this.thanhTien; }
            set { this.thanhTien = value; }
        }
        public HangHoaHienThi() { }
        public HangHoaHienThi(string maHDBanHang, string maHangHoa, string tenHang, string donGia, string soLuong, string chietKhau,string thueGTGT)
        {
            this.maHDBanHang = maHDBanHang;
            this.maHangHoa = maHangHoa;
            this.tenHang = tenHang;
            this.donGia = donGia;
            this.soLuong = soLuong;
            this.chietKhau = chietKhau;
            this.thueGTGT = thueGTGT;
        }
        public HangHoaHienThi(string maHDBanHang, string maHangHoa, string tenHang, string donGia, string soLuong, string chietKhau)
        {
            this.maHDBanHang = maHDBanHang;
            this.maHangHoa = maHangHoa;
            this.tenHang = tenHang;
            this.donGia = donGia;
            this.soLuong = soLuong;
            this.chietKhau = chietKhau;
        }
        public HangHoaHienThi(string maHDBanHang, string maHangHoa, string tenHang, string donGia, string soLuong, string chietKhau,string thueGTGT, string thanhTien)
        {
            this.maHDBanHang = maHDBanHang;
            this.maHangHoa = maHangHoa;
            this.tenHang = tenHang;
            this.donGia = donGia;
            this.soLuong = soLuong;
            this.chietKhau = chietKhau;
            this.thueGTGT = thueGTGT;
            this.thanhTien = thanhTien;
        }

    }
}
