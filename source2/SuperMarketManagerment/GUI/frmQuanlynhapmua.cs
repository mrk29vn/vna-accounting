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
    public partial class frmQuanlynhapmua : Form
    {
        public frmQuanlynhapmua()
        {
            InitializeComponent();
        }

        private void frmQuanlynhapmua_Load(object sender, EventArgs e)
        {

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
            frmXuLy_NhapMua fr = new frmXuLy_NhapMua();
            fr.ShowDialog();
        }

        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            frmXuLy_NhapMua fr = new frmXuLy_NhapMua();
            fr.ShowDialog();
        }

        private void lblDatmua_Click(object sender, EventArgs e)
        {

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
