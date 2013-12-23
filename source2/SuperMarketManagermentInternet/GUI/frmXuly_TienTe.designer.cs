namespace GUI
{
    partial class frmXuly_TienTe
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdonvi = new System.Windows.Forms.MaskedTextBox();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbieutuong = new System.Windows.Forms.TextBox();
            this.txttenttl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txttenttc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txttentt = new System.Windows.Forms.TextBox();
            this.txtmatt = new System.Windows.Forms.TextBox();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.tsslThem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSua = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDong = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Location = new System.Drawing.Point(116, 2);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(65, 20);
            this.txtID.TabIndex = 100;
            this.txtID.Text = "0";
            this.txtID.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 113;
            this.label13.Text = "Ghi chú";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 14);
            this.label1.TabIndex = 98;
            this.label1.Text = "Tiền Tệ ID";
            this.label1.Visible = false;
            // 
            // txtdonvi
            // 
            this.txtdonvi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdonvi.Location = new System.Drawing.Point(414, 96);
            this.txtdonvi.Mask = "9999999";
            this.txtdonvi.Name = "txtdonvi";
            this.txtdonvi.Size = new System.Drawing.Size(186, 20);
            this.txtdonvi.TabIndex = 5;
            // 
            // txtghichu
            // 
            this.txtghichu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtghichu.Location = new System.Drawing.Point(115, 132);
            this.txtghichu.MaxLength = 100;
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(485, 92);
            this.txtghichu.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 99;
            this.label2.Text = "Mã tiền tệ";
            // 
            // txtbieutuong
            // 
            this.txtbieutuong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbieutuong.Location = new System.Drawing.Point(115, 96);
            this.txtbieutuong.MaxLength = 100;
            this.txtbieutuong.Name = "txtbieutuong";
            this.txtbieutuong.Size = new System.Drawing.Size(180, 20);
            this.txtbieutuong.TabIndex = 2;
            // 
            // txttenttl
            // 
            this.txttenttl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttenttl.Location = new System.Drawing.Point(414, 64);
            this.txttenttl.MaxLength = 100;
            this.txttenttl.Name = "txttenttl";
            this.txttenttl.Size = new System.Drawing.Size(186, 20);
            this.txttenttl.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 14);
            this.label3.TabIndex = 100;
            this.label3.Text = "Tên tiền tệ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(325, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 14);
            this.label7.TabIndex = 104;
            this.label7.Text = "Đợn vị làm tròn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 14);
            this.label4.TabIndex = 101;
            this.label4.Text = "Tên tiền tệ chẵn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 14);
            this.label6.TabIndex = 103;
            this.label6.Text = "Biểu tượng ";
            // 
            // txttenttc
            // 
            this.txttenttc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttenttc.Location = new System.Drawing.Point(414, 35);
            this.txttenttc.MaxLength = 100;
            this.txttenttc.Name = "txttenttc";
            this.txttenttc.Size = new System.Drawing.Size(186, 20);
            this.txttenttc.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(325, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 102;
            this.label5.Text = "Tên tiền tệ lẻ";
            // 
            // txttentt
            // 
            this.txttentt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttentt.Location = new System.Drawing.Point(115, 64);
            this.txttentt.MaxLength = 100;
            this.txttentt.Name = "txttentt";
            this.txttentt.Size = new System.Drawing.Size(180, 20);
            this.txttentt.TabIndex = 1;
            // 
            // txtmatt
            // 
            this.txtmatt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtmatt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmatt.Location = new System.Drawing.Point(115, 35);
            this.txtmatt.Name = "txtmatt";
            this.txtmatt.ReadOnly = true;
            this.txtmatt.Size = new System.Drawing.Size(180, 20);
            this.txtmatt.TabIndex = 200;
            // 
            // statusStrip2
            // 
            this.statusStrip2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip2.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslThem,
            this.tsslSua,
            this.toolStripStatusLabel6,
            this.tsslDong});
            this.statusStrip2.Location = new System.Drawing.Point(0, 245);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(634, 26);
            this.statusStrip2.TabIndex = 118;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // tsslThem
            // 
            this.tsslThem.Image = global::GUI.Properties.Resources.Them;
            this.tsslThem.Name = "tsslThem";
            this.tsslThem.Size = new System.Drawing.Size(196, 21);
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
            this.tsslSua.Size = new System.Drawing.Size(196, 21);
            this.tsslSua.Spring = true;
            this.tsslSua.Text = "Sửa ";
            this.tsslSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslSua.Click += new System.EventHandler(this.tsslSua_Click);
            this.tsslSua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslSua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(0, 21);
            // 
            // tsslDong
            // 
            this.tsslDong.Image = global::GUI.Properties.Resources.Tro_ve;
            this.tsslDong.Name = "tsslDong";
            this.tsslDong.Size = new System.Drawing.Size(196, 21);
            this.tsslDong.Spring = true;
            this.tsslDong.Text = "Trở Về";
            this.tsslDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslDong.Click += new System.EventHandler(this.tsslDong_Click);
            this.tsslDong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslDong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // frmXuly_TienTe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 271);
            this.ControlBox = false;
            this.Controls.Add(this.txtdonvi);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtbieutuong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtmatt);
            this.Controls.Add(this.txtghichu);
            this.Controls.Add(this.txttentt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txttenttc);
            this.Controls.Add(this.txttenttl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmXuly_TienTe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xử Lý Tiền Tệ";
            this.Load += new System.EventHandler(this.frmXuly_TienTe_Load);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbieutuong;
        private System.Windows.Forms.TextBox txttenttl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txttenttc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txttentt;
        private System.Windows.Forms.TextBox txtmatt;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tsslSua;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel tsslDong;
        private System.Windows.Forms.ToolStripStatusLabel tsslThem;
        private System.Windows.Forms.MaskedTextBox txtdonvi;
    }
}