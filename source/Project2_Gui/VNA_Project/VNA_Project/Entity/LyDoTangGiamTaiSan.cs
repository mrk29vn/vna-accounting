using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class LyDoTangGiamTaiSan
    {
        public LyDoTangGiamTaiSan() { }

        bool loaiTangGiamTaiSan = false;
        string maLyDoTangGiamTaiSan = string.Empty;
        string tenLyDoTangGiamTaiSan = string.Empty;

        public bool LoaiTangGiamTaiSan
        {
            get { return loaiTangGiamTaiSan; }
            set { loaiTangGiamTaiSan = value; }
        }
        public string MaLyDoTangGiamTaiSan
        {
            get { return maLyDoTangGiamTaiSan; }
            set { maLyDoTangGiamTaiSan = value; }
        }
        public string TenLyDoTangGiamTaiSan
        {
            get { return tenLyDoTangGiamTaiSan; }
            set { tenLyDoTangGiamTaiSan = value; }
        }

        public LyDoTangGiamTaiSan Copy()
        {
            LyDoTangGiamTaiSan kq = new LyDoTangGiamTaiSan();
            kq.LoaiTangGiamTaiSan = loaiTangGiamTaiSan;
            kq.MaLyDoTangGiamTaiSan = maLyDoTangGiamTaiSan;
            kq.TenLyDoTangGiamTaiSan = tenLyDoTangGiamTaiSan;
            return kq;
        }
    }
}
