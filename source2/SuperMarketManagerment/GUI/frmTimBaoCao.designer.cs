namespace GUI
{
    partial class frmTimBaoCao
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
            this.palTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.palFill = new System.Windows.Forms.Panel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.lblThang_Quy = new System.Windows.Forms.Label();
            this.lblNam = new System.Windows.Forms.Label();
            this.cbxThang_Quy = new System.Windows.Forms.ComboBox();
            this.cbxNam = new System.Windows.Forms.ComboBox();
            this.makNgayketthuc = new System.Windows.Forms.MaskedTextBox();
            this.makNgaybatdau = new System.Windows.Forms.MaskedTextBox();
            this.lblNgayketthuc = new System.Windows.Forms.Label();
            this.lblNgaybatdau = new System.Windows.Forms.Label();
            this.cbxCongty = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkKiemtratrangthaithanhtoan = new System.Windows.Forms.CheckBox();
            this.cbxLoaibaocao = new System.Windows.Forms.ComboBox();
            this.groupDieukienloc = new System.Windows.Forms.GroupBox();
            this.rdoKhoangthoigian = new System.Windows.Forms.RadioButton();
            this.rdoTheongay = new System.Windows.Forms.RadioButton();
            this.rdoTheothang = new System.Windows.Forms.RadioButton();
            this.rdoTheoquy = new System.Windows.Forms.RadioButton();
            this.rdoTheonam = new System.Windows.Forms.RadioButton();
            this.palTop.SuspendLayout();
            this.palFill.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupDieukienloc.SuspendLayout();
            this.SuspendLayout();
            // 
            // palTop
            // 
            this.palTop.BackColor = System.Drawing.SystemColors.Control;
            this.palTop.Controls.Add(this.label1);
            this.palTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.palTop.Location = new System.Drawing.Point(0, 0);
            this.palTop.Name = "palTop";
            this.palTop.Size = new System.Drawing.Size(558, 41);
            this.palTop.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn điều kiện lọc báo cáo";
            // 
            // palFill
            // 
            this.palFill.BackColor = System.Drawing.Color.White;
            this.palFill.Controls.Add(this.linkLabel2);
            this.palFill.Controls.Add(this.linkLabel1);
            this.palFill.Controls.Add(this.lblThang_Quy);
            this.palFill.Controls.Add(this.lblNam);
            this.palFill.Controls.Add(this.cbxThang_Quy);
            this.palFill.Controls.Add(this.cbxNam);
            this.palFill.Controls.Add(this.makNgayketthuc);
            this.palFill.Controls.Add(this.makNgaybatdau);
            this.palFill.Controls.Add(this.lblNgayketthuc);
            this.palFill.Controls.Add(this.lblNgaybatdau);
            this.palFill.Controls.Add(this.cbxCongty);
            this.palFill.Controls.Add(this.statusStrip1);
            this.palFill.Controls.Add(this.checkKiemtratrangthaithanhtoan);
            this.palFill.Controls.Add(this.cbxLoaibaocao);
            this.palFill.Controls.Add(this.groupDieukienloc);
            this.palFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palFill.Location = new System.Drawing.Point(0, 41);
            this.palFill.Name = "palFill";
            this.palFill.Size = new System.Drawing.Size(558, 220);
            this.palFill.TabIndex = 1;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.Location = new System.Drawing.Point(322, 143);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(71, 13);
            this.linkLabel2.TabIndex = 37;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "(dd/mm/yyyy)";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(322, 111);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(71, 13);
            this.linkLabel1.TabIndex = 36;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "(dd/mm/yyyy)";
            // 
            // lblThang_Quy
            // 
            this.lblThang_Quy.AutoSize = true;
            this.lblThang_Quy.Location = new System.Drawing.Point(404, 139);
            this.lblThang_Quy.Name = "lblThang_Quy";
            this.lblThang_Quy.Size = new System.Drawing.Size(41, 13);
            this.lblThang_Quy.TabIndex = 14;
            this.lblThang_Quy.Text = "Tháng:";
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.Location = new System.Drawing.Point(413, 112);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(32, 13);
            this.lblNam.TabIndex = 13;
            this.lblNam.Text = "Năm:";
            // 
            // cbxThang_Quy
            // 
            this.cbxThang_Quy.FormattingEnabled = true;
            this.cbxThang_Quy.Location = new System.Drawing.Point(451, 136);
            this.cbxThang_Quy.Name = "cbxThang_Quy";
            this.cbxThang_Quy.Size = new System.Drawing.Size(85, 21);
            this.cbxThang_Quy.TabIndex = 12;
            // 
            // cbxNam
            // 
            this.cbxNam.FormattingEnabled = true;
            this.cbxNam.Location = new System.Drawing.Point(451, 109);
            this.cbxNam.Name = "cbxNam";
            this.cbxNam.Size = new System.Drawing.Size(85, 21);
            this.cbxNam.TabIndex = 11;
            // 
            // makNgayketthuc
            // 
            this.makNgayketthuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.makNgayketthuc.Location = new System.Drawing.Point(233, 136);
            this.makNgayketthuc.Mask = "00/00/0000";
            this.makNgayketthuc.Name = "makNgayketthuc";
            this.makNgayketthuc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.makNgayketthuc.Size = new System.Drawing.Size(83, 20);
            this.makNgayketthuc.TabIndex = 10;
            this.makNgayketthuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // makNgaybatdau
            // 
            this.makNgaybatdau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.makNgaybatdau.Location = new System.Drawing.Point(233, 109);
            this.makNgaybatdau.Mask = "00/00/0000";
            this.makNgaybatdau.Name = "makNgaybatdau";
            this.makNgaybatdau.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.makNgaybatdau.Size = new System.Drawing.Size(83, 20);
            this.makNgaybatdau.TabIndex = 9;
            this.makNgaybatdau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblNgayketthuc
            // 
            this.lblNgayketthuc.AutoSize = true;
            this.lblNgayketthuc.Location = new System.Drawing.Point(171, 139);
            this.lblNgayketthuc.Name = "lblNgayketthuc";
            this.lblNgayketthuc.Size = new System.Drawing.Size(56, 13);
            this.lblNgayketthuc.TabIndex = 8;
            this.lblNgayketthuc.Text = "Đến ngày:";
            // 
            // lblNgaybatdau
            // 
            this.lblNgaybatdau.AutoSize = true;
            this.lblNgaybatdau.Location = new System.Drawing.Point(178, 112);
            this.lblNgaybatdau.Name = "lblNgaybatdau";
            this.lblNgaybatdau.Size = new System.Drawing.Size(49, 13);
            this.lblNgaybatdau.TabIndex = 7;
            this.lblNgaybatdau.Text = "Từ ngày:";
            // 
            // cbxCongty
            // 
            this.cbxCongty.FormattingEnabled = true;
            this.cbxCongty.Location = new System.Drawing.Point(233, 30);
            this.cbxCongty.Name = "cbxCongty";
            this.cbxCongty.Size = new System.Drawing.Size(303, 21);
            this.cbxCongty.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(164, 194);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(394, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::GUI.Properties.Resources.Loc;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(174, 21);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Xem";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            this.toolStripStatusLabel1.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Image = global::GUI.Properties.Resources.Xoa;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(174, 21);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "Trở về";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            this.toolStripStatusLabel2.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // checkKiemtratrangthaithanhtoan
            // 
            this.checkKiemtratrangthaithanhtoan.AutoSize = true;
            this.checkKiemtratrangthaithanhtoan.Checked = true;
            this.checkKiemtratrangthaithanhtoan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkKiemtratrangthaithanhtoan.Location = new System.Drawing.Point(233, 85);
            this.checkKiemtratrangthaithanhtoan.Name = "checkKiemtratrangthaithanhtoan";
            this.checkKiemtratrangthaithanhtoan.Size = new System.Drawing.Size(94, 17);
            this.checkKiemtratrangthaithanhtoan.TabIndex = 3;
            this.checkKiemtratrangthaithanhtoan.Text = "Đã thanh toán";
            this.checkKiemtratrangthaithanhtoan.UseVisualStyleBackColor = true;
            // 
            // cbxLoaibaocao
            // 
            this.cbxLoaibaocao.FormattingEnabled = true;
            this.cbxLoaibaocao.Location = new System.Drawing.Point(233, 58);
            this.cbxLoaibaocao.Name = "cbxLoaibaocao";
            this.cbxLoaibaocao.Size = new System.Drawing.Size(303, 21);
            this.cbxLoaibaocao.TabIndex = 1;
            // 
            // groupDieukienloc
            // 
            this.groupDieukienloc.Controls.Add(this.rdoKhoangthoigian);
            this.groupDieukienloc.Controls.Add(this.rdoTheongay);
            this.groupDieukienloc.Controls.Add(this.rdoTheothang);
            this.groupDieukienloc.Controls.Add(this.rdoTheoquy);
            this.groupDieukienloc.Controls.Add(this.rdoTheonam);
            this.groupDieukienloc.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupDieukienloc.Location = new System.Drawing.Point(0, 0);
            this.groupDieukienloc.Name = "groupDieukienloc";
            this.groupDieukienloc.Size = new System.Drawing.Size(164, 220);
            this.groupDieukienloc.TabIndex = 0;
            this.groupDieukienloc.TabStop = false;
            this.groupDieukienloc.Text = "Lọc theo";
            // 
            // rdoKhoangthoigian
            // 
            this.rdoKhoangthoigian.AutoSize = true;
            this.rdoKhoangthoigian.Location = new System.Drawing.Point(16, 126);
            this.rdoKhoangthoigian.Name = "rdoKhoangthoigian";
            this.rdoKhoangthoigian.Size = new System.Drawing.Size(144, 17);
            this.rdoKhoangthoigian.TabIndex = 4;
            this.rdoKhoangthoigian.Text = "5. Theo khoảng thời gian";
            this.rdoKhoangthoigian.UseVisualStyleBackColor = true;
            this.rdoKhoangthoigian.CheckedChanged += new System.EventHandler(this.rdoKhoangthoigian_CheckedChanged);
            // 
            // rdoTheongay
            // 
            this.rdoTheongay.AutoSize = true;
            this.rdoTheongay.Location = new System.Drawing.Point(16, 103);
            this.rdoTheongay.Name = "rdoTheongay";
            this.rdoTheongay.Size = new System.Drawing.Size(88, 17);
            this.rdoTheongay.TabIndex = 3;
            this.rdoTheongay.Text = "4. Theo ngày";
            this.rdoTheongay.UseVisualStyleBackColor = true;
            this.rdoTheongay.CheckedChanged += new System.EventHandler(this.rdoTheongay_CheckedChanged);
            // 
            // rdoTheothang
            // 
            this.rdoTheothang.AutoSize = true;
            this.rdoTheothang.Location = new System.Drawing.Point(16, 80);
            this.rdoTheothang.Name = "rdoTheothang";
            this.rdoTheothang.Size = new System.Drawing.Size(92, 17);
            this.rdoTheothang.TabIndex = 2;
            this.rdoTheothang.Text = "3. Theo tháng";
            this.rdoTheothang.UseVisualStyleBackColor = true;
            this.rdoTheothang.CheckedChanged += new System.EventHandler(this.rdoTheothang_CheckedChanged);
            // 
            // rdoTheoquy
            // 
            this.rdoTheoquy.AutoSize = true;
            this.rdoTheoquy.Checked = true;
            this.rdoTheoquy.Location = new System.Drawing.Point(16, 57);
            this.rdoTheoquy.Name = "rdoTheoquy";
            this.rdoTheoquy.Size = new System.Drawing.Size(82, 17);
            this.rdoTheoquy.TabIndex = 1;
            this.rdoTheoquy.TabStop = true;
            this.rdoTheoquy.Text = "2. Theo quý";
            this.rdoTheoquy.UseVisualStyleBackColor = true;
            this.rdoTheoquy.CheckedChanged += new System.EventHandler(this.rdoTheoquy_CheckedChanged);
            // 
            // rdoTheonam
            // 
            this.rdoTheonam.AutoSize = true;
            this.rdoTheonam.Location = new System.Drawing.Point(16, 34);
            this.rdoTheonam.Name = "rdoTheonam";
            this.rdoTheonam.Size = new System.Drawing.Size(85, 17);
            this.rdoTheonam.TabIndex = 0;
            this.rdoTheonam.Text = "1. Theo năm";
            this.rdoTheonam.UseVisualStyleBackColor = true;
            this.rdoTheonam.CheckedChanged += new System.EventHandler(this.rdoTheonam_CheckedChanged);
            // 
            // frmTimBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 261);
            this.Controls.Add(this.palFill);
            this.Controls.Add(this.palTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTimBaoCao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo Cáo - Tìm Kiếm Báo Cáo";
            this.Load += new System.EventHandler(this.frmTimBaoCao_Load);
            this.palTop.ResumeLayout(false);
            this.palTop.PerformLayout();
            this.palFill.ResumeLayout(false);
            this.palFill.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupDieukienloc.ResumeLayout(false);
            this.groupDieukienloc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel palTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel palFill;
        private System.Windows.Forms.ComboBox cbxLoaibaocao;
        private System.Windows.Forms.GroupBox groupDieukienloc;
        private System.Windows.Forms.RadioButton rdoKhoangthoigian;
        private System.Windows.Forms.RadioButton rdoTheongay;
        private System.Windows.Forms.RadioButton rdoTheothang;
        private System.Windows.Forms.RadioButton rdoTheoquy;
        private System.Windows.Forms.RadioButton rdoTheonam;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.CheckBox checkKiemtratrangthaithanhtoan;
        private System.Windows.Forms.ComboBox cbxCongty;
        private System.Windows.Forms.Label lblNgayketthuc;
        private System.Windows.Forms.Label lblNgaybatdau;
        private System.Windows.Forms.Label lblThang_Quy;
        private System.Windows.Forms.Label lblNam;
        private System.Windows.Forms.ComboBox cbxThang_Quy;
        private System.Windows.Forms.ComboBox cbxNam;
        private System.Windows.Forms.MaskedTextBox makNgayketthuc;
        private System.Windows.Forms.MaskedTextBox makNgaybatdau;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}