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
    public partial class frmSuaHH : Form
    {
        //Khai báo các hàm
        public TcpClient tcpClient;
        public NetworkStream networkStream;

        public frmSuaHH()
        {
            InitializeComponent();
        }

        private void frmSuahanghoa_Load(object sender, EventArgs e)
        {

        }

        DataGridViewRow dgvr1;
        public frmSuaHH(DataGridViewRow dgvr)
        {
            InitializeComponent();
            txtHangHoaID.Text = dgvr.Cells["HangHoaID"].Value.ToString();
            txtMaHangHoa.Text = dgvr.Cells["MaHangHoa"].Value.ToString();
            txtMaNhomHang.Text = dgvr.Cells["MaNhomHangHoa"].Value.ToString();
            txtTenHangHoa.Text = dgvr.Cells["TenHangHoa"].Value.ToString();
            cmbMaNhaSanXuat.Text = dgvr.Cells["MaNhaSanXuat"].Value.ToString();
            txtMaVachNSX.Text = dgvr.Cells["MaVachNhaSanXuat"].Value.ToString();
            cmbMaDonViTinh.Text = dgvr.Cells["MaDonViTinh"].Value.ToString();
            txtGiaNhap.Text = dgvr.Cells["GiaNhap"].Value.ToString();
            txtGiaBanBuon.Text = dgvr.Cells["GiaBanBuon"].Value.ToString();
            txtGiaBanLe.Text = dgvr.Cells["GiaBanLe"].Value.ToString();
            cmbMathueNhapKhau.Text = dgvr.Cells["MathueNhapKhau"].Value.ToString();
            cmbMaThueXuatKhau.Text = dgvr.Cells["MaThueXuatKhau"].Value.ToString();
            cmbMaThueTieuThuDacBiet.Text = dgvr.Cells["MaThueTiêuThuDacBiet"].Value.ToString();
            cmbMaThueGTGT.Text = dgvr.Cells["MaThueGiaTriGiaTang"].Value.ToString();
            txtKieuHangHoa.Text = dgvr.Cells["KieuHangHoa"].Value.ToString();
            txtSeri.Text = dgvr.Cells["SeriLo"].Value.ToString();
            txtMucDatHang.Text = dgvr.Cells["MucDatHang"].Value.ToString();
            txtMucTonToiThieu.Text = dgvr.Cells["MucTonToiThieu"].Value.ToString();
            txtChiTietThem.Text = dgvr.Cells["ChiTietThem"].Value.ToString();
            txtNgungTheoDoi.Text = dgvr.Cells["NgungTheoDoi"].Value.ToString();
            txtGhiChu.Text = dgvr.Cells["GhiChu"].Value.ToString();
            dgvr1 = dgvr;
        }

        //Phần xử lý
        #region Xử lý Dữ Liệu Nhập Vào

        private bool KiemTra()
        {
            if (txtHangHoaID.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtHangHoaID.Text, "Hệ thống cảnh báo");
                return false;
            }
            if (txtMaHangHoa.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtMaHangHoa.Text, "Hệ thống cảnh báo");
                return false;
            }
            if (txtTenHangHoa.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtMaHangHoa.Text, "Hệ thống cảnh báo");
                return false;
            }
            if (txtMaVachNSX.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtMaHangHoa.Text, "Hệ thống cảnh báo");
                return false;
            }
            if (txtGiaNhap.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtMaHangHoa.Text, "Hệ thống cảnh báo");
                return false;
            }
            if (txtGiaBanBuon.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtMaHangHoa.Text, "Hệ thống cảnh báo");
                return false;
            }
            if (txtGiaBanLe.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtMaHangHoa.Text, "Hệ thống cảnh báo");
                return false;
            }
            if (txtSeri.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtMaHangHoa.Text, "Hệ thống cảnh báo");
                return false;
            }
            if (txtMucDatHang.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtMaHangHoa.Text, "Hệ thống cảnh báo");
                return false;
            }
            if (txtMucTonToiThieu.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtMaHangHoa.Text, "Hệ thống cảnh báo");
                return false;
            }
            if (txtChiTietThem.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtMaHangHoa.Text, "Hệ thống cảnh báo");
                return false;
            }
            if (txtNgungTheoDoi.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + txtMaHangHoa.Text, "Hệ thống cảnh báo");
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

        //Xử lý giá trị
        string id;
        public frmSuaHH(string strThem, DataGridViewRow dtgvr)
        {
            InitializeComponent();
            id = dtgvr.Cells[1].Value.ToString();
        }

        //Sửa Hàng Hóa
        #region Xử lý Khi Sửa
        private void tssSua_Click(object sender, EventArgs e)
        {
            if (KiemTra() == true)
            {
                Server_Client.Client client = new Server_Client.Client();
                this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
                Entities.HangHoa hh = new Entities.HangHoa();
                hh = new Entities.HangHoa("Update", int.Parse(txtHangHoaID.Text), txtMaHangHoa.Text, txtMaNhomHang.Text, txtTenHangHoa.Text, cmbMaNhaSanXuat.Text, txtMaVachNSX.Text, cmbMaDonViTinh.Text, float.Parse(txtGiaNhap.Text), float.Parse(txtGiaBanBuon.Text), float.Parse(txtGiaBanLe.Text), cmbMathueNhapKhau.Text, cmbMaThueXuatKhau.Text, cmbMaThueTieuThuDacBiet.Text, cmbMaThueGTGT.Text, txtKieuHangHoa.Text, txtSeri.Text, int.Parse(txtMucDatHang.Text), int.Parse(txtMucTonToiThieu.Text), txtChiTietThem.Text, txtNgungTheoDoi.Text, txtGhiChu.Text, false);
                networkStream = client.SerializeObj(this.tcpClient, "HangHoa", hh);
                bool kt = false;
                kt = (bool)client.DeserializeHepper(networkStream, kt);
                if (kt == true)
                {
                    MessageBox.Show("Thành công");
                }
                this.Close();
            }
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
