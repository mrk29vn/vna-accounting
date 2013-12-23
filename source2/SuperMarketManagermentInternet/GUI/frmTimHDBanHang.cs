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
    public partial class frmTimHDBanHang : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        string str1;
        public static DataGridViewRow drvr = null;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        /// <param name="str"></param>
        /// <param name="str2"></param>
        public frmTimHDBanHang(string str, string str2)
        {
            InitializeComponent();
            this.str1 = str;
            if (str2 == "")
                SelectData();
            else
                SelectData1();
        }
        Entities.HDBanHang[] hienthi;
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData()
        {
            try
            {
                dtgvKH.RowHeadersVisible = false;
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.HDBanHang kh = new Entities.HDBanHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.HDBanHang[] kh1 = new Entities.HDBanHang[1];
                clientstrem = cl.SerializeObj(this.client1, "HDBanHang", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.HDBanHang[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 == null)
                {
                    hienthi = new Entities.HDBanHang[0];
                    dtgvKH.DataSource = new Entities.HDBanHang[0];
                    return;
                }
                Entities.HDBanHang[] kh2 = new Entities.HDBanHang[kh1.Length];
                int sotang = 0;
                for (int j = 0; j < kh1.Length; j++)
                {
                    if (kh1[j].MaKhachHang == str1 && kh1[j].Deleted == false && kh1[j].LoaiHoaDon == false && !kh1[j].TongTienThanhToan.Equals(kh1[j].ThanhToanNgay) && !kh1[j].TongTienThanhToan.Equals(kh1[j].ThanhToanKhiLapPhieu))
                    {
                        kh2[sotang] = kh1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.HDBanHang[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = kh2[j];
                    }
                }
                else
                {
                    hienthi = new Entities.HDBanHang[0];
                    dtgvKH.DataSource = new Entities.HDBanHang[0];
                    return;
                }
                dtgvKH.DataSource = hienthi;
                dtgvKH.Rows[0].Selected = true;
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
            for (int i = 1; i < dtgvKH.ColumnCount; i++)
            {
                dtgvKH.Columns[i].Visible = false;
            }
            dtgvKH.ReadOnly = true; dtgvKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            new Common.Utilities().CountDatagridview(dtgvKH);
            dtgvKH.Columns[0].Visible = true;
            dtgvKH.Columns[0].HeaderText = "STT";
            dtgvKH.Columns["HDBanHangID"].Visible = true;
            dtgvKH.Columns["HDBanHangID"].HeaderText = "Hóa Đơn ID";
            dtgvKH.Columns["MaHDBanHang"].Visible = true;
            dtgvKH.Columns["MaHDBanHang"].HeaderText = "Mã Hóa Đơn";
            dtgvKH.Columns["MaKhachHang"].Visible = true;
            dtgvKH.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
            dtgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvKH.AllowUserToAddRows = false;
            dtgvKH.AllowUserToDeleteRows = false;
            dtgvKH.AllowUserToResizeRows = false;
            dtgvKH.RowHeadersVisible = false;
        }
        /// <summary>
        /// select từ server
        /// </summary>
        public void SelectData1()
        {
            try
            {
                dtgvKH.RowHeadersVisible = false;
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.HDBanHang kh = new Entities.HDBanHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.HDBanHang[] kh1 = new Entities.HDBanHang[1];
                clientstrem = cl.SerializeObj(this.client1, "HDBanHang", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.HDBanHang[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 == null)
                {
                    dtgvKH.DataSource = new Entities.HDBanHang[0];
                    return;
                }
                Entities.HDBanHang[] kh2 = new Entities.HDBanHang[kh1.Length];
                int sotang = 0;
                for (int j = 0; j < kh1.Length; j++)
                {
                    if (kh1[j].MaKhachHang == str1)
                    {
                        if (kh1[j].Deleted == false && kh1[j].LoaiHoaDon == false)
                        {
                            double ttn = Convert.ToDouble(kh1[j].ThanhToanNgay);
                            double ttnklp = Convert.ToDouble(kh1[j].ThanhToanKhiLapPhieu);
                            double tt = Convert.ToDouble(kh1[j].TongTienThanhToan);
                            if ((ttn + ttnklp) != tt)
                            {
                                kh2[sotang] = kh1[j];
                                sotang++;
                            }
                        }
                    }
                }
                hienthi = new Entities.HDBanHang[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = kh2[j];
                    }
                }
                else
                {
                    dtgvKH.DataSource = new Entities.HDBanHang[0];
                    return;
                }
                dtgvKH.DataSource = hienthi;
                dtgvKH.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {

                fix();
            }
        }
        /// <summary>
        /// xử lý nút hủy bỏ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatus_Huybo_Click(object sender, EventArgs e)
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
        /// xử lý khi click vào button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btntim_Click(object sender, EventArgs e)
        {
            //if (KiemTra() == true)
            //{
            //    try
            //    {
            //        string Kieu = "";
            //        string Cot = "";
            //        if (rdbkieutim1.Checked == true)
            //            Kieu = "=";
            //        else if (rdbkieutim2.Checked == true)
            //            Kieu = "like";
            //        if (cbbcottim.SelectedIndex == 0)
            //            Cot = "HDBanHangID";
            //        else if (cbbcottim.SelectedIndex == 1)
            //            Cot = "MaHDBanHang";
            //        dtgvKH.RowHeadersVisible = false;
            //        Server_Client.Client cl = new Server_Client.Client();
            //        // gán TCPclient
            //        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            //        // khởi tạo biến truyền vào với hàm khởi tạo
            //        Entities.HDBanHang kh = new Entities.HDBanHang("Search", Cot, txtgiatritim.Text, Kieu, str1);
            //        // khởi tạo mảng đối tượng để hứng giá trị
            //        Entities.HDBanHang[] kh1 = new Entities.HDBanHang[1];
            //        clientstrem = cl.SerializeObj(this.client1, "HDBanHang", kh);
            //        // đổ mảng đối tượng vào datagripview       
            //        kh1 = (Entities.HDBanHang[])cl.DeserializeHepper1(clientstrem, kh1);
            //        if (kh1 == null)
            //        {
            //            dtgvKH.DataSource = null;
            //            dtgvKH.Rows.Clear();
            //            return;
            //        }
            //        dtgvKH.DataSource = kh1;
            //        for (int i = 0; i < dtgvKH.ColumnCount; i++)
            //        {
            //            dtgvKH.Columns[i].Visible = false;
            //        }
            //        dtgvKH.Columns["HDBanHangID"].Visible = true;
            //        dtgvKH.Columns["HDBanHangID"].HeaderText = "Hóa Đơn ID";
            //        dtgvKH.Columns["MaHDBanHang"].Visible = true;
            //        dtgvKH.Columns["MaHDBanHang"].HeaderText = "Mã Hóa Đơn";
            //        dtgvKH.Columns["MaKhachHang"].Visible = true;
            //        dtgvKH.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
            //        dtgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //        dtgvKH.AllowUserToAddRows = false;
            //        dtgvKH.AllowUserToDeleteRows = false;
            //        dtgvKH.AllowUserToResizeRows = false;
            //        dtgvKH.RowHeadersVisible = false;
            //        dtgvKH.Rows[0].Selected = true;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Không kết nối được với server - thử lại sau");
            //    }
            //}
            //str1 = "";
        }
        int i;
        /// <summary>
        /// xử lý khi chấp nhận
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
            try
            {
                drvr = dtgvKH.Rows[i];
                this.Close();
            }
            catch
            {
            }
        }
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
        /// xử lý khi click đúp vào ô
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgvKH_DoubleClick(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// xử lý khi thay đổi kích thước
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTimHDBanHang_Resize(object sender, EventArgs e)
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
                    dtgvKH.DataSource = new Entities.HDBanHang[0];
                    return;
                }
                int soluong = 0;
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
                        dtgvKH.DataSource = new Entities.HDBanHang[0];
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

        private void rdbtimkiem2_CheckedChanged(object sender, EventArgs e)
        {
            txttimkiem.Text = "";
        }

        private void dtgvKH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                drvr = dtgvKH.Rows[i];
                this.Close();
            }
            catch
            {
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
