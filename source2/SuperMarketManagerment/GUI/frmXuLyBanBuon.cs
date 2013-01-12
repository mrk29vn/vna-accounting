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
    public partial class frmXuLyBanBuon : Form
    {
        #region Điểm thưởng khách hàng
        //Entities.DiemThuongKhachHang[] dtkh = new Entities.DiemThuongKhachHang[0];
        //private void DiemThuongKhachHang()
        //{//Lấy điểm thưởng khách hàng từ csdl
        //    try
        //    {
        //        cl = new Server_Client.Client();
        //        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
        //        clientstrem = cl.SerializeObj(this.client1, "SelectDiemThuongKhachHang", new Entities.DiemThuongKhachHang("select"));
        //        dtkh = (Entities.DiemThuongKhachHang[])cl.DeserializeHepper1(clientstrem, dtkh);
        //        if (dtkh == null)
        //            dtkh = new Entities.DiemThuongKhachHang[0];
        //    }
        //    catch { }
        //}
        //private double TyLeTinh()
        //{//Lấy tỷ lệ tính từ csdl
        //    try
        //    {
        //        Entities.TyLeTinh[] tlt = new Entities.TyLeTinh[0];
        //        cl = new Server_Client.Client();
        //        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
        //        clientstrem = cl.SerializeObj(this.client1, "selectTyLeTinh", new Entities.TyLeTinh());
        //        tlt = (Entities.TyLeTinh[])cl.DeserializeHepper1(clientstrem, tlt);
        //        if (tlt == null)
        //            tlt = new Entities.TyLeTinh[0];
        //        if (tlt.Length >= 1) { return tlt[tlt.Length - 1].SoTien; }
        //        else { return 2988000; }
        //    }
        //    catch { return 2988000; }
        //}
        //private int sodiemthuong(double tien)
        //{//Tính số điểm thưởng khách hàng
        //    try
        //    {
        //        double tyle = TyLeTinh();
        //        if (tien < 0 || tyle < 0)
        //        {
        //            return 0;
        //        }
        //        return Convert.ToInt32(Math.Round(tien / tyle));
        //    }
        //    catch { return 0; }
        //}
        //public string ProIDDTKH(string tenBang)
        //{
        //    try
        //    {
        //        string idnew;
        //        cl = new Server_Client.Client();
        //        // gán TCPclient
        //        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
        //        // khởi tạo biến truyền vào với hàm khởi tạo
        //        Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
        //        // khởi tạo mảng đối tượng để hứng giá trị
        //        Entities.LayID lid = new Entities.LayID();
        //        clientstrem = cl.SerializeObj(this.client1, "LayID", lid1);
        //        // đổ mảng đối tượng vào datagripview       
        //        lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, lid);
        //        if (lid == null)
        //            return "DTKH_0001";
        //        Common.Utilities a = new Common.Utilities();
        //        idnew = a.ProcessID(lid.ID);
        //        return idnew;
        //    }
        //    catch { return ""; }
        //}
        //private string LayTenKhachHang(string maKH)
        //{
        //    try
        //    {
        //        cl = new Server_Client.Client();
        //        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
        //        clientstrem = cl.SerializeObj(this.client1, "KhachHang", new Entities.KhachHang("Select"));
        //        Entities.KhachHang[] KHACHHANG = new Entities.KhachHang[1];
        //        KHACHHANG = (Entities.KhachHang[])cl.DeserializeHepper1(clientstrem, KHACHHANG);
        //        if (KHACHHANG == null)
        //            KHACHHANG = new Entities.KhachHang[0];
        //        foreach (Entities.KhachHang item in KHACHHANG)
        //        {
        //            if (item.MaKH.ToUpper().Equals(maKH.ToUpper()))
        //            {
        //                return item.Ten;
        //            }
        //        }
        //        return string.Empty;
        //    }
        //    catch { return string.Empty; }
        //}
        //private bool CapNhatDiemThuongKhachHang(string maKH, string tien)
        //{
        //    try
        //    {
        //        Entities.DiemThuongKhachHang input = null;
        //        DiemThuongKhachHang();
        //        foreach (Entities.DiemThuongKhachHang item in dtkh)
        //        {
        //            if (item.MaKhachHang.ToUpper().Equals(maKH.ToUpper()))
        //            {//khách hàng đã có điểm
        //                //thực hiện việc cộng số lượng điểm
        //                input = TienIch.DiemThuongKhachHang_TO_DiemThuongKhachHang(item);
        //                input.ThaoTac = "CapNhat";
        //                input.TongDiem += sodiemthuong(double.Parse(tien.Replace(",", "")));
        //                input.DiemConLai = input.TongDiem - input.DiemDaDung;
        //                break;
        //            }
        //        }
        //        if (input == null)
        //        {//thêm mới trường điểm thường khách hàng
        //            input = new Entities.DiemThuongKhachHang();
        //            input.ThaoTac = "insert";
        //            input.MaDiemThuongKhachHang = ProIDDTKH("DiemThuongKhachHang");
        //            input.MaKhachHang = maKH;
        //            input.TenKhachHang = LayTenKhachHang(maKH);
        //            input.TongDiem = sodiemthuong(double.Parse(tien.Replace(",", "")));
        //            input.DiemDaDung = 0;
        //            input.DiemConLai = input.TongDiem;
        //            input.GhiChu = "";
        //            input.Deleted = false;

        //            cl = new Server_Client.Client();
        //            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
        //            clientstrem = cl.SerializeObj(this.client1, "DiemThuongKhachHang", input);
        //            int msg = 0;
        //            msg = (int)cl.DeserializeHepper(clientstrem, msg);
        //            if (msg != 0)
        //                return true;
        //            else
        //                return false;
        //        }
        //        else
        //        {//Cập nhật điểm thưởng cho khách hàng
        //            cl = new Server_Client.Client();
        //            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
        //            clientstrem = cl.SerializeObj(this.client1, "DiemThuongKhachHang", input);
        //            int msg = 0;
        //            msg = (int)cl.DeserializeHepper(clientstrem, msg);
        //            if (msg != 0)
        //                return true;
        //            else
        //                return false;
        //        }

        //    }
        //    catch { return false; }
        //}
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
        public frmXuLyBanBuon()
        {
            InitializeComponent(); datesv = DateServer.Date();
            this.kmSoLuong = GetData();
        }
        string str;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        /// <param name="str"></param>
        public frmXuLyBanBuon(string str)
        {

            try
            {
                InitializeComponent(); datesv = DateServer.Date();
                tsslin.Enabled = false;
                dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                this.str = str;
                try
                {
                    LayKhoHang();
                    new Common.Utilities().ComboxKhoHang(cbbKhoban);
                }
                catch
                {
                }
                try
                {
                    LayTenTT();
                }
                catch
                {
                }
                datesv = DateServer.Date();
                cbbHinhthucthanhtoan.SelectedIndex = 0;
                makNgaychungtu.Text = makHanthanhtoan.Text = new Common.Utilities().XuLy(2, datesv.ToShortDateString());
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

                // ++++++++++++++++++++++++++
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // lay hang hoa the kho
                List<Entities.HangHoa> array = new List<Entities.HangHoa>();
                cl = new Server_Client.Client();
                Entities.HangHoa kh = new Entities.HangHoa();
                Entities.TruyenGiaTri khoHang = (Entities.TruyenGiaTri)cbbKhoban.SelectedItem;
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
                lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, pt1);
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
            finally
            {


            }
        }

        string id;
        string nohienthoi, sochungtu, datetime, hanthanhtoan, makh, khoban, nhanvien, dondatbanhang, ghichu, nguoinhan, hinhthucthanhtoan, tientetygia, chietkhau, thanhtoankhilapphieu, thanhtoanngay, gtgt, tongtien;
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        /// <param name="str"></param>
        /// <param name="dtgvr"></param>
        public frmXuLyBanBuon(string str, DataGridViewRow dtgvr)
        {
            try
            {
                InitializeComponent(); datesv = DateServer.Date();
                dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                try
                {
                    LayKhoHang();

                }
                catch
                {
                }
                try
                {
                    LayTenTT();
                }
                catch
                {
                }
                if (str == "Sua")
                {
                    tssExcel.Enabled = true;
                    tssWord.Enabled = true;
                    tssPDF.Enabled = true;
                    palNhap.Enabled = palThem.Enabled = palXem.Enabled = tsslthem.Enabled = false;
                    id = dtgvr.Cells["HDBanHangID"].Value.ToString();
                    sochungtu = txtSochungtu.Text = dtgvr.Cells["MaHDBanHang"].Value.ToString();
                    datetime = makNgaychungtu.Text = new Common.Utilities().XuLy(2, dtgvr.Cells["NgayBan"].Value.ToString());
                    hanthanhtoan = makHanthanhtoan.Text = new Common.Utilities().XuLy(2, dtgvr.Cells["HanThanhToam"].Value.ToString());
                    makh = txtMakhachhang.Text = dtgvr.Cells["MaKhachHang"].Value.ToString();

                    khoban = dtgvr.Cells["MaKho"].Value.ToString();
                    cbbKhoban.Text = LayTenKho(khoban);
                    nhanvien = lbnhanvien.Text = dtgvr.Cells["MaNhanVien"].Value.ToString();
                    dondatbanhang = txtDondatbanhang.Text = dtgvr.Cells["MaDonDatHang"].Value.ToString();
                    ghichu = txtDiengiai.Text = dtgvr.Cells["GhiChu"].Value.ToString();
                    nguoinhan = txtnguoinhanhang.Text = dtgvr.Cells["NguoiNhanHang"].Value.ToString();
                    hinhthucthanhtoan = cbbHinhthucthanhtoan.Text = dtgvr.Cells["HinhThucThanhToan"].Value.ToString();
                    tientetygia = dtgvr.Cells["MaTienTe"].Value.ToString();
                    cbbtientetygia.Text = LayTenTT(tientetygia);
                    txttientetygia.Text = LayDonViTT(tientetygia);


                    if (dondatbanhang == "")
                    {
                        SelectData();
                    }
                    else
                        SelectData1(dondatbanhang);


                    double thanhToanNgay = 0;
                    double ptckTongHD = 0;
                    double gtckTongHD = 0;
                    double tongCK = 0;
                    double khachtra = 0;
                    double tienHang = 0;
                    double tongTien = 0;
                    double duTra = 0;
                    double tongGTGT = 0;
                    double tongTienGomVAT = 0;
                    double noHienThoi = 0;

                    //if (dtgvr.Cells["TongTienThanhToan"].Value != null)
                    //    tongTien = double.Parse(dtgvr.Cells["TongTienThanhToan"].Value.ToString());

                    if (dtgvr.Cells["KhachTra"].Value != null)
                    {
                        khachtra = double.Parse(dtgvr.Cells["KhachTra"].Value.ToString());
                        thanhtoankhilapphieu = khachtra.ToString();
                    }

                    if (dtgvr.Cells["ChietKhauTongHoaDon"].Value != null)
                        ptckTongHD = double.Parse(dtgvr.Cells["ChietKhauTongHoaDon"].Value.ToString());

                    if (dtgvr.Cells["ChietKhau"].Value != null)
                        tongCK = double.Parse(dtgvr.Cells["ChietKhau"].Value.ToString());

                    if (dtgvr.Cells["ThueGTGT"].Value != null)
                        tongGTGT = double.Parse(dtgvr.Cells["ThueGTGT"].Value.ToString());

                    if (dtgvr.Cells["NoHienThoi"].Value != null)
                        noHienThoi = double.Parse(dtgvr.Cells["NoHienThoi"].Value.ToString());
                    if (dtgvr.Cells["ThanhToanNgay"].Value != null)
                    {
                        thanhToanNgay = double.Parse(dtgvr.Cells["ThanhToanNgay"].Value.ToString());
                        thanhtoanngay = thanhToanNgay.ToString();
                    }


                    tienHang = double.Parse(TinhTien(dtgvsanpham));
                    tongTienGomVAT = tienHang - tongCK + tongGTGT;
                    gtckTongHD = (ptckTongHD * tongTienGomVAT) / 100;
                    tongTien = tongTienGomVAT - gtckTongHD;
                    duTra = khachtra - tongTien;



                    txtTienhang.Text = new Common.Utilities().FormatMoney(tienHang);
                    txtTongtien.Text = new Common.Utilities().FormatMoney(tongTien);
                    txtGTGT.Text = new Common.Utilities().FormatMoney(tongGTGT);
                    txtTongchietkhau.Text = new Common.Utilities().FormatMoney(tongCK);
                    txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(khachtra);
                    txtConphaitra.Text = new Common.Utilities().FormatMoney(duTra);
                    txtkhachtra.Text = new Common.Utilities().FormatMoney(khachtra);
                    txtdutra.Text = new Common.Utilities().FormatMoney(duTra);
                    txtNohienthoi.Text = new Common.Utilities().FormatMoney(noHienThoi);
                    txtPhantramchietkhau.Text = new Common.Utilities().FormatMoney(ptckTongHD);
                    txtChietkhau.Text = new Common.Utilities().FormatMoney(gtckTongHD);
                    txtkhachtra.Text = new Common.Utilities().FormatMoney(khachtra);

                    if ((Convert.ToDouble(khachtra) + Convert.ToDouble(thanhToanNgay) == Convert.ToDouble(tongTien)))
                    {
                        lbtinhtrang.Text = "Đã Thanh Toán";
                        tssllapphieuthanhtoan.Enabled = false;
                    }
                    else
                    {
                        lbtinhtrang.Text = "Chưa Thanh Toán";
                        tssllapphieuthanhtoan.Enabled = true;
                    }

                    grbDataGridview.Enabled = false;
                }
            }
            catch
            {
            }
        }
        Entities.ChiTietHDBanHang[] pt1;
        /// <summary>
        /// select chi tiết hóa đơn bán hàng
        /// </summary>
        public void SelectData()
        {
            try
            {
                dtgvsanpham.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ChiTietHDBanHang pt = new Entities.ChiTietHDBanHang("Select", txtSochungtu.Text);
                // khởi tạo mảng đối tượng để hứng giá trị
                pt1 = new Entities.ChiTietHDBanHang[1];
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
                    txtkhachtra.Text = txtTienhang.Text = txtGTGT.Text = txtTongtien.Text = txtTongchietkhau.Text = txtConphaitra.Text = txtThanhtoanngay.Text = "0";
                    return;
                }
                dtgvsanpham.DataSource = hhht;
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
                { }

            }
        }
        Entities.ChiTietDonDatHang[] ctddh;
        /// <summary>
        /// select chi tiết hóa đơn bán hàng
        /// </summary>
        public void SelectData1(string maDonDatHang)
        {
            try
            {
                dtgvsanpham.RowHeadersVisible = false;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ChiTietDonDatHang[] pt = new Entities.ChiTietDonDatHang[1];
                pt[0] = new Entities.ChiTietDonDatHang("Select", maDonDatHang);
                // khởi tạo mảng đối tượng để hứng giá trị
                ctddh = new Entities.ChiTietDonDatHang[1];
                clientstrem = cl.SerializeObj(this.client1, "ChiTietDonDatHang", pt);
                // đổ mảng đối tượng vào datagripview       
                ctddh = (Entities.ChiTietDonDatHang[])cl.DeserializeHepper1(clientstrem, ctddh);
                if (ctddh == null)
                {
                    dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                    return;
                }
                Entities.ChiTietDonDatHang[] pt2 = new Entities.ChiTietDonDatHang[ctddh.Length];
                int sotang = 0;
                for (int j = 0; j < ctddh.Length; j++)
                {
                    if (ctddh[j].Deleted == false)
                    {
                        if (ctddh[j].MaDonDatHang == txtDondatbanhang.Text)
                        {
                            pt2[sotang] = ctddh[j];
                            sotang++;
                        }
                    }
                }
                Entities.HangHoaHienThi[] hhht = new Entities.HangHoaHienThi[sotang];
                if (sotang != 0)
                {
                    SelectHangHoa();
                    for (int j = 0; j < sotang; j++)
                    {
                        string giasp = pt2[j].DonGia;
                        string soluongsp = pt2[j].SoLuong.ToString();
                        string thanhtien = (Convert.ToDouble(giasp) * Convert.ToDouble(soluongsp)).ToString();
                        thuegtgt = pt2[j].Thue;
                        hhht[j] = new Entities.HangHoaHienThi(pt2[j].MaDonDatHang, pt2[j].MaHangHoa.ToUpper(), pt2[j].TenHangHoa, giasp, soluongsp, pt2[j].PhanTramChietKhau.ToString(), thuegtgt, thanhtien);
                    }
                }
                else
                {
                    dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                    txtkhachtra.Text = txtTienhang.Text = txtGTGT.Text = txtTongtien.Text = txtTongchietkhau.Text = txtConphaitra.Text = txtThanhtoanngay.Text = "0";
                    return;
                }
                dtgvsanpham.DataSource = hhht;
            }
            catch
            {
            }
            finally
            {
                try
                {
                    fix();
                    maDonDatHang = "";
                }
                catch { }
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
            dtgvsanpham.Columns["ChietKhau"].HeaderText = "Chiết Khấu (%)";
            dtgvsanpham.Columns["ThueGTGT"].HeaderText = "Thuế";
            dtgvsanpham.Columns["ThanhTien"].HeaderText = "Thành Tiên (chưa GTGT)";
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
            catch
            {
            }
            finally
            {


            }
        }

        Entities.CapNhatGiaKhachHang[] cngkh;
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
                Entities.CapNhatGiaKhachHang pt = new Entities.CapNhatGiaKhachHang("Select", txtMakhachhang.Text);
                // khởi tạo mảng đối tượng để hứng giá trị
                cngkh = new Entities.CapNhatGiaKhachHang[1];
                clientstrem = cl.SerializeObj(this.client1, "CapNhatGiaKH", pt);
                // đổ mảng đối tượng vào datagripview       
                cngkh = (Entities.CapNhatGiaKhachHang[])cl.DeserializeHepper1(clientstrem, cngkh);
                if (cngkh == null)
                    cngkh = new Entities.CapNhatGiaKhachHang[0];
            }
            catch
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
                        if (hh1[j].MaHangHoa.ToUpper() == str)
                        {
                            ten = hh1[j].TenHangHoa;
                            break;
                        }
                    }
                }
                return ten;
            }
            catch
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
                        if (hh1[j].MaHangHoa.ToUpper() == str)
                        {
                            gia = hh1[j].GiaBanBuon.ToString();
                            break;
                        }
                    }
                }
                return gia;
            }
            catch
            {
                return "";
            }
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
                        if (hh1[j].MaHangHoa.ToUpper() == str)
                        {
                            gia = hh1[j].MaThueGiaTriGiaTang.ToString();
                            break;
                        }
                    }
                }
                return gia;
            }
            catch
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
                lbnhanvien.Text = Common.Utilities.User.NhanVienID;
                this.Text = "Thêm Mới - F4 Thêm Hàng Hóa - F5 Thanh toán - F6 Sửa Hàng Hóa - F7 Nhập Chiết Khấu";
                sochungtu = txtSochungtu.Text = ProID("HDBanHang");
                dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                tsslin.Enabled = false;
                tssllapphieuthanhtoan.Enabled = false;
            }
            else if (str == "Sua")
            {
                this.Text = "Quản Lý Bán Buôn - Sửa Hóa Đơn Bán Hàng";
            }
        }
        /// <summary>
        /// nút đóng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssltrove_Click(object sender, EventArgs e)
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
        /// xử lý giá trị truyền tới
        /// </summary>
        /// <returns></returns>
        public bool KiemTra()
        {

            if (txtMakhachhang.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + lblMakhachhang.Text, "Hệ thống cảnh báo");
                txtMakhachhang.Focus();
                return false;
            }

            if (cbbHinhthucthanhtoan.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + lbhinhthucthanhtoan.Text, "Hệ thống cảnh báo");
                cbbHinhthucthanhtoan.Focus();
                return false;
            }
            if (cbbKhoban.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + lblKhoban.Text, "Hệ thống cảnh báo");
                cbbKhoban.Focus();
                return false;
            }
            if (cbbtientetygia.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập Tiền tệ", "Hệ thống cảnh báo");
                cbbtientetygia.Focus();
                return false;
            }
            if (txtNohienthoi.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + lblNohienthoi.Text, "Hệ thống cảnh báo");
                txtNohienthoi.Focus();
                return false;
            }
            else
            {
                try
                {
                    float.Parse(txtNohienthoi.Text);
                }
                catch
                {
                    MessageBox.Show("Bạn cần phải nhập " + lblNohienthoi.Text, "Hệ thống cảnh báo");
                    txtNohienthoi.Focus();
                    return false;
                }
            }
            if (makHanthanhtoan.Text.Length != 10)
            {
                MessageBox.Show("Bạn cần phải nhập " + lblHanthanhtoan.Text, "Hệ thống cảnh báo");
                makHanthanhtoan.Focus();
                return false;
            }
            string ngayct = "";
            try
            {
                ngayct = new Common.Utilities().MyDateConversion(makHanthanhtoan.Text);
            }
            catch
            {
                ngayct = null;
            }
            if (ngayct == null)
            {
                MessageBox.Show("Bạn nhập sai định dạng ngày tháng", "Hệ thống cảnh báo");
                makHanthanhtoan.Focus();
                return false;
            }
            else
            {
                string ngayht = new Common.Utilities().XuLy(1, datesv.ToShortDateString());

                try
                {
                    if (Convert.ToDateTime(ngayct) < Convert.ToDateTime(ngayht))
                    {
                        MessageBox.Show("Hạn thanh toán phải lớn hơn Ngày hiện tại", "Hệ thống cảnh báo");
                        makHanthanhtoan.Focus();
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("Hạn thanh toán nhập sai định dạng", "Hệ thống cảnh báo");
                    makHanthanhtoan.Focus();
                    return false;
                }
            }

            if (dtgvsanpham.DataSource == null)
            {
                MessageBox.Show("Bạn cần phải nhận Đơn hàng");
                return false;
            }
            if (dtgvsanpham.RowCount == 0)
            {
                MessageBox.Show("Bạn cần phải nhận Đơn hàng");
                return false;
            }
            return true;
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
                cbbKhoban.Items.Clear();
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
                        cbbKhoban.Items.Add(kh1[i].TenKho);
                    }

                }
            }
            catch
            {
                cbbKhoban.Items.Clear();
                cbbKhoban.Text = "";
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
                foreach (Entities.KhoHang item in kh1)
                {
                    if (item.TenKho == tenKho)
                    {
                        return item.MaKho;
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
            try
            {
                foreach (Entities.KhoHang item in kh1)
                {
                    if (item.MaKho == maKho)
                    {
                        return item.TenKho;
                    }
                }
                return "";
            }
            catch
            {
                return "";
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
                if (tt == null)
                    tt = new Entities.TienTe[0];
                if (tt.Length > 0)
                {
                    int sl = tt.Length;
                    for (int i = 0; i < sl; i++)
                    {
                        cbbtientetygia.Items.Add(tt[i].TenTienTe);
                    }
                    cbbtientetygia.SelectedIndex = 0;
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
                    txtDondatbanhang.Text = "";
                    dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                    toolStrip_Insert.Enabled = true;
                    dtgvsanpham.Enabled = true;
                    txtNohienthoi.Text = frmTimKH.drvr.Cells["DuNo"].Value.ToString();
                    frmTimKH.drvr = null;
                    txtnguoinhanhang.Focus();
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
        /// <summary>
        /// tìm đơn đặt hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTimdondat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMakhachhang.Text.Length != 0)
                {
                    frmTimDonDatHang fr = new frmTimDonDatHang(txtMakhachhang.Text);
                    fr.ShowDialog();
                    if (frmTimDonDatHang.drvr != null)
                    {
                        string maDonDatHang = txtDondatbanhang.Text = frmTimDonDatHang.drvr.Cells["MaDonDatHang"].Value.ToString();
                        frmTimDonDatHang.drvr = null;
                        toolStrip_Insert.Enabled = false;
                        dtgvsanpham.Enabled = false;
                        SelectData1(maDonDatHang);
                        cbbHinhthucthanhtoan.Focus();
                        if (txtPhantramchietkhau.Text == "")
                            phantramchietkhau = "0";
                        else
                            phantramchietkhau = txtPhantramchietkhau.Text;
                        TinhToan();
                        txtChietkhau.Text = new Common.Utilities().FormatMoney(((Convert.ToDouble(phantramchietkhau) / 100) * Convert.ToDouble(txtTienhang.Text)));
                        txtTongchietkhau.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(TinhCK(dtgvsanpham)));
                        txtTongchietkhau.Text = (Convert.ToDouble(txtChietkhau.Text) + Convert.ToDouble(txtTongchietkhau.Text)).ToString();
                        txtTongtien.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(tongtienthanhtoan) - Convert.ToDouble(txtTongchietkhau.Text) - Convert.ToDouble(txtgiatrithe.Text));
                        txtConphaitra.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(tongtienthanhtoan) - Convert.ToDouble(txtThanhtoanngay.Text) - Convert.ToDouble(txtTongchietkhau.Text));
                        txtdutra.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(txtkhachtra.Text) - Convert.ToDouble(tongtienthanhtoan) + Convert.ToDouble(txtTongchietkhau.Text));

                    }
                }
                else
                    MessageBox.Show("Bạn hãy nhập Mã khách hàng");
            }
            catch
            {
            }
        }
        /// <summary>
        /// xử lý option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void thiêtLâpThôngSôToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXuLyBanBuon_Load(object sender, EventArgs e)
        {
            try
            {
                XuLyStr();

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
        /// kiểm tra gí trị nhập vào
        /// </summary>
        /// <param name="pxh"></param>
        /// <returns></returns>
        public bool Check(Entities.HDBanHang pxh)
        {
            bool gt = true;
            string datetimenew = new Common.Utilities().XuLy(2, (Convert.ToDateTime(pxh.NgayBan).ToShortDateString()));
            string datetimenew2 = new Common.Utilities().XuLy(2, (Convert.ToDateTime(pxh.HanThanhToam).ToShortDateString()));
            if (datetime != datetimenew)
            {
                datetime = makNgaychungtu.Text = datetimenew;
                gt = false;
            }
            if (makh != pxh.MaKhachHang)
            {
                makh = txtMakhachhang.Text = pxh.MaKhachHang;
                gt = false;
            }
            if (nohienthoi != pxh.NoHienThoi)
            {
                nohienthoi = txtNohienthoi.Text = pxh.NoHienThoi;
                gt = false;
            }
            if (nguoinhan != pxh.NguoiNhanHang)
            {
                nguoinhan = txtnguoinhanhang.Text = pxh.NguoiNhanHang;
                gt = false;
            }
            if (hinhthucthanhtoan != pxh.HinhThucThanhToan)
            {
                hinhthucthanhtoan = cbbHinhthucthanhtoan.Text = pxh.HinhThucThanhToan;
                gt = false;
            }
            if (khoban != pxh.MaKho)
            {
                khoban = pxh.MaKho;
                cbbKhoban.Text = LayTenKho(khoban);
                gt = false;
            }
            if (hanthanhtoan != datetimenew2)
            {
                hanthanhtoan = makHanthanhtoan.Text = datetimenew2;
                gt = false;
            }
            if (dondatbanhang != pxh.MaHDBanHang)
            {
                dondatbanhang = txtDondatbanhang.Text = pxh.MaHDBanHang;
                gt = false;
            }
            if (nhanvien != pxh.MaNhanVien)
            {
                nhanvien = lbnhanvien.Text = pxh.MaNhanVien;
                gt = false;
            }
            if (tientetygia != pxh.MaTienTe)
            {
                tientetygia = pxh.MaTienTe;
                cbbtientetygia.Text = LayTenTT(tientetygia);
                txttientetygia.Text = LayDonViTT(tientetygia);
                gt = false;
            }
            if (chietkhau != pxh.ChietKhau)
            {
                chietkhau = txtChietkhau.Text = pxh.ChietKhau;
                gt = false;
            }
            if (thanhtoankhilapphieu != pxh.ThanhToanNgay)
            {
                thanhtoankhilapphieu = txtThanhtoanngay.Text = pxh.ThanhToanNgay;
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
        /// kiểm tra dtgv trước khi insert
        /// </summary>
        /// <param name="dgv"></param>
        public Entities.ChiTietHDBanHang[] CheckDataGridInsert(DataGridView dgv)
        {
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
        /// kiểm tra dtgv trừ số lượng
        /// </summary>
        /// <param name="dgv"></param>
        public Entities.ChiTietKhoHangTheoHoaHonNhap[] CheckDataGridTruSL(DataGridView dgv)
        {
            ArrayList array = new ArrayList();
            try
            {
                if (dgv.RowCount != 0)
                {
                    Entities.ChiTietKhoHangTheoHoaHonNhap[] cthdbh = new Entities.ChiTietKhoHangTheoHoaHonNhap[dgv.RowCount];
                    Entities.ChiTietKhoHangTheoHoaHonNhap temp = new Entities.ChiTietKhoHangTheoHoaHonNhap();
                    for (int j = 0; j < dgv.RowCount; j++)
                    {
                        bool kt = false;
                        string maKho = LayMaKho(cbbKhoban.Text);
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
        /// cap nhat lai trang thai don dat hang
        /// </summary>
        private Entities.DonDatHang CapNhatTrangThaiDonDatHang(string hanhdong, string MaDonDatHang, string trangthai)
        {
            try
            {
                if (MaDonDatHang.Length > 0)
                {
                    Entities.DonDatHang dat = new Entities.DonDatHang();
                    dat.Hanhdong = hanhdong;
                    dat.MaDonDatHang = MaDonDatHang;
                    dat.TrangThaiDonDatHang = trangthai;
                    return dat;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
        public bool Delete()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.HDBanHang a = new Entities.HDBanHang("DeleteTheoMa", txtSochungtu.Text, "");
                clientstrem = cl.SerializeObj(this.client1, "HDBanHang", a);
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                return kt;
            }
            catch
            {
                return false;
            }
        }

        string duno = "0";
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
                        string date = "", date2 = "";
                        date = new Common.Utilities().MyDateConversion(makNgaychungtu.Text);
                        try
                        {
                            date2 = new Common.Utilities().MyDateConversion(makHanthanhtoan.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Nhập sai định dạng ngày tháng", "Hệ thông cảnh báo");
                            date2 = "";
                            return;
                        }
                        Entities.HDBanHang pt = new Entities.HDBanHang();
                        string makho = LayMaKho(cbbKhoban.Text);
                        string matt = LayMaTT(cbbtientetygia.Text);

                        if (string.IsNullOrEmpty(txtPhantramchietkhau.Text))
                            txtPhantramchietkhau.Text = "0";
                        if (string.IsNullOrEmpty(txtkhachtra.Text))
                            txtkhachtra.Text = "0";


                        pt = new Entities.HDBanHang("Insert", 0, txtSochungtu.Text, Convert.ToDateTime(date), txtMakhachhang.Text,
                            txtNohienthoi.Text, txtnguoinhanhang.Text, cbbHinhthucthanhtoan.Text, makho, DateTime.Parse(date2),
                            txtDondatbanhang.Text, Common.Utilities.User.NhanVienID, matt, txtTongchietkhau.Text, "0",
                            txtThanhtoanngay.Text, txtGTGT.Text, txtTongtien.Text, false, " ", "0", txtDiengiai.Text,
                            false, Common.Utilities.User.TenDangNhap, txtkhachtra.Text, txtPhantramchietkhau.Text, string.Empty, "0");
                        pt.ChiTietHDBanHang = CheckDataGridInsert(dtgvsanpham);
                        if (txtDondatbanhang.Text.Length != 0)
                        {
                            pt.DonDatHang = CapNhatTrangThaiDonDatHang("Update", txtDondatbanhang.Text, "Đã thành công");
                        }
                        pt.ChiTietKhoHangTheoHoaHonNhap = CheckDataGridTruSL(dtgvsanpham);
                        double khNo = 0;
                        double tongTienHD = 0;
                        double tongThanhToan = 0;

                        if (!string.IsNullOrEmpty(txtTongtien.Text))
                            tongTienHD = double.Parse(txtTongtien.Text);

                        if (!string.IsNullOrEmpty(txtkhachtra.Text))
                            tongThanhToan = double.Parse(txtkhachtra.Text);

                        if (tongThanhToan > tongTienHD)
                            khNo = 0;
                        else
                            khNo = tongTienHD - tongThanhToan;

                        pt.KhachHang = new Entities.KhachHang("UpdateDuNo", txtMakhachhang.Text, khNo.ToString());
                        clientstrem = cl.SerializeObj(this.client1, "HDBanHang", pt);
                        bool kt1 = false;
                        kt1 = (bool)cl.DeserializeHepper(clientstrem, kt1);
                        if (kt1 == true)
                        {
                            ////Cập nhật điểm thưởng cho khách hàng
                            //if (CapNhatDiemThuongKhachHang(txtMakhachhang.Text, txtTongtien.Text))
                            //{
                            //    //Cập nhật điểm thưởng khách hàng thành công
                            //}
                            //else
                            //{
                            //    //Cập nhật điểm thưởng khách hàng thất bại
                            //}
                            ///////////////////////////////////////

                            string khachtra = "0";
                            if (txtkhachtra.Text == "")
                                khachtra = "0";
                            else
                                khachtra = txtkhachtra.Text;
                            //timerRun.Start();
                            if (cbkiemtra.Checked == true)
                            {
                                Entities.KhachHang kh = GetThongTinKhachHang(txtMakhachhang.Text);
                                frmBaoCaorpt bcrpt = new frmBaoCaorpt("HDBanBuon", txtSochungtu.Text,
                                    Double.Parse(txtTongchietkhau.Text), khachtra, txtdutra.Text, txtTongtien.Text,
                                    txtGTGT.Text, Common.Utilities.User.TenNhanVien, "in", makNgaychungtu.Text, txtgiatrithe.Text, "0", "", txtChietkhau.Text, kh.DiaChi, txtnguoinhanhang.Text, txtDiengiai.Text);
                            }
                            //timerRun.Stop();
                            GiaVonBanHang(pt.ChiTietHDBanHang);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại - xin hãy thử lại", "Hệ thống cảnh báo");
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
                        string date = new Common.Utilities().MyDateConversion(makNgaychungtu.Text);
                        string date2 = new Common.Utilities().MyDateConversion(makHanthanhtoan.Text);
                        Entities.HDBanHang pt = new Entities.HDBanHang();
                        string makho = LayMaKho(cbbKhoban.Text);
                        string matt = LayMaTT(cbbtientetygia.Text);
                        pt = new Entities.HDBanHang("Insert", 0, txtSochungtu.Text, Convert.ToDateTime(date), txtMakhachhang.Text,
                                                    txtNohienthoi.Text, txtnguoinhanhang.Text, cbbHinhthucthanhtoan.Text, makho, DateTime.Parse(date2),
                                                    txtDondatbanhang.Text, Common.Utilities.User.NhanVienID, matt, txtTongchietkhau.Text, "0",
                                                    txtThanhtoanngay.Text, txtGTGT.Text, txtTongtien.Text, false, " ", "0", txtDiengiai.Text,
                                                    false, Common.Utilities.User.TenDangNhap, txtkhachtra.Text, txtPhantramchietkhau.Text, string.Empty, "0");

                        clientstrem = cl.SerializeObj(this.client1, "HDBanHang", pt);
                        bool kt1 = false;
                        kt1 = (bool)cl.DeserializeHepper(clientstrem, kt1);
                        if (kt1 == true)
                        {
                            this.Close();
                        }
                        else
                            MessageBox.Show("thất bại - xin kiểm tra lại dữ liệu", "Hệ thống cảnh báo");

                    }
                    else
                        MessageBox.Show("Dữ liệu đã bị thay đổi - Hãy kiểm tra lại", "Hệ thống cảnh báo");
                }
            }
            catch
            {
            }
            finally
            {


            }
        }
        //private void EventChung_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string khachtra = "0";
        //        if (txtkhachtra.Text == "")
        //            khachtra = "0";
        //        else
        //            khachtra = txtkhachtra.Text;
        //        txtkhachtra.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(khachtra));
        //        txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(txtThanhtoanngay.Text));
        //    }
        //    catch
        //    {
        //    }
        //}
        public void XuLyHH()
        {
            try
            {
                if (txtMakhachhang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn hãy nhập Mã khách hàng", "Hệ thống cảnh báo");
                    btnTimmakhachhang.Focus();
                    return;
                }
                if (cbbKhoban.Text.Length == 0)
                {
                    MessageBox.Show("Bạn hãy nhập Kho hàng", "Hệ thống cảnh báo");
                    cbbKhoban.Focus();
                    return;
                }
                string maKho = LayMaKho(cbbKhoban.Text);
                frmTimHangHoa thh = new frmTimHangHoa(maKho, false);
                thh.ShowDialog();
                if (frmTimHangHoa.drvr != null)
                {

                    mahanghoa = toolStrip_txtTracuu.Text = frmTimHangHoa.drvr.Cells["MaHangHoa"].Value.ToString().ToUpper();
                    tssltenhang.Text = frmTimHangHoa.drvr.Cells["TenHangHoa"].Value.ToString();
                    tsslgia.Text = new Common.Utilities().FormatMoney(double.Parse(frmTimHangHoa.drvr.Cells["GiaBanBuon"].Value.ToString()));
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
            catch
            {
            }
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
                    XuLyHH();
                }
                if (e.KeyCode == Keys.Enter)
                {

                    if (txtMakhachhang.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn hãy nhập Mã khách hàng", "Hệ thống cảnh báo");
                        btnTimmakhachhang.Focus();
                        toolStrip_txtTracuu.Text = "";
                        return;
                    }
                    if (cbbKhoban.Text.Length == 0)
                    {
                        MessageBox.Show("Bạn hãy nhập Kho hàng", "Hệ thống cảnh báo");
                        cbbKhoban.Focus();
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
                    bool retVal = true;
                    // Qui đổi đơn vị tính
                    foreach (Entities.QuyDoiDonViTinh item in quidoidvt)
                    {
                        if (item.MaHangQuyDoi.ToUpper().Equals(mahanghoa.ToUpper()))
                        {
                            tssltenhang.Text = item.TenHangDuocQuyDoi;
                            tsslsoluong.Focus();
                            retVal = false;
                            break;
                        }
                    }
                    if (tssltenhang.Text.Length == 0)
                    {
                        //MessageBox.Show("Hàng hóa không có trong kho", "Hệ thống cảnh báo");
                        //return;
                    }
                    if (retVal)
                        LayHangHoaTheoMa();
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
        /// <summary>
        /// kiểm tra chiết khấu
        /// </summary>
        /// <param name="cnhkh"></param>
        public void KiemTraCK(Entities.CapNhatGiaKhachHang[] cnhkh)
        {
            try
            {
                foreach (Entities.CapNhatGiaKhachHang item in cnhkh)
                {
                    if (item.MaKhachHang == txtMakhachhang.Text && item.MaHangHoa == mahanghoa)
                    {
                        DateTime datebegin = item.NgayBatDau;
                        DateTime dateend = item.NgayKetThuc;
                        DateTime datenow = datesv;
                        if (datenow.Date >= datebegin.Date && datenow.Date <= dateend.Date)
                        {
                            phantramchietkhau = tsslchietkhau.Text = item.PhanTramChietKhau.ToString();
                        }
                    }
                }
            }
            catch
            {
            }
        }
        Entities.HangHoaHienThi[] hh;
        /// <summary>
        /// thêm row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbKhoban.Text.Length == 0)
                {
                    MessageBox.Show("Chưa có Kho hàng", "Hệ thống cảnh báo");
                    cbbKhoban.Focus();
                    return;
                }
                if (tssltenhang.Text.Length == 0)
                {
                    MessageBox.Show("Chưa có tên hàng", "Hệ thống cảnh báo");
                    return;
                }
                if (tsslsoluong.Text.Length == 0)
                {
                    MessageBox.Show("Chưa có số lượng hàng", "Hệ thống cảnh báo");
                    tsslsoluong.Focus();
                    return;
                }
                mahanghoa = toolStrip_txtTracuu.Text;
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
        /// <summary>
        /// xử ly thêm row
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
                                        sl = "0";
                                    else
                                        sl = tsslsoluong.Text;
                                    int soluongmoi = Convert.ToInt32(sl);
                                    int soluonghientai = soluongcu + soluongmoi;
                                    string giasp = "0";
                                    // Lay gia san pham
                                    DateTime ngayBan = DateTime.Parse(new Common.Utilities().MyDateConversion(makNgaychungtu.Text));
                                    Entities.KhuyenMaiSoLuong giaTheoSL = LayGia(mahanghoa, soluonghientai.ToString(), ngayBan, this.kmSoLuong);

                                    if (giaTheoSL != null)
                                    {
                                        if (!giaTheoSL.GiaBanBuon.ToString().Equals("0"))
                                            giasp = giaTheoSL.GiaBanBuon.ToString();
                                        else
                                            giasp = new Common.Utilities().FormatMoney(double.Parse(dtgvsanpham[3, j].Value.ToString()));
                                    }
                                    else
                                        giasp = new Common.Utilities().FormatMoney(double.Parse(dtgvsanpham[3, j].Value.ToString()));

                                    string thanhtien = new Common.Utilities().FormatMoney(Convert.ToDouble(soluonghientai) * Convert.ToDouble(giasp));
                                    hh[j] = new Entities.HangHoaHienThi(txtSochungtu.Text, dtgvsanpham[1, j].Value.ToString(), dtgvsanpham[2, j].Value.ToString(),
                                        giasp, soluonghientai.ToString(), dtgvsanpham[5, j].Value.ToString(),
                                       dtgvsanpham[6, j].Value.ToString(), thanhtien);
                                    kt1 = "ok";
                                }
                                else
                                    hh[j] = new Entities.HangHoaHienThi(txtSochungtu.Text,
                                        dtgvsanpham[1, j].Value.ToString(), dtgvsanpham[2, j].Value.ToString(),
                                        dtgvsanpham[3, j].Value.ToString(), dtgvsanpham[4, j].Value.ToString(),
                                        dtgvsanpham[5, j].Value.ToString(), dtgvsanpham[6, j].Value.ToString(),
                                        dtgvsanpham[7, j].Value.ToString());

                            }
                        }
                        else
                        {
                            for (int j = 0; j < hh.Length; j++)
                            {
                                if (j < hh.Length - 1)
                                    hh[j] = new Entities.HangHoaHienThi(txtSochungtu.Text, dtgvsanpham[1, j].Value.ToString(),
                                        dtgvsanpham[2, j].Value.ToString(), dtgvsanpham[3, j].Value.ToString(), dtgvsanpham[4, j].Value.ToString(),
                                        dtgvsanpham[5, j].Value.ToString(), dtgvsanpham[6, j].Value.ToString(), dtgvsanpham[7, j].Value.ToString());
                                else
                                {
                                    string sl = "0";
                                    if (tsslsoluong.Text == "")
                                        sl = "0";
                                    else
                                        sl = tsslsoluong.Text;
                                    string soluongsp = sl;
                                    string giasp = "0";
                                    // Lay gia san pham
                                    DateTime ngayBan = DateTime.Parse(new Common.Utilities().MyDateConversion(makNgaychungtu.Text));
                                    Entities.KhuyenMaiSoLuong giaTheoSL = LayGia(mahanghoa, soluongsp.ToString(), ngayBan, this.kmSoLuong);

                                    if (giaTheoSL != null)
                                    {
                                        if (!giaTheoSL.GiaBanBuon.ToString().Equals("0"))
                                            giasp = giaTheoSL.GiaBanBuon.ToString();
                                        else
                                            giasp = new Common.Utilities().FormatMoney(double.Parse(tsslgia.Text));
                                    }
                                    else
                                        giasp = new Common.Utilities().FormatMoney(double.Parse(tsslgia.Text));

                                    string thanhtien = new Common.Utilities().FormatMoney(Convert.ToDouble(giasp) * Convert.ToDouble(soluongsp));
                                    hh[hh.Length - 1] = new Entities.HangHoaHienThi(txtSochungtu.Text, mahanghoa, tssltenhang.Text, giasp, soluongsp, tsslchietkhau.Text, tsslgtgt.Text, thanhtien);
                                    kt1 = "ok";
                                }


                            }
                        }
                        if (kt1 == "")
                        {
                            string sl = "0";
                            if (tsslsoluong.Text == "")
                                sl = "0";
                            else
                                sl = tsslsoluong.Text;
                            string soluongsp = sl;
                            string giasp = "0";
                            // Lay gia san pham
                            DateTime ngayBan = DateTime.Parse(new Common.Utilities().MyDateConversion(makNgaychungtu.Text));
                            Entities.KhuyenMaiSoLuong giaTheoSL = LayGia(mahanghoa, soluongsp.ToString(), ngayBan, this.kmSoLuong);

                            if (giaTheoSL != null)
                            {
                                if (!giaTheoSL.GiaBanBuon.ToString().Equals("0"))
                                    giasp = giaTheoSL.GiaBanBuon.ToString();
                                else
                                    giasp = new Common.Utilities().FormatMoney(double.Parse(tsslgia.Text));
                            }
                            else
                                giasp = new Common.Utilities().FormatMoney(double.Parse(tsslgia.Text));

                            string thanhtien = new Common.Utilities().FormatMoney(Convert.ToDouble(giasp) * Convert.ToDouble(soluongsp));
                            hh[hh.Length - 1] = new Entities.HangHoaHienThi(txtSochungtu.Text, mahanghoa, tssltenhang.Text, giasp, soluongsp, tsslchietkhau.Text, tsslgtgt.Text, thanhtien);
                        }

                    }
                    catch
                    {
                        string sl = "0";
                        if (tsslsoluong.Text == "")
                            sl = "0";
                        else
                            sl = tsslsoluong.Text;
                        string soluongsp = sl;
                        string giasp = "0";
                        // Lay gia san pham
                        DateTime ngayBan = DateTime.Parse(new Common.Utilities().MyDateConversion(makNgaychungtu.Text));
                        Entities.KhuyenMaiSoLuong giaTheoSL = LayGia(mahanghoa, soluongsp.ToString(), ngayBan, this.kmSoLuong);

                        if (giaTheoSL != null)
                        {
                            if (!giaTheoSL.GiaBanBuon.ToString().Equals("0"))
                                giasp = giaTheoSL.GiaBanBuon.ToString();
                            else
                                giasp = new Common.Utilities().FormatMoney(double.Parse(tsslgia.Text));
                        }
                        else
                            giasp = new Common.Utilities().FormatMoney(double.Parse(tsslgia.Text));

                        string thanhtien = new Common.Utilities().FormatMoney(Convert.ToDouble(giasp) * Convert.ToDouble(soluongsp));
                        hh[0] = new Entities.HangHoaHienThi(txtSochungtu.Text, mahanghoa, tssltenhang.Text, giasp, soluongsp, tsslchietkhau.Text, tsslgtgt.Text, thanhtien);
                    }

                    dtgvsanpham.DataSource = hh;
                    string phantramchietkhau = "0";
                    if (txtPhantramchietkhau.Text == "")
                        phantramchietkhau = "0";
                    else
                        phantramchietkhau = txtPhantramchietkhau.Text;

                    TinhToan();
                    txtChietkhau.Text = new Common.Utilities().FormatMoney(((Convert.ToDouble(phantramchietkhau) / 100) * Convert.ToDouble(txtTienhang.Text)));
                    txtTongchietkhau.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(TinhCK(dtgvsanpham)));
                    txtTongchietkhau.Text = (Convert.ToDouble(txtChietkhau.Text) + Convert.ToDouble(txtTongchietkhau.Text)).ToString();
                    txtTongtien.Text = txtkhachtra.Text = txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(tongtienthanhtoan) - Convert.ToDouble(txtTongchietkhau.Text) - Convert.ToDouble(txtgiatrithe.Text));
                    txtConphaitra.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(tongtienthanhtoan) - Convert.ToDouble(txtThanhtoanngay.Text) - Convert.ToDouble(txtTongchietkhau.Text));
                    txtdutra.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(txtkhachtra.Text) - Convert.ToDouble(tongtienthanhtoan) + Convert.ToDouble(txtTongchietkhau.Text));
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
                    tsslgia.Text = "0";
                    tsslsoluong.Text = "";
                    tsslchietkhau.Text = "0";
                    tsslgtgt.Text = "0";

                }
                catch
                {
                }
            }
        }
        int i;
        string ck = "";
        /// <summary>
        /// xử lý khi click tra cứu
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
            tsslgtgt.Text = "0";
            tsslsoluong.Text = "";
        }
        /// <summary>
        /// tính tiền hàng
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public string TinhTienHang(DataGridView dgv)
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
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// xử lý khi nhập vào control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslsoluong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sl = "0";
                if (tsslsoluong.Text == "")
                    sl = "0";
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
        /// xử lý khi nhập vào control
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
                double tongCK = 0;
                double thueGTGT = 0;
                double ptckTongHD = 0;
                double gtckTongHD = 0;
                double tongtienHangGTGT = 0;
                double tongtien = 0;

                try
                {
                    if (!string.IsNullOrEmpty(txtTienhang.Text))
                        tienHang = double.Parse(txtTienhang.Text);

                    if (!string.IsNullOrEmpty(txtTongchietkhau.Text))
                        tongCK = double.Parse(txtTongchietkhau.Text);

                    if (!string.IsNullOrEmpty(txtGTGT.Text))
                        thueGTGT = double.Parse(txtGTGT.Text);

                    if (!string.IsNullOrEmpty(txtPhantramchietkhau.Text))
                        ptckTongHD = double.Parse(txtPhantramchietkhau.Text);

                    tongtienHangGTGT = tienHang - tongCK + thueGTGT;
                    gtckTongHD = (tongtienHangGTGT * ptckTongHD) / 100;
                    tongtien = tongtienHangGTGT - gtckTongHD;
                    txtChietkhau.Text = new Common.Utilities().FormatMoney(gtckTongHD);
                    txtTongtien.Text = new Common.Utilities().FormatMoney(tongtien);
                }
                catch (Exception)
                {

                }
            }
        }

        /// <summary>
        /// tinh Tong tien
        /// </summary>
        /// <returns></returns>
        public double TongTien()
        {

            string tongtien = "0";
            try
            {
                tongtien = new Common.Utilities().FormatMoney(Convert.ToDouble(tongtienthanhtoan) - Convert.ToDouble(txtTongchietkhau.Text) - Convert.ToDouble(txtgiatrithe.Text));
            }
            catch (Exception)
            {

            }
            return double.Parse(tongtien);
        }

        string tongtienthanhtoan = "0";
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
                txtTongtien.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(tongtienthanhtoan) - Convert.ToDouble(txtTongchietkhau.Text) - Convert.ToDouble(txtgiatrithe.Text));
            }
            catch
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
                        double thue = Convert.ToDouble(dgv["ThueGTGT", i].Value.ToString());
                        double tienhang = Convert.ToDouble(dtgvsanpham["ThanhTien", i].Value.ToString());
                        double tienchietkhau = (Convert.ToDouble(dtgvsanpham["ChietKhau", i].Value.ToString()) / 100) * tienhang;
                        string phantramchietkhau = "0";
                        if (txtPhantramchietkhau.Text == "")
                            phantramchietkhau = "0";
                        else
                            phantramchietkhau = txtPhantramchietkhau.Text;
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
                        double thue = Convert.ToDouble(dgv["ThueGTGT", i].Value.ToString());
                        double thanhtien = Convert.ToDouble(dtgvsanpham["ThanhTien", i].Value.ToString());
                        double phantramck = chietkhau / 100;
                        gia += phantramck * thanhtien;
                    }
                    return Math.Round(gia).ToString();
                }
                gia += Convert.ToDouble(txtChietkhau.Text);
                return Math.Round(gia).ToString();
            }
            catch
            {
                return "0";
            }
        }
        /// <summary>
        /// xử lý khi nhập vào control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtThanhtoanngay_TextChanged(object sender, EventArgs e)
        {

        }

        int run = 0;
        /// <summary>
        /// xử lý timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_txtTracuu_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        /// <summary>
        /// lấy hàng hóa theo mã
        /// </summary>
        private void LayHangHoaTheoMa()
        {
            DateTime start = DateTime.Now;


            try
            {
                if (this.hangHoaTheoKho.Length > 0)
                {
                    bool ktdata = false;
                    foreach (Entities.HangHoa item in this.hangHoaTheoKho)
                    {
                        if (item.MaHangHoa.ToUpper().Equals(toolStrip_txtTracuu.Text.ToUpper()) && item.Deleted == false)
                        {
                            try
                            {
                                mahanghoa = toolStrip_txtTracuu.Text = item.MaHangHoa.ToUpper();
                                tssltenhang.Text = item.TenHangHoa;
                                tsslgia.Text = new Common.Utilities().FormatMoney(double.Parse(item.GiaBanBuon.ToString()));
                                //SelectMaCapNhatKH();
                                KiemTraCK(cngkh);
                                LayGiaTriThue(item.MaThueGiaTriGiaTang);
                                toolStrip_txtTracuu.ReadOnly = true;
                                tsslsoluong.Focus();
                                ktdata = true;
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
            finally
            {


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
            catch
            {
            }
            finally
            {

            }
        }
        /// <summary>
        /// xử lý khi nhập vào control
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
                    //txtkhachtra.Text = string.Empty;
                    txtdutra.Text = string.Empty;
                    txtThanhtoanngay.Text = string.Empty;
                    txtConphaitra.Text = string.Empty;
                    double khachTra = 0;
                    double duTra = 0;
                    double tongTien = 0;
                    if (!string.IsNullOrEmpty(txtTongtien.Text))
                        tongTien = double.Parse(txtTongtien.Text);

                    if (!string.IsNullOrEmpty(txtkhachtra.Text))
                        khachTra = double.Parse(txtkhachtra.Text);

                    if (!string.IsNullOrEmpty(txtdutra.Text))
                        duTra = double.Parse(txtdutra.Text);

                    duTra = khachTra - tongTien;
                    txtdutra.Text = new Common.Utilities().FormatMoney(duTra);
                    txtConphaitra.Text = new Common.Utilities().FormatMoney(duTra);
                    txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(khachTra);
                }
                catch (Exception)
                {
                }
            }

        }
        /// <summary>
        /// xử lý khi thay đổi kích cỡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXuLyBanBuon_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// xử lý khi click vào lập phiếu thanh toán
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssllapphieuthanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                string date = new Common.Utilities().MyDateConversion(makNgaychungtu.Text);
                string date2 = new Common.Utilities().MyDateConversion(makHanthanhtoan.Text);
                string makho = LayMaKho(cbbKhoban.Text);
                string matt = LayMaTT(cbbtientetygia.Text);
                Entities.HDBanHang[] pt1 = new Entities.HDBanHang[1];
                pt1[0] = new Entities.HDBanHang("Update", int.Parse(id), txtSochungtu.Text, Convert.ToDateTime(date),
                    txtMakhachhang.Text, txtNohienthoi.Text, txtnguoinhanhang.Text, cbbHinhthucthanhtoan.Text, makho,
                    DateTime.Parse(date2), txtDondatbanhang.Text, Common.Utilities.User.TenNhanVien, matt,
                    txtChietkhau.Text, thanhtoankhilapphieu, thanhtoanngay, txtGTGT.Text, txtTongtien.Text, false, " ", "0",
                    txtDiengiai.Text, false, Common.Utilities.User.TenDangNhap, txtkhachtra.Text, txtPhantramchietkhau.Text, string.Empty, "0");

                frmXuLyPhieuTTCuaKH pt = new frmXuLyPhieuTTCuaKH(pt1);
                pt.ShowDialog();
                this.Close();
            }
            catch
            {
            }
        }
        /// <summary>
        /// xử lý khi ấn phím
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStrip_Insert_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbbKhoban.Text.Length == 0)
                {
                    MessageBox.Show("Chưa có Kho hàng", "Hệ thống cảnh báo");
                    cbbKhoban.Focus();
                    return;
                }
                if (tssltenhang.Text.Length == 0)
                {
                    MessageBox.Show("Chưa có tên hàng", "Hệ thống cảnh báo");
                    return;
                }
                if (tsslsoluong.Text.Length == 0)
                {
                    MessageBox.Show("Chưa có số lượng hàng", "Hệ thống cảnh báo");
                    tsslsoluong.Focus();
                    return;
                }
                mahanghoa = toolStrip_txtTracuu.Text;
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
            KeyUp_Chung(sender, e);
        }

        private void cbbtientetygia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txttientetygia.Text = LayDonViTT(LayMaTT(cbbtientetygia.Text));
            }
            catch
            {
            }
        }

        /// <summary>
        /// Lay Thong tin cua khach hang .
        /// </summary>
        /// <param name="maKhachHang"></param>
        /// <returns></returns>
        private Entities.KhachHang GetThongTinKhachHang(string maKhachHang)
        {
            Entities.KhachHang khachHang = new Entities.KhachHang();
            try
            {

                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                khachHang = new Entities.KhachHang("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.KhachHang[] khArr = new Entities.KhachHang[1];
                clientstrem = cl.SerializeObj(this.client1, "KhachHang", khachHang);
                // đổ mảng đối tượng vào datagripview       
                khArr = (Entities.KhachHang[])cl.DeserializeHepper1(clientstrem, khArr);
                foreach (Entities.KhachHang item in khArr)
                {
                    if (item.MaKH.Equals(maKhachHang))
                    {
                        khachHang = item;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                khachHang = null;
            }
            return khachHang;
        }

        private void tsslin_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Entities.KhachHang kh = GetThongTinKhachHang(txtMakhachhang.Text);
            try
            {
                string khachtra = "0";
                if (txtkhachtra.Text == "")
                    khachtra = "0";
                else
                    khachtra = txtkhachtra.Text;
                frmBaoCaorpt bcrpt = new frmBaoCaorpt("HDBanBuon", txtSochungtu.Text, Double.Parse(txtTongchietkhau.Text), khachtra, txtdutra.Text, txtTongtien.Text, txtGTGT.Text, lbnhanvien.Text, "", makNgaychungtu.Text, txtgiatrithe.Text, "0", "", txtChietkhau.Text, kh.DiaChi, txtnguoinhanhang.Text, txtDiengiai.Text);
                bcrpt.ShowDialog();
            }
            catch
            {
            }
            finally
            {
                this.Enabled = true;
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
                'đ','Đ'};
            foreach (char c in a)
            {
                if (c.Equals(ch))
                    return true;
            }
            return false;
        }
        public void XuLyDTGV()
        {
            if (i < 0)
                return;
            try
            {

                if (dtgvsanpham.RowCount > 1)
                {
                    mahanghoa = toolStrip_txtTracuu.Text = dtgvsanpham[1, i].Value.ToString().ToUpper();
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
                    if (txtPhantramchietkhau.Text == "")
                        phantramchietkhau = "0";
                    else
                        phantramchietkhau = txtPhantramchietkhau.Text;
                    TinhToan();
                    txtChietkhau.Text = new Common.Utilities().FormatMoney(((Convert.ToDouble(phantramchietkhau) / 100) * Convert.ToDouble(txtTienhang.Text)));
                    txtTongchietkhau.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(TinhCK(dtgvsanpham)));
                    txtTongchietkhau.Text = (Convert.ToDouble(txtChietkhau.Text) + Convert.ToDouble(txtTongchietkhau.Text)).ToString();
                    txtTongtien.Text = txtkhachtra.Text = txtThanhtoanngay.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(tongtienthanhtoan) - Convert.ToDouble(txtTongchietkhau.Text) - Convert.ToDouble(txtgiatrithe.Text));
                    txtConphaitra.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(tongtienthanhtoan) - Convert.ToDouble(txtThanhtoanngay.Text) - Convert.ToDouble(txtTongchietkhau.Text));
                    txtdutra.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(txtkhachtra.Text) - Convert.ToDouble(tongtienthanhtoan) + Convert.ToDouble(txtTongchietkhau.Text));
                }
                else
                {
                    mahanghoa = toolStrip_txtTracuu.Text = dtgvsanpham[1, i].Value.ToString().ToUpper();
                    tssltenhang.Text = dtgvsanpham[2, i].Value.ToString();
                    tsslgia.Text = new Common.Utilities().FormatMoney(double.Parse(dtgvsanpham[3, i].Value.ToString()));
                    tsslsoluong.Text = dtgvsanpham[4, i].Value.ToString();
                    tsslchietkhau.Text = dtgvsanpham[5, i].Value.ToString();
                    tsslgtgt.Text = dtgvsanpham[6, i].Value.ToString();
                    dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                    txtkhachtra.Text = txtTienhang.Text = txtGTGT.Text = txtTongtien.Text = txtTongchietkhau.Text = txtChietkhau.Text = txtdutra.Text = txtConphaitra.Text = txtThanhtoanngay.Text = "0";
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
                try
                {
                    tsslsoluong.Focus();
                    fix();
                    txtTienhang.Text = TinhTienHang(dtgvsanpham);
                }
                catch
                {
                }
            }
        }
        private void dtgvsanpham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            XuLyDTGV();
        }

        private void txtThanhtoanngay_Click(object sender, EventArgs e)
        {
            try
            {
                txtThanhtoanngay.Text = String.Format("{0:0}", Convert.ToDouble(txtThanhtoanngay.Text));
            }
            catch
            {
            }
        }

        private void txtkhachtra_Click(object sender, EventArgs e)
        {
            try
            {
                string khachtra = "0";
                if (txtkhachtra.Text == "")
                    khachtra = "0";
                else
                    khachtra = txtkhachtra.Text;
                txtkhachtra.Text = String.Format("{0:0}", Convert.ToDouble(khachtra));
            }
            catch
            {
            }
        }

        private void dtgvsanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void txtnguoinhanhang_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    cbbHinhthucthanhtoan.Focus();
                }
                KeyUp_Chung(sender, e);
            }
            catch
            {
            }
        }

        private void cbbHinhthucthanhtoan_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    makHanthanhtoan.Focus();
                    makHanthanhtoan.SelectAll();
                }
                KeyUp_Chung(sender, e);
            }
            catch
            {
            }
        }

        private void makHanthanhtoan_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnTimdondat.Focus();
                }
                KeyUp_Chung(sender, e);
            }
            catch
            {
            }
        }

        private void cbbKhoban_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDiengiai.Focus();
                }
                KeyUp_Chung(sender, e);
            }
            catch
            {
            }
        }

        private void txtDiengiai_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    toolStrip_txtTracuu.Focus();
                }
                KeyUp_Chung(sender, e);
            }
            catch
            {
            }
        }
        public void KeyUp_Chung(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F4)
                {
                    XuLyHH();
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
                if (e.KeyCode == Keys.F8)
                {
                    txtthegiamgia.Focus();
                }
            }
            catch
            {
            }
        }
        private void dtgvsanpham_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    i = dtgvsanpham.SelectedRows[0].Index;
                    XuLyDTGV();
                }
                KeyUp_Chung(sender, e);
            }
            catch
            {
            }
        }

        private void txtkhachtra_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tsslthem_Click(sender, e);
                }
                KeyUp_Chung(sender, e);
            }
            catch
            {
            }
        }

        private void txtPhantramchietkhau_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtkhachtra.Focus();
                }
                KeyUp_Chung(sender, e);
            }
            catch
            {
            }
        }

        private void txtthegiamgia_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtkhachtra.Focus();
                }
                KeyUp_Chung(sender, e);
            }
            catch
            {
            }
        }

        private void cbbKhoban_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                fix();
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

        private void tssExcel_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void tssExcel_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void tssWord_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void tssWord_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void tssPDF_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void tssPDF_MouseMove(object sender, MouseEventArgs e)
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
                        txtDondatbanhang.Text = "";
                        dtgvsanpham.DataSource = new Entities.HangHoaHienThi[0];
                        toolStrip_Insert.Enabled = true;
                        dtgvsanpham.Enabled = true;
                        txtNohienthoi.Text = frmTimKH.drvr.Cells["DuNo"].Value.ToString();
                        frmTimKH.drvr = null;
                        txtnguoinhanhang.Focus();
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
        }

        private void txtDondatbanhang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
            {
                try
                {
                    if (txtMakhachhang.Text.Length != 0)
                    {
                        frmTimDonDatHang fr = new frmTimDonDatHang(txtMakhachhang.Text);
                        fr.ShowDialog();
                        if (frmTimDonDatHang.drvr != null)
                        {
                            string maDonDatHang = txtDondatbanhang.Text = frmTimDonDatHang.drvr.Cells["MaDonDatHang"].Value.ToString();
                            frmTimDonDatHang.drvr = null;
                            toolStrip_Insert.Enabled = false;
                            dtgvsanpham.Enabled = false;
                            SelectData1(maDonDatHang);
                            cbbHinhthucthanhtoan.Focus();
                            if (txtPhantramchietkhau.Text == "")
                                phantramchietkhau = "0";
                            else
                                phantramchietkhau = txtPhantramchietkhau.Text;
                            TinhToan();
                            txtChietkhau.Text = new Common.Utilities().FormatMoney(((Convert.ToDouble(phantramchietkhau) / 100) * Convert.ToDouble(txtTienhang.Text)));
                            txtTongchietkhau.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(TinhCK(dtgvsanpham)));
                            txtTongchietkhau.Text = (Convert.ToDouble(txtChietkhau.Text) + Convert.ToDouble(txtTongchietkhau.Text)).ToString();
                            txtTongtien.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(tongtienthanhtoan) - Convert.ToDouble(txtTongchietkhau.Text) - Convert.ToDouble(txtgiatrithe.Text));
                            txtConphaitra.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(tongtienthanhtoan) - Convert.ToDouble(txtThanhtoanngay.Text) - Convert.ToDouble(txtTongchietkhau.Text));
                            txtdutra.Text = new Common.Utilities().FormatMoney(Convert.ToDouble(txtkhachtra.Text) - Convert.ToDouble(tongtienthanhtoan) + Convert.ToDouble(txtTongchietkhau.Text));

                        }
                    }
                    else
                        MessageBox.Show("Bạn hãy nhập Mã khách hàng");
                }
                catch
                {
                }
            }
        }

        private void tssExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.KhachHang kh = GetThongTinKhachHang(txtMakhachhang.Text);
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "Excel |*.xls";
                saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt bcrpt = new frmBaoCaorpt("HDBanBuon", txtSochungtu.Text, Double.Parse(txtTongchietkhau.Text), txtkhachtra.Text, txtdutra.Text, txtTongtien.Text, txtGTGT.Text, lbnhanvien.Text, "Excel", makNgaychungtu.Text, txtgiatrithe.Text, "0", saveFileDialog1.FileName, txtChietkhau.Text, kh.DiaChi, txtnguoinhanhang.Text, txtDiengiai.Text);
                }
            }
            catch
            {
            }
        }

        private void tssWord_Click(object sender, EventArgs e)
        {
            try
            {
                Entities.KhachHang kh = GetThongTinKhachHang(txtMakhachhang.Text);
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "Word |*.doc";
                saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt bcrpt = new frmBaoCaorpt("HDBanBuon", txtSochungtu.Text, Double.Parse(txtTongchietkhau.Text), txtkhachtra.Text, txtdutra.Text, txtTongtien.Text, txtGTGT.Text, lbnhanvien.Text, "Word", makNgaychungtu.Text, txtgiatrithe.Text, "0", saveFileDialog1.FileName, txtChietkhau.Text, kh.DiaChi, txtnguoinhanhang.Text, txtDiengiai.Text);
                }
            }
            catch
            {
            }
        }

        private void tssPDF_Click(object sender, EventArgs e)
        {
            Entities.KhachHang kh = GetThongTinKhachHang(txtMakhachhang.Text);
            if (i < 0)
                return;
            saveFileDialog1.Filter = "PDF |*.pdf";
            saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                frmBaoCaorpt bcrpt = new frmBaoCaorpt("HDBanBuon", txtSochungtu.Text, Double.Parse(txtTongchietkhau.Text), txtkhachtra.Text, txtdutra.Text, txtTongtien.Text, txtGTGT.Text, lbnhanvien.Text, "PDF", makNgaychungtu.Text, txtgiatrithe.Text, "0", saveFileDialog1.FileName, txtChietkhau.Text, kh.DiaChi, txtnguoinhanhang.Text, txtDiengiai.Text);
            }
        }

        private void txtMakhachhang_TextChanged(object sender, EventArgs e)
        {
            SelectMaCapNhatKH();
        }
    }
}
