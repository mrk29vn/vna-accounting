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
    public partial class frmLocDieuKien : Form
    {
        DateTime datesv;
        public frmLocDieuKien()
        {
            InitializeComponent();

            datesv = DateServer.Date();
        }

        private void frmLocDieuKien_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void frmLocDieuKien_Load(object sender, EventArgs e)
        {
            cbbnam.Text = datesv.Year.ToString();
            cbbthang.Text = datesv.Month.ToString();
            cbbnamquy.Text = datesv.Year.ToString();
            msktungay.Text = mskdenngay.Text = new Common.Utilities().XuLy(2, datesv.ToShortDateString());
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void rdbtimkiem_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtimkiem1.Checked == true)
            {
                cbbnamquy.Visible = cbbquy.Visible = lbnamtheoquy.Visible = lbquy.Visible = lbtoi.Visible = msktungay.Visible = mskdenngay.Visible = false;
                lbthang.Visible = lbnam.Visible = cbbthang.Visible = cbbnam.Visible = true;
            }
            else if (rdbtimkiem2.Checked == true)
            {
                lbthang.Visible = lbnam.Visible = cbbthang.Visible = cbbnam.Visible = lbtoi.Visible = msktungay.Visible = mskdenngay.Visible = false;
                cbbnamquy.Visible = cbbquy.Visible = lbnamtheoquy.Visible = lbquy.Visible = true;
            }
            else if (rdbtimkiem3.Checked == true)
            {
                lbtoi.Visible = msktungay.Visible = mskdenngay.Visible = true;
                cbbnamquy.Visible = cbbquy.Visible = lbnamtheoquy.Visible = lbquy.Visible = lbthang.Visible = lbnam.Visible = cbbthang.Visible = cbbnam.Visible = false;
            }
        }
        public bool KiemTra()
        {
            try
            {
                string date = new Common.Utilities().MyDateConversion(mskdenngay.Text);
                Convert.ToDateTime(date);
            }
            catch
            {
                lbloi.Text = "Sai định dạng ngày tháng";
                mskdenngay.Focus();
                mskdenngay.SelectAll();
                return false;
            }
            try
            {
                string date = new Common.Utilities().MyDateConversion(msktungay.Text);
                Convert.ToDateTime(date);
            }
            catch
            {
                lbloi.Text = "Sai định dạng ngày tháng";
                msktungay.Focus();
                msktungay.SelectAll();
                return false;
            }
            return true;
        }
        string batdau, ketthuc;
        static public string truoc;
        static public string sau;
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            if (rdbtimkiem1.Checked == true)
            {
                batdau = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), 1).ToString();
                ketthuc = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), DateTime.DaysInMonth(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text))).ToString();

                //batdau = new Common.Utilities().MyDateConversion("01/" + cbbthang.Text + "/" + cbbnam.Text);
                //if (cbbthang.Text == "12")
                //    ketthuc = new Common.Utilities().MyDateConversion("01/01/" + (Convert.ToInt32(cbbnam.Text) + 1).ToString());
                //else
                //    ketthuc = new Common.Utilities().MyDateConversion("01/" + (Convert.ToInt32(cbbthang.Text) + 1).ToString() + "/" + cbbnam.Text);
                truoc = batdau;
                sau = ketthuc;
                this.Close();
            }
            else if (rdbtimkiem2.Checked == true)
            {
                if (cbbquy.Text == "1")
                {
                    batdau = new Common.Utilities().MyDateConversion("01/01/" + cbbnamquy.Text);
                    ketthuc = new Common.Utilities().MyDateConversion("01/04/" + cbbnamquy.Text);
                }
                else if (cbbquy.Text == "2")
                {
                    batdau = new Common.Utilities().MyDateConversion("01/04/" + cbbnamquy.Text);
                    ketthuc = new Common.Utilities().MyDateConversion("01/07/" + cbbnamquy.Text);
                }
                else if (cbbquy.Text == "3")
                {
                    batdau = new Common.Utilities().MyDateConversion("01/07/" + cbbnamquy.Text);
                    ketthuc = new Common.Utilities().MyDateConversion("01/10/" + cbbnamquy.Text);
                }
                else
                {
                    batdau = new Common.Utilities().MyDateConversion("01/10/" + cbbnamquy.Text);
                    ketthuc = new Common.Utilities().MyDateConversion("01/01/" + (int.Parse(cbbnamquy.Text) + 1).ToString());
                }
                truoc = batdau;
                sau = ketthuc;
                this.Close();
            }
            else if (rdbtimkiem3.Checked == true)
            {
                if (KiemTra() == true)
                {
                    truoc = new Common.Utilities().MyDateConversion(msktungay.Text);
                    sau = new Common.Utilities().MyDateConversion(mskdenngay.Text);
                    this.Close();
                }
            }
        }

        private void KeyUp_Chung(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripStatusLabel1_Click(sender, e);
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
