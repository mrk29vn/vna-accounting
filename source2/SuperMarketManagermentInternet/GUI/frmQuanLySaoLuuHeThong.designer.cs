namespace GUI
{
    partial class frmQuanLySaoLuuHeThong
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
            this.toolStripStatus_ThemMoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Dong = new System.Windows.Forms.ToolStripStatusLabel();
            this.palTencung = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.rdoTatca = new System.Windows.Forms.RadioButton();
            this.rdbNgay = new System.Windows.Forms.RadioButton();
            this.lblDatmua = new System.Windows.Forms.Label();
            this.dgvHienThi = new System.Windows.Forms.DataGridView();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.palTencung.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatus_ThemMoi,
            this.toolStripStatusLabel5,
            this.toolStripStatus_Dong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 434);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(556, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatus_ThemMoi
            // 
            this.toolStripStatus_ThemMoi.Image = global::GUI.Properties.Resources.Luu;
            this.toolStripStatus_ThemMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_ThemMoi.Name = "toolStripStatus_ThemMoi";
            this.toolStripStatus_ThemMoi.Size = new System.Drawing.Size(170, 21);
            this.toolStripStatus_ThemMoi.Spring = true;
            this.toolStripStatus_ThemMoi.Text = "Phục Hồi";
            this.toolStripStatus_ThemMoi.Click += new System.EventHandler(this.toolStripStatus_ThemMoi_Click);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 21);
            // 
            // toolStripStatus_Dong
            // 
            this.toolStripStatus_Dong.Image = global::GUI.Properties.Resources.Xoa;
            this.toolStripStatus_Dong.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Dong.Name = "toolStripStatus_Dong";
            this.toolStripStatus_Dong.Size = new System.Drawing.Size(170, 21);
            this.toolStripStatus_Dong.Spring = true;
            this.toolStripStatus_Dong.Text = "Đóng";
            this.toolStripStatus_Dong.Click += new System.EventHandler(this.toolStripStatus_Dong_Click);
            // 
            // palTencung
            // 
            this.palTencung.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.palTencung.Controls.Add(this.groupBox1);
            this.palTencung.Controls.Add(this.lblDatmua);
            this.palTencung.Dock = System.Windows.Forms.DockStyle.Top;
            this.palTencung.Location = new System.Drawing.Point(0, 0);
            this.palTencung.Name = "palTencung";
            this.palTencung.Size = new System.Drawing.Size(556, 96);
            this.palTencung.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTimkiem);
            this.groupBox1.Controls.Add(this.rdoTatca);
            this.groupBox1.Controls.Add(this.rdbNgay);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 58);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimkiem.Location = new System.Drawing.Point(165, 22);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(210, 20);
            this.txtTimkiem.TabIndex = 27;
            this.txtTimkiem.TextChanged += new System.EventHandler(this.txtTimkiem_TextChanged);
            // 
            // rdoTatca
            // 
            this.rdoTatca.AutoSize = true;
            this.rdoTatca.Checked = true;
            this.rdoTatca.ForeColor = System.Drawing.Color.Black;
            this.rdoTatca.Location = new System.Drawing.Point(105, 22);
            this.rdoTatca.Name = "rdoTatca";
            this.rdoTatca.Size = new System.Drawing.Size(56, 17);
            this.rdoTatca.TabIndex = 31;
            this.rdoTatca.TabStop = true;
            this.rdoTatca.Text = "Tất cả";
            this.rdoTatca.UseVisualStyleBackColor = true;
            this.rdoTatca.CheckedChanged += new System.EventHandler(this.rdoTatca_CheckedChanged);
            // 
            // rdbNgay
            // 
            this.rdbNgay.AutoSize = true;
            this.rdbNgay.ForeColor = System.Drawing.Color.Black;
            this.rdbNgay.Location = new System.Drawing.Point(15, 22);
            this.rdbNgay.Name = "rdbNgay";
            this.rdbNgay.Size = new System.Drawing.Size(92, 17);
            this.rdbNgay.TabIndex = 30;
            this.rdbNgay.Text = "Tìm theo ngày";
            this.rdbNgay.UseVisualStyleBackColor = true;
            // 
            // lblDatmua
            // 
            this.lblDatmua.AutoSize = true;
            this.lblDatmua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatmua.ForeColor = System.Drawing.Color.White;
            this.lblDatmua.Location = new System.Drawing.Point(3, 4);
            this.lblDatmua.Name = "lblDatmua";
            this.lblDatmua.Size = new System.Drawing.Size(136, 19);
            this.lblDatmua.TabIndex = 0;
            this.lblDatmua.Text = "Sao Lưu Hệ Thống";
            // 
            // dgvHienThi
            // 
            this.dgvHienThi.AllowUserToAddRows = false;
            this.dgvHienThi.AllowUserToDeleteRows = false;
            this.dgvHienThi.AllowUserToResizeRows = false;
            this.dgvHienThi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHienThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHienThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHienThi.Location = new System.Drawing.Point(0, 96);
            this.dgvHienThi.MultiSelect = false;
            this.dgvHienThi.Name = "dgvHienThi";
            this.dgvHienThi.ReadOnly = true;
            this.dgvHienThi.RowHeadersVisible = false;
            this.dgvHienThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHienThi.Size = new System.Drawing.Size(556, 338);
            this.dgvHienThi.TabIndex = 4;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Image = global::GUI.Properties.Resources.Cap_nhat_gia;
            this.toolStripStatusLabel2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(170, 21);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "Sao Lưu";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // frmQuanLySaoLuuHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(556, 460);
            this.Controls.Add(this.dgvHienThi);
            this.Controls.Add(this.palTencung);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuanLySaoLuuHeThong";
            this.ShowIcon = false;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmQuanLySaoLuuHeThong_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.palTencung.ResumeLayout(false);
            this.palTencung.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_ThemMoi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Dong;
        private System.Windows.Forms.Panel palTencung;
        private System.Windows.Forms.Label lblDatmua;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.RadioButton rdoTatca;
        private System.Windows.Forms.RadioButton rdbNgay;
        private System.Windows.Forms.DataGridView dgvHienThi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}