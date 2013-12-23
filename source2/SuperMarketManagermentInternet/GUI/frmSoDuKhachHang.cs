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
    public partial class frmSoDuKhachHang : Form
    {
        DateTime datesv;
        string ma = "";
        string year ;
        string month;
        public TcpClient client1;
        public NetworkStream clientstrem;
        Server_Client.Client cl;
        public frmSoDuKhachHang()
        {
            try
            {
                InitializeComponent();datesv = DateServer.Date();
                cbbnam.Text = datesv.Year.ToString();
                cbbthang.Text = datesv.Month.ToString();
                cbbdoituong.SelectedIndex = 0;
                SelectData();
            }
            catch
            {
            }
        }
      
        private void frmSoDuKhachHang_Load(object sender, EventArgs e)
        {

        }
        Entities.SoDuCongNo[] hienthi;
        public void SelectData()
        {
            try
            {
                bool loaiDoiTuong = false;
                if (cbbdoituong.SelectedIndex == 0)
                    loaiDoiTuong = false;
                else
                    loaiDoiTuong = true;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.SoDuCongNo[] pt = new Entities.SoDuCongNo[1];
                pt[0] = new Entities.SoDuCongNo("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                clientstrem = cl.SerializeHepper(this.client1, "CongNo", pt);
                // đổ mảng đối tượng vào datagripview       
                hienthi = (Entities.SoDuCongNo[])cl.DeserializeHepper1(clientstrem, hienthi);
                // nếu null
                if (hienthi == null)
                {
                    hienthi = new Entities.SoDuCongNo[0];
                    lbtrangthai.Text = "Kỳ này chưa đóng";
                    lbtrangthai.ForeColor = Color.Black;
                    toolStrip1.Enabled = dtgvcongno.Enabled = true;
                    return;
                }
                year = cbbnam.Text;
                month = cbbthang.Text;
                int sotang = 0;
                bool ktsd = false;
                Entities.SoDuCongNo[] sq = new Entities.SoDuCongNo[hienthi.Length];
                for (int i = 0; i < sq.Length; i++)
                {
                    string namkt = hienthi[i].NgayKetChuyen.Year.ToString();
                    string thangkt = hienthi[i].NgayKetChuyen.Month.ToString();
                    // nếu năm tháng trong bản ghi - năm tháng hiện tại và loại đối tượng
                    if (namkt == year && thangkt == month && hienthi[i].LoaiDoiTuong == loaiDoiTuong)
                    {
                        // nếu trạng thái = false
                        if (hienthi[i].TrangThai == false)
                        {
                            lbtrangthai.Text = "Kỳ này chưa đóng";
                            lbtrangthai.ForeColor = Color.Black;
                            toolStrip1.Enabled = dtgvcongno.Enabled = true;
                        }
                        else
                        {
                            lbtrangthai.Text = "Kỳ này đã khóa";
                            lbtrangthai.ForeColor = Color.Red;
                            toolStrip1.Enabled = dtgvcongno.Enabled = false;
                        }
                        ma = hienthi[i].MaSoDuCongNo;
                        sq[sotang] = hienthi[i];
                        sotang++;
                        ktsd = true;
                    }
                }
                // nếu không có đối tượng nào đúng
                if (ktsd == false)
                {
                    lbtrangthai.Text = "Kỳ này chưa đóng";
                    lbtrangthai.ForeColor = Color.Black;
                    toolStrip1.Enabled = dtgvcongno.Enabled = true;
                }
                // nếu không có bản ghi nào tồn tại
                if (sotang != 0)
                {
                    hienthi = new Entities.SoDuCongNo[sotang];
                    for (int i = 0; i < sotang; i++)
                    {
                        hienthi[i] = new Entities.SoDuCongNo("", sq[i].MaDoiTuong, sq[i].TenDoiTuong, sq[i].DiaChi, sq[i].SoDuDauKy);
                    }

                }
                else
                {
                    hienthi = new Entities.SoDuCongNo[0];
                    dtgvcongno.DataSource = hienthi;
                    return;
                }
                dtgvcongno.DataSource = hienthi;
                new Common.Utilities().CountDatagridview(dtgvcongno);
            }
            catch
            {
            }
            finally
            {
                fix();
            }
        }

        public void fix()
        {
            try
            {
                // nếu null thì gán giá trị
                if (hienthi == null)
                {
                    dtgvcongno.DataSource = new Entities.SoDuSoQuy[0];
                    return;
                }
                dtgvcongno.DataSource = hienthi;
            }
            catch
            {
            }
            finally
            {
                for (int i = 0; i < dtgvcongno.ColumnCount; i++)
                {
                    dtgvcongno.Columns[i].Visible = false;
                }
                dtgvcongno.ReadOnly = true;
                new Common.Utilities().CountDatagridview(dtgvcongno);
                dtgvcongno.Columns["HanhDong"].Visible = true;
                dtgvcongno.Columns["MaDoiTuong"].Visible = true;
                dtgvcongno.Columns["TenDoiTuong"].Visible = true;
                dtgvcongno.Columns["DiaChi"].Visible = true;
                dtgvcongno.Columns["SoDuDauKy"].Visible = true;
                dtgvcongno.Columns["HanhDong"].HeaderText = "STT";
                dtgvcongno.Columns["MaDoiTuong"].HeaderText = "Mã Đối Tượng";
                dtgvcongno.Columns["TenDoiTuong"].HeaderText = "Tên Đối Tượng";
                dtgvcongno.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                dtgvcongno.Columns["SoDuDauKy"].HeaderText = "Số Dư Đầu Kỳ";
                dtgvcongno.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgvcongno.AllowUserToAddRows = false;
                dtgvcongno.AllowUserToDeleteRows = false;
                dtgvcongno.AllowUserToResizeRows = false;
                dtgvcongno.RowHeadersVisible = false;
                this.Focus(); this.WindowState = FormWindowState.Maximized;
            }
        }
        double sono = 0;
        private void tsslma_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F4)
                {
                    if (cbbdoituong.SelectedIndex == 0)
                    {
                        frmTimKH a = new frmTimKH("PhieuTTCuaKH");
                        a.ShowDialog();
                        if (frmTimKH.drvr != null)
                        {
                            tsslma.Text = frmTimKH.drvr.Cells["MaKH"].Value.ToString();
                            tsslten.Text = frmTimKH.drvr.Cells["Ten"].Value.ToString();
                            tssldiachi.Text = frmTimKH.drvr.Cells["DiaChi"].Value.ToString();
                            sono = Convert.ToDouble(frmTimKH.drvr.Cells["DuNo"].Value.ToString());
                            tsslsodudauky.Focus();
                            frmTimKH.drvr = null;
                        }
                    }
                    else
                    {
                        frmTimNCC tkh = new frmTimNCC("PhieuTTNCC");
                        tkh.ShowDialog();
                        if (frmTimNCC.drvr != null)
                        {
                            tsslma.Text = frmTimNCC.drvr.Cells["MaNhaCungCap"].Value.ToString();
                            tsslten.Text = frmTimNCC.drvr.Cells["TenNhaCungCap"].Value.ToString();
                            tssldiachi.Text = frmTimNCC.drvr.Cells["DiaChi"].Value.ToString();
                            sono = Convert.ToDouble(frmTimKH.drvr.Cells["DuNo"].Value.ToString());
                            tsslsodudauky.Focus();
                            frmTimNCC.drvr = null;
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void tsslma_Click(object sender, EventArgs e)
        {
            tssldiachi.Text = tsslma.Text = tsslten.Text = "";
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
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

        private void tsslsodudauky_TextChanged(object sender, EventArgs e)
        {
        }

        public bool CheckDataGridViewInsert()
        {
            if (tsslma.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã đối tượng trước khi thêm", "Hệ thống cảnh báo");
                tsslma.Focus();
                return false;
            }
            if (tsslten.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập đối tượng", "Hệ thống cảnh báo");
                tsslma.Focus();
                return false;
            }
            if (dtgvcongno.RowCount != 0)
            {

                for (int i = 0; i < dtgvcongno.RowCount; i++)
                {
                    if (dtgvcongno["MaDoiTuong", i].Value.ToString() == tsslma.Text)
                    {
                        MessageBox.Show("Đối tượng đã tồn tại - không thể nhập thêm", "Hệ thống cảnh báo");
                        tsslma.Focus();
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return true;
            }
        }
        public bool UpdateDuNoNCC(Entities.NhaCungCap ctkhthdn)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "NhaCungCap", ctkhthdn);
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                return kt;
            }
            catch
            {
                return false;
            }
            finally
            {


            }
        }
        /// <summary>
        /// update dư nợ
        /// </summary>
        /// <param name="ctkhthdn"></param>
        public bool UpdateDuNo(Entities.KhachHang ctkhthdn)
        {
            try
            {
                cl = new Server_Client.Client();
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                clientstrem = cl.SerializeObj(this.client1, "KhachHang", ctkhthdn);
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                return kt;
            }
            catch
            {
                return false;
            }
            finally
            {


            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                double.Parse(tsslsodudauky.Text);
            }
            catch
            {
                MessageBox.Show("Số dư đầu kỳ không được nhập ký tự", "Hệ thống cảnh báo");
                tsslsodudauky.Focus();
                return;
            }
            try
            {
                // kiểm tra giá trị trong dtgv
                if (CheckDataGridViewInsert() == true)
                {
                    string month1 = datesv.Month.ToString();
                    //nếu tháng hiện tại không = tháng đang xử lý
                    if (month1 != month)
                    {
                        MessageBox.Show("Không phải kỳ hiện tại - xin kiểm tra lại", "Hệ thống cảnh báo");
                        return;
                    }

                    cl = new Server_Client.Client();
                    // gán TCPclient
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    // khởi tạo biến truyền vào với hàm khởi tạo
                    Entities.SoDuCongNo[] pt = new Entities.SoDuCongNo[1];
                    pt[0] = new Entities.SoDuCongNo("Select");
                    // khởi tạo mảng đối tượng để hứng giá trị
                    clientstrem = cl.SerializeHepper(this.client1, "CongNo", pt);
                    // đổ mảng đối tượng vào datagripview       
                    hienthi = (Entities.SoDuCongNo[])cl.DeserializeHepper1(clientstrem, hienthi);
                    // nếu obj khác null
                    if (hienthi != null)
                    {
                        for (int i = 0; i < hienthi.Length; i++)
                        {
                            string monthkytruoc = (Convert.ToInt32(month) - 1).ToString();
                            string mm = hienthi[i].NgayKetChuyen.Month.ToString();
                            // kiểm tra kỳ trước có tồn tại số dư hay không
                            if (mm == monthkytruoc && hienthi[i].MaDoiTuong == tsslma.Text)
                            {
                                MessageBox.Show("Số dư đầu kỳ là kết chuyển từ kỳ trước - không thể thay đổi", "Hệ thống cảnh báo");
                                return;
                            }
                        }
                    }
                    //nếu không tồn tại số dư kỳ trước
                    try
                    {
                        bool loaidt = false;
                        if (cbbdoituong.SelectedIndex == 0)
                            loaidt = false;
                        else
                            loaidt = true;

                        string masd = ProID("SoDuCongNo");
                        cl = new Server_Client.Client();
                        // gán TCPclient
                        this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                        // khởi tạo biến truyền vào với hàm khởi tạo
                        Entities.SoDuCongNo[] pt1 = new Entities.SoDuCongNo[1];
                        pt1[0] = new Entities.SoDuCongNo("Insert", 0, masd, tsslma.Text, tsslten.Text, tssldiachi.Text, tsslsodudauky.Text, datesv, "0", loaidt, false);
                        // khởi tạo mảng đối tượng để hứng giá trị
                        clientstrem = cl.SerializeHepper(this.client1, "CongNo", pt1);
                        // đổ mảng đối tượng vào datagripview       
                        bool kt = false;
                        kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                        if (kt == true)
                        {
                            
                            if (cbbdoituong.SelectedIndex == 0)
                            {
                                Entities.KhachHang kh = new Entities.KhachHang("UpdateDuNo", tsslma.Text, tsslsodudauky.Text);
                                UpdateDuNo(kh);
                            }
                            else
                            {
                                Entities.NhaCungCap kh = new Entities.NhaCungCap("UpdateDuNoNCC", tsslma.Text, tsslsodudauky.Text);
                                UpdateDuNoNCC(kh);
                            }
                            tsslsodudauky.Text = tsslten.Text = tssldiachi.Text = "";
                            tsslma.Text = "<F4>-Tra cứu";
                            SelectData();
                            tsslma.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Thêm số dư đầu kỳ thất bại - xin thử lại sau","Hệ thống cảnh báo");
                            return;
                        }
                    }
                    catch
                    {
                    }

                }
            }
            catch
            {
            }
        }

        public string ProID(string tenBang)
        {
            try
            {
                string idnew;
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.LayID lid = new Entities.LayID();
                clientstrem = cl.SerializeObj(this.client1, "LayID", lid1);
                // đổ mảng đối tượng vào datagripview       
                lid = (Entities.LayID)cl.DeserializeHepper(clientstrem, hienthi);
                if (lid == null)
                    return "SDCN_0001";
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
                return idnew;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private void cbbdoituong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                month = cbbthang.Text;
                year = cbbnam.Text;
                SelectData();
            }
            catch
            {
            }
        }

        private void cbbthang_SelectedIndexChanged(object sender, EventArgs e)
        {
            month = cbbthang.Text;
            year = cbbnam.Text;
            SelectData();
        }

        private void cbbnam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                month = cbbthang.Text;
                year = cbbnam.Text;
                SelectData();
            }
            catch
            {
            }
        }
        int i = 0;

        string maNCCDELETE0 = "";
        public bool DeleteCongNo()
        {
            try
            {
                string maXoa = "";
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.SoDuCongNo[] pt = new Entities.SoDuCongNo[1];
                foreach (Entities.SoDuCongNo item in this.hienthi)
                {
                    if (item.MaDoiTuong.Equals(maNCCDELETE0))
                    {
                        maXoa = item.MaSoDuCongNo;
                    }   
                }
                if (maXoa.Equals(""))
                {
                    pt[0] = new Entities.SoDuCongNo("Delete", ma);
                }
                else
                {
                    pt[0] = new Entities.SoDuCongNo("Delete", maXoa);
                }
                // khởi tạo mảng đối tượng để hứng giá trị
                clientstrem = cl.SerializeHepper(this.client1, "CongNo", pt);
                bool kt = false;
                kt = (bool)cl.DeserializeHepper(clientstrem, kt);
                if (kt == true)
                {
                    SelectData();
                }
                return kt;
            }
            catch
            {
                return false;
            }
        }

        private void tssldong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                    this.Close();
            }
        }
        private void dtgvcongno_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            this.maNCCDELETE0 = dtgvcongno[3, e.RowIndex].Value.ToString();
            //string maNCCDELETE2 = dtgvcongno[2, e.RowIndex].Value.ToString();
            if (i < 0)
                return;
            try
            {
                string month1 = datesv.Month.ToString();
                // kiểm tra tháng hiên tại và tháng được chọn
                if (month1 != month)
                {
                    MessageBox.Show("Không phải kỳ hiện tại", "Hệ thống cảnh báo");
                    return;
                }

                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.SoDuCongNo[] pt = new Entities.SoDuCongNo[1];
                pt[0] = new Entities.SoDuCongNo("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                clientstrem = cl.SerializeHepper(this.client1, "CongNo", pt);
                // đổ mảng đối tượng vào datagripview       
                hienthi = (Entities.SoDuCongNo[])cl.DeserializeHepper1(clientstrem, hienthi);
                // nếu obj khác null
                if (hienthi != null)
                {
                    for (int j = 0; j < hienthi.Length; j++)
                    {
                        string monthkytruoc = (Convert.ToInt32(month) - 1).ToString();
                        string mm = hienthi[j].NgayKetChuyen.Month.ToString();
                        // kiểm tra kỳ trước của tháng đang chọn
                        if (mm == monthkytruoc)
                        {
                            MessageBox.Show("Số dư đầu kỳ là kết chuyển từ kỳ trước - không thể thay đổi", "Hệ thống cảnh báo");
                            SelectData();
                            return;
                        }
                    }
                }
                if (MessageBox.Show("Bạn chắc chắn muốn xóa không?", "Hệ thống cảnh báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {

                    // nếu kỳ trc không tồn tại
                    tsslma.Text = dtgvcongno["MaDoiTuong", i].Value.ToString();
                    tsslten.Text = dtgvcongno["TenDoiTuong", i].Value.ToString();
                    tssldiachi.Text = dtgvcongno["DiaChi", i].Value.ToString();
                    tsslsodudauky.Text = dtgvcongno["SoDuDauKy", i].Value.ToString();
                    sono = Convert.ToDouble(dtgvcongno["SoDuDauKy", i].Value.ToString());
                    if (dtgvcongno.RowCount >= 1)
                    {
                        if (DeleteCongNo())
                        {
                            if (cbbdoituong.SelectedIndex == 0)
                            {
                                Entities.KhachHang kh = new Entities.KhachHang("UpdateDuNoKH", tsslma.Text, sono.ToString());
                                UpdateDuNo(kh);
                            }
                            else
                            {
                                Entities.NhaCungCap kh = new Entities.NhaCungCap("UpdateDuNo", tsslma.Text, sono.ToString());
                                UpdateDuNoNCC(kh);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Xóa thất bại - xin thử lại sau", "Hệ thống cảnh báo");
                            return;
                        }
                    }
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

        private void tsslnap_Click(object sender, EventArgs e)
        {
            try
            {
                month = cbbthang.Text;
                year = cbbnam.Text;
                SelectData();
            }
            catch
            {
            }
        }

        private void tsslsodudauky_Click(object sender, EventArgs e)
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

        private void tsslsodudauky_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                toolStripButton1_Click(sender, e);
            }
        }
    }
}
