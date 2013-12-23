using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BaoCaoXuatHangTheoKho
    {
        private string maKho;

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
        private string maNhanVien;

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
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

        public BaoCaoXuatHangTheoKho() { }

        public BaoCaoXuatHangTheoKho(string makho,string manhanvien,string tenhang,int soluong,string tongtien) 
        {
            this.maKho = makho;
            this.maNhanVien = manhanvien;
            this.tenHangHoa = tenhang;
            this.soLuong = soluong;
            this.tongTienThanhToan = tongtien;
        }
    }
}
