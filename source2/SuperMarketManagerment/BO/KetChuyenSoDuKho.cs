using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizLogic
{
    public class KetChuyenSoDuKho
    {
        #region Lấy Bảng Kho Hàng
        public Entities.KhoHang[] khohang;
        public void LayKhoHang()
        {
            try
            {

                khohang = new BizLogic.KhoHang().Select();
                if (khohang == null)
                {
                    khohang = new Entities.KhoHang[0];
                    return;
                }
            }
            catch
            {
            }
        }
        #endregion
        #region Lấy Số Dư Kho
        Entities.SoDuKho[] sdk;
        public void LaySoDuKho()
        {
            Entities.SoDuKho[] ddh = new Entities.SoDuKho[1];
            ddh = new BizLogic.SoDuKho().Select();
            if (ddh != null)
            {
                sdk = ddh;
            }
            else
            {
                sdk = new Entities.SoDuKho[0];
            }
        }
        #endregion
        #region lấy Số DƯ kho theo Kỳ
        public Entities.SoDuKho[] LaySoDuKhoTheoNgay(int thangKC, int namKC)
        {
            int count = 0;
            for (int i = 0; i < sdk.Length; i++)
            {
                if (sdk[i].NgayKetChuyen.Month == thangKC && sdk[i].NgayKetChuyen.Year == namKC)
                {
                    count++;
                }
            }
            Entities.SoDuKho[] sdk1 = new Entities.SoDuKho[count];
            count = 0;
            for (int i = 0; i < sdk.Length; i++)
            {
                if (sdk[i].NgayKetChuyen.Month == thangKC && sdk[i].NgayKetChuyen.Year == namKC)
                {
                    sdk1[count] = sdk[i];
                    count++;
                }
            }
            if (sdk1.Length == 0)
            {
                return new Entities.SoDuKho[0];
            }
            else
                return sdk1;
        }
        #endregion

        #region Lấy Bảng Hàng Hóa
        public Entities.HangHoa[] hanghoa;
        public void LayBangHangHoa()
        {
            
            Entities.HangHoa[] hh1 = new Entities.HangHoa[1];
            hh1 = new BizLogic.HangHoa().Select();
            if (hh1 != null)
            {
                hanghoa = hh1;
            }
            else
            {
                hanghoa = new Entities.HangHoa[0];
            }
        }
        #endregion

        #region lấy ngày bắt đầu - ngày kết thúc
        DateTime BatDau, KetThuc;
        public void LayNgay()
        {

            BatDau = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            KetThuc = DateTime.Now;

        }
        #endregion

        #region Lấy Hóa Đơn Bán Hàng Theo Ngày Tháng
        public Entities.HDBanHang[] HDBanHang;
        public void LayHDBanHang()
        {
            try
            {
                Entities.HDBanHang[] HDBanHang1 = new Entities.HDBanHang[0];
                HDBanHang1 = new BizLogic.HDBanHang().Select();
                if (HDBanHang1 == null)
                {
                    HDBanHang1 = new Entities.HDBanHang[0];
                    return;
                }

                int count = 0;
                for (int i = 0; i < HDBanHang1.Length; i++)
                {
                    DateTime ngayban = HDBanHang1[i].NgayBan;
                    if (ngayban >= BatDau && ngayban <= KetThuc)
                    {
                        count++;
                    }
                }
                HDBanHang = new Entities.HDBanHang[count];
                count = 0;
                for (int i = 0; i < HDBanHang1.Length; i++)
                {
                    DateTime ngayban = HDBanHang1[i].NgayBan;
                    if (ngayban >= BatDau && ngayban <= KetThuc)
                    {
                        HDBanHang[count] = HDBanHang1[i];
                        count++;
                    }
                }

            }
            catch
            {
            }
        }
        #endregion
        #region Lấy HD Bán Hàng Theo Kho
        Entities.HDBanHang[] HDBanHang_TheoKho;
        public void LayHDBanHang_TheoKho(string maKho)
        {
            int count = 0;
            for (int i = 0; i < HDBanHang.Length; i++)
            {
                if (maKho == HDBanHang[i].MaKho)
                {
                    count++;
                }
            }
            HDBanHang_TheoKho = new Entities.HDBanHang[count];
            count = 0;
            for (int i = 0; i < HDBanHang.Length; i++)
            {
                if (maKho == HDBanHang[i].MaKho)
                {
                    HDBanHang_TheoKho[count] = HDBanHang[i];
                    count++;
                }
            }
        }
        #endregion
        #region Lấy Chi Tiết Hóa Đơn Bán Hàng
        Entities.ChiTietHDBanHang[] ctHDBanHang;
        public void LayChiTiet_HDBanHang()
        {
            Entities.ChiTietHDBanHang[] ctHDBanHang1 = new Entities.ChiTietHDBanHang[0];
            ctHDBanHang1 = new BizLogic.ChiTietHDBanHang().Select();
            if (ctHDBanHang1 == null)
            {
                ctHDBanHang = new Entities.ChiTietHDBanHang[0];
                return;
            }
            ctHDBanHang = ctHDBanHang1;
        }
        #endregion
        #region Lấy Chi tiết Hóa đơn bán hàng theo Mã HD
        public Entities.ChiTietHDBanHang[] LayChiTiet_HDBanHang_TheoMaPhieu(string maHD)
        {
            int count = 0;
            for (int i = 0; i < ctHDBanHang.Length; i++)
            {
                if (ctHDBanHang[i].MaHDBanHang == maHD)
                {
                    count++;
                }
            }
            Entities.ChiTietHDBanHang[] ctHDBanHang_TheoMaHD = new Entities.ChiTietHDBanHang[count];
            count = 0;
            for (int i = 0; i < ctHDBanHang.Length; i++)
            {
                if (ctHDBanHang[i].MaHDBanHang == maHD)
                {
                    ctHDBanHang_TheoMaHD[count] = ctHDBanHang[i];
                    count++;
                }
            }
            if (ctHDBanHang_TheoMaHD == null)
            {
                ctHDBanHang_TheoMaHD = new Entities.ChiTietHDBanHang[0];
                return ctHDBanHang_TheoMaHD;
            }
            else
            {
                return ctHDBanHang_TheoMaHD;
            }
        }
        #endregion

        #region Lấy Phiếu Điều Chuyển Kho theo Ngày Tháng
        Entities.PhieuDieuChuyenKhoNoiBo[] PDieuChuyen;
        public void LayPhieuDieuChuyenKhoNoiBo()
        {
            try
            {
                Entities.PhieuDieuChuyenKhoNoiBo[] PDieuChuyen1 = new Entities.PhieuDieuChuyenKhoNoiBo[0];
                PDieuChuyen1 = new BizLogic.PhieuDieuChuyenKhoNoiBo().Select();
                if (PDieuChuyen1 == null)
                {
                    PDieuChuyen1 = new Entities.PhieuDieuChuyenKhoNoiBo[0];
                    PDieuChuyen = PDieuChuyen1;
                    return;
                }


                int count = 0;
                for (int i = 0; i < PDieuChuyen1.Length; i++)
                {
                    DateTime ngaydieuchuyen = PDieuChuyen1[i].NgayDieuChuyen;
                    if (ngaydieuchuyen >= BatDau && ngaydieuchuyen <= KetThuc)
                    {
                        count++;
                    }
                }
                PDieuChuyen = new Entities.PhieuDieuChuyenKhoNoiBo[count];
                count = 0;
                for (int i = 0; i < PDieuChuyen1.Length; i++)
                {
                    DateTime ngaydieuchuyen = PDieuChuyen1[i].NgayDieuChuyen;
                    if (ngaydieuchuyen >= BatDau && ngaydieuchuyen <= KetThuc)
                    {
                        PDieuChuyen[count] = PDieuChuyen1[i];
                        count++;
                    }
                }

            }
            catch
            {
            }
        }
        #endregion
        #region Lấy Phiếu ĐIều chuyển Theo Kho Đi
        Entities.PhieuDieuChuyenKhoNoiBo[] PDieuChuyen_TheoKhoDi;
        public void LayPhieuDieuChuyenKhoNoiBo_TheoKhoDi(string maKho)
        {
            int count = 0;
            for (int i = 0; i < PDieuChuyen.Length; i++)
            {
                if (maKho == PDieuChuyen[i].TuKho)
                {
                    count++;
                }
            }
            PDieuChuyen_TheoKhoDi = new Entities.PhieuDieuChuyenKhoNoiBo[count];
            count = 0;
            for (int i = 0; i < PDieuChuyen.Length; i++)
            {
                if (maKho == PDieuChuyen[i].TuKho)
                {
                    PDieuChuyen_TheoKhoDi[count] = PDieuChuyen[i];
                    count++;
                }
            }
        }
        #endregion
        #region Lấy Phiếu ĐIều chuyển Theo Kho Đến
        Entities.PhieuDieuChuyenKhoNoiBo[] PDieuChuyen_TheoKhoDen;
        public void LayPhieuDieuChuyenKhoNoiBo_TheoKhoDen(string maKho)
        {
            int count = 0;
            for (int i = 0; i < PDieuChuyen.Length; i++)
            {
                if (maKho == PDieuChuyen[i].DenKho)
                {
                    count++;
                }
            }
            PDieuChuyen_TheoKhoDen = new Entities.PhieuDieuChuyenKhoNoiBo[count];
            count = 0;
            for (int i = 0; i < PDieuChuyen.Length; i++)
            {
                if (maKho == PDieuChuyen[i].DenKho)
                {
                    PDieuChuyen_TheoKhoDen[count] = PDieuChuyen[i];
                    count++;
                }
            }
        }
        #endregion
        #region Lấy Chi Tiết Phiếu Điều Chuyển Kho
        Entities.ChiTietPhieuDieuChuyenKho[] ctPDCK;
        public void LayChiTiet_PhieuDieuChuyenKho()
        {
            ctPDCK = new Entities.ChiTietPhieuDieuChuyenKho[0];
            ctPDCK = new BizLogic.ChiTietPhieuDieuChuyenKho().Select();
            if (ctPDCK == null)
            {
                ctPDCK = new Entities.ChiTietPhieuDieuChuyenKho[0];
                return;
            }
        }
        #endregion
        #region Lấy Chi Tiết Phiếu Điều Chuyển Kho theo Mã Phiếu
        public Entities.ChiTietPhieuDieuChuyenKho[] LayChiTiet_PhieuDieuChuyenKho_TheoMaPhieu(string maPhieu)
        {
            int count = 0;

            for (int i = 0; i < ctPDCK.Length; i++)
            {
                if (ctPDCK[i].MaPhieuDieuChuyenKho == maPhieu)
                {
                    count++;
                }
            }
            Entities.ChiTietPhieuDieuChuyenKho[] ctPDCK1 = new Entities.ChiTietPhieuDieuChuyenKho[count];
            count = 0;
            for (int i = 0; i < ctPDCK.Length; i++)
            {
                if (ctPDCK[i].MaPhieuDieuChuyenKho == maPhieu)
                {
                    ctPDCK1[count] = ctPDCK[i];
                    count++;
                }
            }
            if (ctPDCK1 == null)
            {
                ctPDCK1 = new Entities.ChiTietPhieuDieuChuyenKho[0];
                return ctPDCK1;
            }
            else
            {
                return ctPDCK1;
            }
        }
        #endregion

        #region Lấy Phiếu Xuất Hủy theo ngày tháng
        Entities.PhieuXuatHuy[] PXuatHuy;
        public void LayPhieuXuatHuy()
        {
            try
            {
                Entities.PhieuXuatHuy[] PXuatHuy1 = new Entities.PhieuXuatHuy[0];
                PXuatHuy1 = new BizLogic.PhieuXuatHuy().Select();
                if (PXuatHuy1 == null)
                {
                    PXuatHuy1 = new Entities.PhieuXuatHuy[0];
                    PXuatHuy = PXuatHuy1;
                    return;
                }
                int count = 0;
                for (int i = 0; i < PXuatHuy1.Length; i++)
                {
                    DateTime ngaylap = PXuatHuy1[i].NgayLap;
                    if (ngaylap >= BatDau && ngaylap <= KetThuc)
                    {
                        count++;
                    }
                }
                PXuatHuy = new Entities.PhieuXuatHuy[count];
                count = 0;
                for (int i = 0; i < PXuatHuy1.Length; i++)
                {
                    DateTime ngaylap = PXuatHuy1[i].NgayLap;
                    if (ngaylap >= BatDau && ngaylap <= KetThuc)
                    {
                        PXuatHuy[count] = PXuatHuy1[i];
                        count++;
                    }
                }


            }
            catch
            {
            }
        }
        #endregion
        #region Lấy Phiếu Xuất Hủy theo Kho
        Entities.PhieuXuatHuy[] PXuatHuy_TheoMaKho;
        public void LayPhieuXuatHuy_TheoMaKho(string maKho)
        {
            try
            {
                int count = 0;
                for (int i = 0; i < PXuatHuy.Length; i++)
                {
                    if (PXuatHuy[i].MaKho == maKho)
                    {
                        count++;
                    }
                }
                PXuatHuy_TheoMaKho = new Entities.PhieuXuatHuy[count];
                count = 0;
                for (int i = 0; i < PXuatHuy.Length; i++)
                {
                    if (PXuatHuy[i].MaKho == maKho)
                    {
                        PXuatHuy_TheoMaKho[count] = PXuatHuy[i];
                        count++;
                    }
                }
            }
            catch
            {
            }
        }
        #endregion
        #region Lấy Chi Tiết Phiếu Xuất Hủy
        Entities.ChiTietXuatHuy[] ctPXuatHuy;
        public void LayChiTiet_XuatHuy()
        {
            try
            { 
                ctPXuatHuy = new Entities.ChiTietXuatHuy[0];
                ctPXuatHuy = new BizLogic.ChiTietXuatHuy().Select();
                if (ctPXuatHuy == null)
                {
                    ctPXuatHuy = new Entities.ChiTietXuatHuy[0];
                    return;
                }
            }
            catch
            {
            }
        }
        #endregion
        #region Lấy Chi Tiết Phiếu Xuất Hủy theo Mã
        public Entities.ChiTietXuatHuy[] LayChiTiet_XuatHuy_TheoMaPhieu(string maPXuatHuy)
        {
            try
            {
                int count = 0;

                for (int i = 0; i < ctPXuatHuy.Length; i++)
                {
                    if (ctPXuatHuy[i].MaPhieuXuatHuy == maPXuatHuy)
                    {
                        count++;
                    }
                }
                Entities.ChiTietXuatHuy[] ctPXuatHuy1 = new Entities.ChiTietXuatHuy[count];
                count = 0;

                for (int i = 0; i < ctPXuatHuy.Length; i++)
                {
                    if (ctPXuatHuy[i].MaPhieuXuatHuy == maPXuatHuy)
                    {
                        ctPXuatHuy1[count] = ctPXuatHuy[i];
                        count++;
                    }
                }

                if (ctPXuatHuy1 == null)
                {
                    ctPXuatHuy1 = new Entities.ChiTietXuatHuy[0];
                    return ctPXuatHuy1;
                }

                return ctPXuatHuy1;
            }
            catch
            {
                Entities.ChiTietXuatHuy[] ctPXuatHuy1 = new Entities.ChiTietXuatHuy[0];
                return ctPXuatHuy1;
            }
        }
        #endregion

        #region Lấy Phiếu Trả Lại Nhà Cung Cấp theo Ngày Tháng
        Entities.TraLaiNCC[] TraLaiNCC;
        public void LayTraLaiNCC()
        {
            try
            {
                Entities.TraLaiNCC[] TraLaiNCC1 = new Entities.TraLaiNCC[0];
                TraLaiNCC1 = new BizLogic.TraLaiNhaCungCap().Select();
                if (TraLaiNCC1 == null)
                {
                    TraLaiNCC = new Entities.TraLaiNCC[0];
                    return;
                }
                int count = 0;
                for (int i = 0; i < TraLaiNCC1.Length; i++)
                {
                    DateTime ngaylap = TraLaiNCC1[i].Ngaytra;
                    if (ngaylap >= BatDau && ngaylap <= KetThuc)
                    {
                        count++;
                    }
                }
                TraLaiNCC = new Entities.TraLaiNCC[count];
                count = 0;
                for (int i = 0; i < TraLaiNCC1.Length; i++)
                {
                    DateTime ngaylap = TraLaiNCC1[i].Ngaytra;
                    if (ngaylap >= BatDau && ngaylap <= KetThuc)
                    {
                        TraLaiNCC[count] = TraLaiNCC1[i];
                        count++;
                    }
                }

            }
            catch
            {
            }
        }
        #endregion
        #region Lấy Phiếu Trả Lại Nhà Cung Cấp theo Kho
        Entities.TraLaiNCC[] TraLaiNCC_TheoMaKho;
        public void LayTraLaiNCC_TheoMaKho(string maKho)
        {
            int count = 0;
            for (int i = 0; i < TraLaiNCC.Length; i++)
            {
                if (TraLaiNCC[i].MaKho == maKho)
                {
                    count++;
                }
            }
            TraLaiNCC_TheoMaKho = new Entities.TraLaiNCC[count];
            count = 0;
            for (int i = 0; i < TraLaiNCC.Length; i++)
            {
                if (TraLaiNCC[i].MaKho == maKho)
                {
                    TraLaiNCC_TheoMaKho[count] = TraLaiNCC[i];
                    count++;
                }
            }
        }
        #endregion
        #region Lấy Chi tiết Phiếu trả lại NCC
        Entities.ChiTietTraLaiNhaCungCap[] ctTraLaiNCC;
        public void LayChiTiet_TraLaiNCC()
        {
            ctTraLaiNCC = new Entities.ChiTietTraLaiNhaCungCap[0];
            ctTraLaiNCC = new BizLogic.ChiTietTraLaiNhaCungCap().Select();
            if (ctTraLaiNCC == null)
            {
                ctTraLaiNCC = new Entities.ChiTietTraLaiNhaCungCap[0];

                return;
            }

        }
        #endregion
        #region Lấy Chi tiết Phiếu trả lại NCC theo ma phieu
        public Entities.ChiTietTraLaiNhaCungCap[] LayChiTiet_TraLaiNCC_TheoMaPhieu(string maPTLNCC)
        {
            int count = 0;
            for (int i = 0; i < ctTraLaiNCC.Length; i++)
            {
                if (ctTraLaiNCC[i].MaHDTraLaiNCC == maPTLNCC)
                {
                    count++;
                }
            }
            Entities.ChiTietTraLaiNhaCungCap[] ctTLNCC1 = new Entities.ChiTietTraLaiNhaCungCap[count];
            count = 0;
            for (int i = 0; i < ctTraLaiNCC.Length; i++)
            {
                if (ctTraLaiNCC[i].MaHDTraLaiNCC == maPTLNCC)
                {
                    ctTLNCC1[count] = ctTraLaiNCC[i];
                    count++;
                }
            }
            if (ctTLNCC1 == null)
            {
                ctTLNCC1 = new Entities.ChiTietTraLaiNhaCungCap[0];
                return ctTLNCC1;
            }
            return ctTLNCC1;

        }
        #endregion

        #region lấy hóa đơn nhập theo ngày tháng
        Entities.HoaDonNhap[] HoaDonNhap;
        public void LayHDNhap()
        {
            try
            {
                Entities.HoaDonNhap[] HDN = new Entities.HoaDonNhap[0];
                HDN = new BizLogic.HoaDonNhap().Select();
                if (HDN == null)
                {
                    HoaDonNhap = new Entities.HoaDonNhap[0];
                    return;
                }
                int count = 0;
                for (int i = 0; i < HDN.Length; i++)
                {
                    DateTime ngaylap = HDN[i].NgayNhap;
                    if (ngaylap >= BatDau && ngaylap <= KetThuc)
                    {
                        count++;
                    }
                }
                Entities.HoaDonNhap[] HoaDonNhap1 = new Entities.HoaDonNhap[count];
                count = 0;
                for (int i = 0; i < HDN.Length; i++)
                {
                    DateTime ngaylap = HDN[i].NgayNhap;
                    if (ngaylap >= BatDau && ngaylap <= KetThuc)
                    {
                        HoaDonNhap1[count] = HDN[i];
                        count++;
                    }
                }
                if (HoaDonNhap1.Length == 0)
                {
                    HoaDonNhap = new Entities.HoaDonNhap[0];
                    return;
                }
                else
                    HoaDonNhap = HoaDonNhap1;

            }
            catch
            {
            }
        }
        #endregion
        #region  Lấy Hóa Đơn Nhập theo Mã kho
        Entities.HoaDonNhap[] HoaDonNhap_TheoMaKho;
        public void LayHoaDonNhap_TheoMaKho(string maKho)
        {
            int count = 0;
            for (int i = 0; i < HoaDonNhap.Length; i++)
            {
                if (HoaDonNhap[i].MaKho == maKho)
                {
                    count++;
                }
            }
            HoaDonNhap_TheoMaKho = new Entities.HoaDonNhap[count];
            count = 0;
            for (int i = 0; i < HoaDonNhap.Length; i++)
            {
                if (HoaDonNhap[i].MaKho == maKho)
                {
                    HoaDonNhap_TheoMaKho[count] = HoaDonNhap[i];
                    count++;
                }
            }
        }
        #endregion
        #region Lấy Chi tiết HDN
        public Entities.ChiTietHoaDonNhap[] ctHDN;
        public void LayChiTietHoaDonNhap()
        {
            Entities.ChiTietHoaDonNhap[] ctHDN1 = new Entities.ChiTietHoaDonNhap[0];
            ctHDN1 = new BizLogic.ChiTietHoaDonNhap().Select();
            if (ctHDN1 == null)
            {
                ctHDN = new Entities.ChiTietHoaDonNhap[0];
                return;
            }
            else
                ctHDN = ctHDN1;
        }
        #endregion
        #region Lấy Chi tiết HDN Theo Mã HDN
        public Entities.ChiTietHoaDonNhap[] LayChiTietHoaDonNhap_TheoMaHD(string maHDNhap)
        {
            if (ctHDN.Length == 0)
            {
                return new Entities.ChiTietHoaDonNhap[0];
            }
            else
            {
                int count = 0;
                for (int i = 0; i < ctHDN.Length; i++)
                {
                    if (ctHDN[i].MaHoaDonNhap == maHDNhap)
                    {
                        count++;
                    }
                }
                Entities.ChiTietHoaDonNhap[] ctHDN1 = new Entities.ChiTietHoaDonNhap[count];
                count = 0;
                for (int i = 0; i < ctHDN.Length; i++)
                {
                    if (ctHDN[i].MaHoaDonNhap == maHDNhap)
                    {
                        ctHDN1[count] = ctHDN[i];
                        count++;
                    }
                }
                if (ctHDN1.Length == 0)
                {
                    return new Entities.ChiTietHoaDonNhap[0];
                }
                else
                    return ctHDN1;
            }
        }
        #endregion

        #region lấy Khách Hàng Trả Lại theo ngày tháng
        Entities.KhachHangTraLai[] KHTL;
        public void LayKHTL()
        {
            try
            {
                Entities.KhachHangTraLai[] HDN = new Entities.KhachHangTraLai[1];
                HDN = new BizLogic.KhachHangTraLai().Select();


                if (HDN == null)
                {
                    KHTL = new Entities.KhachHangTraLai[0];
                    return;
                }
                int count = 0;
                for (int i = 0; i < HDN.Length; i++)
                {
                    DateTime ngaylap = HDN[i].NgayNhap;
                    if (ngaylap >= BatDau && ngaylap <= KetThuc)
                    {
                        count++;
                    }
                }
                Entities.KhachHangTraLai[] khtl1 = new Entities.KhachHangTraLai[count];
                count = 0;
                for (int i = 0; i < HDN.Length; i++)
                {
                    DateTime ngaylap = HDN[i].NgayNhap;
                    if (ngaylap >= BatDau && ngaylap <= KetThuc)
                    {
                        khtl1[count] = HDN[i];
                        count++;
                    }
                }
                if (khtl1.Length == 0)
                {
                    KHTL = new Entities.KhachHangTraLai[0];
                    return;
                }
                else
                    KHTL = khtl1;

            }
            catch
            {
            }
        }
        #endregion
        #region  Lấy Khách Hàng Trả Lại theo Mã kho
        Entities.KhachHangTraLai[] KHTL_TheoMaKho;
        public void LayKHTL_TheoMaKho(string maKho)
        {
            int count = 0;
            for (int i = 0; i < KHTL.Length; i++)
            {
                if (KHTL[i].MaKho == maKho)
                {
                    count++;
                }
            }
            KHTL_TheoMaKho = new Entities.KhachHangTraLai[count];
            count = 0;
            for (int i = 0; i < KHTL.Length; i++)
            {
                if (KHTL[i].MaKho == maKho)
                {
                    KHTL_TheoMaKho[count] = KHTL[i];
                    count++;
                }
            }
        }
        #endregion
        #region lấy Chi tiết Khách Hàng Trả Lại
        Entities.ChiTietKhachHangTraLai[] CTKHTL;
        public void LayCTKHTL()
        {
            try
            {
                Entities.ChiTietKhachHangTraLai[] HDN = new Entities.ChiTietKhachHangTraLai[0];
                HDN = new BizLogic.ChiTietKhachHangTraLai().Select();
                if (HDN == null)
                {
                    CTKHTL = new Entities.ChiTietKhachHangTraLai[0];
                    return;
                }

                CTKHTL = HDN;
            }
            catch
            {
            }
        }
        #endregion
        #region lấy Chi tiết Khách Hàng Trả Lại theo Mã phiếu

        public Entities.ChiTietKhachHangTraLai[] LayCTKHTL_TheoMaPhieu(string MaPhieu)
        {
            try
            {

                if (CTKHTL.Length == 0)
                {
                    return new Entities.ChiTietKhachHangTraLai[0];
                }
                else
                {
                    int count = 0;
                    for (int i = 0; i < CTKHTL.Length; i++)
                    {
                        if (CTKHTL[i].MaKhachHangTraLai == MaPhieu)
                        {
                            count++;
                        }
                    }
                    Entities.ChiTietKhachHangTraLai[] CTKHTL1 = new Entities.ChiTietKhachHangTraLai[count];
                    count = 0;
                    for (int i = 0; i < CTKHTL.Length; i++)
                    {
                        if (CTKHTL[i].MaKhachHangTraLai == MaPhieu)
                        {
                            CTKHTL1[count] = CTKHTL[i];
                            count++;
                        }
                    }

                    if (CTKHTL1.Length == 0)
                    {

                        return new Entities.ChiTietKhachHangTraLai[0];
                    }

                    return CTKHTL1;
                }
            }
            catch
            {
                return new Entities.ChiTietKhachHangTraLai[0];
            }
        }
        #endregion

        #region Lấy Chi Tiết Hàng Hóa trong kho
        Entities.SoDuKho[] ctBCXH;
        Entities.ChiTietKhoHangTheoHoaHonNhap[] ctHangHoaTheoKho;
        public void LayChiTiet_HangHoaXuat()
        {
            try
            {
               
                Entities.ChiTietKhoHangTheoHoaHonNhap[] kh1 = new Entities.ChiTietKhoHangTheoHoaHonNhap[1];
                kh1 = new ChiTietKhoHangTheoHoaHonNhap().Select();
                if (kh1 == null)
                {
                    ctHangHoaTheoKho = new Entities.ChiTietKhoHangTheoHoaHonNhap[0];
                    ctBCXH = new Entities.SoDuKho[0];
                    return;
                }
                ctHangHoaTheoKho = kh1;

                ctBCXH = new Entities.SoDuKho[ctHangHoaTheoKho.Length];
                for (int i = 0; i < ctHangHoaTheoKho.Length; i++)
                {
                    ctBCXH[i] = new Entities.SoDuKho();
                    ctBCXH[i].MaKho = ctHangHoaTheoKho[i].Makho;
                    ctBCXH[i].MaHangHoa = ctHangHoaTheoKho[i].Mahanghoa;
                    ctBCXH[i].SoDuDauKy = 0;
                    ctBCXH[i].SoDuCuoiKy = 0;
                    ctBCXH[i].PhatSinhNo = 0;
                    ctBCXH[i].PhatSinhCo = 0;
                }
                Entities.SoDuKho[] sdk1 = LaySoDuKhoTheoNgay(DateTime.Now.Month, DateTime.Now.Year);
                for (int i = 0; i < sdk1.Length; i++)
                {
                    for (int j = 0; j < ctBCXH.Length; j++)
                    {
                        if (sdk1[i].MaKho == ctBCXH[j].MaKho && sdk1[i].MaHangHoa == ctBCXH[j].MaHangHoa)
                        {
                            ctBCXH[j].SoDuDauKy = sdk1[i].SoDuDauKy;
                        }
                    }

                }
            }
            catch
            {
            }
        }
        #endregion
        #region Tính phát sinh >>> Tính Dư Cuối Kỳ
        public void LayChiTiet_SoKho()
        {
            try
            {
                for (int i = 0; i < ctBCXH.Length; i++)
                {

                    // Tính Tổng Số Lượng Hàng Hóa Xuất Trong HD Bán Hàng 
                    for (int j = 0; j < HDBanHang_TheoKho.Length; j++)
                    {
                        string makho = HDBanHang_TheoKho[j].MaKho;
                        Entities.ChiTietHDBanHang[] ctHDBanHang1 = LayChiTiet_HDBanHang_TheoMaPhieu(HDBanHang_TheoKho[j].MaHDBanHang);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trong HD bán Hàng  vào ctBCXH
                        for (int k = 0; k < ctHDBanHang1.Length; k++)
                        {
                            if (ctBCXH[i].MaHangHoa == ctHDBanHang1[k].MaHangHoa && ctBCXH[i].MaKho == makho)
                            {
                                ctBCXH[i].PhatSinhCo = ctBCXH[i].PhatSinhCo + ctHDBanHang1[k].SoLuong;
                            }
                        }
                    }
                    // Tính Tổng Số Lượng Hàng Hóa Xuất trong Trong Điều Chuyển Kho(Kho Đi)
                    for (int j = 0; j < PDieuChuyen_TheoKhoDi.Length; j++)
                    {
                        string makho = PDieuChuyen_TheoKhoDi[j].TuKho;
                        Entities.ChiTietPhieuDieuChuyenKho[] ctPDCK1 = LayChiTiet_PhieuDieuChuyenKho_TheoMaPhieu(PDieuChuyen_TheoKhoDi[j].MaPhieuDieuChuyenKho);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trong HD bán Hàng  vào ctBCXH
                        for (int k = 0; k < ctPDCK1.Length; k++)
                        {
                            if (ctBCXH[i].MaHangHoa == ctPDCK1[k].MaHangHoa && ctBCXH[i].MaKho == makho)
                            {
                                ctBCXH[i].PhatSinhCo = ctBCXH[i].PhatSinhCo + ctPDCK1[k].SoLuong;
                            }
                        }
                    }


                    // Tính Tổng Số Lượng Hàng Hóa Xuất Trong Phiếu Xuất Hủy
                    for (int j = 0; j < PXuatHuy_TheoMaKho.Length; j++)
                    {
                        string makho = PXuatHuy_TheoMaKho[j].MaKho;
                        Entities.ChiTietXuatHuy[] ctPXuatHuy1 = LayChiTiet_XuatHuy_TheoMaPhieu(PXuatHuy_TheoMaKho[j].MaPhieuXuatHuy);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trong Phiếu Xuất Hủy vào ctBCXH
                        for (int k = 0; k < ctPXuatHuy1.Length; k++)
                        {
                            if (ctBCXH[i].MaHangHoa == ctPXuatHuy1[k].MaHangHoa && ctBCXH[i].MaKho == makho)
                            {
                                ctBCXH[i].PhatSinhCo = ctBCXH[i].PhatSinhCo + ctPXuatHuy1[k].SoLuong;

                            }
                        }

                    }

                    // Tính Tổng Số Lượng Hàng Hóa Xuất Trong Trả Lại NCC
                    for (int j = 0; j < TraLaiNCC_TheoMaKho.Length; j++)
                    {
                        string makho = TraLaiNCC_TheoMaKho[j].MaKho;
                        Entities.ChiTietTraLaiNhaCungCap[] ctTraLaiNCC1 = LayChiTiet_TraLaiNCC_TheoMaPhieu(TraLaiNCC_TheoMaKho[j].MaHDTraLaiNCC);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trả Lại NCC vào ctBCXH
                        for (int k = 0; k < ctTraLaiNCC1.Length; k++)
                        {
                            if (ctBCXH[i].MaHangHoa == ctTraLaiNCC1[k].MaHangHoa && ctBCXH[i].MaKho == makho)
                            {
                                ctBCXH[i].PhatSinhCo = ctBCXH[i].PhatSinhCo + ctTraLaiNCC1[k].SoLuong;
                            }
                        }

                    }

                    // Tính Tổng Số Lượng Hàng Hóa NHập trong Trong KH Trả Lại
                    for (int j = 0; j < KHTL_TheoMaKho.Length; j++)
                    {
                        string makho = KHTL_TheoMaKho[j].MaKho;
                        Entities.ChiTietKhachHangTraLai[] ctkhtl1 = LayCTKHTL_TheoMaPhieu(KHTL_TheoMaKho[j].MaKhachHangTraLai);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trả Lại NCC vào ctBCXH
                        for (int k = 0; k < ctkhtl1.Length; k++)
                        {
                            if (ctBCXH[i].MaHangHoa == ctkhtl1[k].MaHangHoa && ctBCXH[i].MaKho == makho)
                            {
                                ctBCXH[i].PhatSinhNo = ctBCXH[i].PhatSinhNo + ctkhtl1[k].SoLuong;
                            }
                        }

                    }
                    // Tính Tổng Số Lượng Hàng Hóa NHập trong Trong Điều Chuyển Kho(Kho Đến)
                    for (int j = 0; j < PDieuChuyen_TheoKhoDen.Length; j++)
                    {
                        string makho = PDieuChuyen_TheoKhoDen[j].DenKho;
                        Entities.ChiTietPhieuDieuChuyenKho[] ctPdck1 = LayChiTiet_PhieuDieuChuyenKho_TheoMaPhieu(PDieuChuyen_TheoKhoDen[j].MaPhieuDieuChuyenKho);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trả Lại NCC vào ctBCXH
                        for (int k = 0; k < ctPdck1.Length; k++)
                        {
                            if (ctBCXH[i].MaHangHoa == ctPdck1[k].MaHangHoa && ctBCXH[i].MaKho == makho)
                            {
                                ctBCXH[i].PhatSinhNo = ctBCXH[i].PhatSinhNo + ctPdck1[k].SoLuong;
                            }
                        }

                    }
                    // Tính Tổng Số Lượng Hàng Hóa NHập trong Trong HD Nhập
                    for (int j = 0; j < HoaDonNhap_TheoMaKho.Length; j++)
                    {
                        string makho = HoaDonNhap_TheoMaKho[j].MaKho;
                        Entities.ChiTietHoaDonNhap[] ctHDNhap = LayChiTietHoaDonNhap_TheoMaHD(HoaDonNhap_TheoMaKho[j].MaHoaDonNhap);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trả Lại NCC vào ctBCXH
                        for (int k = 0; k < ctHDNhap.Length; k++)
                        {
                            if (ctBCXH[i].MaHangHoa == ctHDNhap[k].MaHangHoa && ctBCXH[i].MaKho == makho)
                            {
                                ctBCXH[i].PhatSinhNo = ctBCXH[i].PhatSinhNo + ctHDNhap[k].SoLuong;
                            }
                        }
                    }
                    ctBCXH[i].SoDuCuoiKy = ctBCXH[i].SoDuDauKy + ctBCXH[i].PhatSinhNo - ctBCXH[i].PhatSinhCo;
                }

            }
            catch
            {

            }
        }
        #endregion

        #region LayID
        public string LayID(string tenBang)
        {
            string idnew = "";
            Entities.LayID lid = new Entities.LayID();

            lid = (Entities.LayID)new BizLogic.Lay_ID().Select(lid);
            if (lid != null)
            {
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
            }
            else
            {
                if (lid == null)
                {
                    idnew = "SDK_0001";
                }
            }
            return idnew;
        }
        #endregion
        public void ArrTongHangXuat()
        {
            for (int i = 0; i < khohang.Length; i++)
            {
                LayHDBanHang_TheoKho(khohang[i].MaKho);
                LayPhieuDieuChuyenKhoNoiBo_TheoKhoDi(khohang[i].MaKho);
                LayPhieuXuatHuy_TheoMaKho(khohang[i].MaKho);
                LayTraLaiNCC_TheoMaKho(khohang[i].MaKho);

                LayKHTL_TheoMaKho(khohang[i].MaKho);
                LayPhieuDieuChuyenKhoNoiBo_TheoKhoDen(khohang[i].MaKho);
                LayHoaDonNhap_TheoMaKho(khohang[i].MaKho);
                LayChiTiet_SoKho();
            }
        }
        public void DeleteToDataBase()
        {
            Entities.SoDuKho[] sdk1 = LaySoDuKhoTheoNgay(DateTime.Now.Month, DateTime.Now.Year);
            new BizLogic.SoDuKho().DeleteArr(sdk1);
        }
        public void InsertToDataBase1()
        {
           
            for (int i = 0; i < ctBCXH.Length; i++)
            {
                ctBCXH[i].MaSoDuKho = LayID("SoDuKho");
                ctBCXH[i].TrangThai = true;
                ctBCXH[i].HanhDong = "Insert";
                ctBCXH[i].NgayKetChuyen = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
            new BizLogic.SoDuKho().InsertArr(ctBCXH);
        }
        public void InsertToDataBase2()
        {
            for (int i = 0; i < ctBCXH.Length; i++)
            {
                ctBCXH[i].MaSoDuKho = LayID("SoDuKho");
                ctBCXH[i].TrangThai = false;
                ctBCXH[i].HanhDong = "Insert";
                int nam = 2011, thang = 1;
                if (DateTime.Now.Month == 12)
                {
                    nam = DateTime.Now.Year + 1;
                    thang = 1;
                }
                else
                {
                    nam = DateTime.Now.Year;
                    thang = DateTime.Now.Month + 1;
                }
                ctBCXH[i].NgayKetChuyen = new DateTime(nam, thang, 1);
                ctBCXH[i].SoDuDauKy = ctBCXH[i].SoDuCuoiKy;
                ctBCXH[i].SoDuCuoiKy = 0;
            }

            new BizLogic.SoDuKho().InsertArr(ctBCXH);
        }

        public void KetChuyen()
        {
            LayPhieuXuatHuy();
            LayChiTiet_XuatHuy();
            LayHDBanHang();
            LayChiTiet_HDBanHang();
            LayTraLaiNCC();
            LayChiTiet_TraLaiNCC();
            LayPhieuDieuChuyenKhoNoiBo();
            LayChiTiet_PhieuDieuChuyenKho();

            LayHDNhap();
            LayChiTietHoaDonNhap();
            LayKHTL();
            LayCTKHTL();
            LayChiTiet_HangHoaXuat();
            ArrTongHangXuat();




            int k = 0;
            if (k == 0)
            {
                DeleteToDataBase();
                k++;
            }
            if (k == 1)
            {
                InsertToDataBase1();
                k++;
            }
            if (k == 2)
            {
                InsertToDataBase2();
                k = 0;
            }
        }
    }
}
