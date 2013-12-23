using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ChiTietPhieuTTNCC
    {
        private string maHoaDonNhap;
        private string maPhieuTTNCC;
        private string tienno;
        private string tongtien;
        private float thanhToan;
        private Boolean trangThai;
        private string ghiChu;
        private Boolean deleted;
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public ChiTietPhieuTTNCC()
        { }
        public ChiTietPhieuTTNCC(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }

        public ChiTietPhieuTTNCC(string hanhDong, string maPhieuTTNCC)
        {
            this.hanhDong = hanhDong;
            this.maPhieuTTNCC = maPhieuTTNCC;
        }

        public ChiTietPhieuTTNCC(string hanhDong,string maHoaDonNhap,string maPhieuTTNCC)
        {
            this.hanhDong = hanhDong;
            this.maHoaDonNhap = maHoaDonNhap;
            this.maPhieuTTNCC = maPhieuTTNCC;
        }

        public ChiTietPhieuTTNCC(string hanhDong, string maHoaDonNhap, string maPhieuTTNCC, float thanhToan, Boolean trangThai, string ghiChu, Boolean deleted, string tongtien, string tienno)
        {
            this.hanhDong = hanhDong;
            this.maHoaDonNhap = maHoaDonNhap;
            this.maPhieuTTNCC = maPhieuTTNCC;
            this.thanhToan = thanhToan;
            this.trangThai = trangThai;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.tongtien = tongtien;
            this.tienno = tienno;
        }

        public string MaHoaDonNhap
        {
            get { return this.maHoaDonNhap; }
            set { this.maHoaDonNhap = value; }
        }
        public string MaPhieuTTNCC
        {
            get { return this.maPhieuTTNCC; }
            set { this.maPhieuTTNCC = value; }
        }
        public float ThanhToan
        {
            get { return this.thanhToan; }
            set { this.thanhToan = value; }
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
        public string TongTien
        {
            get { return this.tongtien; }
            set { this.tongtien = value; }
        }
        public string TienNo
        {
            get { return this.tienno; }
            set { this.tienno = value; }
        }

    }
}
