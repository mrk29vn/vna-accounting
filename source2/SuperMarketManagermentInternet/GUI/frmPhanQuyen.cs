using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmPhanQuyen : Form
    {
        public frmPhanQuyen()
        {
            InitializeComponent();
        }
        public TcpClient client1;
        public NetworkStream clientstrem;
        //BizLogic.TaiKhoan tktk;
        Server_Client.Client cl;
        //Entities.TaiKhoan[] tk1;
        //Entities.TaiKhoan[] hienthi;

        private void dgvHienThiNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Form fr = new frmXuLyNhomQuyen();
            fr.ShowDialog();
            Tree();
            if (tkt != null)
                cbbTenNhomQuyen.Text = tkt.TenNhomQuyen;
            Entities.ChiTietQuyen[] ctqt = LayChiTietQuyen(NQ);
            if (ctqt != null)
            {
                dataGridView1.DataSource = ctqt;
                fixdgv();
            }
            else
            {
                dataGridView1.DataSource = new Entities.ChiTietQuyen[0];
                fixdgv();
            }
            dataGridView1.Refresh();
        }
        public void fixdgv()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns["TenNhomQuyen"].ReadOnly = true;
            dataGridView1.Columns["Ten"].ReadOnly = true;
            dataGridView1.Columns["TenNhomQuyen"].HeaderText = "Tên Nhóm Quyền";
            dataGridView1.Columns["Ten"].HeaderText = "Tên";
            dataGridView1.Columns["QuyenXem"].HeaderText = "Quyền Xem";
            dataGridView1.Columns["QuyenSua"].HeaderText = "Quyền Sửa";
            dataGridView1.Columns["QuyenThem"].HeaderText = "Quyền Thêm";
            dataGridView1.Columns["QuyenXoa"].HeaderText = "Quyền Xóa";
            dataGridView1.Columns["SaoLuuDuLieu"].Visible = false;
            dataGridView1.Columns["CapNhatDuLieu"].Visible = false;
            dataGridView1.Columns["TenForm"].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Entities.ChiTietQuyen[] ctq = (Entities.ChiTietQuyen[])dataGridView1.DataSource;
            object[] arr = new object[2] { ctq, Common.Utilities.User };
            bool kt = SuaChiTietQuyen(arr);
            if (!kt)
                MessageBox.Show("Xét Quyền Thất Bại");
            Entities.ChiTietQuyen[] ctqt = LayChiTietQuyen(NQ);
            if (ctqt != null)
            {
                dataGridView1.DataSource = ctqt;
                fixdgv();
            }
            else
            {
                dataGridView1.DataSource = new Entities.ChiTietQuyen[0];
                fixdgv();
            }
            dataGridView1.Refresh();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn Muốn Xóa không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    TreeNode temp = tvNhomQuyen.SelectedNode;
                    if (temp != null)
                    {
                        if (temp.Parent != null)
                        {
                            bool kt = true;
                            foreach (Entities.NhomQuyen item in NhomQuyen)
                            {
                                if (temp.Parent.Name.Equals(item.TenNhomQuyen))
                                {
                                    kt = item.isDeleted;
                                    break;
                                }
                            }
                            if (kt)
                            {
                                Entities.NhomQuyen nq1 = new Entities.NhomQuyen(temp.Parent.Name);
                                nq1.MaNhanVien = Common.Utilities.User.NhanVienID;
                                nq1.TenDangNhap = Common.Utilities.User.TenDangNhap;
                                if (!XoaNhomQuyen(nq1))
                                    MessageBox.Show("Xóa Thất Bại");
                            }
                            else
                                MessageBox.Show("Không Được Phép Xóa");
                        }
                        else
                        {
                            bool kt = true;
                            foreach (Entities.NhomQuyen item in NhomQuyen)
                            {
                                if (temp.Name.Equals(item.TenNhomQuyen))
                                {
                                    kt = item.isDeleted;
                                    break;
                                }
                            }
                            if (kt)
                            {
                                Entities.NhomQuyen nq1 = new Entities.NhomQuyen(temp.Name);
                                nq1.MaNhanVien = Common.Utilities.User.NhanVienID;
                                nq1.TenDangNhap = Common.Utilities.User.TenDangNhap;
                                if (!XoaNhomQuyen(nq1))
                                    MessageBox.Show("Xóa Thất Bại");
                            }
                            else
                                MessageBox.Show("Không Được Phép Xóa");
                        }
                        NQ = "Admin";
                        Tree();
                        Entities.ChiTietQuyen[] ctqt = LayChiTietQuyen(NQ);
                        if (ctqt != null)
                        {
                            dataGridView1.DataSource = ctqt;
                            fixdgv();
                        }
                        else
                        {
                            dataGridView1.DataSource = new Entities.ChiTietQuyen[0];
                            fixdgv();
                        }
                        dataGridView1.Refresh();
                    }
                    else
                        MessageBox.Show("Chưa Chọn Nhóm Quyền");
                }
            }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {

                }
            }
        }

        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            Tree();
            Entities.ChiTietQuyen[] ctqt = LayChiTietQuyen(NQ);
            if (ctqt != null)
            {
                dataGridView1.DataSource = ctqt;
                fixdgv();
            }
            else
            {
                dataGridView1.DataSource = new Entities.ChiTietQuyen[0];
                fixdgv();
            }
            dataGridView1.Refresh();

        }
        string NQ = "Admin";
        /// <summary>
        /// load node cho treeview
        /// </summary>
        /// 
        private Entities.TaiKhoan[] TK;
        Entities.NhomQuyen[] NhomQuyen;
        private Entities.TaiKhoan tkt;
        public void Tree()
        {
            try
            {
                TK = LayTaiKhoan();
                NhomQuyen = LayNhomQuyen();
                tvNhomQuyen.Nodes.Clear();

                foreach (Entities.NhomQuyen item in NhomQuyen)
                {
                    TreeNode root = new TreeNode();
                    root.Name = item.TenNhomQuyen;
                    root.Text = item.TenNhomQuyen;
                    foreach (Entities.TaiKhoan item1 in TK)
                    {
                        if (root.Name.ToString().Equals(item1.TenNhomQuyen))
                        {
                            TreeNode node = new TreeNode();
                            node.Text = item1.TenDangNhap;
                            node.Name = item1.TenDangNhap;
                            root.Nodes.Add(node);
                        }
                    }
                    tvNhomQuyen.Nodes.Add(root);
                }
                tvNhomQuyen.ExpandAll();
                cbbTenNhomQuyen.Items.Clear();
                foreach (Entities.NhomQuyen nq1 in NhomQuyen)
                {
                    cbbTenNhomQuyen.Items.Add(nq1.TenNhomQuyen);
                }
            }
            catch { MessageBox.Show("kết nối với server xuất hiện lỗi"); }
        }
        public Entities.TaiKhoan[] LayTaiKhoan()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                //Entities.TaiKhoan tk = new Entities.TaiKhoan();
                //tk = new Entities.TaiKhoan();
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.TaiKhoan[] tk1;
                clientstrem = cl.SerializeObj(this.client1, "LayTaiKhoan", null);
                // đổ mảng đối tượng vào datagripview       
                tk1 = (Entities.TaiKhoan[])cl.DeserializeHepper1(clientstrem, null);
                return tk1;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public Entities.NhomQuyen[] LayNhomQuyen()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo nếu muốn truyền giá trị
                //Entities.NhomQuyen nq = new Entities.NhomQuyen();
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.NhomQuyen[] nq1;
                clientstrem = cl.SerializeObj(this.client1, "LayNhomQuyen", null);
                // đổ mảng đối tượng vào datagripview       
                nq1 = (Entities.NhomQuyen[])cl.DeserializeHepper1(clientstrem, null);
                return nq1;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public Entities.ChiTietQuyen[] LayChiTietQuyen(string manhomquyen)
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo nếu muốn truyền giá trị
                Entities.ChiTietQuyen nq = new Entities.ChiTietQuyen(manhomquyen);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.ChiTietQuyen[] nq1;
                clientstrem = cl.SerializeObj(this.client1, "LayChiTietQuyen", nq);
                // đổ mảng đối tượng vào datagripview       
                nq1 = (Entities.ChiTietQuyen[])cl.DeserializeHepper1(clientstrem, null);
                return nq1;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public bool SuaChiTietQuyen(object[] ctq)
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo nếu muốn truyền giá trị

                // khởi tạo mảng đối tượng để hứng giá trị
                bool nq1;
                clientstrem = cl.SerializeObj(this.client1, "SuaChiTietQuyen", ctq);
                // đổ mảng đối tượng vào datagripview       
                nq1 = (bool)cl.DeserializeHepper(clientstrem, null);
                return nq1;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private void tvNhomQuyen_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                NQ = e.Node.Name;
                Entities.ChiTietQuyen[] ctqt = LayChiTietQuyen(NQ);
                if (ctqt != null)
                {
                    dataGridView1.DataSource = ctqt;
                    fixdgv();
                }
                else
                {
                    dataGridView1.DataSource = new Entities.ChiTietQuyen[0];
                    fixdgv();
                }
                dataGridView1.Refresh();
            }
            else
            {
                NQ = e.Node.Parent.Name;
                dataGridView1.DataSource = LayChiTietQuyen(NQ);
                dataGridView1.Refresh();
                Entities.ChiTietQuyen[] ctqt = LayChiTietQuyen(NQ);
                if (ctqt != null)
                {
                    dataGridView1.DataSource = ctqt;
                    fixdgv();
                }
                else
                {
                    dataGridView1.DataSource = new Entities.ChiTietQuyen[0];
                    fixdgv();
                }
                dataGridView1.Refresh();
                foreach (Entities.TaiKhoan tk1 in TK)
                {
                    if (e.Node.Name.Equals(tk1.TenDangNhap))
                    {
                        txtTenTaiKhoan.Text = tk1.TenDangNhap;
                        txtMatKhau.Text = string.Empty;
                        txtNewPass.Text = string.Empty;
                        txtMaNhanVien.Text = tk1.NhanVienID;
                        cbKhoa.Checked = tk1.KhoaTaiKhoan;
                        cbbTenNhomQuyen.Text = tk1.TenNhomQuyen;
                        //cbAdministrator.Checked = tk1.Administrator;
                        tkt = new Entities.TaiKhoan(tk1.TenDangNhap, tk1.MatKhauDangNhap, tk1.KhoaTaiKhoan, tk1.NhanVienID, tk1.Administrator, tk1.TenNhomQuyen);
                        break;
                    }
                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.ReadOnly = false;
            txtMatKhau.ReadOnly = false;
            txtTenTaiKhoan.ReadOnly = false;
            cbKhoa.Enabled = true;
            cbbTenNhomQuyen.Enabled = true;
            btnCancel.Visible = true;

            btnThemTaiKhoan.Enabled = false;
            btnSuaTaiKhoan.Visible = false;
            btnXoaTaiKhoan.Visible = false;
            btnDongY.Visible = true;

            txtMaNhanVien.Text = "";
            txtMatKhau.Text = "";
            txtTenTaiKhoan.Text = "";
            cbKhoa.Checked = false;
            //cbAdministrator.Checked = false;
            cbbTenNhomQuyen.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy Chọn 1 tài Khoản");
                return;
            }

            txtMaNhanVien.ReadOnly = false;
            txtMatKhau.ReadOnly = false;
            txtMatKhau.Text = string.Empty;
            txtNewPass.ReadOnly = false;
            txtTenTaiKhoan.ReadOnly = true;
            cbKhoa.Enabled = true;
            cbbTenNhomQuyen.Enabled = true;
            btnCancel.Visible = true;

            btnSuaTaiKhoan.Enabled = false;
            btnThemTaiKhoan.Visible = false;
            btnXoaTaiKhoan.Visible = false;
            btnDongY.Visible = true;
        }


        private void btnDongY_Click(object sender, EventArgs e)
        {
            #region validate

            if (txtTenTaiKhoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("chưa nhập tên tài khoản");
                txtTenTaiKhoan.Focus();
                return;
            }
            else
            {
                if (txtTenTaiKhoan.Text.Trim().Length > 200)
                {
                    MessageBox.Show("Tên tài khoản quá dài");
                    txtTenTaiKhoan.Focus();
                    return;
                }
            }
            if (txtMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("chưa nhập mật Khẩu");
                txtMatKhau.Focus();
                return;
            }
            else
            {
                if (txtMatKhau.Text.Trim().Length > 200)
                {
                    MessageBox.Show("Mật khẩu quá dài ");
                    txtTenTaiKhoan.Focus();
                    return;
                }
            }
            if (txtMaNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("chưa nhập mã nhân viên");
                txtMaNhanVien.Focus();
                return;
            }
            if (cbbTenNhomQuyen.SelectedIndex < 0)
            {
                MessageBox.Show("chưa nhập chọn nhóm quyền");
                cbbTenNhomQuyen.Focus();
                return;
            }
            #endregion

            bool isAdmin = false;

            if (cbbTenNhomQuyen.Text.Equals("Admin"))
                isAdmin = true;

            Entities.TaiKhoan tk = new Entities.TaiKhoan(txtTenTaiKhoan.Text, txtMatKhau.Text, cbKhoa.Checked, txtMaNhanVien.Text, isAdmin, cbbTenNhomQuyen.Text);
            tk.MaNV = Common.Utilities.User.NhanVienID;
            tk.TenDN = Common.Utilities.User.TenDangNhap;
            TK = LayTaiKhoan();
            if (btnThemTaiKhoan.Visible)
            {
                bool kt = true;

                foreach (Entities.TaiKhoan item in TK)
                {
                    if (item.TenDangNhap.ToLower().Equals(tk.TenDangNhap.ToLower()))
                    {
                        MessageBox.Show("Tài Khoản Đã Tồn Tại");
                        kt = false;
                        break;
                    }
                }
                if (kt)
                {

                    if (!ThemTaiKhoan(tk))
                    {
                        MessageBox.Show("Thất Bại");
                    }
                    else
                    {
                        tkt = tk;
                    }
                }
            }
            else if (btnSuaTaiKhoan.Visible)
            {
                // Validate
                if (string.IsNullOrEmpty(txtNewPass.Text))
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu mới, Xin kiểm tra lại", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                    txtNewPass.Focus();
                    return;
                }

                int kt = 2;
                foreach (Entities.TaiKhoan item in TK)
                {
                    if (item.TenDangNhap.Equals(txtTenTaiKhoan.Text))
                    {
                        bool a = txtMatKhau.Text.Equals(item.MatKhauDangNhap);

                        if (a)
                        {
                            kt = 1;
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu không đúng, Xin kiểm tra lại", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                            tkt = item;
                            kt = 3;
                            return;
                        }
                        break;
                    }
                }
                if (kt == 1)
                {
                    tk.MatKhauDangNhap = txtNewPass.Text;

                    if (!SuaTaiKhoan(tk))
                    {
                        MessageBox.Show("Thất Bại");
                    }
                }
                else if (kt == 2)
                {
                    MessageBox.Show("Tài Khoản Không tồn tại hoặc đã bị xóa");
                }
                else if (kt == 3)
                {
                    MessageBox.Show("Tài Khoản đã bị thay đổi trước rồi");
                    System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn có muốn update lại luôn không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                    {
                        if (giatri == System.Windows.Forms.DialogResult.Yes)
                        {
                            tk = tkt;
                            txtTenTaiKhoan.Text = tk.TenDangNhap;
                            txtMatKhau.Text = tk.MatKhauDangNhap;
                            txtMaNhanVien.Text = tk.NhanVienID;
                            cbKhoa.Checked = tk.KhoaTaiKhoan;
                            cbbTenNhomQuyen.Text = tk.TenNhomQuyen;
                            //cbAdministrator.Checked = tk.Administrator;
                        }


                    }
                }
            }

            txtMaNhanVien.ReadOnly = true;
            txtMatKhau.ReadOnly = true;
            txtNewPass.ReadOnly = true;
            txtNewPass.Text = string.Empty;
            txtTenTaiKhoan.ReadOnly = true;
            cbKhoa.Enabled = false;
            cbbTenNhomQuyen.Enabled = false;

            btnCancel.Visible = false;
            btnThemTaiKhoan.Visible = true;
            btnSuaTaiKhoan.Visible = true;
            btnXoaTaiKhoan.Visible = true;
            btnThemTaiKhoan.Enabled = true;
            btnSuaTaiKhoan.Enabled = true;
            btnDongY.Visible = false;

            Tree();
            cbbTenNhomQuyen.Text = tk.TenNhomQuyen;
            Entities.ChiTietQuyen[] ctqt = LayChiTietQuyen(NQ);
            if (ctqt != null)
            {
                dataGridView1.DataSource = ctqt;
                fixdgv();
            }
            else
            {
                dataGridView1.DataSource = new Entities.ChiTietQuyen[0];
                fixdgv();
            }
            dataGridView1.Refresh();
        }
        public bool SuaTaiKhoan(Entities.TaiKhoan tk)
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo nếu muốn truyền giá trị

                // khởi tạo mảng đối tượng để hứng giá trị
                bool nq1;
                clientstrem = cl.SerializeObj(this.client1, "SuaTaiKhoan", tk);
                // đổ mảng đối tượng vào datagripview       
                nq1 = (bool)cl.DeserializeHepper(clientstrem, null);
                return nq1;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool ThemTaiKhoan(Entities.TaiKhoan tk)
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo nếu muốn truyền giá trị

                // khởi tạo mảng đối tượng để hứng giá trị
                bool nq1;
                clientstrem = cl.SerializeObj(this.client1, "ThemTaiKhoan", tk);
                // đổ mảng đối tượng vào datagripview       
                nq1 = (bool)cl.DeserializeHepper(clientstrem, null);
                return nq1;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool XoaTaiKhoan(Entities.TaiKhoan tk)
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo nếu muốn truyền giá trị

                // khởi tạo mảng đối tượng để hứng giá trị
                bool nq1;
                clientstrem = cl.SerializeObj(this.client1, "XoaTaiKhoan", tk);
                // đổ mảng đối tượng vào datagripview       
                nq1 = (bool)cl.DeserializeHepper(clientstrem, null);
                return nq1;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool XoaNhomQuyen(Entities.NhomQuyen nq)
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo nếu muốn truyền giá trị

                // khởi tạo mảng đối tượng để hứng giá trị
                bool nq1;
                clientstrem = cl.SerializeObj(this.client1, "XoaNhomQuyen", nq);
                // đổ mảng đối tượng vào datagripview       
                nq1 = (bool)cl.DeserializeHepper(clientstrem, null);
                return nq1;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            if (txtTenTaiKhoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Hãy Chọn 1 tài Khoản");
                return;
            }
            foreach (Entities.TaiKhoan item in TK)
            {
                if (item.TenDangNhap.Equals(txtTenTaiKhoan.Text) && item.Administrator)
                {
                    MessageBox.Show("không được xóa tài khoản Super Admin");
                    return;
                }
            }
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn muốn xóa không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    Entities.TaiKhoan tk = new Entities.TaiKhoan(txtTenTaiKhoan.Text);
                    tk.MaNV = Common.Utilities.User.NhanVienID;
                    tk.TenDN = Common.Utilities.User.TenDangNhap;
                    if (XoaTaiKhoan(tk))
                    {
                        //MessageBox.Show("Thành Công");
                        Tree();
                        Entities.ChiTietQuyen[] ctqt = LayChiTietQuyen(NQ);
                        if (ctqt != null)
                        {
                            dataGridView1.DataSource = ctqt;
                            fixdgv();
                        }
                        else
                        {
                            dataGridView1.DataSource = new Entities.ChiTietQuyen[0];
                            fixdgv();
                        }
                        tkt = null;
                        dataGridView1.Refresh();
                        txtMaNhanVien.Text = "";
                        txtMatKhau.Text = "";
                        txtTenTaiKhoan.Text = "";
                        cbKhoa.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Thất Bại");
                    }
                }


            }

        }

        private void txtMaNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtMaNhanVien.ReadOnly)
                {
                    frmTimNhanVien frm = new frmTimNhanVien();
                    frm.ShowDialog();
                    if (frmTimNhanVien.drvr != null)
                    {
                        txtMaNhanVien.Text = frmTimNhanVien.drvr.Cells["MaNhanVien"].Value.ToString();
                        frmTimNhanVien.drvr = null;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi Xuất hiện");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnThemTaiKhoan.Visible)
            {
                txtMaNhanVien.Text = "";
                txtMatKhau.Text = "";
                txtTenTaiKhoan.Text = "";
                cbKhoa.Checked = false;
            }
            txtMaNhanVien.ReadOnly = true;
            txtMatKhau.ReadOnly = true;
            txtTenTaiKhoan.ReadOnly = true;
            cbKhoa.Enabled = false;
            cbbTenNhomQuyen.Enabled = false;

            btnCancel.Visible = false;
            btnThemTaiKhoan.Visible = true;
            btnSuaTaiKhoan.Visible = true;
            btnXoaTaiKhoan.Visible = true;
            btnThemTaiKhoan.Enabled = true;
            btnSuaTaiKhoan.Enabled = true;
            btnDongY.Visible = false;
        }

        private void frmPhanQuyen_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void txtTenTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i = e.KeyChar;
            if ((i < 65 || i > 90) && (i < 97 || i > 122) && i != 8)
            {
                e.Handled = true;
            }
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int i = e.KeyChar;
            //if ((i < 65 || i > 90) && (i < 97 || i > 122) && i != 8)
            //{
            //    e.Handled = true;
            //}
        }

        private void txtMaNhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
