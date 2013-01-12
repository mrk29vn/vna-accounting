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
    public partial class frmBCKhachHangTraHang : Form
    {
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.SelectAll selectall;
        Entities.KhachHangTraLai[] khachhangtralai;
        Entities.ChiTietKhachHangTraLai[] chitietkhachhangtralai;
        Entities.HDBanHang[] hdbanhang;
        Entities.Thue[] thue;
        Entities.HangHoa[] hanghoa;
        Entities.BCKhachHangTraHang[] hienthi;
        Entities.BCKhachHangTraHang[] hienthibaocao;
        DateTime datesv;
        string makho = "";
        string batdau, ketthuc;
        public frmBCKhachHangTraHang()
        {
            InitializeComponent();

            SelectData();
            datesv = DateServer.Date();
            truoc = sau = datesv;
            dtgvhienthi.DataSource = new Entities.BCKhachHangTraHang[0];
            makho = new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen;
            if (makho == "")
                MessageBox.Show("Bạn chưa cài đặt kho - Xin hãy kiểm tra lại", "Hệ thống cảnh báo");
            TongTienNhanVien();
            fix();
        }
        void SelectData()
        {

            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("BCKhachHangTraHang", new Common.Utilities().CaiDatKho("View", "", "").Giatritruyen);
            clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
            selectall = (Entities.SelectAll)cl.DeserializeHepper(clientstrem, selectall);
            khachhangtralai = selectall.KhachHangTraLai;
            chitietkhachhangtralai = selectall.ChiTietKhachHangTraLai;
            thue = selectall.Thue;
            hanghoa = selectall.HangHoaTheoKho;
            hdbanhang = selectall.HDBanHang;

        }

        int giatrithue = 0;
        public void TongTienNhanVien()
        {
            try
            {


                List<Entities.BCKhachHangTraHang> temp = new List<Entities.BCKhachHangTraHang>();

                foreach (Entities.KhachHangTraLai item in khachhangtralai)
                {
                    if (truoc.Date <= item.NgayNhap && item.NgayNhap <= sau.Date)//item.NgayNhap.Date >= truoc.Date && item.NgayNhap.Date <= sau.Date
                    {
                        foreach (Entities.ChiTietKhachHangTraLai item1 in chitietkhachhangtralai)
                        {
                            if (item.MaKhachHangTraLai == item1.MaKhachHangTraLai)
                            {
                                Entities.BCKhachHangTraHang bc = new Entities.BCKhachHangTraHang();
                                bc.MaChungTu = item.MaKhachHangTraLai;
                                bc.MaKhachHang = item.MaKhachHang;
                                bc.NgayChungTu = item.NgayNhap.ToString("dd/MM/yyyy");
                                bc.SoLuong = item1.SoLuong.ToString();
                                bc.DonGia = item1.DonGia;
                                bc.TenHang = item1.TenHangHoa;
                                bc.Thue = item1.Thue;
                                bc.TenKhachHang = item.TenKhachHang;
                                double tienhang = double.Parse(bc.SoLuong) * double.Parse(bc.DonGia);
                                double thanhtien = tienhang + (double.Parse(bc.Thue) * tienhang) / 100;
                                bc.ThanhTien = thanhtien;
                                temp.Add(bc);
                            }
                        }
                    }
                }

                hienthi = (Entities.BCKhachHangTraHang[])temp.ToArray();
                ///////////////////////////////MRK FIX
                List<Entities.BCKhachHangTraHang> tem0 = new List<Entities.BCKhachHangTraHang>();
                double tong0 = 0;
                double tong1 = 0;
                foreach (Entities.BCKhachHangTraHang item in hienthi)
                {
                    tong0 += double.Parse(item.SoLuong);
                    tong1 += item.ThanhTien;
                    tem0.Add(item);
                }
                Entities.BCKhachHangTraHang tem1 = new Entities.BCKhachHangTraHang();
                tem1.MaChungTu = "Tổng: ";
                tem1.SoLuong = tong0.ToString();
                tem1.ThanhTien = tong1;
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
            dtgvhienthi.Columns["MaKhachHang"].HeaderText = "Mã KH";
            dtgvhienthi.Columns["TenKhachHang"].HeaderText = "Tên KH";
            dtgvhienthi.Columns["MaChungTu"].HeaderText = "Mã Chứng Từ";
            dtgvhienthi.Columns["NgayChungTu"].HeaderText = "Ngày Chứng Từ";
            dtgvhienthi.Columns["TenHang"].HeaderText = "Tên Hàng";
            dtgvhienthi.Columns["SoLuong"].HeaderText = "Số Lượng";
            dtgvhienthi.Columns["DonGia"].HeaderText = "Đơn Giá";
            dtgvhienthi.Columns["Thue"].HeaderText = "VAT(%)";
            dtgvhienthi.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            dtgvhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvhienthi.AllowUserToAddRows = false;
            dtgvhienthi.AllowUserToDeleteRows = false;
            dtgvhienthi.AllowUserToResizeRows = false;
            this.Focus();
        }

        DateTime truoc;
        DateTime sau;

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
                    dtgvhienthi.DataSource = new Entities.BCKhachHangTraHang[0];
                    return;
                }
                int soluong = 0;
                if (hienthi != null)
                {
                    if (rdbtimkiem1.Checked == true)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaKhachHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                soluong++;
                            }
                        }
                        if (soluong == 0)
                        {
                            dtgvhienthi.DataSource = new Entities.BCKhachHangTraHang[0];
                            return;
                        }
                        Entities.BCKhachHangTraHang[] hienthitheoid = new Entities.BCKhachHangTraHang[soluong];
                        soluong = 0;
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            int kiemtra = hienthi[i].MaKhachHang.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                            if (kiemtra >= 0)
                            {
                                hienthitheoid[soluong] = hienthi[i];
                                soluong++;
                            }
                        }
                        ///////////////////////////////MRK FIX
                        List<Entities.BCKhachHangTraHang> tem0 = new List<Entities.BCKhachHangTraHang>();
                        double tong0 = 0;
                        double tong1 = 0;
                        foreach (Entities.BCKhachHangTraHang item in hienthitheoid)
                        {
                            tong0 += double.Parse(item.SoLuong);
                            tong1 += item.ThanhTien;
                            tem0.Add(item);
                        }
                        Entities.BCKhachHangTraHang tem1 = new Entities.BCKhachHangTraHang();
                        tem1.MaChungTu = "Tổng: ";
                        tem1.SoLuong = tong0.ToString();
                        tem1.ThanhTien = tong1;
                        tem0.Add(tem1);
                        //////////////////////////////////////
                        //dtgvhienthi.DataSource = hienthi;
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
                    dtgvhienthi.DataSource = new Entities.BCKhachHangTraHang[0];
                    return;
                }
                ///////////////////////////////MRK FIX
                List<Entities.BCKhachHangTraHang> tem0 = new List<Entities.BCKhachHangTraHang>();
                double tong0 = 0;
                double tong1 = 0;
                foreach (Entities.BCKhachHangTraHang item in hienthi)
                {
                    tong0 += double.Parse(item.SoLuong);
                    tong1 += item.ThanhTien;
                    tem0.Add(item);
                }
                Entities.BCKhachHangTraHang tem1 = new Entities.BCKhachHangTraHang();
                tem1.MaChungTu = "Tổng: ";
                tem1.SoLuong = tong0.ToString();
                tem1.ThanhTien = tong1;
                tem0.Add(tem1);
                //////////////////////////////////////
                //dtgvhienthi.DataSource = hienthi;
                dtgvhienthi.DataSource = tem0.ToArray();

            }
            catch
            {
            }
            finally
            {
                fix();

            }
        }

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

        int i;
        private void dtgvhienthi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }

        private void dtgvhienthi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            tsslchitiet_Click(sender, e);
        }

        private void tsslchitiet_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                ///////////////////////////////MRK FIX Hiển thị
                List<Entities.BCKhachHangTraHang> tem0 = ((Entities.BCKhachHangTraHang[])dtgvhienthi.DataSource).ToList();
                //Entities.BCKhachHangTraHang dau = new Entities.BCKhachHangTraHang();
                //dau = tem0[0];
                Entities.BCKhachHangTraHang cuoi = new Entities.BCKhachHangTraHang();
                cuoi = tem0[tem0.Count - 1];
                //tem0.Remove(dau);
                tem0.Remove(cuoi);
                ////////////////////////////////////////////////
                hienthibaocao = tem0.ToArray();
                //hienthibaocao = (Entities.BCKhachHangTraHang[])dtgvhienthi.DataSource;

                frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, truoc, sau);
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

        private void tsslPdf_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {

                saveFileDialog1.Filter = "PDF |*.pdf"; saveFileDialog1.FileName = "";
                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ///////////////////////////////MRK FIX Hiển thị
                    List<Entities.BCKhachHangTraHang> tem0 = ((Entities.BCKhachHangTraHang[])dtgvhienthi.DataSource).ToList();
                    //Entities.BCKhachHangTraHang dau = new Entities.BCKhachHangTraHang();
                    //dau = tem0[0];
                    Entities.BCKhachHangTraHang cuoi = new Entities.BCKhachHangTraHang();
                    cuoi = tem0[tem0.Count - 1];
                    //tem0.Remove(dau);
                    tem0.Remove(cuoi);
                    ////////////////////////////////////////////////
                    hienthibaocao = tem0.ToArray();
                    //hienthibaocao = (Entities.BCKhachHangTraHang[])dtgvhienthi.DataSource;
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, truoc, sau, saveFileDialog1.FileName, "PDF");
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
                    List<Entities.BCKhachHangTraHang> tem0 = ((Entities.BCKhachHangTraHang[])dtgvhienthi.DataSource).ToList();
                    //Entities.BCKhachHangTraHang dau = new Entities.BCKhachHangTraHang();
                    //dau = tem0[0];
                    Entities.BCKhachHangTraHang cuoi = new Entities.BCKhachHangTraHang();
                    cuoi = tem0[tem0.Count - 1];
                    //tem0.Remove(dau);
                    tem0.Remove(cuoi);
                    ////////////////////////////////////////////////
                    hienthibaocao = tem0.ToArray();
                    //hienthibaocao = (Entities.BCKhachHangTraHang[])dtgvhienthi.DataSource;
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, truoc, sau, saveFileDialog1.FileName, "Word");
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
                    List<Entities.BCKhachHangTraHang> tem0 = ((Entities.BCKhachHangTraHang[])dtgvhienthi.DataSource).ToList();
                    //Entities.BCKhachHangTraHang dau = new Entities.BCKhachHangTraHang();
                    //dau = tem0[0];
                    Entities.BCKhachHangTraHang cuoi = new Entities.BCKhachHangTraHang();
                    cuoi = tem0[tem0.Count - 1];
                    //tem0.Remove(dau);
                    tem0.Remove(cuoi);
                    ////////////////////////////////////////////////
                    hienthibaocao = tem0.ToArray();
                    //hienthibaocao = (Entities.BCKhachHangTraHang[])dtgvhienthi.DataSource;
                    frmBaoCaorpt a = new frmBaoCaorpt(hienthibaocao, truoc, sau, saveFileDialog1.FileName, "Excel");
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
