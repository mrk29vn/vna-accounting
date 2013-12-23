using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
      [Serializable]
    public class CTBCNhapHangTheoKho
    {
        string maKho;
        string tenKho;
        string maHangHoa;
        string tenHangHoa;
        int tongSoLuongNhap;
        public CTBCNhapHangTheoKho()
        {
            
        }
        public CTBCNhapHangTheoKho(string maKho, string tenKho, string maHangHoa, string tenHangHoa, int tongSoLuongNhap)
        {
            this.maKho = maKho;
            this.tenKho = tenKho;
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.tongSoLuongNhap = tongSoLuongNhap;
        }
        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }

        public string TenKho
        {
            get { return tenKho; }
            set { tenKho = value; }
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
        public int TongSoLuongNhap
        {
            get { return tongSoLuongNhap; }
            set { tongSoLuongNhap = value; }
        }
    }
}
