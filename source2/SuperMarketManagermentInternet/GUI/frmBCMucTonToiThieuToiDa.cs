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
    public partial class frmBCMucTonToiThieuToiDa : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        DateTime datesv;
        public frmBCMucTonToiThieuToiDa()
        {
            try
            {
                InitializeComponent();datesv = DateServer.Date();

                KhoHang();
                ChiTietKhoHang();
                HangHoa();
                dtgvhienthi.DataSource = khohang;
                fix();
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
        Entities.KhoHang[] khohang;
        public void KhoHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("KH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                khohang = (Entities.KhoHang[])cl.DeserializeHepper1(clientstrem, khohang);
                if (khohang == null)
                {
                    khohang = new Entities.KhoHang[0];
                    return;
                }
            }
            catch
            {
            }
        }
        Entities.ChiTietKhoHangTheoHoaHonNhap[] chitietkhohang;
        public void ChiTietKhoHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTKH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                chitietkhohang = (Entities.ChiTietKhoHangTheoHoaHonNhap[])cl.DeserializeHepper1(clientstrem, chitietkhohang);
                if (chitietkhohang == null)
                {
                    chitietkhohang = new Entities.ChiTietKhoHangTheoHoaHonNhap[0];
                    return;
                }
            }
            catch
            {
            }
        }
        bool kiemtra = false;
        Entities.BCMucTonToiThieuToiDa[] hienthi;
        public void HienThi(string makho)
        {
            try
            {
                int sotang = 0;
                bool kt = false;

                for (int j = 0; j < khohang.Length; j++)
                {
                    for (int k = 0; k < chitietkhohang.Length; k++)
                    {
                        if (chitietkhohang[k].Makho == makho)
                        {
                            for (int i = 0; i < hanghoa.Length; i++)
                            {
                                if (chitietkhohang[k].Makho == makho && chitietkhohang[k].Mahanghoa == hanghoa[i].MaHangHoa)
                                {
                                    if (chitietkhohang[k].Soluong < hanghoa[i].MucTonToiThieu)
                                    {
                                        sotang++;
                                        kt = true;
                                    }
                                    else if (chitietkhohang[k].Soluong > hanghoa[i].MucDatHang)
                                    {
                                        sotang++;
                                        kt = true;
                                    }

                                }
                            }
                        }
                    }
                    if (kt == true)
                        break;
                }
                hienthi = new Entities.BCMucTonToiThieuToiDa[sotang];
                if (sotang == 0)
                {
                    MessageBox.Show("Kho không phát sinh mức tồn tối thiểu - tối đa nào", "Hệ thống cảnh báo");
                    kiemtra = false;
                    return;
                }
                kiemtra = true;
                sotang = 0;
                kt = false;
                for (int j = 0; j < khohang.Length; j++)
                {
                    if (khohang[j].MaKho == makho)
                    {
                        for (int k = 0; k < chitietkhohang.Length; k++)
                        {
                            if (chitietkhohang[k].Makho == makho)
                            {
                                for (int i = 0; i < hanghoa.Length; i++)
                                {
                                    if (chitietkhohang[k].Makho == makho && chitietkhohang[k].Mahanghoa == hanghoa[i].MaHangHoa)
                                    {

                                        if (chitietkhohang[k].Soluong < hanghoa[i].MucTonToiThieu)
                                        {
                                            hienthi[sotang] = new Entities.BCMucTonToiThieuToiDa(khohang[j].MaKho, khohang[j].TenKho, hanghoa[i].MaHangHoa, hanghoa[i].TenHangHoa, hanghoa[i].MucTonToiThieu, hanghoa[i].MucDatHang, chitietkhohang[k].Soluong, 0, "Thiếu hàng");
                                            sotang++;
                                            kt = true;
                                        }
                                        else if (chitietkhohang[k].Soluong > hanghoa[i].MucDatHang)
                                        {
                                            hienthi[sotang] = new Entities.BCMucTonToiThieuToiDa(khohang[j].MaKho, khohang[j].TenKho, hanghoa[i].MaHangHoa, hanghoa[i].TenHangHoa, hanghoa[i].MucTonToiThieu, hanghoa[i].MucDatHang, 0, chitietkhohang[k].Soluong, "Thừa hàng");
                                            sotang++;
                                            kt = true;
                                        }

                                    }
                                }
                            }
                        }
                    }
                    if (kt == true)
                        break;
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

        public string Format(double a)
        {
            return String.Format("{0:0,0}", a);
        }

        public void fix()
        {
            for (int i = 0; i < dtgvhienthi.ColumnCount; i++)
            {
                dtgvhienthi.Columns[i].Visible = false;
            }
            new Common.Utilities().CountDatagridview(dtgvhienthi);
            dtgvhienthi.ReadOnly = true;
            dtgvhienthi.RowHeadersVisible = false;
            dtgvhienthi.Columns["HanhDong"].Visible = true;
            dtgvhienthi.Columns["TenKho"].Visible = true;
            dtgvhienthi.Columns["DiaChi"].Visible = true;
            dtgvhienthi.Columns["MaKho"].Visible = true;
            dtgvhienthi.Columns["HanhDong"].HeaderText = "STT";
            dtgvhienthi.Columns["MaKho"].HeaderText = "Mã Kho";
            dtgvhienthi.Columns["TenKho"].HeaderText = "Tên Kho";
            dtgvhienthi.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dtgvhienthi.Columns["DienThoai"].HeaderText = "Điện Thoại";
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.AllowUserToAddRows = false;
            dtgvhienthi.AllowUserToDeleteRows = false;
            dtgvhienthi.AllowUserToResizeRows = false;
            this.Focus();
        }

        DateTime truoc;
        DateTime sau;
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
            this.Enabled = false;
            if (i < 0)
                return;
            try
            {
                HienThi(dtgvhienthi["MaKho", i].Value.ToString());
                if (kiemtra == true)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthi);
                    a.ShowDialog();
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

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (i < 0)
                return;
            try
            {
                HienThi(dtgvhienthi["MaKho", i].Value.ToString());
                if (kiemtra == true)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthi);
                    a.ShowDialog();
                }
            }
            catch
            {
            }
            finally
            {
                this.Enabled = false;
            }
        }

        private void frmBCMucTonToiThieuToiDa_Load(object sender, EventArgs e)
        {
            lbtenbaocao.Text = "Báo Cáo Tồn Tối Thiểu - Tối Đa hết ngày " + datesv.ToShortDateString();
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (i < 0)
                    return;
                HienThi(dtgvhienthi["MaKho", i].Value.ToString());
                if (kiemtra == false)
                    return;
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    frmBaoCaorpt a = new frmBaoCaorpt(hienthi, saveFileDialog1.FileName, "PDF");
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
                HienThi(dtgvhienthi["MaKho", i].Value.ToString());
                if (kiemtra == false)
                    return;
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthi, saveFileDialog1.FileName, "Word");
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
                HienThi(dtgvhienthi["MaKho", i].Value.ToString());
                if (kiemtra == false)
                    return;
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthi, saveFileDialog1.FileName, "Excel");
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
                KhoHang();
                ChiTietKhoHang();
                HangHoa();
                dtgvhienthi.DataSource = khohang;
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
                    dtgvhienthi.DataSource = new Entities.KhoHang[0];
                    return;
                }
                int soluong = 0;
                if (khohang != null)
                {
                    if (rdbtimkiem1.Checked == true)
                    {
                        for (int i = 0; i < khohang.Length; i++)
                        {
                            int kiemtra = khohang[i].MaKho.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.KhoHang[0];
                            return;
                        }
                        Entities.KhoHang[] hienthitheoid = new Entities.KhoHang[soluong];
                        soluong = 0;
                        for (int i = 0; i < khohang.Length; i++)
                        {
                            int kiemtra = khohang[i].MaKho.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid[soluong] = khohang[i];
                                soluong++;
                            }
                        }
                        dtgvhienthi.DataSource = hienthitheoid;
                    }
                    if (rdbtimkiem2.Checked == true)
                    {
                        for (int i = 0; i < khohang.Length; i++)
                        {
                            int kiemtra = khohang[i].TenKho.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.KhoHang[0];
                            return;
                        }
                        Entities.KhoHang[] hienthitheoma = new Entities.KhoHang[soluong];
                        soluong = 0;
                        for (int i = 0; i < khohang.Length; i++)
                        {
                            int kiemtra = khohang[i].TenKho.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = khohang[i];
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
                if (khohang == null)
                {
                    dtgvhienthi.DataSource = new Entities.KhoHang[0];
                    return;
                }
                dtgvhienthi.DataSource = khohang;
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
