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
    public partial class frmBCXuatNhapTonPhieuXuatNhap : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        int nam = 0;
        int thang = 0;
        public frmBCXuatNhapTonPhieuXuatNhap()
        {
            try
            {
                InitializeComponent();
                nam = DateServer.Date().Year;
                thang = DateServer.Date().Month;
                cbbthang.Text = thang.ToString();
                cbbnam.Text = nam.ToString();
                PhieuXuatHuy();
                ChiTietXuatHuy();
                HDBanHang();
                ChiTietHDBanHang();
                HoaDonNhap();
                ChiTietHoaDonNhap();
                TraLaiNCC();
                ChiTietTraLaiNCC();
                KhachHangTraLai();
                ChiTietKhachHangTraLai();
                HangHoa();
                SoDuKho();
                GoiHang();
                ChiTietGoiHang();
                TongTienNhanVien();
            }
            catch
            {
            }

        }

        ////////////////////////////////////MRK FIX
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
        ////////////////////////////////////////////

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
                int soluong = 0;
                Entities.PhieuXuatHuy[] temp = new Entities.PhieuXuatHuy[phieuxuathuy.Length];
                for (int i = 0; i < phieuxuathuy.Length; i++)
                {
                    if (phieuxuathuy[i].TrangThai == true)
                    {
                        temp[soluong] = phieuxuathuy[i];
                        soluong++;
                    }
                }
                phieuxuathuy = new Entities.PhieuXuatHuy[soluong];
                for (int i = 0; i < soluong; i++)
                {
                    phieuxuathuy[i] = temp[i];
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
        Entities.HDBanHang[] hdbanhang;
        public void HDBanHang()
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
        Entities.HangHoa[] hanghoa;
        public void HangHoa()
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
        Entities.BCXuatNhapTonPhieuXuatNhap hienthi;
        List<Entities.BCXuatNhapTonPhieuXuatNhap> tempList = new List<Entities.BCXuatNhapTonPhieuXuatNhap>();
        Entities.BCXuatNhapTonPhieuXuatNhap[] hienthibaocao = new Entities.BCXuatNhapTonPhieuXuatNhap[1];
        public void TongTienNhanVien()
        {
            try
            {
                nam = int.Parse(cbbnam.Text);
                thang = int.Parse(cbbthang.Text);
                double sddk, sddkhh, sdckhh, sdck, tongxuat, tongnhap;
                double nhapmua, nhaptralai, nhapkhac;
                double xuatban, xuattralai, xuatkhac;
                nhapmua = nhaptralai = nhapkhac = xuatban = xuattralai = xuatkhac = 0;
                sdckhh = sddkhh = sdck = sddk = 0;
                int sotang = 0;
                //hienthi = new Entities.BCXuatNhapTonPhieuXuatNhap[chitietxuathuy.Length + chitiethdbanhang.Length + chitiethoadonnhap.Length + chitiettralaincc.Length + chitietkhachhangtralai.Length];
                sotang = 0;
                for (int k = 0; k < hanghoa.Length; k++)
                {////////////////////////// START HÀNG HÓA
                    sdckhh = sddkhh = sdck = sddk = tongxuat = tongnhap = 0;
                    // số dư đầu kỳ - chưa có select
                    for (int l = 0; l < sodukho.Length; l++)
                    {
                        if (sodukho[l].MaHangHoa == hanghoa[k].MaHangHoa)
                        {
                            sddk = sodukho[l].SoDuDauKy;
                            break;
                        }
                    }
                    // xuất hàng - phiếu xuất hủy
                    sdck = sddk = tongxuat = tongnhap = 0;

                    var querypxh = from pxh in phieuxuathuy
                                   where nam.Equals(pxh.NgayLap.Year) && thang.Equals(pxh.NgayLap.Month) && pxh.TrangThai.Equals(true)
                                   select pxh;

                    Entities.PhieuXuatHuy[] phieuxuathuyArr = querypxh.ToArray();

                    // lay chitietphieuxuathuy
                    var queryctpxh = from s1 in phieuxuathuyArr
                                     join s2 in chitietxuathuy
                                     on s1.MaPhieuXuatHuy equals s2.MaPhieuXuatHuy
                                     select s2;

                    Entities.ChiTietXuatHuy[] chitietxuathuyArr = queryctpxh.ToArray();

                    for (int o = 0; o < chitietxuathuyArr.Length; o++)
                    {
                        if (chitietxuathuyArr[o].MaHangHoa == hanghoa[k].MaHangHoa)
                        {
                            tongxuat = xuatkhac = chitietxuathuyArr[o].SoLuong;
                            sdck = sddk + tongnhap - tongxuat;
                            hienthi = new Entities.BCXuatNhapTonPhieuXuatNhap("", chitietxuathuyArr[o].MaPhieuXuatHuy,
                                "Phiếu xuất hủy hàng hóa", hanghoa[k].MaHangHoa, hanghoa[k].TenHangHoa, sddk,
                                tongnhap, tongxuat, sdck);
                            tempList.Add(hienthi);
                        }
                    }
                    // xuất hàng - hóa đơn bán hàng
                    sdck = sddk = tongxuat = tongnhap = 0;

                    var querybanhang = from bh in hdbanhang
                                       where bh.NgayBan.Month.Equals(thang) && bh.NgayBan.Year.Equals(nam)
                                       select bh;

                    Entities.HDBanHang[] hdbanhangArr = querybanhang.ToArray();
                    // lay ct hoa don ban hang
                    var queryctbanhang = from s1 in hdbanhangArr
                                         join s2 in chitiethdbanhang
                                         on s1.MaHDBanHang equals s2.MaHDBanHang
                                         select s2;

                    Entities.ChiTietHDBanHang[] chitiethdbanhangArr = queryctbanhang.ToArray();

                    for (int o = 0; o < chitiethdbanhangArr.Length; o++)
                    {
                        if (chitiethdbanhangArr[o].MaHangHoa == hanghoa[k].MaHangHoa)
                        {
                            tongxuat = chitiethdbanhangArr[o].SoLuong;
                            sdck = sddk + tongnhap - tongxuat;
                            hienthi = new Entities.BCXuatNhapTonPhieuXuatNhap("", chitiethdbanhangArr[o].MaHDBanHang,
                                "Hóa đơn bán hàng", hanghoa[k].MaHangHoa, hanghoa[k].TenHangHoa, sddk,
                                tongnhap, tongxuat, sdck);
                            tempList.Add(hienthi);
                        }
                        ////////////////////////////////////////////////MRK FIX
                        else
                        {
                            foreach (Entities.GoiHang gh in goihang)
                            {
                                foreach (Entities.ChiTietGoiHang ctgh in chitietgoihang)
                                {
                                    if (gh.MaGoiHang.Equals(ctgh.MaGoiHang) && ctgh.MaGoiHang.Equals(chitiethdbanhang[o].MaHangHoa) && ctgh.MaHangHoa.Equals(hanghoa[k].MaHangHoa))
                                    {
                                        tongxuat = chitiethdbanhang[o].SoLuong * ctgh.SoLuong;
                                        sdck = sddk + tongnhap - tongxuat;
                                        hienthi = new Entities.BCXuatNhapTonPhieuXuatNhap("", hdbanhang[o].MaHDBanHang,
                                            "Hóa đơn bán hàng", hanghoa[k].MaHangHoa, hanghoa[k].TenHangHoa, sddk,
                                            tongnhap, tongxuat, sdck);
                                        tempList.Add(hienthi);
                                    }
                                }
                            }
                        }
                        ////////////////////////////////////////////////MRK FIX
                    }
                    // xuất hàng - trả lại nhà cung cấp
                    sdck = sddk = tongxuat = tongnhap = 0;

                    var querytralaincc = from tl in tralaincc
                                         where tl.Ngaytra.Month.Equals(thang) && tl.Ngaytra.Year.Equals(nam)
                                         select tl;

                    Entities.TraLaiNCC[] tralainccArr = querytralaincc.ToArray();
                    // lay chitiet tra lai ncc
                    var querycttralaincc = from s1 in tralainccArr
                                           join s2 in chitiettralaincc
                                           on s1.MaHDTraLaiNCC equals s2.MaHDTraLaiNCC
                                           select s2;

                    Entities.ChiTietTraLaiNhaCungCap[] cttralainccArr = querycttralaincc.ToArray();

                    for (int o = 0; o < cttralainccArr.Length; o++)
                    {
                        if (cttralainccArr[o].MaHangHoa == hanghoa[k].MaHangHoa)
                        {
                            tongxuat = cttralainccArr[o].SoLuong;
                            sdck = sddk + tongnhap - tongxuat;
                            hienthi = new Entities.BCXuatNhapTonPhieuXuatNhap("", cttralainccArr[o].MaHDTraLaiNCC,
                                "Trả lại nhà cung cấp", hanghoa[k].MaHangHoa, hanghoa[k].TenHangHoa, sddk,
                                tongnhap, tongxuat, sdck);
                            tempList.Add(hienthi);
                        }
                    }
                    // nhập hàng - hóa đơn nhập
                    sdck = sddk = tongxuat = tongnhap = 0;

                    var queryhoadonnhap = from nh in hoadonnhap
                                          where nh.NgayNhap.Month.Equals(thang) && nh.NgayNhap.Year.Equals(nam)
                                          select nh;

                    Entities.HoaDonNhap[] hoadonnhapArr = queryhoadonnhap.ToArray();
                    // lay chitiet hoa don nhap
                    var querycthoadonnhap = from s1 in hoadonnhap
                                            join s2 in chitiethoadonnhap
                                            on s1.MaHoaDonNhap equals s2.MaHoaDonNhap
                                            select s2;

                    Entities.ChiTietHoaDonNhap[] cthoadonnhapArr = querycthoadonnhap.ToArray();

                    for (int o = 0; o < cthoadonnhapArr.Length; o++)
                    {
                        if (cthoadonnhapArr[o].MaHangHoa == hanghoa[k].MaHangHoa)
                        {
                            tongnhap = cthoadonnhapArr[o].SoLuong;
                            sdck = sddk + tongnhap - tongxuat;
                            hienthi = new Entities.BCXuatNhapTonPhieuXuatNhap("", cthoadonnhapArr[o].MaHoaDonNhap,
                                "Hóa đơn nhập kho", hanghoa[k].MaHangHoa, hanghoa[k].TenHangHoa, sddk,
                                tongnhap, tongxuat, sdck);
                            tempList.Add(hienthi);
                        }
                    }
                    // nhập hàng - khách hàng trả lại
                    sdck = sddk = tongxuat = tongnhap = 0;

                    var querykhachhangtralai = from tl in khachhangtralai
                                               where tl.NgayNhap.Month.Equals(thang) && tl.NgayNhap.Year.Equals(nam)
                                               select tl;

                    Entities.KhachHangTraLai[] khachhangtralaiArr = querykhachhangtralai.ToArray();
                    // lay chi tiet khach hang tra lai
                    var queryctkhtralai = from s1 in khachhangtralaiArr
                                          join s2 in chitietkhachhangtralai
                                          on s1.MaKhachHangTraLai equals s2.MaKhachHangTraLai
                                          select s2;

                    Entities.ChiTietKhachHangTraLai[] ctkhtralaiArr = queryctkhtralai.ToArray();

                    for (int o = 0; o < ctkhtralaiArr.Length; o++)
                    {
                        if (ctkhtralaiArr[o].MaHangHoa == hanghoa[k].MaHangHoa)
                        {
                            tongnhap = ctkhtralaiArr[o].SoLuong;
                            sdck = sddk + tongnhap - tongxuat;
                            hienthi = new Entities.BCXuatNhapTonPhieuXuatNhap("", ctkhtralaiArr[o].MaKhachHangTraLai,
                                "Khách hàng trả lại", hanghoa[k].MaHangHoa, hanghoa[k].TenHangHoa, sddk,
                                tongnhap, tongxuat, sdck);
                            tempList.Add(hienthi);
                        }
                    }
                    ////////////////////////// END HÀNG HÓA
                }

                // loc cac ma hoa don thanh nhom.
                List<string> maHoaDonList = new List<string>();
                foreach (Entities.BCXuatNhapTonPhieuXuatNhap nxt in tempList)
                {
                    if (!maHoaDonList.Contains(nxt.MaPhieuXuatNhap))
                    {
                        maHoaDonList.Add(nxt.MaPhieuXuatNhap);
                    }
                }

                // sap xep cac hoa don giong nhau len tren .
                List<Entities.BCXuatNhapTonPhieuXuatNhap> temp1 = new List<Entities.BCXuatNhapTonPhieuXuatNhap>();
                foreach (string st in maHoaDonList.ToArray())
                {
                    foreach (Entities.BCXuatNhapTonPhieuXuatNhap xnt1 in tempList.ToArray())
                    {
                        if (st.Equals(xnt1.MaPhieuXuatNhap))
                        {
                            temp1.Add(xnt1);
                        }

                    }
                }

                hienthibaocao = temp1.ToArray();

                ///////////////////////////////MRK FIX
                List<Entities.BCXuatNhapTonPhieuXuatNhap> tem0 = new List<Entities.BCXuatNhapTonPhieuXuatNhap>();
                double tong0 = 0;
                double tong1 = 0;
                double tong2 = 0;
                double tong3 = 0;
                foreach (Entities.BCXuatNhapTonPhieuXuatNhap item in temp1.ToArray())
                {
                    if (item == null)
                    {
                        continue;
                    }
                    tong0 += item.SoDuDauKy;
                    tong1 += item.TongNhap;
                    tong2 += item.TongXuat;
                    tong3 += item.SoDuCuoiKy;
                    tem0.Add(item);
                }
                Entities.BCXuatNhapTonPhieuXuatNhap tem1 = new Entities.BCXuatNhapTonPhieuXuatNhap();
                tem1.TenHang = "Tổng: ";
                tem1.SoDuDauKy = tong0;
                tem1.TongNhap = tong1;
                tem1.TongXuat = tong2;
                tem1.SoDuCuoiKy = tong3;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = hienthi;
                dtgvhienthi.DataSource = tem0.ToArray();

                if (tem0.ToArray().Length > 0)
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
                }
                else
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
                }
            }
            catch
            {
            }
            finally
            {
                fix();
            }
        }

        public string Format(double a)
        {
            return String.Format("{0:0,0}", a);
        }

        public void fix()
        {
            new Common.Utilities().CountDatagridview(dtgvhienthi);
            dtgvhienthi.ReadOnly = true;
            dtgvhienthi.RowHeadersVisible = false;
            dtgvhienthi.Columns["HanhDong"].HeaderText = "STT";
            dtgvhienthi.Columns["MaHang"].HeaderText = "Mã Hàng Hóa";
            dtgvhienthi.Columns["TenHang"].HeaderText = "Tên Hàng Hóa";
            dtgvhienthi.Columns["SoDuDauKy"].HeaderText = "Số Dư Đầu Kỳ";
            dtgvhienthi.Columns["TongNhap"].HeaderText = "Tổng Nhập";
            dtgvhienthi.Columns["TongXuat"].HeaderText = "Tổng Xuất";
            dtgvhienthi.Columns["SoDuCuoiKy"].HeaderText = "Số Dư Cuối Kỳ";
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.AllowUserToAddRows = false;
            dtgvhienthi.AllowUserToDeleteRows = false;
            dtgvhienthi.AllowUserToResizeRows = false;
            this.Focus();
        }

        DateTime truoc;
        DateTime sau;
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
        int i = 0;
        private void dtgvhienthi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }
        public Entities.BCXuatNhapTonPhieuXuatNhap[] ChiTiet()
        {
            try
            {
                Entities.BCXuatNhapTonPhieuXuatNhap[] rt = new Entities.BCXuatNhapTonPhieuXuatNhap[dtgvhienthi.RowCount];
                for (int i = 0; i < dtgvhienthi.RowCount; i++)
                {
                    rt[i] = new Entities.BCXuatNhapTonPhieuXuatNhap("", dtgvhienthi["MaPhieuXuatNhap", i].Value.ToString(), dtgvhienthi["TenPhieuXuatNhap", i].Value.ToString(),
                        dtgvhienthi["MaHang", i].Value.ToString(), dtgvhienthi["TenHang", i].Value.ToString(), double.Parse(dtgvhienthi["SoDuDauKy", i].Value.ToString()), double.Parse(dtgvhienthi["TongNhap", i].Value.ToString()),
                        double.Parse(dtgvhienthi["TongXuat", i].Value.ToString()), double.Parse(dtgvhienthi["SoDuCuoiKy", i].Value.ToString()));
                }
                return rt;
            }
            catch
            {
                return new Entities.BCXuatNhapTonPhieuXuatNhap[0];
            }
        }
        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Enabled = false;
            if (i < 0)
                return;
            try
            {
                frmBaoCaorpt a = new frmBaoCaorpt(ChiTiet(), thang + "/" + nam);
                a.ShowDialog();
            }
            catch
            {
            }
            finally
            {
                this.Enabled = true;
            }
        }


        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (i < 0)
                return;
            try
            {
                frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, thang + "/" + nam);
                a.ShowDialog();
            }
            catch
            {
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                nam = int.Parse(cbbnam.Text);
                thang = int.Parse(cbbthang.Text);
                TongTienNhanVien();
                lbtenbaocao.Text = "Báo Cáo Xuất Nhập Tồn Theo Phiếu Xuất Nhập Kỳ " + cbbthang.Text + "/" + cbbnam.Text;
            }
            catch
            {
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void frmBCXuatNhapTonPhieuXuatNhap_Load(object sender, EventArgs e)
        {
            lbtenbaocao.Text = "Báo Cáo Xuất Nhập Tồn Theo Phiếu Xuất Nhập Kỳ " + cbbthang.Text + "/" + cbbnam.Text;
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, thang + "/" + nam, saveFileDialog1.FileName, "PDF");
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

        private void tsslWord_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, thang + "/" + nam, saveFileDialog1.FileName, "Word");
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

        private void tsslexcel_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, thang + "/" + nam, saveFileDialog1.FileName, "Excel");
                }
            }
            catch
            {
            }
            finally
            { this.Enabled = true; }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                PhieuXuatHuy();
                ChiTietXuatHuy();
                HDBanHang();
                ChiTietHDBanHang();
                HoaDonNhap();
                ChiTietHoaDonNhap();
                TraLaiNCC();
                ChiTietTraLaiNCC();
                KhachHangTraLai();
                ChiTietKhachHangTraLai();
                HangHoa();
                SoDuKho();
                TongTienNhanVien(); this.Focus();
            }
            catch
            {
            }
            this.Enabled = true;
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbtimkiem3.Checked == true)
                {
                    return;
                }
                if (txttimkiem.Text.Length == 0)
                {
                    dtgvhienthi.DataSource = new Entities.BCXuatNhapTonPhieuXuatNhap[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtimkiem1.Checked == true)
                    {
                        for (int i = 0; i < hienthibaocao.Length; i++)
                        {
                            int kiemtra = hienthibaocao[i].MaPhieuXuatNhap.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCXuatNhapTonPhieuXuatNhap[0];
                            return;
                        }
                        Entities.BCXuatNhapTonPhieuXuatNhap[] hienthitheoid = new Entities.BCXuatNhapTonPhieuXuatNhap[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthibaocao.Length; i++)
                        {
                            int kiemtra = hienthibaocao[i].MaPhieuXuatNhap.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid[soluong] = hienthibaocao[i];
                                soluong++;
                            }
                        }
                        ///////////////////////////////MRK FIX
                        List<Entities.BCXuatNhapTonPhieuXuatNhap> tem0 = new List<Entities.BCXuatNhapTonPhieuXuatNhap>();
                        double tong0 = 0;
                        double tong1 = 0;
                        double tong2 = 0;
                        double tong3 = 0;
                        foreach (Entities.BCXuatNhapTonPhieuXuatNhap item in hienthitheoid)
                        {
                            tong0 += item.SoDuDauKy;
                            tong1 += item.TongNhap;
                            tong2 += item.TongXuat;
                            tong3 += item.SoDuCuoiKy;
                            tem0.Add(item);
                        }
                        Entities.BCXuatNhapTonPhieuXuatNhap tem1 = new Entities.BCXuatNhapTonPhieuXuatNhap();
                        tem1.HanhDong = "Tổng: ";
                        tem1.SoDuDauKy = tong0;
                        tem1.TongNhap = tong1;
                        tem1.TongXuat = tong2;
                        tem1.SoDuCuoiKy = tong3;
                        tem0.Add(tem1);
                        //////////////////////////////////////
                        //dtgvhienthi.DataSource = hienthitheoid;
                        dtgvhienthi.DataSource = tem0.ToArray();

                    }
                    if (dtgvhienthi.RowCount > 0)
                    {
                        tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
                    }
                    else
                    {
                        tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
                    }
                }
            }
            finally
            {
                fix();
            }
        }

        private void rdbtimkiem3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (hienthi == null)
                {
                    dtgvhienthi.DataSource = new Entities.BCXuatNhapTonPhieuXuatNhap[0];
                    return;
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCXuatNhapTonPhieuXuatNhap> tem0 = new List<Entities.BCXuatNhapTonPhieuXuatNhap>();
                double tong0 = 0;
                double tong1 = 0;
                double tong2 = 0;
                double tong3 = 0;
                foreach (Entities.BCXuatNhapTonPhieuXuatNhap item in tem0)
                {
                    tong0 += item.SoDuDauKy;
                    tong1 += item.TongNhap;
                    tong2 += item.TongXuat;
                    tong3 += item.SoDuCuoiKy;
                    tem0.Add(item);
                }
                Entities.BCXuatNhapTonPhieuXuatNhap tem1 = new Entities.BCXuatNhapTonPhieuXuatNhap();
                tem1.HanhDong = "Tổng: ";
                tem1.SoDuDauKy = tong0;
                tem1.TongNhap = tong1;
                tem1.TongXuat = tong2;
                tem1.SoDuCuoiKy = tong3;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = hienthi;
                dtgvhienthi.DataSource = tem0.ToArray();

            }
            catch
            {
            }
            finally
            {
                fix();

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
