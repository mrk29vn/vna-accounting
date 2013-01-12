using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmXuLyHangHoa : Form
    {
        #region Khuyen mai thoe so luong
        Entities.KhuyenMaiSoLuong[] source = null;

        /// <summary>
        /// ValidateKM
        /// </summary>
        /// <returns></returns>
        public bool ValidateDataKM()
        {
            bool retVal = true;
            try
            {
                // so luong
                if (string.IsNullOrEmpty(txtSoLuongKM.Text))
                {
                    MessageBox.Show("Số lượng không được để trống", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                    txtSoLuongKM.Focus();
                    txtSoLuongKM.SelectAll();
                    return false;
                }

                try
                {
                    double sl = double.Parse(txtSoLuongKM.Text);
                }
                catch
                {
                    MessageBox.Show("Số lượng phải là số", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                    txtSoLuongKM.Focus();
                    txtSoLuongKM.SelectAll();
                    return false;
                }

                // Gia ban le
                if (string.IsNullOrEmpty(txtKMGiaBanLe.Text))
                {
                    MessageBox.Show("Giá bán lẻ không được để trống", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                    txtKMGiaBanLe.Focus();
                    txtKMGiaBanLe.SelectAll();
                    return false;
                }

                try
                {
                    double banLe = double.Parse(txtKMGiaBanLe.Text);
                }
                catch
                {
                    MessageBox.Show("Giá bán lẻ phải là số", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                    txtKMGiaBanLe.Focus();
                    txtKMGiaBanLe.SelectAll();
                    return false;
                }
                // Gia ban buon
                if (!string.IsNullOrEmpty(txtKMGiaBanBuon.Text))
                {
                    try
                    {
                        double banBuon = double.Parse(txtKMGiaBanBuon.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Giá bán buôn phải là số", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                        txtKMGiaBanBuon.Focus();
                        txtKMGiaBanBuon.SelectAll();
                        return false;
                    }
                }
                // ngay bat dau
                if (!(checkDateTime(txtKMBD.Text)).Equals("true"))
                {
                    MessageBox.Show("Ngày bắt đầu sai định dạng", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                    txtKMBD.Focus();
                    txtKMBD.SelectAll();
                    return false;
                }
                // ngay ket thuc
                if (!(checkDateTime(txtKMKT.Text)).Equals("true"))
                {
                    MessageBox.Show("Ngày kết thúc sai định dạng", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                    txtKMKT.Focus();
                    txtKMKT.SelectAll();
                    return false;
                }
                // ngay bat đầu phải nhỏ hơn ngày kết thúc
                DateTime bd = ConvertDatetime(txtKMBD.Text);
                DateTime ketThuc = ConvertDatetime(txtKMKT.Text);

                if (bd.Date > ketThuc.Date)
                {
                    MessageBox.Show("Ngày băt đầu phải nhỏ hơn ngày kết thúc", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                    txtKMBD.Focus();
                    txtKMBD.SelectAll();
                    return false;
                }
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }

        /// <summary>
        /// CheckKhoangTime
        /// </summary>
        /// <param name="kmsl"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public string CheckKhoangTime(Entities.KhuyenMaiSoLuong kmsl, Entities.KhuyenMaiSoLuong[] source)
        {
            string retVal = string.Empty;
            try
            {
                if (source == null)
                    return string.Empty;

                Entities.KhuyenMaiSoLuong[] result = null;
                //// Trung nhau thi khong duoc tao
                //var query1 = from item in source
                //             let a = item.NgayBatDau.Date.Equals(kmsl.NgayBatDau.Date)
                //             let b = item.NgayKetThuc.Date.Equals(kmsl.NgayKetThuc.Date)
                //             where a && b
                //             select item;

                //result = query1.ToArray();

                //if (result != null && result.Length > 0)
                //    return "trung";
                // Trung nhau 1 phan
                var query2 = from item in source
                             let a = (kmsl.NgayBatDau.Date < item.NgayBatDau.Date) && (kmsl.NgayKetThuc.Date >= item.NgayBatDau.Date) && (kmsl.NgayKetThuc.Date <= item.NgayKetThuc.Date)
                             let b = (kmsl.NgayKetThuc.Date > item.NgayKetThuc.Date) && (kmsl.NgayBatDau.Date >= item.NgayBatDau.Date) && (kmsl.NgayBatDau.Date <= item.NgayKetThuc.Date)
                             let c = (kmsl.NgayBatDau.Date > item.NgayBatDau.Date) && (kmsl.NgayKetThuc.Date < item.NgayKetThuc.Date)
                             let d = item.SoLuong.Equals(kmsl.SoLuong)
                             let e = item.NgayBatDau.Date.Equals(kmsl.NgayBatDau.Date) && item.NgayKetThuc.Date.Equals(kmsl.NgayKetThuc.Date)
                             where (a || b || c || e) && d
                             select item;

                result = query2.ToArray();

                if (result != null && result.Length > 0)
                    return "trungmotphan";
                // Khac nhau
                var query3 = from item in source
                             let a = kmsl.NgayKetThuc.Date > item.NgayBatDau.Date
                             let b = kmsl.NgayBatDau.Date > item.NgayKetThuc.Date
                             select item;

                result = query3.ToArray();

                if (result != null && result.Length > 0)
                    return "khac";
            }
            catch
            {
                retVal = string.Empty;
            }

            return retVal;
        }

        /// <summary>
        /// GetData
        /// </summary>
        /// <param name="maHangHoa"></param>
        /// <returns></returns>
        public Entities.KhuyenMaiSoLuong[] GetData(string maHangHoa)
        {
            Entities.KhuyenMaiSoLuong[] retVal = null;
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.KhuyenMaiSoLuong item = new Entities.KhuyenMaiSoLuong();
                // truyền HanhDong
                item = new Entities.KhuyenMaiSoLuong();
                item.HanhDong = "Select";
                item.MaHangHoa = maHangHoa.Trim().ToUpper();
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.KhuyenMaiSoLuong[] item1 = new Entities.KhuyenMaiSoLuong[1];
                clientstrem = cl.SerializeObj(this.client1, "KhuyenMaiSoLuong", item);
                // đổ mảng đối tượng vào datagripview       
                item1 = (Entities.KhuyenMaiSoLuong[])cl.DeserializeHepper1(clientstrem, item1);
                // Gan gia tri
                retVal = item1;
            }
            catch
            {
                retVal = null;
            }

            return retVal;
        }

        /// <summary>
        /// SetData
        /// </summary>
        /// <param name="item"></param>
        public void SetData(Entities.KhuyenMaiSoLuong item)
        {
            try
            {
                txtKMBD.Text = item.NgayBatDau.ToString("dd/MM/yyyy");
                txtKMKT.Text = item.NgayKetThuc.ToString("dd/MM/yyyy");
                txtSoLuongKM.Text = item.SoLuong.ToString();
                txtKMGiaBanBuon.Text = item.GiaBanBuon.ToString();
                txtKMGiaBanLe.Text = item.GiaBanLe.ToString();
            }
            catch
            {
            }
        }

        /// <summary>
        /// AddToList
        /// </summary>
        /// <param name="item"></param>
        public void AddToList(Entities.KhuyenMaiSoLuong item)
        {
            try
            {
                Entities.KhuyenMaiSoLuong[] source = (Entities.KhuyenMaiSoLuong[])grvKhuyenMaiSL.DataSource;
                List<Entities.KhuyenMaiSoLuong> list = new List<Entities.KhuyenMaiSoLuong>();
                if (source != null)
                    list = source.ToList();

                list.Add(item);
                //cho sour vao ListView
                grvKhuyenMaiSL.DataSource = list.ToArray();
                // Hien thi thong tin tren list view
                Fix();
            }
            catch
            {

            }
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public bool Insert(Entities.KhuyenMaiSoLuong[] source)
        {
            bool retVal = false;
            try
            {
                // Validate
                if (source == null || source.Length <= 0)
                {
                    MessageBox.Show("Danh sách hàng khuyến mại không được để trống, Vui lòng kiểm tra lại", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                    return false;
                }
                // Nghiep vu
                int msg = 0;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.KhuyenMaiSoLuong item = new Entities.KhuyenMaiSoLuong();
                // khởi tạo mảng đối tượng để hứng giá trị
                foreach (Entities.KhuyenMaiSoLuong item1 in source)
                {
                    item1.HanhDong = "Insert";
                    clientstrem = cl.SerializeObj(this.client1, "KhuyenMaiSoLuong", item1);
                    // đổ mảng đối tượng vào datagripview       
                    msg = (int)cl.DeserializeHepper(clientstrem, msg);
                }

                if (msg != 0)
                    retVal = true;
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public bool Update(Entities.KhuyenMaiSoLuong[] source)
        {
            bool retVal = false;
            try
            {
                // Validate
                if (source == null || source.Length <= 0)
                {
                    MessageBox.Show("Danh sách hàng khuyến mại không được để trống, Vui lòng kiểm tra lại", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                    return false;
                }
                //Nghiep vu
                int msg = 0;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.KhuyenMaiSoLuong item = new Entities.KhuyenMaiSoLuong();
                // Delete
                item = source[0];
                item.HanhDong = "Delete";
                clientstrem = cl.SerializeObj(this.client1, "KhuyenMaiSoLuong", item);
                // đổ mảng đối tượng vào datagripview       
                msg = (int)cl.DeserializeHepper(clientstrem, msg);
                // Insert
                foreach (Entities.KhuyenMaiSoLuong item1 in source)
                {
                    item1.HanhDong = "Insert";
                    clientstrem = cl.SerializeObj(this.client1, "KhuyenMaiSoLuong", item1);
                    // đổ mảng đối tượng vào datagripview       
                    msg = (int)cl.DeserializeHepper(clientstrem, msg);
                }

                if (msg != 0)
                    retVal = true;
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }

        /// <summary>
        /// txtKMKT_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGiaBanBuon_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode.Equals(Keys.Enter))
                {
                    // Validate
                    if (!ValidateDataKM())
                        return;
                    // lay data
                    Entities.KhuyenMaiSoLuong item = new Entities.KhuyenMaiSoLuong();
                    item.MaHangHoa = txtMaHangHoa.Text.Trim().ToUpper();
                    item.TenHangHoa = txtTenHangHoa.Text;
                    item.HanhDong = "Insert";
                    item.SoLuong = double.Parse(txtSoLuongKM.Text);
                    double giaBanBuon = 0;

                    if (!string.IsNullOrEmpty(txtKMGiaBanBuon.Text))
                        giaBanBuon = double.Parse(txtKMGiaBanBuon.Text);

                    item.GiaBanBuon = giaBanBuon;
                    item.GiaBanLe = double.Parse(txtKMGiaBanLe.Text);
                    item.NgayBatDau = ConvertDatetime(txtKMBD.Text);
                    item.NgayKetThuc = ConvertDatetime(txtKMKT.Text);
                    // Check Trung, khong trung , trung 1 phan
                    Entities.KhuyenMaiSoLuong[] source = (Entities.KhuyenMaiSoLuong[])grvKhuyenMaiSL.DataSource;

                    string result = CheckKhoangTime(item, source);
                    bool isValidate = true;

                    if (!string.IsNullOrEmpty(result))
                    {
                        switch (result)
                        {
                            //case "trung":
                            //    {
                            //        MessageBox.Show("Thời gian khuyến mại không được trùng nhau, vui lòng kiểm tra lại! ", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                            //        isValidate = false;
                            //        break;
                            //    }
                            case "trungmotphan":
                                {
                                    MessageBox.Show("Số lượng khuyến mại không được giống nhau, vui lòng kiểm tra lại! ", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                                    isValidate = false;
                                    break;
                                }
                        }
                    }

                    if (isValidate)
                    {
                        // add to list view
                        this.AddToList(item);
                    }
                    //
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// grvKhuyenMaiSL_CellDoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grvKhuyenMaiSL_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Lay source
                Entities.KhuyenMaiSoLuong[] source = (Entities.KhuyenMaiSoLuong[])grvKhuyenMaiSL.DataSource;
                List<Entities.KhuyenMaiSoLuong> list = new List<Entities.KhuyenMaiSoLuong>();
                list = source.ToList();
                // lay item khi click
                Entities.KhuyenMaiSoLuong item = (Entities.KhuyenMaiSoLuong)grvKhuyenMaiSL.Rows[e.RowIndex].DataBoundItem;
                // remove item trong list
                list.Remove(item);
                // nhet data vao control
                SetData(item);
                // nhet data vao list view
                grvKhuyenMaiSL.DataSource = list.ToArray();
            }
            catch
            {
            }
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKMUpdate_Click(object sender, EventArgs e)
        {
            Entities.KhuyenMaiSoLuong[] source = (Entities.KhuyenMaiSoLuong[])grvKhuyenMaiSL.DataSource;

            if (this.source != null && this.source.Length > 0)
            {
                bool bol = Update(source);

                if (bol)
                {
                    MessageBox.Show("Cập nhật dữ liệu thành công", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                bool bol = Insert(source);

                if (bol)
                {
                    MessageBox.Show("Thêm dữ liệu thành công", "Hệ thống cảnh báo", MessageBoxButtons.OK);
                    return;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKMGiaBanLe_TextChanged(object sender, EventArgs e)
        {
            new TienIch().AutoFormatMoney(sender);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtKMGiaBanBuon_TextChanged(object sender, EventArgs e)
        {
            new TienIch().AutoFormatMoney(sender);
        }

        /// <summary>
        /// Fix Dung de hien thi cac cot trong listview
        /// </summary>
        public void Fix()
        {
            grvKhuyenMaiSL.RowHeadersVisible = false;
            grvKhuyenMaiSL.Columns[0].Visible = false;
            grvKhuyenMaiSL.Columns[grvKhuyenMaiSL.ColumnCount - 1].Visible = false;
            grvKhuyenMaiSL.AllowUserToResizeRows = false;
            grvKhuyenMaiSL.MultiSelect = false;
            grvKhuyenMaiSL.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grvKhuyenMaiSL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grvKhuyenMaiSL.ReadOnly = true;
            grvKhuyenMaiSL.Columns["ID"].Visible = false;
            grvKhuyenMaiSL.Columns["MaHangHoa"].Visible = false;
            grvKhuyenMaiSL.Columns["TenHangHoa"].Visible = false;
            grvKhuyenMaiSL.Columns["GiaBanLe"].Visible = true;

            grvKhuyenMaiSL.Columns["NgayBatDau"].DefaultCellStyle.Format = "dd/MM/yyyy";
            grvKhuyenMaiSL.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
            grvKhuyenMaiSL.Columns["NgayKetThuc"].DefaultCellStyle.Format = "dd/MM/yyyy";
            grvKhuyenMaiSL.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
            grvKhuyenMaiSL.Columns["GiaBanBuon"].HeaderText = "Giá Bán Buôn";
            grvKhuyenMaiSL.Columns["GiaBanLe"].HeaderText = "Giá Bán Lẻ";
            grvKhuyenMaiSL.Columns["SoLuong"].HeaderText = "Số Lượng Khuyến Mại";
            new Common.Utilities().CountDatagridview(grvKhuyenMaiSL);
        }

        /// <summary>
        /// SapXep
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Entities.KhuyenMaiSoLuong[] SapXep(Entities.KhuyenMaiSoLuong[] source)
        {
            Entities.KhuyenMaiSoLuong[] retVal = null;
            try
            {
                if (source == null)
                    return null;
                // sap xep
                retVal = source.OrderBy(c => c.SoLuong).ToArray();
            }
            catch
            {
                retVal = null;
            }

            return retVal;
        }

        /// <summary>
        /// GetDonGia
        /// </summary>
        /// <param name="?"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static Entities.KhuyenMaiSoLuong GetDonGia(string maHangHoa, string sl, DateTime ngayLapHD, Entities.KhuyenMaiSoLuong[] source)
        {
            Entities.KhuyenMaiSoLuong retVal = null;
            try
            {
                if (source == null)
                    return null;

                int length = source.Length;
                Entities.KhuyenMaiSoLuong[] tempArr = null;
                Entities.KhuyenMaiSoLuong temp = null;
                // truong hop 1 (chi co 1 item trong source)
                if (length == 1)
                {
                    var query = from item in source
                                let a = item.MaHangHoa.Trim().ToUpper().Equals(maHangHoa.Trim().ToUpper())
                                let b = item.SoLuong <= double.Parse(sl)
                                let c = (item.NgayBatDau.Date >= ngayLapHD.Date) && (item.NgayKetThuc.Date <= ngayLapHD.Date)
                                where a && b && c
                                select item;
                    // 
                    tempArr = query.ToArray();

                    if (tempArr != null && tempArr.Length > 0)
                    {
                        retVal = tempArr[0];
                        return retVal;
                    }
                }
                // Truong hop 2(sl hang hoa > ca max trong source)
                if (length > 1)
                {
                    temp = source[length - 1];

                    bool a = temp.SoLuong <= double.Parse(sl);
                    bool b = temp.MaHangHoa.Trim().ToUpper().Equals(maHangHoa.Trim().ToUpper());
                    bool c = (temp.NgayBatDau.Date >= ngayLapHD.Date) && (temp.NgayKetThuc.Date <= ngayLapHD.Date);

                    if (a && b && c)
                        return temp;
                }
                // Truong hop 3
                temp = null;
                foreach (Entities.KhuyenMaiSoLuong item in source)
                {
                    // so sanh so luong truoc
                    if (double.Parse(sl) >= item.SoLuong)
                    {
                        temp = item;
                    }
                    else
                        break;
                }

                if (temp != null)
                {
                    bool b = temp.MaHangHoa.Trim().ToUpper().Equals(maHangHoa.Trim().ToUpper());
                    bool c = (temp.NgayBatDau.Date <= ngayLapHD.Date) && (temp.NgayKetThuc.Date >= ngayLapHD.Date);

                    if (b && c)
                        retVal = temp;
                }
            }
            catch
            {
                retVal = null;
            }

            return retVal;
        }

        /// <summary>
        /// GetSource
        /// </summary>
        /// <param name="maHangHoa"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Entities.KhuyenMaiSoLuong[] GetSource(string maHangHoa, Entities.KhuyenMaiSoLuong[] source)
        {
            Entities.KhuyenMaiSoLuong[] retVal = null;
            try
            {
                var query = from item in source
                            where item.MaHangHoa.Trim().ToUpper().Equals(maHangHoa.Trim().ToUpper())
                            select item;

                retVal = query.ToArray();
            }
            catch
            {
                retVal = null;
            }

            return retVal;
        }


        #endregion


        //Phần Xử Lý Tab Hàng Hóa
        #region Phần Hàng Hóa
        //Phần Khai Báo
        #region Khai Báo
        public TcpClient tcpClient;
        public TcpClient client1;
        public NetworkStream networkStream;
        public NetworkStream clientstrem;
        string maHangHoaMoi;
        string tenHangHoa, maLoaiHang, maNhomHang, maDVT, maThue, kieuHanghoa, Seri, ghiChu;
        string giaNhap, giaBanBuon, giaBanLe;
        int mucTonToiThieu, MucDatHang;

        public frmXuLyHangHoa(string hanhDong)
        {
            InitializeComponent();

            if (hanhDong == "Insert")
            {
                tssSua.Enabled = false;
                tabPage3.Enabled = false;
                tabPage2.Enabled = false;
                label4.Visible = false;
                txtSTT.Visible = false;
                this.Text = "THÊM - HÀNG HÓA";
                XuLyCombobox();
            }
        }
        Entities.QuyDoiDonViTinh[] quidoidvt;
        Server_Client.Client cl;
        private string hanhdong;
        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        public frmXuLyHangHoa(string hanhdong, string giatri)
        {
            InitializeComponent();
            this.hanhdong = hanhdong;
            if (hanhdong == "ThemNhapKho")
            {
                XuLyCombobox();
                tssSua.Enabled = false;
                tabPage3.Enabled = false;
                tabPage2.Enabled = false;
                label4.Visible = false;
                txtSTT.Visible = false;
                this.Text = "THÊM - HÀNG HÓA";
                txtMaHangHoa.Text = giatri;
                txtMaHangHoa.Focus();
            }
        }
        public frmXuLyHangHoa(string hanhDong, DataGridViewRow dgvr)
        {
            InitializeComponent();

            XuLyCombobox();
            txtMaHangHoa.Focus();
            if (hanhDong == "Insert")
            {
                tssSua.Enabled = false;
                tabPage3.Enabled = false;
                tabPage2.Enabled = false;
                label4.Visible = false;
                txtSTT.Visible = false;
                this.Text = "THÊM - HÀNG HÓA";
                if (dgvHienThi.DataSource != null)
                {
                    QuyDoiDVT();
                }
            }
            else
                if (hanhDong == "Update")
                {
                    maquydoidvt = ProMaQuyDoi("QuyDoiDonViTinh");
                    tabPage2.Enabled = true;
                    this.Text = "SỬA - HÀNG HÓA";
                    tssThem.Enabled = false;
                    txtSTT.Enabled = false;
                    txtMaHangHoa.Enabled = false;
                    id = dgvr.Cells["HangHoaID"].Value.ToString();
                    txtSTT.Text = dgvr.Cells[0].Value.ToString();
                    maHangHoaMoi = txtMaHangHoa.Text = dgvr.Cells["MaHangHoa"].Value.ToString();
                    cbbLoaiHangHoa.SelectedIndex = cbbLoaiHangHoa_sua(dgvr.Cells["MaNhomHangHoa"].Value.ToString());
                    Entities.LoaiHangHoa lh = (Entities.LoaiHangHoa)cbbLoaiHangHoa.SelectedItem;
                    maLoaiHang = lh.MaLoaiHang;

                    cmbMaNhomHangHoa.SelectedIndex = cmbmaMaNhomHangHoa_sua(dgvr.Cells["MaNhomHangHoa"].Value.ToString());
                    Entities.NhomHang nh = (Entities.NhomHang)cmbMaNhomHangHoa.SelectedItem;
                    maNhomHang = nh.MaNhomHang;

                    tenHangHoa = txtTenHangHoa.Text = dgvr.Cells["TenHangHoa"].Value.ToString();

                    cmbMaDonViTinh.SelectedIndex = cmbmaDonViTinh_sua(dgvr.Cells["MaDonViTinh"].Value.ToString());
                    Entities.DVT dvt = (Entities.DVT)cmbMaDonViTinh.SelectedItem;
                    maDVT = dvt.MaDonViTinh;

                    txtGiaNhap.Text = dgvr.Cells["GiaNhap"].Value.ToString();
                    giaNhap = txtGiaNhap.Text;

                    txtGiaBanBuon.Text = dgvr.Cells["GiaBanBuon"].Value.ToString();
                    giaBanBuon = txtGiaBanBuon.Text;
                    txtGiaBanLe.Text = dgvr.Cells["GiaBanLe"].Value.ToString();
                    giaBanLe = txtGiaBanLe.Text;
                    cbbThue.SelectedIndex = cbbThue_sua(dgvr.Cells["MaThueGiaTriGiaTang"].Value.ToString());
                    Entities.Thue Thue = (Entities.Thue)cbbThue.SelectedItem;
                    maThue = Thue.MaThue;

                    kieuHanghoa = txtKieuHangHoa.Text = dgvr.Cells["KieuHangHoa"].Value.ToString();
                    Seri = txtSeri.Text = dgvr.Cells["SeriLo"].Value.ToString();
                    txtMucDatHang.Text = dgvr.Cells["MucDatHang"].Value.ToString();
                    MucDatHang = int.Parse(txtMucDatHang.Text);
                    txtMucTonToiThieu.Text = dgvr.Cells["MucTonToiThieu"].Value.ToString();
                    mucTonToiThieu = int.Parse(txtMucTonToiThieu.Text);
                    ghiChu = txtGhiChu.Text = dgvr.Cells["GhiChu"].Value.ToString();
                    HienThiDgvChinhSachGiaKhuyenMai(dgvr.Cells["MaHangHoa"].Value.ToString());
                    txtMaCapNhat.Text = LayID("CapNhatGia");
                    //txtGN.Text = txtGiaNhap.Text;
                    QuyDoiDVT();
                }
        }

        public void QuyDoiDVT()
        {
            // quy đổi đơn vị tính
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("QD");
            clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
            this.quidoidvt = new Entities.QuyDoiDonViTinh[0];
            this.quidoidvt = (Entities.QuyDoiDonViTinh[])cl.DeserializeHepper1(clientstrem, this.quidoidvt);
            if (quidoidvt == null)
            {
                quidoidvt = new Entities.QuyDoiDonViTinh[0];
                return;
            }
            List<Entities.QuyDoiDonViTinh> quydoi = new List<Entities.QuyDoiDonViTinh>();
            foreach (Entities.QuyDoiDonViTinh item in quidoidvt)
            {
                if (item.MaHangDuocQuyDoi == txtMaHangHoa.Text)
                {
                    quydoi.Add(item);
                }
            }
            dgvHienThi.DataSource = (Entities.QuyDoiDonViTinh[])quydoi.ToArray();
            fix();
        }
        void fix()
        {
            for (int i = 0; i < dgvHienThi.ColumnCount; i++)
            {
                dgvHienThi.Columns[i].Visible = false;
            }
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.ReadOnly = true;
            dgvHienThi.RowHeadersVisible = false;
            dgvHienThi.Columns["MaHangQuyDoi"].HeaderText = "Mã Hàng Hóa";
            dgvHienThi.Columns["MaHangQuyDoi"].Visible = true;
            dgvHienThi.Columns["MaHangQuyDoi"].DisplayIndex = 0;
            dgvHienThi.Columns["MaDonViTinh"].HeaderText = "Tên ĐVT";
            dgvHienThi.Columns["MaDonViTinh"].Visible = true;
            dgvHienThi.Columns["SoLuongDuocQuyDoi"].HeaderText = "Số Lượng Quy Đổi";
            dgvHienThi.Columns["SoLuongDuocQuyDoi"].Visible = true;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.AllowUserToAddRows = false;
            dgvHienThi.AllowUserToDeleteRows = false;
            dgvHienThi.AllowUserToResizeRows = false;
        }
        string maquydoidvt = "";
        //Check Thêm
        public Boolean CheckConflictInsertQuyDoi()
        {
            Boolean check = false;
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.QuyDoiDonViTinh ncc = new Entities.QuyDoiDonViTinh("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.QuyDoiDonViTinh[] ncc1 = new Entities.QuyDoiDonViTinh[1];
                networkStream = cl.SerializeObj(this.tcpClient, "QuyDoiDonViTinh", ncc);
                // đổ mảng đối tượng vào datagripview       
                ncc1 = (Entities.QuyDoiDonViTinh[])cl.DeserializeHepper1(networkStream, ncc1);
                for (int j = 0; j < ncc1.Length; j++)
                {
                    if (ncc1[j].MaHangQuyDoi == tsslMaHangHoa.Text)
                    {
                        MessageBox.Show("mã hàng quy đổi đã tồn tại");
                        check = false;
                        break;
                    }
                    else
                    {
                        check = true;
                    }
                }
                if (ncc1.Length <= 0)
                { check = true; }
                if (check)
                {
                    Server_Client.Client client = new Server_Client.Client();
                    this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
                    Entities.HangHoa hh = new Entities.HangHoa("SelectAll");
                    Entities.HangHoa[] hh1 = new Entities.HangHoa[1];
                    networkStream = client.SerializeObj(this.tcpClient, "HangHoa", hh);
                    hh1 = (Entities.HangHoa[])client.DeserializeHepper1(networkStream, hh1);
                    if (hh1 != null)
                    {
                        for (int j = 0; j < hh1.Length; j++)
                        {
                            if (hh1[j].MaHangHoa.ToUpper() == tsslMaHangHoa.Text.ToUpper())
                            {
                                MessageBox.Show("Mã hàng hóa này đã có trong cơ sở dữ liệu");
                                check = false;
                                break;
                            }
                            else
                                check = true;
                        }
                    }
                }
            }
            catch { check = false; }
            return check;
        }

        public string ProMaQuyDoi(string tenBang)
        {
            try
            {
                string idnew;
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.LayID lid = new Entities.LayID();
                networkStream = cl.SerializeObj(this.tcpClient, "LayID", lid1);
                // đổ mảng đối tượng vào datagripview       
                lid = (Entities.LayID)cl.DeserializeHepper(networkStream, lid);
                if (lid == null)
                {
                    return "QDDVT_0001";
                }
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            finally { }
        }

        public frmXuLyHangHoa()
        {
            InitializeComponent();
        }

        //Hiển thị dữ liệu khi load
        private void frmXuLyHangHoa_Load(object sender, EventArgs e)
        {
            ActiveControl = txtMaHangHoa;
            makNgayBatDau.Text = DateServer.Date().ToString("dd/MM/yyyy");
            txtKMBD.Text = DateServer.Date().ToString("dd/MM/yyyy");

            string maHangHoa = txtMaHangHoa.Text;
            if (!string.IsNullOrEmpty(maHangHoa))
            {
                this.source = GetData(maHangHoa);
                grvKhuyenMaiSL.DataSource = this.source;
                Fix();
            }
        }

        string id;

        #endregion

        //Phần Xử Lý
        #region Xử Lý

        //Kiểm Tra
        private bool KiemTra()
        {
            if (txtMaHangHoa.Text.Length == 0)
            {
                MessageBox.Show("Mã hàng hóa không được để trống");
                txtMaHangHoa.Focus();
                return false;
            }
            foreach (char ch in txtMaHangHoa.Text)
            {
                if (testCharacter(ch))
                {
                    MessageBox.Show("        Mã Hàng Hóa Không được nhập tiếng việt có dấu " +
                                  "\nNếu bạn đang dùng máy quét mã vạch hãy tắt bộ gõ Tiếng Tiệt đi! ", "Hệ Thống Cảnh Báo");
                    txtMaHangHoa.Focus();
                    txtMaHangHoa.SelectAll();
                    return false;
                }
            }
            if (txtGiaNhap.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập giá nhập");
                txtGiaNhap.Focus();
                return false;
            }
            if (txtGiaBanBuon.Text == "")
            {
                txtGiaBanBuon.Text = "0";
            }
            if (txtGiaBanLe.Text == "")
            {
                txtGiaBanLe.Text = "0";
            }
            if (txtMucDatHang.Text == "")
            {
                txtMucDatHang.Text = "0";
            }
            if (txtMucTonToiThieu.Text == "")
            {
                txtMucTonToiThieu.Text = "0";
            }
            string kt2 = "ok";

            try
            {
                float.Parse(txtMucDatHang.Text);
            }
            catch
            {
                kt2 = "Bạn đã nhập sai định dang Mức đặt hàng - Hãy Nhập Số";
            }

            try
            {
                float.Parse(txtMucTonToiThieu.Text);
            }
            catch
            {
                kt2 = "Bạn đã nhập sai định dang Mức Tồn Tối Thiểu - Hãy Nhập Số";
                txtMucTonToiThieu.Focus();
                MessageBox.Show(kt2, "Hệ Thống Cảnh Báo");
                return false;
            }

            try
            {
                float.Parse(txtGiaNhap.Text);
            }
            catch
            {
                kt2 = "Bạn đã nhập sai định dang Giá Nhập - Hãy Nhập Số";
                txtGiaNhap.Focus();
                MessageBox.Show(kt2, "Hệ Thống Cảnh Báo");
                return false;
            }

            try
            {
                float.Parse(txtGiaBanBuon.Text);
            }
            catch
            {
                kt2 = "Bạn đã nhập sai định dang Giá Bán Buôn - Hãy Nhập Số";
                txtGiaBanBuon.Focus();
                MessageBox.Show(kt2, "Hệ Thống Cảnh Báo");
                return false;
            }
            try
            {
                float.Parse(txtGiaBanLe.Text);
            }
            catch
            {
                kt2 = "Bạn đã nhập sai định dang Giá Bán Lẻ - Hãy Nhập Số";
                txtGiaBanLe.Focus();
                MessageBox.Show(kt2, "Hệ Thống Cảnh Báo");
                return false;
            }
            //if (double.Parse(txtGiaBanBuon.Text) > double.Parse(txtGiaBanLe.Text))
            //{
            //    MessageBox.Show("Giá buôn không thể lớn hơn Giá lẻ", "Hệ thống cảnh báo");
            //    return false;
            //}
            //if (double.Parse(txtGiaBanBuon.Text) < double.Parse(txtGiaNhap.Text))
            //{
            //    MessageBox.Show("Giá buôn không thể nhỏ hơn Giá nhập", "Hệ thống cảnh báo");
            //    return false;
            //}
            if (cbbLoaiHangHoa.DataSource == null || cbbThue.DataSource == null || cmbMaDonViTinh.DataSource == null || cmbMaNhomHangHoa.DataSource == null)
            {
                MessageBox.Show("Chưa có dữ liệu trong Cơ sở dữ liệu(DataBase)", "Hệ thống cảnh báo");
                return false;
            }

            if (txtMaHangHoa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập mã hàng hóa");
                txtMaHangHoa.Focus();
                return false;
            }
            if (txtTenHangHoa.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập tên hàng hóa");
                txtTenHangHoa.Focus();
                return false;
            }
            if (txtGhiChu.Text.Length > 100)
            {
                MessageBox.Show("Chi chú Không được quá 100 ký tự");
                txtGhiChu.Focus();
                return false;
            }

            return true;
        }

        //Thêm
        private void tssThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra() == true)
                {
                    CheckConflictInsert();
                    if (kt == "ok")
                    {
                        Server_Client.Client client = new Server_Client.Client();
                        this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
                        Entities.HangHoa hh = new Entities.HangHoa();
                        Entities.DVT dvt = (Entities.DVT)cmbMaDonViTinh.SelectedItem;
                        Entities.NhomHang nh = (Entities.NhomHang)cmbMaNhomHangHoa.SelectedItem;
                        Entities.Thue t = (Entities.Thue)cbbThue.SelectedItem;

                        ////: insert 1000
                        //for (int i = 0; i < 1000; i++)
                        //{
                        //    txtMaHangHoa.Text = "HH" + i;
                        //    txtTenHangHoa.Text = "hàng Hóa " + i;
                        //    txtGiaNhap.Text = "100";
                        //    txtGiaBanBuon.Text = "200";
                        //    txtGiaBanLe.Text = "300";

                        hh = new Entities.HangHoa("Insert", 0, txtMaHangHoa.Text.ToUpper(), nh.MaNhomHang, " ", txtTenHangHoa.Text, dvt.MaDonViTinh, " ", txtGiaNhap.Text, txtGiaBanBuon.Text,
                            txtGiaBanLe.Text, t.MaThue, " ",
                            txtKieuHangHoa.Text, txtSeri.Text, int.Parse(txtMucDatHang.Text), int.Parse(txtMucTonToiThieu.Text),
                            txtGhiChu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                        networkStream = client.SerializeObj(this.tcpClient, "HangHoa", hh);
                        bool kt1 = false;
                        kt1 = (bool)client.DeserializeHepper(networkStream, kt);
                        if (hanhdong == "ThemNhapKho")
                        {
                            GiaTriCanLuu.mahanghoa = txtMaHangHoa.Text;
                        }
                        if (!kt1)
                        {
                            MessageBox.Show("Insert Thất Bại");
                            //break;
                        }
                        txtMaHangHoa.Text = " ";
                        txtKieuHangHoa.Text = " ";
                        txtGiaNhap.Text = "0";
                        txtGiaBanBuon.Text = "0";
                        txtGiaBanLe.Text = "0";
                        txtGhiChu.Text = "0";
                        txtMucDatHang.Text = "0";
                        txtMucTonToiThieu.Text = "0";
                        txtSeri.Text = "";
                        frmQuanLyHangHoa.KiemTra = "insert";
                        //}
                        this.Close();
                    }
                }
            }
            catch { }
        }

        //Sửa
        private void tssSua_Click(object sender, EventArgs e)
        {
            if (KiemTra() == true)
            {
                //CheckConflictUpdate();
                if (kt == "ok")
                {
                    Server_Client.Client client = new Server_Client.Client();
                    this.tcpClient = client.Connect(Luu.IP, Luu.Ports);

                    Entities.DVT dvt = (Entities.DVT)cmbMaDonViTinh.SelectedItem;
                    Entities.NhomHang nh = (Entities.NhomHang)cmbMaNhomHangHoa.SelectedItem;
                    Entities.Thue t = (Entities.Thue)cbbThue.SelectedItem;

                    Entities.HangHoa hh = new Entities.HangHoa("Update", int.Parse(id), txtMaHangHoa.Text.ToUpper(), nh.MaNhomHang, " ", txtTenHangHoa.Text,
                        dvt.MaDonViTinh, " ", txtGiaNhap.Text, txtGiaBanBuon.Text,
                        txtGiaBanLe.Text, t.MaThue, " ", txtKieuHangHoa.Text, txtSeri.Text, int.Parse(txtMucDatHang.Text), int.Parse(txtMucTonToiThieu.Text),
                        txtGhiChu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                    networkStream = client.SerializeObj(this.tcpClient, "HangHoa", hh);
                    bool kt1 = false;
                    kt1 = (bool)client.DeserializeHepper(networkStream, kt);

                    maHangHoaMoi = txtMaHangHoa.Text;

                    Entities.LoaiHangHoa lh = (Entities.LoaiHangHoa)cbbLoaiHangHoa.SelectedItem;
                    maLoaiHang = lh.MaLoaiHang;

                    Entities.NhomHang nh1 = (Entities.NhomHang)cmbMaNhomHangHoa.SelectedItem;
                    maNhomHang = nh.MaNhomHang;

                    tenHangHoa = txtTenHangHoa.Text;

                    Entities.DVT dvt1 = (Entities.DVT)cmbMaDonViTinh.SelectedItem;
                    maDVT = dvt.MaDonViTinh;

                    giaNhap = txtGiaNhap.Text;
                    giaBanBuon = txtGiaBanBuon.Text;
                    giaBanLe = txtGiaBanLe.Text;
                    Entities.Thue Thue = (Entities.Thue)cbbThue.SelectedItem;
                    maThue = Thue.MaThue;

                    kieuHanghoa = txtKieuHangHoa.Text;
                    Seri = txtSeri.Text;

                    MucDatHang = int.Parse(txtMucDatHang.Text);

                    mucTonToiThieu = int.Parse(txtMucTonToiThieu.Text);
                    ghiChu = txtGhiChu.Text;
                    this.Close();
                }
            }
        }

        //Đóng form
        private void tssDong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    frmQuanLyHangHoa.KiemTra = "close";
                    this.Close();
                }
                else
                { }
            }
        }

        #endregion

        //Check Conflict 
        #region Check Conflict
        public string kt = "ok";

        //Check Thêm
        public void CheckConflictInsert()
        {
            try
            {
                Server_Client.Client client = new Server_Client.Client();
                this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
                Entities.HangHoa hh = new Entities.HangHoa("SelectAll");
                Entities.HangHoa[] hh1 = new Entities.HangHoa[1];
                networkStream = client.SerializeObj(this.tcpClient, "HangHoa", hh);
                hh1 = (Entities.HangHoa[])client.DeserializeHepper1(networkStream, hh1);
                if (hh1 != null)
                {
                    for (int j = 0; j < hh1.Length; j++)
                    {
                        if (hh1[j].MaHangHoa.ToUpper() == txtMaHangHoa.Text.ToUpper())
                        {
                            MessageBox.Show("Mã hàng hóa này đã có trong cơ sở dữ liệu");
                            kt = "ko";
                            txtMaHangHoa.Text = "";
                            break;
                        }
                        else
                            kt = "ok";
                    }
                }
            }
            catch
            {
            }
        }
        #region check() check conflict
        public string Check(Entities.HangHoa nv)
        {
            string gt = "ok";

            if (tenHangHoa != nv.TenHangHoa)
            {
                tenHangHoa = txtTenHangHoa.Text = nv.TenHangHoa;
                gt = "ko";
            }
            if (maDVT != nv.MaDonViTinh)
            {
                maDVT = nv.MaDonViTinh;
                cmbMaDonViTinh.SelectedIndex = cmbmaDonViTinh_sua(maDVT);
                gt = "ko";
            }
            if (maNhomHang != nv.MaNhomHangHoa)
            {
                maNhomHang = nv.MaNhomHangHoa;
                cmbMaNhomHangHoa.SelectedIndex = cmbmaMaNhomHangHoa_sua(maNhomHang);
                gt = "ko";
            }
            if (maThue != nv.MaThueGiaTriGiaTang)
            {
                maThue = nv.MaThueGiaTriGiaTang;
                cbbThue.SelectedIndex = cbbThue_sua(maThue);
                gt = "ko";
            }
            if (giaNhap != nv.GiaNhap.ToString())
            {
                giaNhap = nv.GiaNhap;
                txtGiaNhap.Text = giaNhap.ToString();
                gt = "ko";
            }
            if (giaBanBuon != nv.GiaBanBuon)
            {
                giaBanBuon = nv.GiaBanBuon;
                txtGiaBanBuon.Text = giaBanBuon.ToString();
                gt = "ko";
            }
            if (giaBanLe != nv.GiaBanLe)
            {
                giaBanLe = nv.GiaBanLe;
                txtGiaBanLe.Text = giaBanLe.ToString();
                gt = "ko";
            }
            if (kieuHanghoa != nv.KieuHangHoa)
            {
                kieuHanghoa = nv.KieuHangHoa;
                txtKieuHangHoa.Text = kieuHanghoa;
                gt = "ko";
            }
            if (Seri != nv.SeriLo)
            {
                Seri = txtSeri.Text = nv.SeriLo;
                gt = "ko";
            }

            if (mucTonToiThieu != nv.MucTonToiThieu)
            {
                mucTonToiThieu = nv.MucTonToiThieu;
                txtMucTonToiThieu.Text = mucTonToiThieu.ToString();
                gt = "ko";
            }
            if (MucDatHang != nv.MucDatHang)
            {
                MucDatHang = nv.MucDatHang;
                txtMucDatHang.Text = MucDatHang.ToString();
                gt = "ko";
            }

            if (ghiChu != nv.GhiChu)
            {
                ghiChu = txtGhiChu.Text = nv.GhiChu;
                gt = "ko";
            }

            if (gt == "ko")
            {
                MessageBox.Show("Dữ liệu đã có thay đổi trước, ấn ok để cập nhật lại.");
            }

            return gt;
        }
        #endregion
        //Check Sửa
        #region Main check conflict update
        Entities.HangHoa[] nv1;
        public void CheckConflictUpdate()
        {
            try
            {
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.HangHoa pt = new Entities.HangHoa("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                nv1 = new Entities.HangHoa[1];
                networkStream = cl.SerializeObj(this.tcpClient, "HangHoa", pt);
                // đổ mảng đối tượng vào datagripview       
                nv1 = (Entities.HangHoa[])cl.DeserializeHepper1(networkStream, nv1);
                if (nv1 != null)
                {
                    for (int j = 0; j < nv1.Length; j++)
                    {
                        if (nv1[j].MaHangHoa == maHangHoaMoi)
                        {

                            kt = Check(nv1[j]);

                            break;
                        }
                        else
                            kt = "null";
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        #endregion

        //Lấy ID
        #region Lấy ID

        public string LayID(string tenBang)
        {
            string idnew = "";
            Server_Client.Client client = new Server_Client.Client();
            this.tcpClient = client.Connect(Luu.IP, Luu.Ports);
            Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
            Entities.LayID lid = new Entities.LayID();
            networkStream = client.SerializeObj(this.tcpClient, "LayID", lid1);
            lid = (Entities.LayID)client.DeserializeHepper(networkStream, lid);

            if (lid == null)
            {
                idnew = "CNG_0001";
            }
            else
            {
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
            }
            return idnew;
        }

        #endregion

        //Xử Lý Combobox Hàng Hóa
        #region Xử Lý Hàng Hóa

        Server_Client.Client client;

        //Lấy combobox thuế
        public void LayThue()
        {
            cbbThue.Items.Clear();
            client = new Server_Client.Client();
            this.tcpClient = client.Connect(Luu.IP, Luu.Ports);

            Entities.Thue nh = new Entities.Thue();
            nh = new Entities.Thue("Select");
            networkStream = client.SerializeObj(this.tcpClient, "Thue", nh);
            Entities.Thue[] nh1 = new Entities.Thue[1];
            nh1 = (Entities.Thue[])client.DeserializeHepper1(networkStream, nh1);
            if (nh1 != null)
            {
                cbbThue.DataSource = nh1;
                cbbThue.DisplayMember = "TenThue";
            }

        }
        public int cbbThue_sua(string maThue)
        {

            Entities.Thue[] pb = (Entities.Thue[])cbbThue.DataSource;
            if (pb != null)
            {
                for (int i = 0; i < pb.Length; i++)
                {
                    if (pb[i].MaThue == maThue)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        //Lấy Mã Nhóm Hàng Hóa
        public void LayLoaiHangHoa()
        {
            try
            {
                cbbLoaiHangHoa.DataSource = null;
                client = new Server_Client.Client();
                this.tcpClient = client.Connect(Luu.IP, Luu.Ports);

                Entities.LoaiHangHoa nh = new Entities.LoaiHangHoa();
                nh = new Entities.LoaiHangHoa("Select");
                networkStream = client.SerializeObj(this.tcpClient, "LoaiHangHoa", nh);
                Entities.LoaiHangHoa[] nh1 = new Entities.LoaiHangHoa[1];
                nh1 = (Entities.LoaiHangHoa[])client.DeserializeHepper1(networkStream, nh1);

                cbbLoaiHangHoa.DataSource = nh1;
                cbbLoaiHangHoa.DisplayMember = "TenLoaiHang";
            }
            catch (Exception) { }
        }
        public int cbbLoaiHangHoa_sua(string maNH)
        {
            client = new Server_Client.Client();
            this.tcpClient = client.Connect(Luu.IP, Luu.Ports);

            Entities.NhomHang nh1 = new Entities.NhomHang();
            nh1 = new Entities.NhomHang("Select");
            networkStream = client.SerializeObj(this.tcpClient, "NhomHang", nh1);
            Entities.NhomHang[] nh = new Entities.NhomHang[1];
            nh = (Entities.NhomHang[])client.DeserializeHepper1(networkStream, nh);
            string maloaihang = "";
            if (nh != null)
            {
                for (int i = 0; i < nh.Length; i++)
                {
                    if (nh[i].MaNhomHang == maNH)
                    {
                        maloaihang = nh[i].MaLoaiHang;
                        break;
                    }
                }

                Entities.LoaiHangHoa[] pb = (Entities.LoaiHangHoa[])cbbLoaiHangHoa.DataSource;
                for (int i = 0; i < pb.Length; i++)
                {
                    if (pb[i].MaLoaiHang == maloaihang)
                    {
                        return i;
                    }
                }
                return -1;
            }
            return -1;
        }

        //Lấy Mã Nhóm Hàng Hóa
        public void LayMaNhomHangHoa(string maLH)
        {
            try
            {
                cmbMaNhomHangHoa.DataSource = null;
                client = new Server_Client.Client();
                this.tcpClient = client.Connect(Luu.IP, Luu.Ports);

                Entities.NhomHang nh = new Entities.NhomHang();
                nh = new Entities.NhomHang("Select");
                networkStream = client.SerializeObj(this.tcpClient, "NhomHang", nh);
                Entities.NhomHang[] nh1 = new Entities.NhomHang[1];
                nh1 = (Entities.NhomHang[])client.DeserializeHepper1(networkStream, nh1);

                if (nh1 != null)
                {
                    int count = 0;
                    for (int i = 0; i < nh1.Length; i++)
                    {
                        if (nh1[i].MaLoaiHang == maLH)
                        {
                            count++;
                        }
                    }
                    Entities.NhomHang[] nhomhang = new Entities.NhomHang[count];
                    count = 0;
                    for (int i = 0; i < nh1.Length; i++)
                    {
                        if (nh1[i].MaLoaiHang == maLH)
                        {
                            nhomhang[count] = nh1[i];
                            count++;
                        }
                    }
                    cmbMaNhomHangHoa.DataSource = nhomhang;
                    cmbMaNhomHangHoa.DisplayMember = "TenNhomHang";
                }
            }
            catch { }

        }
        public int cmbmaMaNhomHangHoa_sua(string maNH)
        {
            Entities.NhomHang[] pb = (Entities.NhomHang[])cmbMaNhomHangHoa.DataSource;
            for (int i = 0; i < pb.Length; i++)
            {
                if (pb[i].MaNhomHang == maNH)
                {
                    return i;
                }
            }
            return -1;
        }

        //Lấy Mã Đơn Vị Tính
        public void LayMaDonViTinh()
        {
            try
            {
                cmbMaDonViTinh.DataSource = null;
                client = new Server_Client.Client();
                this.tcpClient = client.Connect(Luu.IP, Luu.Ports);

                Entities.DVT dvt = new Entities.DVT();
                dvt = new Entities.DVT("Select");
                networkStream = client.SerializeObj(this.tcpClient, "DVT", dvt);
                Entities.DVT[] dvt1 = new Entities.DVT[1];
                dvt1 = (Entities.DVT[])client.DeserializeHepper1(networkStream, dvt1);

                cmbMaDonViTinh.DataSource = dvt1;
                cmbMaDonViTinh.DisplayMember = "TenDonViTinh";
            }
            catch (Exception) { }
        }
        public int cmbmaDonViTinh_sua(string dvt)
        {
            Entities.DVT[] pb = (Entities.DVT[])cmbMaDonViTinh.DataSource;
            for (int i = 0; i < pb.Length; i++)
            {
                if (pb[i].MaDonViTinh == dvt)
                {
                    return i;
                }
            }
            return -1;
        }



        //Lấy Mã Thuế GTGT
        Entities.LoaiThue[] lt1;

        Entities.Thue[] thue;
        public void SelectThue()
        {
            client = new Server_Client.Client();
            this.tcpClient = client.Connect(Luu.IP, Luu.Ports);

            Entities.Thue lt = new Entities.Thue();
            lt = new Entities.Thue("Select");
            networkStream = client.SerializeObj(this.tcpClient, "Thue", lt);
            thue = new Entities.Thue[1];
            thue = (Entities.Thue[])client.DeserializeHepper1(networkStream, thue);
        }


        //Xử Lý Combobox
        public void XuLyCombobox()
        {
            try
            {
                SelectThue();
                LayLoaiHangHoa();
                LayThue();
                LayMaDonViTinh();
            }
            catch { }
        }

        #endregion
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
        //Phần Xử Lý Tab Chính Sách Giá Khuyến Mãi
        #region Phần Cập Nhật GIá
        //Validate
        #region Validate

        public string checkDateTime(string datetime)
        {
            if (datetime.Length < 10)
            {
                return "Ngày tháng năm phải nhập đầy đủ";
            }
            string dd = datetime.Substring(0, 2);
            string mm = datetime.Substring(3, 2);
            string yyyy = datetime.Substring(6, 4);
            if ((int.Parse(dd) > 31) || (int.Parse(dd) < 1))
            {
                return "Ngày phải nhỏ hơn 31 và lớn hơn 0";
            }
            if ((int.Parse(mm) > 12) || (int.Parse(mm) < 1))
            {
                return "Tháng phải nhỏ hơn 12 và lớn hơn 0";
            }

            if ((int.Parse(yyyy) > 9999) || (int.Parse(yyyy) < 1800))
            {
                return "Năm phải nhỏ hơn 9999 và lớn hơn 1800";
            }
            return "true";
        }

        public bool Validate()
        {
            if (checkDateTime(makNgayBatDau.Text) != "true")
            {
                MessageBox.Show(checkDateTime(makNgayBatDau.Text), "Hệ Thống Cảnh Báo");
                makNgayBatDau.Focus();
                return false;
            }
            if (checkDateTime(makNgayKetThuc.Text) != "true")
            {
                MessageBox.Show(checkDateTime(makNgayKetThuc.Text), "Hệ Thống Cảnh Báo");
                makNgayKetThuc.Focus();
                return false;
            }
            if (makNgayBatDau.Text != null && makNgayKetThuc.Text != null)
            {
                string kt3 = "ok";
                try
                {
                    ConvertDatetime(makNgayBatDau.Text);
                }
                catch
                {
                    kt3 = "Lỗi định dạng ngày";
                }
                if (kt3 != "ok")
                {
                    MessageBox.Show("Lỗi Định Dạng Ngày Bắt Đầu", "hệ thống cảnh báo");
                    makNgayBatDau.Focus();
                    return false;
                }

                kt3 = "ok";
                try
                {
                    ConvertDatetime(makNgayKetThuc.Text);
                }
                catch
                {
                    kt3 = "Lỗi định dạng ngày";
                }
                if (kt3 != "ok")
                {
                    MessageBox.Show("Lỗi Định Dạng Ngày Kết Thúc", "hệ thống cảnh báo");
                    makNgayKetThuc.Focus();
                    return false;
                }

                if (ConvertDatetime(makNgayBatDau.Text) >= ConvertDatetime(makNgayKetThuc.Text))
                {
                    MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "hệ thống cảnh báo");
                    makNgayBatDau.Focus();
                    return false;
                }
            }

            string kt2 = "ok";
            try
            {
                float.Parse(txtGN.Text);
                txtGN.Focus();
            }
            catch { kt2 = "Bạn đã nhập sai định dạng Giá Nhập - hãy nhập số"; }

            if (txtPhanTramBB.Text.Length != 0)
            {
                try
                {
                    float.Parse(txtPhanTramBB.Text);
                    txtPhanTramBB.Focus();
                }
                catch { kt2 = "Bạn đã nhập sai định dạng phần trăm bán buôn - hãy nhập số"; }
            }

            if (txtPhanTramBL.Text.Length != 0)
            {

                try
                {
                    float.Parse(txtPhanTramBL.Text);
                    txtPhanTramBL.Focus();
                }
                catch { kt2 = "Bạn đã nhập sai định dạng phần trăm bán lẻ - hãy nhập số"; }
            }

            if (kt2 != "ok")
            {
                MessageBox.Show(kt2);
                return false;
            }
            else
            {
                float f;
                if (txtPhanTramBB.Text == "")
                {
                    f = 0;
                }
                else
                {
                    f = float.Parse(txtPhanTramBB.Text);
                }
                float x;
                if (txtPhanTramBL.Text == "")
                {
                    x = 0;
                }
                else
                    x = float.Parse(txtPhanTramBL.Text);
                if (f > 99)
                {
                    MessageBox.Show("Phần trăm bán Buôn không được lớn 100%");
                    txtPhanTramBB.Focus();
                    return false;
                }
                if (x > 99)
                {
                    MessageBox.Show("Phần trăm bán lẻ không được lớn 100%");
                    txtPhanTramBL.Focus();
                    return false;
                }
            }
            if (txtPhanTramBB.Text.Length == 0 && txtPhanTramBL.Text.Length == 0)
            {
                MessageBox.Show("Không được để trống cả 2 mục phần trăm bán lẻ và phần trăm bán buôn", "Hệ Thống Cảnh Báo");
                return false;
            }
            else

                return true;
        }
        #endregion

        //Hiển Thị Cập Nhật Giá
        #region Hiển Thị Cập Nhật Giá

        public void HienThiDgvChinhSachGiaKhuyenMai(string MaHangHoa)
        {
            client = new Server_Client.Client();
            this.tcpClient = client.Connect(Luu.IP, Luu.Ports);

            Entities.CapNhatGia nsx = new Entities.CapNhatGia();
            nsx = new Entities.CapNhatGia("Select");
            networkStream = client.SerializeObj(this.tcpClient, "CapNhatGia", nsx);
            Entities.CapNhatGia[] nsx1 = new Entities.CapNhatGia[1];
            nsx1 = (Entities.CapNhatGia[])client.DeserializeHepper1(networkStream, nsx1);
            if (nsx1 != null)
            {
                int count = 0;
                for (int i = 0; i < nsx1.Length; i++)
                {
                    if (nsx1[i].MaHangHoa == MaHangHoa)
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    Entities.CapNhatGia[] cng1 = new Entities.CapNhatGia[count];

                    count = 0;
                    for (int i = 0; i < nsx1.Length; i++)
                    {
                        if (nsx1[i].MaHangHoa == MaHangHoa)
                        {
                            cng1[count] = new Entities.CapNhatGia();
                            cng1[count] = nsx1[i];
                            count++;
                        }
                    }
                    dgvChinhSachGiaKhuyenMai.DataSource = cng1;
                    FixDataGridView();
                }
            }
            else
            {
                //MessageBox.Show("Null");
            }
        }

        #endregion

        //Fix Data Grid View
        #region Fix Data Grid View
        public void FixDataGridView()
        {
            dgvChinhSachGiaKhuyenMai.RowHeadersVisible = false;
            dgvChinhSachGiaKhuyenMai.Columns[0].HeaderText = "STT";
            dgvChinhSachGiaKhuyenMai.Columns[dgvChinhSachGiaKhuyenMai.ColumnCount - 1].Visible = false;
            dgvChinhSachGiaKhuyenMai.AllowUserToResizeRows = false;
            dgvChinhSachGiaKhuyenMai.MultiSelect = false;
            dgvChinhSachGiaKhuyenMai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChinhSachGiaKhuyenMai.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChinhSachGiaKhuyenMai.ReadOnly = true;

            dgvChinhSachGiaKhuyenMai.Columns["CapNhatGiaID"].Visible = false;
            dgvChinhSachGiaKhuyenMai.Columns["MaCapNhatGia"].HeaderText = "Mã Cập Nhật Giá";
            dgvChinhSachGiaKhuyenMai.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
            dgvChinhSachGiaKhuyenMai.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
            dgvChinhSachGiaKhuyenMai.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
            dgvChinhSachGiaKhuyenMai.Columns["PhanTramGiaBanBuon"].Visible = false;
            dgvChinhSachGiaKhuyenMai.Columns["PhanTramGiaBanBuon"].HeaderText = "Phần Trăm BB";
            dgvChinhSachGiaKhuyenMai.Columns["PhanTramGiaBanLe"].HeaderText = "Phần Trăm BL";
            dgvChinhSachGiaKhuyenMai.Columns["GiaNhap"].Visible = false;
            dgvChinhSachGiaKhuyenMai.Columns["GiaNhap"].HeaderText = "Giá Nhập";
            dgvChinhSachGiaKhuyenMai.Columns["TrangThai"].Visible = false;
            dgvChinhSachGiaKhuyenMai.Columns["GhiChu"].Visible = false;
            new Common.Utilities().CountDatagridview(dgvChinhSachGiaKhuyenMai);
        }
        #endregion

        //Check Conflict Insert
        #region CheckConflictInsert

        string kt1;
        public void CheckConflictInsertCapNhatGia()
        {
            try
            {
                Server_Client.Client cl = new Server_Client.Client();
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CapNhatGia pt = new Entities.CapNhatGia("Select");
                Entities.CapNhatGia[] pt1 = new Entities.CapNhatGia[1];
                networkStream = cl.SerializeObj(this.tcpClient, "CapNhatGia", pt);
                pt1 = (Entities.CapNhatGia[])cl.DeserializeHepper1(networkStream, pt1);
                if (pt1 != null)
                {
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        if (pt1[j].MaCapNhatGia == txtMaCapNhat.Text)
                        {
                            MessageBox.Show("Lỗi Rồi");
                            kt1 = "ko";
                            txtMaCapNhat.Text = LayID("CapNhatGia");
                            break;
                        }
                        else
                            kt1 = "ok";
                    }
                }
                else
                    kt1 = "ok";
            }
            catch
            {
            }
        }
        #endregion

        //Xử Lý Ngày
        #region Xử Lý Ngày

        public string xulyNgay(DateTime dt)
        {
            string mk;
            string dd = dt.Month.ToString();
            if (dd.Length == 1)
            {
                dd = "0" + dd;
            }
            string mm = dt.Day.ToString();
            if (mm.Length == 1)
            {
                mm = "0" + mm;
            }
            string yyyy = dt.Year.ToString();
            mk = dd + "/" + mm + "/" + yyyy;

            return mk;
        }

        public DateTime ConvertDatetime(string str)
        {

            string dd = str.Substring(0, 2);
            string mm = str.Substring(3, 2);
            string yyyy = str.Substring(6, 4);
            DateTime dt = new DateTime(int.Parse(yyyy), int.Parse(mm), int.Parse(dd));
            return dt;
        }


        #endregion

        //Cập Nhật Giá
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                CheckConflictInsertCapNhatGia();
                if (kt1 == "ok")
                {
                    double bb, bl, gn;

                    if (txtPhanTramBB.Text == "")
                    {
                        bb = 0;
                    }
                    else
                        bb = double.Parse(txtPhanTramBB.Text);
                    if (txtPhanTramBL.Text == "")
                    {
                        bl = 0;
                    }
                    else
                        bl = double.Parse(txtPhanTramBL.Text);
                    if (txtGN.Text == "")
                    {
                        gn = 0;
                    }
                    else
                        gn = double.Parse(txtGN.Text);

                    Server_Client.Client cl = new Server_Client.Client();
                    // gán TCPclient
                    this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                    Entities.CapNhatGia nv = new Entities.CapNhatGia("Insert", 1, txtMaCapNhat.Text,
                        ConvertDatetime(makNgayBatDau.Text), ConvertDatetime(makNgayKetThuc.Text), txtMaHangHoa.Text, bb.ToString(), bl.ToString(), gn.ToString(), true, "", false);
                    networkStream = cl.SerializeObj(this.tcpClient, "CapNhatGia", nv);
                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(networkStream, msg);
                    if (msg == 1)
                    {
                        txtMaCapNhat.Text = LayID("CapNhatGia");
                        makNgayBatDau.Text = "";
                        makNgayKetThuc.Text = "";
                        txtGN.Text = "";
                        txtPhanTramBB.Text = "";
                        txtPhanTramBL.Text = "";
                        HienThiDgvChinhSachGiaKhuyenMai(txtMaHangHoa.Text);
                    }
                    else
                        MessageBox.Show("Insert that bai");
                }
            }
        }
        #endregion
        private void txtGiaBanBuon_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(txtGiaBanBuon.Text);
            }
            catch
            {
                MessageBox.Show("Bạn nhập sai Giá", "Hệ thống cảnh báo");
                txtGiaBanBuon.Text = "0";
                return;
            }
        }

        private void txtGiaBanLe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(txtGiaBanLe.Text);
            }
            catch
            {
                MessageBox.Show("Bạn nhập sai Giá", "Hệ thống cảnh báo");
                txtGiaBanLe.Text = "0";
                return;
            }
        }

        private void txtMucDatHang_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(txtMucDatHang.Text);
            }
            catch
            {
                MessageBox.Show("Bạn nhập sai Mức đặt hàng", "Hệ thống cảnh báo");
                txtMucDatHang.Text = "0";
                return;
            }
        }

        private void txtMucTonToiThieu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(txtMucTonToiThieu.Text);
            }
            catch
            {
                MessageBox.Show("Bạn nhập sai Mức tồn tối thiểu", "Hệ thống cảnh báo");
                txtMucTonToiThieu.Text = "0";
                return;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void cbbLoaiHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Entities.LoaiHangHoa[] lh = (Entities.LoaiHangHoa[])cbbLoaiHangHoa.DataSource;
                if (lh != null)
                    LayMaNhomHangHoa(lh[cbbLoaiHangHoa.SelectedIndex].MaLoaiHang);
            }
            catch { }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!e.TabPage.Enabled)
            {
                if (e.TabPage.Text.Equals("Quy đổi đơn vị tính"))
                {
                    MessageBox.Show("Bạn phải thêm mới hàng hóa trước khi nhập Quy đổi đơn vị tính cho nó", "Hệ thống cảnh báo");
                }
                e.Cancel = true;
            }
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
            return false;
        }

        public string XuLyChuoiSo(string str)
        {
            string[] arr = new string[0];
            if (str.Length > 3)
            {
                arr = str.Split(',');
                str = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    str += arr[i];
                }
            }
            return str;
        }

        public string hienthiso(string str)
        {
            string s = str;
            for (int i = str.Length - 1; i >= 0; i = i - 3)
            {
                s.Insert(i, ",");
            }
            return s;
        }

        private void txtMucTonToiThieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch
            { }
        }

        private void txtMucDatHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch
            { }
        }

        private void txtGiaNhap_TextChanged_2(object sender, EventArgs e)
        {
            try
            {
                new TienIch().AutoFormatMoney(sender);
                txtGN.Text = txtGiaNhap.Text.Replace(",", "");
            }
            catch { }
        }

        private void txtGiaBanBuon_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                new TienIch().AutoFormatMoney(sender);
            }
            catch { }
        }

        private void txtGiaBanLe_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                new TienIch().AutoFormatMoney(sender);
            }
            catch { }
        }

        private void txtMucTonToiThieu_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(txtMucTonToiThieu.Text) >= 0)
                {
                    txtMucTonToiThieu.Text = String.Format("{0:0}", txtMucTonToiThieu.Text);
                    return;
                }
            }
            catch
            {
                txtMucTonToiThieu.Text = "";
            }
        }

        private void txtMucDatHang_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(txtMucDatHang.Text) >= 0)
                {
                    txtMucDatHang.Text = String.Format("{0:0}", txtMucDatHang.Text);
                    return;
                }
            }
            catch
            {
                txtMucDatHang.Text = "";
            }
        }

        private bool testCharacter(char ch)
        {
            char[] a = new char[]{'+','-','~','`','@','#','$','%','^','&','*','(',')','{','}','[',']',':',';','|',
                '<','>',',','.','?','/','-','=',' ',
                'ă','â','á','à','ả','ạ','ã','ắ','ằ','ẳ','ẵ','ặ','ấ','ầ','ẩ','ậ','ẫ',
                'Ă','Â','Á','À','Ả','Ạ','Ã','Ắ','Ằ','Ẳ','Ẵ','Ặ','Ấ','Ầ','Ẩ','Ẫ','Ậ',
                'ê','é','è','ẻ','ẽ','ẹ','ế','ề','ể','ễ','ệ',
                'Ê','É','È','Ẻ','Ẽ','Ẹ','Ế','Ề','Ể','Ễ','Ệ',
                'ô','ơ','ó', 'ò', 'ỏ', 'ọ', 'õ','ố', 'ồ','ổ', 'ộ','ỗ','ớ','ờ','ở','ợ','ỡ',
                'Ô','Ó', 'Ò', 'Ỏ', 'Õ', 'Ọ','Ố', 'Ồ','Ổ', 'Ộ','Ỗ','Ớ','Ờ','Ở','Ợ','Ỡ',
                'ư','ú','ù','ủ','ụ','ũ', 'ứ','ừ', 'ử', 'ự', 'ữ',
                'Ư','Ú','Ù','Ủ','Ụ','Ũ', 'Ứ','Ừ', 'Ử', 'Ự', 'Ữ',
                'í','ì','ỉ','ị','ĩ',
                'Í','Ì','Ỉ','Ị','Ĩ',
                'đ','Đ'
                };
            foreach (char c in a)
            {
                if (c.Equals(ch))
                    return true;
            }
            return false;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            if (tssThem.Enabled == false)
            {
                txtMaHangHoa.Enabled = true;
                txtMaHangHoa.Text = "";
                tssThem.Enabled = true;
                tssSua.Enabled = false;
                MessageBox.Show("Sao lưu thành công - Hãy nhập mã hàng hóa mới", "Hệ thống cảnh báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Bạn phải Thêm mới trước khi Sao lưu", "Hệ thống cảnh báo", MessageBoxButtons.OK);
            }

        }
        bool KiemTraQuyDoi()
        {
            if (tsslMaHangHoa.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Mã hàng quy đổi", "Hệ thống cảnh báo");
                return false;
            }
            foreach (char ch in tsslMaHangHoa.Text)
            {
                if (testCharacter(ch))
                {
                    MessageBox.Show("        Mã Hàng Hóa Không được nhập tiếng việt có dấu " +
                                  "\nNếu bạn đang dùng máy quét mã vạch hãy tắt bộ gõ Tiếng Tiệt đi! ", "Hệ Thống Cảnh Báo");
                    txtMaHangHoa.Focus();
                    txtMaHangHoa.SelectAll();
                    return false;
                }
            }
            if (tsslDVT.Text == "<F4 - Tra cứu>")
            {
                MessageBox.Show("Bạn phải nhập Đơn vị tính", "Hệ thống cảnh báo");
                return false;
            }
            if (tsslSoLuong.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Số lượng", "Hệ thống cảnh báo");
                return false;
            }
            int soluong = 0;
            try
            {
                soluong = Convert.ToInt32(tsslSoLuong.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Số lượng phải là số", "Hệ thống cảnh báo");
                tsslSoLuong.Focus();
                return false;
            }

            if (soluong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Hệ thống cảnh báo");
                tsslSoLuong.Focus();
                return false;
            }

            return true;
        }
        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraQuyDoi())
                {
                    if (CheckConflictInsertQuyDoi())
                    {
                        Entities.DVT dvt = (Entities.DVT)cmbMaDonViTinh.SelectedItem;
                        Server_Client.Client cl = new Server_Client.Client();
                        this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.QuyDoiDonViTinh nv = new Entities.QuyDoiDonViTinh();
                        nv = new Entities.QuyDoiDonViTinh("Insert", 0, maquydoidvt, tsslMaHangHoa.Text, "",
                            tsslDVT.Text, 1, txtMaHangHoa.Text, txtTenHangHoa.Text,
                            dvt.TenDonViTinh, int.Parse(tsslSoLuong.Text), false, Common.Utilities.User.NhanVienID,
                            Common.Utilities.User.TenDangNhap);
                        networkStream = cl.SerializeObj(this.tcpClient, "QuyDoiDonViTinh", nv);
                        int msg = 0;
                        msg = (int)cl.DeserializeHepper(networkStream, msg);
                        if (msg == 1)
                        {
                            tsslMaHangHoa.Text = tsslSoLuong.Text = "";
                            tsslDVT.Text = "<F4 - Tra cứu>";
                            maquydoidvt = ProMaQuyDoi("QuyDoiDonViTinh");
                            QuyDoiDVT();
                            tsslMaHangHoa.Focus();
                        }
                    }
                }
            }
            catch { }
        }

        private void tsslDVT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F4)
            {
                frmTimDVT frm = new frmTimDVT();
                frm.ShowDialog();
                if (frmTimDVT.drvr != null)
                {
                    tsslDVT.Text = frmTimDVT.drvr.Cells["TenDonViTinh"].Value.ToString();
                    frmTimDVT.drvr = null;
                }
            }
        }
        int i;
        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void dgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string maKH = dgvHienThi.Rows[i].Cells["MaQuyDoiDonViTinh"].Value.ToString();
            Entities.QuyDoiDonViTinh[] temp = (Entities.QuyDoiDonViTinh[])dgvHienThi.DataSource;
            Entities.QuyDoiDonViTinh tem = temp[i];

            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 3))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            if (new Check().CheckReference("QD", maKH))
            {
                DialogResult dlgResult = MessageBox.Show("Bạn Có Chắc Chắn muốn Xóa Quy Đổi này không?", "Đồng ý?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlgResult == DialogResult.Yes)
                {
                    try
                    {
                        if (CheckConflictDeleteQuyDoi())
                        {
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                            Entities.QuyDoiDonViTinh kh = new Entities.QuyDoiDonViTinh();
                            kh = new Entities.QuyDoiDonViTinh("Delete", int.Parse(dgvHienThi.Rows[i].Cells["QuyDoiDonViTinhID"].Value.ToString()), Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                            clientstrem = cl.SerializeObj(this.client1, "QuyDoiDonViTinh", kh);
                            bool kt = false;
                            kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                            if (kt == true)
                            {
                                tsslDVT.Text = tem.MaDonViTinh;
                                tsslMaHangHoa.Text = tem.MaHangQuyDoi;
                                tsslSoLuong.Text = tem.SoLuongDuocQuyDoi.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Mã Quy Đổi này đã bị xóa");
                            }
                            QuyDoiDVT();
                        }
                        else
                        {
                            MessageBox.Show("Mã Quy Đổi này đã bị xóa");
                        }
                    }
                    catch { }
                }
            }
            else
            {
                MessageBox.Show("mã quy đổi này này không  thể xóa! Hiện tại đang có giao dịch");
            }
        }

        public Boolean CheckConflictDeleteQuyDoi()
        {
            Boolean check = false;
            try
            {
                string maKH = dgvHienThi.Rows[i].Cells["MaQuyDoiDonViTinh"].Value.ToString();
                cl = new Server_Client.Client();
                // gán TCPclient
                this.tcpClient = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.QuyDoiDonViTinh ncc = new Entities.QuyDoiDonViTinh("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.QuyDoiDonViTinh[] ncc1 = new Entities.QuyDoiDonViTinh[1];
                networkStream = cl.SerializeObj(this.tcpClient, "QuyDoiDonViTinh", ncc);
                // đổ mảng đối tượng vào datagripview       
                ncc1 = (Entities.QuyDoiDonViTinh[])cl.DeserializeHepper1(networkStream, ncc1);
                for (int j = 0; j < ncc1.Length; j++)
                {
                    if (ncc1[j].MaQuyDoiDonViTinh == maKH)
                    {
                        check = true;
                        break;
                    }
                    else { check = false; }
                }
            }
            catch { check = false; }
            return check;
        }

        private void tsslSoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(tsslSoLuong.Text) >= 0)
                {
                    tsslSoLuong.Text = String.Format("{0:0}", tsslSoLuong.Text);
                    return;
                }
            }
            catch { tsslSoLuong.Text = ""; }
        }

        private void tsslSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                toolStrip_btnThem_Click(sender, e);
            }
        }

        private void btnThemLoaiHang_Click(object sender, EventArgs e)
        {
            try
            {
                frmXuLyLoaiHangHoa qlkh = new frmXuLyLoaiHangHoa("Thu", "Them");
                qlkh.ShowDialog();
                LayLoaiHangHoa();
            }
            catch { }
        }

        private void btnThemNhomHang_Click(object sender, EventArgs e)
        {
            try
            {
                frmXuLyNhomHangHoa tnhh = new frmXuLyNhomHangHoa("Insert");
                tnhh.ShowDialog();
                Entities.LoaiHangHoa lhh = new Entities.LoaiHangHoa();
                lhh = (Entities.LoaiHangHoa)cbbLoaiHangHoa.SelectedValue;
                string maLoai = lhh.MaLoaiHang;
                LayMaNhomHangHoa(maLoai);
            }
            catch { }
        }

        private void btnThemDonViTinh_Click(object sender, EventArgs e)
        {
            try
            {
                frmXuLyDonViTinh qlkh = new frmXuLyDonViTinh("Thu", "Them");
                qlkh.ShowDialog();
                LayMaDonViTinh();
            }
            catch { }
        }
    }
}
