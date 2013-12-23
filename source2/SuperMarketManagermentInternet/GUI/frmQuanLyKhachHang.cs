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
    public partial class frmQuanLyKhachHang : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        BizLogic.KhachHang kh;
        public frmQuanLyKhachHang()
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
                for (int j = 0; j < 1000; j++)
                {
                    if (trave == "")
                    {
                        frmXuLyKhachHang qlkh = new frmXuLyKhachHang("Thu", "Them");
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
                if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
                {
                    MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                    return;
                }
                for (int j = 0; j < 1000; j++)
                {
                    if (trave == "")
                    {
                        frmXuLyKhachHang qlkh = new frmXuLyKhachHang("Thu", "Sua", dgvkhachhang.Rows[i]);
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
        Entities.KhachHang[] kh1;
        Entities.KhachHang[] hienthi;
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData()
        {
            try
            {

                i = 0;
                dgvkhachhang.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.KhachHang kh = new Entities.KhachHang();
                // truyền HanhDong
                kh = new Entities.KhachHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                kh1 = new Entities.KhachHang[1];
                clientstrem = cl.SerializeObj(this.client1, "KhachHang", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.KhachHang[])cl.DeserializeHepper1(clientstrem, kh1);
                // lbltongs.Text = kh1.Length.ToString();
                if (kh1 == null)
                {
                    tsslbl.Enabled = false;
                    hienthi = new Entities.KhachHang[0];
                    dgvkhachhang.DataSource = new Entities.KhachHang[0];
                    return;
                }
                tsslbl.Enabled = true;

                Entities.KhachHang[] pt2 = new Entities.KhachHang[kh1.Length];
                int sotang = 0;
                for (int j = 0; j < kh1.Length; j++)
                {

                    if (kh1[j].Deleted == false)
                    {
                        pt2[sotang] = kh1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.KhachHang[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pt2[j];
                    }
                }
                else
                {
                    dgvkhachhang.DataSource = new Entities.KhachHang[0];
                    return;
                }
                dgvkhachhang.DataSource = hienthi;
                new Common.Utilities().CountDatagridview(dgvkhachhang);

                dgvkhachhang.Rows[0].Selected = true;
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvkhachhang.ColumnCount; j++)
                    {
                        dgvkhachhang.Columns[j].Visible = false;
                    }
                    //dgvkhachhang.Columns[0].Visible = false;
                    //dgvkhachhang.Columns[1].Visible = false;
                    //dgvkhachhang.Columns[2].Visible = false;
                    //dgvkhachhang.Columns[3].Visible = false;
                    //dgvkhachhang.Columns[4].Visible = false;
                    //dgvkhachhang.Columns[5].Visible = false;
                    //dgvkhachhang.Columns[6].Visible = false;
                    //dgvkhachhang.Columns["NgungTheoDoi"].Visible = false;
                    //dgvkhachhang.Columns["CongTy"].Visible = false;
                    //dgvkhachhang.Columns["DuNo"].Visible = false;
                    //dgvkhachhang.Columns["MST"].Visible = false;
                    //dgvkhachhang.Columns["Fax"].Visible = false;
                    //dgvkhachhang.Columns["Email"].Visible = false;
                    //dgvkhachhang.Columns["HanMucTT"].Visible = false;
                    //dgvkhachhang.Columns["MaVung"].Visible = false;
                    //dgvkhachhang.Columns["Mobi"].Visible = false;
                    //dgvkhachhang.Columns["NgayThamGia"].Visible = false;
                    //dgvkhachhang.Columns["GiaoDichCuoi"].Visible = false;
                    //dgvkhachhang.Columns["NgungTheoDoi"].Visible = false;
                    //dgvkhachhang.Columns["Website"].Visible = false;
                    dgvkhachhang.Columns[0].Visible = true;
                    dgvkhachhang.Columns[0].HeaderText = "STT";
                    dgvkhachhang.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
                    dgvkhachhang.Columns["Ten"].HeaderText = "Tên Khách Hàng";
                    dgvkhachhang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvkhachhang.Columns["DienThoai"].HeaderText = "Điện Thoại";
                    dgvkhachhang.Columns["MaKH"].Visible = true;
                    dgvkhachhang.Columns["Ten"].Visible = true;
                    dgvkhachhang.Columns["DiaChi"].Visible = true;
                    dgvkhachhang.Columns["DienThoai"].Visible = true;
                    dgvkhachhang.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    dgvkhachhang.Columns["NgaySua"].HeaderText = "Ngày Sửa";
                    dgvkhachhang.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvkhachhang.Columns["NgaySinh"].Visible = true;
                    dgvkhachhang.Columns["NgaySua"].Visible = true;
                    dgvkhachhang.Columns["GhiChu"].Visible = true;
                    //dgvkhachhang.Columns["Deleted"].Visible=true;
                    //dgvkhachhang.Columns["Deleted"].HeaderText = "Deleted";
                    dgvkhachhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvkhachhang.AllowUserToAddRows = false;
                    dgvkhachhang.AllowUserToDeleteRows = false;
                    dgvkhachhang.AllowUserToResizeRows = false;
                }
                catch
                { }
            }
        }

        int i;
        private void dgvkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                i = e.RowIndex;
                if (i >= 0)
                {
                    dgvkhachhang.Rows[i].Selected = true;
                }
            }
            catch { }

        }
        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            SelectData();
        }
        private void tsslbl_Click(object sender, EventArgs e)
        {
            string maKH = dgvkhachhang.Rows[i].Cells["MaKH"].Value.ToString();



            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 3))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (new Check().CheckReference("KhachHang",maKH))
            {
                DialogResult dlgResult = MessageBox.Show("Bạn Có Chắc Chắn muốn Xóa Khách Hàng này không?", "Đồng ý?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.Yes)
                {
                    try
                    {
                        //bool ktdelete = false;
                        //int idcurent = int.Parse(dgvkhachhang.Rows[i].Cells["KhachHangID"].Value.ToString());
                        //SelectData();
                        //for (int j = 0; j < kh1.Length; j++)
                        //{
                        //    if (kh1[j].Deleted == false)
                        //        if (kh1[j].KhachHangID == idcurent)
                        //        {
                        //            ktdelete = true;
                        //            break;
                        //        }
                        //}
                        //if (ktdelete == true)
                        //{
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                            Entities.KhachHang kh = new Entities.KhachHang();
                            kh = new Entities.KhachHang("Delete", int.Parse(dgvkhachhang.Rows[i].Cells["KhachHangID"].Value.ToString()), Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                            clientstrem = cl.SerializeObj(this.client1, "KhachHang", kh);
                            bool kt = false;
                            kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                            if (kt == true)
                            {
                            }
                        //}
                        else
                        {
                            MessageBox.Show("Khách Hàng này đã bị xóa");
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
                MessageBox.Show("khách hàng này không  thể xóa! Hiện tại đang có giao dịch");
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
                    dgvkhachhang.DataSource = new Entities.KhachHang[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtheoma.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].Ten.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dgvkhachhang.DataSource = new Entities.KhachHang[0];
                            return;
                        }
                        Entities.KhachHang[] hienthitheoid = new Entities.KhachHang[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].Ten.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dgvkhachhang.DataSource = hienthitheoid;
                    }
                    if (rdbtheoten.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaKH.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dgvkhachhang.DataSource = new Entities.KhachHang[0];
                            return;
                        }
                        Entities.KhachHang[] hienthitheoma = new Entities.KhachHang[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaKH.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dgvkhachhang.DataSource = hienthitheoma;
                    }
                }
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvkhachhang.ColumnCount; j++)
                    {
                        dgvkhachhang.Columns[j].Visible = false;
                    }
                    new Common.Utilities().CountDatagridview(dgvkhachhang);
                    // dgvkhachhang.Columns[1].Visible = false;
                    dgvkhachhang.Columns[0].Visible = true;
                    dgvkhachhang.Columns[0].HeaderText = "STT";
                    dgvkhachhang.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
                    dgvkhachhang.Columns["Ten"].HeaderText = "Tên Khách Hàng";
                    dgvkhachhang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvkhachhang.Columns["DienThoai"].HeaderText = "Điện Thoại";
                    dgvkhachhang.Columns["MaKH"].Visible = true;
                    dgvkhachhang.Columns["Ten"].Visible = true;
                    dgvkhachhang.Columns["DiaChi"].Visible = true;
                    dgvkhachhang.Columns["DienThoai"].Visible = true;
                    dgvkhachhang.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    dgvkhachhang.Columns["NgaySua"].HeaderText = "Ngày Sửa";
                    dgvkhachhang.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvkhachhang.Columns["NgaySinh"].Visible = true;
                    dgvkhachhang.Columns["NgaySua"].Visible = true;
                    dgvkhachhang.Columns["GhiChu"].Visible = true;
                    dgvkhachhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvkhachhang.AllowUserToAddRows = false;
                    dgvkhachhang.AllowUserToDeleteRows = false;
                    dgvkhachhang.AllowUserToResizeRows = false;
                    dgvkhachhang.RowHeadersVisible = false;
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
                    dgvkhachhang.DataSource = new Entities.KhachHang[0];
                    return;
                }
                dgvkhachhang.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvkhachhang.ColumnCount; j++)
                    {
                        dgvkhachhang.Columns[j].Visible = false;
                    }
                    new Common.Utilities().CountDatagridview(dgvkhachhang);
                    // dgvkhachhang.Columns[1].Visible = false;
                    dgvkhachhang.Columns[0].Visible = true;
                    dgvkhachhang.Columns[0].HeaderText = "STT";
                    dgvkhachhang.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
                    dgvkhachhang.Columns["Ten"].HeaderText = "Tên Khách Hàng";
                    dgvkhachhang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvkhachhang.Columns["DienThoai"].HeaderText = "Điện Thoại";
                    dgvkhachhang.Columns["MaKH"].Visible = true;
                    dgvkhachhang.Columns["Ten"].Visible = true;
                    dgvkhachhang.Columns["DiaChi"].Visible = true;
                    dgvkhachhang.Columns["DienThoai"].Visible = true;
                    dgvkhachhang.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
                    dgvkhachhang.Columns["NgaySua"].HeaderText = "Ngày Sửa";
                    dgvkhachhang.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    dgvkhachhang.Columns["NgaySinh"].Visible = true;
                    dgvkhachhang.Columns["NgaySua"].Visible = true;
                    dgvkhachhang.Columns["GhiChu"].Visible = true;
                    dgvkhachhang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvkhachhang.AllowUserToAddRows = false;
                    dgvkhachhang.AllowUserToDeleteRows = false;
                    dgvkhachhang.AllowUserToResizeRows = false;
                    dgvkhachhang.RowHeadersVisible = false;
                }
                catch { }
            }
        }

        private void panelkhachhang_DoubleClick(object sender, EventArgs e)
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

        private void dgvkhachhang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            try
            {
                frmXuLyKhachHang a = new frmXuLyKhachHang("Thu", "Sua", dgvkhachhang.Rows[i]);
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
