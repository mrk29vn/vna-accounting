using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ChiTietDonDatHang
    {
        #region hungvv===========================================================================================================
        private string hanhdong;
        private string maDonDatHang;
        private string maHangHoa;
        private int soLuong;
        private string donGia;
        private string thue;
        private string phanTramChietKhau;
        private string ghiChu;
        private Boolean deleted;
        private string tenHangHoa;

        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }

        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        public string MaDonDatHang
        {
            get { return this.maDonDatHang; }
            set { this.maDonDatHang = value; }
        }
        public string MaHangHoa
        {
            get { return this.maHangHoa; }
            set { this.maHangHoa = value; }
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
        public string PhanTramChietKhau
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

        public ChiTietDonDatHang() { }

        public ChiTietDonDatHang(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }
        public ChiTietDonDatHang(string hanhdong, string maDonDatHang, string maHangHoa)
        {
            this.hanhdong = hanhdong;
            this.maDonDatHang = maDonDatHang;
            this.maHangHoa = maHangHoa;
        }
        public ChiTietDonDatHang(string hanhdong, string maDonDatHang)
        {
            this.hanhdong = hanhdong;
            this.maDonDatHang = maDonDatHang;
        }
        public ChiTietDonDatHang(string hanhdong, string maDonDatHang, string maHangHoa, int soLuong, string phanTramChietKhau, string ghiChu, Boolean deleted)
        {
            this.hanhdong = hanhdong;
            this.maDonDatHang = maDonDatHang;
            this.maHangHoa = maHangHoa;
            this.soLuong = soLuong;
            this.phanTramChietKhau = phanTramChietKhau;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        #endregion
    }
}
