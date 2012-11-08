using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class PhuTungKemTheo
    {
        public PhuTungKemTheo() { }

        string maTaiSan = string.Empty;
        string maPhuTungKemTheo = string.Empty;
        string tenPhuTungKemTheo = string.Empty;
        string dVT = string.Empty;
        double soLuong = 0;
        double giaTri = 0;
        string ghiChu = string.Empty;

        public string MaTaiSan
        {
            get { return maTaiSan; }
            set { maTaiSan = value; }
        }
        public string MaPhuTungKemTheo
        {
            get { return maPhuTungKemTheo; }
            set { maPhuTungKemTheo = value; }
        }
        public string TenPhuTungKemTheo
        {
            get { return tenPhuTungKemTheo; }
            set { tenPhuTungKemTheo = value; }
        }
        public string DVT
        {
            get { return dVT; }
            set { dVT = value; }
        }
        public double SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        public double GiaTri
        {
            get { return giaTri; }
            set { giaTri = value; }
        }
        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }

        public PhuTungKemTheo Copy()
        {
            PhuTungKemTheo kq = new PhuTungKemTheo();
            kq.MaTaiSan = maTaiSan;
            kq.MaPhuTungKemTheo = maPhuTungKemTheo;
            kq.TenPhuTungKemTheo = tenPhuTungKemTheo;
            kq.DVT = dVT;
            kq.SoLuong = soLuong;
            kq.GiaTri = giaTri;
            kq.GhiChu = ghiChu;
            return kq;
        }
    }
}
