namespace GUI
{
    partial class frmXuLyKiemKeKho
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
            this.btnIn = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExcel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnWord = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPDF = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel = new System.Windows.Forms.Panel();
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
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_txtTenhang = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_txtTonkho = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_txtTonThucTe = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_txtLyDo = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip_btnThem = new System.Windows.Forms.ToolStripButton();
            this.lblGiamgia_Tienhang = new System.Windows.Forms.Label();
            this.txtTienhang = new System.Windows.Forms.TextBox();
            this.palXem = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus_Themmoi,
            this.toolStripStatus_Ghilai,
            this.btnIn,
            this.btnExcel,
            this.btnWord,
            this.btnPDF,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 502);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(900, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatus_Themmoi
            // 
            this.toolStripStatus_Themmoi.Image = global::GUI.Properties.Resources.Them;
            this.toolStripStatus_Themmoi.Name = "toolStripStatus_Themmoi";
            this.toolStripStatus_Themmoi.Size = new System.Drawing.Size(126, 21);
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
            this.toolStripStatus_Ghilai.Size = new System.Drawing.Size(126, 21);
            this.toolStripStatus_Ghilai.Spring = true;
            this.toolStripStatus_Ghilai.Tag = "13";
            this.toolStripStatus_Ghilai.Text = "Sửa";
            this.toolStripStatus_Ghilai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Ghilai.Click += new System.EventHandler(this.toolStripStatus_Ghilai_Click);
            this.toolStripStatus_Ghilai.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Ghilai.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // btnIn
            // 
            this.btnIn.Image = global::GUI.Properties.Resources.In;
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(126, 21);
            this.btnIn.Spring = true;
            this.btnIn.Tag = "14";
            this.btnIn.Text = "In";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::GUI.Properties.Resources.excel_icon4;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(126, 21);
            this.btnExcel.Spring = true;
            this.btnExcel.Tag = "14";
            this.btnExcel.Text = "Excel";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnWord
            // 
            this.btnWord.Image = global::GUI.Properties.Resources.DocX_Viewer_icon;
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(126, 21);
            this.btnWord.Spring = true;
            this.btnWord.Tag = "14";
            this.btnWord.Text = "Word";
            this.btnWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.Image = global::GUI.Properties.Resources.icon_pdf;
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(126, 21);
            this.btnPDF.Spring = true;
            this.btnPDF.Tag = "14";
            this.btnPDF.Text = "PDF";
            this.btnPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            this.btnPDF.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.btnPDF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Image = global::GUI.Properties.Resources.Xoa;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(126, 21);
            this.toolStripStatusLabel4.Spring = true;
            this.toolStripStatusLabel4.Tag = "15";
            this.toolStripStatusLabel4.Text = "Trở về";
            this.toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel4.Click += new System.EventHandler(this.toolStripStatusLabel4_Click);
            this.toolStripStatusLabel4.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // panel
            // 
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
            this.panel.Size = new System.Drawing.Size(900, 156);
            this.panel.TabIndex = 1;
            // 
            // lblDiengiai
            // 
            this.lblDiengiai.AutoSize = true;
            this.lblDiengiai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiengiai.Location = new System.Drawing.Point(26, 98);
            this.lblDiengiai.Name = "lblDiengiai";
            this.lblDiengiai.Size = new System.Drawing.Size(64, 16);
            this.lblDiengiai.TabIndex = 30;
            this.lblDiengiai.Text = "Diễn giải:";
            // 
            // txtDiengiai
            // 
            this.txtDiengiai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiengiai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiengiai.Location = new System.Drawing.Point(96, 96);
            this.txtDiengiai.MaxLength = 200;
            this.txtDiengiai.Multiline = true;
            this.txtDiengiai.Name = "txtDiengiai";
            this.txtDiengiai.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiengiai.Size = new System.Drawing.Size(791, 54);
            this.txtDiengiai.TabIndex = 4;
            // 
            // cbxKhoban
            // 
            this.cbxKhoban.BackColor = System.Drawing.Color.White;
            this.cbxKhoban.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbxKhoban.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKhoban.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxKhoban.Location = new System.Drawing.Point(96, 56);
            this.cbxKhoban.Name = "cbxKhoban";
            this.cbxKhoban.Size = new System.Drawing.Size(421, 24);
            this.cbxKhoban.TabIndex = 3;
            this.cbxKhoban.SelectedIndexChanged += new System.EventHandler(this.cbxKhoban_SelectedIndexChanged);
            // 
            // lblKhohang
            // 
            this.lblKhohang.AutoSize = true;
            this.lblKhohang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhohang.Location = new System.Drawing.Point(23, 59);
            this.lblKhohang.Name = "lblKhohang";
            this.lblKhohang.Size = new System.Drawing.Size(67, 16);
            this.lblKhohang.TabIndex = 12;
            this.lblKhohang.Text = "Kho hàng:";
            // 
            // lblDinhdangngay
            // 
            this.lblDinhdangngay.AutoSize = true;
            this.lblDinhdangngay.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblDinhdangngay.Location = new System.Drawing.Point(446, 20);
            this.lblDinhdangngay.Name = "lblDinhdangngay";
            this.lblDinhdangngay.Size = new System.Drawing.Size(73, 14);
            this.lblDinhdangngay.TabIndex = 7;
            this.lblDinhdangngay.TabStop = true;
            this.lblDinhdangngay.Text = "(dd/mm/yyyy)";
            // 
            // makNgaychungtu
            // 
            this.makNgaychungtu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.makNgaychungtu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.makNgaychungtu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makNgaychungtu.Location = new System.Drawing.Point(343, 17);
            this.makNgaychungtu.Mask = "00/00/0000";
            this.makNgaychungtu.Name = "makNgaychungtu";
            this.makNgaychungtu.ReadOnly = true;
            this.makNgaychungtu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.makNgaychungtu.Size = new System.Drawing.Size(100, 22);
            this.makNgaychungtu.TabIndex = 2;
            this.makNgaychungtu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNgaychungtu
            // 
            this.lblNgaychungtu.AutoSize = true;
            this.lblNgaychungtu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaychungtu.Location = new System.Drawing.Point(251, 20);
            this.lblNgaychungtu.Name = "lblNgaychungtu";
            this.lblNgaychungtu.Size = new System.Drawing.Size(96, 16);
            this.lblNgaychungtu.TabIndex = 5;
            this.lblNgaychungtu.Text = "Ngày chứng từ:";
            // 
            // txtSochungtu
            // 
            this.txtSochungtu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSochungtu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSochungtu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSochungtu.Location = new System.Drawing.Point(96, 16);
            this.txtSochungtu.Name = "txtSochungtu";
            this.txtSochungtu.ReadOnly = true;
            this.txtSochungtu.Size = new System.Drawing.Size(136, 22);
            this.txtSochungtu.TabIndex = 1;
            // 
            // lblSochungtu
            // 
            this.lblSochungtu.AutoSize = true;
            this.lblSochungtu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSochungtu.Location = new System.Drawing.Point(10, 18);
            this.lblSochungtu.Name = "lblSochungtu";
            this.lblSochungtu.Size = new System.Drawing.Size(80, 16);
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
            this.grbDataGridview.Size = new System.Drawing.Size(900, 281);
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
            this.dgvInsertOrder.Location = new System.Drawing.Point(3, 44);
            this.dgvInsertOrder.Name = "dgvInsertOrder";
            this.dgvInsertOrder.ReadOnly = true;
            this.dgvInsertOrder.Size = new System.Drawing.Size(894, 234);
            this.dgvInsertOrder.TabIndex = 0;
            this.dgvInsertOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInsertOrder_CellClick);
            this.dgvInsertOrder.DoubleClick += new System.EventHandler(this.dgvInsertOrder_DoubleClick);
            // 
            // palThem
            // 
            this.palThem.Controls.Add(this.toolStrip_Insert);
            this.palThem.Dock = System.Windows.Forms.DockStyle.Top;
            this.palThem.Location = new System.Drawing.Point(3, 16);
            this.palThem.Name = "palThem";
            this.palThem.Size = new System.Drawing.Size(894, 28);
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
            this.toolStrip_txtLyDo,
            this.toolStrip_btnThem});
            this.toolStrip_Insert.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Insert.Name = "toolStrip_Insert";
            this.toolStrip_Insert.Size = new System.Drawing.Size(894, 25);
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
            this.toolStrip_txtTracuu.MouseLeave += new System.EventHandler(this.toolStrip_txtTracuu_MouseLeave);
            this.toolStrip_txtTracuu.MouseHover += new System.EventHandler(this.toolStrip_txtTracuu_MouseHover);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(30, 22);
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
            this.toolStripLabel2.Size = new System.Drawing.Size(29, 22);
            this.toolStripLabel2.Text = "TSS:";
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
            this.toolStrip_txtTonkho.Text = "0";
            this.toolStrip_txtTonkho.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolStrip_txtTonkho.ToolTipText = "Tồn sổ sách";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel3.Text = "TTT:";
            this.toolStripLabel3.ToolTipText = "Tồn thực tế";
            // 
            // toolStrip_txtTonThucTe
            // 
            this.toolStrip_txtTonThucTe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtTonThucTe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip_txtTonThucTe.MaxLength = 50;
            this.toolStrip_txtTonThucTe.Name = "toolStrip_txtTonThucTe";
            this.toolStrip_txtTonThucTe.Size = new System.Drawing.Size(80, 25);
            this.toolStrip_txtTonThucTe.Tag = "4";
            this.toolStrip_txtTonThucTe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolStrip_txtTonThucTe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_txtTonThucTe_KeyDown);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(24, 22);
            this.toolStripLabel4.Text = "LD:";
            this.toolStripLabel4.ToolTipText = "Lý do tồn";
            // 
            // toolStrip_txtLyDo
            // 
            this.toolStrip_txtLyDo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtLyDo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip_txtLyDo.MaxLength = 100;
            this.toolStrip_txtLyDo.Name = "toolStrip_txtLyDo";
            this.toolStrip_txtLyDo.Size = new System.Drawing.Size(230, 25);
            this.toolStrip_txtLyDo.Tag = "5";
            this.toolStrip_txtLyDo.Text = "Chưa có lý do";
            this.toolStrip_txtLyDo.ToolTipText = "Lý do tồn kho";
            this.toolStrip_txtLyDo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_txtLyDo_KeyDown);
            // 
            // toolStrip_btnThem
            // 
            this.toolStrip_btnThem.Image = global::GUI.Properties.Resources.Them;
            this.toolStrip_btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnThem.Name = "toolStrip_btnThem";
            this.toolStrip_btnThem.Size = new System.Drawing.Size(58, 22);
            this.toolStrip_btnThem.Tag = "6";
            this.toolStrip_btnThem.Text = "Thêm";
            this.toolStrip_btnThem.Click += new System.EventHandler(this.toolStrip_btnThem_Click);
            // 
            // lblGiamgia_Tienhang
            // 
            this.lblGiamgia_Tienhang.AutoSize = true;
            this.lblGiamgia_Tienhang.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiamgia_Tienhang.Location = new System.Drawing.Point(192, 304);
            this.lblGiamgia_Tienhang.Name = "lblGiamgia_Tienhang";
            this.lblGiamgia_Tienhang.Size = new System.Drawing.Size(120, 24);
            this.lblGiamgia_Tienhang.TabIndex = 2;
            this.lblGiamgia_Tienhang.Text = "Tổng giá trị:";
            // 
            // txtTienhang
            // 
            this.txtTienhang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTienhang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTienhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienhang.Location = new System.Drawing.Point(337, 298);
            this.txtTienhang.Name = "txtTienhang";
            this.txtTienhang.ReadOnly = true;
            this.txtTienhang.Size = new System.Drawing.Size(541, 35);
            this.txtTienhang.TabIndex = 5;
            this.txtTienhang.Tag = "11";
            this.txtTienhang.Text = "0";
            this.txtTienhang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // palXem
            // 
            this.palXem.Controls.Add(this.txtTienhang);
            this.palXem.Controls.Add(this.lblGiamgia_Tienhang);
            this.palXem.Controls.Add(this.grbDataGridview);
            this.palXem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palXem.Location = new System.Drawing.Point(0, 156);
            this.palXem.Name = "palXem";
            this.palXem.Size = new System.Drawing.Size(900, 346);
            this.palXem.TabIndex = 2;
            // 
            // frmXuLyKiemKeKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 528);
            this.Controls.Add(this.palXem);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmXuLyKiemKeKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
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
        private System.Windows.Forms.ToolStripStatusLabel btnPDF;
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
        private System.Windows.Forms.GroupBox grbDataGridview;
        private System.Windows.Forms.DataGridView dgvInsertOrder;
        private System.Windows.Forms.Panel palThem;
        private System.Windows.Forms.ToolStrip toolStrip_Insert;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTracuu;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTenhang;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTonkho;
        private System.Windows.Forms.ToolStripButton toolStrip_btnThem;
        private System.Windows.Forms.Label lblGiamgia_Tienhang;
        private System.Windows.Forms.TextBox txtTienhang;
        private System.Windows.Forms.Panel palXem;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtLyDo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripStatusLabel btnIn;
        private System.Windows.Forms.ToolStripStatusLabel btnExcel;
        private System.Windows.Forms.ToolStripStatusLabel btnWord;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTonThucTe;
    }
}