using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class ChiTietXuatHuy
    {
        private string maPhieuXuatHuy;
        private string maHangHoa;
        private int soLuong;
        private string ghiChu;
        private Boolean deleted;
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public ChiTietXuatHuy()
        { }
        public ChiTietXuatHuy(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public ChiTietXuatHuy(string hanhDong, string maPhieuXuatHuy)
        {
            this.hanhDong = hanhDong;
            this.maPhieuXuatHuy = maPhieuXuatHuy;
        }
        public ChiTietXuatHuy(string hanhDong, string maPhieuXuatHuy, string maHangHoa)
        {
            this.hanhDong = hanhDong;
            this.maPhieuXuatHuy = maPhieuXuatHuy;
            this.maHangHoa = maHangHoa;
        }
        public ChiTietXuatHuy(string hanhDong, string maPhieuXuatHuy, string maHangHoa, int soLuong, string ghiChu, Boolean deleted)
        {
            this.hanhDong = hanhDong;
            this.maPhieuXuatHuy = maPhieuXuatHuy;
            this.maHangHoa = maHangHoa;
            this.soLuong = soLuong;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        public string MaPhieuXuatHuy
        {
            get { return this.maPhieuXuatHuy; }
            set { this.maPhieuXuatHuy = value; }
        }
        public string MaHangHoa
        {
            get { return this.maHangHoa; }
            set { this.maHangHoa = value; }
        }
        public int SoLuong
        {
            get { return this.soLuong; }
            set { this.soLuong = value; }
        }
        public string GhiChu
        {
            get { return this.ghiChu; }
            set { this.ghiChu = value; }
        }
        public Boolean Deleted
        {
            get { return this.deleted; }
            set { this.deleted = value; }
        }

    }
}
