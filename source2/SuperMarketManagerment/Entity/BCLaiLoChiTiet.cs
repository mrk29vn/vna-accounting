using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCLaiLoChiTiet
    {
        private string hanhDong;
        private string ngay;
        private string doanhSo;
        private string giaVon;
        private string laiGop;

        public BCLaiLoChiTiet()
        {
            this.hanhDong = "";
            this.ngay = new DateTime().ToShortDateString();
            this.doanhSo = "0";
            this.giaVon = "0";
            this.laiGop = "0";
        }

        public BCLaiLoChiTiet(string hanhDong, string ngay, string doanhSo, string giaVon, string laiGop)
        {
            this.hanhDong = hanhDong;
            this.ngay = ngay;
            this.doanhSo = doanhSo;
            this.giaVon = giaVon;
            this.laiGop = laiGop;
        }
        public string HanhDong
        {
            get { return this.hanhDong; }
            set { this.hanhDong = value; }
        }
        public string Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }
        public string DoanhSo
        {
            get { return this.doanhSo; }
            set { this.doanhSo = value; }
        }

        public string GiaVon
        {
            get { return giaVon; }
            set { giaVon = value; }
        }

        public string LaiGop
        {
            get { return laiGop; }
            set { laiGop = value; }
        }
    }
}
