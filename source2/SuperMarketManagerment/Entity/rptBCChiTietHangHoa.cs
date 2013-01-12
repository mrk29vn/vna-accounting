using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
   public class rptBCChiTietHangHoa
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
        private string tenNhomHang;

        public string TenNhomHang
        {
            get { return tenNhomHang; }
            set { tenNhomHang = value; }
        }
        private string tenHangHoa;

        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }
        private string tenDonViTinh;

        public string TenDonViTinh
        {
            get { return tenDonViTinh; }
            set { tenDonViTinh = value; }
        }
        private Double giaNhap;

        public Double GiaNhap
        {
            get { return giaNhap; }
            set { giaNhap = value; }
        }
        private Double giaBanBuon;

        public Double GiaBanBuon
        {
            get { return giaBanBuon; }
            set { giaBanBuon = value; }
        }
        private Double giaBanLe;

        public Double GiaBanLe
        {
            get { return giaBanLe; }
            set { giaBanLe = value; }
        }
        private int mucDatHang;

        public int MucDatHang
        {
            get { return mucDatHang; }
            set { mucDatHang = value; }
        }
        private int mucTonToiThieu;

        public int MucTonToiThieu
        {
            get { return mucTonToiThieu; }
            set { mucTonToiThieu = value; }
        }

       public rptBCChiTietHangHoa()
       { }
       public rptBCChiTietHangHoa(string hanhdong)
       {
           this.hanhDong = hanhdong;
       }
       public rptBCChiTietHangHoa(string hanhdong,string mahanghoa,string tennhomhang,string tenhanghoa,string tendonvitinh,Double gianhap,Double giabanbuon,Double giabanle,int mucdathang,int muctontoithieu)
       {
           this.hanhDong = hanhdong;
           this.maHangHoa = mahanghoa;
           this.tenNhomHang = tennhomhang;
           this.tenHangHoa = tenhanghoa;
           this.tenDonViTinh = tendonvitinh;
           this.giaNhap = gianhap;
           this.giaBanBuon = giabanbuon;
           this.giaBanLe = giabanle;
           this.mucDatHang = mucdathang;
           this.mucTonToiThieu = muctontoithieu;
       }
    }
}
