using System;
using System.Windows.Forms;

namespace k29vnAU
{
    public partial class AutoUpdateTvanTool : Form
    {
        #region khai báo
        string _urlDownload = string.Empty;
        private const string StrStatus = "k29vn Auto Update Tool";
        readonly string _urlFolderSave = "C:\\VDC-IT VNPT\\VNPT-TAX\\";   //Đường dẫn thư mục mặc định (sẽ được set lại ngay khi khởi động)

        string _strVerTemp = string.Empty;
        string _urlSaveTemp = string.Empty;

        private const string FileNameTvanFrmExe = "TVAN.Frm.exe";
        private const string LinkCheckVer = "http://vnpt-tax.vn/DownloadFile/vesion.html";
        private const string LinkDownloadVer = "http://vnpt-tax.vn/DownloadFile/linkvesionstand.html";
        #endregion

        public AutoUpdateTvanTool()
        {
            InitializeComponent();
            _urlFolderSave = Application.StartupPath + "\\"; //Set lại đường dẫn thư mục cho phù hợp
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
                Version verCurrent = System.Reflection.AssemblyName.GetAssemblyName(_urlFolderSave + FileNameTvanFrmExe).Version;
                string strVerCurrent = verCurrent.ToString();
                string strVer = Klib.AutoUpdateTVANTool.getVer(LinkCheckVer);
                if (!strVer.Equals(strVerCurrent))
                {
                    _urlDownload = Klib.AutoUpdateTVANTool.getVer(LinkDownloadVer);
                    string urlSave = Klib.AutoUpdateTVANTool.GetUrlSave(_urlDownload, _urlFolderSave);
                    string returnMsg;
                    byte[] tempData = Klib.AutoUpdateTVANTool.DL(_urlDownload, ProcessBar, lbMSGValue, lbProcessBar, out returnMsg);
                    if (tempData != null && tempData.Length != 0)
                    {
                        Application.DoEvents();
                        lbProcessBar.Refresh();
                        System.IO.FileStream newFile = new System.IO.FileStream(urlSave, System.IO.FileMode.Create);
                        newFile.Write(tempData, 0, tempData.Length);
                        newFile.Close();
                        Application.DoEvents();
                        lbProcessBar.Refresh();
                        if (MessageBox.Show("Đã tải xong bản cập nhật!\r\nBạn có muốn cài đặt bản cập nhật mới không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string[] nameFileTEMP = _urlDownload.Split('/');
                            if (nameFileTEMP[nameFileTEMP.Length - 1].IndexOf(".exe") >= 0)
                            {
                                //tải EXE
                                lbl1.Text = "Đang thực hiện cài đặt phiên bản mới\r\nXin vui lòng chờ trong giây lát....";
                                this.Text = string.Empty;
                                p1.Location = new System.Drawing.Point(0, 0);
                                p1.Dock = DockStyle.Fill;
                                p1.Visible = true;
                                System.Diagnostics.Process.Start(urlSave);
                                this.TopMost = true;
                                lbMSGValue.Text = "Đang thực hiện cài đặt";
                                Application.DoEvents();
                                timerStop.Start();
                                _strVerTemp = strVer;
                                _urlSaveTemp = urlSave;
                                exit = true;
                            }
                            else
                            {
                                //Tải ZIP
                                lbl1.Text = "Đang thực hiện cài đặt phiên bản mới\r\nXin vui lòng chờ trong giây lát....";
                                this.Text = string.Empty;
                                p1.Location = new System.Drawing.Point(0, 0);
                                p1.Dock = DockStyle.Fill;
                                p1.Visible = true;
                                this.TopMost = true;
                                lbMSGValue.Text = "Đang thực hiện cài đặt";
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
                            callTVAN_FRM_EXE();
                        }
                    }
                    else
                    {
                        //Error cụ thể: returnMSG
                        string[] MsgErr = System.Text.RegularExpressions.Regex.Split(returnMsg, "\r\n\r\n");
                        if (MsgErr[0].IndexOf("The remote server returned an error: (404) Not Found.") >= 0)
                        {
                            MessageBox.Show("Kết nối mạng bị lỗi\r\nBạn vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //MessageBox.Show(returnMSG);
                        //MessageBox.Show(lbMSGValue.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Could not load file or assembly") >= 0)
                {
                    MessageBox.Show("Không tìm thấy file " + _urlFolderSave + FileNameTvanFrmExe + "\r\nBạn vui lòng kiểm tra lại!\r\n\r\n( - Có thể thư mục cài đặt chương trình không phải là : " + _urlFolderSave + "\r\n- Có thể file " + FileNameTvanFrmExe + "đã bị xóa hoặc bị đổi tên ).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Message.IndexOf("The remote server returned an error: (404) Not Found.") >= 0)
                {
                    MessageBox.Show("Kết nối mạng bị lỗi\r\nBạn vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(ex.Message + "\r\n\r\n" + ex.StackTrace);
                }
            }
            if (!exit)
            {
                Application.Exit();
            }
        }

        int dem = 0;
        private void timerStop_Tick(object sender, EventArgs e)
        {
            dem++;
            if (dem == 2)
            {
                timerStop.Stop();
                lbl1.Text = "Hoàn tất quá trình cài đặt phiên bản mới";
                pictureBox1.Visible = false;
                this.Hide();
                lbMSGValue.Text = "Đã cập nhật thành công!";
                MessageBox.Show("Bạn đã cài đặt thành công phiên bản mới.\r\nPhiên bản hiện tại: " + _strVerTemp, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                callTVAN_FRM_EXE();
                if (System.IO.File.Exists(_urlSaveTemp)) System.IO.File.Delete(_urlSaveTemp);
                Application.Exit();
            }
        }

        bool chaytimerStopZIP = true;
        private void timerStopZIP_Tick(object sender, EventArgs e)
        {
            if (chaytimerStopZIP)
            {
                timerStopZIP.Stop();
                chaytimerStopZIP = false;
                string returnMSG = string.Empty;
                try
                {
                    bool kq = KWinZip.UnZipFile(_urlSaveTemp, out returnMSG);
                    if (kq)
                    {
                        lbl1.Text = "Hoàn tất quá trình cài đặt phiên bản mới";
                        pictureBox1.Visible = false;
                        this.Hide();
                        lbMSGValue.Text = "Đã cập nhật thành công!";
                        MessageBox.Show("Bạn đã cài đặt thành công phiên bản mới.\r\nPhiên bản hiện tại: " + _strVerTemp, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        callTVAN_FRM_EXE();
                        if (System.IO.File.Exists(_urlSaveTemp)) System.IO.File.Delete(_urlSaveTemp);
                        Application.Exit();
                    }
                    else
                    {
                        //
                    }
                }
                catch (Exception ex) 
                {
                    //MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
                    //Error cụ thể: returnMSG
                    string[] MsgErr = System.Text.RegularExpressions.Regex.Split(returnMSG, "\r\n\r\n");
                    if (MsgErr[0].IndexOf("The remote server returned an error: (404) Not Found.") >= 0)
                    {
                        MessageBox.Show("Kết nối mạng bị lỗi\r\nBạn vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(returnMSG);
                    }
                }
            }
        }

        private void callTVAN_FRM_EXE()
        {
            System.Diagnostics.Process.Start(_urlFolderSave + FileNameTvanFrmExe); //Run
        }
    }
}
