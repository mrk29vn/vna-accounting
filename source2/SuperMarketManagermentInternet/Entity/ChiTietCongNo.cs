using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
   public class ChiTietCongNo
    {
        private string maHoaDon;
        private string tenHoaDon;
        private string ngayLap;
        private string ghiChu;
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
        
        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        
        public string NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }
        
        public string TenHoaDon
        {
            get { return tenHoaDon; }
            set { tenHoaDon = value; }
        }
        
        public string MaHoaDon
        {
            get { return maHoaDon; }
            set { maHoaDon = value; }
        }
        

    }
}
