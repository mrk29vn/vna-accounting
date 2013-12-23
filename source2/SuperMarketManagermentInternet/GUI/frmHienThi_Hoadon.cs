using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace GUI
{
    public partial class frmHienThi_Hoadon : Form
    {
        public frmHienThi_Hoadon()
        {
            InitializeComponent();
        }

        private void toolStripStatus_ThemMoi_Click(object sender, EventArgs e)
        {
            frmXuLy_DonDatHang insert = new frmXuLy_DonDatHang();
            this.WindowState = FormWindowState.Maximized;
            insert.ShowDialog(this);
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

        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            frmXuLy_DonDatHang insert = new frmXuLy_DonDatHang();
            this.WindowState = FormWindowState.Maximized;
            insert.ShowDialog(this);
        }
     
        private void toolStripStatus_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int x = dgvHienThi.RowCount;
                int y = dgvHienThi.ColumnCount;
                if (y <= -1 || x <= -1)
                {
                    MessageBox.Show("Chọn dòng muốn xóa");
                }
                else
                {
                    int vitri = dgvHienThi.CurrentRow.Index;
                    int ID = System.Convert.ToInt32(dgvHienThi.Rows[vitri].Cells[0].Value.ToString());
                    MessageBox.Show(ID.ToString());
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }
        }

        private void frmViewOrderProducts_Load(object sender, EventArgs e)
        {
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void toolStripStatus_Loc_Click(object sender, EventArgs e)
        {
            frmTimHoaDon update = new frmTimHoaDon();
            this.WindowState = FormWindowState.Maximized;
            update.ShowDialog(this);
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
