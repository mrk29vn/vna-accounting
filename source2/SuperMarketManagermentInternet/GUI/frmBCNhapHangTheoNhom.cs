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
    public partial class frmBCNhapHangTheoNhom : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        int nam = 0;
        int thang = 0;
        DateTime datesv;
        public frmBCNhapHangTheoNhom()
        {
            try
            {
                InitializeComponent();

                datesv = DateServer.Date();
                nam = datesv.Year;
                thang = datesv.Month;
                cbbthang.Text = thang.ToString();
                cbbnam.Text = nam.ToString();

                //DateTime a = DateTime.Now;
                BCNhapHangTheoNhomHang();
                //DateTime b = DateTime.Now;
                //double c = (b - a).TotalMilliseconds;   //498.0285  415.0238    449.0256

                //DateTime aa = DateTime.Now;
                TinhToan();
                //DateTime bb = DateTime.Now;
                //double cc = (bb - aa).TotalMilliseconds;   //177.0102

                //HoaDonNhap();
                //ChiTietHoaDonNhap();
                //PhieuDieuChuyenKhoNoiBo();
                //ChiTietPhieuDieuChuyenKho();
                //KhachHangTraLai();
                //ChiTietKhachHangTraLai();
                //HangHoa();
                //NhomHang();
                //GoiHang();
                //ChiTietGoiHang();

                //TongTienNhanVien();
            }
            catch { }
        }

        List<Entities.BCNhapHangTheoNhom> HIENTHI = new List<Entities.BCNhapHangTheoNhom>();
        List<Entities.BCNhapHangTheoNhomChiTiet> HIENTHIBAOCAO = new List<Entities.BCNhapHangTheoNhomChiTiet>();
        
        private void TinhToan()
        {
            try
            {
                HIENTHI = new List<Entities.BCNhapHangTheoNhom>();
                HIENTHIBAOCAO = new List<Entities.BCNhapHangTheoNhomChiTiet>();

                double TONG = 0;
                foreach (Entities.NhomHang nhomhang in DATA.NhomHang)   //Tính toán các nhóm hàng
                {
                    double TongNhomHang = 0;
                    List<Entities.HangHoa> HangHoaTrongNhom = (from k in DATA.HangHoa where k.MaNhomHangHoa.Equals(nhomhang.MaNhomHang) select k).ToList();
                    foreach (Entities.HangHoa hanghoa in HangHoaTrongNhom)  //Duyệt hàng hóa trong nhóm
                    {
                        double TongHangHoa = 0;
                        //Hóa Đơn Nhập
                        foreach (Entities.ChiTietHoaDonNhap cthoadonnhap in DATA.ChiTietHoaDonNhap)
                        {
                            if ((cthoadonnhap.NgayNhap.Month == thang) && (cthoadonnhap.NgayNhap.Year == nam) && (cthoadonnhap.MaHangHoa.Equals(hanghoa.MaHangHoa)))    //lọc hóa đơn nhập với TIME
                            {
                                TongNhomHang += cthoadonnhap.SoLuong;
                                TongHangHoa += cthoadonnhap.SoLuong;
                            }
                        }
                        //Khách Hàng Trả Lại
                        foreach (Entities.ChiTietKhachHangTraLai ctkhachhangtralai in DATA.ChiTietKhachHangTraLai)
                        {
                            if ((ctkhachhangtralai.NgayNhap.Month == thang) && (ctkhachhangtralai.NgayNhap.Year == nam))
                            {
                                if (ctkhachhangtralai.MaHangHoa.Equals(hanghoa.MaHangHoa))
                                {
                                    TongNhomHang += ctkhachhangtralai.SoLuong;
                                    TongHangHoa += ctkhachhangtralai.SoLuong;
                                }
                                else
                                {
                                    string check = Convert.ToString(from k in DATA.GoiHang where k.MaGoiHang.Equals(ctkhachhangtralai.MaHangHoa) select k.MaGoiHang);
                                    if (!string.IsNullOrEmpty(check))
                                    {
                                        var chitiet = from k in DATA.ChiTietGoiHang where (k.MaGoiHang.Equals(ctkhachhangtralai.MaHangHoa) && k.MaHangHoa.Equals(hanghoa.MaHangHoa)) select k;
                                        foreach (Entities.ChiTietGoiHang ctgh in chitiet)
                                        {
                                            TongNhomHang += ctkhachhangtralai.SoLuong * ctgh.SoLuong;
                                            TongHangHoa += ctkhachhangtralai.SoLuong * ctgh.SoLuong;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        if (TongHangHoa != 0)
                        {
                            HIENTHIBAOCAO.Add(new Entities.BCNhapHangTheoNhomChiTiet(nhomhang.MaNhomHang, nhomhang.TenNhomHang, hanghoa.MaHangHoa, hanghoa.TenHangHoa, TongHangHoa));
                        }
                    }
                    if (TongNhomHang != 0)
                    {
                        HIENTHI.Add(new Entities.BCNhapHangTheoNhom("", nhomhang.MaNhomHang, nhomhang.TenNhomHang, TongNhomHang.ToString()));
                        TONG += TongNhomHang;
                    }
                }
                dtgvhienthi.DataSource = HIENTHI.ToArray();
                label3.Text = "Tổng: " + TONG.ToString();
                fix();
            }
            catch { }
        }

        Entities.BCNhapHangTheoNhomHang DATA = new Entities.BCNhapHangTheoNhomHang();
        public void BCNhapHangTheoNhomHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "Select_sp_BCNhapHangTheoNhomHangFIX", null);
                DATA = (Entities.BCNhapHangTheoNhomHang)cl.DeserializeHepper(clientstrem, DATA);
                if (DATA == null) { return; }
            }
            catch { }
        }

        #region temp
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
            catch { }
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
            catch { }
        }
        ////////////////////////////////////////////
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
            catch { }
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
            catch { }
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
            catch { }
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
            catch { }
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
            catch { }
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
            catch { }
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
            catch { }
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
            catch { }
        }
        #endregion

        Entities.BCNhapHangTheoNhom[] hienthi;
        Entities.BCNhapHangTheoNhomChiTiet[] hienthibaocao;
        public void TongTienNhanVien()
        {
            try
            {
                nam = int.Parse(cbbnam.Text);
                thang = int.Parse(cbbthang.Text);
                double tongnhap, nhap;
                int sotang = 0;
                hienthi = new Entities.BCNhapHangTheoNhom[nhomhang.Length];
                for (int i = 0; i < nhomhang.Length; i++)
                {
                    for (int k = 0; k < hanghoa.Length; k++)
                    {
                        if (hanghoa[k].MaNhomHangHoa == nhomhang[i].MaNhomHang)
                        {
                            sotang++;
                        }
                    }
                }

                hienthibaocao = new Entities.BCNhapHangTheoNhomChiTiet[sotang];
                sotang = 0;
                for (int i = 0; i < nhomhang.Length; i++)
                {
                    tongnhap = 0;
                    for (int k = 0; k < hanghoa.Length; k++)
                    {
                        nhap = 0;
                        if (hanghoa[k].MaNhomHangHoa == nhomhang[i].MaNhomHang)
                        {
                            // nhập hàng - hóa đơn nhập
                            for (int l = 0; l < hoadonnhap.Length; l++)
                            {
                                for (int o = 0; o < chitiethoadonnhap.Length; o++)
                                {
                                    int namphieu = hoadonnhap[l].NgayNhap.Year;
                                    int thangphieu = hoadonnhap[l].NgayNhap.Month;

                                    if (chitiethoadonnhap[o].MaHoaDonNhap == hoadonnhap[l].MaHoaDonNhap && nam == namphieu && thang == thangphieu)
                                    {
                                        if (chitiethoadonnhap[o].MaHangHoa == hanghoa[k].MaHangHoa)
                                        {
                                            tongnhap += chitiethoadonnhap[o].SoLuong;
                                            nhap += chitiethoadonnhap[o].SoLuong;
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
                                    if (chitietkhachhangtralai[o].MaKhachHangTraLai == khachhangtralai[l].MaKhachHangTraLai && nam == namphieu && thang == thangphieu)
                                    {
                                        if (chitietkhachhangtralai[o].MaHangHoa == hanghoa[k].MaHangHoa)
                                        {
                                            tongnhap += chitietkhachhangtralai[o].SoLuong;
                                            nhap += chitietkhachhangtralai[o].SoLuong;
                                        }
                                        ////////////////////////////////////////////////MRK FIX
                                        else
                                        { //là gói hàng
                                            foreach (Entities.GoiHang gh in goihang)
                                            {
                                                foreach (Entities.ChiTietGoiHang ctgh in chitietgoihang)
                                                {
                                                    if (gh.MaGoiHang.Equals(ctgh.MaGoiHang) && ctgh.MaGoiHang.Equals(chitietkhachhangtralai[o].MaHangHoa) && ctgh.MaHangHoa.Equals(hanghoa[k].MaHangHoa))
                                                    {
                                                        tongnhap += (chitietkhachhangtralai[o].SoLuong * ctgh.SoLuong);
                                                        nhap += (chitietkhachhangtralai[o].SoLuong * ctgh.SoLuong);
                                                    }
                                                }
                                            }
                                        }
                                        ////////////////////////////////////////////////MRK FIX
                                    }
                                }
                            }
                            // nhập hàng - phiếu điều chuyển kho nội bộ
                            for (int l = 0; l < phieudieuchuyenkhonoibo.Length; l++)
                            {
                                for (int o = 0; o < chitietphieudieuchuyenkho.Length; o++)
                                {
                                    int namphieu = phieudieuchuyenkhonoibo[l].NgayDieuChuyen.Year;
                                    int thangphieu = phieudieuchuyenkhonoibo[l].NgayDieuChuyen.Month;
                                    if (chitietphieudieuchuyenkho[o].MaPhieuDieuChuyenKho == phieudieuchuyenkhonoibo[l].MaPhieuDieuChuyenKho && nam == namphieu && thang == thangphieu)
                                    {
                                        if (chitietphieudieuchuyenkho[o].MaHangHoa == hanghoa[k].MaHangHoa)
                                        {
                                            tongnhap += chitietphieudieuchuyenkho[o].SoLuong;
                                            nhap += chitietphieudieuchuyenkho[o].SoLuong;
                                        }
                                        ////////////////////////////////////////////////MRK FIX
                                        else
                                        { //là gói hàng
                                            foreach (Entities.GoiHang gh in goihang)
                                            {
                                                foreach (Entities.ChiTietGoiHang ctgh in chitietgoihang)
                                                {
                                                    if (gh.MaGoiHang.Equals(ctgh.MaGoiHang) && ctgh.MaGoiHang.Equals(chitietphieudieuchuyenkho[o].MaHangHoa) && ctgh.MaHangHoa.Equals(hanghoa[k].MaHangHoa))
                                                    {
                                                        tongnhap += (chitietphieudieuchuyenkho[o].SoLuong * ctgh.SoLuong);
                                                        nhap += (chitietphieudieuchuyenkho[o].SoLuong * ctgh.SoLuong);
                                                    }
                                                }
                                            }
                                        }
                                        ////////////////////////////////////////////////MRK FIX
                                    }
                                }
                            }
                            hienthibaocao[sotang] = new Entities.BCNhapHangTheoNhomChiTiet(nhomhang[i].MaNhomHang, nhomhang[i].TenNhomHang, hanghoa[k].MaHangHoa, hanghoa[k].TenHangHoa, nhap);
                            sotang++;
                        }
                    }
                    hienthi[i] = new Entities.BCNhapHangTheoNhom("", nhomhang[i].MaNhomHang, nhomhang[i].TenNhomHang, tongnhap.ToString());
                }
                Entities.BCNhapHangTheoNhom[] temp = new Entities.BCNhapHangTheoNhom[hienthi.Length];
                int soluong = 0;
                for (int i = 0; i < hienthi.Length; i++)
                {
                    if (hienthi[i].TongNhap != "0")
                    {
                        temp[soluong] = hienthi[i];
                        soluong++;
                    }
                }
                hienthi = new Entities.BCNhapHangTheoNhom[soluong];
                for (int i = 0; i < soluong; i++)
                {
                    hienthi[i] = temp[i];
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCNhapHangTheoNhom> tem0 = new List<Entities.BCNhapHangTheoNhom>();
                double tong0 = 0;
                foreach (Entities.BCNhapHangTheoNhom item in hienthi)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    tong0 += double.Parse(item.TongNhap);
                    tem0.Add(item);
                }
                Entities.BCNhapHangTheoNhom tem1 = new Entities.BCNhapHangTheoNhom();
                tem1.TenNhomHang = "Tổng: ";
                tem1.TongNhap = tong0.ToString();
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
            catch { }
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
            dtgvhienthi.Columns["MaNhomHang"].HeaderText = "Mã Nhóm Hàng";
            dtgvhienthi.Columns["TenNhomHang"].HeaderText = "Tên Nhóm Hàng";
            dtgvhienthi.Columns["TongNhap"].HeaderText = "Tổng Nhập";
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

        public Entities.BCNhapHangTheoNhomChiTiet[] ChiTietKho(string makho)
        {
            try
            {
                int sl = 0;
                Entities.BCNhapHangTheoNhomChiTiet[] temp = new Entities.BCNhapHangTheoNhomChiTiet[hienthibaocao.Length];
                for (int i = 0; i < hienthibaocao.Length; i++)
                {
                    if (hienthibaocao[i].MaNhomHang == makho)
                    {
                        if (hienthibaocao[i].SoLuong > 0)
                        {
                            temp[sl] = hienthibaocao[i];
                            sl++;
                        }
                    }
                }
                 Entities.BCNhapHangTheoNhomChiTiet[] baocao = new Entities.BCNhapHangTheoNhomChiTiet[sl];
                for (int i = 0; i < sl; i++)
                {
                    baocao[i] = temp[i];
                }
                return baocao;
            }
            catch
            {
                return new Entities.BCNhapHangTheoNhomChiTiet[0];
            }
        }

        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Enabled = false;
            //if (i < 0)
            //    return;
            try
            {
                Entities.BCNhapHangTheoNhom[] data = (Entities.BCNhapHangTheoNhom[])dtgvhienthi.DataSource;
                if (data == null)
                {
                    return;
                }
                else if (data.Length == 0)
                {
                    return;
                }
                //Xem
                string MaNhomHang = dtgvhienthi["MaNhomHang", i].Value.ToString();
                List<Entities.BCNhapHangTheoNhomChiTiet> L = (from k in HIENTHIBAOCAO where k.MaNhomHang.Equals(MaNhomHang) select k).ToList();
                frmBaoCaorpt a = new frmBaoCaorpt(L.ToArray(), thang.ToString(), nam.ToString());
                a.ShowDialog();
            }
            catch { }
            finally
            {
                this.Enabled = true;
            }
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            //if (i < 0)
            //    return;
            try
            {
                Entities.BCNhapHangTheoNhom[] data = (Entities.BCNhapHangTheoNhom[])dtgvhienthi.DataSource;
                if (data == null)
                {
                    return;
                }
                else if (data.Length == 0)
                {
                    return;
                }
                //Xem
                string MaNhomHang = dtgvhienthi["MaNhomHang", i].Value.ToString();
                List<Entities.BCNhapHangTheoNhomChiTiet> L = (from k in HIENTHIBAOCAO where k.MaNhomHang.Equals(MaNhomHang) select k).ToList();
                frmBaoCaorpt a = new frmBaoCaorpt(L.ToArray(), thang.ToString(), nam.ToString());
                a.ShowDialog();
            }
            catch { }
            finally
            {
                this.Enabled = true;
            }
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                try
                {
                    nam = int.Parse(cbbnam.Text);
                    thang = int.Parse(cbbthang.Text);

                    TinhToan();
                    //TongTienNhanVien();
                    this.Text = "Báo Cáo Nhập Theo Nhóm " + cbbthang.Text + "/" + cbbnam.Text;
                }
                catch { }
                this.Enabled = true;
            }
            catch { }
        }

        private void frmBCXuatNhapTonTheoKho_Load(object sender, EventArgs e)
        {
            this.Text = "Báo Cáo Nhập Theo Nhóm " + cbbthang.Text + "/" + cbbnam.Text;
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                //if (i < 0)
                //    return;
                Entities.BCNhapHangTheoNhom[] data = (Entities.BCNhapHangTheoNhom[])dtgvhienthi.DataSource;
                if (data == null)
                {
                    return;
                }
                else if (data.Length == 0)
                {
                    return;
                }
                //PDF
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string MaNhomHang = dtgvhienthi["MaNhomHang", i].Value.ToString();
                    List<Entities.BCNhapHangTheoNhomChiTiet> L = (from k in HIENTHIBAOCAO where k.MaNhomHang.Equals(MaNhomHang) select k).ToList();
                    frmBaoCaorpt a = new frmBaoCaorpt(L.ToArray(), thang.ToString(), nam.ToString(), saveFileDialog1.FileName, "PDF");
                }
            }
            catch { }
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
                //if (i < 0)
                //    return;
                Entities.BCNhapHangTheoNhom[] data = (Entities.BCNhapHangTheoNhom[])dtgvhienthi.DataSource;
                if (data == null)
                {
                    return;
                }
                else if (data.Length == 0)
                {
                    return;
                }
                //DOC
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string MaNhomHang = dtgvhienthi["MaNhomHang", i].Value.ToString();
                    List<Entities.BCNhapHangTheoNhomChiTiet> L = (from k in HIENTHIBAOCAO where k.MaNhomHang.Equals(MaNhomHang) select k).ToList();
                    frmBaoCaorpt a = new frmBaoCaorpt(L.ToArray(), thang.ToString(), nam.ToString(), saveFileDialog1.FileName, "Word");
                }
            }
            catch { }
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
                //if (i < 0)
                //    return;
                Entities.BCNhapHangTheoNhom[] data = (Entities.BCNhapHangTheoNhom[])dtgvhienthi.DataSource;
                if (data == null)
                {
                    return;
                }
                else if (data.Length == 0)
                {
                    return;
                }
                //XLS
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string MaNhomHang = dtgvhienthi["MaNhomHang", i].Value.ToString();
                    List<Entities.BCNhapHangTheoNhomChiTiet> L = (from k in HIENTHIBAOCAO where k.MaNhomHang.Equals(MaNhomHang) select k).ToList();
                    frmBaoCaorpt a = new frmBaoCaorpt(L.ToArray(), thang.ToString(), nam.ToString(), saveFileDialog1.FileName, "Excel");
                }
            }
            catch { }
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
                nam = datesv.Year;
                thang = datesv.Month;
                cbbthang.Text = thang.ToString();
                cbbnam.Text = nam.ToString();

                BCNhapHangTheoNhomHang();
                TinhToan();
                //HoaDonNhap();
                //ChiTietHoaDonNhap();
                //PhieuDieuChuyenKhoNoiBo();
                //ChiTietPhieuDieuChuyenKho();
                //KhachHangTraLai();
                //ChiTietKhachHangTraLai();
                //HangHoa();
                //NhomHang();
                //TongTienNhanVien();
                this.Focus();
            }
            catch { }
            this.Enabled = true;
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string Search = txttimkiem.Text;
                List<Entities.BCNhapHangTheoNhom> ketqua = new List<Entities.BCNhapHangTheoNhom>();
                foreach (Entities.BCNhapHangTheoNhom item in HIENTHI)
                {
                    int test = -1;
                    if (rdbtimkiem1.Checked)    //Tìm Kiếm Theo Mã
                    {
                        test = item.MaNhomHang.ToLower().IndexOf(Search.ToLower());
                    }
                    else if (rdbtimkiem2.Checked)   //Tìm Kiếm Theo Tên
                    {
                        test = item.TenNhomHang.ToLower().IndexOf(Search.ToLower());
                    }
                    if (test >= 0)
                    {
                        ketqua.Add(item);
                    }
                }
                dtgvhienthi.DataSource = ketqua.ToArray();
                fix();
                double TONG = 0;
                foreach (Entities.BCNhapHangTheoNhom item in ketqua)
                {
                    TONG += double.Parse(item.TongNhap);
                }
                label3.Text = "Tổng: " + TONG.ToString();
            }
            catch { }

            //try
            //{
            //    if (rdbtimkiem3.Checked == true)
            //    {
            //        return;
            //    }
            //    if (txttimkiem.Text.Length == 0)
            //    {
            //        dtgvhienthi.DataSource = new Entities.BCNhapHangTheoNhom[0];
            //        return;
            //    }
            //    int soluong = 0;
            //    if (hienthi != null)
            //    {
            //        if (rdbtimkiem1.Checked == true)
            //        {
            //            for (int i = 0; i < hienthi.Length; i++)
            //            {
            //                int kiemtra = hienthi[i].MaNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
            //                if (kiemtra >= 0)
            //                {
            //                    soluong++;
            //                }
            //            }
            //            if (soluong == 0)
            //            {
            //                dtgvhienthi.DataSource = new Entities.BCNhapHangTheoNhom[0];
            //                return;
            //            }
            //            Entities.BCNhapHangTheoNhom[] hienthitheoid = new Entities.BCNhapHangTheoNhom[soluong];
            //            soluong = 0;
            //            for (int i = 0; i < hienthi.Length; i++)
            //            {
            //                int kiemtra = hienthi[i].MaNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
            //                if (kiemtra >= 0)
            //                {
            //                    hienthitheoid[soluong] = hienthi[i];
            //                    soluong++;
            //                }
            //            }
            //            ///////////////////////////////MRK FIX
            //            List<Entities.BCNhapHangTheoNhom> tem0 = new List<Entities.BCNhapHangTheoNhom>();
            //            double tong0 = 0;
            //            foreach (Entities.BCNhapHangTheoNhom item in hienthitheoid)
            //            {
            //                tong0 += double.Parse(item.TongNhap);
            //                tem0.Add(item);
            //            }
            //            Entities.BCNhapHangTheoNhom tem1 = new Entities.BCNhapHangTheoNhom();
            //            tem1.TenNhomHang = "Tổng: ";
            //            tem1.TongNhap = tong0.ToString();
            //            tem0.Add(tem1);
            //            //////////////////////////////////////
            //            //dtgvhienthi.DataSource = hienthitheoid;
            //            dtgvhienthi.DataSource = tem0.ToArray();
            //        }
            //        if (rdbtimkiem2.Checked == true)
            //        {
            //            for (int i = 0; i < hienthi.Length; i++)
            //            {
            //                int kiemtra = hienthi[i].TenNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
            //                if (kiemtra >= 0)
            //                {
            //                    soluong++;
            //                }
            //            }
            //            if (soluong == 0)
            //            {
            //                dtgvhienthi.DataSource = new Entities.BCNhapHangTheoNhom[0];
            //                return;
            //            }
            //            Entities.BCNhapHangTheoNhom[] hienthitheoma = new Entities.BCNhapHangTheoNhom[soluong];
            //            soluong = 0;
            //            for (int i = 0; i < hienthi.Length; i++)
            //            {
            //                int kiemtra = hienthi[i].TenNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
            //                if (kiemtra >= 0)
            //                {
            //                    hienthitheoma[soluong] = hienthi[i];
            //                    soluong++;
            //                }
            //            }
            //            ///////////////////////////////MRK FIX
            //            List<Entities.BCNhapHangTheoNhom> tem0 = new List<Entities.BCNhapHangTheoNhom>();
            //            double tong0 = 0;
            //            foreach (Entities.BCNhapHangTheoNhom item in hienthitheoma)
            //            {
            //                tong0 += double.Parse(item.TongNhap);
            //                tem0.Add(item);
            //            }
            //            Entities.BCNhapHangTheoNhom tem1 = new Entities.BCNhapHangTheoNhom();
            //            tem1.TenNhomHang = "Tổng: ";
            //            tem1.TongNhap = tong0.ToString();
            //            tem0.Add(tem1);
            //            //////////////////////////////////////
            //            //dtgvhienthi.DataSource = hienthitheoma;
            //            dtgvhienthi.DataSource = tem0.ToArray();

            //        }
            //        if (dtgvhienthi.RowCount > 0)
            //        {
            //            tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
            //        }
            //        else
            //        {
            //            tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
            //        }
            //    }
            //}
            //finally
            //{
            //    fix();
            //}
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
