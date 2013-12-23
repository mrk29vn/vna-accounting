namespace GUI
{
    partial class frmQuanLyPhieuChi
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
            this.tssldong = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgvChitien = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslnaplai = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslthem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslsua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslxoa = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslin = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.rdbtimkiem3 = new System.Windows.Forms.RadioButton();
            this.rdbtimkiem2 = new System.Windows.Forms.RadioButton();
            this.lbchitien = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChitien)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tssldong
            // 
            this.tssldong.BackColor = System.Drawing.SystemColors.Control;
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
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 304);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgvChitien);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(594, 278);
            this.panel3.TabIndex = 2;
            // 
            // dtgvChitien
            // 
            this.dtgvChitien.BackgroundColor = System.Drawing.Color.White;
            this.dtgvChitien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvChitien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvChitien.Location = new System.Drawing.Point(0, 0);
            this.dtgvChitien.Name = "dtgvChitien";
            this.dtgvChitien.Size = new System.Drawing.Size(594, 278);
            this.dtgvChitien.TabIndex = 0;
            this.dtgvChitien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvChitien_CellClick);
            this.dtgvChitien.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvChitien_CellDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslnaplai,
            this.tsslthem,
            this.tsslsua,
            this.tsslxoa,
            this.tsslin,
            this.tssldong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 278);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(594, 26);
            this.statusStrip1.TabIndex = 1;
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
            // tsslthem
            // 
            this.tsslthem.BackColor = System.Drawing.SystemColors.Control;
            this.tsslthem.Image = global::GUI.Properties.Resources.Them;
            this.tsslthem.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.tsslthem.Name = "tsslthem";
            this.tsslthem.Size = new System.Drawing.Size(91, 21);
            this.tsslthem.Spring = true;
            this.tsslthem.Text = "&Thêm";
            this.tsslthem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslthem.Click += new System.EventHandler(this.tsslthemmoi_Click);
            this.tsslthem.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslthem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslsua
            // 
            this.tsslsua.BackColor = System.Drawing.SystemColors.Control;
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
            this.tsslxoa.BackColor = System.Drawing.SystemColors.Control;
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
            this.tsslin.BackColor = System.Drawing.SystemColors.Control;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lbchitien);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 97);
            this.panel1.TabIndex = 4;
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
            // lbchitien
            // 
            this.lbchitien.AutoSize = true;
            this.lbchitien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbchitien.ForeColor = System.Drawing.SystemColors.Info;
            this.lbchitien.Location = new System.Drawing.Point(12, 5);
            this.lbchitien.Name = "lbchitien";
            this.lbchitien.Size = new System.Drawing.Size(123, 19);
            this.lbchitien.TabIndex = 0;
            this.lbchitien.Text = "Quản Lý Chi tiền";
            // 
            // frmQuanLyPhieuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 401);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmQuanLyPhieuChi";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChitien_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChitien)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel tssldong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslthem;
        private System.Windows.Forms.ToolStripStatusLabel tsslsua;
        private System.Windows.Forms.ToolStripStatusLabel tsslxoa;
        private System.Windows.Forms.ToolStripStatusLabel tsslin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbchitien;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgvChitien;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.RadioButton rdbtimkiem3;
        private System.Windows.Forms.RadioButton rdbtimkiem2;
        private System.Windows.Forms.ToolStripStatusLabel tsslnaplai;
    }
}