namespace GUI
{
    partial class frmQuanLyKhachHang
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
            this.lblkhachhang = new System.Windows.Forms.Label();
            this.lbltongs = new System.Windows.Forms.Label();
            this.panelkhachhang = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbtheoten = new System.Windows.Forms.RadioButton();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.rdbtatca = new System.Windows.Forms.RadioButton();
            this.rdbtheoma = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblthemmoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblsua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbldong = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvkhachhang = new System.Windows.Forms.DataGridView();
            this.panelkhachhang.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhachhang)).BeginInit();
            this.SuspendLayout();
            // 
            // lblkhachhang
            // 
            this.lblkhachhang.AutoSize = true;
            this.lblkhachhang.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblkhachhang.ForeColor = System.Drawing.SystemColors.Info;
            this.lblkhachhang.Location = new System.Drawing.Point(7, 5);
            this.lblkhachhang.Name = "lblkhachhang";
            this.lblkhachhang.Size = new System.Drawing.Size(92, 19);
            this.lblkhachhang.TabIndex = 0;
            this.lblkhachhang.Text = "Khách Hàng";
            // 
            // lbltongs
            // 
            this.lbltongs.AutoSize = true;
            this.lbltongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltongs.ForeColor = System.Drawing.SystemColors.Info;
            this.lbltongs.Location = new System.Drawing.Point(154, 33);
            this.lbltongs.Name = "lbltongs";
            this.lbltongs.Size = new System.Drawing.Size(0, 13);
            this.lbltongs.TabIndex = 2;
            // 
            // panelkhachhang
            // 
            this.panelkhachhang.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelkhachhang.Controls.Add(this.groupBox1);
            this.panelkhachhang.Controls.Add(this.lbltongs);
            this.panelkhachhang.Controls.Add(this.lblkhachhang);
            this.panelkhachhang.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelkhachhang.Location = new System.Drawing.Point(0, 0);
            this.panelkhachhang.Name = "panelkhachhang";
            this.panelkhachhang.Size = new System.Drawing.Size(594, 83);
            this.panelkhachhang.TabIndex = 0;
            this.panelkhachhang.DoubleClick += new System.EventHandler(this.panelkhachhang_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbtheoten);
            this.groupBox1.Controls.Add(this.txttimkiem);
            this.groupBox1.Controls.Add(this.rdbtatca);
            this.groupBox1.Controls.Add(this.rdbtheoma);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 50);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm ";
            // 
            // rdbtheoten
            // 
            this.rdbtheoten.AutoSize = true;
            this.rdbtheoten.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtheoten.Location = new System.Drawing.Point(69, 20);
            this.rdbtheoten.Name = "rdbtheoten";
            this.rdbtheoten.Size = new System.Drawing.Size(59, 18);
            this.rdbtheoten.TabIndex = 5;
            this.rdbtheoten.TabStop = true;
            this.rdbtheoten.Text = "Mã KH";
            this.rdbtheoten.UseVisualStyleBackColor = true;
            this.rdbtheoten.CheckedChanged += new System.EventHandler(this.rdbtheoten_CheckedChanged);
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(198, 20);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(390, 20);
            this.txttimkiem.TabIndex = 3;
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            // 
            // rdbtatca
            // 
            this.rdbtatca.AutoSize = true;
            this.rdbtatca.Checked = true;
            this.rdbtatca.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtatca.Location = new System.Drawing.Point(135, 21);
            this.rdbtatca.Name = "rdbtatca";
            this.rdbtatca.Size = new System.Drawing.Size(57, 18);
            this.rdbtatca.TabIndex = 2;
            this.rdbtatca.TabStop = true;
            this.rdbtatca.Text = "Tất Cả";
            this.rdbtatca.UseVisualStyleBackColor = true;
            this.rdbtatca.CheckedChanged += new System.EventHandler(this.rdbtatca_CheckedChanged);
            // 
            // rdbtheoma
            // 
            this.rdbtheoma.AutoSize = true;
            this.rdbtheoma.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtheoma.Location = new System.Drawing.Point(3, 21);
            this.rdbtheoma.Name = "rdbtheoma";
            this.rdbtheoma.Size = new System.Drawing.Size(63, 18);
            this.rdbtheoma.TabIndex = 0;
            this.rdbtheoma.Text = "Tên KH";
            this.rdbtheoma.UseVisualStyleBackColor = true;
            this.rdbtheoma.CheckedChanged += new System.EventHandler(this.rdbtheoma_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 348);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 24);
            this.panel1.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslblthemmoi,
            this.tsslblsua,
            this.tsslbl,
            this.tsslbldong});
            this.statusStrip1.Location = new System.Drawing.Point(0, -2);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(594, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::GUI.Properties.Resources.refresh;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 21);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Nạp lại";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            this.toolStripStatusLabel1.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslblthemmoi
            // 
            this.tsslblthemmoi.Image = global::GUI.Properties.Resources.Them;
            this.tsslblthemmoi.Name = "tsslblthemmoi";
            this.tsslblthemmoi.Size = new System.Drawing.Size(109, 21);
            this.tsslblthemmoi.Spring = true;
            this.tsslblthemmoi.Text = "Thêm ";
            this.tsslblthemmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslblthemmoi.Click += new System.EventHandler(this.tsslblthemmoi_Click);
            this.tsslblthemmoi.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslblthemmoi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslblsua
            // 
            this.tsslblsua.Image = global::GUI.Properties.Resources.Sua;
            this.tsslblsua.Name = "tsslblsua";
            this.tsslblsua.Size = new System.Drawing.Size(109, 21);
            this.tsslblsua.Spring = true;
            this.tsslblsua.Text = "Sửa";
            this.tsslblsua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslblsua.Click += new System.EventHandler(this.tsslblsua_Click);
            this.tsslblsua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslblsua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslbl
            // 
            this.tsslbl.Image = global::GUI.Properties.Resources.Dele;
            this.tsslbl.Name = "tsslbl";
            this.tsslbl.Size = new System.Drawing.Size(109, 21);
            this.tsslbl.Spring = true;
            this.tsslbl.Text = "Xóa";
            this.tsslbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslbl.Click += new System.EventHandler(this.tsslbl_Click);
            this.tsslbl.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslbl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslbldong
            // 
            this.tsslbldong.Image = global::GUI.Properties.Resources.Xoa;
            this.tsslbldong.Name = "tsslbldong";
            this.tsslbldong.Size = new System.Drawing.Size(109, 21);
            this.tsslbldong.Spring = true;
            this.tsslbldong.Text = "Đóng";
            this.tsslbldong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslbldong.Click += new System.EventHandler(this.tsslbldong_Click);
            this.tsslbldong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslbldong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // dgvkhachhang
            // 
            this.dgvkhachhang.BackgroundColor = System.Drawing.Color.White;
            this.dgvkhachhang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvkhachhang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvkhachhang.Location = new System.Drawing.Point(0, 83);
            this.dgvkhachhang.Name = "dgvkhachhang";
            this.dgvkhachhang.ReadOnly = true;
            this.dgvkhachhang.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvkhachhang.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvkhachhang.Size = new System.Drawing.Size(594, 265);
            this.dgvkhachhang.TabIndex = 3;
            this.dgvkhachhang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvkhachhang_CellClick);
            this.dgvkhachhang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvkhachhang_CellDoubleClick);
            // 
            // frmQuanLyKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 372);
            this.Controls.Add(this.dgvkhachhang);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelkhachhang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmQuanLyKhachHang";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQuanLyKhachHang_Load);
            this.panelkhachhang.ResumeLayout(false);
            this.panelkhachhang.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvkhachhang)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblkhachhang;
        private System.Windows.Forms.Label lbltongs;
        private System.Windows.Forms.Panel panelkhachhang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblthemmoi;
        private System.Windows.Forms.ToolStripStatusLabel tsslblsua;
        private System.Windows.Forms.ToolStripStatusLabel tsslbl;
        private System.Windows.Forms.ToolStripStatusLabel tsslbldong;
        private System.Windows.Forms.DataGridView dgvkhachhang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.RadioButton rdbtatca;
        private System.Windows.Forms.RadioButton rdbtheoma;
        private System.Windows.Forms.RadioButton rdbtheoten;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

    }
}