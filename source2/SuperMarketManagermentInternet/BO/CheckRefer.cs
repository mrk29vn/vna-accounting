using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizLogic
{
    public class CheckRefer
    {
        #region Chi Tiết Kho Hàng
        Entities.ChiTietKhoHangTheoHoaHonNhap[] chitietkhohang;
        public Entities.ChiTietKhoHangTheoHoaHonNhap[] ChiTietKhoHang()
        {
            try
            {
                chitietkhohang = new Entities.ChiTietKhoHangTheoHoaHonNhap[1];
                chitietkhohang = new BizLogic.ChiTietKhoHangTheoHoaHonNhap().Select();
                if (chitietkhohang == null)
                {
                    chitietkhohang = new Entities.ChiTietKhoHangTheoHoaHonNhap[0];
                    return chitietkhohang;
                }
                return chitietkhohang;
            }
            catch
            {
                chitietkhohang = new Entities.ChiTietKhoHangTheoHoaHonNhap[0];
                return chitietkhohang;
            }
        }
        #endregion
        #region Chi Tiết Phiếu Điều Chuyển Kho
        Entities.ChiTietPhieuDieuChuyenKho[] chitietdieuchuyen;
        public Entities.ChiTietPhieuDieuChuyenKho[] ChiTietPhieuDieuChuyenKho()
        {
            try
            {
                chitietdieuchuyen = new Entities.ChiTietPhieuDieuChuyenKho[1];
                chitietdieuchuyen = new BizLogic.ChiTietPhieuDieuChuyenKho().Select();
                if (chitietdieuchuyen == null)
                {
                    chitietdieuchuyen = new Entities.ChiTietPhieuDieuChuyenKho[0];
                    return chitietdieuchuyen;
                }
                return chitietdieuchuyen;
            }
            catch
            {
                chitietdieuchuyen = new Entities.ChiTietPhieuDieuChuyenKho[0];
                return chitietdieuchuyen;
            }
        }
        #endregion
        #region Chi Tiết Hóa Đơn Bán Hàng
        Entities.ChiTietHDBanHang[] chitiethdbanhang;
        public Entities.ChiTietHDBanHang[] ChiTietHDBanHang()
        {
            try
            {
                chitiethdbanhang = new Entities.ChiTietHDBanHang[1];
                chitiethdbanhang = new BizLogic.ChiTietHDBanHang().Select();
                if (chitiethdbanhang == null)
                {
                    chitiethdbanhang = new Entities.ChiTietHDBanHang[0];
                    return chitiethdbanhang;
                }
                return chitiethdbanhang;
            }
            catch
            {
                chitiethdbanhang = new Entities.ChiTietHDBanHang[0];
                return chitiethdbanhang;
            }
        }
        #endregion
        #region Chi Tiết Hóa Đơn Nhập
        Entities.ChiTietHoaDonNhap[] chitietnhapmua;
        public Entities.ChiTietHoaDonNhap[] ChiTietHoaDonNhap()
        {
            try
            {
                chitietnhapmua = new Entities.ChiTietHoaDonNhap[1];
                chitietnhapmua = new BizLogic.ChiTietHoaDonNhap().Select();
                if (chitietnhapmua == null)
                {
                    chitietnhapmua = new Entities.ChiTietHoaDonNhap[0];
                    return chitietnhapmua;
                }
                return chitietnhapmua;
            }
            catch
            {
                chitietnhapmua = new Entities.ChiTietHoaDonNhap[0];
                return chitietnhapmua;
            }
        }
        #endregion
        #region Chi Tiết Khách Hàng Trả Lại
        Entities.ChiTietKhachHangTraLai[] chitietkhtl;
        public Entities.ChiTietKhachHangTraLai[] ChiTietKhachHangTraLai()
        {
            try
            {
                chitietkhtl = new Entities.ChiTietKhachHangTraLai[1];
                chitietkhtl = new BizLogic.ChiTietKhachHangTraLai().Select();
                if (chitietkhtl == null)
                {
                    chitietkhtl = new Entities.ChiTietKhachHangTraLai[0];
                    return chitietkhtl;
                }
                return chitietkhtl;
            }
            catch
            {
                chitietkhtl = new Entities.ChiTietKhachHangTraLai[0];
                return chitietkhtl;
            }
        }
        #endregion
        #region Chi Tiết Trả Lại Nhà Cung Cấp
        Entities.ChiTietTraLaiNhaCungCap[] chitiettlncc;
        public Entities.ChiTietTraLaiNhaCungCap[] ChiTietTraLaiNCC()
        {
            try
            {
                chitiettlncc = new Entities.ChiTietTraLaiNhaCungCap[1];
                chitiettlncc = new BizLogic.ChiTietTraLaiNhaCungCap().Select();
                if (chitiettlncc == null)
                {
                    chitiettlncc = new Entities.ChiTietTraLaiNhaCungCap[0];
                    return chitiettlncc;
                }
                return chitiettlncc;
            }
            catch
            {
                chitiettlncc = new Entities.ChiTietTraLaiNhaCungCap[0];
                return chitiettlncc;
            }
        }
        #endregion
        #region Chi Tiết Kiểm Kê Kho
        Entities.ChiTietKiemKeKho[] chitietkiemkekho;
        public void ChiTietKiemKeKho()
        {
            try
            {
                chitietkiemkekho = new Entities.ChiTietKiemKeKho[1];
                chitietkiemkekho = new BizLogic.ChiTietKiemKeKho().Select();
                if (chitietkiemkekho == null)
                    chitietkiemkekho = new Entities.ChiTietKiemKeKho[0];
            }
            catch
            {
            }
        }
        #endregion
        #region Chi Tiết Đơn Đặt Hàng
        Entities.ChiTietDonDatHang[] chitietdonhang;
        public Entities.ChiTietDonDatHang[] ChiTietDonDatHang()
        {
            try
            {
                chitietdonhang = new Entities.ChiTietDonDatHang[1];
                chitietdonhang = new BizLogic.ChiTietDonDatHang().Select();
                if (chitietdonhang == null)
                {
                    chitietdonhang = new Entities.ChiTietDonDatHang[0];
                    return chitietdonhang;
                }
                return chitietdonhang;
            }
            catch
            {
                return new Entities.ChiTietDonDatHang[0];
            }
        }
        #endregion
        #region Cập Nhật Giá
        Entities.CapNhatGia[] capnhatgia;
        public void CapNhatGia()
        {
            try
            {
                capnhatgia = new Entities.CapNhatGia[1];
                capnhatgia = new BizLogic.CapNhatGia().Select();
                if (capnhatgia == null)
                    capnhatgia = new Entities.CapNhatGia[0];
            }
            catch
            {
            }
        }
        #endregion
        #region Cập Nhật Giá Khách Hàng
        Entities.CapNhatGiaKhachHang[] capnhatgiakh;
        public void CapNhatGiaKhachHang()
        {
            try
            {
                capnhatgiakh = new Entities.CapNhatGiaKhachHang[1];
                capnhatgiakh = new BizLogic.CapNhatGiaKH().Select();
                if (capnhatgiakh == null)
                    capnhatgiakh = new Entities.CapNhatGiaKhachHang[0];
            }
            catch
            {
            }
        }
        #endregion
        #region Chi Tiết Phiếu Xuất Hủy
        Entities.ChiTietXuatHuy[] chitietpxh;
        public Entities.ChiTietXuatHuy[] ChiTietXuatHuy()
        {
            try
            {
                chitietpxh = new Entities.ChiTietXuatHuy[1];
                chitietpxh = new BizLogic.ChiTietXuatHuy().Select();
                if (chitietpxh == null)
                {
                    chitietpxh = new Entities.ChiTietXuatHuy[0];
                    return chitietpxh;
                }
                return chitietpxh;
            }
            catch
            {
                chitietpxh = new Entities.ChiTietXuatHuy[0];
                return chitietpxh;
            }
        }
        #endregion
        #region Tài Khoản Kế Toán
        Entities.TKKeToan[] tkketoan;
        public void TKKeToan()
        {
            try
            {
                tkketoan = new Entities.TKKeToan[1];
                tkketoan = new BizLogic.TKKeToan().Select();
                if (tkketoan == null)
                    tkketoan = new Entities.TKKeToan[0];
            }
            catch
            {
            }
        }
        #endregion
        #region Nhân Viên
        Entities.NhanVien[] nhanvien;
        public void NhanVien()
        {
            try
            {
                nhanvien = new Entities.NhanVien[1];
                nhanvien = new BizLogic.NhanVien().Select();
                if (nhanvien == null)
                    nhanvien = new Entities.NhanVien[0];
            }
            catch
            {
            }
        }
        #endregion
        #region Khoản Mục Thu chi
        Entities.KMThuChi[] kmthuchi;
        public void KMThuChi()
        {
            try
            {
                kmthuchi = new Entities.KMThuChi[1];
                kmthuchi = new BizLogic.KMThuChi().Select();
                if (kmthuchi == null)
                    kmthuchi = new Entities.KMThuChi[0];
            }
            catch
            {
            }
        }
        #endregion
        #region Phiêu Thu
        Entities.PhieuThu[] phieuthu;
        public Entities.PhieuThu[] PhieuThu()
        {
            try
            {
                phieuthu = new Entities.PhieuThu[1];
                phieuthu = new BizLogic.PhieuThu().Select();
                if (phieuthu == null)
                {
                    phieuthu = new Entities.PhieuThu[0];
                    return phieuthu;
                }
                return phieuthu;
            }
            catch
            {
                return new Entities.PhieuThu[0];
            }
        }
        #endregion
        #region Kho Hàng
        Entities.KhoHang[] khohang;
        public Entities.KhoHang[] KhoHang()
        {
            try
            {
                khohang = new Entities.KhoHang[1];
                khohang = new BizLogic.KhoHang().Select();
                if (khohang == null)
                {
                    khohang = new Entities.KhoHang[0];
                    return khohang;
                }
                return khohang;
            }
            catch
            {
                khohang = new Entities.KhoHang[0];
                return khohang;
            }
        }
        #endregion
        #region Phiêu Xuất Hủy
        Entities.PhieuXuatHuy[] phieuxuathuy;
        public Entities.PhieuXuatHuy[] PhieuXuatHuy()
        {
            try
            {
                phieuxuathuy = new Entities.PhieuXuatHuy[1];
                phieuxuathuy = new BizLogic.PhieuXuatHuy().Select();
                if (phieuxuathuy == null)
                {
                    phieuxuathuy = new Entities.PhieuXuatHuy[0];
                    return phieuxuathuy;
                }
                return phieuxuathuy;
            }
            catch
            {
                phieuxuathuy = new Entities.PhieuXuatHuy[0];
                return phieuxuathuy;
            }
        }
        #endregion
        #region Phiêu Điều Chuyển Kho
        Entities.PhieuDieuChuyenKhoNoiBo[] phieudieuchuyenkho;
        public Entities.PhieuDieuChuyenKhoNoiBo[] PhieuDieuChuyenKhoNoiBo()
        {
            try
            {
                phieudieuchuyenkho = new Entities.PhieuDieuChuyenKhoNoiBo[1];
                phieudieuchuyenkho = new BizLogic.PhieuDieuChuyenKhoNoiBo().Select();
                if (phieudieuchuyenkho == null)
                {
                    phieudieuchuyenkho = new Entities.PhieuDieuChuyenKhoNoiBo[0];
                    return phieudieuchuyenkho;
                }
                return phieudieuchuyenkho;
            }
            catch
            {
                phieudieuchuyenkho = new Entities.PhieuDieuChuyenKhoNoiBo[0];
                return phieudieuchuyenkho;
            }
        }
        #endregion
        #region Tài Khoản
        Entities.TaiKhoan[] taikhoan;
        public void TaiKhoan()
        {
            try
            {
                taikhoan = new Entities.TaiKhoan[1];
                taikhoan = new BizLogic.TaiKhoan().selectTaiKhoan();
                if (taikhoan == null)
                    taikhoan = new Entities.TaiKhoan[0];
            }
            catch
            {
            }
        }
        #endregion
        #region Loại Hàng Hóa
        Entities.LoaiHangHoa[] loaihanghoa;
        public Entities.LoaiHangHoa[] LoaiHangHoa()
        {
            try
            {
                loaihanghoa = new Entities.LoaiHangHoa[1];
                loaihanghoa = new BizLogic.LoaiHangHoa().Select();
                if (loaihanghoa == null)
                {
                    loaihanghoa = new Entities.LoaiHangHoa[0];
                    return loaihanghoa;
                }
                return loaihanghoa;
            }
            catch
            {
                loaihanghoa = new Entities.LoaiHangHoa[0];
                return loaihanghoa;
            }
        }
        #endregion
        #region Hàng Hóa
        Entities.HangHoa[] hanghoa;
        public Entities.HangHoa[] HangHoa()
        {
            try
            {
                hanghoa = new Entities.HangHoa[1];
                hanghoa = new BizLogic.HangHoa().Select();
                if (hanghoa == null)
                {
                    hanghoa = new Entities.HangHoa[0];
                    return hanghoa;
                }
                return hanghoa;
            }
            catch
            {
                hanghoa = new Entities.HangHoa[0];
                return hanghoa;
            }
        }
        #endregion
        #region Nhóm hàng
        Entities.NhomHang[] nhomhang;
        public Entities.NhomHang[] NhomHang()
        {
            try
            {
                nhomhang = new Entities.NhomHang[1];
                nhomhang = new BizLogic.NhomHang().Select();
                if (nhomhang == null)
                {
                    nhomhang = new Entities.NhomHang[0];
                    return nhomhang;
                }
                return nhomhang;
            }
            catch
            {
                nhomhang = new Entities.NhomHang[0];
                return nhomhang;
            }
        }
        #endregion
        #region Đơn Đặt Hàng
        Entities.DonDatHang[] dondathang;
        public Entities.DonDatHang[] DonDatHang()
        {
            try
            {
                dondathang = new Entities.DonDatHang[1];
                dondathang = new BizLogic.DonDatHang().Select();
                if (dondathang == null)
                {
                    dondathang = new Entities.DonDatHang[0];
                    return dondathang;
                }
                return dondathang;
            }
            catch
            {
                return new Entities.DonDatHang[0];
            }
        }
        #endregion
        #region Khách Hàng Trả Lại
        Entities.KhachHangTraLai[] khachhangtralai;
        public Entities.KhachHangTraLai[] KhachHangTraLai()
        {
            try
            {
                khachhangtralai = new Entities.KhachHangTraLai[1];
                khachhangtralai = new BizLogic.KhachHangTraLai().Select();
                if (khachhangtralai == null)
                {
                    khachhangtralai = new Entities.KhachHangTraLai[0];
                    return khachhangtralai;
                }
                return khachhangtralai;
            }
            catch
            {
                khachhangtralai = new Entities.KhachHangTraLai[0];
                return khachhangtralai;
            }
        }
        #endregion
        #region Trả Lại Nhà Cung Cấp
        Entities.TraLaiNCC[] tralaincc;
        public Entities.TraLaiNCC[] TraLaiNCC()
        {
            try
            {
                tralaincc = new Entities.TraLaiNCC[1];
                tralaincc = new BizLogic.TraLaiNhaCungCap().Select();
                if (tralaincc == null)
                {
                    tralaincc = new Entities.TraLaiNCC[0];
                    return tralaincc;
                }
                return tralaincc;
            }
            catch
            {

                tralaincc = new Entities.TraLaiNCC[0];
                return tralaincc;
            }
        }
        #endregion
        #region Hóa Đơn Nhập
        Entities.HoaDonNhap[] hoadonnhap;
        public Entities.HoaDonNhap[] HoaDonNhap()
        {
            try
            {
                hoadonnhap = new Entities.HoaDonNhap[1];
                hoadonnhap = new BizLogic.HoaDonNhap().Select();
                if (hoadonnhap == null)
                {
                    hoadonnhap = new Entities.HoaDonNhap[0];
                    return hoadonnhap;
                }
                return hoadonnhap;
            }
            catch
            {
                hoadonnhap = new Entities.HoaDonNhap[0];
                return hoadonnhap;
            }
        }
        #endregion
        #region Kiểm Kê Kho
        Entities.KiemKeKho[] kiemkekho;
        public void KiemKeKho()
        {
            try
            {
                kiemkekho = new Entities.KiemKeKho[1];
                kiemkekho = new BizLogic.KiemKeKho().Select();
                if (kiemkekho == null)
                    kiemkekho = new Entities.KiemKeKho[0];
            }
            catch
            {
            }
        }
        #endregion
        #region Phiếu Thanh Toán Của Khách Hàng
        Entities.PhieuTTCuaKH[] phieuttcuakh;
        public Entities.PhieuTTCuaKH[] PhieuTTCuaKH()
        {
            try
            {
                phieuttcuakh = new Entities.PhieuTTCuaKH[1];
                phieuttcuakh = new BizLogic.PhieuTTCuaKH().Select();
                if (phieuttcuakh == null)
                {
                    phieuttcuakh = new Entities.PhieuTTCuaKH[0];
                    return phieuttcuakh;
                }
                return phieuttcuakh;
            }
            catch
            {
                phieuttcuakh = new Entities.PhieuTTCuaKH[0];
                return phieuttcuakh;
            }
        }
        #endregion
        #region Phiếu Thanh Toán Của Nhà Cung Cấp
        Entities.PhieuTTNCC[] phieuttcuancc;
        public Entities.PhieuTTNCC[] PhieuTTNCC()
        {
            try
            {
                phieuttcuancc = new Entities.PhieuTTNCC[1];
                phieuttcuancc = new BizLogic.PhieuTTNCC().Select();
                if (phieuttcuancc == null)
                {
                    phieuttcuancc = new Entities.PhieuTTNCC[0];
                    return phieuttcuancc;
                }
                return phieuttcuancc;
            }
            catch
            {
                phieuttcuancc = new Entities.PhieuTTNCC[0];
                return phieuttcuancc;
            }
        }
        #endregion
        #region Hóa Đơn Bán Hàng
        Entities.HDBanHang[] hdbanhang;
        public Entities.HDBanHang[] HDBanHang()
        {
            try
            {
                hdbanhang = new Entities.HDBanHang[1];
                hdbanhang = new BizLogic.HDBanHang().Select();
                if (hdbanhang == null)
                {
                    hdbanhang = new Entities.HDBanHang[0];
                    return hdbanhang;
                }
                return hdbanhang;
            }
            catch
            {
                hdbanhang = new Entities.HDBanHang[0];
                return hdbanhang;
            }
        }
        #endregion
        #region Số Dư Sổ Quỹ
        Entities.SoDuSoQuy[] sodusoquy;
        public Entities.SoDuSoQuy[] SoDuSoQuy()
        {
            try
            {
                sodusoquy = new Entities.SoDuSoQuy[1];
                sodusoquy = new BizLogic.SoQuy().Select();
                if (sodusoquy == null)
                {
                    sodusoquy = new Entities.SoDuSoQuy[0];
                    return sodusoquy;
                }
                return sodusoquy;
            }
            catch
            {
                return sodusoquy = new Entities.SoDuSoQuy[0];
            }

        }
        #endregion
        #region Thuê
        Entities.Thue[] thue;
        public Entities.Thue[] Thue()
        {
            try
            {
                thue = new Entities.Thue[1];
                thue = new BizLogic.Thue().Select();
                if (thue == null)
                {
                    thue = new Entities.Thue[0];
                    return thue;
                }
                return thue;
            }
            catch
            {
                return thue = new Entities.Thue[0];
            }

        }
        #endregion
        #region Số Dư Sổ Kho
        Entities.SoDuKho[] sodukho;
        public Entities.SoDuKho[] SoDuKho()
        {
            try
            {
                sodukho = new Entities.SoDuKho[1];
                sodukho = new BizLogic.SoDuKho().Select();
                if (sodukho == null)
                {
                    sodukho = new Entities.SoDuKho[0];
                    return sodukho;
                }
                return sodukho;
            }
            catch
            {
                return sodukho = new Entities.SoDuKho[0];
            }

        }
        #endregion
        #region Số Dư Công Nợ
        Entities.SoDuCongNo[] soducongno;
        public Entities.SoDuCongNo[] SoDuCongNo()
        {
            try
            {
                soducongno = new Entities.SoDuCongNo[1];
                soducongno = new BizLogic.CongNo().Select();
                if (soducongno == null)
                {
                    soducongno = new Entities.SoDuCongNo[0];
                    return soducongno;
                }
                return soducongno;
            }
            catch
            {
                return soducongno = new Entities.SoDuCongNo[0];
            }

        }
        #endregion
        #region Chi Tiết Phiếu Thanh Toán Của Khách Hàng
        Entities.ChiTietPhieuTTCuaKH[] chitietphieuttcuakh;
        public Entities.ChiTietPhieuTTCuaKH[] ChiTietPhieuTTCuaKH()
        {
            try
            {
                chitietphieuttcuakh = new Entities.ChiTietPhieuTTCuaKH[1];
                chitietphieuttcuakh = new BizLogic.ChiTietPhieuTTCuaKH().Select();
                if (chitietphieuttcuakh == null)
                {
                    chitietphieuttcuakh = new Entities.ChiTietPhieuTTCuaKH[0];
                    return chitietphieuttcuakh;
                }
                return chitietphieuttcuakh;
            }
            catch
            {
                return chitietphieuttcuakh = new Entities.ChiTietPhieuTTCuaKH[0];
            }

        }
        #endregion
        #region Chi Tiết Phiếu Thanh Toán Nhà Cung Cấp
        Entities.ChiTietPhieuTTNCC[] chitietphieuttncc;
        public Entities.ChiTietPhieuTTNCC[] ChiTietPhieuTTNCC()
        {
            try
            {
                chitietphieuttncc = new Entities.ChiTietPhieuTTNCC[1];
                chitietphieuttncc = new BizLogic.ChiTietPhieuTTNCC().Select();
                if (chitietphieuttncc == null)
                {
                    chitietphieuttncc = new Entities.ChiTietPhieuTTNCC[0];
                    return chitietphieuttncc;
                }
                return chitietphieuttncc;
            }
            catch
            {
                return chitietphieuttncc = new Entities.ChiTietPhieuTTNCC[0];
            }

        }
        #endregion
        #region gói hàng
        Entities.GoiHang[] goihang;
        public Entities.GoiHang[] GoiHang()
        {
            goihang = new BizLogic.GoiHang().Select();
            if (goihang == null)
                goihang = new Entities.GoiHang[0];
            return goihang;
        }
        #endregion
        #region chi tiết gói hàng
        Entities.ChiTietGoiHang[] chitietgoihang;
        public Entities.ChiTietGoiHang[] ChiTietGoiHang()
        {
            chitietgoihang = new BizLogic.ChiTietGoiHang().Select();
            if (chitietgoihang == null)
                chitietgoihang = new Entities.ChiTietGoiHang[0];
            return chitietgoihang;
        }
        #endregion
        #region Quy đổi đơn vị tính
        Entities.QuyDoiDonViTinh[] quydoidonvitinh;
        public Entities.QuyDoiDonViTinh[] QuyDoiDonViTinh()
        {
            quydoidonvitinh = new BizLogic.QuyDoiDonViTinh().Select();
            if (quydoidonvitinh == null)
                quydoidonvitinh = new Entities.QuyDoiDonViTinh[0];
            return quydoidonvitinh;
        }
        #endregion 

        /// <summary>
        ///  check reference
        /// </summary>
        /// <param name="cr"></param>
        /// <returns></returns>
        public bool CheckReferen(Entities.CheckRefer cr)
        {
            bool kt = true;
            try
            {
                switch (cr.TenTruong)
                {
                    #region gói hàng
                    case "GH":
                        {
                            // hàng hóa
                            HangHoa();
                            for (int i = 0; i < hanghoa.Length; i++)
                            {
                                if (hanghoa[i].MaHangHoa == cr.MaTruong)
                                    return false;
                            }
                            // chi tiết đơn đặt hàng
                            ChiTietDonDatHang();
                            for (int i = 0; i < chitietdonhang.Length; i++)
                            {
                                if (chitietdonhang[i].MaHangHoa == cr.MaTruong)
                                    return false;
                            }
                            // chi tiết hóa đơn bán hàng
                            ChiTietHDBanHang();
                            for (int i = 0; i < chitiethdbanhang.Length; i++)
                            {
                                if (chitiethdbanhang[i].MaHangHoa == cr.MaTruong)
                                    return false;
                            }
                            break;
                        }
                    #endregion
                    #region quy đổi đơn vị tính
                    case "QD":
                        {
                            // phiếu xuất hủy
                            PhieuXuatHuy();
                            for (int i = 0; i < phieuxuathuy.Length; i++)
                            {
                                if (phieuxuathuy[i].MaKho == cr.MaTruong)
                                    return false;
                            }
                            // trả lại nhà cung cấp
                            TraLaiNCC();
                            for (int i = 0; i < tralaincc.Length; i++)
                            {
                                if (tralaincc[i].MaKho == cr.MaTruong)
                                    return false;
                            }
                            // phiếu điều chuyển kho
                            PhieuDieuChuyenKhoNoiBo();
                            for (int i = 0; i < phieudieuchuyenkho.Length; i++)
                            {
                                if (phieudieuchuyenkho[i].TuKho == cr.MaTruong || phieudieuchuyenkho[i].DenKho == cr.MaTruong)
                                    return false;
                            }
                            // khách hàng trả lại
                            KhachHangTraLai();
                            for (int i = 0; i < khachhangtralai.Length; i++)
                            {
                                if (khachhangtralai[i].MaKho == cr.MaTruong)
                                    return false;
                            }
                            // hóa đơn nhập
                            HoaDonNhap();
                            for (int i = 0; i < hoadonnhap.Length; i++)
                            {
                                if (hoadonnhap[i].MaKho == cr.MaTruong)
                                    return false;
                            }
                            // hàng hóa
                            HangHoa();
                            for (int i = 0; i < hanghoa.Length; i++)
                            {
                                if (hanghoa[i].MaHangHoa == cr.MaTruong)
                                    return false;
                            }
                            // chi tiết đơn đặt hàng
                            ChiTietDonDatHang();
                            for (int i = 0; i < chitietdonhang.Length; i++)
                            {
                                if (chitietdonhang[i].MaHangHoa == cr.MaTruong)
                                    return false;
                            }
                            // chi tiết hóa đơn bán hàng
                            ChiTietHDBanHang();
                            for (int i = 0; i < chitiethdbanhang.Length; i++)
                            {
                                if (chitiethdbanhang[i].MaHangHoa == cr.MaTruong)
                                    return false;
                            }
                            break;
                        }
                    #endregion
                    case "PhongBan":
                        {
                            // nhân viên
                            NhanVien();
                            for (int i = 0; i < nhanvien.Length; i++)
                            {
                                if (nhanvien[i].MaPhongBan == cr.MaTruong)
                                    return false;
                            }
                            break;
                        }
                    case "KMThuChi":
                        {
                            // phiếu thu
                            PhieuThu();
                            for (int i = 0; i < phieuthu.Length; i++)
                            {
                                if (phieuthu[i].KhoanMuc == cr.MaTruong)
                                    return false;
                            }
                            break;
                        }
                    case "HangHoa":
                        {

                            // chi tiết kho hàng
                            ChiTietKhoHang();
                            for (int i = 0; i < chitietkhohang.Length; i++)
                            {
                                if (chitietkhohang[i].Mahanghoa == cr.MaTruong)
                                    return false;
                            }
                            // chi tiết đơn đặt hàng
                            ChiTietDonDatHang();
                            for (int i = 0; i < chitietdonhang.Length; i++)
                            {
                                if (chitietdonhang[i].MaHangHoa == cr.MaTruong)
                                    return false;
                            }
                            // chi tiết khách hàng trả lại
                            ChiTietKhachHangTraLai();
                            for (int i = 0; i < chitietkhtl.Length; i++)
                            {
                                if (chitietkhtl[i].MaHangHoa == cr.MaTruong)
                                    return false;
                            }
                            // chi tiết hóa đơn nhập
                            ChiTietHoaDonNhap();
                            for (int i = 0; i < chitietnhapmua.Length; i++)
                            {
                                if (chitietnhapmua[i].MaHangHoa == cr.MaTruong)
                                    return false;
                            }
                            // chi tiết hóa đơn bán hàng
                            ChiTietHDBanHang();
                            for (int i = 0; i < chitiethdbanhang.Length; i++)
                            {
                                if (chitiethdbanhang[i].MaHangHoa == cr.MaTruong)
                                    return false;
                            }
                            // chi tiết trả lại nhà cung cấp
                            ChiTietTraLaiNCC();
                            for (int i = 0; i < chitiettlncc.Length; i++)
                            {
                                if (chitiettlncc[i].MaHangHoa == cr.MaTruong)
                                    return false;
                            }
                            // chi tiết phiếu điều chuyển kho
                            ChiTietPhieuDieuChuyenKho();
                            for (int i = 0; i < chitietdieuchuyen.Length; i++)
                            {
                                if (chitietdieuchuyen[i].MaHangHoa == cr.MaTruong)
                                    return false;
                            }
                            // cập nhật giá hàng hóa
                            CapNhatGia();
                            for (int i = 0; i < capnhatgia.Length; i++)
                            {
                                if (capnhatgia[i].MaHangHoa == cr.MaTruong)
                                    return false;
                            }
                            // chi tiết kiểm kê kho
                            ChiTietKiemKeKho();
                            for (int i = 0; i < chitietkiemkekho.Length; i++)
                            {
                                if (chitietkiemkekho[i].MaHangHoa == cr.MaTruong)
                                    return false;
                            }
                            // chi tiết phiếu xuất hủy
                            ChiTietXuatHuy();
                            for (int i = 0; i < chitietpxh.Length; i++)
                            {
                                if (chitietpxh[i].MaHangHoa == cr.MaTruong)
                                    return false;
                            }
                            break;
                        }
                    case "KhachHang":
                        {
                            // cập nhật giá khách hàng
                            CapNhatGiaKhachHang();
                            for (int i = 0; i < capnhatgiakh.Length; i++)
                            {
                                if (capnhatgiakh[i].MaKhachHang == cr.MaTruong)
                                    return false;
                            }
                            // phiếu thanh toán của khách hàng
                            PhieuTTCuaKH();
                            for (int i = 0; i < phieuttcuakh.Length; i++)
                            {
                                if (phieuttcuakh[i].MaKhachHang == cr.MaTruong)
                                    return false;
                            }
                            // đơn đặt hàng
                            DonDatHang();
                            for (int i = 0; i < dondathang.Length; i++)
                            {
                                if (dondathang[i].Makhachhang == cr.MaTruong)
                                    return false;
                            }
                            // hóa đơn bán hàng
                            HDBanHang();
                            for (int i = 0; i < hdbanhang.Length; i++)
                            {
                                if (hdbanhang[i].MaKhachHang == cr.MaTruong)
                                    return false;
                            }
                            // phiếu thu
                            PhieuThu();
                            for (int i = 0; i < phieuthu.Length; i++)
                            {
                                if (phieuthu[i].DoiTuong == cr.MaTruong)
                                    return false;
                            }
                            // số dư công nợ
                            SoDuCongNo();
                            for (int i = 0; i < soducongno.Length; i++)
                            {
                                if (soducongno[i].MaDoiTuong == cr.MaTruong)
                                    return false;
                            }
                            break;
                        }
                    case "KhoHang":
                        {
                            // chi tiết kho hàng
                            ChiTietKhoHang();
                            for (int i = 0; i < chitietkhohang.Length; i++)
                            {
                                if (chitietkhohang[i].Makho == cr.MaTruong)
                                    return false;
                            }
                            // đơn đặt hàng
                            DonDatHang();
                            for (int i = 0; i < dondathang.Length; i++)
                            {
                                if (dondathang[i].MaKho == cr.MaTruong)
                                    return false;
                            }
                            // hóa đơn bán hàng
                            HDBanHang();
                            for (int i = 0; i < hdbanhang.Length; i++)
                            {
                                if (hdbanhang[i].MaKho == cr.MaTruong)
                                    return false;
                            }
                            // khách hàng trả lại
                            KhachHangTraLai();
                            for (int i = 0; i < khachhangtralai.Length; i++)
                            {
                                if (khachhangtralai[i].MaKho == cr.MaTruong)
                                    return false;
                            }
                            // hóa đơn nhập
                            HoaDonNhap();
                            for (int i = 0; i < hoadonnhap.Length; i++)
                            {
                                if (hoadonnhap[i].MaKho == cr.MaTruong)
                                    return false;
                            }
                            // trả lại nhà cung cấp
                            TraLaiNCC();
                            for (int i = 0; i < tralaincc.Length; i++)
                            {
                                if (tralaincc[i].MaKho == cr.MaTruong)
                                    return false;
                            }
                            // phiếu điều chuyển kho
                            PhieuDieuChuyenKhoNoiBo();
                            for (int i = 0; i < phieudieuchuyenkho.Length; i++)
                            {
                                if (phieudieuchuyenkho[i].TuKho == cr.MaTruong || phieudieuchuyenkho[i].DenKho == cr.MaTruong)
                                    return false;
                            }
                            // kiểm kê kho
                            KiemKeKho();
                            for (int i = 0; i < kiemkekho.Length; i++)
                            {
                                if (kiemkekho[i].MaKho == cr.MaTruong)
                                    return false;
                            }
                            // phiếu thu
                            PhieuThu();
                            for (int i = 0; i < phieuthu.Length; i++)
                            {
                                if (phieuthu[i].MaKho == cr.MaTruong)
                                    return false;
                            }
                            // phiếu xuất hủy
                            PhieuXuatHuy();
                            for (int i = 0; i < phieuxuathuy.Length; i++)
                            {
                                if (phieuxuathuy[i].MaKho == cr.MaTruong)
                                    return false;
                            }
                            break;
                        }
                    case "NhomTKKeToan":
                        {
                            // tài khoản kế toán
                            TKKeToan();
                            for (int i = 0; i < tkketoan.Length; i++)
                            {
                                if (tkketoan[i].NhomTKKT == cr.MaTruong)
                                    return false;
                            }
                            break;
                        }
                    case "TKKeToan":
                        {
                            // khoản mục thu chi
                            KMThuChi();
                            for (int i = 0; i < kmthuchi.Length; i++)
                            {
                                if (kmthuchi[i].CoTK == cr.MaTruong || kmthuchi[i].NoTK == cr.MaTruong)
                                    return false;
                            }
                            break;
                        }
                    case "TienTe":
                        {
                            // đơn đặt hàng
                            DonDatHang();
                            for (int i = 0; i < dondathang.Length; i++)
                            {
                                if (dondathang[i].MaTienTe == cr.MaTruong)
                                    return false;
                            }
                            // hóa đơn bán hàng
                            HDBanHang();
                            for (int i = 0; i < hdbanhang.Length; i++)
                            {
                                if (hdbanhang[i].MaTienTe == cr.MaTruong)
                                    return false;
                            }
                            // khách hàng trả lại
                            KhachHangTraLai();
                            for (int i = 0; i < khachhangtralai.Length; i++)
                            {
                                if (khachhangtralai[i].MaTienTe == cr.MaTruong)
                                    return false;
                            }
                            // hóa đơn nhập
                            HoaDonNhap();
                            for (int i = 0; i < hoadonnhap.Length; i++)
                            {
                                if (hoadonnhap[i].MaTienTe == cr.MaTruong)
                                    return false;
                            }
                            // trả lại nhà cung cấp
                            TraLaiNCC();
                            for (int i = 0; i < tralaincc.Length; i++)
                            {
                                if (tralaincc[i].MaTienTe == cr.MaTruong)
                                    return false;
                            }
                            // phiếu thanh toán của khách hàng
                            PhieuTTCuaKH();
                            for (int i = 0; i < phieuttcuakh.Length; i++)
                            {
                                if (phieuttcuakh[i].MaTienTe == cr.MaTruong)
                                    return false;
                            }
                            // phiếu thanh toán của nhà cung cấp
                            PhieuTTNCC();
                            for (int i = 0; i < phieuttcuancc.Length; i++)
                            {
                                if (phieuttcuancc[i].MaTienTe == cr.MaTruong)
                                    return false;
                            }
                            // phiếu thu
                            PhieuThu();
                            for (int i = 0; i < phieuthu.Length; i++)
                            {
                                if (phieuthu[i].MaTienTe == cr.MaTruong)
                                    return false;
                            }
                            break;
                        }
                    case "NhanVien":
                        {
                            // kho hàng
                            KhoHang();
                            for (int i = 0; i < khohang.Length; i++)
                            {
                                if (khohang[i].MaNhanVien == cr.MaTruong)
                                    return false;
                            }
                            // đơn đặt hàng
                            DonDatHang();
                            for (int i = 0; i < dondathang.Length; i++)
                            {
                                if (dondathang[i].MaNhanVien == cr.MaTruong)
                                    return false;
                            }
                            // hóa đơn bán hàng
                            HDBanHang();
                            for (int i = 0; i < hdbanhang.Length; i++)
                            {
                                if (hdbanhang[i].MaNhanVien == cr.MaTruong)
                                    return false;
                            }
                            // phiếu xuất hủy
                            PhieuXuatHuy();
                            for (int i = 0; i < phieuxuathuy.Length; i++)
                            {
                                if (phieuxuathuy[i].MaNhanVien == cr.MaTruong)
                                    return false;
                            }
                            break;
                        }
                    case "LoaiHangHoa":
                        {
                            // nhóm hàng hóa
                            NhomHang();
                            for (int i = 0; i < nhomhang.Length; i++)
                            {
                                if (nhomhang[i].MaLoaiHang == cr.MaTruong)
                                    return false;
                            }

                            break;
                        }
                    case "NhomHang":
                        {
                            HangHoa();
                            for (int i = 0; i < hanghoa.Length; i++)
                            {
                                if (hanghoa[i].MaNhomHangHoa == cr.MaTruong)
                                    return false;
                            }
                            break;
                        }
                    case "NhaCungCap":
                        {
                            // sô dư đầu kỳ công nợ
                            SoDuCongNo();
                            for (int i = 0; i < soducongno.Length; i++)
                            {
                                if (soducongno[i].MaDoiTuong == cr.MaTruong)
                                    return false;
                            }
                            // đơn đặt hàng
                            DonDatHang();
                            for (int i = 0; i < dondathang.Length; i++)
                            {
                                if (dondathang[i].MaNhaCungCap == cr.MaTruong)
                                    return false;
                            }
                            // trả lại nhà cung cấp
                            TraLaiNCC();
                            for (int i = 0; i < tralaincc.Length; i++)
                            {
                                if (tralaincc[i].MaNCC == cr.MaTruong)
                                    return false;
                            }
                            // phiếu thu
                            PhieuThu();
                            for (int i = 0; i < phieuthu.Length; i++)
                            {
                                if (phieuthu[i].DoiTuong == cr.MaTruong)
                                    return false;
                            }
                            // phiếu thanh toán của nhà cung cấp
                            PhieuTTNCC();
                            for (int i = 0; i < phieuttcuancc.Length; i++)
                            {
                                if (phieuttcuancc[i].MaNCC == cr.MaTruong)
                                    return false;
                            }
                            break;
                        }
                    case "Thue":
                        {
                            // hàng hóa
                            HangHoa();
                            for (int i = 0; i < hanghoa.Length; i++)
                            {
                                if (hanghoa[i].MaThueGiaTriGiaTang == cr.MaTruong)
                                    return false;
                            }
                            // khách hàng trả lại
                            KhachHangTraLai();
                            for (int i = 0; i < khachhangtralai.Length; i++)
                            {
                                if (khachhangtralai[i].ThueGTGT == cr.MaTruong)
                                    return false;
                            }
                            // trả lại nhà cung cấp
                            TraLaiNCC();
                            for (int i = 0; i < tralaincc.Length; i++)
                            {
                                if (tralaincc[i].ThueGTGT == cr.MaTruong)
                                    return false;
                            }
                            // đơn đặt hàng
                            DonDatHang();
                            for (int i = 0; i < dondathang.Length; i++)
                            {
                                if (dondathang[i].ThueGTGT == cr.MaTruong)
                                    return false;
                            }
                            // nhập kho
                            HoaDonNhap();
                            for (int i = 0; i < hoadonnhap.Length; i++)
                            {
                                if (hoadonnhap[i].ThueGTGT == cr.MaTruong)
                                    return false;
                            }
                            // hóa đơn bán hàng
                            HDBanHang();
                            for (int i = 0; i < hdbanhang.Length; i++)
                            {
                                if (hdbanhang[i].ThueGTGT == cr.MaTruong)
                                    return false;
                            }
                            break;
                        }
                    case "DVT":
                        {
                            // hàng hóa
                            HangHoa();
                            for (int i = 0; i < hanghoa.Length; i++)
                            {
                                if (hanghoa[i].MaDonViTinh == cr.MaTruong)
                                    return false;
                            }
                            break;
                        }
                    default:
                        break;
                }
                return kt;
            }
            catch
            {
                return false;
            }
        }
    }
}
