using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class BaoCaoTraLaiNhaCungcapTheoKy
    {
        private string maHDTraLaiNCC;
        private DateTime ngaytra;
        private string maKho;
        private string maHangHoa;
        private string tenHangHoa;
        private string giaNhap;
        private string soLuong;
        private string phanTramChietKhau;
        private string tienBoiThuong;
        private string thueGTGT;
        private string thanhToanNgay;
        private string thue;


        public string MaHDTraLaiNCC
        {
            get { return maHDTraLaiNCC; }
            set { maHDTraLaiNCC = value; }
        }
        public DateTime Ngaytra
        {
            get { return ngaytra; }
            set { ngaytra = value; }
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
        public string TienBoiThuong
        {
            get { return tienBoiThuong; }
            set { tienBoiThuong = value; }
        }

        public string ThueGTGT
        {
            get { return thueGTGT; }
            set { thueGTGT = value; }
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

        public BaoCaoTraLaiNhaCungcapTheoKy() { }
        public BaoCaoTraLaiNhaCungcapTheoKy
        (
            string maHDTraLaiNCC,
            DateTime ngayTra,
            string maKho,
            string maHangHoa,
            string tenHangHoa,
            string giaNhap,
            string soLuong,
            string phanTramChietKhau,
            string tienBoiThuong,
            string thueGTGT,
            string thanhToanNgay,
            string thue
        )
        {
            this.maHDTraLaiNCC = maHDTraLaiNCC;
            this.ngaytra = ngayTra;
            this.maKho = maKho;
            this.maHangHoa= maHangHoa;
            this.tenHangHoa= tenHangHoa;
            this.giaNhap= giaNhap;
            this.soLuong= soLuong;
            this.phanTramChietKhau = phanTramChietKhau;
            this.tienBoiThuong = tienBoiThuong;
            this.thueGTGT= thueGTGT;
            this.thanhToanNgay = thanhToanNgay;
            this.thue = thue;
         }
    }
}
