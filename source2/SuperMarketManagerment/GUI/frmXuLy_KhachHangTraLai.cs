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
    public partial class frmXuLy_KhachHangTraLai : Form
    {

        public frmXuLy_KhachHangTraLai()
        {
            InitializeComponent();
        }

        private string hanhDong;
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        public frmXuLy_KhachHangTraLai(string hanhdong)
        {
            InitializeComponent();
            this.hanhDong = hanhdong;
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

        private void btnTimmakhachhang_Click(object sender, EventArgs e)
        {
            //if (_KiemTraForm == 1 || _KiemTraForm == 3)
            //{
            //    frmTraCuu cc = new frmTraCuu();
            //    cc.KiemTra_TraCuu = 1;
            //    cc.ShowDialog();
            //}
            //if (_KiemTraForm == 2 || _KiemTraForm == 4)
            //{
            //    frmTraCuu cc = new frmTraCuu();
            //    cc.KiemTra_TraCuu = 2;
            //    cc.ShowDialog();
            //}
          
        }

        private void frmXuLy_KhachHangTraLaiHang_Load(object sender, EventArgs e)
        {
            //if (_KiemTraForm == 1)
            //{
            //    MessageBox.Show("nha cung cap");
            //}
            //if (_KiemTraForm == 2)
            //{
            //    MessageBox.Show("khach hang tra lai");
            //}
            //if (_KiemTraForm == 3)
            //{
            //    MessageBox.Show("sua lai tra lai nha cung cap");
            //}
            //if (_KiemTraForm == 4)
            //{
            //    MessageBox.Show(" sua lai khach hang tra lai");
            //}
        }

        private void btnChungtugoc_Click(object sender, EventArgs e)
        {
            //if (_KiemTraForm == 1 || _KiemTraForm == 3)
            //{
            //    frmTraCuu cc = new frmTraCuu();
            //    cc.KiemTra_TraCuu = 3;
            //    cc.ShowDialog();
            //}
            //if (_KiemTraForm == 2 || _KiemTraForm == 4)
            //{
            //    frmTraCuu cc = new frmTraCuu();
            //    cc.KiemTra_TraCuu = 4;
            //    cc.ShowDialog();
            //}
          
        }

        private void toolStripStatus_In_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa xử lý");
        }

        private void toolStripStatus_Ghilai_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa xử lý");
        }

        private void toolStripStatus_Themmoi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa xử lý");
        }
    }
}
