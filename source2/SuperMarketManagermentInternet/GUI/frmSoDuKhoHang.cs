using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmSoDuKhoHang : Form
    {
        DateTime datesv;
        public frmSoDuKhoHang()
        {
            InitializeComponent();
            try
            {
                datesv = DateServer.Date();
                LayHangHoa();
                toolStrip1.Enabled = false;
                LayKhoHang();
                cbbkhohang.DataSource = khohang;
                cbbkhohang.DisplayMember = "TenKho";
            }
            catch { }
        }
        public static Entities.SoDuKho sdkho;
        public Entities.SoDuKho[] arrsdkho;
        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        #region Lấy Bảng Hàng Hóa
        public Entities.HangHoa[] HangHoa;
        public void LayHangHoa()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.HangHoa ctxh = new Entities.HangHoa("Select");
                clientstrem = cl.SerializeObj(this.client, "HangHoa", ctxh);
                HangHoa = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, HangHoa);
                if (HangHoa == null)
                {
                    HangHoa = new Entities.HangHoa[0];
                    return;
                }
            }
            catch { }
        }
        #endregion
        public string LayTenHangHoa(string maHangHoa)
        {
            for (int i = 0; i < HangHoa.Length; i++)
            {
                if (HangHoa[i].MaHangHoa==maHangHoa)
                {
                    return HangHoa[i].TenHangHoa;
                }
            }
            return "";
        }
        #region Lấy Bảng Hàng Hóa
        public Entities.HangHoa[] hanghoa;
        public void LayBangHangHoa()
        {
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            clientstrem = cl.SerializeObj(this.client, "Select", new Entities.CheckRefer("HH", ""));
            Entities.HangHoa[] hh1 = new Entities.HangHoa[1];
            hh1 = (Entities.HangHoa[])cl.DeserializeHepper(clientstrem, hh1);
            if (hh1 == null)
            {
                hanghoa = new Entities.HangHoa[0];
            }
            hanghoa = hh1;
        }
        #endregion
        Entities.SoDuKho[] ddh;
        public void HienThi()
        {
            try
            {
                bool kt = false;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "SoDuKho", new Entities.SoDuKho("Select"));
                ddh = new Entities.SoDuKho[1];
                ddh = (Entities.SoDuKho[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh == null)
                {
                    toolStrip1.Enabled = true;
                    dgvsodukhohang.DataSource = new Entities.SoDuKho[0];
                    FixDatagridview();
                    return;
                }
                Entities.KhoHang kh = (Entities.KhoHang)cbbkhohang.SelectedItem;
                List<Entities.SoDuKho> L = new List<Entities.SoDuKho>();
                DateTime SoSanh = new DateTime(int.Parse(cbbnam.Text), int.Parse(cbbthang.Text), 1);
                foreach (Entities.SoDuKho item in ddh)
                {
                    if ((item.TrangThai && !kt) || (!kt && (item.NgayKetChuyen.Month == SoSanh.Month - 1) && (item.NgayKetChuyen.Year == SoSanh.Year) && (item.MaKho.ToUpper().Equals(kh.MaKho.ToUpper()))))
                    {
                        kt = item.TrangThai;
                    }
                    if ((item.NgayKetChuyen.Month == SoSanh.Month) && (item.NgayKetChuyen.Year == SoSanh.Year) && (item.MaKho.ToUpper().Equals(kh.MaKho.ToUpper())))
                    {
                        L.Add(item);
                    }
                }
                if (L.Count == 0)
                {
                    lbltrangthai.Text = "";
                    toolStrip1.Enabled = true;
                    dgvsodukhohang.DataSource = new Entities.SoDuKho[0];
                    FixDatagridview();
                    return;
                }
                if (L[0].TrangThai)
                {
                    lbltrangthai.ForeColor = Color.Red;
                    lbltrangthai.Text = "Kỳ Đã Khóa";
                    toolStrip1.Enabled = false;
                }
                else
                {
                    lbltrangthai.ForeColor = Color.Green;
                    lbltrangthai.Text = "Kỳ Chưa Khóa";
                    toolStrip1.Enabled = true;
                }
                dgvsodukhohang.DataSource = L.ToArray();
                FixDatagridview();
                if (kt)
                {
                    toolStrip1.Enabled = false;
                }
            }
            catch { }
        }

        public void FixDatagridview()
        {
            dgvsodukhohang.Columns[0].HeaderText = "STT";
            dgvsodukhohang.RowHeadersVisible = false;
            dgvsodukhohang.Columns[1].Visible = false;
            dgvsodukhohang.Columns[dgvsodukhohang.ColumnCount - 1].Visible = false;
            dgvsodukhohang.AllowUserToResizeRows = false;
            dgvsodukhohang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvsodukhohang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvsodukhohang.ReadOnly = true;
            dgvsodukhohang.Columns["MaSoDuKho"].Visible = false;
            dgvsodukhohang.Columns["MaKho"].HeaderText = "Mã Kho";
            dgvsodukhohang.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
            dgvsodukhohang.Columns["TenHangHoa"].HeaderText = "Tên Hàng Hóa";
            dgvsodukhohang.Columns["SoDuDauKy"].HeaderText = "Số Dư Đầu Kỳ";
            dgvsodukhohang.Columns["SoDuCuoiKy"].HeaderText = "Số Dư Cuối Kỳ";
            dgvsodukhohang.Columns["PhatSinhNo"].Visible = false;
            dgvsodukhohang.Columns["PhatSinhCo"].Visible = false;
            dgvsodukhohang.Columns["NgayKetChuyen"].Visible = false;
            new Common.Utilities().CountDatagridview(dgvsodukhohang);
        }

        private void tsslma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                Entities.KhoHang kho = (Entities.KhoHang)cbbkhohang.SelectedItem;
                frmTraCuuHDNhap fr = new frmTraCuuHDNhap("HangHoa", kho.MaKho);
                fr.ShowDialog();
                if (sdkho != null)
                {
                    tsslma.Text = sdkho.MaHangHoa;
                    tsslten.Text = sdkho.TenHangHoa;
                }
            }
        }

        private void cbbthang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbnam.SelectedIndex == -1) { }
            else
                if (cbbthang.SelectedIndex == -1) { }
                else
                    if (cbbkhohang.SelectedIndex == -1) { }
                    else
                    { HienThi(); }
        }

        private void cbbnam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbnam.SelectedIndex == -1) { }
            else
                if (cbbthang.SelectedIndex == -1) { }
                else
                    if (cbbkhohang.SelectedIndex == -1) { }
                    else
                    { HienThi(); }
        }

        private void cbbkhohang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbnam.SelectedIndex == -1) { }
            else
                if (cbbthang.SelectedIndex == -1) { }
                else
                    if (cbbkhohang.SelectedIndex == -1) { }
                    else
                    { HienThi(); }
        }

        public Entities.KhoHang[] khohang;
        public void LayKhoHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KhoHang ctxh = new Entities.KhoHang("Select");
                clientstrem = cl.SerializeObj(this.client, "KhoHang", ctxh);
                khohang = (Entities.KhoHang[])cl.DeserializeHepper1(clientstrem, khohang);
                if (khohang == null)
                {
                    khohang = new Entities.KhoHang[0];
                    return;
                }
            }
            catch { }
        }

        private void dgvsodukhohang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                if (dgvsodukhohang.RowCount>0)
                {
                    if (!(bool)dgvsodukhohang.Rows[0].Cells["TrangThai"].Value)
                    {
                        bool kt = true;
                        for (int i = 0; i < ddh.Length; i++)
                        {
                            if (ddh[i].NgayKetChuyen.Month == Convert.ToInt32(cbbthang.Text) - 1 && ddh[i].NgayKetChuyen.Year.ToString() == cbbnam.Text)
                            {
                                kt = false;
                                break;
                            }
                        }
                        if (kt)
                        {
                            string maSoDuKho=dgvsodukhohang.Rows[e.RowIndex].Cells["MaSoDuKho"].Value.ToString();
                            string maHangHoa = dgvsodukhohang.Rows[e.RowIndex].Cells["MaHangHoa"].Value.ToString();
                            string makho = dgvsodukhohang.Rows[e.RowIndex].Cells["MaKho"].Value.ToString();

                            int sddk = Convert.ToInt32(dgvsodukhohang.Rows[e.RowIndex].Cells["SoDuDauKy"].Value.ToString());
                            cl = new Server_Client.Client();
                            this.client = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.SoDuKho sodukho = new Entities.SoDuKho("Delete", 1, maSoDuKho,makho, maHangHoa, sddk, 0, datesv, 0, 0, false);
                            clientstrem = cl.SerializeObj(this.client, "SoDuKho", sodukho);
                            bool msg = true;
                            msg = (bool)cl.DeserializeHepper(clientstrem, msg);
                            if (msg)
                            {
                                cl = new Server_Client.Client();
                                this.client = cl.Connect(Luu.IP, Luu.Ports);
                                Entities.ChiTietKhoHangTheoHoaHonNhap[] ctkho = new Entities.ChiTietKhoHangTheoHoaHonNhap[1];
                                ctkho[0] = new Entities.ChiTietKhoHangTheoHoaHonNhap();
                                ctkho[0].Hanhdong = "Update";
                                ctkho[0].Makho = makho;
                                ctkho[0].Mahanghoa = maHangHoa;
                                ctkho[0].Soluong = sddk;
                                clientstrem = cl.SerializeObj(this.client, "ThemChiTietKhoHang", ctkho);
                                
                                tsslma.Text = maHangHoa;
                                tsslsodudauky.Text = sddk.ToString();
                                tsslten.Text = LayTenHangHoa(maHangHoa);
                                HienThi();
                            }
                            else
                            {
                                MessageBox.Show("Insert thất Bại");
                            }
                        }
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
                bool kt1 = true;
                for (int i = 0; i < dgvsodukhohang.RowCount; i++)
                {
                    if (dgvsodukhohang.Rows[i].Cells["MaHangHoa"].Value.ToString() == tsslma.Text)
                    {
                        kt1 = false;
                        break;
                    }
                }
                if (kt1)
                {
                    string ma = LayID("SoDuKho");
                    Entities.KhoHang kh = (Entities.KhoHang)cbbkhohang.SelectedItem;
                    string makho = kh.MaKho;
                    cl = new Server_Client.Client();
                    this.client = cl.Connect(Luu.IP, Luu.Ports);
                    Entities.SoDuKho sodukho = new Entities.SoDuKho("Insert", 1, ma,makho, tsslma.Text, Convert.ToInt32(tsslsodudauky.Text), 0, datesv, 0, 0, false);
                    clientstrem = cl.SerializeObj(this.client, "SoDuKho", sodukho);
                    bool msg = true;
                    msg = (bool)cl.DeserializeHepper(clientstrem, msg);
                    if (msg)
                    {
                        cl = new Server_Client.Client();
                        this.client = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.ChiTietKhoHangTheoHoaHonNhap[] ctkho = new Entities.ChiTietKhoHangTheoHoaHonNhap[1];
                        ctkho[0] = new Entities.ChiTietKhoHangTheoHoaHonNhap();
                        ctkho[0].Hanhdong = "UpdateCong";
                        ctkho[0].Makho = makho;
                        ctkho[0].Mahanghoa = tsslma.Text;
                        ctkho[0].Soluong = Convert.ToInt32(tsslsodudauky.Text);
                        clientstrem = cl.SerializeObj(this.client, "ThemChiTietKhoHang", ctkho);
                        int i = 0;
                        i = (int)cl.DeserializeHepper(clientstrem, i);
                        HienThi();
                        tsslma.Text = "<F4>-tra cứu";
                        tsslsodudauky.Text = "0";
                        tsslten.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Insert thất Bại");
                    }
                }
                else
                    MessageBox.Show("Hàng Hóa đã được nhập số dư đầu kỳ - Không thể thêm mới");
        }

        #region LayID
        public string LayID(string tenBang)
        {
            string idnew = "";
            cl = new Server_Client.Client();
            // gán TCPclient
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            // khởi tạo biến truyền vào với hàm khởi tạo
            Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
            // khởi tạo mảng đối tượng để hứng giá trị
            Entities.LayID lid = new Entities.LayID();
            clientstrem = cl.SerializeObj(this.client, "LayID", lid1);
            // đổ mảng đối tượng vào datagripview       
            lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, lid1);
            if (lid != null)
            {
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
            }
            else
            {
                if (lid == null)
                {
                    idnew = "SDK_0001";
                }
            }
            return idnew;
        }
        #endregion

        private void toolStripStatus_Dong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
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

        private void tsslsodudauky_TextChanged(object sender, EventArgs e)
        {
            new TienIch().AutoFormat(sender, false, false);
        }
    }
}
