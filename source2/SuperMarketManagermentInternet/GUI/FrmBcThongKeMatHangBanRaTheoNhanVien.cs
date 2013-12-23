using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Entities;
using GUI.Model;
using GUI.Properties;

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

        private readonly List<BcThongKeMatHangBanRaTheoNhanVien> _bcThongKeMatHangBanRaTheoNhanViens = new List<BcThongKeMatHangBanRaTheoNhanVien>();
        private List<BcThongKeMatHangBanRaTheoNhanVien> _bcThongKeMatHangBanRaTheoNhanViensGroup = new List<BcThongKeMatHangBanRaTheoNhanVien>();
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
            if (_bcThongKeMatHangBanRaTheoNhanViensGroup.Count == 0)
            {
                MessageBox.Show(Resources.MSG_DuLieuDangTrong, Resources.MSG_ThongBao);
                return;
            }
            new frmBaoCaorpt(_bcThongKeMatHangBanRaTheoNhanViensGroup, GetDicInput()).ShowDialog();
        }

        private void TssPdfClick(object sender, EventArgs e)
        {//Xuất ra PDF
            if (_bcThongKeMatHangBanRaTheoNhanViensGroup.Count == 0)
            {
                MessageBox.Show(Resources.MSG_DuLieuDangTrong, Resources.MSG_ThongBao);
                return;
            }
            Enabled = false;
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = Resources.MSG_SaveFileDialog_Filter_PDF, FileName = string.Empty };
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    frmBaoCaorpt frmBaoCaorpt = new frmBaoCaorpt(_bcThongKeMatHangBanRaTheoNhanViensGroup, GetDicInput(), saveFileDialog1.FileName, "PDF");
                }
            }
            catch { }
            Enabled = true;
        }

        private void TssWordClick(object sender, EventArgs e)
        {//Xuất ra word
            if (_bcThongKeMatHangBanRaTheoNhanViensGroup.Count == 0)
            {
                MessageBox.Show(Resources.MSG_DuLieuDangTrong, Resources.MSG_ThongBao);
                return;
            }
            Enabled = false;
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = Resources.MSG_SaveFileDialog_Filter_Word, FileName = string.Empty };
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    frmBaoCaorpt frmBaoCaorpt = new frmBaoCaorpt(_bcThongKeMatHangBanRaTheoNhanViensGroup, GetDicInput(), saveFileDialog1.FileName, "Word");
                }
            }
            catch { }
            Enabled = true;
        }

        private void TssExcelClick(object sender, EventArgs e)
        {//Xuất ra Excel
            if (_bcThongKeMatHangBanRaTheoNhanViensGroup.Count == 0)
            {
                MessageBox.Show(Resources.MSG_DuLieuDangTrong, Resources.MSG_ThongBao);
                return;
            }
            Enabled = false;
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = Resources.MSG_SaveFileDialog_Filter_Excel, FileName = string.Empty };
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    frmBaoCaorpt frmBaoCaorpt = new frmBaoCaorpt(_bcThongKeMatHangBanRaTheoNhanViensGroup, GetDicInput(), saveFileDialog1.FileName, "Excel");
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
                if (comboBox.SelectedIndex == -1) return;
                dteTuNgay.Enabled = comboBox.SelectedIndex == comboBox.Items.Count - 1;
                dteDenNgay.Enabled = comboBox.SelectedIndex == comboBox.Items.Count - 1;
                if (comboBox.SelectedIndex == comboBox.Items.Count - 1) return;
                dteTuNgay.Value = new DateTime(_ngayHienTai.Year, comboBox.SelectedIndex + 1, 1);
                dteDenNgay.Value = new DateTime(_ngayHienTai.Year, comboBox.SelectedIndex + 1, DateTime.DaysInMonth(_ngayHienTai.Year, comboBox.SelectedIndex + 1));
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
            var nhanVien = cbbChonNhanVien.SelectedItem as NhanVien;
            if (nhanVien == null) return;

            string maNhanVien = nhanVien.MaNhanVien;
            string tungay = dteTuNgay.Value.ToString("MM/dd/yyyy");
            string denngay = dteDenNgay.Value.ToString("MM/dd/yyyy");

            #region lấy dữ liệu hóa đơn bán hàng
            //Lấy danh sách hàng hóa được bán trong khoảng thời gian này, bởi nhân viên này
            const string sql = "select HDBanHang.MaHDBanHang, HDBanHang.NgayBan, HDBanHang.MaKho, HDBanHang.MaNhanVien, "
                               + "ChiTietHDBanHang.MaHangHoa, ChiTietHDBanHang.TenHangHoa, ChiTietHDBanHang.SoLuong, ChiTietHDBanHang.DonGia, ChiTietHDBanHang.Thue, ChiTietHDBanHang.PhanTramChietKhau "
                               + "from HDBanHang INNER JOIN ChiTietHDBanHang on HDBanHang.MaHDBanHang = ChiTietHDBanHang.MaHDBanHang "
                               + "where HDBanHang.MaNhanVien = '{0}' and HDBanHang.NgayBan between Convert(Datetime,'{1}',101) and Convert(Datetime,'{2}',101)  and HDBanHang.Deleted = 0";
            string input = string.Format(sql, maNhanVien, tungay, denngay);
            object output;
            bool kq = Utils.GetDataFromServer("RunSql", input, out output);
            if (!kq) return;
            List<BcThongKeMatHangBanRaTheoNhanVien> bcThongKeMatHangBanRaTheoNhanViens = Utils.ConvertToList<BcThongKeMatHangBanRaTheoNhanVien>((DataTable)output);
            #endregion

            #region lấy dữ liệu khách hàng trả lại
            //lấy danh sách hàng hóa được trả lại trong khoảng thời gian này
            const string sqlKhtl = "select KhachHangTraLai.MaKhachHangTraLai, KhachHangTraLai.MaHoaDonMuaHang, KhachHangTraLai.NgayNhap, KhachHangTraLai.MaKho, "
                               + "ChiTietKhachHangTraLai.MaHangHoa, ChiTietKhachHangTraLai.TenHangHoa, ChiTietKhachHangTraLai.SoLuong, ChiTietKhachHangTraLai.DonGia, ChiTietKhachHangTraLai.Thue, ChiTietKhachHangTraLai.PhanTramChietKhau "
                               + "from KhachHangTraLai INNER JOIN ChiTietKhachHangTraLai on KhachHangTraLai.MaKhachHangTraLai = ChiTietKhachHangTraLai.MaKhachHangTraLai "
                               + "where KhachHangTraLai.NgayNhap between Convert(Datetime,'{0}',101) and Convert(Datetime,'{1}',101)  and KhachHangTraLai.Deleted = 0";
            string inputKhtl = string.Format(sqlKhtl, tungay, denngay);
            object outputKhtl;
            bool kqKhtl = Utils.GetDataFromServer("RunSql", inputKhtl, out outputKhtl);
            if (!kqKhtl) return;
            List<BcThongKeMatHangBanRaTheoNhanVienKhtl> bcThongKeMatHangBanRaTheoNhanVienKhtls = Utils.ConvertToList<BcThongKeMatHangBanRaTheoNhanVienKhtl>((DataTable)outputKhtl);
            #endregion

            //danh sách hóa đơn cần xét liệu có hàng trả lại hay không?
            List<string> dshoadon = bcThongKeMatHangBanRaTheoNhanViens.Select(k => k.MaHDBanHang).Distinct().ToList();
            //lọc các hàng hóa trả lại sao cho thuộc tập hóa đơn trên
            List<BcThongKeMatHangBanRaTheoNhanVienKhtl> bcThongKeMatHangBanRaTheoNhanVienKhtlsStand =
                bcThongKeMatHangBanRaTheoNhanVienKhtls.Where(k => dshoadon.Contains(k.MaHoaDonMuaHang)).ToList();
            //convert dữ liệu sang List<BcThongKeMatHangBanRaTheoNhanVien> với giá trị âm của số lượng và giá trị
            List<BcThongKeMatHangBanRaTheoNhanVien> bcThongKeMatHangBanRaTheoNhanViensStand =
                bcThongKeMatHangBanRaTheoNhanVienKhtlsStand.Select(k => new BcThongKeMatHangBanRaTheoNhanVien
                                {
                                    MaHDBanHang = k.MaHoaDonMuaHang,
                                    NgayBan = k.NgayNhap,
                                    MaKho = k.MaKho,
                                    MaNhanVien = string.Empty,
                                    TenNhanVien = string.Empty,

                                    MaHangHoa = k.MaHangHoa,
                                    TenHangHoa = k.TenHangHoa,
                                    SoLuong = -k.SoLuong,
                                    DonGia = k.DonGia
                                }).ToList();
            //gộp 2 list
            _bcThongKeMatHangBanRaTheoNhanViens.Clear();
            _bcThongKeMatHangBanRaTheoNhanViens.AddRange(bcThongKeMatHangBanRaTheoNhanViens);
            _bcThongKeMatHangBanRaTheoNhanViens.AddRange(bcThongKeMatHangBanRaTheoNhanViensStand);

            _bcThongKeMatHangBanRaTheoNhanViensGroup = (from k in _bcThongKeMatHangBanRaTheoNhanViens
                                                        group k by k.MaHangHoa into kk
                                                        select new BcThongKeMatHangBanRaTheoNhanVien
                                                                   {
                                                                       MaHangHoa = kk.Key,
                                                                       TenHangHoa = kk.FirstOrDefault().TenHangHoa,
                                                                       SoLuong = kk.Sum(kkk => kkk.SoLuong),
                                                                       DonGia = kk.Sum(kkk => kkk.SoLuong * kkk.DonGia * 0.01 * (100 + kkk.Thue))
                                                                   }).ToList();
            List<BcThongKeMatHangBanRaTheoNhanVien> hienthi = new List<BcThongKeMatHangBanRaTheoNhanVien>();
            if (_bcThongKeMatHangBanRaTheoNhanViensGroup.Count > 0)
            {
                //hiển thị tiền
                foreach (var item in _bcThongKeMatHangBanRaTheoNhanViensGroup)
                {
                    item.SoLuongView = item.SoLuong.ToString();
                    item.DonGiaView = new Common.Utilities().FormatMoney(item.DonGia);
                }
                hienthi.AddRange(_bcThongKeMatHangBanRaTheoNhanViensGroup);
                //thêm dòng tổng
                hienthi.Add(new BcThongKeMatHangBanRaTheoNhanVien
                {
                    TenHangHoa = "Tổng cộng:",
                    SoLuongView = _bcThongKeMatHangBanRaTheoNhanViensGroup.Sum(k => k.SoLuong).ToString(),
                    DonGiaView = new Common.Utilities().FormatMoney(_bcThongKeMatHangBanRaTheoNhanViensGroup.Sum(k => k.DonGia))
                });
            }
            uGrid.DataSource = hienthi;
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
            uGrid.Columns["SoLuongView"].Visible = true;
            uGrid.Columns["DonGiaView"].Visible = true;

            //uGrid.Columns["MaHDBanHang"].HeaderText = "Mã hóa đơn";
            //uGrid.Columns["NgayBan"].HeaderText = "Ngày bán";
            //uGrid.Columns["MaKho"].HeaderText = "Mã kho";
            //uGrid.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            uGrid.Columns["MaHangHoa"].HeaderText = "Mã hàng hóa";
            uGrid.Columns["TenHangHoa"].HeaderText = "Tên hàng hóa";
            uGrid.Columns["SoLuongView"].HeaderText = "Số lượng";
            uGrid.Columns["DonGiaView"].HeaderText = "Đơn giá";
            //uGrid.Columns["Thue"].HeaderText = "Thuế";
            //uGrid.Columns["PhanTramChietKhau"].HeaderText = "Phần trăm chiết khấu";
            uGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        #endregion Utils

        private void TxttimkiemTextChanged(object sender, EventArgs e)
        {
            string filter = txttimkiem.Text.ToLower();
            List<BcThongKeMatHangBanRaTheoNhanVien> qr = new List<BcThongKeMatHangBanRaTheoNhanVien>();
            //Tìm kiếm tương đối theo mã và tên
            if (rdoSearchMa.Checked)
            {//tìm kiếm theo mã
                qr = _bcThongKeMatHangBanRaTheoNhanViensGroup.Where(k => k.MaHangHoa.ToLower().Contains(filter)).ToList();
            }
            else if (rdoSearchTen.Checked)
            {//tìm kiếm theo tên
                qr = _bcThongKeMatHangBanRaTheoNhanViensGroup.Where(k => k.TenHangHoa.ToLower().Contains(filter)).ToList();
            }
            else if (rdoSearchTatCa.Checked)
            {//tìm kiếm tất cả
                qr = _bcThongKeMatHangBanRaTheoNhanViensGroup.Where(k => k.MaHangHoa.ToLower().Contains(filter) || k.TenHangHoa.ToLower().Contains(filter)).ToList();
            }

            if (qr.Count > 0)
            {
                //thêm dòng tổng
                qr.Add(new BcThongKeMatHangBanRaTheoNhanVien
                {
                    TenHangHoa = "Tổng cộng:",
                    SoLuongView = qr.Sum(k => k.SoLuong).ToString(),
                    DonGiaView = new Common.Utilities().FormatMoney(qr.Sum(k => k.DonGia))
                });
            }
            uGrid.DataSource = qr;
        }
    }
}
