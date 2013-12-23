using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class TyLeTinh
    {
        public TyLeTinh() { }
        public TyLeTinh(string maTyLeTinh, double soTien, DateTime ngayNhap, string ghiChu, bool deleted) 
        {
            this.maTyLeTinh = maTyLeTinh;
            this.soTien = soTien;
            this.ngayNhap = ngayNhap;
            this.ghiChu = ghiChu;
            this.deleted = deleted;
        }

        string maTyLeTinh = "";

        public string MaTyLeTinh
        {
            get { return maTyLeTinh; }
            set { maTyLeTinh = value; }
        }
        double soTien = 0;

        public double SoTien
        {
            get { return soTien; }
            set { soTien = value; }
        }
        DateTime ngayNhap = new DateTime(1753, 1, 1);

        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }
        string ghiChu = "";

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        bool deleted = false;

        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
