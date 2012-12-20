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

namespace VNA_Project.NGHIEPVU.GiamTaiSanCoDinhFolder
{
    public partial class frmXuLyNVGiamTaiSanCoDinh : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        int idGiamTaiSanCoDinh = 0;

        bool Them = true;
        TaiSan taisan = new TaiSan();
        #endregion

        public frmXuLyNVGiamTaiSanCoDinh()
        {//Thêm
            InitializeComponent();
        }
        public frmXuLyNVGiamTaiSanCoDinh(DataGridViewRow dgvr)
        {//Sửa
            InitializeComponent();
            try
            {
                Them = false;
                GiamTaiSanCoDinh temp = Utils.DataGridViewRow_to_GiamTaiSanCoDinh(dgvr);
                idGiamTaiSanCoDinh = temp.GiamTaiSanCoDinhID;
                txtMaTaiSan.Text = temp.MaTaiSan;
                List<TaiSan> Ltaisan = TaiSanBiz.getListTaiSan(temp.MaTaiSan);
                taisan = (Ltaisan.Count == 0) ? new TaiSan() : Ltaisan[0];
                txtLyDoTangGiamTaiSan.Text = temp.MaLyDoTangGiamTaiSan;
                txtNgayGiamTaiSan.Text = (temp.NgayGiam.Date == new DateTime(1753, 1, 1).Date) ? string.Empty : temp.NgayGiam.ToString("MM/dd/yyyy");
                txtNgayKetThucKhauHao.Text = (temp.NgayKetThucKhauHao.Date == new DateTime(1753, 1, 1).Date) ? string.Empty : temp.NgayKetThucKhauHao.ToString("MM/dd/yyyy");
                txtSoChungTu.Text = temp.SoChungTu;
                txtLyDo.Text = temp.LyDo;
            }
            catch { }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            try
            {
                GiamTaiSanCoDinh temp = new GiamTaiSanCoDinh();
                temp.GiamTaiSanCoDinhID = idGiamTaiSanCoDinh;
                temp.MaTaiSan = txtMaTaiSan.Text;
                temp.MaLyDoTangGiamTaiSan = txtLyDoTangGiamTaiSan.Text;
                temp.NgayGiam = DateTime.Parse(txtNgayGiamTaiSan.Text);
                temp.NgayKetThucKhauHao = DateTime.Parse(txtNgayKetThucKhauHao.Text);
                temp.SoChungTu = txtSoChungTu.Text;
                temp.LyDo = txtLyDo.Text;

                bool ThatBai = false;
                if (Them)
                {//Thêm
                    if (!CheckLoi(temp)) return;

                    int kq = GiamTaiSanCoDinhBiz.AddGiamTaiSanCoDinh(temp);
                    if (kq > 0) MSG.ThemThanhCong();
                    else
                    {
                        ThatBai = true;
                        MSG.ThemThatBai();
                    }
                }
                else
                {//Sửa
                    temp.GiamTaiSanCoDinhID = idGiamTaiSanCoDinh;
                    int kq = GiamTaiSanCoDinhBiz.EditGiamTaiSanCoDinh(temp);
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

        bool CheckLoi(GiamTaiSanCoDinh data)
        {
            bool kq = true;
            //mã giảm giá trị tài sản rỗng
            if (string.IsNullOrEmpty(data.MaTaiSan))
            {
                MSG.ErrorStand("Bạn chưa nhập mã giảm giá trị tài sản!");
                txtMaTaiSan.Focus();
                return false;
            }
            //mã giảm giá trị tài sản đã có trong cơ sở dữ liệu
            foreach (GiamTaiSanCoDinh item in frmNVGiamTaiSanCoDinh.Ldata)
            {
                if (item.MaTaiSan.ToUpper().Equals(txtMaTaiSan.Text.ToUpper()))
                {
                    MSG.ErrorStand("Mã giảm giá trị tài sản đã có trong cơ sở dữ liệu!");
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

        private void txtLyDoTangGiamTaiSan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == CONFIG.KeyClass.key_TimKiem)
            {//Tìm kiếm
                FRM.frmTimKiem.lydotanggiamtaisan = null;
                FRM.frmTimKiem frm = new FRM.frmTimKiem(CONFIG.ConstFrm.frmDMLyDoTangGiamTaiSan);
                frm.ShowDialog();
                if (FRM.frmTimKiem.lydotanggiamtaisan != null)
                {
                    txtLyDoTangGiamTaiSan.Text = FRM.frmTimKiem.lydotanggiamtaisan.MaLyDoTangGiamTaiSan.ToUpper();
                    lblLyDoTangGiamTaiSan.Text = FRM.frmTimKiem.lydotanggiamtaisan.TenLyDoTangGiamTaiSan;
                }
                FRM.frmTimKiem.lydotanggiamtaisan = null;
            }
        }

    }
}