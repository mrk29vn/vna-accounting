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
        bool Them = true;
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
                txtNam.Text = temp.MaDieuChinhGiaTriTaiSan;
                txtNam.Enabled = false;
            }
            catch { }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (Them)
            {//Thêm
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

                if (!CheckLoi(temp)) return;

                int kq = DieuChinhGiaTriTaiSanBiz.AddDieuChinhGiaTriTaiSan(temp);
                if (kq > 0) MSG.ThemThanhCong();
                else MSG.ThemThatBai();
            }
            else
            {//Sửa
                DieuChinhGiaTriTaiSan temp = new DieuChinhGiaTriTaiSan();
                temp.MaDieuChinhGiaTriTaiSan = txtNam.Text;
                int kq = DieuChinhGiaTriTaiSanBiz.EditDieuChinhGiaTriTaiSan(temp);
                if (kq > 0) MSG.SuaThanhCong();
                else MSG.SuaThatBai();
            }
            this.Close();
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