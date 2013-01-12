using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCXuatNhapTonPhieuXuatNhap
    {
        private string maPhieuXuatNhap;
        private string tenPhieuXuatNhap;
        private string maHang;
        private string tenHang;
        private double soDuDauKy;
        private double tongNhap;
        private string hanhDong;
        private double tongXuat;
        private double soDuCuoiKy;

        public BCXuatNhapTonPhieuXuatNhap()
        {
            this.maPhieuXuatNhap = "";
            this.tenPhieuXuatNhap = "";
            this.hanhDong = "";
            this.maHang = "";
            this.tenHang = "";
            this.soDuDauKy = 0;
            this.tongNhap = 0;
            this.tongXuat = 0;
            this.soDuCuoiKy = 0;
        }

        public BCXuatNhapTonPhieuXuatNhap(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public BCXuatNhapTonPhieuXuatNhap(string hanhDong, string maPhieuXuatNhap, string tenPhieuXuatNhap, string maHang, string tenHang, double soDuDauKy, double tongNhap, double tongXuat, double soDuCuoiKy)
        {
            this.maPhieuXuatNhap = maPhieuXuatNhap;
            this.tenPhieuXuatNhap = tenPhieuXuatNhap;
            this.hanhDong = hanhDong;
            this.maHang = maHang;
            this.tenHang = tenHang;
            this.soDuDauKy = soDuDauKy;
            this.tongNhap = tongNhap;
            this.tongXuat = tongXuat;
            this.soDuCuoiKy = soDuCuoiKy;
        }

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public string MaPhieuXuatNhap
        {
            get { return maPhieuXuatNhap; }
            set { maPhieuXuatNhap = value; }
        }
        public string TenPhieuXuatNhap
        {
            get { return tenPhieuXuatNhap; }
            set { tenPhieuXuatNhap = value; }
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

        public double SoDuDauKy
        {
            get { return soDuDauKy; }
            set { soDuDauKy = value; }
        }

        public double TongNhap
        {
            get { return tongNhap; }
            set { tongNhap = value; }
        }
        public double TongXuat
        {
            get { return tongXuat; }
            set { tongXuat = value; }
        }
        public double SoDuCuoiKy
        {
            get { return soDuCuoiKy; }
            set { soDuCuoiKy = value; }
        }
    }
}
