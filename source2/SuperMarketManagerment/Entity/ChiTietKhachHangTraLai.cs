using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ChiTietKhachHangTraLai
    {
        private string hanhdong;
        private string maKhachHangTraLai;
        private string maHangHoa;
        private int soLuong;
        private string phanTramChietKhau;
        private string donGia;
        private string thue;
        private string ghiChu;
        private Boolean deleted;
        private string makho;
        private string tenHangHoa;
        private DateTime ngayNhap = new DateTime(1753,1,1);

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
        public string MaKhachHangTraLai
        {
            get { return this.maKhachHangTraLai; }
            set { this.maKhachHangTraLai = value; }
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
        public string PhanTramChietKhau
        {
            get { return this.phanTramChietKhau; }
            set { this.phanTramChietKhau = value; }
        }
        public string DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        public string Thue
        {
            get { return thue; }
            set { thue = value; }
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
       
        public string Makho
        {
            get { return makho; }
            set { makho = value; }
        }

        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }

        public ChiTietKhachHangTraLai() { }

        public ChiTietKhachHangTraLai(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }
        public ChiTietKhachHangTraLai(string hanhdong, string maKhachHangTraLai, string maHangHoa)
        {
            this.hanhdong = hanhdong;
            this.maKhachHangTraLai = maKhachHangTraLai;
            this.maHangHoa = maHangHoa;
        }
        public ChiTietKhachHangTraLai(string hanhdong, string maKhachHangTraLai, string maHangHoa, int soLuong, string phanTramChietKhau, string ghiChu, Boolean deleted)
        {
            this.hanhdong = hanhdong;
            this.maKhachHangTraLai = maKhachHangTraLai;
            this.maHangHoa = maHangHoa;
            this.soLuong = soLuong;
            this.phanTramChietKhau = phanTramChietKhau;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        public ChiTietKhachHangTraLai(string hanhdong, string maKhachHangTraLai, string maHangHoa, int soLuong, string phanTramChietKhau, string ghiChu, Boolean deleted,string makho)
        {
            this.hanhdong = hanhdong;
            this.maKhachHangTraLai = maKhachHangTraLai;
            this.maHangHoa = maHangHoa;
            this.soLuong = soLuong;
            this.phanTramChietKhau = phanTramChietKhau;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.makho = makho;
        }

    }
}
