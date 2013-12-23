using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entities;

namespace GUI
{
    public partial class FrmBcChiTietHangHoa : Form
    {
        readonly List<rptBCChiTietHangHoa> _dsBcChiTietHangHoa = new List<rptBCChiTietHangHoa>();

        public FrmBcChiTietHangHoa()
        {
            InitializeComponent();
            _dsBcChiTietHangHoa = GetData();
        }

        static List<rptBCChiTietHangHoa> GetData()
        {
            rptBCChiTietHangHoa[] rptBcChiTietHangHoas;
            bool kq = Utils.GetDataFromServer("BCChiTietHangHoa", new rptBCChiTietHangHoa("Select"), out rptBcChiTietHangHoas);
            if (!kq)
            {
                MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
                return new List<rptBCChiTietHangHoa>();
            }
            return rptBcChiTietHangHoas == null ? new List<rptBCChiTietHangHoa>() : rptBcChiTietHangHoas.ToList();
        }

        private void tsslthoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            //CongTy();
            //cl = new Server_Client.Client();
            //this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            //Entities.rptBCChiTietHangHoa kh = new Entities.rptBCChiTietHangHoa("Select");
            //Entities.rptBCChiTietHangHoa[] kh1 = new Entities.rptBCChiTietHangHoa[1];
            //clientstrem = cl.SerializeObj(this.client1, "BCChiTietHangHoa", kh);
            //kh1 = (Entities.rptBCChiTietHangHoa[])cl.DeserializeHepper1(clientstrem, kh1);
            //if (kh1 == null)
            //{
            //    MessageBox.Show("Không có dữ liệu", "Hệ thống cảnh báo");
            //    return;
            //}
            //GUI.Report.rptBCChiTietHangHoa report = new GUI.Report.rptBCChiTietHangHoa();
            //report.SetDataSource(kh1);
            //crvReport.ReportSource = report;
            //report.SetParameterValue("TenCongTy", CT.TenCongTy);
            //report.SetParameterValue("DiaChiCongTy", CT.DiaChi);
            //report.SetParameterValue("DienThoai", CT.SoDienThoai);
            //report.SetParameterValue("FaxCongTy", CT.Fax);
            //report.SetParameterValue("Web", CT.Website);
            //report.SetParameterValue("TenBaoCao", "Báo Cáo Chi Tiết Hàng Hóa");
            //report.SetParameterValue("NgayTao", new Common.Utilities().XuLy(2, DateServer.Date().ToShortDateString()));
            //report.SetParameterValue("MaNhanVien", Common.Utilities.User.TenNhanVien);
            //report.SetParameterValue("Email", CT.Email);
            //crvReport.Show();
            //break;

            frmBaoCaorpt frm = new frmBaoCaorpt("ChiTietHangHoa");
            frm.ShowDialog();
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            //PDF
            SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = "PDF |*.pdf", FileName = string.Empty };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                frmBaoCaorpt a = new frmBaoCaorpt(_dsBcChiTietHangHoa, new Dictionary<string, object>(), saveFileDialog1.FileName, "PDF");
            }
        }

        private void tsslWord_Click(object sender, EventArgs e)
        {
            //DOC
            SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = "Word |*.doc", FileName = string.Empty };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                frmBaoCaorpt a = new frmBaoCaorpt(_dsBcChiTietHangHoa, new Dictionary<string, object>(), saveFileDialog1.FileName, "Word");
            }
        }

        private void tsslexcel_Click(object sender, EventArgs e)
        {
            //XLS
            SaveFileDialog saveFileDialog1 = new SaveFileDialog { Filter = "Excel |*.xls", FileName = string.Empty };
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                frmBaoCaorpt a = new frmBaoCaorpt(_dsBcChiTietHangHoa, new Dictionary<string, object>(), saveFileDialog1.FileName, "Excel");
            }
        }
    }
}
