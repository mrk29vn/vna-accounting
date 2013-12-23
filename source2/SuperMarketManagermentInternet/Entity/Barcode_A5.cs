using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class Barcode_A5
    {
        private string maHangHoaMot;

        public string MaHangHoaMot
        {
            get { return maHangHoaMot; }
            set { maHangHoaMot = value; }
        }
        private string tenHangHoaMot;

        public string TenHangHoaMot
        {
            get { return tenHangHoaMot; }
            set { tenHangHoaMot = value; }
        }
        private Byte[] anhMot;

        public Byte[] AnhMot
        {
            get { return anhMot; }
            set { anhMot = value; }
        }
        //============================================
        private string maHangHoaHai;

        public string MaHangHoaHai
        {
            get { return maHangHoaHai; }
            set { maHangHoaHai = value; }
        }
        private string tenHangHoaHai;

        public string TenHangHoaHai
        {
            get { return tenHangHoaHai; }
            set { tenHangHoaHai = value; }
        }
        private Byte[] anhHai;

        public Byte[] AnhHai
        {
            get { return anhHai; }
            set { anhHai = value; }
        }

        public Barcode_A5() { }
    }
}
