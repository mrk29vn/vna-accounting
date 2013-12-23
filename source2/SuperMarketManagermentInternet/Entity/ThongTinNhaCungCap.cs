using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ThongTinNhaCungCap
    {
        private string hanhdong;

        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        private string manhacungcap;

        public string Manhacungcap
        {
            get { return manhacungcap; }
            set { manhacungcap = value; }
        }
        private string tennhacungcap;

        public string Tennhacungcap
        {
            get { return tennhacungcap; }
            set { tennhacungcap = value; }
        }
        private string diachi;

        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        private string nohienthoi;

        public string Nohienthoi
        {
            get { return nohienthoi; }
            set { nohienthoi = value; }
        }
        public ThongTinNhaCungCap() { }
        public ThongTinNhaCungCap(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }
        public ThongTinNhaCungCap(string hanhdong, string manhacungcap, string tennhacungcap, string diachi)
        {
            this.hanhdong = hanhdong;
            this.manhacungcap = manhacungcap;
            this.tennhacungcap = tennhacungcap;
            this.diachi = diachi;
        }
        public ThongTinNhaCungCap(string hanhdong, string manhacungcap, string tennhacungcap, string diachi,string nohienthoi)
        {
            this.hanhdong = hanhdong;
            this.manhacungcap = manhacungcap;
            this.tennhacungcap = tennhacungcap;
            this.diachi = diachi;
            this.nohienthoi = nohienthoi;
        }
    }
}
