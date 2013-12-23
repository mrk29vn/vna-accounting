using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCHDBanBuon
    {
        private string maHDBanHang;
        private string tenHangHoa;
        private DateTime ngayBan;
        private int soLuong;
        private int giaBanBuon;
        private float tongTienThanhToan;
        private string hanhDong;
        private string nguoiNhanHang;
        string chietKhau;
        string thue;

        public BCHDBanBuon() { }
        public BCHDBanBuon(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public BCHDBanBuon(string hanhdong, string mahdbanhang)
        {
            this.hanhDong = hanhdong;
            this.maHDBanHang = mahdbanhang;
        }
       
        public BCHDBanBuon(string mahdbanhang, string nguoiNhanHang, string tenhanghoa, int soluong, int giaBanBuon, DateTime ngayBan, float tongtienthanhtoan)
        {
            this.maHDBanHang = mahdbanhang;
            this.nguoiNhanHang = nguoiNhanHang;
            this.tenHangHoa = tenhanghoa;
            this.soLuong = soluong;
            this.giaBanBuon = giaBanBuon;
            this.ngayBan = ngayBan;
            this.tongTienThanhToan = tongtienthanhtoan;
        }

        public string MaHDBanHang
        {
            get { return this.maHDBanHang; }
            set { this.maHDBanHang = value; }
        }
        public string NguoiNhanHang
        {
            get { return this.nguoiNhanHang; }
            set { this.nguoiNhanHang = value; }
        }
        public string TenHangHoa
        {
            get { return this.tenHangHoa; }
            set { this.tenHangHoa = value; }
        }
        public int SoLuong
        {
            get { return this.soLuong; }
            set { this.soLuong = value; }
        }
        public int GiaBanBuon
        {
            get { return this.giaBanBuon; }
            set { this.giaBanBuon = value; }
        }
        public DateTime NgayBan
        {
            get { return this.ngayBan; }
            set { this.ngayBan = value; }
        }
        public float TongTienThanhToan
        {
            get { return this.tongTienThanhToan; }
            set { this.tongTienThanhToan = value; }
        }
        public string HanhDong
        {
            get { return this.hanhDong; }
            set { this.hanhDong = value; }
        }
        public string Thue
        {
            get { return this.thue; }
            set { this.thue = value; }
        }
        public string ChietKhau
        {
            get { return this.chietKhau; }
            set { this.chietKhau = value; }
        }
    }
}
