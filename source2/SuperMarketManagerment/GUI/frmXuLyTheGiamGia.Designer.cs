namespace GUI
{
    partial class frmXuLyTheGiamGia
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
            this.tsslblthem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbldong = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.mskKetThuc = new System.Windows.Forms.MaskedTextBox();
            this.mskBatDau = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaTheGiamGia = new System.Windows.Forms.TextBox();
            this.txtMaKhachHang = new System.Windows.Forms.TextBox();
            this.txtGiaTriThe = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblthem,
            this.tsslbldong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 145);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(386, 26);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslblthem
            // 
            this.tsslblthem.Image = global::GUI.Properties.Resources.Them;
            this.tsslblthem.Name = "tsslblthem";
            this.tsslblthem.Size = new System.Drawing.Size(167, 21);
            this.tsslblthem.Spring = true;
            this.tsslblthem.Text = "Thêm";
            this.tsslblthem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslblthem.Click += new System.EventHandler(this.tsslblthem_Click);
            this.tsslblthem.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslblthem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslbldong
            // 
            this.tsslbldong.Image = global::GUI.Properties.Resources.Xoa;
            this.tsslbldong.Name = "tsslbldong";
            this.tsslbldong.Size = new System.Drawing.Size(167, 21);
            this.tsslbldong.Spring = true;
            this.tsslbldong.Text = "Đóng";
            this.tsslbldong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslbldong.Click += new System.EventHandler(this.tsslbldong_Click);
            this.tsslbldong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslbldong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 56);
            this.panel1.TabIndex = 11;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xử Lý Thẻ Giá Trị";
            // 
            // mskKetThuc
            // 
            this.mskKetThuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskKetThuc.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskKetThuc.Location = new System.Drawing.Point(274, 112);
            this.mskKetThuc.Mask = "00/00/0000";
            this.mskKetThuc.Name = "mskKetThuc";
            this.mskKetThuc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mskKetThuc.Size = new System.Drawing.Size(103, 22);
            this.mskKetThuc.TabIndex = 4;
            this.mskKetThuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mskBatDau
            // 
            this.mskBatDau.BackColor = System.Drawing.Color.White;
            this.mskBatDau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskBatDau.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskBatDau.Location = new System.Drawing.Point(88, 112);
            this.mskBatDau.Mask = "00/00/0000";
            this.mskBatDau.Name = "mskBatDau";
            this.mskBatDau.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mskBatDau.Size = new System.Drawing.Size(99, 22);
            this.mskBatDau.TabIndex = 3;
            this.mskBatDau.TabStop = false;
            this.mskBatDau.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 35;
            this.label2.Text = "Mã thẻ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 14);
            this.label3.TabIndex = 36;
            this.label3.Text = "Mã khách hàng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 14);
            this.label4.TabIndex = 37;
            this.label4.Text = "Giá trị thẻ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 14);
            this.label5.TabIndex = 38;
            this.label5.Text = "Ngày bắt đầu:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 14);
            this.label6.TabIndex = 39;
            this.label6.Text = "Ngày kết thúc:";
            // 
            // txtMaTheGiamGia
            // 
            this.txtMaTheGiamGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMaTheGiamGia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaTheGiamGia.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaTheGiamGia.Location = new System.Drawing.Point(88, 60);
            this.txtMaTheGiamGia.Name = "txtMaTheGiamGia";
            this.txtMaTheGiamGia.ReadOnly = true;
            this.txtMaTheGiamGia.Size = new System.Drawing.Size(100, 22);
            this.txtMaTheGiamGia.TabIndex = 40;
            this.txtMaTheGiamGia.TabStop = false;
            // 
            // txtMaKhachHang
            // 
            this.txtMaKhachHang.BackColor = System.Drawing.Color.White;
            this.txtMaKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaKhachHang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKhachHang.Location = new System.Drawing.Point(88, 86);
            this.txtMaKhachHang.Name = "txtMaKhachHang";
            this.txtMaKhachHang.ReadOnly = true;
            this.txtMaKhachHang.Size = new System.Drawing.Size(100, 22);
            this.txtMaKhachHang.TabIndex = 1;
            this.txtMaKhachHang.Text = "<F4 - Tra cứu>";
            this.txtMaKhachHang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // txtGiaTriThe
            // 
            this.txtGiaTriThe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGiaTriThe.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaTriThe.Location = new System.Drawing.Point(274, 86);
            this.txtGiaTriThe.Name = "txtGiaTriThe";
            this.txtGiaTriThe.Size = new System.Drawing.Size(103, 22);
            this.txtGiaTriThe.TabIndex = 2;
            this.txtGiaTriThe.TextChanged += new System.EventHandler(this.txtGiaTriThe_TextChanged);
            // 
            // frmXuLyTheGiamGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 171);
            this.ControlBox = false;
            this.Controls.Add(this.txtGiaTriThe);
            this.Controls.Add(this.txtMaKhachHang);
            this.Controls.Add(this.txtMaTheGiamGia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mskKetThuc);
            this.Controls.Add(this.mskBatDau);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmXuLyTheGiamGia";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblthem;
        private System.Windows.Forms.ToolStripStatusLabel tsslbldong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mskKetThuc;
        private System.Windows.Forms.MaskedTextBox mskBatDau;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaTheGiamGia;
        private System.Windows.Forms.TextBox txtMaKhachHang;
        private System.Windows.Forms.TextBox txtGiaTriThe;
    }
}