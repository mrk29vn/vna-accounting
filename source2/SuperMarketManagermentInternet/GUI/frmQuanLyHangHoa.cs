using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Linq;
using Entities;

namespace GUI
{
    public partial class frmQuanLyHangHoa : Form
    {
        #region Khai Báo
        Server_Client.Client cl;
        public TcpClient tcpClient;
        public NetworkStream networkStream;

        Entities.HangHoa[] MANG = new Entities.HangHoa[0];

        HangHoa selectHangHoa = new HangHoa();
        #endregion

        #region Khởi Tạo
        public frmQuanLyHangHoa()
        {
            InitializeComponent();
        }
        public frmQuanLyHangHoa(DataGridViewRow dataGridViewRow)
        {
            this.dataGridViewRow = dataGridViewRow;
        }
        #endregion

        private void frmQuanLyHangHoa_Load(object sender, EventArgs e)
        {
            SelectData();
        }

        /// <summary>
        /// OrderBy
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Entities.HangHoa[] OrderBy(Entities.HangHoa[] source)
        {
            Entities.HangHoa[] retVal = null;
            try
            {
                var query = source.OrderBy(item => item.TenHangHoa);
                retVal = query.ToArray();
            }
            catch
            {
                retVal = null;
            }

            return retVal;
        }

        private void SelectData()
        {
            List<Entities.HangHoa> listTemp = new List<Entities.HangHoa>();
            int stt = 0;
            MANG = LayHangHoa();
            MANG = OrderBy(MANG);

            foreach (Entities.HangHoa item in MANG)
            {
                stt++;
                item.Stt = stt;
                listTemp.Add(item);
            }

            dgvQuanLyHangHoa.DataSource = listTemp.ToArray();
            fix();
        }

        #region Lấy dữ liệu
        Entities.HangHoa[] LayHangHoa()
        {
            try
            {
                cl = new Server_Client.Client();
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                networkStream = cl.SerializeObj(this.tcpClient, "HangHoa", new Entities.HangHoa("Select"));
                Entities.HangHoa[] hh1 = new Entities.HangHoa[1];
                hh1 = (Entities.HangHoa[])cl.DeserializeHepper1(networkStream, hh1);
                if (hh1 == null)
                {
                    return new Entities.HangHoa[0];
                }
                foreach (Entities.HangHoa item in hh1)
                {
                    item.GiaBanBuonSHOW = new TienIch().FormatMoney(item.GiaBanBuon);
                    item.GiaBanLeSHOW = new TienIch().FormatMoney(item.GiaBanLe);
                    item.GiaNhapSHOW = new TienIch().FormatMoney(item.GiaNhap);
                }
                return hh1;
            }
            catch { return new Entities.HangHoa[0]; }
        }
        #endregion

        public void fix()
        {
            try
            {
                for (int i = 0; i < dgvQuanLyHangHoa.ColumnCount; i++)
                {
                    dgvQuanLyHangHoa.Columns[i].Visible = false;
                }

                dgvQuanLyHangHoa.Columns["Stt"].Visible = true;
                dgvQuanLyHangHoa.Columns["MaHangHoa"].Visible = true;
                dgvQuanLyHangHoa.Columns["TenHangHoa"].Visible = true;
                dgvQuanLyHangHoa.Columns["TenDonViTinh"].Visible = true;
                dgvQuanLyHangHoa.Columns["GiaNhapSHOW"].Visible = true;
                dgvQuanLyHangHoa.Columns["GiaBanBuonSHOW"].Visible = true;
                dgvQuanLyHangHoa.Columns["GiaBanLeSHOW"].Visible = true;
                
                dgvQuanLyHangHoa.Columns["Stt"].HeaderText = "Stt";
                dgvQuanLyHangHoa.Columns["MaHangHoa"].HeaderText = "Mã hàng hóa";
                dgvQuanLyHangHoa.Columns["TenHangHoa"].HeaderText = "Tên hàng hóa";
                dgvQuanLyHangHoa.Columns["TenDonViTinh"].HeaderText = "Đơn vị tính";
                dgvQuanLyHangHoa.Columns["GiaNhapSHOW"].HeaderText = "Giá nhập";
                dgvQuanLyHangHoa.Columns["GiaBanBuonSHOW"].HeaderText = "Giá bán buôn";
                dgvQuanLyHangHoa.Columns["GiaBanLeSHOW"].HeaderText = "Giá lẻ";
                dgvQuanLyHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvQuanLyHangHoa.AllowUserToAddRows = false;
                dgvQuanLyHangHoa.AllowUserToDeleteRows = false;
                dgvQuanLyHangHoa.AllowUserToResizeRows = false;
                dgvQuanLyHangHoa.RowHeadersVisible = false;
                dgvQuanLyHangHoa.Columns["Stt"].Width = 30;
            }
            catch { }
        }

        int i;
        private DataGridViewRow dataGridViewRow;
        private void dgvQuanLyHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            if (i >= 0)
            {
                dgvQuanLyHangHoa.Rows[i].Selected = true;
            }
        }
        public static string KiemTra = "insert";
        private void tssThem_Click(object sender, EventArgs e)
        {
            KiemTra = "insert";
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 4))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            while (KiemTra == "insert")
            {
                frmXuLyHangHoa fr = new frmXuLyHangHoa("Insert", dgvQuanLyHangHoa.CurrentRow);
                fr.StartPosition = FormStartPosition.CenterScreen;
                fr.ShowDialog();
                SelectData();
            }

        }

        private void tssSua_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            frmXuLyHangHoa fr = new frmXuLyHangHoa("Update", dgvQuanLyHangHoa.CurrentRow);
            fr.StartPosition = FormStartPosition.CenterScreen;
            fr.ShowDialog();
            SelectData();
            fix();
        }

        #region Xử lý khi Delete
        private void tssXoa_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 3))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            DialogResult dlgResult = MessageBox.Show("Bạn Có Chắc Chắn muốn Xóa không?", "Đồng ý?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    bool ktdelete = false;
                    int idcurent = int.Parse(dgvQuanLyHangHoa.CurrentRow.Cells["HangHoaID"].Value.ToString());
                    string maCurrent = dgvQuanLyHangHoa.CurrentRow.Cells["MaHangHoa"].Value.ToString();
                    SelectData();
                    for (int j = 0; j < MANG.Length; j++)
                    {
                        if (MANG[j].Deleted == false)
                            if (MANG[j].HangHoaID == idcurent)
                            {
                                ktdelete = true;
                                break;
                            }
                    }
                    if (ktdelete == true)
                    {

                        if (new Check().CheckReference("HangHoa", maCurrent))
                        {
                            Server_Client.Client cl = new Server_Client.Client();
                            this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.HangHoa hh = new Entities.HangHoa();
                            hh = new Entities.HangHoa("Delete", idcurent, maCurrent, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                            networkStream = cl.SerializeObj(this.tcpClient, "HangHoa", hh);
                            bool kt = false;
                            kt = (bool)cl.DeserializeHepper(networkStream, kt);
                            if (kt != true)
                            {
                                MessageBox.Show("xóa thất bại");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Hàng hóa này đang có giao dịch, không thể xóa ", "Hệ Thống Cảnh Báo!");
                        }
                    }
                    SelectData();
                }
                catch
                {
                    MessageBox.Show("Lỗi Hệ Thống- Liên Hệ nhà Quản Trị");
                }
            }
        }
        #endregion

        private void dgvQuanLyHangHoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
                {
                    MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                    return;
                }
                frmXuLyHangHoa shh = new frmXuLyHangHoa("Update", dgvQuanLyHangHoa.CurrentRow);
                shh.StartPosition = FormStartPosition.CenterScreen;
                shh.ShowDialog();
                SelectData();
                fix();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {//Nạp Lại
            SelectData();
        }

        private void tssDong_Click(object sender, EventArgs e)
        {//Đóng
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Search = txtTimKiem.Text;
                List<Entities.HangHoa> ketqua = new List<Entities.HangHoa>();
                foreach (Entities.HangHoa item in MANG)
                {
                    int test = -1;
                    if (rdbMa.Checked)    //Tìm Kiếm Theo Mã
                    {
                        test = item.MaHangHoa.ToLower().IndexOf(Search.ToLower());
                    }
                    else if (rdbTen.Checked)   //Tìm Kiếm Theo Tên
                    {
                        test = item.TenHangHoa.ToLower().IndexOf(Search.ToLower());
                    }
                    if (test >= 0)
                    {
                        ketqua.Add(item);
                    }
                }
                dgvQuanLyHangHoa.DataSource = ketqua.ToArray();
            }
            catch { }
        }

        #region Check Quyền
        public bool CheckQuyen(string tenform, int quyen)
        {
            try
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
                return false;
            }
            catch { return false; }
        }
        #endregion

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
        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

    }
}
