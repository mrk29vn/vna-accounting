using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmThemNhomTKKeToan : Form
    {
        public frmThemNhomTKKeToan()
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
        public bool Validate()
        {

            if (txttenNTKKT.Text.Length == 0)
            {
                MessageBox.Show("Tên Nhóm TK Kế toán không được để trống", "Hệ Thống Cảnh Báo");
                return false;
            }
            return true;
        }

        public TcpClient client1;
        public NetworkStream clientstream;

        private void toolStripStatus_ThemMoi_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entity.NhomTKKeToan pb = new Entity.NhomTKKeToan("Insert", Convert.ToInt32(txtID.Text), txtmapb.Text, txttenNTKKT.Text, txtghichu.Text, false);
                clientstream = cl.SerializeObj(this.client1, "NhomTKKeToan", pb);

                int msg = 0;
                msg = (int)cl.DeserializeHepper(clientstream, msg);
                if (msg == 1)
                {
                    MessageBox.Show("Insert thanh cong ...");
                }
                else
                    MessageBox.Show("Insert that bai");

            }
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
