using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class TheoNhomHang
    {
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private string maNhomHangHoa;

        public string MaNhomHangHoa
        {
            get { return maNhomHangHoa; }
            set { maNhomHangHoa = value; }
        }
        private string kieuHangHoa;

        public string KieuHangHoa
        {
            get { return kieuHangHoa; }
            set { kieuHangHoa = value; }
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
        private string ghiChu;

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
         public TheoNhomHang()
         { }
         public TheoNhomHang(string hanhdong)
         {
             this.hanhDong = hanhdong;
         }
         public TheoNhomHang(string hanhdong,string manhomhanghoa,string kieuhanghoa,DateTime ngaybatdau,DateTime ngayketthuc,string ghichu)
         {
             this.hanhDong = hanhdong;
             this.maNhomHangHoa = manhomhanghoa;
             this.kieuHangHoa = kieuhanghoa;
             this.ngayBatDau = ngaybatdau;
             this.ngayKetThuc = ngayketthuc;
             this.ghiChu = ghichu;
         }
    }
}
