namespace GUI
{
    partial class frmTraCuuHDNhap
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
            this.tsslChon = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslBoChon = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslThoat = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvHienThi = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslChon,
            this.tsslBoChon,
            this.tsslThoat});
            this.statusStrip1.Location = new System.Drawing.Point(0, 435);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(393, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslChon
            // 
            this.tsslChon.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsslChon.Image = global::GUI.Properties.Resources.Chap_nhan;
            this.tsslChon.Name = "tsslChon";
            this.tsslChon.Size = new System.Drawing.Size(126, 21);
            this.tsslChon.Spring = true;
            this.tsslChon.Text = "Chọn";
            this.tsslChon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslChon.Click += new System.EventHandler(this.tsslChon_Click);
            // 
            // tsslBoChon
            // 
            this.tsslBoChon.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsslBoChon.Image = global::GUI.Properties.Resources.Cong_cu_quan_ly__1_;
            this.tsslBoChon.Name = "tsslBoChon";
            this.tsslBoChon.Size = new System.Drawing.Size(126, 21);
            this.tsslBoChon.Spring = true;
            this.tsslBoChon.Text = "Bỏ chọn";
            this.tsslBoChon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslBoChon.Click += new System.EventHandler(this.tsslBoChon_Click);
            // 
            // tsslThoat
            // 
            this.tsslThoat.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsslThoat.Image = global::GUI.Properties.Resources.Tro_ve;
            this.tsslThoat.Name = "tsslThoat";
            this.tsslThoat.Size = new System.Drawing.Size(126, 21);
            this.tsslThoat.Spring = true;
            this.tsslThoat.Text = "Thoát";
            this.tsslThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslThoat.Click += new System.EventHandler(this.tsslThoat_Click);
            // 
            // dgvHienThi
            // 
            this.dgvHienThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHienThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHienThi.Location = new System.Drawing.Point(0, 0);
            this.dgvHienThi.Name = "dgvHienThi";
            this.dgvHienThi.Size = new System.Drawing.Size(393, 435);
            this.dgvHienThi.TabIndex = 1;
            this.dgvHienThi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHienThi_CellDoubleClick);
            // 
            // frmTraCuuHDNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 461);
            this.Controls.Add(this.dgvHienThi);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTraCuuHDNhap";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.Text = " ";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslChon;
        private System.Windows.Forms.ToolStripStatusLabel tsslThoat;
        private System.Windows.Forms.DataGridView dgvHienThi;
        private System.Windows.Forms.ToolStripStatusLabel tsslBoChon;
    }
}