namespace GUI
{
    partial class frmTimKH
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.rdbtimkiem3 = new System.Windows.Forms.RadioButton();
            this.rdbtimkiem2 = new System.Windows.Forms.RadioButton();
            this.rdbtimkiem1 = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslchapnhan = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslhuybo = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgvKH = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKH)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 88);
            this.panel1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txttimkiem);
            this.groupBox1.Controls.Add(this.rdbtimkiem3);
            this.groupBox1.Controls.Add(this.rdbtimkiem2);
            this.groupBox1.Controls.Add(this.rdbtimkiem1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 60);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(277, 26);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(165, 20);
            this.txttimkiem.TabIndex = 1;
            this.txttimkiem.TabStop = false;
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            // 
            // rdbtimkiem3
            // 
            this.rdbtimkiem3.AutoSize = true;
            this.rdbtimkiem3.Checked = true;
            this.rdbtimkiem3.Location = new System.Drawing.Point(215, 29);
            this.rdbtimkiem3.Name = "rdbtimkiem3";
            this.rdbtimkiem3.Size = new System.Drawing.Size(56, 17);
            this.rdbtimkiem3.TabIndex = 2;
            this.rdbtimkiem3.TabStop = true;
            this.rdbtimkiem3.Text = "Tất cả";
            this.rdbtimkiem3.UseVisualStyleBackColor = true;
            this.rdbtimkiem3.CheckedChanged += new System.EventHandler(this.rdbtimkiem3_CheckedChanged);
            this.rdbtimkiem3.TextChanged += new System.EventHandler(this.rdbtimkiem3_CheckedChanged);
            // 
            // rdbtimkiem2
            // 
            this.rdbtimkiem2.AutoSize = true;
            this.rdbtimkiem2.Location = new System.Drawing.Point(12, 29);
            this.rdbtimkiem2.Name = "rdbtimkiem2";
            this.rdbtimkiem2.Size = new System.Drawing.Size(100, 17);
            this.rdbtimkiem2.TabIndex = 1;
            this.rdbtimkiem2.Text = "Mã khách hàng";
            this.rdbtimkiem2.UseVisualStyleBackColor = true;
            this.rdbtimkiem2.CheckedChanged += new System.EventHandler(this.rdbtimkiem2_CheckedChanged);
            // 
            // rdbtimkiem1
            // 
            this.rdbtimkiem1.AutoSize = true;
            this.rdbtimkiem1.Location = new System.Drawing.Point(112, 29);
            this.rdbtimkiem1.Name = "rdbtimkiem1";
            this.rdbtimkiem1.Size = new System.Drawing.Size(104, 17);
            this.rdbtimkiem1.TabIndex = 0;
            this.rdbtimkiem1.Text = "Tên khách hàng";
            this.rdbtimkiem1.UseVisualStyleBackColor = true;
            this.rdbtimkiem1.CheckedChanged += new System.EventHandler(this.rdbtimkiem1_CheckedChanged);
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
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvKH);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 384);
            this.panel2.TabIndex = 1;
            this.panel2.TabStop = true;
            // 
            // dtgvKH
            // 
            this.dtgvKH.BackgroundColor = System.Drawing.Color.White;
            this.dtgvKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvKH.Location = new System.Drawing.Point(0, 0);
            this.dtgvKH.Name = "dtgvKH";
            this.dtgvKH.Size = new System.Drawing.Size(448, 384);
            this.dtgvKH.TabIndex = 1;
            this.dtgvKH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvKH_CellClick);
            this.dtgvKH.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvKH_CellDoubleClick);
            this.dtgvKH.DoubleClick += new System.EventHandler(this.dtgvKH_DoubleClick);
            this.dtgvKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgvKH_KeyUp);
            // 
            // frmTimKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 498);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTimKH";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lọc - Khách Hàng";
            this.Resize += new System.EventHandler(this.frmTimKH_Resize);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvKH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslchapnhan;
        private System.Windows.Forms.ToolStripStatusLabel tsslhuybo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgvKH;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.RadioButton rdbtimkiem3;
        private System.Windows.Forms.RadioButton rdbtimkiem2;
        private System.Windows.Forms.RadioButton rdbtimkiem1;
    }
}