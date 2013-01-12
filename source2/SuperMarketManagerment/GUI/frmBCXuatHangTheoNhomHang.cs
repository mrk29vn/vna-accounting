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
    public partial class frmBCXuatHangTheoNhomHang : Form
    {
        DateTime datesv;
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.BCXuatHangTheoNhomHang[] ctBCXH_Search;

        public frmBCXuatHangTheoNhomHang()
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

        /////////////////////////////////////////////////////////////MRK FIX
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
            catch
            {

            }
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
            catch
            {

            }
        }
        //////////////////////////////////////////////////////////////////////////////////////

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
            catch
            {
            }
        }
        #endregion
        
        #region Lấy Bảng Nhóm Hàng
        public Entities.NhomHang[] NhomHang;
        public void LayNhomHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.NhomHang ctxh = new Entities.NhomHang("Select");
                clientstrem = cl.SerializeObj(this.client1, "NhomHang", ctxh);
                NhomHang = (Entities.NhomHang[])cl.DeserializeHepper1(clientstrem, NhomHang);
                if (NhomHang == null)
                {
                    NhomHang = new Entities.NhomHang[0];
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
                    PDieuChuyen = new Entities.PhieuDieuChuyenKhoNoiBo[0];
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


        #region Lấy Chi Tiết Hàng Hóa trong 1 Nhóm Hàng
        Entities.HangHoa[] ctHangHoaNhomHang;
        public void LayChiTiet_HangHoaXuat()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.HangHoa nv = new Entities.HangHoa("Select");
                clientstrem = cl.SerializeObj(this.client1, "HangHoa", nv);
                Entities.HangHoa[] kh1 = new Entities.HangHoa[1];
                kh1 = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, kh1);

                if (kh1 == null)
                {
                    ctHangHoaNhomHang = new Entities.HangHoa[0];
                    return;
                }
                ctHangHoaNhomHang = kh1;

            }
            catch
            {
            }
        }
        #endregion
        #region Lấy Chi Tiết Hàng Hóa trong 1 Nhóm Hàng
        Entities.ChiTietBCXuatHangTheoNhomHang[] ctBCXH;
        public void LayChiTiet_HangHoaXuat_TheoNhomHang(string maNhom, string tenNhom)
        {
            try
            {
                int count = 0;
                for (int i = 0; i < ctHangHoaNhomHang.Length; i++)
                {
                    if (ctHangHoaNhomHang[i].MaNhomHangHoa == maNhom)
                    {
                        count++;
                    }

                }
                Entities.HangHoa[] ctkho = new Entities.HangHoa[count];
                count = 0;

                for (int i = 0; i < ctHangHoaNhomHang.Length; i++)
                {
                    if (ctHangHoaNhomHang[i].MaNhomHangHoa == maNhom)
                    {
                        ctkho[count] = ctHangHoaNhomHang[i];
                        count++;
                    }

                }


                ctBCXH = new Entities.ChiTietBCXuatHangTheoNhomHang[count];
                for (int i = 0; i < ctkho.Length; i++)
                {
                    ctBCXH[i] = new Entities.ChiTietBCXuatHangTheoNhomHang();

                    ctBCXH[i].MaNhomHang = ctkho[i].MaNhomHangHoa;
                    ctBCXH[i].TenNhomHang = tenNhom;
                    ctBCXH[i].MaHangHoa = ctkho[i].MaHangHoa;
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

        public void LayChiTiet_SoLuong_HangHoaXuat_TheoKho()
        {
            try
            {
                //Entities.HangHoa[] hh = Common.Utilities.CheckGoiHang(HangHoa, goihang, chitietgoihang);
                for (int i = 0; i < ctBCXH.Length; i++)
                {

                    // Tính Tổng Số Lượng Hàng Hóa Xuất Trong HD Bán Hàng 
                    for (int j = 0; j < HDBanHang.Length; j++)
                    {
                        Entities.ChiTietHDBanHang[] ctHDBanHang1 = LayChiTiet_HDBanHang_TheoMaPhieu(HDBanHang[j].MaHDBanHang);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trong HD bán Hàng  vào ctBCXH
                        for (int k = 0; k < ctHDBanHang1.Length; k++)
                        {
                            ////////////////////////////////////////////////MRK FIX
                            if (!GoiHangOrHangHoa(ctHDBanHang1[k].MaHangHoa))
                            {//là hàng hóa
                                if (ctBCXH[i].MaHangHoa == ctHDBanHang1[k].MaHangHoa)
                                {
                                    ctBCXH[i].TongSoLuongXuat = ctBCXH[i].TongSoLuongXuat + ctHDBanHang1[k].SoLuong;
                                }
                            }
                            else
                            {//là gói hàng
                                foreach (Entities.GoiHang gh in goihang)
                                {
                                    foreach (Entities.ChiTietGoiHang ctgh in chitietgoihang)
                                    {
                                        if (gh.MaGoiHang.Equals(ctgh.MaGoiHang) && ctgh.MaGoiHang.Equals(ctHDBanHang1[k].MaHangHoa) && ctgh.MaHangHoa.Equals(ctBCXH[i].MaHangHoa))
                                        {
                                            ctBCXH[i].TongSoLuongXuat += (ctHDBanHang1[k].SoLuong * ctgh.SoLuong);
                                        }
                                    }
                                }
                            }
                            ////////////////////////////////////////////////MRK FIX
                        }
                    }

                    // Tính Tổng Số Lượng Hàng Hóa Xuất Trong Phiếu Điều Chuyển Kho
                    for (int j = 0; j < PDieuChuyen.Length; j++)
                    {
                        Entities.ChiTietPhieuDieuChuyenKho[] ctPDCK1 = LayChiTiet_PhieuDieuChuyenKho_TheoMaPhieu(PDieuChuyen[j].MaPhieuDieuChuyenKho);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trong Phiếu Điều Chuyển vào ctBCXH
                        for (int k = 0; k < ctPDCK1.Length; k++)
                        {
                            ////////////////////////////////////////////////MRK FIX
                            if (!GoiHangOrHangHoa(ctPDCK1[k].MaHangHoa))
                            {//là hàng hóa
                                if (ctBCXH[i].MaHangHoa == ctPDCK1[k].MaHangHoa)
                                {
                                    ctBCXH[i].TongSoLuongXuat = ctBCXH[i].TongSoLuongXuat + ctPDCK1[k].SoLuong;
                                }
                            }
                            else
                            {//là gói hàng
                                foreach (Entities.GoiHang gh in goihang)
                                {
                                    foreach (Entities.ChiTietGoiHang ctgh in chitietgoihang)
                                    {
                                        if (gh.MaGoiHang.Equals(ctgh.MaGoiHang) && ctgh.MaGoiHang.Equals(ctPDCK1[k].MaHangHoa) && ctgh.MaHangHoa.Equals(ctBCXH[i].MaHangHoa))
                                        {
                                            ctBCXH[i].TongSoLuongXuat += (ctPDCK1[k].SoLuong * ctgh.SoLuong);
                                        }
                                    }
                                }
                            }
                            ////////////////////////////////////////////////MRK FIX
                        }
                    }


                    // Tính Tổng Số Lượng Hàng Hóa Xuất Trong Phiếu Xuất Hủy
                    for (int j = 0; j < PXuatHuy.Length; j++)
                    {
                        Entities.ChiTietXuatHuy[] ctPXuatHuy1 = LayChiTiet_XuatHuy_TheoMaPhieu(PXuatHuy[j].MaPhieuXuatHuy);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trong Phiếu Xuất Hủy vào ctBCXH
                        for (int k = 0; k < ctPXuatHuy1.Length; k++)
                        {
                            if (ctBCXH[i].MaHangHoa == ctPXuatHuy1[k].MaHangHoa)
                            {
                                ctBCXH[i].TongSoLuongXuat = ctBCXH[i].TongSoLuongXuat + ctPXuatHuy1[k].SoLuong;

                            }
                        }

                    }

                    // Tính Tổng Số Lượng Hàng Hóa Xuất Trong Trả Lại NCC
                    for (int j = 0; j < TraLaiNCC.Length; j++)
                    {
                        Entities.ChiTietTraLaiNhaCungCap[] ctTraLaiNCC1 = LayChiTiet_TraLaiNCC_TheoMaPhieu(TraLaiNCC[j].MaHDTraLaiNCC);
                        // Cộng dồn Số Lượng Từng Hàng Hóa Trả Lại NCC vào ctBCXH
                        for (int k = 0; k < ctTraLaiNCC1.Length; k++)
                        {
                            if (ctBCXH[i].MaHangHoa == ctTraLaiNCC1[k].MaHangHoa)
                            {
                                ctBCXH[i].TongSoLuongXuat = ctBCXH[i].TongSoLuongXuat + ctTraLaiNCC1[k].SoLuong;
                            }
                        }

                    }

                }



            }
            catch
            {

            }
        }

        public Entities.BCXuatHangTheoNhomHang[] ArrBCXH;
        public void ArrTongHangXuat()
        {
            ArrBCXH = new Entities.BCXuatHangTheoNhomHang[NhomHang.Length];
            for (int i = 0; i < NhomHang.Length; i++)
            {

                LayChiTiet_HangHoaXuat_TheoNhomHang(NhomHang[i].MaNhomHang, NhomHang[i].TenNhomHang);
                LayChiTiet_SoLuong_HangHoaXuat_TheoKho();

                ArrBCXH[i] = new Entities.BCXuatHangTheoNhomHang();

                int TongHangHoaXuatTheoKho = 0;
                for (int j = 0; j < ctBCXH.Length; j++)
                {
                    TongHangHoaXuatTheoKho = TongHangHoaXuatTheoKho + ctBCXH[j].TongSoLuongXuat;
                }
                ArrBCXH[i].MaNhomHang = NhomHang[i].MaNhomHang;
                ArrBCXH[i].TenNhomHang = NhomHang[i].TenNhomHang;
                ArrBCXH[i].TongSoLuongXuat = TongHangHoaXuatTheoKho;
                ctBCXH = null;
            }
        }
        DateTime BatDau, KetThuc;

        public void LayNgay()
        {
            BatDau = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), 1);
            KetThuc = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), DateTime.DaysInMonth(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text)));
            //BatDau = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), 1);
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
                LayNhomHang();
                LayNgay();
                LayHangHoa();
                GoiHang();
                ChiTietGoiHang();
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
                List<Entities.BCXuatHangTheoNhomHang> tem0 = new List<BCXuatHangTheoNhomHang>();
                double tong0 = 0;
                foreach (Entities.BCXuatHangTheoNhomHang item in ArrBCXH)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    tong0 += item.TongSoLuongXuat;
                    tem0.Add(item);
                }
                Entities.BCXuatHangTheoNhomHang tem1 = new BCXuatHangTheoNhomHang();
                tem1.TenNhomHang = "Tổng: ";
                tem1.TongSoLuongXuat = (int)tong0;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = ArrBCXH;
                dtgvhienthi.DataSource = tem0.ToArray();
                FixDatagridview();
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
            dtgvhienthi.Columns["MaNhomHang"].HeaderText = "Mã Nhóm Hàng";
            dtgvhienthi.Columns["TenNhomHang"].HeaderText = "Tên Nhóm Hàng";
            dtgvhienthi.Columns["TongSoLuongXuat"].HeaderText = "Tổng Số Lượng Xuất";
         
            dtgvhienthi.AllowUserToResizeRows = false;
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvhienthi.ReadOnly = true;
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
            string maNhomHang = dtgvhienthi.Rows[e.RowIndex].Cells["MaNhomHang"].Value.ToString();
            string tenNhomHang = dtgvhienthi.Rows[e.RowIndex].Cells["TenNhomHang"].Value.ToString();
            if ((int)dtgvhienthi.Rows[e.RowIndex].Cells["TongSoLuongXuat"].Value == 0)
            {
                MessageBox.Show("Không có Hàng Xuất từ kho" + tenNhomHang + " trong Khoảng từ ngày : " +xulyNgay( BatDau) + " đến " +xulyNgay( KetThuc) + " ");
            }
            else
            {
                LayChiTiet_HangHoaXuat_TheoNhomHang(maNhomHang, tenNhomHang);
                LayChiTiet_SoLuong_HangHoaXuat_TheoKho();

                //dtgvhienthi.DataSource=ctBCXH;
                //FixDatagridview();
                
                frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH, BatDau,KetThuc);
                frm.ShowDialog();
                ctBCXH = null;

            }
        }

        private void frmBCXuatHangTheoNhomHang_Load(object sender, EventArgs e)
        {
            try
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

                LayNhomHang();
                //Entities.NhomHang[] K_nhomhang = this.NhomHang;
                LayNgay();
                DateTime K_BatDau = this.BatDau;
                DateTime K_KetThuc = this.KetThuc;
                GoiHang();
                ChiTietGoiHang();
                //Entities.GoiHang[] K_goihang = this.goihang;
                //Entities.ChiTietGoiHang[] K_chitietgoihang = this.chitietgoihang;
                LayHangHoa();
                //Entities.HangHoa[] K_hanghoa = this.HangHoa;
                LayHDBanHang();
                //Entities.HDBanHang[] K_HDBanHang = this.HDBanHang;
                LayChiTiet_HDBanHang();
                //Entities.ChiTietHDBanHang[] K_ctHDBanHang = this.ctHDBanHang;
                LayPhieuDieuChuyenKhoNoiBo();
                //Entities.PhieuDieuChuyenKhoNoiBo[] K_PDieuChuyen = this.PDieuChuyen;
                LayChiTiet_PhieuDieuChuyenKho();
                //Entities.ChiTietPhieuDieuChuyenKho[] K_ctPDCK = this.ctPDCK;
                LayPhieuXuatHuy();
                //Entities.PhieuXuatHuy[] K_PXuatHuy = this.PXuatHuy;
                LayChiTiet_XuatHuy();
                //Entities.ChiTietXuatHuy[] K_ctPXuatHuy = this.ctPXuatHuy;
                LayTraLaiNCC();
                //Entities.TraLaiNCC[] K_TraLaiNCC = this.TraLaiNCC;
                LayChiTiet_TraLaiNCC();
                //Entities.ChiTietTraLaiNhaCungCap[] K_ctTraLaiNCC = this.ctTraLaiNCC;
                LayChiTiet_HangHoaXuat();

                ArrTongHangXuat();
                ///////////////////////////////MRK FIX
                List<Entities.BCXuatHangTheoNhomHang> tem0 = new List<BCXuatHangTheoNhomHang>();
                double tong0 = 0;
                foreach (Entities.BCXuatHangTheoNhomHang item in ArrBCXH)
                {
                    tong0 += item.TongSoLuongXuat;
                    tem0.Add(item);
                }
                Entities.BCXuatHangTheoNhomHang tem1 = new BCXuatHangTheoNhomHang();
                tem1.TenNhomHang = "Tổng: ";
                tem1.TongSoLuongXuat = (int)tong0;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = ArrBCXH;
                dtgvhienthi.DataSource = tem0.ToArray();

                FixDatagridview();
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
            catch
            {
            }
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            string maNhomHang = dtgvhienthi.CurrentRow.Cells["MaNhomHang"].Value.ToString();
            string tenNhomHang = dtgvhienthi.CurrentRow.Cells["TenNhomHang"].Value.ToString();
            if ((int)dtgvhienthi.CurrentRow.Cells["TongSoLuongXuat"].Value == 0)
            {
                MessageBox.Show("Không có Hàng Xuất từ kho" + tenNhomHang + " trong Khoảng từ ngày : " + xulyNgay(BatDau) + " đến " + xulyNgay(KetThuc) + " ");
            }
            else
            {
                LayChiTiet_HangHoaXuat_TheoNhomHang(maNhomHang, tenNhomHang);
                LayChiTiet_SoLuong_HangHoaXuat_TheoKho();

                //dtgvhienthi.DataSource=ctBCXH;
                //FixDatagridview();

                frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH, BatDau, KetThuc);
                frm.ShowDialog();
                ctBCXH = null;

            }
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            string maNhomHang = dtgvhienthi.CurrentRow.Cells["MaNhomHang"].Value.ToString();
            string tenNhomHang = dtgvhienthi.CurrentRow.Cells["TenNhomHang"].Value.ToString();
            if ((int)dtgvhienthi.CurrentRow.Cells["TongSoLuongXuat"].Value == 0)
            {
                MessageBox.Show("Không có Hàng Xuất từ kho" + tenNhomHang + " trong Khoảng từ ngày : " + xulyNgay(BatDau) + " đến " + xulyNgay(KetThuc) + " ");
            }
            else
            {
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                 if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                 {

                     LayChiTiet_HangHoaXuat_TheoNhomHang(maNhomHang, tenNhomHang);
                     LayChiTiet_SoLuong_HangHoaXuat_TheoKho();

                     //dtgvhienthi.DataSource=ctBCXH;
                     //FixDatagridview();

                     frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH, BatDau, KetThuc,saveFileDialog1.FileName,"PDF");
                   
                     ctBCXH = null;
                 }
            }
        }

        private void tsslWord_Click(object sender, EventArgs e)
        {
             string maNhomHang = dtgvhienthi.CurrentRow.Cells["MaNhomHang"].Value.ToString();
            string tenNhomHang = dtgvhienthi.CurrentRow.Cells["TenNhomHang"].Value.ToString();
            if ((int)dtgvhienthi.CurrentRow.Cells["TongSoLuongXuat"].Value == 0)
            {
                MessageBox.Show("Không có Hàng Xuất từ kho" + tenNhomHang + " trong Khoảng từ ngày : " + xulyNgay(BatDau) + " đến " + xulyNgay(KetThuc) + " ");
            }
            else
            {
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                 if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                 {

                     LayChiTiet_HangHoaXuat_TheoNhomHang(maNhomHang, tenNhomHang);
                     LayChiTiet_SoLuong_HangHoaXuat_TheoKho();

                     //dtgvhienthi.DataSource=ctBCXH;
                     //FixDatagridview();

                     frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH, BatDau, KetThuc,saveFileDialog1.FileName,"Word");
                     
                     ctBCXH = null;
                 }
            }
        }

        private void tsslExcel_Click(object sender, EventArgs e)
        {
            string maNhomHang = dtgvhienthi.CurrentRow.Cells["MaNhomHang"].Value.ToString();
            string tenNhomHang = dtgvhienthi.CurrentRow.Cells["TenNhomHang"].Value.ToString();
            if ((int)dtgvhienthi.CurrentRow.Cells["TongSoLuongXuat"].Value == 0)
            {
                MessageBox.Show("Không có Hàng Xuất từ kho" + tenNhomHang + " trong Khoảng từ ngày : " + xulyNgay(BatDau) + " đến " + xulyNgay(KetThuc) + " ");
            }
            else
            {
                 saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                 if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                 {

                     LayChiTiet_HangHoaXuat_TheoNhomHang(maNhomHang, tenNhomHang);
                     LayChiTiet_SoLuong_HangHoaXuat_TheoKho();

                     //dtgvhienthi.DataSource=ctBCXH;
                     //FixDatagridview();

                     frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH, BatDau, KetThuc,saveFileDialog1.FileName,"Excel");
                     
                     ctBCXH = null;
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
                List<Entities.BCXuatHangTheoNhomHang> tem0 = new List<BCXuatHangTheoNhomHang>();
                double tong0 = 0;
                foreach (Entities.BCXuatHangTheoNhomHang item in ctBCXH_Search)
                {
                    tong0 += item.TongSoLuongXuat;
                    tem0.Add(item);
                }
                Entities.BCXuatHangTheoNhomHang tem1 = new BCXuatHangTheoNhomHang();
                tem1.TenNhomHang = "Tổng: ";
                tem1.TongSoLuongXuat = (int)tong0;
                tem0.Add(tem1);
                //////////////////////////////////////
                dtgvhienthi.DataSource = tem0.ToArray();
                //dtgvhienthi.DataSource = ctBCXH_Search;
                FixDatagridview();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (rdbTen.Checked == true)
            {

                if (ctBCXH_Search == null)
                {
                    BCXuatHangTheoNhomHang[] tkkt = new BCXuatHangTheoNhomHang[0];
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
                            BCXuatHangTheoNhomHang[] tkkt = new BCXuatHangTheoNhomHang[0];
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
                                index = ctBCXH_Search[i].TenNhomHang.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                if (index >= 0)
                                {
                                    ctBCXH_Search_count++;
                                }
                            }
                            BCXuatHangTheoNhomHang[] ctBCXH_Search1 = new BCXuatHangTheoNhomHang[ctBCXH_Search_count];
                            ctBCXH_Search_count = 0;

                            for (int i = 0; i < ctBCXH_Search.Length; i++)
                            {
                                int index = -1;
                                index = ctBCXH_Search[i].TenNhomHang.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
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
                            List<Entities.BCXuatHangTheoNhomHang> tem0 = new List<BCXuatHangTheoNhomHang>();
                            double tong0 = 0;
                            foreach (Entities.BCXuatHangTheoNhomHang item in ctBCXH_Search1)
                            {
                                tong0 += item.TongSoLuongXuat;
                                tem0.Add(item);
                            }
                            Entities.BCXuatHangTheoNhomHang tem1 = new BCXuatHangTheoNhomHang();
                            tem1.TenNhomHang = "Tổng: ";
                            tem1.TongSoLuongXuat = (int)tong0;
                            tem0.Add(tem1);
                            //////////////////////////////////////
                            dtgvhienthi.DataSource = tem0.ToArray();
                            //dtgvhienthi.DataSource = ctBCXH_Search1;
                            FixDatagridview();
                        }
                    }
            }
            else
                if (rdbMa.Checked == true)
                {
                    if (ctBCXH_Search == null)
                    {
                        BCXuatHangTheoNhomHang[] tkkt = new BCXuatHangTheoNhomHang[0];
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
                                BCXuatHangTheoNhomHang[] tkkt = new BCXuatHangTheoNhomHang[0];
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
                                    index = ctBCXH_Search[i].MaNhomHang.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                    if (index >= 0)
                                    {
                                        ctBCXH_Search_count++;
                                    }
                                }
                                BCXuatHangTheoNhomHang[] ctBCXH_Search1 = new BCXuatHangTheoNhomHang[ctBCXH_Search_count];
                                ctBCXH_Search_count = 0;

                                for (int i = 0; i < ctBCXH_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = ctBCXH_Search[i].MaNhomHang.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
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
                                List<Entities.BCXuatHangTheoNhomHang> tem0 = new List<BCXuatHangTheoNhomHang>();
                                double tong0 = 0;
                                foreach (Entities.BCXuatHangTheoNhomHang item in ctBCXH_Search1)
                                {
                                    tong0 += item.TongSoLuongXuat;
                                    tem0.Add(item);
                                }
                                Entities.BCXuatHangTheoNhomHang tem1 = new BCXuatHangTheoNhomHang();
                                tem1.TenNhomHang = "Tổng: ";
                                tem1.TongSoLuongXuat = (int)tong0;
                                tem0.Add(tem1);
                                //////////////////////////////////////
                                dtgvhienthi.DataSource = tem0.ToArray();
                                //dtgvhienthi.DataSource = ctBCXH_Search1;
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
