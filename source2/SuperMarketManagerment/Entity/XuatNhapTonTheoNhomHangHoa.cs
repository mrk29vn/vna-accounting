using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class XuatNhapTonTheoNhomHangHoa
    {
        private string maHangHoa;
        private string tenHangHoa;
        private int dauKy;
        private int tongNhap;
        private int nhapKho;
        private int khachTra;
        private int tongXuat;
        private int banBuon;
        private int banLe;
        private int traNCC;
        private int cuoiKy;
        private string ngayNhap;
        public string MaHangHoa
        {
            get { return maHangHoa; }
            set { maHangHoa = value; }
        }
        public string TenHangHoa
        {
            get { return tenHangHoa; }
            set { tenHangHoa = value; }
        }
        public int DauKy
        {
            get { return dauKy; }
            set { dauKy = value; }
        }
        public int TongNhap
        {
            get { return tongNhap; }
            set { tongNhap = value; }
        }
        public int NhapKho
        {
            get { return nhapKho; }
            set { nhapKho = value; }
        }
        public int KhachTra
        {
            get { return khachTra; }
            set { khachTra = value; }
        }
        public int TongXuat
        {
            get { return tongXuat; }
            set { tongXuat = value; }
        }
        public int BanBuon
        {
            get { return banBuon; }
            set { banBuon = value; }
        }
        public int BanLe
        {
            get { return banLe; }
            set { banLe = value; }
        }
        public int TraNCC
        {
            get { return traNCC; }
            set { traNCC = value; }
        }
        public int CuoiKy
        {
            get { return cuoiKy; }
            set { cuoiKy = value; }
        }
        public string NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }
        public XuatNhapTonTheoNhomHangHoa() { }
        public XuatNhapTonTheoNhomHangHoa(string maHangHoa, string tenHangHoa, int dauKy, int tongNhap, int nhapKho, int khachTra, int tongXuat, int banBuon, int banLe, int traNCC, int cuoiKy, string ngayNhap) 
        { 
            this.maHangHoa = maHangHoa;
            this.tenHangHoa = tenHangHoa;
            this.dauKy = dauKy;
            this.tongNhap = tongNhap;
            this.nhapKho = nhapKho;
            this.khachTra = khachTra;
            this.tongXuat = tongXuat;
            this.banBuon = banBuon;
            this.banLe = banLe;
            this.traNCC = traNCC;
            this.cuoiKy = cuoiKy;
            this.ngayNhap = ngayNhap;
        }
    }
}
