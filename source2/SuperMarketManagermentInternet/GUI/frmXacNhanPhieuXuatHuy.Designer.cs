namespace GUI
{
    partial class frmXacNhanPhieuXuatHuy
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
            this.tsslsua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslin = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssldong = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbthutien = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtgvxuathuyhanghoa = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.rdbtimkiem3 = new System.Windows.Forms.RadioButton();
            this.rdbtimkiem2 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvxuathuyhanghoa)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslsua,
            this.tsslin,
            this.tssldong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 364);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(620, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslsua
            // 
            this.tsslsua.Image = global::GUI.Properties.Resources.Sua;
            this.tsslsua.Name = "tsslsua";
            this.tsslsua.Size = new System.Drawing.Size(201, 21);
            this.tsslsua.Spring = true;
            this.tsslsua.Text = "Chi tiết";
            this.tsslsua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslsua.Click += new System.EventHandler(this.tsslsua_Click);
            this.tsslsua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslsua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslin
            // 
            this.tsslin.Image = global::GUI.Properties.Resources.In;
            this.tsslin.Name = "tsslin";
            this.tsslin.Size = new System.Drawing.Size(201, 21);
            this.tsslin.Spring = true;
            this.tsslin.Text = "Xác nhận";
            this.tsslin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslin.Click += new System.EventHandler(this.tsslin_Click);
            this.tsslin.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssldong
            // 
            this.tssldong.Image = global::GUI.Properties.Resources.Xoa;
            this.tssldong.Name = "tssldong";
            this.tssldong.Size = new System.Drawing.Size(201, 21);
            this.tssldong.Spring = true;
            this.tssldong.Text = "Đó&ng";
            this.tssldong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssldong.Click += new System.EventHandler(this.tssldong_Click);
            this.tssldong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssldong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // lbthutien
            // 
            this.lbthutien.AutoSize = true;
            this.lbthutien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbthutien.ForeColor = System.Drawing.SystemColors.Info;
            this.lbthutien.Location = new System.Drawing.Point(12, 10);
            this.lbthutien.Name = "lbthutien";
            this.lbthutien.Size = new System.Drawing.Size(184, 19);
            this.lbthutien.TabIndex = 10;
            this.lbthutien.Text = "Xác Nhận Phiếu Xuất Hủy";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(620, 390);
            this.panel2.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtgvxuathuyhanghoa);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 130);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(620, 234);
            this.panel3.TabIndex = 3;
            // 
            // dtgvxuathuyhanghoa
            // 
            this.dtgvxuathuyhanghoa.BackgroundColor = System.Drawing.Color.White;
            this.dtgvxuathuyhanghoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvxuathuyhanghoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvxuathuyhanghoa.Location = new System.Drawing.Point(0, 0);
            this.dtgvxuathuyhanghoa.Name = "dtgvxuathuyhanghoa";
            this.dtgvxuathuyhanghoa.Size = new System.Drawing.Size(620, 234);
            this.dtgvxuathuyhanghoa.TabIndex = 0;
            this.dtgvxuathuyhanghoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvxuathuyhanghoa_CellClick);
            this.dtgvxuathuyhanghoa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvxuathuyhanghoa_CellContentClick);
            this.dtgvxuathuyhanghoa.DoubleClick += new System.EventHandler(this.dtgvxuathuyhanghoa_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.lbthutien);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 130);
            this.panel1.TabIndex = 2;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txttimkiem);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.rdbtimkiem3);
            this.groupBox1.Controls.Add(this.rdbtimkiem2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(0, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 88);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(163, 26);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(259, 20);
            this.txttimkiem.TabIndex = 3;
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            // 
            // rdbtimkiem3
            // 
            this.rdbtimkiem3.AutoSize = true;
            this.rdbtimkiem3.Checked = true;
            this.rdbtimkiem3.Location = new System.Drawing.Point(101, 29);
            this.rdbtimkiem3.Name = "rdbtimkiem3";
            this.rdbtimkiem3.Size = new System.Drawing.Size(55, 18);
            this.rdbtimkiem3.TabIndex = 2;
            this.rdbtimkiem3.TabStop = true;
            this.rdbtimkiem3.Text = "Tất cả";
            this.rdbtimkiem3.UseVisualStyleBackColor = true;
            this.rdbtimkiem3.CheckedChanged += new System.EventHandler(this.rdbtimkiem3_CheckedChanged);
            // 
            // rdbtimkiem2
            // 
            this.rdbtimkiem2.AutoSize = true;
            this.rdbtimkiem2.Location = new System.Drawing.Point(12, 29);
            this.rdbtimkiem2.Name = "rdbtimkiem2";
            this.rdbtimkiem2.Size = new System.Drawing.Size(80, 18);
            this.rdbtimkiem2.TabIndex = 1;
            this.rdbtimkiem2.TabStop = true;
            this.rdbtimkiem2.Text = "Mã hóa đơn";
            this.rdbtimkiem2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(428, 26);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(156, 20);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Chọn tất cả                     ";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmXacNhanPhieuXuatHuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 390);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmXacNhanPhieuXuatHuy";
            this.ShowIcon = false;
            this.Text = " ";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvxuathuyhanghoa)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslsua;
        private System.Windows.Forms.ToolStripStatusLabel tsslin;
        private System.Windows.Forms.ToolStripStatusLabel tssldong;
        private System.Windows.Forms.Label lbthutien;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtgvxuathuyhanghoa;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.RadioButton rdbtimkiem3;
        private System.Windows.Forms.RadioButton rdbtimkiem2;
    }
}