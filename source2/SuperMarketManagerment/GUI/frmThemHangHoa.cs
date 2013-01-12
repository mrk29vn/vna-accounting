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
            id = dtgvr.Cells[1].Value.ToString();
        }


        //Phần xử lý
        #region Xử lý Dữ Liệu Nhập Vào

        private bool KiemTra()
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

            if (txtGiaBanLe.Text == "")
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

        //Thêm
        #region Xử lý Thêm
        private void tssThem_Click(object sender, EventArgs e)
        {
            Server_Client.Client client = new Server_Client.Client();
            this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
            Entity.HangHoa hh = new Entity.HangHoa();
            hh = new Entity.HangHoa("Insert", int.Parse(id), txtMaHangHoa.Text, txtMaNhomHangHoa.Text, txtTenHangHoa.Text, cmbMaNhaSanXuat.Text, txtMaVachNSX.Text, cmbMaDonViTinh.Text, float.Parse(txtGiaNhap.Text), float.Parse(txtGiaBanBuon.Text), float.Parse(txtGiaBanLe.Text), cmbMathueNhapKhau.Text, cmbMaThueXuatKhau.Text, cmbMaThueTieuThuDacBiet.Text, cmbMaThueGTGT.Text, txtKieuHangHoa.Text, txtSeri.Text, int.Parse(txtMucDatHang.Text), int.Parse(txtMucTonToiThieu.Text), txtChiTietThem.Text, txtNgungTheoDoi.Text, txtGhiChu.Text, false);
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
