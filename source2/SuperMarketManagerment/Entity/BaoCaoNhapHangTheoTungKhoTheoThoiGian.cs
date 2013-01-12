using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BaoCaoNhapHangTheoTungKhoTheoThoiGian
    {
        private string maHoaDonNhap;
        private DateTime ngayNhap;
        private string maKho;
        private string maHangHoa;
        private string tenHangHoa;
        private string giaNhap;
        private string soLuong;
        private string phanTramChietKhau;
        private string chietKhau;
        private string thueGTGT;
        private string tongTien;
        private string thanhToanNgay;
        private string thue;

       
        public string MaHoaDonNhap
        {
            get { return maHoaDonNhap; }
            set { maHoaDonNhap = value; }
        }
        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }
        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
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
        public string GiaNhap
        {
            get { return giaNhap; }
            set { giaNhap = value; }
        }
        public string SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        
        public string PhanTramChietKhau
        {
            get { return phanTramChietKhau; }
            set { phanTramChietKhau = value; }
        }
        public string ChietKhau
        {
            get { return chietKhau; }
            set { chietKhau = value; }
        }
        
        public string ThueGTGT
        {
            get { return thueGTGT; }
            set { thueGTGT = value; }
        }
        public string TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        public string ThanhToanNgay
        {
            get { return thanhToanNgay; }
            set { thanhToanNgay = value; }
        }
        public string Thue
        {
            get { return thue; }
            set { thue = value; }
        }

        public BaoCaoNhapHangTheoTungKhoTheoThoiGian() { }
        public BaoCaoNhapHangTheoTungKhoTheoThoiGian
        (
            string maHoaDonNhap,
            DateTime ngayNhap,
            string maKho,
            string maHangHoa,
            string tenHangHoa,
            string giaNhap,
            string soLuong,
            string phanTramChietKhau,
            string chietKhau,
            string thueGTGT,
            string tongTien,
            string thanhToanNgay,
            string thue
        )
        {
            this.maHoaDonNhap = maHoaDonNhap;
            this.ngayNhap = ngayNhap;
            this.maKho = maKho;
            this.maHangHoa= maHangHoa;
            this.tenHangHoa= tenHangHoa;
            this.giaNhap= giaNhap;
            this.soLuong= soLuong;
            this.phanTramChietKhau = phanTramChietKhau;
            this.chietKhau= chietKhau;
            this.thueGTGT= thueGTGT;
            this.tongTien= tongTien;
            this.thanhToanNgay = thanhToanNgay;
            this.thue = thue;
         }
    }
}
