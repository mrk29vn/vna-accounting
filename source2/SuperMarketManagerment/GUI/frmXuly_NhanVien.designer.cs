namespace GUI
{
    partial class frmXuly_NhanVien
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
            this.txtngaycap = new System.Windows.Forms.MaskedTextBox();
            this.tcNhanVien = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtcmnd = new System.Windows.Forms.MaskedTextBox();
            this.txtdtdd = new System.Windows.Forms.MaskedTextBox();
            this.txtdtcd = new System.Windows.Forms.MaskedTextBox();
            this.txtngaysinh = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.cbbmapb = new System.Windows.Forms.ComboBox();
            this.txtnoicap = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtdctamtru = new System.Windows.Forms.TextBox();
            this.txtdcthuongtru = new System.Windows.Forms.TextBox();
            this.txtmanv = new System.Windows.Forms.TextBox();
            this.txttennv = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.tsslThem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSua = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDong = new System.Windows.Forms.ToolStripStatusLabel();
            this.tcNhanVien.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtngaycap
            // 
            this.txtngaycap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtngaycap.Location = new System.Drawing.Point(299, 174);
            this.txtngaycap.Mask = "00/00/0000";
            this.txtngaycap.Name = "txtngaycap";
            this.txtngaycap.Size = new System.Drawing.Size(100, 20);
            this.txtngaycap.TabIndex = 9;
            this.txtngaycap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtngaycap.ValidatingType = typeof(System.DateTime);
            // 
            // tcNhanVien
            // 
            this.tcNhanVien.Controls.Add(this.tabPage1);
            this.tcNhanVien.Controls.Add(this.tabPage2);
            this.tcNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcNhanVien.Location = new System.Drawing.Point(0, 0);
            this.tcNhanVien.Name = "tcNhanVien";
            this.tcNhanVien.SelectedIndex = 0;
            this.tcNhanVien.Size = new System.Drawing.Size(701, 410);
            this.tcNhanVien.TabIndex = 29;
            this.tcNhanVien.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tcNhanVien_DrawItem);
            this.tcNhanVien.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcNhanVien_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtcmnd);
            this.tabPage1.Controls.Add(this.txtdtdd);
            this.tabPage1.Controls.Add(this.txtdtcd);
            this.tabPage1.Controls.Add(this.txtngaycap);
            this.tabPage1.Controls.Add(this.txtngaysinh);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.txtghichu);
            this.tabPage1.Controls.Add(this.cbbmapb);
            this.tabPage1.Controls.Add(this.txtnoicap);
            this.tabPage1.Controls.Add(this.txtemail);
            this.tabPage1.Controls.Add(this.txtdctamtru);
            this.tabPage1.Controls.Add(this.txtdcthuongtru);
            this.tabPage1.Controls.Add(this.txtmanv);
            this.tabPage1.Controls.Add(this.txttennv);
            this.tabPage1.Controls.Add(this.txtID);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(693, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông tin nhân viên";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtcmnd
            // 
            this.txtcmnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcmnd.HidePromptOnLeave = true;
            this.txtcmnd.Location = new System.Drawing.Point(113, 174);
            this.txtcmnd.Mask = "999999999";
            this.txtcmnd.Name = "txtcmnd";
            this.txtcmnd.Size = new System.Drawing.Size(121, 20);
            this.txtcmnd.TabIndex = 8;
            // 
            // txtdtdd
            // 
            this.txtdtdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdtdd.HidePromptOnLeave = true;
            this.txtdtdd.Location = new System.Drawing.Point(113, 230);
            this.txtdtdd.Mask = "99999999999";
            this.txtdtdd.Name = "txtdtdd";
            this.txtdtdd.Size = new System.Drawing.Size(235, 20);
            this.txtdtdd.TabIndex = 12;
            // 
            // txtdtcd
            // 
            this.txtdtcd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdtcd.HidePromptOnLeave = true;
            this.txtdtcd.Location = new System.Drawing.Point(113, 202);
            this.txtdtcd.Mask = "99999999999";
            this.txtdtcd.Name = "txtdtcd";
            this.txtdtcd.Size = new System.Drawing.Size(235, 20);
            this.txtdtcd.TabIndex = 11;
            // 
            // txtngaysinh
            // 
            this.txtngaysinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtngaysinh.Location = new System.Drawing.Point(113, 90);
            this.txtngaysinh.Mask = "00/00/0000";
            this.txtngaysinh.Name = "txtngaysinh";
            this.txtngaysinh.Size = new System.Drawing.Size(100, 20);
            this.txtngaysinh.TabIndex = 4;
            this.txtngaysinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtngaysinh.ValidatingType = typeof(System.DateTime);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label15.Location = new System.Drawing.Point(220, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 14);
            this.label15.TabIndex = 53;
            this.label15.Text = "(dd/mm/yyyy)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(54, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 14);
            this.label14.TabIndex = 51;
            this.label14.Text = "Ngày sinh";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(65, 293);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 50;
            this.label13.Text = "Ghi chú";
            // 
            // txtghichu
            // 
            this.txtghichu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtghichu.Location = new System.Drawing.Point(113, 291);
            this.txtghichu.MaxLength = 100;
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtghichu.Size = new System.Drawing.Size(567, 88);
            this.txtghichu.TabIndex = 14;
            // 
            // cbbmapb
            // 
            this.cbbmapb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbmapb.FormattingEnabled = true;
            this.cbbmapb.Location = new System.Drawing.Point(476, 92);
            this.cbbmapb.Name = "cbbmapb";
            this.cbbmapb.Size = new System.Drawing.Size(204, 22);
            this.cbbmapb.TabIndex = 5;
            // 
            // txtnoicap
            // 
            this.txtnoicap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtnoicap.Location = new System.Drawing.Point(476, 174);
            this.txtnoicap.MaxLength = 100;
            this.txtnoicap.Name = "txtnoicap";
            this.txtnoicap.Size = new System.Drawing.Size(204, 20);
            this.txtnoicap.TabIndex = 10;
            // 
            // txtemail
            // 
            this.txtemail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtemail.Location = new System.Drawing.Point(113, 258);
            this.txtemail.MaxLength = 50;
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(235, 20);
            this.txtemail.TabIndex = 13;
            // 
            // txtdctamtru
            // 
            this.txtdctamtru.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdctamtru.Location = new System.Drawing.Point(113, 146);
            this.txtdctamtru.MaxLength = 200;
            this.txtdctamtru.Name = "txtdctamtru";
            this.txtdctamtru.Size = new System.Drawing.Size(567, 20);
            this.txtdctamtru.TabIndex = 7;
            // 
            // txtdcthuongtru
            // 
            this.txtdcthuongtru.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtdcthuongtru.Location = new System.Drawing.Point(113, 118);
            this.txtdcthuongtru.MaxLength = 200;
            this.txtdcthuongtru.Name = "txtdcthuongtru";
            this.txtdcthuongtru.Size = new System.Drawing.Size(567, 20);
            this.txtdcthuongtru.TabIndex = 6;
            // 
            // txtmanv
            // 
            this.txtmanv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtmanv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmanv.Location = new System.Drawing.Point(113, 38);
            this.txtmanv.Name = "txtmanv";
            this.txtmanv.ReadOnly = true;
            this.txtmanv.Size = new System.Drawing.Size(100, 20);
            this.txtmanv.TabIndex = 2;
            // 
            // txttennv
            // 
            this.txttennv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttennv.Location = new System.Drawing.Point(113, 64);
            this.txttennv.MaxLength = 200;
            this.txttennv.Name = "txttennv";
            this.txttennv.Size = new System.Drawing.Size(235, 20);
            this.txttennv.TabIndex = 3;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Location = new System.Drawing.Point(113, 10);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(67, 20);
            this.txtID.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(427, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 14);
            this.label12.TabIndex = 34;
            this.label12.Text = "Nơi cấp";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(243, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 14);
            this.label11.TabIndex = 33;
            this.label11.Text = "Ngày cấp";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(67, 178);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 14);
            this.label10.TabIndex = 36;
            this.label10.Text = "CMND";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(412, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 14);
            this.label9.TabIndex = 35;
            this.label9.Text = "Phòng Ban";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(70, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 14);
            this.label8.TabIndex = 32;
            this.label8.Text = "Email:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 14);
            this.label7.TabIndex = 31;
            this.label7.Text = "Điện thoại di động";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 14);
            this.label6.TabIndex = 30;
            this.label6.Text = "Điện thoại cố định";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 14);
            this.label5.TabIndex = 29;
            this.label5.Text = "Địa chỉ tạm trú:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 14);
            this.label4.TabIndex = 28;
            this.label4.Text = "Địa chỉ thường trú:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "Tên nhân viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 14);
            this.label2.TabIndex = 26;
            this.label2.Text = "Mã nhân viên:\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "Nhân viên ID:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabPage2.Size = new System.Drawing.Size(693, 383);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Giao Dịch Bán Hàng";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(693, 387);
            this.panel2.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.Size = new System.Drawing.Size(693, 387);
            this.dataGridView1.TabIndex = 0;
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
            this.statusStrip2.Location = new System.Drawing.Point(0, 410);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(701, 26);
            this.statusStrip2.TabIndex = 30;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // tsslThem
            // 
            this.tsslThem.Image = global::GUI.Properties.Resources.Them;
            this.tsslThem.Name = "tsslThem";
            this.tsslThem.Size = new System.Drawing.Size(228, 21);
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
            this.tsslSua.Size = new System.Drawing.Size(228, 21);
            this.tsslSua.Spring = true;
            this.tsslSua.Text = "Sửa";
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
            this.tsslDong.Size = new System.Drawing.Size(228, 21);
            this.tsslDong.Spring = true;
            this.tsslDong.Text = "Trở Về";
            this.tsslDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslDong.Click += new System.EventHandler(this.tsslDong_Click);
            this.tsslDong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslDong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // frmXuly_NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 436);
            this.ControlBox = false;
            this.Controls.Add(this.tcNhanVien);
            this.Controls.Add(this.statusStrip2);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXuly_NhanVien";
            this.Text = "Xử Lý Nhân Viên";
            this.Load += new System.EventHandler(this.frmXuly_NhanVien_Load);
            this.tcNhanVien.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtngaycap;
        private System.Windows.Forms.TabControl tcNhanVien;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.MaskedTextBox txtngaysinh;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.ComboBox cbbmapb;
        private System.Windows.Forms.TextBox txtnoicap;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtdctamtru;
        private System.Windows.Forms.TextBox txtdcthuongtru;
        private System.Windows.Forms.TextBox txtmanv;
        private System.Windows.Forms.TextBox txttennv;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tsslSua;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel tsslDong;
        private System.Windows.Forms.ToolStripStatusLabel tsslThem;
        private System.Windows.Forms.MaskedTextBox txtdtcd;
        private System.Windows.Forms.MaskedTextBox txtcmnd;
        private System.Windows.Forms.MaskedTextBox txtdtdd;
    }
}