using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class QuayThuNgan
    {
        private int quayThuNganID;
        private string tenQuayThuNgan;
        private string diaDiem;
        private string ghiChu;
        private Boolean deleted;
        private string hanhDong;

        public QuayThuNgan()
        { }
        public QuayThuNgan(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public QuayThuNgan(string hanhDong, int quayThuNganID, string tenQuayThuNgan, string diaDiem, string ghiChu, Boolean deleted)
        {
            this.hanhDong = hanhDong;
            this.quayThuNganID = quayThuNganID;
            this.tenQuayThuNgan = tenQuayThuNgan;
            this.diaDiem = diaDiem;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        public int QuayThuNganID
        {
            get { return this.quayThuNganID; }
            set
            {
                this.quayThuNganID = value;
            }
        }
        public string TenQuayThuNgan
        {
            get { return this.tenQuayThuNgan; }
            set { this.tenQuayThuNgan = value; }
        }
        public string DiaDiem
        {
            get { return this.diaDiem; }
            set { this.diaDiem = value; }
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
        public string HanhDong
        {
            get { return this.hanhDong; }
            set { this.hanhDong = value; }
        }

    }
}
