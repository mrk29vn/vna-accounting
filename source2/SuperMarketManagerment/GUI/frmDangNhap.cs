using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
namespace GUI
{
    public partial class frmDangNhap : Form
    {
        //SqlConnection connect;
        public TcpClient client1;
        public NetworkStream clientstrem;
        //BizLogic.TaiKhoan tktk;
        Server_Client.Client cl;
        Entities.TaiKhoan[] tk1;
        //Entities.TaiKhoan[] hienthi;
        public static Entities.TaiKhoan User = null;
        public static Entities.ChiTietQuyen[] CTQ = null;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void lnkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start("http://www.lamtransoft.com/");
        }

        private void lnkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start("http://www.gmail.com");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                
                }
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenTaiKhoan.Text=="")
            {
                chckError.SetError(txtTenTaiKhoan,"Nhập tên tài khoản của bạn");   
            }
            else if (txtMatKhau.Text=="")
            {
                chckError.SetError(txtMatKhau,"Nhập mật khẩu của bạn");
            }
            else if (LogIn(txtTenTaiKhoan.Text, txtMatKhau.Text))
            {
                this.Hide();
                Form fr = new frmChinh();
                fr.Show();
            }
            else
            {
                MessageBox.Show("Đăng Nhập Thất Bại");
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.btnDangNhap;
            this.CancelButton = this.btnThoat;
            if (new Common.Utilities().CaiDatTrial())
            {

            }
        }

        private void lnkDoiMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        /// <summary>
        /// hàm đăng nhập
        /// </summary>
        /// <param name="ttk"></param>
        /// <param name="mk"></param>
        /// <returns></returns>
        public bool LogIn(string ttk,string mk)
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.TaiKhoan tk = new Entities.TaiKhoan();
                tk = new Entities.TaiKhoan(ttk, mk);
                // khởi tạo mảng đối tượng để hứng giá trị
                tk1 = new Entities.TaiKhoan[1];
                clientstrem = cl.SerializeObj(this.client1, "LogIn", tk);
                // đổ mảng đối tượng vào datagripview       
                tk1 = (Entities.TaiKhoan[])cl.DeserializeHepper1(clientstrem, tk1);
                if (tk1.Length > 0)
                {
                    if (!tk1[0].KhoaTaiKhoan)
                    {
                        Common.Utilities.User = User = tk1[0];
                        Common.Utilities.CTQ = CTQ = LayChiTietQuyen(User.TenNhomQuyen);
                        
                        return true;
                    }
                    return false;
                }
                else
                    return false;
            }
            catch (Exception w)
            {
                string str=w.Message;
                return false;
            }
        }
        public Entities.ChiTietQuyen[] LayChiTietQuyen(string manhomquyen)
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo nếu muốn truyền giá trị
                Entities.ChiTietQuyen nq = new Entities.ChiTietQuyen(manhomquyen);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.ChiTietQuyen[] nq1;
                clientstrem = cl.SerializeObj(this.client1, "LayChiTietQuyen", nq);
                // đổ mảng đối tượng vào datagripview       
                nq1 = (Entities.ChiTietQuyen[])cl.DeserializeHepper1(clientstrem, null);
                return nq1;
            }
            catch (Exception)
            {

                return null;
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            //txtTenTaiKhoan.Text = "dhtvietnam";
            //txtMatKhau.Text = "dht12345";
        }

    }
}
