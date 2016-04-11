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
    public partial class frmBaoCaoXuatHang : Form
    {
        public frmBaoCaoXuatHang()
        {
            InitializeComponent();
        }
        private string hanhdong;
        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        private string tenform;

        public string Tenform
        {
            get { return tenform; }
            set { tenform = value; }
        }
        public frmBaoCaoXuatHang(string hanhdong, string tenform)
        {
            InitializeComponent();
            this.hanhdong = hanhdong;
            this.tenform = tenform;
        }

        private TcpClient client;
        private NetworkStream clientstrem;
        private Server_Client.Client cl;

        /// <summary>
        /// lay bang nhom hang hoa theo ma hang hoa va ngay 
        /// </summary>
        /// <param name="manhom"></param>
        /// <param name="ngay"></param>
        /// <returns></returns>
        private Entities.BaoCaoXuatHangTheoNhomHang[] BaoCaoNhomHang(string manhom,string ngay)
        {
            Entities.BaoCaoXuatHangTheoNhomHang[] tralai = null;
            Entities.TruyenGiaTri truyen = new Entities.TruyenGiaTri("Select", manhom,ngay);
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            clientstrem = cl.SerializeObj(this.client, "BaoCaoXuatHangTheoNhomHang", truyen);
            tralai = (Entities.BaoCaoXuatHangTheoNhomHang[])cl.DeserializeHepper(clientstrem, tralai);
            return tralai;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private Entities.BaoCaoXuatHangTheoKho[] BaoCaoKhoHang(string makho, string ngay)
        {
            Entities.BaoCaoXuatHangTheoKho[] tralai = null;
            Entities.TruyenGiaTri truyen = new Entities.TruyenGiaTri("Select", makho, ngay);
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            clientstrem = cl.SerializeObj(this.client, "BaoCaoXuatHangTheoKho", truyen);
            tralai = (Entities.BaoCaoXuatHangTheoKho[])cl.DeserializeHepper(clientstrem, tralai);
            return tralai;
        }
        private void frmBaoCaoXuatHang_Load(object sender, EventArgs e)
        {
            if (TimBaoCao.congty != null)
            {
                //Entities.ThongTinCongTy[] thongtin = layBang(macongty);
               
                if (hanhdong == "XuatHangTheoKho")
                {
                    this.Text = tenform;
                    //GUI.Report.rptBaoCaoXuatHangTheoTungNhomHang report = new GUI.Report.rptBaoCaoXuatHangTheoTungNhomHang();
                    //report.SetDataSource(BaoCaoNhomHang("",""));
                    //rptViewer.ReportSource = report;
                    //report.SetParameterValue("TenCongTy", TimBaoCao.congty.TenCongTy);
                    //report.SetParameterValue("DiaChiCongTy", TimBaoCao.congty.DiaChi);
                    //report.SetParameterValue("DienThoai", TimBaoCao.congty.SoDienThoai);
                    //report.SetParameterValue("FaxCongTy", TimBaoCao.congty.Fax);
                    //report.SetParameterValue("Web", TimBaoCao.congty.Website);
                    //report.SetParameterValue("Email", TimBaoCao.congty.Email);
                    //report.SetParameterValue("TenBaoCao", TimBaoCao.tenbaocao);
                    //report.SetParameterValue("NgayTao", DateServer.Date().ToShortDateString());
                    //report.SetParameterValue("MaNhanVien", GiaTriCanLuu.MaNhanVien + "");
                    //rptViewer.Show();
                }
                if (hanhdong == "XuatHangTheoNhomHang")
                {
                    this.Text = tenform;
                    //GUI.Report.rptBaoCaoXuatHangTheoTungKho report = new GUI.Report.rptBaoCaoXuatHangTheoTungKho();
                    //report.SetDataSource(BaoCaoNhomHang("", ""));
                    //rptViewer.ReportSource = report;
                    //report.SetParameterValue("TenCongTy", TimBaoCao.congty.TenCongTy);
                    //report.SetParameterValue("DiaChiCongTy", TimBaoCao.congty.DiaChi);
                    //report.SetParameterValue("DienThoai", TimBaoCao.congty.SoDienThoai);
                    //report.SetParameterValue("FaxCongTy", TimBaoCao.congty.Fax);
                    //report.SetParameterValue("Web", TimBaoCao.congty.Website);
                    //report.SetParameterValue("Email", TimBaoCao.congty.Email);
                    //report.SetParameterValue("TenBaoCao", TimBaoCao.tenbaocao);
                    //report.SetParameterValue("NgayTao", DateServer.Date().ToShortDateString());
                    //report.SetParameterValue("MaNhanVien", GiaTriCanLuu.MaNhanVien + "");
                    //rptViewer.Show();
                }
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {

            }
        }


    }
}
