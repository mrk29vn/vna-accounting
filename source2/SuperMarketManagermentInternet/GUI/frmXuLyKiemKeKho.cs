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
    public partial class frmXuLyKiemKeKho : Form
    {
        DateTime datesv;
        Entities.ThongTinDatHang[] hangHoaTrongKho;
        Entities.ThongTinKiemKeKho[] ctTemp;
        Entities.GiaVon[] giaVon;
        #region hungvv-------------------------------------------------------------------------------------------------------
        public frmXuLyKiemKeKho()
        {
            InitializeComponent(); datesv = DateServer.Date();
        }
        private string hanhdong;

        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        private string tenFrom;

        public string TenFrom
        {
            get { return tenFrom; }
            set { tenFrom = value; }
        }
        private Entities.KiemKeKho kk;

        public Entities.KiemKeKho Kk
        {
            get { return kk; }
            set { kk = value; }
        }
        public frmXuLyKiemKeKho(string hanhdong)
        {
            InitializeComponent(); datesv = DateServer.Date();
            this.hanhdong = hanhdong;
        }
        public frmXuLyKiemKeKho(string hanhdong, string tenform)
        {
            InitializeComponent();
            datesv = DateServer.Date();
            this.hanhdong = hanhdong;
            this.tenFrom = tenform;
            this.Text = tenform;
            LayGiaVon();
        }
        public frmXuLyKiemKeKho(string hanhdong, string tenform, Entities.KiemKeKho kk)
        {
            InitializeComponent(); datesv = DateServer.Date();
            this.hanhdong = hanhdong;
            this.tenFrom = tenform;
            this.kk = kk;
            this.Text = tenform;
            LayGiaVon();
        }
        public frmXuLyKiemKeKho(string hanhdong, Entities.KiemKeKho kk)
        {
            InitializeComponent(); datesv = DateServer.Date();
            this.hanhdong = hanhdong;
            this.kk = kk;
        }
        #endregion

        #region hungvv===============================================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        private Server_Client.Client cl;


        void LayGiaVon()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                ArrayList arr = new ArrayList();
                arr.Add("SelectTheoDieuKien_GiaVon");
                arr.Add("Select_GIAVON");
                arr.Add(new Entities.GiaVon());
                arr.Add(new Entities.GiaVon());
                clientstrem = cl.SerializeObj(this.client, "GiaVon_k", arr);
                giaVon = (Entities.GiaVon[])cl.DeserializeHepper1(clientstrem, giaVon);
                if (giaVon == null)
                    giaVon = new Entities.GiaVon[0];
            }
            catch { }
        }

        /// <summary>
        ///  Lấy Kho Hàng
        /// </summary>
        private void LayKhoHang()
        {
            try
            {
                cbxKhoban.Items.Clear();
                Entities.KiemTraChung kh = new Entities.KiemTraChung();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                kh = new Entities.KiemTraChung("Select", "KhoHang", "MaKho", "TenKho");
                clientstrem = cl.SerializeObj(this.client, "LayCombox", kh);
                Entities.KiemTraChung[] ddh = new Entities.KiemTraChung[1];
                ddh = (Entities.KiemTraChung[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh != null)
                {
                    Common.Utilities com = new Common.Utilities();
                    com.BindingCombobox(ddh, cbxKhoban, "giatri", "khoachinh");
                }
                else
                { }
            }
            catch (Exception)
            { }
            client.Close();
            clientstrem.Close();
        }

        #endregion
        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmQuanLyKiemKeKho.BaoDong = "A";
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
        /// kiem tra lai truoc khi them moi
        /// </summary>
        /// <param name="giatri"></param>
        /// <param name="sosanh"></param>
        /// <returns></returns>
        private Boolean checkConflictUpdate(Entities.KiemKeKho giatri, Entities.KiemKeKho sosanh)
        {
            Boolean kiemtra = false;
            try
            {
                int count = 0;
                if (giatri.PhieuKiemKeKhoID != sosanh.PhieuKiemKeKhoID)
                { kiemtra = false; ID = sosanh.PhieuKiemKeKhoID; }
                else { kiemtra = true; count = count + 1; }
                if (giatri.MaKiemKe != sosanh.MaKiemKe)
                { kiemtra = false; txtSochungtu.Text = sosanh.MaKiemKe; }
                else { kiemtra = true; count = count + 1; }
                if (giatri.NgayKiemKe != sosanh.NgayKiemKe)
                { kiemtra = false; makNgaychungtu.Text = sosanh.NgayKiemKe.ToString(); }
                else { kiemtra = true; count = count + 1; }
                if (giatri.MaKho != sosanh.MaKho)
                { kiemtra = false; cbxKhoban.SelectedValue = sosanh.MaKho; }
                else { kiemtra = true; count = count + 1; }
                if (giatri.GhiChu != sosanh.GhiChu)
                { kiemtra = false; txtDiengiai.Text = sosanh.GhiChu; }
                else { kiemtra = true; count = count + 1; }
                if (giatri.Deleted != sosanh.Deleted)
                { kiemtra = false; }
                else { kiemtra = true; count = count + 1; }
                if (count < 6)
                { kiemtra = false; }
                else
                { kiemtra = true; }
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return kiemtra;
        }
        private void toolStripStatus_Ghilai_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInsertOrder.RowCount > 0)
                {
                    Entities.KiemKeKho sosanh = ConfilickData("KiemKeKho", txtSochungtu.Text.ToUpper());
                    if (checkConflictUpdate(kk, sosanh) == true)
                    {
                        if (this.hanhdong == "Update")
                        {
                            frmQuanLyKiemKeKho.BaoDong = "A";
                            XuLy_KiemKeKho("Update");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu đã thay đổi hãy kiểm tra lại trước khi sửa");
                    }
                }
                else
                { MessageBox.Show("Không có hàng hóa trong đơn"); }
            }
            catch (Exception ex)
            { string s = ex.Message; }

        }
        /// <summary>
        /// hungvv =======================lay du lieu moi checkfix===========================
        /// </summary>
        private Entities.KiemKeKho ConfilickData(string table, string values)
        {
            Entities.KiemKeKho ddh = new Entities.KiemKeKho();
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TruyenGiaTri gitri = new Entities.TruyenGiaTri("Select", table, values);
                clientstrem = cl.SerializeObj(this.client, "CheckKiemKeKho", gitri);
                ddh = (Entities.KiemKeKho)cl.DeserializeHepper(clientstrem, ddh);
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                ddh = null;
            }
            return ddh;
        }


        /// <summary>
        /// add ban ghi --------------------------------hungvv-----------------------------
        /// </summary>
        /// <param name="dgv"></param>
        public Entities.ChiTietKiemKeKho[] LuuThongTinChiTietKiemKeKho(DataGridView dgv, string hanhdong, string makiemke, string ghichu)
        {
            Entities.ChiTietKiemKeKho[] mangBanghi = null;
            try
            {
                string maKho = cbxKhoban.SelectedValue.ToString().ToUpper();
                ArrayList arr = new ArrayList();
                int i = dgv.RowCount;
                if (i > 0)
                {
                    for (int x = 0; x < i; x++)
                    {
                        Entities.ChiTietKiemKeKho layra = new Entities.ChiTietKiemKeKho();
                        layra.MaKho = maKho.Trim().ToUpper();
                        layra.Hanhdong = hanhdong.ToString();
                        layra.MaPhieuKiemKe = makiemke.ToString();
                        layra.MaHangHoa = dgv.Rows[x].Cells[0].Value.ToString().ToUpper();
                        layra.TonSoSach = dgv.Rows[x].Cells[2].Value.ToString();
                        layra.TonThucTe = dgv.Rows[x].Cells[3].Value.ToString();
                        layra.LyDo = dgv.Rows[x].Cells[5].Value.ToString();
                        layra.GhiChu = "" + ghichu;
                        layra.Deleted = false;
                        arr.Add(layra);
                    }
                    int n = arr.Count;
                    if (n == 0) { mangBanghi = null; }
                    mangBanghi = new Entities.ChiTietKiemKeKho[n];
                    for (int j = 0; j < n; j++)
                    {
                        mangBanghi[j] = (Entities.ChiTietKiemKeKho)arr[j];
                    }
                }
                else
                {
                    mangBanghi = null;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; mangBanghi = null; }
            return mangBanghi;
        }

        /// <summary>
        /// luu chi tiet don hang
        /// </summary>
        private void LuuChiTietKiemKeKho(string hangDong)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.ChiTietKiemKeKho[] luu = LuuThongTinChiTietKiemKeKho(dgvInsertOrder, hangDong, txtSochungtu.Text, txtDiengiai.Text);
                if (hangDong.Equals("Update"))
                {
                    // Cap nhat trang thai(isChange) cho ChiTietKiemKeKho 
                    luu = GetChange(luu, this.ctTemp);
                }

                clientstrem = cl.SerializeHepper(this.client, "ThemchiTietKiemKeKho", luu);
                int bao = 0;
                bao = (int)cl.DeserializeHepper(clientstrem, bao);

                if (bao >= 1)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Chưa thêm hàng hóa vào đơn này");
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// GetChange
        /// </summary>
        /// <param name="news"></param>
        /// <param name="old"></param>
        /// <returns></returns>
        private Entities.ChiTietKiemKeKho[] GetChange(Entities.ChiTietKiemKeKho[] news, Entities.ThongTinKiemKeKho[] old)
        {
            Entities.ChiTietKiemKeKho[] retVal = null;
            try
            {
                List<Entities.ChiTietKiemKeKho> listTemp = new List<Entities.ChiTietKiemKeKho>();
                foreach (Entities.ChiTietKiemKeKho item in news)
                {
                    foreach (Entities.ThongTinKiemKeKho item1 in old)
                    {
                        bool a = item.MaHangHoa.Trim().ToUpper().Equals(item1.Mahang.Trim().ToUpper());
                        bool b = !item.TonSoSach.Equals(item1.Tonsosach);
                        bool c = !item.TonThucTe.Equals(item1.Tonthucte);

                        if ((b || c) && a)
                        {
                            item.IsChange = true;
                            break;
                        }
                    }
                }
                //
                retVal = news;
            }
            catch
            {
                retVal = null;
            }

            return retVal;
        }


        /// <summary>
        /// them moi, sua thong tin don dat hang
        /// </summary>
        /// <param name="hanhdong"></param>
        private int ID = 0;
        private void XuLy_KiemKeKho(string hanhdong)
        {
            try
            {
                Entities.KiemKeKho don = new Entities.KiemKeKho();
                string thoigian_1 = null;
                thoigian_1 = new Common.Utilities().MyDateConversion(makNgaychungtu.Text);
                if (thoigian_1 != null)
                {
                    don.NgayKiemKe = DateTime.Parse(thoigian_1);
                    thoigian_1 = null;
                    don.Hanhdong = hanhdong;
                    don.PhieuKiemKeKhoID = ID;
                    don.MaKiemKe = txtSochungtu.Text.ToUpper();
                    don.MaKho = cbxKhoban.SelectedValue.ToString().ToUpper();
                    don.GhiChu = txtDiengiai.Text;
                    don.Deleted = false;
                    don.Manhanvien = Common.Utilities.User.NhanVienID;
                    don.Tendangnhap = Common.Utilities.User.TenDangNhap;
                    if (dgvInsertOrder.RowCount > 0)
                    {
                        if (CheckData(don) == true)
                        {
                            cl = new Server_Client.Client();
                            this.client = cl.Connect(Luu.IP, Luu.Ports);
                            clientstrem = cl.SerializeObj(this.client, "KiemKeKho", don);
                            Entities.KiemKeKho tralai = new Entities.KiemKeKho();
                            int trave = System.Convert.ToInt32(cl.DeserializeHepper(clientstrem, tralai));
                            if (trave == 1)
                            {
                                LuuChiTietKiemKeKho(hanhdong);
                            }
                            else
                            {
                                MessageBox.Show("Thất bại");
                            }
                        }
                        else
                        { }
                    }
                    else
                    { MessageBox.Show("Không có hàng hóa trong đơn kiểm kê"); }
                }
                else
                { MessageBox.Show("Kiểm tra ngày"); }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                MessageBox.Show("Thông tin nhập không đúng");
            }
        }

        /// <summary>
        /// hungvv kiem tra dinh dang khi them moi hoa don
        /// </summary>
        /// <param name="maDonDatHang"></param>
        private Boolean CheckData(Entities.KiemKeKho dat)
        {
            Boolean kt = false;
            try
            {
                if (dat.MaKho.Length <= 0)
                {
                    cbxKhoban.Focus();
                    System.Windows.Forms.MessageBox.Show("Hãy nhập mã kho");
                    kt = false;
                }
                else
                {
                    if (dat.MaKiemKe.Length <= 0)
                    {
                        txtSochungtu.Focus();
                        MessageBox.Show("Hãy nhập mã kiểm kê");
                        kt = false;
                    }
                    else
                    {
                        kt = true;
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return kt;
        }

        private void toolStripStatus_Themmoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInsertOrder.RowCount > 0)
                {
                    if (hanhdong == "Insert")
                    {
                        getID("KiemKeKho");
                        if (makiemke == txtSochungtu.Text)
                        {
                            frmQuanLyKiemKeKho.BaoDong = "";
                            XuLy_KiemKeKho("Insert");
                        }
                        else
                        { MessageBox.Show("Mã kiểm kê đã thay đổi hãy kiểm tra lại"); txtSochungtu.Text = makiemke; }
                    }
                }
                else
                { MessageBox.Show("Không có hàng hóa trong đơn"); }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// hungvv =======================giao tiep voi server===========================
        /// </summary>
        private void fixDatagridview()
        {
            try
            {
                dgvInsertOrder.RowHeadersVisible = false;
                dgvInsertOrder.Columns[0].HeaderText = "Mã hàng";
                dgvInsertOrder.Columns[1].HeaderText = "Tên hàng";
                dgvInsertOrder.Columns[2].HeaderText = "Tồn sổ sách";
                dgvInsertOrder.Columns[3].HeaderText = "Tồn thực tế";
                dgvInsertOrder.Columns[4].HeaderText = "Chênh lệch";
                dgvInsertOrder.Columns[5].HeaderText = "Lý do điều chỉnh";
                dgvInsertOrder.Columns[6].HeaderText = "Giá vốn";
                dgvInsertOrder.Columns[7].HeaderText = "Giá chênh lệch";
                dgvInsertOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvInsertOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// chi tiet kiem ke
        /// </summary>
        /// <param name="MaKiemKe"></param>
        private void SelectData(string MaKiemKe)
        {
            try
            {
                Entities.ChiTietKiemKeKho ctkk = new Entities.ChiTietKiemKeKho();
                dgvInsertOrder.DataSource = null;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                ctkk = new Entities.ChiTietKiemKeKho("Select", MaKiemKe);
                clientstrem = cl.SerializeObj(this.client, "ChiTietKiemKeKho", ctkk);
                Entities.ChiTietKiemKeKho[] ddh = null;
                ddh = (Entities.ChiTietKiemKeKho[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length > 0)
                {
                    dgvInsertOrder.DataSource = ddh;
                }
                else
                {
                    Entities.ChiTietKiemKeKho[] lay = new Entities.ChiTietKiemKeKho[0];
                    dgvInsertOrder.DataSource = lay;
                }
                fixDatagridview();
            }
            catch (Exception ex)
            {
                string s = ex.Message; Entities.ChiTietKiemKeKho[] lay = new Entities.ChiTietKiemKeKho[0];
                dgvInsertOrder.DataSource = lay; fixDatagridview();
            }
        }
        /// <summary>
        /// chi tiet kiem ke
        /// </summary>
        /// <param name="MaKiemKe"></param>
        private void LayKiemKeKhoTheoMaKiemKe(string MaKiemKe)
        {
            try
            {
                Entities.TruyenGiaTri truyen = new Entities.TruyenGiaTri();
                dgvInsertOrder.DataSource = null;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                truyen = new Entities.TruyenGiaTri("Select", MaKiemKe);
                clientstrem = cl.SerializeObj(this.client, "LayKiemKeKhoTheoMaKiemKe", truyen);
                Entities.ThongTinKiemKeKho[] ddh = null;
                ddh = (Entities.ThongTinKiemKeKho[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length > 0)
                {
                    dgvInsertOrder.DataSource = ddh;
                    this.ctTemp = ddh;
                }
                else
                {
                    Entities.ThongTinKiemKeKho[] lay = new Entities.ThongTinKiemKeKho[0];
                    dgvInsertOrder.DataSource = lay;
                }
                fixDatagridview();
            }
            catch (Exception ex)
            {
                string s = ex.Message; Entities.ThongTinKiemKeKho[] lay = new Entities.ThongTinKiemKeKho[0];
                dgvInsertOrder.DataSource = lay; fixDatagridview();
            }
        }
        /// <summary>
        /// hungvv =================do du lieu vao txt===========================
        /// </summary>
        /// <param name="dat"></param>
        private void DoDuLieu(Entities.KiemKeKho dat)
        {
            try
            {
                Common.Utilities com = new Common.Utilities();
                ID = dat.PhieuKiemKeKhoID;
                txtSochungtu.Text = dat.MaKiemKe;
                makNgaychungtu.Text = new Common.Utilities().XuLy(2, dat.NgayKiemKe.ToString());
                GiaTriCanLuu.Ma = dat.MaKho;
                cbxKhoban.SelectedValue = dat.MaKho;
                txtDiengiai.Text = dat.GhiChu;
                LayKiemKeKhoTheoMaKiemKe(dat.MaKiemKe);
                if (dgvInsertOrder.Rows.Count > 0)
                { txtTienhang.Text = new Common.Utilities().FormatMoney(tinhtong()); }
                else
                { txtTienhang.Text = "0"; }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        Entities.QuyDoiDonViTinh[] quidoidvt;
        private void frmXuLy_KiemKeKho_Load(object sender, EventArgs e)
        {
            try
            {
                //
                Entities.CheckRefer ctxh;
                Entities.ThongTinKiemKeKho[] lay = new Entities.ThongTinKiemKeKho[0];
                dgvInsertOrder.DataSource = lay;
                fixDatagridview();
                string ngay = DateServer.Date().ToString("dd/MM/yyyy");
                makNgaychungtu.Text = ngay;
                LayKhoHang();
                if (hanhdong == "Insert")
                {
                    toolStripStatus_Ghilai.Enabled = false;
                    getID("KiemKeKho");
                    txtSochungtu.Text = makiemke;
                    btnPDF.Enabled = false;

                    // quy đổi đơn vị tính
                    cl = new Server_Client.Client();
                    this.client = cl.Connect(Luu.IP, Luu.Ports);
                    ctxh = new Entities.CheckRefer("QD");
                    clientstrem = cl.SerializeObj(this.client, "Select", ctxh);
                    quidoidvt = new Entities.QuyDoiDonViTinh[0];
                    quidoidvt = (Entities.QuyDoiDonViTinh[])cl.DeserializeHepper1(clientstrem, quidoidvt);
                    if (quidoidvt == null)
                    {
                        quidoidvt = new Entities.QuyDoiDonViTinh[0];
                        return;
                    }
                }
                if (hanhdong == "Update")
                {
                    toolStripStatus_Themmoi.Enabled = false;
                    DoDuLieu(this.kk);
                    if (txtSochungtu.Text.Length <= 0)
                    { MessageBox.Show("Không tìm thấy mã kiểm kê cần sửa"); this.Close(); }
                    btnPDF.Enabled = true;

                    // quy đổi đơn vị tính
                    cl = new Server_Client.Client();
                    this.client = cl.Connect(Luu.IP, Luu.Ports);
                    ctxh = new Entities.CheckRefer("QD");
                    clientstrem = cl.SerializeObj(this.client, "Select", ctxh);
                    quidoidvt = new Entities.QuyDoiDonViTinh[0];
                    quidoidvt = (Entities.QuyDoiDonViTinh[])cl.DeserializeHepper1(clientstrem, quidoidvt);
                    if (quidoidvt == null)
                    {
                        quidoidvt = new Entities.QuyDoiDonViTinh[0];
                        return;
                    }
                }

                // Lay Hang hoa hoa trong kho
                string maKho = cbxKhoban.SelectedValue.ToString().ToUpper();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TruyenGiaTri dh = new Entities.TruyenGiaTri("Select", maKho);
                clientstrem = cl.SerializeObj(this.client, "LayBang_HangHoaTheoMaKhoHang", dh);
                hangHoaTrongKho = new Entities.ThongTinDatHang[1];
                hangHoaTrongKho = (Entities.ThongTinDatHang[])cl.DeserializeHepper(clientstrem, hangHoaTrongKho);
            }
            catch (Exception ex)
            {
                string s = ex.Message; if (txtSochungtu.Text == "")
                { txtSochungtu.Text = "KK_0001"; }
            }
        }

        /// <summary>
        /// do du lieu vao txt
        /// </summary>
        private void BindHangHoa()
        {
            try
            {
                if (GiaTriCanLuu.Loaitrave == "KiemKeKho_HangHoa")
                {
                    mahanghoa = toolStrip_txtTracuu.Text = GiaTriCanLuu.Ma;
                    toolStrip_txtTenhang.Text = GiaTriCanLuu.Ten;
                    toolStrip_txtTonThucTe.Focus();
                    toolStrip_txtTonThucTe.SelectAll();
                    toolStrip_txtTonThucTe.Text = string.Empty;
                    toolStrip_txtTonkho.Text = int.Parse(GiaTriCanLuu.Giatri2).ToString();
                    toolStrip_txtLyDo.Text = "Lý do khác";
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private bool testCharacter(string chuoi)
        {
            bool check = false;
            try
            {
                if (chuoi != "")
                {
                    bool kt = false;
                    foreach (char ch in chuoi)
                    {
                        char[] a = new char[]
                    {'+','-','~','`','@','#','$','%','^','&','*','(',')','{','}','[',']',':',';','|',
                        '<','>',',','.','?','/','-','=',
                        'ă','â','á','à','ả','ạ','ã','ắ','ằ','ẳ','ẵ','ặ','ấ','ầ','ẩ','ậ','ẫ',
                        'Ă','Â','Á','À','Ả','Ạ','Ã','Ắ','Ằ','Ẳ','Ẵ','Ặ','Ấ','Ầ','Ẩ','Ẫ','Ậ',
                        'ê','é','è','ẻ','ẽ','ẹ','ế','ề','ể','ễ','ệ',
                        'Ê','É','È','Ẻ','Ẽ','Ẹ','Ế','Ề','Ể','Ễ','Ệ',
                        'ô','ơ','ó', 'ò', 'ỏ', 'ọ', 'õ','ố', 'ồ','ổ', 'ộ','ỗ','ớ','ờ','ở','ợ','ỡ',
                        'Ô','o','Ó', 'Ò', 'Ỏ', 'Õ', 'Ọ','Ố', 'Ồ','Ổ', 'Ộ','Ỗ','Ớ','Ờ','Ở','Ợ','Ỡ',
                        'ư','ú','ù','ủ','ụ','ũ', 'ứ','ừ', 'ử', 'ự', 'ữ',
                        'Ư','Ú','Ù','Ủ','Ụ','Ũ', 'Ứ','Ừ', 'Ử', 'Ự', 'Ữ',
                        'í','ì','ỉ','ị','ĩ',
                        'Í','Ì','Ỉ','Ị','Ĩ',
                        'đ','Đ'
                    };
                        foreach (char c in a)
                        {
                            if (c.Equals(ch))
                                kt = true;
                            break;
                        }
                        if (kt == true)
                        {
                            MessageBox.Show("Mã Hàng Hóa Không được nhập tiếng việt có dấu " +
                                          "\nNếu bạn đang dùng máy quét mã vạch hãy tắt bộ gõ Tiếng Tiệt đi! ", "Hệ Thống Cảnh Báo");
                            toolStrip_txtTracuu.Focus();
                            toolStrip_txtTracuu.SelectAll();
                            check = false;
                            break;
                        }
                        else
                        { check = true; }
                    }
                }
                else
                { check = true; }
            }
            catch (Exception ex)
            { string s = ex.Message; check = false; }
            return check;
        }
        private void toolStrip_txtTracuu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (cbxKhoban.SelectedValue.ToString() != null)
                {
                    if (testCharacter(toolStrip_txtTracuu.Text) == false)
                    {
                        return;
                    }
                    // F4
                    if (e.KeyCode == Keys.F4)
                    {
                        if (cbxKhoban.Text != "")
                        {
                            GiaTriCanLuu.Loaitrave = null;
                            GiaTriCanLuu.Ma = null;
                            GiaTriCanLuu.Ten = null;
                            GiaTriCanLuu.TonKho = null;
                            frmTraCuu fr = new frmTraCuu("KiemKeKho_HangHoa", "KiemKeHangHoa", cbxKhoban.SelectedValue.ToString());
                            fr.ShowDialog();
                            BindHangHoa();
                        }
                        else
                        { MessageBox.Show("Chọn kho hàng"); }
                    }
                    // Enter
                    if (e.KeyCode == Keys.Enter)
                    {
                        GiaTriCanLuu.Loaitrave = null;
                        GiaTriCanLuu.Ma = null;
                        GiaTriCanLuu.Ten = null;
                        GiaTriCanLuu.TonKho = null;
                        // lay thong tin san pham 
                        string maHangHoa = toolStrip_txtTracuu.Text;
                        // Check quy doi
                        bool isQuyDoi = false;
                        foreach (Entities.QuyDoiDonViTinh item in quidoidvt)
                        {
                            if (item.MaHangQuyDoi.Trim().ToUpper().Equals(maHangHoa.Trim().ToUpper()))
                            {
                                GiaTriCanLuu.Ma = item.MaHangDuocQuyDoi.Trim().ToUpper();
                                isQuyDoi = true;
                                break;
                            }
                        }
                        //
                        if (!isQuyDoi)
                            GiaTriCanLuu.Ma = toolStrip_txtTracuu.Text.Trim().ToUpper();

                        foreach (Entities.ThongTinDatHang item in hangHoaTrongKho)
                        {
                            if (GiaTriCanLuu.Ma.Trim().ToUpper().Equals(item.MaHangHoa.Trim().ToUpper()))
                            {
                                GiaTriCanLuu.Ten = item.TenHangHoa;
                                GiaTriCanLuu.Giatri2 = item.Tonkho;
                                GiaTriCanLuu.Giatri = item.GiaNhap;
                                break;
                            }
                        }

                        GiaTriCanLuu.Loaitrave = "KiemKeKho_HangHoa";
                        BindHangHoa();
                    }
                }
                else
                {
                    MessageBox.Show("Phải nhập kho hàng");
                }
            }
            catch
            {
            }
        }

        #region hungvv================================================================================
        /// <summary>
        /// hungvv them moi row ==============================================================================
        /// </summary>
        private void LayGiaTri(DataGridView dgv, Entities.ThongTinKiemKeKho themmoi)
        {
            try
            {
                ArrayList arr = new ArrayList();
                Entities.ThongTinKiemKeKho[] list = null;
                if (dgv.RowCount > 0)
                {
                    int count = dgv.RowCount;
                    list = new Entities.ThongTinKiemKeKho[count];
                    Boolean check = false;
                    for (int i = 0; i < count; i++)
                    {
                        Entities.ThongTinKiemKeKho row = new Entities.ThongTinKiemKeKho();
                        row.Mahang = dgv.Rows[i].Cells[0].Value.ToString();
                        row.Tenhang = dgv.Rows[i].Cells[1].Value.ToString();
                        string thucte = "0";
                        string chenh = "0";
                        string giachenh = "0";
                        if (dgv.Rows[i].Cells[0].Value.ToString() == themmoi.Mahang)
                        {
                            check = true;
                            thucte = (Double.Parse(dgv.Rows[i].Cells[3].Value.ToString()) + Double.Parse(themmoi.Tonthucte)).ToString();
                            chenh = (Double.Parse(dgv.Rows[i].Cells[2].Value.ToString()) - Double.Parse(thucte)).ToString();
                            giachenh = new Common.Utilities().FormatMoney(Double.Parse(chenh) * Double.Parse(dgv.Rows[i].Cells[6].Value.ToString())).ToString();
                        }
                        else
                        {
                            thucte = Double.Parse(dgv.Rows[i].Cells[3].Value.ToString()).ToString();
                            chenh = dgv.Rows[i].Cells[4].Value.ToString();
                            giachenh = new Common.Utilities().FormatMoney(Double.Parse(dgv.Rows[i].Cells[7].Value.ToString())).ToString();
                        }
                        row.Tonsosach = dgv.Rows[i].Cells[2].Value.ToString();
                        row.Tonthucte = thucte;
                        row.Chenhlech = chenh.ToString();
                        row.Lydo = dgv.Rows[i].Cells[5].Value.ToString();
                        row.Giavon = new Common.Utilities().FormatMoney(Double.Parse(dgv.Rows[i].Cells[6].Value.ToString())).ToString();
                        row.Giachechlech = giachenh.ToString();
                        arr.Add(row);
                    }

                    if (check == false)
                    {
                        Entities.ThongTinKiemKeKho row = new Entities.ThongTinKiemKeKho();
                        row.Mahang = themmoi.Mahang;
                        row.Tenhang = themmoi.Tenhang;
                        row.Tonsosach = themmoi.Tonsosach;
                        row.Tonthucte = themmoi.Tonthucte;
                        row.Chenhlech = themmoi.Chenhlech;
                        row.Lydo = themmoi.Lydo;
                        row.Giavon = themmoi.Giavon;
                        row.Giachechlech = themmoi.Giachechlech;
                        arr.Add(row);
                    }
                }
                else
                {
                    list = new Entities.ThongTinKiemKeKho[1];
                    Entities.ThongTinKiemKeKho row = new Entities.ThongTinKiemKeKho();
                    row.Mahang = themmoi.Mahang;
                    row.Tenhang = themmoi.Tenhang;
                    row.Tonsosach = themmoi.Tonsosach;
                    row.Tonthucte = themmoi.Tonthucte;
                    row.Chenhlech = themmoi.Chenhlech;
                    row.Lydo = themmoi.Lydo;
                    row.Giavon = themmoi.Giavon;
                    row.Giachechlech = themmoi.Giachechlech;
                    arr.Add(row);
                }
                int n = arr.Count;
                if (n == 0) { list = null; }
                list = new Entities.ThongTinKiemKeKho[n];
                for (int i = 0; i < n; i++)
                {
                    list[i] = (Entities.ThongTinKiemKeKho)arr[i];
                }
                dgv.DataSource = null;
                dgv.DataSource = list;
                fixDatagridview();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.ThongTinKiemKeKho[] lay = new Entities.ThongTinKiemKeKho[0]; dgv.DataSource = null;
                dgv.DataSource = lay; fixDatagridview();
            }
        }

        /// <summary>
        /// hungvv --------------------kiem tra ma hang------------------
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string KiemTraMa(string ID)
        {
            string kt = null;
            try
            {
                Entities.KiemTraChung ktm = new Entities.KiemTraChung();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                ktm = new Entities.KiemTraChung("Select", ID);
                clientstrem = cl.SerializeObj(this.client, "KiemTraMa", ktm);
                Entities.KiemTraChung tra = new Entities.KiemTraChung();
                tra = (Entities.KiemTraChung)cl.DeserializeHepper(clientstrem, tra);
                kt = tra.Hanhdong;
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return kt;
        }

        /// hungvv --------------------kiem tra ma hang khi them chi tiet hang------------------
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string KiemTraMa(Entities.ThongTinKiemKeKho lay)
        {
            string kt = null;
            try
            {
                Entities.KiemTraChung ktm = new Entities.KiemTraChung();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                ktm = new Entities.KiemTraChung("Select", lay.Mahang, lay.Tenhang);
                clientstrem = cl.SerializeObj(this.client, "KiemTraMa", ktm);
                Entities.KiemTraChung tra = new Entities.KiemTraChung();
                tra = (Entities.KiemTraChung)cl.DeserializeHepper(clientstrem, tra);
                if (tra.Hanhdong.Length > 0)
                {
                    kt = tra.Hanhdong;
                }
                else
                { kt = null; }
            }
            catch (Exception ex)
            { string s = ex.Message; }
            return kt;
        }
        /// <summary>
        /// them hang moi
        /// </summary>
        private void NewRow()
        {
            Entities.ThongTinKiemKeKho chitiet = new Entities.ThongTinKiemKeKho();
            try
            {
                if (cbxKhoban.SelectedValue.ToString() != "")
                {
                    chitiet.Mahang = toolStrip_txtTracuu.Text.ToUpper();
                    string thongbao = toolStrip_txtTenhang.Text; //KiemTraMa(chitiet);
                    chitiet.Tenhang = toolStrip_txtTenhang.Text;
                    chitiet.Tonsosach = toolStrip_txtTonkho.Text;
                    Double thucte = Double.Parse(toolStrip_txtTonThucTe.Text);
                    chitiet.Tonthucte = thucte.ToString();

                    // lay gia von 
                    var query = from item in giaVon
                                let a = item.MaKho.Trim().ToUpper().Equals(cbxKhoban.SelectedValue.ToString())
                                let b = item.MaHangHoa.Trim().ToUpper().Equals(toolStrip_txtTracuu.Text.Trim().ToUpper())
                                where a && b
                                select item;

                    Entities.GiaVon[] result = query.ToArray();
                    Entities.GiaVon gv = null;

                    if (result != null && result.Length > 0)
                        gv = result[0];

                    double von = double.Parse(gv.Gia.ToString());

                    if (thucte == 0)
                    {
                        chitiet.Chenhlech = toolStrip_txtTonkho.Text;
                        chitiet.Giavon = new Common.Utilities().FormatMoney(von);
                        chitiet.Giachechlech = new Common.Utilities().FormatMoney(von);
                    }
                    else
                    {
                        chitiet.Chenhlech = Math.Abs(thucte - Double.Parse(new Common.Utilities().KhongDau(toolStrip_txtTonkho.Text))).ToString();
                        chitiet.Giavon = new Common.Utilities().FormatMoney(von);
                        chitiet.Giachechlech = new Common.Utilities().FormatMoney(von * Math.Abs(thucte - Double.Parse(new Common.Utilities().KhongDau(toolStrip_txtTonkho.Text)))).ToString();
                    }
                    chitiet.Lydo = toolStrip_txtLyDo.Text;
                    if (thongbao == "NO")
                    {
                        MessageBox.Show("Mã hàng không đúng");
                        toolStrip_txtTracuu.Focus();
                        return;
                    }
                    else
                    {
                        if (chitiet.Tenhang.Length > 0)
                        {
                            LayGiaTri(dgvInsertOrder, chitiet);
                            ResetTool();
                        }
                        else
                        { MessageBox.Show("Phải nhập hàng hóa mới có thể thêm"); }
                    }
                }
                else
                {
                    ResetTool();
                    MessageBox.Show("Chọn kho hàng");
                    return;
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                Entities.ThongTinKiemKeKho[] lay = new Entities.ThongTinKiemKeKho[0]; dgvInsertOrder.DataSource = null;
                dgvInsertOrder.DataSource = lay; fixDatagridview();
            }
        }
        /// <summary>
        /// reset form
        /// </summary>
        private void ResetTool()
        {
            try
            {
                toolStrip_txtTracuu.Text = "<F4 - Tra cứu>";
                toolStrip_txtTenhang.Text = "";
                toolStrip_txtLyDo.Text = "Chưa có lý do";
                toolStrip_txtTonkho.Text = "0";
                toolStrip_txtTonThucTe.Text = "0";
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// tu tang ID
        /// </summary>
        private string makiemke;
        private void getID(string table)
        {
            try
            {
                Entities.LayID top = new Entities.LayID();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                top = new Entities.LayID("Select", table);
                clientstrem = cl.SerializeObj(this.client, "LayID", top);
                Entities.LayID ddh = new Entities.LayID();
                ddh = (Entities.LayID)cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.ID.Length > 0)
                {
                    Common.Utilities com = new Common.Utilities();
                    makiemke = com.ProcessID(ddh.ID.ToString());
                }
                else
                { makiemke = "KK_0001"; }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                makiemke = "KK_0001";
            }
        }
        #endregion
        private Double tinhtong()
        {
            Double tralai = 0;
            try
            {
                for (int i = 0; i < dgvInsertOrder.RowCount; i++)
                {
                    tralai = Math.Round(Double.Parse(new Common.Utilities().KhongDau(dgvInsertOrder.Rows[i].Cells[7].Value.ToString())) + tralai);
                }
            }
            catch (Exception ex)
            { string s = ex.Message; tralai = 0; }
            return tralai;
        }
        string mahanghoa;

        /// <summary>
        /// Validate
        /// </summary>
        /// <returns></returns>
        public bool Validate1()
        {
            bool retVal = true;
            try
            {
                if (string.IsNullOrEmpty(this.toolStrip_txtTonThucTe.Text))
                {
                    MessageBox.Show("Số lượng tồn thực tế không được để trống, xin kiểm tra lại", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                    this.toolStrip_txtTonThucTe.Focus();
                    this.toolStrip_txtTonThucTe.SelectAll();
                    return false;
                }

                try
                {
                    double slTT = double.Parse(this.toolStrip_txtTonThucTe.Text);
                }
                catch
                {
                    MessageBox.Show("Số lượng tồn thực tế nhập sai định dạng, xin kiểm tra lại", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                    this.toolStrip_txtTonThucTe.Focus();
                    this.toolStrip_txtTonThucTe.SelectAll();
                    return false;
                }
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }

        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (!Validate1())
                    return;
                // Qui đổi đơn vị tính
                foreach (Entities.QuyDoiDonViTinh item in quidoidvt)
                {
                    if (item.MaHangQuyDoi == mahanghoa)
                    {
                        mahanghoa = toolStrip_txtTracuu.Text = item.MaHangDuocQuyDoi.ToUpper();
                        toolStrip_txtTenhang.Text = item.TenHangDuocQuyDoi;
                        toolStrip_txtTonThucTe.Text = (double.Parse(item.SoLuongDuocQuyDoi.ToString()) * double.Parse(toolStrip_txtTonThucTe.Text)).ToString();
                        break;

                    }
                }
                NewRow();
                if (dgvInsertOrder.Rows.Count > 0)
                { txtTienhang.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(tinhtong().ToString()))); }
                else
                { txtTienhang.Text = "0"; }

                // Forcus
                toolStrip_txtTracuu.Focus();
                toolStrip_txtTracuu.Text = string.Empty;
            }
            catch (Exception ex)
            {
                string s = ex.Message; Entities.ThongTinKiemKeKho[] lay = new Entities.ThongTinKiemKeKho[0]; dgvInsertOrder.DataSource = null;
                dgvInsertOrder.DataSource = lay; fixDatagridview();
            }
        }

        private void toolStrip_txtTonThucTe_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            //{
            //    e.Handled = true;
            //}
        }
        private int i;
        private void dgvInsertOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                i = e.RowIndex;
                if (i >= 0)
                    dgvInsertOrder.Rows[i].Selected = true;
                else
                    i = -1;
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        /// <summary>
        /// xoa hang hoa
        /// </summary>
        /// <param name="dgv"></param>
        private void getDataTable(DataGridView dgv)
        {
            try
            {
                ArrayList arr = new ArrayList();
                Entities.ThongTinDatHang result;
                Entities.ThongTinKiemKeKho[] list = null;
                if (dgv.RowCount > 0 && i >= 0)
                {
                    mahanghoa = toolStrip_txtTracuu.Text = dgv[0, i].Value.ToString();
                    toolStrip_txtTenhang.Text = dgv[1, i].Value.ToString();

                    var query = from item in hangHoaTrongKho
                                where item.MaHangHoa.Trim().ToUpper().Equals(mahanghoa.Trim().ToUpper())
                                select item;

                    result = query.ToArray()[0];
                    toolStrip_txtTonkho.Text = result.Tonkho; //int.Parse(new Common.Utilities().KhongDau(dgv[2, i].Value.ToString())).ToString();
                    toolStrip_txtTonThucTe.Text = int.Parse(new Common.Utilities().KhongDau(dgv[3, i].Value.ToString())).ToString();
                    toolStrip_txtLyDo.Text = dgv[5, i].Value.ToString();
                    for (int j = 0; j < dgv.RowCount; j++)
                    {
                        if (dgv[0, j].Value.ToString() != dgv[0, i].Value.ToString())
                        {
                            Entities.ThongTinKiemKeKho row = new Entities.ThongTinKiemKeKho();
                            row.Mahang = dgv.Rows[j].Cells[0].Value.ToString();
                            row.Tenhang = "" + dgv.Rows[j].Cells[1].Value.ToString();
                            row.Tonsosach = new Common.Utilities().KhongDau(dgv.Rows[j].Cells[2].Value.ToString());
                            row.Tonthucte = new Common.Utilities().KhongDau(dgv.Rows[j].Cells[3].Value.ToString());
                            row.Chenhlech = Double.Parse(new Common.Utilities().KhongDau(dgv.Rows[j].Cells[4].Value.ToString())).ToString();
                            row.Lydo = dgv.Rows[j].Cells[5].Value.ToString();
                            row.Giavon = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(dgv.Rows[j].Cells[6].Value.ToString())));
                            row.Giachechlech = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(dgv.Rows[j].Cells[7].Value.ToString())));
                            arr.Add(row);
                        }
                    }
                    int n = arr.Count;
                    if (n == 0) { arr = null; }
                    list = new Entities.ThongTinKiemKeKho[n];
                    for (int x = 0; x < n; x++)
                    {
                        list[x] = (Entities.ThongTinKiemKeKho)arr[x];
                    }
                    dgv.DataSource = list;
                }
                else
                {
                    list = new Entities.ThongTinKiemKeKho[0];
                    arr = null;
                    dgv.DataSource = list;
                }
                fixDatagridview();
            }
            catch (Exception ex)
            { string s = ex.Message; Entities.ThongTinKiemKeKho[] a = new Entities.ThongTinKiemKeKho[0]; dgv.DataSource = a; fixDatagridview(); }
        }

        private void dgvInsertOrder_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvInsertOrder.RowCount > 0)
                {
                    getDataTable(dgvInsertOrder);
                    if (dgvInsertOrder.RowCount > 0)
                    { txtTienhang.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(tinhtong().ToString()))); }
                    else
                    { txtTienhang.Text = "0"; }
                }
                else
                { }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
        }

        private void toolStrip_txtTonThucTe_MouseHover(object sender, EventArgs e)
        {
            if (toolStrip_txtTonThucTe.Text == "1" || toolStrip_txtTonThucTe.Text == "0")
            {
                toolStrip_txtTonThucTe.Text = "";
            }
        }

        private void toolStrip_txtTonThucTe_MouseLeave(object sender, EventArgs e)
        {
            if (toolStrip_txtTonThucTe.Text == "")
            {
                toolStrip_txtTonThucTe.Text = "1";
            }
        }

        private void toolStrip_txtTracuu_MouseHover(object sender, EventArgs e)
        {
            if (toolStrip_txtTracuu.Text == "<F4 - Tra cứu>")
            { toolStrip_txtTracuu.Text = ""; }
        }

        private void toolStrip_txtTracuu_MouseLeave(object sender, EventArgs e)
        {
            if (toolStrip_txtTracuu.Text == "")
            { toolStrip_txtTracuu.Text = "<F4 - Tra cứu>"; }
        }

        private void cbxKhoban_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.hanhdong.Equals("Update"))
                    return;

                if (dgvInsertOrder.Rows.Count > 0)
                {
                    dgvInsertOrder.DataSource = null;
                    Entities.ThongTinKiemKeKho[] lay = new Entities.ThongTinKiemKeKho[0];
                    dgvInsertOrder.DataSource = lay;
                    fixDatagridview();
                }
                toolStrip_txtTracuu.Text = "<F4 - Tra cứu>";
                toolStrip_txtTenhang.Text = "";
                toolStrip_txtTonkho.Text = "0";
                toolStrip_txtTonThucTe.Text = "1";
                toolStrip_txtLyDo.Text = "Chưa có lý do";
                txtTienhang.Text = "0";
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }


        private void InThongTinKiemKe()
        {
            try
            {
                Entities.ThongTinKiemKeKho[] row = new Entities.ThongTinKiemKeKho[dgvInsertOrder.RowCount];
                for (int k = 0; k < dgvInsertOrder.RowCount; k++)
                {
                    Entities.ThongTinKiemKeKho banghi = new Entities.ThongTinKiemKeKho();
                    banghi.Mahang = dgvInsertOrder.Rows[k].Cells[0].Value.ToString();
                    banghi.Tenhang = dgvInsertOrder.Rows[k].Cells[1].Value.ToString();
                    banghi.Tonsosach = dgvInsertOrder.Rows[k].Cells[2].Value.ToString();
                    banghi.Tonthucte = dgvInsertOrder.Rows[k].Cells[3].Value.ToString();
                    banghi.Chenhlech = dgvInsertOrder.Rows[k].Cells[4].Value.ToString();
                    banghi.Lydo = dgvInsertOrder.Rows[k].Cells[5].Value.ToString();
                    banghi.Giavon = dgvInsertOrder.Rows[k].Cells[6].Value.ToString();
                    banghi.Giachechlech = dgvInsertOrder.Rows[k].Cells[7].Value.ToString();
                    row[k] = banghi;
                }
                Entities.KiemKeKho kiemke = new Entities.KiemKeKho();
                kiemke.MaKiemKe = txtSochungtu.Text;
                kiemke.NgayKiemKe = Utils.StringToDateTime(makNgaychungtu.Text);
                //kiemke.NgayKiemKe = DateTime.Parse(new Common.Utilities().KiemTraDinhDangNgayThangNam("ThangNgayNam", makNgaychungtu.Text, '/'));
                kiemke.Tenkho = cbxKhoban.Text;
                kiemke.GhiChu = new Common.Utilities().FormatMoney(Double.Parse(txtTienhang.Text));
                kiemke.Hanhdong = "Hóa Đơn Kiểm Kê Kho";
                Entities.ThongTinCongTy conty = Congty("");
                if (row.Length > 0 && kiemke != null && conty != null)
                {
                    frmBaoCaoNhapHang frm = new frmBaoCaoNhapHang("In", Common.Utilities.User.TenNhanVien, row, kiemke, conty, string.Empty);
                    frm.ShowDialog();
                }
                else
                { MessageBox.Show("Không có dữ liệu"); return; }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void Export(string hanhDong, string path)
        {
            try
            {
                Entities.ThongTinKiemKeKho[] row = new Entities.ThongTinKiemKeKho[dgvInsertOrder.RowCount];
                for (int k = 0; k < dgvInsertOrder.RowCount; k++)
                {
                    Entities.ThongTinKiemKeKho banghi = new Entities.ThongTinKiemKeKho();
                    banghi.Mahang = dgvInsertOrder.Rows[k].Cells[0].Value.ToString();
                    banghi.Tenhang = dgvInsertOrder.Rows[k].Cells[1].Value.ToString();
                    banghi.Tonsosach = dgvInsertOrder.Rows[k].Cells[2].Value.ToString();
                    banghi.Tonthucte = dgvInsertOrder.Rows[k].Cells[3].Value.ToString();
                    banghi.Chenhlech = dgvInsertOrder.Rows[k].Cells[4].Value.ToString();
                    banghi.Lydo = dgvInsertOrder.Rows[k].Cells[5].Value.ToString();
                    banghi.Giavon = dgvInsertOrder.Rows[k].Cells[6].Value.ToString();
                    banghi.Giachechlech = dgvInsertOrder.Rows[k].Cells[7].Value.ToString();
                    row[k] = banghi;
                }
                Entities.KiemKeKho kiemke = new Entities.KiemKeKho();
                kiemke.MaKiemKe = txtSochungtu.Text;
                kiemke.NgayKiemKe = Utils.StringToDateTime(makNgaychungtu.Text);
                //kiemke.NgayKiemKe = DateTime.Parse(new Common.Utilities().KiemTraDinhDangNgayThangNam("ThangNgayNam", makNgaychungtu.Text, '/'));
                kiemke.Tenkho = cbxKhoban.Text;
                kiemke.GhiChu = new Common.Utilities().FormatMoney(Double.Parse(txtTienhang.Text));
                kiemke.Hanhdong = "Hóa Đơn Kiểm Kê Kho";
                Entities.ThongTinCongTy conty = Congty("");
                if (row.Length > 0 && kiemke != null && conty != null)
                {
                    frmBaoCaoNhapHang frm = new frmBaoCaoNhapHang(hanhDong, Common.Utilities.User.TenNhanVien, row, kiemke, conty, path);
                }
                else
                { MessageBox.Show("Không có dữ liệu"); return; }
            }
            catch
            {
            }
        }

        private Entities.ThongTinCongTy Congty(string maCongTy)
        {
            Entities.ThongTinCongTy thongtin = null;
            try
            {
                Entities.TruyenGiaTri truyen = new Entities.TruyenGiaTri("Select", maCongTy);
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "LayThongTinCongty", truyen);
                thongtin = (Entities.ThongTinCongTy)cl.DeserializeHepper(clientstrem, thongtin);
                client.Close();
                clientstrem.Close();
            }
            catch (Exception ex)
            { string s = ex.Message; thongtin = null; }
            return thongtin;
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (hanhdong == "Update")
                {
                    InThongTinKiemKe();
                }
                else
                { MessageBox.Show("Phải thêm mới rồi mới xem"); }
            }
            catch
            {

            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Export("Excel", saveFileDialog1.FileName);
                }
            }
            catch
            {
            }
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Export("Word", saveFileDialog1.FileName);
                }
            }
            catch
            {
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Export("PDF", saveFileDialog1.FileName);
                }
            }
            catch
            { }
        }

        private void toolStrip_txtTonThucTe_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // validate
                    if (!Validate1())
                        return;
                    //
                    toolStrip_txtLyDo.Focus();
                    toolStrip_txtLyDo.SelectAll();
                }
            }
            catch
            {
                return;
            }
        }

        private void toolStrip_txtLyDo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Validate
                    if (!Validate1())
                        return;
                    // Qui đổi đơn vị tính
                    foreach (Entities.QuyDoiDonViTinh item in quidoidvt)
                    {
                        if (item.MaHangQuyDoi == mahanghoa)
                        {
                            mahanghoa = toolStrip_txtTracuu.Text = item.MaHangDuocQuyDoi.ToUpper();
                            toolStrip_txtTenhang.Text = item.TenHangDuocQuyDoi;
                            toolStrip_txtTonThucTe.Text = (double.Parse(item.SoLuongDuocQuyDoi.ToString()) * double.Parse(toolStrip_txtTonThucTe.Text)).ToString();
                            break;

                        }
                    }
                    NewRow();
                    if (dgvInsertOrder.Rows.Count > 0)
                    { txtTienhang.Text = new Common.Utilities().FormatMoney(Double.Parse(new Common.Utilities().KhongDau(tinhtong().ToString()))); }
                    else
                    { txtTienhang.Text = "0"; }

                    // Forcus
                    toolStrip_txtTracuu.Focus();
                    toolStrip_txtTracuu.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message; Entities.ThongTinKiemKeKho[] lay = new Entities.ThongTinKiemKeKho[0]; dgvInsertOrder.DataSource = null;
                dgvInsertOrder.DataSource = lay; fixDatagridview();
            }
        }
    }
}
