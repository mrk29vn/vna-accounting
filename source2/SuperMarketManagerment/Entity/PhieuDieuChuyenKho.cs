using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class PhieuDieuChuyenKhoNoiBo
    {
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private int phieuDieuChuyenKhoID;
        private string maPhieuDieuChuyenKho;
        private DateTime ngayDieuChuyen;
        private string tuKho;
        private string tenKhoDi;
        private string denKho;
        private string tenKhoDen;
        private string maHoaDonNhap;
        private bool xacNhan;
        private string ghiChu;
        private bool deleted;
        public PhieuDieuChuyenKhoNoiBo()
        { }
        public PhieuDieuChuyenKhoNoiBo(string hanhDong, string tuKho)
        {
            this.hanhDong = hanhDong;
            this.tuKho = tuKho;
        }
        public PhieuDieuChuyenKhoNoiBo(int phieuDieuChuyenKhoID, string maPhieuDieuChuyenKho, DateTime ngayDieuChuyen, string tuKho, string denKho, string maHoaDonNhap, bool xacNhan, string ghiChu, bool deleted)
        {
            this.phieuDieuChuyenKhoID = phieuDieuChuyenKhoID;
            this.maPhieuDieuChuyenKho = maPhieuDieuChuyenKho;
            this.ngayDieuChuyen = ngayDieuChuyen;
            this.tuKho = tuKho;
            this.denKho = denKho;
            this.maHoaDonNhap = maHoaDonNhap;
            this.xacNhan = xacNhan;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public PhieuDieuChuyenKhoNoiBo(string hanhDong, int phieuDieuChuyenKhoID, string maPhieuDieuChuyenKho, DateTime ngayDieuChuyen, string tuKho,string tenKhoDi, string denKho,string tenKhoDen, string maHoaDonNhap, bool xacNhan, string ghiChu, bool deleted)
        {
            this.hanhDong = hanhDong;
            this.phieuDieuChuyenKhoID = phieuDieuChuyenKhoID;
            this.maPhieuDieuChuyenKho = maPhieuDieuChuyenKho;
            this.ngayDieuChuyen = ngayDieuChuyen;
            this.tuKho = tuKho;
            this.tenKhoDi = tenKhoDi;
            this.denKho = denKho;
            this.tenKhoDen = tenKhoDen;
            this.maHoaDonNhap = maHoaDonNhap;
            this.xacNhan = xacNhan;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public PhieuDieuChuyenKhoNoiBo(string hanhDong, int phieuDieuChuyenKhoID)
        {
            this.hanhDong = hanhDong;
            this.phieuDieuChuyenKhoID = phieuDieuChuyenKhoID;
        }

        public int PhieuDieuChuyenKhoID
        {
            get { return this.phieuDieuChuyenKhoID; }
            set
            {
                this.phieuDieuChuyenKhoID = value;
            }
        }
        public string MaPhieuDieuChuyenKho
        {
            get { return this.maPhieuDieuChuyenKho; }
            set
            {
                this.maPhieuDieuChuyenKho = value;
            }
        }
        public DateTime NgayDieuChuyen
        {
            get { return this.ngayDieuChuyen; }
            set { this.ngayDieuChuyen = value; }
        }
        public string TuKho
        {
            get { return this.tuKho; }
            set { this.tuKho = value; }
        }
        public string TenKhoDi
        {
            get { return tenKhoDi; }
            set { tenKhoDi = value; }
        }
        public string DenKho
        {
            get { return this.denKho; }
            set { this.denKho = value; }
        }
        public string TenKhoDen
        {
            get { return tenKhoDen; }
            set { tenKhoDen = value; }
        }
        public string MaHoaDonNhap
        {
            get { return this.maHoaDonNhap; }
            set { this.maHoaDonNhap = value; }
        }
        public bool XacNhan
        {
            get { return this.xacNhan; }
            set { this.xacNhan = value; }
        }
        public string GhiChu
        {
            get { return this.ghiChu; }
            set { this.ghiChu = value; }
        }
        public bool Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }

    }

    [Serializable]
    public class tem1
    {
        string maHangHoa;
        string tenHangHoa;
        string soLuong;
        string giaNhap;
        string giaBanBuon;
        string giaBanLe;

        public tem1()
        {
            this.maHangHoa = "";
            this.tenHangHoa = "";
            this.soLuong = "0";
            this.giaNhap = "0";
            this.giaBanBuon = "0";
            this.giaBanLe = "0";
        }

        public tem1(string maHangHoa, string tenHangHoa, string soLuong, string giaNhap, string giaBanBuon, string giaBanLe)
        {
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.soLuong = soLuong;
            this.giaNhap = giaNhap;
            this.giaBanBuon = giaBanBuon;
            this.giaBanLe = giaBanLe;
        }

        public string MaHangHoa 
        {
            get { return this.maHangHoa; }
            set { this.maHangHoa = value; }
        }

        public string TenHangHoa
        {
            get { return this.tenHangHoa; }
            set { this.tenHangHoa = value; }
        }

        public string SoLuong
        {
            get { return this.soLuong; }
            set { this.soLuong = value; }
        }

        public string GiaNhap
        {
            get { return this.giaNhap; }
            set { this.giaNhap = value; }
        }

        public string GiaBanBuon
        {
            get { return this.giaBanBuon; }
            set { this.giaBanBuon = value; }
        }

        public string GiaBanLe
        {
            get { return this.giaBanLe; }
            set { this.giaBanLe = value; }
        }
    }
}
