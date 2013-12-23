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

namespace GUI
{
    public partial class frmBCXuatNhapTonNhomHang : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        int nam = 0;
        int thang = 0;
        public frmBCXuatNhapTonNhomHang()
        {
            try
            {
                InitializeComponent();
                nam = DateServer.Date().Year;
                thang = DateServer.Date().Month;
                cbbthang.Text = thang.ToString();
                cbbnam.Text = nam.ToString();
                SelectData();
                TongTienNhanVien();
            }
            catch
            {
            }

        }
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
        Entities.HangHoa[] hanghoa;
        Entities.NhomHang[] nhomhang;
        Entities.KhoHang[] khohang;
        Entities.SoDuKho[] sodukho;
        Entities.GoiHang[] goihang;
        Entities.ChiTietGoiHang[] chitietgoihang;
        Entities.SelectAll selectall;
        void SelectData()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("BCXuatNhapTonNhomHang", new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen);
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
            tralaincc = selectall.TraLaiNCC;
            chitiettralaincc = selectall.ChiTietTraLaiNhaCungCap;
            hanghoa = selectall.HangHoa;
            nhomhang = selectall.NhomHang;
            khohang = selectall.KhoHang;
            sodukho = selectall.SoDuKho;
            goihang = selectall.GoiHang;
            chitietgoihang = selectall.ChiTietGoiHang;
        }


        Entities.BCXuatNhapTonTheoNhomHang[] hienthi;
        Entities.ChiTietBCXuatNhapTonTheoNhomHang[] hienthibaocao;
        public void TongTienNhanVien()
        {
            try
            {
                int i = 0;
                ArrayList arr = new ArrayList();
                ArrayList arrbaocao = new ArrayList();
                Entities.HangHoa[] hh = Common.Utilities.CheckGoiHang(hanghoa, goihang, chitietgoihang);
                foreach (Entities.NhomHang item in nhomhang)
                {
                    int dudauky = 0, ducuoiky = 0, tongxuat = 0, tongnhap = 0;
                    // lay hang hoa theo nhom 
                    var queryhh = from h in hanghoa
                                  where h.MaNhomHangHoa.Equals(item.MaNhomHang)
                                  select h;

                    Entities.HangHoa[] hanghoaArr = queryhh.ToArray();

                    foreach (Entities.HangHoa item1 in hanghoaArr)
                    {
                        int nhapmua = 0, nhaptralai = 0, nhapkhac = 0, xuatban = 0, xuattralai = 0, xuatkhac = 0, sodudauky = 0, soducuoiky = 0;
                        //// so kho
                        foreach (Entities.SoDuKho item2 in sodukho)
                        {
                            if (item2.MaHangHoa == item1.MaHangHoa && item2.NgayKetChuyen.Month == thang && item2.NgayKetChuyen.Year == nam)
                            {
                                dudauky += item2.SoDuDauKy;
                                sodudauky += item2.SoDuDauKy;
                            }
                        }
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

                        foreach (Entities.ChiTietXuatHuy item3 in chitietxuathuyArr)
                        {
                            if (item1.MaHangHoa.Equals(item3.MaHangHoa))
                            {
                                tongxuat += item3.SoLuong;
                                xuatkhac += item3.SoLuong;
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
                            if (item1.MaHangHoa.Equals(item3.MaHangHoa))
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
                                        if (item1.MaHangHoa.Equals(item5.MaHangHoa))
                                        {
                                            tongxuat += (item5.SoLuong * item3.SoLuong);
                                            xuatban += (item5.SoLuong * item3.SoLuong);
                                        }
                                    }

                                }
                            }
                        }
                        // Tra lai ncc
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

                        foreach (Entities.ChiTietTraLaiNhaCungCap item3 in cttralainccArr)
                        {
                            if (item1.MaHangHoa.Equals(item3.MaHangHoa))
                            {
                                tongxuat += item3.SoLuong;
                                xuattralai += item3.SoLuong;
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

                        foreach (Entities.ChiTietHoaDonNhap item3 in cthoadonnhapArr)
                        {
                            if (item3.MaHangHoa == item1.MaHangHoa)
                            {
                                tongnhap += item3.SoLuong;
                                nhapmua += item3.SoLuong;
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
                            if (item1.MaHangHoa.Equals(item3.MaHangHoa))
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
                                        if (item1.MaHangHoa.Equals(item5.MaHangHoa))
                                        {
                                            tongnhap += (item5.SoLuong * item3.SoLuong);
                                            nhaptralai += (item5.SoLuong * item3.SoLuong);
                                        }
                                    }
                                }
                            }
                        }

                        soducuoiky = sodudauky + nhapmua + nhaptralai + nhapkhac - xuatban - xuatkhac - xuattralai;
                        if (!(soducuoiky == 0 && sodudauky == 0 && nhapmua == 0 && nhaptralai == 0 && nhapkhac == 0 && xuatban == 0 && xuattralai == 0 && xuatkhac == 0))
                            arrbaocao.Add(new Entities.ChiTietBCXuatNhapTonTheoNhomHang(item.MaNhomHang, item.TenNhomHang, item1.MaHangHoa, item1.TenHangHoa, sodudauky, nhapmua, nhaptralai, nhapkhac, xuatban, xuattralai, xuatkhac, soducuoiky));
                    }

                    ducuoiky = dudauky + tongnhap - tongxuat;
                    if (!(dudauky == 0 && ducuoiky == 0 && tongnhap == 0 && tongxuat == 0))
                    {
                        arr.Add(new Entities.BCXuatNhapTonTheoNhomHang(i.ToString(), item.MaNhomHang, item.TenNhomHang, dudauky.ToString(), tongnhap.ToString(), tongxuat.ToString(), ducuoiky.ToString()));
                        i++;
                    }
                }

                hienthi = (Entities.BCXuatNhapTonTheoNhomHang[])arr.ToArray(typeof(Entities.BCXuatNhapTonTheoNhomHang));
                hienthibaocao = (Entities.ChiTietBCXuatNhapTonTheoNhomHang[])arrbaocao.ToArray(typeof(Entities.ChiTietBCXuatNhapTonTheoNhomHang));
                ///////////////////////////////MRK FIX
                List<Entities.BCXuatNhapTonTheoNhomHang> tem0 = new List<Entities.BCXuatNhapTonTheoNhomHang>();
                double tong0 = 0;
                double tong1 = 0;
                double tong2 = 0;
                double tong3 = 0;
                foreach (Entities.BCXuatNhapTonTheoNhomHang item in hienthi)
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
                Entities.BCXuatNhapTonTheoNhomHang tem1 = new Entities.BCXuatNhapTonTheoNhomHang();
                tem1.TenNhomHang = "Tổng: ";
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
                    enable();
                }
                else
                {
                    disable();
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
        void enable()
        {
            tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
        }
        void disable()
        {
            tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
        }
        public string Format(double a)
        {
            return new Common.Utilities().FormatMoney(a);
        }

        public void fix()
        {
            new Common.Utilities().CountDatagridview(dtgvhienthi);
            dtgvhienthi.ReadOnly = true;
            dtgvhienthi.RowHeadersVisible = false;
            dtgvhienthi.Columns["HanhDong"].HeaderText = "STT";
            dtgvhienthi.Columns["MaNhomHang"].HeaderText = "Mã Nhóm Hang";
            dtgvhienthi.Columns["TenNhomHang"].HeaderText = "Tên Nhóm Hàng";
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

        public Entities.ChiTietBCXuatNhapTonTheoNhomHang[] ChiTietNhom(string manhomhang)
        {
            try
            {
                ArrayList arr = new ArrayList();
                foreach (Entities.ChiTietBCXuatNhapTonTheoNhomHang item in hienthibaocao)
                {
                    if (item.MaNhomHang.Equals(manhomhang))
                    {
                        arr.Add(item);
                    }
                }
                return (Entities.ChiTietBCXuatNhapTonTheoNhomHang[])arr.ToArray(typeof(Entities.ChiTietBCXuatNhapTonTheoNhomHang));

            }
            catch
            {
                return new Entities.ChiTietBCXuatNhapTonTheoNhomHang[0];
            }
        }

        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                disable();
                string manhomhang = dtgvhienthi["MaNhomHang", i].Value.ToString();
                Report.rptXuatNhapHangTheoNhomHang report = new Report.rptXuatNhapHangTheoNhomHang();
                report.SetDataSource(ChiTietNhom(manhomhang));
                report.SetParameterValue("Ky", thang.ToString() + "-" + nam.ToString());
                report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Nhập Tồn Theo Nhóm Hàng");
                frmBaoCaorpt a = new frmBaoCaorpt(report);
                a.ShowDialog();
            }
            catch
            {
            }
            finally
            {
                enable();
            }
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                disable();
                string manhomhang = dtgvhienthi["MaNhomHang", i].Value.ToString();
                Report.rptXuatNhapHangTheoNhomHang report = new Report.rptXuatNhapHangTheoNhomHang();
                report.SetDataSource(ChiTietNhom(manhomhang));
                report.SetParameterValue("Ky", thang.ToString() + "-" + nam.ToString());
                report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Nhập Tồn Theo Nhóm Hàng");
                frmBaoCaorpt a = new frmBaoCaorpt(report);
                a.ShowDialog();
            }
            catch
            {
            }
            finally
            {
                enable();
            }
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            try
            {
                nam = int.Parse(cbbnam.Text);
                thang = int.Parse(cbbthang.Text);
                TongTienNhanVien();
                lbtenbaocao.Text = "Báo Cáo Xuất Nhập Tồn Theo Nhóm Hàng Kỳ " + cbbthang.Text + "/" + cbbnam.Text;
            }
            catch
            {
            }
        }

        private void frmBCXuatNhapTonLoaiHang_Load(object sender, EventArgs e)
        {
            lbtenbaocao.Text = "Báo Cáo Xuất Nhập Tồn Theo Nhóm Hàng Kỳ " + cbbthang.Text + "/" + cbbnam.Text;
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (i < 0)
                    return;
                disable();
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string manhomhang = dtgvhienthi["MaNhomHang", i].Value.ToString();
                    Report.rptXuatNhapHangTheoNhomHang report = new Report.rptXuatNhapHangTheoNhomHang();
                    report.SetDataSource(ChiTietNhom(manhomhang));
                    report.SetParameterValue("Ky", thang.ToString() + "-" + nam.ToString());
                    report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Nhập Tồn Theo Nhóm Hàng");
                    frmBaoCaorpt a = new frmBaoCaorpt(report, saveFileDialog1.FileName, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                    a.Dispose();
                }
            }
            catch
            {
            }
            finally
            {
                enable();
            }
        }

        private void tsslWord_Click(object sender, EventArgs e)
        {
            try
            {
                if (i < 0)
                    return;
                disable();
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string manhomhang = dtgvhienthi["MaNhomHang", i].Value.ToString();
                    Report.rptXuatNhapHangTheoNhomHang report = new Report.rptXuatNhapHangTheoNhomHang();
                    report.SetDataSource(ChiTietNhom(manhomhang));
                    report.SetParameterValue("Ky", thang.ToString() + "-" + nam.ToString());
                    report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Nhập Tồn Theo Nhóm Hàng");
                    frmBaoCaorpt a = new frmBaoCaorpt(report, saveFileDialog1.FileName, Report.ExportCrystalReport.TypeBC.WordForWindows);
                    a.Dispose();
                }
            }
            catch
            {
            }
            finally
            {
                enable();
            }
        }

        private void tsslexcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (i < 0)
                    return;
                disable();
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string manhomhang = dtgvhienthi["MaNhomHang", i].Value.ToString();
                    Report.rptXuatNhapHangTheoNhomHang report = new Report.rptXuatNhapHangTheoNhomHang();
                    report.SetDataSource(ChiTietNhom(manhomhang));
                    report.SetParameterValue("Ky", thang.ToString() + "-" + nam.ToString());
                    report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Nhập Tồn Theo Nhóm Hàng");
                    frmBaoCaorpt a = new frmBaoCaorpt(report, saveFileDialog1.FileName, Report.ExportCrystalReport.TypeBC.Excel);
                    a.Dispose();
                }
            }
            catch
            {

            }
            finally
            {
                enable();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                SelectData();
                TongTienNhanVien(); this.Focus();
            }
            catch
            {
            }
            this.Enabled = true;
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {

            if (rdbtimkiem3.Checked || hienthi == null)
                return;
            else if (hienthi.Length == 0)
                return;
            if (txttimkiem.Text.Equals(""))
            {
                dtgvhienthi.DataSource = new Entities.BCXuatNhapTonTheoNhomHang[0];
                return;
            }
            ArrayList arr = new ArrayList();
            if (rdbtimkiem1.Checked)
            {
                foreach (Entities.BCXuatNhapTonTheoNhomHang item in hienthi)
                {
                    if (item.MaNhomHang.ToLower().IndexOf(txttimkiem.Text.ToLower()) > -1)
                    {
                        arr.Add(item);
                    }
                }
            }
            else if (rdbtimkiem2.Checked)
            {
                foreach (Entities.BCXuatNhapTonTheoNhomHang item in hienthi)
                {
                    if (item.TenNhomHang.ToLower().IndexOf(txttimkiem.Text.ToLower()) > -1)
                    {
                        arr.Add(item);
                    }
                }
            }
            if (arr.Count > 0)
            {
                Entities.BCXuatNhapTonTheoNhomHang[] temp = new Entities.BCXuatNhapTonTheoNhomHang[arr.Count];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = (Entities.BCXuatNhapTonTheoNhomHang)arr[i];
                    temp[i].HanhDong = (i + 1).ToString();
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCXuatNhapTonTheoNhomHang> tem0 = new List<Entities.BCXuatNhapTonTheoNhomHang>();
                double tong0 = 0;
                double tong1 = 0;
                double tong2 = 0;
                double tong3 = 0;
                foreach (Entities.BCXuatNhapTonTheoNhomHang item in temp)
                {
                    tong0 += double.Parse(item.SoDuDauKy);
                    tong1 += double.Parse(item.TongNhap);
                    tong2 += double.Parse(item.TongXuat);
                    tong3 += double.Parse(item.SoDuCuoiKy);
                    tem0.Add(item);
                }
                Entities.BCXuatNhapTonTheoNhomHang tem1 = new Entities.BCXuatNhapTonTheoNhomHang();
                tem1.TenNhomHang = "Tổng: ";
                tem1.SoDuDauKy = tong0.ToString();
                tem1.TongNhap = tong1.ToString();
                tem1.TongXuat = tong2.ToString();
                tem1.SoDuCuoiKy = tong3.ToString();
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = temp;
                dtgvhienthi.DataSource = tem0.ToArray();
            }
            else
            {
                dtgvhienthi.DataSource = new Entities.BCXuatNhapTonTheoNhomHang[0];
            }
        }

        private void rdbtimkiem3_CheckedChanged(object sender, EventArgs e)
        {

            if (rdbtimkiem3.Checked)
            {
                if (hienthi != null)
                {
                    ///////////////////////////////MRK FIX
                    List<Entities.BCXuatNhapTonTheoNhomHang> tem0 = new List<Entities.BCXuatNhapTonTheoNhomHang>();
                    double tong0 = 0;
                    double tong1 = 0;
                    double tong2 = 0;
                    double tong3 = 0;
                    foreach (Entities.BCXuatNhapTonTheoNhomHang item in hienthi)
                    {
                        tong0 += double.Parse(item.SoDuDauKy);
                        tong1 += double.Parse(item.TongNhap);
                        tong2 += double.Parse(item.TongXuat);
                        tong3 += double.Parse(item.SoDuCuoiKy);
                        tem0.Add(item);
                    }
                    Entities.BCXuatNhapTonTheoNhomHang tem1 = new Entities.BCXuatNhapTonTheoNhomHang();
                    tem1.TenNhomHang = "Tổng: ";
                    tem1.SoDuDauKy = tong0.ToString();
                    tem1.TongNhap = tong1.ToString();
                    tem1.TongXuat = tong2.ToString();
                    tem1.SoDuCuoiKy = tong3.ToString();
                    tem0.Add(tem1);
                    //////////////////////////////////////
                    //dtgvhienthi.DataSource = hienthi;
                    dtgvhienthi.DataSource = tem0.ToArray();
                    dtgvhienthi.DataSource = hienthi;
                }
                else
                {
                    dtgvhienthi.DataSource = new Entities.BCNhapHangTheoMatHang[0];
                }
                dtgvhienthi.Refresh();
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
