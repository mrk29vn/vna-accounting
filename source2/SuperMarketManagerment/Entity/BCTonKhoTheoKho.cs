using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCTonKhoTheoKho
    {
        private string maKho;
        private string tenKho;
        private string maHangHoa;
        private string tenHangHoa;
        private DateTime ngayNhap;
        private DateTime hanSuDung;
        private int soLuong;
        private string hanhDong;
        public BCTonKhoTheoKho() { }
        public BCTonKhoTheoKho(string hanhDong) { this.hanhDong = hanhDong; }
        public BCTonKhoTheoKho(string hanhDong, string maKho) { this.hanhDong = hanhDong; this.maKho = maKho; }
        public BCTonKhoTheoKho(string maKho, string tenKho, string maHangHoa, DateTime ngayNhap, DateTime hanSuDung, int soLuong, string hanhDong)
        {
            this.maKho = maKho;
            this.tenKho = tenKho;
            this.maHangHoa = maHangHoa;
            this.ngayNhap = ngayNhap;
            this.hanSuDung = hanSuDung;
            this.soLuong = soLuong;
            this.hanhDong = hanhDong;
        }
        public string MaKho
        {
            get { return this.maKho; }
            set { this.maKho = value; }
        }
        public string TenKho { get { return this.tenKho; } set { this.tenKho = value; } }
        public string MaHangHoa { get { return this.maHangHoa; } set { this.maHangHoa = value; } }
        public string TenHangHoa { get { return this.tenHangHoa; } set { this.tenHangHoa = value; } }
        public DateTime NgayNhap { get { return this.ngayNhap; } set { this.ngayNhap = value; } }
        public DateTime HanSuDung { get { return this.hanSuDung; } set { this.hanSuDung = value; } }
        public int SoLuong { get { return this.soLuong; } set { this.soLuong = value; } }
        public string HanhDong { get { return this.hanhDong; } set { this.hanhDong = value; } }
    }
}
