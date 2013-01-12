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
    public partial class frmBaoCaoBarcode : Form
    {
        public frmBaoCaoBarcode()
        {
            InitializeComponent();
        }

        private Entities.InMaVach[] code;
        public Entities.InMaVach[] Code
        {
            get { return code; }
            set { code = value; }
        }
        public frmBaoCaoBarcode(Entities.InMaVach[] code)
        {
            InitializeComponent();
            this.code = code;
        }

        private void frmBaoCaoBarcode_Load(object sender, EventArgs e)
        {
            GUI.Report.rptBarcode report = new GUI.Report.rptBarcode();
            report.SetDataSource(this.code);
            crvReport.ReportSource = report;
            crvReport.Show();
        }
    }
}
