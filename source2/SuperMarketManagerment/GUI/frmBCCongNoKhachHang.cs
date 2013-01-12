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
    public partial class frmBCCongNoKhachHang : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Entities.SelectAll selectall;
        DateTime datesv;
        public frmBCCongNoKhachHang()
        {

            InitializeComponent();
            try
            {
                datesv = DateServer.Date();
                batdau = new Common.Utilities().MyDateConversion("01/" + datesv.Month.ToString() + "/" + datesv.Year.ToString());
                if (datesv.Month.ToString() == "12")
                    ketthuc = new Common.Utilities().MyDateConversion("01/01/" + (Convert.ToInt32(datesv.Year.ToString()) + 1).ToString());
                else
                    ketthuc = new Common.Utilities().MyDateConversion("01/" + (Convert.ToInt32(datesv.Month.ToString()) + 1).ToString() + "/" + datesv.Year.ToString());
                truoc = Convert.ToDateTime(batdau);
                sau = Convert.ToDateTime(ketthuc);

            }
            catch
            {
            }
        }
        string batdau = "";
        string ketthuc = "";
        DateTime truoc;
        DateTime sau;
        Entities.PhieuThu[] phieuThuChi;
        Server_Client.Client cl;
        Entities.KhachHang[] kh;
        Entities.HDBanHang[] bb;
        List<Entities.CongNo> hienthi;
        List<Entities.CongNo> congnokh;
        Entities.KhachHangTraLai[] khtl;
        public static Entities.SoDuCongNo[] mangchitiet;
        Entities.SoDuCongNo[] soducongno;
        Entities.PhieuTTCuaKH[] phieuttcuakh;
        Entities.ChiTietPhieuTTCuaKH[] chitietphieuttcuakh;
        void SelectData()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("BCCongNoKhachHang");
            clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
            selectall = (Entities.SelectAll)cl.DeserializeHepper(clientstrem, selectall);
            kh = selectall.KhachHang;
            bb = selectall.HDBanHang;
            soducongno = selectall.SoDuCongNo;
            khtl = selectall.KhachHangTraLai;
            phieuttcuakh = selectall.PhieuTTCuaKH;
            chitietphieuttcuakh = selectall.ChiTietPhieuTTCuaKH;
            phieuThuChi = selectall.PhieuThu;
            SelectKhachHang();
            SelectKHTL();
            SelectBanBuonLe();
            SelectPhieuTTCuaKH();
            SelectChiTietPhieuTTCuaKH();
            SelectSoDuCongNo();

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

        private void btnhienthi_Click(object sender, EventArgs e)
        {

        }

        public void SelectSoDuCongNo()
        {
            try
            {
                if (soducongno == null || soducongno.Length == 0)
                {
                    soducongno = new Entities.SoDuCongNo[0];
                    return;
                }

                int sotang = 0;
                Entities.SoDuCongNo[] sq = new Entities.SoDuCongNo[soducongno.Length];
                for (int i = 0; i < sq.Length; i++)
                {
                    string namkt = soducongno[i].NgayKetChuyen.Year.ToString();
                    string thangkt = soducongno[i].NgayKetChuyen.Month.ToString();

                    if (soducongno[i].LoaiDoiTuong == false && namkt == datesv.Year.ToString() && thangkt == datesv.Month.ToString())
                    {
                        sq[sotang] = soducongno[i];
                        sotang++;
                    }

                }
                if (sotang != 0)
                {
                    soducongno = new Entities.SoDuCongNo[sotang];
                    for (int i = 0; i < sotang; i++)
                    {
                        soducongno[i] = new Entities.SoDuCongNo("", sq[i].MaDoiTuong, sq[i].TenDoiTuong, sq[i].DiaChi, sq[i].SoDuDauKy);
                        soducongno[i].NgayKetChuyen = sq[i].NgayKetChuyen;
                    }
                }
                else
                    soducongno = new Entities.SoDuCongNo[0];
            }
            catch
            {
            }
            finally
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
                i = 0;
                if (bb == null || bb.Length == 0)
                {
                    bb = new Entities.HDBanHang[0];
                    return;
                }
                Entities.HDBanHang[] pt2 = new Entities.HDBanHang[bb.Length];
                int sotang = 0;
                for (int j = 0; j < bb.Length; j++)
                {
                    DateTime hientai = bb[j].NgayBan;
                    if (bb[j].LoaiHoaDon == false && bb[j].Deleted == false && hientai.Date >= Convert.ToDateTime(batdau).Date && hientai.Date < Convert.ToDateTime(ketthuc).Date)
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
            catch
            {
            }
            finally
            {


            }
        }
        /// <summary>
        /// select khách hàng
        /// </summary>
        public void SelectKhachHang()
        {
            try
            {
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
            catch
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
                if (khtl == null || khtl.Length == 0)
                {
                    khtl = new Entities.KhachHangTraLai[0];
                    return;
                }

                Entities.KhachHangTraLai[] pt2 = new Entities.KhachHangTraLai[khtl.Length];
                int sotang = 0;
                for (int j = 0; j < khtl.Length; j++)
                {
                    DateTime hientai = khtl[j].NgayNhap;
                    if (khtl[j].Deleted == false && hientai.Date >= Convert.ToDateTime(batdau).Date && hientai.Date < Convert.ToDateTime(ketthuc).Date)
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
            catch (Exception ex)
            {

            }
            finally
            {


            }
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
                    DateTime hientai = phieuttcuakh[j].NgayLap;

                    if (phieuttcuakh[j].Deleted == false && hientai.Date >= Convert.ToDateTime(batdau).Date && hientai.Date < Convert.ToDateTime(ketthuc).Date)
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
            catch
            {
            }
            finally
            {


            }
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
            catch
            {
            }
            finally
            {


            }
        }
        /// <summary>
        /// fix dtgv
        /// </summary>
        public void fix()
        {
            for (int i = 0; i < dtgvhienthi.ColumnCount; i++)
            {
                dtgvhienthi.Columns[i].Visible = false;
            }
            new Common.Utilities().CountDatagridview(dtgvhienthi);
            dtgvhienthi.ReadOnly = true;
            dtgvhienthi.Columns["HanhDong"].Visible = true;
            dtgvhienthi.Columns["MaDoiTuong"].Visible = true;
            dtgvhienthi.Columns["TenDoiTuong"].Visible = true;
            dtgvhienthi.Columns["DuDauKy"].Visible = true;
            dtgvhienthi.Columns["PhatSinhNo"].Visible = true;
            dtgvhienthi.Columns["PhatSinhCo"].Visible = true;
            dtgvhienthi.Columns["DuCuoiKy"].Visible = true;
            dtgvhienthi.Columns["DiaChi"].Visible = true;
            dtgvhienthi.Columns["HanhDong"].HeaderText = "STT";
            dtgvhienthi.Columns["MaDoiTuong"].HeaderText = "Mã Đối Tượng";
            dtgvhienthi.Columns["TenDoiTuong"].HeaderText = "Tên Đối Tượng";
            dtgvhienthi.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dtgvhienthi.Columns["DuDauKy"].HeaderText = "Dư đầu kỳ";
            dtgvhienthi.Columns["PhatSinhNo"].HeaderText = "Phát sinh nợ";
            dtgvhienthi.Columns["PhatSinhCo"].HeaderText = "Phát sinh có";
            dtgvhienthi.Columns["DuCuoiKy"].HeaderText = "Dư cuối kỳ";
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.AllowUserToAddRows = false;
            dtgvhienthi.AllowUserToDeleteRows = false;
            dtgvhienthi.AllowUserToResizeRows = false;
            dtgvhienthi.RowHeadersVisible = false;
            this.Focus();
        }

        /// <summary>
        /// hiển thị tổng
        /// </summary>

        public void HienThiTong(DateTime batdau, DateTime ketthuc)
        {
            double phatsinhno = 0;
            double phatsinhco = 0;
            double sdck = 0;
            double sddk = 0;
            try
            {

                SelectData();


                congnokh = new List<Entities.CongNo>();
                hienthi = new List<Entities.CongNo>();

                int soluong = 0;
                int soluongkh = 0;
                sdck = sddk = 0;
                // Khách Hàng
                for (int i = 0; i < kh.Length; i++)
                {
                    phatsinhco = 0;
                    phatsinhno = 0;
                    sdck = sddk = 0;
                    for (int j = 0; j < soducongno.Length; j++)
                    {
                        if (soducongno[j].MaDoiTuong == kh[i].MaKH && soducongno[j].NgayKetChuyen.Month == batdau.Month && soducongno[j].NgayKetChuyen.Year == batdau.Year)
                        {
                            sddk = Double.Parse(soducongno[j].SoDuDauKy);
                            break;
                        }
                    }
                    // bán buôn
                    for (int j = 0; j < bb.Length; j++)
                    {
                        if (bb[j].MaKhachHang == kh[i].MaKH && bb[j].NgayBan.Date >= batdau.Date && bb[j].NgayBan.Date <= ketthuc.Date)
                        {
                            phatsinhno += Convert.ToDouble(bb[j].TongTienThanhToan);
                            phatsinhco += Convert.ToDouble(bb[j].ThanhToanKhiLapPhieu);
                        }
                    }

                    // Phieu thu
                    for (int j = 0; j < phieuThuChi.Length; j++)
                    {
                        try
                        {
                            if (phieuThuChi[j].DoiTuong.Equals(kh[i].MaKH) && phieuThuChi[j].LoaiPhieu.ToUpper().Equals("Thu".ToUpper()) && phieuThuChi[j].Deleted == false && phieuThuChi[j].NgayLap.Date >= batdau.Date && phieuThuChi[j].NgayLap.Date <= ketthuc.Date)
                            {
                                phatsinhco += double.Parse(phieuThuChi[j].TongTienThanhToan);
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

                            if (phieuThuChi[j].DoiTuong.Equals(kh[i].MaKH) && phieuThuChi[j].LoaiPhieu.ToUpper().Equals("Chi".ToUpper()) && phieuThuChi[j].Deleted == false && phieuThuChi[j].NgayLap.Date >= batdau.Date && phieuThuChi[j].NgayLap.Date <= ketthuc.Date)
                            {
                                phatsinhno += double.Parse(phieuThuChi[j].TongTienThanhToan);

                            }
                        }
                        catch (Exception)
                        { }
                    }

                    // khách hàng trả lại
                    for (int j = 0; j < khtl.Length; j++)
                    {
                        if (khtl[j].MaKhachHang == kh[i].MaKH && khtl[j].NgayNhap.Date >= batdau.Date && khtl[j].NgayNhap.Date <= ketthuc.Date)
                        {
                            phatsinhco += Convert.ToDouble(khtl[j].TienBoiThuong);
                            phatsinhno += double.Parse(khtl[j].ThanhToanNgay);
                        }
                    }
                    // phiếu thanh toán của khách hàng
                    for (int j = 0; j < phieuttcuakh.Length; j++)
                    {
                        if (phieuttcuakh[j].MaKhachHang == kh[i].MaKH && phieuttcuakh[j].NgayLap.Date >= batdau.Date && phieuttcuakh[j].NgayLap.Date <= ketthuc.Date)
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
                        }
                    }
                    sdck = sddk + phatsinhno - phatsinhco;
                    Entities.CongNo cn = new Entities.CongNo(kh[i].MaKH, kh[i].Ten, kh[i].DiaChi, Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck));
                    congnokh.Add(cn);
                }

                sddk = sdck = phatsinhno = phatsinhco = 0;
                // tính toán của mảng khách hàng
                Entities.CongNo cnKH = new Entities.CongNo();
                int count = congnokh.ToArray().Length;
                if (count == 1)
                {
                    for (int i = 0; i < count; i++)
                    {
                        sdck = sddk + phatsinhno - phatsinhco;
                        cnKH = new Entities.CongNo("Tổng cộng", Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck), string.Empty);
                    }

                    congnokh.Add(cnKH);
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        sddk += Convert.ToDouble(congnokh[i].DuDauKy);
                        phatsinhco += Convert.ToDouble(congnokh[i].PhatSinhCo);
                        phatsinhno += Convert.ToDouble(congnokh[i].PhatSinhNo);
                        sdck = sddk + phatsinhno - phatsinhco;
                        cnKH = new Entities.CongNo("Tổng cộng", Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck), string.Empty);
                    }

                    congnokh.Add(cnKH);
                }

                foreach (Entities.CongNo item in congnokh)
                {
                    if (!string.IsNullOrEmpty(item.MaDoiTuong))
                        hienthi.Add(item);
                }

                dtgvhienthi.DataSource = congnokh;
                if (hienthi.ToArray().Length > 1)
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
                }
                else
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
                }
                dtgvhienthi.Rows[dtgvhienthi.RowCount - 1].DefaultCellStyle.Font = new Font(dtgvhienthi.DefaultCellStyle.Font, FontStyle.Bold);
            }
            catch
            {
            }
            finally
            {
                fix();
            }
        }
        Entities.CongNo[] sdcn1;
        /// <summary>
        /// định dạng dữ liệu
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public string Format(double a)
        {
            return new Common.Utilities().FormatMoney(a);
        }

        int i = 0;
        private void dtgvhienthi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvhienthi.RowCount > 1)
            {
                try
                {
                    frmBaoCaorpt a = new frmBaoCaorpt("KhachHang");
                    a.ShowDialog();
                }
                catch
                {
                }
            }

        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            if (dtgvhienthi.RowCount > 1)
            {
                try
                {
                    frmBaoCaorpt a = new frmBaoCaorpt("KhachHang");
                    a.ShowDialog();
                }
                catch
                {
                }
            }
        }

        private void frmBCCongNoKhachHang_Load(object sender, EventArgs e)
        {
            HienThiTong(truoc, sau);
            this.Focus();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                frmLocDieuKien a = new frmLocDieuKien();
                a.ShowDialog();
                if (frmLocDieuKien.truoc != "" && frmLocDieuKien.sau != "")
                {
                    this.batdau = frmLocDieuKien.truoc;
                    this.ketthuc = frmLocDieuKien.sau;
                    truoc = Convert.ToDateTime(batdau);
                    sau = Convert.ToDateTime(ketthuc);
                    HienThiTong(truoc, sau);
                    frmLocDieuKien.truoc = frmLocDieuKien.sau = "";

                }
            }
            catch
            {
            }
        }

        private void tsslexcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "Excel |*.xls";
                saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt("KhachHang", saveFileDialog1.FileName, "Excel");
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
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "Word |*.doc";
                saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt("KhachHang", saveFileDialog1.FileName, "Word");
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
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "PDF |*.pdf";
                saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    frmBaoCaorpt a = new frmBaoCaorpt("KhachHang", saveFileDialog1.FileName, "PDF");
                }
            }
            catch
            {
            }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                SelectData();
                HienThiTong(truoc, sau); this.Focus();
            }
            catch
            {
            }
            this.Enabled = true;
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbtimkiem3.Checked == true)
                {
                    return;
                }
                if (txttimkiem.Text.Length == 0)
                {
                    dtgvhienthi.DataSource = new Entities.CongNo[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtimkiem1.Checked == true)
                    {
                        for (int i = 0; i < hienthi.ToArray().Length; i++)
                        {
                            int kiemtra = hienthi[i].MaDoiTuong.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.CongNo[0];
                            return;
                        }
                        Entities.CongNo[] hienthitheoid = new Entities.CongNo[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.ToArray().Length; i++)
                        {
                            int kiemtra = hienthi[i].MaDoiTuong.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dtgvhienthi.DataSource = hienthitheoid;
                    }
                    if (rdbtimkiem2.Checked == true)
                    {
                        for (int i = 0; i < hienthi.ToArray().Length; i++)
                        {
                            int kiemtra = hienthi[i].TenDoiTuong.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.CongNo[0];
                            return;
                        }
                        Entities.CongNo[] hienthitheoma = new Entities.CongNo[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.ToArray().Length; i++)
                        {
                            int kiemtra = hienthi[i].TenDoiTuong.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dtgvhienthi.DataSource = hienthitheoma;

                    }
                    if (dtgvhienthi.RowCount > 0)
                    {
                        tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
                    }
                    else
                    {
                        tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
                    }
                }
            }
            finally
            {
                fix();
            }
        }

        private void rdbtimkiem3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtimkiem3.Checked)
            {
                SelectData();
                HienThiTong(truoc, sau);
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
