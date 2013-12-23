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
    public partial class frmQuanLyPhieuThanhToanNCC : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        public frmQuanLyPhieuThanhToanNCC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// lọc dữ liệu
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
            frmXuLyPhieuTTNCC tmpttkh = new frmXuLyPhieuTTNCC("Sua", dtgvThanhtoanNCC.Rows[i]);
            tmpttkh.ShowDialog();
            SelectData();
        }

        /// <summary>
        /// thêm mới
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
            try
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (frmQuanLyPhieuThu.trave == "")
                    {
                        frmXuLyPhieuTTNCC a = new frmXuLyPhieuTTNCC("Them");
                        a.ShowDialog();
                        SelectData();
                    }
                    else
                    {
                        frmQuanLyPhieuThu.trave = "";
                        break;
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// method load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmThanhtoanvoiNCC_Load(object sender, EventArgs e)
        {
            SelectData();
        }
        Server_Client.Client cl;
        Entities.PhieuTTNCC[] pttncc1;
        Entities.PhieuTTNCC[] hienthi;
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData()
        {
            try
            {
                dtgvThanhtoanNCC.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.PhieuTTNCC pttncc = new Entities.PhieuTTNCC();
                // truyền HanhDong
                pttncc = new Entities.PhieuTTNCC("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                pttncc1 = new Entities.PhieuTTNCC[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuTTNCC", pttncc);
                // đổ mảng đối tượng vào datagripview  

                pttncc1 = (Entities.PhieuTTNCC[])cl.DeserializeHepper1(clientstrem, pttncc1);
                if (pttncc1 == null)
                {
                    tsslxoa.Enabled = false;
                    dtgvThanhtoanNCC.DataSource = new Entities.PhieuTTNCC[0];
                    return;
                }
                tsslxoa.Enabled = true;

                Entities.PhieuTTNCC[] pttncc2 = new Entities.PhieuTTNCC[pttncc1.Length];
                int sotang = 0;
                for (int j = 0; j < pttncc1.Length; j++)
                {
                    if (pttncc1[j].Deleted == false)
                    {
                        pttncc2[sotang] = pttncc1[j];
                        sotang++;
                    }
                }

                hienthi = new Entities.PhieuTTNCC[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pttncc2[j];
                    }
                }
                else
                {
                    dtgvThanhtoanNCC.DataSource = new Entities.PhieuTTNCC[0];
                    return;
                }

                dtgvThanhtoanNCC.DataSource = hienthi;
                dtgvThanhtoanNCC.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                dtgvThanhtoanNCC.DataSource = new Entities.PhieuTTNCC[0];
            }
            finally
            {
                fix();
            }
        }
        public void fix()
        {

            for (int j = 1; j < dtgvThanhtoanNCC.ColumnCount; j++)
            {
                dtgvThanhtoanNCC.Columns[j].Visible = false;
            }
            Common.Utilities a = new Common.Utilities();
            a.CountDatagridview(dtgvThanhtoanNCC);
            dtgvThanhtoanNCC.ReadOnly = true;
            dtgvThanhtoanNCC.Columns["HanhDong"].Visible = true;
            dtgvThanhtoanNCC.Columns["HanhDong"].HeaderText = "STT";
            dtgvThanhtoanNCC.Columns["MaPhieuTTNCC"].Visible = true;
            dtgvThanhtoanNCC.Columns["MaPhieuTTNCC"].HeaderText = "Mã Phiếu Thanh Toán";
            dtgvThanhtoanNCC.Columns["TenNhaCungCap"].HeaderText = "Tên Nhà Cung Cấp";
            dtgvThanhtoanNCC.Columns["TenNhaCungCap"].Visible = true;
            dtgvThanhtoanNCC.Columns["NgayLap"].HeaderText = "Ngày Lập";
            dtgvThanhtoanNCC.Columns["NgayLap"].Visible = true;
            dtgvThanhtoanNCC.Columns["NoHienThoi"].HeaderText = "Nợ Hiện Thời";
            dtgvThanhtoanNCC.Columns["NoHienThoi"].Visible = true;
            dtgvThanhtoanNCC.Columns["GhiChu"].Visible = true;
            dtgvThanhtoanNCC.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dtgvThanhtoanNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvThanhtoanNCC.AllowUserToAddRows = false;
            dtgvThanhtoanNCC.AllowUserToDeleteRows = false;
            dtgvThanhtoanNCC.AllowUserToResizeRows = false;
            this.Focus();
        }
        int i;
        /// <summary>
        /// click đúp khi xóa
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
                        int idcurent = int.Parse(dtgvThanhtoanNCC.Rows[i].Cells["PhieuTTNCCID"].Value.ToString());
                        SelectData();
                        for (int j = 0; j < pttncc1.Length; j++)
                        {
                            if (pttncc1[j].Deleted == false)
                                if (pttncc1[j].PhieuTTNCCID == idcurent)
                                {
                                    ktdelete = true;
                                    break;
                                }
                        }
                        if (ktdelete == true)
                        {
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                            Entities.PhieuTTNCC pt = new Entities.PhieuTTNCC();
                            pt = new Entities.PhieuTTNCC("Delete", idcurent);

                            clientstrem = cl.SerializeObj(this.client1, "PhieuTTNCC", pt);
                            bool kt = false;
                            kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                            if (kt == true)
                            {

                            }
                            else
                                MessageBox.Show("Xóa thất bại - xin kiểm tra lại", "Hệ thống cảnh báo");
                        }
                        else
                            MessageBox.Show("Hàng này đã bị xóa trước đó rồi?","Hệ thống cảnh báo");
                        SelectData();
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// xử lý click đúp vào ô
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    dtgvThanhtoanNCC.DataSource = new Entities.PhieuTTNCC[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtimkiem2.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaPhieuTTNCC.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvThanhtoanNCC.DataSource = new Entities.PhieuTTNCC[0];
                            return;
                        }
                        Entities.PhieuTTNCC[] hienthitheoma = new Entities.PhieuTTNCC[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaPhieuTTNCC.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dtgvThanhtoanNCC.DataSource = hienthitheoma;
                    }
                    Common.Utilities a = new Common.Utilities();
                    a.CountDatagridview(dtgvThanhtoanNCC);
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
                    dtgvThanhtoanNCC.DataSource = new Entities.PhieuTTNCC[0];
                    return;
                }
                dtgvThanhtoanNCC.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                fix();
            }
        }

        private void dtgvThanhtoanNCC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            if (i < 0)
                return;
            try
            {
                frmXuLyPhieuTTNCC a = new frmXuLyPhieuTTNCC("Sua", dtgvThanhtoanNCC.Rows[i]);
                a.ShowDialog();
                SelectData();
            }
            catch
            {
            }
        }

        private void dtgvThanhtoanNCC_CellClick(object sender, DataGridViewCellEventArgs e)
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
