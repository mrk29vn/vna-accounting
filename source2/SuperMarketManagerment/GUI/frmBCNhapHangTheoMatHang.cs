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
    public partial class frmBCNhapHangTheoMatHang : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        int nam = 0;
        int thang = 0;
        DateTime datesv;
        public frmBCNhapHangTheoMatHang()
        {
            try
            {
                InitializeComponent();datesv = DateServer.Date();
                nam = datesv.Year;
                thang = datesv.Month;
                cbbthang.Text = thang.ToString();
                cbbnam.Text = nam.ToString();

                HoaDonNhap();
                ChiTietHoaDonNhap();

                KhachHangTraLai();
                ChiTietKhachHangTraLai();
                HangHoa();
                GoiHang();
                ChiTietGoiHang();
                PhieuDieuChuyenKhoNoiBo();
                ChiTietPhieuDieuChuyenKho();

                NhapHangTheoMatHang();
            }
            catch
            {
            }

        }



        #region Lấy DL
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
        ////////////////////////////////////////////

        Entities.HoaDonNhap[] hoadonnhap;
        public void HoaDonNhap()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("HDN");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                hoadonnhap = (Entities.HoaDonNhap[])cl.DeserializeHepper1(clientstrem, hoadonnhap);
                if (hoadonnhap == null)
                {
                    hoadonnhap = new Entities.HoaDonNhap[0];
                    return;
                }
            }
            catch
            {
            }
        }
        Entities.ChiTietHoaDonNhap[] chitiethoadonnhap;
        public void ChiTietHoaDonNhap()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTHDN");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                chitiethoadonnhap = (Entities.ChiTietHoaDonNhap[])cl.DeserializeHepper1(clientstrem, chitiethoadonnhap);
                if (chitiethoadonnhap == null)
                {
                    chitiethoadonnhap = new Entities.ChiTietHoaDonNhap[0];
                    return;
                }
            }
            catch
            {
            }
        }
        Entities.KhachHangTraLai[] khachhangtralai;
        public void KhachHangTraLai()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("KHTL");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                khachhangtralai = (Entities.KhachHangTraLai[])cl.DeserializeHepper1(clientstrem, khachhangtralai);
                if (khachhangtralai == null)
                {
                    khachhangtralai = new Entities.KhachHangTraLai[0];
                    return;
                }
            }
            catch
            {
            }
        }
        Entities.ChiTietKhachHangTraLai[] chitietkhachhangtralai;
        public void ChiTietKhachHangTraLai()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTKHTL");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                chitietkhachhangtralai = (Entities.ChiTietKhachHangTraLai[])cl.DeserializeHepper1(clientstrem, chitietkhachhangtralai);
                if (chitietkhachhangtralai == null)
                {
                    chitietkhachhangtralai = new Entities.ChiTietKhachHangTraLai[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.HangHoa[] hanghoa;
        public void HangHoa()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("HH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                hanghoa = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, hanghoa);
                if (hanghoa == null)
                {
                    hanghoa = new Entities.HangHoa[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.PhieuDieuChuyenKhoNoiBo[] phieudieuchuyenkhonoibo;
        public void PhieuDieuChuyenKhoNoiBo()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("PDCKNB");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                phieudieuchuyenkhonoibo = (Entities.PhieuDieuChuyenKhoNoiBo[])cl.DeserializeHepper1(clientstrem, phieudieuchuyenkhonoibo);
                if (phieudieuchuyenkhonoibo == null)
                {
                    phieudieuchuyenkhonoibo = new Entities.PhieuDieuChuyenKhoNoiBo[0];
                    return;
                }
            }
            catch
            {
            }
        }
        Entities.ChiTietPhieuDieuChuyenKho[] chitietphieudieuchuyenkho;
        public void ChiTietPhieuDieuChuyenKho()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTPDCKNB");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                chitietphieudieuchuyenkho = (Entities.ChiTietPhieuDieuChuyenKho[])cl.DeserializeHepper1(clientstrem, chitietphieudieuchuyenkho);
                if (chitietphieudieuchuyenkho == null)
                {
                    chitietphieudieuchuyenkho = new Entities.ChiTietPhieuDieuChuyenKho[0];
                    return;
                }
            }
            catch
            {
            }
        }
        #endregion
        Entities.BCNhapHangTheoMatHang[] hienthi;
        Entities.ChiTietBCNhapHangTheoMatHang[] hienthibaocao;
        public void NhapHangTheoMatHang()
        {

            ArrayList arr = new ArrayList();
            ArrayList arrChiTiet = new ArrayList();
            int i = 1;
            foreach (Entities.HangHoa item in hanghoa)
            {
                int sl = 0;
                foreach (Entities.HoaDonNhap item1 in hoadonnhap)
                {
                    int laynam = item1.NgayNhap.Year;
                    int laythang = item1.NgayNhap.Month;
                    foreach (Entities.ChiTietHoaDonNhap item2 in chitiethoadonnhap)
                    {
                        if (item1.MaHoaDonNhap == item2.MaHoaDonNhap && nam == laynam && thang == laythang)
                        {
                            if (item.MaHangHoa == item2.MaHangHoa)
                            {
                                sl += item2.SoLuong;
                                arrChiTiet.Add(new Entities.ChiTietBCNhapHangTheoMatHang(item2.MaHangHoa, item.TenHangHoa, item2.SoLuong, item2.MaHoaDonNhap, item1.NgayNhap.ToString("dd/MM/yyyy")));
                            }
                        }
                    }
                }

                foreach (Entities.KhachHangTraLai item1 in khachhangtralai)
                {
                    int laynam = item1.NgayNhap.Year;
                    int laythang = item1.NgayNhap.Month;
                    foreach (Entities.ChiTietKhachHangTraLai item2 in chitietkhachhangtralai)
                    {
                        if (item1.MaKhachHangTraLai == item2.MaKhachHangTraLai && nam == laynam && thang == laythang)
                        {
                            if (item.MaHangHoa == item2.MaHangHoa)
                            {
                                sl += item2.SoLuong;
                                arrChiTiet.Add(new Entities.ChiTietBCNhapHangTheoMatHang(item2.MaHangHoa, item.TenHangHoa, item2.SoLuong, item2.MaKhachHangTraLai, item1.NgayNhap.ToString("dd/MM/yyyy")));
                            }
                            ////////////////////////////////////////////////MRK FIX
                            else
                            { //là gói hàng
                                foreach (Entities.GoiHang gh in goihang)
                                {
                                    foreach (Entities.ChiTietGoiHang ctgh in chitietgoihang)
                                    {
                                        if (gh.MaGoiHang.Equals(ctgh.MaGoiHang) && ctgh.MaGoiHang.Equals(item2.MaHangHoa) && ctgh.MaHangHoa.Equals(item.MaHangHoa))
                                        {
                                            sl += item2.SoLuong * ctgh.SoLuong;
                                            arrChiTiet.Add(new Entities.ChiTietBCNhapHangTheoMatHang(item.MaHangHoa + " (" + item2.MaHangHoa + ")", item.TenHangHoa, item2.SoLuong * ctgh.SoLuong, item2.MaKhachHangTraLai, item1.NgayNhap.ToString("dd/MM/yyyy")));
                                        }
                                    }
                                }
                            }
                            ////////////////////////////////////////////////MRK FIX
                        }
                    }
                }
                foreach (Entities.PhieuDieuChuyenKhoNoiBo item1 in phieudieuchuyenkhonoibo)
                {
                    int laynam = item1.NgayDieuChuyen.Year;
                    int laythang = item1.NgayDieuChuyen.Month;
                    foreach (Entities.ChiTietPhieuDieuChuyenKho item2 in chitietphieudieuchuyenkho)
                    {
                        if (item1.MaPhieuDieuChuyenKho == item2.MaPhieuDieuChuyenKho && nam == laynam && thang == laythang && item1.TenKhoDen.Equals(item.MaKho))
                        {
                            if (item.MaHangHoa == item2.MaHangHoa)
                            {
                                sl += item2.SoLuong;
                                arrChiTiet.Add(new Entities.ChiTietBCNhapHangTheoMatHang(item2.MaHangHoa, item.TenHangHoa, item2.SoLuong, item2.MaPhieuDieuChuyenKho, item1.NgayDieuChuyen.ToString("dd/MM/yyyy")));
                            }
                            ////////////////////////////////////////////////MRK FIX
                            else
                            { //là gói hàng
                                foreach (Entities.GoiHang gh in goihang)
                                {
                                    foreach (Entities.ChiTietGoiHang ctgh in chitietgoihang)
                                    {
                                        if (gh.MaGoiHang.Equals(ctgh.MaGoiHang) && ctgh.MaGoiHang.Equals(item2.MaHangHoa) && ctgh.MaHangHoa.Equals(item.MaHangHoa))
                                        {
                                            sl += item2.SoLuong * ctgh.SoLuong;
                                            arrChiTiet.Add(new Entities.ChiTietBCNhapHangTheoMatHang(item.MaHangHoa + " (" + item2.MaHangHoa + ")", item.TenHangHoa, item2.SoLuong * ctgh.SoLuong, item2.MaPhieuDieuChuyenKho, item1.NgayDieuChuyen.ToString("dd/MM/yyyy")));
                                        }
                                    }
                                }
                            }
                            ////////////////////////////////////////////////MRK FIX
                        }
                    }
                }
                if (sl > 0)
                    arr.Add(new Entities.BCNhapHangTheoMatHang(i, item.MaHangHoa, item.TenHangHoa, sl));
                i++;
            }
            hienthi = (Entities.BCNhapHangTheoMatHang[])arr.ToArray(typeof(Entities.BCNhapHangTheoMatHang));
            hienthibaocao = (Entities.ChiTietBCNhapHangTheoMatHang[])arrChiTiet.ToArray(typeof(Entities.ChiTietBCNhapHangTheoMatHang));
            ///////////////////////////////MRK FIX
            List<Entities.BCNhapHangTheoMatHang> tem0 = new List<Entities.BCNhapHangTheoMatHang>();
            int tong0 = 0;
            foreach (Entities.BCNhapHangTheoMatHang item in hienthi)
            {
                if (item == null)
                {
                    continue;
                }
                tong0 += item.SoLuong;
                tem0.Add(item);
            }
            Entities.BCNhapHangTheoMatHang tem1 = new Entities.BCNhapHangTheoMatHang();
            tem1.TenHangHoa = "Tổng: ";
            tem1.SoLuong = tong0;
            tem0.Add(tem1);
            //////////////////////////////////////
            //dtgvhienthi.DataSource = hienthi;
            dtgvhienthi.DataSource = tem0.ToArray();

            if (hienthi.Length > 0)
            {
                enable();
            }
            else
            {
                disable();
            }
            fix();
        }
        void enable()
        {
            tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
        }
        void disable()
        {
            tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
        }
        public string Format(double a)
        {
            return String.Format("{0:0,0}", a);
        }

        public void fix()
        {
            new Common.Utilities().CountDatagridview(dtgvhienthi);
            dtgvhienthi.ReadOnly = true;
            dtgvhienthi.RowHeadersVisible = false;
            dtgvhienthi.Columns["HanhDong"].HeaderText = "STT";
            dtgvhienthi.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
            dtgvhienthi.Columns["TenHangHoa"].HeaderText = "Tên Hàng Hóa";
            dtgvhienthi.Columns["SoLuong"].HeaderText = "Tổng Số Lượng Nhập";
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.AllowUserToAddRows = false;
            dtgvhienthi.AllowUserToDeleteRows = false;
            dtgvhienthi.AllowUserToResizeRows = false;
            this.Focus();
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
        int i = 0;
        private void dtgvhienthi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        public Entities.ChiTietBCNhapHangTheoMatHang[] ChiTietHang(string mahanghoa)
        {
            try
            {
                ArrayList arr = new ArrayList();
                foreach (Entities.ChiTietBCNhapHangTheoMatHang item in hienthibaocao)
                {
                    if (item.MaHangHoa.Equals(mahanghoa))
                    {
                        arr.Add(item);
                    }
                }
                return (Entities.ChiTietBCNhapHangTheoMatHang[])arr.ToArray(typeof(Entities.ChiTietBCNhapHangTheoMatHang));
            }
            catch
            {
                return new Entities.ChiTietBCNhapHangTheoMatHang[0];
            }
        }

        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                disable();
                string maloaihang = dtgvhienthi["MaHangHoa", i].Value.ToString();
                Report.rptBaoCaoNhapHangTheoMatHang report = new Report.rptBaoCaoNhapHangTheoMatHang();
                report.SetDataSource(ChiTietHang(maloaihang));
                report.SetParameterValue("Ky", thang.ToString() + "-" + nam.ToString());
                report.SetParameterValue("TenBaoCao", "Báo Cáo Nhập Hàng Theo Hàng Hóa");
                frmBaoCaorpt a = new frmBaoCaorpt(report);
                a.ShowDialog();
            }
            catch
            {
            }
            finally
            {
                enable();
            }
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                disable();
                string maloaihang = dtgvhienthi["MaHangHoa", i].Value.ToString();
                Report.rptBaoCaoNhapHangTheoMatHang report = new Report.rptBaoCaoNhapHangTheoMatHang();
                report.SetDataSource(ChiTietHang(maloaihang));
                report.SetParameterValue("Ky", thang.ToString() + "-" + nam.ToString());
                report.SetParameterValue("TenBaoCao", "Báo Cáo Nhập Hàng Theo Hàng Hóa");
                frmBaoCaorpt a = new frmBaoCaorpt(report);
                a.ShowDialog();
            }
            catch
            {
            }
            finally
            {
                enable();
            }
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            try
            {
                nam = int.Parse(cbbnam.Text);
                thang = int.Parse(cbbthang.Text);
                NhapHangTheoMatHang();
                lbtenbaocao.Text = "Báo Cáo Nhập Hàng Theo Hàng Hóa Kỳ " + cbbthang.Text + "/" + cbbnam.Text;
            }
            catch
            {
            }
        }

        private void frmBCXuatNhapTonLoaiHang_Load(object sender, EventArgs e)
        {
            lbtenbaocao.Text = "Báo Cáo Nhập Hàng Theo Hàng Hóa Kỳ " + cbbthang.Text + "/" + cbbnam.Text;
        }
        #region Export report
        private void tsslPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (i < 0)
                    return;
                disable();
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string maloaihang = dtgvhienthi["MaHangHoa", i].Value.ToString();
                    Report.rptBaoCaoNhapHangTheoMatHang report = new Report.rptBaoCaoNhapHangTheoMatHang();
                    report.SetDataSource(ChiTietHang(maloaihang));
                    report.SetParameterValue("Ky", thang.ToString() + "-" + nam.ToString());
                    report.SetParameterValue("TenBaoCao", "Báo Cáo Nhập Hàng Theo Hàng Hóa");
                    frmBaoCaorpt a = new frmBaoCaorpt(report, saveFileDialog1.FileName, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                    a.Dispose();
                }
            }
            catch
            {
            }
            finally
            {
                enable();
            }
        }

        private void tsslWord_Click(object sender, EventArgs e)
        {
            try
            {
                if (i < 0)
                    return;
                disable();
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string maloaihang = dtgvhienthi["MaHangHoa", i].Value.ToString();
                    Report.rptBaoCaoNhapHangTheoMatHang report = new Report.rptBaoCaoNhapHangTheoMatHang();
                    report.SetDataSource(ChiTietHang(maloaihang));
                    report.SetParameterValue("Ky", thang.ToString() + "-" + nam.ToString());
                    report.SetParameterValue("TenBaoCao", "Báo Cáo Nhập Hàng Theo Hàng Hóa");
                    frmBaoCaorpt a = new frmBaoCaorpt(report, saveFileDialog1.FileName, Report.ExportCrystalReport.TypeBC.WordForWindows);
                    a.Dispose();
                }
            }
            catch
            {
            }
            finally
            {
                enable();
            }
        }

        private void tsslexcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (i < 0)
                    return;
                disable();
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string maloaihang = dtgvhienthi["MaHangHoa", i].Value.ToString();
                    Report.rptBaoCaoNhapHangTheoMatHang report = new Report.rptBaoCaoNhapHangTheoMatHang();
                    report.SetDataSource(ChiTietHang(maloaihang));
                    report.SetParameterValue("Ky", thang.ToString() + "-" + nam.ToString());
                    report.SetParameterValue("TenBaoCao", "Báo Cáo Nhập Hàng Theo Hàng Hóa");
                    frmBaoCaorpt a = new frmBaoCaorpt(report, saveFileDialog1.FileName, Report.ExportCrystalReport.TypeBC.Excel);
                    a.Dispose();
                }
            }
            catch
            {
            }
            finally
            {
                enable();
            }
        }
        #endregion
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {

                HoaDonNhap();
                ChiTietHoaDonNhap();

                KhachHangTraLai();
                ChiTietKhachHangTraLai();
                HangHoa();
                PhieuDieuChuyenKhoNoiBo();
                ChiTietPhieuDieuChuyenKho();
                NhapHangTheoMatHang(); this.Focus();
            }
            catch
            {
            }
            this.Enabled = true;
        }

        private void rdbtatca_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtatca.Checked)
            {
                if (hienthi != null)
                {
                    ///////////////////////////////MRK FIX
                    List<Entities.BCNhapHangTheoMatHang> tem0 = new List<Entities.BCNhapHangTheoMatHang>();
                    int tong0 = 0;
                    foreach (Entities.BCNhapHangTheoMatHang item in hienthi)
                    {
                        tong0 += item.SoLuong;
                        tem0.Add(item);
                    }
                    Entities.BCNhapHangTheoMatHang tem1 = new Entities.BCNhapHangTheoMatHang();
                    tem1.TenHangHoa = "Tổng: ";
                    tem1.SoLuong = tong0;
                    tem0.Add(tem1);
                    //////////////////////////////////////
                    //dtgvhienthi.DataSource = hienthi;
                    dtgvhienthi.DataSource = tem0.ToArray();
                }
                else
                {
                    dtgvhienthi.DataSource = new Entities.BCNhapHangTheoMatHang[0];
                }
                dtgvhienthi.Refresh();
                fix();
            }
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {

            if (rdbtatca.Checked || hienthi == null)
                return;
            else if (hienthi.Length == 0)
                return;
            if (txttimkiem.Text.Equals(""))
            {
                dtgvhienthi.DataSource = new Entities.BCNhapHangTheoMatHang[0];
                return;
            }
            ArrayList arr = new ArrayList();
            if (rdbtheomaHH.Checked)
            {
                foreach (Entities.BCNhapHangTheoMatHang item in hienthi)
                {
                    if (item.MaHangHoa.ToLower().IndexOf(txttimkiem.Text.ToLower()) > -1)
                    {
                        arr.Add(item);
                    }
                }
            }
            else if (rdbtheotenHH.Checked)
            {
                foreach (Entities.BCNhapHangTheoMatHang item in hienthi)
                {
                    if (item.TenHangHoa.ToLower().IndexOf(txttimkiem.Text.ToLower()) > -1)
                    {
                        arr.Add(item);
                    }
                }
            }
            if (arr.Count > 0)
            {
                Entities.BCNhapHangTheoMatHang[] temp = new Entities.BCNhapHangTheoMatHang[arr.Count];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = (Entities.BCNhapHangTheoMatHang)arr[i];
                    temp[i].HanhDong = i + 1;
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCNhapHangTheoMatHang> tem0 = new List<Entities.BCNhapHangTheoMatHang>();
                int tong0 = 0;
                foreach (Entities.BCNhapHangTheoMatHang item in temp)
                {
                    tong0 += item.SoLuong;
                    tem0.Add(item);
                }
                Entities.BCNhapHangTheoMatHang tem1 = new Entities.BCNhapHangTheoMatHang();
                tem1.TenHangHoa = "Tổng: ";
                tem1.SoLuong = tong0;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = temp;
                dtgvhienthi.DataSource = tem0.ToArray();

            }
            else
            {
                dtgvhienthi.DataSource = new Entities.BCNhapHangTheoMatHang[0];
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
