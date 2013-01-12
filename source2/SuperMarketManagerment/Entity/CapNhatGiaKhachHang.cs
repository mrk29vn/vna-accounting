using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class CapNhatGiaKhachHang
    {
        private string hanhDong;
        private int capNhatGiaKhachHangID;
        private string maCapNhatGiaKhachHang;
        private string maHangHoa;
        private string maKhachHang;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;
        private float phanTramChietKhau;
        private Boolean deleted;
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
        public CapNhatGiaKhachHang()
        { }
        public CapNhatGiaKhachHang(string hanhdong, int capNhatGiaKhachHangID, string maCapNhatGiaKhachHang, string maHangHoa, string maKhachHang, DateTime ngayBatDau, DateTime ngayKetThuc, float phanTramChietKhau, Boolean deleted)
        {
            this.hanhDong = hanhdong;
            this.capNhatGiaKhachHangID = capNhatGiaKhachHangID;
            this.maCapNhatGiaKhachHang = maCapNhatGiaKhachHang;
            this.maHangHoa = maHangHoa;
            this.maKhachHang = maKhachHang;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
            this.phanTramChietKhau = phanTramChietKhau;
            this.deleted = deleted;
        }
        public CapNhatGiaKhachHang(string hanhdong, int capNhatGiaKhachHangID, string maCapNhatGiaKhachHang, string maHangHoa, string maKhachHang, DateTime ngayBatDau, DateTime ngayKetThuc, float phanTramChietKhau, Boolean deleted, string maNhanVien, string tenDangNhap)
        {
            this.hanhDong = hanhdong;
            this.capNhatGiaKhachHangID = capNhatGiaKhachHangID;
            this.maCapNhatGiaKhachHang = maCapNhatGiaKhachHang;
            this.maHangHoa = maHangHoa;
            this.maKhachHang = maKhachHang;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
            this.phanTramChietKhau = phanTramChietKhau;
            this.deleted = deleted;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public CapNhatGiaKhachHang(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public CapNhatGiaKhachHang(string hanhdong, string maKhachHang)
        {
            this.hanhDong = hanhdong;
            this.maKhachHang = maKhachHang;
        }
        public CapNhatGiaKhachHang(string hanhdong, string maKhachHang, string maNhanVien, string tenDangNhap)
        {
            this.hanhDong = hanhdong;
            this.maKhachHang = maKhachHang;
            this.maNhanVien = maNhanVien;
            this.tenDangNhap = tenDangNhap;
        }
        public int CapNhatGiaKhachHangID
        {
            get { return this.capNhatGiaKhachHangID; }
            set { this.capNhatGiaKhachHangID = value; }
        }
        public string MaCapNhatGiaKhachHang
        {
            get { return this.maCapNhatGiaKhachHang; }
            set { this.maCapNhatGiaKhachHang = value; }
        }
        public string MaHangHoa
        {
            get { return this.maHangHoa; }
            set { this.maHangHoa = value; }
        }
        public string MaKhachHang
        {
            get { return this.maKhachHang; }
            set { this.maKhachHang = value; }
        }
        public DateTime NgayBatDau
        {
            get { return this.ngayBatDau; }
            set { this.ngayBatDau = value; }
        }
        public DateTime NgayKetThuc
        {
            get { return this.ngayKetThuc; }
            set { this.ngayKetThuc = value; }
        }
        public float PhanTramChietKhau
        {
            get { return this.phanTramChietKhau; }
            set { this.phanTramChietKhau = value; }
        }
        public Boolean Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }

    }
}
