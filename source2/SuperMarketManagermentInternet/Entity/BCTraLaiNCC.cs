using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCTraLaiNCC
    {
        string mancc;
        string tenncc;
        string machungtu;
        string ngaychungtu;
        string tenhang;
        string soluong;
        string dongia;
        string thue;
        string chietkhau;
        double thanhtien;
        public BCTraLaiNCC()
        {
        }
        public string MaNCC
        {
            get { return mancc; }
            set { mancc = value; }
        }
        public string TenNCC
        {
            get { return tenncc; }
            set { tenncc = value; }
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
        public string ChietKhau
        {
            get { return chietkhau; }
            set { chietkhau = value; }
        }
        public double ThanhTien
        {
            get { return thanhtien; }
            set { thanhtien = value; }
        }
    }
}
