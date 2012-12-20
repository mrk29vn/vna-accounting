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

namespace VNA_Project.NGHIEPVU.DieuChuyenBoPhanSuDungFolder
{
    public partial class frmXuLyNVDieuChuyenBoPhanSuDung : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        int idDieuChuyenBoPhanSuDung = 0;

        bool Them = true;
        TaiSan taisan = new TaiSan();
        #endregion

        public frmXuLyNVDieuChuyenBoPhanSuDung()
        {//Thêm
            InitializeComponent();
        }
        public frmXuLyNVDieuChuyenBoPhanSuDung(DataGridViewRow dgvr)
        {//Sửa
            InitializeComponent();
            try
            {
                Them = false;
                DieuChuyenBoPhanSuDung temp = Utils.DataGridViewRow_to_DieuChuyenBoPhanSuDung(dgvr);
                idDieuChuyenBoPhanSuDung = temp.DieuChuyenBoPhanSuDungID;
                txtMaTaiSan.Text = temp.MaTaiSan;
                List<TaiSan> Ltaisan = TaiSanBiz.getListTaiSan(temp.MaTaiSan);
                taisan = (Ltaisan.Count == 0) ? new TaiSan() : Ltaisan[0];
                txtNam.Text = temp.Nam;
                txtKy.Text = temp.Ky;
                txtBoPhanSuDung.Text = temp.MaBoPhanSuDung;
                txtTKTaiSan.Text = temp.TKTaiSan;
                txtTKKhauHao.Text = temp.TKKhauHao;
                txtTKChiPhi.Text = temp.TKChiPhi;
            }
            catch { }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            try
            {
                DieuChuyenBoPhanSuDung temp = new DieuChuyenBoPhanSuDung();
                temp.DieuChuyenBoPhanSuDungID = idDieuChuyenBoPhanSuDung;
                temp.MaTaiSan = txtMaTaiSan.Text;
                temp.Nam = txtNam.Text;
                temp.Ky = txtKy.Text;
                temp.MaBoPhanSuDung = txtBoPhanSuDung.Text;
                temp.TKTaiSan = txtTKTaiSan.Text;
                temp.TKKhauHao = txtTKKhauHao.Text;
                temp.TKChiPhi = txtTKChiPhi.Text;

                bool ThatBai = false;
                if (Them)
                {//Thêm
                    if (!CheckLoi(temp)) return;

                    int kq = DieuChuyenBoPhanSuDungBiz.AddDieuChuyenBoPhanSuDung(temp);
                    if (kq > 0) MSG.ThemThanhCong();
                    else
                    {
                        ThatBai = true;
                        MSG.ThemThatBai();
                    }
                }
                else
                {//Sửa
                    temp.DieuChuyenBoPhanSuDungID = idDieuChuyenBoPhanSuDung;
                    int kq = DieuChuyenBoPhanSuDungBiz.EditDieuChuyenBoPhanSuDung(temp);
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

        bool CheckLoi(DieuChuyenBoPhanSuDung data)
        {
            bool kq = true;
            //mã điều chuyển bộ phận sử dụng rỗng
            if (string.IsNullOrEmpty(data.MaTaiSan))
            {
                MSG.ErrorStand("Bạn chưa nhập mã tài sản!");
                txtMaTaiSan.Focus();
                return false;
            }
            //mã điều chuyển bộ phận sử dụng đã có trong cơ sở dữ liệu
            foreach (DieuChuyenBoPhanSuDung item in frmNVDieuChuyenBoPhanSuDung.Ldata)
            {
                if (item.MaTaiSan.ToUpper().Equals(txtMaTaiSan.Text.ToUpper()))
                {
                    MSG.ErrorStand("Mã tài sản đã có trong cơ sở dữ liệu!");
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
                FRM.frmTimKiem.bophansusung = null;
                FRM.frmTimKiem frm = new FRM.frmTimKiem(CONFIG.ConstFrm.frmDMBoPhanSuDung);
                frm.ShowDialog();
                if (FRM.frmTimKiem.bophansusung != null)
                {
                    txtBoPhanSuDung.Text = FRM.frmTimKiem.bophansusung.MaBoPhanSuDung.ToUpper();
                    lblBoPhanSuDung.Text = FRM.frmTimKiem.bophansusung.TenBoPhanSuDung;
                }
                FRM.frmTimKiem.bophansusung = null;
            }
        }

    }
}