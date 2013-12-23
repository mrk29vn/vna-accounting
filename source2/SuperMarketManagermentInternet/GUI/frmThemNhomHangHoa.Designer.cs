namespace GUI
{
    partial class frmThemNhomHangHoa
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
            this.tssThem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssDong = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtMaLoaiHang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaNhomHang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.txtTenNhomHang = new System.Windows.Forms.TextBox();
            this.lblghichu = new System.Windows.Forms.Label();
            this.lbltennhomhang = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvNhomHang = new System.Windows.Forms.DataGridView();
            this.lblNhomHang = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomHang)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssThem,
            this.tssSua,
            this.tssDong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 211);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(557, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssThem
            // 
            this.tssThem.Image = global::GUI.Properties.Resources.Them;
            this.tssThem.Name = "tssThem";
            this.tssThem.Size = new System.Drawing.Size(170, 21);
            this.tssThem.Spring = true;
            this.tssThem.Text = "Thêm";
            this.tssThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssThem.Click += new System.EventHandler(this.tssThem_Click);
            this.tssThem.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssThem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssSua
            // 
            this.tssSua.Enabled = false;
            this.tssSua.Image = global::GUI.Properties.Resources.Sua;
            this.tssSua.Name = "tssSua";
            this.tssSua.Size = new System.Drawing.Size(170, 21);
            this.tssSua.Spring = true;
            this.tssSua.Text = "Sửa";
            this.tssSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssSua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssSua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssDong
            // 
            this.tssDong.Image = global::GUI.Properties.Resources.Xoa;
            this.tssDong.Name = "tssDong";
            this.tssDong.Size = new System.Drawing.Size(170, 21);
            this.tssDong.Spring = true;
            this.tssDong.Text = "Đóng";
            this.tssDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssDong.Click += new System.EventHandler(this.btnTroVe_Click);
            this.tssDong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssDong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(557, 237);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(557, 211);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtMaLoaiHang);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtMaNhomHang);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtGhiChu);
            this.tabPage1.Controls.Add(this.txtTenNhomHang);
            this.tabPage1.Controls.Add(this.lblghichu);
            this.tabPage1.Controls.Add(this.lbltennhomhang);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(549, 185);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1.Thông tin";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtMaLoaiHang
            // 
            this.txtMaLoaiHang.Location = new System.Drawing.Point(110, 39);
            this.txtMaLoaiHang.Name = "txtMaLoaiHang";
            this.txtMaLoaiHang.Size = new System.Drawing.Size(130, 20);
            this.txtMaLoaiHang.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mã loại hàng:";
            // 
            // txtMaNhomHang
            // 
            this.txtMaNhomHang.Location = new System.Drawing.Point(110, 13);
            this.txtMaNhomHang.Name = "txtMaNhomHang";
            this.txtMaNhomHang.Size = new System.Drawing.Size(130, 20);
            this.txtMaNhomHang.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã nhóm hàng:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(110, 91);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(436, 92);
            this.txtGhiChu.TabIndex = 5;
            // 
            // txtTenNhomHang
            // 
            this.txtTenNhomHang.Location = new System.Drawing.Point(110, 65);
            this.txtTenNhomHang.Name = "txtTenNhomHang";
            this.txtTenNhomHang.Size = new System.Drawing.Size(226, 20);
            this.txtTenNhomHang.TabIndex = 4;
            // 
            // lblghichu
            // 
            this.lblghichu.AutoSize = true;
            this.lblghichu.Location = new System.Drawing.Point(57, 89);
            this.lblghichu.Name = "lblghichu";
            this.lblghichu.Size = new System.Drawing.Size(47, 13);
            this.lblghichu.TabIndex = 2;
            this.lblghichu.Text = "Ghi chú:";
            // 
            // lbltennhomhang
            // 
            this.lbltennhomhang.AutoSize = true;
            this.lbltennhomhang.Location = new System.Drawing.Point(19, 68);
            this.lbltennhomhang.Name = "lbltennhomhang";
            this.lbltennhomhang.Size = new System.Drawing.Size(85, 13);
            this.lbltennhomhang.TabIndex = 1;
            this.lbltennhomhang.Text = "Tên nhóm hàng:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvNhomHang);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(553, 193);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2.Hàng hóa";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvNhomHang
            // 
            this.dgvNhomHang.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvNhomHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhomHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhomHang.Location = new System.Drawing.Point(3, 3);
            this.dgvNhomHang.Name = "dgvNhomHang";
            this.dgvNhomHang.Size = new System.Drawing.Size(536, 163);
            this.dgvNhomHang.TabIndex = 0;
            // 
            // lblNhomHang
            // 
            this.lblNhomHang.AutoSize = true;
            this.lblNhomHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhomHang.ForeColor = System.Drawing.SystemColors.Info;
            this.lblNhomHang.Location = new System.Drawing.Point(3, 4);
            this.lblNhomHang.Name = "lblNhomHang";
            this.lblNhomHang.Size = new System.Drawing.Size(203, 18);
            this.lblNhomHang.TabIndex = 0;
            this.lblNhomHang.Text = "THÊM NHÓM HÀNG HÓA";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.lblNhomHang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 45);
            this.panel1.TabIndex = 0;
            // 
            // frmThemNhomHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(557, 282);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmThemNhomHangHoa";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm nhóm hàng hóa";
            this.Load += new System.EventHandler(this.frmThemNhomHangHoa_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhomHang)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssSua;
        private System.Windows.Forms.ToolStripStatusLabel tssDong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtTenNhomHang;
        private System.Windows.Forms.Label lblghichu;
        private System.Windows.Forms.Label lbltennhomhang;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblNhomHang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvNhomHang;
        private System.Windows.Forms.ToolStripStatusLabel tssThem;
        private System.Windows.Forms.TextBox txtMaNhomHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaLoaiHang;
        private System.Windows.Forms.Label label2;

    }
}