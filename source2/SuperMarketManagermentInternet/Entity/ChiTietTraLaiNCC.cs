using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ChiTietTraLaiNCC
    {
        #region hungvv===========================================================================================================
        private string hanhdong;
        private string maHDTraLaiNCC;
        private string maHangHoa;
        private int soLuong;
        private string phanTramChietKhau;
        private string ghiChu;
        private string deleted;
       
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
        public string Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }

        public ChiTietTraLaiNCC() { }

        public ChiTietTraLaiNCC(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }

        public ChiTietTraLaiNCC(string hanhdong, string maHDTraLaiNCC, string maHangHoa)
        {
            this.hanhdong = hanhdong;
            this.maHDTraLaiNCC = maHDTraLaiNCC;
            this.maHangHoa = maHangHoa;
        }

        public ChiTietTraLaiNCC(string hanhdong, string maHDTraLaiNCC, string maHangHoa, int soLuong, string phanTramChietKhau, string ghiChu, string deleted)
        {
            this.hanhdong = hanhdong;
            this.maHDTraLaiNCC = maHDTraLaiNCC;
            this.maHangHoa = maHangHoa;
            this.soLuong = soLuong;
            this.phanTramChietKhau = phanTramChietKhau;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        #endregion
    }
}
