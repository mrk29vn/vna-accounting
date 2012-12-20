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

namespace VNA_Project.FRM
{
    public partial class frmTimKiem : Qios.DevSuite.Components.Ribbon.QRibbonForm
    {
        #region khai báo
        string chose = string.Empty;
        int vtIndex = 0;    //vị trí dòng cell đang được chọn trong datagridview

        //------------------------------------------>
        public static LoaiTaiSan loaitaisan = null;
        List<LoaiTaiSan> Lloaitaisan = new List<LoaiTaiSan>();

        public static TaiSan taisan = null;
        List<TaiSan> Ltaisan = new List<TaiSan>();

        public static PhanNhomTaiSan phannhomtaisan = null;
        List<PhanNhomTaiSan> Lphannhomtaisan = new List<PhanNhomTaiSan>();

        public static LyDoTangGiamTaiSan lydotanggiamtaisan = null;
        List<LyDoTangGiamTaiSan> Llydotanggiamtaisan = new List<LyDoTangGiamTaiSan>();

        public static BoPhanHachToan bophanhachtoan = null;
        List<BoPhanHachToan> Lbophanhachtoan = new List<BoPhanHachToan>();

        public static PhanXuong phanxuong = null;
        List<PhanXuong> Lphanxuong = new List<PhanXuong>();

        public static Phi phi = null;
        List<Phi> Lphi = new List<Phi>();

        public static BoPhanSuDung bophansusung = null;
        List<BoPhanSuDung> Lbophansusung = new List<BoPhanSuDung>();

        public static NguonVon nguonvon = null;
        List<NguonVon> Lnguonvon = new List<NguonVon>();
        #endregion

        public frmTimKiem()
        {
            InitializeComponent();
        }
        public frmTimKiem(string chose)
        {
            InitializeComponent();
            this.chose = chose;
        }

        private void frmLoad(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            DongY();
            this.Close();
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

            switch (chose)
            {
                case CONFIG.ConstFrm.frmDMBoPhanHachToan:
                    {
                        DataGridView.Columns["MaBoPhanHachToan"].HeaderText = "Mã bộ phận hạch toán";
                        DataGridView.Columns["TenBoPhanHachToan"].HeaderText = "Tên bộ phận hạch toán";

                        DataGridView.Columns["MaBoPhanHachToan"].Visible = true;
                        DataGridView.Columns["TenBoPhanHachToan"].Visible = true;
                        break;
                    }
                case CONFIG.ConstFrm.frmDMBoPhanSuDung:
                    {
                        DataGridView.Columns["MaBoPhanSuDung"].HeaderText = "Mã bộ phận sử dụng";
                        DataGridView.Columns["TenBoPhanSuDung"].HeaderText = "Tên bộ phận sử dụng";

                        DataGridView.Columns["MaBoPhanSuDung"].Visible = true;
                        DataGridView.Columns["TenBoPhanSuDung"].Visible = true;
                        break;
                    }
                case CONFIG.ConstFrm.frmDMLoaiTaiSan:
                    {
                        DataGridView.Columns["MaLoaiTaiSan"].HeaderText = "Mã loại tài sản";
                        DataGridView.Columns["TenLoaiTaiSan"].HeaderText = "Tên loại tài sản";

                        DataGridView.Columns["MaLoaiTaiSan"].Visible = true;
                        DataGridView.Columns["TenLoaiTaiSan"].Visible = true;
                        break;
                    }
                case CONFIG.ConstFrm.frmDMLyDoTangGiamTaiSan:
                    {
                        DataGridView.Columns["LoaiTangGiamTaiSanVIEW"].HeaderText = "Loại lý do tăng giảm tài sản";
                        DataGridView.Columns["MaLyDoTangGiamTaiSan"].HeaderText = "Mã lý do tăng giảm tài sản";
                        DataGridView.Columns["TenLyDoTangGiamTaiSan"].HeaderText = "Tên tên lý do tăng giảm tài sản";

                        DataGridView.Columns["LoaiTangGiamTaiSan"].Visible = false;
                        DataGridView.Columns["LoaiTangGiamTaiSanVIEW"].Visible = true;
                        DataGridView.Columns["MaLyDoTangGiamTaiSan"].Visible = true;
                        DataGridView.Columns["TenLyDoTangGiamTaiSan"].Visible = true;
                        break;
                    }
                case CONFIG.ConstFrm.frmDMNguonVon:
                    {
                        DataGridView.Columns["MaNguonVon"].HeaderText = "Mã nguồn vốn";
                        DataGridView.Columns["TenNguonVon"].HeaderText = "Tên nguồn vốn";

                        DataGridView.Columns["MaNguonVon"].Visible = true;
                        DataGridView.Columns["TenNguonVon"].Visible = true;
                        break;
                    }
                case CONFIG.ConstFrm.frmDMPhanNhomTaiSan:
                    {
                        DataGridView.Columns["MaPhanNhomTaiSan"].HeaderText = "Mã phân nhóm tài sản";
                        DataGridView.Columns["TenPhanNhomTaiSan"].HeaderText = "Tên phân nhóm tài sản";
                        DataGridView.Columns["KieuPhanNhomTaiSan"].HeaderText = "Kiểu phân nhóm tài sản";

                        DataGridView.Columns["MaPhanNhomTaiSan"].Visible = true;
                        DataGridView.Columns["TenPhanNhomTaiSan"].Visible = true;
                        DataGridView.Columns["KieuPhanNhomTaiSan"].Visible = true;
                        break;
                    }
                case CONFIG.ConstFrm.frmDMPhanXuong:
                    {
                        DataGridView.Columns["MaPhanXuong"].HeaderText = "Mã phân xưởng";
                        DataGridView.Columns["TenPhanXuong"].HeaderText = "Tên phân xưởng";

                        DataGridView.Columns["MaPhanXuong"].Visible = true;
                        DataGridView.Columns["TenPhanXuong"].Visible = true;
                        break;
                    }
                case CONFIG.ConstFrm.frmDMPhi:
                    {
                        DataGridView.Columns["MaPhi"].HeaderText = "Mã phí";
                        DataGridView.Columns["TenPhi"].HeaderText = "Tên phí";

                        DataGridView.Columns["MaPhi"].Visible = true;
                        DataGridView.Columns["TenPhi"].Visible = true;
                        break;
                    }
                case CONFIG.ConstFrm.frmDMTaiSan:
                    {
                        DataGridView.Columns["MaTaiSan"].HeaderText = "Mã tài sản";
                        DataGridView.Columns["TenTaiSan"].HeaderText = "Tên tài sản";

                        DataGridView.Columns["MaTaiSan"].Visible = true;
                        DataGridView.Columns["TenTaiSan"].Visible = true;
                        break;
                    }
                case CONFIG.ConstFrm.frmDMThietBi:
                    {
                        DataGridView.Columns["MaThietBi"].HeaderText = "Mã Thiết bị";
                        DataGridView.Columns["TenThietBi"].HeaderText = "Tên Thiết bị";

                        DataGridView.Columns["MaThietBi"].Visible = true;
                        DataGridView.Columns["TenThietBi"].Visible = true;
                        break;
                    }
                default:
                    break;
            }

            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView.AllowUserToAddRows = false;
            DataGridView.AllowUserToDeleteRows = false;
            DataGridView.AllowUserToResizeRows = false;
            DataGridView.RowHeadersVisible = false;
        }
        #endregion

        #region Nghiệp vụ
        //------------------------------------------>
        private void HienThi()
        {
            switch (chose)
            {
                case CONFIG.ConstFrm.frmDMLoaiTaiSan:
                    {
                        Lloaitaisan = LoaiTaiSanBiz.getListLoaiTaiSan();
                        DataGridView.DataSource = Lloaitaisan.ToArray();
                        FixDataGirdView();
                        break;
                    }
                case CONFIG.ConstFrm.frmDMTaiSan:
                    {
                        Ltaisan = TaiSanBiz.getListTaiSan();
                        DataGridView.DataSource = Ltaisan.ToArray();
                        FixDataGirdView();
                        break;
                    }
                case CONFIG.ConstFrm.frmDMPhanNhomTaiSan:
                    {
                        Lphannhomtaisan = PhanNhomTaiSanBiz.getListPhanNhomTaiSan();
                        DataGridView.DataSource = Lphannhomtaisan.ToArray();
                        FixDataGirdView();
                        break;
                    }
                case CONFIG.ConstFrm.frmDMLyDoTangGiamTaiSan:
                    {
                        Llydotanggiamtaisan = LyDoTangGiamTaiSanBiz.getListLyDoTangGiamTaiSan();
                        DataGridView.DataSource = Llydotanggiamtaisan.ToArray();
                        FixDataGirdView();
                        break;
                    }
                case CONFIG.ConstFrm.frmDMBoPhanHachToan:
                    {
                        Lbophanhachtoan = BoPhanHachToanBiz.getListBoPhanHachToan();
                        DataGridView.DataSource = Lbophanhachtoan.ToArray();
                        FixDataGirdView();
                        break;
                    }
                case CONFIG.ConstFrm.frmDMPhanXuong:
                    {
                        Lphanxuong = PhanXuongBiz.getListPhanXuong();
                        DataGridView.DataSource = Lphanxuong.ToArray();
                        FixDataGirdView();
                        break;
                    }
                case CONFIG.ConstFrm.frmDMPhi:
                    {
                        Lphi = PhiBiz.getListPhi();
                        DataGridView.DataSource = Lphi.ToArray();
                        FixDataGirdView();
                        break;
                    }
                case CONFIG.ConstFrm.frmDMBoPhanSuDung:
                    {
                        Lbophansusung = BoPhanSuDungBiz.getListBoPhanSuDung();
                        DataGridView.DataSource = Lbophansusung.ToArray();
                        FixDataGirdView();
                        break;
                    }
                case CONFIG.ConstFrm.frmDMNguonVon:
                    {
                        Lnguonvon = NguonVonBiz.getListNguonVon();
                        DataGridView.DataSource = Lnguonvon.ToArray();
                        FixDataGirdView();
                        break;
                    }
                default:
                    break;
            }
        }
        #endregion

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {//Khi click vào Datagridview thì lấy vị trí của dòng vừa click vào và lưu lại vào biến vtIndex
            vtIndex = e.RowIndex;
        }
        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (vtIndex == -1) return;
            DongY();
            this.Close();
        }

        //------------------------------------------>
        private void txtMaSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                switch (chose)
                {
                    case CONFIG.ConstFrm.frmDMLoaiTaiSan:
                        {
                            List<LoaiTaiSan> Ltemp = new List<LoaiTaiSan>();
                            string search = txtMaSearch.Text.ToUpper();
                            foreach (LoaiTaiSan item in Lloaitaisan)
                            {
                                if (item.MaLoaiTaiSan.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMTaiSan:
                        {
                            List<TaiSan> Ltemp = new List<TaiSan>();
                            string search = txtMaSearch.Text.ToUpper();
                            foreach (TaiSan item in Ltaisan)
                            {
                                if (item.MaTaiSan.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMPhanNhomTaiSan:
                        {
                            List<PhanNhomTaiSan> Ltemp = new List<PhanNhomTaiSan>();
                            string search = txtMaSearch.Text.ToUpper();
                            foreach (PhanNhomTaiSan item in Lphannhomtaisan)
                            {
                                if (item.MaPhanNhomTaiSan.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMLyDoTangGiamTaiSan:
                        {
                            List<LyDoTangGiamTaiSan> Ltemp = new List<LyDoTangGiamTaiSan>();
                            string search = txtMaSearch.Text.ToUpper();
                            foreach (LyDoTangGiamTaiSan item in Llydotanggiamtaisan)
                            {
                                if (item.MaLyDoTangGiamTaiSan.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMBoPhanHachToan:
                        {
                            List<BoPhanHachToan> Ltemp = new List<BoPhanHachToan>();
                            string search = txtMaSearch.Text.ToUpper();
                            foreach (BoPhanHachToan item in Lbophanhachtoan)
                            {
                                if (item.MaBoPhanHachToan.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMPhanXuong:
                        {
                            List<PhanXuong> Ltemp = new List<PhanXuong>();
                            string search = txtMaSearch.Text.ToUpper();
                            foreach (PhanXuong item in Lphanxuong)
                            {
                                if (item.MaPhanXuong.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMPhi:
                        {
                            List<Phi> Ltemp = new List<Phi>();
                            string search = txtMaSearch.Text.ToUpper();
                            foreach (Phi item in Lphi)
                            {
                                if (item.MaPhi.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMBoPhanSuDung:
                        {
                            List<BoPhanSuDung> Ltemp = new List<BoPhanSuDung>();
                            string search = txtMaSearch.Text.ToUpper();
                            foreach (BoPhanSuDung item in Lbophansusung)
                            {
                                if (item.MaBoPhanSuDung.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMNguonVon:
                        {
                            List<NguonVon> Ltemp = new List<NguonVon>();
                            string search = txtMaSearch.Text.ToUpper();
                            foreach (NguonVon item in Lnguonvon)
                            {
                                if (item.MaNguonVon.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MSG.Error(ex);
            }
        }

        //------------------------------------------>
        private void txtTenSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                switch (chose)
                {
                    case CONFIG.ConstFrm.frmDMLoaiTaiSan:
                        {
                            List<LoaiTaiSan> Ltemp = new List<LoaiTaiSan>();
                            string search = txtMaSearch.Text.ToUpper();
                            foreach (LoaiTaiSan item in Lloaitaisan)
                            {
                                if (item.TenLoaiTaiSan.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMTaiSan:
                        {
                            List<TaiSan> Ltemp = new List<TaiSan>();
                            string search = txtTenSearch.Text.ToUpper();
                            foreach (TaiSan item in Ltaisan)
                            {
                                if (item.TenTaiSan.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMPhanNhomTaiSan:
                        {
                            List<PhanNhomTaiSan> Ltemp = new List<PhanNhomTaiSan>();
                            string search = txtTenSearch.Text.ToUpper();
                            foreach (PhanNhomTaiSan item in Lphannhomtaisan)
                            {
                                if (item.TenPhanNhomTaiSan.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMLyDoTangGiamTaiSan:
                        {
                            List<LyDoTangGiamTaiSan> Ltemp = new List<LyDoTangGiamTaiSan>();
                            string search = txtTenSearch.Text.ToUpper();
                            foreach (LyDoTangGiamTaiSan item in Llydotanggiamtaisan)
                            {
                                if (item.TenLyDoTangGiamTaiSan.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMBoPhanHachToan:
                        {
                            List<BoPhanHachToan> Ltemp = new List<BoPhanHachToan>();
                            string search = txtTenSearch.Text.ToUpper();
                            foreach (BoPhanHachToan item in Lbophanhachtoan)
                            {
                                if (item.TenBoPhanHachToan.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMPhanXuong:
                        {
                            List<PhanXuong> Ltemp = new List<PhanXuong>();
                            string search = txtTenSearch.Text.ToUpper();
                            foreach (PhanXuong item in Lphanxuong)
                            {
                                if (item.TenPhanXuong.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMPhi:
                        {
                            List<Phi> Ltemp = new List<Phi>();
                            string search = txtTenSearch.Text.ToUpper();
                            foreach (Phi item in Lphi)
                            {
                                if (item.TenPhi.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMBoPhanSuDung:
                        {
                            List<BoPhanSuDung> Ltemp = new List<BoPhanSuDung>();
                            string search = txtTenSearch.Text.ToUpper();
                            foreach (BoPhanSuDung item in Lbophansusung)
                            {
                                if (item.TenBoPhanSuDung.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    case CONFIG.ConstFrm.frmDMNguonVon:
                        {
                            List<NguonVon> Ltemp = new List<NguonVon>();
                            string search = txtTenSearch.Text.ToUpper();
                            foreach (NguonVon item in Lnguonvon)
                            {
                                if (item.TenNguonVon.ToUpper().Contains(search)) Ltemp.Add(item);
                            }
                            DataGridView.DataSource = Ltemp.ToArray();
                            FixDataGirdView();
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MSG.Error(ex);
            }
        }

        private void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    vtIndex = DataGridView.SelectedRows[0].Index;
                    if (vtIndex == -1) return;
                    DongY();
                    this.Close();
                }
                else
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                MSG.Error(ex);
            }
        }

        //------------------------------------------>
        private void DongY()
        {
            if (vtIndex == -1) return;
            switch (chose)
            {
                case CONFIG.ConstFrm.frmDMLoaiTaiSan:
                    {
                        loaitaisan = Utils.DataGridViewRow_to_LoaiTaiSan(DataGridView.Rows[vtIndex]);
                        break;
                    }
                case CONFIG.ConstFrm.frmDMTaiSan:
                    {
                        taisan = Utils.DataGridViewRow_to_TaiSan(DataGridView.Rows[vtIndex]);
                        break;
                    }
                case CONFIG.ConstFrm.frmDMPhanNhomTaiSan:
                    {
                        phannhomtaisan = Utils.DataGridViewRow_to_PhanNhomTaiSan(DataGridView.Rows[vtIndex]);
                        break;
                    }
                case CONFIG.ConstFrm.frmDMLyDoTangGiamTaiSan:
                    {
                        lydotanggiamtaisan = Utils.DataGridViewRow_to_LyDoTangGiamTaiSan(DataGridView.Rows[vtIndex]);
                        break;
                    }
                case CONFIG.ConstFrm.frmDMBoPhanHachToan:
                    {
                        bophanhachtoan = Utils.DataGridViewRow_to_BoPhanHachToan(DataGridView.Rows[vtIndex]);
                        break;
                    }
                case CONFIG.ConstFrm.frmDMPhanXuong:
                    {
                        phanxuong = Utils.DataGridViewRow_to_PhanXuong(DataGridView.Rows[vtIndex]);
                        break;
                    }
                case CONFIG.ConstFrm.frmDMPhi:
                    {
                        phi = Utils.DataGridViewRow_to_Phi(DataGridView.Rows[vtIndex]);
                        break;
                    }
                case CONFIG.ConstFrm.frmDMBoPhanSuDung:
                    {
                        bophansusung = Utils.DataGridViewRow_to_BoPhanSuDung(DataGridView.Rows[vtIndex]);
                        break;
                    }
                case CONFIG.ConstFrm.frmDMNguonVon:
                    {
                        nguonvon = Utils.DataGridViewRow_to_NguonVon(DataGridView.Rows[vtIndex]);
                        break;
                    }
                default:
                    break;
            }
        }
    }
}