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

namespace VNA_Project.NGHIEPVU.GiamTaiSanCoDinhFolder
{
    public partial class frmNVGiamTaiSanCoDinh : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        public static List<GiamTaiSanCoDinh> Ldata = new List<GiamTaiSanCoDinh>();
        int vtIndex = 0;    //vị trí dòng cell đang được chọn trong datagridview
        #endregion

        public frmNVGiamTaiSanCoDinh()
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

            DataGridView.Columns["MaTaiSan"].HeaderText = "Mã tài sản";
            DataGridView.Columns["MaLyDoTangGiamTaiSan"].HeaderText = "Mã lý do tăng giảm tài sản";
            DataGridView.Columns["NgayGiam"].HeaderText = "Ngày giảm";
            DataGridView.Columns["NgayKetThucKhauHao"].HeaderText = "Ngày kết thúc khấu hao";
            DataGridView.Columns["SoChungTu"].HeaderText = "Số chứng từ";
            DataGridView.Columns["LyDo"].HeaderText = "Lý do";

            DataGridView.Columns["GiamTaiSanCoDinhID"].Visible = false;
            DataGridView.Columns["MaGiamTaiSanCoDinh"].Visible = false;
            DataGridView.Columns["MaTaiSan"].Visible = true;
            DataGridView.Columns["MaLyDoTangGiamTaiSan"].Visible = true;
            DataGridView.Columns["NgayGiam"].Visible = true;
            DataGridView.Columns["NgayKetThucKhauHao"].Visible = true;
            DataGridView.Columns["SoChungTu"].Visible = true;
            DataGridView.Columns["LyDo"].Visible = true;

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
            Ldata = GiamTaiSanCoDinhBiz.getListGiamTaiSanCoDinh();
            DataGridView.DataSource = Ldata.ToArray();
            FixDataGirdView();
        }
        private void Them()
        {
            try
            {
                frmXuLyNVGiamTaiSanCoDinh frm = new frmXuLyNVGiamTaiSanCoDinh();
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
                    frmXuLyNVGiamTaiSanCoDinh frm = new frmXuLyNVGiamTaiSanCoDinh(DataGridView.Rows[vtIndex]);
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
                        GiamTaiSanCoDinh temp = Utils.DataGridViewRow_to_GiamTaiSanCoDinh(DataGridView.Rows[vtIndex]);
                        int kq = GiamTaiSanCoDinhBiz.DeleteGiamTaiSanCoDinh(temp);
                        if (kq > 0) MSG.XoaThanhCong();
                        else MSG.XoaThatBai();
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
                List<GiamTaiSanCoDinh> Ltemp = new List<GiamTaiSanCoDinh>();
                string search = txtMaSearch.Text.ToUpper();
                foreach (GiamTaiSanCoDinh item in Ldata)
                {
                    if (item.MaTaiSan.ToUpper().Contains(search)) Ltemp.Add(item);
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
                List<GiamTaiSanCoDinh> Ltemp = new List<GiamTaiSanCoDinh>();
                string search = txtTenSearch.Text.ToUpper();
                foreach (GiamTaiSanCoDinh item in Ldata)
                {
                    if (item.SoChungTu.ToUpper().Contains(search)) Ltemp.Add(item);
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