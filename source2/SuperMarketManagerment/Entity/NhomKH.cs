using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class NhomKH
    {
        private string hanhdong;
        private int nhomKHID;
        private string maNhomKH;
        private string tenNhomKH;
        private Boolean loaiKH;
        private string ghiChu;
        private Boolean deleted;
        public NhomKH()
        { }
        public NhomKH(string Hanhdong)
        {
            this.hanhdong = Hanhdong;
        }
        public NhomKH(string hanhdong,int nhomKHID)
        {
            this.hanhdong = hanhdong;
            this.nhomKHID = nhomKHID;
        }
        public NhomKH( int nhomKHID, string maNhomKH, string tenNhomKH, Boolean loaiKH, string ghiChu, Boolean deleted)
        {
            this.nhomKHID = nhomKHID;
            this.maNhomKH = maNhomKH;
            this.tenNhomKH = tenNhomKH;
            this.loaiKH = loaiKH;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        public NhomKH(string hanhdong,int nhomKHID, string maNhomKH, string tenNhomKH, Boolean loaiKH, string ghiChu, Boolean deleted)
        {
            this.hanhdong = hanhdong;
            this.nhomKHID = nhomKHID;
            this.maNhomKH = maNhomKH;
            this.tenNhomKH = tenNhomKH;
            this.loaiKH = loaiKH;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        public int NhomKHID
        {
            get { return this.nhomKHID; }
            set
            {
                this.nhomKHID = value;
            }
        }
        public string MaNhomKH
        {
            get { return this.maNhomKH; }
            set
            {
                this.maNhomKH = value;
            }
        }
        public string TenNhomKH
        {
            get { return this.tenNhomKH; }
            set
            {
                this.tenNhomKH = value;
            }
        }
        public Boolean LoaiKH
        {
            get { return this.loaiKH; }
            set { this.loaiKH = value; }
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
