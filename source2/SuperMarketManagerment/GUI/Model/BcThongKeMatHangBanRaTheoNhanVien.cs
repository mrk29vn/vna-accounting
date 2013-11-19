using System;

namespace GUI.Model
{
    [Serializable]
    public class BcThongKeMatHangBanRaTheoNhanVien
    {
        public string MaHDBanHang { get; set; }
        public DateTime NgayBan { get; set; }
        public string MaKho { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public double SoLuong { get; set; }
        public double DonGia { get; set; }
        public double Thue { get; set; }
        public double PhanTramChietKhau { get; set; }
    }

    [Serializable]
    public class BcThongKeMatHangBanRaTheoNhanVienKhtl
    {
        public string MaHoaDonMuaHang { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MaKho { get; set; }
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public double SoLuong { get; set; }
        public double DonGia { get; set; }
        public double Thue { get; set; }
        public double PhanTramChietKhau { get; set; }
    }
}
