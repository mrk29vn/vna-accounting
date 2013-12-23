namespace GUI
{
    partial class frmQuanlynhapmua
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
            this.palTencung = new System.Windows.Forms.Panel();
            this.lblThoigian = new System.Windows.Forms.Label();
            this.lblDatmua = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus_ThemMoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Sua = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Xoa = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Loc = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_In = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Dong = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvHienThi = new System.Windows.Forms.DataGridView();
            this.palTencung.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).BeginInit();
            this.SuspendLayout();
            // 
            // palTencung
            // 
            this.palTencung.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.palTencung.Controls.Add(this.lblThoigian);
            this.palTencung.Controls.Add(this.lblDatmua);
            this.palTencung.Dock = System.Windows.Forms.DockStyle.Top;
            this.palTencung.Location = new System.Drawing.Point(0, 0);
            this.palTencung.Name = "palTencung";
            this.palTencung.Size = new System.Drawing.Size(1058, 47);
            this.palTencung.TabIndex = 0;
            // 
            // lblThoigian
            // 
            this.lblThoigian.AutoSize = true;
            this.lblThoigian.ForeColor = System.Drawing.Color.White;
            this.lblThoigian.Location = new System.Drawing.Point(114, 25);
            this.lblThoigian.Name = "lblThoigian";
            this.lblThoigian.Size = new System.Drawing.Size(50, 13);
            this.lblThoigian.TabIndex = 1;
            this.lblThoigian.Text = "thoi gian ";
            // 
            // lblDatmua
            // 
            this.lblDatmua.AutoSize = true;
            this.lblDatmua.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatmua.ForeColor = System.Drawing.Color.White;
            this.lblDatmua.Location = new System.Drawing.Point(3, 4);
            this.lblDatmua.Name = "lblDatmua";
            this.lblDatmua.Size = new System.Drawing.Size(112, 18);
            this.lblDatmua.TabIndex = 0;
            this.lblDatmua.Text = "Đặt mua hàng";
            this.lblDatmua.Click += new System.EventHandler(this.lblDatmua_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus_ThemMoi,
            this.toolStripStatus_Sua,
            this.toolStripStatus_Xoa,
            this.toolStripStatus_Loc,
            this.toolStripStatusLabel5,
            this.toolStripStatus_In,
            this.toolStripStatus_Dong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 512);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1058, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatus_ThemMoi
            // 
            this.toolStripStatus_ThemMoi.Image = global::GUI.Properties.Resources.Them;
            this.toolStripStatus_ThemMoi.Name = "toolStripStatus_ThemMoi";
            this.toolStripStatus_ThemMoi.Size = new System.Drawing.Size(168, 21);
            this.toolStripStatus_ThemMoi.Spring = true;
            this.toolStripStatus_ThemMoi.Text = "Thêm mới";
            this.toolStripStatus_ThemMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_ThemMoi.Click += new System.EventHandler(this.toolStripStatus_ThemMoi_Click);
            this.toolStripStatus_ThemMoi.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_ThemMoi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatus_Sua
            // 
            this.toolStripStatus_Sua.Image = global::GUI.Properties.Resources.Sua;
            this.toolStripStatus_Sua.Name = "toolStripStatus_Sua";
            this.toolStripStatus_Sua.Size = new System.Drawing.Size(168, 21);
            this.toolStripStatus_Sua.Spring = true;
            this.toolStripStatus_Sua.Text = "Sửa";
            this.toolStripStatus_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Sua.Click += new System.EventHandler(this.toolStripStatus_Sua_Click);
            this.toolStripStatus_Sua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Sua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatus_Xoa
            // 
            this.toolStripStatus_Xoa.Image = global::GUI.Properties.Resources.Dele;
            this.toolStripStatus_Xoa.Name = "toolStripStatus_Xoa";
            this.toolStripStatus_Xoa.Size = new System.Drawing.Size(168, 21);
            this.toolStripStatus_Xoa.Spring = true;
            this.toolStripStatus_Xoa.Text = "Xoá";
            this.toolStripStatus_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Xoa.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Xoa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatus_Loc
            // 
            this.toolStripStatus_Loc.Image = global::GUI.Properties.Resources.Loc;
            this.toolStripStatus_Loc.Name = "toolStripStatus_Loc";
            this.toolStripStatus_Loc.Size = new System.Drawing.Size(168, 21);
            this.toolStripStatus_Loc.Spring = true;
            this.toolStripStatus_Loc.Text = "Lọc...";
            this.toolStripStatus_Loc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Loc.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Loc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 21);
            // 
            // toolStripStatus_In
            // 
            this.toolStripStatus_In.Image = global::GUI.Properties.Resources.In;
            this.toolStripStatus_In.Name = "toolStripStatus_In";
            this.toolStripStatus_In.Size = new System.Drawing.Size(168, 21);
            this.toolStripStatus_In.Spring = true;
            this.toolStripStatus_In.Text = "In";
            this.toolStripStatus_In.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_In.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_In.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatus_Dong
            // 
            this.toolStripStatus_Dong.Image = global::GUI.Properties.Resources.Xoa;
            this.toolStripStatus_Dong.Name = "toolStripStatus_Dong";
            this.toolStripStatus_Dong.Size = new System.Drawing.Size(168, 21);
            this.toolStripStatus_Dong.Spring = true;
            this.toolStripStatus_Dong.Text = "Đóng";
            this.toolStripStatus_Dong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Dong.Click += new System.EventHandler(this.toolStripStatus_Dong_Click);
            this.toolStripStatus_Dong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Dong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvHienThi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1058, 465);
            this.panel2.TabIndex = 2;
            // 
            // dgvHienThi
            // 
            this.dgvHienThi.AllowUserToAddRows = false;
            this.dgvHienThi.AllowUserToDeleteRows = false;
            this.dgvHienThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvHienThi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvHienThi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHienThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHienThi.EnableHeadersVisualStyles = false;
            this.dgvHienThi.GridColor = System.Drawing.Color.White;
            this.dgvHienThi.Location = new System.Drawing.Point(0, 0);
            this.dgvHienThi.Name = "dgvHienThi";
            this.dgvHienThi.ReadOnly = true;
            this.dgvHienThi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvHienThi.RowHeadersVisible = false;
            this.dgvHienThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHienThi.Size = new System.Drawing.Size(1058, 465);
            this.dgvHienThi.TabIndex = 0;
            // 
            // frmQuanlynhapmua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 538);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.palTencung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmQuanlynhapmua";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đặt hàng - Thông tin đặt hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQuanlynhapmua_Load);
            this.palTencung.ResumeLayout(false);
            this.palTencung.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel palTencung;
        private System.Windows.Forms.Label lblThoigian;
        private System.Windows.Forms.Label lblDatmua;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_ThemMoi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Sua;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Xoa;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Loc;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_In;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Dong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvHienThi;
    }
}