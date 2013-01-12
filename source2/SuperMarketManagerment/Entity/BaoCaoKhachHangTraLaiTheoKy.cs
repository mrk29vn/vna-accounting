using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class BaoCaoKhachHangTraLaiTheoKy
    {
        private string maKhachHangTraLai;

        public string MaKhachHangTraLai
        {
            get { return maKhachHangTraLai; }
            set { maKhachHangTraLai = value; }
        }
        private DateTime ngayNhap;

        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }
        private string maKhachHang;

        public string MaKhachHang
        {
            get { return maKhachHang; }
            set { maKhachHang = value; }
        }
        private string maHoaDonMuaHang;

        public string MaHoaDonMuaHang
        {
            get { return maHoaDonMuaHang; }
            set { maHoaDonMuaHang = value; }
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
        private string soLuong;

        public string SoLuong
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
        private string tienBoiThuong;

        public string TienBoiThuong
        {
            get { return tienBoiThuong; }
            set { tienBoiThuong = value; }
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
        private string thue;

        public string Thue
        {
            get { return thue; }
            set { thue = value; }
        }

        public BaoCaoKhachHangTraLaiTheoKy(){}
        public BaoCaoKhachHangTraLaiTheoKy
        (
                 string maKhachHangTraLai,
                 DateTime ngayNhap,
                 string maKhachHang,
                 string maHoaDonMuaHang,
                 string maKho,
                 string maHangHoa,
                 string tenHangHoa,
                 string giaBanBuon,
                 string giaBanLe,
                 string soLuong,
                 string phanTramChietKhau,
                 string tienBoiThuong,
                 string thueGTGT,
                 string thanhToanNgay,
                 string thue
         ) 
         { 
                this.maKhachHangTraLai=maKhachHangTraLai;
                this.ngayNhap = ngayNhap;
                this.maKhachHang = maKhachHang;
                this.maHoaDonMuaHang = maHoaDonMuaHang;
                this.maKho = maKho;
                this.maHangHoa= maHangHoa;
                this.tenHangHoa = tenHangHoa;
                this.giaBanBuon = giaBanBuon;
                this.giaBanLe = giaBanLe;
                this.soLuong = soLuong;
                this.phanTramChietKhau = phanTramChietKhau;
                this.tienBoiThuong = tienBoiThuong;
                this.thueGTGT = thueGTGT;
                this.thanhToanNgay = thanhToanNgay;
                this.thue = thue;
         }
    }
}
