namespace GUI
{
    partial class FrmBcThongKeMatHangBanRaTheoNhanVien
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
            this.tssReset = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssView = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssPdf = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssWord = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssExcel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssExit = new System.Windows.Forms.ToolStripStatusLabel();
            this.palCenter = new System.Windows.Forms.Panel();
            this.uGrid = new System.Windows.Forms.DataGridView();
            this.palTop = new System.Windows.Forms.Panel();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.lblChonThoiGian = new System.Windows.Forms.Label();
            this.lblChonNhanVien = new System.Windows.Forms.Label();
            this.cbbChonNhanVien = new System.Windows.Forms.ComboBox();
            this.gbTimKiem = new System.Windows.Forms.GroupBox();
            this.rdoSearchMa = new System.Windows.Forms.RadioButton();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.rdoSearchTatCa = new System.Windows.Forms.RadioButton();
            this.rdoSearchTen = new System.Windows.Forms.RadioButton();
            this.lbtenbaocao = new System.Windows.Forms.Label();
            this.cbbChonThoiGian = new System.Windows.Forms.ComboBox();
            this.dteDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dteTuNgay = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1.SuspendLayout();
            this.palCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uGrid)).BeginInit();
            this.palTop.SuspendLayout();
            this.gbTimKiem.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssReset,
            this.tssView,
            this.tssPdf,
            this.tssWord,
            this.tssExcel,
            this.tssExit});
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(646, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssReset
            // 
            this.tssReset.Image = global::GUI.Properties.Resources.refresh;
            this.tssReset.Name = "tssReset";
            this.tssReset.Size = new System.Drawing.Size(105, 21);
            this.tssReset.Spring = true;
            this.tssReset.Text = "Nạp lại";
            this.tssReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssReset.Click += new System.EventHandler(this.TssResetClick);
            // 
            // tssView
            // 
            this.tssView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tssView.Image = global::GUI.Properties.Resources.In;
            this.tssView.Name = "tssView";
            this.tssView.Size = new System.Drawing.Size(105, 21);
            this.tssView.Spring = true;
            this.tssView.Text = "Xem";
            this.tssView.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssView.Click += new System.EventHandler(this.TssViewClick);
            // 
            // tssPdf
            // 
            this.tssPdf.Image = global::GUI.Properties.Resources.icon_pdf;
            this.tssPdf.Name = "tssPdf";
            this.tssPdf.Size = new System.Drawing.Size(105, 21);
            this.tssPdf.Spring = true;
            this.tssPdf.Text = "PDF";
            this.tssPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssPdf.Click += new System.EventHandler(this.TssPdfClick);
            // 
            // tssWord
            // 
            this.tssWord.Image = global::GUI.Properties.Resources.DocX_Viewer_icon;
            this.tssWord.Name = "tssWord";
            this.tssWord.Size = new System.Drawing.Size(105, 21);
            this.tssWord.Spring = true;
            this.tssWord.Text = "Word";
            this.tssWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssWord.Click += new System.EventHandler(this.TssWordClick);
            // 
            // tssExcel
            // 
            this.tssExcel.Image = global::GUI.Properties.Resources.excel_icon4;
            this.tssExcel.Name = "tssExcel";
            this.tssExcel.Size = new System.Drawing.Size(105, 21);
            this.tssExcel.Spring = true;
            this.tssExcel.Text = "Excel";
            this.tssExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssExcel.Click += new System.EventHandler(this.TssExcelClick);
            // 
            // tssExit
            // 
            this.tssExit.Image = global::GUI.Properties.Resources.Xoa;
            this.tssExit.Name = "tssExit";
            this.tssExit.Size = new System.Drawing.Size(105, 21);
            this.tssExit.Spring = true;
            this.tssExit.Text = "Thoát";
            this.tssExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssExit.Click += new System.EventHandler(this.TssExitClick);
            // 
            // palCenter
            // 
            this.palCenter.Controls.Add(this.uGrid);
            this.palCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palCenter.Location = new System.Drawing.Point(0, 150);
            this.palCenter.Name = "palCenter";
            this.palCenter.Size = new System.Drawing.Size(646, 279);
            this.palCenter.TabIndex = 3;
            // 
            // uGrid
            // 
            this.uGrid.AllowUserToAddRows = false;
            this.uGrid.AllowUserToDeleteRows = false;
            this.uGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.uGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uGrid.Location = new System.Drawing.Point(0, 0);
            this.uGrid.Name = "uGrid";
            this.uGrid.ReadOnly = true;
            this.uGrid.Size = new System.Drawing.Size(646, 279);
            this.uGrid.TabIndex = 0;
            // 
            // palTop
            // 
            this.palTop.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.palTop.Controls.Add(this.lblTenNhanVien);
            this.palTop.Controls.Add(this.lblDenNgay);
            this.palTop.Controls.Add(this.lblTuNgay);
            this.palTop.Controls.Add(this.btnHienThi);
            this.palTop.Controls.Add(this.lblChonThoiGian);
            this.palTop.Controls.Add(this.lblChonNhanVien);
            this.palTop.Controls.Add(this.cbbChonNhanVien);
            this.palTop.Controls.Add(this.gbTimKiem);
            this.palTop.Controls.Add(this.lbtenbaocao);
            this.palTop.Controls.Add(this.cbbChonThoiGian);
            this.palTop.Controls.Add(this.dteDenNgay);
            this.palTop.Controls.Add(this.dteTuNgay);
            this.palTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.palTop.Location = new System.Drawing.Point(0, 0);
            this.palTop.Name = "palTop";
            this.palTop.Size = new System.Drawing.Size(646, 150);
            this.palTop.TabIndex = 4;
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.AutoSize = true;
            this.lblTenNhanVien.Location = new System.Drawing.Point(216, 49);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(0, 13);
            this.lblTenNhanVien.TabIndex = 101;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(461, 57);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(52, 13);
            this.lblDenNgay.TabIndex = 100;
            this.lblDenNgay.Text = "đến ngày";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(366, 57);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(42, 13);
            this.lblTuNgay.TabIndex = 99;
            this.lblTuNgay.Text = "từ ngày";
            // 
            // btnHienThi
            // 
            this.btnHienThi.Location = new System.Drawing.Point(522, 45);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(77, 49);
            this.btnHienThi.TabIndex = 98;
            this.btnHienThi.Text = "Hiển thị";
            this.btnHienThi.UseVisualStyleBackColor = true;
            this.btnHienThi.Click += new System.EventHandler(this.BtnHienThiClick);
            // 
            // lblChonThoiGian
            // 
            this.lblChonThoiGian.AutoSize = true;
            this.lblChonThoiGian.Location = new System.Drawing.Point(13, 75);
            this.lblChonThoiGian.Name = "lblChonThoiGian";
            this.lblChonThoiGian.Size = new System.Drawing.Size(75, 13);
            this.lblChonThoiGian.TabIndex = 97;
            this.lblChonThoiGian.Text = "Chọn thời gian";
            // 
            // lblChonNhanVien
            // 
            this.lblChonNhanVien.AutoSize = true;
            this.lblChonNhanVien.Location = new System.Drawing.Point(12, 48);
            this.lblChonNhanVien.Name = "lblChonNhanVien";
            this.lblChonNhanVien.Size = new System.Drawing.Size(82, 13);
            this.lblChonNhanVien.TabIndex = 96;
            this.lblChonNhanVien.Text = "Chọn nhân viên";
            // 
            // cbbChonNhanVien
            // 
            this.cbbChonNhanVien.FormattingEnabled = true;
            this.cbbChonNhanVien.Location = new System.Drawing.Point(107, 45);
            this.cbbChonNhanVien.Name = "cbbChonNhanVien";
            this.cbbChonNhanVien.Size = new System.Drawing.Size(103, 21);
            this.cbbChonNhanVien.TabIndex = 95;
            this.cbbChonNhanVien.SelectedIndexChanged += new System.EventHandler(this.CbbChonNhanVienSelectedIndexChanged);
            // 
            // gbTimKiem
            // 
            this.gbTimKiem.Controls.Add(this.rdoSearchMa);
            this.gbTimKiem.Controls.Add(this.txttimkiem);
            this.gbTimKiem.Controls.Add(this.rdoSearchTatCa);
            this.gbTimKiem.Controls.Add(this.rdoSearchTen);
            this.gbTimKiem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbTimKiem.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTimKiem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gbTimKiem.Location = new System.Drawing.Point(0, 100);
            this.gbTimKiem.Name = "gbTimKiem";
            this.gbTimKiem.Size = new System.Drawing.Size(646, 50);
            this.gbTimKiem.TabIndex = 94;
            this.gbTimKiem.TabStop = false;
            this.gbTimKiem.Text = "Tìm kiếm";
            // 
            // rdoSearchMa
            // 
            this.rdoSearchMa.AutoSize = true;
            this.rdoSearchMa.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSearchMa.Location = new System.Drawing.Point(12, 21);
            this.rdoSearchMa.Name = "rdoSearchMa";
            this.rdoSearchMa.Size = new System.Drawing.Size(65, 18);
            this.rdoSearchMa.TabIndex = 4;
            this.rdoSearchMa.TabStop = true;
            this.rdoSearchMa.Text = "Mã hàng";
            this.rdoSearchMa.UseVisualStyleBackColor = true;
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(267, 18);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(367, 20);
            this.txttimkiem.TabIndex = 3;
            this.txttimkiem.TextChanged += new System.EventHandler(this.TxttimkiemTextChanged);
            // 
            // rdoSearchTatCa
            // 
            this.rdoSearchTatCa.AutoSize = true;
            this.rdoSearchTatCa.Checked = true;
            this.rdoSearchTatCa.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSearchTatCa.Location = new System.Drawing.Point(206, 21);
            this.rdoSearchTatCa.Name = "rdoSearchTatCa";
            this.rdoSearchTatCa.Size = new System.Drawing.Size(55, 18);
            this.rdoSearchTatCa.TabIndex = 2;
            this.rdoSearchTatCa.TabStop = true;
            this.rdoSearchTatCa.Text = "Tất cả";
            this.rdoSearchTatCa.UseVisualStyleBackColor = true;
            // 
            // rdoSearchTen
            // 
            this.rdoSearchTen.AutoSize = true;
            this.rdoSearchTen.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSearchTen.Location = new System.Drawing.Point(107, 21);
            this.rdoSearchTen.Name = "rdoSearchTen";
            this.rdoSearchTen.Size = new System.Drawing.Size(69, 18);
            this.rdoSearchTen.TabIndex = 1;
            this.rdoSearchTen.TabStop = true;
            this.rdoSearchTen.Text = "Tên hàng";
            this.rdoSearchTen.UseVisualStyleBackColor = true;
            // 
            // lbtenbaocao
            // 
            this.lbtenbaocao.AutoSize = true;
            this.lbtenbaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtenbaocao.ForeColor = System.Drawing.Color.White;
            this.lbtenbaocao.Location = new System.Drawing.Point(12, 9);
            this.lbtenbaocao.Name = "lbtenbaocao";
            this.lbtenbaocao.Size = new System.Drawing.Size(366, 20);
            this.lbtenbaocao.TabIndex = 3;
            this.lbtenbaocao.Text = "Thống Kê Mặt Hàng Bán Ra Theo Nhân Viên";
            // 
            // cbbChonThoiGian
            // 
            this.cbbChonThoiGian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChonThoiGian.FormattingEnabled = true;
            this.cbbChonThoiGian.Items.AddRange(new object[] {
            "Tháng 1",
            "Tháng 2",
            "Tháng 3",
            "Tháng 4",
            "Tháng 5",
            "Tháng 6",
            "Tháng 7",
            "Tháng 8",
            "Tháng 9",
            "Tháng 10",
            "Tháng 11",
            "Tháng 12",
            "[Tùy chỉnh thời gian]"});
            this.cbbChonThoiGian.Location = new System.Drawing.Point(107, 72);
            this.cbbChonThoiGian.Name = "cbbChonThoiGian";
            this.cbbChonThoiGian.Size = new System.Drawing.Size(201, 21);
            this.cbbChonThoiGian.TabIndex = 2;
            this.cbbChonThoiGian.SelectedIndexChanged += new System.EventHandler(this.CbbChonThoiGianSelectedIndexChanged);
            // 
            // dteDenNgay
            // 
            this.dteDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dteDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteDenNgay.Location = new System.Drawing.Point(418, 73);
            this.dteDenNgay.Name = "dteDenNgay";
            this.dteDenNgay.Size = new System.Drawing.Size(98, 20);
            this.dteDenNgay.TabIndex = 1;
            // 
            // dteTuNgay
            // 
            this.dteTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dteTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteTuNgay.Location = new System.Drawing.Point(314, 72);
            this.dteTuNgay.Name = "dteTuNgay";
            this.dteTuNgay.Size = new System.Drawing.Size(98, 20);
            this.dteTuNgay.TabIndex = 0;
            // 
            // FrmBcThongKeMatHangBanRaTheoNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 455);
            this.Controls.Add(this.palCenter);
            this.Controls.Add(this.palTop);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmBcThongKeMatHangBanRaTheoNhanVien";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.palCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uGrid)).EndInit();
            this.palTop.ResumeLayout(false);
            this.palTop.PerformLayout();
            this.gbTimKiem.ResumeLayout(false);
            this.gbTimKiem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssReset;
        private System.Windows.Forms.ToolStripStatusLabel tssView;
        private System.Windows.Forms.ToolStripStatusLabel tssPdf;
        private System.Windows.Forms.ToolStripStatusLabel tssWord;
        private System.Windows.Forms.ToolStripStatusLabel tssExcel;
        private System.Windows.Forms.ToolStripStatusLabel tssExit;
        private System.Windows.Forms.Panel palCenter;
        private System.Windows.Forms.Panel palTop;
        private System.Windows.Forms.DataGridView uGrid;
        private System.Windows.Forms.DateTimePicker dteTuNgay;
        private System.Windows.Forms.ComboBox cbbChonThoiGian;
        private System.Windows.Forms.DateTimePicker dteDenNgay;
        private System.Windows.Forms.Label lbtenbaocao;
        private System.Windows.Forms.GroupBox gbTimKiem;
        private System.Windows.Forms.RadioButton rdoSearchMa;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.RadioButton rdoSearchTatCa;
        private System.Windows.Forms.RadioButton rdoSearchTen;
        private System.Windows.Forms.Label lblChonThoiGian;
        private System.Windows.Forms.Label lblChonNhanVien;
        private System.Windows.Forms.ComboBox cbbChonNhanVien;
        private System.Windows.Forms.Button btnHienThi;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label lblTenNhanVien;
    }
}