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
using Entities;

namespace GUI
{
    public partial class frmQuanlynhanvien : Form
    {
        public frmQuanlynhanvien()
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

        int x = 0;
        NhanVien[] NV_Search;
        public TcpClient client1;
        public NetworkStream clientstrem;
        NhanVien nv;
        NhanVien[] nv1;
        public void hienthi()
        {
            try
            {
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                nv = new NhanVien("Select");
                clientstrem = cl.SerializeObj(this.client1, "NhanVien", nv);

                nv1 = new NhanVien[1];
                nv1[0] = new NhanVien(1, "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", DateServer.Date(), "a", DateServer.Date(), "a", false);
                nv1 = (NhanVien[])cl.DeserializeHepper1(clientstrem, nv1);


                if (nv1 == null)
                {
                    Entities.NhanVien[] nv2 = new NhanVien[0];
                    dataGridView1.DataSource = nv2;
                    NV_Search = nv2;
                    FixDataGridView();
                    toolStripStatus_Sua.Enabled = false;
                    toolStripStatus_Xoa.Enabled = false;
                }
                else
                {
                    NV_Search = nv1;

                    dataGridView1.DataSource = nv1;
                    FixDataGridView();
                    toolStripStatus_Sua.Enabled = true;
                    toolStripStatus_Xoa.Enabled = true;
                }
            }
            catch { }
        }

        public void FixDataGridView()
        {
            dataGridView1.Columns[0].HeaderText = "STT";
            dataGridView1.RowHeadersVisible = false;
            
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ReadOnly = true;


            dataGridView1.Columns[4].HeaderText = "Nhân Viên ID";
            dataGridView1.Columns[5].HeaderText = "Mã Nhân Viên";
            dataGridView1.Columns[6].HeaderText = "Tên Nhân Viên";
            dataGridView1.Columns[7].HeaderText = "Mã Phòng Ban";
            dataGridView1.Columns[8].HeaderText = "Tên Phòng Ban";
            dataGridView1.Columns[9].HeaderText = "Đc Thường Trú";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
            dataGridView1.Columns[15].Visible = false;
            dataGridView1.Columns[16].Visible = false;
            dataGridView1.Columns[17].HeaderText = "Ngày sinh";
            dataGridView1.Columns[18].HeaderText = "Ghi Chú";
            dataGridView1.Columns[7].Visible = false;
            new Common.Utilities().CountDatagridview(dataGridView1);
            Entities.NhanVien[] nv = new NhanVien[0];

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
                frmXuly_NhanVien frm = new frmXuly_NhanVien("Them", dataGridView1.CurrentRow);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
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
            frmXuly_NhanVien frm = new frmXuly_NhanVien("Sua", dataGridView1.CurrentRow);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            hienthi();
        }

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

        private void frmQuanlynhanvien_Load(object sender, EventArgs e)
        {
            hienthi();
            
        }

        private void toolStripStatus_Xoa_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 3))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            DialogResult dlgResult = MessageBox.Show("Bạn Có Chắc Chắn muốn Xóa không?", "Đồng ý?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    bool ktdelete = false;
                    int idcurent = int.Parse(dataGridView1.CurrentRow.Cells["NhanVienID"].Value.ToString());
                    string maCurrent = dataGridView1.CurrentRow.Cells["MaNhanVien"].Value.ToString();
                    hienthi();
                    for (int j = 0; j < NV_Search.Length; j++)
                    {
                        if (NV_Search[j].Deleted == false)
                            if (NV_Search[j].NhanVienID == idcurent)
                            {
                                ktdelete = true;
                                break;
                            }
                    }
                    if (ktdelete == true)
                    {
                        if (new Check().CheckReference("NhanVien",maCurrent ))
                        {
                            try
                            {
                                DataGridViewCellCollection dgvc = dataGridView1.CurrentRow.Cells;
                                Server_Client.Client cl = new Server_Client.Client();
                                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                                nv = new NhanVien("Delete", idcurent, maCurrent, dgvc[6].Value.ToString(), dgvc[7].Value.ToString(), dgvc[8].Value.ToString(), dgvc[9].Value.ToString(), dgvc[10].Value.ToString(), dgvc[11].Value.ToString(), dgvc[12].Value.ToString(), dgvc[13].Value.ToString(), dgvc[14].Value.ToString(), Convert.ToDateTime(dgvc[15].Value), dgvc[16].Value.ToString(), Convert.ToDateTime(dgvc[17].Value), dgvc[18].Value.ToString(), false,Common.Utilities.User.NhanVienID,Common.Utilities.User.TenDangNhap);
                                clientstrem = cl.SerializeObj(this.client1, "NhanVien", nv);
                            }
                            catch (Exception ex1) { }
                        }
                        else
                        {
                            MessageBox.Show("Nhân Viên này Đang Có Giao Dịch - Không thể Xóa","Hệ Thống Cảnh Báo!");
                        }
                        
                    }
                    hienthi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Hệ Thống- Liên Hệ nhà Quản Trị");
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
                {
                    MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                    return;
                }
                frmXuly_NhanVien frm = new frmXuly_NhanVien("Sua", dataGridView1.Rows[e.RowIndex]);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                hienthi();
            }
            
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void rdbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTatCa.Checked==true)
            {
                hienthi();
            }
        }

        private void rdbMa_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (rdbTen.Checked == true)
            {

                if (NV_Search == null)
                {
                    Entities.NhanVien [] km=new NhanVien[0];
                    dataGridView1.DataSource = km;
                    FixDataGridView();
                    toolStripStatus_Xoa.Enabled = false;
                    toolStripStatus_Sua.Enabled = false;
                }
                else
                    if (NV_Search != null)
                    {
                        if (txtTimKiem.Text.Length == 0)
                        {
                            Entities.NhanVien[] km = new NhanVien[0];
                            dataGridView1.DataSource = km;
                            FixDataGridView();
                            toolStripStatus_Sua.Enabled = false;
                            toolStripStatus_Xoa.Enabled = false;
                        }
                        else
                        {
                            int NV1_search_count = 0;

                            for (int i = 0; i < NV_Search.Length; i++)
                            {
                                int index = -1;
                                index = NV_Search[i].TenNhanVien.ToLower().IndexOf(txtTimKiem.Text.ToLower());
                                if (index >= 0)
                                {
                                    NV1_search_count++;
                                }
                            }
                            NhanVien[] tt1_search = new NhanVien[NV1_search_count];
                            NV1_search_count = 0;

                            for (int i = 0; i < NV_Search.Length; i++)
                            {
                                int index = -1;
                                index = NV_Search[i].TenNhanVien.ToLower().IndexOf(txtTimKiem.Text.ToLower());
                                if (index >= 0)
                                {
                                    tt1_search[NV1_search_count] = NV_Search[i];
                                    NV1_search_count++;
                                }
                            }
                            if (NV1_search_count == 0)
                            {
                                toolStripStatus_Sua.Enabled = false;
                                toolStripStatus_Xoa.Enabled = false;
                            }
                            else
                            {
                                toolStripStatus_Sua.Enabled = true;
                                toolStripStatus_Xoa.Enabled = true;
                            }
                            dataGridView1.DataSource = tt1_search;
                            FixDataGridView();
                        }
                    }
            }
            else
                if (rdbMa.Checked == true)
                {
                    if (NV_Search == null)
                    {
                        Entities.NhanVien[] km = new NhanVien[0];
                        dataGridView1.DataSource = km;
                        FixDataGridView();
                        toolStripStatus_Sua.Enabled = false;

                    }
                    else
                        if (NV_Search != null)
                        {
                            if (txtTimKiem.Text.Length == 0)
                            {
                                Entities.NhanVien[] km = new NhanVien[0];
                                dataGridView1.DataSource = km;
                                FixDataGridView();
                                toolStripStatus_Sua.Enabled = false;

                            }
                            else
                            {
                                int NV1_Search_count = 0;

                                for (int i = 0; i < NV_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = NV_Search[i].MaNhanVien.ToLower().IndexOf(txtTimKiem.Text.ToLower());
                                    if (index >= 0)
                                    {
                                        NV1_Search_count++;
                                    }
                                }
                                NhanVien[] NV1_search = new NhanVien[NV1_Search_count];
                                NV1_Search_count = 0;

                                for (int i = 0; i < NV_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = NV_Search[i].MaNhanVien.ToLower().IndexOf(txtTimKiem.Text.ToLower());
                                    if (index >= 0)
                                    {
                                        NV1_search[NV1_Search_count] = NV_Search[i];
                                        NV1_Search_count++;
                                    }
                                }
                                if (NV1_Search_count == 0)
                                {
                                    toolStripStatus_Sua.Enabled = false;
                                    toolStripStatus_Xoa.Enabled = false;
                                }
                                else
                                {
                                    toolStripStatus_Sua.Enabled = true;
                                    toolStripStatus_Xoa.Enabled = true;
                                }
                                dataGridView1.DataSource = NV1_search;
                                FixDataGridView();
                            }
                        }
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

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            hienthi();
        }
    }
}
