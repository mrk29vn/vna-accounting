using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class mrk
    {
        public mrk() { }
    }

    [Serializable]
    public class KhachHang_k
    {
        public KhachHang_k() 
        {
            this.thaoTac = "";
            this.maKH = "";
            this.ten = "";
            this.diaChi = "";
            this.dienThoai = "";
            this.fax = "";
            this.email = "";
            this.mST = "";
            this.duNo = 0;
            this.hanMucTT = 0;
            this.congTy = "";
            this.ngaySinh = new DateTime(1753,1,1);
            this.maVung = 0;
            this.mobi = "";
            this.ngayThamGia = new DateTime(1753,1,1);
            this.giaoDichCuoi = new DateTime(1753,1,1);
            this.ngungTheoDoi = false;
            this.website = "";
            this.ngaySua = new DateTime(1753,1,1);
            this.ghiChu = "";
            this.deleted = false;
        }

        public KhachHang_k(string thaoTac, string maKH, string ten, string diaChi, string dienThoai, string fax, string email, string mST, float duNo, float hanMucTT, string congTy, DateTime ngaySinh, int maVung, string mobi, DateTime ngayThamGia, DateTime giaoDichCuoi, bool ngungTheoDoi, string website, DateTime ngaySua, string ghiChu, bool deleted)
        { 
            this.thaoTac = thaoTac;
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

        string thaoTac;

        public string ThaoTac
        {
            get { return thaoTac; }
            set { thaoTac = value; }
        }
        string maKH;

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        string ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        string diaChi;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        string dienThoai;

        public string DienThoai
        {
            get { return dienThoai; }
            set { dienThoai = value; }
        }
        string fax;

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }
        string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        string mST;

        public string MST
        {
            get { return mST; }
            set { mST = value; }
        }
        float duNo;

        public float DuNo
        {
            get { return duNo; }
            set { duNo = value; }
        }
        float hanMucTT;

        public float HanMucTT
        {
            get { return hanMucTT; }
            set { hanMucTT = value; }
        }
        string congTy;

        public string CongTy
        {
            get { return congTy; }
            set { congTy = value; }
        }
        DateTime ngaySinh;

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }
        int maVung;

        public int MaVung
        {
            get { return maVung; }
            set { maVung = value; }
        }
        string mobi;

        public string Mobi
        {
            get { return mobi; }
            set { mobi = value; }
        }
        DateTime ngayThamGia;

        public DateTime NgayThamGia
        {
            get { return ngayThamGia; }
            set { ngayThamGia = value; }
        }
        DateTime giaoDichCuoi;

        public DateTime GiaoDichCuoi
        {
            get { return giaoDichCuoi; }
            set { giaoDichCuoi = value; }
        }
        bool ngungTheoDoi;

        public bool NgungTheoDoi
        {
            get { return ngungTheoDoi; }
            set { ngungTheoDoi = value; }
        }
        string website;

        public string Website
        {
            get { return website; }
            set { website = value; }
        }
        DateTime ngaySua;

        public DateTime NgaySua
        {
            get { return ngaySua; }
            set { ngaySua = value; }
        }
        string ghiChu;

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        bool deleted;

        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
