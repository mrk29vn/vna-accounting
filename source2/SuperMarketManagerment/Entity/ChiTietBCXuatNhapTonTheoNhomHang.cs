using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class ChiTietBCXuatNhapTonTheoNhomHang
    {
        private string maNhomHang;
        private string tenNhomHang;
        private string maHangHoa;
        private string tenHangHoa;
        private int duDauKy;
        private int nhapMua;
        private int nhapTraLai;
        private int nhapKhac;
        private int xuatBan;
        private int xuatTraLai;
        private int xuatKhac;
        private int duCuoiKy;
        public ChiTietBCXuatNhapTonTheoNhomHang() { }
        public ChiTietBCXuatNhapTonTheoNhomHang(string maNhomHang, string tenNhomHang, string maHangHoa, string tenHangHoa, int duDauKy, int nhapMua, int nhapTraLai, int nhapKhac, int xuatBan, int xuatTraLai, int xuatKhac, int duCuoiKy)
        {
            this.maNhomHang = maNhomHang;
            this.tenNhomHang=tenNhomHang;
            this.maHangHoa=maHangHoa;
            this.tenHangHoa=tenHangHoa;
            this.duDauKy = duDauKy;
            this.nhapMua = nhapMua;
            this.nhapTraLai = nhapTraLai;
            this.nhapKhac = nhapKhac;
            this.xuatBan = xuatBan;
            this.xuatTraLai = xuatTraLai;
            this.xuatKhac = xuatKhac;
            this.duCuoiKy = duCuoiKy;
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
        public int DuDauKy
        {
            get { return this.duDauKy; }
            set { this.duDauKy = value; }
        }
        public int NhapMua
        {
            get { return this.nhapMua; }
            set { this.nhapMua = value; }
        }
        public int NhapTraLai
        {
            get { return this.nhapTraLai; }
            set { this.nhapTraLai = value; }
        }
        public int NhapKhac
        {
            get { return this.nhapKhac; }
            set { this.nhapKhac = value; }
        }
        public int XuatBan
        {
            get { return this.xuatBan; }
            set { this.xuatBan = value; }
        }
        public int XuatTraLai
        {
            get { return this.xuatTraLai; }
            set { this.xuatTraLai = value; }
        }
        public int XuatKhac
        {
            get { return this.xuatKhac; }
            set { this.xuatKhac = value; }
        }
        public int DuCuoiKy
        {
            get { return this.duCuoiKy; }
            set { this.duCuoiKy = value; }
        }
    }
}
