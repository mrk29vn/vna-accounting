using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class PhieuTTNCC
    {
        private int phieuTTNCCID;
        private string maPhieuTTNCC;
        private DateTime ngayLap;
        private string maNCC;
        private string tenNhaCungCap;
        private string noHienThoi;
        private string nguoinhan;
        private string maTienTe;
        private string ghiChu;
        private bool deleted;
        private string Hanhdong;

        public string HanhDong
        {
            get { return Hanhdong; }
            set { Hanhdong = value; }
        }
        public PhieuTTNCC()
        { }
        public PhieuTTNCC(string Hanhdong)
        {
            this.Hanhdong = Hanhdong;
        }

        public PhieuTTNCC(string Hanhdong, int phieuTTNCCID)
        {
            this.Hanhdong = Hanhdong;
            this.phieuTTNCCID = phieuTTNCCID;
        }
        public PhieuTTNCC(string Hanhdong, int phieuTTNCCID, string maPhieuTTNCC, DateTime ngayLap, string maNCC, string noHienThoi,
            string nguoinhan, string maTienTe, string ghiChu, bool deleted, string maNhanVien, string tenDangNhap)
        {
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
            this.Hanhdong = Hanhdong;
            this.phieuTTNCCID = phieuTTNCCID;
            this.maPhieuTTNCC = maPhieuTTNCC;
            this.ngayLap = ngayLap;
            this.maNCC = maNCC;
            this.noHienThoi = noHienThoi;
            this.nguoinhan = nguoinhan;
            this.maTienTe = maTienTe;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public PhieuTTNCC(int phieuTTNCCID, string maPhieuTTNCC, DateTime ngayLap, string maNCC, string noHienThoi,
            string nguoinhan, string maTienTe, string ghiChu, bool deleted)
        {
            this.phieuTTNCCID = phieuTTNCCID;
            this.maPhieuTTNCC = maPhieuTTNCC;
            this.ngayLap = ngayLap;
            this.maNCC = maNCC;
            this.noHienThoi = noHienThoi;
            this.nguoinhan = nguoinhan;
            this.maTienTe = maTienTe;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public int PhieuTTNCCID
        {
            get { return this.phieuTTNCCID; }
            set
            {
                this.phieuTTNCCID = value;
            }
        }
        public string MaPhieuTTNCC
        {
            get { return this.maPhieuTTNCC; }
            set
            {
                this.maPhieuTTNCC = value;
            }
        }
        public DateTime NgayLap
        {
            get { return this.ngayLap; }
            set { this.ngayLap = value; }
        }
        public string MaNCC
        {
            get { return this.maNCC; }
            set { this.maNCC = value; }
        }
        public string TenNhaCungCap
        {
            get { return this.tenNhaCungCap; }
            set { this.tenNhaCungCap = value; }
        }
        public string NoHienThoi
        {
            get { return this.noHienThoi; }
            set { this.noHienThoi = value; }
        }
        public string Nguoinhan
        {
            get { return this.nguoinhan; }
            set { this.nguoinhan = value; }
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
