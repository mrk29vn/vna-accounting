namespace GUI
{
    partial class frmHienThi_DieuChuyenKhoNoiBo
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
            this.grbDieuKien = new System.Windows.Forms.GroupBox();
            this.rdbTatCa = new System.Windows.Forms.RadioButton();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.rdbMa = new System.Windows.Forms.RadioButton();
            this.lblDatmua = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_ThemMoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Sua = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Xoa = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Dong = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvHienThi = new System.Windows.Forms.DataGridView();
            this.palTencung.SuspendLayout();
            this.grbDieuKien.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).BeginInit();
            this.SuspendLayout();
            // 
            // palTencung
            // 
            this.palTencung.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.palTencung.Controls.Add(this.grbDieuKien);
            this.palTencung.Controls.Add(this.lblDatmua);
            this.palTencung.Dock = System.Windows.Forms.DockStyle.Top;
            this.palTencung.Location = new System.Drawing.Point(0, 0);
            this.palTencung.Name = "palTencung";
            this.palTencung.Size = new System.Drawing.Size(594, 102);
            this.palTencung.TabIndex = 0;
            this.palTencung.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.palTencung_MouseDoubleClick);
            // 
            // grbDieuKien
            // 
            this.grbDieuKien.Controls.Add(this.rdbTatCa);
            this.grbDieuKien.Controls.Add(this.txtTimKiem);
            this.grbDieuKien.Controls.Add(this.rdbMa);
            this.grbDieuKien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbDieuKien.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDieuKien.Location = new System.Drawing.Point(0, 51);
            this.grbDieuKien.Name = "grbDieuKien";
            this.grbDieuKien.Size = new System.Drawing.Size(594, 51);
            this.grbDieuKien.TabIndex = 10;
            this.grbDieuKien.TabStop = false;
            this.grbDieuKien.Text = "Tìm Kiếm";
            // 
            // rdbTatCa
            // 
            this.rdbTatCa.AutoSize = true;
            this.rdbTatCa.Checked = true;
            this.rdbTatCa.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTatCa.Location = new System.Drawing.Point(222, 22);
            this.rdbTatCa.Name = "rdbTatCa";
            this.rdbTatCa.Size = new System.Drawing.Size(57, 18);
            this.rdbTatCa.TabIndex = 1;
            this.rdbTatCa.TabStop = true;
            this.rdbTatCa.Text = "Tất Cả";
            this.rdbTatCa.UseVisualStyleBackColor = true;
            this.rdbTatCa.CheckedChanged += new System.EventHandler(this.rdbTatCa_CheckedChanged);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtTimKiem.Location = new System.Drawing.Point(285, 18);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(297, 21);
            this.txtTimKiem.TabIndex = 7;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // rdbMa
            // 
            this.rdbMa.AutoSize = true;
            this.rdbMa.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMa.Location = new System.Drawing.Point(125, 22);
            this.rdbMa.Name = "rdbMa";
            this.rdbMa.Size = new System.Drawing.Size(66, 18);
            this.rdbMa.TabIndex = 0;
            this.rdbMa.Text = "Mã ĐCK";
            this.rdbMa.UseVisualStyleBackColor = true;
            // 
            // lblDatmua
            // 
            this.lblDatmua.AutoSize = true;
            this.lblDatmua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatmua.ForeColor = System.Drawing.Color.White;
            this.lblDatmua.Location = new System.Drawing.Point(12, 10);
            this.lblDatmua.Name = "lblDatmua";
            this.lblDatmua.Size = new System.Drawing.Size(165, 19);
            this.lblDatmua.TabIndex = 0;
            this.lblDatmua.Text = "Điều chuyển kho nội bộ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatus_ThemMoi,
            this.toolStripStatus_Sua,
            this.toolStripStatus_Xoa,
            this.toolStripStatusLabel5,
            this.toolStripStatus_Dong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 375);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(594, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripStatusLabel1.Image = global::GUI.Properties.Resources.refresh;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 21);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Nạp Lại";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            this.toolStripStatusLabel1.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatus_ThemMoi
            // 
            this.toolStripStatus_ThemMoi.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripStatus_ThemMoi.Image = global::GUI.Properties.Resources.Them;
            this.toolStripStatus_ThemMoi.Name = "toolStripStatus_ThemMoi";
            this.toolStripStatus_ThemMoi.Size = new System.Drawing.Size(109, 21);
            this.toolStripStatus_ThemMoi.Spring = true;
            this.toolStripStatus_ThemMoi.Text = "Thêm";
            this.toolStripStatus_ThemMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_ThemMoi.Click += new System.EventHandler(this.toolStripStatus_ThemMoi_Click);
            this.toolStripStatus_ThemMoi.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_ThemMoi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatus_Sua
            // 
            this.toolStripStatus_Sua.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripStatus_Sua.Image = global::GUI.Properties.Resources.Sua;
            this.toolStripStatus_Sua.Name = "toolStripStatus_Sua";
            this.toolStripStatus_Sua.Size = new System.Drawing.Size(109, 21);
            this.toolStripStatus_Sua.Spring = true;
            this.toolStripStatus_Sua.Text = "Sửa";
            this.toolStripStatus_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Sua.Click += new System.EventHandler(this.toolStripStatus_Sua_Click);
            this.toolStripStatus_Sua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Sua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatus_Xoa
            // 
            this.toolStripStatus_Xoa.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripStatus_Xoa.Image = global::GUI.Properties.Resources.Dele;
            this.toolStripStatus_Xoa.Name = "toolStripStatus_Xoa";
            this.toolStripStatus_Xoa.Size = new System.Drawing.Size(109, 21);
            this.toolStripStatus_Xoa.Spring = true;
            this.toolStripStatus_Xoa.Text = "Xoá";
            this.toolStripStatus_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Xoa.Click += new System.EventHandler(this.toolStripStatus_Xoa_Click);
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
            this.toolStripStatus_Dong.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStripStatus_Dong.Image = global::GUI.Properties.Resources.Xoa;
            this.toolStripStatus_Dong.Name = "toolStripStatus_Dong";
            this.toolStripStatus_Dong.Size = new System.Drawing.Size(109, 21);
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
            this.panel2.Location = new System.Drawing.Point(0, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 273);
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
            this.dgvHienThi.Location = new System.Drawing.Point(0, 0);
            this.dgvHienThi.Name = "dgvHienThi";
            this.dgvHienThi.ReadOnly = true;
            this.dgvHienThi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvHienThi.RowHeadersVisible = false;
            this.dgvHienThi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHienThi.Size = new System.Drawing.Size(594, 273);
            this.dgvHienThi.TabIndex = 0;
            this.dgvHienThi.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHienThi_CellDoubleClick);
            // 
            // frmHienThi_DieuChuyenKhoNoiBo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 401);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.palTencung);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmHienThi_DieuChuyenKhoNoiBo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHienThi_DieuChuyenKhoNoiBo_Load);
            this.palTencung.ResumeLayout(false);
            this.palTencung.PerformLayout();
            this.grbDieuKien.ResumeLayout(false);
            this.grbDieuKien.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel palTencung;
        private System.Windows.Forms.Label lblDatmua;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_ThemMoi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Sua;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Xoa;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Dong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvHienThi;
        private System.Windows.Forms.GroupBox grbDieuKien;
        private System.Windows.Forms.RadioButton rdbTatCa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.RadioButton rdbMa;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}