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
    public partial class frmTimNCC : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        string tenbang;
        public static DataGridViewRow drvr = null;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        public frmTimNCC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// phân luống xử lý giữa các bảng khác nhau
        /// </summary>
        /// <param name="tenbang"></param>
        public frmTimNCC(string tenbang)
        {
            this.tenbang = tenbang;
            InitializeComponent();
            if (tenbang == "PhieuTTNCC")
            {
                SelectData();
            }
        }
        Entities.NhaCungCap[] hienthi;
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData()
        {
            try
            {
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.NhaCungCap ncc = new Entities.NhaCungCap("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.NhaCungCap[] ncc1 = new Entities.NhaCungCap[1];
                clientstrem = cl.SerializeObj(this.client1, "NhaCungCap", ncc);
                // đổ mảng đối tượng vào datagripview       
                ncc1 = (Entities.NhaCungCap[])cl.DeserializeHepper1(clientstrem, ncc1);
                if (ncc1 == null)
                {
                    hienthi = new Entities.NhaCungCap[0];
                    dtgvncc.DataSource = new Entities.NhaCungCap[0];
                    return;
                }

                Entities.NhaCungCap[] ncc2 = new Entities.NhaCungCap[ncc1.Length];
                int sotang = 0;
                for (int j = 0; j < ncc1.Length; j++)
                {
                    if (ncc1[j].Deleted == false)
                    {
                        ncc2[sotang] = ncc1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.NhaCungCap[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = ncc2[j];
                    }
                }
                else
                {
                    hienthi = new Entities.NhaCungCap[0];
                    dtgvncc.DataSource = new Entities.NhaCungCap[0];
                    return;
                }

                dtgvncc.DataSource = hienthi;
                dtgvncc.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được với server - thử lại sau");
            }
            finally
            {
                fix();

            }
        }

        public void fix()
        {
            for (int i = 0; i < dtgvncc.ColumnCount; i++)
            {
                dtgvncc.Columns[i].Visible = false;
            }
            dtgvncc.ReadOnly = true; dtgvncc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvncc.Columns["NhaCungCapID"].Visible = true;
            dtgvncc.Columns["NhaCungCapID"].HeaderText = "Nhà Cung Cấp ID";
            dtgvncc.Columns["MaNhaCungCap"].Visible = true;
            dtgvncc.Columns["MaNhaCungCap"].HeaderText = "Mã Nhà Cung Cấp";
            dtgvncc.Columns["TenNhaCungCap"].Visible = true;
            dtgvncc.Columns["TenNhaCungCap"].HeaderText = "Tên Nhà Cung Cấp";
            dtgvncc.Columns["DiaChi"].Visible = true;
            dtgvncc.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dtgvncc.Columns["DuNo"].Visible = true;
            dtgvncc.Columns["DuNo"].HeaderText = "Nợ Hiện Thời";
            dtgvncc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvncc.AllowUserToAddRows = false;
            dtgvncc.AllowUserToDeleteRows = false;
            dtgvncc.AllowUserToResizeRows = false;
            dtgvncc.RowHeadersVisible = false;
        }
        /// <summary>
        /// nút hủy bỏ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslhuybo_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        int i = 0;
        /// <summary>
        /// xử lý khi click vào ô
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }
        /// <summary>
        /// xử lý khi click đúp vào ô
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// xử lý tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btntim_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// xử lý khi click chấp nhận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslchapnhan_Click(object sender, EventArgs e)
        {
            if (i < 0)
            {
                MessageBox.Show("Phải chọn đối tượng trước", "Hệ thống cảnh báo");
                return;
            }
            if (tenbang == "PhieuTTNCC")
            {
                try
                {
                    drvr = dtgvncc.Rows[i];
                    this.Close();
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// xử lý khi thay đổi kích thước
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTimNCC_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// xử lý khi nhập tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    dtgvncc.DataSource = new Entities.NhaCungCap[0];
                    return;
                }
                int soluong = 0;
                if (rdbtimkiem1.Checked == true)
                {
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaNhaCungCap.ToString().ToUpper().IndexOf(txttimkiem.Text);
                        if (kiemtra >= 0)
                        {
                            soluong++;
                        }
                    }
                    if (soluong == 0)
                    {
                        dtgvncc.DataSource = new Entities.NhaCungCap[0];
                        return;
                    }
                    Entities.NhaCungCap[] hienthitheoid = new Entities.NhaCungCap[soluong];
                    soluong = 0;
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaNhaCungCap.ToString().ToUpper().IndexOf(txttimkiem.Text);
                        if (kiemtra >= 0)
                        {
                            hienthitheoid[soluong] = hienthi[i];
                            soluong++;
                        }
                    }
                    dtgvncc.DataSource = hienthitheoid;
                }
                if (rdbtimkiem2.Checked == true)
                {
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].TenNhaCungCap.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            soluong++;
                        }
                    }
                    if (soluong == 0)
                    {
                        dtgvncc.DataSource = new Entities.NhaCungCap[0];
                        return;
                    }
                    Entities.NhaCungCap[] hienthitheoma = new Entities.NhaCungCap[soluong];
                    soluong = 0;
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].TenNhaCungCap.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            hienthitheoma[soluong] = hienthi[i];
                            soluong++;
                        }
                    }
                    dtgvncc.DataSource = hienthitheoma;
                }
            }
            finally
            {
                fix();
            }
        }
        /// <summary>
        /// xử lý khi tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbtimkiem3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtgvncc.DataSource = hienthi;
                fix();
            }
            catch
            {
            }
        }

        private void rdbtimkiem2_CheckedChanged(object sender, EventArgs e)
        {
            txttimkiem.Text = "";
        }

        private void rdbtimkiem1_CheckedChanged(object sender, EventArgs e)
        {
            txttimkiem.Text = "";
        }

        private void dtgvncc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                if (tenbang == "PhieuTTNCC")
                {
                    drvr = dtgvncc.Rows[i];
                    this.Close();
                }
            }
            catch
            {
            }
        }
        int sotang = 0;
        private void dtgvncc_KeyUp(object sender, KeyEventArgs e)
        {
            if (i < 0)
                return;
                if (e.KeyCode == Keys.Enter)
                {


                    i = dtgvncc.SelectedRows[0].Index;
                    if (tenbang == "PhieuTTNCC")
                    {
                        drvr = dtgvncc.Rows[i];
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
    }
}
