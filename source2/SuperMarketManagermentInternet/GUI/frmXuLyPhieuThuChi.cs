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

namespace GUI
{
    public partial class frmXuLyPhieuThuChi : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        DateTime datesv;
        bool thuORchi = true;   //True: thu ||False: chi
        bool xemlai = false;

        public frmXuLyPhieuThuChi()
        {
            InitializeComponent();datesv = DateServer.Date();
        }

        /// <summary>
        /// Xử lý giá trị truyền tới
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="dtgvr"></param>
        string id;
        string sochungtu, datetime, khohang, nhomhang, nguoinoptien, khoanmuc, doituong, tknh, notaikhoan, cotaikhoan, tongtien, tiente, diengiai;
        bool kt;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="dtgvr"></param>
        public frmXuLyPhieuThuChi(string str1, string str2, DataGridViewRow dtgvr)
        {
            try
            {
                InitializeComponent();
                datesv = DateServer.Date();
                if (str1.Equals("Thu"))
                {
                    thuORchi = true;
                }
                else if (str1.Equals("Chi"))
                {
                    thuORchi = false;
                }
                checkBox1.Visible = thuORchi;
                XuLyString(str1, str2);
                try
                {
                    XuLyCombobox();
                }
                catch { }
                id = dtgvr.Cells["PhieuThuID"].Value.ToString();
                sochungtu = txtsochungtu.Text = dtgvr.Cells["MaPhieuThu"].Value.ToString();
                datetime = mskngaychungtu.Text = new Common.Utilities().XuLy(2, dtgvr.Cells["NgayLap"].Value.ToString());
                khohang = dtgvr.Cells["MaKho"].Value.ToString();
                cbbkhohang.Text = LayTenKho(khohang);
                nhomhang = dtgvr.Cells["MaNhomHang"].Value.ToString();
                cbbnhomhangcaptren.Text = LayTenNhomHang(nhomhang);
                nguoinoptien = txtnguoinoptien.Text = dtgvr.Cells["NguoiNopTien"].Value.ToString();
                if (str1 == "Thu")
                    cbbloaichungtu.SelectedIndex = 0;
                if (str1 == "Chi")
                    cbbloaichungtu.SelectedIndex = 1;
                khoanmuc = cbbkhoanmuc.Text = dtgvr.Cells["KhoanMuc"].Value.ToString();
                doituong = txtdoituong.Text = dtgvr.Cells["DoiTuong"].Value.ToString();
                notaikhoan = cbbnotaikhoan.Text = dtgvr.Cells["NoTaiKhoan"].Value.ToString();
                cotaikhoan = cbbcotaikhoan.Text = dtgvr.Cells["CoTaiKhoan"].Value.ToString();
                tongtien = txtsotienthanhtoan.Text = new TienIch().FormatMoney(dtgvr.Cells["TongTienThanhToan"].Value.ToString());
                tiente = dtgvr.Cells["MaTienTe"].Value.ToString();
                cbbtientetygia.Text = LayTenTT(tiente);
                txttientetygia.Text = LayDonViTT(tiente);

                diengiai = txtdiengiai.Text = dtgvr.Cells["GhiChu"].Value.ToString();
                if (kmtc == null)
                {
                    return;
                }
                if (kmtc.Length != 0)
                {
                    for (int j = 0; j < kmtc.Length; j++)
                    {
                        if (kmtc[j].TenKhoanMuc == khoanmuc)
                        {
                            cbbdoituong.Text = kmtc[j].DoiTuong;
                            break;
                        }
                    }
                }
                if (tt.Length != 0)
                {
                    for (int j = 0; j < tt.Length; j++)
                    {
                        if (tt[j].MaTienTe == tiente)
                        {
                            txttientetygia.Text = tt[j].DonViLamTron.ToString();
                            break;
                        }
                    }
                }
                SelectKH();
                SelectNCC();

                xemlai = true;
                //Xử lý xem lại khi thanh toán tiền thẻ ưu đãi của khách hàng
                LayChiTietTheGiamGia();
                foreach (Entities.ChiTietTheGiamGia item in CTTGG)
                {
                    if (item.MaPhieuThu.ToUpper().Equals(txtsochungtu.Text.ToUpper()))
                    {
                        checkBox1.Checked = true;
                        label1.Visible = true;
                        comboBox1.Visible = true;
                        comboBox1.Enabled = false;
                        comboBox1.Text = item.MaTheGiamGia;
                        break;
                    }
                }
            }
            catch { }
        }
        public void SelectKH()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KhachHang kh = new Entities.KhachHang();
                kh = new Entities.KhachHang("Select");
                Entities.KhachHang[] kh1 = new Entities.KhachHang[1];
                clientstrem = cl.SerializeObj(this.client1, "KhachHang", kh);
                kh1 = (Entities.KhachHang[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 == null)
                {
                    kh1 = new Entities.KhachHang[0];
                    return;
                }

                Entities.KhachHang[] pt2 = new Entities.KhachHang[kh1.Length];
                for (int j = 0; j < kh1.Length; j++)
                {
                    if (kh1[j].MaKH == doituong)
                    {
                        lbhienthidiachi.Text = kh1[j].DiaChi;
                        lbhienthima.Text = kh1[j].MaKH;
                        lbhienthiten.Text = kh1[j].Ten;
                        break;
                    }
                }
            }
            catch { }
        }

        public void SelectNCC()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.NhaCungCap kh = new Entities.NhaCungCap();
                kh = new Entities.NhaCungCap("Select");
                Entities.NhaCungCap[] kh1 = new Entities.NhaCungCap[1];
                clientstrem = cl.SerializeObj(this.client1, "NhaCungCap", kh);
                kh1 = (Entities.NhaCungCap[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 == null)
                {
                    kh1 = new Entities.NhaCungCap[0];
                    return;
                }

                Entities.NhaCungCap[] pt2 = new Entities.NhaCungCap[kh1.Length];
                for (int j = 0; j < kh1.Length; j++)
                {

                    if (kh1[j].MaNhaCungCap == doituong)
                    {
                        lbhienthidiachi.Text = kh1[j].DiaChi;
                        lbhienthima.Text = kh1[j].MaNhaCungCap;
                        lbhienthiten.Text = kh1[j].TenNhaCungCap;
                        break;
                    }
                }
            }
            catch { }
        }

        public void SelectNV()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.NhanVien kh = new Entities.NhanVien();
                kh = new Entities.NhanVien("Select");
                Entities.NhanVien[] kh1 = new Entities.NhanVien[1];
                clientstrem = cl.SerializeObj(this.client1, "NhanVien", kh);
                kh1 = (Entities.NhanVien[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 == null)
                {
                    kh1 = new Entities.NhanVien[0];
                    return;
                }

                Entities.NhanVien[] pt2 = new Entities.NhanVien[kh1.Length];
                for (int j = 0; j < kh1.Length; j++)
                {

                    if (kh1[j].MaNhanVien == doituong)
                    {
                        lbhienthidiachi.Text = kh1[j].Email;
                        lbhienthima.Text = kh1[j].MaNhanVien;
                        lbhienthiten.Text = kh1[j].TenNhanVien;
                        break;
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// Truyền giá trị
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        public frmXuLyPhieuThuChi(string str1, string str2)
        {
            try
            {
                InitializeComponent(); datesv = DateServer.Date();
                if (str1.Equals("Thu"))
                {
                    thuORchi = true;
                }
                else if (str1.Equals("Chi"))
                {
                    thuORchi = false;
                }
                checkBox1.Visible = thuORchi;
                sochungtu = txtsochungtu.Text = ProID("PhieuThu");
                try
                {
                    XuLyString(str1, str2);
                    XuLyCombobox();
                    cbbtientetygia.SelectedIndex = cbbcotaikhoan.SelectedIndex = cbbkhohang.SelectedIndex = cbbnotaikhoan.SelectedIndex = cbbnhomhangcaptren.SelectedIndex = cbbcotaikhoan.SelectedIndex = 0;
                }
                catch
                {
                }
                if (str1 == "Thu")
                    cbbloaichungtu.SelectedIndex = 0;
                else if (str1 == "Chi")
                    cbbloaichungtu.SelectedIndex = 1;

                mskngaychungtu.Text = new Common.Utilities().XuLy(2, datesv.ToShortDateString());
            }
            catch { }
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
                string idnew = "";

                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.PhieuThu pt = new Entities.PhieuThu("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                pt1 = new Entities.PhieuThu[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuThu", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.PhieuThu[])cl.DeserializeHepper1(clientstrem, pt1);

                if (this.thuORchi)
                {//Thu
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
                }
                else
                {//Chi
                    if (pt1 == null)
                    {
                        return "PC_0001";
                    }
                    List<Entities.PhieuThu> lChi = new List<Entities.PhieuThu>();
                    foreach (Entities.PhieuThu item in pt1)
                    {
                        if (item.LoaiPhieu.Equals("Chi"))
                        {
                            lChi.Add(item);
                        }
                    }
                    if (lChi.Count == 0)
                    {//Không có phiếu chi
                        return "PC_0001";
                    }
                    else if (lChi.Count >= 1)
                    {
                        string t = lChi[lChi.Count - 1].MaPhieuThu;
                        string[] tt = t.Split('_');
                        int ttt = int.Parse(tt[1]) + 1;
                        string tttt = ttt.ToString();
                        if (tttt.Length == 1)
                        {
                            idnew = "PC_000" + tttt;
                        }
                        else if (tttt.Length == 2)
                        {
                            idnew = "PC_00" + tttt;
                        }
                        else if (tttt.Length == 3)
                        {
                            idnew = "PC_0" + tttt;
                        }
                        else if (tttt.Length == 4)
                        {
                            idnew = "PC_" + tttt;
                        }
                    }
                }
                return idnew;
            }
            catch { return ""; }
        }

        /// <summary>
        /// Đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssltrove_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Các method xử lý khác
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssbkhac_ButtonClick(object sender, EventArgs e)
        {

        }
        /// <summary>
        ///  nút trở về
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssltrove_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    frmQuanLyPhieuThu.trave = "a";
                    this.Close();
                }
                else
                { }
            }
        }
        /// <summary>
        /// kiểm tra trươc khi insert
        /// </summary>
        public void CheckConflictInsert()
        {
            try
            {
                kt = true;
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
                if (pt1 != null)
                {
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        if (pt1[j].MaPhieuThu == sochungtu)
                        {
                            MessageBox.Show("cập nhật mã phiếu - kiểm tra lại để insert");
                            kt = false;
                            sochungtu = txtsochungtu.Text = ProID("PhieuThu");
                            break;
                        }
                        else
                            kt = true;
                    }
                }
            }
            catch { }
        }
        Entities.PhieuThu[] pt1;
        /// <summary>
        /// kiểm tra trước khi update
        /// </summary>
        public void CheckConflictUpdate()
        {
            try
            {
                kt = true;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.PhieuThu pt = new Entities.PhieuThu("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                pt1 = new Entities.PhieuThu[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuThu", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.PhieuThu[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 != null)
                {
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        if (pt1[j].MaPhieuThu == sochungtu)
                        {
                            kt = Check(pt1[j]);
                            break;
                        }
                        else
                            kt = true;
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// kiểm tra dữ liệu nhập vào
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        public bool Check(Entities.PhieuThu pt)
        {
            bool gt = true;
            string datetimenew = new Common.Utilities().XuLy(2, (pt.NgayLap.ToString()));

            if (datetime != datetimenew)
            {
                datetime = mskngaychungtu.Text = datetimenew;
                gt = false;
            }
            if (khohang != pt.MaKho)
            {
                khohang = pt.MaKho;
                cbbkhohang.Text = LayTenTT(khohang);
                gt = false;
            }
            if (nhomhang != pt.MaNhomHang)
            {
                nhomhang = pt.MaNhomHang;
                cbbnhomhangcaptren.Text = LayTenNhomHang(nhomhang);
                gt = false;
            }
            if (khoanmuc != pt.KhoanMuc)
            {
                khoanmuc = cbbkhoanmuc.Text = pt.KhoanMuc;
                gt = false;
            }
            if (doituong != pt.DoiTuong)
            {
                doituong = txtdoituong.Text = pt.DoiTuong;
                gt = false;
            }
            if (nguoinoptien != pt.NguoiNopTien)
            {
                nguoinoptien = txtnguoinoptien.Text = pt.NguoiNopTien;
                gt = false;
            }
            if (notaikhoan != pt.NoTaiKhoan)
            {
                notaikhoan = cbbnotaikhoan.Text = pt.NoTaiKhoan;
                gt = false;
            }
            if (cotaikhoan != pt.CoTaiKhoan)
            {
                cotaikhoan = cbbcotaikhoan.Text = pt.CoTaiKhoan;
                gt = false;
            }
            string tt = String.Format("{0:0,0}", Double.Parse(pt.TongTienThanhToan.ToString()));
            if (tongtien != tt)
            {
                tongtien = String.Format("{0:0,0}", Double.Parse(pt.TongTienThanhToan.ToString()));
                txtsotienthanhtoan.Text = new TienIch().FormatMoney(pt.TongTienThanhToan.ToString());
                gt = false;
            }
            if (tiente != pt.MaTienTe)
            {
                tiente = pt.MaTienTe;
                cbbtientetygia.Text = LayTenTT(tiente);
                txttientetygia.Text = LayDonViTT(tiente);
                gt = false;
            }
            if (diengiai != pt.GhiChu)
            {
                diengiai = txtdiengiai.Text = pt.GhiChu;
                gt = false;
            }
            return gt;
        }

        Server_Client.Client cl;
        Entities.TienTe[] tt;
        /// <summary>
        /// lấy tên tiền tệ
        /// </summary>
        public void LayTenTT()
        {
            try
            {
                cbbtientetygia.Items.Clear();
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.TienTe tt1 = new Entities.TienTe();
                tt1 = new Entities.TienTe("Select");
                clientstrem = cl.SerializeObj(this.client1, "TienTe", tt1);
                tt = new Entities.TienTe[1];
                tt = (Entities.TienTe[])cl.DeserializeHepper1(clientstrem, tt);
                if (tt.Length > 0)
                {
                    int sl = tt.Length;
                    for (int i = 0; i < sl; i++)
                    {
                        cbbtientetygia.Items.Add(tt[i].TenTienTe);
                    }
                }
            }
            catch
            {
                cbbtientetygia.Items.Clear();
                cbbtientetygia.Text = "";
            }
        }
        /// <summary>
        /// lấy mã tiền tệ
        /// </summary>
        /// <param name="tenTT"></param>
        /// <returns></returns>
        public string LayMaTT(string tenTT)
        {
            try
            {
                for (int j = 0; j < tt.Length; j++)
                {
                    if (tt[j].TenTienTe == tenTT)
                    {
                        return tt[j].MaTienTe;
                    }
                }
                return "";
            }
            catch { return ""; }
        }
        /// <summary>
        /// lấy tên tiền tệ
        /// </summary>
        /// <param name="maTT"></param>
        /// <returns></returns>
        public string LayTenTT(string maTT)
        {
            try
            {
                for (int j = 0; j < tt.Length; j++)
                {
                    if (tt[j].MaTienTe == maTT)
                    {
                        return tt[j].TenTienTe;
                    }
                }
            }
            catch
            {

            }
            return "";
        }
        /// <summary>
        /// lấy đơn vị tiền tệ
        /// </summary>
        /// <param name="maTT"></param>
        /// <returns></returns>
        public string LayDonViTT(string maTT)
        {
            try
            {
                for (int j = 0; j < tt.Length; j++)
                {
                    if (tt[j].MaTienTe == maTT)
                    {
                        return tt[j].DonViLamTron.ToString();
                    }
                }
            }
            catch
            {
            }
            return "";
        }
        /// <summary>
        /// Lấy khoản mục thu chi
        /// </summary>
        /// <param name="Loai"></param>
        Entities.KMThuChi[] kmtc;
        public void LayKMThuChi(Boolean Loai)
        {
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

            Entities.KMThuChi tt1 = new Entities.KMThuChi();
            tt1 = new Entities.KMThuChi("SelectTheoMa", Loai);
            clientstrem = cl.SerializeObj(this.client1, "KMThuChi", tt1);
            kmtc = new Entities.KMThuChi[1];
            kmtc = (Entities.KMThuChi[])cl.DeserializeHepper1(clientstrem, kmtc);
            try
            {
                if (kmtc.Length > 0)
                {
                    int sl = kmtc.Length;
                    for (int i = 0; i < sl; i++)
                    {
                        cbbkhoanmuc.Items.Add(kmtc[i].TenKhoanMuc);
                    }
                }
            }
            catch
            {
                cbbkhoanmuc.Items.Clear();
                cbbkhoanmuc.Text = "";
                cbbdoituong.Text = "";
            }
        }
        Entities.KhoHang[] kh1;
        /// <summary>
        /// lấy kho hàng
        /// </summary>
        public void LayKhoHang()
        {
            try
            {
                cbbkhohang.Items.Clear();
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                Entities.KhoHang kh = new Entities.KhoHang();
                kh = new Entities.KhoHang("Select");
                clientstrem = cl.SerializeObj(this.client1, "KhoHang", kh);
                kh1 = new Entities.KhoHang[1];
                kh1 = (Entities.KhoHang[])cl.DeserializeHepper1(clientstrem, kh1);

                if (kh1.Length > 0)
                {
                    int sl = kh1.Length;
                    for (int i = 0; i < sl; i++)
                    {
                        if (kh1[i].Deleted == false)
                            cbbkhohang.Items.Add(kh1[i].TenKho);
                    }
                }
            }
            catch
            {
                cbbkhohang.Items.Clear();
                cbbkhohang.Text = "";
            }
        }
        /// <summary>
        /// lấy mã kho
        /// </summary>
        /// <param name="tenKho"></param>
        /// <returns></returns>
        public string LayMaKho(string tenKho)
        {
            try
            {
                for (int j = 0; j < kh1.Length; j++)
                {
                    if (kh1[j].TenKho == tenKho)
                    {
                        return kh1[j].MaKho;
                    }
                }
                return "";
            }
            catch { return ""; }
        }
        /// <summary>
        /// lấy tên kho
        /// </summary>
        /// <param name="maKho"></param>
        /// <returns></returns>
        public string LayTenKho(string maKho)
        {
            try
            {
                for (int j = 0; j < kh1.Length; j++)
                {
                    if (kh1[j].MaKho == maKho)
                    {
                        return kh1[j].TenKho;
                    }
                }
                return "";
            }
            catch { return ""; }
        }

        Entities.NhomHang[] nhh1;
        /// <summary>
        /// lấy mã nhóm hàng
        /// </summary>
        public void LayMaNhomHang()
        {
            try
            {
                cbbnhomhangcaptren.Items.Clear();
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                Entities.NhomHang nhh = new Entities.NhomHang();
                nhh = new Entities.NhomHang("Select");
                clientstrem = cl.SerializeObj(this.client1, "NhomHang", nhh);
                nhh1 = new Entities.NhomHang[1];
                nhh1 = (Entities.NhomHang[])cl.DeserializeHepper1(clientstrem, nhh1);

                if (nhh1.Length > 0)
                {
                    int sl = nhh1.Length;
                    for (int i = 0; i < sl; i++)
                    {
                        if (nhh1[i].Deleted == false)
                            cbbnhomhangcaptren.Items.Add(nhh1[i].TenNhomHang);
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// lấy tên nhóm hàng
        /// </summary>
        /// <param name="maNhomHang"></param>
        /// <returns></returns>
        public string LayTenNhomHang(string maNhomHang)
        {
            try
            {
                for (int j = 0; j < nhh1.Length; j++)
                {
                    if (nhh1[j].MaNhomHang == maNhomHang)
                    {
                        return nhh1[j].TenNhomHang;
                    }
                }
                return "";
            }
            catch { return ""; }
        }
        /// <summary>
        /// lấy mã nhóm hàng
        /// </summary>
        /// <param name="tenNhomHang"></param>
        /// <returns></returns>
        public string LayMaNhomHang(string tenNhomHang)
        {
            try
            {
                for (int j = 0; j < nhh1.Length; j++)
                {
                    if (nhh1[j].TenNhomHang == tenNhomHang)
                    {
                        return nhh1[j].MaNhomHang;
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        /// Lấy có tài khoản
        /// </summary>
        public void LayCoTK(ComboBox cbb)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                Entities.TKKeToan tkkt = new Entities.TKKeToan();
                tkkt = new Entities.TKKeToan("LayCoTK");
                clientstrem = cl.SerializeObj(this.client1, "TKKeToan", tkkt);
                Entities.TKKeToan[] tkkt1 = new Entities.TKKeToan[1];
                tkkt1 = (Entities.TKKeToan[])cl.DeserializeHepper1(clientstrem, tkkt1);

                if (tkkt1.Length > 0)
                {
                    int sl = tkkt1.Length;
                    for (int i = 0; i < sl; i++)
                    {
                        if (tkkt1[i].Deleted == false)
                            cbb.Items.Add(tkkt1[i].MaTKKeToan);
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// lấy nợ tài khoản
        /// </summary>
        public void LayNoTK(ComboBox cbb)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                Entities.TKKeToan tkkt = new Entities.TKKeToan();
                tkkt = new Entities.TKKeToan("LayNoTK");
                clientstrem = cl.SerializeObj(this.client1, "TKKeToan", tkkt);
                Entities.TKKeToan[] tkkt1 = new Entities.TKKeToan[1];
                tkkt1 = (Entities.TKKeToan[])cl.DeserializeHepper1(clientstrem, tkkt1);

                if (tkkt1.Length > 0)
                {
                    int sl = tkkt1.Length;
                    for (int i = 0; i < sl; i++)
                    {
                        if (tkkt1[i].Deleted == false)
                            cbb.Items.Add(tkkt1[i].MaTKKeToan);
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// Chọn loại chứng từ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbloaichungtu_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbbdoituong.Items.Clear();
                cbbkhoanmuc.Items.Clear();
                cbbdoituong.Text = "";
                cbbkhoanmuc.Text = "";
                int i = cbbloaichungtu.SelectedIndex;
                if (i == 0)
                {
                    LayKMThuChi(true);
                    cbbnotaikhoan.Items.Clear();
                    cbbcotaikhoan.Items.Clear();
                    LayNoTK(cbbnotaikhoan);
                    LayCoTK(cbbcotaikhoan);
                }
                else if (i == 1)
                {
                    LayKMThuChi(false);
                    cbbnotaikhoan.Items.Clear();
                    cbbcotaikhoan.Items.Clear();
                    LayNoTK(cbbcotaikhoan);
                    LayCoTK(cbbnotaikhoan);
                }
            }
            catch { }
        }
        /// <summary>
        /// Chọn KMThuChi - để lấy đối tượng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbkhoanmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbbdoituong.Items.Clear();
                txtdoituong.Text = "";
                int i = cbbkhoanmuc.SelectedIndex;
                if (i >= 0)
                {
                    for (int j = 0; j < kmtc.Length; j++)
                    {
                        if (kmtc[j].TenKhoanMuc == cbbkhoanmuc.SelectedItem.ToString())
                        {
                            cbbdoituong.Items.Add(kmtc[j].DoiTuong);
                            cbbdoituong.SelectedIndex = 0;
                            cbbnotaikhoan.Text = kmtc[j].NoTK;
                            cbbcotaikhoan.Text = kmtc[j].CoTK;
                            break;
                        }
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// nút sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (Kiemtra() == true)
                {
                    CheckConflictUpdate();
                    if (kt == true)
                    {
                        cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        string date = new Common.Utilities().MyDateConversion(mskngaychungtu.Text);
                        string makho = LayMaKho(cbbkhohang.Text);
                        string manhomhang = LayMaNhomHang(cbbnhomhangcaptren.Text);
                        string matt = LayMaTT(cbbtientetygia.Text);
                        Entities.PhieuThu pt = new Entities.PhieuThu("Update", int.Parse(id), txtsochungtu.Text, Convert.ToDateTime(date), cbbloaichungtu.Text, makho, manhomhang, cbbkhoanmuc.Text, txtdoituong.Text, txtnguoinoptien.Text, txtnguoinoptien.Text, cbbnotaikhoan.Text, cbbcotaikhoan.Text, txtsotienthanhtoan.Text.Replace(",", ""), matt, false, txtdiengiai.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);

                        clientstrem = cl.SerializeObj(this.client1, "PhieuThu", pt);
                        bool kt1 = false;
                        kt1 = (bool)cl.DeserializeHepper(clientstrem, kt);
                        if (kt1 == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("thất bại - xin kiểm tra lại dữ liệu", "Hệ thống cảnh báo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu đã được thay đổi - hãy kiểm tra lại", "Hệ thống cảnh báo");
                    }
                }
            }
            catch { }
        }
        string duno = "0";
        /// <summary>
        /// xử lý tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbdoituong.Text == "Khach Hang")
                {
                    frmTimKH kh = new frmTimKH("PhieuTTCuaKH");
                    kh.ShowDialog();
                    if (frmTimKH.drvr != null)
                    {
                        string dt = txtdoituong.Text;
                        txtdoituong.Text = frmTimKH.drvr.Cells["MaKH"].Value.ToString();
                        if (!dt.ToUpper().Equals(txtdoituong.Text.ToUpper()))
                        {
                            checkBox1.Checked = false;
                        }
                        lbhienthima.Text = frmTimKH.drvr.Cells["MaKH"].Value.ToString();
                        lbhienthiten.Text = frmTimKH.drvr.Cells["Ten"].Value.ToString();
                        lbhienthidiachi.Text = frmTimKH.drvr.Cells["DiaChi"].Value.ToString();
                        duno = frmTimKH.drvr.Cells["DuNo"].Value.ToString();
                        frmTimKH.drvr = null;
                    }
                }
                if (cbbdoituong.Text == "Nha Cung Cap")
                {
                    frmTimNCC tkh = new frmTimNCC("PhieuTTNCC");
                    tkh.ShowDialog();
                    if (frmTimNCC.drvr != null)
                    {
                        txtdoituong.Text = frmTimNCC.drvr.Cells["MaNhaCungCap"].Value.ToString();
                        lbhienthima.Text = frmTimNCC.drvr.Cells["MaNhaCungCap"].Value.ToString();
                        lbhienthiten.Text = frmTimNCC.drvr.Cells["TenNhaCungCap"].Value.ToString();
                        lbhienthidiachi.Text = frmTimNCC.drvr.Cells["DiaChi"].Value.ToString();
                        duno = frmTimNCC.drvr.Cells["DuNo"].Value.ToString();
                        frmTimNCC.drvr = null;
                    }
                }
                if (cbbdoituong.Text == "Nhan Vien")
                {
                    frmTimNhanVien tnv = new frmTimNhanVien();
                    tnv.ShowDialog();
                    if (frmTimNhanVien.drvr != null)
                    {
                        txtdoituong.Text = frmTimNhanVien.drvr.Cells["MaNhanVien"].Value.ToString();
                        lbhienthima.Text = frmTimNhanVien.drvr.Cells["MaNhanVien"].Value.ToString();
                        lbhienthiten.Text = frmTimNhanVien.drvr.Cells["TenNhanVien"].Value.ToString();
                        lbhienthidiachi.Text = frmTimNhanVien.drvr.Cells["Email"].Value.ToString();
                        frmTimNhanVien.drvr = null;
                    }
                }
                if (cbbdoituong.Text == "")
                {
                    MessageBox.Show("Bạn phải chọn Khoản mục");
                }
            }
            catch (Exception ex)
            {

            }
        }
        public bool UpdateDuNoNCC(Entities.NhaCungCap ctkhthdn)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "NhaCungCap", ctkhthdn);
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                return kt;
            }
            catch { return false; }
        }
        /// <summary>
        /// update dư nợ
        /// </summary>
        /// <param name="ctkhthdn"></param>
        public bool UpdateDuNo(Entities.KhachHang ctkhthdn)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "KhachHang", ctkhthdn);
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                return kt;
            }
            catch { return false; }
        }

        int UpdateDuNo(Entities.UpdateDuNoK29 tem)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "ThaoTac_UpdateDuNo_k", tem);
                int kq = 0;
                kq = (int)cl.DeserializeHepper(clientstrem, kq);
                return kq;
            }
            catch { return 0; }
        }

        /// <summary>
        /// thêm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslthemmoi_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (Kiemtra() == true)
                {
                    CheckConflictInsert();
                    if (kt == true)
                    {
                        cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        string date = new Common.Utilities().MyDateConversion(mskngaychungtu.Text);
                        Entities.PhieuThu pt = new Entities.PhieuThu();
                        string makho = "";
                        string manhomhang = "";
                        //string makho = LayMaKho(cbbkhohang.Text);
                        //string manhomhang = LayMaNhomHang(cbbnhomhangcaptren.Text);
                        string matt = LayMaTT(cbbtientetygia.Text);
                        pt = new Entities.PhieuThu("Insert", 0, txtsochungtu.Text, Convert.ToDateTime(date), cbbloaichungtu.Text, makho, manhomhang, cbbkhoanmuc.Text, txtdoituong.Text, txtnguoinoptien.Text, Common.Utilities.User.TenNhanVien, cbbnotaikhoan.Text, cbbcotaikhoan.Text, txtsotienthanhtoan.Text.Replace(",", ""), matt, false, txtdiengiai.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);

                        clientstrem = cl.SerializeObj(this.client1, "PhieuThu", pt);
                        bool kt1 = false;
                        try
                        {
                            kt1 = (bool)cl.DeserializeHepper(clientstrem, kt1);
                        }
                        catch { }
                        if (kt1 == true)
                        {
                            //cập nhật trạng thái đã thanh toán của thẻ giá trị (update in chitietthegiatri)
                            if (checkBox1.Checked)
                            {
                                bool run = CapNhatChiTietTheGiamGia();
                            }
                            ////////////////////////////////////////////
                            if (cbbdoituong.Text == "Khach Hang")
                            {
                                if (cbbloaichungtu.Text == "Thu")
                                {
                                    //PHIẾU THU CỦA KHÁCH HÀNG: Cập nhật dư nợ cho khách hàng: NHT -= txtsotienthanhtoan.Text;
                                    int ketqua = 0;
                                    ketqua = UpdateDuNo(new Entities.UpdateDuNoK29("KH_TRU", txtdoituong.Text, txtdoituong.Text, float.Parse(txtsotienthanhtoan.Text.Replace(",", ""))));
                                    if (ketqua > 0) { }
                                    else
                                    {
                                        MessageBox.Show("Cập nhật dư nợ cho khách hàng thất bại - xin hãy thử lại", "Hệ Thống Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    //PHIẾU CHI CỦA KHÁCH HÀNG: Cập nhật dư nợ cho khách hàng: NHT += txtsotienthanhtoan.Text;
                                    int ketqua = 0;
                                    ketqua = UpdateDuNo(new Entities.UpdateDuNoK29("KH_CONG", txtdoituong.Text, txtdoituong.Text, float.Parse(txtsotienthanhtoan.Text.Replace(",", ""))));
                                    if (ketqua > 0) { }
                                    else
                                    {
                                        MessageBox.Show("Cập nhật dư nợ cho khách hàng thất bại - xin hãy thử lại", "Hệ Thống Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else if (cbbdoituong.Text == "Nha Cung Cap")
                            {
                                if (cbbloaichungtu.Text == "Chi")
                                {
                                    //PHIẾU CHI CỦA NHÀ CUNG CẤP: Cập nhật dư nợ cho nhà cung cấp: NHT -= txtsotienthanhtoan.Text;
                                    int ketqua = 0;
                                    ketqua = UpdateDuNo(new Entities.UpdateDuNoK29("NCC_TRU", txtdoituong.Text, txtdoituong.Text, float.Parse(txtsotienthanhtoan.Text.Replace(",", ""))));
                                    if (ketqua > 0) { }
                                    else
                                    {
                                        MessageBox.Show("Cập nhật dư nợ cho nhà cung cấp thất bại - xin hãy thử lại", "Hệ Thống Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    //PHIẾU THU CỦA NHÀ CUNG CẤP: Cập nhật dư nợ cho nhà cung cấp: NHT += txtsotienthanhtoan.Text;
                                    int ketqua = 0;
                                    ketqua = UpdateDuNo(new Entities.UpdateDuNoK29("NCC_CONG", txtdoituong.Text, txtdoituong.Text, float.Parse(txtsotienthanhtoan.Text.Replace(",", ""))));
                                    if (ketqua > 0) { }
                                    else
                                    {
                                        MessageBox.Show("Cập nhật dư nợ cho nhà cung cấp thất bại - xin hãy thử lại", "Hệ Thống Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("thất bại - xin kiểm tra lại dữ liệu", "Hệ thống cảnh báo");
                        }
                    }
                }
            }
            catch { }
            this.Enabled = true;
        }
        /// <summary>
        /// xử lý các combobox
        /// </summary>
        public void XuLyCombobox()
        {
            try
            {
                LayKhoHang();
                cbbkhohang.SelectedIndex = 0;
            }
            catch { }
            try
            {
                LayMaNhomHang();
                cbbnhomhangcaptren.SelectedIndex = 0;
            }
            catch { }
            try
            {
                LayTenTT();
                cbbtientetygia.SelectedIndex = 0;
            }
            catch { }
        }
        /// <summary>
        /// kiểm tra dữ liệu nhập vào
        /// </summary>
        /// <returns></returns>
        private bool Kiemtra()
        {
            if (cbbkhoanmuc.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + lbkhoanmuc.Text, "Hệ thống cảnh báo");
                cbbkhoanmuc.Focus();
                return false;
            }
            if (txtdoituong.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + lbdoituong.Text, "Hệ thống cảnh báo");
                btntimkiem.Focus();
                return false;
            }
            if (txtnguoinoptien.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + lbnguoinoptien.Text, "Hệ thống cảnh báo");
                txtnguoinoptien.Focus();
                return false;
            }
            if (cbbtientetygia.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập Tiền tệ", "Hệ thống cảnh báo");
                cbbtientetygia.Focus();
                return false;
            }

            try
            {
                float.Parse(txtsotienthanhtoan.Text.Replace(",", ""));
            }
            catch
            {
                MessageBox.Show("Bạn phải nhập Thanh toán >0", "Hệ thống cảnh báo");
                txtsotienthanhtoan.Focus();
            }
            if (float.Parse(txtsotienthanhtoan.Text.Replace(",", "")) <= 0)
            {
                MessageBox.Show("Bạn phải nhập Thanh toán >0", "Hệ thống cảnh báo");
                txtsotienthanhtoan.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        public void XuLyString(string str1, string str2)
        {
            if (str1 == "Thu" && str2 == "Them")
            {
                this.Text = " Quản Lý Phiếu Thu Chi - Thêm Phiếu Thu";
                lbnguoinoptien.Text = "Người nộp tiền";
                tsslsua.Enabled = false;
            }
            if (str1 == "Thu" && str2 == "Sua")
            {
                this.Text = " Quản Lý Phiếu Thu Chi - Chi Tiết Phiếu Thu";
                lbnguoinoptien.Text = "Người nộp tiền";
                panel1.Enabled = false;
                tsslthemmoi.Enabled = false;
            }
            if (str1 == "Chi" && str2 == "Them")
            {
                this.Text = " Quản Lý Phiếu Thu Chi - Thêm Phiếu Chi";
                lbnguoinoptien.Text = "Người nhận tiền";
                tsslsua.Enabled = false;
            }
            if (str1 == "Chi" && str2 == "Sua")
            {
                this.Text = " Quản Lý Phiếu Thu Chi - Chi Tiết Phiếu Chi";
                panel1.Enabled = false;
                lbnguoinoptien.Text = "Người nhận tiền";
                tsslthemmoi.Enabled = false;

            }
        }
        /// <summary>
        /// xử lý khi nhập vào ô thanhtoan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtsotienthanhtoan_TextChanged(object sender, EventArgs e)
        {
            new TienIch().AutoFormatMoney(sender);
        }
        /// <summary>
        /// xử lý khi thay đổi kích cỡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXuLyPhieuThuChi_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// xử lý khi chọn tiền tệ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbtientetygia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int i = cbbtientetygia.SelectedIndex;
                if (i >= 0)
                {
                    for (int j = 0; j < tt.Length; j++)
                    {
                        if (tt[j].TenTienTe == cbbtientetygia.SelectedItem.ToString())
                        {
                            txttientetygia.Text = tt[j].DonViLamTron.ToString();
                            return;
                        }
                    }
                }
            }
            catch { }
        }

        private void tsslin_Click(object sender, EventArgs e)
        {
            timer1.Start();
            try
            {
                if (cbbloaichungtu.Text == "Thu")
                {
                    List<string> data = new List<string>();
                    data.Add(cbbnotaikhoan.Text);
                    data.Add(cbbcotaikhoan.Text);
                    data.Add(txtnguoinoptien.Text);
                    data.Add(lbhienthidiachi.Text);
                    data.Add(txtdiengiai.Text);
                    data.Add(txtsotienthanhtoan.Text.Replace(",", ""));
                    frmBaoCaorpt a = new frmBaoCaorpt("PhieuThu", data);
                    a.ShowDialog();
                }
                else
                {
                    List<string> data = new List<string>();
                    data.Add(cbbnotaikhoan.Text);
                    data.Add(cbbcotaikhoan.Text);
                    data.Add(txtnguoinoptien.Text);
                    data.Add(lbhienthidiachi.Text);
                    data.Add(txtdiengiai.Text);
                    data.Add(txtsotienthanhtoan.Text.Replace(",", ""));
                    frmBaoCaorpt a = new frmBaoCaorpt("PhieuChi", data);
                    a.ShowDialog();
                }
            }
            catch { }
            timer1.Stop();
        }
        int run = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                run++;
                if (run == 3)
                {
                    this.Close();
                }
            }
            catch { }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void txtdiengiai_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tsslthemmoi_Click(sender, e);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (xemlai)
                {
                    return;
                }
                if (cbbdoituong.Text != "Khach Hang" || !thuORchi || string.IsNullOrEmpty(txtdoituong.Text))
                {
                    checkBox1.Checked = false;
                    return;
                }
                //hiện combobox chọn mã thẻ cần thanh toán
                label1.Visible = checkBox1.Checked;
                comboBox1.Visible = checkBox1.Checked;
                if (!checkBox1.Checked)
                {
                    txtnguoinoptien.Text = "";
                    txtsotienthanhtoan.Text = "";
                    return;
                }
                //lấy dữ liệu
                LayTheGiamGia();
                LayChiTietTheGiamGia();
                comboBox1.Items.Clear();
                //cập nhật combobox những thẻ giá trị chưa thanh toán của vị khách hàng hiện tại
                foreach (Entities.TheGiamGia item in TGG)
                {
                    if (item.MaKhachHang.ToUpper().Equals(txtdoituong.Text.ToUpper()))
                    {
                        bool co = false;
                        foreach (Entities.ChiTietTheGiamGia item1 in CTTGG)
                        {
                            if (item.MaTheGiamGia.ToUpper().Equals(item1.MaTheGiamGia.ToUpper()))
                            {
                                co = true;
                                break;
                            }
                        }
                        if (!co)
                        {
                            comboBox1.Items.Add(item.MaTheGiamGia);
                            comboBox1.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                if (string.IsNullOrEmpty(comboBox1.Text))
                {
                    checkBox1.Checked = false;
                    label1.Visible = checkBox1.Checked;
                    comboBox1.Visible = checkBox1.Checked;
                    txtnguoinoptien.Text = "";
                    txtsotienthanhtoan.Text = "";
                    return;
                }
                //update người nộp tiền
                txtnguoinoptien.Text = lbhienthiten.Text;
                txtnguoinoptien.Focus();
                txtnguoinoptien.SelectAll();
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

        //Cập nhật trạng thái đã thanh toán của thẻ giá trị
        private bool CapNhatChiTietTheGiamGia()
        {
            try
            {
                Entities.ChiTietTheGiamGia input = new Entities.ChiTietTheGiamGia();
                input.ThaoTac = "insert";
                input.MaTheGiamGia = comboBox1.Text.ToUpper();
                input.MaKhachHang = txtdoituong.Text.ToUpper();
                input.TenKhachHang = LayTenKhachHang(txtdoituong.Text.ToUpper());
                LayTheGiamGia();
                foreach (Entities.TheGiamGia item in TGG)
                {
                    if (item.MaTheGiamGia.ToUpper().Equals(comboBox1.Text.ToUpper()))
                    {
                        input.GiaTriThe = double.Parse(item.GiaTriThe);
                    }
                }
                input.NgayThu = DateServer.Date();
                input.MaPhieuThu = txtsochungtu.Text.ToUpper();
                input.Deleted = false;

                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "ChiTietTheGiamGia", input);
                int msg = 0;
                msg = (int)cl.DeserializeHepper(clientstrem, msg);
                if (msg != 0)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        private string LayTenKhachHang(string maKH)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "KhachHang", new Entities.KhachHang("Select"));
                Entities.KhachHang[] KHACHHANG = new Entities.KhachHang[1];
                KHACHHANG = (Entities.KhachHang[])cl.DeserializeHepper1(clientstrem, KHACHHANG);
                if (KHACHHANG == null)
                    KHACHHANG = new Entities.KhachHang[0];
                foreach (Entities.KhachHang item in KHACHHANG)
                {
                    if (item.MaKH.ToUpper().Equals(maKH.ToUpper()))
                    {
                        return item.Ten;
                    }
                }
                return string.Empty;
            }
            catch { return string.Empty; }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(comboBox1.Text))
                {
                    foreach (Entities.TheGiamGia item in TGG)
                    {
                        if (item.MaTheGiamGia.ToUpper().Equals(comboBox1.Text.ToUpper()))
                        {
                            txtsotienthanhtoan.Text = new TienIch().FormatMoney(item.GiaTriThe.Replace(",", ""));
                        }
                    }
                }
            }
            catch { }
        }
    }
}
