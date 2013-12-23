using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BaoCaoXuatHangTheoNhomHang
    {        
        private string tenNhomHang;
        public string MaNhanVien
        {
            get { return tenNhomHang; }
            set { tenNhomHang = value; }
        }

        private string maKho;
        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }

        private string tenHangHoa;
        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }

        private int soLuong;
        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        private string tongTienThanhToan;
        public string TongTienThanhToan
        {
            get { return tongTienThanhToan; }
            set { tongTienThanhToan = value; }
        }

        public BaoCaoXuatHangTheoNhomHang() { }

        public BaoCaoXuatHangTheoNhomHang(string tennhom, string makho, string tenhang, int soluong, string tongtien) 
        {
            this.tenNhomHang = tennhom;
            this.maKho = makho;
            this.tenHangHoa = tenhang;
            this.soLuong = soluong;
            this.tongTienThanhToan = tongtien;
        }
    }
}
