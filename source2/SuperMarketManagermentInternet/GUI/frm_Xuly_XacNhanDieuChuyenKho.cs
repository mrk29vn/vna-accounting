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
    public partial class frm_Xuly_XacNhanDieuChuyenKho : Form
    {
        DateTime datesv;
        public frm_Xuly_XacNhanDieuChuyenKho()
        {
            InitializeComponent(); datesv = DateServer.Date();

        }
        public TcpClient client1;
        public NetworkStream clientstrem;
        public Server_Client.Client cl;
        Entities.ChiTietPhieuDieuChuyenKho[] arrct;
        ArrayList arr = new ArrayList();
        string kt;
        public frm_Xuly_XacNhanDieuChuyenKho(DataGridViewRow dgvr)
        {
            InitializeComponent(); datesv = DateServer.Date();
            LayKhoHang(cbxTukho, dgvr.Cells[4].Value.ToString());
            LayKhoHang(cbxDenkho, dgvr.Cells[6].Value.ToString());
            HienThi(dgvr);

            if (txtSochungtunhap.Text == "")
            {
                HienThiChiTietTheoPDCK(txtSochungtu.Text);
            }
            else
            {
                if (txtSochungtunhap.Text != "")
                {
                    HienThiChiTiet(txtSochungtunhap.Text, cbxTukho.Text);
                }
            }
        }
        public static string maHDNhap;
        int ctcount = 0;
        string ngaychungtu;
        string tukho, denkho, ghichu, maPDCK;
        int PDCKID;



        #region lay kho hang
        public void LayKhoHang(ComboBox cbb, string str)
        {
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

            Entities.KhoHang kh = new Entities.KhoHang();
            kh = new Entities.KhoHang("Select");
            clientstrem = cl.SerializeObj(this.client1, "KhoHang", kh);
            Entities.KhoHang[] kh1 = new Entities.KhoHang[1];
            kh1 = (Entities.KhoHang[])cl.DeserializeHepper1(clientstrem, kh1);

            if (kh1 != null)
            {
                int index = 0;
                for (int i = 0; i < kh1.Length; i++)
                {
                    if (kh1[i].MaKho == str)
                    {
                        index = i;
                        break;
                    }
                }
                cbb.DataSource = kh1;
                cbb.DisplayMember = "TenKho";
                cbb.SelectedIndex = index;
            }
        }
        #endregion

        #region convert datetime
        public DateTime ConvertDatetime(string str)
        {

            string dd = str.Substring(0, 2);
            string mm = str.Substring(3, 2);
            string yyyy = str.Substring(6, 4);
            DateTime dt = new DateTime(int.Parse(yyyy), int.Parse(mm), int.Parse(dd));
            return dt;
        }
        #endregion

        #region xử lý ngày

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

        #endregion

        #region hien thi
        public void HienThi(DataGridViewRow dgvR)
        {
            PDCKID = (int)dgvR.Cells[1].Value;
            maPDCK = txtSochungtu.Text = dgvR.Cells[2].Value.ToString();
            tukho = cbxTukho.Text = dgvR.Cells[4].Value.ToString();
            denkho = cbxDenkho.Text = dgvR.Cells[6].Value.ToString();
            maHDNhap = txtSochungtunhap.Text = dgvR.Cells[8].Value.ToString();
            check_Xacnhan.Checked = Boolean.Parse(dgvR.Cells[9].Value.ToString());
            ghichu = txtDiengiai.Text = dgvR.Cells[10].Value.ToString();
            ngaychungtu = makNgaychungtu.Text = xulyNgay(Convert.ToDateTime(dgvR.Cells[3].Value.ToString()));

        }
        #endregion

        #region hien thi chi tiet phieu dieu chuyen theo HDNhap
        public void HienThiChiTiet(string maHDNhap, string makho)
        {
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

            Entities.ChiTietHoaDonNhap[] kh = new Entities.ChiTietHoaDonNhap[1];
            kh[0] = new Entities.ChiTietHoaDonNhap("Select");
            clientstrem = cl.SerializeObj(this.client1, "ChiTietHoaDonNhap", kh);

            Entities.ChiTietHoaDonNhap[] kh1 = new Entities.ChiTietHoaDonNhap[1];
            kh1 = (Entities.ChiTietHoaDonNhap[])cl.DeserializeHepper1(clientstrem, kh1);
            if (kh1.Length > 0)
            {
                int ctcount = 0;
                foreach (Entities.ChiTietHoaDonNhap h in kh1)
                {
                    if (h.MaHoaDonNhap == maHDNhap)
                    {
                        ctcount++;
                    }
                }

                Entities.ChiTietHoaDonNhap[] hdn = new Entities.ChiTietHoaDonNhap[ctcount];
                ctcount = 0;
                foreach (Entities.ChiTietHoaDonNhap h in kh1)
                {
                    if (h.MaHoaDonNhap == maHDNhap)
                    {
                        hdn[ctcount] = new Entities.ChiTietHoaDonNhap();
                        hdn[ctcount].MaHangHoa = h.MaHangHoa;
                        hdn[ctcount].TenHangHoa = h.TenHangHoa;
                        hdn[ctcount].SoLuong = h.SoLuong;
                        ctcount++;
                    }
                }

                Server_Client.Client cl1 = new Server_Client.Client();
                this.client1 = cl1.Connect(Luu.IP, Luu.Ports);

                Entities.ChiTietKhoHangTheoHoaHonNhap[] ctkh = new Entities.ChiTietKhoHangTheoHoaHonNhap[1];
                ctkh[0] = new Entities.ChiTietKhoHangTheoHoaHonNhap("Select");
                clientstrem = cl1.SerializeObj(this.client1, "ChiTietKho", ctkh);

                Entities.ChiTietKhoHangTheoHoaHonNhap[] ctkh1 = new Entities.ChiTietKhoHangTheoHoaHonNhap[1];
                ctkh1 = (Entities.ChiTietKhoHangTheoHoaHonNhap[])cl1.DeserializeHepper1(clientstrem, kh1);


                Entities.ChiTietPhieuDieuChuyenKho[] ctdck = new Entities.ChiTietPhieuDieuChuyenKho[ctcount];
                for (int i = 0; i < ctdck.Length; i++)
                {
                    ctdck[i] = new Entities.ChiTietPhieuDieuChuyenKho();
                    ctdck[i].MaHangHoa = hdn[i].MaHangHoa;
                    ctdck[i].TenHangHoa = hdn[i].TenHangHoa;
                    ctdck[i].SoLuong = hdn[i].SoLuong;
                    ctdck[i].MaPhieuDieuChuyenKho = txtSochungtu.Text;
                    if (ctkh1 != null)
                    {
                        for (int j = 0; j < ctkh1.Length; j++)
                        {
                            if (ctkh1[j].Makho == makho && hdn[i].MaHangHoa == ctkh1[j].Mahanghoa)
                            {
                                ctdck[i].NgayHetHan = ctkh1[i].Ngayhethan;
                            }
                        }
                    }
                }
                dgvInsertOrder.DataSource = ctdck;
                FixDataGridView();
            }


        }
        #endregion

        #region fixdatagridview
        public void FixDataGridView()
        {
            dgvInsertOrder.RowHeadersVisible = false;
            dgvInsertOrder.Columns[0].Visible = false;
            dgvInsertOrder.Columns[1].Visible = false;
            dgvInsertOrder.Columns[dgvInsertOrder.ColumnCount - 1].Visible = false;
            dgvInsertOrder.Columns[dgvInsertOrder.ColumnCount - 2].Visible = false;
            dgvInsertOrder.AllowUserToResizeRows = false;
            dgvInsertOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInsertOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInsertOrder.ReadOnly = true;
            dgvInsertOrder.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
            dgvInsertOrder.Columns["TenHangHoa"].HeaderText = "Tên Hàng Hoá";
            dgvInsertOrder.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvInsertOrder.Columns["NgayHetHan"].HeaderText = "Ngày Hết Hạn";
        }
        #endregion

        public void HienThiChiTietTheoPDCK(string Phieudieuchuyenkho)
        {
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

            Entities.ChiTietPhieuDieuChuyenKho kh = new Entities.ChiTietPhieuDieuChuyenKho("Select");
            clientstrem = cl.SerializeObj(this.client1, "ChiTietPhieuDieuCHuyenKhoNoiBo", kh);

            Entities.ChiTietPhieuDieuChuyenKho[] kh1 = new Entities.ChiTietPhieuDieuChuyenKho[1];
            kh1 = (Entities.ChiTietPhieuDieuChuyenKho[])cl.DeserializeHepper1(clientstrem, kh1);

            if (kh1 != null)
            {
                int count = 0;
                for (int i = 0; i < kh1.Length; i++)
                {
                    if (kh1[i].MaPhieuDieuChuyenKho == Phieudieuchuyenkho)
                    {
                        count++;
                    }
                }

                Entities.ChiTietPhieuDieuChuyenKho[] ctpdck1 = new Entities.ChiTietPhieuDieuChuyenKho[count];
                count = 0;
                for (int i = 0; i < kh1.Length; i++)
                {
                    if (kh1[i].MaPhieuDieuChuyenKho == txtSochungtu.Text)
                    {
                        ctpdck1[count] = kh1[i];
                        count++;
                    }
                }
                for (int i = 0; i < count; i++)
                {
                    arr.Add(ctpdck1[i]);
                }
                arrct = new Entities.ChiTietPhieuDieuChuyenKho[count];
                for (int i = 0; i < count; i++)
                {
                    arrct[i] = ctpdck1[i];
                }
                ctcount = count;
                dgvInsertOrder.DataSource = ctpdck1;
                FixDataGridView();
            }

        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
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

        public void CheckDataGridCongSL(DataGridView dgv, string maKho)
        {
            if (dgv.RowCount != 0)
            {
                try
                {

                    Server_Client.Client cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    Entities.ChiTietKhoHangTheoHoaHonNhap nv = new Entities.ChiTietKhoHangTheoHoaHonNhap("Select");
                    clientstrem = cl.SerializeObj(this.client1, "ChiTietKho", nv);
                    Entities.ChiTietKhoHangTheoHoaHonNhap[] kh1 = new Entities.ChiTietKhoHangTheoHoaHonNhap[1];
                    kh1 = (Entities.ChiTietKhoHangTheoHoaHonNhap[])cl.DeserializeHepper1(clientstrem, kh1);
                    List<Entities.ChiTietKhoHangTheoHoaHonNhap> ctList = new List<Entities.ChiTietKhoHangTheoHoaHonNhap>();
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        bool retVal = false;
                        foreach (Entities.ChiTietKhoHangTheoHoaHonNhap item in kh1)
                        {
                            if (dgv["MaHangHoa", i].Value.ToString().ToUpper().Equals(item.Mahanghoa.ToUpper()) && maKho.Equals(item.Makho))
                            {
                                retVal = true;
                                break;
                            }
                        }
                        if (!retVal)
                        {
                            Entities.ChiTietKhoHangTheoHoaHonNhap ct = new Entities.ChiTietKhoHangTheoHoaHonNhap();
                            ct.Hanhdong = "Insert";
                            ct.Mahanghoa = dgv["MaHangHoa", i].Value.ToString();
                            ct.Makho = maKho;
                            ct.Ngaynhap = datesv;
                            DateTime ngayHetHan = DateTime.Now;
                            if (dgv["NgayHetHan", i] != null)
                                ngayHetHan = (DateTime)dgv["NgayHetHan", i].Value;
                            ct.Ngayhethan = ngayHetHan;
                            ct.Soluong = int.Parse(dgv["SoLuong", i].Value.ToString());
                            ct.Ghichu = "";
                            ctList.Add(ct);
                        }
                    }
                    Server_Client.Client cl1 = new Server_Client.Client();
                    this.client1 = cl1.Connect(Luu.IP, Luu.Ports);
                    clientstrem = cl1.SerializeObj(this.client1, "ThemChiTietKhoHang", ctList.ToArray());
                }
                catch (Exception)
                {
 
                }
            }
        }

        public void CheckDataGridTruSL(DataGridView dgv, string maKho)
        {
            if (dgv.RowCount != 0)
            {
                Entities.ChiTietKhoHangTheoHoaHonNhap[] cthdbh = new Entities.ChiTietKhoHangTheoHoaHonNhap[dgv.RowCount];
                for (int j = 0; j < cthdbh.Length; j++)
                {
                    cthdbh[j] = new Entities.ChiTietKhoHangTheoHoaHonNhap("Update", maKho, dgv[2, j].Value.ToString(), int.Parse(dgv["SoLuong", j].Value.ToString()));
                }
                TruSLMang(cthdbh);
            }
        }

        public void CheckDataGridCongSL1(DataGridView dgv, string maKho)
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.ChiTietKhoHangTheoHoaHonNhap nv = new Entities.ChiTietKhoHangTheoHoaHonNhap("Select");
            clientstrem = cl.SerializeObj(this.client1, "ChiTietKho", nv);
            Entities.ChiTietKhoHangTheoHoaHonNhap[] kh1 = new Entities.ChiTietKhoHangTheoHoaHonNhap[1];
            kh1 = (Entities.ChiTietKhoHangTheoHoaHonNhap[])cl.DeserializeHepper1(clientstrem, kh1);
            List<Entities.ChiTietKhoHangTheoHoaHonNhap> ctKhoList = new List<Entities.ChiTietKhoHangTheoHoaHonNhap>();
            try
            {
                if (dgv.RowCount != 0)
                {

                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        foreach (Entities.ChiTietKhoHangTheoHoaHonNhap item in kh1)
                        {
                            // lay cac hang hoa da ton tai 
                            if (dgv["MaHangHoa", i].Value.ToString().ToUpper().Equals(item.Mahanghoa.ToUpper()))
                            {
                                Entities.ChiTietKhoHangTheoHoaHonNhap ct;
                                ct = new Entities.ChiTietKhoHangTheoHoaHonNhap("UpdateCong", maKho, dgv["MaHangHoa", i].Value.ToString(), int.Parse(dgv["SoLuong", i].Value.ToString()));
                                ctKhoList.Add(ct);
                                break;
                            }
                        }
                    }
                    TruSLMang(ctKhoList.ToArray());

                }
            }
            catch (Exception)
            {

            }
        }

        public void TruSLMang(Entities.ChiTietKhoHangTheoHoaHonNhap[] ctkhthdn)
        {
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            clientstrem = cl.SerializeObj(this.client1, "ThemChiTietKhoHang", ctkhthdn);
        }

        private void tsslXacNhan_Click(object sender, EventArgs e)
        {
            if (check_Xacnhan.Checked == true)
            {
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.KhoHang kho1 = (Entities.KhoHang)cbxTukho.SelectedItem;
                Entities.KhoHang kho2 = (Entities.KhoHang)cbxDenkho.SelectedItem;
                Entities.PhieuDieuChuyenKhoNoiBo nv = new Entities.PhieuDieuChuyenKhoNoiBo("Update", PDCKID, txtSochungtu.Text, ConvertDatetime(makNgaychungtu.Text), kho1.MaKho, "", kho2.MaKho, "", maHDNhap, check_Xacnhan.Checked, ghichu, false);
                clientstrem = cl.SerializeObj(this.client1, "PhieuDieuCHuyenKhoNoiBo", nv);

                int msg = 0;
                msg = (int)cl.DeserializeHepper(clientstrem, msg);
                if (msg == 1)
                {
                    // tru so luong tu kho
                    Entities.KhoHang khoh = (Entities.KhoHang)cbxTukho.SelectedItem;
                    CheckDataGridTruSL(dgvInsertOrder, khoh.MaKho);
                    // Update so luong khi co hang hoa tong tai trong kho den
                    Entities.KhoHang khoDen = (Entities.KhoHang)cbxDenkho.SelectedItem;
                    CheckDataGridCongSL1(dgvInsertOrder, khoDen.MaKho);
                    // Insert so luong kho ko co hang hoa do 
                    CheckDataGridCongSL(dgvInsertOrder, khoDen.MaKho);


                }
                else
                {
                    MessageBox.Show("Update that bai");
                    return;
                }

                
                this.Close();
            }
            else
            {
                if (check_Xacnhan.Checked == false)
                {
                    MessageBox.Show("Chưa xác nhận vào checkbox xác nhận ", "Hệ Thống Cảnh Báo");
                }
            }
        }

        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {

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
