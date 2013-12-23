using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class PhieuThu
    {
        private int phieuThuID;
        private string maPhieuThu;
        private DateTime ngayLap;
        private string loaiPhieu;
        private string maKho;
        private string maNhomHang;
        private string khoanMuc;
        private string doiTuong;
        private string nguoiNopTien;
        private string nguoiNhanTien;
        private string noTaiKhoan;
        private string coTaiKhoan;
        private string tongTienThanhToan;
        private string maTienTe;
        private Boolean trangThai;
        private string ghiChu;
        private Boolean deleted;

        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public PhieuThu() { }
        public PhieuThu(string Hanhdong)
        {
            this.hanhDong = Hanhdong;
        }

        public PhieuThu(string Hanhdong, int phieuthuID)
        {
            this.hanhDong = Hanhdong;
            this.phieuThuID = phieuthuID;
        }
        public PhieuThu(string hanhdong, int phieuThuID, string maPhieuThu, DateTime ngayLap,
            string loaiPhieu, string maKho, string maNhomHang, string khoanMuc, string doiTuong,
            string nguoiNopTien, string nguoiNhanTien
            , string noTaiKhoan, string coTaiKhoan, string tongTienThanhToan, string maTienTe,
            Boolean trangThai, string ghiChu, Boolean deleted,string maNhanVien,string tenDangNhap)
        {
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
            this.hanhDong = hanhdong;
            this.phieuThuID = phieuThuID;
            this.maPhieuThu = maPhieuThu;
            this.ngayLap = ngayLap;
            this.loaiPhieu = loaiPhieu;
            this.maKho = maKho;
            this.maNhomHang = maNhomHang;
            this.khoanMuc = khoanMuc;
            this.doiTuong = doiTuong;
            this.nguoiNopTien = nguoiNopTien;
            this.nguoiNhanTien = nguoiNhanTien;
            this.noTaiKhoan = noTaiKhoan;
            this.coTaiKhoan = coTaiKhoan;
            this.tongTienThanhToan = tongTienThanhToan;
            this.maTienTe = maTienTe;
            this.trangThai = trangThai;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public int PhieuThuID
        {
            get { return this.phieuThuID; }
            set
            {
                this.phieuThuID = value;
            }
        }
        public string MaPhieuThu
        {
            get { return this.maPhieuThu; }
            set
            {
                this.maPhieuThu = value;
            }
        }
        public DateTime NgayLap
        {
            get { return this.ngayLap; }
            set { this.ngayLap = value; }
        }
        public string LoaiPhieu
        {
            get { return this.loaiPhieu; }
            set { this.loaiPhieu = value; }
        }
        public string MaKho
        {
            get { return this.maKho; }
            set { this.maKho = value; }
        }
        public string MaNhomHang
        {
            get { return this.maNhomHang; }
            set { this.maNhomHang = value; }
        }
        public string KhoanMuc
        {
            get { return this.khoanMuc; }
            set { this.khoanMuc = value; }
        }
        public string DoiTuong
        {
            get { return this.doiTuong; }
            set { this.doiTuong = value; }
        }
        public string NguoiNopTien
        {
            get { return this.nguoiNopTien; }
            set { this.nguoiNopTien = value; }
        }
        public string NguoiNhanTien
        {
            get { return this.nguoiNhanTien; }
            set { this.nguoiNhanTien = value; }
        }
        public string NoTaiKhoan
        {
            get { return this.noTaiKhoan; }
            set { this.noTaiKhoan = value; }
        }
        public string CoTaiKhoan
        {
            get { return this.coTaiKhoan; }
            set { this.coTaiKhoan = value; }
        }
        public string TongTienThanhToan
        {
            get { return this.tongTienThanhToan; }
            set { this.tongTienThanhToan = value; }
        }
        public string MaTienTe
        {
            get { return this.maTienTe; }
            set { this.maTienTe = value; }
        }
        public Boolean TrangThai
        {
            get { return this.trangThai; }
            set { this.trangThai = value; }
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
        private string maNhanVien;
        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }
        private string tenDangNhap;
        public string TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }
    }
}
