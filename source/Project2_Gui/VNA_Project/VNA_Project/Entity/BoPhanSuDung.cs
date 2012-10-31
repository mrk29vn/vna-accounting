using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class BoPhanSuDung
    {
        public BoPhanSuDung() { }

        string maBoPhanSuDung = string.Empty;
        string tenBoPhanSuDung = string.Empty;

        public string MaBoPhanSuDung
        {
            get { return maBoPhanSuDung; }
            set { maBoPhanSuDung = value; }
        }
        public string TenBoPhanSuDung
        {
            get { return tenBoPhanSuDung; }
            set { tenBoPhanSuDung = value; }
        }
    }
}
