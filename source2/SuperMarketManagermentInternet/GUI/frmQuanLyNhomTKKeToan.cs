using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entities;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmQuanLyNhomTKKeToan : Form
    {
        public frmQuanLyNhomTKKeToan()
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
        NhomTKKeToan[] NhomTKKT_Search;
        public TcpClient client1;
        public NetworkStream clientstrem;
        NhomTKKeToan ntkkt;

        public void hienthi()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            ntkkt = new NhomTKKeToan("Select");
            clientstrem = cl.SerializeObj(this.client1, "NhomTKKeToan", ntkkt);

            NhomTKKeToan[] pb1 = new NhomTKKeToan[1];
            pb1[0] = new NhomTKKeToan(1, "a", "a", "a", false);
            pb1 = (NhomTKKeToan[])cl.DeserializeHepper1(clientstrem, pb1);

               
            if (pb1 == null)
            {
                toolStripStatus_Sua.Enabled = false;
                toolStripStatus_Xoa.Enabled = false;
                Entities.NhomTKKeToan [] nhomtk= new NhomTKKeToan [0];
                NhomTKKT_Search = nhomtk;
                dataGridView1.DataSource = nhomtk;
                FixDataGridView();
            }
            else
            {
                toolStripStatus_Sua.Enabled = true;
                toolStripStatus_Xoa.Enabled = true;
                NhomTKKT_Search = pb1;
                dataGridView1.DataSource = pb1;
                FixDataGridView();
            }
        }

        public void FixDataGridView()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].HeaderText = "STT";
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Visible = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ReadOnly = true;

            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Mã Nhóm Tài Khoản";
            dataGridView1.Columns[3].HeaderText = "Tên Nhóm Tài Khoản";
            dataGridView1.Columns[4].HeaderText = "Ghi Chú";
            new Common.Utilities().CountDatagridview(dataGridView1);
            
        }

        private void frmQuanLyNhomTKKeToan_Load(object sender, EventArgs e)
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
                    int idcurent = int.Parse(dataGridView1.CurrentRow.Cells["NhomTKKeToanID"].Value.ToString());
                    string maCurrent = dataGridView1.CurrentRow.Cells["MaNhomTKKeToan"].Value.ToString();
                    hienthi();
                    for (int j = 0; j < NhomTKKT_Search.Length; j++)
                    {
                        if (NhomTKKT_Search[j].Delete == false)
                            if (NhomTKKT_Search[j].NhomTKKeToanID == idcurent)
                            {
                                ktdelete = true;
                                break;
                            }
                    }
                    if (ktdelete == true)
                    {

                        try
                        {
                            if (new Check().CheckReference("NhomTKKeToan", maCurrent))
                            {
                                Server_Client.Client cl = new Server_Client.Client();
                                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                                Entities.NhomTKKeToan nv = new NhomTKKeToan("Delete", idcurent,maCurrent, "", "", false,Common.Utilities.User.NhanVienID,Common.Utilities.User.TenDangNhap);
                                clientstrem = cl.SerializeObj(this.client1, "NhomTKKeToan", nv);
                                //  MessageBox.Show("Xoa Thanh Cong...");
                            }
                            else
                            {
                                MessageBox.Show("Nhóm TK kế toán này hiện đang có giao dịch - Không thể xóa","Hệ thống cảnh báo");
                            }
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
                frmXuly_NhomTKKeToan fr = new frmXuly_NhomTKKeToan("Them", dataGridView1.CurrentRow);
                fr.StartPosition = FormStartPosition.CenterScreen;
                fr.ShowDialog();
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
            frmXuly_NhomTKKeToan fr = new frmXuly_NhomTKKeToan("Sua", dataGridView1.CurrentRow);
            fr.StartPosition = FormStartPosition.CenterScreen;
            fr.ShowDialog();
            hienthi();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
                {
                    MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                    return;
                }
                frmXuly_NhomTKKeToan fr = new frmXuly_NhomTKKeToan("Sua", dataGridView1.Rows[e.RowIndex]);
                fr.StartPosition = FormStartPosition.CenterScreen;
                fr.ShowDialog();
                hienthi();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (rdbTen.Checked == true)
            {

                if (NhomTKKT_Search == null)
                {
                    NhomTKKeToan[] pb = new NhomTKKeToan[0];
                    dataGridView1.DataSource = pb;
                    FixDataGridView();
                    toolStripStatus_Sua.Enabled = false;
                    toolStripStatus_Xoa.Enabled = false;
                    
                }
                else
                    if (NhomTKKT_Search != null)
                    {
                        if (txtTimKiem.Text.Length == 0)
                        {
                            NhomTKKeToan[] pb = new NhomTKKeToan[0];
                            dataGridView1.DataSource = pb;
                            FixDataGridView();
                            toolStripStatus_Sua.Enabled = false;
                            toolStripStatus_Xoa.Enabled = false;
                        }
                        else
                        {
                            int TKKT1_search_count = 0;

                            for (int i = 0; i < NhomTKKT_Search.Length; i++)
                            {
                                int index = -1;
                                index = NhomTKKT_Search[i].TenNhomTKKeToan.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                if (index >= 0)
                                {
                                    TKKT1_search_count++;
                                }
                            }
                            NhomTKKeToan[] TKKT1_search = new NhomTKKeToan[TKKT1_search_count];
                            TKKT1_search_count = 0;

                            for (int i = 0; i < NhomTKKT_Search.Length; i++)
                            {
                                int index = -1;
                                index = NhomTKKT_Search[i].TenNhomTKKeToan.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                if (index >= 0)
                                {
                                    TKKT1_search[TKKT1_search_count] = NhomTKKT_Search[i];
                                    TKKT1_search_count++;
                                }
                            }
                            if (TKKT1_search_count == 0)
                            {
                                toolStripStatus_Sua.Enabled = false;
                                toolStripStatus_Xoa.Enabled = false;
                            }
                            else
                            {
                                toolStripStatus_Sua.Enabled = true;
                                toolStripStatus_Xoa.Enabled = true;
                            }
                            dataGridView1.DataSource = TKKT1_search;
                            FixDataGridView();
                        }
                    }
            }
            else
                if (rdbMa.Checked == true)
                {
                    if (NhomTKKT_Search == null)
                    {
                        NhomTKKeToan[] pb = new NhomTKKeToan[0];
                        dataGridView1.DataSource = pb;
                        FixDataGridView();
                        toolStripStatus_Sua.Enabled = false;
                        toolStripStatus_Xoa.Enabled = false;
                    }
                    else
                        if (NhomTKKT_Search != null)
                        {
                            if (txtTimKiem.Text.Length == 0)
                            {
                                NhomTKKeToan[] pb = new NhomTKKeToan[0];
                                dataGridView1.DataSource = pb;
                                FixDataGridView();
                                toolStripStatus_Sua.Enabled = false;
                                toolStripStatus_Xoa.Enabled = false;
                            }
                            else
                            {
                                int NV1_Search_count = 0;

                                for (int i = 0; i < NhomTKKT_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = NhomTKKT_Search[i].MaNhomTKKeToan.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                    if (index >= 0)
                                    {
                                        NV1_Search_count++;
                                    }
                                }
                                NhomTKKeToan[] NV1_search = new NhomTKKeToan[NV1_Search_count];
                                NV1_Search_count = 0;

                                for (int i = 0; i < NhomTKKT_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = NhomTKKT_Search[i].MaNhomTKKeToan.IndexOf(txtTimKiem.Text.Trim().ToLower());
                                    if (index >= 0)
                                    {
                                        NV1_search[NV1_Search_count] = NhomTKKT_Search[i];
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

        private void rdbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTatCa.Checked==true)
            {
                hienthi();
            }
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

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            hienthi();
        }
    }
}
