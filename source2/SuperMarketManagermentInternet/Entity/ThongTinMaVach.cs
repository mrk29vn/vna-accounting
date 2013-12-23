using System;

namespace Entities
{
    [Serializable]
    public class ThongTinMaVach
    {
        public bool ChonIn { get; set; }
        public string HanhDong { get; set; }
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public string GiaNhap { get; set; }
        public string GiaBanBuon { get; set; }
        public string GiaBanLe { get; set; }
        public string GhiChu { get; set; }

        public ThongTinMaVach()
        {
            HanhDong = "";
            MaHangHoa = "";
            TenHangHoa = "";
            GiaNhap = "";
            GiaBanBuon = "";
            GiaBanLe = "";
            GhiChu = "";
        }
        public ThongTinMaVach(string hanhDong) { this.HanhDong = hanhDong; }
        public ThongTinMaVach(Boolean chonIn, string hanhDong, string maHangHoa, string tenHangHoa, string giaNhap, string giaBanBuon, string giaBanLe, string ghiChu)
        {
            this.ChonIn = chonIn;
            this.HanhDong = hanhDong;
            this.MaHangHoa = maHangHoa;
            this.TenHangHoa = tenHangHoa;
            this.GiaNhap = giaNhap;
            this.GiaBanBuon = giaBanBuon;
            this.GiaBanLe = giaBanLe;
            this.GhiChu = ghiChu;
        }
    }
}














