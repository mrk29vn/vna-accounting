using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ChiTietKhoHang
    {
        private string maKho;
        private string maHangHoa;
        private string tenHangHoa;
        private int soLuong;
        private DateTime ngayNhap;
        private DateTime hanSuDung;
        private string ghiChu;

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
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

        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }

        public DateTime HanSuDung
        {
            get { return hanSuDung; }
            set { hanSuDung = value; }
        }

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
    }
}
