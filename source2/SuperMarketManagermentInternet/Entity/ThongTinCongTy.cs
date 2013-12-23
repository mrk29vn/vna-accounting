using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ThongTinCongTy
    {
        private string hanhDong;
        private int congTyID;
        private string macongty;
        private string tencongty;
        private string diachi;
        private string sodienthoai;
        private string email;
        private string web;
        private string fax;
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
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public int CongTyID
        {
            get { return congTyID; }
            set { congTyID = value; }
        }
        public string MaCongTy
        {
            get { return macongty; }
            set { macongty = value; }
        }

        public string TenCongTy
        {
            get { return tencongty; }
            set { tencongty = value; }
        }

        public string DiaChi
        {
            get { return diachi; }
            set { diachi = value; }
        }

        public string SoDienThoai
        {
            get { return sodienthoai; }
            set { sodienthoai = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Website
        {
            get { return web; }
            set { web = value; }
        }
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public ThongTinCongTy() { }
        public ThongTinCongTy(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public ThongTinCongTy(string macongty, string hanhdong)
        {
            this.hanhDong = hanhdong;
            this.macongty = macongty;
        }
        public ThongTinCongTy(string macongty, string hanhdong, string maNhanVien, string tenDangNhap)
        {
            this.hanhDong = hanhdong;
            this.macongty = macongty;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public ThongTinCongTy(string hanhdong,int congtyid,string macongty, string tencongty, string diachi, string sodienthoai, string email, string web, string fax)
        {
            this.congTyID = congtyid;
            this.hanhDong = hanhdong;
            this.macongty = macongty;
            this.tencongty = tencongty;
            this.diachi = diachi;
            this.sodienthoai = sodienthoai;
            this.email = email;
            this.web = web;
            this.fax = fax;
        }
        public ThongTinCongTy(string hanhdong, int congtyid, string macongty, string tencongty, string diachi, string sodienthoai, string email, string web, string fax, string maNhanVien, string tenDangNhap)
        {
            this.congTyID = congtyid;
            this.hanhDong = hanhdong;
            this.macongty = macongty;
            this.tencongty = tencongty;
            this.diachi = diachi;
            this.sodienthoai = sodienthoai;
            this.email = email;
            this.web = web;
            this.fax = fax;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public ThongTinCongTy(int congtyid, string macongty, string tencongty, string diachi, string sodienthoai, string email, string web, string fax)
        {
            this.congTyID = congtyid;
            this.macongty = macongty;
            this.tencongty = tencongty;
            this.diachi = diachi;
            this.sodienthoai = sodienthoai;
            this.email = email;
            this.web = web;
            this.fax = fax;
        }  
    }
}
