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
    public partial class frmBCDoanhThuNhomHang : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.GoiHang[] goihang;
        Entities.ChiTietGoiHang[] chitietgoihang;
        DateTime datesv;
        public frmBCDoanhThuNhomHang()
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
                TongTienNhomHang(truoc, sau);
                fix();
            }
            catch
            {
            }
        }
        Entities.SelectAll selectall;
        void SelectAll()
        {
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("BCDoanhThuNhomHang", new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen);
            clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
            selectall = (Entities.SelectAll)cl.DeserializeHepper(clientstrem, selectall);
            goihang = selectall.GoiHang;
            chitietgoihang = selectall.ChiTietGoiHang;
            hdbanhang = selectall.HDBanHang;
            chitiethdbanhang = selectall.ChiTietHDBanHang;
            nv = selectall.HangHoaTheoKho;
            nh = selectall.NhomHang;
            thue = selectall.Thue;
        }
        Entities.BCDTTheoHangHoa[] bcnv;
        Entities.HDBanHang[] hdbanhang;
        Entities.ChiTietHDBanHang[] chitiethdbanhang;
        Entities.HangHoa[] nv;
        Entities.NhomHang[] nh;
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
        Entities.BCDTTheoNhomHang[] hienthi;
        List<Entities.BCDTTheoNhomHang> hienthibaocao = new List<Entities.BCDTTheoNhomHang>();
        
        public void TongTienNhomHang(DateTime batdau, DateTime ketthuc)
        {
            try
            {
                List<Entities.BCDTTheoNhomHang> dtNhomHang = new List<Entities.BCDTTheoNhomHang>();
                // lay tat ca hang hoa trong hoa don.
                for (int i = 0; i < hdbanhang.Length; i++)
                {
                    DateTime hientai = hdbanhang[i].NgayBan;
                    if (hientai.Date >= batdau.Date && hientai.Date <= ketthuc.Date)
                    {
                        for (int j = 0; j < chitiethdbanhang.Length; j++)
                        {
                            if (chitiethdbanhang[j].MaHDBanHang.Equals(hdbanhang[i].MaHDBanHang))
                            {
                                string tenHangHoa = chitiethdbanhang[j].TenHangHoa;
                                string maHangHoa = chitiethdbanhang[j].MaHangHoa;
                                string maHoaDonBanHang = hdbanhang[i].MaHDBanHang;
                                DateTime ngayBan = hdbanhang[i].NgayBan;
                                double tienHang = chitiethdbanhang[j].SoLuong * double.Parse(chitiethdbanhang[j].DonGia);
                                double giaTriCK = (tienHang * chitiethdbanhang[j].PhanTramChietKhau) / 100;
                                double giaTriVAT = ((tienHang - giaTriCK) * double.Parse(chitiethdbanhang[j].Thue)) / 100;
                                double thanhTien = tienHang - giaTriCK + giaTriVAT;
                                Entities.BCDTTheoNhomHang dtnh = new Entities.BCDTTheoNhomHang();
                                dtnh.MaHDBanHang = maHoaDonBanHang;
                                dtnh.NgayBan = ngayBan;
                                dtnh.MaHangHoa = maHangHoa;
                                dtnh.TenHangHoa = tenHangHoa;
                                dtnh.ThanhToanNgay = thanhTien;
                                dtNhomHang.Add(dtnh);
                            }
                        }
                    }
                }

                // gan tat ca hang hoa cho nhom cua no khi la hang hoa. 
                List<Entities.BCDTTheoNhomHang> dtTemp = new List<Entities.BCDTTheoNhomHang>();
                foreach (Entities.BCDTTheoNhomHang item in dtNhomHang.ToArray())
                {
                    foreach (Entities.HangHoa hh in nv)
                    {
                        if (hh.MaHangHoa.Equals(item.MaHangHoa))
                        {
                            foreach (Entities.NhomHang nhTep in nh)
                            {
                                if (hh.MaNhomHangHoa.Equals(nhTep.MaNhomHang))
                                {
                                    item.MaNhomHang = nhTep.MaNhomHang;
                                    item.TenNhomHang = nhTep.TenNhomHang;
                                    break;
                                }
                            }

                            dtTemp.Add(item);
                            break;
                        }
                    }
                }

                // gan tat ca hang hoa cho nhom cua no khi la goi hang. 
                foreach (Entities.BCDTTheoNhomHang item in dtNhomHang.ToArray())
                {
                    foreach (Entities.GoiHang gh in goihang)
                    {
                        if (gh.MaGoiHang.Equals(item.MaHangHoa))
                        {
                            foreach (Entities.NhomHang nhTep in nh)
                            {
                                if (gh.MaNhomHang.Equals(nhTep.MaNhomHang))
                                {
                                    item.MaNhomHang = nhTep.MaNhomHang;
                                    item.TenNhomHang = nhTep.TenNhomHang;
                                    break;
                                }
                            }

                            dtTemp.Add(item);
                            break;
                        }
                    }
                }

                // lay nhom Group trong List Hang hoa.
                List<string> groupList = new List<string>();
                foreach (Entities.BCDTTheoNhomHang item in dtTemp.ToArray())
                {
                    if (!groupList.Contains(item.MaNhomHang))
                    {
                        groupList.Add(item.MaNhomHang);
                    }
                }

                // tinh doanh thu theo tung nhom 
                List<Entities.BCDTTheoNhomHang> dtHienThiList = new List<Entities.BCDTTheoNhomHang>();
                foreach (string group in groupList.ToArray())
                {
                    double thanhToanNgay = 0;
                    string tenNhom = string.Empty;
                    string maNhom = string.Empty;
                    foreach (Entities.BCDTTheoNhomHang item in dtTemp.ToArray())
                    {
                        if (group.Equals(item.MaNhomHang))
                        {
                            thanhToanNgay += item.ThanhToanNgay;
                            maNhom = item.MaNhomHang;
                            tenNhom = item.TenNhomHang;
                        }
                    }
                    Entities.BCDTTheoNhomHang temp = new Entities.BCDTTheoNhomHang();
                    temp.ThanhToanNgay = thanhToanNgay;
                    temp.MaNhomHang = maNhom;
                    temp.TenNhomHang = tenNhom;
                    dtHienThiList.Add(temp);
                }

                hienthibaocao = dtHienThiList;

                //////////////////////////////////////////////Mrk FIX
                List<Entities.BCDTTheoNhomHang> tem0 = new List<Entities.BCDTTheoNhomHang>();
                double tong0 = 0;
                for (int i = 0; i < dtHienThiList.ToArray().Length; i++)
                {
                    if (dtHienThiList[i] == null)
                    {
                        break;
                    }
                    tong0 += dtHienThiList[i].ThanhToanNgay;
                    tem0.Add(dtHienThiList[i]);
                }
                Entities.BCDTTheoNhomHang tem1 = new Entities.BCDTTheoNhomHang();
                tem1.ThanhToanNgay = tong0;
                tem1.TenNhomHang = "Tổng Cộng: ";
                tem0.Add(tem1);

                //////////////////////////////////////////////////////
                dtgvhienthi.DataSource = tem0.ToArray();

                if (tem0.ToArray().Length > 0)
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
            dtgvhienthi.Columns["MaNhomHang"].Visible = true;
            dtgvhienthi.Columns["MaNhomHang"].HeaderText = "Mã Nhóm Hàng";
            dtgvhienthi.Columns["TenNhomHang"].Visible = true;
            dtgvhienthi.Columns["TenNhomHang"].HeaderText = "Tên Nhóm Hàng";
            dtgvhienthi.Columns["ThanhToanNgay"].Visible = true;
            dtgvhienthi.Columns["ThanhToanNgay"].HeaderText = "Tổng Tiền";
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
                TongTienNhomHang(truoc, sau);
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
            this.Enabled = false;
            if (i < 0)
                return;
            try
            {
                int sl = 0;

                for (int j = 0; j < hienthibaocao.ToArray().Length; j++)
                {
                    if (hienthibaocao[j].MaNhomHang == dtgvhienthi.Rows[i].Cells["MaNhomHang"].Value.ToString())
                    {
                        sl++;
                    }
                }

                Entities.BCDTTheoNhomHang[] a = new Entities.BCDTTheoNhomHang[sl];
                sl = 0;
                for (int j = 0; j < hienthibaocao.ToArray().Length; j++)
                {
                    if (hienthibaocao[j].MaNhomHang == dtgvhienthi.Rows[i].Cells["MaNhomHang"].Value.ToString())
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
            finally
            {
                this.Enabled = true;
            }
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            if (i < 0)
                return;
            try
            {
               frmBaoCaorpt b = new frmBaoCaorpt(hienthibaocao.ToArray(), truoc, sau);
                b.ShowDialog();
            }
            catch
            {
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (i < 0)
                        return;
                    frmBaoCaorpt b = new frmBaoCaorpt(hienthibaocao.ToArray(), truoc, sau, saveFileDialog1.FileName, "PDF");
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
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt b = new frmBaoCaorpt(hienthibaocao.ToArray(), truoc, sau, saveFileDialog1.FileName, "Word");
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
                if (i < 0)
                    return;
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt b = new frmBaoCaorpt(hienthibaocao.ToArray(), truoc, sau, saveFileDialog1.FileName, "Excel");
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
                SelectAll();
                batdau = Convert.ToDateTime(cbbthang.Text + "/" + cbbngay.Text + "/" + cbbnam.Text).ToShortDateString();
                ketthuc = batdau;
                truoc = Convert.ToDateTime(batdau);
                sau = Convert.ToDateTime(ketthuc);
                TongTienNhomHang(truoc, sau);
                fix(); this.Focus();
            }
            catch
            {
            }
            this.Enabled = true;
        }

        private void frmBCDoanhThuNhomHang_Load(object sender, EventArgs e)
        {

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
                    dtgvhienthi.DataSource = new Entities.BCDTTheoNhomHang[0];
                    return;
                }
                int soluong = 0;
                if (hienthibaocao != null)
                {
                    if (rdbtimkiem1.Checked == true)
                    {
                        for (int i = 0; i < hienthibaocao.ToArray().Length; i++)
                        {
                            int kiemtra = hienthibaocao[i].MaNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCDTTheoNhomHang[0];
                            return;
                        }
                        Entities.BCDTTheoNhomHang[] hienthitheoid = new Entities.BCDTTheoNhomHang[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthibaocao.ToArray().Length; i++)
                        {
                            int kiemtra = hienthibaocao[i].MaNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
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
                        for (int i = 0; i < hienthibaocao.ToArray().Length; i++)
                        {
                            int kiemtra = hienthibaocao[i].TenNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCDTTheoNhomHang[0];
                            return;
                        }
                        Entities.BCDTTheoNhomHang[] hienthitheoma = new Entities.BCDTTheoNhomHang[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthibaocao.ToArray().Length; i++)
                        {
                            int kiemtra = hienthibaocao[i].TenNhomHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
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
                    dtgvhienthi.DataSource = new Entities.BCDTTheoNhomHang[0];
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
