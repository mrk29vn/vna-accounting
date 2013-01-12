using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class NhapHangTheoMatHang
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
        public NhapHangTheoMatHang() { }
    }
}
