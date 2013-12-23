using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ThongTinMaDonDatHang
    {
        private string hanhdong;

        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        private string maDonDatHang;

        public string MaDonDatHang
        {
            get { return maDonDatHang; }
            set { maDonDatHang = value; }
        }
        private DateTime ngayDonHang;

        public DateTime NgayDonHang
        {
            get { return ngayDonHang; }
            set { ngayDonHang = value; }
        }
        private string tongTien;

        public string TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        public ThongTinMaDonDatHang()
        { }
        public ThongTinMaDonDatHang(string hanhdong)
        {
            this.hanhdong = hanhdong;
        }
        public ThongTinMaDonDatHang(string hanhdong, DateTime ngaydonhang, string tong)
        {
            this.hanhdong = hanhdong;
            this.ngayDonHang = ngaydonhang;
            this.tongTien = tong;
        }
    }
}
