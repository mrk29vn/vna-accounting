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
    public partial class frmHienThi_KhoHang : Form
    {
        //Khai báo các hàm
        public TcpClient tcpClient;
        public NetworkStream networkStream;

        public frmHienThi_KhoHang()
        {
            InitializeComponent();
        }

        private void frmHienThi_KhoHang_Load(object sender, EventArgs e)
        {
            SelectData();
            fix();
        }

        //Đặt tên tiếng việt
        public void fix()
        {
            dgvKhoHang.RowHeadersVisible = false;
            dgvKhoHang.Columns[0].Visible = false;
            dgvKhoHang.Columns[dgvKhoHang.ColumnCount - 1].Visible = false;
            dgvKhoHang.AllowUserToResizeRows = false;
            dgvKhoHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhoHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhoHang.ReadOnly = true;

            dgvKhoHang.Columns["KhoHangID"].HeaderText = "Kho Hàng ID";
            dgvKhoHang.Columns["MaKho"].HeaderText = "Mã Kho";
            dgvKhoHang.Columns["TenKho"].HeaderText = "Tên Kho";
            dgvKhoHang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvKhoHang.Columns["DienThoai"].HeaderText = "Điện Thoại";
            dgvKhoHang.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dgvKhoHang.Columns["GhiChu"].HeaderText = "Ghi Chú";
        }

        //Lấy dữ liệu từ Database
        public void SelectData()
        {
            try
            {
                dgvKhoHang.RowHeadersVisible = false;
                Server_Client.Client cl = new Server_Client.Client();
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KhoHang kh = new Entities.KhoHang("Select");

                Entities.KhoHang[] kh1 = new Entities.KhoHang[1];
                networkStream = cl.SerializeObj(this.tcpClient, "KhoHang", kh);
                kh1 = (Entities.KhoHang[])cl.DeserializeHepper1(networkStream, kh1);

                lbhienthitongso.Text = kh1.Length.ToString();
                dgvKhoHang.DataSource = kh1;
                dgvKhoHang.Columns[0].Visible = false;
                dgvKhoHang.Rows[0].Selected = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Kết nối server thất bại");
            }
        }

        //Hiển thị form Thêm Kho Hàng
        private void toolStripStatus_ThemMoi_Click(object sender, EventArgs e)
        {
            frmXuLyKhoHang fr = new frmXuLyKhoHang("Insert", dgvKhoHang.CurrentRow);
            fr.ShowDialog();
            SelectData();
        }

        //Hiển thị form Sửa Kho Hàng
        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            frmXuLyKhoHang skh = new frmXuLyKhoHang("Update", dgvKhoHang.CurrentRow);
            skh.ShowDialog();
            SelectData();
            fix();
        }

        //Xóa Data trên Data Grid View
        #region Xử lý khi Delete
        private void tssXoa_Click(object sender, EventArgs e)
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
            Entities.KhoHang kh = new Entities.KhoHang();
            kh = new Entities.KhoHang("Delete", int.Parse(dgvKhoHang.CurrentRow.Cells[1].Value.ToString()));
            networkStream = cl.SerializeObj(this.tcpClient, "KhoHang", kh);
            bool kt = false;
            kt = (bool)cl.DeserializeHepper(networkStream, kt);
            if (kt == true)
            {
                MessageBox.Show("Thành công");
            }
            SelectData();
        }
        #endregion

        //Hiển thị Sửa Hàng Hóa
        private void dgvKhoHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmXuLyKhoHang snhh = new frmXuLyKhoHang("Update", dgvKhoHang.Rows[e.RowIndex]);
            snhh.ShowDialog();
            SelectData();
            fix();
        }

        //Lọc
        private void tssLoc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa xử lý");
        }

        //In
        private void tssIn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa xử lý");
        }

        //Đóng form
        private void toolStripStatus_Dong_Click(object sender, EventArgs e)
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