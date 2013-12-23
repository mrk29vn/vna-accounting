using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class TaiKhoan
    {
        private string tenDangNhap;
        private string matKhauDangNhap;
        private bool khoaTaiKhoan;
        private string nhanVienID;
        private bool administrator;
        private string tenNhomQuyen;
        private string tenNhanVien;
        public string MaNV="";
        public string TenDN="";
        public TaiKhoan()
        { }
        public TaiKhoan(string tenDangNhap)
        { this.tenDangNhap = tenDangNhap; }
        public TaiKhoan(string tenDangNhap, string matKhauDangNhap)
        {
            this.tenDangNhap = tenDangNhap;
            this.matKhauDangNhap = matKhauDangNhap;
        }
        public TaiKhoan(string tenDangNhap, string matKhauDangNhap, bool khoaTaiKhoan, string nhanVienID, bool administrator, string tenNhomQuyen,string tenNhanVien)
        {
            this.tenDangNhap = tenDangNhap;
            this.matKhauDangNhap = matKhauDangNhap;
            this.khoaTaiKhoan = khoaTaiKhoan;
            this.nhanVienID = nhanVienID;
            this.administrator = administrator;
            this.tenNhomQuyen = tenNhomQuyen;
            this.tenNhanVien = tenNhanVien;
        }
        public TaiKhoan(string tenDangNhap, string matKhauDangNhap, bool khoaTaiKhoan, string nhanVienID, bool administrator, string tenNhomQuyen)
        {
            this.tenDangNhap = tenDangNhap;
            this.matKhauDangNhap = matKhauDangNhap;
            this.khoaTaiKhoan = khoaTaiKhoan;
            this.nhanVienID = nhanVienID;
            this.administrator = administrator;
            this.tenNhomQuyen = tenNhomQuyen;
        }
        public string TenDangNhap
        {
            get { return this.tenDangNhap; }
            set
            {
                this.tenDangNhap = value;
            }
        }
        public string MatKhauDangNhap
        {
            get { return this.matKhauDangNhap; }
            set
            {
                this.matKhauDangNhap = value;
            }
        }
        public bool KhoaTaiKhoan
        {
            get { return this.khoaTaiKhoan; }
            set { this.khoaTaiKhoan = value; }
        }
        public string NhanVienID
        {
            get { return this.nhanVienID; }
            set { this.nhanVienID = value; }
        }
        public bool Administrator
        {
            get { return this.administrator; }
            set { this.administrator = value; }
        }
        public string TenNhomQuyen
        {
            get { return this.tenNhomQuyen; }
            set
            {

                this.tenNhomQuyen = value;
            }
        }
        public string TenNhanVien
        {
            get { return this.tenNhanVien; }
            set
            {

                this.tenNhanVien = value;
            }
        }
    }
}
