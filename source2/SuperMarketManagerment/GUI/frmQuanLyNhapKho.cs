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
    public partial class frmQuanLyNhapKho : Form
    {
        public frmQuanLyNhapKho()
        {
            InitializeComponent();
        }

        #region hungvv==============================================khoi tao=====================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.HoaDonNhap ctdh;
        private Entities.DonDatHang[] search;
        #endregion

        #region Select============================================================================================================================
        /// <summary>
        /// hungvv =======================giao tiep voi server===========================
        /// </summary>
        private Entities.HoaDonNhap[] hoadonnhap;
        private void SelectData(Entities.HoaDonNhap nhap)
        {
            try
            {
                dgvHienThi.DataSource = null;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "HoaDonNhap", nhap);
                Entities.HoaDonNhap[] ddh = new Entities.HoaDonNhap[1];
                ddh = (Entities.HoaDonNhap[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length > 0)
                {
                    hoadonnhap = new Entities.HoaDonNhap[ddh.Length];
                    hoadonnhap = ddh;
                    dgvHienThi.DataSource = null;
                    dgvHienThi.DataSource = hoadonnhap;
                }
                else
                {
                    dgvHienThi.DataSource = null;
                    Entities.HoaDonNhap[] lay = new Entities.HoaDonNhap[0];
                    dgvHienThi.DataSource = lay;
                    hoadonnhap = null;
                }
                FixDatagridview(dgvHienThi);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.HoaDonNhap[] lay = new Entities.HoaDonNhap[0];
                dgvHienThi.DataSource = lay;
                FixDatagridview(dgvHienThi);
                hoadonnhap = null;
            }
        }
        /// <summary>
        /// fix dgv
        /// </summary>
        /// <param name="dgv"></param>
        private void FixDatagridview(DataGridView dgv)
        {
            try
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    dgv.Columns[i].Visible = false;
                }
                dgv.Columns[0].Visible = true;
                dgv.Columns[0].HeaderText = "STT";
                dgv.Columns[2].Visible = true;
                dgv.Columns[2].HeaderText = "Mã hóa đơn";
                dgv.Columns[3].Visible = true;
                dgv.Columns[3].HeaderText = "Ngày nhập";
                dgv.Columns[15].Visible = true;
                dgv.Columns[15].HeaderText = "Tổng tiền";
                dgv.Columns[16].Visible = true;
                dgv.Columns[16].HeaderText = "Ghi chú";
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvHienThi.Columns[1].Visible = false;
                dgvHienThi.Columns[0].HeaderText = "STT";
                if (dgv.RowCount > 0)
                {
                    new Common.Utilities().CountDatagridview(dgvHienThi);
                }
                dgvHienThi.Columns[0].Width = 40;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        /// <summary>
        /// add giatri vao combox
        /// </summary>
        /// <param name="hanhdong"></param>
        #endregion
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

        private void frmQuanlynhapmua_Load(object sender, EventArgs e)
        {
            try
            {
                Entities.TruyenGiaTri tra = new Entities.TruyenGiaTri();
                tra = new Common.Utilities().CaiDatKho("View", "", "");
                Entities.HoaDonNhap nhap = new Entities.HoaDonNhap();
                nhap.Hanhdong = "Select";
                nhap.MaHoaDonNhap = "";
                nhap.MaKho = tra.Giatritruyen;

                SelectData(nhap);
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

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
                        frmXuLyNhapKho fr = new frmXuLyNhapKho("Insert");
                        fr.ShowDialog();
                        Entities.TruyenGiaTri tra = new Entities.TruyenGiaTri();
                        tra = new Common.Utilities().CaiDatKho("View", "", "");
                        Entities.HoaDonNhap nhap = new Entities.HoaDonNhap();
                        nhap.Hanhdong = "Select";
                        nhap.MaHoaDonNhap = "";
                        nhap.MaKho = tra.Giatritruyen;
                        SelectData(nhap);
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
        private Entities.HoaDonNhap getDatagridview()
        {
            Entities.HoaDonNhap dathang = new Entities.HoaDonNhap();
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
                        dathang.HoaDonNhapID = int.Parse(dgvHienThi.Rows[vitri].Cells[1].Value.ToString());
                        dathang.MaHoaDonNhap = dgvHienThi.Rows[vitri].Cells[2].Value.ToString().ToUpper();
                        dathang.NgayNhap = DateTime.Parse("" + dgvHienThi.Rows[vitri].Cells[3].Value.ToString());
                        dathang.MaNhaCungCap = dgvHienThi.Rows[vitri].Cells[4].Value.ToString().ToUpper();
                        dathang.NoHienThoi = dgvHienThi.Rows[vitri].Cells[5].Value.ToString();
                        dathang.NguoiGiaoHang = dgvHienThi.Rows[vitri].Cells[6].Value.ToString();
                        dathang.HinhThucThanhToan = dgvHienThi.Rows[vitri].Cells[7].Value.ToString();
                        dathang.MaKho = dgvHienThi.Rows[vitri].Cells[8].Value.ToString().ToUpper();
                        dathang.HanThanhToan = DateTime.Parse(dgvHienThi.Rows[vitri].Cells[9].Value.ToString());
                        dathang.MaDonDatHang = dgvHienThi.Rows[vitri].Cells[10].Value.ToString().ToUpper();
                        dathang.MaTienTe = dgvHienThi.Rows[vitri].Cells[11].Value.ToString().ToUpper();
                        dathang.ChietKhau = dgvHienThi.Rows[vitri].Cells[12].Value.ToString();
                        dathang.ThanhToanNgay = dgvHienThi.Rows[vitri].Cells[13].Value.ToString();
                        dathang.ThueGTGT = dgvHienThi.Rows[vitri].Cells[14].Value.ToString();
                        dathang.TongTien = dgvHienThi.Rows[vitri].Cells[15].Value.ToString();
                        dathang.GhiChu = "" + dgvHienThi.Rows[vitri].Cells[16].Value.ToString();
                        dathang.ThanhToanSauKhiLapPhieu = "" + dgvHienThi.Rows[vitri].Cells[18].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            return dathang;
        }


        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && !CheckQuyen(this.Name, 1))
                { return; }
                if (dgvHienThi.RowCount > 0)
                {
                    frmXuLyNhapKho fr = new frmXuLyNhapKho("Update", getDatagridview());
                    fr.ShowDialog();
                    //Entities.TruyenGiaTri tra = new Entities.TruyenGiaTri();
                    //tra = new Common.Utilities().CaiDatKho("View", "", "");
                    //Entities.HoaDonNhap nhap = new Entities.HoaDonNhap();
                    //nhap.Hanhdong = "Select";
                    //nhap.MaHoaDonNhap = "";
                    //nhap.MaKho = tra.Giatritruyen;
                    //SelectData(nhap);
                }
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
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
        /// <summary>
        /// tim kiem tren mang doi tuong
        /// </summary>
        private static int count = 1;
        private void SearchData(RadioButton rdoMa, RadioButton rdoNgay, RadioButton rdoTatCa, DataGridView dgv, string giatritim, Entities.HoaDonNhap[] mangtim)
        {
            try
            {
                if (giatritim.Length > 0)
                {
                    if (mangtim.Length > 0)
                    {
                        if (rdoNgay.Checked == true)
                        {
                            if (mangtim == null)
                            {
                                Entities.HoaDonNhap[] lay = new Entities.HoaDonNhap[0];
                                dgv.DataSource = lay;
                            }
                            else
                            {
                                Boolean check = false;
                                List<Entities.HoaDonNhap> tt1_search = new List<Entities.HoaDonNhap>();
                                for (int i = 0; i < mangtim.Length; i++)
                                {
                                    int index = -1;
                                    index = mangtim[i].NgayNhap.ToString().ToLower().IndexOf(giatritim.ToLower());
                                    if (index >= 0)
                                    {
                                        check = true;
                                        tt1_search.Add(mangtim[i]);
                                    }
                                }
                                if (check == false)
                                {
                                    Entities.HoaDonNhap[] lay = new Entities.HoaDonNhap[0];
                                    dgv.DataSource = lay;
                                }
                                else
                                {
                                    dgv.DataSource = tt1_search.ToArray();
                                    tt1_search = null;
                                }
                            }
                        }
                        if (rdoMa.Checked == true)
                        {
                            if (mangtim == null)
                            {
                                Entities.HoaDonNhap[] lay = new Entities.HoaDonNhap[0];
                                dgv.DataSource = lay;
                            }
                            else
                            {
                                Boolean check = false;
                                List<Entities.HoaDonNhap> tt1_search = new List<Entities.HoaDonNhap>();
                                for (int i = 0; i < mangtim.Length; i++)
                                {
                                    int index = -1;
                                    index = mangtim[i].MaHoaDonNhap.ToString().ToLower().IndexOf(giatritim.ToLower());
                                    if (index >= 0)
                                    {
                                        check = true;
                                        tt1_search.Add(mangtim[i]);
                                    }
                                }
                                if (check == false)
                                {
                                    Entities.HoaDonNhap[] lay = new Entities.HoaDonNhap[0];
                                    dgv.DataSource = lay;
                                }
                                else
                                {
                                    dgv.DataSource = tt1_search.ToArray();
                                    tt1_search = null;
                                }
                            }
                        }
                        if (rdoTatca.Checked == true)
                        {
                            if (mangtim != null)
                            {
                                dgv.DataSource = mangtim;
                            }
                            else
                            {
                                Entities.HoaDonNhap[] k = new Entities.HoaDonNhap[0];
                                dgv.DataSource = k;
                            }
                        }
                    }
                    else
                    {
                        Entities.HoaDonNhap[] k = new Entities.HoaDonNhap[0];
                        dgv.DataSource = k;
                    }

                }
                else
                {
                    if (rdoTatca.Checked == true)
                    {
                        dgv.DataSource = mangtim;
                    }
                }
                FixDatagridview(dgv);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.HoaDonNhap[] k = new Entities.HoaDonNhap[0];
                dgv.DataSource = k;
                FixDatagridview(dgv);
                count = 1;
            }
        }
        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchData(rdbMa, rdbNgay, rdoTatca, dgvHienThi, txtTimkiem.Text, hoadonnhap);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.HoaDonNhap[] k = new Entities.HoaDonNhap[0];
                dgvHienThi.DataSource = k;
                FixDatagridview(dgvHienThi);
                count = 1;
            }
        }

        private void dgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHienThi.RowCount > 0)
                {
                    frmXuLyNhapKho fr = new frmXuLyNhapKho("Update", getDatagridview());
                    fr.ShowDialog();
                    //Entities.TruyenGiaTri tra = new Entities.TruyenGiaTri();
                    //tra = new Common.Utilities().CaiDatKho("View", "", "");
                    //Entities.HoaDonNhap nhap = new Entities.HoaDonNhap();
                    //nhap.Hanhdong = "Select";
                    //nhap.MaHoaDonNhap = "";
                    //nhap.MaKho = tra.Giatritruyen;
                    //SelectData(nhap);
                }
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.TruyenGiaTri tra = new Entities.TruyenGiaTri();
                tra = new Common.Utilities().CaiDatKho("View", "", "");
                Entities.HoaDonNhap nhap = new Entities.HoaDonNhap();
                nhap.Hanhdong = "Select";
                nhap.MaHoaDonNhap = "";
                nhap.MaKho = tra.Giatritruyen;
                SelectData(nhap);
            }
            catch (Exception ex)
            { string s = ex.Message; }
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
