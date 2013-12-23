using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Entities;

namespace GUI
{
    public partial class frmXuly_NhomTKKeToan : Form
    {
        public frmXuly_NhomTKKeToan()
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
        #region khai báo
        Server_Client.Client cl;
        public TcpClient client1;
        public NetworkStream clientstream;
        NhomTKKeToan ntkkt;
        string tenNhomTKKeToan, ghiChu,maNhomTK;
        #endregion

        public frmXuly_NhomTKKeToan(string hanhdong, DataGridViewRow dgvr)
        {
            InitializeComponent();
            if (hanhdong == "Them")
            {
                KhoiTaoThem(dgvr);
                
            }
            else
                if (hanhdong == "Sua")
                {
                    KhoiTaoSua(dgvr);
                }
        }

        #region valifdate
        public bool Validate()
        {

            if (txttenNTKKT.Text.Length == 0)
            {
                MessageBox.Show("Tên Nhóm TK Kế toán không được để trống", "Hệ Thống Cảnh Báo");
                txttenNTKKT.Focus();
                return false;
            }
            if (txtmaNTKKT.Text.Length == 0)
            {
                MessageBox.Show("Mã Nhóm TK Kế toán không được để trống", "Hệ Thống Cảnh Báo");
                txtmaNTKKT.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region LayID
        public string LayID(string tenBang)
        {
            string idnew;
            cl = new Server_Client.Client();
            // gán TCPclient
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            // khởi tạo biến truyền vào với hàm khởi tạo
            Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
            // khởi tạo mảng đối tượng để hứng giá trị
            Entities.LayID lid = new Entities.LayID();
            clientstream = cl.SerializeObj(this.client1, "LayID", lid1);
            // đổ mảng đối tượng vào datagripview       
            lid = (Entities.LayID)cl.DeserializeHepper(clientstream, lid1);
            Common.Utilities a = new Common.Utilities();
            idnew = a.ProcessID(lid.ID);
            return idnew;
        }
        #endregion

        #region Khởi Tạo
        public void KhoiTaoThem(DataGridViewRow dgvr)
        {
            tsslSua.Enabled = false;
            txtmaNTKKT.ReadOnly = false;
            txtID.Visible = false;
            label1.Visible = false;
            this.Text = "Thêm Nhóm TK Kế Toán";
        }

        public void KhoiTaoSua(DataGridViewRow dgvr)
        {
            tsslThem.Enabled = false;
            txtID.Text = dgvr.Cells[1].Value.ToString();
            maNhomTK = txtmaNTKKT.Text = dgvr.Cells[2].Value.ToString();
            tenNhomTKKeToan = txttenNTKKT.Text = dgvr.Cells[3].Value.ToString();
            ghiChu = txtghichu.Text = dgvr.Cells[4].Value.ToString();
            this.Text = "Sửa Nhóm TK Kế Toán";
        }
        #endregion

        #region check() check conflict
        public string Check(Entities.NhomTKKeToan ntkkt)
        {
            string gt = "ok";

            if (tenNhomTKKeToan != ntkkt.TenNhomTKKeToan)
            {
                tenNhomTKKeToan = txttenNTKKT.Text = ntkkt.TenNhomTKKeToan;
                gt = "ko";
            }
            if (ghiChu != ntkkt.GhiChu)
            {
                ghiChu = txtghichu.Text = ntkkt.GhiChu;
                gt = "ko";
            }

            if (gt == "ko")
            {
                MessageBox.Show("Dữ liệu đã có thay đổi trước, ấn ok để cập nhật lại.");
            }

            return gt;
        }
        #endregion

        #region Main check conflict update
        Entities.NhomTKKeToan[] pb1;
        string kt;
        public void CheckConflictUpdate()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.NhomTKKeToan ntkkt = new Entities.NhomTKKeToan("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                pb1 = new Entities.NhomTKKeToan[1];
                clientstream = cl.SerializeObj(this.client1, "NhomTKKeToan", ntkkt);
                // đổ mảng đối tượng vào datagripview       
                pb1 = (Entities.NhomTKKeToan[])cl.DeserializeHepper1(clientstream, pb1);
                if (pb1 != null)
                {
                    for (int j = 0; j < pb1.Length; j++)
                    {
                        if (pb1[j].MaNhomTKKeToan == maNhomTK)
                        {
                            kt = Check(pb1[j]);
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
        #endregion

        #region check conflict insert
        public void CheckConflictInsert()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.NhomTKKeToan pb = new Entities.NhomTKKeToan("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.NhomTKKeToan[] pb1 = new Entities.NhomTKKeToan[1];
                clientstream = cl.SerializeObj(this.client1, "NhomTKKeToan", pb);
                // đổ mảng đối tượng vào datagripview       
                pb1 = (Entities.NhomTKKeToan[])cl.DeserializeHepper1(clientstream, pb1);
                if (pb1 != null)
                {
                    for (int j = 0; j < pb1.Length; j++)
                    {
                        if (pb1[j].MaNhomTKKeToan == txtmaNTKKT.Text)
                        {
                            MessageBox.Show("Mã nhóm tk này đã có trong dữ liệu - mời nhập lại");
                            kt = "ko";
                            txtmaNTKKT.Text = "";
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
        #endregion

        private void tsslDong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    frmQuanLyNhomTKKeToan.KiemTra = "close";
                    this.Close();
                }
                else
                { }
            }
        }

        private void tsslThem_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                CheckConflictInsert();
                if (kt == "ok")
                {
                    cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    Entities.NhomTKKeToan pb = new Entities.NhomTKKeToan("Insert", 1, txtmaNTKKT.Text, txttenNTKKT.Text, txtghichu.Text, false,Common.Utilities.User.NhanVienID,Common.Utilities.User.TenDangNhap);
                    clientstream = cl.SerializeObj(this.client1, "NhomTKKeToan", pb);

                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(clientstream, msg);
                    if (msg == 1)
                    {
                        txtmaNTKKT.Text = "";
                        txttenNTKKT.Text = "";
                        txtghichu.Text = "";
                        frmQuanLyNhomTKKeToan.KiemTra = "insert";
                        this.Close();
                    }
                    else
                        MessageBox.Show("Insert that bai");
                    
                }
            }

        }

        private void tsslSua_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                CheckConflictUpdate();
                if (kt == "ok")
                {
                    Server_Client.Client cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    Entities.NhomTKKeToan pb = new Entities.NhomTKKeToan("Update", Convert.ToInt32(txtID.Text), txtmaNTKKT.Text, txttenNTKKT.Text, txtghichu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                    clientstream = cl.SerializeObj(this.client1, "NhomTKKeToan", pb);

                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(clientstream, msg);
                    if (msg == 1)
                    {
                        this.Close();
                    }
                    else
                        MessageBox.Show("Update that bai");
                }
                else
                    if (kt=="null")
                    {
                        MessageBox.Show("Bản ghi đã bị xóa - Mời thao tác lại.");
                        this.Close();
                    }
            }
        }

        private void frmXuly_NhomTKKeToan_Load(object sender, EventArgs e)
        {
            txttenNTKKT.Focus();
        }

        private void txtmaNTKKT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox temp = (TextBox)sender;
                int vt = temp.SelectionStart;
                string str = new string(temp.Text.ToList<char>().Where(c => char.IsNumber(c)).ToArray<char>());
                temp.Text = str;
                temp.SelectionStart = vt;
            }
            catch
            {
            }
        }


    }
}
