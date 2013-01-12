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
    public partial class frmXuLyDonViTinh : Form
    {
        //Phần Khai Báo
        #region Khai Báo

        public TcpClient tcpClient;
        public NetworkStream networkStream;

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
                    this.Text = " Quản lý Đơn vị tính - Thêm mới đơn vị tính";
                    tssSua.Enabled = false;
                    txtMaDonViTinh.Text = ProID("DVT");


                }
                if (str1 == "Thu" && str2 == "Sua")
                {
                    this.Text = " Quản lý đơn vị tính - Sửa đơn vị tính";
                    tssThem.Enabled = false;

                }
            }
            catch { }

        }

        public frmXuLyDonViTinh()
        {
            InitializeComponent();
        }
        public frmXuLyDonViTinh(DataGridViewRow dgvr)
        {
            InitializeComponent();
        }
        public frmXuLyDonViTinh(string str1,string str2)
        {
            InitializeComponent();
            XuLyString(str1, str2);
        }

        string id;
        string madvt, tendvt, ghichu;
        public frmXuLyDonViTinh(string str1, string str2, DataGridViewRow dgvr)
        {
            InitializeComponent();
            XuLyString(str1, str2);
            id = dgvr.Cells["DVTID"].Value.ToString();
            madvt = txtMaDonViTinh.Text = dgvr.Cells["MaDonViTinh"].Value.ToString();
            tendvt = txtTenDonViTinh.Text = dgvr.Cells["TenDonViTinh"].Value.ToString();
            ghichu = txtGhiChu.Text = dgvr.Cells["GhiChu"].Value.ToString();
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
                Entities.DVT ncc = new Entities.DVT("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.DVT[] ncc1 = new Entities.DVT[1];
                networkStream = cl.SerializeObj(this.tcpClient, "DVT", ncc);
                // đổ mảng đối tượng vào datagripview       
                ncc1 = (Entities.DVT[])cl.DeserializeHepper1(networkStream, ncc1);
                if (ncc1 != null)
                {
                    for (int j = 0; j < ncc1.Length; j++)
                    {
                        if (ncc1[j].MaDonViTinh == madvt)
                        {
                            MessageBox.Show("cập nhật mã đơn vị tính- kiểm tra lại để insert");
                            kt = "ko";
                            madvt = txtMaDonViTinh.Text = ProID("DVT");
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
        Entities.DVT[] kh1;
        Server_Client.Client cl;
        public void CheckConflictUpdate()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.DVT kh = new Entities.DVT("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                kh1 = new Entities.DVT[1];
                networkStream = cl.SerializeObj(this.tcpClient, "DVT", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.DVT[])cl.DeserializeHepper1(networkStream, kh1);
                if (kh1 != null)
                {
                    for (int j = 0; j < kh1.Length; j++)
                    {
                        if (kh1[j].MaDonViTinh == madvt)
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


        public string Check(Entities.DVT kh)
        {
            try
            {
                string gt = "ok";

                if (tendvt != kh.TenDonViTinh)
                {
                    tendvt = txtTenDonViTinh.Text = kh.TenDonViTinh;
                    gt = "ko";
                }
                if (ghichu != kh.GhiChu)
                {
                    ghichu = txtGhiChu.Text = kh.GhiChu;
                    gt = "ko";
                }
                return gt;
            }
            catch
            {
                return "";
            }
        }
        //Hiển thị dữ liệu khi load
        private void frmXuLyDonViTinh_Load(object sender, EventArgs e)
        {
        }
        #endregion
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
        //Phần Xử Lý
        #region Xử Lý
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
                   return "DVT_0001";
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
                if (txtMaDonViTinh.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập" + label3.Text, "Hệ thống cảnh báo");
                    txtMaDonViTinh.Focus();
                    return false;

                }
                if (txtTenDonViTinh.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập" + label4.Text, "Hệ thống cảnh báo");
                    txtTenDonViTinh.Focus();
                    return false;
                }
                return true;
            }
            finally
            { }
        }

        //Thêm
        string ktgiatri = "";
        private void tssThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra())
                {
                    CheckConflictInsert();
                    if (kt == "ok")
                    {

                        ktgiatri = "a";
                        Server_Client.Client cl = new Server_Client.Client();
                        this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.DVT nv = new Entities.DVT();
                        nv = new Entities.DVT("Insert", 0, txtMaDonViTinh.Text, txtTenDonViTinh.Text, txtGhiChu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                        networkStream = cl.SerializeObj(this.tcpClient, "DVT", nv);
                        int msg = 0;
                        msg = (int)cl.DeserializeHepper(networkStream, msg);
                        if (msg == 1)
                        {
                            this.Close();
                        }

                        else
                        {
                            MessageBox.Show("mã đơn vị tính đã thay đổi - kiểm tra lại dữ liệu");
                            txtMaDonViTinh.Text = new Common.Utilities().ProcessID(txtMaDonViTinh.Text);
                        }

                    }

                }
            }
            catch {
                MessageBox.Show("Xuất hiện lỗi");
            }
        }

        //Sửa
        private void tssSua_Click(object sender, EventArgs e)
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
                        Entities.DVT kh = new Entities.DVT();
                        kh = new Entities.DVT("Update", int.Parse(id), txtMaDonViTinh.Text, txtTenDonViTinh.Text, txtGhiChu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                        networkStream = client.SerializeObj(this.tcpClient, "DVT", kh);
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

        //Đóng form
        private void tssDong_Click(object sender, EventArgs e)
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

        #endregion

        private void frmXuLyDonViTinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (ktgiatri == "")
                    frmQuanLyDVT.trave = "A";
            }
            catch
            { }
        }

    }
}
