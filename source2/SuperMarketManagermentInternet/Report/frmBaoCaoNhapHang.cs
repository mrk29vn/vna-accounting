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
        public TcpClient client1;
        public NetworkStream clientstrem;
        public frmBaoCaoNhapHang()
        {
            InitializeComponent();
        }
        Server_Client.Client cl;
        
        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public Entities.BaoCaoNhapHangTheoMatHang[] SelectData()
        {
            Entities.BaoCaoNhapHangTheoMatHang[] nkh1 = new Entities.BaoCaoNhapHangTheoMatHang[1];
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.BaoCaoNhapHangTheoMatHang nkh = new Entities.BaoCaoNhapHangTheoMatHang();
                // truyền HanhDong
                Entities.TruyenGiaTri truyen = new Entities.TruyenGiaTri("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
               
                clientstrem = cl.SerializeObj(this.client1, "BaoCaoNhapHangTheoMatHang", truyen);
                // đổ mảng đối tượng vào datagripview       
                nkh1 = (Entities.BaoCaoNhapHangTheoMatHang[])cl.DeserializeHepper1(clientstrem, nkh1);
                Entities.BaoCaoNhapHangTheoMatHang[] nkh3 = new Entities.BaoCaoNhapHangTheoMatHang[nkh1.Length];
                Common.Utilities a = new Common.Utilities();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được với server - thử lại sau");
            }
            return nkh1;
        }

        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public Entities.BaoCaoNhapHangTheoNhomHang[] SelectData1()
        {
            Entities.BaoCaoNhapHangTheoNhomHang[] nkh1 = new Entities.BaoCaoNhapHangTheoNhomHang[1];
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.BaoCaoNhapHangTheoNhomHang nkh = new Entities.BaoCaoNhapHangTheoNhomHang();
                // truyền HanhDong
                Entities.TruyenGiaTri truyen = new Entities.TruyenGiaTri("Select");
                // khởi tạo mảng đối tượng để hứng giá trị

                clientstrem = cl.SerializeObj(this.client1, "BaoCaoNhapHangTheoNhomHang", truyen);
                // đổ mảng đối tượng vào datagripview       
                nkh1 = (Entities.BaoCaoNhapHangTheoNhomHang[])cl.DeserializeHepper1(clientstrem, nkh1);
                Entities.BaoCaoNhapHangTheoNhomHang[] nkh3 = new Entities.BaoCaoNhapHangTheoNhomHang[nkh1.Length];
                Common.Utilities a = new Common.Utilities();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được với server - thử lại sau");
            }
            return nkh1;
        }
        private void frmBaoCaoNhapHang_Load(object sender, EventArgs e)
        {
            
            CryBaoCaoNhapHangTheoMatHang report = new CryBaoCaoNhapHangTheoMatHang();
            CryBaoCaoNhapHangTheoNhomHang report1 = new CryBaoCaoNhapHangTheoNhomHang();
            report.SetDataSource(SelectData());
            report.SetDataSource(SelectData1());
            crystalReportViewer1.ReportSource = report;
            report.SetParameterValue("TenCongTy", "công ty trách nhiệm hữu hạn một thành viên hungvv");
            report.SetParameterValue("DiaChiCongTy", "thành phố hà nội thật đẹp");
            report.SetParameterValue("DienThoai", "01686825827");
            report.SetParameterValue("FaxCongTy", "01686825827");
            report.SetParameterValue("Web", "www.google.com.vn");
            report.SetParameterValue("TenBaoCao", "Báo Cáo Nhập Hàng Theo Mặt Hàng");
            report.SetParameterValue("NgayTao", DateTime.Now.ToShortDateString());
            report.SetParameterValue("MaNhanVien", "NV_0001");
            report.SetParameterValue("Email", "xmenstart@gmail.com");
            crystalReportViewer1.Show();
            this.WindowState = FormWindowState.Maximized;
            
        }
    }
}
