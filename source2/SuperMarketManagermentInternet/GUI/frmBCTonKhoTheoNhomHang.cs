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
    public partial class frmBCTonKhoTheoNhomHang : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        DateTime datesv;
        public frmBCTonKhoTheoNhomHang()
        {
            InitializeComponent();datesv = DateServer.Date();
            SelectNhomHang();
            TonKho();
            HienThiTongThe();
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
        int i = 0;
        private void dtgvhienthi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (i < 0)
                    return;
                frmBaoCaorpt a = new frmBaoCaorpt("Nhom", dtgvhienthi["MaNhomHang", i].Value.ToString());
                a.ShowDialog();
            }
            catch
            {
            }
            
        }
        Entities.BCTonKhoTheoNhomHangDGV[] hienthi;
        public void HienThiTongThe()
        {
            try
            {
                hienthi = new Entities.BCTonKhoTheoNhomHangDGV[nh.Length];
                for (int i = 0; i < nh.Length; i++)
                {
                    int soluong = 0;
                    for (int j = 0; j < tonkho.Length; j++)
                    {
                        if (nh[i].MaNhomHang == tonkho[j].MaNhomHang)
                        {
                            soluong += tonkho[j].SoLuong;
                        }
                    }
                    hienthi[i] = new Entities.BCTonKhoTheoNhomHangDGV("", nh[i].MaNhomHang, nh[i].TenNhomHang, soluong.ToString());
                }
                Entities.BCTonKhoTheoNhomHangDGV[] test = new Entities.BCTonKhoTheoNhomHangDGV[hienthi.Length];
                int sotang = 0;
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (int.Parse(hienthi[i].SoLuong) != 0)
                    {
                        test[sotang] = hienthi[i];
                        sotang++; ;
                    }
                }
                hienthi = new Entities.BCTonKhoTheoNhomHangDGV[sotang];
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (test[i].MaNhomHang != "")
                        hienthi[i] = test[i];
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCTonKhoTheoNhomHangDGV> tem0 = new List<Entities.BCTonKhoTheoNhomHangDGV>();
                int tong0 = 0;
                foreach (Entities.BCTonKhoTheoNhomHangDGV item in hienthi)
                {
                    tong0 += int.Parse(item.SoLuong);
                    tem0.Add(item);
                }
                Entities.BCTonKhoTheoNhomHangDGV tem1 = new Entities.BCTonKhoTheoNhomHangDGV();
                tem1.HanhDong = "Tổng: ";
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
            catch
            {
            }
            finally
            {
                fix();
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

        public void fix()
        {
            new Common.Utilities().CountDatagridview(dtgvhienthi);
            dtgvhienthi.ReadOnly = true;
            dtgvhienthi.RowHeadersVisible = false;
            dtgvhienthi.Columns["HanhDong"].HeaderText = "STT";
            dtgvhienthi.Columns["MaNhomHang"].HeaderText = "Mã Nhóm Hàng";
            dtgvhienthi.Columns["TenNhomHang"].HeaderText = "Tên Nhóm Hàng";
            dtgvhienthi.Columns["SoLuong"].HeaderText = "Tồn Kho";
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.AllowUserToAddRows = false;
            dtgvhienthi.AllowUserToDeleteRows = false;
            dtgvhienthi.AllowUserToResizeRows = false;
            this.Focus();
        }

        Entities.NhomHang[] nh;
        public void SelectNhomHang()
        {
            try
            {

                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.NhomHang ctxh = new Entities.NhomHang("Select");
                clientstrem = cl.SerializeObj(this.client1, "NhomHang", ctxh);
                nh = (Entities.NhomHang[])cl.DeserializeHepper1(clientstrem, nh);
                if (nh == null)
                {
                    nh = new Entities.NhomHang[0];
                    return;
                }
            }
            catch
            {

            }
        }
        Entities.BCTonKhoTheoNhomHang[] tonkho;
        public void TonKho()
        {
            try
            {

                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.BCTonKhoTheoNhomHang ctxh = new Entities.BCTonKhoTheoNhomHang("Select");
                clientstrem = cl.SerializeObj(this.client1, "BCTonKhoTheoNhom", ctxh);
                tonkho = (Entities.BCTonKhoTheoNhomHang[])cl.DeserializeHepper1(clientstrem, tonkho);
                if (tonkho == null)
                {
                    tonkho = new Entities.BCTonKhoTheoNhomHang[0];
                    return;
                }
            }
            catch
            {

            }
        }

        private void frmBCTonKhoTheoNhomHang_Load(object sender, EventArgs e)
        {
            lbtenbaocao.Text = "Báo Cáo Tồn Kho Theo Nhóm Hàng Kỳ " + datesv.Month.ToString() + "/" + datesv.Year.ToString();

        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (i < 0)
                    return;
                frmBaoCaorpt a = new frmBaoCaorpt("Nhom", dtgvhienthi["MaNhomHang", i].Value.ToString());
                a.ShowDialog();
            }
            catch
            {
            }
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
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (i < 0)
                        return;
                    frmBaoCaorpt a = new frmBaoCaorpt("Nhom", dtgvhienthi["MaNhomHang", i].Value.ToString(), saveFileDialog1.FileName, "PDF");
                }
            }
            catch
            {
            }
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
                    frmBaoCaorpt a = new frmBaoCaorpt("Nhom", dtgvhienthi["MaNhomHang", i].Value.ToString(), saveFileDialog1.FileName, "Word");
                }
            }
            catch
            {
            }
            finally
            {
                this.Enabled = true;
            }
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
                    frmBaoCaorpt a = new frmBaoCaorpt("Nhom", dtgvhienthi["MaNhomHang", i].Value.ToString(), saveFileDialog1.FileName, "Excel");
                }
            }
            catch
            {
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                SelectNhomHang();
                TonKho();
                HienThiTongThe(); this.Focus();
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
                    dtgvhienthi.DataSource = new Entities.BCTonKhoTheoNhomHangDGV[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtimkiem1.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCTonKhoTheoNhomHangDGV[0];
                            return;
                        }
                        Entities.BCTonKhoTheoNhomHangDGV[] hienthitheoid = new Entities.BCTonKhoTheoNhomHangDGV[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        ///////////////////////////////MRK FIX
                        List<Entities.BCTonKhoTheoNhomHangDGV> tem0 = new List<Entities.BCTonKhoTheoNhomHangDGV>();
                        int tong0 = 0;
                        foreach (Entities.BCTonKhoTheoNhomHangDGV item in hienthitheoid)
                        {
                            tong0 += int.Parse(item.SoLuong);
                            tem0.Add(item);
                        }
                        Entities.BCTonKhoTheoNhomHangDGV tem1 = new Entities.BCTonKhoTheoNhomHangDGV();
                        tem1.HanhDong = "Tổng: ";
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
                            int kiemtra = hienthi[i].TenNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCTonKhoTheoNhomHangDGV[0];
                            return;
                        }
                        Entities.BCTonKhoTheoNhomHangDGV[] hienthitheoma = new Entities.BCTonKhoTheoNhomHangDGV[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        ///////////////////////////////MRK FIX
                        List<Entities.BCTonKhoTheoNhomHangDGV> tem0 = new List<Entities.BCTonKhoTheoNhomHangDGV>();
                        int tong0 = 0;
                        foreach (Entities.BCTonKhoTheoNhomHangDGV item in hienthitheoma)
                        {
                            tong0 += int.Parse(item.SoLuong);
                            tem0.Add(item);
                        }
                        Entities.BCTonKhoTheoNhomHangDGV tem1 = new Entities.BCTonKhoTheoNhomHangDGV();
                        tem1.HanhDong = "Tổng: ";
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
                    dtgvhienthi.DataSource = new Entities.BCTonKhoTheoNhomHangDGV[0];
                    return;
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCTonKhoTheoNhomHangDGV> tem0 = new List<Entities.BCTonKhoTheoNhomHangDGV>();
                int tong0 = 0;
                foreach (Entities.BCTonKhoTheoNhomHangDGV item in hienthi)
                {
                    tong0 += int.Parse(item.SoLuong);
                    tem0.Add(item);
                }
                Entities.BCTonKhoTheoNhomHangDGV tem1 = new Entities.BCTonKhoTheoNhomHangDGV();
                tem1.HanhDong = "Tổng: ";
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
