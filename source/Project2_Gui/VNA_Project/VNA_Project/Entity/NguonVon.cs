using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class NguonVon
    {
        public NguonVon() { }

        string maNguonVon = string.Empty;
        string tenNguonVon = string.Empty;

        public string MaNguonVon
        {
            get { return maNguonVon; }
            set { maNguonVon = value; }
        }
        public string TenNguonVon
        {
            get { return tenNguonVon; }
            set { tenNguonVon = value; }
        }

        public NguonVon Copy()
        {
            NguonVon kq = new NguonVon();
            kq.MaNguonVon = maNguonVon;
            kq.TenNguonVon = tenNguonVon;
            return kq;
        }
    }
}
