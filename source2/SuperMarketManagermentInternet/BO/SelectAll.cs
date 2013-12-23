using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizLogic
{

    public class SelectAll
    {
        #region thuế
        public Entities.Thue[] Thue()
        {
            Entities.Thue[] thue = new BizLogic.Thue().Select();
            if (thue == null)
                thue = new Entities.Thue[0];
            return thue;
        }
        #endregion

        #region Hàng Hóa Theo Kho
        public Entities.HangHoa[] HangHoaTheoKho(string makho)
        {
            Entities.HangHoa[] hanghoa = new BizLogic.HangHoa().SelectHHTheoKho(makho);
            if (hanghoa == null)
                hanghoa = new Entities.HangHoa[0];
            return hanghoa;
        }
        #endregion

        #region Chi Tiết Hóa Đơn Bán Hàng
        public Entities.ChiTietHDBanHang[] ChiTietHDBanHang()
        {
            Entities.ChiTietHDBanHang[] chitiethdbanhang = new BizLogic.CheckRefer().ChiTietHDBanHang();
            if (chitiethdbanhang == null)
                chitiethdbanhang = new Entities.ChiTietHDBanHang[0];
            return chitiethdbanhang;
        }
        #endregion

        #region Hóa đơn bán hàng
        public Entities.HDBanHang[] HDBanHang()
        {
            Entities.HDBanHang[] hdbanhang = new BizLogic.CheckRefer().HDBanHang();
            if (hdbanhang == null)
                hdbanhang = new Entities.HDBanHang[0];
            return hdbanhang;
        }
        #endregion

        #region số dư công nợ
        public Entities.SoDuCongNo[] SoDuCongNo()
        {
            Entities.SoDuCongNo[] sodu = new BizLogic.CongNo().Select();
            if (sodu == null)
                sodu = new Entities.SoDuCongNo[0];
            return sodu;
        }
        #endregion

        #region Khách hàng
        public Entities.KhachHang[] KhachHang()
        {
            Entities.KhachHang[] khachhang = new BizLogic.KhachHang().Select();
            if (khachhang == null)
                khachhang = new Entities.KhachHang[0];
            return khachhang;
        }
        #endregion

        #region Khách hàng trả lại
        public Entities.KhachHangTraLai[] KhachHangTraLai()
        {
            Entities.KhachHangTraLai[] select = (Entities.KhachHangTraLai[])new BizLogic.CongNo().SelectKHTL();
            if (select == null)
                select = new Entities.KhachHangTraLai[0];
            return select;
        }
        #endregion

        #region phiếu thanh toán của khách hàng
        public Entities.PhieuTTCuaKH[] PhieuTTCuaKH()
        {
            Entities.PhieuTTCuaKH[] pttckh1 = new BizLogic.PhieuTTCuaKH().Select();
            if (pttckh1 == null)
                pttckh1 = new Entities.PhieuTTCuaKH[0];
            return pttckh1;
        }
        #endregion

        #region Chi tiết phiếu thanh toán của khách hàng
        public Entities.ChiTietPhieuTTCuaKH[] ChiTietPhieuTTCuaKH()
        {
            Entities.ChiTietPhieuTTCuaKH[] ctpttckh1 = new BizLogic.ChiTietPhieuTTCuaKH().Select();
            if (ctpttckh1 == null)
                ctpttckh1 = new Entities.ChiTietPhieuTTCuaKH[0];
            return ctpttckh1;
        }
        #endregion

        #region gói hàng
        public Entities.GoiHang[] GoiHang()
        {
            Entities.GoiHang[] nkh1 = new BizLogic.GoiHang().Select();
            if (nkh1 == null)
                nkh1 = new Entities.GoiHang[0];
            return nkh1;
        }
        #endregion

        #region chi tiết gói hàng
        public Entities.ChiTietGoiHang[] ChiTietGoiHang()
        {
            Entities.ChiTietGoiHang[] nkh1 = new BizLogic.ChiTietGoiHang().Select();
            if (nkh1 == null)
                nkh1 = new Entities.ChiTietGoiHang[0];
            return nkh1;
        }
        #endregion

        #region Quy đổi đơn vị tính
        public Entities.QuyDoiDonViTinh[] QuyDoiDonViTinh()
        {
            Entities.QuyDoiDonViTinh[] nkh1 = new BizLogic.QuyDoiDonViTinh().Select();
            if (nkh1 == null)
                nkh1 = new Entities.QuyDoiDonViTinh[0];
            return nkh1;
        }
        #endregion

        #region phiếu thanh toán nhà cung cấp
        public Entities.PhieuTTNCC[] PhieuTTNCC()
        {
            Entities.PhieuTTNCC[] pttncc1 = new BizLogic.PhieuTTNCC().Select();
            if (pttncc1 == null)
                pttncc1 = new Entities.PhieuTTNCC[0];
            return pttncc1;
        }
        #endregion

        #region chi tiết phiếu thanh toán nhà cung cấp
        public Entities.ChiTietPhieuTTNCC[] ChiTietPhieuTTNCC()
        {
            Entities.ChiTietPhieuTTNCC[] ctpttncc1 = new BizLogic.ChiTietPhieuTTNCC().Select();
            if (ctpttncc1 == null)
                ctpttncc1 = new Entities.ChiTietPhieuTTNCC[0];
            return ctpttncc1;
        }
        #endregion

        #region hóa đơn nhập
        public Entities.HoaDonNhap[] HoaDonNhap()
        {
            Entities.HoaDonNhap[] hdn = new BizLogic.HoaDonNhap().Select();
            if (hdn == null)
                hdn = new Entities.HoaDonNhap[0];
            return hdn;
        }
        #endregion

        #region nhà cung cấp
        public Entities.NhaCungCap[] NhaCungCap()
        {
            Entities.NhaCungCap[] ncc1 = new BizLogic.NhaCungCap().Select();
            if (ncc1 == null)
                ncc1 = new Entities.NhaCungCap[0];
            return ncc1;
        }
        #endregion

        #region nhà cung cấp
        public Entities.TraLaiNCC[] TraLaiNCC()
        {
            Entities.TraLaiNCC[] select = (Entities.TraLaiNCC[])new BizLogic.CongNo().SelectTLNCC();
            if (select == null)
                select = new Entities.TraLaiNCC[0];
            return select;
        }
        #endregion

        /// <summary>
        /// Select all phieu thu chi
        /// </summary>
        /// <returns></returns>
        public Entities.PhieuThu[] PhieuThuChi()
        {
            Entities.PhieuThu[] select = new BizLogic.CheckRefer().PhieuThu();
            if (select == null)
                select = new Entities.PhieuThu[0];
            return select;
        }

        Entities.SelectAll temp;
        public Entities.SelectAll BCThue(string makho)
        {
            temp = new Entities.SelectAll();
            temp.HangHoaTheoKho = HangHoaTheoKho(makho);
            temp.Thue = Thue();
            temp.HDBanHang = HDBanHang();
            temp.ChiTietHDBanHang = ChiTietHDBanHang();
            return temp;

        }
        public Entities.SelectAll BCCongNoKhachHang()
        {
            temp = new Entities.SelectAll();
            temp.KhachHang = KhachHang();
            temp.PhieuTTCuaKH = PhieuTTCuaKH();
            temp.ChiTietPhieuTTCuaKH = ChiTietPhieuTTCuaKH();
            temp.HDBanHang = HDBanHang();
            temp.KhachHangTraLai = KhachHangTraLai();
            temp.SoDuCongNo = SoDuCongNo();
            temp.PhieuThu = PhieuThuChi();
            return temp;
        }
        public Entities.SelectAll BanBuon()
        {
            temp = new Entities.SelectAll();
            temp.GoiHang = GoiHang();
            temp.ChiTietGoiHang = ChiTietGoiHang();
            temp.QuyDoiDonViTinh = QuyDoiDonViTinh();
            return temp;
        }
        public Entities.SelectAll BCCongNoNhaCungCap()
        {
            temp = new Entities.SelectAll();
            temp.SoDuCongNo = SoDuCongNo();
            temp.NhaCungCap = NhaCungCap();
            temp.PhieuTTNCC = PhieuTTNCC();
            temp.ChiTietPhieuTTNCC = ChiTietPhieuTTNCC();
            temp.HoaDonNhap = HoaDonNhap();
            temp.TraLaiNCC = TraLaiNCC();
            temp.PhieuThu = PhieuThuChi();
            return temp;
        }

        public Entities.SelectAll TimKiemChungTu()
        {
            temp = new Entities.SelectAll();
            temp.PhieuXuatHuy = new BizLogic.CheckRefer().PhieuXuatHuy();
            temp.ChiTietXuatHuy = new BizLogic.CheckRefer().ChiTietXuatHuy();
            temp.HDBanHang = new BizLogic.CheckRefer().HDBanHang();
            temp.ChiTietHDBanHang = new BizLogic.CheckRefer().ChiTietHDBanHang();
            temp.ChiTietTraLaiNhaCungCap = new BizLogic.CheckRefer().ChiTietTraLaiNCC();
            temp.HoaDonNhap = new BizLogic.CheckRefer().HoaDonNhap();
            temp.ChiTietHoaDonNhap = new BizLogic.CheckRefer().ChiTietHoaDonNhap();
            temp.KhachHangTraLai = new BizLogic.CheckRefer().KhachHangTraLai();
            temp.ChiTietKhachHangTraLai = new BizLogic.CheckRefer().ChiTietKhachHangTraLai();
            temp.PhieuDieuChuyenKhoNoiBo = new BizLogic.CheckRefer().PhieuDieuChuyenKhoNoiBo();
            temp.ChiTietPhieuDieuChuyenKho = new BizLogic.CheckRefer().ChiTietPhieuDieuChuyenKho();
            temp.PhieuThu = new BizLogic.CheckRefer().PhieuThu();
            temp.PhieuTTCuaKH = new BizLogic.CheckRefer().PhieuTTCuaKH();
            temp.ChiTietPhieuTTCuaKH = new BizLogic.CheckRefer().ChiTietPhieuTTCuaKH();
            temp.PhieuTTNCC = new BizLogic.CheckRefer().PhieuTTNCC();
            temp.ChiTietPhieuTTNCC = new BizLogic.CheckRefer().ChiTietPhieuTTNCC();
            temp.HangHoa = new BizLogic.CheckRefer().HangHoa();
            temp.NhomHang = new BizLogic.CheckRefer().NhomHang();
            temp.TraLaiNCC = new BizLogic.CheckRefer().TraLaiNCC();
            temp.ChiTietTraLaiNhaCungCap = new BizLogic.CheckRefer().ChiTietTraLaiNCC();
            return temp;
        }
        public Entities.SelectAll BCXuatNhapTonNhomHang(string makho)
        {
            temp = new Entities.SelectAll();
            temp.PhieuXuatHuy = new BizLogic.CheckRefer().PhieuXuatHuy();
            temp.ChiTietXuatHuy = new BizLogic.CheckRefer().ChiTietXuatHuy();
            temp.HDBanHang = new BizLogic.CheckRefer().HDBanHang();
            temp.ChiTietHDBanHang = new BizLogic.CheckRefer().ChiTietHDBanHang();
            temp.ChiTietTraLaiNhaCungCap = new BizLogic.CheckRefer().ChiTietTraLaiNCC();
            temp.HoaDonNhap = new BizLogic.CheckRefer().HoaDonNhap();
            temp.ChiTietHoaDonNhap = new BizLogic.CheckRefer().ChiTietHoaDonNhap();
            temp.TraLaiNCC = new BizLogic.CheckRefer().TraLaiNCC();
            temp.ChiTietTraLaiNhaCungCap = new BizLogic.CheckRefer().ChiTietTraLaiNCC();
            temp.KhachHangTraLai = new BizLogic.CheckRefer().KhachHangTraLai();
            temp.ChiTietKhachHangTraLai = new BizLogic.CheckRefer().ChiTietKhachHangTraLai();
            temp.GoiHang = GoiHang();
            temp.ChiTietGoiHang = ChiTietGoiHang();
            temp.HangHoa = HangHoaTheoKho(makho);
            temp.NhomHang = new BizLogic.CheckRefer().NhomHang();
            temp.KhoHang = new BizLogic.CheckRefer().KhoHang();
            temp.SoDuKho = new BizLogic.CheckRefer().SoDuKho();
            return temp;
        }
        public Entities.SelectAll BCDoanhThuNhomHang(string makho)
        {
            temp = new Entities.SelectAll();
            temp.GoiHang = GoiHang();
            temp.ChiTietGoiHang = ChiTietGoiHang();
            temp.HDBanHang = new CheckRefer().HDBanHang();
            temp.ChiTietHDBanHang = new CheckRefer().ChiTietHDBanHang();
            temp.HangHoaTheoKho = HangHoaTheoKho(makho);
            temp.NhomHang = new CheckRefer().NhomHang();
            temp.Thue = new CheckRefer().Thue();
            return temp;
        }
        public Entities.SelectAll frmBCXuatHangTheoTungKho(string makho)
        {
            temp = new Entities.SelectAll();
            temp.GoiHang = GoiHang();
            temp.ChiTietGoiHang = ChiTietGoiHang();
            temp.HangHoaTheoKho = HangHoaTheoKho(makho);
            return temp;
        }
        public Entities.SelectAll frmBCXuatHangTheoNhomHang(string makho)
        {
            temp = new Entities.SelectAll();
            temp.GoiHang = GoiHang();
            temp.ChiTietGoiHang = ChiTietGoiHang();
            temp.HangHoa = new CheckRefer().HangHoa();
            temp.NhomHang = new CheckRefer().NhomHang();
            return temp;
        }
        public Entities.SelectAll BCDoanhThuMatHang(string makho)
        {
            temp = new Entities.SelectAll();
            temp.GoiHang = GoiHang();
            temp.ChiTietGoiHang = ChiTietGoiHang();
            temp.HDBanHang = new CheckRefer().HDBanHang();
            temp.ChiTietHDBanHang = new CheckRefer().ChiTietHDBanHang();
            temp.HangHoaTheoKho = HangHoaTheoKho(makho);
            temp.NhomHang = new CheckRefer().NhomHang();
            temp.Thue = new CheckRefer().Thue();
            return temp;
        }

        public Entities.SelectAll SoQuy()
        {
            temp = new Entities.SelectAll();
            temp.SoDuSoQuy = new CheckRefer().SoDuSoQuy();
            temp.PhieuThu = new CheckRefer().PhieuThu();
            temp.HDBanHang = new CheckRefer().HDBanHang();
            temp.HoaDonNhap = new CheckRefer().HoaDonNhap();
            temp.KhachHangTraLai = new CheckRefer().KhachHangTraLai();
            temp.TraLaiNCC = new CheckRefer().TraLaiNCC();
            return temp;
        }

        public Entities.SelectAll BCXuatHuyHangHoa(string makho)
        {
            temp = new Entities.SelectAll();
            temp.HangHoaTheoKho = HangHoaTheoKho(makho);
            temp.PhieuXuatHuy = new CheckRefer().PhieuXuatHuy();
            temp.ChiTietXuatHuy = new CheckRefer().ChiTietXuatHuy();
            temp.Thue = new CheckRefer().Thue();
            return temp;
        }

        public Entities.SelectAll BCKhachHangTraHang(string makho)
        {
            temp = new Entities.SelectAll();
            temp.HangHoaTheoKho = HangHoaTheoKho(makho);
            temp.KhachHangTraLai = new CheckRefer().KhachHangTraLai();
            temp.ChiTietKhachHangTraLai = new CheckRefer().ChiTietKhachHangTraLai();
            temp.Thue = new CheckRefer().Thue();
            temp.HDBanHang = HDBanHang();
            return temp;
        }

        public Entities.SelectAll BCTraLaiNCC(string makho)
        {
            temp = new Entities.SelectAll();
            temp.HangHoaTheoKho = HangHoaTheoKho(makho);
            temp.TraLaiNCC = new CheckRefer().TraLaiNCC();
            temp.ChiTietTraLaiNhaCungCap = new CheckRefer().ChiTietTraLaiNCC();
            temp.Thue = new CheckRefer().Thue();
            return temp;
        }



    }
}
