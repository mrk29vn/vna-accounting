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
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;

namespace GUI
{
    public partial class frmQuanLyMaVach : Form
    {
        Entities.ThongTinCongTy congTy;
        List<Entities.QuyDoiDonViTinh> _K = new List<Entities.QuyDoiDonViTinh>();
        ///////////////////////////////////////////////////MRK FIX
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
        //////////////////////////////////////////////////////////

        bool rdo()
        {
            if (rdoTV.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        string getTenRdo()
        {
            if (rdoTV.Checked)
            {
                return rdoTV.Text;
            }
            else
            {
                return rdoHH.Text;
            }
        }

        public frmQuanLyMaVach()
        {
            InitializeComponent();
            this.congTy = this.GetCongTy();

        }
        #region hungvv==============================================khoi tao=====================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;
        Entities.ThongTinMaVach mavach;


        /// <summary>
        /// 
        /// </summary>
        private void FixDatagridview()
        {
            try
            {
                dgvHangHoa.Columns[0].Visible = false;
                dgvHangHoa.Columns[1].Visible = false;
                dgvHangHoa.Columns[2].Visible = true;
                dgvHangHoa.Columns[3].Visible = true;
                dgvHangHoa.Columns[4].Visible = false;
                dgvHangHoa.Columns[5].Visible = false;
                dgvHangHoa.Columns[6].Visible = false;
                dgvHangHoa.Columns[7].Visible = true;

                dgvHangHoa.Columns[2].HeaderText = "Mã " + getTenRdo() + "";
                dgvHangHoa.Columns[3].HeaderText = "Tên " + getTenRdo() + "";
                dgvHangHoa.Columns[7].HeaderText = "Số lượng in";

                dgvHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHangHoa.Columns[2].Width = 100;
                dgvHangHoa.Columns[3].Width = 200;
                dgvHangHoa.Columns[7].Width = 100;
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        #endregion
        public bool CheckQuyen(string tenform, int quyen)
        {
            switch (quyen)
            {
                case 1:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenXem;
                        }
                        break;
                    }
                case 2:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenSua;
                        }
                        break;
                    }
                case 3:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenXoa;
                        }
                        break;
                    }
                case 4:
                    {
                        foreach (Entities.ChiTietQuyen item in frmDangNhap.CTQ)
                        {
                            if (item.TenForm.ToLower().Equals(tenform.ToLower()))
                                return item.QuyenThem;
                        }
                        break;
                    }
            }
            return true;
        }
        private void frmQuanLyMaVach_Load(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this.SelectData();
                    this._K = this.bangquydoidonvitinh();
                }
                catch (Exception)
                {
                }
                chkGenerateLabel.Checked = false;
                cbxLoaigiay.Items.Clear();
                this.cbxLoaigiay.Items.AddRange(new object[] { "Loại A5", "Loại 110", "Loại A4" });
                cbxLoaigiay.SelectedIndex = 0;
                //cbxLoaigiay.Enabled = false;
                btnLoadImage.Visible = false;
                Bitmap temp = new Bitmap(1, 1);
                temp.SetPixel(0, 0, this.BackColor);
                barcode.Image = (Image)temp;
                this.cbEncodeType.SelectedIndex = 0;
                this.cbBarcodeAlign.SelectedIndex = 0;
                this.cbLabelLocation.SelectedIndex = 0;
                this.cbRotateFlip.DataSource = System.Enum.GetNames(typeof(RotateFlipType));
                int i = 0;
                foreach (object o in cbRotateFlip.Items)
                {
                    if (o.ToString().Trim().ToLower() == "rotatenoneflipnone")
                        break;
                    i++;
                }
                this.cbRotateFlip.SelectedIndex = i;
                this.btnBackColor.BackColor = this.b.BackColor;
                this.btnForeColor.BackColor = this.b.ForeColor;
                Entities.ThongTinMaVach[] mv = new Entities.ThongTinMaVach[0];
                dgvHangHoa.DataSource = mv;
                FixDatagridview();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                if (dgvHangHoa.RowCount <= 0)
                { toolStripStatusLabel1.Enabled = false; checkBox1.Enabled = false; }
            }
        }

        private void dgvHangHoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Edits(this.MaHangHoa);
                //if (dgvHangHoa.RowCount > 0)
                //{
                //    int i = e.RowIndex;
                //    if (i >= 0)
                //    {
                //        getdata(dgvHangHoa, "BanGhi", i);
                //    }
                //    else
                //    { dgvHangHoa.Rows[0].Selected = true; }
                //}
                //else
                //{ }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.DialogResult giatri = System.Windows.Forms.MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", System.Windows.Forms.MessageBoxButtons.YesNo);
                {
                    if (giatri == System.Windows.Forms.DialogResult.Yes)
                    {
                        frmQuanLyDonDatHang.BaoDong = "A";
                        this.Close();
                    }
                    else
                    { }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private BarcodeLib.Barcode b = new BarcodeLib.Barcode();
        private void btnForeColor_Click(object sender, EventArgs e)
        {
            try
            {
                using (ColorDialog cdialog = new ColorDialog())
                {
                    cdialog.AnyColor = true;
                    if (cdialog.ShowDialog() == DialogResult.OK)
                    {
                        this.b.ForeColor = cdialog.Color;
                        this.btnForeColor.BackColor = this.b.ForeColor;
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// va ma vach
        /// </summary>



        private void LayHangHoaTheoMa(string MaHang)
        {
            try
            {
                if (rdo())
                {//đang là thẻ vip
                    List<Entities.ThongTinMaVach> l = new List<Entities.ThongTinMaVach>();
                    List<Entities.ThongTinMaVach> ll = new List<Entities.ThongTinMaVach>();
                    l = getTheVip().ToList();
                    ll = getTheGiaTri().ToList();
                    if (l.Count == 0 || ll.Count == 0)
                    {
                        return;
                    }
                    else
                    {
                        bool flag = false;
                        foreach (Entities.ThongTinMaVach item in l)
                        {//thẻ vip
                            if (item.MaHangHoa.ToUpper().Equals(MaHang.ToUpper()))
                            {
                                // txtData.Text = item.MaHangHoa;
                                txtTen.Text = item.TenHangHoa;
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {//thẻ giá trị
                            foreach (Entities.ThongTinMaVach item in ll)
                            {
                                //txtData.Text = item.MaHangHoa;
                                txtTen.Text = item.TenHangHoa;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    //////////////////////MRK FIX
                    bool QUYDOI = false;
                    //Kiểm tra bảng quy đổi đơn vị tính
                    List<Entities.QuyDoiDonViTinh> lDVT = _K;
                    Entities.QuyDoiDonViTinh lDVTSelect = new Entities.QuyDoiDonViTinh();
                    foreach (Entities.QuyDoiDonViTinh item in lDVT)
                    {
                        if (item.MaHangQuyDoi.Equals(MaHang))
                        {
                            //MaHang = item.MaHangDuocQuyDoi; //tạm thời chuyển mã hàng về mã hàng được quy đổi để lấy thông tin
                            lDVTSelect = item;  //biến tạm
                            QUYDOI = true; //trạng thái mã hàng đang nhập vào là hàng quy đổi hay không?
                            break;
                        }
                    }
                    /////////////////////////////
                    if (QUYDOI)
                    {
                        txtTen.Text = lDVTSelect.TenHangDuocQuyDoi;
                    }
                    else
                    {
                        Entities.HienThi_ChiTiet_DonDatHang ktm = new Entities.HienThi_ChiTiet_DonDatHang();
                        cl = new Server_Client.Client();
                        this.client = cl.Connect(Luu.IP, Luu.Ports);
                        ktm = new Entities.HienThi_ChiTiet_DonDatHang("Select", MaHang);
                        clientstrem = cl.SerializeObj(this.client, "LayHangHoaTheoMaHangHoa", ktm);
                        Entities.HienThi_ChiTiet_DonDatHang tra = new Entities.HienThi_ChiTiet_DonDatHang();
                        tra = (Entities.HienThi_ChiTiet_DonDatHang)cl.DeserializeHepper(clientstrem, tra);
                        if (tra.MaHangHoa == null || tra == null)
                        {
                            //frmXuLyHangHoa frm = new frmXuLyHangHoa("ThemNhapKho", txtData.Text);
                            //frm.ShowDialog();
                            //txtData.Text = GiaTriCanLuu.mahanghoa;
                            //LayHangHoaTheoMa(txtData.Text);
                        }
                        else
                        {
                            //txtData.Text = tra.MaHangHoa;
                            //txtTen.Text = tra.TenHangHoa;
                        }
                    }
                }
            }
            catch (Exception ex)
            { string s = ex.Message.ToString(); }
        }

        /// <summary>
        /// Chuyen doi img Thanh mang byte
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        private byte[] ConvertToByte(Image img)
        {
            byte[] bytes = null;
            try
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                bytes = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(bytes, 0, Convert.ToInt32(ms.Length));
            }
            catch (Exception)
            {
                bytes = null;
            }
            return bytes;
        }

        /// <summary>
        /// Tao IMG .
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private Image CreateIMG(string code)
        {
            Image img = null;
            try
            {
                errorProvider1.Clear();
                int W = 350;//Convert.ToInt32(this.txtWidth.Text.Trim());
                int H = 220;//Convert.ToInt32(this.txtHeight.Text.Trim());
                BarcodeLib.AlignmentPositions Align = BarcodeLib.AlignmentPositions.CENTER;
                switch (cbBarcodeAlign.SelectedItem.ToString().Trim().ToLower())
                {
                    case "left": Align = BarcodeLib.AlignmentPositions.LEFT; break;
                    case "right": Align = BarcodeLib.AlignmentPositions.RIGHT; break;
                    default: Align = BarcodeLib.AlignmentPositions.CENTER; break;
                }

                BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
                switch (cbEncodeType.SelectedItem.ToString().Trim())
                {
                    case "UPC-A": type = BarcodeLib.TYPE.UPCA; break;
                    case "UPC-E": type = BarcodeLib.TYPE.UPCE; break;
                    case "UPC 2 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_2DIGIT; break;
                    case "UPC 5 Digit Ext.": type = BarcodeLib.TYPE.UPC_SUPPLEMENTAL_5DIGIT; break;
                    case "EAN-13": type = BarcodeLib.TYPE.EAN13; break;
                    case "JAN-13": type = BarcodeLib.TYPE.JAN13; break;
                    case "EAN-8": type = BarcodeLib.TYPE.EAN8; break;
                    case "ITF-14": type = BarcodeLib.TYPE.ITF14; break;
                    case "Codabar": type = BarcodeLib.TYPE.Codabar; break;
                    case "PostNet": type = BarcodeLib.TYPE.PostNet; break;
                    case "Bookland/ISBN": type = BarcodeLib.TYPE.BOOKLAND; break;
                    case "Code 11": type = BarcodeLib.TYPE.CODE11; break;
                    case "Code 39": type = BarcodeLib.TYPE.CODE39; break;
                    case "Code 39 Extended": type = BarcodeLib.TYPE.CODE39Extended; break;
                    case "Code 93": type = BarcodeLib.TYPE.CODE93; break;
                    case "LOGMARS": type = BarcodeLib.TYPE.LOGMARS; break;
                    case "MSI": type = BarcodeLib.TYPE.MSI_Mod10; break;
                    case "Interleaved 2 of 5": type = BarcodeLib.TYPE.Interleaved2of5; break;
                    case "Standard 2 of 5": type = BarcodeLib.TYPE.Standard2of5; break;
                    case "Code 128": type = BarcodeLib.TYPE.CODE128; break;
                    case "Code 128-A": type = BarcodeLib.TYPE.CODE128A; break;
                    case "Code 128-B": type = BarcodeLib.TYPE.CODE128B; break;
                    case "Code 128-C": type = BarcodeLib.TYPE.CODE128C; break;
                    case "Telepen": type = BarcodeLib.TYPE.TELEPEN; break;
                    default: MessageBox.Show("Please specify the encoding type."); break;
                }
                try
                {
                    if (type != BarcodeLib.TYPE.UNSPECIFIED)
                    {
                        barcode.Image = null;
                        b.IncludeLabel = this.chkGenerateLabel.Checked;
                        b.Alignment = Align;
                        b.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), this.cbRotateFlip.SelectedItem.ToString(), true);
                        switch (this.cbLabelLocation.SelectedItem.ToString().Trim().ToUpper())
                        {
                            case "BOTTOMLEFT": b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMLEFT; break;
                            case "BOTTOMRIGHT": b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMRIGHT; break;
                            case "TOPCENTER": b.LabelPosition = BarcodeLib.LabelPositions.TOPCENTER; break;
                            case "TOPLEFT": b.LabelPosition = BarcodeLib.LabelPositions.TOPLEFT; break;
                            case "TOPRIGHT": b.LabelPosition = BarcodeLib.LabelPositions.TOPRIGHT; break;
                            default: b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER; break;
                        }//switch

                        //===== Encoding performed here =====
                        img = b.Encode(type, code, this.btnForeColor.BackColor, this.btnBackColor.BackColor, W, H);
                        //barcode.Image = img;
                        //===================================
                        this.lblEncodingTime.Text = "(" + Math.Round(b.EncodingTime, 0, MidpointRounding.AwayFromZero).ToString() + "ms)";
                        txtEncoded.Text = b.EncodedValue;
                    }
                    //barcode.Width = barcode.Image.Width;
                    //barcode.Height = barcode.Image.Height;
                    //barcode.Location = new Point((this.groupBox2.Location.X + this.groupBox2.Width / 2) - barcode.Width / 2, (this.groupBox2.Location.Y + this.groupBox2.Height / 2) - barcode.Height / 2);
                }
                catch (Exception ex)
                {
                    img = null;
                }
            }
            catch (Exception ex)
            {
                img = null;
            }
            return img;
        }


        /// <summary>
        /// Lay hang hoa trong datagridview
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        private Entities.Barcode[] GetProduct(DataGridView view)
        {
            List<Entities.Barcode> hangHoaList = new List<Entities.Barcode>();
            try
            {
                int count = 0;
                if (view != null)
                    count = view.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    string maHangHoa = view["MaHangHoa", i].Value.ToString();
                    string tenHangHoa = view["TenHangHoa", i].Value.ToString();
                    int soLuong = 0;
                    if (view["GhiChu", i].Value != null)
                        soLuong = int.Parse(view["GhiChu", i].Value.ToString());
                    for (int j = 0; j < soLuong; j++)
                    {
                        Entities.Barcode barcode = new Entities.Barcode();
                        barcode.TenHangHoa = tenHangHoa;
                        barcode.MaHangHoa = maHangHoa;
                        Image img = CreateIMG(maHangHoa);
                        byte[] bytes = ConvertToByte(img);
                        barcode.MaVach = bytes;
                        hangHoaList.Add(barcode);
                    }
                }
            }
            catch (Exception e)
            {
                hangHoaList = null;
            }
            return hangHoaList.ToArray();
        }

        /// <summary>
        /// GetTheGT
        /// </summary>
        /// <param name="barCode"></param>
        /// <param name="congTy"></param>
        /// <returns></returns>
        public Entities.MaVachThe[] GetTheGT(Entities.Barcode[] barCode, Entities.ThongTinCongTy congTy)
        {
            List<Entities.MaVachThe> retVal = null;
            try
            {
                retVal = new List<Entities.MaVachThe>();
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.TheGiamGia pt = new Entities.TheGiamGia();
                pt.HanhDong = "Select";
                clientstrem = cl.SerializeObj(this.client, "TheGiamGia", pt);
                Entities.TheGiamGia[] tggArr = new Entities.TheGiamGia[1];
                // đổ mảng đối tượng vào datagripview       
                tggArr = (Entities.TheGiamGia[])cl.DeserializeHepper1(clientstrem, tggArr);
                // 
                foreach (Entities.Barcode code in barCode)
                {
                    foreach (Entities.TheGiamGia item in tggArr)
                    {
                        if (code.MaHangHoa.Trim().ToUpper().Equals(item.MaTheGiamGia.Trim().ToUpper()))
                        {
                            Entities.MaVachThe mavach = new Entities.MaVachThe();
                            mavach.TenCongTy = congTy.TenCongTy + "\r\n" + congTy.DiaChi;
                            mavach.TenThe = "Thẻ Giá Trị";
                            mavach.MaKH = item.MaKhachHang;
                            mavach.TenKH = code.TenHangHoa;
                            mavach.NgayBatDau = item.NgayBatDau.ToShortDateString();
                            mavach.NgayKetThuc = item.NgayKetThuc.ToShortDateString();
                            mavach.MaVach = code.MaVach;
                            mavach.MaThe = item.MaTheGiamGia;
                            mavach.GiaTriThe = double.Parse(item.GiaTriThe);
                            retVal.Add(mavach);
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                retVal = null;
            }

            return retVal.ToArray();
        }

        /// <summary>
        /// GetTheVip
        /// </summary>
        /// <param name="barCode"></param>
        /// <param name="congTy"></param>
        /// <returns></returns>
        public Entities.MaVachThe[] GetTheVip(Entities.Barcode[] barCode, Entities.ThongTinCongTy congTy)
        {
            List<Entities.MaVachThe> retVal = null;
            try
            {
                retVal = new List<Entities.MaVachThe>();
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                //Entities.TheVip kh = new Entities.TheVip("Select", txtmkh.Text);
                clientstrem = cl.SerializeObj(this.client, "LayTheVip", null);
                Entities.TheVip[] theVip = new Entities.TheVip[1];
                // đổ mảng đối tượng vào datagripview       
                theVip = (Entities.TheVip[])cl.DeserializeHepper1(clientstrem, null);
                //
                foreach (Entities.Barcode code in barCode)
                {
                    foreach (Entities.TheVip item in theVip)
                    {
                        if (code.MaHangHoa.Trim().ToUpper().Equals(item.MaThe.Trim().ToUpper()))
                        {
                            Entities.MaVachThe mavach = new Entities.MaVachThe();
                            mavach.TenCongTy = congTy.TenCongTy + "\r\n" + congTy.DiaChi;
                            mavach.TenThe = "Thẻ Vip";
                            mavach.MaKH = item.MaKhachHang;
                            mavach.TenKH = code.TenHangHoa;
                            mavach.NgayBatDau = new DateTime().ToShortDateString();
                            mavach.NgayKetThuc = new DateTime().ToShortDateString();
                            mavach.MaVach = code.MaVach;
                            mavach.MaThe = item.MaThe;
                            mavach.GiaTriThe = double.Parse(item.GiaTriThe);
                            retVal.Add(mavach);
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                retVal = null;
            }

            return retVal.ToArray();
        }

        /// <summary>
        /// GetCongTy
        /// </summary>
        /// <returns></returns>
        public Entities.ThongTinCongTy GetCongTy()
        {
            Entities.ThongTinCongTy retVal = null;
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                Entities.ThongTinCongTy congTy = new Entities.ThongTinCongTy();
                // truyền HanhDong
                congTy = new Entities.ThongTinCongTy("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                Entities.ThongTinCongTy[] arr = new Entities.ThongTinCongTy[1];
                clientstrem = cl.SerializeObj(this.client, "CongTy", congTy);
                // đổ mảng đối tượng vào daThongTinCongTytagripview       
                arr = (Entities.ThongTinCongTy[])cl.DeserializeHepper1(clientstrem, arr);
                retVal = arr[0];
            }
            catch (Exception)
            {
                retVal = null;
            }

            return retVal;
        }


        private int soCot = 1;

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                this.statusStrip1.Focus();
                //quyen
                if (!Common.Utilities.User.Administrator && !CheckQuyen(this.Name, 4))
                { return; }

                if (checkBox1.Checked == true)
                {
                    if (dgvHangHoa.RowCount > 0)
                    {
                        this.Enabled = false;
                        this.Enabled = true;
                        Entities.Barcode[] barCode = GetProduct(dgvHangHoa);
                        Entities.MaVachThe[] theGT = this.GetTheGT(barCode, this.congTy);
                        Entities.MaVachThe[] theVip = this.GetTheVip(barCode, this.congTy);
                        string loaiGiay = cbxLoaigiay.SelectedItem.ToString();
                        switch (loaiGiay)
                        {
                            case "Loại A5":
                                //in theo 5 cot NGANG
                                if (barCode.Length > 0)
                                {
                                    if (checkXemIn.Checked == false)
                                    {
                                        GUI.Report.rptBarcodeNamCotA5 report = new GUI.Report.rptBarcodeNamCotA5();
                                        report.SetDataSource(barCode);
                                        report.PrintToPrinter(1, true, 0, 999);
                                    }
                                    else
                                    {

                                        frmBaoCaoBarcode frm = new frmBaoCaoBarcode(barCode, "Loại A5", checkXemIn.Checked);
                                        frm.ShowDialog();
                                    }
                                }
                                else
                                { MessageBox.Show("Chọn " + getTenRdo() + " mới có thể in"); }
                                break;

                            case "Loại 110":
                                // in theo 3 cot
                                if (barCode.Length > 0)
                                {
                                    if (checkXemIn.Checked == false)
                                    {
                                        GUI.Report.rptBarcodeBaCot report = new GUI.Report.rptBarcodeBaCot();
                                        report.SetDataSource(barCode);
                                        report.PrintToPrinter(1, true, 0, 999);
                                    }
                                    else
                                    {
                                        frmBaoCaoBarcode frm = new frmBaoCaoBarcode(barCode, "Loại 110", checkXemIn.Checked);
                                        frm.ShowDialog();
                                    }
                                }
                                else
                                { MessageBox.Show("Chọn " + getTenRdo() + " mới có thể in"); }
                                break;
                            case "Loại A4":
                                // in theo 5 cot
                                if (barCode.Length > 0)
                                {
                                    if (checkXemIn.Checked == false)
                                    {
                                        // Hang Hoa
                                        if (rdoHH.Checked)
                                        {
                                            GUI.Report.rptBarcodeNamCot report = new GUI.Report.rptBarcodeNamCot();
                                            report.SetDataSource(barCode);
                                            report.PrintToPrinter(1, true, 0, 999);
                                        }
                                        // The Vip
                                        if (rdoTV.Checked)
                                        {
                                            GUI.Report.rptMaVachTheVip report = new Report.rptMaVachTheVip();
                                            report.SetDataSource(theVip);
                                            report.PrintToPrinter(1, true, 0, 999);
                                        }
                                        // The GT
                                        if (rdoTGT.Checked)
                                        {

                                            GUI.Report.rptMaVachTheGT report = new Report.rptMaVachTheGT();
                                            report.SetDataSource(theGT);
                                            report.PrintToPrinter(1, true, 0, 999);
                                        }

                                    }
                                    else
                                    {
                                        // Hang hoa
                                        if (rdoHH.Checked)
                                        {
                                            frmBaoCaoBarcode frm = new frmBaoCaoBarcode(barCode, "Loại A4", checkXemIn.Checked);
                                            frm.ShowDialog();
                                        }
                                        // The Vip
                                        if (rdoTV.Checked)
                                        {
                                            frmBaoCaoBarcode frm = new frmBaoCaoBarcode("TV", theVip);
                                            frm.ShowDialog();
                                        }
                                        // The GT
                                        if (rdoTGT.Checked)
                                        {
                                            frmBaoCaoBarcode frm = new frmBaoCaoBarcode("TGT", theGT);
                                            frm.ShowDialog();
                                        }


                                    }
                                }
                                else
                                { MessageBox.Show("Chọn " + getTenRdo() + " mới có thể in"); }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    { MessageBox.Show("Không có " + getTenRdo() + " nào để in mã vạch"); }
                }
                else
                { MessageBox.Show("Bạn đang chọn in một mã vạch"); checkBox1.Focus(); }


            }
            catch (Exception ex)
            {

            }

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    txtWidth.ReadOnly = true;
                    txtHeight.ReadOnly = true;
                    cbxLoaigiay.SelectedIndex = 0;
                    cbxLoaigiay.Enabled = true;
                }
                if (checkBox1.Checked == false)
                {
                    txtWidth.ReadOnly = false;
                    txtHeight.ReadOnly = false;
                    cbxLoaigiay.SelectedIndex = 0;
                    cbxLoaigiay.Enabled = false;
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        private Entities.ThongTinMaVach[] search;
        private void CheckData(Boolean c)
        {
            try
            {
                ArrayList list = new ArrayList();
                Entities.ThongTinMaVach[] check = null;
                for (int i = 0; i < search.Length; i++)
                {
                    Entities.ThongTinMaVach banghi = new Entities.ThongTinMaVach();
                    banghi.ChonIn = c;
                    banghi.HanhDong = search[i].HanhDong;
                    banghi.MaHangHoa = search[i].MaHangHoa;
                    banghi.TenHangHoa = search[i].TenHangHoa;
                    banghi.GiaNhap = search[i].GiaNhap;
                    banghi.GiaBanBuon = search[i].GiaBanBuon;
                    banghi.GiaBanLe = search[i].GiaBanLe;
                    list.Add(banghi);
                }
                int n = list.Count;
                if (n == 0) { check = null; }
                check = new Entities.ThongTinMaVach[n];
                for (int i = 0; i < n; i++)
                {
                    check[i] = (Entities.ThongTinMaVach)list[i];
                }
                search = check;
                dgvHangHoa.DataSource = search;
                FixDatagridview();
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbxLoaigiay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtWidth.ReadOnly = true;
                txtHeight.ReadOnly = true;
                if (cbxLoaigiay.SelectedItem.ToString() == "Loại A5")
                {
                    //soCot = 2;
                    soCot = 5;
                    txtWidth.Text = "36 mm";
                    txtHeight.Text = "19 mm";
                }
                if (cbxLoaigiay.SelectedItem.ToString() == "Loại 110")
                {
                    soCot = 3;
                    txtWidth.Text = "36 mm";
                    txtHeight.Text = "19 mm";
                }
                if (cbxLoaigiay.SelectedItem.ToString() == "Loại A4")
                {
                    soCot = 5;
                    txtWidth.Text = "36 mm";
                    txtHeight.Text = "19 mm";
                }
            }
            catch (Exception ex)
            { string s = ex.Message; }
        }

        private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMaHangHoa_Click(object sender, EventArgs e)
        {
            txtMaHangHoa.Text = "";
            txtTenHangHoa.Text = "";
            txtSoLuongIn.Text = "";
        }
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
        private ArrayList list = new ArrayList();
        private void GetHangHoa(string mahanghoa)
        {
            try
            {
                if (rdo())
                {
                    List<Entities.ThongTinMaVach> l = new List<Entities.ThongTinMaVach>();
                    List<Entities.ThongTinMaVach> ll = new List<Entities.ThongTinMaVach>();
                    l = getTheVip().ToList();
                    ll = getTheGiaTri().ToList();
                    if (l.Count == 0 || ll.Count == 0)
                    {
                        return;
                    }
                    else
                    {
                        bool flag = false;
                        foreach (Entities.ThongTinMaVach item in l)
                        {//thẻ vip
                            if (item.MaHangHoa.ToUpper().Equals(mahanghoa.ToUpper()))
                            {
                                txtMaHangHoa.Text = item.MaHangHoa;
                                txtTenHangHoa.Text = item.TenHangHoa;
                                txtSoLuongIn.Text = "1";
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {//thẻ giá trị
                            foreach (Entities.ThongTinMaVach item in ll)
                            {
                                txtMaHangHoa.Text = item.MaHangHoa;
                                txtTenHangHoa.Text = item.TenHangHoa;
                                txtSoLuongIn.Text = "1";
                                break;
                            }
                        }
                    }
                }
                else
                {
                    //////////////////////MRK FIX
                    bool QUYDOI = false;
                    //Kiểm tra bảng quy đổi đơn vị tính
                    List<Entities.QuyDoiDonViTinh> lDVT = _K;
                    Entities.QuyDoiDonViTinh lDVTSelect = new Entities.QuyDoiDonViTinh();
                    foreach (Entities.QuyDoiDonViTinh item in lDVT)
                    {
                        if (item.MaHangQuyDoi.Equals(mahanghoa))
                        {
                            //MaHang = item.MaHangDuocQuyDoi; //tạm thời chuyển mã hàng về mã hàng được quy đổi để lấy thông tin
                            lDVTSelect = item;  //biến tạm
                            QUYDOI = true; //trạng thái mã hàng đang nhập vào là hàng quy đổi hay không?
                            break;
                        }
                    }
                    /////////////////////////////
                    if (QUYDOI)
                    {
                        if (this.search == null)
                        { return; }
                        for (int i = 0; i < this.search.Length; i++)
                        {
                            if (this.search[i].MaHangHoa.ToUpper() == lDVTSelect.MaHangDuocQuyDoi.ToUpper())
                            {
                                txtMaHangHoa.Text = lDVTSelect.MaHangQuyDoi;
                                txtTenHangHoa.Text = lDVTSelect.TenHangDuocQuyDoi;
                                txtSoLuongIn.Text = "1";
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (this.search == null)
                        { return; }
                        for (int i = 0; i < this.search.Length; i++)
                        {
                            if (this.search[i].MaHangHoa.ToUpper() == mahanghoa.ToUpper())
                            {
                                txtMaHangHoa.Text = this.search[i].MaHangHoa;
                                txtTenHangHoa.Text = this.search[i].TenHangHoa;
                                txtSoLuongIn.Text = "1";
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void SelectData()
        {
            try
            {
                cl = new Server_Client.Client();
                this.client = cl.Connect(Luu.IP, Luu.Ports);
                Entities.ThongTinMaVach row = new Entities.ThongTinMaVach("Select");
                clientstrem = cl.SerializeObj(this.client, "ThongTinMaVachHangHoa", row);
                search = new Entities.ThongTinMaVach[1];
                this.search = (Entities.ThongTinMaVach[])cl.DeserializeHepper(clientstrem, this.search);
                client.Close();
                clientstrem.Close();
                this.SelectGoiHang();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                this.search = null;
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
        #endregion
        private Entities.ThongTinMaVach RowsData()
        {
            Entities.ThongTinMaVach r = new Entities.ThongTinMaVach();
            try
            {
                if (txtMaHangHoa.Text == string.Empty || txtMaHangHoa.Text == "F4 - Tra cứu")
                {
                    MessageBox.Show("Bạn phải nhập mã " + getTenRdo() + "");
                    txtMaHangHoa.Focus();
                    return null;
                }
                if (txtTenHangHoa.Text == string.Empty)
                {
                    MessageBox.Show("Bạn phải nhập tên " + getTenRdo() + "");
                    txtMaHangHoa.Text = "";
                    txtTenHangHoa.Text = "";
                    txtSoLuongIn.Text = "1";
                    txtMaHangHoa.Focus();
                    return null;
                }
                try
                {
                    if (int.Parse("0" + txtSoLuongIn.Text) <= 0)
                    {
                        MessageBox.Show("Số lượng in nhập không đúng");
                        txtSoLuongIn.Text = "1";
                        txtSoLuongIn.Focus();
                        return null;
                    }
                }
                catch
                {
                    MessageBox.Show("Số lượng in nhập không đúng");
                    txtSoLuongIn.Text = "1";
                    txtSoLuongIn.Focus();
                    return null;
                }

                r.MaHangHoa = txtMaHangHoa.Text;
                r.TenHangHoa = txtTenHangHoa.Text;
                r.GhiChu = txtSoLuongIn.Text;
            }
            catch (Exception)
            {
                r = null;
            }
            return r;
        }
        private Entities.ThongTinMaVach[] listview;
        private void AddRow(Entities.ThongTinMaVach rows)
        {
            ArrayList li = new ArrayList();
            try
            {

                Boolean kiemtrasoluong = false;
                if (listview == null)
                {
                    li.Add(rows);
                }
                else
                {
                    Boolean kt = false;
                    for (int i = 0; i < listview.Length; i++)
                    {
                        if (listview[i].MaHangHoa.Trim().ToUpper().Equals(rows.MaHangHoa.Trim().ToUpper()))
                        {
                            kt = true;
                            int sl = int.Parse(listview[i].GhiChu) + int.Parse(rows.GhiChu);
                            rows.GhiChu = (sl).ToString();
                            li.Add(rows);
                        }
                        else
                        {
                            li.Add(listview[i]);
                        }
                    }
                    if (kt == false)
                    {
                        li.Add(rows);
                    }
                }
                if (kiemtrasoluong == false)
                {
                    int x = li.Count;
                    if (x <= 0)
                    {
                        listview = new Entities.ThongTinMaVach[0];
                    }
                    else
                    {
                        listview = new Entities.ThongTinMaVach[x];
                        for (int i = 0; i < x; i++)
                        {
                            listview[i] = (Entities.ThongTinMaVach)li[i];
                        }
                    }
                    dgvHangHoa.DataSource = listview;
                    FixDatagridview();
                }
            }
            catch (Exception)
            {
            }
        }

        private void Edits(string MaHangHoa)
        {
            ArrayList li = new ArrayList();
            try
            {
                if (listview == null)
                {
                    li = null;
                }
                else
                {
                    for (int i = 0; i < listview.Length; i++)
                    {
                        if (listview[i].MaHangHoa != MaHangHoa)
                        {
                            li.Add(listview[i]);
                        }
                        if (listview[i].MaHangHoa == MaHangHoa)
                        {
                            txtMaHangHoa.Text = listview[i].MaHangHoa;
                            txtTenHangHoa.Text = listview[i].TenHangHoa;
                            txtSoLuongIn.Text = listview[i].GhiChu;
                            txtSoLuongIn.Focus();
                        }
                    }
                }
                int k = li.Count;
                if (k <= 0)
                {
                    listview = new Entities.ThongTinMaVach[0];
                }
                else
                {
                    listview = new Entities.ThongTinMaVach[k];
                    for (int i = 0; i < k; i++)
                    {
                        listview[i] = (Entities.ThongTinMaVach)li[i];
                    }
                }
                dgvHangHoa.DataSource = listview;
                FixDatagridview();
            }
            catch (Exception)
            {

            }
        }

        public static Entities.ThongTinMaVach timhanghoa;
        private void txtMaHangHoa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        this.GetHangHoa(txtMaHangHoa.Text);
                        txtSoLuongIn.Focus();
                        break;
                    case Keys.F4:
                        //frmTimKiemHangHoaGoiHang frm = new frmTimKiemHangHoaGoiHang();
                        string tem = string.Empty;

                        if (rdoHH.Checked)
                            tem = "HH";

                        if (rdoTV.Checked)
                            tem = "TV";

                        if (rdoTGT.Checked)
                            tem = "TGT";

                        frmTimKiemHangHoaGoiHang frm = new frmTimKiemHangHoaGoiHang(tem);
                        frm.ShowDialog();
                        if (timhanghoa != null)
                        {
                            txtMaHangHoa.Text = timhanghoa.MaHangHoa;
                            txtTenHangHoa.Text = timhanghoa.TenHangHoa;
                            txtSoLuongIn.Text = "1";
                            txtSoLuongIn.Focus();
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtMaHangHoa_TextChanged(object sender, EventArgs e)
        {
            txtTenHangHoa.Text = "";
            txtSoLuongIn.Text = "";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Entities.ThongTinMaVach ttmv = this.RowsData();
            if (ttmv == null)
                return;

            this.AddRow(ttmv);
            txtMaHangHoa.Text = "";
            txtTenHangHoa.Text = "";
            txtSoLuongIn.Text = "";
            txtMaHangHoa.Focus();
        }

        private void txtSoLuongIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Entities.ThongTinMaVach ttmv = this.RowsData();
                if (ttmv == null)
                    return;

                this.AddRow(ttmv);
                txtMaHangHoa.Text = "";
                txtTenHangHoa.Text = "";
                txtSoLuongIn.Text = "";
                txtMaHangHoa.Focus();
            }
        }
        private string MaHangHoa = string.Empty;
        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (listview != null)
                {
                    this.MaHangHoa = dgvHangHoa.Rows[e.RowIndex].Cells["MaHangHoa"].Value.ToString();
                }
            }
            catch (Exception)
            {
            }
        }

        private void rdoTV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTV.Checked)
            {
                label14.Text = "Mã thẻ vip:";
                label15.Text = "Tên khách hàng: ";
                dgvHangHoa.DataSource = null;
                listview = null;
            }
        }

        private void rdoHH_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoHH.Checked)
            {
                label14.Text = "Mã hàng hóa:";
                label15.Text = "Tên hàng hóa: ";
                dgvHangHoa.DataSource = null;
                listview = null;
            }
        }

        private void rdoTGT_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTGT.Checked)
            {
                label14.Text = "Mã thẻ giá trị:";
                label15.Text = "Tên khách hàng: ";
                dgvHangHoa.DataSource = null;
                listview = null;
            }
        }

        private void txtTenHangHoa_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenHangHoa.Text))
            {
                string maHangHoa = txtMaHangHoa.Text;
                Image img = CreateIMG(maHangHoa);
                barcode.Image = img;
                txtTen.Text = txtTenHangHoa.Text;
            }
        }


    }
    /// <summary>
    /// print
    /// </summary>
    //public class SimpleReportPrinter
    //{
    //    Image _header;
    //    int _pageNumber = 0;
    //    PrintDocument _prtdoc;
    //    public SimpleReportPrinter(Image header)
    //    {
    //        _header = header;
    //        _prtdoc = new PrintDocument();
    //        _prtdoc.PrintPage += new PrintPageEventHandler(_prtdoc_PrintPage);
    //    }
    //    public void Print(bool hardcopy)
    //    {
    //        hardcopy = true;
    //        PrintDialog pdlg = new PrintDialog();
    //        pdlg.Document = _prtdoc;
    //        if (pdlg.ShowDialog() == DialogResult.OK)
    //        {
    //            PageSetupDialog psd = new PageSetupDialog();
    //            psd.EnableMetric = true;
    //            psd.Document = pdlg.Document;
    //            if (psd.ShowDialog() == DialogResult.OK)
    //            {
    //                _prtdoc.DefaultPageSettings = psd.PageSettings;
    //                if (hardcopy)
    //                {
    //                    _prtdoc.Print();
    //                }
    //                else
    //                {
    //                    PrintPreviewDialog prvw = new PrintPreviewDialog();
    //                    prvw.Document = _prtdoc;
    //                    prvw.ShowDialog();
    //                }
    //            }
    //        }
    //    }

    //    private void _prtdoc_PrintPage(object sender, PrintPageEventArgs e)
    //    {
    //        e.Graphics.Clip = new Region(e.MarginBounds);
    //        Single x = e.MarginBounds.Left;
    //        Single y = e.MarginBounds.Top;
    //        if (_pageNumber++ == 0)
    //        {
    //            e.Graphics.DrawImage(_header, x, y);
    //            y += _header.Height + 30;
    //        }
    //        RectangleF mainTextArea = RectangleF.FromLTRB(x, y, e.MarginBounds.Right, e.MarginBounds.Bottom);
    //        //e.Graphics.TranslateTransform(200, 200);
    //        //e.Graphics.RotateTransform(e.PageSettings.Landscape ? 30 : 60);
    //        //e.Graphics.DrawString("hungvv", new Font("Courier New", 75, FontStyle.Bold), new SolidBrush(Color.FromArgb(64, Color.Black)), 0, 0);
    //    }

    //}
}
