using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class LoaiHangHoa
    {
        private string hanhDong;
        private int loaiHangID;
        private string maLoaiHang;
        private string tenLoaiHang;
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
        public LoaiHangHoa()
        { }
        public LoaiHangHoa(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public LoaiHangHoa(string hanhDong, int loaiHangID, string maNhanVien, string tenDangNhap)
        {
            this.hanhDong = hanhDong;
            this.loaiHangID = loaiHangID;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public LoaiHangHoa(string hanhDong, int loaiHangID)
        {
            this.hanhDong = hanhDong;
            this.loaiHangID = loaiHangID;
        }
        public LoaiHangHoa(string hanhDong, int loaiHangID, string maLoaiHang, string tenLoaiHang, string ghiChu, bool deleted)
        {
            this.hanhDong = hanhDong;
            this.loaiHangID = loaiHangID;
            this.maLoaiHang = maLoaiHang;
            this.tenLoaiHang = tenLoaiHang;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        public LoaiHangHoa(string hanhDong, int loaiHangID, string maLoaiHang, string tenLoaiHang, string ghiChu, bool deleted, string maNhanVien, string tenDangNhap)
        {
            this.hanhDong = hanhDong;
            this.loaiHangID = loaiHangID;
            this.maLoaiHang = maLoaiHang;
            this.tenLoaiHang = tenLoaiHang;
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

        public int LoaiHangID
        {
            get { return this.loaiHangID; }
            set
            {
                this.loaiHangID = value;
            }
        }
        public string MaLoaiHang
        {
            get { return this.maLoaiHang; }
            set
            {
                this.maLoaiHang = value;
            }
        }
        public string TenLoaiHang
        {
            get { return this.tenLoaiHang; }
            set { this.tenLoaiHang = value; }
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
