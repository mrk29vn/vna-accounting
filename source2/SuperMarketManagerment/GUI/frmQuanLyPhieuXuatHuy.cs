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
    public partial class frmQuanLyPhieuXuatHuy : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        public frmQuanLyPhieuXuatHuy()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmQuanLyPhieuXuatHuy_Load(object sender, EventArgs e)
        {
            SelectData();
        }
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslblthemmoi_Click(object sender, EventArgs e)
        {
            if (!Common.Utilities.User.Administrator && !(new Common.Utilities().CheckQuyen(this.Name, 4)))
            {
                MessageBox.Show("Bạn không có quyền vào", "Hệ thống cảnh báo");
                return;
            }
            for (int j = 0; j < 1000; j++)
            {
                if (frmXuLyPhieuXuatHuy.trave == "")
                {
                    frmXuLyPhieuXuatHuy xhhh = new frmXuLyPhieuXuatHuy("Them");
                    xhhh.ShowDialog();
                    SelectData();
                }
                else
                {
                    frmXuLyPhieuXuatHuy.trave = "";
                    break;
                }
            }

        }

        /// <summary>
        /// đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslbldong_Click(object sender, EventArgs e)
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
        /// lọc dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslblloc_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// sửa dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslblsua_Click(object sender, EventArgs e)
        {
            try
            {
                frmXuLyPhieuXuatHuy tmptc = new frmXuLyPhieuXuatHuy("Sua", dtgvxuathuyhanghoa.Rows[i]);
                tmptc.ShowDialog();
                SelectData();
            }
            catch
            {
            }
        }

        Entities.PhieuXuatHuy[] pxh1;
        Entities.PhieuXuatHuy[] hienthi;
        Server_Client.Client cl;
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData()
        {
            try
            {
                
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.PhieuXuatHuy pxh = new Entities.PhieuXuatHuy("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                pxh1 = new Entities.PhieuXuatHuy[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuXuatHuy", pxh);
                // đổ mảng đối tượng vào datagripview       
                pxh1 = (Entities.PhieuXuatHuy[])cl.DeserializeHepper1(clientstrem, pxh1);
                if (pxh1 == null)
                {
                    hienthi = new Entities.PhieuXuatHuy[0];
                    tsslxoa.Enabled = false;
                    tsslsua.Enabled = false;
                    dtgvxuathuyhanghoa.DataSource = new Entities.PhieuXuatHuy[0];
                    return;
                }
                tsslxoa.Enabled = true;
                tsslsua.Enabled = true;

                Entities.PhieuXuatHuy[] pxh2 = new Entities.PhieuXuatHuy[pxh1.Length];
                int sotang = 0;
                for (int j = 0; j < pxh1.Length; j++)
                {
                    if (pxh1[j].Deleted == false)
                    {
                        pxh2[sotang] = pxh1[j];
                        sotang++;
                    }
                }

                hienthi = new Entities.PhieuXuatHuy[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pxh2[j];
                    }
                }
                else
                {
                    hienthi = new Entities.PhieuXuatHuy[0];
                    dtgvxuathuyhanghoa.DataSource = new Entities.PhieuXuatHuy[0];
                    tsslxoa.Enabled = false;
                    tsslsua.Enabled = false;
                    return;
                }

                foreach (Entities.PhieuXuatHuy item in hienthi)
                {
                    item.Tongtien = new TienIch().FormatMoney(item.Tongtien.Replace(",", ""));
                }
                dtgvxuathuyhanghoa.DataSource = hienthi;
                new Common.Utilities().CountDatagridview(dtgvxuathuyhanghoa);
                dtgvxuathuyhanghoa.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                dtgvxuathuyhanghoa.DataSource = new Entities.PhieuXuatHuy[0];
                tsslxoa.Enabled = false;
                tsslsua.Enabled = false;
            }
            finally
            {
                fix();
            }
        }
        public void fix()
        {
            dtgvxuathuyhanghoa.RowHeadersVisible = false;
            for (int j = 1; j < dtgvxuathuyhanghoa.ColumnCount; j++)
            {
                dtgvxuathuyhanghoa.Columns[j].Visible = false;
            }
            dtgvxuathuyhanghoa.ReadOnly = true;
            dtgvxuathuyhanghoa.Columns["HanhDong"].Visible = true;
            dtgvxuathuyhanghoa.Columns["HanhDong"].HeaderText = "STT";
            dtgvxuathuyhanghoa.Columns["MaPhieuXuatHuy"].Visible = true;
            dtgvxuathuyhanghoa.Columns["MaPhieuXuatHuy"].HeaderText = "Mã Phiếu Xuất Hủy";
            dtgvxuathuyhanghoa.Columns["NgayLap"].Visible = true;
            dtgvxuathuyhanghoa.Columns["NgayLap"].HeaderText = "Ngày Lập";
            dtgvxuathuyhanghoa.Columns["TenNhanVien"].Visible = true;
            dtgvxuathuyhanghoa.Columns["TenNhanVien"].HeaderText = "Tên Nhân Viên";
            dtgvxuathuyhanghoa.Columns["Tongtien"].Visible = true;
            dtgvxuathuyhanghoa.Columns["Tongtien"].HeaderText = "Tổng Tiền";
            dtgvxuathuyhanghoa.Columns["GhiChu"].Visible = true;
            dtgvxuathuyhanghoa.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dtgvxuathuyhanghoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvxuathuyhanghoa.AllowUserToAddRows = false;
            dtgvxuathuyhanghoa.AllowUserToDeleteRows = false;
            dtgvxuathuyhanghoa.AllowUserToResizeRows = false;
            this.Focus();
        }
        /// <summary>
        /// xử lý khi đóng
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
                {
                }
            }
        }
        int i;
        /// <summary>
        /// xử lý khi xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslxoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgvxuathuyhanghoa.Rows[i].Cells["TrangThai"].Value.ToString().Equals("True"))
                {
                    MessageBox.Show("Bạn không thể xóa Phiếu xuất hủy đã xác nhận này", "Hệ thống cảnh báo");
                    return;
                }
                if (dtgvxuathuyhanghoa.RowCount == 0 || i <0)
                {
                    return;
                }
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn muốn Xóa không?", "Hệ Thống Cảnh Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {                        
                        bool ktdelete = false;
                        int idcurent = int.Parse(dtgvxuathuyhanghoa.Rows[i].Cells[1].Value.ToString());
                        SelectData();
                        for (int j = 0; j < pxh1.Length; j++)
                        {
                            if (pxh1[j].Deleted == false)
                                if (pxh1[j].PhieuXuatHuyID == idcurent)
                                {
                                    ktdelete = true;
                                    break;
                                }
                        }
                        if (ktdelete == true)
                        {
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                            Entities.PhieuXuatHuy pt = new Entities.PhieuXuatHuy();
                            pt = new Entities.PhieuXuatHuy("Delete", idcurent);
                            clientstrem = cl.SerializeObj(this.client1, "PhieuXuatHuy", pt);
                            bool kt = false;
                            kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                            if (kt == true)
                            {

                            }
                        }
                        else
                        {
                            MessageBox.Show("Hàng này đã bị xóa trước đó");
                        }
                        SelectData();
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// xử lý khi click đúp
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
                    dtgvxuathuyhanghoa.DataSource = new Entities.PhieuXuatHuy[0];
                    return;
                }
                int soluong = 0;
                if (rdbtimkiem2.Checked == true)
                {
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaPhieuXuatHuy.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            soluong++;
                        }
                    }
                    if (soluong == 0)
                    {
                        dtgvxuathuyhanghoa.DataSource = new Entities.PhieuXuatHuy[0];
                        return;
                    }
                    Entities.PhieuXuatHuy[] hienthitheoma = new Entities.PhieuXuatHuy[soluong];
                    soluong = 0;
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaPhieuXuatHuy.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            hienthitheoma[soluong] = hienthi[i];
                            soluong++;
                        }
                    }
                    dtgvxuathuyhanghoa.DataSource = hienthitheoma;
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
                    dtgvxuathuyhanghoa.DataSource = new Entities.PhieuXuatHuy[0];
                    return;
                }
                dtgvxuathuyhanghoa.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                fix();

            }
        }

        private void dtgvxuathuyhanghoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            try
            {
                if (i < 0)
                    return;
                frmXuLyPhieuXuatHuy tmptc = new frmXuLyPhieuXuatHuy("Sua", dtgvxuathuyhanghoa.Rows[i]);
                tmptc.ShowDialog();
                SelectData();
            }
            catch
            {
            }
        }

        private void dtgvxuathuyhanghoa_CellClick(object sender, DataGridViewCellEventArgs e)
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
