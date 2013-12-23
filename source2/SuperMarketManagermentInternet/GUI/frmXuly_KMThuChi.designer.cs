namespace GUI
{
    partial class frmXuly_KMThuChi
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
            this.cbbdoiTuong = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtghichu = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtmaKM = new System.Windows.Forms.TextBox();
            this.txttenKM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbLoaiKhoanMuc = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tsslSua = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslDong = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.tsslThem = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbbdoiTuong
            // 
            this.cbbdoiTuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbdoiTuong.FormattingEnabled = true;
            this.cbbdoiTuong.Items.AddRange(new object[] {
            "Khách Hàng",
            "Nhà Cung Cấp",
            "Nhân Viên"});
            this.cbbdoiTuong.Location = new System.Drawing.Point(102, 148);
            this.cbbdoiTuong.Name = "cbbdoiTuong";
            this.cbbdoiTuong.Size = new System.Drawing.Size(421, 22);
            this.cbbdoiTuong.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 194);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 50;
            this.label13.Text = "Ghi chú";
            // 
            // txtghichu
            // 
            this.txtghichu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtghichu.Location = new System.Drawing.Point(103, 192);
            this.txtghichu.MaxLength = 100;
            this.txtghichu.Multiline = true;
            this.txtghichu.Name = "txtghichu";
            this.txtghichu.Size = new System.Drawing.Size(422, 83);
            this.txtghichu.TabIndex = 7;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Location = new System.Drawing.Point(104, 5);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(421, 20);
            this.txtID.TabIndex = 100;
            this.txtID.Text = "0";
            this.txtID.Visible = false;
            // 
            // txtmaKM
            // 
            this.txtmaKM.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtmaKM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtmaKM.Location = new System.Drawing.Point(102, 36);
            this.txtmaKM.Name = "txtmaKM";
            this.txtmaKM.ReadOnly = true;
            this.txtmaKM.Size = new System.Drawing.Size(421, 20);
            this.txtmaKM.TabIndex = 1;
            // 
            // txttenKM
            // 
            this.txttenKM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttenKM.Location = new System.Drawing.Point(102, 69);
            this.txttenKM.MaxLength = 200;
            this.txttenKM.Name = "txttenKM";
            this.txttenKM.Size = new System.Drawing.Size(421, 20);
            this.txttenKM.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 14);
            this.label4.TabIndex = 26;
            this.label4.Text = "Đối Tượng";
            // 
            // cbbLoaiKhoanMuc
            // 
            this.cbbLoaiKhoanMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLoaiKhoanMuc.FormattingEnabled = true;
            this.cbbLoaiKhoanMuc.Items.AddRange(new object[] {
            "Khoản Mục  Thu",
            "Khoản Mục  Chi"});
            this.cbbLoaiKhoanMuc.Location = new System.Drawing.Point(102, 108);
            this.cbbLoaiKhoanMuc.Name = "cbbLoaiKhoanMuc";
            this.cbbLoaiKhoanMuc.Size = new System.Drawing.Size(421, 22);
            this.cbbLoaiKhoanMuc.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 27;
            this.label7.Text = "Loại KM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 14);
            this.label1.TabIndex = 26;
            this.label1.Text = "Khoản mục ID";
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "Tên Khoản Mục";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 26;
            this.label2.Text = "Mã Khoản Mục";
            // 
            // tsslSua
            // 
            this.tsslSua.Image = global::GUI.Properties.Resources.Sua;
            this.tsslSua.Name = "tsslSua";
            this.tsslSua.Size = new System.Drawing.Size(172, 21);
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
            this.tsslDong.Size = new System.Drawing.Size(172, 21);
            this.tsslDong.Spring = true;
            this.tsslDong.Text = "Trở về";
            this.tsslDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslDong.Click += new System.EventHandler(this.tsslDong_Click);
            this.tsslDong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslDong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
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
            this.statusStrip2.Location = new System.Drawing.Point(0, 280);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(533, 26);
            this.statusStrip2.TabIndex = 32;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // tsslThem
            // 
            this.tsslThem.Image = global::GUI.Properties.Resources.Them;
            this.tsslThem.Name = "tsslThem";
            this.tsslThem.Size = new System.Drawing.Size(172, 21);
            this.tsslThem.Spring = true;
            this.tsslThem.Text = "Thêm";
            this.tsslThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslThem.Click += new System.EventHandler(this.tsslThem_Click);
            this.tsslThem.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslThem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // frmXuly_KMThuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(533, 306);
            this.ControlBox = false;
            this.Controls.Add(this.cbbLoaiKhoanMuc);
            this.Controls.Add(this.cbbdoiTuong);
            this.Controls.Add(this.statusStrip2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtghichu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtmaKM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txttenKM);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXuly_KMThuChi";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xử Lý Khoản Mục Thu Chi";
            this.Load += new System.EventHandler(this.frmXuly_KMThuChi_Load);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbdoiTuong;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtghichu;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtmaKM;
        private System.Windows.Forms.TextBox txttenKM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel tsslSua;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel tsslDong;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripStatusLabel tsslThem;
        private System.Windows.Forms.ComboBox cbbLoaiKhoanMuc;

    }
}