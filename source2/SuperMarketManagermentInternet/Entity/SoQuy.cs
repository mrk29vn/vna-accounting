using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class SoQuy
    {
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        private string ngayLap;

        public string NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }
        
        private string maPhieu;

        public string MaPhieu
        {
            get { return maPhieu; }
            set { maPhieu = value; }
        }

        private string maTK;

        public string MaTK
        {
            get { return maTK; }
            set { maTK = value; }
        }
        private string tenTK;

        public string TenTK
        {
            get { return tenTK; }
            set { tenTK = value; }
        }
        private string dienGiai;

        public string DienGiai
        {
            get { return dienGiai; }
            set { dienGiai = value; }
        }
        private string duDauKy;

        public string DuDauKy
        {
            get { return duDauKy; }
            set { duDauKy = value; }
        }
        private string phatSinhNo;

        public string PhatSinhNo
        {
            get { return phatSinhNo; }
            set { phatSinhNo = value; }
        }

        private string phatSinhCo;

        public string PhatSinhCo
        {
            get { return phatSinhCo; }
            set { phatSinhCo = value; }
        }
        private string duCuoiKy;

        public string DuCuoiKy
        {
            get { return duCuoiKy; }
            set { duCuoiKy = value; }
        }
        
        private string truongNgam;

        public string TruongNgam
        {
            get { return truongNgam; }
            set { truongNgam = value; }
        }
        private string ton;

        public string Ton
        {
            get { return ton; }
            set { ton = value; }
        }
        public SoQuy()
        { }
        public SoQuy(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }

        public SoQuy(string phatSinhNo, string phatSinhCo, string dienGiai)
        {
            this.phatSinhNo = phatSinhNo;
            this.phatSinhCo = phatSinhCo;
            this.dienGiai = dienGiai;
        }
        public SoQuy(string hanhDong,string maTK, string tenTK,string duDauKy)
        {
            this.hanhDong = hanhDong;
            this.maTK = maTK;
            this.tenTK = tenTK;
            this.duDauKy = duDauKy;
        }
        public SoQuy(string phatSinhNo, string phatSinhCo, string tenTK, string duDauKy,string duCuoiKy)
        {
            this.phatSinhNo = phatSinhNo;
            this.phatSinhCo = phatSinhCo;
            this.tenTK = tenTK;
            this.duDauKy = duDauKy;
            this.duCuoiKy = duCuoiKy;
        }
        public SoQuy(string maTK, string tenTK, string duDauKy, string phatSinhNo, string phatSinhCo, string duCuoiKy, string truongNgam)
        {
            this.maTK = maTK;
            this.tenTK = tenTK;
            this.duDauKy = duDauKy;
            this.phatSinhNo = phatSinhNo;
            this.phatSinhCo = phatSinhCo;
            this.duCuoiKy = duCuoiKy;
            this.truongNgam = truongNgam;
        }
        public SoQuy(string ngayLap, string maPhieu, string maTK, string tenTK, string phatSinhNo, string phatSinhCo, string dienGiai, string truongNgam)
        {
            this.ngayLap = ngayLap;
            this.maPhieu = maPhieu;
            this.maTK = maTK;
            this.tenTK = tenTK;
            this.phatSinhNo = phatSinhNo;
            this.phatSinhCo = phatSinhCo;
            this.dienGiai = dienGiai;
            this.truongNgam = truongNgam;
        }
        public SoQuy(string ngayLap, string hanhDong, string maPhieu, string maTK, string tenTK, string duDauKy, string phatSinhNo, string phatSinhCo, string duCuoiKy,string dienGiai, string truongNgam)
        {
            this.ngayLap = ngayLap;
            this.hanhDong = hanhDong;
            this.maPhieu = maPhieu;
            this.maTK = maTK;
            this.tenTK = tenTK;
            this.duDauKy = duDauKy;
            this.phatSinhNo = phatSinhNo;
            this.phatSinhCo = phatSinhCo;
            this.duCuoiKy = duCuoiKy;
            this.dienGiai = dienGiai;
            this.truongNgam = truongNgam;
        }
        public SoQuy(string ngayLap, string hanhDong,string maPhieu,string maTK,string tenTK,string duDauKy, string phatSinhNo, string phatSinhCo,string duCuoiKy,string dienGiai,string truongNgam,string ton)
        {
            this.ngayLap = ngayLap;
            this.hanhDong = hanhDong;
            this.maPhieu = maPhieu;
            this.maTK = maTK;
            this.tenTK = tenTK;
            this.duDauKy = duDauKy;
            this.phatSinhNo = phatSinhNo;
            this.phatSinhCo = phatSinhCo;
            this.duCuoiKy = duCuoiKy;
            this.dienGiai = dienGiai;
            this.truongNgam = truongNgam;
            this.ton = ton;
        }
    }

    [Serializable]
    public class BCSoQuy
    {
        string maTK;

        public string MaTK
        {
            get { return maTK; }
            set { maTK = value; }
        }
        string tenTK;

        public string TenTK
        {
            get { return tenTK; }
            set { tenTK = value; }
        }
        double duDauKy;

        public double DuDauKy
        {
            get { return duDauKy; }
            set { duDauKy = value; }
        }
        double phatSinhNo;

        public double PhatSinhNo
        {
            get { return phatSinhNo; }
            set { phatSinhNo = value; }
        }
        double phatSinhCo;

        public double PhatSinhCo
        {
            get { return phatSinhCo; }
            set { phatSinhCo = value; }
        }
        double duCuoiKy;

        public double DuCuoiKy
        {
            get { return duCuoiKy; }
            set { duCuoiKy = value; }
        }
        string ngayLap;

        public string NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }
        string maPhieu;

        public string MaPhieu
        {
            get { return maPhieu; }
            set { maPhieu = value; }
        }
        double ton;

        public double Ton
        {
            get { return ton; }
            set { ton = value; }
        }

        public BCSoQuy()
        {
            this.maTK = "";
            this.tenTK = "";
            this.duDauKy = 0;
            this.phatSinhNo = 0;
            this.phatSinhCo = 0;
            this.duCuoiKy = 0;
            this.ngayLap = "";
            this.maPhieu = "";
            this.ton = 0;
        }

        public BCSoQuy(string maTK, string tenTK, double duDauKy, double phatSinhNo, double phatSinhCo, double duCuoiKy, string ngayLap, string maPhieu, double ton)
        {
            this.maTK = maTK;
            this.tenTK = tenTK;
            this.duDauKy = duDauKy;
            this.phatSinhNo = phatSinhNo;
            this.phatSinhCo = phatSinhCo;
            this.duCuoiKy = duCuoiKy;
            this.ngayLap = ngayLap;
            this.maPhieu = maPhieu;
            this.ton = ton;
        }
    }

    [Serializable]
    public class UpdateDuNoK29
    {
        string thaoTac;

        public string ThaoTac
        {
            get { return thaoTac; }
            set { thaoTac = value; }
        }
        string maNhaCungCap;

        public string MaNhaCungCap
        {
            get { return maNhaCungCap; }
            set { maNhaCungCap = value; }
        }
        string maKH;

        public string MaKH
        {
            get { return maKH; }
            set { maKH = value; }
        }
        float soLuong;

        public float SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }

        public UpdateDuNoK29()
        {
            this.thaoTac = "";
            this.maNhaCungCap = "";
            this.maKH = "";
            this.soLuong = 0;
        }

        public UpdateDuNoK29(string thaoTac, string maNhaCungCap, string maKH, float soLuong)
        {
            this.thaoTac = thaoTac;
            this.maNhaCungCap = maNhaCungCap;
            this.maKH = maKH;
            this.soLuong = soLuong;
        }
    }

    //[Serializable]
    //public class BCChiTietSoQuy
    //{
    //    string maTK;
    //    string tenTK;
    //    double duDauKy;
    //    double phatSinhNo;
    //    double phatSinhCo;
    //    double duCuoiKy;
    //    string ngayLap;
    //    string maPhieu;
    //    double ton;

    //    public BCChiTietSoQuy()
    //    {

    //    }

    //    public BCChiTietSoQuy(string maTK, string tenTK, double duDauKy, double phatSinhNo, double phatSinhCo, double duCuoiKy, string ngayLap, string maPhieu, double ton)
    //    {

    //    }
    //}
}
