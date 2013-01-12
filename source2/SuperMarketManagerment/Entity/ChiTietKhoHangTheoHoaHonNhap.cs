using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ChiTietKhoHangTheoHoaHonNhap
    {
        private string hanhdong;

        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        private string makho;

        public string Makho
        {
            get { return makho; }
            set { makho = value; }
        }
        private string mahanghoa;

        public string Mahanghoa
        {
            get { return mahanghoa; }
            set { mahanghoa = value; }
        }
        private int soluong;

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        private DateTime ngaynhap;

        public DateTime Ngaynhap
        {
            get { return ngaynhap; }
            set { ngaynhap = value; }
        }
        private DateTime ngayhethan;

        public DateTime Ngayhethan
        {
            get { return ngayhethan; }
            set { ngayhethan = value; }
        }
        private string ghichu;

        public string Ghichu
        {
            get { return ghichu; }
            set { ghichu = value; }
        }
        private Boolean deleted;

        public Boolean Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }

        private float gia = 0;

        public float Gia
        {
            get { return gia; }
            set { gia = value; }
        }

        public ChiTietKhoHangTheoHoaHonNhap() { }
        public ChiTietKhoHangTheoHoaHonNhap(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }
        public ChiTietKhoHangTheoHoaHonNhap(string hanhdong, string makho, string mahang, int soluong)
        {
            this.hanhdong = hanhdong;
            this.makho = makho;
            this.mahanghoa = mahang;
            this.soluong = soluong;
        }

        public ChiTietKhoHangTheoHoaHonNhap(string hanhdong, string makho, string mahang, int soluong, DateTime ngaynhap, DateTime ngayhethan, string ghichu, Boolean deleted)
        {
            this.hanhdong = hanhdong;
            this.makho = makho;
            this.mahanghoa = mahang;
            this.soluong = soluong;
            this.ngaynhap = ngaynhap;
            this.ngayhethan = ngayhethan;
            this.ghichu = ghichu;
            this.deleted = deleted;
        }

        public ChiTietKhoHangTheoHoaHonNhap(string hanhdong, string makho, string mahang, int soluong, DateTime ngaynhap, DateTime ngayhethan, string ghichu, Boolean deleted,float gia)
        {
            this.hanhdong = hanhdong;
            this.makho = makho;
            this.mahanghoa = mahang;
            this.soluong = soluong;
            this.ngaynhap = ngaynhap;
            this.ngayhethan = ngayhethan;
            this.ghichu = ghichu;
            this.deleted = deleted;
            this.gia = gia;
        }
    }
}
