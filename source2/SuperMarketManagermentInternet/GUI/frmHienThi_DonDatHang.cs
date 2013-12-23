using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using BizLogic;
using DAL;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Server_Client;

namespace GUI
{
    public partial class frmHienThi_DonDatHang : Form
    {
        public frmHienThi_DonDatHang()
        {
            InitializeComponent();
        }

        #region hungvv==============================================khoi tao=====================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        private Entities.DonDatHang dh;
        private Server_Client.Client cl;

        /// <summary>
        /// hungvv =======================giao tiep voi server===========================
        /// </summary>
        private void SelectData()
        {
            try
            {
                dgvHienThi.DataSource = null;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                dh = new Entities.DonDatHang("Select");
                clientstrem = cl.SerializeObj(this.client, "DonDatHang", dh);
                Entities.DonDatHang[] ddh = new Entities.DonDatHang[1];
                ddh = (Entities.DonDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                dgvHienThi.DataSource = ddh;
                dgvHienThi.Columns[0].HeaderText = "STT";
                dgvHienThi.Columns[0].Width = 10;
                dgvHienThi.Columns[1].Visible = false;
                dgvHienThi.Columns[2].HeaderText = "Mã đơn đặt hàng";
                dgvHienThi.Columns[3].Visible = false;
                dgvHienThi.Columns[4].HeaderText = "Ngày đơn hàng ";
                dgvHienThi.Columns[5].Visible = false;
                dgvHienThi.Columns[6].Visible = false;
                dgvHienThi.Columns[7].Visible = false;
                dgvHienThi.Columns[8].HeaderText = "Ngày dự kiến";
                dgvHienThi.Columns[9].Visible = false;
                dgvHienThi.Columns[10].Visible = false;
                dgvHienThi.Columns[11].Visible = false;
                dgvHienThi.Columns[12].Visible = false;
                dgvHienThi.Columns[13].Visible = false;
                dgvHienThi.Columns[17].HeaderText = "Thuế GTGT";
                dgvHienThi.Columns[15].Visible = false;
                dgvHienThi.Columns[16].Visible = false;
                dgvHienThi.Columns[17].HeaderText = "Ghi chú";
                dgvHienThi.Columns[18].Visible = false;                
                new Common.Utilities().CountDatagridview(dgvHienThi);
                dgvHienThi.RowHeadersVisible = false;
                dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                MessageBox.Show("Lỗi hiển thị dữ liệu");
            }
        }

        /// <summary>
        /// hungvv =======================Xoa ===========================
        /// </summary>
        private void DeleteData(string ID)
        {
            try
            {
                dh = new Entities.DonDatHang();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                dh = new Entities.DonDatHang("Delete", ID);
                clientstrem = cl.SerializeObj(this.client, "DonDatHang", dh);
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
            catch (Exception)
            { }
        }
        #endregion


        /// <summary>
        /// hungvv form them moi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Running()
        {
            if (Luu.BienTam == "Close")
            {
                frmXuLyDonDatHang insert = new frmXuLyDonDatHang("Insert");
              
                insert.ShowDialog(this);
            }
        }
        /// <summary>
        /// them moi
        /// </summary>
        public static string BaoDong = "";
        private void toolStripStatus_ThemMoi_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 1000; j++)
            {
                if (BaoDong == "")
                {
                    frmXuLyDonDatHang fr = new frmXuLyDonDatHang("Insert");
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
        /// hungvv dong form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// hungvv =================sua====================
        /// </summary>
        /// <returns></returns>
        private Entities.DonDatHang getDatagridview()
        {
            Entities.DonDatHang dathang = new Entities.DonDatHang();
            try
            {
                int x = dgvHienThi.RowCount;
                int y = dgvHienThi.ColumnCount;
                if (y <= -1 || x <= -1)
                { }
                else
                {
                    int vitri = dgvHienThi.CurrentRow.Index;
                    dathang.MaDonDatHang = "" + dgvHienThi.Rows[vitri].Cells[2].Value.ToString();
                    dathang.LoaiDonDatHang = Convert.ToBoolean("" + dgvHienThi.Rows[vitri].Cells[3].Value.ToString());
                    dathang.NgayDonHang = Convert.ToDateTime("" + dgvHienThi.Rows[vitri].Cells[4].Value.ToString());
                    dathang.MaNhaCungCap = "" + dgvHienThi.Rows[vitri].Cells[5].Value.ToString();
                    dathang.NoHienThoi = dgvHienThi.Rows[vitri].Cells[6].Value.ToString();
                    dathang.TrangThaiDonDatHang = "" + dgvHienThi.Rows[vitri].Cells[7].Value.ToString();
                    dathang.NgayNhapDuKien = Convert.ToDateTime("" + dgvHienThi.Rows[vitri].Cells[8].Value.ToString());
                    dathang.DieuKienThanhToan = "" + dgvHienThi.Rows[vitri].Cells[9].Value.ToString();
                    dathang.HinhThucThanhToan = "" + dgvHienThi.Rows[vitri].Cells[10].Value.ToString();
                    dathang.MaKho = "" + dgvHienThi.Rows[vitri].Cells[11].Value.ToString();
                    dathang.MaNhanVien = "" + dgvHienThi.Rows[vitri].Cells[12].Value.ToString();
                    dathang.MaTienTe = "" + dgvHienThi.Rows[vitri].Cells[13].Value.ToString();
                    dathang.ThueGTGT = dgvHienThi.Rows[vitri].Cells[14].Value.ToString();
                    dathang.Phivanchuyen = dgvHienThi.Rows[vitri].Cells[15].Value.ToString();
                    dathang.PhiKhac = dgvHienThi.Rows[vitri].Cells[16].Value.ToString();
                    dathang.GhiChu = "" + dgvHienThi.Rows[vitri].Cells[17].Value.ToString();
                }
            }
            catch (Exception)
            { }
            return dathang;
        }
        /// <summary>
        /// hungvv form sua
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 1000; j++)
            {
                if (BaoDong == "")
                {
                    frmXuLyDonDatHang fr = new frmXuLyDonDatHang("Update", getDatagridview());
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
        /// hungvv xoa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatus_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int x = dgvHienThi.RowCount;
                int y = dgvHienThi.ColumnCount;
                if (y <= -1 || x <= -1)
                { }
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

        /// <summary>
        /// hungvv form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmViewOrderProducts_Load(object sender, EventArgs e)
        {
            SelectData();
        }

        /// <summary>
        /// hungvv loc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatus_Loc_Click(object sender, EventArgs e)
        {
            frmTimHoaDon update = new frmTimHoaDon();
            update.ShowDialog(this);
        }

        /// <summary>
        /// hungvv loc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatus_In_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void dgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int j = 0; j < 1000; j++)
            {
                if (BaoDong == "")
                {
                    frmXuLyDonDatHang fr = new frmXuLyDonDatHang("Update", getDatagridview());
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

        private void palTencung_DoubleClick(object sender, EventArgs e)
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
