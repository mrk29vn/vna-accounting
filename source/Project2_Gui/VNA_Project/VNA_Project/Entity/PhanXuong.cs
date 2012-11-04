using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class PhanXuong
    {
        public PhanXuong() { }

        string maPhanXuong = string.Empty;
        string tenPhanXuong = string.Empty;

        public string MaPhanXuong
        {
            get { return maPhanXuong; }
            set { maPhanXuong = value; }
        }
        public string TenPhanXuong
        {
            get { return tenPhanXuong; }
            set { tenPhanXuong = value; }
        }

        public PhanXuong Copy()
        {
            PhanXuong kq = new PhanXuong();
            kq.MaPhanXuong = maPhanXuong;
            kq.TenPhanXuong = tenPhanXuong;
            return kq;
        }
    }
}
