namespace GUI
{
    partial class frmXuLyPhieuXuatHuy
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
            this.components = new System.ComponentModel.Container();
            this.tsslthanhtien = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStrip_txtTracuu = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tssltenhang = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tsslsoluong = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tsslgia = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tsslthem = new System.Windows.Forms.ToolStripButton();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.lblghichu = new System.Windows.Forms.Label();
            this.dtgvsanpham = new System.Windows.Forms.DataGridView();
            this.cbbkhohang = new System.Windows.Forms.ComboBox();
            this.lblkhohang = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txttongtien = new System.Windows.Forms.TextBox();
            this.lbtongtien = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbtinhtrang = new System.Windows.Forms.Label();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.txtnhanvien = new System.Windows.Forms.TextBox();
            this.lblnhanvien = new System.Windows.Forms.Label();
            this.lblngayct = new System.Windows.Forms.Label();
            this.mskngaychungtu = new System.Windows.Forms.MaskedTextBox();
            this.lblngaychungtu = new System.Windows.Forms.Label();
            this.txtsochungtu = new System.Windows.Forms.TextBox();
            this.lblsochungtu = new System.Windows.Forms.Label();
            this.timerRun = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblthemmoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblghilai = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblin = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsddbkhac = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsslbldong = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvsanpham)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsslthanhtien
            // 
            this.tsslthanhtien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tsslthanhtien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsslthanhtien.Name = "tsslthanhtien";
            this.tsslthanhtien.ReadOnly = true;
            this.tsslthanhtien.Size = new System.Drawing.Size(130, 25);
            this.tsslthanhtien.Text = "0";
            this.tsslthanhtien.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tsslthanhtien.ToolTipText = "Thành tiền";
            this.tsslthanhtien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btntimkiem_KeyUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_txtTracuu,
            this.toolStripLabel1,
            this.tssltenhang,
            this.toolStripLabel4,
            this.tsslsoluong,
            this.toolStripLabel2,
            this.tsslgia,
            this.toolStripLabel3,
            this.tsslthanhtien,
            this.tsslthem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(813, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStrip_txtTracuu
            // 
            this.toolStrip_txtTracuu.BackColor = System.Drawing.Color.White;
            this.toolStrip_txtTracuu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtTracuu.Name = "toolStrip_txtTracuu";
            this.toolStrip_txtTracuu.Size = new System.Drawing.Size(100, 25);
            this.toolStrip_txtTracuu.Text = "<F4 - Tra Cứu>";
            this.toolStrip_txtTracuu.ToolTipText = "Mã hàng hóa";
            this.toolStrip_txtTracuu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsslhanghoa_KeyUp);
            this.toolStrip_txtTracuu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStrip_txtTracuu_KeyPress);
            this.toolStrip_txtTracuu.Click += new System.EventHandler(this.toolStrip_txtTracuu_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel1.Text = "Tên:";
            // 
            // tssltenhang
            // 
            this.tssltenhang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tssltenhang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tssltenhang.Name = "tssltenhang";
            this.tssltenhang.ReadOnly = true;
            this.tssltenhang.Size = new System.Drawing.Size(200, 25);
            this.tssltenhang.ToolTipText = "Tên hàng hóa";
            this.tssltenhang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btntimkiem_KeyUp);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(24, 22);
            this.toolStripLabel4.Text = "SL:";
            // 
            // tsslsoluong
            // 
            this.tsslsoluong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsslsoluong.Name = "tsslsoluong";
            this.tsslsoluong.Size = new System.Drawing.Size(50, 25);
            this.tsslsoluong.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tsslsoluong.ToolTipText = "Số lượng hàng hóa";
            this.tsslsoluong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsslsoluong_KeyUp);
            this.tsslsoluong.TextChanged += new System.EventHandler(this.tstxtsoluong_TextChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(27, 22);
            this.toolStripLabel2.Text = "GN:";
            // 
            // tsslgia
            // 
            this.tsslgia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tsslgia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsslgia.Name = "tsslgia";
            this.tsslgia.ReadOnly = true;
            this.tsslgia.Size = new System.Drawing.Size(120, 25);
            this.tsslgia.Text = "0";
            this.tsslgia.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tsslgia.ToolTipText = "Giá nhập hàng hóa";
            this.tsslgia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btntimkiem_KeyUp);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(25, 22);
            this.toolStripLabel3.Text = "TT:";
            // 
            // tsslthem
            // 
            this.tsslthem.Checked = true;
            this.tsslthem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsslthem.Image = global::GUI.Properties.Resources.Them;
            this.tsslthem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsslthem.Name = "tsslthem";
            this.tsslthem.Size = new System.Drawing.Size(57, 22);
            this.tsslthem.Text = "Thêm";
            this.tsslthem.Click += new System.EventHandler(this.tsslthem_Click);
            // 
            // txtghichu
            // 
            this.txtghichu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtghichu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtghichu.Location = new System.Drawing.Point(86, 76);
            this.txtghichu.MaxLength = 100;
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtghichu.Size = new System.Drawing.Size(418, 56);
            this.txtghichu.TabIndex = 3;
            this.txtghichu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtghichu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtghichu_KeyUp);
            // 
            // lblghichu
            // 
            this.lblghichu.AutoSize = true;
            this.lblghichu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblghichu.Location = new System.Drawing.Point(29, 78);
            this.lblghichu.Name = "lblghichu";
            this.lblghichu.Size = new System.Drawing.Size(51, 15);
            this.lblghichu.TabIndex = 12;
            this.lblghichu.Text = "Ghi chú:";
            // 
            // dtgvsanpham
            // 
            this.dtgvsanpham.BackgroundColor = System.Drawing.Color.White;
            this.dtgvsanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvsanpham.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtgvsanpham.Location = new System.Drawing.Point(0, 29);
            this.dtgvsanpham.Name = "dtgvsanpham";
            this.dtgvsanpham.Size = new System.Drawing.Size(813, 184);
            this.dtgvsanpham.TabIndex = 1;
            this.dtgvsanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvsanpham_CellClick);
            this.dtgvsanpham.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvsanpham_CellDoubleClick);
            this.dtgvsanpham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgvsanpham_KeyUp);
            // 
            // cbbkhohang
            // 
            this.cbbkhohang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbkhohang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbkhohang.FormattingEnabled = true;
            this.cbbkhohang.Location = new System.Drawing.Point(310, 45);
            this.cbbkhohang.Name = "cbbkhohang";
            this.cbbkhohang.Size = new System.Drawing.Size(194, 23);
            this.cbbkhohang.TabIndex = 2;
            this.cbbkhohang.SelectedIndexChanged += new System.EventHandler(this.cbbkhohang_SelectedIndexChanged);
            this.cbbkhohang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbkhohang_KeyUp);
            // 
            // lblkhohang
            // 
            this.lblkhohang.AutoSize = true;
            this.lblkhohang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblkhohang.Location = new System.Drawing.Point(241, 48);
            this.lblkhohang.Name = "lblkhohang";
            this.lblkhohang.Size = new System.Drawing.Size(63, 15);
            this.lblkhohang.TabIndex = 10;
            this.lblkhohang.Text = "Kho hàng:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txttongtien);
            this.panel2.Controls.Add(this.lbtongtien);
            this.panel2.Controls.Add(this.dtgvsanpham);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 156);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(813, 300);
            this.panel2.TabIndex = 3;
            // 
            // txttongtien
            // 
            this.txttongtien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txttongtien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttongtien.Enabled = false;
            this.txttongtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttongtien.Location = new System.Drawing.Point(528, 221);
            this.txttongtien.Name = "txttongtien";
            this.txttongtien.ReadOnly = true;
            this.txttongtien.Size = new System.Drawing.Size(273, 38);
            this.txttongtien.TabIndex = 14;
            this.txttongtien.TabStop = false;
            this.txttongtien.Text = "0";
            this.txttongtien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txttongtien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btntimkiem_KeyUp);
            // 
            // lbtongtien
            // 
            this.lbtongtien.AutoSize = true;
            this.lbtongtien.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtongtien.Location = new System.Drawing.Point(388, 224);
            this.lbtongtien.Name = "lbtongtien";
            this.lbtongtien.Size = new System.Drawing.Size(134, 31);
            this.lbtongtien.TabIndex = 3;
            this.lbtongtien.Text = "Tổng tiền:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(813, 29);
            this.panel3.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbtinhtrang);
            this.panel1.Controls.Add(this.txtghichu);
            this.panel1.Controls.Add(this.lblghichu);
            this.panel1.Controls.Add(this.cbbkhohang);
            this.panel1.Controls.Add(this.lblkhohang);
            this.panel1.Controls.Add(this.btntimkiem);
            this.panel1.Controls.Add(this.txtnhanvien);
            this.panel1.Controls.Add(this.lblnhanvien);
            this.panel1.Controls.Add(this.lblngayct);
            this.panel1.Controls.Add(this.mskngaychungtu);
            this.panel1.Controls.Add(this.lblngaychungtu);
            this.panel1.Controls.Add(this.txtsochungtu);
            this.panel1.Controls.Add(this.lblsochungtu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 156);
            this.panel1.TabIndex = 2;
            // 
            // lbtinhtrang
            // 
            this.lbtinhtrang.AutoSize = true;
            this.lbtinhtrang.BackColor = System.Drawing.Color.White;
            this.lbtinhtrang.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtinhtrang.ForeColor = System.Drawing.Color.Red;
            this.lbtinhtrang.Location = new System.Drawing.Point(644, 10);
            this.lbtinhtrang.Name = "lbtinhtrang";
            this.lbtinhtrang.Size = new System.Drawing.Size(0, 25);
            this.lbtinhtrang.TabIndex = 13;
            // 
            // btntimkiem
            // 
            this.btntimkiem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimkiem.Image = global::GUI.Properties.Resources.button_search1;
            this.btntimkiem.Location = new System.Drawing.Point(183, 41);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(26, 25);
            this.btntimkiem.TabIndex = 1;
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click_1);
            this.btntimkiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btntimkiem_KeyUp);
            // 
            // txtnhanvien
            // 
            this.txtnhanvien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtnhanvien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnhanvien.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnhanvien.Location = new System.Drawing.Point(86, 43);
            this.txtnhanvien.Name = "txtnhanvien";
            this.txtnhanvien.ReadOnly = true;
            this.txtnhanvien.Size = new System.Drawing.Size(91, 22);
            this.txtnhanvien.TabIndex = 8;
            this.txtnhanvien.TabStop = false;
            this.txtnhanvien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblnhanvien
            // 
            this.lblnhanvien.AutoSize = true;
            this.lblnhanvien.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnhanvien.Location = new System.Drawing.Point(15, 46);
            this.lblnhanvien.Name = "lblnhanvien";
            this.lblnhanvien.Size = new System.Drawing.Size(65, 15);
            this.lblnhanvien.TabIndex = 7;
            this.lblnhanvien.Text = "Nhân viên:";
            // 
            // lblngayct
            // 
            this.lblngayct.AutoSize = true;
            this.lblngayct.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblngayct.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblngayct.Location = new System.Drawing.Point(415, 17);
            this.lblngayct.Name = "lblngayct";
            this.lblngayct.Size = new System.Drawing.Size(83, 15);
            this.lblngayct.TabIndex = 6;
            this.lblngayct.Text = "(dd/mm/yyyy)";
            // 
            // mskngaychungtu
            // 
            this.mskngaychungtu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mskngaychungtu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskngaychungtu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskngaychungtu.Location = new System.Drawing.Point(310, 15);
            this.mskngaychungtu.Mask = "00/00/0000";
            this.mskngaychungtu.Name = "mskngaychungtu";
            this.mskngaychungtu.ReadOnly = true;
            this.mskngaychungtu.Size = new System.Drawing.Size(99, 22);
            this.mskngaychungtu.TabIndex = 5;
            this.mskngaychungtu.TabStop = false;
            this.mskngaychungtu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mskngaychungtu.ValidatingType = typeof(System.DateTime);
            // 
            // lblngaychungtu
            // 
            this.lblngaychungtu.AutoSize = true;
            this.lblngaychungtu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblngaychungtu.Location = new System.Drawing.Point(211, 18);
            this.lblngaychungtu.Name = "lblngaychungtu";
            this.lblngaychungtu.Size = new System.Drawing.Size(90, 15);
            this.lblngaychungtu.TabIndex = 4;
            this.lblngaychungtu.Text = "Ngày chứng từ:";
            // 
            // txtsochungtu
            // 
            this.txtsochungtu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtsochungtu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsochungtu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsochungtu.Location = new System.Drawing.Point(86, 13);
            this.txtsochungtu.Name = "txtsochungtu";
            this.txtsochungtu.ReadOnly = true;
            this.txtsochungtu.Size = new System.Drawing.Size(91, 22);
            this.txtsochungtu.TabIndex = 3;
            this.txtsochungtu.TabStop = false;
            this.txtsochungtu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblsochungtu
            // 
            this.lblsochungtu.AutoSize = true;
            this.lblsochungtu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsochungtu.Location = new System.Drawing.Point(5, 17);
            this.lblsochungtu.Name = "lblsochungtu";
            this.lblsochungtu.Size = new System.Drawing.Size(75, 15);
            this.lblsochungtu.TabIndex = 2;
            this.lblsochungtu.Text = "Số chứng từ:";
            // 
            // timerRun
            // 
            this.timerRun.Tick += new System.EventHandler(this.timerRun_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblthemmoi,
            this.tsslblghilai,
            this.tsslblin,
            this.tsddbkhac,
            this.tsslbldong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 430);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(813, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslblthemmoi
            // 
            this.tsslblthemmoi.Image = global::GUI.Properties.Resources.Them;
            this.tsslblthemmoi.Name = "tsslblthemmoi";
            this.tsslblthemmoi.Size = new System.Drawing.Size(266, 21);
            this.tsslblthemmoi.Spring = true;
            this.tsslblthemmoi.Text = "Thêm";
            this.tsslblthemmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslblthemmoi.Click += new System.EventHandler(this.tsslblthemmoi_Click);
            this.tsslblthemmoi.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslblthemmoi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslblghilai
            // 
            this.tsslblghilai.Image = global::GUI.Properties.Resources.Luu;
            this.tsslblghilai.Name = "tsslblghilai";
            this.tsslblghilai.Size = new System.Drawing.Size(266, 21);
            this.tsslblghilai.Spring = true;
            this.tsslblghilai.Text = "Sửa";
            this.tsslblghilai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslblghilai.Click += new System.EventHandler(this.tsslblghilai_Click);
            this.tsslblghilai.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslblghilai.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslblin
            // 
            this.tsslblin.Image = global::GUI.Properties.Resources.In;
            this.tsslblin.Name = "tsslblin";
            this.tsslblin.Size = new System.Drawing.Size(144, 22);
            this.tsslblin.Spring = true;
            this.tsslblin.Text = "In";
            this.tsslblin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslblin.Visible = false;
            this.tsslblin.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslblin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsddbkhac
            // 
            this.tsddbkhac.Image = global::GUI.Properties.Resources.khac;
            this.tsddbkhac.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbkhac.Name = "tsddbkhac";
            this.tsddbkhac.Size = new System.Drawing.Size(222, 25);
            this.tsddbkhac.Text = "Xác nhận phiếu xuất hủy";
            this.tsddbkhac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsddbkhac.Visible = false;
            this.tsddbkhac.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsddbkhac.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslbldong
            // 
            this.tsslbldong.Image = global::GUI.Properties.Resources.Xoa;
            this.tsslbldong.Name = "tsslbldong";
            this.tsslbldong.Size = new System.Drawing.Size(266, 21);
            this.tsslbldong.Spring = true;
            this.tsslbldong.Text = "Trở về";
            this.tsslbldong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslbldong.Click += new System.EventHandler(this.tsslbldong_Click);
            this.tsslbldong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslbldong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // frmXuLyPhieuXuatHuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 456);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmXuLyPhieuXuatHuy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Phiếu Xuất Hủy";
            this.Load += new System.EventHandler(this.frmXuLyPhieuXuatHuy_Load);
            this.Resize += new System.EventHandler(this.frmXuLyPhieuXuatHuy_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvsanpham)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripTextBox tsslthanhtien;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTracuu;
        private System.Windows.Forms.ToolStripTextBox tsslsoluong;
        private System.Windows.Forms.ToolStripTextBox tsslgia;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.Label lblghichu;
        private System.Windows.Forms.DataGridView dtgvsanpham;
        private System.Windows.Forms.ComboBox cbbkhohang;
        private System.Windows.Forms.Label lblkhohang;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtnhanvien;
        private System.Windows.Forms.Label lblnhanvien;
        private System.Windows.Forms.Label lblngayct;
        private System.Windows.Forms.MaskedTextBox mskngaychungtu;
        private System.Windows.Forms.Label lblngaychungtu;
        private System.Windows.Forms.TextBox txtsochungtu;
        private System.Windows.Forms.Label lblsochungtu;
        private System.Windows.Forms.TextBox txttongtien;
        private System.Windows.Forms.Label lbtongtien;
        private System.Windows.Forms.ToolStripButton tsslthem;
        private System.Windows.Forms.ToolStripTextBox tssltenhang;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.Timer timerRun;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.Label lbtinhtrang;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblthemmoi;
        private System.Windows.Forms.ToolStripStatusLabel tsslblghilai;
        private System.Windows.Forms.ToolStripStatusLabel tsslblin;
        private System.Windows.Forms.ToolStripDropDownButton tsddbkhac;
        private System.Windows.Forms.ToolStripStatusLabel tsslbldong;

    }
}