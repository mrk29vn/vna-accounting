using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAL;
using BizLogic;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
namespace GUI
{
    public partial class frmXuLyCongTy : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        public frmXuLyCongTy()
        {
            InitializeComponent();
        }
        public frmXuLyCongTy(DataGridViewRow dgvcongty)
        {
            InitializeComponent();
        }
        public frmXuLyCongTy(string str1, string str2)
        {
            InitializeComponent();
            XuLyString(str1,str2);
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
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        public void XuLyString(string str1, string str2)
        {
            try
            {
                if (str1 == "Thu" && str2 == "Them")
                {
                    this.Text = " Quản lý Công Ty - Thêm mới ";
                    toolStripStatusLabel2.Enabled = false;
                    txtmacongty.Text = ProID("CongTy");


                }
                if (str1 == "Thu" && str2 == "Sua")
                {
                    this.Text = " Quản lý Công Ty - Sửa";
                    toolStripStatusLabel1.Enabled = false;

                }
            }
            catch { }

        }
        string id;
        string macongty,tencongty,diachi,dienthoai,email,website,fax;
        public frmXuLyCongTy(string str1, string str2, DataGridViewRow dgvcongty)
        {
            try
            {
                InitializeComponent();
                XuLyString(str1, str2);
                id = dgvcongty.Cells["CongTyID"].Value.ToString();
                macongty = txtmacongty.Text = dgvcongty.Cells["MaCongTy"].Value.ToString();
                tencongty = txttencongty.Text = dgvcongty.Cells["TenCongTy"].Value.ToString();
                diachi = txtdiachi.Text = dgvcongty.Cells["DiaChi"].Value.ToString();
                dienthoai = mktxtdienthoai.Text = dgvcongty.Cells["SoDienThoai"].Value.ToString();
                email = txtemail.Text = dgvcongty.Cells["Email"].Value.ToString();
                website = txtwebsite.Text = dgvcongty.Cells["Website"].Value.ToString();
                fax = txtfax.Text = dgvcongty.Cells["Fax"].Value.ToString();
            }
            catch { }
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
                        frmQuanLyKhachHang.trave = "A";
                    }
                    else
                    { }
                }
            }
            catch { }
        }
        private bool Kiemtra()
        {
            try
            {
                if (txtmacongty.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + lblmacongty.Text, "Hệ thống cảnh báo");
                    txtmacongty.Focus();
                    return false;
                }
                if (txttencongty.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + lbltencongty.Text, "Hệ thống cảnh báo");
                    txttencongty.Focus();
                    return false;
                }
                if (txtdiachi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + lbldiachi.Text, "Hệ thống cảnh báo");
                    txtdiachi.Focus();
                    return false;
                }
                if (mktxtdienthoai.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + lbldienthoai.Text, "Hệ thống cảnh báo");
                    mktxtdienthoai.Focus();
                    return false;
                }
                if (txtemail.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + lblemail.Text, "Hệ thống cảnh báo");
                    txtemail.Focus();
                    return false;
                }
                if (txtwebsite.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + lblwebsite.Text, "Hệ thống cảnh báo");
                    txtwebsite.Focus();
                    return false;
                }
                if (txtfax.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + lblfax.Text, "Hệ thống cảnh báo");
                    txtfax.Focus();
                    return false;
                }
                return true;
            }
            finally { }
        }
        /// <summary>
        /// Lấy giá trị id cuối cùng
        /// </summary>
        /// <param name="tenBang"></param>
        /// <returns></returns>
        public string ProID(string tenBang)
        {
            try
            {
                string idnew;
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.LayID lid = new Entities.LayID();
                clientstrem = cl.SerializeObj(this.client1, "LayID", lid1);
                // đổ mảng đối tượng vào datagripview       
                lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, lid);
                if (lid == null)
                {
                    return "CT_0001";
                }
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }

            finally
            { }
            
        }
        string ktgiatri = "";
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Kiemtra())
                {
                    ktgiatri = "a";
                    Server_Client.Client cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    Entities.ThongTinCongTy nv;
                    nv = new Entities.ThongTinCongTy("Insert", 0, txtmacongty.Text, txttencongty.Text, txtdiachi.Text, mktxtdienthoai.Text, txtemail.Text, txtwebsite.Text, txtfax.Text, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                    clientstrem = cl.SerializeObj(this.client1, "CongTy", nv);
                    Entities.ThongTinCongTy msg = new Entities.ThongTinCongTy();
                    msg = (Entities.ThongTinCongTy)cl.DeserializeHepper(clientstrem, msg);
                    if (msg.MaCongTy=="YES")
                    {
                        frmQuanLyCongTy.trave = "A";
                        this.Close();
                       
                    }

                }
            }
            catch { }
        }

        private void frmXuLyCongTy_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (ktgiatri == "")
                    frmQuanLyCongTy.trave = "A";
            }
            catch { }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Kiemtra())
                {
                    ktgiatri = "a";
                    Server_Client.Client cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    Entities.ThongTinCongTy nv;
                    nv = new Entities.ThongTinCongTy("Update", int.Parse(id), txtmacongty.Text, txttencongty.Text, txtdiachi.Text, mktxtdienthoai.Text, txtemail.Text, txtwebsite.Text, txtfax.Text, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                    clientstrem = cl.SerializeObj(this.client1, "CongTy", nv);
                    Entities.ThongTinCongTy msg = new Entities.ThongTinCongTy();
                    msg = (Entities.ThongTinCongTy)cl.DeserializeHepper(clientstrem, msg);
                    if (msg.MaCongTy == "YES")
                    {
                        this.Close();
                    }
                    else
                    {
                        // MessageBox.Show(msg.MaCongTy);
                        MessageBox.Show("Thất Bại");
                        txtmacongty.Text = new Common.Utilities().ProcessID(txtmacongty.Text);
                    }
                }               
            }
            catch { }
        }

        private void mktxtdienthoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch
            { }
        }

        private void txtfax_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch
            { }
        }

        private void mktxtdienthoai_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(mktxtdienthoai.Text) >= 0)
                {
                    mktxtdienthoai.Text = String.Format("{0:0}", mktxtdienthoai.Text);
                    return;
                }
            }
            catch
            {
                mktxtdienthoai.Text = "";
            }
        }

        private void txtfax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(txtfax.Text) >= 0)
                {
                    txtfax.Text = String.Format("{0:0}", txtfax.Text);
                    return;
                }
            }
            catch
            {
                txtfax.Text = "";
            }
        }
    }
}
