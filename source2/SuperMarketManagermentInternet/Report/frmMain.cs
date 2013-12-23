using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Report
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBaoCaorpt bc = new frmBaoCaorpt(1);
            bc.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmBaoCaorpt bc = new frmBaoCaorpt(2);
            bc.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmBaoCaorpt bc = new frmBaoCaorpt(3);
            bc.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmtg tg = new frmtg();
            tg.ShowDialog();
        }
    }
}
