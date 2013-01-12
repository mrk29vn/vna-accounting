using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class SoLuongTraLai
    {
        private string maHangHoa;
        private int soLuong;
        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public SoLuongTraLai() { }
        public SoLuongTraLai(string maHangHoa,int soLuong) 
        {
            this.maHangHoa = maHangHoa;
            this.soLuong = soLuong;
        }
    }
}
