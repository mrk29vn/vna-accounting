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
    public partial class frmThemloaihanghoa : Form
    {
        //Khai báo các hàm
        public TcpClient tcpClient;
        public NetworkStream networkStream;

        public frmThemloaihanghoa()
        {
            InitializeComponent();
        }

        private void frmThemloaihanghoa_Load(object sender, EventArgs e)
        {

        }

         //Xử lý giá trị
        string id;
        public frmThemloaihanghoa(string strThem, DataGridViewRow dtgvr)
        {
            InitializeComponent();
        }

        //Phần xử lý
        #region Xử lý Dữ Liệu Nhập Vào

        private bool KiemTra()
        {
            if (txtMaLoaiHang.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtMaLoaiHang.Text, "Hệ thống cảnh báo");
                return false;
            }
            if (txtTenLoaiHang.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtTenLoaiHang.Text, "Hệ thống cảnh báo");
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
        
        //Xử Lý Thêm
        #region Xử lý Thêm
        private void tssThem_Click(object sender, EventArgs e)
        {
            Server_Client.Client client = new Server_Client.Client();
            this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
            Entities.LoaiHangHoa nh = new Entities.LoaiHangHoa();
            nh = new Entities.LoaiHangHoa("Insert", 0, txtMaLoaiHang.Text, txtTenLoaiHang.Text, txtGhiChu.Text, false);
            networkStream = client.SerializeObj(this.tcpClient, "LoaiHangHoa", nh);
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

            Entities.LoaiHangHoa lhh = new Entities.LoaiHangHoa("Select");
            Entities.LoaiHangHoa[] lhh1 = new Entities.LoaiHangHoa[1];
            networkStream = client.SerializeObj(this.tcpClient, "NhanVien", lhh);

            lhh1 = (Entities.LoaiHangHoa[])client.DeserializeHepper1(networkStream, lhh1);
            if (lhh1 != null)
            {
                for (int j = 0; j < lhh1.Length; j++)
                {
                    if (lhh1[j].MaLoaiHang == txtTenLoaiHang.Text)
                    {
                        MessageBox.Show("Thất bại");
                        chck = "No";
                        txtTenLoaiHang.Text = new Common.Utilities().ProcessID(txtTenLoaiHang.Text);
                        break;
                    }
                    else
                        chck = "Yes";
                }
            }
        }
        #endregion

        private void btnDong_Click(object sender, EventArgs e)
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
