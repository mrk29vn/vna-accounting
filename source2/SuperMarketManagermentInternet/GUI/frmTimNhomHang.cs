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
    public partial class frmTimNhomHang : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        public static DataGridViewRow drvr = null;
        public frmTimNhomHang()
        {
            InitializeComponent();
            Select();
        }

        private void tsslhuybo_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void tsslchapnhan_Click(object sender, EventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                drvr = dtgvHienThi.Rows[i];
                this.Close();
            }
            catch
            {
            }
        }
        int i = 0;
        private void dtgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void dtgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                drvr = dtgvHienThi.Rows[i];
                this.Close();
            }
            catch
            {
            }
        }

        private void dtgvHienThi_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    i = dtgvHienThi.SelectedRows[0].Index;
                    drvr = dtgvHienThi.Rows[i];
                    this.Close();
                }
            }
            catch
            {
            }
        }
        Entities.NhomHang[] hienthi;
        public void Select()
        {
            try
            {
                dtgvHienThi.RowHeadersVisible = false;
                Server_Client.Client cl = new Server_Client.Client();
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("NH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                Entities.NhomHang[] kh1 = new Entities.NhomHang[0];
                kh1 = (Entities.NhomHang[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 == null)
                {
                    hienthi = new Entities.NhomHang[0];
                    dtgvHienThi.DataSource = new Entities.NhomHang[0];
                    return;
                }

                Entities.NhomHang[] ncc2 = new Entities.NhomHang[kh1.Length];
                int sotang = 0;
                for (int j = 0; j < kh1.Length; j++)
                {
                    if (kh1[j].Deleted == false)
                    {
                        ncc2[sotang] = kh1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.NhomHang[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = ncc2[j];
                    }
                }
                else
                {
                    hienthi = new Entities.NhomHang[0];
                    dtgvHienThi.DataSource = new Entities.NhomHang[0];
                    return;
                }

                dtgvHienThi.DataSource = hienthi;
                dtgvHienThi.Rows[0].Selected = true;
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
            dtgvHienThi.RowHeadersVisible = false;
            for (int i = 0; i < dtgvHienThi.ColumnCount; i++)
            {
                dtgvHienThi.Columns[i].Visible = false;
            }

            dtgvHienThi.RowHeadersVisible = false;
            dtgvHienThi.AllowUserToResizeRows = false;
            dtgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvHienThi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvHienThi.ReadOnly = true;
            dtgvHienThi.Columns["MaNhomHang"].Visible = true;
            dtgvHienThi.Columns["TenNhomHang"].Visible = true;
            dtgvHienThi.Columns["MaNhomHang"].HeaderText = "Mã Nhóm Hàng";
            dtgvHienThi.Columns["TenNhomHang"].HeaderText = "Tên Nhóm Hàng";
            dtgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.Focus();
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
