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
using System.Collections;

namespace GUI
{
    public partial class frmQuanLyTraLaiNhaCungCap : Form
    {
        public frmQuanLyTraLaiNhaCungCap()
        {
            InitializeComponent();
        }

        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.TraLaiNCC ctdh;

        private void fixDatagridview()
        {
            try
            {
                for (int i = 1; i < dgvHienThi.ColumnCount; i++)
                {
                    dgvHienThi.Columns[i].Visible = false;
                }
                dgvHienThi.RowHeadersVisible = false;
                dgvHienThi.Columns[2].Visible = true;
                dgvHienThi.Columns[2].HeaderText = "Mã TLNCC";
                dgvHienThi.Columns[3].Visible = true;
                dgvHienThi.Columns[3].HeaderText = "Ngày trả";
                dgvHienThi.Columns[5].Visible = true;
                dgvHienThi.Columns[5].HeaderText = "Nợ hiện thời";
                dgvHienThi.Columns[8].Visible = true;
                dgvHienThi.Columns[8].HeaderText = "Mã đơn đặt hàng";
                dgvHienThi.Columns[14].Visible = true;
                dgvHienThi.Columns[14].HeaderText = "Ghi chú";
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
                ctdh = new Entities.TraLaiNCC();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                ctdh = new Entities.TraLaiNCC("Select", ID);
                clientstrem = cl.SerializeObj(this.client, "TraLaiNhaCungCap", ctdh);
                Entities.TraLaiNCC[] ddh = new Entities.TraLaiNCC[1];
                ddh = (Entities.TraLaiNCC[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh.Length > 0)
                {
                    search = new Entities.TraLaiNCC[ddh.Length];
                    search = ddh;
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
                if (ID != "")
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
                    if (trave >= 1)
                    {
                        SelectData("");
                    }
                    if (trave == 0)
                    {
                        MessageBox.Show("Thất bại !");
                    }
                }
                else
                { MessageBox.Show("Không tìm thấy mã cần xóa"); }
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
                for (int j = 0; j < 1000; j++)
                {
                    if (BaoDong == "")
                    {
                        frmXuLyHangTraLai xuly = new frmXuLyHangTraLai("Them_TraLaiNhaCungCap", "TraLaiNhaCungCap", "Insert");
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

        private Entities.TraLaiNCC getDatagridview()
        {
            Entities.TraLaiNCC tra = new Entities.TraLaiNCC();
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
                        tra.TraLaiNCCID = int.Parse(dgvHienThi.Rows[vitri].Cells[1].Value.ToString());
                        tra.MaHDTraLaiNCC = "" + dgvHienThi.Rows[vitri].Cells[2].Value.ToString();
                        tra.Ngaytra = DateTime.Parse(dgvHienThi.Rows[vitri].Cells[3].Value.ToString());
                        tra.MaNCC = dgvHienThi.Rows[vitri].Cells[4].Value.ToString();
                        tra.NoHienThoi = dgvHienThi.Rows[vitri].Cells[5].Value.ToString();
                        tra.NguoiNhanHang = "" + dgvHienThi.Rows[vitri].Cells[6].Value.ToString();
                        tra.HinhThucThanhToan = "" + dgvHienThi.Rows[vitri].Cells[7].Value.ToString();
                        tra.MaHoaDonNhap = dgvHienThi.Rows[vitri].Cells[8].Value.ToString();
                        tra.MaKho = dgvHienThi.Rows[vitri].Cells[9].Value.ToString();
                        tra.MaTienTe = "" + dgvHienThi.Rows[vitri].Cells[10].Value.ToString();
                        tra.TienBoiThuong = dgvHienThi.Rows[vitri].Cells[11].Value.ToString();
                        tra.ThanhToanNgay = dgvHienThi.Rows[vitri].Cells[12].Value.ToString();
                        tra.ThueGTGT = dgvHienThi.Rows[vitri].Cells[13].Value.ToString();
                        tra.GhiChu = dgvHienThi.Rows[vitri].Cells[14].Value.ToString();
                        tra.Deleted = Boolean.Parse(dgvHienThi.Rows[vitri].Cells[15].Value.ToString());
                    }
                }
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
            return tra;
        }

        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && !CheckQuyen(this.Name, 1))
                { return; }
                if (dgvHienThi.RowCount > 0)
                {
                    frmXuLyHangTraLai xuly = new frmXuLyHangTraLai("Sua_TraLaiNhaCungCap", "TraLaiNhaCungCap", "Update", getDatagridview());
                    xuly.ShowDialog();
                    SelectData("");
                }
                else
                { MessageBox.Show("Không có hóa đơn nào để sửa"); }
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
                { MessageBox.Show("Không có hóa đơn nào để xóa"); }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
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
        private void frmHienThi_TraLaiNhaCungCap_Load(object sender, EventArgs e)
        {
            try { SelectData(""); }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void dgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHienThi.RowCount > 0)
                {
                    frmXuLyHangTraLai xuly = new frmXuLyHangTraLai("Sua_TraLaiNhaCungCap", "TraLaiNhaCungCap", "Update", getDatagridview());
                    xuly.ShowDialog();
                    SelectData("");
                }
                else
                { MessageBox.Show("Không có hóa đơn nào để sửa"); }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void frmHienThi_TraLaiNhaCungCap_DoubleClick(object sender, EventArgs e)
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

        /// <summary>
        /// search
        /// </summary>
        private Entities.TraLaiNCC[] search;
        private void CapNhat(DataGridView dgv)
        {
            try
            {
                Entities.TraLaiNCC[] lay = new Entities.TraLaiNCC[0];
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
                    ArrayList list = new ArrayList();
                    Entities.TraLaiNCC[] getData = null;
                    if (rdoMa.Checked == true)
                    {
                        if (giatritim != "")
                        {
                            for (int i = 0; i < search.Length; i++)
                            {
                                string layma = search[i].MaHDTraLaiNCC.ToLower();
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
                            getData = new Entities.TraLaiNCC[n];
                            for (int i = 0; i < n; i++)
                            {
                                getData[i] = (Entities.TraLaiNCC)list[i];
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
                                string layma = search[i].Ngaytra.ToString().ToLower();
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
                            getData = new Entities.TraLaiNCC[n];
                            for (int i = 0; i < n; i++)
                            {
                                getData[i] = (Entities.TraLaiNCC)list[i];
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

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try { SelectData(""); }
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
