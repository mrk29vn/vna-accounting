using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmTongHopXNT : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        int nam = 0;
        int thang = 0;

        public frmTongHopXNT()
        {
            InitializeComponent();
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                nam = int.Parse(cbbnam.Text);
                thang = int.Parse(cbbthang.Text);
                TongTienNhanVien();
                lbtenbaocao.Text = "Tổng Hợp Xuất Nhập Tồn Theo Kho Kỳ " + cbbthang.Text + "/" + cbbnam.Text;
            }
            catch
            {
            } this.Enabled = true;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
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
                PhieuDieuChuyenKhoNoiBo();
                ChiTietPhieuDieuChuyenKho();
                KhachHangTraLai();
                ChiTietKhachHangTraLai();
                HangHoa();
                KhoHang();
                ChiTietKhoHang();
                SoDuKho();
                TongTienNhanVien();
                this.Focus();
            }
            catch
            {
            }
            this.Enabled = true;
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
        Entities.BCXuatNhapTonTheoKho[] hienthi;
        Entities.BCXuatNhapTonTheoKhoChiTiet[] hienthibaocao;
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
                hienthi = new Entities.BCXuatNhapTonTheoKho[khohang.Length];
                for (int i = 0; i < khohang.Length; i++)
                {
                    for (int j = 0; j < chitietkhohang.Length; j++)
                    {
                        if (chitietkhohang[j].Makho == khohang[i].MaKho)
                        {
                            for (int k = 0; k < hanghoa.Length; k++)
                            {
                                if (hanghoa[k].MaHangHoa == chitietkhohang[j].Mahanghoa)
                                {
                                    sotang++;   //Đếm số hàng hóa trong kho
                                }
                            }
                        }
                    }
                }
                int sohanghoatrongkho = sotang;
                hienthibaocao = new Entities.BCXuatNhapTonTheoKhoChiTiet[sotang];
                sotang = 0;
                for (int i = 0; i < khohang.Length; i++)
                {
                    tongxuat = tongnhap = sddk = 0;
                    for (int j = 0; j < chitietkhohang.Length; j++)
                    {
                        if (chitietkhohang[j].Makho == khohang[i].MaKho)
                        {
                            for (int k = 0; k < hanghoa.Length; k++)
                            {
                                if (hanghoa[k].MaHangHoa == chitietkhohang[j].Mahanghoa)
                                {
                                    sdckhh = sddkhh = sdck = 0;
                                    // số dư đầu kỳ
                                    for (int l = 0; l < sodukho.Length; l++)
                                    {
                                        if (sodukho[l].MaHangHoa == hanghoa[k].MaHangHoa)
                                        {
                                            int namphieu = sodukho[l].NgayKetChuyen.Year;
                                            int thangphieu = sodukho[l].NgayKetChuyen.Month;
                                            if (nam == namphieu && thang == thangphieu)
                                            {
                                                sddk += sodukho[l].SoDuDauKy;
                                                sddkhh = sodukho[l].SoDuDauKy;
                                                break;
                                            }
                                        }
                                    }
                                    // xuất hàng - phiếu xuất hủy
                                    nhapmua = nhaptralai = nhapkhac = xuatban = xuattralai = xuatkhac = 0;
                                    for (int l = 0; l < phieuxuathuy.Length; l++)
                                    {
                                        for (int o = 0; o < chitietxuathuy.Length; o++)
                                        {
                                            int namphieu = phieuxuathuy[l].NgayLap.Year;
                                            int thangphieu = phieuxuathuy[l].NgayLap.Month;
                                            if (phieuxuathuy[l].MaPhieuXuatHuy == chitietxuathuy[o].MaPhieuXuatHuy && nam == namphieu && thang == thangphieu && phieuxuathuy[l].TrangThai == true && phieuxuathuy[l].MaKho == khohang[i].MaKho)
                                            {
                                                if (chitietxuathuy[o].MaHangHoa == hanghoa[k].MaHangHoa)
                                                {
                                                    tongxuat += chitietxuathuy[o].SoLuong;
                                                    xuatkhac += chitietxuathuy[o].SoLuong;
                                                }
                                            }
                                        }
                                    }
                                    // xuất hàng - hóa đơn bán hàng
                                    for (int l = 0; l < hdbanhang.Length; l++)
                                    {
                                        for (int o = 0; o < chitiethdbanhang.Length; o++)
                                        {
                                            int namphieu = hdbanhang[l].NgayBan.Year;
                                            int thangphieu = hdbanhang[l].NgayBan.Month;
                                            if (chitiethdbanhang[o].MaHDBanHang == hdbanhang[l].MaHDBanHang && nam == namphieu && thang == thangphieu &&hdbanhang[l].MaKho== khohang[i].MaKho)
                                            {
                                                //kiểm tra nó là hàng hóa hay mã hàng
                                                if (this.GoiHangOrHangHoa(chitiethdbanhang[o].MaHangHoa))
                                                { //là gói hàng
                                                    for (int for6 = 0; for6 < goihang.Length; for6++)
                                                    {
                                                        for (int for7 = 0; for7 < chitietgoihang.Length; for7++)
                                                        {
                                                            if (goihang[for6].MaGoiHang.Equals(chitietgoihang[for7].MaGoiHang) && chitietgoihang[for7].MaGoiHang.Equals(chitiethdbanhang[o].MaHangHoa))
                                                            {
                                                                //-------
                                                                if (chitietgoihang[for7].MaHangHoa == hanghoa[k].MaHangHoa)
                                                                {
                                                                    tongxuat += (chitietgoihang[for7].SoLuong * chitiethdbanhang[o].SoLuong);
                                                                    xuatban += (chitietgoihang[for7].SoLuong * chitiethdbanhang[o].SoLuong);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                { //là hàng hóa
                                                    if (chitiethdbanhang[o].MaHangHoa == hanghoa[k].MaHangHoa)
                                                    {
                                                        tongxuat += chitiethdbanhang[o].SoLuong;
                                                        xuatban += chitiethdbanhang[o].SoLuong;
                                                    }
                                                }
                                                //End kiểm tra
                                            }
                                        }
                                    }
                                    // xuất hàng - trả lại nhà cung cấp
                                    for (int l = 0; l < tralaincc.Length; l++)
                                    {
                                        for (int o = 0; o < chitiettralaincc.Length; o++)
                                        {
                                            int namphieu = tralaincc[l].Ngaytra.Year;
                                            int thangphieu = tralaincc[l].Ngaytra.Month;
                                            if (chitiettralaincc[o].MaHDTraLaiNCC == tralaincc[l].MaHDTraLaiNCC && nam == namphieu && thang == thangphieu && tralaincc[l].MaKho == khohang[i].MaKho)
                                            {
                                                if (chitiettralaincc[o].MaHangHoa == hanghoa[k].MaHangHoa)
                                                {
                                                    tongxuat += chitiettralaincc[o].SoLuong;
                                                    xuattralai += chitiettralaincc[o].SoLuong;
                                                }
                                            }
                                        }
                                    }
                                    // xuất hàng - phiếu điều chuyển kho nội bộ
                                    for (int l = 0; l < phieudieuchuyenkhonoibo.Length; l++)
                                    {
                                        if (phieudieuchuyenkhonoibo[l].TuKho == khohang[i].MaKho)
                                        {
                                            for (int o = 0; o < chitietphieudieuchuyenkho.Length; o++)
                                            {
                                                int namphieu = phieudieuchuyenkhonoibo[l].NgayDieuChuyen.Year;
                                                int thangphieu = phieudieuchuyenkhonoibo[l].NgayDieuChuyen.Month;
                                                if (chitietphieudieuchuyenkho[o].MaPhieuDieuChuyenKho == phieudieuchuyenkhonoibo[l].MaPhieuDieuChuyenKho && nam == namphieu && thang == thangphieu && phieudieuchuyenkhonoibo[l].TuKho == khohang[i].MaKho)
                                                {
                                                    //kiểm tra nó là hàng hóa hay mã hàng
                                                    if (this.GoiHangOrHangHoa(chitietphieudieuchuyenkho[o].MaHangHoa))
                                                    { //là gói hàng
                                                        for (int for6 = 0; for6 < goihang.Length; for6++)
                                                        {
                                                            for (int for7 = 0; for7 < chitietgoihang.Length; for7++)
                                                            {
                                                                if (goihang[for6].MaGoiHang.Equals(chitietgoihang[for7].MaGoiHang) && chitietgoihang[for7].MaGoiHang.Equals(chitietphieudieuchuyenkho[o].MaHangHoa))
                                                                {
                                                                    //-------
                                                                    if (chitietgoihang[for7].MaHangHoa == hanghoa[k].MaHangHoa)
                                                                    {
                                                                        tongxuat += (chitietgoihang[for7].SoLuong * chitietphieudieuchuyenkho[o].SoLuong); ;
                                                                        xuatban += (chitietgoihang[for7].SoLuong * chitietphieudieuchuyenkho[o].SoLuong); ;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    { //là hàng hóa
                                                        if (chitietphieudieuchuyenkho[o].MaHangHoa == hanghoa[k].MaHangHoa)
                                                        {
                                                            tongxuat += chitietphieudieuchuyenkho[o].SoLuong;
                                                            xuatkhac += chitietphieudieuchuyenkho[o].SoLuong;
                                                        }
                                                    }
                                                    //End kiểm tra
                                                }
                                            }
                                        }
                                    }
                                    // nhập hàng - hóa đơn nhập

                                    for (int l = 0; l < hoadonnhap.Length; l++)
                                    {
                                        for (int o = 0; o < chitiethoadonnhap.Length; o++)
                                        {
                                            int namphieu = hoadonnhap[l].NgayNhap.Year;
                                            int thangphieu = hoadonnhap[l].NgayNhap.Month;
                                            if (chitiethoadonnhap[o].MaHoaDonNhap == hoadonnhap[l].MaHoaDonNhap && nam == namphieu && thang == thangphieu && hoadonnhap[l].MaKho == khohang[i].MaKho)
                                            {
                                                if (chitiethoadonnhap[o].MaHangHoa == hanghoa[k].MaHangHoa)
                                                {
                                                    tongnhap += chitiethoadonnhap[o].SoLuong;
                                                    nhapmua += chitiethoadonnhap[o].SoLuong;
                                                }
                                            }
                                        }
                                    }
                                    // nhập hàng - khách hàng trả lại
                                    for (int l = 0; l < khachhangtralai.Length; l++)
                                    {
                                        for (int o = 0; o < chitietkhachhangtralai.Length; o++)
                                        {
                                            int namphieu = khachhangtralai[l].NgayNhap.Year;
                                            int thangphieu = khachhangtralai[l].NgayNhap.Month;
                                            if (chitietkhachhangtralai[o].MaKhachHangTraLai == khachhangtralai[l].MaKhachHangTraLai && nam == namphieu && thang == thangphieu && khachhangtralai[l].MaKho == khohang[i].MaKho)
                                            {
                                                //kiểm tra nó là hàng hóa hay mã hàng
                                                if (this.GoiHangOrHangHoa(chitietkhachhangtralai[o].MaHangHoa))
                                                { //là gói hàng
                                                    for (int for6 = 0; for6 < goihang.Length; for6++)
                                                    {
                                                        for (int for7 = 0; for7 < chitietgoihang.Length; for7++)
                                                        {
                                                            if (goihang[for6].MaGoiHang.Equals(chitietgoihang[for7].MaGoiHang) && chitietgoihang[for7].MaGoiHang.Equals(chitietkhachhangtralai[o].MaHangHoa))
                                                            {
                                                                //-------
                                                                if (chitietgoihang[for7].MaHangHoa == hanghoa[k].MaHangHoa)
                                                                {
                                                                    tongnhap += (chitietgoihang[for7].SoLuong * chitietkhachhangtralai[o].SoLuong);
                                                                    nhaptralai += (chitietgoihang[for7].SoLuong * chitietkhachhangtralai[o].SoLuong);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                { //là hàng hóa
                                                    if (chitietkhachhangtralai[o].MaHangHoa == hanghoa[k].MaHangHoa)
                                                    {
                                                        tongnhap += chitietkhachhangtralai[o].SoLuong;
                                                        nhaptralai += chitietkhachhangtralai[o].SoLuong;
                                                    }
                                                }
                                                //End kiểm tra
                                            }
                                        }
                                    }
                                    // nhập hàng - phiếu điều chuyển kho nội bộ
                                    for (int l = 0; l < phieudieuchuyenkhonoibo.Length; l++)
                                    {
                                        if (phieudieuchuyenkhonoibo[l].DenKho == khohang[i].MaKho)
                                        {
                                            for (int o = 0; o < chitietphieudieuchuyenkho.Length; o++)
                                            {
                                                int namphieu = phieudieuchuyenkhonoibo[l].NgayDieuChuyen.Year;
                                                int thangphieu = phieudieuchuyenkhonoibo[l].NgayDieuChuyen.Month;
                                                if (chitietphieudieuchuyenkho[o].MaPhieuDieuChuyenKho == phieudieuchuyenkhonoibo[l].MaPhieuDieuChuyenKho && nam == namphieu && thang == thangphieu && phieudieuchuyenkhonoibo[l].DenKho == khohang[i].MaKho)
                                                {
                                                    //kiểm tra nó là hàng hóa hay mã hàng
                                                    if (this.GoiHangOrHangHoa(chitietphieudieuchuyenkho[o].MaHangHoa))
                                                    { //là gói hàng
                                                        for (int for6 = 0; for6 < goihang.Length; for6++)
                                                        {
                                                            for (int for7 = 0; for7 < chitietgoihang.Length; for7++)
                                                            {
                                                                if (goihang[for6].MaGoiHang.Equals(chitietgoihang[for7].MaGoiHang) && chitietgoihang[for7].MaGoiHang.Equals(chitietphieudieuchuyenkho[o].MaHangHoa))
                                                                {
                                                                    //-------
                                                                    if (chitietgoihang[for7].MaHangHoa == hanghoa[k].MaHangHoa)
                                                                    {
                                                                        tongnhap += (chitietgoihang[for7].SoLuong * chitietphieudieuchuyenkho[o].SoLuong);
                                                                        nhapkhac += (chitietgoihang[for7].SoLuong * chitietphieudieuchuyenkho[o].SoLuong);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    { //là hàng hóa
                                                        if (chitietphieudieuchuyenkho[o].MaHangHoa == hanghoa[k].MaHangHoa)
                                                        {
                                                            tongnhap += chitietphieudieuchuyenkho[o].SoLuong;
                                                            nhapkhac += chitietphieudieuchuyenkho[o].SoLuong;
                                                        }
                                                    }
                                                    //End kiểm tra
                                                }
                                            }
                                        }
                                    }
                                    sdckhh = sddkhh + nhapkhac + nhapmua + nhaptralai - xuatkhac - xuatban - xuattralai;
                                    hienthibaocao[sotang] = new Entities.BCXuatNhapTonTheoKhoChiTiet(khohang[i].MaKho, khohang[i].TenKho, hanghoa[k].MaHangHoa, hanghoa[k].TenHangHoa, sddkhh, nhapmua, nhaptralai, nhapkhac, xuatban, xuattralai, xuatkhac, sdckhh);
                                    sotang++;
                                }
                            }
                        }
                    }
                    sdck = sddk + tongnhap - tongxuat;
                    hienthi[i] = new Entities.BCXuatNhapTonTheoKho("", khohang[i].MaKho, khohang[i].TenKho, sddk.ToString(), tongnhap.ToString(), tongxuat.ToString(), sdck.ToString());
                }
                Entities.BCXuatNhapTonTheoKho[] temp = new Entities.BCXuatNhapTonTheoKho[hienthi.Length];
                int soluong = 0;
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (hienthi[i].TongNhap != "0" || hienthi[i].TongXuat != "0")
                    {
                        temp[soluong] = hienthi[i];
                        soluong++;
                    }
                }
                hienthi = new Entities.BCXuatNhapTonTheoKho[soluong];
                for (int i = 0; i < soluong; i++)
                {
                    hienthi[i] = temp[i];
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCXuatNhapTonTheoKho> tem0 = new List<Entities.BCXuatNhapTonTheoKho>();
                double tong0 = 0;
                double tong1 = 0;
                double tong2 = 0;
                double tong3 = 0;
                foreach (Entities.BCXuatNhapTonTheoKho item in hienthi)
                {
                    tong0 += double.Parse(item.SoDuDauKy);
                    tong1 += double.Parse(item.TongNhap);
                    tong2 += double.Parse(item.TongXuat);
                    tong3 += double.Parse(item.SoDuCuoiKy);
                    tem0.Add(item);
                }
                Entities.BCXuatNhapTonTheoKho tem1 = new Entities.BCXuatNhapTonTheoKho();
                tem1.TenKho = "Tổng: ";
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
            dtgvhienthi.Columns["MaKho"].HeaderText = "Ngày Bán";
            dtgvhienthi.Columns["TenKho"].HeaderText = "Tên Loại Hàng";
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
        public Entities.BCXuatNhapTonTheoKhoChiTiet[] ChiTietKho(string makho)
        {
            try
            {
                int sl = 0;
                Entities.BCXuatNhapTonTheoKhoChiTiet[] temp = new Entities.BCXuatNhapTonTheoKhoChiTiet[hienthibaocao.Length];
                for (int i = 0; i < hienthibaocao.Length; i++)
                {
                    if (hienthibaocao[i].MaKho == makho)
                    {
                        if (hienthibaocao[i].NhapKhac != 0 || hienthibaocao[i].NhapMua != 0 || hienthibaocao[i].NhapTraLai != 0 || hienthibaocao[i].XuatBan != 0 || hienthibaocao[i].XuatKhac != 0 || hienthibaocao[i].XuatTraLai != 0)
                        {
                            temp[sl] = hienthibaocao[i];
                            sl++;
                        }
                    }
                }
                Entities.BCXuatNhapTonTheoKhoChiTiet[] baocao = new Entities.BCXuatNhapTonTheoKhoChiTiet[sl];
                for (int i = 0; i < sl; i++)
                {
                    baocao[i] = temp[i];
                }
                return baocao;
            }
            catch
            {
                return new Entities.BCXuatNhapTonTheoKhoChiTiet[0];
            }
        }

        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.ShowTheKho();
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            this.ShowTheKho();
        }

        private void rdbtimkiem3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (hienthi == null)
                {
                    dtgvhienthi.DataSource = new Entities.BCXuatNhapTonTheoKho[0];
                    return;
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCXuatNhapTonTheoKho> tem0 = new List<Entities.BCXuatNhapTonTheoKho>();
                double tong0 = 0;
                double tong1 = 0;
                double tong2 = 0;
                double tong3 = 0;
                foreach (Entities.BCXuatNhapTonTheoKho item in hienthi)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    tong0 += double.Parse(item.SoDuDauKy);
                    tong1 += double.Parse(item.TongNhap);
                    tong2 += double.Parse(item.TongXuat);
                    tong3 += double.Parse(item.SoDuCuoiKy);
                    tem0.Add(item);
                }
                Entities.BCXuatNhapTonTheoKho tem1 = new Entities.BCXuatNhapTonTheoKho();
                tem1.TenKho = "Tổng: ";
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
                    dtgvhienthi.DataSource = new Entities.BCXuatNhapTonTheoKho[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtimkiem1.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaKho.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCXuatNhapTonTheoKho[0];
                            return;
                        }
                        Entities.BCXuatNhapTonTheoKho[] hienthitheoid = new Entities.BCXuatNhapTonTheoKho[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaKho.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        ///////////////////////////////MRK FIX
                        List<Entities.BCXuatNhapTonTheoKho> tem0 = new List<Entities.BCXuatNhapTonTheoKho>();
                        double tong0 = 0;
                        double tong1 = 0;
                        double tong2 = 0;
                        double tong3 = 0;
                        foreach (Entities.BCXuatNhapTonTheoKho item in hienthitheoid)
                        {
                            tong0 += double.Parse(item.SoDuDauKy);
                            tong1 += double.Parse(item.TongNhap);
                            tong2 += double.Parse(item.TongXuat);
                            tong3 += double.Parse(item.SoDuCuoiKy);
                            tem0.Add(item);
                        }
                        Entities.BCXuatNhapTonTheoKho tem1 = new Entities.BCXuatNhapTonTheoKho();
                        tem1.TenKho = "Tổng: ";
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
                            int kiemtra = hienthi[i].TenKho.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCXuatNhapTonTheoKho[0];
                            return;
                        }
                        Entities.BCXuatNhapTonTheoKho[] hienthitheoma = new Entities.BCXuatNhapTonTheoKho[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].TenKho.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        ///////////////////////////////MRK FIX
                        List<Entities.BCXuatNhapTonTheoKho> tem0 = new List<Entities.BCXuatNhapTonTheoKho>();
                        double tong0 = 0;
                        double tong1 = 0;
                        double tong2 = 0;
                        double tong3 = 0;
                        foreach (Entities.BCXuatNhapTonTheoKho item in hienthitheoma)
                        {
                            tong0 += double.Parse(item.SoDuDauKy);
                            tong1 += double.Parse(item.TongNhap);
                            tong2 += double.Parse(item.TongXuat);
                            tong3 += double.Parse(item.SoDuCuoiKy);
                            tem0.Add(item);
                        }
                        Entities.BCXuatNhapTonTheoKho tem1 = new Entities.BCXuatNhapTonTheoKho();
                        tem1.TenKho = "Tổng: ";
                        tem1.SoDuDauKy = tong0.ToString();
                        tem1.TongNhap = tong1.ToString();
                        tem1.TongXuat = tong2.ToString();
                        tem1.SoDuCuoiKy = tong3.ToString();
                        tem0.Add(tem1);
                        //////////////////////////////////////
                        //dtgvhienthi.DataSource = hienthitheoma;
                        dtgvhienthi.DataSource = tem0.ToArray();

                    }
                }
            }
            finally
            {
                fix();
            }
        }

        ////////////////////////////////////////////////////MRK OK
        void ShowTheKho()
        {
            ////////////////////////////////SHOW THẺ KHO
            //this.Enabled = false;
            //if (i < 0)
            //    return;
            //try
            //{
            //    string makho = dtgvhienthi["MaKho", i].Value.ToString();

            //    frmBaoCaorpt a = new frmBaoCaorpt(ChiTietKho(makho), thang + "/" + nam);
            //    a.ShowDialog();
            //}
            //catch
            //{
            //}
            //finally
            //{
            //    this.Enabled = true;
            //}
        }
        //////////////////////////////////////////////////////////

    }
}
