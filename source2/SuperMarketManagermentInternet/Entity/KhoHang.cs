using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class KhoHang
    {
        private string hanhDong;
        private int khoHangID;
        private string maKho;
        private string tenKho;
        private string diaChi;
        private string dienThoai;
        private string maNhanVien;
        private string ghiChu;
        private bool deleted;
        public KhoHang()
        { }
        public KhoHang(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public KhoHang(string hanhDong, int id)
        {
            this.hanhDong = hanhDong;
            this.khoHangID = id;
        }
        public KhoHang(string hanhDong, int khoHangID, string maKho, string tenKho, string diaChi, string dienThoai, string maNhanVien, string ghiChu, bool deleted)
        {
            this.hanhDong = hanhDong;
            this.khoHangID = khoHangID;
            this.maKho = maKho;
            this.tenKho = tenKho;
            this.diaChi = diaChi;
            this.dienThoai = dienThoai;
            this.maNhanVien = maNhanVien;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        public int KhoHangID
        {
            get { return this.khoHangID; }
            set
            {
                this.khoHangID = value;
            }
        }
        public string MaKho
        {
            get { return this.maKho; }
            set
            {
                this.maKho = value;
            }
        }
        public string TenKho
        {
            get { return this.tenKho; }
            set
            {
                this.tenKho = value;
            }
        }
        public string DiaChi
        {
            get { return this.diaChi; }
            set { this.diaChi = value; }
        }
        public string DienThoai
        {
            get { return this.dienThoai; }
            set { this.dienThoai = value; }
        }
        public string MaNhanVien
        {
            get { return this.maNhanVien; }
            set { this.maNhanVien = value; }
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
    }
}
