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
using System.Data.SqlClient;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;
using System.Collections;

namespace GUI
{
    public partial class frmBaoCaorpt : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        public frmBaoCaorpt()
        {
            InitializeComponent();
        }
        public frmBaoCaorpt(CrystalDecisions.CrystalReports.Engine.ReportClass report)
        {
            CongTy();
            InitializeComponent();
            try
            {
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                crvReport.Show();
            }
            catch { }
        }
        public frmBaoCaorpt(CrystalDecisions.CrystalReports.Engine.ReportClass report, string path, Report.ExportCrystalReport.TypeBC type)
        {
            CongTy();
            try
            {
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                bool tv = new GUI.Report.ExportCrystalReport().Export(report, path, type);
            }
            catch { }
        }
        Server_Client.Client cl;
        public frmBaoCaorpt(string hanhDong)
        {
            try
            {
                InitializeComponent();
                switch (hanhDong)
                {
                    case "Test":
                        {
                            Entities.KhachHang[] kh1 = new Entities.KhachHang[0];
                            GUI.Report.rptBCCongNoKhachHang report = new GUI.Report.rptBCCongNoKhachHang();
                            report.SetDataSource(kh1);
                            crvReport.ReportSource = report;
                            report.SetParameterValue("TenCongTy", CT.TenCongTy);
                            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                            report.SetParameterValue("DienThoai", CT.SoDienThoai);
                            report.SetParameterValue("FaxCongTy", CT.Fax);
                            report.SetParameterValue("Web", CT.Website);
                            report.SetParameterValue("TenBaoCao", "Báo Cáo Công Nợ Khách Hàng");
                            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                            report.SetParameterValue("Email", CT.Email);
                            crvReport.Show();
                            break;
                        }
                    case "KhachHang":
                        {
                            CongTy();
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.KhachHang kh = new Entities.KhachHang("Select");
                            Entities.KhachHang[] kh1 = new Entities.KhachHang[1];
                            clientstrem = cl.SerializeObj(this.client1, "KhachHang", kh);
                            kh1 = (Entities.KhachHang[])cl.DeserializeHepper1(clientstrem, kh1);
                            if (kh1 == null)
                            {
                                MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                                return;
                            }
                            GUI.Report.rptBCCongNoKhachHang report = new GUI.Report.rptBCCongNoKhachHang();
                            report.SetDataSource(kh1);
                            crvReport.ReportSource = report;
                            report.SetParameterValue("TenCongTy", CT.TenCongTy);
                            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                            report.SetParameterValue("DienThoai", CT.SoDienThoai);
                            report.SetParameterValue("FaxCongTy", CT.Fax);
                            report.SetParameterValue("Web", CT.Website);
                            report.SetParameterValue("TenBaoCao", "Báo Cáo Công Nợ Khách Hàng");
                            report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                            report.SetParameterValue("Email", CT.Email);
                            crvReport.Show();
                            break;
                        }
                    case "ChiTietHangHoa":
                        {
                            CongTy();
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.rptBCChiTietHangHoa kh = new Entities.rptBCChiTietHangHoa("Select");
                            Entities.rptBCChiTietHangHoa[] kh1 = new Entities.rptBCChiTietHangHoa[1];
                            clientstrem = cl.SerializeObj(this.client1, "BCChiTietHangHoa", kh);
                            kh1 = (Entities.rptBCChiTietHangHoa[])cl.DeserializeHepper1(clientstrem, kh1);
                            if (kh1 == null)
                            {
                                MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                                return;
                            }
                            GUI.Report.rptBCChiTietHangHoa report = new GUI.Report.rptBCChiTietHangHoa();
                            report.SetDataSource(kh1);
                            crvReport.ReportSource = report;
                            report.SetParameterValue("TenCongTy", CT.TenCongTy);
                            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                            report.SetParameterValue("DienThoai", CT.SoDienThoai);
                            report.SetParameterValue("FaxCongTy", CT.Fax);
                            report.SetParameterValue("Web", CT.Website);
                            report.SetParameterValue("TenBaoCao", "Báo Cáo Chi Tiết Hàng Hóa");
                            report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                            report.SetParameterValue("Email", CT.Email);
                            crvReport.Show();
                            break;
                        }
                    case "NCC":
                        {
                            CongTy();
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.NhaCungCap kh = new Entities.NhaCungCap("Select");
                            Entities.NhaCungCap[] kh1 = new Entities.NhaCungCap[1];
                            clientstrem = cl.SerializeObj(this.client1, "NhaCungCap", kh);
                            kh1 = (Entities.NhaCungCap[])cl.DeserializeHepper1(clientstrem, kh1);
                            if (kh1 == null)
                            {
                                MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                                return;
                            }
                            GUI.Report.rptBCCongNoNCC report = new GUI.Report.rptBCCongNoNCC();
                            report.SetDataSource(kh1);
                            crvReport.ReportSource = report;
                            report.SetParameterValue("TenCongTy", CT.TenCongTy);
                            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                            report.SetParameterValue("DienThoai", CT.SoDienThoai);
                            report.SetParameterValue("FaxCongTy", CT.Fax);
                            report.SetParameterValue("Web", CT.Website);
                            report.SetParameterValue("TenBaoCao", "Báo Cáo Công Nợ Nhà Cung Cấp");
                            report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                            report.SetParameterValue("Email", CT.Email);
                            crvReport.Show();
                            break;
                        }

                    default: break;
                }
            }
            catch
            {
            }
        }
        public frmBaoCaorpt(string hanhdong, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                switch (hanhdong)
                {
                    case "KhachHang":
                        {
                            CongTy();
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.KhachHang kh = new Entities.KhachHang("Select");
                            Entities.KhachHang[] kh1 = new Entities.KhachHang[1];
                            clientstrem = cl.SerializeObj(this.client1, "KhachHang", kh);
                            kh1 = (Entities.KhachHang[])cl.DeserializeHepper1(clientstrem, kh1);
                            if (kh1 == null)
                            {
                                MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                                return;
                            }
                            GUI.Report.rptBCCongNoKhachHang report = new GUI.Report.rptBCCongNoKhachHang();
                            report.SetDataSource(kh1);
                            crvReport.ReportSource = report;
                            report.SetParameterValue("TenCongTy", CT.TenCongTy);
                            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                            report.SetParameterValue("DienThoai", CT.SoDienThoai);
                            report.SetParameterValue("FaxCongTy", CT.Fax);
                            report.SetParameterValue("Web", CT.Website);
                            report.SetParameterValue("TenBaoCao", "Báo Cáo Công Nợ Khách Hàng");
                            report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                            report.SetParameterValue("Email", CT.Email);
                            if (hanhDong == "Excel")
                            {
                                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                            }
                            else if (hanhDong == "Word")
                            {
                                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                            }
                            else if (hanhDong == "PDF")
                            {
                                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                            }
                            break;
                        }
                    case "ChiTietHangHoa":
                        {
                            CongTy();
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.rptBCChiTietHangHoa kh = new Entities.rptBCChiTietHangHoa("Select");
                            Entities.rptBCChiTietHangHoa[] kh1 = new Entities.rptBCChiTietHangHoa[1];
                            clientstrem = cl.SerializeObj(this.client1, "BCChiTietHangHoa", kh);
                            kh1 = (Entities.rptBCChiTietHangHoa[])cl.DeserializeHepper1(clientstrem, kh1);
                            if (kh1 == null)
                            {
                                MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                                return;
                            }
                            GUI.Report.rptBCChiTietHangHoa report = new GUI.Report.rptBCChiTietHangHoa();
                            report.SetDataSource(kh1);
                            crvReport.ReportSource = report;
                            report.SetParameterValue("TenCongTy", CT.TenCongTy);
                            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                            report.SetParameterValue("DienThoai", CT.SoDienThoai);
                            report.SetParameterValue("FaxCongTy", CT.Fax);
                            report.SetParameterValue("Web", CT.Website);
                            report.SetParameterValue("TenBaoCao", "Báo Cáo Chi Tiết Hàng Hóa");
                            report.SetParameterValue("NgayTao", DateServer.Date());
                            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                            report.SetParameterValue("Email", CT.Email);
                            if (hanhDong == "Excel")
                            {
                                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                            }
                            else if (hanhDong == "Word")
                            {
                                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                            }
                            else if (hanhDong == "PDF")
                            {
                                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                            }
                            break;
                        }
                    case "NCC":
                        {
                            CongTy();
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.NhaCungCap kh = new Entities.NhaCungCap("Select");
                            Entities.NhaCungCap[] kh1 = new Entities.NhaCungCap[1];
                            clientstrem = cl.SerializeObj(this.client1, "NhaCungCap", kh);
                            kh1 = (Entities.NhaCungCap[])cl.DeserializeHepper1(clientstrem, kh1);
                            if (kh1 == null)
                            {
                                MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                                return;
                            }
                            GUI.Report.rptBCCongNoNCC report = new GUI.Report.rptBCCongNoNCC();
                            report.SetDataSource(kh1);
                            crvReport.ReportSource = report;
                            report.SetParameterValue("TenCongTy", CT.TenCongTy);
                            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                            report.SetParameterValue("DienThoai", CT.SoDienThoai);
                            report.SetParameterValue("FaxCongTy", CT.Fax);
                            report.SetParameterValue("Web", CT.Website);
                            report.SetParameterValue("TenBaoCao", "Báo Cáo Công Nợ Nhà Cung Cấp");
                            report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                            report.SetParameterValue("Email", CT.Email);
                            if (hanhDong == "Excel")
                            {
                                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                            }
                            else if (hanhDong == "Word")
                            {
                                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                            }
                            else if (hanhDong == "PDF")
                            {
                                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                            }
                            break;
                        }

                    default: break;
                }
            }
            catch
            {
            }
        }
        public frmBaoCaorpt(Entities.BCDTTheoHangHoa[] pt1, DateTime truoc, DateTime sau, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCDoanhThuTheoMatHang report = new GUI.Report.rptBCDoanhThuTheoMatHang();
                report.SetDataSource(pt1);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Doanh Thu Theo Hàng Hóa");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("tuNgay", new Common.Utilities().XuLy(2, truoc.ToShortDateString()));
                report.SetParameterValue("DenNgay", new Common.Utilities().XuLy(2, sau.ToShortDateString()));
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch
            {
            }
        }
        public frmBaoCaorpt(Entities.BCMucTonToiThieuToiDa[] pt1, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCMucTonToiThieuToiDa report = new GUI.Report.rptBCMucTonToiThieuToiDa();
                report.SetDataSource(pt1);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Mức Tồn Tối Thiểu Tối Đa");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch
            {
            }
        }
        public frmBaoCaorpt(Entities.BCMucTonToiThieuToiDa[] pt1)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCMucTonToiThieuToiDa report = new GUI.Report.rptBCMucTonToiThieuToiDa();
                report.SetDataSource(pt1);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Mức Tồn Tối Thiểu Tối Đa");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                crvReport.Show();
            }
            catch
            {
            }
        }
        public frmBaoCaorpt(Entities.TimKiemChungTu[] pt1, DateTime tu, DateTime den, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptTimKiemChungTu report = new GUI.Report.rptTimKiemChungTu();
                report.SetDataSource(pt1);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Tìm Kiếm Chứng Từ Theo Điều Kiện");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
                report.SetParameterValue("Den", new Common.Utilities().XuLy(2, den.ToShortDateString()));
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch
            {
            }
        }
        //////////////////////////////////////////////////////////////////////////////////MRK FIX
        //public frmBaoCaorpt(Entities.BCNhapHangTheoThoiGianChiTiet[] pt1, DateTime tu, DateTime den, string a, string path, string hanhDong)
        //{
        //    try
        //    {
        //        InitializeComponent();
        //        CongTy();
        //        GUI.Report.rptBCXuatHangTheoThoiGian report = new GUI.Report.rptBCXuatHangTheoThoiGian();
        //        report.SetDataSource(pt1);
        //        crvReport.ReportSource = report;
        //        report.SetParameterValue("TenCongTy", CT.TenCongTy);
        //        report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
        //        report.SetParameterValue("DienThoai", CT.SoDienThoai);
        //        report.SetParameterValue("FaxCongTy", CT.Fax);
        //        report.SetParameterValue("Web", CT.Website);
        //        report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Hàng Theo Thời Gian");
        //        report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
        //        report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
        //        report.SetParameterValue("Email", CT.Email);
        //        report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
        //        report.SetParameterValue("Den", new Common.Utilities().XuLy(2, den.ToShortDateString()));
        //        if (hanhDong == "Excel")
        //        {
        //            new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
        //        }
        //        else if (hanhDong == "Word")
        //        {
        //            new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
        //        }
        //        else if (hanhDong == "PDF")
        //        {
        //            new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}
        //public frmBaoCaorpt(Entities.BCNhapHangTheoThoiGianChiTiet[] pt1, DateTime tu, DateTime den, string a)
        //{
        //    try
        //    {
        //        InitializeComponent();
        //        CongTy();
        //        GUI.Report.rptBCXuatHangTheoThoiGian report = new GUI.Report.rptBCXuatHangTheoThoiGian();
        //        report.SetDataSource(pt1);
        //        crvReport.ReportSource = report;
        //        report.SetParameterValue("TenCongTy", CT.TenCongTy);
        //        report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
        //        report.SetParameterValue("DienThoai", CT.SoDienThoai);
        //        report.SetParameterValue("FaxCongTy", CT.Fax);
        //        report.SetParameterValue("Web", CT.Website);
        //        report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Hàng Theo Thời Gian");
        //        report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
        //        report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
        //        report.SetParameterValue("Email", CT.Email);
        //        report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
        //        report.SetParameterValue("Den", new Common.Utilities().XuLy(2, den.ToShortDateString()));
        //        crvReport.Show();
        //    }
        //    catch
        //    {
        //    }
        //}
        //public frmBaoCaorpt(Entities.BCNhapHangTheoThoiGianChiTiet[] pt1, DateTime tu, DateTime den, string path, string hanhDong)
        //{
        //    try
        //    {
        //        InitializeComponent();
        //        CongTy();
        //        GUI.Report.rptBCNhapHangTheoThoiGian report = new GUI.Report.rptBCNhapHangTheoThoiGian();
        //        report.SetDataSource(pt1);
        //        crvReport.ReportSource = report;
        //        report.SetParameterValue("TenCongTy", CT.TenCongTy);
        //        report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
        //        report.SetParameterValue("DienThoai", CT.SoDienThoai);
        //        report.SetParameterValue("FaxCongTy", CT.Fax);
        //        report.SetParameterValue("Web", CT.Website);
        //        report.SetParameterValue("TenBaoCao", "Báo Cáo Nhập Hàng Theo Thời Gian");
        //        report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
        //        report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
        //        report.SetParameterValue("Email", CT.Email);
        //        report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
        //        report.SetParameterValue("Den", new Common.Utilities().XuLy(2, den.ToShortDateString()));
        //        if (hanhDong == "Excel")
        //        {
        //            new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
        //        }
        //        else if (hanhDong == "Word")
        //        {
        //            new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
        //        }
        //        else if (hanhDong == "PDF")
        //        {
        //            new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}
        //public frmBaoCaorpt(Entities.BCNhapHangTheoThoiGianChiTiet[] pt1, DateTime tu, DateTime den)
        //{
        //    try
        //    {
        //        InitializeComponent();
        //        CongTy();
        //        GUI.Report.rptBCNhapHangTheoThoiGian report = new GUI.Report.rptBCNhapHangTheoThoiGian();
        //        report.SetDataSource(pt1);
        //        crvReport.ReportSource = report;
        //        report.SetParameterValue("TenCongTy", CT.TenCongTy);
        //        report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
        //        report.SetParameterValue("DienThoai", CT.SoDienThoai);
        //        report.SetParameterValue("FaxCongTy", CT.Fax);
        //        report.SetParameterValue("Web", CT.Website);
        //        report.SetParameterValue("TenBaoCao", "Báo Cáo Nhập Hàng Theo Thời Gian");
        //        report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
        //        report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
        //        report.SetParameterValue("Email", CT.Email);
        //        report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
        //        report.SetParameterValue("Den", new Common.Utilities().XuLy(2, den.ToShortDateString()));
        //        crvReport.Show();
        //    }
        //    catch
        //    {
        //    }
        //}
        /////////////////////////////////////////////////////////////////////////////////
        public frmBaoCaorpt(Entities.BCNhapHangTheoThoiGianChiTiet[] pt1, DateTime tu, DateTime den, string a, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCXuatHangTheoThoiGian report = new GUI.Report.rptBCXuatHangTheoThoiGian();
                report.SetDataSource(pt1);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Hàng Theo Thời Gian");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
                report.SetParameterValue("Den", new Common.Utilities().XuLy(2, den.ToShortDateString()));
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch
            {
            }
        }
        public frmBaoCaorpt(Entities.BCNhapHangTheoThoiGianChiTiet[] pt1, DateTime tu, DateTime den, string a)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCXuatHangTheoThoiGian report = new GUI.Report.rptBCXuatHangTheoThoiGian();
                report.SetDataSource(pt1);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Hàng Theo Thời Gian");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
                report.SetParameterValue("Den", new Common.Utilities().XuLy(2, den.ToShortDateString()));
                crvReport.Show();
            }
            catch
            {
            }
        }

        public frmBaoCaorpt(Entities.ChiTietKhoHang[] pt1, DateTime tu, DateTime den, string action, string path)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBaoCaoHanSuDung report = new GUI.Report.rptBaoCaoHanSuDung();
                report.SetDataSource(pt1);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Hạn Sử Dụng");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
                report.SetParameterValue("Den", new Common.Utilities().XuLy(2, den.ToShortDateString()));

                if (action == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (action == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (action == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
                else if (action == "In")
                {
                    crvReport.Show();
                }
            }
            catch
            {
            }
        }

        public frmBaoCaorpt(Entities.TongHopThuChi[] pt1, DateTime tu, DateTime den, string action, string path, double dauKy, double cuoiKy)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBaoCaoTongHopThuChi report = new GUI.Report.rptBaoCaoTongHopThuChi();
                report.SetDataSource(pt1);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Tổng Hợp Thu Chi");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
                report.SetParameterValue("Den", new Common.Utilities().XuLy(2, den.ToShortDateString()));
                report.SetParameterValue("DuDauKy", dauKy);
                report.SetParameterValue("DuCuoiKy", cuoiKy);

                if (action == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (action == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (action == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
                else if (action == "In")
                {
                    crvReport.Show();
                }
            }
            catch
            {
            }
        }

        public frmBaoCaorpt(Entities.TongHopCongNo[] pt1, string thang, string nam, string action, string path, string doiTuong, string TenDoiTuong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                if (doiTuong.Equals("KH"))
                {
                    GUI.Report.rptTongHopCongNoKH report = new GUI.Report.rptTongHopCongNoKH();
                    report.SetDataSource(pt1);
                    crvReport.ReportSource = report;
                    report.SetParameterValue("TenCongTy", CT.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                    report.SetParameterValue("DienThoai", CT.SoDienThoai);
                    report.SetParameterValue("FaxCongTy", CT.Fax);
                    report.SetParameterValue("Web", CT.Website);
                    report.SetParameterValue("TenBaoCao", "Tổng Hợp Công Nợ " + TenDoiTuong);
                    report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                    report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                    report.SetParameterValue("Email", CT.Email);
                    report.SetParameterValue("Thang", thang);
                    report.SetParameterValue("Nam", nam);

                    if (action == "Excel")
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                    }
                    else if (action == "Word")
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                    }
                    else if (action == "PDF")
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                    }
                    else if (action == "In")
                    {
                        crvReport.Show();
                    }
                }
                else if (doiTuong.Equals("NCC"))
                {
                    GUI.Report.rptTongHopCongNoNCC report = new GUI.Report.rptTongHopCongNoNCC();
                    report.SetDataSource(pt1);
                    crvReport.ReportSource = report;
                    report.SetParameterValue("TenCongTy", CT.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                    report.SetParameterValue("DienThoai", CT.SoDienThoai);
                    report.SetParameterValue("FaxCongTy", CT.Fax);
                    report.SetParameterValue("Web", CT.Website);
                    report.SetParameterValue("TenBaoCao", "Tổng Hợp Công Nợ " + TenDoiTuong);
                    report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                    report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                    report.SetParameterValue("Email", CT.Email);
                    report.SetParameterValue("Thang", thang);
                    report.SetParameterValue("Nam", nam);

                    if (action == "Excel")
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                    }
                    else if (action == "Word")
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                    }
                    else if (action == "PDF")
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                    }
                    else if (action == "In")
                    {
                        crvReport.Show();
                    }
                }
            }
            catch
            {
            }
        }

        public frmBaoCaorpt(Entities.ChiTietCongNo[] pt1, string maKhachHang, string tenKhachHang, string diaChi, double duDauKy, double duCuoiKy, string action, string path, string doiTuong, string TenDoiTuong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                if (doiTuong.Equals("KH"))
                {
                    GUI.Report.rptChiTietCongNoKH report = new GUI.Report.rptChiTietCongNoKH();
                    report.SetDataSource(pt1);
                    crvReport.ReportSource = report;
                    report.SetParameterValue("TenCongTy", CT.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                    report.SetParameterValue("DienThoai", CT.SoDienThoai);
                    report.SetParameterValue("FaxCongTy", CT.Fax);
                    report.SetParameterValue("Web", CT.Website);
                    report.SetParameterValue("TenBaoCao", "Chi Tiết Công Nợ " + TenDoiTuong);
                    report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                    report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                    report.SetParameterValue("Email", CT.Email);
                    report.SetParameterValue("MaKhachHang", maKhachHang);
                    report.SetParameterValue("TenKhachHang", tenKhachHang);
                    report.SetParameterValue("DiaChi", diaChi);
                    report.SetParameterValue("DuDauKy", duDauKy);
                    report.SetParameterValue("DuCuoiKy", duCuoiKy);
                    if (action == "Excel")
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                    }
                    else if (action == "Word")
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                    }
                    else if (action == "PDF")
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                    }
                    else if (action == "In")
                    {
                        crvReport.Show();
                    }
                }
                else if (doiTuong.Equals("NCC"))
                {
                    GUI.Report.rptChiTietCongNoNCC report = new GUI.Report.rptChiTietCongNoNCC();
                    report.SetDataSource(pt1);
                    crvReport.ReportSource = report;
                    report.SetParameterValue("TenCongTy", CT.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                    report.SetParameterValue("DienThoai", CT.SoDienThoai);
                    report.SetParameterValue("FaxCongTy", CT.Fax);
                    report.SetParameterValue("Web", CT.Website);
                    report.SetParameterValue("TenBaoCao", "Chi Tiết Công Nợ " + TenDoiTuong);
                    report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                    report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                    report.SetParameterValue("Email", CT.Email);
                    report.SetParameterValue("MaKhachHang", maKhachHang);
                    report.SetParameterValue("TenKhachHang", tenKhachHang);
                    report.SetParameterValue("DiaChi", diaChi);
                    report.SetParameterValue("DuDauKy", duDauKy);
                    report.SetParameterValue("DuCuoiKy", duCuoiKy);

                    if (action == "Excel")
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                    }
                    else if (action == "Word")
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                    }
                    else if (action == "PDF")
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                    }
                    else if (action == "In")
                    {
                        crvReport.Show();
                    }
                }
            }
            catch
            {
            }
        }

        public frmBaoCaorpt(Entities.BCNhapHangTheoThoiGianChiTiet[] pt1, DateTime tu, DateTime den, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCNhapHangTheoThoiGian report = new GUI.Report.rptBCNhapHangTheoThoiGian();
                report.SetDataSource(pt1);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Nhập Hàng Theo Thời Gian");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
                report.SetParameterValue("Den", new Common.Utilities().XuLy(2, den.ToShortDateString()));
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch
            {
            }
        }
        public frmBaoCaorpt(Entities.BCNhapHangTheoThoiGianChiTiet[] pt1, DateTime tu, DateTime den)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCNhapHangTheoThoiGian report = new GUI.Report.rptBCNhapHangTheoThoiGian();
                report.SetDataSource(pt1);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Nhập Hàng Theo Thời Gian");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
                report.SetParameterValue("Den", new Common.Utilities().XuLy(2, den.ToShortDateString()));
                crvReport.Show();
            }
            catch
            {
            }
        }
        public frmBaoCaorpt(Entities.TimKiemChungTu[] pt1, DateTime tu, DateTime den)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptTimKiemChungTu report = new GUI.Report.rptTimKiemChungTu();
                report.SetDataSource(pt1);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Tìm Kiếm Chứng Từ Theo Điều Kiện");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
                report.SetParameterValue("Den", new Common.Utilities().XuLy(2, den.ToShortDateString()));
                crvReport.Show();
            }
            catch
            {
            }
        }
        public frmBaoCaorpt(Entities.BCDTTheoHangHoa[] pt1, DateTime truoc, DateTime sau)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCDoanhThuTheoMatHang report = new GUI.Report.rptBCDoanhThuTheoMatHang();
                report.SetDataSource(pt1);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Doanh Thu Theo Hàng Hóa");
                report.SetParameterValue("NgayTao", DateServer.Date().ToString("dd/MM/yyyy"));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("tuNgay", truoc.ToString("dd/MM/yyyy"));
                report.SetParameterValue("DenNgay", sau.ToString("dd/MM/yyyy")));
                crvReport.Show();
            }
            catch
            {
            }
        }

        public frmBaoCaorpt(Entities.BCDTTheoNhomHang[] pt1, DateTime truoc, DateTime sau, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCDoanhThuTheoNhomHang report = new GUI.Report.rptBCDoanhThuTheoNhomHang();
                report.SetDataSource(pt1);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Doanh Thu Theo Nhóm Hàng");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("tuNgay", new Common.Utilities().XuLy(2, truoc.ToShortDateString()));
                report.SetParameterValue("DenNgay", new Common.Utilities().XuLy(2, sau.ToShortDateString()));
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch
            {
            }
        }

        public frmBaoCaorpt(Entities.BCDTTheoNhomHang[] pt1, DateTime truoc, DateTime sau)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCDoanhThuTheoNhomHang report = new GUI.Report.rptBCDoanhThuTheoNhomHang();
                report.SetDataSource(pt1);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Doanh Thu Theo Nhóm Hàng");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("tuNgay", new Common.Utilities().XuLy(2, truoc.ToShortDateString()));
                report.SetParameterValue("DenNgay", new Common.Utilities().XuLy(2, sau.ToShortDateString()));
                crvReport.Show();
            }
            catch
            {
            }
        }
        public frmBaoCaorpt(string hanhdong, string ma, DateTime truoc, DateTime sau, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                switch (hanhdong)
                {
                    case "NhanVien":
                        {
                            CongTy();
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.BCDTTheoNhanVien ctxh = new Entities.BCDTTheoNhanVien("SelectTheoMa", ma, truoc, sau);
                            Entities.BCDTTheoNhanVien[] pt1 = new Entities.BCDTTheoNhanVien[1];
                            clientstrem = cl.SerializeObj(this.client1, "BCDTTheoNhanVien", ctxh);
                            pt1 = (Entities.BCDTTheoNhanVien[])cl.DeserializeHepper1(clientstrem, pt1);
                            if (pt1 == null)
                            {
                                MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                                return;
                            }
                            //cập nhật tổng tiền thực thu
                            foreach (Entities.BCDTTheoNhanVien item in pt1)
                            {
                                List<double> bientam = TienIch.TinhDoanhThu(item.TongTienThanhToan, item.GiaTriThe, item.GiaTriTheGiaTri);
                                item.TongTienThanhToan = bientam[0];
                                item.GiaTriThe = bientam[1];
                                item.GiaTriTheGiaTri = bientam[2];
                                item.TongTienThucThu = bientam[3];
                            }
                            GUI.Report.rptBCDoanhThuTheoMaNhanVien report = new GUI.Report.rptBCDoanhThuTheoMaNhanVien();
                            report.SetDataSource(pt1);
                            crvReport.ReportSource = report;
                            report.SetParameterValue("TenCongTy", CT.TenCongTy);
                            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                            report.SetParameterValue("DienThoai", CT.SoDienThoai);
                            report.SetParameterValue("FaxCongTy", CT.Fax);
                            report.SetParameterValue("Web", CT.Website);
                            report.SetParameterValue("TenBaoCao", "Báo Cáo Doanh Thu Theo Nhân Viên");
                            report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                            report.SetParameterValue("Email", CT.Email);
                            report.SetParameterValue("tuNgay", new Common.Utilities().XuLy(2, truoc.ToShortDateString()));
                            report.SetParameterValue("DenNgay", new Common.Utilities().XuLy(2, sau.ToShortDateString()));
                            if (hanhDong == "Excel")
                            {
                                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                            }
                            else if (hanhDong == "Word")
                            {
                                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                            }
                            else if (hanhDong == "PDF")
                            {
                                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                            }
                            break;
                        }
                    default: break;
                }
            }
            catch
            {
            }
        }

        public frmBaoCaorpt(string hanhDong, string ma, DateTime truoc, DateTime sau)
        {
            try
            {
                InitializeComponent();
                switch (hanhDong)
                {
                    case "NhanVien":
                        {
                            CongTy();
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.BCDTTheoNhanVien ctxh = new Entities.BCDTTheoNhanVien("SelectTheoMa", ma, truoc, sau);
                            Entities.BCDTTheoNhanVien[] pt1 = new Entities.BCDTTheoNhanVien[1];
                            clientstrem = cl.SerializeObj(this.client1, "BCDTTheoNhanVien", ctxh);
                            pt1 = (Entities.BCDTTheoNhanVien[])cl.DeserializeHepper1(clientstrem, pt1);
                            if (pt1 == null)
                            {
                                MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                                return;
                            }
                            //Tổng tiền thực thu
                            foreach (Entities.BCDTTheoNhanVien item in pt1)
                            {
                                List<double> bientam = TienIch.TinhDoanhThu(item.TongTienThanhToan, item.GiaTriThe, item.GiaTriTheGiaTri);
                                item.TongTienThanhToan = bientam[0];
                                item.GiaTriThe = bientam[1];
                                item.GiaTriTheGiaTri = bientam[2];
                                item.TongTienThucThu = bientam[3];
                            }
                            GUI.Report.rptBCDoanhThuTheoMaNhanVien report = new GUI.Report.rptBCDoanhThuTheoMaNhanVien();
                            report.SetDataSource(pt1);
                            crvReport.ReportSource = report;
                            report.SetParameterValue("TenCongTy", CT.TenCongTy);
                            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                            report.SetParameterValue("DienThoai", CT.SoDienThoai);
                            report.SetParameterValue("FaxCongTy", CT.Fax);
                            report.SetParameterValue("Web", CT.Website);
                            report.SetParameterValue("TenBaoCao", "Báo Cáo Doanh Thu Theo Nhân Viên");
                            report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                            report.SetParameterValue("Email", CT.Email);
                            report.SetParameterValue("tuNgay", new Common.Utilities().XuLy(2, truoc.ToShortDateString()));
                            report.SetParameterValue("DenNgay", new Common.Utilities().XuLy(2, sau.ToShortDateString()));
                            crvReport.Show();
                            break;
                        }
                    default: break;
                }
            }
            catch
            {
            }
        }
        public string xulyNgay(DateTime dt)
        {
            string mk;
            string dd = dt.Day.ToString();
            if (dd.Length == 1)
            {
                dd = "0" + dd;
            }
            string mm = dt.Month.ToString();
            if (mm.Length == 1)
            {
                mm = "0" + mm;
            }
            string yyyy = dt.Year.ToString();

            mk = dd + "/" + mm + "/" + yyyy;

            return mk;
        }
        public frmBaoCaorpt(Entities.CTBCNhapHangTheoKho[] ctBCXH, DateTime truoc, DateTime sau)
        {
            InitializeComponent(); CongTy();
            GUI.Report.BCNhapHangTheoKho report = new GUI.Report.BCNhapHangTheoKho();
            report.SetDataSource(ctBCXH);
            crvReport.ReportSource = report;
            report.SetParameterValue("TenCongTy", CT.TenCongTy);
            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
            report.SetParameterValue("DienThoai", CT.SoDienThoai);
            report.SetParameterValue("FaxCongTy", CT.Fax);
            report.SetParameterValue("Web", CT.Website);
            report.SetParameterValue("TenBaoCao", "Báo Cáo Nhập Hàng Theo Kho Hàng");
            report.SetParameterValue("NgayTao", xulyNgay(DateServer.Date()));
            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
            report.SetParameterValue("Email", CT.Email);
            report.SetParameterValue("tuNgay", xulyNgay(truoc));
            report.SetParameterValue("DenNgay", xulyNgay(sau));
            crvReport.Show();
        }
        public frmBaoCaorpt(Entities.CTBCNhapHangTheoKho[] ctBCXH, DateTime truoc, DateTime sau, string path, string hanhDong)
        {
            InitializeComponent(); CongTy();
            GUI.Report.BCNhapHangTheoKho report = new GUI.Report.BCNhapHangTheoKho();
            report.SetDataSource(ctBCXH);
            crvReport.ReportSource = report;
            report.SetParameterValue("TenCongTy", CT.TenCongTy);
            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
            report.SetParameterValue("DienThoai", CT.SoDienThoai);
            report.SetParameterValue("FaxCongTy", CT.Fax);
            report.SetParameterValue("Web", CT.Website);
            report.SetParameterValue("TenBaoCao", "Báo Cáo Nhập Hàng Theo Kho Hàng");
            report.SetParameterValue("NgayTao", xulyNgay(DateServer.Date()));
            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
            report.SetParameterValue("Email", CT.Email);
            report.SetParameterValue("tuNgay", xulyNgay(truoc));
            report.SetParameterValue("DenNgay", xulyNgay(sau));
            if (hanhDong == "Excel")
            {
                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
            }
            else if (hanhDong == "Word")
            {
                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
            }
            else if (hanhDong == "PDF")
            {
                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
            }
        }
        public frmBaoCaorpt(Entities.ChiTietBCXuatHangTheoTungKho[] ctBCXH, DateTime truoc, DateTime sau)
        {
            InitializeComponent(); CongTy();
            GUI.Report.rptXuatHangTheoKho report = new GUI.Report.rptXuatHangTheoKho();
            report.SetDataSource(ctBCXH);
            crvReport.ReportSource = report;
            report.SetParameterValue("TenCongTy", CT.TenCongTy);
            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
            report.SetParameterValue("DienThoai", CT.SoDienThoai);
            report.SetParameterValue("FaxCongTy", CT.Fax);
            report.SetParameterValue("Web", CT.Website);
            report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Hàng Theo Kho Hàng");
            report.SetParameterValue("NgayTao", xulyNgay(DateServer.Date()));
            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
            report.SetParameterValue("Email", CT.Email);
            report.SetParameterValue("tuNgay", xulyNgay(truoc));
            report.SetParameterValue("DenNgay", xulyNgay(sau));
            crvReport.Show();
        }

        public frmBaoCaorpt(Entities.ChiTietBCXuatHangTheoTungKho[] ctBCXH, DateTime truoc, DateTime sau, string path, string hanhDong)
        {
            InitializeComponent(); CongTy();
            GUI.Report.rptXuatHangTheoKho report = new GUI.Report.rptXuatHangTheoKho();
            report.SetDataSource(ctBCXH);
            crvReport.ReportSource = report;
            report.SetParameterValue("TenCongTy", CT.TenCongTy);
            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
            report.SetParameterValue("DienThoai", CT.SoDienThoai);
            report.SetParameterValue("FaxCongTy", CT.Fax);
            report.SetParameterValue("Web", CT.Website);
            report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Hàng Theo Kho Hàng");
            report.SetParameterValue("NgayTao", xulyNgay(DateServer.Date()));
            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
            report.SetParameterValue("Email", CT.Email);
            report.SetParameterValue("tuNgay", xulyNgay(truoc));
            report.SetParameterValue("DenNgay", xulyNgay(sau));
            if (hanhDong == "Excel")
            {
                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
            }
            else if (hanhDong == "Word")
            {
                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
            }
            else if (hanhDong == "PDF")
            {
                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
            }
        }

        public frmBaoCaorpt(Entities.ChiTietBCXuatHangTheoNhomHang[] ctBCXH, DateTime truoc, DateTime sau, string path, string hanhDong)
        {
            InitializeComponent();
            CongTy();
            GUI.Report.rptXuatHangTheoNhomHang report = new GUI.Report.rptXuatHangTheoNhomHang();
            report.SetDataSource(ctBCXH);
            crvReport.ReportSource = report;
            report.SetParameterValue("TenCongTy", CT.TenCongTy);
            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
            report.SetParameterValue("DienThoai", CT.SoDienThoai);
            report.SetParameterValue("FaxCongTy", CT.Fax);
            report.SetParameterValue("Web", CT.Website);
            report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Hàng Theo Nhóm Hàng");
            report.SetParameterValue("NgayTao", xulyNgay(DateServer.Date()));
            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
            report.SetParameterValue("Email", CT.Email);
            report.SetParameterValue("tuNgay", xulyNgay(truoc));
            report.SetParameterValue("DenNgay", xulyNgay(sau));
            if (hanhDong == "Excel")
            {
                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
            }
            else if (hanhDong == "Word")
            {
                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
            }
            else if (hanhDong == "PDF")
            {
                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
            }
        }
        public frmBaoCaorpt(Entities.ChiTietBCXuatHangTheoNhomHang[] ctBCXH, DateTime truoc, DateTime sau)
        {
            InitializeComponent();
            CongTy();
            GUI.Report.rptXuatHangTheoNhomHang report = new GUI.Report.rptXuatHangTheoNhomHang();
            report.SetDataSource(ctBCXH);
            crvReport.ReportSource = report;
            report.SetParameterValue("TenCongTy", CT.TenCongTy);
            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
            report.SetParameterValue("DienThoai", CT.SoDienThoai);
            report.SetParameterValue("FaxCongTy", CT.Fax);
            report.SetParameterValue("Web", CT.Website);
            report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Hàng Theo Nhóm Hàng");
            report.SetParameterValue("NgayTao", xulyNgay(DateServer.Date()));
            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
            report.SetParameterValue("Email", CT.Email);
            report.SetParameterValue("tuNgay", xulyNgay(truoc));
            report.SetParameterValue("DenNgay", xulyNgay(sau));
            crvReport.Show();
        }

        public frmBaoCaorpt(Entities.BCXuatHangTheoMatHang[] ctBCXH, DateTime truoc, DateTime sau)
        {
            InitializeComponent();
            CongTy();
            GUI.Report.rptXuatHangTheoMatHang report = new GUI.Report.rptXuatHangTheoMatHang();
            report.SetDataSource(ctBCXH);
            crvReport.ReportSource = report;
            report.SetParameterValue("TenCongTy", CT.TenCongTy);
            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
            report.SetParameterValue("DienThoai", CT.SoDienThoai);
            report.SetParameterValue("FaxCongTy", CT.Fax);
            report.SetParameterValue("Web", CT.Website);
            report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Hàng Theo Hàng Hóa");
            report.SetParameterValue("NgayTao", xulyNgay(DateServer.Date()));
            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
            report.SetParameterValue("Email", CT.Email);
            report.SetParameterValue("tuNgay", xulyNgay(truoc));
            report.SetParameterValue("DenNgay", xulyNgay(sau));
            crvReport.Show();
        }

        public frmBaoCaorpt(Entities.BCXuatHangTheoMatHang[] ctBCXH, DateTime truoc, DateTime sau, string path, string hanhDong)
        {
            InitializeComponent();
            CongTy();
            GUI.Report.rptXuatHangTheoMatHang report = new GUI.Report.rptXuatHangTheoMatHang();
            report.SetDataSource(ctBCXH);
            crvReport.ReportSource = report;
            report.SetParameterValue("TenCongTy", CT.TenCongTy);
            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
            report.SetParameterValue("DienThoai", CT.SoDienThoai);
            report.SetParameterValue("FaxCongTy", CT.Fax);
            report.SetParameterValue("Web", CT.Website);
            report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Hàng Theo Hàng Hóa");
            report.SetParameterValue("NgayTao", xulyNgay(DateServer.Date()));
            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
            report.SetParameterValue("Email", CT.Email);
            report.SetParameterValue("tuNgay", xulyNgay(truoc));
            report.SetParameterValue("DenNgay", xulyNgay(sau));
            if (hanhDong == "Excel")
            {
                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
            }
            else if (hanhDong == "Word")
            {
                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
            }
            else if (hanhDong == "PDF")
            {
                new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
            }
        }
        public frmBaoCaorpt(Entities.ChiTietPhieuDieuChuyenKho[] ctBCXH, string NgayDieuChuyen, string MaHDNhap, string MaPhieuDieuChuyen, string KhoDi, string KhoDen)
        {
            InitializeComponent();
            CongTy();
            GUI.Report.rptPhieuDieuChuyenKho report = new GUI.Report.rptPhieuDieuChuyenKho();
            report.SetDataSource(ctBCXH);
            crvReport.ReportSource = report;
            report.SetParameterValue("TenCongTy", CT.TenCongTy);
            report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
            report.SetParameterValue("DienThoai", CT.SoDienThoai);
            report.SetParameterValue("FaxCongTy", CT.Fax);
            report.SetParameterValue("Web", CT.Website);
            report.SetParameterValue("Email", CT.Email);

            report.SetParameterValue("TenBaoCao", "Phiếu Điều Chuyển Kho");
            report.SetParameterValue("NgayTao", NgayDieuChuyen);
            report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);

            report.SetParameterValue("MaPhieuDieuChuyenKho", MaPhieuDieuChuyen);
            report.SetParameterValue("SoChungTuNhap", MaHDNhap);
            report.SetParameterValue("TuKho", KhoDi);
            report.SetParameterValue("DenKho", KhoDen);
            crvReport.Show();
        }
        public frmBaoCaorpt(Entities.BCNhapHangTheoNhomChiTiet[] kct, string thang, string nam, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBaoCaoNhaphangTheoNhomHang report = new GUI.Report.rptBaoCaoNhaphangTheoNhomHang();
                report.SetDataSource(kct);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("MaNhomHang", kct[0].MaNhomHang);
                report.SetParameterValue("TenNhomHangHoa", kct[0].TenNhomHangHoa);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Nhập Hàng Theo Nhóm");
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Ky", thang + "/" + nam);
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch
            {
            }
        }
        public frmBaoCaorpt(Entities.BCNhapHangTheoNhomChiTiet[] kct, string thang, string nam)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBaoCaoNhaphangTheoNhomHang report = new GUI.Report.rptBaoCaoNhaphangTheoNhomHang();
                report.SetDataSource(kct);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Nhập Hàng Theo Nhóm");
                report.SetParameterValue("MaNhomHang", kct[0].MaNhomHang);
                report.SetParameterValue("TenNhomHangHoa", kct[0].TenNhomHangHoa);
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Ky", thang + " - " + nam);
                crvReport.Show();
            }
            catch { }
        }

        public frmBaoCaorpt(Entities.BCXuatNhapTonTheoKhoChiTiet[] kct, string ky)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCXuatNhapTonTheoKhoHang report = new GUI.Report.rptBCXuatNhapTonTheoKhoHang();
                report.SetDataSource(kct);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Nhập Tồn Theo Kho " + ky);
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                crvReport.Show();
            }
            catch
            {
            }
        }

        public frmBaoCaorpt(Entities.BCXuatNhapTonTheoKhoChiTiet[] kct, string ky, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCXuatNhapTonTheoKhoHang report = new GUI.Report.rptBCXuatNhapTonTheoKhoHang();
                report.SetDataSource(kct);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Nhập Tồn Theo Kho " + ky);
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch
            {
            }

        }

        public frmBaoCaorpt(Entities.BCLaiLo[] kct, string truoc, string sau, string a)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCLaiLo report = new GUI.Report.rptBCLaiLo();
                report.SetDataSource(kct);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Lãi Lỗ");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Tu", truoc);
                report.SetParameterValue("Den", sau);

                crvReport.Show();
            }
            catch
            {

            }
        }


        public frmBaoCaorpt(Entities.BCLaiLo[] kct, string truoc, string sau, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCLaiLo report = new GUI.Report.rptBCLaiLo();
                report.SetDataSource(kct);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Lãi Lỗ");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Tu", truoc);
                report.SetParameterValue("Den", sau);
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch
            {
            }
        }

        public frmBaoCaorpt(Entities.BCXuatNhapTonTheoLoaiHangChiTiet[] kct, string ky, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCXuatNhapTonTheoLoaiHang report = new GUI.Report.rptBCXuatNhapTonTheoLoaiHang();
                report.SetDataSource(kct);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Nhập Tồn Theo Loại Hàng " + ky);
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch
            {
            }
        }

        public frmBaoCaorpt(Entities.BCXuatNhapTonTheoLoaiHangChiTiet[] kct, string ky)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCXuatNhapTonTheoLoaiHang report = new GUI.Report.rptBCXuatNhapTonTheoLoaiHang();
                report.SetDataSource(kct);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Nhập Tồn Theo Loại Hàng " + ky);
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                crvReport.Show();
            }
            catch
            {
            }
        }
        public frmBaoCaorpt(Entities.BCThue[] bc, string mathue, int giatrithue, DateTime tu, DateTime den)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptThue report = new GUI.Report.rptThue();
                report.SetDataSource(bc);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("MaThue", mathue);
                report.SetParameterValue("GiaTriThue", giatrithue);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Thuế");
                report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
                report.SetParameterValue("Den", new Common.Utilities().XuLy(2, den.ToShortDateString()));
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                crvReport.Show();
            }
            catch { }
        }
        public frmBaoCaorpt(Entities.BCThue[] bc, string mathue, int giatrithue, DateTime tu, DateTime den, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptThue report = new GUI.Report.rptThue();
                report.SetDataSource(bc);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("MaThue", mathue);
                report.SetParameterValue("GiaTriThue", giatrithue);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Thuế");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch { }
        }

        public frmBaoCaorpt(Entities.BCXuatHuyHangHoa[] bc, DateTime tu, DateTime den)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCXuatHuy report = new GUI.Report.rptBCXuatHuy();
                report.SetDataSource(bc);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Hủy Hàng Hóa");
                report.SetParameterValue("tuNgay", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
                report.SetParameterValue("denNgay", new Common.Utilities().XuLy(2, den.ToShortDateString()));
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                crvReport.Show();
            }
            catch { }
        }

        public frmBaoCaorpt(Entities.BCXuatHuyHangHoa[] bc, DateTime tu, DateTime den, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCXuatHuy report = new GUI.Report.rptBCXuatHuy();
                report.SetDataSource(bc);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Hủy Hàng Hóa");
                report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
                report.SetParameterValue("Den", new Common.Utilities().XuLy(2, den.ToShortDateString()));
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch { }
        }

        public frmBaoCaorpt(Entities.BCTraLaiNCC[] bc, DateTime tu, DateTime den)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCTraLaiNCC report = new GUI.Report.rptBCTraLaiNCC();
                report.SetDataSource(bc);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Trả Lại Nhà Cung Cấp");
                report.SetParameterValue("tuNgay", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
                report.SetParameterValue("denNgay", new Common.Utilities().XuLy(2, den.ToShortDateString()));
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                crvReport.Show();
            }
            catch { }
        }


        public frmBaoCaorpt(Entities.BCTraLaiNCC[] bc, DateTime tu, DateTime den, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCTraLaiNCC report = new GUI.Report.rptBCTraLaiNCC();
                report.SetDataSource(bc);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Trả Lại Nhà Cung Cấp");
                report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
                report.SetParameterValue("Den", new Common.Utilities().XuLy(2, den.ToShortDateString()));
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch { }
        }

        public frmBaoCaorpt(Entities.BCKhachHangTraHang[] bc, DateTime tu, DateTime den)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptKhachHangTraLai report = new GUI.Report.rptKhachHangTraLai();
                report.SetDataSource(bc);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Khách Hàng Trả Lại Hàng");
                report.SetParameterValue("tuNgay", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
                report.SetParameterValue("denNgay", new Common.Utilities().XuLy(2, den.ToShortDateString()));
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                crvReport.Show();
            }
            catch { }
        }


        public frmBaoCaorpt(Entities.BCKhachHangTraHang[] bc, DateTime tu, DateTime den, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptKhachHangTraLai report = new GUI.Report.rptKhachHangTraLai();
                report.SetDataSource(bc);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Khách Hàng Trả Lại Hàng");
                report.SetParameterValue("tuNgay", new Common.Utilities().XuLy(2, tu.ToShortDateString()));
                report.SetParameterValue("denNgay", new Common.Utilities().XuLy(2, den.ToShortDateString()));
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch { }
        }

        public frmBaoCaorpt(Entities.BCXuatNhapTonPhieuXuatNhap[] kct, string ky, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCXuatNhapTonTheoPhieuXuatNhap report = new GUI.Report.rptBCXuatNhapTonTheoPhieuXuatNhap();
                report.SetDataSource(kct);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Nhập Tồn Theo Phiếu Xuất Nhập " + ky);
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch { }
        }

        public frmBaoCaorpt(Entities.BCXuatNhapTonPhieuXuatNhap[] kct, string ky)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBCXuatNhapTonTheoPhieuXuatNhap report = new GUI.Report.rptBCXuatNhapTonTheoPhieuXuatNhap();
                report.SetDataSource(kct);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "Báo Cáo Xuất Nhập Tồn Theo Phiếu Xuất Nhập " + ky);
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                crvReport.Show();
            }
            catch { }
        }

        public void Print(CrystalDecisions.CrystalReports.Engine.ReportDocument Chart)
        {
            try
            {
                ReportDocument crReportDocument;
                crReportDocument = new ReportDocument();
                //Create an instance of a report
                crReportDocument = Chart;

                //Open the PrintDialog
                this.printDialog1.Document = this.printDocument1;
                DialogResult dr = this.printDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    //Get the Copy times
                    int nCopy = this.printDocument1.PrinterSettings.Copies;
                    //Get the number of Start Page
                    int sPage = this.printDocument1.PrinterSettings.FromPage;
                    //Get the number of End Page
                    int ePage = this.printDocument1.PrinterSettings.ToPage;
                    string PrinterName = this.printDocument1.PrinterSettings.PrinterName;

                    crReportDocument = new ReportDocument();
                    //Create an instance of a report
                    crReportDocument = Chart;
                    try
                    {
                        //Set the printer name to print the report to.  By default the sample
                        //report does not have a defult printer specified.  This will tell the
                        //engine to use the specified printer to print the report.  Print out 
                        //a test page (from Printer properties) to get the correct value.

                        crReportDocument.PrintOptions.PrinterName = PrinterName;


                        //Start the printing process.  Provide details of the print job
                        //using the arguments.
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch { }
                }
            }
            catch { }
        }

        public frmBaoCaorpt(string hanhDong, string maHDBanHang, double chietKhau, string khachTra, string soDU, string thanhTien, string GTGT, string tenNhanVien, string HanhDong, string datetime, string giatrithe, string giaTriTheGT, string path, string chietKhauTongHD, string diaChiNguoiNhan, string tenNguoiNhan, string ghiChu)
        {
            try
            {
                InitializeComponent();
                CongTy();
                switch (hanhDong)
                {
                    case "HDBanLe":
                        {
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.BCHDBanLe ctxh = new Entities.BCHDBanLe("Select", maHDBanHang);
                            Entities.BCHDBanLe[] pt1 = new Entities.BCHDBanLe[1];
                            clientstrem = cl.SerializeObj(this.client1, "BCHDBanHang", ctxh);
                            pt1 = (Entities.BCHDBanLe[])cl.DeserializeHepper1(clientstrem, pt1);
                            if (pt1 == null)
                            {
                                MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                                return;
                            }

                            bool tv = giatrithe.Equals("0");
                            bool tgt = giaTriTheGT.Equals("0");
                            bool ck = chietKhau.ToString().Equals("0");
                            bool ck2 = chietKhauTongHD.Equals("0");
                            bool vat = GTGT.Equals("0");
                            // hien thi khong co gi ca
                            if (tv && tgt && ck && ck2 && vat)
                            {
                                GUI.Report.rptHDBanLe2 report = new GUI.Report.rptHDBanLe2();
                                report.SetDataSource(pt1);
                                report.SetParameterValue("HeaderName", CT.TenCongTy);
                                report.SetParameterValue("DiaChi", CT.DiaChi);
                                report.SetParameterValue("DienThoai", "ĐT: " + CT.SoDienThoai);
                                report.SetParameterValue("Date", datetime);
                                report.SetParameterValue("ChietKhau", new Common.Utilities().FormatMoney(Convert.ToDouble(chietKhau)));
                                report.SetParameterValue("Footer", "Cám Ơn Quý Khách Và Hẹn Gặp Lại");
                                report.SetParameterValue("GTGT", Convert.ToDouble(GTGT));
                                report.SetParameterValue("TenNhanVien", Common.Utilities.User.TenNhanVien);
                                report.SetParameterValue("VietBangChu", new ChuyenDoi().Convert(String.Format("{0:0}", Convert.ToDouble(thanhTien)).ToString().Trim(), ',', "phẩy").Replace(",", "") + " đồng");
                                report.SetParameterValue("giatrithe", new Common.Utilities().FormatMoney(double.Parse(giatrithe)));
                                report.SetParameterValue("GiaTriTheGT", new Common.Utilities().FormatMoney(double.Parse(giaTriTheGT)));
                                report.SetParameterValue("ChietKhauTongHD", new Common.Utilities().FormatMoney(Convert.ToDouble(chietKhauTongHD)));
                                report.SetParameterValue("KhachTra", new Common.Utilities().FormatMoney(double.Parse(thanhTien)));

                                if (HanhDong == "in")
                                {
                                    Print(report);
                                }
                                else
                                {
                                    crvReport.ReportSource = report;
                                    crvReport.Show();
                                }

                            }
                            // Hien thi day du
                            else
                            {
                                GUI.Report.rptHDBanLe report = new GUI.Report.rptHDBanLe();
                                report.SetDataSource(pt1);
                                report.SetParameterValue("HeaderName", CT.TenCongTy);
                                report.SetParameterValue("DiaChi", CT.DiaChi);
                                report.SetParameterValue("DienThoai", "ĐT: " + CT.SoDienThoai);
                                report.SetParameterValue("Date", datetime);
                                report.SetParameterValue("ChietKhau", new Common.Utilities().FormatMoney(Convert.ToDouble(chietKhau)));
                                report.SetParameterValue("Footer", "Cám Ơn Quý Khách Và Hẹn Gặp Lại");
                                report.SetParameterValue("GTGT", Convert.ToDouble(GTGT));
                                report.SetParameterValue("TenNhanVien", Common.Utilities.User.TenNhanVien);
                                report.SetParameterValue("VietBangChu", new ChuyenDoi().Convert(String.Format("{0:0}", Convert.ToDouble(thanhTien)).ToString().Trim(), ',', "phẩy").Replace(",", "") + " đồng");
                                report.SetParameterValue("giatrithe", new Common.Utilities().FormatMoney(double.Parse(giatrithe)));
                                report.SetParameterValue("GiaTriTheGT", new Common.Utilities().FormatMoney(double.Parse(giaTriTheGT)));
                                report.SetParameterValue("ChietKhauTongHD", new Common.Utilities().FormatMoney(Convert.ToDouble(chietKhauTongHD)));
                                report.SetParameterValue("KhachTra", new Common.Utilities().FormatMoney(double.Parse(thanhTien)));

                                if (HanhDong == "in")
                                {
                                    Print(report);
                                }
                                else
                                {
                                    crvReport.ReportSource = report;
                                    crvReport.Show();
                                }
                            }

                            break;
                        }
                    case "HDBanBuon":
                        {
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.BCHDBanBuon ctxh = new Entities.BCHDBanBuon("Select", maHDBanHang);
                            Entities.BCHDBanBuon[] pt1 = new Entities.BCHDBanBuon[1];
                            clientstrem = cl.SerializeObj(this.client1, "BCHDBanBuon", ctxh);
                            pt1 = (Entities.BCHDBanBuon[])cl.DeserializeHepper1(clientstrem, pt1);
                            if (pt1 == null)
                            {
                                MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                                return;
                            }

                            bool vat = GTGT.Equals("0");

                            // Khi khong co Thue VAT
                            if (vat)
                            {
                                foreach (Entities.BCHDBanBuon item in pt1)
                                {
                                    item.NgayBan = DateTime.Parse(new Common.Utilities().MyDateConversion(datetime));
                                }
                                GUI.Report.rptBCHDBanBuon2 report = new GUI.Report.rptBCHDBanBuon2();
                                report.SetDataSource(pt1);

                                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                                report.SetParameterValue("Web", CT.Website);
                                report.SetParameterValue("FaxCongTy", CT.Fax);
                                report.SetParameterValue("Email", CT.Email);
                                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                                report.SetParameterValue("ChietKhau", chietKhau);
                                report.SetParameterValue("GTGT", new Common.Utilities().FormatMoney(Convert.ToDouble(GTGT)));
                                report.SetParameterValue("TenBaoCao", "Phiếu Xuất Kho");
                                report.SetParameterValue("NgayTao", datetime);
                                report.SetParameterValue("ThanhTien", new Common.Utilities().FormatMoney(Convert.ToDouble(thanhTien)));
                                report.SetParameterValue("ChietKhauTongHD", new Common.Utilities().FormatMoney(Convert.ToDouble(chietKhauTongHD)));
                                report.SetParameterValue("VietBangChu", new ChuyenDoi().Convert(String.Format("{0:0}", Convert.ToDouble(thanhTien)).ToString().Trim(), ',', "phẩy").Replace(",", "") + " đồng");
                                report.SetParameterValue("DiaChiNguoiNhan", diaChiNguoiNhan);
                                report.SetParameterValue("TenNguoiNhan", tenNguoiNhan);
                                report.SetParameterValue("GhiChu", ghiChu);
                                if (HanhDong == "in")
                                {
                                    Print(report);
                                }
                                else if (HanhDong == "Word")
                                {
                                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                                }
                                else if (HanhDong == "PDF")
                                {
                                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                                }
                                else if (HanhDong == "Excel")
                                {
                                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                                }
                                else
                                {
                                    crvReport.ReportSource = report;
                                    crvReport.Show();
                                }
                            }
                            // Co Thue VAT
                            else
                            {
                                foreach (Entities.BCHDBanBuon item in pt1)
                                {
                                    item.NgayBan = DateTime.Parse(new Common.Utilities().MyDateConversion(datetime));
                                }
                                GUI.Report.rptBCHDBanBuon report = new GUI.Report.rptBCHDBanBuon();
                                report.SetDataSource(pt1);

                                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                                report.SetParameterValue("Web", CT.Website);
                                report.SetParameterValue("FaxCongTy", CT.Fax);
                                report.SetParameterValue("Email", CT.Email);
                                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                                report.SetParameterValue("ChietKhau", chietKhau);
                                report.SetParameterValue("GTGT", new Common.Utilities().FormatMoney(Convert.ToDouble(GTGT)));
                                report.SetParameterValue("TenBaoCao", "Phiếu Xuất Kho");
                                report.SetParameterValue("NgayTao", datetime);
                                report.SetParameterValue("ThanhTien", new Common.Utilities().FormatMoney(Convert.ToDouble(thanhTien)));
                                report.SetParameterValue("ChietKhauTongHD", new Common.Utilities().FormatMoney(Convert.ToDouble(chietKhauTongHD)));
                                report.SetParameterValue("VietBangChu", new ChuyenDoi().Convert(String.Format("{0:0}", Convert.ToDouble(thanhTien)).ToString().Trim(), ',', "phẩy").Replace(",", "") + " đồng");
                                report.SetParameterValue("DiaChiNguoiNhan", diaChiNguoiNhan);
                                report.SetParameterValue("TenNguoiNhan", tenNguoiNhan);
                                report.SetParameterValue("GhiChu", ghiChu);
                                if (HanhDong == "in")
                                {
                                    Print(report);
                                }
                                else if (HanhDong == "Word")
                                {
                                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                                }
                                else if (HanhDong == "PDF")
                                {
                                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                                }
                                else if (HanhDong == "Excel")
                                {
                                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                                }
                                else
                                {
                                    crvReport.ReportSource = report;
                                    crvReport.Show();
                                }
                            }
                            break;
                        }
                }
            }
            catch { }
        }

        public frmBaoCaorpt(string hanhDong, string maKho, string path, string hanhdong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                switch (hanhDong)
                {
                    case "Kho":
                        {
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.BCTonKhoTheoKho ctxh = new Entities.BCTonKhoTheoKho("SelectTheoMa", maKho);
                            Entities.BCTonKhoTheoKho[] pt1 = new Entities.BCTonKhoTheoKho[1];
                            clientstrem = cl.SerializeObj(this.client1, "BCTonKhoTheoKho", ctxh);
                            pt1 = (Entities.BCTonKhoTheoKho[])cl.DeserializeHepper1(clientstrem, pt1);
                            if (pt1 == null)
                            {
                                MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                                return;
                            }
                            else
                            {
                                GUI.Report.rptBCTonKhoTheoKho report = new GUI.Report.rptBCTonKhoTheoKho();
                                report.SetDataSource(pt1);
                                crvReport.ReportSource = report;
                                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                                report.SetParameterValue("FaxCongTy", CT.Fax);
                                report.SetParameterValue("Web", CT.Website);
                                report.SetParameterValue("TenBaoCao", "Báo Cáo Tồn Kho Theo Kho " + DateServer.Date().Month.ToString() + "/" + DateServer.Date().Year.ToString());
                                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                                report.SetParameterValue("Email", CT.Email);
                                if (hanhdong == "Excel")
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
                            break;
                        }
                    case "Nhom":
                        {
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.BCTonKhoTheoNhomHang ctxh = new Entities.BCTonKhoTheoNhomHang("SelectTheoMa", maKho);
                            Entities.BCTonKhoTheoNhomHang[] pt1 = new Entities.BCTonKhoTheoNhomHang[1];
                            clientstrem = cl.SerializeObj(this.client1, "BCTonKhoTheoNhom", ctxh);
                            pt1 = (Entities.BCTonKhoTheoNhomHang[])cl.DeserializeHepper1(clientstrem, pt1);
                            if (pt1 == null)
                            {
                                MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                                return;
                            }
                            else
                            {
                                GUI.Report.rptBCTonKhoTheoNhomHang report = new GUI.Report.rptBCTonKhoTheoNhomHang();
                                report.SetDataSource(pt1);
                                crvReport.ReportSource = report;
                                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                                report.SetParameterValue("FaxCongTy", CT.Fax);
                                report.SetParameterValue("Web", CT.Website);
                                report.SetParameterValue("TenBaoCao", "Báo Cáo Tồn Kho Theo Nhóm Hàng " + DateServer.Date().Month.ToString() + "/" + DateServer.Date().Year.ToString());
                                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                                report.SetParameterValue("Email", CT.Email);
                                if (hanhdong == "Excel")
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
                            break;
                        }
                    default:
                        break;
                }
            }
            catch { }
        }

        public frmBaoCaorpt(string hanhDong, string maKho)
        {
            try
            {
                InitializeComponent();
                CongTy();
                switch (hanhDong)
                {
                    case "Kho":
                        {
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.BCTonKhoTheoKho ctxh = new Entities.BCTonKhoTheoKho("SelectTheoMa", maKho);
                            Entities.BCTonKhoTheoKho[] pt1 = new Entities.BCTonKhoTheoKho[1];
                            clientstrem = cl.SerializeObj(this.client1, "BCTonKhoTheoKho", ctxh);
                            pt1 = (Entities.BCTonKhoTheoKho[])cl.DeserializeHepper1(clientstrem, pt1);
                            if (pt1 == null)
                            {
                                MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                                return;
                            }
                            else
                            {
                                GUI.Report.rptBCTonKhoTheoKho report = new GUI.Report.rptBCTonKhoTheoKho();
                                report.SetDataSource(pt1);
                                crvReport.ReportSource = report;
                                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                                report.SetParameterValue("FaxCongTy", CT.Fax);
                                report.SetParameterValue("Web", CT.Website);
                                report.SetParameterValue("TenBaoCao", "Báo Cáo Tồn Kho Theo Kho " + DateServer.Date().Month.ToString() + "/" + DateServer.Date().Year.ToString());
                                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                                report.SetParameterValue("Email", CT.Email);
                                crvReport.Show();
                            }
                            break;
                        }
                    case "Nhom":
                        {
                            cl = new Server_Client.Client();
                            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.BCTonKhoTheoNhomHang ctxh = new Entities.BCTonKhoTheoNhomHang("SelectTheoMa", maKho);
                            Entities.BCTonKhoTheoNhomHang[] pt1 = new Entities.BCTonKhoTheoNhomHang[1];
                            clientstrem = cl.SerializeObj(this.client1, "BCTonKhoTheoNhom", ctxh);
                            pt1 = (Entities.BCTonKhoTheoNhomHang[])cl.DeserializeHepper1(clientstrem, pt1);
                            if (pt1 == null)
                            {
                                MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                                return;
                            }
                            else
                            {
                                GUI.Report.rptBCTonKhoTheoNhomHang report = new GUI.Report.rptBCTonKhoTheoNhomHang();
                                report.SetDataSource(pt1);
                                crvReport.ReportSource = report;
                                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                                report.SetParameterValue("FaxCongTy", CT.Fax);
                                report.SetParameterValue("Web", CT.Website);
                                report.SetParameterValue("TenBaoCao", "Báo Cáo Tồn Kho Theo Nhóm Hàng " + DateServer.Date().Month.ToString() + "/" + DateServer.Date().Year.ToString());
                                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                                report.SetParameterValue("Email", CT.Email);
                                crvReport.Show();
                            }
                            break;
                        }
                    default:
                        break;
                }
            }
            catch { }
        }

        public frmBaoCaorpt(DateTime Ngay)
        {
            try
            {
                InitializeComponent();
                CongTy();
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.BCDTTheoThoiGian ctxh = new Entities.BCDTTheoThoiGian("SelectTheoNgay", Ngay);
                Entities.BCDTTheoThoiGian[] pt1 = new Entities.BCDTTheoThoiGian[1];
                clientstrem = cl.SerializeObj(this.client1, "BCDTTheoThoiGian", ctxh);
                pt1 = (Entities.BCDTTheoThoiGian[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 == null)
                {
                    MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                    return;
                }
                else
                {
                    GUI.Report.rptBCDoanhThuTheoThoiGian report = new GUI.Report.rptBCDoanhThuTheoThoiGian();
                    report.SetDataSource(pt1);
                    crvReport.ReportSource = report;
                    report.SetParameterValue("TenCongTy", CT.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                    report.SetParameterValue("DienThoai", CT.SoDienThoai);
                    report.SetParameterValue("FaxCongTy", CT.Fax);
                    report.SetParameterValue("Web", CT.Website);
                    report.SetParameterValue("TenBaoCao", "Báo Cáo Doanh Thu Theo Ngày " + new Common.Utilities().XuLy(2, Ngay.ToShortDateString()));
                    report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, Ngay.ToShortDateString()));
                    report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                    report.SetParameterValue("Email", CT.Email);
                    report.SetParameterValue("Tu", "");
                    report.SetParameterValue("Den", "");
                    crvReport.Show();
                }
            }
            catch { }
        }

        public frmBaoCaorpt(string hanhDong, List<string> data)
        {
            try
            {
                InitializeComponent();
                CongTy();
                if (hanhDong == "PhieuThu")
                {
                    GUI.Report.rptBCPhieuThu report = new GUI.Report.rptBCPhieuThu();
                    //report.SetDataSource(pt1);
                    crvReport.ReportSource = report;
                    report.SetParameterValue("TenCongTy", CT.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                    report.SetParameterValue("DienThoai", CT.SoDienThoai);
                    report.SetParameterValue("FaxCongTy", CT.Fax);
                    report.SetParameterValue("Web", CT.Website);
                    report.SetParameterValue("Email", CT.Email);
                    report.SetParameterValue("TenBaoCao", "PHIẾU THU");
                    //report.SetParameterValue("NoTK", data[0]);
                    //report.SetParameterValue("CoTK", data[1]);
                    report.SetParameterValue("HVTNguoiNhanTien", data[2]);
                    report.SetParameterValue("DiaChi", data[3]);
                    report.SetParameterValue("LyDoChi", data[4]);
                    report.SetParameterValue("SoTien", data[5]);
                    report.SetParameterValue("VietBangChu", new ChuyenDoi().Convert(String.Format("{0:0}", Convert.ToDouble(data[5])).ToString().Trim(), '.', "phẩy").Replace(",", "") + " đồng");
                }
                else
                {
                    GUI.Report.rptBCPhieuChi report = new GUI.Report.rptBCPhieuChi();
                    //report.SetDataSource(pt1);
                    crvReport.ReportSource = report;
                    report.SetParameterValue("TenCongTy", CT.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                    report.SetParameterValue("DienThoai", CT.SoDienThoai);
                    report.SetParameterValue("FaxCongTy", CT.Fax);
                    report.SetParameterValue("Web", CT.Website);
                    report.SetParameterValue("Email", CT.Email);
                    report.SetParameterValue("TenBaoCao", "PHIẾU CHI");
                    //report.SetParameterValue("NoTK", data[0]);
                    //report.SetParameterValue("CoTK", data[1]);
                    report.SetParameterValue("HVTNguoiNhanTien", data[2]);
                    report.SetParameterValue("DiaChi", data[3]);
                    report.SetParameterValue("LyDoChi", data[4]);
                    report.SetParameterValue("SoTien", data[5]);
                    report.SetParameterValue("VietBangChu", new ChuyenDoi().Convert(String.Format("{0:0}", Convert.ToDouble(data[5])).ToString().Trim(), '.', "phẩy").Replace(",", "") + " đồng");
                }

                crvReport.Show();
            }
            catch { }
        }

        public frmBaoCaorpt(int Thang, int Nam)
        {
            try
            {
                InitializeComponent();
                CongTy();
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.BCDTTheoThoiGian ctxh = new Entities.BCDTTheoThoiGian("SelectTheoThang", Thang, Nam);
                Entities.BCDTTheoThoiGian[] pt1 = new Entities.BCDTTheoThoiGian[1];
                clientstrem = cl.SerializeObj(this.client1, "BCDTTheoThoiGian", ctxh);
                pt1 = (Entities.BCDTTheoThoiGian[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 == null)
                {
                    MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                    return;
                }
                else
                {
                    GUI.Report.rptBCDoanhThuTheoThoiGian report = new GUI.Report.rptBCDoanhThuTheoThoiGian();
                    report.SetDataSource(pt1);
                    crvReport.ReportSource = report;
                    report.SetParameterValue("TenCongTy", CT.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                    report.SetParameterValue("DienThoai", CT.SoDienThoai);
                    report.SetParameterValue("FaxCongTy", CT.Fax);
                    report.SetParameterValue("Web", CT.Website);
                    report.SetParameterValue("TenBaoCao", "Báo Cáo Doanh Thu Theo Tháng " + Thang + "/" + Nam);
                    report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                    report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                    report.SetParameterValue("Email", CT.Email);
                    report.SetParameterValue("Tu", "");
                    report.SetParameterValue("Den", "");
                    crvReport.Show();
                }
            }
            catch { }
        }

        public frmBaoCaorpt(DateTime Truoc, DateTime Sau)
        {
            try
            {
                InitializeComponent();
                CongTy();
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.BCDTTheoThoiGian ctxh = new Entities.BCDTTheoThoiGian("SelectTheoKhoang", Truoc, Sau);
                Entities.BCDTTheoThoiGian[] pt1 = new Entities.BCDTTheoThoiGian[1];
                clientstrem = cl.SerializeObj(this.client1, "BCDTTheoThoiGian", ctxh);
                pt1 = (Entities.BCDTTheoThoiGian[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 == null)
                {
                    MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                    return;
                }
                else
                {
                    GUI.Report.rptBCDoanhThuTheoThoiGian report = new GUI.Report.rptBCDoanhThuTheoThoiGian();
                    report.SetDataSource(pt1);
                    crvReport.ReportSource = report;
                    report.SetParameterValue("TenCongTy", CT.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                    report.SetParameterValue("DienThoai", CT.SoDienThoai);
                    report.SetParameterValue("FaxCongTy", CT.Fax);
                    report.SetParameterValue("Web", CT.Website);
                    report.SetParameterValue("TenBaoCao", "Báo Cáo Doanh Thu Theo Khoảng Thời Gian");
                    report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                    report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                    report.SetParameterValue("Email", CT.Email);
                    report.SetParameterValue("Tu", new Common.Utilities().XuLy(2, Truoc.ToShortDateString()));
                    report.SetParameterValue("Den", new Common.Utilities().XuLy(2, Sau.ToShortDateString()));
                    crvReport.Show();
                }
            }
            catch { }
        }

        public Entities.ThongTinCongTy CT = new Entities.ThongTinCongTy(0, " ", " ", " ", " ", " ", " ", " ");
        private void frmBaoCaorpt_Load(object sender, EventArgs e)
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ThongTinCongTy kh = new Entities.ThongTinCongTy();
                // truyền HanhDong
                kh = new Entities.ThongTinCongTy("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.ThongTinCongTy[] CT1 = new Entities.ThongTinCongTy[1];
                clientstrem = cl.SerializeObj(this.client1, "CongTy", kh);
                // đổ mảng đối tượng vào daThongTinCongTytagripview       
                CT1 = (Entities.ThongTinCongTy[])cl.DeserializeHepper(clientstrem, CT1);
                if (CT1 != null)
                {
                    CT = CT1[0];
                }
            }
            catch { }
        }

        public void CongTy()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ThongTinCongTy kh = new Entities.ThongTinCongTy();
                // truyền HanhDong
                kh = new Entities.ThongTinCongTy("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.ThongTinCongTy[] CT1 = new Entities.ThongTinCongTy[1];
                clientstrem = cl.SerializeObj(this.client1, "CongTy", kh);
                // đổ mảng đối tượng vào daThongTinCongTytagripview       
                CT1 = (Entities.ThongTinCongTy[])cl.DeserializeHepper(clientstrem, CT1);
                if (CT1 != null)
                {
                    CT = CT1[0];
                }
            }
            catch { }
        }

        ///////////////////////////////////////////////////////////ADD
        public frmBaoCaorpt(string LuaChon, ArrayList dulieu)
        {
            try
            {
                InitializeComponent();
                CongTy();
                if (LuaChon.Equals("InPhieuThanhToanCuaKH"))
                {
                    GUI.Report.rptBCPhieuThanhToanVoiKH report = new GUI.Report.rptBCPhieuThanhToanVoiKH();
                    report.SetDataSource(dulieu[0]);
                    crvReport.ReportSource = report;
                    report.SetParameterValue("TenCongTy", CT.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                    report.SetParameterValue("DienThoai", CT.SoDienThoai);
                    report.SetParameterValue("Web", CT.Website);
                    report.SetParameterValue("Email", CT.Email);
                    report.SetParameterValue("FaxCongTy", CT.Fax);
                    report.SetParameterValue("TenBaoCao", "PHIẾU THANH TOÁN VỚI KHÁCH HÀNG");
                    report.SetParameterValue("MaPhieu", dulieu[1].ToString());
                    report.SetParameterValue("TenKhachHang", dulieu[2].ToString());
                    report.SetParameterValue("DCNguoiNop", dulieu[3].ToString());
                    report.SetParameterValue("NguoiNopTien", dulieu[4].ToString());
                    report.SetParameterValue("Diengiai", dulieu[5].ToString());
                    report.SetParameterValue("VietBangChu", new ChuyenDoi().Convert(String.Format("{0:0}", Convert.ToDouble(dulieu[6].ToString())).ToString().Trim(), '.', "phẩy").Replace(",", "") + " đồng");
                }
                else if (LuaChon.Equals("InPhieuThanhToanCuaNCC"))
                {
                    GUI.Report.rptBCPhieuThanhToanVoiNCC report = new GUI.Report.rptBCPhieuThanhToanVoiNCC();
                    report.SetDataSource(dulieu[0]);
                    crvReport.ReportSource = report;
                    report.SetParameterValue("TenCongTy", CT.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                    report.SetParameterValue("DienThoai", CT.SoDienThoai);
                    report.SetParameterValue("Web", CT.Website);
                    report.SetParameterValue("Email", CT.Email);
                    report.SetParameterValue("FaxCongTy", CT.Fax);
                    report.SetParameterValue("TenBaoCao", "PHIẾU THANH TOÁN VỚI NHÀ CUNG CẤP");
                    report.SetParameterValue("MaPhieu", dulieu[1].ToString());
                    report.SetParameterValue("TenKhachHang", dulieu[2].ToString());
                    report.SetParameterValue("DCNguoiNop", dulieu[3].ToString());
                    report.SetParameterValue("NguoiNopTien", dulieu[4].ToString());
                    report.SetParameterValue("Diengiai", dulieu[5].ToString());
                    report.SetParameterValue("VietBangChu", new ChuyenDoi().Convert(String.Format("{0:0}", Convert.ToDouble(dulieu[6].ToString())).ToString().Trim(), '.', "phẩy").Replace(",", "") + " đồng");
                }
                crvReport.Show();
            }
            catch { }
        }

        public frmBaoCaorpt(string LuaChon, Entities.SoQuy[] dulieu, string path, bool select)  //true:SoQuy    False: CTSoQuy
        {
            try
            {
                InitializeComponent();
                CongTy();
                foreach (Entities.SoQuy item in dulieu)
                {
                    item.DuDauKy = item.DuDauKy.Replace(",", "");
                    item.PhatSinhNo = item.PhatSinhNo.Replace(",", "");
                    item.PhatSinhCo = item.PhatSinhCo.Replace(",", "");
                    item.DuCuoiKy = item.DuCuoiKy.Replace(",", "");
                }
                if (select)
                {
                    GUI.Report.rptBCSoQuy report = new GUI.Report.rptBCSoQuy();
                    List<Entities.BCSoQuy> dulieu1 = new List<Entities.BCSoQuy>();
                    foreach (Entities.SoQuy item in dulieu)
                    {
                        Entities.BCSoQuy tem = new Entities.BCSoQuy();
                        tem.MaTK = item.MaTK;
                        tem.TenTK = item.TenTK;
                        tem.DuDauKy = double.Parse(item.DuDauKy);
                        tem.PhatSinhNo = double.Parse(item.PhatSinhNo);
                        tem.PhatSinhCo = double.Parse(item.PhatSinhCo);
                        tem.DuCuoiKy = double.Parse(item.DuCuoiKy);
                        //tem.NgayLap = item.NgayLap;
                        //tem.MaPhieu = item.MaPhieu;
                        //tem.Ton = double.Parse(item.Ton);
                        dulieu1.Add(tem);
                    }
                    Entities.BCSoQuy[] view = dulieu1.ToArray();
                    report.SetDataSource(view);
                    crvReport.ReportSource = report;
                    report.SetParameterValue("TenCongTy", CT.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                    report.SetParameterValue("DienThoai", CT.SoDienThoai);
                    report.SetParameterValue("Web", CT.Website);
                    report.SetParameterValue("Email", CT.Email);
                    report.SetParameterValue("FaxCongTy", CT.Fax);
                    report.SetParameterValue("TenBaoCao", "SỔ QUỸ");
                    report.SetParameterValue("NgayIn", DateServer.Date().ToString("dd/MM/yyyy"));
                    if (LuaChon.Equals("SoQuy_In"))
                    {
                        crvReport.Show();
                    }
                    else if (LuaChon.Equals("SoQuy_XLS"))
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                    }
                    else if (LuaChon.Equals("SoQuy_DOC"))
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                    }
                    else if (LuaChon.Equals("SoQuy_PDF"))
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                    }
                }
                else
                {
                    GUI.Report.rptBCChiTietSoQuy report = new GUI.Report.rptBCChiTietSoQuy();
                    List<Entities.BCSoQuy> dulieu1 = new List<Entities.BCSoQuy>();
                    foreach (Entities.SoQuy item in dulieu)
                    {
                        Entities.BCSoQuy tem = new Entities.BCSoQuy();
                        tem.MaTK = item.MaTK;
                        tem.TenTK = item.TenTK;
                        tem.DuDauKy = double.Parse(item.DuDauKy);
                        tem.PhatSinhNo = double.Parse(item.PhatSinhNo);
                        tem.PhatSinhCo = double.Parse(item.PhatSinhCo);
                        tem.DuCuoiKy = double.Parse(item.DuCuoiKy);
                        tem.NgayLap = item.NgayLap;
                        tem.MaPhieu = item.MaPhieu;
                        tem.Ton = double.Parse(item.Ton);
                        dulieu1.Add(tem);
                    }
                    Entities.BCSoQuy[] view = dulieu1.ToArray();
                    report.SetDataSource(view);
                    crvReport.ReportSource = report;
                    report.SetParameterValue("TenCongTy", CT.TenCongTy);
                    report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                    report.SetParameterValue("DienThoai", CT.SoDienThoai);
                    report.SetParameterValue("Web", CT.Website);
                    report.SetParameterValue("Email", CT.Email);
                    report.SetParameterValue("FaxCongTy", CT.Fax);
                    report.SetParameterValue("TenBaoCao", "CHI TIẾT SỔ QUỸ");
                    report.SetParameterValue("NgayIn", DateServer.Date().ToString("dd/MM/yyyy"));
                    if (LuaChon.Equals("SoQuy_In"))
                    {
                        crvReport.Show();
                    }
                    else if (LuaChon.Equals("SoQuy_XLS"))
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                    }
                    else if (LuaChon.Equals("SoQuy_DOC"))
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                    }
                    else if (LuaChon.Equals("SoQuy_PDF"))
                    {
                        new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                    }
                }

            }
            catch { }
        }
        //////////////////////////////////////////////////////////////

        public frmBaoCaorpt(Entities.ChiTietTheGiamGia[] kct, string truoc, string sau)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBaoCaoThuTienTheGiaTri report = new GUI.Report.rptBaoCaoThuTienTheGiaTri();
                report.SetDataSource(kct);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "BÁO CÁO THU TIỀN THẺ GIÁ TRỊ");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Tu", truoc);
                report.SetParameterValue("Den", sau);
                crvReport.Show();
            }
            catch { }
        }


        public frmBaoCaorpt(Entities.ChiTietTheGiamGia[] kct, string truoc, string sau, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBaoCaoThuTienTheGiaTri report = new GUI.Report.rptBaoCaoThuTienTheGiaTri();
                report.SetDataSource(kct);
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "BÁO CÁO THU TIỀN THẺ GIÁ TRỊ");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Tu", truoc);
                report.SetParameterValue("Den", sau);
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch { }
        }

        //////////////////////////////////////////////////////////////

        public frmBaoCaorpt(Entities.BCTienTonKho kct, string truoc, string sau)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBaoCaoTienTonKho report = new GUI.Report.rptBaoCaoTienTonKho();
                report.SetDataSource(kct.DanhSach.ToArray());
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "BÁO CÁO TIỀN TỒN KHO");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Tu", truoc);
                report.SetParameterValue("Den", sau);
                report.SetParameterValue("MaKho", kct.MaKho);
                report.SetParameterValue("TenKho", kct.TenKho);
                crvReport.Show();
            }
            catch { }
        }


        public frmBaoCaorpt(Entities.BCTienTonKho kct, string truoc, string sau, string path, string hanhDong)
        {
            try
            {
                InitializeComponent();
                CongTy();
                GUI.Report.rptBaoCaoTienTonKho report = new GUI.Report.rptBaoCaoTienTonKho();
                report.SetDataSource(kct.DanhSach.ToArray());
                crvReport.ReportSource = report;
                report.SetParameterValue("TenCongTy", CT.TenCongTy);
                report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
                report.SetParameterValue("DienThoai", CT.SoDienThoai);
                report.SetParameterValue("FaxCongTy", CT.Fax);
                report.SetParameterValue("Web", CT.Website);
                report.SetParameterValue("TenBaoCao", "BÁO CÁO TIỀN TỒN KHO");
                report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
                report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
                report.SetParameterValue("Email", CT.Email);
                report.SetParameterValue("Tu", truoc);
                report.SetParameterValue("Den", sau);
                report.SetParameterValue("MaKho", kct.MaKho);
                report.SetParameterValue("TenKho", kct.TenKho);
                if (hanhDong == "Excel")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.Excel);
                }
                else if (hanhDong == "Word")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.WordForWindows);
                }
                else if (hanhDong == "PDF")
                {
                    new GUI.Report.ExportCrystalReport().Export(report, path, Report.ExportCrystalReport.TypeBC.PortableDocFormat);
                }
            }
            catch { }
        }
    }
}
