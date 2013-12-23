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
    public partial class frmXuLyNhomQuyen : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        //BizLogic.TaiKhoan tktk;
        Server_Client.Client cl;

        private Entities.NhomQuyen[] NhomQuyen = null;
        public frmXuLyNhomQuyen()
        {
            InitializeComponent();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                //connect = new SqlConnection("");
                //connect.Open();

                //string them = "";

                //command = new SqlCommand();
                //command.Connection = connect;
                //command.CommandText = them;
                //command.ExecuteNonQuery();
                ////close
                //connect.Dispose();
                //command.Dispose();
                if (txtTenNhomQuyen.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Chưa Nhập Tên Nhóm Quyền");
                }
                else if (txtTenNhomQuyen.Text.Trim().Length > 50)
                {
                    MessageBox.Show("Tên Nhóm Quyền quá dài");
                }
                else
                {
                    NhomQuyen = LayNhomQuyen();
                    bool kt = true;
                    foreach (Entities.NhomQuyen item in NhomQuyen)     
                    {
                        if (txtTenNhomQuyen.Text.ToLower().Equals(item.TenNhomQuyen.ToLower()))
                        {
                            MessageBox.Show("Nhóm Quyền Này Đã Tồn Tại, Hãy Thử Lại");
                            kt = false;
                            break;
                        }
                    }
                    if (kt)
                    {
                        if (ThemNhomQuyen(txtTenNhomQuyen.Text))
                        {
                            //MessageBox.Show("Thêm Thành Công");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Thao Tác Thất Bại");
                        }
                    }
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi Xuất Hiện");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frmThemNguoiDung_Load(object sender, EventArgs e)
        {
            
        }
        public bool ThemNhomQuyen(string tnq)
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo nếu muốn truyền giá trị
                Entities.NhomQuyen nq = new Entities.NhomQuyen(tnq);
                nq.MaNhanVien =Common.Utilities.User.NhanVienID;
                nq.TenDangNhap = Common.Utilities.User.TenDangNhap;
                // khởi tạo mảng đối tượng để hứng giá trị
                //Entities.NhomQuyen[] nq1;
                clientstrem = cl.SerializeObj(this.client1, "ThemNhomQuyen", nq);
                // đổ mảng đối tượng vào datagripview       
                bool trave = (bool)cl.DeserializeHepper(clientstrem, null);
                return trave;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public Entities.NhomQuyen[] LayNhomQuyen()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo nếu muốn truyền giá trị
                //Entities.NhomQuyen nq = new Entities.NhomQuyen();
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.NhomQuyen[] nq1;
                clientstrem = cl.SerializeObj(this.client1, "LayNhomQuyen", null);
                // đổ mảng đối tượng vào datagripview       
                nq1 = (Entities.NhomQuyen[])cl.DeserializeHepper1(clientstrem, null);
                return nq1;
            }
            catch (Exception)
            {

                return null;
            }
        }
        private void txtTenTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i = e.KeyChar;
            if ((i < 65 || i > 90) && (i < 97 || i > 122) && i != 8)
            {
                e.Handled = true;
            }
        }

        private void frmXuLyNhomQuyen_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
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
