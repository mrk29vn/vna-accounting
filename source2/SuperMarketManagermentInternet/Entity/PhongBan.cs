using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class PhongBan
    {
        public string NhanVienID;
        public string TenDangNhap;
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private int phongBanID;
        private string maPhongBan;
        private string tenPhongBan;
        private string ghiChu;
        private bool deleted;
        public PhongBan()
        { }
        public PhongBan(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public PhongBan(int phongBanID, string maPhongBan, string tenPhongBan, string ghiChu, bool deleted)
        {
            this.phongBanID = phongBanID;
            this.maPhongBan = maPhongBan;
            this.tenPhongBan = tenPhongBan;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        public PhongBan(string hanhDong, int phongBanID, string maPhongBan, string tenPhongBan, string ghiChu, bool deleted,string nhanVienID, string tenDangNhap)
        {
            this.HanhDong = hanhDong;
            this.phongBanID = phongBanID;
            this.maPhongBan = maPhongBan;
            this.tenPhongBan = tenPhongBan;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.NhanVienID = nhanVienID;
            this.TenDangNhap = tenDangNhap;
        }

        public int PhongBanID
        {
            get { return this.phongBanID; }
            set
            {
                this.phongBanID = value;
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
            get { return this.tenPhongBan; }
            set
            {
                this.tenPhongBan = value;
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

    }
}
