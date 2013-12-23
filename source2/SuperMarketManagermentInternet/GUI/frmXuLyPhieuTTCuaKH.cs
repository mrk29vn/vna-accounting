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
using System.Collections;

namespace GUI
{
    public partial class frmXuLyPhieuTTCuaKH : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Entities.ChiTietPhieuTTCuaKH ctpttckh;
        DateTime dateserver;
        /// <summary>
        /// xử lý khi truyền giá trị tới
        /// </summary>
        public frmXuLyPhieuTTCuaKH()
        {
            InitializeComponent();
        }
        /// <summary>
        /// xử lý khi truyền giá trị tới
        /// </summary>
        /// <param name="hdbh"></param>
        public frmXuLyPhieuTTCuaKH(Entities.HDBanHang[] hdbh)
        {
            try
            {
                InitializeComponent();
                dateserver = DateServer.Date();
                sochungtu = txtsochungtu.Text = ProID("PhieuTTCuaKH");
                SelectHDBanHang();
                SelectKH();
                LayTenTT();
                this.Text = "Quản Lý Thanh Toán Của Khách Hàng - Thêm Phiếu Thanh Toán";
                txtmakh.Text = hdbh[0].MaKhachHang;
                txtnohienthoi.Text = LaySoDuNo(txtmakh.Text);

                cbbtientetygia.SelectedIndex = 0;
                Entities.HDThanhToanKH[] hd = new Entities.HDThanhToanKH[1];
                string tongtien = hdbh[0].TongTienThanhToan;
                string thanhtoanngay = hdbh[0].ThanhToanNgay;
                string thanhtoankhilapphieu = hdbh[0].ThanhToanKhiLapPhieu;
                string sono = (Convert.ToDouble(tongtien) - Convert.ToDouble(thanhtoanngay) - Convert.ToDouble(thanhtoankhilapphieu)).ToString();
                hd[0] = new Entities.HDThanhToanKH(hdbh[0].MaHDBanHang, tongtien, sono, sono, thanhtoankhilapphieu);
                dtgvpttKH.DataSource = hd;
                mskngaychungtu.Text = new Common.Utilities().XuLy(2, dateserver.ToShortDateString());
                txttongthanhtoan.Text = new Common.Utilities().FormatMoney(TinhTien());
            }
            catch
            {
            }
            finally
            {
                fix();
            }

        }
        public void fix()
        {
            dtgvpttKH.ReadOnly = true;
            dtgvpttKH.RowHeadersVisible = false;
            dtgvpttKH.Columns["MaHDBanHang"].HeaderText = "Mã Đơn Hàng";
            dtgvpttKH.Columns["TongTienThanhToan"].HeaderText = "Tổng Tiền Hóa Đơn";
            dtgvpttKH.Columns["SoNo"].HeaderText = "Số Tiền Nợ";
            dtgvpttKH.Columns["ThanhToan"].HeaderText = "Thanh Toán";
            dtgvpttKH.Columns["ThanhToanKhiLapPhieu"].Visible = false;
            dtgvpttKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvpttKH.AllowUserToAddRows = false;
            dtgvpttKH.AllowUserToDeleteRows = false;
            dtgvpttKH.AllowUserToResizeRows = false;
        }

        Entities.KhachHang[] hienthikh;
        /// <summary>
        /// select khách hàng
        /// </summary>
        public void SelectKH()
        {
            try
            {
                i = 0;
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
                int sotang = 0;
                for (int j = 0; j < kh1.Length; j++)
                {

                    if (kh1[j].Deleted == false)
                    {
                        pt2[sotang] = kh1[j];
                        sotang++;
                    }
                }
                hienthikh = new Entities.KhachHang[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthikh[j] = pt2[j];
                    }
                }
            }
            catch
            {
            }
            finally
            {


            }
        }
        /// <summary>
        /// lấy số dự nợ của khách hàng
        /// </summary>
        /// <param name="maKH"></param>
        /// <returns></returns>
        public string LaySoDuNo(string maKH)
        {
            try
            {
                for (int i = 0; i < hienthikh.Length; i++)
                {
                    if (hienthikh[i].MaKH == maKH)
                    {
                        return hienthikh[i].DuNo.ToString();
                    }
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        ///  xử lý giá trị truyền tới
        /// </summary>
        /// <param name="str1"></param>
        public frmXuLyPhieuTTCuaKH(string str1)
        {
            try
            {
                InitializeComponent();

                try
                {
                    LayTenTT();
                    cbbtientetygia.SelectedIndex = 0;
                    dateserver = DateServer.Date();
                }
                catch
                {
                }
                if (str1 == "Them")
                {
                    this.Text = "Quản Lý Thanh Toán Của Khách Hàng - Thêm Phiếu Thanh Toán";
                    sochungtu = txtsochungtu.Text = ProID("PhieuTTCuaKH");
                    mskngaychungtu.Text = new Common.Utilities().XuLy(2, dateserver.ToShortDateString());

                    dtgvpttKH.DataSource = new Entities.HDThanhToanKH[0];
                    fix();
                }
            }
            catch
            {
            }
        }
        string id;
        string sochungtu, nohienthoi, makh, datetime, tenkh, tientetygia, nguoinop, ghichu;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="dgvrc"></param>
        public frmXuLyPhieuTTCuaKH(string str1, DataGridViewRow dgvrc)
        {
            try
            {
                InitializeComponent();
                SelectHDBanHang();
                LayTenTT();
                if (str1 == "Sua")
                {
                    try
                    {
                        panel1.Enabled = panel2.Enabled = false;
                        this.Text = "Quản Lý Thanh Toán Của Khách Hàng - Chi Tiết Phiếu Thanh Toán";
                        tsslthemmoi.Enabled = false;
                        id = dgvrc.Cells["PhieuTTCuaKHID"].Value.ToString();
                        sochungtu = txtsochungtu.Text = dgvrc.Cells["MaPhieuTTCuaKH"].Value.ToString();
                        nohienthoi = txtnohienthoi.Text = dgvrc.Cells["NoHienThoi"].Value.ToString();
                        makh = txtmakh.Text = dgvrc.Cells["MaKhachHang"].Value.ToString();
                        datetime = mskngaychungtu.Text = new Common.Utilities().XuLy(2, (Convert.ToDateTime(dgvrc.Cells["NgayLap"].Value.ToString()).ToShortDateString()));
                        nguoinop = txtnguoinoptien.Text = dgvrc.Cells["NguoiNop"].Value.ToString();
                        tientetygia = dgvrc.Cells["MaTienTe"].Value.ToString();
                        cbbtientetygia.Text = LayTenTT(tientetygia);
                        ghichu = txtdiengiai.Text = dgvrc.Cells["GhiChu"].Value.ToString();
                        SelectData(txtsochungtu.Text);
                        txttongthanhtoan.Text = new Common.Utilities().FormatMoney(TinhTien());
                        panel1.Enabled = panel2.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            catch
            {
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
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.LayID lid = new Entities.LayID();
                clientstrem = cl.SerializeObj(this.client1, "LayID", lid1);
                // đổ mảng đối tượng vào datagripview       
                lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, ctpttckh);
                if (lid == null)
                    return "PTTKH_0001";
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            catch
            {
                return "";
            }
            finally
            {


            }
        }
        /// <summary>
        /// Tìm khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btntimkh_Click(object sender, EventArgs e)
        {
            try
            {
                frmTimKH tkh = new frmTimKH("PhieuTTCuaKH");
                tkh.ShowDialog();
                if (frmTimKH.drvr != null)
                {
                    txtmakh.Text = frmTimKH.drvr.Cells["MaKH"].Value.ToString();
                    lbtenkh.Text = frmTimKH.drvr.Cells["Ten"].Value.ToString();
                    txtnohienthoi.Text = String.Format("{0:0,0}", float.Parse(frmTimKH.drvr.Cells["DuNo"].Value.ToString()));
                    frmTimKH.drvr = null;
                    dtgvpttKH.DataSource = new Entities.HDThanhToanKH[0];
                    fix();
                }

            }
            catch
            {
            }
        }
        /// <summary>
        /// kiểm tra giá trị nhập vào
        /// </summary>
        /// <returns></returns>
        private bool Kiemtra()
        {
            if (txtmakh.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập Mã khách hàng", "Hệ thống cảnh báo");
                btntimkh.Focus();
                return false;
            }
            if (cbbtientetygia.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập Tiền tệ tỷ giá", "Hệ thống cảnh báo");
                cbbtientetygia.Focus();
                return false;
            }
            if (dtgvpttKH.DataSource == null)
            {
                MessageBox.Show("Bạn cần phải nhập Đơn hàng", "Hệ thống cảnh báo");
                return false;
            }
            if (dtgvpttKH.RowCount == 0)
            {
                MessageBox.Show("Bạn cần phải nhập Đơn hàng", "Hệ thống cảnh báo");
                return false;
            }
            return true;
        }
        /// <summary>
        /// đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssltrove_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    frmQuanLyPhieuThanhToanCuaKH.trave = "ok";
                    this.Close();
                }
            }
        }
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData(string maphieuKH)
        {
            try
            {
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ChiTietPhieuTTCuaKH pt = new Entities.ChiTietPhieuTTCuaKH("Select", maphieuKH);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.ChiTietPhieuTTCuaKH[] pt1 = new Entities.ChiTietPhieuTTCuaKH[1];
                clientstrem = cl.SerializeObj(this.client1, "ChiTietPhieuTTCuaKH", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.ChiTietPhieuTTCuaKH[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 == null)
                {
                    dtgvpttKH.DataSource = new Entities.HDThanhToanKH[0];
                    return;
                }

                Entities.HDThanhToanKH[] hhht = new Entities.HDThanhToanKH[pt1.Length];

                for (int j = 0; j < pt1.Length; j++)
                {
                    string mahd = pt1[j].MaHDBanHang;
                    string tongtien = pt1[j].TongTien;//LayTongTien(mahd);
                    string soNo = pt1[j].TienNo;
                    string thanhtoanngay = pt1[j].ThanhToan.ToString();//LayThanhToanNgay(mahd);
                    string thanhtoanngaysaukhilapphieu = ThanhToanKhiLapPhieu(mahd);
                    string conphaitra = (Convert.ToDouble(tongtien) - Convert.ToDouble(thanhtoanngay)).ToString();
                    hhht[j] = new Entities.HDThanhToanKH(mahd, new Common.Utilities().FormatMoney(Convert.ToDouble(tongtien)), new Common.Utilities().FormatMoney(Convert.ToDouble(soNo)), new Common.Utilities().FormatMoney(Convert.ToDouble(thanhtoanngay)));
                }
                dtgvpttKH.DataSource = hhht;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                fix();
            }
        }
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
            finally
            {


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
            }
            catch
            {
            }
            return "";
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
        /// lấy tổng tiền
        /// </summary>
        /// <param name="maHDBanHang"></param>
        /// <returns></returns>
        public string LayTongTien(string maHDBanHang)
        {
            try
            {
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (hienthi[i].MaHDBanHang == maHDBanHang)
                        return hienthi[i].TongTienThanhToan;
                }
                return "0";
            }
            catch
            {
                return "0";
            }
        }
        public string ThanhToanKhiLapPhieu(string maHDBanHang)
        {
            try
            {
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (hienthi[i].MaHDBanHang == maHDBanHang)
                        return hienthi[i].ThanhToanKhiLapPhieu;
                }
                return "0";
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// lấy thanh toán ngay của hóa đơn bán hàng
        /// </summary>
        /// <param name="maHDBanHang"></param>
        /// <returns></returns>
        public string LayThanhToanNgay(string maHDBanHang)
        {
            try
            {
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (hienthi[i].MaHDBanHang == maHDBanHang)
                        return hienthi[i].ThanhToanNgay;
                }
                return "0";
            }
            catch
            {
                return "0";
            }
        }
        Entities.HDBanHang[] hienthi;
        /// <summary>
        /// select hóa đơn bán hàng
        /// </summary>
        public void SelectHDBanHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.HDBanHang pt = new Entities.HDBanHang("Select");
                Entities.HDBanHang[] pt1 = new Entities.HDBanHang[1];
                clientstrem = cl.SerializeObj(this.client1, "HDBanHang", pt);
                pt1 = (Entities.HDBanHang[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 == null)
                {
                    hienthi = new Entities.HDBanHang[0];
                }

                Entities.HDBanHang[] pt2 = new Entities.HDBanHang[pt1.Length];
                int sotang = 0;
                for (int j = 0; j < pt1.Length; j++)
                {
                    if (pt1[j].LoaiHoaDon == false && pt1[j].Deleted == false)
                    {
                        pt2[sotang] = pt1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.HDBanHang[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = pt2[j];
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {


            }
        }
        /// <summary>
        /// tính tiền
        /// </summary>
        /// <returns></returns>
        public double TinhTien()
        {
            try
            {
                double thanhtien = 0;
                for (int i = 0; i < dtgvpttKH.RowCount; i++)
                {
                    thanhtien += double.Parse(dtgvpttKH["ThanhToan", i].Value.ToString());
                }
                return thanhtien;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        /// <summary>
        /// chọn tiền tệ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbtientetygia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cbbtientetygia.SelectedIndex;
            if (i >= 0)
            {
                for (int j = 0; j < tt.Length; j++)
                {
                    if (tt[j].MaTienTe == tt[i].MaTienTe)
                        txttientetygia.Text = tt[j].DonViLamTron.ToString();
                }
            }
        }
        bool kt = false;
        /// <summary>
        /// kiểm tra trước khi insert
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
                Entities.PhieuTTCuaKH pt = new Entities.PhieuTTCuaKH("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.PhieuTTCuaKH[] pt1 = new Entities.PhieuTTCuaKH[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuTTCuaKH", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.PhieuTTCuaKH[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 != null)
                {
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        if (pt1[j].MaPhieuTTCuaKH == sochungtu)
                        {
                            MessageBox.Show("cập nhật mã phiếu - kiểm tra lại để insert", "Hệ thống cảnh báo");
                            kt = false;
                            sochungtu = txtsochungtu.Text = ProID("PhieuTTCuaKH");
                            break;
                        }
                        else
                            kt = true;
                    }
                }
            }
            catch (Exception ex)
            {
                kt = false;
            }
            finally
            {


            }
        }
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
                Entities.PhieuTTCuaKH pt = new Entities.PhieuTTCuaKH("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.PhieuTTCuaKH[] pt1 = new Entities.PhieuTTCuaKH[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuTTCuaKH", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.PhieuTTCuaKH[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 != null)
                {
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        if (pt1[j].MaPhieuTTCuaKH == sochungtu)
                        {
                            kt = Check(pt1[j]);
                            break;
                        }
                        else
                            kt = true;
                    }
                }
            }
            catch (Exception ex)
            {
                kt = false;
            }
            finally
            {


            }
        }
        /// <summary>
        /// kiểm tra dữ liệu nhập vào
        /// </summary>
        /// <param name="pttckh"></param>
        /// <returns></returns>
        public bool Check(Entities.PhieuTTCuaKH pttckh)
        {
            bool gt = true;
            string datetimenew = new Common.Utilities().XuLy(2, (Convert.ToDateTime(pttckh.NgayLap).ToShortDateString()));
            if (datetime != datetimenew)
            {
                datetime = mskngaychungtu.Text = datetimenew;
                gt = false;
            }
            if (makh != pttckh.MaKhachHang)
            {
                makh = txtmakh.Text = pttckh.MaKhachHang;
                gt = false;
            }
            if (nohienthoi != pttckh.NoHienThoi)
            {
                nohienthoi = txtnohienthoi.Text = pttckh.NoHienThoi;
                gt = false;
            }
            if (nguoinop != pttckh.NguoiNop)
            {
                nguoinop = txtnguoinoptien.Text = pttckh.NguoiNop;
                gt = false;
            }
            if (tientetygia != pttckh.MaTienTe)
            {
                tientetygia = pttckh.MaTienTe;
                cbbtientetygia.Text = LayTenTT(tientetygia);
                txttientetygia.Text = LayDonViTT(tientetygia);
                gt = false;
            }
            if (ghichu != pttckh.GhiChu)
            {
                ghichu = txtdiengiai.Text = pttckh.GhiChu;
                gt = false;
            }
            return gt;
        }
        /// <summary>
        /// update dư nợ của khách hàng
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
            catch (Exception ex)
            {
                return false;
            }
            finally
            {


            }
        }
        /// <summary>
        /// kiểm tra dtgv trước khi update
        /// </summary>
        /// <param name="dgv"></param>
        public bool CheckDataGridUpdate(DataGridView dgv)
        {
            bool kkt = false;
            try
            {
                if (dgv.RowCount != 0)
                {
                    Entities.HDBanHang[] cthdbh = new Entities.HDBanHang[dgv.RowCount];
                    for (int j = 0; j < cthdbh.Length; j++)
                    {
                        double tongtien = Convert.ToDouble(dgv[1, j].Value.ToString());
                        //double sotienno = Convert.ToDouble(dgv[2, j].Value.ToString());
                        double sothanhtoan = Convert.ToDouble(dgv["ThanhToan", j].Value.ToString());
                        //double thanhtoankhilap = Convert.ToDouble(dgv[4, j].Value.ToString());
                        //string sotiendathanhtoan = (sothanhtoan+thanhtoankhilap).ToString();
                        cthdbh[j] = new Entities.HDBanHang("Update", dgv[0, j].Value.ToString(), sothanhtoan.ToString());
                    }
                    kkt = InsertMang(cthdbh);
                    return kkt;
                }
                return kkt;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// insert mảng
        /// </summary>
        /// <param name="cthdbh"></param>
        public bool InsertMang(Entities.HDBanHang[] cthdbh)
        {

            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "HDBanHangMang", cthdbh);
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                return kt;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Thêm mới
        /// </summary>
        Server_Client.Client cl;
        string duno = "0";
        private void tsslthemmoi_Click_1(object sender, EventArgs e)
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
                        string date = "";
                        try
                        {
                            date = new Common.Utilities().MyDateConversion(mskngaychungtu.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Bạn nhập sai định dạng ngày tháng", "Hệ thống cảnh báo");
                            return;
                        }
                        Entities.PhieuTTCuaKH pt = new Entities.PhieuTTCuaKH();
                        string matt = LayMaTT(cbbtientetygia.Text);
                        pt = new Entities.PhieuTTCuaKH("Insert", 0, txtsochungtu.Text, DateTime.Parse(date), txtmakh.Text, txtnohienthoi.Text,
                            txtnguoinoptien.Text, matt, txtdiengiai.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);

                        clientstrem = cl.SerializeObj(this.client1, "PhieuTTCuaKH", pt);
                        bool kt1 = false;
                        kt1 = (bool)cl.DeserializeHepper(clientstrem, kt);
                        if (kt1 == true)
                        {
                            if (CheckDataGridInsert(dtgvpttKH) == true)
                            {
                                if (double.Parse(txttongthanhtoan.Text) != 0)
                                {
                                    //duno = (Convert.ToDouble(txtnohienthoi.Text) - Convert.ToDouble(txttongthanhtoan.Text)).ToString();
                                    duno = (Convert.ToDouble(txttongthanhtoan.Text)).ToString();
                                    Entities.KhachHang kh = new Entities.KhachHang("UpdateDuNoKH", txtmakh.Text, duno);
                                    if (UpdateDuNo(kh) == true)
                                    {
                                        if (CheckDataGridUpdate(dtgvpttKH) == true)
                                        {

                                        }
                                        else
                                            MessageBox.Show("Lỗi trong quá trình sửa thanh toán ngay", "Hệ thống cảnh báo");
                                    }
                                    else
                                        MessageBox.Show("Lỗi trong quá trình sửa dư nợ khách hàng", "Hệ thống cảnh báo");
                                }
                            }
                            else
                                MessageBox.Show("Lỗi trong quá trình thêm hóa đơn vào chi tiết", "Hệ thống cảnh báo");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại - xin hãy thử lại", "Hệ thống cảnh báo");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu đã bị thay đổi - kiểm tra lại", "Hệ thống cảnh báo");
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.Enabled = true;

            }

        }
        /// <summary>
        /// kiểm tra dtgv trước khi insert
        /// </summary>
        /// <param name="dgv"></param>
        public bool CheckDataGridInsert(DataGridView dgv)
        {
            bool kkt = false;
            try
            {
                if (dgv.RowCount != 0)
                {
                    Entities.ChiTietPhieuTTCuaKH[] ctxh2 = new Entities.ChiTietPhieuTTCuaKH[dgv.RowCount];
                    for (int j = 0; j < ctxh2.Length; j++)
                    {
                        ctxh2[j] = new Entities.ChiTietPhieuTTCuaKH("Insert", dgv["MaHDBanHang", j].Value.ToString(), txtsochungtu.Text, float.Parse(dgv["ThanhToan", j].Value.ToString()), true, "", false, dgv["TongTienThanhToan", j].Value.ToString(), dgv["SoNo", j].Value.ToString());
                    }
                    kkt = InsertMang(ctxh2);
                    return kkt;
                }
                return kkt;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// insert mảng
        /// </summary>
        /// <param name="ctxh"></param>
        public bool InsertMang(Entities.ChiTietPhieuTTCuaKH[] ctxh)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "ChiTietPhieuTTCuaKHMang", ctxh);
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                return kt;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslsua_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Kiemtra() == true)
                {
                    CheckConflictUpdate();
                    dateserver = DateServer.Date();
                    if (kt == true)
                    {
                        cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        string date = new Common.Utilities().MyDateConversion(mskngaychungtu.Text);
                        Entities.PhieuTTCuaKH pt = new Entities.PhieuTTCuaKH();
                        string matt = LayMaTT(cbbtientetygia.Text);
                        pt = new Entities.PhieuTTCuaKH("Update", int.Parse(id), txtsochungtu.Text, DateTime.Parse(date), txtmakh.Text, txtnohienthoi.Text, txtnguoinoptien.Text, matt, txtdiengiai.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);

                        clientstrem = cl.SerializeObj(this.client1, "PhieuTTCuaKH", pt);
                        bool kt1 = false;
                        kt1 = (bool)cl.DeserializeHepper(clientstrem, kt);
                        if (kt1 == true)
                        {
                            this.Close();
                        }

                    }
                    else
                        MessageBox.Show("Dữ liệu đã bị thay đổi - Kiểm tra lại", "Hệ thống cảnh báo");
                }
            }
            catch
            {
            }
            finally
            {


            }
        }
        /// <summary>
        /// xử lý khi thay đổi kích cỡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXuLyPhieuTTCuaKH_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        Entities.HDThanhToanKH[] hh;
        string mahdbh;
        string thanhtoankhilapphieu = "";
        /// <summary>
        /// xử lý khi ấn phím xuống
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_txtTracuu_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F4)
                {
                    if (txtmakh.Text.Length != 0)
                    {
                        frmTimHDBanHang fr = new frmTimHDBanHang(txtmakh.Text, "");
                        fr.ShowDialog();
                        if (frmTimHDBanHang.drvr != null)
                        {
                            mahdbh = toolStrip_txtTracuu.Text = frmTimHDBanHang.drvr.Cells["MaHDBanHang"].Value.ToString();
                            tssltongthanhtoan.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(frmTimHDBanHang.drvr.Cells["TongTienThanhToan"].Value.ToString()));
                            thanhtoankhilapphieu = frmTimHDBanHang.drvr.Cells["ThanhToanKhiLapPhieu"].Value.ToString();
                            string sono = (Convert.ToDouble(tssltongthanhtoan.Text) - double.Parse(thanhtoankhilapphieu) - Convert.ToDouble(frmTimHDBanHang.drvr.Cells["ThanhToanNgay"].Value.ToString())).ToString();
                            tsslsono.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(sono));
                            tsslthanhtoan.Text = sono;
                            tsslthanhtoan.Focus();
                            frmTimHDBanHang.drvr = null;
                        }
                    }
                    else
                        MessageBox.Show("Bạn hãy nhập Mã Khách Hàng");
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtmakh.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn cần phải nhập Mã Khách Hàng", "Hệ thống cảnh báo");
                        btntimkh.Focus();
                        return;
                    }
                    try
                    {
                        if (Convert.ToDouble(tssltongthanhtoan.Text) <= 0)
                        {
                            MessageBox.Show("Chưa có tiền thanh toán", "Hệ thống cảnh báo");
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Chưa có tiền thanh toán", "Hệ thống cảnh báo");
                        return;
                    }
                    NewRow();
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// thêm mới row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmakh.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập Mã khách hàng", "Hệ thống cảnh báo");
                    btntimkh.Focus();
                    return;
                }
                if (Convert.ToDouble(tssltongthanhtoan.Text) <= 0)
                {
                    MessageBox.Show("Chưa có tiền thanh toán", "Hệ thống cảnh báo");
                    return;
                }
                NewRow();
            }
            catch
            {
            }
        }
        /// <summary>
        /// xử lý khi thêm row
        /// </summary>
        public void NewRow()
        {
            try
            {

                int sohangtrongbang = dtgvpttKH.RowCount;
                if (dtgvpttKH.RowCount != 0)
                {
                    for (int j = 0; j < dtgvpttKH.RowCount; j++)
                    {
                        if (mahdbh == dtgvpttKH[0, j].Value.ToString())
                        {
                            MessageBox.Show("Hóa đơn đã tồn tại rồi - hãy kiểm tra lại", "Hệ thống cảnh báo");
                            return;
                        }
                        else
                            hh = new Entities.HDThanhToanKH[sohangtrongbang + 1];
                    }
                }
                else
                    hh = new Entities.HDThanhToanKH[sohangtrongbang + 1];

                if (hh.Length != 0)
                {
                    try
                    {
                        for (int j = 0; j < hh.Length; j++)
                        {
                            if (j < hh.Length - 1)
                                hh[j] = new Entities.HDThanhToanKH(dtgvpttKH[0, j].Value.ToString(), dtgvpttKH[1, j].Value.ToString(), dtgvpttKH[2, j].Value.ToString(), dtgvpttKH[3, j].Value.ToString(), dtgvpttKH[4, j].Value.ToString());
                            else
                                hh[hh.Length - 1] = new Entities.HDThanhToanKH(toolStrip_txtTracuu.Text, new Common.Utilities().FormatMoney(Convert.ToDouble(tssltongthanhtoan.Text)), new Common.Utilities().FormatMoney(Convert.ToDouble(tsslsono.Text)), new Common.Utilities().FormatMoney(Convert.ToDouble(tsslthanhtoan.Text)), thanhtoankhilapphieu);
                        }
                    }
                    catch (Exception ex)
                    {
                        hh[0] = new Entities.HDThanhToanKH(toolStrip_txtTracuu.Text, new Common.Utilities().FormatMoney(Convert.ToDouble(tssltongthanhtoan.Text)), new Common.Utilities().FormatMoney(Convert.ToDouble(tsslsono.Text)), new Common.Utilities().FormatMoney(Convert.ToDouble(tsslthanhtoan.Text)), thanhtoankhilapphieu);
                    }
                    dtgvpttKH.DataSource = hh;
                    txttongthanhtoan.Text = new Common.Utilities().FormatMoney(TinhTien());
                }
            }
            catch
            {
            }
            finally
            {
                fix();
                toolStrip_txtTracuu.Text = "<F4 - Tra Cứu>";
                tssltongthanhtoan.Text = tsslsono.Text = tsslthanhtoan.Text = "";
            }
        }

        int i;
        /// <summary>
        /// xử lý khi click vào tra cứu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_txtTracuu_Click(object sender, EventArgs e)
        {
            toolStrip_txtTracuu.Text = "";
            tssltongthanhtoan.Text = tsslsono.Text = tsslthanhtoan.Text = "";
        }
        /// <summary>
        /// xử lý khi gõ phím vào control thanhtoan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslthanhtoan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                new TienIch().AutoFormat(sender, false, true);
            }
            catch
            {
                tsslthanhtoan.Text = "";
            }
        }
        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXuLyPhieuTTCuaKH_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// xử lý khi ấn phím
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssltongthanhtoan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtmakh.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập Mã khách hàng", "Hệ thống cảnh báo");
                    btntimkh.Focus();
                    return;
                }
                if (Convert.ToDouble(tssltongthanhtoan.Text) <= 0)
                {
                    MessageBox.Show("Chưa có tiền thanh toán", "Hệ thống cảnh báo");
                    return;
                }
                NewRow();
            }
        }
        private void dtgvpttKH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (i < 0)
                return;
            try
            {

                if (dtgvpttKH.RowCount > 1)
                {
                    mahdbh = toolStrip_txtTracuu.Text = dtgvpttKH[0, i].Value.ToString();
                    tssltongthanhtoan.Text = dtgvpttKH[1, i].Value.ToString();
                    tsslsono.Text = dtgvpttKH[2, i].Value.ToString();
                    tsslthanhtoan.Text = dtgvpttKH[3, i].Value.ToString();
                    thanhtoankhilapphieu = dtgvpttKH[4, i].Value.ToString();
                    hh = new Entities.HDThanhToanKH[dtgvpttKH.RowCount - 1];
                    int so = 0;
                    for (int j = 0; j < dtgvpttKH.RowCount; j++)
                    {
                        if (dtgvpttKH[0, j].Value.ToString() != dtgvpttKH[0, i].Value.ToString())
                        {
                            hh[so] = new Entities.HDThanhToanKH(dtgvpttKH[0, j].Value.ToString(), dtgvpttKH[1, j].Value.ToString(), dtgvpttKH[2, j].Value.ToString(), dtgvpttKH[3, j].Value.ToString(), dtgvpttKH[4, j].Value.ToString());
                            so++;
                        }
                    }
                    dtgvpttKH.DataSource = hh;
                    txttongthanhtoan.Text = new Common.Utilities().FormatMoney(TinhTien());
                }
                else
                {
                    mahdbh = toolStrip_txtTracuu.Text = dtgvpttKH[0, i].Value.ToString();
                    tssltongthanhtoan.Text = dtgvpttKH[1, i].Value.ToString();
                    tsslsono.Text = dtgvpttKH[2, i].Value.ToString();
                    tsslthanhtoan.Text = dtgvpttKH[3, i].Value.ToString();
                    thanhtoankhilapphieu = dtgvpttKH[4, i].Value.ToString();
                    dtgvpttKH.DataSource = new Entities.HDThanhToanKH[0];
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                fix();
                txttongthanhtoan.Text = new Common.Utilities().FormatMoney(TinhTien());
            }
        }

        private void dtgvpttKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void tsslthanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                tsslthanhtoan.Text = String.Format("{0:0}", Convert.ToDouble(tsslthanhtoan.Text));
            }
            catch
            {
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

        Entities.KhachHang laykhachhang(string maKH)
        {
            Entities.KhachHang tem = new Entities.KhachHang();
            if (hienthikh == null)
            {
                SelectKH();
            }
            if (hienthikh.Length > 0)
            {
                foreach (Entities.KhachHang item in hienthikh)
                {
                    if (item.MaKH.Equals(maKH))
                    {
                        tem = item;
                        break;
                    }
                }
            }
            return tem;
        }

        private void tsslin_Click(object sender, EventArgs e)
        {
            //timer1.Start();
            try
            {
                ArrayList dulieu = new ArrayList();
                Entities.HDThanhToanKH[] tem = new Entities.HDThanhToanKH[0];
                tem = (Entities.HDThanhToanKH[])dtgvpttKH.DataSource;
                if (tem.Length > 0)
                {
                    List<Entities.BCPhieuTTCuaKH> tem1 = new List<Entities.BCPhieuTTCuaKH>();
                    foreach (Entities.HDThanhToanKH item in tem)
                    {
                        Entities.BCPhieuTTCuaKH bientam = new Entities.BCPhieuTTCuaKH();
                        bientam.MaDonHang = item.MaHDBanHang;
                        bientam.TongTienHoaDon = double.Parse(item.TongTienThanhToan.Replace(",", ""));
                        bientam.SoTienNo = double.Parse(item.SoNo.Replace(",", ""));
                        bientam.ThanhToan = double.Parse(item.ThanhToan.Replace(",", ""));
                        tem1.Add(bientam);
                    }
                    Entities.KhachHang kh = new Entities.KhachHang(); kh = laykhachhang(txtmakh.Text);
                    dulieu.Add(tem1);    //dữ liệu trong datagridview   (0)
                    dulieu.Add(txtsochungtu.Text);   //Mã phiếu (1)
                    dulieu.Add(kh.Ten); //Tên khách hàng    (2)
                    dulieu.Add(kh.DiaChi);   //Địa chỉ (3)
                    dulieu.Add(txtnguoinoptien.Text);   //Người nộp tiền   (4)
                    dulieu.Add(txtdiengiai.Text);   //Diễn giải   (5)
                    dulieu.Add(txttongthanhtoan.Text);   //Tổng thanh toán   (6)
                    frmBaoCaorpt a = new frmBaoCaorpt("InPhieuThanhToanCuaKH", dulieu);
                    a.ShowDialog();
                }
                else
                {
                    MessageBox.Show("");
                }
            }
            catch
            {
            }
            //timer1.Stop();
        }

        //int run = 0;
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    //
        //}
    }
}
