using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class TheVip
    {
        public string TenDangNhap;
        public string MaNhanVien;
        private string hanhDong;
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private string maKhachHang;

        public string MaKhachHang
        {
            get { return maKhachHang; }
            set { maKhachHang = value; }
        }
        private string maThe;

        public string MaThe
        {
            get { return maThe; }
            set { maThe = value; }
        }
        private string giaTriThe;

        public string GiaTriThe
        {
            get { return giaTriThe; }
            set { giaTriThe = value; }
        }
        private string giaTriConLai;

        public string GiaTriConLai
        {
            get { return giaTriConLai; }
            set { giaTriConLai = value; }
        }
        private string ghiChu;

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        private string soDiem;

        public string SoDiem
        {
            get { return this.soDiem; }
            set { this.soDiem = value; }
        }
        private Boolean deleted;

        public Boolean Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
        public TheVip() { }
        public TheVip(string maKhachHang,string maThe, string giaTriThe,string giaTriConLai,string ghiChu,string soDiem,Boolean deleted)
        {
            this.maKhachHang = maKhachHang;
            this.maThe = maThe;
            this.giaTriThe = giaTriThe;
            this.giaTriConLai = giaTriConLai;
            this.ghiChu = ghiChu;
            this.soDiem = soDiem;
            this.deleted = deleted;
        }
        public TheVip(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public TheVip(string hanhDong,string maKhachHang)
        {
            this.hanhDong = hanhDong;
            this.maKhachHang = maKhachHang;
        }
    }
}
