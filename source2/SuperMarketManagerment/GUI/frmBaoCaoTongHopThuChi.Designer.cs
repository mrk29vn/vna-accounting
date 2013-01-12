namespace GUI
{
    partial class frmBaoCaoTongHopThuChi
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
            this.dtgvngam = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbsodu = new System.Windows.Forms.GroupBox();
            this.txtducuoiky = new System.Windows.Forms.TextBox();
            this.txtdudauky = new System.Windows.Forms.TextBox();
            this.lbducuoiky = new System.Windows.Forms.Label();
            this.lbdudauky = new System.Windows.Forms.Label();
            this.grbthongtin = new System.Windows.Forms.GroupBox();
            this.lbhienthiten = new System.Windows.Forms.Label();
            this.lbhienthima = new System.Windows.Forms.Label();
            this.lbten = new System.Windows.Forms.Label();
            this.lbma = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.btnNapLai = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnXem = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExcel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnWord = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPDF = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnLoc = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnThoat = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnfill = new System.Windows.Forms.Panel();
            this.dtgvhienthi = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pntop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvngam)).BeginInit();
            this.panel1.SuspendLayout();
            this.grbsodu.SuspendLayout();
            this.grbthongtin.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnfill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvhienthi)).BeginInit();
            this.SuspendLayout();
            // 
            // pntop
            // 
            this.pntop.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pntop.Controls.Add(this.dtgvngam);
            this.pntop.Controls.Add(this.panel1);
            this.pntop.Controls.Add(this.label1);
            this.pntop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pntop.Location = new System.Drawing.Point(0, 0);
            this.pntop.Name = "pntop";
            this.pntop.Size = new System.Drawing.Size(952, 118);
            this.pntop.TabIndex = 0;
            this.pntop.DoubleClick += new System.EventHandler(this.pntop_DoubleClick);
            // 
            // dtgvngam
            // 
            this.dtgvngam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvngam.Location = new System.Drawing.Point(729, 174);
            this.dtgvngam.Name = "dtgvngam";
            this.dtgvngam.Size = new System.Drawing.Size(10, 11);
            this.dtgvngam.TabIndex = 2;
            this.dtgvngam.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grbsodu);
            this.panel1.Controls.Add(this.grbthongtin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 70);
            this.panel1.TabIndex = 1;
            this.panel1.DoubleClick += new System.EventHandler(this.pntop_DoubleClick);
            // 
            // grbsodu
            // 
            this.grbsodu.Controls.Add(this.txtducuoiky);
            this.grbsodu.Controls.Add(this.txtdudauky);
            this.grbsodu.Controls.Add(this.lbducuoiky);
            this.grbsodu.Controls.Add(this.lbdudauky);
            this.grbsodu.Dock = System.Windows.Forms.DockStyle.Right;
            this.grbsodu.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbsodu.Location = new System.Drawing.Point(760, 0);
            this.grbsodu.Name = "grbsodu";
            this.grbsodu.Size = new System.Drawing.Size(192, 70);
            this.grbsodu.TabIndex = 1;
            this.grbsodu.TabStop = false;
            // 
            // txtducuoiky
            // 
            this.txtducuoiky.BackColor = System.Drawing.Color.White;
            this.txtducuoiky.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtducuoiky.Location = new System.Drawing.Point(80, 42);
            this.txtducuoiky.Name = "txtducuoiky";
            this.txtducuoiky.ReadOnly = true;
            this.txtducuoiky.Size = new System.Drawing.Size(100, 20);
            this.txtducuoiky.TabIndex = 5;
            this.txtducuoiky.Text = "0";
            this.txtducuoiky.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtdudauky
            // 
            this.txtdudauky.BackColor = System.Drawing.Color.White;
            this.txtdudauky.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdudauky.Location = new System.Drawing.Point(80, 14);
            this.txtdudauky.Name = "txtdudauky";
            this.txtdudauky.ReadOnly = true;
            this.txtdudauky.Size = new System.Drawing.Size(100, 20);
            this.txtdudauky.TabIndex = 4;
            this.txtdudauky.Text = "0";
            this.txtdudauky.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbducuoiky
            // 
            this.lbducuoiky.AutoSize = true;
            this.lbducuoiky.Location = new System.Drawing.Point(13, 45);
            this.lbducuoiky.Name = "lbducuoiky";
            this.lbducuoiky.Size = new System.Drawing.Size(61, 14);
            this.lbducuoiky.TabIndex = 3;
            this.lbducuoiky.Text = "Dư cuối kỳ:";
            // 
            // lbdudauky
            // 
            this.lbdudauky.AutoSize = true;
            this.lbdudauky.Location = new System.Drawing.Point(15, 17);
            this.lbdudauky.Name = "lbdudauky";
            this.lbdudauky.Size = new System.Drawing.Size(58, 14);
            this.lbdudauky.TabIndex = 2;
            this.lbdudauky.Text = "Dư đầy kỳ:";
            // 
            // grbthongtin
            // 
            this.grbthongtin.Controls.Add(this.lbhienthiten);
            this.grbthongtin.Controls.Add(this.lbhienthima);
            this.grbthongtin.Controls.Add(this.lbten);
            this.grbthongtin.Controls.Add(this.lbma);
            this.grbthongtin.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbthongtin.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbthongtin.Location = new System.Drawing.Point(0, 0);
            this.grbthongtin.Name = "grbthongtin";
            this.grbthongtin.Size = new System.Drawing.Size(208, 70);
            this.grbthongtin.TabIndex = 0;
            this.grbthongtin.TabStop = false;
            this.grbthongtin.Text = "Thông tin tài khoản";
            // 
            // lbhienthiten
            // 
            this.lbhienthiten.AutoSize = true;
            this.lbhienthiten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbhienthiten.Location = new System.Drawing.Point(83, 41);
            this.lbhienthiten.Name = "lbhienthiten";
            this.lbhienthiten.Size = new System.Drawing.Size(108, 13);
            this.lbhienthiten.TabIndex = 3;
            this.lbhienthiten.Text = "Tiền mặt việt nam";
            // 
            // lbhienthima
            // 
            this.lbhienthima.AutoSize = true;
            this.lbhienthima.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbhienthima.Location = new System.Drawing.Point(83, 17);
            this.lbhienthima.Name = "lbhienthima";
            this.lbhienthima.Size = new System.Drawing.Size(35, 13);
            this.lbhienthima.TabIndex = 2;
            this.lbhienthima.Text = "1111";
            // 
            // lbten
            // 
            this.lbten.AutoSize = true;
            this.lbten.Location = new System.Drawing.Point(8, 41);
            this.lbten.Name = "lbten";
            this.lbten.Size = new System.Drawing.Size(29, 14);
            this.lbten.TabIndex = 1;
            this.lbten.Text = "Tên:";
            // 
            // lbma
            // 
            this.lbma.AutoSize = true;
            this.lbma.Location = new System.Drawing.Point(12, 17);
            this.lbma.Name = "lbma";
            this.lbma.Size = new System.Drawing.Size(25, 14);
            this.lbma.TabIndex = 0;
            this.lbma.Text = "Mã:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Báo Cáo Tổng Hợp Thu Chi";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNapLai,
            this.btnXem,
            this.btnExcel,
            this.btnWord,
            this.btnPDF,
            this.btnLoc,
            this.btnThoat});
            this.statusStrip1.Location = new System.Drawing.Point(0, 438);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(952, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // btnNapLai
            // 
            this.btnNapLai.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNapLai.Image = global::GUI.Properties.Resources.refresh;
            this.btnNapLai.Name = "btnNapLai";
            this.btnNapLai.Size = new System.Drawing.Size(129, 21);
            this.btnNapLai.Spring = true;
            this.btnNapLai.Text = "Nạp Lại";
            this.btnNapLai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNapLai.Click += new System.EventHandler(this.btnNapLai_Click);
            this.btnNapLai.MouseLeave += new System.EventHandler(this.btnNapLai_MouseLeave);
            this.btnNapLai.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNapLai_MouseMove);
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnXem.Image = global::GUI.Properties.Resources.In;
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(129, 21);
            this.btnXem.Spring = true;
            this.btnXem.Text = "Xem";
            this.btnXem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            this.btnXem.MouseLeave += new System.EventHandler(this.btnXem_MouseLeave);
            this.btnXem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnXem_MouseMove);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnExcel.Image = global::GUI.Properties.Resources.excel_icon4;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(129, 21);
            this.btnExcel.Spring = true;
            this.btnExcel.Text = "Excel";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            this.btnExcel.MouseLeave += new System.EventHandler(this.btnExcel_MouseLeave);
            this.btnExcel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcel_MouseMove);
            // 
            // btnWord
            // 
            this.btnWord.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnWord.Image = global::GUI.Properties.Resources.DocX_Viewer_icon;
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(129, 21);
            this.btnWord.Spring = true;
            this.btnWord.Text = "Word";
            this.btnWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            this.btnWord.MouseLeave += new System.EventHandler(this.btnWord_MouseLeave);
            this.btnWord.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnWord_MouseMove);
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPDF.Image = global::GUI.Properties.Resources.icon_pdf;
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(129, 21);
            this.btnPDF.Spring = true;
            this.btnPDF.Text = "PDF";
            this.btnPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            this.btnPDF.MouseLeave += new System.EventHandler(this.btnPDF_MouseLeave);
            this.btnPDF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPDF_MouseMove);
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLoc.Image = global::GUI.Properties.Resources.Loc;
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(129, 21);
            this.btnLoc.Spring = true;
            this.btnLoc.Text = "Lọc Điều Kiện";
            this.btnLoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            this.btnLoc.MouseLeave += new System.EventHandler(this.btnLoc_MouseLeave);
            this.btnLoc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnLoc_MouseMove);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnThoat.Image = global::GUI.Properties.Resources.Xoa;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(129, 21);
            this.btnThoat.Spring = true;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            this.btnThoat.MouseLeave += new System.EventHandler(this.btnThoat_MouseLeave);
            this.btnThoat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnThoat_MouseMove);
            // 
            // pnfill
            // 
            this.pnfill.Controls.Add(this.dtgvhienthi);
            this.pnfill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnfill.Location = new System.Drawing.Point(0, 118);
            this.pnfill.Name = "pnfill";
            this.pnfill.Size = new System.Drawing.Size(952, 320);
            this.pnfill.TabIndex = 2;
            // 
            // dtgvhienthi
            // 
            this.dtgvhienthi.AllowUserToAddRows = false;
            this.dtgvhienthi.AllowUserToDeleteRows = false;
            this.dtgvhienthi.BackgroundColor = System.Drawing.Color.White;
            this.dtgvhienthi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvhienthi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvhienthi.Location = new System.Drawing.Point(0, 0);
            this.dtgvhienthi.Name = "dtgvhienthi";
            this.dtgvhienthi.ReadOnly = true;
            this.dtgvhienthi.Size = new System.Drawing.Size(952, 320);
            this.dtgvhienthi.TabIndex = 0;
            //this.dtgvhienthi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvhienthi_CellDoubleClick);
            // 
            // frmBaoCaoTongHopThuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 464);
            this.Controls.Add(this.pnfill);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pntop);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmBaoCaoTongHopThuChi";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmBaoCaoTongHopThuChi_Load);
            this.pntop.ResumeLayout(false);
            this.pntop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvngam)).EndInit();
            this.panel1.ResumeLayout(false);
            this.grbsodu.ResumeLayout(false);
            this.grbsodu.PerformLayout();
            this.grbthongtin.ResumeLayout(false);
            this.grbthongtin.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnfill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvhienthi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pntop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel pnfill;
        private System.Windows.Forms.DataGridView dtgvhienthi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grbsodu;
        private System.Windows.Forms.TextBox txtducuoiky;
        private System.Windows.Forms.TextBox txtdudauky;
        private System.Windows.Forms.Label lbducuoiky;
        private System.Windows.Forms.Label lbdudauky;
        private System.Windows.Forms.GroupBox grbthongtin;
        private System.Windows.Forms.Label lbhienthiten;
        private System.Windows.Forms.Label lbhienthima;
        private System.Windows.Forms.Label lbten;
        private System.Windows.Forms.Label lbma;
        private System.Windows.Forms.DataGridView dtgvngam;
        private System.Windows.Forms.ToolStripStatusLabel btnNapLai;
        private System.Windows.Forms.ToolStripStatusLabel btnXem;
        private System.Windows.Forms.ToolStripStatusLabel btnExcel;
        private System.Windows.Forms.ToolStripStatusLabel btnWord;
        private System.Windows.Forms.ToolStripStatusLabel btnLoc;
        private System.Windows.Forms.ToolStripStatusLabel btnThoat;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel btnPDF;

    }
}