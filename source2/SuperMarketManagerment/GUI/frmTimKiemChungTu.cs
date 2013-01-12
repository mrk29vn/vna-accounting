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
    public partial class frmTimKiemChungTu : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        public frmTimKiemChungTu()
        {
            InitializeComponent();
            SelectData();
            dtgvChiTiet.DataSource = dtgvHienThi.DataSource = new Entities.TimKiemChungTu[0];
            fixChiTiet();
            fixHienThi();
        }
        Entities.SelectAll selectall;

        Entities.PhieuXuatHuy[] phieuxuathuy;
        Entities.ChiTietXuatHuy[] chitietxuathuy;
        Entities.HDBanHang[] hdbanhang;
        Entities.ChiTietHDBanHang[] chitiethdbanhang;
        Entities.TraLaiNCC[] tralaincc;
        Entities.ChiTietTraLaiNhaCungCap[] chitiettralaincc;
        Entities.HoaDonNhap[] hoadonnhap;
        Entities.ChiTietHoaDonNhap[] chitiethoadonnhap;
        Entities.KhachHangTraLai[] khachhangtralai;
        Entities.ChiTietKhachHangTraLai[] chitietkhachhangtralai;
        Entities.PhieuDieuChuyenKhoNoiBo[] phieudieuchuyenkhonoibo;
        Entities.ChiTietPhieuDieuChuyenKho[] chitietphieudieuchuyenkho;
        Entities.PhieuThu[] phieuthu;
        Entities.PhieuTTCuaKH[] phieuttcuakh;
        Entities.ChiTietPhieuTTCuaKH[] chitietphieuttcuakh;
        Entities.PhieuTTNCC[] phieuttncc;
        Entities.ChiTietPhieuTTNCC[] chitietphieuttncc;
        Entities.HangHoa[] hanghoa;
        Entities.NhomHang[] nhomhang;
        void SelectData()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("TimKiemChungTu");
            clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
            selectall = (Entities.SelectAll)cl.DeserializeHepper(clientstrem, selectall);
            phieuxuathuy = selectall.PhieuXuatHuy;
            chitietxuathuy = selectall.ChiTietXuatHuy;
            hdbanhang = selectall.HDBanHang;
            chitiethdbanhang = selectall.ChiTietHDBanHang;
            tralaincc = selectall.TraLaiNCC;
            chitiettralaincc = selectall.ChiTietTraLaiNhaCungCap;
            hoadonnhap = selectall.HoaDonNhap;
            chitiethoadonnhap = selectall.ChiTietHoaDonNhap;
            khachhangtralai = selectall.KhachHangTraLai;
            chitietkhachhangtralai = selectall.ChiTietKhachHangTraLai;
            phieudieuchuyenkhonoibo = selectall.PhieuDieuChuyenKhoNoiBo;
            chitietphieudieuchuyenkho = selectall.ChiTietPhieuDieuChuyenKho;
            phieuthu = selectall.PhieuThu;
            phieuttcuakh = selectall.PhieuTTCuaKH;
            chitietphieuttcuakh = selectall.ChiTietPhieuTTCuaKH;
            phieuttncc = selectall.PhieuTTNCC;
            chitietphieuttncc = selectall.ChiTietPhieuTTNCC;
            hanghoa = selectall.HangHoa;
            nhomhang = selectall.NhomHang;
            tralaincc = selectall.TraLaiNCC;
            chitiettralaincc = selectall.ChiTietTraLaiNhaCungCap;

        }
        public void fixChiTiet()
        {
            dtgvChiTiet.RowHeadersVisible = false;
            for (int j = 0; j < dtgvChiTiet.ColumnCount; j++)
            {
                dtgvChiTiet.Columns[j].Visible = false;
            }
            dtgvChiTiet.ReadOnly = true;
            dtgvChiTiet.Columns["MaHang"].Visible = true;
            dtgvChiTiet.Columns["MaHang"].HeaderText = "Mã Hàng Hóa";
            dtgvChiTiet.Columns["TenHang"].Visible = true;
            dtgvChiTiet.Columns["TenHang"].HeaderText = "Tên Hàng Hóa";
            dtgvChiTiet.Columns["SoLuong"].Visible = true;
            dtgvChiTiet.Columns["SoLuong"].HeaderText = "Số Lượng";
            dtgvChiTiet.Columns["DonGia"].Visible = true;
            dtgvChiTiet.Columns["DonGia"].HeaderText = "Đơn Giá";
            dtgvChiTiet.Columns["ThanhTien"].Visible = true;
            dtgvChiTiet.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            dtgvChiTiet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvChiTiet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvChiTiet.AllowUserToAddRows = false;
            dtgvChiTiet.AllowUserToDeleteRows = false;
            dtgvChiTiet.AllowUserToResizeRows = false;
        }
        public void fixHienThi()
        {
            dtgvHienThi.RowHeadersVisible = false;
            for (int j = 0; j < dtgvHienThi.ColumnCount; j++)
            {
                dtgvHienThi.Columns[j].Visible = false;
            }
            dtgvHienThi.ReadOnly = true;
            dtgvHienThi.Columns["MaChungTu"].Visible = true;
            dtgvHienThi.Columns["MaChungTu"].HeaderText = "Mã Chứng Từ";
            dtgvHienThi.Columns["TenChungTu"].Visible = true;
            dtgvHienThi.Columns["TenChungTu"].HeaderText = "Tên Chứng Từ";
            dtgvHienThi.Columns["NgayLap"].Visible = true;
            dtgvHienThi.Columns["NgayLap"].HeaderText = "Ngày Lập";
            dtgvHienThi.Columns["GhiChu"].Visible = true;
            dtgvHienThi.Columns["GhiChu"].HeaderText = "Ghi Chú";
            dtgvHienThi.Columns["TongTien"].Visible = true;
            dtgvHienThi.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dtgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvHienThi.AllowUserToAddRows = false;
            dtgvHienThi.AllowUserToDeleteRows = false;
            dtgvHienThi.AllowUserToResizeRows = false;

        }

        string batdau = "";
        string ketthuc = "";
        DateTime truoc;
        DateTime sau;
        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                frmLocDieuKien a = new frmLocDieuKien();
                a.ShowDialog();
                if (frmLocDieuKien.truoc != "" && frmLocDieuKien.sau != "")
                {
                    this.batdau = frmLocDieuKien.truoc;
                    this.ketthuc = frmLocDieuKien.sau;
                    truoc = Convert.ToDateTime(batdau);
                    sau = Convert.ToDateTime(ketthuc);
                    frmLocDieuKien.truoc = frmLocDieuKien.sau = "";
                    label1.Text = "Tìm Kiếm Chứng Từ " + new Common.Utilities().XuLy(2, truoc.ToShortDateString()) + " đến ngày " + new Common.Utilities().XuLy(2, sau.ToShortDateString());
                }
            }
            catch
            {
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }


        Entities.TimKiemChungTu[] hienthi;
        Entities.TimKiemChungTu[] chitiet;
        public void HienThi()
        {
            try
            {
                hienthi = new Entities.TimKiemChungTu[phieuxuathuy.Length + hdbanhang.Length + hoadonnhap.Length + tralaincc.Length +
                    khachhangtralai.Length + phieudieuchuyenkhonoibo.Length + phieuthu.Length + phieuttcuakh.Length + phieuttncc.Length];
                chitiet = new Entities.TimKiemChungTu[chitietxuathuy.Length + chitiethdbanhang.Length + chitiethoadonnhap.Length +
                    chitiettralaincc.Length + chitietkhachhangtralai.Length + chitietphieudieuchuyenkho.Length];
                int soluongchitiet = 0;
                int soluonghienthi = 0;
                string machungtu, mahanghoa, tenhanghoa, manhomhang, tennhomhang, soluong, dongia, ghichu;
                DateTime ngaylap;
                double thanhtien, tongtien;
                bool kt = false;
                // phiếu xuất hủy
                foreach (Entities.PhieuXuatHuy item in phieuxuathuy)
                {
                    machungtu = item.MaPhieuXuatHuy;
                    ngaylap = item.NgayLap;
                    ghichu = item.GhiChu;
                    tongtien = double.Parse(item.Tongtien);
                    if (ngaylap.Date >= truoc.Date && ngaylap.Date <= sau.Date)
                    {
                        foreach (Entities.ChiTietXuatHuy item1 in chitietxuathuy)
                        {
                            if (item.MaPhieuXuatHuy == item1.MaPhieuXuatHuy)
                            {
                                foreach (Entities.HangHoa item2 in hanghoa)
                                {
                                    if (item1.MaHangHoa == item2.MaHangHoa)
                                    {
                                        foreach (Entities.NhomHang item3 in nhomhang)
                                        {
                                            if (item2.MaNhomHangHoa == item3.MaNhomHang)
                                            {

                                                mahanghoa = item2.MaHangHoa;
                                                tenhanghoa = item2.TenHangHoa;
                                                manhomhang = item3.MaNhomHang;
                                                tennhomhang = item3.TenNhomHang;
                                                soluong = item1.SoLuong.ToString();
                                                dongia = item2.GiaNhap;
                                                thanhtien = double.Parse(soluong) * double.Parse(dongia);
                                                chitiet[soluongchitiet] = new Entities.TimKiemChungTu(machungtu, "Phiếu Xuất Hủy", mahanghoa, tenhanghoa, manhomhang, tennhomhang, soluong, dongia, ghichu, thanhtien);
                                                soluongchitiet++;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        hienthi[soluonghienthi] = new Entities.TimKiemChungTu(machungtu, "Phiếu Xuất Hủy", ngaylap, ghichu, tongtien);
                        soluonghienthi++;
                    }
                }
                // hóa đơn bán hàng
                foreach (Entities.HDBanHang item in hdbanhang)
                {
                    machungtu = item.MaHDBanHang;
                    ngaylap = item.NgayBan;
                    ghichu = item.GhiChu;
                    tongtien = double.Parse(item.TongTienThanhToan);
                    if (ngaylap.Date >= truoc.Date && ngaylap.Date <= sau.Date)
                    {
                        foreach (Entities.ChiTietHDBanHang item1 in chitiethdbanhang)
                        {
                            if (item.MaHDBanHang == item1.MaHDBanHang)
                            {
                                foreach (Entities.HangHoa item2 in hanghoa)
                                {
                                    if (item1.MaHangHoa == item2.MaHangHoa)
                                    {
                                        foreach (Entities.NhomHang item3 in nhomhang)
                                        {
                                            if (item2.MaNhomHangHoa == item3.MaNhomHang)
                                            {

                                                mahanghoa = item2.MaHangHoa;
                                                tenhanghoa = item2.TenHangHoa;
                                                manhomhang = item3.MaNhomHang;
                                                tennhomhang = item3.TenNhomHang;
                                                soluong = item1.SoLuong.ToString();
                                                if (item.LoaiHoaDon == false)
                                                    dongia = item2.GiaBanBuon;
                                                else
                                                    dongia = item2.GiaBanLe;
                                                thanhtien = double.Parse(soluong) * double.Parse(dongia);
                                                chitiet[soluongchitiet] = new Entities.TimKiemChungTu(machungtu, "Hóa Đơn Bán Hàng", mahanghoa, tenhanghoa, manhomhang, tennhomhang, soluong, dongia, ghichu, thanhtien);
                                                soluongchitiet++;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        hienthi[soluonghienthi] = new Entities.TimKiemChungTu(machungtu, "Hóa Đơn Bán Hàng", ngaylap, ghichu, tongtien);
                        soluonghienthi++;
                    }
                }
                // hóa đơn nhập
                foreach (Entities.HoaDonNhap item in hoadonnhap)
                {
                    machungtu = item.MaHoaDonNhap;
                    ngaylap = item.NgayNhap;
                    ghichu = item.GhiChu;
                    tongtien = double.Parse(item.TongTien);
                    if (ngaylap.Date >= truoc.Date && ngaylap.Date <= sau.Date)
                    {
                        foreach (Entities.ChiTietHoaDonNhap item1 in chitiethoadonnhap)
                        {
                            if (item.MaHoaDonNhap == item1.MaHoaDonNhap)
                            {
                                foreach (Entities.HangHoa item2 in hanghoa)
                                {
                                    if (item1.MaHangHoa == item2.MaHangHoa)
                                    {
                                        foreach (Entities.NhomHang item3 in nhomhang)
                                        {
                                            if (item2.MaNhomHangHoa == item3.MaNhomHang)
                                            {

                                                mahanghoa = item2.MaHangHoa;
                                                tenhanghoa = item2.TenHangHoa;
                                                manhomhang = item3.MaNhomHang;
                                                tennhomhang = item3.TenNhomHang;
                                                soluong = item1.SoLuong.ToString();
                                                dongia = item2.GiaNhap;
                                                thanhtien = double.Parse(soluong) * double.Parse(dongia);
                                                chitiet[soluongchitiet] = new Entities.TimKiemChungTu(machungtu, "Nhập Kho", mahanghoa, tenhanghoa, manhomhang, tennhomhang, soluong, dongia, ghichu, thanhtien);
                                                soluongchitiet++;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        hienthi[soluonghienthi] = new Entities.TimKiemChungTu(machungtu, "Nhập Kho", ngaylap, ghichu, tongtien);
                        soluonghienthi++;
                    }
                }
                // trả lại nhà cung cấp
                foreach (Entities.TraLaiNCC item in tralaincc)
                {
                    machungtu = item.MaHDTraLaiNCC;
                    ngaylap = item.Ngaytra;
                    ghichu = item.GhiChu;
                    tongtien = double.Parse(item.TienBoiThuong);
                    if (ngaylap.Date >= truoc.Date && ngaylap.Date <= sau.Date)
                    {
                        foreach (Entities.ChiTietTraLaiNhaCungCap item1 in chitiettralaincc)
                        {
                            if (item.MaHDTraLaiNCC == item1.MaHDTraLaiNCC)
                            {
                                foreach (Entities.HangHoa item2 in hanghoa)
                                {
                                    if (item1.MaHangHoa == item2.MaHangHoa)
                                    {
                                        foreach (Entities.NhomHang item3 in nhomhang)
                                        {
                                            if (item2.MaNhomHangHoa == item3.MaNhomHang)
                                            {

                                                mahanghoa = item2.MaHangHoa;
                                                tenhanghoa = item2.TenHangHoa;
                                                manhomhang = item3.MaNhomHang;
                                                tennhomhang = item3.TenNhomHang;
                                                soluong = item1.SoLuong.ToString();
                                                dongia = item2.GiaNhap;
                                                thanhtien = double.Parse(soluong) * double.Parse(dongia);
                                                chitiet[soluongchitiet] = new Entities.TimKiemChungTu(machungtu, "Trả Lại Nhà Cung Cấp", mahanghoa, tenhanghoa, manhomhang, tennhomhang, soluong, dongia, ghichu, thanhtien);
                                                soluongchitiet++;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        hienthi[soluonghienthi] = new Entities.TimKiemChungTu(machungtu, "Trả Lại Nhà Cung Cấp", ngaylap, ghichu, tongtien);
                        soluonghienthi++;
                    }
                }
                // khách hàng trả lại
                foreach (Entities.KhachHangTraLai item in khachhangtralai)
                {
                    machungtu = item.MaKhachHangTraLai;
                    ngaylap = item.NgayNhap;
                    ghichu = item.GhiChu;
                    tongtien = double.Parse(item.TienBoiThuong);
                    if (ngaylap.Date >= truoc.Date && ngaylap.Date <= sau.Date)
                    {
                        foreach (Entities.ChiTietKhachHangTraLai item1 in chitietkhachhangtralai)
                        {
                            if (item.MaKhachHangTraLai == item1.MaKhachHangTraLai)
                            {
                                foreach (Entities.HangHoa item2 in hanghoa)
                                {
                                    if (item1.MaHangHoa == item2.MaHangHoa)
                                    {
                                        foreach (Entities.NhomHang item3 in nhomhang)
                                        {
                                            if (item2.MaNhomHangHoa == item3.MaNhomHang)
                                            {

                                                mahanghoa = item2.MaHangHoa;
                                                tenhanghoa = item2.TenHangHoa;
                                                manhomhang = item3.MaNhomHang;
                                                tennhomhang = item3.TenNhomHang;
                                                soluong = item1.SoLuong.ToString();
                                                dongia = item2.GiaBanBuon;
                                                thanhtien = double.Parse(soluong) * double.Parse(dongia);
                                                chitiet[soluongchitiet] = new Entities.TimKiemChungTu(machungtu, "Khách Hàng Trả Lại", mahanghoa, tenhanghoa, manhomhang, tennhomhang, soluong, dongia, ghichu, thanhtien);
                                                soluongchitiet++;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (kt == true)
                        {
                            hienthi[soluonghienthi] = new Entities.TimKiemChungTu(machungtu, "Khách Hàng Trả Lại", ngaylap, ghichu, tongtien);
                            soluonghienthi++;
                        }
                    }
                }
                // phiếu điều chuyển kho nội bộ
                foreach (Entities.PhieuDieuChuyenKhoNoiBo item in phieudieuchuyenkhonoibo)
                {
                    machungtu = item.MaPhieuDieuChuyenKho;
                    ngaylap = item.NgayDieuChuyen;
                    ghichu = item.GhiChu;
                    tongtien = 0;
                    if (ngaylap.Date >= truoc.Date && ngaylap.Date <= sau.Date)
                    {
                        foreach (Entities.ChiTietPhieuDieuChuyenKho item1 in chitietphieudieuchuyenkho)
                        {
                            if (item.MaPhieuDieuChuyenKho == item1.MaPhieuDieuChuyenKho)
                            {
                                foreach (Entities.HangHoa item2 in hanghoa)
                                {
                                    if (item1.MaHangHoa == item2.MaHangHoa)
                                    {
                                        foreach (Entities.NhomHang item3 in nhomhang)
                                        {
                                            if (item2.MaNhomHangHoa == item3.MaNhomHang)
                                            {

                                                mahanghoa = item2.MaHangHoa;
                                                tenhanghoa = item2.TenHangHoa;
                                                manhomhang = item3.MaNhomHang;
                                                tennhomhang = item3.TenNhomHang;
                                                soluong = item1.SoLuong.ToString();
                                                dongia = item2.GiaNhap;
                                                thanhtien = double.Parse(soluong) * double.Parse(dongia);
                                                tongtien += thanhtien;
                                                chitiet[soluongchitiet] = new Entities.TimKiemChungTu(machungtu, "Phiếu Điều Chuyển Kho Nội Bộ", mahanghoa, tenhanghoa, manhomhang, tennhomhang, soluong, dongia, ghichu, thanhtien);
                                                soluongchitiet++;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                            hienthi[soluonghienthi] = new Entities.TimKiemChungTu(machungtu, "Phiếu Điều Chuyển Kho Nội Bộ", ngaylap, ghichu, tongtien);
                            soluonghienthi++;
                    }
                }
                // phiếu thu
                foreach (Entities.PhieuThu item in phieuthu)
                {
                    machungtu = item.MaPhieuThu;
                    ngaylap = item.NgayLap;
                    ghichu = item.GhiChu;
                    tongtien = double.Parse(item.TongTienThanhToan);
                    if (ngaylap.Date >= truoc.Date && ngaylap.Date <= sau.Date)
                    {
                        if (item.LoaiPhieu == "Thu")
                            hienthi[soluonghienthi] = new Entities.TimKiemChungTu(machungtu, "Phiếu Thu", ngaylap, ghichu, tongtien);
                        else
                            hienthi[soluonghienthi] = new Entities.TimKiemChungTu(machungtu, "Phiếu Chi", ngaylap, ghichu, tongtien);
                        soluonghienthi++;
                    }
                }
                // phiếu thanh toán của khách hàng
                foreach (Entities.PhieuTTCuaKH item in phieuttcuakh)
                {
                    machungtu = item.MaPhieuTTCuaKH;
                    ngaylap = item.NgayLap;
                    ghichu = item.GhiChu;
                    tongtien = 0;
                    if (ngaylap.Date >= truoc.Date && ngaylap.Date <= sau.Date)
                    {
                        foreach (Entities.ChiTietPhieuTTCuaKH item1 in chitietphieuttcuakh)
                        {
                            if (item.MaPhieuTTCuaKH == item1.MaPhieuTTCuaKH)
                                tongtien += double.Parse(item1.ThanhToan.ToString());
                        }

                        hienthi[soluonghienthi] = new Entities.TimKiemChungTu(machungtu, "Phiếu Thanh Toán Của Khách Hàng", ngaylap, ghichu, tongtien);
                        soluonghienthi++;
                    }
                }
                // phiếu thanh toán của nhà cung cấp
                foreach (Entities.PhieuTTNCC item in phieuttncc)
                {
                    machungtu = item.MaPhieuTTNCC;
                    ngaylap = item.NgayLap;
                    ghichu = item.GhiChu;
                    tongtien = 0;
                    if (ngaylap.Date >= truoc.Date && ngaylap.Date <= sau.Date)
                    {
                        foreach (Entities.ChiTietPhieuTTNCC item1 in chitietphieuttncc)
                        {
                            if (item.MaPhieuTTNCC == item1.MaPhieuTTNCC)
                                tongtien += double.Parse(item1.ThanhToan.ToString());
                        }

                        hienthi[soluonghienthi] = new Entities.TimKiemChungTu(machungtu, "Phiếu Thanh Toán Nhà Cung Cấp", ngaylap, ghichu, tongtien);
                        soluonghienthi++;
                    }
                }
                if (soluongchitiet != 0)
                {
                    soluongchitiet = 0;
                    Entities.TimKiemChungTu[] temp = new Entities.TimKiemChungTu[chitiet.Length];
                    foreach (Entities.TimKiemChungTu item in chitiet)
                    {
                        if (item != null)
                        {
                            temp[soluongchitiet] = item;
                            soluongchitiet++;
                        }
                    }
                    chitiet = new Entities.TimKiemChungTu[soluongchitiet];
                    soluongchitiet = 0;
                    foreach (Entities.TimKiemChungTu item in temp)
                    {
                        if (soluongchitiet < chitiet.Length)
                        {
                            chitiet[soluongchitiet] = item;
                            soluongchitiet++;
                        }
                    }
                }
                else
                    chitiet = new Entities.TimKiemChungTu[0];
                if (soluonghienthi != 0)
                {
                    soluonghienthi = 0;
                    Entities.TimKiemChungTu[] temp = new Entities.TimKiemChungTu[hienthi.Length];
                    foreach (Entities.TimKiemChungTu item in hienthi)
                    {
                        if (item != null)
                        {
                            temp[soluonghienthi] = item;
                            soluonghienthi++;
                        }
                    }
                    hienthi = new Entities.TimKiemChungTu[soluonghienthi];
                    soluonghienthi = 0;
                    foreach (Entities.TimKiemChungTu item in temp)
                    {
                        if (soluonghienthi < hienthi.Length)
                        {
                            hienthi[soluonghienthi] = item;
                            soluonghienthi++;
                        }
                    }
                }
                else
                    hienthi = new Entities.TimKiemChungTu[0];
                dtgvHienThi.DataSource = hienthi;

                fixHienThi();
            }
            catch
            {
            }
        }

        private void frmTimKiemChungTu_Load(object sender, EventArgs e)
        {
            try
            {
                truoc = DateServer.Date();
                sau = DateServer.Date();
                HienThi();
                fixChiTiet();
                fixHienThi();
                label1.Text = "Tìm Kiếm Chứng Từ " + new Common.Utilities().XuLy(2, truoc.ToShortDateString()) + " đến ngày " + new Common.Utilities().XuLy(2, sau.ToShortDateString());
            }
            catch
            {
            }
        }

        private void frmTimKiemChungTu_Resize(object sender, EventArgs e)
        {
        }
        int i = 0;
        private void dtgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            if (i < 0)
                return;
            try
            {
                ChiTiet(dtgvHienThi["MaChungTu", i].Value.ToString());
            }
            catch
            {
            }
        }
        public void ChiTiet(string maChungTu)
        {
            try
            {
                int sl = 0;
                Entities.TimKiemChungTu[] temp = new Entities.TimKiemChungTu[chitiet.Length];
                foreach (Entities.TimKiemChungTu item in chitiet)
                {
                    if (item.MaChungTu == maChungTu)
                    {
                        temp[sl] = item;
                        sl++;
                    }
                }
                Entities.TimKiemChungTu[] ht = new Entities.TimKiemChungTu[sl];
                sl = 0;
                foreach (Entities.TimKiemChungTu item in chitiet)
                {
                    if (sl >= ht.Length)
                        break;
                    ht[sl] = temp[sl];
                    sl++;
                }
                dtgvChiTiet.DataSource = ht;
            }
            catch
            {
            }
            finally
            {
                fixChiTiet();
            }
        }
        private void dtgvHienThi_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {

                try
                {
                    i = dtgvHienThi.SelectedRows[0].Index;
                    ChiTiet(dtgvHienThi["MaChungTu", i].Value.ToString());
                }
                catch
                {
                }
            }

        }

        private void btnnhomhang_Click(object sender, EventArgs e)
        {
            try
            {
                frmTimNhomHang a = new frmTimNhomHang();
                a.ShowDialog();
                if (frmTimNhomHang.drvr != null)
                {
                    txtnhomhang.Text = frmTimNhomHang.drvr.Cells["TenNhomHang"].Value.ToString();
                    frmTimNhomHang.drvr = null;
                }
            }
            catch
            {
            }
        }

        private void btnmathang_Click(object sender, EventArgs e)
        {
            try
            {
                frmTimHangHoa a = new frmTimHangHoa();
                a.ShowDialog();
                if (frmTimHangHoa.drvr != null)
                {
                    txtmathang.Text = frmTimHangHoa.drvr.Cells["TenHangHoa"].Value.ToString();
                    frmTimHangHoa.drvr = null;
                }
            }
            catch
            {
            }
        }

        private void btnloaiphieu_Click(object sender, EventArgs e)
        {
            try
            {
                frmTimTenChungTu a = new frmTimTenChungTu();
                a.ShowDialog();
                if (frmTimTenChungTu.drvr != null)
                {
                    txtloaiphieu.Text = frmTimTenChungTu.drvr.Cells["TenCT"].Value.ToString();
                    frmTimTenChungTu.drvr = null;
                }
            }
            catch
            {
            }
        }

        public void TimKiemTheoDieuKien(string maChungTu, string nhomHang, string matHang, string tenChungTu, string ghiChu)
        {
            try
            {
                int kiemtra = 0;
                int soluong = 0;
                Entities.TimKiemChungTu[] temp1 = new Entities.TimKiemChungTu[hienthi.Length];
                soluong = 0;
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (hienthi[i].TenChungTu != null)
                    {
                        kiemtra = hienthi[i].TenChungTu.ToUpper().IndexOf(tenChungTu.ToUpper());
                        if (kiemtra >= 0)
                        {
                            kiemtra = hienthi[i].MaChungTu.ToUpper().IndexOf(maChungTu.ToUpper());
                            if (kiemtra >= 0)
                            {
                                kiemtra = hienthi[i].GhiChu.ToUpper().IndexOf(ghiChu.ToUpper());
                                if (kiemtra >= 0)
                                {
                                    temp1[soluong] = hienthi[i];
                                    soluong++;
                                }
                            }
                        }
                    }
                }
                Entities.TimKiemChungTu[] hienthitheoma = new Entities.TimKiemChungTu[soluong];
                for (int i = 0; i < soluong; i++)
                {
                    hienthitheoma[i] = temp1[i];
                }
                bool kt = false;
                int sl = 0;
                if (txtmathang.Text != "" || txtnhomhang.Text != "")
                {
                    Entities.TimKiemChungTu[] temp = new Entities.TimKiemChungTu[hienthitheoma.Length];
                    for (int i = 0; i < hienthitheoma.Length; i++)
                    {
                        for (int j = 0; j < chitiet.Length; j++)
                        {
                            if (hienthitheoma[i].MaChungTu == chitiet[j].MaChungTu)
                            {
                                if (txtnhomhang.Text != "" && txtmathang.Text != "")
                                {
                                    kiemtra = chitiet[j].TenNhomHang.ToUpper().IndexOf(nhomHang.ToUpper());
                                    if (kiemtra >= 0)
                                    {
                                        kiemtra = chitiet[j].TenHang.ToUpper().IndexOf(matHang.ToUpper());
                                        if (kiemtra >= 0)
                                        {
                                            kt = true;
                                            break;
                                        }
                                    }
                                }
                                else if (txtmathang.Text != "")
                                {
                                    kiemtra = chitiet[j].TenHang.ToUpper().IndexOf(matHang.ToUpper());
                                    if (kiemtra >= 0)
                                    {
                                        kt = true;
                                        break;
                                    }
                                }
                                else if (txtnhomhang.Text != "")
                                {
                                    kiemtra = chitiet[j].TenNhomHang.ToUpper().IndexOf(nhomHang.ToUpper());
                                    if (kiemtra >= 0)
                                    {
                                        kt = true;
                                        break;
                                    }
                                }
                                
                            }
                        }
                        if (kt == true)
                        {
                            temp[sl] = hienthitheoma[i];
                            sl++;
                            kt = false;
                        }
                    }
                    hienthitheoma = new Entities.TimKiemChungTu[sl];

                    for (int i = 0; i < sl; i++)
                    {
                        hienthitheoma[i] = temp[i];
                    }
                }
                baocao = hienthitheoma;
                dtgvHienThi.DataSource = hienthitheoma;
                dtgvChiTiet.DataSource = new Entities.TimKiemChungTu[0];
                if (hienthitheoma.Length > 0)
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
                fixHienThi();
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                HienThi();
                TimKiemTheoDieuKien(txtmachungtu.Text, txtnhomhang.Text, txtmathang.Text, txtloaiphieu.Text, txtGhiChu.Text);
            }
            catch
            {
            }
        }
        Entities.TimKiemChungTu[] baocao;
        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            try
            {
                frmBaoCaorpt a = new frmBaoCaorpt(baocao, truoc, sau);
                a.ShowDialog();
            }
            catch
            {
            }
        }

        private void tsslexcel_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(baocao, truoc, sau, saveFileDialog1.FileName, "Excel");
                }
            }
            catch
            {
            }
            finally { this.Enabled = true; }
            
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(baocao, truoc, sau, saveFileDialog1.FileName, "PDF");
                }
            }
            catch
            {
            }
            finally
            { this.Enabled = true; }

        }

        private void tsslWord_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(baocao, truoc, sau, saveFileDialog1.FileName, "Word");
                }
            }
            catch
            {
            }
            finally
            { this.Enabled = true; }
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                SelectData();
                dtgvChiTiet.DataSource = dtgvHienThi.DataSource = new Entities.TimKiemChungTu[0];
                fixChiTiet();
                fixHienThi();
                this.Focus();
            }
            catch
            {
            }
            finally
            {
                this.Enabled = true;
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
