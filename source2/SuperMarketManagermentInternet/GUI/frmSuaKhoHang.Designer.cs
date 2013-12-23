namespace GUI
{
    partial class frmSuaKhoHang
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
            this.palTren = new System.Windows.Forms.Panel();
            this.lblKhoHang = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssThem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssDong = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Khohang = new System.Windows.Forms.TabPage();
            this.cmbMaNhanVien = new System.Windows.Forms.ComboBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenKho = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaKho = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage_Hanghoa = new System.Windows.Forms.TabPage();
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.rbTonKho = new System.Windows.Forms.RadioButton();
            this.palTren.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Khohang.SuspendLayout();
            this.tabPage_Hanghoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.SuspendLayout();
            // 
            // palTren
            // 
            this.palTren.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.palTren.Controls.Add(this.lblKhoHang);
            this.palTren.Dock = System.Windows.Forms.DockStyle.Top;
            this.palTren.Location = new System.Drawing.Point(0, 0);
            this.palTren.Name = "palTren";
            this.palTren.Size = new System.Drawing.Size(442, 43);
            this.palTren.TabIndex = 2;
            // 
            // lblKhoHang
            // 
            this.lblKhoHang.AutoSize = true;
            this.lblKhoHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoHang.ForeColor = System.Drawing.Color.White;
            this.lblKhoHang.Location = new System.Drawing.Point(3, 4);
            this.lblKhoHang.Name = "lblKhoHang";
            this.lblKhoHang.Size = new System.Drawing.Size(130, 16);
            this.lblKhoHang.TabIndex = 0;
            this.lblKhoHang.Text = "SỬA - KHO HÀNG";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssThem,
            this.tssSua,
            this.tssDong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 338);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(442, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssThem
            // 
            this.tssThem.Enabled = false;
            this.tssThem.Image = global::GUI.Properties.Resources.Them;
            this.tssThem.Name = "tssThem";
            this.tssThem.Size = new System.Drawing.Size(132, 21);
            this.tssThem.Spring = true;
            this.tssThem.Text = "Thêm";
            this.tssThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssThem.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssThem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssSua
            // 
            this.tssSua.Image = global::GUI.Properties.Resources.Sua;
            this.tssSua.Name = "tssSua";
            this.tssSua.Size = new System.Drawing.Size(132, 21);
            this.tssSua.Spring = true;
            this.tssSua.Text = "Sửa";
            this.tssSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssSua.Click += new System.EventHandler(this.tssSua_Click);
            this.tssSua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssSua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssDong
            // 
            this.tssDong.Image = global::GUI.Properties.Resources.Xoa;
            this.tssDong.Name = "tssDong";
            this.tssDong.Size = new System.Drawing.Size(132, 21);
            this.tssDong.Spring = true;
            this.tssDong.Text = "Đóng";
            this.tssDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssDong.Click += new System.EventHandler(this.tssDong_Click);
            this.tssDong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssDong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Khohang);
            this.tabControl1.Controls.Add(this.tabPage_Hanghoa);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(442, 295);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage_Khohang
            // 
            this.tabPage_Khohang.Controls.Add(this.cmbMaNhanVien);
            this.tabPage_Khohang.Controls.Add(this.txtGhiChu);
            this.tabPage_Khohang.Controls.Add(this.label8);
            this.tabPage_Khohang.Controls.Add(this.label7);
            this.tabPage_Khohang.Controls.Add(this.txtSoDienThoai);
            this.tabPage_Khohang.Controls.Add(this.label6);
            this.tabPage_Khohang.Controls.Add(this.txtDiaChi);
            this.tabPage_Khohang.Controls.Add(this.label5);
            this.tabPage_Khohang.Controls.Add(this.txtTenKho);
            this.tabPage_Khohang.Controls.Add(this.label4);
            this.tabPage_Khohang.Controls.Add(this.txtMaKho);
            this.tabPage_Khohang.Controls.Add(this.label3);
            this.tabPage_Khohang.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Khohang.Name = "tabPage_Khohang";
            this.tabPage_Khohang.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Khohang.Size = new System.Drawing.Size(434, 269);
            this.tabPage_Khohang.TabIndex = 0;
            this.tabPage_Khohang.Text = "Thông tin";
            this.tabPage_Khohang.UseVisualStyleBackColor = true;
            // 
            // cmbMaNhanVien
            // 
            this.cmbMaNhanVien.FormattingEnabled = true;
            this.cmbMaNhanVien.Location = new System.Drawing.Point(107, 118);
            this.cmbMaNhanVien.Name = "cmbMaNhanVien";
            this.cmbMaNhanVien.Size = new System.Drawing.Size(149, 21);
            this.cmbMaNhanVien.TabIndex = 14;
            this.cmbMaNhanVien.SelectedIndexChanged += new System.EventHandler(this.cmbMaNhanVien_SelectedIndexChanged);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(107, 145);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(315, 117);
            this.txtGhiChu.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 148);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Ghi chú:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Mã nhân viên:";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(107, 88);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(149, 20);
            this.txtSoDienThoai.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Số điện thoại:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(107, 61);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(315, 20);
            this.txtDiaChi.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Địa chỉ:";
            // 
            // txtTenKho
            // 
            this.txtTenKho.Location = new System.Drawing.Point(107, 35);
            this.txtTenKho.Name = "txtTenKho";
            this.txtTenKho.Size = new System.Drawing.Size(149, 20);
            this.txtTenKho.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên kho:";
            // 
            // txtMaKho
            // 
            this.txtMaKho.Location = new System.Drawing.Point(107, 9);
            this.txtMaKho.Name = "txtMaKho";
            this.txtMaKho.Size = new System.Drawing.Size(149, 20);
            this.txtMaKho.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã kho:";
            // 
            // tabPage_Hanghoa
            // 
            this.tabPage_Hanghoa.Controls.Add(this.dgvHangHoa);
            this.tabPage_Hanghoa.Controls.Add(this.rbTonKho);
            this.tabPage_Hanghoa.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Hanghoa.Name = "tabPage_Hanghoa";
            this.tabPage_Hanghoa.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Hanghoa.Size = new System.Drawing.Size(434, 273);
            this.tabPage_Hanghoa.TabIndex = 1;
            this.tabPage_Hanghoa.Text = "2. Hàng hóa";
            this.tabPage_Hanghoa.UseVisualStyleBackColor = true;
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangHoa.Location = new System.Drawing.Point(2, 29);
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.Size = new System.Drawing.Size(429, 241);
            this.dgvHangHoa.TabIndex = 1;
            // 
            // rbTonKho
            // 
            this.rbTonKho.AutoSize = true;
            this.rbTonKho.Location = new System.Drawing.Point(8, 6);
            this.rbTonKho.Name = "rbTonKho";
            this.rbTonKho.Size = new System.Drawing.Size(149, 17);
            this.rbTonKho.TabIndex = 0;
            this.rbTonKho.TabStop = true;
            this.rbTonKho.Text = "Dưới mức tồn kho tối thiểu";
            this.rbTonKho.UseVisualStyleBackColor = true;
            // 
            // frmSuaKhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(442, 364);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.palTren);
            this.MaximizeBox = false;
            this.Name = "frmSuaKhoHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SỬA - KHO HÀNG";
            this.Load += new System.EventHandler(this.frmSuaKhoHang_Load);
            this.palTren.ResumeLayout(false);
            this.palTren.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Khohang.ResumeLayout(false);
            this.tabPage_Khohang.PerformLayout();
            this.tabPage_Hanghoa.ResumeLayout(false);
            this.tabPage_Hanghoa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel palTren;
        private System.Windows.Forms.Label lblKhoHang;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssThem;
        private System.Windows.Forms.ToolStripStatusLabel tssSua;
        private System.Windows.Forms.ToolStripStatusLabel tssDong;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Khohang;
        private System.Windows.Forms.ComboBox cmbMaNhanVien;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenKho;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage_Hanghoa;
        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.RadioButton rbTonKho;
        private System.Windows.Forms.TextBox txtMaKho;
        private System.Windows.Forms.Label label3;
    }
}