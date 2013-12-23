using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    [Serializable]
    public class LoaiHang
    {
        private string hanhDong;
        private int loaiHangID;
        private string maLoaiHang;
        private string tenLoaiHang;
        private string ghiChu;
        private bool deleted;
        public LoaiHang()
        { }
        public LoaiHang(int loaiHangID, string maLoaiHang, string tenLoaiHang, string ghiChu, bool deleted)
        {
            this.loaiHangID = loaiHangID;
            this.maLoaiHang = maLoaiHang;
            this.tenLoaiHang = tenLoaiHang;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        public int LoaiHangID
        {
            get { return this.loaiHangID; }
            set
            {
                this.loaiHangID = value;
            }
        }
        public string MaLoaiHang
        {
            get { return this.maLoaiHang; }
            set
            {
                this.maLoaiHang = value;
            }
        }
        public string TenLoaiHang
        {
            get { return this.tenLoaiHang; }
            set
            {
                this.tenLoaiHang = value;
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
