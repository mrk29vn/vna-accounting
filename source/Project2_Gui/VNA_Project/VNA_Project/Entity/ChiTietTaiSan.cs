using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class ChiTietTaiSan
    {
        public ChiTietTaiSan() { }

        string maTaiSan = string.Empty;
        string maNguonVon = string.Empty;
        DateTime ngayChungTu = new DateTime(1753, 1, 1);
        string soChungTu = string.Empty;
        double nguyenGia = 0;
        double giaTriDaKhauHao = 0;
        double giaTriConLai = 0;
        double giaTriKhauHao1Ky = 0;
        string dienGiai = string.Empty;

        public string MaTaiSan
        {
            get { return maTaiSan; }
            set { maTaiSan = value; }
        }
        public string MaNguonVon
        {
            get { return maNguonVon; }
            set { maNguonVon = value; }
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

        public ChiTietTaiSan Copy()
        {
            ChiTietTaiSan kq = new ChiTietTaiSan();
            kq.MaTaiSan = maTaiSan;
            kq.MaNguonVon = maNguonVon;
            kq.NgayChungTu = ngayChungTu;
            kq.SoChungTu = soChungTu;
            kq.NguyenGia = nguyenGia;
            kq.GiaTriDaKhauHao = giaTriDaKhauHao;
            kq.GiaTriConLai = giaTriConLai;
            kq.GiaTriKhauHao1Ky = giaTriKhauHao1Ky;
            kq.DienGiai = dienGiai;
            return kq;
        }
    }
}
