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
    public partial class FrmXuLyBanLeCalculator : Form
    {
        public static double Phantram;
        private readonly double _tongtien;
        public static bool IsClose;

        public FrmXuLyBanLeCalculator(double tongtien)
        {
            InitializeComponent();
            Phantram = 0;
            IsClose = true;
            _tongtien = tongtien;
            txtTongTien.Text = new Common.Utilities().FormatMoney(_tongtien);
        }

        private void TxtCktmTextChanged(object sender, EventArgs e)
        {
            new TienIch().AutoFormatMoney(sender);

            //Tính % tương ứng
            double cktm = double.Parse(string.IsNullOrEmpty(txtCKTM.Text.Replace(",", "")) ? "0" : txtCKTM.Text.Replace(",", ""));
            Phantram = (cktm / _tongtien) * 100;
            txtPhanTram.Text = Phantram.ToString();
        }

        private void BtnOkClick(object sender, EventArgs e)
        {
            IsClose = false;
            Close();
        }

        private void BtnCloseClick(object sender, EventArgs e)
        {
            IsClose = true;
            Close();
        }
    }
}
