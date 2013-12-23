using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BizLogic;
using DAL;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
namespace GUI
{
    public partial class frmQuanLyNhaCungCap : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        BizLogic.NhaCungCap ncc;
        public static string trave="";
        public frmQuanLyNhaCungCap()
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
        private void tsslblthemmoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 4))
                {
                    MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                    return;
                }
                for (int j = 0; j < 1000; j++)
                {
                    if (trave == "")
                    {
                        frmXuLyNhaCungCap qlncc = new frmXuLyNhaCungCap("Thu", "Them");
                        qlncc.ShowDialog();
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

        private void tssllsua_Click(object sender, EventArgs e)
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
                        frmXuLyNhaCungCap qlncc = new frmXuLyNhaCungCap("Thu", "Sua", dgvNCC.Rows[i]);
                        qlncc.ShowDialog();
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

        private void tsslbltrove_Click(object sender, EventArgs e)
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

        private void frmQuanLyNhaCungCap_Load(object sender, EventArgs e)
        {
            SelectData();
          
        }
        Server_Client.Client cl;        
        Entities.NhaCungCap[] ncc1;
        Entities.NhaCungCap[] hienthi;
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData()
        {
            try
            {
                i = 0;
                dgvNCC.RowHeadersVisible = false;
                 cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.NhaCungCap  ncc = new Entities.NhaCungCap();
                // truyền HanhDong
                ncc = new Entities.NhaCungCap("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                 ncc1 = new Entities.NhaCungCap[1];
                clientstrem = cl.SerializeObj(this.client1, "NhaCungCap", ncc);
                // đổ mảng đối tượng vào datagripview             
                ncc1 = (Entities.NhaCungCap[])cl.DeserializeHepper1(clientstrem, ncc1);
                if (ncc1 == null)
                {
                    tsslblxoa.Enabled = false;
                    hienthi = new Entities.NhaCungCap[0];
                    dgvNCC.DataSource = new Entities.NhaCungCap[0];
                    return;
                }
                tsslblxoa.Enabled = true;

                Entities.NhaCungCap[] pt2 = new Entities.NhaCungCap[ncc1.Length];
                int sotang = 0;
                for (int j = 0; j < ncc1.Length; j++)
                {

                    if (ncc1[j].Deleted == false)
                    {
                        pt2[sotang] = ncc1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.NhaCungCap[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pt2[j];
                    }
                }
                else
                {
                    dgvNCC.DataSource = new Entities.NhaCungCap[0];
                    return;
                }
                dgvNCC.DataSource = hienthi;
                new Common.Utilities().CountDatagridview(dgvNCC);

                dgvNCC.Rows[0].Selected = true;
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvNCC.ColumnCount; j++)
                    {
                        dgvNCC.Columns[j].Visible = false;
                    }
                    //dgvNCC.Columns[0].Visible = false;
                    dgvNCC.Columns[0].Visible = true;
                    dgvNCC.Columns[0].HeaderText = "STT";
                    dgvNCC.Columns["MaNhaCungCap"].Visible = true;
                    dgvNCC.Columns["MaNhaCungCap"].HeaderText = "Mã Nhà Cung Cấp";
                    dgvNCC.Columns["TenNhaCungCap"].Visible = true;
                    dgvNCC.Columns["TenNhaCungCap"].HeaderText = "Tên Nhà Cung Cấp";
                    dgvNCC.Columns["DiaChi"].Visible = true;
                    dgvNCC.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvNCC.Columns["DienThoai"].Visible = true;
                    dgvNCC.Columns["DienThoai"].HeaderText = "Điện Thoại";
                    dgvNCC.Columns["MST"].Visible = true;
                    dgvNCC.Columns["MST"].HeaderText = "Mã Số Thuế";
                    dgvNCC.Columns["GhiChu"].Visible = true;
                    dgvNCC.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvNCC.AllowUserToAddRows = false;
                    dgvNCC.AllowUserToDeleteRows = false;
                    dgvNCC.AllowUserToResizeRows = false;
                }
                catch
                { }
            }
        }

        int i;
        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                i = e.RowIndex;
                if (i >= 0)
                {
                    dgvNCC.Rows[i].Selected = true;
                }
            }
            catch
            { }
        }
        private void tsslblxoa_Click(object sender, EventArgs e)
        {
            string maKH = dgvNCC.Rows[i].Cells["MaNhaCungCap"].Value.ToString();

            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 3))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (new Check().CheckReference("NhaCungCap", maKH))
            {
                DialogResult dlgResult = MessageBox.Show("Bạn Có Chắc Chắn muốn Xóa Nhà Cung Cấp này không?", "Đồng ý?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.Yes)
                {
                    try
                    {
                        //bool ktdelete = false;
                        //int idcurent = int.Parse(dgvNCC.Rows[i].Cells["NhaCungCapID"].Value.ToString());
                        //SelectData();
                        //for (int j = 0; j < ncc1.Length; j++)
                        //{
                        //    if (ncc1[j].Deleted == false)
                        //        if (ncc1[j].NhaCungCapID == idcurent)
                        //        {
                        //            ktdelete = true;
                        //            break;
                        //        }
                        //}
                        //if (ktdelete == true)
                        //{
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                            Entities.NhaCungCap ncc = new Entities.NhaCungCap();
                            ncc = new Entities.NhaCungCap("Delete", int.Parse(dgvNCC.Rows[i].Cells["NhaCungCapID"].Value.ToString()), Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                            clientstrem = cl.SerializeObj(this.client1, "NhaCungCap", ncc);
                            bool kt = false;
                            kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                            if (kt == true)
                            {
                            }
                        //}
                        else
                        {
                            MessageBox.Show("Nhà Cung Cấp này đã bị xóa");
                        }
                        SelectData();
                    }
                    catch
                    {

                    }

                }
            }
            else
            {
                MessageBox.Show("Nhà Cung Cấp này không thể xóa ! Hiện tại đang có giao dịch");
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
                    dgvNCC.DataSource = new Entities.NhaCungCap[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtheoma.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenNhaCungCap.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dgvNCC.DataSource = new Entities.NhaCungCap[0];
                            return;
                        }
                        Entities.NhaCungCap[] hienthitheoid = new Entities.NhaCungCap[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenNhaCungCap.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dgvNCC.DataSource = hienthitheoid;
                    }
                    if (rdbtheoten.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaNhaCungCap.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dgvNCC.DataSource = new Entities.NhaCungCap[0];
                            return;
                        }
                        Entities.NhaCungCap[] hienthitheoma = new Entities.NhaCungCap[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaNhaCungCap.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dgvNCC.DataSource = hienthitheoma;
                    }
                }
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvNCC.ColumnCount; j++)
                    {
                        dgvNCC.Columns[j].Visible = false;
                    }
                    new Common.Utilities().CountDatagridview(dgvNCC);
                   //dgvNCC.Columns[0].Visible = false;
                    dgvNCC.Columns[0].Visible = true;
                    dgvNCC.Columns[0].HeaderText = "STT";
                    dgvNCC.Columns["MaNhaCungCap"].Visible = true;
                    dgvNCC.Columns["MaNhaCungCap"].HeaderText = "Mã Nhà Cung Cấp";
                    dgvNCC.Columns["TenNhaCungCap"].Visible = true;
                    dgvNCC.Columns["TenNhaCungCap"].HeaderText = "Tên Nhà Cung Cấp";
                    dgvNCC.Columns["DiaChi"].Visible = true;
                    dgvNCC.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvNCC.Columns["DienThoai"].Visible = true;
                    dgvNCC.Columns["DienThoai"].HeaderText = "Điện Thoại";
                    dgvNCC.Columns["MST"].Visible = true;
                    dgvNCC.Columns["MST"].HeaderText = "Mã Số Thuế";
                    dgvNCC.Columns["GhiChu"].Visible = true;
                    dgvNCC.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvNCC.AllowUserToAddRows = false;
                    dgvNCC.AllowUserToDeleteRows = false;
                    dgvNCC.AllowUserToResizeRows = false;
                    dgvNCC.RowHeadersVisible = false;
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
                    dgvNCC.DataSource = new Entities.NhaCungCap[0];
                    return;
                }
                dgvNCC.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvNCC.ColumnCount; j++)
                    {
                        dgvNCC.Columns[j].Visible = false;
                    }
                    new Common.Utilities().CountDatagridview(dgvNCC);
                   // dgvNCC.Columns[0].Visible = false;
                    dgvNCC.Columns[0].Visible = true;
                    dgvNCC.Columns[0].HeaderText = "STT";
                    dgvNCC.Columns["MaNhaCungCap"].Visible = true;
                    dgvNCC.Columns["MaNhaCungCap"].HeaderText = "Mã Nhà Cung Cấp";
                    dgvNCC.Columns["TenNhaCungCap"].Visible = true;
                    dgvNCC.Columns["TenNhaCungCap"].HeaderText = "Tên Nhà Cung Cấp";
                    dgvNCC.Columns["DiaChi"].Visible = true;
                    dgvNCC.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvNCC.Columns["DienThoai"].Visible = true;
                    dgvNCC.Columns["DienThoai"].HeaderText = "Điện Thoại";
                    dgvNCC.Columns["MST"].Visible = true;
                    dgvNCC.Columns["MST"].HeaderText = "Mã Số Thuế";
                    dgvNCC.Columns["GhiChu"].Visible = true;
                    dgvNCC.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvNCC.AllowUserToAddRows = false;
                    dgvNCC.AllowUserToDeleteRows = false;
                    dgvNCC.AllowUserToResizeRows = false;
                    dgvNCC.RowHeadersVisible = false;
                }
                catch
                { }
            }
        }

        private void panelNCC_DoubleClick(object sender, EventArgs e)
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

        private void dgvNCC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            try
            {
                frmXuLyNhaCungCap a = new frmXuLyNhaCungCap("Thu", "Sua", dgvNCC.Rows[i]);
                a.ShowDialog();
                SelectData();
            }
            catch
            {

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
