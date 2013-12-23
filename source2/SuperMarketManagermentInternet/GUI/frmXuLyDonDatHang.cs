#region
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Collections;

namespace GUI
{
    public partial class frmXuLyDonDatHang : Form
    {
        #region *******************************************Vương Hùng*************************************************
        #region ==============================================================================================================
        public frmXuLyDonDatHang()
        {

            InitializeComponent();
        }

        private Entities.DonDatHang dathang;
        public Entities.DonDatHang Dathang
        {
            get { return dathang; }
            set { dathang = value; }
        }

        public frmXuLyDonDatHang(string hanhdong, Entities.DonDatHang dathang)
        {
            InitializeComponent();
            this.hanhDong = hanhdong;
            this.dathang = dathang;
        }
        private string hanhDong;
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        public frmXuLyDonDatHang(string kiemtra)
        {
            InitializeComponent();
            this.HanhDong = kiemtra;
        }

        private string maNhaCungCap;
        public string MaNhaCungCap
        {
            get { return maNhaCungCap; }
            set { maNhaCungCap = value; }
        }
        private string tenNhaCungCap;
        public string TenNhaCungCap
        {
            get { return tenNhaCungCap; }
            set { tenNhaCungCap = value; }
        }
        public frmXuLyDonDatHang(string manhacungcap, string tennhacungcap)
        {
            InitializeComponent();
            this.maNhaCungCap = manhacungcap;
            this.tenNhaCungCap = tennhacungcap;
        }
        #endregion

        #region ==============================================================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        DateTime datesv;
        #endregion

        #region ==============================================================================================================
        /// <summary>
        /// tu tang ID
        /// </summary>
        private string makiemtra = "";
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
                if (ddh.ID.Length > 0)
                {
                    string chuoi = ddh.ID.ToString();
                    Common.Utilities com = new Common.Utilities();
                    makiemtra = com.ProcessID(chuoi);
                }
                else
                {
                    makiemtra = "DDH_0001";
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                makiemtra = "DDH_0001";
            }

        }

        /// <summary>
        /// hungvv =======================khong su dung ham nay===========================
        /// </summary>
        private void Select_ChiTietDonDatHang()
        {
            try
            {
                Entities.ChiTietDonDatHang ctdh = new Entities.ChiTietDonDatHang();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                ctdh = new Entities.ChiTietDonDatHang("Select");
                clientstrem = cl.SerializeObj(this.client, "ChiTietDonDatHang", ctdh);
                Entities.ChiTietDonDatHang[] ddh = new Entities.ChiTietDonDatHang[1];
                ddh = (Entities.ChiTietDonDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length > 0)
                {
                    dgvInsertOrder.DataSource = ddh;
                }
                else
                {
                    Entities.ChiTietDonDatHang[] lay = new Entities.ChiTietDonDatHang[0];
                    dgvInsertOrder.DataSource = lay;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }

        }
        /// <summary>
        /// do du lieu vao dgv
        /// </summary>
        private void DoiTen(DataGridView dgv)
        {
            try
            {
                dgv.RowHeadersVisible = false;
                dgv.Columns[0].Visible = false;
                dgv.Columns[1].HeaderText = "Mã hàng";
                dgv.Columns[1].ToolTipText = "Mã hàng hóa";
                dgv.Columns[2].HeaderText = "Tên hàng";
                dgv.Columns[2].ToolTipText = "Tên hàng hóa";
                dgv.Columns[3].HeaderText = "Số Lượng";
                dgv.Columns[3].ToolTipText = "Số lượng đặt hàng";
                dgv.Columns[4].HeaderText = "Đơn giá";
                dgv.Columns[4].ToolTipText = "Giá gốc của nhà cung cấp";
                dgv.Columns[5].Visible = false;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].HeaderText = "Chiết khấu(%) của NCC";
                dgv.Columns[7].ToolTipText = "chiết khấu của nhà cung cấp khi mua hàng";
                dgv.Columns[8].HeaderText = "Thuế(GTGT)";
                dgv.Columns[8].ToolTipText = "thuế giá trị gia tăng(%)";
                dgv.Columns[9].HeaderText = "Thành Tiền(đã C/K)";
                dgv.Columns[9].ToolTipText = "Tổng tiền đã chiết khấu của mặt hàng này(chưa có thuế GTGT)";
                dgv.Columns[10].Visible = false;
                dgv.Columns[11].HeaderText = "Thành Tiền(chưa C/K)";
                dgv.Columns[11].ToolTipText = "Tổng tiền chưa chiết khấu của mặt hàng này(chưa có thuế GTGT)";
                dgv.Columns[12].Visible = false;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
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
                dat.Giatritruyen = txtSodonhang.Text;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "HienThi_ChiTiet_DonDatHang", dat);
                Entities.HienThi_ChiTiet_DonDatHang[] ddh = new Entities.HienThi_ChiTiet_DonDatHang[1];
                ddh = (Entities.HienThi_ChiTiet_DonDatHang[])cl.DeserializeHepper(clientstrem, ddh);
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
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgvInsertOrder.DataSource = lay;
                DoiTen(dgvInsertOrder);
            }

        }
        /// <summary>
        /// xu ly du lieu
        /// </summary>
        /// <param name="chitiet"></param>

        private void XuLyChiTietDonDatHang(Entities.HienThi_ChiTiet_DonDatHang[] chitiet)
        {
            try
            {
                if (chitiet.Length > 0)
                {
                    Entities.HienThi_ChiTiet_DonDatHang[] giatri = null;
                    ArrayList arr = new ArrayList();
                    for (int i = 0; i < chitiet.Length; i++)
                    {
                        Entities.HienThi_ChiTiet_DonDatHang row = new Entities.HienThi_ChiTiet_DonDatHang();
                        row.MaHangHoa = chitiet[i].MaHangHoa;

                        row.TenHangHoa = chitiet[i].TenHangHoa;
                        row.SoLuongDat = chitiet[i].SoLuongDat;
                        row.GiaGoc = new Common.Utilities().FormatMoney(Double.Parse(chitiet[i].GiaGoc));
                        row.Giabanbuon = new Common.Utilities().FormatMoney(Double.Parse(chitiet[i].Giabanbuon));
                        row.Giabanle = new Common.Utilities().FormatMoney(Double.Parse(chitiet[i].Giabanle));
                        string phantram = chitiet[i].PhanTramChietKhau;
                        string gianhap = "0";
                        if (phantram == "0")
                        {
                            gianhap = new Common.Utilities().FormatMoney(Double.Parse(chitiet[i].GiaGoc) * Double.Parse(chitiet[i].SoLuongDat.ToString()));
                        }
                        else
                        {
                            gianhap = new Common.Utilities().FormatMoney((Double.Parse(chitiet[i].GiaGoc) * Double.Parse(chitiet[i].SoLuongDat.ToString())) - ((Double.Parse(chitiet[i].PhanTramChietKhau) / 100 * Double.Parse(chitiet[i].GiaGoc) * Double.Parse(chitiet[i].SoLuongDat.ToString()))));
                        }
                        row.PhanTramChietKhau = phantram;
                        row.Thuegiatrigiatang = chitiet[i].Thuegiatrigiatang;
                        row.GiaNhap = gianhap;
                        row.TongTien = new Common.Utilities().FormatMoney(Double.Parse(chitiet[i].GiaGoc) * Double.Parse(chitiet[i].SoLuongDat.ToString()));
                        arr.Add(row);

                    }
                    int n = arr.Count;
                    if (n == 0) { giatri = null; }
                    giatri = new Entities.HienThi_ChiTiet_DonDatHang[n];
                    for (int i = 0; i < n; i++)
                    {
                        giatri[i] = (Entities.HienThi_ChiTiet_DonDatHang)arr[i];
                    }
                    dgvInsertOrder.DataSource = null;
                    dgvInsertOrder.DataSource = giatri;
                    DoiTen(dgvInsertOrder);
                }
                else
                {
                    dgvInsertOrder.DataSource = chitiet;
                    DoiTen(dgvInsertOrder);
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); MessageBox.Show(s); }
        }
        #endregion

        #region ==============================================================================================================
        /// <summary>
        ///  Lấy Kho Hàng===============ham nay khong dung========================
        /// </summary>
        private void LayKhoHang()
        {
            try
            {
                cbxMaKho.Items.Clear();
                Entities.KiemTraChung kh = new Entities.KiemTraChung();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                kh = new Entities.KiemTraChung("Select", "KhoHang", "MaKho", "TenKho");
                clientstrem = cl.SerializeObj(this.client, "LayCombox", kh);
                Entities.KiemTraChung[] ddh = new Entities.KiemTraChung[1];
                ddh = (Entities.KiemTraChung[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length > 0)
                {
                    Common.Utilities com = new Common.Utilities();
                    com.BindingCombobox(ddh, cbxMaKho, "giatri", "khoachinh");
                }
                else
                { cbxMaKho.Items.Clear(); }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        /// <summary>
        /// Lấy tên tiền tệ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static Entities.KiemTraChung[] tigia;
        private void LayTenTT()
        {
            try
            {
                cbxTiente_Tygia.Items.Clear();
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
                    com.BindingCombobox(tt, cbxTiente_Tygia, "giatri", "khoachinh");
                }
                else
                { cbxTiente_Tygia.Text = ""; cbxTiente_Tygia.Items.Clear(); }
            }
            catch (Exception ex)
            {
                cbxTiente_Tygia.Items.Clear();
                cbxTiente_Tygia.Text = "";
                string s = ex.Message.ToString();
            }
        }

        /// <summary>
        /// Lấy nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LayNhanVien()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KiemTraChung tt1 = new Entities.KiemTraChung();
                tt1 = new Entities.KiemTraChung("Select", "NhanVien", "MaNhanVien", "TenNhanVien");
                clientstrem = cl.SerializeObj(this.client, "LayCombox", tt1);
                Entities.KiemTraChung[] tt = new Entities.KiemTraChung[1];
                tt = (Entities.KiemTraChung[])cl.DeserializeHepper1(clientstrem, tt);
                client.Close();
                clientstrem.Close();
                if (tt.Length > 0)
                {
                    Common.Utilities com = new Common.Utilities();
                    com.BindingCombobox(tt, cbxNhanvien, "giatri", "khoachinh");
                }
                else
                { cbxNhanvien.Items.Clear(); }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                cbxNhanvien.Items.Clear();
            }
        }

        #endregion

        #region ==============================================================================================================
        /// <summary>
        /// add ban ghi --------------------------------hungvv-----------------------------
        /// </summary>
        /// <param name="dgv"></param>
        private Entities.ChiTietDonDatHang[] LuuChiTietHangHoaTheoDonDatHang(DataGridView dgv, string hanhdong, string madondathang)
        {
            Entities.ChiTietDonDatHang[] mangBanghi = null;
            ArrayList arr = new ArrayList();
            try
            {
                int i = dgv.RowCount;
                if (i > 0)
                {
                    for (int x = 0; x < i; x++)
                    {
                        Entities.ChiTietDonDatHang banghi = new Entities.ChiTietDonDatHang();
                        banghi.Hanhdong = hanhdong;
                        banghi.MaDonDatHang = madondathang.ToUpper();
                        banghi.MaHangHoa = dgv.Rows[x].Cells[1].Value.ToString();
                        banghi.TenHangHoa = dgv.Rows[x].Cells["TenHangHoa"].Value.ToString();
                        banghi.SoLuong = int.Parse(0 + dgv.Rows[x].Cells[3].Value.ToString());
                        banghi.DonGia = (0 + dgv.Rows[x].Cells["GiaGoc"].Value.ToString()).ToString();
                        banghi.Thue = (0 + dgv.Rows[x].Cells["Thuegiatrigiatang"].Value.ToString()).ToString();
                        banghi.PhanTramChietKhau = int.Parse(0 + dgv.Rows[x].Cells[7].Value.ToString()).ToString();
                        banghi.GhiChu = "" + txtDiengiai.Text.ToString();
                        banghi.Deleted = false;
                        arr.Add(banghi);
                    }
                    int n = arr.Count;
                    if (n == 0) { return null; }
                    mangBanghi = new Entities.ChiTietDonDatHang[n];
                    for (int j = 0; j < n; j++)
                    {
                        mangBanghi[j] = (Entities.ChiTietDonDatHang)arr[j];
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
        /// <summary>
        /// xoa hang hoa theo don dat hang
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
        /// save
        /// </summary>
        private void LuuChiTietDonHang()
        {
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            if (XoaTheoHoaDon("DonDatHang", txtSodonhang.Text.ToUpper()) != 0)
            {
                Entities.ChiTietDonDatHang[] luu = LuuChiTietHangHoaTheoDonDatHang(dgvInsertOrder, "Insert", txtSodonhang.Text.ToUpper());
                clientstrem = cl.SerializeHepper(this.client, "ChiTietDonDatHang", luu);
                int bao = 0;
                bao = (int)cl.DeserializeHepper(clientstrem, bao);
                if (bao == 0)
                { DeleteData(txtSodonhang.Text); MessageBox.Show("Thất bại"); }
                else
                {
                    this.Close();
                }
            }
            else
            { MessageBox.Show("Chưa thêm hàng hóa vào đơn hàng này"); }
        }

        /// <summary>
        /// them moi, sua thong tin don dat hang
        /// </summary>
        /// <param name="hanhdong"></param>
        private static int ID = 0;
        private string manhacungcap = "";
        private string makhachhang = "";
        private void kiemtrama(CheckBox c, string a, string b)
        {
            if (a.ToUpper() != "<F4 - TRA CỨU" && b.ToUpper() != "<F4 - TRA CỨU" && a != "" && b != "")
            {
                if (c.Checked == true)
                { manhacungcap = a; makhachhang = ""; }
                else
                { manhacungcap = ""; }
                if (c.Checked == false)
                { makhachhang = b; manhacungcap = ""; }
                else
                { makhachhang = ""; }
            }
            else
            { MessageBox.Show("Kiểm tra lại mã nhà cung cấp hoặc mã khách hàng"); }
        }

        /// <summary>
        /// xu ly don dat hang
        /// </summary>
        /// <param name="hanhdong"></param>
        private void XuLy_DonDatHang(string hanhdong)
        {
            try
            {
                Entities.DonDatHang don = new Entities.DonDatHang();
                Common.Utilities ck = new Common.Utilities();
                string thoigian_1 = makNgaydonhang.Text;
                string thoigian_2 = makNgaynhapdukien.Text;
                string thoigian_sosanh = DateServer.Date().ToString("dd/MM/yyyy");
                if (ck.SoSanhNgay('/', ">=", thoigian_1, thoigian_sosanh) == true && thoigian_1 != null && thoigian_2 != null && ck.SoSanhNgay('/', ">=", thoigian_2, thoigian_sosanh) == true)
                {
                    kiemtrama(check_loaidathang, txtManhacungcap.Text, txtManhacungcap.Text);
                    bool temp = false;
                    don.NgayDonHang = Utils.StringToDateTime(thoigian_1, out temp);
                    //don.NgayDonHang = DateTime.Parse(new Common.Utilities().KiemTraDinhDangNgayThangNam("ThangNgayNam", thoigian_1, '/'));
                    don.NgayNhapDuKien = Utils.StringToDateTime(thoigian_2, out temp);
                    //don.NgayNhapDuKien = DateTime.Parse(new Common.Utilities().KiemTraDinhDangNgayThangNam("ThangNgayNam", thoigian_2, '/'));
                    don.Hanhdong = hanhdong;
                    don.DonDatHangID = ID;
                    don.MaDonDatHang = "" + txtSodonhang.Text.ToUpper();
                    don.LoaiDonDatHang = check_loaidathang.Checked;
                    if (check_loaidathang.Checked == true)
                    { manhacungcap = txtManhacungcap.Text; }
                    if (check_loaidathang.Checked == false)
                    { manhacungcap = ""; }
                    don.MaNhaCungCap = manhacungcap;
                    don.NoHienThoi = txtNohienthoi.Text;
                    don.TrangThaiDonDatHang = txtTrangthaidonhang.Text.ToString();
                    don.HinhThucThanhToan = cbxHinhthucthanhtoan.SelectedItem.ToString();
                    don.MaKho = cbxMaKho.SelectedValue.ToString().ToUpper();
                    don.MaNhanVien = cbxNhanvien.SelectedValue.ToString().ToUpper();
                    don.MaTienTe = cbxTiente_Tygia.SelectedValue.ToString().ToUpper();
                    don.ThueGTGT = txtGiatrigiatang.Text;
                    don.Phivanchuyen = Double.Parse(0 + txtPhivanchuyen.Text).ToString();
                    don.PhiKhac = Double.Parse(0 + txtPhikhac.Text).ToString();
                    don.GhiChu = "" + txtDiengiai.Text.ToString();
                    don.Deleted = false;

                    don.Manhanvien = Common.Utilities.User.NhanVienID;
                    don.Tendangnhap = Common.Utilities.User.TenDangNhap;

                    if (check_loaidathang.Checked == false)
                    { makhachhang = txtManhacungcap.Text; }
                    if (check_loaidathang.Checked == true)
                    { makhachhang = ""; }
                    don.Makhachhang = makhachhang;
                    if (dgvInsertOrder.RowCount > 0)
                    {
                        if (CheckData(don) == true)
                        {
                            cl = new Server_Client.Client();
                            this.client = cl.Connect(Luu.IP, Luu.Ports);
                            clientstrem = cl.SerializeObj(this.client, "DonDatHang", don);
                            Entities.DonDatHang[] tralai = new Entities.DonDatHang[1];
                            int trave = Convert.ToInt32(cl.DeserializeHepper(clientstrem, tralai));
                            if (trave == 1)
                            {
                                LuuChiTietDonHang();
                            }
                            else
                            {
                                MessageBox.Show("Thất bại");
                            }
                        }
                        else
                        { }
                    }
                    else
                    { MessageBox.Show("Không có hàng hóa trong đơn đặt hàng"); }
                }
                else
                { MessageBox.Show("Kiểm tra ngày"); }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                MessageBox.Show("Hãy kiểm tra lại thông tin nhập");
            }
        }
        /// <summary>
        /// kiem tra dinh dang nhap khi them chi tiet vao dgv
        /// </summary>
        /// <param name="soluong"></param>
        private Boolean CheckDetail(int soluong, float giagoc, float gianhap)
        {
            Boolean kt = false;
            try
            {
                if (soluong < 1)
                {
                    toolStrip_txtSoluong.Focus();
                    MessageBox.Show("Nhập số lượng");
                    kt = false;
                }
                else
                {
                    if (giagoc < 0)
                    {
                        toolStrip_txtGiagoc.Focus();
                        MessageBox.Show("Nhập giá gốc");
                        kt = false;
                    }
                    else
                    {
                        if (gianhap < 0)
                        {
                            toolStrip_txtGianhap.Focus();
                            MessageBox.Show("Giá nhập nhập không đúng");
                            kt = false;
                        }
                        else
                        {
                            kt = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return kt;
        }


        /// <summary>
        /// hungvv kiem tra dinh dang khi them moi hoa don
        /// </summary>
        /// <param name="maDonDatHang"></param>
        private Boolean CheckData(Entities.DonDatHang dat)
        {
            Boolean kt = false;
            try
            {
                if (dat.MaDonDatHang.Length <= 0)
                {
                    txtSodonhang.Focus();
                    System.Windows.Forms.MessageBox.Show("Hãy nhập mã đơn đặt hàng");
                    kt = false;
                }
                else
                {
                    if (dat.MaKho.Length <= 0)
                    {
                        cbxMaKho.Focus();
                        MessageBox.Show("Chọn mã kho");
                        kt = false;
                    }
                    else
                    {
                        if (dat.MaTienTe.Length <= 0)
                        {
                            cbxTiente_Tygia.Focus();
                            MessageBox.Show("Loại tiền tệ không đúng");
                            kt = false;
                        }
                        else
                        {
                            kt = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; kt = false; }
            return kt;
        }

        /// <summary>
        /// xoa don dat hang
        /// </summary>
        /// <param name="madondathang"></param>
        private void Xoa_DonDatHang(string madondathang)
        {
            try
            {
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn muốn xóa không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        Entities.DonDatHang them = new Entities.DonDatHang();
                        them = new Entities.DonDatHang("Delete", madondathang);
                        clientstrem = cl.SerializeObj(this.client, "DonDatHang", them);
                        Entities.DonDatHang[] tralai = new Entities.DonDatHang[1];
                        int trave = (int)cl.DeserializeHepper(clientstrem, tralai);
                        if (trave == 1)
                        { MessageBox.Show("Thành công !"); }
                        else
                        { MessageBox.Show("Thất bại !"); }
                    }
                    else
                    { }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        #region ==============================================================================================================
        /// <summary>
        /// hungvv thoat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmQuanLyDonDatHang.BaoDong = "A";
                        this.Close();
                    }
                    else
                    { }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        #region do du lieu khi can sua=================================================================
        /// <summary>
        /// hungvv =================do du lieu vao txt===========================
        /// </summary>
        /// <param name="dat"></param>
        private void DoDuLieu(Entities.DonDatHang dat)
        {
            try
            {
                Common.Utilities com = new Common.Utilities();
                ID = dat.DonDatHangID;
                txtSodonhang.Text = dat.MaDonDatHang;
                manhacungcap = "" + dat.MaNhaCungCap;
                //txtManhacungcap.Text = manhacungcap;
                txtTrangthaidonhang.Text = dat.TrangThaiDonDatHang;
                cbxMaKho.SelectedValue = dat.MaKho;
                makNgaydonhang.Text = com.XuLy(2, this.dathang.NgayDonHang.ToString());
                makNgaynhapdukien.Text = com.XuLy(2, this.dathang.NgayNhapDuKien.ToString());
                txtNohienthoi.Text = dat.NoHienThoi.ToString();
                txtPhuongthucvanchuyen.Text = "Tự vận chuyển";
                cbxHinhthucthanhtoan.SelectedItem = dat.HinhThucThanhToan.ToString();
                cbxNhanvien.SelectedValue = dat.MaNhanVien.ToString();
                check_loaidathang.Checked = dat.LoaiDonDatHang;
                cbxTiente_Tygia.SelectedValue = dat.MaTienTe.ToString();
                txtDiengiai.Text = dat.GhiChu;
                txtPhikhac.Text = dat.PhiKhac.ToString();
                txtPhivanchuyen.Text = dat.Phivanchuyen.ToString();
                makhachhang = "" + dat.Makhachhang;
                if (makhachhang != "")
                { check_loaidathang.Checked = false; txtManhacungcap.Text = makhachhang; checkData(); GiaTriCanLuu.makhachhang = makhachhang; GiaTriCanLuu.Ma = manhacungcap; }
                if (manhacungcap != "")
                { check_loaidathang.Checked = true; txtManhacungcap.Text = manhacungcap; checkData(); GiaTriCanLuu.Ma = manhacungcap; GiaTriCanLuu.makhachhang = makhachhang; }
                if (makhachhang != "" && manhacungcap != "")
                {
                    if (check_loaidathang.Checked == false)
                    { txtManhacungcap.Text = makhachhang; checkData(); GiaTriCanLuu.makhachhang = "" + dat.Makhachhang; }
                    if (check_loaidathang.Checked == true)
                    { txtManhacungcap.Text = manhacungcap; checkData(); GiaTriCanLuu.Ma = "" + dat.MaNhaCungCap; }
                }
                ///tim theo ma
                HienThi_ChiTiet_DonDatHang();
                if (dat.TrangThaiDonDatHang == "Đã thành công")
                {
                    toolStrip_Insert.Enabled = false;
                    btnTimnhacungcap.Enabled = false;
                    toolStripStatus_Them.Enabled = false;
                    toolStripStatus_Ghilai.Enabled = false;
                    toolStripStatusLabel3.Enabled = false;
                }
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion
        /// <summary>
        /// ham main
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void frmXuLy_DonDatHang_Load(object sender, EventArgs e)
        {
            try
            {
                datesv = DateServer.Date();
                Entities.HienThi_ChiTiet_DonDatHang[] row = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgvInsertOrder.DataSource = row;
                DoiTen(dgvInsertOrder);
                //doc du lieu dong
                makNgaydonhang.Text = DateServer.Date().ToString("dd/MM/yyyy"); ;
                makNgaynhapdukien.Text = DateServer.Date().ToString("dd/MM/yyyy");
                this.cbxHinhthucthanhtoan.Items.AddRange(new object[] { "Tiền mặt", "ATM" });
                cbxHinhthucthanhtoan.SelectedIndex = 0;
                this.txtTrangthaidonhang.Text = "Đang mở";
                txtPhuongthucvanchuyen.Text = "Tự vận chuyển";
                //fig cung combox
                frmXuLyDonDatHang fr = new frmXuLyDonDatHang();
                if (this.HanhDong == "Insert")
                {
                    btnTimnhacungcap.Enabled = true;
                    toolStripStatus_Them.Enabled = true;
                    toolStripStatus_Ghilai.Enabled = false;
                    Application.OpenForms[fr.Name].Text = "Thêm Mới - F4 Thêm Hàng Hóa F5 Nhập Phí Vận Chuyển F6 Sửa Hàng Hóa F7 Nhập Phí Khác";
                    txtTrangthaidonhang.ReadOnly = true;
                    getID("DonDatHang");
                    txtSodonhang.Text = makiemtra;
                    checkData();
                    toolStripStatusLabel3.Enabled = false;
                }
                //LayKhoHang();
                ///lay kho hang trong xml
                new Common.Utilities().ComboxKhoHang(cbxMaKho);

                Entities.KiemTraChung[] tt = new Entities.KiemTraChung[1];
                Entities.KiemTraChung g = new Entities.KiemTraChung();
                Common.Utilities com = new Common.Utilities();
                g.Khoachinh = Common.Utilities.User.NhanVienID;
                g.Giatri = Common.Utilities.User.TenNhanVien;
                tt[0] = g;
                com.BindingCombobox(tt, cbxNhanvien, "giatri", "khoachinh");
                //LayNhanVien();
                LayTenTT();
                txtGiatien.Text = tigia[0].Giatri2.ToString();
                cbxTiente_Tygia.SelectedIndex = 0;
                cbxTiente_Tygia.Enabled = false;
                //danh cho update
                if (this.HanhDong == "Update")
                {
                    if (this.dathang.DonDatHangID > 0)
                    {
                        btnTimnhacungcap.Enabled = false;
                        toolStripStatus_Them.Enabled = false;
                        toolStripStatus_Ghilai.Enabled = true;
                        Application.OpenForms[fr.Name].Text = "Quản lý đơn đặt hàng - Xem Chi Tiết Đơn";
                        DoDuLieu(this.dathang);
                        if (txtTrangthaidonhang.Text == "Đã thành công")
                        {
                            toolStripStatus_Ghilai.Enabled = false;
                            toolStripStatusLabel3.Enabled = false;
                            toolStripStatusLabel4.Enabled = true;
                            btnTimnhacungcap.Enabled = false;
                        }
                        if (dgvInsertOrder.RowCount <= 0)
                        {
                            txtChietkhau.Text = "0";
                            txtTienhang.Text = "0";
                            txtGiatrigiatang.Text = "0";
                            txtPhivanchuyen.Text = "0";
                            txtPhikhac.Text = "0";
                            txtTongtien.Text = "0";
                        }
                        check_loaidathang.Enabled = false;
                        TinhToan();
                    }
                    else
                    { MessageBox.Show("Không tìm thấy mã đơn đặt hàng cần sửa !"); this.Close(); }
                    toolStripStatusLabel3.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message;
                if (txtSodonhang.Text == "")
                {
                    txtSodonhang.Text = makhachhang;
                }
            }
        }
        /// <summary>
        /// hungvv =======================lay du lieu moi checkfix===========================
        /// </summary>
        private Entities.DonDatHang ConfilickData(string table, string values)
        {
            Entities.DonDatHang ddh = new Entities.DonDatHang();
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TruyenGiaTri gitri = new Entities.TruyenGiaTri("Select", table, values);
                clientstrem = cl.SerializeObj(this.client, "CheckDonDatHang", gitri);
                ddh = (Entities.DonDatHang)cl.DeserializeHepper(clientstrem, ddh);
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                ddh = null;
            }
            return ddh;
        }

        private void btnTimnhacungcap_Click(object sender, EventArgs e)
        {
            try
            {
                GiaTriCanLuu.Ma = null;
                GiaTriCanLuu.Ten = null;
                GiaTriCanLuu.Giatri2 = null;
                if (check_loaidathang.Checked == true)
                {
                    frmTraCuu fr = new frmTraCuu("DonDatHang_NhaCungCap", "NhaCungCap");
                    fr.ShowDialog();
                }
                if (check_loaidathang.Checked == false)
                {
                    frmTraCuu fr = new frmTraCuu("DonDatHang_KhachHang", "KhachHang");
                    fr.ShowDialog();
                }
                BindHangHoa();
                if (GiaTriCanLuu.Ma == null)
                { txtManhacungcap.Text = "<F4-Tra cứu>"; }
                if (dgvInsertOrder.RowCount > 0)
                { TinhToan(); }
                else
                { reset(); }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        /// <summary>
        /// kiem tra khi update
        /// </summary>
        /// <param name="gitri"></param>
        /// <param name="sosanh"></param>
        /// <returns></returns>
        private Boolean CheckConfick(Entities.DonDatHang gitri, Entities.DonDatHang sosanh)
        {
            Boolean kiemtra = false;
            try
            {
                Common.Utilities ck = new Common.Utilities();
                int count = 0;
                if (gitri.MaDonDatHang != sosanh.MaDonDatHang)
                { kiemtra = false; txtSodonhang.Text = sosanh.MaDonDatHang; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.LoaiDonDatHang != sosanh.LoaiDonDatHang)
                { kiemtra = false; check_loaidathang.Checked = sosanh.LoaiDonDatHang; }
                else { kiemtra = true; count = count + 1; }
                if (ck.SoSanhNgay('/', "!=", gitri.NgayDonHang.ToString(), sosanh.NgayDonHang.ToString()) == true)
                {
                    kiemtra = false;
                    makNgaydonhang.Text = sosanh.NgayDonHang.ToString("dd/MM/yyyy");
                    //string ngay = ck.KiemTraDinhDangNgayThangNam("NgayThangNam", sosanh.NgayDonHang.ToString(), '/');
                    //makNgaydonhang.Text = new Common.Utilities().XuLy(2, ngay);
                }
                else { kiemtra = true; count = count + 1; }
                if (gitri.MaNhaCungCap != sosanh.MaNhaCungCap)
                { kiemtra = false; txtManhacungcap.Text = sosanh.MaNhaCungCap; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.NoHienThoi != sosanh.NoHienThoi)
                { kiemtra = false; txtNohienthoi.Text = sosanh.NoHienThoi.ToString(); }
                else { kiemtra = true; count = count + 1; }
                if (gitri.TrangThaiDonDatHang != sosanh.TrangThaiDonDatHang)
                { kiemtra = false; txtTrangthaidonhang.Text = sosanh.TrangThaiDonDatHang; }
                else { kiemtra = true; count = count + 1; }
                if (ck.SoSanhNgay('/', "!=", gitri.NgayNhapDuKien.ToString(), sosanh.NgayNhapDuKien.ToString()) == true)
                {
                    kiemtra = false;
                    makNgaynhapdukien.Text = sosanh.NgayNhapDuKien.ToString("dd/MM/yyyy");
                    //string ngay = ck.KiemTraDinhDangNgayThangNam("NgayThangNam", sosanh.NgayNhapDuKien.ToString(), '/');
                    //makNgaynhapdukien.Text = new Common.Utilities().XuLy(2, ngay);
                }
                else { kiemtra = true; count = count + 1; }
                if (gitri.HinhThucThanhToan != sosanh.HinhThucThanhToan)
                { kiemtra = false; cbxHinhthucthanhtoan.SelectedItem = sosanh.HinhThucThanhToan; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.MaKho != sosanh.MaKho)
                { kiemtra = false; cbxMaKho.SelectedValue = sosanh.MaKho; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.MaNhanVien != sosanh.MaNhanVien)
                { kiemtra = false; cbxNhanvien.SelectedValue = sosanh.MaNhanVien; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.MaTienTe != sosanh.MaTienTe)
                { kiemtra = false; cbxTiente_Tygia.SelectedValue = sosanh.MaTienTe; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.ThueGTGT != sosanh.ThueGTGT)
                { kiemtra = false; txtGiatrigiatang.Text = sosanh.ThueGTGT; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.PhiKhac != sosanh.PhiKhac)
                { kiemtra = false; txtPhikhac.Text = sosanh.PhiKhac; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.Phivanchuyen != sosanh.Phivanchuyen)
                { kiemtra = false; txtPhivanchuyen.Text = sosanh.Phivanchuyen; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.GhiChu != sosanh.GhiChu)
                { kiemtra = false; txtDiengiai.Text = sosanh.GhiChu; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.Deleted != sosanh.Deleted)
                { kiemtra = false; MessageBox.Show("Đơn hàng đã xóa"); }
                else { kiemtra = true; count = count + 1; }
                if (gitri.Makhachhang != sosanh.Makhachhang)
                { kiemtra = false; txtManhacungcap.Text = sosanh.Makhachhang; }
                else { kiemtra = true; count = count + 1; }
                if (count < 17)
                { kiemtra = false; }
                else
                { kiemtra = true; }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                kiemtra = false;
            }
            return kiemtra;
        }
        /// <summary>
        /// hungvv =======================Xoa ===========================
        /// </summary>
        private void DeleteData(string ID)
        {
            try
            {
                Entities.DonDatHang dh = new Entities.DonDatHang();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                dh = new Entities.DonDatHang("Delete", ID);
                clientstrem = cl.SerializeObj(this.client, "DonDatHang", dh);
                int trave = 0;
                trave = System.Convert.ToInt32(cl.DeserializeHepper(clientstrem, trave));
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// hungvv them moi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxMaKho.Text == string.Empty)
                {
                    MessageBox.Show("Phải cài đặt kho trước "); return;
                }
                if (dgvInsertOrder.RowCount > 0)
                {
                    if (this.HanhDong == "Insert")
                    {
                        getID("DonDatHang");
                        if (txtSodonhang.Text == makiemtra)
                        {
                            frmQuanLyDonDatHang.BaoDong = "";
                            XuLy_DonDatHang("Insert");
                        }
                        else
                        { txtSodonhang.Text = makiemtra; MessageBox.Show("Mã hóa đơn đã thay đổi hãy kiểm tra lại"); }
                    }
                }
                else
                { MessageBox.Show("Phải có hàng hóa trong đơn"); }
            }
            catch (Exception ex)
            { string s = ex.Message; MessageBox.Show("Thất bại"); }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInsertOrder.RowCount > 0)
                {
                    Entities.DonDatHang sosanh = ConfilickData("DonDatHang", txtSodonhang.Text.ToUpper());
                    if (CheckConfick(dathang, sosanh) == true)
                    {
                        if (this.HanhDong == "Update")
                        {
                            frmQuanLyDonDatHang.BaoDong = "A";
                            XuLy_DonDatHang("Update");
                        }
                    }
                }
                else
                { MessageBox.Show("Phải nhập hàng hóa vào đơn"); }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            ArrayList arr = new ArrayList();
            foreach (DataGridViewRow item in dgvInsertOrder.Rows)
            {
                Entities.BCKhachHangDatHang temp = new Entities.BCKhachHangDatHang();
                temp.MaDonDatHang = txtSodonhang.Text;
                temp.MaKH = txtManhacungcap.Text;
                temp.Ten = lblTennhacungcap.Text;
                temp.MaHang = item.Cells[1].Value.ToString();
                temp.TenHang = item.Cells[2].Value.ToString();
                temp.SoLuong = Convert.ToDouble(item.Cells[3].Value.ToString());
                temp.Gia = Convert.ToDouble(item.Cells[4].Value.ToString());
                temp.ChietKhau = Convert.ToDouble(item.Cells[7].Value.ToString());
                temp.Thue = Convert.ToDouble(item.Cells[8].Value.ToString());
                temp.TongTienCK = Convert.ToDouble(item.Cells[9].Value.ToString());
                temp.TongTien = Convert.ToDouble(item.Cells[11].Value.ToString());
                arr.Add(temp);
            }
            if (arr.Count > 0)
            {
                Entities.BCKhachHangDatHang[] rpt = new Entities.BCKhachHangDatHang[arr.Count];
                int i = 0;
                foreach (object item in arr)
                {
                    rpt[i] = (Entities.BCKhachHangDatHang)item;
                    i++;
                }
                if (check_loaidathang.Checked)
                {
                    Report.rptDatHangNhaCungCap khdh = new Report.rptDatHangNhaCungCap();
                    khdh.SetDataSource(rpt);
                    khdh.SetParameterValue("TongTien", txtTienhang.Text);
                    khdh.SetParameterValue("TongTienCK", txtChietkhau.Text);
                    khdh.SetParameterValue("TienThue", txtGiatrigiatang.Text);
                    khdh.SetParameterValue("TongTienCK", txtChietkhau.Text);
                    khdh.SetParameterValue("TongTienDonHang", txtTongtien.Text);
                    khdh.SetParameterValue("NgayTao", makNgaydonhang.Text);
                    khdh.SetParameterValue("TenBaoCao", "Báo Cáo Đặt Hàng Nhà Cung Cấp");
                    frmBaoCaorpt frm = new frmBaoCaorpt(khdh);
                    frm.ShowDialog();
                }
                else
                {
                    Report.rptKhachHangDatHang khdh = new Report.rptKhachHangDatHang();
                    khdh.SetDataSource(rpt);
                    khdh.SetParameterValue("TongTien", txtTienhang.Text);
                    khdh.SetParameterValue("TongTienCK", txtChietkhau.Text);
                    khdh.SetParameterValue("TienThue", txtGiatrigiatang.Text);
                    khdh.SetParameterValue("TongTienCK", txtChietkhau.Text);
                    khdh.SetParameterValue("TongTienDonHang", txtTongtien.Text);
                    khdh.SetParameterValue("NgayTao", makNgaydonhang.Text);
                    khdh.SetParameterValue("TenBaoCao", "Báo Cáo Khách Hàng Đặt Hàng");
                    frmBaoCaorpt frm = new frmBaoCaorpt(khdh);
                    frm.ShowDialog();
                }
            }
        }

        #region lay matxt=================================================================
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
            catch (Exception ex)
            {
                string s = ex.Message;
                tra = "";
            }
            return tra;
        }
        /// <summary>
        /// lay ID tu form tra cuu
        /// </summary>
        private string banbuon;
        private string banle;
        private string giatrigiatang;
        private void BindHangHoa()
        {
            try
            {
                //lay ten khach hang
                if (GiaTriCanLuu.Loaitrave == "DonDatHang_NhaCungCap")
                {
                    if (check_loaidathang.Checked == true)
                    { txtManhacungcap.Text = GiaTriCanLuu.Ma; }
                    if (check_loaidathang.Checked == false)
                    {
                        txtManhacungcap.Text = GiaTriCanLuu.Ma;
                    }
                    lblTennhacungcap.Text = fixTen(GiaTriCanLuu.Ten);
                    if (GiaTriCanLuu.Giatri2 != "0")
                    {
                        txtNohienthoi.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(GiaTriCanLuu.Giatri2)));
                    }
                    else
                    { txtNohienthoi.Text = "0"; }
                    if (GiaTriCanLuu.Ma != null)
                    {
                        HienThi_ChiTiet_DonDatHang();
                    }
                }
                //lay ma khach hang
                if (GiaTriCanLuu.Loaitrave == "DonDatHang_KhachHang")
                {
                    txtManhacungcap.Text = GiaTriCanLuu.Ma;
                    lblTennhacungcap.Text = fixTen(GiaTriCanLuu.Ten);
                    if (GiaTriCanLuu.Giatri2 != "0")
                    {
                        txtNohienthoi.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(GiaTriCanLuu.Giatri2)));
                    }
                    else
                    { txtNohienthoi.Text = "0"; }
                }
                //lay hang hoa
                if (GiaTriCanLuu.Loaitrave == "DonDatHang_HangHoa")
                {
                    toolStrip_txtTracuu.Text = GiaTriCanLuu.Ma;
                    toolStrip_txtTenhang.Text = GiaTriCanLuu.Ten;
                    toolStrip_txtGiagoc.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(GiaTriCanLuu.Giatri)));
                    toolStrip_txtSoluong.Text = "1";
                    toolStrip_txtChietkhauphantram.Text = "0";
                    toolStrip_txtGianhap.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(GiaTriCanLuu.Giatri)));
                    toolStrip_txtThuegiatrigiatang.Text = GiaTriCanLuu.giatrigiatang;
                    banbuon = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(GiaTriCanLuu.Giatri2)));
                    banle = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(GiaTriCanLuu.TonKho)));
                    giatrigiatang = GiaTriCanLuu.giatrigiatang;
                }
                if (GiaTriCanLuu.Loaitrave == "DonDatHang_HangHoaTheoKho")
                {
                    toolStrip_txtTracuu.Text = GiaTriCanLuu.Ma;
                    toolStrip_txtTenhang.Text = GiaTriCanLuu.Ten;
                    toolStrip_txtGiagoc.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(GiaTriCanLuu.Giatri)));
                    toolStrip_txtSoluong.Text = "1";
                    toolStrip_txtChietkhauphantram.Text = "0";
                    toolStrip_txtGianhap.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(GiaTriCanLuu.Giatri)));
                    toolStrip_txtThuegiatrigiatang.Text = GiaTriCanLuu.giatrigiatang;
                    banbuon = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(GiaTriCanLuu.Giatri2)));
                    banle = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(GiaTriCanLuu.TonKho)));
                    giatrigiatang = GiaTriCanLuu.giatrigiatang;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion
        private void KeyDown_Chung(object sender, KeyEventArgs e)
        {
            try
            {
                GiaTriCanLuu.Ma = null;
                GiaTriCanLuu.Ten = null;
                GiaTriCanLuu.Giatri = null;
                GiaTriCanLuu.giatrigiatang = null;
                GiaTriCanLuu.Giatri2 = null;
                GiaTriCanLuu.TonKho = null;
                if (e.KeyCode == Keys.F4)
                {
                    if (check_loaidathang.Checked == true)
                    {
                        if (txtManhacungcap.Text.Length > 0 && txtManhacungcap.Text != "<F4-Tra cứu>")
                        {
                            //frmTraCuu fr = new frmTraCuu("DonDatHang_HangHoa", "HangHoa");
                            //fr.ShowDialog();
                            //BindHangHoa();
                            XuLyHH();
                            toolStrip_txtSoluong.Focus();
                            if (GiaTriCanLuu.Ma == null)
                            {
                                toolStrip_txtTracuu.Focus();
                                //ResetTool(); 
                            }
                            toolStrip_txtSoluong.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Nhập mã nhà cung cấp");
                        }
                    }
                    if (check_loaidathang.Checked == false)
                    {
                        if (txtManhacungcap.Text.Length > 0 && txtManhacungcap.Text != "<F4-Tra cứu>")
                        {
                            //frmTraCuu fr = new frmTraCuu("DonDatHang_HangHoaTheoKho", "HangHoaTheoKho", cbxMaKho.SelectedValue.ToString());
                            //fr.ShowDialog();
                            //BindHangHoa();

                            XuLyHH1();
                            toolStrip_txtSoluong.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Nhập mã khách hàng");
                        }
                    }
                }
                else if (e.KeyCode == Keys.F5)
                {
                    txtPhivanchuyen_Click(sender, e);
                    txtPhivanchuyen.Focus();
                }
                else if (e.KeyCode == Keys.F7)
                {
                    txtPhikhac_Click(sender, e);
                    txtPhikhac.Focus();
                }
                else if (e.KeyCode == Keys.F6)
                {
                    if (dgvInsertOrder.RowCount > 0)
                    {
                        this.dgvInsertOrder.Focus();
                    }
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (txtManhacungcap.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn hãy nhập " + lblManhacungcap.Text.Substring(0, lblManhacungcap.Text.Length - 1), "Hệ thống cảnh báo");
                        btnTimnhacungcap.Focus();
                        //toolStrip_txtTracuu.Text = "";
                        return;
                    }
                    else if (cbxMaKho.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn hãy nhập Kho hàng", "Hệ thống cảnh báo");
                        cbxMaKho.Focus();
                        //toolStrip_txtTracuu.Text = "";
                        return;
                    }
                    else if (toolStrip_txtTracuu.Text.Equals("") || toolStrip_txtTracuu.Text.Equals("<F4 - Tra cứu>"))
                    {
                        toolStrip_txtTracuu.Text = "";
                        toolStrip_txtTracuu.Focus();
                    }
                    else if ((toolStrip_txtTracuu.Text != "") || toolStrip_txtTracuu.Text != "<F4 - Tra cứu>")
                    {
                        LayHangHoaTheoMa(toolStrip_txtTracuu.Text.ToUpper());
                        toolStrip_txtSoluong.Focus();
                    }
                    else if (toolStrip_txtTenhang.Text != "" && toolStrip_txtSoluong.Text != "" && toolStrip_txtGiagoc.Text != "" && toolStrip_txtChietkhauphantram.Text != "" && toolStrip_txtGianhap.Text != "" && toolStrip_txtThuegiatrigiatang.Text != "" && toolStrip_Chietkhau.Text != "" && toolStrip_txtTracuu.Text != "")
                    {
                        ThemVao();
                    }

                    //// Qui đổi đơn vị tính
                    //foreach (Entities.QuyDoiDonViTinh item in quidoidvt)
                    //{
                    //    if (item.MaHangQuyDoi == mahanghoa)
                    //    {
                    //        toolStrip_txtTracuu.Text = item.MaHangDuocQuyDoi.ToUpper();
                    //        toolStrip_txtTenhang.Text = item.TenHangDuocQuyDoi;
                    //        toolStrip_txtSoluong.Text = item.SoLuongDuocQuyDoi.ToString();
                    //        break;

                    //    }
                    //}

                    //LayHangHoaTheoMa();
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }


        public TcpClient client1;
        public static string trave = "";
        Entities.QuyDoiDonViTinh[] quidoidvt;
        Entities.GoiHang[] goihang;
        Entities.ChiTietGoiHang[] chitietgoihang;
        Entities.CapNhatGiaKhachHang[] cngkh;
        public void XuLyHH()
        {
            try
            {
                if (txtManhacungcap.Text.Length == 0)
                {
                    MessageBox.Show("Bạn hãy nhập Mã nhà cung cấp", "Hệ thống cảnh báo");
                    btnTimnhacungcap.Focus();
                    return;
                }
                if (check_loaidathang.Checked == false && cbxMaKho.Text.Length == 0)
                {
                    MessageBox.Show("Bạn hãy nhập Kho hàng", "Hệ thống cảnh báo");
                    cbxMaKho.Focus();
                    return;
                }
                //string maKho = cbxMaKho.SelectedValue.ToString();
                frmTimHangHoa thh = new frmTimHangHoa("", "NCC");
                thh.ShowDialog();
                if (frmTimHangHoa.drvr != null)
                {

                    mahanghoa = toolStrip_txtTracuu.Text = frmTimHangHoa.drvr.Cells["MaHangHoa"].Value.ToString().ToUpper();
                    toolStrip_txtTenhang.Text = frmTimHangHoa.drvr.Cells["TenHangHoa"].Value.ToString();
                    toolStrip_txtGiagoc.Text = frmTimHangHoa.drvr.Cells["GiaNhap"].Value.ToString();

                    try
                    {
                        SelectMaCapNhatKH();
                        KiemTraCK(cngkh);
                    }
                    catch
                    {
                        phantramchietkhau = toolStrip_txtGianhap.Text = "0";
                    }
                    LayGiaTriThue(frmTimHangHoa.drvr.Cells["MaThueGiaTriGiaTang"].Value.ToString());
                    //toolStrip_txtTracuu.ReadOnly = true;
                    toolStrip_txtSoluong.Focus();
                    frmTimHangHoa.drvr = null;
                }
                else
                    toolStrip_txtTracuu.ReadOnly = false;
            }
            catch
            {
            }
        }

        public void XuLyHH1()
        {
            try
            {
                string makho = new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen;
                if (txtManhacungcap.Text.Length == 0)
                {
                    MessageBox.Show("Bạn hãy nhập Mã khách hàng", "Hệ thống cảnh báo");
                    btnTimnhacungcap.Focus();
                    return;
                }
                if (check_loaidathang.Checked == false && cbxMaKho.Text.Length == 0)
                {
                    MessageBox.Show("Bạn hãy nhập Kho hàng", "Hệ thống cảnh báo");
                    cbxMaKho.Focus();
                    return;
                }
                //string maKho = cbxMaKho.SelectedValue.ToString();frmTimHangHoa(maKho);
                frmTimHangHoa thh = new frmTimHangHoa(makho);
                thh.ShowDialog();
                if (frmTimHangHoa.drvr != null)
                {
                    mahanghoa = toolStrip_txtTracuu.Text = frmTimHangHoa.drvr.Cells["MaHangHoa"].Value.ToString().ToUpper();
                    toolStrip_txtTenhang.Text = frmTimHangHoa.drvr.Cells["TenHangHoa"].Value.ToString();
                    toolStrip_txtGiagoc.Text = frmTimHangHoa.drvr.Cells["GiaBanBuon"].Value.ToString();

                    try
                    {
                        SelectMaCapNhatKH();
                        KiemTraCK(cngkh);
                    }
                    catch
                    {
                        phantramchietkhau = toolStrip_txtGianhap.Text = "0";
                    }
                    LayGiaTriThue(frmTimHangHoa.drvr.Cells["MaThueGiaTriGiaTang"].Value.ToString());
                    //toolStrip_txtTracuu.ReadOnly = true;
                    toolStrip_txtSoluong.Focus();
                    frmTimHangHoa.drvr = null;
                }
                else
                    toolStrip_txtTracuu.ReadOnly = false;
            }
            catch
            {
            }
        }
        /// <summary>
        /// select mã cập nhật khách hàng
        /// </summary>
        public void SelectMaCapNhatKH()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.CapNhatGiaKhachHang pt = new Entities.CapNhatGiaKhachHang("Select", txtManhacungcap.Text);
                // khởi tạo mảng đối tượng để hứng giá trị
                cngkh = new Entities.CapNhatGiaKhachHang[1];
                clientstrem = cl.SerializeObj(this.client1, "CapNhatGiaKH", pt);
                // đổ mảng đối tượng vào datagripview       
                cngkh = (Entities.CapNhatGiaKhachHang[])cl.DeserializeHepper1(clientstrem, cngkh);
                if (cngkh == null)
                    cngkh = new Entities.CapNhatGiaKhachHang[0];
            }
            catch
            {
            }
            finally
            {


            }
        }
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
                    if (check_loaidathang.Checked == false)
                    {
                        toolStrip_txtGiagoc.Text = quydoiDonViTinh.GiaBanBuon;
                    }
                    else
                    {
                        toolStrip_txtGiagoc.Text = quydoiDonViTinh.GiaNhap;
                    }
                    toolStrip_txtSoluong.Text = (float.Parse(toolStrip_txtSoluong.Text) * float.Parse(quydoiDonViTinh.SoLuong)).ToString();
                    toolStrip_txtThuegiatrigiatang.Text = quydoiDonViTinh.Thue;
                    toolStrip_txtGianhap.Text = (double.Parse(toolStrip_txtGiagoc.Text) * double.Parse(toolStrip_txtSoluong.Text)).ToString();
                    string chietkhau = toolStrip_txtChietkhauphantram.Text;
                    toolStrip_txtChietkhauphantram.Text = "0";
                    toolStrip_txtChietkhauphantram.Text = chietkhau;
                    banbuon = quydoiDonViTinh.GiaBanBuon;
                    banle = quydoiDonViTinh.GiaBanLe;
                    giatrigiatang = quydoiDonViTinh.Thue;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        string thuegtgt = "0";
        /// <summary>
        /// lấy giá trị thuế
        /// </summary>
        /// <param name="maThue"></param>
        private void LayGiaTriThue(string maThue)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                Entities.Thue kh = new Entities.Thue();
                kh = new Entities.Thue("Select");
                clientstrem = cl.SerializeObj(this.client1, "Thue", kh);
                Entities.Thue[] thue = new Entities.Thue[1];
                thue = (Entities.Thue[])cl.DeserializeHepper1(clientstrem, thue);


                if (thue.Length > 0)
                {
                    int sl = thue.Length;
                    for (int i = 0; i < sl; i++)
                    {
                        if (thue[i].Deleted == false && thue[i].MaThue == maThue)
                        {
                            thuegtgt = toolStrip_txtThuegiatrigiatang.Text = thue[i].GiaTriThue;
                            return;
                        }
                    }
                }
                toolStrip_txtThuegiatrigiatang.Text = "0";
            }
            catch
            {
                return;
            }
            finally
            {


            }
        }

        /// <summary>
        /// kiểm tra chiết khấu
        /// </summary>
        /// <param name="cnhkh"></param>
        string mahanghoa, phantramchietkhau;
        public void KiemTraCK(Entities.CapNhatGiaKhachHang[] cnhkh)
        {
            try
            {
                for (int j = 0; j < cnhkh.Length; j++)
                {
                    if (cnhkh[j].MaKhachHang == txtManhacungcap.Text && cnhkh[j].MaHangHoa == mahanghoa)
                    {
                        DateTime datebegin = cnhkh[j].NgayBatDau;
                        DateTime dateend = cnhkh[j].NgayKetThuc;
                        DateTime datenow = datesv;
                        if (datenow >= datebegin && datenow <= dateend)
                        {
                            phantramchietkhau = toolStrip_txtGianhap.Text = cnhkh[j].PhanTramChietKhau.ToString();
                        }
                    }
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
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
        private void toolStrip_txtTracuu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (testCharacter(toolStrip_txtTracuu.Text) == false)
                {
                    toolStrip_txtTracuu.Focus();
                    toolStrip_txtTracuu.SelectAll();
                    return;
                }

                if (e.KeyCode == Keys.F4)
                {
                    if (this.check_loaidathang.Checked) // Dat hang NCC
                    {
                        XuLyHH();
                    }
                    else // Khach Hang Dat hang
                    {
                        XuLyHH1();
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }


        /// <summary>
        /// lấy mã kho
        /// </summary>
        /// <param name="tenKho"></param>
        /// <returns></returns>

        Entities.KhoHang[] kh1;
        public string LayMaKho(string tenKho)
        {
            try
            {
                for (int j = 0; j < kh1.Length; j++)
                {
                    if (kh1[j].TenKho == tenKho)
                    {
                        return kh1[j].MaKho;
                    }
                }
            }
            catch
            {
            }
            return "";
        }
        /// <summary>
        /// lấy hàng hóa theo mã
        /// </summary>
        private void LayHangHoaTheoMa()
        {
            Entities.HangHoa[] kh1;
            try
            {
                ArrayList array = new ArrayList();
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                Entities.HangHoa kh = new Entities.HangHoa();
                string makho = LayMaKho(cbxMaKho.Text);
                kh = new Entities.HangHoa("SelectTheoKho", makho);
                clientstrem = cl.SerializeObj(this.client1, "HangHoa", kh);
                kh1 = new Entities.HangHoa[1];
                kh1 = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 == null)
                    kh1 = new Entities.HangHoa[0];

                if (kh1.Length > 0)
                {
                    foreach (Entities.HangHoa item in kh1)
                    {
                        array.Add(item);
                    }
                    Entities.HangHoa[] save = Common.Utilities.CheckGoiHang(kh1, goihang, chitietgoihang);
                    foreach (Entities.HangHoa item in save)
                    {
                        array.Add(item);
                    }
                    kh1 = (Entities.HangHoa[])array.ToArray(typeof(Entities.HangHoa));

                    bool ktdata = false;
                    int sl = kh1.Length;
                    for (int i = 0; i < sl; i++)
                    {
                        if (kh1[i].Deleted == false)
                            if (kh1[i].MaHangHoa.ToUpper() == toolStrip_txtTracuu.Text.ToUpper())
                            {

                                mahanghoa = toolStrip_txtTracuu.Text = kh1[i].MaHangHoa.ToUpper();
                                toolStrip_txtTenhang.Text = kh1[i].TenHangHoa;
                                toolStrip_txtGiagoc.Text = kh1[i].GiaBanBuon.ToString();
                                try
                                {
                                    SelectMaCapNhatKH();
                                    KiemTraCK(cngkh);
                                }
                                catch
                                {
                                    phantramchietkhau = toolStrip_txtChietkhauphantram.Text = "0";
                                }
                                LayGiaTriThue(kh1[i].MaThueGiaTriGiaTang);
                                toolStrip_txtTracuu.ReadOnly = true;
                                toolStrip_txtSoluong.Focus();
                                ktdata = true;
                                break;
                            }
                    }
                    if (ktdata == false)
                    {
                        MessageBox.Show("Không có hàng hóa trong kho", "Hệ thống cảnh báo");
                        toolStrip_txtTenhang.Text = "";
                        toolStrip_txtGiagoc.Text = "0";
                        toolStrip_txtChietkhauphantram.Text = "0";
                        toolStrip_txtThuegiatrigiatang.Text = "0";
                        toolStrip_txtTracuu.ReadOnly = false;
                    }
                }
                else
                {
                    MessageBox.Show("Không có hàng hóa trong kho", "Hệ thống cảnh báo");
                    toolStrip_txtTenhang.Text = "";
                    toolStrip_txtGiagoc.Text = "0";
                    toolStrip_txtChietkhauphantram.Text = "0";
                    toolStrip_txtThuegiatrigiatang.Text = "0";
                    toolStrip_txtTracuu.ReadOnly = false;
                }
            }
            catch
            {
                return;
            }
            finally
            {

            }
        }

        #region chi tiet don hang-----------------------------------------------------------------------------------------------
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
                if (tra.Hanhdong != null)
                {
                    kt = tra.Hanhdong;
                }
                else
                { kt = null; }
            }
            catch (Exception ex)
            { string s = ex.Message; kt = null; }
            return kt;
        }

        /// <summary>
        /// tong tien
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        private string TinhTien(DataGridView dgv)
        {
            string tra = "0";
            try
            {
                Double gia = 0;
                if (dgv.RowCount != 0)
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        gia += (Convert.ToDouble(dgv[4, i].Value.ToString()) * Convert.ToDouble(dgv[3, i].Value.ToString()));
                    }
                    tra = Math.Round(gia).ToString();

                }
                else
                {
                    tra = "0";
                }
            }
            catch (Exception ex)
            { string s = ex.Message; tra = "0"; }
            return tra;
        }
        /// <summary>
        /// thue gia tri gia tang
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        private string TinhThue(DataGridView dgv)
        {
            string tra = "0";
            try
            {
                double gia = 0;
                if (dgv.RowCount > 0)
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        Double thue = Convert.ToDouble(dgv[8, i].Value.ToString());
                        Double thanhtien = Convert.ToDouble(dgv[9, i].Value.ToString());
                        gia += ((thue / 100) * thanhtien);
                    }
                    tra = Math.Round(gia).ToString();
                }
                else
                {
                    tra = "0";
                }
            }
            catch (Exception ex)
            { string s = ex.Message; tra = "0"; }
            return tra;
        }
        /// <summary>
        /// tinh chiet khau
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        private string TinhCK(DataGridView dgv)
        {
            string tong = "0";
            Double gia = 0;
            try
            {
                if (dgv.RowCount > 0)
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        Double chietkhau = Convert.ToDouble(dgv[9, i].Value.ToString());
                        gia += chietkhau;
                    }
                    tong = Math.Round(gia).ToString();
                }
                else
                {
                    gia += Convert.ToDouble(txtChietkhau.Text);
                    tong = Math.Round(gia).ToString();
                }
            }
            catch (Exception ex)
            { string s = ex.Message; tong = "0"; }
            return tong;
        }
        /// <summary>
        /// tinh tong tien
        /// </summary>
        /// <returns></returns>
        private string TongThanhToan()
        {
            string tong = "0";
            try
            {
                tong = (Double.Parse(txtChietkhau.Text) + Double.Parse(txtGiatrigiatang.Text) + Double.Parse(0 + txtPhivanchuyen.Text) + Double.Parse(0 + txtPhikhac.Text)).ToString();
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
                txtTongtien.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(TongThanhToan())));
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// them hang moi 1 row vao dgv
        /// </sumtramthuemary>
        private string tinhphanthue(string tong, string thue)
        {
            string tra = "0";
            try
            {
                if (int.Parse(thue) > 0)
                {
                    tra = new Common.Utilities().FormatMoney(Math.Round(Double.Parse(tong) * (Double.Parse(thue) / 100)));
                }
                else
                { tra = "0"; }
            }
            catch (Exception ex)
            {
                string s = ex.Message; tra = "0";
            }
            return tra;
        }
        private void NewRow()
        {
            try
            {
                if (txtManhacungcap.Text != "")
                {
                    try
                    {
                        QuyDoi(toolStrip_txtTracuu.Text.ToUpper());
                    }
                    catch
                    { }
                    Entities.HienThi_ChiTiet_DonDatHang add = new Entities.HienThi_ChiTiet_DonDatHang();
                    add.MaHangHoa = toolStrip_txtTracuu.Text.ToUpper();
                    add.TenHangHoa = toolStrip_txtTenhang.Text;
                    add.SoLuongDat = int.Parse(0 + toolStrip_txtSoluong.Text);
                    add.GiaGoc = toolStrip_txtGiagoc.Text;
                    add.PhanTramChietKhau = Double.Parse(0 + toolStrip_txtChietkhauphantram.Text).ToString();
                    add.Thuegiatrigiatang = toolStrip_txtThuegiatrigiatang.Text;
                    add.GiaNhap = new Common.Utilities().FormatMoney(Double.Parse(0 + toolStrip_txtGianhap.Text));
                    add.ChietKhau = toolStrip_Chietkhau.Text;
                    add.TongTien = new Common.Utilities().FormatMoney(Double.Parse(toolStrip_txtGiagoc.Text) * int.Parse(0 + toolStrip_txtSoluong.Text));
                    if (Double.Parse(toolStrip_txtSoluong.Text) >= 1)
                    {
                        string thongbao = KiemTraMa(add);
                        if (thongbao == "OK")
                        {
                            if (Double.Parse(toolStrip_txtGianhap.Text) > 0)
                            {
                                LayGiaTri(dgvInsertOrder, add);
                                DoiTen(dgvInsertOrder);
                                ResetTool();
                            }
                            else
                            {
                                MessageBox.Show("Giá nhập của hàng không đúng");
                            }
                        }
                        else
                        {
                            toolStrip_txtTracuu.Focus();
                            MessageBox.Show("Mã hàng không đúng");
                            return;
                        }
                    }
                    else
                    { MessageBox.Show("Số lượng nhập không đúng"); }
                }
                else
                {
                    MessageBox.Show("Chọn nhà cung cấp");
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
        }
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
                        string thue = "0";
                        Entities.HienThi_ChiTiet_DonDatHang row = new Entities.HienThi_ChiTiet_DonDatHang();
                        row.MaHangHoa = dgv.Rows[i].Cells[1].Value.ToString();
                        row.TenHangHoa = dgv.Rows[i].Cells[2].Value.ToString();
                        thue = dgv.Rows[i].Cells[8].Value.ToString();
                        if (dgv.Rows[i].Cells[1].Value.ToString() == themmoi.MaHangHoa)
                        {
                            sl = (int.Parse(dgv.Rows[i].Cells[3].Value.ToString()) + themmoi.SoLuongDat).ToString();
                            tong = new Common.Utilities().FormatMoney(Double.Parse(sl) * Double.Parse(dgv.Rows[i].Cells[4].Value.ToString()));
                            if (Double.Parse(dgv.Rows[i].Cells[7].Value.ToString()) == 0)
                            {
                                gn = new Common.Utilities().FormatMoney((Double.Parse(tong)));
                            }
                            else
                            {
                                gn = new Common.Utilities().FormatMoney(Double.Parse(tong) - ((Double.Parse(dgv.Rows[i].Cells[7].Value.ToString()) / 100 * Double.Parse(dgv.Rows[i].Cells[4].Value.ToString())) * Double.Parse(sl)));
                            }
                            check = true;
                        }
                        else
                        {
                            sl = dgv.Rows[i].Cells[3].Value.ToString();
                            tong = dgv.Rows[i].Cells[11].Value.ToString();
                            gn = dgv.Rows[i].Cells[9].Value.ToString();
                        }
                        row.SoLuongDat = int.Parse(sl);
                        row.GiaGoc = new Common.Utilities().FormatMoney(Double.Parse(dgv.Rows[i].Cells[4].Value.ToString()));
                        row.PhanTramChietKhau = dgv.Rows[i].Cells[7].Value.ToString();
                        row.Thuegiatrigiatang = thue;
                        row.GiaNhap = gn;
                        row.TongTien = tong;
                        arr.Add(row);
                    }

                    if (check == false)
                    {
                        Entities.HienThi_ChiTiet_DonDatHang row = new Entities.HienThi_ChiTiet_DonDatHang();
                        row.MaHangHoa = themmoi.MaHangHoa;
                        row.TenHangHoa = themmoi.TenHangHoa;
                        row.SoLuongDat = themmoi.SoLuongDat;
                        row.GiaGoc = new Common.Utilities().FormatMoney(Double.Parse(themmoi.GiaGoc));
                        row.PhanTramChietKhau = themmoi.PhanTramChietKhau;
                        row.Thuegiatrigiatang = themmoi.Thuegiatrigiatang;
                        row.GiaNhap = new Common.Utilities().FormatMoney(Double.Parse(themmoi.GiaNhap));
                        row.TongTien = new Common.Utilities().FormatMoney(Double.Parse(themmoi.TongTien));
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
                    row.PhanTramChietKhau = themmoi.PhanTramChietKhau;
                    row.Thuegiatrigiatang = themmoi.Thuegiatrigiatang;
                    row.GiaNhap = new Common.Utilities().FormatMoney(Double.Parse(themmoi.GiaNhap));
                    row.TongTien = new Common.Utilities().FormatMoney(Double.Parse(themmoi.TongTien));
                    arr.Add(row);
                }
                int n = arr.Count;
                if (n == 0) { list = null; }
                list = new Entities.HienThi_ChiTiet_DonDatHang[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.HienThi_ChiTiet_DonDatHang)arr[i];
                }
                dgv.DataSource = null;
                dgv.DataSource = list;
                DoiTen(dgvInsertOrder);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgv.DataSource = lay;
                DoiTen(dgvInsertOrder);
            }
        }
        private void ThemVao()
        {
            if (string.IsNullOrEmpty(toolStrip_txtSoluong.Text))
            {
                MessageBox.Show("Số lượng không được để trống", "Hệ thống cảnh báo");
                toolStrip_txtSoluong.Focus();
                return;
            }

            if (int.Parse(toolStrip_txtSoluong.Text) <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Hệ thống cảnh báo");
                toolStrip_txtSoluong.Focus();
                return;
            }

            if (int.Parse(0 + toolStrip_txtSoluong.Text) < 0)
            {
                MessageBox.Show("Phần trăm chiết khấu không đúng", "Hệ thống cảnh báo");
                toolStrip_txtChietkhauphantram.Focus();
                return;
            }


            if (int.Parse(0 + toolStrip_txtChietkhauphantram.Text) >= 0)
            {
                NewRow();
                if (dgvInsertOrder.RowCount > 0)
                { TinhToan(); txtPhivanchuyen.Text = "0"; txtPhikhac.Text = "0"; toolStrip_txtTracuu.Text = ""; toolStrip_txtTracuu.Focus(); }
                else
                { reset(); }
            }

            toolStrip_txtTracuu.ReadOnly = false;

        }




        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {
            ThemVao();
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
                toolStrip_txtThuegiatrigiatang.Text = "";
                toolStrip_txtChietkhauphantram.Text = "0";
                toolStrip_Chietkhau.Text = "0";
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void txtManhacungcap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtManhacungcap.Text == "")
                {
                    ResetTool();
                    Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                    dgvInsertOrder.DataSource = lay;
                    DoiTen(dgvInsertOrder);
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void txtManhacungcap_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                GiaTriCanLuu.Ma = null;
                GiaTriCanLuu.Ten = null;
                GiaTriCanLuu.Giatri2 = null;
                if (this.HanhDong == "Insert")
                {
                    if (check_loaidathang.Checked == true)
                    {
                        frmTraCuu fr = new frmTraCuu("DonDatHang_NhaCungCap", "NhaCungCap");
                        fr.ShowDialog();
                    }
                    if (check_loaidathang.Checked == false)
                    {
                        frmTraCuu fr = new frmTraCuu("DonDatHang_KhachHang", "KhachHang");
                        fr.ShowDialog();
                    }
                    BindHangHoa();
                    if (GiaTriCanLuu.Ma == null)
                    { txtManhacungcap.Text = "<F4-Tra cứu>"; }
                    if (dgvInsertOrder.RowCount > 0)
                    { TinhToan(); }
                    else
                    { reset(); }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion
        #region ---------------------------------------------------------------------------------------------------------------
        private void toolStrip_txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void toolStrip_txtGiagoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void toolStrip_txtChietkhauphantram_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void toolStrip_txtGianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void toolStrip_txtSoluong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (toolStrip_txtTenhang.Text.Length > 0)
                {
                    if (toolStrip_txtSoluong.Text != "" && int.Parse(0 + toolStrip_txtSoluong.Text) > 0)
                    {
                        toolStrip_txtGianhap.Text = new Common.Utilities().FormatMoney(Double.Parse(toolStrip_txtGiagoc.Text) * Double.Parse(toolStrip_txtSoluong.Text));
                        toolStrip_Chietkhau.Text = new Common.Utilities().FormatMoney(Double.Parse(toolStrip_txtGiagoc.Text) * Double.Parse(toolStrip_txtSoluong.Text));
                    }
                    else
                    {
                        toolStrip_txtGianhap.Text = "0";
                        toolStrip_Chietkhau.Text = "0";
                        toolStrip_txtChietkhauphantram.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void toolStrip_txtChietkhau_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (float.Parse(0 + toolStrip_txtChietkhauphantram.Text) == (float.Parse(0 + toolStrip_txtGiagoc.Text)))
                {
                    toolStrip_txtGianhap.Text = "";
                    toolStrip_txtThuegiatrigiatang.Text = "100";
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void txtChietkhauphantram()
        {
            try
            {
                string tong = (Double.Parse(toolStrip_txtGiagoc.Text) * int.Parse(toolStrip_txtSoluong.Text)).ToString();
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
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void toolStrip_txtChietkhauphantram_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (toolStrip_txtTenhang.Text.Length > 0)
                {
                    if (int.Parse(0 + toolStrip_txtChietkhauphantram.Text) >= 0)
                    {
                        txtChietkhauphantram();
                    }
                    else
                    {
                        toolStrip_Chietkhau.Text = "0";
                        toolStrip_txtGianhap.Text = "0";
                    }
                }
                else
                {
                    toolStrip_txtChietkhauphantram.Text = "0";
                    return;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        private string check = "";
        private void frmXuLyDonDatHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (check == "")
                {
                    frmQuanLyDonDatHang.BaoDong = "A";
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        /// <summary>
        /// xoa du lieu
        /// </summary>
        /// <param name="dgv"></param>
        private int i = 0;
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
                    toolStrip_txtGiagoc.Text = dgv[4, i].Value.ToString();
                    toolStrip_txtThuegiatrigiatang.Text = dgv[8, i].Value.ToString();
                    giatrigiatang = dgv[8, i].Value.ToString();
                    toolStrip_Chietkhau.Text = "0";
                    toolStrip_txtGianhap.Text = (Double.Parse(0 + dgv[4, i].Value.ToString()) * int.Parse(0 + dgv[3, i].Value.ToString())).ToString();
                    toolStrip_txtChietkhauphantram.Text = "0";
                    toolStrip_txtSoluong.Text = int.Parse(0 + dgv[3, i].Value.ToString()).ToString();

                    for (int j = 0; j < dgv.RowCount; j++)
                    {
                        if (dgv[1, j].Value.ToString() != dgv[1, i].Value.ToString())
                        {
                            Entities.HienThi_ChiTiet_DonDatHang row = new Entities.HienThi_ChiTiet_DonDatHang();
                            row.MaHangHoa = dgv.Rows[j].Cells[1].Value.ToString();
                            row.TenHangHoa = dgv.Rows[j].Cells[2].Value.ToString();
                            row.SoLuongDat = int.Parse(0 + dgv.Rows[j].Cells[3].Value.ToString());
                            row.GiaGoc = dgv.Rows[j].Cells[4].Value.ToString();
                            row.PhanTramChietKhau = dgv.Rows[j].Cells[7].Value.ToString();
                            row.Thuegiatrigiatang = dgv.Rows[j].Cells[8].Value.ToString();
                            row.GiaNhap = new Common.Utilities().FormatMoney(Double.Parse(dgv.Rows[j].Cells[9].Value.ToString()));
                            row.TongTien = new Common.Utilities().FormatMoney(Double.Parse(dgv.Rows[j].Cells[11].Value.ToString()));
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
                    list = new Entities.HienThi_ChiTiet_DonDatHang[0];
                    arr = null;
                    dgv.DataSource = list;
                    DoiTen(dgv);
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// cap nhat trang thai txt
        /// </summary>
        private void reset()
        {
            try
            {
                txtTongtien.Text = "0";
                txtPhivanchuyen.Text = "0";
                txtPhikhac.Text = "0";
                txtGiatrigiatang.Text = "0";
                txtTienhang.Text = "0";
                txtChietkhau.Text = "0";
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void dgvInsertOrder_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                getDataTable(dgvInsertOrder);
                if (dgvInsertOrder.RowCount > 0)
                { TinhToan(); }
                else
                { reset(); }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
        }

        private void dgvInsertOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //them = "NO";
                i = e.RowIndex;
                if (i >= 0)
                    dgvInsertOrder.Rows[i].Selected = true;
                else
                    i = -1;
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }

        private void txtManhacungcap_MouseHover(object sender, EventArgs e)
        {
            try
            {
                if (txtManhacungcap.Text == "<F4-Tra cứu>")
                { txtManhacungcap.Text = ""; }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void txtManhacungcap_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (txtManhacungcap.Text == "")
                { txtManhacungcap.Text = "<F4-Tra cứu>"; }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// lay thong tin ti gia theo khoa ma tien te
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxTiente_Tygia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < tigia.Length; i++)
                {
                    if (cbxTiente_Tygia.SelectedValue.ToString() == tigia[i].Khoachinh.ToString())
                    {
                        txtGiatien.Text = tigia[i].Giatri2.ToString();
                    }
                    else
                    { continue; }
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); MessageBox.Show(s); }
        }

        private void txtPhivanchuyen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvInsertOrder.RowCount > 0)
                {
                    if (Double.Parse(0 + txtPhivanchuyen.Text) > 0)
                    {
                        if (txtPhivanchuyen.Text.Length > 2)
                        {
                            //txtPhivanchuyen.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(txtPhivanchuyen.Text)));
                            txtTienhang.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(TongThanhToan())));
                        }
                        //else
                        //{
                        //    txtPhivanchuyen.Text = new Common.Utilities().loc(txtPhivanchuyen.Text);
                        //}
                        TinhToan();
                    }
                    else
                    { txtTongtien.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(TongThanhToan()))); }
                }
                else
                {
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void txtPhivanchuyen_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void txtPhikhac_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void txtPhikhac_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvInsertOrder.RowCount > 0)
                {
                    if (Double.Parse(0 + txtPhikhac.Text) > 0)
                    {
                        if (txtPhikhac.Text.Length > 2)
                        {
                            txtPhikhac.Text = new Common.Utilities().KhongDau(txtPhikhac.Text);
                        }
                        else
                        {
                            txtPhikhac.Text = new Common.Utilities().loc(txtPhikhac.Text);
                        }
                        TinhToan();
                    }
                    else
                    { txtTongtien.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(TongThanhToan()))); }
                }
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void checkData()
        {
            try
            {
                if (check_loaidathang.Checked == true)
                {
                    lblManhacungcap.Text = "Mã nhà cung cấp:";
                    check_loaidathang.Text = "Đặt nhà cung cấp";
                }
                if (check_loaidathang.Checked == false)
                {
                    lblManhacungcap.Text = "Mã khách hàng:";
                    check_loaidathang.Text = "Khách hàng đặt hàng";
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
        private void check_loaidathang_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (check_loaidathang.Checked == true)
                { lblKhohang.Text = "Cho kho hàng: "; }
                if (check_loaidathang.Checked == false)
                { lblKhohang.Text = "Trong kho: "; }
                txtManhacungcap.Text = "<F4-Tra cứu>";
                lblTennhacungcap.Text = "";
                checkData();
                Entities.HienThi_ChiTiet_DonDatHang[] row = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgvInsertOrder.DataSource = row;
                DoiTen(dgvInsertOrder);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.HienThi_ChiTiet_DonDatHang[] lay = new Entities.HienThi_ChiTiet_DonDatHang[0];
                dgvInsertOrder.DataSource = lay;
                DoiTen(dgvInsertOrder);
            }
        }

        #endregion

        private void toolStrip_txtSoluong_Click(object sender, EventArgs e)
        {
            toolStrip_txtSoluong.Text = "";
            toolStrip_txtGianhap.Text = "0";
            toolStrip_Chietkhau.Text = "0";
            toolStrip_txtChietkhauphantram.Text = "0";
        }
        #endregion

        /// <summary>
        /// tim chi tiet hang hoa theo ma
        /// </summary>
        /// <param name="MaHang"></param>
        private void LayHangHoaTheoMa(string MaHang)
        {
            try
            {
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
                    //toolStrip_txtSoluong.Text = "";
                    toolStrip_txtSoluong.Focus();
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="makho"></param>
        private void BindingHangHoaTheoMaKho(string makho, string mahanghoa)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TruyenGiaTri kh = new Entities.TruyenGiaTri("Select", makho);
                clientstrem = cl.SerializeObj(this.client, "LayBang_HangHoaTheoMaKhoHang", kh);
                Entities.ThongTinDatHang[] ddh = new Entities.ThongTinDatHang[1];
                ddh = (Entities.ThongTinDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                bool kt = false;
                if (ddh.Length > 0)
                {
                    for (int i = 0; i < ddh.Length; i++)
                    {
                        if (ddh[i].MaHangHoa == mahanghoa)
                        {
                            LayHangHoaTheoMa(mahanghoa);
                            kt = true;
                            break;
                        }
                        else
                        {
                            kt = false;
                        }
                    }
                    if (kt != true)
                    {
                        MessageBox.Show("Mã hàng hóa này không có trong kho", "Hệ thống cảnh báo");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Mã hàng hóa này không có trong kho", "Hệ thống cảnh báo");
                    return;
                }

            }
            catch
            {
            }
        }

        private void toolStrip_txtTracuu_Click(object sender, EventArgs e)
        {
            toolStrip_txtTracuu.Text = "";
            toolStrip_txtTenhang.Text = "";
            toolStrip_txtGiagoc.Text = "0";
            toolStrip_txtGianhap.Text = "0";
            toolStrip_txtThuegiatrigiatang.Text = "0";
            toolStrip_Chietkhau.Text = "0";

            toolStrip_txtChietkhauphantram.Text = "0";
            toolStrip_txtSoluong.Text = "1";
        }

        private void toolStrip_txtTracuu_DoubleClick(object sender, EventArgs e)
        {
            toolStrip_txtTracuu.Text = "";
            toolStrip_txtTenhang.Text = "";
            toolStrip_txtGiagoc.Text = "0";
            toolStrip_txtGianhap.Text = "0";
            toolStrip_txtThuegiatrigiatang.Text = "0";
            toolStrip_Chietkhau.Text = "0";

            toolStrip_txtChietkhauphantram.Text = "0";
            toolStrip_txtSoluong.Text = "1";
        }

        private void toolStrip_txtSoluong_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    toolStrip_txtChietkhauphantram.Focus();
                    //ThemVao();
                }
                //KeyDown_Chung(sender, e);
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void toolStrip_txtChietkhauphantram_Click(object sender, EventArgs e)
        {
            try
            {
                toolStrip_txtChietkhauphantram.Text = "0";
                toolStrip_Chietkhau.Text = "0";
                toolStrip_txtGianhap.Text = "0";
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void toolStrip_txtChietkhauphantram_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ThemVao();
                }
                //KeyDown_Chung(sender, e);
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void txtPhivanchuyen_Click(object sender, EventArgs e)
        {
            txtPhivanchuyen.Text = "";
        }

        private void txtPhikhac_Click(object sender, EventArgs e)
        {
            txtPhikhac.Text = "";
        }

        private void txtPhivanchuyen_KeyUp(object sender, KeyEventArgs e)
        {
            KeyDown_Chung(sender, e);
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (this.HanhDong == "Insert")
                    {
                        if (dgvInsertOrder.RowCount > 0)
                        {

                            getID("DonDatHang");
                            if (txtSodonhang.Text == makiemtra)
                            {
                                frmQuanLyDonDatHang.BaoDong = "";
                                XuLy_DonDatHang("Insert");
                            }
                            else
                            { txtSodonhang.Text = makiemtra; MessageBox.Show("Mã hóa đơn đã thay đổi hãy kiểm tra lại"); }

                        }
                        else
                        { MessageBox.Show("Phải có hàng hóa trong đơn"); }
                    }
                    if (this.HanhDong == "Update")
                    {
                        if (dgvInsertOrder.RowCount > 0)
                        {
                            Entities.DonDatHang sosanh = ConfilickData("DonDatHang", txtSodonhang.Text.ToUpper());
                            if (CheckConfick(dathang, sosanh) == true)
                            {

                                frmQuanLyDonDatHang.BaoDong = "A";
                                XuLy_DonDatHang("Update");

                            }
                        }
                        else
                        { MessageBox.Show("Phải nhập hàng hóa vào đơn"); }
                    }
                }
                catch (Exception ex)
                { string s = ex.Message; MessageBox.Show("Thất bại"); }
            }
        }

        private void txtPhikhac_KeyUp(object sender, KeyEventArgs e)
        {
            KeyDown_Chung(sender, e);
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (this.HanhDong == "Insert")
                    {
                        if (dgvInsertOrder.RowCount > 0)
                        {

                            getID("DonDatHang");
                            if (txtSodonhang.Text == makiemtra)
                            {
                                frmQuanLyDonDatHang.BaoDong = "";
                                XuLy_DonDatHang("Insert");
                            }
                            else
                            { txtSodonhang.Text = makiemtra; MessageBox.Show("Mã hóa đơn đã thay đổi hãy kiểm tra lại"); }

                        }
                        else
                        { MessageBox.Show("Phải có hàng hóa trong đơn"); }
                    }
                    if (this.HanhDong == "Update")
                    {
                        if (dgvInsertOrder.RowCount > 0)
                        {
                            Entities.DonDatHang sosanh = ConfilickData("DonDatHang", txtSodonhang.Text.ToUpper());
                            if (CheckConfick(dathang, sosanh) == true)
                            {

                                frmQuanLyDonDatHang.BaoDong = "A";
                                XuLy_DonDatHang("Update");

                            }
                        }
                        else
                        { MessageBox.Show("Phải nhập hàng hóa vào đơn"); }
                    }
                }
                catch (Exception ex)
                { string s = ex.Message; MessageBox.Show("Thất bại"); }
            }
        }

        private void dgvInsertOrder_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (i >= 0)
                    {
                        getDataTable(dgvInsertOrder);
                        if (dgvInsertOrder.RowCount > 0)
                        { TinhToan(); }
                        else
                        { reset(); }
                        toolStrip_txtSoluong.Focus();
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
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
        private void thanhtoanngay(KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F3)
                {
                    txtPhivanchuyen.Text = "";
                    txtPhivanchuyen.Focus();
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void makNgaynhapdukien_KeyUp(object sender, KeyEventArgs e)
        {
            thanhtoanngay(e);
        }

        private void txtManhacungcap_KeyUp(object sender, KeyEventArgs e)
        {
            thanhtoanngay(e);
        }

        private void btnTimnhacungcap_KeyUp(object sender, KeyEventArgs e)
        {
            thanhtoanngay(e);
        }

        private void txtPhuongthucvanchuyen_KeyUp(object sender, KeyEventArgs e)
        {
            thanhtoanngay(e);
        }

        private void cbxHinhthucthanhtoan_KeyUp(object sender, KeyEventArgs e)
        {
            thanhtoanngay(e);
        }

        private void cbxNhanvien_KeyUp(object sender, KeyEventArgs e)
        {
            thanhtoanngay(e);
        }

        private void cbxMaKho_KeyUp(object sender, KeyEventArgs e)
        {
            thanhtoanngay(e);
        }

        private void cbxTiente_Tygia_KeyUp(object sender, KeyEventArgs e)
        {
            thanhtoanngay(e);
        }

        private void txtDiengiai_KeyUp(object sender, KeyEventArgs e)
        {
            thanhtoanngay(e);
        }

        private void check_loaidathang_KeyUp(object sender, KeyEventArgs e)
        {
            thanhtoanngay(e);
        }

        private void toolStripStatus_Them_MouseMove(object sender, MouseEventArgs e)
        {
            //toolStripStatus_Them.ForeColor = System.Drawing.Color.Maroon;
            //this.toolStripStatus_Them.Image = global::GUI.Properties.Resources.Sua;
            toolStripStatus_Them.Width = 20;
            toolStripStatus_Them.BackColor = System.Drawing.Color.DarkOrange;
        }

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

    }
}
#endregion