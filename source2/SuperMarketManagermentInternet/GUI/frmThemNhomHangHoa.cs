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
    public partial class frmThemNhomHangHoa : Form
    {
        //Khai báo các hàm
        public TcpClient tcpClient;
        public NetworkStream networkStream;

        public frmThemNhomHangHoa()
        {
            InitializeComponent();
        }

        private void frmThemNhomHangHoa_Load(object sender, EventArgs e)
        {

        }

        //Xử lý giá trị
        string id;
        public frmThemNhomHangHoa(string strThem, DataGridViewRow dtgvr)
        {
            InitializeComponent();
        }

        //Phần xử lý
        #region Xử lý Dữ Liệu Nhập Vào

        private bool KiemTra()
        {
            if (txtMaNhomHang.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtMaNhomHang.Text, "Hệ thống cảnh báo");
                return false;

            }
            if (txtMaLoaiHang.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtMaLoaiHang.Text, "Hệ thống cảnh báo");
                return false;
            }
            if (txtTenNhomHang.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtTenNhomHang.Text, "Hệ thống cảnh báo");
                return false;
            }
            return true;
        }
        #endregion

        //Xử Lý thêm Nhóm Hàng Hóa
        #region Xử lý Thêm 
        private void tssThem_Click(object sender, EventArgs e)
        {
            Server_Client.Client client = new Server_Client.Client();
            this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
            Entities.NhomHang nh = new Entities.NhomHang();
            nh = new Entities.NhomHang("Insert", 0, txtMaNhomHang.Text, txtMaLoaiHang.Text, txtTenNhomHang.Text, txtGhiChu.Text, false);
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
        private void btnTroVe_Click(object sender, EventArgs e)
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
