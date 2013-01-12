using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class KiemTraChung
    {
        private string hanhdong;
        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string khoachinh;

        public string Khoachinh
        {
            get { return khoachinh; }
            set { khoachinh = value; }
        }

        private string giatri;

        public string Giatri
        {
            get { return giatri; }
            set { giatri = value; }
        }
        private string giatri2;

        public string Giatri2
        {
            get { return giatri2; }
            set { giatri2 = value; }
        }

        public KiemTraChung() { }

        public KiemTraChung(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }

        public KiemTraChung(string hanhdong, string khoachinh)
        {
            this.hanhdong = hanhdong;
            this.khoachinh = khoachinh;
        }
        public KiemTraChung(string hanhdong, string khoachinh,string name)
        {
            this.hanhdong = hanhdong;
            this.khoachinh = khoachinh;
            this.name = name;
        }
        public KiemTraChung(string hanhdong, string name, string khoachinh, string giatri)
        {
            this.hanhdong = hanhdong;
            this.name = name;
            this.khoachinh = khoachinh;
            this.giatri = giatri;
            this.giatri2 = giatri2;
        }
        public KiemTraChung(string hanhdong, string name, string khoachinh, string giatri,string giatri2)
        {
            this.hanhdong = hanhdong;
            this.name = name;
            this.khoachinh = khoachinh;
            this.giatri = giatri;
            this.giatri2 = giatri2;
        }
    }
}
