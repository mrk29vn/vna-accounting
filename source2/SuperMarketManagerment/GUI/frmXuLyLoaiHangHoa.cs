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
    public partial class frmXuLyLoaiHangHoa : Form
    {
        //Phần Khai 
        #region Khai Báo
        public TcpClient tcpClient;
        public NetworkStream networkStream;
        public frmXuLyLoaiHangHoa(DataGridViewRow dgvr)
        {
            InitializeComponent();
        }
        public frmXuLyLoaiHangHoa(string str1, string str2)
        {
            InitializeComponent();
            XuLyString(str1, str2);
        }
        public frmXuLyLoaiHangHoa()
        {
            InitializeComponent();
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
                    this.Text = " Quản lý Loại Hàng Hóa - Thêm mới Loại Hàng";
                    tssSua.Enabled = false;
                    txtMaLoaiHang.Text = ProID("LoaiHang");


                }
                if (str1 == "Thu" && str2 == "Sua")
                {
                    this.Text = " Quản lý Loại Hàng Hóa - Sửa Loại Hàng";
                    tssThem.Enabled = false;

                }
            }
            catch { }

        }
        Entities.LoaiHangHoa lhh = new Entities.LoaiHangHoa();
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
                lid = (Entities.LayID)cl.DeserializeHepper(networkStream, lhh);
                if (lid == null)
                {
                    return "LH_0001";
                }
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            finally
            { }

        }
        private void frmXuLyLoaiHangHoa_Load(object sender, EventArgs e)
        {
            txtTenLoaiHang.Focus();
        }

        string id;
        string maloaihang, tenloaihang, ghichu;
        public frmXuLyLoaiHangHoa(string str1, string str2,DataGridViewRow dgvr)
        {
            try
            {
                InitializeComponent();
                XuLyString(str1, str2);
                id = dgvr.Cells["LoaiHangID"].Value.ToString();
                maloaihang = txtMaLoaiHang.Text = dgvr.Cells["MaLoaiHang"].Value.ToString();
                tenloaihang = txtTenLoaiHang.Text = dgvr.Cells["TenLoaiHang"].Value.ToString();
                ghichu = txtGhiChu.Text = dgvr.Cells["GhiChu"].Value.ToString();
            }
            catch { }
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

        //Kiểm tra
        private bool KiemTra()
        {
            try
            {
                if (txtMaLoaiHang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + label2.Text, "Hệ thống cảnh báo");
                    txtMaLoaiHang.Focus();
                    return false;
                }
                if (txtTenLoaiHang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + label3.Text, "Hệ thống cảnh báo");
                    txtTenLoaiHang.Focus();
                    return false;
                }
                if (txtTenLoaiHang.Text.Length >= 100)
                {
                    MessageBox.Show("Tên loại hàng không thể quá 100 kí tự ", "Hệ thống cảnh báo");
                    txtTenLoaiHang.Focus();
                    return false;
                }
                if (txtGhiChu.Text.Length >= 100)
                {
                    MessageBox.Show("ghi chú loại hàng không thể quá 100 kí tự ", "Hệ thống cảnh báo");
                    txtGhiChu.Focus();
                    return false;
                }
                return true;
            }
            finally { }
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
                        Entities.LoaiHangHoa nv = new Entities.LoaiHangHoa();
                        nv = new Entities.LoaiHangHoa("Insert", 0, txtMaLoaiHang.Text, txtTenLoaiHang.Text, txtGhiChu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                        networkStream = cl.SerializeObj(this.tcpClient, "LoaiHangHoa", nv);
                        int msg = 0;
                        msg = (int)cl.DeserializeHepper(networkStream, msg);
                        if (msg == 1)
                        {
                            this.Close();
                        }

                        else
                        {
                            MessageBox.Show("mã loại hàng hóa đã thay đổi - kiểm tra lại dữ liệu");
                            txtMaLoaiHang.Text = new Common.Utilities().ProcessID(txtMaLoaiHang.Text);
                        }

                    }

                }
            }
            catch { }
        }

        //Sửa
        private void tssSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra())
                {
                    CheckConflictUpdate();
                    if (kt == "ok")
                    {
                        Server_Client.Client cl = new Server_Client.Client();
                        this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.LoaiHangHoa nv = new Entities.LoaiHangHoa();
                        nv = new Entities.LoaiHangHoa("Update", int.Parse(id), txtMaLoaiHang.Text, txtTenLoaiHang.Text, txtGhiChu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                        networkStream = cl.SerializeObj(this.tcpClient, "LoaiHangHoa", nv);
                        int msg = 0;
                        msg = (int)cl.DeserializeHepper(networkStream, msg);
                        if (msg == 1)
                        {
                            this.Close();
                        }
                        else
                            MessageBox.Show("Thất Bại");
                    }
                    else
                    {
                        MessageBox.Show("Thay đổi dữ liệu");
                    }
                }
            }
            catch { }
        }

        //Đóng
        private void tssDong_Click(object sender, EventArgs e)
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

        #endregion

        //Check Conflict
        #region Check Conflict

        string kt ;

        //Check Thêm
        public void CheckConflictInsert()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LoaiHangHoa ncc = new Entities.LoaiHangHoa("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.LoaiHangHoa[] ncc1 = new Entities.LoaiHangHoa[1];
                networkStream = cl.SerializeObj(this.tcpClient, "LoaiHangHoa", ncc);
                // đổ mảng đối tượng vào datagripview       
                ncc1 = (Entities.LoaiHangHoa[])cl.DeserializeHepper1(networkStream, ncc1);
                if (ncc1 != null)
                {
                    for (int j = 0; j < ncc1.Length; j++)
                    {
                        if (ncc1[j].MaLoaiHang == maloaihang)
                        {
                            MessageBox.Show("cập nhật mã loại hàng - kiểm tra lại để insert");
                            kt = "ko";
                            maloaihang = txtMaLoaiHang.Text = ProID("LoaiHang");
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

        //Check Sửa
        Entities.LoaiHangHoa[] kh1;
        Server_Client.Client cl;
        public void CheckConflictUpdate()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LoaiHangHoa kh = new Entities.LoaiHangHoa("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                kh1 = new Entities.LoaiHangHoa[1];
                networkStream = cl.SerializeObj(this.tcpClient, "LoaiHangHoa", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.LoaiHangHoa[])cl.DeserializeHepper1(networkStream, kh1);
                if (kh1 != null)
                {
                    for (int j = 0; j < kh1.Length; j++)
                    {
                        if (kh1[j].MaLoaiHang == maloaihang)
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

         public string Check(Entities.LoaiHangHoa kh)
        {
            try
            {
                string gt = "ok";

                if (tenloaihang != kh.TenLoaiHang)
                {
                    tenloaihang = txtTenLoaiHang.Text = kh.TenLoaiHang;
                    gt = "ko";
                }

                if (ghichu != kh.GhiChu)
                {
                    ghichu = txtGhiChu.Text = kh.GhiChu;
                    gt = "ko";
                }
                return gt;
            }
            finally
            { }
        }
        #endregion

        private void frmXuLyLoaiHangHoa_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (ktgiatri == "")
                    frmQuanLyLoaiHangHoa.trave = "A";
            }
            catch { }
        }

    }
}
