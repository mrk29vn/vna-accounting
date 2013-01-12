using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class BCXuatNhapTonTheoNhomHang
    {
        private string hanhDong;
        private string maNhomHang;
        private string tenNhomHang;
        private string soDuDauKy;
        private string tongNhap;
        private string tongXuat;
        private string soDuCuoiKy;

        public BCXuatNhapTonTheoNhomHang() { }
        public BCXuatNhapTonTheoNhomHang(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public BCXuatNhapTonTheoNhomHang(string hanhDong, string maNhomHang, string tenNhomHang, string soDuDauKy, string tongNhap, string tongXuat, string soDuCuoiKy)
        {
            this.hanhDong = hanhDong;
            this.maNhomHang = maNhomHang;
            this.tenNhomHang = tenNhomHang;
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

        public string SoDuDauKy
        {
            get { return soDuDauKy; }
            set { soDuDauKy = value; }
        }

        public string TongNhap
        {
            get { return tongNhap; }
            set { tongNhap = value; }
        }
        public string TongXuat
        {
            get { return tongXuat; }
            set { tongXuat = value; }
        }
        public string SoDuCuoiKy
        {
            get { return soDuCuoiKy; }
            set { soDuCuoiKy = value; }
        }
    }
}
