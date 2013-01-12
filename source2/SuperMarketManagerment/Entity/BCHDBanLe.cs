using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCHDBanLe
    {
        private string maHDBanHang;
        private string tenHangHoa;
        private double soLuong;
        private double giaBanLe;
        private double chietKhau;
        private double tongTienThanhToan;
        private string hanhDong;
        private double thue;

        public BCHDBanLe() { }
        public BCHDBanLe(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public BCHDBanLe(string hanhdong, string mahdbanhang)
        {
            this.hanhDong = hanhdong;
            this.maHDBanHang = mahdbanhang;
        }
        public BCHDBanLe(string mahdbanhang, string tenhanghoa, double soluong, double giabanle, double tongtienthanhtoan)
        {
            this.maHDBanHang = mahdbanhang;
            this.tenHangHoa = tenhanghoa;
            this.soLuong = soluong;
            this.giaBanLe = giabanle;
            this.tongTienThanhToan = tongtienthanhtoan;
        }

        public string MaHDBanHang
        {
            get { return this.maHDBanHang; }
            set { this.maHDBanHang = value; }
        }
        public string TenHangHoa
        {
            get { return this.tenHangHoa; }
            set { this.tenHangHoa = value; }
        }
        public double SoLuong
        {
            get { return this.soLuong; }
            set { this.soLuong = value; }
        }
        public double GiaBanLe
        {
            get { return this.giaBanLe; }
            set { this.giaBanLe = value; }
        }
        public double TongTienThanhToan
        {
            get { return this.tongTienThanhToan; }
            set { this.tongTienThanhToan = value; }
        }
        public string HanhDong
        {
            get { return this.hanhDong; }
            set { this.hanhDong = value; }
        }
        public double Thue
        {
            get { return this.thue; }
            set { this.thue = value; }
        }
        public double ChietKhau
        {
            get { return this.chietKhau; }
            set { this.chietKhau = value; }
        }
    }
}
