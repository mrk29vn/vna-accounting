using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class DieuChuyenBoPhanSuDung
    {
        public DieuChuyenBoPhanSuDung() { }

        int dieuChuyenBoPhanSuDungID = 0;
        string maDieuChuyenBoPhanSuDung = string.Empty;
        string maTaiSan = string.Empty;
        string nam = string.Empty;
        string ky = string.Empty;
        string maBoPhanSuDung = string.Empty;
        string tKTaiSan = string.Empty;
        string tKKhauHao = string.Empty;
        string tKChiPhi = string.Empty;

        public int DieuChuyenBoPhanSuDungID
        {
            get { return dieuChuyenBoPhanSuDungID; }
            set { dieuChuyenBoPhanSuDungID = value; }
        }
        public string MaDieuChuyenBoPhanSuDung
        {
            get { return maDieuChuyenBoPhanSuDung; }
            set { maDieuChuyenBoPhanSuDung = value; }
        }
        public string MaTaiSan
        {
            get { return maTaiSan; }
            set { maTaiSan = value; }
        }
        public string Nam
        {
            get { return nam; }
            set { nam = value; }
        }
        public string Ky
        {
            get { return ky; }
            set { ky = value; }
        }
        public string MaBoPhanSuDung
        {
            get { return maBoPhanSuDung; }
            set { maBoPhanSuDung = value; }
        }
        public string TKTaiSan
        {
            get { return tKTaiSan; }
            set { tKTaiSan = value; }
        }
        public string TKKhauHao
        {
            get { return tKKhauHao; }
            set { tKKhauHao = value; }
        }
        public string TKChiPhi
        {
            get { return tKChiPhi; }
            set { tKChiPhi = value; }
        }

        public DieuChuyenBoPhanSuDung Copy()
        {
            DieuChuyenBoPhanSuDung kq = new DieuChuyenBoPhanSuDung();
            kq.DieuChuyenBoPhanSuDungID = dieuChuyenBoPhanSuDungID;
            kq.MaDieuChuyenBoPhanSuDung = maDieuChuyenBoPhanSuDung;
            kq.MaTaiSan = maTaiSan;
            kq.Nam = nam;
            kq.Ky = ky;
            kq.MaBoPhanSuDung = maBoPhanSuDung;
            kq.TKTaiSan = tKTaiSan;
            kq.TKKhauHao = tKKhauHao;
            kq.TKChiPhi = tKChiPhi;
            return kq;
        }
    }
}
