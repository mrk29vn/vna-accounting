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
    public partial class frmXacNhanPhieuXuatHuy : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        public frmXacNhanPhieuXuatHuy()
        {
            InitializeComponent();
            SelectData();
        }

        Entities.PhieuXuatHuy[] pxh1;
        Entities.PhieuXuatHuy[] hienthi;
        Server_Client.Client cl;
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData()
        {
            try
            {
                dtgvxuathuyhanghoa.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.PhieuXuatHuy pxh = new Entities.PhieuXuatHuy("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                pxh1 = new Entities.PhieuXuatHuy[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuXuatHuy", pxh);
                // đổ mảng đối tượng vào datagripview       
                pxh1 = (Entities.PhieuXuatHuy[])cl.DeserializeHepper1(clientstrem, pxh1);
                if (pxh1 == null)
                {
                    dtgvxuathuyhanghoa.DataSource = new Entities.PhieuXuatHuy[0];
                    return;
                }

                Entities.PhieuXuatHuy[] pxh2 = new Entities.PhieuXuatHuy[pxh1.Length];
                int sotang = 0;
                for (int j = 0; j < pxh1.Length; j++)
                {
                    if (pxh1[j].Deleted == false && pxh1[j].TrangThai == false)
                    {
                        pxh2[sotang] = pxh1[j];
                        sotang++;
                    }
                }

                hienthi = new Entities.PhieuXuatHuy[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pxh2[j];
                    }
                }
                else
                {
                    dtgvxuathuyhanghoa.DataSource = new Entities.PhieuXuatHuy[0];
                    return;
                }

                dtgvxuathuyhanghoa.DataSource = hienthi;
                new Common.Utilities().CountDatagridview(dtgvxuathuyhanghoa);
                dtgvxuathuyhanghoa.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                fix();
            }
        }
        public void fix()
        {
            for (int j = 1; j < dtgvxuathuyhanghoa.ColumnCount; j++)
            {
                dtgvxuathuyhanghoa.Columns[j].Visible = false;
            }
            dtgvxuathuyhanghoa.ReadOnly = true;
            dtgvxuathuyhanghoa.Columns["HanhDong"].Visible = true;
            dtgvxuathuyhanghoa.Columns["HanhDong"].HeaderText = "STT";
            dtgvxuathuyhanghoa.Columns["MaPhieuXuatHuy"].Visible = true;
            dtgvxuathuyhanghoa.Columns["MaPhieuXuatHuy"].HeaderText = "Mã Phiếu Xuất Hủy";
            dtgvxuathuyhanghoa.Columns["NgayLap"].Visible = true;
            dtgvxuathuyhanghoa.Columns["NgayLap"].HeaderText = "Ngày Lập";
            dtgvxuathuyhanghoa.Columns["Tongtien"].Visible = true;
            dtgvxuathuyhanghoa.Columns["Tongtien"].HeaderText = "Tổng Tiền";
            dtgvxuathuyhanghoa.Columns["TrangThai"].Visible = true;
            dtgvxuathuyhanghoa.Columns["TrangThai"].HeaderText = "Xác Nhận";
            dtgvxuathuyhanghoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvxuathuyhanghoa.AllowUserToAddRows = false;
            dtgvxuathuyhanghoa.AllowUserToDeleteRows = false;
            dtgvxuathuyhanghoa.AllowUserToResizeRows = false;
        }
        int i;
        private void dtgvxuathuyhanghoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tssldong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
            }
        }
        public bool CheckDataGridInsert(DataGridView dgv)
        {
            string tv = "";
            try
            {
                if (dgv.RowCount != 0)
                {
                    Entities.PhieuXuatHuy[] ctxh2 = new Entities.PhieuXuatHuy[dgv.RowCount];
                    for (int j = 0; j < ctxh2.Length; j++)
                    {
                        if (Boolean.Parse(dgv["TrangThai", j].Value.ToString()) == true)
                        {
                            ctxh2[j] = new Entities.PhieuXuatHuy("Update", dgv[2, j].Value.ToString(), Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                            CheckDataGridTruSL(SelectChiTiet(dgv["MaPhieuXuatHuy", j].Value.ToString()));
                            tv = "ok";
                        }
                        else
                            ctxh2[j] = new Entities.PhieuXuatHuy("Update", "", Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                    }
                    if (tv == "ok")
                        return DeleteMang(ctxh2);
                    else
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool DeleteMang(Entities.PhieuXuatHuy[] ctxh)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "PhieuXuatHuyMang", ctxh);
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                return kt;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// kiểm tra dtgv trừ số lượng
        /// </summary>
        /// <param name="dgv"></param>
        public void CheckDataGridTruSL(Entities.ChiTietXuatHuy[] dgv)
        {
            try
            {
                if (dgv.Length != 0)
                {
                    Entities.ChiTietKhoHangTheoHoaHonNhap[] cthdbh = new Entities.ChiTietKhoHangTheoHoaHonNhap[dgv.Length];
                    for (int j = 0; j < cthdbh.Length; j++)
                    {
                        string maKho = dtgvxuathuyhanghoa["MaKho", i].Value.ToString();
                        cthdbh[j] = new Entities.ChiTietKhoHangTheoHoaHonNhap("Update", maKho, dgv[j].MaHangHoa, dgv[j].SoLuong);
                    }
                    TruSLMang(cthdbh);
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// trừ số lượng mảng
        /// </summary>
        /// <param name="ctkhthdn"></param>
        public void TruSLMang(Entities.ChiTietKhoHangTheoHoaHonNhap[] ctkhthdn)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "ThemChiTietKhoHang", ctkhthdn);
            }
            catch
            {
            }
            finally
            {
            }
        }
        Entities.ChiTietXuatHuy[] hhht;
        public Entities.ChiTietXuatHuy[] SelectChiTiet(string maPhieuXuatHuy)
        {
            try
            {
                i = 0;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ChiTietXuatHuy ctxh = new Entities.ChiTietXuatHuy("Select", maPhieuXuatHuy);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.ChiTietXuatHuy[] pt1 = new Entities.ChiTietXuatHuy[1];
                clientstrem = cl.SerializeObj(this.client1, "ChiTietXuatHuy", ctxh);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.ChiTietXuatHuy[])cl.DeserializeHepper1(clientstrem, pt1);


                if (pt1 == null)
                {
                    pt1 = new Entities.ChiTietXuatHuy[0];
                    return pt1;
                }

                Entities.ChiTietXuatHuy[] pt2 = new Entities.ChiTietXuatHuy[pt1.Length];
                int sotang = 0;
                for (int j = 0; j < pt1.Length; j++)
                {
                    if (pt1[j].Deleted == false)
                    {
                        if (pt1[j].MaPhieuXuatHuy == maPhieuXuatHuy)
                        {
                            pt2[sotang] = pt1[j];
                            sotang++;
                        }
                    }
                }
                hhht = new Entities.ChiTietXuatHuy[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hhht[j] = pt2[j];
                    }
                    return hhht;
                }
                else
                {
                    hhht = new Entities.ChiTietXuatHuy[0];
                    return hhht;
                }
            }
            catch (Exception ex)
            {
                return new Entities.ChiTietXuatHuy[0];
            }
        }
        private void tsslin_Click(object sender, EventArgs e)
        {
            if (dtgvxuathuyhanghoa.RowCount == 0)
            {
                return;
            }
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn muốn xác nhận không ?", "Hệ thống cảnh báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    bool kt = CheckDataGridInsert(dtgvxuathuyhanghoa);
                    if (kt == true)
                    {

                    }
                    else
                        MessageBox.Show("Thất bại - xin hãy kiểm tra lại");
                    SelectData();
                }
                else
                {
                }
            }
        }
        public void True()
        {
            dtgvxuathuyhanghoa["TrangThai", i].Value = true;
        }
        public void False()
        {
            dtgvxuathuyhanghoa["TrangThai", i].Value = false;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < dtgvxuathuyhanghoa.RowCount; i++)
                {
                    dtgvxuathuyhanghoa["TrangThai", i].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dtgvxuathuyhanghoa.RowCount; i++)
                {
                    dtgvxuathuyhanghoa["TrangThai", i].Value = false;
                }
            }
        }

        private void dtgvxuathuyhanghoa_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                frmXuLyPhieuXuatHuy a = new frmXuLyPhieuXuatHuy("Sua", dtgvxuathuyhanghoa.Rows[i]);
                a.ShowDialog();
            }
            catch
            {
            }
        }

        private void tsslsua_Click(object sender, EventArgs e)
        {
            try
            {
                frmXuLyPhieuXuatHuy a = new frmXuLyPhieuXuatHuy("Sua", dtgvxuathuyhanghoa.Rows[i]);
                a.ShowDialog();
            }
            catch
            {
            }
        }

        private void dtgvxuathuyhanghoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            if (i >= 0)
            {
                if (Boolean.Parse(dtgvxuathuyhanghoa.Rows[i].Cells["TrangThai"].Value.ToString()) == true) False();
                else True();
                lbthutien.Focus();

            }
            else
                i = 0;
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbtimkiem3.Checked == true)
                {
                    return;
                }
                if (txttimkiem.Text.Length == 0)
                {
                    dtgvxuathuyhanghoa.DataSource = new Entities.PhieuXuatHuy[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtimkiem2.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaPhieuXuatHuy.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvxuathuyhanghoa.DataSource = new Entities.PhieuXuatHuy[0];
                            return;
                        }
                        Entities.PhieuXuatHuy[] hienthitheoma = new Entities.PhieuXuatHuy[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaPhieuXuatHuy.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        dtgvxuathuyhanghoa.DataSource = hienthitheoma;
                    }
                }
            }
            finally
            {
                fix();
            }
        }

        private void rdbtimkiem3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (hienthi == null)
                {
                    dtgvxuathuyhanghoa.DataSource = new Entities.PhieuXuatHuy[0];
                    return;
                }
                dtgvxuathuyhanghoa.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                fix();
            }
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
