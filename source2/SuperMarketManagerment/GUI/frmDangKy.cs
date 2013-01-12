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
    public partial class frmDangKy : Form
    {
        bool FULL = false;

        public frmDangKy()
        {
            InitializeComponent();
            GetThongTin();
        }

        private void GetThongTin()
        {
            //Get Thông Tin
            string bientam = Klib2.KEnDe.MrkKEY;
            Klib2.KEnDe.MrkKEY = "k29vn - Đặng Đức Kiên";
            string SubK = Klib2.KEnDe.ES("W3nmTi15jP53j3sfv0JMlaY16oUK5Qric10i7Hvxl/rNlQPcX2Xehp1/+nMT2mAZ");
            List<List<string>> tem = Klib2.Registry.GetRegistry(SubK);
            Klib2.KEnDe.MrkKEY = bientam;
            if (tem.Count > 0)
            {
                if (tem[0].Contains("bd") || tem[0].Contains("kt") || tem[0].Contains("k")) //Kiểm tra REG
                {//Đã từng sử dụng
                    DateTime hientai = new DateTime();
                    if (Luu.Server.Equals("client"))
                    {
                        try
                        {
                            hientai = DateServer.Date();
                        }
                        catch
                        {
                            hientai = DateTime.Now;
                        }
                    }
                    else if (Luu.Server.Equals("server"))
                    {
                        hientai = DateTime.Now;
                    }
                    DateTime batdau = DateTime.Parse(GET("bd", tem));
                    DateTime ketthuc = DateTime.Parse(GET("kt", tem));
                    string temtem = TienIch.GetMainOrHDD();
                    string MAU = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    string _ma = temtem;
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
                    if (GET("k", tem).Equals(Luu.GKOK[tong])) //Kiểm tra KEY
                    {//KEY Full
                        if ((hientai >= batdau) && (hientai <= ketthuc))
                        {
                            progressBarTime.Value = (int)PHANTRAM(hientai, batdau, ketthuc);
                            lblMSG.Text = "Bạn còn " + (ketthuc - hientai).TotalDays + " Ngày dùng thử!";
                            FULL = true;
                            Luu.KFULL = true;
                            //this.Hide();
                            //loginOK();
                        }
                        else
                        {
                            progressBarTime.Value = 100;
                            lblMSG.Text = "Bạn còn 0 Ngày dùng thử!";
                            Luu.KFULL = false;
                            return; //Show frmDangKy
                        }
                    }
                    else
                    {//KEY TRIAL
                        if ((hientai >= batdau) && (hientai <= ketthuc))
                        {//Ngày dùng của KEY TRIAL
                            progressBarTime.Value = (int)Math.Round(PHANTRAM(hientai, batdau, ketthuc));
                            lblMSG.Text = "Bạn còn " + Math.Round((ketthuc - hientai).TotalDays) + " Ngày dùng thử!";
                            Luu.KFULL = false;
                            return; //Show frmDangKy
                        }
                        else
                        {//Hệt hạn dùng KEY TRIAL
                            progressBarTime.Value = 100;
                            lblMSG.Text = "Bạn còn 0 Ngày dùng thử!";
                            MessageBox.Show("Hết hạn dùng thử");
                            Luu.KFULL = false;
                            //Application.Exit();
                            return;
                        }
                    }
                }
                else
                {//Chưa từng sử dụng
                    DateTime hientai = DateServer.Date();
                    DateTime tuonglai = hientai.AddDays(30);
                    string now = hientai.Month + "/" + hientai.Day + "/" + hientai.Year;
                    string future = tuonglai.Month + "/" + tuonglai.Day + "/" + tuonglai.Year;
                    progressBarTime.Value = 0;
                    lblMSG.Text = "Bạn còn 30 Ngày dùng thử!";
                    Luu.KFULL = false;
                    //Lưu lại
                    List<string> l0 = new List<string>() { "bd", "kt", "k" };
                    List<string> l1 = new List<string>() { now, future, "" };
                    List<List<string>> l = new List<List<string>>();
                    l.Add(l0);
                    l.Add(l1);
                    bientam = Klib2.KEnDe.MrkKEY;
                    Klib2.KEnDe.MrkKEY = "k29vn - Đặng Đức Kiên";
                    SubK = Klib2.KEnDe.ES("W3nmTi15jP53j3sfv0JMlaY16oUK5Qric10i7Hvxl/rNlQPcX2Xehp1/+nMT2mAZ");
                    Klib2.Registry.SetRegistry(SubK, l);
                    Klib2.KEnDe.MrkKEY = bientam;
                }
            }
            else
            {
                progressBarTime.Value = 0;
                lblMSG.Text = "Bạn còn 30 Ngày dùng thử!";
                Luu.KFULL = false;
                Application.Exit();
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frmKey key = new frmKey();
            key.ShowDialog();
        }

        private void btnDungThu_Click(object sender, EventArgs e)
        {
            if (progressBarTime.Value == 100)
            {
                MessageBox.Show("Hết hạn dùng thử\r\nVui lòng đăng ký chương trình");
            }
            else
            {
                loginOK();
            }
        }

        private void loginOK()
        {
            this.Hide();
            frmDangNhap fr = new frmDangNhap();
            fr.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        string GET(string ten,List<List<string>> l)
        {
            string kq = "";
            for (int i = 0; i < l[0].Count; i++)
            {
                if (l[0][i].Equals(ten))
                {
                    kq = l[1][i];
                }
            }
            return kq;
        }
          
        double PHANTRAM(DateTime hientai, DateTime batdau, DateTime ketthuc)
        {
            double tong = (ketthuc - batdau).TotalDays;
            double now = (hientai - batdau).TotalDays;
            return (now * 100) / tong;
        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {
            if (FULL)
            {
                this.Hide();
            }
        }
    }
}
