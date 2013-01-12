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
    public partial class frmQuanLyTheGiamGia : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        public frmQuanLyTheGiamGia()
        {
            InitializeComponent();
            SelectData();
        }

        void SelectData()
        {
            try
            {
                i = 0;
                dtgvbanbuon.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.TheGiamGia pt = new Entities.TheGiamGia();
                pt.HanhDong = "Select";
                clientstrem = cl.SerializeObj(this.client1, "TheGiamGia", pt);
                // đổ mảng đối tượng vào datagripview       
                hienthi = (Entities.TheGiamGia[])cl.DeserializeHepper1(clientstrem, hienthi);
                if (hienthi == null)
                    hienthi = new Entities.TheGiamGia[0];
                //Fix hiển thị
                foreach (Entities.TheGiamGia item in hienthi)
                {
                    item.GiaTriThe = new TienIch().FormatMoney(item.GiaTriThe.Replace(",", ""));
                    item.GiaTriConLai = new TienIch().FormatMoney(item.GiaTriConLai.Replace(",", ""));
                }
                //////////////////////////////////
                dtgvbanbuon.DataSource = hienthi;
                if (hienthi.Length != 0)
                {
                    dtgvbanbuon.Rows[0].Selected = true;
                }
            }
            catch
            {
                MessageBox.Show("Không kết nối được với server - thử lại sau");
                dtgvbanbuon.DataSource = new Entities.TheGiamGia[0];
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
        int i;
        private void dtgvbanbuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void dtgvbanbuon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            if (i < 0)
                return;
            try
            {
                frmXuLyTheGiamGia tmptc = new frmXuLyTheGiamGia(dtgvbanbuon.Rows[i]);
                tmptc.ShowDialog();
                SelectData();
            }
            catch
            {
            }
        }

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
                    dtgvbanbuon.DataSource = new Entities.TheGiamGia[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtimkiem2.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaTheGiamGia.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvbanbuon.DataSource = new Entities.TheGiamGia[0];
                            return;
                        }
                        Entities.TheGiamGia[] hienthitheoma = new Entities.TheGiamGia[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaTheGiamGia.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        //Fix hiển thị
                        foreach (Entities.TheGiamGia item in hienthitheoma)
                        {
                            item.GiaTriThe = new TienIch().FormatMoney(item.GiaTriThe);
                        }
                        //////////////////////////////////
                        dtgvbanbuon.DataSource = hienthitheoma;
                    }
                    if (soluong != 0)
                    {

                    }
                }
            }
            finally
            {
                fix();
            }
        }
        Entities.TheGiamGia[] hienthi;
        private void rdbtimkiem3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (hienthi == null)
                {
                    dtgvbanbuon.DataSource = new Entities.TheGiamGia[0];
                    return;
                }
                dtgvbanbuon.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {

                fix();
            }
        }

        void fix()
        {
            new Common.Utilities().CountDatagridview(dtgvbanbuon);
            for (int j = 1; j < dtgvbanbuon.ColumnCount; j++)
            {
                dtgvbanbuon.Columns[j].Visible = false;
            }
            dtgvbanbuon.ReadOnly = true;
            dtgvbanbuon.Columns[0].Visible = true;
            dtgvbanbuon.Columns[0].HeaderText = "STT";
            dtgvbanbuon.Columns["MaTheGiamGia"].Visible = true;
            dtgvbanbuon.Columns["MaTheGiamGia"].HeaderText = "Mã Thẻ Giảm Giá";
            dtgvbanbuon.Columns["MaKhachHang"].Visible = true;
            dtgvbanbuon.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
            dtgvbanbuon.Columns["GiaTriThe"].Visible = true;
            dtgvbanbuon.Columns["GiaTriThe"].HeaderText = "Giá Trị Thẻ";
            dtgvbanbuon.Columns["GiaTriConLai"].Visible = true;
            dtgvbanbuon.Columns["GiaTriConLai"].HeaderText = "Giá Trị Còn Lại";
            dtgvbanbuon.Columns["NgayBatDau"].Visible = true;
            dtgvbanbuon.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
            dtgvbanbuon.Columns["NgayKetThuc"].Visible = true;
            dtgvbanbuon.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
            dtgvbanbuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvbanbuon.AllowUserToAddRows = false;
            dtgvbanbuon.AllowUserToDeleteRows = false;
            dtgvbanbuon.AllowUserToResizeRows = false;
            this.Focus();
        }

        private void tsslnaplai_Click(object sender, EventArgs e)
        {
            SelectData();
        }

        private void tsslthem_Click(object sender, EventArgs e)
        {
            if (!Common.Utilities.User.Administrator)
            {
                MessageBox.Show("Bạn không có quyền vào", "Hệ thống cảnh báo");
                return;
            }
            for (int j = 0; j < 1000; j++)
            {
                if (frmXuLyTheGiamGia.trave == "")
                {
                    frmXuLyTheGiamGia buon = new frmXuLyTheGiamGia();
                    buon.ShowDialog();
                    SelectData();
                }
                else
                {
                    frmXuLyTheGiamGia.trave = "";
                    break;
                }
            }
        }

        private void toolStripStatus_Dong_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                if (i < 0)
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi", "Hệ thống cảnh báo");
                    return;
                }
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.TheGiamGia pt = new Entities.TheGiamGia();
                pt.HanhDong = "Delete";
                pt.MaTheGiamGia = dtgvbanbuon.Rows[i].Cells["MaTheGiamGia"].Value.ToString();
                clientstrem = cl.SerializeObj(this.client1, "TheGiamGia", pt);
                // đổ mảng đối tượng vào datagripview    
                int kt = 0;
                 kt = (int)cl.DeserializeHepper(clientstrem, kt);
                if (kt != 0)
                {
                    SelectData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại - xin thử lại sau", "Hệ thống cảnh báo");
                    return;
                }
            }
            catch
            {
            }
        }
    }
}
