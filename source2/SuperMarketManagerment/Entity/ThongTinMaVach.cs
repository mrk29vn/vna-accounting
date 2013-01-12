









using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ThongTinMaVach
    {
        private Boolean chonIn;
        private string hanhDong;
        private string maHangHoa;
        private string tenHangHoa;
        private string giaNhap;
        private string giaBanBuon;
        private string giaBanLe;

        private string ghiChu;

        public Boolean ChonIn
        {
            get { return chonIn; }
            set { chonIn = value; }
        }
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public string MaHangHoa
        {
            get { return this.maHangHoa; }
            set
            {
                this.maHangHoa = value;
            }
        }
        public string TenHangHoa
        {
            get { return this.tenHangHoa; }
            set { this.tenHangHoa = value; }
        }
        public string GiaNhap
        {
            get { return this.giaNhap; }
            set { this.giaNhap = value; }
        }
        public string GiaBanBuon
        {
            get { return this.giaBanBuon; }
            set { this.giaBanBuon = value; }
        }
        public string GiaBanLe
        {
            get { return this.giaBanLe; }
            set { this.giaBanLe = value; }
        }
        public string GhiChu
        {
            get { return this.ghiChu; }
            set { this.ghiChu = value; }
        }
        public ThongTinMaVach() {
            this.hanhDong = "";
            this.maHangHoa = "";
            this.tenHangHoa = "";
            this.giaNhap = "";
            this.GiaBanBuon = "";
            this.giaBanLe = "";
            this.ghiChu = "";
        }
        public ThongTinMaVach(string hanhDong) { this.hanhDong = hanhDong; }
        public ThongTinMaVach(Boolean chonIn, string hanhDong, string maHangHoa, string tenHangHoa, string giaNhap, string giaBanBuon, string giaBanLe, string ghiChu)
        {
            this.chonIn = chonIn;
            this.hanhDong = hanhDong;
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.giaNhap = giaNhap;
            this.GiaBanBuon = giaBanBuon;
            this.giaBanLe = giaBanLe;
            this.ghiChu = ghiChu;
        }
    }
}














