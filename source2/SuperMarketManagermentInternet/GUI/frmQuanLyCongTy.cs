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
    public partial class frmQuanLyCongTy : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        public frmQuanLyCongTy()
        {
            InitializeComponent();
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
        public static string trave = "";
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 3))
                {
                    MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                    return;
                }
                for (int j = 0; j < 1000; j++)
                {
                    if (trave == "")
                    {
                        frmXuLyCongTy qlkh = new frmXuLyCongTy("Thu", "Them");
                        qlkh.ShowDialog();
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
            { }
        }
        Server_Client.Client cl;
        Entities.ThongTinCongTy[] kh1;
        Entities.ThongTinCongTy[] hienthi;
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData()
        {
            try
            {

                i = 0;
                dgvcongty.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ThongTinCongTy kh = new Entities.ThongTinCongTy();
                // truyền HanhDong
                kh = new Entities.ThongTinCongTy("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                kh1 = new Entities.ThongTinCongTy[1];
                clientstrem = cl.SerializeObj(this.client1, "CongTy", kh);
                // đổ mảng đối tượng vào daThongTinCongTytagripview       
                kh1 = (Entities.ThongTinCongTy[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 == null)
                {
                   
                    hienthi = new Entities.ThongTinCongTy[0];
                    dgvcongty.DataSource = new Entities.ThongTinCongTy[0];
                    toolStripStatusLabel1.Enabled = true;
                    return;
                }

                Entities.ThongTinCongTy[] pt2 = new Entities.ThongTinCongTy[kh1.Length];
                int sotang = 0;
                for (int j = 0; j < kh1.Length; j++)
                {
                    
                            pt2[sotang] = kh1[j];
                            sotang++;               
                }
                hienthi = new Entities.ThongTinCongTy[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pt2[j];
                    }
                }
                else
                {
                    dgvcongty.DataSource = new Entities.ThongTinCongTy[0];

                    return;
                }
                dgvcongty.DataSource = hienthi;
                new Common.Utilities().CountDatagridview(dgvcongty);
                toolStripStatusLabel1.Enabled = false;
                dgvcongty.Rows[0].Selected = true;
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvcongty.ColumnCount; j++)
                    {
                        dgvcongty.Columns[j].Visible = false;
                    }
                    dgvcongty.Columns[0].Visible = true;
                    dgvcongty.Columns["MaCongTy"].Visible = true;
                    dgvcongty.Columns["TenCongTy"].Visible = true;
                    dgvcongty.Columns["DiaChi"].Visible = true;
                    dgvcongty.Columns["SoDienThoai"].Visible = true;
                    dgvcongty.Columns["Email"].Visible = true;
                    dgvcongty.Columns["Website"].Visible = true;
                    dgvcongty.Columns["Fax"].Visible = true;
                    dgvcongty.Columns[0].HeaderText = "STT";
                    dgvcongty.Columns[1].Visible = false;
                    dgvcongty.Columns["MaCongTy"].HeaderText = "Mã Công Ty";
                    dgvcongty.Columns["TenCongTy"].HeaderText = "Tên Công Ty";
                    dgvcongty.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvcongty.Columns["SoDienThoai"].HeaderText = "Điện Thoại";
                    dgvcongty.Columns["Email"].HeaderText = "Email";
                    dgvcongty.Columns["Website"].HeaderText = "Website";
                    dgvcongty.Columns["Fax"].HeaderText = "Fax";
                    dgvcongty.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvcongty.AllowUserToAddRows = false;
                    dgvcongty.AllowUserToDeleteRows = false;
                    dgvcongty.AllowUserToResizeRows = false;
                }
                catch { }
            }
        }

        private void frmQuanLyCongTy_Load(object sender, EventArgs e)
        {
            SelectData();
        }
        int i;
        private void dgvcongty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                i = e.RowIndex;
                if (i >= 0)
                {
                    dgvcongty.Rows[i].Selected = true;
                }
            }
            catch
            { }
        }
        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 3))
                {
                    MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                    return;
                }
                for (int j = 0; j < 1000; j++)
                {
                    if (trave == "")
                    {
                        frmXuLyCongTy qlkh = new frmXuLyCongTy("Thu", "Sua", dgvcongty.Rows[i]);
                        qlkh.ShowDialog();
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
            {}
        }
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            try
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
            catch { }
        }
        public bool CheckQuyen(string tenform, int quyen)
        {
            switch (quyen)
            {
                case 1:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenXem;
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenSua;
                        }
                        break;
                    }
                case 3:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenXoa;
                        }
                        break;
                    }
                case 4:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenThem;
                        }
                        break;
                    }
            }
            return false;
        }

        private void dgvcongty_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            try
            {
                frmXuLyCongTy a = new frmXuLyCongTy("Thu", "Sua", dgvcongty.Rows[i]);
                a.ShowDialog();
                SelectData();
            }
            catch
            {

            }
        }
    }
}
