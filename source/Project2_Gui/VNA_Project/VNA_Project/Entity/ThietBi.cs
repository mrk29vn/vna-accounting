using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class ThietBi
    {
        public ThietBi() { }

        string maThietBi = string.Empty;
        string tenThietBi = string.Empty;

        public string MaThietBi
        {
            get { return maThietBi; }
            set { maThietBi = value; }
        }
        public string TenThietBi
        {
            get { return tenThietBi; }
            set { tenThietBi = value; }
        }

        public ThietBi Copy()
        {
            ThietBi kq = new ThietBi();
            kq.MaThietBi = maThietBi;
            kq.TenThietBi = tenThietBi;
            return kq;
        }
    }
}
