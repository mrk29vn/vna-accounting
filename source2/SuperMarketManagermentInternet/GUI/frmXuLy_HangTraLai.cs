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
    public partial class frmXuLy_HangTraLai : Form
    {
        public static string trave = "";
        public TcpClient client1;
        #region khoi tao=============================================================
        public frmXuLy_HangTraLai()
        {
            InitializeComponent();
        }
        private string truyen;

        public string Truyen
        {
            get { return truyen; }
            set { truyen = value; }
        }
        private Entities.KhachHangTraLai update;
        public Entities.KhachHangTraLai Update
        {
            get { return update; }
            set { update = value; }
        }
        public frmXuLy_HangTraLai(string hanhdong, string tenForm, string truyen)
        {
            InitializeComponent();
            this.HanhDong = hanhdong;
            this.tenForm = tenForm;
            this.truyen = truyen;
        }
        private Entities.TraLaiNCC ncctra;
        public Entities.TraLaiNCC Ncctra
        {
            get { return ncctra; }
            set { ncctra = value; }
        }
        public frmXuLy_HangTraLai(string hanhdong, string tenForm, string truyen, Entities.TraLaiNCC ncctra)
        {
            InitializeComponent();
            this.HanhDong = hanhdong;
            this.tenForm = tenForm;
            this.truyen = truyen;
            this.ncctra = ncctra;
        }
        public frmXuLy_HangTraLai(string hanhdong, string tenForm, string truyen, Entities.KhachHangTraLai add)
        {
            InitializeComponent();
            this.HanhDong = hanhdong;
            this.tenForm = tenForm;
            this.truyen = truyen;
            this.update = add;
        }
        //---------------------------------------------------------------
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private string tenForm;

        public string TenForm
        {
            get { return tenForm; }
            set { tenForm = value; }
        }
        public frmXuLy_HangTraLai(string hanhdong)
        {
            InitializeComponent();
            this.HanhDong = hanhdong;
        }
        public frmXuLy_HangTraLai(string hanhdong, string tenForm)
        {
            InitializeComponent();
            this.HanhDong = hanhdong;
            this.tenForm = tenForm;
        }

        //---------------------------------------------------------------
        #endregion

        #region hungvv==============================================Connections=====================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        private Server_Client.Client cl;

        /// <summary>
        /// mo ket noi
        /// </summary>
        private void Connections()
        {
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
        }
        #endregion

        #region Trả lại nhà cung cấp==================================================================================================
        /// <summary>
        /// hungvv ==================================================
        /// </summary>
        private void SelectChiTietTraLaiNhaCungCap(string hanhdong)
        {
            Entities.DonDatHang pt = new Entities.DonDatHang();
            pt = new Entities.DonDatHang(hanhdong);
            Entities.ChiTietTraLaiNhaCungCap[] pt1 = new Entities.ChiTietTraLaiNhaCungCap[10];
            clientstrem = cl.SerializeObj(this.client, "ChiTietTraLaiNCC", pt);

            Binding((Entities.ChiTietTraLaiNhaCungCap[])cl.DeserializeHepper(clientstrem, pt1));
        }

        /// <summary>
        /// hungvv =====================hien thi ========================================
        /// </summary>
        /// <param name="data"></param>
        private void Binding(Entities.ChiTietTraLaiNhaCungCap[] data)
        {
            try
            {
                dgvXemthongtin.DataSource = null;
                dgvXemthongtin.DataSource = data;
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
        }

        /// <summary>
        /// xoa
        /// </summary>
        /// <param name="hanhdong"></param>
        /// <param name="matralainhacungcap"></param>
        private void XuLy_Xoa_TraLaiNhaCungCap(string hanhdong, string matralainhacungcap)
        {
            Entities.TraLaiNCC them = new Entities.TraLaiNCC();
            them = new Entities.TraLaiNCC(hanhdong, matralainhacungcap);
            clientstrem = cl.SerializeObj(this.client, "TraLaiNCC", them);
            //hứng giá trị trả về
            int trave;
            Entities.TraLaiNCC[] tralai = new Entities.TraLaiNCC[1];
            trave = (int)cl.DeserializeHepper(clientstrem, tralai);
            //thong bao
            if (trave == 1) { MessageBox.Show("Thành công !"); }
            else { MessageBox.Show("Thất bại !"); }
        }


        #endregion

        #region khách hàng trả lại==================================================================================================================
        /// <summary>
        /// hungvv ==================================================
        /// </summary>
        private void SelectChiTietKhachHangTraLai(string hanhdong)
        {
            Entities.DonDatHang pt = new Entities.DonDatHang();
            pt = new Entities.DonDatHang(hanhdong);
            Entities.ChiTietKhachHangTraLai[] pt1 = new Entities.ChiTietKhachHangTraLai[10];
            clientstrem = cl.SerializeObj(this.client, "ChiTietKhachHangTraLai", pt);

            Binding((Entities.ChiTietKhachHangTraLai[])cl.DeserializeHepper(clientstrem, pt1));
        }

        /// <summary>
        /// hungvv =====================hien thi ========================================
        /// </summary>
        /// <param name="data"></param>
        private void Binding(Entities.ChiTietKhachHangTraLai[] data)
        {
            try
            {
                dgvXemthongtin.DataSource = null;
                dgvXemthongtin.DataSource = data;
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
        }


        private void XuLy_Xoa_KhachHangTraLai(string hanhdong, string makhachhangtralai)
        {
            Entities.KhachHangTraLai them = new Entities.KhachHangTraLai();
            them = new Entities.KhachHangTraLai(hanhdong, makhachhangtralai);
            clientstrem = cl.SerializeObj(this.client, "KhachHangTraLai", them);
            //hứng giá trị trả về
            int trave;
            Entities.KhachHangTraLai[] tralai = new Entities.KhachHangTraLai[1];
            trave = (int)cl.DeserializeHepper(clientstrem, tralai);
            //thong bao
            if (trave == 1) { MessageBox.Show("Thành công !"); }
            else { MessageBox.Show("Thất bại !"); }
        }
        /// <summary>
        /// Lấy tên tiền tệ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LayTenTT()
        {
            try
            {
                cbxTiente_Tygia.Items.Clear();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KiemTraChung tt1 = new Entities.KiemTraChung();
                tt1 = new Entities.KiemTraChung("Select", "TienTe", "MaTienTe", "TenTienTe");
                clientstrem = cl.SerializeObj(this.client, "LayCombox", tt1);
                Entities.KiemTraChung[] tt = new Entities.KiemTraChung[1];
                tt = (Entities.KiemTraChung[])cl.DeserializeHepper1(clientstrem, tt);
                Common.Utilities com = new Common.Utilities();
                com.BindingCombobox(tt, cbxTiente_Tygia, "giatri", "khoachinh");
                cbxTiente_Tygia.Text = "Chọn tiền tệ";
            }
            catch
            {
                cbxTiente_Tygia.Items.Clear();
                cbxTiente_Tygia.Text = "";
            }
            client.Close();
            clientstrem.Close();
        }
        /// <summary>
        ///  Lấy Kho Hàng
        /// </summary>
        private void LayKhoHang()
        {
            try
            {
                cbxKhoHang.Items.Clear();
                Entities.KiemTraChung kh = new Entities.KiemTraChung();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                kh = new Entities.KiemTraChung("Select", "KhoHang", "MaKho", "TenKho");
                clientstrem = cl.SerializeObj(this.client, "LayCombox", kh);
                Entities.KiemTraChung[] ddh = new Entities.KiemTraChung[1];
                ddh = (Entities.KiemTraChung[])cl.DeserializeHepper(clientstrem, ddh);
                Common.Utilities com = new Common.Utilities();
                com.BindingCombobox(ddh, cbxKhoHang, "giatri", "khoachinh");
                this.cbxKhoHang.Text = "Chọn kho hàng";
            }
            catch (Exception)
            { }
            client.Close();
            clientstrem.Close();
        }
        #endregion

        private void toolStripStatus_Dong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    trave = "ok";
                    this.Close();
                }
                else
                { }
            }
        }
        /// <summary>
        /// do du lieu vao dgv
        /// </summary>
        private void HienThi_ChiTiet_TheoMa()
        {
            try
            {
                Entities.DonDatHang dat = new Entities.DonDatHang();
                dat.Hanhdong = "Select";
                dat.MaNhaCungCap = GiaTriCanLuu.Ma.ToString().ToUpper();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "HienThi_ChiTiet_TheoMa", dat);
                Entities.HienThi_ChiTiet_DonDatHang[] ddh = new Entities.HienThi_ChiTiet_DonDatHang[1];
                ddh = (Entities.HienThi_ChiTiet_DonDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                dgvXemthongtin.DataSource = ddh;
                new Common.Utilities().CountDatagridview(dgvXemthongtin);
                dgvXemthongtin.Columns[0].HeaderText = "STT";
                dgvXemthongtin.RowHeadersVisible = false;
                dgvXemthongtin.Columns[1].HeaderText = "Mã hàng";
                dgvXemthongtin.Columns[2].HeaderText = "Tên hàng";
                dgvXemthongtin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvXemthongtin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception)
            { }
            client.Close();
            clientstrem.Close();
        }

        /// <summary>
        /// hungvv ======================================
        /// </summary>
        private void Binding()
        {
            if (tenForm == "KhachHangTraLai")
            {
                if (GiaTriCanLuu.Loaitrave == "HangTraLai_KhachHangTraLai_KhachHang")
                {
                    txtMakhachhang.Text = GiaTriCanLuu.Ma;
                    lblTenkhachhang.Text = GiaTriCanLuu.Ten;
                    HienThi_ChiTiet_TheoMa();
                }
                if (GiaTriCanLuu.Loaitrave == "HangTraLai_KhachHangTraLai_MaDonHang")
                {
                    txtChungtugoc.Text = GiaTriCanLuu.Ma;
                    lblNgay.Text = GiaTriCanLuu.Ten;
                }
            }
            if (tenForm == "TraLaiNhaCungCap")
            {
                if (GiaTriCanLuu.Loaitrave == "HangTraLai_MaTraLaiNhaCungCap")
                {
                    txtMakhachhang.Text = GiaTriCanLuu.Ma;
                    lblTenkhachhang.Text = GiaTriCanLuu.Ten;
                    HienThi_ChiTiet_TheoMa();
                }
                if (GiaTriCanLuu.Loaitrave == "HangTraLai_DonDatHangNhaCungCap")
                {
                    txtChungtugoc.Text = GiaTriCanLuu.Ma;
                    lblNgay.Text = GiaTriCanLuu.Ten;
                }
            }
        }


        private void btnTimmakhachhang_Click(object sender, EventArgs e)
        {
            if (tenForm == "KhachHangTraLai")
            {
                if (hanhDong == "Them_KhachHangTraLai")
                {
                    frmTraCuu fr = new frmTraCuu("HangTraLai_KhachHangTraLai_KhachHang", "KhachHang");
                    fr.ShowDialog();
                }
                Binding();
            }
            if (tenForm == "TraLaiNhaCungCap")
            {
                if (hanhDong == "Them_TraLaiNhaCungCap")
                {
                    frmTraCuu fr = new frmTraCuu("HangTraLai_TraLaiNhaCungCap", "NhaCungCap");
                    fr.ShowDialog();
                }
                Binding();
            }
        }

        /// <summary>
        /// tu tang ID
        /// </summary>
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
                string chuoi = ddh.ID.ToString();
                Common.Utilities com = new Common.Utilities();
                txtSodonhang.Text = com.ProcessID(chuoi);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            client.Close();
            clientstrem.Close();
        }

        /// <summary>
        /// hungvv =================do du lieu khach hang can sua vao txt===========================
        /// </summary>
        /// <param name="dat"></param>
        string sodonhang, ngaydonhang, makh, nohienthoi, nguoitra, hinhthucthanhtoan, hanthanhtoan, chungtugoc, khohang, tientetygia, tienboithuong, thanhtoanngay, gtgt, ghichu;

        private void DoDuLieu(Entities.KhachHangTraLai tralai)
        {

            sodonhang = txtSodonhang.Text = tralai.MaKhachHangTraLai.ToString().ToUpper();
            ngaydonhang = makNgaydonhang.Text = new Common.Utilities().XuLy(2, tralai.NgayNhap.ToString());
            makh = txtMakhachhang.Text = tralai.MaKhachHang.ToString();
            nohienthoi = txtNohienthoi.Text = tralai.NoHienThoi.ToString();
            nguoitra = txtNguoitra.Text = tralai.NguoiTra.ToString();
            cbxHinhthucthanhtoan.SelectedItem = hinhthucthanhtoan = tralai.HinhThucThanhToan;
            hanthanhtoan = makHanthanhtoan.Text = new Common.Utilities().XuLy(2, tralai.HanThanhToan.ToString());
            chungtugoc = txtChungtugoc.Text = tralai.MaHoaDonMuaHang.ToString();
            cbxKhoHang.SelectedValue = khohang = tralai.MaKho.ToString().ToUpper();
            cbxTiente_Tygia.SelectedValue = tientetygia = tralai.MaTienTe.ToString().ToUpper();
            tienboithuong = txtTienboithuong.Text = tralai.TienBoiThuong.ToString();
            thanhtoanngay = txtThanhtoanngay.Text = tralai.ThanhToanNgay.ToString();
            gtgt = txtGiatrigiatang.Text = tralai.ThueGTGT.ToString();
            ghichu = txtDiengiai.Text = tralai.GhiChu.ToString();
        }
        /// <summary>
        /// do du lieu tra lai nha cung cap vao txt
        /// </summary>
        /// <param name="tralai"></param>
        private void DoDuLieuNhaCungcap(Entities.TraLaiNCC tralai)
        {
            txtSodonhang.Text = tralai.MaHDTraLaiNCC.ToString().ToUpper();
            makNgaydonhang.Text = new Common.Utilities().XuLy(2, tralai.Ngaytra.ToString());
            txtMakhachhang.Text = tralai.MaNCC.ToString();
            txtNohienthoi.Text = tralai.NoHienThoi.ToString();
            txtNguoitra.Text = tralai.NguoiNhanHang.ToString();
            cbxHinhthucthanhtoan.SelectedItem = tralai.HinhThucThanhToan;
            GiaTriCanLuu.Ma = tralai.MaHoaDonNhap.ToString();
            txtChungtugoc.Text = tralai.MaHoaDonNhap.ToString();
            cbxKhoHang.SelectedValue = tralai.MaKho.ToString().ToUpper();
            cbxTiente_Tygia.SelectedValue = tralai.MaTienTe.ToString().ToUpper();
            txtTienboithuong.Text = tralai.TienBoiThuong.ToString();
            txtThanhtoanngay.Text = tralai.ThanhToanNgay.ToString();
            txtGiatrigiatang.Text = tralai.ThueGTGT.ToString();
            txtDiengiai.Text = tralai.GhiChu.ToString();
        }
        /// <summary>
        /// ham load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXuLy_KhachHangTraLaiHang_Load(object sender, EventArgs e)
        {
            frmXuLy_HangTraLai fr = new frmXuLy_HangTraLai();
            LayTenTT();
            LayKhoHang();
            makNgaydonhang.Text = new Common.Utilities().XuLy(2, DateTime.Today.ToString());
            makHanthanhtoan.Text = new Common.Utilities().XuLy(2, DateTime.Today.ToString());
            this.cbxDieukienthanhtoan.Items.AddRange(new object[] { "Thanh toán ngay", "Thanh toán từng phần", "Mua nợ" });
            this.cbxDieukienthanhtoan.Text = "Chọn điều kiện thanh toán";
            this.cbxHinhthucthanhtoan.Items.AddRange(new object[] { "Tiền mặt", "Séc", "VISA", "MASTER CARD", "AMEX", "CONNECT", "JCB" });
            this.cbxHinhthucthanhtoan.Text = "Chọn hình thức thanh toán";
            //====================================khach hang tra lai========================================================
            if (hanhDong == "Them_KhachHangTraLai")
            {
                Application.OpenForms[fr.Name].Text = "Quản lý khách hàng trả lại - Thêm khách hàng trả lại";
                getID("KhachHangTraLai");
            }
            if (hanhDong == "Sua_KhachHangTraLai")
            {
                Application.OpenForms[fr.Name].Text = "Quản lý khách hàng trả lại - Sửa khách hàng trả lại";
                DoDuLieu(this.update);
            }
            //====================================tra lai nha cung cap========================================================
            if (hanhDong == "Them_TraLaiNhaCungCap")
            {
                makHanthanhtoan.Visible = false;
                lblHanthanhtoan.Visible = false;
                lblDinhDang.Visible = false;
                lblMakhachhang.Text = "Mã nhà cung cấp:";
                lblChungtugoc.Text = "Mã hóa đơn nhập:";
                lblNguoitrahang.Text = "Người nhận hàng:";
                Application.OpenForms[fr.Name].Text = "Quản lý trả lại nhà cung cấp - Thêm trả lại nhà cung cấp";
                getID("TraLaiNCC");
            }
            if (hanhDong == "Sua_TraLaiNhaCungCap")
            {
                makHanthanhtoan.Visible = false;
                lblHanthanhtoan.Visible = false;
                lblMakhachhang.Text = "Mã nhà cung cấp:";
                lblChungtugoc.Text = "Mã hóa đơn nhập:";
                lblDinhDang.Visible = false;
                Application.OpenForms[fr.Name].Text = "Quản lý trả lại nhà cung cấp - Sửa trả lại nhà cung cấp";
                DoDuLieuNhaCungcap(this.ncctra);
            }
        }

        private void btnChungtugoc_Click(object sender, EventArgs e)
        {
            if (tenForm == "KhachHangTraLai")
            {
                if (txtMakhachhang.Text != "<F4 - Tra cứu>" && txtMakhachhang.Text.Length > 0)
                {
                    //hoa don nhap mua
                    frmTraCuu fr = new frmTraCuu("HangTraLai_KhachHangTraLai_MaDonHang", "HoaDonBanHang");
                    fr.ShowDialog();
                    Binding();
                }
                else
                { MessageBox.Show("Nhập khách hàng"); txtMakhachhang.Focus(); }
            }
            if (tenForm == "TraLaiNhaCungCap")
            {
                if (txtMakhachhang.Text != "<F4 - Tra cứu>" && txtMakhachhang.Text.Length > 0)
                {
                    //hoa don nhap mua
                    frmTraCuu fr = new frmTraCuu("HangTraLai_DonDatHangNhaCungCap", "DonDatHangNhaCungCap");
                    fr.ShowDialog();
                    Binding();
                }
                else
                { MessageBox.Show("Nhập nhà cung cấp"); txtMakhachhang.Focus(); }
            }
        }

        private void toolStripStatus_In_Click(object sender, EventArgs e)
        {
            if (tenForm == "KhachHangTraLai")
            {
                MessageBox.Show("khach hang");
            }
            if (tenForm == "TraLaiNhaCungCap")
            {
                MessageBox.Show("cung cap");
            }
        }

        private void toolStripStatus_Ghilai_Click(object sender, EventArgs e)
        {
            if (tenForm == "KhachHangTraLai")
            {
                XuLy_KhachHangTraLai("Update");
            }
            if (tenForm == "TraLaiNhaCungCap")
            {
                XuLy_TraLaiNhaCungCap("Update");
            }
        }


        /// <summary>
        /// add ban ghi --------------------------------hungvv-----------------------------
        /// </summary>
        /// <param name="dgv"></param>
        public Entities.ChiTietKhachHangTraLai[] LuuChiTietKhachHangTraLai(DataGridView dgv, string hanhdong, string madondathang)
        {
            ArrayList arr = new ArrayList();
            int i = dgv.RowCount;
            Entities.ChiTietKhachHangTraLai[] mangBanghi = null;
            if (i > 0)
            {
                for (int x = 0; x < i; x++)
                {
                    Entities.ChiTietKhachHangTraLai banghi = new Entities.ChiTietKhachHangTraLai();
                    banghi.Hanhdong = hanhdong;
                    banghi.MaKhachHangTraLai = madondathang.ToUpper();
                    banghi.MaHangHoa = dgv.Rows[x].Cells[0].Value.ToString();
                    banghi.SoLuong = System.Convert.ToInt32(dgv.Rows[x].Cells[2].Value.ToString());
                    banghi.PhanTramChietKhau = dgv.Rows[x].Cells[4].Value.ToString();
                    banghi.GhiChu = dgv.Rows[x].Cells[1].Value.ToString();
                    banghi.Deleted = false;
                    arr.Add(banghi);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                mangBanghi = new Entities.ChiTietKhachHangTraLai[n];
                for (int j = 0; j < n; j++)
                {
                    mangBanghi[j] = (Entities.ChiTietKhachHangTraLai)arr[j];
                }
            }
            else
            {
                mangBanghi = null;
                mangBanghi = null;
            }
            return mangBanghi;
        }
        /// <summary>
        /// luu chi tiet don hang
        /// </summary>
        private void LuuChiTietKhachHangTraLai()
        {
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            Entities.ChiTietKhachHangTraLai[] luu = LuuChiTietKhachHangTraLai(dgvXemthongtin, "Insert", txtSodonhang.Text.ToUpper());
            clientstrem = cl.SerializeHepper(this.client, "ChiTietKhachHangTraLai", luu);
        }
        /// <summary>
        /// hungvv kiem tra dinh dang khi them moi hoa don
        /// </summary>
        /// <param name="maDonDatHang"></param>
        private Boolean CheckData(Entities.KhachHangTraLai dat)
        {
            if (dat.MaKhachHangTraLai.Length <= 0)
            {
                txtSodonhang.Focus();
                System.Windows.Forms.MessageBox.Show("Hãy nhập mã hóa đơn");
                return false;
            }

            if (dat.MaKhachHang.Length <= 0)
            {
                txtMakhachhang.Focus();
                MessageBox.Show("Kiểm tra mã khách hàng");
                return false;
            }

            if (dat.MaKho.Length <= 0)
            {
                cbxKhoHang.Focus();
                MessageBox.Show("Chọn mã kho");
                return false;
            }

            if (dat.MaTienTe.Length <= 0)
            {
                cbxTiente_Tygia.Focus();
                MessageBox.Show("Loại tiền tệ không đúng");
                return false;
            }

            if (dat.MaHoaDonMuaHang.Length <= 0)
            {
                txtChungtugoc.Focus();
                System.Windows.Forms.MessageBox.Show("Hãy nhập mã đơn nhập mua");
                return false;
            }

            return true;

        }
        private Boolean CheckData(Entities.TraLaiNCC dat)
        {
            if (dat.MaHDTraLaiNCC.Length <= 0)
            {
                txtSodonhang.Focus();
                System.Windows.Forms.MessageBox.Show("Hãy nhập mã hóa đơn");
                return false;
            }

            if (dat.MaNCC.Length <= 0)
            {
                txtMakhachhang.Focus();
                MessageBox.Show("Kiểm tra mã khách hàng");
                return false;
            }

            if (dat.MaKho.Length <= 0)
            {
                cbxKhoHang.Focus();
                MessageBox.Show("Chọn mã kho");
                return false;
            }

            if (dat.MaTienTe.Length <= 0)
            {
                cbxTiente_Tygia.Focus();
                MessageBox.Show("Loại tiền tệ không đúng");
                return false;
            }

            if (dat.MaHoaDonNhap.Length <= 0)
            {
                txtChungtugoc.Focus();
                System.Windows.Forms.MessageBox.Show("Hãy nhập mã đơn nhập mua");
                return false;
            }

            return true;

        }
        public void CheckDataGridTruSL(DataGridView dgv)
        {
            if (dgv.RowCount != 0)
            {
                Entities.ChiTietKhoHangTheoHoaHonNhap[] cthdbh = new Entities.ChiTietKhoHangTheoHoaHonNhap[dgv.RowCount];
                for (int j = 0; j < cthdbh.Length; j++)
                {
                    string maKho = cbxKhoHang.SelectedValue.ToString().ToUpper();
                    cthdbh[j] = new Entities.ChiTietKhoHangTheoHoaHonNhap("Update", maKho, dgv[0, j].Value.ToString(), int.Parse(dgv["SoLuong", j].Value.ToString()));
                }
                TruSLMang(cthdbh);
            }
        }

        public void TruSLMang(Entities.ChiTietKhoHangTheoHoaHonNhap[] ctkhthdn)
        {
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            clientstrem = cl.SerializeObj(this.client1, "ThemChiTietKhoHang", ctkhthdn);
        }

        public void SelectData()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.ChiTietKhachHangTraLai[] ctk = new Entities.ChiTietKhachHangTraLai[1];
                ctk[0] = new Entities.ChiTietKhachHangTraLai("Select");
                clientstrem = cl.SerializeHepper(this.client1, "ChiTietKhachHangTraLai", ctk);
                ctk = (Entities.ChiTietKhachHangTraLai[])cl.DeserializeHepper(clientstrem, ctk);
                dgvXemthongtin.DataSource = ctk;

            }
            catch
            {
            }
        }
        bool kt = false;
        public void CheckInsertKHTL()
        {
            kt = false;
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.KhachHangTraLai ctk = new Entities.KhachHangTraLai();
            ctk = new Entities.KhachHangTraLai("Select");
            clientstrem = cl.SerializeObj(this.client1, "KhachHangTraLai", ctk);
            Entities.KhachHangTraLai[] ctk1 = new Entities.KhachHangTraLai[1];
            ctk1 = (Entities.KhachHangTraLai[])cl.DeserializeHepper1(clientstrem, ctk1);
            dgvXemthongtin.DataSource = ctk;
            if (ctk != null)
            {
                for (int j = 0; j < ctk1.Length; j++)
                {
                    if (ctk1[j].MaKhachHangTraLai == sodonhang)
                    {
                        MessageBox.Show("cập nhật mã phiếu - kiểm tra lại để insert");
                        kt = false;
                        sodonhang = txtSodonhang.Text = new Common.Utilities().ProcessID(txtSodonhang.Text);
                        break;
                    }
                    else
                        kt = true;
                }
            }
        }
        public void CheckUpdateKHTL()
        {
            kt = false;
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.KhachHangTraLai ctk = new Entities.KhachHangTraLai();
            ctk = new Entities.KhachHangTraLai("Select");
            Entities.KhachHangTraLai[] ctk1 = new Entities.KhachHangTraLai[1];
            clientstrem = cl.SerializeObj(this.client1, "KhachHangTraLai", ctk);
            ctk1 = (Entities.KhachHangTraLai[])cl.DeserializeHepper1(clientstrem, ctk1);
            dgvXemthongtin.DataSource = ctk;
            if (ctk != null)
            {
                for (int j = 0; j < ctk1.Length; j++)
                {
                    if (ctk1[j].MaKhachHangTraLai == sodonhang)
                    {
                        kt = CheckKHTL(ctk1[j]);
                        if (kt == false)
                            MessageBox.Show("đã cật nhập 1 số trường thay đổi - kiểm tra lại", "hệ thống cảnh báo");
                        break;
                    }
                    else
                        kt = true;
                }
            }
        }
        public bool CheckKHTL(Entities.KhachHangTraLai kh)
        {
            bool gt = true;
            if (sodonhang != kh.MaKhachHangTraLai)
            {
                sodonhang = txtSodonhang.Text = kh.HinhThucThanhToan;
                gt = false;
            }
            string ngayhientai = new Common.Utilities().XuLy(2, kh.NgayNhap.ToString());
            if (ngaydonhang != ngayhientai)
            {
                ngaydonhang = makHanthanhtoan.Text = ngayhientai;
                gt = false;
            }
            if (makh != kh.MaKhachHang)
            {
                makh = txtMakhachhang.Text = kh.MaKhachHang;
                gt = false;
            }
            if (nohienthoi != kh.NoHienThoi)
            {
                nohienthoi = txtNohienthoi.Text = kh.NoHienThoi;
                gt = false;
            }
            if (nguoitra != kh.NguoiTra)
            {
                nguoitra = txtNguoitra.Text = kh.NguoiTra;
                gt = false;
            }
            ngayhientai = new Common.Utilities().XuLy(2, kh.HanThanhToan.ToString());
            if (ngaydonhang != ngayhientai)
            {
                ngaydonhang = makHanthanhtoan.Text = ngayhientai;
                gt = false;
            }
            if (nguoitra != kh.NguoiTra)
            {
                nguoitra = txtNguoitra.Text = kh.NguoiTra;
                gt = false;
            }
            if (hinhthucthanhtoan != kh.HinhThucThanhToan)
            {
                hinhthucthanhtoan = cbxHinhthucthanhtoan.Text = kh.HinhThucThanhToan;
                gt = false;
            }
            if (chungtugoc != kh.MaHoaDonMuaHang)
            {
                chungtugoc = txtChungtugoc.Text = kh.MaHoaDonMuaHang;
                gt = false;
            }
            if (khohang != kh.MaKho)
            {
                khohang = cbxKhoHang.Text = kh.MaKho;
                gt = false;
            }
            if (tientetygia != kh.MaTienTe)
            {
                tientetygia = cbxTiente_Tygia.Text = kh.MaTienTe;
                gt = false;
            }
            if (tienboithuong != kh.TienBoiThuong)
            {
                tienboithuong = txtTienboithuong.Text = kh.TienBoiThuong;
                gt = false;
            }
            if (thanhtoanngay != kh.ThanhToanNgay)
            {
                thanhtoanngay = txtThanhtoanngay.Text = kh.ThanhToanNgay;
                gt = false;
            }
            if (gtgt != kh.ThueGTGT)
            {
                gtgt = txtGiatrigiatang.Text = kh.ThueGTGT;
                gt = false;
            }
            if (ghichu != kh.GhiChu)
            {
                ghichu = txtDiengiai.Text = kh.GhiChu;
                gt = false;
            }
            return gt;
        }
        public void CheckInsertTLNCC()
        {
            kt = false;
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.TraLaiNCC ctk = new Entities.TraLaiNCC();
            ctk = new Entities.TraLaiNCC("Select");
            clientstrem = cl.SerializeObj(this.client1, "TraLaiNhaCungCap", ctk);
            Entities.TraLaiNCC[] ctk1 = new Entities.TraLaiNCC[1];
            ctk1 = (Entities.TraLaiNCC[])cl.DeserializeHepper1(clientstrem, ctk1);
            dgvXemthongtin.DataSource = ctk;
            if (ctk != null)
            {
                for (int j = 0; j < ctk1.Length; j++)
                {
                    if (ctk1[j].MaHDTraLaiNCC == sodonhang)
                    {
                        MessageBox.Show("cập nhật mã phiếu - kiểm tra lại để insert");
                        kt = false;
                        sodonhang = txtSodonhang.Text = new Common.Utilities().ProcessID(txtSodonhang.Text);
                        break;
                    }
                    else
                        kt = true;
                }
            }
        }
        public void CheckUpdateTLNCC()
        {
            kt = false;
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.TraLaiNCC ctk = new Entities.TraLaiNCC();
            ctk = new Entities.TraLaiNCC("Select");
            Entities.TraLaiNCC[] ctk1 = new Entities.TraLaiNCC[1];
            clientstrem = cl.SerializeObj(this.client1, "TraLaiNhaCungCap", ctk);
            ctk1 = (Entities.TraLaiNCC[])cl.DeserializeHepper1(clientstrem, ctk1);
            dgvXemthongtin.DataSource = ctk;
            if (ctk != null)
            {
                for (int j = 0; j < ctk1.Length; j++)
                {
                    if (ctk1[j].MaHDTraLaiNCC == sodonhang)
                    {
                        kt = CheckTLNCC(ctk1[j]);
                        if (kt == false)
                            MessageBox.Show("đã cật nhập 1 số trường thay đổi - kiểm tra lại", "hệ thống cảnh báo");
                        break;
                    }
                    else
                        kt = true;
                }
            }
        }
        public bool CheckTLNCC(Entities.TraLaiNCC kh)
        {
            bool gt = true;
            if (sodonhang != kh.MaHDTraLaiNCC)
            {
                sodonhang = txtSodonhang.Text = kh.HinhThucThanhToan;
                gt = false;
            }
            if (makh != kh.MaNCC)
            {
                makh = txtMakhachhang.Text = kh.MaNCC;
                gt = false;
            }
            if (nohienthoi != kh.NoHienThoi)
            {
                nohienthoi = txtNohienthoi.Text = kh.NoHienThoi;
                gt = false;
            }
            if (nguoitra != kh.NguoiNhanHang)
            {
                nguoitra = txtNguoitra.Text = kh.NguoiNhanHang;
                gt = false;
            }
            if (hinhthucthanhtoan != kh.HinhThucThanhToan)
            {
                hinhthucthanhtoan = cbxHinhthucthanhtoan.Text = kh.HinhThucThanhToan;
                gt = false;
            }
            if (chungtugoc != kh.MaHoaDonNhap)
            {
                chungtugoc = txtChungtugoc.Text = kh.MaHoaDonNhap;
                gt = false;
            }
            if (khohang != kh.MaKho)
            {
                khohang = cbxKhoHang.Text = kh.MaKho;
                gt = false;
            }
            if (tientetygia != kh.MaTienTe)
            {
                tientetygia = cbxTiente_Tygia.Text = kh.MaTienTe;
                gt = false;
            }
            if (tienboithuong != kh.TienBoiThuong)
            {
                tienboithuong = txtTienboithuong.Text = kh.TienBoiThuong;
                gt = false;
            }
            if (thanhtoanngay != kh.ThanhToanNgay)
            {
                thanhtoanngay = txtThanhtoanngay.Text = kh.ThanhToanNgay;
                gt = false;
            }
            if (gtgt != kh.ThueGTGT)
            {
                gtgt = txtGiatrigiatang.Text = kh.ThueGTGT;
                gt = false;
            }
            if (ghichu != kh.GhiChu)
            {
                ghichu = txtDiengiai.Text = kh.GhiChu;
                gt = false;
            }
            return gt;
        }
        /// <summary>
        /// hungvv ========================================them moi hoac sua===============
        /// </summary>
        private void XuLy_KhachHangTraLai(string hanhdong)
        {
            try
            {
                Entities.KhachHangTraLai xuly = new Entities.KhachHangTraLai();
                string thoigian_1 = null;
                thoigian_1 = new Common.Utilities().MyDateConversion(makNgaydonhang.Text);
                string thoigian_2 = null;
                thoigian_2 = new Common.Utilities().MyDateConversion(makHanthanhtoan.Text);
                if (thoigian_1 != null && thoigian_2 != null)
                {
                    xuly.NgayNhap = DateTime.Parse(thoigian_1);
                    thoigian_1 = null;
                    xuly.HanThanhToan = DateTime.Parse(thoigian_2);
                    thoigian_2 = null;
                    xuly.Hanhdong = hanhdong;
                    xuly.MaKhachHangTraLai = txtSodonhang.Text.ToUpper();
                    xuly.MaKhachHang = txtMakhachhang.Text.ToUpper();
                    xuly.NoHienThoi = float.Parse(0 + txtNohienthoi.Text).ToString();
                    xuly.NguoiTra = "" + txtNguoitra.Text;
                    xuly.HinhThucThanhToan = cbxHinhthucthanhtoan.SelectedItem.ToString();
                    xuly.MaHoaDonMuaHang = "" + txtChungtugoc.Text.ToUpper();
                    xuly.MaKho = cbxKhoHang.SelectedValue.ToString().ToUpper();
                    xuly.MaTienTe = cbxTiente_Tygia.SelectedValue.ToString().ToUpper();
                    xuly.TienBoiThuong = 0 + txtTienboithuong.Text;
                    xuly.ThanhToanNgay = 0 + txtThanhtoanngay.Text;
                    xuly.ThueGTGT = 0 + txtGiatrigiatang.Text;
                    xuly.GhiChu = "" + txtDiengiai.Text;
                    xuly.Deleted = false;
                    if (dgvXemthongtin.RowCount > 0)
                    {
                        if (CheckData(xuly) == true)
                        {
                            if (hanhdong == "Insert")
                                CheckInsertKHTL();
                            else if (hanhdong == "Update")
                                CheckUpdateKHTL();
                            if (kt == true)
                            {
                                cl = new Server_Client.Client();
                                this.client = cl.Connect(Luu.IP, Luu.Ports);
                                clientstrem = cl.SerializeObj(this.client, "KhachHangTraLai", xuly);
                                int trave1 = 0;
                                trave1 = (int)cl.DeserializeHepper(clientstrem, trave1);
                                if (trave1 == 1)
                                {
                                    LuuChiTietKhachHangTraLai();
                                    MessageBox.Show("Thành công");
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Thất bại");
                                }
                            }
                            else
                                return;
                        }
                    }
                    else
                    { MessageBox.Show("Không có hàng hóa trong đơn đặt hàng"); }
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
        /// add ban ghi --------------------------------hungvv-----------------------------
        /// </summary>
        /// <param name="dgv"></param>
        public Entities.ChiTietTraLaiNhaCungCap[] ChiTietTraLaiNhaCungCap(DataGridView dgv, string hanhdong, string madondathang)
        {
            ArrayList arr = new ArrayList();
            int i = dgv.RowCount;
            Entities.ChiTietTraLaiNhaCungCap[] mangBanghi = null;
            if (i > 0)
            {
                for (int x = 0; x < i; x++)
                {
                    Entities.ChiTietTraLaiNhaCungCap banghi = new Entities.ChiTietTraLaiNhaCungCap();
                    banghi.Hanhdong = hanhdong;
                    banghi.MaHDTraLaiNCC = madondathang.ToUpper();
                    banghi.MaHangHoa = dgv.Rows[x].Cells[0].Value.ToString();
                    banghi.SoLuong = System.Convert.ToInt32(dgv.Rows[x].Cells[2].Value.ToString());
                    banghi.PhanTramChietKhau = dgv.Rows[x].Cells[4].Value.ToString();
                    banghi.GhiChu = dgv.Rows[x].Cells[1].Value.ToString();
                    banghi.Deleted = false;
                    arr.Add(banghi);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                mangBanghi = new Entities.ChiTietTraLaiNhaCungCap[n];
                for (int j = 0; j < n; j++)
                {
                    mangBanghi[j] = (Entities.ChiTietTraLaiNhaCungCap)arr[j];
                }
            }
            else
            {
                mangBanghi = null;
                mangBanghi = null;
            }
            return mangBanghi;
        }
        /// <summary>
        /// luu chi tiet don hang
        /// </summary>
        private void LuuChiTietTraLaiNhaCungCap()
        {
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            Entities.ChiTietTraLaiNhaCungCap[] luu = ChiTietTraLaiNhaCungCap(dgvXemthongtin, "Insert", txtSodonhang.Text.ToUpper());
            clientstrem = cl.SerializeHepper(this.client, "ChiTietTraLaiNhaCungCap", luu);
            int bao = 0;
            bao = (int)cl.DeserializeHepper(clientstrem, bao);
        }
        /// <summary>
        /// hungvv ========================================them moi hoac sua===============
        /// </summary>
        private void XuLy_TraLaiNhaCungCap(string hanhdong)
        {
            try
            {
                Entities.TraLaiNCC xuly = new Entities.TraLaiNCC();
                string thoigian_1 = null;
                thoigian_1 = new Common.Utilities().MyDateConversion(makNgaydonhang.Text);
                if (thoigian_1 != null)
                {
                    xuly.Ngaytra = DateTime.Parse(thoigian_1);
                    thoigian_1 = null;
                    xuly.Hanhdong = hanhdong;
                    xuly.MaHDTraLaiNCC = txtSodonhang.Text.ToUpper();
                    xuly.MaNCC = txtMakhachhang.Text.ToUpper();
                    xuly.NoHienThoi = 0 + txtNohienthoi.Text;
                    xuly.NguoiNhanHang = "" + txtNguoitra.Text;
                    xuly.HinhThucThanhToan = cbxHinhthucthanhtoan.SelectedItem.ToString();
                    xuly.MaHoaDonNhap = txtChungtugoc.Text.ToUpper();
                    xuly.MaKho = cbxKhoHang.SelectedValue.ToString().ToUpper();
                    xuly.MaTienTe = cbxTiente_Tygia.SelectedValue.ToString().ToUpper();
                    xuly.TienBoiThuong = 0 + txtTienboithuong.Text;
                    xuly.ThanhToanNgay = 0 + txtThanhtoanngay.Text;
                    xuly.ThueGTGT = 0 + txtGiatrigiatang.Text;
                    xuly.GhiChu = "" + txtDiengiai.Text;
                    xuly.Deleted = false;
                    if (dgvXemthongtin.RowCount > 0)
                    {
                        if (CheckData(xuly) == true)
                        {
                            CheckInsertTLNCC();
                            if (kt == true)
                            {
                                cl = new Server_Client.Client();
                                this.client = cl.Connect(Luu.IP, Luu.Ports);
                                clientstrem = cl.SerializeObj(this.client, "TraLaiNhaCungCap", xuly);
                                Entities.KhachHangTraLai[] tralai = new Entities.KhachHangTraLai[1];
                                int trave = System.Convert.ToInt32(cl.DeserializeHepper(clientstrem, tralai));
                                if (trave == 1)
                                {
                                    LuuChiTietTraLaiNhaCungCap();
                                    CheckDataGridTruSL(dgvXemthongtin);
                                    MessageBox.Show("Thành công");
                                }
                                else
                                {
                                    MessageBox.Show("Thất bại");
                                }
                            }
                        }
                    }
                    else
                    { MessageBox.Show("Không có hàng hóa trong đơn đặt hàng"); }
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


        private void toolStripStatus_Themmoi_Click(object sender, EventArgs e)
        {
            if (tenForm == "KhachHangTraLai")
            {
                XuLy_KhachHangTraLai("Insert");
            }
            if (tenForm == "TraLaiNhaCungCap")
            {
                XuLy_TraLaiNhaCungCap("Insert");
            }
        }

        private void BindHangHoa()
        {
            if (tenForm == "KhachHangTraLai")
            {
                if (GiaTriCanLuu.Loaitrave == "KhachHangTraLaiHang_HangHoa")
                {
                    txtMakhachhang.Text = GiaTriCanLuu.Ma;
                    lblTenkhachhang.Text = GiaTriCanLuu.Ten;
                    HienThi_ChiTiet_TheoMa();
                }
                if (GiaTriCanLuu.Loaitrave == "HoaDonNhap_DonDatHang")
                {
                    txtChungtugoc.Text = GiaTriCanLuu.Ma;
                    lblNgaychungtu.Text = GiaTriCanLuu.Ten;
                }
                if (GiaTriCanLuu.Loaitrave == "ChiTietKhachHangTraLaiHang_HangHoa")
                {
                    toolStrip_txtTracuu.Text = GiaTriCanLuu.Ma;
                    toolStrip_txtTenhang.Text = GiaTriCanLuu.Ten;
                    toolStrip_txtGiagoc.Text = GiaTriCanLuu.Giatri;
                    toolStrip_txtSoluong.Text = "1";
                    toolStrip_txtChietkhauphantram.Text = "0";
                }
            }
            //dang lam
            if (tenForm == "TraLaiNhaCungCap")
            {
                if (GiaTriCanLuu.Loaitrave == "TraLaiNhaCungCap_HangHoa")
                {
                    txtMakhachhang.Text = GiaTriCanLuu.Ma;
                    lblTenkhachhang.Text = GiaTriCanLuu.Ten;
                    HienThi_ChiTiet_TheoMa();
                }
                if (GiaTriCanLuu.Loaitrave == "HoaDonNhap_DonDatHang")
                {
                    txtChungtugoc.Text = GiaTriCanLuu.Ma;
                    lblNgaychungtu.Text = GiaTriCanLuu.Ten;
                }
                if (GiaTriCanLuu.Loaitrave == "ChiTietTraLaiNhaCungCap_MaHangHoa")
                {
                    toolStrip_txtTracuu.Text = GiaTriCanLuu.Ma;
                    toolStrip_txtTenhang.Text = GiaTriCanLuu.Ten;
                    toolStrip_txtGiagoc.Text = GiaTriCanLuu.Giatri;
                    toolStrip_txtSoluong.Text = "1";
                    toolStrip_txtChietkhauphantram.Text = "0";
                }
            }
        }
        private void toolStrip_txtTracuu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                if (tenForm == "KhachHangTraLai")
                {
                    if (txtMakhachhang.Text.Length > 0 && txtMakhachhang.Text != "<F2 Tra cứu>")
                    {
                        frmTraCuu fr = new frmTraCuu("ChiTietKhachHangTraLaiHang_HangHoa", "HangHoa");
                        fr.ShowDialog();
                        BindHangHoa();
                    }
                    else
                    {
                        txtMakhachhang.Focus();
                        MessageBox.Show("Nhập mã khách hàng");
                    }
                }
                //dang lam
                if (tenForm == "TraLaiNhaCungCap")
                {
                    if (txtMakhachhang.Text.Length > 0 && txtMakhachhang.Text != "<F2 Tra cứu>")
                    {
                        frmTraCuu fr = new frmTraCuu("ChiTietTraLaiNhaCungCap_MaHangHoa", "LayChiTietTraLaiNhaCungCap", txtMakhachhang.Text.ToUpper());
                        fr.ShowDialog();
                        BindHangHoa();
                    }
                    else
                    {
                        txtMakhachhang.Focus();
                        MessageBox.Show("Nhập mã nhà cung cấp");
                    }
                }
            }
        }

        /// <summary>
        /// hungvv --------------------kiem tra ma hang khi them chi tiet hang------------------
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string KiemTraMa(string ID)
        {
            string kt = null;
            Entities.KiemTraChung ktm = new Entities.KiemTraChung();
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            ktm = new Entities.KiemTraChung("Select", ID);
            clientstrem = cl.SerializeObj(this.client, "KiemTraMa", ktm);
            Entities.KiemTraChung tra = new Entities.KiemTraChung();
            tra = (Entities.KiemTraChung)cl.DeserializeHepper(clientstrem, tra);
            kt = tra.Hanhdong;
            return kt;
        }

        /// <summary>
        /// hungvv ----------------------tinh toan
        /// </summary>
        public Boolean TinhChietKhau(ToolStripTextBox txtchietkhau, ToolStripTextBox txtphantramchietkhau, float giagoc, float phantram)
        {
            Boolean tra = false;
            float trave = 0;
            if (phantram > 0 && phantram <= 100)
            {
                trave = (phantram / giagoc) * 100;
                txtchietkhau.Text = (giagoc - trave).ToString();
                txtphantramchietkhau.Text = phantram.ToString();
                tra = true;
            }
            else
            {
                if (phantram == 0)
                {
                    txtchietkhau.Text = "";
                    txtphantramchietkhau.Text = "";
                    tra = true;
                }
                else
                {
                    txtchietkhau.Text = "";
                    txtphantramchietkhau.Text = "";
                    tra = false;
                }
            }
            return tra;
        }
        /// <summary>
        /// hungvv  ==============================================================================
        /// </summary>
        public DataTable LayGiaTri(DataGridView dgv, string ma, string ten, int soluong, float gia, float chietkhau, float phantram)
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("ID", typeof(string));
            tb.Columns.Add("Name", typeof(string));
            tb.Columns.Add("SoLuong", typeof(int));
            tb.Columns.Add("Gia", typeof(float));
            tb.Columns.Add("PhanTram", typeof(string));
            tb.Columns.Add("ChietKhau", typeof(string));
            tb.Columns.Add("TongTien", typeof(string));
            DataRow row = tb.NewRow();
            if (dgv.RowCount > 0)
            {
                DataRow row2 = tb.NewRow();
                Boolean k = false;
                int count = dgv.RowCount;
                Entities.ChiTietDonDatHang[] chitiet = new Entities.ChiTietDonDatHang[count];
                for (int i = 0; i < count; i++)
                {
                    row["ID"] = dgv.Rows[i].Cells[0].Value.ToString();
                    row["Name"] = dgv.Rows[i].Cells[1].Value.ToString();
                    int sl = 0;
                    if (dgv.Rows[i].Cells[0].Value.ToString() == ma)
                    {
                        sl = Convert.ToInt32(dgv.Rows[i].Cells[2].Value.ToString()) + soluong;
                        k = true;
                    }
                    if (dgv.Rows[i].Cells[0].Value.ToString() != ma)
                    {
                        sl = Convert.ToInt32(dgv.Rows[i].Cells[2].Value.ToString());
                        k = false;
                    }
                    row["SoLuong"] = sl.ToString();
                    row["Gia"] = dgv.Rows[i].Cells[3].Value.ToString();
                    row["PhanTram"] = dgv.Rows[i].Cells[4].Value.ToString();
                    row["ChietKhau"] = dgv.Rows[i].Cells[5].Value.ToString();
                    row["TongTien"] = dgv.Rows[i].Cells[6].Value.ToString();
                    tb.Rows.Add(row.ItemArray);
                    tb.AcceptChanges();
                }
                if (k == false)
                {
                    row2["ID"] = ma;
                    row2["Name"] = ten;
                    row2["SoLuong"] = soluong;
                    row2["Gia"] = gia;
                    row2["PhanTram"] = phantram;
                    row2["ChietKhau"] = chietkhau;
                    row2["TongTien"] = gia * soluong;
                    tb.Rows.Add(row2.ItemArray);
                    tb.AcceptChanges();
                }
            }
            else
            {
                DataRow row2 = tb.NewRow();
                row2["ID"] = ma;
                row2["Name"] = ten;
                row2["SoLuong"] = soluong;
                row2["Gia"] = gia;
                row2["PhanTram"] = phantram;
                row2["ChietKhau"] = chietkhau;
                row2["TongTien"] = gia * soluong;
                tb.Rows.Add(row2.ItemArray);
                tb.AcceptChanges();
            }
            return tb;
        }

        /// <summary>
        /// tinh tong tien
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public string TongTien(DataGridView dgv)
        {
            string giatri = "0";
            if (dgv.RowCount > 0)
            {
                int count = dgv.RowCount;
                Entities.ChiTietDonDatHang[] chitiet = new Entities.ChiTietDonDatHang[count];
                for (int i = 0; i < count; i++)
                {
                    string lay = dgv.Rows[i].Cells[7].Value.ToString();
                    giatri = (float.Parse(lay) + float.Parse(giatri)).ToString();
                }
            }
            return giatri;
        }

        /// <summary>
        /// them hang moi 1 row vao dgv
        /// </summary>
        private void NewRow()
        {
            try
            {
                if (txtMakhachhang.Text != "" && txtMakhachhang.Text != "<F2 Tra cứu>")
                {
                    string ma = "" + toolStrip_txtTracuu.Text.ToUpper();
                    string ten = "" + toolStrip_txtTenhang.Text;
                    int soluong = Convert.ToInt32(0 + toolStrip_txtSoluong.Text);
                    float gia = Convert.ToInt32(0 + toolStrip_txtGiagoc.Text);
                    float chietkhau = (float)Convert.ToInt32(0 + toolStrip_txtChietkhauphantram.Text);
                    float phantram = (float)Convert.ToInt32(0 + toolStrip_txtChietkhau.Text);
                    string thongbao = KiemTraMa(ma.Trim());
                    if (TinhChietKhau(toolStrip_txtChietkhau, toolStrip_txtChietkhauphantram, gia, chietkhau) == true)
                    {
                        if (thongbao == "NO")
                        {
                            MessageBox.Show("Mã hàng không đúng");
                            toolStrip_txtTracuu.Focus();
                            return;
                        }
                        else
                        {
                            if (chietkhau > 100 || chietkhau < 0)
                            {
                                MessageBox.Show("chiết khấu quá lớn");
                                toolStrip_txtChietkhauphantram.Text = "";
                                toolStrip_txtChietkhauphantram.Focus();
                                return;
                            }
                            else
                            {
                                if (soluong < 0)
                                {
                                    MessageBox.Show("số lượng không đúng");
                                    toolStrip_txtSoluong.Focus();
                                    return;
                                }
                                else
                                {
                                    dgvXemthongtin.DataSource = LayGiaTri(dgvXemthongtin, ma, ten, soluong, gia, chietkhau, phantram);
                                    //txtTienhang_2.Text = TongTien(dgvXemthongtin);
                                    //txtTongtienthanhtoan.Text = txtTienhang_2.Text;
                                    dgvXemthongtin.RowHeadersVisible = false;
                                    dgvXemthongtin.Columns[0].HeaderText = "Mã hàng";
                                    dgvXemthongtin.Columns[1].HeaderText = "Tên hàng hóa";
                                    dgvXemthongtin.Columns[2].HeaderText = "Số lượng";
                                    dgvXemthongtin.Columns[3].HeaderText = "Giá gốc";
                                    dgvXemthongtin.Columns[4].HeaderText = "%CK";
                                    dgvXemthongtin.Columns[5].HeaderText = "Chiết khấu";
                                    dgvXemthongtin.Columns[6].HeaderText = "Tổng tiền";
                                    dgvXemthongtin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                                    dgvXemthongtin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                                    ResetTool();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kiểm tra chiết khấu");
                    }
                }
                else
                {
                    ResetTool();
                    MessageBox.Show("Chọn nhà cung cấp");
                    return;
                }
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                MessageBox.Show("Kiểm tra dữ liệu cần thêm");
            }
        }

        /// <summary>
        /// reset form
        /// </summary>
        private void ResetTool()
        {
            toolStrip_txtTracuu.Text = "<F2 Tra cứu>";
            toolStrip_txtTenhang.Text = "";
            toolStrip_txtSoluong.Text = "1";
            toolStrip_txtGiagoc.Text = "0";
            toolStrip_txtChietkhau.Text = "";
            toolStrip_txtChietkhauphantram.Text = "";
        }

        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {
            NewRow();
        }

        private void TraCuuMa(KeyEventArgs e)
        {
            if (tenForm == "KhachHangTraLai")
            {
                if (e.KeyCode == Keys.F4 && hanhDong == "Them_KhachHangTraLai")
                {
                    frmTraCuu fr = new frmTraCuu("HangTraLai_KhachHangTraLai_KhachHang", "KhachHang");
                    fr.ShowDialog();
                }
                Binding();
            }
            if (tenForm == "TraLaiNhaCungCap")
            {
                if (e.KeyCode == Keys.F4 && hanhDong == "Them_TraLaiNhaCungCap")
                {
                    frmTraCuu fr = new frmTraCuu("HangTraLai_TraLaiNhaCungCap", "NhaCungCap");
                    fr.ShowDialog();
                }
                Binding();
            }
        }
        private void txtMakhachhang_KeyDown(object sender, KeyEventArgs e)
        {
            TraCuuMa(e);
        }

        private void txtChungtugoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (tenForm == "KhachHangTraLai")
            {
                if (e.KeyCode == Keys.F4 && hanhDong == "Them_KhachHangTraLai")
                {
                    //hoa don nhap mua
                    frmTraCuu fr = new frmTraCuu("HangTraLai_KhachHangTraLai_MaDonHang", "DonDatHang");
                    fr.ShowDialog();
                }
                Binding();
            }
            if (tenForm == "TraLaiNhaCungCap")
            {
                if (e.KeyCode == Keys.F4 && hanhDong == "Them_TraLaiNhaCungCap")
                {
                    //hoa don nhap mua
                    frmTraCuu fr = new frmTraCuu("HangTraLai_TraLaiNhaCungCap", "DonDatHang");
                    fr.ShowDialog();
                }
                Binding();
            }
        }

        private void dgvXemthongtin_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.ColumnIndex;
            int j = e.RowIndex;
            int x = dgvXemthongtin.RowCount;
            int y = dgvXemthongtin.ColumnCount;
            if (y <= -1 || x <= -1)
            { }
            else
            {
                if (i >= 0 && j >= 0)
                {
                    int get = dgvXemthongtin.Rows[j].Cells[i].RowIndex;
                    if (get <= dgvXemthongtin.RowCount - 2 && get >= 0)
                    {
                        System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn muốn xóa không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                        {
                            if (giatri == System.Windows.Forms.DialogResult.Yes)
                            {
                                dgvXemthongtin.Rows.RemoveAt(get);
                            }
                        }
                    }
                }
            }
        }

        private void toolStrip_txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void toolStrip_txtGiagoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void toolStrip_txtChietkhauphantram_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void toolStrip_txtChietkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiatrigiatang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTienboithuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtThanhtoanngay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
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
