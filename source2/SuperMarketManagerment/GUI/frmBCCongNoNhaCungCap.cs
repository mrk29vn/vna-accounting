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
    public partial class frmBCCongNoNhaCungCap : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        DateTime datesv;
        public frmBCCongNoNhaCungCap()
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

        Entities.SelectAll selectall;
        Server_Client.Client cl;
        Entities.NhaCungCap[] ncc;
        List<Entities.CongNo> hienthi;
        List<Entities.CongNo> congnoncc;
        Entities.HoaDonNhap[] hdn;
        Entities.TraLaiNCC[] tl;
        Entities.PhieuThu[] phieuThuChi;
        Entities.SoDuCongNo[] hienthi1;
        Entities.ChiTietPhieuTTNCC[] chitietphieuttncc;
        Entities.PhieuTTNCC[] phieuttncc;
        string maSoDuCongNo = "";
        void SelectData()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("BCCongNoNhaCungCap");
            clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
            selectall = (Entities.SelectAll)cl.DeserializeHepper(clientstrem, selectall);
            hienthi1 = selectall.SoDuCongNo;
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


        public void SelectSoDuCongNo()
        {
            try
            {
                if (hienthi1 == null || hienthi1.Length == 0)
                {
                    hienthi1 = new Entities.SoDuCongNo[0];
                    return;
                }
                int sotang = 0;
                Entities.SoDuCongNo[] sq = new Entities.SoDuCongNo[hienthi1.Length];
                for (int i = 0; i < sq.Length; i++)
                {
                    string namkt = hienthi1[i].NgayKetChuyen.Year.ToString();
                    string thangkt = hienthi1[i].NgayKetChuyen.Month.ToString();

                    if (hienthi1[i].LoaiDoiTuong == true && namkt == datesv.Year.ToString() && thangkt == datesv.Month.ToString())
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
                        hienthi1[i] = new Entities.SoDuCongNo("", sq[i].MaDoiTuong, sq[i].TenDoiTuong, sq[i].DiaChi, sq[i].SoDuDauKy);
                        hienthi1[i].NgayKetChuyen = sq[i].NgayKetChuyen;
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
            catch
            {
            }
            finally
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

                if (hdn == null || hdn.Length == 0)
                {
                    hdn = new Entities.HoaDonNhap[0];
                    return;
                }

                Entities.HoaDonNhap[] pt2 = new Entities.HoaDonNhap[hdn.Length];
                int sotang = 0;
                for (int j = 0; j < hdn.Length; j++)
                {
                    DateTime hientai = hdn[j].NgayNhap;
                    if (hdn[j].Deleted == false && hientai.Date >= Convert.ToDateTime(batdau).Date && hientai.Date < Convert.ToDateTime(ketthuc).Date)
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
                    DateTime hientai = tl[j].Ngaytra;
                    if (tl[j].Deleted == false && hientai.Date >= Convert.ToDateTime(batdau).Date && hientai.Date < Convert.ToDateTime(ketthuc).Date)
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
            catch
            {
            }
            finally
            {


            }
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
                    DateTime hientai = phieuttncc[j].NgayLap;

                    if (phieuttncc[j].Deleted == false && hientai.Date >= Convert.ToDateTime(batdau).Date && hientai.Date < Convert.ToDateTime(ketthuc).Date)
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
            catch
            {
            }
            finally
            {


            }
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
            try
            {
                //SelectData();

                hienthi = new List<Entities.CongNo>();
                congnoncc = new List<Entities.CongNo>();
                int soluong = 0;
                int soluongncc = 0;
                double phatsinhno = 0;
                double phatsinhco = 0;
                double sdck = 0;
                double sddk = 0;

                // Nhà Cung Cấp
                for (int i = 0; i < ncc.Length; i++)
                {
                    phatsinhco = 0;
                    phatsinhno = 0;
                    sdck = sddk = 0;
                    string maSoDuCongNo = "";
                    for (int j = 0; j < hienthi1.Length; j++)
                    {
                        if (hienthi1[j].MaDoiTuong == ncc[i].MaNhaCungCap && hienthi1[j].NgayKetChuyen.Month == batdau.Month && hienthi1[j].NgayKetChuyen.Year == batdau.Year)
                        {
                            maSoDuCongNo = hienthi1[j].MaSoDuCongNo;
                            sddk = Double.Parse(hienthi1[j].SoDuDauKy);
                            break;
                        }
                    }
                    // hóa đơn nhập
                    for (int j = 0; j < hdn.Length; j++)
                    {
                        if (ncc[i].MaNhaCungCap == hdn[j].MaNhaCungCap && hdn[j].NgayNhap.Date >= batdau.Date && hdn[j].NgayNhap.Date <= ketthuc.Date)
                        {
                            phatsinhco += Convert.ToDouble(hdn[j].TongTien);
                            phatsinhno += Convert.ToDouble(hdn[j].ThanhToanNgay);
                        }
                    }


                    // Phieu thu
                    for (int j = 0; j < phieuThuChi.Length; j++)
                    {
                        try
                        {
                            if (phieuThuChi[j].DoiTuong.Equals(ncc[i].MaNhaCungCap) && phieuThuChi[j].LoaiPhieu.ToUpper().Equals("Thu".ToUpper()) && phieuThuChi[j].Deleted == false && phieuThuChi[j].NgayLap.Date >= batdau.Date && phieuThuChi[j].NgayLap.Date <= ketthuc.Date)
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
                            if (phieuThuChi[j].DoiTuong.Equals(ncc[i].MaNhaCungCap) && phieuThuChi[j].LoaiPhieu.ToUpper().Equals("Chi".ToUpper()) && phieuThuChi[j].Deleted == false && phieuThuChi[j].NgayLap.Date >= batdau.Date && phieuThuChi[j].NgayLap.Date <= ketthuc.Date)
                            {
                                phatsinhno += double.Parse(phieuThuChi[j].TongTienThanhToan);
                            }
                        }
                        catch (Exception)
                        { }
                    }

                    // trả lại nhà cung cấp
                    for (int j = 0; j < tl.Length; j++)
                    {
                        if (tl[j].MaNCC == ncc[i].MaNhaCungCap && tl[j].Ngaytra.Date >= batdau.Date && tl[j].Ngaytra.Date <= ketthuc.Date)
                        {
                            phatsinhno += Convert.ToDouble(tl[j].TienBoiThuong);
                            phatsinhco += double.Parse(tl[j].ThanhToanNgay);
                        }
                    }
                    // phiếu thanh toán của nhà cung cấp
                    for (int j = 0; j < phieuttncc.Length; j++)
                    {
                        if (phieuttncc[j].MaNCC == ncc[i].MaNhaCungCap && phieuttncc[j].NgayLap.Date >= batdau.Date && phieuttncc[j].NgayLap.Date <= ketthuc.Date)
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
                        }
                    }
                    sdck = sddk + phatsinhco - phatsinhno;
                    Entities.CongNo cn = new Entities.CongNo(ncc[i].MaNhaCungCap, ncc[i].TenNhaCungCap, ncc[i].DiaChi, Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck));
                    congnoncc.Add(cn);
                }
                sddk = 0;
                sdck = 0;
                phatsinhno = 0;
                phatsinhco = 0;
                // tính toán của mảng nhà cung cấp
                Entities.CongNo cnNCC = new Entities.CongNo();
                int count = congnoncc.ToArray().Length;
                if (count == 1)
                {
                    for (int i = 0; i < count; i++)
                    {
                        sddk = double.Parse(congnoncc[i].DuDauKy);
                        phatsinhno = double.Parse(congnoncc[i].PhatSinhNo);
                        phatsinhco = double.Parse(congnoncc[i].PhatSinhCo);
                        sdck = sddk + phatsinhco - phatsinhno;
                        cnNCC = new Entities.CongNo("Tổng cộng", Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck), string.Empty);
                    }
                    congnoncc.Add(cnNCC);
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        sddk += double.Parse(congnoncc[i].DuDauKy);
                        phatsinhco += Convert.ToDouble(congnoncc[i].PhatSinhCo);
                        phatsinhno += Convert.ToDouble(congnoncc[i].PhatSinhNo);
                        sdck = sddk + phatsinhco - phatsinhno;
                        cnNCC = new Entities.CongNo("Tổng cộng", Format(sddk), Format(phatsinhno), Format(phatsinhco), Format(sdck), string.Empty);
                    }
                    congnoncc.Add(cnNCC);
                }

                foreach (Entities.CongNo item in congnoncc)
                {
                    if (!string.IsNullOrEmpty(item.MaDoiTuong))
                    {
                        hienthi.Add(item);
                    }
                }


                dtgvhienthi.DataSource = congnoncc;
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
                    frmBaoCaorpt a = new frmBaoCaorpt("NCC");
                    a.ShowDialog();
                }
                catch
                {
                }
            }

        }

        /// <summary>
        /// định dạng dữ liệu
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public string Format(double a)
        {
            return new Common.Utilities().FormatMoney(a);
        }

        string batdau = "";
        string ketthuc = "";
        DateTime truoc;
        DateTime sau;
        private void btnhienthi_Click(object sender, EventArgs e)
        {
            try
            {
                batdau = new Common.Utilities().MyDateConversion(datesv.Month.ToString() + "/" + "01/" + datesv.Year.ToString());
                if (datesv.Month.ToString() == "12")
                    ketthuc = new Common.Utilities().MyDateConversion("01/01/" + (Convert.ToInt32(datesv.Year.ToString()) + 1).ToString());
                else
                    ketthuc = new Common.Utilities().MyDateConversion((Convert.ToInt32(datesv.Month.ToString()) + 1).ToString() + "/" + "01/" + datesv.Year.ToString());
                HienThiTong(Convert.ToDateTime(batdau), Convert.ToDateTime(ketthuc));
            }
            catch
            {
            }

        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            if (dtgvhienthi.RowCount > 1)
            {
                try
                {
                    frmBaoCaorpt a = new frmBaoCaorpt("NCC");
                    a.ShowDialog();
                }
                catch
                {
                }
            }
        }

        private void frmBCCongNoNhaCungCap_Load(object sender, EventArgs e)
        {
            SelectData();
            HienThiTong(truoc, sau);
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
                    frmBaoCaorpt a = new frmBaoCaorpt("NCC", saveFileDialog1.FileName, "Excel");
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
                    frmBaoCaorpt a = new frmBaoCaorpt("NCC", saveFileDialog1.FileName, "Word");
                }
            }
            catch
            {
            }
        }

        private void dtgvhienthi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

                    frmBaoCaorpt a = new frmBaoCaorpt("NCC", saveFileDialog1.FileName, "PDF");
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

        private void rdbtimkiem3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtimkiem3.Checked)
            {
                SelectData();
                HienThiTong(truoc, sau);
            }
        }
    }
}
