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
    public partial class frmTinhDiemThuong : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.TyLeTinh[] tlt = new Entities.TyLeTinh[0];
        Entities.DiemThuongKhachHang[] dtkh = new Entities.DiemThuongKhachHang[0];

        public frmTinhDiemThuong()
        {
            InitializeComponent();
        }

        private void frmTinhDiemThuong_Load(object sender, EventArgs e)
        {
            try
            {
                DiemThuongKhachHang();
                dtgvhienthi.DataSource = dtkh;
                fix();
                TyLeTinh();
                foreach (Entities.TyLeTinh item in tlt)
                {
                    txttiletinh.Text = new TienIch().FormatMoney(item.SoTien.ToString());
                }
                if (tlt.Length == 0)
                {
                    txttiletinh.Text = "0";
                }
                txttiletinh.Focus();
                txttiletinh.SelectAll();
            }
            catch { }
        }

        private void TyLeTinh()
        {
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            clientstrem = cl.SerializeObj(this.client1, "selectTyLeTinh", new Entities.TyLeTinh());
            tlt = (Entities.TyLeTinh[])cl.DeserializeHepper1(clientstrem, tlt);
            if (tlt == null)
                tlt = new Entities.TyLeTinh[0];
        }

        private void DiemThuongKhachHang()
        {
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            clientstrem = cl.SerializeObj(this.client1, "SelectDiemThuongKhachHang", new Entities.DiemThuongKhachHang("select"));
            dtkh = (Entities.DiemThuongKhachHang[])cl.DeserializeHepper1(clientstrem, dtkh);
            if (dtkh == null)
                dtkh = new Entities.DiemThuongKhachHang[0];
        }

        public void fix()
        {
            for (int j = 1; j < dtgvhienthi.ColumnCount; j++)
            {
                dtgvhienthi.Columns[j].Visible = false;
            }
            new Common.Utilities().CountDatagridview(dtgvhienthi);
            dtgvhienthi.ReadOnly = true;
            dtgvhienthi.RowHeadersVisible = false;
            dtgvhienthi.Columns["ThaoTac"].Visible = false;
            dtgvhienthi.Columns["ThaoTac"].HeaderText = "STT";
            dtgvhienthi.Columns["MaKhachHang"].Visible = true;
            dtgvhienthi.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
            dtgvhienthi.Columns["TenKhachHang"].Visible = true;
            dtgvhienthi.Columns["TenKhachHang"].HeaderText = "Tên Khách Hàng";
            dtgvhienthi.Columns["TongDiem"].Visible = true;
            dtgvhienthi.Columns["TongDiem"].HeaderText = "Tổng Điểm";
            dtgvhienthi.Columns["DiemDaDung"].Visible = true;
            dtgvhienthi.Columns["DiemDaDung"].HeaderText = "Điểm Đã Dùng";
            dtgvhienthi.Columns["DiemConLai"].Visible = true;
            dtgvhienthi.Columns["DiemConLai"].HeaderText = "Điểm Còn Lại";
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.AllowUserToAddRows = false;
            dtgvhienthi.AllowUserToDeleteRows = false;
            dtgvhienthi.AllowUserToResizeRows = false;
            this.Focus();
        }

        private void btntinhdiem_Click(object sender, EventArgs e)
        {//Cập nhật tỷ lệ tính
            try
            {
                string id = ProID("TyLeTinh");
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TyLeTinh input = new Entities.TyLeTinh(id, double.Parse(txttiletinh.Text.Replace(",", "")), DateServer.Date(), "", false);
                clientstrem = cl.SerializeObj(this.client1, "insertTyLeTinh", input);
                int msg = 0;
                msg = (int)cl.DeserializeHepper(clientstrem, msg);
                if (msg != 0)
                    MessageBox.Show("Cập nhật tỷ lệ tính thành công");
            }
            catch { }
        }

        private void tssldong_Click(object sender, EventArgs e)
        {
            DialogResult giatri = MessageBox.Show("Bán chắc chắn đóng không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Search = txttimkiem.Text.Trim();
                List<Entities.DiemThuongKhachHang> ketqua = new List<Entities.DiemThuongKhachHang>();
                foreach (Entities.DiemThuongKhachHang item in dtkh)
                {
                    int test = -1;
                    if (rdbtimkiem1.Checked)    //Tìm Kiếm Theo Mã Khách Hàng
                    {
                        test = item.MaKhachHang.ToLower().IndexOf(Search.ToLower());
                    }
                    else if (rdbtimkiem2.Checked)   //Tìm Kiếm Theo Tên Khách Hàng
                    {
                        test = item.TenKhachHang.ToLower().IndexOf(Search.ToLower());
                    }
                    if (test >= 0)
                    {
                        ketqua.Add(item);
                    }
                }
                dtgvhienthi.DataSource = ketqua.ToArray();
                fix();
            }
            catch { }
        }

        private void txttiletinh_TextChanged(object sender, EventArgs e)
        {
            new TienIch().AutoFormatMoney(sender);
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

        public string ProID(string tenBang)
        {
            try
            {
                string idnew;
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                TcpClient client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.LayID lid = new Entities.LayID();
                NetworkStream clientstrem = cl.SerializeObj(client1, "LayID", lid1);
                // đổ mảng đối tượng vào datagripview       
                lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, lid);
                if (lid == null)
                {
                    if (tenBang.Equals("TyLeTinh"))
                    {
                        return "TLT_0001";
                    }
                    else if (tenBang.Equals("DiemThuongKhachHang"))
                    {
                        return "DTKH_0001";
                    }
                }
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            catch
            { return ""; }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                DiemThuongKhachHang();
                dtgvhienthi.DataSource = dtkh;
                fix();
            }
            catch { }
        }
    }
}
