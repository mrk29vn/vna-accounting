using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BaoCaoNhapHangTheoTungNhomHangTheoThoiGian
    {
        private string maHangHoa;
        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }
        private string tenHangHoa;
        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }
        private string soLuong;
        public string SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private string giaNhap;
        public string GiaNhap
        {
            get { return giaNhap; }
            set { giaNhap = value; }
        }
       
        private string maHoaDonNhap;
        public string MaHoaDonNhap
        {
            get { return maHoaDonNhap; }
            set { maHoaDonNhap = value; }
        }
       
        private DateTime ngayNhap;
        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }
        private DateTime hanThanhToan;
        public DateTime HanThanhToan
        {
            get { return hanThanhToan; }
            set { hanThanhToan = value; }
        }       
        private string thanhToanNgay;
        public string ThanhToanNgay
        {
            get { return thanhToanNgay; }
            set { thanhToanNgay = value; }
        }
        private string phanTramChietKhau;
        public string PhanTramChietKhau
        {
            get { return phanTramChietKhau; }
            set { phanTramChietKhau = value; }
        }
        private string chietKhau;
        public string ChietKhau
        {
            get { return chietKhau; }
            set { chietKhau = value; }
        }
        private string thueGTGT;
        public string ThueGTGT
        {
            get { return thueGTGT; }
            set { thueGTGT = value; }
        }
       
        private string tongTien;
        public string TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        private string maNhomHangHoa;
        public string MaNhomHangHoa
        {
            get { return maNhomHangHoa; }
            set { maNhomHangHoa = value; }
        }
        private string tenNhomHang;
        public string TenNhomHang
        {
            get { return tenNhomHang; }
            set { tenNhomHang = value; }
        }
        public BaoCaoNhapHangTheoTungNhomHangTheoThoiGian() { }
        public BaoCaoNhapHangTheoTungNhomHangTheoThoiGian
        (
            string maHangHoa,
            string tenHangHoa,
            string soLuong,
            string giaNhap,
            string maHoaDonNhap,
            DateTime ngayNhap,
            DateTime hanThanhToan,
            string thanhToanNgay,
            string phanTramChietKhau,
            string chietKhau,
            string thueGTGT,
            string tongTien,
            string maNhomHang,
            string tenNhomHang
        )
        {
            this.maHangHoa= maHangHoa;
            this.tenHangHoa= tenHangHoa;
            this.soLuong= soLuong;
            this.giaNhap = giaNhap;
            this.maHoaDonNhap= maHoaDonNhap;
            this.ngayNhap= ngayNhap;
            this.hanThanhToan = hanThanhToan;
            this.thanhToanNgay = thanhToanNgay;
            this.phanTramChietKhau = phanTramChietKhau;
            this.chietKhau= chietKhau;
            this.thueGTGT= thueGTGT;
            this.tongTien= tongTien;
            this.maNhomHangHoa = maNhomHang;
            this.tenNhomHang = tenNhomHang;
         }
    }
}
