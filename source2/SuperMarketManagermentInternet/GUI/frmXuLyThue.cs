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
    public partial class frmXuLyThue : Form
    {
        public TcpClient tcpClient;
        public NetworkStream networkStream;
        public frmXuLyThue()
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
                    this.Text = " Quản lý thuế- Thêm mới thuế";
                    tsslblsua.Enabled = false;
                    txtmathue.Text = ProID("Thue");


                }
                if (str1 == "Thu" && str2 == "Sua")
                {
                    this.Text = " Quản lý thuế - Sửa thuế";
                    tsslblthem.Enabled = false;

                }
            }
            catch { }

        }
         public frmXuLyThue(DataGridViewRow dgvr)
        {
            InitializeComponent();
        }
         public frmXuLyThue(string str1, string str2)
        {
            InitializeComponent();
            XuLyString(str1, str2);
        }
         string id;
        string mathue, giatrithue, tenthue,ghichu;
        public frmXuLyThue(string str1, string str2, DataGridViewRow dgvr)
        {
            InitializeComponent();
            XuLyString(str1, str2);
            id = dgvr.Cells["ThueID"].Value.ToString();
            mathue = txtmathue.Text = dgvr.Cells["MaThue"].Value.ToString();
            giatrithue = txtgiatrithue.Text = dgvr.Cells["GiaTriThue"].Value.ToString();
            tenthue = txttenthue.Text = dgvr.Cells["TenThue"].Value.ToString();
            ghichu = txtghichu.Text = dgvr.Cells["GhiChu"].Value.ToString();
        }
         string kt;
         public void CheckConflictInsert()
         {
             try
             {
                 cl = new Server_Client.Client();
                 // gán TCPclient
                 this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                 // khởi tạo biến truyền vào với hàm khởi tạo
                 Entities.Thue ncc = new Entities.Thue("Select");
                 // khởi tạo mảng đối tượng để hứng giá trị
                 Entities.Thue[] ncc1 = new Entities.Thue[1];
                 networkStream = cl.SerializeObj(this.tcpClient, "ThueH", ncc);
                 // đổ mảng đối tượng vào datagripview       
                 ncc1 = (Entities.Thue[])cl.DeserializeHepper1(networkStream, ncc1);
                 if (ncc1 != null)
                 {
                     for (int j = 0; j < ncc1.Length; j++)
                     {
                         if (ncc1[j].MaThue == mathue)
                         {
                             MessageBox.Show("cập nhật mã thuế- kiểm tra lại để insert");
                             kt = "ko";
                             mathue = txtmathue.Text = ProID("Thue");
                             break;
                         }
                         else
                             kt = "ok";
                     }

                 }
                 else
                     kt = "ok";

             }
             catch
             {
             }
         }
         Entities.Thue[] kh1;
         Server_Client.Client cl;
         public void CheckConflictUpdate()
         {
             try
             {
                 cl = new Server_Client.Client();
                 // gán TCPclient
                 this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                 // khởi tạo biến truyền vào với hàm khởi tạo
                 Entities.Thue kh = new Entities.Thue("Select");
                 // khởi tạo mảng đối tượng để hứng giá trị
                 kh1 = new Entities.Thue[1];
                 networkStream = cl.SerializeObj(this.tcpClient, "ThueH", kh);
                 // đổ mảng đối tượng vào datagripview       
                 kh1 = (Entities.Thue[])cl.DeserializeHepper1(networkStream, kh1);
                 if (kh1 != null)
                 {
                     for (int j = 0; j < kh1.Length; j++)
                     {
                         if (kh1[j].MaThue == mathue)
                         {

                             kt = Check(kh1[j]);
                             break;
                         }
                         else
                             kt = "ok";
                     }

                 }

             }
             catch
             {
             }
         }


         public string Check(Entities.Thue kh)
         {
             try
             {
                 string gt = "ok";

                 if (giatrithue != kh.GiaTriThue)
                 {
                     giatrithue = txtgiatrithue.Text = kh.GiaTriThue;
                     gt = "ko";
                 }
                 if (tenthue != kh.TenThue)
                 {
                     tenthue = txttenthue.Text = kh.TenThue;
                     gt = "ko";
                 }
                 if (ghichu != kh.GhiChu)
                 {
                     ghichu = txtghichu.Text = kh.GhiChu;
                     gt = "ko";
                 }
                 return gt;
             }
             catch
             {
                 return "";
             }
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
                 this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                 // khởi tạo biến truyền vào với hàm khởi tạo
                 Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
                 // khởi tạo mảng đối tượng để hứng giá trị
                 Entities.LayID lid = new Entities.LayID();
                 networkStream = cl.SerializeObj(this.tcpClient, "LayID", lid1);
                 // đổ mảng đối tượng vào datagripview       
                 lid = (Entities.LayID)cl.DeserializeHepper(networkStream, lid);
                 if (lid == null)
                 {
                     return "MT_0001";
                 }
                 Common.Utilities a = new Common.Utilities();
                 idnew = a.ProcessID(lid.ID);
                 return idnew;
             }
             catch
             { return ""; }
         }

         //Kiểm Tra
         private bool KiemTra()
         {
             try
             {

                 if (txtgiatrithue.Text.Length == 0)
                 {
                     MessageBox.Show("Bạn cần phải nhập" + label3.Text, "Hệ thống cảnh báo");
                     txtgiatrithue.Focus();
                     return false;
                 }
                 if (txttenthue.Text.Length == 0)
                 {
                     MessageBox.Show("Bạn cần phải nhập" + label4.Text, "Hệ thống cảnh báo");
                     txttenthue.Focus();
                     return false;
                 }
                 return true;
             }
             finally
             { }
         }
         string ktgiatri = "";
         private void tsslblthem_Click(object sender, EventArgs e)
         {
             try
             {
             if (KiemTra())
             {
                 CheckConflictInsert();
                 if (kt == "ok")
                 {
                     if (txtghichu.Text == "")
                     { }
                     ktgiatri = "a";
                     Server_Client.Client cl = new Server_Client.Client();
                     this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                     Entities.Thue nv = new Entities.Thue();
                     nv = new Entities.Thue("Insert", 0, txtmathue.Text, txtgiatrithue.Text, txttenthue.Text, txtghichu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                     networkStream = cl.SerializeObj(this.tcpClient, "ThueH", nv);
                     int msg = 0;
                     msg = (int)cl.DeserializeHepper(networkStream, msg);
                     if (msg == 1)
                     {
                         this.Close();
                     }

                     else
                     {
                         MessageBox.Show("mã thuế đã thay đổi - kiểm tra lại dữ liệu");
                         txtmathue.Text = new Common.Utilities().ProcessID(txtmathue.Text);
                     }

                 }

             }
             }
             catch
             {
                 MessageBox.Show("Xuất hiện lỗi");
             }
         }

         private void tsslblsua_Click(object sender, EventArgs e)
         {
             try
             {
             if (KiemTra() == true)
             {
                 CheckConflictUpdate();
                 if (kt == "ok")
                 {
                     Server_Client.Client client = new Server_Client.Client();
                     this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
                     Entities.Thue kh = new Entities.Thue();
                     kh = new Entities.Thue("Update", int.Parse(id), txtmathue.Text, txtgiatrithue.Text, txttenthue.Text, txtghichu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                     networkStream = client.SerializeObj(this.tcpClient, "ThueH", kh);
                     int msg = 0;
                     msg = (int)cl.DeserializeHepper(networkStream, msg);
                     if (msg == 1)
                     {
                     }
                     else
                         MessageBox.Show("Thất Bại");
                     this.Close();
                 }
                 else
                 {
                     MessageBox.Show("Thay đổi dữ liệu");
                 }
             }
             }
             catch
             {
                 MessageBox.Show("Xuất hiện lỗi");
             }
         }

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

         private void frmXuLyThue_FormClosed(object sender, FormClosedEventArgs e)
         {
             try
             {
                 if (ktgiatri == "")
                     frmQuanLyThue.trave = "A";
             }
             catch
             { }
         }

         private void txtgiatrithue_TextChanged(object sender, EventArgs e)
         {
             try
             {
                 if (int.Parse(txtgiatrithue.Text) >= 0)
                 {
                     if (int.Parse(txtgiatrithue.Text) > 100)
                     {
                         MessageBox.Show("Phần trăm giá trị thuế phải >=0 hoặc <=100", "Hệ thống cảnh báo");
                         txtgiatrithue.Focus();
                        txtgiatrithue.Text = "0";
                        txtgiatrithue.Text = String.Format("{0:0}", txtgiatrithue.Text);
                         return;
                     }
                 }
             }
             catch (Exception ex)
             { //txtgiatrithue.Text = "0"; 
                 txtgiatrithue.Text = "";
             }
         }

         private void txtgiatrithue_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
