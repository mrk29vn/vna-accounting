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
    public partial class frmSuaNhomHang : Form
    {
        //Khai báo các hàm
        public TcpClient tcpClient;
        public NetworkStream networkStream;

        public frmSuaNhomHang()
        {
            InitializeComponent();
        }

        private void frmSuaNhomHang_Load(object sender, EventArgs e)
        {

        }
        string id;
        public frmSuaNhomHang(DataGridViewRow dgvr)
        {
            InitializeComponent();
            id = dgvr.Cells["NhomHangID"].Value.ToString();
            txtMaNhomHang.Text = dgvr.Cells["MaNhomHang"].Value.ToString();
            txtMaLoaiHang.Text = dgvr.Cells["MaLoaiHang"].Value.ToString();
            txtTenNhomHang.Text = dgvr.Cells["TenNhomHang"].Value.ToString();
            txtGhiChu.Text = dgvr.Cells["GhiChu"].Value.ToString();
        }

        //Sửa Nhóm Hàng Hóa
        #region Xử lý Khi Sửa
        private void tssSua_Click(object sender, EventArgs e)
        {
                Server_Client.Client client = new Server_Client.Client();
                this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
                Entities.NhomHang nh = new Entities.NhomHang();
                nh = new Entities.NhomHang("Update", int.Parse(id), txtMaNhomHang.Text, txtMaLoaiHang.Text, txtTenNhomHang.Text, txtGhiChu.Text, false);
                networkStream = client.SerializeObj(this.tcpClient, "NhomHang", nh);
                bool kt = false;
                kt = (bool)client.DeserializeHepper(networkStream, kt);
                if (kt == true)
                {
                    MessageBox.Show("Thành công");
                }
                this.Close();
        }
        #endregion

        //Check Conflict
        #region Check Conflict
        public string chck = "1";
        public void checkConflict()
        {
            Server_Client.Client client = new Server_Client.Client();
            this.tcpClient = client.Connect(Luu.IP, Luu.Ports);

            Entities.NhomHang nh = new Entities.NhomHang("Select");
            Entities.NhomHang[] nh1 = new Entities.NhomHang[1];
            networkStream = client.SerializeObj(this.tcpClient, "NhanVien", nh);

            nh1 = (Entities.NhomHang[])client.DeserializeHepper1(networkStream, nh1);
            if (nh1 != null)
            {
                for (int j = 0; j < nh1.Length; j++)
                {
                    if (nh1[j].MaNhomHang == txtMaNhomHang.Text)
                    {
                        MessageBox.Show("Thất bại");
                        chck = "No";
                        txtMaNhomHang.Text = new Common.Utilities().ProcessID(txtMaNhomHang.Text);
                        break;
                    }
                    else
                        chck = "Yes";
                }
            }
        }
        #endregion

        //Đóng form 
        private void tssDong_Click(object sender, EventArgs e)
        {
            this.Close();
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
