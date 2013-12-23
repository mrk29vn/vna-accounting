using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class KhuyenMaiSoLuong
    {
        private string hanhDong;
        private int id;
        private string maHangHoa;
        private string tenHangHoa;
        private DateTime ngayBatDau;
        private DateTime ngayKetThuc;
        private double soLuong;
        private double giaBanBuon;
        private double giaBanLe;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }

        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
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

        public double SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public double GiaBanBuon
        {
            get { return giaBanBuon; }
            set { giaBanBuon = value; }
        }

        public double GiaBanLe
        {
            get { return giaBanLe; }
            set { giaBanLe = value; }
        }
    }
}
