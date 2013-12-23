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
    public partial class frmThemhanghoa : Form
    {
        //Khai báo các hàm
        public TcpClient tcpClient;
        public NetworkStream networkStream;

        public frmThemhanghoa()
        {
            InitializeComponent();
        }
        
        private void frmThemhanghoa_Load(object sender, EventArgs e)
        {

        }
        
        //Xử lý giá trị
        string id;
        public frmThemhanghoa(string strThem, DataGridViewRow dtgvr)
        {
            InitializeComponent();
        }

        #region Xử lý Dữ Liệu Nhập Vào
        public bool check()
        {
            if (txtMaHangHoa.Text == "")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }

            if (txtTenHangHoa.Text == "")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }

            if (cmbMaNhaSanXuat.Text == "")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }

            if (txtMaVachNSX.Text == "")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }

            if (cmbMaDonViTinh.Text == "")
            {
                MessageBox.Show("");
                return false;
            }

            if (txtGiaNhap.Text == "")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }

            if (txtGiaBanBuon.Text == "")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }

            if (txtGiaBanLe.Text=="")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }

            if (txtSeri.Text == "")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }

            if (txtMucDatHang.Text == "")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }

            if (txtMucTonToiThieu.Text == "")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }

            if (txtChiTietThem.Text == "")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }

            if (txtNgungTheoDoi.Text == "")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }

            return true;
        }
        #endregion

        //Xử Lý Thêm
        #region Xử Lý Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            Server_Client.Client client = new Server_Client.Client();
            this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
            Entities.HangHoa hh = new Entities.HangHoa();
            //hh = new Entities.HangHoa("Insert", 0, txtMaHangHoa.Text,txtMaNhomHangHoa.Text,txtTenHangHoa.Text,cmbMaNhaSanXuat.SelectedItem.ToString(),txtMaVachNSX.Text,cmbMaDonViTinh.SelectedItem.ToString(),int.Parse(txtGiaNhap.Text),int.Parse(txtGiaBanBuon.Text),int.Parse(txtGiaBanLe.Text),cmbMaThueGTGT.SelectedItem.ToString(),cmbKieuHangHoa.SelectedItem.ToString(),txtSeri.Text,int.Parse(txtMucDatHang.Text),int.Parse(txtMucTonToiThieu.Text),txtGhiChu.Text,false);
            networkStream = client.SerializeObj(this.tcpClient, "HangHoa", hh);
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

            Entities.HangHoa hh = new Entities.HangHoa("Select");
            Entities.HangHoa[] hh1 = new Entities.HangHoa[1];
            networkStream = client.SerializeObj(this.tcpClient, "NhanVien", hh);

            hh1 = (Entities.HangHoa[])client.DeserializeHepper1(networkStream, hh1);
            if (hh1 != null)
            {
                for (int j = 0; j < hh1.Length; j++)
                {
                    if (hh1[j].MaHangHoa == txtMaHangHoa.Text)
                    {
                        MessageBox.Show("Thất bại");
                        chck = "No";
                        txtMaHangHoa.Text = new Common.Utilities().ProcessID(txtMaHangHoa.Text);
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
