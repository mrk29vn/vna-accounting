using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entities;
using Common;

namespace GUI
{
    public partial class frmLoad : Form
    {
        public frmLoad()
        {
            InitializeComponent();
        }

        private Server_Client.Server server;
        /// <summary>
        /// kiem tra file config
        /// </summary>
        private Common.Utilities lay = null;
        private void XuLy()
        {
            try
            {

                lay = new Common.Utilities();
                ServerConfig config = lay.ReadConfig();
                Luu.Server = "" + config.Server;
                Luu.IP = "" + config.Ip;
                Luu.Ports = Convert.ToInt32(0 + config.Port);
                if (config.Server == "client")
                {
                    this.Hide();
                    frmSQL fr = new frmSQL();
                    fr.Show();
                }
                else
                {
                    if (config.Server == "server")
                    {
                        server = new Server_Client.Server(Luu.Ports);
                        Luu.maychu = server;
                        this.Hide();
                        frmSQL fr = new frmSQL();
                        fr.Show();
                    }
                    else
                    {
                        timer1.Stop();
                        count = 0;
                        RunCount = 0;
                        frmServerConfig frm = new frmServerConfig();
                        frm.ShowDialog();
                        timer1.Start();
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); Application.Exit(); }
        }

        /// <summary>
        /// chay thoi gian
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLoad_Load(object sender, EventArgs e)
        {
            new Klib.Klib().KTime();
            Luu.GKOK = Klib2.KTienIch.GEN();
            timer1.Start();
            try
            {
                frmBaoCaorpt a = new frmBaoCaorpt("Test");
                a.Close();
            }
            catch { }
        }

        /// <summary>
        /// dong lai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn muốn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        timer1.Stop();
                        this.Close();
                    }
                    else
                    { timer1.Start(); }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        /// <summary>
        /// chay thanh trang thai
        /// </summary>
        private int count = 0;
        private static int RunCount;
        private void UpdateProhress()
        {
            try
            {
                count++;
                int total = 100;
                RunCount = count * 100 / total;
                if (count == 2)
                {
                    progress_Bar.Value = total;
                    progress_Bar_1.Value = total;
                    progress_Bar_2.Value = total;
                }
                if (count == 3)
                {
                    timer1.Stop();
                    count = 0;
                    XuLy();
                    progress_Bar.Value = 0;
                    progress_Bar_1.Value = 0;
                    progress_Bar_2.Value = 0;
                }
            }
            catch(Exception ex)
            { string s = ex.Message.ToString(); }
        }

        /// <summary>
        /// su kien thoi gian
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateProhress();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XuLy();
        }
    }
}
