using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class GiaVon
    {
        public GiaVon()
        {
            this.thaoTac = "";
            this.maKho = "";
            this.maHangHoa = "";
            this.soLuong = 0;
            this.gia = 0;
        }

        public GiaVon(string thaoTac, string maKho, string maHangHoa, int soLuong, float gia)
        {
            this.thaoTac = thaoTac;
            this.maKho = maKho;
            this.maHangHoa = maHangHoa;
            this.soLuong = soLuong;
            this.gia = gia;
        }

        string thaoTac;

        public string ThaoTac
        {
            get { return thaoTac; }
            set { thaoTac = value; }
        }

        string maKho;

        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
        string maHangHoa;

        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }
        int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        float gia;

        public float Gia
        {
            get { return gia; }
            set { gia = value; }
        }
    }
}
