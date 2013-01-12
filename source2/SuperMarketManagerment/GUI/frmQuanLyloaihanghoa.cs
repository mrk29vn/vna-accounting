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
    public partial class frmQuanLyLoaiHangHoa : Form
    {
        //Khai báo các hàm
        public TcpClient client1;
        public NetworkStream networkStream;

        public frmQuanLyLoaiHangHoa()
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
        private void frmQuanLyloaihanghoa_Load(object sender, EventArgs e)
        {
            SelectData();
            //fix();
        }

        //Đặt tên tiếng việt
        //public void fix()
        //{
        //    try
        //    {
        //        dgvQuanLyLoaiHangHoa.RowHeadersVisible = false;
        //       // dgvQuanLyLoaiHangHoa.Columns[0].Visible = false;
        //        // dgvQuanLyLoaiHangHoa.Columns[dgvQuanLyLoaiHangHoa.ColumnCount - 1].Visible = false;
        //        dgvQuanLyLoaiHangHoa.AllowUserToResizeRows = false;
        //        dgvQuanLyLoaiHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //        dgvQuanLyLoaiHangHoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        //        dgvQuanLyLoaiHangHoa.ReadOnly = true;

        //        dgvQuanLyLoaiHangHoa.Columns["HanhDong"].HeaderText = "STT";
        //        dgvQuanLyLoaiHangHoa.Columns["MaLoaiHang"].HeaderText = "Mã Loại Hàng";
        //        dgvQuanLyLoaiHangHoa.Columns["TenLoaiHang"].HeaderText = "Tên Loại Hàng";
        //        dgvQuanLyLoaiHangHoa.Columns["GhiChu"].HeaderText = "Ghi Chú";
        //    }
        //    catch { }
        //}


        //public frmQuanLyLoaiHangHoa()
        //{
        //    InitializeComponent();
        //}
        Server_Client.Client cl;
        Entities.LoaiHangHoa[] kh1;
        Entities.LoaiHangHoa[] hienthi;
        //Lấy dữ liệu từ Database
        public void SelectData()
        {
            try
            {

                i = 0;
                dgvQuanLyLoaiHangHoa.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LoaiHangHoa kh = new Entities.LoaiHangHoa();
                // truyền HanhDong
                kh = new Entities.LoaiHangHoa("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                kh1 = new Entities.LoaiHangHoa[1];
                networkStream = cl.SerializeObj(this.client1, "LoaiHangHoa", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.LoaiHangHoa[])cl.DeserializeHepper1(networkStream, kh1);
                //lbhienthitongso.Text = kh1.Length.ToString();
                if (kh1 == null)
                {
                    tssXoa.Enabled = false;
                    hienthi = new Entities.LoaiHangHoa[0];
                    dgvQuanLyLoaiHangHoa.DataSource = new Entities.LoaiHangHoa[0];
                    return;
                }
                tssXoa.Enabled = true;

                Entities.LoaiHangHoa[] pt2 = new Entities.LoaiHangHoa[kh1.Length];
                int sotang = 0;
                for (int j = 0; j < kh1.Length; j++)
                {

                    if (kh1[j].Deleted == false)
                    {
                        pt2[sotang] = kh1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.LoaiHangHoa[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pt2[j];
                    }
                }
                else
                {
                    dgvQuanLyLoaiHangHoa.DataSource = new Entities.LoaiHangHoa[0];
                    return;
                }
                dgvQuanLyLoaiHangHoa.DataSource = hienthi;
                new Common.Utilities().CountDatagridview(dgvQuanLyLoaiHangHoa);

                dgvQuanLyLoaiHangHoa.Rows[0].Selected = true;
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvQuanLyLoaiHangHoa.ColumnCount; j++)
                    {
                        dgvQuanLyLoaiHangHoa.Columns[j].Visible = false;
                    }
                    new Common.Utilities().CountDatagridview(dgvQuanLyLoaiHangHoa);
                    dgvQuanLyLoaiHangHoa.Columns[0].Visible = true;
                    dgvQuanLyLoaiHangHoa.Columns[0].HeaderText = "STT";
                    dgvQuanLyLoaiHangHoa.Columns["MaLoaiHang"].HeaderText = "Mã Loại Hàng";
                    dgvQuanLyLoaiHangHoa.Columns["TenLoaiHang"].HeaderText = "Tên Loại Hàng";
                    dgvQuanLyLoaiHangHoa.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvQuanLyLoaiHangHoa.Columns["MaLoaiHang"].Visible = true;
                    dgvQuanLyLoaiHangHoa.Columns["TenLoaiHang"].Visible = true;
                    dgvQuanLyLoaiHangHoa.Columns["GhiChu"].Visible = true;
                    dgvQuanLyLoaiHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvQuanLyLoaiHangHoa.AllowUserToAddRows = false;
                    dgvQuanLyLoaiHangHoa.AllowUserToDeleteRows = false;
                    dgvQuanLyLoaiHangHoa.AllowUserToResizeRows = false;
                }
                catch { }
            }
        }
        int i;
        //Hiển thị form Thêm Loại Hàng Hóa
        public static string trave = "";
        private void toolStripStatus_ThemMoi_Click(object sender, EventArgs e)
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
                        frmXuLyLoaiHangHoa qlkh = new frmXuLyLoaiHangHoa("Thu", "Them");
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

        //Hiển thị form Sửa Loại Hàng Hóa
        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
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
                        frmXuLyLoaiHangHoa qlkh = new frmXuLyLoaiHangHoa("Thu", "Sua", dgvQuanLyLoaiHangHoa.Rows[i]);
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

        //Xóa Data trên Data Grid View
        #region Xử lý khi Delete
        private void tssXoa_Click(object sender, EventArgs e)
        {
            string maKH = dgvQuanLyLoaiHangHoa.Rows[i].Cells["MaLoaiHang"].Value.ToString();

            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 3))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (new Check().CheckReference("LoaiHangHoa", maKH))
            {
                DialogResult dlgResult = MessageBox.Show("Bạn Có Chắc Chắn muốn Xóa Loại Hàng Hóa này không?", "Đồng ý?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.Yes)
                {
                    try
                    {
                        bool ktdelete = false;
                        int idcurent = int.Parse(dgvQuanLyLoaiHangHoa.Rows[i].Cells["LoaiHangID"].Value.ToString());
                        SelectData();
                        for (int j = 0; j < kh1.Length; j++)
                        {
                            if (kh1[j].Deleted == false)
                                if (kh1[j].LoaiHangID == idcurent)
                                {
                                    ktdelete = true;
                                    break;
                                }
                        }
                        if (ktdelete == true)
                        {
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                            Entities.LoaiHangHoa kh = new Entities.LoaiHangHoa();
                            kh = new Entities.LoaiHangHoa("Delete", idcurent, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                            networkStream = cl.SerializeObj(this.client1, "LoaiHangHoa", kh);
                            bool kt = false;
                            kt = (bool)cl.DeserializeHepper(networkStream, kt);
                            if (kt == true)
                            {
                            }
                        }
                        else
                        {
                            MessageBox.Show("Loại Hàng này đã bị xóa");
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
                MessageBox.Show("Loại hàng này không thể xóa! Hiện đang có giao dịch");
            }
        }
        #endregion

        //Đóng form
        private void toolStripStatus_Dong_Click(object sender, EventArgs e)
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
                    dgvQuanLyLoaiHangHoa.DataSource = new Entities.LoaiHangHoa[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtheoma.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenLoaiHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dgvQuanLyLoaiHangHoa.DataSource = new Entities.LoaiHangHoa[0];
                            return;
                        }
                        Entities.LoaiHangHoa[] hienthitheoid = new Entities.LoaiHangHoa[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenLoaiHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dgvQuanLyLoaiHangHoa.DataSource = hienthitheoid;
                    }
                    if (rdbtheoten.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaLoaiHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dgvQuanLyLoaiHangHoa.DataSource = new Entities.LoaiHangHoa[0];
                            return;
                        }
                        Entities.LoaiHangHoa[] hienthitheoma = new Entities.LoaiHangHoa[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaLoaiHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dgvQuanLyLoaiHangHoa.DataSource = hienthitheoma;
                    }
                }
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvQuanLyLoaiHangHoa.ColumnCount; j++)
                    {
                        dgvQuanLyLoaiHangHoa.Columns[j].Visible = false;
                    }
                    new Common.Utilities().CountDatagridview(dgvQuanLyLoaiHangHoa);
                    dgvQuanLyLoaiHangHoa.Columns[0].Visible = true;
                    dgvQuanLyLoaiHangHoa.Columns[0].HeaderText = "STT";
                    dgvQuanLyLoaiHangHoa.Columns["MaLoaiHang"].HeaderText = "Mã Loại Hàng";
                    dgvQuanLyLoaiHangHoa.Columns["TenLoaiHang"].HeaderText = "Tên Loại Hàng";
                    dgvQuanLyLoaiHangHoa.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvQuanLyLoaiHangHoa.Columns["MaLoaiHang"].Visible = true;
                    dgvQuanLyLoaiHangHoa.Columns["TenLoaiHang"].Visible = true;
                    dgvQuanLyLoaiHangHoa.Columns["GhiChu"].Visible = true;
                    dgvQuanLyLoaiHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvQuanLyLoaiHangHoa.AllowUserToAddRows = false;
                    dgvQuanLyLoaiHangHoa.AllowUserToDeleteRows = false;
                    dgvQuanLyLoaiHangHoa.AllowUserToResizeRows = false;
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
                    dgvQuanLyLoaiHangHoa.DataSource = new Entities.LoaiHangHoa[0];
                    return;
                }
                dgvQuanLyLoaiHangHoa.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvQuanLyLoaiHangHoa.ColumnCount; j++)
                    {
                        dgvQuanLyLoaiHangHoa.Columns[j].Visible = false;
                    }
                    new Common.Utilities().CountDatagridview(dgvQuanLyLoaiHangHoa);
                    dgvQuanLyLoaiHangHoa.Columns[0].Visible = true;
                    dgvQuanLyLoaiHangHoa.Columns[0].HeaderText = "STT";
                    dgvQuanLyLoaiHangHoa.Columns["MaLoaiHang"].HeaderText = "Mã Loại Hàng";
                    dgvQuanLyLoaiHangHoa.Columns["TenLoaiHang"].HeaderText = "Tên Loại Hàng";
                    dgvQuanLyLoaiHangHoa.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvQuanLyLoaiHangHoa.Columns["MaLoaiHang"].Visible = true;
                    dgvQuanLyLoaiHangHoa.Columns["TenLoaiHang"].Visible = true;
                    dgvQuanLyLoaiHangHoa.Columns["GhiChu"].Visible = true;
                    dgvQuanLyLoaiHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvQuanLyLoaiHangHoa.AllowUserToAddRows = false;
                    dgvQuanLyLoaiHangHoa.AllowUserToDeleteRows = false;
                    dgvQuanLyLoaiHangHoa.AllowUserToResizeRows = false;
                }
                catch { }
            }
        }

        private void dgvQuanLyLoaiHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                i = e.RowIndex;
                if (i >= 0)
                {
                    dgvQuanLyLoaiHangHoa.Rows[i].Selected = true;
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

        private void dgvQuanLyLoaiHangHoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            try
            {
                frmXuLyLoaiHangHoa a = new frmXuLyLoaiHangHoa("Thu", "Sua", dgvQuanLyLoaiHangHoa.Rows[i]);
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
