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
    public partial class frmXuLy_DieuChuyenKhoNoiBo : Form
    {
        DateTime datesv;
        Entities.GoiHang[] goihang;
        Entities.ChiTietGoiHang[] chitietgoihang;
        Entities.QuyDoiDonViTinh[] quidoidvt;

        public TcpClient client1;
        public NetworkStream clientstrem;
        public Server_Client.Client cl;
        public static DataGridViewRow ct = new DataGridViewRow();
        Entities.ChiTietPhieuDieuChuyenKho[] arrct;
        Entities.ChiTietKhoHangTheoMa[] ctkArr;
        ArrayList arr = new ArrayList();
        public static string maHDNhap;
        int ctcount = 0;
        string ngaychungtu;
        string tukho, denkho, ghichu, maPDCK;
        int PDCKID;

        Entities.ChiTietPhieuDieuChuyenKho[] CtPdck_BaoCao;

        //Mrk FIX
        bool dangquydoiDVT = false;
        bool khongcohanghoatrongkho = false;
        /////////

        public frmXuLy_DieuChuyenKhoNoiBo()
        {
            InitializeComponent();
            datesv = DateServer.Date();
            this.NapQuyDoiVaGoiHang();
        }

        public frmXuLy_DieuChuyenKhoNoiBo(string str, DataGridViewRow dgvR)
        {
            InitializeComponent();
            datesv = DateServer.Date();
            this.NapQuyDoiVaGoiHang();
            XuLyString(str, dgvR);
            check_Xacnhan.Enabled = false;
            if (toolStrip_txtTracuu.Text == "<F4-Tra cứu>")
            {
                toolStrip_btnThem.Enabled = false;
            }
            Entities.KhoHang kho = (Entities.KhoHang)cbxTukho.SelectedItem;
            this.ctkArr = GetChitietKho(kho.MaKho);

        }

        #region Mrk
        private void NapQuyDoiVaGoiHang()
        {
            // gói hàng
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("GH");
            clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
            goihang = new Entities.GoiHang[0];
            goihang = (Entities.GoiHang[])cl.DeserializeHepper1(clientstrem, goihang);
            if (goihang == null)
            {
                goihang = new Entities.GoiHang[0];
                return;
            }

            // chi tiết gói hàng
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            ctxh = new Entities.CheckRefer("CTGH");
            clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
            chitietgoihang = new Entities.ChiTietGoiHang[0];
            chitietgoihang = (Entities.ChiTietGoiHang[])cl.DeserializeHepper1(clientstrem, chitietgoihang);
            if (chitietgoihang == null)
            {
                chitietgoihang = new Entities.ChiTietGoiHang[0];
                return;
            }

            // quy đổi đơn vị tính
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            ctxh = new Entities.CheckRefer("QD");
            clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
            this.quidoidvt = new Entities.QuyDoiDonViTinh[0];
            this.quidoidvt = (Entities.QuyDoiDonViTinh[])cl.DeserializeHepper1(clientstrem, this.quidoidvt);
            if (quidoidvt == null)
            {
                quidoidvt = new Entities.QuyDoiDonViTinh[0];
                return;
            }

        }

        private Entities.tem1[] LayHangHoaTrongGoiHang(string magoihang, Entities.GoiHang[] gh, Entities.ChiTietGoiHang[] chitietgoihang)
        {
            List<Entities.tem1> kq = new List<Entities.tem1>();
            foreach (Entities.GoiHang item1 in goihang)
            {
                foreach (Entities.ChiTietGoiHang item2 in chitietgoihang)
                {
                    if (item2.MaGoiHang.Equals(item1.MaGoiHang) && item2.MaGoiHang.Equals(magoihang))
                    {
                        Entities.tem1 tem = new Entities.tem1();
                        tem.MaHangHoa = item2.MaHangHoa;
                        tem.TenHangHoa = item2.TenHangHoa;
                        tem.SoLuong = item2.SoLuong + "";
                        tem.GiaNhap = item2.GiaNhap;
                        tem.GiaBanBuon = item2.GiaBanBuon;
                        tem.GiaBanLe = item2.GiaBanLe;
                        kq.Add(tem);
                    }
                }
            }
            Entities.tem1[] kqkq = new Entities.tem1[kq.Count];
            for (int i = 0; i < kq.Count; i++)
            {
                kqkq[i] = kq[i];
            }
            return kqkq;
        }
        #endregion

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    frmHienThi_DieuChuyenKhoNoiBo.KiemTra = "close";
                    this.Close();
                }
                else
                { }
            }
        }

        #region LayID
        public string LayID(string tenBang)
        {
            string idnew = "";
            cl = new Server_Client.Client();
            // gán TCPclient
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            // khởi tạo biến truyền vào với hàm khởi tạo
            Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
            // khởi tạo mảng đối tượng để hứng giá trị
            Entities.LayID lid = new Entities.LayID();
            clientstrem = cl.SerializeObj(this.client1, "LayID", lid1);
            // đổ mảng đối tượng vào datagripview       
            lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, lid1);
            if (lid != null)
            {
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
            }
            else
            {
                if (lid == null)
                {
                    idnew = "PDCK_0001";
                }
            }
            return idnew;
        }
        #endregion

        #region validate

        public string checkDateTime(string datetime)
        {
            if (datetime.Length < 10)
            {
                return "Ngày Tháng năm phải nhập đầy đủ";
            }
            string dd = datetime.Substring(0, 2);
            string mm = datetime.Substring(3, 2);
            string yyyy = datetime.Substring(6, 4);
            if ((int.Parse(dd) > 31) || (int.Parse(dd) < 1))
            {
                return "Ngày phải nhỏ hơn 31 và lớn hơn 0";
            }
            if ((int.Parse(mm) > 12) || (int.Parse(mm) < 1))
            {
                return "Tháng phải nhỏ hơn 12 và lớn hơn 0";
            }

            return "true";
        }

        public bool Validate()
        {

            if (cbxTukho.DataSource == null && cbxDenkho.DataSource == null)
            {
                MessageBox.Show("Chưa có dữ liệu về kho hàng trong Cơ Sở Dữ Liệu - Nhập thêm hoặc liên hệ Nhà Quản Trị");
                return false;
            }

            if (cbxTukho.Text == cbxDenkho.Text)
            {
                MessageBox.Show("Kho Đi Phải Khác kho đến. Mời CHọn lại kho ! ");
                return false;
            }
            if (cbxTukho.Text.Length == 0)
            {
                MessageBox.Show("Kho đi không được để trống");
                cbxTukho.Focus();
                return false;
            }
            if (cbxDenkho.Text.Length == 0)
            {
                MessageBox.Show("Kho đến không được để trống");
                cbxDenkho.Focus();
                return false;
            }
            if (dgvInsertOrder.RowCount == 0)
            {
                MessageBox.Show("Chưa có dữ liệu về chi tiết điều chuyển - Nhập thêm để hoàn thành");
                return false;
            }

            if (cbxTukho.Text.Length == 0)
            {
                MessageBox.Show("Mã kho đi không được để trống", "Hệ Thống Cảnh Báo");
                return false;
            }
            if (checkDateTime(makNgaychungtu.Text) != "true")
            {
                MessageBox.Show(checkDateTime(makNgaychungtu.Text), "Hệ Thống Cảnh Báo");
                return false;
            }
            if (cbxDenkho.Text.Length == 0)
            {
                MessageBox.Show("Ma kho đến không được để trống", "Hệ Thống Cảnh Báo");
                return false;
            }
            if (dgvInsertOrder == null)
            {
                MessageBox.Show("Chi tiết điều chuyển kho không được để trống", "Hệ Thống Cảnh Báo");
                return false;
            }


            return true;
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

        #region Xử lý giá trị truyền tới
        public void XuLyString(string str2, DataGridViewRow dgvR)
        {
            try
            {
                txtSochungtu.ReadOnly = true;

                if (str2 == "Them")
                {
                    //////////////////////////MRK FIX
                    //string tenkho = "";
                    string makhoK = new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen;
                    if (makhoK == "")
                    {
                        MessageBox.Show("Bạn chưa cài đặt kho - Xin hãy kiểm tra lại", "Hệ thống cảnh báo");
                        return;
                    }
                    /////////////////////////////////
                    LayKhoHang(cbxTukho, makhoK);
                    LayKhoHang(cbxDenkho, "");
                    this.Text = " Thêm phiếu điều chuyển kho";
                    tssSua.Enabled = false;
                    txtSochungtu.Text = LayID("PhieuDieuChuyenKho");
                    makNgaychungtu.Text = xulyNgay(datesv);
                }
                if (str2 == "Sua")
                {
                    LayKhoHang(cbxTukho, dgvR.Cells["TuKho"].Value.ToString());
                    LayKhoHang(cbxDenkho, dgvR.Cells["DenKho"].Value.ToString());

                    if ((bool)dgvR.Cells["XacNhan"].Value)
                    {
                        palXem.Enabled = false;
                        palThem.Enabled = false;
                        tssSua.Enabled = false;
                        tsslthemmoi.Enabled = false;
                        txtDiengiai.Enabled = false;
                        cbxTukho.Enabled = false;
                        cbxDenkho.Enabled = false;
                        makNgaychungtu.Enabled = false;
                    }

                    this.Text = " Sửa phiếu điều chuyển kho";
                    HienThi(dgvR);

                    HienThiChiTietTheoPDCK(txtSochungtu.Text);
                    tsslthemmoi.Enabled = false;

                }
            }
            catch { }
        }
        #endregion

        #region hien thi
        public void HienThi(DataGridViewRow dgvR)
        {
            try
            {
                PDCKID = (int)dgvR.Cells["PhieuDieuChuyenKhoID"].Value;
                maPDCK = txtSochungtu.Text = dgvR.Cells["MaPhieuDieuChuyenKho"].Value.ToString();
                Entities.KhoHang kho1 = (Entities.KhoHang)cbxTukho.SelectedItem;
                Entities.KhoHang kho2 = (Entities.KhoHang)cbxDenkho.SelectedItem;
                tukho = kho1.MaKho;// = dgvR.Cells["TuKho"].Value.ToString();
                denkho = kho2.MaKho;//= dgvR.Cells["DenKho"].Value.ToString();
                check_Xacnhan.Checked = Boolean.Parse(dgvR.Cells["XacNhan"].Value.ToString());
                ghichu = txtDiengiai.Text = dgvR.Cells["GhiChu"].Value.ToString();
                ngaychungtu = makNgaychungtu.Text = xulyNgay(Convert.ToDateTime(dgvR.Cells["NgayDieuChuyen"].Value.ToString()));
            }
            catch
            {
            }
        }
        #endregion

        public void HienThiChiTietTheoPDCK(string Phieudieuchuyenkho)
        {
            try
            {

                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);

                Entities.ChiTietPhieuDieuChuyenKho kh = new Entities.ChiTietPhieuDieuChuyenKho("Select");
                clientstrem = cl.SerializeObj(this.client1, "ChiTietPhieuDieuCHuyenKhoNoiBo", kh);

                Entities.ChiTietPhieuDieuChuyenKho[] kh1 = new Entities.ChiTietPhieuDieuChuyenKho[1];
                kh1 = (Entities.ChiTietPhieuDieuChuyenKho[])cl.DeserializeHepper1(clientstrem, kh1);

                if (kh1 != null)
                {
                    ctcount = 0;
                    for (int i = 0; i < kh1.Length; i++)
                    {
                        if (kh1[i].MaPhieuDieuChuyenKho == Phieudieuchuyenkho)
                        {
                            ctcount++;
                        }
                    }

                    Entities.ChiTietPhieuDieuChuyenKho[] ctpdck1 = new Entities.ChiTietPhieuDieuChuyenKho[ctcount];
                    ctcount = 0;
                    for (int i = 0; i < kh1.Length; i++)
                    {
                        if (kh1[i].MaPhieuDieuChuyenKho == txtSochungtu.Text)
                        {
                            ctpdck1[ctcount] = kh1[i];
                            ctcount++;
                        }
                    }
                    for (int i = 0; i < ctcount; i++)
                    {
                        arr.Add(ctpdck1[i]);
                    }
                    arrct = new Entities.ChiTietPhieuDieuChuyenKho[ctcount];
                    for (int i = 0; i < ctcount; i++)
                    {
                        arrct[i] = ctpdck1[i];
                    }
                    LayBangHangHoa();
                    for (int i = 0; i < ctpdck1.Length; i++)
                    {
                        for (int j = 0; j < hanghoa.Length; j++)
                        {
                            if (ctpdck1[i].MaHangHoa == hanghoa[j].MaHangHoa)
                            {
                                ctpdck1[i].TenHangHoa = hanghoa[j].TenHangHoa;
                                break;
                            }
                        }

                    }
                    CtPdck_BaoCao = ctpdck1;
                    dgvInsertOrder.DataSource = ctpdck1;
                    FixDataGridView();
                }
            }
            catch
            {

            }
        }

        Entities.KhoHang[] kh1 = new Entities.KhoHang[1];
        #region lay kho hang
        public void LayKhoHang(ComboBox cbb, string str)
        {
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

            Entities.KhoHang kh = new Entities.KhoHang();
            kh = new Entities.KhoHang("Select");
            clientstrem = cl.SerializeObj(this.client1, "KhoHang", kh);
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

        #region hien thi chi tiet phieu dieu chuyen
        public void HienThiChiTiet(string maHDNhap, string makho)
        {
            try
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
                            hdn[ctcount].SoLuong = h.SoLuong;
                            ctcount++;
                        }
                    }

                    Server_Client.Client cl1 = new Server_Client.Client();
                    this.client1 = cl1.Connect(Luu.IP, Luu.Ports);

                    Entities.ChiTietKhoHangTheoHoaHonNhap[] kho = new Entities.ChiTietKhoHangTheoHoaHonNhap[1];
                    kho[0] = new Entities.ChiTietKhoHangTheoHoaHonNhap("Select");
                    clientstrem = cl.SerializeObj(this.client1, "ChiTietKho", kho);

                    Entities.ChiTietKhoHangTheoHoaHonNhap[] kho1 = new Entities.ChiTietKhoHangTheoHoaHonNhap[1];
                    kho1 = (Entities.ChiTietKhoHangTheoHoaHonNhap[])cl.DeserializeHepper1(clientstrem, kho1);


                    Entities.ChiTietPhieuDieuChuyenKho[] ctdck = new Entities.ChiTietPhieuDieuChuyenKho[ctcount];
                    for (int i = 0; i < ctdck.Length; i++)
                    {
                        ctdck[i] = new Entities.ChiTietPhieuDieuChuyenKho();
                        ctdck[i].MaHangHoa = hdn[i].MaHangHoa;
                        ctdck[i].SoLuong = hdn[i].SoLuong;
                        ctdck[i].MaPhieuDieuChuyenKho = txtSochungtu.Text;
                        if (kho1 != null)
                        {
                            for (int j = 0; j < kho1.Length; j++)
                            {
                                if (kho1[j].Makho == makho & kho1[j].Mahanghoa == hdn[i].MaHangHoa)
                                {
                                    ctdck[i].NgayHetHan = kho1[j].Ngayhethan;
                                    break;
                                }
                            }
                        }

                    }
                    for (int i = 0; i < ctcount; i++)
                    {
                        arr.Add(ctdck[i]);
                    }
                    arrct = new Entities.ChiTietPhieuDieuChuyenKho[ctcount];
                    for (int i = 0; i < ctcount; i++)
                    {
                        arrct[i] = ctdck[i];
                    }
                    LayBangHangHoa();
                    for (int i = 0; i < ctdck.Length; i++)
                    {
                        for (int j = 0; j < hanghoa.Length; j++)
                        {
                            if (hanghoa[j].MaHangHoa == ctdck[i].MaHangHoa)
                            {
                                ctdck[i].TenHangHoa = hanghoa[j].TenHangHoa;
                                break;
                            }
                        }
                    }
                    CtPdck_BaoCao = ctdck;
                    dgvInsertOrder.DataSource = ctdck;
                    FixDataGridView();
                }
            }
            catch
            {

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
            dgvInsertOrder.Columns["SoLuong"].HeaderText = "Số Lượng";
            dgvInsertOrder.Columns["NgayHetHan"].HeaderText = "Ngày Hết Hạn";
            dgvInsertOrder.Columns["TenHangHoa"].HeaderText = "Tên Hàng Hóa";

        }
        #endregion

        #region check() check conflict

        public string Check(Entities.PhieuDieuChuyenKhoNoiBo pdck)
        {
            string gt = "ok";
            string ngaychungtunew = xulyNgay(pdck.NgayDieuChuyen);

            if (ngaychungtu != ngaychungtunew)
            {
                ngaychungtu = makNgaychungtu.Text = ngaychungtunew;
                gt = "ko";
            }

            if (tukho != pdck.TuKho)
            {
                tukho = cbxTukho.Text = pdck.TuKho;
                gt = "ko";
            }
            if (denkho != pdck.DenKho)
            {
                denkho = cbxDenkho.Text = pdck.DenKho;
                gt = "ko";
            }
            if (ghichu != pdck.GhiChu)
            {
                ghichu = txtDiengiai.Text = pdck.GhiChu;
                gt = "ko";
            }

            if (gt == "ko")
            {
                MessageBox.Show("Dữ liệu đã có thay đổi trước, ấn ok để cập nhật lại.");
            }

            return gt;
        }
        #endregion

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            frmBaoCaorpt rpt = new frmBaoCaorpt(CtPdck_BaoCao, makNgaychungtu.Text, "", txtSochungtu.Text, cbxTukho.Text, cbxDenkho.Text);
            rpt.Show();
        }

        public void CheckConflictUpdate()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.PhieuDieuChuyenKhoNoiBo pt = new Entities.PhieuDieuChuyenKhoNoiBo("Select", 1);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.PhieuDieuChuyenKhoNoiBo[] nv1 = new Entities.PhieuDieuChuyenKhoNoiBo[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuDieuCHuyenKhoNoiBo", pt);
                // đổ mảng đối tượng vào datagripview
                Entities.PhieuDieuChuyenKhoNoiBo[] nv2 = (Entities.PhieuDieuChuyenKhoNoiBo[])cl.DeserializeHepper1(clientstrem, nv1);
                if (nv2 != null)
                {
                    for (int j = 0; j < nv2.Length; j++)
                    {
                        if (nv2[j].MaPhieuDieuChuyenKho == maPDCK)
                        {

                            kt = Check(nv2[j]);
                            break;
                        }
                        else
                            kt = "null";
                    }
                }
            }
            catch
            {
            }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    CheckConflictUpdate();
                    if (kt == "ok")
                    {
                        Server_Client.Client cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.KhoHang kho1 = (Entities.KhoHang)cbxTukho.SelectedItem;
                        Entities.KhoHang kho2 = (Entities.KhoHang)cbxDenkho.SelectedItem;
                        Entities.PhieuDieuChuyenKhoNoiBo nv = new Entities.PhieuDieuChuyenKhoNoiBo("Update", PDCKID, txtSochungtu.Text, ConvertDatetime(makNgaychungtu.Text), kho1.MaKho, "a", kho2.MaKho, "a", "", false, txtDiengiai.Text, false);
                        clientstrem = cl.SerializeObj(this.client1, "PhieuDieuCHuyenKhoNoiBo", nv);

                        int msg = 0;
                        msg = (int)cl.DeserializeHepper(clientstrem, msg);
                        if (msg != 1)
                            MessageBox.Show("Update that bai");

                        maPDCK = txtSochungtu.Text;
                        ngaychungtu = xulyNgay(ConvertDatetime(makNgaychungtu.Text));
                        tukho = kho1.MaKho;
                        denkho = kho2.MaKho;
                        ghichu = txtDiengiai.Text;


                        cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.ChiTietPhieuDieuChuyenKho ctpdck11 = new Entities.ChiTietPhieuDieuChuyenKho("Delete", maPDCK);
                        clientstrem = cl.SerializeObj(this.client1, "ChiTietPhieuDieuCHuyenKhoNoiBo", ctpdck11);
                        int msg1 = 0;
                        msg1 = (int)cl.DeserializeHepper(clientstrem, msg1);

                        int count = 0;
                        int kiemtra = 1;
                        Server_Client.Client cl1 = new Server_Client.Client();
                        TcpClient client2;
                        NetworkStream stream;
                        while ((count < arrct.Length) && (kiemtra == 1))
                        {
                            cl1 = new Server_Client.Client();
                            client2 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.ChiTietPhieuDieuChuyenKho ctpdck = new Entities.ChiTietPhieuDieuChuyenKho("Insert", arrct[count].MaPhieuDieuChuyenKho, arrct[count].MaHangHoa, arrct[count].SoLuong, arrct[count].NgayHetHan, " ", false);
                            stream = cl.SerializeObj(client2, "ChiTietPhieuDieuCHuyenKhoNoiBo", ctpdck);
                            kiemtra = (int)cl.DeserializeHepper(stream, kiemtra);
                            count++;
                        }

                        this.Close();
                    }
                }
            }
            catch { }
        }

        public void UpdatePDCK()
        {

        }

        string kt;
        #region check conflict insert
        public void CheckConflictInsert()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.PhieuDieuChuyenKhoNoiBo pt = new Entities.PhieuDieuChuyenKhoNoiBo("Select", 1);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.PhieuDieuChuyenKhoNoiBo[] pt1 = new Entities.PhieuDieuChuyenKhoNoiBo[1];
                clientstrem = cl.SerializeObj(this.client1, "PhieuDieuCHuyenKhoNoiBo", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.PhieuDieuChuyenKhoNoiBo[])cl.DeserializeHepper1(clientstrem, pt1);
                if (pt1 != null)
                {
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        if (pt1[j].MaPhieuDieuChuyenKho == txtSochungtu.Text)
                        {
                            MessageBox.Show("cập nhật số chứng từ - kiểm tra lại để insert");
                            kt = "ko";
                            txtSochungtu.Text = LayID("PhieuDieuChuyenKho");
                            break;
                        }
                        else
                            kt = "ok";
                    }
                }
                else
                {
                    kt = "ok";
                }
            }
            catch
            {
            }
        }
        #endregion

        private void tsslthemmoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    CheckConflictInsert();
                    if (kt == "ok")
                    {
                        cl = new Server_Client.Client();
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        Entities.KhoHang kho1 = (Entities.KhoHang)cbxTukho.SelectedItem;
                        Entities.KhoHang kho2 = (Entities.KhoHang)cbxDenkho.SelectedItem;
                        Entities.PhieuDieuChuyenKhoNoiBo nv = new Entities.PhieuDieuChuyenKhoNoiBo("Insert", 1, txtSochungtu.Text, ConvertDatetime(makNgaychungtu.Text), kho1.MaKho, "a", kho2.MaKho, "a", "", false, txtDiengiai.Text, false);
                        clientstrem = cl.SerializeObj(this.client1, "PhieuDieuCHuyenKhoNoiBo", nv);
                        int msg = 0;
                        msg = (int)cl.DeserializeHepper(clientstrem, msg);
                        if (msg != 1)
                        {
                            MessageBox.Show("Insert Thất Bại");
                        }
                        txtSochungtu.Text = LayID("PhieuDieuCHuyenKho");
                        makNgaychungtu.Text = "";
                        tukho = kho1.MaKho;
                        denkho = kho2.MaKho;

                        int count = 0;
                        int kiemtra = 1;
                        Server_Client.Client cl1 = new Server_Client.Client();
                        TcpClient client2;
                        NetworkStream stream;
                        while ((count < arrct.Length) && (kiemtra == 1))
                        {
                            cl1 = new Server_Client.Client();
                            client2 = cl.Connect(Luu.IP, Luu.Ports);
                            Entities.ChiTietPhieuDieuChuyenKho ctpdck = new Entities.ChiTietPhieuDieuChuyenKho("Insert", arrct[count].MaPhieuDieuChuyenKho, arrct[count].MaHangHoa, arrct[count].SoLuong, arrct[count].NgayHetHan, " ", false);
                            stream = cl.SerializeObj(client2, "ChiTietPhieuDieuCHuyenKhoNoiBo", ctpdck);
                            kiemtra = (int)cl.DeserializeHepper(stream, kiemtra);
                            count++;
                        }
                        dgvInsertOrder.DataSource = new Entities.ChiTietPhieuDieuChuyenKho[0];
                        FixDataGridView();
                        arrct = null;
                        arr.Clear();
                        frmHienThi_DieuChuyenKhoNoiBo.KiemTra = "insert";
                        this.Close();
                    }
                }
            }
            catch { }
        }

        private void btnTimsochungtunhap_Click(object sender, EventArgs e)
        {
            Entities.KhoHang kho1 = (Entities.KhoHang)cbxTukho.SelectedItem;
            frmTraCuuHDNhap fr = new frmTraCuuHDNhap("theo_HDNhap", kho1.MaKho);
            fr.ShowDialog();
        }



        private void thiêtLâpThôngSôToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void cbxTukho_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxTukho.Text == cbxDenkho.Text)
                {
                    MessageBox.Show("Kho đi phải khác kho đến. Mời chọn lại kho!");
                    cbxTukho.SelectedIndex = -1;
                    cbxTukho.Focus();
                }
                else
                {
                    dgvInsertOrder.DataSource = new Entities.ChiTietPhieuDieuChuyenKho[0];
                    arr.Clear();
                    ctcount = 0;
                    FixDataGridView();
                    toolStrip_txtSoluong.Text = "1";
                    toolStrip_txtTracuu.Text = "";
                }
            }
            catch { }
        }

        private void txtSochungtunhap_TextChanged(object sender, EventArgs e)
        {
            dgvInsertOrder.DataSource = new Entities.ChiTietPhieuDieuChuyenKho[0];
            FixDataGridView();
            toolStrip_Insert.Enabled = true;
            arr.Clear();
            ctcount = 0;
        }

        #region Lấy Bảng Hàng Hóa
        public Entities.HangHoa[] hanghoa;
        public void LayBangHangHoa()
        {
            try
            {
                Entities.CheckRefer Checkrefer;
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Checkrefer = new Entities.CheckRefer("HH", "");
                clientstrem = cl.SerializeObj(this.client1, "Select", Checkrefer);
                Entities.HangHoa[] hh1 = new Entities.HangHoa[1];
                hh1 = (Entities.HangHoa[])cl.DeserializeHepper(clientstrem, hh1);
                if (hh1 != null)
                {
                    hanghoa = hh1;
                }
                else
                {
                    hanghoa = new Entities.HangHoa[0];
                }
            }
            catch
            {
            }
        }
        #endregion

        //=======================================MRK FIX
        public string LayMaKho(string tenKho)
        {
            try
            {
                for (int j = 0; j < kh1.Length; j++)
                {
                    if (kh1[j].TenKho == tenKho)
                    {
                        return kh1[j].MaKho;
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        void KiemTraHangHoaTrongKho()
        {
            Entities.HangHoa[] kh1;
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.HangHoa kh = new Entities.HangHoa();
            string makho = LayMaKho(this.cbxTukho.Text);
            kh = new Entities.HangHoa("SelectTheoKho", makho);
            clientstrem = cl.SerializeObj(this.client1, "HangHoa", kh);
            kh1 = new Entities.HangHoa[1];
            kh1 = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, kh1);
            if (kh1 == null)
                kh1 = new Entities.HangHoa[0];

            if (kh1.Length > 0)
            {
                bool ktdata = false;
                int sl = kh1.Length;
                for (int i = 0; i < sl; i++)
                {
                    if (kh1[i].Deleted == false)
                        if (kh1[i].MaHangHoa == toolStrip_txtTracuu.Text)
                        {
                            toolStrip_txtTracuu.Text = kh1[i].MaHangHoa;
                            toolStrip_txtTen.Text = kh1[i].TenHangHoa;
                            toolStrip_txtSoluong.Focus();
                            ktdata = true;
                            break;
                        }
                }
                if (ktdata == false)
                {
                    toolStrip_txtTen.Text = "";
                    toolStrip_txtSoluong.Text = "1";
                    this.khongcohanghoatrongkho = true;
                }
            }
            else
            {
                toolStrip_txtTen.Text = "";
                toolStrip_txtSoluong.Text = "1";
                this.khongcohanghoatrongkho = true;
            }
        }
        //==============================================

        private void toolStrip_txtTracuu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F4)
                {
                    Entities.KhoHang kho1 = (Entities.KhoHang)cbxTukho.SelectedItem;
                    frmTraCuuHDNhap fr = new frmTraCuuHDNhap("theo_Kho", kho1.MaKho);
                    fr.ShowDialog();
                    if (ct != null)
                    {
                        LayBangHangHoa();
                        toolStrip_txtTracuu.Text = ct.Cells["MaHangHoa"].Value.ToString();
                        toolStrip_txtSoluong.Text = "1";
                        for (int i = 0; i < hanghoa.Length; i++)
                        {
                            if (hanghoa[i].MaHangHoa.ToUpper().Equals(toolStrip_txtTracuu.Text.ToUpper()))
                            {
                                toolStrip_txtTen.Text = hanghoa[i].TenHangHoa;
                                toolStrip_txtSoluong.Focus();
                                break;
                            }
                        }
                    }
                }
                if (e.KeyCode == Keys.Enter)
                {
                    ////////////////////////////////MRK FIX
                    if (toolStrip_txtTracuu.Text.Length > 0)
                    {
                        //if (toolStrip_txtTen.Equals(""))
                        //{
                        string mahanghoa = toolStrip_txtTracuu.Text.ToUpper();

                        // la hang hoa
                        bool isHangHoa = false;
                        LayBangHangHoa();
                        toolStrip_txtSoluong.Text = "1";
                        for (int i = 0; i < hanghoa.Length; i++)
                        {
                            if (hanghoa[i].MaHangHoa.ToUpper().Equals(toolStrip_txtTracuu.Text.ToUpper()))
                            {
                                toolStrip_txtTen.Text = hanghoa[i].TenHangHoa;
                                isHangHoa = true;
                                break;
                            }
                        }

                        if (isHangHoa)
                        {
                            //Quy Đổi
                            foreach (Entities.QuyDoiDonViTinh item in quidoidvt)
                            {
                                if (item.MaHangQuyDoi == mahanghoa)
                                {
                                    toolStrip_txtTracuu.Text = item.MaHangDuocQuyDoi.ToUpper();
                                    toolStrip_txtTen.Text = item.TenHangDuocQuyDoi;
                                    dangquydoiDVT = true;
                                    break;
                                }
                            }
                        }

                        // khong tim thay hang hoa.
                        if (!isHangHoa)
                        {
                            MessageBox.Show("Kho co hàng hoá này trong kho!");
                            toolStrip_txtTracuu.Text = string.Empty;
                            toolStrip_txtTen.Text = string.Empty;
                            toolStrip_txtSoluong.Text = "0";
                            return;
                        }

                        toolStrip_txtSoluong.Focus();
                    }
                    ////////////////////////////////////////
                }

            }
            catch
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maKho"></param>
        /// <returns></returns>
        public Entities.ChiTietKhoHangTheoMa[] GetChitietKho(string maKho)
        {

            Entities.ChiTietKhoHangTheoMa[] arr = new Entities.ChiTietKhoHangTheoMa[1];
            try
            {
                Entities.TruyenGiaTri top = new Entities.TruyenGiaTri();
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                top = new Entities.TruyenGiaTri("Select", maKho);
                this.clientstrem = cl.SerializeObj(this.client1, "ChiTietKhoTheoMaKho", top);
                arr = (Entities.ChiTietKhoHangTheoMa[])cl.DeserializeHepper(clientstrem, arr);
            }
            catch (Exception)
            {

            }

            return arr;
        }

        /// <summary>
        /// Lay ngay het han 
        /// </summary>
        /// <param name="maHangHoa"></param>
        /// <param name="maKho"></param>
        /// <returns></returns>
        public DateTime GetNgayHetHan(string maHangHoa, Entities.ChiTietKhoHangTheoMa[] ctkhoArr)
        {
            DateTime dt = new DateTime();
            try
            {
                if (ctkhoArr != null && ctkhoArr.Count() > 0)
                {
                    foreach (Entities.ChiTietKhoHangTheoMa item in ctkhoArr)
                    {
                        if (maHangHoa.ToUpper().Equals(item.MaHangHoa))
                            dt = item.Ngayhethan;
                    }
                }
            }
            catch (Exception)
            {

            }

            return dt;
        }

        private void toolStrip_btnThem_Click(object sender, EventArgs e)
        {   //ấn btn thêm
            try
            {
                if (Convert.ToInt32(toolStrip_txtSoluong.Text) <= 0)
                {
                    MessageBox.Show("Số Lượng Điều Chuyển Phải Lớn Hơn 0.");
                    return;
                }
                if (string.IsNullOrEmpty(toolStrip_txtTen.Text))
                {
                    MessageBox.Show("Mã hàng hoá không hợp lệ hãy kiểm tra lại");
                    return;
                }
                else
                {
                    if (ct != null) //ct là một datagridRow quăng từ frm Chọn mã hàng hóa.  => khác rỗng!
                    {
                        int kt = -1;
                        Entities.ChiTietPhieuDieuChuyenKho ctpdck = new Entities.ChiTietPhieuDieuChuyenKho();

                        #region hiện tại ctcount = 0 => kt không thay đổi (nếu ctcount lớn hơn 0 thì kiểm tra để thay đổi biến kt)
                        if (ctcount > 0)    //[ctcount: chưa rõ để làm gì?]
                        {
                            for (int i = 0; i < ctcount; i++)
                            {
                                Entities.ChiTietPhieuDieuChuyenKho ct1 = (Entities.ChiTietPhieuDieuChuyenKho)arr[i];
                                if (ct1.MaHangHoa == toolStrip_txtTracuu.Text)
                                {
                                    kt = i;
                                    ct1.MaHangHoa = toolStrip_txtTracuu.Text;
                                    ct1.TenHangHoa = toolStrip_txtTen.Text;
                                    ct1.SoLuong = ct1.SoLuong + int.Parse(toolStrip_txtSoluong.Text);
                                }
                            }
                        }
                        #endregion

                        if (kt != -1)
                        {
                            arrct = new Entities.ChiTietPhieuDieuChuyenKho[ctcount];
                            for (int j = 0; j < ctcount; j++)
                            {
                                arrct[j] = (Entities.ChiTietPhieuDieuChuyenKho)arr[j];
                            }
                        }
                        else
                        {
                            //Check: Hàng hóa, gói hàng
                            string mahanghoa = toolStrip_txtTracuu.Text;
                            if (Common.Utilities.CheckHangHoaOrGoiHang(mahanghoa, this.goihang, this.chitietgoihang))
                            { //là gói hàng
                                //lấy hàng hóa trong gói hàng
                                Entities.tem1[] dshh = this.LayHangHoaTrongGoiHang(mahanghoa, this.goihang, this.chitietgoihang);
                                for (int i = 0; i < dshh.Length; i++)
                                {
                                    bool kiemtraquydoi = false;
                                    //kiểm tra có phải quy đổi đơn vị tính không?
                                    foreach (Entities.QuyDoiDonViTinh item in quidoidvt)
                                    {
                                        if (item.MaHangQuyDoi.Equals(dshh[i].MaHangHoa))
                                        {
                                            ctpdck.MaPhieuDieuChuyenKho = txtSochungtu.Text;
                                            ctpdck.MaHangHoa = item.MaHangDuocQuyDoi;
                                            ctpdck.TenHangHoa = item.TenHangDuocQuyDoi;
                                            ctpdck.SoLuong = ((Convert.ToInt32(item.SoLuongDuocQuyDoi) * Convert.ToInt32(dshh[i].SoLuong)) / item.SoLuongQuyDoi) * Convert.ToInt32(toolStrip_txtSoluong.Text);
                                            ctpdck.NgayHetHan = GetNgayHetHan(ctpdck.MaHangHoa, this.ctkArr);
                                            kiemtraquydoi = true;
                                            break;
                                        }
                                    }
                                    if (kiemtraquydoi) { }
                                    else
                                    {
                                        ctpdck.MaPhieuDieuChuyenKho = txtSochungtu.Text;
                                        ctpdck.MaHangHoa = dshh[i].MaHangHoa;
                                        ctpdck.TenHangHoa = dshh[i].TenHangHoa;
                                        ctpdck.SoLuong = Convert.ToInt32(dshh[i].SoLuong) * Convert.ToInt32(toolStrip_txtSoluong.Text);
                                        ctpdck.NgayHetHan = GetNgayHetHan(ctpdck.MaHangHoa, this.ctkArr);
                                    }
                                    arr.Add(ctpdck);
                                    ctcount++;
                                }
                                arrct = new Entities.ChiTietPhieuDieuChuyenKho[ctcount];
                                for (int i = 0; i < ctcount; i++)
                                {
                                    arrct[i] = (Entities.ChiTietPhieuDieuChuyenKho)arr[i];
                                }
                            }   //end Gói hàng
                            else
                            {//là hàng hóa
                                bool kiemtraquydoi = false;
                                //kiểm tra có phải quy đổi đơn vị tính không?
                                foreach (Entities.QuyDoiDonViTinh item in quidoidvt)
                                {
                                    if (item.MaHangQuyDoi.Equals(mahanghoa))
                                    {
                                        ctpdck.MaPhieuDieuChuyenKho = txtSochungtu.Text;
                                        ctpdck.MaHangHoa = item.MaHangDuocQuyDoi;
                                        ctpdck.TenHangHoa = item.TenHangDuocQuyDoi;
                                        ctpdck.SoLuong = (Convert.ToInt32(item.SoLuongDuocQuyDoi) * Convert.ToInt32(toolStrip_txtSoluong.Text)) / item.SoLuongQuyDoi;
                                        ctpdck.NgayHetHan = GetNgayHetHan(ctpdck.MaHangHoa, this.ctkArr);
                                        kiemtraquydoi = true;
                                        break;
                                    }
                                }
                                if (kiemtraquydoi) { }
                                else
                                {
                                    ctpdck.MaPhieuDieuChuyenKho = txtSochungtu.Text;
                                    ctpdck.MaHangHoa = mahanghoa;
                                    ctpdck.TenHangHoa = toolStrip_txtTen.Text;
                                    ctpdck.SoLuong = Convert.ToInt32(toolStrip_txtSoluong.Text);
                                    ctpdck.NgayHetHan = GetNgayHetHan(ctpdck.MaHangHoa, this.ctkArr);
                                }
                                arr.Add(ctpdck);
                                ctcount++;
                                arrct = new Entities.ChiTietPhieuDieuChuyenKho[ctcount];
                                for (int i = 0; i < ctcount; i++)
                                {
                                    arrct[i] = (Entities.ChiTietPhieuDieuChuyenKho)arr[i];
                                }
                            }///end hàng hóa

                        }
                        dgvInsertOrder.DataSource = arrct;
                        FixDataGridView();
                    }
                }
            }
            catch { }
        }

        //clip đúp vào datagridview 
        private void dgvInsertOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //không có số chứng từ nhập
            if (e.RowIndex >= 0)
            {
                Entities.ChiTietPhieuDieuChuyenKho cta = (Entities.ChiTietPhieuDieuChuyenKho)arr[e.RowIndex];
                toolStrip_txtSoluong.Text = cta.SoLuong.ToString();
                toolStrip_txtTracuu.Text = cta.MaHangHoa;
                toolStrip_txtTen.Text = cta.TenHangHoa;
                arr.RemoveAt(e.RowIndex);

                arrct = new Entities.ChiTietPhieuDieuChuyenKho[arrct.Length - 1];
                for (int i = 0; i < arrct.Length; i++)
                {
                    arrct[i] = (Entities.ChiTietPhieuDieuChuyenKho)arr[i];
                }
                dgvInsertOrder.DataSource = arrct;
                ctcount = arrct.Length;
                FixDataGridView();
            }
        }

        //nếu chưa nhập mã hàng hóa thì vô hiệu hóa nút thêm
        private void toolStrip_txtTracuu_TextChanged(object sender, EventArgs e)
        {
            if (toolStrip_txtTracuu.Text != "<F4-Tra cứu>")
            {
                toolStrip_btnThem.Enabled = true;
            }
        }

        //kho đến phải khác kho đi
        private void cbxDenkho_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTukho.Text == cbxDenkho.Text)
            {
                MessageBox.Show("Kho đi phải khác kho đến. Mời chọn lại kho!");
                cbxDenkho.SelectedIndex = -1;
                cbxDenkho.Focus();
            }
        }

        //định dạng số lượng 0:0
        private void toolStrip_txtSoluong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Double.Parse(toolStrip_txtSoluong.Text) >= 0)
                {
                    toolStrip_txtSoluong.Text = String.Format("{0:0}", toolStrip_txtSoluong.Text);
                    return;
                }
            }
            catch
            {
                toolStrip_txtSoluong.Text = "";
            }
        }

        //chỉ cho phép nhập số
        private void toolStrip_txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch
            { }
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
