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
    public partial class frmTimKiemHangHoaGoiHang : Form
    {
        string MaVachHHorMaVachTV = "HH";   //HH: hàng hóa, TV: thẻ vip

        public frmTimKiemHangHoaGoiHang()
        {
            InitializeComponent();
            try
            {
                this.SelectData();
            }
            catch (Exception)
            { }
            this.dgvHieThi.Focus();
        }

        public frmTimKiemHangHoaGoiHang(string MaVachHHorMaVachTV)
        {
            InitializeComponent();
            try
            {
                this.MaVachHHorMaVachTV = MaVachHHorMaVachTV;
                this.SelectData();
            }
            catch (Exception)
            { }
            this.dgvHieThi.Focus();
        }

        private ArrayList list = new ArrayList();
        private TcpClient client;
        private NetworkStream clientstrem;
        private Server_Client.Client cl;
        private Entities.ThongTinMaVach[] search;
        #region
        ////////////////////////////////////////////MRk FIX
        Entities.ThongTinMaVach[] getTheVip()
        {
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            clientstrem = cl.SerializeObj(this.client, "THAOTAC_InMaVachTheVip", new Entities.ThongTinMaVach());
            Entities.ThongTinMaVach[] bientam = new Entities.ThongTinMaVach[1];
            //Tìm kiếm thẻ vip
            bientam = (Entities.ThongTinMaVach[])cl.DeserializeHepper(clientstrem, bientam);
            client.Close();
            clientstrem.Close();
            if (bientam != null)
            {
                return bientam;
            }
            else
            {
                return new Entities.ThongTinMaVach[0];
            }
        }
        Entities.ThongTinMaVach[] getTheGiaTri()
        {
            cl = new Server_Client.Client();
            this.client = cl.Connect(Luu.IP, Luu.Ports);
            clientstrem = cl.SerializeObj(this.client, "THAOTAC_InMaVachTheGiaTri", new Entities.ThongTinMaVach());
            Entities.ThongTinMaVach[] bientam = new Entities.ThongTinMaVach[1];
            //Tìm kiếm thẻ giá trị
            bientam = (Entities.ThongTinMaVach[])cl.DeserializeHepper(clientstrem, bientam);
            client.Close();
            clientstrem.Close();
            if (bientam != null)
            {
                return bientam;
            }
            else
            {
                return new Entities.ThongTinMaVach[0];
            }
        }
        ////////////////////////////////////////////MRk FIX
        private void SelectData()
        {
            try
            {
                // The Vip
                if (this.MaVachHHorMaVachTV.Equals("TV"))
                {
                    List<Entities.ThongTinMaVach> l = new List<Entities.ThongTinMaVach>();
                    l = getTheVip().ToList();

                    if (l.Count == 0)
                    {
                        this.search = new Entities.ThongTinMaVach[0];
                        dgvHieThi.DataSource = new Entities.ThongTinMaVach[0];

                    }
                    else
                    {
                        this.search = l.ToArray();
                        dgvHieThi.DataSource = this.search;
                    }

                    FixDatagridview();
                }
                // The GT
                if (this.MaVachHHorMaVachTV.Equals("TGT"))
                {
                    List<Entities.ThongTinMaVach> tgt = new List<Entities.ThongTinMaVach>();
                    tgt = getTheGiaTri().ToList();

                    if (tgt.Count == 0)
                    {
                        this.search = new Entities.ThongTinMaVach[0];
                        dgvHieThi.DataSource = new Entities.ThongTinMaVach[0];

                    }
                    else
                    {
                        this.search = tgt.ToArray();
                        dgvHieThi.DataSource = this.search;
                    }

                    FixDatagridview();
                }
                // Hang Hoa
                if (this.MaVachHHorMaVachTV.Equals("HH"))
                {
                    dgvHieThi.DataSource = null;
                    cl = new Server_Client.Client();
                    this.client = cl.Connect(Luu.IP, Luu.Ports);
                    Entities.ThongTinMaVach row = new Entities.ThongTinMaVach("Select");
                    clientstrem = cl.SerializeObj(this.client, "ThongTinMaVachHangHoa", row);
                    search = new Entities.ThongTinMaVach[1];
                    //Tìm kiếm hàng hóa
                    this.search = (Entities.ThongTinMaVach[])cl.DeserializeHepper(clientstrem, this.search);
                    client.Close();
                    clientstrem.Close();
                    this.SelectGoiHang();
                    //////////////////////////////MRK FIX
                    List<Entities.QuyDoiDonViTinh> ltem0 = this.bangquydoidonvitinh();
                    List<Entities.ThongTinMaVach> ltem1 = this.search.ToList();
                    foreach (Entities.QuyDoiDonViTinh item in ltem0)
                    {
                        Entities.ThongTinMaVach tem = new Entities.ThongTinMaVach();
                        tem.MaHangHoa = item.MaHangQuyDoi;
                        tem.TenHangHoa = item.TenHangDuocQuyDoi;
                        ltem1.Add(tem);
                    }
                    //dgvHieThi.DataSource = ltem1.ToArray();
                    //FixDatagridview();
                    this.search = new Entities.ThongTinMaVach[ltem1.Count];
                    for (int i = 0; i < ltem1.Count; i++)
                    {
                        this.search[i] = (Entities.ThongTinMaVach)ltem1[i];
                    }
                    ///////////////////////////////////////
                    if (this.search != null)
                    {
                        dgvHieThi.DataSource = this.search;
                    }
                    else
                    {
                        Entities.ThongTinMaVach[] lay = new Entities.ThongTinMaVach[0];
                        dgvHieThi.DataSource = lay;
                    }
                    FixDatagridview();
                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.ThongTinMaVach[] lay = new Entities.ThongTinMaVach[0];
                dgvHieThi.DataSource = lay;
                FixDatagridview();
            }
        }
        public void SelectGoiHang()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.GoiHang goi = new Entities.GoiHang("Select");
                clientstrem = cl.SerializeObj(this.client, "GoiHang", goi);
                Entities.GoiHang[] GoiHang = new Entities.GoiHang[1];
                GoiHang = (Entities.GoiHang[])cl.DeserializeHepper1(clientstrem, GoiHang);
                try
                {
                    for (int j = 0; j < GoiHang.Length; j++)
                    {
                        if (GoiHang[j].Deleted == false)
                        {
                            Entities.ThongTinMaVach row = new Entities.ThongTinMaVach();
                            row.MaHangHoa = GoiHang[j].MaGoiHang;
                            row.TenHangHoa = GoiHang[j].TenGoiHang;
                            list.Add(row);
                        }
                    }

                }
                catch { }
                try
                {
                    for (int i = 0; i < this.search.Length; i++)
                    {
                        list.Add(this.search[i]);
                    }
                }
                catch { }
                int k = list.Count;
                if (k <= 0)
                {
                    this.search = null;
                }
                else
                {
                    this.search = new Entities.ThongTinMaVach[k];
                    for (int i = 0; i < k; i++)
                    {
                        this.search[i] = (Entities.ThongTinMaVach)list[i];
                    }
                }
            }
            catch { }
        }

        List<Entities.QuyDoiDonViTinh> bangquydoidonvitinh()
        {
            // quy đổi đơn vị tính
            Server_Client.Client cl = new Server_Client.Client();
            TcpClient client1 = cl.Connect(Luu.IP, Luu.Ports);
            Entities.CheckRefer ctxh = new Entities.CheckRefer("QD");
            clientstrem = cl.SerializeObj(client1, "Select", ctxh);
            Entities.QuyDoiDonViTinh[] quidoidvt = new Entities.QuyDoiDonViTinh[0];
            return ((Entities.QuyDoiDonViTinh[])cl.DeserializeHepper1(clientstrem, quidoidvt)).ToList();
        }

        private void FixDatagridview()
        {
            try
            {
                dgvHieThi.Columns[0].Visible = false;
                dgvHieThi.Columns[1].Visible = false;
                dgvHieThi.Columns[2].Visible = true;
                dgvHieThi.Columns[3].Visible = true;
                dgvHieThi.Columns[4].Visible = false;
                dgvHieThi.Columns[5].Visible = false;
                dgvHieThi.Columns[6].Visible = false;
                dgvHieThi.Columns[7].Visible = false;
                if (this.MaVachHHorMaVachTV.Equals("TV"))
                {
                    dgvHieThi.Columns[2].HeaderText = "Mã Thẻ Vip";
                    dgvHieThi.Columns[3].HeaderText = "Tên Khách Hàng";
                }
                else
                {
                    dgvHieThi.Columns[2].HeaderText = "Mã Hàng Hóa";
                    dgvHieThi.Columns[3].HeaderText = "Tên Hàng Hóa";
                }
                dgvHieThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        private void GetRow(string mahanghoa)
        {
            try
            {
                if (this.search == null)
                {
                    return;
                }
                for (int i = 0; i < this.search.Length; i++)
                {
                    if (this.search[i].MaHangHoa == mahanghoa)
                    {
                        banghi = this.search[i];
                        break;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        private static int count = 1;
        private void SearchData(RadioButton rdoMa, RadioButton rdoNgay, DataGridView dgv, string giatritim, Entities.ThongTinMaVach[] mangtim)
        {
            try
            {
                if (giatritim.Length > 0)
                {
                    if (mangtim.Length > 0)
                    {
                        if (rdoNgay.Checked == true)
                        {
                            if (mangtim == null)
                            {
                                Entities.ThongTinMaVach[] lay = new Entities.ThongTinMaVach[0];
                                dgv.DataSource = lay;
                            }
                            else
                            {
                                Boolean check = false;
                                List<Entities.ThongTinMaVach> tt1_search = new List<Entities.ThongTinMaVach>();
                                for (int i = 0; i < mangtim.Length; i++)
                                {
                                    int index = -1;
                                    index = mangtim[i].TenHangHoa.ToString().ToLower().IndexOf(giatritim.ToLower());
                                    if (index >= 0)
                                    {
                                        check = true;
                                        tt1_search.Add(mangtim[i]);
                                    }

                                }
                                if (check == false)
                                {
                                    Entities.ThongTinMaVach[] lay = new Entities.ThongTinMaVach[0];
                                    dgv.DataSource = lay;
                                }
                                else
                                {
                                    dgv.DataSource = tt1_search.ToArray();
                                    tt1_search = null;
                                }
                            }
                        }
                        if (rdoMa.Checked == true)
                        {
                            if (mangtim == null)
                            {
                                Entities.ThongTinMaVach[] lay = new Entities.ThongTinMaVach[0];
                                dgv.DataSource = lay;
                            }
                            else
                            {
                                Boolean check = false;
                                List<Entities.ThongTinMaVach> tt1_search = new List<Entities.ThongTinMaVach>();
                                for (int i = 0; i < mangtim.Length; i++)
                                {
                                    int index = -1;
                                    index = mangtim[i].MaHangHoa.ToString().ToLower().IndexOf(giatritim.ToLower());
                                    if (index >= 0)
                                    {
                                        check = true;
                                        tt1_search.Add(mangtim[i]);
                                    }
                                }
                                if (check == false)
                                {
                                    Entities.ThongTinMaVach[] lay = new Entities.ThongTinMaVach[0];
                                    dgv.DataSource = lay;
                                }
                                else
                                {
                                    dgv.DataSource = tt1_search.ToArray();
                                    tt1_search = null;
                                }
                            }
                        }
                    }
                    else
                    {
                        Entities.ThongTinMaVach[] k = new Entities.ThongTinMaVach[0];
                        dgv.DataSource = k;
                    }

                }
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.ThongTinMaVach[] k = new Entities.ThongTinMaVach[0];
                dgvHieThi.DataSource = k;
                count = 1;
            }
        }
        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchData(rdoMa, rdoTen, dgvHieThi, txtTimKiem.Text, search);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.ThongTinMaVach[] k = new Entities.ThongTinMaVach[0];
                dgvHieThi.DataSource = k;
                count = 1;
            }
        }

        private void rdbNgay_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SearchData(rdoMa, rdoTen, dgvHieThi, txtTimKiem.Text, search);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.ThongTinMaVach[] k = new Entities.ThongTinMaVach[0];
                dgvHieThi.DataSource = k;
                count = 1;
            }
        }

        private void rdbMa_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SearchData(rdoMa, rdoTen, dgvHieThi, txtTimKiem.Text, search);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Entities.ThongTinMaVach[] k = new Entities.ThongTinMaVach[0];
                dgvHieThi.DataSource = k;
                count = 1;
            }
        }
        Entities.ThongTinMaVach banghi;

        private void GhiLai()
        {
            try
            {
                if (this.MaHangHoa == string.Empty)
                {
                    MessageBox.Show("Phải chọn hàng hóa", "Thông Báo");
                    return;
                }
                this.GetRow(this.MaHangHoa);
                frmQuanLyMaVach.Timhanghoa = this.banghi;
                this.Close();
            }
            catch (Exception)
            {
            }

        }
        private void toolStripStatus_Chapnhan_Click(object sender, EventArgs e)
        {
            this.GhiLai();
        }

        private void toolStripStatus_Huybo_Click(object sender, EventArgs e)
        {
            frmQuanLyMaVach.Timhanghoa = null;
            this.Close();
        }
        string MaHangHoa = string.Empty;
        int index = -1;
        private void dgvHieThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
                this.MaHangHoa = dgvHieThi.Rows[e.RowIndex].Cells["MaHangHoa"].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void dgvHieThi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.GhiLai();
            }
            catch (Exception)
            {
            }
        }

        private void dgvHieThi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int index = dgvHieThi.SelectedCells[0].RowIndex;
                this.MaHangHoa = dgvHieThi.Rows[index].Cells["MaHangHoa"].Value.ToString();
                this.GhiLai();
            }
        }

    }
}
