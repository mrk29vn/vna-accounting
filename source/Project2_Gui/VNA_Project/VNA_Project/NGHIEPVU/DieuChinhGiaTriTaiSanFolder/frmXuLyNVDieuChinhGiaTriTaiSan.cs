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

namespace VNA_Project.NGHIEPVU.DieuChinhGiaTriTaiSanFolder
{
    public partial class frmXuLyNVDieuChinhGiaTriTaiSan : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        int idDieuChinhGiaTriTaiSan = 0;

        bool Them = true;
        TaiSan taisan = new TaiSan();
        #endregion

        public frmXuLyNVDieuChinhGiaTriTaiSan()
        {//Thêm
            InitializeComponent();
        }
        public frmXuLyNVDieuChinhGiaTriTaiSan(DataGridViewRow dgvr)
        {//Sửa
            InitializeComponent();
            try
            {
                Them = false;
                DieuChinhGiaTriTaiSan temp = Utils.DataGridViewRow_to_DieuChinhGiaTriTaiSan(dgvr);
                idDieuChinhGiaTriTaiSan = temp.DieuChinhGiaTriTaiSanID;
                txtMaTaiSan.Text = temp.MaTaiSan;
                List<TaiSan> Ltaisan = TaiSanBiz.getListTaiSan(temp.MaTaiSan);
                taisan = (Ltaisan.Count == 0) ? new TaiSan() : Ltaisan[0];
                txtNam.Text = temp.Nam;
                txtKy.Text = temp.Ky;
                txtNgayChungTu.Text = (temp.NgayChungTu.Date == new DateTime(1753, 1, 1).Date) ? string.Empty : temp.NgayChungTu.ToString("MM/dd/yyyy");
                txtSoChungTu.Text = temp.SoChungTu;
                txtMaNguonVon.Text = temp.MaNguonVon;
                txtMaLyDoTangGiamTaiSan.Text = temp.MaLyDoTangGiamTaiSan;
                txtNguyenGia.Text = temp.NguyenGia.ToString();
                txtGiaTriDaKhauHao.Text = temp.GiaTriDaKhauHao.ToString();
                txtGiaTriConLai.Text = temp.GiaTriConLai.ToString();
                txtGiaTriKhauHao1Ky.Text = temp.GiaTriKhauHao1Ky.ToString();
                txtDienGiai.Text = temp.DienGiai;
            }
            catch { }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            try
            {
                DieuChinhGiaTriTaiSan temp = new DieuChinhGiaTriTaiSan();
                temp.MaLyDoTangGiamTaiSan = txtMaLyDoTangGiamTaiSan.Text;
                List<LyDoTangGiamTaiSan> L = LyDoTangGiamTaiSanBiz.getListLyDoTangGiamTaiSan(temp.MaLyDoTangGiamTaiSan);
                temp.Loai = (L.Count > 0) ? L[0].LoaiTangGiamTaiSan : true; //mặc định tăng
                temp.MaTaiSan = txtMaTaiSan.Text;
                temp.Nam = txtNam.Text;
                temp.Ky = txtKy.Text;
                temp.NgayChungTu = DateTime.Parse(txtNgayChungTu.Text);
                temp.SoChungTu = txtSoChungTu.Text;
                temp.MaNguonVon = txtMaNguonVon.Text;
                temp.NguyenGia = double.Parse(txtNguyenGia.Text);
                temp.GiaTriDaKhauHao = double.Parse(txtGiaTriDaKhauHao.Text);
                temp.GiaTriConLai = double.Parse(txtGiaTriConLai.Text);
                temp.GiaTriKhauHao1Ky = double.Parse(txtGiaTriKhauHao1Ky.Text);
                temp.DienGiai = txtDienGiai.Text;

                bool ThatBai = false;
                if (Them)
                {//Thêm
                    if (!CheckLoi(temp)) return;

                    int kq = DieuChinhGiaTriTaiSanBiz.AddDieuChinhGiaTriTaiSan(temp);
                    if (kq > 0) MSG.ThemThanhCong();
                    else
                    {
                        ThatBai = true;
                        MSG.ThemThatBai();
                    }
                }
                else
                {//Sửa
                    temp.DieuChinhGiaTriTaiSanID = idDieuChinhGiaTriTaiSan;
                    int kq = DieuChinhGiaTriTaiSanBiz.EditDieuChinhGiaTriTaiSan(temp);
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

        bool CheckLoi(DieuChinhGiaTriTaiSan data)
        {
            bool kq = true;
            //mã điều chỉnh giá trị tài sản rỗng
            if (string.IsNullOrEmpty(data.MaTaiSan))
            {
                MSG.ErrorStand("Bạn chưa nhập mã điều chỉnh giá trị tài sản!");
                txtNam.Focus();
                return false;
            }
            //mã điều chỉnh giá trị tài sản đã có trong cơ sở dữ liệu
            foreach (DieuChinhGiaTriTaiSan item in frmNVDieuChinhGiaTriTaiSan.Ldata)
            {
                if (item.MaTaiSan.ToUpper().Equals(txtNam.Text.ToUpper()))
                {
                    MSG.ErrorStand("Mã điều chỉnh giá trị tài sản đã có trong cơ sở dữ liệu!");
                    txtNam.Focus();
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

        private void txtMaNguonVon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == CONFIG.KeyClass.key_TimKiem)
            {//Tìm kiếm
                FRM.frmTimKiem.nguonvon = null;
                FRM.frmTimKiem frm = new FRM.frmTimKiem(CONFIG.ConstFrm.frmDMNguonVon);
                frm.ShowDialog();
                if (FRM.frmTimKiem.nguonvon != null)
                {
                    txtMaNguonVon.Text = FRM.frmTimKiem.nguonvon.MaNguonVon.ToUpper();
                    lblTenNguonVon.Text = FRM.frmTimKiem.nguonvon.TenNguonVon;
                }
                FRM.frmTimKiem.nguonvon = null;
            }
        }

        private void txtMaLyDoTangGiamTaiSan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == CONFIG.KeyClass.key_TimKiem)
            {//Tìm kiếm
                FRM.frmTimKiem.lydotanggiamtaisan = null;
                FRM.frmTimKiem frm = new FRM.frmTimKiem(CONFIG.ConstFrm.frmDMLyDoTangGiamTaiSan);
                frm.ShowDialog();
                if (FRM.frmTimKiem.lydotanggiamtaisan != null)
                {
                    txtMaLyDoTangGiamTaiSan.Text = FRM.frmTimKiem.lydotanggiamtaisan.MaLyDoTangGiamTaiSan.ToUpper();
                    lblMaLyDoTangGiamTaiSan.Text = FRM.frmTimKiem.lydotanggiamtaisan.TenLyDoTangGiamTaiSan;
                }
                FRM.frmTimKiem.lydotanggiamtaisan = null;
            }
        }

        private void txtNguyenGia_TextChanged(object sender, EventArgs e)
        {
            TinhKhauHao();
        }

        private void txtGiaTriDaKhauHao_TextChanged(object sender, EventArgs e)
        {
            TinhKhauHao();
        }

        private void TinhKhauHao()
        {
            try
            {
                double nguyengia = double.Parse(string.IsNullOrEmpty(txtNguyenGia.Text) ? "0" : txtNguyenGia.Text);
                double giatridakhauhao = double.Parse(string.IsNullOrEmpty(txtGiaTriDaKhauHao.Text) ? "0" : txtGiaTriDaKhauHao.Text);

                double giatriconlai = nguyengia - giatridakhauhao;
                txtGiaTriConLai.Text = giatriconlai.ToString();

                double sokytinhkhauhao = double.Parse(string.IsNullOrEmpty(taisan.SoKyKhauHao) ? "0" : taisan.SoKyKhauHao);

                double giatrikhauhao1ky = sokytinhkhauhao == 0 ? 0 : nguyengia / sokytinhkhauhao;
                txtGiaTriKhauHao1Ky.Text = giatrikhauhao1ky.ToString();
            }
            catch (Exception ex)
            {
                //MSG.Error(ex);
            }
        }

    }
}