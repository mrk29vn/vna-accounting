using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class KMThuChi
    {
        public string NhanVienID;
        public string TenDangNhap;
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private int thuChiID;
        private string maKhoanMuc;
        private string tenKhoanMuc;
        private bool loaiKM;
        private string doiTuong;
        private string noTK;
        private string coTK;
        private string ghiChu;
        private bool deleted;
        private string tenLoaiKhoanMuc;

        

       
        public KMThuChi()
        { }
        public KMThuChi(string hanhDong, bool loaiKM)
        {
            this.hanhDong = hanhDong;
            this.loaiKM = loaiKM;
        }
        public KMThuChi(string hanhDong, int thuChiID,string maKhoanMuc, string nhanVienID, string tenDangNhap)
        {
            this.hanhDong = hanhDong;
            this.thuChiID = thuChiID;
            this.maKhoanMuc = maKhoanMuc;
            this.NhanVienID = nhanVienID;
            this.TenDangNhap = tenDangNhap;
        }
        public KMThuChi(int thuChiID, string maKhoanMuc, string tenKhoanMuc, bool loaiKM, string doiTuong, string noTK, string coTK, string ghiChu, bool deleted)
        {
            this.thuChiID = thuChiID;
            this.maKhoanMuc = maKhoanMuc;
            this.tenKhoanMuc = tenKhoanMuc;
            this.loaiKM = loaiKM;
            this.doiTuong = doiTuong;
            this.noTK = noTK;
            this.coTK = coTK;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }
        public KMThuChi(int thuChiID, string maKhoanMuc, string tenKhoanMuc, bool loaiKM, string doiTuong, string noTK, string coTK, string ghiChu, bool deleted, string tenLoaiKhoanMuc)
        {
            this.thuChiID = thuChiID;
            this.maKhoanMuc = maKhoanMuc;
            this.tenKhoanMuc = tenKhoanMuc;
            this.loaiKM = loaiKM;
            this.doiTuong = doiTuong;
            this.noTK = noTK;
            this.coTK = coTK;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.tenLoaiKhoanMuc = tenLoaiKhoanMuc;
        }
        public KMThuChi(string hanhDong, int thuChiID, string maKhoanMuc, string tenKhoanMuc, bool loaiKM, string doiTuong, string noTK, string coTK, string ghiChu, bool deleted, string nhanVienID, string tenDangNhap)
        {
            this.hanhDong = hanhDong;
            this.thuChiID = thuChiID;
            this.maKhoanMuc = maKhoanMuc;
            this.tenKhoanMuc = tenKhoanMuc;
            this.loaiKM = loaiKM;
            this.doiTuong = doiTuong;
            this.noTK = noTK;
            this.coTK = coTK;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.NhanVienID = nhanVienID;
            this.TenDangNhap = tenDangNhap;
        }

        public KMThuChi(string hanhDong, int thuChiID, string maKhoanMuc, string tenKhoanMuc, bool loaiKM, string doiTuong, string noTK, string coTK, string ghiChu, bool deleted, string tenLoaiKhoanMuc)
        {
            this.hanhDong = hanhDong;
            this.thuChiID = thuChiID;
            this.maKhoanMuc = maKhoanMuc;
            this.tenKhoanMuc = tenKhoanMuc;
            this.loaiKM = loaiKM;
            this.doiTuong = doiTuong;
            this.noTK = noTK;
            this.coTK = coTK;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.tenLoaiKhoanMuc=tenLoaiKhoanMuc;
        }
        public int ThuChiID
        {
            get { return this.thuChiID; }
            set
            {
                this.thuChiID = value;
            }
        }
        public string MaKhoanMuc
        {
            get { return this.maKhoanMuc; }
            set
            {
                this.maKhoanMuc = value;
            }
        }
        public string TenKhoanMuc
        {
            get { return this.tenKhoanMuc; }
            set { this.tenKhoanMuc = value; }
        }
        public bool LoaiKM
        {
            get { return this.loaiKM; }
            set { this.loaiKM = value; }
        }
        public string DoiTuong
        {
            get { return this.doiTuong; }
            set { this.doiTuong = value; }
        }
        public string NoTK
        {
            get { return noTK; }
            set { noTK = value; }
        }


        public string CoTK
        {
            get { return coTK; }
            set { coTK = value; }
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

        public string TenLoaiKhoanMuc
        {
            get { return tenLoaiKhoanMuc; }
            set { tenLoaiKhoanMuc = value; }
        }
    }
}
