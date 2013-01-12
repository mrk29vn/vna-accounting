#region
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Collections;

namespace GUI
{
    public partial class frmQuanLyKhachHangTraLaiHang : Form
    {
        #region==============================Vương Hùng===========================================================
        public frmQuanLyKhachHangTraLaiHang()
        {
            InitializeComponent();
        }
        #endregion

        #region===================================================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.KhachHangTraLai ctdh;
        #endregion

        #region===================================================================================================
        private void fixDatagridview()
        {
            try
            {
                for (int i = 1; i < dgvHienThi.ColumnCount; i++)
                {
                    dgvHienThi.Columns[i].Visible = false;
                }
                dgvHienThi.RowHeadersVisible = false;
                dgvHienThi.Columns[0].Visible = true;
                dgvHienThi.Columns[0].HeaderText = "STT";
                dgvHienThi.Columns[2].Visible = true;
                dgvHienThi.Columns[2].HeaderText = "Mã KHTL";
                dgvHienThi.Columns[3].Visible = true;
                dgvHienThi.Columns[3].HeaderText = "Ngày nhập";
                dgvHienThi.Columns[5].Visible = true;
                dgvHienThi.Columns[5].HeaderText = "Nợ hiện thời";
                dgvHienThi.Columns[6].Visible = true;
                dgvHienThi.Columns[6].HeaderText = "Người trả";
                dgvHienThi.Columns[8].Visible = true;
                dgvHienThi.Columns[8].HeaderText = "Hạn thanh toán";
                dgvHienThi.Columns[9].Visible = true;
                dgvHienThi.Columns[9].HeaderText = "Hóa đơn bán hàng";
                dgvHienThi.Columns[15].Visible = true;
                dgvHienThi.Columns[15].HeaderText = "Ghi chú";
                dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (dgvHienThi.Rows.Count > 0)
                {
                    dgvHienThi.Columns[0].HeaderText = "STT";
                    new Common.Utilities().CountDatagridview(dgvHienThi);
                }
                else
                { dgvHienThi.Columns[0].Visible = false; }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// hungvv =======================giao tiep voi server===========================
        /// </summary>
        private void SelectData(string ID)
        {
            try
            {
                dgvHienThi.DataSource = null;
                ctdh = new Entities.KhachHangTraLai();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                ctdh = new Entities.KhachHangTraLai("Select", ID);
                clientstrem = cl.SerializeObj(this.client, "KhachHangTraLai", ctdh);
                Entities.KhachHangTraLai[] ddh = new Entities.KhachHangTraLai[1];
                ddh = (Entities.KhachHangTraLai[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length > 0)
                {
                    search = new Entities.KhachHangTraLai[ddh.Length];
                    search = ddh;
                    dgvHienThi.DataSource = null;
                    dgvHienThi.DataSource = ddh;
                    rdoTatca.Checked = true;
                }
                else
                {
                    CapNhat(dgvHienThi);
                }
                fixDatagridview();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                CapNhat(dgvHienThi);
                fixDatagridview();
            }
        }

        /// <summary>
        /// hungvv =======================Xoa ===========================
        /// </summary>
        private void DeleteData(string ID)
        {
            try
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
                if (trave >= 1)
                {
                    SelectData("");
                }
                else
                {
                    MessageBox.Show("Thất bại !");
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        /// <summary>
        /// add giatri vao combox
        /// </summary>
        /// <param name="hanhdong"></param>
        #endregion

        #region===================================================================================================
        private void toolStripStatus_Dong_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmQuanLyKhachHangTraLaiHang.BaoDong = "A";
                        this.Close();
                    }
                    else
                    { }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        public static string BaoDong = "";
        private void toolStripStatus_ThemMoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && !CheckQuyen(this.Name, 4))
                { return; }
                for (int j = 0; j < 100; j++)
                {
                    if (BaoDong == "")
                    {
                        frmXuLyHangTraLai xuly = new frmXuLyHangTraLai("Them_KhachHangTraLai", "KhachHangTraLai", "Insert");
                        xuly.ShowDialog();
                        SelectData("");
                    }
                    else
                    {
                        BaoDong = "";
                        break;
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }

        }
        /// <summary>
        /// hungvv =================sua====================
        /// </summary>
        /// <returns></returns>
        private Entities.KhachHangTraLai getDatagridview()
        {
            Entities.KhachHangTraLai tralai = new Entities.KhachHangTraLai();
            try
            {
                if (dgvHienThi.RowCount > 0)
                {
                    int x = dgvHienThi.RowCount;
                    int y = dgvHienThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        int vitri = dgvHienThi.CurrentRow.Index;
                        tralai.KhachHangTraLaiID = int.Parse(dgvHienThi.Rows[vitri].Cells[1].Value.ToString());
                        tralai.MaKhachHangTraLai = dgvHienThi.Rows[vitri].Cells[2].Value.ToString();
                        tralai.NgayNhap = Convert.ToDateTime(dgvHienThi.Rows[vitri].Cells[3].Value.ToString());
                        tralai.MaKhachHang = dgvHienThi.Rows[vitri].Cells[4].Value.ToString();
                        tralai.NoHienThoi = dgvHienThi.Rows[vitri].Cells[5].Value.ToString();
                        tralai.NguoiTra = dgvHienThi.Rows[vitri].Cells[6].Value.ToString();
                        tralai.HinhThucThanhToan = dgvHienThi.Rows[vitri].Cells[7].Value.ToString();
                        tralai.HanThanhToan = Convert.ToDateTime(dgvHienThi.Rows[vitri].Cells[8].Value.ToString());
                        tralai.MaHoaDonMuaHang = dgvHienThi.Rows[vitri].Cells[9].Value.ToString();
                        tralai.MaKho = dgvHienThi.Rows[vitri].Cells[10].Value.ToString();
                        tralai.MaTienTe = dgvHienThi.Rows[vitri].Cells[11].Value.ToString();
                        tralai.TienBoiThuong = dgvHienThi.Rows[vitri].Cells[12].Value.ToString();
                        tralai.ThanhToanNgay = dgvHienThi.Rows[vitri].Cells[13].Value.ToString();
                        tralai.ThueGTGT = dgvHienThi.Rows[vitri].Cells[14].Value.ToString();
                        tralai.GhiChu = dgvHienThi.Rows[vitri].Cells[15].Value.ToString();
                        tralai.Deleted = Boolean.Parse(dgvHienThi.Rows[vitri].Cells[16].Value.ToString());
                    }
                }
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            return tralai;
        }
        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && !CheckQuyen(this.Name, 1))
                { return; }
                if (dgvHienThi.RowCount > 0)
                {
                    frmXuLyHangTraLai xuly = new frmXuLyHangTraLai("Sua_KhachHangTraLai", "KhachHangTraLai", "Update", getDatagridview());
                    xuly.ShowDialog();
                    SelectData("");
                }
                else
                { MessageBox.Show("Không có hóa đơn sửa"); }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void toolStripStatus_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHienThi.RowCount > 0)
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
                else { }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); MessageBox.Show("Dữ liệu đã xóa hết"); }
        }

        private void toolStripStatus_In_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hưởng làm");
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
            return true;
        }
        private void frmHienThi_KhachHangTraLaiHang_Load(object sender, EventArgs e)
        {
            try
            {
                SelectData("");
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void dgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHienThi.RowCount > 0)
                {
                    frmXuLyHangTraLai xuly = new frmXuLyHangTraLai("Sua_KhachHangTraLai", "KhachHangTraLai", "Update", getDatagridview());
                    xuly.ShowDialog();
                    SelectData("");
                }
                else
                { MessageBox.Show("Không có hóa đơn sửa"); }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void frmHienThi_KhachHangTraLaiHang_DoubleClick(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void palTencung_DoubleClick(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            { string s = ex.Message; }

        }
        #endregion

        #region===================================================================================================
        /// <summary>
        /// search
        /// </summary>
        private Entities.KhachHangTraLai[] search;
        private void CapNhat(DataGridView dgv)
        {
            try
            {
                Entities.KhachHangTraLai[] lay = new Entities.KhachHangTraLai[0];
                dgv.DataSource = lay;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void SearchData(RadioButton rdoMa, RadioButton rdoNgay, RadioButton rdoTatCa, DataGridView dgv, string giatritim)
        {
            try
            {
                if (search.Length > 0)
                {
                    if (rdoMa.Checked)
                    {
                        List<Entities.KhachHangTraLai> hienthitheoma = new List<Entities.KhachHangTraLai>();
                        for (int i = 0; i < search.Length; i++)
                        {
                            int kiemtra = search[i].MaKhachHangTraLai.ToString().ToUpper().IndexOf(txtTimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma.Add(search[i]);
                            }
                        }
                        dgv.DataSource = hienthitheoma;

                    }
                    if (rdoNgay.Checked)
                    {
                        List<Entities.KhachHangTraLai> hienthitheoma = new List<Entities.KhachHangTraLai>();
                        for (int i = 0; i < search.Length; i++)
                        {
                            int kiemtra = search[i].NgayNhap.ToString().ToUpper().IndexOf(txtTimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma.Add(search[i]);
                            }
                        }
                        dgv.DataSource = hienthitheoma;
                    }
                    if (rdoTatca.Checked == true)
                    {
                        dgv.DataSource = null;
                        dgv.DataSource = search;
                    }
                }
                else
                { CapNhat(dgv); }
                fixDatagridview();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                CapNhat(dgv);
                fixDatagridview();
            }
        }
        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchData(rdoMakho, rdoTenkho, rdoTatca, dgvHienThi, txtTimkiem.Text);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                CapNhat(dgvHienThi);
                fixDatagridview();
            }
        }

        private void rdoTatca_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (rdoTatca.Checked)
                    SearchData(rdoMakho, rdoTenkho, rdoTatca, dgvHienThi, txtTimkiem.Text);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                CapNhat(dgvHienThi);
                fixDatagridview();
            }
        }

        //private void rdoTenkho_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        SearchData(rdoMakho, rdoTenkho, rdoTatca, dgvHienThi, txtTimkiem.Text);
        //    }
        //    catch (Exception ex)
        //    {
        //        string s = ex.Message;
        //        CapNhat(dgvHienThi);
        //        fixDatagridview();
        //    }
        //}

        //private void rdoMakho_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        SearchData(rdoMakho, rdoTenkho, rdoTatca, dgvHienThi, txtTimkiem.Text);
        //    }
        //    catch (Exception ex)
        //    {
        //        string s = ex.Message;
        //        CapNhat(dgvHienThi);
        //        fixDatagridview();
        //    }
        //}
        #endregion

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                SelectData("");
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void toolStripStatus_Xoa_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void toolStripStatus_Xoa_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void toolStripStatus_Dong_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void toolStripStatus_Dong_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void toolStripStatus_Sua_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void toolStripStatus_Sua_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void toolStripStatus_ThemMoi_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void toolStripStatus_ThemMoi_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void toolStripStatusLabel1_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void toolStripStatusLabel1_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }
    }
}
#endregion
