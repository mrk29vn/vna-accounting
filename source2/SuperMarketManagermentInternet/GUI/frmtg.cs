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
    public partial class frmtg : Form
    {
        DateTime datesv;
        public frmtg()
        {
            InitializeComponent();datesv = DateServer.Date();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                maskedTextBox1.Visible = true;
                maskedTextBox2.Visible = false;
                maskedTextBox3.Visible = false;
                comboBox1.Visible = false;
                dateTimePicker1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
            }
            else if (radioButton2.Checked)
            {
                maskedTextBox1.Visible = false;
                maskedTextBox2.Visible = false;
                maskedTextBox3.Visible = false;
                comboBox1.Visible = true;
                dateTimePicker1.Visible = true;
                label1.Visible = false;
                label2.Visible = true;
                label3.Visible = true;
            }
            else if (radioButton3.Checked)
            {
                maskedTextBox1.Visible = false;
                maskedTextBox2.Visible = true;
                maskedTextBox3.Visible = true;
                comboBox1.Visible = false;
                dateTimePicker1.Visible = false;
                label1.Visible = true;
                label2.Visible = false;
                label3.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                DateTime Ngay;
                string date="";
                try
                {
                   date = new Common.Utilities().MyDateConversion(maskedTextBox1.Text);
                  Ngay =  Convert.ToDateTime(date);
                }
                catch
                {
                    MessageBox.Show("ngay ko dung dinh dang");
                    return;
                }
                frmBaoCaorpt bc = new frmBaoCaorpt(Ngay);
                bc.ShowDialog();
            }
            else if (radioButton2.Checked)
            {
                int Thang, Nam;
                try
                {
                    Thang = Convert.ToInt32(comboBox1.Text);
                    Nam = dateTimePicker1.Value.Year;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("nhập sai định dạng ngày tháng", "Hệ thống cảnh báo");
                    maskedTextBox1.Focus();
                    return;
                }
                frmBaoCaorpt bc = new frmBaoCaorpt(Thang,Nam);
                bc.ShowDialog();
            }
            else if (radioButton3.Checked)
            {
                DateTime Truoc, Sau;
                string date1 = "", date2 = "";
                try
                {
                    date1 = new Common.Utilities().MyDateConversion(maskedTextBox2.Text);
                    Truoc = Convert.ToDateTime(date1);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("nhập sai định dạng ngày tháng","Hệ thống cảnh báo");
                    maskedTextBox2.Focus();
                    return;
                }
                try
                {
                    date2 = new Common.Utilities().MyDateConversion(maskedTextBox3.Text);
                    Sau = Convert.ToDateTime(date2);
                }
                catch
                {
                    MessageBox.Show("nhập sai định dạng ngày tháng", "Hệ thống cảnh báo");
                    maskedTextBox3.Focus();
                    return;
                }
                
                frmBaoCaorpt bc = new frmBaoCaorpt(Truoc, Sau);
                bc.ShowDialog();
            }
        }

        private void frmtg_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'supermarketManagementDataSet.PhieuThu' table. You can move, or remove it, as needed.

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void maskedTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void frmtg_Load_1(object sender, EventArgs e)
        {
            maskedTextBox1.Text = maskedTextBox2.Text = maskedTextBox3.Text = new Common.Utilities().XuLy(2, datesv.ToShortDateString());
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
