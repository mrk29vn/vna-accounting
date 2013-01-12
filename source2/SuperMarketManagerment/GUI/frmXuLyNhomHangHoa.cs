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
    public partial class frmXuLyNhomHangHoa : Form
    {
        //Phần Khai Báo
        #region Khai Báo
        // nhan biet la  formMode la Insert, hay Update.
        bool isInsert = true;
        public TcpClient tcpClient;
        public NetworkStream networkStream;
        string manhomhang, loaihanghoa, tennhomhang, ghichu;
        public static string trave = "";
        string str;
        public frmXuLyNhomHangHoa(string hanhDong, DataGridViewRow dgvr)
        {
            InitializeComponent();
            str = hanhDong;
            XuLyCombobox();
            if (hanhDong == "Update")
            {
                isInsert = false;
                this.Text = "Quản Lý Nhóm Hàng Hóa - Sửa Nhóm Hàng Hóa";
                tssThem.Enabled = false;
                id = dgvr.Cells["NhomHangID"].Value.ToString();
                manhomhang = txtMaNhomHang.Text = dgvr.Cells["MaNhomHang"].Value.ToString();
                loaihanghoa = dgvr.Cells["MaLoaiHang"].Value.ToString();
                cmbLoaihang.Text = LayTenLoaiHang(dgvr.Cells["MaLoaiHang"].Value.ToString()); ;
                tennhomhang = txtTenNhomHang.Text = dgvr.Cells["TenNhomHang"].Value.ToString();
                ghichu = txtGhiChu.Text = dgvr.Cells["GhiChu"].Value.ToString();
            }
        }

        public frmXuLyNhomHangHoa(string hanhDong)
        {
            InitializeComponent();
            str = hanhDong;
            XuLyCombobox();
            if (hanhDong == "Insert")
            {
                isInsert = true;
                tssSua.Enabled = false;
                this.Text = "Quản Lý Nhóm Hàng Hóa - Thêm Nhóm Hàng Hóa";
                txtMaNhomHang.Text = ProID("NhomHang");
                tabControl1.TabPages["tabPage2"].Enabled = false;

            }

        }

        public frmXuLyNhomHangHoa()
        {
            InitializeComponent();
        }

        private void frmXuLyNhomHangHoa_Load(object sender, EventArgs e)
        {
            if (!this.isInsert)
            {
                SelectData();
                fix1();
            }
        }

        string id;
        public frmXuLyNhomHangHoa(DataGridViewRow dgvr)
        {
            InitializeComponent();
            id = dgvr.Cells["NhomHangID"].Value.ToString();
            txtMaNhomHang.Text = dgvr.Cells["MaNhomHang"].Value.ToString();
            cmbLoaihang.Text = dgvr.Cells["MaLoaiHang"].Value.ToString();
            txtTenNhomHang.Text = dgvr.Cells["TenNhomHang"].Value.ToString();
            txtGhiChu.Text = dgvr.Cells["GhiChu"].Value.ToString();
        }

        #endregion

        //Phần Xử Lý
        #region Xử Lý

        //Kiểm Tra
        private bool KiemTra()
        {
            if (txtTenNhomHang.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập Tên nhóm hàng ", "Hệ thống cảnh báo");
                txtTenNhomHang.Focus();
                return false;
            }
            if (cmbLoaihang.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập Loại hàng", "Hệ thống cảnh báo");
                cmbLoaihang.Focus();
                return false;
            }
            return true;
        }
        public TcpClient client1;
        public NetworkStream clientstrem;
        /// <summary>
        /// Lấy giá trị id cuối cùng
        /// </summary>
        /// <param name="tenBang"></param>
        /// <returns></returns>
        public string ProID(string tenBang)
        {
            try
            {
                string idnew;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.LayID lid = new Entities.LayID();
                clientstrem = cl.SerializeObj(this.client1, "LayID", lid1);
                // đổ mảng đối tượng vào datagripview       
                lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, nh);
                Common.Utilities a = new Common.Utilities();
                if (lid == null)
                {
                    return "NH_0001";
                }
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            catch
            {
                return "";
            }
        }
        Entities.NhomHang nh;
        //Thêm
        private void tssThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra() == true)
                {
                    CheckConflictInsert();
                    if (kt1 == true)
                    {
                        Server_Client.Client client = new Server_Client.Client();
                        this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
                        string tenLoaiHang = LayMaLoaiHang(cmbLoaihang.Text);
                        nh = new Entities.NhomHang("Insert", 0, txtMaNhomHang.Text, tenLoaiHang, txtTenNhomHang.Text, txtGhiChu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                        networkStream = client.SerializeObj(this.tcpClient, "NhomHang", nh);
                        bool kt = false;
                        kt = (bool)client.DeserializeHepper(networkStream, kt);
                        if (kt == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("thất bại - xin kiểm tra lại dữ liệu", "Hệ thống cảnh báo");
                        }
                    }

                }
            }
            catch
            {
            }
        }

        //Sửa
        private void tssSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra() == true)
                {
                    CheckConflictUpdate();
                    if (kt1 == true)
                    {
                        Server_Client.Client client = new Server_Client.Client();
                        this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
                        nh = new Entities.NhomHang();
                        string tenLoaiHang = LayMaLoaiHang(cmbLoaihang.Text);
                        nh = new Entities.NhomHang("Update", int.Parse(id), txtMaNhomHang.Text, tenLoaiHang, txtTenNhomHang.Text, txtGhiChu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                        networkStream = client.SerializeObj(this.tcpClient, "NhomHang", nh);
                        bool kt = false;
                        kt = (bool)client.DeserializeHepper(networkStream, kt);
                        if (kt == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("thất bại - xin kiểm tra lại dữ liệu", "Hệ thống cảnh báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu đã bị thay đổi - kiểm tra lại", "Hệ thống cảnh báo");
                    }
                }
            }
            catch
            {
            }
        }

        private void tssDong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    trave = "ok";
                    this.Close();
                }
                else
                { }
            }
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
        //Check Conflict
        #region Check Conflict

        public string kt = "1";

        //Check Thêm
        public void CheckConflictInsert()
        {
            try
            {
                kt1 = true;
                Server_Client.Client client = new Server_Client.Client();
                this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
                Entities.NhomHang nh = new Entities.NhomHang("Select");
                Entities.NhomHang[] nh1 = new Entities.NhomHang[1];
                networkStream = client.SerializeObj(this.tcpClient, "NhomHang", nh);
                nh1 = (Entities.NhomHang[])client.DeserializeHepper1(networkStream, nh1);

                if (nh1 != null)
                {
                    for (int j = 0; j < nh1.Length; j++)
                    {
                        if (nh1[j].MaLoaiHang == cmbLoaihang.Text)
                        {
                            MessageBox.Show("Cập nhật mã hàng hóa", "Hệ thống cảnh báo");
                            kt1 = false;
                            manhomhang = txtMaNhomHang.Text = ProID("NhomHang");
                            break;
                        }
                        else
                            kt1 = true;
                    }
                }
            }
            catch (Exception ex)
            {
                kt1 = false;
            }
        }
        bool kt1 = false;
        //Check Sửa
        public void CheckConflictUpdate()
        {
            try
            {
                kt1 = true;
                cl = new Server_Client.Client();
                this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
                Entities.NhomHang nh = new Entities.NhomHang("Select");
                Entities.NhomHang[] pt1 = new Entities.NhomHang[1];
                networkStream = client.SerializeObj(this.tcpClient, "NhomHang", nh);
                pt1 = (Entities.NhomHang[])client.DeserializeHepper1(networkStream, nh1);
                if (pt1 != null)
                {
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        if (pt1[j].MaNhomHang == manhomhang)
                        {
                            kt1 = Check(pt1[j]);
                            break;
                        }
                        else
                            kt1 = true;
                    }
                }
            }
            catch (Exception ex)
            {

                kt1 = false;
            }
            finally
            {


            }
        }
        string a = "";
        public bool Check(Entities.NhomHang nh)
        {
            bool gt = true;

            if (loaihanghoa != nh.MaLoaiHang)
            {
                loaihanghoa = nh.MaLoaiHang;
                cmbLoaihang.Text = LayTenLoaiHang(loaihanghoa);
                gt = false;
            }
            if (tennhomhang != nh.TenNhomHang)
            {
                tennhomhang = txtTenNhomHang.Text = nh.TenNhomHang;
                gt = false;
            }
            if (ghichu != nh.GhiChu)
            {
                ghichu = txtGhiChu.Text = nh.GhiChu;
                gt = false;
            }
            return gt;
        }


        #endregion

        //Xử Lý Mã Loại Hàng
        #region Mã  Loại Hàng
        Server_Client.Client client;
        Entities.LoaiHangHoa[] nh1;
        public void LayTenLoaiHang()
        {
            try
            {
                cmbLoaihang.Items.Clear();
                client = new Server_Client.Client();
                this.tcpClient = client.Connect(Luu.IP, Luu.Ports);

                Entities.LoaiHangHoa nh = new Entities.LoaiHangHoa();
                nh = new Entities.LoaiHangHoa("Select");
                networkStream = client.SerializeObj(this.tcpClient, "LoaiHangHoa", nh);
                nh1 = new Entities.LoaiHangHoa[1];
                nh1 = (Entities.LoaiHangHoa[])client.DeserializeHepper1(networkStream, nh1);

                if (nh1.Length > 0)
                {
                    int sl = nh1.Length;
                    for (int i = 0; i < sl; i++)
                    {
                        if (nh1[i].Deleted == false)
                            cmbLoaihang.Items.Add(nh1[i].TenLoaiHang);
                    }
                }
            }
            catch
            {
            }
        }

        public string LayMaLoaiHang(string tenLoaiHang)
        {
            for (int j = 0; j < nh1.Length; j++)
            {
                if (nh1[j].TenLoaiHang == tenLoaiHang)
                {
                    return nh1[j].MaLoaiHang;
                }
            }
            return "";
        }

        public string LayTenLoaiHang(string maLoaiHang)
        {
            for (int j = 0; j < nh1.Length; j++)
            {
                if (nh1[j].MaLoaiHang == maLoaiHang)
                {
                    return nh1[j].TenLoaiHang;
                }
            }
            return "";
        }

        //Lấy Combobox
        public void XuLyCombobox()
        {
            try
            {
                LayTenLoaiHang();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        #endregion

        //Hiển thị hàng hóa trong Nhóm Hàng Hóa
        #region Hiển thị hàng hóa trong Nhóm Hàng Hóa

        Server_Client.Client cl;
        public void SelectData()
        {
            try
            {
                dgvHangHoa.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                Entities.HangHoa hh = new Entities.HangHoa("Select");
                networkStream = cl.SerializeObj(this.tcpClient, "HangHoa", hh);
                Entities.HangHoa[] hh1 = new Entities.HangHoa[1];
                hh1 = (Entities.HangHoa[])cl.DeserializeHepper1(networkStream, hh1);

                // goi hang 
                cl = new Server_Client.Client();
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("GH");
                networkStream = cl.SerializeObj(this.tcpClient, "Select", ctxh);
                Entities.GoiHang[] goihang = new Entities.GoiHang[0];
                goihang = (Entities.GoiHang[])cl.DeserializeHepper1(networkStream, goihang);



                if (hh1 == null && goihang == null)
                {
                    dgvHangHoa.DataSource = new Entities.HangHoa[0];
                    return;
                }

                List<Entities.HangHoa> listHangHoa = new List<Entities.HangHoa>();

                // for hang hoa
                foreach (Entities.HangHoa hanghoa in hh1)
                {
                    if (hanghoa != null && hanghoa.Deleted == false && hanghoa.MaNhomHangHoa.Equals(manhomhang))
                    {
                        listHangHoa.Add(hanghoa);
                    }
                }

                // for goi hang
                foreach (Entities.GoiHang gh in goihang)
                {
                    if (gh != null && gh.Deleted == false && gh.MaNhomHang.Equals(manhomhang))
                    {
                        Entities.HangHoa hanghoa = new Entities.HangHoa();
                        hanghoa.MaHangHoa = gh.MaGoiHang;
                        hanghoa.TenHangHoa = gh.TenGoiHang;
                        hanghoa.MaNhomHangHoa = gh.MaNhomHang;
                        hanghoa.GiaNhap = gh.GiaNhap;
                        hanghoa.GiaBanBuon = gh.GiaBanBuon;
                        hanghoa.GiaBanLe = gh.GiaBanLe;
                        listHangHoa.Add(hanghoa);

                    }
                }
                dgvHangHoa.DataSource = (Entities.HangHoa[])listHangHoa.ToArray();
                dgvHangHoa.Rows[0].Selected = true;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                fix1();
            }
        }
        public void fix1()
        {
            dgvHangHoa.Columns[0].Visible = false;
            dgvHangHoa.Columns[0].HeaderText = "STT";
            dgvHangHoa.Columns["HanhDong"].Visible = false;
            dgvHangHoa.Columns["MaNhomHangHoa"].Visible = false;
            dgvHangHoa.Columns["MaDonViTinh"].Visible = false;
            dgvHangHoa.Columns["MaThueGiaTriGiaTang"].Visible = false;
            dgvHangHoa.Columns["Cot"].Visible = false;
            dgvHangHoa.Columns["Kieu"].Visible = false;
            dgvHangHoa.Columns["GiaTri"].Visible = false;
            dgvHangHoa.Columns["Deleted"].Visible = false;
            dgvHangHoa.Columns["HanghoaID"].Visible = false;
            dgvHangHoa.AllowUserToResizeRows = false;
            dgvHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHangHoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHangHoa.ReadOnly = true;
            dgvHangHoa.Columns[0].Visible = true;
            dgvHangHoa.Columns["MaHangHoa"].Visible = false;
            dgvHangHoa.Columns["TenNhomHangHoa"].Visible = false;
            dgvHangHoa.Columns["TenHangHoa"].HeaderText = "Tên Hàng Hóa";
            dgvHangHoa.Columns["TenDonViTinh"].HeaderText = "Tên Đơn Vị Tính";
            dgvHangHoa.Columns["GiaNhap"].HeaderText = "Giá Nhập";
            dgvHangHoa.Columns["GiaBanBuon"].HeaderText = "Giá Bán Buôn";
            dgvHangHoa.Columns["GiaBanLe"].HeaderText = "Giá Bán Lẻ";
            dgvHangHoa.Columns["TenThueGiaTriGiaTang"].Visible = false;
            dgvHangHoa.Columns["KieuHangHoa"].Visible = false;
            dgvHangHoa.Columns["SeriLo"].Visible = false;
            dgvHangHoa.Columns["MucDatHang"].Visible = false;
            dgvHangHoa.Columns["MucTonToiThieu"].Visible = false;
            dgvHangHoa.Columns["GhiChu"].Visible = false;
            new Common.Utilities().CountDatagridview(dgvHangHoa);

        }

        //Hiển thị Form Sửa Hàng Hóa khi Click 
        private void dgvHangHoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                frmXuLyHangHoa snhh = new frmXuLyHangHoa("Update", dgvHangHoa.Rows[i]);
                snhh.ShowDialog();
                SelectData();
                fix1();
            }
            catch
            {
            }
        }

        #endregion
        int i = 0;

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!e.TabPage.Enabled)
            {
                e.Cancel = true;
            }
        }

        private void frmXuLyNhomHangHoa_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void txtGhiChu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (str == "Insert")
                {
                    try
                    {
                        if (KiemTra() == true)
                        {
                            CheckConflictInsert();
                            if (kt1 == true)
                            {
                                Server_Client.Client client = new Server_Client.Client();
                                this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
                                string tenLoaiHang = LayMaLoaiHang(cmbLoaihang.Text);
                                nh = new Entities.NhomHang("Insert", 0, txtMaNhomHang.Text, tenLoaiHang, txtTenNhomHang.Text, txtGhiChu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                                networkStream = client.SerializeObj(this.tcpClient, "NhomHang", nh);
                                bool kt = false;
                                kt = (bool)client.DeserializeHepper(networkStream, kt);
                                if (kt == true)
                                {
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("thất bại - xin kiểm tra lại dữ liệu", "Hệ thống cảnh báo");
                                }
                            }

                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    try
                    {
                        if (KiemTra() == true)
                        {
                            CheckConflictUpdate();
                            if (kt1 == true)
                            {
                                Server_Client.Client client = new Server_Client.Client();
                                this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
                                nh = new Entities.NhomHang();
                                string tenLoaiHang = LayMaLoaiHang(cmbLoaihang.Text);
                                nh = new Entities.NhomHang("Update", int.Parse(id), txtMaNhomHang.Text, tenLoaiHang, txtTenNhomHang.Text, txtGhiChu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                                networkStream = client.SerializeObj(this.tcpClient, "NhomHang", nh);
                                bool kt = false;
                                kt = (bool)client.DeserializeHepper(networkStream, kt);
                                if (kt == true)
                                {
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("thất bại - xin kiểm tra lại dữ liệu", "Hệ thống cảnh báo");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Dữ liệu đã bị thay đổi - kiểm tra lại", "Hệ thống cảnh báo");
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void cmbLoaihang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                txtTenNhomHang.Focus();


            }
        }

        private void txtTenNhomHang_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtGhiChu.Focus();
            }
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }


    }
}
