using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ChiTietTheGiamGia
    {
        public ChiTietTheGiamGia() { }
        public ChiTietTheGiamGia(string thaoTac) { this.thaoTac = thaoTac; }
        public ChiTietTheGiamGia(string thaoTac, string maTheGiamGia, string maKhachHang, string tenKhachHang, double giaTriThe, DateTime ngayThu, string maPhieuThu, bool deleted)
        {
            this.thaoTac = thaoTac;
            this.maTheGiamGia = maTheGiamGia;
            this.maKhachHang = maKhachHang;
            this.tenKhachHang = tenKhachHang;
            this.giaTriThe = giaTriThe;
            this.ngayThu = ngayThu;
            this.maPhieuThu = maPhieuThu;
            this.deleted = deleted;
        }

        string tenKhachHang = "";

        public string TenKhachHang
        {
            get { return tenKhachHang; }
            set { tenKhachHang = value; }
        }

        string thaoTac = "";

        public string ThaoTac
        {
            get { return thaoTac; }
            set { thaoTac = value; }
        }
        string maTheGiamGia = "";

        public string MaTheGiamGia
        {
            get { return maTheGiamGia; }
            set { maTheGiamGia = value; }
        }
        string maKhachHang = "";

        public string MaKhachHang
        {
            get { return maKhachHang; }
            set { maKhachHang = value; }
        }
    
        double giaTriThe = 0;

        public double GiaTriThe
        {
            get { return giaTriThe; }
            set { giaTriThe = value; }
        }
        string giaTriTheSHOW = "";

        public string GiaTriTheSHOW
        {
            get { return giaTriTheSHOW; }
            set { giaTriTheSHOW = value; }
        }


        DateTime ngayThu = new DateTime(1753, 1, 1);

        public DateTime NgayThu
        {
            get { return ngayThu; }
            set { ngayThu = value; }
        }
        string maPhieuThu = "";

        public string MaPhieuThu
        {
            get { return maPhieuThu; }
            set { maPhieuThu = value; }
        }
        bool deleted = false;

        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
