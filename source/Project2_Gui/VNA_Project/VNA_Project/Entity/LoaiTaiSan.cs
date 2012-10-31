using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class LoaiTaiSan
    {
        public LoaiTaiSan() { }

        string maLoaiTaiSan = string.Empty;
        string tenLoaiTaiSan = string.Empty;

        public string MaLoaiTaiSan
        {
            get { return maLoaiTaiSan; }
            set { maLoaiTaiSan = value; }
        }
        public string TenLoaiTaiSan
        {
            get { return tenLoaiTaiSan; }
            set { tenLoaiTaiSan = value; }
        }

        public LoaiTaiSan Copy()
        {
            LoaiTaiSan kq = new LoaiTaiSan();
            kq.MaLoaiTaiSan = maLoaiTaiSan;
            kq.TenLoaiTaiSan = tenLoaiTaiSan;
            return kq;
        }
    }
}
