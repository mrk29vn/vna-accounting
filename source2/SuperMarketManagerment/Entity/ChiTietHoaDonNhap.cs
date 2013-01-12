using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ChiTietHoaDonNhap
    {
        private string hanhdong;
        private int iD;
        private string maHoaDonNhap;
        private string tenHangHoa;
        private string maHangHoa;
        private int soLuong;
        private string phanTramChietKhau;
        private string donGia;
        private string thue;
        private string ghiChu;
        private Boolean deleted;
        private string tenKho;
        private DateTime ngayNhap = new DateTime(1753, 1, 1);

        public ChiTietHoaDonNhap()
        { }
        public ChiTietHoaDonNhap(string hanhdong)
        { this.hanhdong = hanhdong; }
        public ChiTietHoaDonNhap(string hanhdong, int iD, string maHoaDonNhap, string tenHangHoa, string maHangHoa, int soLuong, string donGia, string thue, string phanTramChietKhau, string ghiChu, Boolean deleted)
        {
            this.hanhdong = hanhdong;
            this.iD = iD;
            this.maHoaDonNhap = maHoaDonNhap;
            this.tenHangHoa = tenHangHoa;
            this.maHangHoa = maHangHoa;
            this.soLuong = soLuong;
            this.donGia = donGia;
            this.thue = thue;
            this.phanTramChietKhau = phanTramChietKhau;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        public int ID
        {
            get { return this.iD; }
            set {this.iD = value; }
        }
        public string MaHoaDonNhap
        {
            get { return this.maHoaDonNhap; }
            set { this.maHoaDonNhap = value; }
        }
        public string TenHangHoa
        {
            get { return this.tenHangHoa; }
            set { this.tenHangHoa = value; }
        }
        public string MaHangHoa
        {
            get { return this.maHangHoa; }
            set { this.maHangHoa = value; }
        }
        public int SoLuong
        {
            get { return this.soLuong; }
            set { this.soLuong = value; }
        }
        public string DonGia
        {
            get { return this.donGia; }
            set { this.donGia = value; }
        }

        public string Thue
        {
            get { return thue; }
            set { thue = value; }
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
        public string TenKho
        {
            get { return tenKho; }
            set { tenKho = value; }
        }
        private string maKho;

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }

        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }
    }
}
