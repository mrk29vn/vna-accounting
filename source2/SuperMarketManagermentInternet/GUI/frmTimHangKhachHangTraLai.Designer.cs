namespace GUI
{
    partial class frmTimHangKhachHangTraLai
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
            this.palTrencung = new System.Windows.Forms.Panel();
            this.lbllocthongtin = new System.Windows.Forms.Label();
            this.statusStrip_Duoi = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus_Chapnhan = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatus_Huybo = new System.Windows.Forms.ToolStripStatusLabel();
            this.palGiua = new System.Windows.Forms.Panel();
            this.cbxKethop_3 = new System.Windows.Forms.ComboBox();
            this.cbxKethop_2 = new System.Windows.Forms.ComboBox();
            this.cbxKethop_1 = new System.Windows.Forms.ComboBox();
            this.txtGiatri_4 = new System.Windows.Forms.TextBox();
            this.txtGiatri_3 = new System.Windows.Forms.TextBox();
            this.txtGiatri_2 = new System.Windows.Forms.TextBox();
            this.txtGiatri_1 = new System.Windows.Forms.TextBox();
            this.cbxSosanh_4 = new System.Windows.Forms.ComboBox();
            this.cbxSosanh_3 = new System.Windows.Forms.ComboBox();
            this.cbxSosanh_2 = new System.Windows.Forms.ComboBox();
            this.cbxSosanh_1 = new System.Windows.Forms.ComboBox();
            this.cbxThongtin_4 = new System.Windows.Forms.ComboBox();
            this.cbxThongtin_3 = new System.Windows.Forms.ComboBox();
            this.cbxThongtin_2 = new System.Windows.Forms.ComboBox();
            this.cbxThongtin_1 = new System.Windows.Forms.ComboBox();
            this.lblKethop = new System.Windows.Forms.Label();
            this.lblGiatritim = new System.Windows.Forms.Label();
            this.lblToantusosanh = new System.Windows.Forms.Label();
            this.lblThongtin = new System.Windows.Forms.Label();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.palTrencung.SuspendLayout();
            this.statusStrip_Duoi.SuspendLayout();
            this.palGiua.SuspendLayout();
            this.SuspendLayout();
            // 
            // palTrencung
            // 
            this.palTrencung.BackColor = System.Drawing.Color.Silver;
            this.palTrencung.Controls.Add(this.lbllocthongtin);
            this.palTrencung.Dock = System.Windows.Forms.DockStyle.Top;
            this.palTrencung.Location = new System.Drawing.Point(0, 0);
            this.palTrencung.Name = "palTrencung";
            this.palTrencung.Size = new System.Drawing.Size(667, 34);
            this.palTrencung.TabIndex = 0;
            // 
            // lbllocthongtin
            // 
            this.lbllocthongtin.AutoSize = true;
            this.lbllocthongtin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllocthongtin.ForeColor = System.Drawing.Color.White;
            this.lbllocthongtin.Location = new System.Drawing.Point(12, 9);
            this.lbllocthongtin.Name = "lbllocthongtin";
            this.lbllocthongtin.Size = new System.Drawing.Size(137, 16);
            this.lbllocthongtin.TabIndex = 0;
            this.lbllocthongtin.Text = "Lọc thông tin đặt hàng";
            // 
            // statusStrip_Duoi
            // 
            this.statusStrip_Duoi.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip_Duoi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus_Chapnhan,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel1,
            this.toolStripStatus_Huybo});
            this.statusStrip_Duoi.Location = new System.Drawing.Point(0, 190);
            this.statusStrip_Duoi.Name = "statusStrip_Duoi";
            this.statusStrip_Duoi.Size = new System.Drawing.Size(667, 22);
            this.statusStrip_Duoi.TabIndex = 1;
            this.statusStrip_Duoi.Text = "statusStrip1";
            // 
            // toolStripStatus_Chapnhan
            // 
            this.toolStripStatus_Chapnhan.Name = "toolStripStatus_Chapnhan";
            this.toolStripStatus_Chapnhan.Size = new System.Drawing.Size(163, 17);
            this.toolStripStatus_Chapnhan.Spring = true;
            this.toolStripStatus_Chapnhan.Text = "Chấp nhận";
            this.toolStripStatus_Chapnhan.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Chapnhan.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatus_Huybo
            // 
            this.toolStripStatus_Huybo.Name = "toolStripStatus_Huybo";
            this.toolStripStatus_Huybo.Size = new System.Drawing.Size(163, 17);
            this.toolStripStatus_Huybo.Spring = true;
            this.toolStripStatus_Huybo.Text = "Hủy bỏ";
            this.toolStripStatus_Huybo.Click += new System.EventHandler(this.toolStripStatus_Huybo_Click);
            this.toolStripStatus_Huybo.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatus_Huybo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // palGiua
            // 
            this.palGiua.Controls.Add(this.cbxKethop_3);
            this.palGiua.Controls.Add(this.cbxKethop_2);
            this.palGiua.Controls.Add(this.cbxKethop_1);
            this.palGiua.Controls.Add(this.txtGiatri_4);
            this.palGiua.Controls.Add(this.txtGiatri_3);
            this.palGiua.Controls.Add(this.txtGiatri_2);
            this.palGiua.Controls.Add(this.txtGiatri_1);
            this.palGiua.Controls.Add(this.cbxSosanh_4);
            this.palGiua.Controls.Add(this.cbxSosanh_3);
            this.palGiua.Controls.Add(this.cbxSosanh_2);
            this.palGiua.Controls.Add(this.cbxSosanh_1);
            this.palGiua.Controls.Add(this.cbxThongtin_4);
            this.palGiua.Controls.Add(this.cbxThongtin_3);
            this.palGiua.Controls.Add(this.cbxThongtin_2);
            this.palGiua.Controls.Add(this.cbxThongtin_1);
            this.palGiua.Controls.Add(this.lblKethop);
            this.palGiua.Controls.Add(this.lblGiatritim);
            this.palGiua.Controls.Add(this.lblToantusosanh);
            this.palGiua.Controls.Add(this.lblThongtin);
            this.palGiua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palGiua.Location = new System.Drawing.Point(0, 34);
            this.palGiua.Name = "palGiua";
            this.palGiua.Size = new System.Drawing.Size(667, 156);
            this.palGiua.TabIndex = 2;
            // 
            // cbxKethop_3
            // 
            this.cbxKethop_3.FormattingEnabled = true;
            this.cbxKethop_3.Location = new System.Drawing.Point(545, 93);
            this.cbxKethop_3.Name = "cbxKethop_3";
            this.cbxKethop_3.Size = new System.Drawing.Size(101, 21);
            this.cbxKethop_3.TabIndex = 18;
            // 
            // cbxKethop_2
            // 
            this.cbxKethop_2.FormattingEnabled = true;
            this.cbxKethop_2.Location = new System.Drawing.Point(545, 68);
            this.cbxKethop_2.Name = "cbxKethop_2";
            this.cbxKethop_2.Size = new System.Drawing.Size(101, 21);
            this.cbxKethop_2.TabIndex = 17;
            // 
            // cbxKethop_1
            // 
            this.cbxKethop_1.FormattingEnabled = true;
            this.cbxKethop_1.Location = new System.Drawing.Point(545, 40);
            this.cbxKethop_1.Name = "cbxKethop_1";
            this.cbxKethop_1.Size = new System.Drawing.Size(101, 21);
            this.cbxKethop_1.TabIndex = 16;
            // 
            // txtGiatri_4
            // 
            this.txtGiatri_4.Location = new System.Drawing.Point(343, 120);
            this.txtGiatri_4.Name = "txtGiatri_4";
            this.txtGiatri_4.Size = new System.Drawing.Size(193, 20);
            this.txtGiatri_4.TabIndex = 15;
            // 
            // txtGiatri_3
            // 
            this.txtGiatri_3.Location = new System.Drawing.Point(343, 94);
            this.txtGiatri_3.Name = "txtGiatri_3";
            this.txtGiatri_3.Size = new System.Drawing.Size(193, 20);
            this.txtGiatri_3.TabIndex = 14;
            // 
            // txtGiatri_2
            // 
            this.txtGiatri_2.Location = new System.Drawing.Point(344, 68);
            this.txtGiatri_2.Name = "txtGiatri_2";
            this.txtGiatri_2.Size = new System.Drawing.Size(193, 20);
            this.txtGiatri_2.TabIndex = 13;
            // 
            // txtGiatri_1
            // 
            this.txtGiatri_1.Location = new System.Drawing.Point(344, 40);
            this.txtGiatri_1.Name = "txtGiatri_1";
            this.txtGiatri_1.Size = new System.Drawing.Size(193, 20);
            this.txtGiatri_1.TabIndex = 12;
            // 
            // cbxSosanh_4
            // 
            this.cbxSosanh_4.FormattingEnabled = true;
            this.cbxSosanh_4.Location = new System.Drawing.Point(184, 121);
            this.cbxSosanh_4.Name = "cbxSosanh_4";
            this.cbxSosanh_4.Size = new System.Drawing.Size(153, 21);
            this.cbxSosanh_4.TabIndex = 11;
            // 
            // cbxSosanh_3
            // 
            this.cbxSosanh_3.FormattingEnabled = true;
            this.cbxSosanh_3.Location = new System.Drawing.Point(184, 94);
            this.cbxSosanh_3.Name = "cbxSosanh_3";
            this.cbxSosanh_3.Size = new System.Drawing.Size(153, 21);
            this.cbxSosanh_3.TabIndex = 10;
            // 
            // cbxSosanh_2
            // 
            this.cbxSosanh_2.FormattingEnabled = true;
            this.cbxSosanh_2.Location = new System.Drawing.Point(184, 67);
            this.cbxSosanh_2.Name = "cbxSosanh_2";
            this.cbxSosanh_2.Size = new System.Drawing.Size(153, 21);
            this.cbxSosanh_2.TabIndex = 9;
            // 
            // cbxSosanh_1
            // 
            this.cbxSosanh_1.FormattingEnabled = true;
            this.cbxSosanh_1.Location = new System.Drawing.Point(184, 40);
            this.cbxSosanh_1.Name = "cbxSosanh_1";
            this.cbxSosanh_1.Size = new System.Drawing.Size(153, 21);
            this.cbxSosanh_1.TabIndex = 8;
            // 
            // cbxThongtin_4
            // 
            this.cbxThongtin_4.FormattingEnabled = true;
            this.cbxThongtin_4.Location = new System.Drawing.Point(25, 121);
            this.cbxThongtin_4.Name = "cbxThongtin_4";
            this.cbxThongtin_4.Size = new System.Drawing.Size(153, 21);
            this.cbxThongtin_4.TabIndex = 7;
            // 
            // cbxThongtin_3
            // 
            this.cbxThongtin_3.FormattingEnabled = true;
            this.cbxThongtin_3.Location = new System.Drawing.Point(25, 94);
            this.cbxThongtin_3.Name = "cbxThongtin_3";
            this.cbxThongtin_3.Size = new System.Drawing.Size(153, 21);
            this.cbxThongtin_3.TabIndex = 6;
            // 
            // cbxThongtin_2
            // 
            this.cbxThongtin_2.FormattingEnabled = true;
            this.cbxThongtin_2.Location = new System.Drawing.Point(25, 67);
            this.cbxThongtin_2.Name = "cbxThongtin_2";
            this.cbxThongtin_2.Size = new System.Drawing.Size(153, 21);
            this.cbxThongtin_2.TabIndex = 5;
            // 
            // cbxThongtin_1
            // 
            this.cbxThongtin_1.FormattingEnabled = true;
            this.cbxThongtin_1.Location = new System.Drawing.Point(25, 40);
            this.cbxThongtin_1.Name = "cbxThongtin_1";
            this.cbxThongtin_1.Size = new System.Drawing.Size(153, 21);
            this.cbxThongtin_1.TabIndex = 4;
            // 
            // lblKethop
            // 
            this.lblKethop.AutoSize = true;
            this.lblKethop.Location = new System.Drawing.Point(542, 17);
            this.lblKethop.Name = "lblKethop";
            this.lblKethop.Size = new System.Drawing.Size(47, 13);
            this.lblKethop.TabIndex = 3;
            this.lblKethop.Text = "Kết hợp:";
            // 
            // lblGiatritim
            // 
            this.lblGiatritim.AutoSize = true;
            this.lblGiatritim.Location = new System.Drawing.Point(341, 17);
            this.lblGiatritim.Name = "lblGiatritim";
            this.lblGiatritim.Size = new System.Drawing.Size(74, 13);
            this.lblGiatritim.TabIndex = 2;
            this.lblGiatritim.Text = "Giá trị cần tìm:";
            // 
            // lblToantusosanh
            // 
            this.lblToantusosanh.AutoSize = true;
            this.lblToantusosanh.Location = new System.Drawing.Point(181, 17);
            this.lblToantusosanh.Name = "lblToantusosanh";
            this.lblToantusosanh.Size = new System.Drawing.Size(87, 13);
            this.lblToantusosanh.TabIndex = 1;
            this.lblToantusosanh.Text = "Toán tử so sánh:";
            // 
            // lblThongtin
            // 
            this.lblThongtin.AutoSize = true;
            this.lblThongtin.Location = new System.Drawing.Point(22, 17);
            this.lblThongtin.Name = "lblThongtin";
            this.lblThongtin.Size = new System.Drawing.Size(55, 13);
            this.lblThongtin.TabIndex = 0;
            this.lblThongtin.Text = "Thông tin:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(163, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Chấp nhận";
            this.toolStripStatusLabel1.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(163, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "Hủy bỏ";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatus_Huybo_Click);
            this.toolStripStatusLabel2.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // frmTimHangKhachHangTraLai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 212);
            this.ControlBox = false;
            this.Controls.Add(this.palGiua);
            this.Controls.Add(this.statusStrip_Duoi);
            this.Controls.Add(this.palTrencung);
            this.Name = "frmTimHangKhachHangTraLai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lọc thông tin hàng trả lại";
            this.palTrencung.ResumeLayout(false);
            this.palTrencung.PerformLayout();
            this.statusStrip_Duoi.ResumeLayout(false);
            this.statusStrip_Duoi.PerformLayout();
            this.palGiua.ResumeLayout(false);
            this.palGiua.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel palTrencung;
        private System.Windows.Forms.StatusStrip statusStrip_Duoi;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Chapnhan;
        private System.Windows.Forms.Panel palGiua;
        private System.Windows.Forms.Label lbllocthongtin;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Huybo;
        private System.Windows.Forms.ComboBox cbxKethop_3;
        private System.Windows.Forms.ComboBox cbxKethop_2;
        private System.Windows.Forms.ComboBox cbxKethop_1;
        private System.Windows.Forms.TextBox txtGiatri_4;
        private System.Windows.Forms.TextBox txtGiatri_3;
        private System.Windows.Forms.TextBox txtGiatri_2;
        private System.Windows.Forms.TextBox txtGiatri_1;
        private System.Windows.Forms.ComboBox cbxSosanh_4;
        private System.Windows.Forms.ComboBox cbxSosanh_3;
        private System.Windows.Forms.ComboBox cbxSosanh_2;
        private System.Windows.Forms.ComboBox cbxSosanh_1;
        private System.Windows.Forms.ComboBox cbxThongtin_4;
        private System.Windows.Forms.ComboBox cbxThongtin_3;
        private System.Windows.Forms.ComboBox cbxThongtin_2;
        private System.Windows.Forms.ComboBox cbxThongtin_1;
        private System.Windows.Forms.Label lblKethop;
        private System.Windows.Forms.Label lblGiatritim;
        private System.Windows.Forms.Label lblToantusosanh;
        private System.Windows.Forms.Label lblThongtin;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}