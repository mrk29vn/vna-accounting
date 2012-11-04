using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class Phi
    {
        public Phi() { }

        string maPhi = string.Empty;
        string tenPhi = string.Empty;

        public string MaPhi
        {
            get { return maPhi; }
            set { maPhi = value; }
        }
        public string TenPhi
        {
            get { return tenPhi; }
            set { tenPhi = value; }
        }

        public Phi Copy()
        {
            Phi kq = new Phi();
            kq.MaPhi = maPhi;
            kq.TenPhi = tenPhi;
            return kq;
        }
    }
}
