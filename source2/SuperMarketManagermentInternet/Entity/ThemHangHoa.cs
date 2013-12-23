using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
      [Serializable]
    public class ThemHangHoa
    {
        private string hanhDong;
        private string maHangHoa;   
        private string tenHangHoa;
        private string giagoc;
        private string giabanbuon;
        private string giabanle;
        private int soluong;
        private string phantramchietkhau;
        private string giaNhap;
        private string chietkhau;
        private string tongtien;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }
        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }

        public string GiaGoc
        {
            get { return giagoc; }
            set { giagoc = value; }
        }
        public string GiaBanBuon
        {
            get { return giabanbuon; }
            set { giabanbuon = value; }
        }
        public string GiaBanLe
        {
            get { return giabanle; }
            set { giabanle = value; }
        }
        public int SoLuong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        public string PhanTramChietKhau
        {
            get { return phantramchietkhau; }
            set { phantramchietkhau = value; }
        }
        public string GiaNhap
        {
            get { return giaNhap; }
            set { giaNhap = value; }
        }
        public string ChietKhau
        {
            get { return chietkhau; }
            set { chietkhau = value; }
        }
        public string TongTien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }

        public ThemHangHoa() { }
        public ThemHangHoa(string hanhDong, string maHangHoa,string tenHangHoa, string giagoc, string giabanbuon, string giabanle,  int soluong, string phantramchietkhau, string giaNhap,string chietkhau,string tongtien) 
        {
            this.hanhDong = hanhDong;
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.giagoc = giagoc;
            this.giabanbuon = giabanbuon;
            this.giabanle = giabanle;
            this.soluong = soluong;
            this.phantramchietkhau = phantramchietkhau;
            this.giaNhap = giaNhap;
            this.chietkhau = chietkhau;
            this.tongtien = tongtien;
        }
    }
}
