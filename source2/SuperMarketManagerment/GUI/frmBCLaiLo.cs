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
    public partial class frmBCLaiLo : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        DateTime datesv;
        int nam = 0;
        int thang = 0;
        Entities.GiaVonBanHang[] giaVon;

        public frmBCLaiLo()
        {
            try
            {
                InitializeComponent();
                datesv = DateServer.Date();
                nam = datesv.Year;
                thang = datesv.Month;
                cbbthang.Text = thang.ToString();
                cbbnam.Text = nam.ToString();
                giaVon = GiaVon();
                HDBanHang();
                ChiTietHDBanHang();
                HangHoa();
                GoiHang();
                TongTienNhanVien();
            }
            catch
            {
            }

        }

        Entities.HDBanHang[] hdbanhang;
        public void HDBanHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("HDBH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                hdbanhang = (Entities.HDBanHang[])cl.DeserializeHepper1(clientstrem, hdbanhang);
                if (hdbanhang == null)
                {
                    hdbanhang = new Entities.HDBanHang[0];
                    return;
                }
                int st = 0;
                Entities.HDBanHang[] temp = new Entities.HDBanHang[hdbanhang.Length];
                for (int i = 0; i < hdbanhang.Length; i++)
                {
                    temp[st] = hdbanhang[i];
                    st++;
                }
                hdbanhang = new Entities.HDBanHang[st];
                for (int i = 0; i < st; i++)
                {
                    hdbanhang[i] = temp[i];
                }

            }

            catch
            {
            }
        }
        Entities.ChiTietHDBanHang[] chitiethdbanhang;
        public void ChiTietHDBanHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("CTHDBH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                chitiethdbanhang = (Entities.ChiTietHDBanHang[])cl.DeserializeHepper1(clientstrem, chitiethdbanhang);
                if (chitiethdbanhang == null)
                {
                    chitiethdbanhang = new Entities.ChiTietHDBanHang[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.HangHoa[] hanghoa;
        public void HangHoa()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("HH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                hanghoa = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, hanghoa);
                if (hanghoa == null)
                {
                    hanghoa = new Entities.HangHoa[0];
                    return;
                }
            }
            catch
            {
            }
        }

        Entities.GoiHang[] goihang;
        public void GoiHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("GH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                goihang = (Entities.GoiHang[])cl.DeserializeHepper1(clientstrem, goihang);
                if (hanghoa == null)
                {
                    goihang = new Entities.GoiHang[0];
                    return;
                }
            }
            catch
            {
            }
        }


        public Entities.GiaVonBanHang[] GiaVon(string maHoaDon, string maHangHoa)
        {
            Entities.GiaVonBanHang[] giaVon = null;
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.GiaVonBanHang gv = new Entities.GiaVonBanHang();
                gv.HanhDong = "SelectBy";
                gv.MaHoaDon = maHoaDon;
                gv.MaHangHoa = maHangHoa;
                clientstrem = cl.SerializeObj(this.client1, "GiaVonBanHang", gv);
                ////// đổ mảng đối tượng vào datagripview     

                giaVon = (Entities.GiaVonBanHang[])cl.DeserializeHepper1(clientstrem, giaVon);
                if (giaVon == null)
                {
                    giaVon = new Entities.GiaVonBanHang[0];
                }
            }
            catch
            {
            }

            return giaVon;
        }

        public Entities.GiaVonBanHang[] GiaVon()
        {
            Entities.GiaVonBanHang[] giaVon = null;
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.GiaVonBanHang gv = new Entities.GiaVonBanHang();
                gv.HanhDong = "SelectAll";
                gv.MaHoaDon = string.Empty;
                gv.MaHangHoa = string.Empty;
                clientstrem = cl.SerializeObj(this.client1, "GiaVonBanHang", gv);
                ////// đổ mảng đối tượng vào datagripview     

                giaVon = (Entities.GiaVonBanHang[])cl.DeserializeHepper1(clientstrem, giaVon);
                if (giaVon == null)
                {
                    giaVon = new Entities.GiaVonBanHang[0];
                }
            }
            catch
            {
            }

            return giaVon;
        }

        /// <summary>
        /// Lay gia von cu goi hang = sl * ginhap.
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="gh"></param>
        /// <returns></returns>
        public double LayGiaVonGoiHang(Entities.ChiTietHDBanHang ct, Entities.GoiHang[] gh)
        {
            double retVal = 0;
            try
            {

                foreach (Entities.GoiHang item in gh)
                {
                    if (ct.MaHangHoa.Equals(item.MaGoiHang))
                    {
                        retVal = ct.SoLuong * double.Parse(item.GiaNhap);
                        break;
                    }
                }

            }
            catch
            {
                retVal = 0;
            }
            return retVal;
        }

        /// <summary>
        /// Lay gia von cua hang hoa = sl * giaNhap.
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="hh"></param>
        /// <returns></returns>
        public double LayGiaVonHangHoa(Entities.ChiTietHDBanHang ct)
        {
            double retVal = 0;
            try
            {
                var query = from gv in giaVon
                            where gv.MaHoaDon.Equals(ct.MaHDBanHang) &&
                            gv.MaHangHoa.Equals(ct.MaHangHoa)
                            select gv;

                Entities.GiaVonBanHang[] gvArr = query.ToArray();
                if (gvArr != null && gvArr.Length > 0)
                    retVal = ct.SoLuong * double.Parse(gvArr[0].GiaVon.ToString());
            }
            catch
            {
                retVal = 0;
            }

            return retVal;
        }

        Entities.BCLaiLoChiTiet[] hienthi;
        List<Entities.BCLaiLo> hienthibaocao = new List<Entities.BCLaiLo>();
        List<Entities.HDBanHang> hdBanHanList;

        public void TongTienNhanVien()
        {
            try
            {
                List<Entities.BCLaiLoChiTiet> ctLaiLoList = new List<Entities.BCLaiLoChiTiet>();
                nam = int.Parse(cbbnam.Text);
                thang = int.Parse(cbbthang.Text);
                for (int i = 0; i < hdbanhang.Length; i++)
                {
                    int namht = hdbanhang[i].NgayBan.Year;
                    int thanght = hdbanhang[i].NgayBan.Month;
                    Entities.BCLaiLoChiTiet laiLoChiTiet = new Entities.BCLaiLoChiTiet();
                    if (nam == namht && thanght == thang)
                    {
                        laiLoChiTiet.DoanhSo = (double.Parse(hdbanhang[i].TongTienThanhToan) - double.Parse(hdbanhang[i].ThueGTGT)).ToString();
                        laiLoChiTiet.Ngay = hdbanhang[i].NgayBan.ToShortDateString();
                        double giaVon = 0;
                        for (int j = 0; j < chitiethdbanhang.Length; j++)
                        {
                            if (hdbanhang[i].MaHDBanHang.Equals(chitiethdbanhang[j].MaHDBanHang))
                            {
                                if (LayGiaVonHangHoa(chitiethdbanhang[j]) == 0)
                                {
                                    if (LayGiaVonGoiHang(chitiethdbanhang[j], goihang) == 0)
                                    {
                                        giaVon = 0;
                                    }
                                    else
                                    {
                                        giaVon += LayGiaVonGoiHang(chitiethdbanhang[j], goihang);
                                    }

                                }
                                else
                                {
                                    giaVon += LayGiaVonHangHoa(chitiethdbanhang[j]);
                                }
                            }
                        }

                        laiLoChiTiet.GiaVon = giaVon.ToString();
                        laiLoChiTiet.LaiGop = (double.Parse(laiLoChiTiet.DoanhSo) - double.Parse(laiLoChiTiet.GiaVon)).ToString();
                        ctLaiLoList.Add(laiLoChiTiet);
                    }

                }

                List<string> Ltem = new List<string>();
                foreach (Entities.BCLaiLoChiTiet item in ctLaiLoList)
                {
                    if (!Ltem.Contains(DateTime.Parse(item.Ngay).ToShortDateString()))
                    {
                        Ltem.Add(DateTime.Parse(item.Ngay).ToShortDateString());
                    }
                }
                List<Entities.BCLaiLoChiTiet> Fixhienthi = new List<Entities.BCLaiLoChiTiet>();
                int ii = 0;
                foreach (string item1 in Ltem)
                {
                    Entities.BCLaiLoChiTiet bientam = new Entities.BCLaiLoChiTiet();
                    bientam.HanhDong = ii.ToString();
                    ii++;
                    double doanhso = 0; double giavon = 0; double laigop = 0;
                    foreach (Entities.BCLaiLoChiTiet item2 in ctLaiLoList)
                    {
                        if (item2.Ngay.Equals(item1))
                        {
                            bientam.Ngay = item2.Ngay;
                            doanhso += double.Parse(item2.DoanhSo);
                            giavon += double.Parse(item2.GiaVon);
                            laigop += double.Parse(item2.LaiGop);
                        }
                    }
                    bientam.DoanhSo = new Common.Utilities().FormatMoney(doanhso);
                    bientam.GiaVon = new Common.Utilities().FormatMoney(giavon);
                    bientam.LaiGop = new Common.Utilities().FormatMoney(laigop);
                    Fixhienthi.Add(bientam);
                }

                /// Lay Datasour cho BC.
                foreach (Entities.BCLaiLoChiTiet item in (Entities.BCLaiLoChiTiet[])Fixhienthi.ToArray())
                {
                    try
                    {
                        DateTime ngay = DateTime.Parse(DateTime.Parse(item.Ngay).ToShortDateString());
                        double doanhSo = double.Parse(item.DoanhSo);
                        double giaVon = double.Parse(item.GiaVon);
                        double laiGop = double.Parse(item.LaiGop);
                        Entities.BCLaiLo laiLo = new Entities.BCLaiLo(ngay, doanhSo, giaVon, laiGop);
                        hienthibaocao.Add(laiLo);
                    }
                    catch (Exception)
                    { }
                }

                Entities.BCLaiLoChiTiet tongCong = new Entities.BCLaiLoChiTiet();
                double tongDoanhSo = 0;
                double tongGiaVon = 0;
                double tongLaiGop = 0;
                foreach (Entities.BCLaiLoChiTiet item in (Entities.BCLaiLoChiTiet[])Fixhienthi.ToArray())
                {
                    tongDoanhSo += double.Parse(item.DoanhSo);
                    tongGiaVon += double.Parse(item.GiaVon);
                    tongLaiGop += double.Parse(item.LaiGop);
                }
                tongCong.DoanhSo = new Common.Utilities().FormatMoney(tongDoanhSo);
                tongCong.GiaVon = new Common.Utilities().FormatMoney(tongGiaVon);
                tongCong.LaiGop = new Common.Utilities().FormatMoney(tongLaiGop);
                tongCong.Ngay = "Tổng Cộng:";
                Fixhienthi.Add(tongCong);

                dtgvhienthi.DataSource = (Entities.BCLaiLoChiTiet[])Fixhienthi.ToArray();
                if (Fixhienthi.ToArray().Length > 0)
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
            return String.Format("{0:0,0}", a);
        }

        public void fix()
        {
            new Common.Utilities().CountDatagridview(dtgvhienthi);
            dtgvhienthi.ReadOnly = true;
            dtgvhienthi.RowHeadersVisible = false;
            dtgvhienthi.Columns["HanhDong"].HeaderText = "STT";
            dtgvhienthi.Columns["Ngay"].HeaderText = "Ngày Bán";
            dtgvhienthi.Columns["DoanhSo"].HeaderText = "Doanh Số";
            dtgvhienthi.Columns["GiaVon"].HeaderText = "Giá Vốn";
            dtgvhienthi.Columns["LaiGop"].HeaderText = "Lãi Gộp";
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
            if (i < 0)
                return;
            try
            {
                string b = "";
                string c = "01/" + cbbthang.Text + "/" + cbbnam.Text;
                if (cbbthang.Text == "12")
                    b = "01/01/" + (int.Parse(cbbnam.Text) + 1).ToString();
                else
                    b = "01/" + (int.Parse(cbbthang.Text) + 1).ToString() + "/" + cbbnam.Text;
                frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao.ToArray(), c, b, "");
                a.ShowDialog();
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
                string b = "";
                string c = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), 1).ToString();
                b = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), DateTime.DaysInMonth(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text))).ToString();
                //string c = "01/" + cbbthang.Text + "/" + cbbnam.Text;
                //if (cbbthang.Text == "12")
                //    b = "01/01/" + (int.Parse(cbbnam.Text) + 1).ToString();
                //else
                //    b = "01/" + (int.Parse(cbbthang.Text) + 1).ToString() + "/" + cbbnam.Text;
                frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao.ToArray(), c, b, "");
                a.ShowDialog();
            }
            catch
            {
            }
        }

        private void btnhienthi_Click(object sender, EventArgs e)
        {
            try
            {
                nam = int.Parse(cbbnam.Text);
                thang = int.Parse(cbbthang.Text);
                TongTienNhanVien();
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
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string b = "";
                    string c = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), 1).ToString();
                    b = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), DateTime.DaysInMonth(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text))).ToString();
                    //string c = "01/" + cbbthang.Text + "/" + cbbnam.Text;
                    //if (cbbthang.Text == "12")
                    //    b = "01/01/" + (int.Parse(cbbnam.Text) + 1).ToString();
                    //else
                    //    b = "01/" + (int.Parse(cbbthang.Text) + 1).ToString() + "/" + cbbnam.Text;
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao.ToArray(), c, b, saveFileDialog1.FileName, "PDF");
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
                    string b = "";
                    string c = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), 1).ToString();
                    b = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), DateTime.DaysInMonth(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text))).ToString();
                    //string c = "01/" + cbbthang.Text + "/" + cbbnam.Text;
                    //if (cbbthang.Text == "12")
                    //    b = "01/01/" + (int.Parse(cbbnam.Text) + 1).ToString();
                    //else
                    //    b = "01/" + (int.Parse(cbbthang.Text) + 1).ToString() + "/" + cbbnam.Text;
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao.ToArray(), c, b, saveFileDialog1.FileName, "Word");
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
                    string b = "";
                    string c = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), 1).ToString();
                    b = new DateTime(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text), DateTime.DaysInMonth(Convert.ToInt32(cbbnam.Text), Convert.ToInt32(cbbthang.Text))).ToString();
                    //string c = "01/" + cbbthang.Text + "/" + cbbnam.Text;
                    //if (cbbthang.Text == "12")
                    //    b = "01/01/" + (int.Parse(cbbnam.Text) + 1).ToString();
                    //else
                    //    b = "01/" + (int.Parse(cbbthang.Text) + 1).ToString() + "/" + cbbnam.Text;
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao.ToArray(), c, b, saveFileDialog1.FileName, "Excel");
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
                HDBanHang();
                ChiTietHDBanHang();
                HangHoa();
                TongTienNhanVien(); this.Focus();
            }
            catch
            {
            }
            this.Enabled = true;
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

        private void cbbthang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbnam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
