using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmXuLyKhoHang : Form
    {
        //Phần Khai Báo
        #region Khai Báo --------------------hungvv-------------------------
        public frmXuLyKhoHang()
        {
            InitializeComponent();
        }
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        Server_Client.Client cl;
        private string id;

        private DataGridViewRow dgv;
        public DataGridViewRow Dgv
        {
            get { return dgv; }
            set { dgv = value; }
        }

        private string hanhDong;
        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }

        public frmXuLyKhoHang(string hanhdong)
        {
            InitializeComponent();
            this.hanhDong = hanhdong;
        }

        public frmXuLyKhoHang(string hanhdong, DataGridViewRow dgvr)
        {
            InitializeComponent();
            this.hanhDong = hanhdong;
            this.dgv = dgvr;
        }

        private Entities.KhoHang khohang;
        public Entities.KhoHang Khohang
        {
            get { return khohang; }
            set { khohang = value; }
        }
        public frmXuLyKhoHang(string hanhdong, DataGridViewRow dgvr, Entities.KhoHang kho)
        {
            InitializeComponent();
            this.hanhDong = hanhdong;
            this.dgv = dgvr;
            this.khohang = kho;
        }
        #endregion

        #region ket noi server --------hungvv----------------------------------
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
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                top = new Entities.LayID("Select", table);
                networkStream = cl.SerializeObj(this.tcpClient, "LayID", top);
                Entities.LayID ddh = new Entities.LayID();
                ddh = (Entities.LayID)cl.DeserializeHepper(networkStream, ddh);
                tcpClient.Close();
                networkStream.Close();
                if (ddh.ID != null)
                {
                    string chuoi = ddh.ID.ToString();
                    Common.Utilities com = new Common.Utilities();
                    makiemtra = com.ProcessID(chuoi);
                }
                else
                {
                    makiemtra = "MK_0001";
                    txtMaKho.Text = "";
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                if (txtMaKho.Text == "")
                {
                    makiemtra = "MK_0001";
                    txtMaKho.Text = "";
                }
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
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KiemTraChung tt1 = new Entities.KiemTraChung();
                tt1 = new Entities.KiemTraChung("Select", "NhanVien", "MaNhanVien", "TenNhanVien");
                networkStream = cl.SerializeObj(this.tcpClient, "LayCombox", tt1);
                Entities.KiemTraChung[] tt = new Entities.KiemTraChung[1];
                tt = (Entities.KiemTraChung[])cl.DeserializeHepper1(networkStream, tt);
                tcpClient.Close();
                networkStream.Close();
                if (tt.Length > 0)
                {
                    Common.Utilities com = new Common.Utilities();
                    com.BindingCombobox(tt, cbxMaNhanVien, "giatri", "khoachinh");
                }
                else
                {
                    frmXuly_NhanVien frm = new frmXuly_NhanVien();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                cbxMaNhanVien.Items.Clear();
                string s = ex.Message.ToString();
            }
        }
        /// <summary>
        /// Xu ly kho hang-----------------------------------
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private int ID = 0;
        private void XuLyKhoHang(string hanhdong)
        {
            try
            {
                Server_Client.Client client = new Server_Client.Client();
                this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
                Entities.KhoHang kh = new Entities.KhoHang();
                kh = new Entities.KhoHang(hanhdong, ID, txtMaKho.Text, txtTenKho.Text, txtDiaChi.Text, txtSoDienThoai.Text, cbxMaNhanVien.SelectedValue.ToString(), txtGhiChu.Text, false);
                kh.Manhanvien = Common.Utilities.User.NhanVienID;
                kh.Tendangnhap = Common.Utilities.User.TenDangNhap;
                networkStream = client.SerializeObj(this.tcpClient, "KhoHang", kh);
                Entities.KhoHang k = new Entities.KhoHang();
                k = (Entities.KhoHang)client.DeserializeHepper(networkStream, k);
                if (k.GhiChu == "OK")
                {
                    frmQuanLyKhoHang.BaoDong = "";
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// hien thi chi tiet hang hoa theo ma kho
        /// </summary>
        /// <param name="mahang"></param>
        private void BindingHang(string mahang)
        {
            try
            {
                Entities.TruyenGiaTri top = new Entities.TruyenGiaTri();
                cl = new Server_Client.Client();
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                top = new Entities.TruyenGiaTri("Select", mahang);
                networkStream = cl.SerializeObj(this.tcpClient, "ChiTietKhoTheoMaKho", top);
                Entities.ChiTietKhoHangTheoMa[] ddh = new Entities.ChiTietKhoHangTheoMa[1];
                ddh = (Entities.ChiTietKhoHangTheoMa[])cl.DeserializeHepper(networkStream, ddh);
                if (ddh.Length > 0)
                {
                    dgvHangHoa.DataSource = null;
                    dgvHangHoa.DataSource = ddh;
                }
                else
                {
                    Entities.ChiTietKhoHangTheoMa[] h = new Entities.ChiTietKhoHangTheoMa[0];
                    dgvHangHoa.DataSource = h;
                }
                fixDatagridview();
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.ChiTietKhoHangTheoMa[] h = new Entities.ChiTietKhoHangTheoMa[0];
                dgvHangHoa.DataSource = h;
                fixDatagridview();
            }
        }
        /// <summary>
        /// cap nhat lai dgv
        /// </summary>
        private void fixDatagridview()
        {
            try
            {
                dgvHangHoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvHangHoa.RowHeadersVisible = false;
                dgvHangHoa.Columns["MaHangHoa"].Visible = true;
                dgvHangHoa.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
                dgvHangHoa.Columns["Makho"].Visible = false;
                dgvHangHoa.Columns["Makho"].HeaderText = "Mã Kho";
                dgvHangHoa.Columns["Tenkho"].Visible = true;
                dgvHangHoa.Columns["Tenkho"].HeaderText = "Tên Kho";
                dgvHangHoa.Columns["Tenhang"].Visible = true;
                dgvHangHoa.Columns["Tenhang"].HeaderText = "Tên Hàng";
                dgvHangHoa.Columns["Soluong"].Visible = true;
                dgvHangHoa.Columns["Soluong"].HeaderText = "Số Lượng";
                dgvHangHoa.Columns["Gianhap"].Visible = true;
                dgvHangHoa.Columns["Gianhap"].HeaderText = "Giá Nhập";
                dgvHangHoa.Columns["Ngaynhap"].Visible = true;
                dgvHangHoa.Columns["Ngaynhap"].HeaderText = "Ngày Nhập";
                dgvHangHoa.Columns["Ngayhethan"].Visible = true;
                dgvHangHoa.Columns["Ngayhethan"].HeaderText = "Ngày Hết Hạn";
                dgvHangHoa.Columns["TongTien"].Visible = true;
                dgvHangHoa.Columns["TongTien"].HeaderText = "Tổng Tiền";
                //dgvHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHangHoa.AllowUserToAddRows = false;
                dgvHangHoa.AllowUserToDeleteRows = false;
                dgvHangHoa.AllowUserToResizeRows = false;

                //dgvHangHoa.Columns[0].Visible = true;
                //dgvHangHoa.Columns[1].HeaderText = "Tên kho";
                //dgvHangHoa.Columns[2].HeaderText = "Tên hàng";
                //dgvHangHoa.Columns[3].HeaderText = "Số lượng";
                //dgvHangHoa.Columns[4].HeaderText = "Giá gốc";
                //dgvHangHoa.Columns[5].HeaderText = "Ngày nhập";
                //dgvHangHoa.Columns[6].HeaderText = "Hạn sử dụng";
                //dgvHangHoa.Columns[7].HeaderText = "Tổng Tiền";
                groupThongtinhanghoatrongkho.Text = "Tìm thấy " + dgvHangHoa.RowCount + " bản ghi";
                //dgvHangHoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        public string kt = "1";
        /// <summary>
        /// kiem tra ma khi them moi kho --------------------------------------------------------check--------------------
        /// </summary>
        public void CheckConflictInsert()
        {
            try
            {
                Server_Client.Client client = new Server_Client.Client();
                this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
                Entities.KhoHang nh = new Entities.KhoHang("Select");
                Entities.KhoHang[] nh1 = new Entities.KhoHang[1];
                networkStream = client.SerializeObj(this.tcpClient, "KhoHang", nh);
                nh1 = (Entities.KhoHang[])client.DeserializeHepper1(networkStream, nh1);
                if (nh1 != null)
                {
                    for (int j = 0; j < nh1.Length; j++)
                    {
                        if (nh1[j].MaKho == txtMaKho.Text)
                        {
                            MessageBox.Show("Cập nhật mã hàng hóa");
                            kt = "ko";
                            txtMaKho.Text = new Common.Utilities().ProcessID(txtMaKho.Text);
                            break;
                        }
                        else
                            kt = "ok";
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
        }
        /// <summary>
        /// hungvv =======================lay du lieu moi checkfix===========================
        /// </summary>
        private Entities.KhoHang ConfilickData(string table, string values)
        {
            Entities.KhoHang ddh = null;
            try
            {
                cl = new Server_Client.Client();
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TruyenGiaTri gitri = new Entities.TruyenGiaTri("Select", table, values);
                networkStream = cl.SerializeObj(this.tcpClient, "CheckKhoHang", gitri);
                ddh = new Entities.KhoHang();
                ddh = (Entities.KhoHang)cl.DeserializeHepper(networkStream, ddh);
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                ddh = null;
            }
            return ddh;
        }
        /// <summary>
        /// kiem tra
        /// </summary>
        /// <param name="gitri"></param>
        /// <param name="sosanh"></param>
        /// <returns></returns>
        private Boolean checkconflictUpdate(Entities.KhoHang gitri, Entities.KhoHang sosanh)
        {
            Boolean kiemtra = false;
            try
            {
                int count = 0;
                if (gitri.KhoHangID != sosanh.KhoHangID)
                { kiemtra = false; ID = sosanh.KhoHangID; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.MaKho != sosanh.MaKho)
                { kiemtra = false; txtMaKho.Text = sosanh.MaKho; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.TenKho != sosanh.TenKho)
                { kiemtra = false; txtTenKho.Text = sosanh.TenKho; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.DiaChi != sosanh.DiaChi)
                { kiemtra = false; txtDiaChi.Text = sosanh.DiaChi; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.DienThoai != sosanh.DienThoai)
                { kiemtra = false; txtSoDienThoai.Text = sosanh.DienThoai; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.MaNhanVien != sosanh.MaNhanVien)
                { kiemtra = false; cbxMaNhanVien.SelectedValue = sosanh.MaNhanVien; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.GhiChu != sosanh.GhiChu)
                { kiemtra = false; txtGhiChu.Text = sosanh.GhiChu; }
                else { kiemtra = true; count = count + 1; }
                if (gitri.Deleted != sosanh.Deleted)
                { kiemtra = false; }
                else { kiemtra = true; count = count + 1; }
                if (count < 8)
                {
                    kiemtra = false;
                }
                else
                { kiemtra = true; count = 0; }
            }
            catch (Exception ex)
            { string s = ex.Message; kiemtra = false; }
            return kiemtra;
        }
        #endregion
        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        private void frmXuLyKhoHang_Load(object sender, EventArgs e)
        {
            try
            {
                Entities.ChiTietKhoHangTheoMa[] ddh = new Entities.ChiTietKhoHangTheoMa[0];
                dgvHangHoa.DataSource = null;
                dgvHangHoa.DataSource = ddh;
                fixDatagridview();
                if (hanhDong == "Update")
                {
                    this.Text = "SỬA - KHO HÀNG";
                    tabPage_Khohang.Text = "Sửa kho hàng";
                    tssThem.Enabled = false;
                    tssSua.Enabled = true;
                    ID = khohang.KhoHangID;
                    id = khohang.KhoHangID.ToString();
                    txtMaKho.Text = khohang.MaKho;
                    txtTenKho.Text = khohang.TenKho;
                    txtDiaChi.Text = khohang.DiaChi;
                    txtSoDienThoai.Text = khohang.DienThoai;
                    txtGhiChu.Text = khohang.GhiChu;
                    cbxMaNhanVien.SelectedValue = khohang.MaNhanVien;
                    BindingHang(khohang.MaKho);
                }
                if (hanhDong == "Insert")
                {
                    tabPage_Hanghoa.Enabled = false;
                    tabPage_Khohang.Text = "Thêm mới kho hàng";
                    tssThem.Enabled = true;
                    tssSua.Enabled = false;
                    this.Text = "THÊM - KHO HÀNG";
                    getID("KhoHang");
                    txtMaKho.Text = makiemtra;
                }
                LayNhanVien();
            }
            catch (Exception ex)
            {
                if (txtMaKho.Text == "")
                {
                    txtMaKho.Text = makiemtra;
                }
                string s = ex.Message.ToString();
                Entities.ChiTietKhoHangTheoMa[] ddh = new Entities.ChiTietKhoHangTheoMa[0];
                dgvHangHoa.DataSource = null;
                dgvHangHoa.DataSource = ddh;
                fixDatagridview();
            }
            ActiveControl = txtTenKho;
        }


        //Phần Xử Lý
        #region Xử Lý --------------------------------------------------------------

        /// <summary>
        /// kiem tra khi them moi
        /// </summary>
        /// <returns></returns>
        private bool KiemTra()
        {
            bool check = false;
            try
            {
                if (txtMaKho.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập mã kho");
                    txtMaKho.Focus();
                    check = false;
                }
                else
                {
                    if (txtTenKho.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn cần phải nhập tên kho hàng");
                        txtTenKho.Focus();
                        check = false;
                    }
                    else
                    {
                        if (txtDiaChi.Text.Length == 0)
                        {
                            MessageBox.Show("Bạn cần phải nhập địa chỉ kho");
                            txtDiaChi.Focus();
                            check = false;
                        }
                        else
                        {
                            if (txtSoDienThoai.Text.Length == 0)
                            {
                                MessageBox.Show("Bạn cần phải nhập số điện thoại");
                                txtSoDienThoai.Focus();
                                check = false;
                            }
                            else
                            { check = true; }
                        }
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); check = false; }
            return check;
        }
        #endregion
        /// <summary>
        /// nut them moi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                getID("KhoHang");
                if (makiemtra == txtMaKho.Text)
                {
                    if (KiemTra() == true)
                    {
                        if (hanhDong == "Insert")
                        {
                            XuLyKhoHang("Insert");
                        }
                    }
                    else
                    { }
                }
                else
                { txtMaKho.Text = makiemtra; MessageBox.Show("Mã kho đã thay đổi"); }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        /// <summary>
        /// nut sua
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra() == true)
                {
                    if (checkconflictUpdate(khohang, ConfilickData("KhoHang", txtMaKho.Text.ToUpper())) == true)
                    {
                        if (hanhDong == "Update")
                        {
                            XuLyKhoHang("Update");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu đã thay đổi hãy kiểm tra lại trước khi sửa");
                    }
                }
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); MessageBox.Show("Thất bại"); }
        }

        private void tssDong_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    { frmQuanLyKhoHang.BaoDong = "A"; this.Close(); }
                    else
                    { }

                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tabControl_Cha_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!e.TabPage.Enabled)
            {
                e.Cancel = true;
            }
        }
    }
}
