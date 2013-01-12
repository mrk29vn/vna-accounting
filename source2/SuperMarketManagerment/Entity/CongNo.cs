using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class CongNo
    {
        
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private string maDoiTuong;
        private string ngayLap;

        public string NgayLap
        {
            get { return ngayLap; }
            set { ngayLap = value; }
        }
        public string MaDoiTuong
        {
            get { return maDoiTuong; }
            set { maDoiTuong = value; }
        }

        private string tenDoiTuong;

        public string TenDoiTuong
        {
            get { return tenDoiTuong; }
            set { tenDoiTuong = value; }
        }
        private string diaChi;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        private string ghiChu;

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
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
        private string ton;

        public string Ton
        {
            get { return ton; }
            set { ton = value; }
        }
        private string truongNgam;

        public string TruongNgam
        {
            get { return truongNgam; }
            set { truongNgam = value; }
        }
        private string maTruongNgam;

        public string MaTruongNgam
        {
            get { return maTruongNgam; }
            set { maTruongNgam = value; }
        }
        public CongNo() { }
        public CongNo(string maDoiTuong, string tenDoiTuong, string diaChi,string duDauKy, string phatSinhNo, string phatSinhCo, string duCuoiKy)
        {
            this.maDoiTuong = maDoiTuong;
            this.diaChi = diaChi;
            this.tenDoiTuong = tenDoiTuong;
            this.phatSinhCo = phatSinhCo;
            this.phatSinhNo = phatSinhNo;
            this.duCuoiKy = duCuoiKy;
            this.duDauKy = duDauKy;
        }
        public CongNo(string ghichu, string duDauKy, string phatSinhNo, string phatSinhCo, string duCuoiKy)
        {
            this.ghiChu = ghichu;
            this.phatSinhCo = phatSinhCo;
            this.phatSinhNo = phatSinhNo;
            this.duCuoiKy = duCuoiKy;
            this.duDauKy = duDauKy;
        }

        public CongNo(string diachi, string duDauKy, string phatSinhNo, string phatSinhCo, string duCuoiKy,string a)
        {
            this.diaChi = diachi;
            this.phatSinhCo = phatSinhCo;
            this.phatSinhNo = phatSinhNo;
            this.duCuoiKy = duCuoiKy;
            this.duDauKy = duDauKy;
        }

        public CongNo(string ngayLap, string maDoiTuong, string tenDoiTuong, string diaChi, string phatSinhNo, string phatSinhCo, string ghiChu, string truongNgam)
        {
            this.ngayLap = ngayLap;
            this.ghiChu = ghiChu;
            this.maDoiTuong = maDoiTuong;
            this.diaChi = diaChi;
            this.tenDoiTuong = tenDoiTuong;
            this.phatSinhCo = phatSinhCo;
            this.phatSinhNo = phatSinhNo;
            this.truongNgam = truongNgam;
        }
        public CongNo(string ngayLap, string maDoiTuong, string tenDoiTuong, string diaChi, string duDauKy, string phatSinhNo, string phatSinhCo, string duCuoiKy, string ghiChu, string truongNgam)
        {
            this.ngayLap = ngayLap;
            this.ghiChu = ghiChu;
            this.maDoiTuong = maDoiTuong;
            this.diaChi = diaChi;
            this.tenDoiTuong = tenDoiTuong;
            this.duDauKy = duDauKy;
            this.phatSinhCo = phatSinhCo;
            this.phatSinhNo = phatSinhNo;
            this.duCuoiKy = duCuoiKy;
            this.truongNgam = truongNgam;
        }
        public CongNo(string ngayLap, string maDoiTuong, string tenDoiTuong, string diaChi, string duDauKy, string phatSinhNo, string phatSinhCo, string duCuoiKy, string ghiChu, string truongNgam, string ton)
        {
            this.ngayLap = ngayLap;
            this.ghiChu = ghiChu;
            this.maDoiTuong = maDoiTuong;
            this.diaChi = diaChi;
            this.tenDoiTuong = tenDoiTuong;
            this.duDauKy = duDauKy;
            this.phatSinhCo = phatSinhCo;
            this.phatSinhNo = phatSinhNo;
            this.duCuoiKy = duCuoiKy;
            this.truongNgam = truongNgam;
            this.ton = ton;
        }
        public CongNo(string ngayLap, string maDoiTuong, string tenDoiTuong, string diaChi, string duDauKy, string phatSinhNo, string phatSinhCo, string duCuoiKy, string ghiChu, string truongNgam,string ton,string maTruongNgam)
        {
            this.ngayLap = ngayLap;
            this.ghiChu = ghiChu;
            this.maDoiTuong = maDoiTuong;
            this.diaChi = diaChi;
            this.tenDoiTuong = tenDoiTuong;
            this.duDauKy = duDauKy;
            this.phatSinhCo = phatSinhCo;
            this.phatSinhNo = phatSinhNo;
            this.duCuoiKy = duCuoiKy;
            this.truongNgam = truongNgam;
            this.ton = ton;
            this.maTruongNgam = maTruongNgam;
        }
    }
}
