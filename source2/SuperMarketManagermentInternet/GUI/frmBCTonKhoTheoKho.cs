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
    public partial class frmBCTonKhoTheoKho : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        DateTime datesv;

        public frmBCTonKhoTheoKho()
        {
            InitializeComponent();datesv = DateServer.Date();
            KhoHang();
            TonKho();
            HienThiTongThe();
        }
        int i = 0;
        private void dtgvhienthi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
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

        private void frmBCTonKhoTheoKho_Load(object sender, EventArgs e)
        {
            lbtenbaocao.Text = "Báo Cáo Tồn Kho Theo Kho Kỳ " + datesv.Month.ToString() + "/" + datesv.Year.ToString();
        }

        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (i < 0)
                    return;
                frmBaoCaorpt a = new frmBaoCaorpt("Kho", dtgvhienthi["MaKho", i].Value.ToString());
                a.ShowDialog();
            }
            catch { }
        }
        Entities.BCTonKhoTheoKhoDGV[] hienthi;
        public void HienThiTongThe()
        {
            try
            {
                hienthi = new Entities.BCTonKhoTheoKhoDGV[khohang.Length];
                for (int i = 0; i < khohang.Length; i++)
                {
                    int soluong = 0;
                    for (int j = 0; j < tonkho.Length; j++)
                    {
                        if (khohang[i].MaKho == tonkho[j].MaKho)
                        {
                            soluong += tonkho[j].SoLuong;
                        }
                    }
                    hienthi[i] = new Entities.BCTonKhoTheoKhoDGV("", khohang[i].MaKho, khohang[i].TenKho, khohang[i].DiaChi, soluong.ToString());
                }
                Entities.BCTonKhoTheoKhoDGV[] test = new Entities.BCTonKhoTheoKhoDGV[hienthi.Length];
                int sotang = 0;
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (int.Parse(hienthi[i].SoLuong) != 0)
                    {
                        test[sotang] = hienthi[i];
                        sotang++; ;
                    }
                }
                hienthi = new Entities.BCTonKhoTheoKhoDGV[sotang];
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (test[i].MaKho != "")
                        hienthi[i] = test[i];
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCTonKhoTheoKhoDGV> tem0 = new List<Entities.BCTonKhoTheoKhoDGV>();
                int tong0 = 0;
                foreach (Entities.BCTonKhoTheoKhoDGV item in hienthi)
                {
                    tong0 += int.Parse(item.SoLuong);
                    tem0.Add(item);
                }
                Entities.BCTonKhoTheoKhoDGV tem1 = new Entities.BCTonKhoTheoKhoDGV();
                tem1.DiaChi = "Tổng: ";
                tem1.SoLuong = tong0.ToString();
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = hienthi;
                dtgvhienthi.DataSource = tem0.ToArray();

                if (hienthi.Length > 0)
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
                }
                else
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
                }
            }
            catch { }
            finally
            {
                fix();
            }
        }
        public void fix()
        {
            new Common.Utilities().CountDatagridview(dtgvhienthi);
            dtgvhienthi.ReadOnly = true;
            dtgvhienthi.RowHeadersVisible = false;
            dtgvhienthi.Columns["HanhDong"].HeaderText = "STT";
            dtgvhienthi.Columns["MaKho"].HeaderText = "Mã Kho";
            dtgvhienthi.Columns["TenKho"].HeaderText = "Tên Kho";
            dtgvhienthi.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dtgvhienthi.Columns["SoLuong"].HeaderText = "Tồn Kho";
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.AllowUserToAddRows = false;
            dtgvhienthi.AllowUserToDeleteRows = false;
            dtgvhienthi.AllowUserToResizeRows = false;
            this.Focus();
        }
        Entities.KhoHang[] khohang;
        public void KhoHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KhoHang ctxh = new Entities.KhoHang("Select");
                khohang = new Entities.KhoHang[1];
                clientstrem = cl.SerializeObj(this.client1, "KhoHang", ctxh);
                khohang = (Entities.KhoHang[])cl.DeserializeHepper1(clientstrem, khohang);
                if (khohang == null)
                    khohang = new Entities.KhoHang[0];
            }
            catch { }
        }
        Entities.BCTonKhoTheoKho[] tonkho;
        public void TonKho()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.BCTonKhoTheoKho ctxh = new Entities.BCTonKhoTheoKho("Select");
                tonkho = new Entities.BCTonKhoTheoKho[1];
                clientstrem = cl.SerializeObj(this.client1, "BCTonKhoTheoKho", ctxh);
                tonkho = (Entities.BCTonKhoTheoKho[])cl.DeserializeHepper1(clientstrem, tonkho);
                if (tonkho == null)
                    tonkho = new Entities.BCTonKhoTheoKho[0];
            }
            catch { }
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (i < 0)
                    return;
                frmBaoCaorpt a = new frmBaoCaorpt("Kho", dtgvhienthi["MaKho", i].Value.ToString());
                a.ShowDialog();
            }
            catch { }
            finally
            {
                this.Enabled = true;
            }
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt("Kho", dtgvhienthi["MaKho", i].Value.ToString(), saveFileDialog1.FileName, "PDF");
                }
            }
            catch { }
            finally
            {
                this.Enabled = true;
            }
        }

        private void tsslWord_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt("Kho", dtgvhienthi["MaKho", i].Value.ToString(), saveFileDialog1.FileName, "Word");
                }
            }
            catch { }
            finally
            { this.Enabled = true; }
        }

        private void tsslexcel_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt("Kho", dtgvhienthi["MaKho", i].Value.ToString(), saveFileDialog1.FileName, "Excel");
                }
            }
            catch { }
            finally
            { this.Enabled = true; }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                KhoHang();
                TonKho();
                HienThiTongThe(); this.Focus();
            }
            catch { }
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
                    dtgvhienthi.DataSource = new Entities.BCTonKhoTheoKhoDGV[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtimkiem1.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaKho.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCTonKhoTheoKhoDGV[0];
                            return;
                        }
                        Entities.BCTonKhoTheoKhoDGV[] hienthitheoid = new Entities.BCTonKhoTheoKhoDGV[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaKho.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        ///////////////////////////////MRK FIX
                        List<Entities.BCTonKhoTheoKhoDGV> tem0 = new List<Entities.BCTonKhoTheoKhoDGV>();
                        int tong0 = 0;
                        foreach (Entities.BCTonKhoTheoKhoDGV item in hienthitheoid)
                        {
                            tong0 += int.Parse(item.SoLuong);
                            tem0.Add(item);
                        }
                        Entities.BCTonKhoTheoKhoDGV tem1 = new Entities.BCTonKhoTheoKhoDGV();
                        tem1.DiaChi = "Tổng: ";
                        tem1.SoLuong = tong0.ToString();
                        tem0.Add(tem1);
                        //////////////////////////////////////
                        //dtgvhienthi.DataSource = hienthitheoid;
                        dtgvhienthi.DataSource = tem0.ToArray();

                    }
                    if (rdbtimkiem2.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenKho.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCTonKhoTheoKhoDGV[0];
                            return;
                        }
                        Entities.BCTonKhoTheoKhoDGV[] hienthitheoma = new Entities.BCTonKhoTheoKhoDGV[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenKho.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        ///////////////////////////////MRK FIX
                        List<Entities.BCTonKhoTheoKhoDGV> tem0 = new List<Entities.BCTonKhoTheoKhoDGV>();
                        int tong0 = 0;
                        foreach (Entities.BCTonKhoTheoKhoDGV item in hienthitheoma)
                        {
                            tong0 += int.Parse(item.SoLuong);
                            tem0.Add(item);
                        }
                        Entities.BCTonKhoTheoKhoDGV tem1 = new Entities.BCTonKhoTheoKhoDGV();
                        tem1.DiaChi = "Tổng: ";
                        tem1.SoLuong = tong0.ToString();
                        tem0.Add(tem1);
                        //////////////////////////////////////
                        //dtgvhienthi.DataSource = hienthitheoma;
                        dtgvhienthi.DataSource = tem0.ToArray();

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
                    dtgvhienthi.DataSource = new Entities.BCTonKhoTheoKhoDGV[0];
                    return;
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCTonKhoTheoKhoDGV> tem0 = new List<Entities.BCTonKhoTheoKhoDGV>();
                int tong0 = 0;
                foreach (Entities.BCTonKhoTheoKhoDGV item in hienthi)
                {
                    tong0 += int.Parse(item.SoLuong);
                    tem0.Add(item);
                }
                Entities.BCTonKhoTheoKhoDGV tem1 = new Entities.BCTonKhoTheoKhoDGV();
                tem1.DiaChi = "Tổng: ";
                tem1.SoLuong = tong0.ToString();
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = hienthi;
                dtgvhienthi.DataSource = tem0.ToArray();

                if (dtgvhienthi.RowCount > 0)
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
                }
                else
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
                }
            }
            catch { }
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
