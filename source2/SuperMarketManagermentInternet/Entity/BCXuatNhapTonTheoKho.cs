using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCXuatNhapTonTheoKho
    {
        private string maKho;
        private string tenKho;
        private string soDuDauKy;
        private string tongNhap;
        private string hanhDong;
        private string tongXuat;
        private string soDuCuoiKy;

        public BCXuatNhapTonTheoKho() { }
        public BCXuatNhapTonTheoKho(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public BCXuatNhapTonTheoKho(string hanhDong, string maKho, string tenKho, string soDuDauKy, string tongNhap, string tongXuat, string soDuCuoiKy)
        {
            this.hanhDong = hanhDong;
            this.maKho = maKho;
            this.tenKho = tenKho;
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

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
        public string TenKho
        {
            get { return this.tenKho; }
            set { this.tenKho = value; }
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
