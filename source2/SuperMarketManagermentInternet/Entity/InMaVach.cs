using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Entities
{
     [Serializable]
    public class InMaVach
    {
        private string maHangHoa;
        private string tenHangHoa;
        private Byte[] anh;
        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }
        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }
        public Byte[] Anh
        {
            get { return anh; }
            set { anh = value; }
        }

        public InMaVach() { }
        public InMaVach(string ten, string ma, Byte[] anh) 
        {
            this.tenHangHoa = ten;
            this.maHangHoa = ma;
            this.anh = anh;
        }
    }
}
