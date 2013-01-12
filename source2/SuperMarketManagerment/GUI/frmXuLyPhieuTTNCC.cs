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
    public partial class frmXuLyPhieuTTNCC : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Entities.ChiTietPhieuTTNCC ctpttncc;
        DateTime dateserver;
        public frmXuLyPhieuTTNCC()
        {
            InitializeComponent();
        }
        /// <summary>
        ///  xử lý giá trị truyền tới
        /// </summary>
        /// <param name="hdbh"></param>
        public frmXuLyPhieuTTNCC(Entities.HoaDonNhap[] hdbh)
        {
            try
            {
                InitializeComponent();
                dateserver = DateServer.Date();
                sochungtu = txtsochungtu.Text = ProID("PhieuTTNCC");
                SelectHoaDonNhap();
                SelectNCC();
                LayTenTT();
                this.Text = "Quản Lý Thanh Toán Của Nhà Cung Cấp - Thêm Phiếu Thanh Toán";
                txtmancc.Text = hdbh[0].MaNhaCungCap;
                txtnohienthoi.Text = LaySoDuNo(txtmancc.Text);
                
                cbbtientetygia.SelectedIndex = 0;
                Entities.HDThanhToanKH[] hd = new Entities.HDThanhToanKH[1];
                Double tongtien = Convert.ToDouble(hdbh[0].TongTien);
                string thanhtoanngay = hdbh[0].ThanhToanNgay;
                thanhtoansaukhilapphieu = hdbh[0].ThanhToanSauKhiLapPhieu;
                Double sono = Convert.ToDouble(tongtien) - Convert.ToDouble(thanhtoanngay) - Convert.ToDouble(thanhtoansaukhilapphieu);
                hd[0] = new Entities.HDThanhToanKH(hdbh[0].MaHoaDonNhap,  new Common.Utilities().FormatMoney(tongtien), new Common.Utilities().FormatMoney(sono), new Common.Utilities().FormatMoney(sono),thanhtoansaukhilapphieu);
                dtgvNCC.DataSource = hd;
                mskngaychungtu.Text = new Common.Utilities().XuLy(2,dateserver.ToShortDateString());
                txttongthanhtoan.Text = new Common.Utilities().FormatMoney(TinhTien());
                fix();
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        /// <param name="str1"></param>
        public frmXuLyPhieuTTNCC(string str1)
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
                    this.Text = "Quản Lý Phiếu Thanh Toán Nhà Cung Cấp - Chi Tiết Phiếu Thanh Toán";
                    tsslsua.Enabled = false;
                    sochungtu = txtsochungtu.Text = ProID("PhieuTTNCC");
                    mskngaychungtu.Text = new Common.Utilities().XuLy(2,dateserver.ToShortDateString());

                    dtgvNCC.DataSource = new Entities.HDThanhToanKH[0];
                    fix();
                }
            }
            catch
            {

            }

        }

        Entities.NhaCungCap[] hienthikh;
        /// <summary>
        /// select nhà cung câps
        /// </summary>
        public void SelectNCC()
        {
            try
            {
                i = 0;
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
                int sotang = 0;
                for (int j = 0; j < kh1.Length; j++)
                {

                    if (kh1[j].Deleted == false)
                    {
                        pt2[sotang] = kh1[j];
                        sotang++;
                    }
                }
                hienthikh = new Entities.NhaCungCap[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthikh[j] = pt2[j];
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// lấy dự nợ của nhà cung cấp
        /// </summary>
        /// <param name="maNCC"></param>
        /// <returns></returns>
        public string LaySoDuNo(string maNCC)
        {
            try
            {
                for (int i = 0; i < hienthikh.Length; i++)
                {
                    if (hienthikh[i].MaNhaCungCap == maNCC)
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
        public string LayThanhToanNgaySauKhiLapPhieu(string maHoaDonNhap)
        {
            try
            {
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (hienthi[i].MaHoaDonNhap == maHoaDonNhap)
                        return hienthi[i].ThanhToanSauKhiLapPhieu;
                }
                return "0";

            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        /// <summary>
        /// lấy thanh toán ngay của hóa đơn nhập
        /// </summary>
        /// <param name="maHDBanHang"></param>
        /// <returns></returns>
        public string LayThanhToanNgay(string maHoaDonNhap)
        {
            try
            {
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (hienthi[i].MaHoaDonNhap == maHoaDonNhap)
                        return hienthi[i].ThanhToanNgay;
                }
                return "0";

            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        /// <summary>
        /// lấy tổng tiền thanh toán
        /// </summary>
        /// <param name="maHoaDonNhap"></param>
        /// <returns></returns>
        public string LayTongTien(string maHoaDonNhap)
        {
            try
            {
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (hienthi[i].MaHoaDonNhap == maHoaDonNhap)
                        return hienthi[i].TongTien;
                }
                return "0";
            }
            catch (Exception ex)
            {
                return "0";
            }
        }

        string id;
        string sochungtu, nohienthoi, mancc, datetime, nguoinhantien, tientetygia, ghichu;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="dtgvr"></param>
        public frmXuLyPhieuTTNCC(string str1, DataGridViewRow dtgvr)
        {
            try
            {
                InitializeComponent();
                SelectHoaDonNhap();
                LayTenTT();
                if (str1 == "Sua")
                {
                    this.Text = "Quản Lý Phiếu Thanh Toán Nhà Cung Cấp - Sửa Phiếu Thanh Toán";
                    tsslthem.Enabled = panel1.Enabled = panel2.Enabled = false;
                    id = dtgvr.Cells["PhieuTTNCCID"].Value.ToString();
                    sochungtu = txtsochungtu.Text = dtgvr.Cells["MaPhieuTTNCC"].Value.ToString();
                    datetime = mskngaychungtu.Text = new Common.Utilities().XuLy(2, (Convert.ToDateTime(dtgvr.Cells["NgayLap"].Value.ToString()).ToShortDateString()));
                    mancc = txtmancc.Text = dtgvr.Cells["MaNCC"].Value.ToString();
                    nohienthoi = txtnohienthoi.Text = String.Format("{0:0,0}", Convert.ToDouble(dtgvr.Cells["NoHienThoi"].Value.ToString()));
                    nguoinhantien = txtnguoinhaptien.Text = dtgvr.Cells["Nguoinhan"].Value.ToString();
                    tientetygia = dtgvr.Cells["MaTienTe"].Value.ToString();
                    cbbtientetygia.Text = LayTenTT(tientetygia);
                    LayDonViTT(cbbtientetygia.Text);
                    ghichu = txtdiengiai.Text = dtgvr.Cells["GhiChu"].Value.ToString();
                    SelectData(txtsochungtu.Text);
                    txttongthanhtoan.Text = new Common.Utilities().FormatMoney(TinhTien());
                }
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData(string maphieuncc)
        {
            try
            {
                dtgvNCC.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ChiTietPhieuTTNCC ptpttncc = new Entities.ChiTietPhieuTTNCC("Select", maphieuncc);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.ChiTietPhieuTTNCC[] ptpttncc1 = new Entities.ChiTietPhieuTTNCC[1];
                clientstrem = cl.SerializeObj(this.client1, "ChiTietPhieuTTNCC", ptpttncc);
                // đổ mảng đối tượng vào datagripview       
                ptpttncc1 = (Entities.ChiTietPhieuTTNCC[])cl.DeserializeHepper1(clientstrem, ptpttncc1);

                if (ptpttncc1 == null)
                {
                    dtgvNCC.DataSource = new Entities.HDThanhToanKH[0];
                    return;
                }

                Entities.HDThanhToanKH[] hhht = new Entities.HDThanhToanKH[ptpttncc1.Length];

                for (int j = 0; j < ptpttncc1.Length; j++)
                {
                    string mahd = ptpttncc1[j].MaHoaDonNhap;
                    string tongtien = ptpttncc1[j].TongTien;//LayTongTien(mahd);
                    string soNo = ptpttncc1[j].TienNo;
                    string thanhtoanngay = ptpttncc1[j].ThanhToan.ToString();//LayThanhToanNgay(mahd);
                    string thanhtoanngaysaukhilapphieu = LayThanhToanNgaySauKhiLapPhieu(mahd);
                    string conphaitra = (Convert.ToDouble(tongtien) - Convert.ToDouble(thanhtoanngay)).ToString();
                    hhht[j] = new Entities.HDThanhToanKH(mahd, new Common.Utilities().FormatMoney(Convert.ToDouble(tongtien)),  new Common.Utilities().FormatMoney(Convert.ToDouble(soNo)),  new Common.Utilities().FormatMoney(Convert.ToDouble(ptpttncc1[j].ThanhToan)));
                }
                dtgvNCC.DataSource = hhht;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                fix();
            }
        }
        public void fix()
        {
            dtgvNCC.ReadOnly = true;
            dtgvNCC.RowHeadersVisible = false;
            dtgvNCC.Columns["MaHDBanHang"].HeaderText = "Mã Đơn Hàng";
            dtgvNCC.Columns["TongTienThanhToan"].HeaderText = "Tổng Tiền Hóa Đơn";
            dtgvNCC.Columns["SoNo"].HeaderText = "Số Tiền Nợ";
            dtgvNCC.Columns["ThanhToan"].HeaderText = "Thanh Toán";
            dtgvNCC.Columns["ThanhToanKhiLapPhieu"].Visible = false;
            dtgvNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvNCC.AllowUserToAddRows = false;
            dtgvNCC.AllowUserToDeleteRows = false;
            dtgvNCC.AllowUserToResizeRows = false;
        }
        Entities.HoaDonNhap[] hienthi;
        /// <summary>
        /// select hóa đơn nhập
        /// </summary>
        public void SelectHoaDonNhap()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.HoaDonNhap pt = new Entities.HoaDonNhap("Select");
                Entities.HoaDonNhap[] pt1 = new Entities.HoaDonNhap[1];
                clientstrem = cl.SerializeObj(this.client1, "HDN", pt);
                pt1 = (Entities.HoaDonNhap[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 == null)
                {
                    hienthi = new Entities.HoaDonNhap[0];
                }

                Entities.HoaDonNhap[] pt2 = new Entities.HoaDonNhap[pt1.Length];
                int sotang = 0;
                for (int j = 0; j < pt1.Length; j++)
                {
                    if (pt1[j].Deleted == false)
                    {
                        pt2[sotang] = pt1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.HoaDonNhap[sotang];
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
        /// tìm khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btntimkh_Click(object sender, EventArgs e)
        {
            frmTimNCC tncc = new frmTimNCC();
            tncc.ShowDialog();
        }
        /// <summary>
        /// lấy giá trị id cuối cùng
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
                lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, ctpttncc);
                if (lid == null)
                    return "PTTNCC_0001";
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
        /// nút trở về
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssltrove_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    frmQuanLyPhieuThu.trave = "ok";
                    this.Close();
                }
                else
                { }
            }
        }
        /// <summary>
        /// kiểm tra giá trị đầu vào
        /// </summary>
        /// <returns></returns>
        private bool Kiemtra()
        {
            if (txtmancc.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập Mã nhân viên", "Hệ thống cảnh báo");
                btntimkh.Focus();
                return false;
            }
            if (cbbtientetygia.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập Tiền tệ tỷ giá", "Hệ thống cảnh báo");
                cbbtientetygia.Focus();
                return false;
            }

            if (dtgvNCC.DataSource == null)
            {
                MessageBox.Show("Bạn cần phải Đơn hàng cần thanh toán", "Hệ thống cảnh báo");
                return false;
            }
            if (dtgvNCC.RowCount == 0)
            {
                MessageBox.Show("Bạn cần phải Đơn hàng cần thanh toán", "Hệ thống cảnh báo");
                return false;
            }
            return true;
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
                Entities.PhieuTTNCC pt = new Entities.PhieuTTNCC("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.PhieuTTNCC[] pt1 = new Entities.PhieuTTNCC[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuTTNCC", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.PhieuTTNCC[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 != null)
                {
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        if (pt1[j].MaPhieuTTNCC == sochungtu)
                        {
                            MessageBox.Show("cập nhật mã phiếu - kiểm tra lại để insert");
                            kt = false;
                            sochungtu = txtsochungtu.Text = ProID("PhieuTTNCC");
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
                Entities.PhieuTTNCC pt = new Entities.PhieuTTNCC("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.PhieuTTNCC[] pt1 = new Entities.PhieuTTNCC[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuTTNCC", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.PhieuTTNCC[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 != null)
                {
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        if (pt1[j].MaPhieuTTNCC == sochungtu)
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
        /// kiểm tra dữ liệu trước khi update
        /// </summary>
        /// <param name="pttncc"></param>
        /// <returns></returns>
        public bool Check(Entities.PhieuTTNCC pttncc)
        {
            bool gt = true;
            string datetimenew = new Common.Utilities().XuLy(2, (Convert.ToDateTime(pttncc.NgayLap).ToShortDateString()));
            if (datetime != datetimenew)
            {
                datetime = mskngaychungtu.Text = datetimenew;
                gt = false;
            }
            if (mancc != pttncc.MaNCC)
            {
                mancc = txtmancc.Text = pttncc.MaNCC;
                gt = false;
            }
            if (nohienthoi != pttncc.NoHienThoi)
            {
                nohienthoi = txtnohienthoi.Text = pttncc.NoHienThoi;
                gt = false;
            }
            if (nguoinhantien != pttncc.Nguoinhan)
            {
                nguoinhantien = txtnguoinhaptien.Text = pttncc.Nguoinhan;
                gt = false;
            }
            if (tientetygia != pttncc.MaTienTe)
            {
                tientetygia = pttncc.MaTienTe;
                cbbtientetygia.Text = LayTenTT(tientetygia);
                txttientetygia.Text = LayDonViTT(tientetygia);
                gt = false;
            }
            if (ghichu != pttncc.GhiChu)
            {
                ghichu = txtdiengiai.Text = pttncc.GhiChu;
                gt = false;
            }
            return gt;
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
                    Entities.ChiTietPhieuTTNCC[] ctxh2 = new Entities.ChiTietPhieuTTNCC[dgv.RowCount];
                    for (int j = 0; j < ctxh2.Length; j++)
                    {
                        ctxh2[j] = new Entities.ChiTietPhieuTTNCC("Insert", dgv["MaHDBanHang", j].Value.ToString(), txtsochungtu.Text, float.Parse(dgv["ThanhToan", j].Value.ToString()), true, "", false, dgv["TongTienThanhToan", j].Value.ToString(), dgv["SoNo", j].Value.ToString());
                    }
                   kkt= InsertMang(ctxh2);
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
        public bool InsertMang(Entities.ChiTietPhieuTTNCC[] ctxh)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "ChiTietPhieuTTNCCMang", ctxh);
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                return kt;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        /// <summary>
        /// update dư nợ nhà cung cấp
        /// </summary>
        /// <param name="ctkhthdn"></param>
        public bool UpdateDuNo(Entities.NhaCungCap ctkhthdn)
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
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                 
                 
            }
        }
        /// <summary>
        /// update dư nợ sau khi laapj phieu
        /// </summary>
        /// <param name="ctkhthdn"></param>
        public bool UpdateDuNoSauLapPHieu(Entities.HoaDonNhap hdn)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "HDN", hdn);
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
                    Entities.HoaDonNhap[] cthdbh = new Entities.HoaDonNhap[dgv.RowCount];
                    for (int j = 0; j < cthdbh.Length; j++)
                    {
                        double tongtien = Convert.ToDouble(dgv[1, j].Value.ToString());
                        double sotienno = Convert.ToDouble(dgv[2, j].Value.ToString());
                        double sothanhtoan = Convert.ToDouble(dgv[3, j].Value.ToString());
                        double thanhtoankhilap = Convert.ToDouble(dgv[4, j].Value.ToString());
                        string sotiendathanhtoan = (sothanhtoan + thanhtoankhilap).ToString();
                        cthdbh[j] = new Entities.HoaDonNhap("Update", dgv[0, j].Value.ToString(), sotiendathanhtoan);
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
        public bool InsertMang(Entities.HoaDonNhap[] cthdbh)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "HoaDonNhapMang", cthdbh);
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
        string duno = "0";
        /// <summary>
        /// xử lý thêm mới
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
                    dateserver = DateServer.Date();
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
                        Entities.PhieuTTNCC pt = new Entities.PhieuTTNCC();
                        string matt = LayMaTT(cbbtientetygia.Text);
                        pt = new Entities.PhieuTTNCC("Insert", 0, txtsochungtu.Text, DateTime.Parse(date), txtmancc.Text, txtnohienthoi.Text, txtnguoinhaptien.Text, matt, txtdiengiai.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);

                        clientstrem = cl.SerializeObj(this.client1, "PhieuTTNCC", pt);
                        bool kt1 = false;
                        kt1 = (bool)cl.DeserializeHepper(clientstrem, kt);
                        if (kt1 == true)
                        {
                            if (CheckDataGridInsert(dtgvNCC) == true)
                            {
                                if (double.Parse(txttongthanhtoan.Text) != 0)
                                {
                                    //duno = (Convert.ToDouble(txtnohienthoi.Text) - Convert.ToDouble(txttongthanhtoan.Text)).ToString();
                                    duno = Convert.ToDouble(txttongthanhtoan.Text).ToString();

                                    Entities.NhaCungCap kh = new Entities.NhaCungCap("UpdateDuNo", txtmancc.Text, duno);
                                    if (UpdateDuNo(kh) == true)
                                    {
                                        if (CheckDataGridUpdate(dtgvNCC) == true)
                                        {
                                        }
                                        else
                                            MessageBox.Show("Lỗi trong quá trình sửa thanh toán", "Hệ thống cảnh báo");
                                    }
                                    else
                                        MessageBox.Show("Lỗi trong quá trinh sửa dư nợ nhà cung cấp", "Hệ thống cảnh báo");
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
            catch (Exception ex)
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
                } return "";
            }
            catch (Exception ex)
            {
                return "";
            }
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
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        /// lấy mã đơn vị tiền tệ
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
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        /// tính tiền
        /// </summary>
        /// <returns></returns>
        public Double TinhTien()
        {
            try
            {
                Double thanhtien = 0;
                for (int i = 0; i < dtgvNCC.RowCount; i++)
                {
                    thanhtien += Double.Parse(dtgvNCC[3, i].Value.ToString());
                }
                return thanhtien;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        /// <summary>
        /// xử lý chọn tiền tệ
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
                        if (tt[j].TenTienTe == tt[i].TenTienTe)
                            txttientetygia.Text = tt[j].DonViLamTron.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        /// <summary>
        /// tìm nhà cung cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btntimkh_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmTimNCC tkh = new frmTimNCC("PhieuTTNCC");
                tkh.ShowDialog();
                if (frmTimNCC.drvr != null)
                {
                    txtmancc.Text = frmTimNCC.drvr.Cells["MaNhaCungCap"].Value.ToString();
                    lbncc.Text = frmTimNCC.drvr.Cells["TenNhaCungCap"].Value.ToString();
                    txtnohienthoi.Text = String.Format("{0:0}", float.Parse(frmTimNCC.drvr.Cells["DuNo"].Value.ToString()));
                    frmTimNCC.drvr = null;
                    dtgvNCC.DataSource = new Entities.HDThanhToanKH[0];
                    fix();
                }
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// xử lý nút chọn
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
                    dateserver = DateServer.Date();
                    if (kt == true)
                    {
                        cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        string date = new Common.Utilities().MyDateConversion(mskngaychungtu.Text);
                        Entities.PhieuTTNCC pt = new Entities.PhieuTTNCC();
                        string matt = LayMaTT(cbbtientetygia.Text);
                        pt = new Entities.PhieuTTNCC("Update", int.Parse(id), txtsochungtu.Text, DateTime.Parse(date), txtmancc.Text, txtnohienthoi.Text, txtnguoinhaptien.Text, matt, txtdiengiai.Text, false,Common.Utilities.User.NhanVienID,Common.Utilities.User.TenDangNhap);

                        clientstrem = cl.SerializeObj(this.client1, "PhieuTTNCC", pt);
                        bool kt1 = false;
                        kt1 = (bool)cl.DeserializeHepper(clientstrem, kt);
                        if (kt1 == true)
                        {
                            this.Close();

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
                 
                 
            }
        }
        /// <summary>
        /// xử lý khi đổi kích cỡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXuLyPhieuTTNCC_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// xử lý khi click vào tra cứu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_txtTracuu_Click(object sender, EventArgs e)
        {
            toolStrip_txtTracuu.Text = "";
            tssltongthanhtoan.Text = tsslsono.Text = tsslthanhtoan.Text = "0";
        }
        /// <summary>
        /// thêm row mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {
            if (txtmancc.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập Mã nhà cung cấp", "Hệ thống cảnh báo");
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
        Entities.HDThanhToanKH[] hh;
        /// <summary>
        /// xử lý thêm row
        /// </summary>
        public void NewRow()
        {
            try
            {
                
                int sohangtrongbang = dtgvNCC.RowCount;
                if (dtgvNCC.RowCount != 0)
                {
                    for (int j = 0; j < dtgvNCC.RowCount; j++)
                    {
                        if (mahdbh == dtgvNCC[0, j].Value.ToString())
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
                                hh[j] = new Entities.HDThanhToanKH(dtgvNCC[0, j].Value.ToString(), dtgvNCC[1, j].Value.ToString(), dtgvNCC[2, j].Value.ToString(), dtgvNCC[3, j].Value.ToString(), dtgvNCC[4, j].Value.ToString());
                            else
                                hh[hh.Length - 1] = new Entities.HDThanhToanKH(toolStrip_txtTracuu.Text,new Common.Utilities().FormatMoney(Convert.ToDouble( tssltongthanhtoan.Text)), new Common.Utilities().FormatMoney(Convert.ToDouble(tsslsono.Text)), new Common.Utilities().FormatMoney(Convert.ToDouble(tsslthanhtoan.Text)), thanhtoansaukhilapphieu);
                        }
                    }
                    catch (Exception ex)
                    {
                        hh[0] = new Entities.HDThanhToanKH(toolStrip_txtTracuu.Text, new Common.Utilities().FormatMoney(Convert.ToDouble(tssltongthanhtoan.Text)), new Common.Utilities().FormatMoney(Convert.ToDouble(tsslsono.Text)), new Common.Utilities().FormatMoney(Convert.ToDouble(tsslthanhtoan.Text)),thanhtoansaukhilapphieu);
                    }
                    dtgvNCC.DataSource = hh;
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
                tssltongthanhtoan.Text = tsslsono.Text = tsslthanhtoan.Text = "0";
            }
        }
        string mahdbh = "";
        string thanhtoansaukhilapphieu = "";
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
                    if (txtmancc.Text.Length != 0)
                    {
                        frmTimHoaDonNhap fr = new frmTimHoaDonNhap(txtmancc.Text);
                        fr.ShowDialog();
                        if (frmTimHoaDonNhap.drvr != null)
                        {
                            mahdbh = toolStrip_txtTracuu.Text = frmTimHoaDonNhap.drvr.Cells["MaHoaDonNhap"].Value.ToString();
                            tssltongthanhtoan.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(frmTimHoaDonNhap.drvr.Cells["TongTien"].Value.ToString()));
                            thanhtoansaukhilapphieu = frmTimHoaDonNhap.drvr.Cells["ThanhToanSauKhiLapPhieu"].Value.ToString();
                            string sono = (Convert.ToDouble(tssltongthanhtoan.Text) - Convert.ToDouble(frmTimHoaDonNhap.drvr.Cells["ThanhToanNgay"].Value.ToString()) - Convert.ToDouble(thanhtoansaukhilapphieu)).ToString();
                            tsslsono.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(sono));
                            tsslthanhtoan.Text = sono;
                            tsslthanhtoan.Focus();
                            frmTimHoaDonNhap.drvr = null;
                        }
                    }
                    else
                        MessageBox.Show("Bạn hãy nhập Mã nhà cung cấp");
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtmancc.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn cần phải nhập Mã nhà cung cấp", "Hệ thống cảnh báo");
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
        int i;

        private void tsslthanhtoan_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtmancc.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần phải nhập Mã nhân viên", "Hệ thống cảnh báo");
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
                toolStrip_txtTracuu.Focus();
                toolStrip_txtTracuu.Text = "";
            }
        }

        private void dtgvNCC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (i < 0)
                return;
            try
            {

                if (dtgvNCC.RowCount > 1)
                {
                    mahdbh = toolStrip_txtTracuu.Text = dtgvNCC[0, i].Value.ToString();
                    tssltongthanhtoan.Text = dtgvNCC[1, i].Value.ToString();
                    tsslsono.Text = dtgvNCC[2, i].Value.ToString();
                    tsslthanhtoan.Text = dtgvNCC[3, i].Value.ToString();
                    thanhtoansaukhilapphieu = dtgvNCC[4, i].Value.ToString();
                    hh = new Entities.HDThanhToanKH[dtgvNCC.RowCount - 1];
                    int so = 0;
                    for (int j = 0; j < dtgvNCC.RowCount; j++)
                    {
                        if (dtgvNCC[0, j].Value.ToString() != dtgvNCC[0, i].Value.ToString())
                        {
                            hh[so] = new Entities.HDThanhToanKH(dtgvNCC[0, j].Value.ToString(), dtgvNCC[1, j].Value.ToString(), dtgvNCC[2, j].Value.ToString(), dtgvNCC[3, j].Value.ToString(), dtgvNCC[4, j].Value.ToString());
                            so++;
                        }
                    }
                    dtgvNCC.DataSource = hh;
                    txttongthanhtoan.Text = new Common.Utilities().FormatMoney(TinhTien());
                }
                else
                {
                    mahdbh = toolStrip_txtTracuu.Text = dtgvNCC[0, i].Value.ToString();
                    tssltongthanhtoan.Text = dtgvNCC[1, i].Value.ToString();
                    tsslsono.Text = dtgvNCC[2, i].Value.ToString();
                    tsslthanhtoan.Text = dtgvNCC[3, i].Value.ToString();
                    thanhtoansaukhilapphieu = dtgvNCC[4, i].Value.ToString();
                    dtgvNCC.DataSource = new Entities.HDThanhToanKH[0];
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                fix();
                txttongthanhtoan.Text = TinhTien().ToString();
            }
        }

        private void dtgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

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

        Entities.NhaCungCap laynhacungcap(string maNCC)
        {
            Entities.NhaCungCap tem = new Entities.NhaCungCap();
            if (hienthikh == null)
            {
                SelectNCC();
            }
            if (hienthikh.Length > 0)
            {
                foreach (Entities.NhaCungCap item in hienthikh)
                {
                    if (item.MaNhaCungCap.Equals(maNCC))
                    {
                        tem = item;
                    }
                }
            }
            return tem;
        }

        private void tsslin_Click(object sender, EventArgs e)
        {
            try
            {
                ArrayList dulieu = new ArrayList();
                Entities.HDThanhToanKH[] tem = new Entities.HDThanhToanKH[0];
                tem = (Entities.HDThanhToanKH[])dtgvNCC.DataSource;
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
                    Entities.NhaCungCap kh = new Entities.NhaCungCap(); kh = laynhacungcap(txtmancc.Text);
                    dulieu.Add(tem1);    //dữ liệu trong datagridview   (0)
                    dulieu.Add(txtsochungtu.Text);   //Mã phiếu (1)
                    dulieu.Add(kh.TenNhaCungCap); //Tên nhà cung cấp    (2)
                    dulieu.Add(kh.DiaChi);   //Địa chỉ (3)
                    dulieu.Add(txtnguoinhaptien.Text);   //Người nhận tiền   (4)
                    dulieu.Add(txtdiengiai.Text);   //Diễn giải   (5)
                    dulieu.Add(txttongthanhtoan.Text);   //Tổng thanh toán   (6)
                    frmBaoCaorpt a = new frmBaoCaorpt("InPhieuThanhToanCuaNCC", dulieu);
                    a.ShowDialog();
                }
            }
            catch
            {
            }
        }

    }
}
