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
using System.Collections;

namespace GUI
{
    public partial class frmTimDVT : Form
    {        
        //Khai báo các hàm
        public TcpClient tcpClient;
        public NetworkStream networkStream;
        public static DataGridViewRow drvr = null;
        Server_Client.Client cl;
        Entities.DVT[] hienthi;
        public frmTimDVT()
        {
            InitializeComponent();
            SelectData();            
        }

        private void frmTimDVT_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        public void SelectData()
        {
            try
            {

                // i = 0;
                dtgvKH.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.DVT kh = new Entities.DVT();
                // truyền HanhDong
                kh = new Entities.DVT("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.DVT[] kh1 = new Entities.DVT[1];
                networkStream = cl.SerializeObj(this.tcpClient, "DVT", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.DVT[])cl.DeserializeHepper1(networkStream, kh1);
                //lbhienthitongso.Text = kh1.Length.ToString();
                if (kh1 == null)
                {
                    hienthi = new Entities.DVT[0];
                    dtgvKH.DataSource = new Entities.DVT[0];
                    return;
                }

                Entities.DVT[] pt2 = new Entities.DVT[kh1.Length];
                int sotang = 0;
                for (int j = 0; j < kh1.Length; j++)
                {

                    if (kh1[j].Deleted == false)
                    {
                        pt2[sotang] = kh1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.DVT[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pt2[j];
                    }
                }
                else
                {
                    
                    dtgvKH.DataSource = new Entities.DVT[0];
                    return;
                }
                dtgvKH.DataSource = hienthi;
                new Common.Utilities().CountDatagridview(dtgvKH);

                dtgvKH.Rows[0].Selected = true;
            }
            finally
            {
                fix();
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

                int soluong = 0;
                if (rdbtimkiem1.Checked == true)
                {
                    if (txttimkiem.Text.Length == 0)
                    {
                        dtgvKH.DataSource = new Entities.DVT[0];
                        return;
                    }
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].TenDonViTinh.ToString().ToUpper().IndexOf(txttimkiem.Text);
                        if (kiemtra >= 0)
                        {
                            soluong++;
                        }
                    }
                    if (soluong == 0)
                    {
                        dtgvKH.DataSource = new Entities.DVT[0];
                        return;
                    }
                    Entities.DVT[] hienthitheoid = new Entities.DVT[soluong];
                    soluong = 0;
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].TenDonViTinh.ToString().ToUpper().IndexOf(txttimkiem.Text);
                        if (kiemtra >= 0)
                        {
                            hienthitheoid[soluong] = hienthi[i];
                            soluong++;
                        }
                    }
                    dtgvKH.DataSource = hienthitheoid;
                }
                if (rdbtimkiem2.Checked == true)
                {
                    if (txttimkiem.Text.Length == 0)
                    {
                        dtgvKH.DataSource = new Entities.DVT[0];
                        return;
                    }
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaDonViTinh.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            soluong++;
                        }
                    }
                    if (soluong == 0)
                    {
                        dtgvKH.DataSource = new Entities.DVT[0];
                        return;
                    }
                    Entities.DVT[] hienthitheoma = new Entities.DVT[soluong];
                    soluong = 0;
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaDonViTinh.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
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
                dtgvKH.DataSource = hienthi;
                fix();
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
                drvr = dtgvKH.Rows[i];
                this.Close();
            }
            catch
            {
            }
        }
        int i;
        private void dtgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
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

        public void fix()
        {
            for (int i = 0; i < dtgvKH.ColumnCount; i++)
            {
                dtgvKH.Columns[i].Visible = false;
            }
            dtgvKH.ReadOnly = true;
            dtgvKH.Columns["MaDonViTinh"].Visible = true;
            dtgvKH.Columns["TenDonViTinh"].Visible = true;
            dtgvKH.Columns["MaDonViTinh"].HeaderText = "Mã Đơn Vị Tính";
            dtgvKH.Columns["TenDonViTinh"].HeaderText = "Tên Đơn Vị Tính";
            dtgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvKH.AllowUserToAddRows = false;
            dtgvKH.AllowUserToDeleteRows = false;
            dtgvKH.AllowUserToResizeRows = false;
            
        }

        private void frmTimDVT_Load(object sender, EventArgs e)
        {
            dtgvKH.Focus();
        }

        private void dtgvKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
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
        }

        private void dtgvKH_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }
    }
}
