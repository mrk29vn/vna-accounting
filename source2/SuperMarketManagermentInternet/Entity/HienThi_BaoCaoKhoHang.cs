using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class HienThi_BaoCaoKhoHang
    {
        private string maKho;

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
        private string tenKho;

        public string TenKho
        {
            get { return tenKho; }
            set { tenKho = value; }
        }
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public HienThi_BaoCaoKhoHang() { }
        public HienThi_BaoCaoKhoHang(string ma,string ten,int soluong) 
        {
            this.maKho = ma;
            this.tenKho = ten;
            this.soLuong = soluong;
        }
    }
}
