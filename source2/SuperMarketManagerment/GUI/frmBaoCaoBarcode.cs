using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace GUI
{
    public partial class frmBaoCaoBarcode : Form
    {
        Entities.MaVachThe[] maVach;

        public frmBaoCaoBarcode()
        {
            InitializeComponent();
        }

        public frmBaoCaoBarcode(string hanhDong, Entities.MaVachThe[] maVach)
        {
            InitializeComponent();
            this.hanhDong = hanhDong;
            this.maVach = maVach;
        }

        private Entities.Barcode[] code;
        public Entities.Barcode[] Code
        {
            get { return code; }
            set { code = value; }
        }
        private int banghi;

        public int Banghi
        {
            get { return banghi; }
            set { banghi = value; }
        }

        public frmBaoCaoBarcode(Entities.Barcode[] code, string hanhdong, Boolean xemIn)
        {
            InitializeComponent();
            this.code = code;
            this.hanhDong = hanhdong;
            this.xemIn = xemIn;
        }
        public frmBaoCaoBarcode(Entities.Barcode[] code, int banghi)
        {
            InitializeComponent();
            this.code = code;
            this.banghi = banghi;
        }

        //======================================================================
        private Entities.Barcode_110[] baCot;
        public Entities.Barcode_110[] BaCot
        {
            get { return baCot; }
            set { baCot = value; }
        }
        public frmBaoCaoBarcode(Entities.Barcode_110[] baCot, string hanhdong, Boolean xemIn)
        {
            InitializeComponent();
            this.baCot = baCot;
            this.hanhDong = hanhdong;
            this.xemIn = xemIn;
        }
        //======================================================================
        private Entities.Barcode_A4[] namCot;
        public Entities.Barcode_A4[] NamCot
        {
            get { return namCot; }
            set { namCot = value; }
        }
        public frmBaoCaoBarcode(Entities.Barcode_A4[] namCot, string hanhdong, Boolean xemIn)
        {
            InitializeComponent();
            this.namCot = namCot;
            this.hanhDong = hanhdong;
            this.xemIn = xemIn;
        }
        //======================================================================
        private Entities.Barcode_A5[] haiCot;
        public Entities.Barcode_A5[] HaiCot
        {
            get { return haiCot; }
            set { haiCot = value; }
        }
        private Boolean xemIn;

        public Boolean XemIn
        {
            get { return xemIn; }
            set { xemIn = value; }
        }
        public frmBaoCaoBarcode(Entities.Barcode_A5[] haiCot, string hanhdong, Boolean xemIn)
        {
            InitializeComponent();
            this.haiCot = haiCot;
            this.hanhDong = hanhdong;
            this.xemIn = xemIn;
        }
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private void frmBaoCaoBarcode_Load(object sender, EventArgs e)
        {
            try
            {
                switch (hanhDong)
                {
                    case "MotCot":
                        if (code.Length > 0)
                        {
                            GUI.Report.rptBarcode report = new GUI.Report.rptBarcode();
                            report.SetDataSource(this.code);
                            crvReport.ReportSource = report;
                            crvReport.Show();
                        }
                        else
                        { MessageBox.Show("Chưa có mã vạch để in hãy kiểm tra lại"); this.Close(); }
                        break;
                    case "Loại A5":
                        if (code.Length > 0)
                        {
                            GUI.Report.In_MaVach_Chuan report = new GUI.Report.In_MaVach_Chuan();
                            report.SetDataSource(this.code);
                            crvReport.ReportSource = report;
                            crvReport.Show();
                        }
                        else
                        { MessageBox.Show("Chưa có mã vạch để in hãy kiểm tra lại"); this.Close(); }
                        break;

                    case "Loại 110":
                        if (code.Length > 0)
                        {
                            GUI.Report.In_MaVach_ChuyenDung report = new GUI.Report.In_MaVach_ChuyenDung();
                            report.SetDataSource(this.code);
                            crvReport.ReportSource = report;
                            crvReport.Show();
                        }
                        else
                        { MessageBox.Show("Chưa có mã vạch để in hãy kiểm tra lại"); this.Close(); }
                        break;
                    case "Loại A4":
                        if (code.Length > 0)
                        {
                            GUI.Report.In_MaVach_Khac report = new GUI.Report.In_MaVach_Khac();
                            report.SetDataSource(this.code);
                            crvReport.ReportSource = report;
                            crvReport.Show();
                        }
                        else
                        { MessageBox.Show("Chưa có mã vạch để in hãy kiểm tra lại"); this.Close(); }
                        break;
                    case "TV":
                        if (this.maVach.Length > 0)
                        {
                            GUI.Report.rptMaVachTheVip report = new Report.rptMaVachTheVip();
                            report.SetDataSource(maVach);
                            crvReport.ReportSource = report;
                            crvReport.Show();
                        }
                        else
                        { MessageBox.Show("Chưa có mã vạch để in hãy kiểm tra lại"); this.Close(); }
                        break;
                    case "TGT":
                        if (this.maVach.Length > 0)
                        {
                            GUI.Report.rptMaVachTheGT report = new Report.rptMaVachTheGT();
                            report.SetDataSource(maVach);
                            crvReport.ReportSource = report;
                            crvReport.Show();
                        }
                        else
                        { MessageBox.Show("Chưa có mã vạch để in hãy kiểm tra lại"); this.Close(); }
                        break;
                    default:
                        this.Close();
                        break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; MessageBox.Show("Thất bại"); this.Close(); }
        }

        private void toolStripStatus_Dong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
                else
                { }
            }
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }
    }
}
