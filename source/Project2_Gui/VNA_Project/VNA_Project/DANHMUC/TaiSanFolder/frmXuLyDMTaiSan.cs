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

namespace VNA_Project.DANHMUC.TaiSanFolder
{
    public partial class frmXuLyDMTaiSan : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        bool isEditChiTietTaiSan = false;
        bool isEditChiTietPhuTung = false;
        bool Them = true;
        List<ChiTietTaiSan> LChiTietTaiSan = new List<ChiTietTaiSan>();
        List<PhuTungKemTheo> LPhuTungKemTheo = new List<PhuTungKemTheo>();
        #endregion

        public frmXuLyDMTaiSan()
        {//Thêm
            InitializeComponent();
            DataGridViewCTNguonVon.DataSource = LChiTietTaiSan.ToArray();
            FixDataGirdView(DataGridViewCTNguonVon, false);
            DataGridViewCTPhuTungKemTheo.DataSource = LPhuTungKemTheo.ToArray();
            FixDataGirdView(DataGridViewCTPhuTungKemTheo, true);
        }
        public frmXuLyDMTaiSan(DataGridViewRow dgvr)
        {//Sửa
            InitializeComponent();
            try
            {
                Them = false;
                TaiSan temp = Utils.DataGridViewRow_to_TaiSan(dgvr);
                txtMaTaiSan.Text = temp.MaTaiSan;
                txtMaTaiSan.Enabled = false;
                txtTenTaiSan.Text = temp.TenTaiSan;
                txtNhomTaiSan.Text = temp.MaLoaiTaiSan;
                txtLyDoTang.Text = temp.MaLyDoTangGiamTaiSan;
                txtNgayTangTaiSan.Text = temp.NgayTangTaiSan.ToString("MM/dd/yyyy");
                txtNgayTinhKhauHao.Text = temp.NgayTinhKhauHao.ToString("MM/dd/yyyy");
                txtSoKyKhauHao.Text = temp.SoKyKhauHao;
                txtBoPhanHachToan.Text = temp.MaBoPhanHachToan;
                txtMaPhanXuong.Text = temp.MaPhanXuong;
                txtMaPhi.Text = temp.MaPhi;
                txtBoPhanSuDung.Text = temp.MaBoPhanSuDung;
                txtTKTaiSan.Text = temp.TKTaiSan;
                txtTKKhauHao.Text = temp.TKKhauHao;
                txtTKChiPhi.Text = temp.TKChiPhi;
                txtPhanNhom1.Text = temp.PhanNhom1;
                txtPhanNhom2.Text = temp.PhanNhom2;
                txtPhanNhom3.Text = temp.PhanNhom3;

                txtTenKhac.Text = temp.TenKhac;
                txtSoHieuTaiSan.Text = temp.SoHieuTaiSan;
                txtThongSoKyThuat.Text = temp.ThongSoKyThuat;
                txtNuocSanXuat.Text = temp.NuocSanXuat;
                txtNamSanXuat.Text = temp.NamSanXuat;
                txtNgayDuaVaoSuDung.Text = (temp.NgayDuaVaoSuDung.Date == new DateTime(1753, 1, 1).Date) ? string.Empty : temp.NgayDuaVaoSuDung.ToString("MM/dd/yyyy");
                txtNgayDinhChiSuDung.Text = (temp.NgayDinhChiSuDung.Date == new DateTime(1753, 1, 1).Date) ? string.Empty : temp.NgayDinhChiSuDung.ToString("MM/dd/yyyy");
                txtLyDoDinhChi.Text = temp.LyDoDinhChi;
                txtGhiChu.Text = temp.GhiChu;

                LChiTietTaiSan.AddRange(temp.Lchitiettaisan);
                LPhuTungKemTheo.AddRange(temp.Lphutungkemtheo);

                DataGridViewCTNguonVon.DataSource = LChiTietTaiSan.ToArray();
                FixDataGirdView(DataGridViewCTNguonVon, false);
                DataGridViewCTPhuTungKemTheo.DataSource = LPhuTungKemTheo.ToArray();
                FixDataGirdView(DataGridViewCTPhuTungKemTheo, true);
            }
            catch { }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            try
            {
                TaiSan temp = new TaiSan();
                temp.MaTaiSan = txtMaTaiSan.Text;
                temp.TenTaiSan = txtTenTaiSan.Text;
                temp.MaLoaiTaiSan = txtNhomTaiSan.Text;
                temp.MaLyDoTangGiamTaiSan = txtLyDoTang.Text;
                temp.NgayTangTaiSan = !string.IsNullOrEmpty(txtNgayTangTaiSan.Text) ? DateTime.Parse(txtNgayTangTaiSan.Text) : new DateTime(1753, 1, 1);
                temp.NgayTinhKhauHao = !string.IsNullOrEmpty(txtNgayTinhKhauHao.Text) ? DateTime.Parse(txtNgayTinhKhauHao.Text) : new DateTime(1753, 1, 1);
                temp.SoKyKhauHao = txtSoKyKhauHao.Text;
                temp.MaBoPhanHachToan = txtBoPhanHachToan.Text;
                temp.MaPhanXuong = txtMaPhanXuong.Text;
                temp.MaPhi = txtMaPhi.Text;
                temp.MaBoPhanSuDung = txtBoPhanSuDung.Text;
                temp.TKTaiSan = txtTKTaiSan.Text;
                temp.TKKhauHao = txtTKKhauHao.Text;
                temp.TKChiPhi = txtTKChiPhi.Text;
                temp.PhanNhom1 = txtPhanNhom1.Text;
                temp.PhanNhom2 = txtPhanNhom2.Text;
                temp.PhanNhom3 = txtPhanNhom3.Text;

                temp.TenKhac = txtTenKhac.Text;
                temp.SoHieuTaiSan = txtSoHieuTaiSan.Text;
                temp.ThongSoKyThuat = txtThongSoKyThuat.Text;
                temp.NuocSanXuat = txtNuocSanXuat.Text;
                temp.NamSanXuat = txtNamSanXuat.Text;
                temp.NgayDuaVaoSuDung = !string.IsNullOrEmpty(txtNgayTangTaiSan.Text) ? DateTime.Parse(txtNgayDuaVaoSuDung.Text) : new DateTime(1753, 1, 1);
                temp.NgayDinhChiSuDung = !string.IsNullOrEmpty(txtNgayTangTaiSan.Text) ? DateTime.Parse(txtNgayDinhChiSuDung.Text) : new DateTime(1753, 1, 1);
                temp.LyDoDinhChi = txtLyDoDinhChi.Text;
                temp.GhiChu = txtGhiChu.Text;

                temp.Lchitiettaisan.AddRange(LChiTietTaiSan);
                temp.Lphutungkemtheo.AddRange(LPhuTungKemTheo);

                bool ThatBai = false;
                if (Them)
                {//Thêm
                    if (!CheckLoi(temp)) return;

                    int kq = TaiSanBiz.AddTaiSan(temp);
                    if (kq > 0) MSG.ThemThanhCong();
                    else
                    {
                        ThatBai = true;
                        MSG.ThemThatBai();
                    }
                }
                else
                {//Sửa
                    int kq = TaiSanBiz.EditTaiSan(temp);
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

        bool CheckLoi(TaiSan data)
        {
            bool kq = true;
            ////mã tài sản rỗng
            //if (string.IsNullOrEmpty(data.MaTaiSan))
            //{
            //    MSG.ErrorStand("Bạn chưa nhập mã tài sản!");
            //    txtMa.Focus();
            //    return false;
            //}
            ////mã tài sản đã có trong cơ sở dữ liệu
            //foreach (TaiSan item in frmDMTaiSan.Ldata)
            //{
            //    if (item.MaTaiSan.ToUpper().Equals(txtMa.Text.ToUpper()))
            //    {
            //        MSG.ErrorStand("Mã tài sản đã có trong cơ sở dữ liệu!");
            //        txtMa.Focus();
            //        return false;
            //    }
            //}
            return kq;
        }

        void FixDataGirdView(System.Windows.Forms.DataGridView DataGridView, bool isPhuTung)
        {
            for (int j = 1; j < DataGridView.ColumnCount; j++) DataGridView.Columns[j].Visible = false;
            DataGridView.ReadOnly = true;

            if (isPhuTung)
            {
                DataGridView.Columns["MaPhuTungKemTheo"].HeaderText = "Mã phụ tùng kèm theo";
                DataGridView.Columns["TenPhuTungKemTheo"].HeaderText = "Tên phụ tùng kèm theo";
                DataGridView.Columns["DVT"].HeaderText = "Đơn vị tính";
                DataGridView.Columns["SoLuong"].HeaderText = "Số lượng";
                DataGridView.Columns["GiaTri"].HeaderText = "Giá trị";
                DataGridView.Columns["GhiChu"].HeaderText = "Ghi chú";

                DataGridView.Columns["MaTaiSan"].Visible = false;
                DataGridView.Columns["MaPhuTungKemTheo"].Visible = true;
                DataGridView.Columns["TenPhuTungKemTheo"].Visible = true;
                DataGridView.Columns["DVT"].Visible = true;
                DataGridView.Columns["SoLuong"].Visible = true;
                DataGridView.Columns["GiaTri"].Visible = true;
                DataGridView.Columns["GhiChu"].Visible = true;
            }
            else
            {
                DataGridView.Columns["MaNguonVon"].HeaderText = "Mã nguồn vốn";
                DataGridView.Columns["NgayChungTu"].HeaderText = "Ngày chứng từ";
                DataGridView.Columns["SoChungTu"].HeaderText = "Số chứng từ";
                DataGridView.Columns["NguyenGia"].HeaderText = "Nguyên giá";
                DataGridView.Columns["GiaTriDaKhauHao"].HeaderText = "Giá trị đã khấu hao";
                DataGridView.Columns["GiaTriConLai"].HeaderText = "Giá trị còn lại";
                DataGridView.Columns["GiaTriKhauHao1Ky"].HeaderText = "Giá trị khấu hao 1 kỳ";
                DataGridView.Columns["DienGiai"].HeaderText = "Diễn giải";

                DataGridView.Columns["MaTaiSan"].Visible = false;
                DataGridView.Columns["MaNguonVon"].Visible = true;
                DataGridView.Columns["NgayChungTu"].Visible = true;
                DataGridView.Columns["SoChungTu"].Visible = true;
                DataGridView.Columns["NguyenGia"].Visible = true;
                DataGridView.Columns["GiaTriDaKhauHao"].Visible = true;
                DataGridView.Columns["GiaTriConLai"].Visible = true;
                DataGridView.Columns["GiaTriKhauHao1Ky"].Visible = true;
                DataGridView.Columns["DienGiai"].Visible = true;
            }

            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.AllowUserToDeleteRows = false;
            DataGridView.AllowUserToResizeRows = false;
            DataGridView.RowHeadersVisible = false;
        }

        private void btnNguonVonOK_Click(object sender, EventArgs e)
        {
            try
            {
                ChiTietTaiSan temp = new ChiTietTaiSan();
                temp.MaTaiSan = txtMaTaiSan.Text.ToUpper();

                temp.MaNguonVon = txtNguonVon.Text.ToUpper();
                temp.NgayChungTu = DateTime.Parse(txtNgayChungTu.Text);
                temp.SoChungTu = txtSoChungTu.Text;
                temp.NguyenGia = double.Parse(txtNguyenGia.Text);
                temp.GiaTriDaKhauHao = double.Parse(txtGiaTriDaKhauHao.Text);
                temp.GiaTriConLai = double.Parse(txtGiaTriConLai.Text);
                temp.GiaTriKhauHao1Ky = double.Parse(txtGiaTriKhauHao1Ky.Text);
                temp.DienGiai = txtDienGiai.Text;

                //Check lỗi nguồn vốn

                LChiTietTaiSan.Add(temp);
                DataGridViewCTNguonVon.DataSource = LChiTietTaiSan.ToArray();
                FixDataGirdView(DataGridViewCTNguonVon, false);
                ResetNguonVon();
                if (isEditChiTietTaiSan) isEditChiTietTaiSan = false;
            }
            catch (Exception ex)
            {
                MSG.Error(ex);
            }
        }

        private void btnPhuTungKemTheoOK_Click(object sender, EventArgs e)
        {
            try
            {
                PhuTungKemTheo temp = new PhuTungKemTheo();
                temp.MaTaiSan = txtMaTaiSan.Text.ToUpper();

                temp.MaPhuTungKemTheo = txtMaPhuTungKemTheo.Text.ToUpper();
                temp.TenPhuTungKemTheo = txtTenPhuTungKemTheo.Text;
                temp.DVT = txtDonViTinh.Text;
                temp.SoLuong = double.Parse(txtSoLuong.Text);
                temp.GiaTri = double.Parse(txtGiaTri.Text);
                temp.GhiChu = txtGhiChuPhuTungKemTheo.Text;

                //Check lỗi phụ tùng kèm theo

                LPhuTungKemTheo.Add(temp);
                DataGridViewCTPhuTungKemTheo.DataSource = LPhuTungKemTheo.ToArray();
                FixDataGirdView(DataGridViewCTPhuTungKemTheo, true);
                ResetPhuTungKemTheo();
                if (isEditChiTietPhuTung) isEditChiTietPhuTung = false;
            }
            catch (Exception ex)
            {
                MSG.Error(ex);
            }
        }

        private void DataGridViewCTNguonVon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int vtIndex = e.RowIndex;
                if (vtIndex != -1)  //khi click lên tiêu đề header của datagrid thì bỏ qua
                {
                    if (isEditChiTietTaiSan)
                    {
                        MSG.MESSAGE("Bạn đang sửa Nguồn vốn!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    txtNguonVon.Text = LChiTietTaiSan[vtIndex].MaNguonVon;
                    txtNgayChungTu.Text = LChiTietTaiSan[vtIndex].NgayChungTu.ToString("dd/MM/yyyy");
                    txtSoChungTu.Text = LChiTietTaiSan[vtIndex].SoChungTu;
                    txtNguyenGia.Text = LChiTietTaiSan[vtIndex].NguyenGia.ToString();
                    txtGiaTriDaKhauHao.Text = LChiTietTaiSan[vtIndex].GiaTriDaKhauHao.ToString();
                    txtGiaTriConLai.Text = LChiTietTaiSan[vtIndex].GiaTriConLai.ToString();
                    txtGiaTriKhauHao1Ky.Text = LChiTietTaiSan[vtIndex].GiaTriKhauHao1Ky.ToString();
                    txtDienGiai.Text = LChiTietTaiSan[vtIndex].DienGiai;

                    LChiTietTaiSan.RemoveAt(vtIndex);
                    DataGridViewCTNguonVon.DataSource = LChiTietTaiSan.ToArray();
                    FixDataGirdView(DataGridViewCTNguonVon, false);
                    isEditChiTietTaiSan = true;
                }
            }
            catch (Exception ex)
            {
                MSG.Error(ex);
            }
        }

        private void DataGridViewCTPhuTungKemTheo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int vtIndex = e.RowIndex;
                if (vtIndex != -1)  //khi click lên tiêu đề header của datagrid thì bỏ qua
                {
                    if (isEditChiTietPhuTung)
                    {
                        MSG.MESSAGE("Bạn đang sửa Phụ tùng!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    txtMaPhuTungKemTheo.Text = LPhuTungKemTheo[vtIndex].MaPhuTungKemTheo;
                    txtTenPhuTungKemTheo.Text = LPhuTungKemTheo[vtIndex].TenPhuTungKemTheo;
                    txtDonViTinh.Text = LPhuTungKemTheo[vtIndex].DVT;
                    txtSoLuong.Text = LPhuTungKemTheo[vtIndex].SoLuong.ToString();
                    txtGiaTri.Text = LPhuTungKemTheo[vtIndex].GiaTri.ToString();
                    txtGhiChuPhuTungKemTheo.Text = LPhuTungKemTheo[vtIndex].GhiChu.ToString();

                    LPhuTungKemTheo.RemoveAt(vtIndex);
                    DataGridViewCTPhuTungKemTheo.DataSource = LPhuTungKemTheo.ToArray();
                    FixDataGirdView(DataGridViewCTPhuTungKemTheo, true);
                    isEditChiTietPhuTung = true;
                }
            }
            catch (Exception ex)
            {
                MSG.Error(ex);
            }
        }

        void ResetPhuTungKemTheo()
        {
            //Reset
            txtMaPhuTungKemTheo.Text = string.Empty;
            txtTenPhuTungKemTheo.Text = string.Empty;
            txtDonViTinh.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtGiaTri.Text = string.Empty;
            txtGhiChuPhuTungKemTheo.Text = string.Empty;
        }

        void ResetNguonVon()
        {
            //Reset
            txtNguonVon.Text = string.Empty;
            txtNgayChungTu.Text = string.Empty;
            txtSoChungTu.Text = string.Empty;
            txtNguyenGia.Text = string.Empty;
            txtGiaTriDaKhauHao.Text = string.Empty;
            txtGiaTriConLai.Text = string.Empty;
            txtGiaTriKhauHao1Ky.Text = string.Empty;
            txtDienGiai.Text = string.Empty;
        }

        private void txtNhomTaiSan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == CONFIG.KeyClass.key_TimKiem)
            {//Tìm kiếm
                FRM.frmTimKiem.phannhomtaisan = null;
                FRM.frmTimKiem frm = new FRM.frmTimKiem(CONFIG.ConstFrm.frmDMPhanNhomTaiSan);
                frm.ShowDialog();
                if (FRM.frmTimKiem.phannhomtaisan != null)
                {
                    txtNhomTaiSan.Text = FRM.frmTimKiem.phannhomtaisan.MaPhanNhomTaiSan.ToUpper();
                    lblTenNhomTaiSan.Text = FRM.frmTimKiem.phannhomtaisan.TenPhanNhomTaiSan;
                }
                FRM.frmTimKiem.phannhomtaisan = null;
            }
        }

        private void txtLyDoTang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == CONFIG.KeyClass.key_TimKiem)
            {//Tìm kiếm
                FRM.frmTimKiem.lydotanggiamtaisan = null;
                FRM.frmTimKiem frm = new FRM.frmTimKiem(CONFIG.ConstFrm.frmDMLyDoTangGiamTaiSan);
                frm.ShowDialog();
                if (FRM.frmTimKiem.lydotanggiamtaisan != null)
                {
                    txtLyDoTang.Text = FRM.frmTimKiem.lydotanggiamtaisan.MaLyDoTangGiamTaiSan.ToUpper();
                    lblTenLyDoTang.Text = FRM.frmTimKiem.lydotanggiamtaisan.TenLyDoTangGiamTaiSan;
                }
                FRM.frmTimKiem.lydotanggiamtaisan = null;
            }
        }

        private void txtBoPhanHachToan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == CONFIG.KeyClass.key_TimKiem)
            {//Tìm kiếm
                FRM.frmTimKiem.bophanhachtoan = null;
                FRM.frmTimKiem frm = new FRM.frmTimKiem(CONFIG.ConstFrm.frmDMBoPhanHachToan);
                frm.ShowDialog();
                if (FRM.frmTimKiem.bophanhachtoan != null)
                {
                    txtBoPhanHachToan.Text = FRM.frmTimKiem.bophanhachtoan.MaBoPhanHachToan.ToUpper();
                }
                FRM.frmTimKiem.bophanhachtoan = null;
            }
        }

        private void txtMaPhanXuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == CONFIG.KeyClass.key_TimKiem)
            {//Tìm kiếm
                FRM.frmTimKiem.phanxuong = null;
                FRM.frmTimKiem frm = new FRM.frmTimKiem(CONFIG.ConstFrm.frmDMPhanXuong);
                frm.ShowDialog();
                if (FRM.frmTimKiem.phanxuong != null)
                {
                    txtMaPhanXuong.Text = FRM.frmTimKiem.phanxuong.MaPhanXuong.ToUpper();
                }
                FRM.frmTimKiem.phanxuong = null;
            }
        }

        private void txtMaPhi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == CONFIG.KeyClass.key_TimKiem)
            {//Tìm kiếm
                FRM.frmTimKiem.phi = null;
                FRM.frmTimKiem frm = new FRM.frmTimKiem(CONFIG.ConstFrm.frmDMPhi);
                frm.ShowDialog();
                if (FRM.frmTimKiem.phi != null)
                {
                    txtMaPhi.Text = FRM.frmTimKiem.phi.MaPhi.ToUpper();
                }
                FRM.frmTimKiem.phi = null;
            }
        }

        private void txtBoPhanSuDung_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == CONFIG.KeyClass.key_TimKiem)
            {//Tìm kiếm
                FRM.frmTimKiem.bophansusung = null;
                FRM.frmTimKiem frm = new FRM.frmTimKiem(CONFIG.ConstFrm.frmDMBoPhanSuDung);
                frm.ShowDialog();
                if (FRM.frmTimKiem.bophansusung != null)
                {
                    txtBoPhanSuDung.Text = FRM.frmTimKiem.bophansusung.MaBoPhanSuDung.ToUpper();
                }
                FRM.frmTimKiem.bophansusung = null;
            }
        }

        private void txtNguonVon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == CONFIG.KeyClass.key_TimKiem)
            {//Tìm kiếm
                FRM.frmTimKiem.nguonvon = null;
                FRM.frmTimKiem frm = new FRM.frmTimKiem(CONFIG.ConstFrm.frmDMNguonVon);
                frm.ShowDialog();
                if (FRM.frmTimKiem.nguonvon != null)
                {
                    txtNguonVon.Text = FRM.frmTimKiem.nguonvon.MaNguonVon.ToUpper();
                }
                FRM.frmTimKiem.nguonvon = null;
            }
        }
    }
}