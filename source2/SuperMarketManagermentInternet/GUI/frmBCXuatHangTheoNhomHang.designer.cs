namespace GUI
{
    partial class frmBCXuatHangTheoNhomHang
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
            this.grbDieuKien = new System.Windows.Forms.GroupBox();
            this.rdbTatCa = new System.Windows.Forms.RadioButton();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.rdbMa = new System.Windows.Forms.RadioButton();
            this.rdbTen = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Thang = new System.Windows.Forms.Label();
            this.cbbthang = new System.Windows.Forms.ComboBox();
            this.cbbnam = new System.Windows.Forms.ComboBox();
            this.btnhienthi = new System.Windows.Forms.Button();
            this.lbtenbaocao = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslchitiet = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslPdf = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslWord = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslExcel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslthoat = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgvhienthi = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pntop.SuspendLayout();
            this.grbDieuKien.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvhienthi)).BeginInit();
            this.SuspendLayout();
            // 
            // pntop
            // 
            this.pntop.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pntop.Controls.Add(this.grbDieuKien);
            this.pntop.Controls.Add(this.label1);
            this.pntop.Controls.Add(this.Thang);
            this.pntop.Controls.Add(this.cbbthang);
            this.pntop.Controls.Add(this.cbbnam);
            this.pntop.Controls.Add(this.btnhienthi);
            this.pntop.Controls.Add(this.lbtenbaocao);
            this.pntop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pntop.Location = new System.Drawing.Point(0, 0);
            this.pntop.Name = "pntop";
            this.pntop.Size = new System.Drawing.Size(594, 140);
            this.pntop.TabIndex = 0;
            this.pntop.DoubleClick += new System.EventHandler(this.pntop_DoubleClick);
            // 
            // grbDieuKien
            // 
            this.grbDieuKien.Controls.Add(this.rdbTatCa);
            this.grbDieuKien.Controls.Add(this.txtTimKiem);
            this.grbDieuKien.Controls.Add(this.rdbMa);
            this.grbDieuKien.Controls.Add(this.rdbTen);
            this.grbDieuKien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbDieuKien.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDieuKien.Location = new System.Drawing.Point(0, 74);
            this.grbDieuKien.Name = "grbDieuKien";
            this.grbDieuKien.Size = new System.Drawing.Size(594, 66);
            this.grbDieuKien.TabIndex = 12;
            this.grbDieuKien.TabStop = false;
            this.grbDieuKien.Text = "Tìm Kiếm";
            // 
            // rdbTatCa
            // 
            this.rdbTatCa.AutoSize = true;
            this.rdbTatCa.Checked = true;
            this.rdbTatCa.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTatCa.Location = new System.Drawing.Point(227, 24);
            this.rdbTatCa.Name = "rdbTatCa";
            this.rdbTatCa.Size = new System.Drawing.Size(57, 18);
            this.rdbTatCa.TabIndex = 1;
            this.rdbTatCa.TabStop = true;
            this.rdbTatCa.Text = "Tất Cả";
            this.rdbTatCa.UseVisualStyleBackColor = true;
            this.rdbTatCa.CheckedChanged += new System.EventHandler(this.rdbTatCa_CheckedChanged);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtTimKiem.Location = new System.Drawing.Point(291, 20);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(291, 20);
            this.txtTimKiem.TabIndex = 7;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // rdbMa
            // 
            this.rdbMa.AutoSize = true;
            this.rdbMa.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMa.Location = new System.Drawing.Point(122, 24);
            this.rdbMa.Name = "rdbMa";
            this.rdbMa.Size = new System.Drawing.Size(72, 18);
            this.rdbMa.TabIndex = 0;
            this.rdbMa.Text = "Mã Nhóm";
            this.rdbMa.UseVisualStyleBackColor = true;
            // 
            // rdbTen
            // 
            this.rdbTen.AutoSize = true;
            this.rdbTen.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTen.Location = new System.Drawing.Point(13, 24);
            this.rdbTen.Name = "rdbTen";
            this.rdbTen.Size = new System.Drawing.Size(76, 18);
            this.rdbTen.TabIndex = 0;
            this.rdbTen.Text = "Tên Nhóm";
            this.rdbTen.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(210, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Năm:";
            // 
            // Thang
            // 
            this.Thang.AutoSize = true;
            this.Thang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Thang.Location = new System.Drawing.Point(51, 50);
            this.Thang.Name = "Thang";
            this.Thang.Size = new System.Drawing.Size(47, 13);
            this.Thang.TabIndex = 10;
            this.Thang.Text = "Tháng:";
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
            this.cbbthang.Location = new System.Drawing.Point(109, 46);
            this.cbbthang.Name = "cbbthang";
            this.cbbthang.Size = new System.Drawing.Size(59, 22);
            this.cbbthang.TabIndex = 8;
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
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cbbnam.Location = new System.Drawing.Point(252, 46);
            this.cbbnam.Name = "cbbnam";
            this.cbbnam.Size = new System.Drawing.Size(88, 22);
            this.cbbnam.TabIndex = 7;
            // 
            // btnhienthi
            // 
            this.btnhienthi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhienthi.Location = new System.Drawing.Point(362, 45);
            this.btnhienthi.Name = "btnhienthi";
            this.btnhienthi.Size = new System.Drawing.Size(75, 24);
            this.btnhienthi.TabIndex = 3;
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
            this.lbtenbaocao.Size = new System.Drawing.Size(313, 20);
            this.lbtenbaocao.TabIndex = 0;
            this.lbtenbaocao.Text = "Báo Cáo Xuất Hàng Theo Nhóm Hàng";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslchitiet,
            this.tsslPdf,
            this.tsslWord,
            this.tsslExcel,
            this.tsslthoat});
            this.statusStrip1.Location = new System.Drawing.Point(0, 375);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(594, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslchitiet
            // 
            this.tsslchitiet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tsslchitiet.Image = global::GUI.Properties.Resources.In;
            this.tsslchitiet.Name = "tsslchitiet";
            this.tsslchitiet.Size = new System.Drawing.Size(109, 21);
            this.tsslchitiet.Spring = true;
            this.tsslchitiet.Text = "Chi Tiết";
            this.tsslchitiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslchitiet.Click += new System.EventHandler(this.tsslchitiet_Click);
            this.tsslchitiet.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslchitiet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslPdf
            // 
            this.tsslPdf.Enabled = false;
            this.tsslPdf.Image = global::GUI.Properties.Resources.icon_pdf;
            this.tsslPdf.Name = "tsslPdf";
            this.tsslPdf.Size = new System.Drawing.Size(109, 21);
            this.tsslPdf.Spring = true;
            this.tsslPdf.Text = "PDF";
            this.tsslPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslPdf.Click += new System.EventHandler(this.tsslPdf_Click);
            this.tsslPdf.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslPdf.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslWord
            // 
            this.tsslWord.Enabled = false;
            this.tsslWord.Image = global::GUI.Properties.Resources.DocX_Viewer_icon;
            this.tsslWord.Name = "tsslWord";
            this.tsslWord.Size = new System.Drawing.Size(109, 21);
            this.tsslWord.Spring = true;
            this.tsslWord.Text = "Word";
            this.tsslWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslWord.Click += new System.EventHandler(this.tsslWord_Click);
            this.tsslWord.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslWord.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslExcel
            // 
            this.tsslExcel.Enabled = false;
            this.tsslExcel.Image = global::GUI.Properties.Resources.excel_icon4;
            this.tsslExcel.Name = "tsslExcel";
            this.tsslExcel.Size = new System.Drawing.Size(109, 21);
            this.tsslExcel.Spring = true;
            this.tsslExcel.Text = "Excel";
            this.tsslExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslExcel.Click += new System.EventHandler(this.tsslExcel_Click);
            this.tsslExcel.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslExcel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslthoat
            // 
            this.tsslthoat.Image = global::GUI.Properties.Resources.Xoa;
            this.tsslthoat.Name = "tsslthoat";
            this.tsslthoat.Size = new System.Drawing.Size(109, 21);
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
            this.panel1.Location = new System.Drawing.Point(0, 140);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 235);
            this.panel1.TabIndex = 2;
            // 
            // dtgvhienthi
            // 
            this.dtgvhienthi.BackgroundColor = System.Drawing.Color.White;
            this.dtgvhienthi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvhienthi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvhienthi.Location = new System.Drawing.Point(0, 0);
            this.dtgvhienthi.Name = "dtgvhienthi";
            this.dtgvhienthi.Size = new System.Drawing.Size(594, 235);
            this.dtgvhienthi.TabIndex = 0;
            this.dtgvhienthi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvhienthi_CellDoubleClick);
            // 
            // frmBCXuatHangTheoNhomHang
            // 
            this.AcceptButton = this.btnhienthi;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 401);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pntop);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBCXuatHangTheoNhomHang";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmBCXuatHangTheoNhomHang_Load);
            this.pntop.ResumeLayout(false);
            this.pntop.PerformLayout();
            this.grbDieuKien.ResumeLayout(false);
            this.grbDieuKien.PerformLayout();
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
        private System.Windows.Forms.Button btnhienthi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Thang;
        private System.Windows.Forms.ComboBox cbbthang;
        private System.Windows.Forms.ComboBox cbbnam;
        private System.Windows.Forms.ToolStripStatusLabel tsslPdf;
        private System.Windows.Forms.ToolStripStatusLabel tsslWord;
        private System.Windows.Forms.ToolStripStatusLabel tsslExcel;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox grbDieuKien;
        private System.Windows.Forms.RadioButton rdbTatCa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.RadioButton rdbMa;
        private System.Windows.Forms.RadioButton rdbTen;
    }
}