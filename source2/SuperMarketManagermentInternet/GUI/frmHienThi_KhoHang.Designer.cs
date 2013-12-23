namespace GUI
{
    partial class frmHienThi_KhoHang
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
            this.lbhienthitongso = new System.Windows.Forms.Label();
            this.lbTongso = new System.Windows.Forms.Label();
            this.lblDatmua = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssThem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssXoa = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLoc = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssIn = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssDong = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvKhoHang = new System.Windows.Forms.DataGridView();
            this.palTencung.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoHang)).BeginInit();
            this.SuspendLayout();
            // 
            // palTencung
            // 
            this.palTencung.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.palTencung.Controls.Add(this.lbhienthitongso);
            this.palTencung.Controls.Add(this.lbTongso);
            this.palTencung.Controls.Add(this.lblDatmua);
            this.palTencung.Dock = System.Windows.Forms.DockStyle.Top;
            this.palTencung.Location = new System.Drawing.Point(0, 0);
            this.palTencung.Name = "palTencung";
            this.palTencung.Size = new System.Drawing.Size(590, 47);
            this.palTencung.TabIndex = 0;
            // 
            // lbhienthitongso
            // 
            this.lbhienthitongso.AutoSize = true;
            this.lbhienthitongso.ForeColor = System.Drawing.Color.Yellow;
            this.lbhienthitongso.Location = new System.Drawing.Point(207, 31);
            this.lbhienthitongso.Name = "lbhienthitongso";
            this.lbhienthitongso.Size = new System.Drawing.Size(13, 13);
            this.lbhienthitongso.TabIndex = 7;
            this.lbhienthitongso.Text = "1";
            // 
            // lbTongso
            // 
            this.lbTongso.AutoSize = true;
            this.lbTongso.ForeColor = System.Drawing.Color.Yellow;
            this.lbTongso.Location = new System.Drawing.Point(152, 31);
            this.lbTongso.Name = "lbTongso";
            this.lbTongso.Size = new System.Drawing.Size(49, 13);
            this.lbTongso.TabIndex = 6;
            this.lbTongso.Text = "Tổng số:";
            // 
            // lblDatmua
            // 
            this.lblDatmua.AutoSize = true;
            this.lblDatmua.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatmua.ForeColor = System.Drawing.Color.White;
            this.lblDatmua.Location = new System.Drawing.Point(12, 5);
            this.lblDatmua.Name = "lblDatmua";
            this.lblDatmua.Size = new System.Drawing.Size(152, 18);
            this.lblDatmua.TabIndex = 0;
            this.lblDatmua.Text = "Thông tin kho hàng";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssThem,
            this.tssSua,
            this.tssXoa,
            this.tssLoc,
            this.toolStripStatusLabel5,
            this.tssIn,
            this.tssDong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 414);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(590, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssThem
            // 
            this.tssThem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tssThem.Image = global::GUI.Properties.Resources.Them;
            this.tssThem.Name = "tssThem";
            this.tssThem.Size = new System.Drawing.Size(95, 17);
            this.tssThem.Spring = true;
            this.tssThem.Text = "Thêm";
            this.tssThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssThem.Click += new System.EventHandler(this.toolStripStatus_ThemMoi_Click);
            this.tssThem.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssThem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssSua
            // 
            this.tssSua.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tssSua.Image = global::GUI.Properties.Resources.Sua;
            this.tssSua.Name = "tssSua";
            this.tssSua.Size = new System.Drawing.Size(95, 17);
            this.tssSua.Spring = true;
            this.tssSua.Text = "Sửa";
            this.tssSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssSua.Click += new System.EventHandler(this.toolStripStatus_Sua_Click);
            this.tssSua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssSua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssXoa
            // 
            this.tssXoa.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tssXoa.Image = global::GUI.Properties.Resources.Dele;
            this.tssXoa.Name = "tssXoa";
            this.tssXoa.Size = new System.Drawing.Size(95, 17);
            this.tssXoa.Spring = true;
            this.tssXoa.Text = "Xoá";
            this.tssXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssXoa.Click += new System.EventHandler(this.tssXoa_Click);
            this.tssXoa.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssXoa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssLoc
            // 
            this.tssLoc.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tssLoc.Image = global::GUI.Properties.Resources.Loc;
            this.tssLoc.Name = "tssLoc";
            this.tssLoc.Size = new System.Drawing.Size(95, 17);
            this.tssLoc.Spring = true;
            this.tssLoc.Text = "Lọc...";
            this.tssLoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssLoc.Click += new System.EventHandler(this.tssLoc_Click);
            this.tssLoc.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssLoc.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 17);
            // 
            // tssIn
            // 
            this.tssIn.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tssIn.Image = global::GUI.Properties.Resources.In;
            this.tssIn.Name = "tssIn";
            this.tssIn.Size = new System.Drawing.Size(95, 17);
            this.tssIn.Spring = true;
            this.tssIn.Text = "In";
            this.tssIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssIn.Click += new System.EventHandler(this.tssIn_Click);
            this.tssIn.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssIn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssDong
            // 
            this.tssDong.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tssDong.Image = global::GUI.Properties.Resources.Xoa;
            this.tssDong.Name = "tssDong";
            this.tssDong.Size = new System.Drawing.Size(95, 17);
            this.tssDong.Spring = true;
            this.tssDong.Text = "Đóng";
            this.tssDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssDong.Click += new System.EventHandler(this.toolStripStatus_Dong_Click);
            this.tssDong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssDong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvKhoHang);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(590, 367);
            this.panel2.TabIndex = 2;
            // 
            // dgvKhoHang
            // 
            this.dgvKhoHang.AllowUserToAddRows = false;
            this.dgvKhoHang.AllowUserToDeleteRows = false;
            this.dgvKhoHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhoHang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvKhoHang.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvKhoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhoHang.EnableHeadersVisualStyles = false;
            this.dgvKhoHang.GridColor = System.Drawing.Color.White;
            this.dgvKhoHang.Location = new System.Drawing.Point(0, 0);
            this.dgvKhoHang.Name = "dgvKhoHang";
            this.dgvKhoHang.ReadOnly = true;
            this.dgvKhoHang.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvKhoHang.RowHeadersVisible = false;
            this.dgvKhoHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoHang.Size = new System.Drawing.Size(590, 367);
            this.dgvKhoHang.TabIndex = 0;
            this.dgvKhoHang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhoHang_CellDoubleClick);
            // 
            // frmHienThi_KhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 436);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.palTencung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmHienThi_KhoHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kho hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHienThi_KhoHang_Load);
            this.palTencung.ResumeLayout(false);
            this.palTencung.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel palTencung;
        private System.Windows.Forms.Label lblDatmua;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssThem;
        private System.Windows.Forms.ToolStripStatusLabel tssSua;
        private System.Windows.Forms.ToolStripStatusLabel tssXoa;
        private System.Windows.Forms.ToolStripStatusLabel tssLoc;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel tssIn;
        private System.Windows.Forms.ToolStripStatusLabel tssDong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvKhoHang;
        private System.Windows.Forms.Label lbhienthitongso;
        private System.Windows.Forms.Label lbTongso;
    }
}