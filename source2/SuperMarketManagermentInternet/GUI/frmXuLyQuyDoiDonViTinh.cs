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
    public partial class frmXuLyQuyDoiDonViTinh : Form
    {

         //Phần Khai 
        #region Khai Báo
        public TcpClient tcpClient;
        public NetworkStream networkStream;
        DataGridViewRow dgvr;
        public frmXuLyQuyDoiDonViTinh(DataGridViewRow dgvr)
        {
            InitializeComponent();
        }
        public frmXuLyQuyDoiDonViTinh(string str1, string str2)
        {
            InitializeComponent();
            XuLyString(str1, str2);
        }
        public frmXuLyQuyDoiDonViTinh()
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
                    this.Text = " Quản lý Quy Đổi Đơn Vị Tính - Thêm mới Quy Đổi";
                    tsslblghilai.Enabled = false;
                    txtmaquydoidvt.Text = ProID("QuyDoiDonViTinh");


                }
                if (str1 == "Thu" && str2 == "Sua")
                {
                    this.Text = " Quản lý Quy Đổi Đơn Vị Tính - Sửa Quy Đổi";
                    tsslblthemmoi.Enabled = false;

                }
            }
            catch { }

        }
        Entities.QuyDoiDonViTinh lhh = new Entities.QuyDoiDonViTinh();
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
                    return "QDDVT_0001";
                }
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            finally
            { }

        }
        private void frmXuLyQuyDoiDonViTinh_Load(object sender, EventArgs e)
        {
            txtmahangquydoi.Focus();
        }

        string id;
        string maquydoidvt, mahangquydoi, mahangduocquydoi,
            tenhangquydoi,donvitinhquydoi,soluongquydoi,tenhangduocquydoi,donvitinhduocquydoi,soluongduocquydoi;
        public frmXuLyQuyDoiDonViTinh(string str1, string str2, DataGridViewRow dgvr)
        {
            try
            {
                InitializeComponent();
                XuLyString(str1, str2);
                id = dgvr.Cells["QuyDoiDonViTinhID"].Value.ToString();
                maquydoidvt = txtmaquydoidvt.Text = dgvr.Cells["MaQuyDoiDonViTinh"].Value.ToString();
                mahangquydoi = txtmahangquydoi.Text = dgvr.Cells["MaHangQuyDoi"].Value.ToString();
                mahangduocquydoi = txtmahangduocquydoi.Text = dgvr.Cells["MaHangDuocQuyDoi"].Value.ToString();
                tenhangquydoi = txttenhangquydoi.Text = dgvr.Cells["TenHangQuyDoi"].Value.ToString();
                tenhangduocquydoi = txttenhangduocquydoi.Text = dgvr.Cells["TenHangDuocQuyDoi"].Value.ToString();
                donvitinhquydoi = txtdonvitinhquydoi.Text = dgvr.Cells["MaDonViTinh"].Value.ToString();
                donvitinhduocquydoi = txtdonvitinhduocquydoi.Text = dgvr.Cells["MaDonViTinhDuocQuyDoi"].Value.ToString();
                soluongquydoi = txtsoluongquydoi.Text = dgvr.Cells["SoLuongQuyDoi"].Value.ToString();
                soluongduocquydoi = txtsoluongduocquydoi.Text = dgvr.Cells["SoLuongDuocQuyDoi"].Value.ToString();
            }
            catch { }
        }

        #endregion

        //Phần Xử Lý
        #region Xử Lý

        //Kiểm tra
        private bool KiemTra()
        {
            try
            {
                if (txtmaquydoidvt.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + label8.Text, "Hệ thống cảnh báo");
                    txtmaquydoidvt.Focus();
                    return false;
                }
                if (txtmahangquydoi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + lblMaNCC.Text, "Hệ thống cảnh báo");
                    txtmahangquydoi.Focus();
                    return false;
                }
                if (txttenhangquydoi.Text.Length >= 100)
                {
                    MessageBox.Show("Bạn cần phải nhập " + label1.Text, "Hệ thống cảnh báo");
                    txttenhangquydoi.Focus();
                    return false;
                }
                if (txtdonvitinhquydoi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập" + label2.Text,"Hệ thống cảnh báo");
                    txtdonvitinhquydoi.Focus();
                    return false;
                }
                if (txtsoluongquydoi.Text.Length >= 100)
                {
                    MessageBox.Show("Bạn cần phải nhập " + label3.Text, "Hệ thống cảnh báo");
                    txtsoluongquydoi.Focus();
                    return false;
                }
                if (txtmahangduocquydoi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + label4.Text, "Hệ thống cảnh báo");
                    txtmahangduocquydoi.Focus();
                    return false;
                }
                if (txttenhangduocquydoi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + label5.Text, "Hệ thống cảnh báo");
                    txttenhangduocquydoi.Focus();
                    return false;
                }
                if (txtdonvitinhduocquydoi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + label6.Text, "Hệ thống cảnh báo");
                    txtdonvitinhduocquydoi.Focus();
                    return false;
                }
                if (txtsoluongduocquydoi.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + label7.Text, "Hệ thống cảnh báo");
                    txtsoluongduocquydoi.Focus();
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
                   if (CheckConflictInsert() == true)
                    {

                        ktgiatri = "a";
                        Server_Client.Client cl = new Server_Client.Client();
                        this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.QuyDoiDonViTinh nv = new Entities.QuyDoiDonViTinh();
                        nv = new Entities.QuyDoiDonViTinh("Insert", 0, txtmaquydoidvt.Text, txtmahangquydoi.Text, txttenhangquydoi.Text,
                            txtdonvitinhquydoi.Text, int.Parse(txtsoluongquydoi.Text), txtmahangduocquydoi.Text, txttenhangduocquydoi.Text,
                            txtdonvitinhduocquydoi.Text, int.Parse(txtsoluongduocquydoi.Text), false, Common.Utilities.User.NhanVienID,
                            Common.Utilities.User.TenDangNhap);
                        networkStream = cl.SerializeObj(this.tcpClient, "QuyDoiDonViTinh", nv);
                        int msg = 0;
                        msg = (int)cl.DeserializeHepper(networkStream, msg);
                        if (msg == 1)
                        {
                            this.Close();
                        }

                        else
                        {
                            MessageBox.Show("mã quy đổi đơn vị tính đã thay đổi - kiểm tra lại dữ liệu");
                            txtmaquydoidvt.Text = new Common.Utilities().ProcessID(txtmaquydoidvt.Text);
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
                        Entities.QuyDoiDonViTinh nv = new Entities.QuyDoiDonViTinh();
                        nv = new Entities.QuyDoiDonViTinh("Update", int.Parse(id), txtmaquydoidvt.Text, txtmahangquydoi.Text, txttenhangquydoi.Text, txtdonvitinhquydoi.Text, int.Parse(txtsoluongquydoi.Text), txtmahangduocquydoi.Text, txttenhangduocquydoi.Text, txtdonvitinhduocquydoi.Text, int.Parse(txtsoluongduocquydoi.Text), false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                        networkStream = cl.SerializeObj(this.tcpClient, "QuyDoiDonViTinh", nv);
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
                        frmQuanLyQuyDoiDonViTinh.trave = "A";
                    }
                    else
                    { }
                }
            }
            catch
            { }
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
        //Check Conflict
        #region Check Conflict

        string kt ="1" ;

        //Check Thêm
        public Boolean CheckConflictInsert()
        {
            Boolean check = false;
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.QuyDoiDonViTinh ncc = new Entities.QuyDoiDonViTinh("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.QuyDoiDonViTinh[] ncc1 = new Entities.QuyDoiDonViTinh[1];
                networkStream = cl.SerializeObj(this.tcpClient, "QuyDoiDonViTinh", ncc);
                // đổ mảng đối tượng vào datagripview       
                ncc1 = (Entities.QuyDoiDonViTinh[])cl.DeserializeHepper1(networkStream, ncc1);
                for (int j = 0; j < ncc1.Length; j++)
                {
                    if (ncc1[j].MaQuyDoiDonViTinh == txtmaquydoidvt.Text)
                    {
                        MessageBox.Show("cập nhật mã loại hàng - kiểm tra lại để insert");
                        check = false;
                        maquydoidvt = txtmaquydoidvt.Text = ProID("QuyDoiDonViTinh");
                        break;
                    }
                    if (ncc1[j].MaHangQuyDoi == txtmahangquydoi.Text || ncc1[j].MaHangDuocQuyDoi == txtmahangduocquydoi.Text)
                    {
                        MessageBox.Show("mã hàng quy đổi đã tồn tại");
                        check = false;
                        break;
                    }
                    else
                    {

                        check = true;
                    }
                }
                if (ncc1.Length <= 0)
                { check = true; }
            }
            catch
            {
                check = false;
            }
            return check;
        }

        //Check Sửa
        Entities.QuyDoiDonViTinh[] kh1;
        Server_Client.Client cl;
        public void CheckConflictUpdate()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.QuyDoiDonViTinh kh = new Entities.QuyDoiDonViTinh("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                kh1 = new Entities.QuyDoiDonViTinh[1];
                networkStream = cl.SerializeObj(this.tcpClient, "QuyDoiDonViTinh", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.QuyDoiDonViTinh[])cl.DeserializeHepper1(networkStream, kh1);
                if (kh1 != null)
                {
                    for (int j = 0; j < kh1.Length; j++)
                    {
                        if (kh1[j].MaQuyDoiDonViTinh == maquydoidvt)
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

         public string Check(Entities.QuyDoiDonViTinh kh)
        {
            try
            {
                string gt = "ok";

                if (mahangquydoi != kh.MaHangQuyDoi)
                {
                    mahangquydoi = txtmahangquydoi.Text = kh.MaHangQuyDoi;
                    gt = "ko";
                }

                if (tenhangquydoi != kh.TenHangQuyDoi)
                {
                    tenhangquydoi = txttenhangquydoi.Text = kh.TenHangQuyDoi;
                    gt = "ko";
                }
                if (donvitinhquydoi != kh.MaDonViTinh)
                {
                    donvitinhquydoi = txtdonvitinhquydoi.Text = kh.MaDonViTinh;
                    gt = "ko";
                }
                
                if (mahangduocquydoi != kh.MaHangDuocQuyDoi)
                {
                    mahangduocquydoi = txtmahangduocquydoi.Text = kh.MaHangDuocQuyDoi;
                    gt = "ko";
                }
                if (tenhangduocquydoi != kh.TenHangDuocQuyDoi)
                {
                    tenhangduocquydoi = txttenhangduocquydoi.Text = kh.TenHangDuocQuyDoi;
                    gt = "ko";
                }
                if (donvitinhduocquydoi != kh.MaDonViTinhDuocQuyDoi)
                {
                    donvitinhduocquydoi = txtdonvitinhduocquydoi.Text = kh.MaDonViTinhDuocQuyDoi;
                    gt = "ko";
                }
                return gt;
            }
            finally
            { }
        }
        #endregion


         private void frmXuLyQuyDoiDonViTinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (ktgiatri == "")
                    frmQuanLyQuyDoiDonViTinh.trave = "A";
            }
            catch { }
        }

        private void txtmahangquydoi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                frmTimHangHoa a = new frmTimHangHoa();
                a.ShowDialog();
                if (frmTimHangHoa.drvr != null)
                {
                    txtmahangquydoi.Text = frmTimHangHoa.drvr.Cells["MaHangHoa"].Value.ToString();
                    txttenhangquydoi.Text = frmTimHangHoa.drvr.Cells["TenHangHoa"].Value.ToString();
                    txtdonvitinhquydoi.Text = frmTimHangHoa.drvr.Cells["TenDonViTinh"].Value.ToString();
                    txtsoluongquydoi.Focus();
                    frmTimHangHoa.drvr = null;
                }
            }
        }

        private void txtmahangduocquydoi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                frmTimHangHoa a = new frmTimHangHoa();
                a.ShowDialog();
                if (frmTimHangHoa.drvr != null)
                {
                    txtmahangduocquydoi.Text = frmTimHangHoa.drvr.Cells["MaHangHoa"].Value.ToString();
                    txttenhangduocquydoi.Text = frmTimHangHoa.drvr.Cells["TenHangHoa"].Value.ToString();
                    txtdonvitinhduocquydoi.Text = frmTimHangHoa.drvr.Cells["TenDonViTinh"].Value.ToString();
                    txtsoluongduocquydoi.Focus();
                    frmTimHangHoa.drvr = null;
                }
            }
        }

        private void txtsoluongduocquydoi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtsoluongduocquydoi.Text) >= 0)
                {
                    txtsoluongduocquydoi.Text = String.Format("{0:0}", txtsoluongduocquydoi.Text);
                    return;
                }
            }
            catch
            {
                txtsoluongduocquydoi.Text = "";
            }
        }

    }
}
