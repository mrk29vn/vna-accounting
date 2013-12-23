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
    public partial class frmQuanlyphongban : Form
    {
        public frmQuanlyphongban()
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
        PhongBan[] PhongBan_Search;
        public TcpClient client1;
        public NetworkStream clientstrem;
        PhongBan pb;

        public void hienthi()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            pb = new PhongBan("Select");
            clientstrem = cl.SerializeObj(this.client1, "PhongBan", pb);

            PhongBan[] pb1 = new PhongBan[1];
            pb1[0] = new PhongBan(1, "a", "a", "a", false);
            pb1 = (PhongBan[])cl.DeserializeHepper1(clientstrem, pb1);
           
            if (pb1 == null)
            {
                Entities.PhongBan [] pb2=new PhongBan[0];
                dataGridView1.DataSource = pb2;
                PhongBan_Search = pb2;
                FixDataGridView();
                toolStripStatus_Sua.Enabled = false;
                toolStripStatus_Xoa.Enabled = false;
            }
            else
            {
                dataGridView1.DataSource = pb1;
                PhongBan_Search = pb1;
                FixDataGridView();
                toolStripStatus_Sua.Enabled = true;
                toolStripStatus_Xoa.Enabled = true;
            }
        }

        public void FixDataGridView()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns["HanhDong"].HeaderText = "STT";
            dataGridView1.Columns["Deleted"].Visible = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ReadOnly = true;
            new Common.Utilities().CountDatagridview(dataGridView1);
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Mã Phòng Ban";
            dataGridView1.Columns[3].HeaderText = "Tên Phòng Ban";
            dataGridView1.Columns[4].HeaderText = "Ghi Chú";
        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
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
        public static string KiemTra = "insert";
        private void toolStripStatus_ThemMoi_Click_1(object sender, EventArgs e)
        {
            KiemTra = "insert";
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 4))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            while (KiemTra == "insert")
            {
                frmXuly_PhongBan fr = new frmXuly_PhongBan("Them", dataGridView1.CurrentRow);
                fr.StartPosition = FormStartPosition.CenterScreen;
                fr.ShowDialog();
                hienthi();
            }
        }

        private void toolStripStatus_Sua_Click_1(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            frmXuly_PhongBan fr = new frmXuly_PhongBan("Sua", dataGridView1.CurrentRow);
            fr.StartPosition = FormStartPosition.CenterScreen;
            fr.ShowDialog();
            hienthi();
        }

        private void frmQuanlyphongban_Load_1(object sender, EventArgs e)
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
                    int idcurent = int.Parse(dataGridView1.CurrentRow.Cells["PhongBanID"].Value.ToString());
                    string maCurrent = dataGridView1.CurrentRow.Cells["MaPhongBan"].Value.ToString();
                    hienthi();
                    for (int j = 0; j < PhongBan_Search.Length; j++)
                    {
                        if (PhongBan_Search[j].Deleted == false)
                            if (PhongBan_Search[j].PhongBanID == idcurent)
                            {
                                ktdelete = true;
                                break;
                            }
                    }
                    if (ktdelete == true)
                    {
                        try
                        {
                            if (new Check().CheckReference("PhongBan", maCurrent))
                            {
                                Server_Client.Client cl = new Server_Client.Client();
                                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                                pb = new PhongBan("Delete", idcurent, maCurrent, "", "", false,Common.Utilities.User.NhanVienID,Common.Utilities.User.TenDangNhap);
                                clientstrem = cl.SerializeObj(this.client1, "PhongBan", pb);
                                // MessageBox.Show("Xoa Thanh Cong...");
                            }
                            else
                            {
                                MessageBox.Show("Phòng ban nayg hiện đang có giao dịch - Không thể xóa","Hệ thống cảnh báo");
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
                if (!frmDangNhap.User.Administrator && !CheckQuyen("frmQuanlyphongban", 2))
                {
                    MessageBox.Show(" Không có quyền vào chức năng này.");
                    return;
                }
                frmXuly_PhongBan fr = new frmXuly_PhongBan("Sua", dataGridView1.Rows[e.RowIndex]);
                fr.StartPosition = FormStartPosition.CenterScreen;
                fr.ShowDialog();

                hienthi();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (rdbTen.Checked == true)
            {

                if (PhongBan_Search == null)
                {
                    PhongBan[] pb = new PhongBan[0];
                    dataGridView1.DataSource = pb;
                    FixDataGridView();
                    toolStripStatus_Xoa.Enabled = false;
                    toolStripStatus_Sua.Enabled = false;
                    
                }
                else
                    if (PhongBan_Search != null)
                    {
                        
                        if (txtTimKiem.Text.Length == 0)
                        {
                            PhongBan[] pb = new PhongBan[0];
                            dataGridView1.DataSource = pb;
                            FixDataGridView(); 
                            toolStripStatus_Xoa.Enabled = false;
                            toolStripStatus_Sua.Enabled = false;
                        }
                        else
                        {
                            int TKKT1_search_count = 0;

                            for (int i = 0; i < PhongBan_Search.Length; i++)
                            {
                                int index = -1;
                                index = PhongBan_Search[i].TenPhongBan.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                if (index >= 0)
                                {
                                    TKKT1_search_count++;
                                }
                            }
                            PhongBan[] TKKT1_search = new PhongBan[TKKT1_search_count];
                            TKKT1_search_count = 0;

                            for (int i = 0; i < PhongBan_Search.Length; i++)
                            {
                                int index = -1;
                                index = PhongBan_Search[i].TenPhongBan.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                if (index >= 0)
                                {
                                    TKKT1_search[TKKT1_search_count] = PhongBan_Search[i];
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
                    if (PhongBan_Search == null)
                    {
                        PhongBan[] pb = new PhongBan[0];
                        dataGridView1.DataSource = pb;
                        FixDataGridView();
                        toolStripStatus_Xoa.Enabled = false;
                        toolStripStatus_Sua.Enabled = false;
                    }
                    else
                        if (PhongBan_Search != null)
                        {
                            if (txtTimKiem.Text.Length == 0)
                            {
                                PhongBan[] pb = new PhongBan[0];
                                dataGridView1.DataSource = pb;
                                FixDataGridView();
                                toolStripStatus_Xoa.Enabled = false;
                                toolStripStatus_Sua.Enabled = false;
                            }
                            else
                            {
                                int NV1_Search_count = 0;

                                for (int i = 0; i < PhongBan_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = PhongBan_Search[i].MaPhongBan.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                    if (index >= 0)
                                    {
                                        NV1_Search_count++;
                                    }
                                }
                                PhongBan[] NV1_search = new PhongBan[NV1_Search_count];
                                NV1_Search_count = 0;

                                for (int i = 0; i < PhongBan_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = PhongBan_Search[i].MaPhongBan.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                    if (index >= 0)
                                    {
                                        NV1_search[NV1_Search_count] = PhongBan_Search[i];
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
