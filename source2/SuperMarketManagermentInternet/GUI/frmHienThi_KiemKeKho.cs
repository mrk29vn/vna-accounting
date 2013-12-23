using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmHienThi_KiemKeKho : Form
    {
        public frmHienThi_KiemKeKho()
        {
            InitializeComponent();
        }

        #region hungvv==============================================khoi tao=====================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.KiemKeKho kk;
        #endregion

        #region Select============================================================================================================================
        /// <summary>
        /// hungvv =======================giao tiep voi server===========================
        /// </summary>
        private void SelectData()
        {
            dgvHienThi.DataSource = null;
            kk = new Entities.KiemKeKho();
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            kk = new Entities.KiemKeKho("Select");
            clientstrem = cl.SerializeObj(this.client, "KiemKeKho", kk);
            Entities.KiemKeKho[] ddh = new Entities.KiemKeKho[1];
            ddh = (Entities.KiemKeKho[])cl.DeserializeHepper(clientstrem, ddh);
            dgvHienThi.DataSource = ddh;
            dgvHienThi.Columns[1].Visible = false;
            dgvHienThi.Columns[0].HeaderText = "STT";
            new Common.Utilities().CountDatagridview(dgvHienThi);
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            client.Close();
            clientstrem.Close();
        }

        /// <summary>
        /// hungvv =======================Xoa ===========================
        /// </summary>
        private void DeleteData(string ID)
        {
            kk = new Entities.KiemKeKho();
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            kk = new Entities.KiemKeKho("Delete", ID);
            clientstrem = cl.SerializeObj(this.client, "KiemKeKho", kk);
            int trave = 0;
            trave = System.Convert.ToInt32(cl.DeserializeHepper(clientstrem, trave));
            client.Close();
            clientstrem.Close();
            if (trave == 1)
            {
                SelectData();
                MessageBox.Show("Thành công !");
            }
            if (trave == 0)
            {
                MessageBox.Show("Thất bại !");
            }
        }
        /// <summary>
        /// add giatri vao combox
        /// </summary>
        /// <param name="hanhdong"></param>
        #endregion

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

        public static string BaoDong = "";
        private void toolStripStatus_ThemMoi_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 1000; j++)
            {
                if (BaoDong == "")
                {
                    frmXuLy_KiemKeKho kk = new frmXuLy_KiemKeKho("Insert");
                    kk.ShowDialog();
                    SelectData();
                }
                else
                {
                    BaoDong = "";
                    break;
                }
            }
           
        }

        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 1000; j++)
            {
                if (BaoDong == "")
                {
                    frmXuLy_KiemKeKho kk = new frmXuLy_KiemKeKho("Update", getDatagridview());
                    kk.ShowDialog();
                    SelectData();
                }
                else
                {
                    BaoDong = "";
                    break;
                }
            }
        }

        private void toolStripStatus_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int x = dgvHienThi.RowCount;
                int y = dgvHienThi.ColumnCount;
                if (y <= -1 || x <= -1)
                {}
                else
                {
                    System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn muốn xóa không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                    {
                        if (giatri == System.Windows.Forms.DialogResult.Yes)
                        {
                            int vitri = dgvHienThi.CurrentRow.Index;
                            string ID = dgvHienThi.Rows[vitri].Cells[2].Value.ToString();
                            DeleteData(ID);
                        }
                        else
                        { }
                    }

                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); MessageBox.Show("Dữ liệu đã xóa hết"); }
        }

        private void toolStripStatus_Loc_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void toolStripStatus_In_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void frmHienThi_KiemKeKho_Load(object sender, EventArgs e)
        {
            SelectData();
        }
        /// <summary>
        /// hungvv =================sua====================
        /// </summary>
        /// <returns></returns>
        private Entities.KiemKeKho getDatagridview()
        {
            Entities.KiemKeKho dathang = new Entities.KiemKeKho();
            int x = dgvHienThi.RowCount;
            int y = dgvHienThi.ColumnCount;
            if (y <= -1 || x <= -1)
            { }
            else
            {
                int vitri = dgvHienThi.CurrentRow.Index;
                dathang.MaKiemKe = "" + dgvHienThi.Rows[vitri].Cells[2].Value.ToString().ToUpper();
                dathang.NgayKiemKe = Convert.ToDateTime("" + dgvHienThi.Rows[vitri].Cells[3].Value.ToString());
                dathang.MaKho = "" + dgvHienThi.Rows[vitri].Cells[4].Value.ToString().ToUpper();
                dathang.MaTKNganHang = "" + dgvHienThi.Rows[vitri].Cells[5].Value.ToString().ToUpper();
                dathang.GhiChu = ""+dgvHienThi.Rows[vitri].Cells[6].Value.ToString();
            }
            return dathang;
        }

        private void dgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int j = 0; j < 1000; j++)
            {
                if (BaoDong == "")
                {
                    frmXuLy_KiemKeKho kk = new frmXuLy_KiemKeKho("Update", getDatagridview());
                    kk.ShowDialog();
                    SelectData();
                }
                else
                {
                    BaoDong = "";
                    break;
                }
            }
        }

        private void frmHienThi_KiemKeKho_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
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
