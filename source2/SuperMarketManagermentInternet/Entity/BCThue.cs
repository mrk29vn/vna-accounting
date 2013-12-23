using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCThue
    {
        string maHangHoa;
        string tenHangHoa;
        string dVT;
        double tongThue;
        public BCThue()
        {
        }
        public BCThue(string maHangHoa, string tenHangHoa, string dVT, double tongThue)
        {
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.dVT = dVT;
            this.tongThue = tongThue;
        }
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
        public string DVT
        {
            get { return dVT; }
            set { dVT = value; }
        }
        public double TongThue
        {
            get { return tongThue; }
            set { tongThue = value; }
        }
    }
}
