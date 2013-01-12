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
    public partial class frmXuly_TKKeToan : Form
    {
        public frmXuly_TKKeToan()
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
        string tentk, nhomtk, ghichu, maTK;
        public TcpClient client1;
        public NetworkStream clientstream;
        NhomTKKeToan ntkkt;
        Server_Client.Client cl;

        public frmXuly_TKKeToan(string hanhdong, DataGridViewRow dgvr)
        {
            InitializeComponent();
            ShowCombobox();
            if (hanhdong == "Them")
            {
                KhoiTaoThem(dgvr);
                txtID.ReadOnly = false;
            }
            else
                if (hanhdong == "Sua")
                {
                    KhoiTaoSua(dgvr);
                }
           
        }

        #region Khởi Tạo
        public void KhoiTaoThem(DataGridViewRow dgvr)
        {
            tsslSua.Enabled = false;
            txtID.Visible = false;
            label1.Visible = false;
            txtmatkkt.ReadOnly = false;
            this.Text = "Thêm tài khoản kế toán";
        }

        public void KhoiTaoSua(DataGridViewRow dgvr)
        {
            txtmatkkt.ReadOnly = false ;
            tsslThem.Enabled = false;
            txtID.Text = dgvr.Cells[1].Value.ToString();
            maTK = txtmatkkt.Text = dgvr.Cells[2].Value.ToString();
            tentk = txttentkkt.Text = dgvr.Cells[3].Value.ToString();
            nhomtk = dgvr.Cells[4].Value.ToString();
            cbbNhomTK.SelectedIndex = cbbmaMaNhomTK_sua(nhomtk);
            ghichu = txtghichu.Text = dgvr.Cells[5].Value.ToString();
            this.Text = "Sửa Tài khoản kế toán";
            
           
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

        #region validate
        public bool Validate()
        {
            if (cbbNhomTK.DataSource==null)
            {
                MessageBox.Show("Nhóm TK kế toán chưa có dữ liệu trong cơ sở dữ liệu - Nhập thêm hoặc liên hệ nhà quản trị");

                return false;
            }
            if (txttentkkt.Text.Length == 0)
            {
                MessageBox.Show("Tên TK Kế toán không được để trống", "Hệ Thống Cảnh Báo");
                return false;
            }
            if (cbbNhomTK.Text.Length == 0)
            {
                MessageBox.Show("Nhóm TK Kế toán không được để trống", "Hệ Thống Cảnh Báo");
                return false;
            }
            if (txtmatkkt.Text.Length == 0)
            {
                MessageBox.Show("Mã TK Kế toán không được để trống", "Hệ Thống Cảnh Báo");
                return false;
            }
            return true;
        }
        #endregion

        #region check() check conflict
        public string Check(Entities.TKKeToan tk)
        {
            string gt = "ok";

            if (tentk != tk.TenTaiKhoan)
            {
                tentk = txttentkkt.Text = tk.TenTaiKhoan;
                gt = "ko";
            }
            if (ghichu != tk.GhiChu)
            {
                ghichu = txtghichu.Text = tk.GhiChu;
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
        Entities.TKKeToan[] tk1;
        string kt;
        public void CheckConflictUpdate()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.TKKeToan pb = new Entities.TKKeToan("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                tk1 = new Entities.TKKeToan[1];
                clientstream = cl.SerializeObj(this.client1, "TKKeToan", pb);
                // đổ mảng đối tượng vào datagripview       
                tk1 = (Entities.TKKeToan[])cl.DeserializeHepper1(clientstream, tk1);
                if (tk1 != null)
                {
                    for (int j = 0; j < tk1.Length; j++)
                    {
                        if (tk1[j].MaTKKeToan == maTK)
                        {
                            kt = Check(tk1[j]);
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

        #region show combobox nhomtkketoan
        public void ShowCombobox()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            ntkkt = new NhomTKKeToan("Select");
            clientstream = cl.SerializeObj(this.client1, "NhomTKKeToan", ntkkt);

            NhomTKKeToan[] tk = new NhomTKKeToan[1];
            tk[0] = new NhomTKKeToan(1, "a", "a", "a", false);
            tk = (NhomTKKeToan[])cl.DeserializeHepper1(clientstream, tk);

            cbbNhomTK.DataSource = tk;
            cbbNhomTK.DisplayMember = "TenNhomTKKeToan";

        }

        public int cbbmaMaNhomTK_sua(string maNH)
        {
            Entities.NhomTKKeToan[] pb = (Entities.NhomTKKeToan[])cbbNhomTK.DataSource;
            for (int i = 0; i < pb.Length; i++)
            {
                if (pb[i].MaNhomTKKeToan == maNH)
                {
                    return i;
                }
            }
            return -1;
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
                Entities.TKKeToan pb = new Entities.TKKeToan("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.TKKeToan[] tk1 = new Entities.TKKeToan[1];
                clientstream = cl.SerializeObj(this.client1, "TKKeToan", pb);
                // đổ mảng đối tượng vào datagripview       
                tk1 = (Entities.TKKeToan[])cl.DeserializeHepper1(clientstream, tk1);
                if (tk1 != null)
                {
                    for (int j = 0; j < tk1.Length; j++)
                    {
                        if (tk1[j].MaTKKeToan == txtmatkkt.Text)
                        {
                            MessageBox.Show("Mã tài khoản đã có trong dữ liệu - mời nhập lại để insert");
                            kt = "ko";
                            txtmatkkt.Text = "";
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
                    frmQuanLyTaiKhoanKeToan.KiemTra = "close";
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
                    Server_Client.Client cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    NhomTKKeToan ntk = (NhomTKKeToan)cbbNhomTK.SelectedItem;
                    Entities.TKKeToan tkkt = new Entities.TKKeToan("Insert", 1, txtmatkkt.Text, txttentkkt.Text, ntk.MaNhomTKKeToan, txtghichu.Text, false,Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                    clientstream = cl.SerializeObj(this.client1, "TKKeToan", tkkt);

                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(clientstream, msg);
                    if (msg == 1)
                    {
                        txttentkkt.Text = "";
                        txtmatkkt.Text = "";
                        txtghichu.Text = "";
                        cbbNhomTK.Text = "";
                        frmQuanLyTaiKhoanKeToan.KiemTra = "insert";
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
                    NhomTKKeToan ntk = (NhomTKKeToan)cbbNhomTK.SelectedItem;
                    Entities.TKKeToan tkkt1 = new Entities.TKKeToan("Update", Convert.ToInt32(txtID.Text), txtmatkkt.Text.Trim(), txttentkkt.Text.Trim(), ntk.MaNhomTKKeToan.Trim(), txtghichu.Text.Trim(), false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                    clientstream = cl.SerializeObj(this.client1, "TKKeToan", tkkt1);

                    int msg = 0;
                    try
                    {
                        msg = (int)cl.DeserializeHepper(clientstream, msg);
                    }
                    catch { }
                    if (msg == 1)
                    {
                      //  MessageBox.Show("Update thanh cong ...");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Cập nhật thất bại!\r\nvui lòng kiểm tra lại đường truyền tới server hoặc tài khoản kế toán đang được sử dụng không thể sửa hoặc xóa!");
                    tentk = txttentkkt.Text;
                    ghichu = txtghichu.Text;
                    
                }
                else
                    if (kt=="null")
                    {
                        MessageBox.Show("Bản Ghi đã bị xóa trước khi cập nhật! Vui lòng thao tác lại !");
                         this.Close();
                    }
            }
        }

        private void frmXuly_TKKeToan_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            txttentkkt.Focus();
        }

        private void txtmatkkt_TextChanged(object sender, EventArgs e)
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
