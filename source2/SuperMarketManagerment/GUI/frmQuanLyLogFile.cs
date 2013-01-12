using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Collections;

namespace GUI
{
    public partial class frmQuanLyLogFile : Form
    {
        public frmQuanLyLogFile()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
                else
                { }
            }
        }
        public TcpClient client1;
        public NetworkStream clientstrem;
        Entities.LogFile[] tf;
        public Entities.LogFile[] LayDT()
        {
            try
            {
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                clientstrem = cl.SerializeObj(this.client1, "DocFileLog", null);
                Entities.LogFile[] lf1 = (Entities.LogFile[])cl.DeserializeHepper1(clientstrem, null);
                return lf1;
            }
            catch (Exception)
            {
                return null;
            }

        }
        void LoadDT()
        {
            tf = LayDT();
            if (tf != null)
                dgvLog.DataSource = tf;
            else
            {
                tf = new Entities.LogFile[0];
                dgvLog.DataSource = tf;
            }
            dgvLog.Refresh();
            fixdgv();
        }
        private void frmQuanLyLogFile_Load(object sender, EventArgs e)
        {
            LoadDT();
        }

        void fixdgv()
        {
            dgvLog.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dgvLog.Columns["TenDangNhap"].HeaderText = "Tên Đăng Nhập";
            dgvLog.Columns["HanhDong"].HeaderText = "Hành Động";
            dgvLog.Columns["NhoiGianThucHien"].HeaderText = "Thời Gian Thực Hiện";
            dgvLog.Columns["NoiDung"].HeaderText = "Nội Dung";
        }
        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            LoadDT();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            if (!Common.Utilities.User.Administrator)
            {
                MessageBox.Show("Phải Là Administrator mới được thực hiện thao tác này");
                return;
            }
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn muốn xóa không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    XoaLogFile(new Entities.LogFile(Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap, "Delete", DateServer.Date().ToString(), "Xoa File Log"));
                    LoadDT();
                }
            }
        }
        bool XoaLogFile(Entities.LogFile lf)
        {
            try
            {
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo nếu muốn truyền giá trị

                // khởi tạo mảng đối tượng để hứng giá trị
                bool nq1;
                clientstrem = cl.SerializeObj(this.client1, "XoaFileLog", lf);
                // đổ mảng đối tượng vào datagripview       
                nq1 = (bool)cl.DeserializeHepper(clientstrem, null);
                return nq1;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private void frmQuanLyLogFile_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            if (txttimkiem.Text.Trim() == "" || tf == null)
            {
                return;
            }

            if (rdbtheomaNV.Checked)
            {
                ArrayList lf1 = new ArrayList();
                foreach (Entities.LogFile item in tf)
                {
                    if (item.MaNhanVien.ToLower().IndexOf(txttimkiem.Text.ToLower()) >= 0)
                    {
                        lf1.Add(item);

                    }

                }
                if (lf1.Count > 0)
                    dgvLog.DataSource = lf1;
                else
                {
                    dgvLog.DataSource = new Entities.LogFile[0];
                }

            }
            else if (rdbtheotenDN.Checked)
            {
                ArrayList lf1 = new ArrayList();
                foreach (Entities.LogFile item in tf)
                {
                    if (item.TenDangNhap.ToLower().IndexOf(txttimkiem.Text.ToLower()) >= 0)
                    {
                        lf1.Add(item);

                    }

                }
                if (lf1.Count > 0)
                    dgvLog.DataSource = lf1;
                else
                {
                    dgvLog.DataSource = new Entities.LogFile[0];
                }
            }
            fixdgv();
        }

        private void rdbtatca_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtatca.Checked)
            {
                if (tf != null)
                    dgvLog.DataSource = tf;
                else
                    dgvLog.DataSource = new Entities.LogFile[0];
                dgvLog.Refresh();
                fixdgv();
            }
        }
    }
}
