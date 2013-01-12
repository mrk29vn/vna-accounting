using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
   public class TongHopCongNo
    {
        private string maDoiTuong;
        private string tenDoiTuong;
        private string diaChi;
        private double phatSinhNo;
        private double phatSinhCo;
        private double duDauKy;
        private double duCuoiKy;

        public double DuCuoiKy
        {
            get { return duCuoiKy; }
            set { duCuoiKy = value; }
        }
        public double DuDauKy
        {
            get { return duDauKy; }
            set { duDauKy = value; }
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
        
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        
        public string TenDoiTuong
        {
            get { return tenDoiTuong; }
            set { tenDoiTuong = value; }
        }
        
        public string MaDoiTuong
        {
            get { return maDoiTuong; }
            set { maDoiTuong = value; }
        }
      
    }
}
