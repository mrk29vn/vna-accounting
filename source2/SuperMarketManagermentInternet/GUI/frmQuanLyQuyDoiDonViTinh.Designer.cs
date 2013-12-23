namespace GUI
{
    partial class frmQuanLyQuyDoiDonViTinh
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
            this.rdoMakho = new System.Windows.Forms.RadioButton();
            this.lblQuyDoi = new System.Windows.Forms.Label();
            this.dgvHienThi = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_ThemMoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Sua = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Xoa = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Dong = new System.Windows.Forms.ToolStripStatusLabel();
            this.palTencung.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // palTencung
            // 
            this.palTencung.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.palTencung.Controls.Add(this.groupBox1);
            this.palTencung.Controls.Add(this.lblQuyDoi);
            this.palTencung.Dock = System.Windows.Forms.DockStyle.Top;
            this.palTencung.Location = new System.Drawing.Point(0, 0);
            this.palTencung.Name = "palTencung";
            this.palTencung.Size = new System.Drawing.Size(584, 83);
            this.palTencung.TabIndex = 1;
            this.palTencung.DoubleClick += new System.EventHandler(this.panelQuyDoiDonViTinh_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTimkiem);
            this.groupBox1.Controls.Add(this.rdoTatca);
            this.groupBox1.Controls.Add(this.rdoMakho);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(0, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 50);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimkiem.Location = new System.Drawing.Point(202, 19);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(380, 20);
            this.txtTimkiem.TabIndex = 27;
            this.txtTimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            // 
            // rdoTatca
            // 
            this.rdoTatca.AutoSize = true;
            this.rdoTatca.Checked = true;
            this.rdoTatca.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTatca.ForeColor = System.Drawing.Color.Black;
            this.rdoTatca.Location = new System.Drawing.Point(141, 19);
            this.rdoTatca.Name = "rdoTatca";
            this.rdoTatca.Size = new System.Drawing.Size(55, 18);
            this.rdoTatca.TabIndex = 31;
            this.rdoTatca.TabStop = true;
            this.rdoTatca.Text = "Tất cả";
            this.rdoTatca.UseVisualStyleBackColor = true;
            this.rdoTatca.CheckedChanged += new System.EventHandler(this.rdbtatca_CheckedChanged);
            // 
            // rdoMakho
            // 
            this.rdoMakho.AutoSize = true;
            this.rdoMakho.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoMakho.Location = new System.Drawing.Point(16, 19);
            this.rdoMakho.Name = "rdoMakho";
            this.rdoMakho.Size = new System.Drawing.Size(82, 18);
            this.rdoMakho.TabIndex = 29;
            this.rdoMakho.Text = "Mã Quy Đổi";
            this.rdoMakho.UseVisualStyleBackColor = true;
            this.rdoMakho.CheckedChanged += new System.EventHandler(this.rdbtheoma_CheckedChanged);
            // 
            // lblQuyDoi
            // 
            this.lblQuyDoi.AutoSize = true;
            this.lblQuyDoi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuyDoi.ForeColor = System.Drawing.Color.White;
            this.lblQuyDoi.Location = new System.Drawing.Point(8, 6);
            this.lblQuyDoi.Name = "lblQuyDoi";
            this.lblQuyDoi.Size = new System.Drawing.Size(151, 19);
            this.lblQuyDoi.TabIndex = 0;
            this.lblQuyDoi.Text = "Quy Đổi Đơn Vị Tính";
            // 
            // dgvHienThi
            // 
            this.dgvHienThi.AllowUserToAddRows = false;
            this.dgvHienThi.AllowUserToDeleteRows = false;
            this.dgvHienThi.BackgroundColor = System.Drawing.Color.White;
            this.dgvHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHienThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHienThi.Location = new System.Drawing.Point(0, 83);
            this.dgvHienThi.Name = "dgvHienThi";
            this.dgvHienThi.ReadOnly = true;
            this.dgvHienThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHienThi.Size = new System.Drawing.Size(584, 279);
            this.dgvHienThi.TabIndex = 2;
            this.dgvHienThi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHienThi_CellClick);
            this.dgvHienThi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHienThi_CellDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatus_ThemMoi,
            this.toolStripStatus_Sua,
            this.toolStripStatus_Xoa,
            this.toolStripStatusLabel5,
            this.toolStripStatus_Dong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 336);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::GUI.Properties.Resources.refresh1;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(107, 21);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Nạp lại";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            this.toolStripStatusLabel1.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatus_ThemMoi
            // 
            this.toolStripStatus_ThemMoi.Image = global::GUI.Properties.Resources.Them;
            this.toolStripStatus_ThemMoi.Name = "toolStripStatus_ThemMoi";
            this.toolStripStatus_ThemMoi.Size = new System.Drawing.Size(107, 21);
            this.toolStripStatus_ThemMoi.Spring = true;
            this.toolStripStatus_ThemMoi.Text = "Thêm";
            this.toolStripStatus_ThemMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_ThemMoi.Click += new System.EventHandler(this.tsslblthemmoi_Click);
            this.toolStripStatus_ThemMoi.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_ThemMoi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatus_Sua
            // 
            this.toolStripStatus_Sua.Image = global::GUI.Properties.Resources.Sua;
            this.toolStripStatus_Sua.Name = "toolStripStatus_Sua";
            this.toolStripStatus_Sua.Size = new System.Drawing.Size(107, 21);
            this.toolStripStatus_Sua.Spring = true;
            this.toolStripStatus_Sua.Text = "Sửa";
            this.toolStripStatus_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Sua.Click += new System.EventHandler(this.tsslblsua_Click);
            this.toolStripStatus_Sua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Sua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatus_Xoa
            // 
            this.toolStripStatus_Xoa.Image = global::GUI.Properties.Resources.Dele;
            this.toolStripStatus_Xoa.Name = "toolStripStatus_Xoa";
            this.toolStripStatus_Xoa.Size = new System.Drawing.Size(107, 21);
            this.toolStripStatus_Xoa.Spring = true;
            this.toolStripStatus_Xoa.Text = "Xoá";
            this.toolStripStatus_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Xoa.Click += new System.EventHandler(this.tsslbl_Click);
            this.toolStripStatus_Xoa.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Xoa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 21);
            // 
            // toolStripStatus_Dong
            // 
            this.toolStripStatus_Dong.Image = global::GUI.Properties.Resources.Xoa;
            this.toolStripStatus_Dong.Name = "toolStripStatus_Dong";
            this.toolStripStatus_Dong.Size = new System.Drawing.Size(107, 21);
            this.toolStripStatus_Dong.Spring = true;
            this.toolStripStatus_Dong.Text = "Đóng";
            this.toolStripStatus_Dong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Dong.Click += new System.EventHandler(this.tsslbldong_Click);
            this.toolStripStatus_Dong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Dong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // frmQuanLyQuyDoiDonViTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvHienThi);
            this.Controls.Add(this.palTencung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmQuanLyQuyDoiDonViTinh";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQuanLyQuyDoiDonViTinh_Load);
            this.palTencung.ResumeLayout(false);
            this.palTencung.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel palTencung;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.RadioButton rdoTatca;
        private System.Windows.Forms.RadioButton rdoMakho;
        private System.Windows.Forms.Label lblQuyDoi;
        private System.Windows.Forms.DataGridView dgvHienThi;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_ThemMoi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Sua;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Xoa;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Dong;
    }
}