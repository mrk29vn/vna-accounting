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
        bool _mahoa = true;

        public frmDangKy()
        {
            InitializeComponent();
            GetThongTin();
        }

        List<List<string>> CheckThongTinNguoiDung(string strPatch)
        {
            //Get Thông Tin người dùng mới
            string bientam = Klib2.KEnDe.MrkKEY; Klib2.KEnDe.MrkKEY = string.Empty;
            string SubK = Klib2.KEnDe.ES(strPatch);
            List<List<string>> kq = Klib2.Registry.GetRegistry(SubK); Klib2.KEnDe.MrkKEY = bientam;
            return kq;
        }

        private void GetThongTin()
        {
            string strPregNew = "nsVPovFETgTaPeS+iEsXJlMal2WvNwfgz9kDZSAyEh//Fqb3wxMHeNTr8rAkklj3"; //PatchNew
            string strPreg = "W3nmTi15jP53j3sfv0JMlaY16oUK5Qric10i7Hvxl/rNlQPcX2Xehp1/+nMT2mAZ";    //PatchOld

            //Get Thông Tin người dùng mới
            List<List<string>> List_strPregPatch = CheckThongTinNguoiDung(strPregNew);
            //kiểm tra xem có dữ liệu người dùng mới không?
            if (List_strPregPatch.Count > 0) _mahoa = true; //có dữ liệu người dùng mới
            else
            {//không có dữ liệu người dùng mới thì check dữ liệu người dùng cũ
                List_strPregPatch = CheckThongTinNguoiDung(strPreg);
                if (List_strPregPatch.Count > 0) _mahoa = false;    //có dữ liệu người dùng cũ
                else   //không có dữ liệu người dùng cũ
                { progressBarTime.Value = 0; lblMSG.Text = "Bạn còn 30 Ngày dùng thử!"; Luu.KFULL = false; Application.Exit(); }
            }

            string key1 = _mahoa ? "sk29vnbd2988" : "bd";
            string key2 = _mahoa ? "ek29vnkt2988" : "kt";
            string key3 = _mahoa ? "kk29vnkk2988" : "k";
            if (List_strPregPatch[0].Contains(key1) || List_strPregPatch[0].Contains(key2) || List_strPregPatch[0].Contains(key3)) //Kiểm tra REG
            {//Đã từng sử dụng
                DateTime hientai = Utils.GetDateTimeNow(Luu.Server);
                DateTime batdau = DateTime.Parse(_mahoa ? Klib2.KEnDe.ES(GET(key1, List_strPregPatch)) : GET(key1, List_strPregPatch));
                DateTime ketthuc = DateTime.Parse(_mahoa ? Klib2.KEnDe.ES(GET(key2, List_strPregPatch)) : GET(key2, List_strPregPatch));

                string getKey3Tem = _mahoa ? Klib2.KEnDe.ES(GET(key3, List_strPregPatch)) : GET(key3, List_strPregPatch);
                if (TienIch.isTrueKey(getKey3Tem)) //Kiểm tra KEY
                {//KEY Full
                    if ((hientai >= batdau) && (hientai <= ketthuc))
                    {
                        progressBarTime.Value = (int)PHANTRAM(hientai, batdau, ketthuc); lblMSG.Text = "Bạn còn " + (ketthuc - hientai).TotalDays + " Ngày dùng thử!";
                        FULL = true;
                        Luu.KFULL = true; //this.Hide(); //loginOK();
                    }
                    else
                    {
                        progressBarTime.Value = 100; lblMSG.Text = "Bạn còn 0 Ngày dùng thử!";
                        Luu.KFULL = false;
                        return; //Show frmDangKy
                    }
                }
                else
                {//KEY TRIAL
                    if ((hientai >= batdau) && (hientai <= ketthuc))
                    {//Ngày dùng của KEY TRIAL
                        progressBarTime.Value = (int)Math.Round(PHANTRAM(hientai, batdau, ketthuc)); lblMSG.Text = "Bạn còn " + Math.Round((ketthuc - hientai).TotalDays) + " Ngày dùng thử!";
                        Luu.KFULL = false;
                        return; //Show frmDangKy
                    }
                    else
                    {//Hệt hạn dùng KEY TRIAL
                        progressBarTime.Value = 100; lblMSG.Text = "Bạn còn 0 Ngày dùng thử!"; MessageBox.Show("Hết hạn dùng thử");
                        Luu.KFULL = false; //Application.Exit();
                        return;
                    }
                }
            }
            else
            {//Chưa từng sử dụng
                DateTime hientai = Utils.GetDateTimeNow(Luu.Server);
                DateTime tuonglai = hientai.AddDays(30);
                string now = hientai.Month + "/" + hientai.Day + "/" + hientai.Year;
                string future = tuonglai.Month + "/" + tuonglai.Day + "/" + tuonglai.Year;
                progressBarTime.Value = 0; lblMSG.Text = "Bạn còn 30 Ngày dùng thử!"; Luu.KFULL = false;
                //Lưu lại
                key1 = "sk29vnbd2988";
                key2 = "ek29vnkt2988";
                key3 = "kk29vnkk2988";
                string value_key1 = Klib2.KEnDe.DS(now);
                string value_key2 = Klib2.KEnDe.DS(future);
                string value_key3 = string.Empty;

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
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frmKey key = new frmKey(_mahoa);
            key.ShowDialog();
        }

        private void btnDungThu_Click(object sender, EventArgs e)
        {
            if (progressBarTime.Value == 100) MessageBox.Show("Hết hạn dùng thử\r\nVui lòng đăng ký chương trình");
            else loginOK();
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

        string GET(string ten, List<List<string>> l)
        {
            string kq = "";
            for (int i = 0; i < l[0].Count; i++)
            {
                if (l[0][i].Equals(ten)) kq = l[1][i];
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
            if (FULL) this.Hide();
        }
    }
}
