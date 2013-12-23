using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Entity;

namespace GUI
{
    public partial class frmSuaNhomTKKeToan : Form
    {
        public frmSuaNhomTKKeToan()
        {
            InitializeComponent();
        }

        private void toolStripStatus_Dong_Click(object sender, EventArgs e)
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

        string maNhomTKKeToan;

        public string MaNhomTKKeToan
        {
            get { return maNhomTKKeToan; }
            set { maNhomTKKeToan = value; }
        }

        public TcpClient client1;
        public NetworkStream clientstream;
        NhomTKKeToan ntkkt;

        public void hienthi()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            ntkkt = new NhomTKKeToan("Select", 1, "a", "a", "a", false);
            clientstream = cl.SerializeObj(this.client1, "NhomTKKeToan", ntkkt);

            NhomTKKeToan[] tk1 = new NhomTKKeToan[1];
            tk1[0] = new NhomTKKeToan(1, "a", "a", "a", false);
            tk1 = (NhomTKKeToan[])cl.DeserializeHepper1(clientstream, tk1);

            foreach (NhomTKKeToan objtk in tk1)
            {
                if (objtk.MaNhomTKKeToan == maNhomTKKeToan)
                {
                    txtID.Text = objtk.NhomTKKeToanID.ToString();
                    txtmaNTKKT.Text = objtk.MaNhomTKKeToan;
                    txttenNTKKT.Text = objtk.TenNhomTKKeToan;
                    txtghichu.Text = objtk.GhiChu;
                }
            }

        }

        public bool Validate()
        {

            if (txttenNTKKT.Text.Length == 0)
            {
                MessageBox.Show("Tên Nhóm TK Kế toán không được để trống", "Hệ Thống Cảnh Báo");
                return false;
            }
            return true;
        }

        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entity.NhomTKKeToan pb = new Entity.NhomTKKeToan("Update", Convert.ToInt32(txtID.Text), txtmaNTKKT.Text, txttenNTKKT.Text, txtghichu.Text, false);
                clientstream = cl.SerializeObj(this.client1, "NhomTKKeToan", pb);

                int msg = 0;
                msg = (int)cl.DeserializeHepper(clientstream, msg);
                if (msg == 1)
                {
                    MessageBox.Show("Update thanh cong ...");
                }
                else
                    MessageBox.Show("Update that bai");

            }
        }

        private void frmSuaNhomTKKeToan_Load(object sender, EventArgs e)
        {
            hienthi();
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
