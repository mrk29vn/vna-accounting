using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ChiTietGoiHang
    {
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private int chiTietGoiHangID;

        public int ChiTietGoiHangID
        {
            get { return chiTietGoiHangID; }
            set { chiTietGoiHangID = value; }
        }
        private string maGoiHang;
        private string maHangHoa;
        private string tenHangHoa;
        
        private int soLuong;
        public ChiTietGoiHang()
        { }
        public ChiTietGoiHang(string hanhdong)
        {
            this.hanhDong = hanhdong;
        }
        public ChiTietGoiHang(string hanhdong, int chitietgoihangid, string magoihang, string mahanghoa, string tenhanghoa, string gianhap, string giabanbuon, string giabanle, int soluong)
        {
            this.hanhDong = hanhdong;
            this.chiTietGoiHangID = chitietgoihangid;
            this.maGoiHang = magoihang;
            this.maHangHoa = mahanghoa;
            this.tenHangHoa = tenhanghoa;
            this.giaNhap = gianhap;
            this.giaBanBuon = giabanbuon;
            this.giaBanLe = giabanle;
            this.soLuong = soluong;
        }

        public string MaGoiHang
        {
            get { return this.maGoiHang; }
            set
            {
                this.maGoiHang = value;
            }
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
        public int SoLuong
        {
            get { return this.soLuong; }
            set { this.soLuong = value; }
        }

    }

}
