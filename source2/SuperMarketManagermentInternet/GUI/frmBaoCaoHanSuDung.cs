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

namespace GUI
{
    public partial class frmBaoCaoHanSuDung : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        DateTime datesv = new DateTime(1753, 1, 1);
        DateTime now = DateServer.Date();
        string batdau = string.Empty;
        string ketthuc = string.Empty;
        DateTime truoc = new DateTime(1753, 1, 1);
        DateTime sau = new DateTime(1753, 1, 1);
        Entities.ChiTietKhoHang[] ctkhArr = new Entities.ChiTietKhoHang[1];
        public frmBaoCaoHanSuDung()
        {
            InitializeComponent();
            DefaultLoad();
        }

        /// <summary>
        /// ham load mac dinh.
        /// </summary>
        public void DefaultLoad()
        {
            int thang = now.Month;
            int nam = now.Year;
            int soNgayTrongThang = DateTime.DaysInMonth(nam, thang);
            truoc = new DateTime(nam, thang, 1);
            sau = new DateTime(nam, thang, soNgayTrongThang);
            lbtenbaocao.Text = "Báo Cáo Hàng Hết Hạn Từ Ngày " + truoc.ToString("dd/MM/yyyy") + " Đến Ngày " + sau.ToString("dd/MM/yyyy");
            ctkhArr = GetData(truoc, sau, now);
            BinData(ctkhArr);
        }
        /// <summary>
        /// Lay tat ca hang hoa trong chi tiet kho hang thoa man batDau<= HanSuDung <=KetThuc.
        /// </summary>
        /// <param name="batDau"></param>
        /// <param name="ketThuc"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public Entities.ChiTietKhoHang[] GetData(DateTime batDau, DateTime ketThuc, DateTime now)
        {
            List<Entities.ChiTietKhoHang> ctkhList = new List<Entities.ChiTietKhoHang>();
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.ChiTietKhoHang ct = new Entities.ChiTietKhoHang();
                clientstrem = cl.SerializeObj(this.client1, "ChiTietKhoAll", ct);
                Entities.ChiTietKhoHang[] ctArr = new Entities.ChiTietKhoHang[1];
                ctArr = (Entities.ChiTietKhoHang[])cl.DeserializeHepper(clientstrem, ctArr);
                if (ctArr != null && ctArr.Count() > 0)
                {
                    foreach (Entities.ChiTietKhoHang item in ctArr)
                    {
                        if (batDau <= item.HanSuDung && item.HanSuDung <= ketThuc && item.HanSuDung > now && item.SoLuong > 0)
                        {
                            ctkhList.Add(item);
                        }
                    }
                }

            }
            catch (Exception)
            {
            }
            return ctkhList.ToArray();
        }
        /// <summary>
        /// Do data vao DataGridview.
        /// </summary>
        /// <param name="ctkh"></param>
        public void BinData(Entities.ChiTietKhoHang[] ctkh)
        {
            try
            {
                this.dtgvHienThi.DataSource = ctkh;
                dtgvHienThi.Columns[0].Visible = false;
                dtgvHienThi.Columns["MaKho"].Visible = true;
                dtgvHienThi.Columns["MaKho"].HeaderText = "Mã Kho";
                dtgvHienThi.Columns["MaHangHoa"].HeaderText = "Mã hàng";
                dtgvHienThi.Columns["TenHangHoa"].HeaderText = "Tên hàng";
                dtgvHienThi.Columns["SoLuong"].HeaderText = "Số lượng";
                dtgvHienThi.Columns["HanSuDung"].HeaderText = "Hạn sử dụng";
                dtgvHienThi.Columns["GhiChu"].HeaderText = "Ghi chú";
                dtgvHienThi.Columns["NgayNhap"].Visible = false;
                dtgvHienThi.RowHeadersVisible = false;
                dtgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvHienThi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dtgvHienThi.ReadOnly = true;
                if (ctkh != null && ctkhArr.Count() > 0)
                    ShowButton();
            }
            catch (Exception)
            { }
        }
        /// <summary>
        /// Tim kiem hang hoa trong DataGridView.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="searchVal"></param>
        /// <param name="arr"></param>
        public void Search(string type, string searchVal, Entities.ChiTietKhoHang[] arr)
        {
            List<Entities.ChiTietKhoHang> ctList = new List<Entities.ChiTietKhoHang>();
            try
            {
                if (arr == null || arr.Count() <= 0)
                {
                    return;
                }

                switch (type)
                {
                    case "MaHang":
                        for (int i = 0; i < arr.Length; i++)
                        {
                            int kiemtra = arr[i].MaHangHoa.ToString().ToUpper().IndexOf(searchVal.ToUpper());
                            if (kiemtra >= 0)
                            {
                                ctList.Add(arr[i]);
                            }
                        }
                        BinData(ctList.ToArray());
                        break;
                    case "TenHang":
                        for (int i = 0; i < arr.Length; i++)
                        {
                            int kiemtra = arr[i].TenHangHoa.ToString().ToUpper().IndexOf(searchVal.ToUpper());
                            if (kiemtra >= 0)
                            {
                                ctList.Add(arr[i]);
                            }
                        }
                        BinData(ctList.ToArray());
                        break;
                    case "HanSuDung":
                        for (int i = 0; i < arr.Length; i++)
                        {
                            int kiemtra = arr[i].HanSuDung.ToShortDateString().ToUpper().IndexOf(searchVal.ToUpper());
                            if (kiemtra >= 0)
                            {
                                ctList.Add(arr[i]);
                            }
                        }
                        BinData(ctList.ToArray());
                        break;
                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Show Button Xem, Word, PDF, Ex...
        /// </summary>
        public void ShowButton()
        {
            this.btnXem.Enabled = true;
            this.btnWord.Enabled = true;
            this.btnExcel.Enabled = true;
            this.btnPDF.Enabled = true;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (rdbMaHang.Checked)
                Search("MaHang", txtTimKiem.Text, ctkhArr);
            if (rdbTenHang.Checked)
                Search("TenHang", txtTimKiem.Text, ctkhArr);
            if (rdbHanSudung.Checked)
                Search("HanSuDung", txtTimKiem.Text, ctkhArr);
        }

        private void btnNapLai_Click(object sender, EventArgs e)
        {
            DefaultLoad();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                frmBaoCaorpt a = new frmBaoCaorpt(ctkhArr, truoc, sau, "In", "");
                a.ShowDialog();
            }
            catch
            {
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                saveFileDialog1.Filter = "Excel |*.xls"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(ctkhArr, truoc, sau, "Excel", saveFileDialog1.FileName);
                }
            }
            catch
            {
            }
            finally { this.Enabled = true; }
        }

        private void btnWord_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                saveFileDialog1.Filter = "Word |*.doc"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(ctkhArr, truoc, sau, "Word", saveFileDialog1.FileName);
                }
            }
            catch
            {
            }
            finally { this.Enabled = true; }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frmBaoCaorpt a = new frmBaoCaorpt(ctkhArr, truoc, sau, "PDF", saveFileDialog1.FileName);
                }
            }
            catch
            {
            }
            finally { this.Enabled = true; }
        }

        private void btnLocDieuKien_Click(object sender, EventArgs e)
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
                    lbtenbaocao.Text = "Báo Cáo Hàng Hết Hạn Từ Ngày " + truoc.ToString("dd/MM/yyyy") + " Đến Ngày " + sau.ToString("dd/MM/yyyy");
                    ctkhArr = GetData(truoc, sau, now);
                    BinData(ctkhArr);
                    frmLocDieuKien.truoc = frmLocDieuKien.sau = "";
                }
            }
            catch
            {
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void btnNapLai_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void btnNapLai_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void btnXem_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void btnXem_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void btnExcel_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void btnExcel_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void btnWord_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void btnWord_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void btnPDF_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void btnPDF_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void btnLocDieuKien_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void btnLocDieuKien_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }

        private void btnThoat_MouseLeave(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.LightSteelBlue;
        }

        private void btnThoat_MouseMove(object sender, MouseEventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel)sender;
            tsl.BackColor = System.Drawing.Color.Snow;
        }
    }
}
