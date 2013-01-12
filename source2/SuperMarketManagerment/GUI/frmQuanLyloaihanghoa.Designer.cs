namespace GUI
{
    partial class frmQuanLyLoaiHangHoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLyLoaiHangHoa));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.rdbtatca = new System.Windows.Forms.RadioButton();
            this.rdbtheoten = new System.Windows.Forms.RadioButton();
            this.rdbtheoma = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssThem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssXoa = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssDong = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvQuanLyLoaiHangHoa = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyLoaiHangHoa)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 89);
            this.panel1.TabIndex = 4;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txttimkiem);
            this.groupBox1.Controls.Add(this.rdbtatca);
            this.groupBox1.Controls.Add(this.rdbtheoten);
            this.groupBox1.Controls.Add(this.rdbtheoma);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 54);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm ";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(306, 22);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(272, 20);
            this.txttimkiem.TabIndex = 3;
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            // 
            // rdbtatca
            // 
            this.rdbtatca.AutoSize = true;
            this.rdbtatca.Checked = true;
            this.rdbtatca.Location = new System.Drawing.Point(228, 23);
            this.rdbtatca.Name = "rdbtatca";
            this.rdbtatca.Size = new System.Drawing.Size(57, 17);
            this.rdbtatca.TabIndex = 2;
            this.rdbtatca.TabStop = true;
            this.rdbtatca.Text = "Tất Cả";
            this.rdbtatca.UseVisualStyleBackColor = true;
            this.rdbtatca.CheckedChanged += new System.EventHandler(this.rdbtatca_CheckedChanged);
            // 
            // rdbtheoten
            // 
            this.rdbtheoten.AutoSize = true;
            this.rdbtheoten.Location = new System.Drawing.Point(130, 23);
            this.rdbtheoten.Name = "rdbtheoten";
            this.rdbtheoten.Size = new System.Drawing.Size(92, 17);
            this.rdbtheoten.TabIndex = 1;
            this.rdbtheoten.Text = "Mã Loại Hàng";
            this.rdbtheoten.UseVisualStyleBackColor = true;
            this.rdbtheoten.CheckedChanged += new System.EventHandler(this.rdbtheoten_CheckedChanged);
            // 
            // rdbtheoma
            // 
            this.rdbtheoma.AutoSize = true;
            this.rdbtheoma.Location = new System.Drawing.Point(28, 23);
            this.rdbtheoma.Name = "rdbtheoma";
            this.rdbtheoma.Size = new System.Drawing.Size(96, 17);
            this.rdbtheoma.TabIndex = 0;
            this.rdbtheoma.Text = "Tên Loại Hàng";
            this.rdbtheoma.UseVisualStyleBackColor = true;
            this.rdbtheoma.CheckedChanged += new System.EventHandler(this.rdbtheoma_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý loại hàng hóa";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 366);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 24);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.statusStrip2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(584, 25);
            this.panel3.TabIndex = 4;
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip2.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tssThem,
            this.tssSua,
            this.tssXoa,
            this.toolStripStatusLabel6,
            this.tssDong});
            this.statusStrip2.Location = new System.Drawing.Point(0, 0);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(584, 25);
            this.statusStrip2.TabIndex = 10;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::GUI.Properties.Resources.refresh;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(107, 20);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Nạp lại";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            this.toolStripStatusLabel1.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssThem
            // 
            this.tssThem.Image = ((System.Drawing.Image)(resources.GetObject("tssThem.Image")));
            this.tssThem.Name = "tssThem";
            this.tssThem.Size = new System.Drawing.Size(107, 20);
            this.tssThem.Spring = true;
            this.tssThem.Text = "Thêm ";
            this.tssThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssThem.Click += new System.EventHandler(this.toolStripStatus_ThemMoi_Click);
            this.tssThem.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssThem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssSua
            // 
            this.tssSua.Image = ((System.Drawing.Image)(resources.GetObject("tssSua.Image")));
            this.tssSua.Name = "tssSua";
            this.tssSua.Size = new System.Drawing.Size(107, 20);
            this.tssSua.Spring = true;
            this.tssSua.Text = "Sửa";
            this.tssSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssSua.Click += new System.EventHandler(this.toolStripStatus_Sua_Click);
            this.tssSua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssSua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssXoa
            // 
            this.tssXoa.Image = ((System.Drawing.Image)(resources.GetObject("tssXoa.Image")));
            this.tssXoa.Name = "tssXoa";
            this.tssXoa.Size = new System.Drawing.Size(107, 20);
            this.tssXoa.Spring = true;
            this.tssXoa.Text = "Xoá";
            this.tssXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssXoa.Click += new System.EventHandler(this.tssXoa_Click);
            this.tssXoa.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssXoa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(0, 20);
            // 
            // tssDong
            // 
            this.tssDong.Image = ((System.Drawing.Image)(resources.GetObject("tssDong.Image")));
            this.tssDong.Name = "tssDong";
            this.tssDong.Size = new System.Drawing.Size(107, 20);
            this.tssDong.Spring = true;
            this.tssDong.Text = "Đóng";
            this.tssDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssDong.Click += new System.EventHandler(this.toolStripStatus_Dong_Click);
            this.tssDong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssDong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // dgvQuanLyLoaiHangHoa
            // 
            this.dgvQuanLyLoaiHangHoa.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvQuanLyLoaiHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuanLyLoaiHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuanLyLoaiHangHoa.Location = new System.Drawing.Point(0, 89);
            this.dgvQuanLyLoaiHangHoa.Name = "dgvQuanLyLoaiHangHoa";
            this.dgvQuanLyLoaiHangHoa.ReadOnly = true;
            this.dgvQuanLyLoaiHangHoa.Size = new System.Drawing.Size(584, 277);
            this.dgvQuanLyLoaiHangHoa.TabIndex = 5;
            this.dgvQuanLyLoaiHangHoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuanLyLoaiHangHoa_CellClick);
            this.dgvQuanLyLoaiHangHoa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuanLyLoaiHangHoa_CellDoubleClick);
            // 
            // frmQuanLyLoaiHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 390);
            this.Controls.Add(this.dgvQuanLyLoaiHangHoa);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmQuanLyLoaiHangHoa";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmQuanLyloaihanghoa_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanLyLoaiHangHoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.RadioButton rdbtatca;
        private System.Windows.Forms.RadioButton rdbtheoten;
        private System.Windows.Forms.RadioButton rdbtheoma;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tssThem;
        private System.Windows.Forms.ToolStripStatusLabel tssSua;
        private System.Windows.Forms.ToolStripStatusLabel tssXoa;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel tssDong;
        private System.Windows.Forms.DataGridView dgvQuanLyLoaiHangHoa;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}