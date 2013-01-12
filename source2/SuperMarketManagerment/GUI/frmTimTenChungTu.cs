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
    public partial class frmTimTenChungTu : Form
    {
        public static DataGridViewRow drvr = null;
        public frmTimTenChungTu()
        {
            InitializeComponent();
            try
            {
                Entities.TenChungTu[] tenchungtu = new Entities.TenChungTu[11];
                tenchungtu[0] = new Entities.TenChungTu("Phiếu Xuất Hủy", "PXH");
                tenchungtu[1] = new Entities.TenChungTu("Hóa Đơn Bán Hàng", "HDBH");
                tenchungtu[2] = new Entities.TenChungTu("Nhập Kho", "HDN");
                tenchungtu[3] = new Entities.TenChungTu("Trả Lại Nhà Cung Cấp", "TLNCC");
                tenchungtu[4] = new Entities.TenChungTu("Khách Hàng Trả Lại", "KHTL");
                tenchungtu[5] = new Entities.TenChungTu("Phiếu Điều Chuyển Kho Nội Bộ", "PDCK");
                tenchungtu[6] = new Entities.TenChungTu("Đơn Đặt Hàng", "DDH");
                tenchungtu[7] = new Entities.TenChungTu("Phiếu Thu", "PT");
                tenchungtu[8] = new Entities.TenChungTu("Phiếu Chi", "PT");
                tenchungtu[9] = new Entities.TenChungTu("Phiếu Thanh Toán Của Khách Hàng", "PTTKH");
                tenchungtu[10] = new Entities.TenChungTu("Phiếu Thanh Toán Nhà Cung Cấp", "PTTNCC");
                dtgvHienThi.DataSource = tenchungtu;
                fix();
            }
            catch
            {
            }
        }
        public void fix()
        {
            dtgvHienThi.RowHeadersVisible = false;
            dtgvHienThi.ReadOnly = true;
            dtgvHienThi.Columns["TenCT"].HeaderText = "Tên Chứng Từ";
            dtgvHienThi.Columns["KyHieu"].HeaderText = "Ký Hiệu";
            dtgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvHienThi.AllowUserToAddRows = false;
            dtgvHienThi.AllowUserToDeleteRows = false;
            dtgvHienThi.AllowUserToResizeRows = false;
        }
        int i = 0;
        private void dtgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void dtgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                drvr = dtgvHienThi.Rows[i];
                this.Close();
            }
            catch
            {
            }
        }

        private void tsslhuybo_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void dtgvHienThi_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    i = dtgvHienThi.SelectedRows[0].Index;
                    drvr = dtgvHienThi.Rows[i];
                    this.Close();
                }
            }
            catch
            {
            }
        }

        private void tsslchapnhan_Click(object sender, EventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                drvr = dtgvHienThi.Rows[i];
                this.Close();
            }
            catch
            {
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
