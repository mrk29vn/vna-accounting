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
    public partial class frmTimHoaDonNhap : Form
    {
        public static DataGridViewRow drvr = null;
        public TcpClient client1;
        public NetworkStream clientstrem;
        string str = "";
        public frmTimHoaDonNhap(string str)
        {
            InitializeComponent();
            this.str = str;
            SelectData(str);
        }
        Server_Client.Client cl;
        Entities.HoaDonNhap[] hienthi;
        public void SelectData(string str)
        {
            try
            {
                Entities.HoaDonNhap ctdh = new Entities.HoaDonNhap();
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                ctdh = new Entities.HoaDonNhap("Select");
                clientstrem = cl.SerializeObj(this.client1, "HDN", ctdh);
                Entities.HoaDonNhap[] ddh = new Entities.HoaDonNhap[1];
                ddh = (Entities.HoaDonNhap[])cl.DeserializeHepper(clientstrem, ddh);

                if (ddh == null)
                {
                    hienthi = new Entities.HoaDonNhap[0];
                    dtgvKH.DataSource = hienthi;
                    return;
                }

                Entities.HoaDonNhap[] pt2 = new Entities.HoaDonNhap[ddh.Length];
                int sotang = 0;
                for (int j = 0; j < ddh.Length; j++)
                {
                    if (ddh[j].Deleted == false && ddh[j].MaNhaCungCap==str)
                    {
                        double ttn = Convert.ToDouble(ddh[j].ThanhToanNgay);
                        double ttnklp = Convert.ToDouble(ddh[j].ThanhToanSauKhiLapPhieu);
                        double tt = Convert.ToDouble(ddh[j].TongTien);
                        if ((ttn + ttnklp) != tt)
                        {
                            pt2[sotang] = ddh[j];
                            sotang++;
                        }
                    }
                }
                hienthi = new Entities.HoaDonNhap[sotang];
                if (sotang != 0)
                {

                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pt2[j];
                    }
                }
                else
                {
                    hienthi = new Entities.HoaDonNhap[0];
                    dtgvKH.DataSource = hienthi;
                    return;
                }
                dtgvKH.DataSource = hienthi;
                dtgvKH.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                fix();      
                 
            }
        }

        public void fix()
        {
            for (int j = 0; j < dtgvKH.ColumnCount; j++)
            {
                dtgvKH.Columns[j].Visible = false;
            }
            dtgvKH.ReadOnly = true; dtgvKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvKH.Columns["HoaDonNhapID"].Visible = true;
            dtgvKH.Columns["MaHoaDonNhap"].Visible = true;
            dtgvKH.Columns["TongTien"].Visible = true;
            dtgvKH.Columns["HoaDonNhapID"].HeaderText = "Hóa Đơn ID";
            dtgvKH.Columns["MaHoaDonNhap"].HeaderText = "Mã Hóa Đơn";
            dtgvKH.Columns["TongTien"].HeaderText = "Tông Tiền";
            dtgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvKH.AllowUserToAddRows = false;
            dtgvKH.AllowUserToDeleteRows = false;
            dtgvKH.AllowUserToResizeRows = false;
            dtgvKH.RowHeadersVisible = false;
        }
        int i;
        private void dtgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void dtgvKH_DoubleClick(object sender, EventArgs e)
        {

        }

        private void frmTimHoaDonNhap_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void rdbtimkiem3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtgvKH.DataSource = hienthi;
                fix();
            }
            catch
            {
            }
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
                    dtgvKH.DataSource = new Entities.HoaDonNhap[0];
                    return;
                }
                int soluong = 0;
                if (rdbtimkiem2.Checked == true)
                {
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaHoaDonNhap.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            soluong++;
                        }
                    }
                    if (soluong == 0)
                    {
                        dtgvKH.DataSource = new Entities.HoaDonNhap[0];
                        return;
                    }
                    Entities.HoaDonNhap[] hienthitheoma = new Entities.HoaDonNhap[soluong];
                    soluong = 0;
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaHoaDonNhap.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            hienthitheoma[soluong] = hienthi[i];
                            soluong++;
                        }
                    }
                    dtgvKH.DataSource = hienthitheoma;
                }
            }
            finally
            {
                fix();
            }
        }

        private void tsslchapnhan_Click(object sender, EventArgs e)
        {
            if (i < 0)
            {
                return;
            }
            try
            {
                drvr = dtgvKH.Rows[i];
                this.Close();
            }
            catch
            {
            }
        }

        private void tsslhuybo_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    frmQuanLyPhieuThu.trave = "ok";
                    this.Close();
                }
                else
                { }
            }
        }

        private void rdbtimkiem2_CheckedChanged(object sender, EventArgs e)
        {
            txttimkiem.Text = "";
        }

        private void dtgvKH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                drvr = dtgvKH.Rows[i];
                this.Close();
            }
            catch
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
    }
}
