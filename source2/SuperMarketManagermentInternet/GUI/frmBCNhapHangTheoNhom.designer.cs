namespace GUI
{
    partial class frmBCNhapHangTheoNhom
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
            this.pntop = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbtimkiem1 = new System.Windows.Forms.RadioButton();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.rdbtimkiem3 = new System.Windows.Forms.RadioButton();
            this.rdbtimkiem2 = new System.Windows.Forms.RadioButton();
            this.cbbnam = new System.Windows.Forms.ComboBox();
            this.cbbthang = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnhienthi = new System.Windows.Forms.Button();
            this.lbtenbaocao = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslchitiet = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslPdf = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslWord = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslexcel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslthoat = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgvhienthi = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.pntop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvhienthi)).BeginInit();
            this.SuspendLayout();
            // 
            // pntop
            // 
            this.pntop.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pntop.Controls.Add(this.groupBox1);
            this.pntop.Controls.Add(this.cbbnam);
            this.pntop.Controls.Add(this.cbbthang);
            this.pntop.Controls.Add(this.label2);
            this.pntop.Controls.Add(this.label1);
            this.pntop.Controls.Add(this.btnhienthi);
            this.pntop.Controls.Add(this.lbtenbaocao);
            this.pntop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pntop.Location = new System.Drawing.Point(0, 0);
            this.pntop.Name = "pntop";
            this.pntop.Size = new System.Drawing.Size(594, 163);
            this.pntop.TabIndex = 0;
            this.pntop.DoubleClick += new System.EventHandler(this.pntop_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rdbtimkiem1);
            this.groupBox1.Controls.Add(this.txttimkiem);
            this.groupBox1.Controls.Add(this.rdbtimkiem3);
            this.groupBox1.Controls.Add(this.rdbtimkiem2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(0, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 79);
            this.groupBox1.TabIndex = 89;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // rdbtimkiem1
            // 
            this.rdbtimkiem1.AutoSize = true;
            this.rdbtimkiem1.Checked = true;
            this.rdbtimkiem1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtimkiem1.Location = new System.Drawing.Point(13, 24);
            this.rdbtimkiem1.Name = "rdbtimkiem1";
            this.rdbtimkiem1.Size = new System.Drawing.Size(70, 18);
            this.rdbtimkiem1.TabIndex = 4;
            this.rdbtimkiem1.TabStop = true;
            this.rdbtimkiem1.Text = "Mã nhóm";
            this.rdbtimkiem1.UseVisualStyleBackColor = true;
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(169, 23);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(419, 20);
            this.txttimkiem.TabIndex = 3;
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            // 
            // rdbtimkiem3
            // 
            this.rdbtimkiem3.AutoSize = true;
            this.rdbtimkiem3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtimkiem3.Location = new System.Drawing.Point(165, 73);
            this.rdbtimkiem3.Name = "rdbtimkiem3";
            this.rdbtimkiem3.Size = new System.Drawing.Size(55, 18);
            this.rdbtimkiem3.TabIndex = 2;
            this.rdbtimkiem3.Text = "Tất cả";
            this.rdbtimkiem3.UseVisualStyleBackColor = true;
            this.rdbtimkiem3.Visible = false;
            // 
            // rdbtimkiem2
            // 
            this.rdbtimkiem2.AutoSize = true;
            this.rdbtimkiem2.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtimkiem2.Location = new System.Drawing.Point(89, 24);
            this.rdbtimkiem2.Name = "rdbtimkiem2";
            this.rdbtimkiem2.Size = new System.Drawing.Size(74, 18);
            this.rdbtimkiem2.TabIndex = 1;
            this.rdbtimkiem2.TabStop = true;
            this.rdbtimkiem2.Text = "Tên nhóm";
            this.rdbtimkiem2.UseVisualStyleBackColor = true;
            // 
            // cbbnam
            // 
            this.cbbnam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbnam.FormattingEnabled = true;
            this.cbbnam.Items.AddRange(new object[] {
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cbbnam.Location = new System.Drawing.Point(165, 51);
            this.cbbnam.Name = "cbbnam";
            this.cbbnam.Size = new System.Drawing.Size(67, 22);
            this.cbbnam.TabIndex = 86;
            // 
            // cbbthang
            // 
            this.cbbthang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbthang.FormattingEnabled = true;
            this.cbbthang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbbthang.Location = new System.Drawing.Point(75, 51);
            this.cbbthang.Name = "cbbthang";
            this.cbbthang.Size = new System.Drawing.Size(47, 22);
            this.cbbthang.TabIndex = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 84;
            this.label2.Text = "Năm:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 83;
            this.label1.Text = "Tháng:";
            // 
            // btnhienthi
            // 
            this.btnhienthi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhienthi.Location = new System.Drawing.Point(238, 51);
            this.btnhienthi.Name = "btnhienthi";
            this.btnhienthi.Size = new System.Drawing.Size(75, 24);
            this.btnhienthi.TabIndex = 82;
            this.btnhienthi.Text = "Hiển Thị";
            this.btnhienthi.UseVisualStyleBackColor = true;
            this.btnhienthi.Click += new System.EventHandler(this.btnhienthi_Click);
            // 
            // lbtenbaocao
            // 
            this.lbtenbaocao.AutoSize = true;
            this.lbtenbaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtenbaocao.ForeColor = System.Drawing.Color.White;
            this.lbtenbaocao.Location = new System.Drawing.Point(12, 10);
            this.lbtenbaocao.Name = "lbtenbaocao";
            this.lbtenbaocao.Size = new System.Drawing.Size(221, 20);
            this.lbtenbaocao.TabIndex = 0;
            this.lbtenbaocao.Text = "Báo Cáo Nhập Theo Nhóm";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslchitiet,
            this.tsslPdf,
            this.tsslWord,
            this.tsslexcel,
            this.tsslthoat});
            this.statusStrip1.Location = new System.Drawing.Point(0, 417);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(594, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::GUI.Properties.Resources.refresh;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(96, 21);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Nạp lại";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            this.toolStripStatusLabel1.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslchitiet
            // 
            this.tsslchitiet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tsslchitiet.Image = global::GUI.Properties.Resources.In;
            this.tsslchitiet.Name = "tsslchitiet";
            this.tsslchitiet.Size = new System.Drawing.Size(91, 21);
            this.tsslchitiet.Spring = true;
            this.tsslchitiet.Text = "Xem";
            this.tsslchitiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslchitiet.Click += new System.EventHandler(this.tsslchitiet_Click);
            this.tsslchitiet.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslchitiet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslPdf
            // 
            this.tsslPdf.Image = global::GUI.Properties.Resources.icon_pdf;
            this.tsslPdf.Name = "tsslPdf";
            this.tsslPdf.Size = new System.Drawing.Size(91, 21);
            this.tsslPdf.Spring = true;
            this.tsslPdf.Text = "PDF";
            this.tsslPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslPdf.Click += new System.EventHandler(this.tsslPdf_Click);
            this.tsslPdf.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslPdf.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslWord
            // 
            this.tsslWord.Image = global::GUI.Properties.Resources.DocX_Viewer_icon;
            this.tsslWord.Name = "tsslWord";
            this.tsslWord.Size = new System.Drawing.Size(91, 21);
            this.tsslWord.Spring = true;
            this.tsslWord.Text = "Word";
            this.tsslWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslWord.Click += new System.EventHandler(this.tsslWord_Click);
            this.tsslWord.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslWord.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslexcel
            // 
            this.tsslexcel.Image = global::GUI.Properties.Resources.excel_icon4;
            this.tsslexcel.Name = "tsslexcel";
            this.tsslexcel.Size = new System.Drawing.Size(91, 21);
            this.tsslexcel.Spring = true;
            this.tsslexcel.Text = "Excel";
            this.tsslexcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslexcel.Click += new System.EventHandler(this.tsslexcel_Click);
            this.tsslexcel.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslexcel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslthoat
            // 
            this.tsslthoat.Image = global::GUI.Properties.Resources.Xoa;
            this.tsslthoat.Name = "tsslthoat";
            this.tsslthoat.Size = new System.Drawing.Size(96, 21);
            this.tsslthoat.Spring = true;
            this.tsslthoat.Text = "Thoát";
            this.tsslthoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslthoat.Click += new System.EventHandler(this.tsslthoat_Click);
            this.tsslthoat.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslthoat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtgvhienthi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 254);
            this.panel1.TabIndex = 2;
            // 
            // dtgvhienthi
            // 
            this.dtgvhienthi.BackgroundColor = System.Drawing.Color.White;
            this.dtgvhienthi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvhienthi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvhienthi.Location = new System.Drawing.Point(0, 0);
            this.dtgvhienthi.Name = "dtgvhienthi";
            this.dtgvhienthi.Size = new System.Drawing.Size(594, 254);
            this.dtgvhienthi.TabIndex = 0;
            this.dtgvhienthi.TabStop = false;
            this.dtgvhienthi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvhienthi_CellClick);
            this.dtgvhienthi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvhienthi_CellDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 52);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 95;
            this.label3.Text = "Tổng: 0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmBCNhapHangTheoNhom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 443);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pntop);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBCNhapHangTheoNhom";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmBCXuatNhapTonTheoKho_Load);
            this.pntop.ResumeLayout(false);
            this.pntop.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvhienthi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pntop;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslchitiet;
        private System.Windows.Forms.ToolStripStatusLabel tsslthoat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dtgvhienthi;
        private System.Windows.Forms.Label lbtenbaocao;
        private System.Windows.Forms.ComboBox cbbnam;
        private System.Windows.Forms.ComboBox cbbthang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnhienthi;
        private System.Windows.Forms.ToolStripStatusLabel tsslPdf;
        private System.Windows.Forms.ToolStripStatusLabel tsslWord;
        private System.Windows.Forms.ToolStripStatusLabel tsslexcel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbtimkiem1;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.RadioButton rdbtimkiem3;
        private System.Windows.Forms.RadioButton rdbtimkiem2;
        private System.Windows.Forms.Label label3;
    }
}