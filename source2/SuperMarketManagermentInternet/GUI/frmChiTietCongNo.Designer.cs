namespace GUI
{
    partial class frmChiTietCongNo
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
            this.tssltrove = new System.Windows.Forms.ToolStripStatusLabel();
            this.pntop = new System.Windows.Forms.Panel();
            this.dtgvngam = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbsodu = new System.Windows.Forms.GroupBox();
            this.txtdudauky = new System.Windows.Forms.TextBox();
            this.txtducuoiky = new System.Windows.Forms.TextBox();
            this.lbducuoiky = new System.Windows.Forms.Label();
            this.lbdudauky = new System.Windows.Forms.Label();
            this.grbthongtin = new System.Windows.Forms.GroupBox();
            this.lbhienthidiachi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbhienthiten = new System.Windows.Forms.Label();
            this.lbhienthima = new System.Windows.Forms.Label();
            this.lbten = new System.Windows.Forms.Label();
            this.lbma = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgvhienthi = new System.Windows.Forms.DataGridView();
            this.btnPDF = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnWord = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnXem = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExcel = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            this.pntop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvngam)).BeginInit();
            this.panel1.SuspendLayout();
            this.grbsodu.SuspendLayout();
            this.grbthongtin.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvhienthi)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnXem,
            this.btnExcel,
            this.btnWord,
            this.btnPDF,
            this.tssltrove});
            this.statusStrip1.Location = new System.Drawing.Point(0, 481);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(794, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssltrove
            // 
            this.tssltrove.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tssltrove.Image = global::GUI.Properties.Resources.Xoa;
            this.tssltrove.Name = "tssltrove";
            this.tssltrove.Size = new System.Drawing.Size(149, 21);
            this.tssltrove.Spring = true;
            this.tssltrove.Text = "Đóng";
            this.tssltrove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssltrove.Click += new System.EventHandler(this.tssltrove_Click);
            this.tssltrove.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssltrove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
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
            this.pntop.Size = new System.Drawing.Size(794, 142);
            this.pntop.TabIndex = 3;
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
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 97);
            this.panel1.TabIndex = 1;
            this.panel1.DoubleClick += new System.EventHandler(this.pntop_DoubleClick);
            // 
            // grbsodu
            // 
            this.grbsodu.Controls.Add(this.txtdudauky);
            this.grbsodu.Controls.Add(this.txtducuoiky);
            this.grbsodu.Controls.Add(this.lbducuoiky);
            this.grbsodu.Controls.Add(this.lbdudauky);
            this.grbsodu.Dock = System.Windows.Forms.DockStyle.Right;
            this.grbsodu.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbsodu.Location = new System.Drawing.Point(602, 0);
            this.grbsodu.Name = "grbsodu";
            this.grbsodu.Size = new System.Drawing.Size(192, 97);
            this.grbsodu.TabIndex = 1;
            this.grbsodu.TabStop = false;
            // 
            // txtdudauky
            // 
            this.txtdudauky.BackColor = System.Drawing.Color.White;
            this.txtdudauky.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdudauky.Location = new System.Drawing.Point(80, 26);
            this.txtdudauky.Name = "txtdudauky";
            this.txtdudauky.ReadOnly = true;
            this.txtdudauky.Size = new System.Drawing.Size(100, 20);
            this.txtdudauky.TabIndex = 6;
            this.txtdudauky.Text = "0";
            this.txtdudauky.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtducuoiky
            // 
            this.txtducuoiky.BackColor = System.Drawing.Color.White;
            this.txtducuoiky.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtducuoiky.Location = new System.Drawing.Point(80, 54);
            this.txtducuoiky.Name = "txtducuoiky";
            this.txtducuoiky.ReadOnly = true;
            this.txtducuoiky.Size = new System.Drawing.Size(100, 20);
            this.txtducuoiky.TabIndex = 5;
            this.txtducuoiky.Text = "0";
            this.txtducuoiky.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbducuoiky
            // 
            this.lbducuoiky.AutoSize = true;
            this.lbducuoiky.Location = new System.Drawing.Point(13, 57);
            this.lbducuoiky.Name = "lbducuoiky";
            this.lbducuoiky.Size = new System.Drawing.Size(61, 14);
            this.lbducuoiky.TabIndex = 3;
            this.lbducuoiky.Text = "Dư cuối kỳ:";
            // 
            // lbdudauky
            // 
            this.lbdudauky.AutoSize = true;
            this.lbdudauky.Location = new System.Drawing.Point(15, 29);
            this.lbdudauky.Name = "lbdudauky";
            this.lbdudauky.Size = new System.Drawing.Size(57, 14);
            this.lbdudauky.TabIndex = 2;
            this.lbdudauky.Text = "Dư đầu kỳ:";
            // 
            // grbthongtin
            // 
            this.grbthongtin.Controls.Add(this.lbhienthidiachi);
            this.grbthongtin.Controls.Add(this.label3);
            this.grbthongtin.Controls.Add(this.lbhienthiten);
            this.grbthongtin.Controls.Add(this.lbhienthima);
            this.grbthongtin.Controls.Add(this.lbten);
            this.grbthongtin.Controls.Add(this.lbma);
            this.grbthongtin.Dock = System.Windows.Forms.DockStyle.Left;
            this.grbthongtin.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbthongtin.Location = new System.Drawing.Point(0, 0);
            this.grbthongtin.Name = "grbthongtin";
            this.grbthongtin.Size = new System.Drawing.Size(268, 97);
            this.grbthongtin.TabIndex = 0;
            this.grbthongtin.TabStop = false;
            this.grbthongtin.Text = "Thông tin khách hàng";
            // 
            // lbhienthidiachi
            // 
            this.lbhienthidiachi.AutoSize = true;
            this.lbhienthidiachi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbhienthidiachi.Location = new System.Drawing.Point(118, 72);
            this.lbhienthidiachi.Name = "lbhienthidiachi";
            this.lbhienthidiachi.Size = new System.Drawing.Size(46, 13);
            this.lbhienthidiachi.TabIndex = 5;
            this.lbhienthidiachi.Text = "địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Địa chỉ:";
            // 
            // lbhienthiten
            // 
            this.lbhienthiten.AutoSize = true;
            this.lbhienthiten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbhienthiten.Location = new System.Drawing.Point(118, 48);
            this.lbhienthiten.Name = "lbhienthiten";
            this.lbhienthiten.Size = new System.Drawing.Size(25, 13);
            this.lbhienthiten.TabIndex = 3;
            this.lbhienthiten.Text = "tên";
            // 
            // lbhienthima
            // 
            this.lbhienthima.AutoSize = true;
            this.lbhienthima.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbhienthima.Location = new System.Drawing.Point(118, 25);
            this.lbhienthima.Name = "lbhienthima";
            this.lbhienthima.Size = new System.Drawing.Size(23, 13);
            this.lbhienthima.TabIndex = 2;
            this.lbhienthima.Text = "mã";
            // 
            // lbten
            // 
            this.lbten.AutoSize = true;
            this.lbten.Location = new System.Drawing.Point(6, 48);
            this.lbten.Name = "lbten";
            this.lbten.Size = new System.Drawing.Size(85, 14);
            this.lbten.TabIndex = 1;
            this.lbten.Text = "Tên khách hàng:";
            // 
            // lbma
            // 
            this.lbma.AutoSize = true;
            this.lbma.Location = new System.Drawing.Point(10, 25);
            this.lbma.Name = "lbma";
            this.lbma.Size = new System.Drawing.Size(81, 14);
            this.lbma.TabIndex = 0;
            this.lbma.Text = "Mã khách hàng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi Tiết Công Nợ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvhienthi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 339);
            this.panel2.TabIndex = 4;
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
            this.dtgvhienthi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvhienthi.Size = new System.Drawing.Size(794, 339);
            this.dtgvhienthi.TabIndex = 1;
            this.dtgvhienthi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvhienthi_CellDoubleClick);
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPDF.Image = global::GUI.Properties.Resources.icon_pdf;
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(149, 21);
            this.btnPDF.Spring = true;
            this.btnPDF.Text = "PDF";
            this.btnPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            this.btnPDF.MouseLeave += new System.EventHandler(this.btnPDF_MouseLeave);
            this.btnPDF.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPDF_MouseMove);
            // 
            // btnWord
            // 
            this.btnWord.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnWord.Image = global::GUI.Properties.Resources.DocX_Viewer_icon;
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(149, 21);
            this.btnWord.Spring = true;
            this.btnWord.Text = "Word";
            this.btnWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            this.btnWord.MouseLeave += new System.EventHandler(this.btnWord_MouseLeave);
            this.btnWord.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnWord_MouseMove);
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnXem.Image = global::GUI.Properties.Resources.In;
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(149, 21);
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
            this.btnExcel.Size = new System.Drawing.Size(149, 21);
            this.btnExcel.Spring = true;
            this.btnExcel.Text = "Excel";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            this.btnExcel.MouseLeave += new System.EventHandler(this.btnExcel_MouseLeave);
            this.btnExcel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnExcel_MouseMove);
            // 
            // frmChiTietCongNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 507);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pntop);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmChiTietCongNo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmChiTietCongNo_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pntop.ResumeLayout(false);
            this.pntop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvngam)).EndInit();
            this.panel1.ResumeLayout(false);
            this.grbsodu.ResumeLayout(false);
            this.grbsodu.PerformLayout();
            this.grbthongtin.ResumeLayout(false);
            this.grbthongtin.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvhienthi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssltrove;
        private System.Windows.Forms.Panel pntop;
        private System.Windows.Forms.DataGridView dtgvngam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grbsodu;
        private System.Windows.Forms.TextBox txtducuoiky;
        private System.Windows.Forms.Label lbducuoiky;
        private System.Windows.Forms.Label lbdudauky;
        private System.Windows.Forms.GroupBox grbthongtin;
        private System.Windows.Forms.Label lbhienthiten;
        private System.Windows.Forms.Label lbhienthima;
        private System.Windows.Forms.Label lbten;
        private System.Windows.Forms.Label lbma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbhienthidiachi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgvhienthi;
        private System.Windows.Forms.TextBox txtdudauky;
        private System.Windows.Forms.ToolStripStatusLabel btnXem;
        private System.Windows.Forms.ToolStripStatusLabel btnExcel;
        private System.Windows.Forms.ToolStripStatusLabel btnWord;
        private System.Windows.Forms.ToolStripStatusLabel btnPDF;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}