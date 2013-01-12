using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Windows.Controls;
using Entities;

namespace GUI
{
    public partial class frmXuly_NhanVien : Form
    {
        public frmXuly_NhanVien()
        {
            InitializeComponent();
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
        #region Khai Báo
        
        string maNhanVien;
        string tenNhanVien;
        string maPhongBan;
        string dCThuongTru;
        string dCTamTru;
        string dienThoaiCD;
        string dienThoaiDD;
        string email;
        string cMND;
        string ngayCap;
        string noiCap;
        string ngaySinh;
        string ghiChu;
        public TcpClient client1;
        public NetworkStream clientstream;
        public string kt;
        Server_Client.Client cl;
        #endregion

        public frmXuly_NhanVien(string hanhdong, DataGridViewRow dgvr)
        {
            InitializeComponent();
            if (hanhdong =="Them")
            {
                showCombobox_PhongBan();
                KhoiTaoThem(dgvr);
            }
            else
                if (hanhdong=="Sua")
                {
                    showCombobox_PhongBan();
                    KhoiTaoSua(dgvr);
                }

            
        }



        #region check() check conflict
        public string Check(Entities.NhanVien nv)
        {
            string gt = "ok";
            string ngaycapnew = xulyNgay(nv.NgayCap);
            string ngaysinhnew = xulyNgay(nv.NgaySinh);
            if (ngayCap != ngaycapnew)
            {
                ngayCap = txtngaycap.Text = ngaycapnew;
                gt = "ko";
            }
            if (ngaySinh != ngaysinhnew)
            {
                ngaySinh = txtngaysinh.Text = ngaysinhnew;
                gt = "ko";
            }

            if (tenNhanVien != nv.TenNhanVien)
            {
                tenNhanVien = txttennv.Text = nv.TenNhanVien;
                gt = "ko";
            }
            if (maPhongBan != nv.MaPhongBan)
            {
                maPhongBan = cbbmapb.Text = nv.MaPhongBan;
                gt = "ko";
            }
            if (dCThuongTru != nv.DCThuongTru)
            {
                dCThuongTru = txtdcthuongtru.Text = nv.DCThuongTru;
                gt = "ko";
            }
            if (dCTamTru != nv.DCTamTru)
            {
                dCTamTru = txtdctamtru.Text = nv.DCTamTru;
                gt = "ko";
            }
            if (dienThoaiCD != nv.DienThoaiCD)
            {
                dienThoaiCD = txtdtcd.Text = nv.DienThoaiCD;
                gt = "ko";
            }
            if (dienThoaiDD != nv.DienThoaiDD)
            {
                dienThoaiDD = txtdtdd.Text = nv.DienThoaiDD;
                gt = "ko";
            }
            if (email != nv.Email)
            {
                email = txtemail.Text = nv.Email;
                gt = "ko";
            }
            if (cMND != nv.CMND)
            {
                cMND = txtcmnd.Text = nv.CMND;
                gt = "ko";
            }
            if (noiCap != nv.NoiCap)
            {
                noiCap = txtnoicap.Text = nv.NoiCap;
                gt = "ko";
            }
            if (ghiChu != nv.GhiChu)
            {
                ghiChu = txtghichu.Text = nv.GhiChu;
                gt = "ko";
            }

            if (gt == "ko")
            {
                MessageBox.Show("Dữ liệu đã có thay đổi trước, ấn ok để cập nhật lại.");
            }

            return gt;
        }
        #endregion

        #region Main check conflict update
        Entities.NhanVien[] nv1;
        public void CheckConflictUpdate()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.NhanVien pt = new Entities.NhanVien("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                nv1 = new Entities.NhanVien[1];
                clientstream = cl.SerializeObj(this.client1, "NhanVien", pt);
                // đổ mảng đối tượng vào datagripview       
                nv1 = (Entities.NhanVien[])cl.DeserializeHepper1(clientstream, nv1);
                if (nv1 != null)
                {
                    for (int j = 0; j < nv1.Length; j++)
                    {
                        if (nv1[j].MaNhanVien == maNhanVien)
                        {

                            kt = Check(nv1[j]);

                            break;
                        }
                        else
                            kt = "null";
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        #region validate

        public string checkDateTime(string datetime)
        {

            if (datetime.Length < 10)
            {
                return "Ngày Tháng năm phải nhập đầy đủ";
            }
            string dd = datetime.Substring(0, 2);
            string mm = datetime.Substring(3, 2);
            string yyyy = datetime.Substring(6, 4);
            if ((int.Parse(dd) > 31) || (int.Parse(dd) < 1))
            {
                return "Ngày phải nhỏ hơn 31 và lớn hơn 0";
            }
            if ((int.Parse(mm) > 12) || (int.Parse(mm) < 1))
            {
                return "Tháng phải nhỏ hơn 12 và lớn hơn 0";
            }
            if ((int.Parse(yyyy) > 9999) || (int.Parse(yyyy) < 1753))
            {
                return "Năm phải nhỏ hơn 9999 và lớn hơn 1753";
            }
            return "true";
        }

        public bool Validate()
        {
            if (cbbmapb.DataSource==null)
            {
                MessageBox.Show("Dữ Liệu về Phòng Ban Chưa Có trong cơ sở dữ liệu - Liên Hệ Nhà Quản Trị");
                cbbmapb.Focus();
                return false;
            }

            if (txttennv.Text.Length == 0)
            {
                MessageBox.Show("Tên nhân viên không được để trống", "Hệ Thống Cảnh Báo");
                txttennv.Focus();
                return false;
            }
            if (checkDateTime(txtngaysinh.Text) != "true")
            {
                MessageBox.Show(checkDateTime(txtngaysinh.Text), "Hệ Thống Cảnh Báo");
                txtngaysinh.Focus();
                return false;
            }
            if (txtcmnd.Text.Length == 0)
            {
                MessageBox.Show("Số Chứng Minh nhân dân không được để trống", "Hệ Thống Cảnh Báo");
                txtcmnd.Focus();
                return false;
            }
            if (checkDateTime(txtngaycap.Text) != "true")
            {
                MessageBox.Show(checkDateTime(txtngaycap.Text), "Hệ Thống Cảnh Báo");
                txtngaycap.Focus();
                return false;
            }

            if (txtngaysinh.Text != null && txtngaysinh.Text != null)
            {
                string kt3 = "ok";
                try
                {
                    xulyNgayInsert(txtngaysinh.Text);
                }
                catch
                {
                    kt3 = "Lỗi định dạng ngày";
                }
                if (kt3 != "ok")
                {
                    MessageBox.Show("Lỗi Định Dạng Ngày Sinh", "hệ thống cảnh báo");
                    txtngaysinh.Focus();
                    return false;
                }

                kt3 = "ok";
                try
                {
                    xulyNgayInsert(txtngaycap.Text);
                }
                catch
                {
                    kt3 = "Lỗi định dạng ngày";
                }
                if (kt3 != "ok")
                {
                    MessageBox.Show("Lỗi Định Dạng Ngày Ngày cấp", "hệ thống cảnh báo");
                    txtngaycap.Focus();
                    return false;
                }

                if (xulyNgayInsert(txtngaysinh.Text) >= xulyNgayInsert(txtngaycap.Text))
                {
                    MessageBox.Show("Ngày Sinh phải nhỏ hơn ngày Cấp", "hệ thống cảnh báo");
                    txtngaycap.Focus();
                    return false;
                }
            }

            if (txtnoicap.Text.Length == 0)
            {
                MessageBox.Show("Nơi cấp không được để trống", "Hệ Thống Cảnh Báo");
                txtnoicap.Focus();
                return false;
            }
            if (cbbmapb.Text.Length == 0)
            {
                MessageBox.Show("Mã Phòng ban không được để trống", "Hệ Thống Cảnh Báo");
                cbbmapb.Focus();
                return false;
            }
            if ((txtdtdd.Text.Length == 0) && (txtdtcd.Text.Length == 0) && (txtemail.Text.Length == 0))
            {
                MessageBox.Show("Điện thoại và email liên lạc không được để trống(Lưu ý: Chỉ cần điền 1 trong 3 thông tin!!)", "Hệ Thống Cảnh Báo");
                txtdtdd.Focus();
                return false;
            }
            return true;
        }
        #endregion 

        #region Khởi Tạo
        public void KhoiTaoThem(DataGridViewRow dgvr)
        {
            tsslSua.Enabled = false;
            txtmanv.Text = LayID("NhanVien");
            txtID.Visible = false;
            label1.Visible = false;
            tabPage2.Enabled = false;
            this.Text = "Thêm Nhân Viên";
        }

        public void KhoiTaoSua(DataGridViewRow dgvr)
        {
            tsslThem.Enabled = false;
            txtID.Text = dgvr.Cells[4].Value.ToString();
            maNhanVien= txtmanv.Text = dgvr.Cells[5].Value.ToString();
            tenNhanVien= txttennv.Text = dgvr.Cells[6].Value.ToString();
            maPhongBan= dgvr.Cells[7].Value.ToString();
            cbbmapb.SelectedIndex = cbbmaPB_sua(maPhongBan);
            dCThuongTru= txtdcthuongtru.Text = dgvr.Cells[9].Value.ToString();
            dCTamTru= txtdctamtru.Text = dgvr.Cells[10].Value.ToString();
            dienThoaiCD= txtdtcd.Text = dgvr.Cells[11].Value.ToString();
            dienThoaiDD= txtdtdd.Text = dgvr.Cells[12].Value.ToString();
            email= txtemail.Text = dgvr.Cells[13].Value.ToString();
            cMND= txtcmnd.Text = dgvr.Cells[14].Value.ToString();
            ngayCap= txtngaycap.Text = xulyNgay(Convert.ToDateTime(dgvr.Cells[15].Value.ToString()));
            noiCap = txtnoicap.Text = dgvr.Cells[16].Value.ToString();
            ngaySinh= txtngaysinh.Text = xulyNgay(Convert.ToDateTime(dgvr.Cells[17].Value.ToString()));
            ghiChu = txtghichu.Text = dgvr.Cells[18].Value.ToString();
            this.Text = "Sửa Nhân Viên";
        }
        #endregion

        public int cbbmaPB_sua(string maPB)
        {
            Entities.PhongBan[] pb = (Entities.PhongBan[])cbbmapb.DataSource;
            for (int i = 0; i < pb.Length; i++)
            {
                if (pb[i].MaPhongBan==maPB)
                {
                    return i;
                }
            }
            return -1;
        }


        #region xử lý ngày

        public string xulyNgay(DateTime dt)
        {
            string mk;
            string dd = dt.Day.ToString();
            if (dd.Length == 1)
            {
                dd = "0" + dd;
            }
            string mm = dt.Month.ToString();
            if (mm.Length == 1)
            {
                mm = "0" + mm;
            }
            string yyyy = dt.Year.ToString();

            mk = dd + "/" + mm + "/" + yyyy;

            return mk;
        }

        public DateTime xulyNgayInsert(string datetime)
        {
            DateTime mk;

            string dd = datetime.Substring(0, 2);
            string mm = datetime.Substring(3, 2);
            string yyyy = datetime.Substring(6, 4);

            if (dd.Length == 1)
            {
                dd = "0" + dd;
            }
            
            if (mm.Length == 1)
            {
                mm = "0" + mm;
            }
            
            mk =new DateTime(Convert.ToInt32(yyyy),Convert.ToInt32(mm),Convert.ToInt32(dd));

            return mk;
        }

        #endregion

        #region show combobox phongban
        PhongBan pb;
        public void showCombobox_PhongBan()
        {
            cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            pb = new PhongBan("Select");
            clientstream = cl.SerializeObj(this.client1, "PhongBan", pb);

            PhongBan[] pb1 = new PhongBan[1];
            pb1[0] = new PhongBan(1, "a", "a", "a", false);
            pb1 = (PhongBan[])cl.DeserializeHepper1(clientstream, pb1);

            cbbmapb.DataSource = pb1;
            cbbmapb.DisplayMember = "TenPhongBan";
        }
        #endregion

        #region LayID
        public string LayID(string tenBang)
        {
            string idnew="";
            cl = new Server_Client.Client();
            // gán TCPclient
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            // khởi tạo biến truyền vào với hàm khởi tạo
            Entities.LayID lid1 = new Entities.LayID("Select", tenBang);
            // khởi tạo mảng đối tượng để hứng giá trị
            Entities.LayID lid = new Entities.LayID();
            clientstream = cl.SerializeObj(this.client1, "LayID", lid1);
            // đổ mảng đối tượng vào datagripview       
            lid = (Entities.LayID)cl.DeserializeHepper(clientstream, lid1);
            if (lid != null)
            {
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);
            }
            else
            {
                if (lid == null)
                {
                    idnew = "NV_0001";
                }
            }
            return idnew;
        }
        #endregion

        #region check conflict insert 
        public void CheckConflictInsert()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.NhanVien pt = new Entities.NhanVien("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.NhanVien[] pt1 = new Entities.NhanVien[1];
                clientstream = cl.SerializeObj(this.client1, "NhanVien", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.NhanVien[])cl.DeserializeHepper1(clientstream, pt1);
                if (pt1 != null)
                {
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        if (pt1[j].MaNhanVien == txtmanv.Text)
                        {
                            MessageBox.Show("cập nhật mã Nhân Viên - kiểm tra lại để insert");
                            kt = "ko";
                            txtmanv.Text = LayID("NhanVien");
                            break;
                        }
                        else
                            kt = "ok";
                    }
                }
                else
                    kt = "ok";
            }
            catch
            {
            }
        }
        #endregion

        private void tsslDong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    frmQuanlynhanvien.KiemTra = "close";
                    this.Close();
                }
                else
                { }
            }
        }

        private void tsslThem_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                CheckConflictInsert();

                if (kt == "ok")
                {
                    cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    PhongBan pb =(PhongBan) cbbmapb.SelectedItem;
                    Entities.NhanVien nv = new Entities.NhanVien("Insert", 1, txtmanv.Text, txttennv.Text, pb.MaPhongBan,"", txtdcthuongtru.Text, txtdctamtru.Text, txtdtcd.Text, txtdtdd.Text, txtemail.Text, txtcmnd.Text, xulyNgayInsert(txtngaycap.Text), txtnoicap.Text, xulyNgayInsert(txtngaysinh.Text), txtghichu.Text, false,Common.Utilities.User.NhanVienID,Common.Utilities.User.TenDangNhap);
                    clientstream = cl.SerializeObj(this.client1, "NhanVien", nv);
                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(clientstream, msg);
                    if (msg != 1)
                   
                        MessageBox.Show("Insert that bai");
                    txtmanv.Text = LayID("NhanVien");
                    txttennv.Text = "";
                    cbbmapb.Text = "";
                    txtdcthuongtru.Text = "";
                    txtdctamtru.Text = "";
                    txtdtcd.Text = "";
                    txtdtdd.Text = "";
                    txtemail.Text = "";
                    txtcmnd.Text = "";
                    txtngaycap.Text = "";
                    txtnoicap.Text = "";
                    txtngaysinh.Text = "";
                    txtghichu.Text = "";
                    cbbmapb.SelectedIndex = -1;
                    frmQuanlynhanvien.KiemTra = "insert";
                    this.Close();
                }
            }   
        }

        private void tsslSua_Click(object sender, EventArgs e)
        {

            if (Validate())
            {
                CheckConflictUpdate();
                if (kt == "ok")
                {
                    Server_Client.Client cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    PhongBan pb = (PhongBan)cbbmapb.SelectedItem;
                    Entities.NhanVien nv = new Entities.NhanVien("Update", Convert.ToInt32(txtID.Text), txtmanv.Text, txttennv.Text, pb.MaPhongBan, " ", txtdcthuongtru.Text, txtdctamtru.Text, txtdtcd.Text, txtdtdd.Text, txtemail.Text, txtcmnd.Text, xulyNgayInsert(txtngaycap.Text), txtnoicap.Text, xulyNgayInsert(txtngaysinh.Text), txtghichu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                    clientstream = cl.SerializeObj(this.client1, "NhanVien", nv);

                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(clientstream, msg);
                    if (msg != 1)
                        MessageBox.Show("Update that bai");

                    tenNhanVien = txttennv.Text;
                    maPhongBan = pb.MaPhongBan;
                    dCThuongTru = txtdcthuongtru.Text;
                    dCTamTru = txtdctamtru.Text ;
                    dienThoaiCD = txtdtcd.Text;
                    dienThoaiDD = txtdtdd.Text;
                    email = txtemail.Text;
                    cMND = txtcmnd.Text;
                    ngayCap = xulyNgay(xulyNgayInsert(txtngaycap.Text)); 
                    noiCap = txtnoicap.Text;
                    ngaySinh = xulyNgay(xulyNgayInsert(txtngaysinh.Text));
                    ghiChu = txtghichu.Text;
                    this.Close();
                }
                else
                    if (kt=="null")
                    {
                        MessageBox.Show("Bản Ghi đã bị xóa trước khi cập nhật! Vui lòng thao tác lại !");
                        this.Close();
                    }
            }
        }

        private void tcNhanVien_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!e.TabPage.Enabled)
            {
                e.Cancel = true;
            }
            else
                if (e.TabPageIndex==1)
                {
                    HienThiHoaDonBanHang();
                    FixHienThiHDBanHang();
                }
        }

        private void tcNhanVien_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        #region Giao Dịch Bán Hàng
        public void HienThiHoaDonBanHang()
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);

            Entities.HDBanHang nv = new Entities.HDBanHang("Select");
            clientstream = cl.SerializeObj(this.client1, "HDBanHang", nv);
            Entities.HDBanHang[] nv1 = new Entities.HDBanHang[1];
            nv1 = (HDBanHang[])cl.DeserializeHepper(clientstream, nv1);
            
            int count=0;
            if (nv1!=null)
            {
                for (int i = 0; i < nv1.Length; i++)
                {
                    if (nv1[i].MaNhanVien==txtmanv.Text)
                    {
                        count++;
                    }
                }    
            }
            Entities.HDBanHang [] hdbh= new Entities.HDBanHang [count];
           
            count = 0;
            if (nv1 != null)
            {
                for (int i = 0; i < nv1.Length; i++)
                {
                    if (nv1[i].MaNhanVien == txtmanv.Text)
                    {
                        hdbh[count] = nv1[i];
                        count++;
                    }
                }
            }
            dataGridView1.DataSource = hdbh;
        }

        #endregion

        private void rdbGiaoDich_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        public void FixHienThiHDBanHang()
        {
        
        
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ReadOnly = true;

            new Common.Utilities().CountDatagridview(dataGridView1);
            for (int j = 1; j < dataGridView1.ColumnCount; j++)
            {
                dataGridView1.Columns[j].Visible = false;
            }
            dataGridView1.RowHeadersVisible = false;
            
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[0].HeaderText = "STT";
            dataGridView1.Columns["MaHDBanHang"].Visible = true;
            dataGridView1.Columns["MaHDBanHang"].HeaderText = "Mã Đơn Hàng";
            dataGridView1.Columns["NgayBan"].Visible = true;
            dataGridView1.Columns["NgayBan"].HeaderText = "Ngày Bán";
            dataGridView1.Columns["LoaiHoaDon"].Visible = true;
            dataGridView1.Columns["LoaiHoaDon"].HeaderText = "Loại Hóa Đơn";
            dataGridView1.Columns["TongTienThanhToan"].Visible = true;
            dataGridView1.Columns["TongTienThanhToan"].HeaderText = "Tổng Thanh Toán";
           
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
        }

        private void frmXuly_NhanVien_Load(object sender, EventArgs e)
        {
            ActiveControl = txttennv;
            
        }
    }
}
