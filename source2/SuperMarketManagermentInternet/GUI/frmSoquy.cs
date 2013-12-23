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
using System.Collections;

namespace GUI
{
    public partial class frmSoquy : Form
    {
        DateTime datesv;
        public string month;
        public string year;
        public TcpClient client1;
        public NetworkStream clientstrem;
        public static string a = "0";
        bool batdau = false;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        public frmSoquy()
        {
            InitializeComponent();
            try
            {
                datesv = DateServer.Date();
                batdau = true;
                cbbnam.Text = datesv.Year.ToString();
                cbbthang.Text = datesv.Month.ToString();
                month = cbbthang.Text;
                year = cbbnam.Text;
            }
            catch { }
            SelectSoQuy();
            HienThiTongThe();
        }
        public frmSoquy(string nam, string thang)
        {
            InitializeComponent();
            try
            {
                datesv = DateServer.Date();
                batdau = true;
                cbbnam.Text = datesv.Year.ToString();
                cbbthang.Text = datesv.Month.ToString();
                month = thang;
                year = nam;
            }
            catch { }
            SelectSoQuy();
            HienThiTongThe();
        }
        Server_Client.Client cl;
        Entities.PhieuThu[] thuchi;
        Entities.PhieuThu[] pt;
        Entities.PhieuThu[] pc;
        Entities.HDBanHang[] buonle;
        Entities.HDBanHang[] bb;
        Entities.HDBanHang[] bl;
        Entities.HoaDonNhap[] hdn;
        Entities.TraLaiNCC[] tl;
        Entities.KhachHangTraLai[] kh;
        Entities.SoQuy[] hienthi;
        Entities.SoQuy[] soquy;
        Entities.SoDuSoQuy[] sodu;
        Entities.PhieuTTCuaKH[] pttkh;
        Entities.PhieuTTNCC[] pttncc;
        Entities.ChiTietPhieuTTCuaKH[] ctpttkh;
        Entities.ChiTietPhieuTTNCC[] ctpttncc;
        int sl = 0;
        Entities.SelectAll selectall;
        void SelectSoQuy()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("SoQuy");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                selectall = (Entities.SelectAll)cl.DeserializeHepper(clientstrem, selectall);
                // gói hàng
                sodu = selectall.SoDuSoQuy;

                // chi tiết gói hàng
                thuchi = selectall.PhieuThu;
                if (thuchi == null)
                    thuchi = pt = pc = new Entities.PhieuThu[0];
                SelectPhieuThuChi();    //Chọn phiếu thu chi
                SelectPhieuThanhToan(); //Chọn phiếu thanh toán
                buonle = selectall.HDBanHang;
                if (buonle == null)
                {
                    buonle = bb = bl = new Entities.HDBanHang[0];
                    return;
                }
                SelectBanBuonLe();  //Hóa đơn bán buôn bán lẻ
                hdn = selectall.HoaDonNhap; //Hóa đơn nhập
                kh = selectall.KhachHangTraLai; //Khách hàng trả lại
                tl = selectall.TraLaiNCC;   //Trả lại NCC
                SelectNhapKho();
                SelectKHTL();
                SelectTLNCC();
            }
            catch { MessageBox.Show("Có lỗi xảy ra, có thể do đường truyền mạng, xin vui lòng thử lại!"); }
        }

        public void SelectPhieuTTCuaKH()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.PhieuTTCuaKH pttckh = new Entities.PhieuTTCuaKH();
                // truyền HanhDong
                pttckh = new Entities.PhieuTTCuaKH("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.PhieuTTCuaKH[] pttckh1 = new Entities.PhieuTTCuaKH[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuTTCuaKH", pttckh);
                // đổ mảng đối tượng vào datagripview       
                pttckh1 = (Entities.PhieuTTCuaKH[])cl.DeserializeHepper1(clientstrem, pttckh1);
                if (pttckh1 == null)
                {
                    pttckh1 = new Entities.PhieuTTCuaKH[0];
                    pttkh = new Entities.PhieuTTCuaKH[0];
                    return;
                }

                Entities.PhieuTTCuaKH[] pttkhTEM = new Entities.PhieuTTCuaKH[pttckh1.Length];
                int sotang = 0;
                for (int j = 0; j < pttckh1.Length; j++)
                {
                    if (pttckh1[j].Deleted == false)
                    {
                        pttkhTEM[sotang] = pttckh1[j];
                        sotang++;
                    }
                }

                pttkh = new Entities.PhieuTTCuaKH[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        pttkh[j] = pttkhTEM[j];
                    }
                }
                else
                    pttkh = new Entities.PhieuTTCuaKH[0];
            }
            catch (Exception ex)
            {
                pttkh = new Entities.PhieuTTCuaKH[0];
            }
        }

        public void SelectPhieuTTNCC()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.PhieuTTNCC pttcncc = new Entities.PhieuTTNCC();
                // truyền HanhDong
                pttcncc = new Entities.PhieuTTNCC("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.PhieuTTNCC[] pttncc1 = new Entities.PhieuTTNCC[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuTTNCC", pttcncc);
                // đổ mảng đối tượng vào datagripview       
                pttncc1 = (Entities.PhieuTTNCC[])cl.DeserializeHepper1(clientstrem, pttncc1);
                if (pttncc1 == null)
                {
                    pttncc1 = new Entities.PhieuTTNCC[0];
                    pttncc = new Entities.PhieuTTNCC[0];
                    return;
                }

                Entities.PhieuTTNCC[] pttncc2 = new Entities.PhieuTTNCC[pttncc1.Length];
                int sotang = 0;
                for (int j = 0; j < pttncc1.Length; j++)
                {
                    if (pttncc1[j].Deleted == false)
                    {
                        pttncc2[sotang] = pttncc1[j];
                        sotang++;
                    }
                }

                pttncc = new Entities.PhieuTTNCC[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        pttncc[j] = pttncc2[j];
                    }
                }
                else
                    pttncc = new Entities.PhieuTTNCC[0];
            }
            catch (Exception ex)
            {
                pttncc = new Entities.PhieuTTNCC[0];
            }
        }

        void SelectChiTietPhieuTTCuaKH()
        {
            try
            {
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ChiTietPhieuTTCuaKH pt = new Entities.ChiTietPhieuTTCuaKH("SelectAll");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.ChiTietPhieuTTCuaKH[] pt1 = new Entities.ChiTietPhieuTTCuaKH[1];
                clientstrem = cl.SerializeObj(this.client1, "ChiTietPhieuTTCuaKH", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.ChiTietPhieuTTCuaKH[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 == null)
                {
                    ctpttkh = new Entities.ChiTietPhieuTTCuaKH[0];
                    return;
                }
                ctpttkh = new Entities.ChiTietPhieuTTCuaKH[pt1.Length];
                for (int i = 0; i < pt1.Length; i++)
                {
                    ctpttkh[i] = pt1[i];
                }
            }
            catch { ctpttkh = new Entities.ChiTietPhieuTTCuaKH[0]; }
        }
        void SelectChiTietPhieuTTNCC()
        {
            try
            {
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ChiTietPhieuTTNCC pt = new Entities.ChiTietPhieuTTNCC("SelectAll");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.ChiTietPhieuTTNCC[] pt1 = new Entities.ChiTietPhieuTTNCC[1];
                clientstrem = cl.SerializeObj(this.client1, "ChiTietPhieuTTNCC", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.ChiTietPhieuTTNCC[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 == null)
                {
                    ctpttncc = new Entities.ChiTietPhieuTTNCC[0];
                    return;
                }
                ctpttncc = new Entities.ChiTietPhieuTTNCC[pt1.Length];
                for (int i = 0; i < pt1.Length; i++)
                {
                    ctpttncc[i] = pt1[i];
                }
            }
            catch { ctpttncc = new Entities.ChiTietPhieuTTNCC[0]; }
        }
        

        public void SelectPhieuThanhToan()
        {
            try
            {
                SelectPhieuTTCuaKH();
                SelectPhieuTTNCC();
                SelectChiTietPhieuTTCuaKH();
                SelectChiTietPhieuTTNCC();
            }
            catch
            {
            }
            finally
            {

            }
        }

        /// <summary>
        /// select thu chi
        /// </summary>
        public void SelectPhieuThuChi()
        {
            try
            {
                SelectPhieuChi();
                SelectPhieuThu();
            }
            catch
            {
            }
            finally
            {

            }
        }
        /// <summary>
        /// select phiếu thu
        /// </summary>
        public void SelectPhieuThu()
        {
            try
            {
                Entities.PhieuThu[] pt2 = new Entities.PhieuThu[thuchi.Length];
                int sotang = 0;
                for (int j = 0; j < thuchi.Length; j++)
                {
                    string month1 = thuchi[j].NgayLap.Month.ToString();
                    string year1 = thuchi[j].NgayLap.Year.ToString();
                    if (thuchi[j].Deleted == false && thuchi[j].LoaiPhieu == "Thu") // && thuchi[j].NoTaiKhoan == "1111"
                    {
                        if (month == month1 && year == year1)
                        {
                            sl++;
                            pt2[sotang] = thuchi[j];
                            sotang++;
                        }
                    }
                }

                pt = new Entities.PhieuThu[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        pt[j] = pt2[j];
                    }
                }
                else
                    pt = new Entities.PhieuThu[0];
            }
            catch
            {
            }

        }
        /// <summary>
        /// select phiếu chi
        /// </summary>
        public void SelectPhieuChi()
        {
            try
            {
                Entities.PhieuThu[] pt2 = new Entities.PhieuThu[thuchi.Length];
                int sotang = 0;
                for (int j = 0; j < thuchi.Length; j++)
                {
                    string month1 = thuchi[j].NgayLap.Month.ToString();
                    string year1 = thuchi[j].NgayLap.Year.ToString();
                    if (thuchi[j].Deleted == false && thuchi[j].LoaiPhieu == "Chi") // && thuchi[j].CoTaiKhoan == "1111"
                    {
                        if (month == month1 && year1 == year)
                        {
                            sl++;
                            pt2[sotang] = thuchi[j];
                            sotang++;
                        }
                    }
                }

                pc = new Entities.PhieuThu[sotang];
                if (sotang != 0)
                {

                    for (int j = 0; j < sotang; j++)
                    {
                        pc[j] = pt2[j];
                    }
                }
                else
                    pc = new Entities.PhieuThu[0];
            }
            catch
            {
            }
        }
        /// <summary>
        /// select bán buôn - bán lẻ
        /// </summary>
        public void SelectBanBuonLe()
        {
            try
            {
                SelectBanLe();
                SelectBanBuon();
            }
            catch { }
        }
        /// <summary>
        /// selec bán lẻ
        /// </summary>
        public void SelectBanLe()
        {
            try
            {
                Entities.HDBanHang[] pt2 = new Entities.HDBanHang[buonle.Length];
                int sotang = 0;
                for (int j = 0; j < buonle.Length; j++)
                {
                    string month1 = buonle[j].NgayBan.Month.ToString();
                    string year1 = buonle[j].NgayBan.Year.ToString();
                    if (buonle[j].LoaiHoaDon == true && buonle[j].Deleted == false)
                    {
                        if (month == month1 && year == year1)
                        {
                            sl++;
                            pt2[sotang] = buonle[j];
                            sotang++;
                        }
                    }
                }
                bl = new Entities.HDBanHang[sotang];
                if (sotang != 0)
                {

                    for (int j = 0; j < sotang; j++)
                    {
                        bl[j] = pt2[j];
                    }
                }
                else
                    bl = new Entities.HDBanHang[0];
            }
            catch { }
        }
        /// <summary>
        /// select bán buôn
        /// </summary>
        public void SelectBanBuon()
        {
            try
            {
                Entities.HDBanHang[] pt2 = new Entities.HDBanHang[buonle.Length];
                int sotang = 0;
                for (int j = 0; j < buonle.Length; j++)
                {
                    string month1 = buonle[j].NgayBan.Month.ToString();
                    string year1 = buonle[j].NgayBan.Year.ToString();
                    if (buonle[j].LoaiHoaDon == false && buonle[j].Deleted == false)
                    {
                        if (month == month1 && year == year1 && Convert.ToDouble(buonle[j].ThanhToanKhiLapPhieu) != 0)
                        {
                            sl++;
                            pt2[sotang] = buonle[j];
                            sotang++;
                        }
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
        /// select nhập kho
        /// </summary>
        private void SelectNhapKho()
        {
            try
            {
                Entities.HoaDonNhap[] pt2 = new Entities.HoaDonNhap[hdn.Length];
                int sotang = 0;
                for (int j = 0; j < hdn.Length; j++)
                {
                    string month1 = hdn[j].NgayNhap.Month.ToString();
                    string year1 = hdn[j].NgayNhap.Year.ToString();
                    if (hdn[j].Deleted == false && month1 == month && year == year1 && Convert.ToDouble(hdn[j].ThanhToanNgay) != 0)
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
                Entities.KhachHangTraLai[] pt2 = new Entities.KhachHangTraLai[kh.Length];
                int sotang = 0;
                for (int j = 0; j < kh.Length; j++)
                {
                    string month1 = kh[j].NgayNhap.Month.ToString();
                    string year1 = kh[j].NgayNhap.Year.ToString();
                    if (kh[j].Deleted == false)
                    {
                        if (month == month1 && year1 == year && Convert.ToDouble(kh[j].ThanhToanNgay) != 0)
                        {
                            sl++;
                            pt2[sotang] = kh[j];
                            sotang++;
                        }
                    }
                }
                kh = new Entities.KhachHangTraLai[sotang];
                if (sotang != 0)
                {

                    for (int j = 0; j < sotang; j++)
                    {
                        kh[j] = pt2[j];
                    }
                }
                else
                    kh = new Entities.KhachHangTraLai[0];
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
                Entities.TraLaiNCC[] pt2 = new Entities.TraLaiNCC[tl.Length];
                int sotang = 0;
                for (int j = 0; j < tl.Length; j++)
                {
                    string month1 = tl[j].Ngaytra.Month.ToString();
                    string year1 = tl[j].Ngaytra.Year.ToString();
                    if (month == month1 & year == year1 && Convert.ToDouble(tl[j].ThanhToanNgay) != 0)
                    {
                        sl++;
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
        /// <summary>
        /// fix dtgv
        /// </summary>
        public void fix()
        {
            for (int i = 0; i < dtgvsoquy.ColumnCount; i++)
            {
                dtgvsoquy.Columns[i].Visible = false;
            }
            new Common.Utilities().CountDatagridview(dtgvsoquy);
            dtgvsoquy.ReadOnly = true;
            dtgvsoquy.Columns["HanhDong"].Visible = true;
            dtgvsoquy.Columns["MaTK"].Visible = true;
            dtgvsoquy.Columns["TenTK"].Visible = true;
            dtgvsoquy.Columns["DuDauKy"].Visible = true;
            dtgvsoquy.Columns["PhatSinhNo"].Visible = true;
            dtgvsoquy.Columns["PhatSinhCo"].Visible = true;
            dtgvsoquy.Columns["DuCuoiKy"].Visible = true;
            dtgvsoquy.Columns["HanhDong"].HeaderText = "STT";
            dtgvsoquy.Columns["MaTK"].HeaderText = "Mã tài khoản";
            dtgvsoquy.Columns["TenTK"].HeaderText = "Tên tài khoản";
            dtgvsoquy.Columns["DuDauKy"].HeaderText = "Dư đầu kỳ";
            dtgvsoquy.Columns["PhatSinhNo"].HeaderText = "Phát sinh nợ";
            dtgvsoquy.Columns["PhatSinhCo"].HeaderText = "Phát sinh có";
            dtgvsoquy.Columns["DuCuoiKy"].HeaderText = "Dư cuối kỳ";
            dtgvsoquy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvsoquy.AllowUserToAddRows = false;
            dtgvsoquy.AllowUserToDeleteRows = false;
            dtgvsoquy.AllowUserToResizeRows = false;
            dtgvsoquy.RowHeadersVisible = false;
            this.Focus(); this.WindowState = FormWindowState.Maximized;
        }

        double phatsinhno = 0;
        double phatsinhco = 0;
        double sdck = 0;
        double sddk = 0;
        bool kt = false;
        /// <summary>
        /// xử lý hiển thị
        /// </summary>
        public void HienThiTongThe()
        {
            try
            {
                phatsinhno = phatsinhco = sdck = sddk = 0;
                try
                {
                    hienthi = new Entities.SoQuy[pt.Length + pc.Length + bl.Length + bb.Length + hdn.Length + kh.Length + tl.Length + pttkh.Length + pttncc.Length + 1];
                }
                catch { }
                if (kt == false)
                {
                    for (int i = 0; i < sodu.Length; i++)
                    {
                        string monthsodu = sodu[i].NgayKetChuyen.Month.ToString();
                        string yearsodu = sodu[i].NgayKetChuyen.Year.ToString();
                        if (month == monthsodu && year == yearsodu)
                        {
                            sddk = Convert.ToDouble(sodu[i].SoDuDauKy);
                            break;
                        }
                    }
                }
                int soluong = 0;

                // Phiếu Thu
                for (int i = 0; i < pt.Length; i++)
                {
                    string month1 = pt[i].NgayLap.Month.ToString();
                    string year1 = pt[i].NgayLap.Year.ToString();
                    if (month == month1 && year == year1)
                    {
                        phatsinhno = Convert.ToDouble(pt[i].TongTienThanhToan);
                        string ngaylap = new Common.Utilities().XuLy(2, pt[i].NgayLap.ToShortDateString());
                        hienthi[soluong] = new Entities.SoQuy(ngaylap, pt[i].MaPhieuThu, "1111", "Tiền mặt việt nam",
                            Format(phatsinhno), Format(phatsinhco), pt[i].GhiChu, "PhieuThu");
                        soluong++;
                    }
                }
                phatsinhno = phatsinhco = 0;
                // Phiếu Chi
                for (int i = 0; i < pc.Length; i++)
                {
                    string month1 = pc[i].NgayLap.Month.ToString();
                    string year1 = pc[i].NgayLap.Year.ToString();
                    if (month == month1 && year == year1)
                    {
                        phatsinhco = Convert.ToDouble(pc[i].TongTienThanhToan);
                        string ngaylap = new Common.Utilities().XuLy(2, pc[i].NgayLap.ToShortDateString());
                        hienthi[soluong] = new Entities.SoQuy(ngaylap, pc[i].MaPhieuThu, "1111", "Tiền mặt việt nam",
                          Format(phatsinhno), Format(phatsinhco), pc[i].GhiChu, "PhieuChi");
                        soluong++;
                    }
                }
                phatsinhno = phatsinhco = 0;
                // Bán Lẻ
                for (int i = 0; i < bl.Length; i++)
                {
                    string month1 = bl[i].NgayBan.Month.ToString();
                    string year1 = bl[i].NgayBan.Year.ToString();
                    if (month == month1 && year == year1)
                    {
                        List<double> bientam = TienIch.TinhDoanhThu(Convert.ToDouble(bl[i].TongTienThanhToan), Convert.ToDouble(bl[i].GiaTriThe), Convert.ToDouble(bl[i].GiaTriTheGiaTri));
                        phatsinhno =  bientam[3]; //bl[i].ThanhToanNgay
                        string ngaylap = new Common.Utilities().XuLy(2, bl[i].NgayBan.ToShortDateString());
                        hienthi[soluong] = new Entities.SoQuy(ngaylap, bl[i].MaHDBanHang, "1111", "Tiền mặt việt nam",
                             Format(phatsinhno), Format(phatsinhco), bl[i].GhiChu, "BanLe");
                        soluong++;
                    }
                }
                phatsinhno = phatsinhco = 0;
                // Bán Buôn
                for (int i = 0; i < bb.Length; i++)
                {
                    string month1 = bb[i].NgayBan.Month.ToString();
                    string year1 = bb[i].NgayBan.Year.ToString();
                    if (month == month1 && year == year1)
                    {
                        double a = Convert.ToDouble(bb[i].TongTienThanhToan);
                        double b = Convert.ToDouble(bb[i].ThanhToanKhiLapPhieu);
                        if (b > a)
                        {
                            b = a;
                        }
                        phatsinhno = b;
                        string ngaylap = new Common.Utilities().XuLy(2, bb[i].NgayBan.ToShortDateString());
                        hienthi[soluong] = new Entities.SoQuy(ngaylap, bb[i].MaHDBanHang, "1111", "Tiền mặt việt nam",
                            Format(phatsinhno), Format(phatsinhco), bb[i].GhiChu, "BanBuon");
                        soluong++;
                    }
                }
                phatsinhno = phatsinhco = 0;
                // Hóa Đơn Nhập
                for (int i = 0; i < hdn.Length; i++)
                {
                    string month1 = hdn[i].NgayNhap.Month.ToString();
                    string year1 = hdn[i].NgayNhap.Year.ToString();
                    if (month == month1 && year == year1)
                    {
                        double a = Convert.ToDouble(hdn[i].TongTien);
                        double b = Convert.ToDouble(hdn[i].ThanhToanNgay);
                        if (b > a)
                        {
                            b = a;
                        }
                        phatsinhco = b;
                        string ngaylap = new Common.Utilities().XuLy(2, hdn[i].NgayNhap.ToShortDateString());
                        hienthi[soluong] = new Entities.SoQuy(ngaylap, hdn[i].MaHoaDonNhap, "1111", "Tiền mặt việt nam",
                             Format(phatsinhno), Format(phatsinhco), hdn[i].GhiChu, "HoaDonNhap");
                        soluong++;
                    }
                }
                phatsinhno = phatsinhco = 0;
                // Khách Hàng Trả Lại
                for (int i = 0; i < kh.Length; i++)
                {
                    string month1 = kh[i].NgayNhap.Month.ToString();
                    string year1 = kh[i].NgayNhap.Year.ToString();
                    double a = Convert.ToDouble(kh[i].TienBoiThuong);
                    double b = double.Parse(kh[i].ThanhToanNgay);
                    if (b > a)
                    {
                        b = a;
                    }
                    double a1 = b;
                    if (month == month1 && year == year1)
                    {
                        phatsinhco = a1;
                        string ngaylap = new Common.Utilities().XuLy(2, kh[i].NgayNhap.ToShortDateString());
                        hienthi[soluong] = new Entities.SoQuy(ngaylap, kh[i].MaKhachHangTraLai, "1111", "Tiền mặt việt nam",
                             Format(phatsinhno), Format(phatsinhco), kh[i].GhiChu, "KHTL");
                        soluong++;
                    }
                }
                phatsinhno = phatsinhco = 0;
                // Trả Lại Nhà Cung Cấp
                for (int i = 0; i < tl.Length; i++)
                {
                    string month1 = tl[i].Ngaytra.Month.ToString();
                    string year1 = tl[i].Ngaytra.Year.ToString();
                    double a = Convert.ToDouble(tl[i].TienBoiThuong);
                    double b = Convert.ToDouble(tl[i].ThanhToanNgay);
                    if (b > a)
                    {
                        b = a;
                    }
                    double a1 = b;
                    if (month == month1 && year == year1)
                    {
                        phatsinhno = a1;
                        string ngaylap = new Common.Utilities().XuLy(2, tl[i].Ngaytra.ToShortDateString());
                        hienthi[soluong] = new Entities.SoQuy(ngaylap, tl[i].MaHDTraLaiNCC, "1111", "Tiền mặt việt nam",
                            Format(phatsinhno), Format(phatsinhco), tl[i].GhiChu, "TLNCC");
                        soluong++;
                    }
                }
                phatsinhno = phatsinhco = 0;
                // Phiếu thanh toán nhà cung cấp
                for (int i = 0; i < pttncc.Length; i++)
                {
                    string month1 = pttncc[i].NgayLap.Month.ToString();
                    string year1 = pttncc[i].NgayLap.Year.ToString();
                    //double a1 = double.Parse(pttncc[i].NoHienThoi);
                    double a1 = TongThanhToanCuaPhieuThanhToan("NCC", pttncc[i].MaPhieuTTNCC);
                    if (month == month1 && year == year1)
                    {
                        phatsinhco = a1;
                        string ngaylap = new Common.Utilities().XuLy(2, pttncc[i].NgayLap.ToShortDateString());
                        hienthi[soluong] = new Entities.SoQuy(ngaylap, pttncc[i].MaPhieuTTNCC, "1111", "Tiền mặt việt nam",
                            Format(phatsinhno), Format(phatsinhco), pttncc[i].GhiChu, "PTTNCC");
                        soluong++;
                    }
                }
                phatsinhno = phatsinhco = 0;
                // Phiếu thanh toán khách hàng
                for (int i = 0; i < pttkh.Length; i++)
                {
                    string month1 = pttkh[i].NgayLap.Month.ToString();
                    string year1 = pttkh[i].NgayLap.Year.ToString();
                    //double a1 = double.Parse(pttkh[i].NoHienThoi);
                    double a1 = TongThanhToanCuaPhieuThanhToan("KH", pttkh[i].MaPhieuTTCuaKH);
                    if (month == month1 && year == year1)
                    {
                        phatsinhno = a1;
                        string ngaylap = new Common.Utilities().XuLy(2, pttkh[i].NgayLap.ToShortDateString());
                        hienthi[soluong] = new Entities.SoQuy(ngaylap, pttkh[i].MaPhieuTTCuaKH, "1111", "Tiền mặt việt nam",
                            Format(phatsinhno), Format(phatsinhco), pttkh[i].GhiChu, "PTTKH");
                        soluong++;
                    }
                }

                phatsinhno = phatsinhco = 0;
                List<Entities.SoQuy> l = new List<Entities.SoQuy>();
                foreach (Entities.SoQuy item in hienthi)
                {
                    if (item != null)
                    {
                        l.Add(item);
                    }
                }
                hienthi = l.ToArray();
                //Tính toán
                if (hienthi.Length == 0)
                {//Chỉ có số dư đầu kỳ
                    if (sddk == 0 && sdck == 0)
                    {
                        soquy = new Entities.SoQuy[0];
                    }
                    else
                    {
                        soquy = new Entities.SoQuy[1];
                        soquy[0] = new Entities.SoQuy("0", "0", "Tổng Cộng", Format(sddk), Format(sdck));
                    }
                }
                else
                {
                    soquy = new Entities.SoQuy[2];
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        phatsinhco += Convert.ToDouble(hienthi[i].PhatSinhCo);
                        phatsinhno += Convert.ToDouble(hienthi[i].PhatSinhNo);
                        sdck = sddk + phatsinhno - phatsinhco;
                        soquy[0] = new Entities.SoQuy("1111", "Tiền mặt việt nam", Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck), "TongHop");
                    }
                    if (phatsinhno == 0 && phatsinhco == 0)
                    {
                        sdck = sddk + phatsinhno - phatsinhco;
                        soquy[1] = new Entities.SoQuy("0", "0", "Tổng Cộng", Format(sddk), Format(sdck));
                    }
                    else if (phatsinhno == 0 && phatsinhco != 0)
                        soquy[1] = new Entities.SoQuy("0", Format(phatsinhco), "Tổng Cộng", Format(sddk), Format(sdck));
                    else if (phatsinhno != 0 && phatsinhco == 0)
                        soquy[1] = new Entities.SoQuy(Format(phatsinhno), "0", "Tổng Cộng", Format(sddk), Format(sdck));
                    else if (phatsinhno != 0 && phatsinhco != 0)
                        soquy[1] = new Entities.SoQuy(Format(phatsinhno), Format(phatsinhco), "Tổng Cộng", Format(sddk), Format(sdck));
                    a = soquy[1].DuCuoiKy;
                }
                dtgvsoquy.DataSource = soquy;
            }
            catch
            {
                dtgvsoquy.DataSource = new Entities.SoQuy[0];
            }
            finally
            {
                fix();
            }
        }

        double TongThanhToanCuaPhieuThanhToan(string chon,string ma)
        {
            double kq = 0;
            if (chon.Equals("NCC"))
            {
                //foreach (Entities.PhieuTTNCC item in pttncc)
                //{
                    foreach (Entities.ChiTietPhieuTTNCC item2 in ctpttncc)
                    {
                        if (ma.Equals(item2.MaPhieuTTNCC))
                        {
                            kq += item2.ThanhToan;
                        }
                    }
                //}
            }
            else if (chon.Equals("KH"))
            {
                //foreach (Entities.PhieuTTCuaKH item in pttkh)
                //{
                    foreach (Entities.ChiTietPhieuTTCuaKH item2 in ctpttkh)
                    {
                        if (ma.Equals(item2.MaPhieuTTCuaKH))
                        {
                            kq += item2.ThanhToan;
                        }
                    }
                //}
            }

            return kq;
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
        /// <summary>
        /// đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// lọc theo điều kiện
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslbldieukien_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// click vào xem chi tiết
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslblchitiet_Click(object sender, EventArgs e)
        {
            try
            {
                if (i == 0)
                {
                    frmChiTietSoQuy a = new frmChiTietSoQuy(hienthi, pt, pc, bl, bb, hdn, kh, tl, soquy[1].DuDauKy, soquy[1].DuCuoiKy);
                    a.ShowDialog();
                }
            }
            catch
            {

            }
        }
        int i;

        private void frmSoquy_Load(object sender, EventArgs e)
        {
            try
            {
                dtgvsoquy.Rows[dtgvsoquy.RowCount - 1].DefaultCellStyle.Font = new Font(dtgvsoquy.DefaultCellStyle.Font, FontStyle.Bold);
            }
            catch { }
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
            if (batdau)
            {
                batdau = false;
                return;
            }
            month = cbbthang.Text;
            year = cbbnam.Text;
            this.Enabled = false;
            try
            {
                //SelectBanBuon();
                //SelectBanLe();
                //SelectPhieuThu();
                //SelectPhieuChi();
                //SelectNhapKho();
                //SelectKHTL();
                //SelectTLNCC();
                SelectSoQuy();
                HienThiTongThe();
            }
            catch
            {
            }
            this.Enabled = true;
        }

        private void cbbnam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (batdau)
            {
                batdau = false;
                return;
            }
            month = cbbthang.Text;
            year = cbbnam.Text;
            this.Enabled = false;
            try
            {
                //SelectBanBuon();
                //SelectBanLe();
                //SelectPhieuThu();
                //SelectPhieuChi();
                //SelectNhapKho();
                //SelectKHTL();
                //SelectTLNCC();
                SelectSoQuy();
                HienThiTongThe();
            }
            catch
            {
            }
            this.Enabled = true;
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dtgvsoquy_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                if (i == 0)
                {
                    //SelectSoQuy();
                    //HienThiTongThe();
                    frmChiTietSoQuy a = new frmChiTietSoQuy(hienthi, pt, pc, bl, bb, hdn, kh, tl, soquy[1].DuDauKy, soquy[1].DuCuoiKy);
                    a.ShowDialog();
                }
            }
            catch
            {

            }
        }

        private void dtgvsoquy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void tsslnap_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                SelectSoQuy();
                HienThiTongThe();
            }
            catch
            {
            }
            this.Enabled = true;
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

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            try
            {
                List<Entities.SoQuy> tem0 = ((Entities.SoQuy[])dtgvsoquy.DataSource).ToList();
                tem0.RemoveAt(tem0.Count - 1);
                Entities.SoQuy[] tem = tem0.ToArray();
                if (tem.Length > 0)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt("SoQuy_In", tem, "", true);
                    a.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại dữ liệu trước khi in!");
                }
            }
            catch
            {
            }
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            try
            {
                List<Entities.SoQuy> tem0 = ((Entities.SoQuy[])dtgvsoquy.DataSource).ToList();
                tem0.RemoveAt(tem0.Count - 1);
                Entities.SoQuy[] tem = tem0.ToArray();
                if (tem.Length > 0)
                {
                    SaveFileDialog s = new SaveFileDialog();
                    s.Filter = "PDF |*.pdf";
                    if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        frmBaoCaorpt a = new frmBaoCaorpt("SoQuy_PDF", tem, s.FileName, true);
                        a.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại dữ liệu trước khi in!");
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
                List<Entities.SoQuy> tem0 = ((Entities.SoQuy[])dtgvsoquy.DataSource).ToList();
                tem0.RemoveAt(tem0.Count - 1);
                Entities.SoQuy[] tem = tem0.ToArray();
                if (tem.Length > 0)
                {
                    SaveFileDialog s = new SaveFileDialog();
                    s.Filter = "DOC |*.doc";
                    if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        frmBaoCaorpt a = new frmBaoCaorpt("SoQuy_DOC", tem, s.FileName, true);
                        a.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại dữ liệu trước khi in!");
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
                List<Entities.SoQuy> tem0 = ((Entities.SoQuy[])dtgvsoquy.DataSource).ToList();
                tem0.RemoveAt(tem0.Count - 1);
                Entities.SoQuy[] tem = tem0.ToArray();
                if (tem.Length > 0)
                {
                    SaveFileDialog s = new SaveFileDialog();
                    s.Filter = "XLS |*.xls";
                    if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        frmBaoCaorpt a = new frmBaoCaorpt("SoQuy_XLS", tem, s.FileName, true);
                        a.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại dữ liệu trước khi in!");
                }
            }
            catch { }
        }
    }
}
