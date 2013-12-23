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
    public partial class frmHienThi_HoaDonNhap : Form
    {
        public frmHienThi_HoaDonNhap()
        {
            InitializeComponent();
        }

        #region hungvv==============================================khoi tao=====================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.HoaDonNhap ctdh;
        #endregion

        #region Select============================================================================================================================
        /// <summary>
        /// hungvv =======================giao tiep voi server===========================
        /// </summary>
        private void SelectData()
        {
            dgvHienThi.DataSource = null;
            ctdh = new Entities.HoaDonNhap();
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            ctdh = new Entities.HoaDonNhap("Select");
            clientstrem = cl.SerializeObj(this.client, "HoaDonNhap", ctdh);
            Entities.HoaDonNhap[] ddh = new Entities.HoaDonNhap[1];
            ddh = (Entities.HoaDonNhap[])cl.DeserializeHepper(clientstrem, ddh);
            dgvHienThi.DataSource = ddh;
            dgvHienThi.Columns[1].Visible = false;
            dgvHienThi.Columns[0].HeaderText = "STT";
            new Common.Utilities().CountDatagridview(dgvHienThi);
            client.Close();
            clientstrem.Close();
        }

        /// <summary>
        /// hungvv =======================Xoa ===========================
        /// </summary>
        private void DeleteData(string ID)
        {
            ctdh = new Entities.HoaDonNhap();
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            ctdh = new Entities.HoaDonNhap("Delete",ID);
            clientstrem = cl.SerializeObj(this.client, "HoaDonNhap", ctdh);
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

        private void frmQuanlynhapmua_Load(object sender, EventArgs e)
        {
           SelectData();
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
        public static string BaoDong = "";
        private void toolStripStatus_ThemMoi_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 1000; j++)
            {
                if (BaoDong == "")
                {
                    frmXuLy_HoaDonNhap fr = new frmXuLy_HoaDonNhap("Insert");
                    fr.ShowDialog();
                    SelectData();
                }
                else
                {
                    BaoDong = "";
                    break;
                }
            }
          
        }
        /// <summary>
        /// hungvv =================sua====================
        /// </summary>
        /// <returns></returns>
        private Entities.HoaDonNhap getDatagridview()
        {
            Entities.HoaDonNhap dathang = new Entities.HoaDonNhap();
            int x = dgvHienThi.RowCount;
            int y = dgvHienThi.ColumnCount;
            if (y <= -1 || x <= -1)
            { }
            else
            {
                int vitri = dgvHienThi.CurrentRow.Index;
                dathang.MaHoaDonNhap = "" + dgvHienThi.Rows[vitri].Cells[2].Value.ToString().ToUpper();
                dathang.NgayNhap = DateTime.Parse("" + dgvHienThi.Rows[vitri].Cells[3].Value.ToString());
                dathang.MaNhaCungCap = "" + dgvHienThi.Rows[vitri].Cells[4].Value.ToString().ToUpper();
                dathang.NoHienThoi = dgvHienThi.Rows[vitri].Cells[5].Value.ToString();
                dathang.NguoiGiaoHang = ""+dgvHienThi.Rows[vitri].Cells[6].Value.ToString();
                dathang.HinhThucThanhToan = "" + dgvHienThi.Rows[vitri].Cells[7].Value.ToString();
                dathang.MaKho = "" + dgvHienThi.Rows[vitri].Cells[8].Value.ToString().ToUpper();
                dathang.DieuKienThanhToan = "" + dgvHienThi.Rows[vitri].Cells[9].Value.ToString();
                dathang.MaDonDatHang = "" + dgvHienThi.Rows[vitri].Cells[11].Value.ToString().ToUpper();
                dathang.HanThanhToan = DateTime.Parse(dgvHienThi.Rows[vitri].Cells[10].Value.ToString());
                dathang.MaTienTe = "" + dgvHienThi.Rows[vitri].Cells[12].Value.ToString().ToUpper();
                dathang.ChietKhau = dgvHienThi.Rows[vitri].Cells[13].Value.ToString();
                dathang.ThanhToanNgay =dgvHienThi.Rows[vitri].Cells[14].Value.ToString();
                dathang.ThueGTGT = dgvHienThi.Rows[vitri].Cells[15].Value.ToString();
                dathang.TongTien = dgvHienThi.Rows[vitri].Cells[16].Value.ToString();
                dathang.GhiChu = "" + dgvHienThi.Rows[vitri].Cells[17].Value.ToString();
            }
            return dathang;
        }


        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            BaoDong = "";
            for (int j = 0; j < 1000; j++)
            {
                if (BaoDong == "")
                {
                    frmXuLy_HoaDonNhap fr = new frmXuLy_HoaDonNhap("Update", getDatagridview());
                    fr.ShowDialog();
                    SelectData();
                }
                else
                {
                    BaoDong = "";
                    break;
                }
            }
          
        }

        private void lblDatmua_Click(object sender, EventArgs e)
        {

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

        private void dgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BaoDong = "";
            for (int j = 0; j < 1000; j++)
            {
                if (BaoDong == "")
                {
                    frmXuLy_HoaDonNhap fr = new frmXuLy_HoaDonNhap("Update", getDatagridview());
                    fr.ShowDialog();
                    SelectData();
                }
                else
                {
                    BaoDong = "";
                    break;
                }
            }
        }

        private void frmHienThi_HoaDonNhap_DoubleClick(object sender, EventArgs e)
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
