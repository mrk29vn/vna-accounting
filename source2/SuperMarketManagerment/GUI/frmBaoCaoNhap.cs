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
    public partial class frmBaoCaoNhap : Form
    {
        public frmBaoCaoNhap()
        {
            InitializeComponent();
        }

        private string reportName;
        public string ReportName
        {
            get { return reportName; }
            set { reportName = value; }
        }
        public frmBaoCaoNhap(string reportName)
        {
            InitializeComponent();
            this.reportName = reportName;
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

        #region ==============================================================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        #endregion

        private Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[] khohang;
        private Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[] mathang;
        /// <summary>
        /// tim theo kho hang
        /// </summary>
        /// <param name="tungay"></param>
        /// <param name="denngay"></param>
        private void TimTheo_KhoHang(string tungay, string denngay)
        {
            try
            {
                Entities.TruyenGiaTri top = new Entities.TruyenGiaTri();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                top = new Entities.TruyenGiaTri("Select", tungay, denngay);
                clientstrem = cl.SerializeObj(this.client, "BaoCaoNhapHangTheoTungKhoTheoThoiGian", top);
                khohang = new Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[1];
                khohang = (Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[])cl.DeserializeHepper(clientstrem, khohang);
                client.Close();
                clientstrem.Close();
                if (khohang.Length <= 0)
                {
                    khohang = null;
                    Entities.HienThiBaoCao[] lay = new Entities.HienThiBaoCao[0];
                    dgvBaoCaoNhap.DataSource = lay;
                    fixDatagridview();
                } 
            }
            catch (Exception ex)
            {
                string s = ex.Message; khohang = null;
                khohang = null;
                Entities.HienThiBaoCao[] lay = new Entities.HienThiBaoCao[0];
                dgvBaoCaoNhap.DataSource = lay;
                fixDatagridview();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Entities.KiemTraChung[] kt;
        private void LayKhoHang(string tenbang, string cotID, string cotTen)
        {
            try
            {
                Entities.KiemTraChung kh = new Entities.KiemTraChung();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                kh = new Entities.KiemTraChung("Select", tenbang, cotID, cotTen);
                clientstrem = cl.SerializeObj(this.client, "LayCombox", kh);
                kt = new Entities.KiemTraChung[1];
                kt = (Entities.KiemTraChung[])cl.DeserializeHepper(clientstrem, kt);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        /// <summary>
        /// 
        /// </summary>
        private void fixDatagridview()
        {
            try
            {
                dgvBaoCaoNhap.Columns[1].HeaderText = "Mã kho";
                dgvBaoCaoNhap.Columns[2].HeaderText = "Tên kho";
                dgvBaoCaoNhap.Columns[3].HeaderText = "Số lượng";
                new Common.Utilities().CountDatagridview(dgvBaoCaoNhap);
                dgvBaoCaoNhap.RowHeadersVisible = false;
                dgvBaoCaoNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvBaoCaoNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvBaoCaoNhap.Columns[0].Width = 40;
                dgvBaoCaoNhap.Columns[1].Width = 80;
                dgvBaoCaoNhap.Columns[3].Width = 120;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        private void LocKhoHang()
        {
            try
            {
                LayKhoHang("KhoHang", "MaKho", "TenKho");
                Entities.HienThiBaoCao[] hienthi = null;
                if (kt.Length > 0)
                {
                    ArrayList list = new ArrayList();
                    for (int k = 0; k < kt.Length; k++)
                    {
                        Entities.HienThiBaoCao lay = new Entities.HienThiBaoCao();
                        lay.Ma = kt[k].Khoachinh;
                        lay.Ten = kt[k].Giatri;
                        int sl = 0;
                        for (int j = 0; j < khohang.Length; j++)
                        {
                            if (kt[k].Khoachinh == khohang[j].MaKho)
                            {
                                sl += int.Parse(khohang[j].SoLuong);
                            }
                            else
                            { continue; }
                        }
                        lay.Soluong = sl.ToString();
                        list.Add(lay);
                    }
                    int n = list.Count;
                    if (n == 0) { hienthi = null; }
                    hienthi = new Entities.HienThiBaoCao[n];
                    for (int i = 0; i < n; i++)
                    {
                        hienthi[i] = (Entities.HienThiBaoCao)list[i];
                    }
                    ArrayList list2 = new ArrayList();
                    Entities.HienThiBaoCao[] baocaokho = null;
                    for (int x = 0; x < hienthi.Length; x++)
                    {
                        if (hienthi[x].Soluong != "0")
                        {
                            Entities.HienThiBaoCao lay = new Entities.HienThiBaoCao();
                            lay.Ma = hienthi[x].Ma;
                            lay.Ten = hienthi[x].Ten;
                            lay.Soluong = hienthi[x].Soluong;
                            list2.Add(lay);
                        }
                    }
                    int w = list2.Count;
                    if (w == 0) { baocaokho = null; }
                    baocaokho = new Entities.HienThiBaoCao[w];
                    for (int t = 0; t < w; t++)
                    {
                        baocaokho[t] = (Entities.HienThiBaoCao)list2[t];
                    }
                    if (baocaokho.Length > 0)
                    {
                        dgvBaoCaoNhap.DataSource = baocaokho;
                    }
                    else
                    {
                        Entities.HienThiBaoCao[] g = new Entities.HienThiBaoCao[0];
                        dgvBaoCaoNhap.DataSource = g;
                    }
                    fixDatagridview();
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.HienThiBaoCao[] g = new Entities.HienThiBaoCao[0];
                dgvBaoCaoNhap.DataSource = g;
                fixDatagridview();
            }
        }
        /// <summary>
        /// lay ma
        /// </summary>
        /// <returns></returns>
        private string tenNhom;
        private string getID()
        {
            string ma = "";
            try
            {
                if (dgvBaoCaoNhap.RowCount > 0)
                {
                    int x = dgvBaoCaoNhap.RowCount;
                    int y = dgvBaoCaoNhap.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        int vitri = dgvBaoCaoNhap.CurrentRow.Index;
                        ma = dgvBaoCaoNhap.Rows[vitri].Cells[1].Value.ToString();
                        if (reportName.Equals("XuatNhapTonTheoNhomHang"))
                        {
                            tenNhom = dgvBaoCaoNhap.Rows[vitri].Cells[2].Value.ToString();
                        }
                        if (reportName.Equals("BaoCaoNhapTheoMatHang"))
                        {
                            tenNhom = dgvBaoCaoNhap.Rows[vitri].Cells[2].Value.ToString();
                        }
                        if (reportName.Equals("BaoCaoNhapTheoNhomHang"))
                        {
                            tenNhom = dgvBaoCaoNhap.Rows[vitri].Cells[2].Value.ToString();
                        }
                    }
                }
                else
                { ma = ""; }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); ma = ""; }
            return ma;
        }
        /// <summary>
        /// 
        /// </summary>
        private void LocMatHang()
        {
            try
            {
                LayKhoHang("HangHoa", "MaHangHoa", "TenHangHoa");
                Entities.HienThiBaoCao[] hienthi = null;
                if (kt.Length > 0)
                {
                    ArrayList list = new ArrayList();
                    for (int k = 0; k < kt.Length; k++)
                    {
                        Entities.HienThiBaoCao lay = new Entities.HienThiBaoCao();
                        lay.Ma = kt[k].Khoachinh;
                        lay.Ten = kt[k].Giatri;
                        int sl = 0;
                        for (int j = 0; j < mathang.Length; j++)
                        {
                            if (kt[k].Khoachinh == mathang[j].MaHangHoa)
                            {
                                sl += int.Parse(mathang[j].SoLuong);
                            }
                            else
                            { continue; }
                        }
                        lay.Soluong = sl.ToString();
                        list.Add(lay);
                    }
                    int n = list.Count;
                    if (n == 0) { hienthi = null; }
                    hienthi = new Entities.HienThiBaoCao[n];
                    for (int i = 0; i < n; i++)
                    {
                        hienthi[i] = (Entities.HienThiBaoCao)list[i];
                    }
                    ArrayList list2 = new ArrayList();
                    Entities.HienThiBaoCao[] baocaokho = null;
                    for (int x = 0; x < hienthi.Length; x++)
                    {
                        if (hienthi[x].Soluong != "0")
                        {
                            Entities.HienThiBaoCao lay = new Entities.HienThiBaoCao();
                            lay.Ma = hienthi[x].Ma;
                            lay.Ten = hienthi[x].Ten;
                            lay.Soluong = hienthi[x].Soluong;
                            list2.Add(lay);
                        }
                        else
                        { continue; }
                    }
                    int w = list2.Count;
                    if (w == 0) { baocaokho = null; }
                    baocaokho = new Entities.HienThiBaoCao[w];
                    for (int t = 0; t < w; t++)
                    {
                        baocaokho[t] = (Entities.HienThiBaoCao)list2[t];
                    }
                    if (baocaokho.Length > 0)
                    {
                        dgvBaoCaoNhap.DataSource = baocaokho;
                    }
                    else
                    {
                        Entities.HienThiBaoCao[] g = new Entities.HienThiBaoCao[0];
                        dgvBaoCaoNhap.DataSource = g;
                    }
                    fixDatagridview();
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.HienThiBaoCao[] g = new Entities.HienThiBaoCao[0];
                dgvBaoCaoNhap.DataSource = g;
                fixDatagridview();
            }
        }
        /// <summary>
        /// tim theo mat hang
        /// </summary>
        /// <param name="tungay"></param>
        /// <param name="denngay"></param>
        private void TimTheo_MatHang(string tungay, string denngay)
        {
            try
            {
                Entities.TruyenGiaTri top = new Entities.TruyenGiaTri();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                top = new Entities.TruyenGiaTri("Select", tungay, denngay);
                clientstrem = cl.SerializeObj(this.client, "BaoCaoNhapHangTheoTungKhoTheoThoiGian", top);
                mathang = new Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[1];
                mathang = (Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[])cl.DeserializeHepper(clientstrem, mathang);
                client.Close();
                clientstrem.Close();
                if (mathang.Length <= 0)
                {
                    mathang = null;
                    Entities.HienThiBaoCao[] lay = new Entities.HienThiBaoCao[0];
                    dgvBaoCaoNhap.DataSource = lay;
                    fixDatagridview();
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message; mathang = null; mathang = null;
                Entities.HienThiBaoCao[] lay = new Entities.HienThiBaoCao[0];
                dgvBaoCaoNhap.DataSource = lay;
                fixDatagridview();
            }
        }
        /// <summary>
        /// tim theo nhom hang
        /// </summary>
        /// <param name="tungay"></param>
        /// <param name="denngay"></param>
        private void TimTheo_NhomHang(string thang, string nam)
        {
            try
            {
                Entities.TruyenGiaTri top = new Entities.TruyenGiaTri();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                top = new Entities.TruyenGiaTri("Select", thang, nam);
                clientstrem = cl.SerializeObj(this.client, "BaoCaoNhapHangTheoTungKhoTheoThoiGian", top);
                Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[] ddh = new Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[1];
                ddh = (Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length > 0)
                {
                    nhomhang = new Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[ddh.Length];
                    nhomhang = ddh;
                }
                else
                {
                    khohang = null;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        private void frmBaoCaoNhap_Load(object sender, EventArgs e)
        {
            try
            {
                this.cbxThang.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
                cbxThang.SelectedIndex = 0;
                this.cbxNam.Items.AddRange(new object[] { "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2019", "2020" });
                cbxNam.SelectedIndex = 0;
                thongtin = Utils.LayThongTinCongty();
                switch (reportName)
                {
                    //=============================================================================
                    case "BaoCaoNhapTheoKhoHang":
                        {
                            Entities.HienThiBaoCao[] lay = new Entities.HienThiBaoCao[0];
                            dgvBaoCaoNhap.DataSource = lay;
                            fixDatagridview();
                            lblTieuDe.Text = "Báo Cáo Nhập Hàng Theo Kho Hàng Theo Kỳ";
                        } break;
                    //=============================================================================
                    case "BaoCaoNhapTheoNhomHang":
                        {
                            Entities.HienThiBaoCao[] lay = new Entities.HienThiBaoCao[0];
                            dgvBaoCaoNhap.DataSource = lay;
                            fixDatagridview();
                            lblTieuDe.Text = "Báo Cáo Nhập Hàng Theo Nhóm Hàng Theo Kỳ";
                        } break;
                    //=============================================================================
                    case "BaoCaoNhapTheoMatHang":
                        {
                            Entities.HienThiBaoCao[] lay = new Entities.HienThiBaoCao[0];
                            dgvBaoCaoNhap.DataSource = lay;
                            fixDatagridview();
                            lblTieuDe.Text = "Báo Cáo Nhập Hàng Theo Mat Hàng Theo Kỳ";
                        } break;
                    //=============================================================================
                    case "XuatNhapTonTheoNhomHang":
                        {
                            Entities.HienThiBaoCao[] g = new Entities.HienThiBaoCao[0];
                            dgvBaoCaoNhap.DataSource = g;
                            fixDatagridviewNhom();
                            lblTieuDe.Text = "Báo Cáo Xuất Nhập Tồn Hàng Theo Nhóm Hàng Theo Kỳ";
                        } break;
                    default:
                        {
                            MessageBox.Show("Không có tên báo cáo.Ứng dụng sẽ đóng");
                            this.Close();
                        } break;
                }
                if (thongtin.TenCongTy == "")
                { MessageBox.Show("Thông tin công ty chưa có hãy kiểm tra lại"); return; }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
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
        /// 
        /// </summary>
        private void LocXuatNhapTonNhomHang()
        {
            try
            {
                Entities.HienThiBaoCao[] hienthi = null;
                if (nhom.Length > 0)
                {
                    ArrayList list = new ArrayList();
                    for (int k = 0; k < nhom.Length; k++)
                    {
                        Entities.HienThiBaoCao lay = new Entities.HienThiBaoCao();
                        lay.STT = "Select";
                        lay.Ma = nhom[k].Khoachinh;
                        lay.Ten = nhom[k].Giatri;
                        int sl = 0;
                        for (int j = 0; j < nhom.Length; j++)
                        {
                            if (nhom[k].Khoachinh == hang[j].Giatri)
                            {
                                for (int f = 0; f < nhomhang.Length; f++)
                                {
                                    if (hang[j].Giatri == nhomhang[f].MaHangHoa)
                                    {
                                        sl += int.Parse(nhomhang[f].SoLuong);
                                    }
                                    else
                                    { continue; }
                                }
                            }
                            else
                            { continue; }
                        }
                        lay.Soluong = sl.ToString();
                        list.Add(lay);
                    }
                    int n = list.Count;
                    if (n == 0) { hienthi = null; }
                    hienthi = new Entities.HienThiBaoCao[n];
                    for (int i = 0; i < n; i++)
                    {
                        hienthi[i] = (Entities.HienThiBaoCao)list[i];
                    }

                    if (hienthi.Length > 0)
                    {
                        dgvBaoCaoNhap.DataSource = hienthi;
                               // LayThongTinNhom(hienthi);
                    }
                    else
                    {
                        Entities.HienThiBaoCao[] g = new Entities.HienThiBaoCao[0];
                        dgvBaoCaoNhap.DataSource = g;
                    }
                    fixDatagridviewNhom();
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.HienThiBaoCao[] g = new Entities.HienThiBaoCao[0];
                dgvBaoCaoNhap.DataSource = g;
                fixDatagridviewNhom();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nh"></param>
        private Entities.HienThiBaoCao[] LayThongTinNhom(Entities.HienThiBaoCao[] nh)
        {
            Entities.HienThiBaoCao[] tra = new Entities.HienThiBaoCao[1];
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "KiemTraNhomHangHoa", nh);
                tra = (Entities.HienThiBaoCao[])cl.DeserializeHepper(clientstrem, tra);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString(); 
                tra = new Entities.HienThiBaoCao[0]; 
            }
            return tra;
        }
        /// <summary>
        /// fix nhom hang hoa
        /// </summary>
        private void fixDatagridviewNhom()
        {
            try
            {
                dgvBaoCaoNhap.Columns[1].HeaderText = "Mã nhóm";
                dgvBaoCaoNhap.Columns[2].HeaderText = "Tên nhóm hàng";
                dgvBaoCaoNhap.Columns[3].HeaderText = "Số lượng";
                dgvBaoCaoNhap.Columns[3].Visible = false;
                new Common.Utilities().CountDatagridview(dgvBaoCaoNhap);
                dgvBaoCaoNhap.RowHeadersVisible = false;
                dgvBaoCaoNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvBaoCaoNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvBaoCaoNhap.Columns[0].Width = 40;
                dgvBaoCaoNhap.Columns[1].Width = 80;
                dgvBaoCaoNhap.Columns[3].Width = 120;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        private void LayNhomHang(string tenbang, string cotID, string cotTen)
        {
            try
            {
                Entities.KiemTraChung kh = new Entities.KiemTraChung();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                kh = new Entities.KiemTraChung("Select", tenbang, cotID, cotTen);
                clientstrem = cl.SerializeObj(this.client, "LayCombox", kh);
                nhom = new Entities.KiemTraChung[1];
                nhom = (Entities.KiemTraChung[])cl.DeserializeHepper(clientstrem, kt);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        /// <summary>
        /// 
        /// </summary>

        private void LayHangHoa(string tenbang, string cotID, string cotTen)
        {
            try
            {
                Entities.KiemTraChung kh = new Entities.KiemTraChung();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                kh = new Entities.KiemTraChung("Select", tenbang, cotID, cotTen);
                clientstrem = cl.SerializeObj(this.client, "LayCombox", kh);
                hang = new Entities.KiemTraChung[1];
                hang = (Entities.KiemTraChung[])cl.DeserializeHepper(clientstrem, kt);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        /// <summary>
        /// tim kiem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                //gan gia tri khoi tao===================================
                hang = null;
                nhom = null;
                nhacungcap = null;
                khachhangtralai = null;
                banbuon = null;
                banle = null;
                //=======================================================
                string thang = cbxThang.SelectedItem.ToString();
                string nam = cbxNam.SelectedItem.ToString();
                //=======================================================
                switch (reportName)
                {
                    case "BaoCaoNhapTheoKhoHang": 
                        {
                            this.Enabled = false;
                            TimTheo_KhoHang(thang, nam);
                            this.Enabled = true;
                            if (khohang.Length > 0)
                            {
                                this.Enabled = false;
                                LocKhoHang();
                                this.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu"); khohang = null;
                                Entities.HienThiBaoCao[] lay = new Entities.HienThiBaoCao[0];
                                dgvBaoCaoNhap.DataSource = lay;
                                fixDatagridview();
                                this.Enabled = true;
                            }
                            
                        } break;
                    //=============================================================================
                    case "BaoCaoNhapTheoNhomHang": 
                        {
                            this.Enabled = false;
                            LayNhomHang("NhomHang", "MaNhomHang", "TenNhomHang");
                            LayHangHoa("HangHoa", "MaHangHoa", "MaNhomHangHoa");
                            TimTheo_NhomHang(thang, nam);
                            this.Enabled = true;
                            if (nhomhang.Length > 0)
                            {
                                this.Enabled = false;
                                LocXuatNhapTonNhomHang();
                                this.Enabled = true;
                            }
                            else
                            {
                                Entities.HienThiBaoCao[] g = new Entities.HienThiBaoCao[0];
                                dgvBaoCaoNhap.DataSource = g;
                                fixDatagridviewNhom();
                                MessageBox.Show("Không có dữ liệu");
                                this.Enabled = true;
                            }
                            
                        } break;
                    //=============================================================================
                    case "BaoCaoNhapTheoMatHang": 
                        {
                            this.Enabled = false;
                            TimTheo_MatHang(thang, nam);
                            this.Enabled = true;
                            if (mathang.Length > 0)
                            {
                                this.Enabled = false;
                                LocMatHang();
                                this.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu"); mathang = null;
                                Entities.HienThiBaoCao[] lay = new Entities.HienThiBaoCao[0];
                                dgvBaoCaoNhap.DataSource = lay;
                                fixDatagridview();
                                this.Enabled = true;
                            }

                        } break;
                    //=============================================================================
                    case "XuatNhapTonTheoNhomHang":
                        {
                            this.Enabled = false;
                            BindingData(thang, nam);
                            Tim_XuatNhapTonTheoNhom(thang, nam);
                            this.Enabled = true;
                            if (nhomhang.Length > 0)
                            {
                                this.Enabled = false;
                                LocXuatNhapTonNhomHang();
                                this.Enabled = true;
                            }
                            else
                            {
                                Entities.HienThiBaoCao[] g = new Entities.HienThiBaoCao[0];
                                dgvBaoCaoNhap.DataSource = g;
                                fixDatagridviewNhom();
                                MessageBox.Show("Không có dữ liệu");
                                this.Enabled = true;
                            }
                        } break;
                    //=============================================================================
                    default: { MessageBox.Show("Không tìm thấy tên báo cáo"); this.Close(); } break;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                this.Enabled = true;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ma"></param>
        private Entities.NhapHangTheoKho[] theokho;
        private void LocBaoCaoTheoKhoHang(string ma)
        {
            try
            {
                if (khohang.Length > 0)
                {
                    ArrayList list = new ArrayList();
                    for (int z = 0; z < khohang.Length; z++)
                    {
                        if (khohang[z].MaKho == ma)
                        {
                            Entities.NhapHangTheoKho banghi = new Entities.NhapHangTheoKho();
                            banghi.HoaDonNhap = khohang[z].MaHoaDonNhap;
                            banghi.NgayNhap = khohang[z].NgayNhap.ToString("dd/MM/yyyy");
                            banghi.TenHang = khohang[z].TenHangHoa;
                            banghi.SoLuong = int.Parse(khohang[z].SoLuong);
                            banghi.TongTien = (int.Parse(khohang[z].SoLuong) * Double.Parse(khohang[z].GiaNhap)) - (((Double.Parse(khohang[z].PhanTramChietKhau) / 100) * Double.Parse(khohang[z].GiaNhap)) * Double.Parse(khohang[z].SoLuong));
                            list.Add(banghi);
                        }
                    }

                    int n = list.Count;
                    if (n == 0) { theokho = null; }
                    theokho = new Entities.NhapHangTheoKho[n];
                    for (int i = 0; i < n; i++)
                    {
                        theokho[i] = (Entities.NhapHangTheoKho)list[i];
                    }
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ma"></param>
        private void PrintKho(string ma, Entities.ThongTinCongTy congty)
        {
            try
            {
                string ky = cbxThang.SelectedItem.ToString() + " - " + cbxNam.SelectedItem.ToString();
                string maNV = Common.Utilities.User.TenNhanVien;
                if (theokho.Length > 0 && congty!=null && ma!="" && maNV !="" && ky!="")
                {
                    frmBaoCaoNhapHang frm = new frmBaoCaoNhapHang("KhoHang", congty, theokho, ky, ma, maNV, "Báo Cáo Nhập Hàng Theo Kỳ");
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            catch (Exception ex)
            { string s = ex.Message; MessageBox.Show("Thất bại"); }
        }
        /// <summary>
        /// 
        /// </summary>
        private Entities.NhapHangTheoMatHang[] theoMatHang;
        private void LocBaoCaoMatHang(string ma)
        {
            try
            {
                if (mathang.Length > 0)
                {
                    ArrayList list = new ArrayList();
                    for (int z = 0; z < mathang.Length; z++)
                    {
                        if (mathang[z].MaHangHoa == ma)
                        {
                            Entities.NhapHangTheoMatHang banghi = new Entities.NhapHangTheoMatHang();
                            banghi.NgayNhap = mathang[z].NgayNhap.ToString("dd/MM/yyyy");
                            banghi.HoaDonNhap = mathang[z].MaHoaDonNhap;
                            banghi.SoLuong = int.Parse(mathang[z].SoLuong);
                            banghi.ThanhTien = Double.Parse(mathang[z].TongTien);
                            list.Add(banghi);
                        }
                        else
                        { continue; }
                    }

                    int n = list.Count;
                    if (n == 0) { theokho = null; }
                    theoMatHang = new Entities.NhapHangTheoMatHang[n];
                    for (int i = 0; i < n; i++)
                    {
                        theoMatHang[i] = (Entities.NhapHangTheoMatHang)list[i];
                    }
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ma"></param>
        /// <param name="congty"></param>
        private void PrintMatHang(string ma, Entities.ThongTinCongTy congty,string tenhang)
        {
            try
            {
                string ky = cbxThang.SelectedItem.ToString() + " - " + cbxNam.SelectedItem.ToString();
                string maNV = Common.Utilities.User.TenNhanVien;
                if (theoMatHang.Length > 0 && congty.TenCongTy.Length > 0 && ma.Length > 0 && maNV != "" && ky.Length > 3 && tenhang !="")
                {
                    frmBaoCaoNhapHang frm = new frmBaoCaoNhapHang("MatHang", congty, theoMatHang, ky, ma, maNV, "Báo Cáo Nhập Hàng Theo Mặt Hàng Theo Kỳ",tenhang);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ma"></par
        Entities.XuatNhapTonTheoNhomHangHoa[] baocaonhomhang;
        private void HienThi_XuatNhapTonTheoNhom(string ma)
        {
            try
            {
                LayHangHoaTheoNMhom(ma);
                if (nhomhang.Length > 0)
                {
                    ArrayList list = new ArrayList();
                    for (int z = 0; z < nhomhang.Length; z++)
                    {
                        for (int v = 0; v < hanghoatheonhom.Length; v++)
                        {
                            if (nhomhang[z].MaHangHoa == hanghoatheonhom[v].MaHangHoa)
                            {
                                Entities.XuatNhapTonTheoNhomHangHoa banghi = new Entities.XuatNhapTonTheoNhomHangHoa();
                                //===========================================================
                                int khachtra = 0;
                                if (khachhangtralai.Length > 0)
                                {
                                    for (int o = 0; o < khachhangtralai.Length; o++)
                                    {
                                        if (nhomhang[z].MaHangHoa == khachhangtralai[o].MaHangHoa)
                                        {
                                            khachtra += int.Parse(khachhangtralai[o].SoLuong);
                                        }
                                        else
                                        { continue; }
                                    }
                                }
                                else
                                { khachtra = 0; }
                                //===========================================================
                                int buon = 0;
                                if (banbuon.Length > 0)
                                {
                                    for (int o = 0; o < banbuon.Length; o++)
                                    {
                                        if (nhomhang[z].MaHangHoa == banbuon[o].MaHangHoa)
                                        { buon += banbuon[o].SoLuong; }
                                        else
                                        { continue; }
                                    }
                                }
                                else
                                { buon = 0; }
                                //===========================================================
                                int le = 0;
                                if (banle.Length > 0)
                                {
                                    for (int o = 0; o < banle.Length; o++)
                                    {
                                        if (nhomhang[z].MaHangHoa == banle[o].MaHangHoa)
                                        { le += banle[o].SoLuong; }
                                        else
                                        { continue; }
                                    }
                                }
                                else
                                { le = 0; }
                                //===========================================================
                                int cungcap = 0;
                                if (nhacungcap.Length > 0)
                                {
                                    for (int o = 0; o < nhacungcap.Length; o++)
                                    {
                                        if (nhomhang[z].MaHangHoa == nhacungcap[o].MaHangHoa)
                                        { cungcap += int.Parse(nhacungcap[o].SoLuong); }
                                        else
                                        { continue; }
                                    }
                                }
                                else
                                { cungcap = 0; }
                                //===========================================================
                                int sodu = 0;
                                if (sodukho.Length > 0)
                                {
                                    for (int o = 0; o < sodukho.Length; o++)
                                    {
                                        if (nhomhang[z].MaHangHoa == sodukho[o].MaHangHoa)
                                        { sodu += sodukho[o].SoDuDauKy; }
                                        else
                                        { continue; }
                                    }
                                }
                                else
                                { sodu = 0; }
                                //===========================================================
                                int tn =tinhTongNhap(int.Parse(nhomhang[z].SoLuong),khachtra);
                                int tx = tinhTongXuat(buon,le,cungcap);
                                banghi.MaHangHoa = nhomhang[z].MaHangHoa;
                                banghi.TenHangHoa = nhomhang[z].TenHangHoa;
                                banghi.DauKy = sodu;
                                banghi.TongNhap = tn;
                                banghi.NhapKho = int.Parse(nhomhang[z].SoLuong);
                                banghi.KhachTra = khachtra;
                                banghi.TongXuat = tx;
                                banghi.BanBuon = buon;
                                banghi.BanLe = le;
                                banghi.TraNCC = cungcap;
                                banghi.CuoiKy = SoDuCuoiKy(sodu,tn,tx);
                                banghi.NgayNhap = nhomhang[z].NgayNhap.ToString("dd/MM/yyyy");
                                list.Add(banghi);
                            }
                            else
                            { continue; }
                        }
                    }
                    int n = list.Count;
                    if (n == 0) { theokho = null; }
                    baocaonhomhang = new Entities.XuatNhapTonTheoNhomHangHoa[n];
                    for (int i = 0; i < n; i++)
                    {
                        baocaonhomhang[i] = (Entities.XuatNhapTonTheoNhomHangHoa)list[i];
                    }
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ma"></param>
        /// <param name="congty"></param>
        private void PrintGroup(string ma, Entities.ThongTinCongTy congty)
        {
            try
            {
                string ky = cbxThang.SelectedItem.ToString() + " - " + cbxNam.SelectedItem.ToString();
                string maNV = Common.Utilities.User.TenNhanVien;
                if (baocaonhomhang.Length > 0 && congty.TenCongTy.Length > 0 && ma != "" && ky.Length > 3 && tenNhom.Length > 0 && maNV != "")
                {
                    frmBaoCaoNhapHang frm = new frmBaoCaoNhapHang("XuatNhapTonTheoNhomHang", congty, baocaonhomhang, ky, ma, maNV, "Báo Cáo Xuất Nhập Tồn Theo Nhóm Hàng", tenNhom);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private Entities.BaoCaoNhapHangTheoNhom[] baocaotheonhom;
        private void LocNhapHangTheoNhom(string ma)
        {
            try
            {
                LayHangHoaTheoNMhom(ma);
                if (nhomhang.Length > 0)
                {
                    ArrayList list = new ArrayList();
                    for (int z = 0; z < nhomhang.Length; z++)
                    {
                        for (int v = 0; v < hanghoatheonhom.Length; v++)
                        {
                            if (nhomhang[z].MaHangHoa == hanghoatheonhom[v].MaHangHoa)
                            {
                                Entities.BaoCaoNhapHangTheoNhom banghi = new Entities.BaoCaoNhapHangTheoNhom();
                                banghi.NgayNhap = nhomhang[z].NgayNhap.ToString("dd/MM/yyyy");
                                banghi.HoaDonNhap = nhomhang[z].MaHoaDonNhap;
                                banghi.TenHangHoa = nhomhang[z].TenHangHoa;
                                banghi.SoLuong = int.Parse(nhomhang[z].SoLuong);
                                banghi.ThanhTien = Double.Parse(nhomhang[z].TongTien);
                                list.Add(banghi);
                            }
                            else
                            { continue; }
                        }
                    }
                    int n = list.Count;
                    if (n == 0) { theokho = null; }
                    baocaotheonhom = new Entities.BaoCaoNhapHangTheoNhom[n];
                    for (int i = 0; i < n; i++)
                    {
                        baocaotheonhom[i] = (Entities.BaoCaoNhapHangTheoNhom)list[i];
                    }
                }
                else
                {
                    MessageBox.Show("Thất bại");
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ma"></param>
        /// <param name="congty"></param>
        private void PrintNhom(string ma, Entities.ThongTinCongTy congty,string ten)
        {
            try
            {
                string ky = cbxThang.SelectedItem.ToString() + " - " + cbxNam.SelectedItem.ToString();
                string maNV = Common.Utilities.User.TenNhanVien;
                if (baocaotheonhom.Length > 0 && congty.TenCongTy.Length > 0 && ma != "" && ky.Length > 3 && tenNhom.Length > 0 && maNV != "")
                {
                    frmBaoCaoNhapHang frm = new frmBaoCaoNhapHang("NhomHang", congty, baocaotheonhom, ky, ma, maNV, "Báo Cáo Nhập Hàng Theo Nhóm Hàng", tenNhom);
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu");
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dau"></param>
        /// <param name="nhap"></param>
        /// <param name="xuat"></param>
        /// <returns></returns>
        private int SoDuCuoiKy(int dau,int nhap,int xuat)
        {
            int cuoi = 0;
            try
            {
                cuoi = (nhap + dau) - xuat;
            }
            catch(Exception ex)
            { string s = ex.Message; cuoi = 0; }
            return cuoi;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int tinhTongNhap(int a,int b)
        {
            int t = 0;
            try
            {
                t = a + b;
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return t;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int tinhTongXuat(int a, int b,int c)
        {
            int t = 0;
            try
            {
                t = a + b + c;
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return t;
        }
        /// <summary>
        /// 
        /// </summary>
        private Entities.ThongTinHangHoa[] hanghoatheonhom;
        private void LayHangHoaTheoNMhom(string manhom)
        {
            try
            {
                Entities.TruyenGiaTri h = new Entities.TruyenGiaTri();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                h = new Entities.TruyenGiaTri("Select", manhom);
                clientstrem = cl.SerializeObj(this.client, "TimHangHoaTheoMaNhomHang", h);
                hanghoatheonhom = new Entities.ThongTinHangHoa[1];
                hanghoatheonhom = (Entities.ThongTinHangHoa[])cl.DeserializeHepper(clientstrem, kt);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); hanghoatheonhom = null; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvBaoCaoNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string ID = getID();
                switch (reportName)
                {
                    case "BaoCaoNhapTheoKhoHang":
                        { 
                            LocBaoCaoTheoKhoHang(ID);
                            PrintKho(ID, thongtin);
                        } break;
                    case "BaoCaoNhapTheoNhomHang": 
                        {
                            this.Enabled = false;
                            LocNhapHangTheoNhom(ID);
                            this.Enabled = true;
                            PrintNhom(ID, thongtin,tenNhom);
                        } break;
                    case "BaoCaoNhapTheoMatHang": 
                        {
                            LocBaoCaoMatHang(ID);
                            PrintMatHang(ID, thongtin, tenNhom);
                        } break;
                    case "XuatNhapTonTheoNhomHang": 
                        { 
                            HienThi_XuatNhapTonTheoNhom(ID);
                            PrintGroup(ID,thongtin);
                        }break;
                    default: break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #region Hungvv-Xuat_Nhap_Ton-NhomHangHoa====================================================================================================
        /// <summary>
        /// lay nha tra lai nha cung cap theo ky`
        /// </summary>
        private void LayTraLaiNhaCungCap(string thang, string nam)
        {
            try
            {
                Entities.TruyenGiaTri top = new Entities.TruyenGiaTri();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                top = new Entities.TruyenGiaTri("Select", thang, nam);
                clientstrem = cl.SerializeObj(this.client, "BaoCaoTraLaiNhaCungcapTheoKy", top);
                nhacungcap = new Entities.BaoCaoTraLaiNhaCungcapTheoKy[1];
                nhacungcap = (Entities.BaoCaoTraLaiNhaCungcapTheoKy[])cl.DeserializeHepper(clientstrem, nhacungcap);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message; nhacungcap = null; }
        }
        /// <summary>
        /// lay khach hang tra lai hang theo ky`
        /// </summary>

        private void LayKhachHangTraLai(string thang, string nam)
        {
            try
            {
                Entities.TruyenGiaTri top = new Entities.TruyenGiaTri();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                top = new Entities.TruyenGiaTri("Select", thang, nam);
                clientstrem = cl.SerializeObj(this.client, "BaoCaoKhachHangTraLaiTheoKy", top);
                khachhangtralai = new Entities.BaoCaoKhachHangTraLaiTheoKy[1];
                khachhangtralai = (Entities.BaoCaoKhachHangTraLaiTheoKy[])cl.DeserializeHepper(clientstrem, khachhangtralai);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message; khachhangtralai = null; }
        }
        /// <summary>
        /// lay khach hang tra lai hang theo ky`
        /// </summary>

        private void LayBanBuon(string thang, string nam, string loai)
        {
            try
            {
                Entities.TruyenGiaTri top = new Entities.TruyenGiaTri();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                top = new Entities.TruyenGiaTri("Select", thang, nam, loai);
                clientstrem = cl.SerializeObj(this.client, "BaoCaoBanBuonBanLeTheoKy", top);
                banbuon = new Entities.BaoCaoBanBuonBanLeTheoKy[1];
                banbuon = (Entities.BaoCaoBanBuonBanLeTheoKy[])cl.DeserializeHepper(clientstrem, banbuon);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message; banbuon = null; }
        }
        /// <summary>
        /// lay khach hang tra lai hang theo ky`
        /// </summary>

        private void LayBanLe(string thang, string nam, string loai)
        {
            try
            {
                Entities.TruyenGiaTri top = new Entities.TruyenGiaTri();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                top = new Entities.TruyenGiaTri("Select", thang, nam, loai);
                clientstrem = cl.SerializeObj(this.client, "BaoCaoBanBuonBanLeTheoKy", top);
                banle = new Entities.BaoCaoBanBuonBanLeTheoKy[1];
                banle = (Entities.BaoCaoBanBuonBanLeTheoKy[])cl.DeserializeHepper(clientstrem, banle);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message; banle = null; }
        }
        /// <summary>
        /// lay hoa don nhap
        /// </summary>
        /// <param name="thang"></param>
        /// <param name="nam"></param>
        private void Tim_XuatNhapTonTheoNhom(string thang, string nam)
        {
            try
            {
                Entities.TruyenGiaTri top = new Entities.TruyenGiaTri();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                top = new Entities.TruyenGiaTri("Select", thang, nam);
                clientstrem = cl.SerializeObj(this.client, "BaoCaoNhapHangTheoTungKhoTheoThoiGian", top);
                nhomhang = new Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[1];
                nhomhang = (Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[])cl.DeserializeHepper(clientstrem, nhomhang);
                client.Close();
                clientstrem.Close();
                if (nhomhang.Length <= 0)
                {
                    nhomhang = new Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[0];
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                nhomhang = new Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[0];
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thang"></param>
        /// <param name="nam"></param>
        private void LaySoDuKho(string thang, string nam)
        {
            try
            {
                Entities.TruyenGiaTri top = new Entities.TruyenGiaTri();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                top = new Entities.TruyenGiaTri("Select", thang, nam);
                clientstrem = cl.SerializeObj(this.client, "BaoCaoSoDuKho", top);
                sodukho = new Entities.BaoCaoSoDuKho[1];
                sodukho = (Entities.BaoCaoSoDuKho[])cl.DeserializeHepper(clientstrem, sodukho);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            {
                sodukho = null;
                string s = ex.Message;
            }
        }
        /// <summary>
        /// lay du lieu
        /// </summary>
        private Entities.BaoCaoSoDuKho[] sodukho;//so du kho hang
        private Entities.BaoCaoNhapHangTheoTungKhoTheoThoiGian[] nhomhang;
        private Entities.KiemTraChung[] hang; //hang hoa
        private Entities.KiemTraChung[] nhom; //nhom hang hoa
        private Entities.BaoCaoTraLaiNhaCungcapTheoKy[] nhacungcap; //tra lai nha cung cap
        private Entities.BaoCaoKhachHangTraLaiTheoKy[] khachhangtralai;//khach hang tra lai
        private Entities.BaoCaoBanBuonBanLeTheoKy[] banbuon;//ban buon
        private Entities.BaoCaoBanBuonBanLeTheoKy[] banle;//ban le
        private Entities.ThongTinCongTy thongtin;
        private void BindingData(string thang, string nam)
        {
            try
            {
                LayNhomHang("NhomHang", "MaNhomHang", "TenNhomHang");
                LayHangHoa("HangHoa", "MaHangHoa", "MaNhomHangHoa");
                LayTraLaiNhaCungCap(thang, nam);
                LayKhachHangTraLai(thang, nam);
                LayBanBuon(thang, nam, "BanBuon");
                LayBanLe(thang, nam, "BanLe");
                LaySoDuKho(thang, nam);
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion Hungvv-Xuat_Nhap_Ton-NhomHangHoa=================================================================================================

        private void ExportWord(string hanhdong,string filter)
        {
            try
            {
                string ID = getID();
                switch (reportName)
                {
                    case "BaoCaoNhapTheoKhoHang":
                        {
                            this.Enabled = false;
                            LocBaoCaoTheoKhoHang(ID);
                            this.Enabled = true;
                            saveFile.Filter = filter;
                            string ky = cbxThang.SelectedItem.ToString() + " - " + cbxNam.SelectedItem.ToString();
                            string maNV = Common.Utilities.User.TenNhanVien;
                            if (theokho.Length > 0 && thongtin != null && ID != "" && maNV != "" && ky != "")
                            {
                                if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    frmBaoCaoNhapHang a = new frmBaoCaoNhapHang(hanhdong, this.theokho, this.thongtin, saveFile.FileName, ky, ID, maNV, "Báo Cáo Nhập Hàng Theo Kho Theo Kỳ");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu");
                            }
                        } break;
                    case "BaoCaoNhapTheoNhomHang":
                        {
                            this.Enabled = false;
                            LocNhapHangTheoNhom(ID);
                            this.Enabled = true;
                            saveFile.Filter = filter;
                            string ky = cbxThang.SelectedItem.ToString() + " - " + cbxNam.SelectedItem.ToString();
                            string maNV = Common.Utilities.User.TenNhanVien;
                            if (baocaotheonhom.Length > 0 && thongtin.TenCongTy.Length > 0 && ID != "" && ky.Length > 3 && tenNhom.Length > 0 && maNV != "")
                            {
                                if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    frmBaoCaoNhapHang frm = new frmBaoCaoNhapHang(hanhdong, saveFile.FileName, thongtin, baocaotheonhom, ky, ID, maNV, "Báo Cáo Nhập Hàng Theo Nhóm Hàng", tenNhom);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu");
                            }
                        } break;
                    case "BaoCaoNhapTheoMatHang":
                        {
                            this.Enabled = false;
                            LocBaoCaoMatHang(ID);
                            this.Enabled = true;
                            saveFile.Filter = filter;
                            string ky = cbxThang.SelectedItem.ToString() + " - " + cbxNam.SelectedItem.ToString();
                            string maNV = Common.Utilities.User.TenNhanVien;
                            if (theoMatHang.Length > 0 && thongtin.TenCongTy.Length > 0 && ID.Length > 0 && maNV != "" && ky.Length > 3 && tenNhom != "")
                            {
                                if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    frmBaoCaoNhapHang frm = new frmBaoCaoNhapHang(hanhdong, saveFile.FileName, thongtin, theoMatHang, ky, ID, maNV, "Báo Cáo Nhập Hàng Theo Mặt Hàng Theo Kỳ", tenNhom);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu");
                            }
                        } break;
                    case "XuatNhapTonTheoNhomHang":
                        {
                            this.Enabled = false;
                            HienThi_XuatNhapTonTheoNhom(ID);
                            this.Enabled = true;
                            saveFile.Filter = filter;
                            string ky = cbxThang.SelectedItem.ToString() + " - " + cbxNam.SelectedItem.ToString();
                            string maNV = Common.Utilities.User.TenNhanVien;
                            if (baocaonhomhang.Length > 0 && thongtin.TenCongTy.Length > 0 && ID != "" && ky.Length > 3 && tenNhom.Length > 0 && maNV != "")
                            {
                                if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    frmBaoCaoNhapHang frm = new frmBaoCaoNhapHang(hanhdong, saveFile.FileName, thongtin, baocaonhomhang, ky, ID, maNV, "Báo Cáo Xuất Nhập Tồn Theo Nhóm Hàng", tenNhom);
                                } 
                            }
                            else
                            {
                                MessageBox.Show("Không có dữ liệu");
                            }
                        } break;
                    default: break;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                ExportWord("Word", "Word |*.doc");
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                ExportWord("Excel", "Excel |*.xls");
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            try
            {
                ExportWord("PDF", "PDF |*.pdf");
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
