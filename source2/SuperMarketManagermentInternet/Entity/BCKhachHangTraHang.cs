using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCKhachHangTraHang
    {
        string makhachhang;
        string tenkhachhang;
        string machungtu;
        string ngaychungtu;
        string tenhang;
        string soluong;
        string dongia;
        string thue;
        double thanhtien;
        public BCKhachHangTraHang()
        {
        }

        public string MaKhachHang
        {
            get { return makhachhang; }
            set { makhachhang = value; }
        }
        public string TenKhachHang
        {
            get { return tenkhachhang; }
            set { tenkhachhang = value; }
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
        public string TenHang
        {
            get { return tenhang; }
            set { tenhang = value; }
        }
        public string SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        public string DonGia
        {
            get { return dongia; }
            set { dongia = value; }
        }
        public string Thue
        {
            get { return thue; }
            set { thue = value; }
        }
        public double ThanhTien
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }
        
    }
}
