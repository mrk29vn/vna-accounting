
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class TKKeToan
    {
        public string NhanVienID;
        public string TenDangNhap;
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private int tKKeToanID;
        private string maTKKeToan;
        private string tenTaiKhoan;
        private string nhomTKKT;
        private string ghiChu;
        private Boolean deleted;
        public TKKeToan()
        { }
        public TKKeToan(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public TKKeToan(string tenTaiKhoan, Boolean deleted)
        {
            this.tenTaiKhoan = tenTaiKhoan;
            this.deleted = deleted;
        }
        public TKKeToan(int tKKeToanID, string maTKKeToan, string tenTaiKhoan, string nhomTKKT, string ghiChu, Boolean deleted)
        {
            this.nhomTKKT = nhomTKKT;
            this.tKKeToanID = tKKeToanID;
            this.maTKKeToan = maTKKeToan;
            this.tenTaiKhoan = tenTaiKhoan;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public TKKeToan(string hanhdong, int tKKeToanID, string maTKKeToan, string tenTaiKhoan, string nhomTKKT, string ghiChu, Boolean deleted, string nhanVienID, string tenDangNhap)
        {
            this.hanhDong = hanhdong;
            this.tKKeToanID = tKKeToanID;
            this.maTKKeToan = maTKKeToan;
            this.tenTaiKhoan = tenTaiKhoan;
            this.nhomTKKT = nhomTKKT;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.NhanVienID = nhanVienID;
            this.TenDangNhap = tenDangNhap;
        }

        public int TKKeToanID
        {
            get { return this.tKKeToanID; }
            set
            {
                this.tKKeToanID = value;
            }
        }
        public string MaTKKeToan
        {
            get { return this.maTKKeToan; }
            set
            {
                this.maTKKeToan = value;
            }
        }
        public string TenTaiKhoan
        {
            get { return this.tenTaiKhoan; }
            set
            {
                this.tenTaiKhoan = value;
            }
        }
        public string NhomTKKT
        {
            get { return nhomTKKT; }
            set { nhomTKKT = value; }
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
