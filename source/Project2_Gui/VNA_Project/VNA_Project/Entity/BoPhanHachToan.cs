using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class BoPhanHachToan
    {
        public BoPhanHachToan() { }

        string maBoPhanHachToan = string.Empty;
        string tenBoPhanHachToan = string.Empty;

        public string MaBoPhanHachToan
        {
            get { return maBoPhanHachToan; }
            set { maBoPhanHachToan = value; }
        }
        public string TenBoPhanHachToan
        {
            get { return tenBoPhanHachToan; }
            set { tenBoPhanHachToan = value; }
        }

        public BoPhanHachToan Copy()
        {
            BoPhanHachToan kq = new BoPhanHachToan();
            kq.MaBoPhanHachToan = maBoPhanHachToan;
            kq.TenBoPhanHachToan = tenBoPhanHachToan;
            return kq;
        }
    }
}
