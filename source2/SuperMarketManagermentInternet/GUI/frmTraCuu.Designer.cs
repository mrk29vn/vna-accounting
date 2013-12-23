namespace GUI
{
    partial class frmTraCuu
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
            this.statusStrip_Duoi = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus_Chapnhan = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Huybo = new System.Windows.Forms.ToolStripStatusLabel();
            this.palTren = new System.Windows.Forms.Panel();
            this.rdbtimkiem1 = new System.Windows.Forms.RadioButton();
            this.rdbtimkiem2 = new System.Windows.Forms.RadioButton();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.palGiua = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvHieThi = new System.Windows.Forms.DataGridView();
            this.statusStrip_Duoi.SuspendLayout();
            this.palTren.SuspendLayout();
            this.palGiua.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHieThi)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip_Duoi
            // 
            this.statusStrip_Duoi.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip_Duoi.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip_Duoi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus_Chapnhan,
            this.toolStripStatus_Huybo});
            this.statusStrip_Duoi.Location = new System.Drawing.Point(0, 489);
            this.statusStrip_Duoi.Name = "statusStrip_Duoi";
            this.statusStrip_Duoi.Size = new System.Drawing.Size(398, 26);
            this.statusStrip_Duoi.TabIndex = 0;
            this.statusStrip_Duoi.Text = "statusStrip1";
            // 
            // toolStripStatus_Chapnhan
            // 
            this.toolStripStatus_Chapnhan.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripStatus_Chapnhan.Image = global::GUI.Properties.Resources.Chap_nhan;
            this.toolStripStatus_Chapnhan.Name = "toolStripStatus_Chapnhan";
            this.toolStripStatus_Chapnhan.Size = new System.Drawing.Size(191, 21);
            this.toolStripStatus_Chapnhan.Spring = true;
            this.toolStripStatus_Chapnhan.Text = "Chấp nhận";
            this.toolStripStatus_Chapnhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Chapnhan.Click += new System.EventHandler(this.toolStripStatus_Chapnhan_Click);
            this.toolStripStatus_Chapnhan.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Chapnhan.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatus_Huybo
            // 
            this.toolStripStatus_Huybo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripStatus_Huybo.Image = global::GUI.Properties.Resources.Tro_ve;
            this.toolStripStatus_Huybo.Name = "toolStripStatus_Huybo";
            this.toolStripStatus_Huybo.Size = new System.Drawing.Size(191, 21);
            this.toolStripStatus_Huybo.Spring = true;
            this.toolStripStatus_Huybo.Text = "Trở về";
            this.toolStripStatus_Huybo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Huybo.Click += new System.EventHandler(this.toolStripStatus_Huybo_Click);
            this.toolStripStatus_Huybo.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Huybo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // palTren
            // 
            this.palTren.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.palTren.Controls.Add(this.rdbtimkiem1);
            this.palTren.Controls.Add(this.rdbtimkiem2);
            this.palTren.Controls.Add(this.txttimkiem);
            this.palTren.Controls.Add(this.label1);
            this.palTren.Dock = System.Windows.Forms.DockStyle.Top;
            this.palTren.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.palTren.Location = new System.Drawing.Point(0, 0);
            this.palTren.Name = "palTren";
            this.palTren.Size = new System.Drawing.Size(398, 87);
            this.palTren.TabIndex = 8;
            // 
            // rdbtimkiem1
            // 
            this.rdbtimkiem1.AutoSize = true;
            this.rdbtimkiem1.Checked = true;
            this.rdbtimkiem1.ForeColor = System.Drawing.Color.Black;
            this.rdbtimkiem1.Location = new System.Drawing.Point(6, 50);
            this.rdbtimkiem1.Name = "rdbtimkiem1";
            this.rdbtimkiem1.Size = new System.Drawing.Size(103, 18);
            this.rdbtimkiem1.TabIndex = 2;
            this.rdbtimkiem1.TabStop = true;
            this.rdbtimkiem1.Text = "Mã nhà cung cấp";
            this.rdbtimkiem1.UseVisualStyleBackColor = true;
            this.rdbtimkiem1.Visible = false;
            // 
            // rdbtimkiem2
            // 
            this.rdbtimkiem2.AutoSize = true;
            this.rdbtimkiem2.ForeColor = System.Drawing.Color.Black;
            this.rdbtimkiem2.Location = new System.Drawing.Point(110, 50);
            this.rdbtimkiem2.Name = "rdbtimkiem2";
            this.rdbtimkiem2.Size = new System.Drawing.Size(107, 18);
            this.rdbtimkiem2.TabIndex = 4;
            this.rdbtimkiem2.Text = "Tên nhà cung cấp";
            this.rdbtimkiem2.UseVisualStyleBackColor = true;
            this.rdbtimkiem2.Visible = false;
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(221, 48);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(165, 20);
            this.txttimkiem.TabIndex = 3;
            this.txttimkiem.TabStop = false;
            this.txttimkiem.Visible = false;
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(104, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin tìm được";
            // 
            // palGiua
            // 
            this.palGiua.Controls.Add(this.groupBox1);
            this.palGiua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palGiua.Location = new System.Drawing.Point(0, 87);
            this.palGiua.Name = "palGiua";
            this.palGiua.Size = new System.Drawing.Size(398, 402);
            this.palGiua.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvHieThi);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 402);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kết quả tìm kiếm";
            // 
            // dgvHieThi
            // 
            this.dgvHieThi.AllowUserToAddRows = false;
            this.dgvHieThi.AllowUserToDeleteRows = false;
            this.dgvHieThi.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvHieThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHieThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHieThi.Location = new System.Drawing.Point(3, 16);
            this.dgvHieThi.Name = "dgvHieThi";
            this.dgvHieThi.ReadOnly = true;
            this.dgvHieThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHieThi.Size = new System.Drawing.Size(392, 383);
            this.dgvHieThi.TabIndex = 0;
            this.dgvHieThi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHieThi_CellClick);
            this.dgvHieThi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHieThi_CellDoubleClick);
            this.dgvHieThi.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHieThi_RowEnter);
            this.dgvHieThi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvHieThi_KeyDown);
            // 
            // frmTraCuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 515);
            this.Controls.Add(this.palGiua);
            this.Controls.Add(this.palTren);
            this.Controls.Add(this.statusStrip_Duoi);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmTraCuu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tra cứu";
            this.Load += new System.EventHandler(this.frmTraCuu_Load);
            this.statusStrip_Duoi.ResumeLayout(false);
            this.statusStrip_Duoi.PerformLayout();
            this.palTren.ResumeLayout(false);
            this.palTren.PerformLayout();
            this.palGiua.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHieThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip_Duoi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Chapnhan;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Huybo;
        private System.Windows.Forms.Panel palTren;
        private System.Windows.Forms.Panel palGiua;
        private System.Windows.Forms.DataGridView dgvHieThi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbtimkiem1;
        private System.Windows.Forms.RadioButton rdbtimkiem2;
        private System.Windows.Forms.TextBox txttimkiem;
    }
}