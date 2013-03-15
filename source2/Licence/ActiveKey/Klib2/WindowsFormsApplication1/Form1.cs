using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<string> GKOK = new List<string>();

        public Form1()
        {
            InitializeComponent();
            GKOK = Klib2.KTienIch.GEN();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //bool kq = checkFULL();
            //if (kq) MessageBox.Show("Thành công");
            GetThongTin();
        }

        public bool checkFULL()
        {
            bool kq = false;
            try
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
                        hientai = DateTime.Now;
                        DateTime batdau = DateTime.Parse(GET("bd", tem));
                        DateTime ketthuc = DateTime.Parse(GET("kt", tem));
                        string temtem = GetMainOrHDD();
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
                        if (GET("k", tem).Equals(GKOK[tong])) //Kiểm tra KEY
                        {//KEY Full
                            if ((hientai >= batdau) && (hientai <= ketthuc))
                            {
                                kq = true;
                            }
                        }
                    }
                }
            }
            catch { }
            return kq;
        }

        string GET(string ten, List<List<string>> l)
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

        public static string GetMainOrHDD()
        {
            System.Management.ManagementClass partionsClass = new System.Management.ManagementClass("Win32_LogicalDisk");
            System.Management.ManagementObjectCollection partions = partionsClass.GetInstances();
            string hdd = string.Empty;
            foreach (System.Management.ManagementObject partion in partions)
            {
                hdd = Convert.ToString(partion["VolumeSerialNumber"]);

                if (hdd != string.Empty)
                    return hdd;
            }
            return hdd;
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
                    hientai = DateTime.Now;
                    DateTime batdau = DateTime.Parse(GET("bd", tem));
                    DateTime ketthuc = DateTime.Parse(GET("kt", tem));
                    string temtem = GetMainOrHDD();
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
                    if (GET("k", tem).Equals(GKOK[tong])) //Kiểm tra KEY
                    {//KEY Full
                        if ((hientai >= batdau) && (hientai <= ketthuc))
                        {
                            //progressBarTime.Value = (int)PHANTRAM(hientai, batdau, ketthuc);
                            //lblMSG.Text = "Bạn còn " + (ketthuc - hientai).TotalDays + " Ngày dùng thử!";
                            //FULL = true;
                            //Luu.KFULL = true;
                            //this.Hide();
                            //loginOK();
                        }
                        else
                        {
                            //progressBarTime.Value = 100;
                            //lblMSG.Text = "Bạn còn 0 Ngày dùng thử!";
                            //Luu.KFULL = false;
                            return; //Show frmDangKy
                        }
                    }
                    else
                    {//KEY TRIAL
                        if ((hientai >= batdau) && (hientai <= ketthuc))
                        {//Ngày dùng của KEY TRIAL
                            //progressBarTime.Value = (int)Math.Round(PHANTRAM(hientai, batdau, ketthuc));
                            //lblMSG.Text = "Bạn còn " + Math.Round((ketthuc - hientai).TotalDays) + " Ngày dùng thử!";
                            //Luu.KFULL = false;
                            return; //Show frmDangKy
                        }
                        else
                        {//Hệt hạn dùng KEY TRIAL
                            //progressBarTime.Value = 100;
                            //lblMSG.Text = "Bạn còn 0 Ngày dùng thử!";
                            MessageBox.Show("Hết hạn dùng thử");
                            //Luu.KFULL = false;
                            //Application.Exit();
                            return;
                        }
                    }
                }
                else
                {//Chưa từng sử dụng
                    DateTime hientai = DateTime.Now;
                    DateTime tuonglai = hientai.AddDays(30);
                    string now = hientai.Month + "/" + hientai.Day + "/" + hientai.Year;
                    string future = tuonglai.Month + "/" + tuonglai.Day + "/" + tuonglai.Year;
                    //progressBarTime.Value = 0;
                    //lblMSG.Text = "Bạn còn 30 Ngày dùng thử!";
                    //Luu.KFULL = false;
                    //Lưu lại
                    List<string> l0 = new List<string>() { "bd", "kt", "k" };
                    List<string> l1 = new List<string>() { now, future, "" };
                    List<List<string>> l = new List<List<string>>();
                    l.Add(l0);
                    l.Add(l1);
                    bientam = Klib2.KEnDe.MrkKEY;
                    Klib2.KEnDe.MrkKEY = "k29vn - Đặng Đức Kiên";
                    SubK = Klib2.KEnDe.ES("W3nmTi15jP53j3sfv0JMlaY16oUK5Qric10i7Hvxl/rNlQPcX2Xehp1/+nMT2mAZ");
                    try
                    {
                        Klib2.Registry.SetRegistry(SubK, l);
                    }
                    catch (Exception ex) { MessageBox.Show("Reg is No"); }
                    Klib2.KEnDe.MrkKEY = bientam;
                }
            }
            else
            {
                //progressBarTime.Value = 0;
                //lblMSG.Text = "Bạn còn 30 Ngày dùng thử!";
                //Luu.KFULL = false;
                Application.Exit();
            }
        }
    }
}
