using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class DieuChinhGiaTriTaiSan
    {
        public DieuChinhGiaTriTaiSan() { }

        int dieuChinhGiaTriTaiSanID = 0;
        string maDieuChinhGiaTriTaiSan = string.Empty;
        bool loai = true;
        string maTaiSan = string.Empty;
        string nam = string.Empty;
        string ky = string.Empty;
        DateTime ngayChungTu = new DateTime(1753, 1, 1);
        string soChungTu = string.Empty;
        string maNguonVon = string.Empty;
        string maLyDoTangGiamTaiSan = string.Empty;
        double nguyenGia = 0;
        double giaTriDaKhauHao = 0;
        double giaTriConLai = 0;
        double giaTriKhauHao1Ky = 0;
        string dienGiai = string.Empty;

        public int DieuChinhGiaTriTaiSanID
        {
            get { return dieuChinhGiaTriTaiSanID; }
            set { dieuChinhGiaTriTaiSanID = value; }
        }
        public string MaDieuChinhGiaTriTaiSan
        {
            get { return maDieuChinhGiaTriTaiSan; }
            set { maDieuChinhGiaTriTaiSan = value; }
        }
        public bool Loai
        {
            get { return loai; }
            set { loai = value; }
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
        public DateTime NgayChungTu
        {
            get { return ngayChungTu; }
            set { ngayChungTu = value; }
        }
        public string SoChungTu
        {
            get { return soChungTu; }
            set { soChungTu = value; }
        }
        public string MaNguonVon
        {
            get { return maNguonVon; }
            set { maNguonVon = value; }
        }
        public string MaLyDoTangGiamTaiSan
        {
            get { return maLyDoTangGiamTaiSan; }
            set { maLyDoTangGiamTaiSan = value; }
        }
        public double NguyenGia
        {
            get { return nguyenGia; }
            set { nguyenGia = value; }
        }
        public double GiaTriDaKhauHao
        {
            get { return giaTriDaKhauHao; }
            set { giaTriDaKhauHao = value; }
        }
        public double GiaTriConLai
        {
            get { return giaTriConLai; }
            set { giaTriConLai = value; }
        }
        public double GiaTriKhauHao1Ky
        {
            get { return giaTriKhauHao1Ky; }
            set { giaTriKhauHao1Ky = value; }
        }
        public string DienGiai
        {
            get { return dienGiai; }
            set { dienGiai = value; }
        }

        public DieuChinhGiaTriTaiSan Copy()
        {
            DieuChinhGiaTriTaiSan kq = new DieuChinhGiaTriTaiSan();
            kq.DieuChinhGiaTriTaiSanID = dieuChinhGiaTriTaiSanID;
            kq.MaDieuChinhGiaTriTaiSan = maDieuChinhGiaTriTaiSan;
            kq.Loai = loai;
            kq.MaTaiSan = maTaiSan;
            kq.Nam = nam;
            kq.Ky = ky;
            kq.NgayChungTu = ngayChungTu;
            kq.SoChungTu = soChungTu;
            kq.MaNguonVon = maNguonVon;
            kq.MaLyDoTangGiamTaiSan = maLyDoTangGiamTaiSan;
            kq.NguyenGia = nguyenGia;
            kq.GiaTriDaKhauHao = giaTriDaKhauHao;
            kq.GiaTriConLai = giaTriConLai;
            kq.GiaTriKhauHao1Ky = giaTriKhauHao1Ky;
            kq.DienGiai = dienGiai;
            return kq;
        }
    }
}
