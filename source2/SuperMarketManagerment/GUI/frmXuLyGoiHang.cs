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
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;

namespace GUI
{
    public partial class frmXuLyGoiHang : Form
    {
        #region khai báo
        string maKho = new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen;
        Server_Client.Client client;
        public TcpClient client1;
        public NetworkStream clientstrem;
        public static string trave = "";
        int soluong = 1;
        string mahanghoa;
        Entities.ChiTietGoiHang[] tempcheck = null;
        public frmXuLyGoiHang()
        {
            InitializeComponent();

        }

        public frmXuLyGoiHang(string str1, string str2)
        {
            InitializeComponent();
            XuLyString(str1, str2);
        }
        public void fix()
        {
            try
            {
                dgvInsertOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvInsertOrder.ReadOnly = true;
                dgvInsertOrder.RowHeadersVisible = false;
                dgvInsertOrder.Columns["MaGoiHang"].Visible = false;
                dgvInsertOrder.Columns["ChiTietGoiHangID"].Visible = false;
                dgvInsertOrder.Columns["HanhDong"].Visible = false;
                dgvInsertOrder.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
                dgvInsertOrder.Columns["TenHangHoa"].HeaderText = "Tên Hàng";
                dgvInsertOrder.Columns["GiaNhap"].HeaderText = "Giá Nhập";
                dgvInsertOrder.Columns["GiaBanBuon"].HeaderText = "Giá Bán Buôn";
                dgvInsertOrder.Columns["GiaBanLe"].HeaderText = "Giá Bán Lẻ";
                dgvInsertOrder.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgvInsertOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvInsertOrder.AllowUserToAddRows = false;
                dgvInsertOrder.AllowUserToDeleteRows = false;
                dgvInsertOrder.AllowUserToResizeRows = false;
            }
            catch (Exception)
            {


            }

        }
        #endregion

        #region select
        double giaNhap;
        double giaBanBuon;
        double giaBanLe;
        int tongSoLuong;
        Entities.ChiTietGoiHang[] ctddh;
        int sotang = 0;
        ArrayList array = new ArrayList();
        public void SelectData1()
        {
            try
            {

                dgvInsertOrder.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ChiTietGoiHang[] pt = new Entities.ChiTietGoiHang[1];
                pt[0] = new Entities.ChiTietGoiHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                ctddh = new Entities.ChiTietGoiHang[1];
                clientstrem = cl.SerializeObj(this.client1, "ChiTietGoiHang", pt);
                // đổ mảng đối tượng vào datagripview       
                ctddh = (Entities.ChiTietGoiHang[])cl.DeserializeHepper1(clientstrem, ctddh);
                if (ctddh == null)
                {
                    dgvInsertOrder.DataSource = new Entities.ChiTietGoiHang[0];
                    return;
                }
                foreach (Entities.ChiTietGoiHang item in ctddh)
                {
                    if (item.MaGoiHang.ToUpper().Equals(magoihang.ToUpper()))
                    {
                        array.Add(item);
                    }
                }

                if (array != null && array.Count > 0)
                {

                    tempcheck = new Entities.ChiTietGoiHang[array.Count + 1];
                    sotang = 0;
                    foreach (Entities.ChiTietGoiHang item in (Entities.ChiTietGoiHang[])array.ToArray(typeof(Entities.ChiTietGoiHang)))
                    {

                        soluong = item.SoLuong;
                        giaNhap += double.Parse(item.GiaNhap);
                        giaBanBuon += double.Parse(item.GiaBanBuon);
                        giaBanLe += double.Parse(item.GiaBanLe);
                        tongSoLuong += item.SoLuong;
                        tempcheck[sotang] = item;
                        sotang++;
                    }

                    tempcheck[tempcheck.Length - 1] = new Entities.ChiTietGoiHang();
                    tempcheck[tempcheck.Length - 1].TenHangHoa = "Tổng Cộng";
                    tempcheck[tempcheck.Length - 1].GiaNhap = (new Common.Utilities().FormatMoney(giaNhap));
                    tempcheck[tempcheck.Length - 1].GiaBanBuon = (new Common.Utilities().FormatMoney(giaBanBuon));
                    tempcheck[tempcheck.Length - 1].GiaBanLe = (new Common.Utilities().FormatMoney(giaBanLe));
                    tempcheck[tempcheck.Length - 1].SoLuong = tongSoLuong;
                    dgvInsertOrder.DataSource = tempcheck;

                }
            }
            catch { }
            finally
            {
                try
                {
                    fix();

                }
                catch
                { }

            }
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
        #region Sửa LV
        void SuaRow()
        {
            if (i < 0)
                return;
            if (dgvInsertOrder.RowCount > 1)
            {
                txtmagoihang.Text = dgvInsertOrder["MaGoiHang", i].Value.ToString().ToUpper();
                toolStrip_txtTracuu.Text = dgvInsertOrder["MaHangHoa", i].Value.ToString().ToUpper();
                toolStrip_txtTenhang.Text = dgvInsertOrder["TenHangHoa", i].Value.ToString();
                toolStrip_txtTonkho.Text = new Common.Utilities().FormatMoney(double.Parse(dgvInsertOrder["GiaNhap", i].Value.ToString()) / double.Parse(dgvInsertOrder["SoLuong", i].Value.ToString()));
                toolStrip_txtTonThucTe.Text = new Common.Utilities().FormatMoney(double.Parse(dgvInsertOrder["GiaBanBuon", i].Value.ToString()) / double.Parse(dgvInsertOrder["SoLuong", i].Value.ToString()));
                toolStripTextBox1.Text = new Common.Utilities().FormatMoney(double.Parse(dgvInsertOrder["GiaBanLe", i].Value.ToString()) / double.Parse(dgvInsertOrder["SoLuong", i].Value.ToString()));
                toolStripTextBox2.Text = dgvInsertOrder["SoLuong", i].Value.ToString();
                tempcheck = new Entities.ChiTietGoiHang[dgvInsertOrder.RowCount - 1];
                int sotang = 0;
                for (int j = 0; j < dgvInsertOrder.RowCount - 1; j++)
                {
                    if (dgvInsertOrder["MaHangHoa", j].Value.ToString() != dgvInsertOrder["MaHangHoa", i].Value.ToString())
                    {
                        tempcheck[sotang] = new Entities.ChiTietGoiHang("Delete", 0,
                 dgvInsertOrder["MaGoiHang", j].Value.ToString(), dgvInsertOrder["MaHangHoa", j].Value.ToString(),
                 dgvInsertOrder["TenHangHoa", j].Value.ToString(),
                 dgvInsertOrder["GiaNhap", j].Value.ToString(), dgvInsertOrder["GiaBanBuon", j].Value.ToString(),
                 dgvInsertOrder["GiaBanLe", j].Value.ToString(), int.Parse(dgvInsertOrder["SoLuong", j].Value.ToString()));
                        sotang++;
                    }
                }
                dgvInsertOrder.DataSource = tempcheck;
            }
            else
            {
                txtmagoihang.Text = dgvInsertOrder["MaGoiHang", i].Value.ToString().ToUpper();
                toolStrip_txtTracuu.Text = dgvInsertOrder["MaHangHoa", i].Value.ToString().ToUpper();
                toolStrip_txtTenhang.Text = dgvInsertOrder["TenHangHoa", i].Value.ToString();
                toolStrip_txtTonkho.Text = new Common.Utilities().FormatMoney(double.Parse(dgvInsertOrder["GiaNhap", i].Value.ToString()));
                toolStrip_txtTonThucTe.Text = new Common.Utilities().FormatMoney(double.Parse(dgvInsertOrder["GiaBanBuon", i].Value.ToString()));
                toolStripTextBox1.Text = new Common.Utilities().FormatMoney(double.Parse(dgvInsertOrder["GiaBanLe", i].Value.ToString()));
                toolStripTextBox2.Text = dgvInsertOrder["SoLuong", i].Value.ToString();
                dgvInsertOrder.DataSource = new Entities.ChiTietGoiHang[0];
                toolStrip_txtTracuu.Text = toolStrip_txtTenhang.Text = toolStrip_txtTonkho.Text = toolStrip_txtTonThucTe.Text = toolStripTextBox1.Text = toolStripTextBox2.Text = "0";
            }

        }
        #endregion

        #region Thêm Mới LV
        public void NewRow()
        {
            try
            {
                if (tempcheck == null)
                {
                    bool kt1 = false;
                    string sl = " 0 ";
                    if (toolStripTextBox2.Text == "")
                        sl = "0";
                    else
                        sl = toolStripTextBox2.Text;
                    string soluongsp = (soluong + int.Parse(sl)).ToString();

                    //giá nhập
                    string gianhap = "0";
                    gianhap = toolStrip_txtTonkho.Text;
                    double gianhapsp = double.Parse(gianhap) * soluong;
                    //giá bán buôn
                    string giabanbuon = "0";
                    giabanbuon = toolStrip_txtTonThucTe.Text;
                    double giabanbuonsp = double.Parse(giabanbuon) * soluong;
                    //giá bán lẻ
                    string giabanle = "0";
                    giabanle = toolStripTextBox1.Text;
                    double giabanlesp = double.Parse(giabanle) * soluong;

                    tempcheck = new Entities.ChiTietGoiHang[1];
                    tempcheck[0] = new Entities.ChiTietGoiHang("Insert", 0, txtmagoihang.Text.ToUpper(),
                        toolStrip_txtTracuu.Text, toolStrip_txtTenhang.Text, gianhapsp.ToString(),
                        giabanbuonsp.ToString(), giabanlesp.ToString(), int.Parse(sl));
                    dgvInsertOrder.DataSource = tempcheck;
                    return;

                }
                int sohangtrongbang = tempcheck.Length;
                //sohangtrongbang = tempcheck.Length;
                // số lượng bảng ghi khác 0
                //if (sohangtrongbang != 0)
                //{
                //    for (int j = 0; j < dgvInsertOrder.RowCount; j++)
                //    {
                //        // nếu tìm được mã đã có trong list view
                //        if (mahanghoa == dgvInsertOrder["MaHangHoa", j].Value.ToString())
                //        {
                //            tempcheck = new Entities.ChiTietGoiHang[sohangtrongbang];
                //            break;
                //        }
                //        // nếu không tìm được
                //        else
                //            tempcheck = new Entities.ChiTietGoiHang[sohangtrongbang + 1];
                //    }
                //}
                // số lượng bảng ghi = 0
                //else
                //tempcheck = new Entities.ChiTietGoiHang[sohangtrongbang + 1];
                // nếu số lượng bảng ghi khác 0
                if (sohangtrongbang != 0)
                {
                    ArrayList li = new ArrayList();
                    try
                    {
                        // số lượng bảng ghi = số lượng row list view
                        //if (tempcheck.Length == dgvInsertOrder.RowCount)
                        //{
                        Boolean ch = false;
                        for (int j = 0; j < tempcheck.Length; j++)
                        {
                            // nếu mã = mã trong list view
                            if (mahanghoa == tempcheck[j].MaHangHoa)// dgvInsertOrder["MaHangHoa", j].Value.ToString())
                            {
                                ch = true;
                                int soluongcu = Convert.ToInt32(tempcheck[j].SoLuong);//dgvInsertOrder["SoLuong", j].Value.ToString());
                                string sl = "0";
                                if (toolStripTextBox2.Text == "")
                                    sl = "1";
                                else
                                    sl = toolStripTextBox2.Text;
                                int soluongmoi = Convert.ToInt32(sl);
                                int soluonghientai = soluongcu + soluongmoi;
                                //giá nhập
                                string gianhap = "0";
                                gianhap = toolStrip_txtTonkho.Text;
                                double gianhapmoi = double.Parse(gianhap);
                                double gianhaphientai = gianhapmoi * soluonghientai;
                                // giá bán buôn
                                string giabanbuon = "0";
                                giabanbuon = toolStrip_txtTonThucTe.Text;
                                double giabanbuonmoi = double.Parse(giabanbuon);
                                double giabanbuonhientai = giabanbuonmoi * soluonghientai;
                                // giá bán lẻ
                                string giabanle = "0";
                                giabanle = toolStripTextBox1.Text;
                                double giabanlemoi = double.Parse(giabanle);
                                double giabanlehientai = giabanlemoi * soluonghientai;
                                //

                                Entities.ChiTietGoiHang g = new Entities.ChiTietGoiHang("Insert", 0, txtmagoihang.Text,
                                     toolStrip_txtTracuu.Text, toolStrip_txtTenhang.Text, gianhaphientai.ToString(),
                                     giabanbuonhientai.ToString(), giabanlehientai.ToString(), soluonghientai);
                                li.Add(g);
                                //tempcheck[j] = new Entities.ChiTietGoiHang("Insert", 0, txtmagoihang.Text,
                                //    toolStrip_txtTracuu.Text, toolStrip_txtTenhang.Text, gianhaphientai.ToString(),
                                //    giabanbuonhientai.ToString(), giabanlehientai.ToString(), soluonghientai);
                            }
                            // nếu mã không = mã trong list view
                            else
                            {
                                if (!string.IsNullOrEmpty(tempcheck[j].MaHangHoa))
                                    li.Add(tempcheck[j]);

                            }
                        }
                        if (ch == false)
                        {
                            bool kt1 = false;
                            string sl = " 0 ";
                            if (toolStripTextBox2.Text == "")
                                sl = "0";
                            else
                                sl = toolStripTextBox2.Text;
                            string soluongsp = (soluong + int.Parse(sl)).ToString();

                            //giá nhập
                            string gianhap = "0";
                            gianhap = toolStrip_txtTonkho.Text;
                            double gianhapsp = double.Parse(gianhap) * soluong;
                            //giá bán buôn
                            string giabanbuon = "0";
                            giabanbuon = toolStrip_txtTonThucTe.Text;
                            double giabanbuonsp = double.Parse(giabanbuon) * soluong;
                            //giá bán lẻ
                            string giabanle = "0";
                            giabanle = toolStripTextBox1.Text;
                            double giabanlesp = double.Parse(giabanle) * soluong;
                            Entities.ChiTietGoiHang r = new Entities.ChiTietGoiHang("Insert", 0, txtmagoihang.Text,
                                toolStrip_txtTracuu.Text, toolStrip_txtTenhang.Text, gianhapsp.ToString(),
                                giabanbuonsp.ToString(), giabanlesp.ToString(), int.Parse(sl));
                            li.Add(r);
                        }

                    }
                    catch (Exception ex)
                    {
                        string sl = "0";
                        if (toolStripTextBox2.Text == "")
                            sl = "0";
                        else
                            sl = toolStripTextBox2.Text;
                        string soluongsp = (soluong + int.Parse(sl).ToString());
                        //giá nhập
                        string gianhap = "0";
                        gianhap = toolStrip_txtTonkho.Text;
                        double gianhapsp = double.Parse(gianhap) * soluong;
                        // giá bán buôn
                        string giabanbuon = "0";
                        giabanbuon = toolStrip_txtTonThucTe.Text;
                        double giabanbuonsp = double.Parse(giabanbuon) * soluong;
                        // giá bán lẻ
                        string giabanle = "0";
                        giabanle = toolStripTextBox1.Text;
                        double giabanlesp = double.Parse(giabanle) * soluong;
                        Entities.ChiTietGoiHang r = new Entities.ChiTietGoiHang("Insert", 0, txtmagoihang.Text, toolStrip_txtTracuu.Text, toolStrip_txtTenhang.Text, gianhapsp.ToString(), giabanbuonsp.ToString(), giabanlesp.ToString(), int.Parse(sl));
                        //tempcheck[tempcheck.Length - 1] = new Entities.ChiTietGoiHang("Insert", 0, txtmagoihang.Text, toolStrip_txtTracuu.Text, toolStrip_txtTenhang.Text, gianhapsp.ToString(), giabanbuonsp.ToString(), giabanlesp.ToString(), int.Parse(sl));
                        li.Add(r);
                    }
                    int f = li.Count;
                    if (f <= 0)
                    {
                        tempcheck = new Entities.ChiTietGoiHang[0];
                    }
                    else
                    {
                        tempcheck = new Entities.ChiTietGoiHang[f];
                        for (int i = 0; i < f; i++)
                        {
                            tempcheck[i] = (Entities.ChiTietGoiHang)li[i];
                        }
                    }
                    dgvInsertOrder.DataSource = tempcheck;
                }
            }
            catch
            {
                string sl = "0";
                if (toolStripTextBox2.Text == "")
                    sl = "0";
                else
                    sl = toolStripTextBox2.Text;
                string soluongsp = (soluong + int.Parse(sl).ToString());
                //giá nhập
                string gianhap = "0";
                gianhap = toolStrip_txtTonkho.Text;
                double gianhapsp = double.Parse(gianhap) * soluong;
                // giá bán buôn
                string giabanbuon = "0";
                giabanbuon = toolStrip_txtTonThucTe.Text;
                double giabanbuonsp = double.Parse(giabanbuon) * soluong;
                //giá bán lẻ
                string giabanle = "0";
                giabanle = toolStripTextBox1.Text;
                double giabanlesp = double.Parse(giabanle) * soluong;

                tempcheck = new Entities.ChiTietGoiHang[1];
                tempcheck[0] = new Entities.ChiTietGoiHang("Insert", 0, txtmagoihang.Text, toolStrip_txtTracuu.Text, toolStrip_txtTenhang.Text, gianhapsp.ToString(), giabanbuonsp.ToString(), giabanlesp.ToString(), int.Parse(sl));
                dgvInsertOrder.DataSource = tempcheck;
            }
            finally
            {
                try
                {
                    Entities.ChiTietGoiHang[] goi;
                    ArrayList l = new ArrayList();
                    sotang = 0;
                    foreach (Entities.ChiTietGoiHang item in tempcheck)
                    {

                        soluong = item.SoLuong;
                        gn += double.Parse(item.GiaNhap);
                        gbb += double.Parse(item.GiaBanBuon);
                        gbl += double.Parse(item.GiaBanLe);
                        tsl += item.SoLuong;
                        l.Add(item);
                        tempcheck[sotang] = item;
                        sotang++;
                    }
                    //for (int i = 0; i < tempcheck.Length; i++)
                    //{
                    //    l.Add(tempcheck[i]);
                    //    soluong = tempcheck[i].SoLuong;
                    //    giaNhap += double.Parse(tempcheck[i].GiaNhap) * soluong;
                    //    giaBanBuon += double.Parse(tempcheck[i].GiaBanBuon) * soluong;
                    //    giaBanLe += double.Parse(tempcheck[i].GiaBanLe) * soluong;
                    //}
                    int k = l.Count;
                    if (k <= 0)
                    {
                        goi = null;
                    }
                    else
                    {
                        Entities.ChiTietGoiHang r = new Entities.ChiTietGoiHang();
                        r.TenHangHoa = "Tổng Cộng";
                        r.GiaNhap = (new Common.Utilities().FormatMoney(gn));
                        r.GiaBanBuon = (new Common.Utilities().FormatMoney(gbb));
                        r.GiaBanLe = (new Common.Utilities().FormatMoney(gbl));
                        r.SoLuong = tsl;
                        l.Add(r);
                        int x = l.Count;
                        goi = new Entities.ChiTietGoiHang[x];
                        for (int i = 0; i < x; i++)
                        {
                            goi[i] = (Entities.ChiTietGoiHang)l[i];
                        }
                    }
                    dgvInsertOrder.DataSource = goi;
                    txtgianhap.Text = gn.ToString();
                    txtgiabanbuon.Text = gbb.ToString();
                    txtgiabanle.Text = gbl.ToString();
                    gn = 0;
                    gbb = 0;
                    gbl = 0;
                    tsl = 0;

                    fix();
                }
                catch { }
            }
        }
        double gn, gbb, gbl;
        int tsl;
        #endregion

        #region tính toán
        void tinhgianhap()
        {
            dgvInsertOrder.DataSource = tempcheck;
            double tonggianhap = 0;
            foreach (Entities.ChiTietGoiHang item in tempcheck)
            {
                tonggianhap += double.Parse(item.GiaNhap);

            }
            gianhap = tonggianhap.ToString();
        }
        void tinhgiabanbuon()
        {
            dgvInsertOrder.DataSource = tempcheck;
            //  tempcheck = (Entities.ChiTietGoiHang[])ucHienThiXuLyGoiHang1.lvXuLyGoiHang.ItemsSource;
            double tonggiabanbuon = 0;
            foreach (Entities.ChiTietGoiHang item in tempcheck)
            {
                tonggiabanbuon += double.Parse(item.GiaBanBuon);
            }
            giabanbuon = tonggiabanbuon.ToString();
        }
        void tinhgiabanle()
        {
            dgvInsertOrder.DataSource = tempcheck;
            //tempcheck = (Entities.ChiTietGoiHang[])ucHienThiXuLyGoiHang1.lvXuLyGoiHang.ItemsSource;
            double tonggiabanbuon = 0;
            foreach (Entities.ChiTietGoiHang item in tempcheck)
            {
                tonggiabanbuon += double.Parse(item.GiaBanLe);

            }
            giabanle = tonggiabanbuon.ToString();
        }
        #endregion

        #region lấy hàng hóa
        void LayHH()
        {
            try
            {
                string kho = new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen;
                frmTimHangHoa thh = new frmTimHangHoa(kho, "HangHoa", "");
                thh.ShowDialog();
                if (frmTimHangHoa.drvr != null)
                {

                    mahanghoa = toolStrip_txtTracuu.Text = frmTimHangHoa.drvr.Cells["MaHangHoa"].Value.ToString().ToUpper();
                    toolStrip_txtTenhang.Text = frmTimHangHoa.drvr.Cells["TenHangHoa"].Value.ToString();
                    toolStrip_txtTonkho.Text = frmTimHangHoa.drvr.Cells["GiaNhap"].Value.ToString();
                    toolStrip_txtTonThucTe.Text = frmTimHangHoa.drvr.Cells["GiaBanBuon"].Value.ToString();
                    toolStripTextBox1.Text = frmTimHangHoa.drvr.Cells["GiaBanLe"].Value.ToString();
                    toolStripTextBox2.Focus();
                }
            }
            catch
            {
            }
            finally
            {
                try
                {
                    fix();
                }
                catch
                {
                }
            }
        }
        #endregion

        #region check số

        private void txtgianhap_TextChanged(object sender, EventArgs e)
        {
            try
            {
                new TienIch().AutoFormatMoney(sender);
            }
            catch
            {
                txtgianhap.Text = "";
            }
        }

        private void txtgiabanbuon_TextChanged(object sender, EventArgs e)
        {
            try
            {
                new TienIch().AutoFormatMoney(sender);
            }
            catch
            {
                txtgiabanbuon.Text = "";
            }
        }

        private void txtgiabanle_TextChanged(object sender, EventArgs e)
        {
            try
            {
                new TienIch().AutoFormatMoney(sender);
            }
            catch
            {
                txtgiabanle.Text = "";
            }
        }
        private void txtGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtGiaBanBuon_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtGiaBanLe_KeyPress(object sender, KeyPressEventArgs e)
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

        #endregion

        #region combobox

        //Lấy Mã Nhóm Hàng Hóa
        public void LayLoaiHangHoa()
        {
            cbbLoaiHangHoa.Items.Clear();
            client = new Server_Client.Client();
            this.client1 = client.Connect(Luu.IP, Luu.Ports);

            Entities.LoaiHangHoa nh = new Entities.LoaiHangHoa();
            nh = new Entities.LoaiHangHoa("Select");
            clientstrem = client.SerializeObj(this.client1, "LoaiHangHoa", nh);
            Entities.LoaiHangHoa[] nh1 = new Entities.LoaiHangHoa[1];
            nh1 = (Entities.LoaiHangHoa[])client.DeserializeHepper1(clientstrem, nh1);

            cbbLoaiHangHoa.DataSource = nh1;
            cbbLoaiHangHoa.DisplayMember = "TenLoaiHang";
        }
        public int cbbLoaiHangHoa_sua(string maNH)
        {
            client = new Server_Client.Client();
            this.client1 = client.Connect(Luu.IP, Luu.Ports);

            Entities.NhomHang nh1 = new Entities.NhomHang();
            nh1 = new Entities.NhomHang("Select");
            clientstrem = client.SerializeObj(this.client1, "NhomHang", nh1);
            Entities.NhomHang[] nh = new Entities.NhomHang[1];
            nh = (Entities.NhomHang[])client.DeserializeHepper1(clientstrem, nh);
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

            client = new Server_Client.Client();
            this.client1 = client.Connect(Luu.IP, Luu.Ports);

            Entities.NhomHang nh = new Entities.NhomHang();
            nh = new Entities.NhomHang("Select");
            clientstrem = client.SerializeObj(this.client1, "NhomHang", nh);
            Entities.NhomHang[] nh1 = new Entities.NhomHang[1];
            nh1 = (Entities.NhomHang[])client.DeserializeHepper1(clientstrem, nh1);

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

        private void cbbLoaiHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entities.LoaiHangHoa[] lh = (Entities.LoaiHangHoa[])cbbLoaiHangHoa.DataSource;
            LayMaNhomHangHoa(lh[cbbLoaiHangHoa.SelectedIndex].MaLoaiHang);
        }
        #endregion

        int i;
        //Xử Lý Combobox
        public void XuLyCombobox()
        {
            try
            {
                LayLoaiHangHoa();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
        Entities.GoiHang lhh = new Entities.GoiHang();
        #region proid
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
                lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, lhh);
                if (lid == null)
                {
                    return "GH_0001";
                }
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            finally
            { }

        }
        #endregion

        #region xử lý chuỗi
        public void XuLyString(string str1, string str2)
        {
            try
            {
                if (str1 == "Thu" && str2 == "Them")
                {
                    this.Text = " Quản lý Gói Hàng - Thêm mới Gói Hàng";
                    toolStripStatus_Ghilai.Enabled = false;
                    txtmagoihang.Text = string.Empty;
                    //txtmagoihang.Text = ProID("GoiHang");
                    XuLyCombobox();


                }
                if (str1 == "Thu" && str2 == "Sua")
                {
                    this.Text = " Quản lý Gói Hàng - Sửa Gói  Hàng";
                    toolStripStatus_Themmoi.Enabled = false;
                    txtmagoihang.Enabled = false;
                    XuLyCombobox();

                }
            }
            catch { }

        }
        #endregion

        #region khai báo form
        string id;
        string magoihang, tengoihang, gianhap, giabanbuon, giabanle, maLoaiHang, maNhomHang;
        Entities.GoiHang gh, ghOld;
        public frmXuLyGoiHang(string str1, string str2, DataGridViewRow dgvr)
        {
            try
            {
                InitializeComponent();
                XuLyString(str1, str2);
                if (str1 == "Thu" && str2 == "Sua")
                {
                    id = dgvr.Cells["GoiHangID"].Value.ToString();
                    magoihang = dgvr.Cells["MaGoiHang"].Value.ToString();
                    tengoihang = dgvr.Cells["TenGoiHang"].Value.ToString();
                    cbbLoaiHangHoa.SelectedIndex = cbbLoaiHangHoa_sua(dgvr.Cells["MaNhomHang"].Value.ToString());
                    Entities.LoaiHangHoa lh = (Entities.LoaiHangHoa)cbbLoaiHangHoa.SelectedItem;
                    maLoaiHang = lh.MaLoaiHang;

                    cmbMaNhomHangHoa.SelectedIndex = cmbmaMaNhomHangHoa_sua(dgvr.Cells["MaNhomHang"].Value.ToString());
                    Entities.NhomHang nh = (Entities.NhomHang)cmbMaNhomHangHoa.SelectedItem;
                    maNhomHang = nh.MaNhomHang;
                    gianhap = dgvr.Cells["GiaNhap"].Value.ToString();
                    giabanbuon = dgvr.Cells["GiaBanBuon"].Value.ToString();
                    giabanle = dgvr.Cells["GiaBanLe"].Value.ToString();
                    this.txtmagoihang.Text = magoihang;
                    this.txttengoihang.Text = tengoihang;
                    this.txtgianhap.Text = gianhap;
                    this.txtgiabanbuon.Text = giabanbuon;
                    this.txtgiabanle.Text = giabanle;
                    ghOld = new Entities.GoiHang();
                    ghOld.GoiHangID = int.Parse(id);
                    ghOld.MaGoiHang = magoihang;
                    ghOld.TenGoiHang = tengoihang;
                    ghOld.MaNhomHang = dgvr.Cells["MaNhomHang"].Value.ToString();
                    ghOld.GiaNhap = gianhap;
                    ghOld.GiaBanBuon = giabanbuon;
                    ghOld.GiaBanLe = giabanle;

                    if (magoihang == txtmagoihang.Text)
                    {
                        SelectData1();
                    }
                }
            }
            catch { }
        }

        #endregion

        #region xử lý

        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                if (int.Parse(0 + toolStripTextBox2.Text) > 0)
                {
                    mahanghoa = toolStrip_txtTracuu.Text;
                    soluong = int.Parse(toolStripTextBox2.Text);
                    giaNhap = double.Parse(toolStrip_txtTonkho.Text);
                    //  ucHienThiXuLyGoiHang1.lblTonggn.Content = Common.Constants.TongGN + giaNhap;
                    giaBanBuon = double.Parse(toolStrip_txtTonThucTe.Text);
                    //  ucHienThiXuLyGoiHang1.lblTongbb.Content = Common.Constants.TongBB + giaBanBuon;
                    giaBanLe = double.Parse(toolStripTextBox1.Text);
                    //   ucHienThiXuLyGoiHang1.lblTongbl.Content = Common.Constants.TongBL + giaBanLe;
                    NewRow();
                    toolStrip_txtTracuu.Text = null;
                    toolStrip_txtTenhang.Text = null;
                    toolStrip_txtTonkho.Text = null;
                    toolStrip_txtTonThucTe.Text = null;
                    toolStripTextBox1.Text = null;
                    toolStripTextBox2.Text = null;
                    toolStrip_txtTracuu.Focus();
                }
                else
                {
                    toolStripTextBox2.Focus();
                    MessageBox.Show("Số lượng phải lớn hơn 0");
                }
            }

        }
        #endregion

        #region kiểm tra
        private bool KiemTra()
        {
            try
            {
                if (txtmagoihang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập mã gói hàng ", "Hệ thống cảnh báo");
                    txtmagoihang.Focus();
                    return false;
                }
                if (txttengoihang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập tên gói hàng", "Hệ thống cảnh báo");
                    txttengoihang.Focus();
                    return false;
                }
                if (this.dgvInsertOrder.RowCount <= 1)
                {
                    MessageBox.Show("Bạn cần phải nhập chi tiết gói hàng", "Hệ thống cảnh báo");
                    return false;
                }
                return true;
            }
            finally { }
        }
        #endregion

        #region check conflict

        /// <summary>
        /// Check conflic Insert , true= tim thay hang hoa do roi.
        /// </summary>
        public bool CheckConflictInsert()
        {
            bool retVal = false;
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.GoiHang ncc = new Entities.GoiHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.GoiHang[] ncc1 = new Entities.GoiHang[1];
                clientstrem = cl.SerializeObj(this.client1, "GoiHang", ncc);
                // đổ mảng đối tượng vào datagripview       
                ncc1 = (Entities.GoiHang[])cl.DeserializeHepper1(clientstrem, ncc1);
                if (ncc1 != null)
                {
                    for (int j = 0; j < ncc1.Length; j++)
                    {
                        if (ncc1[j].MaGoiHang.ToUpper().Equals(txtmagoihang.Text.ToUpper()))
                        {
                            retVal = true;
                            break;
                        }
                    }

                }
            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }

        //Check Sửa
        Entities.GoiHang[] kh1;
        Server_Client.Client cl;

        /// <summary>
        /// Check Conflic Update , true = su thay doi
        /// </summary>
        /// <returns></returns>
        public bool CheckConflictUpdate()
        {
            bool retVal = false;
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.GoiHang kh = new Entities.GoiHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                kh1 = new Entities.GoiHang[1];
                clientstrem = cl.SerializeObj(this.client1, "GoiHang", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.GoiHang[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 != null)
                {
                    for (int j = 0; j < kh1.Length; j++)
                    {
                        if (kh1[j].MaGoiHang.ToUpper().Equals(ghOld.MaGoiHang.ToUpper()))
                        {
                            bool blTenGoiHang = kh1[j].TenGoiHang.Equals(ghOld.TenGoiHang);
                            bool blMaNhomHangHoa = kh1[j].MaNhomHang.Equals(ghOld.MaNhomHang);
                            bool blGiaNhap = kh1[j].GiaNhap.Equals(ghOld.GiaNhap);
                            bool blGiaBanBuon = kh1[j].GiaBanBuon.Equals(ghOld.GiaBanBuon);
                            bool blGiaBanLe = kh1[j].GiaBanLe.Equals(ghOld.GiaBanLe);
                            if (!blTenGoiHang || !blMaNhomHangHoa || !blGiaNhap || !blGiaBanBuon || !blGiaBanLe)
                            {
                                retVal = true;
                                break;
                            }
                        }
                    }
                }

            }
            catch
            {
                retVal = false;
            }

            return retVal;
        }

        public string Check(Entities.GoiHang kh)
        {
            try
            {
                string gt = "ok";

                if (tengoihang != kh.TenGoiHang)
                {
                    tengoihang = txttengoihang.Text = kh.TenGoiHang;
                    gt = "ko";
                }

                if (gianhap != kh.GiaNhap)
                {
                    gianhap = txtgianhap.Text = kh.GiaNhap;
                    gt = "ko";
                }
                if (giabanbuon != kh.GiaBanBuon)
                {
                    giabanbuon = txtgiabanbuon.Text = kh.GiaBanBuon;
                    gt = "ko";
                }
                if (giabanle != kh.GiaBanLe)
                {
                    giabanle = txtgiabanle.Text = kh.GiaBanLe;
                    gt = "ko";
                }
                return gt;
            }
            finally
            { }
        }
        #endregion

        #region Lay chi tiet goi hang trong Gridview
        public Entities.ChiTietGoiHang[] GetChiTietGoiHang()
        {
            List<Entities.ChiTietGoiHang> list = null;
            Entities.ChiTietGoiHang chitiet = null;
            int rowCount = dgvInsertOrder.RowCount;
            if (rowCount > 1)
            {

                list = new List<Entities.ChiTietGoiHang>();
                for (int i = 0; i < rowCount - 1; i++)
                {
                    chitiet = new Entities.ChiTietGoiHang();
                    chitiet.MaGoiHang = this.txtmagoihang.Text;
                    chitiet.MaHangHoa = dgvInsertOrder.Rows[i].Cells["MaHangHoa"].Value.ToString();
                    chitiet.TenHangHoa = dgvInsertOrder.Rows[i].Cells["TenHangHoa"].Value.ToString();
                    chitiet.SoLuong = int.Parse(dgvInsertOrder.Rows[i].Cells["SoLuong"].Value.ToString());
                    chitiet.GiaNhap = dgvInsertOrder.Rows[i].Cells["GiaNhap"].Value.ToString();
                    chitiet.GiaBanBuon = dgvInsertOrder.Rows[i].Cells["GiaBanBuon"].Value.ToString();
                    chitiet.GiaBanLe = dgvInsertOrder.Rows[i].Cells["GiaBanLe"].Value.ToString();
                    chitiet.HanhDong = "Insert";
                    list.Add(chitiet);
                }
            }
            return (Entities.ChiTietGoiHang[])list.ToArray();
        }
        #endregion

        #region check datagirdinsert
        public bool InsertMang()
        {
            try
            {
                Entities.ChiTietGoiHang[] chitiet = GetChiTietGoiHang();
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "ChiTietGoiHang", chitiet);
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                return kt;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteMang(Entities.ChiTietGoiHang[] ctxh)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "ChiTietGoiHang", ctxh);
                int kt = 0;
                kt = (int)cl.DeserializeHepper(clientstrem, kt);
                if (kt == 1)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool CheckDataGridDelete(DataGridView dgv)
        {
            bool kkt = false;
            try
            {
                if (dgv.RowCount != 0)
                {
                    List<Entities.ChiTietGoiHang> list = new List<Entities.ChiTietGoiHang>();
                    Entities.ChiTietGoiHang chitietgoihang = null;
                    chitietgoihang = new Entities.ChiTietGoiHang("Delete", 0, txtmagoihang.Text, "", "", "0", "0", "0", 0);
                    list.Add(chitietgoihang);
                    Entities.ChiTietGoiHang[] ctghArr = (Entities.ChiTietGoiHang[])list.ToArray();
                    kkt = DeleteMang(ctghArr);
                    return kkt;
                }
                return kkt;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        bool CheckData()
        {
            if (dgvInsertOrder.RowCount == 0)
            {
                MessageBox.Show("danh sách hàng hóa không được trống");
                toolStrip_txtTracuu.Focus();
                return false;
            }
            return true;
        }
        #region thêm
        string ktgiatri = "";
        private void toolStripStatus_Themmoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTra())
                {
                    return;
                }

                if (CheckConflictInsert())
                {
                    MessageBox.Show("Mã gói hàng đã tồn tại", "");
                    txtmagoihang.Focus();
                    return;
                }

                if (CheckData())
                {
                    ktgiatri = "a";
                    Server_Client.Client cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    Entities.GoiHang nv = new Entities.GoiHang();
                    Entities.NhomHang nh = (Entities.NhomHang)cmbMaNhomHangHoa.SelectedItem;

                    string giaNhap = "0";
                    string giaBanBuon = "0";
                    string giaBanLe = "0";

                    if (!string.IsNullOrEmpty(txtgianhap.Text))
                        giaNhap = txtgianhap.Text;

                    if (!string.IsNullOrEmpty(txtgiabanbuon.Text))
                        giaBanBuon = txtgiabanbuon.Text;

                    if (!string.IsNullOrEmpty(txtgiabanle.Text))
                        giaBanLe = txtgiabanle.Text;

                    nv = new Entities.GoiHang("Insert", 0, this.maKho, txtmagoihang.Text, txttengoihang.Text, nh.MaNhomHang, "", giaNhap, giaBanBuon, giaBanLe, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                    clientstrem = cl.SerializeObj(this.client1, "GoiHang", nv);
                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(clientstrem, msg);
                    if (msg == 1)
                    {
                        Boolean k = InsertMang();
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("mã gói hàng đã thay đổi - kiểm tra lại dữ liệu");
                        //txtmagoihang.Text = new Common.Utilities().ProcessID(txtmagoihang.Text);
                        txtmagoihang.Focus();
                        return;
                    }
                    //  }
                }
            }
            catch { }
        }
        #endregion

        #region Check Refer False la tim thay.
        public bool CheckRefer()
        {
            bool retVal = false;
            try
            {
                Entities.CheckRefer goihang = new Entities.CheckRefer();
                goihang.TenTruong = "GH";
                goihang.MaTruong = this.txtmagoihang.Text;
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "CheckRefer", goihang);
                retVal = (bool)cl.DeserializeHepper(clientstrem, retVal);
            }
            catch (Exception)
            {
                retVal = false;
            }
            return retVal;
        }
        #endregion

        #region Sua goi hang
        public bool Sua()
        {
            bool retVal = false;
            try
            {

                //if (!CheckRefer())
                //{
                //    MessageBox.Show("Gói hàng đang có gia dịch, không được sửa", "Hệ thống cảnh báo");
                //    return false;
                //}
                if (!KiemTra())
                {
                    return false;
                }

                if (CheckConflictUpdate())
                {
                    MessageBox.Show("Dữ liệu đã thay đổi hãy kiểm tra lại", "Hệ thống cảnh báo");
                    return false;
                }
                ktgiatri = "a";
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.GoiHang nv = new Entities.GoiHang();
                Entities.NhomHang nh = (Entities.NhomHang)cmbMaNhomHangHoa.SelectedItem;

                string giaNhap = "0";
                string giaBanBuon = "0";
                string giaBanLe = "0";

                if (!string.IsNullOrEmpty(txtgianhap.Text))
                    giaNhap = txtgianhap.Text;

                if (!string.IsNullOrEmpty(txtgiabanbuon.Text))
                    giaBanBuon = txtgiabanbuon.Text;

                if (!string.IsNullOrEmpty(txtgiabanle.Text))
                    giaBanLe = txtgiabanle.Text;

                nv = new Entities.GoiHang("Update", 0, this.maKho, txtmagoihang.Text, txttengoihang.Text, nh.MaNhomHang, "", giaNhap, giaBanBuon, giaBanLe, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                clientstrem = cl.SerializeObj(this.client1, "GoiHang", nv);
                int msg = 0;
                msg = (int)cl.DeserializeHepper(clientstrem, msg);
                if (msg == 0)
                {

                    this.Close();
                }
                if (msg == 1)
                {
                    CheckDataGridDelete(this.dgvInsertOrder);
                    InsertMang();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("mã gói hàng đã thay đổi - kiểm tra lại dữ liệu");
                    txtmagoihang.Text = new Common.Utilities().ProcessID(txtmagoihang.Text);
                }

            }
            catch (Exception)
            {
                retVal = false;
            }
            return retVal;
        }
        #endregion

        #region sửa
        private void toolStripStatus_Ghilai_Click(object sender, EventArgs e)
        {
            Sua();
        }
        #endregion

        #region sự kiện
        private void dgvInsertOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SuaRow();
            }
            catch { }
        }

        private void dgvInsertOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                i = e.RowIndex;
            }
            catch { }
            // 
        }
        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.Close();
                        frmQuanLyGoiHang.trave = "A";
                    }
                    else
                    { }
                }
            }
            catch { }
        }



        private void frmXuLyGoiHang_Load(object sender, EventArgs e)
        {
            fix();
        }

        public bool Validate()
        {
            bool retVal = true;
            if (string.IsNullOrEmpty(toolStrip_txtTracuu.Text))
            {
                MessageBox.Show("Bạn phải nhập mã hàng hóa", "Hệ thống cảnh báo");
                toolStrip_txtTracuu.Focus();
                return false;
            }

            if (!CheckMaHangExited(toolStrip_txtTracuu.Text))
            {
                MessageBox.Show("Mã hàng hóa khôn tồn tại", "Hệ thống cảnh báo");
                toolStrip_txtTracuu.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(toolStrip_txtTenhang.Text))
            {
                MessageBox.Show("Không tìm thấy mã hàng hoá này", "Hệ thống cảnh báo");
                toolStrip_txtTenhang.Focus();
                return false;
            }

            if (!CheckMaHangExited(toolStrip_txtTracuu.Text))
            {
                MessageBox.Show("Không tìm thấy mã hàng hoá này", "Hệ thống cảnh báo");
                toolStrip_txtTracuu.Focus();
                return false;
            }

            if (!CheckTenHangExited(toolStrip_txtTracuu.Text, toolStrip_txtTenhang.Text))
            {
                MessageBox.Show("Tên hàng hoá không đúng", "Hệ thống cảnh báo");
                toolStrip_txtTracuu.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(toolStripTextBox2.Text))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Hệ thống cảnh báo");
                toolStripTextBox2.Focus();
                return false;
            }

            if (!string.IsNullOrEmpty(toolStripTextBox2.Text))
            {
                try
                {
                    double sl = double.Parse(toolStripTextBox2.Text);
                    if (sl <= 0)
                    {
                        MessageBox.Show("Bạn phải nhập số lượng > 0", "Hệ thống cảnh báo");
                        toolStripTextBox2.Focus();
                        return false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Bạn phải nhập số", "Hệ thống cảnh báo");
                    toolStripTextBox2.Focus();
                    return false;
                }
            }

            return retVal;
        }
        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Validate())
                {
                    if (int.Parse(0 + toolStripTextBox2.Text) > 0)
                    {
                        mahanghoa = toolStrip_txtTracuu.Text;
                        soluong = int.Parse(toolStripTextBox2.Text);
                        giaNhap = double.Parse(toolStrip_txtTonkho.Text);
                        //  ucHienThiXuLyGoiHang1.lblTonggn.Content = Common.Constants.TongGN + giaNhap;
                        giaBanBuon = double.Parse(toolStrip_txtTonThucTe.Text);
                        //  ucHienThiXuLyGoiHang1.lblTongbb.Content = Common.Constants.TongBB + giaBanBuon;
                        giaBanLe = double.Parse(toolStripTextBox1.Text);
                        //   ucHienThiXuLyGoiHang1.lblTongbl.Content = Common.Constants.TongBL + giaBanLe;
                        NewRow();
                        toolStrip_txtTracuu.Text = null;
                        toolStrip_txtTenhang.Text = null;
                        toolStrip_txtTonkho.Text = null;
                        toolStrip_txtTonThucTe.Text = null;
                        toolStripTextBox1.Text = null;
                        toolStripTextBox2.Text = null;
                        toolStrip_txtTracuu.Focus();
                    }
                    else
                    {
                        toolStripTextBox2.Focus();
                        MessageBox.Show("Số lượng phải lớn hơn 0");
                    }
                }
            }
        }
        #endregion

        private void toolStrip_txtTracuu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                LayHH();
            }
            if (e.KeyCode == Keys.Enter)
            {
                Entities.HangHoa[] hhArr = GetHangHoaTheoKho(maKho);
                Entities.HangHoa retVal = null;
                foreach (Entities.HangHoa hh in hhArr)
                {
                    if (hh.MaHangHoa.ToUpper().Equals(toolStrip_txtTracuu.Text.ToUpper()))
                    {
                        retVal = hh;
                        break;
                    }
                }
                if (retVal != null)
                {
                    toolStrip_txtTracuu.Text = retVal.MaHangHoa.ToUpper();
                    toolStrip_txtTenhang.Text = retVal.TenHangHoa;
                    toolStrip_txtTonkho.Text = retVal.GiaNhap;
                    toolStrip_txtTonThucTe.Text = retVal.GiaBanBuon;
                    toolStripTextBox1.Text = retVal.GiaBanLe;
                    toolStripTextBox2.Focus();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mã hàng hoá này", "Hệ thống cảnh báo");
                }

                fix();
            }
        }

        /// <summary>
        /// Lay tat ca hang hoa theo kho
        /// </summary>
        /// <param name="maKho"></param>
        /// <returns></returns>
        public Entities.HangHoa[] GetHangHoaTheoKho(string maKho)
        {
            Entities.HangHoa hh = null;
            Entities.HangHoa[] hhArr = null;
            try
            {
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                hh = new Entities.HangHoa("SelectTheoKho", maKho);
                hhArr = new Entities.HangHoa[1];
                clientstrem = cl.SerializeObj(this.client1, "HangHoa", hh);
                hhArr = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, hhArr);
                return hhArr;
            }
            catch (Exception)
            {
                hhArr = null;
            }
            return hhArr;
        }

        /// <summary>
        /// Check ma hang hoa da ton tai hay chua , True = da ton tai ,va nguoc lai
        /// </summary>
        /// <param name="maHang"></param>
        /// <returns></returns>
        public bool CheckMaHangExited(string maHang)
        {
            bool retVal = false;
            Entities.HangHoa[] hhArr = GetHangHoaTheoKho(maKho);
            foreach (Entities.HangHoa hh in hhArr)
            {
                if (hh.MaHangHoa.ToUpper().Equals(maHang.ToUpper()))
                {
                    retVal = true;
                    break;
                }
            }
            return retVal;
        }

        /// <summary>
        /// Check ten hang co dung la ten cua ma hang do khon , true = tim thay .
        /// </summary>
        /// <param name="maHang"></param>
        /// <param name="tenHang"></param>
        /// <returns></returns>
        public bool CheckTenHangExited(string maHang, string tenHang)
        {
            bool retVal = false;
            Entities.HangHoa[] hhArr = GetHangHoaTheoKho(maKho);
            foreach (Entities.HangHoa hh in hhArr)
            {
                if (hh.MaHangHoa.ToUpper().Equals(maHang.ToUpper()) && hh.TenHangHoa.Equals(tenHang))
                {
                    retVal = true;
                    break;
                }
            }
            return retVal;
        }
    }
}
