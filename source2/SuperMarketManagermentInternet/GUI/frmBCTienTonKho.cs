using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmBCTienTonKho : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        List<Entities.BCTienTonKho> MANG = new List<Entities.BCTienTonKho>();
        DateTime start = new DateTime(1753, 1, 1);
        DateTime end = new DateTime(1753, 1, 1);
        int chon = -1;

        public frmBCTienTonKho()
        {
            InitializeComponent();
        }

        private void frmBCTienTonKho_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime hientai = DateServer.Date();
                DateTime truoc = new DateTime(hientai.Year, hientai.Month, 1);
                Xuly(truoc, hientai);
            }
            catch { }
        }

        List<Entities.BCTienTonKho> TinhToanDuLieu()
        {
            try
            {
                LayKhoHang();
                LayChiTietKhoHang();
                LayGiaVon();
                List<Entities.BCTienTonKho> hienthi = new List<Entities.BCTienTonKho>();
                foreach (Entities.KhoHang item in KHOHANG)
                {
                    Entities.BCTienTonKho temp = new Entities.BCTienTonKho();
                    temp.MaKho = item.MaKho;
                    temp.TenKho = item.TenKho;
                    //Tạo chi tiết
                    foreach (Entities.BCTonKhoTheoKho item1 in TONKHO)
                    {
                        if (item1.MaKho.ToUpper().Equals(item.MaKho.ToUpper()))
                        {
                            Entities.BaoCaoTienTonKho temp2 = new Entities.BaoCaoTienTonKho();
                            temp2.MaHangHoa = item1.MaHangHoa;
                            temp2.TenHangHoa = item1.TenHangHoa;
                            temp2.SlTon = item1.SoLuong;
                            foreach (Entities.GiaVon item2 in GIAVON)
                            {
                                if (item2.MaHangHoa.ToUpper().Equals(item1.MaHangHoa.ToUpper()))
                                {
                                    temp2.GtTon = item2.Gia;
                                }
                            }
                            temp.DanhSach.Add(temp2);
                        }
                    }
                    foreach (Entities.BaoCaoTienTonKho bientam in temp.DanhSach)
                    {
                        temp.SoLuongTon += bientam.SlTon;
                        temp.GiaTriTon += bientam.GtTon * bientam.SlTon;
                        temp.GiaTriTonSHOW = new TienIch().FormatMoney(temp.GiaTriTon.ToString());
                    }
                    if (temp.GiaTriTon != 0 || temp.SoLuongTon != 0)
                    {
                        hienthi.Add(temp);
                    }
                }
                return hienthi;
            }
            catch { return new List<Entities.BCTienTonKho>(); }
        }

        //Lấy dữ liệu kho hàng
        Entities.KhoHang[] KHOHANG = new Entities.KhoHang[0];
        void LayKhoHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KhoHang ctxh = new Entities.KhoHang("Select");
                KHOHANG = new Entities.KhoHang[1];
                clientstrem = cl.SerializeObj(this.client1, "KhoHang", ctxh);
                KHOHANG = (Entities.KhoHang[])cl.DeserializeHepper1(clientstrem, KHOHANG);
                if (KHOHANG == null)
                    KHOHANG = new Entities.KhoHang[0];
            }
            catch { }
        }
        //Lấy dữ liệu chi tiết kho hàng
        Entities.BCTonKhoTheoKho[] TONKHO = new Entities.BCTonKhoTheoKho[0];
        void LayChiTietKhoHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.BCTonKhoTheoKho ctxh = new Entities.BCTonKhoTheoKho("Select");
                TONKHO = new Entities.BCTonKhoTheoKho[1];
                clientstrem = cl.SerializeObj(this.client1, "BCTonKhoTheoKho", ctxh);
                TONKHO = (Entities.BCTonKhoTheoKho[])cl.DeserializeHepper1(clientstrem, TONKHO);
                if (TONKHO == null)
                    TONKHO = new Entities.BCTonKhoTheoKho[0];
            }
            catch { }
        }
        //Lấy dữ liệu giá vốn
        Entities.GiaVon[] GIAVON = new Entities.GiaVon[0];
        void LayGiaVon()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                ArrayList arr = new ArrayList();
                arr.Add("SelectTheoDieuKien_GiaVon");
                arr.Add("Select_GIAVON");
                arr.Add(new Entities.GiaVon());
                arr.Add(new Entities.GiaVon());
                clientstrem = cl.SerializeObj(this.client1, "GiaVon_k", arr);
                GIAVON = (Entities.GiaVon[])cl.DeserializeHepper1(clientstrem, GIAVON);
                if (GIAVON == null)
                    GIAVON = new Entities.GiaVon[0];
            }
            catch { }
        }

        void Xuly(DateTime truoc, DateTime sau)
        {
            try
            {
                start = truoc;
                end = sau;
                List<Entities.BCTienTonKho> hienthi = TinhToanDuLieu();
                double tong = 0;
                MANG.Clear();
                foreach (Entities.BCTienTonKho item in hienthi)
                {
                    tong += item.GiaTriTon;
                    MANG.Add(item);
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
            dtgvhienthi.Columns["MaKho"].Visible = true;
            dtgvhienthi.Columns["TenKho"].Visible = true;
            dtgvhienthi.Columns["SoLuongTon"].Visible = true;
            dtgvhienthi.Columns["giaTriTonSHOW"].Visible = true;
            dtgvhienthi.Columns["MaKho"].HeaderText = "Mã kho";
            dtgvhienthi.Columns["TenKho"].HeaderText = "Tên kho";
            dtgvhienthi.Columns["SoLuongTon"].HeaderText = "Số lượng tồn";
            dtgvhienthi.Columns["giaTriTonSHOW"].HeaderText = "Giá trị tồn";
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
                List<Entities.BCTienTonKho> ketqua = new List<Entities.BCTienTonKho>();
                foreach (Entities.BCTienTonKho item in MANG)
                {
                    int test = -1;
                    if (rdbtimkiem1.Checked)    //Tìm Kiếm Theo Mã Kho
                    {
                        test = item.MaKho.ToLower().IndexOf(Search.ToLower());
                    }
                    else if (rdbtimkiem2.Checked)   //Tìm Kiếm Theo Tên Kho
                    {
                        test = item.TenKho.ToLower().IndexOf(Search.ToLower());
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
                Xuly(truoc, hientai);
            }
            catch { }
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                Entities.BCTienTonKho[] data = (Entities.BCTienTonKho[])dtgvhienthi.DataSource;
                if (data == null)
                {
                    return;
                }
                else if (data.Length == 0)
                {
                    return;
                }
                if (chon < 0)
                {
                    return;
                }
                string MK = dtgvhienthi["MaKho", chon].Value.ToString();
                foreach (Entities.BCTienTonKho item in data)
                {
                    if (item.MaKho.Equals(MK))
                    {
                        //Xem
                        frmBaoCaorpt a = new frmBaoCaorpt(item, start.ToString("dd/MM/yyyy"), end.ToString("dd/MM/yyyy"));
                        a.ShowDialog();
                    }
                }
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
                Entities.BCTienTonKho[] data = (Entities.BCTienTonKho[])dtgvhienthi.DataSource;
                if (data == null)
                {
                    return;
                }
                else if (data.Length == 0)
                {
                    return;
                }
                if (chon < 0)
                {
                    return;
                }
                string MK = dtgvhienthi["MaKho", chon].Value.ToString();
                foreach (Entities.BCTienTonKho item in data)
                {
                    if (item.MaKho.Equals(MK))
                    {
                        //PDF
                        saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                        if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            frmBaoCaorpt a = new frmBaoCaorpt(item, start.ToString("dd/MM/yyyy"), end.ToString("dd/MM/yyyy"), saveFileDialog1.FileName, "PDF");
                        }
                    }
                }
            }
            catch { }
        }

        private void tsslWord_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.BCTienTonKho[] data = (Entities.BCTienTonKho[])dtgvhienthi.DataSource;
                if (data == null)
                {
                    return;
                }
                else if (data.Length == 0)
                {
                    return;
                }
                if (chon < 0)
                {
                    return;
                }
                string MK = dtgvhienthi["MaKho", chon].Value.ToString();
                foreach (Entities.BCTienTonKho item in data)
                {
                    if (item.MaKho.Equals(MK))
                    {
                        //DOC
                        saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                        if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            frmBaoCaorpt a = new frmBaoCaorpt(item, start.ToString("dd/MM/yyyy"), end.ToString("dd/MM/yyyy"), saveFileDialog1.FileName, "Word");
                        }
                    }
                }
            }
            catch { }
        }

        private void tsslexcel_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.BCTienTonKho[] data = (Entities.BCTienTonKho[])dtgvhienthi.DataSource;
                if (data == null)
                {
                    return;
                }
                else if (data.Length == 0)
                {
                    return;
                }
                if (chon < 0)
                {
                    return;
                }
                string MK = dtgvhienthi["MaKho", chon].Value.ToString();
                foreach (Entities.BCTienTonKho item in data)
                {
                    if (item.MaKho.Equals(MK))
                    {
                        //XLS
                        saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                        if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            frmBaoCaorpt a = new frmBaoCaorpt(item, start.ToString("dd/MM/yyyy"), end.ToString("dd/MM/yyyy"), saveFileDialog1.FileName, "Excel");
                        }
                    }
                }
            }
            catch { }
        }

        private void dtgvhienthi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                chon = e.RowIndex;
            }
            catch { }
        }

        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Enabled = false;
            try
            {
                Entities.BCTienTonKho[] data = (Entities.BCTienTonKho[])dtgvhienthi.DataSource;
                if (data == null)
                {
                    return;
                }
                else if (data.Length == 0)
                {
                    return;
                }
                if (chon < 0)
                {
                    return;
                }
                string MK = dtgvhienthi["MaKho", chon].Value.ToString();
                foreach (Entities.BCTienTonKho item in data)
                {
                    if (item.MaKho.Equals(MK))
                    {
                        //Xem
                        frmBaoCaorpt a = new frmBaoCaorpt(item, start.ToString("dd/MM/yyyy"), end.ToString("dd/MM/yyyy"));
                        a.ShowDialog();
                    }
                }
            }
            catch { }
            finally
            {
                this.Enabled = true;
            }
        }
    }
}
