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
    public partial class frmTraCuu : Form
    {
        Entities.ThongTinNhaCungCap[] hienthiNCC = new Entities.ThongTinNhaCungCap[0];
        Entities.ThongTinKhachHang[] hienthiKH = new Entities.ThongTinKhachHang[0];
        Entities.HienThi_KhachHangTraLai[] hienthiKHTL = new Entities.HienThi_KhachHangTraLai[0];
        Entities.ThongTinDatHang[] hienthiTTDH = new Entities.ThongTinDatHang[0];

        #region hungvv==============================================khoi tao=====================================================================
        public static DataGridViewRow drvr = null;
        private string hanhdong;
        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        private string names;
        public string Names
        {
            get { return names; }
            set { names = value; }
        }

        public frmTraCuu()
        {
            InitializeComponent();
        }
        private string maNhaCungCap;

        public string MaNhaCungCap
        {
            get { return maNhaCungCap; }
            set { maNhaCungCap = value; }
        }
        private string loai;

        public string Loai
        {
            get { return loai; }
            set { loai = value; }
        }
        public frmTraCuu(string names, string hanhdong, string manhacungcap)
        {
            InitializeComponent();
            if (names.Equals("HangTraLai_KhachHangTraLai_KhachHang") && hanhdong.Equals("KhachHangTralaiHang"))
            {
                rdbtimkiem1.Visible = true;
                rdbtimkiem2.Visible = true;
                txttimkiem.Visible = true;
                rdbtimkiem1.Text = "Mã khách hàng";
                rdbtimkiem2.Text = "Tên khách hàng";
            }
            if (names.Equals("ChiTietTraLaiNhaCungCap_MaHangHoa") && hanhdong.Equals("ThongTinTraLaiNhaCungCap"))
            {
                rdbtimkiem1.Visible = true;
                rdbtimkiem2.Visible = true;
                txttimkiem.Visible = true;
                rdbtimkiem1.Text = "Mã hàng hóa";
                rdbtimkiem2.Text = "Tên hàng hóa";
            }
            if (names.Equals("HoaDonNhap_MaDonDatHang") && hanhdong.Equals("MaDonDatHang"))
            {
                rdbtimkiem1.Visible = true;
                rdbtimkiem2.Visible = true;
                txttimkiem.Visible = true;
                rdbtimkiem1.Text = "Mã hóa đơn";
                rdbtimkiem2.Text = "Ngày lập";
            }
            if (names.Equals("KiemKeKho_HangHoa") && hanhdong.Equals("KiemKeHangHoa"))
            {
                rdbtimkiem1.Visible = true;
                rdbtimkiem2.Visible = true;
                txttimkiem.Visible = true;
                rdbtimkiem1.Text = "Mã hàng hóa";
                rdbtimkiem2.Text = "Tên hàng hóa";
            }

            this.hanhdong = hanhdong;
            this.names = names;
            this.maNhaCungCap = manhacungcap;
        }
        string makho;
        public frmTraCuu(string names, string hanhdong, string manhacungcap, string makho, string aa)
        {
            InitializeComponent();
            if (names.Equals("HangTraLai_DonDatHangNhaCungCap") && hanhdong.Equals("TimHoaDonNhapTheoMa"))
            {
                rdbtimkiem1.Visible = true;
                rdbtimkiem2.Visible = true;
                txttimkiem.Visible = true;
                rdbtimkiem1.Text = "Mã hóa đơn";
                rdbtimkiem2.Text = "Ngày nhập";
            }
            if (names.Equals("HangTraLai_KhachHangTraLai_MaDonHang") && hanhdong.Equals("HoaDonBanHang"))
            {
                rdbtimkiem1.Visible = true;
                rdbtimkiem2.Visible = true;
                txttimkiem.Visible = true;
                rdbtimkiem1.Text = "Mã hóa đơn";
                rdbtimkiem2.Text = "Ngày bán";
            }
            this.hanhdong = hanhdong;
            this.names = names;
            this.maNhaCungCap = manhacungcap;
            this.makho = makho;
        }
        public frmTraCuu(string names, string hanhdong, string manhacungcap, string loai)
        {
            InitializeComponent();
            if (names.Equals("ChiTietKhachHangTraLaiHang_HangHoa") && hanhdong.Equals("HangHoaTraLai"))
            {
                rdbtimkiem1.Visible = true;
                rdbtimkiem2.Visible = true;
                txttimkiem.Visible = true;
                rdbtimkiem1.Text = "Mã hàng hóa";
                rdbtimkiem2.Text = "Tên hàng hóa";
            }
            this.hanhdong = hanhdong;
            this.names = names;
            this.maNhaCungCap = manhacungcap;
            this.loai = loai;
        }
        public frmTraCuu(string names, string hanhdong)
        {
            InitializeComponent();
            if (names.Equals("HoaDonNhap_NhaCungCap") && hanhdong.Equals("HoaDonNhap"))
            {
                rdbtimkiem1.Visible = true;
                rdbtimkiem2.Visible = true;
                txttimkiem.Visible = true;
                rdbtimkiem1.Text = "Mã nhà cung cấp";
                rdbtimkiem2.Text = "Tên nhà cung cấp";
            }
            if (names.Equals("HangTraLai_TraLaiNhaCungCap") && hanhdong.Equals("NhaCungCap"))
            {
                rdbtimkiem1.Visible = true;
                rdbtimkiem2.Visible = true;
                txttimkiem.Visible = true;
                rdbtimkiem1.Text = "Mã nhà cung cấp";
                rdbtimkiem2.Text = "Tên nhà cung cấp";
            }
            if (names.Equals("DonDatHang_KhachHang") && hanhdong.Equals("KhachHang"))
            {
                rdbtimkiem1.Visible = true;
                rdbtimkiem2.Visible = true;
                txttimkiem.Visible = true;
                rdbtimkiem1.Text = "Mã khách hàng";
                rdbtimkiem2.Text = "Tên khách hàng";
            }
            if (names.Equals("DonDatHang_NhaCungCap") && hanhdong.Equals("NhaCungCap"))
            {
                rdbtimkiem1.Visible = true;
                rdbtimkiem2.Visible = true;
                txttimkiem.Visible = true;
                rdbtimkiem1.Text = "Mã nhà cung cấp";
                rdbtimkiem2.Text = "Tên nhà cung cấp";
            }
            if (names.Equals("HoaDonDat_HangHoa") && hanhdong.Equals("HoaDonHangHoa"))
            {
                rdbtimkiem1.Visible = true;
                rdbtimkiem2.Visible = true;
                txttimkiem.Visible = true;
                rdbtimkiem1.Text = "Mã hàng hóa";
                rdbtimkiem2.Text = "Tên hàng hóa";
            }
            this.hanhdong = hanhdong;
            this.names = names;
        }
        private TcpClient client;
        private NetworkStream clientstrem;

        private Entities.TruyenGiaTri cc;
        private Entities.ThongTinKhachHang kh;
        private Entities.TruyenGiaTri dh;

        private Entities.ThongTinMaDonDatHang ddhs;
        private Server_Client.Client cl;

        private void KiemKeHangHoa(string makho)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                dh = new Entities.TruyenGiaTri("Select", makho);
                clientstrem = cl.SerializeObj(this.client, "KiemKeHangHoa", dh);
                Entities.ThongTinDatHang[] ddh = new Entities.ThongTinDatHang[1];
                ddh = (Entities.ThongTinDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh.Length > 0)
                {
                    this.hienthiTTDH = ddh;
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = ddh;
                    fixHangHoaKiemKe();
                }
                else
                {
                    Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = lay;
                    fixHangHoaKiemKe();
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                dgvHieThi.DataSource = null;
                dgvHieThi.DataSource = lay;
                fixHangHoaKiemKe();
            }
        }
        /// <summary>
        /// tim hang hoa
        /// </summary>
        private void BindingHangHoa()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                dh = new Entities.TruyenGiaTri("Select", "");
                clientstrem = cl.SerializeObj(this.client, "ThongTinDatHang", dh);
                Entities.ThongTinDatHang[] ddh = new Entities.ThongTinDatHang[1];
                ddh = (Entities.ThongTinDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh.Length > 0)
                {
                    dgvHieThi.DataSource = null;
                    hienthiTTDH = ddh;
                    dgvHieThi.DataSource = ddh;
                    fixHangHoa();
                }
                else
                {
                    Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = lay;
                    fixHangHoa();
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                dgvHieThi.DataSource = null;
                dgvHieThi.DataSource = lay;
                fixHangHoa();
            }
        }
        private void fixHangHoaTheoKho()
        {
            dgvHieThi.Columns[0].Visible = false;
            dgvHieThi.RowHeadersVisible = false;
            dgvHieThi.Columns[1].HeaderText = "Mã hàng";
            dgvHieThi.Columns[2].HeaderText = "Tên hàng";
            dgvHieThi.Columns[3].Visible = false;
            dgvHieThi.Columns[4].HeaderText = "Số lượng";
            dgvHieThi.Columns[5].Visible = false;
            dgvHieThi.Columns[6].Visible = false;
            dgvHieThi.Columns[7].Visible = false;
            groupBox1.Text = "Tìm thấy tổng số: " + (0 + dgvHieThi.RowCount) + " bản ghi";
            dgvHieThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHieThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        /// tim hang hoa
        /// </summary>
        private void BindingHangHoaTheoMaKho(string makho)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                dh = new Entities.TruyenGiaTri("Select", makho);
                clientstrem = cl.SerializeObj(this.client, "LayBang_HangHoaTheoMaKhoHang", dh);
                Entities.ThongTinDatHang[] ddh = new Entities.ThongTinDatHang[1];
                ddh = (Entities.ThongTinDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh.Length > 0)
                {
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = ddh;
                    fixHangHoaTheoKho();
                }
                else
                {
                    Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = lay;
                    fixHangHoaTheoKho();
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                dgvHieThi.DataSource = null;
                dgvHieThi.DataSource = lay;
                fixHangHoa();
            }
        }
        /// <summary>
        /// tim hang hoa
        /// </summary>
        private Entities.TruyenGiaTri[] doituong;
        private void send(Entities.ThongTinDatHang[] giatri)
        {
            try
            {
                doituong = new Entities.TruyenGiaTri[giatri.Length];
                for (int i = 0; i < giatri.Length; i++)
                {
                    Entities.TruyenGiaTri b = new Entities.TruyenGiaTri();
                    b.Giatritruyen = giatri[i].MaHangHoa;
                    b.Giatrithuhai = giatri[i].Tonkho;
                    doituong[i] = b;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void BindingHangHoaTraLai(string ma, string loai)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                dh = new Entities.TruyenGiaTri("Select", ma, loai);
                clientstrem = cl.SerializeObj(this.client, "ChiTietKhachHangTraLaiTheoDonBanHang", dh);
                Entities.ThongTinDatHang[] ddh = new Entities.ThongTinDatHang[1];
                ddh = (Entities.ThongTinDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh.Length > 0)
                {
                    send(ddh);
                    dgvHieThi.DataSource = null;
                    hienthiTTDH = ddh;
                    dgvHieThi.DataSource = ddh;
                    fixHangHoa();
                }
                else
                {
                    Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = lay;
                    fixHangHoa();
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                dgvHieThi.DataSource = null;
                dgvHieThi.DataSource = lay;
                fixHangHoa();
            }
        }
        private void fixHangHoaKiemKe()
        {
            try
            {
                dgvHieThi.RowHeadersVisible = false;
                dgvHieThi.Columns["MaHangHoa"].HeaderText = "Mã hàng";
                dgvHieThi.Columns["TenHangHoa"].HeaderText = "Tên hàng";
                dgvHieThi.Columns["Tonkho"].HeaderText = "Số lượng";
                dgvHieThi.Columns[0].Visible = false;
                dgvHieThi.Columns[3].Visible = false;
                dgvHieThi.Columns[5].Visible = false;
                dgvHieThi.Columns[6].Visible = false;
                dgvHieThi.Columns[7].Visible = false;
                groupBox1.Text = "Tìm thấy tổng số: " + (0 + dgvHieThi.RowCount) + " bản ghi";
                dgvHieThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHieThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// hien thi lai dgv
        /// </summary>
        private void fixHangHoa()
        {
            dgvHieThi.Columns[0].Visible = false;
            dgvHieThi.RowHeadersVisible = false;
            dgvHieThi.Columns[1].HeaderText = "Mã hàng";
            dgvHieThi.Columns[2].HeaderText = "Tên hàng";
            dgvHieThi.Columns[3].Visible = false;
            dgvHieThi.Columns[4].Visible = false;
            dgvHieThi.Columns[4].HeaderText = "Số lượng";
            dgvHieThi.Columns[5].Visible = false;
            dgvHieThi.Columns[6].Visible = false;
            dgvHieThi.Columns[7].Visible = false;
            groupBox1.Text = "Tìm thấy tổng số: " + (0 + dgvHieThi.RowCount) + " bản ghi";
            dgvHieThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHieThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// lay nha cung cap
        /// </summary>
        private void BindingNhaCungCap()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                cc = new Entities.TruyenGiaTri("Select", "");
                clientstrem = cl.SerializeObj(this.client, "ThongTinNhaCungCap", cc);
                Entities.ThongTinNhaCungCap[] ddh = new Entities.ThongTinNhaCungCap[1];
                ddh = (Entities.ThongTinNhaCungCap[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length > 0)
                {
                    hienthiNCC = ddh;
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = ddh;
                    fixNhaCungCap();
                }
                else
                {
                    Entities.ThongTinNhaCungCap[] lay = new Entities.ThongTinNhaCungCap[0];
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = lay;
                    fixNhaCungCap();
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.ThongTinNhaCungCap[] lay = new Entities.ThongTinNhaCungCap[0];
                dgvHieThi.DataSource = null;
                dgvHieThi.DataSource = lay;
                fixNhaCungCap();
            }
        }
        /// <summary>
        /// fix nha cung cap dgv
        /// </summary>
        private void fixNhaCungCap()
        {
            dgvHieThi.RowHeadersVisible = false;
            dgvHieThi.Columns[0].Visible = false;
            dgvHieThi.Columns[1].HeaderText = "Mã NCC";
            dgvHieThi.Columns[2].HeaderText = "Tên nhà cung cấp";
            dgvHieThi.Columns[3].HeaderText = "Địa chỉ";
            dgvHieThi.Columns[4].HeaderText = "Nợ hiện thời";
            dgvHieThi.Columns[4].Visible = false;
            groupBox1.Text = "Tìm thấy tổng số: " + (0 + dgvHieThi.RowCount) + " bản ghi";
            dgvHieThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHieThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loai"></param>
        private void BindingKhachHangTralaiHang(string loai)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TruyenGiaTri truyen = new Entities.TruyenGiaTri("Select", loai);
                clientstrem = cl.SerializeObj(this.client, "BindingKhachHangTralaiHang", truyen);
                Entities.ThongTinKhachHang[] ddh = new Entities.ThongTinKhachHang[1];
                ddh = (Entities.ThongTinKhachHang[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh.Length > 0)
                {
                    dgvHieThi.DataSource = null;
                    hienthiKH = ddh;
                    dgvHieThi.DataSource = ddh;
                    fixKhachHang();
                }
                else
                {
                    Entities.ThongTinKhachHang[] lay = new Entities.ThongTinKhachHang[0];
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = lay;
                    fixKhachHang();
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.ThongTinKhachHang[] lay = new Entities.ThongTinKhachHang[0];
                dgvHieThi.DataSource = null;
                dgvHieThi.DataSource = lay;
                fixKhachHang();
            }
        }
        /// <summary>
        /// lay khach hang
        /// </summary>
        /// <param name="makhachhang"></param>
        private void BindingKhachHang(string makhachhang)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TruyenGiaTri truyen = new Entities.TruyenGiaTri("Select", makhachhang);
                clientstrem = cl.SerializeObj(this.client, "ThongTinKhachHang", truyen);
                Entities.ThongTinKhachHang[] ddh = new Entities.ThongTinKhachHang[1];
                ddh = (Entities.ThongTinKhachHang[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh.Length > 0)
                {
                    dgvHieThi.DataSource = null;
                    hienthiKH = ddh;
                    dgvHieThi.DataSource = ddh;
                    fixKhachHang();
                }
                else
                {
                    Entities.ThongTinKhachHang[] lay = new Entities.ThongTinKhachHang[0];
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = lay;
                    fixKhachHang();
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.ThongTinKhachHang[] lay = new Entities.ThongTinKhachHang[0];
                dgvHieThi.DataSource = null;
                dgvHieThi.DataSource = lay;
                fixKhachHang();
            }
        }
        /// <summary>
        /// fix dgv khach hang
        /// </summary>
        private void fixKhachHang()
        {
            dgvHieThi.RowHeadersVisible = false;
            dgvHieThi.Columns[0].Visible = false;
            dgvHieThi.Columns[1].HeaderText = "Mã khách hàng";
            dgvHieThi.Columns[2].HeaderText = "Tên khách hàng";
            dgvHieThi.Columns[3].HeaderText = "Địa chỉ";
            dgvHieThi.Columns[4].HeaderText = "Dư nợ";
            dgvHieThi.Columns[4].Visible = false;
            groupBox1.Text = "Tìm thấy tổng số: " + (0 + dgvHieThi.RowCount) + " bản ghi";
            dgvHieThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHieThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        /// lay don dat hang
        /// </summary>
        private void BindingDonDatHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                ddhs = new Entities.ThongTinMaDonDatHang("Select");
                clientstrem = cl.SerializeObj(this.client, "ThongTinMaDonDatHang", ddhs);
                Entities.ThongTinMaDonDatHang[] ddh = new Entities.ThongTinMaDonDatHang[1];
                ddh = (Entities.ThongTinMaDonDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh.Length > 0)
                {
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = ddh;
                    fixDonDatHang();
                }
                else
                {
                    Entities.ThongTinMaDonDatHang[] lay = new Entities.ThongTinMaDonDatHang[0];
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = lay;
                    fixDonDatHang();
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.ThongTinMaDonDatHang[] lay = new Entities.ThongTinMaDonDatHang[0];
                dgvHieThi.DataSource = null;
                dgvHieThi.DataSource = lay;
                fixDonDatHang();
            }
        }
        /// <summary>
        /// fix don dat hang dgv
        /// </summary>
        private void fixDonDatHang()
        {
            try
            {
                dgvHieThi.RowHeadersVisible = false;
                dgvHieThi.Columns[0].Visible = false;
                dgvHieThi.Columns[1].HeaderText = "Mã hàng hóa";
                dgvHieThi.Columns[2].HeaderText = "Ngày lập";
                dgvHieThi.Columns[3].HeaderText = "Tổng Tiền";
                groupBox1.Text = "Tìm thấy tổng số: " + (0 + dgvHieThi.RowCount) + " bản ghi";
                dgvHieThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHieThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void LayThongTinHoaDonNhap(string ma)
        {
            try
            {
                Entities.ThongTinDatHang nhap = new Entities.ThongTinDatHang();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                nhap = new Entities.ThongTinDatHang("Select", ma);
                clientstrem = cl.SerializeObj(this.client, "LayThongTinHoaDonNhap", nhap);
                Entities.ThongTinDatHang[] ddh = new Entities.ThongTinDatHang[1];
                ddh = (Entities.ThongTinDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh.Length > 0)
                {
                    dgvHieThi.DataSource = null;
                    hienthiTTDH = ddh;
                    dgvHieThi.DataSource = ddh;
                    fixHoaDonNhap();
                }
                else
                {
                    Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = lay;
                    fixHoaDonNhap();
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                dgvHieThi.DataSource = null;
                dgvHieThi.DataSource = lay;
                fixHoaDonNhap();
            }
        }
        /// <summary>
        /// fix hoa don nhap
        /// </summary>
        private void fixHoaDonNhap()
        {
            try
            {
                for (int i = 0; i < dgvHieThi.ColumnCount; i++)
                { dgvHieThi.Columns[i].Visible = false; }
                dgvHieThi.Columns[1].Visible = true;
                dgvHieThi.Columns[2].Visible = true;
                dgvHieThi.Columns[3].Visible = true;
                dgvHieThi.Columns[1].HeaderText = "Mã đơn";
                dgvHieThi.Columns[2].HeaderText = "Ngày lập";
                dgvHieThi.Columns[3].HeaderText = "Ngày dự kiến";
                dgvHieThi.RowHeadersVisible = false;
                groupBox1.Text = "Tìm thấy tổng số: " + (0 + dgvHieThi.RowCount) + " bản ghi";
                dgvHieThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHieThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// lay hoa don ban hang
        /// </summary>
        /// <param name="ma"></param>
        private void LayHoaDonBanHang(string ma)
        {
            try
            {
                Entities.TruyenGiaTri nhap = new Entities.TruyenGiaTri();
                nhap.Hanhdong = "Select";
                nhap.Giatritruyen = ma;
                nhap.Giatrithuhai = GiaTriCanLuu.Giatri;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "ThongTinHoaDonBanHang", nhap);
                Entities.HienThi_KhachHangTraLai[] ddh = new Entities.HienThi_KhachHangTraLai[1];
                ddh = (Entities.HienThi_KhachHangTraLai[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length > 0)
                {
                    dgvHieThi.DataSource = null;
                    Entities.HienThi_KhachHangTraLai[] temp = new Entities.HienThi_KhachHangTraLai[ddh.Length];
                    int sl = 0;
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (ddh[i].MaKho == makho)
                        {
                            temp[sl] = ddh[i];
                            sl++;
                        }
                    }
                    ddh = new Entities.HienThi_KhachHangTraLai[sl];
                    for (int i = 0; i < sl; i++)
                    {
                        ddh[i] = temp[i];
                    }
                    hienthiKHTL = ddh;
                    dgvHieThi.DataSource = ddh;
                    fixHoaDonBanHang();
                }
                else
                {
                    Entities.HienThi_KhachHangTraLai[] lay = new Entities.HienThi_KhachHangTraLai[0];
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = lay;
                    fixHoaDonBanHang();
                }
                GiaTriCanLuu.Giatri = null;
                GiaTriCanLuu.Giatri2 = null;
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.HienThi_KhachHangTraLai[] lay = new Entities.HienThi_KhachHangTraLai[0];
                dgvHieThi.DataSource = null;
                dgvHieThi.DataSource = lay;
                fixHoaDonBanHang();
            }
        }
        /// <summary>
        /// tim hoa don ban hang
        /// </summary>
        private void fixHoaDonBanHang()
        {
            try
            {
                dgvHieThi.Columns[0].HeaderText = "Mã HDBH";
                dgvHieThi.Columns[1].HeaderText = "Ngày bán";
                dgvHieThi.Columns[2].HeaderText = "Tổng tiền";
                dgvHieThi.Columns[3].HeaderText = "Nợ hiện thời";
                dgvHieThi.Columns[3].Visible = false;
                dgvHieThi.RowHeadersVisible = false;
                groupBox1.Text = "Tìm thấy tổng số: " + (0 + dgvHieThi.RowCount) + " bản ghi";
                dgvHieThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHieThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary> hungvv
        /// lay don dat hang nha cung cap
        /// </summary>
        private void LayDonDatHangNhaCungCap()
        {
            try
            {
                Entities.ThongTinDatHang nhap;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                nhap = new Entities.ThongTinDatHang("Select");
                clientstrem = cl.SerializeObj(this.client, "LayDonDatHangNhaCungCap", nhap);
                Entities.ThongTinDatHang[] ddh = new Entities.ThongTinDatHang[1];
                ddh = (Entities.ThongTinDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length > 0)
                {
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = ddh;
                    fixDonDatHangNhaCungCap();
                }
                else
                {
                    Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = lay;
                    fixDonDatHangNhaCungCap();
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                dgvHieThi.DataSource = null;
                dgvHieThi.DataSource = lay;
                fixDonDatHangNhaCungCap();
            }
        }
        /// <summary>
        /// fix don dat hag nha cung cap
        /// </summary>
        private void fixDonDatHangNhaCungCap()
        {
            try
            {
                dgvHieThi.Columns[0].Visible = false;
                dgvHieThi.Columns[1].HeaderText = "Mã đơn";
                dgvHieThi.Columns[2].HeaderText = "Ngày đặt";
                dgvHieThi.Columns[3].HeaderText = "Tổng tiền";
                dgvHieThi.Columns[4].Visible = false;
                dgvHieThi.RowHeadersVisible = false;
                groupBox1.Text = "Tìm thấy tổng số: " + (0 + dgvHieThi.RowCount) + " bản ghi";
                dgvHieThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHieThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// tim hoa don nhap theo ma nha cung cap
        /// </summary>
        /// <param name="ma"></param>
        private void TimHoaDonNhapTheoMaNhaCungCap(string ma)
        {
            try
            {
                Entities.TruyenGiaTri nhap = new Entities.TruyenGiaTri();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                nhap.Hanhdong = "Select";
                nhap.Giatritruyen = ma;
                nhap.Giatrithuhai = "";
                clientstrem = cl.SerializeObj(this.client, "TimHoaDonNhapTheoMaNhaCungCap", nhap);
                Entities.HienThi_KhachHangTraLai[] ddh = new Entities.HienThi_KhachHangTraLai[1];
                ddh = (Entities.HienThi_KhachHangTraLai[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh.Length <= 0)
                {
                    Entities.HienThi_KhachHangTraLai[] lay = new Entities.HienThi_KhachHangTraLai[0];
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = lay;
                    fixDondathangtheomanhacungcap();
                }
                else
                {
                    dgvHieThi.DataSource = null;
                    Entities.HienThi_KhachHangTraLai[] temp = new Entities.HienThi_KhachHangTraLai[ddh.Length];
                    int sl = 0;
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (ddh[i].MaKho == makho)
                        {
                            temp[sl] = ddh[i];
                            sl++;
                        }
                    }
                    ddh = new Entities.HienThi_KhachHangTraLai[sl];
                    for (int i = 0; i < sl; i++)
                    {
                        ddh[i] = temp[i];
                    }
                    hienthiKHTL = ddh;
                    dgvHieThi.DataSource = ddh;
                    fixDondathangtheomanhacungcap();
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.HienThi_KhachHangTraLai[] lay = new Entities.HienThi_KhachHangTraLai[0];
                dgvHieThi.DataSource = null;
                dgvHieThi.DataSource = lay;
                fixDondathangtheomanhacungcap();
            }
        }
        private void fixDondathangtheomanhacungcap()
        {
            try
            {
                for (int i = 0; i < dgvHieThi.ColumnCount; i++)
                { dgvHieThi.Columns[i].Visible = false; }
                dgvHieThi.Columns[0].Visible = true;
                dgvHieThi.Columns[0].HeaderText = "Mã Hóa Đơn";
                dgvHieThi.Columns[1].Visible = true;
                dgvHieThi.Columns[1].HeaderText = "Ngày Nhập";
                dgvHieThi.Columns[2].Visible = true;
                dgvHieThi.Columns[2].HeaderText = "Tổng Tiền";
                dgvHieThi.Columns[3].HeaderText = "Nợ Hiện Thời";
                dgvHieThi.Columns[3].Visible = false;
                dgvHieThi.RowHeadersVisible = false;
                groupBox1.Text = "Tìm thấy tổng số: " + (0 + dgvHieThi.RowCount) + " bản ghi";
                dgvHieThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHieThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// tim hoa don ban hang theo ma khach hang
        /// </summary>
        /// <param name="makhachhang"></param>
        private void TimHoaDonBanHangTheoMaKhachHang(string makhachhang)
        {
            try
            {
                Entities.TruyenGiaTri nhap = new Entities.TruyenGiaTri();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                nhap.Hanhdong = "Select";
                nhap.Giatritruyen = makhachhang;
                nhap.Giatrithuhai = "";

                clientstrem = cl.SerializeObj(this.client, "TimHoaDonBanHangTheoMaKhachHang", nhap);
                Entities.HienThi_KhachHangTraLai[] ddh = new Entities.HienThi_KhachHangTraLai[1];
                ddh = (Entities.HienThi_KhachHangTraLai[])cl.DeserializeHepper(clientstrem, ddh);
                client.Close();
                clientstrem.Close();
                if (ddh.Length > 0)
                {
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = ddh;
                    fixTimhoadontheomakhachhang();
                }
                else
                {
                    Entities.HienThi_KhachHangTraLai[] lay = new Entities.HienThi_KhachHangTraLai[1];
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = lay;
                    fixTimhoadontheomakhachhang();
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.HienThi_KhachHangTraLai[] lay = new Entities.HienThi_KhachHangTraLai[1];
                dgvHieThi.DataSource = null;
                dgvHieThi.DataSource = lay;
                fixTimhoadontheomakhachhang();
            }
        }
        /// <summary>
        /// tim hoa don theo khach hang
        /// </summary>
        private void fixTimhoadontheomakhachhang()
        {
            try
            {
                dgvHieThi.Columns[0].HeaderText = "Mã Hóa Đơn";
                dgvHieThi.Columns[1].HeaderText = "Ngày Bán";
                dgvHieThi.Columns[2].HeaderText = "Tổng Tiền";
                dgvHieThi.Columns[3].HeaderText = "Nợ Hiện Thời";
                dgvHieThi.Columns[3].Visible = false;
                dgvHieThi.RowHeadersVisible = false;
                groupBox1.Text = "Tìm thấy tổng số: " + (0 + dgvHieThi.RowCount) + " bản ghi";
                dgvHieThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHieThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="manhacungcap"></param>
        private void ThongTinTraLaiNhaCungCap(string manhacungcap)
        {
            try
            {
                Entities.ThongTinDatHang nhap;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                nhap = new Entities.ThongTinDatHang("Select", manhacungcap);
                clientstrem = cl.SerializeObj(this.client, "ThongTinTraLaiNhaCungCap", nhap);
                Entities.ThongTinDatHang[] ddh = new Entities.ThongTinDatHang[1];
                ddh = (Entities.ThongTinDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh.Length > 0)
                {
                    send(ddh);
                    dgvHieThi.DataSource = null;
                    hienthiTTDH = ddh;
                    dgvHieThi.DataSource = ddh;
                    fixthongtintralainhacungcap();
                }
                else
                {
                    Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                    dgvHieThi.DataSource = lay;
                    fixthongtintralainhacungcap();
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                dgvHieThi.DataSource = lay;
                fixthongtintralainhacungcap();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void fixthongtintralainhacungcap()
        {
            try
            {
                for (int i = 0; i < dgvHieThi.ColumnCount; i++)
                { dgvHieThi.Columns[i].Visible = false; }
                dgvHieThi.Columns[1].Visible = true;
                dgvHieThi.Columns[1].HeaderText = "Mã hàng";
                dgvHieThi.Columns[2].Visible = true;
                dgvHieThi.Columns[2].HeaderText = "Tên hàng";

                dgvHieThi.Columns[3].HeaderText = "Giá nhập";
                dgvHieThi.Columns[4].Visible = true;
                dgvHieThi.Columns[4].HeaderText = "Số lượng";
                dgvHieThi.RowHeadersVisible = false;
                groupBox1.Text = "Tìm thấy tổng số: " + (0 + dgvHieThi.RowCount) + " bản ghi";
                dgvHieThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHieThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// lay hang hoa theo ma nha cung cap da dat hang
        /// </summary>
        private void LayChiTietTraLaiNhaCungCap(string manhacungcap)
        {
            try
            {
                Entities.ThongTinDatHang nhap;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                nhap = new Entities.ThongTinDatHang("Select", manhacungcap);
                clientstrem = cl.SerializeObj(this.client, "LayChiTietTraLaiNhaCungCap", nhap);
                Entities.ThongTinDatHang[] ddh = new Entities.ThongTinDatHang[1];
                ddh = (Entities.ThongTinDatHang[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh.Length > 0)
                {
                    dgvHieThi.DataSource = null;
                    dgvHieThi.DataSource = ddh;
                    fixChitiettralainhacungcap();
                }
                else
                {
                    Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                    dgvHieThi.DataSource = lay;
                    fixChitiettralainhacungcap();
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                dgvHieThi.DataSource = lay;
                fixChitiettralainhacungcap();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void fixChitiettralainhacungcap()
        {
            try
            {
                for (int i = 0; i < dgvHieThi.ColumnCount; i++)
                { dgvHieThi.Columns[i].Visible = false; }
                dgvHieThi.Columns[1].Visible = true;
                dgvHieThi.Columns[1].HeaderText = "Mã hàng";
                dgvHieThi.Columns[2].Visible = true;
                dgvHieThi.Columns[2].HeaderText = "Tên hàng";
                dgvHieThi.Columns[3].Visible = true;
                dgvHieThi.Columns[3].HeaderText = "Giá nhập";
                dgvHieThi.RowHeadersVisible = false;
                groupBox1.Text = "Tìm thấy tổng số: " + (0 + dgvHieThi.RowCount) + " bản ghi";
                dgvHieThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHieThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion
        #region------------------------------------------------xu ly------------------------------------------------------------------
        private void frmTraCuu_Load(object sender, EventArgs e)
        {
            try { DieuKienForm(); }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
        private void TraveLoai()
        {
            try
            {
                if (names == "Lay_HangHoa_GoiHang")
                {
                    GiaTriCanLuu.Loaitrave = "Lay_HangHoa_GoiHang";
                    frmXuLyNhapKho fr = new frmXuLyNhapKho();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }
                if (names == "DonDatHang_HangHoa")
                {
                    GiaTriCanLuu.Loaitrave = "DonDatHang_HangHoa";
                    frmXuLyDonDatHang fr = new frmXuLyDonDatHang();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }

                if (names == "HoaDonDat_HangHoa")
                {
                    GiaTriCanLuu.Loaitrave = "HoaDonDat_HangHoa";
                    frmXuLyNhapKho fr = new frmXuLyNhapKho();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }

                if (names == "DonDatHang_NhaCungCap")
                {
                    GiaTriCanLuu.Loaitrave = "DonDatHang_NhaCungCap";
                    frmXuLyDonDatHang fr = new frmXuLyDonDatHang();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }

                if (names == "HoaDonNhap_NhaCungCap")
                {
                    GiaTriCanLuu.Loaitrave = "HoaDonNhap_NhaCungCap";
                    frmXuLyNhapKho fr = new frmXuLyNhapKho();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }
                if (names == "ThongTin_KhachHangTraLai")
                {
                    GiaTriCanLuu.Loaitrave = "ThongTin_KhachHangTraLai";
                    frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }
                if (names == "HoaDonNhap_DonDatHang")
                {
                    GiaTriCanLuu.Loaitrave = "HoaDonNhap_DonDatHang";
                    frmXuLyNhapKho fr = new frmXuLyNhapKho();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }
                if (names == "HangTraLai_KhachHangTraLai_MaDonHang")
                {
                    GiaTriCanLuu.Loaitrave = "HangTraLai_KhachHangTraLai_MaDonHang";
                    frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }
                if (names == "HangTraLai_KhachHangTraLai_KhachHang")
                {
                    GiaTriCanLuu.Loaitrave = "HangTraLai_KhachHangTraLai_KhachHang";
                    frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }

                if (names == "HangTraLai_TraLaiNhaCungCap")
                {
                    GiaTriCanLuu.Loaitrave = "HangTraLai_TraLaiNhaCungCap";
                    frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }

                if (names == "ChiTietKhachHangTraLaiHang_HangHoa")
                {
                    GiaTriCanLuu.Loaitrave = "ChiTietKhachHangTraLaiHang_HangHoa";
                    frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }
                if (names == "ChiTietTraLaiNhaCungCap_MaHangHoa")
                {
                    GiaTriCanLuu.Loaitrave = "ChiTietTraLaiNhaCungCap_MaHangHoa";
                    frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }
                if (names == "HoaDonNhap_MaDonDatHang")
                {
                    GiaTriCanLuu.Loaitrave = "HoaDonNhap_MaDonDatHang";
                    frmXuLyNhapKho fr = new frmXuLyNhapKho();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }

                if (names == "KiemKeKho_HangHoa")
                {
                    GiaTriCanLuu.Loaitrave = "KiemKeKho_HangHoa";
                    frmXuLyKiemKeKho fr = new frmXuLyKiemKeKho();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }
                if (names == "HangTraLai_DonDatHangNhaCungCap")
                {
                    GiaTriCanLuu.Loaitrave = "HangTraLai_DonDatHangNhaCungCap";
                    frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }
                if (names == "HangTraLai_MaTraLaiNhaCungCap")
                {
                    GiaTriCanLuu.Loaitrave = "HangTraLai_MaTraLaiNhaCungCap";
                    frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }
                if (names == "XuLyKhachHang")
                {
                    GiaTriCanLuu.Loaitrave = "XuLyKhachHang";
                    frmXuLyKhachHang fr = new frmXuLyKhachHang();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }
                if (names == "DonDatHang_KhachHang")
                {
                    GiaTriCanLuu.Loaitrave = "DonDatHang_KhachHang";
                    frmXuLyDonDatHang fr = new frmXuLyDonDatHang();
                    Application.OpenForms[fr.Name].Focus();
                    this.Close();
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void toolStripStatus_Huybo_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        TraveLoai();
                        this.Close();
                    }
                    else
                    { }
                }
            }
            catch (Exception ex) { string s = ex.Message; }
        }
        private void BindingHangHoaGoiHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.HangHoaGoiHang values = new Entities.HangHoaGoiHang();
                values.Hanhdong = "Select";
                clientstrem = cl.SerializeObj(this.client, "LayHangHoaGoiHang", values);
                Entities.HangHoaGoiHang[] hhgh = new Entities.HangHoaGoiHang[1];
                hhgh = (Entities.HangHoaGoiHang[])cl.DeserializeHepper(clientstrem, hhgh);
                if (hhgh.Length > 0)
                {
                    dgvHieThi.DataSource = hhgh;
                    fixHangHoa();
                }
                else
                {
                    Entities.HangHoaGoiHang[] lay = new Entities.HangHoaGoiHang[0];
                    dgvHieThi.DataSource = lay;
                    FixHangHoaGoiHang();
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Entities.ThongTinDatHang[] lay = new Entities.ThongTinDatHang[0];
                dgvHieThi.DataSource = null;
                dgvHieThi.DataSource = lay;
                FixHangHoaGoiHang();
            }
        }
        private void FixHangHoaGoiHang()
        {
            dgvHieThi.Columns["HanhDong"].Visible = false;
            dgvHieThi.RowHeadersVisible = false;
            dgvHieThi.Columns["MaHang"].HeaderText = "Mã hàng";
            dgvHieThi.Columns["TenHang"].HeaderText = "Tên hàng";
            dgvHieThi.Columns["GiaBanBuon"].Visible = false;
            dgvHieThi.Columns["GiaBanLe"].Visible = false;
            dgvHieThi.Columns["GiaNhap"].Visible = false;
            dgvHieThi.Columns["Thue"].Visible = false;
            dgvHieThi.Columns["HangHoa"].Visible = false;
            dgvHieThi.Columns["GoiHang"].Visible = false;
            groupBox1.Text = "Tìm thấy tổng số: " + (0 + dgvHieThi.RowCount) + " bản ghi";
            dgvHieThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHieThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        /// <summary>
        /// hungvv ==================================================
        /// </summary>
        private void DieuKienForm()
        {
            try
            {
                frmTraCuu fr = new frmTraCuu();
                if (hanhdong == "LayHangHoaGoiHang")
                {
                    BindingHangHoaGoiHang();
                    Application.OpenForms[fr.Name].Text = "Lọc - Hàng hóa và gói hàng";
                }
                if (hanhdong == "HangHoaTraLai")
                {
                    BindingHangHoaTraLai(this.maNhaCungCap, loai);
                    Application.OpenForms[fr.Name].Text = "Lọc - Hàng hóa theo hóa đơn bán hàng";
                }
                if (hanhdong == "HangHoa")
                {
                    BindingHangHoa();
                    Application.OpenForms[fr.Name].Text = "Lọc - Hàng hóa";
                }
                if (hanhdong == "NhaCungCap")
                {
                    BindingNhaCungCap();
                    Application.OpenForms[fr.Name].Text = "Lọc - Nhà cung cấp";
                }
                if (hanhdong == "KhachHang")
                {
                    BindingKhachHang("");
                    Application.OpenForms[fr.Name].Text = "Lọc - Khách hàng";
                }
                if (hanhdong == "KhachHangTralaiHang")
                {
                    BindingKhachHangTralaiHang(this.maNhaCungCap);
                    Application.OpenForms[fr.Name].Text = "Lọc - Khách hàng";
                }
                if (hanhdong == "HoaDonNhap")
                {
                    BindingNhaCungCap();
                    Application.OpenForms[fr.Name].Text = "Lọc - Hoa đơn nhập";
                }
                if (hanhdong == "DonDatHang")
                {
                    BindingDonDatHang();
                    Application.OpenForms[fr.Name].Text = "Lọc - Đơn đặt hàng";
                }
                if (hanhdong == "HoaDonHangHoa")
                {
                    BindingHangHoa();
                    Application.OpenForms[fr.Name].Text = "Lọc - Hóa đơn hàng hóa";
                }
                if (hanhdong == "MaDonDatHang")
                {
                    LayThongTinHoaDonNhap(this.maNhaCungCap);
                    Application.OpenForms[fr.Name].Text = "Lọc - Đơn đặt hàng";
                }
                if (hanhdong == "HoaDonBanHang")
                {
                    LayHoaDonBanHang(this.maNhaCungCap);
                    Application.OpenForms[fr.Name].Text = "Lọc - Hóa đơn bán hàng";
                }

                if (hanhdong == "DonDatHangNhaCungCap")
                {
                    LayDonDatHangNhaCungCap();
                    Application.OpenForms[fr.Name].Text = "Lọc - Đơn đặt hàng nhà cung cấp";
                }
                if (hanhdong == "LayChiTietTraLaiNhaCungCap")
                {
                    LayChiTietTraLaiNhaCungCap(this.maNhaCungCap);
                    Application.OpenForms[fr.Name].Text = "Lọc - Đơn đặt hàng nhà cung cấp";
                }
                if (hanhdong == "TimHoaDonBanHangTheoMaKhachHang")
                {
                    TimHoaDonBanHangTheoMaKhachHang(this.maNhaCungCap);
                    Application.OpenForms[fr.Name].Text = "Lọc - Hóa Đơn Bán Hàng Theo Mã Khách Hàng";
                }
                if (hanhdong == "TimHoaDonNhapTheoMa")
                {
                    TimHoaDonNhapTheoMaNhaCungCap(this.maNhaCungCap);
                    Application.OpenForms[fr.Name].Text = "Lọc - Hóa Đơn Nhập Theo Mã Nhà Cung Cấp";
                }
                if (hanhdong == "ThongTinTraLaiNhaCungCap")
                {
                    ThongTinTraLaiNhaCungCap(this.maNhaCungCap);
                    Application.OpenForms[fr.Name].Text = "Lọc - Hàng hóa theo hóa đơn nhập";
                }
                if (hanhdong == "KiemKeHangHoa")
                {
                    KiemKeHangHoa(this.maNhaCungCap);
                    Application.OpenForms[fr.Name].Text = "Lọc - Hàng hóa theo kho hàng";
                }
                if (hanhdong == "HangHoaTheoKho")
                {
                    BindingHangHoaTheoMaKho(this.maNhaCungCap);
                    Application.OpenForms[fr.Name].Text = "Lọc - Hàng hóa theo kho hàng";
                }

            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        /// <summary>
        /// hungvv ==========================tra lai gia tri form chinh
        /// </summary>
        private int vitri = 0;
        private void TraVe()
        {
            try
            {
                if (names == "Lay_HangHoa_GoiHang")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        string ID = dgvHieThi.Rows[vitri].Cells["MaHang"].Value.ToString();
                        string Name = dgvHieThi.Rows[vitri].Cells["TenHang"].Value.ToString();
                        string Gia = dgvHieThi.Rows[vitri].Cells["GiaNhap"].Value.ToString();
                        string banbuon = dgvHieThi.Rows[vitri].Cells["GiaBanBuon"].Value.ToString();
                        string banle = dgvHieThi.Rows[vitri].Cells["GiaBanLe"].Value.ToString();
                        string giatrigiatang = dgvHieThi.Rows[vitri].Cells["Thue"].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "Lay_HangHoa_GoiHang";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.Giatri = Gia;
                        GiaTriCanLuu.Giatri2 = banbuon;
                        GiaTriCanLuu.TonKho = banle;
                        GiaTriCanLuu.giatrigiatang = giatrigiatang;
                        frmXuLyNhapKho fr = new frmXuLyNhapKho();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }
                if (names == "DonDatHang_HangHoa")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        GiaTriCanLuu.Loaitrave = "DonDatHang_HangHoa";
                        string ID = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string Name = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        string Gia = dgvHieThi.Rows[vitri].Cells[3].Value.ToString();
                        string banbuon = dgvHieThi.Rows[vitri].Cells[5].Value.ToString();
                        string banle = dgvHieThi.Rows[vitri].Cells[6].Value.ToString();
                        string giatrigiatang = dgvHieThi.Rows[vitri].Cells[7].Value.ToString();
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.Giatri = Gia;
                        GiaTriCanLuu.Giatri2 = banbuon;
                        GiaTriCanLuu.TonKho = banle;
                        GiaTriCanLuu.giatrigiatang = giatrigiatang;
                        frmXuLyDonDatHang fr = new frmXuLyDonDatHang();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }
                if (names == "HoaDonDat_HangHoa")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        string ID = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string Name = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        string Gia = dgvHieThi.Rows[vitri].Cells[3].Value.ToString();
                        string banbuon = dgvHieThi.Rows[vitri].Cells[5].Value.ToString();
                        string banle = dgvHieThi.Rows[vitri].Cells[6].Value.ToString();
                        string giatrigiatang = dgvHieThi.Rows[vitri].Cells[7].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "HoaDonDat_HangHoa";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.Giatri = Gia;
                        GiaTriCanLuu.Giatri2 = banbuon;
                        GiaTriCanLuu.TonKho = banle;
                        GiaTriCanLuu.giatrigiatang = giatrigiatang;
                        frmXuLyNhapKho fr = new frmXuLyNhapKho();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }

                if (names == "DonDatHang_NhaCungCap")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        string ID = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string Name = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        string add = dgvHieThi.Rows[vitri].Cells[3].Value.ToString();
                        string giatri = dgvHieThi.Rows[vitri].Cells[4].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "DonDatHang_NhaCungCap";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.Giatri = add;
                        GiaTriCanLuu.Giatri2 = giatri;
                        frmXuLyDonDatHang fr = new frmXuLyDonDatHang();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }

                if (names == "HoaDonNhap_NhaCungCap")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        string ID = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string Name = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        string add = dgvHieThi.Rows[vitri].Cells[3].Value.ToString();
                        string no = dgvHieThi.Rows[vitri].Cells[4].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "HoaDonNhap_NhaCungCap";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.Giatri = add;
                        GiaTriCanLuu.TonKho = no;
                        frmXuLyNhapKho fr = new frmXuLyNhapKho();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }
                if (names == "ThongTin_KhachHangTraLai")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        string ID = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string Name = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        string add = dgvHieThi.Rows[vitri].Cells[3].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "ThongTin_KhachHangTraLai";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.Giatri = add;
                        frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }
                if (names == "HoaDonNhap_DonDatHang")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        string ID = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string Name = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        string add = dgvHieThi.Rows[vitri].Cells[3].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "HoaDonNhap_DonDatHang";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.Giatri = add;
                        frmXuLyNhapKho fr = new frmXuLyNhapKho();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }
                if (names == "HangTraLai_KhachHangTraLai_MaDonHang")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        string ID = dgvHieThi.Rows[vitri].Cells[0].Value.ToString();
                        string Name = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string add = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "HangTraLai_KhachHangTraLai_MaDonHang";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.Giatri = add;
                        frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }
                if (names == "HangTraLai_KhachHangTraLai_KhachHang")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        string ID = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string Name = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        string duno = dgvHieThi.Rows[vitri].Cells[4].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "HangTraLai_KhachHangTraLai_KhachHang";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.Giatri2 = duno;
                        frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }

                if (names == "HangTraLai_TraLaiNhaCungCap")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        string ID = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string Name = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        string add = dgvHieThi.Rows[vitri].Cells[3].Value.ToString();
                        string nohienthoi = dgvHieThi.Rows[vitri].Cells[4].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "HangTraLai_TraLaiNhaCungCap";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.Giatri = add;
                        GiaTriCanLuu.Giatri2 = nohienthoi;
                        frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }

                if (names == "ChiTietKhachHangTraLaiHang_HangHoa")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        frmXuLyHangTraLai.soluongmua = doituong;
                        string ID = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string Name = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        string add = dgvHieThi.Rows[vitri].Cells[3].Value.ToString();
                        string sl = dgvHieThi.Rows[vitri].Cells[4].Value.ToString();
                        string giatrigiatrang = dgvHieThi.Rows[vitri].Cells[7].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "ChiTietKhachHangTraLaiHang_HangHoa";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.Giatri = add;
                        GiaTriCanLuu.Giatri2 = sl;
                        GiaTriCanLuu.giatrigiatang = giatrigiatrang;
                        frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }
                if (names == "ChiTietTraLaiNhaCungCap_MaHangHoa")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        frmXuLyHangTraLai.soluongmua = doituong;
                        string ID = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string Name = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        string add = dgvHieThi.Rows[vitri].Cells[3].Value.ToString();
                        string sl = dgvHieThi.Rows[vitri].Cells[4].Value.ToString();
                        string g = dgvHieThi.Rows[vitri].Cells[5].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "ChiTietTraLaiNhaCungCap_MaHangHoa";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.Giatri = add;
                        GiaTriCanLuu.makhachhang = sl;
                        GiaTriCanLuu.giatrigiatang = g;
                        frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }
                if (names == "HoaDonNhap_MaDonDatHang")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        string ID = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string Name = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        string add = dgvHieThi.Rows[vitri].Cells[3].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "HoaDonNhap_MaDonDatHang";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.Giatri = add;
                        frmXuLyNhapKho fr = new frmXuLyNhapKho();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }

                if (names == "KiemKeKho_HangHoa")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        int temVITRI = dgvHieThi.CurrentRow.Index;
                        string ID = dgvHieThi.Rows[temVITRI].Cells["MaHangHoa"].Value.ToString();
                        string Name = dgvHieThi.Rows[temVITRI].Cells["TenHangHoa"].Value.ToString();
                        string add = dgvHieThi.Rows[temVITRI].Cells["GiaNhap"].Value.ToString();
                        string ton = dgvHieThi.Rows[temVITRI].Cells["Tonkho"].Value.ToString();
                        string sl = dgvHieThi.Rows[temVITRI].Cells["Tonkho"].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "KiemKeKho_HangHoa";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.TonKho = ton;
                        GiaTriCanLuu.Giatri2 = sl;
                        GiaTriCanLuu.Giatri = add;
                        frmXuLyKiemKeKho fr = new frmXuLyKiemKeKho();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }
                ///-------------------------------------------------------------------
                if (names == "DonDatHang_HangHoaTheoKho")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        GiaTriCanLuu.Loaitrave = "DonDatHang_HangHoaTheoKho";
                        string ID = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string Name = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        string Gia = dgvHieThi.Rows[vitri].Cells[3].Value.ToString();
                        string banbuon = dgvHieThi.Rows[vitri].Cells[5].Value.ToString();
                        string banle = dgvHieThi.Rows[vitri].Cells[6].Value.ToString();
                        string giatrigiatang = dgvHieThi.Rows[vitri].Cells[7].Value.ToString();
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.Giatri = Gia;
                        GiaTriCanLuu.Giatri2 = banbuon;
                        GiaTriCanLuu.TonKho = banle;
                        GiaTriCanLuu.giatrigiatang = giatrigiatang;
                        frmXuLyDonDatHang fr = new frmXuLyDonDatHang();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }

                if (names == "HangTraLai_DonDatHangNhaCungCap")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        string ID = dgvHieThi.Rows[vitri].Cells[0].Value.ToString();
                        string ngay = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "HangTraLai_DonDatHangNhaCungCap";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = ngay;
                        frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }
                if (names == "HangTraLai_MaTraLaiNhaCungCap")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        string ID = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string ngay = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "HangTraLai_MaTraLaiNhaCungCap";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = ngay;
                        frmXuLyHangTraLai fr = new frmXuLyHangTraLai();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }
                if (names == "XuLyKhachHang")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        string ID = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string ngay = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "XuLyKhachHang";
                        GiaTriCanLuu.Ma = ID;
                        frmXuLyKhachHang fr = new frmXuLyKhachHang();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }
                if (names == "DonDatHang_KhachHang")
                {
                    int x = dgvHieThi.RowCount;
                    int y = dgvHieThi.ColumnCount;
                    if (y <= -1 || x <= -1)
                    { }
                    else
                    {
                        string ID = dgvHieThi.Rows[vitri].Cells[1].Value.ToString();
                        string Name = dgvHieThi.Rows[vitri].Cells[2].Value.ToString();
                        string duno = dgvHieThi.Rows[vitri].Cells[4].Value.ToString();
                        GiaTriCanLuu.Loaitrave = "DonDatHang_KhachHang";
                        GiaTriCanLuu.Ma = ID;
                        GiaTriCanLuu.Ten = Name;
                        GiaTriCanLuu.Giatri2 = duno;
                        frmXuLyDonDatHang fr = new frmXuLyDonDatHang();
                        Application.OpenForms[fr.Name].Focus();
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }

        private void toolStripStatus_Chapnhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHieThi.RowCount > 0)
                {
                    vitri = dgvHieThi.CurrentRow.Index;
                    TraVe();
                }
                else
                { TraveLoai(); }
            }
            catch (Exception ex)
            { string s = ex.Message; }

        }

        private void dgvHieThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHieThi.RowCount > 0)
                {
                    vitri = 0;
                    vitri = dgvHieThi.CurrentRow.Index;
                    TraVe();
                }
                else
                { TraveLoai(); }
            }
            catch (Exception ex) { string s = ex.Message; }
        }
        #endregion

        private void dgvHieThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                vitri = 0;
                vitri = e.RowIndex;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void dgvHieThi_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.names.Equals("KiemKeKho_HangHoa"))
            {
                try
                {
                    vitri = dgvHieThi.CurrentRow.Index;
                }
                catch (Exception ex)
                { string s = ex.Message; }
                //try
                //{
                //    if (dgvHieThi.RowCount > 0)
                //    {
                //        vitri = dgvHieThi.CurrentRow.Index;
                //        TraVe();
                //    }
                //    else
                //    { TraveLoai(); }
                //}
                //catch (Exception ex)
                //{ string s = ex.Message; }
            }
            else
            {
                try
                {
                    vitri = dgvHieThi.CurrentRow.Index + 1;
                }
                catch (Exception ex)
                { string s = ex.Message; }
            }
        }

        private void dgvHieThi_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    this.vitri = dgvHieThi.SelectedRows[0].Index;
                    TraVe();
                }
                else
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex) { string s = ex.Message; }
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

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if ((names.Equals("HoaDonNhap_NhaCungCap") && hanhdong.Equals("HoaDonNhap")) || (names.Equals("HangTraLai_TraLaiNhaCungCap") && hanhdong.Equals("NhaCungCap")) || (names.Equals("DonDatHang_NhaCungCap") && hanhdong.Equals("NhaCungCap")))
                {
                    string Search = txttimkiem.Text;
                    List<Entities.ThongTinNhaCungCap> ketqua = new List<Entities.ThongTinNhaCungCap>();
                    foreach (Entities.ThongTinNhaCungCap item in hienthiNCC)
                    {
                        int test = -1;
                        if (rdbtimkiem1.Checked)    //Tìm Kiếm Theo Mã
                        {
                            test = item.Manhacungcap.ToLower().IndexOf(Search.ToLower());
                        }
                        else if (rdbtimkiem2.Checked)   //Tìm Kiếm Theo Tên
                        {
                            test = item.Tennhacungcap.ToLower().IndexOf(Search.ToLower());
                        }
                        if (test >= 0)
                        {
                            ketqua.Add(item);
                        }
                    }
                    dgvHieThi.DataSource = ketqua.ToArray();
                }
                else if ((names.Equals("HangTraLai_KhachHangTraLai_KhachHang") && hanhdong.Equals("KhachHangTralaiHang")) || (names.Equals("DonDatHang_KhachHang") && hanhdong.Equals("KhachHang")))
                {
                    string Search = txttimkiem.Text;
                    List<Entities.ThongTinKhachHang> ketqua = new List<Entities.ThongTinKhachHang>();
                    foreach (Entities.ThongTinKhachHang item in hienthiKH)
                    {
                        int test = -1;
                        if (rdbtimkiem1.Checked)    //Tìm Kiếm Theo Mã
                        {
                            test = item.Makhachhang.ToLower().IndexOf(Search.ToLower());
                        }
                        else if (rdbtimkiem2.Checked)   //Tìm Kiếm Theo Tên
                        {
                            test = item.Tenkhachhang.ToLower().IndexOf(Search.ToLower());
                        }
                        if (test >= 0)
                        {
                            ketqua.Add(item);
                        }
                    }
                    dgvHieThi.DataSource = ketqua.ToArray();
                }
                else if ((names.Equals("HangTraLai_DonDatHangNhaCungCap") && hanhdong.Equals("TimHoaDonNhapTheoMa")) || (names.Equals("HangTraLai_KhachHangTraLai_MaDonHang") && hanhdong.Equals("HoaDonBanHang")))
                {
                    string Search = txttimkiem.Text;
                    List<Entities.HienThi_KhachHangTraLai> ketqua = new List<Entities.HienThi_KhachHangTraLai>();
                    foreach (Entities.HienThi_KhachHangTraLai item in hienthiKHTL)
                    {
                        int test = -1;
                        if (rdbtimkiem1.Checked)    //Tìm Kiếm Theo Mã
                        {
                            test = item.Mahoadonbanhang.ToLower().IndexOf(Search.ToLower());
                        }
                        else if (rdbtimkiem2.Checked)   //Tìm Kiếm Theo Tên
                        {
                            test = item.Ngayban.ToString().ToLower().IndexOf(Search.ToLower());
                        }
                        if (test >= 0)
                        {
                            ketqua.Add(item);
                        }
                    }
                    dgvHieThi.DataSource = ketqua.ToArray();
                }
                else if ((names.Equals("ChiTietTraLaiNhaCungCap_MaHangHoa") && hanhdong.Equals("ThongTinTraLaiNhaCungCap")) || (names.Equals("ChiTietKhachHangTraLaiHang_HangHoa") && hanhdong.Equals("HangHoaTraLai")) || (names.Equals("HoaDonDat_HangHoa") && hanhdong.Equals("HoaDonHangHoa")))
                {
                    string Search = txttimkiem.Text;
                    List<Entities.ThongTinDatHang> ketqua = new List<Entities.ThongTinDatHang>();
                    foreach (Entities.ThongTinDatHang item in hienthiTTDH)
                    {
                        int test = -1;
                        if (rdbtimkiem1.Checked)    //Tìm Kiếm Theo Mã
                        {
                            test = item.MaHangHoa.ToLower().IndexOf(Search.ToLower());
                        }
                        else if (rdbtimkiem2.Checked)   //Tìm Kiếm Theo Tên
                        {
                            test = item.TenHangHoa.ToString().ToLower().IndexOf(Search.ToLower());
                        }
                        if (test >= 0)
                        {
                            ketqua.Add(item);
                        }
                    }
                    dgvHieThi.DataSource = ketqua.ToArray();
                }
                // Kiem ke kho
                else if (names.Equals("KiemKeKho_HangHoa") && hanhdong.Equals("KiemKeHangHoa"))
                {
                    string Search = txttimkiem.Text;
                    List<Entities.ThongTinDatHang> ketqua = new List<Entities.ThongTinDatHang>();
                    foreach (Entities.ThongTinDatHang item in hienthiTTDH)
                    {
                        int test = -1;
                        if (rdbtimkiem1.Checked)    //Tìm Kiếm Theo Mã
                        {
                            test = item.MaHangHoa.ToLower().IndexOf(Search.ToLower());
                        }
                        else if (rdbtimkiem2.Checked)   //Tìm Kiếm Theo Tên
                        {
                            test = item.TenHangHoa.ToString().ToLower().IndexOf(Search.ToLower());
                        }
                        if (test >= 0)
                        {
                            ketqua.Add(item);
                        }
                    }
                    dgvHieThi.DataSource = ketqua.ToArray();
                }

            }
            catch { }
        }
    }
}
