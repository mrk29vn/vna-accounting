namespace GUI
{
    partial class frmXuLy_KiemKeKho
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
            this.toolStripStatus_Themmoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Ghilai = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.thiêtLâpThôngSôToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xoaChưngTưHiênThơiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.huyĐơnĐătHangHiênThơiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saoChepChưngTưTưToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saoChepChưngTưSangNhâpHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saoChepChưngTưToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel = new System.Windows.Forms.Panel();
            this.lblTaikhoan = new System.Windows.Forms.Label();
            this.cbxMaTaiKhoan = new System.Windows.Forms.ComboBox();
            this.lblDiengiai = new System.Windows.Forms.Label();
            this.txtDiengiai = new System.Windows.Forms.TextBox();
            this.cbxKhoban = new System.Windows.Forms.ComboBox();
            this.lblKhohang = new System.Windows.Forms.Label();
            this.lblDinhdangngay = new System.Windows.Forms.LinkLabel();
            this.makNgaychungtu = new System.Windows.Forms.MaskedTextBox();
            this.lblNgaychungtu = new System.Windows.Forms.Label();
            this.txtSochungtu = new System.Windows.Forms.TextBox();
            this.lblSochungtu = new System.Windows.Forms.Label();
            this.grbDataGridview = new System.Windows.Forms.GroupBox();
            this.dgvInsertOrder = new System.Windows.Forms.DataGridView();
            this.palThem = new System.Windows.Forms.Panel();
            this.toolStrip_Insert = new System.Windows.Forms.ToolStrip();
            this.toolStrip_txtTracuu = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip_txtTenhang = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip_txtTonkho = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip_txtTonThucTe = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip_txtLyDo = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip_btnThem = new System.Windows.Forms.ToolStripButton();
            this.txtPhantrang = new System.Windows.Forms.TextBox();
            this.lblGiamgia_Tienhang = new System.Windows.Forms.Label();
            this.txtTienhang = new System.Windows.Forms.TextBox();
            this.palXem = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.panel.SuspendLayout();
            this.grbDataGridview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsertOrder)).BeginInit();
            this.palThem.SuspendLayout();
            this.toolStrip_Insert.SuspendLayout();
            this.palXem.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus_Themmoi,
            this.toolStripStatus_Ghilai,
            this.toolStripStatusLabel3,
            this.toolStripDropDownButton1,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 371);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(758, 27);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatus_Themmoi
            // 
            this.toolStripStatus_Themmoi.Image = global::GUI.Properties.Resources.Them;
            this.toolStripStatus_Themmoi.Name = "toolStripStatus_Themmoi";
            this.toolStripStatus_Themmoi.Size = new System.Drawing.Size(158, 22);
            this.toolStripStatus_Themmoi.Spring = true;
            this.toolStripStatus_Themmoi.Text = "Thêm";
            this.toolStripStatus_Themmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Themmoi.Click += new System.EventHandler(this.toolStripStatus_Themmoi_Click);
            this.toolStripStatus_Themmoi.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Themmoi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatus_Ghilai
            // 
            this.toolStripStatus_Ghilai.Image = global::GUI.Properties.Resources.Luu;
            this.toolStripStatus_Ghilai.Name = "toolStripStatus_Ghilai";
            this.toolStripStatus_Ghilai.Size = new System.Drawing.Size(158, 22);
            this.toolStripStatus_Ghilai.Spring = true;
            this.toolStripStatus_Ghilai.Text = "Sửa";
            this.toolStripStatus_Ghilai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Ghilai.Click += new System.EventHandler(this.toolStripStatus_Ghilai_Click);
            this.toolStripStatus_Ghilai.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Ghilai.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = global::GUI.Properties.Resources.In;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(158, 22);
            this.toolStripStatusLabel3.Spring = true;
            this.toolStripStatusLabel3.Text = "In";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel3.Click += new System.EventHandler(this.toolStripStatusLabel3_Click);
            this.toolStripStatusLabel3.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thiêtLâpThôngSôToolStripMenuItem,
            this.xoaChưngTưHiênThơiToolStripMenuItem,
            this.huyĐơnĐătHangHiênThơiToolStripMenuItem,
            this.saoChepChưngTưTưToolStripMenuItem,
            this.saoChepChưngTưSangNhâpHangToolStripMenuItem,
            this.saoChepChưngTưToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::GUI.Properties.Resources.khac1;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(78, 25);
            this.toolStripDropDownButton1.Text = "Khác";
            this.toolStripDropDownButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripDropDownButton1.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripDropDownButton1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // thiêtLâpThôngSôToolStripMenuItem
            // 
            this.thiêtLâpThôngSôToolStripMenuItem.Name = "thiêtLâpThôngSôToolStripMenuItem";
            this.thiêtLâpThôngSôToolStripMenuItem.Size = new System.Drawing.Size(374, 26);
            this.thiêtLâpThôngSôToolStripMenuItem.Text = "Thiết lập thông số";
            this.thiêtLâpThôngSôToolStripMenuItem.Click += new System.EventHandler(this.thiêtLâpThôngSôToolStripMenuItem_Click);
            // 
            // xoaChưngTưHiênThơiToolStripMenuItem
            // 
            this.xoaChưngTưHiênThơiToolStripMenuItem.Name = "xoaChưngTưHiênThơiToolStripMenuItem";
            this.xoaChưngTưHiênThơiToolStripMenuItem.Size = new System.Drawing.Size(374, 26);
            this.xoaChưngTưHiênThơiToolStripMenuItem.Text = "Xóa chứng từ hiện thời";
            // 
            // huyĐơnĐătHangHiênThơiToolStripMenuItem
            // 
            this.huyĐơnĐătHangHiênThơiToolStripMenuItem.Name = "huyĐơnĐătHangHiênThơiToolStripMenuItem";
            this.huyĐơnĐătHangHiênThơiToolStripMenuItem.Size = new System.Drawing.Size(374, 26);
            this.huyĐơnĐătHangHiênThơiToolStripMenuItem.Text = "Hủy đơn đặt hàng hiện thời";
            // 
            // saoChepChưngTưTưToolStripMenuItem
            // 
            this.saoChepChưngTưTưToolStripMenuItem.Name = "saoChepChưngTưTưToolStripMenuItem";
            this.saoChepChưngTưTưToolStripMenuItem.Size = new System.Drawing.Size(374, 26);
            this.saoChepChưngTưTưToolStripMenuItem.Text = "Sao chép từ chứng từ...";
            // 
            // saoChepChưngTưSangNhâpHangToolStripMenuItem
            // 
            this.saoChepChưngTưSangNhâpHangToolStripMenuItem.Name = "saoChepChưngTưSangNhâpHangToolStripMenuItem";
            this.saoChepChưngTưSangNhâpHangToolStripMenuItem.Size = new System.Drawing.Size(374, 26);
            this.saoChepChưngTưSangNhâpHangToolStripMenuItem.Text = "Sao chép chứng từ sang nhập hàng";
            // 
            // saoChepChưngTưToolStripMenuItem
            // 
            this.saoChepChưngTưToolStripMenuItem.Name = "saoChepChưngTưToolStripMenuItem";
            this.saoChepChưngTưToolStripMenuItem.Size = new System.Drawing.Size(374, 26);
            this.saoChepChưngTưToolStripMenuItem.Text = "Sao chép chứng từ thành Chứng từ mới";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Image = global::GUI.Properties.Resources.Xoa;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(158, 22);
            this.toolStripStatusLabel4.Spring = true;
            this.toolStripStatusLabel4.Text = "Trở về";
            this.toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel4.Click += new System.EventHandler(this.toolStripStatusLabel4_Click);
            this.toolStripStatusLabel4.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.lblTaikhoan);
            this.panel.Controls.Add(this.cbxMaTaiKhoan);
            this.panel.Controls.Add(this.lblDiengiai);
            this.panel.Controls.Add(this.txtDiengiai);
            this.panel.Controls.Add(this.cbxKhoban);
            this.panel.Controls.Add(this.lblKhohang);
            this.panel.Controls.Add(this.lblDinhdangngay);
            this.panel.Controls.Add(this.makNgaychungtu);
            this.panel.Controls.Add(this.lblNgaychungtu);
            this.panel.Controls.Add(this.txtSochungtu);
            this.panel.Controls.Add(this.lblSochungtu);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(758, 122);
            this.panel.TabIndex = 1;
            // 
            // lblTaikhoan
            // 
            this.lblTaikhoan.AutoSize = true;
            this.lblTaikhoan.Location = new System.Drawing.Point(425, 42);
            this.lblTaikhoan.Name = "lblTaikhoan";
            this.lblTaikhoan.Size = new System.Drawing.Size(112, 13);
            this.lblTaikhoan.TabIndex = 43;
            this.lblTaikhoan.Text = "Tài khoản ngân hàng:";
            // 
            // cbxMaTaiKhoan
            // 
            this.cbxMaTaiKhoan.BackColor = System.Drawing.Color.White;
            this.cbxMaTaiKhoan.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbxMaTaiKhoan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMaTaiKhoan.Location = new System.Drawing.Point(543, 39);
            this.cbxMaTaiKhoan.Name = "cbxMaTaiKhoan";
            this.cbxMaTaiKhoan.Size = new System.Drawing.Size(198, 21);
            this.cbxMaTaiKhoan.TabIndex = 42;
            // 
            // lblDiengiai
            // 
            this.lblDiengiai.AutoSize = true;
            this.lblDiengiai.Location = new System.Drawing.Point(17, 68);
            this.lblDiengiai.Name = "lblDiengiai";
            this.lblDiengiai.Size = new System.Drawing.Size(51, 13);
            this.lblDiengiai.TabIndex = 30;
            this.lblDiengiai.Text = "Diễn giải:";
            // 
            // txtDiengiai
            // 
            this.txtDiengiai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiengiai.Location = new System.Drawing.Point(96, 66);
            this.txtDiengiai.Multiline = true;
            this.txtDiengiai.Name = "txtDiengiai";
            this.txtDiengiai.Size = new System.Drawing.Size(645, 50);
            this.txtDiengiai.TabIndex = 29;
            // 
            // cbxKhoban
            // 
            this.cbxKhoban.BackColor = System.Drawing.Color.White;
            this.cbxKhoban.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbxKhoban.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKhoban.Location = new System.Drawing.Point(96, 39);
            this.cbxKhoban.Name = "cbxKhoban";
            this.cbxKhoban.Size = new System.Drawing.Size(323, 21);
            this.cbxKhoban.TabIndex = 13;
            // 
            // lblKhohang
            // 
            this.lblKhohang.AutoSize = true;
            this.lblKhohang.Location = new System.Drawing.Point(17, 42);
            this.lblKhohang.Name = "lblKhohang";
            this.lblKhohang.Size = new System.Drawing.Size(56, 13);
            this.lblKhohang.TabIndex = 12;
            this.lblKhohang.Text = "Kho hàng:";
            // 
            // lblDinhdangngay
            // 
            this.lblDinhdangngay.AutoSize = true;
            this.lblDinhdangngay.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblDinhdangngay.Location = new System.Drawing.Point(446, 16);
            this.lblDinhdangngay.Name = "lblDinhdangngay";
            this.lblDinhdangngay.Size = new System.Drawing.Size(71, 13);
            this.lblDinhdangngay.TabIndex = 7;
            this.lblDinhdangngay.TabStop = true;
            this.lblDinhdangngay.Text = "(dd/mm/yyyy)";
            // 
            // makNgaychungtu
            // 
            this.makNgaychungtu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.makNgaychungtu.Location = new System.Drawing.Point(343, 13);
            this.makNgaychungtu.Mask = "00/00/0000";
            this.makNgaychungtu.Name = "makNgaychungtu";
            this.makNgaychungtu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.makNgaychungtu.Size = new System.Drawing.Size(100, 20);
            this.makNgaychungtu.TabIndex = 6;
            this.makNgaychungtu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNgaychungtu
            // 
            this.lblNgaychungtu.AutoSize = true;
            this.lblNgaychungtu.Location = new System.Drawing.Point(251, 16);
            this.lblNgaychungtu.Name = "lblNgaychungtu";
            this.lblNgaychungtu.Size = new System.Drawing.Size(80, 13);
            this.lblNgaychungtu.TabIndex = 5;
            this.lblNgaychungtu.Text = "Ngày chứng từ:";
            // 
            // txtSochungtu
            // 
            this.txtSochungtu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSochungtu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSochungtu.Location = new System.Drawing.Point(96, 12);
            this.txtSochungtu.Name = "txtSochungtu";
            this.txtSochungtu.ReadOnly = true;
            this.txtSochungtu.Size = new System.Drawing.Size(136, 20);
            this.txtSochungtu.TabIndex = 2;
            // 
            // lblSochungtu
            // 
            this.lblSochungtu.AutoSize = true;
            this.lblSochungtu.Location = new System.Drawing.Point(13, 15);
            this.lblSochungtu.Name = "lblSochungtu";
            this.lblSochungtu.Size = new System.Drawing.Size(65, 13);
            this.lblSochungtu.TabIndex = 0;
            this.lblSochungtu.Text = "Mã kiểm kê:";
            // 
            // grbDataGridview
            // 
            this.grbDataGridview.Controls.Add(this.dgvInsertOrder);
            this.grbDataGridview.Controls.Add(this.palThem);
            this.grbDataGridview.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbDataGridview.Location = new System.Drawing.Point(0, 0);
            this.grbDataGridview.Name = "grbDataGridview";
            this.grbDataGridview.Size = new System.Drawing.Size(758, 218);
            this.grbDataGridview.TabIndex = 0;
            this.grbDataGridview.TabStop = false;
            // 
            // dgvInsertOrder
            // 
            this.dgvInsertOrder.AllowUserToAddRows = false;
            this.dgvInsertOrder.AllowUserToDeleteRows = false;
            this.dgvInsertOrder.BackgroundColor = System.Drawing.Color.White;
            this.dgvInsertOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsertOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInsertOrder.Location = new System.Drawing.Point(3, 42);
            this.dgvInsertOrder.Name = "dgvInsertOrder";
            this.dgvInsertOrder.ReadOnly = true;
            this.dgvInsertOrder.Size = new System.Drawing.Size(752, 173);
            this.dgvInsertOrder.TabIndex = 0;
            // 
            // palThem
            // 
            this.palThem.Controls.Add(this.toolStrip_Insert);
            this.palThem.Dock = System.Windows.Forms.DockStyle.Top;
            this.palThem.Location = new System.Drawing.Point(3, 16);
            this.palThem.Name = "palThem";
            this.palThem.Size = new System.Drawing.Size(752, 26);
            this.palThem.TabIndex = 3;
            // 
            // toolStrip_Insert
            // 
            this.toolStrip_Insert.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_Insert.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_txtTracuu,
            this.toolStrip_txtTenhang,
            this.toolStrip_txtTonkho,
            this.toolStrip_txtTonThucTe,
            this.toolStrip_txtLyDo,
            this.toolStrip_btnThem});
            this.toolStrip_Insert.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Insert.Name = "toolStrip_Insert";
            this.toolStrip_Insert.Size = new System.Drawing.Size(752, 25);
            this.toolStrip_Insert.TabIndex = 2;
            this.toolStrip_Insert.Text = "toolStrip1";
            // 
            // toolStrip_txtTracuu
            // 
            this.toolStrip_txtTracuu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtTracuu.Name = "toolStrip_txtTracuu";
            this.toolStrip_txtTracuu.Size = new System.Drawing.Size(100, 25);
            this.toolStrip_txtTracuu.Text = "<F4 - Tra cứu>";
            this.toolStrip_txtTracuu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_txtTracuu_KeyDown);
            // 
            // toolStrip_txtTenhang
            // 
            this.toolStrip_txtTenhang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStrip_txtTenhang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtTenhang.Name = "toolStrip_txtTenhang";
            this.toolStrip_txtTenhang.ReadOnly = true;
            this.toolStrip_txtTenhang.Size = new System.Drawing.Size(200, 25);
            // 
            // toolStrip_txtTonkho
            // 
            this.toolStrip_txtTonkho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStrip_txtTonkho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtTonkho.Name = "toolStrip_txtTonkho";
            this.toolStrip_txtTonkho.ReadOnly = true;
            this.toolStrip_txtTonkho.Size = new System.Drawing.Size(80, 25);
            this.toolStrip_txtTonkho.Text = "0";
            this.toolStrip_txtTonkho.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // toolStrip_txtTonThucTe
            // 
            this.toolStrip_txtTonThucTe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtTonThucTe.Name = "toolStrip_txtTonThucTe";
            this.toolStrip_txtTonThucTe.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip_txtTonThucTe.Size = new System.Drawing.Size(60, 25);
            this.toolStrip_txtTonThucTe.Text = "1";
            this.toolStrip_txtTonThucTe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStrip_txtTonThucTe_KeyPress);
            // 
            // toolStrip_txtLyDo
            // 
            this.toolStrip_txtLyDo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtLyDo.Name = "toolStrip_txtLyDo";
            this.toolStrip_txtLyDo.Size = new System.Drawing.Size(160, 25);
            this.toolStrip_txtLyDo.Text = "Chưa có lý do";
            // 
            // toolStrip_btnThem
            // 
            this.toolStrip_btnThem.Image = global::GUI.Properties.Resources.Them;
            this.toolStrip_btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnThem.Name = "toolStrip_btnThem";
            this.toolStrip_btnThem.Size = new System.Drawing.Size(58, 22);
            this.toolStrip_btnThem.Text = "Thêm";
            this.toolStrip_btnThem.Click += new System.EventHandler(this.toolStrip_btnThem_Click);
            // 
            // txtPhantrang
            // 
            this.txtPhantrang.BackColor = System.Drawing.Color.White;
            this.txtPhantrang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhantrang.ForeColor = System.Drawing.Color.Red;
            this.txtPhantrang.Location = new System.Drawing.Point(3, 225);
            this.txtPhantrang.Name = "txtPhantrang";
            this.txtPhantrang.ReadOnly = true;
            this.txtPhantrang.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPhantrang.Size = new System.Drawing.Size(49, 20);
            this.txtPhantrang.TabIndex = 1;
            this.txtPhantrang.Text = "0/0";
            this.txtPhantrang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblGiamgia_Tienhang
            // 
            this.lblGiamgia_Tienhang.AutoSize = true;
            this.lblGiamgia_Tienhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiamgia_Tienhang.Location = new System.Drawing.Point(461, 231);
            this.lblGiamgia_Tienhang.Name = "lblGiamgia_Tienhang";
            this.lblGiamgia_Tienhang.Size = new System.Drawing.Size(76, 13);
            this.lblGiamgia_Tienhang.TabIndex = 2;
            this.lblGiamgia_Tienhang.Text = "Tổng giá trị:";
            // 
            // txtTienhang
            // 
            this.txtTienhang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTienhang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTienhang.Location = new System.Drawing.Point(543, 224);
            this.txtTienhang.Name = "txtTienhang";
            this.txtTienhang.ReadOnly = true;
            this.txtTienhang.Size = new System.Drawing.Size(206, 20);
            this.txtTienhang.TabIndex = 4;
            this.txtTienhang.Text = "0";
            this.txtTienhang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // palXem
            // 
            this.palXem.Controls.Add(this.txtTienhang);
            this.palXem.Controls.Add(this.lblGiamgia_Tienhang);
            this.palXem.Controls.Add(this.txtPhantrang);
            this.palXem.Controls.Add(this.grbDataGridview);
            this.palXem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palXem.Location = new System.Drawing.Point(0, 122);
            this.palXem.Name = "palXem";
            this.palXem.Size = new System.Drawing.Size(758, 249);
            this.palXem.TabIndex = 2;
            // 
            // frmXuLy_KiemKeKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 398);
            this.ControlBox = false;
            this.Controls.Add(this.palXem);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmXuLy_KiemKeKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kiểm kê kho";
            this.Load += new System.EventHandler(this.frmXuLy_KiemKeKho_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.grbDataGridview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsertOrder)).EndInit();
            this.palThem.ResumeLayout(false);
            this.palThem.PerformLayout();
            this.toolStrip_Insert.ResumeLayout(false);
            this.toolStrip_Insert.PerformLayout();
            this.palXem.ResumeLayout(false);
            this.palXem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Themmoi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Ghilai;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.ComboBox cbxKhoban;
        private System.Windows.Forms.Label lblKhohang;
        private System.Windows.Forms.LinkLabel lblDinhdangngay;
        private System.Windows.Forms.MaskedTextBox makNgaychungtu;
        private System.Windows.Forms.Label lblNgaychungtu;
        private System.Windows.Forms.TextBox txtSochungtu;
        private System.Windows.Forms.Label lblSochungtu;
        private System.Windows.Forms.Label lblDiengiai;
        private System.Windows.Forms.TextBox txtDiengiai;
        private System.Windows.Forms.ToolStripMenuItem thiêtLâpThôngSôToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xoaChưngTưHiênThơiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem huyĐơnĐătHangHiênThơiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saoChepChưngTưTưToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saoChepChưngTưSangNhâpHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saoChepChưngTưToolStripMenuItem;
        private System.Windows.Forms.Label lblTaikhoan;
        private System.Windows.Forms.ComboBox cbxMaTaiKhoan;
        private System.Windows.Forms.GroupBox grbDataGridview;
        private System.Windows.Forms.DataGridView dgvInsertOrder;
        private System.Windows.Forms.Panel palThem;
        private System.Windows.Forms.ToolStrip toolStrip_Insert;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTracuu;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTenhang;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTonkho;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTonThucTe;
        private System.Windows.Forms.ToolStripButton toolStrip_btnThem;
        private System.Windows.Forms.TextBox txtPhantrang;
        private System.Windows.Forms.Label lblGiamgia_Tienhang;
        private System.Windows.Forms.TextBox txtTienhang;
        private System.Windows.Forms.Panel palXem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtLyDo;
    }
}