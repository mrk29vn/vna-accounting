using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ThongTinDatHang
    {
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private string maHangHoa;

        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }
        private string tenHangHoa;

        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }
        private string giaNhap;

        public string GiaNhap
        {
            get { return giaNhap; }
            set { giaNhap = value; }
        }
        private string tonkho;

        public string Tonkho
        {
            get { return tonkho; }
            set { tonkho = value; }
        }
        private string giabanbuon;

        public string Giabanbuon
        {
            get { return giabanbuon; }
            set { giabanbuon = value; }
        }
        private string giabanle;

        public string Giabanle
        {
            get { return giabanle; }
            set { giabanle = value; }
        }
        private string giatrigiatang;

        public string Giatrigiatang
        {
            get { return giatrigiatang; }
            set { giatrigiatang = value; }
        }
        public ThongTinDatHang() { }

        public ThongTinDatHang(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public ThongTinDatHang(string hanhdong, string mahanghoa)
        {
            this.hanhDong = hanhdong;
            this.maHangHoa = mahanghoa;
        }

        public ThongTinDatHang(string hanhdong, string mahanghoa, string tenhanghoa, string gianhap,string ton)
        {
            this.hanhDong = hanhdong;
            this.maHangHoa = mahanghoa;
            this.tenHangHoa = tenhanghoa;
            this.giaNhap = gianhap;
            this.tonkho = ton;
        }
        public ThongTinDatHang(string hanhdong, string mahanghoa, string tenhanghoa, string gianhap, string ton,string banbuon,string banle,string thuegiatrigiatang)
        {
            this.hanhDong = hanhdong;
            this.maHangHoa = mahanghoa;
            this.tenHangHoa = tenhanghoa;
            this.giaNhap = gianhap;
            this.tonkho = ton;
            this.giabanbuon = banbuon;
            this.giabanle = banle;
            this.giatrigiatang = thuegiatrigiatang;
        }
    }
}
