using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class TinhDiemDoanhThu
    {
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private string maKhachHang;

        public string MaKhachHang
        {
            get { return maKhachHang; }
            set { maKhachHang = value; }
        }
        private string tenKhachHang;

        public string TenKhachHang
        {
            get { return tenKhachHang; }
            set { tenKhachHang = value; }
        }
        private string diaChi;

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        private string doanhThu;

        public string DoanhThu
        {
            get { return doanhThu; }
            set { doanhThu = value; }
        }
        private string tinhDiem;

        public string TinhDiem
        {
            get { return tinhDiem; }
            set { tinhDiem = value; }
        }
        private string diemDaDung;

        public string DiemDaDung
        {
            get { return diemDaDung; }
            set { diemDaDung = value; }
        }
        private string diemConLai;

        public string DiemConLai
        {
            get { return diemConLai; }
            set { diemConLai = value; }
        }
        public TinhDiemDoanhThu()
        {
        }
        public TinhDiemDoanhThu(string hanhDong, string maKhachHang, string tenKhachHang, string diaChi, string doanhThu, string tinhDiem,string diemDaDung,string diemConLai)
        {
            this.hanhDong = hanhDong;
            this.maKhachHang = maKhachHang;
            this.tenKhachHang = tenKhachHang;
            this.diaChi = diaChi;
            this.doanhThu = doanhThu;
            this.tinhDiem = tinhDiem;
            this.diemDaDung = diemDaDung;
            this.diemConLai = diemConLai;
        }
    }
}
