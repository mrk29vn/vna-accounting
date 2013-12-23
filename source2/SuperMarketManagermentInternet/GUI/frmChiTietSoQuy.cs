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
    public partial class frmChiTietSoQuy : Form
    {
        Entities.PhieuThu[] pt;
        Entities.PhieuThu[] pc;
        Entities.HDBanHang[] bb;
        Entities.HDBanHang[] bl;
        Entities.HoaDonNhap[] hdn;
        Entities.TraLaiNCC[] tl;
        Entities.SoQuy[] soquy;
        Entities.KhachHangTraLai[] kh;
        public frmChiTietSoQuy(Entities.SoQuy[] soquy, Entities.PhieuThu[] pt, Entities.PhieuThu[] pc, Entities.HDBanHang[] bl,
            Entities.HDBanHang[] bb, Entities.HoaDonNhap[] hdn, Entities.KhachHangTraLai[] kh, Entities.TraLaiNCC[] tl, string dudauky, string ducuoiky)
        {
            InitializeComponent();
            this.pt = pt;
            this.pc = pc;
            this.bb = bb;
            this.bl = bl;
            this.kh = kh;
            this.hdn = hdn;
            this.tl = tl;
            this.soquy = soquy;
            List<Entities.SoQuy> lHienThi = new List<Entities.SoQuy>();
            lHienThi = this.soquy.ToList();
            txtducuoiky.Text = Format(double.Parse(ducuoiky));
            txtdudauky.Text = Format(double.Parse(dudauky));

            if (Thu() == 0 && Chi() == 0)
            {
                lHienThi.Add(new Entities.SoQuy("0", "0", "Tổng Cộng"));
                //soquy[soquy.Length - 1] = new Entities.SoQuy("0", "0", "Tổng Cộng");
            }
            else if (Thu() == 0 && Chi() != 0)
            {
                lHienThi.Add(new Entities.SoQuy("0", Format(Chi()), "Tổng Cộng"));
                //soquy[soquy.Length - 1] = new Entities.SoQuy("0", Format(Chi()), "Tổng Cộng");
            }
            else if (Thu() != 0 && Chi() == 0)
            {
                lHienThi.Add(new Entities.SoQuy(Format(Thu()), "0", "Tổng Cộng"));
                //soquy[soquy.Length - 1] = new Entities.SoQuy(Format(Thu()), "0", "Tổng Cộng");
            }
            else if (Thu() != 0 && Chi() != 0)
            {
                lHienThi.Add(new Entities.SoQuy(Format(Thu()), Format(Chi()), "Tổng Cộng"));
                //soquy[soquy.Length - 1] = new Entities.SoQuy(Format(Thu()), Format(Chi()), "Tổng Cộng");
            }

            dtgvhienthi.DataSource = lHienThi.ToArray();
            Ton();
            fix();
        }

        public double Thu()
        {
            double tongthu = 0;
            for (int i = 0; i < soquy.Length; i++)
            {
                tongthu += Convert.ToDouble(soquy[i].PhatSinhNo);
            }
            return tongthu;
        }

        public double Chi()
        {
            double tongchi = 0;
            for (int i = 0; i < soquy.Length; i++)
            {
                tongchi += Convert.ToDouble(soquy[i].PhatSinhCo);
            }
            return tongchi;
        }

        public void Ton()
        {
            double ton = 0;
            for (int i = 0; i < soquy.Length; i++)
            {
                ton = Convert.ToDouble(ton) + Convert.ToDouble(soquy[i].PhatSinhNo) - Convert.ToDouble(soquy[i].PhatSinhCo);
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

        private void frmChiTietSoQuy_Load(object sender, EventArgs e)
        {
            try
            {
                dtgvhienthi.Rows[dtgvhienthi.RowCount - 1].DefaultCellStyle.Font = new Font(dtgvhienthi.DefaultCellStyle.Font, FontStyle.Bold);
            }
            catch { }
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

        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            if (i < 0)
                return;
            try
            {
                string objname = soquy[i].TruongNgam;
                string maphieu = soquy[i].MaPhieu;
                switch (objname)
                {
                    case "PhieuThu":
                        {
                            dtgvngam.DataSource = pt;
                            int so = 0;
                            for (int j = 0; j < pt.Length; j++)
                            {
                                if (pt[j].MaPhieuThu == maphieu)
                                {
                                    so = j;
                                    break;
                                }
                            }

                            frmXuLyPhieuThuChi b = new frmXuLyPhieuThuChi("Thu", "Sua", dtgvngam.Rows[so]);
                            b.ShowDialog();
                            break;
                        }
                    case "PhieuChi":
                        {
                            dtgvngam.DataSource = pc;
                            int so = 0;
                            for (int j = 0; j < pc.Length; j++)
                            {
                                if (pc[j].MaPhieuThu == maphieu)
                                {
                                    so = j;
                                    break;
                                }
                            }

                            frmXuLyPhieuThuChi b = new frmXuLyPhieuThuChi("Thu", "Sua", dtgvngam.Rows[so]);
                            b.ShowDialog();
                            break;
                        }
                    case "BanBuon":
                        {
                            dtgvngam.DataSource = bb;
                            int so = 0;
                            for (int j = 0; j < bb.Length; j++)
                            {
                                if (bb[j].MaHDBanHang == maphieu)
                                {
                                    so = j;
                                    break;
                                }
                            }
                            frmXuLyBanBuon b = new frmXuLyBanBuon("Sua", dtgvngam.Rows[so]);
                            b.ShowDialog();
                            break;
                        }
                    case "BanLe":
                        {
                            dtgvngam.DataSource = bl;
                            int so = 0;
                            for (int j = 0; j < bl.Length; j++)
                            {
                                if (bl[j].MaHDBanHang == maphieu)
                                {
                                    so = j;
                                    break;
                                }
                            }
                            frmXuLyBanLe b = new frmXuLyBanLe("Sua", dtgvngam.Rows[so]);
                            b.ShowDialog();
                            break;
                        }
                    case "HoaDonNhap":
                        {
                            int so = 0;
                            for (int j = 0; j < hdn.Length; j++)
                            {
                                if (hdn[j].MaHoaDonNhap == maphieu)
                                {
                                    so = j;
                                    break;
                                }
                            }
                            frmXuLyNhapKho b = new frmXuLyNhapKho("Update", hdn[so]);
                            b.ShowDialog();
                            break;
                        }
                    case "KHTL":
                        {
                            int so = 0;
                            for (int j = 0; j < kh.Length; j++)
                            {
                                if (kh[j].MaKhachHangTraLai == maphieu)
                                {
                                    so = j;
                                    break;
                                }
                            }
                            frmXuLyHangTraLai b = new frmXuLyHangTraLai("Sua_KhachHangTraLai", "KhachHangTraLai", "Update", kh[so]);
                            b.ShowDialog();
                            break;
                        }
                    case "TLNCC":
                        {
                            int so = 0;
                            for (int j = 0; j < tl.Length; j++)
                            {
                                if (tl[j].MaHDTraLaiNCC == maphieu)
                                {
                                    so = j;
                                    break;
                                }
                            }
                            frmXuLyHangTraLai b = new frmXuLyHangTraLai("Sua_TraLaiNhaCungCap", "TraLaiNhaCungCap", "Update", tl[so]);
                            b.ShowDialog();
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

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            try
            {
                List<Entities.SoQuy> tem0 = ((Entities.SoQuy[])dtgvhienthi.DataSource).ToList();
                tem0.RemoveAt(tem0.Count - 1);
                Entities.SoQuy[] tem = tem0.ToArray();
                if (tem.Length > 0)
                {
                    foreach (Entities.SoQuy item in tem)
                    {
                        item.MaTK = lbhienthima.Text;
                        item.TenTK = lbhienthiten.Text;
                        item.DuDauKy = txtdudauky.Text;
                        item.DuCuoiKy = txtducuoiky.Text;
                    }
                    frmBaoCaorpt a = new frmBaoCaorpt("SoQuy_In", tem, "", false);
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
                List<Entities.SoQuy> tem0 = ((Entities.SoQuy[])dtgvhienthi.DataSource).ToList();
                tem0.RemoveAt(tem0.Count - 1);
                Entities.SoQuy[] tem = tem0.ToArray();
                if (tem.Length > 0)
                {
                    SaveFileDialog s = new SaveFileDialog();
                    s.Filter = "PDF |*.pdf";
                    if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        foreach (Entities.SoQuy item in tem)
                        {
                            item.MaTK = lbhienthima.Text;
                            item.TenTK = lbhienthiten.Text;
                            item.DuDauKy = txtdudauky.Text;
                            item.DuCuoiKy = txtducuoiky.Text;
                        }
                        frmBaoCaorpt a = new frmBaoCaorpt("SoQuy_PDF", tem, s.FileName, false);
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
                List<Entities.SoQuy> tem0 = ((Entities.SoQuy[])dtgvhienthi.DataSource).ToList();
                tem0.RemoveAt(tem0.Count - 1);
                Entities.SoQuy[] tem = tem0.ToArray();
                if (tem.Length > 0)
                {
                    SaveFileDialog s = new SaveFileDialog();
                    s.Filter = "DOC |*.doc";
                    if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        foreach (Entities.SoQuy item in tem)
                        {
                            item.MaTK = lbhienthima.Text;
                            item.TenTK = lbhienthiten.Text;
                            item.DuDauKy = txtdudauky.Text;
                            item.DuCuoiKy = txtducuoiky.Text;
                        }
                        frmBaoCaorpt a = new frmBaoCaorpt("SoQuy_DOC", tem, s.FileName, false);
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
                List<Entities.SoQuy> tem0 = ((Entities.SoQuy[])dtgvhienthi.DataSource).ToList();
                tem0.RemoveAt(tem0.Count - 1);
                Entities.SoQuy[] tem = tem0.ToArray();
                if (tem.Length > 0)
                {
                    SaveFileDialog s = new SaveFileDialog();
                    s.Filter = "XLS |*.xls";
                    if (s.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        foreach (Entities.SoQuy item in tem)
                        {
                            item.MaTK = lbhienthima.Text;
                            item.TenTK = lbhienthiten.Text;
                            item.DuDauKy = txtdudauky.Text;
                            item.DuCuoiKy = txtducuoiky.Text;
                        }
                        frmBaoCaorpt a = new frmBaoCaorpt("SoQuy_XLS", tem, s.FileName, false);
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
    }
}
