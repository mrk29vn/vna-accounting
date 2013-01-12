using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
   public class TheoHangHoa
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
        private DateTime ngayBatDau;

        public DateTime NgayBatDau
        {
            get { return ngayBatDau; }
            set { ngayBatDau = value; }
        }
        private DateTime ngayKetThuc;

        public DateTime NgayKetThuc
        {
            get { return ngayKetThuc; }
            set { ngayKetThuc = value; }
        }
        private string giaBanBuon;

        public string GiaBanBuon
        {
            get { return giaBanBuon; }
            set { giaBanBuon = value; }
        }
        private string giaBanLe;

        public string GiaBanLe
        {
            get { return giaBanLe; }
            set { giaBanLe = value; }
        }
        private string ghiChu;

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
       public TheoHangHoa()
       { }
       public TheoHangHoa(string hanhdong)
       {
           this.hanhDong = hanhdong;
       }
       public TheoHangHoa(string hanhdong,string mahanghoa,DateTime ngaybatdau,DateTime ngayketthuc,string giabanbuon,string giabanle,string ghichu)
       {
           this.hanhDong = hanhdong;
           this.maHangHoa = mahanghoa;
           this.ngayBatDau = ngaybatdau;
           this.ngayKetThuc = ngayketthuc;
           this.giaBanBuon = giabanbuon;
           this.giaBanLe = giabanle;
           this.ghiChu = ghichu;
       }
    }
}
