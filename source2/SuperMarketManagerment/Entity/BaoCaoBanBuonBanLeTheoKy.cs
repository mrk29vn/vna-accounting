using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BaoCaoBanBuonBanLeTheoKy
    {
        private string maHDBanHang;

        public string MaHDBanHang
        {
            get { return maHDBanHang; }
            set { maHDBanHang = value; }
        }
        private DateTime ngayBan;

        public DateTime NgayBan
        {
            get { return ngayBan; }
            set { ngayBan = value; }
        }
        private string maKho;

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
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
        private string giaBan;

        public string GiaBan
        {
            get { return giaBan; }
            set { giaBan = value; }
        }
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
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
        private string thanhToanNgay;

        public string ThanhToanNgay
        {
            get { return thanhToanNgay; }
            set { thanhToanNgay = value; }
        }
        private string tongTienThanhToan;

        public string TongTienThanhToan
        {
            get { return tongTienThanhToan; }
            set { tongTienThanhToan = value; }
        }
        private string giaTriThue;

        public string GiaTriThue
        {
            get { return giaTriThue; }
            set { giaTriThue = value; }
        }

        public BaoCaoBanBuonBanLeTheoKy() { }
        public BaoCaoBanBuonBanLeTheoKy
        (
            string maHDBanHang,
            DateTime ngayBan,
            string maKho,
            string maHangHoa,
            string tenHangHoa,
            string giaBan,
            int soLuong,
            string phanTramChietKhau,
            string chietKhau,
            string thueGTGT,
            string thanhToanNgay,
            string tongTienThanhToan,
            string giaTriThue
        ) 
        {
            this.maHDBanHang=  maHDBanHang; 
            this.ngayBan = ngayBan;
            this.maKho = maKho;
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.giaBan = giaBan;
            this.soLuong = soLuong;
            this.phanTramChietKhau = phanTramChietKhau;
            this.chietKhau = chietKhau;
            this.thueGTGT = thueGTGT;
            this.thanhToanNgay = thanhToanNgay;
            this.tongTienThanhToan = tongTienThanhToan;
            this.giaTriThue = giaTriThue;
        }
    }
}
