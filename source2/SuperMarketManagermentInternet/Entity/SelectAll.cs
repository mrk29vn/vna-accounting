using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    [Serializable]
    public class SelectAll
    {
        Entities.HangHoa[] hanghoa;
        public Entities.HangHoa[] HangHoa
        {
            get { return hanghoa; }
            set { hanghoa = value; }
        }
        Entities.NhomHang[] nhomhang;
        public Entities.NhomHang[] NhomHang
        {
            get { return nhomhang; }
            set { nhomhang = value; }
        }
        Entities.KhoHang[] khohang;
        public Entities.KhoHang[] KhoHang
        {
            get { return khohang; }
            set { khohang = value; }
        }
        Entities.PhieuXuatHuy[] phieuxuathuy;
        public Entities.PhieuXuatHuy[] PhieuXuatHuy
        {
            get { return phieuxuathuy; }
            set { phieuxuathuy = value; }
        }
        Entities.ChiTietXuatHuy[] chitietxuathuy;
        public Entities.ChiTietXuatHuy[] ChiTietXuatHuy
        {
            get { return chitietxuathuy; }
            set { chitietxuathuy = value; }
        }
        Entities.ChiTietTraLaiNhaCungCap[] chitiettralaincc;
        public Entities.ChiTietTraLaiNhaCungCap[] ChiTietTraLaiNhaCungCap
        {
            get { return chitiettralaincc; }
            set { chitiettralaincc = value; }
        }
        Entities.ChiTietHoaDonNhap[] chitiethoadonnhap;
        public Entities.ChiTietHoaDonNhap[] ChiTietHoaDonNhap
        {
            get { return chitiethoadonnhap; }
            set { chitiethoadonnhap = value; }
        }
        Entities.ChiTietKhachHangTraLai[] chitietkhachhangtralai;
        public Entities.ChiTietKhachHangTraLai[] ChiTietKhachHangTraLai
        {
            get { return chitietkhachhangtralai; }
            set { chitietkhachhangtralai = value; }
        }
        Entities.PhieuDieuChuyenKhoNoiBo[] phieudieuchuyenkhonoibo;
        public Entities.PhieuDieuChuyenKhoNoiBo[] PhieuDieuChuyenKhoNoiBo
        {
            get { return phieudieuchuyenkhonoibo; }
            set { phieudieuchuyenkhonoibo = value; }
        }
        Entities.ChiTietPhieuDieuChuyenKho[] chitietphieudieuchuyenkho;
        public Entities.ChiTietPhieuDieuChuyenKho[] ChiTietPhieuDieuChuyenKho
        {
            get { return chitietphieudieuchuyenkho; }
            set { chitietphieudieuchuyenkho = value; }
        }
        Entities.PhieuThu[] phieuthu;
        public Entities.PhieuThu[] PhieuThu
        {
            get { return phieuthu; }
            set { phieuthu = value; }
        }
        Entities.NhaCungCap[] nhacungcap;
        public Entities.NhaCungCap[] NhaCungCap
        {
            get { return nhacungcap; }
            set { nhacungcap = value; }
        }
        Entities.TraLaiNCC[] tralaincc;
        public Entities.TraLaiNCC[] TraLaiNCC
        {
            get { return tralaincc; }
            set { tralaincc = value; }
        }
        Entities.PhieuTTNCC[] phieuttncc;
        public Entities.PhieuTTNCC[] PhieuTTNCC
        {
            get { return phieuttncc; }
            set { phieuttncc = value; }
        }
        Entities.ChiTietPhieuTTNCC[] chitietphieuttncc;
        public Entities.ChiTietPhieuTTNCC[] ChiTietPhieuTTNCC
        {
            get { return chitietphieuttncc; }
            set { chitietphieuttncc = value; }
        }
        Entities.HoaDonNhap[] hoadonnhap;
        public Entities.HoaDonNhap[] HoaDonNhap
        {
            get { return hoadonnhap; }
            set { hoadonnhap = value; }
        }
        Entities.HDBanHang[] hDBanHang;
        public Entities.HDBanHang[] HDBanHang
        {
            get { return hDBanHang; }
            set { hDBanHang = value; }
        }
        Entities.ChiTietHDBanHang[] chiTietHDBanHang;
        public Entities.ChiTietHDBanHang[] ChiTietHDBanHang
        {
            get { return chiTietHDBanHang; }
            set { chiTietHDBanHang = value; }
        }
        Entities.Thue[] thue;
        public Entities.Thue[] Thue
        {
            get { return thue; }
            set { thue = value; }
        }
        Entities.HangHoa[] hangHoaTheoKho;
        public Entities.HangHoa[] HangHoaTheoKho
        {
            get { return hangHoaTheoKho; }
            set { hangHoaTheoKho = value; }
        }
        Entities.SoDuCongNo[] soDuCongNo;
        public Entities.SoDuCongNo[] SoDuCongNo
        {
            get { return soDuCongNo; }
            set { soDuCongNo = value; }
        }
        Entities.KhachHang[] khachHang;
        public Entities.KhachHang[] KhachHang
        {
            get { return khachHang; }
            set { khachHang = value; }
        }
        Entities.KhachHangTraLai[] khachHangTraLai;
        public Entities.KhachHangTraLai[] KhachHangTraLai
        {
            get { return khachHangTraLai; }
            set { khachHangTraLai = value; }
        }
        Entities.PhieuTTCuaKH[] phieuTTCuaKh;
        public Entities.PhieuTTCuaKH[] PhieuTTCuaKH
        {
            get { return phieuTTCuaKh; }
            set { phieuTTCuaKh = value; }
        }
        Entities.ChiTietPhieuTTCuaKH[] chiTietPhieuTTCuaKH;
        public Entities.ChiTietPhieuTTCuaKH[] ChiTietPhieuTTCuaKH
        {
            get { return chiTietPhieuTTCuaKH; }
            set { chiTietPhieuTTCuaKH = value; }
        }
        Entities.GoiHang[] goihang;
        public Entities.GoiHang[] GoiHang
        {
            get { return goihang; }
            set { goihang = value; }
        }
        Entities.ChiTietGoiHang[] chitietgoihang;
        public Entities.ChiTietGoiHang[] ChiTietGoiHang
        {
            get { return chitietgoihang; }
            set { chitietgoihang = value; }
        }
        Entities.QuyDoiDonViTinh[] quydoidonvitinh;
        public Entities.QuyDoiDonViTinh[] QuyDoiDonViTinh
        {
            get { return quydoidonvitinh; }
            set { quydoidonvitinh = value; }
        }
        Entities.SoDuSoQuy[] sodusoquy;
        public Entities.SoDuSoQuy[] SoDuSoQuy
        {
            get { return sodusoquy; }
            set { sodusoquy = value; }
        }
        Entities.SoDuKho[] sodukho;
        public Entities.SoDuKho[] SoDuKho
        {
            get { return sodukho; }
            set { sodukho = value; }
        }
        public SelectAll()
        {
        }
    }
}
