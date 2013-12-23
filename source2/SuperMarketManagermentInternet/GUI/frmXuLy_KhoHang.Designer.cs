namespace GUI
{
    partial class frmXuLy_KhoHang
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
            this.btnThem = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnGhiLai = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnIn = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnKhac = new System.Windows.Forms.ToolStripDropDownButton();
            this.thiêtLâpThôngSôToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xoaChưngTưHiênThơiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.huyĐơnĐătHangHiênThơiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saoChepChưngTưTưToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saoChepChưngTưSangNhâpHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saoChepChưngTưToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDong = new System.Windows.Forms.ToolStripStatusLabel();
            this.palTren = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Khohang = new System.Windows.Forms.TabPage();
            this.cmbThuKho = new System.Windows.Forms.ComboBox();
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtSTT = new System.Windows.Forms.TextBox();
            this.tabPage_Hanghoa = new System.Windows.Forms.TabPage();
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            this.palTren.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Khohang.SuspendLayout();
            this.tabPage_Hanghoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnGhiLai,
            this.btnIn,
            this.btnKhac,
            this.btnDong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 388);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(758, 27);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnThem
            // 
            this.btnThem.Image = global::GUI.Properties.Resources.Them;
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(158, 22);
            this.btnThem.Spring = true;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnThem.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.btnThem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // btnGhiLai
            // 
            this.btnGhiLai.Image = global::GUI.Properties.Resources.Luu;
            this.btnGhiLai.Name = "btnGhiLai";
            this.btnGhiLai.Size = new System.Drawing.Size(158, 22);
            this.btnGhiLai.Spring = true;
            this.btnGhiLai.Text = "Ghi lại";
            this.btnGhiLai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGhiLai.Click += new System.EventHandler(this.btnGhiLai_Click);
            this.btnGhiLai.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.btnGhiLai.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // btnIn
            // 
            this.btnIn.Image = global::GUI.Properties.Resources.In;
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(158, 22);
            this.btnIn.Spring = true;
            this.btnIn.Text = "In";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            this.btnIn.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.btnIn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // btnKhac
            // 
            this.btnKhac.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thiêtLâpThôngSôToolStripMenuItem,
            this.xoaChưngTưHiênThơiToolStripMenuItem,
            this.huyĐơnĐătHangHiênThơiToolStripMenuItem,
            this.saoChepChưngTưTưToolStripMenuItem,
            this.saoChepChưngTưSangNhâpHangToolStripMenuItem,
            this.saoChepChưngTưToolStripMenuItem});
            this.btnKhac.Image = global::GUI.Properties.Resources.khac;
            this.btnKhac.Name = "btnKhac";
            this.btnKhac.Size = new System.Drawing.Size(78, 25);
            this.btnKhac.Text = "Khác";
            this.btnKhac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKhac.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.btnKhac.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
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
            // btnDong
            // 
            this.btnDong.Image = global::GUI.Properties.Resources.Tro_ve;
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(158, 22);
            this.btnDong.Spring = true;
            this.btnDong.Text = "Trở về";
            this.btnDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            this.btnDong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.btnDong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // palTren
            // 
            this.palTren.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.palTren.Controls.Add(this.label1);
            this.palTren.Dock = System.Windows.Forms.DockStyle.Top;
            this.palTren.Location = new System.Drawing.Point(0, 0);
            this.palTren.Name = "palTren";
            this.palTren.Size = new System.Drawing.Size(758, 43);
            this.palTren.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "KHO HÀNG";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 345);
            this.panel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Khohang);
            this.tabControl1.Controls.Add(this.tabPage_Hanghoa);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(758, 345);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_Khohang
            // 
            this.tabPage_Khohang.Controls.Add(this.cmbThuKho);
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
            this.tabPage_Khohang.Controls.Add(this.label2);
            this.tabPage_Khohang.Controls.Add(this.txtSTT);
            this.tabPage_Khohang.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Khohang.Name = "tabPage_Khohang";
            this.tabPage_Khohang.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Khohang.Size = new System.Drawing.Size(750, 319);
            this.tabPage_Khohang.TabIndex = 0;
            this.tabPage_Khohang.Text = "1. Kho hàng";
            this.tabPage_Khohang.UseVisualStyleBackColor = true;
            // 
            // cmbThuKho
            // 
            this.cmbThuKho.FormattingEnabled = true;
            this.cmbThuKho.Location = new System.Drawing.Point(108, 150);
            this.cmbThuKho.Name = "cmbThuKho";
            this.cmbThuKho.Size = new System.Drawing.Size(149, 21);
            this.cmbThuKho.TabIndex = 14;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(108, 177);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGhiChu.Size = new System.Drawing.Size(524, 115);
            this.txtGhiChu.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Ghi chú:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Thủ kho:";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Location = new System.Drawing.Point(108, 120);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(149, 20);
            this.txtSoDienThoai.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Số điện thoại:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(108, 93);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(524, 20);
            this.txtDiaChi.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Địa chỉ:";
            // 
            // txtTenKho
            // 
            this.txtTenKho.Location = new System.Drawing.Point(108, 67);
            this.txtTenKho.Name = "txtTenKho";
            this.txtTenKho.Size = new System.Drawing.Size(149, 20);
            this.txtTenKho.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên kho:";
            // 
            // txtMaKho
            // 
            this.txtMaKho.Location = new System.Drawing.Point(108, 41);
            this.txtMaKho.Name = "txtMaKho";
            this.txtMaKho.Size = new System.Drawing.Size(149, 20);
            this.txtMaKho.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã kho:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số thứ tự:";
            // 
            // txtSTT
            // 
            this.txtSTT.Location = new System.Drawing.Point(108, 15);
            this.txtSTT.Name = "txtSTT";
            this.txtSTT.Size = new System.Drawing.Size(149, 20);
            this.txtSTT.TabIndex = 0;
            // 
            // tabPage_Hanghoa
            // 
            this.tabPage_Hanghoa.Controls.Add(this.dgvHangHoa);
            this.tabPage_Hanghoa.Controls.Add(this.panel2);
            this.tabPage_Hanghoa.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Hanghoa.Name = "tabPage_Hanghoa";
            this.tabPage_Hanghoa.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Hanghoa.Size = new System.Drawing.Size(750, 324);
            this.tabPage_Hanghoa.TabIndex = 1;
            this.tabPage_Hanghoa.Text = "2. Hàng hóa";
            this.tabPage_Hanghoa.UseVisualStyleBackColor = true;
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHangHoa.Location = new System.Drawing.Point(3, 49);
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.Size = new System.Drawing.Size(744, 272);
            this.dgvHangHoa.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(744, 46);
            this.panel2.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Chọn Kho Hàng Cần Xem:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(156, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(373, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // frmXuLy_KhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 415);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.palTren);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmXuLy_KhoHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kho hàng";
            this.Load += new System.EventHandler(this.frmXuLy_KhoHang_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.palTren.ResumeLayout(false);
            this.palTren.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Khohang.ResumeLayout(false);
            this.tabPage_Khohang.PerformLayout();
            this.tabPage_Hanghoa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel btnThem;
        private System.Windows.Forms.ToolStripStatusLabel btnGhiLai;
        private System.Windows.Forms.ToolStripStatusLabel btnIn;
        private System.Windows.Forms.ToolStripDropDownButton btnKhac;
        private System.Windows.Forms.ToolStripStatusLabel btnDong;
        private System.Windows.Forms.ToolStripMenuItem thiêtLâpThôngSôToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xoaChưngTưHiênThơiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem huyĐơnĐătHangHiênThơiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saoChepChưngTưTưToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saoChepChưngTưSangNhâpHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saoChepChưngTưToolStripMenuItem;
        private System.Windows.Forms.Panel palTren;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Khohang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaKho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSTT;
        private System.Windows.Forms.TabPage tabPage_Hanghoa;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenKho;
        private System.Windows.Forms.ComboBox cmbThuKho;
        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}