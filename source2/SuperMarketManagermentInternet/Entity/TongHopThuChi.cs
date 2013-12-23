using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
   public class TongHopThuChi
    {
        private string maPhieu;
        private string ngayLap;
        private string dienGiai;
        private double phatSinhNo;
        private double phatSinhCo;
        private double ton;

        public double Ton
        {
            get { return ton; }
            set { ton = value; }
        }
        public double PhatSinhCo
        {
            get { return phatSinhCo; }
            set { phatSinhCo = value; }
        }
        
        public double PhatSinhNo
        {
            get { return phatSinhNo; }
            set { phatSinhNo = value; }
        }
        
        public string DienGiai
        {
            get { return dienGiai; }
            set { dienGiai = value; }
        }

        public string NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }
       
        public string MaPhieu
        {
            get { return maPhieu; }
            set { maPhieu = value; }
        }
       
    }
}
