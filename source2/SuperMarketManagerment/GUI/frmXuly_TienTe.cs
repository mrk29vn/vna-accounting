using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entities;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmXuly_TienTe : Form
    {
        public frmXuly_TienTe()
        {
            InitializeComponent();
        }
        #region Khai Báo
        private int nhanVienID;
        private string maTienTe;
        private string tenTienTe;
        private string tenTienTeChan;
        private string tenTienTeLe;
        private string bieuTuong;
        private int donViLamTron;
        private string ghiChu;

        TienTe tt;
        public TcpClient client1;
        public NetworkStream clientstream;
        Server_Client.Client cl;
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
        public frmXuly_TienTe(string hanhdong, DataGridViewRow dgvr)
        {
            InitializeComponent();
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
            txtmatt.Text = LayID("TienTe");
            txtID.Visible = false;
            label1.Visible = false;
            txtdonvi.Text = "0";
            this.Text = "Thêm Tiền Tệ";
        }

        public void KhoiTaoSua(DataGridViewRow dgvr)
        {
            tsslThem.Enabled = false;
            txtID.Text = dgvr.Cells[1].Value.ToString();
            maTienTe = txtmatt.Text = dgvr.Cells[2].Value.ToString();
            tenTienTe = txttentt.Text = dgvr.Cells[3].Value.ToString();
            tenTienTeChan = txttenttc.Text = dgvr.Cells[4].Value.ToString();
            tenTienTeLe = txttenttl.Text = dgvr.Cells[5].Value.ToString();
            bieuTuong = txtbieutuong.Text = dgvr.Cells[6].Value.ToString();
            txtdonvi.Text = dgvr.Cells[7].Value.ToString();
            donViLamTron = int.Parse(txtdonvi.Text);
            ghiChu = txtghichu.Text = dgvr.Cells[8].Value.ToString();
            this.Text = "Sửa Tiền Tệ ";
        }
        #endregion

        #region LayID
        public string LayID(string tenBang)
        {
            string idnew="";
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
            if (lid != null)
            {
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
            }
            else
            {
                if (lid == null)
                {
                    idnew = "TT_0001";
                }
            }
            return idnew;
        }
        #endregion

        #region validate
        public bool Validate()
        {

           string kt2="ok";
           try
           {
               Convert.ToInt32(txtdonvi.Text);
           }
           catch (Exception e)
           {
               kt2 = "Bạn đã nhập sai định dạng đơn vị - Hãy nhập số";
               txtdonvi.Focus();
           }
           if (kt2!="ok")
           {
               MessageBox.Show(kt2);
                return false;
           }

           if (txtbieutuong.Text.Length >10)
           {
                MessageBox.Show("Biểu tượng Tiền Tệ không được trên 10 ký tự", "Hệ Thống Cảnh Báo");
                txtbieutuong.Focus();
                return false;
           }

            if (txttentt.Text.Length == 0)
            {
                MessageBox.Show("Tên Tiền Tệ không được để trống", "Hệ Thống Cảnh Báo");
                txttentt.Focus();
                return false;
            }
            if (txttenttc.Text.Length == 0)
            {
                MessageBox.Show("Tên Tiền Tệ chẵn không được để trống", "Hệ Thống Cảnh Báo");
                txttenttc.Focus();
                return false;
            }
            if (txttenttl.Text.Length == 0)
            {
                MessageBox.Show("Tên Tiền Tệ lẻ không được để trống", "Hệ Thống Cảnh Báo");
                txttenttl.Focus();
                return false;
            }
            if (txtdonvi.Text.Length == 0)
            {
                MessageBox.Show("Đơn vị không được để trống", "Hệ Thống Cảnh Báo");
                txtdonvi.Focus();
                return false;
            }

            return true;
        }
        #endregion

        #region Main check conflict update
        Entities.TienTe[] tt1;
        string kt;
        public void CheckConflictUpdate()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.TienTe tt = new Entities.TienTe("Select", 1);
                // khởi tạo mảng đối tượng để hứng giá trị
                tt1 = new Entities.TienTe[1];
                clientstream = cl.SerializeObj(this.client1, "TienTe", tt);
                // đổ mảng đối tượng vào datagripview       
                tt1 = (Entities.TienTe[])cl.DeserializeHepper1(clientstream, tt1);
                if (tt1 != null)
                {
                    for (int j = 0; j < tt1.Length; j++)
                    {
                        if (tt1[j].MaTienTe == maTienTe)
                        {
                            kt = Check(tt1[j]);
                            break;
                        }
                        else
                            kt = "null";
                    }
                }

            }
            catch
            {
            }
        }
        #endregion

        #region check() check conflict
        public string Check(Entities.TienTe tt)
        {
            string gt = "ok";

            if (tenTienTe != tt.TenTienTe)
            {
                tenTienTe = txttentt.Text = tt.TenTienTe;
                gt = "ko";
            }
            if (tenTienTeLe != tt.TenTienTeLe)
            {
                tenTienTeLe = txttenttl.Text = tt.TenTienTeLe;
                gt = "ko";
            }

            if (tenTienTeChan != tt.TenTienTeChan)
            {
                tenTienTeChan = txttenttc.Text = tt.TenTienTeChan;
                gt = "ko";
            }
            if (bieuTuong != tt.BieuTuong)
            {
                bieuTuong = txtbieutuong.Text = tt.BieuTuong.ToString();
                gt = "ko";
            }
            if (donViLamTron != tt.DonViLamTron)
            {
                donViLamTron = tt.DonViLamTron;
                txtdonvi.Text = donViLamTron.ToString();
                gt = "ko";
            }

            if (ghiChu != tt.GhiChu)
            {
                ghiChu = txtghichu.Text = tt.GhiChu;
                gt = "ko";
            }

            if (gt == "ko")
            {
                MessageBox.Show("Dữ liệu đã có thay đổi trước, ấn ok để cập nhật lại.");
            }

            return gt;
        }
        #endregion

        #region check conflict Insert
        public void CheckConflictInsert()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.TienTe tt = new Entities.TienTe("Select", 1);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.TienTe[] tknh1 = new Entities.TienTe[1];
                clientstream = cl.SerializeObj(this.client1, "TienTe", tt);
                // đổ mảng đối tượng vào datagripview       
                tknh1 = (Entities.TienTe[])cl.DeserializeHepper1(clientstream, tknh1);
                if (tknh1 != null)
                {
                    for (int j = 0; j < tknh1.Length; j++)
                    {
                        if (tknh1[j].MaTienTe == txtmatt.Text)
                        {
                            MessageBox.Show("cập nhật mã Tài Khoản Ngân Hàng - kiểm tra lại để insert");
                            kt = "ko";
                            txtmatt.Text = LayID("TienTe");
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

        #region sự kiện click của nút thêm
        private void tsslThem_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                CheckConflictInsert();
                if (kt == "ok")
                {
                    cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    Entities.TienTe tt = new Entities.TienTe("Insert", 1, txtmatt.Text, txttentt.Text, txttenttc.Text, txttenttl.Text, txtbieutuong.Text, Convert.ToInt32(txtdonvi.Text), txtghichu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                    clientstream = cl.SerializeObj(this.client1, "TienTe", tt);
                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(clientstream, msg);
                    if (msg == 1)
                    {
                        txtmatt.Text = LayID("TienTe");
                        txttentt.Text = "";
                        txttenttc.Text = "";
                        txttenttl.Text = "";
                        txtbieutuong.Text = "";
                        txtdonvi.Text = "";
                        txtghichu.Text = "";
                        frmQuanlytiente.KiemTra = "insert";
                        this.Close();
                    }
                    else
                        MessageBox.Show("Insert that bai");
                    
                }
            }
        }
        #endregion

        private void tsslSua_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                CheckConflictUpdate();
                if (kt == "ok")
                {
                    Server_Client.Client cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    Entities.TienTe tt = new Entities.TienTe("Update", Convert.ToInt32(txtID.Text), txtmatt.Text, txttentt.Text, txttenttc.Text, txttenttl.Text, txtbieutuong.Text, Convert.ToInt32(txtdonvi.Text), txtghichu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                    clientstream = cl.SerializeObj(this.client1, "TienTe", tt);
                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(clientstream, msg);
                    if (msg == 1)
                    {
                        tenTienTe = txttentt.Text;
                        tenTienTeChan = txttenttc.Text;
                        tenTienTeLe = txttenttl.Text;
                        bieuTuong = txtbieutuong.Text;
                        donViLamTron = int.Parse(txtdonvi.Text);
                        ghiChu = txtghichu.Text;
                        this.Close();
                    }
                    else
                        MessageBox.Show("Update that bai");
                    

                }
                else
                    if (kt == "null")
                    {
                        MessageBox.Show("Bản ghi đã bị xóa bởi người dùng khác. Mời bạn xử lý bản ghi khác");
                        this.Close();
                    }
            }
        }

        private void tsslDong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    frmQuanlytiente.KiemTra = "close";
                    this.Close();
                }
                else
                { }
            }
        }

        private void frmXuly_TienTe_Load(object sender, EventArgs e)
        {
             txttentt.Focus();
        }
    }
}
