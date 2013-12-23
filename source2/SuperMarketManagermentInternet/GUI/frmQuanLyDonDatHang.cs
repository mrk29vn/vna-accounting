#region
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
using System.Collections;

namespace GUI
{
    public partial class frmQuanLyDonDatHang : Form
    {
        #region===========================================================================================
        public frmQuanLyDonDatHang()
        {
            InitializeComponent();
        }
        #endregion

        #region===========================================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        private Entities.DonDatHang dh;
        private Server_Client.Client cl;

        private void FixDataGridview(DataGridView dgv)
        {
            try
            {
                dgv.Columns[0].HeaderText = "STT";
                for (int i = 1; i < dgvHienThi.ColumnCount; i++)
                {
                    dgv.Columns[i].Visible = false;
                }
                dgv.Columns[2].Visible = true;
                dgv.Columns[2].HeaderText = "Mã đặt hàng";
                dgv.Columns[4].Visible = true;
                dgv.Columns[4].HeaderText = "Ngày tạo";
                dgv.Columns[6].Visible = true;
                dgv.Columns[6].HeaderText = "Nợ hiện thời";
                dgv.Columns[7].Visible = true;
                dgv.Columns[7].HeaderText = "Trạng thái đơn";
                dgv.Columns[8].Visible = true;
                dgv.Columns[8].HeaderText = "Ngày nhập dự kiến";
                dgv.Columns[16].Visible = true;
                dgv.Columns[16].HeaderText = "Ghi chú";
                new Common.Utilities().CountDatagridview(dgv);
                dgv.RowHeadersVisible = false;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
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
                dh = new Entities.DonDatHang("Select", "");
                clientstrem = cl.SerializeObj(this.client, "DonDatHang", dh);
                Entities.DonDatHang[] ddh = new Entities.DonDatHang[1];
                ddh = (Entities.DonDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh.Length > 0)
                {
                    search = ddh;
                    dgvHienThi.DataSource = search;
                    rdoTatca.Checked = true;
                }
                else
                {
                    Entities.DonDatHang[] lay = new Entities.DonDatHang[0];
                    dgvHienThi.DataSource = lay;
                    search = null;
                    toolStripStatus_Sua.Enabled = false;
                }
                FixDataGridview(dgvHienThi);
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.DonDatHang[] lay = new Entities.DonDatHang[0];
                dgvHienThi.DataSource = lay;
                FixDataGridview(dgvHienThi);
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
                dh.Manhanvien = Common.Utilities.User.MaNV;
                dh.Tendangnhap = Common.Utilities.User.TenDangNhap;
                clientstrem = cl.SerializeObj(this.client, "DonDatHang", dh);
                int trave = 0;
                trave = System.Convert.ToInt32(cl.DeserializeHepper(clientstrem, trave));
                client.Close();
                clientstrem.Close();
                if (trave >= 1)
                {
                    SelectData();
                    if (dgvHienThi.RowCount <= 0)
                    { search = null; }
                }
                else
                {
                    MessageBox.Show("Thất bại !");
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        #region===========================================================================================
        /// <summary>
        /// hungvv form them moi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Running()
        {
            try
            {
                if (Luu.BienTam == "Close")
                {
                    frmXuLyDonDatHang insert = new frmXuLyDonDatHang("Insert");

                    insert.ShowDialog(this);
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// them moi
        /// </summary>
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
            catch (Exception ex)
            { string s = ex.Message; }
        }

        /// <summary>
        /// hungvv dong form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// hungvv =================sua====================
        /// </summary>
        /// <returns></returns>
        private Entities.DonDatHang getDatagridview()
        {
            Entities.DonDatHang dathang = new Entities.DonDatHang();
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
                        dathang.DonDatHangID = int.Parse(dgvHienThi.Rows[vitri].Cells[1].Value.ToString());
                        dathang.MaDonDatHang = "" + dgvHienThi.Rows[vitri].Cells[2].Value.ToString();
                        dathang.LoaiDonDatHang = Convert.ToBoolean(dgvHienThi.Rows[vitri].Cells[3].Value.ToString());
                        dathang.NgayDonHang = Convert.ToDateTime(dgvHienThi.Rows[vitri].Cells[4].Value.ToString());
                        dathang.MaNhaCungCap = "" + dgvHienThi.Rows[vitri].Cells[5].Value.ToString();
                        dathang.NoHienThoi = dgvHienThi.Rows[vitri].Cells[6].Value.ToString();
                        dathang.TrangThaiDonDatHang = "" + dgvHienThi.Rows[vitri].Cells[7].Value.ToString();
                        dathang.NgayNhapDuKien = Convert.ToDateTime("" + dgvHienThi.Rows[vitri].Cells[8].Value.ToString());
                        dathang.HinhThucThanhToan = "" + dgvHienThi.Rows[vitri].Cells[9].Value.ToString();
                        dathang.MaKho = "" + dgvHienThi.Rows[vitri].Cells[10].Value.ToString();
                        dathang.MaNhanVien = "" + dgvHienThi.Rows[vitri].Cells[11].Value.ToString();
                        dathang.MaTienTe = "" + dgvHienThi.Rows[vitri].Cells[12].Value.ToString();
                        dathang.ThueGTGT = dgvHienThi.Rows[vitri].Cells[13].Value.ToString();
                        dathang.Phivanchuyen = dgvHienThi.Rows[vitri].Cells[14].Value.ToString();
                        dathang.PhiKhac = dgvHienThi.Rows[vitri].Cells[15].Value.ToString();
                        dathang.GhiChu = "" + dgvHienThi.Rows[vitri].Cells[16].Value.ToString();
                        dathang.Deleted = Boolean.Parse(dgvHienThi.Rows[vitri].Cells[17].Value.ToString());
                        dathang.Makhachhang = dgvHienThi.Rows[vitri].Cells[18].Value.ToString();
                    }
                }
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            return dathang;
        }
        /// <summary>
        /// hungvv form sua
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && !CheckQuyen(this.Name, 2))
                { return; }
                if (dgvHienThi.RowCount > 0)
                {
                    BaoDong = "A";
                    frmXuLyDonDatHang fr = new frmXuLyDonDatHang("Update", getDatagridview());
                    fr.ShowDialog();
                    SelectData();
                }
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
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
                                if (dgvHienThi.Rows[vitri].Cells[7].Value.ToString().Equals("Đã thành công"))
                                {
                                    MessageBox.Show("Hoá đơn này đã nhập kho bạn không thể xoá","Hệ thống cảnh báo");
                                    return;
                                }
                                else
                                {
                                    string ID = dgvHienThi.Rows[vitri].Cells[2].Value.ToString();
                                    DeleteData(ID);
                                }
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
            { string s = ex.Message.ToString(); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tenform"></param>
        /// <param name="quyen"></param>
        /// <returns></returns>
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
        /// <summary>
        /// hungvv form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmViewOrderProducts_Load(object sender, EventArgs e)
        {
            try
            {
                SelectData();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }

        /// <summary>
        /// hungvv loc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatus_Loc_Click(object sender, EventArgs e)
        {

        }

        private void dgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHienThi.RowCount > 0)
                {
                    BaoDong = "A";
                    frmXuLyDonDatHang fr = new frmXuLyDonDatHang("Update", getDatagridview());
                    fr.ShowDialog();
                    SelectData();
                }
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
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

        #region===========================================================================================
        /// <summary>
        /// tim kiem tren mang doi tuong
        /// </summary>
        private Entities.DonDatHang[] search;
        private void capnhat(DataGridView dgv)
        {
            try
            {
                Entities.DonDatHang[] k = new Entities.DonDatHang[0];
                dgv.DataSource = k;
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
                    ArrayList list = new ArrayList();
                    Entities.DonDatHang[] getData = null;
                    if (rdoMa.Checked == true)
                    {
                        if (giatritim != "")
                        {
                            for (int i = 0; i < search.Length; i++)
                            {
                                string layma = search[i].MaDonDatHang.ToLower();
                                if (layma.Length > 0)
                                {
                                    int index = layma.IndexOf(giatritim.ToLower());
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
                            getData = new Entities.DonDatHang[n];
                            for (int i = 0; i < n; i++)
                            {
                                getData[i] = (Entities.DonDatHang)list[i];
                            }
                            dgv.DataSource = null;
                            dgv.DataSource = getData;
                        }
                        else
                        { capnhat(dgv); }
                    }
                    if (rdoNgay.Checked == true)
                    {
                        if (giatritim != "")
                        {
                            for (int i = 0; i < search.Length; i++)
                            {
                                string layma = @search[i].NgayDonHang.ToString().ToLower();
                                if (layma.Length > 0)
                                {
                                    int index = layma.IndexOf(giatritim.ToLower());
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
                            getData = new Entities.DonDatHang[n];
                            for (int i = 0; i < n; i++)
                            {
                                getData[i] = (Entities.DonDatHang)list[i];
                            }
                            dgv.DataSource = null;
                            dgv.DataSource = getData;
                        }
                        else
                        { capnhat(dgv); }
                    }
                    if (rdoTatca.Checked == true)
                    {
                        dgv.DataSource = null;
                        dgv.DataSource = search;
                    }
                }
                else
                { capnhat(dgv); }
                FixDataGridview(dgv);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                capnhat(dgv);
                FixDataGridview(dgv);
            }
        }
        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchData(rdbMa, rdbNgay, rdoTatca, dgvHienThi, txtTimkiem.Text);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                capnhat(dgvHienThi);
                FixDataGridview(dgvHienThi);
            }
        }

        private void rdoTatca_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SearchData(rdbMa, rdbNgay, rdoTatca, dgvHienThi, txtTimkiem.Text);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                capnhat(dgvHienThi);
                FixDataGridview(dgvHienThi);
            }
        }

        private void rdbNgay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SearchData(rdbMa, rdbNgay, rdoTatca, dgvHienThi, txtTimkiem.Text);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                capnhat(dgvHienThi);
                FixDataGridview(dgvHienThi);
            }
        }

        private void rdbMa_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SearchData(rdbMa, rdbNgay, rdoTatca, dgvHienThi, txtTimkiem.Text);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                capnhat(dgvHienThi);
                FixDataGridview(dgvHienThi);
            }
        }
        #endregion

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                SelectData();
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
#endregion
