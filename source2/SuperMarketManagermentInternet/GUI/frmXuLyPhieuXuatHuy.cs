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
    public partial class frmXuLyPhieuXuatHuy : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        public static string trave = "";
        List<Entities.QuyDoiDonViTinh> quidoidvt;
        DateTime datesv;
        string str;

        //Mrk FIX
        bool khongcohanghoatrongkho = false;
        /////////

        /// <summary>
        /// khởi tạo truyền giá trị
        /// </summary>
        /// <param name="str"></param>
        public frmXuLyPhieuXuatHuy(string str)
        {
            try
            {
                InitializeComponent();
                datesv = DateServer.Date();
                quidoidvt = this.bangquydoidonvitinh();
                this.str = str;
                try
                {
                    //////////////////////////MRK FIX
                    string tenkho = "";
                    string makhoK = new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen;
                    if (makhoK == "")
                    {
                        MessageBox.Show("Bạn chưa cài đặt kho - Xin hãy kiểm tra lại", "Hệ thống cảnh báo");
                        return;
                    }
                    LayKhoHang();
                    foreach (Entities.KhoHang item in kh1)
	                {
		                if (item.MaKho.Equals(makhoK))
	                    {
		                    tenkho = item.TenKho;
                            break;
	                    }
	                }
                    bool co = false;
                    for (int i = 0; i < cbbkhohang.Items.Count; i++)
                    {
                        string tem = cbbkhohang.Items[i].ToString();
                        if (tem.Equals(tenkho))
                        {
                            //cbbkhohang.SelectedItem = tenkho;
                            cbbkhohang.SelectedIndex = i;
                            co = true;
                            break;
                        }
                    }
                    if (!co)
                    {
                        cbbkhohang.SelectedIndex = 0;
                    }
                    ////////////////////////////////////////
                    //cbbkhohang.SelectedIndex = 0;
                }
                catch
                {
                }
                sochungtu = txtsochungtu.Text;
                mskngaychungtu.Text = new Common.Utilities().XuLy(2, datesv.ToShortDateString());

            }
            catch
            {

            }
        }
        string id;
        string sochungtu, datetime, manhanvien, khohang, tongtien, ghichu;
        /// <summary>
        /// khởi tạo truyền giá trị khi sửa
        /// </summary>
        /// <param name="str"></param>
        /// <param name="dtgvr"></param>
        public frmXuLyPhieuXuatHuy(string str, DataGridViewRow dtgvr)
        {
            InitializeComponent();
            datesv = DateServer.Date();
            quidoidvt = this.bangquydoidonvitinh();
            try
            {
                LayKhoHang();
                this.str = str;
                bool tinhtrang = (Boolean)dtgvr.Cells["TrangThai"].Value;
                if (tinhtrang == false) { lbtinhtrang.Text = "Chưa xác nhận"; }
                else { lbtinhtrang.Text = "Đã xác nhận"; panel1.Enabled = panel2.Enabled = panel3.Enabled = tsslblghilai.Enabled = false; }
                id = dtgvr.Cells["PhieuXuatHuyID"].Value.ToString();
                sochungtu = txtsochungtu.Text = dtgvr.Cells["MaPhieuXuatHuy"].Value.ToString();
                datetime = mskngaychungtu.Text = new Common.Utilities().XuLy(2, dtgvr.Cells["NgayLap"].Value.ToString());
                manhanvien = manhanvien = txtnhanvien.Text = dtgvr.Cells["MaNhanVien"].Value.ToString();
                khohang = dtgvr.Cells["MaKho"].Value.ToString();
                cbbkhohang.Text = LayTenKho(khohang);
                tongtien = txttongtien.Text = dtgvr.Cells["Tongtien"].Value.ToString();
                ghichu = txtghichu.Text = dtgvr.Cells["GhiChu"].Value.ToString();
                SelectData();
                txttongtien.Text = String.Format("{0:0,0}", Convert.ToDouble(TinhTien(dtgvsanpham)));
                if (dtgvr.Cells["TrangThai"].Value == "True")
                {
                    panel1.Enabled = panel2.Enabled = panel3.Enabled = false;
                }
            }
            catch
            {

            }
        }

        ////////////////////////////////////////MRK FIX
        List<Entities.QuyDoiDonViTinh> bangquydoidonvitinh()
        {
            // quy đổi đơn vị tính
            Server_Client.Client cl = new Server_Client.Client();
            TcpClient client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("QD");
            clientstrem = cl.SerializeObj(client1, "Select", ctxh);
            Entities.QuyDoiDonViTinh[] quidoidvt = new Entities.QuyDoiDonViTinh[0];
            return ((Entities.QuyDoiDonViTinh[])cl.DeserializeHepper1(clientstrem, quidoidvt)).ToList();
        }
        //////////////////////////////////////////////

        Entities.ChiTietXuatHuy[] pt1;
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData()
        {
            Entities.HangHoaHienThi[] hhht = new Entities.HangHoaHienThi[0];
            try
            {
                i = 0;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ChiTietXuatHuy ctxh = new Entities.ChiTietXuatHuy("Select", sochungtu);
                // khởi tạo mảng đối tượng để hứng giá trị
                pt1 = new Entities.ChiTietXuatHuy[1];
                clientstrem = cl.SerializeObj(this.client1, "ChiTietXuatHuy", ctxh);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.ChiTietXuatHuy[])cl.DeserializeHepper1(clientstrem, pt1);


                if (pt1 == null)
                {
                    dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                    return;
                }

                Entities.ChiTietXuatHuy[] pt2 = new Entities.ChiTietXuatHuy[pt1.Length];
                int sotang = 0;
                for (int j = 0; j < pt1.Length; j++)
                {
                    if (pt1[j].Deleted == false)
                    {
                        if (pt1[j].MaPhieuXuatHuy == sochungtu)
                        {
                            pt2[sotang] = pt1[j];
                            sotang++;
                        }
                    }
                }
                hhht = new Entities.HangHoaHienThi[sotang];
                if (sotang != 0)
                {
                    SelectHangHoa();
                    for (int j = 0; j < sotang; j++)
                    {
                        string tongtien = (Convert.ToDouble(LayGiaSanPham(pt2[j].MaHangHoa)) * Convert.ToDouble(pt2[j].SoLuong.ToString())).ToString();
                        hhht[j] = new Entities.HangHoaHienThi(pt2[j].MaPhieuXuatHuy, pt2[j].MaHangHoa, LayTenSanPham(pt2[j].MaHangHoa), new TienIch().FormatMoney(LayGiaSanPham(pt2[j].MaHangHoa)), pt2[j].SoLuong.ToString(), new TienIch().FormatMoney(tongtien));
                    }
                }
                else
                {
                    dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                    return;
                }
                dtgvsanpham.DataSource = hhht;

                dtgvsanpham.Rows[0].Selected = true;

            }
            catch { }
            finally
            {
                try
                {
                    fix();
                }
                catch { }
            }
        }

        public void fix()
        {
            for (int i = 0; i < dtgvsanpham.ColumnCount; i++)
            {
                dtgvsanpham.Columns[i].Visible = false;
            } dtgvsanpham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvsanpham.ReadOnly = true;
            dtgvsanpham.RowHeadersVisible = false;
            dtgvsanpham.Columns["MaHangHoa"].Visible = true;
            dtgvsanpham.Columns["TenHang"].Visible = true;
            dtgvsanpham.Columns["DonGia"].Visible = true;
            dtgvsanpham.Columns["SoLuong"].Visible = true;
            dtgvsanpham.Columns["ChietKhau"].Visible = true;
            dtgvsanpham.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
            dtgvsanpham.Columns["TenHang"].HeaderText = "Tên Hàng";
            dtgvsanpham.Columns["DonGia"].HeaderText = "Đơn Giá";
            dtgvsanpham.Columns["SoLuong"].HeaderText = "Số Lượng";
            dtgvsanpham.Columns["ChietKhau"].HeaderText = "Tổng Tiền";
            dtgvsanpham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvsanpham.AllowUserToAddRows = false;
            dtgvsanpham.AllowUserToDeleteRows = false;
            dtgvsanpham.AllowUserToResizeRows = false;
        }
        Entities.HangHoa[] hh1;
        /// <summary>
        /// select hàng hóa
        /// </summary>
        public void SelectHangHoa()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.HangHoa pt = new Entities.HangHoa("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                hh1 = new Entities.HangHoa[1];
                clientstrem = cl.SerializeObj(this.client1, "HangHoa", pt);
                // đổ mảng đối tượng vào datagripview       
                hh1 = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, hh1);
            }
            catch { }
        }
        /// <summary>
        /// lấy tên hàng hóa
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string LayTenSanPham(string str)
        {
            try
            {
                string ten = "";
                if (hh1 != null)
                {
                    for (int j = 0; j < hh1.Length; j++)
                    {
                        if (hh1[j].MaHangHoa == str)
                        {
                            ten = hh1[j].TenHangHoa;
                            break;
                        }
                    }
                }
                return ten;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        /// lấy giá hàng hóa
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string LayGiaSanPham(string str)
        {
            try
            {
                string gia = "";
                if (hh1 != null)
                {
                    for (int j = 0; j < hh1.Length; j++)
                    {
                        if (hh1[j].MaHangHoa == str)
                        {
                            gia = hh1[j].GiaNhap.ToString();
                            break;
                        }
                    }
                }
                return gia;
            }
            catch (Exception ex)
            {

                return "";
            }
        }
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        public void XuLyStr()
        {
            if (str == "Sua")
            {
                this.Text = "Quản Lý Phiếu Xuất Hủy - Chi Tiết Phiếu Xuất Hủy";
                tsslblthemmoi.Enabled = false;
            }
            else if (str == "Them")
            {
                this.Text = "Thêm Mới - F4 Tìm Hàng Hóa - F5 Thêm Mới - F6 Sửa Hàng Hóa";
                tsslblghilai.Enabled = false;
                txtsochungtu.Text = ProID("PhieuXuatHuy");
                dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
            }
        }
        
        Entities.KhoHang[] kh1;
        /// <summary>
        /// select kho hàng
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
            catch (Exception ex)
            {
                cbbkhohang.Items.Clear();
                cbbkhohang.Text = "";
            }
            finally
            {


            }
        }
        /// <summary>
        /// lấy mã kho hàng
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
            catch (Exception ex)
            {
                return "";
            }

        }
        /// <summary>
        /// lấy tên kho hàng
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
            catch (Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        /// nút trở về
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslbldong_Click(object sender, EventArgs e)
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
        string ngayct;
        /// <summary>
        /// kiểm tra dữ liệu nhập vào
        /// </summary>
        /// <returns></returns>
        private bool Kiemtra()
        {
            if (txtnhanvien.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập Nhân viên", "Hệ thống cảnh báo");
                txtnhanvien.Focus();
                return false;
            }
            if (cbbkhohang.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập Kho hàng", "Hệ thống cảnh báo");
                cbbkhohang.Focus();
                return false;
            }
            if (dtgvsanpham.DataSource == null)
            {
                MessageBox.Show("Bạn cần phải nhập Hàng hóa", "Hệ thống cảnh báo");
                return false;
            }
            if (dtgvsanpham.RowCount == 0)
            {
                MessageBox.Show("Bạn cần phải nhập Hàng hóa", "Hệ thống cảnh báo");
                return false;
            }
            return true;
        }
        /// <summary>
        /// kiểm tra dữ liệu trong datagridview để update
        /// </summary>
        /// <param name="dgv"></param>
        public void CheckDataGirdUpdate(DataGridView dgv)
        {
            try
            {
                int slnew = 0;
                int sl = dgv.RowCount;
                string hd = "";
                int sotang = 0;
                if (pt1 == null)
                    if (sl == 0)
                    {
                        MessageBox.Show("không có dữ liệu");
                        return;
                    }
                if (dgv.RowCount != 0)
                {

                    if (sl > pt1.Length)
                        slnew = sl;
                    else
                        slnew = pt1.Length;
                    Entities.ChiTietXuatHuy[] ctxh1 = new Entities.ChiTietXuatHuy[slnew];
                    for (int k = 0; k < pt1.Length; k++)
                    {
                        for (int j = 0; j < sl; j++)
                        {
                            if (dgv[1, j].Value.ToString() == pt1[k].MaHangHoa)
                            {
                                hd = "ok";
                                break;
                            }
                        }
                        if (hd == "")
                        {
                            ctxh1[sotang] = new Entities.ChiTietXuatHuy("Delete", pt1[k].MaPhieuXuatHuy, pt1[k].MaHangHoa);
                            sotang++;
                        }
                        else
                            hd = "";
                    }
                    if (sotang != 0)
                    {
                        Entities.ChiTietXuatHuy[] ctxh2 = new Entities.ChiTietXuatHuy[sotang];
                        for (int j = 0; j < ctxh2.Length; j++)
                        {
                            ctxh2[j] = ctxh1[j];
                        }
                        DeleteMang(ctxh2);
                    }
                    else
                        return;
                }
                else
                {
                    Entities.ChiTietXuatHuy[] ctxh2 = new Entities.ChiTietXuatHuy[pt1.Length];
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        ctxh2[j] = new Entities.ChiTietXuatHuy("Delete", pt1[j].MaPhieuXuatHuy, pt1[j].MaHangHoa);
                    }
                    DeleteMang(ctxh2);
                }
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// kiểm tra dữ liệu trong datagridview để insert
        /// </summary>
        /// <param name="dgv"></param>
        public void CheckDataGridInsert(DataGridView dgv)
        {
            try
            {
                if (dgv.RowCount != 0)
                {
                    Entities.ChiTietXuatHuy[] ctxh2 = new Entities.ChiTietXuatHuy[dgv.RowCount];
                    for (int j = 0; j < ctxh2.Length; j++)
                    {
                        ctxh2[j] = new Entities.ChiTietXuatHuy("InsertUpdate", txtsochungtu.Text, dgv[1, j].Value.ToString(), int.Parse(dgv[4, j].Value.ToString()), "", false);
                    }
                    InsertMang(ctxh2);
                }
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// xử lý delete mảng
        /// </summary>
        /// <param name="ctxh"></param>
        public void DeleteMang(Entities.ChiTietXuatHuy[] ctxh)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "ChiTietXuatHuyMang", ctxh);
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
            }
            catch (Exception ex)
            {

            }
            finally
            {


            }
        }
        /// <summary>
        /// xử lý insert mảng
        /// </summary>
        /// <param name="ctxh"></param>
        public void InsertMang(Entities.ChiTietXuatHuy[] ctxh)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "ChiTietXuatHuyMang", ctxh);
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
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
        /// <param name="dgv"></param>
        /// <returns></returns>
        public string TinhTien(DataGridView dgv)
        {
            try
            {
                double gia = 0;
                if (dgv.RowCount != 0)
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        gia += (Convert.ToDouble(dgv[4, i].Value.ToString()) * Convert.ToDouble(dgv[3, i].Value.ToString()));
                    }
                    return gia.ToString();
                }
                return "0";
            }
            catch (Exception ex)
            {

                return "0";
            }
        }
        Entities.PhieuXuatHuy pxh;
        /// <summary>
        /// thêm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslblthemmoi_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (Kiemtra() == true)
                {
                    CheckConflictInsert();
                    if (kt == true)
                    {
                        try
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
                            Entities.PhieuXuatHuy pt = new Entities.PhieuXuatHuy();
                            string makho = LayMaKho(cbbkhohang.Text);
                            pt = new Entities.PhieuXuatHuy("Insert", 0, txtsochungtu.Text, Convert.ToDateTime(date), txtnhanvien.Text, makho, false, txttongtien.Text, txtghichu.Text, false, Common.Utilities.User.TenDangNhap);

                            clientstrem = cl.SerializeObj(this.client1, "PhieuXuatHuy", pt);
                            bool kt1 = false;
                            kt1 = (bool)cl.DeserializeHepper(clientstrem, kt1);
                            if (kt1 == true)
                            {
                                CheckDataGridInsert(dtgvsanpham);
                                DialogResult giatri = MessageBox.Show("Bạn có muốn thêm phiếu xuất hủy tiếp không?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                                {
                                    if (giatri == DialogResult.No)
                                        trave = "a";
                                } this.Close();
                            }
                            else
                            {
                                MessageBox.Show("thất bại - xin kiểm tra lại dữ liệu", "Hệ thống cảnh báo");
                            }

                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            this.Enabled = true;
        }
        bool kt = false;
        /// <summary>
        /// Kiểm tra dữ liệu trong database để insert
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
                Entities.PhieuXuatHuy pt = new Entities.PhieuXuatHuy("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.PhieuXuatHuy[] pt1 = new Entities.PhieuXuatHuy[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuXuatHuy", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.PhieuXuatHuy[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 != null)
                {
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        if (pt1[j].MaPhieuXuatHuy == sochungtu)
                        {
                            MessageBox.Show("cập nhật mã phiếu - kiểm tra lại để insert");
                            kt = false;
                            sochungtu = txtsochungtu.Text = ProID("PhieuXuatHuy");
                            break;
                        }
                        else
                            kt = true;
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
        /// kiểm tra dữ liệu trong database để update
        /// </summary>
        public void CheckConflictUpdate()
        {
            try
            {
                kt = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.PhieuXuatHuy pt = new Entities.PhieuXuatHuy("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.PhieuXuatHuy[] pt1 = new Entities.PhieuXuatHuy[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuXuatHuy", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.PhieuXuatHuy[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 != null)
                {
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        if (pt1[j].MaPhieuXuatHuy == sochungtu)
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

            }
            finally
            {


            }
        }
        /// <summary>
        /// kiểm tra dữ liệu giữa data + người dùng nhập vào để update
        /// </summary>
        /// <param name="pxh"></param>
        /// <returns></returns>
        public bool Check(Entities.PhieuXuatHuy pxh)
        {
            bool gt = true;
            string datetimenew = new Common.Utilities().XuLy(2, (Convert.ToDateTime(pxh.NgayLap).ToShortDateString()));
            if (datetime != datetimenew)
            {
                datetime = mskngaychungtu.Text = datetimenew;
                gt = false;
            }
            if (khohang != pxh.MaKho)
            {
                khohang = pxh.MaKho;
                cbbkhohang.Text = LayTenKho(khohang);
                gt = false;
            }
            if (manhanvien != pxh.MaNhanVien)
            {
                manhanvien = txtnhanvien.Text = pxh.MaNhanVien;
                gt = false;
            }
            if (ghichu != pxh.GhiChu)
            {
                ghichu = txtghichu.Text = pxh.GhiChu;
                gt = false;
            }
            return gt;
        }
        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXuLyPhieuXuatHuy_Load(object sender, EventArgs e)
        {
            try
            {
                //NapQuyDoiVaGoiHang();

                XuLyStr();

                fix();
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
                lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, pxh);
                if (lid == null)
                    return "PXH_0001";
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            catch (Exception ex)
            {

                return "";
            }
            finally
            {


            }
        }
        /// <summary>
        /// xử lý tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btntimkiem_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmTimNhanVien tnv = new frmTimNhanVien();
                tnv.ShowDialog();
                if (frmTimNhanVien.drvr != null)
                {
                    txtnhanvien.Text = frmTimNhanVien.drvr.Cells["MaNhanVien"].Value.ToString();
                    cbbkhohang.Focus();
                    frmTimNhanVien.drvr = null;
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void XulyHH()
        {
            try
            {
                string maKho = LayMaKho(cbbkhohang.Text);
                maKho = new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen;
                frmTimHangHoa thh = new frmTimHangHoa(maKho,"HangHoa","");
                thh.ShowDialog();
                if (frmTimHangHoa.drvr != null)
                {
                    mahanghoa = toolStrip_txtTracuu.Text = frmTimHangHoa.drvr.Cells["MaHangHoa"].Value.ToString();
                    tssltenhang.Text = frmTimHangHoa.drvr.Cells["TenHangHoa"].Value.ToString();
                    tsslgia.Text = frmTimHangHoa.drvr.Cells["GiaNhap"].Value.ToString();
                    tsslsoluong.Text = "";
                    string soluong = "0";
                    if (tsslsoluong.Text == "")
                        soluong = "0";
                    else
                        soluong = tsslsoluong.Text;
                    tsslthanhtien.Text = (Convert.ToDouble(soluong) * Convert.ToDouble(tsslgia.Text)).ToString();
                    frmTimHangHoa.drvr = null;
                    tsslsoluong.Focus();
                    toolStrip_txtTracuu.ReadOnly = true;
                }
                else
                    toolStrip_txtTracuu.ReadOnly = false;
            }
            catch
            {
            }
        }
        string mahanghoa;
        /// <summary>
        /// xử lý khi ấn phím xuống
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslhanghoa_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    tsslblthemmoi_Click(sender, e);
                }
                if (e.KeyCode == Keys.F6)
                {
                    dtgvsanpham.Focus();
                }
                
                if (e.KeyCode == Keys.F4)
                {
                    if (cbbkhohang.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải nhập Kho hàng", "Hệ thống cảnh báo");
                        cbbkhohang.Focus();
                        return;
                    }
                    if (txtnhanvien.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn phải nhập Mã nhân viên", "Hệ thống cảnh báo");
                        btntimkiem.Focus();
                        return;
                    }
                    XulyHH();
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (toolStrip_txtTracuu.Text.Length > 0)
                    {
                        mahanghoa = toolStrip_txtTracuu.Text;
                        //Quy Đổi
                        foreach (Entities.QuyDoiDonViTinh item in quidoidvt)
                        {
                            if (item.MaHangQuyDoi == mahanghoa)
                            {
                                toolStrip_txtTracuu.Text = item.MaHangDuocQuyDoi.ToUpper();
                                tssltenhang.Text = item.TenHangDuocQuyDoi;
                                tsslsoluong.Text = item.SoLuongDuocQuyDoi.ToString();
                                break;

                            }
                        }
                        LayHangHoaTheoMa();
                        if (this.khongcohanghoatrongkho)
                        {
                            MessageBox.Show("Không có hàng hóa trong kho!");
                            return;
                        }
                        tsslsoluong.Focus();
                    }
                }
                
            }
            catch
            {

            }
        }
        /// <summary>
        /// xử lý số lượng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tstxtsoluong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string soluong = "0";
                if (tsslsoluong.Text == "")
                    soluong = "0";
                else
                    soluong = tsslsoluong.Text;
                if (int.Parse(soluong) > 0)
                {
                    tsslthanhtien.Text = (Convert.ToDouble(soluong) * Convert.ToDouble(tsslgia.Text)).ToString();
                    return;
                }
                tsslsoluong.Text = "";
                tsslthanhtien.Text = "0";

            }
            catch (Exception ex)
            {

                tsslsoluong.Text = "";
            }
        }
        Entities.HangHoaHienThi[] hh;
        /// <summary>
        /// xử lý thêm 1 row trong dtgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (tssltenhang.Text.Length == 0)
                {
                    MessageBox.Show("Chưa có tên hàng hóa");
                    toolStrip_txtTracuu.Focus();
                    toolStrip_txtTracuu.Text = "";
                    return;
                }
                if (tsslsoluong.Text.Length == 0)
                {
                    MessageBox.Show("Chưa nhập số lượng hàng", "Hệ thống cảnh báo");
                    tsslsoluong.Focus();
                    return;
                }
                NewRow();
                toolStrip_txtTracuu.ReadOnly = false;
            }
            catch
            {
            }
        }

        private Server_Client.Client cl;
        private TcpClient client;
        #region Quy Doi
        private Entities.HangHoaGoiHang quydoiDonViTinh;
        private void QuyDoi(string mahang)
        {
            try
            {
                Entities.HangHoaGoiHang dat = new Entities.HangHoaGoiHang();
                dat.Hanhdong = "Select";
                dat.MaHang = mahang;
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "QuyDoi", dat);
                quydoiDonViTinh = new Entities.HangHoaGoiHang();
                quydoiDonViTinh = (Entities.HangHoaGoiHang)cl.DeserializeHepper(clientstrem, quydoiDonViTinh);
                client.Close();
                clientstrem.Close();
                if (quydoiDonViTinh.MaHang != null)
                {
                    toolStrip_txtTracuu.Text = quydoiDonViTinh.MaHang;
                    tssltenhang.Text = quydoiDonViTinh.TenHang;
                    tsslsoluong.Text = quydoiDonViTinh.SoLuong;
                    tsslgia.Text = quydoiDonViTinh.GiaNhap;
                    tsslthanhtien.Text = (double.Parse(tsslsoluong.Text) * double.Parse(tsslgia.Text)).ToString();
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion

        /// <summary>
        /// method xử lý thêm row
        /// </summary>
        public void NewRow()
        {
            try
            {
                int sohangtrongbang = dtgvsanpham.RowCount;
                if (dtgvsanpham.RowCount != 0)
                {
                    for (int j = 0; j < dtgvsanpham.RowCount; j++)
                    {
                        if (mahanghoa == dtgvsanpham[1, j].Value.ToString())
                        {
                            hh = new Entities.HangHoaHienThi[sohangtrongbang];
                            break;
                        }
                        else
                            hh = new Entities.HangHoaHienThi[sohangtrongbang + 1];
                    }
                }
                else
                    hh = new Entities.HangHoaHienThi[sohangtrongbang + 1];

                if (hh.Length != 0)
                {
                    try
                    {
                        QuyDoi(toolStrip_txtTracuu.Text.ToUpper());
                    }
                    catch
                    { }
                    try
                    {
                        string kt1 = "";
                        if (hh.Length == dtgvsanpham.RowCount)
                        {

                            for (int j = 0; j < hh.Length; j++)
                            {
                                if (mahanghoa == dtgvsanpham[1, j].Value.ToString())
                                {
                                    int soluongcu = Convert.ToInt32(dtgvsanpham[4, j].Value.ToString());
                                    string soluong = "0";
                                    if (tsslsoluong.Text == "")
                                        soluong = "0";
                                    else
                                        soluong = tsslsoluong.Text;
                                    int soluongmoi = Convert.ToInt32(soluong);
                                    int soluonghientai = soluongcu + soluongmoi;
                                    string tongtien = (Convert.ToDouble(soluonghientai.ToString()) * Convert.ToDouble(dtgvsanpham[3, j].Value.ToString())).ToString();
                                    hh[j] = new Entities.HangHoaHienThi(txtsochungtu.Text, dtgvsanpham[1, j].Value.ToString(), dtgvsanpham[2, j].Value.ToString(), dtgvsanpham[3, j].Value.ToString(), soluonghientai.ToString(), tongtien);
                                    kt1 = "ok";
                                }
                                else
                                    hh[j] = new Entities.HangHoaHienThi(txtsochungtu.Text, dtgvsanpham[1, j].Value.ToString(), dtgvsanpham[2, j].Value.ToString(), dtgvsanpham[3, j].Value.ToString(), dtgvsanpham[4, j].Value.ToString(), dtgvsanpham[5, j].Value.ToString());
                            }
                        }
                        else
                        {
                            for (int j = 0; j < hh.Length; j++)
                            {
                                if (j < hh.Length - 1)
                                    hh[j] = new Entities.HangHoaHienThi(txtsochungtu.Text, dtgvsanpham[1, j].Value.ToString(), dtgvsanpham[2, j].Value.ToString(), dtgvsanpham[3, j].Value.ToString(), dtgvsanpham[4, j].Value.ToString(), dtgvsanpham[5, j].Value.ToString());
                                else
                                    hh[hh.Length - 1] = new Entities.HangHoaHienThi(txtsochungtu.Text, mahanghoa, tssltenhang.Text, tsslgia.Text, tsslsoluong.Text, tsslthanhtien.Text);
                            }
                        }
                        if (kt1 == "")
                            hh[hh.Length - 1] = new Entities.HangHoaHienThi(txtsochungtu.Text, mahanghoa, tssltenhang.Text, tsslgia.Text, tsslsoluong.Text, tsslthanhtien.Text);

                    }
                    catch (Exception ex)
                    {
                        hh[0] = new Entities.HangHoaHienThi(txtsochungtu.Text, mahanghoa, tssltenhang.Text, tsslgia.Text, tsslsoluong.Text, tsslthanhtien.Text);
                    }
                    dtgvsanpham.DataSource = hh;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                try
                {
                    for (int i = 0; i < dtgvsanpham.ColumnCount; i++)
                    {
                        dtgvsanpham.Columns[i].Visible = false;
                    }
                    dtgvsanpham.ReadOnly = true;
                    dtgvsanpham.RowHeadersVisible = false;
                    dtgvsanpham.Columns["MaHangHoa"].Visible = true;
                    dtgvsanpham.Columns["TenHang"].Visible = true;
                    dtgvsanpham.Columns["DonGia"].Visible = true;
                    dtgvsanpham.Columns["SoLuong"].Visible = true;
                    dtgvsanpham.Columns["ChietKhau"].Visible = true;
                    dtgvsanpham.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
                    dtgvsanpham.Columns["TenHang"].HeaderText = "Tên Hàng";
                    dtgvsanpham.Columns["DonGia"].HeaderText = "Đơn Giá";
                    dtgvsanpham.Columns["SoLuong"].HeaderText = "Số Lượng";
                    dtgvsanpham.Columns["ChietKhau"].HeaderText = "Tổng Tiền";
                    dtgvsanpham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dtgvsanpham.AllowUserToAddRows = false;
                    dtgvsanpham.AllowUserToDeleteRows = false;
                    dtgvsanpham.AllowUserToResizeRows = false;
                    toolStrip_txtTracuu.Text = "<F4 - Tra Cứu>";
                    tssltenhang.Text = "";
                    tsslgia.Text = "0";
                    tsslsoluong.Text = "";
                    tsslthanhtien.Text = "0";
                    txttongtien.Text = String.Format("{0:0,0}", Convert.ToDouble(TinhTien(dtgvsanpham)));
                }
                catch
                {
                }
            }

        }
        int i;
        /// <summary>
        /// nút sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslblghilai_Click(object sender, EventArgs e)
        {
            try
            {
                if (Kiemtra() == true)
                {
                    CheckConflictUpdate();
                    if (kt == true)
                    {
                        try
                        {
                            CheckDataGirdUpdate(dtgvsanpham);
                            CheckDataGridInsert(dtgvsanpham);
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            string date = new Common.Utilities().MyDateConversion(mskngaychungtu.Text);
                            Entities.PhieuXuatHuy pt = new Entities.PhieuXuatHuy();
                            string makho = LayMaKho(cbbkhohang.Text);
                            pt = new Entities.PhieuXuatHuy("Update", int.Parse(id), txtsochungtu.Text, Convert.ToDateTime(date), txtnhanvien.Text, makho, false, txttongtien.Text, txtghichu.Text, false, Common.Utilities.User.TenDangNhap);

                            clientstrem = cl.SerializeObj(this.client1, "PhieuXuatHuy", pt);
                            bool kt1 = false;
                            kt1 = (bool)cl.DeserializeHepper(clientstrem, kt1);
                            if (kt1 == true)
                            {
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("thất bại - xin kiểm tra lại dữ liệu", "Hệ thống cảnh báo");
                            }

                        }
                        catch (Exception ex)
                        {
                            kt = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu đã được thay đổi - hãy kiểm tra lại", "Hệ thống cảnh báo");
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
        /// xử lý khi click vào tra cứu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_txtTracuu_Click(object sender, EventArgs e)
        {
            toolStrip_txtTracuu.ReadOnly = false;
            toolStrip_txtTracuu.Text = "";
            tssltenhang.Text = "";
            tsslsoluong.Text = "";
            tsslgia.Text = "0";
            tsslthanhtien.Text = "0";
        }
        /// <summary>
        /// xử lý khi có ấn phím
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_txtTracuu_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        int run = 0;
        /// <summary>
        /// lấy hàng hóa
        /// </summary>
        private void LayHangHoaTheoMa()
        {
            Entities.HangHoa[] kh1;
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                Entities.HangHoa kh = new Entities.HangHoa();
                string makho = LayMaKho(cbbkhohang.Text);
                kh = new Entities.HangHoa("SelectTheoKho", makho);
                clientstrem = cl.SerializeObj(this.client1, "HangHoa", kh);
                kh1 = new Entities.HangHoa[1];
                kh1 = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 == null)
                    kh1 = new Entities.HangHoa[0];

                if (kh1.Length > 0)
                {
                    bool ktdata = false;
                    int sl = kh1.Length;
                    for (int i = 0; i < sl; i++)
                    {
                        if (kh1[i].Deleted == false)
                            if (kh1[i].MaHangHoa == toolStrip_txtTracuu.Text)
                            {
                                mahanghoa = toolStrip_txtTracuu.Text = kh1[i].MaHangHoa;
                                tssltenhang.Text = kh1[i].TenHangHoa;
                                tsslgia.Text = kh1[i].GiaBanLe.ToString();
                                toolStrip_txtTracuu.ReadOnly = true;
                                tsslsoluong.Focus();
                                ktdata = true;
                                break;
                            }
                    }
                    if (ktdata == false)
                    {
                        tssltenhang.Text = "";
                        tsslgia.Text = "0";
                        tsslsoluong.Text = "";
                        tsslthanhtien.Text = "0";
                        toolStrip_txtTracuu.ReadOnly = false;
                        this.khongcohanghoatrongkho = true;
                    }
                }
                else
                {
                    tssltenhang.Text = "";
                    tsslgia.Text = "0";
                    tsslsoluong.Text = "";
                    tsslthanhtien.Text = "0";
                    toolStrip_txtTracuu.ReadOnly = false;
                    MessageBox.Show("Không có hàng hóa trong kho!");
                }
            }
            catch (Exception ex)
            {
                tssltenhang.Text = "";
                tsslgia.Text = "0";
                tsslsoluong.Text = "";
                tsslthanhtien.Text = "0";
                toolStrip_txtTracuu.ReadOnly = false;
            }
            finally
            {
                timerRun.Stop();
                run = 0;

            }
        }
        /// <summary>
        /// chạy timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerRun_Tick(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {

            }

        }
        /// <summary>
        /// không cho đổi kicks thước Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXuLyPhieuXuatHuy_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        public void XuLyDGV()
        {
            if (i < 0)
                return;
            try
            {
                if (dtgvsanpham.RowCount > 1)
                {
                    mahanghoa = toolStrip_txtTracuu.Text = dtgvsanpham["MaHangHoa", i].Value.ToString();
                    tssltenhang.Text = dtgvsanpham["TenHang", i].Value.ToString();
                    tsslgia.Text = dtgvsanpham["DonGia", i].Value.ToString();
                    tsslsoluong.Text = dtgvsanpham["SoLuong", i].Value.ToString();
                    tsslthanhtien.Text = dtgvsanpham["ChietKhau", i].Value.ToString();
                    hh = new Entities.HangHoaHienThi[dtgvsanpham.RowCount - 1];
                    int so = 0;
                    for (int j = 0; j < dtgvsanpham.RowCount; j++)
                    {
                        if (dtgvsanpham[1, j].Value.ToString() != dtgvsanpham[1, i].Value.ToString())
                        {
                            hh[so] = new Entities.HangHoaHienThi(txtsochungtu.Text, dtgvsanpham[1, j].Value.ToString(), dtgvsanpham[2, j].Value.ToString(), dtgvsanpham[3, j].Value.ToString(), dtgvsanpham[4, j].Value.ToString(), dtgvsanpham[5, j].Value.ToString());
                            so++;
                        }
                    }
                    dtgvsanpham.DataSource = hh;
                }
                else
                {
                    mahanghoa = toolStrip_txtTracuu.Text = dtgvsanpham["MaHangHoa", i].Value.ToString();
                    tssltenhang.Text = dtgvsanpham["TenHang", i].Value.ToString();
                    tsslgia.Text = dtgvsanpham["DonGia", i].Value.ToString();
                    tsslsoluong.Text = dtgvsanpham["SoLuong", i].Value.ToString();
                    tsslthanhtien.Text = dtgvsanpham["ChietKhau", i].Value.ToString();
                    txttongtien.Text = "0";
                    dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                    return;
                }
                txttongtien.Text = String.Format("{0:0,0}", Convert.ToDouble(TinhTien(dtgvsanpham)));
            }
            catch (Exception ex)
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
        private void dtgvsanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            XuLyDGV();
        }

        private void dtgvsanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void tsslsoluong_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F4)
                {
                    XulyHH();
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (tssltenhang.Text.Length == 0)
                    {
                        MessageBox.Show("Chưa có tên hàng hóa");
                        return;
                    }
                    if (tsslsoluong.Text.Length == 0)
                    {
                        MessageBox.Show("Chưa nhập số lượng hàng", "Hệ thống cảnh báo");
                        tsslsoluong.Focus();
                        return;
                    }
                    NewRow();
                    toolStrip_txtTracuu.ReadOnly = false;
                    toolStrip_txtTracuu.Focus();
                    toolStrip_txtTracuu.Text = "";
                }
            }
            catch
            {
            }
        }

        private void KeyUp_Chung(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F4)
                {
                    XulyHH();
                }
                if (e.KeyCode == Keys.F5)
                {
                    tsslthem_Click(sender, e);
                }
                if (e.KeyCode == Keys.F6)
                {
                    dtgvsanpham.Focus();
                }
            }
            catch
            {
            }
        }
        private void btntimkiem_KeyUp(object sender, KeyEventArgs e)
        {
            KeyUp_Chung(sender, e);
        }

        private void dtgvsanpham_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                    i = dtgvsanpham.SelectedRows[0].Index;
                XuLyDGV();
            }
        }

        private void cbbkhohang_KeyUp(object sender, KeyEventArgs e)
        {
            KeyUp_Chung(sender, e);
            if (e.KeyCode == Keys.Enter)
            {
                txtghichu.Focus();
            }
        }

        private void txtghichu_KeyUp(object sender, KeyEventArgs e)
        {
            KeyUp_Chung(sender, e);
            if (e.KeyCode == Keys.Enter)
            {
                toolStrip_txtTracuu.Focus();
            }
        }

        private void cbbkhohang_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
            fix();
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
