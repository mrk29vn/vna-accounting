using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAL;
using BizLogic;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.Collections;

namespace GUI
{
    public partial class frmXuLyKhachHang : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        DateTime datesv;
        Entities.DiemThuongKhachHang[] dtkh = new Entities.DiemThuongKhachHang[0];

        public frmXuLyKhachHang(DataGridViewRow dgvkhachhang)
        {
            datesv = DateServer.Date();
            InitializeComponent();
        }
        public frmXuLyKhachHang()
        {
            InitializeComponent();
            datesv = DateServer.Date();
            makh = txtmakh.Text;
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
        string id;
        string makh, ten, diachi, dienthoai, fax, email, mst, duno, hanmucthanhtoan, congty, ngaysinh, mavung, mobi, ngaythamgia, giaodichcuoi, ngungtheodoi, website, ngaysua, ghichu;
        public frmXuLyKhachHang(string str1, string str2, DataGridViewRow dgvkhachhang)
        {
            try
            {
                InitializeComponent();
                XuLyString(str1, str2);
                id = dgvkhachhang.Cells["KhachHangID"].Value.ToString();
                makh = txtmakh.Text = dgvkhachhang.Cells["MaKH"].Value.ToString();
                ten = txthoten.Text = dgvkhachhang.Cells["Ten"].Value.ToString();
                diachi = txtdiachi.Text = dgvkhachhang.Cells["DiaChi"].Value.ToString();
                dienthoai = mktxtsodienthoai.Text = dgvkhachhang.Cells["DienThoai"].Value.ToString();
                fax = txtfax.Text = dgvkhachhang.Cells["Fax"].Value.ToString();
                email = txtemail.Text = dgvkhachhang.Cells["Email"].Value.ToString();
                mst = txtmasothue.Text = dgvkhachhang.Cells["MST"].Value.ToString();
                duno = txtduno.Text = String.Format("{0:0.0}", float.Parse(dgvkhachhang.Cells["DuNo"].Value.ToString()));
                hanmucthanhtoan = txthanmucthanhtoan.Text = dgvkhachhang.Cells["HanMucTT"].Value.ToString();
                congty = txtcongty.Text = dgvkhachhang.Cells["CongTy"].Value.ToString();
                ngaysinh = maktxtngaysinh.Text = new Common.Utilities().XuLy(2, dgvkhachhang.Cells["NgaySinh"].Value.ToString());
                mavung = txtmavung.Text = dgvkhachhang.Cells["MaVung"].Value.ToString();
                mobi = mktxtmobile.Text = dgvkhachhang.Cells["Mobi"].Value.ToString();
                //ngaythamgia = mktxtngaythamgia.Text = new Common.Utilities().XuLy(2, dgvkhachhang.Cells["NgayThamGia"].Value.ToString());
                //giaodichcuoi = maskedTextBox1.Text = new Common.Utilities().XuLy(2, dgvkhachhang.Cells["GiaoDichCuoi"].Value.ToString());
                website = txtwebsite.Text = dgvkhachhang.Cells["Website"].Value.ToString();
                //ngaysua = mktxtngaysua.Text = new Common.Utilities().XuLy(2, dgvkhachhang.Cells["NgaySua"].Value.ToString());
                ghichu = txtghichu.Text = dgvkhachhang.Cells["GhiChu"].Value.ToString();
                Entities.DonHang[] lay = new Entities.DonHang[0];
                dataGridView1.DataSource = lay;
                for (int j = 1; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Columns[j].Visible = false;
                }
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = true;
                dataGridView1.Columns[1].HeaderText = "Mã Khách Hàng";
                dataGridView1.Columns[2].Visible = true;
                dataGridView1.Columns[2].HeaderText = "Mã Đơn Đặt Hàng";
                dataGridView1.Columns[3].Visible = true;
                dataGridView1.Columns[3].HeaderText = "Ngày Đơn Hàng";
                dataGridView1.Columns[4].Visible = true;
                dataGridView1.Columns[4].HeaderText = "Hình Thức Thanh Toán";
                dataGridView1.Columns[5].Visible = true;
                dataGridView1.Columns[5].HeaderText = "Ghi Chú";
                dataGridView1.Columns[6].HeaderText = "Tổng Tiền Thanh Toán";
                dataGridView1.Columns[6].Visible = true;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AllowUserToResizeRows = false;
            }
            catch
            {
            }
        }
        Entities.HDBanHang[] pt1;
        //Entities.HDBanHang[] hienthi;
        public void SelectData1()
        {
            try
            {
                double duNoHoaDon = 0;
                DateTime dateServer = DateServer.Date();
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.HDBanHang pt = new Entities.HDBanHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                pt1 = new Entities.HDBanHang[1];
                clientstrem = cl.SerializeObj(this.client1, "HDBanHang", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.HDBanHang[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 == null)
                    pt1 = new Entities.HDBanHang[0];
                List<Entities.HDBanHang> hdBanHanList = new List<Entities.HDBanHang>();

                for (int j = 0; j < pt1.Length; j++)
                {
                    int YY = dateServer.Year;
                    int MM = dateServer.Month;
                    int DD = dateServer.Day;
                    if (pt1[j].MaKhachHang == makh)
                    {
                        double thanhToanNgay = 0;
                        double thanToanKhiLapPhieu = 0;
                        double tongTienThanhToan = 0;

                        if (!string.IsNullOrEmpty(pt1[j].ThanhToanNgay))
                            thanhToanNgay = double.Parse(pt1[j].ThanhToanNgay);

                        if (!string.IsNullOrEmpty(pt1[j].ThanhToanKhiLapPhieu))
                            thanToanKhiLapPhieu = double.Parse(pt1[j].ThanhToanKhiLapPhieu);

                        if (!string.IsNullOrEmpty(pt1[j].TongTienThanhToan))
                            tongTienThanhToan = double.Parse(pt1[j].TongTienThanhToan);

                        duNoHoaDon = thanhToanNgay + thanToanKhiLapPhieu - tongTienThanhToan;

                        DateTime hanthanhtoan = pt1[j].HanThanhToam;
                        if (YY == hanthanhtoan.Year && MM == hanthanhtoan.Month && (hanthanhtoan.Day - DD) <= 3 && (hanthanhtoan.Day - DD) >= 0 && duNoHoaDon != 0)
                        {
                            hdBanHanList.Add(pt1[j]);
                        }
                    }
                }

                int tem = 32;
                Entities.HDBanHang hdTem = null;
                foreach (Entities.HDBanHang item in hdBanHanList)
                {
                    int DD = item.HanThanhToam.Day;
                    if (tem > DD)
                    {
                        tem = DD;
                        hdTem = new Entities.HDBanHang();
                        hdTem = item;
                    }
                }

                if (tem != 0 && hdTem != null && !string.IsNullOrEmpty(hdTem.MaHDBanHang))
                    label3.Text = "Sắp tới hạn thanh toán của khách hàng " + hdTem.HanThanhToam.ToString("dd/MM/yyyy");
            }
            catch { }
        }
        public frmXuLyKhachHang(string str1, string str2)
        {
            InitializeComponent();
            datesv = DateServer.Date();
            XuLyString(str1, str2);
        }

        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        public void XuLyString(string str1, string str2)
        {
            try
            {
                if (str1 == "Thu" && str2 == "Them")
                {

                    this.Text = " Quản lý Khách Hàng - Thêm mới Khách hàng";
                    paneldatagv.Enabled = false;
                    panel1.Enabled = false;
                    tsslblghilai.Enabled = false;
                    txtmakh.Text = ProID("KhachHang");
                    tablichsugiaodich.Enabled = false;
                    tabchinhsachgiakm.Enabled = false;
                    TabTheVip.Enabled = false;
                    //mktxtngaysua.Text = new Common.Utilities().XuLy(2, datesv.ToShortDateString());
                    //mktxtngaythamgia.Text = new Common.Utilities().XuLy(2, datesv.ToShortDateString());
                    //maskedTextBox1.Text = new Common.Utilities().XuLy(2, datesv.ToShortDateString());
                }
                if (str1 == "Thu" && str2 == "Sua")
                {
                    this.Text = " Quản lý Khách Hàng - Sửa Khách hàng";
                    tsslblthemmoi.Enabled = false;
                    txtmacapnhatgiakh.Text = ProID1("CapNhatGiaKhachHang");

                }
            }
            catch
            { }

        }

        private void tsslbltrove_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.Close();
                        frmQuanLyKhachHang.trave = "A";
                    }
                    else
                    { }
                }
            }
            catch
            { }
        }
        string kt;
        public void CheckConflictInsert()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.KhachHang kh = new Entities.KhachHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.KhachHang[] kh1 = new Entities.KhachHang[1];
                clientstrem = cl.SerializeObj(this.client1, "KhachHang", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.KhachHang[])cl.DeserializeHepper1(clientstrem, kh1);

                if (kh1 != null)
                {
                    for (int j = 0; j < kh1.Length; j++)
                    {
                        if (kh1[j].MaKH == makh)
                        {
                            MessageBox.Show("cập nhật mã khách hàng - kiểm tra lại để insert");
                            kt = "ko";
                            makh = txtmakh.Text = ProID("KhachHang");
                            break;
                        }
                        else
                            kt = "ok";
                    }

                }
                else
                    kt = "ok";

            }
            catch
            {
            }
        }
        Entities.KhachHang[] kh1;
        Server_Client.Client cl;
        public void CheckConflictUpdate()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.KhachHang kh = new Entities.KhachHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                kh1 = new Entities.KhachHang[1];
                clientstrem = cl.SerializeObj(this.client1, "KhachHang", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.KhachHang[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 != null)
                {
                    for (int j = 0; j < kh1.Length; j++)
                    {
                        if (kh1[j].MaKH == makh)
                        {

                            kt = Check(kh1[j]);
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


        public string Check(Entities.KhachHang kh)
        {
            try
            {
                string gt = "ok";

                if (ten != kh.Ten)
                {
                    ten = txthoten.Text = kh.Ten;
                    gt = "ko";
                }
                if (diachi != kh.DiaChi)
                {
                    diachi = txtdiachi.Text = kh.DiaChi;
                    gt = "ko";
                }
                if (dienthoai != kh.DienThoai)
                {
                    dienthoai = mktxtsodienthoai.Text = kh.DienThoai;
                    gt = "ko";
                }
                if (fax != kh.Fax)
                {
                    fax = txtfax.Text = kh.Fax;
                    gt = "ko";
                }
                if (email != kh.Email)
                {
                    email = txtemail.Text = kh.Email;
                    gt = "ko";
                }
                if (mst != kh.MST)
                {
                    mst = txtmasothue.Text = kh.MST;
                    gt = "ko";
                }
                string dunonew = String.Format("{0:0.0}", float.Parse(kh.DuNo.ToString()));
                if (duno != dunonew)
                {
                    duno = txtduno.Text = dunonew;
                    gt = "ko";
                }
                string hmtt = String.Format("{0:0.0}", float.Parse(kh.HanMucTT.ToString()));
                if (hanmucthanhtoan != kh.HanMucTT.ToString())
                {
                    hanmucthanhtoan = txthanmucthanhtoan.Text = hmtt;
                    gt = "ko";
                }
                if (congty != kh.CongTy)
                {
                    congty = txtcongty.Text = kh.CongTy;
                    gt = "ko";
                }
                string datetimenew = new Common.Utilities().XuLy(2, kh.NgaySinh.ToString());
                if (ngaysinh != datetimenew)
                {
                    ngaysinh = maktxtngaysinh.Text = datetimenew;
                    gt = "ko";
                }
                if (mavung != kh.MaVung.ToString())
                {
                    mavung = txtmavung.Text = (kh.MaVung.ToString());
                    gt = "ko";
                }
                if (mobi != kh.Mobi)
                {
                    mobi = mktxtmobile.Text = kh.Mobi;
                    gt = "ko";
                }
                string datetimenew1 = new Common.Utilities().XuLy(2, kh.NgayThamGia.ToString());
                //if (ngaythamgia != datetimenew1)
                //{
                //    ngaythamgia = mktxtngaythamgia.Text = datetimenew1;
                //    gt = "ko";
                //}
                string datetimenew2 = new Common.Utilities().XuLy(2, kh.GiaoDichCuoi.ToString());
                //if (giaodichcuoi != datetimenew2)
                //{
                //    giaodichcuoi = maskedTextBox1.Text = datetimenew2;
                //    gt = "ko";
                //}
                if (website != kh.Website)
                {
                    website = txtwebsite.Text = kh.Website;
                    gt = "ko";
                }
                string datetimenew3 = new Common.Utilities().XuLy(2, kh.NgaySua.ToString());
                //if (ngaysua != datetimenew3)
                //{
                //    ngaysua = mktxtngaysua.Text = datetimenew3;
                //    gt = "ko";
                //}
                if (ghichu != kh.GhiChu)
                {
                    ghichu = txtghichu.Text = kh.GhiChu;
                    gt = "ko";
                }
                return gt;
            }
            finally
            { }
        }
        bool td;
        int nam;
        public string checkDateTime(string datetime)
        {
            try
            {
                if (datetime.Length < 10)
                {
                    return "Ngày Tháng năm phải nhập đầy đủ";
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
                if ((int.Parse(yyyy) > 9999) || (int.Parse(yyyy) < 1753))
                {
                    return "Năm phải nhỏ hơn 9999 và lớn hơn 1753";
                }
                return "true";
            }
            finally
            { }

        }
        private bool Kiemtra()
        {
            try
            {
                if (txtmakh.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + lblmakh.Text, "Hệ thống cảnh báo");
                    txtmakh.Focus();
                    return false;
                }
                if (checkDateTime(maktxtngaysinh.Text) != "true")
                {
                    MessageBox.Show(checkDateTime(maktxtngaysinh.Text), "Hệ Thống Cảnh Báo");
                    maktxtngaysinh.Focus();
                    return false;
                }
                if (txthoten.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập " + lblhoten.Text, "Hệ thống cảnh báo");
                    txthoten.Focus();
                    return false;
                }
                if (txthoten.Text.Length >= 100)
                {
                    MessageBox.Show("Tên khách hàng không thể quá 100 kí tự ", "Hệ thống cảnh báo");
                    txthoten.Focus();
                    return false;
                }
                if (txtmasothue.Text.Length >= 21)
                {
                    MessageBox.Show("mã số thuế khách hàng không thể quá 20 kí tự ", "Hệ thống cảnh báo");
                    txtmasothue.Focus();
                    return false;
                }
                if (txtcongty.Text.Length >= 100)
                {
                    MessageBox.Show("Tên khách hàng không thể quá 100 kí tự ", "Hệ thống cảnh báo");
                    txtcongty.Focus();
                    return false;
                }
                if (txtdiachi.Text.Length >= 100)
                {
                    MessageBox.Show("địa chỉ khách hàng không thể quá 100 kí tự ", "Hệ thống cảnh báo");
                    txtdiachi.Focus();
                    return false;
                }
                if (txtwebsite.Text.Length >= 100)
                {
                    MessageBox.Show("website khách hàng không thể quá 100 kí tự ", "Hệ thống cảnh báo");
                    txtwebsite.Focus();
                    return false;
                }
                if (txtghichu.Text.Length >= 100)
                {
                    MessageBox.Show("ghi chú khách hàng không thể quá 100 kí tự ", "Hệ thống cảnh báo");
                    txtghichu.Focus();
                    return false;
                }
                if (txtmavung.Text.Length >= 6)
                {
                    MessageBox.Show("mã vùng khách hàng không thể quá 5 kí tự ", "Hệ thống cảnh báo");
                    txtmavung.Focus();
                    return false;
                }
                if (mktxtsodienthoai.Text.Length >= 12)
                {
                    MessageBox.Show("số điện thoại khách hàng không thể quá 11 kí tự ", "Hệ thống cảnh báo");
                    mktxtsodienthoai.Focus();
                    return false;
                }
                if (txtfax.Text.Length >= 12)
                {
                    MessageBox.Show("fax khách hàng không thể quá 11 kí tự ", "Hệ thống cảnh báo");
                    txtfax.Focus();
                    return false;
                }
                if (mktxtmobile.Text.Length >= 12)
                {
                    MessageBox.Show("mobile khách hàng không thể quá 11 kí tự ", "Hệ thống cảnh báo");
                    mktxtmobile.Focus();
                    return false;
                }
                if (txtemail.Text.Length >= 51)
                {
                    MessageBox.Show("email khách hàng không thể quá 50 kí tự ", "Hệ thống cảnh báo");
                    txtemail.Focus();
                    return false;
                }

            }
            catch
            {

            }
            return true;
        }
        string ktgiatri = "";
        private void tsslblthemmoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (Kiemtra())
                {
                    CheckConflictInsert();
                    if (kt == "ok")
                    {
                        /////////////////////////////////////////////MRK FIX
                        //if (string.IsNullOrEmpty(txtmavung.Text))
                        //    txtmavung.Text = "0";
                        //if (string.IsNullOrEmpty(txthanmucthanhtoan.Text))
                        //    txthanmucthanhtoan.Text = "0";
                        //if (string.IsNullOrEmpty(txtduno.Text))
                        //    txtduno.Text = "0";
                        //if (maktxtngaysinh.Text.Equals(""))
                        //{
                        //    maktxtngaysinh.Text = "01/01/1753";
                        //}
                        //ktgiatri = "a";

                        //Server_Client.Client cl = new Server_Client.Client();
                        //// gán TCPclient
                        //this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        //// khởi tạo biến truyền vào với hàm khởi tạo
                        //ArrayList KArr = new ArrayList();
                        //KArr.Add("ThaoTac_KhachHang");
                        //KArr.Add("Insert_KHACHHANG");
                        //KArr.Add(new Entities.KhachHang_k("", txtmakh.Text, txthoten.Text, txtdiachi.Text, mktxtsodienthoai.Text, txtfax.Text, txtemail.Text, txtmasothue.Text, float.Parse(txtduno.Text), float.Parse(txthanmucthanhtoan.Text), txtcongty.Text, DateTime.Parse(maktxtngaysinh.Text), int.Parse(txtmavung.Text), mktxtmobile.Text, datesv, datesv, false, txtwebsite.Text, datesv, txtghichu.Text, false));
                        //KArr.Add(new Entities.KhachHang_k());
                        //clientstrem = cl.SerializeObj(this.client1, "KhachHang_k", KArr);
                        ////// khởi tạo mảng đối tượng để hứng giá trị
                        ////Entities.KhachHang_k[] kq = new Entities.KhachHang_k[1];
                        ////// đổ mảng đối tượng vào datagripview     
                        ////kq = (Entities.KhachHang_k[])cl.DeserializeHepper1(clientstrem, kq);
                        //int kq = 0;
                        //kq = (int)cl.DeserializeHepper(clientstrem, kq);
                        //if (kq != 0)
                        //{
                        //    this.Close();
                        //    txtmakh.Text = new Common.Utilities().ProcessID(txtmakh.Text);
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Thêm Thất Bại!", "Hệ Thống Cảnh Báo");
                        //}
                        ////////////////////////////////////////////////////

                        //if (mktxtngaythamgia.Text == "" || mktxtngaysua.Text == "" || maskedTextBox1.Text == "" || txtdiachi.Text == "" || mktxtsodienthoai.Text == "" || txtfax.Text == "" || txtemail.Text == "" || txtmasothue.Text == "" || txtduno.Text == "" || txthanmucthanhtoan.Text == "" || txtcongty.Text == "" || txtmavung.Text == "" || mktxtmobile.Text == "" || txtwebsite.Text == "" || txtghichu.Text == "")
                        //{
                        //    mktxtngaysua.Text = new Common.Utilities().XuLy(2, datesv.ToShortDateString());
                        //    maskedTextBox1.Text = new Common.Utilities().XuLy(2, datesv.ToShortDateString());
                        //    mktxtngaythamgia.Text = new Common.Utilities().XuLy(2, datesv.ToShortDateString());

                        //}
                        if (string.IsNullOrEmpty(txtmavung.Text))
                            txtmavung.Text = "0";
                        if (string.IsNullOrEmpty(txthanmucthanhtoan.Text))
                            txthanmucthanhtoan.Text = "0";
                        if (string.IsNullOrEmpty(txtduno.Text))
                            txtduno.Text = "0";
                        ktgiatri = "a";
                        Server_Client.Client cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.KhachHang nv;
                        string date1 = new Common.Utilities().MyDateConversion(maktxtngaysinh.Text);
                        //string date2 = new Common.Utilities().MyDateConversion(mktxtngaythamgia.Text);
                        //string date3 = new Common.Utilities().MyDateConversion(mktxtngaysua.Text);
                        //string date4 = new Common.Utilities().MyDateConversion(maskedTextBox1.Text);
                        nv = new Entities.KhachHang("Insert", 0, txtmakh.Text, txthoten.Text, txtdiachi.Text, mktxtsodienthoai.Text, txtfax.Text, txtemail.Text, txtmasothue.Text,
                        txtduno.Text, txthanmucthanhtoan.Text, txtcongty.Text, Convert.ToDateTime(date1), int.Parse(txtmavung.Text),
                        mktxtmobile.Text, datesv, datesv, false, txtwebsite.Text, datesv, txtghichu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);

                        clientstrem = cl.SerializeObj(this.client1, "KhachHang", nv);
                        int msg = 0;
                        msg = (int)cl.DeserializeHepper(clientstrem, msg);
                        if (msg == 1)
                        {
                            this.Close();
                        }

                        else
                        {
                            MessageBox.Show("Mã khách hàng đã bị thay đổi - Kiểm tra lại dữ liệu");
                            txtmakh.Text = new Common.Utilities().ProcessID(txtmakh.Text);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Kiếm tra lại dữ liệu nhập vào");
            }
        }
        /// <summary>
        /// Lấy giá trị id cuối cùng
        /// </summary>
        /// <param name="tenBang"></param>
        /// <returns></returns>
        public string ProID(string tenBang)
        {
            try
            {
                string idnew;
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.LayID lid = new Entities.LayID();
                clientstrem = cl.SerializeObj(this.client1, "LayID", lid1);
                // đổ mảng đối tượng vào datagripview       
                lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, lid);
                if (lid == null)
                {
                    return "KH_0001";
                }
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            finally
            { }
        }
        /// <summary>
        /// Lấy giá trị id cuối cùng
        /// </summary>
        /// <param name="tenBang"></param>
        /// <returns></returns>
        public string ProID1(string tenBang)
        {
            try
            {
                string idnew;
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.LayID lid = new Entities.LayID();
                clientstrem = cl.SerializeObj(this.client1, "LayID", lid1);
                // đổ mảng đối tượng vào datagripview       
                lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, lid);
                if (lid == null)
                {
                    return "CNGKH_0001";
                }
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            finally
            { }

        }
        private void tsslblghilai_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Kiemtra())
                {
                    return;
                }
                //CheckConflictUpdate();

                //if (mktxtngaythamgia.Text == "" || mktxtngaysua.Text == "" || maskedTextBox1.Text == "" || txtdiachi.Text == "" || mktxtsodienthoai.Text == "" || txtfax.Text == "" || txtemail.Text == "" || txtmasothue.Text == "" || txtduno.Text == "" || txthanmucthanhtoan.Text == "" || txtcongty.Text == "" || txtmavung.Text == "" || mktxtmobile.Text == "" || txtwebsite.Text == "" || txtghichu.Text == "")
                //{
                //    mktxtngaysua.Text = new Common.Utilities().XuLy(2, datesv.ToShortDateString());
                //    maskedTextBox1.Text = new Common.Utilities().XuLy(2, datesv.ToShortDateString());
                //    mktxtngaythamgia.Text = new Common.Utilities().XuLy(2, datesv.ToShortDateString());

                //}
                if (string.IsNullOrEmpty(txtmavung.Text))
                    txtmavung.Text = "0";
                if (string.IsNullOrEmpty(txthanmucthanhtoan.Text))
                    txthanmucthanhtoan.Text = "0";
                if (string.IsNullOrEmpty(txtduno.Text))
                    txtduno.Text = "0";
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KhachHang nv = new Entities.KhachHang();
                nv = new Entities.KhachHang("Update", int.Parse(id), txtmakh.Text, txthoten.Text, txtdiachi.Text, mktxtsodienthoai.Text, txtfax.Text, txtemail.Text, txtmasothue.Text,
                 txtduno.Text, txthanmucthanhtoan.Text, txtcongty.Text, xulyNgayInsert(maktxtngaysinh.Text), int.Parse(txtmavung.Text),
                 mktxtmobile.Text, datesv, datesv, false, txtwebsite.Text, datesv, txtghichu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                clientstrem = cl.SerializeObj(this.client1, "KhachHang", nv);
                int msg = 0;
                msg = (int)cl.DeserializeHepper(clientstrem, msg);
                if (!msg.Equals(1))
                {
                    MessageBox.Show("Thất Bại");
                }
                this.Close();

            }
            catch
            {
                MessageBox.Show("Kiếm tra lại dữ liệu nhập vào");
            }
        }

        private void frmXuLyKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (ktgiatri == "")
                    frmQuanLyKhachHang.trave = "A";
            }
            catch
            { }
        }
        Entities.DonHang[] hienthi;
        private void rdbtndonhang_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbtndonhang.Checked == true)
                {
                    dataGridView1.RowHeadersVisible = false;
                    cl = new Server_Client.Client();
                    // gán TCPclient
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    // khởi tạo biến truyền vào với hàm khởi tạo
                    Entities.DonHang lsgd = new Entities.DonHang();
                    // truyền HanhDong
                    lsgd = new Entities.DonHang("Select", makh);

                    clientstrem = cl.SerializeObj(this.client1, "DonHang", lsgd);
                    // khởi tạo mảng đối tượng để hứng giá trị
                    Entities.DonHang[] lsgd1;
                    lsgd1 = new Entities.DonHang[1];
                    // đổ mảng đối tượng vào datagripview       
                    lsgd1 = (Entities.DonHang[])cl.DeserializeHepper1(clientstrem, lsgd1);
                    int sotang = 0;
                    if (lsgd1 == null)
                    {
                        Entities.DonHang[] lay = new Entities.DonHang[0];
                        dataGridView1.DataSource = lay;
                        return;
                    }

                    Entities.DonHang[] pt3 = new Entities.DonHang[lsgd1.Length];
                    for (int j = 0; j < lsgd1.Length; j++)
                    {

                        pt3[sotang] = lsgd1[j];
                        sotang++;
                    }
                    hienthi = new Entities.DonHang[sotang];
                    if (sotang != 0)
                    {
                        for (int j = 0; j < sotang; j++)
                        {
                            hienthi[j] = pt3[j];
                        }
                    }
                    else
                    {
                        Entities.DonHang[] lay = new Entities.DonHang[0];
                        dataGridView1.DataSource = lay;
                        return;
                    }
                    dataGridView1.DataSource = hienthi;
                    new Common.Utilities().CountDatagridview(dataGridView1);

                    dataGridView1.Rows[0].Selected = true;
                }
                else
                { }
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Columns[j].Visible = false;
                    }
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = true;
                    dataGridView1.Columns[1].HeaderText = "Mã Khách Hàng";
                    dataGridView1.Columns[2].Visible = true;
                    dataGridView1.Columns[2].HeaderText = "Mã Đơn Đặt Hàng";
                    dataGridView1.Columns[3].Visible = true;
                    dataGridView1.Columns[3].HeaderText = "Ngày Đơn Hàng";
                    dataGridView1.Columns[4].Visible = true;
                    dataGridView1.Columns[4].HeaderText = "Hình Thức Thanh Toán";
                    dataGridView1.Columns[5].Visible = true;
                    dataGridView1.Columns[5].HeaderText = "Ghi Chú";
                    dataGridView1.Columns[6].HeaderText = "Tổng Tiền Thanh Toán";
                    dataGridView1.Columns[6].Visible = true;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AllowUserToResizeRows = false;
                }
                catch
                { }
            }
        }
        Entities.XuatHang[] hienthi1;
        private void rdbtnxuathang_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.XuatHang xh = new Entities.XuatHang();
                // truyền HanhDong
                xh = new Entities.XuatHang("Select", txtmakh.Text);
                clientstrem = cl.SerializeObj(this.client1, "XuatHang", xh);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.XuatHang[] xh1;
                xh1 = new Entities.XuatHang[1];
                // đổ mảng đối tượng vào datagripview       
                xh1 = (Entities.XuatHang[])cl.DeserializeHepper1(clientstrem, xh1);
                int sotang = 0;
                if (xh1 == null)
                {
                    dataGridView1.DataSource = new Entities.XuatHang[0];
                    return;
                }

                Entities.XuatHang[] pt3 = new Entities.XuatHang[xh1.Length];
                for (int j = 0; j < xh1.Length; j++)
                {

                    pt3[sotang] = xh1[j];
                    sotang++;
                }
                hienthi1 = new Entities.XuatHang[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi1[j] = pt3[j];
                    }
                }
                else
                {
                    dataGridView1.DataSource = new Entities.XuatHang[0];
                    return;
                }
                dataGridView1.DataSource = hienthi1;
                new Common.Utilities().CountDatagridview(dataGridView1);

                dataGridView1.Rows[0].Selected = true;
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Columns[j].Visible = false;
                    }
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = true;
                    dataGridView1.Columns[1].HeaderText = "Mã Khách Hàng";
                    dataGridView1.Columns[2].Visible = true;
                    dataGridView1.Columns[2].HeaderText = "Mã Hóa Đơn Bán Hàng";
                    dataGridView1.Columns[3].Visible = true;
                    dataGridView1.Columns[3].HeaderText = "Ngày Bán";
                    dataGridView1.Columns[4].Visible = true;
                    dataGridView1.Columns[4].HeaderText = "Hình Thức Thanh Toán";
                    dataGridView1.Columns[5].Visible = true;
                    dataGridView1.Columns[5].HeaderText = "Ghi Chú";
                    dataGridView1.Columns[6].HeaderText = "Tổng Tiền Thanh Toán";
                    dataGridView1.Columns[6].Visible = true;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AllowUserToResizeRows = false;
                }
                catch
                { }
            }
        }
        Entities.TraLai[] hienthi2;
        private void rdbtntralai_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.TraLai tl = new Entities.TraLai();
                // truyền HanhDong
                tl = new Entities.TraLai("Select", txtmakh.Text);
                clientstrem = cl.SerializeObj(this.client1, "TraLai", tl);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.TraLai[] tl1;
                tl1 = new Entities.TraLai[1];
                // đổ mảng đối tượng vào datagripview       
                tl1 = (Entities.TraLai[])cl.DeserializeHepper1(clientstrem, tl1);

                int sotang = 0;
                if (tl1 == null)
                {
                    dataGridView1.DataSource = new Entities.TraLai[0];
                    return;
                }

                Entities.TraLai[] pt3 = new Entities.TraLai[tl1.Length];
                for (int j = 0; j < tl1.Length; j++)
                {

                    pt3[sotang] = tl1[j];
                    sotang++;
                }
                hienthi2 = new Entities.TraLai[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi2[j] = pt3[j];
                    }
                }
                else
                {
                    dataGridView1.DataSource = new Entities.TraLai[0];
                    return;
                }
                dataGridView1.DataSource = hienthi2;
                new Common.Utilities().CountDatagridview(dataGridView1);

                dataGridView1.Rows[0].Selected = true;
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Columns[j].Visible = false;
                    }
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = true;
                    dataGridView1.Columns[1].HeaderText = "Mã Khách Hàng";
                    dataGridView1.Columns[2].Visible = true;
                    dataGridView1.Columns[2].HeaderText = "Mã KH Trả Lại";
                    dataGridView1.Columns[3].Visible = true;
                    dataGridView1.Columns[3].HeaderText = "Ngày Nhập";
                    dataGridView1.Columns[4].Visible = true;
                    dataGridView1.Columns[4].HeaderText = "Hình Thức Thanh Toán";
                    dataGridView1.Columns[5].Visible = true;
                    dataGridView1.Columns[5].HeaderText = "Ghi Chú";
                    dataGridView1.Columns[6].HeaderText = "Thanh Toán Ngay";
                    dataGridView1.Columns[6].Visible = true;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AllowUserToResizeRows = false;
                }
                catch
                { }
            }
        }
        Entities.ThanhToan[] hienthi3;
        private void rdbtnthanhtoan_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ThanhToan tt = new Entities.ThanhToan();
                // truyền HanhDong
                tt = new Entities.ThanhToan("Select", txtmakh.Text);
                clientstrem = cl.SerializeObj(this.client1, "ThanhToan", tt);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.ThanhToan[] tt1;
                tt1 = new Entities.ThanhToan[1];
                // đổ mảng đối tượng vào datagripview       
                tt1 = (Entities.ThanhToan[])cl.DeserializeHepper1(clientstrem, tt1);
                int sotang = 0;
                if (tt1 == null)
                {
                    dataGridView1.DataSource = new Entities.ThanhToan[0];
                    return;
                }

                Entities.ThanhToan[] pt3 = new Entities.ThanhToan[tt1.Length];
                for (int j = 0; j < tt1.Length; j++)
                {

                    pt3[sotang] = tt1[j];
                    sotang++;
                }
                hienthi3 = new Entities.ThanhToan[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi3[j] = pt3[j];
                    }
                }
                else
                {
                    dataGridView1.DataSource = new Entities.ThanhToan[0];
                    return;
                }
                dataGridView1.DataSource = hienthi3;
                new Common.Utilities().CountDatagridview(dataGridView1);

                dataGridView1.Rows[0].Selected = true;
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Columns[j].Visible = false;
                    }
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = true;
                    dataGridView1.Columns[1].HeaderText = "Mã Khách Hàng";
                    dataGridView1.Columns[2].Visible = true;
                    dataGridView1.Columns[2].HeaderText = "Mã Phiếu TT KH";
                    dataGridView1.Columns[3].Visible = true;
                    dataGridView1.Columns[3].HeaderText = "Ngày Lập";
                    dataGridView1.Columns[4].Visible = true;
                    dataGridView1.Columns[4].HeaderText = "Trạng Thái";
                    dataGridView1.Columns[5].Visible = true;
                    dataGridView1.Columns[5].HeaderText = "Ghi Chú";
                    dataGridView1.Columns[6].HeaderText = "Thanh Toán ";
                    dataGridView1.Columns[6].Visible = true;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AllowUserToResizeRows = false;
                }
                catch
                { }
            }
        }
        Entities.LSGDHangHoa[] hienthi4;
        private void rdbtnhanghoa_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LSGDHangHoa tt = new Entities.LSGDHangHoa();
                // truyền HanhDong
                tt = new Entities.LSGDHangHoa("Select", txtmakh.Text);
                clientstrem = cl.SerializeObj(this.client1, "LSGDHangHoa", tt);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.LSGDHangHoa[] tt1;
                tt1 = new Entities.LSGDHangHoa[1];
                // đổ mảng đối tượng vào datagripview       
                tt1 = (Entities.LSGDHangHoa[])cl.DeserializeHepper1(clientstrem, tt1);
                int sotang = 0;
                if (tt1 == null)
                {
                    dataGridView1.DataSource = new Entities.LSGDHangHoa[0];
                    return;
                }

                Entities.LSGDHangHoa[] pt3 = new Entities.LSGDHangHoa[tt1.Length];
                for (int j = 0; j < tt1.Length; j++)
                {

                    pt3[sotang] = tt1[j];
                    sotang++;
                }
                hienthi4 = new Entities.LSGDHangHoa[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi4[j] = pt3[j];
                    }
                }
                else
                {
                    dataGridView1.DataSource = new Entities.LSGDHangHoa[0];
                    return;
                }
                dataGridView1.DataSource = hienthi4;
                new Common.Utilities().CountDatagridview(dataGridView1);

                dataGridView1.Rows[0].Selected = true;
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dataGridView1.ColumnCount; j++)
                    {
                        dataGridView1.Columns[j].Visible = false;
                    }
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[1].Visible = true;
                    dataGridView1.Columns[1].HeaderText = "Mã Khách Hàng";
                    dataGridView1.Columns[2].Visible = true;
                    dataGridView1.Columns[2].HeaderText = "Mã Hàng Hóa";
                    dataGridView1.Columns[3].Visible = true;
                    dataGridView1.Columns[3].HeaderText = "Tên Hàng Hóa";
                    dataGridView1.Columns[4].Visible = true;
                    dataGridView1.Columns[4].HeaderText = "Mã Đơn Vị Tính";
                    dataGridView1.Columns[5].Visible = true;
                    dataGridView1.Columns[5].HeaderText = "Số Lượng";
                    dataGridView1.Columns[6].HeaderText = "Thuế GTGT";
                    dataGridView1.Columns[6].Visible = true;
                    dataGridView1.Columns[7].HeaderText = "Tổng Tiền Thanh Toán";
                    dataGridView1.Columns[7].Visible = true;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.AllowUserToResizeRows = false;
                }
                catch
                { }
            }
        }
        string mahanghoa;

        private void txtmahanghoa_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F4)
                {
                    frmTraCuu thh = new frmTraCuu();
                    thh.ShowDialog();
                    if (frmTraCuu.drvr != null)
                    {
                        mahanghoa = frmTraCuu.drvr.Cells["MaHangHoa"].Value.ToString();
                        frmTraCuu.drvr = null;

                    }
                }
            }
            catch
            {
            }
        }

        private void txtmahanghoa_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (txtmahanghoa.Text == "")
                {
                }
            }
            catch
            {
            }

        }

        private void BindHangHoa()
        {
            try
            {
                if (GiaTriCanLuu.Loaitrave == "XuLyKhachHang")
                {
                    txtmahanghoa.Text = GiaTriCanLuu.Ma;

                }
            }
            catch
            {
            }

        }
        private void txtmahanghoa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F4)
                {
                    frmTraCuu fr = new frmTraCuu("XuLyKhachHang", "HangHoa");
                    fr.ShowDialog();
                    BindHangHoa();

                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        Entities.CapNhatGiaKhachHang[] hienthi5;
        Entities.CapNhatGiaKhachHang[] cnkh;
        public void SelectData()
        {
            try
            {

                i = 0;
                dgvkhuyenmai.RowHeadersVisible = false;
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.CapNhatGiaKhachHang kh = new Entities.CapNhatGiaKhachHang();
                // truyền HanhDong
                kh = new Entities.CapNhatGiaKhachHang("Select", txtmakh.Text);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.CapNhatGiaKhachHang[] cnkh = new Entities.CapNhatGiaKhachHang[1];
                clientstrem = cl.SerializeObj(this.client1, "CapNhatGiaKH", kh);
                // đổ mảng đối tượng vào datagripview       
                cnkh = (Entities.CapNhatGiaKhachHang[])cl.DeserializeHepper1(clientstrem, cnkh);
                int sotang = 0;
                if (cnkh == null)
                {
                    dgvkhuyenmai.DataSource = new Entities.CapNhatGiaKhachHang[0];
                    return;
                }

                Entities.CapNhatGiaKhachHang[] pt3 = new Entities.CapNhatGiaKhachHang[cnkh.Length];
                for (int j = 0; j < cnkh.Length; j++)
                {

                    pt3[sotang] = cnkh[j];
                    sotang++;
                }
                hienthi5 = new Entities.CapNhatGiaKhachHang[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi5[j] = pt3[j];
                    }
                }
                else
                {
                    dgvkhuyenmai.DataSource = new Entities.CapNhatGiaKhachHang[0];
                    return;
                }
                dgvkhuyenmai.DataSource = hienthi5;
                new Common.Utilities().CountDatagridview(dgvkhuyenmai);

                dgvkhuyenmai.Rows[0].Selected = true;
            }
            finally
            {
                try
                {
                    for (int j = 1; j < dgvkhuyenmai.ColumnCount; j++)
                    {
                        dgvkhuyenmai.Columns[j].Visible = false;
                    }
                    dgvkhuyenmai.Columns[0].Visible = false;
                    dgvkhuyenmai.Columns["MaCapNhatGiaKhachHang"].Visible = true;
                    dgvkhuyenmai.Columns["MaCapNhatGiaKhachHang"].HeaderText = "Mã Cập Nhật Giá Khách Hàng";
                    dgvkhuyenmai.Columns["MaHangHoa"].Visible = true;
                    dgvkhuyenmai.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
                    dgvkhuyenmai.Columns["MaKhachHang"].Visible = true;
                    dgvkhuyenmai.Columns["MaKhachHang"].HeaderText = "Mã Khách Hàng";
                    dgvkhuyenmai.Columns["NgayBatDau"].Visible = true;
                    dgvkhuyenmai.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
                    dgvkhuyenmai.Columns["NgayKetThuc"].Visible = true;
                    dgvkhuyenmai.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
                    dgvkhuyenmai.Columns["PhanTramChietKhau"].Visible = true;
                    dgvkhuyenmai.Columns["PhanTramChietKhau"].HeaderText = "Phần Trăm Chiết Khấu";
                    dgvkhuyenmai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvkhuyenmai.AllowUserToAddRows = false;
                    dgvkhuyenmai.AllowUserToDeleteRows = false;
                    dgvkhuyenmai.AllowUserToResizeRows = false;
                }
                catch
                {
                    MessageBox.Show("Xuất hiện lỗi");
                }
            }
        }

        private void frmXuLyKhachHang_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime dateServer = DateServer.Date();
                rdbtnhanghoa.Visible = false;
                SelectData1();
                SelectData();
                DateTime ngaysinh = Convert.ToDateTime(new Common.Utilities().MyDateConversion(maktxtngaysinh.Text));
                int MM = dateServer.Month;
                int DD = dateServer.Day;
                if (MM == ngaysinh.Month && (ngaysinh.Day - DD) <= 3 && (ngaysinh.Day - DD) >= 0)
                {
                    label1.Text = "Khách Hàng Này Sắp Có Sinh Nhật " + maktxtngaysinh.Text;
                }
            }
            catch
            { }
        }
        int i;
        private void dgvkhuyenmai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                i = e.RowIndex;
                if (i >= 0)
                {
                    dgvkhuyenmai.Rows[i].Selected = true;
                }
            }
            catch
            { }

        }
        private void dgvkhuyenmai_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
        private bool CheckKT()
        {
            try
            {
                if (txtmahanghoa.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa chọn " + lblmahanghoa.Text, "Hệ thống cảnh báo");
                    txtmahanghoa.Focus();
                    return false;
                }
                string date = "";
                try
                {
                    date = new Common.Utilities().MyDateConversion(mktxtngaybatdau.Text);
                    Convert.ToDateTime(date);
                }
                catch
                {
                    MessageBox.Show("lỗi định dạng ngày");
                    return false;
                }
                try
                {
                    date = new Common.Utilities().MyDateConversion(mktxtngayketthuc.Text);
                    Convert.ToDateTime(date);
                }
                catch
                {
                    MessageBox.Show("lỗi định dạng ngày");
                    return false;
                }
                if (checkDateTime(mktxtngaybatdau.Text) != "true")
                {
                    MessageBox.Show(checkDateTime(mktxtngaybatdau.Text), "Hệ Thống Cảnh Báo");
                    mktxtngaybatdau.Focus();
                    return false;
                }
                if (checkDateTime(mktxtngayketthuc.Text) != "true")
                {
                    MessageBox.Show(checkDateTime(mktxtngayketthuc.Text), "Hệ Thống Cảnh Báo");
                    mktxtngayketthuc.Focus();
                    return false;
                }
                if (mktxtngaybatdau.Text != null && mktxtngayketthuc.Text != null)
                {
                    if (xulyNgayInsert(mktxtngaybatdau.Text) >= xulyNgayInsert(mktxtngayketthuc.Text))
                    {
                        MessageBox.Show("Ngày bắt đầu phải nhỏ hơn ngày kết thúc", "hệ thống cảnh báo");
                        mktxtngaybatdau.Focus();
                        return false;
                    }
                }
            }
            catch
            { }
            return true;
        }
        public DateTime xulyNgayInsert(string datetime)
        {
            try
            {
                DateTime mk;

                string dd = datetime.Substring(0, 2);
                string mm = datetime.Substring(3, 2);
                string yyyy = datetime.Substring(6, 4);
                mk = new DateTime(Convert.ToInt32(yyyy), Convert.ToInt32(mm), Convert.ToInt32(dd));

                return mk;
            }
            finally
            { }
        }
        public static string trave = "";
        private void btnluuchinhsachgia_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckKT())
                {
                    if (txtchietkhau.Text == "")
                    { }
                    Server_Client.Client cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                    Entities.CapNhatGiaKhachHang nv = new Entities.CapNhatGiaKhachHang();
                    string date3 = new Common.Utilities().MyDateConversion(mktxtngaybatdau.Text);
                    string date4 = new Common.Utilities().MyDateConversion(mktxtngayketthuc.Text);
                    nv = new Entities.CapNhatGiaKhachHang("Insert", 0, txtmacapnhatgiakh.Text, txtmahanghoa.Text, txtmakhachhang.Text, Convert.ToDateTime(date3), Convert.ToDateTime(date4), float.Parse(txtchietkhau.Text), false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                    clientstrem = cl.SerializeObj(this.client1, "CapNhatGiaKH", nv);
                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(clientstrem, msg);
                    if (msg == 1)
                    {
                        txtmacapnhatgiakh.Text = new Common.Utilities().ProcessID(txtmacapnhatgiakh.Text);
                    }
                    else
                    {
                        MessageBox.Show("Thất Bại.....");
                        txtmakh.Text = new Common.Utilities().ProcessID(txtmakh.Text);
                        txtmacapnhatgiakh.Text = new Common.Utilities().ProcessID(txtmacapnhatgiakh.Text);
                    }
                    SelectData();
                    txtmahanghoa.Text = "";
                    mktxtngaybatdau.Text = "";
                    mktxtngayketthuc.Text = "";
                    txtchietkhau.Text = "";
                }
            }
            catch
            {
                MessageBox.Show("Kiểm tra dữ liệu nhập vào");
            }
        }
        private void BindHangHoa1()
        {
            try
            {
                if (GiaTriCanLuu.Loaitrave == "XuLyKhachHang")
                {
                    txtmakhachhang.Text = GiaTriCanLuu.Ma;

                }
            }
            catch
            { }

        }

        private void txtchietkhau_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (int.Parse(txtchietkhau.Text) >= 0)
                {
                    if (int.Parse(txtchietkhau.Text) > 100)
                    {
                        MessageBox.Show("Phần trăm chiết khấu phải >=0 hoặc <=100", "Hệ thống cảnh báo");
                        txtchietkhau.Focus();
                        txtchietkhau.Text = "0";
                        txtchietkhau.Text = String.Format("{0:0}", txtchietkhau.Text);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                txtchietkhau.Text = "";
            }
        }
        private void tabControlNDdanhmuckhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtmakhachhang.Text = txtmkh.Text = txtmakh.Text;
            if (tabControlNDdanhmuckhachhang.SelectedIndex == 3)
            {
                LayDLTheVip();
            }
        }

        private void tabControlNDdanhmuckhachhang_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                if (!e.TabPage.Enabled)
                {
                    e.Cancel = true;
                }
            }
            catch
            { }
        }

        private void txthanmucthanhtoan_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtchietkhau_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtmavung_KeyPress(object sender, KeyPressEventArgs e)
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

        private void mktxtsodienthoai_KeyPress(object sender, KeyPressEventArgs e)
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

        private void mktxtmobile_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtfax_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmXuLyKhachHang_Click(object sender, EventArgs e)
        {
            txthanmucthanhtoan.Text = new Common.Utilities().FormatMoney(float.Parse(txthanmucthanhtoan.Text));
        }

        private void txthanmucthanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                txthanmucthanhtoan.Text = String.Format("{0:0}", float.Parse(txthanmucthanhtoan.Text));
            }
            catch
            {
            }
        }

        private void txthanmucthanhtoan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(txthanmucthanhtoan.Text) >= 0)
                {
                    txthanmucthanhtoan.Text = String.Format("{0:0}", txthanmucthanhtoan.Text);
                    return;
                }
            }
            catch
            {
                txthanmucthanhtoan.Text = "";
            }
        }

        private void mktxtsodienthoai_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(mktxtsodienthoai.Text) >= 0)
                {
                    mktxtsodienthoai.Text = String.Format("{0:0}", mktxtsodienthoai.Text);
                    return;
                }
            }
            catch
            {
                mktxtsodienthoai.Text = "";
            }
        }

        private void txtfax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(txtfax.Text) >= 0)
                {
                    txtfax.Text = String.Format("{0:0}", txtfax.Text);
                    return;
                }
            }
            catch
            {
                txtfax.Text = "";
            }
        }

        private void mktxtmobile_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(mktxtmobile.Text) >= 0)
                {
                    mktxtmobile.Text = String.Format("{0:0}", mktxtmobile.Text);
                    return;
                }
            }
            catch
            {
                mktxtmobile.Text = "";
            }
        }

        private void txtmavung_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(txtmavung.Text) >= 0)
                {
                    txtmavung.Text = String.Format("{0:0}", txtmavung.Text);
                    return;
                }
            }
            catch
            {
                txtmavung.Text = "";
            }
        }

        private void XoaTheVip_Click(object sender, EventArgs e)
        {

            try
            {
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn muốn xóa mã thẻ " + dtgvTheVip.SelectedRows[0].Cells["MaThe"].Value.ToString() + " ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        Entities.TheVip thevip = new Entities.TheVip("Delete");
                        thevip.TenDangNhap = Common.Utilities.User.TenDangNhap;
                        thevip.MaNhanVien = Common.Utilities.User.NhanVienID;
                        thevip.MaThe = dtgvTheVip.SelectedRows[0].Cells["MaThe"].Value.ToString();
                        XoaTheVip(thevip);
                    }
                }
            }
            catch
            { }

        }
        void fixdtgvTheVip()
        {
            dtgvTheVip.Columns["HanhDong"].Visible = false;
            dtgvTheVip.Columns["MaKhachHang"].Visible = false;
            dtgvTheVip.Columns["MaThe"].HeaderText = "Mã Thẻ";
            dtgvTheVip.Columns["GiaTriThe"].HeaderText = "Giá Trị Thẻ";
            dtgvTheVip.Columns["GiaTriConLai"].HeaderText = "Giá Trị Còn Lại";
            dtgvTheVip.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dtgvTheVip.Columns["Deleted"].Visible = false;
        }
        Entities.TheVip[] TheVip;
        ArrayList TheVipht = new ArrayList();
        void LayDLTheVip()
        {
            cl = new Server_Client.Client();
            // gán TCPclient
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            // khởi tạo biến truyền vào với hàm khởi tạo
            //Entities.TheVip kh = new Entities.TheVip("Select", txtmkh.Text);
            clientstrem = cl.SerializeObj(this.client1, "LayTheVip", null);
            // đổ mảng đối tượng vào datagripview       
            TheVip = (Entities.TheVip[])cl.DeserializeHepper1(clientstrem, null);
            LocDL();
        }
        void XoaTheVip(Entities.TheVip thevip)
        {
            cl = new Server_Client.Client();
            // gán TCPclient
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            // khởi tạo biến truyền vào với hàm khởi tạo
            //Entities.TheVip kh = new Entities.TheVip("Select", txtmkh.Text);

            clientstrem = cl.SerializeObj(this.client1, "XoaTheVip", thevip);
            // đổ mảng đối tượng vào datagripview       
            bool tv = (bool)cl.DeserializeHepper(clientstrem, null);
            if (tv)
            {
                foreach (Entities.TheVip item in TheVip)
                {
                    if (item.MaThe.Equals(thevip.MaThe))
                    {
                        item.Deleted = true;
                        break;
                    }
                }
            }
            LocDL();
        }
        void ThemTheVip(Entities.TheVip thevip)
        {
            cl = new Server_Client.Client();
            // gán TCPclient
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            // khởi tạo biến truyền vào với hàm khởi tạo
            //Entities.TheVip kh = new Entities.TheVip("Select", txtmkh.Text);

            clientstrem = cl.SerializeObj(this.client1, "ThemTheVip", thevip);
            // đổ mảng đối tượng vào datagripview       
            bool tv = (bool)cl.DeserializeHepper(clientstrem, null);
            if (tv)
            {
                foreach (Entities.TheVip item in TheVip)
                {
                    if (item.MaThe.Equals(thevip.MaThe))
                    {
                        item.Deleted = true;
                        break;
                    }
                }
            }
            LayDLTheVip();
        }
        void LocDL()
        {
            TheVipht.Clear();
            foreach (Entities.TheVip item in TheVip)
            {
                if (!item.Deleted && item.MaKhachHang.Equals(txtmkh.Text))
                    TheVipht.Add(item);
            }
            if (TheVipht.Count > 0)
                dtgvTheVip.DataSource = (Entities.TheVip[])TheVipht.ToArray(typeof(Entities.TheVip));
            else
                dtgvTheVip.DataSource = new Entities.TheVip[0];
            fixdtgvTheVip();
        }

        private void txtGiaTriThe_KeyPress(object sender, KeyPressEventArgs e)
        {
            //TextBox temp = (TextBox)sender;
            //int i = e.KeyChar;
            //if (temp.Text.Length > 14 && i != 8 && !(temp.SelectionLength == temp.TextLength))
            //    e.Handled = true;
            //else if ((i < 48 || i > 57) && i != 8)
            //    e.Handled = true;
        }

        private void btnThemTheVip_Click(object sender, EventArgs e)
        {
            try
            {
                //Check Validate
                if (txtMaThe.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Mã thẻ không được để trống");
                    txtMaThe.Focus();
                    return;
                }
                else if (txtGiaTriThe.Text.Replace(",","").Trim().Length == 0)
                {
                    MessageBox.Show("Giá trị thẻ không được để trống");
                    txtGiaTriThe.Focus();
                    return;
                }
                if (txtmkh.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Mã khách hàng không được để trống");
                    txtGiaTriThe.Focus();
                    return;
                }
                else if (txtMaThe.Text.Length > 20)
                {
                    MessageBox.Show("Mã thẻ không được quá dài");
                    txtMaThe.Focus();
                    return;
                }
                else if (txtGiaTriThe.Text.Replace(",","").Length > 15)
                {
                    MessageBox.Show("Giá trị thẻ quá lớn");
                    txtMaThe.Focus();
                    return;
                }
                else if (txtGC.Text.Length > 100)
                {
                    MessageBox.Show("Ghi chú không được quá dài");
                    txtMaThe.Focus();
                    return;
                }
                else if (txtDiemThuong.Text.Length == 0)
                {
                    MessageBox.Show("Điểm thưởng không được để trống");
                    txtDiemThuong.Focus();
                    return;
                }
                //Check số điểm khách hàng
                Entities.DiemThuongKhachHang input = null;
                DiemThuongKhachHang();
                foreach (Entities.DiemThuongKhachHang item in dtkh)
                {
                    if (item.MaKhachHang.ToUpper().Equals(txtmkh.Text.ToUpper()))
                    {//khách hàng đã có điểm
                        int sodiem = int.Parse(txtDiemThuong.Text);
                        if (sodiem > item.DiemConLai)
                        {
                            MessageBox.Show("Không đủ điểm để tạo thẻ");
                            return;
                        }
                        else
                        {
                            //thực hiện việc trừ số lượng điểm
                            input = TienIch.DiemThuongKhachHang_TO_DiemThuongKhachHang(item);
                            input.ThaoTac = "CapNhat";
                            input.DiemDaDung = input.DiemDaDung + sodiem;
                            input.DiemConLai = input.TongDiem - input.DiemDaDung;
                        }
                    }
                }
                if (input == null)
                {
                    MessageBox.Show("Không đủ điểm để tạo thẻ");
                    return;
                }
                
                Entities.TheVip tv = new Entities.TheVip(txtmkh.Text, txtMaThe.Text, txtGiaTriThe.Text.Replace(",",""), txtGiaTriThe.Text.Replace(",",""), txtGC.Text, txtDiemThuong.Text, false);
                tv.TenDangNhap = Common.Utilities.User.TenDangNhap;
                tv.MaNhanVien = Common.Utilities.User.NhanVienID;
                LayDLTheVip();
                foreach (Entities.TheVip item in TheVip)
                {
                    if (item.MaThe.ToUpper().Equals(tv.MaThe.ToUpper()))
                    {
                        MessageBox.Show("Mã thẻ đã tồn tại, xin hãy ghi lại mã khác");
                        return;
                    }
                }
                ThemTheVip(tv);
                //Cập nhật điểm thưởng khách hàng
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "DiemThuongKhachHang", input);
                int msg = 0;
                msg = (int)cl.DeserializeHepper(clientstrem, msg);
                if (msg != 0)
                    MessageBox.Show("Cập nhật điểm thưởng khách hàng thành công");
                /////////////////////////////////
                txtMaThe.Text = "";
                txtGiaTriThe.Text = "";
                txtGC.Text = "";
            }
            catch { }
        }

        private void dgvkhuyenmai_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0)
                return;
            try
            {
                int id;
                DataGridViewRow row = dgvkhuyenmai.Rows[i];
                Entities.CapNhatGiaKhachHang nv = new Entities.CapNhatGiaKhachHang();
                id = int.Parse(row.Cells["CapNhatGiaKhachHangID"].Value.ToString());
                nv.MaHangHoa = row.Cells["MaHangHoa"].Value.ToString();
                nv.MaKhachHang = row.Cells["MaKhachHang"].Value.ToString();
                nv.NgayBatDau = DateTime.Parse(row.Cells["NgayBatDau"].Value.ToString());
                nv.NgayKetThuc = DateTime.Parse(row.Cells["NgayKetThuc"].Value.ToString());
                nv.MaCapNhatGiaKhachHang = row.Cells["MaCapNhatGiaKhachHang"].Value.ToString();
                nv.PhanTramChietKhau = float.Parse(row.Cells["PhanTramChietKhau"].Value.ToString());
                txtmahanghoa.Text = nv.MaHangHoa;
                txtmakhachhang.Text = nv.MaKhachHang;
                mktxtngaybatdau.Text = nv.NgayBatDau.ToShortDateString();
                mktxtngayketthuc.Text = nv.NgayKetThuc.ToShortDateString();
                txtmacapnhatgiakh.Text = nv.MaCapNhatGiaKhachHang;
                txtchietkhau.Text = nv.PhanTramChietKhau.ToString();
                DeleteKM(id);
                SelectData();

            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Delete KM.
        /// </summary>
        /// <param name="km"></param>
        /// <returns></returns>
        public bool DeleteKM(int id)
        {
            bool retVal = false;
            try
            {
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                Entities.CapNhatGiaKhachHang nv = new Entities.CapNhatGiaKhachHang();
                nv.HanhDong = "Delete";
                nv.CapNhatGiaKhachHangID = id;
                clientstrem = cl.SerializeObj(this.client1, "CapNhatGiaKH", nv);
                int msg = 0;
                msg = (int)cl.DeserializeHepper(clientstrem, msg);
                if (msg > 0)
                    retVal = true;
            }
            catch (Exception)
            {
                retVal = false;
            }

            return retVal;
        }

        private void DiemThuongKhachHang()
        {
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            clientstrem = cl.SerializeObj(this.client1, "SelectDiemThuongKhachHang", new Entities.DiemThuongKhachHang("select"));
            dtkh = (Entities.DiemThuongKhachHang[])cl.DeserializeHepper1(clientstrem, dtkh);
            if (dtkh == null)
                dtkh = new Entities.DiemThuongKhachHang[0];
        }

        private void txtGiaTriThe_TextChanged(object sender, EventArgs e)
        {
            new TienIch().AutoFormatMoney(sender);
        }
    }
}