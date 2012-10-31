using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class PhanNhomTaiSan
    {
        public PhanNhomTaiSan() { }

        string maPhanNhomTaiSan = string.Empty;
        string tenPhanNhomTaiSan = string.Empty;
        string kieuPhanNhomTaiSan = string.Empty;

        public string MaPhanNhomTaiSan
        {
            get { return maPhanNhomTaiSan; }
            set { maPhanNhomTaiSan = value; }
        }
        public string TenPhanNhomTaiSan
        {
            get { return tenPhanNhomTaiSan; }
            set { tenPhanNhomTaiSan = value; }
        }
        public string KieuPhanNhomTaiSan
        {
            get { return kieuPhanNhomTaiSan; }
            set { kieuPhanNhomTaiSan = value; }
        }
    }
}
