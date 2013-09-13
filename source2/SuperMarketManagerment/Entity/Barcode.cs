using System;

namespace Entities
{
    [Serializable]
    public class Barcode
    {
        private string tenSieuThi;
        private string maHangHoa;
        private string tenHangHoa;
        private byte[] maVach;
        private double donGia;
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public double DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }

        public byte[] MaVach
        {
            get { return maVach; }
            set { maVach = value; }
        }

        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }

        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }

        public string TenSieuThi
        {
            get { return tenSieuThi; }
            set { tenSieuThi = value; }
        }
    }
}
