using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Entities;

namespace GUI
{
    public partial class frmHienThi_DieuChuyenKhoNoiBo : Form
    {
        public frmHienThi_DieuChuyenKhoNoiBo()
        {
            InitializeComponent();
        }

        PhieuDieuChuyenKhoNoiBo[] PDCK_Search;
        private void toolStripStatus_Dong_Click(object sender, EventArgs e)
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

        public TcpClient client1;
        public NetworkStream clientstrem;
        PhieuDieuChuyenKhoNoiBo Pdck;

        public void hienthi()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Pdck = new PhieuDieuChuyenKhoNoiBo("Select", 1, "a", DateServer.Date(), "a", "a ", "a", "a", "a", false, "a", false);
            clientstrem = cl.SerializeObj(this.client1, "PhieuDieuCHuyenKhoNoiBo", Pdck);

            PhieuDieuChuyenKhoNoiBo[] pdck1 = new PhieuDieuChuyenKhoNoiBo[1];
            pdck1[0] = new PhieuDieuChuyenKhoNoiBo(1, "a", DateServer.Date(), "a", "a", "a", false, "a", false);
            pdck1 = (PhieuDieuChuyenKhoNoiBo[])cl.DeserializeHepper1(clientstrem, pdck1);

            
            if (pdck1 == null)
            {
                Entities.PhieuDieuChuyenKhoNoiBo[] a = new PhieuDieuChuyenKhoNoiBo[0];
                PDCK_Search = a;
                dgvHienThi.DataSource = a;
                FixDataGridView();
                toolStripStatus_Sua.Enabled = false;
                toolStripStatus_Xoa.Enabled = false;
            }
            else
            {
                PDCK_Search = pdck1;
                dgvHienThi.DataSource = pdck1;
                FixDataGridView();
                toolStripStatus_Sua.Enabled = true;
                toolStripStatus_Xoa.Enabled = true;
            }
            
        }

        public void FixDataGridView()
        {
            dgvHienThi.RowHeadersVisible = false;
            dgvHienThi.Columns[0].HeaderText = "STT";
            dgvHienThi.Columns["TuKho"].Visible = false;
            dgvHienThi.Columns["DenKho"].Visible = false;
            dgvHienThi.Columns[dgvHienThi.ColumnCount - 1].Visible = false;
            dgvHienThi.AllowUserToResizeRows = false;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHienThi.ReadOnly = true;
            new Common.Utilities().CountDatagridview(dgvHienThi);
            dgvHienThi.Columns["PhieuDieuChuyenKhoID"].Visible =false;
            dgvHienThi.Columns["MaPhieuDieuChuyenKho"].HeaderText = "Mã Phiếu điều chuyển";
            dgvHienThi.Columns["NgayDieuChuyen"].HeaderText = "Ngày điều chuyển";
            dgvHienThi.Columns["TenKhoDi"].HeaderText = "Tên Kho Đi";
            dgvHienThi.Columns["TenKhoDen"].HeaderText = "Tên Kho Đến";
            dgvHienThi.Columns["MaHoaDonNhap"].Visible = false;
            dgvHienThi.Columns["XacNhan"].HeaderText = "Xác nhận";
            dgvHienThi.Columns["GhiChu"].HeaderText = "Ghi Chú";
          
        }
        public static string KiemTra = "insert";
        private void toolStripStatus_ThemMoi_Click(object sender, EventArgs e)
        {
            KiemTra = "insert";
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 4))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            while (KiemTra == "insert")
            {
                frmXuLy_DieuChuyenKhoNoiBo noi = new frmXuLy_DieuChuyenKhoNoiBo("Them", dgvHienThi.CurrentRow);
                noi.ShowDialog();
                hienthi();
            }
            
            
        }

        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            frmXuLy_DieuChuyenKhoNoiBo noi = new frmXuLy_DieuChuyenKhoNoiBo("Sua", dgvHienThi.CurrentRow);
            noi.ShowDialog();
            hienthi();
        }

        private void toolStripStatus_Xoa_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 3))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if ((bool)dgvHienThi.CurrentRow.Cells["XacNhan"].Value)
            {
                  MessageBox.Show("Phiếu đã xác nhận không thể xóa", "Hệ Thống cảnh báo");
                return;
            }
            DialogResult dlgResult = MessageBox.Show("Bạn Có Chắc Chắn muốn Xóa không?", "Đồng ý?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    bool ktdelete = false;
                    int idcurent = int.Parse(dgvHienThi.CurrentRow.Cells["PhieuDieuChuyenKhoID"].Value.ToString());
                    hienthi();
                    for (int j = 0; j < PDCK_Search.Length; j++)
                    {
                        if (PDCK_Search[j].Deleted == false)
                            if (PDCK_Search[j].PhieuDieuChuyenKhoID == idcurent)
                            {
                                ktdelete = true;
                                break;
                            }
                    }
                    if (ktdelete == true)
                    {
                        try
                        {
                            Server_Client.Client cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                            PhieuDieuChuyenKhoNoiBo tt = new PhieuDieuChuyenKhoNoiBo("Delete", idcurent);
                            clientstrem = cl.SerializeObj(this.client1, "PhieuDieuCHuyenKhoNoiBo", tt);
                            //MessageBox.Show("Xoa Thanh Cong...");
                        }
                        catch { }
                    }
                    hienthi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Hệ Thống- Liên Hệ nhà Quản Trị");
                }
            }       
        }

        private void toolStripStatus_Loc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void toolStripStatus_In_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void frmHienThi_DieuChuyenKhoNoiBo_Load(object sender, EventArgs e)
        {
            hienthi();
        }

        private void dgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    frmXuLy_DieuChuyenKhoNoiBo noi = new frmXuLy_DieuChuyenKhoNoiBo("Sua", dgvHienThi.Rows[e.RowIndex]);
                    noi.ShowDialog();
                    hienthi();
                }
            }
            catch { }
            
        }

        private void palTencung_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbMa.Checked == true)
                {
                    if (PDCK_Search == null)
                    {
                        PhieuDieuChuyenKhoNoiBo[] pdck = new PhieuDieuChuyenKhoNoiBo[0];
                        dgvHienThi.DataSource = pdck;
                        FixDataGridView();

                        toolStripStatus_Sua.Enabled = false;
                        toolStripStatus_Xoa.Enabled = false;

                    }
                    else
                        if (PDCK_Search != null)
                        {
                            if (txtTimKiem.Text.Length == 0)
                            {
                                PhieuDieuChuyenKhoNoiBo[] pdck = new PhieuDieuChuyenKhoNoiBo[0];
                                dgvHienThi.DataSource = pdck;
                                FixDataGridView();
                                toolStripStatus_Sua.Enabled = false;
                                toolStripStatus_Xoa.Enabled = false;
                            }
                            else
                            {
                                int tt1_search_count = 0;

                                for (int i = 0; i < PDCK_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = PDCK_Search[i].MaPhieuDieuChuyenKho.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                    if (index >= 0)
                                    {
                                        tt1_search_count++;
                                    }
                                }
                                PhieuDieuChuyenKhoNoiBo[] tt1_search = new PhieuDieuChuyenKhoNoiBo[tt1_search_count];
                                tt1_search_count = 0;

                                for (int i = 0; i < PDCK_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = PDCK_Search[i].MaPhieuDieuChuyenKho.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                    if (index >= 0)
                                    {
                                        tt1_search[tt1_search_count] = PDCK_Search[i];
                                        tt1_search_count++;
                                    }
                                }
                                if (tt1_search_count == 0)
                                {
                                    toolStripStatus_Sua.Enabled = false;
                                    toolStripStatus_Xoa.Enabled = false;
                                }
                                else
                                {
                                    toolStripStatus_Sua.Enabled = true;
                                    toolStripStatus_Xoa.Enabled = true;
                                }
                                dgvHienThi.DataSource = tt1_search;
                                FixDataGridView();
                            }
                        }
                }
            }catch(Exception ex){}
        }

        private void rdbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTatCa.Checked==true)
            {
                hienthi();
            }
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

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            hienthi();
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
