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
    public partial class frmQuanLyBanLe : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        DateTime datesv;
        string makho;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        public frmQuanLyBanLe()
        {
            InitializeComponent(); datesv = DateServer.Date();
            datesv = DateServer.Date();
            makho = new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen;
            if (string.IsNullOrEmpty(makho))
            {
                MessageBox.Show("Chưa cài đặt kho", "Hệ thống cảnh báo");
            }
            truoc = sau = datesv;
            SelectDate(truoc, sau);

        }
        /// <summary>
        /// xử lý đóng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatus_Dong_Click(object sender, EventArgs e)
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

        Server_Client.Client cl;
        Entities.HDBanHang[] pt1;
        Entities.HDBanHang[] hienthi;
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void fix()
        {
            for (int j = 1; j < dtgvbanle.ColumnCount; j++)
            {
                dtgvbanle.Columns[j].Visible = false;
            }

            dtgvbanle.ReadOnly = true;
            //dtgvbanle.Columns[0].Visible = true;
            //dtgvbanle.Columns[0].HeaderText = "STT";
            dtgvbanle.Columns["MaHDBanHang"].Visible = true;
            dtgvbanle.Columns["MaHDBanHang"].HeaderText = "Mã Đơn Hàng";
            dtgvbanle.Columns["NgayBan"].Visible = true;
            dtgvbanle.Columns["NgayBan"].HeaderText = "Ngày Bán";
            dtgvbanle.Columns["TenKhachHang"].Visible = true;
            dtgvbanle.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";
            dtgvbanle.Columns["TongTienThanhToan"].Visible = true;
            dtgvbanle.Columns["TongTienThanhToan"].HeaderText = "Tổng Thanh Toán";
            dtgvbanle.Columns["GhiChu"].Visible = true;
            dtgvbanle.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dtgvbanle.Columns["MaTheGiaTri"].Visible = false;
            dtgvbanle.Columns["ChietKhauTongHoaDon"].Visible = false;
            dtgvbanle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvbanle.AllowUserToAddRows = false;
            dtgvbanle.AllowUserToDeleteRows = false;
            dtgvbanle.AllowUserToResizeRows = false;
            this.Focus();
        }
        /// <summary>
        /// xử lý khi thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatus_ThemMoi_Click(object sender, EventArgs e)
        {
            if (!Common.Utilities.User.Administrator && !(new Common.Utilities().CheckQuyen(Name, 4)))
            {
                MessageBox.Show("Bạn không có quyền vào", "Hệ thống cảnh báo");
                return;
            }
            try
            {
                for (int j = 0; j < 1000; j++)
                {
                    if (frmXuLyBanLe.Trave == "")
                    {
                        frmXuLyBanLe le = new frmXuLyBanLe("Them");
                        le.ShowDialog();
                        SelectDate(truoc, sau);
                    }
                    else
                    {
                        frmXuLyBanLe.Trave = "";
                        break;
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// xử lý khi in
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatus_In_Click(object sender, EventArgs e)
        {

        }

        int i = 0;
        /// <summary>
        /// xử lý khi click đúp vào panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void palTencung_MouseDoubleClick(object sender, MouseEventArgs e)
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
                    dtgvbanle.DataSource = new Entities.HDBanHang[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtimkiem2.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaHDBanHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvbanle.DataSource = new Entities.HDBanHang[0];
                            return;
                        }
                        Entities.HDBanHang[] hienthitheoma = new Entities.HDBanHang[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaHDBanHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dtgvbanle.DataSource = hienthitheoma;
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
                    dtgvbanle.DataSource = new Entities.HDBanHang[0];
                    return;
                }
                dtgvbanle.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                fix();
            }
        }

        private void dtgvbanle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            if (i < 0)
                return;
            try
            {
                frmXuLyBanLe tmptc = new frmXuLyBanLe("Sua", dtgvbanle.Rows[i]);
                tmptc.ShowDialog();
                SelectDate(truoc, sau);
            }
            catch
            {
            }
        }

        private void dtgvbanle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void rdbtimkiem2_CheckedChanged(object sender, EventArgs e)
        {
            txttimkiem.Text = "";
        }

        private void tsslnaplai_Click(object sender, EventArgs e)
        {
            SelectDate(truoc, sau); this.Focus();
        }
        string batdau = "";
        string ketthuc = "";
        DateTime truoc;
        DateTime sau;
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                frmLocDieuKien a = new frmLocDieuKien();
                a.ShowDialog();
                if (frmLocDieuKien.truoc != "" && frmLocDieuKien.sau != "")
                {
                    this.batdau = frmLocDieuKien.truoc;
                    this.ketthuc = frmLocDieuKien.sau;
                    truoc = Convert.ToDateTime(batdau);
                    sau = Convert.ToDateTime(ketthuc);
                    SelectDate(truoc, sau);
                    frmLocDieuKien.truoc = frmLocDieuKien.sau = "";

                }
            }
            catch
            {
            }
        }

        void SelectDate(DateTime batdau, DateTime ketthuc)
        {
            try
            {
                i = 0;
                dtgvbanle.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.HDBanHang pt = new Entities.HDBanHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                pt1 = new Entities.HDBanHang[1];
                clientstrem = cl.SerializeObj(this.client1, "HDBanHang", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.HDBanHang[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 == null)
                {
                    dtgvbanle.DataSource = new Entities.HDBanHang[0];
                    return;
                }

                Entities.HDBanHang[] pt2 = new Entities.HDBanHang[pt1.Length];
                int sotang = 0;
                foreach (Entities.HDBanHang item in pt1)
                {
                    if (item.LoaiHoaDon && !item.Deleted && item.NgayBan.Date >= batdau.Date && item.NgayBan.Date <= ketthuc.Date && item.MaKho == makho)
                    {
                        pt2[sotang] = item;
                        sotang++;
                    }
                }
                hienthi = new Entities.HDBanHang[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pt2[j];
                        hienthi[j].TongTienThanhToan = new Common.Utilities().FormatMoney(double.Parse(hienthi[j].TongTienThanhToan));
                    }
                }
                else
                {
                    dtgvbanle.DataSource = new Entities.HDBanHang[0];
                    return;
                }

                dtgvbanle.DataSource = hienthi;
                //new Common.Utilities().CountDatagridview(dtgvbanle);
                dtgvbanle.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được với server - thử lại sau");
                dtgvbanle.DataSource = new Entities.HDBanHang[0];
            }
            finally
            {
                fix();
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
