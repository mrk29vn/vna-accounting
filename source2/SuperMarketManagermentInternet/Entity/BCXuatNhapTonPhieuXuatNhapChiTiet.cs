using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCXuatNhapTonPhieuXuatNhapChiTiet
    {
        private string maPhieuXuatNhap;
        private string tenPhieuXuatNhap;
        private string maLoaiHang;
        private string tenLoaiHang;
        private double soDuDauKy;
        private double nhapMua;
        private double nhapTraLai;
        private double nhapKhac;
        private double xuatBan;
        private double xuatTraLai;
        private double xuatKhac;
        private double soDuCuoiKy;

        public BCXuatNhapTonPhieuXuatNhapChiTiet(string maPhieuXuatNhap, string tenPhieuXuatNhap, string maLoaiHang,
            string tenLoaiHang, double soDuDauKy, double nhapMua, double nhapTraLai, double nhapKhac, double xuatBan, double xuatTraLai, 
            double xuatKhac, double soDuCuoiKy)
        {
            this.maPhieuXuatNhap = maPhieuXuatNhap;
            this.tenPhieuXuatNhap = tenPhieuXuatNhap;
            this.maLoaiHang = maLoaiHang;
            this.tenLoaiHang = tenLoaiHang;
            this.soDuDauKy = soDuDauKy;
            this.nhapMua = nhapMua;
            this.nhapTraLai = nhapTraLai;
            this.nhapKhac = nhapKhac;
            this.xuatBan = xuatBan;
            this.xuatTraLai = xuatTraLai;
            this.xuatKhac = xuatKhac;
            this.soDuCuoiKy = soDuCuoiKy;
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
        public string MaLoaiHang
        {
            get { return maLoaiHang; }
            set { maLoaiHang = value; }
        }
        public string TenLoaiHang
        {
            get { return this.tenLoaiHang; }
            set { this.tenLoaiHang = value; }
        }

        public double SoDuDauKy
        {
            get { return soDuDauKy; }
            set { soDuDauKy = value; }
        }
        public double NhapMua
        {
            get { return nhapMua; }
            set { nhapMua = value; }
        }
        public double NhapTraLai
        {
            get { return nhapTraLai; }
            set { nhapTraLai = value; }
        }
        public double NhapKhac
        {
            get { return nhapKhac; }
            set { nhapKhac = value; }
        }
        public double XuatBan
        {
            get { return xuatBan; }
            set { xuatBan = value; }
        }
        public double XuatTraLai
        {
            get { return xuatTraLai; }
            set { xuatTraLai = value; }
        }
        public double XuatKhac
        {
            get { return xuatKhac; }
            set { xuatKhac = value; }
        }
        public double SoDuCuoiKy
        {
            get { return soDuCuoiKy; }
            set { soDuCuoiKy = value; }
        }
    }
}
