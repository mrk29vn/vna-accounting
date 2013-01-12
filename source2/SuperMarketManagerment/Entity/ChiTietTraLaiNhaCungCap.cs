using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ChiTietTraLaiNhaCungCap
    {
        #region hungvv===========================================================================================================
        private string hanhdong;
        private string maHDTraLaiNCC;
        private string maHangHoa;
        private int soLuong;
        private string donGia;

        public string DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        private string thue;

        public string Thue
        {
            get { return thue; }
            set { thue = value; }
        }
        private string phanTramChietKhau;
        private string ghiChu;
        private Boolean deleted;
        private string makho;


        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        public string MaHDTraLaiNCC
        {
            get { return this.maHDTraLaiNCC; }
            set { this.maHDTraLaiNCC = value; }
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
        public string Makho
        {
            get { return makho; }
            set { makho = value; }
        }
        public ChiTietTraLaiNhaCungCap() { }

        public ChiTietTraLaiNhaCungCap(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }

        public ChiTietTraLaiNhaCungCap(string hanhdong, string maHDTraLaiNCC, string maHangHoa)
        {
            this.hanhdong = hanhdong;
            this.maHDTraLaiNCC = maHDTraLaiNCC;
            this.maHangHoa = maHangHoa;
        }

        public ChiTietTraLaiNhaCungCap(string hanhdong, string maHDTraLaiNCC, string maHangHoa, int soLuong, string phanTramChietKhau, string ghiChu, Boolean deleted)
        {
            this.hanhdong = hanhdong;
            this.maHDTraLaiNCC = maHDTraLaiNCC;
            this.maHangHoa = maHangHoa;
            this.soLuong = soLuong;
            this.phanTramChietKhau = phanTramChietKhau;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        public ChiTietTraLaiNhaCungCap(string hanhdong, string maHDTraLaiNCC, string maHangHoa, int soLuong, string phanTramChietKhau, string ghiChu, Boolean deleted,string makho)
        {
            this.hanhdong = hanhdong;
            this.maHDTraLaiNCC = maHDTraLaiNCC;
            this.maHangHoa = maHangHoa;
            this.soLuong = soLuong;
            this.phanTramChietKhau = phanTramChietKhau;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.makho = makho;
        }
        #endregion
    }
}
