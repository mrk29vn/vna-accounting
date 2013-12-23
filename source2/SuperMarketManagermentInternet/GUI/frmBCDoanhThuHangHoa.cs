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
    public partial class frmBCDoanhThuHangHoa : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.GoiHang[] goihang;
        Entities.ChiTietGoiHang[] chitietgoihang;
        DateTime datesv;
        public frmBCDoanhThuHangHoa()
        {
            try
            {
                InitializeComponent();
                SelectAll();
                datesv = DateServer.Date();
                cbbnam.Text = datesv.Year.ToString();
                cbbthang.Text = datesv.Month.ToString();
                cbbngay.Text = datesv.Day.ToString();
                batdau = Convert.ToDateTime(cbbthang.Text + "/" + cbbngay.Text + "/" + cbbnam.Text).ToShortDateString();
                ketthuc = batdau;
                truoc = Convert.ToDateTime(batdau);
                sau = Convert.ToDateTime(ketthuc);
                TongTienHangHoa(truoc, sau);
                fix();
            }
            catch
            {
            }
        }
        Entities.HDBanHang[] hdbanhang;
        Entities.SelectAll selectall;
        void SelectAll()
        {
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("BCDoanhThuMatHang", new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen);
            clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
            selectall = (Entities.SelectAll)cl.DeserializeHepper(clientstrem, selectall);
            goihang = selectall.GoiHang;
            chitietgoihang = selectall.ChiTietGoiHang;
            hdbanhang = selectall.HDBanHang;
            chitiethdbanhang = selectall.ChiTietHDBanHang;
            nv = selectall.HangHoaTheoKho;
            thue = selectall.Thue;
        }
        Entities.ChiTietHDBanHang[] chitiethdbanhang;
        Entities.HangHoa[] nv;
        Entities.Thue[] thue;
        string thuegtgt = "0";
        /// <summary>
        /// lấy giá trị thuế
        /// </summary>
        /// <param name="maThue"></param>
        private void LayGiaTriThue(string maThue)
        {
            try
            {
                if (thue.Length > 0)
                {
                    int sl = thue.Length;
                    for (int i = 0; i < sl; i++)
                    {
                        if (thue[i].Deleted == false)
                            if (thue[i].MaThue == maThue)
                            {
                                thuegtgt = thue[i].GiaTriThue;
                                return;
                            }
                    }
                }
                thuegtgt = "0";
            }
            catch
            {
                return;
            }
            finally
            {


            }
        }
        Entities.BCDTTheoHangHoa[] hienthi;
        Entities.BCDTTheoHangHoa[] hienthibaocao;
        public void TongTienHangHoa(DateTime batdau, DateTime ketthuc)
        {
            try
            {
                int sotang = 0; int sl = 0;
                //Entities.HangHoa[] hanghoa = Common.Utilities.CheckGoiHang(nv, goihang, chitietgoihang);

                List<Entities.BCDTTheoHangHoa> dtHangHoaList = new List<Entities.BCDTTheoHangHoa>();
                ArrayList arr1 = new ArrayList();
                Entities.BCDTTheoHangHoa[] bcdt = new Entities.BCDTTheoHangHoa[sotang];
                hienthibaocao = new Entities.BCDTTheoHangHoa[sl];
                sotang = 0;
                sl = 0;
                double tongtien;
                tongtien = 0;
                for (int j = 0; j < hdbanhang.Length; j++)
                {
                    DateTime hientai = hdbanhang[j].NgayBan;
                    if (hientai.Date >= batdau.Date && hientai.Date <= ketthuc.Date)
                    {
                        for (int k = 0; k < chitiethdbanhang.Length; k++)
                        {
                            if (chitiethdbanhang[k].MaHDBanHang.Equals(hdbanhang[j].MaHDBanHang))
                            {
                                string maHangHoa = chitiethdbanhang[k].MaHangHoa;
                                string tenHangHoa = chitiethdbanhang[k].TenHangHoa;
                                string maHoaDon = hdbanhang[j].MaHDBanHang;
                                DateTime ngayBan = hdbanhang[j].NgayBan;
                                double tienHang = chitiethdbanhang[k].SoLuong * double.Parse(chitiethdbanhang[k].DonGia);
                                double giaTriCK = (tienHang * double.Parse(chitiethdbanhang[k].PhanTramChietKhau.ToString())) / 100;
                                double giaTriVAT = ((tienHang - giaTriCK) * double.Parse(chitiethdbanhang[k].Thue)) / 100;
                                double TongTienHang = tienHang - giaTriCK + giaTriVAT;
                                Entities.BCDTTheoHangHoa temp = new Entities.BCDTTheoHangHoa(maHangHoa, tenHangHoa, maHoaDon, ngayBan, TongTienHang);
                                dtHangHoaList.Add(temp);
                            }

                        }

                    }
                }

                List<string> maHangHoaList = new List<string>();
                foreach (Entities.BCDTTheoHangHoa item in dtHangHoaList.ToArray())
                {
                    if (!maHangHoaList.Contains(item.MaHangHoa))
                    {
                        maHangHoaList.Add(item.MaHangHoa);
                    }
                }

                List<Entities.BCDTTheoHangHoa> hienThiList = new List<Entities.BCDTTheoHangHoa>();
                if (maHangHoaList != null)
                {
                    foreach (string maHangHoa in maHangHoaList.ToArray())
                    {

                        Entities.BCDTTheoHangHoa dtHH = new Entities.BCDTTheoHangHoa();
                        double tongTien = 0;
                        string maHang = string.Empty, tenHang = string.Empty;
                        foreach (Entities.BCDTTheoHangHoa item in dtHangHoaList.ToArray())
                        {
                            if (maHangHoa.Equals(item.MaHangHoa))
                            {
                                tongTien += item.ThanhToanNgay;
                                maHang = item.MaHangHoa;
                                tenHang = item.TenHangHoa;
                            }
                        }
                        dtHH.ThanhToanNgay = tongTien;
                        dtHH.MaHangHoa = maHang;
                        dtHH.TenHangHoa = tenHang;
                        hienThiList.Add(dtHH);
                    }
                }


                hienthibaocao = hienThiList.ToArray();
                //////////////////////////////////////////////Mrk FIX
                double tong0 = 0;
                for (int i = 0; i < hienThiList.ToArray().Length; i++)
                {
                    if (hienThiList[i] == null)
                    {
                        break;
                    }
                    tong0 += hienThiList[i].ThanhToanNgay;
                }
                Entities.BCDTTheoHangHoa tem1 = new Entities.BCDTTheoHangHoa();
                tem1.ThanhToanNgay = tong0;
                tem1.TenHangHoa = "Tổng Cộng: ";
                hienThiList.Add(tem1);
                //////////////////////////////////////////////////////
                //dtgvhienthi.DataSource = hienthi;
                dtgvhienthi.DataSource = hienThiList.ToArray();
                if (hienThiList.ToArray().Length > 0)
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = true;
                }
                else
                {
                    tsslexcel.Enabled = tsslPdf.Enabled = tsslWord.Enabled = tsslchitiet.Enabled = false;
                }
                fix();
            }
            catch
            {
            }
        }

        //private static List<string> GroupBy(List<Entities.BCDTTheoHangHoa> dtHangHoaList)
        //{
        //    List<string> maHangHoaList = new List<string>();
        //    string tem = string.Empty;
        //    foreach (Entities.BCDTTheoHangHoa item in dtHangHoaList)
        //    {
        //        if (item.MaHangHoa.Equals(tem))
        //        {
        //            continue;
        //        }
        //        else
        //        {
        //            tem = item.MaHangHoa;
        //            bool _b = false;
        //            foreach (string k in maHangHoaList)
        //            {
        //                if (k.Equals(tem))
        //                {
        //                    _b = true;
        //                }
        //            }
        //            if (!_b)
        //            {
        //                maHangHoaList.Add(tem);
        //            }
        //            else
        //            {
        //                continue;
        //            }
        //        }
        //    }
        //    return maHangHoaList;
        //}

        public void fix()
        {
            for (int j = 1; j < dtgvhienthi.ColumnCount; j++)
            {
                dtgvhienthi.Columns[j].Visible = false;
            }
            new Common.Utilities().CountDatagridview(dtgvhienthi);
            dtgvhienthi.ReadOnly = true;
            dtgvhienthi.RowHeadersVisible = false;
            dtgvhienthi.Columns["HanhDong"].Visible = true;
            dtgvhienthi.Columns["HanhDong"].HeaderText = "STT";
            dtgvhienthi.Columns["MaHangHoa"].Visible = true;
            dtgvhienthi.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
            dtgvhienthi.Columns["TenHangHoa"].Visible = true;
            dtgvhienthi.Columns["TenHangHoa"].HeaderText = "Tên Hàng Hóa";
            dtgvhienthi.Columns["thanhToanNgay"].Visible = true;
            dtgvhienthi.Columns["thanhToanNgay"].HeaderText = "Tổng Tiền";
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.AllowUserToAddRows = false;
            dtgvhienthi.AllowUserToDeleteRows = false;
            dtgvhienthi.AllowUserToResizeRows = false;
            this.Focus();
        }
        string batdau = "";
        string ketthuc = "";
        DateTime truoc;
        DateTime sau;
        private void btnhienthi_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    batdau = Convert.ToDateTime(cbbthang.Text + "/" + cbbngay.Text + "/" + cbbnam.Text).ToShortDateString();
                }
                catch
                {
                    MessageBox.Show("Không tồn tại ngày này trong tháng này", "Hệ thống cảnh báo");
                    return;
                }
                ketthuc = batdau;
                truoc = Convert.ToDateTime(batdau);
                sau = Convert.ToDateTime(ketthuc);
                TongTienHangHoa(truoc, sau);
            }
            catch
            {
            }

        }

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
            if (i < 0)
                return;
            try
            {
                int sl = 0;

                for (int j = 0; j < hienthibaocao.Length; j++)
                {
                    if (hienthibaocao[j].MaHangHoa == dtgvhienthi.Rows[i].Cells["MaHangHoa"].Value.ToString())
                    {
                        sl++;
                    }
                }

                Entities.BCDTTheoHangHoa[] a = new Entities.BCDTTheoHangHoa[sl];
                sl = 0;
                for (int j = 0; j < hienthibaocao.Length; j++)
                {
                    if (hienthibaocao[j].MaHangHoa == dtgvhienthi.Rows[i].Cells["MaHangHoa"].Value.ToString())
                    {
                        a[sl] = hienthibaocao[j];
                        sl++;
                    }
                }
                frmBaoCaorpt b = new frmBaoCaorpt(a, truoc, sau);
                b.ShowDialog();
            }
            catch
            {
            }
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                int sl = 0;

                for (int j = 0; j < hienthibaocao.Length; j++)
                {
                    string mahanghoa = dtgvhienthi.Rows[i].Cells["MaHangHoa"].Value.ToString();
                    if (hienthibaocao[j].MaHangHoa == dtgvhienthi.Rows[i].Cells["MaHangHoa"].Value.ToString())
                    {
                        sl++;
                    }
                }

                Entities.BCDTTheoHangHoa[] a = new Entities.BCDTTheoHangHoa[sl];
                sl = 0;
                for (int j = 0; j < hienthibaocao.Length; j++)
                {
                    if (hienthibaocao[j].MaHangHoa == dtgvhienthi.Rows[i].Cells["MaHangHoa"].Value.ToString())
                    {
                        a[sl] = hienthibaocao[j];
                        sl++;
                    }
                }
                frmBaoCaorpt b = new frmBaoCaorpt(hienthibaocao, truoc, sau);
                b.ShowDialog();
            }
            catch
            {
            }
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "PDF |*.pdf";
                saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                    int sl = 0;

                    for (int j = 0; j < hienthibaocao.Length; j++)
                    {
                        if (hienthibaocao[j].MaHangHoa == dtgvhienthi.Rows[i].Cells["MaHangHoa"].Value.ToString())
                        {
                            sl++;
                        }
                    }

                    Entities.BCDTTheoHangHoa[] a = new Entities.BCDTTheoHangHoa[sl];
                    sl = 0;
                    for (int j = 0; j < hienthibaocao.Length; j++)
                    {
                        if (hienthibaocao[j].MaHangHoa == dtgvhienthi.Rows[i].Cells["MaHangHoa"].Value.ToString())
                        {
                            a[sl] = hienthibaocao[j];
                            sl++;
                        }
                    }
                    frmBaoCaorpt b = new frmBaoCaorpt(a, truoc, sau, saveFileDialog1.FileName, "PDF");
                }
            }
            catch
            {
            }
        }

        private void tsslWord_Click(object sender, EventArgs e)
        {
            try
            {
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int sl = 0;

                    for (int j = 0; j < hienthibaocao.Length; j++)
                    {
                        if (hienthibaocao[j].MaHangHoa == dtgvhienthi.Rows[i].Cells["MaHangHoa"].Value.ToString())
                        {
                            sl++;
                        }
                    }

                    Entities.BCDTTheoHangHoa[] a = new Entities.BCDTTheoHangHoa[sl];
                    sl = 0;
                    for (int j = 0; j < hienthibaocao.Length; j++)
                    {
                        if (hienthibaocao[j].MaHangHoa == dtgvhienthi.Rows[i].Cells["MaHangHoa"].Value.ToString())
                        {
                            a[sl] = hienthibaocao[j];
                            sl++;
                        }
                    }
                    frmBaoCaorpt b = new frmBaoCaorpt(a, truoc, sau, saveFileDialog1.FileName, "Word");
                }
            }
            catch
            {
            }
        }

        private void tsslexcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int sl = 0;

                    for (int j = 0; j < hienthibaocao.Length; j++)
                    {
                        if (hienthibaocao[j].MaHangHoa == dtgvhienthi.Rows[i].Cells["MaHangHoa"].Value.ToString())
                        {
                            sl++;
                        }
                    }

                    Entities.BCDTTheoHangHoa[] a = new Entities.BCDTTheoHangHoa[sl];
                    sl = 0;
                    for (int j = 0; j < hienthibaocao.Length; j++)
                    {
                        if (hienthibaocao[j].MaHangHoa == dtgvhienthi.Rows[i].Cells["MaHangHoa"].Value.ToString())
                        {
                            a[sl] = hienthibaocao[j];
                            sl++;
                        }
                    }
                    frmBaoCaorpt b = new frmBaoCaorpt(a, truoc, sau, saveFileDialog1.FileName, "Excel");
                }
            }
            catch
            {
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                SelectAll();
                batdau = Convert.ToDateTime(cbbthang.Text + "/" + cbbngay.Text + "/" + cbbnam.Text).ToShortDateString();
                ketthuc = batdau;
                truoc = Convert.ToDateTime(batdau);
                sau = Convert.ToDateTime(ketthuc);
                TongTienHangHoa(truoc, sau);
                fix(); this.Focus();
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
                    dtgvhienthi.DataSource = new Entities.BCDTTheoHangHoa[0];
                    return;
                }
                int soluong = 0;
                if (hienthibaocao != null)
                {
                    if (rdbtimkiem1.Checked == true)
                    {
                        for (int i = 0; i < hienthibaocao.Length; i++)
                        {
                            int kiemtra = hienthibaocao[i].MaHangHoa.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCDTTheoHangHoa[0];
                            return;
                        }
                        Entities.BCDTTheoHangHoa[] hienthitheoid = new Entities.BCDTTheoHangHoa[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthibaocao.Length; i++)
                        {
                            int kiemtra = hienthibaocao[i].MaHangHoa.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid[soluong] = hienthibaocao[i];
                                soluong++;
                            }
                        }
                        dtgvhienthi.DataSource = hienthitheoid;
                    }
                    if (rdbtimkiem2.Checked == true)
                    {
                        for (int i = 0; i < hienthibaocao.Length; i++)
                        {
                            int kiemtra = hienthibaocao[i].TenHangHoa.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCDTTheoHangHoa[0];
                            return;
                        }
                        Entities.BCDTTheoHangHoa[] hienthitheoma = new Entities.BCDTTheoHangHoa[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthibaocao.Length; i++)
                        {
                            int kiemtra = hienthibaocao[i].TenHangHoa.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoma[soluong] = hienthibaocao[i];
                                soluong++;
                            }
                        }
                        dtgvhienthi.DataSource = hienthitheoma;

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
                if (hienthibaocao == null)
                {
                    dtgvhienthi.DataSource = new Entities.BCDTTheoHangHoa[0];
                    return;
                }
                dtgvhienthi.DataSource = hienthibaocao;
                if (dtgvhienthi.RowCount > 0)
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
