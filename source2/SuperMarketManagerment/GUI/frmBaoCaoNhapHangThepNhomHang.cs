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
    public partial class frmBaoCaoNhapHangThepNhomHang : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        public frmBaoCaoNhapHangThepNhomHang()
        {
            InitializeComponent();
        }
        Server_Client.Client cl;
        /// <summary>
        /// lay thong tin cong ty
        /// </summary>
        /// <param name="macongty"></param>
        /// <returns></returns>
        private Entities.ThongTinCongTy[] layBang(string maCongTy)
        {
            Entities.ThongTinCongTy[] thongtin = null;
            Entities.TruyenGiaTri truyen = new Entities.TruyenGiaTri("Select", maCongTy);
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            clientstrem = cl.SerializeObj(this.client1, "LayThongTinCongty", truyen);
            thongtin = (Entities.ThongTinCongTy[])cl.DeserializeHepper(clientstrem, thongtin);
            return thongtin;
        }
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
        private void frmBaoCaoNhapHangThepNhomHang_Load(object sender, EventArgs e)
        {
            //Entities.ThongTinCongTy[] thongtin = layBang("CT_0001");
            //Report.CryBaoCaoNhapHangTheoNhomHang report1 = new Report.CryBaoCaoNhapHangTheoNhomHang();
            //report1.SetDataSource(SelectData1());
            //crystalReportViewer1.ReportSource = report1;
            //report1.SetParameterValue("TenCongTy", thongtin[0].TenCongTy);
            //report1.SetParameterValue("DiaChiCongTy", thongtin[0].DiaChi);
            //report1.SetParameterValue("DienThoai", thongtin[0].SoDienThoai);
            //report1.SetParameterValue("FaxCongTy", thongtin[0].Fax);
            //report1.SetParameterValue("Web", thongtin[0].Website);
            //report1.SetParameterValue("Email", thongtin[0].Email);
            //report1.SetParameterValue("TenBaoCao", "Báo Cáo Nhập Hàng THeo Nhóm Hàng");
            //report1.SetParameterValue("NgayTao", DateServer.Date().ToShortDateString());
            //report1.SetParameterValue("MaNhanVien", "NV_0001");
            //crystalReportViewer1.Show();
            //this.WindowState = FormWindowState.Maximized;
        }
    }
}
