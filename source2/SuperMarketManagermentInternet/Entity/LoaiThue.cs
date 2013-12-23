using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class LoaiThue
    {
        private string hanhDong;
        private int loaiThueID;
        private string maLoaiThue;
        private string tenLoaiThue;
        private string ghiChu;
        private bool deleted;
        public LoaiThue()
        { }
        public LoaiThue(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public LoaiThue(string hanhDong, int loaiThueID)
        {
            this.hanhDong = hanhDong;
            this.loaiThueID = loaiThueID;
        }
        public LoaiThue(string hanhDong,int loaiThueID, string maLoaiThue, string tenLoaiThue, string ghiChu, bool deleted)
        {
            this.hanhDong = hanhDong;
            this.loaiThueID = loaiThueID;
            this.maLoaiThue = maLoaiThue;
            this.tenLoaiThue = tenLoaiThue;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        public int LoaiThueID
        {
            get { return this.loaiThueID; }
            set
            {
                this.loaiThueID = value;
            }
        }
        public string MaLoaiThue
        {
            get { return this.maLoaiThue; }
            set
            {
                this.maLoaiThue = value;
            }
        }
        public string TenLoaiThue
        {
            get { return this.tenLoaiThue; }
            set
            {
                this.tenLoaiThue = value;
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
