using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class DonDatHang
    {
        #region hungvv==============================================================
        private string hanhdong;
        private int donDatHangID;
        private string maDonDatHang;
        private Boolean loaiDonDatHang;
        private DateTime ngayDonHang;
        private string maNhaCungCap;
        private string noHienThoi;
        private string trangThaiDonDatHang;
        private DateTime ngayNhapDuKien;
        private string hinhThucThanhToan;
        private string maKho;
        private string maNhanVien;
        private string maTienTe;
        private string thueGTGT;
        private string phivanchuyen;
        private string phiKhac;
        private string ghiChu;
        private Boolean deleted;
        private string makhachhang;

        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        public int DonDatHangID
        {
            get { return donDatHangID; }
            set { donDatHangID = value; }
        }
        public string MaDonDatHang
        {
            get { return maDonDatHang; }
            set { maDonDatHang = value; }
        }
        public Boolean LoaiDonDatHang
        {
            get { return loaiDonDatHang; }
            set { loaiDonDatHang = value; }
        }
        public DateTime NgayDonHang
        {
            get { return this.ngayDonHang; }
            set { this.ngayDonHang = value; }
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
        public string TrangThaiDonDatHang
        {
            get { return this.trangThaiDonDatHang; }
            set { this.trangThaiDonDatHang = value; }
        }
        public DateTime NgayNhapDuKien
        {
            get { return this.ngayNhapDuKien; }
            set { this.ngayNhapDuKien = value; }
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
        public string MaNhanVien
        {
            get { return this.maNhanVien; }
            set { this.maNhanVien = value; }
        }
        public string MaTienTe
        {
            get { return this.maTienTe; }
            set { this.maTienTe = value; }
        }
        public string ThueGTGT
        {
            get { return this.thueGTGT; }
            set { this.thueGTGT = value; }
        }
        public string Phivanchuyen
        {
            get { return this.phivanchuyen; }
            set { this.phivanchuyen = value; }
        }
        public string PhiKhac
        {
            get { return this.phiKhac; }
            set { this.phiKhac = value; }
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
        public string Makhachhang
        {
            get { return makhachhang; }
            set { makhachhang = value; }
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
        #endregion ==============================================================

        #region hungvv==============================================================
        public DonDatHang() { }

        public DonDatHang(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }

        public DonDatHang(string hanhdong, string madondathang)
        {
            this.hanhdong = hanhdong;
            this.maDonDatHang = madondathang;
        }
        public DonDatHang(string hanhdong, int donDatHangID)
        {
            this.hanhdong = hanhdong;
            this.donDatHangID = donDatHangID;
        }

        public DonDatHang(string hanhdong, string maDonDatHang, Boolean loaiDonDatHang, DateTime ngayDonHang, string maNhaCungCap, string noHienThoi, string trangThaiDonDatHang, DateTime ngayNhapDuKien, string hinhThucThanhToan, string maKho, string maNhanVien, string maTienTe, string thueGTGT, string phivanchuyen, string phiKhac, string ghiChu, Boolean deleted)
        {
            this.hanhdong = hanhdong;
            this.maDonDatHang = maDonDatHang;
            this.loaiDonDatHang = loaiDonDatHang;
            this.ngayDonHang = ngayDonHang;
            this.maNhaCungCap = maNhaCungCap;
            this.noHienThoi = noHienThoi;
            this.trangThaiDonDatHang = trangThaiDonDatHang;
            this.ngayNhapDuKien = ngayNhapDuKien;
            this.hinhThucThanhToan = hinhThucThanhToan;
            this.maKho = maKho;
            this.maNhanVien = maNhanVien;
            this.maTienTe = maTienTe;
            this.thueGTGT = thueGTGT;
            this.phivanchuyen = phivanchuyen;
            this.phiKhac = phiKhac;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        public DonDatHang(string hanhdong, int donDatHangID, string maDonDatHang, Boolean loaiDonDatHang, DateTime ngayDonHang, string maNhaCungCap, string noHienThoi, string trangThaiDonDatHang, DateTime ngayNhapDuKien, string hinhThucThanhToan, string maKho, string maNhanVien, string maTienTe, string thueGTGT, string phivanchuyen, string phiKhac, string ghiChu, Boolean deleted,string makhachhang)
        {
            this.hanhdong = hanhdong;
            this.donDatHangID = donDatHangID;
            this.maDonDatHang = maDonDatHang;
            this.loaiDonDatHang = loaiDonDatHang;
            this.ngayDonHang = ngayDonHang;
            this.maNhaCungCap = maNhaCungCap;
            this.noHienThoi = noHienThoi;
            this.trangThaiDonDatHang = trangThaiDonDatHang;
            this.ngayNhapDuKien = ngayNhapDuKien;
            this.hinhThucThanhToan = hinhThucThanhToan;
            this.maKho = maKho;
            this.maNhanVien = maNhanVien;
            this.maTienTe = maTienTe;
            this.thueGTGT = thueGTGT;
            this.phivanchuyen = phivanchuyen;
            this.phiKhac = phiKhac;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.makhachhang = makhachhang;
        }
        #endregion

    }
}
