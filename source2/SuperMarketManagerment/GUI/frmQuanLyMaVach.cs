using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;
using Entities;

namespace GUI
{
    public partial class frmQuanLyMaVach : Form
    {
        ThongTinCongTy congTy;
        List<QuyDoiDonViTinh> _k = new List<QuyDoiDonViTinh>();
        ///////////////////////////////////////////////////MRK FIX
        List<QuyDoiDonViTinh> Bangquydoidonvitinh()
        {
            // quy đổi đơn vị tính
            Server_Client.Client client2 = new Server_Client.Client();
            TcpClient client1 = client2.Connect(Luu.IP, Luu.Ports);
            CheckRefer ctxh = new CheckRefer("QD");
            clientstrem = client2.SerializeObj(client1, "Select", ctxh);
            QuyDoiDonViTinh[] quidoidvt = new QuyDoiDonViTinh[0];
            return ((QuyDoiDonViTinh[])client2.DeserializeHepper1(clientstrem, quidoidvt)).ToList();
        }
        //////////////////////////////////////////////////////////

        string GetTenRdo()
        {
            return rdoTV.Checked ? rdoTV.Text : rdoHH.Text;
        }

        public frmQuanLyMaVach()
        {
            InitializeComponent();
            congTy = GetCongTy();

        }
        #region hungvv==============================================khoi tao=====================================================================
        private TcpClient client;
        private NetworkStream clientstrem;
        Server_Client.Client cl;

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

                dgvHangHoa.Columns[2].HeaderText = "Mã " + GetTenRdo() + "";
                dgvHangHoa.Columns[3].HeaderText = "Tên " + GetTenRdo() + "";
                dgvHangHoa.Columns[7].HeaderText = "Số lượng in";

                dgvHangHoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvHangHoa.Columns[2].Width = 100;
                dgvHangHoa.Columns[3].Width = 200;
                dgvHangHoa.Columns[7].Width = 100;
            }
            catch
            { }
        }
        #endregion
        public bool CheckQuyen(string tenform, int quyen)
        {
            switch (quyen)
            {
                case 1:
                    {
                        foreach (ChiTietQuyen item in frmDangNhap.CTQ.Where(item => item.TenForm.ToLower().Equals(tenform.ToLower())))
                            return item.QuyenXem;
                        break;
                    }
                case 2:
                    {
                        foreach (ChiTietQuyen item in frmDangNhap.CTQ.Where(item => item.TenForm.ToLower().Equals(tenform.ToLower())))
                            return item.QuyenSua;
                        break;
                    }
                case 3:
                    {
                        foreach (ChiTietQuyen item in frmDangNhap.CTQ.Where(item => item.TenForm.ToLower().Equals(tenform.ToLower())))
                            return item.QuyenXoa;
                        break;
                    }
                case 4:
                    {
                        foreach (ChiTietQuyen item in frmDangNhap.CTQ.Where(item => item.TenForm.ToLower().Equals(tenform.ToLower())))
                            return item.QuyenThem;
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
                    SelectData();
                    _k = Bangquydoidonvitinh();
                }
                catch
                {
                }
                chkGenerateLabel.Checked = false;
                cbxLoaigiay.Items.Clear();
                cbxLoaigiay.Items.AddRange(new object[] { "Loại A5", "Loại 110", "Loại A4" });
                cbxLoaigiay.SelectedIndex = 0;
                btnLoadImage.Visible = false;
                Bitmap temp = new Bitmap(1, 1);
                temp.SetPixel(0, 0, BackColor);
                barcode.Image = temp;
                cbEncodeType.SelectedIndex = 0;
                cbBarcodeAlign.SelectedIndex = 0;
                cbLabelLocation.SelectedIndex = 0;
                cbRotateFlip.DataSource = Enum.GetNames(typeof(RotateFlipType));
                int i = 0;
                foreach (object o in cbRotateFlip.Items)
                {
                    if (o.ToString().Trim().ToLower() == "rotatenoneflipnone")
                        break;
                    i++;
                }
                cbRotateFlip.SelectedIndex = i;
                btnBackColor.BackColor = b.BackColor;
                btnForeColor.BackColor = b.ForeColor;
                ThongTinMaVach[] mv = new ThongTinMaVach[0];
                dgvHangHoa.DataSource = mv;
                FixDatagridview();
            }
            catch
            {
                if (dgvHangHoa.RowCount > 0) return;
                toolStripStatusLabel1.Enabled = false; checkBox1.Enabled = false;
            }
        }

        private void dgvHangHoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Edits(MaHangHoa);
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult giatri = MessageBox.Show("Bạn chắc chắn đóng lại không ?", "Thông Báo", MessageBoxButtons.YesNo);
                {
                    if (giatri == DialogResult.Yes)
                    {
                        frmQuanLyDonDatHang.BaoDong = "A";
                        Close();
                    }
                }
            }
            catch
            {
            }
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
                        b.ForeColor = cdialog.Color;
                        btnForeColor.BackColor = this.b.ForeColor;
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Chuyen doi img Thanh mang byte
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        private byte[] ConvertToByte(Image img)
        {
            byte[] bytes;
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
        private Image CreateImg(string code)
        {
            Image img = null;
            try
            {
                errorProvider1.Clear();
                int W = 350;//Convert.ToInt32(this.txtWidth.Text.Trim());
                int H = 220;//Convert.ToInt32(this.txtHeight.Text.Trim());
                BarcodeLib.AlignmentPositions align;
                switch (cbBarcodeAlign.SelectedItem.ToString().Trim().ToLower())
                {
                    case "left": align = BarcodeLib.AlignmentPositions.LEFT; break;
                    case "right": align = BarcodeLib.AlignmentPositions.RIGHT; break;
                    default: align = BarcodeLib.AlignmentPositions.CENTER; break;
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
                        b.IncludeLabel = chkGenerateLabel.Checked;
                        b.Alignment = align;
                        b.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), cbRotateFlip.SelectedItem.ToString(), true);
                        switch (cbLabelLocation.SelectedItem.ToString().Trim().ToUpper())
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
                        lblEncodingTime.Text = "(" + Math.Round(b.EncodingTime, 0, MidpointRounding.AwayFromZero).ToString() + "ms)";
                        txtEncoded.Text = b.EncodedValue;
                    }
                }
                catch
                {
                    img = null;
                }
            }
            catch
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
                        Image img = CreateImg(maHangHoa);
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
        /// <param name="thongTinCongTy"></param>
        /// <returns></returns>
        public MaVachThe[] GetTheVip(Barcode[] barCode, ThongTinCongTy thongTinCongTy)
        {
            List<MaVachThe> retVal;
            try
            {
                retVal = new List<MaVachThe>();
                cl = new Server_Client.Client();
                // gán TCPclient
                client = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                //Entities.TheVip kh = new Entities.TheVip("Select", txtmkh.Text);
                clientstrem = cl.SerializeObj(client, "LayTheVip", null);
                // đổ mảng đối tượng vào datagripview       
                TheVip[] theVip = (TheVip[])cl.DeserializeHepper1(clientstrem, null);
                //
                foreach (Barcode code in barCode)
                {
                    foreach (TheVip item in theVip)
                    {
                        if (!code.MaHangHoa.Trim().ToUpper().Equals(item.MaThe.Trim().ToUpper())) continue;
                        MaVachThe maVachThe = new MaVachThe
                                                  {
                                                      TenCongTy = thongTinCongTy.TenCongTy + "\r\n" + thongTinCongTy.DiaChi,
                                                      TenThe = "Thẻ Vip",
                                                      MaKH = item.MaKhachHang,
                                                      TenKH = code.TenHangHoa,
                                                      NgayBatDau = new DateTime().ToShortDateString(),
                                                      NgayKetThuc = new DateTime().ToShortDateString(),
                                                      MaVach = code.MaVach,
                                                      MaThe = item.MaThe,
                                                      GiaTriThe = double.Parse(item.GiaTriThe)
                                                  };
                        retVal.Add(maVachThe);
                        break;
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
        public ThongTinCongTy GetCongTy()
        {
            ThongTinCongTy retVal;
            try
            {
                cl = new Server_Client.Client();
                // gán TCPclient
                client = cl.Connect(Luu.IP, Luu.Ports);
                // khởi tạo biến truyền vào với hàm khởi tạo
                ThongTinCongTy congTy = new ThongTinCongTy();
                // truyền HanhDong
                congTy = new ThongTinCongTy("Select");
                // khởi tạo mảng đối tượng để hứng giá trị
                ThongTinCongTy[] arr = new ThongTinCongTy[1];
                clientstrem = cl.SerializeObj(client, "CongTy", congTy);
                // đổ mảng đối tượng vào daThongTinCongTytagripview       
                arr = (ThongTinCongTy[])cl.DeserializeHepper1(clientstrem, arr);
                retVal = arr[0];
            }
            catch (Exception)
            {
                retVal = null;
            }

            return retVal;
        }

        private void ToolStripStatusLabel1Click(object sender, EventArgs e)
        {
            try
            {
                statusStrip1.Focus();
                //quyen
                if (!Common.Utilities.User.Administrator && !CheckQuyen(Name, 4)) return;

                if (checkBox1.Checked)
                {
                    if (dgvHangHoa.RowCount > 0)
                    {
                        Enabled = false;
                        Enabled = true;
                        Barcode[] barCode = GetProduct(dgvHangHoa);
                        MaVachThe[] theGt = GetTheGT(barCode, congTy);
                        MaVachThe[] theVip = GetTheVip(barCode, congTy);
                        string loaiGiay = cbxLoaigiay.SelectedItem.ToString();
                        switch (loaiGiay)
                        {
                            case "Loại A5":
                                //in theo 5 cot NGANG
                                if (barCode.Length > 0)
                                {
                                    if (checkXemIn.Checked == false)
                                    {
                                        Report.rptBarcodeNamCotA5 report = new GUI.Report.rptBarcodeNamCotA5();
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
                                { MessageBox.Show("Chọn " + GetTenRdo() + " mới có thể in"); }
                                break;

                            case "Loại 110":
                                // in theo 3 cot
                                if (barCode.Length > 0)
                                {
                                    if (checkXemIn.Checked == false)
                                    {
                                        Report.rptBarcodeBaCot report = new Report.rptBarcodeBaCot();
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
                                { MessageBox.Show("Chọn " + GetTenRdo() + " mới có thể in"); }
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
                                            report.SetDataSource(theGt);
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
                                            frmBaoCaoBarcode frm = new frmBaoCaoBarcode("TGT", theGt);
                                            frm.ShowDialog();
                                        }


                                    }
                                }
                                else
                                { MessageBox.Show("Chọn " + GetTenRdo() + " mới có thể in"); }
                                break;
                        }
                    }
                    else
                    { MessageBox.Show("Không có " + GetTenRdo() + " nào để in mã vạch"); }
                }
                else
                { MessageBox.Show("Bạn đang chọn in một mã vạch"); checkBox1.Focus(); }
            }
            catch
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
            catch
            {
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        private ThongTinMaVach[] _search;

        private void cbxLoaigiay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtWidth.ReadOnly = true;
                txtHeight.ReadOnly = true;
                if (cbxLoaigiay.SelectedItem.ToString() == "Loại A5")
                {
                    txtWidth.Text = "36 mm";
                    txtHeight.Text = "19 mm";
                }
                if (cbxLoaigiay.SelectedItem.ToString() == "Loại 110")
                {
                    txtWidth.Text = "36 mm";
                    txtHeight.Text = "19 mm";
                }
                if (cbxLoaigiay.SelectedItem.ToString() == "Loại A4")
                {
                    txtWidth.Text = "36 mm";
                    txtHeight.Text = "19 mm";
                }
            }
            catch
            {
            }
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
            txtMaHangHoa.Text = string.Empty;
            txtTenHangHoa.Text = string.Empty;
            txtSoLuongIn.Text = string.Empty;
        }
        #region
        ////////////////////////////////////////////MRk FIX
        ThongTinMaVach[] getTheVip()
        {
            cl = new Server_Client.Client();
            client = cl.Connect(Luu.IP, Luu.Ports);
            clientstrem = cl.SerializeObj(client, "THAOTAC_InMaVachTheVip", new ThongTinMaVach());
            ThongTinMaVach[] bientam = new ThongTinMaVach[1];
            //Tìm kiếm thẻ vip
            bientam = (ThongTinMaVach[])cl.DeserializeHepper(clientstrem, bientam);
            client.Close();
            clientstrem.Close();
            return bientam ?? new ThongTinMaVach[0];
        }
        ThongTinMaVach[] getTheGiaTri()
        {
            cl = new Server_Client.Client();
            client = cl.Connect(Luu.IP, Luu.Ports);
            clientstrem = cl.SerializeObj(client, "THAOTAC_InMaVachTheGiaTri", new ThongTinMaVach());
            ThongTinMaVach[] bientam = new ThongTinMaVach[1];
            //Tìm kiếm thẻ giá trị
            bientam = (ThongTinMaVach[])cl.DeserializeHepper(clientstrem, bientam);
            client.Close();
            clientstrem.Close();
            return bientam ?? new ThongTinMaVach[0];
        }
        ////////////////////////////////////////////MRk FIX
        private ArrayList list = new ArrayList();
        private void GetHangHoa(string mahanghoa)
        {
            try
            {
                if (rdoTV.Checked)
                {
                    List<ThongTinMaVach> l = new List<ThongTinMaVach>();
                    List<ThongTinMaVach> ll = new List<ThongTinMaVach>();
                    l = getTheVip().ToList();
                    ll = getTheGiaTri().ToList();
                    if (l.Count == 0 || ll.Count == 0)
                    {
                        return;
                    }
                    bool flag = false;
                    foreach (ThongTinMaVach item in l.Where(item => item.MaHangHoa.ToUpper().Equals(mahanghoa.ToUpper())))
                    {
                        txtMaHangHoa.Text = item.MaHangHoa;
                        txtTenHangHoa.Text = item.TenHangHoa;
                        txtSoLuongIn.Text = "1";
                        flag = true;
                        break;
                    }
                    if (!flag)
                    {//thẻ giá trị
                        foreach (ThongTinMaVach item in ll)
                        {
                            txtMaHangHoa.Text = item.MaHangHoa;
                            txtTenHangHoa.Text = item.TenHangHoa;
                            txtSoLuongIn.Text = "1";
                            break;
                        }
                    }
                }
                else
                {
                    //////////////////////MRK FIX
                    bool quydoi = false;
                    //Kiểm tra bảng quy đổi đơn vị tính
                    List<QuyDoiDonViTinh> lDvt = _k;
                    QuyDoiDonViTinh lDvtSelect = new QuyDoiDonViTinh();
                    foreach (QuyDoiDonViTinh item in lDvt)
                    {
                        if (item.MaHangQuyDoi.Equals(mahanghoa))
                        {
                            //MaHang = item.MaHangDuocQuyDoi; //tạm thời chuyển mã hàng về mã hàng được quy đổi để lấy thông tin
                            lDvtSelect = item;  //biến tạm
                            quydoi = true; //trạng thái mã hàng đang nhập vào là hàng quy đổi hay không?
                            break;
                        }
                    }
                    /////////////////////////////
                    if (quydoi)
                    {
                        if (_search == null)
                        { return; }
                        for (int i = 0; i < _search.Length; i++)
                        {
                            if (_search[i].MaHangHoa.ToUpper() == lDvtSelect.MaHangDuocQuyDoi.ToUpper())
                            {
                                txtMaHangHoa.Text = lDvtSelect.MaHangQuyDoi;
                                txtTenHangHoa.Text = lDvtSelect.TenHangDuocQuyDoi;
                                txtSoLuongIn.Text = "1";
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (_search == null)
                        { return; }
                        foreach (ThongTinMaVach t in _search)
                        {
                            if (t.MaHangHoa.ToUpper() != mahanghoa.ToUpper()) continue;
                            txtMaHangHoa.Text = t.MaHangHoa;
                            txtTenHangHoa.Text = t.TenHangHoa;
                            txtSoLuongIn.Text = "1";
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
        }
        private void SelectData()
        {
            try
            {
                cl = new Server_Client.Client();
                client = cl.Connect(Luu.IP, Luu.Ports);
                ThongTinMaVach row = new ThongTinMaVach("Select");
                clientstrem = cl.SerializeObj(client, "ThongTinMaVachHangHoa", row);
                _search = new ThongTinMaVach[1];
                _search = (ThongTinMaVach[])cl.DeserializeHepper(clientstrem, _search);
                client.Close();
                clientstrem.Close();
                SelectGoiHang();
            }
            catch
            {
                _search = null;
            }
        }
        public void SelectGoiHang()
        {
            try
            {
                cl = new Server_Client.Client();
                client = cl.Connect(Luu.IP, Luu.Ports);
                GoiHang goi = new GoiHang("Select");
                clientstrem = cl.SerializeObj(client, "GoiHang", goi);
                GoiHang[] goiHang = new GoiHang[1];
                goiHang = (GoiHang[])cl.DeserializeHepper1(clientstrem, goiHang);
                try
                {
                    foreach (GoiHang t in goiHang)
                    {
                        if (t.Deleted == false)
                        {
                            ThongTinMaVach row = new ThongTinMaVach
                                                     {
                                                         MaHangHoa = t.MaGoiHang,
                                                         TenHangHoa = t.TenGoiHang
                                                     };
                            list.Add(row);
                        }
                    }
                }
                catch { }
                try
                {
                    for (int i = 0; i < this._search.Length; i++)
                    {
                        list.Add(this._search[i]);
                    }
                }
                catch { }
                int k = list.Count;
                if (k <= 0) _search = null;
                else
                {
                    _search = new ThongTinMaVach[k];
                    for (int i = 0; i < k; i++) _search[i] = (ThongTinMaVach)list[i];
                }
            }
            catch { }
        }
        #endregion
        private ThongTinMaVach RowsData()
        {
            ThongTinMaVach r = new ThongTinMaVach();
            try
            {
                if (txtMaHangHoa.Text == string.Empty || txtMaHangHoa.Text == "F4 - Tra cứu")
                {
                    MessageBox.Show("Bạn phải nhập mã " + GetTenRdo() + "");
                    txtMaHangHoa.Focus();
                    return null;
                }
                if (txtTenHangHoa.Text == string.Empty)
                {
                    MessageBox.Show("Bạn phải nhập tên " + GetTenRdo() + "");
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
        private ThongTinMaVach[] _listview;
        private void AddRow(ThongTinMaVach rows)
        {
            ArrayList li = new ArrayList();
            try
            {
                if (_listview == null)
                {
                    li.Add(rows);
                }
                else
                {
                    Boolean kt = false;
                    foreach (ThongTinMaVach t in _listview)
                    {
                        if (t.MaHangHoa.Trim().ToUpper().Equals(rows.MaHangHoa.Trim().ToUpper()))
                        {
                            kt = true;
                            int sl = int.Parse(t.GhiChu) + int.Parse(rows.GhiChu);
                            rows.GhiChu = (sl).ToString();
                            li.Add(rows);
                        }
                        else li.Add(t);
                    }
                    if (kt == false) li.Add(rows);
                }
                int x = li.Count;
                if (x <= 0)
                {
                    _listview = new ThongTinMaVach[0];
                }
                else
                {
                    _listview = new ThongTinMaVach[x];
                    for (int i = 0; i < x; i++)
                    {
                        _listview[i] = (ThongTinMaVach)li[i];
                    }
                }
                dgvHangHoa.DataSource = _listview;
                FixDatagridview();
            }
            catch
            {
            }
        }

        private void Edits(string MaHangHoa)
        {
            ArrayList li = new ArrayList();
            try
            {
                if (_listview == null) li = null;
                else
                {
                    foreach (ThongTinMaVach t in _listview)
                    {
                        if (t.MaHangHoa != MaHangHoa) { li.Add(t); continue; }
                        txtMaHangHoa.Text = t.MaHangHoa;
                        txtTenHangHoa.Text = t.TenHangHoa;
                        txtSoLuongIn.Text = t.GhiChu;
                        txtSoLuongIn.Focus();
                    }
                }

                int k = li.Count;
                if (k <= 0)
                {
                    _listview = new ThongTinMaVach[0];
                }
                else
                {
                    _listview = new ThongTinMaVach[k];
                    for (int i = 0; i < k; i++)
                    {
                        _listview[i] = (ThongTinMaVach)li[i];
                    }
                }
                dgvHangHoa.DataSource = _listview;
                FixDatagridview();
            }
            catch
            {
            }
        }

        public static ThongTinMaVach Timhanghoa;
        private void txtMaHangHoa_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        GetHangHoa(txtMaHangHoa.Text);
                        txtSoLuongIn.Focus();
                        break;
                    case Keys.F4:
                        string tem = string.Empty;

                        if (rdoHH.Checked)
                            tem = "HH";

                        if (rdoTV.Checked)
                            tem = "TV";

                        if (rdoTGT.Checked)
                            tem = "TGT";

                        frmTimKiemHangHoaGoiHang frm = new frmTimKiemHangHoaGoiHang(tem);
                        frm.ShowDialog();
                        if (Timhanghoa != null)
                        {
                            txtMaHangHoa.Text = Timhanghoa.MaHangHoa;
                            txtTenHangHoa.Text = Timhanghoa.TenHangHoa;
                            txtSoLuongIn.Text = "1";
                            txtSoLuongIn.Focus();
                        }
                        break;
                }
            }
            catch
            {
            }
        }

        private void txtMaHangHoa_TextChanged(object sender, EventArgs e)
        {
            txtTenHangHoa.Text = string.Empty;
            txtSoLuongIn.Text = string.Empty;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Entities.ThongTinMaVach ttmv = RowsData();
            if (ttmv == null)
                return;

            AddRow(ttmv);
            txtMaHangHoa.Text = "";
            txtTenHangHoa.Text = "";
            txtSoLuongIn.Text = "";
            txtMaHangHoa.Focus();
        }

        private void txtSoLuongIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Entities.ThongTinMaVach ttmv = RowsData();
                if (ttmv == null)
                    return;

                AddRow(ttmv);
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
                if (_listview != null)
                {
                    MaHangHoa = dgvHangHoa.Rows[e.RowIndex].Cells["MaHangHoa"].Value.ToString();
                }
            }
            catch
            {
            }
        }

        private void rdoTV_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoTV.Checked) return;
            label14.Text = "Mã thẻ vip:";
            label15.Text = "Tên khách hàng: ";
            dgvHangHoa.DataSource = null;
            _listview = null;
        }

        private void rdoHH_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoHH.Checked) return;
            label14.Text = "Mã hàng hóa:";
            label15.Text = "Tên hàng hóa: ";
            dgvHangHoa.DataSource = null;
            _listview = null;
        }

        private void rdoTGT_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoTGT.Checked) return;
            label14.Text = "Mã thẻ giá trị:";
            label15.Text = "Tên khách hàng: ";
            dgvHangHoa.DataSource = null;
            _listview = null;
        }

        private void txtTenHangHoa_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenHangHoa.Text)) return;
            string maHangHoa = txtMaHangHoa.Text;
            Image img = CreateImg(maHangHoa);
            barcode.Image = img;
            txtTen.Text = txtTenHangHoa.Text;
        }
    }
}
