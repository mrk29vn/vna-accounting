using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmXuly_PhongBan : Form
    {
        public frmXuly_PhongBan()
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
        #region Khai báo
        Server_Client.Client cl;
        string tenphongban, maphongban, ghichu;
        public TcpClient client1;
        public NetworkStream clientstream;
        public string kt;
        #endregion

        public frmXuly_PhongBan(string hanhdong , DataGridViewRow dgvr)
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

        #region validate()
        public bool Validate()
        {
            if (txttenpb.Text.Length == 0)
            {
                MessageBox.Show("Tên Phòng ban không được để trống", "Hệ Thống Cảnh Báo");
                txttenpb.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region Khởi Tạo
        public void KhoiTaoThem(DataGridViewRow dgvr)
        {
            tsslSua.Enabled = false;
            txtmapb.Text = LayID("PhongBan");
            txtID.Visible = false;
            label1.Visible = false;
            this.Text = "Thêm Phòng Ban";
        }

        public void KhoiTaoSua(DataGridViewRow dgvr)
        {
            tsslThem.Enabled = false;
            txtID.Text = dgvr.Cells[1].Value.ToString();
            maphongban = txtmapb.Text = dgvr.Cells[2].Value.ToString();
            tenphongban = txttenpb.Text = dgvr.Cells[3].Value.ToString();
            ghichu = txtghichu.Text = dgvr.Cells[4].Value.ToString();
            this.Text = "Sửa Phòng Ban";
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
                    idnew = "PB_0001";
                }
            }
            return idnew;
        }
        #endregion

        #region check() check conflict
        public string Check(Entities.PhongBan pb)
        {
            string gt = "ok";

            if (tenphongban != pb.TenPhongBan)
            {
                tenphongban = txttenpb.Text = pb.TenPhongBan;
                gt = "ko";
            }
            if (ghichu != pb.GhiChu)
            {
                ghichu = txtghichu.Text = pb.GhiChu;
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
        Entities.PhongBan[] pb1;
        public void CheckConflictUpdate()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.PhongBan pb = new Entities.PhongBan("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                pb1 = new Entities.PhongBan[1];
                clientstream = cl.SerializeObj(this.client1, "PhongBan", pb);
                // đổ mảng đối tượng vào datagripview       
                pb1 = (Entities.PhongBan[])cl.DeserializeHepper1(clientstream, pb1);
                if (pb1 != null)
                {
                    for (int j = 0; j < pb1.Length; j++)
                    {
                        if (pb1[j].MaPhongBan == maphongban)
                        {
                            kt = Check(pb1[j]);
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

        #region check conflict insert
        public void CheckConflictInsert()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.PhongBan pb = new Entities.PhongBan("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.PhongBan[] pb1 = new Entities.PhongBan[1];
                clientstream = cl.SerializeObj(this.client1, "PhongBan", pb);
                // đổ mảng đối tượng vào datagripview       
                pb1 = (Entities.PhongBan[])cl.DeserializeHepper1(clientstream, pb1);
                if (pb1 != null)
                {
                    for (int j = 0; j < pb1.Length; j++)
                    {
                        if (pb1[j].MaPhongBan == txtmapb.Text)
                        {
                            MessageBox.Show("cập nhật mã Khoản Mục - kiểm tra lại để insert");
                            kt = "ko";
                            txtmapb.Text = LayID("PhongBan");
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
                    frmQuanlyphongban.KiemTra = "close";
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
                    Entities.PhongBan pb = new Entities.PhongBan("Insert", 1, txtmapb.Text, txttenpb.Text, txtghichu.Text, false,Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                    clientstream = cl.SerializeObj(this.client1, "PhongBan", pb);

                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(clientstream, msg);
                    if (msg == 1)
                    {
                        txtmapb.Text = LayID("PhongBan");
                        txttenpb.Text = "";
                        txtghichu.Text = "";
                        frmQuanlyphongban.KiemTra = "insert";
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
                    cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    Entities.PhongBan pb = new Entities.PhongBan("Update", Convert.ToInt32(txtID.Text), txtmapb.Text, txttenpb.Text, txtghichu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                    clientstream = cl.SerializeObj(this.client1, "PhongBan", pb);

                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(clientstream, msg);
                    if (msg == 1)
                    {
                        this.Close();
                    }
                    else
                        MessageBox.Show("Update that bai");
                        tenphongban = txttenpb.Text;
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

        private void frmXuly_PhongBan_Load(object sender, EventArgs e)
        {
            txttenpb.Focus();
        }


    }
}
