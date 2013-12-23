using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace GUI
{
    public partial class frmTraCuuHDNhap : Form
    {
        public frmTraCuuHDNhap()
        {
            InitializeComponent();
        }

        string DoiTuong;
        public frmTraCuuHDNhap(string doituong)
        {
            InitializeComponent();

        }
        #region Lấy Bảng Hàng Hóa
        public Entities.HangHoa[] hanghoa;
        public void LayBangHangHoa()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "Select", new Entities.CheckRefer("HH", ""));
                Entities.HangHoa[] hh1 = new Entities.HangHoa[1];
                hh1 = (Entities.HangHoa[])cl.DeserializeHepper(clientstrem, hh1);
                if (hh1 == null)
                {
                    hanghoa = new Entities.HangHoa[0];
                    return;
                }
                hanghoa = hh1;
            }
            catch { }
        }
        #endregion
        public frmTraCuuHDNhap(string doituong, string maKho)
        {
            InitializeComponent();
            LayBangHangHoa();
            DoiTuong = doituong;
            if (doituong == "theo_HDNhap")
            {
                SelectDataHDNhap(maKho);
            }
            else
                if (doituong == "theo_Kho")
                {
                    SelectDataMakho(maKho);
                }
                else
                    if (doituong == "HangHoa")
                    {
                        SelectHangHoa(maKho);
                    }
        }

        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.HoaDonNhap ctdh;

        private void SelectHangHoa(string maKho)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "ChiTietKho", new Entities.ChiTietKhoHangTheoHoaHonNhap("Select"));
                Entities.ChiTietKhoHangTheoHoaHonNhap[] kh1 = new Entities.ChiTietKhoHangTheoHoaHonNhap[1];
                kh1 = (Entities.ChiTietKhoHangTheoHoaHonNhap[])cl.DeserializeHepper1(clientstrem, kh1);
                if (kh1 == null)
                {
                    kh1 = new Entities.ChiTietKhoHangTheoHoaHonNhap[0];
                    return;
                }
                List<Entities.ChiTietKhoHangTheoHoaHonNhap> L = new List<Entities.ChiTietKhoHangTheoHoaHonNhap>();
                foreach (Entities.ChiTietKhoHangTheoHoaHonNhap item in kh1)
                {
                    if (item.Makho.ToUpper().Equals(maKho.ToUpper()))
                    {
                        L.Add(item);
                    }
                }
                dgvHienThi.DataSource = L.ToArray();
                FixDataGridView();
            }
            catch { }
        }

        private void SelectDataHDNhap(string maKho)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "HoaDonNhap", new Entities.HoaDonNhap("Select", "", maKho, 1));
                Entities.HoaDonNhap[] ddh = new Entities.HoaDonNhap[1];
                ddh = (Entities.HoaDonNhap[])cl.DeserializeHepper(clientstrem, ddh);
                if (ddh == null)
                {
                    return;
                }
                List<Entities.HoaDonNhap> L = new List<Entities.HoaDonNhap>();
                foreach (Entities.HoaDonNhap item in ddh)
                {
                    if (item.MaKho.ToUpper().Equals(maKho.ToUpper()))
                    {
                        L.Add(item);
                    }
                }
                dgvHienThi.DataSource = L.ToArray();
                FixDataGridView();
            }
            catch { }
        }



        public void FixDataGridView()
        {
            try
            {
                for (int i = 0; i < dgvHienThi.ColumnCount; i++)
                {
                    dgvHienThi.Columns[i].Visible = false;
                }
                dgvHienThi.Columns["MaHangHoa"].Visible = true;
                dgvHienThi.Columns["MaKho"].Visible = true;
                dgvHienThi.Columns["MaHangHoa"].HeaderText = "Mã Hàng Hóa";
                dgvHienThi.Columns["MaKho"].HeaderText = "Mã Kho";
                dgvHienThi.RowHeadersVisible = false;
                dgvHienThi.Columns[0].Visible = false;
                dgvHienThi.Columns[dgvHienThi.ColumnCount - 1].Visible = false;
                dgvHienThi.AllowUserToResizeRows = false;
                dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHienThi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dgvHienThi.ReadOnly = true;
            }
            catch { }
        }

        Entities.ChiTietKhoHangTheoHoaHonNhap cthdn;
        private void SelectDataMakho(string maKho)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client, "ChiTietKho", new Entities.ChiTietKhoHangTheoHoaHonNhap("Select"));
                Entities.ChiTietKhoHangTheoHoaHonNhap[] cthd = new Entities.ChiTietKhoHangTheoHoaHonNhap[1];
                cthd = (Entities.ChiTietKhoHangTheoHoaHonNhap[])cl.DeserializeHepper(clientstrem, cthd);
                if (cthd == null)
                {
                    return;
                }
                List<Entities.ChiTietKhoHangTheoHoaHonNhap> L = new List<Entities.ChiTietKhoHangTheoHoaHonNhap>();
                foreach (Entities.ChiTietKhoHangTheoHoaHonNhap item in cthd)
                {
                    if (item.Makho.ToUpper().Equals(maKho.ToUpper()))
                    {
                        L.Add(item);
                    }
                }
                dgvHienThi.DataSource = L.ToArray();
                FixDataGridView();
            }
            catch { }
        }

        private void dgvHienThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (DoiTuong == "theo_HDNhap")
                {
                    frmXuLy_DieuChuyenKhoNoiBo.maHDNhap = dgvHienThi.Rows[e.RowIndex].Cells[2].Value.ToString();
                    this.Close();
                }
                else
                    if (DoiTuong == "theo_Kho")
                    {
                        frmXuLy_DieuChuyenKhoNoiBo.ct = dgvHienThi.Rows[e.RowIndex];
                        this.Close();
                    }
                    else
                        if (DoiTuong == "HangHoa")
                        {
                            Entities.SoDuKho sdk = new Entities.SoDuKho();
                            sdk.MaHangHoa = dgvHienThi.Rows[e.RowIndex].Cells["MaHangHoa"].Value.ToString();
                            frmSoDuKhoHang.sdkho = sdk;
                            this.Close();
                        }
            }
        }

        private void tsslChon_Click(object sender, EventArgs e)
        {
            if (DoiTuong == "theo_HDNhap")
            {
                frmXuLy_DieuChuyenKhoNoiBo.maHDNhap = dgvHienThi.CurrentRow.Cells[2].Value.ToString();
                this.Close();
            }
            else
                if (DoiTuong == "theo_Kho")
                {
                    frmXuLy_DieuChuyenKhoNoiBo.ct = dgvHienThi.CurrentRow;
                    this.Close();
                }
                else
                    if (DoiTuong == "HangHoa")
                    {
                        Entities.SoDuKho sdk = new Entities.SoDuKho();
                        sdk.MaHangHoa = dgvHienThi.CurrentRow.Cells["MaHangHoa"].Value.ToString();
                        //  sdk.TenHangHoa = dgvHienThi.Rows[e.RowIndex].Cells["TenHangHoa"].Value.ToString();
                        frmSoDuKhoHang.sdkho = sdk;
                        this.Close();
                    }
        }

        private void tsslBoChon_Click(object sender, EventArgs e)
        {
            frmXuLy_DieuChuyenKhoNoiBo.maHDNhap = "";
            this.Close();
        }

        private void tsslThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
