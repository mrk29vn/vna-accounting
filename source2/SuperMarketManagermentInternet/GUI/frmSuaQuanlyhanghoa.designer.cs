namespace GUI
{
    partial class frmSuahanghoa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssThem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssIn = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssDong = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbKieuHangHoa = new System.Windows.Forms.ComboBox();
            this.txtMaNhomHangHoa = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtNgungTheoDoi = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtChiTietThem = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtMucTonToiThieu = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtMucDatHang = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSeri = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.cmbMaDonViTinh = new System.Windows.Forms.ComboBox();
            this.cmbMaThueGTGT = new System.Windows.Forms.ComboBox();
            this.cmbMaThueTieuThuDacBiet = new System.Windows.Forms.ComboBox();
            this.cmbMaThueXuatKhau = new System.Windows.Forms.ComboBox();
            this.cmbMathueNhapKhau = new System.Windows.Forms.ComboBox();
            this.cmbMaNhaSanXuat = new System.Windows.Forms.ComboBox();
            this.txtGiaBanBuon = new System.Windows.Forms.TextBox();
            this.txtMaVachNSX = new System.Windows.Forms.TextBox();
            this.txtGiaBanLe = new System.Windows.Forms.TextBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.txtMaHangHoa = new System.Windows.Forms.TextBox();
            this.txtTenHangHoa = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssThem,
            this.tssSua,
            this.tssIn,
            this.tssDong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 370);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(786, 22);
            this.statusStrip1.TabIndex = 56;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssThem
            // 
            this.tssThem.Enabled = false;
            this.tssThem.Image = global::GUI.Properties.Resources.Them;
            this.tssThem.Name = "tssThem";
            this.tssThem.Size = new System.Drawing.Size(192, 17);
            this.tssThem.Spring = true;
            this.tssThem.Text = "Thêm";
            // 
            // tssSua
            // 
            this.tssSua.Image = global::GUI.Properties.Resources.Sua;
            this.tssSua.Name = "tssSua";
            this.tssSua.Size = new System.Drawing.Size(192, 17);
            this.tssSua.Spring = true;
            this.tssSua.Text = "&Sửa";
            // 
            // tssIn
            // 
            this.tssIn.Image = global::GUI.Properties.Resources.In;
            this.tssIn.Name = "tssIn";
            this.tssIn.Size = new System.Drawing.Size(192, 17);
            this.tssIn.Spring = true;
            this.tssIn.Text = "&In";
            // 
            // tssDong
            // 
            this.tssDong.Image = global::GUI.Properties.Resources.Xoa;
            this.tssDong.Name = "tssDong";
            this.tssDong.Size = new System.Drawing.Size(192, 17);
            this.tssDong.Spring = true;
            this.tssDong.Text = "Đóng";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(786, 370);
            this.tabControl1.TabIndex = 58;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.cmbKieuHangHoa);
            this.tabPage1.Controls.Add(this.txtMaNhomHangHoa);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.txtNgungTheoDoi);
            this.tabPage1.Controls.Add(this.label19);
            this.tabPage1.Controls.Add(this.txtChiTietThem);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.txtMucTonToiThieu);
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.txtMucDatHang);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.txtSeri);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.txtGhiChu);
            this.tabPage1.Controls.Add(this.cmbMaDonViTinh);
            this.tabPage1.Controls.Add(this.cmbMaThueGTGT);
            this.tabPage1.Controls.Add(this.cmbMaThueTieuThuDacBiet);
            this.tabPage1.Controls.Add(this.cmbMaThueXuatKhau);
            this.tabPage1.Controls.Add(this.cmbMathueNhapKhau);
            this.tabPage1.Controls.Add(this.cmbMaNhaSanXuat);
            this.tabPage1.Controls.Add(this.txtGiaBanBuon);
            this.tabPage1.Controls.Add(this.txtMaVachNSX);
            this.tabPage1.Controls.Add(this.txtGiaBanLe);
            this.tabPage1.Controls.Add(this.txtGiaNhap);
            this.tabPage1.Controls.Add(this.txtMaHangHoa);
            this.tabPage1.Controls.Add(this.txtTenHangHoa);
            this.tabPage1.Controls.Add(this.txtID);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(778, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông tin hàng hóa";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(452, 118);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(80, 13);
            this.label21.TabIndex = 65;
            this.label21.Text = "Kiểu Hàng Hóa";
            // 
            // cmbKieuHangHoa
            // 
            this.cmbKieuHangHoa.FormattingEnabled = true;
            this.cmbKieuHangHoa.Location = new System.Drawing.Point(552, 115);
            this.cmbKieuHangHoa.Name = "cmbKieuHangHoa";
            this.cmbKieuHangHoa.Size = new System.Drawing.Size(171, 21);
            this.cmbKieuHangHoa.TabIndex = 64;
            // 
            // txtMaNhomHangHoa
            // 
            this.txtMaNhomHangHoa.Location = new System.Drawing.Point(128, 66);
            this.txtMaNhomHangHoa.Name = "txtMaNhomHangHoa";
            this.txtMaNhomHangHoa.Size = new System.Drawing.Size(175, 20);
            this.txtMaNhomHangHoa.TabIndex = 63;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(2, 69);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(105, 13);
            this.label20.TabIndex = 62;
            this.label20.Text = "Mã Nhóm Hàng Hóa";
            // 
            // txtNgungTheoDoi
            // 
            this.txtNgungTheoDoi.Location = new System.Drawing.Point(552, 247);
            this.txtNgungTheoDoi.Name = "txtNgungTheoDoi";
            this.txtNgungTheoDoi.Size = new System.Drawing.Size(171, 20);
            this.txtNgungTheoDoi.TabIndex = 61;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(451, 250);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(80, 13);
            this.label19.TabIndex = 60;
            this.label19.Text = "Ngừng theo dõi";
            // 
            // txtChiTietThem
            // 
            this.txtChiTietThem.Location = new System.Drawing.Point(552, 221);
            this.txtChiTietThem.Name = "txtChiTietThem";
            this.txtChiTietThem.Size = new System.Drawing.Size(171, 20);
            this.txtChiTietThem.TabIndex = 59;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(458, 224);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 13);
            this.label18.TabIndex = 58;
            this.label18.Text = "Chi Tiết Thêm";
            // 
            // txtMucTonToiThieu
            // 
            this.txtMucTonToiThieu.Location = new System.Drawing.Point(552, 195);
            this.txtMucTonToiThieu.Name = "txtMucTonToiThieu";
            this.txtMucTonToiThieu.Size = new System.Drawing.Size(171, 20);
            this.txtMucTonToiThieu.TabIndex = 57;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(446, 202);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 13);
            this.label17.TabIndex = 56;
            this.label17.Text = "Mức tồn tối thiểu";
            // 
            // txtMucDatHang
            // 
            this.txtMucDatHang.Location = new System.Drawing.Point(552, 169);
            this.txtMucDatHang.Name = "txtMucDatHang";
            this.txtMucDatHang.Size = new System.Drawing.Size(171, 20);
            this.txtMucDatHang.TabIndex = 55;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(458, 172);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 13);
            this.label16.TabIndex = 54;
            this.label16.Text = "Mức đặt hàng";
            // 
            // txtSeri
            // 
            this.txtSeri.Location = new System.Drawing.Point(552, 142);
            this.txtSeri.Name = "txtSeri";
            this.txtSeri.Size = new System.Drawing.Size(171, 20);
            this.txtSeri.TabIndex = 53;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(490, 145);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 52;
            this.label15.Text = "Seri/Lô";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(453, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 51;
            this.label14.Text = "Mã thuế GTGT";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(63, 279);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 50;
            this.label13.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(128, 276);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGhiChu.Size = new System.Drawing.Size(637, 61);
            this.txtGhiChu.TabIndex = 49;
            // 
            // cmbMaDonViTinh
            // 
            this.cmbMaDonViTinh.FormattingEnabled = true;
            this.cmbMaDonViTinh.Location = new System.Drawing.Point(128, 171);
            this.cmbMaDonViTinh.Name = "cmbMaDonViTinh";
            this.cmbMaDonViTinh.Size = new System.Drawing.Size(175, 21);
            this.cmbMaDonViTinh.TabIndex = 48;
            // 
            // cmbMaThueGTGT
            // 
            this.cmbMaThueGTGT.FormattingEnabled = true;
            this.cmbMaThueGTGT.Location = new System.Drawing.Point(552, 88);
            this.cmbMaThueGTGT.Name = "cmbMaThueGTGT";
            this.cmbMaThueGTGT.Size = new System.Drawing.Size(171, 21);
            this.cmbMaThueGTGT.TabIndex = 48;
            // 
            // cmbMaThueTieuThuDacBiet
            // 
            this.cmbMaThueTieuThuDacBiet.FormattingEnabled = true;
            this.cmbMaThueTieuThuDacBiet.Location = new System.Drawing.Point(552, 61);
            this.cmbMaThueTieuThuDacBiet.Name = "cmbMaThueTieuThuDacBiet";
            this.cmbMaThueTieuThuDacBiet.Size = new System.Drawing.Size(171, 21);
            this.cmbMaThueTieuThuDacBiet.TabIndex = 48;
            // 
            // cmbMaThueXuatKhau
            // 
            this.cmbMaThueXuatKhau.FormattingEnabled = true;
            this.cmbMaThueXuatKhau.Location = new System.Drawing.Point(552, 34);
            this.cmbMaThueXuatKhau.Name = "cmbMaThueXuatKhau";
            this.cmbMaThueXuatKhau.Size = new System.Drawing.Size(171, 21);
            this.cmbMaThueXuatKhau.TabIndex = 48;
            // 
            // cmbMathueNhapKhau
            // 
            this.cmbMathueNhapKhau.FormattingEnabled = true;
            this.cmbMathueNhapKhau.Location = new System.Drawing.Point(552, 7);
            this.cmbMathueNhapKhau.Name = "cmbMathueNhapKhau";
            this.cmbMathueNhapKhau.Size = new System.Drawing.Size(171, 21);
            this.cmbMathueNhapKhau.TabIndex = 48;
            // 
            // cmbMaNhaSanXuat
            // 
            this.cmbMaNhaSanXuat.FormattingEnabled = true;
            this.cmbMaNhaSanXuat.Location = new System.Drawing.Point(128, 118);
            this.cmbMaNhaSanXuat.Name = "cmbMaNhaSanXuat";
            this.cmbMaNhaSanXuat.Size = new System.Drawing.Size(175, 21);
            this.cmbMaNhaSanXuat.TabIndex = 48;
            // 
            // txtGiaBanBuon
            // 
            this.txtGiaBanBuon.Location = new System.Drawing.Point(128, 224);
            this.txtGiaBanBuon.Name = "txtGiaBanBuon";
            this.txtGiaBanBuon.Size = new System.Drawing.Size(175, 20);
            this.txtGiaBanBuon.TabIndex = 46;
            // 
            // txtMaVachNSX
            // 
            this.txtMaVachNSX.Location = new System.Drawing.Point(128, 145);
            this.txtMaVachNSX.Name = "txtMaVachNSX";
            this.txtMaVachNSX.Size = new System.Drawing.Size(175, 20);
            this.txtMaVachNSX.TabIndex = 45;
            // 
            // txtGiaBanLe
            // 
            this.txtGiaBanLe.Location = new System.Drawing.Point(128, 250);
            this.txtGiaBanLe.Name = "txtGiaBanLe";
            this.txtGiaBanLe.Size = new System.Drawing.Size(175, 20);
            this.txtGiaBanLe.TabIndex = 43;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(128, 198);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(175, 20);
            this.txtGiaNhap.TabIndex = 41;
            // 
            // txtMaHangHoa
            // 
            this.txtMaHangHoa.Location = new System.Drawing.Point(128, 40);
            this.txtMaHangHoa.Name = "txtMaHangHoa";
            this.txtMaHangHoa.Size = new System.Drawing.Size(175, 20);
            this.txtMaHangHoa.TabIndex = 39;
            // 
            // txtTenHangHoa
            // 
            this.txtTenHangHoa.Location = new System.Drawing.Point(128, 92);
            this.txtTenHangHoa.Name = "txtTenHangHoa";
            this.txtTenHangHoa.Size = new System.Drawing.Size(175, 20);
            this.txtTenHangHoa.TabIndex = 38;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(128, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(175, 20);
            this.txtID.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(406, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Mã thuế tiêu thụ đặc biệt";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(436, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Mã thuế xuất khẩu";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(432, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 36;
            this.label10.Text = "Mã thuế nhập khẩu";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Giá bán lẻ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(36, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Giá bán buôn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Giá Nhập";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Mã Đơn Vị Tính ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Mã Vạch NSX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Mã Nhà Sản Xuất";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Tên Hàng Hóa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Mã Hàng Hóa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Hàng Hóa ID";
            // 
            // frmSuahanghoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(786, 392);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmSuahanghoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SỬA - HÀNG HÓA";
            this.Load += new System.EventHandler(this.frmSuahanghoa_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssThem;
        private System.Windows.Forms.ToolStripStatusLabel tssSua;
        private System.Windows.Forms.ToolStripStatusLabel tssIn;
        private System.Windows.Forms.ToolStripStatusLabel tssDong;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbKieuHangHoa;
        private System.Windows.Forms.TextBox txtMaNhomHangHoa;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtNgungTheoDoi;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtChiTietThem;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtMucTonToiThieu;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtMucDatHang;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSeri;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.ComboBox cmbMaDonViTinh;
        private System.Windows.Forms.ComboBox cmbMaThueGTGT;
        private System.Windows.Forms.ComboBox cmbMaThueTieuThuDacBiet;
        private System.Windows.Forms.ComboBox cmbMaThueXuatKhau;
        private System.Windows.Forms.ComboBox cmbMathueNhapKhau;
        private System.Windows.Forms.ComboBox cmbMaNhaSanXuat;
        private System.Windows.Forms.TextBox txtGiaBanBuon;
        private System.Windows.Forms.TextBox txtMaVachNSX;
        private System.Windows.Forms.TextBox txtGiaBanLe;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.TextBox txtMaHangHoa;
        private System.Windows.Forms.TextBox txtTenHangHoa;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}