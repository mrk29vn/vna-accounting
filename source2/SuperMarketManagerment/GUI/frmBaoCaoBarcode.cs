using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using Entities;

namespace GUI
{
    public partial class frmBaoCaoBarcode : Form
    {
        #region Khai báo
        readonly MaVachThe[] _maVach;
        public Barcode[] Code { get; set; }
        public int Banghi { get; set; }
        public Barcode_110[] BaCot { get; set; }
        public Barcode_A4[] NamCot { get; set; }
        public Barcode_A5[] HaiCot { get; set; }
        public bool XemIn { get; set; }
        public string HanhDong { get; set; }
        #endregion

        #region khởi tạo
        public frmBaoCaoBarcode()
        {
            InitializeComponent();
        }

        public frmBaoCaoBarcode(string hanhDong, MaVachThe[] maVach)
        {//In mã vạch thẻ vip và thẻ giá trị
            InitializeComponent();

            HanhDong = hanhDong;
            _maVach = maVach;
        }

        public frmBaoCaoBarcode(Barcode[] code, string hanhdong, Boolean xemIn)
        {//In mã vạch hàng hóa
            InitializeComponent();

            Code = code;
            HanhDong = hanhdong;
            XemIn = xemIn;
        }

        private void frmBaoCaoBarcode_Load(object sender, EventArgs e)
        {
            try
            {
                switch (HanhDong)
                {
                    case "MotCot":
                        if (Code.Length > 0)
                        {
                            Report.rptBarcode report = new Report.rptBarcode();
                            report.SetDataSource(Code);
                            crvReport.ReportSource = report;
                            crvReport.Show();
                        }
                        else
                        { MessageBox.Show("Chưa có mã vạch để in hãy kiểm tra lại"); this.Close(); }
                        break;
                    case "Loại A5":
                        if (Code.Length > 0)
                        {
                            Report.In_MaVach_Chuan report = new Report.In_MaVach_Chuan();
                            report.SetDataSource(Code);
                            crvReport.ReportSource = report;
                            crvReport.Show();
                        }
                        else
                        { MessageBox.Show("Chưa có mã vạch để in hãy kiểm tra lại"); this.Close(); }
                        break;

                    case "Loại 110":
                        if (Code.Length > 0)
                        {
                            Report.In_MaVach_ChuyenDung report = new Report.In_MaVach_ChuyenDung();
                            report.SetDataSource(Code);
                            crvReport.ReportSource = report;
                            crvReport.Show();
                        }
                        else
                        { MessageBox.Show("Chưa có mã vạch để in hãy kiểm tra lại"); Close(); }
                        break;
                    case "Loại A4":
                        if (Code.Length > 0)
                        {
                            Report.In_MaVach_Khac report = new Report.In_MaVach_Khac();
                            report.SetDataSource(Code);
                            crvReport.ReportSource = report;
                            crvReport.Show();
                        }
                        else
                        { MessageBox.Show("Chưa có mã vạch để in hãy kiểm tra lại"); Close(); }
                        break;
                    case "TV":
                        if (_maVach.Length > 0)
                        {
                            Report.rptMaVachTheVip report = new Report.rptMaVachTheVip();
                            report.SetDataSource(_maVach);
                            crvReport.ReportSource = report;
                            crvReport.Show();
                        }
                        else
                        { MessageBox.Show("Chưa có mã vạch để in hãy kiểm tra lại"); Close(); }
                        break;
                    case "TGT":
                        if (_maVach.Length > 0)
                        {
                            Report.rptMaVachTheGT report = new Report.rptMaVachTheGT();
                            report.SetDataSource(_maVach);
                            crvReport.ReportSource = report;
                            crvReport.Show();
                        }
                        else
                        { MessageBox.Show("Chưa có mã vạch để in hãy kiểm tra lại"); Close(); }
                        break;
                    default:
                        Close();
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Thất bại"); Close();
            }
        }
        #endregion

        #region Event
        private void toolStripStatus_Dong_Click(object sender, EventArgs e)
        {
            DialogResult giatri = MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == DialogResult.Yes)
                {
                    Close();
                }
            }
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = Color.LightSteelBlue;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = Color.Snow;
        }
        #endregion
    }
}
