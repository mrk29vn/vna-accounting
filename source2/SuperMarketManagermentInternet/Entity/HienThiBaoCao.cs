using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class HienThiBaoCao
    {
        private string stt;
        public string STT
        {
            get { return stt; }
            set { stt = value; }
        }
        private string ma;

        public string Ma
        {
            get { return ma; }
            set { ma = value; }
        }
        private string ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        private string soluong;

        public string Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        public HienThiBaoCao() { }
        public HienThiBaoCao(string stt,string ma,string ten,string sl)
        {
            this.stt = stt;
            this.ma = ma;
            this.ten = ten;
            this.soluong = sl;
        }
    }
}
