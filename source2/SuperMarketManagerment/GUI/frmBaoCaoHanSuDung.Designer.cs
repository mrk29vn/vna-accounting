namespace GUI
{
    partial class frmBaoCaoHanSuDung
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
            this.dtgvHienThi = new System.Windows.Forms.DataGridView();
            this.btnThoat = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLocDieuKien = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbtenbaocao = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnNapLai = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnXem = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExcel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnWord = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPDF = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.rdbMaHang = new System.Windows.Forms.RadioButton();
            this.rdbHanSudung = new System.Windows.Forms.RadioButton();
            this.rdbTenHang = new System.Windows.Forms.RadioButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHienThi)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvHienThi
            // 
            this.dtgvHienThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvHienThi.BackgroundColor = System.Drawing.Color.White;
            this.dtgvHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHienThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvHienThi.Location = new System.Drawing.Point(0, 0);
            this.dtgvHienThi.Name = "dtgvHienThi";
            this.dtgvHienThi.Size = new System.Drawing.Size(901, 263);
            this.dtgvHienThi.TabIndex = 0;
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::GUI.Properties.Resources.Xoa;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(122, 21);
            this.btnThoat.Spring = true;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            this.btnThoat.MouseLeave += new System.EventHandler(this.btnThoat_MouseLeave);
            this.btnThoat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnThoat_MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvHienThi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(901, 263);
            this.panel2.TabIndex = 6;
            // 
            // btnLocDieuKien
            // 
            this.btnLocDieuKien.Image = global::GUI.Properties.Resources.Loc;
            this.btnLocDieuKien.Name = "btnLocDieuKien";
            this.btnLocDieuKien.Size = new System.Drawing.Size(122, 21);
            this.btnLocDieuKien.Spring = true;
            this.btnLocDieuKien.Text = "Lọc điều kiện";
            this.btnLocDieuKien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLocDieuKien.Click += new System.EventHandler(this.btnLocDieuKien_Click);
            this.btnLocDieuKien.MouseLeave += new System.EventHandler(this.btnLocDieuKien_MouseLeave);
            this.btnLocDieuKien.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnLocDieuKien_MouseMove);
            // 
            // lbtenbaocao
            // 
            this.lbtenbaocao.AutoSize = true;
            this.lbtenbaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtenbaocao.ForeColor = System.Drawing.Color.White;
            this.lbtenbaocao.Location = new System.Drawing.Point(12, 9);
            this.lbtenbaocao.Name = "lbtenbaocao";
            this.lbtenbaocao.Size = new System.Drawing.Size(198, 20);
            this.lbtenbaocao.TabIndex = 1;
            this.lbtenbaocao.Text = "Báo Cáo Hàng Hết Hạn";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNapLai,
            this.btnXem,
            this.btnExcel,
            this.btnWord,
            this.btnPDF,
            this.btnLocDieuKien,
            this.btnThoat});
            this.statusStrip1.Location = new System.Drawing.Point(0, 346);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(901, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnNapLai
            // 
            this.btnNapLai.Image = global::GUI.Properties.Resources.refresh;
            this.btnNapLai.Name = "btnNapLai";
            this.btnNapLai.Size = new System.Drawing.Size(122, 21);
            this.btnNapLai.Spring = true;
            this.btnNapLai.Text = "Nạp lại";
            this.btnNapLai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNapLai.Click += new System.EventHandler(this.btnNapLai_Click);
            this.btnNapLai.MouseLeave += new System.EventHandler(this.btnNapLai_MouseLeave);
            this.btnNapLai.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNapLai_MouseMove);
            // 
            // btnXem
            // 
            this.btnXem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnXem.Enabled = false;
            this.btnXem.Image = global::GUI.Properties.Resources.In;
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(122, 21);
            this.btnXem.Spring = true;
            this.btnXem.Text = "Xem";
            this.btnXem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            this.btnXem.MouseLeave += new System.EventHandler(this.btnXem_MouseLeave);
            this.btnXem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnXem_MouseMove);
            // 
            // btnExcel
            // 
            this.btnExcel.Enabled = false;
            this.btnExcel.Image = global::GUI.Properties.Resources.excel_icon4;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(122, 21);
            this.btnExcel.Spring = true;
            this.btnExcel.Text = "Excel";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            this.btnExcel.MouseLeave += new System.EventHandler(this.btnExcel_MouseLeave);
            this.btnExcel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcel_MouseMove);
            // 
            // btnWord
            // 
            this.btnWord.Enabled = false;
            this.btnWord.Image = global::GUI.Properties.Resources.DocX_Viewer_icon;
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(122, 21);
            this.btnWord.Spring = true;
            this.btnWord.Text = "Word";
            this.btnWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            this.btnWord.MouseLeave += new System.EventHandler(this.btnWord_MouseLeave);
            this.btnWord.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnWord_MouseMove);
            // 
            // btnPDF
            // 
            this.btnPDF.Enabled = false;
            this.btnPDF.Image = global::GUI.Properties.Resources.icon_pdf;
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(122, 21);
            this.btnPDF.Spring = true;
            this.btnPDF.Text = "PDF";
            this.btnPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            this.btnPDF.MouseLeave += new System.EventHandler(this.btnPDF_MouseLeave);
            this.btnPDF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPDF_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.txtTimKiem);
            this.panel1.Controls.Add(this.rdbMaHang);
            this.panel1.Controls.Add(this.rdbHanSudung);
            this.panel1.Controls.Add(this.rdbTenHang);
            this.panel1.Controls.Add(this.lbtenbaocao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(901, 83);
            this.panel1.TabIndex = 4;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(354, 46);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(457, 20);
            this.txtTimKiem.TabIndex = 5;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // rdbMaHang
            // 
            this.rdbMaHang.AutoSize = true;
            this.rdbMaHang.Location = new System.Drawing.Point(23, 45);
            this.rdbMaHang.Name = "rdbMaHang";
            this.rdbMaHang.Size = new System.Drawing.Size(69, 17);
            this.rdbMaHang.TabIndex = 4;
            this.rdbMaHang.TabStop = true;
            this.rdbMaHang.Text = "Mã Hàng";
            this.rdbMaHang.UseVisualStyleBackColor = true;
            // 
            // rdbHanSudung
            // 
            this.rdbHanSudung.AutoSize = true;
            this.rdbHanSudung.Checked = true;
            this.rdbHanSudung.Location = new System.Drawing.Point(221, 47);
            this.rdbHanSudung.Name = "rdbHanSudung";
            this.rdbHanSudung.Size = new System.Drawing.Size(90, 17);
            this.rdbHanSudung.TabIndex = 3;
            this.rdbHanSudung.TabStop = true;
            this.rdbHanSudung.Text = "Hạn Sử Dụng";
            this.rdbHanSudung.UseVisualStyleBackColor = true;
            // 
            // rdbTenHang
            // 
            this.rdbTenHang.AutoSize = true;
            this.rdbTenHang.Location = new System.Drawing.Point(119, 47);
            this.rdbTenHang.Name = "rdbTenHang";
            this.rdbTenHang.Size = new System.Drawing.Size(73, 17);
            this.rdbTenHang.TabIndex = 2;
            this.rdbTenHang.Text = "Tên Hàng";
            this.rdbTenHang.UseVisualStyleBackColor = true;
            // 
            // frmBaoCaoHanSuDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 372);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBaoCaoHanSuDung";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHienThi)).EndInit();
            this.panel2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvHienThi;
        private System.Windows.Forms.ToolStripStatusLabel btnThoat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripStatusLabel btnLocDieuKien;
        private System.Windows.Forms.Label lbtenbaocao;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel btnNapLai;
        private System.Windows.Forms.ToolStripStatusLabel btnXem;
        private System.Windows.Forms.ToolStripStatusLabel btnExcel;
        private System.Windows.Forms.ToolStripStatusLabel btnWord;
        private System.Windows.Forms.ToolStripStatusLabel btnPDF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.RadioButton rdbMaHang;
        private System.Windows.Forms.RadioButton rdbHanSudung;
        private System.Windows.Forms.RadioButton rdbTenHang;
    }
}