using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmKetChuyenSoDuKho : Form
    {
        DateTime datesv;
        public frmKetChuyenSoDuKho()
        {
            InitializeComponent(); datesv = DateServer.Date();
            this.WindowState = FormWindowState.Normal;

        }

        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        #region Lấy Bảng Kho Hàng
        public Entities.KhoHang[] khohang;
        public void LayKhoHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KhoHang ctxh = new Entities.KhoHang("Select");
                clientstrem = cl.SerializeObj(this.client, "KhoHang", ctxh);
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
        #region Hiển thị
        Entities.SoDuKho[] ddh;
        public void HienThi()
        {
            List<Entities.SoDuKho> listTemp = new List<Entities.SoDuKho>();
            Entities.SoDuKho sodukho;
            sodukho = new Entities.SoDuKho();
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            sodukho = new Entities.SoDuKho("Select");
            clientstrem = cl.SerializeObj(this.client, "SoDuKho", sodukho);
            ddh = new Entities.SoDuKho[1];
            ddh = (Entities.SoDuKho[])cl.DeserializeHepper(clientstrem, ddh);

            if (ddh == null)
                ddh = new Entities.SoDuKho[0];

            //
            for (int i = 0; i < ddh.Length; i++)
            {
                if (ddh[i].NgayKetChuyen.Month.ToString().Equals(cbbthang.Text) && ddh[i].NgayKetChuyen.Year.ToString().Equals(cbbnam.Text))
                {
                    listTemp.Add(ddh[i]);
                }
            }
            if (listTemp.ToArray().Length != 0)
            {

                if ((bool)listTemp.ToArray()[0].TrangThai)
                {
                    lbtrangthai.ForeColor = Color.Red;
                    lbtrangthai.Text = "Kỳ Đã Khóa";
                    tsslthuchien.Enabled = false;

                }
                else
                {
                    lbtrangthai.ForeColor = Color.Green;
                    lbtrangthai.Text = "Kỳ Chưa Khóa";
                    tsslthuchien.Enabled = true;
                }
            }

        }
        #endregion

        private void cbbthang_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbbnam.SelectedIndex == -1)
            {

            }
            else
                if (cbbthang.SelectedIndex == -1)
                {

                }
                else
                {
                    HienThi();

                }
        }

        private void cbbnam_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbbnam.SelectedIndex == -1)
            {

            }
            else
                if (cbbthang.SelectedIndex == -1)
                {

                }
                else
                {
                    HienThi();

                }
        }
        #region Lấy Số Dư Kho
        Entities.SoDuKho[] sdk;
        public void LaySoDuKho()
        {
            Entities.SoDuKho sodukho;
            sodukho = new Entities.SoDuKho();
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            sodukho = new Entities.SoDuKho("Select");
            clientstrem = cl.SerializeObj(this.client, "SoDuKho", sodukho);
            ddh = new Entities.SoDuKho[1];
            ddh = (Entities.SoDuKho[])cl.DeserializeHepper(clientstrem, ddh);
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
            if (sdk == null)
                sdk = new Entities.SoDuKho[0];

            List<Entities.SoDuKho> sdk1 = new List<Entities.SoDuKho>();
            for (int i = 0; i < sdk.Length; i++)
            {
                if (sdk[i].NgayKetChuyen.Month == thangKC && sdk[i].NgayKetChuyen.Year == namKC)
                {
                    sdk1.Add(sdk[i]);
                }
            }
            //
            return sdk1.ToArray();
        }
        #endregion

        #region Lấy Bảng Hàng Hóa
        public Entities.HangHoa[] hanghoa;
        public void LayBangHangHoa()
        {
            Entities.CheckRefer Checkrefer;
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            Checkrefer = new Entities.CheckRefer("HH", "");
            clientstrem = cl.SerializeObj(this.client, "Select", Checkrefer);
            Entities.HangHoa[] hh1 = new Entities.HangHoa[1];
            hh1 = (Entities.HangHoa[])cl.DeserializeHepper(clientstrem, hh1);
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
            int year = int.Parse(cbbnam.Text);
            int month = int.Parse(cbbthang.Text);
            int ngayCuoiTrongThang = DateTime.DaysInMonth(year, month);
            BatDau = new DateTime(year, month, 1);
            KetThuc = new DateTime(year, month, ngayCuoiTrongThang);

        }
        #endregion

        #region Lấy Hóa Đơn Bán Hàng Theo Ngày Tháng
        public Entities.HDBanHang[] HDBanHang = new Entities.HDBanHang[0];
        public void LayHDBanHang()
        {
            try
            {

                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.HDBanHang ctxh = new Entities.HDBanHang("Select");
                clientstrem = cl.SerializeObj(this.client, "HDBanHang", ctxh);
                Entities.HDBanHang[] HDBanHang1 = new Entities.HDBanHang[0];
                HDBanHang1 = (Entities.HDBanHang[])cl.DeserializeHepper1(clientstrem, HDBanHang1);
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
            if (HDBanHang == null)
                HDBanHang = new Entities.HDBanHang[0];

            List<Entities.HDBanHang> listTemp = new List<Entities.HDBanHang>();
            for (int i = 0; i < HDBanHang.Length; i++)
            {
                if (maKho == HDBanHang[i].MaKho)
                {
                    listTemp.Add(HDBanHang[i]);
                }
            }
            //
            HDBanHang_TheoKho = listTemp.ToArray();
        }
        #endregion
        #region Lấy Chi Tiết Hóa Đơn Bán Hàng
        Entities.ChiTietHDBanHang[] ctHDBanHang;
        public void LayChiTiet_HDBanHang()
        {
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            Entities.ChiTietHDBanHang ctxh = new Entities.ChiTietHDBanHang("SelectSon");
            clientstrem = cl.SerializeObj(this.client, "ChiTietHDBanHang", ctxh);
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
            if (ctHDBanHang == null)
                ctHDBanHang = new Entities.ChiTietHDBanHang[0];

            List<Entities.ChiTietHDBanHang> listTemp = new List<Entities.ChiTietHDBanHang>();
            for (int i = 0; i < ctHDBanHang.Length; i++)
            {
                if (ctHDBanHang[i].MaHDBanHang == maHD)
                {
                    listTemp.Add(ctHDBanHang[i]);
                }
            }
            //
            return listTemp.ToArray();
        }
        #endregion

        #region Lấy Phiếu Điều Chuyển Kho theo Ngày Tháng
        Entities.PhieuDieuChuyenKhoNoiBo[] PDieuChuyen;
        public void LayPhieuDieuChuyenKhoNoiBo()
        {
            try
            {
                List<Entities.PhieuDieuChuyenKhoNoiBo> listTemp = new List<Entities.PhieuDieuChuyenKhoNoiBo>();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.PhieuDieuChuyenKhoNoiBo ctxh = new Entities.PhieuDieuChuyenKhoNoiBo("Select", 1);
                clientstrem = cl.SerializeObj(this.client, "PhieuDieuCHuyenKhoNoiBo", ctxh);
                Entities.PhieuDieuChuyenKhoNoiBo[] PDieuChuyen1 = new Entities.PhieuDieuChuyenKhoNoiBo[0];
                PDieuChuyen1 = (Entities.PhieuDieuChuyenKhoNoiBo[])cl.DeserializeHepper1(clientstrem, PDieuChuyen1);

                if (PDieuChuyen1 == null)
                    PDieuChuyen1 = new Entities.PhieuDieuChuyenKhoNoiBo[0];

                for (int i = 0; i < PDieuChuyen1.Length; i++)
                {
                    DateTime ngaydieuchuyen = PDieuChuyen1[i].NgayDieuChuyen;
                    if (ngaydieuchuyen >= BatDau && ngaydieuchuyen <= KetThuc)
                    {
                        listTemp.Add(PDieuChuyen1[i]);
                    }
                }
                //
                PDieuChuyen = listTemp.ToArray();
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
            if (PDieuChuyen == null)
                PDieuChuyen = new Entities.PhieuDieuChuyenKhoNoiBo[0];


            List<Entities.PhieuDieuChuyenKhoNoiBo> listTemp = new List<Entities.PhieuDieuChuyenKhoNoiBo>();
            for (int i = 0; i < PDieuChuyen.Length; i++)
            {
                if (maKho == PDieuChuyen[i].TuKho)
                {
                    listTemp.Add(PDieuChuyen[i]);
                }
            }
            //
            PDieuChuyen_TheoKhoDi = listTemp.ToArray();
        }
        #endregion
        #region Lấy Phiếu ĐIều chuyển Theo Kho Đến
        Entities.PhieuDieuChuyenKhoNoiBo[] PDieuChuyen_TheoKhoDen;
        public void LayPhieuDieuChuyenKhoNoiBo_TheoKhoDen(string maKho)
        {
            if (PDieuChuyen == null)
                PDieuChuyen = new Entities.PhieuDieuChuyenKhoNoiBo[0];

            List<Entities.PhieuDieuChuyenKhoNoiBo> listTemp = new List<Entities.PhieuDieuChuyenKhoNoiBo>();
            for (int i = 0; i < PDieuChuyen.Length; i++)
            {
                if (maKho == PDieuChuyen[i].DenKho)
                {
                    listTemp.Add(PDieuChuyen[i]);
                }
            }
            //
            PDieuChuyen_TheoKhoDen = listTemp.ToArray();
        }
        #endregion
        #region Lấy Chi Tiết Phiếu Điều Chuyển Kho
        Entities.ChiTietPhieuDieuChuyenKho[] ctPDCK;
        public void LayChiTiet_PhieuDieuChuyenKho()
        {
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            Entities.ChiTietPhieuDieuChuyenKho ctxh = new Entities.ChiTietPhieuDieuChuyenKho("Select");
            clientstrem = cl.SerializeObj(this.client, "ChiTietPhieuDieuCHuyenKhoNoiBo", ctxh);
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
            if (ctPDCK == null)
                ctPDCK = new Entities.ChiTietPhieuDieuChuyenKho[0];

            List<Entities.ChiTietPhieuDieuChuyenKho> listTemp = new List<Entities.ChiTietPhieuDieuChuyenKho>();
            for (int i = 0; i < ctPDCK.Length; i++)
            {
                if (ctPDCK[i].MaPhieuDieuChuyenKho == maPhieu)
                {
                    listTemp.Add(ctPDCK[i]);
                }
            }
            //
            return listTemp.ToArray();
        }
        #endregion

        #region Lấy Phiếu Xuất Hủy theo ngày tháng
        Entities.PhieuXuatHuy[] PXuatHuy;
        public void LayPhieuXuatHuy()
        {
            try
            {
                List<Entities.PhieuXuatHuy> listTemp = new List<Entities.PhieuXuatHuy>();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.PhieuXuatHuy ctxh = new Entities.PhieuXuatHuy("Select");
                clientstrem = cl.SerializeObj(this.client, "PhieuXuatHuy", ctxh);
                Entities.PhieuXuatHuy[] PXuatHuy1 = new Entities.PhieuXuatHuy[0];
                PXuatHuy1 = (Entities.PhieuXuatHuy[])cl.DeserializeHepper1(clientstrem, PXuatHuy1);
                if (PXuatHuy1 == null)
                {
                    PXuatHuy1 = new Entities.PhieuXuatHuy[0];
                    PXuatHuy = PXuatHuy1;
                    return;
                }
                //
                for (int i = 0; i < PXuatHuy1.Length; i++)
                {
                    DateTime ngaylap = PXuatHuy1[i].NgayLap;
                    if (ngaylap >= BatDau && ngaylap <= KetThuc)
                    {
                        listTemp.Add(PXuatHuy1[i]);
                    }
                }
                //
                PXuatHuy = listTemp.ToArray();
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
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.ChiTietXuatHuy ctxh = new Entities.ChiTietXuatHuy("SelectSon");
                clientstrem = cl.SerializeObj(this.client, "ChiTietXuatHuy", ctxh);
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
                if (ctPXuatHuy == null)
                    ctPXuatHuy = new Entities.ChiTietXuatHuy[0];

                List<Entities.ChiTietXuatHuy> listTemp = new List<Entities.ChiTietXuatHuy>();
                for (int i = 0; i < ctPXuatHuy.Length; i++)
                {
                    if (ctPXuatHuy[i].MaPhieuXuatHuy.ToUpper().Equals(maPXuatHuy.ToUpper()))
                    {
                        listTemp.Add(ctPXuatHuy[i]);
                    }
                }

                return listTemp.ToArray();
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
                List<Entities.TraLaiNCC> listTemp = new List<Entities.TraLaiNCC>();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TraLaiNCC ctxh = new Entities.TraLaiNCC("Select");
                clientstrem = cl.SerializeObj(this.client, "TLNCC", ctxh);
                Entities.TraLaiNCC[] TraLaiNCC1 = new Entities.TraLaiNCC[0];
                TraLaiNCC1 = (Entities.TraLaiNCC[])cl.DeserializeHepper1(clientstrem, TraLaiNCC1);
                if (TraLaiNCC1 == null)
                {
                    TraLaiNCC = new Entities.TraLaiNCC[0];
                    return;
                }
                //
                for (int i = 0; i < TraLaiNCC1.Length; i++)
                {
                    DateTime ngaylap = TraLaiNCC1[i].Ngaytra;
                    if (ngaylap >= BatDau && ngaylap <= KetThuc)
                    {
                        listTemp.Add(TraLaiNCC1[i]);
                    }
                }
                //
                TraLaiNCC = listTemp.ToArray();
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
            if (TraLaiNCC == null)
                TraLaiNCC = new Entities.TraLaiNCC[0];

            List<Entities.TraLaiNCC> listTemp = new List<Entities.TraLaiNCC>();
            for (int i = 0; i < TraLaiNCC.Length; i++)
            {
                if (TraLaiNCC[i].MaKho.Equals(maKho))
                {
                    listTemp.Add(TraLaiNCC[i]);
                }
            }
            //
            TraLaiNCC_TheoMaKho = listTemp.ToArray();
        }
        #endregion
        #region Lấy Chi tiết Phiếu trả lại NCC
        Entities.ChiTietTraLaiNhaCungCap[] ctTraLaiNCC;
        public void LayChiTiet_TraLaiNCC()
        {
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            Entities.ChiTietTraLaiNhaCungCap[] ctxh = new Entities.ChiTietTraLaiNhaCungCap[1];
            ctxh[0] = new Entities.ChiTietTraLaiNhaCungCap("Select");
            clientstrem = cl.SerializeObj(this.client, "ChiTietTraLaiNhaCungCap", ctxh);
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
            if (ctTraLaiNCC == null)
                ctTraLaiNCC = new Entities.ChiTietTraLaiNhaCungCap[0];

            List<Entities.ChiTietTraLaiNhaCungCap> listTemp = new List<Entities.ChiTietTraLaiNhaCungCap>();
            for (int i = 0; i < ctTraLaiNCC.Length; i++)
            {
                if (ctTraLaiNCC[i].MaHDTraLaiNCC == maPTLNCC)
                {
                    listTemp.Add(ctTraLaiNCC[i]);
                }
            }
            //
            return listTemp.ToArray();

        }
        #endregion

        #region lấy hóa đơn nhập theo ngày tháng
        Entities.HoaDonNhap[] HoaDonNhap;
        public void LayHDNhap()
        {
            try
            {
                List<Entities.HoaDonNhap> listTemp = new List<Entities.HoaDonNhap>();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("HDN", "");
                clientstrem = cl.SerializeObj(this.client, "Select", ctxh);
                Entities.HoaDonNhap[] HDN = new Entities.HoaDonNhap[0];
                HDN = (Entities.HoaDonNhap[])cl.DeserializeHepper1(clientstrem, HDN);
                if (HDN == null)
                {
                    HoaDonNhap = new Entities.HoaDonNhap[0];
                    return;
                }
                //
                for (int i = 0; i < HDN.Length; i++)
                {
                    DateTime ngaylap = HDN[i].NgayNhap;
                    if (ngaylap >= BatDau && ngaylap <= KetThuc)
                    {
                        listTemp.Add(HDN[i]);
                    }
                }
                //
                HoaDonNhap = listTemp.ToArray();
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
            if (HoaDonNhap == null)
                HoaDonNhap = new Entities.HoaDonNhap[0];

            List<Entities.HoaDonNhap> listTemp = new List<Entities.HoaDonNhap>();
            for (int i = 0; i < HoaDonNhap.Length; i++)
            {
                if (HoaDonNhap[i].MaKho.Equals(maKho))
                {
                    listTemp.Add(HoaDonNhap[i]);
                }
            }
            //
            HoaDonNhap_TheoMaKho = listTemp.ToArray();
        }
        #endregion
        #region Lấy Chi tiết HDN
        public Entities.ChiTietHoaDonNhap[] ctHDN;
        public void LayChiTietHoaDonNhap()
        {
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("CTHDN", "");
            clientstrem = cl.SerializeObj(this.client, "Select", ctxh);
            Entities.ChiTietHoaDonNhap[] ctHDN1 = new Entities.ChiTietHoaDonNhap[0];
            ctHDN1 = (Entities.ChiTietHoaDonNhap[])cl.DeserializeHepper1(clientstrem, ctHDN1);
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
            if (ctHDN == null)
                ctHDN = new Entities.ChiTietHoaDonNhap[0];

            List<Entities.ChiTietHoaDonNhap> listTemp = new List<Entities.ChiTietHoaDonNhap>();
            for (int i = 0; i < ctHDN.Length; i++)
            {
                if (ctHDN[i].MaHoaDonNhap == maHDNhap)
                {
                    listTemp.Add(ctHDN[i]);
                }
            }
            //
            return listTemp.ToArray();
        }
        #endregion

        #region lấy Khách Hàng Trả Lại theo ngày tháng
        Entities.KhachHangTraLai[] KHTL;
        public void LayKHTL()
        {
            try
            {
                List<Entities.KhachHangTraLai> listTemp = new List<Entities.KhachHangTraLai>();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KhachHangTraLai KHTL1 = new Entities.KhachHangTraLai("Select");
                clientstrem = cl.SerializeObj(this.client, "KHTL", KHTL1);
                Entities.KhachHangTraLai[] HDN = new Entities.KhachHangTraLai[1];
                HDN = (Entities.KhachHangTraLai[])cl.DeserializeHepper(clientstrem, HDN);
                //
                if (HDN == null)
                    HDN = new Entities.KhachHangTraLai[0];
                //
                for (int i = 0; i < HDN.Length; i++)
                {
                    DateTime ngaylap = HDN[i].NgayNhap;
                    if (ngaylap >= BatDau && ngaylap <= KetThuc)
                    {
                        listTemp.Add(HDN[i]);
                    }
                }
                //
                KHTL = listTemp.ToArray();
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
            if (KHTL == null)
                KHTL = new Entities.KhachHangTraLai[0];

            List<Entities.KhachHangTraLai> listTemp = new List<Entities.KhachHangTraLai>();
            for (int i = 0; i < KHTL.Length; i++)
            {
                if (KHTL[i].MaKho == maKho)
                {
                    listTemp.Add(KHTL[i]);
                }
            }
            //
            KHTL_TheoMaKho = listTemp.ToArray();
        }
        #endregion
        #region lấy Chi tiết Khách Hàng Trả Lại
        Entities.ChiTietKhachHangTraLai[] CTKHTL;
        public void LayCTKHTL()
        {
            try
            {

                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTKHTL");
                clientstrem = cl.SerializeObj(this.client, "Select", ctxh);
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
            if (CTKHTL == null)
                CTKHTL = new Entities.ChiTietKhachHangTraLai[0];

            List<Entities.ChiTietKhachHangTraLai> listTemp = new List<Entities.ChiTietKhachHangTraLai>();
            try
            {
                for (int i = 0; i < CTKHTL.Length; i++)
                {
                    if (CTKHTL[i].MaKhachHangTraLai == MaPhieu)
                    {
                        listTemp.Add(CTKHTL[i]);
                    }
                }

            }
            catch
            {
                listTemp = null;
            }
            //
            return listTemp.ToArray();
        }
        #endregion

        #region Lấy Chi Tiết Hàng Hóa trong kho
        Entities.SoDuKho[] ctBCXH;
        Entities.ChiTietKhoHangTheoHoaHonNhap[] ctHangHoaTheoKho;
        public void LayChiTiet_HangHoaXuat()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.ChiTietKhoHangTheoHoaHonNhap nv = new Entities.ChiTietKhoHangTheoHoaHonNhap("Select");
                clientstrem = cl.SerializeObj(this.client, "ChiTietKho", nv);
                Entities.ChiTietKhoHangTheoHoaHonNhap[] kh1 = new Entities.ChiTietKhoHangTheoHoaHonNhap[1];
                kh1 = (Entities.ChiTietKhoHangTheoHoaHonNhap[])cl.DeserializeHepper1(clientstrem, kh1);

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
                Entities.SoDuKho[] sdk1 = LaySoDuKhoTheoNgay(Convert.ToInt32(cbbthang.Text), Convert.ToInt32(cbbnam.Text));
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

        #region LayID
        public string LayID(string tenBang)
        {
            string idnew = "";
            cl = new Server_Client.Client();
            // gán TCPclient
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            // khởi tạo biến truyền vào với hàm khởi tạo
            Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
            // khởi tạo mảng đối tượng để hứng giá trị
            Entities.LayID lid = new Entities.LayID();
            clientstrem = cl.SerializeObj(this.client, "LayID", lid1);
            // đổ mảng đối tượng vào datagripview       
            lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, lid1);
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
        public bool DeleteToDataBase()
        {
            bool msg = false;
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);

                Entities.SoDuKho[] sdk1 = LaySoDuKhoTheoNgay(Convert.ToInt32(cbbthang.Text), Convert.ToInt32(cbbnam.Text));
                clientstrem = cl.SerializeObj(this.client, "XoaArr", sdk1);
                msg = (bool)cl.DeserializeHepper(clientstrem, msg);
            }
            catch
            {
                msg = false;
            }

            return msg;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool InsertToDataBase1()
        {
            bool msg = false;
            try
            {
                int year = int.Parse(cbbnam.Text);
                int month = int.Parse(cbbthang.Text);
                string maSoDuKho = LayID("SoDuKho");
                for (int i = 0; i < ctBCXH.Length; i++)
                {
                    ctBCXH[i].MaSoDuKho = maSoDuKho;
                    ctBCXH[i].TrangThai = true;
                    ctBCXH[i].HanhDong = "Insert";
                    ctBCXH[i].NgayKetChuyen = new DateTime(year, month, 1);
                }
                //
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "ThemArr", ctBCXH);
                msg = (bool)cl.DeserializeHepper(clientstrem, msg);
            }
            catch
            {
                msg = false;
            }

            return msg;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool InsertToDataBase2()
        {
            bool msg = false;
            try
            {
                string maSoDuKho = LayID("SoDuKho");
                for (int i = 0; i < ctBCXH.Length; i++)
                {
                    ctBCXH[i].MaSoDuKho = maSoDuKho;
                    ctBCXH[i].TrangThai = false;
                    ctBCXH[i].HanhDong = "Insert";
                    int nam = int.Parse(cbbnam.Text);
                    int thang = int.Parse(cbbthang.Text);
                    if (thang == 12)
                    {
                        nam += 1;
                        thang = 1;
                    }
                    else
                    {
                        thang += 1;
                    }

                    ctBCXH[i].NgayKetChuyen = new DateTime(nam, thang, 1);
                    ctBCXH[i].SoDuDauKy = ctBCXH[i].SoDuCuoiKy;
                    ctBCXH[i].SoDuCuoiKy = 0;
                }
                //
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "ThemArr", ctBCXH);
                msg = (bool)cl.DeserializeHepper(clientstrem, msg);
            }
            catch
            {
                msg = false;
            }

            return msg;
        }



        /// <summary>
        /// tsslthuchien_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslthuchien_Click(object sender, EventArgs e)
        {
            tsslthuchien.Enabled = false;
            if (string.IsNullOrEmpty(cbbthang.Text))
            {
                MessageBox.Show("Nhập tháng");
                return;

            }
            //
            if (string.IsNullOrEmpty(cbbnam.Text))
            {
                MessageBox.Show("Nhập Năm");
                return;
            }
            //
            LayKhoHang();
            LayNgay();
            LaySoDuKho();
            LayBangHangHoa();
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
            //
            bool delete = DeleteToDataBase();
            if (!delete)
                return;
            //
            bool insert1 = InsertToDataBase1();
            if (!insert1)
                return;
            //
            bool insert2 = InsertToDataBase2();
            if (!insert2)
                return;
            //
            tsslthuchien.Enabled = true;
            HienThi();
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void frmKetChuyenSoDuKho_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

        }

        private void tssltrove_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
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
