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
    public partial class frmTimBaoCao : Form
    {

        public frmTimBaoCao()
        {
            InitializeComponent();
        }

        private TcpClient client;
        private NetworkStream clientstrem;
        private Server_Client.Client cl;

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void send(int i)
        {
            TimBaoCao.tenbaocao = cbxLoaibaocao.SelectedItem.ToString();
            TimBaoCao.macongty = cbxCongty.SelectedValue.ToString().ToUpper();
            TimBaoCao.dieukienloc = i;
            TimBaoCao.ngaybatdau = makNgaybatdau.Text;
            TimBaoCao.ngayketthuc = makNgayketthuc.Text;
            TimBaoCao.trangthaithanhtoan = checkKiemtratrangthaithanhtoan.Checked;
            TimBaoCao.nam = ""+cbxNam.SelectedItem.ToString();
            TimBaoCao.thang = ""+cbxThang_Quy.SelectedItem.ToString();
            TimBaoCao.congty = layra;
        }
        /// <summary>
        /// kiem tra dieu kien
        /// </summary>
        /// <returns></returns>
        private int Check()
        {
            if (rdoTheonam.Checked == true)
            {   
                send(1);
                return 1;  
            }
            else
            {
                if (rdoTheoquy.Checked == true)
                { send(2); return 2; }
                else
                {
                    if (rdoTheothang.Checked == true)
                    { send(3); return 3; }
                    else
                    {
                        if (rdoTheongay.Checked == true)
                        { send(4); return 4; }
                        else
                        {
                            if (rdoKhoangthoigian.Checked == true)
                            { send(5); return 5; }
                            else
                            { send(0); MessageBox.Show("Chọn điều kiện lọc"); return 0; }
                        }
                    }
                }
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            if (Check()> 0)
            {
                this.Close();
            }
            else
            { }
        }
        /// <summary>
        /// lay thong tin cong ty
        /// </summary>
        /// <param name="macongty"></param>
        /// <returns></returns>
        private static Entities.ThongTinCongTy[] thongtin = null;
        Entities.ThongTinCongTy layra = null;
        private void layBang()
        {
            layra = new Entities.ThongTinCongTy();
            Entities.TruyenGiaTri truyen = new Entities.TruyenGiaTri("Select", "");
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            clientstrem = cl.SerializeObj(this.client, "LayThongTinCongty", truyen);
            thongtin = (Entities.ThongTinCongTy[])cl.DeserializeHepper(clientstrem, thongtin);
            new Common.Utilities().BindingCombobox(thongtin, cbxCongty, "TenCongTy", "MaCongTy");
          
            for (int i = 0; i < thongtin.Length; i++)
            {
                if (thongtin[i].MaCongTy == cbxCongty.SelectedValue.ToString())
                {
                    layra.MaCongTy = thongtin[i].MaCongTy;
                    layra.TenCongTy = thongtin[i].TenCongTy;
                    layra.DiaChi = thongtin[i].DiaChi;
                    layra.SoDienThoai = thongtin[i].SoDienThoai;
                    layra.Fax = thongtin[i].Fax;
                    layra.Email = thongtin[i].Email;
                }
                else
                { continue; }
            }
        }

        private void frmTimBaoCao_Load(object sender, EventArgs e)
        {
            makNgaybatdau.Text = new Common.Utilities().XuLy(2, DateServer.Date().ToString());
            makNgayketthuc.Text = new Common.Utilities().XuLy(2, DateServer.Date().ToString());
            layBang();
            this.cbxLoaibaocao.Items.AddRange(new object[] { "Xuất Hàng Theo Từng Kho","Xuất Hàng Theo Từng Nhóm Hàng","Xuất Hàng Theo Từng Mặt Hàng" });
            this.cbxLoaibaocao.Text = "Chọn báo cáo cần hiển thị";
            this.cbxNam.Items.AddRange(new object[] { "2011", "2012", "2013", "2014", "2015", "2016", "2017", "2018", "2020" });
            if (rdoTheoquy.Checked == true)
            {
                cbxNam.Enabled = true;
                cbxThang_Quy.Enabled = true;
                makNgaybatdau.Enabled = false;
                makNgayketthuc.Enabled = false;
                lblThang_Quy.Text = "Quý:";
                this.cbxThang_Quy.Items.AddRange(new object[] { "1", "2", "3", "4" });
                this.cbxThang_Quy.Text = "Chọn quý";
            }
            if (rdoTheothang.Checked == true)
            {
                cbxNam.Enabled = true;
                cbxThang_Quy.Enabled = true;
                makNgaybatdau.Enabled = false;
                makNgayketthuc.Enabled = false;
                lblThang_Quy.Text = "Tháng:";
                this.cbxThang_Quy.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            }
        }

        private void rdoTheonam_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTheonam.Checked == true)
            {
                cbxNam.Enabled = true;
                cbxThang_Quy.Enabled = false;
                rdoTheothang.Enabled = false;
                rdoTheongay.Enabled = false;
                rdoKhoangthoigian.Enabled = false;
            }            
           
        }

        private void rdoTheoquy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTheoquy.Checked == true)
            {
                cbxNam.Enabled = true;
                cbxThang_Quy.Enabled = true;
                makNgaybatdau.Enabled = false;
                makNgayketthuc.Enabled = false;
                lblThang_Quy.Text = "Quý:";
                this.cbxThang_Quy.Items.AddRange(new object[] { "1", "2", "3", "4" });
                this.cbxThang_Quy.Text = "Chọn quý";
            }
        }

        private void rdoTheothang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTheothang.Checked == true)
            {
                cbxNam.Enabled = true;
                cbxThang_Quy.Enabled = true;
                makNgaybatdau.Enabled = false;
                makNgayketthuc.Enabled = false;
                lblThang_Quy.Text = "Tháng:";
                this.cbxThang_Quy.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
                this.cbxThang_Quy.Text = "Chọn tháng";
            }
        }

        private void rdoTheongay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTheongay.Checked == true)
            {
                cbxNam.Enabled = false;
                cbxThang_Quy.Enabled = false;
                makNgaybatdau.Enabled = true;
                makNgayketthuc.Enabled = false;
            }
        }

        private void rdoKhoangthoigian_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoKhoangthoigian.Checked == true)
            {
                cbxNam.Enabled = false;
                cbxThang_Quy.Enabled = false;
                makNgaybatdau.Enabled = true;
                makNgayketthuc.Enabled = true;
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
