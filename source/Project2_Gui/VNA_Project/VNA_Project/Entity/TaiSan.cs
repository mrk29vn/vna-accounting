using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNA_Project.Entity
{
    [Serializable]
    public class TaiSan
    {
        public TaiSan() { }

        string maTaiSan = string.Empty;
        string tenTaiSan = string.Empty;
        string maLoaiTaiSan = string.Empty;
        string maLyDoTangGiamTaiSan = string.Empty;
        DateTime ngayTangTaiSan = new DateTime(1753, 1, 1);
        DateTime ngayTinhKhauHao = new DateTime(1753, 1, 1);
        string soKyKhauHao = string.Empty;
        string maBoPhanHachToan = string.Empty;
        string maPhanXuong = string.Empty;
        string maPhi = string.Empty;
        string maBoPhanSuDung = string.Empty;
        string tKTaiSan = string.Empty;
        string tKKhauHao = string.Empty;
        string tKChiPhi = string.Empty;
        string phanNhom1 = string.Empty;
        string phanNhom2 = string.Empty;
        string phanNhom3 = string.Empty;
        string tenKhac = string.Empty;
        string soHieuTaiSan = string.Empty;
        string thongSoKyThuat = string.Empty;
        string nuocSanXuat = string.Empty;
        string namSanXuat = string.Empty;
        DateTime ngayDuaVaoSuDung = new DateTime(1753, 1, 1);
        DateTime ngayDinhChiSuDung = new DateTime(1753, 1, 1);
        string lyDoDinhChi = string.Empty;
        string ghiChu = string.Empty;

        List<ChiTietTaiSan> lchitiettaisan = new List<ChiTietTaiSan>();
        List<PhuTungKemTheo> lphutungkemtheo = new List<PhuTungKemTheo>();
        public List<ChiTietTaiSan> Lchitiettaisan
        {
            get { return lchitiettaisan; }
            set { lchitiettaisan = value; }
        }
        public List<PhuTungKemTheo> Lphutungkemtheo
        {
            get { return lphutungkemtheo; }
            set { lphutungkemtheo = value; }
        }

        public string MaTaiSan
        {
            get { return maTaiSan; }
            set { maTaiSan = value; }
        }
        public string TenTaiSan
        {
            get { return tenTaiSan; }
            set { tenTaiSan = value; }
        }
        public string MaLoaiTaiSan
        {
            get { return maLoaiTaiSan; }
            set { maLoaiTaiSan = value; }
        }
        public string MaLyDoTangGiamTaiSan
        {
            get { return maLyDoTangGiamTaiSan; }
            set { maLyDoTangGiamTaiSan = value; }
        }
        public DateTime NgayTangTaiSan
        {
            get { return ngayTangTaiSan; }
            set { ngayTangTaiSan = value; }
        }
        public DateTime NgayTinhKhauHao
        {
            get { return ngayTinhKhauHao; }
            set { ngayTinhKhauHao = value; }
        }
        public string SoKyKhauHao
        {
            get { return soKyKhauHao; }
            set { soKyKhauHao = value; }
        }
        public string MaBoPhanHachToan
        {
            get { return maBoPhanHachToan; }
            set { maBoPhanHachToan = value; }
        }
        public string MaPhanXuong
        {
            get { return maPhanXuong; }
            set { maPhanXuong = value; }
        }
        public string MaPhi
        {
            get { return maPhi; }
            set { maPhi = value; }
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
        public string PhanNhom1
        {
            get { return phanNhom1; }
            set { phanNhom1 = value; }
        }
        public string PhanNhom2
        {
            get { return phanNhom2; }
            set { phanNhom2 = value; }
        }
        public string PhanNhom3
        {
            get { return phanNhom3; }
            set { phanNhom3 = value; }
        }
        public string TenKhac
        {
            get { return tenKhac; }
            set { tenKhac = value; }
        }
        public string SoHieuTaiSan
        {
            get { return soHieuTaiSan; }
            set { soHieuTaiSan = value; }
        }
        public string ThongSoKyThuat
        {
            get { return thongSoKyThuat; }
            set { thongSoKyThuat = value; }
        }
        public string NuocSanXuat
        {
            get { return nuocSanXuat; }
            set { nuocSanXuat = value; }
        }
        public string NamSanXuat
        {
            get { return namSanXuat; }
            set { namSanXuat = value; }
        }
        public DateTime NgayDuaVaoSuDung
        {
            get { return ngayDuaVaoSuDung; }
            set { ngayDuaVaoSuDung = value; }
        }
        public DateTime NgayDinhChiSuDung
        {
            get { return ngayDinhChiSuDung; }
            set { ngayDinhChiSuDung = value; }
        }
        public string LyDoDinhChi
        {
            get { return lyDoDinhChi; }
            set { lyDoDinhChi = value; }
        }
        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }

        public TaiSan Copy()
        {
            TaiSan kq = new TaiSan();
            kq.MaTaiSan = maTaiSan;
            kq.TenTaiSan = tenTaiSan;
            kq.MaLoaiTaiSan = maLoaiTaiSan;
            kq.MaLyDoTangGiamTaiSan = maLyDoTangGiamTaiSan;
            kq.NgayTangTaiSan = ngayTangTaiSan;
            kq.NgayTinhKhauHao = ngayTinhKhauHao;
            kq.SoKyKhauHao = soKyKhauHao;
            kq.MaBoPhanHachToan = maBoPhanHachToan;
            kq.MaPhanXuong = maPhanXuong;
            kq.MaPhi = maPhi;
            kq.MaBoPhanSuDung = maBoPhanSuDung;
            kq.TKTaiSan = tKTaiSan;
            kq.TKKhauHao = tKKhauHao;
            kq.TKChiPhi = tKChiPhi;
            kq.PhanNhom1 = phanNhom1;
            kq.PhanNhom2 = phanNhom2;
            kq.PhanNhom3 = phanNhom3;
            kq.TenKhac = tenKhac;
            kq.SoHieuTaiSan = soHieuTaiSan;
            kq.ThongSoKyThuat = thongSoKyThuat;
            kq.NuocSanXuat = nuocSanXuat;
            kq.NamSanXuat = namSanXuat;
            kq.NgayDuaVaoSuDung = ngayDuaVaoSuDung;
            kq.NgayDinhChiSuDung = ngayDinhChiSuDung;
            kq.LyDoDinhChi = lyDoDinhChi;
            kq.GhiChu = ghiChu;
            kq.Lchitiettaisan.AddRange(lchitiettaisan);
            kq.Lphutungkemtheo.AddRange(lphutungkemtheo);
            return kq;
        }
    }
}
