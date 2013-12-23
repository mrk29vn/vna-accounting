using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
   public class ChiTietHDBanHang
    {
        private string maHDBanHang;
        private string maHangHoa;
        private string tenHangHoa;
        private int soLuong;
        private string donGia;
        private string thue;
        private float phanTramChietKhau;
        private string ghiChu;
        private Boolean deleted;
        private string hanhDong;

        public ChiTietHDBanHang()
        { }
        public ChiTietHDBanHang(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public ChiTietHDBanHang(string hanhDong, string maHDBanHang)
        {
            this.hanhDong = hanhDong;
            this.maHDBanHang = maHDBanHang;
        }
        public ChiTietHDBanHang(string hanhDong, string maHDBanHang, string maHangHoa)
        {
            this.hanhDong = hanhDong;
            this.maHDBanHang = maHDBanHang;
            this.maHangHoa = maHangHoa;
        }

        public ChiTietHDBanHang(string hanhDong, string maHDBanHang, string maHangHoa, int soLuong, float phanTramChietKhau, string ghiChu, Boolean deleted)
        {
            this.hanhDong = hanhDong;
            this.maHDBanHang = maHDBanHang;
            this.maHangHoa = maHangHoa;
            this.soLuong = soLuong;
            this.phanTramChietKhau = phanTramChietKhau;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public string HanhDong
        {
            get { return this.hanhDong; }
            set { this.hanhDong = value; }
        }

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
        public string TenHangHoa
        {
            get { return this.tenHangHoa; }
            set { this.tenHangHoa = value; }
        }
        public int SoLuong
        {
            get { return this.soLuong; }
            set
            {
                this.soLuong = value;
            }
        }
        public string DonGia
        {
            get { return this.donGia; }
            set { this.donGia = value; }
        }
        public string Thue
        {
            get { return this.thue; }
            set { this.thue = value; }
        }
        public float PhanTramChietKhau
        {
            get { return this.phanTramChietKhau; }
            set { this.phanTramChietKhau = value; }
        }
        public string GhiChu
        {
            get { return this.ghiChu; }
            set { this.ghiChu = value; }
        }
        public Boolean Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }

    }
}
