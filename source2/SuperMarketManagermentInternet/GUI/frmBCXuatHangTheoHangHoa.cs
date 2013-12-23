using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Entities;

namespace GUI
{
    public partial class frmBCXuatHangTheoHangHoa : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        BCXuatHangTheoMatHang[] ctBCXH_Search;
        BCXuatHangTheoMatHang[] ctBCXH_Search_In;
        DateTime datesv = new DateTime(1753,1,1);
        int nam = 0;
        int thang = 0;

        public frmBCXuatHangTheoHangHoa()
        {
            InitializeComponent();
            try
            {
                datesv = DateServer.Date();
                for (int i = 0; i < cbbthang.Items.Count; i++)
                {
                    if (cbbthang.Items[i].ToString() == datesv.Month.ToString())
                    {
                        cbbthang.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cbbnam.Items.Count; i++)
                {
                    if (cbbnam.Items[i].ToString() == datesv.Year.ToString())
                    {
                        cbbnam.SelectedIndex = i;
                        break;
                    }
                }
                nam = datesv.Year;
                thang = datesv.Month;
                //cbbthang.Text = thang.ToString();
                //cbbnam.Text = nam.ToString();

                LayNgay();

                //Xuất hủy
                PhieuXuatHuy();
                ChiTietXuatHuy();
                //HĐ bán hàng
                HDBanHang1();
                ChiTietHDBanHang();
                //Trả lại NCC
                TraLaiNCC();
                ChiTietTraLaiNCC();

                HangHoa1();
                GoiHang();
                ChiTietGoiHang();

                TongTienNhanVien();

                LayChiTiet_HangHoaXuat_TheoNhomHang();

                    ///////////////////////////////MRK FIX
                    List<Entities.BCXuatHangTheoMatHang> tem0 = new List<BCXuatHangTheoMatHang>();
                    double tong0 = 0;
                    foreach (Entities.BCXuatHangTheoMatHang item in temp)
                    {
                        tong0 += item.TongSoLuongXuat;
                        tem0.Add(item);
                    }
                    Entities.BCXuatHangTheoMatHang tem1 = new BCXuatHangTheoMatHang();
                    tem1.TenHangHoa = "Tổng: ";
                    tem1.TongSoLuongXuat = (int)tong0;
                    tem0.Add(tem1);
                    //////////////////////////////////////
                    //dtgvhienthi.DataSource = temp;
                    dtgvhienthi.DataSource = tem0.ToArray();

                    FixDatagridview();
                    ctBCXH_Search = temp;
                    ctBCXH_Search_In = temp;
                    if (temp.Length > 0)
                    {
                        tsslchitiet.Enabled = true;
                        tsslPdf.Enabled = true;
                        tsslExcel.Enabled = true;
                        tsslWord.Enabled = true;
                    }
                    else
                    {
                        tsslchitiet.Enabled = false;
                        tsslPdf.Enabled = false;
                        tsslExcel.Enabled = false;
                        tsslWord.Enabled = false;
                    }
            }
            catch { }
        }

        private void tsslthoat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void pntop_DoubleClick(object sender, EventArgs e)
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

        public bool KiemTra()
        {
            if (cbbthang.Text == "")
            {
                MessageBox.Show("Bạn Chưa Nhập Tháng", "Hệ thống cánh bảo");
                cbbthang.Focus();
                return false;
            }
            if (cbbnam.Text == "")
            {
                MessageBox.Show("Bạn Chưa Nhập Năm", "Hệ thống cánh bảo");
                cbbnam.Focus();
                return false;
            }
            return true;
        }


        #region Lấy Chi Tiết Hàng Hóa trong 1 Nhóm Hàng
        Entities.BCXuatHangTheoMatHang[] temp;
        public void LayChiTiet_HangHoaXuat_TheoNhomHang()
        {
            try
            {
                int sl = 0;

                temp = new Entities.BCXuatHangTheoMatHang[hienthibaocao.Length];
                for (int i = 0; i < hienthibaocao.Length; i++)
                {
                    if (hienthibaocao[i].TongSoLuongXuat != 0)
                    {
                        temp[sl] = hienthibaocao[i];
                        sl++;
                    }
                }
                Entities.BCXuatHangTheoMatHang[] baocao = new Entities.BCXuatHangTheoMatHang[sl];
                for (int i = 0; i < sl; i++)
                {
                    baocao[i] = temp[i];
                }

            }
            catch
            {
            }
        }
        #endregion

        private bool GoiHangOrHangHoa(string ma)
        {// Gói hàng: true  | Hàng hóa: false
            bool kq = false;
            foreach (Entities.GoiHang item in this.goihang)
            {
                if (item.MaGoiHang.Equals(ma))
                {
                    kq = true;
                    break;
                }
            }
            return kq;
        }

        Entities.GoiHang[] goihang;
        public void GoiHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("GH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                goihang = (Entities.GoiHang[])cl.DeserializeHepper1(clientstrem, goihang);
                if (goihang == null)
                {
                    goihang = new Entities.GoiHang[0];
                    return;
                }
            }
            catch
            {

            }
        }
        Entities.ChiTietGoiHang[] chitietgoihang;
        public void ChiTietGoiHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTGH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                chitietgoihang = (Entities.ChiTietGoiHang[])cl.DeserializeHepper1(clientstrem, chitietgoihang);
                if (chitietgoihang == null)
                {
                    chitietgoihang = new Entities.ChiTietGoiHang[0];
                    return;
                }
            }
            catch
            {

            }
        }

        Entities.HoaDonNhap[] hoadonnhap;
        public void HoaDonNhap()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("HDN");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                hoadonnhap = (Entities.HoaDonNhap[])cl.DeserializeHepper1(clientstrem, hoadonnhap);
                if (hoadonnhap == null)
                {
                    hoadonnhap = new Entities.HoaDonNhap[0];
                    return;
                }
            }
            catch
            {
            }
        }
        Entities.ChiTietHoaDonNhap[] chitiethoadonnhap;
        public void ChiTietHoaDonNhap()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTHDN");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                chitiethoadonnhap = (Entities.ChiTietHoaDonNhap[])cl.DeserializeHepper1(clientstrem, chitiethoadonnhap);
                if (chitiethoadonnhap == null)
                {
                    chitiethoadonnhap = new Entities.ChiTietHoaDonNhap[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.KhachHangTraLai[] khachhangtralai;
        public void KhachHangTraLai()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("KHTL");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                khachhangtralai = (Entities.KhachHangTraLai[])cl.DeserializeHepper1(clientstrem, khachhangtralai);
                if (khachhangtralai == null)
                {
                    khachhangtralai = new Entities.KhachHangTraLai[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.ChiTietKhachHangTraLai[] chitietkhachhangtralai;
        public void ChiTietKhachHangTraLai()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTKHTL");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                chitietkhachhangtralai = (Entities.ChiTietKhachHangTraLai[])cl.DeserializeHepper1(clientstrem, chitietkhachhangtralai);
                if (chitietkhachhangtralai == null)
                {
                    chitietkhachhangtralai = new Entities.ChiTietKhachHangTraLai[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.PhieuDieuChuyenKhoNoiBo[] phieudieuchuyenkhonoibo;
        public void PhieuDieuChuyenKhoNoiBo()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("PDCKNB");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                phieudieuchuyenkhonoibo = (Entities.PhieuDieuChuyenKhoNoiBo[])cl.DeserializeHepper1(clientstrem, phieudieuchuyenkhonoibo);
                if (phieudieuchuyenkhonoibo == null)
                {
                    phieudieuchuyenkhonoibo = new Entities.PhieuDieuChuyenKhoNoiBo[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.ChiTietPhieuDieuChuyenKho[] chitietphieudieuchuyenkho;
        public void ChiTietPhieuDieuChuyenKho()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTPDCKNB");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                chitietphieudieuchuyenkho = (Entities.ChiTietPhieuDieuChuyenKho[])cl.DeserializeHepper1(clientstrem, chitietphieudieuchuyenkho);
                if (chitietphieudieuchuyenkho == null)
                {
                    chitietphieudieuchuyenkho = new Entities.ChiTietPhieuDieuChuyenKho[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.TraLaiNCC[] tralaincc;
        public void TraLaiNCC()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("TLNCC");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                tralaincc = (Entities.TraLaiNCC[])cl.DeserializeHepper1(clientstrem, tralaincc);
                if (tralaincc == null)
                {
                    tralaincc = new Entities.TraLaiNCC[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.ChiTietTraLaiNhaCungCap[] chitiettralaincc;
        public void ChiTietTraLaiNCC()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTTLNCC");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                chitiettralaincc = (Entities.ChiTietTraLaiNhaCungCap[])cl.DeserializeHepper1(clientstrem, chitiettralaincc);
                if (chitiettralaincc == null)
                {
                    chitiettralaincc = new Entities.ChiTietTraLaiNhaCungCap[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.ChiTietXuatHuy[] chitietxuathuy;
        public void ChiTietXuatHuy()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTPXH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                chitietxuathuy = (Entities.ChiTietXuatHuy[])cl.DeserializeHepper1(clientstrem, chitietxuathuy);
                if (chitietxuathuy == null)
                {
                    chitietxuathuy = new Entities.ChiTietXuatHuy[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.PhieuXuatHuy[] phieuxuathuy;
        public void PhieuXuatHuy()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("PXH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                phieuxuathuy = (Entities.PhieuXuatHuy[])cl.DeserializeHepper1(clientstrem, phieuxuathuy);
                if (phieuxuathuy == null)
                {
                    phieuxuathuy = new Entities.PhieuXuatHuy[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.SoDuKho[] sodukho;
        public void SoDuKho()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.SoDuKho ctxh = new Entities.SoDuKho("Select");
                clientstrem = cl.SerializeObj(this.client1, "SoDuKho", ctxh);
                sodukho = (Entities.SoDuKho[])cl.DeserializeHepper1(clientstrem, sodukho);
                if (sodukho == null)
                {
                    sodukho = new Entities.SoDuKho[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.HangHoa[] hanghoa;
        public void HangHoa1()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("HH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                hanghoa = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, hanghoa);
                if (hanghoa == null)
                {
                    hanghoa = new Entities.HangHoa[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.KhoHang[] khohang;
        public void KhoHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("KH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                khohang = (Entities.KhoHang[])cl.DeserializeHepper1(clientstrem, khohang);
                if (khohang == null)
                {
                    khohang = new Entities.KhoHang[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.ChiTietKhoHangTheoHoaHonNhap[] chitietkhohang;
        public void ChiTietKhoHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTKH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                chitietkhohang = (Entities.ChiTietKhoHangTheoHoaHonNhap[])cl.DeserializeHepper1(clientstrem, chitietkhohang);
                if (chitietkhohang == null)
                {
                    chitietkhohang = new Entities.ChiTietKhoHangTheoHoaHonNhap[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.HDBanHang[] hdbanhang;
        public void HDBanHang1()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("HDBH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                hdbanhang = (Entities.HDBanHang[])cl.DeserializeHepper1(clientstrem, hdbanhang);
                if (hdbanhang == null)
                {
                    hdbanhang = new Entities.HDBanHang[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.ChiTietHDBanHang[] chitiethdbanhang;
        public void ChiTietHDBanHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTHDBH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                chitiethdbanhang = (Entities.ChiTietHDBanHang[])cl.DeserializeHepper1(clientstrem, chitiethdbanhang);
                if (chitiethdbanhang == null)
                {
                    chitiethdbanhang = new Entities.ChiTietHDBanHang[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.BCXuatNhapTonTheoKho[] hienthi;
        Entities.BCXuatHangTheoMatHang[] hienthibaocao;

        public void TongTienNhanVien()
        {
            try
            {
                nam = int.Parse(cbbnam.Text);
                thang = int.Parse(cbbthang.Text);
                List<Entities.BCXuatHangTheoMatHang> l = new List<Entities.BCXuatHangTheoMatHang>();

                foreach (Entities.HangHoa hh in this.hanghoa)
                {
                    int tongxuat = 0;

                    //Xuất Hủy
                    foreach (Entities.PhieuXuatHuy item in this.phieuxuathuy)
                    {
                        int _nam = item.NgayLap.Year;
                        int _thang = item.NgayLap.Month;
                        if ((_nam == this.nam) && (_thang == this.thang) && (item.TrangThai == true))
                        {
                            foreach (Entities.ChiTietXuatHuy item1 in this.chitietxuathuy)
                            {
                                if (item1.MaPhieuXuatHuy.Equals(item.MaPhieuXuatHuy) && (item1.MaHangHoa.Equals(hh.MaHangHoa)))
                                {
                                    tongxuat += item1.SoLuong;
                                }
                            }
                        }
                    }
                    //Hóa đơn bán hàng
                    foreach (Entities.HDBanHang item in this.hdbanhang)
                    {
                        int _nam = item.NgayBan.Year;
                        int _thang = item.NgayBan.Month;
                        if ((_nam == this.nam) && (_thang == this.thang))
                        {
                            foreach (Entities.ChiTietHDBanHang item1 in this.chitiethdbanhang)
                            {
                                if (item1.MaHDBanHang.Equals(item.MaHDBanHang))
                                {
                                    if (GoiHangOrHangHoa(item1.MaHangHoa))
                                    {//là gói hàng
                                        foreach (Entities.GoiHang gh in this.goihang)
                                        {
                                            foreach (Entities.ChiTietGoiHang ctgh in this.chitietgoihang)
                                            {
                                                if (gh.MaGoiHang.Equals(ctgh.MaGoiHang) && ctgh.MaGoiHang.Equals(item1.MaHangHoa))
                                                {
                                                    if (ctgh.MaHangHoa.Equals(hh.MaHangHoa))
                                                    {
                                                        tongxuat += item1.SoLuong * ctgh.SoLuong;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {//là hàng hóa
                                        if (item1.MaHangHoa.Equals(hh.MaHangHoa))
                                        {
                                            tongxuat += item1.SoLuong;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //Trả lại nhà cung cấp
                    foreach (Entities.TraLaiNCC item in this.tralaincc)
                    {
                        int _nam = item.Ngaytra.Year;
                        int _thang = item.Ngaytra.Month;
                        if ((_nam == this.nam) && (_thang == this.thang))
                        {
                            foreach (Entities.ChiTietTraLaiNhaCungCap item1 in this.chitiettralaincc)
                            {
                                if (item1.MaHDTraLaiNCC.Equals(item.MaHDTraLaiNCC) && item1.MaHangHoa.Equals(hh.MaHangHoa))
                                {
                                    tongxuat += item1.SoLuong;
                                }
                            }
                        }
                    }

                    if (tongxuat == 0)
                    {//Nếu hàng hóa này không có sự xuất đi thì không hiển thị
                        continue;
                    }
                    else
                    {
                        Entities.BCXuatHangTheoMatHang bientam = new BCXuatHangTheoMatHang();
                        bientam.MaHangHoa = hh.MaHangHoa;
                        bientam.TenHangHoa = hh.TenHangHoa;
                        bientam.TongSoLuongXuat = tongxuat;
                        l.Add(bientam);
                    }
                }

                hienthibaocao = new Entities.BCXuatHangTheoMatHang[l.Count];

                for (int i = 0; i < l.Count; i++)
                {
                    hienthibaocao[i] = l[i];
                }

                ///////////////////////////////MRK FIX
                List<Entities.BCXuatHangTheoMatHang> tem0 = new List<Entities.BCXuatHangTheoMatHang>();
                double tong0 = 0;
                foreach (Entities.BCXuatHangTheoMatHang item in hienthibaocao)
                {
                    tong0 += item.TongSoLuongXuat;
                    tem0.Add(item);
                }
                Entities.BCXuatHangTheoMatHang tem1 = new Entities.BCXuatHangTheoMatHang();
                tem1.TenHangHoa = "Tổng: ";
                tem1.TongSoLuongXuat = (int)tong0;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = hienthibaocao;
                dtgvhienthi.DataSource = tem0.ToArray();
            }
            catch { }

            //try
            //{
                
            //    double sddk, sddkhh, sdckhh, sdck, tongxuat, tongnhap;
            //    double nhapmua, nhaptralai, nhapkhac;
            //    double xuatban, xuattralai, xuatkhac;
             
            //    nhapmua = nhaptralai = nhapkhac = xuatban = xuattralai = xuatkhac = 0;
            //    sdckhh = sddkhh = sdck = sddk = 0;
            //    int sotang = 0;
            //    hienthi = new Entities.BCXuatNhapTonTheoKho[khohang.Length];

            //    for (int i = 0; i < khohang.Length; i++)
            //    {
            //        for (int j = 0; j < chitietkhohang.Length; j++)
            //        {
            //            if (chitietkhohang[j].Makho == khohang[i].MaKho)
            //            {
            //                for (int k = 0; k < hanghoa.Length; k++)
            //                {
            //                    if (hanghoa[k].MaHangHoa == chitietkhohang[j].Mahanghoa)
            //                    {
            //                        sotang++;   //Đếm số hàng hóa trong kho
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    int sohanghoatrongkho = sotang;
            //    hienthibaocao = new Entities.BCXuatHangTheoMatHang[sotang];
            //    sotang = 0;
            //    for (int i = 0; i < khohang.Length; i++)
            //    {
            //        tongxuat = tongnhap = sddk = 0;
            //        for (int j = 0; j < chitietkhohang.Length; j++)
            //        {
            //            if (chitietkhohang[j].Makho == khohang[i].MaKho)
            //            {
            //                for (int k = 0; k < hanghoa.Length; k++)
            //                {
            //                    if (hanghoa[k].MaHangHoa == chitietkhohang[j].Mahanghoa)
            //                    {
            //                        sdckhh = sddkhh = sdck = 0;

                                 
            //                        // xuất hàng - phiếu xuất hủy
            //                        nhapmua = nhaptralai = nhapkhac = xuatban = xuattralai = xuatkhac = 0;
            //                        for (int l = 0; l < phieuxuathuy.Length; l++)
            //                        {
            //                            for (int o = 0; o < chitietxuathuy.Length; o++)
            //                            {
            //                                int namphieu = phieuxuathuy[l].NgayLap.Year;
            //                                int thangphieu = phieuxuathuy[l].NgayLap.Month;
            //                                if (thang == thangphieu && phieuxuathuy[l].TrangThai == true && phieuxuathuy[l].MaKho == khohang[i].MaKho)
            //                                {
            //                                    if (chitietxuathuy[o].MaHangHoa == hanghoa[k].MaHangHoa)
            //                                    {
            //                                        xuatban += chitietxuathuy[o].SoLuong;
            //                                    }
            //                                }
            //                            }
            //                        }


            //                        // xuất hàng - hóa đơn bán hàng
            //                        for (int l = 0; l < hdbanhang.Length; l++)
            //                        {
            //                            for (int o = 0; o < chitiethdbanhang.Length; o++)
            //                            {
            //                                int namphieu = hdbanhang[l].NgayBan.Year;
            //                                int thangphieu = hdbanhang[l].NgayBan.Month;
            //                                if (chitiethdbanhang[o].MaHDBanHang == hdbanhang[l].MaHDBanHang &&
            //                                    nam == namphieu && thang == thangphieu &&
            //                                    hdbanhang[l].MaKho == khohang[i].MaKho)
            //                                {
            //                                    ////////////////////////////////////////////////MRK FIX
            //                                    //kiểm tra nó là hàng hóa hay mã hàng
            //                                    if (this.GoiHangOrHangHoa(chitiethdbanhang[o].MaHangHoa))
            //                                    { //là gói hàng
            //                                        for (int for6 = 0; for6 < goihang.Length; for6++)
            //                                        {
            //                                            for (int for7 = 0; for7 < chitietgoihang.Length; for7++)
            //                                            {
            //                                                if (goihang[for6].MaGoiHang.Equals(chitietgoihang[for7].MaGoiHang) && chitietgoihang[for7].MaGoiHang.Equals(chitiethdbanhang[o].MaHangHoa))
            //                                                {
            //                                                    //-------
            //                                                    if (chitietgoihang[for7].MaHangHoa == hanghoa[k].MaHangHoa)
            //                                                    {
            //                                                        xuatban += (chitietgoihang[for7].SoLuong * chitiethdbanhang[o].SoLuong);
                                                               
            //                                                    }
            //                                                }
            //                                            }
            //                                        }
            //                                    }
            //                                    else
            //                                    { //là hàng hóa
            //                                        if ((chitiethdbanhang[o].MaHangHoa == hanghoa[k].MaHangHoa) && (hdbanhang[l].MaKho == khohang[i].MaKho))
            //                                        {
            //                                             xuatban += chitiethdbanhang[o].SoLuong;
            //                                        }
            //                                    }
            //                                    //End kiểm tra
            //                                    ////////////////////////////////////////////////MRK FIX
            //                                }
            //                            }
            //                        }

            //                        // xuất hàng - trả lại nhà cung cấp
            //                        for (int l = 0; l < tralaincc.Length; l++)
            //                        {
            //                            for (int o = 0; o < chitiettralaincc.Length; o++)
            //                            {
            //                                int namphieu = tralaincc[l].Ngaytra.Year;
            //                                int thangphieu = tralaincc[l].Ngaytra.Month;
            //                                if (thang == thangphieu && tralaincc[l].MaKho == khohang[i].MaKho)
            //                                {
            //                                    if (chitiettralaincc[o].MaHangHoa == hanghoa[k].MaHangHoa)
            //                                    {
            //                                        xuatban += chitiettralaincc[o].SoLuong;
            //                                    }
            //                                }
            //                            }
            //                        }
            //                        // xuất hàng - phiếu điều chuyển kho nội bộ
            //                        for (int l = 0; l < phieudieuchuyenkhonoibo.Length; l++)
            //                        {
            //                            if (phieudieuchuyenkhonoibo[l].TuKho == khohang[i].MaKho)
            //                            {
            //                                for (int o = 0; o < chitietphieudieuchuyenkho.Length; o++)
            //                                {
            //                                    int namphieu = phieudieuchuyenkhonoibo[l].NgayDieuChuyen.Year;
            //                                    int thangphieu = phieudieuchuyenkhonoibo[l].NgayDieuChuyen.Month;
            //                                    if (nam == namphieu && thang == thangphieu && phieudieuchuyenkhonoibo[l].TuKho == khohang[i].MaKho)
            //                                    {
            //                                        ////////////////////////////////////////////////MRK FIX
            //                                        //kiểm tra nó là hàng hóa hay mã hàng
            //                                        if (this.GoiHangOrHangHoa(chitietphieudieuchuyenkho[o].MaHangHoa))
            //                                        { //là gói hàng
            //                                            for (int for6 = 0; for6 < goihang.Length; for6++)
            //                                            {
            //                                                for (int for7 = 0; for7 < chitietgoihang.Length; for7++)
            //                                                {
            //                                                    if (goihang[for6].MaGoiHang.Equals(chitietgoihang[for7].MaGoiHang) && chitietgoihang[for7].MaGoiHang.Equals(chitietphieudieuchuyenkho[o].MaHangHoa))
            //                                                    {
            //                                                        //-------
            //                                                        if (chitietgoihang[for7].MaHangHoa == hanghoa[k].MaHangHoa)
            //                                                        {
            //                                                            xuatban += (chitietgoihang[for7].SoLuong * chitietphieudieuchuyenkho[o].SoLuong);
                                                                      
            //                                                        }
            //                                                    }
            //                                                }
            //                                            }
            //                                        }
            //                                        else
            //                                        { //là hàng hóa
            //                                            if (chitietphieudieuchuyenkho[o].MaHangHoa == hanghoa[k].MaHangHoa
            //                                                && phieudieuchuyenkhonoibo[l].TuKho == khohang[i].MaKho)
            //                                            {
            //                                                xuatban += chitietphieudieuchuyenkho[o].SoLuong;
            //                                            }
            //                                        }
            //                                        //End kiểm tra
            //                                        ////////////////////////////////////////////////MRK FIX
            //                                    }
            //                                }
            //                            }
            //                        }
            //                        hienthibaocao[sotang] = new Entities.BCXuatHangTheoMatHang(hanghoa[k].MaHangHoa, hanghoa[k].TenHangHoa,Convert.ToInt32(xuatban));                                 
            //                        sotang++;
            //                    }
            //                }
            //            }
            //        }
            //    }

            //    ///////////////////////////////MRK FIX
            //    List<Entities.BCXuatHangTheoMatHang> tem0 = new List<Entities.BCXuatHangTheoMatHang>();
            //    double tong0 = 0;
            //    foreach (Entities.BCXuatHangTheoMatHang item in hienthibaocao)
            //    {
            //        tong0 += item.TongSoLuongXuat;
            //        tem0.Add(item);
            //    }
            //    Entities.BCXuatHangTheoMatHang tem1 = new BCXuatHangTheoMatHang();
            //    tem1.TenHangHoa = "Tổng: ";
            //    tem1.TongSoLuongXuat = (int)tong0;
            //    tem0.Add(tem1);
            //    //////////////////////////////////////
            //    //dtgvhienthi.DataSource = hienthibaocao;
            //    dtgvhienthi.DataSource = tem0.ToArray();
              
            //}
            //catch
            //{
            //}
        }


        
        DateTime BatDau, KetThuc;

        public void LayNgay()
        {
            BatDau = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), 1);
            KetThuc = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), DateTime.DaysInMonth(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text)));
            //BatDau = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), 1);
            //if (cbbthang.Text == "12")
            //{
            //    KetThuc = new DateTime(Convert.ToInt32(cbbnam.Text) + 1, 1, 1);
            //}
            //else
            //{
            //    KetThuc = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text) + 1, 1);
            //}
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                LayNgay();

                //Xuất hủy
                PhieuXuatHuy();
                ChiTietXuatHuy();
                //HĐ bán hàng
                HDBanHang1();
                ChiTietHDBanHang();
                //Trả lại NCC
                TraLaiNCC();
                ChiTietTraLaiNCC();

                HangHoa1();
                GoiHang();
                ChiTietGoiHang();

                TongTienNhanVien();

                LayChiTiet_HangHoaXuat_TheoNhomHang();

                ///////////////////////////////MRK FIX
                List<Entities.BCXuatHangTheoMatHang> tem0 = new List<BCXuatHangTheoMatHang>();
                double tong0 = 0;
                foreach (Entities.BCXuatHangTheoMatHang item in temp)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    tong0 += item.TongSoLuongXuat;
                    tem0.Add(item);
                }
                Entities.BCXuatHangTheoMatHang tem1 = new BCXuatHangTheoMatHang();
                tem1.TenHangHoa = "Tổng: ";
                tem1.TongSoLuongXuat = (int)tong0;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = temp;
                dtgvhienthi.DataSource = tem0.ToArray();

                FixDatagridview();
                ctBCXH_Search = temp;
                ctBCXH_Search_In = temp;
                if (temp.Length > 0)
                {
                    tsslchitiet.Enabled = true;
                    tsslPdf.Enabled = true;
                    tsslExcel.Enabled = true;
                    tsslWord.Enabled = true;
                }
                else
                {
                    tsslchitiet.Enabled = false;
                    tsslPdf.Enabled = false;
                    tsslExcel.Enabled = false;
                    tsslWord.Enabled = false;
                }
            }
        }

        public void FixDatagridview()
        {
            dtgvhienthi.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
            dtgvhienthi.Columns["TenHangHoa"].HeaderText = "Tên Hàng Hóa";
            dtgvhienthi.Columns["TongSoLuongXuat"].HeaderText = "Tổng Số Lượng Xuất";
         
            dtgvhienthi.AllowUserToResizeRows = false;
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvhienthi.ReadOnly = true;
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            frmBaoCaorpt frm = new frmBaoCaorpt(temp, BatDau, KetThuc);
            frm.ShowDialog();
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH_Search_In, BatDau, KetThuc,saveFileDialog1.FileName,"PDF");
                
            }
        }

        private void tsslWord_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH_Search_In, BatDau, KetThuc, saveFileDialog1.FileName, "Word");
                
            }
        }

        private void tsslExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                frmBaoCaorpt frm = new frmBaoCaorpt(ctBCXH_Search_In, BatDau, KetThuc, saveFileDialog1.FileName, "Excel");
            }
        }

        private void rdbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTatCa.Checked == true)
            {
                txtTimKiem.Text = "";
                if (ctBCXH_Search.Length > 0)
                {
                    tsslchitiet.Enabled = true;
                    tsslPdf.Enabled = true;
                    tsslExcel.Enabled = true;
                    tsslWord.Enabled = true;
                }
                else
                {
                    tsslchitiet.Enabled = false;
                    tsslPdf.Enabled = false;
                    tsslExcel.Enabled = false;
                    tsslWord.Enabled = false;
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCXuatHangTheoMatHang> tem0 = new List<BCXuatHangTheoMatHang>();
                double tong0 = 0;
                foreach (Entities.BCXuatHangTheoMatHang item in ctBCXH_Search)
                {
                    tong0 += item.TongSoLuongXuat;
                    tem0.Add(item);
                }
                Entities.BCXuatHangTheoMatHang tem1 = new BCXuatHangTheoMatHang();
                tem1.TenHangHoa = "Tổng: ";
                tem1.TongSoLuongXuat = (int)tong0;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = ctBCXH_Search;
                dtgvhienthi.DataSource = tem0.ToArray();

                ctBCXH_Search_In = ctBCXH_Search;
                FixDatagridview();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (rdbTen.Checked == true)
            {

                if (ctBCXH_Search == null)
                {
                    BCXuatHangTheoMatHang[] tkkt = new BCXuatHangTheoMatHang[0];
                    dtgvhienthi.DataSource = tkkt;
                    FixDatagridview();

                    tsslchitiet.Enabled = false;
                    tsslExcel.Enabled = false;
                    tsslPdf.Enabled = false;
                    tsslWord.Enabled = false;
                }
                else
                    if (ctBCXH_Search != null)
                    {
                        if (txtTimKiem.Text.Length == 0)
                        {
                            BCXuatHangTheoMatHang[] tkkt = new BCXuatHangTheoMatHang[0];
                            dtgvhienthi.DataSource = tkkt;
                            FixDatagridview();

                            tsslchitiet.Enabled = false;
                            tsslExcel.Enabled = false;
                            tsslPdf.Enabled = false;
                            tsslWord.Enabled = false;
                        }
                        else
                        {
                            int ctBCXH_Search_count = 0;

                            for (int i = 0; i < ctBCXH_Search.Length; i++)
                            {
                                int index = -1;
                                index = ctBCXH_Search[i].TenHangHoa.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                if (index >= 0)
                                {
                                    ctBCXH_Search_count++;
                                }
                            }
                            BCXuatHangTheoMatHang[] ctBCXH_Search1 = new BCXuatHangTheoMatHang[ctBCXH_Search_count];
                            ctBCXH_Search_count = 0;

                            for (int i = 0; i < ctBCXH_Search.Length; i++)
                            {
                                int index = -1;
                                index = ctBCXH_Search[i].TenHangHoa.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                if (index >= 0)
                                {
                                    ctBCXH_Search1[ctBCXH_Search_count] = ctBCXH_Search[i];
                                    ctBCXH_Search_count++;
                                }
                            }
                            if (ctBCXH_Search_count == 0)
                            {
                                tsslchitiet.Enabled = false;
                                tsslExcel.Enabled = false;
                                tsslPdf.Enabled = false;
                                tsslWord.Enabled = false;
                            }
                            else
                            {
                                tsslchitiet.Enabled = true;
                                tsslExcel.Enabled = true;
                                tsslPdf.Enabled = true;
                                tsslWord.Enabled = true;
                            }
                            ///////////////////////////////MRK FIX
                            List<Entities.BCXuatHangTheoMatHang> tem0 = new List<BCXuatHangTheoMatHang>();
                            double tong0 = 0;
                            foreach (Entities.BCXuatHangTheoMatHang item in ctBCXH_Search1)
                            {
                                tong0 += item.TongSoLuongXuat;
                                tem0.Add(item);
                            }
                            Entities.BCXuatHangTheoMatHang tem1 = new BCXuatHangTheoMatHang();
                            tem1.TenHangHoa = "Tổng: ";
                            tem1.TongSoLuongXuat = (int)tong0;
                            tem0.Add(tem1);
                            //////////////////////////////////////
                            //dtgvhienthi.DataSource = ctBCXH_Search1;
                            dtgvhienthi.DataSource = tem0.ToArray();

                            ctBCXH_Search_In = ctBCXH_Search1;
                            FixDatagridview();
                        }
                    }
            }
            else
                if (rdbMa.Checked == true)
                {
                    if (ctBCXH_Search == null)
                    {
                        BCXuatHangTheoMatHang[] tkkt = new BCXuatHangTheoMatHang[0];
                        dtgvhienthi.DataSource = tkkt;
                        FixDatagridview();

                        tsslchitiet.Enabled = false;
                        tsslExcel.Enabled = false;
                        tsslPdf.Enabled = false;
                        tsslWord.Enabled = false;

                    }
                    else
                        if (ctBCXH_Search != null)
                        {
                            if (txtTimKiem.Text.Length == 0)
                            {
                                BCXuatHangTheoMatHang[] tkkt = new BCXuatHangTheoMatHang[0];
                                dtgvhienthi.DataSource = tkkt;
                                FixDatagridview();

                                tsslchitiet.Enabled = false;
                                tsslExcel.Enabled = false;
                                tsslPdf.Enabled = false;
                                tsslWord.Enabled = false;

                            }
                            else
                            {
                                int ctBCXH_Search_count = 0;

                                for (int i = 0; i < ctBCXH_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = ctBCXH_Search[i].MaHangHoa.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                    if (index >= 0)
                                    {
                                        ctBCXH_Search_count++;
                                    }
                                }
                                BCXuatHangTheoMatHang[] ctBCXH_Search1 = new BCXuatHangTheoMatHang[ctBCXH_Search_count];
                                ctBCXH_Search_count = 0;

                                for (int i = 0; i < ctBCXH_Search.Length; i++)
                                {
                                    int index = -1;
                                    index = ctBCXH_Search[i].MaHangHoa.ToLower().IndexOf(txtTimKiem.Text.Trim().ToLower());
                                    if (index >= 0)
                                    {
                                        ctBCXH_Search1[ctBCXH_Search_count] = ctBCXH_Search[i];
                                        ctBCXH_Search_count++;
                                    }
                                }
                                if (ctBCXH_Search_count == 0)
                                {
                                    tsslchitiet.Enabled = false;
                                    tsslExcel.Enabled = false;
                                    tsslPdf.Enabled = false;
                                    tsslWord.Enabled = false;
                                }
                                else
                                {
                                    tsslchitiet.Enabled = true;
                                    tsslExcel.Enabled = true;
                                    tsslPdf.Enabled = true;
                                    tsslWord.Enabled = true;
                                }
                                ///////////////////////////////MRK FIX
                                List<Entities.BCXuatHangTheoMatHang> tem0 = new List<BCXuatHangTheoMatHang>();
                                double tong0 = 0;
                                foreach (Entities.BCXuatHangTheoMatHang item in ctBCXH_Search1)
                                {
                                    tong0 += item.TongSoLuongXuat;
                                    tem0.Add(item);
                                }
                                Entities.BCXuatHangTheoMatHang tem1 = new BCXuatHangTheoMatHang();
                                tem1.TenHangHoa = "Tổng: ";
                                tem1.TongSoLuongXuat = (int)tong0;
                                tem0.Add(tem1);
                                //////////////////////////////////////
                                //dtgvhienthi.DataSource = ctBCXH_Search1;
                                dtgvhienthi.DataSource = tem0.ToArray();

                                ctBCXH_Search_In = ctBCXH_Search1;
                                FixDatagridview();
                            }
                        }
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
    
    }
}
