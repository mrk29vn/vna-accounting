using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace GUI
{
    public partial class frmBaoCaoXemInMaVach : Form
    {
        public frmBaoCaoXemInMaVach()
        {
            InitializeComponent();
        }

        private Entities.InMaVach[] gitri;
        public Entities.InMaVach[] Gitri
        {
            get { return gitri; }
            set { gitri = value; }
        }

        private string hanhdong;
        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }

        public frmBaoCaoXemInMaVach(string hanhdong,Entities.InMaVach[] dulieu)
        {
            InitializeComponent();
            this.hanhdong = hanhdong;
            this.gitri = dulieu;
        }

       
        private void frmBaoCaoXemInMaVach_Load(object sender, EventArgs e)
        {
            //ReportDocument rpDoc = new GUI.Report.rptBarcode();
            //rpDoc.SetDataSource(this.gitri);
            //rptViewer.ReportSource = rpDoc;
            //rptViewer.Show();
            //this.WindowState = FormWindowState.Maximized;
        }
    }
}
