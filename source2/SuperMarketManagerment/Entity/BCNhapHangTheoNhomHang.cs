using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class BCNhapHangTheoNhomHang
    {
        public BCNhapHangTheoNhomHang() { }

        List<HoaDonNhap> hoaDonNhap = new List<HoaDonNhap>();

        public List<HoaDonNhap> HoaDonNhap
        {
            get { return hoaDonNhap; }
            set { hoaDonNhap = value; }
        }
        List<ChiTietHoaDonNhap> chiTietHoaDonNhap = new List<ChiTietHoaDonNhap>();

        public List<ChiTietHoaDonNhap> ChiTietHoaDonNhap
        {
            get { return chiTietHoaDonNhap; }
            set { chiTietHoaDonNhap = value; }
        }
        List<KhachHangTraLai> khachHangTraLai = new List<KhachHangTraLai>();

        public List<KhachHangTraLai> KhachHangTraLai
        {
            get { return khachHangTraLai; }
            set { khachHangTraLai = value; }
        }
        List<ChiTietKhachHangTraLai> chiTietKhachHangTraLai = new List<ChiTietKhachHangTraLai>();

        public List<ChiTietKhachHangTraLai> ChiTietKhachHangTraLai
        {
            get { return chiTietKhachHangTraLai; }
            set { chiTietKhachHangTraLai = value; }
        }
        List<HangHoa> hangHoa = new List<HangHoa>();

        public List<HangHoa> HangHoa
        {
            get { return hangHoa; }
            set { hangHoa = value; }
        }

        List<NhomHang> nhomHang = new List<NhomHang>();

        public List<NhomHang> NhomHang
        {
            get { return nhomHang; }
            set { nhomHang = value; }
        }

        List<GoiHang> goiHang = new List<GoiHang>();

        public List<GoiHang> GoiHang
        {
            get { return goiHang; }
            set { goiHang = value; }
        }
        List<ChiTietGoiHang> chiTietGoiHang = new List<ChiTietGoiHang>();

        public List<ChiTietGoiHang> ChiTietGoiHang
        {
            get { return chiTietGoiHang; }
            set { chiTietGoiHang = value; }
        }
    }
}
