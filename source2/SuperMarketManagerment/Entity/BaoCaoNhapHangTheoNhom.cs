using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class BaoCaoNhapHangTheoNhom
    {
        private string ngayNhap;

        public string NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }
        private string hoaDonNhap;

        public string HoaDonNhap
        {
            get { return hoaDonNhap; }
            set { hoaDonNhap = value; }
        }
        private string tenHangHoa;

        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private Double thanhTien;

        public Double ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }
        public BaoCaoNhapHangTheoNhom() { }
    }
}
