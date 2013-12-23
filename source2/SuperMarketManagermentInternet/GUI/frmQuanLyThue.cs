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
    public partial class frmQuanLyThue : Form
    {
        public TcpClient tcpClient;
        public NetworkStream networkStream;
        public frmQuanLyThue()
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
        Server_Client.Client cl;
        Entities.Thue[] kh1;
        Entities.Thue[] hienthi;
        //Lấy dữ liệu từ Database
        public void SelectData()
        {
            try
            {

                // i = 0;
                dgvThue.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.Thue kh = new Entities.Thue();
                // truyền HanhDong
                kh = new Entities.Thue("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                kh1 = new Entities.Thue[1];
                networkStream = cl.SerializeObj(this.tcpClient, "ThueH", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.Thue[])cl.DeserializeHepper1(networkStream, kh1);
                //lbhienthitongso.Text = kh1.Length.ToString();
                if (kh1 == null)
                {
                    tsslblxoa.Enabled = false;
                    hienthi = new Entities.Thue[0];
                    dgvThue.DataSource = new Entities.Thue[0];
                    return;
                }
                tsslblxoa.Enabled = true;

                Entities.Thue[] pt2 = new Entities.Thue[kh1.Length];
                int sotang = 0;
                for (int j = 0; j < kh1.Length; j++)
                {

                    if (kh1[j].Deleted == false)
                    {
                        pt2[sotang] = kh1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.Thue[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pt2[j];
                    }
                }
                else
                {
                    dgvThue.DataSource = new Entities.Thue[0];
                    return;
                }
                dgvThue.DataSource = hienthi;
                new Common.Utilities().CountDatagridview(dgvThue);

                dgvThue.Rows[0].Selected = true;
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvThue.ColumnCount; j++)
                    {
                        dgvThue.Columns[j].Visible = false;
                    }
                    dgvThue.Columns[0].Visible = true;
                    dgvThue.Columns[0].HeaderText = "STT";
                    dgvThue.Columns["MaThue"].HeaderText = "Mã Thuế";
                    dgvThue.Columns["GiaTriThue"].HeaderText = "Giá Trị Thuế";
                    dgvThue.Columns["TenThue"].HeaderText = "Tên Thuế";
                    dgvThue.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvThue.Columns["MaThue"].Visible = true;
                    dgvThue.Columns["GiaTriThue"].Visible = true;
                    dgvThue.Columns["TenThue"].Visible = true;
                    dgvThue.Columns["GhiChu"].Visible = true;
                    dgvThue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvThue.AllowUserToAddRows = false;
                    dgvThue.AllowUserToDeleteRows = false;
                    dgvThue.AllowUserToResizeRows = false;
                }
                catch {
                    MessageBox.Show("Xuất hiện lỗi");
                }
            }
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
                    dgvThue.DataSource = new Entities.Thue[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtheoma.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenThue.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dgvThue.DataSource = new Entities.Thue[0];
                            return;
                        }
                        Entities.Thue[] hienthitheoid = new Entities.Thue[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenThue.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dgvThue.DataSource = hienthitheoid;
                    }
                    if (rdbtheoten.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaThue.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dgvThue.DataSource = new Entities.Thue[0];
                            return;
                        }
                        Entities.Thue[] hienthitheoma = new Entities.Thue[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaThue.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dgvThue.DataSource = hienthitheoma;
                    }
                }
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvThue.ColumnCount; j++)
                    {
                        dgvThue.Columns[j].Visible = false;
                    }
                    new Common.Utilities().CountDatagridview(dgvThue);
                    dgvThue.Columns[0].Visible = true;
                    dgvThue.Columns[0].HeaderText = "STT";
                    dgvThue.Columns["MaThue"].HeaderText = "Mã Thuế";
                    dgvThue.Columns["GiaTriThue"].HeaderText = "Giá Trị Thuế";
                    dgvThue.Columns["TenThue"].HeaderText = "Tên Thuế";
                    dgvThue.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvThue.Columns["MaThue"].Visible = true;
                    dgvThue.Columns["GiaTriThue"].Visible = true;
                    dgvThue.Columns["TenThue"].Visible = true;
                    dgvThue.Columns["GhiChu"].Visible = true;
                    dgvThue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvThue.AllowUserToAddRows = false;
                    dgvThue.AllowUserToDeleteRows = false;
                    dgvThue.AllowUserToResizeRows = false;
                    dgvThue.RowHeadersVisible = false;
                }
                catch {
                    MessageBox.Show("Xuất hiện lỗi");
                }
            }
        }

        private void rdbtatca_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (hienthi == null)
                {
                    dgvThue.DataSource = new Entities.Thue[0];
                    return;
                }
                dgvThue.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvThue.ColumnCount; j++)
                    {
                        dgvThue.Columns[j].Visible = false;
                    }
                    new Common.Utilities().CountDatagridview(dgvThue);
                    dgvThue.Columns[0].Visible = true;
                    dgvThue.Columns[0].HeaderText = "STT";
                    dgvThue.Columns["MaThue"].HeaderText = "Mã Thuế";
                    dgvThue.Columns["GiaTriThue"].HeaderText = "Giá Trị Thuế";
                    dgvThue.Columns["TenThue"].HeaderText = "Tên Thuế";
                    dgvThue.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvThue.Columns["MaThue"].Visible = true;
                    dgvThue.Columns["GiaTriThue"].Visible = true;
                    dgvThue.Columns["TenThue"].Visible = true;
                    dgvThue.Columns["GhiChu"].Visible = true;
                    dgvThue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvThue.AllowUserToAddRows = false;
                    dgvThue.AllowUserToDeleteRows = false;
                    dgvThue.AllowUserToResizeRows = false;
                    dgvThue.RowHeadersVisible = false;
                }
                catch {
                    MessageBox.Show("Xuất hiện lỗi");
                }
            }
        }
        int i;
        private void dgvThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                i = e.RowIndex;
                if (i >= 0)
                {
                    dgvThue.Rows[i].Selected = true;
                }
            }
            catch
            { }
        }

        private void dgvThue_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            try
            {
                frmXuLyThue a = new frmXuLyThue("Thu", "Sua", dgvThue.Rows[i]);
                a.ShowDialog();
                SelectData();
            }
            catch
            { }
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

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
        }
        public static string trave = "";     
        private void frmQuanLyThue_Load(object sender, EventArgs e)
        {
            SelectData();
        }

        private void tsslblthem_Click(object sender, EventArgs e)
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
                        frmXuLyThue qlkh = new frmXuLyThue("Thu", "Them");
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

        private void tsslblsua_Click(object sender, EventArgs e)
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
                        frmXuLyThue qlkh = new frmXuLyThue("Thu", "Sua", dgvThue.Rows[i]);
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
            catch {
            }
        }

        private void tsslblxoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maKH = dgvThue.Rows[i].Cells["MaThue"].Value.ToString();
                if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 3))
                {
                    MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                    return;
                }
                if (new Check().CheckReference("Thue", maKH))
                {
                    DialogResult dlgResult = MessageBox.Show("Bạn Có Chắc Chắn muốn Xóa  không?", "Đồng ý?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.Yes)
                    {
                        
                            bool ktdelete = false;
                            int idcurent = int.Parse(dgvThue.Rows[i].Cells["ThueID"].Value.ToString());
                            SelectData();
                            for (int j = 0; j < kh1.Length; j++)
                            {
                                if (kh1[j].Deleted == false)
                                    if (kh1[j].ThueID == idcurent)
                                    {
                                        ktdelete = true;
                                        break;
                                    }
                            }
                            if (ktdelete == true)
                            {
                                cl = new Server_Client.Client();
                                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);

                                Entities.Thue kh = new Entities.Thue();
                                kh = new Entities.Thue("Delete", idcurent, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                                networkStream = cl.SerializeObj(this.tcpClient, "ThueH", kh);
                                bool kt = false;
                                kt = (bool)cl.DeserializeHepper(networkStream, kt);
                                if (kt == true)
                                {
                                }
                            }
                            else
                            {
                                MessageBox.Show("Thuế này đã bị xóa");
                            }
                            SelectData();
                       
                    }
                }
                else
                {
                    MessageBox.Show("Thuế này không thể xóa! Hiện tại đang có giao dịch");
                }
            }
            catch { }
        }

        private void tsslbldong_Click(object sender, EventArgs e)
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
