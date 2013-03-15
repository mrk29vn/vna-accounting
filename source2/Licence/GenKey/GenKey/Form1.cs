using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenKey
{
    public partial class Form1 : Form
    {
        List<string> l = new List<string>();

        public Form1()
        {
            InitializeComponent();
            l = KTienIch.GEN();
        }

        private void key_DoubleClick(object sender, EventArgs e)
        {
            key.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ma.Text.Equals(""))
            {
                MessageBox.Show("Chưa nhập mã đăng ký!", "Hệ thống cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                string MAU = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string _ma = ma.Text;
                int tong = 0;
                List<int> test = new List<int>();
                for (int i = 0; i < _ma.Length; i++)
                {
                    for (int j = 0; j < MAU.Length; j++)
                    {
                        if (_ma[i].Equals(MAU[j]))
                        {
                            tong += j;
                            test.Add(j);
                        }
                    }
                }
                key.Text = l[tong];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}