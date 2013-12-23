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
    public partial class frmHienThi_KhachHangTraLaiHang : Form
    {
        public frmHienThi_KhachHangTraLaiHang()
        {
            InitializeComponent();
        }

        #region hungvv==============================================khoi tao=====================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.KhachHangTraLai ctdh;
        #endregion

        #region Select============================================================================================================================
        /// <summary>
        /// hungvv =======================giao tiep voi server===========================
        /// </summary>
        private void SelectData()
        {
            dgvHienThi.DataSource = null;
            ctdh = new Entities.KhachHangTraLai();
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            ctdh = new Entities.KhachHangTraLai("Select");
            clientstrem = cl.SerializeObj(this.client, "KhachHangTraLai", ctdh);
            Entities.KhachHangTraLai[] ddh = new Entities.KhachHangTraLai[1];
            ddh = (Entities.KhachHangTraLai[])cl.DeserializeHepper(clientstrem, ddh);
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
            ctdh = new Entities.KhachHangTraLai();
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            ctdh = new Entities.KhachHangTraLai("Delete", ID);
            clientstrem = cl.SerializeObj(this.client, "KhachHangTraLai", ctdh);
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

        private void toolStripStatus_Loc_Click(object sender, EventArgs e)
        {
            frmTimKhachHangTraLaiHang tralai = new frmTimKhachHangTraLaiHang();
            tralai.ShowDialog();
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

        private void toolStripStatus_ThemMoi_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 1000; j++)
            {
                if (frmXuLy_HangTraLai.trave == "")
                {
                    frmXuLy_HangTraLai xuly = new frmXuLy_HangTraLai("Them_KhachHangTraLai", "KhachHangTraLai", "Insert");
                    xuly.ShowDialog();
                    SelectData();
                }
                else
                {
                    frmXuLy_HangTraLai.trave = "";
                    return;
                }
            }
            
        }
        /// <summary>
        /// hungvv =================sua====================
        /// </summary>
        /// <returns></returns>
        private Entities.KhachHangTraLai getDatagridview()
        {
            Entities.KhachHangTraLai tralai = new Entities.KhachHangTraLai();
            int x = dgvHienThi.RowCount;
            int y = dgvHienThi.ColumnCount;
            if (y <= -1 || x <= -1)
            { }
            else
            {
                int vitri = dgvHienThi.CurrentRow.Index;
                tralai.MaKhachHangTraLai = "" + dgvHienThi.Rows[vitri].Cells["MaKhachHangTraLai"].Value.ToString();
                tralai.NgayNhap = Convert.ToDateTime("" + dgvHienThi.Rows[vitri].Cells["NgayNhap"].Value.ToString());
                tralai.MaKhachHang = "" + dgvHienThi.Rows[vitri].Cells[4].Value.ToString();
                tralai.NoHienThoi = dgvHienThi.Rows[vitri].Cells[5].Value.ToString();
                tralai.NguoiTra = "" + dgvHienThi.Rows[vitri].Cells[6].Value.ToString();
                tralai.HinhThucThanhToan = "" + dgvHienThi.Rows[vitri].Cells["HinhThucThanhToan"].Value.ToString();
                tralai.HanThanhToan = Convert.ToDateTime("" + dgvHienThi.Rows[vitri].Cells["HanThanhToan"].Value.ToString());
                tralai.MaHoaDonMuaHang =  dgvHienThi.Rows[vitri].Cells["MaHoaDonMuaHang"].Value.ToString();
                tralai.MaKho = "" + dgvHienThi.Rows[vitri].Cells["MaKho"].Value.ToString();
                tralai.MaTienTe = "" + dgvHienThi.Rows[vitri].Cells["MaTienTe"].Value.ToString();
                tralai.TienBoiThuong =  dgvHienThi.Rows[vitri].Cells["TienBoiThuong"].Value.ToString();
                tralai.ThanhToanNgay = dgvHienThi.Rows[vitri].Cells["ThanhToanNgay"].Value.ToString();
                tralai.ThueGTGT =  dgvHienThi.Rows[vitri].Cells["ThueGTGT"].Value.ToString();
                tralai.GhiChu = "" + dgvHienThi.Rows[vitri].Cells["GhiChu"].Value.ToString();
            }
            return tralai;
        }
        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            frmXuLy_HangTraLai xuly = new frmXuLy_HangTraLai("Sua_KhachHangTraLai", "KhachHangTraLai", "Update",getDatagridview());
            xuly.ShowDialog();
        }

        private void toolStripStatus_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int x = dgvHienThi.RowCount;
                int y = dgvHienThi.ColumnCount;
                if (y <= -1 || x <= -1)
                {
                    MessageBox.Show("Chọn dòng muốn xóa");
                }
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

        private void frmHienThi_KhachHangTraLaiHang_Load(object sender, EventArgs e)
        {
            SelectData();
        }

        private void dgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmXuLy_HangTraLai xuly = new frmXuLy_HangTraLai("Sua_KhachHangTraLai", "KhachHangTraLai", "Update", getDatagridview());
            xuly.ShowDialog();
            SelectData();
        }

        private void frmHienThi_KhachHangTraLaiHang_DoubleClick(object sender, EventArgs e)
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
