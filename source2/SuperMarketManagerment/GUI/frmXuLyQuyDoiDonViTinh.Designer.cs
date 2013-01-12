namespace GUI
{
    partial class frmXuLyQuyDoiDonViTinh
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
            this.tsslblthemmoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblghilai = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbltrove = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMaNCC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtmaquydoidvt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txttenhangquydoi = new System.Windows.Forms.TextBox();
            this.txtdonvitinhquydoi = new System.Windows.Forms.TextBox();
            this.txtsoluongquydoi = new System.Windows.Forms.TextBox();
            this.txttenhangduocquydoi = new System.Windows.Forms.TextBox();
            this.txtdonvitinhduocquydoi = new System.Windows.Forms.TextBox();
            this.txtsoluongduocquydoi = new System.Windows.Forms.TextBox();
            this.txtmahangduocquydoi = new System.Windows.Forms.TextBox();
            this.txtmahangquydoi = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslblthemmoi,
            this.tsslblghilai,
            this.tsslbltrove});
            this.statusStrip1.Location = new System.Drawing.Point(0, 205);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(667, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslblthemmoi
            // 
            this.tsslblthemmoi.Image = global::GUI.Properties.Resources.Them;
            this.tsslblthemmoi.Name = "tsslblthemmoi";
            this.tsslblthemmoi.Size = new System.Drawing.Size(207, 21);
            this.tsslblthemmoi.Spring = true;
            this.tsslblthemmoi.Text = "Thêm ";
            this.tsslblthemmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslblthemmoi.Click += new System.EventHandler(this.tssThem_Click);
            this.tsslblthemmoi.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslblthemmoi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslblghilai
            // 
            this.tsslblghilai.Image = global::GUI.Properties.Resources.Luu;
            this.tsslblghilai.Name = "tsslblghilai";
            this.tsslblghilai.Size = new System.Drawing.Size(207, 21);
            this.tsslblghilai.Spring = true;
            this.tsslblghilai.Text = "Sửa";
            this.tsslblghilai.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslblghilai.Click += new System.EventHandler(this.tssSua_Click);
            this.tsslblghilai.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslblghilai.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslbltrove
            // 
            this.tsslbltrove.Image = global::GUI.Properties.Resources.Tro_ve;
            this.tsslbltrove.Name = "tsslbltrove";
            this.tsslbltrove.Size = new System.Drawing.Size(207, 21);
            this.tsslbltrove.Spring = true;
            this.tsslbltrove.Text = "Trở về";
            this.tsslbltrove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslbltrove.Click += new System.EventHandler(this.tssDong_Click);
            this.tsslbltrove.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslbltrove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // lblMaNCC
            // 
            this.lblMaNCC.AutoSize = true;
            this.lblMaNCC.Location = new System.Drawing.Point(25, 47);
            this.lblMaNCC.Name = "lblMaNCC";
            this.lblMaNCC.Size = new System.Drawing.Size(95, 13);
            this.lblMaNCC.TabIndex = 5;
            this.lblMaNCC.Text = "Mã Hàng Quy Đổi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tên Hàng Quy Đổi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Đơn Vị Tính:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Số Lượng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mã Hàng Được Quy Đổi:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Tên Hàng Được Quy Đổi:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(375, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Đơn Vị Tính:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(386, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Số Lượng:";
            // 
            // txtmaquydoidvt
            // 
            this.txtmaquydoidvt.BackColor = System.Drawing.SystemColors.Info;
            this.txtmaquydoidvt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmaquydoidvt.Location = new System.Drawing.Point(122, 7);
            this.txtmaquydoidvt.Name = "txtmaquydoidvt";
            this.txtmaquydoidvt.ReadOnly = true;
            this.txtmaquydoidvt.Size = new System.Drawing.Size(181, 20);
            this.txtmaquydoidvt.TabIndex = 0;
            this.txtmaquydoidvt.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Mã Quy Đổi:";
            // 
            // txttenhangquydoi
            // 
            this.txttenhangquydoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txttenhangquydoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttenhangquydoi.Location = new System.Drawing.Point(122, 75);
            this.txttenhangquydoi.MaxLength = 99;
            this.txttenhangquydoi.Name = "txttenhangquydoi";
            this.txttenhangquydoi.ReadOnly = true;
            this.txttenhangquydoi.Size = new System.Drawing.Size(181, 20);
            this.txttenhangquydoi.TabIndex = 2;
            // 
            // txtdonvitinhquydoi
            // 
            this.txtdonvitinhquydoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtdonvitinhquydoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdonvitinhquydoi.Location = new System.Drawing.Point(122, 104);
            this.txtdonvitinhquydoi.MaxLength = 99;
            this.txtdonvitinhquydoi.Name = "txtdonvitinhquydoi";
            this.txtdonvitinhquydoi.ReadOnly = true;
            this.txtdonvitinhquydoi.Size = new System.Drawing.Size(181, 20);
            this.txtdonvitinhquydoi.TabIndex = 3;
            // 
            // txtsoluongquydoi
            // 
            this.txtsoluongquydoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtsoluongquydoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsoluongquydoi.Location = new System.Drawing.Point(122, 134);
            this.txtsoluongquydoi.MaxLength = 99;
            this.txtsoluongquydoi.Name = "txtsoluongquydoi";
            this.txtsoluongquydoi.ReadOnly = true;
            this.txtsoluongquydoi.Size = new System.Drawing.Size(181, 20);
            this.txtsoluongquydoi.TabIndex = 4;
            this.txtsoluongquydoi.Text = "1";
            // 
            // txttenhangduocquydoi
            // 
            this.txttenhangduocquydoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txttenhangduocquydoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttenhangduocquydoi.Location = new System.Drawing.Point(446, 73);
            this.txttenhangduocquydoi.MaxLength = 99;
            this.txttenhangduocquydoi.Name = "txttenhangduocquydoi";
            this.txttenhangduocquydoi.ReadOnly = true;
            this.txttenhangduocquydoi.Size = new System.Drawing.Size(181, 20);
            this.txttenhangduocquydoi.TabIndex = 6;
            // 
            // txtdonvitinhduocquydoi
            // 
            this.txtdonvitinhduocquydoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtdonvitinhduocquydoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdonvitinhduocquydoi.Location = new System.Drawing.Point(446, 103);
            this.txtdonvitinhduocquydoi.MaxLength = 99;
            this.txtdonvitinhduocquydoi.Name = "txtdonvitinhduocquydoi";
            this.txtdonvitinhduocquydoi.ReadOnly = true;
            this.txtdonvitinhduocquydoi.Size = new System.Drawing.Size(181, 20);
            this.txtdonvitinhduocquydoi.TabIndex = 7;
            // 
            // txtsoluongduocquydoi
            // 
            this.txtsoluongduocquydoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsoluongduocquydoi.Location = new System.Drawing.Point(446, 134);
            this.txtsoluongduocquydoi.MaxLength = 99;
            this.txtsoluongduocquydoi.Name = "txtsoluongduocquydoi";
            this.txtsoluongduocquydoi.Size = new System.Drawing.Size(181, 20);
            this.txtsoluongduocquydoi.TabIndex = 8;
            this.txtsoluongduocquydoi.TextChanged += new System.EventHandler(this.txtsoluongduocquydoi_TextChanged);
            // 
            // txtmahangduocquydoi
            // 
            this.txtmahangduocquydoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmahangduocquydoi.Location = new System.Drawing.Point(446, 44);
            this.txtmahangduocquydoi.MaxLength = 99;
            this.txtmahangduocquydoi.Name = "txtmahangduocquydoi";
            this.txtmahangduocquydoi.Size = new System.Drawing.Size(181, 20);
            this.txtmahangduocquydoi.TabIndex = 5;
            this.txtmahangduocquydoi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtmahangduocquydoi_KeyUp);
            // 
            // txtmahangquydoi
            // 
            this.txtmahangquydoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmahangquydoi.Location = new System.Drawing.Point(122, 43);
            this.txtmahangquydoi.MaxLength = 99;
            this.txtmahangquydoi.Name = "txtmahangquydoi";
            this.txtmahangquydoi.Size = new System.Drawing.Size(181, 20);
            this.txtmahangquydoi.TabIndex = 1;
            this.txtmahangquydoi.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtmahangquydoi_KeyUp);
            // 
            // frmXuLyQuyDoiDonViTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 231);
            this.Controls.Add(this.txtmahangquydoi);
            this.Controls.Add(this.txtmahangduocquydoi);
            this.Controls.Add(this.txtsoluongduocquydoi);
            this.Controls.Add(this.txtdonvitinhduocquydoi);
            this.Controls.Add(this.txttenhangduocquydoi);
            this.Controls.Add(this.txtsoluongquydoi);
            this.Controls.Add(this.txtdonvitinhquydoi);
            this.Controls.Add(this.txttenhangquydoi);
            this.Controls.Add(this.txtmaquydoidvt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMaNCC);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmXuLyQuyDoiDonViTinh";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmXuLyQuyDoiDonViTinh_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblthemmoi;
        private System.Windows.Forms.ToolStripStatusLabel tsslblghilai;
        private System.Windows.Forms.ToolStripStatusLabel tsslbltrove;
        private System.Windows.Forms.Label lblMaNCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtmaquydoidvt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txttenhangquydoi;
        private System.Windows.Forms.TextBox txtdonvitinhquydoi;
        private System.Windows.Forms.TextBox txtsoluongquydoi;
        private System.Windows.Forms.TextBox txttenhangduocquydoi;
        private System.Windows.Forms.TextBox txtdonvitinhduocquydoi;
        private System.Windows.Forms.TextBox txtsoluongduocquydoi;
        private System.Windows.Forms.TextBox txtmahangduocquydoi;
        private System.Windows.Forms.TextBox txtmahangquydoi;
    }
}