using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BizLogic;

namespace GUI
{
    public partial class frmXuLy_KhoHang : Form
    {
        //form xu ly kho hang
        public frmXuLy_KhoHang()
        {
            InitializeComponent();
        }
        private string maHang;
        public frmXuLy_KhoHang(string MaHang)
        {
            InitializeComponent();
            this.maHang = MaHang;
        }
        //form load
        private void frmXuLy_KhoHang_Load(object sender, EventArgs e)
        {
            try
            {
                Entities.KhoHang[] pb = new BizLogic.KhoHang().sp_SelectKhoHangsAll();

                for (int i = 0; i < pb.Length; i++)
                {
                    cmbThuKho.Items.Add(pb[i].MaKho);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //check error
        public bool check()
        {
            if (txtMaKho.Text == "")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }

            if (txtTenKho.Text == "")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }

            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Không được để trống.");              
                return false;
            }

            if (txtSoDienThoai.Text == "")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }

            if (cmbThuKho.SelectedItem == "")
            {
                MessageBox.Show("Không được để trống.");
                return false;
            }
            return true;
        }
        //them data
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnGhiLai_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void rbTonKho_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        //thiet lap
        private void thiêtLâpThôngSôToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOption fr = new frmOption();
            fr.ShowDialog();
        }
        //close form
        private void btnDong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {

                }
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
