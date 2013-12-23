namespace GUI
{
    partial class frmXuly_NhomTKKeToan
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
            this.label13 = new System.Windows.Forms.Label();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.txtmaNTKKT = new System.Windows.Forms.TextBox();
            this.txttenNTKKT = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.tsslThem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDong = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 50;
            this.label13.Text = "Ghi chú";
            // 
            // txtghichu
            // 
            this.txtghichu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtghichu.Location = new System.Drawing.Point(125, 89);
            this.txtghichu.MaxLength = 100;
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(333, 82);
            this.txtghichu.TabIndex = 4;
            // 
            // txtmaNTKKT
            // 
            this.txtmaNTKKT.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtmaNTKKT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmaNTKKT.Location = new System.Drawing.Point(125, 29);
            this.txtmaNTKKT.MaxLength = 3;
            this.txtmaNTKKT.Name = "txtmaNTKKT";
            this.txtmaNTKKT.ReadOnly = true;
            this.txtmaNTKKT.Size = new System.Drawing.Size(333, 20);
            this.txtmaNTKKT.TabIndex = 2;
            this.txtmaNTKKT.TextChanged += new System.EventHandler(this.txtmaNTKKT_TextChanged);
            // 
            // txttenNTKKT
            // 
            this.txttenNTKKT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttenNTKKT.Location = new System.Drawing.Point(125, 59);
            this.txttenNTKKT.MaxLength = 100;
            this.txttenNTKKT.Name = "txttenNTKKT";
            this.txttenNTKKT.Size = new System.Drawing.Size(333, 20);
            this.txttenNTKKT.TabIndex = 3;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Location = new System.Drawing.Point(125, 1);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(65, 20);
            this.txtID.TabIndex = 1;
            this.txtID.Text = "1";
            this.txtID.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "Tên Nhóm Tài Khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 14);
            this.label2.TabIndex = 26;
            this.label2.Text = "Mã Nhóm TK";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "Nhóm TK ID";
            this.label1.Visible = false;
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(0, 21);
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.statusStrip2.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslThem,
            this.tsslSua,
            this.toolStripStatusLabel6,
            this.tsslDong});
            this.statusStrip2.Location = new System.Drawing.Point(0, 200);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(482, 26);
            this.statusStrip2.TabIndex = 36;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // tsslThem
            // 
            this.tsslThem.Image = global::GUI.Properties.Resources.Them;
            this.tsslThem.Name = "tsslThem";
            this.tsslThem.Size = new System.Drawing.Size(145, 21);
            this.tsslThem.Spring = true;
            this.tsslThem.Text = "Thêm";
            this.tsslThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslThem.Click += new System.EventHandler(this.tsslThem_Click);
            this.tsslThem.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslThem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslSua
            // 
            this.tsslSua.Image = global::GUI.Properties.Resources.Sua;
            this.tsslSua.Name = "tsslSua";
            this.tsslSua.Size = new System.Drawing.Size(145, 21);
            this.tsslSua.Spring = true;
            this.tsslSua.Text = "Sửa";
            this.tsslSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslSua.Click += new System.EventHandler(this.tsslSua_Click);
            this.tsslSua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslSua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslDong
            // 
            this.tsslDong.Image = global::GUI.Properties.Resources.Tro_ve;
            this.tsslDong.Name = "tsslDong";
            this.tsslDong.Size = new System.Drawing.Size(145, 21);
            this.tsslDong.Spring = true;
            this.tsslDong.Text = "Trở Về";
            this.tsslDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslDong.Click += new System.EventHandler(this.tsslDong_Click);
            this.tsslDong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslDong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // frmXuly_NhomTKKeToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 226);
            this.ControlBox = false;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtghichu);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.txtmaNTKKT);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txttenNTKKT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmXuly_NhomTKKeToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xử Lý Nhóm Tài Khoản Kế Toán";
            this.Load += new System.EventHandler(this.frmXuly_NhomTKKeToan_Load);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.TextBox txtmaNTKKT;
        private System.Windows.Forms.TextBox txttenNTKKT;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel tsslSua;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel tsslDong;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tsslThem;
    }
}