using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class KhachHangTraLai
    {
        #region hungvv======================================================================================================================
        private string hanhdong;
        private int khachHangTraLaiID;
        private string maKhachHangTraLai;
        private DateTime ngayNhap;
        private string maKhachHang;
        private string noHienThoi;
        private string nguoiTra;
        private string hinhThucThanhToan;
        private DateTime hanThanhToan;
        private string maHoaDonMuaHang;
        private string maKho;
        private string maTienTe;
        private string tienBoiThuong;
        private string thanhToanNgay;
        private string thueGTGT;
        private string ghiChu;
        private Boolean deleted;


        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        public int KhachHangTraLaiID
        {
            get { return this.khachHangTraLaiID; }
            set
            {
                this.khachHangTraLaiID = value;
            }
        }
        public string MaKhachHangTraLai
        {
            get { return this.maKhachHangTraLai; }
            set
            { this.maKhachHangTraLai = value; }
        }
        public DateTime NgayNhap
        {
            get { return this.ngayNhap; }
            set { this.ngayNhap = value; }
        }
        public string MaKhachHang
        {
            get { return this.maKhachHang; }
            set { this.maKhachHang = value; }
        }
        public string NoHienThoi
        {
            get { return this.noHienThoi; }
            set { this.noHienThoi = value; }
        }
        public string NguoiTra
        {
            get { return this.nguoiTra; }
            set { this.nguoiTra = value; }
        }
        public string HinhThucThanhToan
        {
            get { return this.hinhThucThanhToan; }
            set { this.hinhThucThanhToan = value; }
        }
        public DateTime HanThanhToan
        {
            get { return this.hanThanhToan; }
            set { this.hanThanhToan = value; }
        }
        public string MaHoaDonMuaHang
        {
            get { return this.maHoaDonMuaHang; }
            set { this.maHoaDonMuaHang = value; }
        }
        public string MaKho
        {
            get { return this.maKho; }
            set { this.maKho = value; }
        }
        public string MaTienTe
        {
            get { return this.maTienTe; }
            set { this.maTienTe = value; }
        }
        public string TienBoiThuong
        {
            get { return this.tienBoiThuong; }
            set { this.tienBoiThuong = value; }
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
        string tenKhachHang;
        public string TenKhachHang
        {
            get { return tenKhachHang; }
            set { tenKhachHang = value; }
        }
        #endregion hungvv======================================================================================================================

        #region hungvv======================================================================================================================
        public KhachHangTraLai() { }

        public KhachHangTraLai(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }

        public KhachHangTraLai(string hanhdong, string makhachhangtralai)
        {
            this.hanhdong = hanhdong;
            this.maKhachHangTraLai = makhachhangtralai;
        }
        public KhachHangTraLai(string hanhdong, string maKhachHangTraLai, DateTime ngayNhap, string maKhachHang, string noHienThoi, string nguoiTra, string hinhThucThanhToan, DateTime hanThanhToan, string maHoaDonMuaHang, string maKho, string maTienTe, string tienBoiThuong, string thanhToanNgay, string thueGTGT, string ghiChu, Boolean deleted)
        {
            this.hanhdong = hanhdong;
            this.maKhachHangTraLai = maKhachHangTraLai;
            this.ngayNhap = ngayNhap;
            this.maKhachHang = maKhachHang;
            this.noHienThoi = noHienThoi;
            this.nguoiTra = nguoiTra;
            this.hinhThucThanhToan = hinhThucThanhToan;
            this.hanThanhToan = hanThanhToan;
            this.maHoaDonMuaHang = maHoaDonMuaHang;
            this.maKho = maKho;
            this.maTienTe = maTienTe;
            this.tienBoiThuong = tienBoiThuong;
            this.thanhToanNgay = thanhToanNgay;
            this.thueGTGT = thueGTGT;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

       
        public KhachHangTraLai(string hanhdong, int ID,string maKhachHangTraLai, DateTime ngayNhap, string maKhachHang, string noHienThoi, string nguoiTra, string hinhThucThanhToan, DateTime hanThanhToan, string maHoaDonMuaHang, string maKho, string maTienTe, string tienBoiThuong, string thanhToanNgay, string thueGTGT, string ghiChu, Boolean deleted)
        {
            this.hanhdong = hanhdong;
            this.khachHangTraLaiID = ID;
            this.maKhachHangTraLai = maKhachHangTraLai;
            this.ngayNhap = ngayNhap;
            this.maKhachHang = maKhachHang;
            this.noHienThoi = noHienThoi;
            this.nguoiTra = nguoiTra;
            this.hinhThucThanhToan = hinhThucThanhToan;
            this.hanThanhToan = hanThanhToan;
            this.maHoaDonMuaHang = maHoaDonMuaHang;
            this.maKho = maKho;
            this.maTienTe = maTienTe;
            this.tienBoiThuong = tienBoiThuong;
            this.thanhToanNgay = thanhToanNgay;
            this.thueGTGT = thueGTGT;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        #endregion hungvv======================================================================================================================
   
    }
}
