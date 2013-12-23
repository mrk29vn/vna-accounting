using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class SoDuCongNo
    {
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private int soDuCongNoID;

        public int SoDuCongNoID
        {
            get { return soDuCongNoID; }
            set { soDuCongNoID = value; }
        }
        private string maSoDuCongNo;

        public string MaSoDuCongNo
        {
            get { return maSoDuCongNo; }
            set { maSoDuCongNo = value; }
        }
        private string maDoiTuong;

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
        private string soDuDauKy;

        public string SoDuDauKy
        {
            get { return soDuDauKy; }
            set { soDuDauKy = value; }
        }
        private DateTime ngayKetChuyen;

        public DateTime NgayKetChuyen
        {
            get { return ngayKetChuyen; }
            set { ngayKetChuyen = value; }
        }
        private string soDuCuoiKy;

        public string SoDuCuoiKy
        {
            get { return soDuCuoiKy; }
            set { soDuCuoiKy = value; }
        }

        private Boolean loaiDoiTuong;

        public Boolean LoaiDoiTuong
        {
            get { return loaiDoiTuong; }
            set { loaiDoiTuong = value; }
        }
        private Boolean trangThai;

        public Boolean TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

        public SoDuCongNo() { }
        public SoDuCongNo(string hanhDong) 
        {
            this.hanhDong = hanhDong;
        }
        public SoDuCongNo(string hanhDong,string maSoDuCongNo)
        {
            this.hanhDong = hanhDong;
            this.maSoDuCongNo = maSoDuCongNo;
        }
        public SoDuCongNo(string hanhDong, string maSoDuCongNo,string soDuCuoiKy,Boolean loaiDoiTuong)
        {
            this.hanhDong = hanhDong;
            this.maSoDuCongNo = maSoDuCongNo;
            this.soDuCuoiKy = soDuCuoiKy;
            this.loaiDoiTuong = loaiDoiTuong;
        }
        public SoDuCongNo(string hanhDong,string maSoDuCongNo, string maDoiTuong, string tenDoiTuong, string diaChi, string soDuCuoiKy,DateTime ngayKetChuyen, Boolean loaiDoiTuong)
        {
            this.hanhDong = hanhDong;
            this.maSoDuCongNo = maSoDuCongNo;
            this.maDoiTuong = maDoiTuong;
            this.tenDoiTuong = tenDoiTuong;
            this.diaChi = diaChi;
            this.soDuCuoiKy = soDuCuoiKy;
            this.ngayKetChuyen = ngayKetChuyen;
            this.loaiDoiTuong = loaiDoiTuong;
        }
        public SoDuCongNo(string hanhDong, int soDuCongNoID,string maSoDuCongNo, string maDoiTuong, string tenDoiTuong, 
            string diaChi, string soDuDauKy, DateTime ngayKetChuyen, string soDuCuoiKy, Boolean loaiDoiTuong, Boolean trangThai)
        {
            this.hanhDong = hanhDong;
            this.soDuCongNoID = soDuCongNoID;
            this.maSoDuCongNo = maSoDuCongNo;
            this.maDoiTuong = maDoiTuong;
            this.maDoiTuong = maDoiTuong;
            this.tenDoiTuong = tenDoiTuong;
            this.diaChi = diaChi;
            this.soDuDauKy = soDuDauKy;
            this.ngayKetChuyen = ngayKetChuyen;
            this.soDuCuoiKy = soDuCuoiKy;
            this.loaiDoiTuong = loaiDoiTuong;
            this.trangThai = trangThai;
        }
        public SoDuCongNo(string maSoDuCongNo,string maDoiTuong, string tenDoiTuong,
            string diaChi, string soDuDauKy, DateTime ngayKetChuyen, string soDuCuoiKy, Boolean loaiDoiTuong, Boolean trangThai)
        {
            this.maSoDuCongNo = maSoDuCongNo;
            this.maDoiTuong = maDoiTuong;
            this.maDoiTuong = maDoiTuong;
            this.tenDoiTuong = tenDoiTuong;
            this.diaChi = diaChi;
            this.soDuDauKy = soDuDauKy;
            this.ngayKetChuyen = ngayKetChuyen;
            this.soDuCuoiKy = soDuCuoiKy;
            this.loaiDoiTuong = loaiDoiTuong;
            this.trangThai = trangThai;
        }
        public SoDuCongNo(string hanhDong,string maDoiTuong, string tenDoiTuong,
            string diaChi, string soDuDauKy)
        {
            this.hanhDong = hanhDong;
            this.maDoiTuong = maDoiTuong;
            this.maDoiTuong = maDoiTuong;
            this.tenDoiTuong = tenDoiTuong;
            this.diaChi = diaChi;
            this.soDuDauKy = soDuDauKy;
        }
        public SoDuCongNo(string hanhDong,string maSoDuCongNo, string maDoiTuong, string tenDoiTuong,
            string diaChi, string soDuDauKy)
        {
            this.hanhDong = hanhDong;
            this.maSoDuCongNo = maSoDuCongNo;
            this.maDoiTuong = maDoiTuong;
            this.maDoiTuong = maDoiTuong;
            this.tenDoiTuong = tenDoiTuong;
            this.diaChi = diaChi;
            this.soDuDauKy = soDuDauKy;
        }
    }
}
