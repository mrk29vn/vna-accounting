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
    public partial class frmXuLyHangTraLai : Form
    {
        #region Khoi Tao
        private Entities.ThongTinDatHang[] laymang2;
        private Entities.ThongTinDatHang[] laymang;
        private Entities.SoLuongTraLai[] soluongKHTL;
        private Entities.SoLuongTraLai[] soluongHDBH;
        private Entities.SoLuongTraLai[] soluongHDN;
        private Entities.SoLuongTraLai[] soluongTLNCC;
        private static Entities.KiemTraChung[] tigia;
        private int KhachHangID = 0;
        private string Duno = "0";
        private int NhaCungCapID = 0;
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private string tenForm;

        public string TenForm
        {
            get { return tenForm; }
            set { tenForm = value; }
        }
        private string truyen;
        public string Truyen
        {
            get { return truyen; }
            set { truyen = value; }
        }
        private Entities.KhachHangTraLai update;
        public Entities.KhachHangTraLai Update
        {
            get { return update; }
            set { update = value; }
        }
        public frmXuLyHangTraLai(string hanhdong, string tenForm, string truyen)
        {
            InitializeComponent();
            this.HanhDong = hanhdong;
            this.tenForm = tenForm;
            this.truyen = truyen;
        }
        private Entities.TraLaiNCC ncctra;
        public Entities.TraLaiNCC Ncctra
        {
            get { return ncctra; }
            set { ncctra = value; }
        }
        public frmXuLyHangTraLai()
        {
            InitializeComponent();
        }
        public frmXuLyHangTraLai(string hanhdong)
        {
            InitializeComponent();
            this.HanhDong = hanhdong;
        }
        public frmXuLyHangTraLai(string hanhdong, string tenForm)
        {
            InitializeComponent();
            this.HanhDong = hanhdong;
            this.tenForm = tenForm;
        }
        public frmXuLyHangTraLai(string hanhdong, string tenForm, string truyen, Entities.TraLaiNCC ncctra)
        {
            InitializeComponent();
            this.HanhDong = hanhdong;
            this.tenForm = tenForm;
            this.truyen = truyen;
            this.ncctra = ncctra;
        }
        public frmXuLyHangTraLai(string hanhdong, string tenForm, string truyen, Entities.KhachHangTraLai add)
        {
            InitializeComponent();
            this.HanhDong = hanhdong;
            this.tenForm = tenForm;
            this.truyen = truyen;
            this.update = add;
        }
        #endregion

        #region Connections
        private TcpClient client;
        private NetworkStream clientstrem;
        private Server_Client.Client cl;

        /// <summary>
        /// mo ket noi
        /// </summary>
        private void Connections()
        {
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
        }
        #endregion

        #region ComboBox
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
                tigia = tt;
                Common.Utilities com = new Common.Utilities();
                com.BindingCombobox(tt, cbxTiente_Tygia, "giatri", "khoachinh");
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
        }

        private void LayKhoHang()
        {
            try
            {
                cbxKhoHang.Items.Clear();
                Entities.KiemTraChung kh = new Entities.KiemTraChung();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                kh = new Entities.KiemTraChung("Select", "KhoHang", "MaKho", "TenKho");
                clientstrem = cl.SerializeObj(this.client, "LayCombox", kh);
                Entities.KiemTraChung[] ddh = new Entities.KiemTraChung[1];
                ddh = (Entities.KiemTraChung[])cl.DeserializeHepper(clientstrem, ddh);
                Common.Utilities com = new Common.Utilities();
                com.BindingCombobox(ddh, cbxKhoHang, "giatri", "khoachinh");
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }

        }
        #endregion

        #region Hien Thi
        private void Binding()
        {
            try
            {
                if (tenForm == "KhachHangTraLai")
                {
                    if (GiaTriCanLuu.Loaitrave == "HangTraLai_KhachHangTraLai_KhachHang")
                    {
                        txtMakhachhang.Text = GiaTriCanLuu.Ma;
                        lblTenkhachhang.Text = fixTen(GiaTriCanLuu.Ten);
                        txtNohienthoi.Text = GiaTriCanLuu.Giatri2;
                    }
                    if (GiaTriCanLuu.Loaitrave == "HangTraLai_KhachHangTraLai_MaDonHang")
                    {
                        txtChungtugoc.Text = GiaTriCanLuu.Ma;
                        lblNgay.Text = GiaTriCanLuu.Ten;
                    }
                }
                if (tenForm == "TraLaiNhaCungCap")
                {
                    if (GiaTriCanLuu.Loaitrave == "HangTraLai_TraLaiNhaCungCap")
                    {
                        txtMakhachhang.Text = GiaTriCanLuu.Ma;
                        lblTenkhachhang.Text = fixTen(GiaTriCanLuu.Ten);
                        txtNohienthoi.Text = GiaTriCanLuu.Giatri2;
                    }
                    if (GiaTriCanLuu.Loaitrave == "HangTraLai_DonDatHangNhaCungCap")
                    {
                        txtChungtugoc.Text = GiaTriCanLuu.Ma;
                        lblNgay.Text = GiaTriCanLuu.Ten;
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private string loaihoadon(RadioButton check1, RadioButton check2)
        {
            string tralai = "";
            if (check1.Checked == true)
            {
                tralai = "BanBuon";
            }
            else
            {
                if (check2.Checked == true)
                {
                    tralai = "BanLe";
                }
                else
                { tralai = ""; }
            }
            return tralai;
        }
        private void ResetTool()
        {
            toolStrip_txtTracuu.Text = "<F4 - Tra cứu>";
            toolStrip_txtTenhang.Text = "";
            toolStrip_txtSoluong.Text = "1";
            toolStrip_txtGiagoc.Text = "0";
            toolStrip_Chietkhau.Text = "0";
            toolStrip_txtChietkhauphantram.Text = "0";
            toolStrip_txtTongTien.Text = "0";
        }
        private void capnhat()
        {
            try
            {
                txtChietkhau.Text = "0";
                txtTienhang.Text = "0";
                txtGiatrigiatang.Text = "0";
                txtTongtienthanhtoan.Text = "0";
                txtConphaitra.Text = "0";
                txtThanhtoanngay.Text = "0";
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void format()
        {
            if (dgvXemthongtin.RowCount <= 0)
            {
                dgvXemthongtin.DataSource = null;
                Entities.LayHangHoaTheoMaKhachHangTraLai[] row = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                dgvXemthongtin.DataSource = row;
            }
            toolStrip_txtTracuu.Text = "";
            toolStrip_txtSoluong.Text = "1";
            toolStrip_txtChietkhauphantram.Text = "0";
            toolStrip_txtTenhang.Text = "";
            toolStrip_txtGiagoc.Text = "0";
        }
        private string fixTen(string chuoi)
        {
            string tra = "";
            try
            {
                if (chuoi.Length >= 10)
                {
                    tra = chuoi.Substring(0, 7) + "...";
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
        private void fixDatagridview()
        {
            try
            {
                dgvXemthongtin.RowHeadersVisible = false;
                dgvXemthongtin.Columns[0].HeaderText = "Mã hàng";
                dgvXemthongtin.Columns[1].HeaderText = "Tên hàng";
                dgvXemthongtin.Columns[2].HeaderText = "Số lượng";
                dgvXemthongtin.Columns[3].HeaderText = "Giá bán";
                dgvXemthongtin.Columns[4].HeaderText = "Chiết khấu(%)";
                dgvXemthongtin.Columns[5].HeaderText = "Chiết khấu";
                dgvXemthongtin.Columns[6].HeaderText = "Tổng Tiền";
                dgvXemthongtin.Columns[7].HeaderText = "Thuế(GTGT)";
                dgvXemthongtin.Columns[7].Visible = false;
                dgvXemthongtin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvXemthongtin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        #region Get ID
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
                {
                    if (hanhDong == "Them_KhachHangTraLai")
                    {
                        makiemtra = "KHTL_0001";
                    }
                    if (hanhDong == "Them_TraLaiNhaCungCap")
                    {
                        makiemtra = "TLNCC_0001";
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                txtSodonhang.Text = "";
                if (hanhDong == "Them_KhachHangTraLai")
                {
                    makiemtra = "KHTL_0001";
                }
                if (hanhDong == "Them_TraLaiNhaCungCap")
                {
                    makiemtra = "TLNCC_0001";
                }
            }
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
            catch (Exception ex)
            { string s = ex.Message; thongtin = null; }
            return thongtin;
        }
        #endregion

        #region KhachHang_NhaCungCap
        private void TraCuuMa()
        {
            try
            {
                GiaTriCanLuu.Ma = null;
                GiaTriCanLuu.Ten = null;
                GiaTriCanLuu.Giatri2 = null;
                if (tenForm == "KhachHangTraLai")
                {
                    if (hanhDong == "Them_KhachHangTraLai")
                    {
                        frmTraCuu fr = new frmTraCuu("HangTraLai_KhachHangTraLai_KhachHang", "KhachHangTralaiHang", loaihoadon(rdoBanbuon, rdoBanle));
                        fr.ShowDialog();
                    }
                    Binding();
                }
                if (tenForm == "TraLaiNhaCungCap")
                {
                    if (hanhDong == "Them_TraLaiNhaCungCap")
                    {
                        frmTraCuu fr = new frmTraCuu("HangTraLai_TraLaiNhaCungCap", "NhaCungCap");
                        fr.ShowDialog();
                    }
                    Binding();
                }
                if (txtMakhachhang.Text.Length <= 0)
                { txtMakhachhang.Text = "<F4 - Tra cứu>"; }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        #region LayHangHoaTheoMa
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
                    ResetTool();
                    MessageBox.Show("Hàng hóa không tồn tại");
                    toolStrip_txtTracuu.Focus();
                    toolStrip_txtTracuu.Text = "";
                }
                else
                {
                    GiaTriCanLuu.Ma = tra.MaHangHoa;
                    GiaTriCanLuu.Ten = tra.TenHangHoa;
                    GiaTriCanLuu.Giatri = tra.GiaGoc;
                    GiaTriCanLuu.Giatri2 = tra.SoLuongDat.ToString();
                    GiaTriCanLuu.giatrigiatang = tra.Thuegiatrigiatang;
                    GiaTriCanLuu.makhachhang = tra.SoLuongDat.ToString();
                    if (tenForm == "KhachHangTraLai")
                    {

                        toolStrip_txtTracuu.Text = GiaTriCanLuu.Ma;
                        toolStrip_txtTenhang.Text = GiaTriCanLuu.Ten;
                        toolStrip_txtGiagoc.Text = GiaTriCanLuu.Giatri;
                        toolStrip_txtSoluong.Text = GiaTriCanLuu.Giatri2;
                        toolStrip_txtChietkhauphantram.Text = "0";
                        toolStrip_Chietkhau.Text = (Double.Parse(toolStrip_txtGiagoc.Text) * Double.Parse(toolStrip_txtSoluong.Text)).ToString();
                        toolStrip_txtTongTien.Text = (Double.Parse(toolStrip_txtGiagoc.Text) * Double.Parse(toolStrip_txtSoluong.Text)).ToString();
                        thue = GiaTriCanLuu.giatrigiatang;
                    }
                    if (tenForm == "TraLaiNhaCungCap")
                    {
                        toolStrip_txtTracuu.Text = GiaTriCanLuu.Ma;
                        toolStrip_txtTenhang.Text = GiaTriCanLuu.Ten;
                        toolStrip_txtGiagoc.Text = GiaTriCanLuu.Giatri;
                        toolStrip_txtSoluong.Text = GiaTriCanLuu.makhachhang;
                        toolStrip_txtChietkhauphantram.Text = "0";
                        toolStrip_Chietkhau.Text = (Double.Parse(toolStrip_txtGiagoc.Text) * Double.Parse(toolStrip_txtSoluong.Text)).ToString();
                        toolStrip_txtTongTien.Text = (Double.Parse(toolStrip_txtGiagoc.Text) * Double.Parse(toolStrip_txtSoluong.Text)).ToString();
                        thue = GiaTriCanLuu.giatrigiatang;
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        #endregion

        #region AddRow
        private int sl = 1;
        private Boolean kiemtrahangtralai(int c, string ma, string hanhdong)
        {
            Boolean kt = false;
            try
            {
                if (dgvXemthongtin.RowCount > 0)
                {
                    for (int i = 0; i < dgvXemthongtin.RowCount; i++)
                    {
                        if (c == 2)
                        {
                            if (int.Parse(dgvXemthongtin.Rows[2].Cells[i].Value.ToString()) > int.Parse(ma))
                            {
                                sl = int.Parse(dgvXemthongtin.Rows[2].Cells[i].Value.ToString());
                                kt = true;
                                MessageBox.Show("Số lượng trả lại phải nhỏ hơn hoặc bằng số lượng đã mua");
                                break;
                            }
                            else
                            { continue; }
                        }
                    }
                }
                else
                {
                    if (hanhdong == "cungcap")
                    {
                        if (Double.Parse(toolStrip_txtSoluong.Text) > Double.Parse(GiaTriCanLuu.makhachhang) && Double.Parse(GiaTriCanLuu.makhachhang) > 0)
                        {
                            MessageBox.Show("Số lượng lớn hơn số lượng đã mua");
                            sl = int.Parse(GiaTriCanLuu.makhachhang);
                            kt = true;
                        }
                        else
                        {
                            kt = false;
                        }
                    }
                    else
                    {
                        if (Double.Parse(toolStrip_txtSoluong.Text) > Double.Parse(GiaTriCanLuu.Giatri2) && Double.Parse(GiaTriCanLuu.Giatri2) > 0)
                        {
                            MessageBox.Show("Số lượng lớn hơn số lượng đã bán");
                            sl = int.Parse(GiaTriCanLuu.Giatri2);
                            kt = true;
                        }
                        else
                        {
                            kt = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return kt;
        }
        private void ThemVao()
        {
            try
            {
                if (toolStrip_txtTenhang.Text.Length > 0)
                {
                    if (int.Parse(0 + toolStrip_txtSoluong.Text) > 0)
                    {
                        if (toolStrip_txtChietkhauphantram.Text != "")
                        {
                            if (Double.Parse(toolStrip_Chietkhau.Text) > 0)
                            {
                                if (g == "khachhang")
                                {
                                    NewRow(g);
                                }
                                if (g == "cungcap")
                                {
                                    NewRow(g);
                                }
                                if (dgvXemthongtin.RowCount > 0)
                                {
                                    capnhat();
                                    TinhToan();
                                    if (tenForm == "KhachHangTraLai")
                                    {
                                        string gia = DuNoKhachHang(txtNohienthoi.Text);
                                        txtSodu.Text = new Common.Utilities().FormatMoney(double.Parse(gia));
                                        if (Double.Parse(txtThanhtoanngay.Text) > Double.Parse(txtSodu.Text) && Double.Parse(txtSodu.Text) < 0)
                                        {
                                            txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(gia));
                                            if (rdoBanle.Checked == true)
                                            {
                                                txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(Double.Parse(TongTienDaCoThue()));
                                                txtThanhtoanngay.Enabled = false;
                                            }
                                        }
                                        if (Double.Parse(txtSodu.Text) > 0)
                                        {
                                            txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(gia));
                                            if (rdoBanle.Checked == true)
                                            {
                                                txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(Double.Parse(TongTienDaCoThue()));
                                                txtThanhtoanngay.Enabled = false;
                                            }
                                        }
                                        if (Double.Parse(txtSodu.Text) == 0)
                                        {


                                            if (rdoBanle.Checked == true)
                                            {
                                                txtConphaitra.Text = new Common.Utilities().FormatMoney(0 - Double.Parse(TongTienDaCoThue()));
                                                txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(Double.Parse(TongTienDaCoThue()));
                                                txtThanhtoanngay.Enabled = false;
                                            }
                                            else
                                            {
                                                txtSodu.Text = "0";
                                                txtConphaitra.Text = "0";
                                                txtThanhtoanngay.Text = "0";
                                            }
                                        }
                                    }
                                    if (tenForm == "TraLaiNhaCungCap")
                                    {
                                        string gia = DuNoNhaCungCap(txtNohienthoi.Text);
                                        txtSodu.Text = new Common.Utilities().FormatMoney(Double.Parse(gia));
                                        if (Double.Parse(txtThanhtoanngay.Text) > Double.Parse(txtSodu.Text) && Double.Parse(txtSodu.Text) < 0)
                                        {
                                            txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(gia));

                                        }
                                        if (Double.Parse(txtSodu.Text) > 0)
                                        {
                                            txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(gia));
                                        }
                                        if (Double.Parse(txtSodu.Text) == 0)
                                        {
                                            txtSodu.Text = "0";
                                            txtConphaitra.Text = "0";
                                            txtThanhtoanngay.Text = "0";
                                        }
                                    }
                                }
                                else
                                { capnhat(); ResetTool(); }
                            }
                            else
                            { MessageBox.Show("Tổng tiền đã chiết khấu phải lớn hơn 0"); ResetTool(); }
                        }
                        else
                        { MessageBox.Show("Nhập phần trăm chiết khấu"); toolStrip_txtChietkhauphantram.Focus(); }
                    }
                    else
                    { MessageBox.Show("Nhập số lượng"); toolStrip_txtSoluong.Focus(); }
                }
                else
                { MessageBox.Show("Phải nhập hàng hóa"); toolStrip_txtTracuu.Focus(); }
                toolStrip_txtTracuu.Focus();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        private string thue = "0";
        private void NewRow(string hanhdong)
        {
            try
            {
                if (txtMakhachhang.Text != "")
                {
                    try
                    {
                        QuyDoi(toolStrip_txtTracuu.Text.ToUpper());
                    }
                    catch
                    { }
                    Entities.LayHangHoaTheoMaKhachHangTraLai add = new Entities.LayHangHoaTheoMaKhachHangTraLai();
                    add.Mahanghoa = toolStrip_txtTracuu.Text;
                    string thongbao = KiemTraMa(add);
                    add.Tenhanghoa = toolStrip_txtTenhang.Text;
                    add.Soluong = int.Parse(toolStrip_txtSoluong.Text);
                    add.Giaban = toolStrip_txtGiagoc.Text;
                    add.Phantramchietkhau = Double.Parse(0 + toolStrip_txtChietkhauphantram.Text).ToString();
                    add.Chietkhau = Double.Parse(0 + toolStrip_Chietkhau.Text).ToString();
                    add.Tongtien = Double.Parse(0 + toolStrip_txtTongTien.Text).ToString();
                    add.Thuegiatrigiatang = thue;
                    if (thongbao == "NO")
                    {
                        MessageBox.Show("Mã hàng không đúng");
                        toolStrip_txtTracuu.Focus();
                        toolStrip_txtTracuu.Text = "";
                        return;
                    }
                    else
                    {
                        LayGiaTri(dgvXemthongtin, add);
                        ResetTool();
                    }
                }
                else
                {
                    ResetTool();
                    MessageBox.Show("Chọn nhà cung cấp");
                    return;
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
            }
        }
        #endregion

        #region SoLuong
        private string LaySoLuong(string ma)
        {
            string tra = "";
            try
            {
                for (int x = 0; x < soluongmua.Length; x++)
                {
                    if (soluongmua[x].Giatritruyen == ma)
                    {
                        tra = soluongmua[x].Giatrithuhai;
                        break;
                    }
                    else
                    { tra = ""; continue; }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; tra = ""; }
            return tra;
        }
        private int LaySoLuongConLaiTheoKhachHang(string hoadonbanhang, string mahanghoa)
        {
            int sl = 0;
            try
            {
                LaySoLuongKhachHangTraLaiTheoHoaDonBanHang(hoadonbanhang);
                LaySoLuongDaMuaTheoHoaDonBanHang(hoadonbanhang);
                if (soluongKHTL.Length <= 0 && soluongHDBH.Length > 0)
                {
                    for (int k = 0; k < soluongHDBH.Length; k++)
                    {
                        if (soluongHDBH[k].MaHangHoa == mahanghoa)
                        {
                            sl += soluongHDBH[k].SoLuong;
                        }
                        else
                        { continue; }
                    }
                }
                else
                {
                    int sl_1 = 0;
                    int sl_2 = 0;
                    for (int k = 0; k < soluongKHTL.Length; k++)
                    {
                        if (soluongKHTL[k].MaHangHoa == mahanghoa)
                        {
                            sl_1 += soluongKHTL[k].SoLuong;
                        }
                        else
                        { continue; }
                    }
                    for (int k = 0; k < soluongHDBH.Length; k++)
                    {
                        if (soluongHDBH[k].MaHangHoa == mahanghoa)
                        {
                            sl_2 += soluongHDBH[k].SoLuong;
                        }
                        else
                        { continue; }
                    }
                    if (sl_2 == sl_1)
                    {
                        sl = 0;
                    }
                    else
                    {
                        sl = sl_2 - sl_1;
                    }
                }
                if (soluongHDBH.Length <= 0)
                { sl = 0; }
            }
            catch (Exception ex)
            { string s = ex.Message; sl = 0; }
            return sl;
        }

        private int LaySoLuongConLaiTheoNhaCungCap(string mahoadonnhap, string mahanghoa)
        {
            int sl = 0;
            try
            {
                LaySoLuongDaNhapTheoHoaDonNhap(mahoadonnhap);
                LaySoLuongTraLaiNhaCungCapTheoHoaDonNhapHang(mahoadonnhap);
                if (soluongTLNCC.Length <= 0 && soluongHDN.Length > 0)
                {
                    for (int k = 0; k < soluongHDN.Length; k++)
                    {
                        if (soluongHDN[k].MaHangHoa == mahanghoa)
                        {
                            sl += soluongHDN[k].SoLuong;
                        }
                        else
                        { continue; }
                    }
                }
                else
                {
                    int sl_1 = 0;
                    int sl_2 = 0;
                    for (int k = 0; k < soluongTLNCC.Length; k++)
                    {
                        if (soluongTLNCC[k].MaHangHoa == mahanghoa)
                        {
                            sl_1 += soluongTLNCC[k].SoLuong;
                        }
                        else
                        { continue; }
                    }
                    for (int k = 0; k < soluongHDN.Length; k++)
                    {
                        if (soluongHDN[k].MaHangHoa == mahanghoa)
                        {
                            sl_2 += soluongHDN[k].SoLuong;
                        }
                        else
                        { continue; }
                    }
                    if (sl_2 == sl_1)
                    {
                        sl = 0;
                    }
                    else
                    {
                        sl = sl_2 - sl_1;
                    }
                }
                if (soluongHDN.Length <= 0)
                { sl = 0; }
            }
            catch (Exception ex)
            { string s = ex.Message; sl = 0; }
            return sl;
        }
        private void LaySoLuongKhachHangTraLaiTheoHoaDonBanHang(string hoadonbanhang)
        {
            try
            {
                Entities.TruyenGiaTri dat = new Entities.TruyenGiaTri("Select", hoadonbanhang);
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "LaySoLuongKhachHangTraLaiTheoHoaDonBanHang", dat);
                soluongKHTL = new Entities.SoLuongTraLai[1];
                soluongKHTL = (Entities.SoLuongTraLai[])cl.DeserializeHepper(clientstrem, soluongKHTL);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }

        private void LaySoLuongDaMuaTheoHoaDonBanHang(string hoadonbanhang)
        {
            try
            {
                Entities.TruyenGiaTri dat = new Entities.TruyenGiaTri("Select", hoadonbanhang);
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "LaySoLuongDaMuaTheoHoaDonBanHang", dat);
                soluongHDBH = new Entities.SoLuongTraLai[1];
                soluongHDBH = (Entities.SoLuongTraLai[])cl.DeserializeHepper(clientstrem, soluongHDBH);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }

        private void LaySoLuongTraLaiNhaCungCapTheoHoaDonNhapHang(string mahoadonnhap)
        {
            try
            {
                Entities.TruyenGiaTri dat = new Entities.TruyenGiaTri("Select", mahoadonnhap);
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "LaySoLuongTraLaiNhaCungCapTheoHoaDonNhapHang", dat);
                soluongTLNCC = new Entities.SoLuongTraLai[1];
                soluongTLNCC = (Entities.SoLuongTraLai[])cl.DeserializeHepper(clientstrem, soluongTLNCC);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }

        private void LaySoLuongDaNhapTheoHoaDonNhap(string mahoadonnhap)
        {
            try
            {
                Entities.TruyenGiaTri dat = new Entities.TruyenGiaTri("Select", mahoadonnhap);
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "LaySoLuongDaNhapTheoHoaDonNhap", dat);
                soluongHDN = new Entities.SoLuongTraLai[1];
                soluongHDN = (Entities.SoLuongTraLai[])cl.DeserializeHepper(clientstrem, soluongHDN);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        #endregion

        #region Chuyen Unicode
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

        #region Tinh Toan
        private void checkKH()
        {
            try
            {
                string gia = DuNoKhachHang(txtNohienthoi.Text);
                if (txtThanhtoanngay.Text != "")
                {
                    if (Double.Parse(gia) == 0)
                    {
                        txtConphaitra.Text = "0";
                        txtThanhtoanngay.Text = "0";
                    }
                    if (Double.Parse(gia) < 0 && Double.Parse(txtThanhtoanngay.Text) > 0)
                    {
                        txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(gia) + Double.Parse(txtThanhtoanngay.Text));
                    }
                    if (Double.Parse(gia) > 0 && Double.Parse(0 + txtThanhtoanngay.Text) > 0)
                    {
                        txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(gia) - Double.Parse(txtThanhtoanngay.Text));
                        return;
                    }
                    if (Double.Parse(txtThanhtoanngay.Text) == 0)
                    {
                        txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(gia));
                        return;
                    }
                    if ((Double.Parse(txtSodu.Text) + Double.Parse(txtThanhtoanngay.Text)) == 0)
                    {
                        txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(Double.Parse(gia));
                        txtConphaitra.Text = "0";
                        return;
                    }
                    if (Double.Parse(gia) < Double.Parse(txtThanhtoanngay.Text))
                    {
                        txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(Double.Parse(gia));
                        txtConphaitra.Text = "0";
                    }
                }
                else
                { txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(gia)); }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        public Boolean TinhChietKhau(ToolStripTextBox txtchietkhau, ToolStripTextBox txtphantramchietkhau, Double giagoc, Double phantram)
        {
            Boolean tra = false;
            Double trave = 0;
            if (phantram > 0 && phantram <= 100)
            {
                trave = (phantram / giagoc) * 100;
                txtchietkhau.Text = (giagoc - trave).ToString();
                txtphantramchietkhau.Text = phantram.ToString();
                tra = true;
            }
            else
            {
                if (phantram == 0)
                {
                    txtchietkhau.Text = "";
                    txtphantramchietkhau.Text = "";
                    tra = true;
                }
                else
                {
                    txtchietkhau.Text = "";
                    txtphantramchietkhau.Text = "";
                    tra = false;
                }
            }
            return tra;
        }
        public string TongTien(DataGridView dgv)
        {
            string giatri = "0";
            if (dgv.RowCount > 0)
            {
                int count = dgv.RowCount;
                Entities.ChiTietDonDatHang[] chitiet = new Entities.ChiTietDonDatHang[count];
                for (int i = 0; i < count; i++)
                {
                    string lay = dgv.Rows[i].Cells[7].Value.ToString();
                    giatri = (Double.Parse(lay) + Double.Parse(giatri)).ToString();
                }
            }
            return giatri;
        }
        private void checkNCC()
        {
            try
            {
                string gia = txtSodu.Text;
                if (txtThanhtoanngay.Text != "")
                {
                    if (Double.Parse(gia) == 0)
                    {
                        txtConphaitra.Text = "0";
                        txtThanhtoanngay.Text = "0";
                    }
                    if (Double.Parse(gia) < 0 && Double.Parse(txtThanhtoanngay.Text) > 0)
                    {
                        txtThanhtoanngay.Text = "0";
                        txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(gia));
                    }
                    if (Double.Parse(gia) > 0 && Double.Parse(txtThanhtoanngay.Text) > 0)
                    {
                        txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(gia) + Double.Parse(txtThanhtoanngay.Text));
                        //txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(gia));
                    }
                    if ((Double.Parse(txtThanhtoanngay.Text) + Double.Parse(txtSodu.Text)) >= 0 && Double.Parse(txtSodu.Text) < 0)
                    {
                        txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(Double.Parse(txtSodu.Text));
                        txtConphaitra.Text = "0";
                    }
                    if (Double.Parse(gia) < Double.Parse(txtThanhtoanngay.Text))
                    {
                        txtThanhtoanngay.Text = Double.Parse(gia).ToString();
                        txtConphaitra.Text = "0";
                    }
                }
                else
                { txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(txtSodu.Text)); }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private Boolean KiemTraDuNoKhachHang(string tong)
        {
            Boolean k = false;
            try
            {
                if (Double.Parse(tong) <= 0)
                    k = true;
                else
                    k = false;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                k = false;
            }
            return k;
        }

        private Boolean KiemTraDuNoNhaCungCap(string sodu)
        {
            Boolean k = false;
            try
            {
                if (Double.Parse(sodu) >= 0)
                {
                    k = true;
                }
                else
                {
                    k = false;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                k = false;
            }
            return k;
        }

        private string SoDu(string chuoi)
        {
            string tra = "0";
            try
            {
                if (Double.Parse(chuoi) < 0)
                    tra = chuoi;
                if (Double.Parse(chuoi) == 0)
                    tra = "0";
                if (Double.Parse(chuoi) > 0)
                    tra = chuoi;

            }
            catch (Exception ex)
            { string s = ex.Message; tra = ""; }
            return tra;
        }

        private string SoDuKT(string chuoi)
        {
            string tra = "0";
            try
            {
                if (Double.Parse(chuoi) > 0)
                    tra = chuoi;
                if (Double.Parse(chuoi) == 0)
                    tra = "0";
                if (Double.Parse(chuoi) < 0)
                    tra = chuoi;
            }
            catch (Exception ex)
            { string s = ex.Message; tra = ""; }
            return tra;
        }
        private string TinhTien(DataGridView dgv)
        {
            string t = "0";
            try
            {
                Double gia = 0;
                if (dgv.RowCount > 0)
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        gia += Convert.ToDouble(new Common.Utilities().KhongDau(dgv[6, i].Value.ToString()));
                    }
                    t = Math.Round(gia).ToString();
                }
                else
                { t = "0"; }
            }
            catch (Exception ex) { string s = ex.Message.ToString(); t = "0"; }
            return t;
        }
        public string TongTienDaCoThue()
        {
            string t = "0";
            try
            {
                Double tong = 0;
                tong = Double.Parse(txtChietkhau.Text) + Double.Parse(txtGiatrigiatang.Text);
                t = Math.Round(tong).ToString();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); t = "0"; }
            return t;
        }

        private string TinhCK(DataGridView dgv)
        {
            string t = "0";
            try
            {
                if (dgv.RowCount > 0)
                {
                    Double gia = 0;
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        Double chietkhau = Double.Parse(new Common.Utilities().KhongDau(dgv[5, i].Value.ToString()));
                        gia += chietkhau;
                    }
                    t = Math.Round(gia).ToString();
                }
                else
                { t = "0"; }
            }
            catch (Exception ex)
            { string s = ex.Message; t = "0"; }
            return t;
        }
        private string TinhThue(DataGridView dgv)
        {
            string tra = "0";
            try
            {
                double gia = 0;
                if (dgv.RowCount != 0)
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        Double thue = Convert.ToDouble(new Common.Utilities().KhongDau(dgv[7, i].Value.ToString()));
                        Double thanhtien = Convert.ToDouble(new Common.Utilities().KhongDau(dgv[5, i].Value.ToString()));
                        gia += ((thue / 100) * thanhtien);
                    }
                    tra = Math.Round(gia).ToString();
                }
                else { tra = "0"; }
            }
            catch (Exception ex)
            { string s = ex.Message; tra = "0"; }
            return tra;
        }

        private string tinhtienconphaitra()
        {
            string boi = "0";
            try
            {
                if (Double.Parse(txtThanhtoanngay.Text) <= Double.Parse(txtTongtienthanhtoan.Text))
                {
                    boi = Math.Round(Double.Parse(new Common.Utilities().KhongDau(txtTongtienthanhtoan.Text)) - Double.Parse(new Common.Utilities().KhongDau(txtThanhtoanngay.Text))).ToString();
                }
                else
                {
                    boi = Math.Round(Double.Parse(new Common.Utilities().KhongDau(txtTongtienthanhtoan.Text))).ToString();
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); boi = "0"; }
            return boi;
        }
        private string DuNoKhachHang(string no)
        {
            string tra = "0";
            try
            {
                if (Double.Parse(no) == 0)
                {
                    Duno = "0";
                    tra = (Convert.ToDouble(no) - Convert.ToDouble(txtTongtienthanhtoan.Text)).ToString();
                }
                if (Double.Parse(no) < 0)
                {
                    Duno = "0";
                    tra = (Convert.ToDouble(no) - Convert.ToDouble(txtTongtienthanhtoan.Text)).ToString();
                }
                if (Double.Parse(no) > 0)
                {
                    tra = (Convert.ToDouble(no) - Convert.ToDouble(txtTongtienthanhtoan.Text)).ToString();
                }
            }
            catch (Exception ex)
            { string s = ex.Message; tra = "0"; }
            return tra;
        }
        private string DuNoNhaCungCap(string no)
        {
            string tra = "0";
            try
            {
                if (Double.Parse(no) > 0)
                {
                    tra = (Convert.ToDouble(no) - Convert.ToDouble(txtTongtienthanhtoan.Text)).ToString();
                }
                if (Double.Parse(no) == 0)
                {
                    tra = (Convert.ToDouble(no) - Convert.ToDouble(txtTongtienthanhtoan.Text)).ToString();
                }
                if (Double.Parse(no) < 0)
                {
                    tra = (Convert.ToDouble(no) - Convert.ToDouble(txtTongtienthanhtoan.Text)).ToString();
                }
            }
            catch (Exception ex)
            { string s = ex.Message; tra = "0"; }
            return tra;
        }

        private void TinhToan()
        {
            try
            {
                txtTienhang.Text = new Common.Utilities().FormatMoney(Double.Parse(TinhTien(dgvXemthongtin)));
                txtChietkhau.Text = new Common.Utilities().FormatMoney(Double.Parse(TinhCK(dgvXemthongtin)));
                txtGiatrigiatang.Text = new Common.Utilities().FormatMoney(Double.Parse(TinhThue(dgvXemthongtin)));
                txtTongtienthanhtoan.Text = new Common.Utilities().FormatMoney(Double.Parse(TongTienDaCoThue()));

            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        private string tinhtong()
        {
            string tong = "0";
            try
            {
                tong = (int.Parse(toolStrip_txtSoluong.Text) * Double.Parse(new Common.Utilities().KhongDau(toolStrip_txtGiagoc.Text))).ToString();
            }
            catch (Exception ex)
            { string s = ex.Message; tong = "0"; }
            return tong;
        }

        private string chietkhau()
        {
            string chietkhau = "0";
            try
            {
                Double p = Double.Parse(0 + toolStrip_txtChietkhauphantram.Text);
                if (p <= 0)
                {
                    chietkhau = tinhtong();
                }
                else
                {
                    chietkhau = Math.Round(Double.Parse(new Common.Utilities().KhongDau(tinhtong())) - ((p / 100 * Double.Parse(new Common.Utilities().KhongDau(toolStrip_txtGiagoc.Text))) * Double.Parse(new Common.Utilities().KhongDau(toolStrip_txtSoluong.Text)))).ToString();
                }
            }
            catch (Exception ex)
            { string s = ex.Message; chietkhau = "0"; }
            return chietkhau;
        }
        #endregion

        #region XuLy
        private void ThemMoi()
        {
            try
            {
                if (tenForm == "KhachHangTraLai" && hanhDong == "Them_KhachHangTraLai")
                {
                    if (string.IsNullOrEmpty(txtNohienthoi.Text))
                        txtNohienthoi.Text = "0";
                    if (string.IsNullOrEmpty(txtConphaitra.Text))
                        txtConphaitra.Text = "0";

                    Duno = (double.Parse(txtNohienthoi.Text) - double.Parse(txtConphaitra.Text)).ToString();
                    if (Duno != "")
                    {
                        getID("KhachHangTraLai");
                        if (txtSodonhang.Text == makiemtra)
                        {
                            frmQuanLyKhachHangTraLaiHang.BaoDong = "";
                            XuLy_KhachHangTraLai("Insert");
                        }
                        else
                        { MessageBox.Show("Mã hóa đơn này đã thay đổi hãy kiểm tra lại"); txtSodonhang.Text = makiemtra; return; }

                    }
                    else
                    { MessageBox.Show("Tiền thanh toán quá lớn"); }
                }
                if (tenForm == "TraLaiNhaCungCap" && hanhDong == "Them_TraLaiNhaCungCap")
                {
                    if (string.IsNullOrEmpty(txtNohienthoi.Text))
                        txtNohienthoi.Text = "0";
                    if (string.IsNullOrEmpty(txtConphaitra.Text))
                        txtConphaitra.Text = "0";

                    Duno = (double.Parse(txtNohienthoi.Text) - double.Parse(txtConphaitra.Text)).ToString();
                    if (Duno != "")
                    {
                        getID("TraLaiNCC");
                        if (txtSodonhang.Text == makiemtra)
                        {
                            frmQuanLyTraLaiNhaCungCap.BaoDong = "";
                            XuLy_TraLaiNhaCungCap("Insert");
                        }
                        else
                        { MessageBox.Show("Mã hóa đơn này đã thay đổi hãy kiểm tra lại"); txtSodonhang.Text = makiemtra; return; }

                    }
                    else
                    { MessageBox.Show("Dư nợ phải lớn hơn hoặc bằng 0"); txtConphaitra.Focus(); }
                }
            }
            catch
            { }
        }
        private void getDataTableKhachHang(DataGridView dgv)
        {
            try
            {
                ArrayList arr = new ArrayList();
                Entities.LayHangHoaTheoMaKhachHangTraLai[] list = null;
                if (dgv.RowCount > 0 && i >= 0)
                {

                    toolStrip_txtTracuu.Text = dgv[0, i].Value.ToString();
                    toolStrip_txtTenhang.Text = dgv[1, i].Value.ToString();
                    toolStrip_txtSoluong.Text = LaySoLuong(dgv[0, i].Value.ToString());
                    toolStrip_txtGiagoc.Text = dgv[3, i].Value.ToString();
                    toolStrip_txtChietkhauphantram.Text = "0";
                    toolStrip_Chietkhau.Text = (Double.Parse(toolStrip_txtSoluong.Text) * Double.Parse(toolStrip_txtGiagoc.Text)).ToString();
                    toolStrip_txtTongTien.Text = (Double.Parse(toolStrip_txtSoluong.Text) * Double.Parse(toolStrip_txtGiagoc.Text)).ToString();
                    thue = dgv[7, i].Value.ToString();
                    for (int j = 0; j < dgv.RowCount; j++)
                    {
                        if (dgv[0, j].Value.ToString() != dgv[0, i].Value.ToString())
                        {
                            Entities.LayHangHoaTheoMaKhachHangTraLai row = new Entities.LayHangHoaTheoMaKhachHangTraLai();
                            row.Mahanghoa = dgv.Rows[j].Cells[0].Value.ToString();
                            row.Tenhanghoa = "" + dgv.Rows[j].Cells[1].Value.ToString();
                            row.Soluong = int.Parse(dgv.Rows[j].Cells[2].Value.ToString());
                            row.Giaban = dgv.Rows[j].Cells[3].Value.ToString();
                            row.Phantramchietkhau = dgv.Rows[j].Cells[4].Value.ToString();
                            row.Chietkhau = dgv.Rows[j].Cells[5].Value.ToString();
                            row.Tongtien = dgv.Rows[j].Cells[6].Value.ToString();
                            row.Thuegiatrigiatang = dgv.Rows[j].Cells[7].Value.ToString();
                            arr.Add(row);
                        }
                        else
                        { continue; }
                    }
                    int n = arr.Count;
                    if (n == 0) { arr = null; }
                    list = new Entities.LayHangHoaTheoMaKhachHangTraLai[n];
                    for (int x = 0; x < n; x++)
                    {
                        list[x] = (Entities.LayHangHoaTheoMaKhachHangTraLai)arr[x];
                    }
                    dgv.DataSource = list;
                }
                else
                {
                    list = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                    arr = null;
                    dgv.DataSource = list;
                    fixDatagridview();
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void getDataTableNhaCungCap(DataGridView dgv)
        {
            try
            {
                ArrayList arr = new ArrayList();
                Entities.LayHangHoaTheoMaKhachHangTraLai[] list = null;
                if (dgv.RowCount > 0 && i >= 0)
                {
                    toolStrip_txtTracuu.Text = dgv[0, i].Value.ToString();
                    toolStrip_txtTenhang.Text = dgv[1, i].Value.ToString();
                    toolStrip_txtSoluong.Text = dgv[2, i].Value.ToString();
                    toolStrip_txtGiagoc.Text = dgv[3, i].Value.ToString();
                    toolStrip_txtChietkhauphantram.Text = "0";
                    toolStrip_Chietkhau.Text = (Double.Parse(toolStrip_txtSoluong.Text) * Double.Parse(toolStrip_txtGiagoc.Text)).ToString();
                    toolStrip_txtTongTien.Text = (Double.Parse(toolStrip_txtSoluong.Text) * Double.Parse(toolStrip_txtGiagoc.Text)).ToString();
                    thue = dgv[7, i].Value.ToString();
                    for (int j = 0; j < dgv.RowCount; j++)
                    {
                        if (dgv[0, j].Value.ToString() != dgv[0, i].Value.ToString())
                        {
                            Entities.LayHangHoaTheoMaKhachHangTraLai row = new Entities.LayHangHoaTheoMaKhachHangTraLai();
                            row.Mahanghoa = dgv.Rows[j].Cells[0].Value.ToString();
                            row.Tenhanghoa = "" + dgv.Rows[j].Cells[1].Value.ToString();
                            row.Soluong = int.Parse(dgv.Rows[j].Cells[2].Value.ToString());
                            row.Giaban = dgv.Rows[j].Cells[3].Value.ToString();
                            row.Phantramchietkhau = dgv.Rows[j].Cells[4].Value.ToString();
                            row.Chietkhau = dgv.Rows[j].Cells[5].Value.ToString();
                            row.Tongtien = dgv.Rows[j].Cells[6].Value.ToString();
                            row.Thuegiatrigiatang = dgv.Rows[j].Cells[7].Value.ToString();
                            arr.Add(row);
                        }
                        else
                        { continue; }
                    }
                    int n = arr.Count;
                    if (n == 0) { arr = null; }
                    list = new Entities.LayHangHoaTheoMaKhachHangTraLai[n];
                    for (int x = 0; x < n; x++)
                    {
                        list[x] = (Entities.LayHangHoaTheoMaKhachHangTraLai)arr[x];
                    }
                    dgv.DataSource = list;
                }
                else
                {
                    list = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                    arr = null;
                    dgv.DataSource = list;
                    fixDatagridview();
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void XuLyDGV()
        {
            try
            {
                if (tenForm == "KhachHangTraLai")
                {
                    getDataTableKhachHang(dgvXemthongtin);
                    txtSodu.Text = "0";
                    txtThanhtoanngay.Text = "0";
                    txtConphaitra.Text = "0";
                }
                if (tenForm == "TraLaiNhaCungCap")
                {
                    getDataTableNhaCungCap(dgvXemthongtin);
                    txtSodu.Text = "0";
                    txtThanhtoanngay.Text = "0";
                    txtConphaitra.Text = "0";
                }
                if (dgvXemthongtin.RowCount > 0)
                {
                    capnhat();
                    TinhToan();
                    if (tenForm == "KhachHangTraLai")
                    {
                        string gia = DuNoKhachHang(txtNohienthoi.Text);
                        txtSodu.Text = new Common.Utilities().FormatMoney(Double.Parse(gia));
                        if (Double.Parse(txtThanhtoanngay.Text) > Double.Parse(txtSodu.Text) && Double.Parse(txtSodu.Text) < 0)
                        {
                            txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(Double.Parse(txtSodu.Text));
                        }
                        if (Double.Parse(txtSodu.Text) > 0)
                        {
                            txtThanhtoanngay.Text = "0";
                        }
                    }
                    if (tenForm == "TraLaiNhaCungCap")
                    {
                        string gia = DuNoNhaCungCap(txtNohienthoi.Text);
                        txtSodu.Text = new Common.Utilities().FormatMoney(Double.Parse(gia));
                        if (Double.Parse(txtThanhtoanngay.Text) > Double.Parse(txtSodu.Text) && Double.Parse(txtSodu.Text) < 0)
                        {
                            txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(Double.Parse(txtSodu.Text));
                        }
                        if (Double.Parse(txtSodu.Text) > 0)
                        {
                            txtThanhtoanngay.Text = "0";
                        }
                    }
                }
                else
                { capnhat(); }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
        }
        #endregion

        #region KhachHangTraLai
        //============================================================================================================
        #region Confilick Row
        private Entities.KhachHangTraLai ConfilickData(string table, string values)
        {
            Entities.KhachHangTraLai ddh = new Entities.KhachHangTraLai();
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TruyenGiaTri gitri = new Entities.TruyenGiaTri("Select", table, values);
                clientstrem = cl.SerializeObj(this.client, "CheckKhachHangTraLai", gitri);
                ddh = (Entities.KhachHangTraLai)cl.DeserializeHepper(clientstrem, ddh);
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                ddh = null;
            }
            return ddh;
        }
        private Boolean CheckConfick(Entities.KhachHangTraLai gitri, Entities.KhachHangTraLai sosanh)
        {
            Boolean kiemtra = false;
            try
            {
                Common.Utilities ck = new Common.Utilities();
                int count = 0;
                if (gitri.MaKhachHangTraLai != sosanh.MaKhachHangTraLai)
                { kiemtra = false; txtSodonhang.Text = sosanh.MaKhachHangTraLai; }
                else { kiemtra = true; count = count + 1; }
                if (ck.SoSanhNgay('/', "!=", gitri.NgayNhap.ToString(), sosanh.NgayNhap.ToString()) == true)
                {
                    kiemtra = false;
                    makNgaydonhang.Text = sosanh.NgayNhap.ToString("dd/MM/yyyy");
                    //string ngay = ck.KiemTraDinhDangNgayThangNam("NgayThangNam", sosanh.NgayNhap.ToString(), '/');
                    //makNgaydonhang.Text = new Common.Utilities().XuLy(2, ngay);
                }
                else { kiemtra = true; count = count + 1; }
                if (gitri.MaKhachHang != sosanh.MaKhachHang)
                { kiemtra = false; txtMakhachhang.Text = sosanh.MaKhachHang; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.NoHienThoi != sosanh.NoHienThoi)
                { kiemtra = false; txtNohienthoi.Text = sosanh.NoHienThoi.ToString(); }
                else { kiemtra = true; count = count + 1; }
                if (gitri.NguoiTra != sosanh.NguoiTra)
                { kiemtra = false; txtNguoitra.Text = sosanh.NguoiTra; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.HinhThucThanhToan != sosanh.HinhThucThanhToan)
                { kiemtra = false; cbxHinhthucthanhtoan.SelectedItem = sosanh.HinhThucThanhToan; }
                else { kiemtra = true; count = count + 1; }
                if (ck.SoSanhNgay('/', "!=", gitri.HanThanhToan.ToString(), sosanh.HanThanhToan.ToString()) == true)
                {
                    kiemtra = false;
                    makHanthanhtoan.Text = sosanh.HanThanhToan.ToString("dd/MM/yyyy");
                    //string ngay = ck.KiemTraDinhDangNgayThangNam("NgayThangNam", sosanh.HanThanhToan.ToString(), '/');
                    //makHanthanhtoan.Text = new Common.Utilities().XuLy(2, ngay);
                }
                else { kiemtra = true; count = count + 1; }
                if (gitri.MaHoaDonMuaHang != sosanh.MaHoaDonMuaHang)
                { kiemtra = false; txtChungtugoc.Text = sosanh.MaHoaDonMuaHang; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.MaKho != sosanh.MaKho)
                { kiemtra = false; cbxKhoHang.SelectedValue = sosanh.MaKho; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.MaTienTe != sosanh.MaTienTe)
                { kiemtra = false; cbxTiente_Tygia.SelectedValue = sosanh.MaTienTe; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.TienBoiThuong != sosanh.TienBoiThuong)
                { kiemtra = false; txtTongtienthanhtoan.Text = sosanh.TienBoiThuong; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.ThanhToanNgay != sosanh.ThanhToanNgay)
                { kiemtra = false; txtThanhtoanngay.Text = sosanh.ThanhToanNgay; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.ThueGTGT != sosanh.ThueGTGT)
                { kiemtra = false; txtGiatrigiatang.Text = sosanh.ThueGTGT; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.GhiChu != sosanh.GhiChu)
                { kiemtra = false; txtDiengiai.Text = sosanh.GhiChu; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.Deleted != sosanh.Deleted)
                { kiemtra = false; MessageBox.Show("Đơn hàng đã xóa"); }
                else { kiemtra = true; count = count + 1; }
                if (count < 15)
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
        #endregion
        //============================================================================================================
        #region Load
        private void LoadKhachHangTraLai()
        {
            try
            {
                frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                if (hanhDong == "Them_KhachHangTraLai")
                {
                    g = "khachhang";
                    Application.OpenForms[fr.Name].Text = "Thêm mới - F4 Thêm Hàng Hóa F5 Nhập Thanh Toán F6 Sửa Hàng Hóa";
                    getID("KhachHangTraLai");
                    txtSodonhang.Text = makiemtra;
                    toolStripStatus_Ghilai.Enabled = false;
                    rdoBanbuon.Visible = true;
                    rdoBanle.Visible = true;
                    rdoBanbuon.Checked = true;
                    rdoBanle.Checked = false;
                    toolStripStatus_In.Enabled = false;
                }
                if (hanhDong == "Sua_KhachHangTraLai")
                {
                    g = "khachhang";
                    toolStripStatus_Themmoi.Enabled = false;
                    Application.OpenForms[fr.Name].Text = "Quản lý khách hàng trả lại - Xem Chi Tiết ";
                    palNhap.Enabled = false;
                    grbDataGridview.Enabled = false;
                    palXem.Enabled = false;
                    toolStripStatus_Ghilai.Enabled = false;
                    rdoBanbuon.Visible = true;
                    rdoBanle.Visible = true;
                    rdoBanbuon.Checked = true;
                    rdoBanle.Checked = false;
                    toolStripStatus_In.Enabled = true;
                    DoDuLieu(this.update);
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion
        //============================================================================================================
        #region Xem
        private void DoDuLieu(Entities.KhachHangTraLai tralai)
        {
            try
            {
                KhachHangID = tralai.KhachHangTraLaiID;
                txtSodonhang.Text = tralai.MaKhachHangTraLai.ToString();
                makNgaydonhang.Text = new Common.Utilities().XuLy(2, tralai.NgayNhap.ToString());

                txtMakhachhang.Text = tralai.MaKhachHang.ToString();
                if (txtMakhachhang.Text == "<F4 - Tra cứu>" || txtMakhachhang.Text.Length <= 0)
                {
                    rdoBanle.Checked = true;
                }
                txtNohienthoi.Text = tralai.NoHienThoi.ToString();
                txtNguoitra.Text = tralai.NguoiTra.ToString();
                cbxHinhthucthanhtoan.SelectedItem = tralai.HinhThucThanhToan;
                makHanthanhtoan.Text = new Common.Utilities().XuLy(2, tralai.HanThanhToan.ToString());
                txtChungtugoc.Text = tralai.MaHoaDonMuaHang.ToString();
                cbxKhoHang.SelectedValue = tralai.MaKho.ToString();
                cbxTiente_Tygia.SelectedValue = tralai.MaTienTe.ToString();
                txtGiatrigiatang.Text = tralai.ThueGTGT.ToString();
                txtDiengiai.Text = tralai.GhiChu.ToString();
                txtTongtienthanhtoan.Text = tralai.TienBoiThuong;
                txtThanhtoanngay.Text = string.Empty;
                txtThanhtoanngay.Text = tralai.ThanhToanNgay;
                string tongtientrailai = (double.Parse(txtTongtienthanhtoan.Text) - double.Parse(txtThanhtoanngay.Text)).ToString();
                txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(tongtientrailai));
                LayHangHoaTheoMaKhachHangTraLai(tralai.MaKhachHangTraLai);
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void LayHangHoaTheoMaKhachHangTraLai(string makhachhangtralai)
        {
            try
            {
                string loai = loaihoadon(rdoBanbuon, rdoBanle);
                Entities.TruyenGiaTri dat = new Entities.TruyenGiaTri("Select", txtSodonhang.Text, txtMakhachhang.Text, txtChungtugoc.Text);
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "LayHangHoaTheoMaKhachHangTraLaiHang", dat);
                Entities.LayHangHoaTheoMaKhachHangTraLai[] ddh = new Entities.LayHangHoaTheoMaKhachHangTraLai[1];
                ddh = (Entities.LayHangHoaTheoMaKhachHangTraLai[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length <= 0)
                {
                    dgvXemthongtin.DataSource = null;
                    Entities.LayHangHoaTheoMaKhachHangTraLai[] hay = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                    dgvXemthongtin.DataSource = hay;
                }
                else
                {
                    dgvXemthongtin.DataSource = ddh;
                }
                fixDatagridview();
                TinhToan();
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                dgvXemthongtin.DataSource = null;
                Entities.LayHangHoaTheoMaKhachHangTraLai[] hay = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                dgvXemthongtin.DataSource = hay;
            }
        }
        #endregion
        //============================================================================================================
        #region In
        private void InThongTinKhachHangTraLai()
        {
            try
            {
                Entities.BaoCaoHoaDonNhap[] hoadon = new Entities.BaoCaoHoaDonNhap[dgvXemthongtin.RowCount];
                for (int k = 0; k < dgvXemthongtin.RowCount; k++)
                {
                    Entities.BaoCaoHoaDonNhap row = new Entities.BaoCaoHoaDonNhap
                    (
                        dgvXemthongtin.Rows[k].Cells[0].Value.ToString(),
                        dgvXemthongtin.Rows[k].Cells[1].Value.ToString(),
                        Double.Parse(dgvXemthongtin.Rows[k].Cells[3].Value.ToString()),
                        int.Parse(dgvXemthongtin.Rows[k].Cells[2].Value.ToString()),
                        int.Parse(dgvXemthongtin.Rows[k].Cells[4].Value.ToString()),
                        Double.Parse(dgvXemthongtin.Rows[k].Cells[5].Value.ToString()),
                        Double.Parse(dgvXemthongtin.Rows[k].Cells[7].Value.ToString()),
                        Double.Parse(dgvXemthongtin.Rows[k].Cells[6].Value.ToString())
                    );
                    hoadon[k] = row;
                }
                Entities.TruyenGiaTriVaoBaoCao baocao = new Entities.TruyenGiaTriVaoBaoCao();
                baocao.Giatri1 = "Hóa Đơn Khách Hàng Trả Lại";
                baocao.Giatri2 = DateServer.Date().ToString("dd/MM/yyyy");
                baocao.Giatri3 = txtSodonhang.Text;
                baocao.Giatri4 = Common.Utilities.User.TenNhanVien;
                baocao.Giatri5 = makNgaydonhang.Text;
                baocao.Giatri6 = txtMakhachhang.Text;
                baocao.Giatri7 = makHanthanhtoan.Text;
                baocao.Giatri8 = cbxKhoHang.Text;
                string chuoi = loaihoadon(rdoBanbuon, rdoBanle);
                if (chuoi == "BanBuon")
                {
                    baocao.Giatri9 = rdoBanbuon.Text;
                }
                if (chuoi == "BanLe")
                {
                    baocao.Giatri9 = rdoBanle.Text;
                }
                baocao.Giatri10 = txtChungtugoc.Text;
                baocao.Giatri11 = cbxHinhthucthanhtoan.Text;
                baocao.Giatri12 = new Common.Utilities().FormatMoney(Double.Parse(txtThanhtoanngay.Text));
                baocao.Giatri13 = new Common.Utilities().FormatMoney(Double.Parse(txtChietkhau.Text));
                baocao.Giatri14 = txtTongtienthanhtoan.Text;
                baocao.Giatri16 = txtGiatrigiatang.Text;
                baocao.Giatri17 = new Common.Utilities().FormatMoney(Double.Parse(txtConphaitra.Text));
                frmBaoCaoNhapHang frm = new frmBaoCaoNhapHang("KhachHangTraLai", hoadon, baocao, Congty(""));
                frm.ShowDialog();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion
        //============================================================================================================
        #region Insert
        #region Validate
        private Boolean CheckData(Entities.KhachHangTraLai dat)
        {
            Boolean kt = false;
            try
            {
                if (dat.MaKhachHangTraLai.Length <= 0)
                {
                    txtSodonhang.Focus();
                    System.Windows.Forms.MessageBox.Show("Hãy nhập mã hóa đơn");
                    kt = false;
                }
                else
                {
                    if (rdoBanle.Checked)
                    {
                        if (dat.MaKhachHang.Equals("") || dat.MaKhachHang.Equals("<F4 - Tra cứu>"))
                        {
                            txtMakhachhang.Text = "NULL";
                        }
                        if (dat.MaKho.Length <= 0)
                        {
                            cbxKhoHang.Focus();
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
                                if (dat.MaHoaDonMuaHang.Length <= 0)
                                {
                                    txtChungtugoc.Focus();
                                    System.Windows.Forms.MessageBox.Show("Hãy nhập mã đơn nhập mua");
                                    kt = false;
                                }
                                else
                                {
                                    kt = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dat.MaKhachHang.Length <= 0)
                        {
                            txtMakhachhang.Focus();
                            MessageBox.Show("Kiểm tra mã khách hàng");
                            kt = false;
                        }
                        else
                        {
                            if (dat.MaKho.Length <= 0)
                            {
                                cbxKhoHang.Focus();
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
                                    if (dat.MaHoaDonMuaHang.Length <= 0)
                                    {
                                        txtChungtugoc.Focus();
                                        System.Windows.Forms.MessageBox.Show("Hãy nhập mã đơn nhập mua");
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
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return kt;
        }
        #endregion
        #region UpdateDuNo
        private int CapNhatDuNoKhachHang()
        {
            int bao = 0;
            double tongTienThanhToan = 0;
            double tongtienHoaDon = 0;
            double noHienThoi = 0;
            try
            {
                if (!string.IsNullOrEmpty(txtTongtienthanhtoan.Text))
                    tongtienHoaDon = double.Parse(txtTongtienthanhtoan.Text);

                if (!string.IsNullOrEmpty(txtThanhtoanngay.Text))
                    tongTienThanhToan = double.Parse(txtThanhtoanngay.Text);

                if (tongTienThanhToan > tongtienHoaDon)
                    noHienThoi = 0;
                else
                    noHienThoi = tongTienThanhToan - tongtienHoaDon;

                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TruyenGiaTri luu = new Entities.TruyenGiaTri("Update", txtMakhachhang.Text, noHienThoi.ToString());
                clientstrem = cl.SerializeObj(this.client, "CapNhatDuNoKhachHang", luu);
                bao = (int)cl.DeserializeHepper(clientstrem, bao);
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return bao;
        }
        #endregion
        #region ChiTietKhachHangTraLai
        public Entities.ChiTietKhachHangTraLai[] LuuChiTietKhachHangTraLai(DataGridView dgv, string hanhdong, string madondathang, string makho)
        {
            Entities.ChiTietKhachHangTraLai[] mangBanghi = null;
            try
            {
                ArrayList arr = new ArrayList();
                int i = dgv.RowCount;

                if (i > 0)
                {
                    for (int x = 0; x < i; x++)
                    {
                        Entities.ChiTietKhachHangTraLai banghi = new Entities.ChiTietKhachHangTraLai();
                        banghi.Hanhdong = hanhdong;
                        banghi.MaKhachHangTraLai = madondathang;
                        banghi.MaHangHoa = dgv.Rows[x].Cells[0].Value.ToString().ToUpper();
                        banghi.TenHangHoa = dgv.Rows[x].Cells["TenHangHoa"].Value.ToString();
                        banghi.SoLuong = System.Convert.ToInt32(dgv.Rows[x].Cells[2].Value.ToString());
                        banghi.PhanTramChietKhau = dgv.Rows[x].Cells[4].Value.ToString();
                        banghi.DonGia = dgv.Rows[x].Cells["Giaban"].Value.ToString();
                        banghi.Thue = dgv.Rows[x].Cells["Thuegiatrigiatang"].Value.ToString();
                        banghi.GhiChu = txtDiengiai.Text;
                        banghi.Deleted = false;
                        banghi.Makho = makho;
                        arr.Add(banghi);
                    }
                    int n = arr.Count;
                    if (n == 0) { return null; }
                    mangBanghi = new Entities.ChiTietKhachHangTraLai[n];
                    for (int j = 0; j < n; j++)
                    {
                        mangBanghi[j] = (Entities.ChiTietKhachHangTraLai)arr[j];
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
        private void LuuChiTietKhachHangTraLai()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.ChiTietKhachHangTraLai[] luu = LuuChiTietKhachHangTraLai(dgvXemthongtin, "Insert", txtSodonhang.Text, cbxKhoHang.SelectedValue.ToString());
                clientstrem = cl.SerializeHepper(this.client, "ChiTietKhachHangTraLai", luu);
                int bao = 0;
                bao = (int)cl.DeserializeHepper(clientstrem, bao);
                if (bao <= 0)
                {
                    DeleteData(txtSodonhang.Text);
                    MessageBox.Show("Thất bại");
                }
                else
                { this.Close(); }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion
        #region XuLy
        private void XuLy_KhachHangTraLai(string hanhdong)
        {
            try
            {
                Entities.KhachHangTraLai xuly = new Entities.KhachHangTraLai();
                Common.Utilities ck = new Common.Utilities();

                //Mrk Fix 3/2/2013
                string _makNgaydonhang = makNgaydonhang.Text;
                string _makHanthanhtoan = makHanthanhtoan.Text;
                //if (string.IsNullOrEmpty(_makNgaydonhang))
                //{
                //    MessageBox.Show("Vui lòng kiểm tra lại ngày đơn hàng! \r\nkhông được phép rỗng!");
                //    return;
                //}
                //else if (string.IsNullOrEmpty(_makHanthanhtoan))
                //{
                //    MessageBox.Show("Vui lòng kiểm tra lại Hạn thanh toán! \r\nkhông được phép rỗng!");
                //    return;
                //}
                string[] temp_makNgaydonhang = _makNgaydonhang.Split('/');
                string[] temp_makHanthanhtoan = _makHanthanhtoan.Split('/');
                DateTime temp_date1 = new DateTime(int.Parse(temp_makNgaydonhang[2]), int.Parse(temp_makNgaydonhang[1]), int.Parse(temp_makNgaydonhang[0]));
                DateTime temp_date11 = new DateTime(int.Parse(temp_makHanthanhtoan[2]), int.Parse(temp_makHanthanhtoan[1]), int.Parse(temp_makHanthanhtoan[0]));
                DateTime temp_date2 = DateServer.Date();
                if (temp_date1.Date >= temp_date2.Date)
                {
                    xuly.NgayNhap = temp_date1;
                    xuly.HanThanhToan = temp_date11;
                    ///////////////////////////////////////////////////////

                    //string thoigian_1 = makNgaydonhang.Text;
                    //string thoigian_2 = makHanthanhtoan.Text;
                    //string thoigian_sosanh = DateServer.Date().ToString("dd/MM/yyyy");
                    //if (ck.SoSanhNgay('/', ">=", thoigian_1, thoigian_sosanh) == true)
                    //{
                    //xuly.NgayNhap = DateTime.Parse(new Common.Utilities().KiemTraDinhDangNgayThangNam("ThangNgayNam", thoigian_1, '/'));
                    //thoigian_1 = null;
                    //xuly.HanThanhToan = DateTime.Parse(new Common.Utilities().KiemTraDinhDangNgayThangNam("ThangNgayNam", thoigian_2, '/'));
                    //thoigian_2 = null;
                    xuly.Hanhdong = hanhdong;
                    xuly.KhachHangTraLaiID = KhachHangID;
                    xuly.MaKhachHangTraLai = txtSodonhang.Text;
                    string maKH = txtMakhachhang.Text;
                    if (maKH.ToUpper().Equals("<F4 - TRA CỨU>"))
                        maKH = string.Empty;

                    xuly.MaKhachHang = maKH;
                    xuly.NoHienThoi = txtNohienthoi.Text;
                    xuly.NguoiTra = "" + txtNguoitra.Text;
                    xuly.HinhThucThanhToan = cbxHinhthucthanhtoan.SelectedItem.ToString();
                    string ma = txtChungtugoc.Text;
                    if (ma.ToUpper().Equals("<F4 - TRA CỨU>") || ma.Length <= 0)
                    {
                        ma = string.Empty;
                    }
                    xuly.MaHoaDonMuaHang = ma;
                    xuly.MaKho = cbxKhoHang.SelectedValue.ToString();
                    xuly.MaTienTe = cbxTiente_Tygia.SelectedValue.ToString();
                    xuly.TienBoiThuong = txtTongtienthanhtoan.Text;
                    string tnn = "0";
                    if (txtThanhtoanngay.Text == "")
                        tnn = "0";
                    else
                        tnn = txtThanhtoanngay.Text;
                    if (Double.Parse(tnn) < 0)
                    {
                        xuly.ThanhToanNgay = "0";
                    }
                    else
                    {
                        xuly.ThanhToanNgay = tnn;
                    }
                    xuly.ThueGTGT = txtGiatrigiatang.Text;
                    xuly.GhiChu = "" + txtDiengiai.Text;
                    xuly.Deleted = false;

                    xuly.Manhanvien = Common.Utilities.User.NhanVienID;
                    xuly.Tendangnhap = Common.Utilities.User.TenDangNhap;

                    if (dgvXemthongtin.RowCount > 0)
                    {
                        if (CheckData(xuly) == true)
                        {
                            cl = new Server_Client.Client();
                            this.client = cl.Connect(Luu.IP, Luu.Ports);
                            clientstrem = cl.SerializeObj(this.client, "KhachHangTraLai", xuly);
                            Entities.KhachHangTraLai[] tralai = new Entities.KhachHangTraLai[1];
                            int trave = System.Convert.ToInt32(cl.DeserializeHepper(clientstrem, tralai));
                            if (trave >= 1)
                            {
                                if (rdoBanbuon.Checked == true)
                                {
                                    if (CapNhatDuNoKhachHang() >= 1)
                                    {
                                        LuuChiTietKhachHangTraLai();
                                    }
                                    else
                                    { MessageBox.Show("Chưa cập nhập dư nợ khách hàng"); }
                                }
                                else
                                {
                                    LuuChiTietKhachHangTraLai();
                                }
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
                else
                { MessageBox.Show("Kiểm tra ngày"); }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                MessageBox.Show("Thất bại");
            }
        }
        #endregion
        #endregion
        //============================================================================================================
        #endregion

        #region TraLaiNhaCungCap
        //============================================================================================================
        #region Confilick Row
        private Entities.TraLaiNCC ConfilickDataTraLaiNhaCungcap(string table, string values)
        {
            Entities.TraLaiNCC ddh = new Entities.TraLaiNCC();
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TruyenGiaTri gitri = new Entities.TruyenGiaTri("Select", table, values);
                clientstrem = cl.SerializeObj(this.client, "CheckTraLaiNhaCungCap", gitri);
                ddh = (Entities.TraLaiNCC)cl.DeserializeHepper(clientstrem, ddh);
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                ddh = null;
            }
            return ddh;
        }
        private Boolean CheckConfickTraLaiNhaCungCap(Entities.TraLaiNCC gitri, Entities.TraLaiNCC sosanh)
        {
            Boolean kiemtra = false;
            try
            {
                Common.Utilities ck = new Common.Utilities();
                int count = 0;
                if (gitri.MaHDTraLaiNCC != sosanh.MaHDTraLaiNCC)
                { kiemtra = false; txtSodonhang.Text = sosanh.MaHDTraLaiNCC; }
                else { kiemtra = true; count = count + 1; }
                if (ck.SoSanhNgay('/', "!=", gitri.Ngaytra.ToString(), sosanh.Ngaytra.ToString()) == true)
                {
                    kiemtra = false;
                    makNgaydonhang.Text = sosanh.Ngaytra.ToString("dd/MM/yyyy");
                    //string ngay = ck.KiemTraDinhDangNgayThangNam("NgayThangNam", sosanh.Ngaytra.ToString(), '/');
                    //makNgaydonhang.Text = new Common.Utilities().XuLy(2, ngay);
                }
                else { kiemtra = true; count = count + 1; }
                if (gitri.MaNCC != sosanh.MaNCC)
                { kiemtra = false; txtMakhachhang.Text = sosanh.MaNCC; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.NoHienThoi != sosanh.NoHienThoi)
                { kiemtra = false; txtNohienthoi.Text = sosanh.NoHienThoi.ToString(); }
                else { kiemtra = true; count = count + 1; }
                if (gitri.NguoiNhanHang != sosanh.NguoiNhanHang)
                { kiemtra = false; txtNguoitra.Text = sosanh.NguoiNhanHang; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.HinhThucThanhToan != sosanh.HinhThucThanhToan)
                { kiemtra = false; cbxHinhthucthanhtoan.SelectedItem = sosanh.HinhThucThanhToan; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.MaHoaDonNhap != sosanh.MaHoaDonNhap)
                { kiemtra = false; txtChungtugoc.Text = sosanh.MaHoaDonNhap; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.MaKho != sosanh.MaKho)
                { kiemtra = false; cbxKhoHang.SelectedValue = sosanh.MaKho; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.MaTienTe != sosanh.MaTienTe)
                { kiemtra = false; cbxTiente_Tygia.SelectedValue = sosanh.MaTienTe; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.TienBoiThuong != sosanh.TienBoiThuong)
                { kiemtra = false; txtTongtienthanhtoan.Text = sosanh.TienBoiThuong; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.ThanhToanNgay != sosanh.ThanhToanNgay)
                { kiemtra = false; txtThanhtoanngay.Text = sosanh.ThanhToanNgay; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.ThueGTGT != sosanh.ThueGTGT)
                { kiemtra = false; txtGiatrigiatang.Text = sosanh.ThueGTGT; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.GhiChu != sosanh.GhiChu)
                { kiemtra = false; txtDiengiai.Text = sosanh.GhiChu; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.Deleted != sosanh.Deleted)
                { kiemtra = false; MessageBox.Show("Đơn hàng đã xóa"); }
                else { kiemtra = true; count = count + 1; }
                if (count < 14)
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
        #endregion
        //============================================================================================================
        #region Load
        private void LoadTraLaiNhaCungCap()
        {
            try
            {
                frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                if (hanhDong == "Them_TraLaiNhaCungCap")
                {
                    g = "cungcap";
                    rdoBanbuon.Visible = false;
                    rdoBanle.Visible = false;
                    makHanthanhtoan.Visible = false;
                    lblHanthanhtoan.Visible = false;
                    label6.Visible = false;
                    toolStripStatus_Ghilai.Enabled = false;
                    lblMakhachhang.Text = "Mã nhà cung cấp:";
                    lblChungtugoc.Text = "Mã hóa đơn nhập:";
                    lblNguoitrahang.Text = "Người nhận hàng:";
                    Application.OpenForms[fr.Name].Text = "Thêm mới - F4 Thêm Hàng Hóa F5 Nhập Thanh Toán F6 Sửa Hàng Hóa";
                    getID("TraLaiNCC");
                    txtSodonhang.Text = makiemtra;
                    toolStripStatus_In.Enabled = false;
                }
                if (hanhDong == "Sua_TraLaiNhaCungCap")
                {
                    g = "cungcap";
                    rdoBanbuon.Visible = false;
                    rdoBanle.Visible = false;
                    makHanthanhtoan.Visible = false;
                    lblHanthanhtoan.Visible = false;
                    toolStripStatus_Themmoi.Enabled = false;
                    lblMakhachhang.Text = "Mã nhà cung cấp:";
                    lblChungtugoc.Text = "Mã hóa đơn nhập:";
                    label6.Visible = false;
                    toolStripStatus_Themmoi.Enabled = false;
                    Application.OpenForms[fr.Name].Text = "Quản lý trả lại nhà cung cấp - Xem Chi Tiết Hóa Đơn";
                    DoDuLieuNhaCungcap(this.ncctra);
                    palNhap.Enabled = false;
                    grbDataGridview.Enabled = false;
                    palXem.Enabled = false;
                    toolStripStatus_Ghilai.Enabled = false;
                    toolStripStatus_In.Enabled = true;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion
        //============================================================================================================
        #region Xem
        private void DoDuLieuNhaCungcap(Entities.TraLaiNCC tralai)
        {
            try
            {
                NhaCungCapID = tralai.TraLaiNCCID;
                txtSodonhang.Text = tralai.MaHDTraLaiNCC.ToString();
                makNgaydonhang.Text = new Common.Utilities().XuLy(2, tralai.Ngaytra.ToString());
                txtMakhachhang.Text = tralai.MaNCC.ToString();
                txtNohienthoi.Text = tralai.NoHienThoi.ToString();
                txtNguoitra.Text = tralai.NguoiNhanHang.ToString();
                cbxHinhthucthanhtoan.SelectedItem = tralai.HinhThucThanhToan;
                GiaTriCanLuu.Ma = tralai.MaHoaDonNhap.ToString();
                txtChungtugoc.Text = tralai.MaHoaDonNhap.ToString();
                cbxKhoHang.SelectedValue = tralai.MaKho.ToString();
                cbxTiente_Tygia.SelectedValue = tralai.MaTienTe.ToString();
                txtTongtienthanhtoan.Text = tralai.TienBoiThuong.ToString();
                txtGiatrigiatang.Text = tralai.ThueGTGT.ToString();
                txtDiengiai.Text = tralai.GhiChu.ToString();
                LayHangHoaTheoMaTraLaiNhaCungCap(tralai.MaHDTraLaiNCC);
                txtThanhtoanngay.Text = string.Empty;
                txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(Double.Parse(tralai.ThanhToanNgay));
                string tongtientrailai = (double.Parse(txtTongtienthanhtoan.Text) - double.Parse(txtThanhtoanngay.Text)).ToString();
                txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(tongtientrailai));
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void LayHangHoaTheoMaTraLaiNhaCungCap(string matralainhacungcap)
        {
            try
            {
                string loai = loaihoadon(rdoBanbuon, rdoBanle);
                Entities.TruyenGiaTri dat = new Entities.TruyenGiaTri("Select", matralainhacungcap);
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "LayHangHoaTheoMaTraLaiNhaCungCap", dat);
                Entities.LayHangHoaTheoMaKhachHangTraLai[] ddh = new Entities.LayHangHoaTheoMaKhachHangTraLai[1];
                ddh = (Entities.LayHangHoaTheoMaKhachHangTraLai[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length <= 0)
                {
                    dgvXemthongtin.DataSource = null;
                    Entities.LayHangHoaTheoMaKhachHangTraLai[] hay = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                    dgvXemthongtin.DataSource = hay;
                }
                else
                {
                    dgvXemthongtin.DataSource = ddh;
                }
                fixDatagridview();
                TinhToan();
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString(); dgvXemthongtin.DataSource = null;
                Entities.LayHangHoaTheoMaKhachHangTraLai[] hay = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                dgvXemthongtin.DataSource = hay;
            }
        }
        #endregion
        //============================================================================================================
        #region In
        private void InThongTinTraLaiNhaCungCap()
        {
            try
            {
                Entities.BaoCaoHoaDonNhap[] hoadon = new Entities.BaoCaoHoaDonNhap[dgvXemthongtin.RowCount];
                for (int k = 0; k < dgvXemthongtin.RowCount; k++)
                {
                    Entities.BaoCaoHoaDonNhap row = new Entities.BaoCaoHoaDonNhap
                    (
                        dgvXemthongtin.Rows[k].Cells[0].Value.ToString(),
                        dgvXemthongtin.Rows[k].Cells[1].Value.ToString(),
                        Double.Parse(dgvXemthongtin.Rows[k].Cells[3].Value.ToString()),
                        int.Parse(dgvXemthongtin.Rows[k].Cells[2].Value.ToString()),
                        int.Parse(dgvXemthongtin.Rows[k].Cells[4].Value.ToString()),
                        Double.Parse(dgvXemthongtin.Rows[k].Cells[5].Value.ToString()),
                        Double.Parse(dgvXemthongtin.Rows[k].Cells[7].Value.ToString()),
                        Double.Parse(dgvXemthongtin.Rows[k].Cells[6].Value.ToString())
                    );
                    hoadon[k] = row;
                }
                Entities.TruyenGiaTriVaoBaoCao baocao = new Entities.TruyenGiaTriVaoBaoCao();
                baocao.Giatri1 = "Hóa Đơn Trả Lại Nhà Cung Cấp";
                baocao.Giatri2 = DateServer.Date().ToString("dd/MM/yyyy");
                baocao.Giatri3 = txtSodonhang.Text;
                baocao.Giatri4 = Common.Utilities.User.TenNhanVien;
                baocao.Giatri5 = makNgaydonhang.Text;
                baocao.Giatri6 = txtMakhachhang.Text;
                baocao.Giatri7 = makHanthanhtoan.Text;
                baocao.Giatri8 = cbxKhoHang.Text;
                string chuoi = loaihoadon(rdoBanbuon, rdoBanle);
                if (chuoi == "BanBuon")
                {
                    baocao.Giatri9 = rdoBanbuon.Text;
                }
                if (chuoi == "BanLe")
                {
                    baocao.Giatri9 = rdoBanle.Text;
                }
                baocao.Giatri10 = txtChungtugoc.Text;
                baocao.Giatri11 = cbxHinhthucthanhtoan.Text;
                baocao.Giatri12 = new Common.Utilities().FormatMoney(Double.Parse(txtThanhtoanngay.Text));
                baocao.Giatri13 = new Common.Utilities().FormatMoney(Double.Parse(txtChietkhau.Text));
                baocao.Giatri14 = txtTongtienthanhtoan.Text;
                baocao.Giatri16 = txtGiatrigiatang.Text;
                baocao.Giatri17 = new Common.Utilities().FormatMoney(Double.Parse(txtConphaitra.Text));
                frmBaoCaoNhapHang frm = new frmBaoCaoNhapHang("TraLaiNhaCungCap", hoadon, baocao, Congty(""));
                frm.ShowDialog();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        #endregion
        //============================================================================================================
        #region Insert
        #region Validate
        private Boolean CheckDataNhaCungCap(Entities.TraLaiNCC xuly)
        {
            Boolean kt = false;
            try
            {
                if (xuly.MaHoaDonNhap == "<F4 - Tra cứu>" && xuly.MaHoaDonNhap == "")
                {
                    kt = false;
                    MessageBox.Show("Phải mã đơn mua hàng");
                }

                if (xuly.MaHDTraLaiNCC == "" && xuly.MaHDTraLaiNCC == "<F4 - Tra cứu>")
                {
                    kt = false; MessageBox.Show("Phải nhập mã đơn trả lại nhà cung cấp");
                }

                if (xuly.MaKho == null)
                {
                    kt = false; MessageBox.Show("Phải nhập mã kho hàng");
                }

                if (xuly.MaNCC == null)
                {
                    kt = false; MessageBox.Show("Phải nhập mã nhà cung cấp");
                }

                if (xuly.MaTienTe == null)
                {
                    kt = false; MessageBox.Show("Phải nhập mã tiền tệ");
                }

                if (xuly.HinhThucThanhToan == null)
                {
                    kt = false; MessageBox.Show("Phải nhập hình thức thanh toán");
                }
                else
                {
                    kt = true;
                }

            }
            catch (Exception ex)
            { string s = ex.Message; }
            return kt;
        }
        #endregion
        #region UpdateDuNo
        private int CapNhatDuNoNhaCungCap()
        {
            int bao = 0;
            double tongTienThanhToan = 0;
            double tongtienHoaDon = 0;
            double noHienThoi = 0;
            try
            {
                if (!string.IsNullOrEmpty(txtTongtienthanhtoan.Text))
                    tongtienHoaDon = double.Parse(txtTongtienthanhtoan.Text);

                if (!string.IsNullOrEmpty(txtThanhtoanngay.Text))
                    tongTienThanhToan = double.Parse(txtThanhtoanngay.Text);

                if (tongTienThanhToan > tongtienHoaDon)
                    noHienThoi = 0;
                else
                    noHienThoi = tongTienThanhToan - tongtienHoaDon;

                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TruyenGiaTri luu = new Entities.TruyenGiaTri("Update", txtMakhachhang.Text, noHienThoi.ToString());
                clientstrem = cl.SerializeObj(this.client, "CapNhatDuNoNhaCungCap", luu);
                bao = (int)cl.DeserializeHepper(clientstrem, bao);
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return bao;
        }
        #endregion
        #region ChiTietNhaCungCap
        public Entities.ChiTietTraLaiNhaCungCap[] ChiTietTraLaiNhaCungCap(DataGridView dgv, string hanhdong, string madondathang, string makho)
        {
            Entities.ChiTietTraLaiNhaCungCap[] mangBanghi = null;
            try
            {
                ArrayList arr = new ArrayList();
                int i = dgv.RowCount;
                if (i > 0)
                {
                    for (int x = 0; x < i; x++)
                    {
                        Entities.ChiTietTraLaiNhaCungCap banghi = new Entities.ChiTietTraLaiNhaCungCap();
                        banghi.Hanhdong = hanhdong;
                        banghi.MaHDTraLaiNCC = madondathang;
                        banghi.MaHangHoa = dgv.Rows[x].Cells[0].Value.ToString().ToUpper();
                        banghi.SoLuong = int.Parse(dgv.Rows[x].Cells["SoLuong"].Value.ToString());
                        banghi.DonGia = dgv.Rows[x].Cells["GiaBan"].Value.ToString();
                        banghi.Thue = dgv.Rows[0].Cells[7].Value.ToString();
                        banghi.PhanTramChietKhau = dgv.Rows[x].Cells["PhanTramChietKhau"].Value.ToString();
                        banghi.GhiChu = dgv.Rows[x].Cells[1].Value.ToString();
                        banghi.Deleted = false;
                        banghi.Makho = makho;
                        arr.Add(banghi);
                    }
                    int n = arr.Count;
                    if (n == 0) { return null; }
                    mangBanghi = new Entities.ChiTietTraLaiNhaCungCap[n];
                    for (int j = 0; j < n; j++)
                    {
                        mangBanghi[j] = (Entities.ChiTietTraLaiNhaCungCap)arr[j];
                    }
                }
                else
                {
                    mangBanghi = null;
                    mangBanghi = null;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return mangBanghi;
        }
        #endregion
        #region XuLy
        private void XuLy_TraLaiNhaCungCap(string hanhdong)
        {
            try
            {
                Entities.TraLaiNCC xuly = new Entities.TraLaiNCC();
                Common.Utilities ck = new Common.Utilities();

                //Mrk Fix 3/2/2013
                string _makNgaydonhang = makNgaydonhang.Text;
                if (string.IsNullOrEmpty(_makNgaydonhang))
                {
                    MessageBox.Show("Vui lòng kiểm tra lại ngày! \r\nkhông được phép rỗng!");
                    return;
                }
                string[] temp = _makNgaydonhang.Split('/');
                DateTime temp_date1 = new DateTime(int.Parse(temp[2]), int.Parse(temp[1]), int.Parse(temp[0]));
                DateTime temp_date2 = DateServer.Date();
                if (temp_date1.Date >= temp_date2.Date)
                {
                    xuly.Ngaytra = temp_date1;
                    ///////////////////////////////////////////////////////

                    //string thoigian_1 = makNgaydonhang.Text;
                    //string thoigian_sosanh = DateServer.Date().ToString("dd/MM/yyyy");
                    //if (ck.SoSanhNgay('/', ">=", thoigian_1, thoigian_sosanh) == true && thoigian_1 != null)
                    //{
                    //xuly.Ngaytra = DateTime.Parse(new Common.Utilities().KiemTraDinhDangNgayThangNam("ThangNgayNam", thoigian_1, '/'));
                    //thoigian_1 = null;
                    xuly.Hanhdong = hanhdong;
                    xuly.TraLaiNCCID = NhaCungCapID;
                    xuly.MaHDTraLaiNCC = txtSodonhang.Text;
                    xuly.NoHienThoi = txtNohienthoi.Text;
                    xuly.MaNCC = txtMakhachhang.Text;
                    xuly.NguoiNhanHang = "" + txtNguoitra.Text;
                    xuly.HinhThucThanhToan = cbxHinhthucthanhtoan.SelectedItem.ToString();
                    xuly.MaHoaDonNhap = txtChungtugoc.Text;
                    xuly.MaKho = cbxKhoHang.SelectedValue.ToString();
                    xuly.MaTienTe = cbxTiente_Tygia.SelectedValue.ToString();
                    xuly.TienBoiThuong = txtTongtienthanhtoan.Text;
                    xuly.ThanhToanNgay = Double.Parse(0 + txtThanhtoanngay.Text).ToString();
                    xuly.ThueGTGT = 0 + txtGiatrigiatang.Text;
                    xuly.GhiChu = "" + txtDiengiai.Text;
                    xuly.Deleted = false;
                    xuly.Manhanvien = Common.Utilities.User.NhanVienID;
                    xuly.Tendangnhap = Common.Utilities.User.TenDangNhap;
                    if (dgvXemthongtin.RowCount > 0)
                    {
                        if (CheckDataNhaCungCap(xuly) == true)
                        {
                            cl = new Server_Client.Client();
                            this.client = cl.Connect(Luu.IP, Luu.Ports);
                            clientstrem = cl.SerializeObj(this.client, "TraLaiNhaCungCap", xuly);
                            Entities.KhachHangTraLai[] tralai = new Entities.KhachHangTraLai[1];
                            int trave = System.Convert.ToInt32(cl.DeserializeHepper(clientstrem, tralai));
                            if (trave == 1)
                            {
                                if (CapNhatDuNoNhaCungCap() >= 1)
                                {
                                    LuuChiTietTraLaiNhaCungCap();
                                }
                                else
                                { MessageBox.Show("Chưa cập nhật dư nợ nhà cung cấp"); }
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
                else
                { MessageBox.Show("Kiểm tra ngày"); }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                MessageBox.Show("Thông tin nhập không đúng");
            }
        }
        #endregion
        #endregion
        //============================================================================================================
        #endregion


        #region Trả lại nhà cung cấp
        private void SelectChiTietTraLaiNhaCungCap(string hanhdong)
        {
            Entities.DonDatHang pt = new Entities.DonDatHang();
            pt = new Entities.DonDatHang(hanhdong);
            Entities.ChiTietTraLaiNhaCungCap[] pt1 = new Entities.ChiTietTraLaiNhaCungCap[10];
            clientstrem = cl.SerializeObj(this.client, "ChiTietTraLaiNCC", pt);
            Binding((Entities.ChiTietTraLaiNhaCungCap[])cl.DeserializeHepper(clientstrem, pt1));
        }
        private void Binding(Entities.ChiTietTraLaiNhaCungCap[] data)
        {
            try
            {
                dgvXemthongtin.DataSource = null;
                dgvXemthongtin.DataSource = data;
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
        }

        private void XuLy_Xoa_TraLaiNhaCungCap(string hanhdong, string matralainhacungcap)
        {
            Entities.TraLaiNCC them = new Entities.TraLaiNCC();
            them = new Entities.TraLaiNCC(hanhdong, matralainhacungcap);
            clientstrem = cl.SerializeObj(this.client, "TraLaiNCC", them);
            //hứng giá trị trả về
            int trave;
            Entities.TraLaiNCC[] tralai = new Entities.TraLaiNCC[1];
            trave = (int)cl.DeserializeHepper(clientstrem, tralai);
            //thong bao
            if (trave != 0)
            { MessageBox.Show("Thành công !"); }
            else
            { MessageBox.Show("Thất bại !"); }
        }
        #endregion

        #region khách hàng trả lại
        private void SelectChiTietKhachHangTraLai(string hanhdong)
        {
            Entities.DonDatHang pt = new Entities.DonDatHang();
            pt = new Entities.DonDatHang(hanhdong);
            Entities.ChiTietKhachHangTraLai[] pt1 = new Entities.ChiTietKhachHangTraLai[10];
            clientstrem = cl.SerializeObj(this.client, "ChiTietKhachHangTraLai", pt);

            Binding((Entities.ChiTietKhachHangTraLai[])cl.DeserializeHepper(clientstrem, pt1));
        }

        private void Binding(Entities.ChiTietKhachHangTraLai[] data)
        {
            try
            {
                dgvXemthongtin.DataSource = null;
                dgvXemthongtin.DataSource = data;
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
        }

        private void XuLy_Xoa_KhachHangTraLai(string hanhdong, string makhachhangtralai)
        {
            Entities.KhachHangTraLai them = new Entities.KhachHangTraLai();
            them = new Entities.KhachHangTraLai(hanhdong, makhachhangtralai);
            clientstrem = cl.SerializeObj(this.client, "KhachHangTraLai", them);
            //hứng giá trị trả về
            int trave;
            Entities.KhachHangTraLai[] tralai = new Entities.KhachHangTraLai[1];
            trave = (int)cl.DeserializeHepper(clientstrem, tralai);
            //thong bao
            if (trave == 1)
            { MessageBox.Show("Thành công !"); }
            else
            { MessageBox.Show("Thất bại !"); }
        }
        #endregion

        #region LayHangHoa
        private void LayHangHoaTheoMaHoaDonNhap(string ma)
        {
            try
            {
                Entities.TruyenGiaTri dat = new Entities.TruyenGiaTri("Select", "", ma);
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "TimHangHoaTheoMaHoaDonNhap", dat);
                Entities.LayHangHoaTheoMaKhachHangTraLai[] ddh = new Entities.LayHangHoaTheoMaKhachHangTraLai[1];
                ddh = (Entities.LayHangHoaTheoMaKhachHangTraLai[])cl.DeserializeHepper(clientstrem, ddh);
                dgvXemthongtin.DataSource = ddh;
                dgvXemthongtin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvXemthongtin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }

        private void LayHangHoaTheoMaHoaDonBanHang(string ma)
        {
            try
            {
                string loai = loaihoadon(rdoBanbuon, rdoBanle);
                Entities.TruyenGiaTri dat = new Entities.TruyenGiaTri("Select", "", ma, loai);
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "LayHangHoaTheoMaHoaDonBanHang", dat);
                Entities.LayHangHoaTheoMaKhachHangTraLai[] ddh = new Entities.LayHangHoaTheoMaKhachHangTraLai[1];
                ddh = (Entities.LayHangHoaTheoMaKhachHangTraLai[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();

                if (ddh.Length <= 0)
                {
                    dgvXemthongtin.DataSource = null;
                    Entities.LayHangHoaTheoMaKhachHangTraLai[] hay = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                    dgvXemthongtin.DataSource = hay;
                }
                else
                { dgvXemthongtin.DataSource = ddh; }
                fixDatagridview();

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString(); dgvXemthongtin.DataSource = null;
                Entities.LayHangHoaTheoMaKhachHangTraLai[] hay = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                dgvXemthongtin.DataSource = hay; fixDatagridview();
            }
        }
        #endregion

        #region FormLoad
        private string g = "";
        private void frmXuLy_KhachHangTraLaiHang_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    format();
                    fixDatagridview();
                }
                catch { }
                makNgaydonhang.Text = DateServer.Date().ToString("dd/MM/yyyy");
                makHanthanhtoan.Text = DateServer.Date().ToString("dd/MM/yyyy");
                this.cbxHinhthucthanhtoan.Items.AddRange(new object[] { "Tiền mặt", "ATM" });
                cbxHinhthucthanhtoan.SelectedIndex = 0;
                try
                {
                    LayTenTT();
                    txtGiatien.Text = tigia[0].Giatri2.ToString();
                }
                catch { }
                try
                {
                    new Common.Utilities().ComboxKhoHang(cbxKhoHang);
                }
                catch { }
                switch (this.tenForm)
                {
                    case "KhachHangTraLai":
                        this.LoadKhachHangTraLai();
                        break;
                    case "TraLaiNhaCungCap":
                        this.LoadTraLaiNhaCungCap();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                if (txtSodonhang.Text == "")
                {
                    if (hanhDong == "Them_KhachHangTraLai")
                    {
                        txtSodonhang.Text = makiemtra;
                    }
                    if (hanhDong == "Them_TraLaiNhaCungCap")
                    {
                        txtSodonhang.Text = makiemtra;
                    }
                }
            }
        }
        #endregion

        #region ChungTu
        private void TimChungTuKhachHang()
        {
            GiaTriCanLuu.Giatri = loaihoadon(rdoBanbuon, rdoBanle);
            if (GiaTriCanLuu.Giatri == "BanBuon")
            {
                if (txtMakhachhang.Text != "<F4 - Tra cứu>" && txtMakhachhang.Text.Length > 0)
                {
                    Entities.LayHangHoaTheoMaKhachHangTraLai[] lay = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                    dgvXemthongtin.DataSource = lay;
                    fixDatagridview();
                    ResetTool();
                    string makho = cbxKhoHang.SelectedValue.ToString();
                    frmTraCuu fr = new frmTraCuu("HangTraLai_KhachHangTraLai_MaDonHang", "HoaDonBanHang", txtMakhachhang.Text, makho, "");
                    fr.ShowDialog();
                    Binding();
                }
                else
                { MessageBox.Show("Nhập khách hàng"); txtMakhachhang.Focus(); }
            }
            else
            {
                string makh = "";
                if (txtMakhachhang.Text == "<F4 - Tra cứu>" || txtMakhachhang.Text.Length <= 0)
                    makh = "";
                else
                    makh = txtMakhachhang.Text;
                Entities.LayHangHoaTheoMaKhachHangTraLai[] lay = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                dgvXemthongtin.DataSource = lay;
                fixDatagridview();
                ResetTool();
                string makho = cbxKhoHang.SelectedValue.ToString();
                frmTraCuu fr = new frmTraCuu("HangTraLai_KhachHangTraLai_MaDonHang", "HoaDonBanHang", makh, makho, "");
                fr.ShowDialog();
                Binding();
            }
        }
        private void TimChungTuNhaCungCap()
        {
            if (txtMakhachhang.Text != "<F4 - Tra cứu>" && txtMakhachhang.Text.Length > 0)
            {
                Entities.LayHangHoaTheoMaKhachHangTraLai[] lay = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                dgvXemthongtin.DataSource = lay;
                fixDatagridview();
                ResetTool();
                string makho = cbxKhoHang.SelectedValue.ToString();
                frmTraCuu fr = new frmTraCuu("HangTraLai_DonDatHangNhaCungCap", "TimHoaDonNhapTheoMa", txtMakhachhang.Text, makho, "");
                fr.ShowDialog();
                Binding();
            }
            else
            { MessageBox.Show("Nhập nhà cung cấp"); txtMakhachhang.Focus(); }
        }
        private void btnChungtugoc_Click(object sender, EventArgs e)
        {
            TimChungTu();
        }
        #endregion

        /// <summary>
        /// Tim chung tu chung
        /// </summary>
        public void TimChungTu()
        {
            try
            {
                GiaTriCanLuu.Ma = null;
                GiaTriCanLuu.Ten = null;
                GiaTriCanLuu.Giatri2 = null;
                switch (this.tenForm)
                {
                    case "KhachHangTraLai":
                        this.TimChungTuKhachHang();
                        break;
                    case "TraLaiNhaCungCap":
                        this.TimChungTuNhaCungCap();
                        break;
                    default:
                        break;
                }
                if (dgvXemthongtin.RowCount > 0)
                {
                    capnhat();
                    TinhToan();
                }
                else
                { capnhat(); }
                if (txtChungtugoc.Text.Length <= 0)
                { txtChungtugoc.Text = "<F4 - Tra cứu>"; }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        #region Delete
        private void DeleteData(string ID)
        {
            try
            {
                Entities.KhachHangTraLai ctdh = new Entities.KhachHangTraLai();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                ctdh = new Entities.KhachHangTraLai("Delete", ID);
                clientstrem = cl.SerializeObj(this.client, "KhachHangTraLai", ctdh);
                int trave = 0;
                trave = System.Convert.ToInt32(cl.DeserializeHepper(clientstrem, trave));
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// hungvv =======================Xoa ===========================
        /// </summary>
        private void DeleteData2(string ID)
        {
            try
            {
                Entities.TraLaiNCC ctdh = new Entities.TraLaiNCC();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                ctdh = new Entities.TraLaiNCC("Delete", ID);
                clientstrem = cl.SerializeObj(this.client, "TraLaiNhaCungCap", ctdh);
                int trave = 0;
                trave = System.Convert.ToInt32(cl.DeserializeHepper(clientstrem, trave));
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        #region Tim Hang Hoa
        private void KeyDown_Chung(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F4)
                {
                    switch (this.tenForm)
                    {
                        case "KhachHangTraLai":
                            if (txtChungtugoc.Text != "" && txtChungtugoc.Text != "<F4 - Tra cứu>")
                            {
                                frmTraCuu fr = new frmTraCuu("ChiTietKhachHangTraLaiHang_HangHoa", "HangHoaTraLai", txtChungtugoc.Text, loaihoadon(rdoBanbuon, rdoBanle));
                                fr.ShowDialog();
                                BindHangHoa();

                            }
                            else
                            {
                                MessageBox.Show("Nhập mã hóa đơn bán hàng");
                                txtChungtugoc.Text = "";
                                txtChungtugoc.Focus();
                            }
                            break;
                        case "TraLaiNhaCungCap":
                            if (txtChungtugoc.Text != "" && txtChungtugoc.Text != "<F4 - Tra cứu>")
                            {
                                frmTraCuu fr = new frmTraCuu("ChiTietTraLaiNhaCungCap_MaHangHoa", "ThongTinTraLaiNhaCungCap", txtChungtugoc.Text);
                                fr.ShowDialog();
                                BindHangHoa();
                            }
                            else
                            {
                                MessageBox.Show("Nhập mã hóa đơn mua hàng");
                                txtChungtugoc.Focus();
                                txtChungtugoc.Text = "";
                            }
                            break;
                        default:
                            break;
                    }
                    if (toolStrip_txtTracuu.Text.Length <= 0)
                    {
                        ResetTool();
                    }
                }
                if (e.KeyCode == Keys.F5)
                {
                    txtThanhtoanngay_Click(sender, e);
                    txtThanhtoanngay.Focus();
                }
                if (e.KeyCode == Keys.F6)
                {
                    dgvXemthongtin.Focus();
                }
            }
            catch
            {
            }
        }

        private void TimHangHoaKhachHang()
        {
            try
            {
                if (txtChungtugoc.Text != "" && txtChungtugoc.Text != "<F4 - Tra cứu>")
                {
                    if (toolStrip_txtTracuu.Text != "<F4 - Tra cứu>" && toolStrip_txtTracuu.Text != "")
                    {
                        BindingHangHoaTraLai(txtChungtugoc.Text, loaihoadon(rdoBanbuon, rdoBanle));
                        if (laymang.Length > 0)
                        {
                            string ma = "";
                            for (int y = 0; y < laymang.Length; y++)
                            {
                                if (laymang[y].MaHangHoa == toolStrip_txtTracuu.Text)
                                {
                                    ma = toolStrip_txtTracuu.Text;
                                    break;
                                }
                                else
                                { ma = ""; continue; }
                            }
                            if (ma == "")
                            {
                                MessageBox.Show("Mã hàng hóa không có trong đơn này");
                                toolStrip_txtTracuu.Focus();
                            }
                            else
                            {
                                LayHangHoaTheoMa(ma);
                                khachhangtra = LaySoLuongConLaiTheoKhachHang(txtChungtugoc.Text, toolStrip_txtTracuu.Text);
                                toolStrip_txtSoluong.Focus();
                            }
                        }
                        else
                        { MessageBox.Show("Không có hàng hóa trong chứng từ gốc"); toolStrip_txtTracuu.Focus(); }
                    }
                    else
                    { MessageBox.Show("Nhập mã hàng hóa"); ResetTool(); toolStrip_txtTracuu.Focus(); }
                }
                else
                {
                    MessageBox.Show("Nhập mã hóa đơn bán hàng");
                    txtChungtugoc.Focus();
                    txtChungtugoc.Text = "";
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void TimHangHoaNhaCungCap()
        {
            try
            {
                if (txtChungtugoc.Text != "" && txtChungtugoc.Text != "<F4 - Tra cứu>")
                {
                    if (toolStrip_txtTracuu.Text != "<F4 - Tra cứu>" && toolStrip_txtTracuu.Text != "")
                    {
                        ThongTinTraLaiNhaCungCap(txtChungtugoc.Text);
                        if (laymang2.Length > 0)
                        {
                            string ma = "";
                            for (int y = 0; y < laymang2.Length; y++)
                            {
                                if (laymang2[y].MaHangHoa == toolStrip_txtTracuu.Text)
                                {
                                    ma = toolStrip_txtTracuu.Text;
                                    break;
                                }
                                else
                                { ma = ""; continue; }
                            }
                            if (ma == "")
                            { MessageBox.Show("Mã hàng hóa không có trong đơn này"); }
                            else
                            {
                                LayHangHoaTheoMa(ma);
                                toolStrip_txtSoluong.Focus();
                                tranhacungcap = LaySoLuongConLaiTheoNhaCungCap(txtChungtugoc.Text, toolStrip_txtTracuu.Text);
                            }
                        }
                        else
                        { MessageBox.Show("Không có hàng hóa trong chứng từ gốc"); }
                    }
                    else
                    { MessageBox.Show("Nhập mã hàng hóa"); ResetTool(); }
                }
                else
                {
                    MessageBox.Show("Nhập mã hóa đơn mua hàng");
                    txtChungtugoc.Focus();
                    txtChungtugoc.Text = "";
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        public static Entities.TruyenGiaTri[] soluongmua;
        private void toolStrip_txtTracuu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (testCharacter(toolStrip_txtTracuu.Text) == false)
                { return; }
                GiaTriCanLuu.Ma = null;
                GiaTriCanLuu.Ten = null;
                GiaTriCanLuu.Giatri = null;
                GiaTriCanLuu.Giatri2 = null;
                KeyDown_Chung(sender, e);
                if (e.KeyCode == Keys.Enter)
                {
                    switch (this.tenForm)
                    {
                        case "KhachHangTraLai":
                            TimHangHoaKhachHang();
                            break;
                        case "TraLaiNhaCungCap":
                            TimHangHoaNhaCungCap();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        #region Hien Thi Hang Hoa Tim
        private void BindHangHoa()
        {
            try
            {
                switch (this.tenForm)
                {
                    case "KhachHangTraLai":
                        if (GiaTriCanLuu.Loaitrave == "KhachHangTraLaiHang_HangHoa")
                        {
                            txtMakhachhang.Text = GiaTriCanLuu.Ma;
                            lblTenkhachhang.Text = GiaTriCanLuu.Ten;
                            LayHangHoaTheoMaHoaDonBanHang("");
                        }
                        if (GiaTriCanLuu.Loaitrave == "HoaDonNhap_DonDatHang")
                        {
                            txtChungtugoc.Text = GiaTriCanLuu.Ma;
                            lblNgaychungtu.Text = GiaTriCanLuu.Ten;
                        }
                        if (GiaTriCanLuu.Loaitrave == "ChiTietKhachHangTraLaiHang_HangHoa")
                        {
                            toolStrip_txtTracuu.Text = GiaTriCanLuu.Ma;
                            toolStrip_txtTenhang.Text = GiaTriCanLuu.Ten;
                            khachhangtra = LaySoLuongConLaiTheoKhachHang(txtChungtugoc.Text, toolStrip_txtTracuu.Text);
                            toolStrip_txtGiagoc.Text = GiaTriCanLuu.Giatri;
                            toolStrip_txtSoluong.Text = GiaTriCanLuu.Giatri2;
                            toolStrip_txtChietkhauphantram.Text = "0";
                            thue = GiaTriCanLuu.giatrigiatang;
                            toolStrip_txtSoluong.Focus();
                        }
                        break;
                    case "TraLaiNhaCungCap":
                        if (GiaTriCanLuu.Loaitrave == "TraLaiNhaCungCap_HangHoa")
                        {
                            txtMakhachhang.Text = GiaTriCanLuu.Ma;
                            lblTenkhachhang.Text = GiaTriCanLuu.Ten;
                            LayHangHoaTheoMaHoaDonBanHang("");
                        }
                        if (GiaTriCanLuu.Loaitrave == "HoaDonNhap_DonDatHang")
                        {
                            txtChungtugoc.Text = GiaTriCanLuu.Ma;
                            lblNgaychungtu.Text = GiaTriCanLuu.Ten;
                        }
                        if (GiaTriCanLuu.Loaitrave == "ChiTietTraLaiNhaCungCap_MaHangHoa")
                        {
                            toolStrip_txtTracuu.Text = GiaTriCanLuu.Ma;
                            toolStrip_txtTenhang.Text = GiaTriCanLuu.Ten;
                            tranhacungcap = LaySoLuongConLaiTheoNhaCungCap(txtChungtugoc.Text, toolStrip_txtTracuu.Text);
                            toolStrip_txtGiagoc.Text = GiaTriCanLuu.Giatri;
                            toolStrip_txtSoluong.Text = GiaTriCanLuu.makhachhang;
                            toolStrip_txtChietkhauphantram.Text = "0";
                            thue = GiaTriCanLuu.giatrigiatang;
                            toolStrip_txtSoluong.Focus();
                        }
                        break;
                    default:
                        break;
                }
                toolStrip_txtTongTien.Text = tinhtong();
                toolStrip_Chietkhau.Text = chietkhau();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        #region LayHangHoaHoaDonNhap
        private void ThongTinTraLaiNhaCungCap(string manhacungcap)
        {
            try
            {
                Entities.ThongTinDatHang nhap;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                nhap = new Entities.ThongTinDatHang("Select", manhacungcap);
                clientstrem = cl.SerializeObj(this.client, "ThongTinTraLaiNhaCungCap", nhap);
                laymang2 = new Entities.ThongTinDatHang[1];
                laymang2 = (Entities.ThongTinDatHang[])cl.DeserializeHepper(clientstrem, laymang2);
                if (laymang2.Length <= 0)
                {
                    laymang2 = new Entities.ThongTinDatHang[0];
                    laymang2 = null;
                }
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                laymang2 = new Entities.ThongTinDatHang[0];
                laymang2 = null;
            }
        }
        #endregion

        #region LayHangHoaTrongHoaDonBanHang
        private void BindingHangHoaTraLai(string ma, string loai)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TruyenGiaTri dh = new Entities.TruyenGiaTri("Select", ma, loai);
                clientstrem = cl.SerializeObj(this.client, "ChiTietKhachHangTraLaiTheoDonBanHang", dh);
                laymang = new Entities.ThongTinDatHang[1];
                laymang = (Entities.ThongTinDatHang[])cl.DeserializeHepper(clientstrem, laymang);
                if (laymang.Length <= 0)
                {
                    laymang = new Entities.ThongTinDatHang[0];
                    laymang = null;
                }
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                laymang = new Entities.ThongTinDatHang[0];
                laymang = null;
            }
        }
        #endregion

        #region KiemTra
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

        private string KiemTraMa(Entities.LayHangHoaTheoMaKhachHangTraLai lay)
        {
            string kt = null;
            Entities.KiemTraChung ktm = new Entities.KiemTraChung();
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            ktm = new Entities.KiemTraChung("Select", lay.Mahanghoa);
            clientstrem = cl.SerializeObj(this.client, "KiemTraMa", ktm);
            Entities.KiemTraChung tra = new Entities.KiemTraChung();
            tra = (Entities.KiemTraChung)cl.DeserializeHepper(clientstrem, tra);
            kt = tra.Hanhdong;
            return kt;
        }
        #endregion

        #region GetDataGridview KhachHang
        public void LayGiaTri(DataGridView dgv, Entities.LayHangHoaTheoMaKhachHangTraLai themmoi)
        {
            try
            {
                ArrayList arr = new ArrayList();
                Entities.LayHangHoaTheoMaKhachHangTraLai[] list = null;
                if (dgv.RowCount > 0)
                {
                    int count = dgv.RowCount;
                    list = new Entities.LayHangHoaTheoMaKhachHangTraLai[count];
                    Boolean check = false;
                    for (int i = 0; i < count; i++)
                    {
                        string sl = "1";
                        Entities.LayHangHoaTheoMaKhachHangTraLai row = new Entities.LayHangHoaTheoMaKhachHangTraLai();
                        row.Mahanghoa = dgv.Rows[i].Cells[0].Value.ToString();
                        row.Tenhanghoa = dgv.Rows[i].Cells[1].Value.ToString();
                        if (dgv.Rows[i].Cells[0].Value.ToString() == themmoi.Mahanghoa)
                        {
                            sl = (Convert.ToInt32(dgv.Rows[i].Cells[2].Value.ToString()) + themmoi.Soluong).ToString();
                            row.Phantramchietkhau = dgv.Rows[i].Cells[4].Value.ToString();
                            row.Chietkhau = (Convert.ToDouble(dgv.Rows[i].Cells[5].Value.ToString()) + Convert.ToDouble(toolStrip_Chietkhau.Text)).ToString();
                            row.Tongtien = (Convert.ToDouble(dgv.Rows[i].Cells[6].Value.ToString()) + Convert.ToDouble(toolStrip_txtTongTien.Text)).ToString();
                            row.Thuegiatrigiatang = dgv.Rows[i].Cells[7].Value.ToString();
                            check = true;
                        }
                        else
                        {
                            sl = (Convert.ToInt32(dgv.Rows[i].Cells[2].Value.ToString())).ToString();
                            row.Phantramchietkhau = dgv.Rows[i].Cells[4].Value.ToString();
                            row.Chietkhau = dgv.Rows[i].Cells[5].Value.ToString();
                            row.Tongtien = dgv.Rows[i].Cells[6].Value.ToString();
                            row.Thuegiatrigiatang = dgv.Rows[i].Cells[7].Value.ToString();
                        }
                        row.Soluong = int.Parse(sl);
                        row.Giaban = dgv.Rows[i].Cells[3].Value.ToString();

                        arr.Add(row);
                    }

                    if (check == false)
                    {
                        Entities.LayHangHoaTheoMaKhachHangTraLai row = new Entities.LayHangHoaTheoMaKhachHangTraLai();
                        row.Mahanghoa = themmoi.Mahanghoa;
                        row.Tenhanghoa = themmoi.Tenhanghoa;
                        row.Soluong = themmoi.Soluong;
                        row.Giaban = themmoi.Giaban;
                        row.Phantramchietkhau = themmoi.Phantramchietkhau;
                        row.Chietkhau = themmoi.Chietkhau;
                        row.Tongtien = themmoi.Tongtien;
                        row.Thuegiatrigiatang = themmoi.Thuegiatrigiatang;
                        arr.Add(row);
                        check = true;
                    }
                }
                else
                {
                    list = new Entities.LayHangHoaTheoMaKhachHangTraLai[1];
                    Entities.LayHangHoaTheoMaKhachHangTraLai row = new Entities.LayHangHoaTheoMaKhachHangTraLai();
                    row.Mahanghoa = themmoi.Mahanghoa;
                    row.Tenhanghoa = themmoi.Tenhanghoa;
                    row.Soluong = themmoi.Soluong;
                    row.Giaban = themmoi.Giaban;
                    row.Phantramchietkhau = themmoi.Phantramchietkhau;
                    row.Chietkhau = themmoi.Chietkhau;
                    row.Tongtien = themmoi.Tongtien;
                    row.Thuegiatrigiatang = themmoi.Thuegiatrigiatang;
                    arr.Add(row);
                }
                int n = arr.Count;
                if (n == 0) { list = null; }
                list = new Entities.LayHangHoaTheoMaKhachHangTraLai[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.LayHangHoaTheoMaKhachHangTraLai)arr[i];
                }
                if (list.Length > 0)
                {
                    dgv.DataSource = list;
                    fixDatagridview();
                }
                else
                {
                    Entities.LayHangHoaTheoMaKhachHangTraLai[] lay = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                    dgv.DataSource = lay;
                    fixDatagridview();
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.LayHangHoaTheoMaKhachHangTraLai[] lay = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                dgv.DataSource = lay;
                fixDatagridview();
            }
        }
        #endregion

        #region GetDataGridview NhaCungCap
        public void LayGiaTri(DataGridView dgv, Entities.HienThi_ChiTiet_DonDatHang themmoi)
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
                    Entities.HienThi_ChiTiet_DonDatHang row = new Entities.HienThi_ChiTiet_DonDatHang();
                    row.MaHangHoa = dgv.Rows[i].Cells[1].Value.ToString();
                    row.TenHangHoa = dgv.Rows[i].Cells[2].Value.ToString();
                    if (dgv.Rows[i].Cells[1].Value.ToString() == themmoi.MaHangHoa)
                    {
                        sl = (Convert.ToInt32(dgv.Rows[i].Cells[3].Value.ToString()) + themmoi.SoLuongDat).ToString();
                        check = true;
                    }
                    else
                    {
                        sl = (Convert.ToInt32(dgv.Rows[i].Cells[3].Value.ToString())).ToString();
                        check = false;
                    }
                    row.SoLuongDat = int.Parse(sl);
                    row.GiaGoc = dgv.Rows[i].Cells[4].Value.ToString();
                    row.Giabanbuon = dgv.Rows[i].Cells[5].Value.ToString();
                    row.Giabanle = dgv.Rows[i].Cells[6].Value.ToString();
                    row.PhanTramChietKhau = dgv.Rows[i].Cells[7].Value.ToString();
                    row.Thuegiatrigiatang = Double.Parse(0 + dgv.Rows[i].Cells[8].Value.ToString()).ToString();
                    row.GiaNhap = dgv.Rows[i].Cells[9].Value.ToString();
                    row.TongTien = dgv.Rows[i].Cells[11].Value.ToString();
                    arr.Add(row);
                }

                if (check == false)
                {
                    Entities.HienThi_ChiTiet_DonDatHang row = new Entities.HienThi_ChiTiet_DonDatHang();
                    row.MaHangHoa = themmoi.MaHangHoa;
                    row.TenHangHoa = themmoi.TenHangHoa;
                    row.SoLuongDat = themmoi.SoLuongDat;
                    row.GiaGoc = themmoi.GiaGoc;
                    row.Giabanbuon = themmoi.Giabanbuon;
                    row.Giabanle = themmoi.Giabanle;
                    row.PhanTramChietKhau = themmoi.PhanTramChietKhau;
                    row.Thuegiatrigiatang = themmoi.Thuegiatrigiatang;
                    row.GiaNhap = themmoi.GiaNhap;
                    row.TongTien = themmoi.TongTien;
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
                row.GiaGoc = themmoi.GiaGoc;
                row.Giabanbuon = themmoi.Giabanbuon;
                row.Giabanle = themmoi.Giabanle;
                row.PhanTramChietKhau = themmoi.PhanTramChietKhau;
                row.Thuegiatrigiatang = themmoi.Thuegiatrigiatang;
                row.GiaNhap = themmoi.GiaNhap;
                row.TongTien = themmoi.TongTien;
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
                quydoiDonViTinh = (Entities.HangHoaGoiHang)cl.DeserializeHepper(clientstrem, quydoiDonViTinh);
                client.Close();
                clientstrem.Close();
                if (quydoiDonViTinh.MaHang != null)
                {
                    if (tenForm == "KhachHangTraLai")
                    {
                        toolStrip_txtTracuu.Text = quydoiDonViTinh.MaHang;
                        toolStrip_txtTenhang.Text = quydoiDonViTinh.TenHang;
                        khachhangtra = LaySoLuongConLaiTheoKhachHang(txtChungtugoc.Text, quydoiDonViTinh.MaHang);
                        toolStrip_txtGiagoc.Text = quydoiDonViTinh.GiaBanBuon;
                        toolStrip_txtSoluong.Text = (float.Parse(toolStrip_txtSoluong.Text) * float.Parse(quydoiDonViTinh.SoLuong)).ToString();
                        toolStrip_txtChietkhauphantram.Text = "0";
                        thue = quydoiDonViTinh.Thue;
                        toolStrip_txtSoluong.Focus();
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        #region Event
        private void toolStripStatus_In_Click(object sender, EventArgs e)
        {
            try
            {
                if (tenForm == "KhachHangTraLai")
                {
                    InThongTinKhachHangTraLai();
                }
                if (tenForm == "TraLaiNhaCungCap")
                {
                    InThongTinTraLaiNhaCungCap();
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void LuuChiTietTraLaiNhaCungCap()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.ChiTietTraLaiNhaCungCap[] luu = ChiTietTraLaiNhaCungCap(dgvXemthongtin, "Insert", txtSodonhang.Text, cbxKhoHang.SelectedValue.ToString());
                clientstrem = cl.SerializeHepper(this.client, "ChiTietTraLaiNhaCungCap", luu);
                int bao = 0;
                bao = (int)cl.DeserializeHepper(clientstrem, bao);
                if (bao >= 1)
                { this.Close(); }
                else
                { DeleteData2(txtSodonhang.Text); MessageBox.Show("Thất bại"); }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }


        private string makiemtra;
        private void toolStripStatus_Themmoi_Click(object sender, EventArgs e)
        {
            ThemMoi();
        }
        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tenForm == "KhachHangTraLai")
                {
                    int slthem = 0;
                    khachhangtra = LaySoLuongConLaiTheoKhachHang(txtChungtugoc.Text, toolStrip_txtTracuu.Text);
                    if (khachhangtra > 0)
                    {
                        for (int k = 0; k < dgvXemthongtin.RowCount; k++)
                        {
                            if (dgvXemthongtin.Rows[k].Cells[0].Value.ToString() == toolStrip_txtTracuu.Text)
                            {
                                int sl = int.Parse(dgvXemthongtin.Rows[k].Cells[2].Value.ToString());
                                if (khachhangtra <= sl)
                                {
                                    MessageBox.Show("Số lượng vượt quá số lượng đã mua");
                                    toolStrip_txtTracuu_Click(sender, e);
                                    toolStrip_txtTracuu.Focus();
                                    return;
                                }
                                else
                                {
                                    slthem = khachhangtra - sl;
                                    if (int.Parse(toolStrip_txtSoluong.Text) <= slthem)
                                    {
                                        toolStrip_txtTongTien.Text = new Common.Utilities().FormatMoney(Double.Parse(tinhtong()));
                                        toolStrip_Chietkhau.Text = new Common.Utilities().FormatMoney(Double.Parse(chietkhau()));
                                        break;
                                    }
                                    else
                                    {
                                        if (slthem <= 0)
                                        {
                                            MessageBox.Show("Hàng hóa này đã trả hết không thể trả thêm");
                                            return;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Bạn chỉ có thể trả :" + slthem);
                                            toolStrip_txtSoluong.Text = slthem.ToString();
                                            toolStrip_txtSoluong.Focus();
                                            break;
                                        }
                                    }

                                }
                            }
                            else
                            { continue; }
                        }
                    }
                    else
                    { MessageBox.Show("Hàng hóa này đã trả hết không thể trả thêm"); ResetTool(); }

                }
                if (tenForm == "TraLaiNhaCungCap")
                {
                    tranhacungcap = LaySoLuongConLaiTheoNhaCungCap(txtChungtugoc.Text, toolStrip_txtTracuu.Text);

                    int slthem = 0;
                    for (int k = 0; k < dgvXemthongtin.RowCount; k++)
                    {
                        if (dgvXemthongtin.Rows[k].Cells[0].Value.ToString() == toolStrip_txtTracuu.Text)
                        {
                            int sl = int.Parse(dgvXemthongtin.Rows[k].Cells[2].Value.ToString());
                            if (tranhacungcap <= sl)
                            {
                                MessageBox.Show("Số lượng vượt quá số lượng đã mua");
                                toolStrip_txtTracuu_Click(sender, e);
                                toolStrip_txtTracuu.Focus();
                                return;
                            }
                            else
                            {
                                slthem = tranhacungcap - sl;
                                if (int.Parse(toolStrip_txtSoluong.Text) <= slthem)
                                {
                                    toolStrip_txtTongTien.Text = new Common.Utilities().FormatMoney(Double.Parse(tinhtong()));
                                    toolStrip_Chietkhau.Text = new Common.Utilities().FormatMoney(Double.Parse(chietkhau()));
                                }
                                else
                                {
                                    toolStrip_txtSoluong.Text = slthem.ToString();
                                    toolStrip_txtSoluong.Focus();
                                }
                                break;
                            }
                        }

                        else
                        { continue; }
                    }
                }
                ThemVao();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        private void txtMakhachhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                TraCuuMa();
            }
        }

        private void txtChungtugoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                TimChungTu();
            //if (tenForm == "KhachHangTraLai")
            //{
            //    GiaTriCanLuu.Giatri = loaihoadon(rdoBanbuon, rdoBanle);
            //    if (txtMakhachhang.Text != "<F4 - Tra cứu>" && txtMakhachhang.Text.Length > 0)
            //    {
            //        frmTraCuu fr = new frmTraCuu("HangTraLai_KhachHangTraLai_MaDonHang", "HoaDonBanHang", txtMakhachhang.Text);
            //        fr.ShowDialog();
            //        Binding();
            //    }
            //    else
            //    { MessageBox.Show("Nhập khách hàng"); txtMakhachhang.Focus(); }

            //}
            //if (tenForm == "TraLaiNhaCungCap")
            //{
            //    if (txtMakhachhang.Text != "<F4 - Tra cứu>" && txtMakhachhang.Text.Length > 0)
            //    {
            //        //hoa don nhap mua
            //        frmTraCuu fr = new frmTraCuu("HangTraLai_DonDatHangNhaCungCap", "TimHoaDonNhapTheoMa", txtMakhachhang.Text);
            //        fr.ShowDialog();
            //        Binding();
            //    }
            //    else
            //    { MessageBox.Show("Nhập nhà cung cấp"); txtMakhachhang.Focus(); }
            //}
        }

        private void toolStrip_txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
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

        private void toolStrip_txtChietkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiatrigiatang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTienboithuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtThanhtoanngay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

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

        private void toolStrip_txtChietkhauphantram_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(0 + toolStrip_txtChietkhauphantram.Text) > 0 && int.Parse(0 + toolStrip_txtChietkhauphantram.Text) < 100)
                {
                    toolStrip_txtTongTien.Text = tinhtong();
                    toolStrip_Chietkhau.Text = chietkhau();
                }
                else
                {
                    if (toolStrip_txtChietkhauphantram.Text == "0")
                    {
                        toolStrip_txtTongTien.Text = tinhtong();
                        toolStrip_Chietkhau.Text = tinhtong();
                    }
                    else
                    {
                        toolStrip_txtChietkhauphantram.Text = "0";
                        toolStrip_txtTongTien.Text = "0";
                        toolStrip_Chietkhau.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void rdoBanle_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (hanhDong == "Sua_KhachHangTraLai")
                {
                    if (rdoBanle.Checked == true)
                    {
                        txtChungtugoc.Text = "<F4 - Tra cứu>";
                        dgvXemthongtin.DataSource = null;
                        Entities.LayHangHoaTheoMaKhachHangTraLai[] row = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                        dgvXemthongtin.DataSource = row;
                        fixDatagridview();
                        capnhat();
                        ResetTool();
                        toolStripLabel5.Text = "GBL";
                        toolStripLabel5.ToolTipText = "Giá bán lẻ";
                        txtThanhtoanngay.Text = "0";
                        txtTongtienthanhtoan.Text = "0";
                        txtSodu.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void rdoBanbuon_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (hanhDong != "Sua_KhachHangTraLai")
                {
                    if (rdoBanbuon.Checked == true)
                    {
                        txtChungtugoc.Text = "<F4 - Tra cứu>";
                        dgvXemthongtin.DataSource = null;
                        Entities.LayHangHoaTheoMaKhachHangTraLai[] row = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                        dgvXemthongtin.DataSource = row;
                        fixDatagridview();
                        capnhat();
                        ResetTool();
                        toolStripLabel5.Text = "GBB";
                        toolStripLabel5.ToolTipText = "Giá bán buôn";
                        txtThanhtoanngay.Text = "0";
                        txtTongtienthanhtoan.Text = "0";
                        txtSodu.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        int khachhangtra = 0;
        int tranhacungcap = 0;
        private void toolStrip_txtSoluong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtChungtugoc.Text != "" && txtChungtugoc.Text != "<F4 - Tra cứu>" && toolStrip_txtTracuu.Text != "" && toolStrip_txtTracuu.Text != "<F4 - Tra cứu>")
                {
                    if (tenForm == "KhachHangTraLai")
                    {
                        if (khachhangtra > 0)
                        {
                            if (int.Parse(toolStrip_txtSoluong.Text) <= khachhangtra)
                            {
                                toolStrip_txtTongTien.Text = new Common.Utilities().FormatMoney(Double.Parse(tinhtong()));
                                toolStrip_Chietkhau.Text = new Common.Utilities().FormatMoney(Double.Parse(chietkhau()));
                            }
                            else
                            { toolStrip_txtSoluong.Text = khachhangtra.ToString(); toolStrip_txtSoluong.Focus(); }
                        }
                        else
                        { MessageBox.Show("Hàng hóa này đã trả hết không thể trả thêm"); ResetTool(); return; }
                    }
                    if (tenForm == "TraLaiNhaCungCap")
                    {

                        if (tranhacungcap > 0)
                        {
                            if (int.Parse(toolStrip_txtSoluong.Text) <= tranhacungcap)
                            {
                                toolStrip_txtTongTien.Text = new Common.Utilities().FormatMoney(Double.Parse(tinhtong()));
                                toolStrip_Chietkhau.Text = new Common.Utilities().FormatMoney(Double.Parse(chietkhau()));
                            }
                            else
                            { toolStrip_txtSoluong.Text = tranhacungcap.ToString(); toolStrip_txtSoluong.Focus(); }
                        }
                        else
                        { MessageBox.Show("Hàng hóa này đã trả hết không thể trả thêm"); ResetTool(); return; }
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private int i;
        private void dgvXemthongtin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                i = e.RowIndex;
                if (i < 0)
                    dgvXemthongtin.Rows[0].Selected = true;
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }

        private void dgvXemthongtin_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                XuLyDGV();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void txtTienboithuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (tenForm == "TraLaiNhaCungCap")
                {
                    if (dgvXemthongtin.RowCount > 0)
                    {
                        if (txtChietkhau.Text != "0" && txtChietkhau.Text != "")
                        {
                            txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(txtTongtienthanhtoan.Text));
                            txtThanhtoanngay.Text = "0";
                        }
                        else
                        { capnhat(); }
                        TinhToan();
                    }
                    else { capnhat(); }
                }
                if (tenForm == "KhachHangTraLai")
                {

                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void txtThanhtoanngay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtConphaitra.Text = string.Empty;
                string tongtientrailai = (double.Parse(txtTongtienthanhtoan.Text) - double.Parse(txtThanhtoanngay.Text)).ToString();
                string sodu = (double.Parse(txtNohienthoi.Text) - double.Parse(tongtientrailai)).ToString();
                txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(tongtientrailai));
                txtSodu.Text = new Common.Utilities().FormatMoney(Double.Parse(sodu));
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        private void toolStrip_txtSoluong_Click(object sender, EventArgs e)
        {
            toolStrip_txtSoluong.Text = "";
            toolStrip_txtChietkhauphantram.Text = "0";
            toolStrip_Chietkhau.Text = "0";
            toolStrip_txtTongTien.Text = "0";
        }

        private void toolStrip_txtChietkhauphantram_Click(object sender, EventArgs e)
        {
            toolStrip_txtChietkhauphantram.Text = "0";
            toolStrip_Chietkhau.Text = "0";
            toolStrip_txtTongTien.Text = "0";
        }

        private void toolStrip_txtTracuu_Click(object sender, EventArgs e)
        {
            toolStrip_txtTracuu.Text = "";
        }

        private void txtThanhtoanngay_Click(object sender, EventArgs e)
        {
            if (tenForm == "KhachHangTraLai")
            {
                txtThanhtoanngay.Text = "";
                string gia = txtSodu.Text;
                txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(gia));
            }
            if (tenForm == "TraLaiNhaCungCap")
            {
                txtThanhtoanngay.Text = "";
                string gia = txtSodu.Text;
                txtConphaitra.Text = new Common.Utilities().FormatMoney(Double.Parse(gia));
            }
        }

        private void toolStrip_txtSoluong_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    toolStrip_txtChietkhauphantram.Text = "0";
                    toolStrip_txtChietkhauphantram.Focus();
                }
                KeyDown_Chung(sender, e);
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
                    if (toolStrip_txtChietkhauphantram.Text == "")
                        toolStrip_txtChietkhauphantram.Text = "0";
                    toolStrip_btnThem_Click(sender, e);
                }
                KeyDown_Chung(sender, e);
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void txtThanhtoanngay_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ThemMoi();
                }
                KeyDown_Chung(sender, e);
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void dgvXemthongtin_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDown_Chung(sender, e);
            if (e.KeyCode == Keys.Enter)
            {
                if (dgvXemthongtin.RowCount == 0)
                    return;
                i = dgvXemthongtin.SelectedRows[0].Index;
                XuLyDGV();
                toolStrip_txtSoluong.Focus();
            }
        }
        private void toolStripStatus_Dong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    if (tenForm == "KhachHangTraLai")
                    {
                        frmQuanLyKhachHangTraLaiHang.BaoDong = "A";
                    }
                    if (tenForm == "TraLaiNhaCungCap")
                    {
                        frmQuanLyTraLaiNhaCungCap.BaoDong = "A";
                    }
                    this.Close();
                }
                else
                { }
            }
        }
        private void btnTimmakhachhang_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.LayHangHoaTheoMaKhachHangTraLai[] lay = new Entities.LayHangHoaTheoMaKhachHangTraLai[0];
                dgvXemthongtin.DataSource = lay;
                fixDatagridview();
                ResetTool();
                TraCuuMa();
            }
            catch (Exception ex)
            { string s = ex.Message; }
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

        private void txtMakhachhang_TextChanged(object sender, EventArgs e)
        {
            this.txtChungtugoc.Text = "<F4 - Tra cứu>";
        }
    }
}
