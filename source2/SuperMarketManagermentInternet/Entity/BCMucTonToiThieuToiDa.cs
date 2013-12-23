using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCMucTonToiThieuToiDa
    {
        private string maKho;
        private string tenKho;
        private string maHangHoa;
        private string tenHangHoa;
        private int mucTonToiThieu;
        private int mucTonToiDa;
        private int soLuongVuotMucToiThieu;
        private int soLuongVuotMucToiDa;
        private string tinhTrang;
        public BCMucTonToiThieuToiDa(string maKho, string tenKho,string maHangHoa, string tenHangHoa, int mucTonToiThieu, int mucTonToiDa, int soLuongVuotMucToiThieu,
            int soLuongVuotMucToiDa, string tinhTrang)
        {
            this.maKho = maKho;
            this.tenKho = tenKho;
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.mucTonToiThieu = mucTonToiThieu;
            this.mucTonToiDa = mucTonToiDa;
            this.soLuongVuotMucToiDa = soLuongVuotMucToiDa;
            this.soLuongVuotMucToiThieu = soLuongVuotMucToiThieu;
            this.tinhTrang = tinhTrang;
        }
        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
        public string TenKho
        {
            get { return this.tenKho; }
            set { this.tenKho = value; }
        }
        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }
        public string TenHangHoa
        {
            get { return this.tenHangHoa; }
            set { this.tenHangHoa = value; }
        }

        public int MucTonToiThieu
        {
            get { return mucTonToiThieu; }
            set { mucTonToiThieu = value; }
        }

        public int MucTonToiDa
        {
            get { return mucTonToiDa; }
            set { mucTonToiDa = value; }
        }
        public int SoLuongVuotMucToiThieu
        {
            get { return soLuongVuotMucToiThieu; }
            set { soLuongVuotMucToiThieu = value; }
        }
        public int SoLuongVuotMucToiDa
        {
            get { return soLuongVuotMucToiDa; }
            set { soLuongVuotMucToiDa = value; }
        }

        public string TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
    }
}
