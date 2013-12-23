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
    public partial class frmXuLyTheGiamGia : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        public static string trave = "";
        Server_Client.Client cl;
        public frmXuLyTheGiamGia()
        {
            InitializeComponent();
            txtMaTheGiamGia.Text = ProID("TheGiamGia");
            mskBatDau.Text = mskKetThuc.Text = DateServer.Date().ToString("dd/MM/yyyy");
        }

        public frmXuLyTheGiamGia(DataGridViewRow dr)
        {
            InitializeComponent();
            tsslblthem.Enabled = false;

            txtMaTheGiamGia.Text = dr.Cells["MaTheGiamGia"].Value.ToString();
            txtGiaTriThe.Text = new TienIch().FormatMoney(dr.Cells["GiaTriThe"].Value.ToString());
            txtMaKhachHang.Text = dr.Cells["MaKhachHang"].Value.ToString();
            mskBatDau.Text = DateTime.Parse(dr.Cells["NgayBatDau"].Value.ToString()).ToString("dd/MM/yyyy");
            mskKetThuc.Text = DateTime.Parse(dr.Cells["NgayKetThuc"].Value.ToString()).ToString("dd/MM/yyyy");
            
        }

        public string ProID(string tenBang)
        {
            try
            {
                string idnew;
                cl = new Server_Client.Client();
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
                    return "TGG_0001";
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            catch { return ""; }
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
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

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.F4)
                {
                    frmTimKH frm = new frmTimKH("PhieuTTCuaKH");
                    frm.ShowDialog();
                    if (frmTimKH.drvr != null)
                    {
                        txtMaKhachHang.Text = frmTimKH.drvr.Cells["MaKH"].Value.ToString();
                        frmTimKH.drvr = null;
                        txtGiaTriThe.Focus();
                    }
                }
            }
            catch{}
        }

        bool Validate()
        {
            if (txtMaKhachHang.Text == "<F4 - Tra cứu>")
            {
                MessageBox.Show("Bạn phải chọn Mã khách hàng", "Hệ thống cảnh báo");
                return false;
            }
            if (string.IsNullOrEmpty(txtGiaTriThe.Text.Replace(",","")))
            {
                MessageBox.Show("Bạn phải nhập Giá trị thẻ", "Hệ thống cảnh báo");
                return false;

            }
            if (mskBatDau.Text.Length != 10)
            {
                MessageBox.Show("Bạn cần phải nhập " + mskBatDau.Text, "Hệ thống cảnh báo");
                mskBatDau.Focus();
                return false;
            }
            if (mskKetThuc.Text.Length != 10)
            {
                MessageBox.Show("Bạn cần phải nhập " + mskKetThuc.Text, "Hệ thống cảnh báo");
                mskKetThuc.Focus();
                return false;
            }
            string ngayct = "";
            string ngaykt = "";
            try
            {
                ngayct = new Common.Utilities().MyDateConversion(mskBatDau.Text);
            }
            catch
            {
                ngayct = null;
            }
            if (ngayct == null)
            {
                MessageBox.Show("Bạn nhập sai định dạng ngày tháng", "Hệ thống cảnh báo");
                mskBatDau.Focus();
                return false;
            }
            try
            {
                ngaykt = new Common.Utilities().MyDateConversion(mskKetThuc.Text);
            }
            catch
            {
                ngaykt = null;
            }
            if (ngaykt == null)
            {
                MessageBox.Show("Bạn nhập sai định dạng ngày tháng", "Hệ thống cảnh báo");
                mskKetThuc.Focus();
                return false;
            }
            if (DateTime.Parse(ngayct) > DateTime.Parse(ngaykt))
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn Ngày bắt đầu", "Hệ thống cảnh báo");
                mskKetThuc.Focus();
                return false;
            }            
            return true;
        }

        private void tsslblthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    if (CheckConflicInsert())
                    {
                        string date, date2;
                        try
                        {
                            date = new Common.Utilities().MyDateConversion(mskKetThuc.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Nhập sai định dạng ngày tháng", "Hệ thông cảnh báo");
                            mskKetThuc.Focus();
                            date = "";
                            return;
                        }
                        try
                        {
                            date2 = new Common.Utilities().MyDateConversion(mskBatDau.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Nhập sai định dạng ngày tháng", "Hệ thông cảnh báo");
                            mskBatDau.Focus();
                            date2 = "";
                            return;
                        }
                        cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.TheGiamGia pt = new Entities.TheGiamGia();
                        pt.HanhDong = "Insert";
                        pt.GiaTriThe = txtGiaTriThe.Text.Replace(",","");
                        pt.MaKhachHang = txtMaKhachHang.Text;
                        pt.MaTheGiamGia = txtMaTheGiamGia.Text;
                        pt.NgayBatDau = DateTime.Parse(date2);
                        pt.NgayKetThuc = DateTime.Parse(date);
                        clientstrem = cl.SerializeObj(this.client1, "TheGiamGia", pt);
                        int kt1 = 0;
                        kt1 = (int)cl.DeserializeHepper(clientstrem, kt1);
                        if (kt1 != 0)
                        {
                            ////Lấy Tên Khách Hàng
                            //string tenKH = "";
                            //cl = new Server_Client.Client();
                            //this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            //Entities.KhachHang kh = new Entities.KhachHang("Select");
                            //Entities.KhachHang[] kh1 = new Entities.KhachHang[0];
                            //clientstrem = cl.SerializeObj(this.client1, "KhachHang", kh);
                            //kh1 = (Entities.KhachHang[])cl.DeserializeHepper1(clientstrem, kh1);
                            //if (kh1 == null)
                            //{
                            //    kh1 = new Entities.KhachHang[0];
                            //}
                            //foreach (Entities.KhachHang item in kh1)
                            //{
                            //    if (!item.Deleted && txtMaKhachHang.Text.ToUpper().Equals(item.MaKH.ToUpper()))
                            //    {
                            //        tenKH = item.Ten;
                            //        break;
                            //    }
                            //}
                            ////Lấy tiền tệ tỷ giá
                            //cl = new Server_Client.Client();
                            //this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            //Entities.TienTe tt1 = new Entities.TienTe();
                            //tt1 = new Entities.TienTe("Select");
                            //clientstrem = cl.SerializeObj(this.client1, "TienTe", tt1);
                            //Entities.TienTe[] tt = new Entities.TienTe[1];
                            //tt = (Entities.TienTe[])cl.DeserializeHepper1(clientstrem, tt);
                            //if (tt != null)
                            //{
                            //    string tentiente = tt[0].TenTienTe;
                            //}
                            ////Lấy khoản mục thu chi
                            //cl = new Server_Client.Client();
                            //this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            //Entities.KMThuChi KM = new Entities.KMThuChi("Select", 1, "a", "a", true, "a", "a", "a", "a", false, " ");
                            //clientstrem = cl.SerializeObj(this.client1, "KMThuChi", KM);

                            //Entities.KMThuChi[] tk1 = new Entities.KMThuChi[1];
                            //tk1[0] = new Entities.KMThuChi(1, "a", "a", true, "a", "a", "a", "a", false, "");
                            //tk1 = (Entities.KMThuChi[])cl.DeserializeHepper1(clientstrem, tk1);
                            //if (tk1 == null)
                            //{
                            //    tk1 = new Entities.KMThuChi[0];
                            //}
                            //Entities.KMThuChi KMTC = new Entities.KMThuChi();
                            //foreach (Entities.KMThuChi item in tk1)
                            //{
                            //    if (item.DoiTuong.Equals("Khach Hang") && item.LoaiKM && !item.Deleted)
                            //    {
                            //        KMTC = item;
                            //        break;
                            //    }
                            //}
                            ////Tạo ngầm phiếu thu
                            //DateTime time = DateServer.Date();
                            //string idPTOK = ProIDPT("PhieuThu");
                            //string makho = new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen;
                            //cl = new Server_Client.Client();
                            //this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            //Entities.PhieuThu ptOK = new Entities.PhieuThu();
                            //ptOK = new Entities.PhieuThu("Insert", 0, idPTOK, time, "Thu", makho, "", KMTC.TenKhoanMuc, txtMaKhachHang.Text, tenKH, Common.Utilities.User.TenNhanVien, "", "", txtGiaTriThe.Text.Replace(",",""), tt[0].MaTienTe, false, "", false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                            //clientstrem = cl.SerializeObj(this.client1, "PhieuThu", ptOK);
                            //bool kt2 = false;
                            //try
                            //{
                            //    kt2 = (bool)cl.DeserializeHepper(clientstrem, kt2);
                            //}
                            //catch { }
                            /////////////////////////////////////////////
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại - xin hãy thử lại", "Hệ thống cảnh báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật Mã thẻ - Xin hãy kiểm tra lại", "Hệ thống cảnh báo");
                        txtMaTheGiamGia.Text = mathemoi;
                        return;
                    }
                }
            }
            catch { }
        }
        string mathemoi = "";
        bool CheckConflicInsert()
        {
            try
            {
                mathemoi = ProID("TheGiamGia");
                if (txtMaTheGiamGia.Text == mathemoi)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void txtGiaTriThe_TextChanged(object sender, EventArgs e)
        {
            new TienIch().AutoFormatMoney(sender);
        }

        private void tsslbldong_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                trave = "ok";
                this.Close();
            }
        }

        /// <summary>
        /// Lấy giá trị id cuối cùng
        /// </summary>
        /// <param name="tenBang"></param>
        /// <returns></returns>
        public string ProIDPT(string tenBang)
        {
            try
            {
                string idnew = "";
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.PhieuThu pt = new Entities.PhieuThu("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.PhieuThu[] pt1 = new Entities.PhieuThu[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuThu", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.PhieuThu[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 == null)
                {
                    return "PT_0001";
                }
                List<Entities.PhieuThu> lThu = new List<Entities.PhieuThu>();
                foreach (Entities.PhieuThu item in pt1)
                {
                    if (item.LoaiPhieu.Equals("Thu"))
                    {
                        lThu.Add(item);
                    }
                }
                if (lThu.Count == 0)
                {//Không có phiếu thu
                    return "PT_0001";
                }
                else if (lThu.Count >= 1)
                {
                    string t = lThu[lThu.Count - 1].MaPhieuThu;
                    string[] tt = t.Split('_');
                    int ttt = int.Parse(tt[1]) + 1;
                    string tttt = ttt.ToString();
                    if (tttt.Length == 1)
                    {
                        idnew = "PT_000" + tttt;
                    }
                    else if (tttt.Length == 2)
                    {
                        idnew = "PT_00" + tttt;
                    }
                    else if (tttt.Length == 3)
                    {
                        idnew = "PT_0" + tttt;
                    }
                    else if (tttt.Length == 4)
                    {
                        idnew = "PT_" + tttt;
                    }
                }
                return idnew;
            }
            catch { return ""; }
        }
    }
}
