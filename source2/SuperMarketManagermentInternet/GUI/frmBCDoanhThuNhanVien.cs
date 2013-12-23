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
    public partial class frmBCDoanhThuTheoNhanVien : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        DateTime datesv;
        public frmBCDoanhThuTheoNhanVien()
        {
            try
            {
                InitializeComponent();
                SelectDTNhanVien();
                SelectNhanVien();
                datesv = DateServer.Date();
                cbbnam.Text = datesv.Year.ToString();
                cbbthang.Text = datesv.Month.ToString();
                cbbngay.Text = datesv.Day.ToString();

                batdau = Convert.ToDateTime(cbbthang.Text + "/" + cbbngay.Text + "/" + cbbnam.Text).ToShortDateString();
                ketthuc = batdau;
                truoc = Convert.ToDateTime(batdau);
                sau = Convert.ToDateTime(ketthuc);
                TongTienNhanVien(truoc, sau);
                fix();
            }
            catch
            {
            }

        }
        Entities.BCDTTheoNhanVien[] bcnv;
        public void SelectDTNhanVien()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.BCDTTheoNhanVien ctxh = new Entities.BCDTTheoNhanVien("Select");
                clientstrem = cl.SerializeObj(this.client1, "BCDTTheoNhanVien", ctxh);
                bcnv = (Entities.BCDTTheoNhanVien[])cl.DeserializeHepper1(clientstrem, bcnv);
                if (bcnv == null)
                {
                    bcnv = new Entities.BCDTTheoNhanVien[0];
                    return;
                }
            }
            catch
            {
            }
        }
        Entities.NhanVien[] nv;
        public void SelectNhanVien()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.NhanVien ctxh = new Entities.NhanVien("Select");
                clientstrem = cl.SerializeObj(this.client1, "NhanVien", ctxh);
                nv = (Entities.NhanVien[])cl.DeserializeHepper1(clientstrem, nv);
                if (nv == null)
                {
                    nv = new Entities.NhanVien[0];
                    return;
                }
            }
            catch
            {
            }
        }
        Entities.BCDTTheoNhanVien[] hienthi;
        public void TongTienNhanVien(DateTime batdau, DateTime ketthuc)
        {
            try
            {
                int sotang = 0;
                for (int i = 0; i < nv.Length; i++)
                {
                    for (int j = 0; j < bcnv.Length; j++)
                    {
                        DateTime hientai = bcnv[j].NgayBan;
                        if (hientai.Date >= batdau.Date && hientai.Date <= ketthuc.Date && bcnv[j].MaNhanVien == nv[i].MaNhanVien)
                        {
                            sotang++;
                        }
                    }
                }
                Entities.BCDTTheoNhanVien[] bcdt = new Entities.BCDTTheoNhanVien[sotang];
                sotang = 0;
                double tongtien;
                for (int i = 0; i < nv.Length; i++)
                {
                    tongtien = 0;
                    for (int j = 0; j < bcnv.Length; j++)
                    {
                        DateTime hientai = bcnv[j].NgayBan;
                        if (hientai.Date >= batdau.Date && hientai.Date <= ketthuc.Date && bcnv[j].MaNhanVien == nv[i].MaNhanVien)
                        {
                            List<double> bientam = TienIch.TinhDoanhThu(bcnv[j].TongTienThanhToan, bcnv[j].GiaTriThe, bcnv[j].GiaTriTheGiaTri);
                            tongtien +=  bientam[3];  //bcnv[j].ThanhToanNgay
                        }
                    }
                    if (tongtien != 0)
                    {
                        bcdt[sotang] = new Entities.BCDTTheoNhanVien("", nv[i].MaNhanVien, nv[i].TenNhanVien, new Common.Utilities().FormatMoney(tongtien));
                        sotang++;
                    }
                }
                hienthi = new Entities.BCDTTheoNhanVien[sotang];
                for (int i = 0; i < hienthi.Length; i++)
                {
                    hienthi[i] = bcdt[i];
                }
                //////////////////////////////////////////////Mrk FIX
                List<Entities.BCDTTheoNhanVien> tem0 = new List<Entities.BCDTTheoNhanVien>();
                double tong0 = 0;
                for (int i = 0; i < bcdt.Length; i++)
                {
                    if (bcdt[i] == null)
                    {
                        break;
                    }
                    tong0 += double.Parse(bcdt[i].TongTien.Replace(",", ""));
                    tem0.Add(bcdt[i]);
                }
                Entities.BCDTTheoNhanVien tem1 = new Entities.BCDTTheoNhanVien();
                tem1.TongTien = new Common.Utilities().FormatMoney(tong0);
                tem1.TenNhanVien = "Tổng Cộng: ";
                tem0.Add(tem1);
                //foreach (Entities.BCDTTheoNhanVien item in tem0)
                //{
                //    hienthi[i] = item;
                //}
                //////////////////////////////////////////////////////
                //dtgvhienthi.DataSource = hienthi;
                if (tem0.Count == 1 && tem0[0].TenNhanVien.Equals("Tổng Cộng: "))
                {
                    //tem0.Remove(tem0[0]);
                    tem0 = new List<Entities.BCDTTheoNhanVien>();
                }
                else if (tem0.Count > 1)
                {
                    foreach (Entities.BCDTTheoNhanVien item in tem0)
                    {
                        if (item.TenNhanVien.Equals("Tổng Cộng: "))
                        {
                            item.GiaTriThe = 0;
                        }
                    }
                }
                dtgvhienthi.DataSource = tem0.ToArray();
                if (bcdt.Length > 0)
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
                }
                else
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
                }
                fix();
            }
            catch
            {
            }
        }

        public void fix()
        {
            try
            {
                for (int j = 0; j < dtgvhienthi.ColumnCount; j++)
                {
                    dtgvhienthi.Columns[j].Visible = false;
                }
                new Common.Utilities().CountDatagridview(dtgvhienthi);
                dtgvhienthi.ReadOnly = true;
                dtgvhienthi.RowHeadersVisible = false;
                dtgvhienthi.Columns["GiaTriThe"].Visible = true;
                dtgvhienthi.Columns["GiaTriThe"].HeaderText = "STT";
                dtgvhienthi.Columns["MaNhanVien"].Visible = true;
                dtgvhienthi.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                dtgvhienthi.Columns["TenNhanVien"].Visible = true;
                dtgvhienthi.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
                dtgvhienthi.Columns["TongTien"].Visible = true;
                dtgvhienthi.Columns["TongTien"].HeaderText = "Tổng Tiền";
                dtgvhienthi.Columns["TongTienThanhToan"].Visible = false;
                dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvhienthi.AllowUserToAddRows = false;
                dtgvhienthi.AllowUserToDeleteRows = false;
                dtgvhienthi.AllowUserToResizeRows = false;
                this.Focus();
            }
            catch { }
        }
        string batdau = "";
        string ketthuc = "";
        DateTime truoc;
        DateTime sau;
        private void btnhienthi_Click(object sender, EventArgs e)
        {

            try
            {
                try
                {
                    batdau = Convert.ToDateTime(cbbthang.Text + "/" + cbbngay.Text + "/" + cbbnam.Text).ToShortDateString();
                }
                catch
                {
                    MessageBox.Show("Không tồn tại ngày này trong tháng này", "Hệ thống cảnh báo");
                    return;
                }
                ketthuc = batdau;
                truoc = Convert.ToDateTime(batdau);
                sau = Convert.ToDateTime(ketthuc);
                TongTienNhanVien(truoc, sau);
            }
            catch
            {
            }
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

        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                if (dtgvhienthi.Rows[i].Cells["TenNhanVien"].Value.ToString().Equals("Tổng Cộng: "))
                {
                    return;
                }
                frmBaoCaorpt a = new frmBaoCaorpt("NhanVien", dtgvhienthi.Rows[i].Cells["MaNhanVien"].Value.ToString(), truoc, sau);
                a.ShowDialog();
            }
            catch { }
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                frmBaoCaorpt a = new frmBaoCaorpt("NhanVien", dtgvhienthi.Rows[i].Cells["MaNhanVien"].Value.ToString(), truoc, sau);
                a.ShowDialog();
            }
            catch
            {
            }
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (i < 0)
                        return;
                    frmBaoCaorpt a = new frmBaoCaorpt("NhanVien", dtgvhienthi.Rows[i].Cells["MaNhanVien"].Value.ToString(), truoc, sau, saveFileDialog1.FileName, "PDF");
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
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt("NhanVien", dtgvhienthi.Rows[i].Cells["MaNhanVien"].Value.ToString(), truoc, sau, saveFileDialog1.FileName, "Word");
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
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt("NhanVien", dtgvhienthi.Rows[i].Cells["MaNhanVien"].Value.ToString(), truoc, sau, saveFileDialog1.FileName, "Excel");
                }
            }
            catch
            {
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                SelectDTNhanVien();
                SelectNhanVien();
                batdau = Convert.ToDateTime(cbbthang.Text + "/" + cbbngay.Text + "/" + cbbnam.Text).ToShortDateString();
                ketthuc = batdau;
                truoc = Convert.ToDateTime(batdau);
                sau = Convert.ToDateTime(ketthuc);
                TongTienNhanVien(truoc, sau);
                fix(); this.Focus();
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
                    dtgvhienthi.DataSource = new Entities.BCDTTheoNhanVien[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtimkiem1.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaNhanVien.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCDTTheoNhanVien[0];
                            return;
                        }
                        Entities.BCDTTheoNhanVien[] hienthitheoid = new Entities.BCDTTheoNhanVien[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaNhanVien.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
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
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenNhanVien.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCDTTheoNhanVien[0];
                            return;
                        }
                        Entities.BCDTTheoNhanVien[] hienthitheoma = new Entities.BCDTTheoNhanVien[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenNhanVien.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
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
            try
            {
                if (hienthi == null)
                {
                    dtgvhienthi.DataSource = new Entities.BCDTTheoNhanVien[0];
                    return;
                }
                dtgvhienthi.DataSource = hienthi;
                if (dtgvhienthi.RowCount > 0)
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
                }
                else
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
                }
            }
            catch
            {
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
    }
}
