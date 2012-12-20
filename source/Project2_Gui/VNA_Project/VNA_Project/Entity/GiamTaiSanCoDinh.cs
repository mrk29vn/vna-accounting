using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class GiamTaiSanCoDinh
    {
        public GiamTaiSanCoDinh() { }

        int giamTaiSanCoDinhID = 0;
        string maGiamTaiSanCoDinh = string.Empty;
        string maTaiSan = string.Empty;
        string maLyDoTangGiamTaiSan = string.Empty;
        DateTime ngayGiam = new DateTime(1753, 1, 1);
        DateTime ngayKetThucKhauHao = new DateTime(1753, 1, 1);
        string soChungTu = string.Empty;
        string lyDo = string.Empty;

        public int GiamTaiSanCoDinhID
        {
            get { return giamTaiSanCoDinhID; }
            set { giamTaiSanCoDinhID = value; }
        }
        public string MaGiamTaiSanCoDinh
        {
            get { return maGiamTaiSanCoDinh; }
            set { maGiamTaiSanCoDinh = value; }
        }
        public string MaTaiSan
        {
            get { return maTaiSan; }
            set { maTaiSan = value; }
        }
        public string MaLyDoTangGiamTaiSan
        {
            get { return maLyDoTangGiamTaiSan; }
            set { maLyDoTangGiamTaiSan = value; }
        }
        public DateTime NgayGiam
        {
            get { return ngayGiam; }
            set { ngayGiam = value; }
        }
        public DateTime NgayKetThucKhauHao
        {
            get { return ngayKetThucKhauHao; }
            set { ngayKetThucKhauHao = value; }
        }
        public string SoChungTu
        {
            get { return soChungTu; }
            set { soChungTu = value; }
        }
        public string LyDo
        {
            get { return lyDo; }
            set { lyDo = value; }
        }

        public GiamTaiSanCoDinh Copy()
        {
            GiamTaiSanCoDinh kq = new GiamTaiSanCoDinh();
            kq.GiamTaiSanCoDinhID = giamTaiSanCoDinhID;
            kq.MaGiamTaiSanCoDinh = maGiamTaiSanCoDinh;
            kq.MaTaiSan = maTaiSan;
            kq.MaLyDoTangGiamTaiSan = maLyDoTangGiamTaiSan;
            kq.NgayGiam = ngayGiam;
            kq.NgayKetThucKhauHao = ngayKetThucKhauHao;
            kq.SoChungTu = soChungTu;
            kq.LyDo = lyDo;
            return kq;
        }
    }
}
