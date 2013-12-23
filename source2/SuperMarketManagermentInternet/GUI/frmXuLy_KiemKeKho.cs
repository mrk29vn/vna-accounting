using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Collections;

namespace GUI
{
    public partial class frmXuLy_KiemKeKho : Form
    {
        #region hungvv-------------------------------------------------------------------------------------------------------
        public frmXuLy_KiemKeKho()
        {
            InitializeComponent();
        }
        private string hanhdong;

        public string Hanhdong
        {
            get { return hanhdong; }
            set { hanhdong = value; }
        }
        private string tenFrom;

        public string TenFrom
        {
            get { return tenFrom; }
            set { tenFrom = value; }
        }
        private Entities.KiemKeKho kk;

        public Entities.KiemKeKho Kk
        {
            get { return kk; }
            set { kk = value; }
        }
        public frmXuLy_KiemKeKho(string hanhdong)
        {
            InitializeComponent();
            this.hanhdong = hanhdong;
        }
        public frmXuLy_KiemKeKho(string hanhdong,string tenform)
        {
            InitializeComponent();
            this.hanhdong = hanhdong;
            this.tenFrom = tenform;
        }
        public frmXuLy_KiemKeKho(string hanhdong, string tenform,Entities.KiemKeKho kk)
        {
            InitializeComponent();
            this.hanhdong = hanhdong;
            this.tenFrom = tenform;
            this.kk = kk;
        }
        public frmXuLy_KiemKeKho(string hanhdong, Entities.KiemKeKho kk)
        {
            InitializeComponent();
            this.hanhdong = hanhdong;
            this.kk = kk;
        }
        #endregion

        #region hungvv===============================================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        private Server_Client.Client cl;

        /// <summary>
        ///  Lấy Kho Hàng
        /// </summary>
        private void LayKhoHang()
        {
            try
            {
                cbxKhoban.Items.Clear();
                Entities.KiemTraChung kh = new Entities.KiemTraChung();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                kh = new Entities.KiemTraChung("Select", "KhoHang", "MaKho", "TenKho");
                clientstrem = cl.SerializeObj(this.client, "LayCombox", kh);
                Entities.KiemTraChung[] ddh = new Entities.KiemTraChung[1];
                ddh = (Entities.KiemTraChung[])cl.DeserializeHepper(clientstrem, ddh);
                Common.Utilities com = new Common.Utilities();
                com.BindingCombobox(ddh, cbxKhoban, "giatri", "khoachinh");
                this.cbxKhoban.Text = "Chọn kho hàng";
            }
            catch (Exception)
            { }
            client.Close();
            clientstrem.Close();
        }
        /// <summary>
        ///  ma tai khoan ngan hang
        /// </summary>
        private void LayTaiKhoanNganHang()
        {
            try
            {
                cbxMaTaiKhoan.Items.Clear();
                Entities.KiemTraChung kh = new Entities.KiemTraChung();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                kh = new Entities.KiemTraChung("Select", "TKNganHang", "MaTKNganHang", "SoTK");
                clientstrem = cl.SerializeObj(this.client, "LayCombox", kh);
                Entities.KiemTraChung[] ddh = new Entities.KiemTraChung[1];
                ddh = (Entities.KiemTraChung[])cl.DeserializeHepper(clientstrem, ddh);
                Common.Utilities com = new Common.Utilities();
                com.BindingCombobox(ddh, cbxMaTaiKhoan, "giatri", "khoachinh");
                this.cbxMaTaiKhoan.Text = "Chọn tài khoản ngân hàng";
            }
            catch (Exception)
            { }
            client.Close();
            clientstrem.Close();
        }
        #endregion
        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    frmQuanLyKiemKeKho.BaoDong = "A";
                    this.Close();
                }
                else
                { }
            }
        }

        private void toolStripStatus_Ghilai_Click(object sender, EventArgs e)
        {
            XuLy_KiemKeKho("Update");
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chưa xử lý");
        }
        /// <summary>
        /// add ban ghi --------------------------------hungvv-----------------------------
        /// </summary>
        /// <param name="dgv"></param>
        public Entities.ChiTietKiemKeKho[] LuuThongTinChiTietKiemKeKho(DataGridView dgv, string hanhdong, string makiemke,string ghichu)
        {
            ArrayList arr = new ArrayList();
            int i = dgv.RowCount;
            Entities.ChiTietKiemKeKho[] mangBanghi = null;
            if (i > 0)
            {
                for (int x = 0; x < i; x++)
                {
                    Entities.ChiTietKiemKeKho layra = new Entities.ChiTietKiemKeKho();
                    layra.Hanhdong = hanhdong.ToString();
                    layra.MaPhieuKiemKe = makiemke.ToString();
                    layra.MaHangHoa = dgv.Rows[x].Cells[1].Value.ToString();
                    layra.TonThucTe = dgv.Rows[x].Cells[3].Value.ToString();
                    layra.TonSoSach = dgv.Rows[x].Cells[4].Value.ToString();
                    layra.LyDo = dgv.Rows[x].Cells[6].Value.ToString();
                    layra.GhiChu = ""+ghichu;
                    layra.Deleted = false;
                    arr.Add(layra);
                }
                int n = arr.Count;
                if (n == 0) { return null; }
                mangBanghi = new Entities.ChiTietKiemKeKho[n];
                for (int j = 0; j < n; j++)
                {
                    mangBanghi[j] = (Entities.ChiTietKiemKeKho)arr[j];
                }
            }
            else
            {
                mangBanghi = null;
                mangBanghi = null;
            }
            return mangBanghi;
        }
        /// <summary>
        /// luu chi tiet don hang
        /// </summary>
        private void LuuChiTietKiemKeKho()
        {
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            Entities.ChiTietKiemKeKho[] luu = LuuThongTinChiTietKiemKeKho(dgvInsertOrder, "Insert",txtSochungtu.Text,txtDiengiai.Text);
            clientstrem = cl.SerializeHepper(this.client, "ThemchiTietKiemKeKho", luu);
            int bao = 0;
            bao = (int)cl.DeserializeHepper(clientstrem, bao);
        }
        /// <summary>
        /// them moi, sua thong tin don dat hang
        /// </summary>
        /// <param name="hanhdong"></param>
        private int ID = 0;
        private void XuLy_KiemKeKho(string hanhdong)
        {
            try
            {
                Entities.KiemKeKho don = new Entities.KiemKeKho();
                string thoigian_1 = null;
                thoigian_1 = new Common.Utilities().MyDateConversion(makNgaychungtu.Text);
                if (thoigian_1 != null)
                {
                    don.NgayKiemKe = DateTime.Parse(thoigian_1);
                    thoigian_1 = null;
                    don.Hanhdong = hanhdong;
                    don.PhieuKiemKeKhoID = ID;
                    don.MaKiemKe = txtSochungtu.Text.ToUpper();
                    don.MaKho = cbxKhoban.SelectedValue.ToString().ToUpper();
                    don.GhiChu = txtDiengiai.Text;
                    don.Deleted = false;
                    if (dgvInsertOrder.RowCount > 0)
                    {
                        if (CheckData(don) == true)
                        {
                            cl = new Server_Client.Client();
                            this.client = cl.Connect(Luu.IP, Luu.Ports);
                            clientstrem = cl.SerializeObj(this.client, "KiemKeKho", don);
                            Entities.KiemKeKho tralai = new Entities.KiemKeKho();
                            int trave = System.Convert.ToInt32(cl.DeserializeHepper(clientstrem, tralai));
                            if (trave == 1)
                            {
                                LuuChiTietKiemKeKho();
                                MessageBox.Show("Thành công");
                                frmQuanLyKiemKeKho.BaoDong = "";
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Thất bại");
                            }
                        }
                    }
                    else
                    { MessageBox.Show("Không có hàng hóa trong đơn đặt hàng"); }
                }
                else
                { MessageBox.Show("Kiểm tra ngày"); }
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                MessageBox.Show("Thông tin nhập không đúng");
            }
        }

        /// <summary>
        /// hungvv kiem tra dinh dang khi them moi hoa don
        /// </summary>
        /// <param name="maDonDatHang"></param>
        private Boolean CheckData(Entities.KiemKeKho dat)
        {
            if (dat.MaKho.Length <= 0)
            {
                cbxKhoban.Focus();
                System.Windows.Forms.MessageBox.Show("Hãy nhập mã kho");
                return false;
            }
            else
            {
                if (dat.MaKiemKe.Length<=0)
                {
                    txtSochungtu.Focus();
                    MessageBox.Show("Hãy nhập mã kiểm kê");
                    return false;
                }
                else
                {
                      return true;
                }
            }
        }

        private void toolStripStatus_Themmoi_Click(object sender, EventArgs e)
        {
            XuLy_KiemKeKho("Insert");
        }

        private void thiêtLâpThôngSôToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOption fr = new frmOption();
            fr.ShowDialog();
        }
        /// <summary>
        /// hungvv =======================giao tiep voi server===========================
        /// </summary>
        private void SelectData(string MaKiemKe)
        {
            Entities.ChiTietKiemKeKho ctkk = new Entities.ChiTietKiemKeKho();
            dgvInsertOrder.DataSource = null;
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            ctkk = new Entities.ChiTietKiemKeKho("Select", MaKiemKe);
            clientstrem = cl.SerializeObj(this.client, "ChiTietKiemKeKho", ctkk);
            Entities.ChiTietKiemKeKho[] ddh =null;
            ddh = (Entities.ChiTietKiemKeKho[])cl.DeserializeHepper(clientstrem, ddh);
            dgvInsertOrder.DataSource = ddh;
            dgvInsertOrder.RowHeadersVisible = false;
            dgvInsertOrder.Columns[1].Visible = false;
            dgvInsertOrder.Columns[10].Visible = false;
            dgvInsertOrder.Columns[11].Visible = false;
            dgvInsertOrder.Columns[0].HeaderText = "STT";
            dgvInsertOrder.Columns[2].HeaderText = "Mã hàng";
            dgvInsertOrder.Columns[3].HeaderText = "Tên hàng";
            dgvInsertOrder.Columns[4].HeaderText = "Tồn sổ sách";
            dgvInsertOrder.Columns[5].HeaderText = "Tồn thực tế";
            dgvInsertOrder.Columns[6].HeaderText = "Chênh lệch";
            dgvInsertOrder.Columns[7].HeaderText = "Lý do điều chỉnh";
            dgvInsertOrder.Columns[8].HeaderText = "Giá vốn";
            dgvInsertOrder.Columns[9].HeaderText = "Giá chênh lệch";
            new Common.Utilities().CountDatagridview(dgvInsertOrder);
            dgvInsertOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInsertOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            client.Close();
            clientstrem.Close();
        }
       
        /// <summary>
        /// hungvv =================do du lieu vao txt===========================
        /// </summary>
        /// <param name="dat"></param>
        private void DoDuLieu(Entities.KiemKeKho dat)
        {
            Common.Utilities com = new Common.Utilities();
            txtSochungtu.Text = dat.MaKiemKe;
            makNgaychungtu.Text = new Common.Utilities().XuLy(2,dat.NgayKiemKe.ToString());
            GiaTriCanLuu.Ma = dat.MaKho;
            cbxKhoban.SelectedValue = dat.MaKho;
            txtDiengiai.Text = dat.GhiChu;
            SelectData(dat.MaKiemKe);
        }
        private void frmXuLy_KiemKeKho_Load(object sender, EventArgs e)
        {
            LayKhoHang();
            LayTaiKhoanNganHang();
            makNgaychungtu.Text = new Common.Utilities().XuLy(2, DateTime.Today.ToString());
            if (hanhdong == "Insert")
            {
                getID("KiemKeKho");
            }
            if (hanhdong == "Update")
            { 

               DoDuLieu(this.kk);
            }
        }

        /// <summary>
        /// do du lieu vao txt
        /// </summary>
        private void BindHangHoa()
        {
            if (GiaTriCanLuu.Loaitrave == "KiemKeKho_HangHoa")
            {
                toolStrip_txtTracuu.Text = GiaTriCanLuu.Ma;
                toolStrip_txtTenhang.Text = GiaTriCanLuu.Ten;
                toolStrip_txtTonkho.Text = int.Parse(GiaTriCanLuu.TonKho).ToString();
                toolStrip_txtTonThucTe.Text = "1";
                toolStrip_txtLyDo.Text = "Lý do khác";
            }
        }
        private void toolStrip_txtTracuu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                if (cbxKhoban.Text != "")
                {
                    frmTraCuu fr = new frmTraCuu("KiemKeKho_HangHoa", "HangHoa");
                    fr.ShowDialog();
                    BindHangHoa();
                }
                else
                { MessageBox.Show("Chọn kho hàng"); }
            } 
        }

        #region hungvv================================================================================
        /// <summary>
        /// hungvv  ==============================================================================
        /// </summary>
        private DataTable LayGiaTri(DataGridView dgv, string ma, string ten, int tonsosach, int tonthucte, int  chechlech, string lydo, string giavon,string giachenhlech)
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("STT", typeof(string));
            tb.Columns.Add("ID", typeof(string));
            tb.Columns.Add("Name", typeof(string));
            tb.Columns.Add("SoSach", typeof(string));
            tb.Columns.Add("ThucTe", typeof(string));
            tb.Columns.Add("ChenhLech", typeof(string));
            tb.Columns.Add("LyDo", typeof(string));
            tb.Columns.Add("GiaVon", typeof(string));
            tb.Columns.Add("GiaChenhLech", typeof(string));
            if (dgv.RowCount > 0)
            {
                Boolean k = false;
                DataRow row2 = tb.NewRow();
                int count = dgv.RowCount;
                Entities.ChiTietDonDatHang[] chitiet = new Entities.ChiTietDonDatHang[count];
                for (int i = 0; i < count; i++)
                {
                    DataRow row = tb.NewRow();
                    row["ID"] = dgv.Rows[i].Cells[1].Value.ToString();
                    row["Name"] = dgv.Rows[i].Cells[2].Value.ToString();
                    string sl = "1";
                    if (dgv.Rows[i].Cells[1].Value.ToString() == ma)
                    {
                        sl = (Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString()) + tonthucte).ToString();
                        k = true;
                    }
                    else
                    {
                        sl = (Convert.ToInt32(dgv.Rows[i].Cells[4].Value.ToString())).ToString();
                        k = false;
                    }
                    row["SoSach"] = dgv.Rows[i].Cells[3].Value.ToString();
                    row["ThucTe"] =  sl.ToString();
                    row["ChenhLech"] = dgv.Rows[i].Cells[5].Value.ToString();
                    row["LyDo"] = dgv.Rows[i].Cells[6].Value.ToString();
                    row["GiaVon"] = dgv.Rows[i].Cells[7].Value.ToString();
                    row["GiaChenhLech"] = dgv.Rows[i].Cells[8].Value.ToString(); 
                    tb.Rows.Add(row.ItemArray);
                    tb.AcceptChanges();
                }
                if (k == false)
                {
                    row2["ID"] = ma.ToUpper();
                    row2["Name"] = ten.ToString();
                    row2["SoSach"] = tonsosach.ToString();
                    row2["ThucTe"] = tonthucte.ToString();
                    row2["ChenhLech"] = chechlech.ToString();
                    row2["LyDo"] = lydo;
                    row2["GiaVon"] = giavon.ToString();
                    row2["GiaChenhLech"] = giachenhlech.ToString(); 
                    tb.Rows.Add(row2.ItemArray);
                    tb.AcceptChanges();
                }
            }
            else
            {
                DataRow row2 = tb.NewRow();
                row2["ID"] = ma.ToUpper();
                row2["Name"] = ten.ToString();
                row2["SoSach"] = tonsosach.ToString();
                row2["ThucTe"] = tonthucte.ToString();
                row2["ChenhLech"] = chechlech.ToString();
                row2["LyDo"] = lydo;
                row2["GiaVon"] = giavon.ToString();
                row2["GiaChenhLech"] = giachenhlech.ToString(); 
                tb.Rows.Add(row2.ItemArray);
                tb.AcceptChanges();
            }
            return tb;
        }
        /// <summary>
        /// hungvv --------------------kiem tra ma hang------------------
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string KiemTraMa(string ID)
        {
            string kt = null;
            Entities.KiemTraChung ktm = new Entities.KiemTraChung();
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            ktm = new Entities.KiemTraChung("Select", ID);
            clientstrem = cl.SerializeObj(this.client, "KiemTraMa", ktm);
            Entities.KiemTraChung tra = new Entities.KiemTraChung();
            tra = (Entities.KiemTraChung)cl.DeserializeHepper(clientstrem, tra);
            kt = tra.Hanhdong;
            return kt;
        }

        /// <summary>
        /// them hang moi
        /// </summary>
        private void NewRow()
        {
            //try
            //{
            if (cbxKhoban.SelectedValue.ToString() != "")
            {
                string ma = "" + toolStrip_txtTracuu.Text.ToUpper();
                string ten = "" + toolStrip_txtTenhang.Text;
                int tonsosach = Convert.ToInt32(0 + toolStrip_txtTonkho.Text);
                int tonthucte = Convert.ToInt32(0 + toolStrip_txtTonThucTe.Text);
                int chenhlech = tonsosach - tonthucte;
                string lydochinh = toolStrip_txtLyDo.Text;
                string giavon = (tonsosach * (float.Parse(GiaTriCanLuu.Giatri))).ToString();
                string giachinhlech = (float.Parse(giavon) - (tonthucte * (float.Parse(GiaTriCanLuu.Giatri)))).ToString();
                string thongbao = KiemTraMa(ma.Trim());
               dgvInsertOrder.DataSource =LayGiaTri(dgvInsertOrder, ma , ten, tonsosach ,  tonthucte , chenhlech , lydochinh,  giavon , giachinhlech );
               //txtTienhang.Text = new Common.Utilities().TongTien(dgvInsertOrder);
               dgvInsertOrder.RowHeadersVisible = false;
               dgvInsertOrder.Columns[0].HeaderText = "STT";
               dgvInsertOrder.Columns[1].HeaderText = "Mã hàng";
               dgvInsertOrder.Columns[2].HeaderText = "Tên hàng hóa";
               dgvInsertOrder.Columns[3].HeaderText = "Tồn thực tế";
               dgvInsertOrder.Columns[4].HeaderText = "Tồn sổ sách";
               dgvInsertOrder.Columns[5].HeaderText = "Chênh lệch";
               dgvInsertOrder.Columns[8].HeaderText = "Lý do điều chỉnh";
               dgvInsertOrder.Columns[6].HeaderText = "Giá vốn";
               dgvInsertOrder.Columns[7].HeaderText = "Giá chênh lệch";
               new Common.Utilities().CountDatagridview(dgvInsertOrder);
               dgvInsertOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
               dgvInsertOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
               ResetTool();
            }
            else
            {
                ResetTool();
                MessageBox.Show("Chọn kho hàng");
                return;
            }
            //}
            //catch (Exception ex)
            //{ 
            //    string s = ex.ToString(); 
            //    MessageBox.Show("Kiểm tra dữ liệu cần thêm");
            //}
        }
        /// <summary>
        /// reset form
        /// </summary>
        private void ResetTool()
        {
            toolStrip_txtTracuu.Text = "<F2 Tra cứu>";
            toolStrip_txtTenhang.Text = "";
            toolStrip_txtLyDo.Text = "Chưa có lý do";
            toolStrip_txtTonkho.Text = "0";
            toolStrip_txtTonThucTe.Text = "0";
        }
        /// <summary>
        /// tu tang ID
        /// </summary>
        private void getID(string table)
        {
            try
            {
                Entities.LayID top = new Entities.LayID();
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                top = new Entities.LayID("Select", table);
                clientstrem = cl.SerializeObj(this.client, "LayID", top);
                Entities.LayID ddh = new Entities.LayID();
                ddh = (Entities.LayID)cl.DeserializeHepper(clientstrem, ddh);
                string chuoi = ddh.ID.ToString();
                Common.Utilities com = new Common.Utilities();
                txtSochungtu.Text = com.ProcessID(chuoi);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            client.Close();
            clientstrem.Close();
        }
        #endregion
        
        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {
            NewRow();
        }

        private void toolStrip_txtTonThucTe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
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
