using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class DiemThuongKhachHang
    {
        public DiemThuongKhachHang() { }
        public DiemThuongKhachHang(string thaoTac) { this.thaoTac = thaoTac; }
        public DiemThuongKhachHang(string MaDiemThuongKhachHang, string MaKhachHang, string TenKhachHang, int TongDiem, int DiemDaDung, int DiemConLai, string GhiChu, bool Deleted) 
        {
            this.maDiemThuongKhachHang = MaDiemThuongKhachHang;
            this.maKhachHang = MaKhachHang;
            this.tenKhachHang = TenKhachHang;
            this.tongDiem = TongDiem;
            this.diemDaDung = DiemDaDung;
            this.diemConLai = DiemConLai;
            this.ghiChu = GhiChu;
            this.deleted = Deleted;
        }

        string thaoTac = "";

        public string ThaoTac
        {
            get { return thaoTac; }
            set { thaoTac = value; }
        }

        string maDiemThuongKhachHang = "";

        public string MaDiemThuongKhachHang
        {
            get { return maDiemThuongKhachHang; }
            set { maDiemThuongKhachHang = value; }
        }
        string maKhachHang = "";

        public string MaKhachHang
        {
            get { return maKhachHang; }
            set { maKhachHang = value; }
        }
        string tenKhachHang = "";

        public string TenKhachHang
        {
            get { return tenKhachHang; }
            set { tenKhachHang = value; }
        }
        int tongDiem = 0;

        public int TongDiem
        {
            get { return tongDiem; }
            set { tongDiem = value; }
        }
        int diemDaDung = 0;

        public int DiemDaDung
        {
            get { return diemDaDung; }
            set { diemDaDung = value; }
        }
        int diemConLai = 0;

        public int DiemConLai
        {
            get { return diemConLai; }
            set { diemConLai = value; }
        }
        string ghiChu = "";

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        bool deleted = false;

        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
