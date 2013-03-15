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
    public partial class Form2 : Form
    {
        int dem = 0;

        public Form2()
        {
            InitializeComponent();
        }

        public void SetValue(String str1, String str2)
        {
            textBox1.Text = str1;
            textBox2.Text = str2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập tên truy cập", "Hệ thống cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu truy cập", "Hệ thống cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                textBox2.Focus();
            }
            else
            {
                string u = "dhtvietnam";
                string p = "dhtvietnam12345";
                try
                {
                    List<string> kq = KTienIch.DocFile();
                    u = kq[0];
                    p = kq[1];
                }
                catch (Exception)
                {
                    //Quá trình đọc file bị lỗi, file chưa tồn tại thì lấy u và p mặc định
                }
                if (textBox1.Text.Equals(u) && textBox2.Text.Equals(p))
                {
                    //MessageBox.Show("Đăng Nhập Thành Công!");
                    this.Hide();
                    new Form1().Show();
                }
                else
                {
                    dem++;
                    if (dem == 4)
                    {
                        MessageBox.Show("Bạn đã nhập sai quá nhiều lần, chương trình sẽ thoát!");
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại!", "Hệ thống cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                Form3 f3 = new Form3();
                f3.MyGetData = new Form3.LayChuoi(SetValue);
                f3.ShowDialog();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login();
            }
        }
    }
}
