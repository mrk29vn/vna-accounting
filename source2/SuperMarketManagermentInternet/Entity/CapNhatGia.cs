using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class CapNhatGia
    {
        private string hanhDong;
        private int capNhatGiaID;
        private string maCapNhatGia;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;
        private string maHangHoa;
        private string phanTramGiaBanBuon;
        private string phanTramGiaBanLe;
        private string giaNhap;
        private bool trangthai;
        private string ghiChu;
        private bool deleted;
        public CapNhatGia()
        { }
        public CapNhatGia(string hanhDong, int capNhatGiaID)
        {
            this.hanhDong = hanhDong;
            this.capNhatGiaID = capNhatGiaID;
        }

        public CapNhatGia(string hanhDong)
        {
            this.hanhDong = hanhDong;
            
        }
        public CapNhatGia(string hanhDong, int capNhatGiaID, string maCapNhatGia, DateTime ngayBatDau, DateTime ngayKetThuc, string maHangHoa, string phanTramGiaBanBuon, string phanTramGiaBanLe, string giaNhap, bool trangthai, string ghiChu, bool deleted)
        {
            this.hanhDong = hanhDong;
            this.capNhatGiaID = capNhatGiaID;
            this.maCapNhatGia = maCapNhatGia;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
            this.maHangHoa = maHangHoa;
            this.phanTramGiaBanBuon = phanTramGiaBanBuon;
            this.phanTramGiaBanLe = phanTramGiaBanLe;
            this.giaNhap = giaNhap;
            this.trangthai = trangthai;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        public int CapNhatGiaID
        {
            get { return this.capNhatGiaID; }
            set
            {
                this.capNhatGiaID = value;
            }
        }
        public string MaCapNhatGia
        {
            get { return this.maCapNhatGia; }
            set
            {
                this.maCapNhatGia = value;
            }
        }
        public DateTime NgayBatDau
        {
            get { return this.ngayBatDau; }
            set
            {
                this.ngayBatDau = value;
            }
        }
        public DateTime NgayKetThuc
        {
            get { return this.ngayKetThuc; }
            set
            {
                this.ngayKetThuc = value;
            }
        }
        public string MaHangHoa
        {
            get { return this.maHangHoa; }
            set { this.maHangHoa = value; }
        }
        public string PhanTramGiaBanBuon
        {
            get { return phanTramGiaBanBuon; }
            set { phanTramGiaBanBuon = value; }
        }

        public string PhanTramGiaBanLe
        {
            get { return phanTramGiaBanLe; }
            set { phanTramGiaBanLe = value; }
        }

        public string GiaNhap
        {
            get { return giaNhap; }
            set { giaNhap = value; }
        }

        public bool Trangthai
        {
            get { return this.trangthai; }
            set { this.trangthai = value; }
        }
        public string GhiChu
        {
            get { return this.ghiChu; }
            set { this.ghiChu = value; }
        }
        public bool Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }

    }
}
