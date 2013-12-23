using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class GoiHang
    {
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private int goiHangID;
        private string maKho;

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
        private string maGoiHang;
        private string tenGoiHang;
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
        private string maNhomHang;

        public string MaNhomHang
        {
            get { return maNhomHang; }
            set { maNhomHang = value; }
        }
        private string tenNhomHang;

        public string TenNhomHang
        {
            get { return tenNhomHang; }
            set { tenNhomHang = value; }
        }
        private string giaNhap;
        private string giaBanBuon;
        private string giaBanLe;
        private Boolean deleted;
        public GoiHang()
        { }
        public GoiHang(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public GoiHang(string hanhdong, string magoihang)
        {
            this.hanhDong = hanhdong;
            this.maGoiHang = magoihang;
        }
        public GoiHang(string hanhdong, int goiHangID, string maNhanVien, string tenDangNhap)
        {
            this.hanhDong = hanhdong;
            this.goiHangID = goiHangID;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public GoiHang(string hanhdong, int goiHangID, string maGoiHang, string tenGoiHang, string maNhomHang, string tenNhomHang, string giaNhap, string giaBanBuon, string giaBanLe, Boolean deleted)
        {
            this.hanhDong = hanhdong;
            this.goiHangID = goiHangID;
            this.maGoiHang = maGoiHang;
            this.tenGoiHang = tenGoiHang;
            this.maNhomHang = maNhomHang;
            this.tenNhomHang = tenNhomHang;
            this.giaNhap = giaNhap;
            this.giaBanBuon = giaBanBuon;
            this.giaBanLe = giaBanLe;
            this.deleted = deleted;
        }
        public GoiHang(string hanhdong, int goiHangID,string maKho, string maGoiHang, string tenGoiHang, string maNhomHang, string tenNhomHang, string giaNhap, string giaBanBuon, string giaBanLe, Boolean deleted, string maNhanVien, string tenDangNhap)
        {
            this.hanhDong = hanhdong;
            this.goiHangID = goiHangID;
            this.maKho = maKho;
            this.maGoiHang = maGoiHang;
            this.tenGoiHang = tenGoiHang;
            this.maNhomHang = maNhomHang;
            this.tenNhomHang = tenNhomHang;
            this.giaNhap = giaNhap;
            this.giaBanBuon = giaBanBuon;
            this.giaBanLe = giaBanLe;
            this.deleted = deleted;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public int GoiHangID
        {
            get { return this.goiHangID; }
            set
            {
                this.goiHangID = value;
            }
        }
        public string MaGoiHang
        {
            get { return this.maGoiHang; }
            set
            {
                this.maGoiHang = value;
            }
        }
        public string TenGoiHang
        {
            get { return this.tenGoiHang; }
            set { this.tenGoiHang = value; }
        }
        public string GiaNhap
        {
            get { return this.giaNhap; }
            set { this.giaNhap = value; }
        }
        public string GiaBanBuon
        {
            get { return this.giaBanBuon; }
            set { this.giaBanBuon = value; }
        }
        public string GiaBanLe
        {
            get { return this.giaBanLe; }
            set { this.giaBanLe = value; }
        }
        public Boolean Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }

    }

}
