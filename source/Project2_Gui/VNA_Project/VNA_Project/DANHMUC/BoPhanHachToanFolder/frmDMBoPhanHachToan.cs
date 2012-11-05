using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VNA_Project.Entity;
using VNA_Project.BIZ;
using Qios.DevSuite.Components;
using System.Linq;

namespace VNA_Project.DANHMUC.BoPhanHachToanFolder
{
    public partial class frmDMBoPhanHachToan : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        public static List<BoPhanHachToan> Ldata = new List<BoPhanHachToan>();
        int vtIndex = 0;    //vị trí dòng cell đang được chọn trong datagridview
        #endregion

        public frmDMBoPhanHachToan()
        {
            InitializeComponent();
        }

        private void frmLoad(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Sua();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xoa();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Function
        void FixDataGirdView()
        {
            FixDataGirdView(DataGridView);
        }
        void FixDataGirdView(System.Windows.Forms.DataGridView DataGridView)
        {
            for (int j = 1; j < DataGridView.ColumnCount; j++) DataGridView.Columns[j].Visible = false;
            DataGridView.ReadOnly = true;

            DataGridView.Columns["MaBoPhanHachToan"].HeaderText = "Mã bộ phận hạch toán";
            DataGridView.Columns["TenBoPhanHachToan"].HeaderText = "Tên bộ phận hạch toán";

            DataGridView.Columns["MaBoPhanHachToan"].Visible = true;
            DataGridView.Columns["TenBoPhanHachToan"].Visible = true;

            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.AllowUserToDeleteRows = false;
            DataGridView.AllowUserToResizeRows = false;
            DataGridView.RowHeadersVisible = false;
        }
        #endregion

        #region Nghiệp vụ
        private void HienThi()
        {
            Ldata = BoPhanHachToanBiz.getListBoPhanHachToan();
            DataGridView.DataSource = Ldata.ToArray();
            FixDataGirdView();
        }
        private void Them()
        {
            try
            {
                frmXuLyDMBoPhanHachToan frm = new frmXuLyDMBoPhanHachToan();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                HienThi();
                if (Ldata.Count != 0) DataGridView.Rows[vtIndex == -1 ? 0 : vtIndex].Selected = true;   //nếu ko có phần tử nào thì thôi
            }
            catch (Exception ex)
            {
                MSG.Error(ex);
            }
        }
        private void Sua()
        {
            try
            {
                if (vtIndex != -1)  //khi click lên tiêu đề header của datagrid thì bỏ qua
                {
                    frmXuLyDMBoPhanHachToan frm = new frmXuLyDMBoPhanHachToan(DataGridView.Rows[vtIndex]);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                    HienThi();
                    if (Ldata.Count != 0) DataGridView.Rows[vtIndex == -1 ? 0 : vtIndex].Selected = true;   //nếu ko có phần tử nào thì thôi
                }
            }
            catch (Exception ex)
            {
                MSG.Error(ex);
            }
        }
        private void Xoa()
        {
            try
            {
                if (vtIndex != -1)  //khi click lên tiêu đề header của datagrid thì bỏ qua
                {
                    if (MSG.BanCoChacChanMuonXoaKhong() == System.Windows.Forms.DialogResult.Yes)
                    {
                        BoPhanHachToan temp = Utils.DataGridViewRow_to_BoPhanHachToan(DataGridView.Rows[vtIndex]);
                        int kq = BoPhanHachToanBiz.DeleteBoPhanHachToan(temp);
                        //if (kq > 0) MSG.XoaThanhCong();
                        //else MSG.XoaThatBai();
                        if (kq <= 0) MSG.XoaThatBai();
                        HienThi();
                    }
                }
            }
            catch (Exception ex)
            {
                MSG.Error(ex);
            }
        }
        #endregion

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {//Khi click vào Datagridview thì lấy vị trí của dòng vừa click vào và lưu lại vào biến vtIndex
            vtIndex = e.RowIndex;
        }
        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Sua();
        }

        private void txtMaSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<BoPhanHachToan> Ltemp = new List<BoPhanHachToan>();
                string search = txtMaSearch.Text.ToUpper();
                foreach (BoPhanHachToan item in Ldata)
                {
                    if (item.MaBoPhanHachToan.ToUpper().Contains(search)) Ltemp.Add(item);
                }
                DataGridView.DataSource = Ltemp.ToArray();
                FixDataGirdView();
            }
            catch (Exception ex)
            {
                MSG.Error(ex);
            }
        }

        private void txtTenSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<BoPhanHachToan> Ltemp = new List<BoPhanHachToan>();
                string search = txtTenSearch.Text.ToUpper();
                foreach (BoPhanHachToan item in Ldata)
                {
                    if (item.TenBoPhanHachToan.ToUpper().Contains(search)) Ltemp.Add(item);
                }
                DataGridView.DataSource = Ltemp.ToArray();
                FixDataGirdView();
            }
            catch (Exception ex)
            {
                MSG.Error(ex);
            }
        }
    }
}