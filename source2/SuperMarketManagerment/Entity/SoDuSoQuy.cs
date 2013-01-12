using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class SoDuSoQuy
    {
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private int soDuSoQuyID;

        public int SoDuSoQuyID
        {
            get { return soDuSoQuyID; }
            set { soDuSoQuyID = value; }
        }
        private string maSoDuSoQuy;

        public string MaSoDuSoQuy
        {
            get { return maSoDuSoQuy; }
            set { maSoDuSoQuy = value; }
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

        private Boolean trangThai;

        public Boolean TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
        public SoDuSoQuy() { }
        public SoDuSoQuy(string hanhDong)
        {
            this.hanhDong = hanhDong;
        }
        public SoDuSoQuy(string hanhDong,int soDuSoQuyID, string maSoDuSoQuy,DateTime ngayKetChuyen,string soDuCuoiKy)
        {
            this.hanhDong = hanhDong;
            this.soDuSoQuyID = soDuSoQuyID;
            this.maSoDuSoQuy = maSoDuSoQuy;
            this.ngayKetChuyen = ngayKetChuyen;
            this.SoDuDauKy = soDuCuoiKy;
            this.soDuCuoiKy = "0";
        }
        public SoDuSoQuy(string hanhDong, string maSoDuSoQuy)
        {
            this.hanhDong = hanhDong;
            this.maSoDuSoQuy = maSoDuSoQuy;
        }
        public SoDuSoQuy(string hanhDong, string soDuDauKy,string soDuCuoiKy)
        {
            this.hanhDong = hanhDong;

            this.soDuDauKy = soDuDauKy;
            this.soDuCuoiKy = soDuCuoiKy;
        }
        public SoDuSoQuy(string hanhDong, string maSoDuSoQuy, string soDuDauKy, DateTime ngayKetChuyen, string soDuCuoiKy,Boolean trangThai)
        {
            this.hanhDong = hanhDong;
            this.maSoDuSoQuy = maSoDuSoQuy;
            this.soDuDauKy = soDuDauKy;
            this.ngayKetChuyen = ngayKetChuyen;
            this.soDuCuoiKy = soDuCuoiKy;
            this.trangThai = trangThai;
        }
    }
}
