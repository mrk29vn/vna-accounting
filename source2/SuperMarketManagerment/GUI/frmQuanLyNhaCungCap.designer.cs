namespace GUI
{
    partial class frmQuanLyNhaCungCap
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
            this.panelNCC = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.rdbtatca = new System.Windows.Forms.RadioButton();
            this.rdbtheoten = new System.Windows.Forms.RadioButton();
            this.rdbtheoma = new System.Windows.Forms.RadioButton();
            this.lbltongs = new System.Windows.Forms.Label();
            this.lblNCC = new System.Windows.Forms.Label();
            this.panelNDNCC = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblthemmoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssllsua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblxoa = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbltrove = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvNCC = new System.Windows.Forms.DataGridView();
            this.panelNCC.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelNDNCC.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNCC)).BeginInit();
            this.SuspendLayout();
            // 
            // panelNCC
            // 
            this.panelNCC.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelNCC.Controls.Add(this.groupBox1);
            this.panelNCC.Controls.Add(this.lbltongs);
            this.panelNCC.Controls.Add(this.lblNCC);
            this.panelNCC.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNCC.Location = new System.Drawing.Point(0, 0);
            this.panelNCC.Name = "panelNCC";
            this.panelNCC.Size = new System.Drawing.Size(594, 89);
            this.panelNCC.TabIndex = 0;
            this.panelNCC.DoubleClick += new System.EventHandler(this.panelNCC_DoubleClick);
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
            this.groupBox1.Size = new System.Drawing.Size(594, 54);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm ";
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(240, 22);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(348, 20);
            this.txttimkiem.TabIndex = 3;
            this.txttimkiem.TextChanged += new System.EventHandler(this.txttimkiem_TextChanged);
            // 
            // rdbtatca
            // 
            this.rdbtatca.AutoSize = true;
            this.rdbtatca.Checked = true;
            this.rdbtatca.Location = new System.Drawing.Point(176, 22);
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
            this.rdbtheoten.Location = new System.Drawing.Point(98, 22);
            this.rdbtheoten.Name = "rdbtheoten";
            this.rdbtheoten.Size = new System.Drawing.Size(65, 17);
            this.rdbtheoten.TabIndex = 1;
            this.rdbtheoten.TabStop = true;
            this.rdbtheoten.Text = "Mã NCC";
            this.rdbtheoten.UseVisualStyleBackColor = true;
            this.rdbtheoten.CheckedChanged += new System.EventHandler(this.rdbtheoten_CheckedChanged);
            // 
            // rdbtheoma
            // 
            this.rdbtheoma.AutoSize = true;
            this.rdbtheoma.Location = new System.Drawing.Point(25, 22);
            this.rdbtheoma.Name = "rdbtheoma";
            this.rdbtheoma.Size = new System.Drawing.Size(69, 17);
            this.rdbtheoma.TabIndex = 0;
            this.rdbtheoma.TabStop = true;
            this.rdbtheoma.Text = "Tên NCC";
            this.rdbtheoma.UseVisualStyleBackColor = true;
            this.rdbtheoma.CheckedChanged += new System.EventHandler(this.rdbtheoma_CheckedChanged);
            // 
            // lbltongs
            // 
            this.lbltongs.AutoSize = true;
            this.lbltongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltongs.ForeColor = System.Drawing.SystemColors.Info;
            this.lbltongs.Location = new System.Drawing.Point(166, 39);
            this.lbltongs.Name = "lbltongs";
            this.lbltongs.Size = new System.Drawing.Size(0, 13);
            this.lbltongs.TabIndex = 2;
            // 
            // lblNCC
            // 
            this.lblNCC.AutoSize = true;
            this.lblNCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNCC.ForeColor = System.Drawing.SystemColors.Info;
            this.lblNCC.Location = new System.Drawing.Point(12, 6);
            this.lblNCC.Name = "lblNCC";
            this.lblNCC.Size = new System.Drawing.Size(107, 19);
            this.lblNCC.TabIndex = 0;
            this.lblNCC.Text = "Nhà Cung Cấp";
            // 
            // panelNDNCC
            // 
            this.panelNDNCC.Controls.Add(this.statusStrip1);
            this.panelNDNCC.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelNDNCC.Location = new System.Drawing.Point(0, 377);
            this.panelNDNCC.Name = "panelNDNCC";
            this.panelNDNCC.Size = new System.Drawing.Size(594, 24);
            this.panelNDNCC.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslblthemmoi,
            this.tssllsua,
            this.tsslblxoa,
            this.tsslbltrove});
            this.statusStrip1.Location = new System.Drawing.Point(0, -2);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(594, 26);
            this.statusStrip1.TabIndex = 1;
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
            // tssllsua
            // 
            this.tssllsua.Image = global::GUI.Properties.Resources.Sua;
            this.tssllsua.Name = "tssllsua";
            this.tssllsua.Size = new System.Drawing.Size(109, 21);
            this.tssllsua.Spring = true;
            this.tssllsua.Text = "Sửa";
            this.tssllsua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssllsua.Click += new System.EventHandler(this.tssllsua_Click);
            this.tssllsua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssllsua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslblxoa
            // 
            this.tsslblxoa.Image = global::GUI.Properties.Resources.Dele;
            this.tsslblxoa.Name = "tsslblxoa";
            this.tsslblxoa.Size = new System.Drawing.Size(109, 21);
            this.tsslblxoa.Spring = true;
            this.tsslblxoa.Text = "Xóa";
            this.tsslblxoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslblxoa.Click += new System.EventHandler(this.tsslblxoa_Click);
            this.tsslblxoa.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslblxoa.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslbltrove
            // 
            this.tsslbltrove.Image = global::GUI.Properties.Resources.Xoa;
            this.tsslbltrove.Name = "tsslbltrove";
            this.tsslbltrove.Size = new System.Drawing.Size(109, 21);
            this.tsslbltrove.Spring = true;
            this.tsslbltrove.Text = "Đóng";
            this.tsslbltrove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslbltrove.Click += new System.EventHandler(this.tsslbltrove_Click);
            this.tsslbltrove.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslbltrove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // dgvNCC
            // 
            this.dgvNCC.AllowUserToAddRows = false;
            this.dgvNCC.AllowUserToDeleteRows = false;
            this.dgvNCC.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvNCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNCC.Location = new System.Drawing.Point(0, 89);
            this.dgvNCC.Name = "dgvNCC";
            this.dgvNCC.ReadOnly = true;
            this.dgvNCC.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgvNCC.Size = new System.Drawing.Size(594, 288);
            this.dgvNCC.TabIndex = 2;
            this.dgvNCC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNCC_CellClick);
            this.dgvNCC.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNCC_CellDoubleClick);
            // 
            // frmQuanLyNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 401);
            this.Controls.Add(this.dgvNCC);
            this.Controls.Add(this.panelNDNCC);
            this.Controls.Add(this.panelNCC);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmQuanLyNhaCungCap";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQuanLyNhaCungCap_Load);
            this.panelNCC.ResumeLayout(false);
            this.panelNCC.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelNDNCC.ResumeLayout(false);
            this.panelNDNCC.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNCC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNCC;
        private System.Windows.Forms.Label lblNCC;
        private System.Windows.Forms.Panel panelNDNCC;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblthemmoi;
        private System.Windows.Forms.ToolStripStatusLabel tssllsua;
        private System.Windows.Forms.ToolStripStatusLabel tsslblxoa;
        private System.Windows.Forms.ToolStripStatusLabel tsslbltrove;
        private System.Windows.Forms.Label lbltongs;
        private System.Windows.Forms.DataGridView dgvNCC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.RadioButton rdbtatca;
        private System.Windows.Forms.RadioButton rdbtheoten;
        private System.Windows.Forms.RadioButton rdbtheoma;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}