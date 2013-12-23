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
    public partial class frmQuanLyPhieuThanhToanCuaKH : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        public static string trave = "";
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        public frmQuanLyPhieuThanhToanCuaKH()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslthemmoi_Click(object sender, EventArgs e)
        {
            if (!Common.Utilities.User.Administrator && !(new Common.Utilities().CheckQuyen(this.Name, 4)))
            {
                MessageBox.Show("Bạn không có quyền vào", "Hệ thống cảnh báo");
                return;
            }
            for (int j = 0; j < 1000; j++)
            {
                if (trave == "")
                {
                    frmXuLyPhieuTTCuaKH a = new frmXuLyPhieuTTCuaKH("Them");
                    a.ShowDialog();
                    SelectData();
                }
                else
                {
                    trave = "";
                    break;
                }
            }
        }

        /// <summary>
        /// Lọc dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslloc_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssldong_Click(object sender, EventArgs e)
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

        /// <summary>
        /// sửa dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslsua_Click(object sender, EventArgs e)
        {
            try
            {
                frmXuLyPhieuTTCuaKH a = new frmXuLyPhieuTTCuaKH("Sua", dtgvThanhtoanKH.Rows[i]);
                a.ShowDialog();
                SelectData();
            }
            catch
            {
            }
        }
        /// <summary>
        /// Form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmThanhToanVoiKH_Load(object sender, EventArgs e)
        {
            SelectData();
        }

        Server_Client.Client cl;
        Entities.PhieuTTCuaKH[] pttckh1;
        Entities.PhieuTTCuaKH[] hienthi;
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData()
        {
            try
            {
                dtgvThanhtoanKH.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.PhieuTTCuaKH pttckh = new Entities.PhieuTTCuaKH();
                // truyền HanhDong
                pttckh = new Entities.PhieuTTCuaKH("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                pttckh1 = new Entities.PhieuTTCuaKH[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuTTCuaKH", pttckh);
                // đổ mảng đối tượng vào datagripview       
                pttckh1 = (Entities.PhieuTTCuaKH[])cl.DeserializeHepper1(clientstrem, pttckh1);
                if (pttckh1 == null)
                {
                    tsslxoa.Enabled = false;
                    dtgvThanhtoanKH.DataSource = new Entities.PhieuTTCuaKH[0];
                    return;
                }
                tsslxoa.Enabled = true;

                Entities.PhieuTTCuaKH[] pttckh2 = new Entities.PhieuTTCuaKH[pttckh1.Length];
                int sotang = 0;
                for (int j = 0; j < pttckh1.Length; j++)
                {
                    if (pttckh1[j].Deleted == false)
                    {
                        pttckh2[sotang] = pttckh1[j];
                        sotang++;
                    }
                }

                hienthi = new Entities.PhieuTTCuaKH[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pttckh2[j];
                    }
                }
                else
                {
                    dtgvThanhtoanKH.DataSource = new Entities.PhieuTTCuaKH[0];
                    return;
                }
                dtgvThanhtoanKH.DataSource = hienthi;
                dtgvThanhtoanKH.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                dtgvThanhtoanKH.DataSource = new Entities.PhieuTTCuaKH[0];
                tsslxoa.Enabled = false;
            }
            finally
            {
                fix();
            }
        }
        public void fix()
        {
            for (int j = 1; j < dtgvThanhtoanKH.ColumnCount; j++)
            {
                dtgvThanhtoanKH.Columns[j].Visible = false;
            }
            Common.Utilities a = new Common.Utilities();
            a.CountDatagridview(dtgvThanhtoanKH);
            dtgvThanhtoanKH.ReadOnly = true;
            dtgvThanhtoanKH.Columns[0].Visible = true;
            dtgvThanhtoanKH.Columns[0].HeaderText = "STT";
            dtgvThanhtoanKH.Columns["MaPhieuTTCuaKH"].Visible = true;
            dtgvThanhtoanKH.Columns["MaPhieuTTCuaKH"].HeaderText = "Mã Phiếu Thanh Toán";
            dtgvThanhtoanKH.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";
            dtgvThanhtoanKH.Columns["TenKhachHang"].Visible = true;
            dtgvThanhtoanKH.Columns["NgayLap"].HeaderText = "Ngày Lập Phiếu";
            dtgvThanhtoanKH.Columns["NgayLap"].Visible = true;
            dtgvThanhtoanKH.Columns["NoHienThoi"].HeaderText = "Nợ Hiện Thời";
            dtgvThanhtoanKH.Columns["NoHienThoi"].Visible = true;
            dtgvThanhtoanKH.Columns["GhiChu"].Visible = true;
            dtgvThanhtoanKH.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dtgvThanhtoanKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvThanhtoanKH.AllowUserToAddRows = false;
            dtgvThanhtoanKH.AllowUserToDeleteRows = false;
            dtgvThanhtoanKH.AllowUserToResizeRows = false;
            dtgvThanhtoanKH.RowHeadersVisible = false;
            this.Focus();
        }
        int i;

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslxoa_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn muốn Xóa không?", "Hệ Thống Cảnh Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        bool ktdelete = false;
                        int idcurent = int.Parse(dtgvThanhtoanKH.Rows[i].Cells["PhieuTTCuaKHID"].Value.ToString());
                        SelectData();
                        for (int j = 0; j < pttckh1.Length; j++)
                        {
                            if (pttckh1[j].Deleted == false)
                                if (pttckh1[j].PhieuTTCuaKHID == idcurent)
                                {
                                    ktdelete = true;
                                    break;
                                }

                        }
                        if (ktdelete == true)
                        {
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                            Entities.PhieuTTCuaKH pt = new Entities.PhieuTTCuaKH();
                            pt = new Entities.PhieuTTCuaKH("Delete", idcurent);

                            clientstrem = cl.SerializeObj(this.client1, "PhieuTTCuaKH", pt);
                            bool kt = false;
                            kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                            if (kt == true)
                            {
                                MessageBox.Show("Delete thanh cong");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hàng này đã bị xóa rồi");
                        }
                        SelectData();
                    }
                }
            }
            catch
            {
            }
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
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
                    dtgvThanhtoanKH.DataSource = new Entities.PhieuTTCuaKH[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtimkiem2.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaPhieuTTCuaKH.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvThanhtoanKH.DataSource = new Entities.PhieuTTCuaKH[0];
                            return;
                        }
                        Entities.PhieuTTCuaKH[] hienthitheoma = new Entities.PhieuTTCuaKH[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaPhieuTTCuaKH.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dtgvThanhtoanKH.DataSource = hienthitheoma;
                    }
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
                if (hienthi == null)
                {
                    dtgvThanhtoanKH.DataSource = new Entities.PhieuTTCuaKH[0];
                    return;
                }
                dtgvThanhtoanKH.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                fix();
            }
        }

        private void dtgvThanhtoanKH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            if (i < 0)
                return;
            try
            {
                frmXuLyPhieuTTCuaKH a = new frmXuLyPhieuTTCuaKH("Sua", dtgvThanhtoanKH.Rows[i]);
                a.ShowDialog();
                SelectData();
            }
            catch
            {
            }
        }

        private void dtgvThanhtoanKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void rdbtimkiem2_CheckedChanged(object sender, EventArgs e)
        {
            txttimkiem.Text = "";
        }

        private void tsslnaplai_Click(object sender, EventArgs e)
        {
            SelectData(); this.Focus();
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
