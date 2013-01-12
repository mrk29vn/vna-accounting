using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BizLogic;
using DAL;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
namespace GUI
{
    public partial class frmBaoCaoNhapHang : Form
    {
        public frmBaoCaoNhapHang()
        {
            InitializeComponent();
        }

        public frmBaoCaoNhapHang(string hanhdong, string tennhanvien, Entities.ThongTinKiemKeKho[] row, Entities.KiemKeKho kiemke, Entities.ThongTinCongTy congty, string path)
        {
            InitializeComponent();
            try
            {
                GUI.Report.rptBaoCaoKiemKeKho report = new GUI.Report.rptBaoCaoKiemKeKho();
                report.SetDataSource(row);
                rptView.ReportSource = report;
                report.SetParameterValue("TenCongTy", congty.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", congty.DiaChi);
                report.SetParameterValue("DienThoai", congty.SoDienThoai);
                report.SetParameterValue("FaxCongTy", congty.Fax);
                report.SetParameterValue("Web", congty.Website);
                report.SetParameterValue("Email", congty.Email);
                report.SetParameterValue("TenBaoCao", kiemke.Hanhdong);
                report.SetParameterValue("MaNhanVien", tennhanvien);
                report.SetParameterValue("MaKiemKe", kiemke.MaKiemKe);
                report.SetParameterValue("NgayKiemKe", kiemke.NgayKiemKe.ToString("dd/MM/yyyy"));
                report.SetParameterValue("MaKho", kiemke.Tenkho);
                report.SetParameterValue("TongTien", kiemke.GhiChu);

                if (hanhdong == "In")
                {
                    rptView.Show();
                }
                else if (hanhdong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhdong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhdong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch
            {
            }
        }


        private Entities.BaoCaoHoaDonNhap[] hoadonnhap;

        public Entities.BaoCaoHoaDonNhap[] Hoadonnhap
        {
            get { return hoadonnhap; }
            set { hoadonnhap = value; }
        }
        private Entities.TruyenGiaTriVaoBaoCao giatri;

        public Entities.TruyenGiaTriVaoBaoCao Giatri
        {
            get { return giatri; }
            set { giatri = value; }
        }
        public frmBaoCaoNhapHang(string hanhdong, Entities.BaoCaoHoaDonNhap[] hoadonnhap, Entities.TruyenGiaTriVaoBaoCao giatri, Entities.ThongTinCongTy congty)
        {
            InitializeComponent();
            try
            {
                if (hanhdong == "HoaDonNhap")
                {
                    GUI.Report.rptHoaDonNhap report = new GUI.Report.rptHoaDonNhap();
                    report.SetDataSource(hoadonnhap);
                    rptView.ReportSource = report;
                    report.SetParameterValue("TenCongTy", congty.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", congty.DiaChi);
                    report.SetParameterValue("DienThoai", congty.SoDienThoai);
                    report.SetParameterValue("FaxCongTy", congty.Fax);
                    report.SetParameterValue("Web", congty.Website);
                    report.SetParameterValue("Email", congty.Email);
                    report.SetParameterValue("TenBaoCao", giatri.Giatri1);
                    //report.SetParameterValue("NgayTao", @giatri.Giatri2);
                    report.SetParameterValue("MaHoaDonNhap", giatri.Giatri3);
                    report.SetParameterValue("MaNhanVien", giatri.Giatri4);
                    report.SetParameterValue("NgayLap", @giatri.Giatri5);
                    report.SetParameterValue("MaNhaCungCap", giatri.Giatri6);
                    report.SetParameterValue("HanThanhToan", @giatri.Giatri7);
                    report.SetParameterValue("KhoHang", giatri.Giatri8);
                    report.SetParameterValue("LoaiNhapHang", giatri.Giatri9);
                    report.SetParameterValue("MaDonDatHang", giatri.Giatri10);
                    report.SetParameterValue("LoaiThanhToan", giatri.Giatri11);
                    report.SetParameterValue("ThanhToanNgay", giatri.Giatri12);
                    report.SetParameterValue("ChietKhauTM", giatri.Giatri13);
                    report.SetParameterValue("TongThanhToan", giatri.Giatri14);
                    report.SetParameterValue("TongChietKhau", giatri.Giatri15);
                    report.SetParameterValue("ThueGTGT", giatri.Giatri16);
                    report.SetParameterValue("ConPhaiTra", giatri.Giatri17);
                    rptView.Show();
                }
                if (hanhdong == "TraLaiNhaCungCap")
                {
                    GUI.Report.rptBaoCaoTraLaiNhaCungCap report = new GUI.Report.rptBaoCaoTraLaiNhaCungCap();
                    report.SetDataSource(hoadonnhap);
                    rptView.ReportSource = report;
                    report.SetParameterValue("TenCongTy", congty.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", congty.DiaChi);
                    report.SetParameterValue("DienThoai", congty.SoDienThoai);
                    report.SetParameterValue("FaxCongTy", congty.Fax);
                    report.SetParameterValue("Web", congty.Website);
                    report.SetParameterValue("Email", congty.Email);
                    report.SetParameterValue("TenBaoCao", giatri.Giatri1);
                    //report.SetParameterValue("NgayTao", @giatri.Giatri2);
                    report.SetParameterValue("MaHoaDonNhap", giatri.Giatri3);
                    report.SetParameterValue("MaNhanVien", giatri.Giatri4);
                    report.SetParameterValue("NgayLap", giatri.Giatri5);
                    report.SetParameterValue("MaNhaCungCap", giatri.Giatri6);
                    report.SetParameterValue("HanThanhToan", giatri.Giatri7);
                    report.SetParameterValue("KhoHang", giatri.Giatri8);
                    report.SetParameterValue("MaDonDatHang", giatri.Giatri10);
                    report.SetParameterValue("LoaiThanhToan", giatri.Giatri11);
                    report.SetParameterValue("ThanhToanNgay", giatri.Giatri12);
                    report.SetParameterValue("TongChietKhau", giatri.Giatri13);
                    report.SetParameterValue("TongThanhToan", giatri.Giatri14);
                    report.SetParameterValue("ThueGTGT", giatri.Giatri16);
                    report.SetParameterValue("ConPhaiTra", giatri.Giatri17);
                    rptView.Show();
                }
                if (hanhdong == "KhachHangTraLai")
                {
                    GUI.Report.rptBaoCaoKhachHangTraLaiHang report = new GUI.Report.rptBaoCaoKhachHangTraLaiHang();
                    report.SetDataSource(hoadonnhap);
                    rptView.ReportSource = report;
                    report.SetParameterValue("TenCongTy", congty.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", congty.DiaChi);
                    report.SetParameterValue("DienThoai", congty.SoDienThoai);
                    report.SetParameterValue("FaxCongTy", congty.Fax);
                    report.SetParameterValue("Web", congty.Website);
                    report.SetParameterValue("Email", congty.Email);
                    report.SetParameterValue("TenBaoCao", giatri.Giatri1);
                    //report.SetParameterValue("NgayTao", @giatri.Giatri2);
                    report.SetParameterValue("MaHoaDonNhap", giatri.Giatri3);
                    report.SetParameterValue("MaNhanVien", giatri.Giatri4);
                    report.SetParameterValue("NgayLap", @giatri.Giatri5);
                    report.SetParameterValue("MaNhaCungCap", giatri.Giatri6);
                    report.SetParameterValue("HanThanhToan", @giatri.Giatri7);
                    report.SetParameterValue("KhoHang", giatri.Giatri8);
                    report.SetParameterValue("LoaiBan", giatri.Giatri9);
                    report.SetParameterValue("MaDonDatHang", giatri.Giatri10);
                    report.SetParameterValue("LoaiThanhToan", giatri.Giatri11);
                    report.SetParameterValue("ThanhToanNgay", giatri.Giatri12);
                    report.SetParameterValue("TongChietKhau", giatri.Giatri13);
                    report.SetParameterValue("TongThanhToan", giatri.Giatri14);
                    report.SetParameterValue("ThueGTGT", giatri.Giatri16);
                    report.SetParameterValue("ConPhaiTra", giatri.Giatri17);
                    rptView.Show();
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }


        public frmBaoCaoNhapHang(string hanhDong, Entities.NhapHangTheoKho[] khohang, Entities.ThongTinCongTy congty, string path, string theoKy, string ma, string maNhanVien, string tenBaoCao)
        {
            InitializeComponent();
            try
            {
                if (this.hanhDong == null)
                {
                    GUI.Report.rptBaoCaoNhapHangTheoTungKho kho = new GUI.Report.rptBaoCaoNhapHangTheoTungKho();
                    kho.SetDataSource(khohang);
                    rptView.ReportSource = kho;
                    kho.SetParameterValue("TenCongTy", congty.TenCongTy);
                    kho.SetParameterValue("DiaChiCongTy", congty.DiaChi);
                    kho.SetParameterValue("DienThoai", congty.SoDienThoai);
                    kho.SetParameterValue("FaxCongTy", congty.Fax);
                    kho.SetParameterValue("Web", congty.Website);
                    kho.SetParameterValue("Email", congty.Email);
                    kho.SetParameterValue("TenBaoCao", tenBaoCao);
                    kho.SetParameterValue("Ky", theoKy);
                    kho.SetParameterValue("MaNhanVien", maNhanVien);
                    kho.SetParameterValue("MaKho", ma);
                    if (hanhDong == "Excel")
                    {
                        new GUI.Report.ExportCrystalReport().Export(kho, path, Report.ExportCrystalReport.TypeBC.Excel);
                    }
                    else if (hanhDong == "Word")
                    {
                        new GUI.Report.ExportCrystalReport().Export(kho, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                    }
                    else if (hanhDong == "PDF")
                    {
                        new GUI.Report.ExportCrystalReport().Export(kho, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                    }
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
        public frmBaoCaoNhapHang(string hanhDong, string path, Entities.ThongTinCongTy congty, Entities.BaoCaoNhapHangTheoNhom[] data, string theoKy, string ma, string maNhanVien, string tenBaoCao, string tenHang)
        {
            InitializeComponent();
            try
            {
                if (this.hanhDong == null)
                {
                    GUI.Report.rptBaoCaoNhaphangTheoNhomHang nhom = new GUI.Report.rptBaoCaoNhaphangTheoNhomHang();
                    nhom.SetDataSource(data);
                    rptView.ReportSource = nhom;
                    nhom.SetParameterValue("TenCongTy", congty.TenCongTy);
                    nhom.SetParameterValue("DiaChiCongTy", congty.DiaChi);
                    nhom.SetParameterValue("DienThoai", congty.SoDienThoai);
                    nhom.SetParameterValue("FaxCongTy", congty.Fax);
                    nhom.SetParameterValue("Web", congty.Website);
                    nhom.SetParameterValue("Email", congty.Email);
                    nhom.SetParameterValue("TenBaoCao", tenBaoCao);
                    nhom.SetParameterValue("Ky", theoKy);
                    nhom.SetParameterValue("MaNhanVien", maNhanVien);
                    nhom.SetParameterValue("MaNhomHang", ma);
                    nhom.SetParameterValue("TenNhomHangHoa", tenHang);
                    if (hanhDong == "Excel")
                    {
                        new GUI.Report.ExportCrystalReport().Export(nhom, path, Report.ExportCrystalReport.TypeBC.Excel);
                    }
                    else if (hanhDong == "Word")
                    {
                        new GUI.Report.ExportCrystalReport().Export(nhom, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                    }
                    else if (hanhDong == "PDF")
                    {
                        new GUI.Report.ExportCrystalReport().Export(nhom, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        public frmBaoCaoNhapHang(string hanhDong, string path, Entities.ThongTinCongTy congty, Entities.NhapHangTheoMatHang[] mathang, string theoKy, string ma, string maNhanVien, string tenBaoCao, string tenHang)
        {
            InitializeComponent();
            try
            {
                if (this.hanhDong == null)
                {
                    GUI.Report.rptBaoCaoNhapHangTheoMatHang hang = new GUI.Report.rptBaoCaoNhapHangTheoMatHang();
                    hang.SetDataSource(mathang);
                    rptView.ReportSource = hang;
                    hang.SetParameterValue("TenCongTy", congty.TenCongTy);
                    hang.SetParameterValue("DiaChiCongTy", congty.DiaChi);
                    hang.SetParameterValue("DienThoai", congty.SoDienThoai);
                    hang.SetParameterValue("FaxCongTy", congty.Fax);
                    hang.SetParameterValue("Web", congty.Website);
                    hang.SetParameterValue("Email", congty.Email);
                    hang.SetParameterValue("TenBaoCao", tenBaoCao);
                    hang.SetParameterValue("Ky", theoKy);
                    hang.SetParameterValue("MaNhanVien", maNhanVien);
                    hang.SetParameterValue("MaHangHoa", ma);
                    hang.SetParameterValue("TenHangHoa", tenHang);
                    if (hanhDong == "Excel")
                    {
                        new GUI.Report.ExportCrystalReport().Export(hang, path, Report.ExportCrystalReport.TypeBC.Excel);
                    }
                    else if (hanhDong == "Word")
                    {
                        new GUI.Report.ExportCrystalReport().Export(hang, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                    }
                    else if (hanhDong == "PDF")
                    {
                        new GUI.Report.ExportCrystalReport().Export(hang, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        public frmBaoCaoNhapHang(string hanhDong, string path, Entities.ThongTinCongTy congty, Entities.XuatNhapTonTheoNhomHangHoa[] nhomHang, string theoKy, string ma, string maNhanVien, string tenBaoCao, string tenNhom)
        {
            InitializeComponent();
            try
            {
                if (this.hanhDong == null)
                {
                    GUI.Report.rptXuatNhapHangTheoNhomHang nhom = new GUI.Report.rptXuatNhapHangTheoNhomHang();
                    nhom.SetDataSource(nhomHang);
                    rptView.ReportSource = nhom;
                    nhom.SetParameterValue("TenCongTy", congty.TenCongTy);
                    nhom.SetParameterValue("DiaChiCongTy", congty.DiaChi);
                    nhom.SetParameterValue("DienThoai", congty.SoDienThoai);
                    nhom.SetParameterValue("FaxCongTy", congty.Fax);
                    nhom.SetParameterValue("Web", congty.Website);
                    nhom.SetParameterValue("Email", congty.Email);
                    nhom.SetParameterValue("TenBaoCao", tenBaoCao);
                    nhom.SetParameterValue("Ky", theoKy);
                    nhom.SetParameterValue("MaNhanVien", maNhanVien);
                    nhom.SetParameterValue("MaNhom", ma);
                    nhom.SetParameterValue("TenNhomHang", tenNhom);
                    if (hanhDong == "Excel")
                    {
                        new GUI.Report.ExportCrystalReport().Export(nhom, path, Report.ExportCrystalReport.TypeBC.Excel);
                    }
                    else if (hanhDong == "Word")
                    {
                        new GUI.Report.ExportCrystalReport().Export(nhom, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                    }
                    else if (hanhDong == "PDF")
                    {
                        new GUI.Report.ExportCrystalReport().Export(nhom, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private Entities.ThongTinCongTy congty;
        private Entities.NhapHangTheoKho[] data;
        private Entities.XuatNhapTonTheoNhomHangHoa[] nhomHang;
        public Entities.XuatNhapTonTheoNhomHangHoa[] NhomHang
        {
            get { return nhomHang; }
            set { nhomHang = value; }
        }
        private string theoKy;
        private string ma;

        public string TheoKy
        {
            get { return theoKy; }
            set { theoKy = value; }
        }
        public string Ma
        {
            get { return ma; }
            set { ma = value; }
        }
        public Entities.ThongTinCongTy Congty
        {
            get { return congty; }
            set { congty = value; }
        }
        public Entities.NhapHangTheoKho[] Data
        {
            get { return data; }
            set { data = value; }
        }
        private string hanhDong;

        public string HanhDong
        {
            get { return hanhDong; }
            set { hanhDong = value; }
        }
        private string maNhanVien;

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }
        private string tenBaoCao;

        public string TenBaoCao
        {
            get { return tenBaoCao; }
            set { tenBaoCao = value; }
        }
        private string tenNhom;

        public string TenNhom
        {
            get { return tenNhom; }
            set { tenNhom = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="congty"></param>
        /// <param name="data"></param>
        /// <param name="theoKy"></param>
        /// <param name="maKho"></param>
        public frmBaoCaoNhapHang(string hanhDong, Entities.ThongTinCongTy congty, Entities.NhapHangTheoKho[] data, string theoKy, string ma, string maNhanVien, string tenBaoCao)
        {
            InitializeComponent();
            this.hanhDong = hanhDong;
            this.congty = congty;
            this.data = data;
            this.theoKy = theoKy;
            this.ma = ma;
            this.maNhanVien = maNhanVien;
            this.tenBaoCao = tenBaoCao;
        }
        private Entities.NhapHangTheoMatHang[] mathang;

        public Entities.NhapHangTheoMatHang[] Mathang
        {
            get { return mathang; }
            set { mathang = value; }
        }
        private string tenHang;

        public string TenHang
        {
            get { return tenHang; }
            set { tenHang = value; }
        }
        public frmBaoCaoNhapHang(string hanhDong, Entities.ThongTinCongTy congty, Entities.NhapHangTheoMatHang[] mathang, string theoKy, string ma, string maNhanVien, string tenBaoCao, string tenHang)
        {
            InitializeComponent();
            this.hanhDong = hanhDong;
            this.congty = congty;
            this.mathang = mathang;
            this.theoKy = theoKy;
            this.ma = ma;
            this.maNhanVien = maNhanVien;
            this.tenBaoCao = tenBaoCao;
            this.tenHang = tenHang;
        }
        private Entities.BaoCaoNhapHangTheoNhom[] nhomhanghoa;

        public Entities.BaoCaoNhapHangTheoNhom[] Nhomhanghoa
        {
            get { return nhomhanghoa; }
            set { nhomhanghoa = value; }
        }
        public frmBaoCaoNhapHang(string hanhDong, Entities.ThongTinCongTy congty, Entities.BaoCaoNhapHangTheoNhom[] nhomhanghoa, string theoKy, string ma, string maNhanVien, string tenBaoCao, string tenHang)
        {
            InitializeComponent();
            this.hanhDong = hanhDong;
            this.congty = congty;
            this.nhomhanghoa = nhomhanghoa;
            this.theoKy = theoKy;
            this.ma = ma;
            this.maNhanVien = maNhanVien;
            this.tenBaoCao = tenBaoCao;
            this.tenHang = tenHang;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="congty"></param>
        /// <param name="data"></param>
        /// <param name="theoKy"></param>
        /// <param name="maKho"></param>
        public frmBaoCaoNhapHang(string hanhDong, Entities.ThongTinCongTy congty, Entities.XuatNhapTonTheoNhomHangHoa[] nhomHang, string theoKy, string ma, string maNhanVien, string tenBaoCao, string tenNhom)
        {
            InitializeComponent();
            this.hanhDong = hanhDong;
            this.congty = congty;
            this.nhomHang = nhomHang;
            this.theoKy = theoKy;
            this.ma = ma;
            this.maNhanVien = maNhanVien;
            this.tenBaoCao = tenBaoCao;
            this.tenNhom = tenNhom;
        }
        /// <summary>
        /// show
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBaoCaoNhapHang_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.hanhDong != null)
                {
                    switch (this.hanhDong)
                    {
                        case "KhoHang":
                            {
                                GUI.Report.rptBaoCaoNhapHangTheoTungKho kho = new GUI.Report.rptBaoCaoNhapHangTheoTungKho();
                                kho.SetDataSource(data);
                                rptView.ReportSource = kho;
                                kho.SetParameterValue("TenCongTy", this.congty.TenCongTy);
                                kho.SetParameterValue("DiaChiCongTy", this.congty.DiaChi);
                                kho.SetParameterValue("DienThoai", this.congty.SoDienThoai);
                                kho.SetParameterValue("FaxCongTy", this.congty.Fax);
                                kho.SetParameterValue("Web", this.congty.Website);
                                kho.SetParameterValue("Email", this.congty.Email);
                                kho.SetParameterValue("TenBaoCao", this.tenBaoCao);
                                kho.SetParameterValue("Ky", this.theoKy);
                                kho.SetParameterValue("MaNhanVien", this.maNhanVien);
                                kho.SetParameterValue("MaKho", this.ma);
                                rptView.Show();
                            } break;
                        case "MatHang":
                            {
                                GUI.Report.rptBaoCaoNhapHangTheoMatHang hang = new GUI.Report.rptBaoCaoNhapHangTheoMatHang();
                                hang.SetDataSource(mathang);
                                rptView.ReportSource = hang;
                                hang.SetParameterValue("TenCongTy", this.congty.TenCongTy);
                                hang.SetParameterValue("DiaChiCongTy", this.congty.DiaChi);
                                hang.SetParameterValue("DienThoai", this.congty.SoDienThoai);
                                hang.SetParameterValue("FaxCongTy", this.congty.Fax);
                                hang.SetParameterValue("Web", this.congty.Website);
                                hang.SetParameterValue("Email", this.congty.Email);
                                hang.SetParameterValue("TenBaoCao", this.tenBaoCao);
                                hang.SetParameterValue("Ky", this.theoKy);
                                hang.SetParameterValue("MaNhanVien", this.maNhanVien);
                                hang.SetParameterValue("MaHangHoa", this.ma);
                                hang.SetParameterValue("TenHangHoa", this.tenHang);
                                rptView.Show();
                            } break;
                        case "NhomHang":
                            {
                                GUI.Report.rptBaoCaoNhaphangTheoNhomHang nhom = new GUI.Report.rptBaoCaoNhaphangTheoNhomHang();
                                nhom.SetDataSource(nhomhanghoa);
                                rptView.ReportSource = nhom;
                                nhom.SetParameterValue("TenCongTy", this.congty.TenCongTy);
                                nhom.SetParameterValue("DiaChiCongTy", this.congty.DiaChi);
                                nhom.SetParameterValue("DienThoai", this.congty.SoDienThoai);
                                nhom.SetParameterValue("FaxCongTy", this.congty.Fax);
                                nhom.SetParameterValue("Web", this.congty.Website);
                                nhom.SetParameterValue("Email", this.congty.Email);
                                nhom.SetParameterValue("TenBaoCao", this.tenBaoCao);
                                nhom.SetParameterValue("Ky", this.theoKy);
                                nhom.SetParameterValue("MaNhanVien", this.maNhanVien);
                                nhom.SetParameterValue("MaNhomHang", this.ma);
                                nhom.SetParameterValue("TenNhomHangHoa", this.tenHang);
                                rptView.Show();
                            } break;
                        case "XuatNhapTonTheoNhomHang":
                            {
                                GUI.Report.rptXuatNhapHangTheoNhomHang nhom = new GUI.Report.rptXuatNhapHangTheoNhomHang();
                                nhom.SetDataSource(this.nhomHang);
                                rptView.ReportSource = nhom;
                                nhom.SetParameterValue("TenCongTy", this.congty.TenCongTy);
                                nhom.SetParameterValue("DiaChiCongTy", this.congty.DiaChi);
                                nhom.SetParameterValue("DienThoai", this.congty.SoDienThoai);
                                nhom.SetParameterValue("FaxCongTy", this.congty.Fax);
                                nhom.SetParameterValue("Web", this.congty.Website);
                                nhom.SetParameterValue("Email", this.congty.Email);
                                nhom.SetParameterValue("TenBaoCao", this.tenBaoCao);
                                nhom.SetParameterValue("Ky", this.theoKy);
                                nhom.SetParameterValue("MaNhanVien", this.maNhanVien);
                                nhom.SetParameterValue("MaNhom", this.ma);
                                nhom.SetParameterValue("TenNhomHang", this.tenNhom);
                                rptView.Show();
                            } break;
                        default:
                            {
                                MessageBox.Show("Không có dữ liệu hiển thị");
                                this.Close();
                            } break;
                    }
                }
                else
                { }
            }
            catch (Exception ex)
            { string s = ex.Message; MessageBox.Show("Thất bại"); this.Close(); }
        }

        private void toolStripStatus_Dong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
                else
                { }
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
