using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BaoCaoTienTonKho
    {
        public BaoCaoTienTonKho() { }
        public BaoCaoTienTonKho(string maHangHoa, string tenHangHoa, double slTon, double gtTon) 
        {
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.slTon = slTon;
            this.gtTon = gtTon;
        }

        string maHangHoa = "";

        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }
        string tenHangHoa = "";

        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }
        double slTon = 0;

        public double SlTon
        {
            get { return slTon; }
            set { slTon = value; }
        }
        double gtTon = 0;

        public double GtTon
        {
            get { return gtTon; }
            set { gtTon = value; }
        }
        string gtTonSHOW = "";

        public string GtTonSHOW
        {
            get { return gtTonSHOW; }
            set { gtTonSHOW = value; }
        }
    }

    [Serializable]
    public class BCTienTonKho
    {
        public BCTienTonKho() { }
        public BCTienTonKho(string maKho, string tenKho, double soLuongTon, double giaTriTon) 
        {
            this.maKho = maKho;
            this.tenKho = tenKho;
            this.soLuongTon = soLuongTon;
            this.giaTriTon = giaTriTon;
        }

        string maKho = "";

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
        string tenKho = "";

        public string TenKho
        {
            get { return tenKho; }
            set { tenKho = value; }
        }
        double soLuongTon = 0;

        public double SoLuongTon
        {
            get { return soLuongTon; }
            set { soLuongTon = value; }
        }
        double giaTriTon = 0;

        public double GiaTriTon
        {
            get { return giaTriTon; }
            set { giaTriTon = value; }
        }
        string giaTriTonSHOW = "";

        public string GiaTriTonSHOW
        {
            get { return giaTriTonSHOW; }
            set { giaTriTonSHOW = value; }
        }

        List<BaoCaoTienTonKho> danhSach = new List<BaoCaoTienTonKho>();

        public List<BaoCaoTienTonKho> DanhSach
        {
            get { return danhSach; }
            set { danhSach = value; }
        }
    }
}
