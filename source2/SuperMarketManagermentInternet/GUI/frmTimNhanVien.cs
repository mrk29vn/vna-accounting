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
    public partial class frmTimNhanVien : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        string tenbang;
        public static DataGridViewRow drvr = null;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        public frmTimNhanVien()
        {
            InitializeComponent();
            SelectData();
        }
        Entities.NhanVien[] hienthi;
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
                Entities.NhanVien ncc = new Entities.NhanVien("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.NhanVien[] ncc1 = new Entities.NhanVien[1];
                clientstrem = cl.SerializeObj(this.client1, "NhanVien", ncc);
                // đổ mảng đối tượng vào datagripview       
                ncc1 = (Entities.NhanVien[])cl.DeserializeHepper1(clientstrem, ncc1);
                if (ncc1 == null)
                {
                    hienthi = new Entities.NhanVien[0];
                    dtgvncc.DataSource = new Entities.NhanVien[0];
                    return;
                }

                Entities.NhanVien[] ncc2 = new Entities.NhanVien[ncc1.Length];
                int sotang = 0;
                for (int j = 0; j < ncc1.Length; j++)
                {
                    if (ncc1[j].Deleted == false)
                    {
                        ncc2[sotang] = ncc1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.NhanVien[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = ncc2[j];
                    }
                }
                else
                {
                    hienthi = new Entities.NhanVien[0];
                    dtgvncc.DataSource = new Entities.NhanVien[0];
                    return;
                }
                dtgvncc.DataSource = hienthi;
                dtgvncc.Rows[0].Selected = true;

            }
            catch (Exception ex)
            {
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
            dtgvncc.Columns["NhanVienID"].Visible = true;
            dtgvncc.Columns["NhanVienID"].HeaderText = "Nhân Viên ID";
            dtgvncc.Columns["MaNhanVien"].Visible = true;
            dtgvncc.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
            dtgvncc.Columns["TenNhanVien"].Visible = true;
            dtgvncc.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
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

        int i;
        /// <summary>
        /// xử lý khi ấn vào ô
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
        private void dtgvncc_DoubleClick(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// xử lý khi ấn nút 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslchapnhan_Click(object sender, EventArgs e)
        {
            if (i < 0)
            {
                return;
            }
            try
            {
                drvr = dtgvncc.Rows[i];
                this.Close();
            }
            catch
            {
            }
        }
        /// <summary>
        /// xử lý khí ấn vào tìm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btntim_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// xử lý khi thao đổi kích thước
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTimNhanVien_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// xử lý tìm kiếm
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
                    dtgvncc.DataSource = new Entities.NhanVien[0];
                    return;
                }
                int soluong = 0;
                if (rdbtimkiem1.Checked == true)
                {
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].TenNhanVien.ToString().ToUpper().IndexOf(txttimkiem.Text);
                        if (kiemtra >= 0)
                        {
                            soluong++;
                        }
                    }
                    if (soluong == 0)
                    {
                        dtgvncc.DataSource = new Entities.NhanVien[0];
                        return;
                    }
                    Entities.NhanVien[] hienthitheoid = new Entities.NhanVien[soluong];
                    soluong = 0;
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].TenNhanVien.ToString().ToUpper().IndexOf(txttimkiem.Text);
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
                        int kiemtra = hienthi[i].MaNhanVien.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            soluong++;
                        }
                    }
                    if (soluong == 0)
                    {
                        dtgvncc.DataSource = new Entities.NhanVien[0];
                        return;
                    }
                    Entities.NhanVien[] hienthitheoma = new Entities.NhanVien[soluong];
                    soluong = 0;
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaNhanVien.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
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
        /// xử lý tìm kiếm
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
                drvr = dtgvncc.Rows[i];
                this.Close();
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
                drvr = dtgvncc.Rows[i];
                sotang = 0;
                this.Close();
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
