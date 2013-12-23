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
    public partial class frmXuLy_HoaDonNhap : Form
    {
       
        #region khoi tao==========================================================================
        private Entities.HoaDonNhap hoadon;
        public Entities.HoaDonNhap Hoadon
        {
            get { return hoadon; }
            set { hoadon = value; }
        }
        public frmXuLy_HoaDonNhap()
        {
            InitializeComponent();
        }
        public frmXuLy_HoaDonNhap(string hanhdong,Entities.HoaDonNhap hoa)
        {
            InitializeComponent();
            this.hanhdong = hanhdong;
            this.hoadon = hoa;
        }
        private string hanhdong;
        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }

        public frmXuLy_HoaDonNhap(string hanhdong)
        {
            InitializeComponent();
            this.hanhdong = hanhdong;
        }
        #endregion

        #region hungvv==============================================ket noi=====================================================================
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

        #region Select============================================================================================================================
        /// <summary>
        /// hungvv =======================giao tiep voi server===========================
        /// </summary>
        private void Select_ChiTietHoaDonNhap(string hanhdong)
        {
            Entities.HoaDonNhap pt = new Entities.HoaDonNhap();
            pt = new Entities.HoaDonNhap(hanhdong);
            Entities.ChiTietHoaDonNhap[] pt1 = new Entities.ChiTietHoaDonNhap[10];
            clientstrem = cl.SerializeObj(this.client, "ChiTietHoaDonNhap", pt);

            Binding((Entities.ChiTietHoaDonNhap[])cl.DeserializeHepper(clientstrem, pt1));
        }

        /// <summary>
        /// hungvv =====================hien thi ========================================
        /// </summary>
        /// <param name="data"></param>
        private void Binding(Entities.ChiTietHoaDonNhap[] data)
        {
            try
            {
                dgvInsertOrder.DataSource = null;
                dgvInsertOrder.DataSource = data;
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
        }

        /// <summary>
        /// add giatri vao combox
        /// </summary>
        /// <param name="hanhdong"></param>
        #endregion

        #region Binding combox======================================================================================================================
        /// <summary>
        ///  Lấy Kho Hàng
        /// </summary>
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
                this.cbxKhoHang.Text = "Chọn kho hàng";
            }
            catch (Exception)
            { }
            client.Close();
            clientstrem.Close();
        }

        /// <summary>
        /// Lấy tên tiền tệ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LayTenTT()
        {
            try
            {
                cbxTienTe_TyGia.Items.Clear();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KiemTraChung tt1 = new Entities.KiemTraChung();
                tt1 = new Entities.KiemTraChung("Select", "TienTe", "MaTienTe", "TenTienTe");
                clientstrem = cl.SerializeObj(this.client, "LayCombox", tt1);
                Entities.KiemTraChung[] tt = new Entities.KiemTraChung[1];
                tt = (Entities.KiemTraChung[])cl.DeserializeHepper1(clientstrem, tt);
                Common.Utilities com = new Common.Utilities();
                com.BindingCombobox(tt, cbxTienTe_TyGia, "giatri", "khoachinh");
                cbxTienTe_TyGia.Text = "Chọn tiền tệ";
            }
            catch
            {
                cbxTienTe_TyGia.Items.Clear();
                cbxTienTe_TyGia.Text = "";
            }
            client.Close();
            clientstrem.Close();
        }

        #endregion

        #region Xu Ly=======================================================================================
        /// <summary>
        /// add ban ghi --------------------------------hungvv-----------------------------
        /// </summary>
        /// <param name="dgv"></param>
        public Entities.ChiTietHoaDonNhap[] LuuChiTietHoaDonNhap(DataGridView dgv, string hanhdong, string madondathang)
        {
           
            ArrayList arr = new ArrayList();
            int i = dgv.RowCount;
            Entities.ChiTietHoaDonNhap[] mangBanghi = null;
            if (i > 0)
            {
                for (int x = 0; x < i; x++)
                {
                    Entities.ChiTietHoaDonNhap banghi = new Entities.ChiTietHoaDonNhap();
                    banghi.Hanhdong = hanhdong;
                    banghi.MaHoaDonNhap = madondathang.ToUpper();
                    banghi.MaHangHoa = dgv.Rows[x].Cells[1].Value.ToString();
                    banghi.SoLuong = System.Convert.ToInt32(dgv.Rows[x].Cells[3].Value.ToString());
                    banghi.PhanTramChietKhau = dgv.Rows[x].Cells[5].Value.ToString();
                    banghi.GhiChu = dgv.Rows[x].Cells[2].Value.ToString();
                    banghi.Deleted = false;
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
                mangBanghi = null;
            }
            return mangBanghi;
        }
        /// <summary>
        /// luu chi tiet don hang
        /// </summary>
        private void LuuChiTietDonHang()
        {
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            Entities.ChiTietHoaDonNhap[] luu = LuuChiTietHoaDonNhap(dgvInsertOrder, "Insert", txtSodonhang.Text.ToUpper());
            clientstrem = cl.SerializeHepper(this.client, "ChiTietHoaDonNhap", luu);
            int bao = 0;
            bao = (int)cl.DeserializeHepper(clientstrem, bao);
            if (bao == 1)
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
                        kho.Soluong = System.Convert.ToInt32(dgvInsertOrder.Rows[x].Cells[3].Value.ToString());
                        kho.Ngaynhap = DateTime.Now;
                        kho.Ngayhethan = 0;
                        kho.Ghichu = txtDiengiai.Text;
                        kho.Deleted = false;
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
                { khohang = null;}
                LuuChiTietVaoKhoHang(khohang);
            }
            else
            { MessageBox.Show("Chưa thêm vào kho"); }
        }
        /// <summary>
        /// luu chi tiet hoa don nhap vao kho hang
        /// </summary>
        private void LuuChiTietVaoKhoHang(Entities.ChiTietKhoHangTheoHoaHonNhap[] kho)
        {
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            clientstrem = cl.SerializeHepper(this.client, "ThemChiTietKhoHang", kho);
            int bao = 0;
            bao = (int)cl.DeserializeHepper(clientstrem, bao);
            if (bao == 1)
            { MessageBox.Show("Đã thêm vào kho"); }
            else
            { MessageBox.Show("Chưa thêm vào kho"); }
        }
        /// <summary>
        /// cap nhat lai trang thai don dat hang
        /// </summary>
        private void CapNhatTrangThaiDonDatHang(string hanhdong,string MaDonDatHang,string trangthai)
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
                //if (tralai == "OK")
                //{ MessageBox.Show("cap nhat thanh cong"); }
                //else
                //{ MessageBox.Show("Chưa thêm vào kho"); }
            }
            else
            { }
        }
        /// <summary>
        /// them moi, sua thong tin don dat hang
        /// </summary>
        /// <param name="hanhdong"></param>
        private void XuLy_HoaDonNhap(string hanhdong)
        {
            try
            {
                Entities.HoaDonNhap don = new Entities.HoaDonNhap();
                string thoigian_1 = null;
                thoigian_1 = new Common.Utilities().MyDateConversion(makNgaydonhang.Text);
                string thoigian_2 = null;
                thoigian_2 = new Common.Utilities().MyDateConversion(makHanthanhtoan.Text);
                if (thoigian_1 != null && thoigian_2 != null)
                {
                    don.NgayNhap = DateTime.Parse(thoigian_1);
                    thoigian_1 = null;
                    don.HanThanhToan = DateTime.Parse(thoigian_2);
                    thoigian_2 = null;
                    don.Hanhdong = hanhdong;
                    don.MaHoaDonNhap = "" + txtSodonhang.Text.ToUpper();
                    don.MaNhaCungCap = "" + txtManhacungcap.Text.ToUpper();
                    don.NoHienThoi = 0+txtNohienthoi.Text;
                    don.NguoiGiaoHang = "" + txtnguoigiaohang.Text;
                    don.HinhThucThanhToan = "" + cbxHinhthucthanhtoan.SelectedItem.ToString();
                    don.MaKho = "" + cbxKhoHang.SelectedValue.ToString().ToUpper();
                    don.DieuKienThanhToan = "" + cbxDieuKienThanhToan.SelectedItem.ToString();
                    string MaDonDatHang = txtMadondathang.Text.ToUpper();
                    if (MaDonDatHang == "<F4 -TRA CỨU>" || MaDonDatHang.Length <= 0)
                    {
                        MaDonDatHang = "NULL";
                    }
                    don.MaDonDatHang = MaDonDatHang;
                    don.MaTienTe = "" + cbxTienTe_TyGia.SelectedValue.ToString().ToUpper();
                    don.ChietKhau = 0+txtChietkhau.Text;
                    don.ThanhToanNgay = 0+txtThanhtoanngay.Text;
                    don.ThueGTGT = 0+txtGiatrigiatang.Text;
                    don.TongTien = 0+txtTongtien.Text;
                    don.GhiChu = txtDiengiai.Text;
                    don.Deleted = false;
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
                                LuuChiTietDonHang();
                                //cap nhat trang thai don dat hang
                                CapNhatTrangThaiDonDatHang("Update",MaDonDatHang,"Đã thành công");
                                MessageBox.Show("Thành công");
                                frmHienThi_HoaDonNhap.BaoDong = "";
                                this.Close();
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
       
        private void XuLy_Xoa_HoaDonNhap(string hanhdong, string mahoadonnhap)
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
                string chuoi = ddh.ID.ToString();
                Common.Utilities com = new Common.Utilities();
                txtSodonhang.Text = com.ProcessID(chuoi);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            client.Close();
            clientstrem.Close();
        }
        #endregion


        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    frmHienThi_HoaDonNhap.BaoDong = "A";
                    this.Close();
                }
                else
                { }
            }
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void thiêtLâpThôngSôToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOption fr = new frmOption();
            fr.ShowDialog();
        }

        private void xoaChưngTưHiênThơiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void huyĐơnĐătHangHiênThơiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void saoChepChưngTưTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void saoChepChưngTưSangNhâpHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void saoChepChưngTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            XuLy_HoaDonNhap("Update");
        }

        /// <summary>
        /// hungvv kiem tra dinh dang khi them moi hoa don
        /// </summary>
        /// <param name="maDonDatHang"></param>
        private Boolean CheckData(Entities.HoaDonNhap dat)
        {
            if (dat.MaHoaDonNhap.Length <= 0)
            {
                txtSodonhang.Focus();
                System.Windows.Forms.MessageBox.Show("Hãy nhập mã hóa đơn");
                return false;
            }
            else
            {
                if (dat.MaNhaCungCap.Length <= 0)
                {
                    txtManhacungcap.Focus();
                    MessageBox.Show("Kiểm tra mã nhà cung cấp");
                    return false;
                }
                else
                {
                    if (dat.DieuKienThanhToan.Length <= 0)
                    {
                        cbxDieuKienThanhToan.Focus();
                        MessageBox.Show("Chọn điều kiện thanh toán");
                        return false;
                    }
                    else
                    {
                        if (dat.MaKho.Length <= 0)
                        {
                            cbxKhoHang.Focus();
                            MessageBox.Show("Chọn mã kho");
                            return false;
                        }
                        else
                        {
                            if (dat.MaTienTe.Length <= 0)
                            {
                                cbxTienTe_TyGia.Focus();
                                MessageBox.Show("Loại tiền tệ không đúng");
                                return false;
                            }
                            else
                            {
                                if (dat.MaDonDatHang.Length <= 0 && chekChonLoai.Checked == true)
                                {
                                    txtMadondathang.Text = "";
                                    txtMadondathang.Focus();
                                    System.Windows.Forms.MessageBox.Show("Hãy nhập mã đơn đặt hàng");
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        }
        
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            if (txtManhacungcap.Text != "<F4 - Tra cứu>")
            {
                XuLy_HoaDonNhap("Insert");
            }
        }

        private void btnTimnhacungcap_Click(object sender, EventArgs e)
        {
            frmTraCuu fr = new frmTraCuu("HoaDonNhap_NhaCungCap", "HoaDonNhap");
            fr.ShowDialog();
            BindHangHoa();
        }

        /// <summary>
        /// do du lieu vao dgv
        /// </summary>
        private void DoiTen(DataGridView dgv)
        {
            dgv.RowHeadersVisible = false;
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "STT";
            dgv.Columns[2].HeaderText = "Mã hàng";
            dgv.Columns[3].HeaderText = "Tên hàng";
            dgv.Columns[4].HeaderText = "Giá gốc";
            dgv.Columns[5].HeaderText = "%CK";
            dgv.Columns[6].HeaderText = "Giá nhập";
            dgv.Columns[7].HeaderText = "Chiết khấu";
            dgv.Columns[8].HeaderText = "Tổng tiền";
            new Common.Utilities().CountDatagridview(dgv);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void HienThi_ChiTiet_HoaDonNhap(string MaDonHang)
        {
            try
            {
                Entities.HienThi_ChiTiet_DonDatHang dat = new Entities.HienThi_ChiTiet_DonDatHang( "Select",MaDonHang);
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "HienThi_ChiTiet_HoaDonNhap", dat);
                Entities.HienThi_ChiTiet_DonDatHang[] ddh = new Entities.HienThi_ChiTiet_DonDatHang[1];
                ddh = (Entities.HienThi_ChiTiet_DonDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                dgvInsertOrder.DataSource = ddh;
                //hien thi
                DoiTen(dgvInsertOrder);
                string tong = new Common.Utilities().TongTien(dgvInsertOrder);
                txtTienhang.Text = tong;
            }
            catch (Exception)
            { }
            client.Close();
            clientstrem.Close();
        }

        private void BindHangHoa()
        {
            if (GiaTriCanLuu.Loaitrave == "HoaDonNhap_NhaCungCap")
            {
                txtManhacungcap.Text = GiaTriCanLuu.Ma;
                lblTenNhaCungCap.Text = GiaTriCanLuu.Ten;
            }
            if (GiaTriCanLuu.Loaitrave == "HoaDonNhap_MaDonDatHang")
            {
                txtMadondathang.Text = GiaTriCanLuu.Ma;
                lblMaHoaDonNhap.Text = new Common.Utilities().XuLy(2, GiaTriCanLuu.Ten);
                HienThi_ChiTiet_HoaDonNhap(txtMadondathang.Text.ToUpper());
            }
            if (GiaTriCanLuu.Loaitrave == "HoaDonDat_HangHoa")
            {
                toolStrip_txtTracuu.Text = GiaTriCanLuu.Ma;
                toolStrip_txtTenhang.Text = GiaTriCanLuu.Ten;
                toolStrip_txtGiagoc.Text = GiaTriCanLuu.Giatri;
                toolStrip_txtGianhap.Text = GiaTriCanLuu.Giatri;
                toolStrip_txtSoluong.Text = "1";
                toolStrip_txtChietkhauphantram.Text = "0";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (hanhdong == "Insert")
            {
                frmTraCuu fr = new frmTraCuu("HoaDonNhap_MaDonDatHang", "MaDonDatHang");
                fr.ShowDialog();
                BindHangHoa();
            }
        }
        /// <summary>
        /// hungvv =================do du lieu vao txt===========================
        /// </summary>
        /// <param name="dat"></param>
        private void DoDuLieu(Entities.HoaDonNhap dat)
        {
            Common.Utilities com = new Common.Utilities();
            txtSodonhang.Text = dat.MaHoaDonNhap;
            txtManhacungcap.Text = dat.MaNhaCungCap;
            GiaTriCanLuu.Ma = dat.MaNhaCungCap;
            makNgaydonhang.Text = com.XuLy(2,dat.NgayNhap.ToString());
            makHanthanhtoan.Text = com.XuLy(2, dat.HanThanhToan.ToString());
            txtNohienthoi.Text = dat.NoHienThoi.ToString();
            txtnguoigiaohang.Text = dat.NguoiGiaoHang;
            cbxHinhthucthanhtoan.SelectedItem = dat.HinhThucThanhToan;
            cbxKhoHang.SelectedValue = dat.MaKho;
            cbxDieuKienThanhToan.SelectedItem = dat.DieuKienThanhToan;
            txtMadondathang.Text= dat.MaDonDatHang;
            cbxTienTe_TyGia.SelectedValue = dat.MaTienTe;
            txtChietkhau.Text = dat.ChietKhau.ToString();
            txtThanhtoanngay.Text = dat.ThanhToanNgay.ToString();
            txtGiatrigiatang.Text = dat.ThueGTGT.ToString();
            txtTongtien.Text = dat.TongTien.ToString();
            txtDiengiai.Text = dat.GhiChu;
            //HienThi_ChiTiet_HoaDonNhap();            
        }

        private void frmXuLy_NhapMua_Load(object sender, EventArgs e)
        {
            chekChonLoai.Checked = false;
            toolStrip_txtTracuu.Focus();
            toolStrip_txtTracuu.Text = "";
            //doc du lieu dong
            makNgaydonhang.Text = new Common.Utilities().XuLy(2, DateTime.Today.ToString());
            makHanthanhtoan.Text = new Common.Utilities().XuLy(2, DateTime.Today.ToString());
            frmXuLy_HoaDonNhap fr = new frmXuLy_HoaDonNhap();
            this.cbxDieuKienThanhToan.Items.AddRange(new object[] { "Thanh toán ngay", "Thanh toán từng phần", "Mua nợ" });
            this.cbxDieuKienThanhToan.Text = "Chọn loại thanh toán";
            this.cbxHinhthucthanhtoan.Items.AddRange(new object[] { "Tiền mặt", "Séc", "VISA", "MASTER CARD", "AMEX", "CONNECT", "JCB" });
            this.cbxHinhthucthanhtoan.Text = "Chọn hình thức thanh toán";
            
            LayKhoHang();
            LayTenTT();

            if (hanhdong == "Insert")
            {
                getID("HoaDonNhap");
                txtManhacungcap.ReadOnly = false;
                btnTimnhacungcap.Enabled = true;
                toolStripStatus_Ghilai.Enabled = false;
                toolStripStatus_Themmoi.Enabled = true;
                Application.OpenForms[fr.Name].Text = "Quản lý hóa đơn nhập - Thêm hóa đơn nhập";
            }
            if (hanhdong == "Update")
            {
                txtMadondathang.ReadOnly = true;
                btnTimMadatmuahang.Enabled = false;
                txtManhacungcap.ReadOnly = true;
                btnTimnhacungcap.Enabled = false;
                toolStripStatus_Ghilai.Enabled = true;
                toolStripStatus_Themmoi.Enabled = false;
                Application.OpenForms[fr.Name].Text = "Quản lý hóa đơn nhập - Sửa hóa đơn nhập";
                DoDuLieu(this.hoadon);
                if (txtSodonhang.Text.Length > 0)
                {
                    HienThi_ChiTiet_HoaDonNhap(txtMadondathang.Text.ToUpper());
                }
            }
        }

        private void toolStrip_txtTracuu_KeyDown(object sender, KeyEventArgs e)
        {
            if (chekChonLoai.Checked == true)
            {
                if (e.KeyCode == Keys.F4)
                {
                    frmTraCuu fr = new frmTraCuu("HoaDonDat_HangHoa", "HoaDonHangHoa");
                    fr.ShowDialog();
                    BindHangHoa();
                }
            }
            else
            { }
        }
        /// <summary>
        /// reset form
        /// </summary>
        private void ResetTool()
        {
            toolStrip_txtTracuu.Text = "<F4 - Tra cứu>";
            toolStrip_txtTenhang.Text = "";
            toolStrip_txtSoluong.Text = "1";
            toolStrip_txtGianhap.Text = "";
            toolStrip_txtGiagoc.Text = "0";
            toolStrip_txtChietkhau.Text = "";
            toolStrip_txtChietkhauphantram.Text = "";
        }

        /// <summary>
        /// hungvv --------------------kiem tra ma hang------------------
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string KiemTraMa(string ID)
        {
            string kt = null;
            Entities.KiemTraChung ktm = new Entities.KiemTraChung();
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            ktm = new Entities.KiemTraChung("Select", ID);
            clientstrem = cl.SerializeObj(this.client, "KiemTraMa", ktm);
            Entities.KiemTraChung tra = new Entities.KiemTraChung();
            tra = (Entities.KiemTraChung)cl.DeserializeHepper(clientstrem, tra);
            kt = tra.Hanhdong;
            return kt;
        }

        /// <summary>
        /// them hang moi
        /// </summary>
        private void NewRow()
        {
            //try
            //{
            if (txtManhacungcap.Text != "")
            {
                string ma = "" + toolStrip_txtTracuu.Text.ToUpper();
                string ten = "" + toolStrip_txtTenhang.Text;
                int soluong = Convert.ToInt32(0 + toolStrip_txtSoluong.Text);
                float gia = Convert.ToInt32(0 + toolStrip_txtGiagoc.Text);
                float chietkhau = (float)Convert.ToInt32(0 + toolStrip_txtChietkhauphantram.Text);
                float gianhap = (float)Convert.ToInt32(0 + toolStrip_txtGianhap.Text);
                float phantram = (float)Convert.ToInt32(0 + toolStrip_txtChietkhau.Text);
                string thongbao = KiemTraMa(ma.Trim());
                if (new Common.Utilities().TinhChietKhau(toolStrip_txtChietkhau, toolStrip_txtChietkhauphantram, toolStrip_txtGianhap, gia, chietkhau) == true)
                {
                    if (thongbao == "NO")
                    {
                        MessageBox.Show("Mã hàng không đúng");
                        toolStrip_txtTracuu.Focus();
                        return;
                    }
                    else
                    {
                        if (chietkhau > 100 || chietkhau < 0)
                        {
                            MessageBox.Show("chiết khấu quá lớn");
                            toolStrip_txtChietkhauphantram.Text = "";
                            toolStrip_txtChietkhauphantram.Focus();
                            return;
                        }
                        else
                        {
                            if (soluong < 0)
                            {
                                MessageBox.Show("số lượng không đúng");
                                toolStrip_txtSoluong.Focus();
                                return;
                            }
                            else
                            {
                                if (gianhap > gia || gianhap <= 0)
                                {
                                    toolStrip_txtGianhap.Focus();
                                    MessageBox.Show("giá nhập không đúng");
                                    return;
                                }
                                else
                                {
                                    dgvInsertOrder.DataSource = new Common.Utilities().LayGiaTri(dgvInsertOrder, ma, ten, soluong, gia, chietkhau, gianhap, phantram);
                                    txtTongtien.Text = new Common.Utilities().TongTien(dgvInsertOrder);
                                    txtTienhang.Text = txtTongtien.Text;
                                    dgvInsertOrder.RowHeadersVisible = false;
                                    dgvInsertOrder.Columns[0].HeaderText = "STT";
                                    dgvInsertOrder.Columns[1].HeaderText = "Mã hàng";
                                    dgvInsertOrder.Columns[2].HeaderText = "Tên hàng";
                                    dgvInsertOrder.Columns[3].HeaderText = "Số lượng";
                                    dgvInsertOrder.Columns[4].HeaderText = "Giá gốc";
                                    dgvInsertOrder.Columns[5].HeaderText = "%CK";
                                    dgvInsertOrder.Columns[6].HeaderText = "Giá nhập";
                                    dgvInsertOrder.Columns[7].HeaderText = "Chiết khấu";
                                    dgvInsertOrder.Columns[8].HeaderText = "Tổng tiền";
                                    new Common.Utilities().CountDatagridview(dgvInsertOrder);
                                    dgvInsertOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                    dgvInsertOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                    ResetTool();
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Kiểm tra chiết khấu");
                }
            }
            else
            {
                ResetTool();
                MessageBox.Show("Chọn nhà cung cấp");
                return;
            }
            //}
            //catch (Exception ex)
            //{ 
            //    string s = ex.ToString(); 
            //    MessageBox.Show("Kiểm tra dữ liệu cần thêm");
            //}
        }
        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {
            NewRow();
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

        private void toolStrip_txtChietkhauphantram_TextChanged(object sender, EventArgs e)
        {
            if (float.Parse(0 + toolStrip_txtChietkhauphantram.Text) <= 100 && float.Parse(0 + toolStrip_txtChietkhauphantram.Text) > 0)
            {
                toolStrip_txtGianhap.Text = (float.Parse(0 + toolStrip_txtGiagoc.Text) - ((float.Parse(0 + toolStrip_txtChietkhauphantram.Text) / 100) * (float.Parse(0 + toolStrip_txtGiagoc.Text)))).ToString();
                toolStrip_txtChietkhau.Text = ((float.Parse(0 + toolStrip_txtGiagoc.Text)) - (float.Parse(0 + toolStrip_txtGiagoc.Text) - ((float.Parse(0 + toolStrip_txtChietkhauphantram.Text) / 100) * (float.Parse(0 + toolStrip_txtGiagoc.Text))))).ToString();
            }
            else
            {
                toolStrip_txtChietkhauphantram.Text = "";
                toolStrip_txtGianhap.Text = toolStrip_txtGiagoc.Text;
                toolStrip_txtChietkhau.Text = "";
            }
        }

        private void toolStrip_txtChietkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (float.Parse(0 + toolStrip_txtChietkhauphantram.Text) == (float.Parse(0 + toolStrip_txtGiagoc.Text)))
            {
                toolStrip_txtGianhap.Text = "";
                toolStrip_txtChietkhau.Text = "100";
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
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMadondathang_KeyDown(object sender, KeyEventArgs e)
        {
            if (chekChonLoai.Checked == true)
            {
                if (e.KeyCode == Keys.F4)
                {
                    if (hanhdong == "Insert")
                    {
                        frmTraCuu fr = new frmTraCuu("HoaDonNhap_MaDonDatHang", "MaDonDatHang");
                        fr.ShowDialog();
                        BindHangHoa();
                    }
                }
            }
        }

        private void txtManhacungcap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                if (hanhdong == "Insert")
                {
                    frmTraCuu fr = new frmTraCuu("HoaDonNhap_NhaCungCap", "HoaDonNhap");
                    fr.ShowDialog();
                    BindHangHoa();
                }
            }
        }

        private void chekChonLoai_CheckedChanged(object sender, EventArgs e)
        {
            if (chekChonLoai.Checked == false)
            {
                txtMadondathang.ReadOnly = true;
                btnTimMadatmuahang.Enabled = false;
            }
            else
            {
                txtMadondathang.ReadOnly = false;
                btnTimMadatmuahang.Enabled = true;
            }
        }

        private void toolStrip_txtTracuu_MouseHover(object sender, EventArgs e)
        {
            if (chekChonLoai.Checked == true)
            {
                if (toolStrip_txtTracuu.Text == "<F4 -Tra cứu>")
                {
                    toolStrip_txtTracuu.Text = "";
                    toolStrip_txtTracuu.Focus();
                }
            }
        }

        private void txtManhacungcap_MouseHover(object sender, EventArgs e)
        {
            if (txtManhacungcap.Text == "<F4 -Tra cứu>")
            {
                txtManhacungcap.Text = "";
                txtManhacungcap.Focus();
            }
        }

        private void txtManhacungcap_MouseLeave(object sender, EventArgs e)
        {
            if (txtManhacungcap.Text == "")
            {
                txtManhacungcap.Text = "<F4 -Tra cứu>";
                txtManhacungcap.Focus();
            }
        }

        private void txtMadondathang_MouseHover(object sender, EventArgs e)
        {
            if (chekChonLoai.Checked == true)
            {
                if (txtMadondathang.Text == "<F4 -Tra cứu>")
                {
                    txtMadondathang.Text = "";
                    txtMadondathang.Focus();
                }
            }
        }

        private void txtMadondathang_MouseLeave(object sender, EventArgs e)
        {
            if (chekChonLoai.Checked == true)
            {
                if (txtMadondathang.Text == "")
                {
                    txtMadondathang.Text = "<F4 -Tra cứu>";
                }
            }
        }

        /// <summary>
        /// xoa du lieu
        /// </summary>
        /// <param name="dgv"></param>
        private int i;
        private void getDataTable(DataGridView dgv)
        {
            if (dgv.RowCount > 0)
            {
                toolStrip_txtTracuu.Text = dgv[1, i].Value.ToString();
                toolStrip_txtTenhang.Text = dgv[2, i].Value.ToString();
                toolStrip_txtSoluong.Text = Double.Parse(dgv[3, i].Value.ToString()).ToString();
                toolStrip_txtGiagoc.Text = Double.Parse(dgv[4, i].Value.ToString()).ToString();
                toolStrip_txtChietkhauphantram.Text = Double.Parse(dgv[5, i].Value.ToString()).ToString();
                toolStrip_txtGianhap.Text = Double.Parse(dgv[6, i].Value.ToString()).ToString();
                toolStrip_txtChietkhau.Text = Double.Parse(dgv[7, i].Value.ToString()).ToString();
                Entities.HienThi_ChiTiet_DonDatHang[] hh = new Entities.HienThi_ChiTiet_DonDatHang[dgv.RowCount];
                    int so = 0;
                    for (int j = 0; j < dgv.RowCount; j++)
                    {
                        if (dgv[1, j].Value.ToString() != dgv[1, i].Value.ToString())
                        {
                            hh[so] = new Entities.HienThi_ChiTiet_DonDatHang("" + dgv[1, j].Value.ToString(), "" + dgv[2, j].Value.ToString(), int.Parse(0 + dgv[3, j].Value.ToString()), "" + dgv[4, j].Value.ToString(), "" + dgv[5, j].Value.ToString(), "" + dgv[6, j].Value.ToString(), "" + dgv[7, j].Value.ToString(), "" + dgv[8, j].Value.ToString());
                            so++;
                        }
                        else
                        { continue; }
                    }
                    if (hh.Length <= 0)
                    { dgv.DataSource = null; dgv.Rows.Clear(); DoiTen(dgv); }
                    else
                    { dgv.DataSource = null; dgv.Rows.Clear();dgv.DataSource = hh; DoiTen(dgv); }
            }
            else
            {
                dgv.DataSource = null;
            }
        }

        
        private void dgvInsertOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            if (i < 0)
                dgvInsertOrder.Rows[0].Selected = true;
        }

       
        private void dgvInsertOrder_DoubleClick(object sender, EventArgs e)
        {
            try
            {
               getDataTable(dgvInsertOrder);
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
        }

       
        private int run = 0;
        private void toolStrip_txtTracuu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (chekChonLoai.Checked == false)
            {
                timerRun.Start();
            }
            else
            { timerRun.Stop(); run = 0; }
        }

        /// <summary>
        /// tim chi tiet hang hoa theo ma
        /// </summary>
        /// <param name="MaHang"></param>
        private void LayHangHoaTheoMa(string MaHang)
        {
            Entities.HienThi_ChiTiet_DonDatHang ktm = new Entities.HienThi_ChiTiet_DonDatHang();
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            ktm = new Entities.HienThi_ChiTiet_DonDatHang("Select", MaHang);
            clientstrem = cl.SerializeObj(this.client, "LayHangHoaTheoMaHangHoa", ktm);
            Entities.HienThi_ChiTiet_DonDatHang tra = new Entities.HienThi_ChiTiet_DonDatHang();
            tra = (Entities.HienThi_ChiTiet_DonDatHang)cl.DeserializeHepper(clientstrem, tra);
            if (tra == null)
            {
                MessageBox.Show("Mã bạn nhập không tồn tại");
            }
            else
            {
                timerRun.Stop();
                run = 0;
                toolStrip_txtTracuu.Text = tra.MaHangHoa;
                toolStrip_txtTenhang.Text = tra.TenHangHoa;
                toolStrip_txtSoluong.Text = tra.SoLuongDat.ToString();
                toolStrip_txtGiagoc.Text = tra.GiaGoc;
                toolStrip_txtChietkhauphantram.Text = tra.PhanTramChietKhau;
                toolStrip_txtGianhap.Text = tra.GiaNhap;
                toolStrip_txtChietkhau.Text = tra.ChietKhau;
            }
        }
        private void timerRun_Tick(object sender, EventArgs e)
        {
            if (toolStrip_txtTracuu.Text.Length > 0)
            {
                run++;
                if (run == 10)
                {
                    timerRun.Stop();
                    LayHangHoaTheoMa(toolStrip_txtTracuu.Text.ToUpper());
                    NewRow();
                    toolStrip_txtTracuu.Text = "";
                    run = 0;
                }
            }
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
