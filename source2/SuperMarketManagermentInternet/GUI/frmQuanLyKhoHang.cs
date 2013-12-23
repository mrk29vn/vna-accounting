using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.Collections;

namespace GUI
{
    public partial class frmQuanLyKhoHang : Form
    {
        //Khai báo các hàm
        public TcpClient tcpClient;
        public NetworkStream networkStream;

        public frmQuanLyKhoHang()
        {
            InitializeComponent();
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
        private void frmHienThi_KhoHang_Load(object sender, EventArgs e)
        {
            try
            {
                SelectData();
            }
            catch (Exception ex)
            {
                string s = ex.Message; 
                Entities.KhoHang[] k = new Entities.KhoHang[0];
                dgvKhoHang.DataSource = k;
                fix();
            }
        }

        //Đặt tên tiếng việt
        private void fix()
        {
            try
            {
                    dgvKhoHang.RowHeadersVisible = false;
                    dgvKhoHang.Columns[1].Visible = false;
                    dgvKhoHang.Columns[2].Visible = false;
                    dgvKhoHang.Columns[6].Visible = false;
                    dgvKhoHang.Columns[8].Visible = false;

                    dgvKhoHang.Columns[9].Visible = false;
                    dgvKhoHang.Columns[10].Visible = false;
                    dgvKhoHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvKhoHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    dgvKhoHang.ReadOnly = true;
                    dgvKhoHang.Columns["KhoHangID"].HeaderText = "Kho Hàng ID";
                    dgvKhoHang.Columns["MaKho"].HeaderText = "Mã Kho";
                    dgvKhoHang.Columns["TenKho"].HeaderText = "Tên Kho";
                    dgvKhoHang.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                    dgvKhoHang.Columns["DienThoai"].HeaderText = "Điện Thoại";
                    dgvKhoHang.Columns["MaNhanVien"].HeaderText = "Mã Nhân Viên";
                    dgvKhoHang.Columns["GhiChu"].HeaderText = "Ghi Chú";
                    if (dgvKhoHang.Rows.Count > 0)
                    {
                        dgvKhoHang.Columns[0].HeaderText = "STT";
                        new Common.Utilities().CountDatagridview(dgvKhoHang);
                    }
                    else
                    { 
                        dgvKhoHang.Columns[0].HeaderText = "STT"; 
                    }
                    dgvKhoHang.Columns[0].Width = 40;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// thong tin cac kho
        /// </summary>
        private Entities.KhoHang[] kho;
        //Lấy dữ liệu từ Database
        private void SelectData()
        {
            try
            {
                dgvKhoHang.RowHeadersVisible = false;
                Server_Client.Client cl = new Server_Client.Client();
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KhoHang kh = new Entities.KhoHang("Select");
                Entities.KhoHang[] kh1 = new Entities.KhoHang[1];
                networkStream = cl.SerializeObj(this.tcpClient, "KhoHang", kh);
                kh1 = (Entities.KhoHang[])cl.DeserializeHepper1(networkStream, kh1);
                if (kh1.Length > 0 && kh1 != null)
                {
                    search = new Entities.KhoHang[kh1.Length];
                    search = kh1;
                    dgvKhoHang.DataSource = search;
                    rdoTatca.Checked = true;
                    fix();
                }
                else
                {
                    CapNhat(dgvKhoHang);
                    fix();
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.KhoHang[] lay = new Entities.KhoHang[0];
                dgvKhoHang.DataSource = lay;
                CapNhat(dgvKhoHang);
                fix();
            }
        }
        public static string BaoDong = "";
        //Hiển thị form Thêm Kho Hàng
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
                        frmXuLyKhoHang fr = new frmXuLyKhoHang("Insert");
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
        /// lay hang khi sua
        /// </summary>
        /// <returns></returns>
        private Entities.KhoHang getData()
        {
            Entities.KhoHang data = new Entities.KhoHang();
            try
            {
                data.KhoHangID = int.Parse(dgvKhoHang.CurrentRow.Cells[1].Value.ToString());
                data.MaKho =dgvKhoHang.CurrentRow.Cells[2].Value.ToString();
                data.TenKho = dgvKhoHang.CurrentRow.Cells[3].Value.ToString();
                data.DiaChi = dgvKhoHang.CurrentRow.Cells[4].Value.ToString();
                data.DienThoai = dgvKhoHang.CurrentRow.Cells[5].Value.ToString();
                data.MaNhanVien = dgvKhoHang.CurrentRow.Cells[6].Value.ToString();
                data.GhiChu = dgvKhoHang.CurrentRow.Cells[7].Value.ToString();
                data.Deleted = Boolean.Parse(dgvKhoHang.CurrentRow.Cells[8].Value.ToString());
            }
            catch (Exception ex)
            { string s = ex.Message; data = null; }
            return data;
        }
        //Hiển thị form Sửa Kho Hàng
        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && !CheckQuyen(this.Name, 2))
                { return; }
                if (dgvKhoHang.RowCount > 0)
                {
                    frmXuLyKhoHang skh = new frmXuLyKhoHang("Update", dgvKhoHang.CurrentRow, getData());
                    skh.ShowDialog();
                    SelectData();
                }
                else
                { MessageBox.Show("Không có kho nào để sửa"); }
            }
            catch (Exception ex)
            {
                string s = ex.Message; Entities.KhoHang[] k = new Entities.KhoHang[0];
                dgvKhoHang.DataSource = k;
                fix();
            }
        }

        //Xóa Data trên Data Grid View
        #region Xử lý khi Delete
        private void tssXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Common.Utilities.User.Administrator && !CheckQuyen(this.Name, 3))
                { return; }
                if (dgvKhoHang.RowCount > 0)
                {
                    
                  Boolean check =  new Check().CheckReference("KhoHang",dgvKhoHang.CurrentRow.Cells[2].Value.ToString());
                  if (check == true)
                  {
                      System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn muốn xóa không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                      {
                          if (giatri == System.Windows.Forms.DialogResult.Yes)
                          {
                              Server_Client.Client cl = new Server_Client.Client();
                              this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                              Entities.KhoHang kh = new Entities.KhoHang();
                              kh = new Entities.KhoHang("Delete", int.Parse(dgvKhoHang.CurrentRow.Cells[1].Value.ToString()));
                              kh.Manhanvien = Common.Utilities.User.MaNV;
                              kh.Tendangnhap = Common.Utilities.User.TenDangNhap;
                              networkStream = cl.SerializeObj(this.tcpClient, "KhoHang", kh);
                              int kt = 0;
                              kt = (int)cl.DeserializeHepper(networkStream, kt);
                              if (kt >= 1)
                              {
                                  SelectData();
                                  fix();
                                  if (dgvKhoHang.RowCount <= 0)
                                  { search = null; }
                              }
                              else
                              { MessageBox.Show("Thất bại"); }

                          }
                          else
                          { }
                      }
                  }
                  else
                  { MessageBox.Show("Kho hàng này không thể xóa"); }
                }
                else
                { search = null; }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        //Đóng form
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

        #region===================================================================================================
        /// <summary>
        /// search
        /// </summary>
        private Entities.KhoHang[] search;
        private void CapNhat(DataGridView dgv)
        {
            try
            {
                Entities.KhoHang[] lay = new Entities.KhoHang[0];
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
                    Entities.KhoHang[] getData = null;
                    if (rdoMa.Checked == true)
                    {
                        if (giatritim != "")
                        {
                            for (int i = 0; i < search.Length; i++)
                            {
                                string layma = search[i].MaKho.ToLower();
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
                            getData = new Entities.KhoHang[n];
                            for (int i = 0; i < n; i++)
                            {
                                getData[i] = (Entities.KhoHang)list[i];
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
                                string layma = search[i].TenKho.ToString().ToLower();
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
                            getData = new Entities.KhoHang[n];
                            for (int i = 0; i < n; i++)
                            {
                                getData[i] = (Entities.KhoHang)list[i];
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
                fix();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                CapNhat(dgv);
                fix();
            }
        }
        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchData(rdoMakho, rdoTenkho, rdoTatca, dgvKhoHang, txtTimkiem.Text);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                CapNhat(dgvKhoHang);
                fix();
            }
        }

        private void rdoTatca_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SearchData(rdoMakho, rdoTenkho, rdoTatca, dgvKhoHang, txtTimkiem.Text);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                CapNhat(dgvKhoHang);
                fix();
            }
        }

        private void rdoTenkho_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SearchData(rdoMakho, rdoTenkho, rdoTatca, dgvKhoHang, txtTimkiem.Text);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                CapNhat(dgvKhoHang);
                fix();
            }
        }

        private void rdoMakho_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SearchData(rdoMakho, rdoTenkho, rdoTatca, dgvKhoHang, txtTimkiem.Text);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                CapNhat(dgvKhoHang);
                fix();
            }
        }
        #endregion

        private void dgvKhoHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvKhoHang.RowCount > 0)
                {
                    frmXuLyKhoHang skh = new frmXuLyKhoHang("Update", dgvKhoHang.CurrentRow, getData());
                    skh.ShowDialog();
                    SelectData();
                }
                else
                { }
            }
            catch (Exception ex)
            {
                string s = ex.Message; Entities.KhoHang[] k = new Entities.KhoHang[0];
                dgvKhoHang.DataSource = k;
                fix();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                SelectData();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.KhoHang[] k = new Entities.KhoHang[0];
                dgvKhoHang.DataSource = k;
                fix();
            }
        }
    }
}