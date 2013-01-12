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
    public partial class frmQuanlyKMthuchi : Form
    {
        public frmQuanlyKMthuchi()
        {
            InitializeComponent();
        }
        int x = 0;
        KMThuChi[] KM_Search;
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
                frmXuly_KMThuChi fr = new frmXuly_KMThuChi("Them", dataGridView1.CurrentRow);
                fr.StartPosition = FormStartPosition.CenterScreen;
                fr.ShowDialog();
                x = 0;
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
            frmXuly_KMThuChi fr = new frmXuly_KMThuChi("Sua", dataGridView1.CurrentRow);
            fr.StartPosition = FormStartPosition.CenterScreen;
            fr.ShowDialog();
            x = 0;
            hienthi();
          
        }
        public TcpClient client1;
        public NetworkStream clientstrem;
        KMThuChi KM;

        public void hienthi()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            KM = new KMThuChi("Select", 1, "a", "a", true, "a", "a", "a", "a", false," ");
            clientstrem = cl.SerializeObj(this.client1, "KMThuChi", KM);

            KMThuChi[] tk1 = new KMThuChi[1];
            tk1[0] = new KMThuChi(1, "a", "a", true, "a", "a", "a", "a", false,"");
            tk1 = (KMThuChi[])cl.DeserializeHepper1(clientstrem, tk1);
            
            if (tk1 == null)
            {
                Entities.KMThuChi[] km = new KMThuChi[0];
                KM_Search = km;
                dataGridView1.DataSource = km;
                FixDataGridView();
                toolStripStatus_Sua.Enabled = false;
                toolStripStatus_Xoa.Enabled = false;
            }
            else
            {
                KM_Search = tk1;
                dataGridView1.DataSource = tk1;
                FixDataGridView();
                toolStripStatus_Sua.Enabled = true;
                toolStripStatus_Xoa.Enabled = true;
            }
        }

        public void FixDataGridView()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].HeaderText = "STT";
            dataGridView1.Columns[dataGridView1.ColumnCount - 2].Visible = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ReadOnly = true;
            new Common.Utilities().CountDatagridview(dataGridView1);
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "Mã Khoản Mục";
            dataGridView1.Columns[3].HeaderText = "Tên Khoản Mục";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].HeaderText = "Đối Tượng";
            dataGridView1.Columns[6].HeaderText = "Nợ Tài Khoản";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Có Tài Khoản";
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Ghi Chú";
            dataGridView1.Columns[10].HeaderText = "Loại Khoản Mục";
        }

        private void frmQuanlyKMthuchi_Load(object sender, EventArgs e)
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
                    int idcurent = int.Parse(dataGridView1.CurrentRow.Cells["ThuChiID"].Value.ToString());
                    string ten = dataGridView1.CurrentRow.Cells["TenKhoanMuc"].Value.ToString();
                    string maCurrent = dataGridView1.CurrentRow.Cells["MaKhoanMuc"].Value.ToString();
                    hienthi();
                    for (int j = 0; j < KM_Search.Length; j++)
                    {
                        if (KM_Search[j].Deleted == false)
                            if (KM_Search[j].ThuChiID == idcurent)
                            {
                                ktdelete = true;
                                break;
                            }
                    }
                    if (ktdelete == true)
                    {
                        try
                        {
                            if (new Check().CheckReference("KMThuChi", ten))
                            {
                                Server_Client.Client cl = new Server_Client.Client();
                                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                                Entities.KMThuChi nv = new KMThuChi("Delete", idcurent, maCurrent,Common.Utilities.User.NhanVienID,Common.Utilities.User.TenDangNhap);
                                clientstrem = cl.SerializeObj(this.client1, "KMThuChi", nv);
                                //MessageBox.Show("Xoa Thanh Cong...");
                            }
                            else
                            {
                                MessageBox.Show("Khoản Mục Này Hiện Đang Có Giao Dịch - Không Thể Xóa!","Hệ Thống Cảnh Báo");
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
                frmXuly_KMThuChi fr = new frmXuly_KMThuChi("Sua", dataGridView1.Rows[e.RowIndex]);
                fr.StartPosition = FormStartPosition.CenterScreen;
                fr.ShowDialog();
                x = 0;
                hienthi();
            }
        }

        private void rdbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTatCa.Checked==true)
            {
            
                hienthi();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (rdbTen.Checked==true)
            {

                if (KM_Search==null)
                {
                    Entities.KMThuChi[] km = new KMThuChi[0];
                    dataGridView1.DataSource = km;
                    FixDataGridView();
                    toolStripStatus_Sua.Enabled = false;
                    toolStripStatus_Xoa.Enabled = false;
                    
                }
                else
                    if (KM_Search != null)
                    {
                        if (txtTimKiem.Text.Length == 0)
                        {
                            Entities.KMThuChi[] km = new KMThuChi[0];
                            dataGridView1.DataSource = km;
                            FixDataGridView();
                            toolStripStatus_Sua.Enabled = false;
                            toolStripStatus_Xoa.Enabled = false;
                        }
                        else
                        {
                            int tk1_search_count = 0;

                            for (int i = 0; i < KM_Search.Length; i++)
                            {
                                int index = -1;
                                index = KM_Search[i].TenKhoanMuc.ToLower().IndexOf(txtTimKiem.Text.ToLower());
                                if (index >= 0)
                                {
                                    tk1_search_count++;
                                }
                            }
                            KMThuChi[] tk1_search = new KMThuChi[tk1_search_count];
                            tk1_search_count = 0;

                            for (int i = 0; i < KM_Search.Length; i++)
                            {
                                int index = -1;
                                index = KM_Search[i].TenKhoanMuc.ToLower().IndexOf(txtTimKiem.Text.ToLower());
                                if (index >= 0)
                                {
                                    tk1_search[tk1_search_count] = KM_Search[i];
                                    tk1_search_count++;
                                }
                            }

                            if (tk1_search_count == 0)
                            {
                                toolStripStatus_Sua.Enabled = false;
                                toolStripStatus_Xoa.Enabled = false;
                            }
                            else
                            {
                                toolStripStatus_Sua.Enabled = true;
                                toolStripStatus_Xoa.Enabled = true;
                            }
                            dataGridView1.DataSource = tk1_search;
                            FixDataGridView();
                           
                        }
                    }
            }
            else
                if (rdbMa.Checked == true)
                {
                    if (KM_Search == null)
                    {
                        Entities.KMThuChi[] km = new KMThuChi[0];
                        dataGridView1.DataSource = km;
                        FixDataGridView();
                        toolStripStatus_Sua.Enabled = false;
                        toolStripStatus_Xoa.Enabled = false;
                    }
                    else
                        if (KM_Search != null)
                        {
                            if (txtTimKiem.Text.Length == 0)
                            {
                                Entities.KMThuChi[] km = new KMThuChi[0];
                                dataGridView1.DataSource = km;
                                FixDataGridView();
                                toolStripStatus_Sua.Enabled = false;
                                toolStripStatus_Xoa.Enabled = false;
                            }
                            else
                            {
                                int tk1_search_count = 0;

                                for (int i = 0; i < KM_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = KM_Search[i].MaKhoanMuc.ToLower().IndexOf(txtTimKiem.Text.ToLower());
                                    if (index >= 0)
                                    {
                                        tk1_search_count++;
                                    }
                                }
                                KMThuChi[] tk1_search = new KMThuChi[tk1_search_count];
                                tk1_search_count = 0;

                                for (int i = 0; i < KM_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = KM_Search[i].MaKhoanMuc.ToLower().IndexOf(txtTimKiem.Text.ToLower());
                                    if (index >= 0)
                                    {
                                        tk1_search[tk1_search_count] = KM_Search[i];
                                        tk1_search_count++;
                                    }
                                }
                                if (tk1_search_count == 0)
                                {
                                    toolStripStatus_Sua.Enabled = false;
                                    toolStripStatus_Xoa.Enabled = false;
                                }
                                else
                                {
                                    toolStripStatus_Sua.Enabled = true;
                                    toolStripStatus_Xoa.Enabled = true;
                                }
                                dataGridView1.DataSource = tk1_search;
                                FixDataGridView();
                            }
                        }
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
