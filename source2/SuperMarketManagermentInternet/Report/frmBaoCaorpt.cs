using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Report
{
    public partial class frmBaoCaorpt : Form
    {
        public frmBaoCaorpt()
        {
            InitializeComponent();
        }
        public frmBaoCaorpt(int stt)
        {
            InitializeComponent();
            switch (stt)
            {
                case 1:
                    {
                        BCDoanhThuTheoNhanVien report = new BCDoanhThuTheoNhanVien();
                        report.SetDataSource(SelectBCDoanhThuTheoNhanVien());
                        crvReport.ReportSource = report;
                        report.SetParameterValue("TenCongTy", "công ty trách nhiệm hữu hạn một thành viên hungvv");
                        report.SetParameterValue("DiaChiCongTy", "thành phố hà nội thật đẹp");
                        report.SetParameterValue("DienThoai", "01686825827");
                        report.SetParameterValue("FaxCongTy", "01686825827");
                        report.SetParameterValue("Web", "www.google.com.vn");
                        report.SetParameterValue("TenBaoCao", "Báo Cáo Hàng Hóa Theo Ngày");
                        report.SetParameterValue("NgayTao", DateTime.Now);
                        report.SetParameterValue("MaNhanVien", "NV_0001");
                        report.SetParameterValue("Email", "xmenstart@gmail.com");
                        crvReport.Show();
                        break;
                    }
                case 2:
                    {
                        BCDoanhThuTheoNhomHang report = new BCDoanhThuTheoNhomHang();
                        report.SetDataSource(SelectBCDoanhThuTheoNhomHang());
                        crvReport.ReportSource = report;
                        report.SetParameterValue("TenCongTy", "công ty trách nhiệm hữu hạn một thành viên hungvv");
                        report.SetParameterValue("DiaChiCongTy", "thành phố hà nội thật đẹp");
                        report.SetParameterValue("DienThoai", "01686825827");
                        report.SetParameterValue("FaxCongTy", "01686825827");
                        report.SetParameterValue("Web", "www.google.com.vn");
                        report.SetParameterValue("TenBaoCao", "Báo Cáo Hàng Hóa Theo Ngày");
                        report.SetParameterValue("NgayTao", DateTime.Now);
                        report.SetParameterValue("MaNhanVien", "NV_0001");
                        report.SetParameterValue("Email", "xmenstart@gmail.com");
                        crvReport.Show();
                        break;
                    }
                case 3:
                    {
                        BCDoanhThuTheoMatHang report = new BCDoanhThuTheoMatHang();
                        report.SetDataSource(SelectBCDoanhThuTheoMatHang());
                        crvReport.ReportSource = report;
                        report.SetParameterValue("TenCongTy", "công ty trách nhiệm hữu hạn một thành viên hungvv");
                        report.SetParameterValue("DiaChiCongTy", "thành phố hà nội thật đẹp");
                        report.SetParameterValue("DienThoai", "01686825827");
                        report.SetParameterValue("FaxCongTy", "01686825827");
                        report.SetParameterValue("Web", "www.google.com.vn");
                        report.SetParameterValue("TenBaoCao", "Báo Cáo Hàng Hóa Theo Ngày");
                        report.SetParameterValue("NgayTao", DateTime.Now);
                        report.SetParameterValue("MaNhanVien", "NV_0001");
                        report.SetParameterValue("Email", "xmenstart@gmail.com");
                        crvReport.Show();
                        break;
                    }
            }
        }
        public frmBaoCaorpt(DateTime Ngay)
        {
            InitializeComponent();
            BCDoanhThuTheoThoiGian report = new BCDoanhThuTheoThoiGian();
            report.SetDataSource(select_PhieuThuTheoNgay(Ngay));
            crvReport.ReportSource = report;
            report.SetParameterValue("TenCongTy", "công ty trách nhiệm hữu hạn một thành viên hungvv");
            report.SetParameterValue("DiaChiCongTy", "thành phố hà nội thật đẹp");
            report.SetParameterValue("DienThoai", "01686825827");
            report.SetParameterValue("FaxCongTy", "01686825827");
            report.SetParameterValue("Web", "www.google.com.vn");
            report.SetParameterValue("TenBaoCao", "Báo Cáo Hàng Hóa Theo Ngày");
            report.SetParameterValue("NgayTao", DateTime.Now);
            report.SetParameterValue("MaNhanVien", "NV_0001");
            report.SetParameterValue("Email", "xmenstart@gmail.com");
            crvReport.Show();
        }

        public frmBaoCaorpt(int Thang, int Nam)
        {
            InitializeComponent();
            BCDoanhThuTheoThoiGian report = new BCDoanhThuTheoThoiGian();
            report.SetDataSource(select_PhieuThuTheoThang(Thang,Nam));
            crvReport.ReportSource = report;
            report.SetParameterValue("TenCongTy", "công ty trách nhiệm hữu hạn một thành viên hungvv");
            report.SetParameterValue("DiaChiCongTy", "thành phố hà nội thật đẹp");
            report.SetParameterValue("DienThoai", "01686825827");
            report.SetParameterValue("FaxCongTy", "01686825827");
            report.SetParameterValue("Web", "www.google.com.vn");
            report.SetParameterValue("TenBaoCao", "Báo Cáo Hàng Hóa Theo Ngày");
            report.SetParameterValue("NgayTao", DateTime.Now);
            report.SetParameterValue("MaNhanVien", "NV_0001");
            report.SetParameterValue("Email", "xmenstart@gmail.com");
            crvReport.Show();
        }
        public frmBaoCaorpt(DateTime Truoc, DateTime Sau)
        {
            InitializeComponent();
            BCDoanhThuTheoThoiGian report = new BCDoanhThuTheoThoiGian();
            report.SetDataSource(select_PhieuThuTheoKhoangThoiGian(Truoc,Sau));
            crvReport.ReportSource = report;
            report.SetParameterValue("TenCongTy", "công ty trách nhiệm hữu hạn một thành viên hungvv");
            report.SetParameterValue("DiaChiCongTy", "thành phố hà nội thật đẹp");
            report.SetParameterValue("DienThoai", "01686825827");
            report.SetParameterValue("FaxCongTy", "01686825827");
            report.SetParameterValue("Web", "www.google.com.vn");
            report.SetParameterValue("TenBaoCao", "Báo Cáo Hàng Hóa Theo Ngày");
            report.SetParameterValue("NgayTao", DateTime.Now);
            report.SetParameterValue("MaNhanVien", "NV_0001");
            report.SetParameterValue("Email", "xmenstart@gmail.com");
            crvReport.Show();
        }

        public DataTable SelectBCDoanhThuTheoNhanVien()
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "sp_selectDoanhThuTheoNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = new SqlConnection("Data Source=Red-pc;Initial Catalog=SupermarketManagement;Persist Security Info=True;User ID=sa;Password=123");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable SelectBCDoanhThuTheoNhomHang()
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "sp_selectDoanhThuTheoNhomHang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = new SqlConnection("Data Source=Red-pc;Initial Catalog=SupermarketManagement;Persist Security Info=True;User ID=sa;Password=123");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable SelectBCDoanhThuTheoMatHang()
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "sp_selectDoanhThuTheoMatHang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = new SqlConnection("Data Source=Red-pc;Initial Catalog=SupermarketManagement;Persist Security Info=True;User ID=sa;Password=123");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable select_PhieuThuTheoNgay(DateTime date)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "sp_selectPhieuThuTheoNgay";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = new SqlConnection("Data Source=Red-pc;Initial Catalog=SupermarketManagement;Persist Security Info=True;User ID=sa;Password=123");
                cmd.Parameters.Add(new SqlParameter("@Ngay", date));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public DataTable select_PhieuThuTheoThang(int Thang, int Nam)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "sp_selectPhieuThuTheoThang";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = new SqlConnection("Data Source=Red-pc;Initial Catalog=SupermarketManagement;Persist Security Info=True;User ID=sa;Password=123");
                cmd.Parameters.Add(new SqlParameter("@Thang", Thang));
                cmd.Parameters.Add(new SqlParameter("@Nam", Nam));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public DataTable select_PhieuThuTheoKhoangThoiGian(DateTime Truoc, DateTime Sau)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "sp_selectPhieuThuTheoKhoangThoiGian";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = new SqlConnection("Data Source=Red-pc;Initial Catalog=SupermarketManagement;Persist Security Info=True;User ID=sa;Password=123");
                cmd.Parameters.Add(new SqlParameter("@Truoc", Truoc));
                cmd.Parameters.Add(new SqlParameter("@Sau", Sau));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
