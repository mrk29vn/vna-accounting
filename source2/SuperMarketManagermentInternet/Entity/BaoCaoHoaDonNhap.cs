using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class BaoCaoHoaDonNhap
    {
        private string maHangHoa;
        private string tenHangHoa;
        private Double giaNhap;
        private int soLuong;
        private int phanTram;
        private Double chietKhau;
        private Double thue;
        private Double thanhTien;

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
        public Double GiaNhap
        {
            get { return giaNhap; }
            set { giaNhap = value; }
        }
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        public int PhanTram
        {
            get { return phanTram; }
            set { phanTram = value; }
        }
        public Double ChietKhau
        {
            get { return chietKhau; }
            set { chietKhau = value; }
        }
        public Double Thue
        {
            get { return thue; }
            set { thue = value; }
        }
        public Double ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }

        public BaoCaoHoaDonNhap() { }
        public BaoCaoHoaDonNhap(string maHangHoa,string tenHangHoa,Double giaNhap, int soLuong,int phanTram,Double chietKhau, Double thue,Double thanhTien) 
        {
            this.maHangHoa=maHangHoa;
            this. tenHangHoa=tenHangHoa;
            this. giaNhap=giaNhap; 
            this. soLuong=soLuong;
            this. phanTram=phanTram;
            this. chietKhau=chietKhau; 
            this. thue=thue;
            this.thanhTien = thanhTien;
        }
    }
}
