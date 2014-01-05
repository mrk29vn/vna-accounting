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
    public partial class frmtg : Form
    {
        #region khai báo
        DateTime _datesv;
        #endregion

        public frmtg()
        {
            InitializeComponent();
            _datesv = DateServer.Date();
            maskedTextBox1.Text = maskedTextBox2.Text = maskedTextBox3.Text = new Common.Utilities().XuLy(2, _datesv.ToShortDateString());
        }

        #region Event
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTheoNgay.Checked)
            {
                maskedTextBox1.Visible = true;
                maskedTextBox2.Visible = false;
                maskedTextBox3.Visible = false;
                comboBox1.Visible = false;
                dateTimePicker1.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
            }
            else if (rdoTheoThang.Checked)
            {
                maskedTextBox1.Visible = false;
                maskedTextBox2.Visible = false;
                maskedTextBox3.Visible = false;
                comboBox1.Visible = true;
                dateTimePicker1.Visible = true;
                label1.Visible = false;
                label2.Visible = true;
                label3.Visible = true;
            }
            else if (rdoTheoNam.Checked)
            {
                maskedTextBox1.Visible = false;
                maskedTextBox2.Visible = true;
                maskedTextBox3.Visible = true;
                comboBox1.Visible = false;
                dateTimePicker1.Visible = false;
                label1.Visible = true;
                label2.Visible = false;
                label3.Visible = false;
            }
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            ExportBc(0);
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            ExportBc(1);
        }

        private void tsslWord_Click(object sender, EventArgs e)
        {
            ExportBc(2);
        }

        private void tsslexcel_Click(object sender, EventArgs e)
        {
            ExportBc(3);
        }

        private void tsslthoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Utils
        /// <summary>
        /// Xuất báo cáo
        /// </summary>
        /// <param name="select">0: View, 1: PDF, 2: WORD, 3: EXCEL</param>
        void ExportBc(int select)
        {
            if (rdoTheoNgay.Checked)
            {
                #region theo ngày
                DateTime ngay;
                try
                {
                    string date = new Common.Utilities().MyDateConversion(maskedTextBox1.Text);
                    ngay = Convert.ToDateTime(date);
                }
                catch
                {
                    MessageBox.Show("không đúng định dạng ngày!");
                    return;
                }

                switch (@select)
                {
                    case 0:
                        {
                            frmBaoCaorpt bc = new frmBaoCaorpt(ngay, true, string.Empty, string.Empty);
                            bc.ShowDialog();
                        }
                        break;
                    case 1:
                        {
                            //PDF
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = "PDF |*.pdf", FileName = string.Empty };
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                frmBaoCaorpt bc = new frmBaoCaorpt(ngay, false, saveFileDialog1.FileName, "PDF");
                            }
                        }
                        break;
                    case 2:
                        {
                            //DOC
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = "Word |*.doc", FileName = string.Empty };
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                frmBaoCaorpt bc = new frmBaoCaorpt(ngay, false, saveFileDialog1.FileName, "Word");
                            }
                        }
                        break;
                    case 3:
                        {
                            //XLS
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = "Excel |*.xls", FileName = string.Empty };
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                frmBaoCaorpt bc = new frmBaoCaorpt(ngay, false, saveFileDialog1.FileName, "Excel");
                            }
                        }
                        break;
                }
                #endregion
            }
            else if (rdoTheoThang.Checked)
            {
                #region theo tháng
                int Thang, Nam;
                try
                {
                    Thang = Convert.ToInt32(comboBox1.Text);
                    Nam = dateTimePicker1.Value.Year;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("nhập sai định dạng ngày tháng", "Hệ thống cảnh báo");
                    maskedTextBox1.Focus();
                    return;
                }

                switch (@select)
                {
                    case 0:
                        {
                            frmBaoCaorpt bc = new frmBaoCaorpt(Thang, Nam, true, string.Empty, string.Empty);
                            bc.ShowDialog();
                        }
                        break;
                    case 1:
                        {
                            //PDF
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = "PDF |*.pdf", FileName = string.Empty };
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                frmBaoCaorpt bc = new frmBaoCaorpt(Thang, Nam, false, saveFileDialog1.FileName, "PDF");
                            }
                        }
                        break;
                    case 2:
                        {
                            //DOC
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = "Word |*.doc", FileName = string.Empty };
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                frmBaoCaorpt bc = new frmBaoCaorpt(Thang, Nam, false, saveFileDialog1.FileName, "Word");
                            }
                        }
                        break;
                    case 3:
                        {
                            //XLS
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = "Excel |*.xls", FileName = string.Empty };
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                frmBaoCaorpt bc = new frmBaoCaorpt(Thang, Nam, false, saveFileDialog1.FileName, "Excel");
                            }
                        }
                        break;
                }
                #endregion
            }
            else if (rdoTheoNam.Checked)
            {
                #region theo năm
                DateTime Truoc, Sau;
                string date1 = "", date2 = "";
                try
                {
                    date1 = new Common.Utilities().MyDateConversion(maskedTextBox2.Text);
                    Truoc = Convert.ToDateTime(date1);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("nhập sai định dạng ngày tháng", "Hệ thống cảnh báo");
                    maskedTextBox2.Focus();
                    return;
                }
                try
                {
                    date2 = new Common.Utilities().MyDateConversion(maskedTextBox3.Text);
                    Sau = Convert.ToDateTime(date2);
                }
                catch
                {
                    MessageBox.Show("nhập sai định dạng ngày tháng", "Hệ thống cảnh báo");
                    maskedTextBox3.Focus();
                    return;
                }

                switch (@select)
                {
                    case 0:
                        {
                            frmBaoCaorpt bc = new frmBaoCaorpt(Truoc, Sau, true, string.Empty, string.Empty);
                            bc.ShowDialog();
                        }
                        break;
                    case 1:
                        {
                            //PDF
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = "PDF |*.pdf", FileName = string.Empty };
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                frmBaoCaorpt bc = new frmBaoCaorpt(Truoc, Sau, false, saveFileDialog1.FileName, "PDF");
                            }
                        }
                        break;
                    case 2:
                        {
                            //DOC
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = "Word |*.doc", FileName = string.Empty };
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                frmBaoCaorpt bc = new frmBaoCaorpt(Truoc, Sau, false, saveFileDialog1.FileName, "Word");
                            }
                        }
                        break;
                    case 3:
                        {
                            //XLS
                            SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = "Excel |*.xls", FileName = string.Empty };
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                frmBaoCaorpt bc = new frmBaoCaorpt(Truoc, Sau, false, saveFileDialog1.FileName, "Excel");
                            }
                        }
                        break;
                }
                #endregion
            }
        }
        #endregion
    }
}
