using System;
using System.Windows.Forms;
using System.Xml.Linq;
using k29vnAU.Properties;

namespace k29vnAU
{
    public partial class K29VnAuTool : Form
    {
        #region khai báo
        private const string StrStatus = "k29vn Auto Update Tool";

        readonly string _urlFolderSave = Application.StartupPath + "\\";   //Đường dẫn thư mục mặc định (sẽ được set lại ngay khi khởi động)
        string _strVerTemp = string.Empty;
        string _urlSaveTemp = string.Empty;
        string _urlDownload = string.Empty;

        //Load Config XML
        readonly string _nameFrmTool;   //tên công cụ chính
        readonly string _linkCheckVer;   //link check ver
        readonly string _linkDownloadVer;    //link download ver
        #endregion

        public K29VnAuTool()
        {
            InitializeComponent();

            //đọc các giá trị config
            XDocument doc = XDocument.Load(Application.StartupPath + "\\Kconfig.xml");
            _nameFrmTool = Kxml.GetValueOfXelement(doc, "nameFrmTool");
            _linkCheckVer = Kxml.GetValueOfXelement(doc, "linkCheckVer");
            _linkDownloadVer = Kxml.GetValueOfXelement(doc, "linkDownloadVer");

            Text = StrStatus;
            timer1.Start();
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        bool _chay = true;
        private void Timer1Tick(object sender, EventArgs e)
        {
            if (!_chay) return;
            _chay = false;
            timer1.Stop();
            Run();
        }

        private void Run()
        {
            bool exit = false;
            try
            {
                string strVer = K29VnAuToolLib.GetVer(_linkCheckVer);
                if (!strVer.Equals(System.Reflection.AssemblyName.GetAssemblyName(_urlFolderSave + _nameFrmTool).Version.ToString()))
                {
                    _urlDownload = K29VnAuToolLib.GetVer(_linkDownloadVer);
                    string urlSave = K29VnAuToolLib.GetUrlSave(_urlDownload, _urlFolderSave);
                    string returnMsg;
                    byte[] tempData = K29VnAuToolLib.Dl(_urlDownload, ProcessBar, lbMSGValue, lbProcessBar, out returnMsg);
                    if (tempData != null && tempData.Length != 0)
                    {
                        Application.DoEvents();
                        lbProcessBar.Refresh();
                        System.IO.FileStream newFile = new System.IO.FileStream(urlSave, System.IO.FileMode.Create);
                        newFile.Write(tempData, 0, tempData.Length);
                        newFile.Close();
                        Application.DoEvents();
                        lbProcessBar.Refresh();
                        if (MessageBox.Show(Resources.k29vnAuTool_Run_, Resources.k29vnAuTool_Run_Thông_báo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string[] nameFileTemp = _urlDownload.Split('/');
                            if (nameFileTemp[nameFileTemp.Length - 1].IndexOf(".exe", StringComparison.Ordinal) >= 0)
                            {
                                //tải EXE
                                lbl1.Text = Resources.k29vnAuTool_Run_;
                                Text = string.Empty;
                                p1.Location = new System.Drawing.Point(0, 0);
                                p1.Dock = DockStyle.Fill;
                                p1.Visible = true;
                                System.Diagnostics.Process.Start(urlSave);
                                TopMost = true;
                                lbMSGValue.Text = Resources.k29vnAuTool_Run_Đang_thực_hiện_cài_đặt;
                                Application.DoEvents();
                                timerStop.Start();
                                _strVerTemp = strVer;
                                _urlSaveTemp = urlSave;
                                exit = true;
                            }
                            else
                            {
                                //Tải ZIP
                                lbl1.Text = Resources.k29vnAuTool_Run_;
                                Text = string.Empty;
                                p1.Location = new System.Drawing.Point(0, 0);
                                p1.Dock = DockStyle.Fill;
                                p1.Visible = true;
                                TopMost = true;
                                lbMSGValue.Text = Resources.k29vnAuTool_Run_Đang_thực_hiện_cài_đặt;
                                Application.DoEvents();
                                timerStopZIP.Start();
                                _strVerTemp = strVer;
                                _urlSaveTemp = urlSave;
                                exit = true;
                            }
                        }
                        else
                        {
                            //xóa temp
                            if (System.IO.File.Exists(urlSave)) System.IO.File.Delete(urlSave);
                            CallFrmExe();
                        }
                    }
                    else
                    {
                        //Error cụ thể: returnMSG
                        string[] msgErr = System.Text.RegularExpressions.Regex.Split(returnMsg, "\r\n\r\n");
                        if (msgErr[0].IndexOf("The remote server returned an error: (404) Not Found.", StringComparison.Ordinal) >= 0)
                        {
                            MessageBox.Show(Resources.k29vnAuTool_Run_, Resources.k29vnAuTool_Run_Thông_báo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //MessageBox.Show(returnMSG);
                        //MessageBox.Show(lbMSGValue.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Could not load file or assembly", StringComparison.Ordinal) >= 0)
                {
                    MessageBox.Show(Resources.k29vnAuTool_Run_Không_tìm_thấy_file_ + _urlFolderSave + _nameFrmTool + Resources.k29vnAuTool_Run_ + _urlFolderSave + Resources.K29VnAuTool_Run_Cothefile + _nameFrmTool + Resources.K29VnAuTool_Run_đã_bị_xóa_hoặc_bị_đổi_tên___, Resources.k29vnAuTool_Run_Thông_báo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Message.IndexOf("The remote server returned an error: (404) Not Found.", StringComparison.Ordinal) >= 0)
                {
                    MessageBox.Show(Resources.k29vnAuTool_Run_, Resources.k29vnAuTool_Run_Thông_báo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message + Resources.k29vnAuTool_Run_ + ex.StackTrace);
                }
            }
            if (!exit)
            {
                Application.Exit();
            }
        }

        int _dem;
        private void TimerStopTick(object sender, EventArgs e)
        {
            _dem++;
            if (_dem != 2) return;
            timerStop.Stop();
            lbl1.Text = Resources.k29vnAuTool_TimerStopZipTick_Hoàn_tất_quá_trình_cài_đặt_phiên_bản_mới;
            pictureBox1.Visible = false;
            Hide();
            lbMSGValue.Text = Resources.k29vnAuTool_TimerStopZipTick_Đã_cập_nhật_thành_công_;
            MessageBox.Show(Resources.k29vnAuTool_timerStop_Tick_ + _strVerTemp, Resources.k29vnAuTool_Run_Thông_báo, MessageBoxButtons.OK, MessageBoxIcon.Information);
            CallFrmExe();
            if (System.IO.File.Exists(_urlSaveTemp)) System.IO.File.Delete(_urlSaveTemp);
            Application.Exit();
        }

        bool _chaytimerStopZip = true;
        private void TimerStopZipTick(object sender, EventArgs e)
        {
            if (!_chaytimerStopZip) return;
            timerStopZIP.Stop();
            _chaytimerStopZip = false;
            string returnMsg = string.Empty;
            try
            {
                bool kq = KWinZip.UnZipFile(_urlSaveTemp, out returnMsg);
                if (!kq) return;
                lbl1.Text = Resources.k29vnAuTool_TimerStopZipTick_Hoàn_tất_quá_trình_cài_đặt_phiên_bản_mới;
                pictureBox1.Visible = false;
                Hide();
                lbMSGValue.Text = Resources.k29vnAuTool_TimerStopZipTick_Đã_cập_nhật_thành_công_;
                MessageBox.Show(Resources.k29vnAuTool_TimerStopZipTick_ + _strVerTemp, Resources.k29vnAuTool_Run_Thông_báo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                CallFrmExe();
                if (System.IO.File.Exists(_urlSaveTemp)) System.IO.File.Delete(_urlSaveTemp);
                Application.Exit();
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
                //Error cụ thể: returnMSG
                string[] msgErr = System.Text.RegularExpressions.Regex.Split(returnMsg, "\r\n\r\n");
                if (msgErr[0].IndexOf("The remote server returned an error: (404) Not Found.", StringComparison.Ordinal) >= 0)
                {
                    MessageBox.Show(Resources.k29vnAuTool_TimerStopZipTick_, Resources.k29vnAuTool_Run_Thông_báo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(returnMsg);
                }
            }
        }

        private void CallFrmExe()
        {
            System.Diagnostics.Process.Start(_urlFolderSave + _nameFrmTool); //Run
        }
    }
}
