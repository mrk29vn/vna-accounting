using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ChiTietPhieuTTCuaKH
    {
        private string maHDBanHang;
        private string maPhieuTTCuaKH;
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

        public ChiTietPhieuTTCuaKH()
        { }
        public ChiTietPhieuTTCuaKH(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public ChiTietPhieuTTCuaKH(string hanhDong, string maPhieuTTCuaKH)
        {
            this.hanhDong = hanhDong;
            this.maPhieuTTCuaKH = maPhieuTTCuaKH;
        }

        public ChiTietPhieuTTCuaKH(string hanhDong, string maHDBanHang, string maPhieuTTCuaKH)
        {
            this.hanhDong = hanhDong;
            this.maHDBanHang = maHDBanHang;
            this.maPhieuTTCuaKH = maPhieuTTCuaKH;
        }
        public ChiTietPhieuTTCuaKH(string hanhDong, string maHDBanHang, string maPhieuTTCuaKH ,float thanhToan, Boolean trangThai, string ghiChu, Boolean deleted, string tongtien, string tienno)
        {
            this.hanhDong = hanhDong;
            this.maHDBanHang = maHDBanHang;
            this.maPhieuTTCuaKH = maPhieuTTCuaKH;
            this.thanhToan = thanhToan;
            this.trangThai = trangThai;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
            this.tongtien = tongtien;
            this.tienno = tienno;
            
        }

        public string MaHDBanHang
        {
            get { return this.maHDBanHang; }
            set { this.maHDBanHang = value; }
        }
        public string MaPhieuTTCuaKH
        {
            get { return this.maPhieuTTCuaKH; }
            set { this.maPhieuTTCuaKH = value; }
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
