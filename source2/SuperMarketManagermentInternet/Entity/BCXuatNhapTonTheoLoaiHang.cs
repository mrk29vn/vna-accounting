using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCXuatNhapTonTheoLoaiHang
    {
        private string maLoaiHang;
        private string tenLoaiHang;
        private string soDuDauKy;
        private string tongNhap;
        private string hanhDong;
        private string tongXuat;
        private string soDuCuoiKy;

        public BCXuatNhapTonTheoLoaiHang() { }
        public BCXuatNhapTonTheoLoaiHang(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public BCXuatNhapTonTheoLoaiHang(string hanhDong,string maLoaiHang, string tenLoaiHang, string soDuDauKy, string tongNhap, string tongXuat, string soDuCuoiKy)
        {
            this.hanhDong = hanhDong;
            this.maLoaiHang = maLoaiHang;
            this.tenLoaiHang = tenLoaiHang;
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
