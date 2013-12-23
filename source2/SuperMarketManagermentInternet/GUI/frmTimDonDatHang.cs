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
    public partial class frmTimDonDatHang : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        string str1;
        public static DataGridViewRow drvr = null;
        public frmTimDonDatHang(string str)
        {
            InitializeComponent();
            str1 = str;
            SelectData();
        }
        Entities.DonDatHang[] hienthi;
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData()
        {
            try
            {
                dtgvKH.RowHeadersVisible = false;
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.DonDatHang kh = new Entities.DonDatHang("SelectDDH");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.DonDatHang[] kh1 = new Entities.DonDatHang[1];
                clientstrem = cl.SerializeObj(this.client1, "DonDatHang", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.DonDatHang[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 == null)
                {
                    hienthi = new Entities.DonDatHang[0];
                    dtgvKH.DataSource = hienthi;
                    return;
                }
                Entities.DonDatHang[] kh2 = new Entities.DonDatHang[kh1.Length];
                int sotang = 0;
                for (int j = 0; j < kh1.Length; j++)
                {
                    if (kh1[j].Makhachhang == str1)
                    {
                        kh2[sotang] = kh1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.DonDatHang[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = kh2[j];
                    }
                }
                else
                {
                    hienthi = new Entities.DonDatHang[0];
                    dtgvKH.DataSource = new Entities.DonDatHang[0];
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
            dtgvKH.ReadOnly = true;
            dtgvKH.RowHeadersVisible = false;
            for (int i = 0; i < dtgvKH.ColumnCount; i++)
            {
                dtgvKH.Columns[i].Visible = false;
            }
            dtgvKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvKH.Columns["DonDatHangID"].Visible = true;
            dtgvKH.Columns["DonDatHangID"].HeaderText = "Hóa Đơn ID";
            dtgvKH.Columns["MaDonDatHang"].Visible = true;
            dtgvKH.Columns["MaDonDatHang"].HeaderText = "Mã Hóa Đơn";
            dtgvKH.Columns["MaKhachHang"].Visible = true;
            dtgvKH.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
            dtgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvKH.AllowUserToAddRows = false;
            dtgvKH.AllowUserToDeleteRows = false;
            dtgvKH.AllowUserToResizeRows = false;
            dtgvKH.RowHeadersVisible = false;
        }
        private void toolStripStatus_Huybo_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    sotang = 0;
                    this.Close();
                }
                else
                { }
            }
        }

        private void btntim_Click(object sender, EventArgs e)
        {

        }
        int i;
        private void tsslchapnhan_Click(object sender, EventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                drvr = dtgvKH.Rows[i]; sotang = 0;
                this.Close();
            }
            catch
            {
            }
        }

        private void dtgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void dtgvKH_DoubleClick(object sender, EventArgs e)
        {

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
                    dtgvKH.DataSource = new Entities.DonDatHang[0];
                    return;
                }
                int soluong = 0;
                if (rdbtimkiem2.Checked == true)
                {
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaDonDatHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            soluong++;
                        }
                    }
                    if (soluong == 0)
                    {
                        dtgvKH.DataSource = new Entities.DonDatHang[0];
                        return;
                    }
                    Entities.DonDatHang[] hienthitheoma = new Entities.DonDatHang[soluong];
                    soluong = 0;
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaDonDatHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
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

        private void rdbtimkiem3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtgvKH.DataSource = hienthi; sotang = 0;
                fix();
            }
            catch
            {
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
                drvr = dtgvKH.Rows[i]; sotang = 0;
                this.Close();
            }
            catch
            {
            }
        }
        int sotang = 0;
        private void dtgvKH_KeyUp(object sender, KeyEventArgs e)
        {
            if (i < 0)
                return;
            if (e.KeyCode == Keys.Enter)
            {
                i = dtgvKH.SelectedRows[0].Index;
                drvr = dtgvKH.Rows[i];
                sotang = 0;
                this.Close();
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
