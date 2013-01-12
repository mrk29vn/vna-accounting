namespace GUI
{
    partial class frmQuanLyThue
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
            this.rdbtheoten = new System.Windows.Forms.RadioButton();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.rdbtatca = new System.Windows.Forms.RadioButton();
            this.rdbtheoma = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblthem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblsua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblxoa = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbldong = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvThue = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThue)).BeginInit();
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
            this.panel1.TabIndex = 0;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbtheoten);
            this.groupBox1.Controls.Add(this.txttimkiem);
            this.groupBox1.Controls.Add(this.rdbtatca);
            this.groupBox1.Controls.Add(this.rdbtheoma);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 54);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm ";
            // 
            // rdbtheoten
            // 
            this.rdbtheoten.AutoSize = true;
            this.rdbtheoten.Location = new System.Drawing.Point(85, 25);
            this.rdbtheoten.Name = "rdbtheoten";
            this.rdbtheoten.Size = new System.Drawing.Size(68, 17);
            this.rdbtheoten.TabIndex = 5;
            this.rdbtheoten.TabStop = true;
            this.rdbtheoten.Text = "Mã Thuế";
            this.rdbtheoten.UseVisualStyleBackColor = true;
            this.rdbtheoten.CheckedChanged += new System.EventHandler(this.rdbtheoten_CheckedChanged);
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(222, 22);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(356, 20);
            this.txttimkiem.TabIndex = 3;
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            // 
            // rdbtatca
            // 
            this.rdbtatca.AutoSize = true;
            this.rdbtatca.Checked = true;
            this.rdbtatca.Location = new System.Drawing.Point(159, 25);
            this.rdbtatca.Name = "rdbtatca";
            this.rdbtatca.Size = new System.Drawing.Size(57, 17);
            this.rdbtatca.TabIndex = 2;
            this.rdbtatca.TabStop = true;
            this.rdbtatca.Text = "Tất Cả";
            this.rdbtatca.UseVisualStyleBackColor = true;
            this.rdbtatca.CheckedChanged += new System.EventHandler(this.rdbtatca_CheckedChanged);
            // 
            // rdbtheoma
            // 
            this.rdbtheoma.AutoSize = true;
            this.rdbtheoma.Location = new System.Drawing.Point(7, 25);
            this.rdbtheoma.Name = "rdbtheoma";
            this.rdbtheoma.Size = new System.Drawing.Size(72, 17);
            this.rdbtheoma.TabIndex = 0;
            this.rdbtheoma.Text = "Tên Thuế";
            this.rdbtheoma.UseVisualStyleBackColor = true;
            this.rdbtheoma.CheckedChanged += new System.EventHandler(this.rdbtheoma_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản Lý Thuế";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslblthem,
            this.tsslblsua,
            this.tsslblxoa,
            this.tsslbldong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 364);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(584, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::GUI.Properties.Resources.refresh;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(107, 21);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Nạp lại";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            this.toolStripStatusLabel1.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslblthem
            // 
            this.tsslblthem.Image = global::GUI.Properties.Resources.Them;
            this.tsslblthem.Name = "tsslblthem";
            this.tsslblthem.Size = new System.Drawing.Size(107, 21);
            this.tsslblthem.Spring = true;
            this.tsslblthem.Text = "Thêm";
            this.tsslblthem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslblthem.Click += new System.EventHandler(this.tsslblthem_Click);
            this.tsslblthem.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslblthem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslblsua
            // 
            this.tsslblsua.Image = global::GUI.Properties.Resources.Sua;
            this.tsslblsua.Name = "tsslblsua";
            this.tsslblsua.Size = new System.Drawing.Size(107, 21);
            this.tsslblsua.Spring = true;
            this.tsslblsua.Text = "Sửa";
            this.tsslblsua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslblsua.Click += new System.EventHandler(this.tsslblsua_Click);
            this.tsslblsua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslblsua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslblxoa
            // 
            this.tsslblxoa.Image = global::GUI.Properties.Resources.Dele;
            this.tsslblxoa.Name = "tsslblxoa";
            this.tsslblxoa.Size = new System.Drawing.Size(107, 21);
            this.tsslblxoa.Spring = true;
            this.tsslblxoa.Text = "Xóa";
            this.tsslblxoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslblxoa.Click += new System.EventHandler(this.tsslblxoa_Click);
            this.tsslblxoa.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslblxoa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslbldong
            // 
            this.tsslbldong.Image = global::GUI.Properties.Resources.Xoa;
            this.tsslbldong.Name = "tsslbldong";
            this.tsslbldong.Size = new System.Drawing.Size(107, 21);
            this.tsslbldong.Spring = true;
            this.tsslbldong.Text = "Đóng";
            this.tsslbldong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslbldong.Click += new System.EventHandler(this.tsslbldong_Click);
            this.tsslbldong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslbldong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvThue);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 275);
            this.panel2.TabIndex = 5;
            // 
            // dgvThue
            // 
            this.dgvThue.BackgroundColor = System.Drawing.Color.White;
            this.dgvThue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThue.Location = new System.Drawing.Point(0, 0);
            this.dgvThue.Name = "dgvThue";
            this.dgvThue.ReadOnly = true;
            this.dgvThue.Size = new System.Drawing.Size(584, 275);
            this.dgvThue.TabIndex = 2;
            this.dgvThue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThue_CellClick);
            this.dgvThue.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThue_CellDoubleClick);
            // 
            // frmQuanLyThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 390);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmQuanLyThue";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQuanLyThue_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbtheoten;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.RadioButton rdbtatca;
        private System.Windows.Forms.RadioButton rdbtheoma;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblthem;
        private System.Windows.Forms.ToolStripStatusLabel tsslblsua;
        private System.Windows.Forms.ToolStripStatusLabel tsslblxoa;
        private System.Windows.Forms.ToolStripStatusLabel tsslbldong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvThue;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}