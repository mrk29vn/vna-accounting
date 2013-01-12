using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Server_Client;

namespace GUI
{
    public partial class frmHienThi_TraLaiNhaCungCap : Form
    {
        public frmHienThi_TraLaiNhaCungCap()
        {
            InitializeComponent();
        }

        #region hungvv==============================================khoi tao=====================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.TraLaiNCC ctdh;
        #endregion

        #region Select============================================================================================================================
        /// <summary>
        /// hungvv =======================giao tiep voi server===========================
        /// </summary>
        private void SelectData()
        {
            dgvHienThi.DataSource = null;
            ctdh = new Entities.TraLaiNCC();
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            ctdh = new Entities.TraLaiNCC("Select");
            clientstrem = cl.SerializeObj(this.client, "TraLaiNhaCungCap", ctdh);
            Entities.TraLaiNCC[] ddh = new Entities.TraLaiNCC[1];
            ddh = (Entities.TraLaiNCC[])cl.DeserializeHepper(clientstrem, ddh);
            dgvHienThi.DataSource = ddh;
            dgvHienThi.Columns[1].Visible = false;
            dgvHienThi.Columns[0].HeaderText = "STT";
            new Common.Utilities().CountDatagridview(dgvHienThi);
        }

        /// <summary>
        /// hungvv =======================Xoa ===========================
        /// </summary>
        private void DeleteData(string ID)
        {
            ctdh = new Entities.TraLaiNCC();
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            ctdh = new Entities.TraLaiNCC("Delete", ID);
            clientstrem = cl.SerializeObj(this.client, "TraLaiNhaCungCap", ctdh);
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
        #endregion


        private void toolStripStatus_ThemMoi_Click(object sender, EventArgs e)
        {
            frmXuLy_HangTraLai xuly = new frmXuLy_HangTraLai("Them_TraLaiNhaCungCap", "TraLaiNhaCungCap","Insert");
            xuly.ShowDialog();
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

        private Entities.TraLaiNCC getDatagridview()
        {
            Entities.TraLaiNCC tra = new Entities.TraLaiNCC();
            int x = dgvHienThi.RowCount;
            int y = dgvHienThi.ColumnCount;
            if (y <= -1 || x <= -1)
            { }
            else
            {
                int vitri = dgvHienThi.CurrentRow.Index;
                tra.MaHDTraLaiNCC = "" + dgvHienThi.Rows[vitri].Cells["MaHDTraLaiNCC"].Value.ToString().ToUpper();
                tra.Ngaytra = DateTime.Parse("" + dgvHienThi.Rows[vitri].Cells["Ngaytra"].Value.ToString());
                tra.MaNCC = "" + dgvHienThi.Rows[vitri].Cells["MaNCC"].Value.ToString().ToUpper();
                tra.NoHienThoi = dgvHienThi.Rows[vitri].Cells["NoHienThoi"].Value.ToString();
                tra.NguoiNhanHang = "" + dgvHienThi.Rows[vitri].Cells["NguoiNhanHang"].Value.ToString();
                tra.HinhThucThanhToan = "" + dgvHienThi.Rows[vitri].Cells["HinhThucThanhToan"].Value.ToString();
                tra.MaHoaDonNhap = "" + dgvHienThi.Rows[vitri].Cells["MaHoaDonNhap"].Value.ToString().ToUpper();
                tra.MaKho = dgvHienThi.Rows[vitri].Cells["MaKho"].Value.ToString();
                tra.MaTienTe = "" + dgvHienThi.Rows[vitri].Cells["MaTienTe"].Value.ToString().ToUpper();
                tra.TienBoiThuong = dgvHienThi.Rows[vitri].Cells["TienBoiThuong"].Value.ToString();
                tra.ThanhToanNgay = dgvHienThi.Rows[vitri].Cells["ThanhToanNgay"].Value.ToString();
                tra.ThueGTGT = dgvHienThi.Rows[vitri].Cells["ThueGTGT"].Value.ToString();
                tra.GhiChu = dgvHienThi.Rows[vitri].Cells["GhiChu"].Value.ToString();
            }
            return tra;
        }

        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            frmXuLy_HangTraLai xuly = new frmXuLy_HangTraLai("Sua_TraLaiNhaCungCap", "TraLaiNhaCungCap","Update",getDatagridview());
            xuly.ShowDialog();
        }

        private void toolStripStatus_Loc_Click(object sender, EventArgs e)
        {
            frmTimHangTraLaiNhaCungCap tra = new frmTimHangTraLaiNhaCungCap();
            tra.ShowDialog();
        }

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

        private void toolStripStatus_In_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void frmHienThi_TraLaiNhaCungCap_Load(object sender, EventArgs e)
        {
            SelectData();
        }

        private void dgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmXuLy_HangTraLai xuly = new frmXuLy_HangTraLai("Sua_TraLaiNhaCungCap", "TraLaiNhaCungCap", "Update", getDatagridview());
            xuly.ShowDialog();
        }

        private void frmHienThi_TraLaiNhaCungCap_DoubleClick(object sender, EventArgs e)
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
