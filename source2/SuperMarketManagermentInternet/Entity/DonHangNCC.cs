using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
   public class DonHangNCC
    {
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private string maNhaCungCap;

        public string MaNhaCungCap
        {
            get { return maNhaCungCap; }
            set { maNhaCungCap = value; }
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
        private string trangThaiDonDatHang;

        public string TrangThaiDonDatHang
        {
            get { return trangThaiDonDatHang; }
            set { trangThaiDonDatHang = value; }
        }
        private string hinhThucThanhToan;

        public string HinhThucThanhToan
        {
            get { return hinhThucThanhToan; }
            set { hinhThucThanhToan = value; }
        }
        private string tongTien;

        public string TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }
        public DonHangNCC()
        { }
        public DonHangNCC(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public DonHangNCC(string hanhdong, string manhacungcap)
        {
            this.hanhDong = hanhdong;
            this.maNhaCungCap = manhacungcap;
        }
        public DonHangNCC(string hanhdong, string manhacungcap, string madondathang, DateTime ngaydonhang, string trangthaidondathang, string hinhthucthanhtoan, string tongtien)
        {
            this.hanhDong = hanhdong;
            this.maNhaCungCap = manhacungcap;
            this.maDonDatHang = madondathang;
            this.ngayDonHang = ngaydonhang;
            this.trangThaiDonDatHang = trangthaidondathang;
            this.hinhThucThanhToan = hinhthucthanhtoan;
            this.tongTien = tongtien;
        }
    }
}
