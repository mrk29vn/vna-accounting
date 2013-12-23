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
    public partial class frmThemNhomHangHoaHoa : Form
    {
        //Khai báo các hàm
        public TcpClient tcpClient;
        public NetworkStream networkStream;

        public frmThemNhomHangHoaHoa()
        {
            InitializeComponent();
        }

        private void frmThemNhomHangHoa_Load(object sender, EventArgs e)
        {

        }

        //Xử lý giá trị
        string id;
        public frmThemNhomHangHoaHoa(string strThem, DataGridViewRow dtgvr)
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
            if (txtTenNhomHangHoa.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtTenNhomHangHoa.Text, "Hệ thống cảnh báo");
                return false;
            }
            if (txtGhiChu.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtGhiChu.Text, "Hệ thống cảnh báo");
                return false;
            }
            return true;
        }
        #endregion

        #region Xử lý Thêm
        private void tssThem_Click(object sender, EventArgs e)
        {
            Server_Client.Client client = new Server_Client.Client();
            this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
            Entities.NhomHang nh = new Entities.NhomHang();
            nh = new Entities.NhomHang("Insert", 0, txtMaNhomHang.Text, txtMaLoaiHang.Text, txtTenNhomHangHoa.Text, txtGhiChu.Text, false);
            networkStream = client.SerializeObj(this.tcpClient, "NhomHangHoa", nh);
            bool kt = false;
            kt = (bool)client.DeserializeHepper(networkStream, kt);
            if (kt == true)
            {
                MessageBox.Show("Thành công");
            }
            this.Close();
        }
        #endregion

        //Đóng form
        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
            //System.Windows.Forms.DialogResult dong = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            //{
            //    if (dong == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        this.Close();
            //    }
            //    else
            //    { 

            //    }
            //}
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
