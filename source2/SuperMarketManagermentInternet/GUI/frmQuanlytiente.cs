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
    public partial class frmQuanlytiente : Form
    {
        public frmQuanlytiente()
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
        TienTe[] TT_Search;
        private void frmQuanlytiente_Load(object sender, EventArgs e)
        {
            hienthi();
        }

        public TcpClient client1;
        public NetworkStream clientstrem;
        TienTe tt;

        public void hienthi()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            tt = new TienTe("Select", 1, "a", "a", "a", "a", "a", 1000, "a", false,Common.Utilities.User.NhanVienID,Common.Utilities.User.TenDangNhap);
            clientstrem = cl.SerializeObj(this.client1, "TienTe", tt);

            TienTe[] tt1 = new TienTe[1];
            tt1[0] = new TienTe(1, "a", "a", "a", "a", "a", 1000, "a", false);
            tt1 = (TienTe[])cl.DeserializeHepper1(clientstrem, tt1);
            
                
                if (tt1 == null)
                {
                    Entities.TienTe [] a= new Entities.TienTe[0];
                    TT_Search = a;
                    dataGridView1.DataSource = a;
                    FixDataGridView();
                    toolStripStatus_Sua.Enabled = false;
                    toolStripStatus_Xoa.Enabled = false;
                }
                else
                {
                    TT_Search = tt1;
                    dataGridView1.DataSource = tt1;
                    FixDataGridView();
                    toolStripStatus_Sua.Enabled = true;
                    toolStripStatus_Xoa.Enabled = true;
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
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Mã Tiền Tệ";
            dataGridView1.Columns[3].HeaderText = "Tên Tiền Tệ";
            dataGridView1.Columns[4].HeaderText = "Tên Tiền Tệ Chẵn";
            dataGridView1.Columns[5].HeaderText = "Tên tiền tệ lẻ";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Ghi Chú";
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
                frmXuly_TienTe fr = new frmXuly_TienTe("Them", dataGridView1.CurrentRow);
                fr.StartPosition = FormStartPosition.CenterScreen;
                fr.ShowDialog();
                hienthi();
            }
        }

        private void toolStripStatus_Dong_Click_1(object sender, EventArgs e)
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
                    int idcurent = int.Parse(dataGridView1.CurrentRow.Cells["TienTeID"].Value.ToString());
                    string maCurrent=dataGridView1.CurrentRow.Cells["MaTienTe"].Value.ToString();
                    hienthi();
                    for (int j = 0; j < TT_Search.Length; j++)
                    {
                        if (TT_Search[j].Deleted == false)
                            if (TT_Search[j].TienteID == idcurent)
                            {
                                ktdelete = true;
                                break;
                            }
                    }
                    if (ktdelete == true)
                    {
                        try
                        {
                            if (new Check().CheckReference("TienTe", maCurrent))
                            {
                                Server_Client.Client cl = new Server_Client.Client();
                                this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                                tt = new TienTe("Delete", idcurent,maCurrent,"","","","",0,"",false,Common.Utilities.User.NhanVienID,Common.Utilities.User.TenDangNhap);
                                clientstrem = cl.SerializeObj(this.client1, "TienTe", tt);
                                // MessageBox.Show("Xoa Thanh Cong...");
                            }
                            else
                            {
                                MessageBox.Show("Tiền tệ này hiện đang có giao dịch - Không thể xóa","Hệ thống cảnh báo");
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

        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            frmXuly_TienTe fr = new frmXuly_TienTe("Sua", dataGridView1.CurrentRow);
            fr.StartPosition = FormStartPosition.CenterScreen;
            fr.ShowDialog();
            hienthi();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                frmXuly_TienTe fr = new frmXuly_TienTe("Sua", dataGridView1.Rows[e.RowIndex]);
                fr.StartPosition = FormStartPosition.CenterScreen;
                fr.ShowDialog();
                hienthi();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (rdbTen.Checked == true)
            {

                if (TT_Search == null)
                {
                    TienTe[] tt = new TienTe[0];
                    dataGridView1.DataSource = tt;
                    FixDataGridView();
                    
                        toolStripStatus_Sua.Enabled = false;
                        toolStripStatus_Xoa.Enabled = false;
               
                }
                else
                    if (TT_Search != null)
                    {
                        if (txtTimKiem.Text.Length == 0)
                        {
                            TienTe[] tt = new TienTe[0];
                            dataGridView1.DataSource = tt;
                            FixDataGridView();
                            
                                toolStripStatus_Sua.Enabled = false;
                                toolStripStatus_Xoa.Enabled = false;
                           
                        }
                        else
                        {
                            int tt1_search_count = 0;

                            for (int i = 0; i < TT_Search.Length; i++)
                            {
                                int index = -1;
                                index = TT_Search[i].TenTienTe.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                if (index >= 0)
                                {
                                    tt1_search_count++;
                                }
                            }
                            TienTe[] tt1_search = new TienTe[tt1_search_count];
                            tt1_search_count = 0;

                            for (int i = 0; i < TT_Search.Length; i++)
                            {
                                int index = -1;
                                index = TT_Search[i].TenTienTe.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                if (index >= 0)
                                {
                                    tt1_search[tt1_search_count] = TT_Search[i];
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
                            dataGridView1.DataSource = tt1_search;
                            FixDataGridView();
                        }
                    }
            }
            else
                if (rdbMa.Checked == true)
                {
                    if (TT_Search == null)
                    {
                        TienTe[] tt = new TienTe[0];
                        dataGridView1.DataSource = tt;
                        FixDataGridView();
                        toolStripStatus_Sua.Enabled = false;
                        toolStripStatus_Xoa.Enabled = false;
                    }
                    else
                        if (TT_Search != null)
                        {
                            if (txtTimKiem.Text.Length == 0)
                            {
                                TienTe[] tt = new TienTe[0];
                                dataGridView1.DataSource = tt;
                                FixDataGridView();
                                 toolStripStatus_Sua.Enabled = false;
                                toolStripStatus_Xoa.Enabled = false;
                            }
                            else
                            {
                                int tt1_search_count = 0;

                                for (int i = 0; i < TT_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = TT_Search[i].MaTienTe.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                    if (index >= 0)
                                    {
                                        tt1_search_count++;
                                    }
                                }
                                TienTe[] tt1_search = new TienTe[tt1_search_count];
                                tt1_search_count = 0;

                                for (int i = 0; i < TT_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = TT_Search[i].MaTienTe.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                    if (index >= 0)
                                    {
                                        tt1_search[tt1_search_count] = TT_Search[i];
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
                                dataGridView1.DataSource = tt1_search;
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
