namespace GUI
{
    partial class frmXuLyThue
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmathue = new System.Windows.Forms.TextBox();
            this.txtgiatrithue = new System.Windows.Forms.TextBox();
            this.txttenthue = new System.Windows.Forms.TextBox();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslblthem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblsua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbldong = new System.Windows.Forms.ToolStripStatusLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 52);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thuế";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Thuế:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giá Trị Thuế:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên Thuế:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ghi Chú:";
            // 
            // txtmathue
            // 
            this.txtmathue.BackColor = System.Drawing.SystemColors.Info;
            this.txtmathue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmathue.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmathue.Location = new System.Drawing.Point(88, 69);
            this.txtmathue.Name = "txtmathue";
            this.txtmathue.ReadOnly = true;
            this.txtmathue.Size = new System.Drawing.Size(125, 20);
            this.txtmathue.TabIndex = 0;
            this.txtmathue.TabStop = false;
            // 
            // txtgiatrithue
            // 
            this.txtgiatrithue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtgiatrithue.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgiatrithue.Location = new System.Drawing.Point(88, 100);
            this.txtgiatrithue.Name = "txtgiatrithue";
            this.txtgiatrithue.Size = new System.Drawing.Size(179, 20);
            this.txtgiatrithue.TabIndex = 1;
            this.txtgiatrithue.TextChanged += new System.EventHandler(this.txtgiatrithue_TextChanged);
            this.txtgiatrithue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtgiatrithue_KeyPress);
            // 
            // txttenthue
            // 
            this.txttenthue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttenthue.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttenthue.Location = new System.Drawing.Point(88, 128);
            this.txttenthue.MaxLength = 99;
            this.txttenthue.Name = "txttenthue";
            this.txttenthue.Size = new System.Drawing.Size(365, 20);
            this.txttenthue.TabIndex = 2;
            // 
            // txtghichu
            // 
            this.txtghichu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtghichu.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtghichu.Location = new System.Drawing.Point(88, 156);
            this.txtghichu.MaxLength = 99;
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtghichu.Size = new System.Drawing.Size(365, 66);
            this.txtghichu.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblthem,
            this.tsslblsua,
            this.tsslbldong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 247);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(465, 26);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslblthem
            // 
            this.tsslblthem.Image = global::GUI.Properties.Resources.Them;
            this.tsslblthem.Name = "tsslblthem";
            this.tsslblthem.Size = new System.Drawing.Size(139, 21);
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
            this.tsslblsua.Size = new System.Drawing.Size(139, 21);
            this.tsslblsua.Spring = true;
            this.tsslblsua.Text = "Sửa";
            this.tsslblsua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslblsua.Click += new System.EventHandler(this.tsslblsua_Click);
            this.tsslblsua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslblsua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslbldong
            // 
            this.tsslbldong.Image = global::GUI.Properties.Resources.Xoa;
            this.tsslbldong.Name = "tsslbldong";
            this.tsslbldong.Size = new System.Drawing.Size(139, 21);
            this.tsslbldong.Spring = true;
            this.tsslbldong.Text = "Đóng";
            this.tsslbldong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslbldong.Click += new System.EventHandler(this.tsslbldong_Click);
            this.tsslbldong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslbldong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(273, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "[%]";
            // 
            // frmXuLyThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 273);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtghichu);
            this.Controls.Add(this.txttenthue);
            this.Controls.Add(this.txtgiatrithue);
            this.Controls.Add(this.txtmathue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmXuLyThue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông Tin Thuế";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmXuLyThue_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtmathue;
        private System.Windows.Forms.TextBox txtgiatrithue;
        private System.Windows.Forms.TextBox txttenthue;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblthem;
        private System.Windows.Forms.ToolStripStatusLabel tsslblsua;
        private System.Windows.Forms.ToolStripStatusLabel tsslbldong;
        private System.Windows.Forms.Label label6;
    }
}