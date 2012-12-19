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

namespace VNA_Project.NGHIEPVU.DieuChinhGiaTriTaiSanFolder
{
    public partial class frmNVDieuChinhGiaTriTaiSan : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        public static List<DieuChinhGiaTriTaiSan> Ldata = new List<DieuChinhGiaTriTaiSan>();
        int vtIndex = 0;    //vị trí dòng cell đang được chọn trong datagridview
        #endregion

        public frmNVDieuChinhGiaTriTaiSan()
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

            DataGridView.Columns["Loai"].HeaderText = "Loại";
            DataGridView.Columns["MaTaiSan"].HeaderText = "Mã tài sản";
            DataGridView.Columns["Nam"].HeaderText = "Năm";
            DataGridView.Columns["Ky"].HeaderText = "Kỳ";
            DataGridView.Columns["NgayChungTu"].HeaderText = "Ngày chứng từ";
            DataGridView.Columns["SoChungTu"].HeaderText = "Số chứng từ";
            DataGridView.Columns["MaNguonVon"].HeaderText = "Mã nguồn vốn";
            DataGridView.Columns["MaLyDoTangGiamTaiSan"].HeaderText = "Mã lý do tăng giảm tài sản";
            DataGridView.Columns["NguyenGia"].HeaderText = "Nguyên giá";
            DataGridView.Columns["GiaTriDaKhauHao"].HeaderText = "Giá trị đã khấu hao";
            DataGridView.Columns["GiaTriConLai"].HeaderText = "Giá trị còn lại";
            DataGridView.Columns["GiaTriKhauHao1Ky"].HeaderText = "Giá trị khấu hao 1 kỳ";
            DataGridView.Columns["DienGiai"].HeaderText = "Diễn giải";

            DataGridView.Columns["MaDieuChinhGiaTriTaiSan"].Visible = false;
            DataGridView.Columns["Loai"].Visible = true;
            DataGridView.Columns["MaTaiSan"].Visible = true;
            DataGridView.Columns["Nam"].Visible = true;
            DataGridView.Columns["Ky"].Visible = true;
            DataGridView.Columns["NgayChungTu"].Visible = true;
            DataGridView.Columns["SoChungTu"].Visible = true;
            DataGridView.Columns["MaNguonVon"].Visible = true;
            DataGridView.Columns["MaLyDoTangGiamTaiSan"].Visible = true;
            DataGridView.Columns["NguyenGia"].Visible = true;
            DataGridView.Columns["GiaTriDaKhauHao"].Visible = true;
            DataGridView.Columns["GiaTriConLai"].Visible = true;
            DataGridView.Columns["GiaTriKhauHao1Ky"].Visible = true;
            DataGridView.Columns["DienGiai"].Visible = true;

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
            Ldata = DieuChinhGiaTriTaiSanBiz.getListDieuChinhGiaTriTaiSan();
            DataGridView.DataSource = Ldata.ToArray();
            FixDataGirdView();
        }
        private void Them()
        {
            try
            {
                frmXuLyNVDieuChinhGiaTriTaiSan frm = new frmXuLyNVDieuChinhGiaTriTaiSan();
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
                    frmXuLyNVDieuChinhGiaTriTaiSan frm = new frmXuLyNVDieuChinhGiaTriTaiSan(DataGridView.Rows[vtIndex]);
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
                        NguonVon temp = Utils.DataGridViewRow_to_NguonVon(DataGridView.Rows[vtIndex]);
                        int kq = NguonVonBiz.DeleteNguonVon(temp);
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
                List<DieuChinhGiaTriTaiSan> Ltemp = new List<DieuChinhGiaTriTaiSan>();
                string search = txtMaSearch.Text.ToUpper();
                foreach (DieuChinhGiaTriTaiSan item in Ldata)
                {
                    if (item.MaNguonVon.ToUpper().Contains(search)) Ltemp.Add(item);
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
                List<DieuChinhGiaTriTaiSan> Ltemp = new List<DieuChinhGiaTriTaiSan>();
                string search = txtTenSearch.Text.ToUpper();
                foreach (DieuChinhGiaTriTaiSan item in Ldata)
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