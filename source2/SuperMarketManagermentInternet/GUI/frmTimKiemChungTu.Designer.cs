namespace GUI
{
    partial class frmTimKiemChungTu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimKiemChungTu));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslchitiet = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslexcel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslWord = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslPdf = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnloaiphieu = new System.Windows.Forms.Button();
            this.txtloaiphieu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnmathang = new System.Windows.Forms.Button();
            this.txtmathang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnnhomhang = new System.Windows.Forms.Button();
            this.txtnhomhang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtmachungtu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgvChiTiet = new System.Windows.Forms.DataGridView();
            this.dtgvHienThi = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHienThi)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.tsslchitiet,
            this.tsslexcel,
            this.tsslWord,
            this.tsslPdf,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripStatusLabel3.Image = global::GUI.Properties.Resources.refresh;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            resources.ApplyResources(this.toolStripStatusLabel3, "toolStripStatusLabel3");
            this.toolStripStatusLabel3.Spring = true;
            this.toolStripStatusLabel3.Click += new System.EventHandler(this.toolStripStatusLabel3_Click);
            this.toolStripStatusLabel3.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslchitiet
            // 
            this.tsslchitiet.BackColor = System.Drawing.Color.LightSteelBlue;
            resources.ApplyResources(this.tsslchitiet, "tsslchitiet");
            this.tsslchitiet.Image = global::GUI.Properties.Resources.In;
            this.tsslchitiet.Name = "tsslchitiet";
            this.tsslchitiet.Spring = true;
            this.tsslchitiet.Click += new System.EventHandler(this.tsslchitiet_Click);
            this.tsslchitiet.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslchitiet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslexcel
            // 
            this.tsslexcel.Name = "tsslexcel";
            resources.ApplyResources(this.tsslexcel, "tsslexcel");
            // 
            // tsslWord
            // 
            this.tsslWord.Name = "tsslWord";
            resources.ApplyResources(this.tsslWord, "tsslWord");
            // 
            // tsslPdf
            // 
            this.tsslPdf.BackColor = System.Drawing.Color.LightSteelBlue;
            resources.ApplyResources(this.tsslPdf, "tsslPdf");
            this.tsslPdf.Image = global::GUI.Properties.Resources.icon_pdf;
            this.tsslPdf.Name = "tsslPdf";
            this.tsslPdf.Spring = true;
            this.tsslPdf.Click += new System.EventHandler(this.tsslPdf_Click);
            this.tsslPdf.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslPdf.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripStatusLabel2.Image = global::GUI.Properties.Resources.Loc;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            resources.ApplyResources(this.toolStripStatusLabel2, "toolStripStatusLabel2");
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            this.toolStripStatusLabel2.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripStatusLabel1.Image = global::GUI.Properties.Resources.Xoa;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Tag = "4";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            this.toolStripStatusLabel1.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Name = "label1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnTimKiem);
            this.panel2.Controls.Add(this.txtGhiChu);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnloaiphieu);
            this.panel2.Controls.Add(this.txtloaiphieu);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnmathang);
            this.panel2.Controls.Add(this.txtmathang);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnnhomhang);
            this.panel2.Controls.Add(this.txtnhomhang);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtmachungtu);
            this.panel2.Controls.Add(this.label2);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // btnTimKiem
            // 
            resources.ApplyResources(this.btnTimKiem, "btnTimKiem");
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtGhiChu, "txtGhiChu");
            this.txtGhiChu.Name = "txtGhiChu";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // btnloaiphieu
            // 
            this.btnloaiphieu.Image = global::GUI.Properties.Resources.button_search;
            resources.ApplyResources(this.btnloaiphieu, "btnloaiphieu");
            this.btnloaiphieu.Name = "btnloaiphieu";
            this.btnloaiphieu.UseVisualStyleBackColor = true;
            this.btnloaiphieu.Click += new System.EventHandler(this.btnloaiphieu_Click);
            // 
            // txtloaiphieu
            // 
            this.txtloaiphieu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtloaiphieu, "txtloaiphieu");
            this.txtloaiphieu.Name = "txtloaiphieu";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // btnmathang
            // 
            this.btnmathang.Image = global::GUI.Properties.Resources.button_search;
            resources.ApplyResources(this.btnmathang, "btnmathang");
            this.btnmathang.Name = "btnmathang";
            this.btnmathang.UseVisualStyleBackColor = true;
            this.btnmathang.Click += new System.EventHandler(this.btnmathang_Click);
            // 
            // txtmathang
            // 
            this.txtmathang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtmathang, "txtmathang");
            this.txtmathang.Name = "txtmathang";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // btnnhomhang
            // 
            this.btnnhomhang.Image = global::GUI.Properties.Resources.button_search;
            resources.ApplyResources(this.btnnhomhang, "btnnhomhang");
            this.btnnhomhang.Name = "btnnhomhang";
            this.btnnhomhang.UseVisualStyleBackColor = true;
            this.btnnhomhang.Click += new System.EventHandler(this.btnnhomhang_Click);
            // 
            // txtnhomhang
            // 
            this.txtnhomhang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtnhomhang, "txtnhomhang");
            this.txtnhomhang.Name = "txtnhomhang";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtmachungtu
            // 
            this.txtmachungtu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtmachungtu, "txtmachungtu");
            this.txtmachungtu.Name = "txtmachungtu";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgvChiTiet);
            this.panel3.Controls.Add(this.dtgvHienThi);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // dtgvChiTiet
            // 
            this.dtgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dtgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dtgvChiTiet, "dtgvChiTiet");
            this.dtgvChiTiet.Name = "dtgvChiTiet";
            // 
            // dtgvHienThi
            // 
            this.dtgvHienThi.BackgroundColor = System.Drawing.Color.White;
            this.dtgvHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dtgvHienThi, "dtgvHienThi");
            this.dtgvHienThi.Name = "dtgvHienThi";
            this.dtgvHienThi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvHienThi_CellClick);
            this.dtgvHienThi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dtgvHienThi_KeyUp);
            // 
            // frmTimKiemChungTu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTimKiemChungTu";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.frmTimKiemChungTu_Load);
            this.Resize += new System.EventHandler(this.frmTimKiemChungTu_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHienThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgvChiTiet;
        private System.Windows.Forms.DataGridView dtgvHienThi;
        private System.Windows.Forms.ToolStripStatusLabel tsslchitiet;
        private System.Windows.Forms.ToolStripStatusLabel tsslexcel;
        private System.Windows.Forms.ToolStripStatusLabel tsslWord;
        private System.Windows.Forms.ToolStripStatusLabel tsslPdf;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button btnloaiphieu;
        private System.Windows.Forms.TextBox txtloaiphieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnmathang;
        private System.Windows.Forms.TextBox txtmathang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnnhomhang;
        private System.Windows.Forms.TextBox txtnhomhang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtmachungtu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
    }
}