namespace GUI
{
    partial class frmTimKiemHangHoaGoiHang
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
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.rdoTen = new System.Windows.Forms.RadioButton();
            this.rdoMa = new System.Windows.Forms.RadioButton();
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
            this.statusStrip_Duoi.Location = new System.Drawing.Point(0, 473);
            this.statusStrip_Duoi.Name = "statusStrip_Duoi";
            this.statusStrip_Duoi.Size = new System.Drawing.Size(382, 26);
            this.statusStrip_Duoi.TabIndex = 0;
            this.statusStrip_Duoi.Text = "statusStrip1";
            // 
            // toolStripStatus_Chapnhan
            // 
            this.toolStripStatus_Chapnhan.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripStatus_Chapnhan.Image = global::GUI.Properties.Resources.Chap_nhan;
            this.toolStripStatus_Chapnhan.Name = "toolStripStatus_Chapnhan";
            this.toolStripStatus_Chapnhan.Size = new System.Drawing.Size(183, 21);
            this.toolStripStatus_Chapnhan.Spring = true;
            this.toolStripStatus_Chapnhan.Text = "Chấp nhận";
            this.toolStripStatus_Chapnhan.Click += new System.EventHandler(this.toolStripStatus_Chapnhan_Click);
            // 
            // toolStripStatus_Huybo
            // 
            this.toolStripStatus_Huybo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripStatus_Huybo.Image = global::GUI.Properties.Resources.Tro_ve;
            this.toolStripStatus_Huybo.Name = "toolStripStatus_Huybo";
            this.toolStripStatus_Huybo.Size = new System.Drawing.Size(183, 21);
            this.toolStripStatus_Huybo.Spring = true;
            this.toolStripStatus_Huybo.Text = "Trở về";
            this.toolStripStatus_Huybo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Huybo.Click += new System.EventHandler(this.toolStripStatus_Huybo_Click);
            // 
            // palTren
            // 
            this.palTren.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.palTren.Controls.Add(this.txtTimKiem);
            this.palTren.Controls.Add(this.rdoTen);
            this.palTren.Controls.Add(this.rdoMa);
            this.palTren.Controls.Add(this.label1);
            this.palTren.Dock = System.Windows.Forms.DockStyle.Top;
            this.palTren.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.palTren.Location = new System.Drawing.Point(0, 0);
            this.palTren.Name = "palTren";
            this.palTren.Size = new System.Drawing.Size(382, 91);
            this.palTren.TabIndex = 8;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(109, 57);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(267, 20);
            this.txtTimKiem.TabIndex = 3;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimkiem_TextChanged);
            // 
            // rdoTen
            // 
            this.rdoTen.AutoSize = true;
            this.rdoTen.BackColor = System.Drawing.Color.Transparent;
            this.rdoTen.ForeColor = System.Drawing.Color.Black;
            this.rdoTen.Location = new System.Drawing.Point(58, 57);
            this.rdoTen.Name = "rdoTen";
            this.rdoTen.Size = new System.Drawing.Size(44, 18);
            this.rdoTen.TabIndex = 2;
            this.rdoTen.TabStop = true;
            this.rdoTen.Text = "Tên";
            this.rdoTen.UseVisualStyleBackColor = false;
            this.rdoTen.CheckedChanged += new System.EventHandler(this.rdbNgay_CheckedChanged);
            // 
            // rdoMa
            // 
            this.rdoMa.AutoSize = true;
            this.rdoMa.BackColor = System.Drawing.Color.Transparent;
            this.rdoMa.ForeColor = System.Drawing.Color.Black;
            this.rdoMa.Location = new System.Drawing.Point(12, 57);
            this.rdoMa.Name = "rdoMa";
            this.rdoMa.Size = new System.Drawing.Size(40, 18);
            this.rdoMa.TabIndex = 2;
            this.rdoMa.TabStop = true;
            this.rdoMa.Text = "Mã";
            this.rdoMa.UseVisualStyleBackColor = false;
            this.rdoMa.CheckedChanged += new System.EventHandler(this.rdbMa_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(123, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin tìm được";
            // 
            // palGiua
            // 
            this.palGiua.Controls.Add(this.groupBox1);
            this.palGiua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palGiua.Location = new System.Drawing.Point(0, 91);
            this.palGiua.Name = "palGiua";
            this.palGiua.Size = new System.Drawing.Size(382, 382);
            this.palGiua.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvHieThi);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 382);
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
            this.dgvHieThi.RowHeadersVisible = false;
            this.dgvHieThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHieThi.Size = new System.Drawing.Size(376, 363);
            this.dgvHieThi.TabIndex = 1;
            this.dgvHieThi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHieThi_CellClick);
            this.dgvHieThi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHieThi_CellDoubleClick);
            this.dgvHieThi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvHieThi_KeyDown);
            // 
            // frmTimKiemHangHoaGoiHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 499);
            this.ControlBox = false;
            this.Controls.Add(this.palGiua);
            this.Controls.Add(this.palTren);
            this.Controls.Add(this.statusStrip_Duoi);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmTimKiemHangHoaGoiHang";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tra cứu";
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
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.RadioButton rdoTen;
        private System.Windows.Forms.RadioButton rdoMa;
    }
}