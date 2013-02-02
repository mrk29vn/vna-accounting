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
    public partial class frmXuLyBanLe : Form
    {
        #region Điểm thưởng khách hàng
        Entities.DiemThuongKhachHang[] dtkh = new Entities.DiemThuongKhachHang[0];
        private void DiemThuongKhachHang()
        {//Lấy điểm thưởng khách hàng từ csdl
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "SelectDiemThuongKhachHang", new Entities.DiemThuongKhachHang("select"));
                dtkh = (Entities.DiemThuongKhachHang[])cl.DeserializeHepper1(clientstrem, dtkh);
                if (dtkh == null)
                    dtkh = new Entities.DiemThuongKhachHang[0];
            }
            catch { }
        }
        private double TyLeTinh()
        {//Lấy tỷ lệ tính từ csdl
            try
            {
                Entities.TyLeTinh[] tlt = new Entities.TyLeTinh[0];
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "selectTyLeTinh", new Entities.TyLeTinh());
                tlt = (Entities.TyLeTinh[])cl.DeserializeHepper1(clientstrem, tlt);
                if (tlt == null)
                    tlt = new Entities.TyLeTinh[0];
                if (tlt.Length >= 1) { return tlt[tlt.Length - 1].SoTien; }
                else { return 2988000; }
            }
            catch { return 2988000; }
        }
        private int sodiemthuong(double tien)
        {//Tính số điểm thưởng khách hàng
            try
            {
                double tyle = TyLeTinh();
                if (tien < 0 || tyle < 0)
                {
                    return 0;
                }
                return Convert.ToInt32(Math.Round(tien / tyle));
            }
            catch { return 0; }
        }
        public string ProIDDTKH(string tenBang)
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
                    return "DTKH_0001";
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            catch { return ""; }
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
        private bool CapNhatDiemThuongKhachHang(string maKH, string tien)
        {
            try
            {
                Entities.DiemThuongKhachHang input = null;
                DiemThuongKhachHang();
                foreach (Entities.DiemThuongKhachHang item in dtkh)
                {
                    if (item.MaKhachHang.ToUpper().Equals(maKH.ToUpper()))
                    {//khách hàng đã có điểm
                        //thực hiện việc cộng số lượng điểm
                        input = TienIch.DiemThuongKhachHang_TO_DiemThuongKhachHang(item);
                        input.ThaoTac = "CapNhat";
                        input.TongDiem += sodiemthuong(double.Parse(tien.Replace(",", "")));
                        input.DiemConLai = input.TongDiem - input.DiemDaDung;
                        break;
                    }
                }
                if (input == null)
                {//thêm mới trường điểm thường khách hàng
                    input = new Entities.DiemThuongKhachHang();
                    input.ThaoTac = "insert";
                    input.MaDiemThuongKhachHang = ProIDDTKH("DiemThuongKhachHang");
                    input.MaKhachHang = maKH;
                    input.TenKhachHang = LayTenKhachHang(maKH);
                    input.TongDiem = sodiemthuong(double.Parse(tien.Replace(",", "")));
                    input.DiemDaDung = 0;
                    input.DiemConLai = input.TongDiem;
                    input.GhiChu = "";
                    input.Deleted = false;

                    cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    clientstrem = cl.SerializeObj(this.client1, "DiemThuongKhachHang", input);
                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(clientstrem, msg);
                    if (msg != 0)
                        return true;
                    else
                        return false;
                }
                else
                {//Cập nhật điểm thưởng cho khách hàng
                    cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    clientstrem = cl.SerializeObj(this.client1, "DiemThuongKhachHang", input);
                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(clientstrem, msg);
                    if (msg != 0)
                        return true;
                    else
                        return false;
                }

            }
            catch { return false; }
        }
        #endregion

        Entities.KhuyenMaiSoLuong[] kmSoLuong;
        public TcpClient client1;
        public NetworkStream clientstrem;
        public static string trave = "";
        Entities.QuyDoiDonViTinh[] quidoidvt;
        Entities.GoiHang[] goihang;
        Entities.ChiTietGoiHang[] chitietgoihang;
        DateTime datesv;
        Entities.HangHoa[] hangHoaTheoKho;
        Entities.Thue[] thue;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        public frmXuLyBanLe()
        {
            InitializeComponent();
            datesv = DateServer.Date();
            this.kmSoLuong = GetData();
        }
        string str;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        /// <param name="str"></param>
        public frmXuLyBanLe(string str)
        {
            try
            {
                InitializeComponent();
                //
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.CapNhatGia pt = new Entities.CapNhatGia("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                cngkh = new Entities.CapNhatGia[1];
                clientstrem = cl.SerializeObj(this.client1, "CapNhatGia", pt);
                // đổ mảng đối tượng vào datagripview       
                cngkh = (Entities.CapNhatGia[])cl.DeserializeHepper1(clientstrem, cngkh);
                if (cngkh == null)
                    cngkh = new Entities.CapNhatGia[0];
                //
                datesv = DateServer.Date();
                toolStripStatusLabel3.Enabled = false;
                dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                this.str = str;
                TheVip();
                try
                {
                    LayKhoHang();
                    new Common.Utilities().ComboxKhoHang(cbbkhohang);
                }
                catch
                {
                }
                datesv = DateServer.Date();
                cbxHinhthucthanhtoan.SelectedIndex = 0;
                mskngaychungtu.Text = new Common.Utilities().XuLy(2, datesv.ToShortDateString());
                lbnhanvien.Text = Common.Utilities.User.TenNhanVien;
                //
                this.KhoiTao();
                this.kmSoLuong = GetData();
            }
            catch
            {

            }
        }


        public void KhoiTao()
        {
            try
            {
                //
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("BanBuon");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                selectall = (Entities.SelectAll)cl.DeserializeHepper(clientstrem, selectall);
                // gói hàng
                goihang = selectall.GoiHang;

                // chi tiết gói hàng
                chitietgoihang = selectall.ChiTietGoiHang;

                // quy đổi đơn vị tính
                quidoidvt = selectall.QuyDoiDonViTinh;


                // lay hang hoa the kho
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                List<Entities.HangHoa> array = new List<Entities.HangHoa>();
                cl = new Server_Client.Client();

                Entities.HangHoa kh = new Entities.HangHoa();
                Entities.TruyenGiaTri khoHang = (Entities.TruyenGiaTri)cbbkhohang.SelectedItem;
                string makho = khoHang.Giatritruyen;
                kh = new Entities.HangHoa("SelectTheoKho", makho);
                clientstrem = cl.SerializeObj(this.client1, "HangHoa", kh);
                Entities.HangHoa[] hhArr = new Entities.HangHoa[1];
                hhArr = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, hhArr);

                if (hhArr == null)
                    hangHoaTheoKho = new Entities.HangHoa[0];

                if (hhArr.Length > 0)
                {
                    //
                    array = hhArr.ToList();
                    //
                    Entities.HangHoa[] save = Common.Utilities.CheckGoiHang(hhArr, goihang, chitietgoihang);
                    if (save != null)
                    {
                        foreach (Entities.HangHoa item in save)
                        {
                            array.Add(item);
                        }
                    }
                    // lay hang hoa theo kho
                    this.hangHoaTheoKho = array.ToArray();

                    // Lay Thue
                    cl = new Server_Client.Client();

                    Entities.Thue thueTemp = new Entities.Thue();
                    thueTemp = new Entities.Thue("Select");
                    clientstrem = cl.SerializeObj(this.client1, "Thue", thueTemp);
                    this.thue = new Entities.Thue[1];
                    thue = (Entities.Thue[])cl.DeserializeHepper1(clientstrem, thue);
                    if (thue == null)
                        thue = new Entities.Thue[0];
                }
            }
            catch
            {

            }
        }

        #region Lay Gia Trong phan km theo so luong

        /// <summary>
        /// GetData
        /// </summary>
        /// <param name="maHangHoa"></param>
        /// <returns></returns>
        public Entities.KhuyenMaiSoLuong[] GetData()
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
                item.HanhDong = "SelectAll";
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
        /// LayGia
        /// </summary>
        /// <param name="maHangHoa"></param>
        /// <param name="sl"></param>
        /// <param name="ngayLapHD"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public Entities.KhuyenMaiSoLuong LayGia(string maHangHoa, string sl, DateTime ngayLapHD, Entities.KhuyenMaiSoLuong[] source)
        {
            Entities.KhuyenMaiSoLuong retVal = null;
            try
            {
                Entities.KhuyenMaiSoLuong[] temp = frmXuLyHangHoa.GetSource(maHangHoa, source);
                temp = frmXuLyHangHoa.SapXep(temp);
                retVal = frmXuLyHangHoa.GetDonGia(maHangHoa, sl, ngayLapHD, temp);
            }
            catch
            {
                retVal = null;
            }

            return retVal;
        }

        #endregion

        public Entities.GiaVon[] GiaVon()
        {
            Entities.GiaVon[] giaVon = null;
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                ArrayList KArr = new ArrayList();
                KArr.Add("SelectTheoDieuKien_GiaVon");
                KArr.Add("Select_GIAVON");
                KArr.Add(new Entities.GiaVon());
                KArr.Add(new Entities.GiaVon());
                clientstrem = cl.SerializeObj(this.client1, "GiaVon_k", KArr);
                ////// đổ mảng đối tượng vào datagripview     
                giaVon = (Entities.GiaVon[])cl.DeserializeHepper1(clientstrem, giaVon);
                if (giaVon == null)
                {
                    giaVon = new Entities.GiaVon[0];
                }
            }
            catch (Exception)
            {
            }

            return giaVon;
        }

        public void GiaVonBanHang(Entities.ChiTietHDBanHang[] ct)
        {
            try
            {
                List<Entities.GiaVonBanHang> gvbhArr = new List<Entities.GiaVonBanHang>();
                Entities.GoiHang[] goiHang = this.goihang;
                Entities.GiaVon[] gv = GiaVon();
                bool isHangHoa = false;

                foreach (Entities.ChiTietHDBanHang bh in ct)
                {
                    Entities.GiaVonBanHang gvbh = new Entities.GiaVonBanHang();
                    foreach (Entities.GiaVon item in gv)
                    {
                        if (item.MaHangHoa.Equals(bh.MaHangHoa))
                        {
                            gvbh.HanhDong = "Insert";
                            gvbh.MaHangHoa = bh.MaHangHoa;
                            gvbh.MaHoaDon = bh.MaHDBanHang;
                            gvbh.GiaVon = item.Gia;
                            gvbhArr.Add(gvbh);
                            isHangHoa = true;
                            break;
                        }
                    }
                    // neu ko phai la hang hoa thi la gia von trong goi hang
                    if (!isHangHoa)
                    {
                        gvbh = GetGVGoiHang(bh.MaHDBanHang, bh.MaHangHoa, goiHang);

                        if (gvbh != null)
                            gvbhArr.Add(gvbh);
                    }
                }

                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                foreach (Entities.GiaVonBanHang item in gvbhArr.ToArray())
                {
                    clientstrem = cl.SerializeObj(this.client1, "GiaVonBanHang", item);
                }
                // đổ mảng đối tượng vào datagripview
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// GetGVGoiHang
        /// </summary>
        /// <param name="maGoi"></param>
        /// <param name="gh"></param>
        /// <returns></returns>
        public Entities.GiaVonBanHang GetGVGoiHang(string maHD, string maGoi, Entities.GoiHang[] gh)
        {
            Entities.GiaVonBanHang retVal = null;
            try
            {
                foreach (Entities.GoiHang item in gh)
                {
                    if (item.MaGoiHang.Trim().ToUpper().Equals(maGoi.Trim().ToUpper()))
                    {
                        retVal = new Entities.GiaVonBanHang();
                        retVal.HanhDong = "Insert";
                        retVal.MaHangHoa = maGoi.Trim().ToUpper();
                        retVal.MaHoaDon = maHD.Trim().ToUpper();
                        retVal.GiaVon = double.Parse(item.GiaNhap);
                        break;
                    }
                }
            }
            catch
            {
                retVal = null;
            }

            return retVal;
        }

        string id, sochungtu, datetime, makh, khoban, nhanvien, ghichu, hinhthucthanhtoan, chietkhau, gtgt, tongtien;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        /// <param name="str"></param>
        /// <param name="dtgvr"></param>
        public frmXuLyBanLe(string str, DataGridViewRow dtgvr)
        {
            try
            {
                InitializeComponent(); datesv = DateServer.Date();
                dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                LayKhoHang();
                palNhap.Enabled = palThem.Enabled = palXem.Enabled = tsslthem.Enabled = false;
                this.str = str;
                id = dtgvr.Cells["HDBanHangID"].Value.ToString();
                txtSochungtu.Text = dtgvr.Cells["MaHDBanHang"].Value.ToString();
                SelectData();

                mskngaychungtu.Text = new Common.Utilities().XuLy(2, dtgvr.Cells["NgayBan"].Value.ToString());
                txtMakhachhang.Text = dtgvr.Cells["MaKhachHang"].Value.ToString();
                lblTenKH.Text = dtgvr.Cells["TenKhachHang"].Value.ToString();
                cbxHinhthucthanhtoan.Text = dtgvr.Cells["HinhThucThanhToan"].Value.ToString();
                lbnhanvien.Text = dtgvr.Cells["MaNhanVien"].Value.ToString();
                string maKho = dtgvr.Cells["MaKho"].Value.ToString();
                cbbkhohang.Text = LayTenKho(maKho);
                if (dtgvr.Cells["MaThe"].Value != null)
                    txtMaTheVip.Text = dtgvr.Cells["MaThe"].Value.ToString();

                if (dtgvr.Cells["MaTheGiaTri"].Value != null)
                    txtMaTheGT.Text = dtgvr.Cells["MaTheGiaTri"].Value.ToString();



                double ptckTongHD = 0;
                double gtckTongHD = 0;
                double tongCK = 0;
                double khachtra = 0;
                double khackPhaiTra = 0;
                double tienHang = 0;
                double tongTien = 0;
                double duTra = 0;
                double tongGTGT = 0;
                double tongTienGomVAT = 0;
                double giaTriThe = 0;
                double giaTriTheGT = 0;

                if (dtgvr.Cells["GiaTriThe"].Value != null)
                    giaTriThe = double.Parse(dtgvr.Cells["GiaTriThe"].Value.ToString());

                if (dtgvr.Cells["GiaTriTheGiaTri"].Value != null)
                    giaTriTheGT = double.Parse(dtgvr.Cells["GiaTriTheGiaTri"].Value.ToString());

                if (dtgvr.Cells["KhachTra"].Value != null)
                    khachtra = double.Parse(dtgvr.Cells["KhachTra"].Value.ToString());

                if (dtgvr.Cells["ChietKhauTongHoaDon"].Value != null)
                    ptckTongHD = double.Parse(dtgvr.Cells["ChietKhauTongHoaDon"].Value.ToString());

                if (dtgvr.Cells["ChietKhau"].Value != null)
                    tongCK = double.Parse(dtgvr.Cells["ChietKhau"].Value.ToString());

                if (dtgvr.Cells["ThueGTGT"].Value != null)
                    tongGTGT = double.Parse(dtgvr.Cells["ThueGTGT"].Value.ToString());

                tienHang = double.Parse(TinhTien(dtgvsanpham));
                tongTienGomVAT = tienHang - tongCK + tongGTGT;
                gtckTongHD = (ptckTongHD * tongTienGomVAT) / 100;
                tongTien = tongTienGomVAT - gtckTongHD;
                khackPhaiTra = tongTien - giaTriThe - giaTriTheGT;
                duTra = khachtra - khackPhaiTra;

                if (giaTriThe + giaTriTheGT > tongTien)
                {
                    khachtra = 0;
                    duTra = 0;
                    khackPhaiTra = 0;
                }

                txtTongtien.Text = new Common.Utilities().FormatMoney(tongTien);
                txtTienhang.Text = new Common.Utilities().FormatMoney(tienHang);
                txtGiamgia.Text = new Common.Utilities().FormatMoney(tongCK);
                txtGTGT.Text = new Common.Utilities().FormatMoney(tongGTGT);
                txtkhachtra.Text = new Common.Utilities().FormatMoney(khachtra);
                txtdutra.Text = new Common.Utilities().FormatMoney(duTra);
                txtPhantramchietkhau.Text = new Common.Utilities().FormatMoney(ptckTongHD);
                txtChietkhau.Text = new Common.Utilities().FormatMoney(gtckTongHD);
                txtGTTheVip.Text = new Common.Utilities().FormatMoney(giaTriThe);
                txtGTTheGT.Text = new Common.Utilities().FormatMoney(giaTriTheGT);
                txtKhachPhaiTra.Text = new Common.Utilities().FormatMoney(khackPhaiTra);


                grbDataGridview.Enabled = false;
            }
            catch (Exception ex)
            {

            }
        }

        Entities.TheVip[] thevip;
        public void TheVip()
        {
            cl = new Server_Client.Client();

            // gán TCPclient
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            // khởi tạo biến truyền vào với hàm khởi tạo
            Entities.TheVip pt = new Entities.TheVip("Select");
            clientstrem = cl.SerializeObj(this.client1, "LayTheVip", pt);
            // đổ mảng đối tượng vào datagripview
            thevip = (Entities.TheVip[])cl.DeserializeHepper1(clientstrem, thevip);
            if (thevip == null)
                thevip = new Entities.TheVip[0];

        }
        Entities.TheGiamGia[] thegiagiam;
        public void TheGiamGia()
        {
            cl = new Server_Client.Client();

            // gán TCPclient
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            // khởi tạo biến truyền vào với hàm khởi tạo
            Entities.TheGiamGia pt = new Entities.TheGiamGia();
            pt.HanhDong = "Select";
            clientstrem = cl.SerializeObj(this.client1, "TheGiamGia", pt);
            // đổ mảng đối tượng vào datagripview
            thegiagiam = (Entities.TheGiamGia[])cl.DeserializeHepper1(clientstrem, thegiagiam);
            if (thegiagiam == null)
                thegiagiam = new Entities.TheGiamGia[0];
        }
        /// <summary>
        /// select dữ liệu
        /// </summary>
        public void SelectData()
        {
            try
            {
                cl = new Server_Client.Client();

                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ChiTietHDBanHang pt = new Entities.ChiTietHDBanHang("Select", txtSochungtu.Text);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.ChiTietHDBanHang[] pt1 = new Entities.ChiTietHDBanHang[1];
                clientstrem = cl.SerializeObj(this.client1, "ChiTietHDBanHang", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.ChiTietHDBanHang[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 == null)
                {

                    dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                    return;
                }

                Entities.ChiTietHDBanHang[] pt2 = new Entities.ChiTietHDBanHang[pt1.Length];
                int sotang = 0;
                for (int j = 0; j < pt1.Length; j++)
                {
                    if (pt1[j].Deleted == false)
                    {
                        if (pt1[j].MaHDBanHang == txtSochungtu.Text)
                        {
                            pt2[sotang] = pt1[j];
                            sotang++;
                        }
                    }
                }
                Entities.HangHoaHienThi[] hhht = new Entities.HangHoaHienThi[sotang];

                if (sotang != 0)
                {

                    for (int j = 0; j < sotang; j++)
                    {
                        string giasp = pt2[j].DonGia;

                        string soluongsp = pt2[j].SoLuong.ToString();
                        string thanhtien = (Convert.ToDouble(giasp) * Convert.ToDouble(soluongsp)).ToString();
                        thuegtgt = pt2[j].Thue;
                        hhht[j] = new Entities.HangHoaHienThi(pt2[j].MaHDBanHang, pt2[j].MaHangHoa.ToUpper(), pt2[j].TenHangHoa, giasp, soluongsp, pt2[j].PhanTramChietKhau.ToString(), thuegtgt, thanhtien);
                    }
                }
                else
                {
                    dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                    txtTienhang.Text = "0";
                    txtGTGT.Text = "0";
                    return;
                }
                dtgvsanpham.DataSource = hhht;
                //TinhToan();
                //if (txtPhantramchietkhau.Text == "")
                //    phantramchietkhau = "0";
                //else
                //    phantramchietkhau = txtPhantramchietkhau.Text;
                //txtChietkhau.Text = new Common.Utilities().FormatMoney(((Convert.ToDouble(phantramchietkhau) / 100) * Convert.ToDouble(txtTienhang.Text)));
                //txtTongtien.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(tongtienthanhtoan) - Convert.ToDouble(txtChietkhau.Text) - Convert.ToDouble(txtGiamgia.Text));
                //txtkhachtra.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(txtTongtien.Text) - Convert.ToDouble(txtgiatrithe.Text)); string khachtra = "0";
                //if (txtkhachtra.Text == "")
                //    khachtra = "0";
                //else
                //    khachtra = txtkhachtra.Text;
                //if (Convert.ToDouble(txtTongtien.Text) >= Convert.ToDouble(txtgiatrithe.Text))
                //    txtdutra.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(khachtra) - Convert.ToDouble(txtTongtien.Text) + Convert.ToDouble(txtgiatrithe.Text));
                //else
                //    txtdutra.Text = txtkhachtra.Text; dtgvsanpham.Rows[0].Selected = true;

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
        public void fix()
        {
            dtgvsanpham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvsanpham.ReadOnly = true;
            dtgvsanpham.RowHeadersVisible = false;
            dtgvsanpham.Columns["MaHDBanHang"].Visible = false;
            dtgvsanpham.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
            dtgvsanpham.Columns["TenHang"].HeaderText = "Tên Hàng";
            dtgvsanpham.Columns["DonGia"].HeaderText = "Đơn Giá";
            dtgvsanpham.Columns["SoLuong"].HeaderText = "Số Lượng";
            dtgvsanpham.Columns["ChietKhau"].HeaderText = "Khuyến Mại (%)";
            dtgvsanpham.Columns["ThueGTGT"].HeaderText = "Thuế GTGT";
            dtgvsanpham.Columns["ThanhTien"].HeaderText = "Thành Tiền (chưa GTGT)";
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
                if (hh1 == null)
                    hh1 = new Entities.HangHoa[0];
            }
            catch (Exception ex)
            {

            }
            finally
            {


            }
        }
        /// <summary>
        /// lấy tên sản phẩm
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
        /// lấy giá sản phẩm
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
                            gia = hh1[j].GiaBanLe.ToString();
                            break;
                        }
                    }
                }
                return gia;
            }
            catch (Exception ex)
            {

            } return "";
        }
        /// <summary>
        /// lấy thuế sản phẩm
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string LayThueSanPham(string str)
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
                            gia = hh1[j].MaThueGiaTriGiaTang.ToString();
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
        Entities.SelectAll selectall;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        public void XuLyStr()
        {
            if (str == "Them")
            {
                this.Text = "Thêm Mới - F4 Thêm Hàng Hóa - F5 Thanh toán - F6 Sửa Hàng Hóa - F7 Nhập Chiết Khấu - F8 Nhập Thẻ Vip";
                sochungtu = txtSochungtu.Text = ProID("HDBanHang");
                dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
            }
            else if (str == "Sua")
            {
                this.Text = "Quản Lý Bán Lẻ - Sửa Hóa Đơn Bán Hàng";
            }
        }

        Entities.HDBanHang[] hdbh;
        /// <summary>
        /// xử lý lấy giá trị id cuối cùng
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
                lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, hdbh);
                if (lid == null)
                    return "HDBH_0001";
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// xử lý đóng form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
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
        /// Form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXuLy_BanLe_Load(object sender, EventArgs e)
        {
            try
            {
                XuLyStr();
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
        /// <summary>
        /// xử lý giá trị nhập vào
        /// </summary>
        /// <returns></returns>
        public bool KiemTra()
        {
            if (cbbkhohang.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập Kho hàng", "Hệ thống cảnh báo");
                cbbkhohang.Focus();
                return false;
            }
            if (cbxHinhthucthanhtoan.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập Hình thức thanh toán", "Hệ thống cảnh báo");
                cbxHinhthucthanhtoan.Focus();
                return false;
            }
            if (dtgvsanpham.DataSource == null)
            {
                MessageBox.Show("Bạn cần phải nhận Đơn hàng", "Hệ thống cảnh báo");
                return false;
            }
            if (dtgvsanpham.RowCount == 0)
            {
                MessageBox.Show("Bạn cần phải nhận Đơn hàng", "Hệ thống cảnh báo");
                return false;
            }
            return true;
        }
        /// <summary>
        /// tìm khách hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimmakhachhang_Click(object sender, EventArgs e)
        {
            try
            {
                frmTimKH tkh = new frmTimKH("PhieuTTCuaKH");
                tkh.ShowDialog();
                if (frmTimKH.drvr != null)
                {
                    txtMakhachhang.Text = frmTimKH.drvr.Cells["MaKH"].Value.ToString();
                    lblTenKH.Text = frmTimKH.drvr.Cells["Ten"].Value.ToString();
                    frmTimKH.drvr = null;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// GetKH
        /// </summary>
        /// <param name="maKH"></param>
        /// <returns></returns>
        public Entities.KhachHang GetKH(string maKH)
        {
            Entities.KhachHang retVal = null;
            try
            {
                Server_Client.Client cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.KhachHang kh = new Entities.KhachHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.KhachHang[] kh1 = new Entities.KhachHang[1];
                clientstrem = cl.SerializeObj(this.client1, "KhachHang", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.KhachHang[])cl.DeserializeHepper1(clientstrem, kh1);
                foreach (Entities.KhachHang item in kh1)
                {
                    if (item.MaKH.Trim().ToUpper().Equals(maKH.Trim().ToUpper()))
                    {
                        retVal = item;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                retVal = null;
            }

            return retVal;
        }



        Server_Client.Client cl;
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
                if (kh1 == null)
                    kh1 = new Entities.KhoHang[0];
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
            finally
            {


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
            }
            catch
            {
            }
            return "";
        }
        /// <summary>
        /// lấy tên kho
        /// </summary>
        /// <param name="maKho"></param>
        /// <returns></returns>
        public string LayTenKho(string maKho)
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
        /// <summary>
        /// xử lý option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void thiêtLâpThôngSôToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        Entities.HangHoaHienThi[] hh;
        /// <summary>
        /// xử lý thêm row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbkhohang.Text.Length == 0)
                {
                    MessageBox.Show("Chưa có Kho hàng", "Hệ thống cảnh báo");
                    cbbkhohang.Focus();
                    return;
                }
                if (tsslsoluong.Text.Length == 0)
                {
                    MessageBox.Show("Chưa nhập số lượng hàng", "Hệ thống cảnh báo");
                    tsslsoluong.Focus();
                    return;
                }

                if (tssltenhang.Text.Length == 0)
                {
                    MessageBox.Show("Chưa có tên hàng", "Hệ thống cảnh báo");
                    return;
                }
                // Qui đổi đơn vị tính
                foreach (Entities.QuyDoiDonViTinh item in quidoidvt)
                {
                    if (item.MaHangQuyDoi == mahanghoa)
                    {
                        mahanghoa = toolStrip_txtTracuu.Text = item.MaHangDuocQuyDoi.ToUpper();
                        tssltenhang.Text = item.TenHangDuocQuyDoi;
                        tsslsoluong.Text = (item.SoLuongDuocQuyDoi * int.Parse(tsslsoluong.Text)).ToString();
                        break;

                    }
                }
                LayHangHoaTheoMa();
                NewRow();
                toolStrip_txtTracuu.ReadOnly = false;
            }
            catch
            {
            }
        }
        string tongtienthanhtoan = "";




        /// <summary>
        /// tính toán
        /// </summary>
        public void TinhToan()
        {
            try
            {
                txtTienhang.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(TinhTien(dtgvsanpham)));
                txtGTGT.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(TinhThue(dtgvsanpham)));
                tongtienthanhtoan = (Convert.ToDouble(txtTienhang.Text) + Convert.ToDouble(txtGTGT.Text)).ToString();
                txtGiamgia.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(TinhCK(dtgvsanpham)));
            }
            catch
            {
            }
        }
        /// <summary>
        /// method thêm row
        /// </summary>
        public void NewRow()
        {
            try
            {
                string kt1 = "";

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
                        kt1 = "";
                        if (hh.Length == dtgvsanpham.RowCount)
                        {

                            for (int j = 0; j < hh.Length; j++)
                            {
                                if (mahanghoa == dtgvsanpham[1, j].Value.ToString())
                                {
                                    int soluongcu = Convert.ToInt32(dtgvsanpham[4, j].Value.ToString());
                                    string sl = "0";
                                    if (tsslsoluong.Text == "")
                                        sl = "1";
                                    else
                                        sl = tsslsoluong.Text;
                                    int soluongmoi = Convert.ToInt32(sl);
                                    int soluonghientai = soluongcu + soluongmoi;
                                    string giasp = "0";
                                    // Lay gia san pham
                                    DateTime ngayBan = DateTime.Parse(new Common.Utilities().MyDateConversion(mskngaychungtu.Text));
                                    Entities.KhuyenMaiSoLuong giaTheoSL = LayGia(mahanghoa, soluonghientai.ToString(), ngayBan, this.kmSoLuong);

                                    if (giaTheoSL != null)
                                        giasp = giaTheoSL.GiaBanLe.ToString();
                                    else
                                        giasp = new Common.Utilities().FormatMoney(double.Parse(dtgvsanpham[3, j].Value.ToString()));

                                    string thanhtien = new Common.Utilities().FormatMoney((Convert.ToDouble(soluonghientai) * Convert.ToDouble(giasp)));
                                    hh[j] = new Entities.HangHoaHienThi(txtSochungtu.Text, dtgvsanpham[1, j].Value.ToString(), dtgvsanpham[2, j].Value.ToString(), giasp, soluonghientai.ToString(), dtgvsanpham[5, j].Value.ToString(), dtgvsanpham[6, j].Value.ToString(), thanhtien);
                                    kt1 = "ok";
                                }
                                else
                                    hh[j] = new Entities.HangHoaHienThi(txtSochungtu.Text, dtgvsanpham[1, j].Value.ToString(), dtgvsanpham[2, j].Value.ToString(), dtgvsanpham[3, j].Value.ToString(), dtgvsanpham[4, j].Value.ToString(), dtgvsanpham[5, j].Value.ToString(), dtgvsanpham[6, j].Value.ToString(), dtgvsanpham[7, j].Value.ToString());

                            }
                        }
                        else
                        {
                            for (int j = 0; j < hh.Length; j++)
                            {
                                if (j < hh.Length - 1)
                                    hh[j] = new Entities.HangHoaHienThi(txtSochungtu.Text, dtgvsanpham[1, j].Value.ToString(), dtgvsanpham[2, j].Value.ToString(), dtgvsanpham[3, j].Value.ToString(), dtgvsanpham[4, j].Value.ToString(), dtgvsanpham[5, j].Value.ToString(), dtgvsanpham[6, j].Value.ToString(), dtgvsanpham[7, j].Value.ToString());
                                else
                                {

                                    string sl = "0";
                                    if (tsslsoluong.Text == "")
                                        sl = "1";
                                    else
                                        sl = tsslsoluong.Text;
                                    string soluongsp = sl;
                                    string giasp = "0";
                                    // Lay gia san pham
                                    DateTime ngayBan = DateTime.Parse(new Common.Utilities().MyDateConversion(mskngaychungtu.Text));
                                    Entities.KhuyenMaiSoLuong giaTheoSL = LayGia(mahanghoa, soluongsp.ToString(), ngayBan, this.kmSoLuong);

                                    if (giaTheoSL != null)
                                        giasp = giaTheoSL.GiaBanLe.ToString();
                                    else
                                        giasp = new Common.Utilities().FormatMoney(double.Parse(tsslgia.Text));

                                    string thanhtien = new Common.Utilities().FormatMoney((Convert.ToDouble(giasp) * Convert.ToDouble(soluongsp)));
                                    hh[hh.Length - 1] = new Entities.HangHoaHienThi(txtSochungtu.Text, mahanghoa, tssltenhang.Text, giasp, soluongsp, tsslchietkhau.Text, tsslgtgt.Text, thanhtien);
                                }


                            }
                        }
                        if (kt1 == "")
                        {
                            string sl = "0";
                            if (tsslsoluong.Text == "")
                                sl = "1";
                            else
                                sl = tsslsoluong.Text;
                            string soluongsp = sl;
                            string giasp = "0";
                            // Lay gia san pham
                            DateTime ngayBan = DateTime.Parse(new Common.Utilities().MyDateConversion(mskngaychungtu.Text));
                            Entities.KhuyenMaiSoLuong giaTheoSL = LayGia(mahanghoa, soluongsp.ToString(), ngayBan, this.kmSoLuong);

                            if (giaTheoSL != null)
                                giasp = giaTheoSL.GiaBanLe.ToString();
                            else
                                giasp = new Common.Utilities().FormatMoney(double.Parse(tsslgia.Text));

                            string thanhtien = new Common.Utilities().FormatMoney((Convert.ToDouble(giasp) * Convert.ToDouble(soluongsp)));
                            hh[hh.Length - 1] = new Entities.HangHoaHienThi(txtSochungtu.Text, mahanghoa, tssltenhang.Text, giasp, soluongsp, tsslchietkhau.Text, tsslgtgt.Text, thanhtien);
                        }
                    }
                    catch (Exception ex)
                    {
                        string sl = "0";
                        if (tsslsoluong.Text == "")
                            sl = "1";
                        else
                            sl = tsslsoluong.Text;
                        string soluongsp = sl;
                        string giasp = "0";
                        // Lay gia san pham
                        DateTime ngayBan = DateTime.Parse(new Common.Utilities().MyDateConversion(mskngaychungtu.Text));
                        Entities.KhuyenMaiSoLuong giaTheoSL = LayGia(mahanghoa, soluongsp.ToString(), ngayBan, this.kmSoLuong);

                        if (giaTheoSL != null)
                            giasp = giaTheoSL.GiaBanLe.ToString();
                        else
                            giasp = new Common.Utilities().FormatMoney(double.Parse(tsslgia.Text));
                        string thanhtien = new Common.Utilities().FormatMoney((Convert.ToDouble(giasp) * Convert.ToDouble(soluongsp)));
                        hh[0] = new Entities.HangHoaHienThi(txtSochungtu.Text, mahanghoa, tssltenhang.Text, giasp, soluongsp, tsslchietkhau.Text, tsslgtgt.Text, thanhtien);
                    }

                    dtgvsanpham.DataSource = hh;
                    TinhToan();
                    if (txtPhantramchietkhau.Text == "")
                        phantramchietkhau = "0";
                    else
                        phantramchietkhau = txtPhantramchietkhau.Text;
                    txtChietkhau.Text = new Common.Utilities().FormatMoney(((Convert.ToDouble(phantramchietkhau) / 100) * Convert.ToDouble(txtTienhang.Text)));
                    txtTongtien.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(tongtienthanhtoan) - Convert.ToDouble(txtChietkhau.Text) - Convert.ToDouble(txtGiamgia.Text));
                    txtKhachPhaiTra.Text = txtTongtien.Text;
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
                    toolStrip_txtTracuu.Text = "<F4 - Tra Cứu>";
                    tssltenhang.Text = "";
                    tsslsoluong.Text = "";
                    tsslgia.Text = "0";
                    tsslchietkhau.Text = "0";
                    tsslgtgt.Text = "0";
                }
                catch
                {
                }
            }
        }
        private bool testCharacter(char ch)
        {
            char[] a = new char[]{'+','-','~','`','@','#','$','%','^','&','*','(',')','{','}','[',']',':',';','|',
                '<','>',',','.','?','/','-','=',
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
        string mahanghoa, phantramchietkhau;
        /// <summary>
        /// xử lý khi ấn phím
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_txtTracuu_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F4)
                {
                    if (cbbkhohang.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn hãy nhập Kho hàng", "Hệ thống cảnh báo");
                        return;
                    }
                    string maKho = LayMaKho(cbbkhohang.Text);
                    frmTimHangHoa thh = new frmTimHangHoa(maKho, true);
                    thh.ShowDialog();
                    if (frmTimHangHoa.drvr != null)
                    {
                        mahanghoa = toolStrip_txtTracuu.Text = frmTimHangHoa.drvr.Cells["MaHangHoa"].Value.ToString().ToUpper();
                        tssltenhang.Text = frmTimHangHoa.drvr.Cells["TenHangHoa"].Value.ToString();
                        tsslgia.Text = frmTimHangHoa.drvr.Cells["GiaBanLe"].Value.ToString();
                        try
                        {
                            //SelectMaCapNhatKH();
                            KiemTraCK(cngkh);
                        }
                        catch
                        {
                            phantramchietkhau = tsslchietkhau.Text = "0";
                        }
                        LayGiaTriThue(frmTimHangHoa.drvr.Cells["MaThueGiaTriGiaTang"].Value.ToString());
                        toolStrip_txtTracuu.ReadOnly = true;
                        tsslsoluong.Focus();
                        frmTimHangHoa.drvr = null;
                    }
                    else
                        toolStrip_txtTracuu.ReadOnly = false;
                }
                if (e.KeyCode == Keys.Enter)
                {
                    if (toolStrip_txtTracuu.Text.Length > 0)
                    {

                        if (cbbkhohang.Text.Length == 0)
                        {
                            MessageBox.Show("Bạn hãy nhập Kho hàng", "Hệ thống cảnh báo");
                            toolStrip_txtTracuu.Text = "";
                            return;
                        }

                        foreach (char ch in toolStrip_txtTracuu.Text)
                        {
                            if (testCharacter(ch))
                            {
                                MessageBox.Show("        Mã Hàng Hóa Không được nhập tiếng việt có dấu " +
                                              "\nNếu bạn đang dùng máy quét mã vạch hãy tắt bộ gõ Tiếng Tiệt đi! ", "Hệ Thống Cảnh Báo");
                                toolStrip_txtTracuu.Focus();
                                toolStrip_txtTracuu.SelectAll();
                                return;
                            }
                        }
                        mahanghoa = toolStrip_txtTracuu.Text;
                        bool kt = true;
                        // Qui đổi đơn vị tính
                        foreach (Entities.QuyDoiDonViTinh item in quidoidvt)
                        {
                            if (item.MaHangQuyDoi == mahanghoa)
                            {
                                tssltenhang.Text = item.TenHangDuocQuyDoi;
                                tsslsoluong.Focus();
                                kt = false;
                                break;

                            }
                        }

                        if (tssltenhang.Text.Length == 0)
                        {
                            //MessageBox.Show("Hàng hóa không có trong kho", "Hệ thống cảnh báo");
                            //return;
                        }
                        if (kt)
                            LayHangHoaTheoMa();
                    }
                }
                if (e.KeyCode == Keys.F5)
                {
                    txtkhachtra.Focus();
                }
                if (e.KeyCode == Keys.F6)
                {
                    dtgvsanpham.Focus();
                }
                if (e.KeyCode == Keys.F7)
                {
                    txtPhantramchietkhau.Focus();
                }
            }
            catch
            {
            }
        }
        private void txt_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F5 || e.KeyCode == Keys.Enter)
                {
                    txtkhachtra.Focus();
                }
            }
            catch { }
        }
        int i;

        bool kt = false;
        /// <summary>
        /// check kiểm tra trước khi insert
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
                Entities.HDBanHang pt = new Entities.HDBanHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.HDBanHang[] pt1 = new Entities.HDBanHang[1];
                clientstrem = cl.SerializeObj(this.client1, "HDBanHang", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.HDBanHang[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 != null)
                {
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        if (pt1[j].MaHDBanHang == sochungtu)
                        {
                            //MessageBox.Show("cập nhật mã phiếu - kiểm tra lại để insert");
                            kt = true;
                            sochungtu = txtSochungtu.Text = ProID("HDBanHang");
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
                kt = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.HDBanHang pt = new Entities.HDBanHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.HDBanHang[] pt1 = new Entities.HDBanHang[1];
                clientstrem = cl.SerializeObj(this.client1, "HDBanHang", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.HDBanHang[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 != null)
                {
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        if (pt1[j].MaHDBanHang == sochungtu)
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
        /// kiểm tra giá trị nhập vào
        /// </summary>
        /// <param name="pxh"></param>
        /// <returns></returns>
        public bool Check(Entities.HDBanHang pxh)
        {
            bool gt = true;
            string datetimenew = new Common.Utilities().XuLy(2, (Convert.ToDateTime(pxh.NgayBan).ToShortDateString()));
            if (datetime != datetimenew)
            {
                datetime = mskngaychungtu.Text = datetimenew;
                gt = false;
            }
            if (hinhthucthanhtoan != pxh.HinhThucThanhToan)
            {
                hinhthucthanhtoan = cbxHinhthucthanhtoan.Text = pxh.HinhThucThanhToan;
                gt = false;
            }
            if (khoban != pxh.MaKho)
            {
                khoban = cbbkhohang.Text = pxh.MaKho;
                gt = false;
            }
            if (nhanvien != pxh.MaNhanVien)
            {
                nhanvien = lbnhanvien.Text = pxh.MaNhanVien;
                gt = false;
            }
            if (chietkhau != pxh.ChietKhau)
            {
                chietkhau = txtChietkhau.Text = pxh.ChietKhau;
                gt = false;
            }
            if (gtgt != pxh.ThueGTGT)
            {
                gtgt = txtGTGT.Text = pxh.ThueGTGT;
                gt = false;
            }
            if (tongtien != pxh.TongTienThanhToan)
            {
                tongtien = txtTongtien.Text = pxh.TongTienThanhToan;
                gt = false;
            }
            if (ghichu != pxh.GhiChu)
            {
                ghichu = txtDiengiai.Text = pxh.GhiChu;
                gt = false;
            }
            return gt;
        }
        /// <summary>
        /// kiểm tra dtgv trước khi update
        /// </summary>
        /// <param name="dgv"></param>
        public Entities.ChiTietHDBanHang[] CheckDataGridInsert(DataGridView dgv)
        {
            bool kkt = false;
            try
            {
                if (dgv.RowCount != 0)
                {
                    Entities.ChiTietHDBanHang[] cthdbh = new Entities.ChiTietHDBanHang[dgv.RowCount];
                    for (int j = 0; j < cthdbh.Length; j++)
                    {
                        cthdbh[j] = new Entities.ChiTietHDBanHang("InsertUpdate", txtSochungtu.Text, dgv[1, j].Value.ToString(), int.Parse(dgv[4, j].Value.ToString()), int.Parse(dgv[5, j].Value.ToString()), "", false);
                        cthdbh[j].Thue = dgv["ThueGTGT", j].Value.ToString();
                        cthdbh[j].DonGia = dgv["DonGia", j].Value.ToString();
                        cthdbh[j].TenHangHoa = dgv["TenHang", j].Value.ToString();
                    }
                    return cthdbh;
                }
                return new Entities.ChiTietHDBanHang[0];
            }
            catch
            {
                return new Entities.ChiTietHDBanHang[0];
            }
        }

        /// <summary>
        /// nút thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslthem_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (KiemTra() == true)
                {
                    //CheckConflictInsert();
                    txtSochungtu.Text = ProID("HDBanHang");
                    kt = true;
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
                            mskngaychungtu.Focus();
                            return;
                        }
                        string khachtra = "0";
                        if (txtkhachtra.Text == "")
                            khachtra = "0";
                        else
                            khachtra = txtkhachtra.Text;
                        if (Convert.ToDouble(khachtra) < (Convert.ToDouble(txtTongtien.Text) - Convert.ToDouble(txtGTTheVip.Text) - double.Parse(txtGTTheGT.Text)))
                        {
                            lbloi.Text = "Khách trả không thể nhỏ hơn Tổng tiền";
                            return;
                        }
                        Entities.HDBanHang pt = new Entities.HDBanHang();
                        string makho = LayMaKho(cbbkhohang.Text);
                        double ttn = 0;
                        Entities.TheVip tv1 = null;
                        Entities.TheGiamGia tgg1 = null;
                        // The Vip
                        if (Convert.ToDouble(txtTongtien.Text) < Convert.ToDouble(txtGTTheVip.Text))
                        {
                            ttn = Convert.ToDouble(txtGTTheVip.Text) - Convert.ToDouble(txtTongtien.Text);
                            tv1 = new Entities.TheVip("", txtMaTheVip.Text, "", ttn.ToString(), "", "", false);
                        }
                        else
                        {
                            ttn = Convert.ToDouble(txtTongtien.Text) - Convert.ToDouble(txtGTTheVip.Text);
                            tv1 = new Entities.TheVip("", txtMaTheVip.Text, "", "0", "", "", false);
                            // The Gia Tri.
                            if (Convert.ToDouble(txtTongtien.Text) - Convert.ToDouble(txtGTTheVip.Text) < Convert.ToDouble(txtGTTheGT.Text))
                            {
                                ttn = Convert.ToDouble(txtGTTheGT.Text) - (Convert.ToDouble(txtTongtien.Text) - Convert.ToDouble(txtGTTheVip.Text));
                                tgg1 = new Entities.TheGiamGia();
                                tgg1.MaTheGiamGia = txtMaTheGT.Text;
                                tgg1.GiaTriConLai = ttn.ToString();
                            }
                            else
                            {
                                ttn = Convert.ToDouble(txtTongtien.Text) - Convert.ToDouble(txtGTTheVip.Text) - Convert.ToDouble(txtGTTheVip.Text);
                                tgg1 = new Entities.TheGiamGia();
                                tgg1.MaTheGiamGia = txtMaTheGT.Text;
                                tgg1.GiaTriConLai = "0";
                            }
                        }

                        chietkhau = (double.Parse(txtGiamgia.Text) + double.Parse(txtChietkhau.Text)).ToString();
                        string ckTongHoaDon = txtPhantramchietkhau.Text;
                        if (string.IsNullOrEmpty(txtPhantramchietkhau.Text))
                            ckTongHoaDon = "0";
                        pt = new Entities.HDBanHang("Insert", 0, txtSochungtu.Text, Convert.ToDateTime(date),
                            txtMakhachhang.Text, "0", " ", cbxHinhthucthanhtoan.Text, makho, datesv, " ",
                            Common.Utilities.User.NhanVienID, "TT_0001", txtGiamgia.Text, ttn.ToString(), "0",
                            txtGTGT.Text, txtTongtien.Text, true, txtMaTheVip.Text, txtGTTheVip.Text, txtDiengiai.Text, false,
                            Common.Utilities.User.TenDangNhap, txtkhachtra.Text, ckTongHoaDon, txtMaTheGT.Text, txtGTTheGT.Text);

                        pt.ChiTietHDBanHang = CheckDataGridInsert(dtgvsanpham);
                        pt.ChiTietKhoHangTheoHoaHonNhap = CheckDataGridTruSL(dtgvsanpham);
                        pt.TheVip = tv1;
                        pt.TheGiamGia = tgg1;
                        clientstrem = cl.SerializeObj(this.client1, "HDBanHang", pt);

                        bool kt1 = false;
                        kt1 = (bool)cl.DeserializeHepper(clientstrem, kt1);
                        if (kt1 == true)
                        {
                            //Cập nhật điểm thưởng cho khách hàng
                            if (!string.IsNullOrEmpty(txtMakhachhang.Text))
                            {
                                //Cập nhật điểm thưởng khách hàng thành công
                                bool kq = CapNhatDiemThuongKhachHang(txtMakhachhang.Text, txtTongtien.Text);
                            }
                            else
                            {
                                //Cập nhật điểm thưởng khách hàng thất bại
                            }
                            /////////////////////////////////////
                            khachtra = "0";
                            if (txtkhachtra.Text == "")
                                khachtra = "0";
                            else
                                khachtra = txtkhachtra.Text;

                            if (cbkiemtra.Checked == true)
                            {
                                frmBaoCaorpt bcrpt = new frmBaoCaorpt("HDBanLe", txtSochungtu.Text, double.Parse(txtGiamgia.Text), khachtra, txtdutra.Text, txtKhachPhaiTra.Text, txtGTGT.Text, lbnhanvien.Text, "in", mskngaychungtu.Text, txtGTTheVip.Text, txtGTTheGT.Text, "", txtChietkhau.Text, "", "", "");
                            }

                            GiaVonBanHang(pt.ChiTietHDBanHang);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại - xin thử lại", "Hệ thống cảnh báo");
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                this.Enabled = true;

            }
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
                if (KiemTra() == true)
                {
                    CheckConflictUpdate();
                    if (kt == true)
                    {
                        cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        string date = new Common.Utilities().MyDateConversion(mskngaychungtu.Text);
                        Entities.HDBanHang pt = new Entities.HDBanHang();
                        string makho = LayMaKho(cbbkhohang.Text);
                        pt = new Entities.HDBanHang("Insert", 0, txtSochungtu.Text, Convert.ToDateTime(date),
                                                    txtMakhachhang.Text, "0", " ", cbxHinhthucthanhtoan.Text, makho, datesv, " ",
                                                    Common.Utilities.User.NhanVienID, "TT_0001", txtChietkhau.Text, txtTongtien.Text, "0",
                                                    txtGTGT.Text, txtTongtien.Text, true, txtMaTheVip.Text, txtGTTheVip.Text, txtDiengiai.Text, false,
                                                    Common.Utilities.User.TenDangNhap, txtkhachtra.Text, txtPhantramchietkhau.Text, txtMaTheGT.Text, txtGTTheGT.Text);

                        clientstrem = cl.SerializeObj(this.client1, "HDBanHang", pt);
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
                    else
                        MessageBox.Show("Dữ liệu đã bị thay đổi - kiểm tra lại", "Hệ thống cảnh báo");
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
        /// xử lý khi click vào tra cứu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_txtTracuu_Click(object sender, EventArgs e)
        {
            toolStrip_txtTracuu.ReadOnly = false;
            toolStrip_txtTracuu.Text = "";
            tssltenhang.Text = "";
            tsslgia.Text = "0";
            tsslchietkhau.Text = "0";
        }
        /// <summary>
        /// xử lý khi nhập vào control soluong
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslsoluong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sl = "0";
                if (tsslsoluong.Text == "")
                    sl = "1";
                else
                    sl = tsslsoluong.Text;
                if (int.Parse(sl) > 0)
                {
                    return;
                }
                tsslsoluong.Text = "";

            }
            catch (Exception ex)
            {
                tsslsoluong.Text = "";
            }
        }
        /// <summary>
        /// xử lý khi nhập vào ô phantram
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPhantramchietkhau_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(str) && str.Equals("Them"))
            {
                txtTongtien.Text = string.Empty;
                txtChietkhau.Text = string.Empty;
                double tienHang = 0;
                double giamGia = 0;
                double thueGTGT = 0;
                double ptckTongHD = 0;
                double gtckTongHD = 0;
                double tongtienHangGTGT = 0;
                double tongtien = 0;

                try
                {
                    if (!string.IsNullOrEmpty(txtTienhang.Text))
                        tienHang = double.Parse(txtTienhang.Text);

                    if (!string.IsNullOrEmpty(txtGiamgia.Text))
                        giamGia = double.Parse(txtGiamgia.Text);

                    if (!string.IsNullOrEmpty(txtGTGT.Text))
                        thueGTGT = double.Parse(txtGTGT.Text);

                    if (!string.IsNullOrEmpty(txtPhantramchietkhau.Text))
                        ptckTongHD = double.Parse(txtPhantramchietkhau.Text);

                    tongtienHangGTGT = tienHang - giamGia + thueGTGT;
                    gtckTongHD = (tongtienHangGTGT * ptckTongHD) / 100;
                    tongtien = tongtienHangGTGT - gtckTongHD;
                    txtChietkhau.Text = new Common.Utilities().FormatMoney(gtckTongHD);
                    txtTongtien.Text = new Common.Utilities().FormatMoney(tongtien);
                    txtKhachPhaiTra.Text = new Common.Utilities().FormatMoney(tongtien);
                    this.tongtien = tongtien.ToString();
                }
                catch { }
            }
        }

        /// <summary>
        /// Tinh tong tien.
        /// </summary>
        /// <returns></returns>
        public double TongTien()
        {
            double tongtien = 0;
            try
            {
                txtTienhang.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(TinhTien(dtgvsanpham)));
                txtGTGT.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(TinhThue(dtgvsanpham)));
                tongtien = Convert.ToDouble(txtTienhang.Text) + Convert.ToDouble(txtGTGT.Text);
            }
            catch
            {
                tongtien = 0;
            }

            return tongtien;
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
                    return Math.Round(gia).ToString();
                }
                return "0";
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// tính thuế
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public string TinhThue(DataGridView dgv)
        {
            try
            {
                double gia = 0;
                if (dgv.RowCount != 0)
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        string phantramchietkhau = "0";
                        if (txtPhantramchietkhau.Text == "")
                            phantramchietkhau = "0";
                        else
                            phantramchietkhau = txtPhantramchietkhau.Text;
                        double thue = Convert.ToDouble(dgv["ThueGTGT", i].Value.ToString());
                        double tienhang = Convert.ToDouble(dtgvsanpham["ThanhTien", i].Value.ToString());
                        double tienchietkhau = (Convert.ToDouble(dtgvsanpham["ChietKhau", i].Value.ToString()) / 100) * tienhang;
                        double tienchietkhautm = (Convert.ToDouble(phantramchietkhau) / 100) * tienhang;
                        double thanhtien = tienhang - tienchietkhau - tienchietkhautm;
                        gia += thue / 100 * thanhtien;
                    }
                    return Math.Round(gia).ToString();
                }
                return "0";
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// tính chiết khấu
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public string TinhCK(DataGridView dgv)
        {
            try
            {
                double gia = 0;
                if (dgv.RowCount != 0)
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        double chietkhau = Convert.ToDouble(dgv["ChietKhau", i].Value.ToString());
                        double thanhtien = Convert.ToDouble(dtgvsanpham["ThanhTien", i].Value.ToString());
                        gia += (chietkhau / 100) * (thanhtien);
                    }
                    return Math.Round(gia).ToString();
                }
                return "0";
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// kiểm tra chiết khấu
        /// </summary>
        /// <param name="cnhkh"></param>
        public void KiemTraCK(Entities.CapNhatGia[] cnhkh)
        {
            try
            {
                for (int j = 0; j < cnhkh.Length; j++)
                {
                    if (cnhkh[j].MaHangHoa == mahanghoa)
                    {
                        DateTime datebegin = cnhkh[j].NgayBatDau;
                        DateTime dateend = cnhkh[j].NgayKetThuc;
                        DateTime datenow = datesv;
                        if (datenow >= datebegin && datenow <= dateend)
                        {
                            phantramchietkhau = tsslchietkhau.Text = cnhkh[j].PhanTramGiaBanLe.ToString();
                        }
                    }
                }
            }
            catch
            {
            }
        }
        Entities.CapNhatGia[] cngkh;
        /// <summary>
        /// select mã cập nhật khách hàng
        /// </summary>
        public void SelectMaCapNhatKH()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.CapNhatGia pt = new Entities.CapNhatGia("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                cngkh = new Entities.CapNhatGia[1];
                clientstrem = cl.SerializeObj(this.client1, "CapNhatGia", pt);
                // đổ mảng đối tượng vào datagripview       
                cngkh = (Entities.CapNhatGia[])cl.DeserializeHepper1(clientstrem, cngkh);
                if (cngkh == null)
                    cngkh = new Entities.CapNhatGia[0];
            }
            catch { }
        }

        /// <summary>
        /// xử lý khi ấn phím
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_txtTracuu_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        int run = 0;
        /// <summary>
        /// lấy hàng hóa theo mã
        /// </summary>
        private void LayHangHoaTheoMa()
        {
            DateTime start = DateTime.Now;

            if (cbbkhohang.Text.Length == 0)
            {
                MessageBox.Show("Chưa có kho hàng", "Hệ thống cảnh báo");
                cbbkhohang.Focus();
                return;
            }

            try
            {
                if (this.hangHoaTheoKho.Length > 0)
                {
                    double end2 = (DateTime.Now - start).TotalMilliseconds;
                    bool ktdata = false;
                    foreach (Entities.HangHoa item in this.hangHoaTheoKho)
                    {
                        if (item.MaHangHoa.ToUpper().Equals(toolStrip_txtTracuu.Text.ToUpper()) && item.Deleted == false)
                        {
                            try
                            {
                                mahanghoa = toolStrip_txtTracuu.Text = item.MaHangHoa.ToUpper();
                                tssltenhang.Text = item.TenHangHoa;
                                tsslgia.Text = new Common.Utilities().FormatMoney(double.Parse(item.GiaBanLe.ToString()));
                                //
                                //SelectMaCapNhatKH();
                                KiemTraCK(cngkh);
                                //
                                LayGiaTriThue(item.MaThueGiaTriGiaTang);
                                toolStrip_txtTracuu.ReadOnly = true;
                                tsslsoluong.Focus();
                                ktdata = true;
                                double end3 = (DateTime.Now - start).TotalMilliseconds;
                            }
                            catch
                            {
                                phantramchietkhau = tsslchietkhau.Text = "0";
                            }

                            break;
                        }
                    }

                    double end = (DateTime.Now - start).TotalMilliseconds;

                    if (ktdata == false)
                    {
                        MessageBox.Show("Không có hàng hóa trong kho", "Hệ thống cảnh báo");
                        tssltenhang.Text = "";
                        tsslgia.Text = "0";
                        tsslchietkhau.Text = "0";
                        tsslgtgt.Text = "0";
                        toolStrip_txtTracuu.ReadOnly = false;
                    }
                }
                else
                {
                    MessageBox.Show("Không có hàng hóa trong kho", "Hệ thống cảnh báo");
                    tssltenhang.Text = "";
                    tsslgia.Text = "0";
                    tsslchietkhau.Text = "0";
                    tsslgtgt.Text = "0";
                    toolStrip_txtTracuu.ReadOnly = false;
                }
            }
            catch
            {
                return;
            }
            finally
            {
                timerRun.Stop();
                run = 0;
            }
        }
        string thuegtgt = "0";
        /// <summary>
        /// lấy giá trị thuế
        /// </summary>
        /// <param name="maThue"></param>
        private void LayGiaTriThue(string maThue)
        {
            try
            {
                if (thue.Length > 0)
                {
                    int sl = thue.Length;
                    for (int i = 0; i < sl; i++)
                    {
                        if (thue[i].Deleted == false && thue[i].MaThue == maThue)
                        {
                            thuegtgt = tsslgtgt.Text = thue[i].GiaTriThue;
                            return;
                        }
                    }
                }

                tsslgtgt.Text = "0";
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// xử lý timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerRun_Tick(object sender, EventArgs e)
        {
            try
            {
                if (toolStrip_txtTracuu.Text.Length > 0)
                {
                    run++;
                    if (run == 3)
                    {
                        this.Close();
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// kiểm tra dtgv trước khi trừ số lượng
        /// </summary>
        /// <param name="dgv"></param>
        public Entities.ChiTietKhoHangTheoHoaHonNhap[] CheckDataGridTruSL(DataGridView dgv)
        {
            ArrayList array = new ArrayList();
            bool kkt = false;
            try
            {
                if (dgv.RowCount != 0)
                {
                    Entities.ChiTietKhoHangTheoHoaHonNhap[] cthdbh = new Entities.ChiTietKhoHangTheoHoaHonNhap[dgv.RowCount];
                    Entities.ChiTietKhoHangTheoHoaHonNhap temp = new Entities.ChiTietKhoHangTheoHoaHonNhap();
                    for (int j = 0; j < dgv.RowCount; j++)
                    {
                        bool kt = false;
                        string maKho = LayMaKho(cbbkhohang.Text);
                        foreach (Entities.GoiHang item1 in goihang)
                        {
                            if (dgv[1, j].Value.ToString() == item1.MaGoiHang.ToUpper())
                            {
                                foreach (Entities.ChiTietGoiHang item2 in chitietgoihang)
                                {
                                    if (item1.MaGoiHang.ToUpper() == item2.MaGoiHang.ToUpper())
                                    {
                                        temp = new Entities.ChiTietKhoHangTheoHoaHonNhap("Update", maKho, item2.MaHangHoa, int.Parse(dgv["SoLuong", j].Value.ToString()) * item2.SoLuong);
                                        array.Add(temp);
                                        kt = true;
                                    }
                                }
                                break;
                            }
                        }
                        if (!kt)
                        {
                            temp = new Entities.ChiTietKhoHangTheoHoaHonNhap("Update", maKho, dgv[1, j].Value.ToString(), int.Parse(dgv["SoLuong", j].Value.ToString()));
                            array.Add(temp);
                        }
                    }
                    cthdbh = (Entities.ChiTietKhoHangTheoHoaHonNhap[])array.ToArray(typeof(Entities.ChiTietKhoHangTheoHoaHonNhap));
                    return cthdbh;
                }
                return new Entities.ChiTietKhoHangTheoHoaHonNhap[0];
            }
            catch
            {
                return new Entities.ChiTietKhoHangTheoHoaHonNhap[0];
            }
        }
        /// <summary>
        /// xử lý khi nhập vào control khachtra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtkhachtra_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(str) && str.Equals("Them"))
            {
                try
                {
                    new TienIch().AutoFormatMoney(sender);
                    txtdutra.Text = string.Empty;
                    double khachTra = 0;
                    double duTra = 0;
                    double KhacPhaiTra = 0;

                    if (!string.IsNullOrEmpty(txtkhachtra.Text))
                        khachTra = double.Parse(txtkhachtra.Text);

                    if (!string.IsNullOrEmpty(txtdutra.Text))
                        duTra = double.Parse(txtdutra.Text);

                    if (!string.IsNullOrEmpty(txtKhachPhaiTra.Text))
                        KhacPhaiTra = double.Parse(txtKhachPhaiTra.Text);

                    duTra = khachTra - KhacPhaiTra;

                    txtdutra.Text = new Common.Utilities().FormatMoney(duTra);
                }
                catch { }
            }
        }
        /// <summary>
        /// xử lý khi thay đổi kick thước
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXuLyBanLe_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// xử lý khi click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtkhachtra_Click(object sender, EventArgs e)
        {
            try
            {
                string khachtra = "0";
                if (string.IsNullOrEmpty(txtkhachtra.Text))
                    khachtra = "0";
                else
                    khachtra = txtkhachtra.Text;
                txtkhachtra.Text = String.Format("{0:0}", Convert.ToDouble(khachtra));
            }
            catch { }
        }

        /// <summary>
        /// xử nó khi click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_Insert_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            toolStrip_btnThem.Checked = true;
        }
        /// <summary>
        /// xử lý khi ấn phím
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslsoluong_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Qui đổi đơn vị tính
                    foreach (Entities.QuyDoiDonViTinh item in quidoidvt)
                    {
                        if (item.MaHangQuyDoi == mahanghoa)
                        {
                            mahanghoa = toolStrip_txtTracuu.Text = item.MaHangDuocQuyDoi.ToUpper();
                            tssltenhang.Text = item.TenHangDuocQuyDoi;
                            tsslsoluong.Text = (item.SoLuongDuocQuyDoi * int.Parse(tsslsoluong.Text)).ToString();
                            break;

                        }
                    }
                    LayHangHoaTheoMa();
                    NewRow();
                    toolStrip_txtTracuu_Click(sender, e);
                    toolStrip_txtTracuu.Focus();
                }
                if (e.KeyCode == Keys.F6)
                {
                    XuLyDTGV();
                    tsslsoluong.Focus();
                }
                if (e.KeyCode == Keys.F5)
                {
                    txtkhachtra.Focus();
                }
                if (e.KeyCode == Keys.F7)
                {
                    txtPhantramchietkhau.Focus();
                }
                if (e.KeyCode == Keys.F4)
                {
                    try
                    {
                        if (cbbkhohang.Text.Length == 0)
                        {
                            MessageBox.Show("Bạn hãy nhập Kho hàng", "Hệ thống cảnh báo");
                            return;
                        }
                        string maKho = LayMaKho(cbbkhohang.Text);
                        frmTimHangHoa thh = new frmTimHangHoa(maKho);
                        thh.ShowDialog();
                        if (frmTimHangHoa.drvr != null)
                        {
                            mahanghoa = toolStrip_txtTracuu.Text = frmTimHangHoa.drvr.Cells["MaHangHoa"].Value.ToString();
                            tssltenhang.Text = frmTimHangHoa.drvr.Cells["TenHangHoa"].Value.ToString();
                            tsslgia.Text = new Common.Utilities().FormatMoney(double.Parse(frmTimHangHoa.drvr.Cells["GiaBanLe"].Value.ToString()));
                            try
                            {
                                //SelectMaCapNhatKH();
                                KiemTraCK(cngkh);
                            }
                            catch
                            {
                                phantramchietkhau = tsslchietkhau.Text = "0";
                            }
                            LayGiaTriThue(frmTimHangHoa.drvr.Cells["MaThueGiaTriGiaTang"].Value.ToString());
                            toolStrip_txtTracuu.ReadOnly = true;
                            tsslsoluong.Focus();
                            frmTimHangHoa.drvr = null;
                        }
                        else
                            toolStrip_txtTracuu.ReadOnly = false;
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                string khachtra = "0";
                if (txtkhachtra.Text == "")
                    khachtra = "0";
                else
                    khachtra = txtkhachtra.Text;
                frmBaoCaorpt bcrpt = new frmBaoCaorpt("HDBanLe", txtSochungtu.Text, Double.Parse(txtGiamgia.Text), khachtra, txtdutra.Text, txtKhachPhaiTra.Text, txtGTGT.Text, lbnhanvien.Text, "kin", mskngaychungtu.Text, txtGTTheVip.Text, txtGTTheGT.Text, "", txtChietkhau.Text, "", "", "");
                bcrpt.ShowDialog();
            }
            catch { }
            finally
            {
                this.Enabled = true;
            }
        }

        public void XuLyDTGV()
        {
            try
            {
                if (i < 0)
                    return;
                if (dtgvsanpham.RowCount > 1)
                {
                    mahanghoa = toolStrip_txtTracuu.Text = dtgvsanpham[1, i].Value.ToString();
                    tssltenhang.Text = dtgvsanpham[2, i].Value.ToString();
                    tsslgia.Text = new Common.Utilities().FormatMoney(double.Parse(dtgvsanpham[3, i].Value.ToString()));
                    tsslsoluong.Text = dtgvsanpham[4, i].Value.ToString();
                    tsslchietkhau.Text = dtgvsanpham[5, i].Value.ToString();
                    tsslgtgt.Text = dtgvsanpham[6, i].Value.ToString();
                    hh = new Entities.HangHoaHienThi[dtgvsanpham.RowCount - 1];
                    int so = 0;
                    for (int j = 0; j < dtgvsanpham.RowCount; j++)
                    {
                        if (dtgvsanpham[1, j].Value.ToString() != dtgvsanpham[1, i].Value.ToString())
                        {
                            hh[so] = new Entities.HangHoaHienThi(txtSochungtu.Text, dtgvsanpham[1, j].Value.ToString(), dtgvsanpham[2, j].Value.ToString(), dtgvsanpham[3, j].Value.ToString(), dtgvsanpham[4, j].Value.ToString(), dtgvsanpham[5, j].Value.ToString(), dtgvsanpham[6, j].Value.ToString(), dtgvsanpham[7, j].Value.ToString());
                            so++;
                        }
                    }
                    dtgvsanpham.DataSource = hh;
                    TinhToan();
                    if (txtPhantramchietkhau.Text == "")
                        phantramchietkhau = "0";
                    else
                        phantramchietkhau = txtPhantramchietkhau.Text;
                    txtChietkhau.Text = new Common.Utilities().FormatMoney(((Convert.ToDouble(phantramchietkhau) / 100) * Convert.ToDouble(txtTienhang.Text)));
                    txtKhachPhaiTra.Text = txtTongtien.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(tongtienthanhtoan) - Convert.ToDouble(txtChietkhau.Text) - Convert.ToDouble(txtGiamgia.Text));
                    txtkhachtra.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(txtTongtien.Text) - Convert.ToDouble(txtGTTheVip.Text));
                    if (Convert.ToDouble(txtkhachtra.Text) < 0)
                        txtkhachtra.Text = "0";
                    if (txtPhantramchietkhau.Text == "")
                        phantramchietkhau = "0";
                    else
                        phantramchietkhau = txtPhantramchietkhau.Text;
                    txtChietkhau.Text = new Common.Utilities().FormatMoney(((Convert.ToDouble(phantramchietkhau) / 100) * Convert.ToDouble(txtTienhang.Text)));

                    string khachtra = "0";
                    if (txtkhachtra.Text == "")
                        khachtra = "0";
                    else
                        khachtra = txtkhachtra.Text;
                    if (Convert.ToDouble(txtTongtien.Text) >= Convert.ToDouble(txtGTTheVip.Text))
                        txtdutra.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(khachtra) - Convert.ToDouble(txtTongtien.Text) + Convert.ToDouble(txtGTTheVip.Text));
                    else
                        txtdutra.Text = txtkhachtra.Text;
                }
                else
                {
                    mahanghoa = toolStrip_txtTracuu.Text = dtgvsanpham[1, i].Value.ToString();
                    tssltenhang.Text = dtgvsanpham[2, i].Value.ToString();
                    tsslgia.Text = new Common.Utilities().FormatMoney(double.Parse(dtgvsanpham[3, i].Value.ToString()));
                    tsslsoluong.Text = dtgvsanpham[4, i].Value.ToString();
                    tsslchietkhau.Text = dtgvsanpham[5, i].Value.ToString();
                    tsslgtgt.Text = dtgvsanpham[6, i].Value.ToString();
                    dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                    txtTienhang.Text = "0";
                    txtGTGT.Text = "0";
                    txtChietkhau.Text = "0";
                    txtGiamgia.Text = "0";
                    txtkhachtra.Text = "";
                    txtTongtien.Text = "0";
                    txtdutra.Text = "0";

                }
            }
            catch { }
            finally
            {
                try
                {
                    tsslsoluong.Focus();
                    fix();
                }
                catch { }
            }
        }

        private void dtgvsanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            XuLyDTGV();
        }

        private void dtgvsanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void txtkhachtra_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tsslthem_Click(sender, e);
                }
                KeyDown_Chung(sender, e);
            }
            catch { }
        }

        private void dtgvsanpham_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    try
                    {

                        i = dtgvsanpham.SelectedRows[0].Index;
                        XuLyDTGV();
                    }
                    catch
                    {
                    }
                }
                KeyDown_Chung(sender, e);
            }
            catch
            {
            }
        }

        private void cbbkhohang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void KeyDown_Chung(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                XuLyDTGV();
                tsslsoluong.Focus();
            }
            else if (e.KeyCode == Keys.F5)
            {
                txtkhachtra.Focus();
            }
            else if (e.KeyCode == Keys.F7)
            {
                txtPhantramchietkhau.Focus();
            }
            else if (e.KeyCode == Keys.F8)
            {
                txtMaTheVip.Focus();
                txtMaTheVip.SelectAll();
            }
            else if (e.KeyCode == Keys.F4)
            {
                try
                {
                    if (cbbkhohang.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn hãy nhập Kho hàng", "Hệ thống cảnh báo");
                        return;
                    }
                    string maKho = LayMaKho(cbbkhohang.Text);
                    frmTimHangHoa thh = new frmTimHangHoa(maKho);
                    thh.ShowDialog();
                    if (frmTimHangHoa.drvr != null)
                    {
                        mahanghoa = toolStrip_txtTracuu.Text = frmTimHangHoa.drvr.Cells["MaHangHoa"].Value.ToString();
                        tssltenhang.Text = frmTimHangHoa.drvr.Cells["TenHangHoa"].Value.ToString();
                        tsslgia.Text = new Common.Utilities().FormatMoney(double.Parse(frmTimHangHoa.drvr.Cells["GiaBanLe"].Value.ToString()));
                        try
                        {
                            //SelectMaCapNhatKH();
                            KiemTraCK(cngkh);
                        }
                        catch
                        {
                            phantramchietkhau = tsslchietkhau.Text = "0";
                        }
                        LayGiaTriThue(frmTimHangHoa.drvr.Cells["MaThueGiaTriGiaTang"].Value.ToString());
                        toolStrip_txtTracuu.ReadOnly = true;
                        tsslsoluong.Focus();
                        frmTimHangHoa.drvr = null;
                    }
                    else
                        toolStrip_txtTracuu.ReadOnly = false;
                }
                catch { }
            }
        }

        public Entities.TheVip LayGiaTriThe(string mathe)
        {
            try
            {
                for (int j = 0; j < thevip.Length; j++)
                {
                    if (thevip[j].MaThe.Trim().ToUpper() == mathe.Trim().ToUpper() && thevip[j].Deleted == false)
                    {
                        return thevip[j];
                    }
                }
                return null;
            }
            catch { return null; }
        }

        public Entities.TheGiamGia LayGiaTriTheGiamGia(string mathe)
        {
            try
            {
                TheGiamGia();
                for (int j = 0; j < thegiagiam.Length; j++)
                {
                    bool bol1 = thegiagiam[j].MaTheGiamGia.Trim().ToUpper().Equals(mathe.Trim().ToUpper());
                    bool bol2 = datesv.Date >= thegiagiam[j].NgayBatDau.Date;
                    bool bol3 = datesv.Date <= thegiagiam[j].NgayKetThuc.Date;
                    if (bol1 && bol2 && bol3)
                    {
                        return thegiagiam[j];
                    }
                }
                return null;
            }
            catch { return null; }
        }
        string loaithe = "";

        private void cbkiemtra_Enter(object sender, EventArgs e)
        {

        }

        private void cbkiemtra_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    toolStrip_txtTracuu_Click(sender, e);
                    toolStrip_txtTracuu.Focus();
                }
                KeyDown_Chung(sender, e);
            }
            catch { }
        }

        private void txtthegiamgia_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(str) && str.Equals("Them"))
            {
                try
                {
                    txtMaTheVip.Text = "";
                    txtGTTheVip.Text = "0";
                    txtKhachPhaiTra.Text = txtTongtien.Text = new Common.Utilities().FormatMoney(double.Parse(this.tongtien));
                }
                catch { }
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

        private void txtMakhachhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                try
                {
                    frmTimKH tkh = new frmTimKH("PhieuTTCuaKH");
                    tkh.ShowDialog();
                    if (frmTimKH.drvr != null)
                    {
                        txtMakhachhang.Text = frmTimKH.drvr.Cells["MaKH"].Value.ToString();
                        frmTimKH.drvr = null;
                    }
                }
                catch { }
            }
        }

        private void txtthegiamgia_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(str) && str.Equals("Them"))
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        double tongTien = 0;
                        double giaTriThe = 0;
                        double giaTriTheGT = 0;
                        double khachPhaiTra = 0;
                        double khachTra = 0;
                        double duTra = 0;
                        string maThe = txtMaTheVip.Text.ToUpper();
                        txtMaTheVip.Text = maThe;
                        Entities.TheVip tv = LayGiaTriThe(maThe);
                        if (tv == null)
                        {
                            MessageBox.Show("Mã thẻ không tồn tại hoặc đã hết hạn sử dụng - Hãy kiểm tra lại", "Hệ thống cảnh báo");
                            txtMaTheVip.Text = string.Empty;
                            txtMaTheVip.Focus();
                            return;
                        }
                        else
                        {
                            loaithe = "TheVip";
                            txtGTTheVip.Text = new Common.Utilities().FormatMoney(double.Parse(tv.GiaTriConLai));
                            // lay khach hang theo maKH
                            Entities.KhachHang kh = new Entities.KhachHang();
                            kh = this.GetKH(tv.MaKhachHang);
                            // Gan thong tin cua KH
                            txtMakhachhang.Text = kh.MaKH.ToUpper();
                            lblTenKH.Text = kh.Ten;
                            txtkhachtra.Focus();
                            txtkhachtra.SelectAll();

                            if (!string.IsNullOrEmpty(txtTongtien.Text))
                                tongTien = double.Parse(txtTongtien.Text);

                            if (!string.IsNullOrEmpty(txtGTTheVip.Text))
                                giaTriThe = double.Parse(txtGTTheVip.Text);

                            if (!string.IsNullOrEmpty(txtGTTheGT.Text))
                                giaTriTheGT = double.Parse(txtGTTheGT.Text);

                            if (giaTriThe + giaTriTheGT > tongTien)
                            {
                                khachTra = 0;
                                duTra = 0;
                                khachPhaiTra = 0;
                            }
                            else
                            {
                                khachPhaiTra = tongTien - giaTriThe - giaTriTheGT;
                            }

                            txtkhachtra.Text = new Common.Utilities().FormatMoney(khachTra);
                            txtKhachPhaiTra.Text = new Common.Utilities().FormatMoney(khachPhaiTra);
                            txtkhachtra.Text = khachTra.ToString();
                            txtdutra.Text = duTra.ToString();
                        }
                    }
                }
                catch { }
            }
        }

        private void txtMaTheGT_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(str) && str.Equals("Them"))
            {
                try
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        double tongTien = 0;
                        double giaTriThe = 0;
                        double giaTriTheVip = 0;
                        double khachPhaiTra = 0;
                        double khachTra = 0;
                        double duTra = 0;
                        string maThe = txtMaTheGT.Text.ToUpper();
                        txtMaTheGT.Text = maThe;
                        Entities.TheGiamGia thegiamgia = LayGiaTriTheGiamGia(maThe);
                        if (thegiamgia == null)
                        {
                            MessageBox.Show("Mã thẻ không tồn tại hoặc đã hết hạn sử dụng - Hãy kiểm tra lại", "Hệ thống cảnh báo");
                            txtMaTheGT.Text = string.Empty;
                            txtMaTheGT.Focus();
                            return;
                        }

                        loaithe = "TheGiamGia";
                        txtGTTheGT.Text = new Common.Utilities().FormatMoney(double.Parse(thegiamgia.GiaTriConLai));
                        // lay khach hang theo maKH
                        Entities.KhachHang kh = new Entities.KhachHang();
                        kh = this.GetKH(thegiamgia.MaKhachHang);
                        // Gan thong tin cua KH
                        txtMakhachhang.Text = kh.MaKH.ToUpper();
                        lblTenKH.Text = kh.Ten;
                        txtkhachtra.Focus();
                        txtkhachtra.SelectAll();
                        if (!string.IsNullOrEmpty(txtTongtien.Text))
                            tongTien = double.Parse(txtTongtien.Text);

                        if (!string.IsNullOrEmpty(txtGTTheGT.Text))
                            giaTriThe = double.Parse(txtGTTheGT.Text);

                        if (!string.IsNullOrEmpty(txtGTTheVip.Text))
                            giaTriTheVip = double.Parse(txtGTTheVip.Text);

                        if (giaTriThe + giaTriTheVip > tongTien)
                        {
                            khachTra = 0;
                            duTra = 0;
                            khachPhaiTra = 0;
                        }
                        else
                        {
                            khachPhaiTra = tongTien - giaTriThe - giaTriTheVip;
                        }

                        txtkhachtra.Text = new Common.Utilities().FormatMoney(khachTra);
                        txtKhachPhaiTra.Text = new Common.Utilities().FormatMoney(khachPhaiTra);
                        txtkhachtra.Text = khachTra.ToString();
                        txtdutra.Text = duTra.ToString();
                    }
                }
                catch { }
            }
        }

        
        private void txtCKTienMat_TextChanged(object sender, EventArgs e)
        {
            new TienIch().AutoFormatMoney(sender);
        }

        void TinhTongTienHangTrongBanLe()
        {
            if (!string.IsNullOrEmpty(str) && str.Equals("Them"))
            {
                txtTongtien.Text = string.Empty;

                double tongtienHangGTGT = 0;
                double tienHang = 0;
                double giamGia = 0;
                double thueGTGT = 0;

                double ptckTongHD = 0;
                double gtckTongHD = 0;
                double tongtien = 0;

                try
                {
                    if (!string.IsNullOrEmpty(txtTienhang.Text)) tienHang = double.Parse(txtTienhang.Text);
                    if (!string.IsNullOrEmpty(txtGiamgia.Text)) giamGia = double.Parse(txtGiamgia.Text);
                    if (!string.IsNullOrEmpty(txtGTGT.Text)) thueGTGT = double.Parse(txtGTGT.Text);
                    if (!string.IsNullOrEmpty(txtPhantramchietkhau.Text)) ptckTongHD = double.Parse(txtPhantramchietkhau.Text);

                    tongtienHangGTGT = tienHang - giamGia + thueGTGT;   //Tổng tiền hàng bao gồm tiền hàng - giảm giá + thuế GTGT
                    gtckTongHD = (tongtienHangGTGT * ptckTongHD) / 100; //giá trị chiết khấu trên tổng tiền hàng
                    tongtien = tongtienHangGTGT - gtckTongHD;   //số tiền còn lại sau khi chiết khấu

                    txtTongtien.Text = new Common.Utilities().FormatMoney(tongtien);
                    txtKhachPhaiTra.Text = new Common.Utilities().FormatMoney(tongtien);
                    this.tongtien = tongtien.ToString();
                }
                catch { }
            }
        }

        double _cktienmat = 0;
        private void txtCKTienMat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    //Chiết khấu tiền mặt -> double
                    double ckTienMat = double.Parse(txtCKTienMat.Text);
                    double tongtien = double.Parse(this.tongtien);

                    double chenhlech = _cktienmat - ckTienMat;  //tiền hiện tại - tiền trước đó
                    _cktienmat = ckTienMat; //lưu hiện tại

                    txtTongtien.Text = new Common.Utilities().FormatMoney(tongtien + chenhlech);
                    txtKhachPhaiTra.Text = txtTongtien.Text;
                    this.tongtien = txtTongtien.Text;

                    txtkhachtra.Focus();
                    txtkhachtra.SelectAll();
                }
                catch { }
            }
        }
    }
}
