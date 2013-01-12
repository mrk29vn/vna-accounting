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
    public partial class frmQuanLyKiemKeKho : Form
    {
        #region=======================================Vương Hùng==================================================
        public frmQuanLyKiemKeKho()
        {
            InitializeComponent();
        }
        #endregion

        #region===================================================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.KiemKeKho kk;
        #endregion

        #region===================================================================================================


        /// <summary>
        /// fixDatagridview
        /// </summary>
        private void fixDatagridview()
        {
            try
            {
                for (int i = 1; i < dgvHienThi.ColumnCount; i++)
                {
                    dgvHienThi.Columns[i].Visible = false;
                }
                dgvHienThi.RowHeadersVisible = false;
                dgvHienThi.Columns[3].Visible = true;
                dgvHienThi.Columns[3].HeaderText = "Ngày kiểm kê";
                dgvHienThi.Columns[5].Visible = true;
                dgvHienThi.Columns[5].HeaderText = "Kho hàng";
                dgvHienThi.Columns[6].Visible = true;
                dgvHienThi.Columns[6].HeaderText = "Ghi chú";
                dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (dgvHienThi.Rows.Count > 0)
                {
                    dgvHienThi.Columns[0].HeaderText = "STT";
                    new Common.Utilities().CountDatagridview(dgvHienThi);
                }
                else
                { dgvHienThi.Columns[0].HeaderText = "STT"; }
                dgvHienThi.Columns[0].Width = 40;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// hungvv =======================giao tiep voi server===========================
        /// </summary>
        private void SelectData(string ma)
        {
            try
            {
                dgvHienThi.DataSource = null;
                kk = new Entities.KiemKeKho();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                kk = new Entities.KiemKeKho("Select", ma);
                clientstrem = cl.SerializeObj(this.client, "KiemKeKho", kk);
                Entities.KiemKeKho[] ddh = new Entities.KiemKeKho[1];
                ddh = (Entities.KiemKeKho[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length > 0)
                {
                    search = ddh;
                    dgvHienThi.DataSource = null;
                    dgvHienThi.DataSource = search;
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
                kk = new Entities.KiemKeKho();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                kk = new Entities.KiemKeKho("Delete", ID);
                kk.Manhanvien = Common.Utilities.User.MaNV;
                kk.Tendangnhap = Common.Utilities.User.TenDangNhap;
                clientstrem = cl.SerializeObj(this.client, "KiemKeKho", kk);
                int trave = 0;
                trave = System.Convert.ToInt32(cl.DeserializeHepper(clientstrem, trave));
                client.Close();
                clientstrem.Close();
                if (trave >= 1)
                {
                    SelectData("");
                    if (dgvHienThi.RowCount <= 0)
                    {
                        search = null;
                    }
                    fixDatagridview();
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
                        frmXuLyKiemKeKho kk = new frmXuLyKiemKeKho("Insert","Thêm mới phiếu kiểm kê kho");
                        kk.ShowDialog();
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

        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && !CheckQuyen(this.Name, 2))
                { return; }
                if (dgvHienThi.RowCount > 0)
                {
                    frmXuLyKiemKeKho kk = new frmXuLyKiemKeKho("Update","Sửa phiếu kiểm kê kho", getDatagridview());
                    kk.ShowDialog();
                    SelectData("");
                }
                else
                {  }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void toolStripStatus_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && !CheckQuyen(this.Name, 3))
                { return; }
                if (dgvHienThi.RowCount > 0)
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
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); MessageBox.Show("Dữ liệu đã xóa hết"); }
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
        private void frmHienThi_KiemKeKho_Load(object sender, EventArgs e)
        {
            try
            {
                SelectData("");
            }
            catch (Exception ex)
            { string s = ex.Message; CapNhat(dgvHienThi); fixDatagridview(); }
        }
        /// <summary>
        /// hungvv =================sua====================
        /// </summary>
        /// <returns></returns>
        private Entities.KiemKeKho getDatagridview()
        {
            Entities.KiemKeKho dathang = new Entities.KiemKeKho();
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
                        dathang.PhieuKiemKeKhoID = int.Parse(dgvHienThi.Rows[vitri].Cells[1].Value.ToString());
                        dathang.MaKiemKe = dgvHienThi.Rows[vitri].Cells[2].Value.ToString().ToUpper();
                        dathang.NgayKiemKe = Convert.ToDateTime(dgvHienThi.Rows[vitri].Cells[3].Value.ToString());
                        dathang.MaKho = dgvHienThi.Rows[vitri].Cells[4].Value.ToString().ToUpper();
                        dathang.GhiChu = "" + dgvHienThi.Rows[vitri].Cells[6].Value.ToString();
                        dathang.Deleted = Boolean.Parse(dgvHienThi.Rows[vitri].Cells[7].Value.ToString());
                    }
                }
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return dathang;
        }

        private void dgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHienThi.RowCount > 0)
                {
                    frmXuLyKiemKeKho kk = new frmXuLyKiemKeKho("Update", "Sửa phiếu kiểm kê kho", getDatagridview());
                    kk.ShowDialog();
                    SelectData("");
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void frmHienThi_KiemKeKho_DoubleClick(object sender, EventArgs e)
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
        private Entities.KiemKeKho[] search;
        private void CapNhat(DataGridView dgv)
        {
            try
            {
                Entities.KiemKeKho[] lay = new Entities.KiemKeKho[0];
                dgv.DataSource = lay;
            }
            catch (Exception ex)
            { string s = ex.Message; fixDatagridview(); }
        }
        private void SearchData(RadioButton rdoMa, RadioButton rdoNgay, RadioButton rdoTatCa, DataGridView dgv, string giatritim)
        {
            try
            {
                if (search.Length > 0)
                {
                    ArrayList list = new ArrayList();
                    Entities.KiemKeKho[] getData = null;
                    if (rdoMa.Checked == true)
                    {
                        if (giatritim != "")
                        {
                            for (int i = 0; i < search.Length; i++)
                            {
                                string layma = search[i].MaKiemKe.ToLower();
                                if (layma.Length > 0)
                                {
                                    int index = layma.IndexOf(giatritim);
                                    if (index >= 0)
                                    {
                                        list.Add(search[i]);
                                    }
                                }
                                else
                                { continue; }
                            }
                            int n = list.Count;
                            if (n == 0) { getData = null; }
                            getData = new Entities.KiemKeKho[n];
                            for (int i = 0; i < n; i++)
                            {
                                getData[i] = (Entities.KiemKeKho)list[i];
                            }
                            dgv.DataSource = null;
                            dgv.DataSource = getData;
                        }
                        else
                        { CapNhat(dgv); }
                    }
                    if (rdoNgay.Checked == true)
                    {
                        if (giatritim != "")
                        {
                            for (int i = 0; i < search.Length; i++)
                            {
                                string layma = search[i].NgayKiemKe.ToString().ToLower();
                                if (layma.Length > 0)
                                {
                                    int index = layma.IndexOf(giatritim);
                                    if (index >= 0)
                                    {
                                        list.Add(search[i]);
                                    }
                                }
                                else
                                { continue; }
                            }
                            int n = list.Count;
                            if (n == 0) { getData = null; }
                            getData = new Entities.KiemKeKho[n];
                            for (int i = 0; i < n; i++)
                            {
                                getData[i] = (Entities.KiemKeKho)list[i];
                            }
                            dgv.DataSource = null;
                            dgv.DataSource = getData;
                        }
                        else
                        { CapNhat(dgv); }
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
                SearchData(rdoMakho, rdoTenkho, rdoTatca, dgvHienThi, txtTimkiem.Text);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                CapNhat(dgvHienThi);
                fixDatagridview();
            }
        }

        private void rdoTenkho_CheckedChanged(object sender, EventArgs e)
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

        private void rdoMakho_CheckedChanged(object sender, EventArgs e)
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
        #endregion

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                SelectData("");
            }
            catch (Exception ex)
            { string s = ex.Message; CapNhat(dgvHienThi); fixDatagridview(); }
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
#endregion