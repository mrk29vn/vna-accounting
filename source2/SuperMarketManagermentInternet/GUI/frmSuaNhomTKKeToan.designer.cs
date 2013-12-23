namespace GUI
{
    partial class frmSuaNhomTKKeToan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSuaNhomTKKeToan));
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus_Sua = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Dong = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.txtmaNTKKT = new System.Windows.Forms.TextBox();
            this.txttenNTKKT = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip2.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus_Sua,
            this.toolStripStatusLabel6,
            this.toolStripStatus_Dong});
            this.statusStrip2.Location = new System.Drawing.Point(0, 241);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(325, 26);
            this.statusStrip2.TabIndex = 34;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatus_Sua
            // 
            this.toolStripStatus_Sua.Image = global::GUI.Properties.Resources.Sua;
            this.toolStripStatus_Sua.Name = "toolStripStatus_Sua";
            this.toolStripStatus_Sua.Size = new System.Drawing.Size(139, 21);
            this.toolStripStatus_Sua.Spring = true;
            this.toolStripStatus_Sua.Text = "Sửa";
            this.toolStripStatus_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Sua.Click += new System.EventHandler(this.toolStripStatus_Sua_Click);
            this.toolStripStatus_Sua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Sua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
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
            this.toolStripStatus_Dong.Size = new System.Drawing.Size(139, 21);
            this.toolStripStatus_Dong.Spring = true;
            this.toolStripStatus_Dong.Text = "Đóng";
            this.toolStripStatus_Dong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatus_Dong.Click += new System.EventHandler(this.toolStripStatus_Dong_Click);
            this.toolStripStatus_Dong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Dong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(325, 267);
            this.tabControl1.TabIndex = 33;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.txtghichu);
            this.tabPage1.Controls.Add(this.txtmaNTKKT);
            this.tabPage1.Controls.Add(this.txttenNTKKT);
            this.tabPage1.Controls.Add(this.txtID);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(317, 241);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông tin loại TK Kế Toán";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 50;
            this.label13.Text = "Ghi chú";
            // 
            // txtghichu
            // 
            this.txtghichu.Location = new System.Drawing.Point(123, 91);
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtghichu.Size = new System.Drawing.Size(180, 125);
            this.txtghichu.TabIndex = 49;
            // 
            // txtmaNTKKT
            // 
            this.txtmaNTKKT.Location = new System.Drawing.Point(123, 35);
            this.txtmaNTKKT.Name = "txtmaNTKKT";
            this.txtmaNTKKT.Size = new System.Drawing.Size(65, 20);
            this.txtmaNTKKT.TabIndex = 39;
            // 
            // txttenNTKKT
            // 
            this.txttenNTKKT.Location = new System.Drawing.Point(123, 63);
            this.txttenNTKKT.Name = "txttenNTKKT";
            this.txttenNTKKT.Size = new System.Drawing.Size(180, 20);
            this.txttenNTKKT.TabIndex = 38;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(123, 9);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(67, 20);
            this.txtID.TabIndex = 37;
            this.txtID.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Tên Nhóm Tài Khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Mã Nhóm TK";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Nhóm TK ID";
            // 
            // frmSuaNhomTKKeToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 267);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmSuaNhomTKKeToan";
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmSuaNhomTKKeToan_Load);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Sua;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Dong;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.TextBox txtmaNTKKT;
        private System.Windows.Forms.TextBox txttenNTKKT;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}