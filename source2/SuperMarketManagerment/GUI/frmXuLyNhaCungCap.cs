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
    public partial class frmXuLyNhaCungCap : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        DateTime datesv;
        public frmXuLyNhaCungCap(DataGridViewRow dgvNCC)
        {
            InitializeComponent();
            datesv = DateServer.Date();
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
        Entities.HoaDonNhap[] pt1;
        //Entities.HDBanHang[] hienthi;
        public void SelectDatancc()
        {
            try
            {
                DateTime dateSerVer = DateServer.Date();
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.HoaDonNhap pt = new Entities.HoaDonNhap("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                pt1 = new Entities.HoaDonNhap[1];
                clientstrem = cl.SerializeObj(this.client1, "HDN", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.HoaDonNhap[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 == null)
                    pt1 = new Entities.HoaDonNhap[0];

                if (int.Parse(duno) != 0)
                {
                    List<Entities.HoaDonNhap> l = new List<Entities.HoaDonNhap>();
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        double noHienThoi = 0;
                        double thanhToanNgay = 0;
                        double tongTien = 0;
                        double thanhToanNgayKhiLapPhieu = 0;
                        DateTime hanThanhToan = pt1[j].HanThanhToan;
                        int YY = dateSerVer.Year;
                        int MM = dateSerVer.Month;
                        int DD = dateSerVer.Day;

                        if (!string.IsNullOrEmpty(pt1[j].ThanhToanNgay))
                            thanhToanNgay = double.Parse(pt1[j].ThanhToanNgay);

                        if (!string.IsNullOrEmpty(pt1[j].TongTien))
                            tongTien = double.Parse(pt1[j].TongTien);

                        if (!string.IsNullOrEmpty(pt1[j].ThanhToanSauKhiLapPhieu))
                            thanhToanNgayKhiLapPhieu = double.Parse(pt1[j].ThanhToanSauKhiLapPhieu);

                        noHienThoi = thanhToanNgay + thanhToanNgayKhiLapPhieu - tongTien;

                        if (pt1[j].MaNhaCungCap.Equals(mancc) && YY == hanThanhToan.Year && MM == hanThanhToan.Month && (hanThanhToan.Day - DD) <= 3 && (hanThanhToan.Day - DD) >= 0 && (noHienThoi != 0))
                        {
                            l.Add(pt1[j]);
                        }
                    }

                    Entities.HoaDonNhap hdn = HanThanhToanNhoNhat(l);
                    if (hdn != null && !string.IsNullOrEmpty(hdn.MaHoaDonNhap))
                        label1.Text = "Sắp tới hạn thanh toán với nhà cung cấp " + hdn.HanThanhToan.ToString("dd/MM/yyyy");
                }

            }
            catch { }
        }

        private Entities.HoaDonNhap HanThanhToanNhoNhat(List<Entities.HoaDonNhap> l)
        {
            Entities.HoaDonNhap kq = new Entities.HoaDonNhap();
            int temp = 31;
            foreach (Entities.HoaDonNhap item in l)
            {
                temp = item.HanThanhToan.Day;
                kq = item;
            }
            return kq;
        }

        public void XuLyString(string str1, string str2)
        {
            try
            {
                if (str1 == "Thu" && str2 == "Them")
                {
                    this.Text = " Quản lý Nhà Cung Cấp- Thêm mới Nhà Cung Cấp";
                    tsslblghilai.Enabled = false;
                    txtMaNCC.Text = ProID("NhaCungCap");
                    tPlichsugiaodich.Enabled = false;
                }
                if (str1 == "Thu" && str2 == "Sua")
                {
                    this.Text = " Quản lý Nhà Cung Cấp - Sửa Nhà Cung Cấp";
                    tsslblthemmoi.Enabled = false;
                }
            }
            catch { }

        }
        public frmXuLyNhaCungCap(string str1, string str2)
        {
            InitializeComponent();
            datesv = DateServer.Date();
            XuLyString(str1, str2);
        }
        string id;
        string mancc, tenncc, diachi, dienthoai, email, fax, nguoilienhe, mst, duno, website, ghichu;
        string kt;
        public frmXuLyNhaCungCap(string str1, string str2, DataGridViewRow dgvNCC)
        {
            try
            {
                InitializeComponent();
                datesv = DateServer.Date();
                XuLyString(str1, str2);
                id = dgvNCC.Cells["NhaCungCapID"].Value.ToString();
                mancc = txtMaNCC.Text = dgvNCC.Cells["MaNhaCungCap"].Value.ToString();
                tenncc = txtTenNCC.Text = dgvNCC.Cells["TenNhaCungCap"].Value.ToString();
                diachi = txtDiaChi.Text = dgvNCC.Cells["DiaChi"].Value.ToString();
                dienthoai = mktxtdienthoai.Text = dgvNCC.Cells["DienThoai"].Value.ToString();
                fax = txtFax.Text = dgvNCC.Cells["Fax"].Value.ToString();
                email = txtEmail.Text = dgvNCC.Cells["Email"].Value.ToString();
                website = txtWebsite.Text = dgvNCC.Cells["Website"].Value.ToString();
                mst = txtMasothue.Text = dgvNCC.Cells["MST"].Value.ToString();
                nguoilienhe = txtNguoilienhe.Text = dgvNCC.Cells["NguoiLienHe"].Value.ToString();
                ghichu = txtGhichu.Text = dgvNCC.Cells["GhiChu"].Value.ToString();
                duno = txtduno.Text = dgvNCC.Cells["DuNo"].Value.ToString();
                Entities.DonHangNCC[] lay = new Entities.DonHangNCC[0];
                dataGridView1.DataSource = lay;
                for (int j = 1; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Columns[j].Visible = false;
                }
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = true;
                dataGridView1.Columns[1].HeaderText = "Mã Đơn Đặt Hàng";
                dataGridView1.Columns[2].Visible = true;
                dataGridView1.Columns[2].HeaderText = "Mã Nhà Cung Cấp";
                dataGridView1.Columns[3].Visible = true;
                dataGridView1.Columns[3].HeaderText = "Ngày Đơn Hàng";
                dataGridView1.Columns[4].Visible = true;
                dataGridView1.Columns[4].HeaderText = "Trạng Thái Đơn Hàng";
                dataGridView1.Columns[5].Visible = true;
                dataGridView1.Columns[5].HeaderText = "Hình Thức Thanh Toán";
                dataGridView1.Columns[6].HeaderText = "Tổng Tiền";
                dataGridView1.Columns[6].Visible = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AllowUserToResizeRows = false;
            }
            catch { }
        }
        private void tsslbltrove_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.Close();
                        frmQuanLyNhaCungCap.trave = "A";
                    }
                    else
                    { }
                }
            }
            catch { }
        }
        private bool Kiemtra()
        {
            try
            {
                if (txtMaNCC.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + lblMaNCC.Text, "Hệ thống cảnh báo");
                    txtMaNCC.Focus();
                    return false;
                }
                if (txtTenNCC.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + lblTenNCC.Text, "Hệ thống cảnh báo");
                    txtTenNCC.Focus();
                    return false;
                }
                if (txtTenNCC.Text.Length >= 100)
                {
                    MessageBox.Show("Tên nhà cung cấp không thể quá 100 kí tự ", "Hệ thống cảnh báo");
                    txtTenNCC.Focus();
                    return false;
                }
                if (txtDiaChi.Text.Length >= 100)
                {
                    MessageBox.Show("Địa chỉ không thể quá 100 kí tự ", "Hệ thống cảnh báo");
                    txtDiaChi.Focus();
                    return false;
                }
                if (txtEmail.Text.Length >= 51)
                {
                    MessageBox.Show("Email không thể quá 50 kí tự ", "Hệ thống cảnh báo");
                    txtEmail.Focus();
                    return false;
                }
                if (txtWebsite.Text.Length >= 100)
                {
                    MessageBox.Show("Website không thể quá 100 kí tự ", "Hệ thống cảnh báo");
                    txtWebsite.Focus();
                    return false;
                }
                if (txtMasothue.Text.Length >= 21)
                {
                    MessageBox.Show("Mã số thuế không thể quá 20 kí tự ", "Hệ thống cảnh báo");
                    txtMasothue.Focus();
                    return false;
                }
                if (txtNguoilienhe.Text.Length >= 100)
                {
                    MessageBox.Show("Người liên hệ không thể quá 100 kí tự ", "Hệ thống cảnh báo");
                    txtNguoilienhe.Focus();
                    return false;
                }
                if (txtGhichu.Text.Length >= 100)
                {
                    MessageBox.Show("Ghi chú không thể quá 100 kí tự ", "Hệ thống cảnh báo");
                    txtGhichu.Focus();
                    return false;
                }
                return true;
            }
            finally { }
        }

        public void CheckConflictInsert()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.NhaCungCap ncc = new Entities.NhaCungCap("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.NhaCungCap[] ncc1 = new Entities.NhaCungCap[1];
                clientstrem = cl.SerializeObj(this.client1, "NhaCungCap", ncc);
                // đổ mảng đối tượng vào datagripview       
                ncc1 = (Entities.NhaCungCap[])cl.DeserializeHepper1(clientstrem, ncc1);
                if (ncc1 != null)
                {
                    for (int j = 0; j < ncc1.Length; j++)
                    {
                        if (ncc1[j].MaNhaCungCap == mancc)
                        {
                            MessageBox.Show("cập nhật mã nhà cung cấp - kiểm tra lại để insert");
                            kt = "ko";
                            mancc = txtMaNCC.Text = ProID("NhaCungCap");
                            break;
                        }
                        else
                            kt = "ok";
                    }

                }
                else
                    kt = "ok";

            }
            catch
            {
            }
        }
        Entities.NhaCungCap[] ncc1;
        Server_Client.Client cl;
        public void CheckConflictUpdate()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.NhaCungCap ncc = new Entities.NhaCungCap("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                ncc1 = new Entities.NhaCungCap[1];
                clientstrem = cl.SerializeObj(this.client1, "NhaCungCap", ncc);
                // đổ mảng đối tượng vào datagripview       
                ncc1 = (Entities.NhaCungCap[])cl.DeserializeHepper1(clientstrem, ncc1);
                if (ncc1 != null)
                {
                    for (int j = 0; j < ncc1.Length; j++)
                    {
                        if (ncc1[j].MaNhaCungCap == mancc)
                        {
                            kt = Check(ncc1[j]);
                            break;
                        }
                        else
                            kt = "ok";
                    }

                }

            }
            catch
            {
            }
        }


        public string Check(Entities.NhaCungCap ncc)
        {
            try
            {
                string gt = "ok";
                if (tenncc != ncc.TenNhaCungCap)
                {
                    tenncc = txtTenNCC.Text = ncc.TenNhaCungCap;
                    gt = "ko";
                }
                if (diachi != ncc.DiaChi)
                {
                    diachi = txtDiaChi.Text = ncc.DiaChi;
                    gt = "ko";
                }
                if (dienthoai != ncc.DienThoai)
                {
                    dienthoai = mktxtdienthoai.Text = ncc.DienThoai;
                    gt = "ko";
                }
                if (email != ncc.Email)
                {
                    email = txtEmail.Text = ncc.Email;
                    gt = "ko";
                }
                if (fax != ncc.Fax)
                {
                    fax = txtFax.Text = ncc.Fax;
                    gt = "ko";
                }
                if (nguoilienhe != ncc.NguoiLienHe)
                {
                    nguoilienhe = txtNguoilienhe.Text = ncc.NguoiLienHe;
                    gt = "ko";
                }
                if (mst != ncc.MST)
                {
                    mst = txtMasothue.Text = ncc.MST;
                    gt = "ko";
                }
                if (duno != ncc.DuNo.ToString())
                {
                    duno = txtduno.Text = String.Format("{0:0.0}", float.Parse(ncc.DuNo.ToString()));
                    gt = "ko";
                }
                if (website != ncc.Website)
                {
                    website = txtWebsite.Text = ncc.Website;
                    gt = "ko";
                }
                if (ghichu != ncc.GhiChu)
                {
                    ghichu = txtGhichu.Text = ncc.GhiChu;
                    gt = "ko";
                }
                return gt;
            }
            finally
            { }
        }
        string ktgiatri = "";
        private void tsslblthemmoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (Kiemtra())
                {
                    CheckConflictInsert();
                    if (kt == "ok")
                    {
                        if (txtDiaChi.Text == "" || mktxtdienthoai.Text == "" || txtEmail.Text == "" || txtFax.Text == "" || txtNguoilienhe.Text == "" || txtMasothue.Text == "" || txtduno.Text == "" || txtWebsite.Text == "" || txtGhichu.Text == "")
                        {

                        }
                        ktgiatri = "a";
                        Server_Client.Client cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.NhaCungCap nv = new Entities.NhaCungCap();
                        nv = new Entities.NhaCungCap("Insert", 0, txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text, mktxtdienthoai.Text, txtEmail.Text, txtFax.Text, txtNguoilienhe.Text, txtMasothue.Text, txtduno.Text, txtWebsite.Text, txtGhichu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                        clientstrem = cl.SerializeObj(this.client1, "NhaCungCap", nv);
                        int msg = 0;
                        msg = (int)cl.DeserializeHepper(clientstrem, msg);
                        if (msg == 1)
                        {
                            this.Close();
                        }

                        else
                        {
                            MessageBox.Show("mã nhà cung cấp đã thay đổi - kiểm tra lại dữ liệu");
                            txtMaNCC.Text = new Common.Utilities().ProcessID(txtMaNCC.Text);
                        }

                    }

                }
            }
            catch
            { }
        }

        private void frmQuanlyNCC_Load(object sender, EventArgs e)
        {
            SelectDatancc();
            rdbtnhanghoa.Visible = false;
            ActiveControl = txtTenNCC;
            //if (int.Parse(duno) != 0)
            //{
            //    timer1.Enabled = true;
            //    timer1.Start();
            //}
        }

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
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.LayID lid = new Entities.LayID();
                clientstrem = cl.SerializeObj(this.client1, "LayID", lid1);
                // đổ mảng đối tượng vào datagripview       
                lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, lid);
                if (lid == null)
                {
                    return "NCC_0001";
                }
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                //idnew =(Convert.ToInt32( lid.ID)+1).ToString();
                return idnew;
            }
            finally
            { }
        }
        private void tsslblghilai_Click(object sender, EventArgs e)
        {
            try
            {
                if (Kiemtra())
                {
                    CheckConflictUpdate();
                    if (kt == "ok")
                    {
                        Server_Client.Client cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.NhaCungCap nv = new Entities.NhaCungCap();
                        nv = new Entities.NhaCungCap("Update", int.Parse(id), txtMaNCC.Text, txtTenNCC.Text, txtDiaChi.Text, mktxtdienthoai.Text, txtEmail.Text, txtFax.Text, txtNguoilienhe.Text, txtMasothue.Text, txtduno.Text, txtWebsite.Text, txtGhichu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                        clientstrem = cl.SerializeObj(this.client1, "NhaCungCap", nv);
                        int msg = 0;
                        msg = (int)cl.DeserializeHepper(clientstrem, msg);
                        if (msg == 1)
                        {
                            this.Close();
                        }
                        else
                            MessageBox.Show("Thất Bại");
                    }
                    else
                    {
                        MessageBox.Show("Thay đổi dữ liệu");
                    }
                }
            }
            catch { }

        }

        private void frmXuLyNhaCungCap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ktgiatri == "")
                frmQuanLyNhaCungCap.trave = "A";
        }
        Entities.DonHangNCC[] hienthi;
        private void rdbtndonhang_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.DonHangNCC tl = new Entities.DonHangNCC();
                // truyền HanhDong
                tl = new Entities.DonHangNCC("Select", txtMaNCC.Text);
                clientstrem = cl.SerializeObj(this.client1, "DonHangNCC", tl);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.DonHangNCC[] tl1;
                tl1 = new Entities.DonHangNCC[1];
                // đổ mảng đối tượng vào datagripview       
                tl1 = (Entities.DonHangNCC[])cl.DeserializeHepper1(clientstrem, tl1);
                if (tl1 == null)
                {
                    dataGridView1.DataSource = new Entities.DonHangNCC[0];
                    return;
                }

                Entities.DonHangNCC[] pt2 = new Entities.DonHangNCC[tl1.Length];
                int sotang = 0;
                for (int j = 0; j < tl1.Length; j++)
                {

                    pt2[sotang] = tl1[j];
                    sotang++;
                }
                hienthi = new Entities.DonHangNCC[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pt2[j];
                    }
                }
                else
                {
                    dataGridView1.DataSource = new Entities.DonHangNCC[0];
                    return;
                }
                dataGridView1.DataSource = hienthi;
                new Common.Utilities().CountDatagridview(dataGridView1);

                dataGridView1.Rows[0].Selected = true;
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Columns[j].Visible = false;
                    }
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = true;
                    dataGridView1.Columns[1].HeaderText = "Mã Đơn Đặt Hàng";
                    dataGridView1.Columns[2].Visible = true;
                    dataGridView1.Columns[2].HeaderText = "Mã Nhà Cung Cấp";
                    dataGridView1.Columns[3].Visible = true;
                    dataGridView1.Columns[3].HeaderText = "Ngày Đơn Hàng";
                    dataGridView1.Columns[4].Visible = true;
                    dataGridView1.Columns[4].HeaderText = "Trạng Thái Đơn Hàng";
                    dataGridView1.Columns[5].Visible = true;
                    dataGridView1.Columns[5].HeaderText = "Hình Thức Thanh Toán";
                    dataGridView1.Columns[6].HeaderText = "Tổng Tiền";
                    dataGridView1.Columns[6].Visible = true;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AllowUserToResizeRows = false;
                }
                catch { }
            }

        }
        Entities.LSGDNhapMua[] hienthi1;
        private void rdbtnnhapmua_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbtnnhapmua.Checked == true)
                {
                    dataGridView1.RowHeadersVisible = false;
                    cl = new Server_Client.Client();
                    // gán TCPclient
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    // khởi tạo biến truyền vào với hàm khởi tạo
                    Entities.LSGDNhapMua lsgd = new Entities.LSGDNhapMua();
                    // truyền HanhDong
                    lsgd = new Entities.LSGDNhapMua("Select", txtMaNCC.Text);

                    clientstrem = cl.SerializeObj(this.client1, "LSGDNhapMua", lsgd);
                    // khởi tạo mảng đối tượng để hứng giá trị
                    Entities.LSGDNhapMua[] lsgd1;
                    lsgd1 = new Entities.LSGDNhapMua[1];
                    // đổ mảng đối tượng vào datagripview       
                    lsgd1 = (Entities.LSGDNhapMua[])cl.DeserializeHepper1(clientstrem, lsgd1);
                    if (lsgd1 == null)
                    {
                        dataGridView1.DataSource = new Entities.LSGDNhapMua[0];
                        return;
                    }

                    Entities.LSGDNhapMua[] pt3 = new Entities.LSGDNhapMua[lsgd1.Length];
                    int sotang = 0;
                    for (int j = 0; j < lsgd1.Length; j++)
                    {

                        pt3[sotang] = lsgd1[j];
                        sotang++;
                    }
                    hienthi1 = new Entities.LSGDNhapMua[sotang];
                    if (sotang != 0)
                    {
                        for (int j = 0; j < sotang; j++)
                        {
                            hienthi1[j] = pt3[j];
                        }
                    }
                    else
                    {
                        dataGridView1.DataSource = new Entities.LSGDNhapMua[0];
                        return;
                    }
                    dataGridView1.DataSource = hienthi1;
                    new Common.Utilities().CountDatagridview(dataGridView1);

                    dataGridView1.Rows[0].Selected = true;
                }
                else
                { }
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Columns[j].Visible = false;
                    }
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = true;
                    dataGridView1.Columns[1].HeaderText = "Mã Nhà Cung Cấp";
                    dataGridView1.Columns[2].Visible = true;
                    dataGridView1.Columns[2].HeaderText = "Mã Hóa Đơn Nhập";
                    dataGridView1.Columns[3].Visible = true;
                    dataGridView1.Columns[3].HeaderText = "Ngày Nhập";
                    dataGridView1.Columns[4].Visible = true;
                    dataGridView1.Columns[4].HeaderText = "Hình Thức Thanh Toán";
                    dataGridView1.Columns[5].Visible = true;
                    dataGridView1.Columns[5].HeaderText = "Ghi Chú";
                    dataGridView1.Columns[6].HeaderText = "Tổng Tiền";
                    dataGridView1.Columns[6].Visible = true;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AllowUserToResizeRows = false;
                }
                catch { }
            }
        }
        Entities.LSGDTraLaiNCC[] hienthi2;
        private void rdbtntralai_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbtntralai.Checked == true)
                {
                    dataGridView1.RowHeadersVisible = false;
                    cl = new Server_Client.Client();
                    // gán TCPclient
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    // khởi tạo biến truyền vào với hàm khởi tạo
                    Entities.LSGDTraLaiNCC lsgd = new Entities.LSGDTraLaiNCC();
                    // truyền HanhDong
                    lsgd = new Entities.LSGDTraLaiNCC("Select", txtMaNCC.Text);

                    clientstrem = cl.SerializeObj(this.client1, "LSGDTraLaiNCC", lsgd);
                    // khởi tạo mảng đối tượng để hứng giá trị
                    Entities.LSGDTraLaiNCC[] lsgd1;
                    lsgd1 = new Entities.LSGDTraLaiNCC[1];
                    // đổ mảng đối tượng vào datagripview       
                    lsgd1 = (Entities.LSGDTraLaiNCC[])cl.DeserializeHepper1(clientstrem, lsgd1);
                    if (lsgd1 == null)
                    {
                        dataGridView1.DataSource = new Entities.LSGDTraLaiNCC[0];
                        return;
                    }

                    Entities.LSGDTraLaiNCC[] pt3 = new Entities.LSGDTraLaiNCC[lsgd1.Length];
                    int sotang = 0;
                    for (int j = 0; j < lsgd1.Length; j++)
                    {

                        pt3[sotang] = lsgd1[j];
                        sotang++;
                    }
                    hienthi2 = new Entities.LSGDTraLaiNCC[sotang];
                    if (sotang != 0)
                    {
                        for (int j = 0; j < sotang; j++)
                        {
                            hienthi2[j] = pt3[j];
                        }
                    }
                    else
                    {
                        dataGridView1.DataSource = new Entities.LSGDTraLaiNCC[0];
                        return;
                    }
                    dataGridView1.DataSource = hienthi2;
                    new Common.Utilities().CountDatagridview(dataGridView1);

                    dataGridView1.Rows[0].Selected = true;
                }
                else
                { }
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Columns[j].Visible = false;
                    }
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = true;
                    dataGridView1.Columns[1].HeaderText = "Mã Nhà Cung Cấp";
                    dataGridView1.Columns[2].Visible = true;
                    dataGridView1.Columns[2].HeaderText = "Mã Hóa Đơn Trả Lại NCC";
                    dataGridView1.Columns[3].Visible = true;
                    dataGridView1.Columns[3].HeaderText = "Ngày Trả";
                    dataGridView1.Columns[4].Visible = true;
                    dataGridView1.Columns[4].HeaderText = "Hình Thức Thanh Toán";
                    dataGridView1.Columns[5].Visible = true;
                    dataGridView1.Columns[5].HeaderText = "Ghi Chú";
                    dataGridView1.Columns[6].HeaderText = "Thanh Toán Ngay";
                    dataGridView1.Columns[6].Visible = true;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AllowUserToResizeRows = false;
                }
                catch { }
            }
        }
        Entities.LSGDTTNCC[] hienthi3;
        private void rdbtnthanhtoan_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbtnthanhtoan.Checked == true)
                {
                    dataGridView1.RowHeadersVisible = false;
                    cl = new Server_Client.Client();
                    // gán TCPclient
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    // khởi tạo biến truyền vào với hàm khởi tạo
                    Entities.LSGDTTNCC lsgd = new Entities.LSGDTTNCC();
                    // truyền HanhDong
                    lsgd = new Entities.LSGDTTNCC("Select", mancc);

                    clientstrem = cl.SerializeObj(this.client1, "LSGDTTNCC", lsgd);
                    // khởi tạo mảng đối tượng để hứng giá trị
                    Entities.LSGDTTNCC[] lsgd1;
                    lsgd1 = new Entities.LSGDTTNCC[1];
                    // đổ mảng đối tượng vào datagripview       
                    lsgd1 = (Entities.LSGDTTNCC[])cl.DeserializeHepper1(clientstrem, lsgd1);
                    if (lsgd1 == null)
                    {
                        dataGridView1.DataSource = new Entities.LSGDTTNCC[0];
                        return;
                    }

                    Entities.LSGDTTNCC[] pt3 = new Entities.LSGDTTNCC[lsgd1.Length];
                    int sotang = 0;
                    for (int j = 0; j < lsgd1.Length; j++)
                    {

                        pt3[sotang] = lsgd1[j];
                        sotang++;
                    }
                    hienthi3 = new Entities.LSGDTTNCC[sotang];
                    if (sotang != 0)
                    {
                        for (int j = 0; j < sotang; j++)
                        {
                            hienthi3[j] = pt3[j];
                        }
                    }
                    else
                    {
                        dataGridView1.DataSource = new Entities.LSGDTTNCC[0];
                        return;
                    }
                    dataGridView1.DataSource = hienthi3;
                    new Common.Utilities().CountDatagridview(dataGridView1);

                    dataGridView1.Rows[0].Selected = true;
                }
                else
                { }
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Columns[j].Visible = false;
                    }
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = true;
                    dataGridView1.Columns[1].HeaderText = "Mã Nhà Cung Cấp";
                    dataGridView1.Columns[2].Visible = true;
                    dataGridView1.Columns[2].HeaderText = "Mã Phiếu TT NCC";
                    dataGridView1.Columns[3].Visible = true;
                    dataGridView1.Columns[3].HeaderText = "Ngày Lập";
                    dataGridView1.Columns[4].Visible = true;
                    dataGridView1.Columns[4].HeaderText = "Trạng Thái";
                    dataGridView1.Columns[5].Visible = true;
                    dataGridView1.Columns[5].HeaderText = "Ghi Chú";
                    dataGridView1.Columns[6].HeaderText = "Thanh Toán ";
                    dataGridView1.Columns[6].Visible = true;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AllowUserToResizeRows = false;
                }
                catch { }
            }
        }
        Entities.HangHoaNCC[] hienthi4;
        private void rdbtnhanghoa_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbtnhanghoa.Checked == true)
                {
                    dataGridView1.RowHeadersVisible = false;
                    cl = new Server_Client.Client();
                    // gán TCPclient
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    // khởi tạo biến truyền vào với hàm khởi tạo
                    Entities.HangHoaNCC lsgd = new Entities.HangHoaNCC();
                    // truyền HanhDong
                    lsgd = new Entities.HangHoaNCC("Select", txtMaNCC.Text);

                    clientstrem = cl.SerializeObj(this.client1, "HangHoaNCC", lsgd);
                    // khởi tạo mảng đối tượng để hứng giá trị
                    Entities.HangHoaNCC[] lsgd1;
                    lsgd1 = new Entities.HangHoaNCC[1];
                    // đổ mảng đối tượng vào datagripview       
                    lsgd1 = (Entities.HangHoaNCC[])cl.DeserializeHepper1(clientstrem, lsgd1);
                    int sotang = 0;
                    if (lsgd1 == null)
                    {
                        dataGridView1.DataSource = new Entities.HangHoaNCC[0];
                        return;
                    }

                    Entities.HangHoaNCC[] pt3 = new Entities.HangHoaNCC[lsgd1.Length];
                    for (int j = 0; j < lsgd1.Length; j++)
                    {

                        pt3[sotang] = lsgd1[j];
                        sotang++;
                    }
                    hienthi4 = new Entities.HangHoaNCC[sotang];
                    if (sotang != 0)
                    {
                        for (int j = 0; j < sotang; j++)
                        {
                            hienthi4[j] = pt3[j];
                        }
                    }
                    else
                    {
                        dataGridView1.DataSource = new Entities.HangHoaNCC[0];
                        return;
                    }
                    dataGridView1.DataSource = hienthi4;
                    new Common.Utilities().CountDatagridview(dataGridView1);

                    dataGridView1.Rows[0].Selected = true;
                }
                else
                { }
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Columns[j].Visible = false;
                    }
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = true;
                    dataGridView1.Columns[1].HeaderText = "Mã Nhà Cung Cấp";
                    dataGridView1.Columns[2].Visible = true;
                    dataGridView1.Columns[2].HeaderText = "Mã Hàng Hóa";
                    dataGridView1.Columns[3].Visible = true;
                    dataGridView1.Columns[3].HeaderText = "Tên Hàng Hóa";
                    dataGridView1.Columns[4].Visible = true;
                    dataGridView1.Columns[4].HeaderText = "Mã Đơn Vị Tính";
                    dataGridView1.Columns[5].Visible = true;
                    dataGridView1.Columns[5].HeaderText = "Số Lượng";
                    dataGridView1.Columns[6].HeaderText = "Thuế GTGT";
                    dataGridView1.Columns[6].Visible = true;
                    dataGridView1.Columns[7].HeaderText = "Tổng Tiền";
                    dataGridView1.Columns[7].Visible = true;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AllowUserToResizeRows = false;
                }
                catch
                { }
            }
        }

        private void tabControldanhmucnhacungcap_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                if (!e.TabPage.Enabled)
                {
                    e.Cancel = true;
                }
            }
            catch { }
        }

        private void mktxtdienthoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch
            { }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch
            { }
        }

        private void mktxtdienthoai_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(mktxtdienthoai.Text) >= 0)
                {
                    mktxtdienthoai.Text = String.Format("{0:0}", mktxtdienthoai.Text);
                    return;
                }
            }
            catch
            {
                mktxtdienthoai.Text = "";
            }
        }

        private void txtFax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(txtFax.Text) >= 0)
                {
                    txtFax.Text = String.Format("{0:0}", txtFax.Text);
                    return;
                }
            }
            catch
            {
                txtFax.Text = "";
            }
        }

        //////////////////////////////////////////////////////BUZZ
        private void BuzzForm(int rate)
        {
            // vị trí lúc đầu của Form
            int _locationX = this.Location.X;
            int _locationY = this.Location.Y;

            for (int i = 0; i < rate; i++)
            {
                this.Location = new Point(_locationX + 5, _locationY + 5);
                System.Threading.Thread.Sleep(50);
                this.Location = new Point(_locationX + 10, _locationY + 10);
                System.Threading.Thread.Sleep(50);
                this.Location = new Point(_locationX + 7, _locationY + 3);
                System.Threading.Thread.Sleep(50);
                this.Location = new Point(_locationX, _locationY);

            }
        }
        int dem = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dem < 3)
            {
                dem++;
                BuzzForm(4);
            }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
            }
        }
        //////////////////////////////////////////////////////////////////
    }
}
