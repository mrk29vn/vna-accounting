using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class BCKhachHangDatHang
    {
        private string maDonDatHang;
        private string maKH;
        private string ten;
        private string maHang;
        private string tenHang;
        private double soLuong;
        private double gia;
        private double chietKhau;
        private double thue;
        private double tongTienCK;
        private double tongTien;

        public string MaDonDatHang
        {
            get { return this.maDonDatHang; }
            set { this.maDonDatHang = value; }
        }
        public string MaKH
        {
            get { return this.maKH; }
            set { this.maKH = value; }
        }
        public string Ten
        {
            get { return this.ten; }
            set { this.ten = value; }
        }
        public string MaHang
        {
            get { return this.maHang; }
            set { this.maHang = value; }
        }
        public string TenHang
        {
            get { return this.tenHang; }
            set { this.tenHang = value; }
        }
        public double SoLuong
        {
            get { return this.soLuong; }
            set { this.soLuong = value; }
        }
        public double Gia
        {
            get { return this.gia; }
            set { this.gia = value; }
        }
        public double ChietKhau
        {
            get { return this.chietKhau; }
            set { this.chietKhau = value; }
        }
        public double Thue
        {
            get { return this.thue; }
            set { this.thue = value; }
        }
        public double TongTienCK
        {
            get { return this.tongTienCK; }
            set { this.tongTienCK = value; }
        }
        public double TongTien
        {
            get { return this.tongTien; }
            set { this.tongTien = value; }
        }
    }
}
