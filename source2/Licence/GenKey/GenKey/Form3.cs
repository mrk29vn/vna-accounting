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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public delegate void LayChuoi(String str1, String str2);
        public LayChuoi MyGetData;

        private void button1_Click(object sender, EventArgs e)
        {
            reg();
        }

        private void reg()
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
                string p = "dhtvietnam12345";
                try
                {
                    List<string> kq = KTienIch.DocFile();
                    p = kq[1];
                }
                catch (Exception)
                {
                    //Quá trình đọc file bị lỗi, file chưa tồn tại thì lấy u và p mặc định
                }
                if (textBox3.Text.Equals(""))
                {
                    MessageBox.Show("Chưa nhập mật khẩu cũ");
                    textBox3.Focus();
                }
                else if (textBox3.Text.Equals(p))
                {
                    try
                    {
                        KTienIch.GhiFile(textBox1.Text, textBox2.Text);
                        MyGetData(textBox1.Text, textBox2.Text);
                        MessageBox.Show("Đăng ký thành công!");
                        this.Close();
                    }
                    catch { MessageBox.Show("Ghi Thất Bại"); }
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ chưa chính xác!");
                    textBox3.Focus();
                }
                
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                reg();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                reg();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                reg();
            }
        }
    }
}
