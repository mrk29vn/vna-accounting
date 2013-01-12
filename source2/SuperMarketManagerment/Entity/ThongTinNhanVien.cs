using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ThongTinNhanVien
    {
        private string hanhdong;

        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        private string manhanvien;

        public string Manhanvien
        {
            get { return manhanvien; }
            set { manhanvien = value; }
        }
        private string tennhanvien;

        public string Tennhanvien
        {
            get { return tennhanvien; }
            set { tennhanvien = value; }
        }
        public ThongTinNhanVien() { }
        public ThongTinNhanVien(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }
        public ThongTinNhanVien(string hanhdong, string manhanvien, string tennhanvien)
        {
            this.hanhdong = hanhdong;
            this.manhanvien = manhanvien;
            this.tennhanvien = tennhanvien;
        }
    }
}
