using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class NhomHang
    {
        private string hanhDong;
        private int nhomHangID;
        private string maNhomHang = "";
        private string maLoaiHang = "";
        private string tenLoaiHang = "";
        private string tenNhomHang = "";
        private string ghiChu = "";
        private bool deleted = false;
        
        public NhomHang()
        { }
        public NhomHang(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public NhomHang(string hanhDong, int nhomHangID, string maNhomHang, string maLoaiHang, string tenNhomHang, string ghiChu, bool deleted
            , string maNhanVien, string tenDangNhap)
        {
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
            this.hanhDong = hanhDong;
            this.nhomHangID = nhomHangID;
            this.maNhomHang = maNhomHang;
            this.maLoaiHang = maLoaiHang;
            this.tenNhomHang = tenNhomHang;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        public NhomHang(string hanhDong, int nhomHangID, string maNhomHang, string maLoaiHang,string tenLoaiHang, 
            string tenNhomHang, string ghiChu, bool deleted)
        {
            
            this.hanhDong = hanhDong;
            this.nhomHangID = nhomHangID;
            this.maNhomHang = maNhomHang;
            this.maLoaiHang = maLoaiHang;
            this.tenLoaiHang = tenLoaiHang;
            this.tenNhomHang = tenNhomHang;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public NhomHang(string hanhDong, int ID, string maNhanVien, string tenDangNhap)
        {
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
            this.hanhDong = hanhDong;
            this.nhomHangID = ID;
        }

        public int NhomHangID
        {
            get { return this.nhomHangID; }
            set
            {
                this.nhomHangID = value;
            }
        }
        public string MaNhomHang
        {
            get { return this.maNhomHang; }
            set
            {
                this.maNhomHang = value;
            }
        }
        public string MaLoaiHang
        {
            get { return this.maLoaiHang; }
            set { this.maLoaiHang = value; }
        }
        public string TenLoaiHang
        {
            get { return this.tenLoaiHang; }
            set { this.tenLoaiHang = value; }
        }
        public string TenNhomHang
        {
            get { return this.tenNhomHang; }
            set
            {
                this.tenNhomHang = value;
            }
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
    }
}
