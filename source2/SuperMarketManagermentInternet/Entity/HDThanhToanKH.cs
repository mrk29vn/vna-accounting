using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class HDThanhToanKH
    {
        private string maHDBanHang;
        private string tongTienThanhToan;
        private string soNo;
        private string thanhToan;
        private string thanhToanKhiLapPhieu;
        public string MaHDBanHang
        {
            get { return this.maHDBanHang; }
            set
            {
                this.maHDBanHang = value;
            }
        }
        public string TongTienThanhToan
        {
            get { return this.tongTienThanhToan; }
            set
            {
                this.tongTienThanhToan = value;
            }
        }
        public string SoNo
        {
            get { return this.soNo; }
            set
            {
                this.soNo = value;
            }
        }
        public string ThanhToan
        {
            get { return this.thanhToan; }
            set
            {
                this.thanhToan = value;
            }
        }
        public string ThanhToanKhiLapPhieu
        {
            get { return this.thanhToanKhiLapPhieu; }
            set
            {
                this.thanhToanKhiLapPhieu = value;
            }
        }
        public HDThanhToanKH()
        {
        }
        public HDThanhToanKH(string maHDBanHang, string tongTienThanhToan, string soNo, string thanhToan,string thanhToanKhiLapPhieu)
        {
            this.maHDBanHang = maHDBanHang;
            this.tongTienThanhToan = tongTienThanhToan;
            this.soNo = soNo;
            this.thanhToan = thanhToan;
            this.thanhToanKhiLapPhieu = thanhToanKhiLapPhieu;
        }
        public HDThanhToanKH(string maHDBanHang, string tongTienThanhToan, string soNo, string thanhToan)
        {
            this.maHDBanHang = maHDBanHang;
            this.tongTienThanhToan = tongTienThanhToan;
            this.soNo = soNo;
            this.thanhToan = thanhToan;
        }
    }

    [Serializable]
    public class BCPhieuTTCuaKH
    {
        string maDonHang;
        public string MaDonHang
        {
            get { return maDonHang; }
            set { maDonHang = value; }
        }
        double tongTienHoaDon;
        public double TongTienHoaDon
        {
            get { return tongTienHoaDon; }
            set { tongTienHoaDon = value; }
        }
        double soTienNo;
        public double SoTienNo
        {
            get { return soTienNo; }
            set { soTienNo = value; }
        }
        double thanhToan;
        public double ThanhToan
        {
            get { return thanhToan; }
            set { thanhToan = value; }
        }

        public BCPhieuTTCuaKH()
        {
            this.maDonHang = "";
            this.tongTienHoaDon = 0;
            this.soTienNo = 0;
            this.thanhToan = 0;
        }

        public BCPhieuTTCuaKH(string maDonHang, double tongTienHoaDon, double soTienNo, double thanhToan)
        {
            this.maDonHang = maDonHang;
            this.tongTienHoaDon = tongTienHoaDon;
            this.soTienNo = soTienNo;
            this.thanhToan = thanhToan;
        }
    }
}
