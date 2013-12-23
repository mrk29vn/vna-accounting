namespace GUI
{
    partial class frmQuanlynhanvien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanlynhanvien));
            this.panel1 = new System.Windows.Forms.Panel();
            this.grbDieuKien = new System.Windows.Forms.GroupBox();
            this.rdbTatCa = new System.Windows.Forms.RadioButton();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.rdbMa = new System.Windows.Forms.RadioButton();
            this.rdbTen = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_ThemMoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Sua = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Xoa = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Dong = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.grbDieuKien.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.grbDieuKien);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 98);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDoubleClick);
            // 
            // grbDieuKien
            // 
            this.grbDieuKien.Controls.Add(this.rdbTatCa);
            this.grbDieuKien.Controls.Add(this.txtTimKiem);
            this.grbDieuKien.Controls.Add(this.rdbMa);
            this.grbDieuKien.Controls.Add(this.rdbTen);
            this.grbDieuKien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbDieuKien.Location = new System.Drawing.Point(0, 47);
            this.grbDieuKien.Name = "grbDieuKien";
            this.grbDieuKien.Size = new System.Drawing.Size(594, 51);
            this.grbDieuKien.TabIndex = 5;
            this.grbDieuKien.TabStop = false;
            this.grbDieuKien.Text = "Tìm Kiếm";
            // 
            // rdbTatCa
            // 
            this.rdbTatCa.AutoSize = true;
            this.rdbTatCa.Checked = true;
            this.rdbTatCa.Location = new System.Drawing.Point(222, 22);
            this.rdbTatCa.Name = "rdbTatCa";
            this.rdbTatCa.Size = new System.Drawing.Size(57, 17);
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
            this.txtTimKiem.Size = new System.Drawing.Size(303, 20);
            this.txtTimKiem.TabIndex = 7;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // rdbMa
            // 
            this.rdbMa.AutoSize = true;
            this.rdbMa.Location = new System.Drawing.Point(125, 22);
            this.rdbMa.Name = "rdbMa";
            this.rdbMa.Size = new System.Drawing.Size(58, 17);
            this.rdbMa.TabIndex = 0;
            this.rdbMa.TabStop = true;
            this.rdbMa.Text = "Mã NV";
            this.rdbMa.UseVisualStyleBackColor = true;
            this.rdbMa.CheckedChanged += new System.EventHandler(this.rdbMa_CheckedChanged);
            // 
            // rdbTen
            // 
            this.rdbTen.AutoSize = true;
            this.rdbTen.Location = new System.Drawing.Point(21, 22);
            this.rdbTen.Name = "rdbTen";
            this.rdbTen.Size = new System.Drawing.Size(62, 17);
            this.rdbTen.TabIndex = 0;
            this.rdbTen.TabStop = true;
            this.rdbTen.Text = "Tên NV";
            this.rdbTen.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Quản lý nhân viên";
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip2.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatus_ThemMoi,
            this.toolStripStatus_Sua,
            this.toolStripStatus_Xoa,
            this.toolStripStatusLabel6,
            this.toolStripStatus_Dong});
            this.statusStrip2.Location = new System.Drawing.Point(0, 375);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(594, 26);
            this.statusStrip2.TabIndex = 10;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
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
            this.toolStripStatus_ThemMoi.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatus_ThemMoi.Image")));
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
            this.toolStripStatus_Sua.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatus_Sua.Image")));
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
            this.toolStripStatus_Xoa.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatus_Xoa.Image")));
            this.toolStripStatus_Xoa.Name = "toolStripStatus_Xoa";
            this.toolStripStatus_Xoa.Size = new System.Drawing.Size(109, 21);
            this.toolStripStatus_Xoa.Spring = true;
            this.toolStripStatus_Xoa.Text = "Xoá";
            this.toolStripStatus_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Xoa.Click += new System.EventHandler(this.toolStripStatus_Xoa_Click);
            this.toolStripStatus_Xoa.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Xoa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(0, 21);
            // 
            // toolStripStatus_Dong
            // 
            this.toolStripStatus_Dong.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatus_Dong.Image")));
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
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 277);
            this.panel2.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(594, 277);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // frmQuanlynhanvien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 401);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmQuanlynhanvien";
            this.ShowIcon = false;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmQuanlynhanvien_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grbDieuKien.ResumeLayout(false);
            this.grbDieuKien.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_ThemMoi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Sua;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Xoa;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Dong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox grbDieuKien;
        private System.Windows.Forms.RadioButton rdbTatCa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.RadioButton rdbMa;
        private System.Windows.Forms.RadioButton rdbTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}