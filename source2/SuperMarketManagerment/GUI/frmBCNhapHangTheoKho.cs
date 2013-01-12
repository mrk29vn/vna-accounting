using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Entities;

namespace GUI
{
    public partial class frmBCNhapHangTheoKho : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;

        BCNhapHangTheoKho[] ctBCXH_Search;
        DateTime datesv;
        public frmBCNhapHangTheoKho()
        {
            InitializeComponent();
            datesv = DateServer.Date();
        }
        private void tsslthoat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void pntop_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
        public bool KiemTra()
        {
            if (cbbthang.Text == "")
            {
                MessageBox.Show("Bạn Chưa Nhập Tháng", "Hệ thống cánh bảo");
                cbbthang.Focus();
                return false;
            }
            if (cbbnam.Text == "")
            {
                MessageBox.Show("Bạn Chưa Nhập Năm", "Hệ thống cánh bảo");
                cbbnam.Focus();
                return false;
            }
            return true;
        }

        ////////////////////////////////////MRK FIX
        Entities.GoiHang[] goihang;
        public void GoiHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("GH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                goihang = (Entities.GoiHang[])cl.DeserializeHepper1(clientstrem, goihang);
                if (goihang == null)
                {
                    goihang = new Entities.GoiHang[0];
                    return;
                }
            }
            catch { }
        }
        Entities.ChiTietGoiHang[] chitietgoihang;
        public void ChiTietGoiHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTGH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                chitietgoihang = (Entities.ChiTietGoiHang[])cl.DeserializeHepper1(clientstrem, chitietgoihang);
                if (chitietgoihang == null)
                {
                    chitietgoihang = new Entities.ChiTietGoiHang[0];
                    return;
                }
            }
            catch { }
        }
        ////////////////////////////////////////////

        #region lấy Khách Hàng Trả Lại theo ngày tháng
        Entities.KhachHangTraLai[] KHTL;
        public void LayKHTL()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KhachHangTraLai KHTL1 = new Entities.KhachHangTraLai("Select");
                clientstrem = cl.SerializeObj(this.client1, "KHTL", KHTL1);
                Entities.KhachHangTraLai[] HDN = new Entities.KhachHangTraLai[1];
                HDN = (Entities.KhachHangTraLai[])cl.DeserializeHepper(clientstrem, HDN);
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
            catch { }
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
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTKHTL");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                Entities.ChiTietKhachHangTraLai[] HDN = new Entities.ChiTietKhachHangTraLai[0];
                HDN = (Entities.ChiTietKhachHangTraLai[])cl.DeserializeHepper1(clientstrem, HDN);
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

        #region Lấy Phiếu Điều Chuyển Kho theo Ngày Tháng
        Entities.PhieuDieuChuyenKhoNoiBo[] PDieuChuyen;
        public void LayPhieuDieuChuyenKhoNoiBo()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.PhieuDieuChuyenKhoNoiBo ctxh = new Entities.PhieuDieuChuyenKhoNoiBo("Select", 1);
                clientstrem = cl.SerializeObj(this.client1, "PhieuDieuCHuyenKhoNoiBo", ctxh);
                Entities.PhieuDieuChuyenKhoNoiBo[] PDieuChuyen1 = new Entities.PhieuDieuChuyenKhoNoiBo[0];
                PDieuChuyen1 = (Entities.PhieuDieuChuyenKhoNoiBo[])cl.DeserializeHepper1(clientstrem, PDieuChuyen1);
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
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.ChiTietPhieuDieuChuyenKho ctxh = new Entities.ChiTietPhieuDieuChuyenKho("Select");
            clientstrem = cl.SerializeObj(this.client1, "ChiTietPhieuDieuCHuyenKhoNoiBo", ctxh);
            ctPDCK = new Entities.ChiTietPhieuDieuChuyenKho[0];
            ctPDCK = (Entities.ChiTietPhieuDieuChuyenKho[])cl.DeserializeHepper1(clientstrem, ctPDCK);
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

        #region lấy hóa đơn nhập theo ngày tháng
        Entities.HoaDonNhap[] HoaDonNhap;
        public void LayHDNhap()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("HDN", "");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                Entities.HoaDonNhap[] HDN = new Entities.HoaDonNhap[0];
                HDN = (Entities.HoaDonNhap[])cl.DeserializeHepper1(clientstrem, HDN);
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
            catch { }
        }
        #endregion
        #region  Lấy Hóa Đơn Nhập theo Mã kho
        Entities.HoaDonNhap[] HoaDonNhap_TheoMaKho;
        public void LayHoaDonNhap_TheoMaKho(string maKho)
        {
            try
            {
                List<Entities.HoaDonNhap> L = new List<HoaDonNhap>();
                foreach (Entities.HoaDonNhap item in HoaDonNhap)
                {
                    if (item.MaKho.ToUpper().Equals(maKho.ToUpper()))
                    {
                        L.Add(item);
                    }
                }
                HoaDonNhap_TheoMaKho = L.ToArray();
            }
            catch { }
        }
        #endregion
        #region Lấy Chi tiết HDN
        public Entities.ChiTietHoaDonNhap[] ctHDN;
        public void LayChiTietHoaDonNhap()
        {
            ctHDN = new Entities.ChiTietHoaDonNhap[0];
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("CTHDN", "");
            clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
            Entities.ChiTietHoaDonNhap[] ctHDN1 = new Entities.ChiTietHoaDonNhap[0];
            ctHDN1 = (Entities.ChiTietHoaDonNhap[])cl.DeserializeHepper1(clientstrem, ctHDN1);
            if (ctHDN1 == null)
            {
                return;
            }
            else
                ctHDN = ctHDN1;
        }
        #endregion
        #region Lấy Chi tiết HDN Theo Mã HDN
        public Entities.ChiTietHoaDonNhap[] LayChiTietHoaDonNhap_TheoMaHD(string maHDNhap)
        {
            try
            {
                List<Entities.ChiTietHoaDonNhap> L = new List<ChiTietHoaDonNhap>();
                foreach (Entities.ChiTietHoaDonNhap item in ctHDN)
                {
                    if (item.MaHoaDonNhap.ToUpper().Equals(maHDNhap.ToUpper()))
                    {
                        L.Add(item);
                    }
                }
                return L.ToArray();
            }
            catch { return new Entities.ChiTietHoaDonNhap[0]; }
        }
        #endregion

        #region Lấy Bảng Kho Hàng
        public Entities.KhoHang[] khohang;
        public void LayKhoHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "KhoHang", new Entities.KhoHang("Select"));
                khohang = (Entities.KhoHang[])cl.DeserializeHepper1(clientstrem, khohang);
                if (khohang == null)
                {
                    khohang = new Entities.KhoHang[0];
                    return;
                }
            }
            catch { }
        }
        #endregion
        #region Lấy Chi Tiết Hàng Hóa trong 1 kho
        Entities.ChiTietKhoHangTheoHoaHonNhap[] ctHangHoaTheoKho;
        public void LayChiTiet_HangHoaXuat()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.ChiTietKhoHangTheoHoaHonNhap nv = new Entities.ChiTietKhoHangTheoHoaHonNhap("Select");
                clientstrem = cl.SerializeObj(this.client1, "ChiTietKho", nv);
                Entities.ChiTietKhoHangTheoHoaHonNhap[] kh1 = new Entities.ChiTietKhoHangTheoHoaHonNhap[1];
                kh1 = (Entities.ChiTietKhoHangTheoHoaHonNhap[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 == null)
                {
                    ctHangHoaTheoKho = new Entities.ChiTietKhoHangTheoHoaHonNhap[0];
                    return;
                }
                ctHangHoaTheoKho = kh1;
            }
            catch { }
        }
        #endregion
        #region Lấy Chi Tiết Hàng Hóa trong 1 kho
        Entities.CTBCNhapHangTheoKho[] ctBCXH;
        public void LayChiTiet_HangHoaXuat_TheoKho(string maKho, string tenKho)
        {
            try
            {
                int count = 0;
                for (int i = 0; i < ctHangHoaTheoKho.Length; i++)
                {
                    if (ctHangHoaTheoKho[i].Makho == maKho)
                    {
                        count++;
                    }
                }
                Entities.ChiTietKhoHangTheoHoaHonNhap[] ctkho = new Entities.ChiTietKhoHangTheoHoaHonNhap[count];
                count = 0;

                for (int i = 0; i < ctHangHoaTheoKho.Length; i++)
                {
                    if (ctHangHoaTheoKho[i].Makho == maKho)
                    {
                        ctkho[count] = ctHangHoaTheoKho[i];
                        count++;
                    }
                }

                ctBCXH = new Entities.CTBCNhapHangTheoKho[count];
                for (int i = 0; i < ctkho.Length; i++)
                {
                    ctBCXH[i] = new Entities.CTBCNhapHangTheoKho();
                    ctBCXH[i].MaKho = ctkho[i].Makho;
                    ctBCXH[i].TenKho = tenKho;
                    ctBCXH[i].MaHangHoa = ctkho[i].Mahanghoa;
                    ctBCXH[i].TongSoLuongNhap = 0;
                    for (int j = 0; j < HangHoa.Length; j++)
                    {
                        if (HangHoa[j].MaHangHoa == ctBCXH[i].MaHangHoa)
                        {
                            ctBCXH[i].TenHangHoa = HangHoa[j].TenHangHoa;
                            break;
                        }
                    }
                }
            }
            catch { }
        }
        #endregion

        public Entities.BCNhapHangTheoKho[] ArrBCXH;
        public void ArrTongHangXuat()
        {
            ArrBCXH = new Entities.BCNhapHangTheoKho[khohang.Length];
            for (int i = 0; i < khohang.Length; i++)
            {
                LayHoaDonNhap_TheoMaKho(khohang[i].MaKho);
                LayKHTL_TheoMaKho(khohang[i].MaKho);
                LayPhieuDieuChuyenKhoNoiBo_TheoKhoDen(khohang[i].MaKho);
                LayChiTiet_HangHoaXuat_TheoKho(khohang[i].MaKho,khohang[i].TenKho);
                LayChiTiet_SoLuong_HangHoaNhap_TheoKho();
                ArrBCXH[i] = new Entities.BCNhapHangTheoKho();

                int TongHangHoaXuatTheoKho = 0;
                for (int j = 0; j < ctBCXH.Length; j++)
                {
                    TongHangHoaXuatTheoKho = TongHangHoaXuatTheoKho + ctBCXH[j].TongSoLuongNhap;
                }
                ArrBCXH[i].MaKho = khohang[i].MaKho;
                ArrBCXH[i].TenKho = khohang[i].TenKho;
                ArrBCXH[i].TongSoLuongNhap = TongHangHoaXuatTheoKho;
                ctBCXH = null;
            }
        }
        DateTime BatDau, KetThuc;
        public void LayNgay()
        {
            BatDau = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), 1);
            KetThuc = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), DateTime.DaysInMonth(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text)));
        }
        private bool GoiHangOrHangHoa(string ma)
        {// Gói hàng: true  | Hàng hóa: false
            bool kq = false;
            foreach (Entities.GoiHang item in this.goihang)
            {
                if (item.MaGoiHang.Equals(ma))
                {
                    kq = true;
                    break;
                }
            }
            return kq;
        }
        public void LayChiTiet_SoLuong_HangHoaNhap_TheoKho()
        {
            try
            {
                for (int i = 0; i < ctBCXH.Length; i++)
                {
                    // Tính Tổng Số Lượng Hàng Hóa Xuất Trong HD Bán Hàng 
                    for (int j = 0; j < HoaDonNhap_TheoMaKho.Length; j++)
                    {
                        string makho = HoaDonNhap_TheoMaKho[j].MaKho;
                        //Lấy Chi Tiết HD Bán Hàng Theo Ma Hóa Đơn
                        Entities.ChiTietHoaDonNhap[] ctHDNhap = LayChiTietHoaDonNhap_TheoMaHD(HoaDonNhap_TheoMaKho[j].MaHoaDonNhap);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trong HD bán Hàng  vào ctBCXH
                        for (int k = 0; k < ctHDNhap.Length; k++)
                        {
                            if (ctBCXH[i].MaHangHoa == ctHDNhap[k].MaHangHoa && ctBCXH[i].MaKho==makho)
                            {
                                ctBCXH[i].TongSoLuongNhap = ctBCXH[i].TongSoLuongNhap + ctHDNhap[k].SoLuong;
                            }
                        }
                    }
                    // Tính Tổng Số Lượng Hàng Hóa Xuất Trong phiếu điều chuyển kho
                    for (int j = 0; j < PDieuChuyen_TheoKhoDen.Length; j++)
                    {
                        string makho = PDieuChuyen_TheoKhoDen[j].DenKho;
                        //Lấy Chi Tiết HD Bán Hàng Theo Ma Hóa Đơn
                        Entities.ChiTietPhieuDieuChuyenKho[] ctPDCK1 = LayChiTiet_PhieuDieuChuyenKho_TheoMaPhieu(PDieuChuyen_TheoKhoDen[j].MaPhieuDieuChuyenKho);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trong HD bán Hàng  vào ctBCXH
                        for (int k = 0; k < ctPDCK1.Length; k++)
                        {
                            if (ctBCXH[i].MaKho == makho)
                            {
                                ////////////////////////////////////////////////MRK FIX
                                if (!GoiHangOrHangHoa(ctPDCK1[k].MaHangHoa))
                                {
                                    if (ctBCXH[i].MaHangHoa == ctPDCK1[k].MaHangHoa)
                                    {
                                        ctBCXH[i].TongSoLuongNhap = ctBCXH[i].TongSoLuongNhap + ctPDCK1[k].SoLuong;
                                    }
                                }
                                else
                                {
                                    foreach (Entities.GoiHang gh in goihang)
                                    {
                                        foreach (Entities.ChiTietGoiHang ctgh in chitietgoihang)
                                        {
                                            if (gh.MaGoiHang.Equals(ctgh.MaGoiHang) && ctgh.MaGoiHang.Equals(ctPDCK1[k].MaHangHoa) && ctgh.MaHangHoa.Equals(ctBCXH[i].MaHangHoa))
                                            {
                                                ctBCXH[i].TongSoLuongNhap += (ctPDCK1[k].SoLuong * ctgh.SoLuong);
                                            }
                                        }
                                    }
                                }
                                ////////////////////////////////////////////////MRK FIX
                            }
                        }
                    }

                    for (int j = 0; j < KHTL_TheoMaKho.Length; j++)
                    {
                        string makho = KHTL_TheoMaKho[j].MaKho;
                        if (ctBCXH[i].MaKho == makho)
                        {
                            //Lấy Chi Tiết HD Bán Hàng Theo Ma Hóa Đơn
                            Entities.ChiTietKhachHangTraLai[] ctKHTL1 = LayCTKHTL_TheoMaPhieu(KHTL_TheoMaKho[j].MaKhachHangTraLai);
                            // Cộng dồn Số Lượng Từng Hàng Hóa Trong HD bán Hàng  vào ctBCXH
                            for (int k = 0; k < ctKHTL1.Length; k++)
                            {
                                if (!GoiHangOrHangHoa(ctKHTL1[k].MaHangHoa))
                                {
                                    if (ctBCXH[i].MaHangHoa == ctKHTL1[k].MaHangHoa)
                                    {
                                        ctBCXH[i].TongSoLuongNhap = ctBCXH[i].TongSoLuongNhap + ctKHTL1[k].SoLuong;
                                    }
                                }
                                ////////////////////////////////////////////////MRK FIX
                                else
                                {
                                    foreach (Entities.GoiHang gh in goihang)
                                    {
                                        foreach (Entities.ChiTietGoiHang ctgh in chitietgoihang)
                                        {
                                            if (gh.MaGoiHang.Equals(ctgh.MaGoiHang) && ctgh.MaGoiHang.Equals(ctKHTL1[k].MaHangHoa) && ctgh.MaHangHoa.Equals(ctBCXH[i].MaHangHoa))
                                            {
                                                ctBCXH[i].TongSoLuongNhap += (ctKHTL1[k].SoLuong * ctgh.SoLuong);
                                            }
                                        }
                                    }
                                }
                                ////////////////////////////////////////////////MRK FIX
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
        #region Lấy Bảng Hàng Hóa
        public Entities.HangHoa[] HangHoa;
        public void LayHangHoa()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.HangHoa ctxh = new Entities.HangHoa("Select");
                clientstrem = cl.SerializeObj(this.client1, "HangHoa", ctxh);
                HangHoa = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, HangHoa);
                if (HangHoa == null)
                {
                    HangHoa = new Entities.HangHoa[0];
                    return;
                }
            }
            catch { }
        }
        #endregion

        public void FixDatagridview()
        {
            dtgvhienthi.Columns["STT"].Visible = false;
            dtgvhienthi.Columns["MaKho"].HeaderText = "Mã Kho";
            dtgvhienthi.Columns["TenKho"].HeaderText = "Tên Kho";
            dtgvhienthi.Columns["TongSoLuongNhap"].HeaderText = "Tổng Số Lượng Nhập";
            dtgvhienthi.AllowUserToResizeRows = false;
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvhienthi.ReadOnly = true;
        }
        private void btnhienthi_Click(object sender, EventArgs e)
        {

            if (KiemTra())
            {
                LayNgay();
                LayKhoHang();
                LayHangHoa();
                LayHDNhap();
                LayChiTietHoaDonNhap();
                LayKHTL();
                LayCTKHTL();
                LayPhieuDieuChuyenKhoNoiBo();
                LayChiTiet_PhieuDieuChuyenKho();
                LayChiTiet_HangHoaXuat();
                ArrTongHangXuat();
                ///////////////////////////////MRK FIX
                List<Entities.BCNhapHangTheoKho> tem0 = new List<Entities.BCNhapHangTheoKho>();
                int tong0 = 0;
                foreach (Entities.BCNhapHangTheoKho item in ArrBCXH)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    tong0 += item.TongSoLuongNhap;
                    tem0.Add(item);
                }
                Entities.BCNhapHangTheoKho tem1 = new Entities.BCNhapHangTheoKho();
                tem1.TenKho = "Tổng: ";
                tem1.TongSoLuongNhap = tong0;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = ArrBCXH;
                dtgvhienthi.DataSource = tem0.ToArray();

               FixDatagridview();
               dtgvhienthi.Focus();
               ctBCXH_Search = ArrBCXH;
                if (ctHDN.Length > 0)
                {
                    tsslchitiet.Enabled = true;
                    tsslPdf.Enabled = true;
                    tsslExcel.Enabled = true;
                    tsslWord.Enabled = true;
                }
                else
                {
                    tsslchitiet.Enabled = false;
                    tsslPdf.Enabled = false;
                    tsslExcel.Enabled = false;
                    tsslWord.Enabled = false;
                }
            }
            
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            string makho = dtgvhienthi.CurrentRow.Cells["MaKho"].Value.ToString();
            string tenkho = dtgvhienthi.CurrentRow.Cells["TenKho"].Value.ToString();
            if ((int)dtgvhienthi.CurrentRow.Cells["TongSoLuongNhap"].Value == 0)
            {
                MessageBox.Show("Không có hàng nhập kho" + tenkho + " trong Khoảng từ ngày : " + xulyNgay(BatDau) + " đến " + xulyNgay(KetThuc) + " ");
            }
            else
            {
                LayHoaDonNhap_TheoMaKho(makho);
                LayKHTL_TheoMaKho(makho);
                LayPhieuDieuChuyenKhoNoiBo_TheoKhoDen(makho);


                LayChiTiet_HangHoaXuat_TheoKho(makho, tenkho);
                LayChiTiet_SoLuong_HangHoaNhap_TheoKho();
                frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH, BatDau, KetThuc);
                frm.ShowDialog();
            }
        }
        public string xulyNgay(DateTime dt)
        {
            string mk;
            string dd = dt.Day.ToString();
            if (dd.Length == 1)
            {
                dd = "0" + dd;
            }
            string mm = dt.Month.ToString();
            if (mm.Length == 1)
            {
                mm = "0" + mm;
            }
            string yyyy = dt.Year.ToString();

            mk = dd + "/" + mm + "/" + yyyy;

            return mk;
        }
        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            string makho = dtgvhienthi.Rows[e.RowIndex].Cells["MaKho"].Value.ToString();
            string tenkho = dtgvhienthi.Rows[e.RowIndex].Cells["TenKho"].Value.ToString();
            if ((int)dtgvhienthi.Rows[e.RowIndex].Cells["TongSoLuongNhap"].Value == 0)
            {
                MessageBox.Show("Không có hàng nhập kho" + tenkho + " trong Khoảng từ ngày : " + xulyNgay(BatDau) + " đến " + xulyNgay(KetThuc) + " ");
            }
            else
            {
                LayHoaDonNhap_TheoMaKho(makho);
                LayKHTL_TheoMaKho(makho);
                LayPhieuDieuChuyenKhoNoiBo_TheoKhoDen(makho);


                LayChiTiet_HangHoaXuat_TheoKho(makho, tenkho);
                LayChiTiet_SoLuong_HangHoaNhap_TheoKho();
                frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH, BatDau, KetThuc);
                frm.ShowDialog();

            }
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            string makho = dtgvhienthi.CurrentRow.Cells["MaKho"].Value.ToString();
            string tenkho = dtgvhienthi.CurrentRow.Cells["TenKho"].Value.ToString();
            if ((int)dtgvhienthi.CurrentRow.Cells["TongSoLuongNhap"].Value == 0)
            {
                MessageBox.Show("Không có hàng nhập kho" + tenkho + " trong Khoảng từ ngày : " + xulyNgay(BatDau) + " đến " + xulyNgay(KetThuc) + " ");
            }
            else
            {
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LayHoaDonNhap_TheoMaKho(makho);
                    LayKHTL_TheoMaKho(makho);
                    LayPhieuDieuChuyenKhoNoiBo_TheoKhoDen(makho);


                    LayChiTiet_HangHoaXuat_TheoKho(makho, tenkho);
                    LayChiTiet_SoLuong_HangHoaNhap_TheoKho();
                    frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH, BatDau, KetThuc,saveFileDialog1.FileName,"PDF");
                    frm.ShowDialog();
                }
            }
        }

        private void tsslWord_Click(object sender, EventArgs e)
        {
            string makho = dtgvhienthi.CurrentRow.Cells["MaKho"].Value.ToString();
            string tenkho = dtgvhienthi.CurrentRow.Cells["TenKho"].Value.ToString();
            if ((int)dtgvhienthi.CurrentRow.Cells["TongSoLuongNhap"].Value == 0)
            {
                MessageBox.Show("Không có hàng nhập kho" + tenkho + " trong Khoảng từ ngày : " + xulyNgay(BatDau) + " đến " + xulyNgay(KetThuc) + " ");
            }
            else
            {
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LayHoaDonNhap_TheoMaKho(makho);
                    LayKHTL_TheoMaKho(makho);
                    LayPhieuDieuChuyenKhoNoiBo_TheoKhoDen(makho);


                    LayChiTiet_HangHoaXuat_TheoKho(makho, tenkho);
                    LayChiTiet_SoLuong_HangHoaNhap_TheoKho();
                    frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH, BatDau, KetThuc, saveFileDialog1.FileName, "Word");
                    frm.ShowDialog();
                }
            }
        }

        private void tsslExcel_Click(object sender, EventArgs e)
        {
            string makho = dtgvhienthi.CurrentRow.Cells["MaKho"].Value.ToString();
            string tenkho = dtgvhienthi.CurrentRow.Cells["TenKho"].Value.ToString();
            if ((int)dtgvhienthi.CurrentRow.Cells["TongSoLuongNhap"].Value == 0)
            {
                MessageBox.Show("Không có hàng nhập kho" + tenkho + " trong Khoảng từ ngày : " + xulyNgay(BatDau) + " đến " + xulyNgay(KetThuc) + " ");
            }
            else
            {
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    LayHoaDonNhap_TheoMaKho(makho);
                    LayKHTL_TheoMaKho(makho);
                    LayPhieuDieuChuyenKhoNoiBo_TheoKhoDen(makho);


                    LayChiTiet_HangHoaXuat_TheoKho(makho, tenkho);
                    LayChiTiet_SoLuong_HangHoaNhap_TheoKho();
                    frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH, BatDau, KetThuc, saveFileDialog1.FileName, "Excel");
                    frm.ShowDialog();
                }
            }
        }

        private void frmBCNhapHangTheoKho_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < cbbthang.Items.Count; i++)
            {
                if (cbbthang.Items[i].ToString() == datesv.Month.ToString())
                {
                    cbbthang.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < cbbnam.Items.Count; i++)
            {
                if (cbbnam.Items[i].ToString() == datesv.Year.ToString())
                {
                    cbbnam.SelectedIndex = i;
                    break;
                }
            }
            LayNgay();
            LayKhoHang();
            LayHangHoa();
            GoiHang();
            ChiTietGoiHang();

            LayHDNhap();
            LayChiTietHoaDonNhap();

            LayKHTL();
            LayCTKHTL();

            LayPhieuDieuChuyenKhoNoiBo();
            LayChiTiet_PhieuDieuChuyenKho();

            LayChiTiet_HangHoaXuat();

            ArrTongHangXuat();
            ///////////////////////////////MRK FIX
            List<Entities.BCNhapHangTheoKho> tem0 = new List<Entities.BCNhapHangTheoKho>();
            int tong0 = 0;
            foreach (Entities.BCNhapHangTheoKho item in ArrBCXH)
            {
                if (item == null)
                {
                    continue;
                }
                tong0 += item.TongSoLuongNhap;
                tem0.Add(item);
            }
            Entities.BCNhapHangTheoKho tem1 = new Entities.BCNhapHangTheoKho();
            tem1.TenKho = "Tổng: ";
            tem1.TongSoLuongNhap = tong0;
            tem0.Add(tem1);
            //////////////////////////////////////
            //dtgvhienthi.DataSource = ArrBCXH;
            dtgvhienthi.DataSource = tem0.ToArray();

            FixDatagridview();
            dtgvhienthi.Focus();
            ctBCXH_Search = ArrBCXH;
            if (ctHDN.Length > 0)
            {
                tsslchitiet.Enabled = true;
                tsslPdf.Enabled = true;
                tsslExcel.Enabled = true;
                tsslWord.Enabled = true;
            }
            else
            {
                tsslchitiet.Enabled = false;
                tsslPdf.Enabled = false;
                tsslExcel.Enabled = false;
                tsslWord.Enabled = false;
            }
        }

        private void rdbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTatCa.Checked == true)
            {
                txtTimKiem.Text = "";
                if (ctBCXH_Search.Length > 0)
                {
                    tsslchitiet.Enabled = true;
                    tsslPdf.Enabled = true;
                    tsslExcel.Enabled = true;
                    tsslWord.Enabled = true;
                }
                else
                {
                    tsslchitiet.Enabled = false;
                    tsslPdf.Enabled = false;
                    tsslExcel.Enabled = false;
                    tsslWord.Enabled = false;
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCNhapHangTheoKho> tem0 = new List<Entities.BCNhapHangTheoKho>();
                int tong0 = 0;
                foreach (Entities.BCNhapHangTheoKho item in ctBCXH_Search)
                {
                    tong0 += item.TongSoLuongNhap;
                    tem0.Add(item);
                }
                Entities.BCNhapHangTheoKho tem1 = new Entities.BCNhapHangTheoKho();
                tem1.TenKho = "Tổng: ";
                tem1.TongSoLuongNhap = tong0;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = ctBCXH_Search;
                dtgvhienthi.DataSource = tem0.ToArray();

                FixDatagridview();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (rdbTen.Checked == true)
            {

                if (ctBCXH_Search == null)
                {
                    BCNhapHangTheoKho[] tkkt = new BCNhapHangTheoKho[0];
                    dtgvhienthi.DataSource = tkkt;
                    FixDatagridview();

                    tsslchitiet.Enabled = false;
                    tsslExcel.Enabled = false;
                    tsslPdf.Enabled = false;
                    tsslWord.Enabled = false;
                }
                else
                    if (ctBCXH_Search != null)
                    {
                        if (txtTimKiem.Text.Length == 0)
                        {
                            BCNhapHangTheoKho[] tkkt = new BCNhapHangTheoKho[0];
                            dtgvhienthi.DataSource = tkkt;
                            FixDatagridview();

                            tsslchitiet.Enabled = false;
                            tsslExcel.Enabled = false;
                            tsslPdf.Enabled = false;
                            tsslWord.Enabled = false;
                        }
                        else
                        {
                            int ctBCXH_Search_count = 0;

                            for (int i = 0; i < ctBCXH_Search.Length; i++)
                            {
                                int index = -1;
                                index = ctBCXH_Search[i].TenKho.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                if (index >= 0)
                                {
                                    ctBCXH_Search_count++;
                                }
                            }
                            BCNhapHangTheoKho[] ctBCXH_Search1 = new BCNhapHangTheoKho[ctBCXH_Search_count];
                            ctBCXH_Search_count = 0;

                            for (int i = 0; i < ctBCXH_Search.Length; i++)
                            {
                                int index = -1;
                                index = ctBCXH_Search[i].TenKho.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                if (index >= 0)
                                {
                                    ctBCXH_Search1[ctBCXH_Search_count] = ctBCXH_Search[i];
                                    ctBCXH_Search_count++;
                                }
                            }
                            if (ctBCXH_Search_count == 0)
                            {
                                tsslchitiet.Enabled = false;
                                tsslExcel.Enabled = false;
                                tsslPdf.Enabled = false;
                                tsslWord.Enabled = false;
                            }
                            else
                            {
                                tsslchitiet.Enabled = true;
                                tsslExcel.Enabled = true;
                                tsslPdf.Enabled = true;
                                tsslWord.Enabled = true;
                            }
                            ///////////////////////////////MRK FIX
                            List<Entities.BCNhapHangTheoKho> tem0 = new List<Entities.BCNhapHangTheoKho>();
                            int tong0 = 0;
                            foreach (Entities.BCNhapHangTheoKho item in ctBCXH_Search1)
                            {
                                tong0 += item.TongSoLuongNhap;
                                tem0.Add(item);
                            }
                            Entities.BCNhapHangTheoKho tem1 = new Entities.BCNhapHangTheoKho();
                            tem1.TenKho = "Tổng: ";
                            tem1.TongSoLuongNhap = tong0;
                            tem0.Add(tem1);
                            //////////////////////////////////////
                            //dtgvhienthi.DataSource = ctBCXH_Search1;
                            dtgvhienthi.DataSource = tem0.ToArray();

                            FixDatagridview();
                        }
                    }
            }
            else
                if (rdbMa.Checked == true)
                {
                    if (ctBCXH_Search == null)
                    {
                        BCNhapHangTheoKho[] tkkt = new BCNhapHangTheoKho[0];
                        dtgvhienthi.DataSource = tkkt;
                        FixDatagridview();

                        tsslchitiet.Enabled = false;
                        tsslExcel.Enabled = false;
                        tsslPdf.Enabled = false;
                        tsslWord.Enabled = false;

                    }
                    else
                        if (ctBCXH_Search != null)
                        {
                            if (txtTimKiem.Text.Length == 0)
                            {
                                BCNhapHangTheoKho[] tkkt = new BCNhapHangTheoKho[0];
                                dtgvhienthi.DataSource = tkkt;
                                FixDatagridview();

                                tsslchitiet.Enabled = false;
                                tsslExcel.Enabled = false;
                                tsslPdf.Enabled = false;
                                tsslWord.Enabled = false;

                            }
                            else
                            {
                                int ctBCXH_Search_count = 0;

                                for (int i = 0; i < ctBCXH_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = ctBCXH_Search[i].MaKho.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                    if (index >= 0)
                                    {
                                        ctBCXH_Search_count++;
                                    }
                                }
                                BCNhapHangTheoKho[] ctBCXH_Search1 = new BCNhapHangTheoKho[ctBCXH_Search_count];
                                ctBCXH_Search_count = 0;

                                for (int i = 0; i < ctBCXH_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = ctBCXH_Search[i].MaKho.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                    if (index >= 0)
                                    {
                                        ctBCXH_Search1[ctBCXH_Search_count] = ctBCXH_Search[i];
                                        ctBCXH_Search_count++;
                                    }
                                }
                                if (ctBCXH_Search_count == 0)
                                {
                                    tsslchitiet.Enabled = false;
                                    tsslExcel.Enabled = false;
                                    tsslPdf.Enabled = false;
                                    tsslWord.Enabled = false;
                                }
                                else
                                {
                                    tsslchitiet.Enabled = true;
                                    tsslExcel.Enabled = true;
                                    tsslPdf.Enabled = true;
                                    tsslWord.Enabled = true;
                                }
                                ///////////////////////////////MRK FIX
                                List<Entities.BCNhapHangTheoKho> tem0 = new List<Entities.BCNhapHangTheoKho>();
                                int tong0 = 0;
                                foreach (Entities.BCNhapHangTheoKho item in ctBCXH_Search1)
                                {
                                    tong0 += item.TongSoLuongNhap;
                                    tem0.Add(item);
                                }
                                Entities.BCNhapHangTheoKho tem1 = new Entities.BCNhapHangTheoKho();
                                tem1.TenKho = "Tổng: ";
                                tem1.TongSoLuongNhap = tong0;
                                tem0.Add(tem1);
                                //////////////////////////////////////
                                //dtgvhienthi.DataSource = ctBCXH_Search1;
                                dtgvhienthi.DataSource = tem0.ToArray();

                                FixDatagridview();
                            }
                        }
                }
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }
    }
}
