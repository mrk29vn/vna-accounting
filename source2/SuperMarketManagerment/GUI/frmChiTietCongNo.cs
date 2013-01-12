using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmChiTietCongNo : Form
    {
        Entities.HDBanHang[] bb1;
        Entities.PhieuThu[] ptc;
        List<Entities.CongNo> congnochitiet;
        Entities.HoaDonNhap[] hdn1;
        Entities.KhachHangTraLai[] khtl1;
        Entities.KhachHang kh1;
        Entities.NhaCungCap ncc1;
        Entities.TraLaiNCC[] tlncc1;
        Entities.PhieuTTCuaKH[] phieuttcuakh1;
        Entities.PhieuTTNCC[] phieuttncc1;
        List<Entities.ChiTietCongNo> list = new List<Entities.ChiTietCongNo>();
        public frmChiTietCongNo(Entities.CongNo[] congnochitietkh, Entities.HDBanHang[] bb1, Entities.PhieuThu[] ptc,
            Entities.KhachHangTraLai[] khtl1, Entities.KhachHang kh, Entities.PhieuTTCuaKH[] phieuttcuakh1, string sddk, string sdck)
        {
            InitializeComponent();
            congnochitiet = new List<Entities.CongNo>();
            this.bb1 = bb1;
            foreach (Entities.CongNo item in congnochitietkh)
            {
                if (!string.IsNullOrEmpty(item.MaDoiTuong))
                    this.congnochitiet.Add(item);
            }

            this.khtl1 = khtl1;
            this.kh1 = kh;
            this.ptc = ptc;
            this.phieuttcuakh1 = phieuttcuakh1;
            lbhienthidiachi.Text = kh1.DiaChi;
            lbhienthima.Text = kh1.MaKH;
            lbhienthiten.Text = kh1.Ten;
            txtducuoiky.Text = sdck;
            txtdudauky.Text = sddk;
            Entities.CongNo cnkh = new Entities.CongNo();

            if (Thu() == 0 && Chi() == 0)
                cnkh = new Entities.CongNo("Tổng Cộng", "", "0", "0", "");
            else if (Thu() == 0 && Chi() != 0)
                cnkh = new Entities.CongNo("Tổng Cộng", "", "0", Format(Chi()), "");
            else if (Thu() != 0 && Chi() == 0)
                cnkh = new Entities.CongNo("Tổng Cộng", "", Format(Thu()), "0", "");
            else if (Thu() != 0 && Chi() != 0)
                cnkh = new Entities.CongNo("Tổng Cộng", "", Format(Thu()), Format(Chi()), "");

            congnochitiet.Add(cnkh);
            dtgvhienthi.DataSource = congnochitiet;
            Ton();
            fixkh();
            list = GetData(dtgvhienthi);
        }

        public frmChiTietCongNo(Entities.CongNo[] congnochitietncc, Entities.PhieuThu[] ptc,
            Entities.HoaDonNhap[] hdn1, Entities.TraLaiNCC[] tlncc1, Entities.NhaCungCap ncc1, Entities.PhieuTTNCC[] phieuttncc1, string sddk, string sdck)
        {
            InitializeComponent();
            congnochitiet = new List<Entities.CongNo>();
            foreach (Entities.CongNo item in congnochitietncc)
            {
                if (!string.IsNullOrEmpty(item.MaDoiTuong))
                    this.congnochitiet.Add(item);
            }

            this.hdn1 = hdn1;
            this.tlncc1 = tlncc1;
            this.ncc1 = ncc1;
            this.ptc = ptc;
            this.phieuttncc1 = phieuttncc1;
            txtducuoiky.Text = sdck;
            txtdudauky.Text = sddk;
            lbma.Text = "Mã nhà cung cấp:";
            lbten.Text = "Tên nhà cung cấp:";
            grbthongtin.Text = "Thông tin nhà cung cấp";
            lbhienthidiachi.Text = ncc1.DiaChi;
            lbhienthima.Text = ncc1.MaNhaCungCap;
            lbhienthiten.Text = ncc1.TenNhaCungCap;
            Entities.CongNo cnNCC = new Entities.CongNo();

            if (Thu() == 0 && Chi() == 0)
                cnNCC = new Entities.CongNo("Tổng Cộng", "", "0", "0", "");
            else if (Thu() == 0 && Chi() != 0)
                cnNCC = new Entities.CongNo("Tổng Cộng", "", "0", Format(Chi()), "");
            else if (Thu() != 0 && Chi() == 0)
                cnNCC = new Entities.CongNo("Tổng Cộng", "", Format(Thu()), "0", "");
            else if (Thu() != 0 && Chi() != 0)
                cnNCC = new Entities.CongNo("Tổng Cộng", "", Format(Thu()), Format(Chi()), "");
            congnochitiet.Add(cnNCC);
            dtgvhienthi.DataSource = congnochitiet;
            TonNCC();
            fixncc();
            list = GetData(dtgvhienthi);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="congNo"></param>
        /// <returns></returns>
        public List<Entities.ChiTietCongNo> GetData(DataGridView dv)
        {
            List<Entities.ChiTietCongNo> list = new List<Entities.ChiTietCongNo>();
            try
            {
                if (dv != null && dv.RowCount > 0)
                {
                    int count = dv.RowCount;
                    for (int i = 0; i < count; i++)
                    {
                        Entities.ChiTietCongNo cn = new Entities.ChiTietCongNo();
                        cn.MaHoaDon = dv["MaTruongNgam", i].Value.ToString();
                        cn.TenHoaDon = dv["TruongNgam", i].Value.ToString();
                        cn.NgayLap = dv["NgayLap", i].Value.ToString();
                        cn.PhatSinhNo = double.Parse(dv["PhatSinhNo", i].Value.ToString());
                        cn.PhatSinhCo = double.Parse(dv["PhatSinhCo", i].Value.ToString());
                        cn.Ton = double.Parse(dv["Ton", i].Value.ToString());
                        cn.GhiChu = dv["GhiChu", i].Value.ToString();
                        if (!string.IsNullOrEmpty(cn.MaHoaDon))
                            list.Add(cn);
                    }
                }
            }
            catch (Exception)
            {

            }

            return list;
        }

        public double Thu()
        {
            double tongthu = 0;
            for (int i = 0; i < congnochitiet.ToArray().Length; i++)
            {
                tongthu += Convert.ToDouble(congnochitiet[i].PhatSinhNo);
            }
            return tongthu;
        }

        public double Chi()
        {
            double tongchi = 0;
            for (int i = 0; i < congnochitiet.ToArray().Length; i++)
            {
                tongchi += Convert.ToDouble(congnochitiet[i].PhatSinhCo);
            }
            return tongchi;
        }
        public void TonNCC()
        {
            double ton = 0;
            for (int i = 0; i < congnochitiet.ToArray().Length - 1; i++)
            {
                ton = Convert.ToDouble(ton) - Convert.ToDouble(congnochitiet[i].PhatSinhNo) + Convert.ToDouble(congnochitiet[i].PhatSinhCo);
                dtgvhienthi["Ton", i].Value = Format(ton);
            }
        }
        public void Ton()
        {
            double ton = 0;
            for (int i = 0; i < congnochitiet.ToArray().Length - 1; i++)
            {
                ton = Convert.ToDouble(ton) + Convert.ToDouble(congnochitiet[i].PhatSinhNo) - Convert.ToDouble(congnochitiet[i].PhatSinhCo);
                dtgvhienthi["Ton", i].Value = Format(ton);
            }
        }
        public void fixncc()
        {
            for (int i = 0; i < dtgvhienthi.ColumnCount; i++)
            {
                dtgvhienthi.Columns[i].Visible = false;
            }

            dtgvhienthi.Columns["MaTruongNgam"].DisplayIndex = 0;
            dtgvhienthi.Columns["TruongNgam"].DisplayIndex = 1;
            dtgvhienthi.Columns["NgayLap"].DisplayIndex = 2;

            dtgvhienthi.Columns["NgayLap"].Visible = true;
            dtgvhienthi.Columns["MaTruongNgam"].Visible = true;
            dtgvhienthi.Columns["TruongNgam"].Visible = true;
            dtgvhienthi.Columns["DiaChi"].Visible = false;
            dtgvhienthi.Columns["GhiChu"].Visible = true;
            dtgvhienthi.Columns["PhatSinhNo"].Visible = true;
            dtgvhienthi.Columns["PhatSinhCo"].Visible = true;
            dtgvhienthi.Columns["GhiChu"].Visible = true;
            dtgvhienthi.Columns["Ton"].Visible = true;
            dtgvhienthi.Columns["NgayLap"].HeaderText = "Ngày";
            dtgvhienthi.Columns["MaTruongNgam"].HeaderText = "Mã Hoá Đơn";
            dtgvhienthi.Columns["TruongNgam"].HeaderText = "Tên Hoá Đơn";
            dtgvhienthi.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dtgvhienthi.Columns["PhatSinhNo"].HeaderText = "Thanh Toán";
            dtgvhienthi.Columns["PhatSinhCo"].HeaderText = "Số Tiền";
            dtgvhienthi.Columns["Ton"].HeaderText = "Còn Lại";
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.AllowUserToAddRows = false;
            dtgvhienthi.AllowUserToDeleteRows = false;
            dtgvhienthi.AllowUserToResizeRows = false;
            dtgvhienthi.RowHeadersVisible = false;
        }

        public void fixkh()
        {
            for (int i = 0; i < dtgvhienthi.ColumnCount; i++)
            {
                dtgvhienthi.Columns[i].Visible = false;
            }
            dtgvhienthi.Columns["MaTruongNgam"].DisplayIndex = 0;
            dtgvhienthi.Columns["TruongNgam"].DisplayIndex = 1;
            dtgvhienthi.Columns["NgayLap"].DisplayIndex = 2;

            dtgvhienthi.Columns["NgayLap"].Visible = true;
            dtgvhienthi.Columns["MaTruongNgam"].Visible = true;
            dtgvhienthi.Columns["TruongNgam"].Visible = true;
            dtgvhienthi.Columns["DiaChi"].Visible = false;
            dtgvhienthi.Columns["GhiChu"].Visible = true;
            dtgvhienthi.Columns["PhatSinhNo"].Visible = true;
            dtgvhienthi.Columns["PhatSinhCo"].Visible = true;
            dtgvhienthi.Columns["GhiChu"].Visible = true;
            dtgvhienthi.Columns["Ton"].Visible = true;
            dtgvhienthi.Columns["NgayLap"].HeaderText = "Ngày";
            dtgvhienthi.Columns["MaTruongNgam"].HeaderText = "Mã Hoá Đơn";
            dtgvhienthi.Columns["TruongNgam"].HeaderText = "Tên Hoá Đơn";
            dtgvhienthi.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dtgvhienthi.Columns["PhatSinhNo"].HeaderText = "Số Tiền";
            dtgvhienthi.Columns["PhatSinhCo"].HeaderText = "Thanh Toán";
            dtgvhienthi.Columns["Ton"].HeaderText = "Còn Lại";
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
            catch
            {
                str = "";
            }
            return str;
        }

        public frmChiTietCongNo()
        {
            InitializeComponent();
        }

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

        private void frmChiTietCongNo_Load(object sender, EventArgs e)
        {
            dtgvhienthi.Rows[dtgvhienthi.RowCount - 1].DefaultCellStyle.Font = new Font(dtgvhienthi.DefaultCellStyle.Font, FontStyle.Bold);
        }
        int i = 0;

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

        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            if (i < 0)
                return;
            try
            {
                bool kt = true;
                string objname = congnochitiet[i].TruongNgam;
                string madoituong = congnochitiet[i].MaTruongNgam;
                switch (objname)
                {
                    case "BanBuon":
                        {
                            kt = false;
                            dtgvngam.DataSource = bb1;
                            int so = 0;
                            for (int j = 0; j < bb1.Length; j++)
                            {
                                if (bb1[j].MaHDBanHang == madoituong)
                                {
                                    so = j; kt = true;
                                    break;
                                }
                            }
                            if (kt == true)
                            {
                                frmXuLyBanBuon b = new frmXuLyBanBuon("Sua", dtgvngam.Rows[so]);
                                b.ShowDialog();
                            }
                            break;
                        }
                    case "Thu":
                        {
                            dtgvngam.DataSource = ptc;
                            kt = false;
                            int so = 0;
                            for (int j = 0; j < ptc.Length; j++)
                            {
                                if (ptc[j].MaPhieuThu == madoituong)
                                {
                                    so = j;
                                    kt = true;
                                    break;
                                }
                            } if (kt == true)
                            {
                                frmXuLyPhieuThuChi tmptc = new frmXuLyPhieuThuChi("Thu", "Sua", dtgvngam.Rows[so]);
                                tmptc.ShowDialog();
                            }
                            break;
                        }

                    case "Chi":
                        {
                            dtgvngam.DataSource = ptc;
                            kt = false;
                            int so = 0;
                            for (int j = 0; j < ptc.Length; j++)
                            {
                                if (ptc[j].MaPhieuThu == madoituong)
                                {
                                    so = j;
                                    kt = true;
                                    break;
                                }
                            } if (kt == true)
                            {
                                frmXuLyPhieuThuChi tmptc = new frmXuLyPhieuThuChi("Chi", "Sua", dtgvngam.Rows[so]);
                                tmptc.ShowDialog();
                            }
                            break;
                        }

                    case "KHTL":
                        {
                            kt = false;
                            int so = 0;
                            for (int j = 0; j < khtl1.Length; j++)
                            {
                                if (khtl1[j].MaKhachHangTraLai == madoituong)
                                {
                                    so = j;
                                    kt = true;
                                    break;
                                }
                            } if (kt == true)
                            {
                                frmXuLyHangTraLai b = new frmXuLyHangTraLai("Sua_KhachHangTraLai", "KhachHangTraLai", "Update", khtl1[so]);
                                b.ShowDialog();
                            }
                            break;
                        }
                    case "HoaDonNhap":
                        {
                            kt = false;
                            int so = 0;
                            for (int j = 0; j < hdn1.Length; j++)
                            {
                                if (hdn1[j].MaHoaDonNhap == madoituong)
                                {
                                    so = j;
                                    kt = true;
                                    break;
                                }
                            }
                            if (kt == true)
                            {
                                frmXuLyNhapKho b = new frmXuLyNhapKho("Update", hdn1[so]);
                                b.ShowDialog();
                            }
                            break;
                        }
                    case "TLNCC":
                        {
                            kt = false;
                            int so = 0;
                            for (int j = 0; j < tlncc1.Length; j++)
                            {
                                if (tlncc1[j].MaHDTraLaiNCC == madoituong)
                                {
                                    so = j;
                                    kt = true;
                                    break;
                                }
                            }
                            if (kt == true)
                            {
                                frmXuLyHangTraLai b = new frmXuLyHangTraLai("Sua_TraLaiNhaCungCap", "TraLaiNhaCungCap", "Update", tlncc1[so]);
                                b.ShowDialog();
                            }
                            break;
                        }
                    case "PhieuTTCuaKH":
                        {
                            kt = false;
                            dtgvngam.DataSource = phieuttcuakh1;
                            int so = 0;
                            for (int j = 0; j < phieuttcuakh1.Length; j++)
                            {
                                if (phieuttcuakh1[j].MaPhieuTTCuaKH == madoituong)
                                {
                                    so = j; kt = true;
                                    break;
                                }
                            }
                            if (kt == true)
                            {
                                frmXuLyPhieuTTCuaKH b = new frmXuLyPhieuTTCuaKH("Sua", dtgvngam.Rows[so]);
                                b.ShowDialog();
                            }
                            break;
                        }
                    case "PhieuTTNCC":
                        {
                            kt = false;
                            dtgvngam.DataSource = phieuttncc1;
                            int so = 0;
                            for (int j = 0; j < phieuttncc1.Length; j++)
                            {
                                if (phieuttncc1[j].MaPhieuTTNCC == madoituong)
                                {
                                    so = j; kt = true;
                                    break;
                                }
                            }
                            if (kt == true)
                            {
                                frmXuLyPhieuTTNCC b = new frmXuLyPhieuTTNCC("Sua", dtgvngam.Rows[so]);
                                b.ShowDialog();
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
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
                // Khach hang
                if (kh1 != null)
                {
                    string maKhachHang = kh1.MaKH;
                    string tenKhachHang = kh1.Ten;
                    string diaChi = kh1.DiaChi;
                    double duDauKy = double.Parse(txtdudauky.Text);
                    double duCuoiKy = double.Parse(txtducuoiky.Text);
                    frmBaoCaorpt a = new frmBaoCaorpt(list.ToArray(), maKhachHang, tenKhachHang, diaChi, duDauKy, duCuoiKy, "In", "", "KH", "Khách Hàng");
                    a.ShowDialog();
                }
                else
                {
                    string maKhachHang = ncc1.MaNhaCungCap;
                    string tenKhachHang = ncc1.TenNhaCungCap;
                    string diaChi = ncc1.DiaChi;
                    double duDauKy = double.Parse(txtdudauky.Text);
                    double duCuoiKy = double.Parse(txtducuoiky.Text);
                    frmBaoCaorpt a = new frmBaoCaorpt(list.ToArray(), maKhachHang, tenKhachHang, diaChi, duDauKy, duCuoiKy, "In", "", "NCC", "Nhà Cung Cấp");
                    a.ShowDialog();
                }
            }
            catch (Exception)
            { }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Khach hang
                    if (kh1 != null)
                    {
                        string maKhachHang = kh1.MaKH;
                        string tenKhachHang = kh1.Ten;
                        string diaChi = kh1.DiaChi;
                        double duDauKy = double.Parse(txtdudauky.Text);
                        double duCuoiKy = double.Parse(txtducuoiky.Text);
                        frmBaoCaorpt a = new frmBaoCaorpt(list.ToArray(), maKhachHang, tenKhachHang, diaChi, duDauKy, duCuoiKy, "Excel", saveFileDialog1.FileName, "KH", "Khách Hàng");

                    }
                    else
                    {
                        string maKhachHang = ncc1.MaNhaCungCap;
                        string tenKhachHang = ncc1.TenNhaCungCap;
                        string diaChi = ncc1.DiaChi;
                        double duDauKy = double.Parse(txtdudauky.Text);
                        double duCuoiKy = double.Parse(txtducuoiky.Text);
                        frmBaoCaorpt a = new frmBaoCaorpt(list.ToArray(), maKhachHang, tenKhachHang, diaChi, duDauKy, duCuoiKy, "Excel", saveFileDialog1.FileName, "NCC", "Nhà Cung Cấp");

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
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Khach hang
                    if (kh1 != null)
                    {
                        string maKhachHang = kh1.MaKH;
                        string tenKhachHang = kh1.Ten;
                        string diaChi = kh1.DiaChi;
                        double duDauKy = double.Parse(txtdudauky.Text);
                        double duCuoiKy = double.Parse(txtducuoiky.Text);
                        frmBaoCaorpt a = new frmBaoCaorpt(list.ToArray(), maKhachHang, tenKhachHang, diaChi, duDauKy, duCuoiKy, "Word", saveFileDialog1.FileName, "KH", "Khách Hàng");

                    }
                    else
                    {
                        string maKhachHang = ncc1.MaNhaCungCap;
                        string tenKhachHang = ncc1.TenNhaCungCap;
                        string diaChi = ncc1.DiaChi;
                        double duDauKy = double.Parse(txtdudauky.Text);
                        double duCuoiKy = double.Parse(txtducuoiky.Text);
                        frmBaoCaorpt a = new frmBaoCaorpt(list.ToArray(), maKhachHang, tenKhachHang, diaChi, duDauKy, duCuoiKy, "Word", saveFileDialog1.FileName, "NCC", "Nhà Cung Cấp");

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
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Khach hang
                    if (kh1 != null)
                    {
                        string maKhachHang = kh1.MaKH;
                        string tenKhachHang = kh1.Ten;
                        string diaChi = kh1.DiaChi;
                        double duDauKy = double.Parse(txtdudauky.Text);
                        double duCuoiKy = double.Parse(txtducuoiky.Text);
                        frmBaoCaorpt a = new frmBaoCaorpt(list.ToArray(), maKhachHang, tenKhachHang, diaChi, duDauKy, duCuoiKy, "PDF", saveFileDialog1.FileName, "KH", "Khách Hàng");

                    }
                    else
                    {
                        string maKhachHang = ncc1.MaNhaCungCap;
                        string tenKhachHang = ncc1.TenNhaCungCap;
                        string diaChi = ncc1.DiaChi;
                        double duDauKy = double.Parse(txtdudauky.Text);
                        double duCuoiKy = double.Parse(txtducuoiky.Text);
                        frmBaoCaorpt a = new frmBaoCaorpt(list.ToArray(), maKhachHang, tenKhachHang, diaChi, duDauKy, duCuoiKy, "PDF", saveFileDialog1.FileName, "NCC", "Nhà Cung Cấp");

                    }
                }
            }
            catch
            {
            }
            finally { this.Enabled = true; }
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
    }
}
