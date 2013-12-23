using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entities;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmHienThi_XacNhanDieuChuyenKho : Form
    {
        public frmHienThi_XacNhanDieuChuyenKho()
        {
            InitializeComponent();
        }

        PhieuDieuChuyenKhoNoiBo[] PDCK_Search;
        public TcpClient client1;
        public NetworkStream clientstrem;
        PhieuDieuChuyenKhoNoiBo Pdck;


        public void hienthi()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Pdck = new PhieuDieuChuyenKhoNoiBo("Select", 1, "a", DateServer.Date(), "a", "a", "a", "a", "a", false, "a", false);
            clientstrem = cl.SerializeObj(this.client1, "PhieuDieuCHuyenKhoNoiBo", Pdck);

            PhieuDieuChuyenKhoNoiBo[] pdck1 = new PhieuDieuChuyenKhoNoiBo[1];
            pdck1[0] = new PhieuDieuChuyenKhoNoiBo(1, "a", DateServer.Date(), "a", "a", "a", false, "a", false);
            pdck1 = (PhieuDieuChuyenKhoNoiBo[])cl.DeserializeHepper1(clientstrem, pdck1);


            ////PDCK_Search = pdck1;
            if (pdck1 == null)
            {
                Entities.PhieuDieuChuyenKhoNoiBo[] a = new PhieuDieuChuyenKhoNoiBo[0];
                dgvHienThi.DataSource = a;
                PDCK_Search = a;
                FixDataGridView();
                toolStripStatus_Sua.Enabled = false;
                toolStripStatus_ChiTiet.Enabled = false;
            }
            else
            {
                int count = 0;
                for (int i = 0; i < pdck1.Length; i++)
                {
                    if (pdck1[i].XacNhan == false)
                    {
                        count++;
                    }
                }
                PhieuDieuChuyenKhoNoiBo[] pdck2 = new PhieuDieuChuyenKhoNoiBo[count];
                count = 0;
                for (int i = 0; i < pdck1.Length; i++)
                {
                    if (pdck1[i].XacNhan == false)
                    {
                        pdck2[count] = pdck1[i];
                        count++;
                    }
                }
                PDCK_Search = pdck2;
                dgvHienThi.DataSource = pdck2;

                FixDataGridView();
                toolStripStatus_Sua.Enabled = true;
                toolStripStatus_ChiTiet.Enabled = true;
            }

        }

        public void FixDataGridView()
        {
            dgvHienThi.RowHeadersVisible = false;
            dgvHienThi.Columns[0].HeaderText = "STT";
            dgvHienThi.Columns[dgvHienThi.ColumnCount - 1].Visible = false;
            dgvHienThi.Columns["TuKho"].Visible = false;
            dgvHienThi.Columns["DenKho"].Visible = false;

            dgvHienThi.AllowUserToResizeRows = false;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            for (int i = 0; i < dgvHienThi.ColumnCount; i++)
            {
                dgvHienThi.Columns[i].ReadOnly = true;
            }
            dgvHienThi.Columns["XacNhan"].ReadOnly = false;

            dgvHienThi.Columns["PhieuDieuChuyenKhoID"].Visible = false;
            dgvHienThi.Columns["MaPhieuDieuChuyenKho"].HeaderText = "Mã Phiếu điều chuyển";
            dgvHienThi.Columns["NgayDieuChuyen"].HeaderText = "Ngày điều chuyển";
            dgvHienThi.Columns["TenKhoDi"].HeaderText = "Từ Kho";
            dgvHienThi.Columns["TenKhoDen"].HeaderText = "Đến Kho";
            dgvHienThi.Columns["MaHoaDonNhap"].HeaderText = "Mã Hóa đơn nhập";
            dgvHienThi.Columns["XacNhan"].HeaderText = "Xác nhận";
            dgvHienThi.Columns["GhiChu"].HeaderText = "Ghi Chú";
            new Common.Utilities().CountDatagridview(dgvHienThi);

        }

        private void toolStripStatus_ChiTiet_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            frm_Xuly_XacNhanDieuChuyenKho fr = new frm_Xuly_XacNhanDieuChuyenKho(dgvHienThi.CurrentRow);
            fr.ShowDialog();
            hienthi();
        }

        private void toolStripStatus_Dong_Click(object sender, EventArgs e)
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

        private void toolStripStatus_XacNhan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("chưa xử lý");
        }

        private void frmHienThi_XacNhanDieuChuyenKho_Load(object sender, EventArgs e)
        {
            hienthi();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked == true)
            {
                for (int i = 0; i < dgvHienThi.RowCount; i++)
                {
                    dgvHienThi.Rows[i].Cells["XacNhan"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dgvHienThi.RowCount; i++)
                {
                    dgvHienThi.Rows[i].Cells["XacNhan"].Value = false;
                }
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (rdbMa.Checked == true)
            {
                if (PDCK_Search == null)
                {
                    PhieuDieuChuyenKhoNoiBo[] pdck = new PhieuDieuChuyenKhoNoiBo[0];
                    dgvHienThi.DataSource = pdck;
                    FixDataGridView();

                    toolStripStatus_Sua.Enabled = false;
                    toolStripStatus_ChiTiet.Enabled = false;


                }
                else
                    if (PDCK_Search != null)
                    {
                        if (txtTimKiem.Text.Length == 0)
                        {
                            PhieuDieuChuyenKhoNoiBo[] pdck = new PhieuDieuChuyenKhoNoiBo[0];
                            dgvHienThi.DataSource = pdck;
                            FixDataGridView();

                            toolStripStatus_Sua.Enabled = false;
                            toolStripStatus_ChiTiet.Enabled = false;

                        }
                        else
                        {
                            int tt1_search_count = 0;

                            for (int i = 0; i < PDCK_Search.Length; i++)
                            {
                                int index = -1;
                                index = PDCK_Search[i].MaPhieuDieuChuyenKho.IndexOf(txtTimKiem.Text.Trim());
                                if (index >= 0)
                                {
                                    tt1_search_count++;
                                }
                            }
                            PhieuDieuChuyenKhoNoiBo[] tt1_search = new PhieuDieuChuyenKhoNoiBo[tt1_search_count];
                            tt1_search_count = 0;

                            for (int i = 0; i < PDCK_Search.Length; i++)
                            {
                                int index = -1;
                                index = PDCK_Search[i].MaPhieuDieuChuyenKho.IndexOf(txtTimKiem.Text.Trim());
                                if (index >= 0)
                                {
                                    tt1_search[tt1_search_count] = PDCK_Search[i];
                                    tt1_search_count++;
                                }
                            }
                            if (tt1_search_count == 0)
                            {
                                toolStripStatus_Sua.Enabled = false;
                                toolStripStatus_ChiTiet.Enabled = false;
                            }
                            else
                            {
                                toolStripStatus_Sua.Enabled = true;
                                toolStripStatus_ChiTiet.Enabled = true;
                            }
                            dgvHienThi.DataSource = tt1_search;
                            FixDataGridView();
                        }
                    }
            }
        }



        private void rdbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            if (rdb.Checked == true)
            {
                hienthi();
            }
        }

        private void dgvHienThi_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgvHienThi.DataSource == null)
            {
                checkBox1.Visible = false;
            }
            else
            {
                if (dgvHienThi.DataSource != null)
                {
                    checkBox1.Visible = true;
                }
            }
        }

        private void dgvHienThi_DataMemberChanged(object sender, EventArgs e)
        {
            if (dgvHienThi.RowCount == 0)
            {
                MessageBox.Show("Khong co du lieu");
            }
        }

        private void dgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                frm_Xuly_XacNhanDieuChuyenKho fr = new frm_Xuly_XacNhanDieuChuyenKho(dgvHienThi.CurrentRow);
                fr.ShowDialog();
                hienthi();
            }
        }
        Server_Client.Client cl;
        #region lay chi tiet phieu dieu chuyen theo hdnhap
        public DataGridView HienThiChiTiet(string maHDNhap, string maPDCK, string makho)
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
                    ctdck[i].SoLuong = hdn[i].SoLuong;
                    ctdck[i].MaPhieuDieuChuyenKho = maPDCK;
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

                dgv.DataSource = ctdck;
                return dgv;
            }
            return dgv;
        }
        #endregion

        public DataGridView HienThiChiTietTheoPDCK(string Phieudieuchuyenkho)
        {
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

            Entities.ChiTietPhieuDieuChuyenKho kh = new Entities.ChiTietPhieuDieuChuyenKho("Select");
            clientstrem = cl.SerializeObj(this.client1, "ChiTietPhieuDieuCHuyenKhoNoiBo", kh);

            Entities.ChiTietPhieuDieuChuyenKho[] kh1 = new Entities.ChiTietPhieuDieuChuyenKho[1];
            kh1 = (Entities.ChiTietPhieuDieuChuyenKho[])cl.DeserializeHepper1(clientstrem, kh1);

            if (kh1 != null)
            {
                int ctcount = 0;

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
                    if (kh1[i].MaPhieuDieuChuyenKho == Phieudieuchuyenkho)
                    {
                        ctpdck1[ctcount] = new ChiTietPhieuDieuChuyenKho();
                        ctpdck1[ctcount].HanhDong = kh1[i].HanhDong;
                        ctpdck1[ctcount].MaHangHoa = kh1[i].MaHangHoa;
                        ctpdck1[ctcount].MaPhieuDieuChuyenKho = kh1[i].MaPhieuDieuChuyenKho;
                        ctpdck1[ctcount].NgayHetHan = kh1[i].NgayHetHan;
                        ctpdck1[ctcount].SoLuong = kh1[i].SoLuong;
                        ctcount++;
                    }
                }

                dgv.DataSource = ctpdck1;
                return dgv;
            }
            return dgv;

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
                            ct.Ngaynhap = DateServer.Date();
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
                    cthdbh[j] = new Entities.ChiTietKhoHangTheoHoaHonNhap("Update", maKho, dgv["MaHangHoa", j].Value.ToString(), int.Parse(dgv["SoLuong", j].Value.ToString()));
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

        private void toolStripStatus_Sua_Click(object sender, EventArgs e)
        {
            if (!frmDangNhap.User.Administrator && !CheckQuyen(this.Name, 2))
            {
                MessageBox.Show("Bạn Không có quyền vào chức năng này.");
                return;
            }
            int count = 0;

            for (int i = 0; i < dgvHienThi.RowCount; i++)
            {
                if ((bool)dgvHienThi.Rows[i].Cells["XacNhan"].Value == true)
                {
                    count++;
                }

            }
            PhieuDieuChuyenKhoNoiBo[] pdck = new PhieuDieuChuyenKhoNoiBo[count];
            count = 0;
            for (int i = 0; i < dgvHienThi.RowCount; i++)
            {
                if ((bool)dgvHienThi.Rows[i].Cells["XacNhan"].Value == true)
                {
                    pdck[count] = new PhieuDieuChuyenKhoNoiBo();
                    pdck[count].MaPhieuDieuChuyenKho = dgvHienThi.Rows[i].Cells["MaPhieuDieuChuyenKho"].Value.ToString();
                    pdck[count].MaHoaDonNhap = dgvHienThi.Rows[i].Cells["MaHoaDonNhap"].Value.ToString();
                    pdck[count].PhieuDieuChuyenKhoID = (int)dgvHienThi.Rows[i].Cells["PhieuDieuChuyenKhoID"].Value;
                    pdck[count].NgayDieuChuyen = (DateTime)dgvHienThi.Rows[i].Cells["NgayDieuChuyen"].Value;
                    pdck[count].TuKho = dgvHienThi.Rows[i].Cells["TuKho"].Value.ToString();
                    pdck[count].DenKho = dgvHienThi.Rows[i].Cells["DenKho"].Value.ToString();
                    pdck[count].GhiChu = dgvHienThi.Rows[i].Cells["GhiChu"].Value.ToString();
                    pdck[count].XacNhan = (bool)dgvHienThi.Rows[i].Cells["XacNhan"].Value;
                    count++;
                }
            }

            if (pdck != null)
            {
                int i = 0;
                int msg = 1;
                while (i < pdck.Length && msg > 0)
                {
                    Server_Client.Client cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    Entities.PhieuDieuChuyenKhoNoiBo nv = new Entities.PhieuDieuChuyenKhoNoiBo("Update", pdck[i].PhieuDieuChuyenKhoID, pdck[i].MaPhieuDieuChuyenKho, pdck[i].NgayDieuChuyen, pdck[i].TuKho, "", pdck[i].DenKho, "", pdck[i].MaHoaDonNhap, pdck[i].XacNhan, pdck[i].GhiChu, false);
                    clientstrem = cl.SerializeObj(this.client1, "PhieuDieuCHuyenKhoNoiBo", nv);
                    msg = (int)cl.DeserializeHepper(clientstrem, msg);
                    if (pdck[i].MaHoaDonNhap.Length == 0)
                    {

                        dgv.DataSource = HienThiChiTietTheoPDCK(pdck[i].MaPhieuDieuChuyenKho).DataSource;
                        int d = dgv.RowCount;
                        CheckDataGridTruSL(dgv, pdck[i].TuKho);
                        CheckDataGridCongSL1(dgv, pdck[i].DenKho);
                        CheckDataGridCongSL(dgv, pdck[i].DenKho);
                    }
                    else
                        if (pdck[i].MaHoaDonNhap.Length != 0)
                        {

                            dgv.DataSource = HienThiChiTiet(pdck[i].MaHoaDonNhap, pdck[i].MaPhieuDieuChuyenKho, pdck[i].TuKho).DataSource;
                            CheckDataGridTruSL(dgv, pdck[i].TuKho);
                            CheckDataGridCongSL1(dgv, pdck[i].DenKho);
                            CheckDataGridCongSL(dgv, pdck[i].DenKho);
                        }

                    i++;
                }
                hienthi();
            }

        }

        int a = 0;
        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            a = e.RowIndex;
            if (a >= 0)
            {
                if ((bool)dgvHienThi.Rows[a].Cells["XacNhan"].Value == true)
                {
                    dgvHienThi.Rows[a].Cells["XacNhan"].Value = false;
                }
                else
                {
                    if ((bool)dgvHienThi.Rows[a].Cells["XacNhan"].Value == false)
                    {
                        dgvHienThi.Rows[a].Cells["XacNhan"].Value = true;
                    }
                }

            }
        }
        public bool CheckQuyen(string tenform, int quyen)
        {
            switch (quyen)
            {
                case 1:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenXem;
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenSua;
                        }
                        break;
                    }
                case 3:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenXoa;
                        }
                        break;
                    }
                case 4:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenThem;
                        }
                        break;
                    }
            }
            return false;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            hienthi();
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
