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
    public partial class frmBCNhapHangTheoThoiGian : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        DateTime datesv;
        public frmBCNhapHangTheoThoiGian()
        {
            try
            {
                InitializeComponent();
                datesv = DateServer.Date();
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
                //Hóa đơn nhập
                HoaDonNhap();
                ChiTietHoaDonNhap();
                //điều chuyển kho nội bộ
                PhieuDieuChuyenKhoNoiBo();
                ChiTietPhieuDieuChuyenKho();
                //khách hàng trả lại
                KhachHangTraLai();
                ChiTietKhachHangTraLai();

                HangHoa();
                GoiHang();
                ChiTietGoiHang();
                HienThi();
            }
            catch
            {
            }
        }

        ////////////////////////////////////MRK FIX
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
        ////////////////////////////////////////////

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
                    lbtenbaocao.Text = "Báo Cáo Nhập Hàng Từ Ngày " + new Common.Utilities().XuLy(2, truoc.ToShortDateString()) + " Đến Ngày " + new Common.Utilities().XuLy(2, sau.ToShortDateString());
                    HienThi();
                    frmLocDieuKien.truoc = frmLocDieuKien.sau = "";

                }
            }
            catch
            {
            }
        }
        string batdau = "";
        string ketthuc = "";
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

        List<Entities.BCNhapHangTheoThoiGian> hienthi;
       List<Entities.BCNhapHangTheoThoiGianChiTiet> hienthibaocao;
        public void HienThi()
        {
            try
            {
                hienthi = new List<Entities.BCNhapHangTheoThoiGian>();
                hienthibaocao = new List<Entities.BCNhapHangTheoThoiGianChiTiet>();
                int sotangbaocao = 0;
                int sotanghienthi = 0;
                // hóa đơn nhập
                for (int i = 0; i < hoadonnhap.Length; i++)
                {
                    int soluong = 0;
                    DateTime ngayphieu = hoadonnhap[i].NgayNhap;
                    if (ngayphieu >= truoc && ngayphieu <= sau)
                    {
                        for (int j = 0; j < chitiethoadonnhap.Length; j++)
                        {
                            if (hoadonnhap[i].MaHoaDonNhap == chitiethoadonnhap[j].MaHoaDonNhap)
                            {
                                for (int k = 0; k < hanghoa.Length; k++)
                                {
                                    if (chitiethoadonnhap[j].MaHangHoa == hanghoa[k].MaHangHoa)
                                    {
                                        int sl = chitiethoadonnhap[j].SoLuong;
                                        soluong += sl;
                                        Entities.BCNhapHangTheoThoiGianChiTiet ct = new Entities.BCNhapHangTheoThoiGianChiTiet(hoadonnhap[i].MaHoaDonNhap, "Hóa Đơn Nhập", hoadonnhap[i].NgayNhap, hanghoa[k].MaHangHoa, hanghoa[k].TenHangHoa, sl);
                                        hienthibaocao.Add(ct); 
                                    }
                                }
                            }
                        }
                        Entities.BCNhapHangTheoThoiGian tg = new Entities.BCNhapHangTheoThoiGian(hoadonnhap[i].MaHoaDonNhap, "Hóa Đơn Nhập", hoadonnhap[i].NgayNhap, soluong);
                        hienthi.Add(tg);
                    }
                }
                // khách hàng trả lại
                for (int i = 0; i < khachhangtralai.Length; i++)
                {
                    int soluong = 0;
                    DateTime ngayphieu = khachhangtralai[i].NgayNhap;
                    if (ngayphieu >= truoc && ngayphieu <= sau)
                    {
                        for (int j = 0; j < chitietkhachhangtralai.Length; j++)
                        {
                            if (khachhangtralai[i].MaKhachHangTraLai == chitietkhachhangtralai[j].MaKhachHangTraLai)
                            {
                                for (int k = 0; k < hanghoa.Length; k++)
                                {
                                    if (!GoiHangOrHangHoa(chitietkhachhangtralai[j].MaHangHoa))
                                    {
                                        if (chitietkhachhangtralai[j].MaHangHoa == hanghoa[k].MaHangHoa)
                                        {
                                            int sl = chitietkhachhangtralai[j].SoLuong;
                                            soluong += sl;
                                            Entities.BCNhapHangTheoThoiGianChiTiet ct = new Entities.BCNhapHangTheoThoiGianChiTiet(khachhangtralai[i].MaKhachHangTraLai, "Khách Hàng Trả Lại", khachhangtralai[i].NgayNhap, hanghoa[k].MaHangHoa, hanghoa[k].TenHangHoa, sl);
                                            hienthibaocao.Add(ct);
                                        }
                                    }
                                    ////////////////////////////////////////////////MRK FIX
                                    else
                                    {//là gói hàng
                                        foreach (Entities.GoiHang gh in goihang)
                                        {
                                            foreach (Entities.ChiTietGoiHang ctgh in chitietgoihang)
                                            {
                                                if (gh.MaGoiHang.Equals(ctgh.MaGoiHang) && ctgh.MaGoiHang.Equals(chitietkhachhangtralai[j].MaHangHoa) && ctgh.MaHangHoa.Equals(hanghoa[k].MaHangHoa))
                                                {
                                                    int sl = chitietkhachhangtralai[j].SoLuong * ctgh.SoLuong;
                                                    soluong += sl;
                                                    Entities.BCNhapHangTheoThoiGianChiTiet ct = new Entities.BCNhapHangTheoThoiGianChiTiet(khachhangtralai[i].MaKhachHangTraLai, "Khách Hàng Trả Lại", khachhangtralai[i].NgayNhap, hanghoa[k].MaHangHoa + " (" + ctgh.MaGoiHang + ")", hanghoa[k].TenHangHoa, sl);
                                                    hienthibaocao.Add(ct);
                                                }
                                            }
                                        }
                                    }
                                    ////////////////////////////////////////////////MRK FIX
                                }
                            }
                        }
                        Entities.BCNhapHangTheoThoiGian tg = new Entities.BCNhapHangTheoThoiGian(khachhangtralai[i].MaKhachHangTraLai, "Khách Hàng Trả Lại", khachhangtralai[i].NgayNhap, soluong);
                        hienthi.Add(tg);
                    }
                }
               
               
                ///////////////////////////////MRK FIX
                List<Entities.BCNhapHangTheoThoiGian> tem0 = new List<Entities.BCNhapHangTheoThoiGian>();
                int tong0 = 0;
                foreach (Entities.BCNhapHangTheoThoiGian item in hienthi.ToArray())
                {
                    tong0 += item.SoLuong;
                    tem0.Add(item);
                }
                Entities.BCNhapHangTheoThoiGian tem1 = new Entities.BCNhapHangTheoThoiGian();
                tem1.TenChungTu = "Tổng: ";
                tem1.SoLuong = tong0;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = hienthi;
                dtgvHienThi.DataSource = tem0.ToArray();

                if (hienthi.ToArray().Length > 0)
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
                }
                else
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
                }
                fix();
            }
            catch
            {
            }
        }
        public void fix()
        {
            dtgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvHienThi.ReadOnly = true;
            dtgvHienThi.RowHeadersVisible = false;
            dtgvHienThi.Columns["MaChungTu"].HeaderText = "Mã Chứng Từ";
            dtgvHienThi.Columns["TenChungTu"].HeaderText = "Tên Chứng Từ";
            dtgvHienThi.Columns["NgayLap"].HeaderText = "Ngày Lập";
            dtgvHienThi.Columns["SoLuong"].HeaderText = "Số Lượng Nhập";
            dtgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvHienThi.AllowUserToAddRows = false;
            dtgvHienThi.AllowUserToDeleteRows = false;
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                lbtenbaocao.Text = "Báo Cáo Nhập Hàng Từ Ngày " + new Common.Utilities().XuLy(2, truoc.ToShortDateString()) + " Đến Ngày " + new Common.Utilities().XuLy(2, sau.ToShortDateString());
                HoaDonNhap();
                ChiTietHoaDonNhap();
                PhieuDieuChuyenKhoNoiBo();
                ChiTietPhieuDieuChuyenKho();
                KhachHangTraLai();
                ChiTietKhachHangTraLai();
                HangHoa();
                HienThi();
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

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            try
            {
                frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao.ToArray(), truoc, sau);
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
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao.ToArray(), truoc, sau, saveFileDialog1.FileName, "Excel");
                }
            }
            catch
            {
            }
            finally { this.Enabled = true; }
        }

        private void tsslWord_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao.ToArray(), truoc, sau, saveFileDialog1.FileName, "Word");
                }
            }
            catch
            {
            }
            finally
            { this.Enabled = true; }
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao.ToArray(), truoc, sau, saveFileDialog1.FileName, "PDF");
                }
            }
            catch
            {
            }
            finally
            { this.Enabled = true; }
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
