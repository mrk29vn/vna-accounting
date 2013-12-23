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
        #region khoi tao=============================================================
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

        #region hungvv==============================================khoi tao=====================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        #endregion

        #region Select============================================================================================================================
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
        
        /// <summary>
        /// hungvv =======================giao tiep voi server===========================
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
                dgvInsertOrder.DataSource = ddh;
                //dgvInsertOrder.Columns[1].Visible = false;
                dgvInsertOrder.Columns[0].HeaderText = "STT";
                new Common.Utilities().CountDatagridview(dgvInsertOrder);
            }
            catch (Exception)
            { }
            client.Close();
            clientstrem.Close();
        }
        /// <summary>
        /// do du lieu vao dgv
        /// </summary>
        private void DoiTen(DataGridView dgv)
        {
            dgv.RowHeadersVisible = false;
            dgv.Columns[0].HeaderText = "STT";
            dgv.Columns[1].HeaderText = "Mã hàng";
            dgv.Columns[2].HeaderText = "Tên hàng";
            dgv.Columns[3].HeaderText = "Số Lượng";
            dgv.Columns[4].HeaderText = "Giá gốc";
            dgv.Columns[5].HeaderText = "%CK";
            dgv.Columns[6].HeaderText = "Giá nhập";
            dgv.Columns[7].HeaderText = "Chiết khấu";
            dgv.Columns[8].HeaderText = "Tổng tiền";
            new Common.Utilities().CountDatagridview(dgv);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        /// <summary>
        /// do du lieu vao dgv
        /// </summary>
        private void HienThi_ChiTiet_DonDatHang()
        {
            try
            {
                Entities.DonDatHang dat = new Entities.DonDatHang();
                dat.Hanhdong = "Select";
                dat.MaNhaCungCap = GiaTriCanLuu.Ma.ToString().ToUpper();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "HienThi_ChiTiet_DonDatHang", dat);
                Entities.HienThi_ChiTiet_DonDatHang[] ddh = new Entities.HienThi_ChiTiet_DonDatHang[1];
                ddh = (Entities.HienThi_ChiTiet_DonDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                dgvInsertOrder.DataSource = ddh;
                DoiTen(dgvInsertOrder);
            }
            catch (Exception)
            { }
            client.Close();
            clientstrem.Close();
        }
        #endregion

        #region Binding combox======================================================================================================================
        /// <summary>
        ///  Lấy Kho Hàng
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
                Common.Utilities com = new Common.Utilities();
                com.BindingCombobox(ddh, cbxMaKho, "giatri", "khoachinh");
                this.cbxMaKho.Text = "Chọn kho hàng";
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
                cbxTiente_Tygia.Items.Clear();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KiemTraChung tt1 = new Entities.KiemTraChung();
                tt1 = new Entities.KiemTraChung("Select", "TienTe", "MaTienTe", "TenTienTe");
                clientstrem = cl.SerializeObj(this.client, "LayCombox", tt1);
                Entities.KiemTraChung[] tt = new Entities.KiemTraChung[1];
                tt = (Entities.KiemTraChung[])cl.DeserializeHepper1(clientstrem, tt);
                Common.Utilities com = new Common.Utilities();
                com.BindingCombobox(tt, cbxTiente_Tygia, "giatri", "khoachinh");
                cbxTiente_Tygia.Text = "Chọn tiền tệ";
            }
            catch
            {
                cbxTiente_Tygia.Items.Clear();
                cbxTiente_Tygia.Text = "";
            }
            client.Close();
            clientstrem.Close();
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
                Common.Utilities com = new Common.Utilities();
                com.BindingCombobox(tt, cbxNhanvien, "giatri", "khoachinh");
                cbxNhanvien.Text = "Chọn nhân viên";
            }
            catch (Exception)
            {
                cbxNhanvien.Items.Clear();
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
        public Entities.ChiTietDonDatHang[] LuuChiTietKhoHang(DataGridView dgv, string hanhdong, string madondathang)
        {
            ArrayList arr = new ArrayList();
            int i = dgv.RowCount;
            Entities.ChiTietDonDatHang[] mangBanghi = null;
            if (i > 0)
            {
                for (int x = 0; x < i; x++)
                {
                    Entities.ChiTietDonDatHang banghi = new Entities.ChiTietDonDatHang();
                    banghi.Hanhdong = hanhdong;
                    banghi.MaDonDatHang = madondathang.ToUpper();
                    banghi.MaHangHoa = dgv.Rows[x].Cells[1].Value.ToString();
                    banghi.SoLuong = System.Convert.ToInt32(dgv.Rows[x].Cells[3].Value.ToString());
                    banghi.PhanTramChietKhau = dgv.Rows[x].Cells[5].Value.ToString();
                    banghi.GhiChu = dgv.Rows[x].Cells[2].Value.ToString();
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
            Entities.ChiTietDonDatHang[] luu = LuuChiTietKhoHang(dgvInsertOrder, "Insert", txtSodonhang.Text.ToUpper());
            clientstrem = cl.SerializeHepper(this.client, "ChiTietDonDatHang", luu);
            int bao = 0;
            bao = (int)cl.DeserializeHepper(clientstrem, bao);            
        }
       
        /// <summary>
        /// them moi, sua thong tin don dat hang
        /// </summary>
        /// <param name="hanhdong"></param>
        private void XuLy_DonDatHang(string hanhdong)
        {
            try
            {
                Entities.DonDatHang don = new Entities.DonDatHang();
                string thoigian_1 = null;
                thoigian_1 = new Common.Utilities().MyDateConversion(makNgaydonhang.Text);
                string thoigian_2 = null;
                thoigian_2 = new Common.Utilities().MyDateConversion(makNgaynhapdukien.Text);
                if (thoigian_1 != null && thoigian_2 != null)
                {
                    don.NgayDonHang = DateTime.Parse(thoigian_1);
                    thoigian_1 = null;
                    don.NgayNhapDuKien = DateTime.Parse(thoigian_2);
                    thoigian_2 = null;
                    don.Hanhdong = hanhdong;
                    don.MaDonDatHang = "" + txtSodonhang.Text.ToUpper();
                    don.LoaiDonDatHang = check_loaidathang.Checked;
                    don.MaNhaCungCap = "" + txtManhacungcap.Text.ToUpper();
                    don.NoHienThoi = txtNohienthoi.Text.ToString();
                    don.TrangThaiDonDatHang = "" + txtTrangthaidonhang.Text.ToString();
                    don.DieuKienThanhToan = "" + cbxDieukienthanhtoan.SelectedItem.ToString(); ;
                    don.HinhThucThanhToan = "" + cbxHinhthucthanhtoan.SelectedItem.ToString();
                    don.MaKho = "" + cbxMaKho.SelectedValue.ToString().ToUpper();
                    don.MaNhanVien = cbxNhanvien.SelectedValue.ToString().ToUpper();
                    don.MaTienTe = "" + cbxTiente_Tygia.SelectedValue.ToString().ToUpper();
                    don.ThueGTGT =  txtGiatrigiatang.Text;
                    don.Phivanchuyen =  txtPhivanchuyen.Text;
                    don.PhiKhac = txtPhikhac.Text;
                    don.GhiChu = "" + txtDiengiai.Text.ToString();
                    don.Deleted = false;
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
                                MessageBox.Show("Thành công");
                                frmHienThi_DonDatHang.BaoDong = "";
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Thất bại");
                            }
                        }
                    }
                    else
                    {  MessageBox.Show("Không có hàng hóa trong đơn đặt hàng");}
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
        /// <summary>
        /// kiem tra dinh dang nhap khi them chi tiet vao dgv
        /// </summary>
        /// <param name="soluong"></param>
        private Boolean CheckDetail(int soluong, float giagoc, float gianhap)
        {
            if (soluong < 1)
            {
                toolStrip_txtSoluong.Focus();
                MessageBox.Show("Nhập số lượng");
                return false;
            }
            else
            {
                if (giagoc < 0)
                {
                    toolStrip_txtGiagoc.Focus();
                    MessageBox.Show("Nhập giá gốc");
                    return false;
                }
                else
                {
                    if (gianhap < 0)
                    {
                        toolStrip_txtGianhap.Focus();
                        MessageBox.Show("Giá nhập nhập không đúng");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }


        /// <summary>
        /// hungvv kiem tra dinh dang khi them moi hoa don
        /// </summary>
        /// <param name="maDonDatHang"></param>
        private Boolean CheckData(Entities.DonDatHang dat)
        {
            if (dat.MaDonDatHang.Length <= 0)
            {
                txtSodonhang.Focus();
                System.Windows.Forms.MessageBox.Show("Hãy nhập mã đơn đặt hàng");
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
                        cbxDieukienthanhtoan.Focus();
                        MessageBox.Show("Chọn điều kiện thanh toán");
                        return false;
                    }
                    else
                    {
                        if (dat.MaKho.Length <= 0)
                        {
                            cbxMaKho.Focus();
                            MessageBox.Show("Chọn mã kho");
                            return false;
                        }
                        else
                        {
                            if (dat.MaTienTe.Length <= 0)
                            {
                                cbxTiente_Tygia.Focus();
                                MessageBox.Show("Loại tiền tệ không đúng");
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

        /// <summary>
        /// xoa don dat hang
        /// </summary>
        /// <param name="madondathang"></param>
        private void Xoa_DonDatHang(string madondathang)
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
        #endregion

        /// <summary>
        /// hungvv thoat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    frmHienThi_DonDatHang.BaoDong = "A";
                    this.Close();
                }
                else
                { }
            }
        }

        #region do du lieu khi can sua=================================================================
        /// <summary>
        /// hungvv =================do du lieu vao txt===========================
        /// </summary>
        /// <param name="dat"></param>
        private void DoDuLieu(Entities.DonDatHang dat)
        {
            Common.Utilities com = new Common.Utilities();
            txtSodonhang.Text = dat.MaDonDatHang;
            txtManhacungcap.Text = dat.MaNhaCungCap;
            GiaTriCanLuu.Ma = dat.MaNhaCungCap;
            txtTrangthaidonhang.Text = dat.TrangThaiDonDatHang;
            cbxDieukienthanhtoan.SelectedValue = dat.DieuKienThanhToan;
            cbxMaKho.Text = dat.MaKho;
            makNgaydonhang.Text = com.XuLy(2,this.dathang.NgayDonHang.ToString());
            makNgaynhapdukien.Text = com.XuLy(2,this.dathang.NgayNhapDuKien.ToString());
            txtNohienthoi.Text = dat.NoHienThoi.ToString();
            txtPhuongthucvanchuyen.Text = dat.ToString();
            cbxDieukienthanhtoan.SelectedItem = dat.DieuKienThanhToan.ToString();
            cbxHinhthucthanhtoan.SelectedItem = dat.HinhThucThanhToan.ToString();
            cbxNhanvien.SelectedValue = dat.MaNhanVien.ToString();
            check_loaidathang.Checked = dat.LoaiDonDatHang;
            cbxTiente_Tygia.SelectedValue = dat.MaTienTe.ToString();
            txtDiengiai.Text = dat.GhiChu;
            txtPhikhac.Text = dat.PhiKhac.ToString();
            txtPhivanchuyen.Text = dat.Phivanchuyen.ToString();
            HienThi_ChiTiet_DonDatHang();
        }
        #endregion
        /// <summary>
        /// ham main
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXuLy_DonDatHang_Load(object sender, EventArgs e)
        {
            //doc du lieu dong
            makNgaydonhang.Text = new Common.Utilities().XuLy(2,DateTime.Today.ToString());
            makNgaynhapdukien.Text = new Common.Utilities().XuLy(2,DateTime.Today.ToString());
           
            LayKhoHang();
            LayTenTT();
            LayNhanVien();
            //fig cung combox
            this.cbxDieukienthanhtoan.Items.AddRange(new object[] { "Thanh toán ngay", "Thanh toán từng phần", "Mua nợ" });
            this.cbxDieukienthanhtoan.Text = "Chọn loại thanh toán";
            this.cbxHinhthucthanhtoan.Items.AddRange(new object[] { "Tiền mặt", "Séc", "VISA", "MASTER CARD", "AMEX", "CONNECT", "JCB" });
            this.cbxHinhthucthanhtoan.Text = "Chọn hình thức thanh toán";
            this.txtTrangthaidonhang.Text = "Đang mở";
            frmXuLyDonDatHang fr = new frmXuLyDonDatHang();
            //danh cho delete
            if (this.HanhDong == "Insert")
            {
                getID("DonDatHang");
                btnTimnhacungcap.Enabled = true;
                txtManhacungcap.ReadOnly = false;
                toolStripStatus_Them.Enabled = true;
                toolStripStatus_Ghilai.Enabled = false;
                Application.OpenForms[fr.Name].Text = "Quản lý đơn đặt hàng - Thêm đơn đặt hàng";
                txtTrangthaidonhang.ReadOnly = true;
            }
            //danh cho update
            if (this.HanhDong == "Update")
            {
                btnTimnhacungcap.Enabled = false;
                txtManhacungcap.ReadOnly = true;
                toolStripStatus_Them.Enabled = false;
                toolStripStatus_Ghilai.Enabled = true;
                Application.OpenForms[fr.Name].Text = "Quản lý đơn đặt hàng - Sửa đơn đặt hàng";
                DoDuLieu(this.dathang);
                if (txtTrangthaidonhang.Text == "Đã thành công")
                {
                    toolStripStatus_Ghilai.Enabled = false;
                    toolStripStatusLabel3.Enabled = false;
                    toolStripStatusLabel4.Enabled = true;
                    toolStripDropDownButton1.Enabled = false;
                    btnTimnhacungcap.Enabled = false;
                }
            }
        }

        private void btnTimnhacungcap_Click(object sender, EventArgs e)
        {
            frmTraCuu fr = new frmTraCuu("DonDatHang_NhaCungCap", "NhaCungCap");
            fr.ShowDialog();
            BindHangHoa();
        }

        /// <summary>
        /// hungvv them moi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            XuLy_DonDatHang("Insert");
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            XuLy_DonDatHang("Update");
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa xử lý");
        }

        private void thiêtLâpThôngSôToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOption fr = new frmOption();
            fr.ShowDialog();
        }

        #region lay matxt=================================================================
        /// <summary>
        /// lay ID tu form tra cuu
        /// </summary>
        private void BindHangHoa()
        {
            if (GiaTriCanLuu.Loaitrave == "DonDatHang_NhaCungCap")
            {
                txtManhacungcap.Text = GiaTriCanLuu.Ma;
                lblTennhacungcap.Text = GiaTriCanLuu.Ten;
                HienThi_ChiTiet_DonDatHang();
            }
            if (GiaTriCanLuu.Loaitrave == "DonDatHang_HangHoa")
            {

                toolStrip_txtTracuu.Text = GiaTriCanLuu.Ma;
                toolStrip_txtTenhang.Text = GiaTriCanLuu.Ten;
                toolStrip_txtGiagoc.Text = GiaTriCanLuu.Giatri;
                toolStrip_txtGianhap.Text = GiaTriCanLuu.Giatri;
                toolStrip_txtSoluong.Text = "1";
                toolStrip_txtChietkhauphantram.Text = "";
            }
        }
        #endregion

        private void toolStrip_txtTracuu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                if (txtManhacungcap.Text.Length > 0)
                {
                    frmTraCuu fr = new frmTraCuu("DonDatHang_HangHoa", "HangHoa");
                    fr.ShowDialog();
                    BindHangHoa();
                }
                else
                {
                    MessageBox.Show("Nhập mã nhà cung cấp");
                }
            }
        }
        #region chi tiet don hang-----------------------------------------------------------------------------------------------
        /// <summary>
        /// hungvv --------------------kiem tra ma hang khi them chi tiet hang------------------
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
        /// them hang moi 1 row vao dgv
        /// </summary>
        private void NewRow()
        {
            try
            {
                if (txtManhacungcap.Text != "")
                {
                    string ma = "" + toolStrip_txtTracuu.Text.ToUpper();
                    string ten = "" + toolStrip_txtTenhang.Text;
                    int soluong = int.Parse(0 + toolStrip_txtSoluong.Text);
                    Double gia = Convert.ToInt32(0 + toolStrip_txtGiagoc.Text);
                    Double chietkhau = Double.Parse(0 + toolStrip_txtChietkhauphantram.Text);
                    Double gianhap = Double.Parse(0 + toolStrip_txtGianhap.Text);
                    Double phantram = Double.Parse(0 + toolStrip_txtChietkhau.Text);
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
                                        //Entities.HienThi_ChiTiet_DonDatHang newrow = new Entities.HienThi_ChiTiet_DonDatHang(ma, ten, soluong, gia, phantram, gianhap, chietkhau);
                                        dgvInsertOrder.DataSource = new Common.Utilities().LayGiaTri(dgvInsertOrder, ma, ten, soluong, gia, chietkhau, gianhap, phantram);
                                        txtTongtien.Text = new Common.Utilities().TongTien(dgvInsertOrder);
                                        txtTienhang.Text = txtTongtien.Text;
                                        dgvInsertOrder.RowHeadersVisible = false;
                                        dgvInsertOrder.Columns[0].HeaderText = "STT";
                                        dgvInsertOrder.Columns[1].HeaderText = "Mã hàng";
                                        dgvInsertOrder.Columns[2].HeaderText = "Tên hàng hóa";
                                        dgvInsertOrder.Columns[3].HeaderText = "Số lượng";
                                        dgvInsertOrder.Columns[4].HeaderText = "Giá gốc";
                                        dgvInsertOrder.Columns[5].HeaderText = "Chiết khấu";
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
            }
            catch (Exception ex)
            { 
                string s = ex.ToString(); 
                MessageBox.Show("Kiểm tra dữ liệu cần thêm");
            }
        }

        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {
            NewRow();
        }

        /// <summary>
        /// reset form
        /// </summary>
        private void ResetTool()
        {
            toolStrip_txtTracuu.Text = "<F4-Tìm hàng>";
            toolStrip_txtTenhang.Text = "";
            toolStrip_txtSoluong.Text = "1";
            toolStrip_txtGianhap.Text = "";
            toolStrip_txtGiagoc.Text = "0";
            toolStrip_txtChietkhau.Text = "";
            toolStrip_txtChietkhauphantram.Text = "";
        }

        private void txtManhacungcap_TextChanged(object sender, EventArgs e)
        {
            if (txtManhacungcap.Text == "")
            {
                ResetTool();
                dgvInsertOrder.DataSource = null;
            }
        }

        private void txtManhacungcap_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.HanhDong == "Insert")
            {
                if (e.KeyCode == Keys.F4)
                {
                    frmTraCuu fr = new frmTraCuu("DonDatHang_NhaCungCap", "NhaCungCap");
                    fr.ShowDialog();
                    BindHangHoa();
                    ResetTool();
                }
            }
        }
        #endregion
        #region ---------------------------------------------------------------------------------------------------------------
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

        private void toolStrip_txtSoluong_TextChanged(object sender, EventArgs e)
        {
            if (toolStrip_txtSoluong.Text.Length > 5 || toolStrip_txtSoluong.Text=="0")
            {
                toolStrip_txtSoluong.Text = "1";
            }
            if (toolStrip_txtSoluong.Text.Length ==1 && toolStrip_txtSoluong.Text == "0")
            {
                toolStrip_txtSoluong.Text = "1";
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
        #endregion

        private void palNhap_Paint(object sender, PaintEventArgs e)
        {

        }
        private string check = "";
        private void frmXuLyDonDatHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (check == "")
            {
                frmHienThi_DonDatHang.BaoDong = "A";
            }
        }

        /// <summary>
        /// xoa du lieu
        /// </summary>
        /// <param name="dgv"></param>
        private int i;
        private void getDataTable(DataGridView dgv)
        {
            if (dgv.RowCount > 1)
            {
                toolStrip_txtTracuu.Text = dgv[1, i].Value.ToString();
                toolStrip_txtTenhang.Text = dgv[2, i].Value.ToString();
                toolStrip_txtSoluong.Text = Double.Parse(dgv[3, i].Value.ToString()).ToString();
                toolStrip_txtGiagoc.Text = Double.Parse(dgv[4, i].Value.ToString()).ToString();
                toolStrip_txtChietkhauphantram.Text = Double.Parse(dgv[5, i].Value.ToString()).ToString();
                toolStrip_txtGianhap.Text = Double.Parse(dgv[6, i].Value.ToString()).ToString();
                toolStrip_txtChietkhau.Text = Double.Parse(dgv[7, i].Value.ToString()).ToString();
                Entities.HienThi_ChiTiet_DonDatHang[] hh = new Entities.HienThi_ChiTiet_DonDatHang[dgv.RowCount-1];
                int so = 0;
                for (int j = 0; j < dgv.RowCount; j++)
                {
                    if (dgv[1, j].Value.ToString() != dgv[1, i].Value.ToString())
                    {
                        hh[so] = new Entities.HienThi_ChiTiet_DonDatHang("" + dgv[1, j].Value.ToString(), "" + dgv[2, j].Value.ToString(), int.Parse(0 + dgv[3, j].Value.ToString()), "" + dgv[4, j].Value.ToString(), "" + dgv[5, j].Value.ToString(), "" + dgv[6, j].Value.ToString(), "" + dgv[7, j].Value.ToString(), "" + dgv[8, j].Value.ToString());
                        so++;
                    }
                }
                if (hh.Length <= 0)
                { dgv.DataSource = null; DoiTen(dgv); }
                else
                { dgv.DataSource = null; dgv.DataSource = hh; DoiTen(dgv); }
            }
            else
            {
                dgv.DataSource = null;
            }
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

        private void dgvInsertOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            if (i < 0)
                dgvInsertOrder.Rows[0].Selected = true;
        }

        private void txtManhacungcap_MouseHover(object sender, EventArgs e)
        {
            if(txtManhacungcap.Text=="<F4-Tìm hàng>")
            { txtManhacungcap.Text = ""; }
        }

        private void txtManhacungcap_MouseLeave(object sender, EventArgs e)
        {
            if (txtManhacungcap.Text == "")
            { txtManhacungcap.Text = "<F4-Tìm hàng>"; }
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