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
    public partial class frmQuanLyDVT : Form
    {
        //Khai báo các hàm
        public TcpClient tcpClient;
        public NetworkStream networkStream;

        public frmQuanLyDVT()
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
        private void frmQuanLyDVT_Load(object sender, EventArgs e)
        {
            SelectData();
            //fix();
        }

        //Đặt tên tiếng việt
        //public void fix()
        //{
        //    dgvDonViTinh.RowHeadersVisible = false;
        //    dgvDonViTinh.Columns[0].Visible = false;
        //    dgvDonViTinh.Columns[dgvDonViTinh.ColumnCount - 1].Visible = false;
        //    dgvDonViTinh.AllowUserToResizeRows = false;
        //    dgvDonViTinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dgvDonViTinh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        //    dgvDonViTinh.ReadOnly = true;

        //    dgvDonViTinh.Columns["DVTID"].HeaderText = "Đơn vị tính ID";
        //    dgvDonViTinh.Columns["MaDonViTinh"].HeaderText = "Mã đơn vị tính";
        //    dgvDonViTinh.Columns["TenDonViTinh"].HeaderText = "Tên đơn vị tính";
        //    dgvDonViTinh.Columns["GhiChu"].HeaderText = "Ghi Chú";
        //}
        Server_Client.Client cl;
        Entities.DVT[] kh1;
        Entities.DVT[] hienthi;
        //Lấy dữ liệu từ Database
        public void SelectData()
        {
            try
            {

                // i = 0;
                dgvDonViTinh.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.DVT kh = new Entities.DVT();
                // truyền HanhDong
                kh = new Entities.DVT("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                kh1 = new Entities.DVT[1];
                networkStream = cl.SerializeObj(this.tcpClient, "DVT", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.DVT[])cl.DeserializeHepper1(networkStream, kh1);
                //lbhienthitongso.Text = kh1.Length.ToString();
                if (kh1 == null)
                {
                    tssXoa.Enabled = false;
                    hienthi = new Entities.DVT[0];
                    dgvDonViTinh.DataSource = new Entities.DVT[0];
                    return;
                }
                tssXoa.Enabled = true;

                Entities.DVT[] pt2 = new Entities.DVT[kh1.Length];
                int sotang = 0;
                for (int j = 0; j < kh1.Length; j++)
                {

                    if (kh1[j].Deleted == false)
                    {
                        pt2[sotang] = kh1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.DVT[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pt2[j];
                    }
                }
                else
                {
                    dgvDonViTinh.DataSource = new Entities.DVT[0];
                    return;
                }
                dgvDonViTinh.DataSource = hienthi;
                new Common.Utilities().CountDatagridview(dgvDonViTinh);

                dgvDonViTinh.Rows[0].Selected = true;
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvDonViTinh.ColumnCount; j++)
                    {
                        dgvDonViTinh.Columns[j].Visible = false;
                    }
                    dgvDonViTinh.Columns[0].Visible = true;
                    dgvDonViTinh.Columns[0].HeaderText = "STT";
                    dgvDonViTinh.Columns["MaDonViTinh"].HeaderText = "Mã Đơn Vị Tính";
                    dgvDonViTinh.Columns["TenDonViTinh"].HeaderText = "Tên Đơn Vị Tính";
                    dgvDonViTinh.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvDonViTinh.Columns["MaDonViTinh"].Visible = true;
                    dgvDonViTinh.Columns["TenDonViTinh"].Visible = true;
                    dgvDonViTinh.Columns["GhiChu"].Visible = true;
                    dgvDonViTinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvDonViTinh.AllowUserToAddRows = false;
                    dgvDonViTinh.AllowUserToDeleteRows = false;
                    dgvDonViTinh.AllowUserToResizeRows = false;
                }
                catch { }
            }
        }
        public static string trave = "";
        private void tssThem_Click(object sender, EventArgs e)
        {

            try
            {
                if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 3))
                {
                    MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                    return;
                }
                for (int j = 0; j < 1000; j++)
                {
                    if (trave == "")
                    {
                        frmXuLyDonViTinh qlkh = new frmXuLyDonViTinh("Thu", "Them");
                        qlkh.ShowDialog();
                        SelectData();
                    }
                    else
                    {
                        trave = "";
                        break;
                    }
                }
            }
            catch { }
        }
        int i;
        private void tssSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 3))
                {
                    MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                    return;
                }
                for (int j = 0; j < 1000; j++)
                {
                    if (trave == "")
                    {
                        frmXuLyDonViTinh qlkh = new frmXuLyDonViTinh("Thu", "Sua", dgvDonViTinh.Rows[i]);
                        qlkh.ShowDialog();
                        SelectData();
                    }
                    else
                    {
                        trave = "";
                        break;
                    }
                }
            }
            catch { }
        }
        public bool CheckQuyen(string tenform, int quyen)
        {
            switch (quyen)
            {
                case 1:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenXem;
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenSua;
                        }
                        break;
                    }
                case 3:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenXoa;
                        }
                        break;
                    }
                case 4:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenThem;
                        }
                        break;
                    }
            }
            return false;
        }
        //Xóa Data trên Data Grid View
        #region Xử lý khi Delete
        private void tssXoa_Click(object sender, EventArgs e)
        {
            string maKH = dgvDonViTinh.Rows[i].Cells["MaDonViTinh"].Value.ToString();
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 3))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (new Check().CheckReference("DVT", maKH))
            {
                DialogResult dlgResult = MessageBox.Show("Bạn Có Chắc Chắn muốn Xóa  không?", "Đồng ý?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.Yes)
                {
                    try
                    {
                        bool ktdelete = false;
                        int idcurent = int.Parse(dgvDonViTinh.Rows[i].Cells["DVTID"].Value.ToString());
                        SelectData();
                        for (int j = 0; j < kh1.Length; j++)
                        {
                            if (kh1[j].Deleted == false)
                                if (kh1[j].DVTID == idcurent)
                                {
                                    ktdelete = true;
                                    break;
                                }
                        }
                        if (ktdelete == true)
                        {
                            cl = new Server_Client.Client();
                            this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);

                            Entities.DVT kh = new Entities.DVT();
                            kh = new Entities.DVT("Delete", idcurent, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                            networkStream = cl.SerializeObj(this.tcpClient, "DVT", kh);
                            bool kt = false;
                            kt = (bool)cl.DeserializeHepper(networkStream, kt);
                            if (kt == true)
                            {
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đơn vị tính này đã bị xóa");
                        }
                        SelectData();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            else
            {
                MessageBox.Show("Đơn vị tính này không thể xóa! Hiện tại đang có giao dịch");
            }
        }
        #endregion

        //In
        private void tssIn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa xử lý");
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

        private void dgvDonViTinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                i = e.RowIndex;
                if (i >= 0)
                {
                    dgvDonViTinh.Rows[i].Selected = true;
                }
            }
            catch
            { }
        }
        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
        }
        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbtatca.Checked == true)
                {
                    return;
                }
                if (txttimkiem.Text.Length == 0)
                {
                    dgvDonViTinh.DataSource = new Entities.DVT[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtheoma.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenDonViTinh.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dgvDonViTinh.DataSource = new Entities.DVT[0];
                            return;
                        }
                        Entities.DVT[] hienthitheoid = new Entities.DVT[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenDonViTinh.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dgvDonViTinh.DataSource = hienthitheoid;
                    }
                    if (rdbtheoten.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaDonViTinh.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dgvDonViTinh.DataSource = new Entities.DVT[0];
                            return;
                        }
                        Entities.DVT[] hienthitheoma = new Entities.DVT[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaDonViTinh.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dgvDonViTinh.DataSource = hienthitheoma;
                    }
                }
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvDonViTinh.ColumnCount; j++)
                    {
                        dgvDonViTinh.Columns[j].Visible = false;
                    }
                    new Common.Utilities().CountDatagridview(dgvDonViTinh);
                    dgvDonViTinh.Columns[0].Visible = true;
                    dgvDonViTinh.Columns[0].HeaderText = "STT";
                    dgvDonViTinh.Columns["MaDonViTinh"].HeaderText = "Mã Đơn Vị Tính";
                    dgvDonViTinh.Columns["TenDonViTinh"].HeaderText = "Tên Đơn Vị Tính";
                    dgvDonViTinh.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvDonViTinh.Columns["MaDonViTinh"].Visible = true;
                    dgvDonViTinh.Columns["TenDonViTinh"].Visible = true;
                    dgvDonViTinh.Columns["GhiChu"].Visible = true;
                    dgvDonViTinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvDonViTinh.AllowUserToAddRows = false;
                    dgvDonViTinh.AllowUserToDeleteRows = false;
                    dgvDonViTinh.AllowUserToResizeRows = false;
                    dgvDonViTinh.RowHeadersVisible = false;
                }
                catch { }
            }
        }

        private void rdbtatca_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (hienthi == null)
                {
                    dgvDonViTinh.DataSource = new Entities.DVT[0];
                    return;
                }
                dgvDonViTinh.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvDonViTinh.ColumnCount; j++)
                    {
                        dgvDonViTinh.Columns[j].Visible = false;
                    }
                    new Common.Utilities().CountDatagridview(dgvDonViTinh);
                    dgvDonViTinh.Columns[0].Visible = true;
                    dgvDonViTinh.Columns[0].HeaderText = "STT";
                    dgvDonViTinh.Columns["MaDonViTinh"].HeaderText = "Mã Đơn Vị Tính";
                    dgvDonViTinh.Columns["TenDonViTinh"].HeaderText = "Tên Đơn Vị Tính";
                    dgvDonViTinh.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvDonViTinh.Columns["MaDonViTinh"].Visible = true;
                    dgvDonViTinh.Columns["TenDonViTinh"].Visible = true;
                    dgvDonViTinh.Columns["GhiChu"].Visible = true;
                    dgvDonViTinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvDonViTinh.AllowUserToAddRows = false;
                    dgvDonViTinh.AllowUserToDeleteRows = false;
                    dgvDonViTinh.AllowUserToResizeRows = false;
                    dgvDonViTinh.RowHeadersVisible = false;
                }
                catch { }
            }
        }

        private void dgvDonViTinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            try
            {
                frmXuLyDonViTinh a = new frmXuLyDonViTinh("Thu", "Sua", dgvDonViTinh.Rows[i]);
                a.ShowDialog();
                SelectData();
            }
            catch
            { }
        }

        private void rdbtheoten_CheckedChanged(object sender, EventArgs e)
        {
            txttimkiem.Text = "";

        }

        private void rdbtheoma_CheckedChanged(object sender, EventArgs e)
        {
            txttimkiem.Text = "";
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            SelectData();
        }

    }
}
