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
    public partial class frmHienThi_HoaDonTraLaiNhaCungCap : Form
    {
        public frmHienThi_HoaDonTraLaiNhaCungCap()
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

        private void toolStripStatus_ThemMoi_Click(object sender, EventArgs e)
        {
            frmXuLy_HoaDonTraLaiNhaCungCap tra = new frmXuLy_HoaDonTraLaiNhaCungCap("Insert");
            tra.ShowDialog();
        }

        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            frmXuLy_HoaDonTraLaiNhaCungCap tra = new frmXuLy_HoaDonTraLaiNhaCungCap("Update");
            tra.ShowDialog();
        }

        private void toolStripStatus_Xoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void toolStripStatus_Loc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void toolStripStatus_In_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }
    }
}
