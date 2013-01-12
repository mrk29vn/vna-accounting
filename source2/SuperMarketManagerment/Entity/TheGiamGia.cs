using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class TheGiamGia
    {
        string hanhDong;
        string maTheGiamGia;
        string maKhachHang;
        string giaTriThe;
        string giaTriConLai;
        DateTime ngayBatDau;
        DateTime ngayKetThuc;
        bool deleted;
        public TheGiamGia()
        {
            //
        }
        public TheGiamGia(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public string MaTheGiamGia
        {
            get { return maTheGiamGia; }
            set { maTheGiamGia = value; }
        }
        public string MaKhachHang
        {
            get { return maKhachHang; }
            set { maKhachHang = value; }
        }
        public string GiaTriThe
        {
            get { return giaTriThe; }
            set { giaTriThe = value; }
        }

        public string GiaTriConLai
        {
            get { return giaTriConLai; }
            set { giaTriConLai = value; }
        }

        public DateTime NgayBatDau
        {
            get { return ngayBatDau; }
            set { ngayBatDau = value; }
        }

        public DateTime NgayKetThuc
        {
            get { return ngayKetThuc; }
            set { ngayKetThuc = value; }
        }

        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
