using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCLaiLo
    {
        private DateTime ngay;
        private double doanhSo;
        private double giaVon;
        private double laiGop;

        public BCLaiLo(DateTime ngay, double doanhSo, double giaVon, double laiGop)
        {
            this.ngay = ngay;
            this.doanhSo = doanhSo;
            this.giaVon = giaVon;
            this.laiGop = laiGop;
        }
        public DateTime Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }
        public double DoanhSo
        {
            get { return this.doanhSo; }
            set { this.doanhSo = value; }
        }

        public double GiaVon
        {
            get { return giaVon; }
            set { giaVon = value; }
        }

        public double LaiGop
        {
            get { return laiGop; }
            set { laiGop = value; }
        }
    }
}
