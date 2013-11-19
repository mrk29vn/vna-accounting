using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Entities;
using GUI.Model;

namespace GUI
{
    public partial class FrmBcThongKeMatHangBanRaTheoNhanVien : Form
    {
        #region khai báo
        DateTime _ngayHienTai = DateTime.Now;   //DateServer.Date();

        readonly List<NhanVien> _nhanViens = new List<NhanVien>();
        readonly List<HangHoa> _hangHoas = new List<HangHoa>();
        readonly List<HDBanHang> _hdBanHangs = new List<HDBanHang>();
        readonly List<ChiTietHDBanHang> _chiTietHdBanHangs = new List<ChiTietHDBanHang>();

        private List<BcThongKeMatHangBanRaTheoNhanVien> _bcThongKeMatHangBanRaTheoNhanViens = new List<BcThongKeMatHangBanRaTheoNhanVien>();
        #endregion khai báo

        #region khởi tạo
        public FrmBcThongKeMatHangBanRaTheoNhanVien()
        {
            InitializeComponent();

            LayDuLieuNhanVien();
            cbbChonNhanVien.DataSource = _nhanViens;
            cbbChonNhanVien.DisplayMember = "MaNhanVien";
            cbbChonNhanVien.SelectedIndex = _nhanViens.Count == 0 ? -1 : 0;

            //Mặc định thiết lập lọc thời gian là tháng hiện tại
            cbbChonThoiGian.SelectedIndex = 0;

            uGrid.DataSource = new List<BcThongKeMatHangBanRaTheoNhanVien>();
            FixDataGridView();

            LoadData();
        }
        #endregion khởi tạo

        #region Event
        #region Event StatusStrip
        private void TssResetClick(object sender, EventArgs e)
        {//Load lại dữ liệu
            LoadData();
        }

        private void TssViewClick(object sender, EventArgs e)
        {//Xem trước báo cáo
            List<BcThongKeMatHangBanRaTheoNhanVien> thongKeMatHangBanRaTheoNhanViens = (List<BcThongKeMatHangBanRaTheoNhanVien>)uGrid.DataSource;
            if (thongKeMatHangBanRaTheoNhanViens.Count == 0)
            {
                MessageBox.Show("Dữ liệu đang trống", "Thông báo");
                return;
            }
            new frmBaoCaorpt(thongKeMatHangBanRaTheoNhanViens, GetDicInput()).ShowDialog();
        }

        private void TssPdfClick(object sender, EventArgs e)
        {//Xuất ra PDF
            List<BcThongKeMatHangBanRaTheoNhanVien> thongKeMatHangBanRaTheoNhanViens = (List<BcThongKeMatHangBanRaTheoNhanVien>)uGrid.DataSource;
            if (thongKeMatHangBanRaTheoNhanViens.Count == 0)
            {
                MessageBox.Show("Dữ liệu đang trống", "Thông báo");
                return;
            }
            Enabled = false;
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = "PDF |*.pdf", FileName = string.Empty };
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    frmBaoCaorpt frmBaoCaorpt = new frmBaoCaorpt(thongKeMatHangBanRaTheoNhanViens, GetDicInput(), saveFileDialog1.FileName, "PDF");
                }
            }
            catch { }
            Enabled = true;
        }

        private void TssWordClick(object sender, EventArgs e)
        {//Xuất ra word
            List<BcThongKeMatHangBanRaTheoNhanVien> thongKeMatHangBanRaTheoNhanViens = (List<BcThongKeMatHangBanRaTheoNhanVien>)uGrid.DataSource;
            if (thongKeMatHangBanRaTheoNhanViens.Count == 0)
            {
                MessageBox.Show("Dữ liệu đang trống", "Thông báo");
                return;
            }
            Enabled = false;
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = "Word |*.doc", FileName = string.Empty };
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    frmBaoCaorpt frmBaoCaorpt = new frmBaoCaorpt(thongKeMatHangBanRaTheoNhanViens, GetDicInput(), saveFileDialog1.FileName, "Word");
                }
            }
            catch { }
            Enabled = true;
        }

        private void TssExcelClick(object sender, EventArgs e)
        {//Xuất ra Excel
            List<BcThongKeMatHangBanRaTheoNhanVien> thongKeMatHangBanRaTheoNhanViens = (List<BcThongKeMatHangBanRaTheoNhanVien>)uGrid.DataSource;
            if (thongKeMatHangBanRaTheoNhanViens.Count == 0)
            {
                MessageBox.Show("Dữ liệu đang trống", "Thông báo");
                return;
            }
            Enabled = false;
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = "Excel |*.xls", FileName = string.Empty };
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    frmBaoCaorpt frmBaoCaorpt = new frmBaoCaorpt(thongKeMatHangBanRaTheoNhanViens, GetDicInput(), saveFileDialog1.FileName, "Excel");
                }
            }
            catch { }
            Enabled = true;
        }

        private void TssExitClick(object sender, EventArgs e)
        {//Thoát chương trình
            Close();
        }
        #endregion Event StatusStrip

        private void BtnHienThiClick(object sender, EventArgs e)
        {
            LoadData();
        }

        private void CbbChonThoiGianSelectedIndexChanged(object sender, EventArgs e)
        {//Thay đổi Cbb chọn thời gian
            try
            {
                ComboBox comboBox = (ComboBox)sender;
                switch (comboBox.SelectedIndex)
                {
                    case 0:
                        dteTuNgay.Enabled = false;
                        dteDenNgay.Enabled = false;
                        dteTuNgay.Value = new DateTime(_ngayHienTai.Year, _ngayHienTai.Month, 1);
                        dteDenNgay.Value = new DateTime(_ngayHienTai.Year, _ngayHienTai.Month, DateTime.DaysInMonth(_ngayHienTai.Year, _ngayHienTai.Month));
                        break;
                    case 1:
                        dteTuNgay.Enabled = true;
                        dteDenNgay.Enabled = true;
                        break;
                }
            }
            catch { }
        }

        private void CbbChonNhanVienSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox comboBox = (ComboBox)sender;
                var nhanVien = comboBox.SelectedItem as NhanVien;
                if (nhanVien != null)
                    lblTenNhanVien.Text = nhanVien.TenNhanVien;
            }
            catch
            {

            }
        }

        #endregion Event

        #region Utils
        Dictionary<string, object> GetDicInput()
        {
            Dictionary<string, object> dicInput = new Dictionary<string, object>();
            var nhanVien = cbbChonNhanVien.SelectedItem as NhanVien;
            string manhanvien = nhanVien == null ? string.Empty : nhanVien.MaNhanVien;
            string tennhanvien = nhanVien == null ? string.Empty : nhanVien.TenNhanVien;
            DateTime tungay = dteTuNgay.Value;
            DateTime denngay = dteDenNgay.Value;

            dicInput.Add("MaNhanVien", manhanvien);
            dicInput.Add("TenNhanVien", tennhanvien);
            dicInput.Add("TuNgay", tungay);
            dicInput.Add("DenNgay", denngay);
            return dicInput;
        }

        void LoadData()
        {
            //Lấy dữ liệu
            const string sql = "select HDBanHang.MaHDBanHang, HDBanHang.NgayBan, HDBanHang.MaKho, HDBanHang.MaNhanVien, "
                               + "ChiTietHDBanHang.MaHangHoa, ChiTietHDBanHang.TenHangHoa, ChiTietHDBanHang.SoLuong, ChiTietHDBanHang.DonGia, ChiTietHDBanHang.Thue, ChiTietHDBanHang.PhanTramChietKhau "
                               + "from HDBanHang INNER JOIN ChiTietHDBanHang on HDBanHang.MaHDBanHang = ChiTietHDBanHang.MaHDBanHang "
                               + "where HDBanHang.MaNhanVien = '{0}' and HDBanHang.NgayBan between Convert(Datetime,'{1}',101) and Convert(Datetime,'{2}',101)  and HDBanHang.Deleted = 0";
            var nhanVien = cbbChonNhanVien.SelectedItem as NhanVien;
            if (nhanVien == null) return;

            string maNhanVien = nhanVien.MaNhanVien;
            string tungay = dteTuNgay.Value.ToString("MM/dd/yyyy");
            string denngay = dteDenNgay.Value.ToString("MM/dd/yyyy");

            string input = string.Format(sql, maNhanVien, tungay, denngay);
            object output;
            bool kq = Utils.GetDataFromServer("RunSql", input, out output);
            if (!kq) return;
            _bcThongKeMatHangBanRaTheoNhanViens = Utils.ConvertToList<BcThongKeMatHangBanRaTheoNhanVien>((DataTable)output);

            var qr = from k in _bcThongKeMatHangBanRaTheoNhanViens
                     group k by k.MaHangHoa into kk
                     select new BcThongKeMatHangBanRaTheoNhanVien
                                {
                                    MaHangHoa = kk.Key,
                                    TenHangHoa = kk.FirstOrDefault().TenHangHoa,
                                    SoLuong = kk.Sum(kkk => kkk.SoLuong),
                                    DonGia = kk.Sum(kkk => kkk.SoLuong * kkk.DonGia * 0.01 * (100 + kkk.Thue))
                                };
            uGrid.DataSource = qr.ToList();
        }

        private void LayDuLieuChiTietHoaDonBanHang()
        {
            //lấy dữ liệu chi tiết hóa đơn bán hàng
            ChiTietHDBanHang inputCtHdbbh = new ChiTietHDBanHang { HanhDong = "Select" };
            ChiTietHDBanHang[] outputCtHdbbh;
            bool kqCtHdbh = Utils.GetDataFromServer("ChiTietHDBanHang", inputCtHdbbh, out outputCtHdbbh);
            if (kqCtHdbh) _chiTietHdBanHangs.AddRange(outputCtHdbbh);
        }

        private void LayDuLieuHoaDonBanHang()
        {
            //lấy dữ liệu hóa đơn bán hàng
            HDBanHang inputHdbbh = new HDBanHang { HanhDong = "Select" };
            HDBanHang[] outputHdbh;
            bool kqHdbh = Utils.GetDataFromServer("HDBanHang", inputHdbbh, out outputHdbh);
            if (kqHdbh) _hdBanHangs.AddRange(outputHdbh);
        }

        private void LayDuLieuHangHoa()
        {
            //lấy dữ liệu hàng hóa
            HangHoa inputHh = new HangHoa { HanhDong = "Select" };
            HangHoa[] outputHh;
            bool kqHh = Utils.GetDataFromServer("HangHoa", inputHh, out outputHh);
            if (kqHh) _hangHoas.AddRange(outputHh);
        }

        private void LayDuLieuNhanVien()
        {
            //Lấy dữ liệu nhân viên
            NhanVien inputNv = new NhanVien { HanhDong = "Select" };
            NhanVien[] outputNv;
            bool kqNv = Utils.GetDataFromServer("NhanVien", inputNv, out outputNv);
            if (kqNv) _nhanViens.AddRange(outputNv);
        }

        void FixDataGridView()
        {
            uGrid.ReadOnly = true;
            uGrid.RowHeadersVisible = false;
            foreach (DataGridViewColumn column in uGrid.Columns) column.Visible = false;
            uGrid.Columns["MaHangHoa"].Visible = true;
            uGrid.Columns["TenHangHoa"].Visible = true;
            uGrid.Columns["SoLuong"].Visible = true;
            uGrid.Columns["DonGia"].Visible = true;

            //uGrid.Columns["MaHDBanHang"].HeaderText = "Mã hóa đơn";
            //uGrid.Columns["NgayBan"].HeaderText = "Ngày bán";
            //uGrid.Columns["MaKho"].HeaderText = "Mã kho";
            //uGrid.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            uGrid.Columns["MaHangHoa"].HeaderText = "Mã hàng hóa";
            uGrid.Columns["TenHangHoa"].HeaderText = "Tên hàng hóa";
            uGrid.Columns["SoLuong"].HeaderText = "Số lượng";
            uGrid.Columns["DonGia"].HeaderText = "Đơn giá";
            //uGrid.Columns["Thue"].HeaderText = "Thuế";
            //uGrid.Columns["PhanTramChietKhau"].HeaderText = "Phần trăm chiết khấu";
            uGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion Utils

        private void TxttimkiemTextChanged(object sender, EventArgs e)
        {
            //Tìm kiếm tương đối theo mã và tên
            if (rdoSearchMa.Checked)
            {//tìm kiếm theo mã
                //
            }
            else if (rdoSearchTen.Checked)
            {//tìm kiếm theo tên
                //
            }
            else if (rdoSearchTen.Checked)
            {//tìm kiếm tất cả
                //
            }
        }
    }
}
