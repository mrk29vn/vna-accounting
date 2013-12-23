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
    public partial class frmTimKH : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        string tenbang;
        public static DataGridViewRow drvr = null;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        public frmTimKH()
        {
            InitializeComponent();
        }

        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        /// <param name="tenbang"></param>
        public frmTimKH(string tenbang)
        {
            try
            {
                this.tenbang = tenbang;
                InitializeComponent();
                if (tenbang == "PhieuTTCuaKH")
                {
                    SelectData();
                }
            }
            catch
            {
            }
        }
        Entities.KhachHang[] hienthi;
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
                Entities.KhachHang kh = new Entities.KhachHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.KhachHang[] kh1 = new Entities.KhachHang[1];
                clientstrem = cl.SerializeObj(this.client1, "KhachHang", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.KhachHang[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 == null)
                {
                    hienthi = new Entities.KhachHang[0];
                    dtgvKH.DataSource = new Entities.KhachHang[0];
                    return;
                }

                Entities.KhachHang[] ncc2 = new Entities.KhachHang[kh1.Length];
                int sotang = 0;
                for (int j = 0; j < kh1.Length; j++)
                {
                    if (kh1[j].Deleted == false)
                    {
                        ncc2[sotang] = kh1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.KhachHang[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = ncc2[j];
                    }
                }
                else
                {
                    hienthi = new Entities.KhachHang[0];
                    dtgvKH.DataSource = new Entities.KhachHang[0];
                    return;
                }

                dtgvKH.DataSource = hienthi;

            }
            catch
            {

            }
            finally
            {
                fix();


            }
        }
        public void fix()
        {
            for (int i = 0; i < dtgvKH.ColumnCount; i++)
            {
                dtgvKH.Columns[i].Visible = false;
            } dtgvKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvKH.ReadOnly = true;
            dtgvKH.Columns["KhachHangID"].Visible = true;
            dtgvKH.Columns["KhachHangID"].HeaderText = "Khách Hàng ID";
            dtgvKH.Columns["MaKH"].Visible = true;
            dtgvKH.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
            dtgvKH.Columns["Ten"].Visible = true;
            dtgvKH.Columns["Ten"].HeaderText = "Tên Khách Hàng";
            dtgvKH.Columns["DiaChi"].Visible = true;
            dtgvKH.Columns["DiaChi"].HeaderText = "Địa Chỉ Khách Hàng";
            dtgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvKH.AllowUserToAddRows = false;
            dtgvKH.AllowUserToDeleteRows = false;
            dtgvKH.AllowUserToResizeRows = false;
            dtgvKH.RowHeadersVisible = false;
        }
        /// <summary>
        /// đóng form
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

        /// <summary>
        /// lấy giá trị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslchapnhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (i < 0)
                {
                    MessageBox.Show("Phải chọn đối tượng trước", "Hệ thống cảnh báo");
                    return;
                }
                if (tenbang == "PhieuTTCuaKH")
                {
                    drvr = dtgvKH.Rows[i];
                    this.Close();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// nếu click đúp chuột
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgvKH_DoubleClick(object sender, EventArgs e)
        {

        }

        int i = 0;
        /// <summary>
        /// xử lý khi ấn vào ô
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }
        /// <summary>
        /// xử lý khi click button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btntim_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// xử lý khi chấp nhận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmTimKH_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// xử lý khi tìm kiếm
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
                    dtgvKH.DataSource = new Entities.KhachHang[0];
                    return;
                }
                int soluong = 0;
                if (rdbtimkiem1.Checked == true)
                {
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].Ten.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            soluong++;
                        }
                    }
                    if (soluong == 0)
                    {
                        dtgvKH.DataSource = new Entities.KhachHang[0];
                        return;
                    }
                    Entities.KhachHang[] hienthitheoid = new Entities.KhachHang[soluong];
                    soluong = 0;
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].Ten.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            hienthitheoid[soluong] = hienthi[i];
                            soluong++;
                        }
                    }
                    dtgvKH.DataSource = hienthitheoid;
                }
                if (rdbtimkiem2.Checked == true)
                {
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaKH.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            soluong++;
                        }
                    }
                    if (soluong == 0)
                    {
                        dtgvKH.DataSource = new Entities.KhachHang[0];
                        return;
                    }
                    Entities.KhachHang[] hienthitheoma = new Entities.KhachHang[soluong];
                    soluong = 0;
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaKH.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            hienthitheoma[soluong] = hienthi[i];
                            soluong++;
                        }
                    }
                    dtgvKH.DataSource = hienthitheoma;
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
                dtgvKH.DataSource = hienthi;
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

        private void rdbtimkiem2_CheckedChanged(object sender, EventArgs e)
        {
            txttimkiem.Text = "";
        }

        private void dtgvKH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (i < 0)
                return;
            if (tenbang == "PhieuTTCuaKH")
            {
                drvr = dtgvKH.Rows[i];
                this.Close();
            }
        }

        private void dtgvKH_KeyUp(object sender, KeyEventArgs e)
        {
            if (i < 0)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                i = dtgvKH.SelectedRows[0].Index;
                if (tenbang == "PhieuTTCuaKH")
                {
                    drvr = dtgvKH.Rows[i];
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
