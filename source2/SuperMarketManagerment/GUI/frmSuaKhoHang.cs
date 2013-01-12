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
    public partial class frmSuaKhoHang : Form
    {
        //Khai báo các hàm
        public TcpClient tcpClient;
        public NetworkStream networkStream;

        public frmSuaKhoHang()
        {
            InitializeComponent();
        }

        private void frmSuaKhoHang_Load(object sender, EventArgs e)
        {

        }

        DataGridViewRow dgvr1;
         public frmSuaKhoHang(DataGridViewRow dgvr)
        {
            InitializeComponent();
            txtMaKho.Text = dgvr.Cells["MaKho"].Value.ToString();
            txtTenKho.Text = dgvr.Cells["TenKho"].Value.ToString();
            txtDiaChi.Text = dgvr.Cells["DiaChi"].Value.ToString();
            txtSoDienThoai.Text = dgvr.Cells["DienThoai"].Value.ToString();
            cmbMaNhanVien.Text = dgvr.Cells["MaNhanVien"].Value.ToString();
            txtGhiChu.Text = dgvr.Cells["GhiChu"].Value.ToString();
            dgvr1 = dgvr;
        }

        //Xử Lý Combobox Mã Nhân Viên
         #region Xử lý Combobox Mã Nhân Viên
         Server_Client.Client client;
         private void cmbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
         {
             cmbMaNhanVien.Items.Clear();
             client = new Server_Client.Client();
             this.tcpClient = client.Connect(Luu.IP, Luu.Ports);

             Entities.NhanVien kh = new Entities.NhanVien();
             kh = new Entities.NhanVien("Select");
             networkStream = client.SerializeObj(this.tcpClient, "NhanVien", kh);
             Entities.NhanVien[] kh1 = new Entities.NhanVien[1];
             kh1 = (Entities.NhanVien[])client.DeserializeHepper1(networkStream, kh1);

             if (kh1.Length > 0)
             {
                 int sl = kh1.Length;
                 for (int i = 0; i < sl; i++)
                 {
                     if (kh1[i].Deleted == false)
                         cmbMaNhanVien.Items.Add(kh1[i].MaNhanVien);
                 }
             }
         }
         #endregion
        
        //Sửa Kho Hàng
         #region Sửa Kho Hàng
         private void tssSua_Click(object sender, EventArgs e)
         {
                 Server_Client.Client client = new Server_Client.Client();
                 this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
                 Entities.KhoHang kh = new Entities.KhoHang();
                 kh = new Entities.KhoHang("Update", int.Parse(dgvr1.Cells[1].Value.ToString()), txtMaKho.Text, txtTenKho.Text,txtDiaChi.Text,txtSoDienThoai.Text,cmbMaNhanVien.Text, txtGhiChu.Text, false);
                 networkStream = client.SerializeObj(this.tcpClient, "KhoHang", kh);
                 bool kt = false;
                 kt = (bool)client.DeserializeHepper(networkStream, kt);
                 if (kt == true)
                 {
                     MessageBox.Show("Thành công");
                 }
                 this.Close();
         }
        #endregion

         //Check Conflict
         #region Check Conflict
         public string chck = "1";
         public void checkConflict()
         {
             Server_Client.Client client= new Server_Client.Client();
             this.tcpClient = client.Connect(Luu.IP, Luu.Ports);

             Entities.KhoHang kh = new Entities.KhoHang("Select");
             Entities.KhoHang[] kh1 = new Entities.KhoHang[1];
             networkStream = client.SerializeObj(this.tcpClient, "KhoHang", kh);

             kh1 = (Entities.KhoHang[])client.DeserializeHepper1(networkStream, kh1);
             if (kh1 != null)
             {
                 for (int j = 0; j < kh1.Length; j++)
                 {
                     if (kh1[j].MaKho == txtMaKho.Text)
                     {
                         MessageBox.Show("Thất bại");
                         chck = "No";
                         txtMaKho.Text = new Common.Utilities().ProcessID(txtMaKho.Text);
                         break;
                     }
                     else
                         chck = "Yes";
                 }
             }
         }
         #endregion

         //Đóng form
         private void tssDong_Click(object sender, EventArgs e)
         {
             this.Close();
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

    }
}
