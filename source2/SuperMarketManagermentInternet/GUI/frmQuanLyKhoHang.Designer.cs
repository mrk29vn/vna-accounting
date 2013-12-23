namespace GUI
{
    partial class frmQuanLyKhoHang
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.rdoTatca = new System.Windows.Forms.RadioButton();
            this.rdoTenkho = new System.Windows.Forms.RadioButton();
            this.rdoMakho = new System.Windows.Forms.RadioButton();
            this.lblDatmua = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssThem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssXoa = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssDong = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvKhoHang = new System.Windows.Forms.DataGridView();
            this.palTencung.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhoHang)).BeginInit();
            this.SuspendLayout();
            // 
            // palTencung
            // 
            this.palTencung.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.palTencung.Controls.Add(this.groupBox1);
            this.palTencung.Controls.Add(this.lblDatmua);
            this.palTencung.Dock = System.Windows.Forms.DockStyle.Top;
            this.palTencung.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.palTencung.Location = new System.Drawing.Point(0, 0);
            this.palTencung.Name = "palTencung";
            this.palTencung.Size = new System.Drawing.Size(594, 83);
            this.palTencung.TabIndex = 0;
            this.palTencung.DoubleClick += new System.EventHandler(this.palTencung_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTimkiem);
            this.groupBox1.Controls.Add(this.rdoTatca);
            this.groupBox1.Controls.Add(this.rdoTenkho);
            this.groupBox1.Controls.Add(this.rdoMakho);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 50);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimkiem.Location = new System.Drawing.Point(255, 19);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(327, 20);
            this.txtTimkiem.TabIndex = 27;
            this.txtTimkiem.TextChanged += new System.EventHandler(this.txtTimkiem_TextChanged);
            // 
            // rdoTatca
            // 
            this.rdoTatca.AutoSize = true;
            this.rdoTatca.Checked = true;
            this.rdoTatca.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTatca.ForeColor = System.Drawing.Color.Black;
            this.rdoTatca.Location = new System.Drawing.Point(195, 19);
            this.rdoTatca.Name = "rdoTatca";
            this.rdoTatca.Size = new System.Drawing.Size(55, 18);
            this.rdoTatca.TabIndex = 31;
            this.rdoTatca.TabStop = true;
            this.rdoTatca.Text = "Tất cả";
            this.rdoTatca.UseVisualStyleBackColor = true;
            this.rdoTatca.CheckedChanged += new System.EventHandler(this.rdoTatca_CheckedChanged);
            this.rdoTatca.TextChanged += new System.EventHandler(this.rdoTatca_CheckedChanged);
            // 
            // rdoTenkho
            // 
            this.rdoTenkho.AutoSize = true;
            this.rdoTenkho.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTenkho.ForeColor = System.Drawing.Color.Black;
            this.rdoTenkho.Location = new System.Drawing.Point(105, 19);
            this.rdoTenkho.Name = "rdoTenkho";
            this.rdoTenkho.Size = new System.Drawing.Size(87, 18);
            this.rdoTenkho.TabIndex = 30;
            this.rdoTenkho.Text = "Tìm theo tên";
            this.rdoTenkho.UseVisualStyleBackColor = true;
            this.rdoTenkho.CheckedChanged += new System.EventHandler(this.rdoTenkho_CheckedChanged);
            this.rdoTenkho.TextChanged += new System.EventHandler(this.rdoTenkho_CheckedChanged);
            // 
            // rdoMakho
            // 
            this.rdoMakho.AutoSize = true;
            this.rdoMakho.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoMakho.Location = new System.Drawing.Point(16, 19);
            this.rdoMakho.Name = "rdoMakho";
            this.rdoMakho.Size = new System.Drawing.Size(86, 18);
            this.rdoMakho.TabIndex = 29;
            this.rdoMakho.Text = "Tìm theo mã";
            this.rdoMakho.UseVisualStyleBackColor = true;
            this.rdoMakho.CheckedChanged += new System.EventHandler(this.rdoMakho_CheckedChanged);
            this.rdoMakho.TextChanged += new System.EventHandler(this.rdoMakho_CheckedChanged);
            // 
            // lblDatmua
            // 
            this.lblDatmua.AutoSize = true;
            this.lblDatmua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatmua.ForeColor = System.Drawing.Color.White;
            this.lblDatmua.Location = new System.Drawing.Point(3, 8);
            this.lblDatmua.Name = "lblDatmua";
            this.lblDatmua.Size = new System.Drawing.Size(137, 19);
            this.lblDatmua.TabIndex = 0;
            this.lblDatmua.Text = "Thông tin kho hàng";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tssThem,
            this.tssSua,
            this.tssXoa,
            this.toolStripStatusLabel5,
            this.tssDong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 346);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(594, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::GUI.Properties.Resources.refresh1;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 21);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Nạp lại";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            this.toolStripStatusLabel1.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssThem
            // 
            this.tssThem.Image = global::GUI.Properties.Resources.Them;
            this.tssThem.Name = "tssThem";
            this.tssThem.Size = new System.Drawing.Size(109, 21);
            this.tssThem.Spring = true;
            this.tssThem.Text = "Thêm";
            this.tssThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssThem.Click += new System.EventHandler(this.toolStripStatus_ThemMoi_Click);
            this.tssThem.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssThem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssSua
            // 
            this.tssSua.Image = global::GUI.Properties.Resources.Sua;
            this.tssSua.Name = "tssSua";
            this.tssSua.Size = new System.Drawing.Size(109, 21);
            this.tssSua.Spring = true;
            this.tssSua.Text = "Sửa";
            this.tssSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssSua.Click += new System.EventHandler(this.toolStripStatus_Sua_Click);
            this.tssSua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssSua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssXoa
            // 
            this.tssXoa.Image = global::GUI.Properties.Resources.Dele;
            this.tssXoa.Name = "tssXoa";
            this.tssXoa.Size = new System.Drawing.Size(109, 21);
            this.tssXoa.Spring = true;
            this.tssXoa.Text = "Xoá";
            this.tssXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssXoa.Click += new System.EventHandler(this.tssXoa_Click);
            this.tssXoa.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssXoa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 21);
            // 
            // tssDong
            // 
            this.tssDong.Image = global::GUI.Properties.Resources.Xoa;
            this.tssDong.Name = "tssDong";
            this.tssDong.Size = new System.Drawing.Size(109, 21);
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
            this.panel2.Location = new System.Drawing.Point(0, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 263);
            this.panel2.TabIndex = 2;
            // 
            // dgvKhoHang
            // 
            this.dgvKhoHang.AllowUserToAddRows = false;
            this.dgvKhoHang.AllowUserToDeleteRows = false;
            this.dgvKhoHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhoHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhoHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKhoHang.Location = new System.Drawing.Point(0, 0);
            this.dgvKhoHang.Name = "dgvKhoHang";
            this.dgvKhoHang.ReadOnly = true;
            this.dgvKhoHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoHang.Size = new System.Drawing.Size(594, 263);
            this.dgvKhoHang.TabIndex = 0;
            this.dgvKhoHang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhoHang_CellDoubleClick);
            // 
            // frmQuanLyKhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 372);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.palTencung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmQuanLyKhoHang";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHienThi_KhoHang_Load);
            this.palTencung.ResumeLayout(false);
            this.palTencung.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel tssDong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.RadioButton rdoTatca;
        private System.Windows.Forms.RadioButton rdoTenkho;
        private System.Windows.Forms.RadioButton rdoMakho;
        private System.Windows.Forms.DataGridView dgvKhoHang;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}