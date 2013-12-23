namespace GUI
{
    partial class frmTimNhomHang
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.tsslhuybo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslchapnhan = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbtenbaocao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHienThi)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvHienThi
            // 
            this.dtgvHienThi.BackgroundColor = System.Drawing.Color.White;
            this.dtgvHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHienThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvHienThi.Location = new System.Drawing.Point(0, 0);
            this.dtgvHienThi.Name = "dtgvHienThi";
            this.dtgvHienThi.Size = new System.Drawing.Size(448, 407);
            this.dtgvHienThi.TabIndex = 0;
            this.dtgvHienThi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvHienThi_CellClick);
            this.dtgvHienThi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvHienThi_CellDoubleClick);
            this.dtgvHienThi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgvHienThi_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvHienThi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 407);
            this.panel2.TabIndex = 20;
            // 
            // tsslhuybo
            // 
            this.tsslhuybo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsslhuybo.Image = global::GUI.Properties.Resources.Tro_ve;
            this.tsslhuybo.Name = "tsslhuybo";
            this.tsslhuybo.Size = new System.Drawing.Size(201, 21);
            this.tsslhuybo.Spring = true;
            this.tsslhuybo.Text = "&Hủy bỏ";
            this.tsslhuybo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslhuybo.Click += new System.EventHandler(this.tsslhuybo_Click);
            this.tsslhuybo.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslhuybo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslchapnhan
            // 
            this.tsslchapnhan.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsslchapnhan.Image = global::GUI.Properties.Resources.Chap_nhan;
            this.tsslchapnhan.Name = "tsslchapnhan";
            this.tsslchapnhan.Size = new System.Drawing.Size(201, 21);
            this.tsslchapnhan.Spring = true;
            this.tsslchapnhan.Text = "&Chấp nhận";
            this.tsslchapnhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslchapnhan.Click += new System.EventHandler(this.tsslchapnhan_Click);
            this.tsslchapnhan.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslchapnhan.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslchapnhan,
            this.tsslhuybo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 472);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(448, 26);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.lbtenbaocao);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 65);
            this.panel1.TabIndex = 18;
            // 
            // lbtenbaocao
            // 
            this.lbtenbaocao.AutoSize = true;
            this.lbtenbaocao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtenbaocao.ForeColor = System.Drawing.Color.White;
            this.lbtenbaocao.Location = new System.Drawing.Point(12, 9);
            this.lbtenbaocao.Name = "lbtenbaocao";
            this.lbtenbaocao.Size = new System.Drawing.Size(103, 20);
            this.lbtenbaocao.TabIndex = 1;
            this.lbtenbaocao.Text = "Nhóm Hàng";
            // 
            // frmTimNhomHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 498);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTimNhomHang";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm Nhóm Hàng";
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslhuybo;
        private System.Windows.Forms.ToolStripStatusLabel tsslchapnhan;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbtenbaocao;
    }
}