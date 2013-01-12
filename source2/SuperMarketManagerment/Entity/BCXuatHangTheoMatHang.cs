using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    
    public class BCXuatHangTheoMatHang
    {
        string maHangHoa;
        string tenHangHoa;
        int tongSoLuongXuat;

        public BCXuatHangTheoMatHang()
        {

        }
        public BCXuatHangTheoMatHang(string maHangHoa, string tenHangHoa, int tongSoLuongXuat)
        {
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.tongSoLuongXuat = tongSoLuongXuat;
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

        public int TongSoLuongXuat
        {
            get { return tongSoLuongXuat; }
            set { tongSoLuongXuat = value; }
        }
    }
}
