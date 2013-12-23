using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
      [Serializable]
    public class ThongTinHangHoa
    {
        private string maNhomHangHoa;

        public string MaNhomHangHoa
        {
            get { return maNhomHangHoa; }
            set { maNhomHangHoa = value; }
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

          public ThongTinHangHoa() {}
          public ThongTinHangHoa(string maNhomHangHoa, string maHangHoa, string tenHangHoa, string giaNhap, string giaBanBuon, string giaBanLe) 
          {
              this.maNhomHangHoa = maNhomHangHoa;
              this.maHangHoa= maHangHoa;
              this.tenHangHoa= tenHangHoa;
              this.giaNhap = giaNhap;
              this.giaBanBuon = giaBanBuon;
              this.giaBanLe = giaBanLe;
          }
    }
}
