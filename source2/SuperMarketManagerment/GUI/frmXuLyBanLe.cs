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
using Entities;

namespace GUI
{
    public partial class frmXuLyBanLe : Form
    {
        #region Điểm thưởng khách hàng
        DiemThuongKhachHang[] _dtkh = new DiemThuongKhachHang[0];
        private void DiemThuongKhachHang()
        {//Lấy điểm thưởng khách hàng từ csdl
            try
            {
                cl = new Server_Client.Client();
                Client1 = cl.Connect(Luu.IP, Luu.Ports);
                Clientstrem = cl.SerializeObj(this.Client1, "SelectDiemThuongKhachHang", new DiemThuongKhachHang("select"));
                _dtkh = (DiemThuongKhachHang[])cl.DeserializeHepper1(Clientstrem, _dtkh) ?? new DiemThuongKhachHang[0];
            }
            catch { }
        }
        private double TyLeTinh()
        {//Lấy tỷ lệ tính từ csdl
            try
            {
                TyLeTinh[] tlt = new TyLeTinh[0];
                cl = new Server_Client.Client();
                Client1 = cl.Connect(Luu.IP, Luu.Ports);
                Clientstrem = cl.SerializeObj(Client1, "selectTyLeTinh", new TyLeTinh());
                tlt = (TyLeTinh[])cl.DeserializeHepper1(Clientstrem, tlt) ?? new TyLeTinh[0];
                return tlt.Length >= 1 ? tlt[tlt.Length - 1].SoTien : 2988000;
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
        public string ProIddtkh(string tenBang)
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                Client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                LayID lid1 = new LayID("Select", tenBang);
                // khởi tạo mảng đối tượng để hứng giá trị
                LayID lid = new LayID();
                Clientstrem = cl.SerializeObj(Client1, "LayID", lid1);
                // đổ mảng đối tượng vào datagripview       
                lid = (LayID)cl.DeserializeHepper(Clientstrem, lid);
                if (lid == null)
                    return "DTKH_0001";
                Common.Utilities a = new Common.Utilities();
                string idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            catch { return ""; }
        }
        private string LayTenKhachHang(string maKh)
        {
            try
            {
                cl = new Server_Client.Client();
                Client1 = cl.Connect(Luu.IP, Luu.Ports);
                Clientstrem = cl.SerializeObj(Client1, "KhachHang", new KhachHang("Select"));
                KhachHang[] khachhang = new KhachHang[1];
                khachhang = (KhachHang[])cl.DeserializeHepper1(Clientstrem, khachhang) ?? new KhachHang[0];
                foreach (KhachHang item in khachhang.Where(item => item.MaKH.ToUpper().Equals(maKh.ToUpper())))
                    return item.Ten;
                return string.Empty;
            }
            catch { return string.Empty; }
        }
        private bool CapNhatDiemThuongKhachHang(string maKh, string tien)
        {
            try
            {
                DiemThuongKhachHang input = null;
                DiemThuongKhachHang();
                foreach (DiemThuongKhachHang item in _dtkh.Where(item => item.MaKhachHang.ToUpper().Equals(maKh.ToUpper())))
                {
                    //thực hiện việc cộng số lượng điểm
                    input = TienIch.DiemThuongKhachHang_TO_DiemThuongKhachHang(item);
                    input.ThaoTac = "CapNhat";
                    input.TongDiem += sodiemthuong(double.Parse(tien.Replace(",", "")));
                    input.DiemConLai = input.TongDiem - input.DiemDaDung;
                    break;
                }
                if (input == null)
                {//thêm mới trường điểm thường khách hàng
                    input = new DiemThuongKhachHang
                                {
                                    ThaoTac = "insert",
                                    MaDiemThuongKhachHang = ProIddtkh("DiemThuongKhachHang"),
                                    MaKhachHang = maKh,
                                    TenKhachHang = LayTenKhachHang(maKh),
                                    TongDiem = sodiemthuong(double.Parse(tien.Replace(",", ""))),
                                    DiemDaDung = 0
                                };
                    input.DiemConLai = input.TongDiem;
                    input.GhiChu = "";
                    input.Deleted = false;

                    cl = new Server_Client.Client();
                    Client1 = cl.Connect(Luu.IP, Luu.Ports);
                    Clientstrem = cl.SerializeObj(Client1, "DiemThuongKhachHang", input);
                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(Clientstrem, msg);
                    return msg != 0;
                }
                else
                {//Cập nhật điểm thưởng cho khách hàng
                    cl = new Server_Client.Client();
                    Client1 = cl.Connect(Luu.IP, Luu.Ports);
                    Clientstrem = cl.SerializeObj(Client1, "DiemThuongKhachHang", input);
                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(Clientstrem, msg);
                    return msg != 0;
                }

            }
            catch { return false; }
        }
        #endregion

        readonly KhuyenMaiSoLuong[] _kmSoLuong;
        public TcpClient Client1;
        public NetworkStream Clientstrem;
        public static string Trave = string.Empty;
        QuyDoiDonViTinh[] _quidoidvt;
        GoiHang[] _goihang;
        ChiTietGoiHang[] _chitietgoihang;
        DateTime _datesv;
        HangHoa[] _hangHoaTheoKho;
        Thue[] _thue;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        public frmXuLyBanLe()
        {
            InitializeComponent();
            _datesv = DateServer.Date();
            _kmSoLuong = GetData();
        }
        readonly string _str;
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
                Client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                CapNhatGia pt = new CapNhatGia("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                _cngkh = new CapNhatGia[1];
                Clientstrem = cl.SerializeObj(Client1, "CapNhatGia", pt);
                // đổ mảng đối tượng vào datagripview       
                _cngkh = (CapNhatGia[])cl.DeserializeHepper1(Clientstrem, _cngkh) ?? new CapNhatGia[0];
                //
                _datesv = DateServer.Date();
                toolStripStatusLabel3.Enabled = false;
                dtgvsanpham.DataSource = new HangHoaHienThi[0];
                _str = str;
                TheVip();
                try
                {
                    LayKhoHang();
                    new Common.Utilities().ComboxKhoHang(cbbkhohang);
                }
                catch
                {
                }
                _datesv = DateServer.Date();
                cbxHinhthucthanhtoan.SelectedIndex = 0;
                mskngaychungtu.Text = new Common.Utilities().XuLy(2, _datesv.ToShortDateString());
                lbnhanvien.Text = Common.Utilities.User.TenNhanVien;
                //
                KhoiTao();
                _kmSoLuong = GetData();
            }
            catch
            {

            }
        }


        public void KhoiTao()
        {
            try
            {
                Server_Client.Client client = new Server_Client.Client();
                Client1 = client.Connect(Luu.IP, Luu.Ports);
                CheckRefer ctxh = new CheckRefer("BanBuon");
                Clientstrem = client.SerializeObj(Client1, "Select", ctxh);
                selectall = (SelectAll)client.DeserializeHepper(Clientstrem, selectall);
                // gói hàng
                _goihang = selectall.GoiHang;
                // chi tiết gói hàng
                _chitietgoihang = selectall.ChiTietGoiHang;
                // quy đổi đơn vị tính
                _quidoidvt = selectall.QuyDoiDonViTinh;

                // lay hang hoa the kho
                client = new Server_Client.Client();
                // gán TCPclient
                Client1 = client.Connect(Luu.IP, Luu.Ports);
                client = new Server_Client.Client();

                TruyenGiaTri khoHang = (TruyenGiaTri)cbbkhohang.SelectedItem;
                string makho = khoHang.Giatritruyen;
                HangHoa kh = new HangHoa("SelectTheoKho", makho);
                Clientstrem = client.SerializeObj(Client1, "HangHoa", kh);
                HangHoa[] hhArr = new HangHoa[1];
                hhArr = (HangHoa[])client.DeserializeHepper1(Clientstrem, hhArr);

                if (hhArr == null)
                    _hangHoaTheoKho = new HangHoa[0];

                if (hhArr.Length <= 0) return;

                List<HangHoa> array = hhArr.ToList();

                HangHoa[] save = Common.Utilities.CheckGoiHang(hhArr, _goihang, _chitietgoihang);
                if (save != null) array.AddRange(save);

                // lay hang hoa theo kho
                _hangHoaTheoKho = array.ToArray();

                // Lay Thue
                client = new Server_Client.Client();

                Thue thueTemp = new Thue("Select");
                Clientstrem = client.SerializeObj(Client1, "Thue", thueTemp);
                _thue = new Thue[1];
                _thue = (Thue[])client.DeserializeHepper1(Clientstrem, _thue) ?? new Thue[0];
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
        public KhuyenMaiSoLuong[] GetData()
        {
            KhuyenMaiSoLuong[] retVal = null;
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                Client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                // truyền HanhDong
                KhuyenMaiSoLuong item = new KhuyenMaiSoLuong { HanhDong = "SelectAll" };
                // khởi tạo mảng đối tượng để hứng giá trị
                KhuyenMaiSoLuong[] item1 = new KhuyenMaiSoLuong[1];
                Clientstrem = cl.SerializeObj(Client1, "KhuyenMaiSoLuong", item);
                // đổ mảng đối tượng vào datagripview       
                item1 = (KhuyenMaiSoLuong[])cl.DeserializeHepper1(Clientstrem, item1);
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
        /// <param name="ngayLapHd"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public KhuyenMaiSoLuong LayGia(string maHangHoa, string sl, DateTime ngayLapHd, KhuyenMaiSoLuong[] source)
        {
            KhuyenMaiSoLuong retVal;
            try
            {
                KhuyenMaiSoLuong[] temp = frmXuLyHangHoa.GetSource(maHangHoa, source);
                temp = frmXuLyHangHoa.SapXep(temp);
                retVal = frmXuLyHangHoa.GetDonGia(maHangHoa, sl, ngayLapHd, temp);
            }
            catch
            {
                retVal = null;
            }

            return retVal;
        }

        #endregion

        public GiaVon[] GiaVon()
        {
            GiaVon[] giaVon = null;
            try
            {
                cl = new Server_Client.Client();
                Client1 = cl.Connect(Luu.IP, Luu.Ports);
                ArrayList kArr = new ArrayList { "SelectTheoDieuKien_GiaVon", "Select_GIAVON", new GiaVon(), new GiaVon() };
                Clientstrem = cl.SerializeObj(Client1, "GiaVon_k", kArr);
                ////// đổ mảng đối tượng vào datagripview     
                giaVon = (GiaVon[])cl.DeserializeHepper1(Clientstrem, giaVon) ?? new GiaVon[0];
            }
            catch (Exception)
            {
            }

            return giaVon;
        }

        public void GiaVonBanHang(ChiTietHDBanHang[] ct)
        {
            try
            {
                List<GiaVonBanHang> gvbhArr = new List<GiaVonBanHang>();
                GoiHang[] goiHang = _goihang;
                GiaVon[] gv = GiaVon();
                bool isHangHoa = false;

                foreach (ChiTietHDBanHang bh in ct)
                {
                    GiaVonBanHang gvbh = new GiaVonBanHang();
                    ChiTietHDBanHang bh1 = bh;
                    foreach (GiaVon item in gv.Where(item => item.MaHangHoa.Equals(bh1.MaHangHoa)))
                    {
                        gvbh.HanhDong = "Insert";
                        gvbh.MaHangHoa = bh.MaHangHoa;
                        gvbh.MaHoaDon = bh.MaHDBanHang;
                        gvbh.GiaVon = item.Gia;
                        gvbhArr.Add(gvbh);
                        isHangHoa = true;
                        break;
                    }
                    // neu ko phai la hang hoa thi la gia von trong goi hang
                    if (isHangHoa) continue;
                    gvbh = GetGvGoiHang(bh.MaHDBanHang, bh.MaHangHoa, goiHang);

                    if (gvbh != null)
                        gvbhArr.Add(gvbh);
                }

                cl = new Server_Client.Client();
                Client1 = cl.Connect(Luu.IP, Luu.Ports);
                foreach (GiaVonBanHang item in gvbhArr.ToArray())
                {
                    Clientstrem = cl.SerializeObj(Client1, "GiaVonBanHang", item);
                }
                // đổ mảng đối tượng vào datagripview
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(Clientstrem, kt);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// GetGVGoiHang
        /// </summary>
        /// <param name="maHd"> </param>
        /// <param name="maGoi"></param>
        /// <param name="gh"></param>
        /// <returns></returns>
        public GiaVonBanHang GetGvGoiHang(string maHd, string maGoi, GoiHang[] gh)
        {
            GiaVonBanHang retVal = null;
            try
            {
                foreach (GoiHang item in gh.Where(item => item.MaGoiHang.Trim().ToUpper().Equals(maGoi.Trim().ToUpper())))
                {
                    retVal = new GiaVonBanHang
                                 {
                                     HanhDong = "Insert",
                                     MaHangHoa = maGoi.Trim().ToUpper(),
                                     MaHoaDon = maHd.Trim().ToUpper(),
                                     GiaVon = double.Parse(item.GiaNhap)
                                 };
                    break;
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
                InitializeComponent(); _datesv = DateServer.Date();
                dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                LayKhoHang();
                palNhap.Enabled = palThem.Enabled = palXem.Enabled = tsslthem.Enabled = false;
                _str = str;
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
            this.Client1 = cl.Connect(Luu.IP, Luu.Ports);
            // khởi tạo biến truyền vào với hàm khởi tạo
            Entities.TheVip pt = new Entities.TheVip("Select");
            Clientstrem = cl.SerializeObj(this.Client1, "LayTheVip", pt);
            // đổ mảng đối tượng vào datagripview
            thevip = (Entities.TheVip[])cl.DeserializeHepper1(Clientstrem, thevip);
            if (thevip == null)
                thevip = new Entities.TheVip[0];

        }
        Entities.TheGiamGia[] thegiagiam;
        public void TheGiamGia()
        {
            cl = new Server_Client.Client();

            // gán TCPclient
            this.Client1 = cl.Connect(Luu.IP, Luu.Ports);
            // khởi tạo biến truyền vào với hàm khởi tạo
            Entities.TheGiamGia pt = new Entities.TheGiamGia();
            pt.HanhDong = "Select";
            Clientstrem = cl.SerializeObj(this.Client1, "TheGiamGia", pt);
            // đổ mảng đối tượng vào datagripview
            thegiagiam = (Entities.TheGiamGia[])cl.DeserializeHepper1(Clientstrem, thegiagiam);
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
                this.Client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ChiTietHDBanHang pt = new Entities.ChiTietHDBanHang("Select", txtSochungtu.Text);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.ChiTietHDBanHang[] pt1 = new Entities.ChiTietHDBanHang[1];
                Clientstrem = cl.SerializeObj(this.Client1, "ChiTietHDBanHang", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.ChiTietHDBanHang[])cl.DeserializeHepper1(Clientstrem, pt1);
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
                this.Client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.HangHoa pt = new Entities.HangHoa("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                hh1 = new Entities.HangHoa[1];
                Clientstrem = cl.SerializeObj(this.Client1, "HangHoa", pt);
                // đổ mảng đối tượng vào datagripview       
                hh1 = (Entities.HangHoa[])cl.DeserializeHepper1(Clientstrem, hh1);
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
            if (_str == "Them")
            {
                this.Text = "Thêm Mới - F4 Thêm Hàng Hóa - F5 Thanh toán - F6 Sửa Hàng Hóa - F7 Nhập Chiết Khấu - F8 Nhập Thẻ Vip";
                sochungtu = txtSochungtu.Text = ProID("HDBanHang");
                dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
            }
            else if (_str == "Sua")
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
                this.Client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.LayID lid = new Entities.LayID();
                Clientstrem = cl.SerializeObj(this.Client1, "LayID", lid1);
                // đổ mảng đối tượng vào datagripview       
                lid = (Entities.LayID)cl.DeserializeHepper(Clientstrem, hdbh);
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
                    Trave = "ok";
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
                this.Client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.KhachHang kh = new Entities.KhachHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.KhachHang[] kh1 = new Entities.KhachHang[1];
                Clientstrem = cl.SerializeObj(this.Client1, "KhachHang", kh);
                // đổ mảng đối tượng vào datagripview       
                kh1 = (Entities.KhachHang[])cl.DeserializeHepper1(Clientstrem, kh1);
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
                this.Client1 = cl.Connect(Luu.IP, Luu.Ports);

                Entities.KhoHang kh = new Entities.KhoHang();
                kh = new Entities.KhoHang("Select");
                Clientstrem = cl.SerializeObj(this.Client1, "KhoHang", kh);
                kh1 = new Entities.KhoHang[1];
                kh1 = (Entities.KhoHang[])cl.DeserializeHepper1(Clientstrem, kh1);
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
        }
        /// <summary>
        /// lấy mã kho
        /// </summary>
        /// <param name="tenKho"></param>
        /// <returns></returns>
        public string LayMaKho(string tenKho)
        {
            foreach (KhoHang khoHang in kh1.Where(khoHang => khoHang.TenKho == tenKho))
                return khoHang.MaKho;
            return string.Empty;
        }
        /// <summary>
        /// lấy tên kho
        /// </summary>
        /// <param name="maKho"></param>
        /// <returns></returns>
        public string LayTenKho(string maKho)
        {
            foreach (KhoHang khoHang in kh1.Where(khoHang => khoHang.MaKho == maKho))
                return khoHang.TenKho;
            return string.Empty;
        }

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
                foreach (QuyDoiDonViTinh item in _quidoidvt.Where(item => item.MaHangQuyDoi == mahanghoa))
                {
                    mahanghoa = toolStrip_txtTracuu.Text = item.MaHangDuocQuyDoi.ToUpper();
                    tssltenhang.Text = item.TenHangDuocQuyDoi;
                    tsslsoluong.Text = (item.SoLuongDuocQuyDoi * int.Parse(tsslsoluong.Text)).ToString();
                    break;
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
                txtGiamgia.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(TinhCk(dtgvsanpham)));
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
            HangHoaHienThi[] hh = new HangHoaHienThi[0];
            try
            {
                if (dtgvsanpham.RowCount != 0)
                {
                    for (int j = 0; j < dtgvsanpham.RowCount; j++)
                    {
                        if (mahanghoa == dtgvsanpham[1, j].Value.ToString())
                        {
                            hh = new HangHoaHienThi[dtgvsanpham.RowCount];
                            break;
                        }
                        hh = new HangHoaHienThi[dtgvsanpham.RowCount + 1];
                    }
                }
                else
                    hh = new HangHoaHienThi[dtgvsanpham.RowCount + 1];

                if (hh.Length == 0) return;
                try
                {
                    string kt1 = string.Empty;
                    if (hh.Length == dtgvsanpham.RowCount)
                    {

                        for (int j = 0; j < hh.Length; j++)
                        {
                            if (mahanghoa == dtgvsanpham[1, j].Value.ToString())
                            {
                                int soluongcu = Convert.ToInt32(dtgvsanpham[4, j].Value.ToString());
                                string sl = string.IsNullOrEmpty(tsslsoluong.Text) ? "1" : tsslsoluong.Text;
                                int soluongmoi = Convert.ToInt32(sl);
                                int soluonghientai = soluongcu + soluongmoi;
                                // Lay gia san pham
                                DateTime ngayBan = DateTime.Parse(new Common.Utilities().MyDateConversion(mskngaychungtu.Text));
                                KhuyenMaiSoLuong giaTheoSl = LayGia(mahanghoa, soluonghientai.ToString(), ngayBan, _kmSoLuong);

                                string giasp = giaTheoSl != null ? giaTheoSl.GiaBanLe.ToString() : new Common.Utilities().FormatMoney(double.Parse(dtgvsanpham[3, j].Value.ToString()));

                                string thanhtien = new Common.Utilities().FormatMoney((Convert.ToDouble(soluonghientai) * Convert.ToDouble(giasp)));
                                hh[j] = new HangHoaHienThi(txtSochungtu.Text, dtgvsanpham[1, j].Value.ToString(), dtgvsanpham[2, j].Value.ToString(), giasp, soluonghientai.ToString(), dtgvsanpham[5, j].Value.ToString(), dtgvsanpham[6, j].Value.ToString(), thanhtien);
                                kt1 = "ok";
                            }
                            else
                                hh[j] = new HangHoaHienThi(txtSochungtu.Text, dtgvsanpham[1, j].Value.ToString(), dtgvsanpham[2, j].Value.ToString(), dtgvsanpham[3, j].Value.ToString(), dtgvsanpham[4, j].Value.ToString(), dtgvsanpham[5, j].Value.ToString(), dtgvsanpham[6, j].Value.ToString(), dtgvsanpham[7, j].Value.ToString());

                        }
                    }
                    else
                    {
                        for (int j = 0; j < hh.Length; j++)
                        {
                            if (j < hh.Length - 1)
                                hh[j] = new HangHoaHienThi(txtSochungtu.Text, dtgvsanpham[1, j].Value.ToString(), dtgvsanpham[2, j].Value.ToString(), dtgvsanpham[3, j].Value.ToString(), dtgvsanpham[4, j].Value.ToString(), dtgvsanpham[5, j].Value.ToString(), dtgvsanpham[6, j].Value.ToString(), dtgvsanpham[7, j].Value.ToString());
                            else
                            {
                                string sl = string.IsNullOrEmpty(tsslsoluong.Text) ? "1" : tsslsoluong.Text;
                                string soluongsp = sl;
                                // Lay gia san pham
                                DateTime ngayBan = DateTime.Parse(new Common.Utilities().MyDateConversion(mskngaychungtu.Text));
                                KhuyenMaiSoLuong giaTheoSl = LayGia(mahanghoa, soluongsp, ngayBan, _kmSoLuong);

                                string giasp = giaTheoSl != null ? giaTheoSl.GiaBanLe.ToString() : new Common.Utilities().FormatMoney(double.Parse(tsslgia.Text));

                                string thanhtien = new Common.Utilities().FormatMoney((Convert.ToDouble(giasp) * Convert.ToDouble(soluongsp)));
                                hh[hh.Length - 1] = new HangHoaHienThi(txtSochungtu.Text, mahanghoa, tssltenhang.Text, giasp, soluongsp, tsslchietkhau.Text, tsslgtgt.Text, thanhtien);
                            }


                        }
                    }
                    if (string.IsNullOrEmpty(kt1))
                    {
                        string sl = tsslsoluong.Text == "" ? "1" : tsslsoluong.Text;
                        string soluongsp = sl;
                        // Lay gia san pham
                        DateTime ngayBan = DateTime.Parse(new Common.Utilities().MyDateConversion(mskngaychungtu.Text));
                        KhuyenMaiSoLuong giaTheoSl = LayGia(mahanghoa, soluongsp, ngayBan, _kmSoLuong);

                        string giasp = giaTheoSl != null ? giaTheoSl.GiaBanLe.ToString() : new Common.Utilities().FormatMoney(double.Parse(tsslgia.Text));

                        string thanhtien = new Common.Utilities().FormatMoney((Convert.ToDouble(giasp) * Convert.ToDouble(soluongsp)));
                        hh[hh.Length - 1] = new HangHoaHienThi(txtSochungtu.Text, mahanghoa, tssltenhang.Text, giasp, soluongsp, tsslchietkhau.Text, tsslgtgt.Text, thanhtien);
                    }
                }
                catch (Exception ex)
                {
                    string sl = string.IsNullOrEmpty(tsslsoluong.Text) ? "1" : tsslsoluong.Text;
                    string soluongsp = sl;
                    // Lay gia san pham
                    DateTime ngayBan = DateTime.Parse(new Common.Utilities().MyDateConversion(mskngaychungtu.Text));
                    KhuyenMaiSoLuong giaTheoSl = LayGia(mahanghoa, soluongsp, ngayBan, _kmSoLuong);

                    string giasp = giaTheoSl != null ? giaTheoSl.GiaBanLe.ToString() : new Common.Utilities().FormatMoney(double.Parse(tsslgia.Text));
                    string thanhtien = new Common.Utilities().FormatMoney((Convert.ToDouble(giasp) * Convert.ToDouble(soluongsp)));
                    hh[0] = new HangHoaHienThi(txtSochungtu.Text, mahanghoa, tssltenhang.Text, giasp, soluongsp, tsslchietkhau.Text, tsslgtgt.Text, thanhtien);
                }

                dtgvsanpham.DataSource = hh;
                TinhToan();
                phantramchietkhau = string.IsNullOrEmpty(txtPhantramchietkhau.Text) ? "0" : txtPhantramchietkhau.Text;
                txtChietkhau.Text = new Common.Utilities().FormatMoney(((Convert.ToDouble(phantramchietkhau) / 100) * Convert.ToDouble(txtTienhang.Text)));
                txtTongtien.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(tongtienthanhtoan) - Convert.ToDouble(txtChietkhau.Text) - Convert.ToDouble(txtGiamgia.Text));
                txtKhachPhaiTra.Text = txtTongtien.Text;
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
        private static bool TestCharacter(char ch)
        {
            char[] a = new[]{'+','-','~','`','@','#','$','%','^','&','*','(',')','{','}','[',']',':',';','|',
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
            return a.Any(c => c.Equals(ch));
            //foreach (char c in a)
            //{
            //    if (c.Equals(ch))
            //        return true;
            //}
            //return false;
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
                            KiemTraCk(_cngkh);
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
                            if (TestCharacter(ch))
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
                        foreach (Entities.QuyDoiDonViTinh item in _quidoidvt)
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
                this.Client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.HDBanHang pt = new Entities.HDBanHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.HDBanHang[] pt1 = new Entities.HDBanHang[1];
                Clientstrem = cl.SerializeObj(this.Client1, "HDBanHang", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.HDBanHang[])cl.DeserializeHepper1(Clientstrem, pt1);
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
                this.Client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.HDBanHang pt = new Entities.HDBanHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.HDBanHang[] pt1 = new Entities.HDBanHang[1];
                Clientstrem = cl.SerializeObj(this.Client1, "HDBanHang", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.HDBanHang[])cl.DeserializeHepper1(Clientstrem, pt1);
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
                        this.Client1 = cl.Connect(Luu.IP, Luu.Ports);
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
                            txtMakhachhang.Text, "0", " ", cbxHinhthucthanhtoan.Text, makho, _datesv, " ",
                            Common.Utilities.User.NhanVienID, "TT_0001", txtGiamgia.Text, ttn.ToString(), "0",
                            txtGTGT.Text, txtTongtien.Text, true, txtMaTheVip.Text, txtGTTheVip.Text, txtDiengiai.Text, false,
                            Common.Utilities.User.TenDangNhap, txtkhachtra.Text, ckTongHoaDon, txtMaTheGT.Text, txtGTTheGT.Text);

                        pt.ChiTietHDBanHang = CheckDataGridInsert(dtgvsanpham);
                        pt.ChiTietKhoHangTheoHoaHonNhap = CheckDataGridTruSL(dtgvsanpham);
                        pt.TheVip = tv1;
                        pt.TheGiamGia = tgg1;
                        Clientstrem = cl.SerializeObj(this.Client1, "HDBanHang", pt);

                        bool kt1 = false;
                        kt1 = (bool)cl.DeserializeHepper(Clientstrem, kt1);
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
                        this.Client1 = cl.Connect(Luu.IP, Luu.Ports);
                        string date = new Common.Utilities().MyDateConversion(mskngaychungtu.Text);
                        Entities.HDBanHang pt = new Entities.HDBanHang();
                        string makho = LayMaKho(cbbkhohang.Text);
                        pt = new Entities.HDBanHang("Insert", 0, txtSochungtu.Text, Convert.ToDateTime(date),
                                                    txtMakhachhang.Text, "0", " ", cbxHinhthucthanhtoan.Text, makho, _datesv, " ",
                                                    Common.Utilities.User.NhanVienID, "TT_0001", txtChietkhau.Text, txtTongtien.Text, "0",
                                                    txtGTGT.Text, txtTongtien.Text, true, txtMaTheVip.Text, txtGTTheVip.Text, txtDiengiai.Text, false,
                                                    Common.Utilities.User.TenDangNhap, txtkhachtra.Text, txtPhantramchietkhau.Text, txtMaTheGT.Text, txtGTTheGT.Text);

                        Clientstrem = cl.SerializeObj(this.Client1, "HDBanHang", pt);
                        bool kt1 = false;
                        kt1 = (bool)cl.DeserializeHepper(Clientstrem, kt1);
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
            if (!string.IsNullOrEmpty(_str) && _str.Equals("Them"))
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
        public string TinhCk(DataGridView dgv)
        {
            try
            {
                double gia = 0;
                if (dgv.RowCount != 0)
                {
                    for (int index = 0; index < dgv.RowCount; index++)
                    {
                        double dchietkhau = Convert.ToDouble(dgv["ChietKhau", index].Value.ToString());
                        double thanhtien = Convert.ToDouble(dtgvsanpham["ThanhTien", index].Value.ToString());
                        gia += (dchietkhau / 100) * (thanhtien);
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
        public void KiemTraCk(CapNhatGia[] cnhkh)
        {
            try
            {
                foreach (CapNhatGia capNhatGia in cnhkh.Where(capNhatGia => capNhatGia.MaHangHoa == mahanghoa).Where(capNhatGia => _datesv >= capNhatGia.NgayBatDau && _datesv <= capNhatGia.NgayKetThuc))
                {
                    phantramchietkhau = tsslchietkhau.Text = capNhatGia.PhanTramGiaBanLe;
                }
                //foreach (CapNhatGia capNhatGia in cnhkh)
                //{
                //if (capNhatGia.MaHangHoa != mahanghoa) continue;
                //if (_datesv >= capNhatGia.NgayBatDau && _datesv <= capNhatGia.NgayKetThuc)
                //{
                //    phantramchietkhau = tsslchietkhau.Text = capNhatGia.PhanTramGiaBanLe;
                //}
                //}
            }
            catch
            {
            }
        }
        CapNhatGia[] _cngkh;
        /// <summary>
        /// select mã cập nhật khách hàng
        /// </summary>
        public void SelectMaCapNhatKh()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                Client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                CapNhatGia pt = new CapNhatGia("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                _cngkh = new CapNhatGia[1];
                Clientstrem = cl.SerializeObj(Client1, "CapNhatGia", pt);
                // đổ mảng đối tượng vào datagripview       
                _cngkh = (CapNhatGia[])cl.DeserializeHepper1(Clientstrem, _cngkh) ?? new CapNhatGia[0];
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
                if (this._hangHoaTheoKho.Length > 0)
                {
                    double end2 = (DateTime.Now - start).TotalMilliseconds;
                    bool ktdata = false;
                    foreach (Entities.HangHoa item in this._hangHoaTheoKho)
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
                                KiemTraCk(_cngkh);
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
                if (_thue.Length > 0)
                {
                    int sl = _thue.Length;
                    for (int i = 0; i < sl; i++)
                    {
                        if (_thue[i].Deleted == false && _thue[i].MaThue == maThue)
                        {
                            thuegtgt = tsslgtgt.Text = _thue[i].GiaTriThue;
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
                        foreach (Entities.GoiHang item1 in _goihang)
                        {
                            if (dgv[1, j].Value.ToString() == item1.MaGoiHang.ToUpper())
                            {
                                foreach (Entities.ChiTietGoiHang item2 in _chitietgoihang)
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
            if (!string.IsNullOrEmpty(_str) && _str.Equals("Them"))
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
                    foreach (Entities.QuyDoiDonViTinh item in _quidoidvt)
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
                                KiemTraCk(_cngkh);
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
                string khachtra = string.IsNullOrEmpty(txtkhachtra.Text) ? "0" : txtkhachtra.Text;
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
                    HangHoaHienThi[] hh = new HangHoaHienThi[dtgvsanpham.RowCount - 1];
                    int so = 0;
                    for (int j = 0; j < dtgvsanpham.RowCount; j++)
                    {
                        if (dtgvsanpham[1, j].Value.ToString() == dtgvsanpham[1, i].Value.ToString()) continue;
                        hh[so] = new HangHoaHienThi(txtSochungtu.Text, dtgvsanpham[1, j].Value.ToString(), dtgvsanpham[2, j].Value.ToString(), dtgvsanpham[3, j].Value.ToString(), dtgvsanpham[4, j].Value.ToString(), dtgvsanpham[5, j].Value.ToString(), dtgvsanpham[6, j].Value.ToString(), dtgvsanpham[7, j].Value.ToString());
                        so++;
                    }
                    dtgvsanpham.DataSource = hh;
                    TinhToan();
                    phantramchietkhau = string.IsNullOrEmpty(txtPhantramchietkhau.Text) ? "0" : txtPhantramchietkhau.Text;
                    txtChietkhau.Text = new Common.Utilities().FormatMoney(((Convert.ToDouble(phantramchietkhau) / 100) * Convert.ToDouble(txtTienhang.Text)));
                    txtKhachPhaiTra.Text = txtTongtien.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(tongtienthanhtoan) - Convert.ToDouble(txtChietkhau.Text) - Convert.ToDouble(txtGiamgia.Text));
                    txtkhachtra.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(txtTongtien.Text) - Convert.ToDouble(txtGTTheVip.Text));
                    if (Convert.ToDouble(txtkhachtra.Text) < 0)
                        txtkhachtra.Text = "0";
                    phantramchietkhau = string.IsNullOrEmpty(txtPhantramchietkhau.Text) ? "0" : txtPhantramchietkhau.Text;
                    txtChietkhau.Text = new Common.Utilities().FormatMoney(((Convert.ToDouble(phantramchietkhau) / 100) * Convert.ToDouble(txtTienhang.Text)));

                    string khachtra = string.IsNullOrEmpty(txtkhachtra.Text) ? "0" : txtkhachtra.Text;
                    txtdutra.Text = Convert.ToDouble(txtTongtien.Text) >= Convert.ToDouble(txtGTTheVip.Text) ? new Common.Utilities().FormatMoney(Convert.ToDouble(khachtra) - Convert.ToDouble(txtTongtien.Text) + Convert.ToDouble(txtGTTheVip.Text)) : txtkhachtra.Text;
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
                            KiemTraCk(_cngkh);
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
                    bool bol2 = _datesv.Date >= thegiagiam[j].NgayBatDau.Date;
                    bool bol3 = _datesv.Date <= thegiagiam[j].NgayKetThuc.Date;
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
            if (!string.IsNullOrEmpty(_str) && _str.Equals("Them"))
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
            if (!string.IsNullOrEmpty(_str) && _str.Equals("Them"))
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
            if (!string.IsNullOrEmpty(_str) && _str.Equals("Them"))
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
            //new TienIch().AutoFormatMoney(sender);
        }

        void TinhTongTienHangTrongBanLe()
        {
            if (!string.IsNullOrEmpty(_str) && _str.Equals("Them"))
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

        //double _cktienmat = 0;
        private void txtCKTienMat_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    try
            //    {
            //        //Chiết khấu tiền mặt -> double
            //        double ckTienMat = double.Parse(txtCKTienMat.Text);
            //        double tongtien = double.Parse(this.tongtien);

            //        double chenhlech = _cktienmat - ckTienMat;  //tiền hiện tại - tiền trước đó
            //        _cktienmat = ckTienMat; //lưu hiện tại

            //        txtTongtien.Text = new Common.Utilities().FormatMoney(tongtien + chenhlech);
            //        txtKhachPhaiTra.Text = txtTongtien.Text;
            //        this.tongtien = txtTongtien.Text;

            //        txtkhachtra.Focus();
            //        txtkhachtra.SelectAll();
            //    }
            //    catch { }
            //}
        }

        private void frmXuLyBanLe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.F9) return; //Sửa giá hàng hóa
            string maHangHoa = toolStrip_txtTracuu.Text.Trim().ToUpper();
            if (string.IsNullOrEmpty(maHangHoa) || maHangHoa.Equals("<F4 - Tra cứu>"))
            {
                MessageBox.Show("Vui lòng chọn hàng hóa cần sửa giá!\r\n tại ô nhập mã hàng hóa, vui lòng điền thông tin mã hàng hoặc ấn F4 để tìm kiếm hàng hóa");
                toolStrip_txtTracuu.Focus(); return;
            }
            HangHoa[] tempReturn;
            bool kq = Utils.GetDataFromServer("HangHoa", new HangHoa { HanhDong = "SelectHangHoa_Theo_MaHangHoa", MaHangHoa = maHangHoa }, out tempReturn);
            if (!kq && tempReturn.Length == 0) return;
            frmXuLyHangHoa frm = new frmXuLyHangHoa("Update", tempReturn[0]);
            frm.ShowDialog();
            kq = Utils.GetDataFromServer("HangHoa", new HangHoa { HanhDong = "SelectHangHoa_Theo_MaHangHoa", MaHangHoa = maHangHoa }, out tempReturn);
            if (!kq && tempReturn.Length == 0) return;
            //Sửa xong thì cập nhật lại vào danh sách hàng hóa trong kho
            foreach (HangHoa hangHoa in _hangHoaTheoKho.Where(hangHoa => hangHoa.MaHangHoa.Equals(tempReturn[0].MaHangHoa)))
                Utils.Copy(tempReturn[0], hangHoa);

            HangHoa hangHoaTemp = GetGoodsByCode(maHangHoa);
            if (hangHoaTemp == null) return;
            try
            {
                mahanghoa = toolStrip_txtTracuu.Text = hangHoaTemp.MaHangHoa.ToUpper();
                tssltenhang.Text = hangHoaTemp.TenHangHoa;
                tsslgia.Text = new Common.Utilities().FormatMoney(double.Parse(hangHoaTemp.GiaBanLe));
                KiemTraCk(_cngkh);
                LayGiaTriThue(hangHoaTemp.MaThueGiaTriGiaTang);
                toolStrip_txtTracuu.ReadOnly = true;
                tsslsoluong.Focus();
            }
            catch { phantramchietkhau = tsslchietkhau.Text = "0"; }
        }

        /// <summary>
        /// Lấy hàng hóa theo mã
        /// </summary>
        /// <param name="code">Mã hàng hóa</param>
        /// <param name="dsHangHoa">danh sách tìm kiếm hàng hóa (nếu null thì lấy trong _hangHoaTheoKho đã có sẵn)</param>
        /// <returns>đối tượng hàng hóa</returns>
        HangHoa GetGoodsByCode(string code, HangHoa[] dsHangHoa = null)
        {
            dsHangHoa = dsHangHoa ?? _hangHoaTheoKho;
            return dsHangHoa.FirstOrDefault(k => k.MaHangHoa.ToUpper().Equals(code.ToUpper()) && !k.Deleted);
        }
    }
}
