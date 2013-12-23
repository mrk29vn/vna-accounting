using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
   public class GiaVonBanHang
    {
        private string hanhDong;
        private string maHoaDon;
        private string maHangHoa;
        private double giaVon;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        public double GiaVon
        {
            get { return giaVon; }
            set { giaVon = value; }
        }

        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }
       
        public string MaHoaDon
        {
            get { return maHoaDon; }
            set { maHoaDon = value; }
        }
       

    }
}
