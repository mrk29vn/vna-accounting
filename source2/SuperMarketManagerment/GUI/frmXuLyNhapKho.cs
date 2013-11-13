using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;
using Entities;

namespace GUI
{
    public partial class frmXuLyNhapKho : Form
    {
        #region Khai báo
        List<Entities.QuyDoiDonViTinh> dsQuyDoiDonViTinh = new List<Entities.QuyDoiDonViTinh>();
        private DateTime Date;
        private Entities.HoaDonNhap[] hoa;
        private Entities.HoaDonNhap hoadon;
        public Entities.HoaDonNhap Hoadon
        {
            get { return hoadon; }
            set { hoadon = value; }
        }
        private string hanhdong;
        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        DateTime giatritruyenthu4 = new DateTime(1753, 1, 1);
        private TcpClient client;
        private NetworkStream clientstrem;
        private Server_Client.Client cl;
        private static Entities.KiemTraChung[] tigia = null;
        #endregion

        #region Khởi tạo
        public frmXuLyNhapKho()
        {
            InitializeComponent();
            dsQuyDoiDonViTinh = this.bangquydoidonvitinh();
        }
        public frmXuLyNhapKho(string hanhdong, Entities.HoaDonNhap hoa)
        {
            InitializeComponent();
            this.hanhdong = hanhdong;
            this.hoadon = hoa;
            dsQuyDoiDonViTinh = this.bangquydoidonvitinh();
        }
        public frmXuLyNhapKho(string hanhdong)
        {
            InitializeComponent();
            this.hanhdong = hanhdong;
            dsQuyDoiDonViTinh = this.bangquydoidonvitinh();
        }
        private void frmXuLyNhapKho_Load(object sender, EventArgs e)
        {
            try
            {
                this.GetDate();
                frmXuLyNhapKho fr = new frmXuLyNhapKho();
                this.cbxHinhthucthanhtoan.Items.AddRange(new object[] { "Tiền mặt", "ATM" });
                if (hanhdong == "Insert")
                {
                    Common.Utilities ck = new Common.Utilities();
                    string ngay = this.Date.ToString("dd/MM/yyyy");
                    makNgaydonhang.Text = ngay;
                    makHanthanhtoan.Text = ngay;
                    cbxHinhthucthanhtoan.SelectedIndex = 0;
                    toolStrip_txtNgayhethan.Text = this.Date.ToString("dd/MM/yyyy");
                    toolStripStatus_Themmoi.Enabled = true;
                    Application.OpenForms[fr.Name].Text = "Thêm đơn nhập kho - F3 Thanh toán - F6 sửa hàng hóa - F9 Sửa giá hàng hóa";
                    Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                    dgvInsertOrder.DataSource = null;
                    dgvInsertOrder.DataSource = lay;
                    DoiTen(dgvInsertOrder);
                    toolStrip_txtTracuu.Focus();
                    format();
                    if (Double.Parse(txtThanhtoanngay.Text.Replace(",", "")) == Double.Parse(txtTongThanhToan.Text) && (txtThanhtoanngay.Text.Replace(",", "") != "0"))
                    {
                        lbtinhtrang.Visible = true;
                        lbtinhtrang.Text = "Đã thanh toán";
                        toolStripStatus_Thanhtoan.Enabled = false;
                    }
                    else
                    {
                        if (txtTongThanhToan.Text == "0" || txtTongThanhToan.Text == "00")
                        {
                            lbtinhtrang.Visible = true;
                            lbtinhtrang.Text = "Chưa thanh toán";
                            toolStripStatus_Thanhtoan.Enabled = true;
                        }
                        else
                        {
                            lbtinhtrang.Visible = true;
                            lbtinhtrang.Text = "Chưa thanh toán hết";
                            toolStripStatus_Thanhtoan.Enabled = true;
                        }
                    }
                    getID("HoaDonNhap");
                    txtSodonhang.Text = makiemtra;
                    toolStripStatus_Thanhtoan.Enabled = false;
                    toolStripStatus_In.Enabled = false;
                }
                new Common.Utilities().ComboxKhoHang(cbxKhoHang);
                LayTenTT();
                txtTygia.Text = tigia[0].Giatri2.ToString();
                cbxTienTe_TyGia.SelectedIndex = 0;
                cbxTienTe_TyGia.Enabled = false;
                if (hanhdong == "Update")
                {

                    palNhap.Enabled = false;
                    palXem.Enabled = false;
                    Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                    dgvInsertOrder.DataSource = null;
                    dgvInsertOrder.DataSource = lay;
                    txtMadondathang.ReadOnly = true;
                    btnTimMadatmuahang.Enabled = false;
                    txtManhacungcap.ReadOnly = true;
                    btnTimnhacungcap.Enabled = false;
                    toolStripStatus_Themmoi.Enabled = false;
                    Application.OpenForms[fr.Name].Text = "Quản lý hóa đơn nhập - Xem hóa đơn nhập <Enter - Thêm hàng hóa, F3 - Thanh toán  - F9 Sửa giá hàng hóa>";
                    DoDuLieu(this.hoadon);
                    toolStripStatus_In.Enabled = true;
                }
            }
            catch
            {
                Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgvInsertOrder.DataSource = null;
                dgvInsertOrder.DataSource = lay;
                DoiTen(dgvInsertOrder);
                if (txtSodonhang.Text == "")
                { txtSodonhang.Text = "HDN_0001"; }
            }
        }

        #endregion

        #region Event Form
        #region Form
        private void frmXuLyNhapKho_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {//Sửa giá hàng hóa
                string maHangHoa = toolStrip_txtTracuu.Text.Trim().ToUpper();
                if (string.IsNullOrEmpty(maHangHoa) || maHangHoa.Equals("<F4 - Tra cứu>"))
                {
                    MessageBox.Show("Vui lòng chọn hàng hóa cần sửa giá!\r\n tại ô nhập mã hàng hóa, vui lòng điền thông tin mã hàng hoặc ấn F4 để tìm kiếm hàng hóa");
                    toolStrip_txtTracuu.Focus(); return;
                }
                HangHoa temp = new HangHoa { MaHangHoa = maHangHoa };
                HangHoa tempReturn = LayHangHoaTheoMa(temp);
                frmXuLyHangHoa frm = new frmXuLyHangHoa("Update", tempReturn);
                frm.ShowDialog();
                LayHangHoaTheoMa(maHangHoa);
            }
        }
        #endregion
        #endregion

        #region Load Dữ liệu
        ///////////////////////////////////////////////////MRK FIX
        List<Entities.QuyDoiDonViTinh> bangquydoidonvitinh()
        {
            // quy đổi đơn vị tính
            Server_Client.Client cl = new Server_Client.Client();
            TcpClient client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("QD");
            clientstrem = cl.SerializeObj(client1, "Select", ctxh);
            Entities.QuyDoiDonViTinh[] quidoidvt = new Entities.QuyDoiDonViTinh[0];
            return ((Entities.QuyDoiDonViTinh[])cl.DeserializeHepper1(clientstrem, quidoidvt)).ToList();
        }
        //////////////////////////////////////////////////////////


        #endregion

        #region Date
        private void GetDate()
        {
            try
            {
                Entities.TruyenGiaTri kh = new Entities.TruyenGiaTri();
                kh.Hanhdong = "Select";
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "GetDateTime", kh);
                Entities.TruyenGiaTri DateTimes = new Entities.TruyenGiaTri();
                DateTimes = (Entities.TruyenGiaTri)cl.DeserializeHepper(clientstrem, DateTimes);
                DateTime tem = new DateTime(1753, 1, 1);
                this.giatritruyenthu4 = DateTimes.GiatritruyenTU;
                try { tem = DateTime.Parse(DateTimes.Giatritruyen).Date; }
                catch { tem = this.giatritruyenthu4; }
                Date = tem;
            }
            catch { }
        }
        #endregion

        #region Binding combox
        private void LayTenTT()
        {
            try
            {
                cbxTienTe_TyGia.Items.Clear();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KiemTraChung tt1 = new Entities.KiemTraChung();
                tt1 = new Entities.KiemTraChung("Select");
                clientstrem = cl.SerializeObj(this.client, "LayThongTinTienTe", tt1);
                Entities.KiemTraChung[] tt = new Entities.KiemTraChung[1];
                tt = (Entities.KiemTraChung[])cl.DeserializeHepper1(clientstrem, tt);
                client.Close();
                clientstrem.Close();
                if (tt.Length > 0)
                {
                    tigia = tt;
                    Common.Utilities com = new Common.Utilities();
                    com.BindingCombobox(tt, cbxTienTe_TyGia, "giatri", "khoachinh");
                }
                else
                { cbxTienTe_TyGia.Items.Clear(); }
            }
            catch (Exception ex)
            {
                cbxTienTe_TyGia.Items.Clear();
                string s = ex.Message.ToString();
            }
        }
        #endregion

        #region Xu Ly
        public Entities.ChiTietHoaDonNhap[] LuuChiTietHoaDonNhap(DataGridView dgv, string hanhdong, string madondathang)
        {
            ArrayList arr = new ArrayList();
            int i = dgv.RowCount;
            Entities.ChiTietHoaDonNhap[] mangBanghi = null;
            try
            {
                if (i > 0)
                {
                    for (int x = 0; x < i; x++)
                    {
                        Entities.ChiTietHoaDonNhap banghi = new Entities.ChiTietHoaDonNhap();
                        banghi.Hanhdong = hanhdong;
                        banghi.MaHoaDonNhap = madondathang;
                        banghi.MaHangHoa = dgv.Rows[x].Cells[1].Value.ToString().ToUpper();
                        banghi.SoLuong = System.Convert.ToInt32(dgv.Rows[x].Cells[3].Value.ToString());
                        banghi.PhanTramChietKhau = dgv.Rows[x].Cells[7].Value.ToString();
                        banghi.DonGia = dgv.Rows[x].Cells["GiaGoc"].Value.ToString();
                        banghi.Thue = dgv.Rows[x].Cells["Thuegiatrigiatang"].Value.ToString();
                        banghi.GhiChu = txtDiengiai.Text.ToString();
                        banghi.Deleted = false;
                        banghi.MaKho = new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen;
                        arr.Add(banghi);
                    }
                    int n = arr.Count;
                    if (n == 0) { return null; }
                    mangBanghi = new Entities.ChiTietHoaDonNhap[n];
                    for (int j = 0; j < n; j++)
                    {
                        mangBanghi[j] = (Entities.ChiTietHoaDonNhap)arr[j];
                    }
                }
                else
                {
                    mangBanghi = null;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; mangBanghi = null; }
            return mangBanghi;
        }
        private void DeleteData(string ID)
        {
            try
            {
                Entities.HoaDonNhap dh = new Entities.HoaDonNhap();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                dh = new Entities.HoaDonNhap("Delete", ID);
                clientstrem = cl.SerializeObj(this.client, "HoaDonNhap", dh);
                int trave = 0;
                trave = System.Convert.ToInt32(cl.DeserializeHepper(clientstrem, trave));
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void LuuChiTietDonHang()
        {
            try
            {
                if (XoaTheoHoaDon("HoaDonNhap", txtSodonhang.Text.ToUpper()) != 0)
                {
                    cl = new Server_Client.Client();
                    this.client = cl.Connect(Luu.IP, Luu.Ports);
                    Entities.ChiTietHoaDonNhap[] luu = LuuChiTietHoaDonNhap(dgvInsertOrder, "Insert", txtSodonhang.Text);
                    clientstrem = cl.SerializeHepper(this.client, "ChiTietHoaDonNhap", luu);
                    int bao = 0;
                    bao = (int)cl.DeserializeHepper(clientstrem, bao);
                    if (bao != 0)
                    {
                        int k = dgvInsertOrder.RowCount;
                        Entities.ChiTietKhoHangTheoHoaHonNhap[] khohang = new Entities.ChiTietKhoHangTheoHoaHonNhap[k];
                        ArrayList arr = new ArrayList();
                        if (k > 0)
                        {
                            for (int x = 0; x < k; x++)
                            {
                                Entities.ChiTietKhoHangTheoHoaHonNhap kho = new Entities.ChiTietKhoHangTheoHoaHonNhap();
                                kho.Hanhdong = "Insert";
                                kho.Makho = cbxKhoHang.SelectedValue.ToString();
                                kho.Mahanghoa = dgvInsertOrder.Rows[x].Cells[1].Value.ToString();
                                kho.Soluong = int.Parse(dgvInsertOrder.Rows[x].Cells[3].Value.ToString());
                                kho.Ngaynhap = Date.Date;
                                //string ngay = new Common.Utilities().KiemTraDinhDangNgayThangNam("ThangNgayNam", dgvInsertOrder.Rows[x].Cells[12].Value.ToString(), '/');
                                //kho.Ngayhethan = DateTime.Parse(ngay);
                                kho.Ngayhethan = Utils.StringToDateTime(dgvInsertOrder.Rows[x].Cells[12].Value.ToString());
                                kho.Ghichu = txtDiengiai.Text;
                                kho.Deleted = false;
                                kho.Gia = float.Parse(dgvInsertOrder.Rows[x].Cells[4].Value.ToString());
                                arr.Add(kho);
                            }
                            int n = arr.Count;
                            if (n == 0)
                            { khohang = null; }
                            khohang = new Entities.ChiTietKhoHangTheoHoaHonNhap[n];
                            for (int j = 0; j < n; j++)
                            { khohang[j] = (Entities.ChiTietKhoHangTheoHoaHonNhap)arr[j]; }
                        }
                        else
                        { khohang = null; }
                        LuuChiTietVaoKhoHang(khohang);
                    }
                    else
                    { DeleteData(txtSodonhang.Text); MessageBox.Show("Thất bại"); }
                }
                else
                { MessageBox.Show("Chưa thêm hàng hóa vào đơn nhập hàng này"); }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void update(string ma, string duno)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TruyenGiaTri kh = new Entities.TruyenGiaTri("Update", ma, duno);
                clientstrem = cl.SerializeObj(this.client, "UpdateDuNo", kh);
                int kq = 0;
                kq = (int)cl.DeserializeHepper(clientstrem, kq);
                client.Close();
                clientstrem.Close();
                if (kq > 0)
                { }
                else
                { string f = "Chưa cập nhật"; }
            }
            catch { }
        }
        private void LuuChiTietVaoKhoHang(Entities.ChiTietKhoHangTheoHoaHonNhap[] kho)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeHepper(this.client, "ThemChiTietKhoHang", kho);
                int bao = 0;
                bao = (int)cl.DeserializeHepper(clientstrem, bao);
                if (bao == 1 || bao == -1)
                {
                    if (bao == -1)
                    {
                        lblSodonhang.Text = "Mã Đơn Nhập:";
                    }
                    if (Double.Parse(txtTongThanhToan.Text.Replace(",", "")) > Double.Parse(txtThanhtoanngay.Text.Replace(",", "")))
                    {
                        update(txtManhacungcap.Text, capnhat());
                    }
                    else if (Double.Parse(txtThanhtoanngay.Text.Replace(",", "")) == Double.Parse(txtTongThanhToan.Text))
                    {
                        lbtinhtrang.Visible = true;
                        lbtinhtrang.Text = "Đã thanh toán";
                        toolStripStatus_Thanhtoan.Enabled = false;
                    }
                    else
                    {
                        lbtinhtrang.Visible = true;
                        lbtinhtrang.Text = "Chưa thanh toán hết";
                        toolStripStatus_Thanhtoan.Enabled = true;
                    }
                }
                else
                {
                    lblSodonhang.Text = "Mã đơn nhập::";
                }
            }
            catch { }
        }
        private void CapNhatTrangThaiDonDatHang(string hanhdong, string MaDonDatHang, string trangthai)
        {
            try
            {
                if (MaDonDatHang.Length > 0)
                {
                    Entities.DonDatHang dat = new Entities.DonDatHang();
                    dat.Hanhdong = hanhdong;
                    dat.MaDonDatHang = MaDonDatHang;
                    dat.TrangThaiDonDatHang = trangthai;
                    cl = new Server_Client.Client();
                    this.client = cl.Connect(Luu.IP, Luu.Ports);
                    clientstrem = cl.SerializeObj(this.client, "CapNhatTrangThaiDonDatHang", dat);
                    string tralai = "";
                    tralai = (string)cl.DeserializeHepper(clientstrem, tralai);
                    if (tralai == "OK") { }
                    else
                    { MessageBox.Show("Chưa cập nhật đơn đặt hàng"); }
                }
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private string capnhat()
        {
            string d = "0";
            try
            {
                if (Double.Parse(txtTongThanhToan.Text.Replace(",", "")) > Double.Parse(txtThanhtoanngay.Text.Replace(",", "")))
                {
                    d = (Double.Parse(txtTongThanhToan.Text) - Double.Parse(txtThanhtoanngay.Text.Replace(",", ""))).ToString();
                }
                else
                { d = "0"; }
            }
            catch { }
            return d;
        }
        /// <summary>
        /// them moi, sua thong tin don dat hang
        /// </summary>
        /// <param name="hanhdong"></param>
        private Boolean KiemTraNgayHetHan()
        {
            Boolean k = false;
            try
            {
                if (dgvInsertOrder.RowCount > 0)
                {
                    for (int y = 0; y < dgvInsertOrder.RowCount; y++)
                    {
                        string thoigian = dgvInsertOrder.Rows[y].Cells[12].Value.ToString();
                        if (thoigian != null && thoigian != "")
                        {
                            string thoigian_sosanh = DateServer.Date().ToString("dd/MM/yyyy");
                            if (new Common.Utilities().SoSanhNgay('/', "<", thoigian, thoigian_sosanh) == true)
                            {
                                k = false;
                            }
                            else
                            {
                                k = true;
                                continue;
                            }
                        }
                        else
                        {
                            k = false;
                            MessageBox.Show("Nhập hạn sử dụng cho hàng hóa " + dgvInsertOrder.Rows[y].Cells[2].Value.ToString());
                            break;
                        }
                    }
                }
                else
                { MessageBox.Show("Không có hàng trong đơn này"); toolStrip_txtTracuu.Focus(); }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                MessageBox.Show("Kiểm tra hạn sử dụng của các hàng hóa");
                k = false;
            }
            return k;
        }
        /// <summary>
        /// 
        /// </summary>
        private int ID = 0;
        private Entities.HoaDonNhap[] thanhtoan;
        private void XuLy_HoaDonNhap(string hanhdong)
        {
            try
            {
                if (!KiemTraNgayHetHan()) return;

                thanhtoan = new Entities.HoaDonNhap[1];
                Entities.HoaDonNhap don = new Entities.HoaDonNhap();
                Common.Utilities ck = new Common.Utilities();
                string thoigian_1 = makNgaydonhang.Text;
                string thoigian_2 = makHanthanhtoan.Text;
                string thoigian_sosanh = Date.ToString("dd/MM/yyyy");
                if (string.IsNullOrEmpty(thoigian_1) || string.IsNullOrEmpty(thoigian_2))
                {
                    MessageBox.Show("Kiểm tra ngày"); return;
                }
                if (!(ck.SoSanhNgay('/', ">=", thoigian_1, thoigian_sosanh) && ck.SoSanhNgay('/', ">=", thoigian_2, thoigian_sosanh)))
                {
                    MessageBox.Show("Kiểm tra ngày"); return;
                }
                else
                {
                    bool _kq0 = true; bool _kq1 = true;
                    don.NgayNhap = Utils.StringToDateTime(thoigian_1, out _kq0);
                    don.HanThanhToan = Utils.StringToDateTime(thoigian_2, out _kq1);
                    //don.NgayNhap = DateTime.Parse(new Common.Utilities().KiemTraDinhDangNgayThangNam("ThangNgayNam", thoigian_1, '/'));
                    //don.HanThanhToan = DateTime.Parse(new Common.Utilities().KiemTraDinhDangNgayThangNam("ThangNgayNam", thoigian_2, '/'));
                    don.Hanhdong = hanhdong;
                    don.HoaDonNhapID = ID;
                    don.MaHoaDonNhap = txtSodonhang.Text;
                    don.MaNhaCungCap = txtManhacungcap.Text;
                    don.NoHienThoi = txtNohienthoi.Text;
                    don.NguoiGiaoHang = "" + txtnguoigiaohang.Text;
                    don.HinhThucThanhToan = cbxHinhthucthanhtoan.SelectedItem.ToString();
                    string kh = "";
                    try { kh = cbxKhoHang.SelectedValue.ToString(); }
                    catch (Exception ex) { MessageBox.Show("Kiểm tra mã kho"); kh = ""; return; }
                    don.MaKho = kh;
                    string MaDonDatHang = txtMadondathang.Text;
                    if (MaDonDatHang == "<F4 - Tra cứu>" || MaDonDatHang.Length <= 0)
                    {
                        MaDonDatHang = "NULL";
                    }
                    don.MaDonDatHang = MaDonDatHang;
                    string tt = "";
                    try { tt = cbxTienTe_TyGia.SelectedValue.ToString(); }
                    catch (Exception ex) { MessageBox.Show("Kiểm tra mã tiền tệ"); tt = ""; return; }
                    don.MaTienTe = tt;
                    don.ChietKhau = Double.Parse(0 + txtTienCKTM0.Text).ToString();
                    don.ThanhToanNgay = Double.Parse(0 + txtThanhtoanngay.Text.Replace(",", "")).ToString();
                    don.ThueGTGT = Double.Parse(0 + txtGiatrigiatang.Text).ToString();
                    don.TongTien = Double.Parse(0 + txtTongThanhToan.Text).ToString();
                    don.GhiChu = "" + txtDiengiai.Text;
                    don.Deleted = false;
                    don.Manhanvien = Common.Utilities.User.NhanVienID;
                    don.Tendangnhap = Common.Utilities.User.TenDangNhap;
                    don.ThanhToanSauKhiLapPhieu = "0";
                    if (dgvInsertOrder.RowCount > 0)
                    {
                        if (CheckData(don) == true)
                        {
                            cl = new Server_Client.Client();
                            this.client = cl.Connect(Luu.IP, Luu.Ports);
                            clientstrem = cl.SerializeObj(this.client, "HoaDonNhap", don);
                            Entities.HoaDonNhap[] tralai = new Entities.HoaDonNhap[1];
                            int trave = System.Convert.ToInt32(cl.DeserializeHepper(clientstrem, tralai));
                            if (trave == 1)
                            {
                                thanhtoan[0] = don;
                                try
                                {
                                    LuuChiTietDonHang();
                                }
                                catch { }
                                CapNhatTrangThaiDonDatHang("Update", MaDonDatHang, "Đã thành công");
                                frmQuanLyNhapKho.BaoDong = "";
                                DialogResult giatri = MessageBox.Show("Bạn có muốn thêm phiếu nhập tiếp không?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                                {
                                    if (giatri == DialogResult.No)
                                        frmQuanLyNhapKho.BaoDong = "A";
                                } this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Thất bại");
                            }
                        }
                    }
                    else
                    { MessageBox.Show("Không có hàng hóa trong đơn đặt hàng"); }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                MessageBox.Show("Thông tin nhập không đúng");
            }
        }
        /// <summary>
        /// kiem tra ngay trong dgv
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        private int kiemtrangaytrong_dgv(DataGridView dgv)
        {
            int count = 0;
            try
            {
                if (dgv.RowCount > 0)
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        string data = dgv.Rows[i].Cells[12].Value.ToString();
                        if (data != null)
                        {
                            count = 1;
                        }
                        else
                        { break; }
                    }
                }
                else
                { MessageBox.Show("Không có hàng hóa nào"); count = 0; }
            }
            catch (Exception ex)
            { string s = ex.Message; count = 0; }
            return count;
        }
        private void XuLy_Xoa_HoaDonNhap(string hanhdong, string mahoadonnhap)
        {
            try
            {
                Entities.HoaDonNhap them = new Entities.HoaDonNhap();
                them = new Entities.HoaDonNhap(hanhdong, mahoadonnhap);
                clientstrem = cl.SerializeObj(this.client, "HoaDonNhap", them);
                //hứng giá trị trả về
                int trave;
                Entities.HoaDonNhap[] tralai = new Entities.HoaDonNhap[1];
                trave = (int)cl.DeserializeHepper(clientstrem, tralai);
                //thong bao
                if (trave == 1) { MessageBox.Show("Thành công !"); }
                else { MessageBox.Show("Thất bại !"); }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// tu tang ID
        /// </summary>
        private void getID(string table)
        {
            try
            {
                Entities.LayID top = new Entities.LayID();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                top = new Entities.LayID("Select", table);
                clientstrem = cl.SerializeObj(this.client, "LayID", top);
                Entities.LayID ddh = new Entities.LayID();
                ddh = (Entities.LayID)cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh != null)
                {
                    string chuoi = ddh.ID.ToString();
                    Common.Utilities com = new Common.Utilities();
                    makiemtra = com.ProcessID(chuoi);
                }
                else
                { makiemtra = "HDN_0001"; }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                makiemtra = "HDN_0001";
            }
        }
        #endregion

        #region Checkconflic
        private Entities.HoaDonNhap ConfilickData(string table, string values)
        {
            Entities.HoaDonNhap ddh = new Entities.HoaDonNhap();
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TruyenGiaTri gitri = new Entities.TruyenGiaTri("Select", table, values);
                clientstrem = cl.SerializeObj(this.client, "CheckHoaDonNhap", gitri);
                ddh = (Entities.HoaDonNhap)cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                ddh = null;
            }
            return ddh;
        }

        private Boolean CheckConfilct(Entities.HoaDonNhap giaitri, Entities.HoaDonNhap sosanh)
        {
            Boolean kiemtra = false;
            try
            {
                int count = 0;
                if (giaitri.HoaDonNhapID != sosanh.HoaDonNhapID)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.MaHoaDonNhap != sosanh.MaHoaDonNhap)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.NgayNhap != sosanh.NgayNhap)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.MaNhaCungCap != sosanh.MaNhaCungCap)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.NoHienThoi != sosanh.NoHienThoi)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.NguoiGiaoHang != sosanh.NguoiGiaoHang)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.HinhThucThanhToan != sosanh.HinhThucThanhToan)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.MaKho != sosanh.MaKho)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.HanThanhToan != sosanh.HanThanhToan)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.MaDonDatHang != sosanh.MaDonDatHang)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.MaTienTe != sosanh.MaTienTe)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.ChietKhau != sosanh.ChietKhau)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.ThanhToanNgay != sosanh.ThanhToanNgay)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.ThueGTGT != sosanh.ThueGTGT)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.TongTien != sosanh.TongTien)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.GhiChu != sosanh.GhiChu)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (giaitri.Deleted != sosanh.Deleted)
                { kiemtra = false; ID = sosanh.HoaDonNhapID; }
                else { kiemtra = true; count = count + 1; }
                if (count < 17)
                { kiemtra = false; }
                else { kiemtra = true; }
            }
            catch (Exception ex)
            { string s = ex.Message; kiemtra = false; }
            return kiemtra;
        }
        #endregion

        #region Validate
        /// <summary>
        /// hungvv kiem tra dinh dang khi them moi hoa don
        /// </summary>
        /// <param name="maDonDatHang"></param>
        private Boolean CheckData(Entities.HoaDonNhap dat)
        {
            Boolean kt = false;
            try
            {
                if (dat.MaNhaCungCap.Length <= 0)
                {
                    txtManhacungcap.Focus();
                    MessageBox.Show("Phải nhập mã nhà cung cấp");
                    kt = false;
                }
                else
                {
                    if (dat.MaKho.Length <= 0)
                    {
                        cbxKhoHang.Focus();
                        MessageBox.Show("Chưa có mã kho mã kho");
                        kt = false;
                    }
                    else
                    {
                        if (dat.MaTienTe.Length <= 0)
                        {
                            cbxTienTe_TyGia.Focus();
                            MessageBox.Show("Loại tiền tệ không đúng");
                            kt = false;
                        }
                        else
                        {
                            if (dat.MaHoaDonNhap.Length <= 0)
                            {
                                txtMadondathang.Text = "";
                                txtMadondathang.Focus();
                                System.Windows.Forms.MessageBox.Show("Hãy nhập mã hóa đơn nhập");
                                kt = false;
                            }
                            else
                            {
                                kt = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; kt = false; }
            return kt;
        }
        #endregion

        #region Fix
        /// <summary>
        /// do du lieu vao dgv
        /// </summary>
        private void DoiTen(DataGridView dgv)
        {
            try
            {
                dgv.RowHeadersVisible = false;
                dgv.Columns["HanhDong"].Visible = false;
                dgv.Columns["ChietKhau"].Visible = false;
                dgv.Columns["MaHangHoa"].HeaderText = "Mã hàng";
                dgv.Columns["MaHangHoa"].ToolTipText = "Mã hàng hóa";
                dgv.Columns["TenHangHoa"].HeaderText = "Tên hàng";
                dgv.Columns["TenHangHoa"].ToolTipText = "Tên hàng hóa";
                dgv.Columns["SoLuongDat"].HeaderText = "Số Lượng";
                dgv.Columns["SoLuongDat"].ToolTipText = "Số Lượng";
                dgv.Columns["GiaGoc"].HeaderText = "Giá gốc";
                dgv.Columns["GiaGoc"].ToolTipText = "Giá gốc của nhà cung cấp";
                dgv.Columns["Giabanbuon"].Visible = false;  //MRK FIX
                dgv.Columns["Giabanbuon"].HeaderText = "Giá bán buôn";
                dgv.Columns["Giabanbuon"].ToolTipText = "Giá bán buôn";
                dgv.Columns["Giabanle"].Visible = false;    //MRK FIX
                dgv.Columns["Giabanle"].ToolTipText = "Giá bán lẻ";
                dgv.Columns["Giabanle"].HeaderText = "Giá bán lẻ";
                dgv.Columns["PhanTramChietKhau"].HeaderText = "Chiết khấu(%) của NCC";
                dgv.Columns["PhanTramChietKhau"].ToolTipText = "chiết khấu của nhà cung cấp khi mua hàng";
                dgv.Columns["Thuegiatrigiatang"].HeaderText = "Thuế(GTGT)";
                dgv.Columns["Thuegiatrigiatang"].ToolTipText = "thuế giá trị gia tăng(%)";
                dgv.Columns["GiaNhap"].HeaderText = "Thành Tiền(đã C/K)";
                dgv.Columns["GiaNhap"].ToolTipText = "Tổng tiền đã chiết khấu của mặt hàng này(chưa có thuế GTGT)";
                dgv.Columns["TongTien"].HeaderText = "Thành Tiền(chưa C/K)";
                dgv.Columns["TongTien"].ToolTipText = "Tổng tiền chưa chiết khấu của mặt hàng này(chưa có thuế GTGT)";
                dgv.Columns["Ngayhethan"].HeaderText = "Hạn sử dụng";
                dgv.Columns["Ngayhethan"].HeaderText = "Hạn sử dụng";
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        #endregion

        #region Hien Thi Chi Tiet Hoa Don
        private void HienThi_ChiTiet_HoaDonNhap(string Mahoadonnhap)
        {
            try
            {
                Entities.HienThi_ChiTiet_DonDatHang dat = new Entities.HienThi_ChiTiet_DonDatHang();
                dat.HanhDong = "Select";
                dat.MaHangHoa = Mahoadonnhap;
                dat.TenHangHoa = maKhoHang;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "HienThi_ChiTiet_HoaDonNhap", dat);
                Entities.HienThi_ChiTiet_DonDatHang[] ddh = new Entities.HienThi_ChiTiet_DonDatHang[1];
                ddh = (Entities.HienThi_ChiTiet_DonDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length > 0 && ddh != null)
                {
                    XuLyChiTietDonDatHang(ddh);
                }
                else
                {
                    Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                    dgvInsertOrder.DataSource = null;
                    dgvInsertOrder.DataSource = lay;
                    DoiTen(dgvInsertOrder);

                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgvInsertOrder.DataSource = null;
                dgvInsertOrder.DataSource = lay;
                DoiTen(dgvInsertOrder);
            }
        }
        #endregion

        #region Xu Ly Don Dat Hang
        /// <summary>
        /// xu ly du lieu
        /// </summary>
        /// <param name="chitiet"></param>
        private string ngaythangnam = "";
        private void XuLyChiTietDonDatHang(Entities.HienThi_ChiTiet_DonDatHang[] chitiet)
        {
            try
            {
                if (chitiet.Length > 0)
                {
                    Entities.HienThi_ChiTiet_DonDatHang[] giatri = null;
                    ArrayList arr = new ArrayList();
                    Entities.HienThi_ChiTiet_DonDatHang[] g = new Entities.HienThi_ChiTiet_DonDatHang[chitiet.Length];
                    for (int i = 0; i < chitiet.Length; i++)
                    {
                        Entities.HienThi_ChiTiet_DonDatHang row = new Entities.HienThi_ChiTiet_DonDatHang();
                        row.MaHangHoa = chitiet[i].MaHangHoa;
                        row.TenHangHoa = chitiet[i].TenHangHoa;
                        row.SoLuongDat = chitiet[i].SoLuongDat;
                        row.GiaGoc = chitiet[i].GiaGoc;
                        row.Giabanbuon = chitiet[i].Giabanbuon;
                        row.Giabanle = chitiet[i].Giabanle;
                        string phantram = chitiet[i].PhanTramChietKhau;
                        string gianhap = "0";
                        if (phantram == "0")
                        {
                            gianhap = (Double.Parse(chitiet[i].GiaGoc) * Double.Parse(chitiet[i].SoLuongDat.ToString())).ToString();
                        }
                        else
                        {
                            gianhap = ((Double.Parse(chitiet[i].GiaGoc) * Double.Parse(chitiet[i].SoLuongDat.ToString())) - ((Double.Parse(chitiet[i].PhanTramChietKhau) / 100 * Double.Parse(chitiet[i].GiaGoc) * Double.Parse(chitiet[i].SoLuongDat.ToString())))).ToString();
                        }
                        row.PhanTramChietKhau = phantram;
                        row.Thuegiatrigiatang = chitiet[i].Thuegiatrigiatang;
                        row.GiaNhap = gianhap;
                        row.TongTien = (Double.Parse(chitiet[i].GiaGoc) * Double.Parse(chitiet[i].SoLuongDat.ToString())).ToString();
                        //ngaythangnam = new Common.Utilities().KiemTraDinhDangNgayThangNam("NgayThangNam", chitiet[i].Ngayhethan, '/');
                        ngaythangnam = chitiet[i].Ngayhethan;
                        row.Ngayhethan = ngaythangnam;
                        arr.Add(row);
                    }
                    int n = arr.Count;
                    if (n == 0) { giatri = null; }
                    giatri = new Entities.HienThi_ChiTiet_DonDatHang[n];
                    for (int i = 0; i < n; i++)
                    {
                        giatri[i] = (Entities.HienThi_ChiTiet_DonDatHang)arr[i];
                    }
                    if (giatri != null)
                    {
                        dgvInsertOrder.DataSource = null;
                        dgvInsertOrder.DataSource = giatri;
                        DoiTen(dgvInsertOrder);
                    }
                    else
                    {
                        Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                        dgvInsertOrder.DataSource = null;
                        dgvInsertOrder.DataSource = lay;
                        DoiTen(dgvInsertOrder);
                    }
                }
                else
                {
                    dgvInsertOrder.DataSource = chitiet;
                    DoiTen(dgvInsertOrder);
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgvInsertOrder.DataSource = null;
                dgvInsertOrder.DataSource = lay;
                DoiTen(dgvInsertOrder);
            }
        }
        /// <summary>
        /// do du lieu vao dgv
        /// </summary>
        private void HienThi_ChiTiet_DonDatHang()
        {
            try
            {
                Entities.TruyenGiaTri dat = new Entities.TruyenGiaTri();
                dat.Hanhdong = "Select";
                dat.Giatritruyen = txtMadondathang.Text;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "HienThi_ChiTiet_DonDatHang", dat);
                Entities.HienThi_ChiTiet_DonDatHang[] ddh = new Entities.HienThi_ChiTiet_DonDatHang[1];
                ddh = (Entities.HienThi_ChiTiet_DonDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length > 0)
                {
                    XuLyChiTietDonDatHang(ddh);
                }
                else
                {
                    Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                    dgvInsertOrder.DataSource = lay;
                    DoiTen(dgvInsertOrder);
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgvInsertOrder.DataSource = lay;
                DoiTen(dgvInsertOrder);
            }

        }
        #endregion

        #region Binding
        private string banbuon;
        private string banle;
        private string giatrigiatang;
        private void BindHangHoa()
        {
            try
            {
                if (GiaTriCanLuu.Loaitrave == "HoaDonNhap_NhaCungCap")
                {
                    if (GiaTriCanLuu.Ma != null)
                    {
                        txtManhacungcap.Text = GiaTriCanLuu.Ma;
                        lblTenNhaCungCap.Text = fixTen(GiaTriCanLuu.Ten);
                        txtNohienthoi.Text = GiaTriCanLuu.TonKho;
                    }
                    else
                    {
                        txtManhacungcap.Text = "<F4 -Tra cứu>";
                    }
                }
                if (GiaTriCanLuu.Loaitrave == "HoaDonNhap_MaDonDatHang")
                {
                    if (GiaTriCanLuu.Ma != null)
                    {
                        txtMadondathang.Text = GiaTriCanLuu.Ma;
                        lblMaHoaDonNhap.Text = new Common.Utilities().XuLy(2, GiaTriCanLuu.Ten);
                        HienThi_ChiTiet_DonDatHang();
                    }
                    else
                    {
                        txtMadondathang.Text = "<F4 -Tra cứu>";
                    }
                }
                if (GiaTriCanLuu.Loaitrave == "HoaDonDat_HangHoa")    //HoaDonDat_HangHoa    Lay_HangHoa_GoiHang
                {
                    toolStrip_txtTracuu.Text = GiaTriCanLuu.Ma;
                    toolStrip_txtTenhang.Text = GiaTriCanLuu.Ten;
                    toolStrip_txtGiagoc.Text = GiaTriCanLuu.Giatri;
                    toolStrip_txtSoluong.Text = "1";
                    toolStrip_txtChietkhauphantram.Text = "0";
                    toolStrip_txtGianhap.Text = GiaTriCanLuu.Giatri;
                    toolStrip_txtThuegiatrigiatang.Text = GiaTriCanLuu.giatrigiatang;
                    toolStrip_txtNgayhethan.Text = this.Date.ToString("dd/MM/yyyy");
                    banbuon = GiaTriCanLuu.Giatri2;
                    banle = GiaTriCanLuu.TonKho;
                    giatrigiatang = GiaTriCanLuu.giatrigiatang;
                    toolStrip_txtSoluong.Text = "";
                    toolStrip_txtSoluong.Focus();

                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        #region Lay Du Lieu
        /// <summary>
        /// hungvv =================do du lieu vao txt===========================
        /// </summary>
        /// <param name="dat"></param>
        private string maKhoHang;
        private void DoDuLieu(Entities.HoaDonNhap dat)
        {
            try
            {
                Common.Utilities com = new Common.Utilities();
                ID = dat.HoaDonNhapID;
                txtSodonhang.Text = dat.MaHoaDonNhap;
                txtManhacungcap.Text = dat.MaNhaCungCap;
                ////////////////////////////////////////MRK FIX
                if (lblTenNhaCungCap.Text.Equals(""))
                {
                    try
                    {
                        cl = new Server_Client.Client();
                        this.client = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.TruyenGiaTri cc = new Entities.TruyenGiaTri("Select", "");
                        clientstrem = cl.SerializeObj(this.client, "ThongTinNhaCungCap", cc);
                        Entities.ThongTinNhaCungCap[] ddh = new Entities.ThongTinNhaCungCap[1];
                        ddh = (Entities.ThongTinNhaCungCap[])cl.DeserializeHepper(clientstrem, ddh);
                        client.Close();
                        clientstrem.Close();
                        if (ddh.Length > 0)
                        {
                            foreach (Entities.ThongTinNhaCungCap item in ddh)
                            {
                                if (item.Manhacungcap.Equals(txtManhacungcap.Text))
                                {
                                    lblTenNhaCungCap.Text = item.Tennhacungcap;
                                }
                            }
                        }
                        else { }
                    }
                    catch { }
                }
                /////////////////////////////////////////////////////////
                GiaTriCanLuu.Ma = dat.MaNhaCungCap;
                makNgaydonhang.Text = new Common.Utilities().XuLy(2, dat.NgayNhap.ToString());
                makHanthanhtoan.Text = new Common.Utilities().XuLy(2, dat.HanThanhToan.ToString());
                txtNohienthoi.Text = dat.NoHienThoi;
                txtnguoigiaohang.Text = dat.NguoiGiaoHang;
                cbxHinhthucthanhtoan.SelectedItem = dat.HinhThucThanhToan;
                cbxKhoHang.SelectedValue = dat.MaKho;
                maKhoHang = dat.MaKho;
                txtMadondathang.Text = dat.MaDonDatHang;
                cbxTienTe_TyGia.SelectedValue = dat.MaTienTe;
                txtDiengiai.Text = dat.GhiChu;
                if (dat.MaDonDatHang != "" || dat.MaDonDatHang == "<F4 - TRA CỨU>")
                {
                    chekChonLoai.Checked = true;
                }
                else
                {
                    chekChonLoai.Checked = false;
                }
                txtMadondathang.ReadOnly = true;
                btnTimMadatmuahang.Enabled = false;
                chekChonLoai.Enabled = false;
                if (txtSodonhang.Text != "" || txtSodonhang.Text != "<F4 -Tra cứu>")
                {
                    HienThi_ChiTiet_HoaDonNhap(txtSodonhang.Text);
                }
                else
                {
                    Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                    dgvInsertOrder.DataSource = null;
                    dgvInsertOrder.DataSource = lay;
                    DoiTen(dgvInsertOrder);
                }
                double ckTongHoaDon = 0;
                if (!string.IsNullOrEmpty(dat.ChietKhau))
                    ckTongHoaDon = double.Parse(dat.ChietKhau);
                txtTienCKTM0.Text = new Common.Utilities().FormatMoney(ckTongHoaDon);
                TinhToan();
                txtCKTM0.Text = new Common.Utilities().FormatMoney(100 - (1 - double.Parse(dat.ChietKhau) / double.Parse(txtTongThanhToan.Text.Replace(",", ""))) * 100);
                txtTongThanhToan.Text = new Common.Utilities().FormatMoney(double.Parse(txtTongThanhToan.Text.Replace(",", "")) - double.Parse(txtTienCKTM0.Text.Replace(",", "")));
                txtThanhtoanngay.Text = new TienIch().FormatMoney(dat.ThanhToanNgay);
                txtTienTraLai.Text = new Common.Utilities().FormatMoney(Double.Parse(dat.ThanhToanNgay) - Double.Parse(dat.TongTien));
                double thanhtoankhilapphieu = Double.Parse(dat.ThanhToanSauKhiLapPhieu);
                if ((Double.Parse(txtThanhtoanngay.Text.Replace(",", "")) + thanhtoankhilapphieu) == Double.Parse(txtTongThanhToan.Text))
                {
                    lbtinhtrang.Text = "Đã Thanh Toán";
                    toolStripStatus_Thanhtoan.Enabled = false;
                }
                else
                {
                    lbtinhtrang.Text = "Chưa Thanh Toán";
                    toolStripStatus_Thanhtoan.Enabled = true;
                }
                string date = new Common.Utilities().MyDateConversion(makNgaydonhang.Text);
                string date2 = new Common.Utilities().MyDateConversion(makHanthanhtoan.Text);
                string makho = cbxKhoHang.SelectedValue.ToString();
                string matt = cbxTienTe_TyGia.SelectedValue.ToString();
                hoa = new Entities.HoaDonNhap[1];
                hoa[0] = dat;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgvInsertOrder.DataSource = null;
                dgvInsertOrder.DataSource = lay;
                DoiTen(dgvInsertOrder);
            }
        }
        #endregion

        #region Hien Thi
        private void checks()
        {
            toolStrip_txtSoluong.Text = "";
            toolStrip_txtChietkhauphantram.Text = "0";
            toolStrip_txtGianhap.Text = "0";
            toolStrip_Chietkhau.Text = "0";
            toolStrip_txtSoluong.Focus();
        }
        /// <summary>
        /// reset form
        /// </summary>
        private void ResetTool()
        {
            try
            {
                toolStrip_txtTracuu.Text = "<F4 - Tra cứu>";
                toolStrip_txtTenhang.Text = "";
                toolStrip_txtSoluong.Text = "1";
                toolStrip_txtGianhap.Text = "";
                toolStrip_txtGiagoc.Text = "0";
                toolStrip_txtNgayhethan.Text = this.Date.ToString("dd/MM/yyyy");
                toolStrip_txtChietkhauphantram.Text = "";
            }
            catch { }
        }
        /// <summary>
        /// cap nhat trang thai txt
        /// </summary>
        private void reset()
        {
            txtTienTraLai.Text = "0";
            txtTongThanhToan.Text = "0";
            txtGiatrigiatang.Text = "0";
            txtTienhang.Text = "0";
            txtChietkhau.Text = "0";
            txtThanhtoanngay.Text = "0";
        }
        #endregion

        #region Kiem Tra
        /// <summary>
        /// hungvv --------------------kiem tra ma hang------------------
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string KiemTraMa(string ID)
        {
            string kt = null;
            try
            {
                Entities.KiemTraChung ktm = new Entities.KiemTraChung();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                ktm = new Entities.KiemTraChung("Select", ID);
                clientstrem = cl.SerializeObj(this.client, "KiemTraMa", ktm);
                Entities.KiemTraChung tra = new Entities.KiemTraChung();
                tra = (Entities.KiemTraChung)cl.DeserializeHepper(clientstrem, tra);
                kt = tra.Hanhdong;
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return kt;
        }
        /// <summary>
        /// hungvv --------------------kiem tra ma hang khi them chi tiet hang------------------
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string KiemTraMa(Entities.HienThi_ChiTiet_DonDatHang lay)
        {
            string kt = null;
            try
            {
                Entities.KiemTraChung ktm = new Entities.KiemTraChung();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                ktm = new Entities.KiemTraChung("Select", lay.MaHangHoa, lay.TenHangHoa);
                clientstrem = cl.SerializeObj(this.client, "KiemTraMa", ktm);
                Entities.KiemTraChung tra = new Entities.KiemTraChung();
                tra = (Entities.KiemTraChung)cl.DeserializeHepper(clientstrem, tra);
                if (tra != null)
                {
                    kt = tra.Hanhdong;
                }
                else
                { kt = null; }
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return kt;
        }
        /// <summary>
        /// them hang moi 1 row vao dgv
        /// </summary>
        private string kiemtrangay(string ngay)
        {
            string s = "";
            try
            {
                s = new Common.Utilities().MyDateConversion(ngay);

            }
            catch (Exception ex)
            { string a = ex.Message.ToString(); s = ""; }
            return s;
        }
        #endregion

        #region ChiTietHoaDonNhap
        /// <summary>
        /// hungvv them moi row ==============================================================================
        /// </summary>
        public void LayGiaTri(DataGridView dgv, Entities.HienThi_ChiTiet_DonDatHang themmoi)
        {
            try
            {
                ArrayList arr = new ArrayList();
                Entities.HienThi_ChiTiet_DonDatHang[] list = null;
                if (dgv.RowCount > 0)
                {
                    int count = dgv.RowCount;
                    list = new Entities.HienThi_ChiTiet_DonDatHang[count];
                    Boolean check = false;
                    for (int i = 0; i < count; i++)
                    {
                        string sl = "1";
                        string gn = "0";
                        string tong = "0";
                        Entities.HienThi_ChiTiet_DonDatHang row = new Entities.HienThi_ChiTiet_DonDatHang();
                        row.MaHangHoa = dgv.Rows[i].Cells[1].Value.ToString().ToUpper();
                        row.TenHangHoa = dgv.Rows[i].Cells[2].Value.ToString();
                        if (dgv.Rows[i].Cells[1].Value.ToString() == themmoi.MaHangHoa)
                        {
                            sl = (int.Parse(dgv.Rows[i].Cells[3].Value.ToString()) + themmoi.SoLuongDat).ToString();
                            tong = new Common.Utilities().FormatMoney(Double.Parse(sl) * Double.Parse(dgv.Rows[i].Cells[4].Value.ToString()));
                            gn = new Common.Utilities().FormatMoney((Double.Parse(tong) - ((Double.Parse(dgv.Rows[i].Cells[7].Value.ToString()) / 100 * Double.Parse(dgv.Rows[i].Cells[4].Value.ToString())) * Double.Parse(sl))));
                            check = true;
                        }
                        else
                        {
                            sl = (Convert.ToInt32(dgv.Rows[i].Cells[3].Value.ToString())).ToString();
                            tong = dgv.Rows[i].Cells[11].Value.ToString();
                            gn = dgv.Rows[i].Cells[9].Value.ToString();
                        }
                        row.SoLuongDat = int.Parse(sl);
                        row.GiaGoc = new Common.Utilities().FormatMoney(Double.Parse(dgv.Rows[i].Cells[4].Value.ToString()));
                        row.Giabanbuon = new Common.Utilities().FormatMoney(Double.Parse(dgv.Rows[i].Cells[5].Value.ToString()));
                        row.Giabanle = new Common.Utilities().FormatMoney(Double.Parse(dgv.Rows[i].Cells[6].Value.ToString()));
                        row.PhanTramChietKhau = dgv.Rows[i].Cells[7].Value.ToString();
                        row.Thuegiatrigiatang = Double.Parse(0 + dgv.Rows[i].Cells[8].Value.ToString()).ToString();
                        row.GiaNhap = gn;
                        row.TongTien = tong;
                        row.Ngayhethan = dgv.Rows[i].Cells[12].Value.ToString();
                        arr.Add(row);
                    }
                    if (check == false)
                    {
                        Entities.HienThi_ChiTiet_DonDatHang row = new Entities.HienThi_ChiTiet_DonDatHang();
                        row.MaHangHoa = themmoi.MaHangHoa;
                        row.TenHangHoa = themmoi.TenHangHoa;
                        row.SoLuongDat = themmoi.SoLuongDat;
                        row.GiaGoc = new Common.Utilities().FormatMoney(Double.Parse(themmoi.GiaGoc));
                        row.Giabanbuon = new Common.Utilities().FormatMoney(Double.Parse(themmoi.Giabanbuon));
                        row.Giabanle = new Common.Utilities().FormatMoney(Double.Parse(themmoi.Giabanle));
                        row.PhanTramChietKhau = themmoi.PhanTramChietKhau;
                        row.Thuegiatrigiatang = themmoi.Thuegiatrigiatang;
                        row.GiaNhap = new Common.Utilities().FormatMoney(Double.Parse(themmoi.GiaNhap));
                        row.TongTien = new Common.Utilities().FormatMoney(Double.Parse(themmoi.TongTien));
                        row.Ngayhethan = themmoi.Ngayhethan;
                        arr.Add(row);
                    }
                }
                else
                {
                    list = new Entities.HienThi_ChiTiet_DonDatHang[1];
                    Entities.HienThi_ChiTiet_DonDatHang row = new Entities.HienThi_ChiTiet_DonDatHang();
                    row.MaHangHoa = themmoi.MaHangHoa;
                    row.TenHangHoa = themmoi.TenHangHoa;
                    row.SoLuongDat = themmoi.SoLuongDat;
                    row.GiaGoc = new Common.Utilities().FormatMoney(Double.Parse(themmoi.GiaGoc));
                    row.Giabanbuon = new Common.Utilities().FormatMoney(Double.Parse(themmoi.Giabanbuon));
                    row.Giabanle = new Common.Utilities().FormatMoney(Double.Parse(themmoi.Giabanle));
                    row.PhanTramChietKhau = themmoi.PhanTramChietKhau;
                    row.Thuegiatrigiatang = themmoi.Thuegiatrigiatang;
                    row.GiaNhap = new Common.Utilities().FormatMoney(Double.Parse(themmoi.GiaNhap));
                    row.TongTien = new Common.Utilities().FormatMoney(Double.Parse(themmoi.TongTien));
                    row.Ngayhethan = themmoi.Ngayhethan;
                    arr.Add(row);
                }
                int n = arr.Count;
                if (n == 0) { list = null; }
                list = new Entities.HienThi_ChiTiet_DonDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.HienThi_ChiTiet_DonDatHang)arr[i];
                }
                if (list != null)
                {
                    dgv.DataSource = null;
                    dgv.DataSource = list;
                }
                else
                {
                    dgv.DataSource = null;
                    Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                    dgv.DataSource = lay;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                dgv.DataSource = null;
                Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgv.DataSource = lay;
            }
        }

        /// <summary>
        /// cap nhat lai ngay het han
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="themmoi"></param>
        private void LuuNgayHetHan(DataGridView dgv, string ma, string ngaymoi)
        {
            try
            {
                ArrayList arr = new ArrayList();
                Entities.HienThi_ChiTiet_DonDatHang[] list = null;
                if (dgv.RowCount > 0)
                {
                    int count = dgv.RowCount;
                    list = new Entities.HienThi_ChiTiet_DonDatHang[count];
                    for (int i = 0; i < count; i++)
                    {
                        Entities.HienThi_ChiTiet_DonDatHang row = new Entities.HienThi_ChiTiet_DonDatHang();
                        row.MaHangHoa = dgv.Rows[i].Cells[1].Value.ToString().ToUpper();
                        row.TenHangHoa = dgv.Rows[i].Cells[2].Value.ToString();
                        row.SoLuongDat = int.Parse(dgv.Rows[i].Cells[3].Value.ToString());
                        row.GiaGoc = dgv.Rows[i].Cells[4].Value.ToString();
                        row.Giabanbuon = dgv.Rows[i].Cells[5].Value.ToString();
                        row.Giabanle = dgv.Rows[i].Cells[6].Value.ToString();
                        row.PhanTramChietKhau = dgv.Rows[i].Cells[7].Value.ToString();
                        row.Thuegiatrigiatang = dgv.Rows[i].Cells[8].Value.ToString();
                        row.TongTien = dgv.Rows[i].Cells[9].Value.ToString();
                        row.GiaNhap = dgv.Rows[i].Cells[11].Value.ToString();
                        string ngay = row.Ngayhethan = dgv.Rows[i].Cells[12].Value.ToString();
                        if (dgv.Rows[i].Cells[1].Value.ToString() == ma)
                        {
                            row.Ngayhethan = ngaymoi;
                        }
                        else
                        {
                            row.Ngayhethan = ngay;
                        }
                        arr.Add(row);
                    }
                }
                int n = arr.Count;
                if (n == 0) { list = null; }
                list = new Entities.HienThi_ChiTiet_DonDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.HienThi_ChiTiet_DonDatHang)arr[i];
                }
                if (list != null)
                {
                    dgv.DataSource = null;
                    dgv.DataSource = list;
                }
                else
                {
                    dgv.DataSource = null;
                    Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                    dgv.DataSource = lay;
                }
                DoiTen(dgvInsertOrder);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                dgv.DataSource = null;
                Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgv.DataSource = lay;
                DoiTen(dgvInsertOrder);
            }
        }
        #endregion

        #region Quy Doi
        private Entities.HangHoaGoiHang quydoiDonViTinh;
        private void QuyDoi(string mahang)
        {
            try
            {
                Entities.HangHoaGoiHang dat = new Entities.HangHoaGoiHang();
                dat.Hanhdong = "Select";
                dat.MaHang = mahang;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "QuyDoi", dat);
                quydoiDonViTinh = new Entities.HangHoaGoiHang();
                quydoiDonViTinh = (Entities.HangHoaGoiHang)cl.DeserializeHepper(clientstrem, quydoiDonViTinh);
                client.Close();
                clientstrem.Close();
                if (quydoiDonViTinh.MaHang != null)
                {
                    toolStrip_txtTracuu.Text = quydoiDonViTinh.MaHang;
                    toolStrip_txtTenhang.Text = quydoiDonViTinh.TenHang;
                    toolStrip_txtGiagoc.Text = quydoiDonViTinh.GiaNhap;
                    toolStrip_txtSoluong.Text = (float.Parse(toolStrip_txtSoluong.Text) * float.Parse(quydoiDonViTinh.SoLuong)).ToString();
                    toolStrip_txtGianhap.Text = quydoiDonViTinh.GiaNhap;
                    toolStrip_txtThuegiatrigiatang.Text = quydoiDonViTinh.Thue;
                    banbuon = quydoiDonViTinh.GiaBanBuon;
                    banle = quydoiDonViTinh.GiaBanLe;
                    giatrigiatang = quydoiDonViTinh.Thue;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        #region AddRow
        private void Thems(KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtManhacungcap.Text != "<F4 - Tra cứu>")
                    {
                        getID("HoaDonNhap");
                        if (txtSodonhang.Text == makiemtra)
                        {
                            if (kiemtrangaytrong_dgv(dgvInsertOrder) == 1)
                            {
                                XuLy_HoaDonNhap("Insert");
                            }
                            else
                            { MessageBox.Show("Phải nhập ngày hết hạn cho hàng hóa"); }
                        }
                        else
                        { txtSodonhang.Text = makiemtra; MessageBox.Show("Mã hóa đơn đã thay đổi"); }
                    }
                    else
                    { MessageBox.Show("Nhập mã nhà cung cấp"); }
                }
            }
            catch { }
        }
        /// <summary>
        /// 
        /// </summary>
        //int bienchay = 0;
        private void NewRow()
        {
            try
            {
                //if (bienchay > 1000)
                //{
                //    return;
                //}
                //for (int i = bienchay; i < bienchay + 100; i++)
                //{
                //    toolStrip_txtTracuu.Text = "HH" + i;
                //    toolStrip_txtTenhang.Text = "hàng hóa " + i;
                //    toolStrip_txtSoluong.Text = "100";
                //    toolStrip_txtGiagoc.Text = "100";

                #region Run
                //try
                //{
                //    QuyDoi(toolStrip_txtTracuu.Text.ToUpper());
                //}
                //catch
                //{ }

                ////////////////////////////MRK FIX
                //Kiểm tra bảng quy đổi đơn vị tính
                bool QUYDOI = false;
                List<Entities.QuyDoiDonViTinh> lDVT = this.dsQuyDoiDonViTinh;
                Entities.QuyDoiDonViTinh lDVTSelect = new Entities.QuyDoiDonViTinh();
                foreach (Entities.QuyDoiDonViTinh item in lDVT)
                {
                    if (item.MaHangQuyDoi.Equals(toolStrip_txtTracuu.Text))
                    {
                        //MaHang = item.MaHangDuocQuyDoi; //tạm thời chuyển mã hàng về mã hàng được quy đổi để lấy thông tin
                        lDVTSelect = item;  //biến tạm
                        QUYDOI = true; //trạng thái mã hàng đang nhập vào là hàng quy đổi hay không?
                        break;
                    }
                }
                if (QUYDOI)
                {
                    string txtTraCuuTEM = lDVTSelect.MaHangDuocQuyDoi;
                    string txtSoLuongTEM = (float.Parse(toolStrip_txtSoluong.Text) * lDVTSelect.SoLuongDuocQuyDoi).ToString();
                    //toolStrip_txtTracuu.Text = lDVTSelect.MaHangDuocQuyDoi;
                    //try
                    //{
                    //    toolStrip_txtSoluong.Text = (float.Parse(toolStrip_txtSoluong.Text) * lDVTSelect.SoLuongDuocQuyDoi).ToString();
                    //}
                    //catch { }
                    if (toolStrip_txtTenhang.Text != string.Empty)
                    {
                        if (txtManhacungcap.Text != "")
                        {
                            Entities.HienThi_ChiTiet_DonDatHang add = new Entities.HienThi_ChiTiet_DonDatHang();
                            add.MaHangHoa = txtTraCuuTEM.ToUpper();
                            string thongbao = KiemTraMa(add);
                            add.TenHangHoa = toolStrip_txtTenhang.Text;
                            add.SoLuongDat = int.Parse(0 + txtSoLuongTEM);
                            add.GiaGoc = toolStrip_txtGiagoc.Text;
                            add.Giabanbuon = Double.Parse(0 + banbuon).ToString();
                            add.Giabanle = Double.Parse(0 + banle).ToString();
                            add.TongTien = (float.Parse(0 + toolStrip_txtGiagoc.Text) * int.Parse(0 + txtSoLuongTEM)).ToString();
                            add.PhanTramChietKhau = int.Parse(0 + toolStrip_txtChietkhauphantram.Text).ToString();
                            add.GiaNhap = Double.Parse(toolStrip_txtGianhap.Text).ToString();
                            add.Thuegiatrigiatang = Double.Parse(0 + toolStrip_txtThuegiatrigiatang.Text).ToString();
                            add.ChietKhau = float.Parse(0 + toolStrip_Chietkhau.Text).ToString();
                            Common.Utilities ck = new Common.Utilities();
                            string ngay = toolStrip_txtNgayhethan.Text;
                            string ngayhientai = this.Date.ToString("dd/MM/yyyy");
                            if (Utils.StringToDateTime(ngayhientai).Date <= Utils.StringToDateTime(ngay).Date)
                            {
                                add.Ngayhethan = ngay;
                                if (float.Parse(toolStrip_txtGianhap.Text) > 0)
                                {
                                    if (thongbao == "NO")
                                    {
                                        MessageBox.Show("Mã hàng không đúng");
                                        toolStrip_txtTracuu.Focus();
                                        return;
                                    }
                                    else
                                    {
                                        LayGiaTri(dgvInsertOrder, add);
                                        DoiTen(dgvInsertOrder);
                                        ResetTool();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Kiểm tra giá nhập");
                                }
                            }
                            else
                            { MessageBox.Show("Kiểm tra lại định dạng ngày hết hạn <dd/MM/yyyy>"); }

                        }
                        else
                        {
                            ResetTool();
                            MessageBox.Show("Chọn nhà cung cấp");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Phải nhập hàng hóa");
                        return;
                    }
                }
                ////////////////////////////////////
                else
                {//Không Quy Đổi
                    if (toolStrip_txtTenhang.Text != string.Empty)
                    {
                        if (txtManhacungcap.Text != "")
                        {

                            Entities.HienThi_ChiTiet_DonDatHang add = new Entities.HienThi_ChiTiet_DonDatHang();
                            add.MaHangHoa = toolStrip_txtTracuu.Text.ToUpper();
                            string thongbao = KiemTraMa(add);
                            add.TenHangHoa = toolStrip_txtTenhang.Text;
                            add.SoLuongDat = int.Parse(0 + toolStrip_txtSoluong.Text);
                            add.GiaGoc = toolStrip_txtGiagoc.Text;
                            add.Giabanbuon = Double.Parse(0 + banbuon).ToString();
                            add.Giabanle = Double.Parse(0 + banle).ToString();
                            add.TongTien = (float.Parse(0 + toolStrip_txtGiagoc.Text) * int.Parse(0 + toolStrip_txtSoluong.Text)).ToString();
                            add.PhanTramChietKhau = int.Parse(0 + toolStrip_txtChietkhauphantram.Text).ToString();
                            add.GiaNhap = Double.Parse(toolStrip_txtGianhap.Text).ToString();
                            add.Thuegiatrigiatang = Double.Parse(0 + toolStrip_txtThuegiatrigiatang.Text).ToString();
                            add.ChietKhau = float.Parse(0 + toolStrip_Chietkhau.Text).ToString();
                            Common.Utilities ck = new Common.Utilities();
                            string ngay = toolStrip_txtNgayhethan.Text;
                            string ngayhientai = this.Date.ToString("dd/MM/yyyy");
                            bool _kq0 = true; bool _kq1 = true;
                            DateTime ngay1 = Utils.StringToDateTime(ngayhientai, out _kq0);  //DateTime.Parse(new Common.Utilities().KiemTraDinhDangNgayThangNam("ThangNgayNam", ngayhientai, '/'));
                            DateTime ngay2 = Utils.StringToDateTime(ngay, out _kq1);  //DateTime.Parse(new Common.Utilities().KiemTraDinhDangNgayThangNam("ThangNgayNam", ngay, '/'));
                            if (!_kq1 || !_kq0 || !(ngay1.Date <= ngay2.Date))
                            {
                                MessageBox.Show("Kiểm tra lại định dạng ngày hết hạn <dd/MM/yyyy>");
                            }
                            else
                            {
                                add.Ngayhethan = ngay;
                                if (float.Parse(toolStrip_txtGianhap.Text) > 0)
                                {
                                    if (thongbao == "NO")
                                    {
                                        MessageBox.Show("Mã hàng không đúng");
                                        toolStrip_txtTracuu.Focus();
                                        return;
                                    }
                                    else
                                    {
                                        LayGiaTri(dgvInsertOrder, add); DoiTen(dgvInsertOrder);
                                    }
                                }
                                else MessageBox.Show("Kiểm tra giá nhập");
                            }
                        }
                        else
                        { MessageBox.Show("Chọn nhà cung cấp"); return; }
                    }
                    else
                    { MessageBox.Show("Phải nhập hàng hóa"); return; }
                }
                #endregion

                //}

                //bienchay += 100;
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgvInsertOrder.DataSource = lay;
                MessageBox.Show("Kiểm tra ngày nhập");
            }
        }
        private void ThemVao()
        {
            try
            {
                if (chekChonLoai.Checked == false)
                {
                    if (toolStrip_txtNgayhethan.Text.Length > 6)
                    {
                        NewRow();
                        if (dgvInsertOrder.RowCount > 0)
                        {
                            TinhToan();
                            if (txtTongThanhToan.Text != "0")
                            {
                                fixTienTraLai();
                            }
                            else
                            { reset(); }
                            txtTienTraLai.Text = "0";
                        }
                        else
                        { reset(); }
                    }
                    else
                    { MessageBox.Show("Nhập ngày hết hạn"); }
                }
                if (chekChonLoai.Checked == true)
                {
                    if (toolStrip_txtNgayhethan.Text.Length > 6)
                    {
                        if (txtManhacungcap.Text != "")
                        {
                            string MaHangHoa = toolStrip_txtTracuu.Text;
                            Common.Utilities ck = new Common.Utilities();
                            string ngay = toolStrip_txtNgayhethan.Text;
                            string ngayhientai = DateServer.Date().ToString("dd/MM/yyyy");
                            if (toolStrip_txtTracuu.Text.Length > 0)
                            {
                                if (Utils.StringToDateTime(ngayhientai) <= Utils.StringToDateTime(ngay))
                                {
                                    LuuNgayHetHan(dgvInsertOrder, MaHangHoa, ngay);
                                    ResetTool();
                                }
                                else
                                { MessageBox.Show("Kiểm tra lại định dạng ngày hết hạn <dd/MM/yyyy>"); }
                            }
                        }
                    }
                    else
                    { MessageBox.Show("Nhập ngày hết hạn"); }
                }
            }
            catch { }
        }
        #endregion

        #region Format
        private void format()
        {
            try
            {
                if (chekChonLoai.Checked == false)
                {
                    Application.OpenForms[this.Name].Text = "Thêm đơn nhập kho - F3 Thanh toán - F6 sửa hàng hóa - F9 sửa giá hàng hóa";
                    dgvInsertOrder.DataSource = null;
                    Entities.HienThi_ChiTiet_DonDatHang[] row = new Entities.HienThi_ChiTiet_DonDatHang[0];
                    dgvInsertOrder.DataSource = row;
                    txtMadondathang.Text = "<F4 - Tra cứu>";
                    txtMadondathang.ReadOnly = true;
                    btnTimMadatmuahang.Enabled = false;
                    //toolStrip_btnThem.Enabled = true;
                    toolStrip_txtTracuu.Enabled = true;
                    toolStrip_txtSoluong.Enabled = true;
                    toolStrip_txtChietkhauphantram.Enabled = true;
                }
                if (chekChonLoai.Checked == true)
                {
                    Application.OpenForms[this.Name].Text = "Thêm đơn nhập kho - F3 Thanh toán - F9 Sửa giá hàng hóa";
                    txtMadondathang.ReadOnly = false;
                    btnTimMadatmuahang.Enabled = true;
                    //toolStrip_btnThem.Enabled = false;
                    toolStrip_txtTracuu.Enabled = false;
                    toolStrip_txtSoluong.Enabled = false;
                    toolStrip_txtChietkhauphantram.Enabled = false;
                }
                toolStrip_txtTracuu.Text = "";
                toolStrip_txtSoluong.Text = "1";
                toolStrip_txtChietkhauphantram.Text = "0";
                toolStrip_txtTenhang.Text = "";
                toolStrip_txtGianhap.Text = "0";
                toolStrip_txtGiagoc.Text = "0";
                toolStrip_txtThuegiatrigiatang.Text = "0";
                toolStrip_txtNgayhethan.Text = this.Date.ToString("dd/MM/yyyy");
                DoiTen(dgvInsertOrder);
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        #region Delete
        /// <summary>
        /// xoa hang hoa theo don nhap hang
        /// </summary
        private int XoaTheoHoaDon(string hanhdong, string ma)
        {
            int tra = 0;
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TruyenGiaTri truyen = new Entities.TruyenGiaTri();
                truyen.Hanhdong = "Update";
                truyen.Giatritruyen = hanhdong;
                truyen.Giatrithuhai = ma;
                clientstrem = cl.SerializeObj(this.client, "XoaTheoHoaDon", truyen);
                tra = (int)cl.DeserializeHepper(clientstrem, tra);
            }
            catch (Exception ex)
            { string s = ex.Message; tra = 0; }
            return tra;
        }
        /// <summary>
        /// xoa du lieu
        /// </summary>
        /// <param name="dgv"></param>
        private int i;
        private string date = "";
        private void getDataTable(DataGridView dgv)
        {
            try
            {
                ArrayList arr = new ArrayList();
                Entities.HienThi_ChiTiet_DonDatHang[] list = null;
                if (dgv.RowCount > 0 && i >= 0)
                {
                    toolStrip_txtTracuu.Text = dgv[1, i].Value.ToString();
                    toolStrip_txtTenhang.Text = dgv[2, i].Value.ToString();
                    toolStrip_txtSoluong.Text = int.Parse(0 + dgv[3, i].Value.ToString()).ToString();
                    toolStrip_txtGiagoc.Text = Double.Parse(0 + dgv[4, i].Value.ToString()).ToString();
                    banbuon = Double.Parse(0 + dgv[5, i].Value.ToString()).ToString();
                    banle = Double.Parse(0 + dgv[6, i].Value.ToString()).ToString();
                    toolStrip_txtChietkhauphantram.Text = "0";
                    toolStrip_txtThuegiatrigiatang.Text = Double.Parse(0 + dgv[8, i].Value.ToString()).ToString();
                    giatrigiatang = Double.Parse(0 + dgv[8, i].Value.ToString()).ToString();
                    toolStrip_Chietkhau.Text = "0";
                    toolStrip_txtGianhap.Text = (Double.Parse(0 + dgv[4, i].Value.ToString()) * int.Parse(toolStrip_txtSoluong.Text)).ToString();
                    //date = new Common.Utilities().KiemTraDinhDangNgayThangNam("NgayThangNam", dgv[12, i].Value.ToString(), '/');
                    date = dgv[12, i].Value.ToString();
                    if (date.Length <= 0)
                    { date = toolStrip_txtNgayhethan.Text = DateServer.Date().ToString("dd/MM/yyyy"); }
                    toolStrip_txtNgayhethan.Text = date;
                    for (int j = 0; j < dgv.RowCount; j++)
                    {
                        if (dgv[1, j].Value.ToString() != dgv[1, i].Value.ToString())
                        {
                            Entities.HienThi_ChiTiet_DonDatHang row = new Entities.HienThi_ChiTiet_DonDatHang();
                            row.MaHangHoa = dgv.Rows[j].Cells[1].Value.ToString();
                            row.TenHangHoa = "" + dgv.Rows[j].Cells[2].Value.ToString();
                            row.SoLuongDat = int.Parse(0 + dgv.Rows[j].Cells[3].Value.ToString());
                            row.GiaGoc = Double.Parse(0 + dgv.Rows[j].Cells[4].Value.ToString()).ToString();
                            row.Giabanbuon = Double.Parse(0 + dgv.Rows[j].Cells[5].Value.ToString()).ToString();
                            row.Giabanle = Double.Parse(0 + dgv.Rows[j].Cells[6].Value.ToString()).ToString();
                            row.PhanTramChietKhau = Double.Parse(0 + dgv.Rows[j].Cells[7].Value.ToString()).ToString();
                            row.Thuegiatrigiatang = Double.Parse(0 + dgv.Rows[j].Cells[8].Value.ToString()).ToString();
                            row.GiaNhap = Double.Parse(0 + dgv.Rows[j].Cells[9].Value.ToString()).ToString();
                            row.TongTien = Double.Parse(0 + dgv.Rows[j].Cells[11].Value.ToString()).ToString();
                            row.Ngayhethan = dgv.Rows[j].Cells[12].Value.ToString();
                            arr.Add(row);
                        }
                    }
                    int n = arr.Count;
                    if (n == 0) { arr = null; }
                    list = new Entities.HienThi_ChiTiet_DonDatHang[n];
                    for (int x = 0; x < n; x++)
                    {
                        list[x] = (Entities.HienThi_ChiTiet_DonDatHang)arr[x];
                    }
                    dgv.DataSource = list;
                }
                else
                {
                    toolStrip_txtNgayhethan.Text = new Common.Utilities().XuLy(2, date);
                    list = new Entities.HienThi_ChiTiet_DonDatHang[0];
                    arr = null;
                    dgv.DataSource = list;
                }
                DoiTen(dgv);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.HienThi_ChiTiet_DonDatHang[] list = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgv.DataSource = list;
                DoiTen(dgv);
            }
        }

        public void LayThongTinHang(DataGridView dgv)
        {
            try
            {
                if (dgv.RowCount > 0 && i >= 0)
                {
                    toolStrip_txtTracuu.Text = dgv[1, i].Value.ToString();
                    toolStrip_txtTenhang.Text = dgv[2, i].Value.ToString();
                    toolStrip_txtNgayhethan.Text = dgv.Rows[12].Cells[i].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
        #endregion

        #region Sua Ngay het han
        /// <summary>
        /// sua ngay
        /// </summary>
        /// <param name="dgv"></param>
        private void getData(DataGridView dgv)
        {
            try
            {
                ArrayList arr = new ArrayList();
                Entities.HienThi_ChiTiet_DonDatHang[] list = null;
                if (dgv.RowCount > 0 && i >= 0)
                {
                    toolStrip_txtTracuu.Text = dgv[1, i].Value.ToString();
                    toolStrip_txtTenhang.Text = dgv[2, i].Value.ToString();
                    toolStrip_txtSoluong.Text = Double.Parse(0 + dgv[3, i].Value.ToString()).ToString();
                    toolStrip_txtGiagoc.Text = Double.Parse(0 + dgv[4, i].Value.ToString()).ToString();
                    banbuon = Double.Parse(0 + dgv[5, i].Value.ToString()).ToString();
                    banle = Double.Parse(0 + dgv[6, i].Value.ToString()).ToString();
                    toolStrip_txtChietkhauphantram.Text = "0";
                    toolStrip_txtThuegiatrigiatang.Text = Double.Parse(0 + dgv[8, i].Value.ToString()).ToString();
                    giatrigiatang = Double.Parse(0 + dgv[8, i].Value.ToString()).ToString();
                    toolStrip_Chietkhau.Text = "0";
                    toolStrip_txtGianhap.Text = (Double.Parse(0 + dgv[4, i].Value.ToString()) * int.Parse(toolStrip_txtSoluong.Text)).ToString();
                    date = dgv[12, i].Value.ToString();
                    if (date.Length <= 0)
                    { date = toolStrip_txtNgayhethan.Text = this.Date.ToString("dd/MM/yyyy"); }
                    toolStrip_txtNgayhethan.Text = date;
                }
                else
                {
                    toolStrip_txtNgayhethan.Text = new Common.Utilities().XuLy(2, date);
                    list = new Entities.HienThi_ChiTiet_DonDatHang[0];
                    arr = null;
                    dgv.DataSource = list;
                }
                DoiTen(dgv);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.HienThi_ChiTiet_DonDatHang[] list = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgv.DataSource = list;
                DoiTen(dgv);
            }
        }
        #endregion

        #region Tinh Toan
        private string TinhTien(DataGridView dgv)
        {
            string tong = "0";
            try
            {
                Double gia = 0;
                if (dgv.RowCount != 0)
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        gia += (Double.Parse(new Common.Utilities().KhongDau(dgv[4, i].Value.ToString())) * Double.Parse(new Common.Utilities().KhongDau(dgv[3, i].Value.ToString())));
                    }
                    tong = Math.Round(gia).ToString();
                }
                else
                {
                    tong = "0";
                }
            }
            catch (Exception ex)
            { string s = ex.Message; tong = "0"; }
            return tong;
        }
        public string TinhThue(DataGridView dgv)
        {
            string tong = "0";
            try
            {
                double gia = 0;
                if (dgv.RowCount > 0)
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        Double thue = Double.Parse(new Common.Utilities().KhongDau(dgv[8, i].Value.ToString()));
                        Double thanhtien = Double.Parse(new Common.Utilities().KhongDau(dgv[9, i].Value.ToString()));
                        gia += ((thue / 100) * thanhtien);
                    }
                    tong = Math.Round(gia).ToString();
                }
                else
                {
                    tong = "0";
                }
            }
            catch (Exception ex)
            { string s = ex.Message; tong = "0"; }
            return tong;
        }
        private string TinhCK(DataGridView dgv)
        {
            string tong = "0";
            try
            {
                Double gia = 0;
                if (dgv.RowCount > 0)
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        Double chietkhau = Double.Parse(new Common.Utilities().KhongDau(dgv[9, i].Value.ToString()));
                        gia += Math.Round(chietkhau);
                    }
                }
                else
                { gia = 0; }
                //gia = Double.Parse(new Common.Utilities().KhongDau(txtChietkhau.Text));
                tong = Math.Round(gia).ToString();
            }
            catch (Exception ex)
            { string s = ex.Message; tong = "0"; }
            return tong;
        }
        private string TongThanhToan()
        {
            string tong = "0";
            try
            {
                tong = Math.Round((Double.Parse(new Common.Utilities().KhongDau(txtChietkhau.Text)) + Double.Parse(new Common.Utilities().KhongDau(txtGiatrigiatang.Text))) - Double.Parse(new Common.Utilities().KhongDau(txtTienCKTM.Text))).ToString();
            }
            catch (Exception ex)
            { string s = ex.Message; tong = "0"; }
            return tong;
        }
        private string ChietKhauTM(string giatri)
        {
            string tong = "0";
            try
            {
                if (Double.Parse(giatri) > 0)
                {
                    tong = Math.Round((Double.Parse(new Common.Utilities().KhongDau(txtChietkhau.Text)) * Double.Parse(giatri)) / 100).ToString();
                }
                else
                { tong = "0"; }
            }
            catch (Exception ex)
            { string s = ex.Message; tong = "0"; }
            return tong;
        }

        /// <summary>
        /// ham chung tinh toan
        /// </summary>
        private void TinhToan()
        {
            try
            {
                txtTienhang.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(TinhTien(dgvInsertOrder))));
                txtGiatrigiatang.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(TinhThue(dgvInsertOrder))));
                txtChietkhau.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(TinhCK(dgvInsertOrder))));
                //txtTienCKTM.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(ChietKhauTM(txtCKTM.Text))));
                txtTongThanhToan.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(TongThanhToan())));
                txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(txtTongThanhToan.Text)));
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        #region Lay Hang Hoa Theo Ma
        /// <summary>
        /// Tìm chi tiết hàng hóa và fill dữ liệu vào form
        /// </summary>
        /// <param name="MaHang"></param>
        private void LayHangHoaTheoMa(string MaHang)
        {
            try
            {
                Entities.QuyDoiDonViTinh lDVTSelect = new Entities.QuyDoiDonViTinh();
                if (checkQuyDoiDonViTinh(MaHang, out lDVTSelect))
                {
                    #region có quy đổi
                    Entities.HienThi_ChiTiet_DonDatHang ktm = new Entities.HienThi_ChiTiet_DonDatHang();
                    cl = new Server_Client.Client();
                    this.client = cl.Connect(Luu.IP, Luu.Ports);
                    ktm = new Entities.HienThi_ChiTiet_DonDatHang("Select", lDVTSelect.MaHangDuocQuyDoi);
                    clientstrem = cl.SerializeObj(this.client, "LayHangHoaTheoMaHangHoa", ktm);
                    Entities.HienThi_ChiTiet_DonDatHang tra = new Entities.HienThi_ChiTiet_DonDatHang();
                    tra = (Entities.HienThi_ChiTiet_DonDatHang)cl.DeserializeHepper(clientstrem, tra);
                    if (tra.MaHangHoa == null || tra == null)
                    {
                        toolStrip_txtTracuu.Focus();
                        frmXuLyHangHoa frm = new frmXuLyHangHoa("ThemNhapKho", lDVTSelect.MaHangDuocQuyDoi);
                        frm.ShowDialog();
                        ResetTool();
                        toolStrip_txtTracuu.Text = GiaTriCanLuu.mahanghoa;
                        //LayHangHoaTheoMa(toolStrip_txtTracuu.Text);
                    }
                    else
                    {
                        toolStrip_txtTracuu.Text = lDVTSelect.MaHangQuyDoi;
                        if (lDVTSelect.TenHangDuocQuyDoi.Equals(""))
                        {
                            toolStrip_txtTenhang.Text = lDVTSelect.MaHangQuyDoi;
                        }
                        else
                        {
                            toolStrip_txtTenhang.Text = lDVTSelect.TenHangDuocQuyDoi;
                        }
                        if (tra.SoLuongDat != null && tra.SoLuongDat > 0)
                        {
                            if (lDVTSelect.SoLuongDuocQuyDoi != null || lDVTSelect.SoLuongDuocQuyDoi > 0)
                            {
                                try
                                {
                                    toolStrip_txtSoluong.Text = (tra.SoLuongDat / lDVTSelect.SoLuongDuocQuyDoi).ToString();
                                }
                                catch { }
                            }
                        }
                        ////toolStrip_txtSoluong.Text = tra.SoLuongDat.ToString();
                        toolStrip_txtGiagoc.Text = tra.GiaGoc;
                        banbuon = tra.Giabanbuon;
                        banle = tra.Giabanle;
                        giatrigiatang = tra.Thuegiatrigiatang;
                        toolStrip_txtChietkhauphantram.Text = tra.PhanTramChietKhau;
                        toolStrip_txtThuegiatrigiatang.Text = int.Parse(0 + tra.Thuegiatrigiatang).ToString();
                        toolStrip_txtGianhap.Text = tra.GiaNhap;
                        toolStrip_txtNgayhethan.Text = this.Date.ToString("dd/MM/yyyy");
                        toolStrip_txtSoluong.Text = "";
                        toolStrip_txtSoluong.Focus();
                    }
                    #endregion
                }
                else
                {
                    #region không có quy đổi
                    Entities.HienThi_ChiTiet_DonDatHang ktm = new Entities.HienThi_ChiTiet_DonDatHang();
                    cl = new Server_Client.Client();
                    this.client = cl.Connect(Luu.IP, Luu.Ports);
                    ktm = new Entities.HienThi_ChiTiet_DonDatHang("Select", MaHang);
                    clientstrem = cl.SerializeObj(this.client, "LayHangHoaTheoMaHangHoa", ktm);
                    Entities.HienThi_ChiTiet_DonDatHang tra = new Entities.HienThi_ChiTiet_DonDatHang();
                    tra = (Entities.HienThi_ChiTiet_DonDatHang)cl.DeserializeHepper(clientstrem, tra);
                    if (tra.MaHangHoa == null || tra == null)
                    {
                        toolStrip_txtTracuu.Focus();
                        frmXuLyHangHoa frm = new frmXuLyHangHoa("ThemNhapKho", toolStrip_txtTracuu.Text);
                        frm.ShowDialog();
                        ResetTool();
                        toolStrip_txtTracuu.Text = GiaTriCanLuu.mahanghoa;
                    }
                    else
                    {
                        toolStrip_txtTracuu.Text = tra.MaHangHoa;
                        toolStrip_txtTenhang.Text = tra.TenHangHoa;
                        toolStrip_txtSoluong.Text = tra.SoLuongDat.ToString();
                        toolStrip_txtGiagoc.Text = tra.GiaGoc;
                        banbuon = tra.Giabanbuon;
                        banle = tra.Giabanle;
                        giatrigiatang = tra.Thuegiatrigiatang;
                        toolStrip_txtChietkhauphantram.Text = tra.PhanTramChietKhau;
                        toolStrip_txtThuegiatrigiatang.Text = int.Parse(0 + tra.Thuegiatrigiatang).ToString();
                        toolStrip_txtGianhap.Text = tra.GiaNhap;
                        toolStrip_txtNgayhethan.Text = this.Date.ToString("dd/MM/yyyy");
                        toolStrip_txtSoluong.Text = "";
                        toolStrip_txtSoluong.Focus();
                    }
                    #endregion
                }
            }
            catch { }
        }

        private Entities.HangHoa LayHangHoaTheoMa(Entities.HangHoa input)
        {
            try
            {
                string MaHang = input.MaHangHoa;
                Entities.QuyDoiDonViTinh lDVTSelect = new Entities.QuyDoiDonViTinh();
                if (checkQuyDoiDonViTinh(MaHang, out lDVTSelect))
                {
                    return new Entities.HangHoa();
                    //tạm bỏ
                    #region có quy đổi
                    Entities.HienThi_ChiTiet_DonDatHang ktm = new Entities.HienThi_ChiTiet_DonDatHang();
                    cl = new Server_Client.Client();
                    this.client = cl.Connect(Luu.IP, Luu.Ports);
                    ktm = new Entities.HienThi_ChiTiet_DonDatHang("Select", lDVTSelect.MaHangDuocQuyDoi);
                    clientstrem = cl.SerializeObj(this.client, "LayHangHoaTheoMaHangHoa", ktm);
                    Entities.HienThi_ChiTiet_DonDatHang tra = new Entities.HienThi_ChiTiet_DonDatHang();
                    tra = (Entities.HienThi_ChiTiet_DonDatHang)cl.DeserializeHepper(clientstrem, tra);
                    if (tra.MaHangHoa == null || tra == null)
                    {
                        toolStrip_txtTracuu.Focus();
                        frmXuLyHangHoa frm = new frmXuLyHangHoa("ThemNhapKho", lDVTSelect.MaHangDuocQuyDoi);
                        frm.ShowDialog();
                        ResetTool();
                        toolStrip_txtTracuu.Text = GiaTriCanLuu.mahanghoa;
                        //LayHangHoaTheoMa(toolStrip_txtTracuu.Text);
                    }
                    else
                    {
                        toolStrip_txtTracuu.Text = lDVTSelect.MaHangQuyDoi;
                        if (lDVTSelect.TenHangDuocQuyDoi.Equals(""))
                        {
                            toolStrip_txtTenhang.Text = lDVTSelect.MaHangQuyDoi;
                        }
                        else
                        {
                            toolStrip_txtTenhang.Text = lDVTSelect.TenHangDuocQuyDoi;
                        }
                        if (tra.SoLuongDat != null && tra.SoLuongDat > 0)
                        {
                            if (lDVTSelect.SoLuongDuocQuyDoi != null || lDVTSelect.SoLuongDuocQuyDoi > 0)
                            {
                                try
                                {
                                    toolStrip_txtSoluong.Text = (tra.SoLuongDat / lDVTSelect.SoLuongDuocQuyDoi).ToString();
                                }
                                catch { }
                            }
                        }
                        ////toolStrip_txtSoluong.Text = tra.SoLuongDat.ToString();
                        toolStrip_txtGiagoc.Text = tra.GiaGoc;
                        banbuon = tra.Giabanbuon;
                        banle = tra.Giabanle;
                        giatrigiatang = tra.Thuegiatrigiatang;
                        toolStrip_txtChietkhauphantram.Text = tra.PhanTramChietKhau;
                        toolStrip_txtThuegiatrigiatang.Text = int.Parse(0 + tra.Thuegiatrigiatang).ToString();
                        toolStrip_txtGianhap.Text = tra.GiaNhap;
                        toolStrip_txtNgayhethan.Text = this.Date.ToString("dd/MM/yyyy");
                        toolStrip_txtSoluong.Text = "";
                        toolStrip_txtSoluong.Focus();
                    }
                    #endregion
                }
                else
                {
                    #region không có quy đổi
                    cl = new Server_Client.Client();
                    client = cl.Connect(Luu.IP, Luu.Ports);
                    Entities.HangHoa temp = new Entities.HangHoa { HanhDong = "SelectHangHoa_Theo_MaHangHoa", MaHangHoa = MaHang };
                    clientstrem = cl.SerializeObj(client, "HangHoa", temp);
                    Entities.HangHoa[] hh1 = new Entities.HangHoa[1];
                    hh1 = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, hh1);
                    if (hh1 == null || hh1.Length == 0) return new Entities.HangHoa();
                    return hh1[0];
                    #endregion
                }
            }
            catch { }
            return new Entities.HangHoa();
        }
        #endregion

        #region Tinh Toan Lai
        private void checkNK()
        {
            try
            {
                ////////////////////////////////////////////////////MRK FIX
                bool QUYDOI = false;
                //Kiểm tra bảng quy đổi đơn vị tính
                List<Entities.QuyDoiDonViTinh> lDVT = dsQuyDoiDonViTinh;
                Entities.QuyDoiDonViTinh lDVTSelect = new Entities.QuyDoiDonViTinh();
                foreach (Entities.QuyDoiDonViTinh item in lDVT)
                {
                    if (item.MaHangQuyDoi.Equals(toolStrip_txtTracuu.Text))
                    {
                        //MaHang = item.MaHangDuocQuyDoi; //tạm thời chuyển mã hàng về mã hàng được quy đổi để lấy thông tin
                        lDVTSelect = item;  //biến tạm
                        QUYDOI = true; //trạng thái mã hàng đang nhập vào là hàng quy đổi hay không?
                        break;
                    }
                }
                ////////////////////////////////////////////////////////////
                if (QUYDOI)
                {
                    ////////////////////////////////////////////////////MRK FIX
                    Double t0 = (Double.Parse(toolStrip_txtGiagoc.Text)) * Double.Parse(toolStrip_txtSoluong.Text) * lDVTSelect.SoLuongDuocQuyDoi;
                    Double t1 = t0;
                    if (float.Parse(0 + toolStrip_txtChietkhauphantram.Text) > 100)
                    {
                        toolStrip_txtChietkhauphantram.Text = "0";
                    }
                    t0 -= (t0 * (Double.Parse(toolStrip_txtChietkhauphantram.Text) / 100));
                    toolStrip_txtGianhap.Text = new Common.Utilities().FormatMoney(t0).ToString();
                    toolStrip_Chietkhau.Text = new Common.Utilities().FormatMoney(t1).ToString();
                    ////////////////////////////////////////////////////////////
                }
                else
                {
                    string tong = (Double.Parse(toolStrip_txtGiagoc.Text) * Double.Parse(toolStrip_txtSoluong.Text)).ToString();
                    if (float.Parse(0 + toolStrip_txtChietkhauphantram.Text) > 100)
                    {
                        toolStrip_txtChietkhauphantram.Text = "0";
                        toolStrip_txtGianhap.Text = new Common.Utilities().FormatMoney(Double.Parse(tong));
                        toolStrip_Chietkhau.Text = new Common.Utilities().FormatMoney(Double.Parse(tong));
                    }
                    else
                    {
                        string gianhap = (Double.Parse(tong) - ((Double.Parse(toolStrip_txtChietkhauphantram.Text) / 100) * Double.Parse(tong))).ToString();
                        toolStrip_txtGianhap.Text = new Common.Utilities().FormatMoney(Double.Parse(gianhap));
                        toolStrip_Chietkhau.Text = new Common.Utilities().FormatMoney(Double.Parse(tong));
                    }
                }
            }
            catch { }
        }
        private void txtCKTMs()
        {
            try
            {
                if (dgvInsertOrder.RowCount > 0)
                {
                    if (Double.Parse(txtCKTM.Text) > 100)
                    {
                        txtCKTM.Text = "0";
                        txtTienCKTM.Text = "0";
                        txtTongThanhToan.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(TongThanhToan())));
                    }
                    else
                    {
                        if (txtCKTM.Text == "" || txtCKTM.Text == "0")
                        {
                            txtTienCKTM.Text = "0";
                            txtTongThanhToan.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(TongThanhToan())));
                        }
                        else
                        {
                            if (txtCKTM.Text == "100")
                            {
                                txtTienCKTM.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(txtChietkhau.Text)));
                                txtTongThanhToan.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(txtGiatrigiatang.Text)));
                            }
                            else
                            {
                                txtTienCKTM.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(ChietKhauTM(txtCKTM.Text))));
                                txtTongThanhToan.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(TongThanhToan())));
                            }
                        }
                    }
                    //if (txtTongThanhToan.Text != "0")
                    //{
                    //    fixTienTraLai();
                    //}
                    //else
                    //{ txtTienTraLai.Text = "0"; }
                    txtTienTraLai.Text = "0";
                    txtThanhtoanngay.Text = "0";
                }
                else
                { reset(); }
            }
            catch { }
        }
        private void fixTienTraLai()
        {
            try
            {
                if (Double.Parse(txtThanhtoanngay.Text.Replace(",", "")) > Double.Parse(txtTongThanhToan.Text) && txtTongThanhToan.Text != "0")
                {
                    //txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(Double.Parse(txtThanhtoanngay.Text));
                    txtTienTraLai.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(txtThanhtoanngay.Text.Replace(",", ""))) - Double.Parse(new Common.Utilities().KhongDau(txtTongThanhToan.Text)));
                }
                else
                {
                    if (Double.Parse(txtThanhtoanngay.Text.Replace(",", "")) == Double.Parse(txtTongThanhToan.Text))
                    {
                        txtTienTraLai.Text = "0";
                        txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(txtThanhtoanngay.Text.Replace(",", ""))));
                    }
                    else
                    {
                        txtTienTraLai.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(txtThanhtoanngay.Text.Replace(",", ""))) - Double.Parse(new Common.Utilities().KhongDau(txtTongThanhToan.Text)));
                        if (txtThanhtoanngay.Text.Replace(",", "").Length < 3)
                        { txtThanhtoanngay.Text = new Common.Utilities().loc(txtThanhtoanngay.Text.Replace(",", "")); }
                    }
                }

            }
            catch { }
        }
        #endregion

        #region In
        private void InThongTinDonHang()
        {
            try
            {
                Entities.BaoCaoHoaDonNhap[] hoadon = new Entities.BaoCaoHoaDonNhap[dgvInsertOrder.RowCount];
                for (int k = 0; k < dgvInsertOrder.RowCount; k++)
                {
                    Entities.BaoCaoHoaDonNhap row = new Entities.BaoCaoHoaDonNhap
                    (
                        dgvInsertOrder.Rows[k].Cells[1].Value.ToString(),
                        dgvInsertOrder.Rows[k].Cells[2].Value.ToString(),
                        Double.Parse(dgvInsertOrder.Rows[k].Cells[4].Value.ToString()),
                        int.Parse(dgvInsertOrder.Rows[k].Cells[3].Value.ToString()),
                        int.Parse(dgvInsertOrder.Rows[k].Cells[7].Value.ToString()),
                        Double.Parse(dgvInsertOrder.Rows[k].Cells[9].Value.ToString()),
                        Double.Parse(dgvInsertOrder.Rows[k].Cells[8].Value.ToString()),
                        Double.Parse(dgvInsertOrder.Rows[k].Cells[11].Value.ToString())
                    );
                    hoadon[k] = row;
                }
                Entities.TruyenGiaTriVaoBaoCao baocao = new Entities.TruyenGiaTriVaoBaoCao();
                baocao.Giatri1 = "Hóa Đơn Nhập Kho";
                baocao.Giatri2 = this.Date.ToString("dd/MM/yyyy");
                baocao.Giatri3 = txtSodonhang.Text;
                baocao.Giatri4 = Common.Utilities.User.TenNhanVien;
                baocao.Giatri5 = makNgaydonhang.Text;
                baocao.Giatri6 = txtManhacungcap.Text;
                baocao.Giatri7 = makHanthanhtoan.Text;
                baocao.Giatri8 = cbxKhoHang.Text;
                baocao.Giatri9 = chekChonLoai.Text;
                string chuoi = "Không theo đơn";
                if (txtMadondathang.Text.Length > 0)
                { chuoi = txtMadondathang.Text; }
                baocao.Giatri10 = chuoi;
                baocao.Giatri11 = cbxHinhthucthanhtoan.Text;
                baocao.Giatri12 = new Common.Utilities().FormatMoney(Double.Parse(txtThanhtoanngay.Text.Replace(",", "")));
                baocao.Giatri13 = new Common.Utilities().FormatMoney(Double.Parse(txtTienCKTM0.Text));
                baocao.Giatri14 = txtTongThanhToan.Text;
                baocao.Giatri15 = txtChietkhau.Text;
                baocao.Giatri16 = txtGiatrigiatang.Text;
                baocao.Giatri17 = new Common.Utilities().FormatMoney(Double.Parse(txtTienTraLai.Text));
                frmBaoCaoNhapHang frm = new frmBaoCaoNhapHang("HoaDonNhap", hoadon, baocao, Congty(""));
                frm.ShowDialog();
            }
            catch { }
        }
        #endregion

        #region CongTy
        private Entities.ThongTinCongTy Congty(string maCongTy)
        {
            Entities.ThongTinCongTy thongtin = null;
            try
            {
                Entities.TruyenGiaTri truyen = new Entities.TruyenGiaTri("Select", maCongTy);
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "LayThongTinCongty", truyen);
                thongtin = (Entities.ThongTinCongTy)cl.DeserializeHepper(clientstrem, thongtin);
                client.Close();
                clientstrem.Close();
            }
            catch { return null; }
            return thongtin;
        }
        #endregion

        #region XuLyChuoi Unicode
        private bool testCharacter(string chuoi)
        {
            bool check = false;
            try
            {
                if (chuoi != "")
                {
                    bool kt = false;
                    foreach (char ch in chuoi)
                    {
                        char[] a = new char[]
                    {'+','-','~','`','@','#','$','%','^','&','*','(',')','{','}','[',']',':',';','|',
                        '<','>',',','.','?','/','-','=',
                        'ă','â','á','à','ả','ạ','ã','ắ','ằ','ẳ','ẵ','ặ','ấ','ầ','ẩ','ậ','ẫ',
                        'Ă','Â','Á','À','Ả','Ạ','Ã','Ắ','Ằ','Ẳ','Ẵ','Ặ','Ấ','Ầ','Ẩ','Ẫ','Ậ',
                        'ê','é','è','ẻ','ẽ','ẹ','ế','ề','ể','ễ','ệ',
                        'Ê','É','È','Ẻ','Ẽ','Ẹ','Ế','Ề','Ể','Ễ','Ệ',
                        'ô','ơ','ó', 'ò', 'ỏ', 'ọ', 'õ','ố', 'ồ','ổ', 'ộ','ỗ','ớ','ờ','ở','ợ','ỡ',
                        'Ô','o','Ó', 'Ò', 'Ỏ', 'Õ', 'Ọ','Ố', 'Ồ','Ổ', 'Ộ','Ỗ','Ớ','Ờ','Ở','Ợ','Ỡ',
                        'ư','ú','ù','ủ','ụ','ũ', 'ứ','ừ', 'ử', 'ự', 'ữ',
                        'Ư','Ú','Ù','Ủ','Ụ','Ũ', 'Ứ','Ừ', 'Ử', 'Ự', 'Ữ',
                        'í','ì','ỉ','ị','ĩ',
                        'Í','Ì','Ỉ','Ị','Ĩ',
                        'đ','Đ'
                    };
                        foreach (char c in a)
                        {
                            if (c.Equals(ch))
                                kt = true;
                            break;
                        }
                        if (kt == true)
                        {
                            MessageBox.Show("Mã Hàng Hóa Không được nhập tiếng việt có dấu " +
                                          "\nNếu bạn đang dùng máy quét mã vạch hãy tắt bộ gõ Tiếng Tiệt đi! ", "Hệ Thống Cảnh Báo");
                            toolStrip_txtTracuu.Focus();
                            toolStrip_txtTracuu.SelectAll();
                            check = false;
                            break;
                        }
                        else
                        { check = true; }
                    }
                }
                else
                { check = true; }
            }
            catch (Exception ex)
            { string s = ex.Message; check = false; }
            return check;
        }
        #endregion

        #region Event
        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmQuanLyNhapKho.BaoDong = "A";
                        this.Close();
                    }
                }
            }
            catch { }
        }

        private void toolStrip_txtChietkhauphantram_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(toolStrip_txtChietkhauphantram.Text) > 0)
                {
                    checkNK();
                }
                else
                {
                    ////////////////////////////////////////////////////MRK FIX
                    bool QUYDOI = false;
                    //Kiểm tra bảng quy đổi đơn vị tính
                    List<Entities.QuyDoiDonViTinh> lDVT = dsQuyDoiDonViTinh;
                    Entities.QuyDoiDonViTinh lDVTSelect = new Entities.QuyDoiDonViTinh();
                    foreach (Entities.QuyDoiDonViTinh item in lDVT)
                    {
                        if (item.MaHangQuyDoi.Equals(toolStrip_txtTracuu.Text))
                        {
                            //MaHang = item.MaHangDuocQuyDoi; //tạm thời chuyển mã hàng về mã hàng được quy đổi để lấy thông tin
                            lDVTSelect = item;  //biến tạm
                            QUYDOI = true; //trạng thái mã hàng đang nhập vào là hàng quy đổi hay không?
                            break;
                        }
                    }
                    ////////////////////////////////////////////////////////////
                    if (QUYDOI)
                    {
                        ////////////////////////////////////////////////////MRK FIX
                        Double t0 = (Double.Parse(toolStrip_txtGiagoc.Text)) * Double.Parse(toolStrip_txtSoluong.Text) * lDVTSelect.SoLuongDuocQuyDoi;
                        Double t1 = t0;
                        toolStrip_txtChietkhauphantram.Text = "0";
                        t0 -= (t0 * (Double.Parse(toolStrip_txtChietkhauphantram.Text) / 100));
                        toolStrip_txtGianhap.Text = new Common.Utilities().FormatMoney(t0).ToString();
                        toolStrip_Chietkhau.Text = new Common.Utilities().FormatMoney(t1).ToString();
                        ////////////////////////////////////////////////////////////
                    }
                    else
                    {
                        string tong = (Double.Parse(toolStrip_txtGiagoc.Text) * Double.Parse(toolStrip_txtSoluong.Text)).ToString();
                        toolStrip_txtChietkhauphantram.Text = "0";
                        toolStrip_txtGianhap.Text = new Common.Utilities().FormatMoney(Double.Parse(tong));
                        toolStrip_Chietkhau.Text = new Common.Utilities().FormatMoney(Double.Parse(tong));
                    }
                }
            }
            catch { }
        }
        private void toolStrip_txtSoluong_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (toolStrip_txtSoluong.Text == "" || int.Parse(0 + toolStrip_txtSoluong.Text) <= 0)
                {
                    checks();
                }
                else
                {
                    ////////////////////////////////////////////////////MRK FIX
                    bool QUYDOI = false;
                    //Kiểm tra bảng quy đổi đơn vị tính
                    List<Entities.QuyDoiDonViTinh> lDVT = dsQuyDoiDonViTinh;
                    Entities.QuyDoiDonViTinh lDVTSelect = new Entities.QuyDoiDonViTinh();
                    foreach (Entities.QuyDoiDonViTinh item in lDVT)
                    {
                        if (item.MaHangQuyDoi.Equals(toolStrip_txtTracuu.Text))
                        {
                            //MaHang = item.MaHangDuocQuyDoi; //tạm thời chuyển mã hàng về mã hàng được quy đổi để lấy thông tin
                            lDVTSelect = item;  //biến tạm
                            QUYDOI = true; //trạng thái mã hàng đang nhập vào là hàng quy đổi hay không?
                            break;
                        }
                    }
                    ////////////////////////////////////////////////////////////
                    if (QUYDOI)
                    {
                        ////////////////////////////////////////////////////MRK FIX
                        Double t0 = (Double.Parse(toolStrip_txtGiagoc.Text)) * Double.Parse(toolStrip_txtSoluong.Text) * lDVTSelect.SoLuongDuocQuyDoi;
                        Double t1 = t0;
                        t0 -= (t0 * (Double.Parse(toolStrip_txtChietkhauphantram.Text) / 100));
                        toolStrip_txtGianhap.Text = new Common.Utilities().FormatMoney(t0).ToString();
                        toolStrip_Chietkhau.Text = new Common.Utilities().FormatMoney(t1).ToString();
                        ////////////////////////////////////////////////////////////
                    }
                    else
                    {
                        Double t0 = (Double.Parse(toolStrip_txtGiagoc.Text)) * Double.Parse(toolStrip_txtSoluong.Text);
                        Double t1 = t0;
                        t0 -= (t0 * (Double.Parse(toolStrip_txtChietkhauphantram.Text) / 100));
                        toolStrip_txtGianhap.Text = new Common.Utilities().FormatMoney(t0).ToString();
                        toolStrip_Chietkhau.Text = new Common.Utilities().FormatMoney(t1).ToString();
                    }
                }
            }
            catch { }
        }

        private void txtCKTM_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (hanhdong == "Insert")
                {
                    if (txtCKTM.Text != "")
                    {
                        if (dgvInsertOrder.RowCount > 0)
                        {
                            if (txtCKTM.Text.Length <= 2)
                            {
                                txtCKTM.Text = new Common.Utilities().loc(txtCKTM.Text);
                                txtCKTMs();
                            }
                            else
                            { txtCKTMs(); }
                        }
                        else
                        { reset(); ResetTool(); }
                    }
                    else
                    { txtTienCKTM.Text = "0"; }
                    txtTongThanhToan.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(TongThanhToan())));
                }
            }
            catch { }
        }

        private void txtThanhtoanngay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                new TienIch().AutoFormatMoney(sender);
                if (hanhdong == "Insert")
                {
                    if (dgvInsertOrder.RowCount > 0)
                    {
                        if (txtThanhtoanngay.Text.Replace(",", "") != "" && txtThanhtoanngay.Text.Replace(",", "") != "0")
                        {
                            fixTienTraLai();
                        }
                        else
                        {
                            txtTienTraLai.Text = "-" + (Double.Parse(txtTongThanhToan.Text) - Double.Parse(0 + txtThanhtoanngay.Text.Replace(",", ""))).ToString();
                        }
                    }
                    else
                    { txtTienTraLai.Text = "0"; reset(); }
                }
            }
            catch { }
        }

        private void cbxTienTe_TyGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < tigia.Length; i++)
                {
                    if (cbxTienTe_TyGia.SelectedValue.ToString() == tigia[i].Khoachinh.ToString())
                    {
                        txtTygia.Text = new Common.Utilities().FormatMoney(Double.Parse(tigia[i].Giatri2.ToString()));
                    }
                    else
                    { continue; }
                }
            }
            catch { }
        }

        private void toolStripStatusLabel2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (lbtinhtrang.Text == "Chưa thanh toán hết")
                {
                    frmXuLyPhieuTTNCC frm = new frmXuLyPhieuTTNCC(thanhtoan);
                    frm.ShowDialog();
                }
            }
            catch { }
        }

        private void chekChonLoai_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dgvInsertOrder.DataSource = null;
                Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgvInsertOrder.DataSource = lay;
                DoiTen(dgvInsertOrder);
                format();
            }
            catch { }
        }
        private void txtManhacungcap_MouseHover(object sender, EventArgs e)
        {
            try
            {
                if (hanhdong == "Insert")
                {
                    if (txtManhacungcap.Text == "<F4 -Tra cứu>")
                    {
                        txtManhacungcap.Text = "";
                        txtManhacungcap.Focus();
                    }
                }
            }
            catch { }
        }

        private void txtManhacungcap_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (hanhdong == "Insert")
                {
                    if (txtManhacungcap.Text == "")
                    {
                        txtManhacungcap.Text = "<F4 -Tra cứu>";
                        txtManhacungcap.Focus();
                    }
                }
            }
            catch { }
        }

        private void txtMadondathang_MouseHover(object sender, EventArgs e)
        {
            try
            {
                if (txtMadondathang.Text == "<F4 -Tra cứu>")
                {
                    txtMadondathang.Text = "";
                }
            }
            catch { }
        }

        private void txtMadondathang_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (txtMadondathang.Text == "")
                {
                    txtMadondathang.Text = "<F4 -Tra cứu>";
                }
            }
            catch { }
        }
        private void dgvInsertOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                i = e.RowIndex;
                if (i < 0)
                    dgvInsertOrder.Rows[0].Selected = true;
            }
            catch { }
        }
        private void dgvInsertOrder_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (chekChonLoai.Checked == false)
                {
                    getDataTable(dgvInsertOrder);
                    if (dgvInsertOrder.RowCount > 0)
                    {
                        TinhToan();
                        if (txtTongThanhToan.Text != "0")
                        {
                            fixTienTraLai();
                        }
                        else
                        { reset(); }
                    }
                    else
                    {
                        reset();
                    }
                }
                if (chekChonLoai.Checked == true)
                {
                    LayThongTinHang(dgvInsertOrder);
                }
            }
            catch { }
        }
        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (toolStrip_txtSoluong.Text != "")
                {
                    ThemVao();
                    txtTienTraLai.Text = capnhat();
                    toolStrip_txtTracuu.Focus();
                }
                else
                { MessageBox.Show("Nhập số lượng"); toolStrip_txtSoluong.Focus(); }
            }
            catch { }
        }

        private void toolStrip_txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void toolStrip_txtGiagoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void toolStrip_txtChietkhauphantram_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void toolStrip_txtGianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void toolStrip_txtChietkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void toolStrip_txtChietkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (float.Parse(0 + toolStrip_txtChietkhauphantram.Text) == (float.Parse(0 + toolStrip_txtGiagoc.Text)))
            {
                toolStrip_txtGianhap.Text = "0";
            }
        }

        private void toolStrip_txtSoluong_TextChanged(object sender, EventArgs e)
        {
            if (toolStrip_txtSoluong.Text.Length > 5 || toolStrip_txtSoluong.Text == "0")
            {
                toolStrip_txtSoluong.Text = "1";
            }
            if (toolStrip_txtSoluong.Text.Length == 1 && toolStrip_txtSoluong.Text == "0")
            {
                toolStrip_txtSoluong.Text = "1";
            }
        }

        private void txtGiatrigiatang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtThanhtoanngay_KeyPress(object sender, KeyPressEventArgs e)
        {
            //
        }

        private void txtMadondathang_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (chekChonLoai.Checked == true)
                {
                    ngaythangnam = "KhongCo";
                    if (hanhdong == "Insert")
                    {
                        if (txtManhacungcap.Text != "<F4 -Tra cứu>" && txtManhacungcap.Text != "")
                        {
                            GiaTriCanLuu.Ma = null;
                            GiaTriCanLuu.Ten = null;
                            GiaTriCanLuu.Giatri = null;
                            dgvInsertOrder.DataSource = null;
                            Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                            dgvInsertOrder.DataSource = lay;
                            DoiTen(dgvInsertOrder);
                            reset();
                            frmTraCuu fr = new frmTraCuu("HoaDonNhap_MaDonDatHang", "MaDonDatHang", txtManhacungcap.Text);
                            fr.ShowDialog();
                            BindHangHoa();
                            if (GiaTriCanLuu.Ma.Length <= 0)
                            { txtMadondathang.Text = "<F4 -Tra cứu>"; }
                            if (dgvInsertOrder.RowCount > 0)
                            { TinhToan(); }
                            else
                            { reset(); }
                            ngaythangnam = "";
                        }
                        else
                        { MessageBox.Show("Nhập mã nhà cung cấp"); }
                    }
                }
            }
            catch { }
        }

        private void txtManhacungcap_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (hanhdong == "Insert")
                {
                    GiaTriCanLuu.Ma = null;
                    GiaTriCanLuu.Ten = null;
                    GiaTriCanLuu.TonKho = null;
                    dgvInsertOrder.DataSource = null;
                    Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                    dgvInsertOrder.DataSource = lay;
                    DoiTen(dgvInsertOrder);
                    reset();
                    frmTraCuu frm = new frmTraCuu("HoaDonNhap_NhaCungCap", "HoaDonNhap");
                    frm.ShowDialog();
                    BindHangHoa();
                    if (GiaTriCanLuu.Ma == null)
                    { txtManhacungcap.Text = "<F4 -Tra cứu>"; }
                    if (txtNohienthoi.Text.Length <= 0)
                    { txtNohienthoi.Text = "0"; }
                }
            }
            catch { }
        }
        private void toolStripStatus_In_Click(object sender, EventArgs e)
        {
            try
            {
                InThongTinDonHang();
            }
            catch { }
        }

        private void toolStripStatus_Thanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                frmXuLyPhieuTTNCC pt = new frmXuLyPhieuTTNCC(hoa);
                pt.ShowDialog();
                this.Close();
            }
            catch { }
        }

        private void toolStrip_txtSoluong_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (hanhdong == "Insert")
                {
                    if (chekChonLoai.Checked == false)
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (int.Parse(0 + toolStrip_txtSoluong.Text) > 0)
                            {
                                toolStrip_txtChietkhauphantram.Text = "0";
                                toolStrip_txtChietkhauphantram.Focus();
                            }
                            else
                            { toolStrip_txtSoluong.Focus(); }
                        }
                        if (e.KeyCode == Keys.F6)
                        {
                            if (dgvInsertOrder.RowCount > 0)
                            {
                                this.dgvInsertOrder.Focus();
                                dgvInsertOrder.CurrentRow.Selected = true;
                            }
                            else
                            { MessageBox.Show("Không có hàng để sửa"); toolStrip_txtTracuu.Focus(); }
                        }
                        if (e.KeyCode == Keys.F3)
                        {
                            txtThanhtoanngay.Focus();
                        }
                    }
                }
            }
            catch { }
        }

        private void toolStrip_txtTracuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (chekChonLoai.Checked == false)
                {
                    ResetTool();
                    toolStrip_txtTracuu.Text = "";
                }
            }
            catch { }
        }

        private void toolStrip_txtChietkhauphantram_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (hanhdong == "Insert")
                {
                    if (chekChonLoai.Checked == false)
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (toolStrip_txtChietkhauphantram.Text != "")
                            {
                                toolStrip_txtNgayhethan.Focus();
                            }
                            else
                            { toolStrip_txtChietkhauphantram.Focus(); }
                        }
                        if (e.KeyCode == Keys.F6)
                        {
                            if (dgvInsertOrder.RowCount > 0)
                            {
                                this.dgvInsertOrder.Focus();
                                dgvInsertOrder.CurrentRow.Selected = true;
                            }
                            else
                            { MessageBox.Show("Không có hàng để sửa"); toolStrip_txtTracuu.Focus(); }
                        }
                        if (e.KeyCode == Keys.F3)
                        {
                            txtThanhtoanngay.Focus();
                        }
                    }
                }
            }
            catch { }
        }

        private void toolStrip_txtSoluong_Click(object sender, EventArgs e)
        {
            try
            {
                if (chekChonLoai.Checked == false)
                {
                    checks();
                }
            }
            catch { }
        }

        private void toolStrip_txtNgayhethan_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (hanhdong == "Insert")
                {
                    if (chekChonLoai.Checked == false)
                    {
                        if (e.KeyCode == Keys.Enter)
                        {
                            if (toolStrip_txtNgayhethan.Text != "")
                            {
                                ThemVao();
                                toolStrip_txtTracuu.Focus();
                            }
                            else
                            { toolStrip_txtNgayhethan.Focus(); }
                        }
                        if (e.KeyCode == Keys.F6)
                        {
                            if (dgvInsertOrder.RowCount > 0)
                            {
                                this.dgvInsertOrder.Focus();
                                dgvInsertOrder.CurrentRow.Selected = true;
                            }
                            else
                            { MessageBox.Show("Không có hàng để sửa"); toolStrip_txtTracuu.Focus(); }
                        }
                        if (e.KeyCode == Keys.F3)
                        {
                            txtThanhtoanngay.Focus();
                        }
                    }
                }
                if (chekChonLoai.Checked == true)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        string MaHangHoa = toolStrip_txtTracuu.Text;
                        Common.Utilities ck = new Common.Utilities();
                        string ngay = toolStrip_txtNgayhethan.Text;
                        string ngayhientai = this.Date.ToString("dd/MM/yyyy");
                        if (toolStrip_txtTracuu.Text.Length > 0)
                        {
                            bool tempKQ1 = false; bool tempKQ2 = false;
                            DateTime Nhientai = Utils.StringToDateTime(ngayhientai, out tempKQ1);
                            DateTime Nngay = Utils.StringToDateTime(ngay, out tempKQ2);
                            if (!tempKQ1 || !tempKQ2)
                            {
                                MessageBox.Show("Ngày Không Hợp Lệ!"); txtTygia.Focus(); return;
                            }
                            if (Nhientai <= Nngay)
                            {
                                LuuNgayHetHan(dgvInsertOrder, MaHangHoa, ngay);
                                ResetTool();
                            }
                            else
                            {
                                MessageBox.Show("Kiểm tra lại định dạng ngày hết hạn <dd/MM/yyyy>"); txtTygia.Focus(); return;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void txtThanhtoanngay_Click(object sender, EventArgs e)
        {
            txtThanhtoanngay.Text = "";
        }

        private void txtCKTM_Click(object sender, EventArgs e)
        {
            txtCKTM.Text = "";
            txtTienCKTM.Text = "0";
        }

        private void toolStrip_txtChietkhauphantram_Click(object sender, EventArgs e)
        {
            if (chekChonLoai.Checked == false)
            {
                toolStrip_txtChietkhauphantram.Text = "";
                toolStrip_txtGianhap.Text = "0";
                toolStrip_Chietkhau.Text = "0";
            }
        }

        private void toolStrip_txtTracuu_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (hanhdong == "Insert")
                {
                    if (chekChonLoai.Checked == false)
                    {
                        if (testCharacter(toolStrip_txtTracuu.Text) == false)
                        { return; }

                        if (e.KeyCode == Keys.Enter)
                        {
                            if (toolStrip_txtTracuu.Text != "" && toolStrip_txtTracuu.Text != "<F4 - Tra cứu>")
                            {
                                LayHangHoaTheoMa(toolStrip_txtTracuu.Text);
                            }
                            if (string.IsNullOrEmpty(toolStrip_txtTenhang.Text) && toolStrip_txtTracuu.Text != "<F4 - Tra cứu>")
                            {
                                toolStrip_txtTracuu.Focus();
                                frmXuLyHangHoa fr = new frmXuLyHangHoa("Insert");
                                fr.StartPosition = FormStartPosition.CenterScreen;
                                fr.ShowDialog();
                            }
                        }
                        if (e.KeyCode == Keys.F6)
                        {
                            if (dgvInsertOrder.RowCount > 0)
                            {
                                this.dgvInsertOrder.Focus();
                                dgvInsertOrder.CurrentRow.Selected = true;
                            }
                            else
                            { MessageBox.Show("Không có hàng để sửa"); toolStrip_txtTracuu.Focus(); }
                        }
                        if (e.KeyCode == Keys.F3)
                        {
                            txtThanhtoanngay.Focus();
                        }
                    }
                }
            }
            catch { }
        }

        private void dgvInsertOrder_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                i = dgvInsertOrder.CurrentRow.Index;
            }
            catch (Exception)
            { }
        }

        private void dgvInsertOrder_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (i >= 0)
                    {
                        if (chekChonLoai.Checked == false)
                        {
                            getDataTable(dgvInsertOrder);
                            if (dgvInsertOrder.RowCount > 0)
                            {
                                TinhToan();
                                if (txtTongThanhToan.Text != "0")
                                {
                                    fixTienTraLai();
                                }
                                else
                                { reset(); }
                            }
                            else
                            {
                                reset();
                            }
                        }
                        toolStrip_txtSoluong.Focus();
                    }
                }
            }
            catch { }
        }
        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmQuanLyNhapKho.BaoDong = "A";
                        this.Close();
                    }
                }
            }
            catch { }
        }
        private string makiemtra = "";
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtManhacungcap.Text != "<F4 - Tra cứu>")
                {
                    getID("HoaDonNhap");
                    if (txtSodonhang.Text == makiemtra)
                    {
                        if (kiemtrangaytrong_dgv(dgvInsertOrder) == 1)
                        {
                            if (txtThanhtoanngay.Text == "")
                                txtThanhtoanngay.Text = "0";
                            XuLy_HoaDonNhap("Insert");
                        }
                        else
                        { MessageBox.Show("Phải nhập ngày hết hạn cho hàng hóa"); }
                    }
                    else
                    { txtSodonhang.Text = makiemtra; MessageBox.Show("Mã hóa đơn đã thay đổi"); }
                }
                else
                { MessageBox.Show("Nhập mã nhà cung cấp"); }
            }
            catch { }
        }
        private string fixTen(string chuoi)
        {
            string tra = "";
            try
            {
                if (chuoi.Length >= 20)
                {
                    tra = chuoi.Substring(0, 17) + "...";
                }
                else
                {
                    tra = chuoi;
                }
            }
            catch { return chuoi; }
            return tra;
        }
        private void btnTimnhacungcap_Click(object sender, EventArgs e)
        {
            try
            {
                if (hanhdong == "Insert")
                {
                    GiaTriCanLuu.Ma = null;
                    GiaTriCanLuu.Ten = null;
                    GiaTriCanLuu.TonKho = null;
                    dgvInsertOrder.DataSource = null;
                    Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                    dgvInsertOrder.DataSource = lay;
                    DoiTen(dgvInsertOrder);
                    reset();
                    frmTraCuu frm = new frmTraCuu("HoaDonNhap_NhaCungCap", "HoaDonNhap");
                    frm.ShowDialog();
                    BindHangHoa();
                    if (GiaTriCanLuu.Ma == null)
                    { txtManhacungcap.Text = "<F4 -Tra cứu>"; }
                    if (txtNohienthoi.Text.Length <= 0)
                    { txtNohienthoi.Text = "0"; }
                }
            }
            catch { }
        }
        private Boolean KiemTraTrangThaiDonDatHang(string madondathang)
        {
            Boolean bl = false;
            try
            {
                Entities.TruyenGiaTri dat = new Entities.TruyenGiaTri();
                dat.Hanhdong = "Select";
                dat.Giatritruyen = "ThanhCong";
                dat.Giatrithuhai = madondathang;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "KiemTraDonDatHang", dat);
                Entities.TruyenGiaTri ddh = new Entities.TruyenGiaTri();
                ddh = (Entities.TruyenGiaTri)cl.DeserializeHepper(clientstrem, ddh);
                if (ddh.Giatritruyen == "Yes")
                { bl = true; }
                else { bl = false; }
            }
            catch { bl = false; }
            return bl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (chekChonLoai.Checked == true)
                {
                    ngaythangnam = "KhongCo";
                    if (hanhdong == "Insert")
                    {
                        if (txtManhacungcap.Text != "<F4 -Tra cứu>" && txtManhacungcap.Text != "")
                        {
                            GiaTriCanLuu.Ma = null;
                            GiaTriCanLuu.Ten = null;
                            GiaTriCanLuu.Giatri = null;
                            dgvInsertOrder.DataSource = null;
                            Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                            dgvInsertOrder.DataSource = lay;
                            DoiTen(dgvInsertOrder);
                            reset();
                            frmTraCuu fr = new frmTraCuu("HoaDonNhap_MaDonDatHang", "MaDonDatHang", txtManhacungcap.Text);
                            fr.ShowDialog();
                            BindHangHoa();
                            if (GiaTriCanLuu.Ma.Length <= 0)
                            { txtMadondathang.Text = "<F4 -Tra cứu>"; }
                            if (dgvInsertOrder.RowCount > 0)
                            { TinhToan(); txtTienTraLai.Text = "0"; }
                            else
                            { reset(); }
                            ngaythangnam = "";
                        }
                        else
                        { MessageBox.Show("Nhập mã nhà cung cấp"); }
                    }
                }
            }
            catch { }
        }
        private void toolStrip_txtTracuu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (hanhdong == "Insert")
                {
                    if (chekChonLoai.Checked == false)
                    {
                        GiaTriCanLuu.Ma = null;
                        GiaTriCanLuu.Ten = null;
                        GiaTriCanLuu.TonKho = null;
                        GiaTriCanLuu.Giatri = null;
                        GiaTriCanLuu.giatrigiatang = null;
                        if (txtManhacungcap.Text != "" && txtManhacungcap.Text != "<F4 -Tra cứu>")
                        {
                            if (cbxKhoHang.SelectedValue.ToString().Length > 0)
                            {
                                if (e.KeyCode == Keys.F4)
                                {
                                    frmTraCuu fr = new frmTraCuu("HoaDonDat_HangHoa", "HoaDonHangHoa");
                                    fr.ShowDialog();
                                    BindHangHoa();
                                }
                            }
                            else
                            { MessageBox.Show("Nhập mã kho hàng"); }
                        }
                        else
                        { MessageBox.Show("Nhập mã nhà cung cấp"); }
                    }
                }
            }
            catch { }
        }
        #endregion

        private void MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        /////////////////////////////////////////////////////////////////MRk FIX
        bool CoPhaiLaMaQuyDoiHayKhong(string ma)
        {
            bool kq = false;
            foreach (Entities.QuyDoiDonViTinh item in dsQuyDoiDonViTinh)
            {
                if (item.MaHangQuyDoi.Equals(ma))
                {
                    kq = true;
                    break;
                }
            }
            return kq;
        }

        //FIX Triết khấu theo tổng hóa đơn
        private void txtCKTM0_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (hanhdong == "Insert")
                {
                    if (!string.IsNullOrEmpty(txtCKTM0.Text))
                    {
                        if (dgvInsertOrder.RowCount > 0)
                        {
                            if (txtCKTM0.Text.Length <= 2)
                            {
                                txtCKTM0.Text = new Common.Utilities().loc(txtCKTM0.Text);
                                txtCKTMs0();
                            }
                            else
                            { txtCKTMs0(); }
                        }
                        else
                        { reset(); ResetTool(); }
                    }
                    else
                    { txtTienCKTM0.Text = "0"; }
                    string tem = Math.Round((Double.Parse(new Common.Utilities().KhongDau(txtChietkhau.Text)) + Double.Parse(new Common.Utilities().KhongDau(txtGiatrigiatang.Text))) - Double.Parse(new Common.Utilities().KhongDau(txtTienCKTM0.Text))).ToString();
                    txtTongThanhToan.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(tem)));
                }
            }
            catch { }
        }

        private void txtCKTM0_Click(object sender, EventArgs e)
        {
            txtCKTM0.Text = string.Empty;
            txtTienCKTM0.Text = "0";
        }

        private void txtCKTMs0()
        {
            try
            {
                if (dgvInsertOrder.RowCount > 0)
                {
                    if (Double.Parse(txtCKTM0.Text) > 100)
                    {
                        txtCKTM0.Text = "0";
                        txtTienCKTM0.Text = "0";
                        string tem = Math.Round((Double.Parse(new Common.Utilities().KhongDau(txtChietkhau.Text)) + Double.Parse(new Common.Utilities().KhongDau(txtGiatrigiatang.Text))) - Double.Parse(new Common.Utilities().KhongDau(txtTienCKTM0.Text))).ToString();
                        txtTongThanhToan.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(tem)));
                    }
                    else
                    {
                        if (txtCKTM0.Text == "" || txtCKTM0.Text == "0")
                        {
                            txtTienCKTM0.Text = "0";
                            string tem = Math.Round((Double.Parse(new Common.Utilities().KhongDau(txtChietkhau.Text)) + Double.Parse(new Common.Utilities().KhongDau(txtGiatrigiatang.Text))) - Double.Parse(new Common.Utilities().KhongDau(txtTienCKTM0.Text))).ToString();
                            txtTongThanhToan.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(tem)));
                        }
                        else
                        {
                            if (txtCKTM0.Text == "100")
                            {
                                txtTongThanhToan.Text = "0";
                            }
                            else
                            {
                                string tem0 = Math.Round(((Double.Parse(new Common.Utilities().KhongDau(txtChietkhau.Text)) + Double.Parse(new Common.Utilities().KhongDau(txtGiatrigiatang.Text))) * Double.Parse(txtCKTM0.Text)) / 100).ToString();
                                txtTienCKTM0.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(tem0)));
                                string tem = Math.Round((Double.Parse(new Common.Utilities().KhongDau(txtChietkhau.Text)) + Double.Parse(new Common.Utilities().KhongDau(txtGiatrigiatang.Text))) - Double.Parse(new Common.Utilities().KhongDau(txtTienCKTM0.Text))).ToString();
                                txtTongThanhToan.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(tem)));
                            }
                        }
                    }
                    txtTienTraLai.Text = "0";
                    txtThanhtoanngay.Text = "0";
                }
                else
                { reset(); }
            }
            catch { }
        }

        private void txtThanhtoanngay_KeyDown(object sender, KeyEventArgs e)
        {
            Thems(e);
        }

        private void txtMadondathang_TextChanged(object sender, EventArgs e)
        {
            txtThanhtoanngay.Focus();
        }
        ////////////////////////////////////////////////////////////////////////////

        #region Utils Function (K)
        bool checkQuyDoiDonViTinh(string MaHangHoa, out Entities.QuyDoiDonViTinh input)
        {
            input = new Entities.QuyDoiDonViTinh();
            foreach (Entities.QuyDoiDonViTinh item in dsQuyDoiDonViTinh)
            {
                if (item.MaHangQuyDoi.Equals(MaHangHoa)) { input = item; return true; }
            }
            return false;
        }
        #endregion

        private void toolStripStatus_InMaVach_Click(object sender, EventArgs e)
        {
            try
            {
                //Kiểm tra danh sách hàng hóa trong dgvInsertOrder
                if (dgvInsertOrder.Rows.Count <= 0) return;
                //chuyển danh sách về List<ThongTinMaVach>
                List<ThongTinMaVach> dsThongTinMaVach = new List<ThongTinMaVach>();
                for (int j = 0; j < dgvInsertOrder.Rows.Count; j++)
                {
                    string maHangHoa = dgvInsertOrder["MaHangHoa", j].Value.ToString();
                    string tenHangHoa = dgvInsertOrder["TenHangHoa", j].Value.ToString();
                    double gianhap = double.Parse(dgvInsertOrder["GiaNhap", j].Value.ToString());
                    double giabanbuon = double.Parse(dgvInsertOrder["GiaBanBuon", j].Value.ToString());
                    double giabanle = double.Parse(dgvInsertOrder["GiaBanLe", j].Value.ToString());
                    double soluong = double.Parse(dgvInsertOrder["SoLuongDat", j].Value.ToString());
                    dsThongTinMaVach.Add(new ThongTinMaVach
                    {
                        MaHangHoa = maHangHoa,
                        TenHangHoa = tenHangHoa,
                        GiaNhap = gianhap.ToString(),
                        GiaBanBuon = giabanbuon.ToString(),
                        GiaBanLe = giabanle.ToString(),
                        GhiChu = soluong.ToString()
                    });
                }
                //Gọi Form "In Mã Vạch"
                new frmQuanLyMaVach(dsThongTinMaVach).ShowDialog();
            }
            catch { }
        }
    }
}








