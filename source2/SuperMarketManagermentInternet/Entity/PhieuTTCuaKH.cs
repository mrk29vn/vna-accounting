using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class PhieuTTCuaKH
    {
        private int phieuTTCuaKHID;
        private string maPhieuTTCuaKH;
        private DateTime ngayLap;
        private string maKhachHang;
        private string tenKhachHang;
        private string noHienThoi;
        private string nguoiNop;
        private string maTienTe;
        private string ghiChu;
        private Boolean deleted;
        private string Hanhdong;

        public string HanhDong
        {
            get { return Hanhdong; }
            set { Hanhdong = value; }
        }
        public PhieuTTCuaKH()
        { }

        public PhieuTTCuaKH(string Hanhdong)
        {
            this.Hanhdong = Hanhdong;
        }

        public PhieuTTCuaKH(string Hanhdong, int phieuTTCuaKHID)
        {
            this.Hanhdong = Hanhdong;
            this.phieuTTCuaKHID = phieuTTCuaKHID;
        }
        public PhieuTTCuaKH(string Hanhdong, int phieuTTCuaKHID, string maPhieuTTCuaKH, DateTime ngayLap, string maKhachHang, 
            string noHienThoi, string nguoiNop,string maTienTe, string ghiChu, Boolean deleted,string maNhanVien,string tenDangNhap)
        {
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
            this.Hanhdong = Hanhdong;
            this.phieuTTCuaKHID = phieuTTCuaKHID;
            this.maPhieuTTCuaKH = maPhieuTTCuaKH;
            this.ngayLap = ngayLap;
            this.maKhachHang = maKhachHang;
            this.noHienThoi = noHienThoi;
            this.nguoiNop = nguoiNop;
            this.maTienTe = maTienTe;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public PhieuTTCuaKH(string Hanhdong, int phieuTTCuaKHID, string maPhieuTTCuaKH, DateTime ngayLap, string maKhachHang,string tenKhachHang,
            string noHienThoi, string nguoiNop, string maTienTe, string ghiChu, Boolean deleted)
        {
            this.Hanhdong = Hanhdong;
            this.phieuTTCuaKHID = phieuTTCuaKHID;
            this.maPhieuTTCuaKH = maPhieuTTCuaKH;
            this.ngayLap = ngayLap;
            this.maKhachHang = maKhachHang;
            this.tenKhachHang = tenKhachHang;
            this.noHienThoi = noHienThoi;
            this.nguoiNop = nguoiNop;
            this.maTienTe = maTienTe;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public int PhieuTTCuaKHID
        {
            get { return this.phieuTTCuaKHID; }
            set
            {
                this.phieuTTCuaKHID = value;
            }
        }
        public string MaPhieuTTCuaKH
        {
            get { return this.maPhieuTTCuaKH; }
            set
            {
                this.maPhieuTTCuaKH = value;
            }
        }
        public DateTime NgayLap
        {
            get { return this.ngayLap; }
            set { this.ngayLap = value; }
        }
        public string MaKhachHang
        {
            get { return this.maKhachHang; }
            set { this.maKhachHang = value; }
        }
            public string TenKhachHang
        {
            get { return this.tenKhachHang; }
            set { this.tenKhachHang = value; }
        }
        public string NoHienThoi
        {
            get { return this.noHienThoi; }
            set { this.noHienThoi = value; }
        }
        public string NguoiNop
        {
            get { return this.nguoiNop; }
            set { this.nguoiNop = value; }
        }
        public string MaTienTe
        {
            get { return this.maTienTe; }
            set { this.maTienTe = value; }
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
