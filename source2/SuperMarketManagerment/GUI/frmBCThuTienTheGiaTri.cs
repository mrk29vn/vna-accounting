using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmBCThuTienTheGiaTri : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        List<Entities.ChiTietTheGiamGia> MANG = new List<Entities.ChiTietTheGiamGia>();
        DateTime start = new DateTime(1753, 1, 1);
        DateTime end = new DateTime(1753, 1, 1);

        public frmBCThuTienTheGiaTri()
        {
            InitializeComponent();
        }

        private void frmBCThuTienTheGiaTri_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime hientai = DateServer.Date();
                DateTime truoc = new DateTime(hientai.Year, hientai.Month, 1);
                DateTime sau = new DateTime(hientai.Year, hientai.Month, DateTime.DaysInMonth(hientai.Year, hientai.Month));
                Xuly(truoc, sau);
            }
            catch { }
        }

        //Lấy dữ liệu thẻ giảm giá
        Entities.TheGiamGia[] TGG = new Entities.TheGiamGia[0];
        void LayTheGiamGia()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "TheGiamGia", new Entities.TheGiamGia("Select"));     
                TGG = (Entities.TheGiamGia[])cl.DeserializeHepper1(clientstrem, TGG);
                if (TGG == null)
                    TGG = new Entities.TheGiamGia[0];
            }
            catch { }
        }
        //Lấy dữ liệu chi tiết thẻ giảm giá
        Entities.ChiTietTheGiamGia[] CTTGG = new Entities.ChiTietTheGiamGia[0];
        void LayChiTietTheGiamGia()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "SelectChiTietTheGiamGia", new Entities.ChiTietTheGiamGia("select"));
                CTTGG = (Entities.ChiTietTheGiamGia[])cl.DeserializeHepper1(clientstrem, CTTGG);
                if (CTTGG == null)
                    CTTGG = new Entities.ChiTietTheGiamGia[0];
            }
            catch { }
        }

        private void btnLocDieuKien_Click(object sender, EventArgs e)
        {
            try
            {
                new frmLocDieuKien().ShowDialog();
                if (frmLocDieuKien.truoc != "" && frmLocDieuKien.sau != "")
                {
                    DateTime truoc = Convert.ToDateTime(frmLocDieuKien.truoc);
                    DateTime sau = Convert.ToDateTime(frmLocDieuKien.sau);
                    Xuly(truoc, sau);
                    frmLocDieuKien.truoc = frmLocDieuKien.sau = "";
                }
            }
            catch { }
        }

        void Xuly(DateTime truoc, DateTime sau)
        {
            try
            {
                start = truoc;
                end = sau;
                LayChiTietTheGiamGia();
                List<Entities.ChiTietTheGiamGia> hienthi = new List<Entities.ChiTietTheGiamGia>();
                foreach (Entities.ChiTietTheGiamGia item in CTTGG)
                {
                    if (item.NgayThu.Date >= truoc.Date && item.NgayThu.Date <= sau.Date)
                    {
                        hienthi.Add(item);
                    }
                }
                double tong = 0;
                MANG.Clear();
                foreach (Entities.ChiTietTheGiamGia item in hienthi)
                {
                    MANG.Add(item);
                    tong += item.GiaTriThe;
                    item.GiaTriTheSHOW = new TienIch().FormatMoney(item.GiaTriThe.ToString());
                }
                label1.Text = "Tổng tiền: " + new TienIch().FormatMoney(tong.ToString());
                dtgvhienthi.DataSource = hienthi.ToArray();
                fix();
            }
            catch { }
        }

        public void fix()
        {
            for (int i = 0; i < dtgvhienthi.ColumnCount; i++)
            {
                dtgvhienthi.Columns[i].Visible = false;
            }
            dtgvhienthi.Columns["TenKhachHang"].Visible = true;
            dtgvhienthi.Columns["MaTheGiamGia"].Visible = true;
            dtgvhienthi.Columns["GiaTriTheSHOW"].Visible = true;
            dtgvhienthi.Columns["NgayThu"].Visible = true;
            dtgvhienthi.Columns["TenKhachHang"].HeaderText = "Tên khách hàng";
            dtgvhienthi.Columns["MaTheGiamGia"].HeaderText = "Mã thẻ giá trị";
            dtgvhienthi.Columns["GiaTriTheSHOW"].HeaderText = "Giá trị thẻ";
            dtgvhienthi.Columns["NgayThu"].HeaderText = "Thời gian thanh toán";
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.AllowUserToAddRows = false;
            dtgvhienthi.AllowUserToDeleteRows = false;
            dtgvhienthi.AllowUserToResizeRows = false;
            dtgvhienthi.RowHeadersVisible = false;
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }
        private void btn_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Search = txttimkiem.Text;
                List<Entities.ChiTietTheGiamGia> ketqua = new List<Entities.ChiTietTheGiamGia>();
                foreach (Entities.ChiTietTheGiamGia item in MANG)
                {
                    int test = -1;
                    if (rdbtimkiem1.Checked)    //Tìm Kiếm Theo Mã Thẻ Giá Trị
                    {
                        test = item.MaTheGiamGia.ToLower().IndexOf(Search.ToLower());
                    }
                    else if (rdbtimkiem2.Checked)   //Tìm Kiếm Theo Tên Khách Hàng
                    {
                        test = item.TenKhachHang.ToLower().IndexOf(Search.ToLower());
                    }
                    if (test >= 0)
                    {
                        ketqua.Add(item);
                    }
                }
                dtgvhienthi.DataSource = ketqua.ToArray();
            }
            catch { }
        }

        private void tsslthoat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            //Nạp Lại
            try
            {
                DateTime hientai = DateServer.Date();
                DateTime truoc = new DateTime(hientai.Year, hientai.Month, 1);
                DateTime sau = new DateTime(hientai.Year, hientai.Month, DateTime.DaysInMonth(hientai.Year, hientai.Month));
                Xuly(truoc, sau);
                fix();
            }
            catch { }
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                Entities.ChiTietTheGiamGia[] data = (Entities.ChiTietTheGiamGia[])dtgvhienthi.DataSource;
                if (data == null)
                {
                    return;
                }
                else if (data.Length == 0)
                {
                    return;
                }
                //Xem
                frmBaoCaorpt a = new frmBaoCaorpt( data, start.ToString("dd/MM/yyyy"), end.ToString("dd/MM/yyyy"));
                a.ShowDialog();
            }
            catch { }
            finally
            {
                this.Enabled = true;
            }
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.ChiTietTheGiamGia[] data = (Entities.ChiTietTheGiamGia[])dtgvhienthi.DataSource;
                if (data == null)
                {
                    return;
                }
                else if (data.Length == 0)
                {
                    return;
                }
                //PDF
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt( data, start.ToString("dd/MM/yyyy"), end.ToString("dd/MM/yyyy"), saveFileDialog1.FileName, "PDF");
                }
            }
            catch { }
        }

        private void tsslWord_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.ChiTietTheGiamGia[] data = (Entities.ChiTietTheGiamGia[])dtgvhienthi.DataSource;
                if (data == null)
                {
                    return;
                }
                else if (data.Length == 0)
                {
                    return;
                }
                //DOC
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt( data, start.ToString("dd/MM/yyyy"), end.ToString("dd/MM/yyyy"), saveFileDialog1.FileName, "Word");
                }
            }
            catch { }
        }

        private void tsslexcel_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.ChiTietTheGiamGia[] data = (Entities.ChiTietTheGiamGia[])dtgvhienthi.DataSource;
                if (data == null)
                {
                    return;
                }
                else if (data.Length == 0)
                {
                    return;
                }
                //XLS
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt( data, start.ToString("dd/MM/yyyy"), end.ToString("dd/MM/yyyy"), saveFileDialog1.FileName, "Excel");
                }
            }
            catch { }
        }
    }
}
