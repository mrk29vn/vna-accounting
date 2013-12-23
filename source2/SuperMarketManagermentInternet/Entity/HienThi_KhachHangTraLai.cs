using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class HienThi_KhachHangTraLai
    {
        private string mahoadonbanhang;
        private DateTime ngayban;
        private string tongtien;
        private string nohienthoi;
        private string maKho;
        public string Mahoadonbanhang
        {
            get { return mahoadonbanhang; }
            set { mahoadonbanhang = value; }
        }        
        public DateTime Ngayban
        {
            get { return ngayban; }
            set { ngayban = value; }
        }
        public string Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }
        public string Nohienthoi
        {
            get { return nohienthoi; }
            set { nohienthoi = value; }
        }
        public string MaKho
        {
            get { return maKho; }
            set { maKho = value; }
        }
        public HienThi_KhachHangTraLai() { }
        public HienThi_KhachHangTraLai(string mahoadonbanhang, DateTime ngayban, string tongtien, string nohienthoi, string maKho) 
        {
            this.mahoadonbanhang = mahoadonbanhang;
            this.ngayban = ngayban;
            this.tongtien = tongtien;
            this.nohienthoi = nohienthoi;
            this.maKho = maKho;
        }
    }
}
