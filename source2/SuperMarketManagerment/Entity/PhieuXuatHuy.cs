using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class PhieuXuatHuy
    {
        private int phieuXuatHuyID;
        private string maPhieuXuatHuy;
        private DateTime ngayLap;
        private string maNhanVien;
        private string tenNhanVien;
        private string maKho;
        private Boolean trangThai;
        private string tongtien;
        private string ghiChu;
        private Boolean deleted;
        private string Hanhdong;

        public string HanhDong
        {
            get { return Hanhdong; }
            set { Hanhdong = value; }
        }
        public PhieuXuatHuy()
        { }

        public PhieuXuatHuy(string Hanhdong)
        {
            this.Hanhdong = Hanhdong;
        }
        public PhieuXuatHuy(string Hanhdong,string maKho,int i)
        {
            this.Hanhdong = Hanhdong;
            this.maKho = maKho;
        }
        public PhieuXuatHuy(string Hanhdong, int phieuXuatHuyID)
        {
            this.Hanhdong = Hanhdong;
            this.phieuXuatHuyID = phieuXuatHuyID;
        }

        public PhieuXuatHuy(string Hanhdong, string maPhieuXuatHuy, string maNhanVien, string tenDangNhap)
        {
            this.Hanhdong = Hanhdong;
            this.maPhieuXuatHuy = maPhieuXuatHuy;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }

        public PhieuXuatHuy(string Hanhdong, int phieuXuatHuyID, string maPhieuXuatHuy, DateTime ngayLap, string maNhanVien,
            string maKho, Boolean trangThai, string tongtien, string ghiChu, Boolean deleted, string tenDangNhap)
        {
            this.tenDangNhap = tenDangNhap;
            this.Hanhdong = Hanhdong;
            this.phieuXuatHuyID = phieuXuatHuyID;
            this.maPhieuXuatHuy = maPhieuXuatHuy;
            this.ngayLap = ngayLap;
            this.maNhanVien = maNhanVien;
            this.maKho = maKho;
            this.trangThai = trangThai;
            this.tongtien = tongtien;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public PhieuXuatHuy(string Hanhdong, int phieuXuatHuyID, string maPhieuXuatHuy, DateTime ngayLap, string maNhanVien,string tenNhanVien,
            string maKho, Boolean trangThai, string tongtien, string ghiChu, Boolean deleted)
        {
            this.Hanhdong = Hanhdong;
            this.phieuXuatHuyID = phieuXuatHuyID;
            this.maPhieuXuatHuy = maPhieuXuatHuy;
            this.ngayLap = ngayLap;
            this.maNhanVien = maNhanVien;
            this.tenNhanVien = tenNhanVien;
            this.maKho = maKho;
            this.trangThai = trangThai;
            this.tongtien = tongtien;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        public int PhieuXuatHuyID
        {
            get { return this.phieuXuatHuyID; }
            set
            {
                this.phieuXuatHuyID = value;
            }
        }
        public string MaPhieuXuatHuy
        {
            get { return this.maPhieuXuatHuy; }
            set
            {
                this.maPhieuXuatHuy = value;
            }
        }
        public DateTime NgayLap
        {
            get { return this.ngayLap; }
            set { this.ngayLap = value; }
        }
        public string MaNhanVien
        {
            get { return this.maNhanVien; }
            set { this.maNhanVien = value; }
        }
        public string TenNhanVien
        {
            get { return this.tenNhanVien; }
            set { this.tenNhanVien = value; }
        }
        public string MaKho
        {
            get { return this.maKho; }
            set { this.maKho = value; }
        }
        
        public string Tongtien
        {
            get { return this.tongtien; }
            set { this.tongtien = value; }
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
        private string tenDangNhap;
        public string TenDangNhap
        {
            get { return tenDangNhap; }
            set { tenDangNhap = value; }
        }
    }
}
