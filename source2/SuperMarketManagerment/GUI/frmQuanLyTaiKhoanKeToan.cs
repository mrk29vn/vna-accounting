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
    public partial class frmQuanLyTaiKhoanKeToan : Form
    {
        public frmQuanLyTaiKhoanKeToan()
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
        TKKeToan[] TKKT_Search;
        public TcpClient client1;
        public NetworkStream clientstrem;
        TKKeToan ntkkt;

        public void hienthi()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            ntkkt = new TKKeToan("Select");
            clientstrem = cl.SerializeObj(this.client1, "TKKeToan", ntkkt);

            TKKeToan[] pb1 = new TKKeToan[1];
            pb1[0] = new TKKeToan(1, "a", "a", "a", "a", false);
            pb1 = (TKKeToan[])cl.DeserializeHepper1(clientstrem, pb1);

           

            if (pb1 == null)
            {
                Entities.TKKeToan [] tk= new TKKeToan [0];
                TKKT_Search = tk;
                dataGridView1.DataSource = tk;
                FixDataGridView();
                toolStripStatus_Sua.Enabled = false;
                toolStripStatus_Xoa.Enabled = false;
            }
            else
            {
                TKKT_Search = pb1;
                dataGridView1.DataSource = pb1;
                FixDataGridView();
                toolStripStatus_Sua.Enabled = true;
                toolStripStatus_Xoa.Enabled = true;
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
                frmXuly_TKKeToan fr = new frmXuly_TKKeToan("Them", dataGridView1.CurrentRow);
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
            frmXuly_TKKeToan fr = new frmXuly_TKKeToan("Sua", dataGridView1.CurrentRow);
            fr.ShowDialog();
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

        private void frmQuanLyTaiKhoanKeToan_Load(object sender, EventArgs e)
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
                    int idcurent = int.Parse(dataGridView1.CurrentRow.Cells["TKKeToanID"].Value.ToString());
                    string maCurrent=dataGridView1.CurrentRow.Cells["MaTKKeToan"].Value.ToString();
                    hienthi();
                    for (int j = 0; j < TKKT_Search.Length; j++)
                    {
                        if (TKKT_Search[j].Deleted == false)
                            if (TKKT_Search[j].TKKeToanID == idcurent)
                            {
                                ktdelete = true;
                                break;
                            }
                    }
                    if (ktdelete == true)
                    {
                        try
                        {
                            if (new Check().CheckReference("TKKeToan",maCurrent ))
                            {
                                Server_Client.Client cl = new Server_Client.Client();
                                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                                Entities.TKKeToan tkkt = new TKKeToan("Delete", idcurent,maCurrent, "", "", "", false,Common.Utilities.User.NhanVienID,Common.Utilities.User.TenDangNhap);
                                clientstrem = cl.SerializeObj(this.client1, "TKKeToan", tkkt);
                                //MessageBox.Show("Xoa Thanh Cong...");
                            }
                            else
                            {
                                MessageBox.Show("Tài Khoản Kế Toán Này Hiện Đang Có Giao Dịch - Không Thể Xóa","Hệ thống cảnh báo");
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
                {
                    MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                    return;
                }
                frmXuly_TKKeToan fr = new frmXuly_TKKeToan("Sua", dataGridView1.Rows[e.RowIndex]);
                fr.ShowDialog();
                hienthi();
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

            new Common.Utilities().CountDatagridview(dataGridView1);
            dataGridView1.Columns["NhomTKKT"].Visible = false;
            dataGridView1.Columns["MaTKKeToan"].HeaderText = "Mã TK Kế Toán";
            dataGridView1.Columns["TKKeToanID"].HeaderText = "TK Kế Toán ID";
            dataGridView1.Columns["TenTaiKhoan"].HeaderText = "Tên Tài Khoản";
            dataGridView1.Columns["GhiChu"].HeaderText = "Ghi Chú";
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (rdbTen.Checked == true)
            {

                if (TKKT_Search == null)
                {
                    TKKeToan[] tkkt = new TKKeToan[0];
                    dataGridView1.DataSource = tkkt;
                    FixDataGridView();
                    toolStripStatus_Sua.Enabled = false;
                    toolStripStatus_Xoa.Enabled = false;

                }
                else
                    if (TKKT_Search != null)
                    {
                        if (txtTimKiem.Text.Length == 0)
                        {
                            TKKeToan[] tkkt = new TKKeToan[0];
                            dataGridView1.DataSource = tkkt;
                            FixDataGridView();
                            toolStripStatus_Sua.Enabled = false;
                            toolStripStatus_Xoa.Enabled = false;
                        }
                        else
                        {
                            int TKKT1_search_count = 0;

                            for (int i = 0; i < TKKT_Search.Length; i++)
                            {
                                int index = -1;
                                index = TKKT_Search[i].TenTaiKhoan.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                if (index >= 0)
                                {
                                    TKKT1_search_count++;
                                }
                            }
                            TKKeToan[] TKKT1_search = new TKKeToan[TKKT1_search_count];
                            TKKT1_search_count = 0;

                            for (int i = 0; i < TKKT_Search.Length; i++)
                            {
                                int index = -1;
                                index = TKKT_Search[i].TenTaiKhoan.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                if (index >= 0)
                                {
                                    TKKT1_search[TKKT1_search_count] = TKKT_Search[i];
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
                    if (TKKT_Search == null)
                    {
                        TKKeToan[] tkkt = new TKKeToan[0];
                        dataGridView1.DataSource = tkkt;
                        FixDataGridView();
                        
                            toolStripStatus_Sua.Enabled = false;
                            toolStripStatus_Xoa.Enabled = false;
                      
                    }
                    else
                        if (TKKT_Search != null)
                        {
                            if (txtTimKiem.Text.Length == 0)
                            {
                                TKKeToan[] tkkt = new TKKeToan[0];
                                dataGridView1.DataSource = tkkt;
                                FixDataGridView();
                               
                                    toolStripStatus_Sua.Enabled = false;
                                    toolStripStatus_Xoa.Enabled = false;
                              
                            }
                            else
                            {
                                int NV1_Search_count = 0;

                                for (int i = 0; i < TKKT_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = TKKT_Search[i].MaTKKeToan.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                    if (index >= 0)
                                    {
                                        NV1_Search_count++;
                                    }
                                }
                                TKKeToan[] NV1_search = new TKKeToan[NV1_Search_count];
                                NV1_Search_count = 0;

                                for (int i = 0; i < TKKT_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = TKKT_Search[i].MaTKKeToan.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                    if (index >= 0)
                                    {
                                        NV1_search[NV1_Search_count] = TKKT_Search[i];
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
            if (rdbTatCa.Checked == true)
            {
                hienthi();
            }
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
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
