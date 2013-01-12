using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.Collections;

namespace GUI
{
    public partial class frmBCThue : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.SelectAll selectall;
        Entities.HDBanHang[] hdbanhang;
        Entities.ChiTietHDBanHang[] chitiethdbanhang;
        Entities.Thue[] thue;
        Entities.HangHoa[] hanghoa;
        Entities.BCThue[] hienthi;
        Entities.BCThue[] hienthibaocao;
        DateTime datesv;
        public frmBCThue()
        {
            InitializeComponent();datesv = DateServer.Date();
            datesv = DateServer.Date();
            truoc = sau = datesv;
            SelectData();
            dtgvhienthi.DataSource = new Entities.BCThue[0];
            fix();

        }

        void SelectData()
        {

            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("BCThue", new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen);
            clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
            selectall = (Entities.SelectAll)cl.DeserializeHepper(clientstrem, selectall);
            hdbanhang = selectall.HDBanHang;
            chitiethdbanhang = selectall.ChiTietHDBanHang;
            thue = selectall.Thue;
            hanghoa = selectall.HangHoaTheoKho;
            if (thue.Length != 0)
            {
                cbbThue.DataSource = thue;
                cbbThue.DisplayMember = "GiaTriThue";
                cbbThue.ValueMember = "MaThue";
                cbbThue.SelectedIndex = -1;
            }

        }

        int giatrithue = 0;
        public void TongTienNhanVien()
        {
            try
            {
                List<Entities.HangHoa> hh = new List<Entities.HangHoa>();
                foreach (Entities.HangHoa item in hanghoa)
                {

                    if (item.MaThueGiaTriGiaTang == mathue)
                    {
                        hh.Add(item);
                    }
                }
                giatrithue = 0;
                foreach (Entities.Thue item1 in thue)
                {
                    if (item1.MaThue == mathue)
                    {
                        giatrithue = int.Parse(item1.GiaTriThue);
                        break;
                    }
                }

                List<Entities.BCThue> temp = new List<Entities.BCThue>();
                foreach (Entities.HangHoa item in hh)
                {
                    double tongthue = 0;
                    foreach (Entities.ChiTietHDBanHang item1 in chitiethdbanhang)
                    {
                        if (item.MaHangHoa == item1.MaHangHoa)
                        {
                            double cktm = 0;
                            double dongia = 0;
                            foreach (Entities.HDBanHang item2 in hdbanhang)
                            {
                                if (item2.NgayBan.Date <= sau.Date && item2.NgayBan.Date >= truoc.Date)
                                {
                                    if (item1.MaHDBanHang == item2.MaHDBanHang)
                                    {
                                        if (item2.LoaiHoaDon)
                                        {
                                            dongia = double.Parse(item.GiaBanLe) - ((double.Parse(item.GiaBanLe) * (item1.PhanTramChietKhau))) / 100;
                                            break;
                                        }
                                        else
                                        {
                                            dongia = double.Parse(item.GiaBanBuon) - ((double.Parse(item.GiaBanBuon) * (item1.PhanTramChietKhau))) / 100;
                                            break;
                                        }
                                    }
                                }
                            }
                            tongthue += ((dongia * item1.SoLuong) * giatrithue) / 100;

                        }
                    }
                    Entities.BCThue te = new Entities.BCThue();
                    te.DVT = item.TenDonViTinh;
                    te.MaHangHoa = item.MaHangHoa;
                    te.TenHangHoa = item.TenHangHoa;
                    te.TongThue = tongthue;
                    temp.Add(te);
                }

                hienthi = (Entities.BCThue[])temp.ToArray();
                ///////////////////////////////MRK FIX
                List<Entities.BCThue> tem0 = new List<Entities.BCThue>();
                double tong0 = 0;
                foreach (Entities.BCThue item in hienthi)
                {
                    tong0 += item.TongThue;
                    tem0.Add(item);
                }
                Entities.BCThue tem1 = new Entities.BCThue();
                tem1.TenHangHoa = "Tổng: ";
                tem1.TongThue = tong0;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = hienthi;
                dtgvhienthi.DataSource = tem0.ToArray();

                if (hienthi.Length > 0)
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
                }
                else
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
                }
            }
            catch
            {
            }
            finally
            {
                fix();
            }
        }

        public string Format(double a)
        {
            return new Common.Utilities().FormatMoney(a);
        }

        public void fix()
        {
            dtgvhienthi.ReadOnly = true;
            dtgvhienthi.RowHeadersVisible = false;
            dtgvhienthi.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
            dtgvhienthi.Columns["TenHangHoa"].HeaderText = "Tên Hàng Hóa";
            dtgvhienthi.Columns["DVT"].HeaderText = "Đơn Vị Tính";
            dtgvhienthi.Columns["TongThue"].HeaderText = "Tổng Tiền";
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.AllowUserToAddRows = false;
            dtgvhienthi.AllowUserToDeleteRows = false;
            dtgvhienthi.AllowUserToResizeRows = false;
            this.Focus();
        }

        DateTime truoc;
        DateTime sau;
        private void tsslthoat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void pntop_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
        int i = 0;
        private void dtgvhienthi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Enabled = false;
            try
            {
                ///////////////////////////////MRK FIX Hiển thị
                List<Entities.BCThue> tem0 = ((Entities.BCThue[])dtgvhienthi.DataSource).ToList();
                //Entities.BCThue dau = new Entities.BCThue();
                //dau = tem0[0];
                Entities.BCThue cuoi = new Entities.BCThue();
                cuoi = tem0[tem0.Count -1];
                //tem0.Remove(dau);
                tem0.Remove(cuoi);
                ////////////////////////////////////////////////
                hienthibaocao = tem0.ToArray();
                frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, mathue, giatrithue, truoc, sau);
                a.ShowDialog();
            }
            catch
            {
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                ///////////////////////////////MRK FIX Hiển thị
                List<Entities.BCThue> tem0 = ((Entities.BCThue[])dtgvhienthi.DataSource).ToList();
                //Entities.BCThue dau = new Entities.BCThue();
                //dau = tem0[0];
                Entities.BCThue cuoi = new Entities.BCThue();
                cuoi = tem0[tem0.Count -1];
                //tem0.Remove(dau);
                tem0.Remove(cuoi);
                ////////////////////////////////////////////////
                hienthibaocao = tem0.ToArray();
                //hienthibaocao = (Entities.BCThue[])dtgvhienthi.DataSource;
                frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, mathue, giatrithue, truoc, sau);
                a.ShowDialog();
            }
            catch
            {
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                TongTienNhanVien();
            }
            catch
            {
            }
            this.Enabled = true;
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {

                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ///////////////////////////////MRK FIX Hiển thị
                    List<Entities.BCThue> tem0 = ((Entities.BCThue[])dtgvhienthi.DataSource).ToList();
                    //Entities.BCThue dau = new Entities.BCThue();
                    //dau = tem0[0];
                    Entities.BCThue cuoi = new Entities.BCThue();
                    cuoi = tem0[tem0.Count -1];
                    //tem0.Remove(dau);
                    tem0.Remove(cuoi);
                    ////////////////////////////////////////////////
                    hienthibaocao = tem0.ToArray();
                    //hienthibaocao = (Entities.BCThue[])dtgvhienthi.DataSource;
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, mathue, giatrithue,truoc,sau, saveFileDialog1.FileName, "PDF");
                }
            }
            catch
            {
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void tsslWord_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {

                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ///////////////////////////////MRK FIX Hiển thị
                    List<Entities.BCThue> tem0 = ((Entities.BCThue[])dtgvhienthi.DataSource).ToList();
                    //Entities.BCThue dau = new Entities.BCThue();
                    //dau = tem0[0];
                    Entities.BCThue cuoi = new Entities.BCThue();
                    cuoi = tem0[tem0.Count -1];
                    //tem0.Remove(dau);
                    tem0.Remove(cuoi);
                    ////////////////////////////////////////////////
                    hienthibaocao = tem0.ToArray();
                    //hienthibaocao = (Entities.BCThue[])dtgvhienthi.DataSource;
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, mathue, giatrithue, truoc, sau, saveFileDialog1.FileName, "Word");
                }
            }
            catch
            {
            }
            finally
            {

                this.Enabled = true;
            }
        }

        private void tsslexcel_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {

                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ///////////////////////////////MRK FIX Hiển thị
                    List<Entities.BCThue> tem0 = ((Entities.BCThue[])dtgvhienthi.DataSource).ToList();
                    //Entities.BCThue dau = new Entities.BCThue();
                    //dau = tem0[0];
                    Entities.BCThue cuoi = new Entities.BCThue();
                    cuoi = tem0[tem0.Count -1];
                    //tem0.Remove(dau);
                    tem0.Remove(cuoi);
                    ////////////////////////////////////////////////
                    hienthibaocao = tem0.ToArray();
                    //hienthibaocao = (Entities.BCThue[])dtgvhienthi.DataSource;
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, mathue, giatrithue, truoc, sau, saveFileDialog1.FileName, "Excel");
                }
            }
            catch
            {
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                SelectData();

                TongTienNhanVien();
                this.Focus();
            }
            catch
            {
            }
            this.Enabled = true;
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbtimkiem3.Checked == true)
                {
                    return;
                }
                if (txttimkiem.Text.Length == 0)
                {
                    dtgvhienthi.DataSource = new Entities.BCThue[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtimkiem1.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaHangHoa.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCThue[0];
                            return;
                        }
                        Entities.BCThue[] hienthitheoid = new Entities.BCThue[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaHangHoa.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        ///////////////////////////////MRK FIX
                        List<Entities.BCThue> tem0 = new List<Entities.BCThue>();
                        double tong0 = 0;
                        foreach (Entities.BCThue item in hienthitheoid)
                        {
                            tong0 += item.TongThue;
                            tem0.Add(item);
                        }
                        Entities.BCThue tem1 = new Entities.BCThue();
                        tem1.TenHangHoa = "Tổng: ";
                        tem1.TongThue = tong0;
                        tem0.Add(tem1);
                        //////////////////////////////////////
                        //dtgvhienthi.DataSource = hienthitheoid;
                        dtgvhienthi.DataSource = tem0.ToArray();

                    }
                    if (dtgvhienthi.RowCount > 0)
                    {
                        tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
                    }
                    else
                    {
                        tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
                    }
                }
            }
            finally
            {
                fix();
            }
        }

        private void rdbtimkiem3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (hienthi == null)
                {
                    dtgvhienthi.DataSource = new Entities.BCThue[0];
                    return;
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCThue> tem0 = new List<Entities.BCThue>();
                double tong0 = 0;
                foreach (Entities.BCThue item in hienthi)
                {
                    tong0 += item.TongThue;
                    tem0.Add(item);
                }
                Entities.BCThue tem1 = new Entities.BCThue();
                tem1.TenHangHoa = "Tổng: ";
                tem1.TongThue = tong0;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = hienthi;
                dtgvhienthi.DataSource = tem0.ToArray();
                //dtgvhienthi.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                fix();

            }
        }
        string mathue = "";
        private void cbbThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbThue.Text != "")
            {
                mathue = cbbThue.SelectedValue.ToString();
            }
        }
        string batdau, ketthuc;
        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                frmLocDieuKien a = new frmLocDieuKien();
                a.ShowDialog();
                if (frmLocDieuKien.truoc != "" && frmLocDieuKien.sau != "")
                {
                    this.batdau = frmLocDieuKien.truoc;
                    this.ketthuc = frmLocDieuKien.sau;
                    truoc = Convert.ToDateTime(batdau);
                    sau = Convert.ToDateTime(ketthuc);
                    TongTienNhanVien();
                    frmLocDieuKien.truoc = frmLocDieuKien.sau = "";

                }
            }
            catch
            {
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

        private void pntop_DoubleClick_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
    }
}


/////////////////////////////////MRK FIX Hiển thị
//                List<Entities.BCThue> tem0 = ((Entities.BCThue[])dtgvhienthi.DataSource).ToList();
////                Entities.BCThue dau = new Entities.BCThue();
////                dau = tem0[0];
//                Entities.BCThue cuoi = new Entities.BCThue();
//                cuoi = tem0[tem0.Count -1];
////                tem0.Remove(dau);
//                tem0.Remove(cuoi);
//                ////////////////////////////////////////////////
//                hienthibaocao = tem0.ToArray();