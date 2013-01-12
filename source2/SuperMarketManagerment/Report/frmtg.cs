using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Report
{
    public partial class frmtg : Form
    {
        public frmtg()
        {
            InitializeComponent();
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
                try
                {
                    Ngay = Convert.ToDateTime(maskedTextBox1.Text);
                }
                catch
                {
                    MessageBox.Show("ngay ko dung dinh dang");
                    return;
                }
                frmBaoCaorpt bc = new frmBaoCaorpt(Ngay);
                bc.Show();
                this.Close();
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
                    MessageBox.Show("Lam Gi Day");
                    Thang = 0; Nam = 0;
                }
                frmBaoCaorpt bc = new frmBaoCaorpt(Thang,Nam);
                bc.Show();
                this.Close();
            }
            else if (radioButton3.Checked)
            {
                DateTime Truoc, Sau;
                try
                {
                    Truoc = Convert.ToDateTime(maskedTextBox2.Text);
                    Sau = Convert.ToDateTime(maskedTextBox3.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lam Gi Day");
                    Truoc = new DateTime(0, 0, 0);
                    Sau = new DateTime(0, 0, 0);
                }
                frmBaoCaorpt bc = new frmBaoCaorpt(Truoc, Sau);
                bc.Show();
                this.Close();
            }
        }

        private void frmtg_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'supermarketManagementDataSet.PhieuThu' table. You can move, or remove it, as needed.

        }
    }
}
