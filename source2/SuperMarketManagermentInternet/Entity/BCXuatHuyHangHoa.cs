using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCXuatHuyHangHoa
    {
        string machungtu;
        string ngaychungtu;
        string mahanghoa;
        string tenhanghoa;
        double soluong;
        public BCXuatHuyHangHoa()
        {
        }
        public string MaChungTu
        {
            get { return machungtu; }
            set { machungtu = value; }
        }
        public string NgayChungTu
        {
            get { return ngaychungtu; }
            set { ngaychungtu = value; }
        }
        public string MaHangHoa
        {
            get { return mahanghoa; }
            set { mahanghoa = value; }
        }
        public string TenHangHoa
        {
            get { return tenhanghoa; }
            set { tenhanghoa = value; }
        }
        public double SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }
    }
}
