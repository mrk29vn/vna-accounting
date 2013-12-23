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
    public partial class frmSoDuSoQuy : Form
    {
        DateTime datesv;
        string ma = "";
        string year;
        string month;
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        public frmSoDuSoQuy()
        {
            try
            {
                InitializeComponent();datesv = DateServer.Date();
                cbbnam.Text = datesv.Year.ToString();
                cbbthang.Text = datesv.Month.ToString();
                SelectData();
            }
            catch
            {
            }
        }
        Entities.SoDuSoQuy[] hienthi;
        string id = "";
        /// <summary>
        /// select dữ liệu
        /// </summary>
        public void SelectData()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.SoDuSoQuy pt = new Entities.SoDuSoQuy("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                clientstrem = cl.SerializeObj(this.client1, "SoQuy", pt);
                // đổ mảng đối tượng vào datagripview       
                hienthi = (Entities.SoDuSoQuy[])cl.DeserializeHepper1(clientstrem, hienthi);
                if (hienthi == null)
                {
                    dtgvsoquy.DataSource = new Entities.SoDuSoQuy[0];
                    lbtrangthai.Text = "Kỳ này chưa đóng";
                    lbtrangthai.ForeColor = Color.Black;
                    toolStrip1.Enabled = dtgvsoquy.Enabled = true;
                    return;
                }
                year = cbbnam.Text;
                month = cbbthang.Text;
                int sotang = 0;
                Entities.SoDuSoQuy[] sq = new Entities.SoDuSoQuy[hienthi.Length];
                for (int i = 0; i < sq.Length; i++)
                {
                    string namkt = hienthi[i].NgayKetChuyen.Year.ToString();
                    string thangkt = hienthi[i].NgayKetChuyen.Month.ToString();

                    if (namkt == year && thangkt == month)
                    {
                        if (hienthi[i].TrangThai == false)
                        {
                            lbtrangthai.Text = "Kỳ này chưa đóng";
                            lbtrangthai.ForeColor = Color.Black;
                            toolStrip1.Enabled = dtgvsoquy.Enabled = true;
                        }
                        else
                        {
                            lbtrangthai.Text = "Kỳ này đã khóa";
                            lbtrangthai.ForeColor = Color.Red;
                            toolStrip1.Enabled = dtgvsoquy.Enabled = false;
                        }
                        ma = hienthi[i].MaSoDuSoQuy;
                        sq[sotang] = hienthi[i];
                        sotang++;
                        break;
                    }
                    else
                    {
                        lbtrangthai.Text = "Kỳ này chưa đóng";
                        lbtrangthai.ForeColor = Color.Black;
                        toolStrip1.Enabled = dtgvsoquy.Enabled = true;
                    }

                }
                if (sotang != 0)
                {
                    hienthi = new Entities.SoDuSoQuy[sotang];
                    for (int i = 0; i < sotang; i++)
                    {
                        hienthi[i] = new Entities.SoDuSoQuy("1111", "Tiền mặt - Tiền Việt Nam", sq[i].SoDuDauKy);
                    }

                }
                else
                {
                    hienthi = new Entities.SoDuSoQuy[0];
                    dtgvsoquy.DataSource = hienthi;
                    return;
                }
                dtgvsoquy.DataSource = hienthi;
                //new Common.Utilities().CountDatagridview(dtgvsoquy);
            }
            catch
            {
            }
            finally
            {
                fix();
            }
        }

        public void DeleteSoQuy()   
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.SoDuSoQuy pt = new Entities.SoDuSoQuy("Delete", ma);
                // khởi tạo mảng đối tượng để hứng giá trị
                clientstrem = cl.SerializeObj(this.client1, "SoQuy", pt);
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                if (kt == true)
                {
                    SelectData();
                }
            }
            catch
            {
            }
        }

        public void fix()
        {
            try
            {
                if (hienthi == null)
                {
                    dtgvsoquy.DataSource = new Entities.SoDuSoQuy[0];
                    return;
                }
                dtgvsoquy.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                for (int i = 0; i < dtgvsoquy.ColumnCount; i++)
                {
                    dtgvsoquy.Columns[i].Visible = false;
                }
                dtgvsoquy.ReadOnly = true;
                //new Common.Utilities().CountDatagridview(dtgvsoquy);
                dtgvsoquy.Columns["HanhDong"].Visible = true;
                dtgvsoquy.Columns["SoDuCuoiKy"].Visible = true;
                dtgvsoquy.Columns["SoDuDauKy"].Visible = true;
                dtgvsoquy.Columns["HanhDong"].HeaderText = "Mã Tài Khoản";
                dtgvsoquy.Columns["SoDuCuoiKy"].HeaderText = "Dư Đầu Kỳ";
                dtgvsoquy.Columns["SoDuDauKy"].HeaderText = "Tên Tài Khoản";
                dtgvsoquy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvsoquy.AllowUserToAddRows = false;
                dtgvsoquy.AllowUserToDeleteRows = false;
                dtgvsoquy.AllowUserToResizeRows = false;
                dtgvsoquy.RowHeadersVisible = false;
                this.Focus(); this.WindowState = FormWindowState.Maximized;
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

        private void frmSoDuSoQuy_Load(object sender, EventArgs e)
        {
        }

        private void cbbnam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                year = cbbnam.Text;
                month = cbbthang.Text;
                SelectData();
            }
            catch
            {
            }

        }

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

        public bool CheckDataGridViewInsert()
        {
            if (dtgvsoquy.RowCount != 0)
            {
                
                MessageBox.Show("Đã tồn tại số dư tháng này - không thể nhập thêm", "Hệ thống cảnh báo");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (CheckDataGridViewInsert() == true)
            {
                string month1 = datesv.Month.ToString();
                if (month1 != month)
                {
                    MessageBox.Show("Không phải kỳ hiện tại", "Hệ thống cảnh báo");
                    return;
                }

                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.SoDuSoQuy pt = new Entities.SoDuSoQuy("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                clientstrem = cl.SerializeObj(this.client1, "SoQuy", pt);
                // đổ mảng đối tượng vào datagripview       
                hienthi = (Entities.SoDuSoQuy[])cl.DeserializeHepper1(clientstrem, hienthi);
                if (hienthi != null)
                {
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        string monthkytruoc = (Convert.ToInt32(month) - 1).ToString();
                        string mm = hienthi[i].NgayKetChuyen.Month.ToString();
                        if (mm == monthkytruoc)
                        {
                            MessageBox.Show("Số dư đầu kỳ là kết chuyển từ kỳ trước - không thể thay đổi", "Hệ thống cảnh báo");
                            return;
                        }
                    }
                }
                try
                {

                    string masd = ProID("SoDuSoQuy");
                    cl = new Server_Client.Client();
                    // gán TCPclient
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    // khởi tạo biến truyền vào với hàm khởi tạo
                    Entities.SoDuSoQuy pt1 = new Entities.SoDuSoQuy();
                    pt1 = new Entities.SoDuSoQuy("Insert", masd, tsslsodudauky.Text.Replace(",", ""), datesv, "0", false);
                    // khởi tạo mảng đối tượng để hứng giá trị
                    clientstrem = cl.SerializeObj(this.client1, "SoQuy", pt1);
                    // đổ mảng đối tượng vào datagripview       
                    bool kt = false;
                    kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                    if (kt == true)
                    {
                        tsslsodudauky.Text = "0";
                        SelectData();
                    }
                }
                catch
                {
                }

            }
        }

        public string ProID(string tenBang)
        {
            try
            {
                string idnew;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.LayID lid = new Entities.LayID();
                clientstrem = cl.SerializeObj(this.client1, "LayID", lid1);
                // đổ mảng đối tượng vào datagripview       
                lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, hienthi);
                if (lid == null)
                    return "SDSQ_0001";
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void cbbthang_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                year = cbbnam.Text;
                month = cbbthang.Text;
                SelectData();
            }
            catch
            {
            }
        }
        int i = 0;

        private void tsslsodudauky_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    double.Parse(tsslsodudauky.Text);
            //}
            //catch
            //{
            //    tsslsodudauky.Text = "0";
            //}
            new TienIch().AutoFormatMoney(sender);
        }

        private void dtgvsoquy_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            if (i < 0)
                return;
            try
            {
                string month1 = datesv.Month.ToString();
                if (month1 != month)
                {
                    MessageBox.Show("Không phải kỳ hiện tại", "Hệ thống cảnh báo");
                    return;
                }

                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.SoDuSoQuy pt = new Entities.SoDuSoQuy("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                clientstrem = cl.SerializeObj(this.client1, "SoQuy", pt);
                // đổ mảng đối tượng vào datagripview       
                hienthi = (Entities.SoDuSoQuy[])cl.DeserializeHepper1(clientstrem, hienthi);
                if (hienthi != null)
                {
                    for (int j = 0; j < hienthi.Length; j++)
                    {
                        string monthkytruoc = (Convert.ToInt32(month) - 1).ToString();
                        string mm = hienthi[j].NgayKetChuyen.Month.ToString();
                        if (mm == monthkytruoc)
                        {
                            MessageBox.Show("Số dư đầu kỳ là kết chuyển từ kỳ trước - không thể thay đổi", "Hệ thống cảnh báo");
                            SelectData();
                            return;
                        }
                    }
                }
                tsslsodudauky.Text = new TienIch().FormatMoney(dtgvsoquy["SoDuCuoiKy", i].Value.ToString());
                if (dtgvsoquy.RowCount >= 1)
                {
                    DeleteSoQuy();
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                fix();
            }
        }

        private void tsslin_Click(object sender, EventArgs e)
        {

        }

        private void tsslnap_Click(object sender, EventArgs e)
        {
            try
            {
                year = cbbnam.Text;
                month = cbbthang.Text;
                SelectData();
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

        private void tsslsodudauky_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                toolStripButton1_Click(sender, e);
            }
        }
    }
}
