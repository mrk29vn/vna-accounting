using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;

namespace GUI
{
    public static class DateServer
    {
        public static TcpClient client1;
        public static NetworkStream clientstrem;
        public static DateTime Date()
        {
            return "Datetime".GetDataFromServer<DateTime>();
            //Server_Client.Client cl = new Server_Client.Client();
            //client1 = cl.Connect(Luu.IP, Luu.Ports);
            //Entities.CheckRefer pt = new Entities.CheckRefer();
            //clientstrem = cl.SerializeObj(client1, "Datetime", pt);
            //DateTime dt = new DateTime();
            //dt = (DateTime)cl.DeserializeHepper(clientstrem, dt);
            //return dt;
        }
    }
    public class Check
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        public bool CheckReference(string tenTruong, string maTruong)
        {
            try
            {
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer pt = new Entities.CheckRefer(tenTruong, maTruong);
                bool kt = false;
                clientstrem = cl.SerializeObj(this.client1, "CheckRefer", pt);
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                return kt;
            }
            catch
            {
                return false;
            }
        }
    }

    public class TienIch
    {
        public bool checkFULL()
        {
            bool kq = false;
            string strPreg = "W3nmTi15jP53j3sfv0JMlaY16oUK5Qric10i7Hvxl/rNlQPcX2Xehp1/+nMT2mAZ";    //Old
            string strPreg1 = "nsVPovFETgTaPeS+iEsXJlMal2WvNwfgz9kDZSAyEh//Fqb3wxMHeNTr8rAkklj3";   //New
            //if (!(!checkFULL(strPreg) && !checkFULL(strPreg1))) return true;
            if (checkFULL(strPreg1, true)) return true;
            else if (checkFULL(strPreg, false)) return true;
            return kq;
        }
        public bool checkFULL(string strPreg, bool mahoa)
        {
            bool kq = false;
            try
            {
                //string strPreg = "W3nmTi15jP53j3sfv0JMlaY16oUK5Qric10i7Hvxl/rNlQPcX2Xehp1/+nMT2mAZ";
                //Get Thông Tin
                string bientam = Klib2.KEnDe.MrkKEY;
                Klib2.KEnDe.MrkKEY = "k29vn - Đặng Đức Kiên";
                string SubK = Klib2.KEnDe.ES(strPreg);
                List<List<string>> tem = Klib2.Registry.GetRegistry(SubK);
                Klib2.KEnDe.MrkKEY = bientam;
                if (tem.Count > 0)
                {
                    string key1 = mahoa ? "sk29vnbd2988" : "bd";
                    string key2 = mahoa ? "ek29vnkt2988" : "kt";
                    string key3 = mahoa ? "kk29vnkk2988" : "k";

                    if (tem[0].Contains(key1) || tem[0].Contains(key2) || tem[0].Contains(key3)) //Kiểm tra REG
                    {//Đã từng sử dụng
                        DateTime hientai = Utils.GetDateTimeNow(Luu.Server);
                        DateTime batdau = DateTime.Parse(mahoa ? Klib2.KEnDe.ES(GET(key1, tem)) : GET(key1, tem));
                        DateTime ketthuc = DateTime.Parse(mahoa ? Klib2.KEnDe.ES(GET(key2, tem)) : GET(key2, tem));
                        string getKey3Tem = mahoa ? Klib2.KEnDe.ES(GET(key3, tem)) : GET(key3, tem);
                        if (isTrueKey(getKey3Tem)) //Kiểm tra KEY
                        {//KEY Full
                            if ((hientai >= batdau) && (hientai <= ketthuc)) kq = true;
                        }
                    }
                }
            }
            catch { }
            return kq;
        }

        string GET(string ten, List<List<string>> l)
        {
            string kq = string.Empty;
            for (int i = 0; i < l[0].Count; i++) { if (l[0][i].Equals(ten)) kq = l[1][i]; }
            return kq;
        }

        public static bool isTrueKey(string strCheck)
        {
            if (Luu.GKOK.Count <= 0) Luu.GKOK = Klib2.KTienIch.GEN();
            string temtem = GetMainOrHDD();
            string MAU = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string _ma = temtem;
            int tong = 0;
            List<int> test = new List<int>();
            for (int i = 0; i < _ma.Length; i++)
            {
                for (int j = 0; j < MAU.Length; j++)
                {
                    if (_ma[i].Equals(MAU[j])) { tong += j; test.Add(j); }
                }
            }
            if (strCheck.Equals(Luu.GKOK[tong])) return true;
            else return false;
        }

        public static string HDDID()
        {
            System.Management.ManagementClass partionsClass = new System.Management.ManagementClass("Win32_LogicalDisk");
            System.Management.ManagementObjectCollection partions = partionsClass.GetInstances();
            string hdd = string.Empty;
            foreach (System.Management.ManagementObject partion in partions)
            { hdd = Convert.ToString(partion["VolumeSerialNumber"]); if (hdd != string.Empty) return hdd; }
            return hdd;
        }

        public static string GetMainOrHDD()
        {
            return HDDID();
            #region temp
            //string bientamthoi = HardwareMotherboardID.nsMotherBoardID.MotherBoardID.GetMotherBoardID();
            //if (bientamthoi.Equals("N/A                                                             ") || bientamthoi.Equals("N/A") || bientamthoi == null || bientamthoi.Equals("None") || bientamthoi.Equals("Base Board Serial Number"))
            //{
            //return HDDID();
            //}
            //else
            //{
            //    return bientamthoi;
            //}
            #endregion
        }

        public void AutoFormatMoney(object sender)
        {
            try
            {
                TextBox temp = (TextBox)sender;
                int vt = temp.SelectionStart;
                string str = new string(temp.Text.Replace(",", "").ToList<char>().Where(c => char.IsNumber(c)).ToArray<char>());
                temp.Text = FormatMoney(str);
                temp.SelectionStart = temp.Text.Length;
            }
            catch { }
        }

        /// <summary>
        /// Tự động định dạng với AutoFormat
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="okTextBox">TRUE: TextBox, FALSE: ToolStripTextBox</param>
        /// <param name="okMoney">TRUE: FormatMoney, FALSE: InputINT</param>
        public void AutoFormat(object sender, bool okTextBox, bool okMoney)
        {
            try
            {
                if (okTextBox && okMoney)
                {//FormatMoney For TextBox
                    TextBox temp = (TextBox)sender;
                    int vt = temp.SelectionStart;
                    string str = new string(temp.Text.Replace(",", "").ToList<char>().Where(c => char.IsNumber(c)).ToArray<char>());
                    temp.Text = FormatMoney(str);
                    temp.SelectionStart = temp.Text.Length;
                }
                else if (!okTextBox && okMoney)
                {//FormatMoney For ToolStripTextBox
                    ToolStripTextBox temp = (ToolStripTextBox)sender;
                    int vt = temp.SelectionStart;
                    string str = new string(temp.Text.Replace(",", "").ToList<char>().Where(c => char.IsNumber(c)).ToArray<char>());
                    temp.Text = FormatMoney(str);
                    temp.SelectionStart = temp.Text.Length;
                }
                else if (okTextBox && !okMoney)
                {//InputINT For TextBox
                    TextBox temp = (TextBox)sender;
                    int vt = temp.SelectionStart;
                    string str = new string(temp.Text.ToList<char>().Where(c => char.IsNumber(c)).ToArray<char>());
                    temp.Text = str;
                    temp.SelectionStart = temp.Text.Length;
                }
                else if (!okTextBox && !okMoney)
                {//InputINT For ToolStripTextBox
                    ToolStripTextBox temp = (ToolStripTextBox)sender;
                    int vt = temp.SelectionStart;
                    string str = new string(temp.Text.ToList<char>().Where(c => char.IsNumber(c)).ToArray<char>());
                    temp.Text = str;
                    temp.SelectionStart = temp.Text.Length;
                }
            }
            catch { }
        }

        public string FormatMoney(string money)
        {
            if (double.Parse(money) >= 0 && double.Parse(money) < 10)
                return money;
            string str = "";
            try
            {
                if (double.Parse(money) < 0)
                    str = String.Format("{0,-0:0,0}", double.Parse(money));
                else
                    str = String.Format("{0:0,0}", double.Parse(money));
            }
            catch { return ""; }
            return str;
        }

        public static Entities.DiemThuongKhachHang DiemThuongKhachHang_TO_DiemThuongKhachHang(Entities.DiemThuongKhachHang dtkh)
        {
            Entities.DiemThuongKhachHang kq = new Entities.DiemThuongKhachHang();
            kq.MaDiemThuongKhachHang = dtkh.MaDiemThuongKhachHang;
            kq.MaKhachHang = dtkh.MaKhachHang;
            kq.TenKhachHang = dtkh.TenKhachHang;
            kq.TongDiem = dtkh.TongDiem;
            kq.DiemDaDung = dtkh.DiemDaDung;
            kq.DiemConLai = dtkh.DiemConLai;
            kq.GhiChu = dtkh.GhiChu;
            kq.Deleted = dtkh.Deleted;
            return kq;
        }

        public static List<double> TinhDoanhThu(double TT, double vip, double uudai)
        {
            double UseVIP = 0;
            double UseUD = 0;
            double DT = 0;
            List<double> kq = new List<double>();
            if (TT - vip < 0)
            {
                DT = 0;
                UseVIP = TT;
                UseUD = 0;
            }
            else if (TT - vip == 0)
            {
                DT = 0;
                UseVIP = vip;
                UseUD = 0;
            }
            else
            {
                if (TT - vip - uudai < 0)
                {
                    DT = 0;
                    UseVIP = vip;
                    UseUD = TT - vip;
                }
                else if (TT - vip - uudai == 0)
                {
                    DT = 0;
                    UseVIP = vip;
                    UseUD = uudai;
                }
                else
                {
                    DT = TT - vip - uudai;
                    UseVIP = vip;
                    UseUD = uudai;
                }
            }
            kq.Add(TT);
            kq.Add(UseVIP);
            kq.Add(UseUD);
            kq.Add(DT);
            return kq;
        }
    }
}
