using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class Thue
    {
        private int thueID;
        private string maThue;
        private string giaTriThue;
        private string tenThue;
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
        private string hanhDong;
        public string HanhDong
        {
            get { return this.hanhDong; }
            set
            {
                this.hanhDong = value;
            }
        }
        public Thue()
        { }
        public Thue(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public Thue(string hanhdong, int thueid)
        {
            this.hanhDong = hanhdong;
            this.thueID = thueid;
        }
        public Thue(string hanhdong, int thueid, string maNhanVien, string tenDangNhap)
        {
            this.hanhDong = hanhdong;
            this.thueID = thueid;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public Thue(string hanhdong, int thueid, string mathue, string giatrithue, string tenthue, string ghichu, Boolean Deleted)
        {
            this.hanhDong = hanhdong;
            this.thueID = thueid;
            this.maThue = mathue;
            this.giaTriThue = giatrithue;
            this.tenThue = tenthue;
            this.ghiChu = ghichu;
            this.deleted = Deleted;
        }
        public Thue(string hanhdong, int thueid, string mathue, string giatrithue, string tenthue, string ghichu, Boolean Deleted, string maNhanVien, string tenDangNhap)
        {
            this.hanhDong = hanhdong;
            this.thueID = thueid;
            this.maThue = mathue;
            this.giaTriThue = giatrithue;
            this.tenThue = tenthue;
            this.ghiChu = ghichu;
            this.deleted = Deleted;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public int ThueID
        {
            get { return this.thueID; }
            set
            {
                this.thueID = value;
            }
        }
        public string MaThue
        {
            get { return this.maThue; }
            set
            {
                this.maThue = value;
            }
        }
        public string GiaTriThue
        {
            get { return this.giaTriThue; }
            set
            {
                this.giaTriThue = value;
            }
        }
        public string TenThue
        {
            get { return this.tenThue; }
            set
            {
                this.tenThue = value;
            }
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
