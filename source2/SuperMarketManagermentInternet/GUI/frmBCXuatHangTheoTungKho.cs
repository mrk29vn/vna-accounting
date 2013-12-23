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
    public partial class frmBCXuatHangTheoTungKho : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.BCXuatHangTheoTungKho[] ctBCXH_Search;
        DateTime datesv;
        public frmBCXuatHangTheoTungKho()
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
            //string date;
            //try
            //{
            //    date = new Common.Utilities().MyDateConversion(mskBatDau.Text);
            //    Convert.ToDateTime(date);
            //}
            //catch
            //{
            //    MessageBox.Show("Bạn nhập sai định dạng Từ ngày", "Hệ thống cánh bảo");
            //    mskBatDau.Focus();
            //    return false;
            //} string date1;
            //try
            //{
            //    date1 = new Common.Utilities().MyDateConversion(mskKetThuc.Text);
            //    Convert.ToDateTime(date1);
            //}
            //catch
            //{
            //    MessageBox.Show("Bạn nhập sai định dạng Đến ngày", "Hệ thống cánh bảo");
            //    mskKetThuc.Focus();
            //    return false;
            //}
            //if (Convert.ToDateTime(date) > Convert.ToDateTime(date1))
            //{
            //    MessageBox.Show("Ngày Kết thúc phải lớn hơn ngày Bắt đầu", "Hệ thống cảnh báo");
            //    mskKetThuc.Focus();
            //    return false;
            //}
            return true;
        }
        #region Lấy Bảng Hàng Hóa
        public Entities.HangHoa[] HangHoa;
        public void LayHangHoa()
        {

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
                Entities.KhoHang ctxh = new Entities.KhoHang("Select");
                clientstrem = cl.SerializeObj(this.client1, "KhoHang", ctxh);
                khohang = (Entities.KhoHang[])cl.DeserializeHepper1(clientstrem, khohang);
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

        #region Lấy Hóa Đơn Bán Hàng Theo Ngày Tháng
        public Entities.HDBanHang[] HDBanHang;
        public void LayHDBanHang()
        {
            try
            {

                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.HDBanHang ctxh = new Entities.HDBanHang("Select");
                clientstrem = cl.SerializeObj(this.client1, "HDBanHang", ctxh);
                Entities.HDBanHang[] HDBanHang1 = new Entities.HDBanHang[0];
                HDBanHang1 = (Entities.HDBanHang[])cl.DeserializeHepper1(clientstrem, HDBanHang1);
                if (HDBanHang1 == null)
                {
                    HDBanHang = new Entities.HDBanHang[0];
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
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.ChiTietHDBanHang ctxh = new Entities.ChiTietHDBanHang("SelectSon");
            clientstrem = cl.SerializeObj(this.client1, "ChiTietHDBanHang", ctxh);
            Entities.ChiTietHDBanHang[] ctHDBanHang1 = new Entities.ChiTietHDBanHang[0];
            ctHDBanHang1 = (Entities.ChiTietHDBanHang[])cl.DeserializeHepper1(clientstrem, ctHDBanHang1);
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
        #region Lấy Phiếu ĐIều chuyển Theo Kho
        Entities.PhieuDieuChuyenKhoNoiBo[] PDieuChuyen_TheoKho;
        public void LayPhieuDieuChuyenKhoNoiBo_TheoKho(string maKho)
        {
            int count = 0;
            for (int i = 0; i < PDieuChuyen.Length; i++)
            {
                if (maKho == PDieuChuyen[i].TuKho)
                {
                    count++;
                }
            }
            PDieuChuyen_TheoKho = new Entities.PhieuDieuChuyenKhoNoiBo[count];
            count = 0;
            for (int i = 0; i < PDieuChuyen.Length; i++)
            {
                if (maKho == PDieuChuyen[i].TuKho)
                {
                    PDieuChuyen_TheoKho[count] = PDieuChuyen[i];
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


        #region Lấy Phiếu Xuất Hủy theo ngày tháng
        Entities.PhieuXuatHuy[] PXuatHuy;
        public void LayPhieuXuatHuy()
        {
            try
            {

                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.PhieuXuatHuy ctxh = new Entities.PhieuXuatHuy("Select");
                clientstrem = cl.SerializeObj(this.client1, "PhieuXuatHuy", ctxh);
                Entities.PhieuXuatHuy[] PXuatHuy1 = new Entities.PhieuXuatHuy[0];
                PXuatHuy1 = (Entities.PhieuXuatHuy[])cl.DeserializeHepper1(clientstrem, PXuatHuy1);
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
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.ChiTietXuatHuy ctxh = new Entities.ChiTietXuatHuy("SelectSon");
                clientstrem = cl.SerializeObj(this.client1, "ChiTietXuatHuy", ctxh);
                ctPXuatHuy = new Entities.ChiTietXuatHuy[0];
                ctPXuatHuy = (Entities.ChiTietXuatHuy[])cl.DeserializeHepper1(clientstrem, ctPXuatHuy);
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

                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TraLaiNCC ctxh = new Entities.TraLaiNCC("Select");
                clientstrem = cl.SerializeObj(this.client1, "TLNCC", ctxh);
                Entities.TraLaiNCC[] TraLaiNCC1 = new Entities.TraLaiNCC[0];
                TraLaiNCC1 = (Entities.TraLaiNCC[])cl.DeserializeHepper1(clientstrem, TraLaiNCC1);
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
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.ChiTietTraLaiNhaCungCap[] ctxh = new Entities.ChiTietTraLaiNhaCungCap[1];
            ctxh[0] = new Entities.ChiTietTraLaiNhaCungCap("Select");
            clientstrem = cl.SerializeObj(this.client1, "ChiTietTraLaiNhaCungCap", ctxh);
            ctTraLaiNCC = new Entities.ChiTietTraLaiNhaCungCap[0];
            ctTraLaiNCC = (Entities.ChiTietTraLaiNhaCungCap[])cl.DeserializeHepper1(clientstrem, ctTraLaiNCC);
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
            catch
            {
            }
        }
        #endregion
        #region Lấy Chi Tiết Hàng Hóa trong 1 kho
        Entities.ChiTietBCXuatHangTheoTungKho[] ctBCXH;
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


                ctBCXH = new Entities.ChiTietBCXuatHangTheoTungKho[count];
                for (int i = 0; i < ctkho.Length; i++)
                {
                    ctBCXH[i] = new Entities.ChiTietBCXuatHangTheoTungKho();
                    ctBCXH[i].MaKho = ctkho[i].Makho;
                    ctBCXH[i].TenKho = tenKho;
                    ctBCXH[i].MaHangHoa = ctkho[i].Mahanghoa;
                    ctBCXH[i].TongSoLuongXuat = 0;
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
            catch
            {
            }
        }
        #endregion
        Entities.GoiHang[] goihang;
        Entities.ChiTietGoiHang[] chitietgoihang;
        Entities.SelectAll selectall;
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
        void SelectGoiHang()
        {
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("frmBCXuatHangTheoTungKho", new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen);
            clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
            selectall = (Entities.SelectAll)cl.DeserializeHepper(clientstrem, selectall);
            // gói hàng
            goihang = selectall.GoiHang;

            // chi tiết gói hàng
            chitietgoihang = selectall.ChiTietGoiHang;
            HangHoa = selectall.HangHoaTheoKho;
        }
        public void LayChiTiet_SoLuong_HangHoaXuat_TheoKho()
        {
            try
            {
                Entities.HangHoa[] hh = Common.Utilities.CheckGoiHang(HangHoa, goihang, chitietgoihang);
                for (int i = 0; i < ctBCXH.Length; i++)
                {

                    // Tính Tổng Số Lượng Hàng Hóa Xuất Trong HD Bán Hàng 
                    for (int j = 0; j < HDBanHang_TheoKho.Length; j++)
                    {
                        //Lấy Chi Tiết HD Bán Hàng Theo Ma Hóa Đơn
                        Entities.ChiTietHDBanHang[] ctHDBanHang = LayChiTiet_HDBanHang_TheoMaPhieu(HDBanHang_TheoKho[j].MaHDBanHang);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trong HD bán Hàng  vào ctBCXH
                        for (int k = 0; k < ctHDBanHang.Length; k++)
                        {
                            if (!GoiHangOrHangHoa(ctHDBanHang[k].MaHangHoa))
                            {//là hàng hóa
                                if (ctBCXH[i].MaHangHoa == ctHDBanHang[k].MaHangHoa)
                                {
                                    ctBCXH[i].TongSoLuongXuat = ctBCXH[i].TongSoLuongXuat + ctHDBanHang[k].SoLuong;
                                }
                            }
                            ////////////////////////////////////////////////MRK FIX
                            else
                            {
                                foreach (Entities.GoiHang gh in goihang)
                                {
                                    foreach (Entities.ChiTietGoiHang ctgh in chitietgoihang)
                                    {
                                        if (gh.MaGoiHang.Equals(ctgh.MaGoiHang) && ctgh.MaGoiHang.Equals(ctHDBanHang[k].MaHangHoa) && ctgh.MaHangHoa.Equals(ctBCXH[i].MaHangHoa))
                                        {
                                            ctBCXH[i].TongSoLuongXuat += (ctHDBanHang[k].SoLuong * ctgh.SoLuong);
                                        }
                                    }
                                }
                            }
                            ////////////////////////////////////////////////MRK FIX
                        }
                    }

                    // Tính Tổng Số Lượng Hàng Hóa Xuất Trong Phiếu Điều Chuyển Kho
                    for (int j = 0; j < PDieuChuyen_TheoKho.Length; j++)
                    {
                        //Lấy Chi Tiết Phiếu Điều Chuyển Theo Mã Phiếu
                        Entities.ChiTietPhieuDieuChuyenKho[] ctPDCK = LayChiTiet_PhieuDieuChuyenKho_TheoMaPhieu(PDieuChuyen_TheoKho[j].MaPhieuDieuChuyenKho);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trong Phiếu Điều Chuyển vào ctBCXH
                        for (int k = 0; k < ctPDCK.Length; k++)
                        {
                            if (!GoiHangOrHangHoa(ctHDBanHang[k].MaHangHoa))
                            {//là hàng hóa
                                if (ctBCXH[i].MaHangHoa == ctPDCK[k].MaHangHoa)
                                {
                                    ctBCXH[i].TongSoLuongXuat = ctBCXH[i].TongSoLuongXuat + ctPDCK[k].SoLuong;
                                }
                            }
                            ////////////////////////////////////////////////MRK FIX
                            else
                            {
                                foreach (Entities.GoiHang gh in goihang)
                                {
                                    foreach (Entities.ChiTietGoiHang ctgh in chitietgoihang)
                                    {
                                        if (gh.MaGoiHang.Equals(ctgh.MaGoiHang) && ctgh.MaGoiHang.Equals(ctPDCK[k].MaHangHoa) && ctgh.MaHangHoa.Equals(ctBCXH[i].MaHangHoa))
                                        {
                                            ctBCXH[i].TongSoLuongXuat += (ctPDCK[k].SoLuong * ctgh.SoLuong);
                                        }
                                    }
                                }
                            }
                            ////////////////////////////////////////////////MRK FIX
                        }
                    }


                    // Tính Tổng Số Lượng Hàng Hóa Xuất Trong Phiếu Xuất Hủy
                    for (int j = 0; j < PXuatHuy_TheoMaKho.Length; j++)
                    {
                        //Lấy Chi Tiết Phiếu Xuất Hủy Theo Mã Phiếu
                        Entities.ChiTietXuatHuy[] ctXuatHuy = LayChiTiet_XuatHuy_TheoMaPhieu(PXuatHuy_TheoMaKho[j].MaPhieuXuatHuy);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trong Phiếu Xuất Hủy vào ctBCXH
                        for (int k = 0; k < ctXuatHuy.Length; k++)
                        {
                            if (ctBCXH[i].MaHangHoa == ctXuatHuy[k].MaHangHoa)
                            {
                                ctBCXH[i].TongSoLuongXuat = ctBCXH[i].TongSoLuongXuat + ctXuatHuy[k].SoLuong;

                            }
                        }

                    }

                    // Tính Tổng Số Lượng Hàng Hóa Xuất Trong Trả Lại NCC
                    for (int j = 0; j < TraLaiNCC_TheoMaKho.Length; j++)
                    {
                        //Lấy Chi Tiết Phiếu Xuất Hủy Trả Lại NCC
                        Entities.ChiTietTraLaiNhaCungCap[] ctTraLaiNCC = LayChiTiet_TraLaiNCC_TheoMaPhieu(TraLaiNCC_TheoMaKho[j].MaHDTraLaiNCC);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trả Lại NCC vào ctBCXH
                        for (int k = 0; k < ctTraLaiNCC.Length; k++)
                        {

                            if (ctBCXH[i].MaHangHoa == ctTraLaiNCC[k].MaHangHoa)
                            {
                                ctBCXH[i].TongSoLuongXuat = ctBCXH[i].TongSoLuongXuat + ctTraLaiNCC[k].SoLuong;
                            }
                        }

                    }

                }



            }
            catch
            {

            }
        }

        public Entities.BCXuatHangTheoTungKho[] ArrBCXH;
        public void ArrTongHangXuat()
        {
            ArrBCXH = new Entities.BCXuatHangTheoTungKho[khohang.Length];
            for (int i = 0; i < khohang.Length; i++)
            {
                LayHDBanHang_TheoKho(khohang[i].MaKho);
                LayPhieuDieuChuyenKhoNoiBo_TheoKho(khohang[i].MaKho);
                LayPhieuXuatHuy_TheoMaKho(khohang[i].MaKho);
                LayTraLaiNCC_TheoMaKho(khohang[i].MaKho);
                LayChiTiet_HangHoaXuat_TheoKho(khohang[i].MaKho, khohang[i].TenKho);
                LayChiTiet_SoLuong_HangHoaXuat_TheoKho();

                ArrBCXH[i] = new Entities.BCXuatHangTheoTungKho();

                int TongHangHoaXuatTheoKho = 0;
                for (int j = 0; j < ctBCXH.Length; j++)
                {
                    TongHangHoaXuatTheoKho = TongHangHoaXuatTheoKho + ctBCXH[j].TongSoLuongXuat;
                }
                ArrBCXH[i].MaKho = khohang[i].MaKho;
                ArrBCXH[i].TenKho = khohang[i].TenKho;
                ArrBCXH[i].TongSoLuongXuat = TongHangHoaXuatTheoKho;
                ctBCXH = null;
            }
        }
        DateTime BatDau, KetThuc;

        public void LayNgay()
        {
            BatDau = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), 1);
            KetThuc = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), DateTime.DaysInMonth(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text)));
            //if (cbbthang.Text == "12")
            //{
            //    KetThuc = new DateTime(Convert.ToInt32(cbbnam.Text) + 1, 1, 1);
            //}
            //else
            //{
            //    KetThuc = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text) + 1, 1);
            //}
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                LayNgay();
                LayKhoHang();
                LayHangHoa();
                SelectGoiHang();
                LayHDBanHang();
                LayChiTiet_HDBanHang();
                LayPhieuDieuChuyenKhoNoiBo();
                LayChiTiet_PhieuDieuChuyenKho();
                LayPhieuXuatHuy();
                LayChiTiet_XuatHuy();
                LayTraLaiNCC();
                LayChiTiet_TraLaiNCC();
                LayChiTiet_HangHoaXuat();

                ArrTongHangXuat();
                ///////////////////////////////MRK FIX
                List<Entities.BCXuatHangTheoTungKho> tem0 = new List<BCXuatHangTheoTungKho>();
                double tong0 = 0;
                foreach (Entities.BCXuatHangTheoTungKho item in ArrBCXH)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    tong0 += item.TongSoLuongXuat;
                    tem0.Add(item);
                }
                Entities.BCXuatHangTheoTungKho tem1 = new BCXuatHangTheoTungKho();
                tem1.TenKho = "Tổng: ";
                tem1.TongSoLuongXuat = (int)tong0;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = ArrBCXH;
                dtgvhienthi.DataSource = tem0.ToArray();
                FixDatagridview();
                dtgvhienthi.Focus();
                ctBCXH_Search = ArrBCXH;
                if (ArrBCXH.Length > 0)
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
        public void FixDatagridview()
        {
            dtgvhienthi.Columns["MaKho"].HeaderText = "Mã Kho";
            dtgvhienthi.Columns["TenKho"].HeaderText = "Tên Kho";
            dtgvhienthi.Columns["TongSoLuongXuat"].HeaderText = "Tổng Số Lượng Xuất";
            dtgvhienthi.Columns["STT"].Visible = false;
            dtgvhienthi.AllowUserToResizeRows = false;
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvhienthi.ReadOnly = true;
        }
        private void frmBCXuatHangTheoTungKho_Load(object sender, EventArgs e)
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
            SelectGoiHang();
            LayHDBanHang();
            LayChiTiet_HDBanHang();
            LayPhieuDieuChuyenKhoNoiBo();
            LayChiTiet_PhieuDieuChuyenKho();
            LayPhieuXuatHuy();
            LayChiTiet_XuatHuy();
            LayTraLaiNCC();
            LayChiTiet_TraLaiNCC();
            LayChiTiet_HangHoaXuat();

            ArrTongHangXuat();
            ///////////////////////////////MRK FIX
            List<Entities.BCXuatHangTheoTungKho> tem0 = new List<BCXuatHangTheoTungKho>();
            double tong0 = 0;
            foreach (Entities.BCXuatHangTheoTungKho item in ArrBCXH)
            {
                tong0 += item.TongSoLuongXuat;
                tem0.Add(item);
            }
            Entities.BCXuatHangTheoTungKho tem1 = new BCXuatHangTheoTungKho();
            tem1.TenKho = "Tổng: ";
            tem1.TongSoLuongXuat = (int)tong0;
            tem0.Add(tem1);
            //////////////////////////////////////
            //dtgvhienthi.DataSource = ArrBCXH;
            dtgvhienthi.DataSource = tem0.ToArray();
            FixDatagridview();
            dtgvhienthi.Focus();
            ctBCXH_Search = ArrBCXH;
            if (ArrBCXH.Length > 0)
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
            if ((int)dtgvhienthi.Rows[e.RowIndex].Cells["TongSoLuongXuat"].Value == 0)
            {
                MessageBox.Show("Không có Hàng Xuất từ kho" + tenkho + " trong Khoảng từ ngày : " + xulyNgay(BatDau) + " đến " + xulyNgay(KetThuc) + " ");
            }
            else
            {
                LayHDBanHang_TheoKho(makho);
                LayPhieuDieuChuyenKhoNoiBo_TheoKho(makho);
                LayPhieuXuatHuy_TheoMaKho(makho);
                LayTraLaiNCC_TheoMaKho(makho);
                LayChiTiet_HangHoaXuat_TheoKho(makho, tenkho);
                LayChiTiet_SoLuong_HangHoaXuat_TheoKho();

                frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH, BatDau, KetThuc);
                frm.ShowDialog();

            }
        }

        private void cbbthang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            string makho = dtgvhienthi.CurrentRow.Cells["MaKho"].Value.ToString();
            string tenkho = dtgvhienthi.CurrentRow.Cells["TenKho"].Value.ToString();
            if ((int)dtgvhienthi.CurrentRow.Cells["TongSoLuongXuat"].Value == 0)
            {
                MessageBox.Show("Không có Hàng Xuất từ kho" + tenkho + " trong Khoảng từ ngày : " + xulyNgay(BatDau) + " đến " + xulyNgay(KetThuc) + " ");
            }
            else
            {
                LayHDBanHang_TheoKho(makho);
                LayPhieuDieuChuyenKhoNoiBo_TheoKho(makho);
                LayPhieuXuatHuy_TheoMaKho(makho);
                LayTraLaiNCC_TheoMaKho(makho);
                LayChiTiet_HangHoaXuat_TheoKho(makho, tenkho);
                LayChiTiet_SoLuong_HangHoaXuat_TheoKho();

                frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH, BatDau, KetThuc);
                frm.ShowDialog();

            }
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dtgvhienthi.CurrentRow.Index;
                if (i < 0)
                {
                    MessageBox.Show("Bạn Phải Chọn Bản Ghi");
                    return;
                }
                string makho = dtgvhienthi.CurrentRow.Cells["MaKho"].Value.ToString();
                string tenkho = dtgvhienthi.CurrentRow.Cells["TenKho"].Value.ToString();
                if ((int)dtgvhienthi.CurrentRow.Cells["TongSoLuongXuat"].Value == 0)
                {
                    MessageBox.Show("Không có Hàng Xuất từ kho" + tenkho + " trong Khoảng từ ngày : " + xulyNgay(BatDau) + " đến " + xulyNgay(KetThuc) + " ");
                }
                else
                {
                    saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                    if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        LayHDBanHang_TheoKho(makho);
                        LayPhieuDieuChuyenKhoNoiBo_TheoKho(makho);
                        LayPhieuXuatHuy_TheoMaKho(makho);
                        LayTraLaiNCC_TheoMaKho(makho);
                        LayChiTiet_HangHoaXuat_TheoKho(makho, tenkho);
                        LayChiTiet_SoLuong_HangHoaXuat_TheoKho();

                        frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH, BatDau, KetThuc, saveFileDialog1.FileName, "PDF");

                    }

                }
            }
            catch
            {
            }

        }

        private void tsslWord_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dtgvhienthi.CurrentRow.Index;
                if (i < 0)
                {
                    MessageBox.Show("Bạn Phải Chọn Bản Ghi");
                    return;
                }
                string makho = dtgvhienthi.CurrentRow.Cells["MaKho"].Value.ToString();
                string tenkho = dtgvhienthi.CurrentRow.Cells["TenKho"].Value.ToString();
                if ((int)dtgvhienthi.CurrentRow.Cells["TongSoLuongXuat"].Value == 0)
                {
                    MessageBox.Show("Không có Hàng Xuất từ kho" + tenkho + " trong Khoảng từ ngày : " + xulyNgay(BatDau) + " đến " + xulyNgay(KetThuc) + " ");
                }
                else
                {
                    saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                    if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        LayHDBanHang_TheoKho(makho);
                        LayPhieuDieuChuyenKhoNoiBo_TheoKho(makho);
                        LayPhieuXuatHuy_TheoMaKho(makho);
                        LayTraLaiNCC_TheoMaKho(makho);
                        LayChiTiet_HangHoaXuat_TheoKho(makho, tenkho);
                        LayChiTiet_SoLuong_HangHoaXuat_TheoKho();

                        frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH, BatDau, KetThuc, saveFileDialog1.FileName, "Word");

                    }

                }
            }
            catch
            {
            }
        }

        private void tsslExcel_Click(object sender, EventArgs e)
        {
            try
            {
                int i = dtgvhienthi.CurrentRow.Index;
                if (i < 0)
                {
                    MessageBox.Show("Bạn Phải Chọn Bản Ghi");
                    return;
                }
                string makho = dtgvhienthi.CurrentRow.Cells["MaKho"].Value.ToString();
                string tenkho = dtgvhienthi.CurrentRow.Cells["TenKho"].Value.ToString();
                if ((int)dtgvhienthi.CurrentRow.Cells["TongSoLuongXuat"].Value == 0)
                {
                    MessageBox.Show("Không có Hàng Xuất từ kho" + tenkho + " trong Khoảng từ ngày : " + xulyNgay(BatDau) + " đến " + xulyNgay(KetThuc) + " ");
                }
                else
                {
                    saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                    if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {

                        LayHDBanHang_TheoKho(makho);
                        LayPhieuDieuChuyenKhoNoiBo_TheoKho(makho);
                        LayPhieuXuatHuy_TheoMaKho(makho);
                        LayTraLaiNCC_TheoMaKho(makho);
                        LayChiTiet_HangHoaXuat_TheoKho(makho, tenkho);
                        LayChiTiet_SoLuong_HangHoaXuat_TheoKho();

                        frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH, BatDau, KetThuc, saveFileDialog1.FileName, "Excel");

                    }

                }
            }
            catch
            {
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (rdbTen.Checked == true)
            {

                if (ctBCXH_Search == null)
                {
                    BCXuatHangTheoTungKho[] tkkt = new BCXuatHangTheoTungKho[0];
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
                            BCXuatHangTheoTungKho[] tkkt = new BCXuatHangTheoTungKho[0];
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
                            BCXuatHangTheoTungKho[] ctBCXH_Search1 = new BCXuatHangTheoTungKho[ctBCXH_Search_count];
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
                            List<Entities.BCXuatHangTheoTungKho> tem0 = new List<BCXuatHangTheoTungKho>();
                            double tong0 = 0;
                            foreach (Entities.BCXuatHangTheoTungKho item in ctBCXH_Search1)
                            {
                                tong0 += item.TongSoLuongXuat;
                                tem0.Add(item);
                            }
                            Entities.BCXuatHangTheoTungKho tem1 = new BCXuatHangTheoTungKho();
                            tem1.TenKho = "Tổng: ";
                            tem1.TongSoLuongXuat = (int)tong0;
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
                        BCXuatHangTheoTungKho[] tkkt = new BCXuatHangTheoTungKho[0];
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
                                BCXuatHangTheoTungKho[] tkkt = new BCXuatHangTheoTungKho[0];
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
                                BCXuatHangTheoTungKho[] ctBCXH_Search1 = new BCXuatHangTheoTungKho[ctBCXH_Search_count];
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
                                List<Entities.BCXuatHangTheoTungKho> tem0 = new List<BCXuatHangTheoTungKho>();
                                double tong0 = 0;
                                foreach (Entities.BCXuatHangTheoTungKho item in ctBCXH_Search1)
                                {
                                    tong0 += item.TongSoLuongXuat;
                                    tem0.Add(item);
                                }
                                Entities.BCXuatHangTheoTungKho tem1 = new BCXuatHangTheoTungKho();
                                tem1.TenKho = "Tổng: ";
                                tem1.TongSoLuongXuat = (int)tong0;
                                tem0.Add(tem1);
                                //////////////////////////////////////
                                //dtgvhienthi.DataSource = ctBCXH_Search1;
                                dtgvhienthi.DataSource = tem0.ToArray();
                                FixDatagridview();
                            }
                        }
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
                List<Entities.BCXuatHangTheoTungKho> tem0 = new List<BCXuatHangTheoTungKho>();
                double tong0 = 0;
                foreach (Entities.BCXuatHangTheoTungKho item in ctBCXH_Search)
                {
                    tong0 += item.TongSoLuongXuat;
                    tem0.Add(item);
                }
                Entities.BCXuatHangTheoTungKho tem1 = new BCXuatHangTheoTungKho();
                tem1.TenKho = "Tổng: ";
                tem1.TongSoLuongXuat = (int)tong0;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = ctBCXH_Search;
                dtgvhienthi.DataSource = tem0.ToArray();
                FixDatagridview();
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

