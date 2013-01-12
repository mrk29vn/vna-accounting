using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class KhachHang
    {
        private string hanhdong;
        private int khachHangID;
        private string maKH;
        private string ten;
        private string diaChi;
        private string dienThoai;
        private string fax;
        private string email;
        private string mST;
        private string duNo;
        private string hanMucTT;
        private string congTy;
        private DateTime ngaySinh;
        private int maVung;
        private string mobi;
        private DateTime ngayThamGia;
        private DateTime giaoDichCuoi;
        private Boolean ngungTheoDoi;
        private string website;
        private DateTime ngaySua;
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

        public KhachHang()
        {
        }
        public KhachHang(string Hanhdong, string cot, string giaTri, string kieu)
        {
            this.hanhdong = Hanhdong;
            this.cot = cot;
            this.giaTri = giaTri;
            this.kieu = kieu;
        }
        public KhachHang(string Hanhdong, int khachHangID)
        {
            this.hanhdong = Hanhdong;
            this.khachHangID = khachHangID;
        }
        public KhachHang(string Hanhdong, int khachHangID, string maNhanVien, string tenDangNhap)
        {
            this.hanhdong = Hanhdong;
            this.khachHangID = khachHangID;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public KhachHang(string Hanhdong, string maKH,string duNo)
        {
            this.hanhdong = Hanhdong;
            this.maKH = maKH;
            this.duNo = duNo;
        }
        public KhachHang(string Hanhdong)
        {
            this.hanhdong = Hanhdong;
        }
        public KhachHang( int khachHangID,string maKH, string ten, string diaChi, string dienThoai, string fax, 
            string email, string mST, string duNo, string hanMucTT, string congTy,DateTime ngaySinh,int maVung, string mobi,
            DateTime ngayThamGia,DateTime giaoDichCuoi,Boolean ngungTheoDoi,string website,DateTime ngaySua,string ghiChu, Boolean deleted)
        {
            this.khachHangID = khachHangID;
            this.maKH = maKH;
            this.ten = ten;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.fax = fax;
            this.email = email;
            this.mST = mST;
            this.duNo = duNo;
            this.hanMucTT = hanMucTT;
            this.congTy = congTy;
            this.ngaySinh = ngaySinh;
            this.maVung = maVung;
            this.mobi = mobi;
            this.ngayThamGia = ngayThamGia;
            this.giaoDichCuoi = giaoDichCuoi;
            this.ngungTheoDoi = ngungTheoDoi;
            this.website = website;
            this.ngaySua = ngaySua;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        public KhachHang(string hanhdong,int khachHangID, string maKH, string ten, string diaChi, string dienThoai, string fax,
            string email, string mST, string duNo, string hanMucTT, string congTy, DateTime ngaySinh, int maVung, string mobi,
            DateTime ngayThamGia, DateTime giaoDichCuoi, Boolean ngungTheoDoi, string website, DateTime ngaySua, string ghiChu, Boolean deleted, string maNhanVien, string tenDangNhap)
        {
            this.hanhdong = hanhdong;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
            this.khachHangID = khachHangID;
            this.maKH = maKH;
            this.ten = ten;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.fax = fax;
            this.email = email;
            this.mST = mST;
            this.duNo = duNo;
            this.hanMucTT = hanMucTT;
            this.congTy = congTy;
            this.ngaySinh = ngaySinh;
            this.maVung = maVung;
            this.mobi = mobi;
            //this.ngayThamGia = ngayThamGia;
            //this.giaoDichCuoi = giaoDichCuoi;
            this.ngungTheoDoi = ngungTheoDoi;
            this.website = website;
            //this.ngaySua = ngaySua;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public string HanhDong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        public int KhachHangID
        {
            get { return this.khachHangID; }
            set
            {
                this.khachHangID = value;
            }
        }
        public string MaKH
        {
            get { return this.maKH; }
            set
            {
                this.maKH = value;
            }
        }
        public string Ten
        {
            get { return this.ten; }
            set
            {
                this.ten = value;
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
        public string Fax
        {
            get { return this.fax; }
            set { this.fax = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
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
        public string HanMucTT
        {
            get { return this.hanMucTT; }
            set { this.hanMucTT = value; }
        }
        public string CongTy
        {
            get { return this.congTy; }
            set { this.congTy = value; }
        }
        public DateTime NgaySinh
        {
            get { return this.ngaySinh; }
            set { this.ngaySinh = value; }
        }
        public int MaVung
        {
            get { return this.maVung; }
            set { this.maVung = value; }
        }
        public string Mobi
        {
            get { return this.mobi; }
            set { this.mobi = value; }
        }
        public DateTime NgayThamGia
        {
            get { return this.ngayThamGia; }
            set { this.ngayThamGia = value; }
        }
        public DateTime GiaoDichCuoi
        {
            get { return this.giaoDichCuoi; }
            set { this.giaoDichCuoi = value; }
        }
        public Boolean NgungTheoDoi
        {
            get { return this.ngungTheoDoi; }
            set { this.ngungTheoDoi = value; }
        }
        public string Website
        {
            get { return this.website; }
            set { this.website = value; }
        }
        public DateTime NgaySua
        {
            get { return this.ngaySua; }
            set { this.ngaySua = value; }
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
