using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
  public  class LSGDTraLaiNCC
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
        private string maHDTraLaiNCC;

        public string MaHDTraLaiNCC
        {
            get { return maHDTraLaiNCC; }
            set { maHDTraLaiNCC = value; }
        }
        private DateTime ngayTra;

        public DateTime NgayTra
        {
            get { return ngayTra; }
            set { ngayTra = value; }
        }
        private string hinhThucThanhToan;

        public string HinhThucThanhToan
        {
            get { return hinhThucThanhToan; }
            set { hinhThucThanhToan = value; }
        }
        private string ghiChu;

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        private string thanhToanNgay;

        public string ThanhToanNgay
        {
            get { return thanhToanNgay; }
            set { thanhToanNgay = value; }
        }
        public LSGDTraLaiNCC()
        { }
        public LSGDTraLaiNCC(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public LSGDTraLaiNCC(string hanhdong,string manhacungcap)
        {
            this.hanhDong = hanhdong;
            this.maNhaCungCap = manhacungcap;
        }
        public LSGDTraLaiNCC(string hanhdong,string manhacungcap,string mahdtralaincc,DateTime ngaytra,string hinhthucthanhtoan,string ghichu,string thanhtoanngay)
        {
            this.hanhDong = hanhdong;
            this.maNhaCungCap = manhacungcap;
            this.maHDTraLaiNCC = mahdtralaincc;
            this.ngayTra = ngaytra;
            this.hinhThucThanhToan = hinhthucthanhtoan;
            this.ghiChu = ghichu;
            this.thanhToanNgay = thanhtoanngay;
        }

    }
}
