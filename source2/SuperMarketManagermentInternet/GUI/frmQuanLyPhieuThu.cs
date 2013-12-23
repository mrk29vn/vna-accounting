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

    public partial class frmQuanLyPhieuThu : Form
    {
        public static string trave;
        public TcpClient client1;
        public NetworkStream clientstrem;
        BizLogic.PhieuThu pt;
        /// <summary>
        /// xử lý gía trị truyền tới
        /// </summary>
        public frmQuanLyPhieuThu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// xử lý thêm mới
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
                    if (trave == "")
                    {
                        frmXuLyPhieuThuChi tmptc = new frmXuLyPhieuThuChi("Thu", "Them");
                        tmptc.ShowDialog();
                        SelectData();
                    }
                    else
                    {
                        trave = "";
                        break;
                    }
                }
            }
            catch
            {
            }

        }
        /// <summary>
        /// xử lý lọc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslloc_Click(object sender, EventArgs e)
        {

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
        /// <summary>
        /// xử lý khi sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslsua_Click(object sender, EventArgs e)
        {
            try
            {
                frmXuLyPhieuThuChi tmptc = new frmXuLyPhieuThuChi("Thu", "Sua", dtgvThutien.Rows[i]);
                tmptc.ShowDialog();
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
        private void frmThutien_Load(object sender, EventArgs e)
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
                dtgvThutien.RowHeadersVisible = false;
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
                    dtgvThutien.DataSource = new Entities.PhieuThu[0];
                    return;
                }
                tsslxoa.Enabled = true;
                tsslsua.Enabled = true;

                Entities.PhieuThu[] pt2 = new Entities.PhieuThu[pt1.Length];
                int sotang = 0;
                for (int j = 0; j < pt1.Length; j++)
                {
                    if (pt1[j].Deleted == false)
                    {
                        if (pt1[j].LoaiPhieu == "Thu")
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
                    dtgvThutien.DataSource = new Entities.PhieuThu[0];
                    tsslxoa.Enabled = false;
                    tsslsua.Enabled = false;
                    return;
                }
                dtgvThutien.DataSource = hienthi;
                new Common.Utilities().CountDatagridview(dtgvThutien);

                dtgvThutien.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                
                dtgvThutien.DataSource = new Entities.PhieuThu[0];
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
            for (int j = 1; j < dtgvThutien.ColumnCount; j++)
            {
                dtgvThutien.Columns[j].Visible = false;
            }
            dtgvThutien.ReadOnly = true;
            dtgvThutien.Columns[0].Visible = true;
            dtgvThutien.Columns[0].HeaderText = "STT";
            dtgvThutien.Columns["MaPhieuThu"].Visible = true;
            dtgvThutien.Columns["MaPhieuThu"].HeaderText = "Mã Phiếu Thu";
            dtgvThutien.Columns["NgayLap"].Visible = true;
            dtgvThutien.Columns["NgayLap"].HeaderText = "Ngày Lập Phiếu";
            dtgvThutien.Columns["NguoiNopTien"].Visible = true;
            dtgvThutien.Columns["NguoiNopTien"].HeaderText = "Người Nộp Tiền";
            dtgvThutien.Columns["NguoiNhanTien"].Visible = true;
            dtgvThutien.Columns["NguoiNhanTien"].HeaderText = "Người Nhận Tiền";
            dtgvThutien.Columns["TongTienThanhToan"].Visible = true;
            dtgvThutien.Columns["TongTienThanhToan"].HeaderText = "Tổng Thanh Toán";
            dtgvThutien.Columns["GhiChu"].Visible = true;
            dtgvThutien.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dtgvThutien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvThutien.AllowUserToAddRows = false;
            dtgvThutien.AllowUserToDeleteRows = false;
            dtgvThutien.AllowUserToResizeRows = false;
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
                        int idcurent = int.Parse(dtgvThutien.Rows[i].Cells[1].Value.ToString());
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
                            pt = new Entities.PhieuThu("Delete", idcurent);
                            clientstrem = cl.SerializeObj(this.client1, "PhieuThu", pt);
                            bool kt = false;
                            kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                            if (kt == true)
                            {
 
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hàng này đã bị xóa");
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
        /// xử lý khi click đúp vào ô
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
        /// xử lý khi tìm kiêm
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
                    dtgvThutien.DataSource = new Entities.PhieuThu[0];
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
                            dtgvThutien.DataSource = new Entities.PhieuThu[0];
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
                        dtgvThutien.DataSource = hienthitheoma;
                    }
                    new Common.Utilities().CountDatagridview(dtgvThutien);
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
                    dtgvThutien.DataSource = new Entities.PhieuThu[0];
                    return;
                }
                dtgvThutien.DataSource = hienthi;
            }
            finally
            {
                fix();  
            }
        }
        private void dtgvThutien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            try
            {
                if (i < 0)
                    return;
                frmXuLyPhieuThuChi tmptc = new frmXuLyPhieuThuChi("Thu", "Sua", dtgvThutien.Rows[i]);
                tmptc.ShowDialog();
                SelectData();
            }
            catch { }
        }

        private void dtgvThutien_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void dtgvThutien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
