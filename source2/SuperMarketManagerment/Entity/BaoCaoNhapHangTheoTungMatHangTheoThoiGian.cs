using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class BaoCaoNhapHangTheoTungMatHangTheoThoiGian
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
        private string giaNhap;
        public string GiaNhap
        {
            get { return giaNhap; }
            set { giaNhap = value; }
        }
        private string soLuong;
        public string SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private string giaBanBuon;

        public string GiaBanBuon
        {
            get { return giaBanBuon; }
            set { giaBanBuon = value; }
        }
        private string giaBanLe;

        public string GiaBanLe
        {
            get { return giaBanLe; }
            set { giaBanLe = value; }
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
       
        private string chietKhau;

        public string ChietKhau
        {
            get { return chietKhau; }
            set { chietKhau = value; }
        }
        private string thanhToanNgay;

        public string ThanhToanNgay
        {
            get { return thanhToanNgay; }
            set { thanhToanNgay = value; }
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
        private string phanTramChietKhau;

        public string PhanTramChietKhau
        {
            get { return phanTramChietKhau; }
            set { phanTramChietKhau = value; }
        }

        public BaoCaoNhapHangTheoTungMatHangTheoThoiGian() { }
        public BaoCaoNhapHangTheoTungMatHangTheoThoiGian
        (
            string maHangHoa,
            string tenHangHoa,
            string giaNhap,
            string soLuong,
            string giaBanBuon,
            string giaBanLe,
            string maHoaDonNhap,
            DateTime ngayNhap,
            string thanhToanNgay,
            string chietKhau,
            string thueGTGT,
            string tongTien,
            string phanTramChietKhau
        )
        {
            this.maHangHoa= maHangHoa;
            this.tenHangHoa= tenHangHoa;
            this.giaNhap= giaNhap;
            this.soLuong= soLuong;
            this.giaBanBuon= giaBanBuon;
            this.giaBanLe= giaBanLe;
            this.maHoaDonNhap= maHoaDonNhap;
            this.ngayNhap= ngayNhap;
            this.thanhToanNgay = thanhToanNgay;
            this.chietKhau= chietKhau;
            this.thueGTGT= thueGTGT;
            this.tongTien= tongTien;
            this.phanTramChietKhau = phanTramChietKhau;
         }
    }
}
