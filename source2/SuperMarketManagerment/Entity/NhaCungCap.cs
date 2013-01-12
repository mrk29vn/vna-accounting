using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class NhaCungCap
    {
        private string hanhdong;
        private int nhaCungCapID;
        private string maNhaCungCap;
        private string tenNhaCungCap;
        private string diaChi;
        private string dienThoai;
        private string email;
        private string fax;
        private string nguoiLienHe;
        private string mST;
        private string duNo;
        private string website;
        private string ghiChu;
        private Boolean deleted;
        private string maNhanVien;
        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }
        private string tenDangNhap;
        public string TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }
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
        public NhaCungCap()
        { }
        public NhaCungCap(string Hanhdong)
        {
            this.hanhdong = Hanhdong;
        }
        public NhaCungCap(string Hanhdong, int nhaCungCapID)
        {
            this.hanhdong = Hanhdong;
            this.nhaCungCapID = nhaCungCapID;
        }
        public NhaCungCap(string hanhdong, int nhaCungCapID, string maNhanVien, string tenDangNhap)
        {
            this.hanhdong = hanhdong;
            this.nhaCungCapID = nhaCungCapID;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public NhaCungCap(string hanhDong, string maNhaCungCap, string duNo)
        {
            this.hanhdong = hanhDong;
            this.maNhaCungCap = maNhaCungCap;
            this.duNo = duNo;
        }
        public NhaCungCap(string hanhDong, int nhaCungCapID, string maNhaCungCap, string tenNhaCungCap, string diaChi, string dienThoai, string email, string fax, string nguoiLienHe, string mST, string duNo, string website, string ghiChu, Boolean deleted, string maNhanVien, string tenDangNhap)
        {
            this.hanhdong = hanhDong;
            this.nhaCungCapID = nhaCungCapID;
            this.maNhaCungCap = maNhaCungCap;
            this.tenNhaCungCap = tenNhaCungCap;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.email = email;
            this.fax = fax;
            this.nguoiLienHe = nguoiLienHe;
            this.mST = mST;
            this.duNo = duNo;
            this.website = website;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public NhaCungCap(string Hanhdong, string cot, string giaTri, string kieu)
        {
            this.hanhdong = Hanhdong;
            this.cot = cot;
            this.giaTri = giaTri;
            this.kieu = kieu;
        }

        public NhaCungCap(string hanhdong,int nhacungcapid, string maNhaCungCap, string tenNhaCungCap, string diaChi, string dienThoai, string email, string fax, string nguoiLienHe, string mST, string duNo, string website, string ghiChu, Boolean deleted)
        {
            this.hanhdong = hanhdong;
            this.nhaCungCapID = nhacungcapid;
            this.maNhaCungCap = maNhaCungCap;
            this.tenNhaCungCap = tenNhaCungCap;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.email = email;
            this.fax = fax;
            this.nguoiLienHe = nguoiLienHe;
            this.mST = mST;
            this.duNo = duNo;
            this.website = website;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public string HanhDong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }

        public int NhaCungCapID
        {
            get { return this.nhaCungCapID; }
            set
            {
                this.nhaCungCapID = value;
            }
        }
        public string MaNhaCungCap
        {
            get { return this.maNhaCungCap; }
            set
            {
                this.maNhaCungCap = value;
            }
        }
        public string TenNhaCungCap
        {
            get { return this.tenNhaCungCap; }
            set
            {
                this.tenNhaCungCap = value;
            }
        }
        public string DiaChi
        {
            get { return this.diaChi; }
            set { this.diaChi = value; }
        }
        public string DienThoai
        {
            get { return this.dienThoai; }
            set { this.dienThoai = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string Fax
        {
            get { return this.fax; }
            set { this.fax = value; }
        }
        public string NguoiLienHe
        {
            get { return this.nguoiLienHe; }
            set { this.nguoiLienHe = value; }
        }
        public string MST
        {
            get { return this.mST; }
            set { this.mST = value; }
        }
        public string DuNo
        {
            get { return this.duNo; }
            set { this.duNo = value; }
        }
        public string Website
        {
            get { return this.website; }
            set { this.website = value; }
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
