using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCNhapHangTheoThoiGianChiTiet
    {
        private string maChungTu;
        private string tenChungTu;
        private DateTime ngayLap;
        private string maHangHoa;
        private string tenHangHoa;
        private int soLuong;
        public string MaChungTu
        {
            get { return maChungTu; }
            set { maChungTu = value; }
        }
        public string TenChungTu
        {
            get { return tenChungTu; }
            set { tenChungTu = value; }
        }
        public DateTime NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
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
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        public BCNhapHangTheoThoiGianChiTiet()
        {
        }
        public BCNhapHangTheoThoiGianChiTiet(string maChungTu, string tenChungTu, DateTime ngayLap, string maHangHoa, string tenHangHoa, int soLuong)
        {
            this.maChungTu = maChungTu;
            this.tenChungTu = tenChungTu;
            this.ngayLap = ngayLap;
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.soLuong = soLuong;
        }
    }
}
