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
    public partial class frmQuanLyGoiHang : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        BizLogic.GoiHang kh;
        public frmQuanLyGoiHang()
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
        public static string trave = "";
        private void tsslblthemmoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 4))
                {
                    MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                    return;
                }
                frmXuLyGoiHang qlkh = new frmXuLyGoiHang("Thu", "Them");
                qlkh.ShowDialog();
                SelectData();
            }
            catch { }
        }

        private void tsslblsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
                {
                    MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                    return;
                }
                for (int j = 0; j < 1000; j++)
                {
                    if (trave == "")
                    {
                        frmXuLyGoiHang qlkh = new frmXuLyGoiHang("Thu", "Sua", dgvHienThi.Rows[i]);
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

        private void tsslbldong_Click(object sender, EventArgs e)
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
            catch
            { }
        }

        Server_Client.Client cl;
        Entities.GoiHang[] kh1;
        Entities.GoiHang[] hienthi;
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData()
        {
            try
            {

                i = 0;
                dgvHienThi.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.GoiHang kh = new Entities.GoiHang();
                // truyền HanhDong
                kh = new Entities.GoiHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                kh1 = new Entities.GoiHang[1];
                clientstrem = cl.SerializeObj(this.client1, "GoiHang", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.GoiHang[])cl.DeserializeHepper1(clientstrem, kh1);
                // lbltongs.Text = kh1.Length.ToString();
                if (kh1 == null)
                {
                    toolStripStatus_Xoa.Enabled = false;
                    hienthi = new Entities.GoiHang[0];
                    dgvHienThi.DataSource = new Entities.GoiHang[0];
                    return;
                }
                toolStripStatus_Xoa.Enabled = true;

                Entities.GoiHang[] pt2 = new Entities.GoiHang[kh1.Length];
                int sotang = 0;
                for (int j = 0; j < kh1.Length; j++)
                {

                    if (kh1[j].Deleted == false)
                    {
                        pt2[sotang] = kh1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.GoiHang[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pt2[j];
                    }
                }
                else
                {
                    dgvHienThi.DataSource = new Entities.GoiHang[0];
                    return;
                }
                dgvHienThi.DataSource = hienthi;
                new Common.Utilities().CountDatagridview(dgvHienThi);

                dgvHienThi.Rows[0].Selected = true;
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvHienThi.ColumnCount; j++)
                    {
                        dgvHienThi.Columns[j].Visible = false;
                    }

                    dgvHienThi.Columns[0].Visible = true;
                    dgvHienThi.Columns[0].HeaderText = "STT";
                    dgvHienThi.Columns["MaGoiHang"].HeaderText = "Mã Gói Hàng";
                    dgvHienThi.Columns["TenGoiHang"].HeaderText = "Tên Gói Hàng";
                    dgvHienThi.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                    dgvHienThi.Columns["GiaBanBuon"].HeaderText = "Giá Bán Buôn";
                    dgvHienThi.Columns["GiaBanLe"].HeaderText = "Giá Bán Lẻ";
                    dgvHienThi.Columns["MaGoiHang"].Visible = true;
                    dgvHienThi.Columns["TenGoiHang"].Visible = true;
                    dgvHienThi.Columns["GiaNhap"].Visible = true;
                    dgvHienThi.Columns["GiaBanBuon"].Visible = true;
                    dgvHienThi.Columns["GiaBanLe"].Visible = true;
                    dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvHienThi.AllowUserToAddRows = false;
                    dgvHienThi.AllowUserToDeleteRows = false;
                    dgvHienThi.AllowUserToResizeRows = false;
                    dgvHienThi.RowHeadersVisible = false;
                }
                catch
                { }
            }
        }

        int i;
        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                i = e.RowIndex;
                if (i >= 0)
                {
                    dgvHienThi.Rows[i].Selected = true;
                }
            }
            catch { }

        }
        private void frmQuanLyGoiHang_Load(object sender, EventArgs e)
        {
            SelectData();
        }
        private void tsslbl_Click(object sender, EventArgs e)
        {
            string maKH = dgvHienThi.Rows[i].Cells["MaGoiHang"].Value.ToString();



            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 3))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (new Check().CheckReference("GH", maKH))
            {
                DialogResult dlgResult = MessageBox.Show("Bạn Có Chắc Chắn muốn Xóa Gói Hàng này không?", "Đồng ý?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.Yes)
                {
                    try
                    {

                        cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                        Entities.GoiHang kh = new Entities.GoiHang();
                        kh = new Entities.GoiHang("Delete", int.Parse(dgvHienThi.Rows[i].Cells["GoiHangID"].Value.ToString()), Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                        clientstrem = cl.SerializeObj(this.client1, "GoiHang", kh);
                        bool kt = false;
                        kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                        if (kt == true)
                        {
                        }
                        //}
                        else
                        {
                            MessageBox.Show("Mã Gói Hàng này đã bị xóa");
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
                MessageBox.Show("mã gói hàng này này không  thể xóa! Hiện tại đang có giao dịch");
            }
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (hienthi != null)
                {

                    if (rdoMakho.Checked == true)
                    {
                        List<Entities.GoiHang> hienthitheoid = new List<Entities.GoiHang>();
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaGoiHang.ToString().ToUpper().IndexOf(txtTimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid.Add(hienthi[i]);
                            }
                        }
                        dgvHienThi.DataSource = hienthitheoid;
                    }
                    if (dbten.Checked == true)
                    {
                        List<Entities.GoiHang> hienthitheoma = new List<Entities.GoiHang>();
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenGoiHang.ToString().ToUpper().IndexOf(txtTimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma.Add(hienthi[i]);
                            }
                        }
                        dgvHienThi.DataSource = hienthitheoma;
                    }
                }
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvHienThi.ColumnCount; j++)
                    {
                        dgvHienThi.Columns[j].Visible = false;
                    }
                    new Common.Utilities().CountDatagridview(dgvHienThi);
                    dgvHienThi.Columns[0].Visible = true;
                    dgvHienThi.Columns[0].HeaderText = "STT";
                    dgvHienThi.Columns["MaGoiHang"].HeaderText = "Mã Gói Hàng";
                    dgvHienThi.Columns["TenGoiHang"].HeaderText = "Tên Gói Hàng";
                    dgvHienThi.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                    dgvHienThi.Columns["GiaBanBuon"].HeaderText = "Giá Bán Buôn";
                    dgvHienThi.Columns["GiaBanLe"].HeaderText = "Giá Bán Lẻ";
                    dgvHienThi.Columns["MaGoiHang"].Visible = true;
                    dgvHienThi.Columns["TenGoiHang"].Visible = true;
                    dgvHienThi.Columns["GiaNhap"].Visible = true;
                    dgvHienThi.Columns["GiaBanBuon"].Visible = true;
                    dgvHienThi.Columns["GiaBanLe"].Visible = true;
                    dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvHienThi.AllowUserToAddRows = false;
                    dgvHienThi.AllowUserToDeleteRows = false;
                    dgvHienThi.AllowUserToResizeRows = false;
                    dgvHienThi.RowHeadersVisible = false;
                }
                catch
                { }
            }
        }
        private void rdbtatca_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (hienthi == null)
                {
                    dgvHienThi.DataSource = new Entities.GoiHang[0];
                    return;
                }
                dgvHienThi.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvHienThi.ColumnCount; j++)
                    {
                        dgvHienThi.Columns[j].Visible = false;
                    }
                    new Common.Utilities().CountDatagridview(dgvHienThi);
                    dgvHienThi.Columns[0].Visible = true;
                    dgvHienThi.Columns[0].HeaderText = "STT";
                    dgvHienThi.Columns["MaGoiHang"].HeaderText = "Mã Gói Hàng";
                    dgvHienThi.Columns["TenGoiHang"].HeaderText = "Tên Gói Hàng";
                    dgvHienThi.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                    dgvHienThi.Columns["GiaBanBuon"].HeaderText = "Giá Bán Buôn";
                    dgvHienThi.Columns["GiaBanLe"].HeaderText = "Giá Bán Lẻ";
                    dgvHienThi.Columns["MaGoiHang"].Visible = true;
                    dgvHienThi.Columns["TenGoiHang"].Visible = true;
                    dgvHienThi.Columns["GiaNhap"].Visible = true;
                    dgvHienThi.Columns["GiaBanBuon"].Visible = true;
                    dgvHienThi.Columns["GiaBanLe"].Visible = true;
                    dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvHienThi.AllowUserToAddRows = false;
                    dgvHienThi.AllowUserToDeleteRows = false;
                    dgvHienThi.AllowUserToResizeRows = false;
                    dgvHienThi.RowHeadersVisible = false;
                }
                catch { }
            }
        }

        private void panelGoiHang_DoubleClick(object sender, EventArgs e)
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

        private void dgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            try
            {
                frmXuLyGoiHang a = new frmXuLyGoiHang("Thu", "Sua", dgvHienThi.Rows[i]);
                a.ShowDialog();
                SelectData();
            }
            catch
            { }
        }

        private void rdbtheoten_CheckedChanged(object sender, EventArgs e)
        {
            txtTimkiem.Text = "";
        }

        private void rdbtheoma_CheckedChanged(object sender, EventArgs e)
        {
            txtTimkiem.Text = "";
        }

        private void toolStripStatusLabel1_Click_1(object sender, EventArgs e)
        {
            SelectData();
        }

        private void rdoTatca_CheckedChanged(object sender, EventArgs e)
        {
            SelectData();
        }
    }
}
