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
    public partial class frmBCXuatHangTheoThoiGian : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        DateTime datesv = new DateTime(1753, 1, 1);
        public frmBCXuatHangTheoThoiGian()
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

                cbbnam.Text = datesv.Year.ToString();
                cbbthang.Text = datesv.Month.ToString();
                batdau = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), 1).ToString();
                ketthuc = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), DateTime.DaysInMonth(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text))).ToString();
                //batdau = new Common.Utilities().MyDateConversion("01/" + cbbthang.Text + "/" + cbbnam.Text);
                //if (cbbthang.Text == "12")
                //    ketthuc = new Common.Utilities().MyDateConversion("01/01/" + (Convert.ToInt32(cbbnam.Text) + 1).ToString());
                //else
                //    ketthuc = new Common.Utilities().MyDateConversion("01/" + (Convert.ToInt32(cbbthang.Text) + 1).ToString() + "/" + cbbnam.Text);
                truoc = Convert.ToDateTime(batdau);
                sau = Convert.ToDateTime(ketthuc);

                nam = datesv.Year;
                thang = datesv.Month;
                cbbthang.Text = thang.ToString();
                cbbnam.Text = nam.ToString();
                //Xuất hủy
                PhieuXuatHuy();
                ChiTietXuatHuy();
                //Hóa đơn bán hàng
                HDBanHang1();
                ChiTietHDBanHang();
                //Trả lại nhà cung cấp
                TraLaiNCC();
                ChiTietTraLaiNCC();

                HangHoa1();
                GoiHang();
                ChiTietGoiHang();

                TongTienNhanVien();
            }
            catch
            {
            }
        }
        string batdau = "";
        string ketthuc = "";
        DateTime truoc;
        DateTime sau;
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
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
                    lbtenbaocao.Text = "Báo Cáo Xuất Hàng Từ Ngày " + new Common.Utilities().XuLy(2, truoc.ToShortDateString()) + " Đến Ngày " + new Common.Utilities().XuLy(2, sau.ToShortDateString());
                    
                    TongTienNhanVien();
                    LayChiTiet_HangHoaXuat_TheoNhomHang();
                    frmLocDieuKien.truoc = frmLocDieuKien.sau = "";
                }
            }
            catch
            {
            }
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

        private void panel1_DoubleClick(object sender, EventArgs e)
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
            if (dtgvHienThi.RowCount <= 0)
            {
                return false;
            }
            //string date;
            //try
            //{
            //    date = new Common.Utilities().MyDateConversion(mskBatDau.Text);
            //    Convert.ToDateTime(date);
            //}
            //catch
            //{
            //    MessageBox.Show("Bạn nhập sai định dạng Từ ngày", "Hệ thống cánh bảo");
            //    mskBatDau.Focus();
            //    return false;
            //} string date1;
            //try
            //{
            //    date1 = new Common.Utilities().MyDateConversion(mskKetThuc.Text);
            //    Convert.ToDateTime(date1);
            //}
            //catch
            //{
            //    MessageBox.Show("Bạn nhập sai định dạng Đến ngày", "Hệ thống cánh bảo");
            //    mskKetThuc.Focus();
            //    return false;
            //}
            //if (Convert.ToDateTime(date) > Convert.ToDateTime(date1))
            //{
            //    MessageBox.Show("Ngày Kết thúc phải lớn hơn ngày Bắt đầu", "Hệ thống cảnh báo");
            //    mskKetThuc.Focus();
            //    return false;
            //}
            return true;
        }


        #region Lấy Chi Tiết Hàng Hóa trong 1 Nhóm Hàng
        Entities.BCNhapHangTheoThoiGian[] temp;
        public void LayChiTiet_HangHoaXuat_TheoNhomHang()
        {
            try
            {
                int sl = 0;

                temp = new Entities.BCNhapHangTheoThoiGian[hienthi.Length];
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (hienthi[i].SoLuong != 0)
                    {
                        temp[sl] = hienthi[i];
                        sl++;
                    }
                }
                Entities.BCNhapHangTheoThoiGian[] baocao = new Entities.BCNhapHangTheoThoiGian[sl];
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

        Entities.BCNhapHangTheoThoiGian[] hienthi;
        Entities.BCNhapHangTheoThoiGianChiTiet[] hienthibaocao;

        int nam = 0;
        int thang = 0;
        public void TongTienNhanVien()
        {
            try
            {
                List<Entities.BCNhapHangTheoThoiGian> l = new List<Entities.BCNhapHangTheoThoiGian>();
                List<Entities.BCNhapHangTheoThoiGianChiTiet> lhienthi = new List<Entities.BCNhapHangTheoThoiGianChiTiet>();

                foreach (Entities.HangHoa hh in this.hanghoa)
                {
                    int tongxuat = 0;

                    //Xuất Hủy
                    foreach (Entities.PhieuXuatHuy item in this.phieuxuathuy)
                    {
                        DateTime tem = item.NgayLap;
                        if ((tem >= truoc) && (tem <= sau) && (item.TrangThai == true))
                        {
                            foreach (Entities.ChiTietXuatHuy item1 in this.chitietxuathuy)
                            {
                                if (item1.MaPhieuXuatHuy.Equals(item.MaPhieuXuatHuy) && (item1.MaHangHoa.Equals(hh.MaHangHoa)))
                                {
                                    tongxuat += item1.SoLuong;
                                    lhienthi.Add(new Entities.BCNhapHangTheoThoiGianChiTiet(item.MaPhieuXuatHuy,"Phiếu xuất hủy",item.NgayLap,hh.MaHangHoa,hh.TenHangHoa,item1.SoLuong));
                                }
                            }
                        }
                    }
                    //Hóa đơn bán hàng
                    foreach (Entities.HDBanHang item in this.hdbanhang)
                    {
                        DateTime tem = item.NgayBan;
                        if ((tem >= truoc) && (tem <= sau))
                        {
                            foreach (Entities.ChiTietHDBanHang item1 in this.chitiethdbanhang)
                            {
                                if (item1.MaHDBanHang.Equals(item.MaHDBanHang))
                                {
                                    bool runBC = false;
                                    int tongxuatBC = 0;
                                    if (GoiHangOrHangHoa(item1.MaHangHoa))
                                    {//là gói hàng
                                        foreach (Entities.GoiHang gh in this.goihang)
                                        {
                                            foreach (Entities.ChiTietGoiHang ctgh in this.chitietgoihang)
                                            {
                                                if (gh.MaGoiHang.Equals(ctgh.MaGoiHang) && (item1.MaHangHoa.Equals(ctgh.MaGoiHang)))
                                                {
                                                    if (ctgh.MaHangHoa.Equals(hh.MaHangHoa))
                                                    {
                                                        tongxuat += item1.SoLuong * ctgh.SoLuong;
                                                        tongxuatBC += item1.SoLuong * ctgh.SoLuong;
                                                        runBC = true;
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
                                            tongxuatBC += item1.SoLuong;
                                            runBC = true;
                                        }
                                    }
                                    if (runBC)
                                    {
                                        lhienthi.Add(new Entities.BCNhapHangTheoThoiGianChiTiet(item.MaHDBanHang, "Hóa Đơn Bán Hàng", item.NgayBan, hh.MaHangHoa, hh.TenHangHoa, tongxuatBC));
                                    }
                                }
                            }
                        }
                    }
                    //Trả lại nhà cung cấp
                    foreach (Entities.TraLaiNCC item in this.tralaincc)
                    {
                        DateTime tem = item.Ngaytra;
                        if ((tem >= truoc) && (tem <= sau))
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
                        Entities.BCNhapHangTheoThoiGian bientam = new Entities.BCNhapHangTheoThoiGian();
                        bientam.MaChungTu = hh.MaHangHoa;
                        bientam.TenChungTu = hh.TenHangHoa;
                        bientam.NgayLap = new DateTime(1753, 1, 1);
                        bientam.SoLuong = tongxuat;
                        l.Add(bientam);
                    }
                }

                hienthi = new Entities.BCNhapHangTheoThoiGian[l.Count];

                for (int i = 0; i < l.Count; i++)
                {
                    hienthi[i] = l[i];
                }

                hienthibaocao = new Entities.BCNhapHangTheoThoiGianChiTiet[lhienthi.Count];

                for (int i = 0; i < lhienthi.Count; i++)
                {
                    hienthibaocao[i] = lhienthi[i];
                }

                ///////////////////////////////MRK FIX
                List<Entities.BCNhapHangTheoThoiGian> tem0 = new List<Entities.BCNhapHangTheoThoiGian>();
                int tong0 = 0;
                foreach (Entities.BCNhapHangTheoThoiGian item in hienthi)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    tong0 += item.SoLuong;
                    tem0.Add(item);
                }
                Entities.BCNhapHangTheoThoiGian tem1 = new Entities.BCNhapHangTheoThoiGian();
                tem1.TenChungTu = "Tổng: ";
                tem1.SoLuong = tong0;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = hienthibaocao;
                dtgvHienThi.DataSource = tem0.ToArray();
                FixDatagridview();

                if (tem0.ToArray().Length > 0)
                {
                    enable();
                }
                else
                {
                    disable();
                }

            }
            catch { }
        }

        void enable()
        {
            tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
        }
        void disable()
        {
            tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
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

        public void FixDatagridview()
        {
            dtgvHienThi.Columns["MaChungTu"].HeaderText = "Mã Hàng Hóa";
            dtgvHienThi.Columns["TenChungTu"].HeaderText = "Tên Hàng Hóa";
            dtgvHienThi.Columns["NgayLap"].Visible = false;
            dtgvHienThi.Columns["NgayLap"].HeaderText = "Ngày Xuất";
            dtgvHienThi.Columns["SoLuong"].HeaderText = "Tổng Số Lượng Xuất";

            dtgvHienThi.AllowUserToResizeRows = false;
            dtgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvHienThi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvHienThi.ReadOnly = true;
        }  
      
    
        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            //frmBaoCaorpt frm = new frmBaoCaorpt(temp, BatDau, KetThuc);
            //frm.ShowDialog();
            try
            {
                frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, truoc, sau,"k29vn");
                a.ShowDialog();
            }
            catch
            {
            }
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, truoc, sau,"k29vn", saveFileDialog1.FileName, "PDF");
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
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, truoc, sau,"k29vn", saveFileDialog1.FileName, "Word");
                }
            }
            catch
            {
            }
            finally
            { this.Enabled = true; }
        }

        private void tsslexcel_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, truoc, sau,"k29vn", saveFileDialog1.FileName, "Excel");
                }
            }
            catch
            {
            }
            finally { this.Enabled = true; }
        }

        private void rdbTatCa_CheckedChanged(object sender, EventArgs e)
        {
           
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

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                if (KiemTra())
                {
                    LayNgay();
                    PhieuXuatHuy();
                    ChiTietXuatHuy();
                    HDBanHang1();
                    ChiTietHDBanHang();
                    TraLaiNCC();
                    ChiTietTraLaiNCC();

                    HangHoa1();
                    GoiHang();
                    ChiTietGoiHang();
                    TongTienNhanVien();

                    LayChiTiet_HangHoaXuat_TheoNhomHang();

                    ///////////////////////////////MRK FIX
                    List<Entities.BCNhapHangTheoThoiGian> tem0 = new List<Entities.BCNhapHangTheoThoiGian>();
                    int tong0 = 0;
                    foreach (Entities.BCNhapHangTheoThoiGian item in temp)
                    {
                        tong0 += item.SoLuong;
                        tem0.Add(item);
                    }
                    Entities.BCNhapHangTheoThoiGian tem1 = new Entities.BCNhapHangTheoThoiGian();
                    tem1.TenChungTu = "Tổng: ";
                    tem1.SoLuong = tong0;
                    tem0.Add(tem1);
                    //////////////////////////////////////
                    //dtgvhienthi.DataSource = temp;
                    dtgvHienThi.DataSource = tem0.ToArray();

                    FixDatagridview();

                }
            }
            catch
            {
            }
            finally
            {
                this.Enabled = true;
                this.Focus();
            }
        }
    }
}
