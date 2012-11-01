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

namespace VNA_Project.DANHMUC.ThietBiFolder
{
    public partial class frmDMThietBi : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        public static List<ThietBi> Ldata = new List<ThietBi>();
        int vtIndex = 0;    //vị trí dòng cell đang được chọn trong datagridview
        #endregion

        public frmDMThietBi()
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

            DataGridView.Columns["MaThietBi"].HeaderText = "Mã Thiết bị";
            DataGridView.Columns["TenThietBi"].HeaderText = "Tên Thiết bị";

            DataGridView.Columns["MaThietBi"].Visible = true;
            DataGridView.Columns["TenThietBi"].Visible = true;

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
            Ldata = ThietBiBiz.getListThietBi();
            DataGridView.DataSource = Ldata.ToArray();
            FixDataGirdView();
        }
        private void Them()
        {
            try
            {
                frmXuLyDMThietBi frm = new frmXuLyDMThietBi();
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
                    frmXuLyDMThietBi frm = new frmXuLyDMThietBi(DataGridView.Rows[vtIndex]);
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
                        ThietBi temp = Utils.DataGridViewRow_to_ThietBi(DataGridView.Rows[vtIndex]);
                        int kq = ThietBiBiz.DeleteThietBi(temp);
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
                List<ThietBi> Ltemp = new List<ThietBi>();
                string search = txtMaSearch.Text.ToUpper();
                foreach (ThietBi item in Ldata)
                {
                    if (item.MaThietBi.ToUpper().Contains(search)) Ltemp.Add(item);
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
                List<ThietBi> Ltemp = new List<ThietBi>();
                string search = txtTenSearch.Text.ToUpper();
                foreach (ThietBi item in Ldata)
                {
                    if (item.TenThietBi.ToUpper().Contains(search)) Ltemp.Add(item);
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