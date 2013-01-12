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
    public partial class frmKey : Form
    {
        int dem = 0;
        public frmKey()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("Chưa nhập key đăng ký!", "Hệ thống cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                string MAU = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string _ma = textBox1.Text;
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
                if (textBox2.Text.Equals(Luu.GKOK[tong]))
                {
                    DateTime hientai = DateServer.Date();
                    DateTime tuonglai = hientai.AddYears(2);
                    string now = hientai.Month + "/" + hientai.Day + "/" + hientai.Year;
                    string future = tuonglai.Month + "/" + tuonglai.Day + "/" + tuonglai.Year;
                    //Lưu lại
                    List<string> l0 = new List<string>() { "bd", "kt", "k" };
                    List<string> l1 = new List<string>() { now, future, textBox2.Text };
                    List<List<string>> l = new List<List<string>>();
                    l.Add(l0);
                    l.Add(l1);
                    string bientam = Klib2.KEnDe.MrkKEY;
                    Klib2.KEnDe.MrkKEY = "k29vn - Đặng Đức Kiên";
                    string SubK = Klib2.KEnDe.ES("W3nmTi15jP53j3sfv0JMlaY16oUK5Qric10i7Hvxl/rNlQPcX2Xehp1/+nMT2mAZ");
                    Klib2.Registry.SetRegistry(SubK, l);
                    Klib2.KEnDe.MrkKEY = bientam;
                    MessageBox.Show("Đăng ký thành công! \r\nKhởi động lại chương trình...");
                    Application.Exit();

                }
                else
                {
                    dem++;
                    if (dem == 4)
                    {
                        MessageBox.Show("Bạn đã nhập sai Key nhiều lần, chương trình sẽ tự động thoát!");
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Mã Key không hợp lệ !");
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmKey_Load(object sender, EventArgs e)
        {
            textBox1.Text = TienIch.GetMainOrHDD();
            textBox2.Text = "";
            textBox2.Focus();
        }
    }
}
