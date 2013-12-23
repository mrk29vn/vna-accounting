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
        bool mahoa = true;

        public frmKey(bool _mahoa)
        {
            InitializeComponent();
            this.mahoa = _mahoa;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string strPregNew = "nsVPovFETgTaPeS+iEsXJlMal2WvNwfgz9kDZSAyEh//Fqb3wxMHeNTr8rAkklj3"; //PatchNew
            //string strPreg = "W3nmTi15jP53j3sfv0JMlaY16oUK5Qric10i7Hvxl/rNlQPcX2Xehp1/+nMT2mAZ";    //PatchOld
            if (string.IsNullOrEmpty(textBox2.Text)) MessageBox.Show("Chưa nhập key đăng ký!", "Hệ thống cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            else
            {
                if (TienIch.isTrueKey(textBox2.Text))
                {
                    DateTime hientai = Utils.GetDateTimeNow(Luu.Server);
                    DateTime tuonglai = hientai.AddYears(2);
                    string now = hientai.Month + "/" + hientai.Day + "/" + hientai.Year;
                    string future = tuonglai.Month + "/" + tuonglai.Day + "/" + tuonglai.Year;
                    //Lưu lại
                    string key1 = "sk29vnbd2988";
                    string key2 = "ek29vnkt2988";
                    string key3 = "kk29vnkk2988";
                    string value_key1 = Klib2.KEnDe.DS(now);
                    string value_key2 = Klib2.KEnDe.DS(future);
                    string value_key3 = Klib2.KEnDe.DS(textBox2.Text);

                    List<string> l0 = new List<string>() { key1, key2, key3 };
                    List<string> l1 = new List<string>() { value_key1, value_key2, value_key3 };
                    List<List<string>> l = new List<List<string>>(); l.Add(l0); l.Add(l1);
                    string bientam = Klib2.KEnDe.MrkKEY; Klib2.KEnDe.MrkKEY = string.Empty;
                    string SubK = Klib2.KEnDe.ES(strPregNew);
                    try
                    {
                        Klib2.Registry.SetRegistry(SubK, l);
                    }
                    catch { MessageBox.Show("không thể cấu hình phần mềm, xin vui lòng kiểm tra lại máy tính của bạn!"); Application.Exit(); }
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
                    else MessageBox.Show("Mã Key không hợp lệ !");
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
            textBox2.Text = string.Empty;
            textBox2.Focus();
        }
    }
}
