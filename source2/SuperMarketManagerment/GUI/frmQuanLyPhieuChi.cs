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
    public partial class frmQuanLyPhieuChi : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        public frmQuanLyPhieuChi()
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
                if (frmQuanLyPhieuThu.trave == "")
                {
                    frmXuLyPhieuThuChi tmptc = new frmXuLyPhieuThuChi("Chi", "Them");
                    tmptc.ShowDialog();
                    SelectData();
                }
                else
                {
                    frmQuanLyPhieuThu.trave = "";
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
        ///  đóng form
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
            frmXuLyPhieuThuChi tmptc = new frmXuLyPhieuThuChi("Thu", "Sua", dtgvChitien.Rows[i]);
            tmptc.ShowDialog();
            SelectData();
        }

        private void frmChitien_Load(object sender, EventArgs e)
        {
            SelectData();
        }
        Server_Client.Client cl;
        Entities.PhieuThu[] pt1;
        Entities.PhieuThu[] hienthi;
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData()
        {
            try
            {
                i = 0;
                dtgvChitien.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.PhieuThu pt = new Entities.PhieuThu("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                pt1 = new Entities.PhieuThu[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuThu", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.PhieuThu[])cl.DeserializeHepper1(clientstrem, pt1);

                if (pt1 == null)
                {
                    tsslxoa.Enabled = false;
                    tsslsua.Enabled = false;
                    dtgvChitien.DataSource = new Entities.PhieuThu[0];
                    return;
                }

                Entities.PhieuThu[] pt2 = new Entities.PhieuThu[pt1.Length];
                int sotang = 0;
                for (int j = 0; j < pt1.Length; j++)
                {
                    if (pt1[j].LoaiPhieu == "Chi")
                    {
                        if (pt1[j].Deleted == false)
                        {
                            pt2[sotang] = pt1[j];
                            sotang++;
                        }
                    }
                }
                hienthi = new Entities.PhieuThu[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pt2[j];
                    }
                }
                else
                {
                    dtgvChitien.DataSource = new Entities.PhieuThu[0];
                    tsslxoa.Enabled = tsslsua.Enabled = false;
                    return;
                }
                tsslxoa.Enabled = true;
                tsslsua.Enabled = true;
                dtgvChitien.DataSource = hienthi;
                dtgvChitien.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                dtgvChitien.DataSource = new Entities.PhieuThu[0];
                tsslxoa.Enabled = tsslsua.Enabled = false;
            }
            finally
            {
                fix();
            }
        }

        public void fix()
        {
            for (int j = 1; j < dtgvChitien.ColumnCount; j++)
            {
                dtgvChitien.Columns[j].Visible = false;
            }
            Common.Utilities a = new Common.Utilities();
            a.CountDatagridview(dtgvChitien);
            dtgvChitien.ReadOnly = true;
            dtgvChitien.Columns[0].Visible = true;
            dtgvChitien.Columns[0].HeaderText = "STT";
            dtgvChitien.Columns["MaPhieuThu"].Visible = true;
            dtgvChitien.Columns["MaPhieuThu"].HeaderText = "Mã Phiếu Chi";
            dtgvChitien.Columns["NgayLap"].Visible = true;
            dtgvChitien.Columns["NgayLap"].HeaderText = "Ngày Lập Phiếu";
            dtgvChitien.Columns["NguoiNopTien"].Visible = true;
            dtgvChitien.Columns["NguoiNopTien"].HeaderText = "Người Nộp Tiền";
            dtgvChitien.Columns["NguoiNhanTien"].Visible = true;
            dtgvChitien.Columns["NguoiNhanTien"].HeaderText = "Người Nhận Tiền";
            dtgvChitien.Columns["TongTienThanhToan"].Visible = true;
            dtgvChitien.Columns["TongTienThanhToan"].HeaderText = "Tổng Thanh Toán";
            dtgvChitien.Columns["GhiChu"].Visible = true;
            dtgvChitien.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dtgvChitien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvChitien.AllowUserToAddRows = false;
            dtgvChitien.AllowUserToDeleteRows = false;
            dtgvChitien.AllowUserToResizeRows = false;
            this.Focus();
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
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn muốn Xóa không?", "Hệ Thống Cảnh Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        bool ktdelete = false;
                        int idcurent = int.Parse(dtgvChitien.Rows[i].Cells[1].Value.ToString());
                        SelectData();
                        for (int j = 0; j < pt1.Length; j++)
                        {
                            if (pt1[j].Deleted == false)
                                if (pt1[j].PhieuThuID == idcurent)
                                {
                                    ktdelete = true;
                                    break;
                                }
                        }
                        if (ktdelete == true)
                        {
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                            Entities.PhieuThu pt = new Entities.PhieuThu();
                            pt = new Entities.PhieuThu("Delete", int.Parse(dtgvChitien.Rows[i].Cells[1].Value.ToString()));
                            clientstrem = cl.SerializeObj(this.client1, "PhieuThu", pt);
                            bool kt = false;
                            kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                            if (kt == true)
                            {
                            }
                            else
                                MessageBox.Show("Thất bại - xin hãy kiểm tra lại", "Hệ thống cảnh báo");
                        }
                        else
                            MessageBox.Show("Hàng này đã bị xóa");
                        SelectData();
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// xử lý khi cliick đúp vào ô
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
                    dtgvChitien.DataSource = new Entities.PhieuThu[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtimkiem2.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaPhieuThu.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvChitien.DataSource = new Entities.PhieuThu[0];
                            return;
                        }
                        Entities.PhieuThu[] hienthitheoma = new Entities.PhieuThu[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaPhieuThu.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dtgvChitien.DataSource = hienthitheoma;
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
                    dtgvChitien.DataSource = new Entities.PhieuThu[0];
                    return;
                }
                dtgvChitien.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                fix();
            }
        }

        private void dtgvChitien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            if (i < 0)
                return;
            try
            {
                frmXuLyPhieuThuChi tmptc = new frmXuLyPhieuThuChi("Chi", "Sua", dtgvChitien.Rows[i]);
                tmptc.ShowDialog();
                SelectData();
            }
            catch
            {

            }
        }

        private void dtgvChitien_CellClick(object sender, DataGridViewCellEventArgs e)
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
