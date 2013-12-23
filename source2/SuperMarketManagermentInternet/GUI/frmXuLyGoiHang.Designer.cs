namespace GUI
{
    partial class frmXuLyGoiHang
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbMaNhomHangHoa = new System.Windows.Forms.ComboBox();
            this.cbbLoaiHangHoa = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtgianhap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtgiabanle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtgiabanbuon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txttengoihang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmagoihang = new System.Windows.Forms.TextBox();
            this.lblSochungtu = new System.Windows.Forms.Label();
            this.grbDataGridview = new System.Windows.Forms.GroupBox();
            this.dgvInsertOrder = new System.Windows.Forms.DataGridView();
            this.palThem = new System.Windows.Forms.Panel();
            this.toolStrip_Insert = new System.Windows.Forms.ToolStrip();
            this.toolStrip_txtTracuu = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_txtTenhang = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_txtTonkho = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_txtTonThucTe = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_btnThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus_Themmoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Ghilai = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.grbDataGridview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsertOrder)).BeginInit();
            this.palThem.SuspendLayout();
            this.toolStrip_Insert.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbMaNhomHangHoa);
            this.panel1.Controls.Add(this.cbbLoaiHangHoa);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtgianhap);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtgiabanle);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtgiabanbuon);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txttengoihang);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtmagoihang);
            this.panel1.Controls.Add(this.lblSochungtu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(885, 140);
            this.panel1.TabIndex = 12;
            // 
            // cmbMaNhomHangHoa
            // 
            this.cmbMaNhomHangHoa.FormattingEnabled = true;
            this.cmbMaNhomHangHoa.ItemHeight = 13;
            this.cmbMaNhomHangHoa.Location = new System.Drawing.Point(408, 59);
            this.cmbMaNhomHangHoa.Name = "cmbMaNhomHangHoa";
            this.cmbMaNhomHangHoa.Size = new System.Drawing.Size(136, 21);
            this.cmbMaNhomHangHoa.TabIndex = 3;
            // 
            // cbbLoaiHangHoa
            // 
            this.cbbLoaiHangHoa.FormattingEnabled = true;
            this.cbbLoaiHangHoa.ItemHeight = 13;
            this.cbbLoaiHangHoa.Location = new System.Drawing.Point(408, 18);
            this.cbbLoaiHangHoa.Name = "cbbLoaiHangHoa";
            this.cbbLoaiHangHoa.Size = new System.Drawing.Size(136, 21);
            this.cbbLoaiHangHoa.TabIndex = 2;
            this.cbbLoaiHangHoa.SelectedIndexChanged += new System.EventHandler(this.cbbLoaiHangHoa_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(306, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "Nhóm Hàng:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(313, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Loại Hàng:";
            // 
            // txtgianhap
            // 
            this.txtgianhap.BackColor = System.Drawing.Color.White;
            this.txtgianhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtgianhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgianhap.Location = new System.Drawing.Point(117, 91);
            this.txtgianhap.Name = "txtgianhap";
            this.txtgianhap.Size = new System.Drawing.Size(136, 22);
            this.txtgianhap.TabIndex = 200;
            this.txtgianhap.TextChanged += new System.EventHandler(this.txtgianhap_TextChanged);
            this.txtgianhap.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaNhap_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Giá Nhập:";
            // 
            // txtgiabanle
            // 
            this.txtgiabanle.BackColor = System.Drawing.Color.White;
            this.txtgiabanle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtgiabanle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgiabanle.Location = new System.Drawing.Point(653, 89);
            this.txtgiabanle.Name = "txtgiabanle";
            this.txtgiabanle.Size = new System.Drawing.Size(136, 22);
            this.txtgiabanle.TabIndex = 600;
            this.txtgiabanle.TextChanged += new System.EventHandler(this.txtgiabanle_TextChanged);
            this.txtgiabanle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaBanLe_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(567, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Giá Bán Lẻ:";
            // 
            // txtgiabanbuon
            // 
            this.txtgiabanbuon.BackColor = System.Drawing.Color.White;
            this.txtgiabanbuon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtgiabanbuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgiabanbuon.Location = new System.Drawing.Point(408, 90);
            this.txtgiabanbuon.Name = "txtgiabanbuon";
            this.txtgiabanbuon.Size = new System.Drawing.Size(136, 22);
            this.txtgiabanbuon.TabIndex = 500;
            this.txtgiabanbuon.TextChanged += new System.EventHandler(this.txtgiabanbuon_TextChanged);
            this.txtgiabanbuon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaBanBuon_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(306, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Giá Bán Buôn:";
            // 
            // txttengoihang
            // 
            this.txttengoihang.BackColor = System.Drawing.Color.White;
            this.txttengoihang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttengoihang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttengoihang.Location = new System.Drawing.Point(117, 53);
            this.txttengoihang.Name = "txttengoihang";
            this.txttengoihang.Size = new System.Drawing.Size(136, 22);
            this.txttengoihang.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Tên Gói Hàng:";
            // 
            // txtmagoihang
            // 
            this.txtmagoihang.BackColor = System.Drawing.Color.White;
            this.txtmagoihang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmagoihang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmagoihang.Location = new System.Drawing.Point(117, 16);
            this.txtmagoihang.Name = "txtmagoihang";
            this.txtmagoihang.Size = new System.Drawing.Size(136, 22);
            this.txtmagoihang.TabIndex = 0;
            // 
            // lblSochungtu
            // 
            this.lblSochungtu.AutoSize = true;
            this.lblSochungtu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSochungtu.Location = new System.Drawing.Point(21, 18);
            this.lblSochungtu.Name = "lblSochungtu";
            this.lblSochungtu.Size = new System.Drawing.Size(90, 16);
            this.lblSochungtu.TabIndex = 12;
            this.lblSochungtu.Text = "Mã Gói Hàng:";
            // 
            // grbDataGridview
            // 
            this.grbDataGridview.Controls.Add(this.dgvInsertOrder);
            this.grbDataGridview.Controls.Add(this.palThem);
            this.grbDataGridview.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbDataGridview.Location = new System.Drawing.Point(0, 140);
            this.grbDataGridview.Name = "grbDataGridview";
            this.grbDataGridview.Size = new System.Drawing.Size(885, 213);
            this.grbDataGridview.TabIndex = 4;
            this.grbDataGridview.TabStop = false;
            // 
            // dgvInsertOrder
            // 
            this.dgvInsertOrder.AllowUserToAddRows = false;
            this.dgvInsertOrder.AllowUserToDeleteRows = false;
            this.dgvInsertOrder.BackgroundColor = System.Drawing.Color.White;
            this.dgvInsertOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsertOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInsertOrder.Location = new System.Drawing.Point(3, 44);
            this.dgvInsertOrder.Name = "dgvInsertOrder";
            this.dgvInsertOrder.ReadOnly = true;
            this.dgvInsertOrder.Size = new System.Drawing.Size(879, 166);
            this.dgvInsertOrder.TabIndex = 0;
            this.dgvInsertOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInsertOrder_CellClick);
            this.dgvInsertOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInsertOrder_CellDoubleClick);
            // 
            // palThem
            // 
            this.palThem.Controls.Add(this.toolStrip_Insert);
            this.palThem.Dock = System.Windows.Forms.DockStyle.Top;
            this.palThem.Location = new System.Drawing.Point(3, 16);
            this.palThem.Name = "palThem";
            this.palThem.Size = new System.Drawing.Size(879, 28);
            this.palThem.TabIndex = 3;
            // 
            // toolStrip_Insert
            // 
            this.toolStrip_Insert.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_Insert.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_txtTracuu,
            this.toolStripLabel1,
            this.toolStrip_txtTenhang,
            this.toolStripLabel2,
            this.toolStrip_txtTonkho,
            this.toolStripLabel3,
            this.toolStrip_txtTonThucTe,
            this.toolStripLabel4,
            this.toolStrip_btnThem,
            this.toolStripTextBox1,
            this.toolStripLabel5,
            this.toolStripTextBox2});
            this.toolStrip_Insert.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Insert.Name = "toolStrip_Insert";
            this.toolStrip_Insert.Size = new System.Drawing.Size(879, 25);
            this.toolStrip_Insert.TabIndex = 2;
            this.toolStrip_Insert.Text = "toolStrip1";
            // 
            // toolStrip_txtTracuu
            // 
            this.toolStrip_txtTracuu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtTracuu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip_txtTracuu.MaxLength = 50;
            this.toolStrip_txtTracuu.Name = "toolStrip_txtTracuu";
            this.toolStrip_txtTracuu.Size = new System.Drawing.Size(100, 25);
            this.toolStrip_txtTracuu.Tag = "1";
            this.toolStrip_txtTracuu.Text = "<F4 - Tra cứu>";
            this.toolStrip_txtTracuu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_txtTracuu_KeyDown);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel1.Text = "Tên:";
            // 
            // toolStrip_txtTenhang
            // 
            this.toolStrip_txtTenhang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStrip_txtTenhang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtTenhang.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip_txtTenhang.Name = "toolStrip_txtTenhang";
            this.toolStrip_txtTenhang.ReadOnly = true;
            this.toolStrip_txtTenhang.Size = new System.Drawing.Size(200, 25);
            this.toolStrip_txtTenhang.Tag = "2";
            this.toolStrip_txtTenhang.ToolTipText = "Tên hàng";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(25, 22);
            this.toolStripLabel2.Text = "GN:";
            this.toolStripLabel2.ToolTipText = "Tồn sổ sách";
            // 
            // toolStrip_txtTonkho
            // 
            this.toolStrip_txtTonkho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStrip_txtTonkho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtTonkho.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip_txtTonkho.Name = "toolStrip_txtTonkho";
            this.toolStrip_txtTonkho.ReadOnly = true;
            this.toolStrip_txtTonkho.Size = new System.Drawing.Size(80, 25);
            this.toolStrip_txtTonkho.Tag = "3";
            this.toolStrip_txtTonkho.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolStrip_txtTonkho.ToolTipText = "Tồn sổ sách";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(30, 22);
            this.toolStripLabel3.Text = "GBB:";
            this.toolStripLabel3.ToolTipText = "Tồn thực tế";
            // 
            // toolStrip_txtTonThucTe
            // 
            this.toolStrip_txtTonThucTe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStrip_txtTonThucTe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtTonThucTe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip_txtTonThucTe.MaxLength = 15;
            this.toolStrip_txtTonThucTe.Name = "toolStrip_txtTonThucTe";
            this.toolStrip_txtTonThucTe.ReadOnly = true;
            this.toolStrip_txtTonThucTe.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip_txtTonThucTe.Size = new System.Drawing.Size(60, 25);
            this.toolStrip_txtTonThucTe.Tag = "4";
            this.toolStrip_txtTonThucTe.ToolTipText = "Tồn thực tế";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel4.Text = "GBL:";
            this.toolStripLabel4.ToolTipText = "Lý do tồn";
            // 
            // toolStrip_btnThem
            // 
            this.toolStrip_btnThem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStrip_btnThem.Image = global::GUI.Properties.Resources.Them;
            this.toolStrip_btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnThem.Name = "toolStrip_btnThem";
            this.toolStrip_btnThem.Size = new System.Drawing.Size(53, 22);
            this.toolStrip_btnThem.Tag = "6";
            this.toolStrip_btnThem.Text = "Thêm";
            this.toolStrip_btnThem.Click += new System.EventHandler(this.toolStrip_btnThem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(22, 22);
            this.toolStripLabel5.Text = "SL:";
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.MaxLength = 5;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox2.Text = "1";
            this.toolStripTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox2_KeyDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus_Themmoi,
            this.toolStripStatus_Ghilai,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 373);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(885, 26);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatus_Themmoi
            // 
            this.toolStripStatus_Themmoi.Image = global::GUI.Properties.Resources.Them;
            this.toolStripStatus_Themmoi.Name = "toolStripStatus_Themmoi";
            this.toolStripStatus_Themmoi.Size = new System.Drawing.Size(290, 21);
            this.toolStripStatus_Themmoi.Spring = true;
            this.toolStripStatus_Themmoi.Tag = "12";
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
            this.toolStripStatus_Ghilai.Size = new System.Drawing.Size(290, 21);
            this.toolStripStatus_Ghilai.Spring = true;
            this.toolStripStatus_Ghilai.Tag = "13";
            this.toolStripStatus_Ghilai.Text = "Sửa";
            this.toolStripStatus_Ghilai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Ghilai.Click += new System.EventHandler(this.toolStripStatus_Ghilai_Click);
            this.toolStripStatus_Ghilai.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Ghilai.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Image = global::GUI.Properties.Resources.Xoa;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(290, 21);
            this.toolStripStatusLabel4.Spring = true;
            this.toolStripStatusLabel4.Tag = "15";
            this.toolStripStatusLabel4.Text = "Trở về";
            this.toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel4.Click += new System.EventHandler(this.toolStripStatusLabel4_Click);
            this.toolStripStatusLabel4.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // frmXuLyGoiHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 399);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grbDataGridview);
            this.Controls.Add(this.panel1);
            this.Name = "frmXuLyGoiHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xử Lý Gói Hàng";
            this.Load += new System.EventHandler(this.frmXuLyGoiHang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbDataGridview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsertOrder)).EndInit();
            this.palThem.ResumeLayout(false);
            this.palThem.PerformLayout();
            this.toolStrip_Insert.ResumeLayout(false);
            this.toolStrip_Insert.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtgianhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtgiabanle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtgiabanbuon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttengoihang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmagoihang;
        private System.Windows.Forms.Label lblSochungtu;
        private System.Windows.Forms.GroupBox grbDataGridview;
        private System.Windows.Forms.DataGridView dgvInsertOrder;
        private System.Windows.Forms.Panel palThem;
        private System.Windows.Forms.ToolStrip toolStrip_Insert;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTracuu;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTenhang;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTonkho;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTonThucTe;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton toolStrip_btnThem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ComboBox cmbMaNhomHangHoa;
        private System.Windows.Forms.ComboBox cbbLoaiHangHoa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Themmoi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Ghilai;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;

    }
}