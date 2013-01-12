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
    public partial class frmTimHangHoa : Form
    {
        bool isBanLe = false;
        bool isBanBuon = false;

        public TcpClient client1;
        public NetworkStream clientstrem;
        public static DataGridViewRow drvr = null;
        Entities.GoiHang[] goihang;
        Entities.QuyDoiDonViTinh[] quydoi;
        Entities.ChiTietGoiHang[] chitietgoihang;
        string maKho = "";
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        /// <param name="maKho"></param>
        public frmTimHangHoa(string maKho)
        {
            InitializeComponent();
            this.maKho = maKho;
            SelectData();
            dtgvKH.Focus();

        }

        public frmTimHangHoa(string maKho, bool isBanLe)
        {
            InitializeComponent();
            this.maKho = maKho;
            SelectData(isBanLe);
            dtgvKH.Focus();
            // Ban le
            this.isBanLe = isBanLe;

            if (!isBanLe)
                this.isBanBuon = true;
        }

        /// <summary>
        /// loivt
        /// </summary>
        /// <param name="maKho"></param>
        public frmTimHangHoa(string maKho, string name)
        {
            InitializeComponent();
            this.maKho = maKho;
            SelectData23();
            dtgvKH.Focus();

        }
        /// <param name="maKho"></param>
        public frmTimHangHoa(string maKho, string name, string h)
        {
            InitializeComponent();
            this.maKho = maKho;
            SelectDataHHTK();
            dtgvKH.Focus();

        }
        /// <summary>
        /// xử lý giá trị truyền tới
        /// </summary>
        public frmTimHangHoa()
        {
            InitializeComponent();
            Select();
        }
        Entities.HangHoa[] hienthi;

        /// <summary>
        /// select dữ liệu từ server
        /// </summary>
        public void SelectData()
        {
            try
            {
                ArrayList array = new ArrayList();
                dtgvKH.RowHeadersVisible = false;
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.HangHoa kh = new Entities.HangHoa("SelectTheoKho", maKho);
                Entities.HangHoa[] kh1 = new Entities.HangHoa[1];
                clientstrem = cl.SerializeObj(this.client1, "HangHoa", kh);
                kh1 = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, kh1);
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


                if (kh1 == null)
                {
                    hienthi = new Entities.HangHoa[0];
                    dtgvKH.DataSource = new Entities.HangHoa[0];
                    return;
                }
                foreach (Entities.HangHoa item in kh1)
                {
                    if (item.Deleted == false)
                        array.Add(item);
                }
                if (array.Count != 0)
                {
                    Entities.HangHoa[] save = Common.Utilities.CheckGoiHang((Entities.HangHoa[])array.ToArray(typeof(Entities.HangHoa)), goihang, chitietgoihang);
                    foreach (Entities.HangHoa item in save)
                    {
                        array.Add(item);
                    }
                    hienthi = (Entities.HangHoa[])array.ToArray(typeof(Entities.HangHoa));
                }
                else
                {
                    hienthi = new Entities.HangHoa[0];
                    dtgvKH.DataSource = new Entities.HangHoa[0];
                    return;
                }

                dtgvKH.DataSource = hienthi;
                dtgvKH.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {

                fix();


            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isBanLe"></param>
        public void SelectData(bool isBanLe)
        {
            try
            {
                ArrayList array = new ArrayList();
                dtgvKH.RowHeadersVisible = false;
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.HangHoa kh = new Entities.HangHoa("SelectTheoKho", maKho);
                Entities.HangHoa[] kh1 = new Entities.HangHoa[1];
                clientstrem = cl.SerializeObj(this.client1, "HangHoa", kh);
                kh1 = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, kh1);
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


                if (kh1 == null)
                {
                    hienthi = new Entities.HangHoa[0];
                    dtgvKH.DataSource = new Entities.HangHoa[0];
                    return;
                }
                foreach (Entities.HangHoa item in kh1)
                {
                    if (item.Deleted == false)
                        array.Add(item);
                }
                if (array.Count != 0)
                {
                    Entities.HangHoa[] save = Common.Utilities.CheckGoiHang((Entities.HangHoa[])array.ToArray(typeof(Entities.HangHoa)), goihang, chitietgoihang);
                    foreach (Entities.HangHoa item in save)
                    {
                        array.Add(item);
                    }
                    hienthi = (Entities.HangHoa[])array.ToArray(typeof(Entities.HangHoa));
                }
                else
                {
                    hienthi = new Entities.HangHoa[0];
                    dtgvKH.DataSource = new Entities.HangHoa[0];
                    return;
                }

                dtgvKH.DataSource = hienthi;
                dtgvKH.Rows[0].Selected = true;
            }
            catch
            {
            }
            finally
            {
                if (isBanLe)
                    fixBL();
                else
                    fixBB();
            }
        }


        /// <summary>
        /// loivt
        /// </summary>
        public void SelectData23()
        {
            try
            {

                ArrayList array = new ArrayList();
                dtgvKH.RowHeadersVisible = false;
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.HangHoa kh = new Entities.HangHoa("Select");
                Entities.HangHoa[] kh1 = new Entities.HangHoa[1];
                clientstrem = cl.SerializeObj(this.client1, "HangHoa", kh);
                kh1 = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, kh1);

                if (kh1 == null)
                {
                    hienthi = new Entities.HangHoa[0];
                    dtgvKH.DataSource = new Entities.HangHoa[0];
                    return;
                }
                foreach (Entities.HangHoa item in kh1)
                {
                    if (item.Deleted == false)
                        array.Add(item);
                }
                if (array.Count != 0)
                {
                    Entities.HangHoa[] save = Common.Utilities.CheckGoiHang((Entities.HangHoa[])array.ToArray(typeof(Entities.HangHoa)), goihang, chitietgoihang);
                    foreach (Entities.HangHoa item in save)
                    {
                        array.Add(item);
                    }
                    hienthi = (Entities.HangHoa[])array.ToArray(typeof(Entities.HangHoa));
                }
                else
                {
                    hienthi = new Entities.HangHoa[0];
                    dtgvKH.DataSource = new Entities.HangHoa[0];
                    return;
                }

                dtgvKH.DataSource = hienthi;
                dtgvKH.Rows[0].Selected = true;
            }
            catch
            {
            }
            finally
            {

                fix();


            }
        }

        public void SelectDataHHTK()
        {
            try
            {

                ArrayList array = new ArrayList();
                dtgvKH.RowHeadersVisible = false;
                Server_Client.Client cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.HangHoa kh = new Entities.HangHoa("SelectTheoKho", maKho);
                Entities.HangHoa[] kh1 = new Entities.HangHoa[1];
                clientstrem = cl.SerializeObj(this.client1, "HangHoa", kh);
                kh1 = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, kh1);

                if (kh1 == null)
                {
                    hienthi = new Entities.HangHoa[0];
                    dtgvKH.DataSource = new Entities.HangHoa[0];
                    return;
                }
                foreach (Entities.HangHoa item in kh1)
                {
                    if (item.Deleted == false)
                        array.Add(item);
                }
                if (array.Count != 0)
                {
                    Entities.HangHoa[] save = Common.Utilities.CheckGoiHang((Entities.HangHoa[])array.ToArray(typeof(Entities.HangHoa)), goihang, chitietgoihang);
                    foreach (Entities.HangHoa item in save)
                    {
                        array.Add(item);
                    }
                    hienthi = (Entities.HangHoa[])array.ToArray(typeof(Entities.HangHoa));
                }
                else
                {
                    hienthi = new Entities.HangHoa[0];
                    dtgvKH.DataSource = new Entities.HangHoa[0];
                    return;
                }

                dtgvKH.DataSource = hienthi;
                dtgvKH.Rows[0].Selected = true;
            }
            catch
            {
            }
            finally
            {

                fix();


            }
        }

        public void Select()
        {
            try
            {
                dtgvKH.RowHeadersVisible = false;
                Server_Client.Client cl = new Server_Client.Client();
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                Entities.CheckRefer ctxh = new Entities.CheckRefer("HH");
                clientstrem = cl.SerializeObj(this.client1, "Select", ctxh);
                Entities.HangHoa[] kh1 = new Entities.HangHoa[0];
                kh1 = (Entities.HangHoa[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 == null)
                {
                    hienthi = new Entities.HangHoa[0];
                    dtgvKH.DataSource = new Entities.HangHoa[0];
                    return;
                }

                Entities.HangHoa[] ncc2 = new Entities.HangHoa[kh1.Length];
                int sotang = 0;
                for (int j = 0; j < kh1.Length; j++)
                {
                    if (kh1[j].Deleted == false)
                    {
                        ncc2[sotang] = kh1[j];
                        sotang++;
                    }
                }
                hienthi = new Entities.HangHoa[sotang];
                if (sotang != 0)
                {
                    for (int j = 0; j < sotang; j++)
                    {
                        hienthi[j] = ncc2[j];
                    }
                }
                else
                {
                    hienthi = new Entities.HangHoa[0];
                    dtgvKH.DataSource = new Entities.HangHoa[0];
                    return;
                }

                dtgvKH.DataSource = hienthi;
                dtgvKH.Rows[0].Selected = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                fix1();
            }
        }

        public void fix1()
        {
            for (int i = 0; i < dtgvKH.ColumnCount; i++)
            {
                dtgvKH.Columns[i].Visible = false;
            }
            dtgvKH.ReadOnly = true;
            dtgvKH.Columns["MaHangHoa"].Visible = true;
            dtgvKH.Columns["TenHangHoa"].Visible = true;
            dtgvKH.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
            dtgvKH.Columns["TenHangHoa"].HeaderText = "Tên Hàng Hóa";
            dtgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvKH.AllowUserToAddRows = false;
            dtgvKH.AllowUserToDeleteRows = false;
            dtgvKH.AllowUserToResizeRows = false;
        }

        public void fix()
        {
            for (int i = 0; i < dtgvKH.ColumnCount; i++)
            {
                dtgvKH.Columns[i].Visible = false;
            }
            dtgvKH.ReadOnly = true;
            dtgvKH.Columns["MaHangHoa"].Visible = true;
            dtgvKH.Columns["TenHangHoa"].Visible = true;
            dtgvKH.Columns["GiaNhap"].Visible = true;
            dtgvKH.Columns["GiaBanLe"].Visible = true;
            dtgvKH.Columns["GiaBanBuon"].Visible = true;
            dtgvKH.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
            dtgvKH.Columns["TenHangHoa"].HeaderText = "Tên Hàng Hóa";
            dtgvKH.Columns["GiaNhap"].HeaderText = "Giá Nhập";
            dtgvKH.Columns["GiaBanLe"].HeaderText = "Giá Bán Lẻ";
            dtgvKH.Columns["GiaBanBuon"].HeaderText = "Giá Bán Buôn";
            dtgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvKH.AllowUserToAddRows = false;
            dtgvKH.AllowUserToDeleteRows = false;
            dtgvKH.AllowUserToResizeRows = false;
        }

        /// <summary>
        /// fixBB
        /// </summary>
        public void fixBB()
        {
            for (int i = 0; i < dtgvKH.ColumnCount; i++)
            {
                dtgvKH.Columns[i].Visible = false;
            }
            dtgvKH.ReadOnly = true;
            dtgvKH.Columns["MaHangHoa"].Visible = true;
            dtgvKH.Columns["TenHangHoa"].Visible = true;
            dtgvKH.Columns["GiaNhap"].Visible = false;
            dtgvKH.Columns["GiaBanLe"].Visible = false;
            dtgvKH.Columns["GiaBanBuon"].Visible = true;
            dtgvKH.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
            dtgvKH.Columns["TenHangHoa"].HeaderText = "Tên Hàng Hóa";
            dtgvKH.Columns["GiaBanBuon"].HeaderText = "Giá Bán Buôn";
            dtgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvKH.AllowUserToAddRows = false;
            dtgvKH.AllowUserToDeleteRows = false;
            dtgvKH.AllowUserToResizeRows = false;
        }

        /// <summary>
        /// fixBL
        /// </summary>
        public void fixBL()
        {
            for (int i = 0; i < dtgvKH.ColumnCount; i++)
            {
                dtgvKH.Columns[i].Visible = false;
            }
            dtgvKH.ReadOnly = true;
            dtgvKH.Columns["MaHangHoa"].Visible = true;
            dtgvKH.Columns["TenHangHoa"].Visible = true;
            dtgvKH.Columns["GiaNhap"].Visible = false;
            dtgvKH.Columns["GiaBanLe"].Visible = true;
            dtgvKH.Columns["GiaBanBuon"].Visible = false;
            dtgvKH.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
            dtgvKH.Columns["TenHangHoa"].HeaderText = "Tên Hàng Hóa";
            dtgvKH.Columns["GiaBanLe"].HeaderText = "Giá Bán Lẻ";
            dtgvKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvKH.AllowUserToAddRows = false;
            dtgvKH.AllowUserToDeleteRows = false;
            dtgvKH.AllowUserToResizeRows = false;
        }

        /// <summary>
        /// xử lý chấp nhận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslchapnhan_Click(object sender, EventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                drvr = dtgvKH.Rows[i];
                this.Close();
            }
            catch
            {
            }
        }
        /// <summary>
        /// xử lý hủy bỏ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsslhuybo_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        int i;
        /// <summary>
        /// xử lý click vào ô
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
        }
        /// <summary>
        /// xử lý click đúp vào ô
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgvKH_DoubleClick(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// xử lý khi thay đổi kích thước
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTimHangHoa_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        /// <summary>
        /// xử lý khi tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbtimkiem3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dtgvKH.DataSource = hienthi;
                // Ban le
                if (this.isBanLe)
                    fixBL();
                // ban buon
                else if (this.isBanBuon)
                    fixBB();
                // truong hop khac
                else
                    fix();
            }
            catch
            {
            }
        }
        /// <summary>
        /// xử lý khi tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Tat ca
                if (rdbtimkiem3.Checked == true)
                {
                    return;
                }

                int soluong = 0;
                // Theo Ten san pham
                if (rdbtimkiem1.Checked == true)
                {
                    if (txttimkiem.Text.Length == 0)
                    {
                        dtgvKH.DataSource = new Entities.HangHoa[0];
                        return;
                    }
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].TenHangHoa.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            soluong++;
                        }
                    }
                    if (soluong == 0)
                    {
                        dtgvKH.DataSource = new Entities.HangHoa[0];
                        return;
                    }
                    Entities.HangHoa[] hienthitheoid = new Entities.HangHoa[soluong];
                    soluong = 0;
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].TenHangHoa.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            hienthitheoid[soluong] = hienthi[i];
                            soluong++;
                        }
                    }
                    dtgvKH.DataSource = hienthitheoid;
                }
                // Theo ma san pham
                if (rdbtimkiem2.Checked == true)
                {
                    if (txttimkiem.Text.Length == 0)
                    {
                        dtgvKH.DataSource = new Entities.HangHoa[0];
                        return;
                    }
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
                        dtgvKH.DataSource = new Entities.HangHoa[0];
                        return;
                    }
                    Entities.HangHoa[] hienthitheoma = new Entities.HangHoa[soluong];
                    soluong = 0;
                    for (int i = 0; i < hienthi.Length; i++)
                    {
                        int kiemtra = hienthi[i].MaHangHoa.ToString().ToUpper().IndexOf(txttimkiem.Text.ToUpper());
                        if (kiemtra >= 0)
                        {
                            hienthitheoma[soluong] = hienthi[i];
                            soluong++;
                        }
                    }
                    dtgvKH.DataSource = hienthitheoma;
                }
            }
            finally
            {
                // Ban le
                if (this.isBanLe)
                    fixBL();
                // ban buon
                else if (this.isBanBuon)
                    fixBB();
                // truong hop khac
                else
                    fix();
            }
        }

        private void rdbtimkiem1_CheckedChanged(object sender, EventArgs e)
        {
            txttimkiem.Text = "";
        }

        private void rdbtimkiem2_CheckedChanged(object sender, EventArgs e)
        {
            txttimkiem.Text = "";
        }

        private void dtgvKH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (i < 0)
                return;
            try
            {
                drvr = dtgvKH.Rows[i];
                this.Close();
            }
            catch
            {
            }
        }

        private void dtgvKH_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    i = dtgvKH.SelectedRows[0].Index;
                    drvr = dtgvKH.Rows[i];
                    this.Close();
                }
            }
            catch
            {
            }
        }

        private void frmTimHangHoa_Load(object sender, EventArgs e)
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
