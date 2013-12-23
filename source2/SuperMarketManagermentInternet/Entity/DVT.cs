using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class DVT
    {
        private string hanhDong;
        private int dVTID;
        private string maDonViTinh;
        private string tenDonViTinh;
        private string ghiChu;
        private bool deleted;
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
        public DVT()
        { }
        public DVT(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public DVT(string hanhDong, int dVTID)
        {
            this.hanhDong = hanhDong;
            this.dVTID = dVTID;
        }
        public DVT(string hanhDong, int dVTID, string maNhanVien, string tenDangNhap)
        {
            this.hanhDong = hanhDong;
            this.dVTID = dVTID;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public DVT(string hanhDong,int dVTID, string maDonViTinh, string tenDonViTinh, string ghiChu, bool deleted)
        {
            this.hanhDong = hanhDong;
            this.dVTID = dVTID;
            this.maDonViTinh = maDonViTinh;
            this.tenDonViTinh = tenDonViTinh;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        public DVT(string hanhDong, int dVTID, string maDonViTinh, string tenDonViTinh, string ghiChu, bool deleted, string maNhanVien, string tenDangNhap)
        {
            this.hanhDong = hanhDong;
            this.dVTID = dVTID;
            this.maDonViTinh = maDonViTinh;
            this.tenDonViTinh = tenDonViTinh;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        public int DVTID
        {
            get { return this.dVTID; }
            set
            {
                this.dVTID = value;
            }
        }
        public string MaDonViTinh
        {
            get { return this.maDonViTinh; }
            set
            {
                this.maDonViTinh = value;
            }
        }
        public string TenDonViTinh
        {
            get { return this.tenDonViTinh; }
            set { this.tenDonViTinh = value; }
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
}
