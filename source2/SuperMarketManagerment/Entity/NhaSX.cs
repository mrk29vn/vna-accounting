using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class NhaSX
    {
        private string hanhdong;
        private int nhaSXID;
        private string maNhaSX;
        private string tenNhaSX;
        private string tenLH;
        private string diaChi;
        private string dienThoai;
        private string fax;
        private string email;
        private string webSite;
        private string ghiChu;
        private Boolean deleted;
        public NhaSX()
        { }
        public NhaSX(string Hanhdong)
        {
            this.hanhdong = Hanhdong;
        }
        public NhaSX(string hanhdong, int nhaSXID)
        {
            this.hanhdong = hanhdong;
            this.nhaSXID = nhaSXID;
        }
        public NhaSX( int nhaSXID,string maNhaSX, string tenNhaSX, string tenLH, string diaChi, string dienThoai, string fax, string email, string webSite, string ghiChu, Boolean deleted)
        {
            this.nhaSXID = nhaSXID;
            this.maNhaSX = maNhaSX;
            this.tenNhaSX = tenNhaSX;
            this.tenLH = tenLH;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.fax = fax;
            this.email = email;
            this.webSite = webSite;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public NhaSX(string hanhdong,int nhaSXID,string maNhaSX, string tenNhaSX, string tenLH, string diaChi, string dienThoai, string fax, string email, string webSite, string ghiChu, Boolean deleted)
        {
            this.hanhdong = hanhdong;
            this.nhaSXID = nhaSXID;
            this.maNhaSX = maNhaSX;
            this.tenNhaSX = tenNhaSX;
            this.tenLH = tenLH;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.fax = fax;
            this.email = email;
            this.webSite = webSite;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

            public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        public int NhaSXID
        {
            get { return this.nhaSXID; }
            set
            {
                this.nhaSXID = value;
            }
        }
        public string MaNhaSX
        {
            get { return this.maNhaSX; }
            set
            {
                this.maNhaSX = value;
            }
        }
        public string TenNhaSX
        {
            get { return this.tenNhaSX; }
            set
            {
                this.tenNhaSX = value;
            }
        }
        public string TenLH
        {
            get { return this.tenLH; }
            set { this.tenLH = value; }
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
        public string WebSite
        {
            get { return this.webSite; }
            set { this.webSite = value; }
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
