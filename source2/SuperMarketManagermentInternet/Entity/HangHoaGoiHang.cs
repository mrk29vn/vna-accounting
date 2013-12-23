using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     [Serializable]
    public class HangHoaGoiHang
    {
        private string hanhdong;

        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        private string maHang;

        public string MaHang
        {
            get { return maHang; }
            set { maHang = value; }
        }
        private string tenHang;

        public string TenHang
        {
            get { return tenHang; }
            set { tenHang = value; }
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
        private string giaNhap;

        public string GiaNhap
        {
            get { return giaNhap; }
            set { giaNhap = value; }
        }
        private string thue;

        public string Thue
        {
            get { return thue; }
            set { thue = value; }
        }
        private Entities.HangHoa[] hangHoa;

        public Entities.HangHoa[] HangHoa
        {
            get { return hangHoa; }
            set { hangHoa = value; }
        }
        private Entities.GoiHang[] goiHang;

        public Entities.GoiHang[] GoiHang
        {
            get { return goiHang; }
            set { goiHang = value; }
        }
        private string soLuong;

        public string SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
    }
}
