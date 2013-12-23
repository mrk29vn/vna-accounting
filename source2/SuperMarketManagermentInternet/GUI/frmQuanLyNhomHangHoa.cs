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
    public partial class frmQuanLyNhomHangHoa : Form
    {
        //Khai báo các hàm
        public TcpClient tcpClient;
        public NetworkStream networkStream;

        public frmQuanLyNhomHangHoa()
        {
            InitializeComponent();
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
        private void frmNhomHang_Load(object sender, EventArgs e)
        {
            SelectData();
            fix();
        }

        //Đặt tên tiếng việt
        public void fix()
        {
            for (int i = 0; i < dgvNhomHang.ColumnCount; i++)
            {
                dgvNhomHang.Columns[i].Visible = false;
            }
           
            dgvNhomHang.RowHeadersVisible = false;
            dgvNhomHang.AllowUserToResizeRows = false;
            dgvNhomHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhomHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhomHang.ReadOnly = true;
            new Common.Utilities().CountDatagridview(dgvNhomHang);
            dgvNhomHang.Columns["HanhDong"].Visible = true;
            dgvNhomHang.Columns["MaNhomHang"].Visible = true;
            dgvNhomHang.Columns["TenLoaiHang"].Visible = true;
            dgvNhomHang.Columns["TenNhomHang"].Visible = true;
            dgvNhomHang.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dgvNhomHang.Columns["HanhDong"].HeaderText = "STT";
            dgvNhomHang.Columns["MaNhomHang"].HeaderText = "Mã Nhóm Hàng";
            dgvNhomHang.Columns["TenLoaiHang"].HeaderText = "Tên Loại Hàng";
            dgvNhomHang.Columns["TenNhomHang"].HeaderText = "Tên Nhóm Hàng";
            dgvNhomHang.Columns["GhiChu"].HeaderText = "Ghi Chú";
            this.Focus();
        }
        Entities.NhomHang[] hienthi;
        //Lấy dữ liệu từ Database
        public void SelectData()
        {
            try
            {
                dgvNhomHang.RowHeadersVisible = false;
                Server_Client.Client cl = new Server_Client.Client();
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                Entities.NhomHang nh = new Entities.NhomHang("Select");
                Entities.NhomHang[] nh1 = new Entities.NhomHang[1];
                networkStream = cl.SerializeObj(this.tcpClient, "NhomHang", nh);
                nh1 = (Entities.NhomHang[])cl.DeserializeHepper1(networkStream, nh1);

                if (nh1 == null)
                {
                    tssXoa.Enabled = false;
                    tssSua.Enabled = false;
                    hienthi = new Entities.NhomHang[0];
                    dgvNhomHang.DataSource = new Entities.NhomHang[0];
                    return;
                }

                Entities.NhomHang[] pt2 = new Entities.NhomHang[nh1.Length];
                int sotang = 0;
                for (int j = 0; j < nh1.Length; j++)
                {
                    if (nh1[j].Deleted == false)
                    {
                        pt2[sotang] = nh1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.NhomHang[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pt2[j];
                    }
                }
                else
                {
                    hienthi = new Entities.NhomHang[0];
                    dgvNhomHang.DataSource = new Entities.NhomHang[0];
                    tssXoa.Enabled = false;
                    tssSua.Enabled = false;
                    return;
                }
                tssXoa.Enabled = true;
                tssSua.Enabled = true;
                dgvNhomHang.DataSource = hienthi;
                dgvNhomHang.Rows[0].Selected = true;
            }
            catch (Exception)
            {
                
            }
            finally
            {
                fix();
            }
        }

        //Hiển thị form Thêm Nhóm Hàng Hóa
        private void tssThem_Click(object sender, EventArgs e)
        {
            if (!Common.Utilities.User.Administrator && !(new Common.Utilities().CheckQuyen(this.Name, 4)))
            {
                MessageBox.Show("Bạn không có quyền vào", "Hệ thống cảnh báo");
                return;
            }
            for (int j = 0; j < 1000; j++)
            {

                if (frmXuLyNhomHangHoa.trave == "")
                {

                    frmXuLyNhomHangHoa tnhh = new frmXuLyNhomHangHoa("Insert");
                    tnhh.ShowDialog();
                    SelectData();

                }
                else
                {
                    frmXuLyNhomHangHoa.trave = "";
                    return;
                    
                }
            }
            
        }

        //Hiển thị form Sửa Nhóm Hàng Hóa
        private void tssSua_Click(object sender, EventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                if (!Common.Utilities.User.Administrator && !(new Common.Utilities().CheckQuyen(this.Name, 2)))
                {
                    MessageBox.Show("Bạn không có quyền vào", "Hệ thống cảnh báo");
                    return;
                }
                frmXuLyNhomHangHoa snhh = new frmXuLyNhomHangHoa("Update", dgvNhomHang.Rows[i]);
                snhh.ShowDialog();
                SelectData();
            }
            catch
            {
            }
        }

        //Xóa Data trên Data Grid View
        #region Xử lý khi Delete
        private void tssXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && !(new Common.Utilities().CheckQuyen(this.Name, 3)))
                {
                    MessageBox.Show("Bạn không có quyền vào", "Hệ thống cảnh báo");
                    return;
                }
                if (new Check().CheckReference("NhomHang", dgvNhomHang["MaNhomHang", i].Value.ToString()) == false)
                {
                    MessageBox.Show("Nhóm hàng này đang có giao dịch không thể xóa", "Hệ thống cảnh báo");
                    return;
                }
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn muốn Xóa không?", "Hệ Thống Cảnh Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        Server_Client.Client cl = new Server_Client.Client();
                        this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.NhomHang nh = new Entities.NhomHang();
                        nh = new Entities.NhomHang("Delete", int.Parse(dgvNhomHang.CurrentRow.Cells["NhomHangID"].Value.ToString()),Common.Utilities.User.NhanVienID,Common.Utilities.User.TenDangNhap);
                        networkStream = cl.SerializeObj(this.tcpClient, "NhomHang", nh);
                        bool kt = false;
                        kt = (bool)cl.DeserializeHepper(networkStream, kt);
                        if (kt == true)
                        {
                        }
                        else
                            MessageBox.Show("thất bại - xin hãy kiểm tra lại", "Hệ thống cảnh báo");
                        SelectData();
                    }
                }

            }
            catch
            {
            }
        }
        #endregion

        //Hiển thị Sửa Nhóm Hàng Hóa
        private void dgvNhomHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
            }
            catch
            {
            }
        }

        //In Data
        private void tssIn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa xử lý");
        }

        //Đóng form
        private void tssDong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
                else
                { }
            }
        }
        int i = 0;

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbtimkiem3.Checked == true)
                {
                    return;
                }
                if (txttimkiem.Text.Length == 0)
                {                    
                    dgvNhomHang.DataSource = new Entities.NhomHang[0];
                    return;
                }
                int soluong = 0;
                if (rdbtimkiem1.Checked == true)
                {
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].TenNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            soluong++;
                        }
                    }
                    if (soluong == 0)
                    {
                        dgvNhomHang.DataSource = new Entities.NhomHang[0];
                        return;
                    }
                    Entities.NhomHang[] hienthitheoid = new Entities.NhomHang[soluong];
                    soluong = 0;
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].TenNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            hienthitheoid[soluong] = hienthi[i];
                            soluong++;
                        }
                    }
                    dgvNhomHang.DataSource = hienthitheoid;
                }
                if (rdbtimkiem2.Checked == true)
                {
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            soluong++;
                        }
                    }
                    if (soluong == 0)
                    {
                        dgvNhomHang.DataSource = new Entities.NhomHang[0];
                        return;
                    }
                    Entities.NhomHang[] hienthitheoma = new Entities.NhomHang[soluong];
                    soluong = 0;
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            hienthitheoma[soluong] = hienthi[i];
                            soluong++;
                        }
                    }
                    dgvNhomHang.DataSource = hienthitheoma;
                }
            }
            finally
            {
                fix();
            }
        }

        private void rdbtimkiem3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (hienthi == null)
                {
                    dgvNhomHang.DataSource = new Entities.NhomHang[0];
                    return;
                }
                dgvNhomHang.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                fix();

            }
        }

        private void palTencung_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void dgvNhomHang_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            if (i < 0)
                return;
            try
            {
                frmXuLyNhomHangHoa snhh = new frmXuLyNhomHangHoa("Update", dgvNhomHang.Rows[i]);
                snhh.ShowDialog();
                SelectData();
            }
            catch
            {
            }
        }

        private void dgvNhomHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void rdbtimkiem1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbtimkiem2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tsslnaplai_Click(object sender, EventArgs e)
        {
            SelectData(); this.Focus();
        }

    }
}
