using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace VisualFrmTool
{
    public partial class Frmmain : Form
    {
        #region khai báo
        readonly bool _runUpdate;
        private static bool _checkVer;
        readonly string _nameUpdateTool;
        readonly string _linkCheckVer;   //link check ver
        #endregion

        public Frmmain()
        {
            InitializeComponent();
            lblVersion.Text = new AssemblyInfo(System.Reflection.Assembly.GetEntryAssembly()).Version;

            //đọc các giá trị config
            XDocument doc = XDocument.Load(Application.StartupPath + "\\Kconfig.xml");
            _runUpdate = bool.Parse(Kxml.GetValueOfXelement(doc, "runUpdate"));
            _nameUpdateTool = Kxml.GetValueOfXelement(doc, "nameUpdateTool");
            _linkCheckVer = Kxml.GetValueOfXelement(doc, "linkCheckVer");
        }

        private void Frmmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_checkVer && _runUpdate)
            {
                try
                {
                    Environment.CurrentDirectory = Application.StartupPath;
                    System.Diagnostics.Process.Start(_nameUpdateTool);
                }
                catch
                {
                    MessageBox.Show("Không tìm thấy công cụ cập nhật tự động", "Thông báo");
                }
                _checkVer = false;
                return;
            }
            if (e.CloseReason != CloseReason.UserClosing) return;
            //if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            //    e.Cancel = true;
        }

        private void Frmmain_Load(object sender, EventArgs e)
        {
            if (_runUpdate)
            {
                try
                {
                    string strVer = K29VnAuToolLib.GetVer(_linkCheckVer);
                    string strVerCurrent = K29VnAuToolLib.GetVerCurrent();
                    if (K29VnAuToolLib.CheckVersion(strVerCurrent, strVer))
                    {
                        string msg = "Phiên bản hiện tại của bạn là " + strVerCurrent + "!\r\nĐã có phiên bản mới " + strVer + "!\r\nBạn có muốn cập nhật không?";
                        if (MessageBox.Show(msg, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) _checkVer = true;
                    }
                    if (_checkVer) Application.Exit();
                }
                catch
                {
                    //không có mạng thì thôi
                }
            }
        }
    }
}
