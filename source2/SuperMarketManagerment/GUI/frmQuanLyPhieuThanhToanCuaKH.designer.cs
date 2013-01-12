namespace GUI
{
    partial class frmQuanLyPhieuThanhToanCuaKH
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.rdbtimkiem3 = new System.Windows.Forms.RadioButton();
            this.rdbtimkiem2 = new System.Windows.Forms.RadioButton();
            this.lbThanhtoanvoiKH = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslnaplai = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslthemmoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslsua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslxoa = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslin = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssldong = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgvThanhtoanKH = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThanhtoanKH)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lbThanhtoanvoiKH);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 97);
            this.panel1.TabIndex = 0;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txttimkiem);
            this.groupBox1.Controls.Add(this.rdbtimkiem3);
            this.groupBox1.Controls.Add(this.rdbtimkiem2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(0, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 54);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(163, 26);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(425, 20);
            this.txttimkiem.TabIndex = 3;
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            // 
            // rdbtimkiem3
            // 
            this.rdbtimkiem3.AutoSize = true;
            this.rdbtimkiem3.Checked = true;
            this.rdbtimkiem3.Location = new System.Drawing.Point(101, 29);
            this.rdbtimkiem3.Name = "rdbtimkiem3";
            this.rdbtimkiem3.Size = new System.Drawing.Size(56, 17);
            this.rdbtimkiem3.TabIndex = 2;
            this.rdbtimkiem3.TabStop = true;
            this.rdbtimkiem3.Text = "Tất cả";
            this.rdbtimkiem3.UseVisualStyleBackColor = true;
            this.rdbtimkiem3.CheckedChanged += new System.EventHandler(this.rdbtimkiem3_CheckedChanged);
            // 
            // rdbtimkiem2
            // 
            this.rdbtimkiem2.AutoSize = true;
            this.rdbtimkiem2.Location = new System.Drawing.Point(12, 29);
            this.rdbtimkiem2.Name = "rdbtimkiem2";
            this.rdbtimkiem2.Size = new System.Drawing.Size(83, 17);
            this.rdbtimkiem2.TabIndex = 1;
            this.rdbtimkiem2.TabStop = true;
            this.rdbtimkiem2.Text = "Mã hóa đơn";
            this.rdbtimkiem2.UseVisualStyleBackColor = true;
            this.rdbtimkiem2.CheckedChanged += new System.EventHandler(this.rdbtimkiem2_CheckedChanged);
            // 
            // lbThanhtoanvoiKH
            // 
            this.lbThanhtoanvoiKH.AutoSize = true;
            this.lbThanhtoanvoiKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThanhtoanvoiKH.ForeColor = System.Drawing.SystemColors.Info;
            this.lbThanhtoanvoiKH.Location = new System.Drawing.Point(12, 3);
            this.lbThanhtoanvoiKH.Name = "lbThanhtoanvoiKH";
            this.lbThanhtoanvoiKH.Size = new System.Drawing.Size(222, 18);
            this.lbThanhtoanvoiKH.TabIndex = 0;
            this.lbThanhtoanvoiKH.Text = "Thanh Toán Với Khách Hàng";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslnaplai,
            this.tsslthemmoi,
            this.tsslsua,
            this.tsslxoa,
            this.tsslin,
            this.tssldong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 375);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(594, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslnaplai
            // 
            this.tsslnaplai.Image = global::GUI.Properties.Resources.refresh;
            this.tsslnaplai.Name = "tsslnaplai";
            this.tsslnaplai.Size = new System.Drawing.Size(91, 21);
            this.tsslnaplai.Spring = true;
            this.tsslnaplai.Text = "Nạp lại";
            this.tsslnaplai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslnaplai.Click += new System.EventHandler(this.tsslnaplai_Click);
            this.tsslnaplai.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslnaplai.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslthemmoi
            // 
            this.tsslthemmoi.Image = global::GUI.Properties.Resources.Them;
            this.tsslthemmoi.Name = "tsslthemmoi";
            this.tsslthemmoi.Size = new System.Drawing.Size(91, 21);
            this.tsslthemmoi.Spring = true;
            this.tsslthemmoi.Text = "&Thêm";
            this.tsslthemmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslthemmoi.Click += new System.EventHandler(this.tsslthemmoi_Click);
            this.tsslthemmoi.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslthemmoi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslsua
            // 
            this.tsslsua.Image = global::GUI.Properties.Resources.Sua;
            this.tsslsua.Name = "tsslsua";
            this.tsslsua.Size = new System.Drawing.Size(91, 21);
            this.tsslsua.Spring = true;
            this.tsslsua.Text = "&Sửa";
            this.tsslsua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslsua.Visible = false;
            this.tsslsua.Click += new System.EventHandler(this.tsslsua_Click);
            this.tsslsua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslsua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslxoa
            // 
            this.tsslxoa.Image = global::GUI.Properties.Resources.Dele;
            this.tsslxoa.Name = "tsslxoa";
            this.tsslxoa.Size = new System.Drawing.Size(91, 21);
            this.tsslxoa.Spring = true;
            this.tsslxoa.Text = "&Xóa";
            this.tsslxoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslxoa.Visible = false;
            this.tsslxoa.Click += new System.EventHandler(this.tsslxoa_Click);
            this.tsslxoa.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslxoa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslin
            // 
            this.tsslin.Image = global::GUI.Properties.Resources.In;
            this.tsslin.Name = "tsslin";
            this.tsslin.Size = new System.Drawing.Size(91, 21);
            this.tsslin.Spring = true;
            this.tsslin.Text = "&In";
            this.tsslin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslin.Visible = false;
            this.tsslin.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssldong
            // 
            this.tssldong.Image = global::GUI.Properties.Resources.Xoa;
            this.tssldong.Name = "tssldong";
            this.tssldong.Size = new System.Drawing.Size(91, 21);
            this.tssldong.Spring = true;
            this.tssldong.Text = "Đó&ng";
            this.tssldong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssldong.Click += new System.EventHandler(this.tssldong_Click);
            this.tssldong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssldong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvThanhtoanKH);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 278);
            this.panel2.TabIndex = 3;
            // 
            // dtgvThanhtoanKH
            // 
            this.dtgvThanhtoanKH.BackgroundColor = System.Drawing.Color.White;
            this.dtgvThanhtoanKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThanhtoanKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvThanhtoanKH.Location = new System.Drawing.Point(0, 0);
            this.dtgvThanhtoanKH.Name = "dtgvThanhtoanKH";
            this.dtgvThanhtoanKH.Size = new System.Drawing.Size(594, 278);
            this.dtgvThanhtoanKH.TabIndex = 0;
            this.dtgvThanhtoanKH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvThanhtoanKH_CellClick);
            this.dtgvThanhtoanKH.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvThanhtoanKH_CellDoubleClick);
            // 
            // frmQuanLyPhieuThanhToanCuaKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 401);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmQuanLyPhieuThanhToanCuaKH";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThanhToanVoiKH_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThanhtoanKH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbThanhtoanvoiKH;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslthemmoi;
        private System.Windows.Forms.ToolStripStatusLabel tsslsua;
        private System.Windows.Forms.ToolStripStatusLabel tsslxoa;
        private System.Windows.Forms.ToolStripStatusLabel tsslin;
        private System.Windows.Forms.ToolStripStatusLabel tssldong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgvThanhtoanKH;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbtimkiem3;
        private System.Windows.Forms.RadioButton rdbtimkiem2;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.ToolStripStatusLabel tsslnaplai;
    }
}

