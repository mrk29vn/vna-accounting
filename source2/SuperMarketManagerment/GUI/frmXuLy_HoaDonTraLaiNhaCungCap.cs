using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmXuLy_HoaDonTraLaiNhaCungCap : Form
    {
        public frmXuLy_HoaDonTraLaiNhaCungCap()
        {
            InitializeComponent();
        }

        private string hanhDong;
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        public frmXuLy_HoaDonTraLaiNhaCungCap(string hanhdong)
        {
            InitializeComponent();
            this.hanhDong = hanhdong;
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
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

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa xử lý");
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa xử lý");
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa xử lý");
        }

        private void btnTimmanhacungcap_Click(object sender, EventArgs e)
        {
            frmTraCuu fr = new frmTraCuu();
            fr.ShowDialog();
        }

        private void btnTimchungtu_Click(object sender, EventArgs e)
        {
            frmTraCuu fr = new frmTraCuu();
            fr.ShowDialog();
        }
    }
}
