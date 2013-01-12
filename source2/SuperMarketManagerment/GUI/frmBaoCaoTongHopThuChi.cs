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
    public partial class frmBaoCaoTongHopThuChi : Form
    {
        Entities.PhieuThu[] pt;
        Entities.PhieuThu[] pc;
        Entities.HDBanHang[] bb;
        Entities.HDBanHang[] bl;
        Entities.HoaDonNhap[] hdn;
        Entities.TraLaiNCC[] tl;
        Entities.SoQuy soquy;
        Entities.KhachHangTraLai[] kh;
        Entities.PhieuTTCuaKH[] pttkh = new Entities.PhieuTTCuaKH[0];
        Entities.PhieuTTNCC[] pttncc = new Entities.PhieuTTNCC[0];
        Entities.ChiTietPhieuTTCuaKH[] ctpttkh;
        Entities.ChiTietPhieuTTNCC[] ctpttncc;
        Entities.PhieuThu[] thuchi;
        Entities.HDBanHang[] buonle;
        List<Entities.SoQuy> hienthi;
        Entities.SoDuSoQuy[] sodu;
        public static string a = "0";

        DateTime datesv;
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        DateTime batDau = new DateTime(1753, 1, 1);
        DateTime ketThuc = new DateTime(1753, 1, 1);

        public frmBaoCaoTongHopThuChi()
        {
            InitializeComponent();
            try
            {
                datesv = DateServer.Date();
                int thang = datesv.Month;
                int nam = datesv.Year;
                int soNgayTrongThang = DateTime.DaysInMonth(nam, thang);
                batDau = new DateTime(nam, thang, 1);
                ketThuc = new DateTime(nam, thang, soNgayTrongThang);
                label1.Text = "Báo Cáo Tổng Hợp Thu Chi Từ Ngày " + new Common.Utilities().XuLy(2, batDau.ToShortDateString()) + " Đến Ngày " + new Common.Utilities().XuLy(2, ketThuc.ToShortDateString());
                SelectSoQuy();
                HienThiTongThe();
                Entities.SoQuy sq = new Entities.SoQuy();
                double dudauky = 0;
                double ducuoiky = 0;
                if (soquy != null)
                {
                    if (!string.IsNullOrEmpty(soquy.DuDauKy))
                        dudauky = double.Parse(soquy.DuDauKy);
                    if (!string.IsNullOrEmpty(soquy.DuCuoiKy))
                        ducuoiky = double.Parse(soquy.DuCuoiKy);
                    txtducuoiky.Text = ducuoiky.ToString();
                    try
                    {
                        dudauky = double.Parse(sodu[0].SoDuDauKy);
                    }
                    catch { }
                    txtdudauky.Text = dudauky.ToString();
                }
                if (hienthi != null && hienthi.Count() > 0 && hienthi[0] != null)
                {
                    if (Thu() == 0 && Chi() == 0)
                        sq = new Entities.SoQuy("0", "0", "Tổng Cộng");
                    else if (Thu() == 0 && Chi() != 0)
                        sq = new Entities.SoQuy("0", Format(Chi()), "Tổng Cộng");
                    else if (Thu() != 0 && Chi() == 0)
                        sq = new Entities.SoQuy(Format(Thu()), "0", "Tổng Cộng");
                    else if (Thu() != 0 && Chi() != 0)
                        sq = new Entities.SoQuy(Format(Thu()), Format(Chi()), "Tổng Cộng");
                }
                List<Entities.SoQuy> dataSource = new List<Entities.SoQuy>();
                foreach (Entities.SoQuy item in hienthi)
                {
                    dataSource.Add(item);
                }
                dataSource.Add(sq);
                dtgvhienthi.DataSource = dataSource;
                Ton();
                fix();
            }
            catch { }
        }

        public double Thu()
        {
            double tongthu = 0;
            for (int i = 0; i < hienthi.ToArray().Length; i++)
            {
                tongthu += Convert.ToDouble(hienthi[i].PhatSinhNo);
            }
            return tongthu;
        }

        public double Chi()
        {
            double tongchi = 0;
            for (int i = 0; i < hienthi.ToArray().Length; i++)
            {
                tongchi += Convert.ToDouble(hienthi[i].PhatSinhCo);
            }
            return tongchi;
        }

        public void Ton()
        {
            double ton = 0;
            for (int i = 0; i < hienthi.ToArray().Length; i++)
            {
                ton = Convert.ToDouble(ton) + Convert.ToDouble(hienthi[i].PhatSinhNo) - Convert.ToDouble(hienthi[i].PhatSinhCo);
                dtgvhienthi["Ton", i].Value = Format(ton);
            }
        }

        public void fix()
        {
            for (int i = 0; i < dtgvhienthi.ColumnCount; i++)
            {
                dtgvhienthi.Columns[i].Visible = false;
            }
            dtgvhienthi.Columns["NgayLap"].Visible = true;
            dtgvhienthi.Columns["MaPhieu"].Visible = true;
            dtgvhienthi.Columns["PhatSinhNo"].Visible = true;
            dtgvhienthi.Columns["PhatSinhCo"].Visible = true;
            dtgvhienthi.Columns["DienGiai"].Visible = true;
            dtgvhienthi.Columns["Ton"].Visible = true;
            dtgvhienthi.Columns["NgayLap"].HeaderText = "Ngày";
            dtgvhienthi.Columns["MaPhieu"].HeaderText = "Mã Chứng Từ";
            dtgvhienthi.Columns["DienGiai"].HeaderText = "Ghi Chú";
            dtgvhienthi.Columns["PhatSinhNo"].HeaderText = "Thu";
            dtgvhienthi.Columns["PhatSinhCo"].HeaderText = "Chi";

            dtgvhienthi.Columns["Ton"].HeaderText = "Tồn";
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.AllowUserToAddRows = false;
            dtgvhienthi.AllowUserToDeleteRows = false;
            dtgvhienthi.AllowUserToResizeRows = false;
            dtgvhienthi.RowHeadersVisible = false;
        }

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

        private void frmBaoCaoTongHopThuChi_Load(object sender, EventArgs e)
        {
            dtgvhienthi.Rows[dtgvhienthi.RowCount - 1].DefaultCellStyle.Font = new Font(dtgvhienthi.DefaultCellStyle.Font, FontStyle.Bold);
        }
        int i = 0;

        private void tssltrove_Click(object sender, EventArgs e)
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

        //private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    i = e.RowIndex;
        //    if (i < 0)
        //        return;
        //    try
        //    {
        //        string objname = hienthi[i].TruongNgam;
        //        string maphieu = hienthi[i].MaPhieu;
        //        switch (objname)
        //        {
        //            case "PhieuThu":
        //                {
        //                    dtgvngam.DataSource = pt;
        //                    int so = 0;
        //                    for (int j = 0; j < pt.Length; j++)
        //                    {
        //                        if (pt[j].MaPhieuThu == maphieu)
        //                        {
        //                            so = j;
        //                            break;
        //                        }
        //                    }

        //                    frmXuLyPhieuThuChi b = new frmXuLyPhieuThuChi("Thu", "Sua", dtgvngam.Rows[so]);
        //                    b.ShowDialog();
        //                    break;
        //                }
        //            case "PhieuChi":
        //                {
        //                    dtgvngam.DataSource = pc;
        //                    int so = 0;
        //                    for (int j = 0; j < pc.Length; j++)
        //                    {
        //                        if (pc[j].MaPhieuThu == maphieu)
        //                        {
        //                            so = j;
        //                            break;
        //                        }
        //                    }

        //                    frmXuLyPhieuThuChi b = new frmXuLyPhieuThuChi("Thu", "Sua", dtgvngam.Rows[so]);
        //                    b.ShowDialog();
        //                    break;
        //                }
        //            case "BanBuon":
        //                {
        //                    dtgvngam.DataSource = bb;
        //                    int so = 0;
        //                    for (int j = 0; j < bb.Length; j++)
        //                    {
        //                        if (bb[j].MaHDBanHang == maphieu)
        //                        {
        //                            so = j;
        //                            break;
        //                        }
        //                    }
        //                    frmXuLyBanBuon b = new frmXuLyBanBuon("Sua", dtgvngam.Rows[so]);
        //                    b.ShowDialog();
        //                    break;
        //                }
        //            case "BanLe":
        //                {
        //                    dtgvngam.DataSource = bl;
        //                    int so = 0;
        //                    for (int j = 0; j < bl.Length; j++)
        //                    {
        //                        if (bl[j].MaHDBanHang == maphieu)
        //                        {
        //                            so = j;
        //                            break;
        //                        }
        //                    }
        //                    frmXuLyBanLe b = new frmXuLyBanLe("Sua", dtgvngam.Rows[so]);
        //                    b.ShowDialog();
        //                    break;
        //                }
        //            case "HoaDonNhap":
        //                {
        //                    int so = 0;
        //                    for (int j = 0; j < hdn.Length; j++)
        //                    {
        //                        if (hdn[j].MaHoaDonNhap == maphieu)
        //                        {
        //                            so = j;
        //                            break;
        //                        }
        //                    }
        //                    frmXuLyNhapKho b = new frmXuLyNhapKho("Update", hdn[so]);
        //                    b.ShowDialog();
        //                    break;
        //                }
        //            case "KHTL":
        //                {
        //                    int so = 0;
        //                    for (int j = 0; j < kh.Length; j++)
        //                    {
        //                        if (kh[j].MaKhachHangTraLai == maphieu)
        //                        {
        //                            so = j;
        //                            break;
        //                        }
        //                    }
        //                    frmXuLyHangTraLai b = new frmXuLyHangTraLai("Sua_KhachHangTraLai", "KhachHangTraLai", "Update", kh[so]);
        //                    b.ShowDialog();
        //                    break;
        //                }
        //            case "TLNCC":
        //                {
        //                    int so = 0;
        //                    for (int j = 0; j < tl.Length; j++)
        //                    {
        //                        if (tl[j].MaHDTraLaiNCC == maphieu)
        //                        {
        //                            so = j;
        //                            break;
        //                        }
        //                    }
        //                    frmXuLyHangTraLai b = new frmXuLyHangTraLai("Sua_TraLaiNhaCungCap", "TraLaiNhaCungCap", "Update", tl[so]);
        //                    b.ShowDialog();
        //                    break;
        //                }
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

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

        //----------------------------------------------------------------

        int sl = 0;
        Entities.SelectAll selectall;
        void SelectSoQuy()
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

            SelectPhieuThuChi();
            SelectPhieuThanhToan(); //Chọn phiếu thanh toán

            buonle = selectall.HDBanHang;
            if (buonle == null)
            {
                buonle = bb = bl = new Entities.HDBanHang[0];
                return;
            }
            SelectBanBuonLe();
            hdn = selectall.HoaDonNhap;
            kh = selectall.KhachHangTraLai;
            tl = selectall.TraLaiNCC;
            SelectNhapKho();
            SelectKHTL();
            SelectTLNCC();

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
        /// SelectPhieuThanhToan
        /// </summary>
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
                    if (thuchi[j].Deleted == false && thuchi[j].LoaiPhieu == "Thu")
                    {
                        if (batDau <= thuchi[j].NgayLap && thuchi[j].NgayLap <= ketThuc)
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
                    if (thuchi[j].Deleted == false && thuchi[j].LoaiPhieu == "Chi")
                    {
                        if (batDau <= thuchi[j].NgayLap && thuchi[j].NgayLap <= ketThuc)
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
            catch
            {
            }
            finally
            {


            }
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
                    if (buonle[j].LoaiHoaDon == true && buonle[j].Deleted == false)
                    {
                        if (batDau <= buonle[j].NgayBan && buonle[j].NgayBan <= ketThuc)
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
            catch (Exception ex)
            {

            }
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
                    if (buonle[j].LoaiHoaDon == false && buonle[j].Deleted == false)
                    {
                        if (batDau <= buonle[j].NgayBan && buonle[j].NgayBan <= ketThuc && Convert.ToDouble(buonle[j].ThanhToanKhiLapPhieu) != 0)
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
            catch (Exception ex)
            {

            }
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
                    if (hdn[j].Deleted == false && batDau <= hdn[j].NgayNhap && hdn[j].NgayNhap <= ketThuc && Convert.ToDouble(hdn[j].ThanhToanNgay) != 0)
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
            catch (Exception ex)
            {

            }
            finally
            {


            }
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
                    if (kh[j].Deleted == false)
                    {
                        if (batDau <= kh[j].NgayNhap && kh[j].NgayNhap <= ketThuc && Convert.ToDouble(kh[j].ThanhToanNgay) != 0)
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
            catch (Exception ex)
            {

            }
            finally
            {


            }
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
                    if (batDau <= tl[j].Ngaytra && tl[j].Ngaytra <= ketThuc && Convert.ToDouble(tl[j].ThanhToanNgay) != 0)
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
            catch
            {
            }
            finally
            {


            }
        }

        double TongThanhToanCuaPhieuThanhToan(string chon, string ma)
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
                hienthi = new List<Entities.SoQuy>();
                if (kt == false)
                {
                    for (int i = 0; i < sodu.Length; i++)
                    {
                        if (batDau <= sodu[i].NgayKetChuyen && sodu[i].NgayKetChuyen <= ketThuc)
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
                    if (batDau <= pt[i].NgayLap && pt[i].NgayLap <= ketThuc)
                    {
                        phatsinhno = Convert.ToDouble(pt[i].TongTienThanhToan);
                        string ngaylap = new Common.Utilities().XuLy(2, pt[i].NgayLap.ToShortDateString());
                        Entities.SoQuy soquy = new Entities.SoQuy(ngaylap, pt[i].MaPhieuThu, "1111", "Tiền mặt việt nam",
                            Format(phatsinhno), Format(phatsinhco), pt[i].GhiChu, "PhieuThu");
                        hienthi.Add(soquy);
                    }
                }
                phatsinhno = phatsinhco = 0;
                // Phiếu Chi
                for (int i = 0; i < pc.Length; i++)
                {
                    string month1 = pc[i].NgayLap.Month.ToString();
                    string year1 = pc[i].NgayLap.Year.ToString();
                    if (batDau <= pc[i].NgayLap && pc[i].NgayLap <= ketThuc)
                    {
                        phatsinhco = Convert.ToDouble(pc[i].TongTienThanhToan);
                        string ngaylap = new Common.Utilities().XuLy(2, pc[i].NgayLap.ToShortDateString());
                        Entities.SoQuy soquy = new Entities.SoQuy(ngaylap, pc[i].MaPhieuThu, "1111", "Tiền mặt việt nam",
                          Format(phatsinhno), Format(phatsinhco), pc[i].GhiChu, "PhieuChi");
                        hienthi.Add(soquy);
                    }
                }
                phatsinhno = phatsinhco = 0;
                // Bán Lẻ
                for (int i = 0; i < bl.Length; i++)
                {
                    if (batDau <= bl[i].NgayBan && bl[i].NgayBan <= ketThuc)
                    {
                        List<double> bientam = TienIch.TinhDoanhThu(Convert.ToDouble(bl[i].TongTienThanhToan), Convert.ToDouble(bl[i].GiaTriThe), Convert.ToDouble(bl[i].GiaTriTheGiaTri));
                        phatsinhno = bientam[3];
                        string ngaylap = new Common.Utilities().XuLy(2, bl[i].NgayBan.ToShortDateString());
                        Entities.SoQuy soquy = new Entities.SoQuy(ngaylap, bl[i].MaHDBanHang, "1111", "Tiền mặt việt nam",
                             Format(phatsinhno), Format(phatsinhco), bl[i].GhiChu, "BanLe");
                        hienthi.Add(soquy);
                    }
                }
                phatsinhno = phatsinhco = 0;
                // Bán Buôn
                for (int i = 0; i < bb.Length; i++)
                {
                    if (batDau <= bb[i].NgayBan && bb[i].NgayBan <= ketThuc)
                    {
                        phatsinhno = Convert.ToDouble(bb[i].ThanhToanKhiLapPhieu);
                        string ngaylap = new Common.Utilities().XuLy(2, bb[i].NgayBan.ToShortDateString());
                        Entities.SoQuy soquy = new Entities.SoQuy(ngaylap, bb[i].MaHDBanHang, "1111", "Tiền mặt việt nam",
                            Format(phatsinhno), Format(phatsinhco), bb[i].GhiChu, "BanBuon");
                        hienthi.Add(soquy);
                    }
                }
                phatsinhno = phatsinhco = 0;
                // Hóa Đơn Nhập
                for (int i = 0; i < hdn.Length; i++)
                {
                    if (batDau <= hdn[i].NgayNhap && hdn[i].NgayNhap <= ketThuc)
                    {
                        phatsinhco = Convert.ToDouble(hdn[i].ThanhToanNgay);
                        string ngaylap = new Common.Utilities().XuLy(2, hdn[i].NgayNhap.ToShortDateString());
                        Entities.SoQuy soquy = new Entities.SoQuy(ngaylap, hdn[i].MaHoaDonNhap, "1111", "Tiền mặt việt nam",
                             Format(phatsinhno), Format(phatsinhco), hdn[i].GhiChu, "HoaDonNhap");
                        hienthi.Add(soquy);
                    }
                }


                phatsinhno = phatsinhco = 0;
                // Phiếu thanh toán nhà cung cấp
                for (int i = 0; i < pttncc.Length; i++)
                {
                    double a1 = TongThanhToanCuaPhieuThanhToan("NCC", pttncc[i].MaPhieuTTNCC);
                    if (batDau <= pttncc[i].NgayLap && pttncc[i].NgayLap <= ketThuc)
                    {
                        phatsinhco = a1;
                        string ngaylap = new Common.Utilities().XuLy(2, pttncc[i].NgayLap.ToShortDateString());
                        Entities.SoQuy soquy = new Entities.SoQuy(ngaylap, pttncc[i].MaPhieuTTNCC, "1111", "Tiền mặt việt nam",
                            Format(phatsinhno), Format(phatsinhco), pttncc[i].GhiChu, "PTTNCC");
                        hienthi.Add(soquy);
                    }
                }
                phatsinhno = phatsinhco = 0;
                // Phiếu thanh toán khách hàng
                for (int i = 0; i < pttkh.Length; i++)
                {
                    double a1 = TongThanhToanCuaPhieuThanhToan("KH", pttkh[i].MaPhieuTTCuaKH);
                    if (batDau <= pttkh[i].NgayLap && pttkh[i].NgayLap <= ketThuc)
                    {
                        phatsinhno = a1;
                        string ngaylap = new Common.Utilities().XuLy(2, pttkh[i].NgayLap.ToShortDateString());
                        Entities.SoQuy soquy = new Entities.SoQuy(ngaylap, pttkh[i].MaPhieuTTCuaKH, "1111", "Tiền mặt việt nam",
                            Format(phatsinhno), Format(phatsinhco), pttkh[i].GhiChu, "PTTKH");
                        hienthi.Add(soquy);
                    }
                }

                phatsinhno = phatsinhco = 0;
                // Khách Hàng Trả Lại
                for (int i = 0; i < kh.Length; i++)
                {
                    string month1 = kh[i].NgayNhap.Month.ToString();
                    string year1 = kh[i].NgayNhap.Year.ToString();
                    double a1 = double.Parse(kh[i].ThanhToanNgay);
                    if (batDau <= kh[i].NgayNhap && kh[i].NgayNhap <= ketThuc)
                    {
                        phatsinhco = a1;
                        string ngaylap = new Common.Utilities().XuLy(2, kh[i].NgayNhap.ToShortDateString());
                        Entities.SoQuy soquy = new Entities.SoQuy(ngaylap, kh[i].MaKhachHangTraLai, "1111", "Tiền mặt việt nam",
                             Format(phatsinhno), Format(phatsinhco), kh[i].GhiChu, "KHTL");
                        hienthi.Add(soquy);
                    }
                }
                phatsinhno = phatsinhco = 0;
                // Trả Lại Nhà Cung Cấp
                for (int i = 0; i < tl.Length; i++)
                {
                    double a1 = double.Parse(tl[i].ThanhToanNgay);
                    if (batDau <= tl[i].Ngaytra && tl[i].Ngaytra <= ketThuc)
                    {
                        phatsinhno = a1;
                        string ngaylap = new Common.Utilities().XuLy(2, tl[i].Ngaytra.ToShortDateString());
                        Entities.SoQuy soquy = new Entities.SoQuy(ngaylap, tl[i].MaHDTraLaiNCC, "1111", "Tiền mặt việt nam",
                            Format(phatsinhno), Format(phatsinhco), tl[i].GhiChu, "TLNCC");
                        hienthi.Add(soquy);
                    }
                }
                phatsinhno = phatsinhco = 0;
                //Tính toán
                Entities.SoQuy tongSQ = new Entities.SoQuy();
                if (hienthi.ToArray().Length == 1)
                {
                    tongSQ = new Entities.SoQuy("0", "0", "Tổng Cộng", Format(sddk), Format(sdck));
                }
                else
                {
                    for (int i = 0; i < hienthi.ToArray().Length; i++)
                    {
                        phatsinhco += Convert.ToDouble(hienthi[i].PhatSinhCo);
                        phatsinhno += Convert.ToDouble(hienthi[i].PhatSinhNo);
                        sdck = sddk + phatsinhno - phatsinhco;
                        tongSQ = new Entities.SoQuy("1111", "Tiền mặt việt nam", Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck), "TongHop");
                    }
                }

                this.soquy = tongSQ;
            }
            catch
            {

            }
            finally
            {

            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                frmLocDieuKien a = new frmLocDieuKien();
                a.ShowDialog();
                if (frmLocDieuKien.truoc != "" && frmLocDieuKien.sau != "")
                {
                    string batdau = frmLocDieuKien.truoc;
                    string ketthuc = frmLocDieuKien.sau;
                    this.batDau = Convert.ToDateTime(batdau);
                    this.ketThuc = Convert.ToDateTime(ketthuc);
                    label1.Text = "Báo Cáo Tổng Hợp Thu Chi Từ Ngày " + new Common.Utilities().XuLy(2, batDau.ToShortDateString()) + " Đến Ngày " + new Common.Utilities().XuLy(2, ketThuc.ToShortDateString());
                    SelectSoQuy();
                    HienThiTongThe();
                    Entities.SoQuy tongSQ = new Entities.SoQuy();
                    double dudauky = 0;
                    double ducuoiky = 0;
                    if (soquy != null)
                    {
                        if (!string.IsNullOrEmpty(soquy.DuDauKy))
                            dudauky = double.Parse(soquy.DuDauKy);
                        if (!string.IsNullOrEmpty(soquy.DuCuoiKy))
                            ducuoiky = double.Parse(soquy.DuCuoiKy);
                        txtducuoiky.Text = ducuoiky.ToString();
                        txtdudauky.Text = dudauky.ToString();
                    }
                    if (hienthi != null && hienthi.Count() > 0 && hienthi[0] != null)
                    {
                        if (Thu() == 0 && Chi() == 0)
                            tongSQ = new Entities.SoQuy("0", "0", "Tổng Cộng");
                        else if (Thu() == 0 && Chi() != 0)
                            tongSQ = new Entities.SoQuy("0", Format(Chi()), "Tổng Cộng");
                        else if (Thu() != 0 && Chi() == 0)
                            tongSQ = new Entities.SoQuy(Format(Thu()), "0", "Tổng Cộng");
                        else if (Thu() != 0 && Chi() != 0)
                            tongSQ = new Entities.SoQuy(Format(Thu()), Format(Chi()), "Tổng Cộng");
                    }
                    List<Entities.SoQuy> dataSource = new List<Entities.SoQuy>();
                    foreach (Entities.SoQuy item in hienthi)
                    {
                        dataSource.Add(item);
                    }
                    dataSource.Add(tongSQ);
                    dtgvhienthi.DataSource = dataSource;
                    Ton();
                    fix();

                    frmLocDieuKien.truoc = frmLocDieuKien.sau = "";
                }
            }
            catch
            {
            }
        }

        private void btnNapLai_Click(object sender, EventArgs e)
        {
            int thang = datesv.Month;
            int nam = datesv.Year;
            int soNgayTrongThang = DateTime.DaysInMonth(nam, thang);
            batDau = new DateTime(nam, thang, 1);
            ketThuc = new DateTime(nam, thang, soNgayTrongThang);
            label1.Text = "Báo Cáo Tổng Hợp Thu Chi Từ Ngày " + new Common.Utilities().XuLy(2, batDau.ToShortDateString()) + " Đến Ngày " + new Common.Utilities().XuLy(2, ketThuc.ToShortDateString());
            SelectSoQuy();
            HienThiTongThe();
            Entities.SoQuy tongSQ = new Entities.SoQuy();
            double dudauky = 0;
            double ducuoiky = 0;
            if (soquy != null)
            {
                if (!string.IsNullOrEmpty(soquy.DuDauKy))
                    dudauky = double.Parse(soquy.DuDauKy);
                if (!string.IsNullOrEmpty(soquy.DuCuoiKy))
                    ducuoiky = double.Parse(soquy.DuCuoiKy);
                txtducuoiky.Text = ducuoiky.ToString();
                txtdudauky.Text = dudauky.ToString();
            }
            if (hienthi != null && hienthi.Count() > 0 && hienthi[0] != null)
            {
                if (Thu() == 0 && Chi() == 0)
                    tongSQ = new Entities.SoQuy("0", "0", "Tổng Cộng");
                else if (Thu() == 0 && Chi() != 0)
                    tongSQ = new Entities.SoQuy("0", Format(Chi()), "Tổng Cộng");
                else if (Thu() != 0 && Chi() == 0)
                    tongSQ = new Entities.SoQuy(Format(Thu()), "0", "Tổng Cộng");
                else if (Thu() != 0 && Chi() != 0)
                    tongSQ = new Entities.SoQuy(Format(Thu()), Format(Chi()), "Tổng Cộng");
            }
            List<Entities.SoQuy> dataSource = new List<Entities.SoQuy>();
            foreach (Entities.SoQuy item in hienthi)
            {
                dataSource.Add(item);
            }
            dataSource.Add(tongSQ);
            dtgvhienthi.DataSource = dataSource;
            Ton();
            fix();
        }

        /// <summary>
        /// Get Data
        /// </summary>
        /// <param name="sqArr"></param>
        /// <returns></returns>
        public Entities.TongHopThuChi[] GetData(Entities.SoQuy[] sqArr)
        {
            List<Entities.TongHopThuChi> list = new List<Entities.TongHopThuChi>();
            try
            {
                if (sqArr != null && sqArr.Count() > 0)
                {
                    foreach (Entities.SoQuy item in sqArr)
                    {
                        Entities.TongHopThuChi tc = new Entities.TongHopThuChi();
                        tc.MaPhieu = item.MaPhieu;
                        tc.NgayLap = item.NgayLap;
                        tc.PhatSinhNo = double.Parse(item.PhatSinhNo);
                        tc.PhatSinhCo = double.Parse(item.PhatSinhCo);
                        tc.Ton = double.Parse(item.Ton);
                        tc.DienGiai = item.DienGiai;
                        list.Add(tc);
                    }
                }
            }
            catch (Exception)
            {

            }
            return list.ToArray();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            Entities.TongHopThuChi[] tcArr = GetData(hienthi.ToArray());
            frmBaoCaorpt a = new frmBaoCaorpt(tcArr, batDau, ketThuc, "In", "", double.Parse(txtdudauky.Text), double.Parse(txtducuoiky.Text));
            a.ShowDialog();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                Entities.TongHopThuChi[] tcArr = GetData(hienthi.ToArray());
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(tcArr, batDau, ketThuc, "Excel", saveFileDialog1.FileName, double.Parse(txtdudauky.Text), double.Parse(txtducuoiky.Text));
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
                Entities.TongHopThuChi[] tcArr = GetData(hienthi.ToArray());
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(tcArr, batDau, ketThuc, "Word", saveFileDialog1.FileName, double.Parse(txtdudauky.Text), double.Parse(txtducuoiky.Text));
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
                Entities.TongHopThuChi[] tcArr = GetData(hienthi.ToArray());
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(tcArr, batDau, ketThuc, "PDF", saveFileDialog1.FileName, double.Parse(txtdudauky.Text), double.Parse(txtducuoiky.Text));
                }
            }
            catch
            {
            }
            finally { this.Enabled = true; }
        }

        private void btnNapLai_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void btnNapLai_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void btnXem_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void btnXem_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void btnExcel_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void btnExcel_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void btnWord_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void btnWord_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void btnPDF_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void btnPDF_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void btnLoc_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void btnLoc_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void btnThoat_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
        //----------------------------------------------------------------
    }
}
