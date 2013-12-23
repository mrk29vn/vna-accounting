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
    public partial class frmBCXuatNhapTonLoaiHang : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        int nam = 0;
        int thang = 0;
        public frmBCXuatNhapTonLoaiHang()
        {
            try
            {
                InitializeComponent();

                DateTime dt = DateTime.Now;

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
                LoaiHangHoa();
                NhomHang();
                SoDuKho();
                GoiHang();
                ChiTietGoiHang();
                TongTienNhanVien();
            }
            catch
            {
            }

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
        Entities.LoaiHangHoa[] loaihanghoa;
        public void LoaiHangHoa()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("LH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                loaihanghoa = (Entities.LoaiHangHoa[])cl.DeserializeHepper1(clientstrem, loaihanghoa);
                if (loaihanghoa == null)
                {
                    loaihanghoa = new Entities.LoaiHangHoa[0];
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
        Entities.NhomHang[] nhomhang;
        public void NhomHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("NH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                nhomhang = (Entities.NhomHang[])cl.DeserializeHepper1(clientstrem, nhomhang);
                if (nhomhang == null)
                {
                    nhomhang = new Entities.NhomHang[0];
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
        Entities.BCXuatNhapTonTheoLoaiHang[] hienthi;
        Entities.BCXuatNhapTonTheoLoaiHangChiTiet[] hienthibaocao;
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
                hienthi = new Entities.BCXuatNhapTonTheoLoaiHang[loaihanghoa.Length];
                List<Entities.BCXuatNhapTonTheoLoaiHangChiTiet> list = new List<Entities.BCXuatNhapTonTheoLoaiHangChiTiet>();

                // For Loai Hang
                for (int i = 0; i < loaihanghoa.Length; i++)
                {
                    sdck = sddk = tongxuat = tongnhap = 0;
                    // Lay tat ca nhom hang thuoc loai hang tren
                    var query = from nh in nhomhang
                                where nh.MaLoaiHang.Equals(loaihanghoa[i].MaLoaiHang)
                                select nh;

                    Entities.NhomHang[] nhomHangArr = query.ToArray();

                    // lay hang hoa trong nhom hang 
                    var queryhh = from s1 in nhomHangArr
                                  join s2 in hanghoa
                                  on s1.MaNhomHang equals s2.MaNhomHangHoa
                                  select s2;

                    Entities.HangHoa[] hangHoaArr = queryhh.ToArray();

                    for (int k = 0; k < hangHoaArr.Length; k++)
                    {
                        sdckhh = sddkhh = 0;
                        // số dư đầu kỳ
                        for (int l = 0; l < sodukho.Length; l++)
                        {
                            if (sodukho[l].MaHangHoa == hangHoaArr[k].MaHangHoa)
                            {
                                sddkhh = sodukho[l].SoDuDauKy;
                                sddk += sodukho[l].SoDuDauKy;
                                break;
                            }
                        }
                        // xuất hàng - phiếu xuất hủy
                        nhapmua = nhaptralai = nhapkhac = xuatban = xuattralai = xuatkhac = 0;
                        // lay cac phieu xuat huy trong thang
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
                            if (chitietxuathuyArr[o].MaHangHoa == hangHoaArr[k].MaHangHoa)
                            {
                                tongxuat += chitietxuathuyArr[o].SoLuong;
                                xuatkhac += chitietxuathuyArr[o].SoLuong;
                            }
                        }
                        // xuất hàng - hóa đơn bán hàng
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

                        foreach (Entities.ChiTietHDBanHang item3 in chitiethdbanhangArr)
                        {
                            if (hangHoaArr[k].MaHangHoa.Equals(item3.MaHangHoa))
                            {
                                tongxuat += item3.SoLuong;
                                xuatban += item3.SoLuong;
                            }
                            else
                            {
                                foreach (Entities.ChiTietGoiHang item5 in chitietgoihang)
                                {
                                    if (item5.MaGoiHang.Equals(item3.MaHangHoa))
                                    {
                                        if (hangHoaArr[k].MaHangHoa.Equals(item5.MaHangHoa))
                                        {
                                            tongxuat += (item5.SoLuong * item3.SoLuong);
                                            xuatban += (item5.SoLuong * item3.SoLuong);
                                        }
                                    }

                                }
                            }
                        }
                        // xuất hàng - trả lại nhà cung cấp
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
                            if (cttralainccArr[o].MaHangHoa == hangHoaArr[k].MaHangHoa)
                            {
                                tongxuat += cttralainccArr[o].SoLuong;
                                xuattralai += cttralainccArr[o].SoLuong;
                            }
                        }
                        // nhập hàng - hóa đơn nhập
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
                            if (cthoadonnhapArr[o].MaHangHoa == hangHoaArr[k].MaHangHoa)
                            {
                                tongnhap += cthoadonnhapArr[o].SoLuong;
                                nhapmua += cthoadonnhapArr[o].SoLuong;
                            }
                        }
                        // nhập hàng - khách hàng trả lại
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

                        foreach (Entities.ChiTietKhachHangTraLai item3 in ctkhtralaiArr)
                        {
                            if (hangHoaArr[k].MaHangHoa.Equals(item3.MaHangHoa))
                            {
                                tongnhap += item3.SoLuong;
                                nhaptralai += item3.SoLuong;
                            }
                            else
                            {
                                foreach (Entities.ChiTietGoiHang item5 in chitietgoihang)
                                {
                                    if (item5.MaGoiHang.Equals(item3.MaHangHoa))
                                    {
                                        if (hangHoaArr[k].MaHangHoa.Equals(item5.MaHangHoa))
                                        {
                                            tongnhap += (item5.SoLuong * item3.SoLuong);
                                            nhaptralai += (item5.SoLuong * item3.SoLuong);
                                        }
                                    }
                                }
                            }
                        }

                        sdckhh = sddkhh + nhapkhac + nhapmua + nhaptralai - xuatkhac - xuatban - xuattralai;
                        Entities.BCXuatNhapTonTheoLoaiHangChiTiet item = new Entities.BCXuatNhapTonTheoLoaiHangChiTiet(loaihanghoa[i].MaLoaiHang, loaihanghoa[i].TenLoaiHang, hangHoaArr[k].MaHangHoa, hangHoaArr[k].TenHangHoa, sddkhh, nhapmua, nhaptralai, nhapkhac, xuatban, xuattralai, xuatkhac, sdckhh);
                        list.Add(item);
                    }

                    sdck = sddk + tongnhap - tongxuat;
                    hienthi[i] = new Entities.BCXuatNhapTonTheoLoaiHang("", loaihanghoa[i].MaLoaiHang, loaihanghoa[i].TenLoaiHang, sddk.ToString(), tongnhap.ToString(), tongxuat.ToString(), sdck.ToString());
                }

                hienthibaocao = list.ToArray();

                Entities.BCXuatNhapTonTheoLoaiHang[] temp = new Entities.BCXuatNhapTonTheoLoaiHang[hienthi.Length];
                int soluong = 0;
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (Convert.ToDouble(hienthi[i].TongNhap) != 0 || Convert.ToDouble(hienthi[i].TongXuat) != 0)
                    {
                        temp[soluong] = hienthi[i];
                        soluong++;
                    }
                }
                hienthi = new Entities.BCXuatNhapTonTheoLoaiHang[soluong];
                for (int i = 0; i < soluong; i++)
                {
                    hienthi[i] = temp[i];
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCXuatNhapTonTheoLoaiHang> tem0 = new List<Entities.BCXuatNhapTonTheoLoaiHang>();
                double tong0 = 0;
                double tong1 = 0;
                double tong2 = 0;
                double tong3 = 0;
                foreach (Entities.BCXuatNhapTonTheoLoaiHang item in hienthi)
                {
                    tong0 += double.Parse(item.SoDuDauKy);
                    tong1 += double.Parse(item.TongNhap);
                    tong2 += double.Parse(item.TongXuat);
                    tong3 += double.Parse(item.SoDuCuoiKy);
                    tem0.Add(item);
                }
                Entities.BCXuatNhapTonTheoLoaiHang tem1 = new Entities.BCXuatNhapTonTheoLoaiHang();
                tem1.TenLoaiHang = "Tổng: ";
                tem1.SoDuDauKy = tong0.ToString();
                tem1.TongNhap = tong1.ToString();
                tem1.TongXuat = tong2.ToString();
                tem1.SoDuCuoiKy = tong3.ToString();
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = hienthi;
                dtgvhienthi.DataSource = tem0.ToArray();

                if (hienthi.Length > 0)
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

        //Fixbug DHT
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
            dtgvhienthi.Columns["MaLoaiHang"].HeaderText = "Ngày Bán";
            dtgvhienthi.Columns["TenLoaiHang"].HeaderText = "Tên Loại Hàng";
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

        public Entities.BCXuatNhapTonTheoLoaiHangChiTiet[] ChiTietLoai(string maloaihang)
        {
            try
            {
                int sl = 0;
                Entities.BCXuatNhapTonTheoLoaiHangChiTiet[] temp = new Entities.BCXuatNhapTonTheoLoaiHangChiTiet[hienthibaocao.Length];
                for (int i = 0; i < hienthibaocao.Length; i++)
                {
                    if (hienthibaocao[i].MaLoaiHang == maloaihang)
                    {
                        if (hienthibaocao[i].NhapKhac != 0 || hienthibaocao[i].NhapMua != 0 || hienthibaocao[i].NhapTraLai != 0 || hienthibaocao[i].XuatBan != 0 || hienthibaocao[i].XuatKhac != 0 || hienthibaocao[i].XuatTraLai != 0)
                        {
                            temp[sl] = hienthibaocao[i];
                            sl++;
                        }
                    }
                }
                Entities.BCXuatNhapTonTheoLoaiHangChiTiet[] baocao = new Entities.BCXuatNhapTonTheoLoaiHangChiTiet[sl];
                for (int i = 0; i < sl; i++)
                {
                    baocao[i] = temp[i];
                }
                return baocao;
            }
            catch
            {
                return new Entities.BCXuatNhapTonTheoLoaiHangChiTiet[0];
            }
        }

        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Enabled = false;
            if (i < 0)
                return;
            try
            {
                string maloaihang = dtgvhienthi["MaLoaiHang", i].Value.ToString();
                frmBaoCaorpt a = new frmBaoCaorpt(ChiTietLoai(maloaihang), thang + "/" + nam);
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
                string maloaihang = dtgvhienthi["MaLoaiHang", i].Value.ToString();
                frmBaoCaorpt a = new frmBaoCaorpt(ChiTietLoai(maloaihang), thang + "/" + nam);
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
                lbtenbaocao.Text = "Báo Cáo Xuất Nhập Tồn Theo Loại Hàng Kỳ " + cbbthang.Text + "/" + cbbnam.Text;
            }
            catch
            {
            }
            this.Enabled = true;
        }

        private void frmBCXuatNhapTonLoaiHang_Load(object sender, EventArgs e)
        {
            lbtenbaocao.Text = "Báo Cáo Xuất Nhập Tồn Theo Loại Hàng Kỳ " + cbbthang.Text + "/" + cbbnam.Text;
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
                    string maloaihang = dtgvhienthi["MaLoaiHang", i].Value.ToString();
                    frmBaoCaorpt a = new frmBaoCaorpt(ChiTietLoai(maloaihang), thang + "/" + nam, saveFileDialog1.FileName, "PDF");
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
                    string maloaihang = dtgvhienthi["MaLoaiHang", i].Value.ToString();
                    frmBaoCaorpt a = new frmBaoCaorpt(ChiTietLoai(maloaihang), thang + "/" + nam, saveFileDialog1.FileName, "Word");
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
                    string maloaihang = dtgvhienthi["MaLoaiHang", i].Value.ToString();
                    frmBaoCaorpt a = new frmBaoCaorpt(ChiTietLoai(maloaihang), thang + "/" + nam, saveFileDialog1.FileName, "Excel");
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
                LoaiHangHoa();
                NhomHang();
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
                    dtgvhienthi.DataSource = new Entities.BCXuatNhapTonTheoLoaiHang[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtimkiem1.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaLoaiHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCXuatNhapTonTheoLoaiHang[0];
                            return;
                        }
                        Entities.BCXuatNhapTonTheoLoaiHang[] hienthitheoid = new Entities.BCXuatNhapTonTheoLoaiHang[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaLoaiHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        ///////////////////////////////MRK FIX
                        List<Entities.BCXuatNhapTonTheoLoaiHang> tem0 = new List<Entities.BCXuatNhapTonTheoLoaiHang>();
                        double tong0 = 0;
                        double tong1 = 0;
                        double tong2 = 0;
                        double tong3 = 0;
                        foreach (Entities.BCXuatNhapTonTheoLoaiHang item in hienthitheoid)
                        {
                            tong0 += double.Parse(item.SoDuDauKy);
                            tong1 += double.Parse(item.TongNhap);
                            tong2 += double.Parse(item.TongXuat);
                            tong3 += double.Parse(item.SoDuCuoiKy);
                            tem0.Add(item);
                        }
                        Entities.BCXuatNhapTonTheoLoaiHang tem1 = new Entities.BCXuatNhapTonTheoLoaiHang();
                        tem1.TenLoaiHang = "Tổng: ";
                        tem1.SoDuDauKy = tong0.ToString();
                        tem1.TongNhap = tong1.ToString();
                        tem1.TongXuat = tong2.ToString();
                        tem1.SoDuCuoiKy = tong3.ToString();
                        tem0.Add(tem1);
                        //////////////////////////////////////
                        //dtgvhienthi.DataSource = hienthitheoid;
                        dtgvhienthi.DataSource = tem0.ToArray();

                    }
                    if (rdbtimkiem2.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenLoaiHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCXuatNhapTonTheoLoaiHang[0];
                            return;
                        }
                        Entities.BCXuatNhapTonTheoLoaiHang[] hienthitheoma = new Entities.BCXuatNhapTonTheoLoaiHang[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenLoaiHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        ///////////////////////////////MRK FIX
                        List<Entities.BCXuatNhapTonTheoLoaiHang> tem0 = new List<Entities.BCXuatNhapTonTheoLoaiHang>();
                        double tong0 = 0;
                        double tong1 = 0;
                        double tong2 = 0;
                        double tong3 = 0;
                        foreach (Entities.BCXuatNhapTonTheoLoaiHang item in hienthitheoma)
                        {
                            tong0 += double.Parse(item.SoDuDauKy);
                            tong1 += double.Parse(item.TongNhap);
                            tong2 += double.Parse(item.TongXuat);
                            tong3 += double.Parse(item.SoDuCuoiKy);
                            tem0.Add(item);
                        }
                        Entities.BCXuatNhapTonTheoLoaiHang tem1 = new Entities.BCXuatNhapTonTheoLoaiHang();
                        tem1.TenLoaiHang = "Tổng: ";
                        tem1.SoDuDauKy = tong0.ToString();
                        tem1.TongNhap = tong1.ToString();
                        tem1.TongXuat = tong2.ToString();
                        tem1.SoDuCuoiKy = tong3.ToString();
                        tem0.Add(tem1);
                        //////////////////////////////////////
                        //dtgvhienthi.DataSource = hienthitheoma;
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
                    dtgvhienthi.DataSource = new Entities.BCXuatNhapTonTheoLoaiHang[0];
                    return;
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCXuatNhapTonTheoLoaiHang> tem0 = new List<Entities.BCXuatNhapTonTheoLoaiHang>();
                double tong0 = 0;
                double tong1 = 0;
                double tong2 = 0;
                double tong3 = 0;
                foreach (Entities.BCXuatNhapTonTheoLoaiHang item in hienthi)
                {
                    tong0 += double.Parse(item.SoDuDauKy);
                    tong1 += double.Parse(item.TongNhap);
                    tong2 += double.Parse(item.TongXuat);
                    tong3 += double.Parse(item.SoDuCuoiKy);
                    tem0.Add(item);
                }
                Entities.BCXuatNhapTonTheoLoaiHang tem1 = new Entities.BCXuatNhapTonTheoLoaiHang();
                tem1.TenLoaiHang = "Tổng: ";
                tem1.SoDuDauKy = tong0.ToString();
                tem1.TongNhap = tong1.ToString();
                tem1.TongXuat = tong2.ToString();
                tem1.SoDuCuoiKy = tong3.ToString();
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
