using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
namespace GUI
{
    public partial class frmCongNo : Form
    {
        public string month;
        public string year;
        public TcpClient client1;
        public NetworkStream clientstrem;
        DateTime datesv;
        List<Entities.TongHopCongNo> congNoList = new List<Entities.TongHopCongNo>();
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        public frmCongNo()
        {
            InitializeComponent(); datesv = DateServer.Date();
            cbbdoituong.SelectedIndex = 0;
            if (cbbdoituong.Text != "" && year != "" && month != "")
                HienThiTong();
            datesv = DateServer.Date();
            cbbnam.Text = datesv.Year.ToString();
            cbbthang.Text = datesv.Month.ToString();
            month = cbbthang.Text;
            year = cbbnam.Text;
        }
        public frmCongNo(string nam, string thang, int loaiDoiTuong)
        {
            InitializeComponent();
            cbbdoituong.SelectedIndex = loaiDoiTuong;
            month = thang;
            year = nam;
            cbbnam.Text = nam;
            cbbthang.Text = thang;
            HienThiTong();
        }
        Server_Client.Client cl;
        Entities.PhieuThu[] phieuThuChi = new Entities.PhieuThu[0];
        Entities.KhachHang[] kh;
        Entities.NhaCungCap[] ncc;
        Entities.HDBanHang[] buonle;
        Entities.HDBanHang[] bb;
        List<Entities.CongNo> hienthi;
        List<Entities.CongNo> congnokh;
        List<Entities.CongNo> congnoncc;
        Entities.HoaDonNhap[] hdn;
        Entities.TraLaiNCC[] tl;
        Entities.KhachHangTraLai[] khtl;
        Entities.ChiTietPhieuTTCuaKH[] chitietphieuttcuakh;
        Entities.ChiTietPhieuTTNCC[] chitietphieuttncc;
        Entities.PhieuTTCuaKH[] phieuttcuakh;
        Entities.PhieuTTNCC[] phieuttncc;
        public static List<Entities.SoDuCongNo> mangchitiet;
        Entities.SoDuCongNo[] hienthi1;
        public void SelectSoDuCongNo()
        {
            try
            {
                bool loaiDoiTuong = false;
                if (cbbdoituong.SelectedIndex == 0)
                    loaiDoiTuong = false;
                else
                    loaiDoiTuong = true;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.SoDuCongNo[] pt = new Entities.SoDuCongNo[1];
                pt[0] = new Entities.SoDuCongNo("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                clientstrem = cl.SerializeHepper(this.client1, "CongNo", pt);
                Entities.CongNo[] hienthi = new Entities.CongNo[1];
                // đổ mảng đối tượng vào datagripview       
                hienthi1 = (Entities.SoDuCongNo[])cl.DeserializeHepper1(clientstrem, hienthi);
                if (hienthi1 == null)
                {
                    hienthi1 = new Entities.SoDuCongNo[0];
                    return;
                }
                year = cbbnam.Text;
                month = cbbthang.Text;
                int sotang = 0;
                Entities.SoDuCongNo[] sq = new Entities.SoDuCongNo[hienthi1.Length];
                for (int i = 0; i < sq.Length; i++)
                {
                    string namkt = hienthi1[i].NgayKetChuyen.Year.ToString();
                    string thangkt = hienthi1[i].NgayKetChuyen.Month.ToString();

                    if (namkt == year && thangkt == month && hienthi1[i].LoaiDoiTuong == loaiDoiTuong)
                    {
                        sq[sotang] = hienthi1[i];
                        sotang++;
                    }

                }
                if (sotang != 0)
                {
                    hienthi1 = new Entities.SoDuCongNo[sotang];
                    for (int i = 0; i < sotang; i++)
                    {
                        hienthi1[i] = new Entities.SoDuCongNo("", sq[i].MaSoDuCongNo, sq[i].MaDoiTuong, sq[i].TenDoiTuong, sq[i].DiaChi, sq[i].SoDuDauKy);
                    }
                }
                else
                    hienthi1 = new Entities.SoDuCongNo[0];
            }
            catch
            {
            }
            finally
            {

            }
        }
        Entities.SelectAll selectall;
        void SelectDataKH()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("BCCongNoKhachHang");
            clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
            selectall = (Entities.SelectAll)cl.DeserializeHepper(clientstrem, selectall);
            kh = selectall.KhachHang;
            bb = selectall.HDBanHang;
            hienthi1 = selectall.SoDuCongNo;
            khtl = selectall.KhachHangTraLai;
            phieuttcuakh = selectall.PhieuTTCuaKH;
            chitietphieuttcuakh = selectall.ChiTietPhieuTTCuaKH;
            phieuThuChi = selectall.PhieuThu;
            SelectKhachHang();
            SelectKHTL();
            SelectPhieuTTCuaKH();
            SelectChiTietPhieuTTCuaKH();
            phieuttncc = new Entities.PhieuTTNCC[0];
            chitietphieuttncc = new Entities.ChiTietPhieuTTNCC[0];
            ncc = new Entities.NhaCungCap[0];
            hdn = new Entities.HoaDonNhap[0];
            tl = new Entities.TraLaiNCC[0];
            mangchitiet = new List<Entities.SoDuCongNo>();

        }
        void SelectDataNCC()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("BCCongNoNhaCungCap");
            clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
            selectall = (Entities.SelectAll)cl.DeserializeHepper(clientstrem, selectall);
            hienthi1 = selectall.SoDuCongNo;
            bb = selectall.HDBanHang;
            ncc = selectall.NhaCungCap;
            hdn = selectall.HoaDonNhap;
            tl = selectall.TraLaiNCC;
            phieuttncc = selectall.PhieuTTNCC;
            chitietphieuttncc = selectall.ChiTietPhieuTTNCC;
            phieuThuChi = selectall.PhieuThu;
            SelectNhaCungCap();
            SelectNhapKho();
            SelectTLNCC();
            SelectPhieuTTNCC();
            SelectChiTietPhieuTTNCC();
            phieuttcuakh = new Entities.PhieuTTCuaKH[0];
            chitietphieuttcuakh = new Entities.ChiTietPhieuTTCuaKH[0];
            kh = new Entities.KhachHang[0];
            khtl = new Entities.KhachHangTraLai[0];
            mangchitiet = new List<Entities.SoDuCongNo>();
        }


        /// select bán buôn - bán lẻ
        /// </summary>
        public void SelectBanBuonLe()
        {
            try
            {
                if (bb == null || bb.Length == 0)
                {
                    bb = new Entities.HDBanHang[0];
                    return;
                }
                Entities.HDBanHang[] pt2 = new Entities.HDBanHang[bb.Length];
                int sotang = 0;
                for (int j = 0; j < bb.Length; j++)
                {
                    string month1 = bb[j].NgayBan.Month.ToString();
                    string year1 = bb[j].NgayBan.Year.ToString();
                    if (bb[j].LoaiHoaDon == false && bb[j].Deleted == false && month == month1 && year1 == year)
                    {
                        pt2[sotang] = bb[j];
                        sotang++;
                    }
                }
                bb = new Entities.HDBanHang[sotang];
                if (sotang != 0)
                {

                    for (int j = 0; j < sotang; j++)
                    {
                        bb[j] = pt2[j];
                    }
                }
                else
                    bb = new Entities.HDBanHang[0];
            }
            catch { }
        }
        /// <summary>
        /// select khách hàng
        /// </summary>
        public void SelectKhachHang()
        {
            try
            {
                i = 0;
                if (kh == null || kh.Length == 0)
                {
                    kh = new Entities.KhachHang[0];
                    return;
                }

                Entities.KhachHang[] pt2 = new Entities.KhachHang[kh.Length];
                int sotang = 0;
                for (int j = 0; j < kh.Length; j++)
                {
                    if (kh[j].Deleted == false)
                    {
                        pt2[sotang] = kh[j];
                        sotang++;
                    }
                }

                kh = new Entities.KhachHang[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        kh[j] = pt2[j];
                    }
                }
                else
                    kh = new Entities.KhachHang[0];
            }
            catch { }
        }
        /// <summary>
        /// select nhà cung cấp
        /// </summary>
        public void SelectNhaCungCap()
        {
            try
            {
                i = 0;
                if (ncc == null || ncc.Length == 0)
                {
                    ncc = new Entities.NhaCungCap[0];
                    return;
                }

                Entities.NhaCungCap[] pt2 = new Entities.NhaCungCap[ncc.Length];
                int sotang = 0;
                for (int j = 0; j < ncc.Length; j++)
                {
                    if (ncc[j].Deleted == false)
                    {
                        pt2[sotang] = ncc[j];
                        sotang++;
                    }
                }

                ncc = new Entities.NhaCungCap[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        ncc[j] = pt2[j];
                    }
                }
                else
                    ncc = new Entities.NhaCungCap[0];
            }
            catch { }
        }
        /// <summary>
        /// select nhập kho
        /// </summary>
        private void SelectNhapKho()
        {
            try
            {

                if (hdn == null || hdn.Length == 0)
                {
                    hdn = new Entities.HoaDonNhap[0];
                    return;
                }

                Entities.HoaDonNhap[] pt2 = new Entities.HoaDonNhap[hdn.Length];
                int sotang = 0;
                for (int j = 0; j < hdn.Length; j++)
                {
                    string month1 = hdn[j].NgayNhap.Month.ToString();
                    string year1 = hdn[j].NgayNhap.Year.ToString();
                    if (hdn[j].Deleted == false && month1 == month && year1 == year)
                    {
                        pt2[sotang] = hdn[j];
                        sotang++;
                    }
                }
                hdn = new Entities.HoaDonNhap[sotang];
                if (sotang != 0)
                {

                    for (int j = 0; j < sotang; j++)
                    {
                        hdn[j] = pt2[j];
                    }
                }
                else
                    hdn = new Entities.HoaDonNhap[0];
            }
            catch { }
        }
        /// <summary>
        /// select khách hàng trả lại
        /// </summary>
        private void SelectKHTL()
        {
            try
            {
                if (khtl == null || khtl.Length == 0)
                {
                    khtl = new Entities.KhachHangTraLai[0];
                    return;
                }

                Entities.KhachHangTraLai[] pt2 = new Entities.KhachHangTraLai[khtl.Length];
                int sotang = 0;
                for (int j = 0; j < khtl.Length; j++)
                {
                    string month1 = khtl[j].NgayNhap.Month.ToString();
                    string year1 = khtl[j].NgayNhap.Year.ToString();
                    if (khtl[j].Deleted == false && month == month1 && year1 == year)
                    {
                        pt2[sotang] = khtl[j];
                        sotang++;
                    }
                }
                khtl = new Entities.KhachHangTraLai[sotang];
                if (sotang != 0)
                {

                    for (int j = 0; j < sotang; j++)
                    {
                        khtl[j] = pt2[j];
                    }
                }
                else
                    khtl = new Entities.KhachHangTraLai[0];
            }
            catch { }
        }
        /// <summary>
        /// select trả lại nhà cung cấp
        /// </summary>
        private void SelectTLNCC()
        {
            try
            {
                if (tl == null || tl.Length == 0)
                {
                    tl = new Entities.TraLaiNCC[0];
                    return;
                }

                Entities.TraLaiNCC[] pt2 = new Entities.TraLaiNCC[tl.Length];
                int sotang = 0;
                for (int j = 0; j < tl.Length; j++)
                {
                    string month1 = tl[j].Ngaytra.Month.ToString();
                    string year1 = tl[j].Ngaytra.Year.ToString();

                    if (tl[j].Deleted == false && month1 == month && year1 == year)
                    {
                        pt2[sotang] = tl[j];
                        sotang++;
                    }
                }
                tl = new Entities.TraLaiNCC[sotang];
                if (sotang != 0)
                {

                    for (int j = 0; j < sotang; j++)
                    {
                        tl[j] = pt2[j];
                    }
                }
                else
                    tl = new Entities.TraLaiNCC[0];
            }
            catch { }
        }

        private void SelectPhieuTTCuaKH()
        {
            try
            {
                if (phieuttcuakh == null || phieuttcuakh.Length == 0)
                {
                    phieuttcuakh = new Entities.PhieuTTCuaKH[0];
                    return;
                }

                Entities.PhieuTTCuaKH[] pt2 = new Entities.PhieuTTCuaKH[phieuttcuakh.Length];
                int sotang = 0;
                for (int j = 0; j < phieuttcuakh.Length; j++)
                {
                    string month1 = phieuttcuakh[j].NgayLap.Month.ToString();
                    string year1 = phieuttcuakh[j].NgayLap.Year.ToString();

                    if (phieuttcuakh[j].Deleted == false && month1 == month && year1 == year)
                    {
                        pt2[sotang] = phieuttcuakh[j];
                        sotang++;
                    }
                }
                phieuttcuakh = new Entities.PhieuTTCuaKH[sotang];
                if (sotang != 0)
                {

                    for (int j = 0; j < sotang; j++)
                    {
                        phieuttcuakh[j] = pt2[j];
                    }
                }
                else
                    phieuttcuakh = new Entities.PhieuTTCuaKH[0];
            }
            catch { }
        }

        private void SelectChiTietPhieuTTCuaKH()
        {
            try
            {
                if (chitietphieuttcuakh == null || chitietphieuttcuakh.Length == 0)
                {
                    chitietphieuttcuakh = new Entities.ChiTietPhieuTTCuaKH[0];
                    return;
                }

                Entities.ChiTietPhieuTTCuaKH[] pt2 = new Entities.ChiTietPhieuTTCuaKH[chitietphieuttcuakh.Length];
                int sotang = 0;
                for (int j = 0; j < chitietphieuttcuakh.Length; j++)
                {
                    if (chitietphieuttcuakh[j].Deleted == false)
                    {
                        pt2[sotang] = chitietphieuttcuakh[j];
                        sotang++;
                    }
                }
                chitietphieuttcuakh = new Entities.ChiTietPhieuTTCuaKH[sotang];
                if (sotang != 0)
                {

                    for (int j = 0; j < sotang; j++)
                    {
                        chitietphieuttcuakh[j] = pt2[j];
                    }
                }
                else
                    chitietphieuttcuakh = new Entities.ChiTietPhieuTTCuaKH[0];
            }
            catch { }
        }

        private void SelectPhieuTTNCC()
        {
            try
            {
                if (phieuttncc == null || phieuttncc.Length == 0)
                {
                    phieuttncc = new Entities.PhieuTTNCC[0];
                    return;
                }

                Entities.PhieuTTNCC[] pt2 = new Entities.PhieuTTNCC[phieuttncc.Length];
                int sotang = 0;
                for (int j = 0; j < phieuttncc.Length; j++)
                {
                    string month1 = phieuttncc[j].NgayLap.Month.ToString();
                    string year1 = phieuttncc[j].NgayLap.Year.ToString();

                    if (phieuttncc[j].Deleted == false && month1 == month && year1 == year)
                    {
                        pt2[sotang] = phieuttncc[j];
                        sotang++;
                    }
                }
                phieuttncc = new Entities.PhieuTTNCC[sotang];
                if (sotang != 0)
                {

                    for (int j = 0; j < sotang; j++)
                    {
                        phieuttncc[j] = pt2[j];
                    }
                }
                else
                    phieuttncc = new Entities.PhieuTTNCC[0];
            }
            catch { }
        }

        private void SelectChiTietPhieuTTNCC()
        {
            try
            {
                if (chitietphieuttncc == null || chitietphieuttncc.Length == 0)
                {
                    chitietphieuttncc = new Entities.ChiTietPhieuTTNCC[0];
                    return;
                }

                Entities.ChiTietPhieuTTNCC[] pt2 = new Entities.ChiTietPhieuTTNCC[chitietphieuttncc.Length];
                int sotang = 0;
                for (int j = 0; j < chitietphieuttncc.Length; j++)
                {
                    if (chitietphieuttncc[j].Deleted == false)
                    {
                        pt2[sotang] = chitietphieuttncc[j];
                        sotang++;
                    }
                }
                chitietphieuttncc = new Entities.ChiTietPhieuTTNCC[sotang];
                if (sotang != 0)
                {

                    for (int j = 0; j < sotang; j++)
                    {
                        chitietphieuttncc[j] = pt2[j];
                    }
                }
                else
                    chitietphieuttncc = new Entities.ChiTietPhieuTTNCC[0];
            }
            catch { }
        }

        public void fixNCC()
        {
            for (int i = 0; i < dtgvcongno.ColumnCount; i++)
            {
                dtgvcongno.Columns[i].Visible = false;
            }
            new Common.Utilities().CountDatagridview(dtgvcongno);
            dtgvcongno.ReadOnly = true;
            dtgvcongno.Columns["HanhDong"].Visible = true;
            dtgvcongno.Columns["MaDoiTuong"].Visible = true;
            dtgvcongno.Columns["TenDoiTuong"].Visible = true;
            dtgvcongno.Columns["DuDauKy"].Visible = true;
            dtgvcongno.Columns["PhatSinhNo"].Visible = true;
            dtgvcongno.Columns["PhatSinhCo"].Visible = true;
            dtgvcongno.Columns["DuCuoiKy"].Visible = true;
            dtgvcongno.Columns["DiaChi"].Visible = true;
            dtgvcongno.Columns["HanhDong"].HeaderText = "STT";
            dtgvcongno.Columns["MaDoiTuong"].HeaderText = "Mã Nhà Cung Cấp";
            dtgvcongno.Columns["TenDoiTuong"].HeaderText = "Tên Nhà Cung Cấp";
            dtgvcongno.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dtgvcongno.Columns["DuDauKy"].HeaderText = "Dư đầu kỳ";
            dtgvcongno.Columns["PhatSinhNo"].HeaderText = "Phát sinh nợ";
            dtgvcongno.Columns["PhatSinhCo"].HeaderText = "Phát sinh có";
            dtgvcongno.Columns["DuCuoiKy"].HeaderText = "Dư cuối kỳ";
            dtgvcongno.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvcongno.AllowUserToAddRows = false;
            dtgvcongno.AllowUserToDeleteRows = false;
            dtgvcongno.AllowUserToResizeRows = false;
            dtgvcongno.RowHeadersVisible = false;
            this.Focus(); this.WindowState = FormWindowState.Maximized;
        }
        /// <summary>
        /// fix dtgv
        /// </summary>
        public void fixKH()
        {
            for (int i = 0; i < dtgvcongno.ColumnCount; i++)
            {
                dtgvcongno.Columns[i].Visible = false;
            }
            new Common.Utilities().CountDatagridview(dtgvcongno);
            dtgvcongno.ReadOnly = true;
            dtgvcongno.Columns["HanhDong"].Visible = true;
            dtgvcongno.Columns["MaDoiTuong"].Visible = true;
            dtgvcongno.Columns["TenDoiTuong"].Visible = true;
            dtgvcongno.Columns["DuDauKy"].Visible = true;
            dtgvcongno.Columns["PhatSinhNo"].Visible = true;
            dtgvcongno.Columns["PhatSinhCo"].Visible = true;
            dtgvcongno.Columns["DuCuoiKy"].Visible = true;
            dtgvcongno.Columns["DiaChi"].Visible = true;
            dtgvcongno.Columns["HanhDong"].HeaderText = "STT";
            dtgvcongno.Columns["MaDoiTuong"].HeaderText = "Mã Khách Hàng";
            dtgvcongno.Columns["TenDoiTuong"].HeaderText = "Tên Khách Hàng";
            dtgvcongno.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dtgvcongno.Columns["DuDauKy"].HeaderText = "Dư đầu kỳ";
            dtgvcongno.Columns["PhatSinhNo"].HeaderText = "Phát sinh nợ";
            dtgvcongno.Columns["PhatSinhCo"].HeaderText = "Phát sinh có";
            dtgvcongno.Columns["DuCuoiKy"].HeaderText = "Dư cuối kỳ";
            dtgvcongno.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvcongno.AllowUserToAddRows = false;
            dtgvcongno.AllowUserToDeleteRows = false;
            dtgvcongno.AllowUserToResizeRows = false;
            dtgvcongno.RowHeadersVisible = false;
            this.Focus(); this.WindowState = FormWindowState.Maximized;
        }
        double phatsinhno = 0;
        double phatsinhco = 0;
        double sdck = 0;
        double sddk = 0;
        /// <summary>
        /// hiển thị tổng
        /// </summary>
        public void HienThiTong()
        {
            try
            {
                if (cbbdoituong.SelectedIndex == 0)
                {
                    SelectDataKH();
                }
                else
                {
                    SelectDataNCC();
                }
                SelectBanBuonLe();

                hienthi = new List<Entities.CongNo>();

                congnokh = new List<Entities.CongNo>();

                congnoncc = new List<Entities.CongNo>();
                int soluong = 0;
                int soluongkh = 0;
                int soluongncc = 0;
                sdck = sddk = 0;
                if (cbbdoituong.SelectedIndex == 0)
                {
                    string maSoDuCongNo = "";
                    SelectSoDuCongNo();
                    // Khách Hàng
                    for (int i = 0; i < kh.Length; i++)
                    {
                        phatsinhco = 0;
                        phatsinhno = 0;
                        sddk = 0;
                        for (int j = 0; j < hienthi1.Length; j++)
                        {
                            if (hienthi1[j].MaDoiTuong == kh[i].MaKH)
                            {
                                maSoDuCongNo = hienthi1[j].MaSoDuCongNo;
                                sddk = Double.Parse(hienthi1[j].SoDuDauKy);
                                break;
                            }
                        }
                        // bán buôn
                        for (int j = 0; j < bb.Length; j++)
                        {
                            if (bb[j].MaKhachHang == kh[i].MaKH)
                            {
                                double a = Convert.ToDouble(bb[j].TongTienThanhToan);
                                double b = Convert.ToDouble(bb[j].ThanhToanKhiLapPhieu);
                                if (b > a)
                                {
                                    b = a;
                                }
                                phatsinhno += a;
                                phatsinhco += b;
                                string ngaylap = new Common.Utilities().XuLy(2, bb[j].NgayBan.ToShortDateString());
                                Entities.CongNo cn = new Entities.CongNo(ngaylap, kh[i].MaKH, kh[i].Ten, kh[i].DiaChi,
                                   Format(a), Format(b), bb[j].GhiChu, "PhieuThu");
                                hienthi.Add(cn);
                            }
                        }

                        // Phieu thu
                        for (int j = 0; j < phieuThuChi.Length; j++)
                        {
                            try
                            {
                                string month1 = phieuThuChi[j].NgayLap.Month.ToString();
                                string year1 = phieuThuChi[j].NgayLap.Year.ToString();

                                if (phieuThuChi[j].DoiTuong.Equals(kh[i].MaKH) && phieuThuChi[j].LoaiPhieu.ToUpper().Equals("Thu".ToUpper()) && phieuThuChi[j].Deleted == false && month1 == month && year1 == year)
                                {
                                    phatsinhco += double.Parse(phieuThuChi[j].TongTienThanhToan);
                                    string ngaylap = new Common.Utilities().XuLy(2, phieuThuChi[j].NgayLap.ToShortDateString());
                                    Entities.CongNo cn = new Entities.CongNo(ngaylap, kh[i].MaKH, kh[i].Ten, kh[i].DiaChi,
                                       "0", Format(double.Parse(phieuThuChi[j].TongTienThanhToan)), phieuThuChi[j].GhiChu, "Thu");
                                    hienthi.Add(cn);
                                }
                            }
                            catch { }
                        }

                        // Phieu chi
                        for (int j = 0; j < phieuThuChi.Length; j++)
                        {
                            try
                            {
                                string month1 = phieuThuChi[j].NgayLap.Month.ToString();
                                string year1 = phieuThuChi[j].NgayLap.Year.ToString();

                                if (phieuThuChi[j].DoiTuong.Equals(kh[i].MaKH) && phieuThuChi[j].LoaiPhieu.ToUpper().Equals("Chi".ToUpper()) && phieuThuChi[j].Deleted == false && month1 == month && year1 == year)
                                {
                                    phatsinhno += double.Parse(phieuThuChi[j].TongTienThanhToan);
                                    string ngaylap = new Common.Utilities().XuLy(2, phieuThuChi[j].NgayLap.ToShortDateString());
                                    Entities.CongNo cn = new Entities.CongNo(ngaylap, kh[i].MaKH, kh[i].Ten, kh[i].DiaChi,
                                       Format(double.Parse(phieuThuChi[j].TongTienThanhToan)), "0", phieuThuChi[j].GhiChu, "Chi");
                                    hienthi.Add(cn);
                                }
                            }
                            catch { }
                        }

                        // khách hàng trả lại
                        for (int j = 0; j < khtl.Length; j++)
                        {
                            if (khtl[j].MaKhachHang == kh[i].MaKH)
                            {
                                double a = Convert.ToDouble(khtl[j].TienBoiThuong);
                                double b = Convert.ToDouble(khtl[j].ThanhToanNgay);
                                if (b > a)
                                {
                                    b = a;
                                }
                                phatsinhco += a;
                                phatsinhno += b;
                                string ngaylap = new Common.Utilities().XuLy(2, khtl[j].NgayNhap.ToShortDateString());
                                Entities.CongNo cn = new Entities.CongNo(ngaylap, kh[i].MaKH, kh[i].Ten, kh[i].DiaChi, Format(b),
                                    Format(a), khtl[j].GhiChu, "PhieuThu");
                                hienthi.Add(cn);
                            }
                        }
                        // phiếu thanh toán của khách hàng
                        for (int j = 0; j < phieuttcuakh.Length; j++)
                        {
                            if (phieuttcuakh[j].MaKhachHang == kh[i].MaKH)
                            {
                                double tienthanhtoan = 0;
                                for (int k = 0; k < chitietphieuttcuakh.Length; k++)
                                {
                                    if (phieuttcuakh[j].MaPhieuTTCuaKH == chitietphieuttcuakh[k].MaPhieuTTCuaKH)
                                    {
                                        phatsinhco += Convert.ToDouble(chitietphieuttcuakh[k].ThanhToan.ToString());
                                        tienthanhtoan += Convert.ToDouble(chitietphieuttcuakh[k].ThanhToan.ToString());
                                    }
                                }
                                string ngaylap = new Common.Utilities().XuLy(2, phieuttcuakh[j].NgayLap.ToShortDateString());
                                Entities.CongNo cn = new Entities.CongNo(ngaylap, kh[i].MaKH, kh[i].Ten, kh[i].DiaChi, "0",
                                    Format(tienthanhtoan), phieuttcuakh[j].GhiChu, "PhieuTTCuaKH");
                                hienthi.Add(cn);
                            }
                        }
                        sdck = sddk + phatsinhno - phatsinhco;
                        Entities.SoDuCongNo sdcnKH = new Entities.SoDuCongNo("UpdateTrangThai", maSoDuCongNo, kh[i].MaKH, kh[i].Ten, kh[i].DiaChi, (sddk + phatsinhno - phatsinhco).ToString(), Convert.ToDateTime(cbbthang.Text + "/01/" + cbbnam.Text), false);
                        Entities.CongNo cnkh = new Entities.CongNo(kh[i].MaKH, kh[i].Ten, kh[i].DiaChi,
                            Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck));
                        mangchitiet.Add(sdcnKH);
                        congnokh.Add(cnkh);
                    }
                    sddk = phatsinhno = phatsinhco = 0;
                    // tính toán của mảng khách hàng
                    Entities.CongNo cnkh1 = new Entities.CongNo();
                    int count = congnokh.ToArray().Length;
                    if (count == 1)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            sdck = sddk + phatsinhno - phatsinhco;
                            cnkh1 = new Entities.CongNo("Tổng cộng", Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck), string.Empty);

                        }
                        congnokh.Add(cnkh1);
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            phatsinhco += Convert.ToDouble(congnokh[i].PhatSinhCo);
                            phatsinhno += Convert.ToDouble(congnokh[i].PhatSinhNo);
                            sddk += double.Parse(congnokh[i].DuDauKy);
                            sdck = sddk + phatsinhno - phatsinhco;
                            cnkh1 = new Entities.CongNo("Tổng cộng", Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck), string.Empty);
                        }
                        congnokh.Add(cnkh1);
                    }

                    Entities.TongHopCongNo thcn;
                    congNoList = new List<Entities.TongHopCongNo>();
                    foreach (Entities.CongNo item in congnokh)
                    {
                        double psn = 0;
                        double psc = 0;
                        double ddk = 0;
                        double dck = 0;
                        if (!string.IsNullOrEmpty(item.PhatSinhNo))
                            psn = double.Parse(item.PhatSinhNo);
                        if (!string.IsNullOrEmpty(item.PhatSinhCo))
                            psc = double.Parse(item.PhatSinhCo);
                        if (!string.IsNullOrEmpty(item.DuDauKy))
                            ddk = double.Parse(item.DuDauKy);
                        if (!string.IsNullOrEmpty(item.DuCuoiKy))
                            dck = double.Parse(item.DuCuoiKy);
                        thcn = new Entities.TongHopCongNo();
                        thcn.MaDoiTuong = item.MaDoiTuong;
                        thcn.TenDoiTuong = item.TenDoiTuong;
                        thcn.DiaChi = item.DiaChi;
                        thcn.PhatSinhNo = psn;
                        thcn.PhatSinhCo = psc;
                        thcn.DuDauKy = ddk;
                        thcn.DuCuoiKy = dck;
                        if (!string.IsNullOrEmpty(item.MaDoiTuong))
                            congNoList.Add(thcn);
                    }
                }
                else
                {
                    SelectSoDuCongNo();
                    // Nhà Cung Cấp
                    for (int i = 0; i < ncc.Length; i++)
                    {
                        phatsinhco = 0;
                        phatsinhno = 0;
                        sddk = 0;
                        string maSoDuCongNo = "";
                        for (int j = 0; j < hienthi1.Length; j++)
                        {
                            if (hienthi1[j].MaDoiTuong == ncc[i].MaNhaCungCap)
                            {
                                maSoDuCongNo = hienthi1[j].MaSoDuCongNo;
                                sddk = Double.Parse(hienthi1[j].SoDuDauKy);
                                break;
                            }
                        }
                        // hóa đơn nhập
                        for (int j = 0; j < hdn.Length; j++)
                        {
                            if (ncc[i].MaNhaCungCap == hdn[j].MaNhaCungCap)
                            {
                                double a = Convert.ToDouble(hdn[j].TongTien);
                                double b = Convert.ToDouble(hdn[j].ThanhToanNgay);
                                if (b > a)
                                {
                                    b = a;
                                }
                                phatsinhco += a;
                                phatsinhno += b;
                                string ngaylap = new Common.Utilities().XuLy(2, hdn[j].NgayNhap.ToShortDateString());
                                Entities.CongNo cn = new Entities.CongNo(ngaylap, ncc[i].MaNhaCungCap, ncc[i].TenNhaCungCap, ncc[i].DiaChi,
                                    Format(b), Format(a), hdn[j].GhiChu, "HoaDonNhap");
                                hienthi.Add(cn);
                            }
                        }

                        // Phieu thu
                        for (int j = 0; j < phieuThuChi.Length; j++)
                        {
                            try
                            {
                                string month1 = phieuThuChi[j].NgayLap.Month.ToString();
                                string year1 = phieuThuChi[j].NgayLap.Year.ToString();

                                if (phieuThuChi[j].DoiTuong.Equals(ncc[i].MaNhaCungCap) && phieuThuChi[j].LoaiPhieu.ToUpper().Equals("Thu".ToUpper()) && phieuThuChi[j].Deleted == false && month1 == month && year1 == year)
                                {
                                    phatsinhco += double.Parse(phieuThuChi[j].TongTienThanhToan);
                                    string ngaylap = new Common.Utilities().XuLy(2, phieuThuChi[j].NgayLap.ToShortDateString());
                                    Entities.CongNo cn = new Entities.CongNo(ngaylap, ncc[i].MaNhaCungCap, ncc[i].TenNhaCungCap, ncc[i].DiaChi,
                                       "0", Format(double.Parse(phieuThuChi[j].TongTienThanhToan)), phieuThuChi[j].GhiChu, "Thu");
                                    hienthi.Add(cn);
                                }
                            }
                            catch { }
                        }

                        // Phieu chi
                        for (int j = 0; j < phieuThuChi.Length; j++)
                        {
                            try
                            {
                                string month1 = phieuThuChi[j].NgayLap.Month.ToString();
                                string year1 = phieuThuChi[j].NgayLap.Year.ToString();

                                if (phieuThuChi[j].DoiTuong.Equals(ncc[i].MaNhaCungCap) && phieuThuChi[j].LoaiPhieu.ToUpper().Equals("Chi".ToUpper()) && phieuThuChi[j].Deleted == false && month1 == month && year1 == year)
                                {
                                    phatsinhno += double.Parse(phieuThuChi[j].TongTienThanhToan);
                                    string ngaylap = new Common.Utilities().XuLy(2, phieuThuChi[j].NgayLap.ToShortDateString());
                                    Entities.CongNo cn = new Entities.CongNo(ngaylap, ncc[i].MaNhaCungCap, ncc[i].TenNhaCungCap, ncc[i].DiaChi,
                                       Format(double.Parse(phieuThuChi[j].TongTienThanhToan)), "0", phieuThuChi[j].GhiChu, "Chi");
                                    hienthi.Add(cn);
                                }
                            }
                            catch { }
                        }


                        // trả lại nhà cung cấp
                        for (int j = 0; j < tl.Length; j++)
                        {
                            if (tl[j].MaNCC == ncc[i].MaNhaCungCap)
                            {
                                double tongTienThanhToan = Convert.ToDouble(tl[j].TienBoiThuong);
                                double thanhToanNgay = Convert.ToDouble(tl[j].ThanhToanNgay);
                                if (thanhToanNgay > tongTienThanhToan)
                                    thanhToanNgay = tongTienThanhToan;

                                phatsinhno += tongTienThanhToan;
                                phatsinhco += thanhToanNgay;
                                string ngaylap = new Common.Utilities().XuLy(2, tl[j].Ngaytra.ToShortDateString());
                                Entities.CongNo cn = new Entities.CongNo(ngaylap, ncc[i].MaNhaCungCap, ncc[i].TenNhaCungCap, ncc[i].DiaChi,
                                    Format(double.Parse(tl[j].ThanhToanNgay)), Format(double.Parse(tl[j].TienBoiThuong)), tl[j].GhiChu, "KHTL");
                                hienthi.Add(cn);
                            }
                        }
                        // phiếu thanh toán của nhà cung cấp
                        for (int j = 0; j < phieuttncc.Length; j++)
                        {
                            if (phieuttncc[j].MaNCC == ncc[i].MaNhaCungCap)
                            {
                                double tienthanhtoan = 0;
                                for (int k = 0; k < chitietphieuttncc.Length; k++)
                                {
                                    if (phieuttncc[j].MaPhieuTTNCC == chitietphieuttncc[k].MaPhieuTTNCC)
                                    {
                                        phatsinhno += Convert.ToDouble(chitietphieuttncc[k].ThanhToan.ToString());
                                        tienthanhtoan += Convert.ToDouble(chitietphieuttncc[k].ThanhToan.ToString());
                                    }
                                }
                                string ngaylap = new Common.Utilities().XuLy(2, phieuttncc[j].NgayLap.ToShortDateString());
                                Entities.CongNo cn = new Entities.CongNo(ngaylap, ncc[i].MaNhaCungCap, ncc[i].TenNhaCungCap, ncc[i].DiaChi,
                                    "0", Format(tienthanhtoan), phieuttncc[j].GhiChu, "PhieuThu");
                                hienthi.Add(cn);
                            }
                        }
                        sdck = sddk + phatsinhco - phatsinhno;
                        Entities.SoDuCongNo sdcnNCC = new Entities.SoDuCongNo("UpdateTrangThai", maSoDuCongNo, ncc[i].MaNhaCungCap, ncc[i].TenNhaCungCap, ncc[i].DiaChi, sdck.ToString(), Convert.ToDateTime(cbbthang.Text + "/01/" + cbbnam.Text), true);
                        Entities.CongNo cnncc = new Entities.CongNo(ncc[i].MaNhaCungCap, ncc[i].TenNhaCungCap, ncc[i].DiaChi,
                            Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck));
                        mangchitiet.Add(sdcnNCC);
                        congnoncc.Add(cnncc);
                        soluongncc++;
                    }
                    sddk = phatsinhno = phatsinhco = 0;
                    // tính toán của mảng nhà cung cấp
                    int count = congnoncc.ToArray().Length;
                    Entities.CongNo cnNCC = new Entities.CongNo();
                    if (count == 1)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            sdck = sddk + phatsinhco - phatsinhno;
                            cnNCC = new Entities.CongNo("Tổng cộng", Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck), string.Empty);
                        }

                        congnoncc.Add(cnNCC);
                    }
                    else
                    {
                        for (int i = 0; i < count; i++)
                        {
                            phatsinhco += Convert.ToDouble(congnoncc[i].PhatSinhCo);
                            phatsinhno += Convert.ToDouble(congnoncc[i].PhatSinhNo);
                            sddk += double.Parse(congnoncc[i].DuDauKy);
                            sdck = sddk + phatsinhco - phatsinhno;
                            cnNCC = new Entities.CongNo("Tổng cộng", Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck), string.Empty);
                        }
                        congnoncc.Add(cnNCC);
                    }
                }
                if (cbbdoituong.SelectedIndex == 0)
                {
                    soluong = 0;
                    int sl = 0;
                    Entities.CongNo[] sdcn = new Entities.CongNo[congnokh.ToArray().Length];
                    for (int i = 0; i < congnokh.ToArray().Length - 1; i++)
                    {
                        double dauky = Convert.ToDouble(congnokh[i].DuDauKy);
                        double cuoiky = Convert.ToDouble(congnokh[i].DuCuoiKy);
                        double psco = Convert.ToDouble(congnokh[i].PhatSinhCo);
                        double psno = Convert.ToDouble(congnokh[i].PhatSinhNo);
                        if (dauky == 0 && cuoiky == 0 && psco == 0 && psno == 0)
                        {
                            soluong++;
                        }
                        else
                        {
                            sdcn[sl] = congnokh[i];
                            sl++;
                        }
                    }
                    Entities.CongNo[] sdcn1 = new Entities.CongNo[sl + 1];
                    for (int i = 0; i < sdcn1.Length; i++)
                    {
                        if (i < sdcn1.Length - 1)
                            sdcn1[i] = sdcn[i];
                        else
                            sdcn1[i] = congnokh[congnokh.ToArray().Length - 1];

                    }
                    dtgvcongno.DataSource = sdcn1;
                    fixKH();
                }
                else
                {
                    soluong = 0;
                    int sl = 0;
                    Entities.CongNo[] sdcn = new Entities.CongNo[congnoncc.ToArray().Length];
                    for (int i = 0; i < congnoncc.ToArray().Length - 1; i++)
                    {
                        double dauky = Convert.ToDouble(congnoncc[i].DuDauKy);
                        double cuoiky = Convert.ToDouble(congnoncc[i].DuCuoiKy);
                        double psco = Convert.ToDouble(congnoncc[i].PhatSinhCo);
                        double psno = Convert.ToDouble(congnoncc[i].PhatSinhNo);
                        if (dauky == 0 && cuoiky == 0 && psco == 0 && psno == 0)
                        {
                            soluong++;
                        }
                        else
                        {
                            sdcn[sl] = congnoncc[i];
                            sl++;
                        }
                    }
                    Entities.CongNo[] sdcn1 = new Entities.CongNo[sl + 1];
                    for (int i = 0; i < sdcn1.Length; i++)
                    {
                        Entities.TongHopCongNo cn = new Entities.TongHopCongNo();
                        if (i < sdcn1.Length - 1)
                        {
                            sdcn1[i] = sdcn[i];
                        }
                        else
                        {
                            sdcn1[i] = congnoncc[congnoncc.ToArray().Length - 1];
                        }

                    }

                    Entities.TongHopCongNo cn1;
                    congNoList = new List<Entities.TongHopCongNo>();
                    foreach (Entities.CongNo item in sdcn1)
                    {
                        cn1 = new Entities.TongHopCongNo();
                        cn1.MaDoiTuong = item.MaDoiTuong;
                        cn1.TenDoiTuong = item.TenDoiTuong;
                        cn1.DiaChi = item.DiaChi;
                        cn1.PhatSinhNo = double.Parse(item.PhatSinhNo);
                        cn1.PhatSinhCo = double.Parse(item.PhatSinhCo);
                        cn1.DuDauKy = double.Parse(item.DuDauKy);
                        cn1.DuCuoiKy = double.Parse(item.DuCuoiKy);
                        if (!string.IsNullOrEmpty(item.MaDoiTuong))
                            congNoList.Add(cn1);
                    }
                    dtgvcongno.DataSource = sdcn1;
                    fixNCC();
                }

                dtgvcongno.Rows[dtgvcongno.RowCount - 1].DefaultCellStyle.Font = new Font(dtgvcongno.DefaultCellStyle.Font, FontStyle.Bold);
            }
            catch
            {
            }
            finally
            {

            }
        }
        List<Entities.HDBanHang> bb1;
        List<Entities.PhieuThu> ptcKH;
        List<Entities.CongNo> congnochitietkh;
        List<Entities.KhachHangTraLai> khtl1;
        Entities.KhachHang kh1;
        List<Entities.PhieuTTCuaKH> phieuttcuakh1;
        List<Entities.ChiTietPhieuTTCuaKH> chitietphieuttcuakh1;
        List<Entities.CongNo> congnokh1;
        public void ChiTietTheoKhachHang(string maKhachHang)
        {
            try
            {
                congnokh1 = new List<Entities.CongNo>();
                int soluong = 0;
                int sotang = 0;
                phatsinhco = 0;
                phatsinhno = 0;
                sdck = sddk = 0;

                bb1 = new List<Entities.HDBanHang>();
                ptcKH = new List<Entities.PhieuThu>();
                khtl1 = new List<Entities.KhachHangTraLai>();
                phieuttcuakh1 = new List<Entities.PhieuTTCuaKH>();
                congnochitietkh = new List<Entities.CongNo>();
                // lấy thông tin của khách hàng
                string tenkh = "";
                string diachi = "";
                for (int j = 0; j < kh.Length; j++)
                {
                    if (kh[j].MaKH == maKhachHang)
                    {
                        kh1 = kh[j];
                        tenkh = kh[j].Ten;
                        diachi = kh[j].DiaChi;
                        break;
                    }
                }
                for (int j = 0; j < hienthi1.Length; j++)
                {
                    if (hienthi1[j].MaDoiTuong == maKhachHang)
                    {
                        sddk = Double.Parse(hienthi1[j].SoDuDauKy);
                        break;
                    }
                }
                // bán buôn
                soluong = 0;
                sotang = 0;
                for (int j = 0; j < bb.Length; j++)
                {
                    if (bb[j].MaKhachHang == maKhachHang)
                    {
                        Entities.CongNo cn = null;
                        string ngay = new Common.Utilities().XuLy(2, bb[j].NgayBan.ToShortDateString());
                        double tongTienThanhToan = double.Parse(bb[j].TongTienThanhToan);
                        double thanhToanNgay = double.Parse(bb[j].ThanhToanKhiLapPhieu);
                        if (thanhToanNgay > tongTienThanhToan)
                            cn = new Entities.CongNo(ngay, maKhachHang, tenkh, diachi, "0",
                          tongTienThanhToan.ToString(), tongTienThanhToan.ToString(), "0", bb[j].GhiChu, "BanBuon", "0", bb[j].MaHDBanHang);
                        else
                            cn = new Entities.CongNo(ngay, maKhachHang, tenkh, diachi, "0",
                          tongTienThanhToan.ToString(), thanhToanNgay.ToString(), "0", bb[j].GhiChu, "BanBuon", "0", bb[j].MaHDBanHang);
                        congnochitietkh.Add(cn);
                        bb1.Add(bb[j]);
                    }
                }

                // Phieu thu
                for (int j = 0; j < phieuThuChi.Length; j++)
                {
                    try
                    {
                        string month1 = phieuThuChi[j].NgayLap.Month.ToString();
                        string year1 = phieuThuChi[j].NgayLap.Year.ToString();

                        if (phieuThuChi[j].DoiTuong.Equals(maKhachHang) && phieuThuChi[j].LoaiPhieu.ToUpper().Equals("Thu".ToUpper()) && phieuThuChi[j].Deleted == false && month1 == month && year1 == year)
                        {
                            string ngaylap = new Common.Utilities().XuLy(2, phieuThuChi[j].NgayLap.ToShortDateString());
                            Entities.CongNo cn = new Entities.CongNo(ngaylap, maKhachHang, tenkh, diachi, "0",
                               "0", Format(double.Parse(phieuThuChi[j].TongTienThanhToan)), "0", phieuThuChi[j].GhiChu, "Thu", "0", phieuThuChi[j].MaPhieuThu);
                            congnochitietkh.Add(cn);
                            ptcKH.Add(phieuThuChi[j]);
                        }
                    }
                    catch (Exception)
                    { }
                }

                // Phieu chi
                for (int j = 0; j < phieuThuChi.Length; j++)
                {
                    try
                    {
                        string month1 = phieuThuChi[j].NgayLap.Month.ToString();
                        string year1 = phieuThuChi[j].NgayLap.Year.ToString();

                        if (phieuThuChi[j].DoiTuong.Equals(maKhachHang) && phieuThuChi[j].LoaiPhieu.ToUpper().Equals("Chi".ToUpper()) && phieuThuChi[j].Deleted == false && month1 == month && year1 == year)
                        {
                            string ngaylap = new Common.Utilities().XuLy(2, phieuThuChi[j].NgayLap.ToShortDateString());
                            Entities.CongNo cn = new Entities.CongNo(ngaylap, maKhachHang, tenkh, diachi, "0",
                               Format(double.Parse(phieuThuChi[j].TongTienThanhToan)), "0", "0", phieuThuChi[j].GhiChu, "Chi", "0", phieuThuChi[j].MaPhieuThu);
                            congnochitietkh.Add(cn);
                            ptcKH.Add(phieuThuChi[j]);
                        }
                    }
                    catch (Exception)
                    { }
                }

                // khách hàng trả lại
                sotang = 0;
                for (int j = 0; j < khtl.Length; j++)
                {
                    if (khtl[j].MaKhachHang == maKhachHang)
                    {
                        Entities.CongNo cn = null;
                        string ngay = new Common.Utilities().XuLy(2, khtl[j].NgayNhap.ToShortDateString());
                        double tongTienThanhToan = double.Parse(khtl[j].TienBoiThuong);
                        double thanhToanNgay = double.Parse(khtl[j].ThanhToanNgay);
                        if (thanhToanNgay > tongTienThanhToan)
                            cn = new Entities.CongNo(ngay, maKhachHang, tenkh, diachi, "0",
                           tongTienThanhToan.ToString(), tongTienThanhToan.ToString(), "0", khtl[j].GhiChu, "KHTL", "0", khtl[j].MaKhachHangTraLai);
                        else
                            cn = new Entities.CongNo(ngay, maKhachHang, tenkh, diachi, "0",
                            thanhToanNgay.ToString(), tongTienThanhToan.ToString(), "0", khtl[j].GhiChu, "KHTL", "0", khtl[j].MaKhachHangTraLai);
                        congnochitietkh.Add(cn);
                        khtl1.Add(khtl[j]);
                    }
                }
                // phiếu thanh toán của khách hàng
                sotang = 0;
                for (int j = 0; j < phieuttcuakh.Length; j++)
                {
                    if (phieuttcuakh[j].MaKhachHang == maKhachHang)
                    {
                        double tienthanhtoan = 0;
                        for (int k = 0; k < chitietphieuttcuakh.Length; k++)
                        {
                            if (phieuttcuakh[j].MaPhieuTTCuaKH == chitietphieuttcuakh[k].MaPhieuTTCuaKH)
                            {
                                tienthanhtoan += Convert.ToDouble(chitietphieuttcuakh[k].ThanhToan.ToString());
                            }
                        }
                        string ngay = new Common.Utilities().XuLy(2, phieuttcuakh[j].NgayLap.ToShortDateString());
                        Entities.CongNo cn = new Entities.CongNo(ngay, maKhachHang, tenkh, diachi, "0", "0",
                            Format(tienthanhtoan), "0", phieuttcuakh[j].GhiChu, "PhieuTTCuaKH", "0", phieuttcuakh[j].MaPhieuTTCuaKH);
                        congnochitietkh.Add(cn);
                        phieuttcuakh1.Add(phieuttcuakh[j]);
                    }
                }
                phatsinhno = phatsinhco = 0;
                // tính toán của mảng khách hàng
                Entities.CongNo cnTong = new Entities.CongNo();
                for (int j = 0; j < congnochitietkh.ToArray().Length; j++)
                {
                    phatsinhco += Convert.ToDouble(congnochitietkh[j].PhatSinhCo);
                    phatsinhno += Convert.ToDouble(congnochitietkh[j].PhatSinhNo);
                    sdck = sddk + phatsinhno - phatsinhco;
                    cnTong = new Entities.CongNo("Tổng cộng", Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck), string.Empty);
                }

                congnochitietkh.Add(cnTong);

            }
            catch
            {
            }
        }


        List<Entities.HoaDonNhap> hdn2;
        List<Entities.TraLaiNCC> tlncc2;
        List<Entities.CongNo> congnoncc2;
        List<Entities.CongNo> congnochitietncc2;
        List<Entities.PhieuTTNCC> phieuttncc2;
        List<Entities.ChiTietPhieuTTNCC> chitietphieuttncc2;
        List<Entities.PhieuThu> ptcNCC;
        Entities.NhaCungCap ncc2;
        public void ChiTietNhaCungCap(string maNhaCungCap)
        {
            try
            {
                congnoncc2 = new List<Entities.CongNo>();
                int soluong = 0;
                int sotang = 0;
                phatsinhco = 0;
                phatsinhno = 0;
                sdck = sddk = 0;
                phatsinhco = 0;
                phatsinhno = 0;

                hdn2 = new List<Entities.HoaDonNhap>();
                tlncc2 = new List<Entities.TraLaiNCC>();
                phieuttncc2 = new List<Entities.PhieuTTNCC>();
                congnochitietncc2 = new List<Entities.CongNo>();
                ptcNCC = new List<Entities.PhieuThu>();

                // lấy thông tin của Nhà cung cấp
                string tenncc = "";
                string diachi = "";
                for (int j = 0; j < ncc.Length; j++)
                {
                    if (ncc[j].MaNhaCungCap == maNhaCungCap)
                    {
                        ncc2 = ncc[j];
                        tenncc = ncc[j].TenNhaCungCap;
                        diachi = ncc[j].DiaChi;
                        break;
                    }
                }
                for (int j = 0; j < hienthi1.Length; j++)
                {
                    if (hienthi1[j].MaDoiTuong == maNhaCungCap)
                    {
                        sddk = Double.Parse(hienthi1[j].SoDuDauKy);
                        break;
                    }
                }
                // Hóa đơn nhập
                for (int j = 0; j < hdn.Length; j++)
                {
                    if (hdn[j].MaNhaCungCap == maNhaCungCap)
                    {
                        double a = Convert.ToDouble(hdn[j].TongTien);
                        double b = Convert.ToDouble(hdn[j].ThanhToanNgay);
                        if (b > a)
                        {
                            b = a;
                        }
                        string ngay = new Common.Utilities().XuLy(2, hdn[j].NgayNhap.ToShortDateString());
                        Entities.CongNo cn = new Entities.CongNo(ngay, maNhaCungCap, tenncc, diachi, "0",
                           Format(b), Format(a), "0", hdn[j].GhiChu, "HoaDonNhap", "0", hdn[j].MaHoaDonNhap);
                        congnochitietncc2.Add(cn);
                        hdn2.Add(hdn[j]);
                    }
                }


                // Phieu thu
                for (int j = 0; j < phieuThuChi.Length; j++)
                {
                    try
                    {
                        string month1 = phieuThuChi[j].NgayLap.Month.ToString();
                        string year1 = phieuThuChi[j].NgayLap.Year.ToString();

                        if (phieuThuChi[j].DoiTuong.Equals(maNhaCungCap) && phieuThuChi[j].LoaiPhieu.ToUpper().Equals("Thu".ToUpper()) && phieuThuChi[j].Deleted == false && month1 == month && year1 == year)
                        {
                            string ngaylap = new Common.Utilities().XuLy(2, phieuThuChi[j].NgayLap.ToShortDateString());
                            Entities.CongNo cn = new Entities.CongNo(ngaylap, maNhaCungCap, tenncc, diachi, "0",
                               "0", Format(double.Parse(phieuThuChi[j].TongTienThanhToan)), "0", phieuThuChi[j].GhiChu, "Thu", "0", phieuThuChi[j].MaPhieuThu);
                            congnochitietncc2.Add(cn);
                            ptcNCC.Add(phieuThuChi[j]);
                        }
                    }
                    catch (Exception)
                    { }
                }

                // Phieu chi
                for (int j = 0; j < phieuThuChi.Length; j++)
                {
                    try
                    {
                        string month1 = phieuThuChi[j].NgayLap.Month.ToString();
                        string year1 = phieuThuChi[j].NgayLap.Year.ToString();

                        if (phieuThuChi[j].DoiTuong.Equals(maNhaCungCap) && phieuThuChi[j].LoaiPhieu.ToUpper().Equals("Chi".ToUpper()) && phieuThuChi[j].Deleted == false && month1 == month && year1 == year)
                        {
                            string ngaylap = new Common.Utilities().XuLy(2, phieuThuChi[j].NgayLap.ToShortDateString());
                            Entities.CongNo cn = new Entities.CongNo(ngaylap, maNhaCungCap, tenncc, diachi, "0",
                               Format(double.Parse(phieuThuChi[j].TongTienThanhToan)), "0", "0", phieuThuChi[j].GhiChu, "Chi", "0", phieuThuChi[j].MaPhieuThu);
                            congnochitietncc2.Add(cn);
                            ptcNCC.Add(phieuThuChi[j]);
                        }
                    }
                    catch (Exception)
                    { }
                }


                // trả lại nhà cung cấp
                sotang = 0;
                for (int j = 0; j < tl.Length; j++)
                {
                    if (tl[j].MaNCC == maNhaCungCap)
                    {
                        Entities.CongNo cn = null;
                        string ngay = new Common.Utilities().XuLy(2, tl[j].Ngaytra.ToShortDateString());
                        double tongTienThanhToan = double.Parse(tl[j].TienBoiThuong);
                        double thanhToanNgay = double.Parse(tl[j].ThanhToanNgay);
                        if (thanhToanNgay > tongTienThanhToan)
                            cn = new Entities.CongNo(ngay, maNhaCungCap, tenncc, diachi, "0",
                            tongTienThanhToan.ToString(), tongTienThanhToan.ToString(), "0", tl[j].GhiChu, "TLNCC", "0", tl[j].MaHDTraLaiNCC);
                        else
                            cn = new Entities.CongNo(ngay, maNhaCungCap, tenncc, diachi, "0",
                               tongTienThanhToan.ToString(), thanhToanNgay.ToString(), "0", tl[j].GhiChu, "TLNCC", "0", tl[j].MaHDTraLaiNCC);
                        congnochitietncc2.Add(cn);
                        tlncc2.Add(tl[j]);
                    }
                }
                // phiếu thanh toán nhà cung cấp
                for (int j = 0; j < phieuttncc.Length; j++)
                {
                    if (phieuttncc[j].MaNCC == maNhaCungCap)
                    {
                        double tienthanhtoan = 0;
                        for (int k = 0; k < chitietphieuttncc.Length; k++)
                        {
                            if (phieuttncc[j].MaPhieuTTNCC == chitietphieuttncc[k].MaPhieuTTNCC)
                            {
                                tienthanhtoan += Convert.ToDouble(chitietphieuttncc[k].ThanhToan.ToString());
                            }
                        }
                        string ngay = new Common.Utilities().XuLy(2, phieuttncc[j].NgayLap.ToShortDateString());
                        Entities.CongNo cn = new Entities.CongNo(ngay, maNhaCungCap, tenncc, diachi, "0",
                             Format(tienthanhtoan), "0", "0", phieuttncc[j].GhiChu, "PhieuTTNCC", "0", phieuttncc[j].MaPhieuTTNCC);
                        congnochitietncc2.Add(cn);
                        phieuttncc2.Add(phieuttncc[j]);
                    }
                }
                phatsinhno = phatsinhco = 0;
                // tính toán của mảng nhà cung cấp
                Entities.CongNo tongCnNCC = new Entities.CongNo();
                for (int j = 0; j < congnochitietncc2.ToArray().Length; j++)
                {
                    phatsinhco += Convert.ToDouble(congnochitietncc2[j].PhatSinhCo);
                    phatsinhno += Convert.ToDouble(congnochitietncc2[j].PhatSinhNo);
                    sdck = sddk + phatsinhco - phatsinhno;
                    tongCnNCC = new Entities.CongNo("Tổng cộng", Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck), string.Empty);
                }
                congnochitietncc2.Add(tongCnNCC);
            }
            catch
            {
            }
        }

        /// <summary>
        /// định dạng dữ liệu
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public string Format(double a)
        {
            if (a >= 0 && a < 10)
                return a.ToString();
            string str = "";
            try
            {
                if (a < 0)
                    str = String.Format("{0,-0:0,0}", a);
                else
                    str = String.Format("{0:0,0}", a);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                str = "";
            }
            return str;
        }
        int i = 0;

        private void tsslbltrove_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
                else
                { }
            }
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
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

        private void cbbthang_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                month = cbbthang.Text;
                year = cbbnam.Text;
                if (cbbdoituong.Text != "" && year != "" && month != "")
                    HienThiTong();
            }
            catch
            {
            }
            this.Enabled = true;
        }

        private void cbbnam_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                month = cbbthang.Text;
                year = cbbnam.Text;
                if (cbbdoituong.Text != "" && year != "" && month != "")
                    HienThiTong();
            }
            catch
            {
            }
            this.Enabled = true;
        }

        private void cbbdoituong_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                month = cbbthang.Text;
                year = cbbnam.Text;
                if (cbbdoituong.Text != "" && year != "" && month != "")
                    HienThiTong();
            }
            catch
            {
            }
            this.Enabled = true;
        }

        private void dtgvcongno_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                if (i < congnokh.ToArray().Length - 1)
                {
                    if (cbbdoituong.SelectedIndex == 0)
                    {
                        ChiTietTheoKhachHang(dtgvcongno["MaDoiTuong", i].Value.ToString());
                        double duDauKy = double.Parse(congnochitietkh[congnochitietkh.ToArray().Length - 1].DuDauKy);
                        double psNo = double.Parse(congnochitietkh[congnochitietkh.ToArray().Length - 1].PhatSinhNo);
                        double psCo = double.Parse(congnochitietkh[congnochitietkh.ToArray().Length - 1].PhatSinhCo);
                        double duCuoiKy = duDauKy + psNo - psCo;
                        frmChiTietCongNo a = new frmChiTietCongNo(congnochitietkh.ToArray(), bb1.ToArray(), ptcKH.ToArray(), khtl1.ToArray(), kh1, phieuttcuakh.ToArray(), duDauKy.ToString(), duCuoiKy.ToString());
                        a.ShowDialog();
                    }
                }
                if (i < congnoncc.ToArray().Length - 1)
                {
                    if (cbbdoituong.SelectedIndex == 1)
                    {
                        ChiTietNhaCungCap(dtgvcongno["MaDoiTuong", i].Value.ToString());
                        double duDauKy = double.Parse(congnochitietncc2[congnochitietncc2.ToArray().Length - 1].DuDauKy);
                        double psNo = double.Parse(congnochitietncc2[congnochitietncc2.ToArray().Length - 1].PhatSinhNo);
                        double psCo = double.Parse(congnochitietncc2[congnochitietncc2.ToArray().Length - 1].PhatSinhCo);
                        double duCuoiKy = duDauKy + psCo - psNo;
                        frmChiTietCongNo a = new frmChiTietCongNo(congnochitietncc2.ToArray(), ptcNCC.ToArray(), hdn2.ToArray(), tlncc2.ToArray(), ncc2, phieuttncc.ToArray(), duDauKy.ToString(), duCuoiKy.ToString());
                        a.ShowDialog();
                    }
                }
            }
            catch
            {

            }
        }

        private void frmCongNo_Load(object sender, EventArgs e)
        {
            //dtgvcongno.Rows[dtgvcongno.RowCount - 1].DefaultCellStyle.Font = new Font(dtgvcongno.DefaultCellStyle.Font, FontStyle.Bold);

        }

        private void dtgvcongno_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void tsslnap_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                month = cbbthang.Text;
                year = cbbnam.Text;
                if (cbbdoituong.Text != "" && year != "" && month != "")
                    HienThiTong();
            }
            catch
            {
            }
            this.Enabled = true;

        }

        private void tsslbldieukien_Click(object sender, EventArgs e)
        {

        }

        private void tsslblchitiet_Click(object sender, EventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                if (i < congnokh.ToArray().Length - 1)
                {
                    if (cbbdoituong.SelectedIndex == 0)
                    {
                        ChiTietTheoKhachHang(dtgvcongno["MaDoiTuong", i].Value.ToString());
                        double duDauKy = double.Parse(congnochitietkh[congnochitietkh.ToArray().Length - 1].DuDauKy);
                        double psNo = double.Parse(congnochitietkh[congnochitietkh.ToArray().Length - 1].PhatSinhNo);
                        double psCo = double.Parse(congnochitietkh[congnochitietkh.ToArray().Length - 1].PhatSinhCo);
                        double duCuoiKy = duDauKy + psNo - psCo;
                        frmChiTietCongNo a = new frmChiTietCongNo(congnochitietkh.ToArray(), bb1.ToArray(), ptcKH.ToArray(), khtl1.ToArray(), kh1, phieuttcuakh.ToArray(), duDauKy.ToString(), duCuoiKy.ToString());
                        a.ShowDialog();
                    }
                }
                if (i < congnoncc.ToArray().Length - 1)
                {
                    if (cbbdoituong.SelectedIndex == 1)
                    {
                        ChiTietNhaCungCap(dtgvcongno["MaDoiTuong", i].Value.ToString());
                        double duDauKy = double.Parse(congnochitietncc2[congnochitietncc2.ToArray().Length - 1].DuDauKy);
                        double psNo = double.Parse(congnochitietncc2[congnochitietncc2.ToArray().Length - 1].PhatSinhNo);
                        double psCo = double.Parse(congnochitietncc2[congnochitietncc2.ToArray().Length - 1].PhatSinhCo);
                        double duCuoiKy = duDauKy + psCo - psNo;
                        frmChiTietCongNo a = new frmChiTietCongNo(congnochitietncc2.ToArray(), ptcNCC.ToArray(), hdn2.ToArray(), tlncc2.ToArray(), ncc2, phieuttncc.ToArray(), duDauKy.ToString(), duCuoiKy.ToString());
                        a.ShowDialog();
                    }
                }
            }
            catch
            {

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

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.TongHopCongNo[] congNo = congNoList.ToArray();
                string thang = cbbthang.SelectedItem.ToString();
                string nam = cbbnam.SelectedItem.ToString();
                // Khach hang
                if (cbbdoituong.SelectedIndex == 0)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(congNo, thang, nam, "In", "", "KH", "Khách Hàng");
                    a.ShowDialog();
                }
                else
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(congNo, thang, nam, "In", "", "NCC", "Nhà Cung Cấp");
                    a.ShowDialog();
                }
            }
            catch (Exception)
            {
            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                Entities.TongHopCongNo[] congNo = congNoList.ToArray();
                string thang = cbbthang.SelectedItem.ToString();
                string nam = cbbnam.SelectedItem.ToString();
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Khach hang
                    if (cbbdoituong.SelectedIndex == 0)
                    {
                        frmBaoCaorpt a = new frmBaoCaorpt(congNo, thang, nam, "Excel", saveFileDialog1.FileName, "KH", "Khách Hàng");
                    }
                    else
                    {
                        frmBaoCaorpt a = new frmBaoCaorpt(congNo, thang, nam, "Excel", saveFileDialog1.FileName, "NCC", "Nhà Cung Cấp");
                    }
                }
            }
            catch
            {
            }
            finally { this.Enabled = true; }
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                Entities.TongHopCongNo[] congNo = congNoList.ToArray();
                string thang = cbbthang.SelectedItem.ToString();
                string nam = cbbnam.SelectedItem.ToString();
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Khach hang
                    if (cbbdoituong.SelectedIndex == 0)
                    {
                        frmBaoCaorpt a = new frmBaoCaorpt(congNo, thang, nam, "Word", saveFileDialog1.FileName, "KH", "Khách Hàng");
                    }
                    else
                    {
                        frmBaoCaorpt a = new frmBaoCaorpt(congNo, thang, nam, "Word", saveFileDialog1.FileName, "NCC", "Nhà Cung Cấp");
                    }
                }
            }
            catch
            {
            }
            finally { this.Enabled = true; }

        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                Entities.TongHopCongNo[] congNo = congNoList.ToArray();
                string thang = cbbthang.SelectedItem.ToString();
                string nam = cbbnam.SelectedItem.ToString();
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Khach hang
                    if (cbbdoituong.SelectedIndex == 0)
                    {
                        frmBaoCaorpt a = new frmBaoCaorpt(congNo, thang, nam, "PDF", saveFileDialog1.FileName, "KH", "Khách Hàng");
                    }
                    else
                    {
                        frmBaoCaorpt a = new frmBaoCaorpt(congNo, thang, nam, "PDF", saveFileDialog1.FileName, "NCC", "Nhà Cung Cấp");
                    }
                }
            }
            catch
            {
            }
            finally { this.Enabled = true; }
        }
    }
}
