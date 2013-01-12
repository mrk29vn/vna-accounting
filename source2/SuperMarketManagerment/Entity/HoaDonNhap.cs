using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class HoaDonNhap
    {
        #region hungvv======================================================================================================================
        private string hanhdong;
        private int hoaDonNhapID;
        private string maHoaDonNhap;
        private DateTime ngayNhap;
        private string maNhaCungCap;
        private string noHienThoi;
        private string nguoiGiaoHang;
        private string hinhThucThanhToan;
        private string maKho;
        private DateTime hanThanhToan;
        private string maDonDatHang;
        private string maTienTe;
        private string chietKhau;
        private string thanhToanNgay;
        private string thueGTGT;
        private string tongTien;
        private string ghiChu;
        private Boolean deleted;
        private string thanhToanSauKhiLapPhieu;
        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        public int HoaDonNhapID
        {
            get { return this.hoaDonNhapID; }
            set
            {
                this.hoaDonNhapID = value;
            }
        }
        public string MaHoaDonNhap
        {
            get { return this.maHoaDonNhap; }
            set
            {
                this.maHoaDonNhap = value;
            }
        }
        public DateTime NgayNhap
        {
            get { return this.ngayNhap; }
            set { this.ngayNhap = value; }
        }
        public string MaNhaCungCap
        {
            get { return this.maNhaCungCap; }
            set { this.maNhaCungCap = value; }
        }
        public string NoHienThoi
        {
            get { return this.noHienThoi; }
            set { this.noHienThoi = value; }
        }
        public string NguoiGiaoHang
        {
            get { return this.nguoiGiaoHang; }
            set { this.nguoiGiaoHang = value; }
        }
        public string HinhThucThanhToan
        {
            get { return this.hinhThucThanhToan; }
            set { this.hinhThucThanhToan = value; }
        }
        public string MaKho
        {
            get { return this.maKho; }
            set { this.maKho = value; }
        }
        public DateTime HanThanhToan
        {
            get { return this.hanThanhToan; }
            set { this.hanThanhToan = value; }
        }
        public string MaDonDatHang
        {
            get { return this.maDonDatHang; }
            set { this.maDonDatHang = value; }
        }
        public string MaTienTe
        {
            get { return this.maTienTe; }
            set { this.maTienTe = value; }
        }
        public string ChietKhau
        {
            get { return this.chietKhau; }
            set { this.chietKhau = value; }
        }
        public string ThanhToanNgay
        {
            get { return this.thanhToanNgay; }
            set { this.thanhToanNgay = value; }
        }
        public string ThueGTGT
        {
            get { return this.thueGTGT; }
            set { this.thueGTGT = value; }
        }
        public string TongTien
        {
            get { return this.tongTien; }
            set { this.tongTien = value; }
        }
        public string GhiChu
        {
            get { return this.ghiChu; }
            set { this.ghiChu = value; }
        }
        public Boolean Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }
        public string ThanhToanSauKhiLapPhieu
        {
            get { return thanhToanSauKhiLapPhieu; }
            set { thanhToanSauKhiLapPhieu = value; }
        }

        private string manhanvien;
        private string tendangnhap;
        public string Manhanvien
        {
            get { return manhanvien; }
            set { manhanvien = value; }
        }
        public string Tendangnhap
        {
            get { return tendangnhap; }
            set { tendangnhap = value; }
        }
        #endregion hungvv======================================================================================================================

        #region hungvv======================================================================================================================
        public HoaDonNhap() { }

        public HoaDonNhap(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }

        public HoaDonNhap(string hanhdong, string maHoaDonNhap)
        {
            this.hanhdong = hanhdong;
            this.maHoaDonNhap = maHoaDonNhap;
        }

        public HoaDonNhap(string hanhdong, string maHoaDonNhap, string maKho, int i)
        {
            this.hanhdong = hanhdong;
            this.maHoaDonNhap = maHoaDonNhap;
            this.maKho = maKho;
        }
        public HoaDonNhap(string hanhdong, string maHoaDonNhap, string thanhToanSauKhiLapPhieu)
        {
            this.hanhdong = hanhdong;
            this.maHoaDonNhap = maHoaDonNhap;
            this.thanhToanSauKhiLapPhieu = thanhToanSauKhiLapPhieu;
        }
        public HoaDonNhap(string hanhdong, string maHoaDonNhap, DateTime ngayNhap, string maNhaCungCap, string noHienThoi, string nguoiGiaoHang, string hinhThucThanhToan, string maKho, DateTime hanThanhToan, string maDonDatHang, string maTienTe, string chietKhau, string thanhToanNgay, string thueGTGT, string tongTien, string ghiChu, Boolean deleted, string thanhToanSauKhiLapPhieu)
        {
            this.hanhdong = hanhdong;
            this.maHoaDonNhap = maHoaDonNhap;
            this.ngayNhap = ngayNhap;
            this.maNhaCungCap = maNhaCungCap;
            this.noHienThoi = noHienThoi;
            this.nguoiGiaoHang = nguoiGiaoHang;
            this.hinhThucThanhToan = hinhThucThanhToan;
            this.maKho = maKho;
            this.HanThanhToan = hanThanhToan;
            this.maDonDatHang = maDonDatHang;
            this.maTienTe = maTienTe;
            this.chietKhau = chietKhau;
            this.thanhToanNgay = thanhToanNgay;
            this.thueGTGT = thueGTGT;
            this.tongTien = tongTien;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.thanhToanSauKhiLapPhieu = thanhToanSauKhiLapPhieu;
        }
        #endregion hungvv======================================================================================================================

    }
}
