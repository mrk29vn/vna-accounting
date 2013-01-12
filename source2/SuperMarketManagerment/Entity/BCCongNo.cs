using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCCongNo
    {
        private string maDoiTuong;
        private string tenDoiTuong;
        private string noDauKy;
        private string phatSinhTang;
        private string phatSinhGiam;
        private string noCuoiKy;

        public BCCongNo(){}

        public BCCongNo(string maDoiTuong, string tenDoiTuong, string noDauKy, string phatSinhTang, string phatSinhGiam, string noCuoiKy)
        {
            this.maDoiTuong = maDoiTuong;
            this.tenDoiTuong = tenDoiTuong;
            this.noDauKy = noDauKy;
            this.phatSinhTang = phatSinhTang;
            this.phatSinhGiam = phatSinhGiam;
            this.noCuoiKy = noCuoiKy;
        }

        public string MaDoiTuong
        {
            get { return this.maDoiTuong; }
            set { this.maDoiTuong = value; }
        }
        public string TenDoiTuong
        {
            get { return this.tenDoiTuong; }
            set { this.tenDoiTuong = value; }
        }
        public string NoDauKy
        {
            get { return this.noDauKy; }
            set { this.noDauKy = value; }
        }
        public string PhatSinhTang
        {
            get { return this.phatSinhTang; }
            set { this.phatSinhTang = value; }
        }
        public string PhatSinhGiam
        {
            get { return this.phatSinhGiam; }
            set { this.phatSinhGiam = value; }
        }
        public string NoCuoiKy
        {
            get { return this.noCuoiKy; }
            set { this.noCuoiKy = value; }
        }
    }
}
