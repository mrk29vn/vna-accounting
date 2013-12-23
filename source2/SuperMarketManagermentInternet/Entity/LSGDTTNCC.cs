using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
   public class LSGDTTNCC
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
        private string maPhieuTTNCC;

        public string MaPhieuTTNCC
        {
            get { return maPhieuTTNCC; }
            set { maPhieuTTNCC = value; }
        }
        private DateTime ngayLap;

        public DateTime NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }
        private string trangThai;

        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
        private string ghiChu;

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        private string thanhToan;

        public string ThanhToan
        {
            get { return thanhToan; }
            set { thanhToan = value; }
        }
        public LSGDTTNCC()
        { }
        public LSGDTTNCC(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public LSGDTTNCC(string hanhdong,string manhacungcap)
        {
            this.hanhDong = hanhdong;
            this.maNhaCungCap = manhacungcap;
        }
        public LSGDTTNCC(string hanhdong, string manhacungcap, string maphieuTTNCC, DateTime ngaylap, string trangthai, string ghichu, string thanhtoan)
        {
            this.hanhDong = hanhdong;
            this.maNhaCungCap = manhacungcap;
            this.maPhieuTTNCC = maphieuTTNCC;
            this.ngayLap = ngaylap;
            this.trangThai = trangthai;
            this.ghiChu = ghichu;
            this.thanhToan = thanhtoan;
        }
    }
}
