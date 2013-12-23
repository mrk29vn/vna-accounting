using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCXuatNhapTonTheoKhoChiTiet
    {
        private string maKho;
        private string tenKho;
        private string maHang;
        private string tenHang;
        private double soDuDauKy;
        private double nhapMua;
        private double nhapTraLai;
        private double nhapKhac;
        private double xuatBan;
        private double xuatTraLai;
        private double xuatKhac;
        private double soDuCuoiKy;
        public BCXuatNhapTonTheoKhoChiTiet(string maKho, string tenKho,string maHang,string tenHang, double soDuDauKy, double nhapMua, double nhapTraLai,
            double nhapKhac, double xuatBan, double xuatTraLai, double xuatKhac, double soDuCuoiKy)
        {
            this.maKho = maKho;
            this.tenKho = tenKho;
            this.maHang = maHang;
            this.tenHang = tenHang;
            this.soDuDauKy = soDuDauKy;
            this.nhapMua = nhapMua;
            this.nhapTraLai = nhapTraLai;
            this.nhapKhac = nhapKhac;
            this.xuatBan = xuatBan;
            this.xuatTraLai = xuatTraLai;
            this.xuatKhac = xuatKhac;
            this.soDuCuoiKy = soDuCuoiKy;
        }
        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
        public string TenKho
        {
            get { return tenKho; }
            set { tenKho = value; }
        }
        public string MaHang
        {
            get { return maHang; }
            set { maHang = value; }
        }
        public string TenHang
        {
            get { return tenHang; }
            set { tenHang = value; }
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
