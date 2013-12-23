using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAL;
using BizLogic;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmXuLyQuanlyKH : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        frmKH frm = null;
        public frmXuLyQuanlyKH(frmKH kh)
        {
            InitializeComponent();
            frm = kh;
        }
        public frmXuLyQuanlyKH(DataGridViewRow dgvkhachhang)
        {
            InitializeComponent();
        }
        
        string MaKH="",  Ten="",  MaNhomKH="",  DiaChi="",  DienThoai="", Fax="", Email="", MST="",CongTy="",Mobi="",Website="",GhiChu="",NgaySinh="",NgayThamGia="", GiaoDichCuoi="",NgaySua="",DuNo="", HanMucTT="" ,MaVung="",id="",stt="";
        public void QuanLyKH(string stt,string id,string mavung, string makh, string ten, string manhomkh, string diachi, string dienthoai, string fax, string email, string mst, string congty, string mobi, string website, string ghichu, string ngaysinh, string ngaythamgia, string giaodichcuoi, string ngaysua, string duno, string hanmuctt)
        {
            this.stt = stt;
            this.id = id;
            MaVung = mavung;
            MaKH = makh;
            Ten = ten;
            MaNhomKH = manhomkh;
            DiaChi = diachi;
            DienThoai = dienthoai;
            Fax = fax;
            Email = email;
            MST=mst;
            CongTy=congty;
            Mobi=mobi;
            Website = website;
            GhiChu = ghichu;
            NgaySinh = ngaysinh;
            NgayThamGia = ngaythamgia;
            GiaoDichCuoi = giaodichcuoi;
            NgaySua = ngaysua;
            DuNo = duno;
            HanMucTT = hanmuctt;
        }

        public void LoadKH()
        {
            txtsothutu.Text = stt;
            txtmavung.Text = MaVung;
            txtmakh.Text = MaKH;
            txthoten.Text = Ten;
            cbxnhomkh.Text = MaNhomKH;
            txtdiachi.Text = DiaChi;
            txtdt.Text = DienThoai;
            txtfax.Text = Fax;
            txtemail.Text = Email;
            txtmasothue.Text = MST;
            txtcongty.Text = CongTy;
            txtMobile.Text = Mobi;
            txtwebsite.Text = Website;
            txtghichu.Text = GhiChu;
            maktxtngaysinh.Text = NgaySinh;
            mktxtngaythamgia.Text = NgayThamGia;
            mktxtngaysua.Text = NgaySua;
            txtduno.Text = DuNo;
            txthanmucthanhtoan.Text = HanMucTT;
        }
        private void tsslbltrove_Click(object sender, EventArgs e)
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
        private bool Kiemtra()
        {
            if (txtmakh.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + lblmakh.Text, "Hệ thống cảnh báo");
                return false;
            }
            if (txthoten.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + lblhoten.Text, "Hệ thống cảnh báo");
                return false;
            }           
            if (cbxnhomkh.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần phải nhập " + lblnhomkh.Text, "Hệ thống cảnh báo");
                return false;
            }
            return true;
        }

        private void tsslblthemmoi_Click(object sender, EventArgs e)
        {

            if (Kiemtra())
            {
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entity.KhachHang nv = new Entity.KhachHang();
                nv = new Entity.KhachHang("Insert",int.Parse(id),txtmakh.Text,txthoten.Text,cbxnhomkh.Text,txtdiachi.Text,txtdt.Text,txtfax.Text,txtemail.Text,txtmasothue.Text,
                   0, 0, txtcongty.Text, DateTime.Now, int.Parse(txtmavung.Text),
                    txtMobile.Text, DateTime.Now, DateTime.Now, ckbngungtheodoi.Checked, txtwebsite.Text, DateTime.Now, txtghichu.Text, false);
                clientstrem = cl.SerializeObj(this.client1, "KhachHang", nv);
                int msg = 0;
                msg = (int)cl.DeserializeHepper(clientstrem, msg);
                if (msg == 1)
                {
                    MessageBox.Show("Insert thanh cong ...");
                    frm.SelectData();
                }
                else
                    MessageBox.Show("Insert that bai");

            }
        }
        public void KH()
        {
        }

        public void BindingCombobox(object[] tbl, ComboBox box, string columnDisplay, string columnValue)
        {
            try
            {
                box.DataSource = tbl;
                box.DisplayMember = columnDisplay;
                box.ValueMember = columnValue;
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }
        public void Combobox()
        {
            BizLogic.KhachHang dat = new BizLogic.KhachHang();
            Entity.KhachHang[] hang = dat.Select();
            BindingCombobox(hang, cbxnhomkh, "MaNhomKH", "MaKH");
        }
        private void frmQuanlyKH_Load(object sender, EventArgs e)
        {
            Combobox();
            LoadKH();
            KH();
        }

        private void tsslblghilai_Click(object sender, EventArgs e)
        {
            if (Kiemtra())
            {
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entity.KhachHang nv = new Entity.KhachHang();
                nv = new Entity.KhachHang("Update", int.Parse(id), txtmakh.Text, txthoten.Text, cbxnhomkh.Text, txtdiachi.Text, txtdt.Text, txtfax.Text, txtemail.Text, txtmasothue.Text,
                    0, (float)System.Convert.ToInt32(txthanmucthanhtoan.Text), txtcongty.Text, DateTime.Now, System.Convert.ToInt32(txtmavung.Text),
                    txtMobile.Text, DateTime.Now, DateTime.Now, ckbngungtheodoi.Checked, txtwebsite.Text, DateTime.Now, txtghichu.Text, false);
                clientstrem = cl.SerializeObj(this.client1, "KhachHang", nv);
                int msg = 0;
                msg = (int)cl.DeserializeHepper(clientstrem, msg);
                if (msg == 1)
                {
                    MessageBox.Show("Update thanh cong ...");
                    frm.SelectData();
                }
                else
                    MessageBox.Show("Update that bai");
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
