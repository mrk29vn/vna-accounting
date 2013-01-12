using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class NhanVien
    {
        public string NhanVienID1;
        public string TenDangNhap;
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private int nhanVienID;
        private string maNhanVien;
        private string tenNhanVien;
        private string maPhongBan;
        private string tenPhongBan;
        private string dCThuongTru;
        private string dCTamTru;
        private string dienThoaiCD;
        private string dienThoaiDD;
        private string email;
        private string cMND;
        private DateTime ngayCap;
        private string noiCap;
        private DateTime ngaySinh;
        private string ghiChu;
        private bool deleted;
        private string cot;
        public string Cot
        {
            get { return cot; }
            set { cot = value; }
        }

        private string kieu;
        public string Kieu
        {
            get { return kieu; }
            set { kieu = value; }
        }

        private string giaTri;
        public string GiaTri
        {
            get { return giaTri; }
            set { giaTri = value; }
        }

        public NhanVien(string Hanhdong, string cot, string giaTri, string kieu)
        {
            this.hanhDong = Hanhdong;
            this.cot = cot;
            this.giaTri = giaTri;
            this.kieu = kieu;
        }
        public NhanVien()
        { }
        public NhanVien(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public NhanVien(int nhanVienID, string maNhanVien, string tenNhanVien, string maPhongBan , string tenPhongBan, string dCThuongTru, string dCTamTru, string dienThoaiCD, string dienThoaiDD, string email, string cMND, DateTime ngayCap, string noiCap, DateTime ngaySinh, string ghiChu, bool deleted)
        {
            this.nhanVienID = nhanVienID;
            this.maNhanVien = maNhanVien;
            this.tenNhanVien = tenNhanVien;
            this.maPhongBan = maPhongBan;
            this.tenPhongBan = tenPhongBan;
            this.dCThuongTru = dCThuongTru;
            this.dCTamTru = dCTamTru;
            this.dienThoaiCD = dienThoaiCD;
            this.dienThoaiDD = dienThoaiDD;
            this.email = email;
            this.cMND = cMND;
            this.ngayCap = ngayCap;
            this.noiCap = noiCap;
            this.ngaySinh = ngaySinh;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public NhanVien(string hanhDong, int nhanVienID, string maNhanVien, string tenNhanVien, string maPhongBan, string tenPhongBan, string dCThuongTru, string dCTamTru, string dienThoaiCD, string dienThoaiDD, string email, string cMND, DateTime ngayCap, 
            string noiCap, DateTime ngaySinh, string ghiChu, bool deleted,string nhanVienID1, string tenDangNhap)
        {
            this.hanhDong = hanhDong;
            this.nhanVienID = nhanVienID;
            this.maNhanVien = maNhanVien;
            this.tenNhanVien = tenNhanVien;
            this.maPhongBan = maPhongBan;
            this.tenPhongBan = tenPhongBan;
            this.dCThuongTru = dCThuongTru;
            this.dCTamTru = dCTamTru;
            this.dienThoaiCD = dienThoaiCD;
            this.dienThoaiDD = dienThoaiDD;
            this.email = email;
            this.cMND = cMND;
            this.ngayCap = ngayCap;
            this.noiCap = noiCap;
            this.ngaySinh = ngaySinh;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.NhanVienID1 = nhanVienID1;
            this.TenDangNhap = tenDangNhap;
        }
        public int NhanVienID
        {
            get { return this.nhanVienID; }
            set
            {
                this.nhanVienID = value;
            }
        }
        public string MaNhanVien
        {
            get { return this.maNhanVien; }
            set
            {
                this.maNhanVien = value;
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
        public string MaPhongBan
        {
            get { return this.maPhongBan; }
            set
            {
                this.maPhongBan = value;
            }
        }
        public string TenPhongBan
        {
            get { return tenPhongBan; }
            set { tenPhongBan = value; }
        }
        public string DCThuongTru
        {
            get { return this.dCThuongTru; }
            set { this.dCThuongTru = value; }
        }
        public string DCTamTru
        {
            get { return this.dCTamTru; }
            set { this.dCTamTru = value; }
        }
        public string DienThoaiCD
        {
            get { return this.dienThoaiCD; }
            set { this.dienThoaiCD = value; }
        }
        public string DienThoaiDD
        {
            get { return this.dienThoaiDD; }
            set { this.dienThoaiDD = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string CMND
        {
            get { return this.cMND; }
            set
            {
                this.cMND = value;
            }
        }
        public DateTime NgayCap
        {
            get { return this.ngayCap; }
            set { this.ngayCap = value; }
        }
        public string NoiCap
        {
            get { return this.noiCap; }
            set { this.noiCap = value; }
        }
        public DateTime NgaySinh
        {
            get { return this.ngaySinh; }
            set { this.ngaySinh = value; }
        }
        public string GhiChu
        {
            get { return this.ghiChu; }
            set { this.ghiChu = value; }
        }
        public bool Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }

    }
}
