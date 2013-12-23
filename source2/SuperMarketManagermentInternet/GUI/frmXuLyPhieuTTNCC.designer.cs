namespace GUI
{
    partial class frmXuLyPhieuTTNCC
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
            this.txttongthanhtoan = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbtongthanhtoan = new System.Windows.Forms.Label();
            this.dtgvNCC = new System.Windows.Forms.DataGridView();
            this.txtdiengiai = new System.Windows.Forms.TextBox();
            this.txtnguoinhaptien = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip_Insert = new System.Windows.Forms.ToolStrip();
            this.toolStrip_txtTracuu = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tssltongthanhtoan = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tsslsono = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.tsslthanhtoan = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip_btnThem = new System.Windows.Forms.ToolStripButton();
            this.lbncc = new System.Windows.Forms.Label();
            this.btntimkh = new System.Windows.Forms.Button();
            this.cbbtientetygia = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.mskngaychungtu = new System.Windows.Forms.MaskedTextBox();
            this.txttientetygia = new System.Windows.Forms.TextBox();
            this.txtnohienthoi = new System.Windows.Forms.TextBox();
            this.txtmancc = new System.Windows.Forms.TextBox();
            this.txtsochungtu = new System.Windows.Forms.TextBox();
            this.lbtientetygia = new System.Windows.Forms.Label();
            this.lbnohientai = new System.Windows.Forms.Label();
            this.lbngaychungtu = new System.Windows.Forms.Label();
            this.lbdiengiai = new System.Windows.Forms.Label();
            this.lbtennguoinoptien = new System.Windows.Forms.Label();
            this.lbmancc = new System.Windows.Forms.Label();
            this.lbsochungtu = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslthem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslsua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslin = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tssltrove = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNCC)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStrip_Insert.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txttongthanhtoan
            // 
            this.txttongthanhtoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txttongthanhtoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttongthanhtoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttongthanhtoan.Location = new System.Drawing.Point(452, 255);
            this.txttongthanhtoan.Name = "txttongthanhtoan";
            this.txttongthanhtoan.ReadOnly = true;
            this.txttongthanhtoan.Size = new System.Drawing.Size(269, 38);
            this.txttongthanhtoan.TabIndex = 15;
            this.txttongthanhtoan.TabStop = false;
            this.txttongthanhtoan.Text = "0";
            this.txttongthanhtoan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.txttongthanhtoan);
            this.panel2.Controls.Add(this.lbtongthanhtoan);
            this.panel2.Controls.Add(this.dtgvNCC);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(733, 350);
            this.panel2.TabIndex = 5;
            // 
            // lbtongthanhtoan
            // 
            this.lbtongthanhtoan.AutoSize = true;
            this.lbtongthanhtoan.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtongthanhtoan.Location = new System.Drawing.Point(229, 258);
            this.lbtongthanhtoan.Name = "lbtongthanhtoan";
            this.lbtongthanhtoan.Size = new System.Drawing.Size(217, 31);
            this.lbtongthanhtoan.TabIndex = 7;
            this.lbtongthanhtoan.Text = "Tổng thanh toán:";
            // 
            // dtgvNCC
            // 
            this.dtgvNCC.BackgroundColor = System.Drawing.Color.White;
            this.dtgvNCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvNCC.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtgvNCC.Location = new System.Drawing.Point(0, 0);
            this.dtgvNCC.Name = "dtgvNCC";
            this.dtgvNCC.Size = new System.Drawing.Size(733, 214);
            this.dtgvNCC.TabIndex = 0;
            this.dtgvNCC.TabStop = false;
            this.dtgvNCC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvNCC_CellClick);
            this.dtgvNCC.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvNCC_CellDoubleClick);
            // 
            // txtdiengiai
            // 
            this.txtdiengiai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdiengiai.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdiengiai.Location = new System.Drawing.Point(115, 88);
            this.txtdiengiai.MaxLength = 100;
            this.txtdiengiai.Name = "txtdiengiai";
            this.txtdiengiai.Size = new System.Drawing.Size(615, 22);
            this.txtdiengiai.TabIndex = 4;
            // 
            // txtnguoinhaptien
            // 
            this.txtnguoinhaptien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnguoinhaptien.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnguoinhaptien.Location = new System.Drawing.Point(115, 60);
            this.txtnguoinhaptien.MaxLength = 100;
            this.txtnguoinhaptien.Name = "txtnguoinhaptien";
            this.txtnguoinhaptien.Size = new System.Drawing.Size(100, 22);
            this.txtnguoinhaptien.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.toolStrip_Insert);
            this.panel1.Controls.Add(this.lbncc);
            this.panel1.Controls.Add(this.btntimkh);
            this.panel1.Controls.Add(this.cbbtientetygia);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.mskngaychungtu);
            this.panel1.Controls.Add(this.txttientetygia);
            this.panel1.Controls.Add(this.txtnohienthoi);
            this.panel1.Controls.Add(this.txtdiengiai);
            this.panel1.Controls.Add(this.txtnguoinhaptien);
            this.panel1.Controls.Add(this.txtmancc);
            this.panel1.Controls.Add(this.txtsochungtu);
            this.panel1.Controls.Add(this.lbtientetygia);
            this.panel1.Controls.Add(this.lbnohientai);
            this.panel1.Controls.Add(this.lbngaychungtu);
            this.panel1.Controls.Add(this.lbdiengiai);
            this.panel1.Controls.Add(this.lbtennguoinoptien);
            this.panel1.Controls.Add(this.lbmancc);
            this.panel1.Controls.Add(this.lbsochungtu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 150);
            this.panel1.TabIndex = 4;
            // 
            // toolStrip_Insert
            // 
            this.toolStrip_Insert.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip_Insert.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip_Insert.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_Insert.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_txtTracuu,
            this.toolStripLabel1,
            this.tssltongthanhtoan,
            this.toolStripLabel4,
            this.tsslsono,
            this.toolStripLabel5,
            this.tsslthanhtoan,
            this.toolStrip_btnThem});
            this.toolStrip_Insert.Location = new System.Drawing.Point(0, 125);
            this.toolStrip_Insert.Name = "toolStrip_Insert";
            this.toolStrip_Insert.Size = new System.Drawing.Size(733, 25);
            this.toolStrip_Insert.TabIndex = 5;
            this.toolStrip_Insert.TabStop = true;
            this.toolStrip_Insert.Text = "toolStrip1";
            // 
            // toolStrip_txtTracuu
            // 
            this.toolStrip_txtTracuu.BackColor = System.Drawing.Color.White;
            this.toolStrip_txtTracuu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtTracuu.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.toolStrip_txtTracuu.Name = "toolStrip_txtTracuu";
            this.toolStrip_txtTracuu.ReadOnly = true;
            this.toolStrip_txtTracuu.Size = new System.Drawing.Size(100, 25);
            this.toolStrip_txtTracuu.Text = "<F4-Tra cứu>";
            this.toolStrip_txtTracuu.ToolTipText = "Mã hóa đơn";
            this.toolStrip_txtTracuu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_txtTracuu_KeyUp);
            this.toolStrip_txtTracuu.Click += new System.EventHandler(this.toolStrip_txtTracuu_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel1.Text = "Tổng:";
            // 
            // tssltongthanhtoan
            // 
            this.tssltongthanhtoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tssltongthanhtoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tssltongthanhtoan.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.tssltongthanhtoan.Name = "tssltongthanhtoan";
            this.tssltongthanhtoan.ReadOnly = true;
            this.tssltongthanhtoan.Size = new System.Drawing.Size(140, 25);
            this.tssltongthanhtoan.ToolTipText = "Tổng hóa đơn";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(41, 22);
            this.toolStripLabel4.Text = "Số nợ:";
            // 
            // tsslsono
            // 
            this.tsslsono.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tsslsono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsslsono.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.tsslsono.Name = "tsslsono";
            this.tsslsono.ReadOnly = true;
            this.tsslsono.Size = new System.Drawing.Size(100, 25);
            this.tsslsono.ToolTipText = "Nợ phải trả";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(72, 22);
            this.toolStripLabel5.Text = "Thanh toán:";
            // 
            // tsslthanhtoan
            // 
            this.tsslthanhtoan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsslthanhtoan.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.tsslthanhtoan.Name = "tsslthanhtoan";
            this.tsslthanhtoan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tsslthanhtoan.Size = new System.Drawing.Size(140, 25);
            this.tsslthanhtoan.ToolTipText = "Số tiền thanh toán";
            this.tsslthanhtoan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsslthanhtoan_KeyUp);
            this.tsslthanhtoan.Click += new System.EventHandler(this.tsslthanhtoan_Click);
            this.tsslthanhtoan.TextChanged += new System.EventHandler(this.tsslthanhtoan_TextChanged);
            // 
            // toolStrip_btnThem
            // 
            this.toolStrip_btnThem.Checked = true;
            this.toolStrip_btnThem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStrip_btnThem.Image = global::GUI.Properties.Resources.Them;
            this.toolStrip_btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnThem.Name = "toolStrip_btnThem";
            this.toolStrip_btnThem.Size = new System.Drawing.Size(57, 22);
            this.toolStrip_btnThem.Text = "Thêm";
            this.toolStrip_btnThem.Click += new System.EventHandler(this.toolStrip_btnThem_Click);
            // 
            // lbncc
            // 
            this.lbncc.AutoSize = true;
            this.lbncc.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbncc.ForeColor = System.Drawing.Color.Blue;
            this.lbncc.Location = new System.Drawing.Point(253, 37);
            this.lbncc.Name = "lbncc";
            this.lbncc.Size = new System.Drawing.Size(0, 15);
            this.lbncc.TabIndex = 25;
            // 
            // btntimkh
            // 
            this.btntimkh.FlatAppearance.BorderSize = 0;
            this.btntimkh.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimkh.Image = global::GUI.Properties.Resources.button_search;
            this.btntimkh.Location = new System.Drawing.Point(223, 31);
            this.btntimkh.Name = "btntimkh";
            this.btntimkh.Size = new System.Drawing.Size(24, 25);
            this.btntimkh.TabIndex = 1;
            this.btntimkh.TabStop = false;
            this.btntimkh.UseVisualStyleBackColor = true;
            this.btntimkh.Click += new System.EventHandler(this.btntimkh_Click_1);
            // 
            // cbbtientetygia
            // 
            this.cbbtientetygia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbtientetygia.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbtientetygia.FormattingEnabled = true;
            this.cbbtientetygia.Items.AddRange(new object[] {
            "VND"});
            this.cbbtientetygia.Location = new System.Drawing.Point(315, 57);
            this.cbbtientetygia.Name = "cbbtientetygia";
            this.cbbtientetygia.Size = new System.Drawing.Size(83, 23);
            this.cbbtientetygia.TabIndex = 3;
            this.cbbtientetygia.SelectedIndexChanged += new System.EventHandler(this.cbbtientetygia_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(390, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 15);
            this.label11.TabIndex = 20;
            this.label11.Text = "(dd/mm/yyyy)";
            // 
            // mskngaychungtu
            // 
            this.mskngaychungtu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mskngaychungtu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskngaychungtu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskngaychungtu.Location = new System.Drawing.Point(314, 6);
            this.mskngaychungtu.Mask = "00/00/0000";
            this.mskngaychungtu.Name = "mskngaychungtu";
            this.mskngaychungtu.ReadOnly = true;
            this.mskngaychungtu.Size = new System.Drawing.Size(70, 22);
            this.mskngaychungtu.TabIndex = 19;
            this.mskngaychungtu.TabStop = false;
            this.mskngaychungtu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mskngaychungtu.ValidatingType = typeof(System.DateTime);
            // 
            // txttientetygia
            // 
            this.txttientetygia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txttientetygia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttientetygia.Enabled = false;
            this.txttientetygia.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttientetygia.Location = new System.Drawing.Point(404, 58);
            this.txttientetygia.Name = "txttientetygia";
            this.txttientetygia.Size = new System.Drawing.Size(100, 22);
            this.txttientetygia.TabIndex = 18;
            this.txttientetygia.TabStop = false;
            // 
            // txtnohienthoi
            // 
            this.txtnohienthoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtnohienthoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnohienthoi.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnohienthoi.Location = new System.Drawing.Point(630, 6);
            this.txtnohienthoi.Name = "txtnohienthoi";
            this.txtnohienthoi.ReadOnly = true;
            this.txtnohienthoi.Size = new System.Drawing.Size(100, 22);
            this.txtnohienthoi.TabIndex = 17;
            this.txtnohienthoi.TabStop = false;
            this.txtnohienthoi.Text = "0";
            this.txtnohienthoi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtmancc
            // 
            this.txtmancc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtmancc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmancc.Enabled = false;
            this.txtmancc.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmancc.Location = new System.Drawing.Point(115, 33);
            this.txtmancc.Name = "txtmancc";
            this.txtmancc.ReadOnly = true;
            this.txtmancc.Size = new System.Drawing.Size(100, 22);
            this.txtmancc.TabIndex = 13;
            this.txtmancc.TabStop = false;
            // 
            // txtsochungtu
            // 
            this.txtsochungtu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtsochungtu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsochungtu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsochungtu.Location = new System.Drawing.Point(115, 6);
            this.txtsochungtu.Name = "txtsochungtu";
            this.txtsochungtu.ReadOnly = true;
            this.txtsochungtu.Size = new System.Drawing.Size(100, 22);
            this.txtsochungtu.TabIndex = 12;
            this.txtsochungtu.TabStop = false;
            // 
            // lbtientetygia
            // 
            this.lbtientetygia.AutoSize = true;
            this.lbtientetygia.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtientetygia.Location = new System.Drawing.Point(221, 62);
            this.lbtientetygia.Name = "lbtientetygia";
            this.lbtientetygia.Size = new System.Drawing.Size(88, 15);
            this.lbtientetygia.TabIndex = 11;
            this.lbtientetygia.Text = "Tiền tệ /Tỷ giá:";
            // 
            // lbnohientai
            // 
            this.lbnohientai.AutoSize = true;
            this.lbnohientai.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnohientai.Location = new System.Drawing.Point(548, 9);
            this.lbnohientai.Name = "lbnohientai";
            this.lbnohientai.Size = new System.Drawing.Size(76, 15);
            this.lbnohientai.TabIndex = 10;
            this.lbnohientai.Text = "Nợ hiện thời:";
            // 
            // lbngaychungtu
            // 
            this.lbngaychungtu.AutoSize = true;
            this.lbngaychungtu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbngaychungtu.Location = new System.Drawing.Point(218, 10);
            this.lbngaychungtu.Name = "lbngaychungtu";
            this.lbngaychungtu.Size = new System.Drawing.Size(90, 15);
            this.lbngaychungtu.TabIndex = 8;
            this.lbngaychungtu.Text = "Ngày chứng từ:";
            // 
            // lbdiengiai
            // 
            this.lbdiengiai.AutoSize = true;
            this.lbdiengiai.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdiengiai.Location = new System.Drawing.Point(58, 90);
            this.lbdiengiai.Name = "lbdiengiai";
            this.lbdiengiai.Size = new System.Drawing.Size(51, 15);
            this.lbdiengiai.TabIndex = 5;
            this.lbdiengiai.Text = "Ghi chú:";
            // 
            // lbtennguoinoptien
            // 
            this.lbtennguoinoptien.AutoSize = true;
            this.lbtennguoinoptien.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtennguoinoptien.Location = new System.Drawing.Point(13, 62);
            this.lbtennguoinoptien.Name = "lbtennguoinoptien";
            this.lbtennguoinoptien.Size = new System.Drawing.Size(96, 15);
            this.lbtennguoinoptien.TabIndex = 4;
            this.lbtennguoinoptien.Text = "Người nhận tiền:";
            // 
            // lbmancc
            // 
            this.lbmancc.AutoSize = true;
            this.lbmancc.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbmancc.Location = new System.Drawing.Point(25, 37);
            this.lbmancc.Name = "lbmancc";
            this.lbmancc.Size = new System.Drawing.Size(84, 15);
            this.lbmancc.TabIndex = 3;
            this.lbmancc.Text = "Nhà cung cấp:";
            // 
            // lbsochungtu
            // 
            this.lbsochungtu.AutoSize = true;
            this.lbsochungtu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsochungtu.Location = new System.Drawing.Point(34, 10);
            this.lbsochungtu.Name = "lbsochungtu";
            this.lbsochungtu.Size = new System.Drawing.Size(75, 15);
            this.lbsochungtu.TabIndex = 2;
            this.lbsochungtu.Text = "Số chứng từ:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslthem,
            this.tsslsua,
            this.tsslin,
            this.toolStripDropDownButton1,
            this.tssltrove});
            this.statusStrip1.Location = new System.Drawing.Point(0, 474);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(733, 26);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslthem
            // 
            this.tsslthem.Image = global::GUI.Properties.Resources.Them;
            this.tsslthem.Name = "tsslthem";
            this.tsslthem.Size = new System.Drawing.Size(239, 21);
            this.tsslthem.Spring = true;
            this.tsslthem.Text = "&Thêm";
            this.tsslthem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslthem.Click += new System.EventHandler(this.tsslthemmoi_Click);
            this.tsslthem.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslthem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslsua
            // 
            this.tsslsua.Image = global::GUI.Properties.Resources.Sua;
            this.tsslsua.Name = "tsslsua";
            this.tsslsua.Size = new System.Drawing.Size(160, 22);
            this.tsslsua.Spring = true;
            this.tsslsua.Text = "&Sửa";
            this.tsslsua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslsua.Visible = false;
            this.tsslsua.Click += new System.EventHandler(this.tsslsua_Click);
            this.tsslsua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslsua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslin
            // 
            this.tsslin.Image = global::GUI.Properties.Resources.In;
            this.tsslin.Name = "tsslin";
            this.tsslin.Size = new System.Drawing.Size(239, 21);
            this.tsslin.Spring = true;
            this.tsslin.Text = "&In";
            this.tsslin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslin.Click += new System.EventHandler(this.tsslin_Click);
            this.tsslin.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Image = global::GUI.Properties.Resources.khac;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(78, 25);
            this.toolStripDropDownButton1.Text = "Khác";
            this.toolStripDropDownButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripDropDownButton1.Visible = false;
            this.toolStripDropDownButton1.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripDropDownButton1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssltrove
            // 
            this.tssltrove.Image = global::GUI.Properties.Resources.Tro_ve;
            this.tssltrove.Name = "tssltrove";
            this.tssltrove.Size = new System.Drawing.Size(239, 21);
            this.tssltrove.Spring = true;
            this.tssltrove.Text = "Trở &về";
            this.tssltrove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssltrove.Click += new System.EventHandler(this.tssltrove_Click);
            this.tssltrove.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssltrove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // frmXuLyPhieuTTNCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 500);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmXuLyPhieuTTNCC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Phiếu Thanh Toán Nhà  Cung Cấp";
            this.Resize += new System.EventHandler(this.frmXuLyPhieuTTNCC_Resize);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvNCC)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip_Insert.ResumeLayout(false);
            this.toolStrip_Insert.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txttongthanhtoan;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbtongthanhtoan;
        private System.Windows.Forms.DataGridView dtgvNCC;
        private System.Windows.Forms.TextBox txtdiengiai;
        private System.Windows.Forms.TextBox txtnguoinhaptien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btntimkh;
        private System.Windows.Forms.ComboBox cbbtientetygia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox mskngaychungtu;
        private System.Windows.Forms.TextBox txttientetygia;
        private System.Windows.Forms.TextBox txtnohienthoi;
        private System.Windows.Forms.TextBox txtmancc;
        private System.Windows.Forms.TextBox txtsochungtu;
        private System.Windows.Forms.Label lbtientetygia;
        private System.Windows.Forms.Label lbnohientai;
        private System.Windows.Forms.Label lbngaychungtu;
        private System.Windows.Forms.Label lbdiengiai;
        private System.Windows.Forms.Label lbtennguoinoptien;
        private System.Windows.Forms.Label lbmancc;
        private System.Windows.Forms.Label lbsochungtu;
        private System.Windows.Forms.Label lbncc;
        private System.Windows.Forms.ToolStrip toolStrip_Insert;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTracuu;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tssltongthanhtoan;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox tsslsono;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox tsslthanhtoan;
        private System.Windows.Forms.ToolStripButton toolStrip_btnThem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslthem;
        private System.Windows.Forms.ToolStripStatusLabel tsslsua;
        private System.Windows.Forms.ToolStripStatusLabel tsslin;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripStatusLabel tssltrove;

    }
}