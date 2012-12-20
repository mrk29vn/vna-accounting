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

namespace VNA_Project.NGHIEPVU.ThoiKhauHaoTaiSanFolder
{
    public partial class frmXuLyNVThoiKhauHaoTaiSan : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        int idThoiKhauHaoTaiSan = 0;

        bool Them = true;
        TaiSan taisan = new TaiSan();
        #endregion

        public frmXuLyNVThoiKhauHaoTaiSan()
        {//Thêm
            InitializeComponent();
        }
        public frmXuLyNVThoiKhauHaoTaiSan(DataGridViewRow dgvr)
        {//Sửa
            InitializeComponent();
            try
            {
                Them = false;
                ThoiKhauHaoTaiSan temp = Utils.DataGridViewRow_to_ThoiKhauHaoTaiSan(dgvr);
                idThoiKhauHaoTaiSan = temp.ThoiKhauHaoTaiSanID;
                txtMaTaiSan.Text = temp.MaTaiSan;
                List<TaiSan> Ltaisan = TaiSanBiz.getListTaiSan(temp.MaTaiSan);
                taisan = (Ltaisan.Count == 0) ? new TaiSan() : Ltaisan[0];
                txtNgayThoiKhauHao.Text = (temp.NgayThoiKhauHao.Date == new DateTime(1753, 1, 1).Date) ? string.Empty : temp.NgayThoiKhauHao.ToString("MM/dd/yyyy");
            }
            catch { }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            try
            {
                ThoiKhauHaoTaiSan temp = new ThoiKhauHaoTaiSan();
                temp.ThoiKhauHaoTaiSanID = idThoiKhauHaoTaiSan;
                temp.MaTaiSan = txtMaTaiSan.Text;
                temp.NgayThoiKhauHao = DateTime.Parse(txtNgayThoiKhauHao.Text);

                bool ThatBai = false;
                if (Them)
                {//Thêm
                    if (!CheckLoi(temp)) return;

                    int kq = ThoiKhauHaoTaiSanBiz.AddThoiKhauHaoTaiSan(temp);
                    if (kq > 0) MSG.ThemThanhCong();
                    else
                    {
                        ThatBai = true;
                        MSG.ThemThatBai();
                    }
                }
                else
                {//Sửa
                    temp.ThoiKhauHaoTaiSanID = idThoiKhauHaoTaiSan;
                    int kq = ThoiKhauHaoTaiSanBiz.EditThoiKhauHaoTaiSan(temp);
                    if (kq > 0) MSG.SuaThanhCong();
                    else
                    {
                        ThatBai = true;
                        MSG.SuaThatBai();
                    }
                }
                if (ThatBai && MSG.MESSAGE("Bạn có muốn sửa lại dữ liệu không?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) return;
                this.Close();
            }
            catch (Exception ex)
            {
                MSG.Error(ex);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool CheckLoi(ThoiKhauHaoTaiSan data)
        {
            bool kq = true;
            //mã giảm giá trị tài sản rỗng
            if (string.IsNullOrEmpty(data.MaTaiSan))
            {
                MSG.ErrorStand("Bạn chưa nhập mã thôi khấu hao tài sản!");
                txtMaTaiSan.Focus();
                return false;
            }
            //mã giảm giá trị tài sản đã có trong cơ sở dữ liệu
            foreach (ThoiKhauHaoTaiSan item in frmNVThoiKhauHaoTaiSan.Ldata)
            {
                if (item.MaTaiSan.ToUpper().Equals(txtMaTaiSan.Text.ToUpper()))
                {
                    MSG.ErrorStand("Mã thôi khấu hao tài sản đã có trong cơ sở dữ liệu!");
                    txtMaTaiSan.Focus();
                    return false;
                }
            }
            return kq;
        }

        private void txtMaTaiSan_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == CONFIG.KeyClass.key_TimKiem)
                {//Tìm kiếm
                    FRM.frmTimKiem.taisan = null;
                    FRM.frmTimKiem frm = new FRM.frmTimKiem(CONFIG.ConstFrm.frmDMTaiSan);
                    frm.ShowDialog();
                    if (FRM.frmTimKiem.taisan != null)
                    {
                        taisan = FRM.frmTimKiem.taisan.Copy();
                        txtMaTaiSan.Text = FRM.frmTimKiem.taisan.MaTaiSan.ToUpper();
                        lblTenTaiSan.Text = FRM.frmTimKiem.taisan.TenTaiSan;
                    }
                    FRM.frmTimKiem.taisan = null;
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

    }
}