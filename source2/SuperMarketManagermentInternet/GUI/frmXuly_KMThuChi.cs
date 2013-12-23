using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Entities;

namespace GUI
{
    public partial class frmXuly_KMThuChi : Form
    {
        public frmXuly_KMThuChi()
        {
            InitializeComponent();
        }

        #region Khai Báo

        private string maKhoanMuc;
        private string tenKhoanMuc;
        private bool loaiKM;
        private string doiTuong;
        private string noTK;
        private string coTK;
        private string ghiChu;
        public TcpClient client1;
        public NetworkStream clientstream;
        public string kt;
        Server_Client.Client cl;
        TKKeToan tk;
        #endregion

        public frmXuly_KMThuChi(string hanhdong, DataGridViewRow dgvr)
        {
            InitializeComponent();
            if (hanhdong =="Them")
            {
                KhoiTaoThem(dgvr);
                txtID.ReadOnly = false;
                ShowCombox_Co("");
                ShowCombox_NoTK("");
            }
            else
                if (hanhdong=="Sua")
                {
                    KhoiTaoSua(dgvr);
                }

        }

        #region show combobox NoTK, coTK
        public void ShowCombox_Co(string co)
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            tk = new TKKeToan("Select");
            clientstream = cl.SerializeObj(this.client1, "TKKeToan", tk);

            TKKeToan[] tk1 = new TKKeToan[1];
            tk1[0] = new TKKeToan(1, "a", "a", "a", "a", false);
            tk1 = (TKKeToan[])cl.DeserializeHepper1(clientstream, tk1);

           
        //    cbbCoTK.DataSource = tk1;
        //    cbbCoTK.DisplayMember = "MaTKKeToan";
           
        //    if (co == "")
        //    {
        //        cbbCoTK.SelectedIndex = -1;
        //    }
        //    else
        //        if (true)
        //        {


        //            for (int i = 0; i < tk1.Length; i++)
        //            {
        //                if (tk1[i].MaTKKeToan == co)
        //                {
        //                    cbbCoTK.SelectedIndex = i;
        //                    break;
        //                }
        //            }
        //        }
        }

        public void ShowCombox_NoTK(string no)
        {
            Server_Client.Client cl = new Server_Client.Client();
            this.client1 = cl.Connect(Luu.IP, Luu.Ports);
            tk = new TKKeToan("Select");
            clientstream = cl.SerializeObj(this.client1, "TKKeToan", tk);

            TKKeToan[] tk1 = new TKKeToan[1];
            tk1[0] = new TKKeToan(1, "a", "a", "a", "a", false);
            tk1 = (TKKeToan[])cl.DeserializeHepper1(clientstream, tk1);

            //cbbNoTK.DataSource = tk1;
            //cbbNoTK.DisplayMember = "MaTKKeToan";
            
            //if (no == "")
            //{
            //    cbbNoTK.SelectedIndex = -1;
            //}
            //else
            //    if (no != "")
            //    {


            //        for (int i = 0; i < tk1.Length; i++)
            //        {

            //            if (tk1[i].MaTKKeToan == no)
            //            {
            //                cbbNoTK.SelectedIndex = i;
            //                break;
            //            }
            //        }
            //    }
            
        }
        #endregion

        #region Khởi Tạo
        public void KhoiTaoThem(DataGridViewRow dgvr)
        {
            tsslSua.Enabled = false;
            txtmaKM.Text = LayID("KMThuChi");
            txtID.Visible = false;
            label1.Visible = false;
            this.Text = "Thêm Khoản Mục Thu Chi";
        }

        public void KhoiTaoSua(DataGridViewRow dgvr)
        {
            tsslThem.Enabled = false;
            txtID.Text = dgvr.Cells[1].Value.ToString();
            maKhoanMuc = txtmaKM.Text = dgvr.Cells[2].Value.ToString();
            tenKhoanMuc = txttenKM.Text = dgvr.Cells[3].Value.ToString();

            loaiKM = (bool) dgvr.Cells[4].Value;
            if (loaiKM)
            {
                cbbLoaiKhoanMuc.SelectedIndex = 0;
            }
            else
            {
                cbbLoaiKhoanMuc.SelectedIndex = 1;
            }
            doiTuong = dgvr.Cells[5].Value.ToString();
            noTK= dgvr.Cells[6].Value.ToString();
            coTK = dgvr.Cells[7].Value.ToString();
            ghiChu = txtghichu.Text = dgvr.Cells[8].Value.ToString();
            this.Text = "Sửa Khoản Mục Thu Chi ";
            ShowCombox_Co(coTK);
            ShowCombox_NoTK(noTK);

            switch (doiTuong)
            {
                case "Khach Hang":
                    {
                        cbbdoiTuong.SelectedIndex = 0;
                        break;
                    }
                case "Nha Cung Cap":
                    {
                        cbbdoiTuong.SelectedIndex = 1;
                        break;
                    }
                case "Nhan Vien":
                    {
                        cbbdoiTuong.SelectedIndex = 2;
                        break;
                    }
            }
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
            if (lid!=null)
            {
                Common.Utilities a = new Common.Utilities();
                idnew = a.ProcessID(lid.ID);    
            }
            else
            {
                if (lid==null)
                {
                    idnew = "KM_0001";
                }
            }
                        
            
            return idnew;
        }
        #endregion

        #region check() check conflict
        public string Check(Entities.KMThuChi kmtc)
        {
            string gt = "ok";

            if (tenKhoanMuc != kmtc.TenKhoanMuc)
            {
                tenKhoanMuc = txttenKM.Text = kmtc.TenKhoanMuc;
                gt = "ko";
            }
            if (loaiKM != kmtc.LoaiKM)
            {

                loaiKM = kmtc.LoaiKM;
               
                if (loaiKM)
                {
                    cbbLoaiKhoanMuc.SelectedIndex = 0;
                }
                else
                {
                    cbbLoaiKhoanMuc.SelectedIndex = 1;
                }
                gt = "ko";
            }
            if (doiTuong != kmtc.DoiTuong)
            {
                doiTuong = cbbdoiTuong.Text = kmtc.DoiTuong;
                gt = "ko";
            }
            //if (noTK != kmtc.NoTK)
            //{
            //    noTK = cbbNoTK.Text = kmtc.NoTK;
            //    gt = "ko";
            //}
            //if (coTK != kmtc.CoTK)
            //{
            //    coTK = cbbCoTK.Text = kmtc.CoTK;
            //    gt = "ko";
            //}
            if (ghiChu != kmtc.GhiChu)
            {
                ghiChu = txtghichu.Text = kmtc.GhiChu;
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
        Entities.KMThuChi[] km1;
        public void CheckConflictUpdate()
        {
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.KMThuChi pt = new Entities.KMThuChi("Select", 1,"","","");
                // khởi tạo mảng đối tượng để hứng giá trị
                km1 = new Entities.KMThuChi[1];
                clientstream = cl.SerializeObj(this.client1, "KMThuChi", pt);
                // đổ mảng đối tượng vào datagripview       
                km1 = (Entities.KMThuChi[])cl.DeserializeHepper1(clientstream, km1);
                if (km1 != null)
                {
                    for (int j = 0; j < km1.Length; j++)
                    {
                        if (km1[j].MaKhoanMuc == maKhoanMuc)
                        {
                            kt = Check(km1[j]);
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
        public bool Validate()
        {

            //if (cbbNoTK.DataSource==null && cbbCoTK.DataSource==null)
            //{
                
            //    MessageBox.Show("Không Có Dữ liệu trong Cơ Sở Dữ liệu - Liên Hệ Nhà Quản Trị");
            //    cbbCoTK.Focus();
            //    return false;
            //}

            if (txttenKM.Text.Length == 0)
            {
                
                MessageBox.Show("Tên Khoản Mục không được để trống", "Hệ Thống Cảnh Báo");
                txttenKM.Focus();
                return false;
            }
            if (cbbdoiTuong.Text.Length == 0)
            {
                MessageBox.Show("Tên Đối Tượng không được để trống", "Hệ Thống Cảnh Báo");
                cbbdoiTuong.Focus();
                return false;
            }
            //if (cbbNoTK.Text.Length == 0)
            //{
            //    MessageBox.Show(" Nợ Tài Khoản không được để trống", "Hệ Thống Cảnh Báo");
            //    cbbNoTK.Focus();
            //    return false;
            //}
            //if (cbbCoTK.Text.Length == 0)
            //{
            //    MessageBox.Show("Có Tài Khoản không được để trống", "Hệ Thống Cảnh Báo");
            //    cbbCoTK.Focus();
            //    return false;
            //}

            return true;
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
                Entities.KMThuChi pt = new Entities.KMThuChi("Select", 1,"","","");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.KMThuChi[] pt1 = new Entities.KMThuChi[1];
                clientstream = cl.SerializeObj(this.client1, "KMThuChi", pt);
                // đổ mảng đối tượng vào datagripview       
                pt1 = (Entities.KMThuChi[])cl.DeserializeHepper1(clientstream, pt1);
                if (pt1 != null)
                {
                    for (int j = 0; j < pt1.Length; j++)
                    {
                        if (pt1[j].MaKhoanMuc == txtmaKM.Text)
                        {
                            MessageBox.Show("cập nhật mã Khoản Mục - kiểm tra lại để insert");
                            kt = "ko";
                            txtmaKM.Text = LayID("KMThuChi");
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

        #region sự kiên click của nút đóng
        private void tsslDong_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
            {
                if (giatri == System.Windows.Forms.DialogResult.Yes)
                {
                    frmQuanlyKMthuchi.KiemTra = "close";
                    this.Close();
                }
                else
                { }
            }
        }
        #endregion

        #region Sự kiện click của nút sửa
        private void tsslSua_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                CheckConflictUpdate();
                if (kt == "ok")
                {
                    Server_Client.Client cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    string dt = "";
                    switch (cbbdoiTuong.Text)
                    {
                        case "Khách Hàng":
                            {
                                dt = "Khach Hang";
                                break;
                            }
                        case "Nhà Cung Cấp":
                            {
                                dt = "Nha Cung Cap";
                                break;
                            }
                        case "Nhân Viên":
                            {
                                dt = "Nhan Vien";
                                break;
                            }
                    }
                    bool LoaiKhoanMuc;
                    if (cbbLoaiKhoanMuc.SelectedIndex == 0)
                    {
                        LoaiKhoanMuc = true;
                    }
                    else
                    {
                        LoaiKhoanMuc = false;
                    }

                    Entities.KMThuChi pb = new Entities.KMThuChi("Update", Convert.ToInt32(txtID.Text), txtmaKM.Text, txttenKM.Text, LoaiKhoanMuc, dt, "", "", txtghichu.Text, false, Common.Utilities.User.NhanVienID, Common.Utilities.User.TenDangNhap);
                    clientstream = cl.SerializeObj(this.client1, "KMThuChi", pb);

                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(clientstream, msg);

                    if (msg != 1)
                    {
                        MessageBox.Show("Update That Bai");
                    }
                    
                    tenKhoanMuc = txttenKM.Text;
                  
                 
                   
                     loaiKM = LoaiKhoanMuc;
                 
                    doiTuong = dt ;
                    //noTK = cbbNoTK.Text;
                    //coTK = cbbCoTK.Text;
                    ghiChu = txtghichu.Text;
                    this.Close();
                }
                else
                    if (kt == "null")
                    {
                        MessageBox.Show("Bản Ghi đã bị xóa trước khi cập nhật! Vui lòng thao tác lại !");
                        //tabControl1.Enabled = false;
                        this.Close();
                    }
               
            }
        }
        #endregion

        #region Sự kiện click của nút Thêm
        private void tsslThem_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                CheckConflictInsert();
                if (kt == "ok")
                {
                    cl = new Server_Client.Client();
                    this.client1 = cl.Connect(Luu.IP, Luu.Ports);
                    string dt="";
                    switch (cbbdoiTuong.Text)
                    {
                        case "Khách Hàng":
                            {
                                dt = "Khach Hang";
                                break;
                            }
                        case "Nhà Cung Cấp":
                            {
                                dt = "Nha Cung Cap";
                                break;
                            }
                        case "Nhân Viên":
                            {
                                dt = "Nhan Vien";
                                break;
                            }
                    }
                    bool LoaiKhoanMuc;
                    if (cbbLoaiKhoanMuc.SelectedIndex == 0)
                    {
                        LoaiKhoanMuc = true;
                    }
                    else
                    {
                        LoaiKhoanMuc = false;
                    }
                    Entities.KMThuChi pb = new Entities.KMThuChi("Insert", 1, txtmaKM.Text, txttenKM.Text,LoaiKhoanMuc, dt, "", "", txtghichu.Text, false,Common.Utilities.User.NhanVienID,Common.Utilities.User.TenDangNhap);
                    clientstream = cl.SerializeObj(this.client1, "KMThuChi", pb);

                    int msg = 0;
                    msg = (int)cl.DeserializeHepper(clientstream, msg);

                    if (msg !=1)
                    {
                        MessageBox.Show("Insert That Bai");
                    }
                    txttenKM.Text = "";
                    txtghichu.Text = "";
                    cbbdoiTuong.SelectedIndex = -1;
                    //cbbNoTK.SelectedIndex = -1;
                    //cbbCoTK.SelectedIndex = -1;
                    txtmaKM.Text = LayID("KMThuChi");
                    frmQuanlyKMthuchi.KiemTra = "insert";
                    this.Close();
                }
            }
        }
        #endregion

        private void frmXuly_KMThuChi_Load(object sender, EventArgs e)
        {
            txtmaKM.Focus();
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
