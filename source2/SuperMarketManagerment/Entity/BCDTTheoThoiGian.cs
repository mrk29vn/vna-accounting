using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCDTTheoThoiGian
    {
        private string maHDBanHang;
        private DateTime ngayBan;
        private DateTime ngay;
        private int thang;
        private int nam;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;
        private float thanhToanNgay;
        private double thanhToanKhiLapPhieu;
        private double tongTienThanhToan;

        public double TongTienThanhToan
        {
            get { return tongTienThanhToan; }
            set { tongTienThanhToan = value; }
        }
        public double ThanhToanKhiLapPhieu
        {
            get { return this.thanhToanKhiLapPhieu; }
            set { this.thanhToanKhiLapPhieu = value; }
        }

        public BCDTTheoThoiGian(string maHDBanHang, DateTime ngayBan, float thanhToanNgay)
        {
            this.maHDBanHang = maHDBanHang;
            this.ngayBan = ngayBan;
            this.thanhToanNgay = thanhToanNgay;
        }
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        public DateTime Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }

        public int Thang
        {
            get { return thang; }
            set { thang = value; }
        }

        public int Nam
        {
            get { return nam; }
            set { nam = value; }
        }

        public DateTime NgayBatDau
        {
            get { return ngayBatDau; }
            set { ngayBatDau = value; }
        }

        public DateTime NgayKetThuc
        {
            get { return ngayKetThuc; }
            set { ngayKetThuc = value; }
        }
        public BCDTTheoThoiGian() { }

        public BCDTTheoThoiGian(string hanhDong, int thang, int nam)
        {
            this.hanhDong = hanhDong;
            this.thang = thang;
            this.nam = nam;
        }

        public BCDTTheoThoiGian(string hanhDong, DateTime ngay)
        {
            this.hanhDong = hanhDong;
            this.ngay = ngay;
        }

        public BCDTTheoThoiGian(string hanhDong, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            this.hanhDong = hanhDong;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }
        
        public string MaHDBanHang
        {
            get { return this.maHDBanHang; }
            set
            {
                this.maHDBanHang = value;
            }
        }
        public DateTime NgayBan
        {
            get { return this.ngayBan; }
            set { this.ngayBan = value; }
        }
        public float ThanhToanNgay
        {
            get { return this.thanhToanNgay; }
            set { this.thanhToanNgay = value; }
        }
    }
}
