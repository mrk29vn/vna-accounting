namespace GUI
{
    partial class frmXuLyKhoHang
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
            this.panelBottom = new System.Windows.Forms.Panel();
            this.statusStrip_Menu = new System.Windows.Forms.StatusStrip();
            this.tssThem = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSua = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssDong = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl_Cha = new System.Windows.Forms.TabControl();
            this.tabPage_Khohang = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupThongtinthemmoikho = new System.Windows.Forms.GroupBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.cbxMaNhanVien = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenKho = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaKho = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage_Hanghoa = new System.Windows.Forms.TabPage();
            this.groupThongtinhanghoatrongkho = new System.Windows.Forms.GroupBox();
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.panelBottom.SuspendLayout();
            this.statusStrip_Menu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl_Cha.SuspendLayout();
            this.tabPage_Khohang.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupThongtinthemmoikho.SuspendLayout();
            this.tabPage_Hanghoa.SuspendLayout();
            this.groupThongtinhanghoatrongkho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.statusStrip_Menu);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 245);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(524, 26);
            this.panelBottom.TabIndex = 2;
            // 
            // statusStrip_Menu
            // 
            this.statusStrip_Menu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip_Menu.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssThem,
            this.tssSua,
            this.tssDong});
            this.statusStrip_Menu.Location = new System.Drawing.Point(0, 0);
            this.statusStrip_Menu.Name = "statusStrip_Menu";
            this.statusStrip_Menu.Size = new System.Drawing.Size(524, 26);
            this.statusStrip_Menu.TabIndex = 9;
            // 
            // tssThem
            // 
            this.tssThem.Image = global::GUI.Properties.Resources.Them;
            this.tssThem.Name = "tssThem";
            this.tssThem.Size = new System.Drawing.Size(159, 21);
            this.tssThem.Spring = true;
            this.tssThem.Text = "Thêm";
            this.tssThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssThem.Click += new System.EventHandler(this.tssThem_Click_1);
            this.tssThem.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssThem.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssSua
            // 
            this.tssSua.Image = global::GUI.Properties.Resources.Sua;
            this.tssSua.Name = "tssSua";
            this.tssSua.Size = new System.Drawing.Size(159, 21);
            this.tssSua.Spring = true;
            this.tssSua.Text = "Sửa";
            this.tssSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssSua.Click += new System.EventHandler(this.tssSua_Click_1);
            this.tssSua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssSua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssDong
            // 
            this.tssDong.Image = global::GUI.Properties.Resources.Tro_ve;
            this.tssDong.Name = "tssDong";
            this.tssDong.Size = new System.Drawing.Size(159, 21);
            this.tssDong.Spring = true;
            this.tssDong.Text = "Trở Về";
            this.tssDong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssDong.Click += new System.EventHandler(this.tssDong_Click);
            this.tssDong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssDong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl_Cha);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(524, 245);
            this.panel2.TabIndex = 3;
            // 
            // tabControl_Cha
            // 
            this.tabControl_Cha.Controls.Add(this.tabPage_Khohang);
            this.tabControl_Cha.Controls.Add(this.tabPage_Hanghoa);
            this.tabControl_Cha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_Cha.Location = new System.Drawing.Point(0, 0);
            this.tabControl_Cha.Name = "tabControl_Cha";
            this.tabControl_Cha.SelectedIndex = 0;
            this.tabControl_Cha.Size = new System.Drawing.Size(524, 245);
            this.tabControl_Cha.TabIndex = 2;
            this.tabControl_Cha.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl_Cha_Selecting);
            // 
            // tabPage_Khohang
            // 
            this.tabPage_Khohang.Controls.Add(this.panel1);
            this.tabPage_Khohang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage_Khohang.Location = new System.Drawing.Point(4, 23);
            this.tabPage_Khohang.Name = "tabPage_Khohang";
            this.tabPage_Khohang.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Khohang.Size = new System.Drawing.Size(516, 218);
            this.tabPage_Khohang.TabIndex = 0;
            this.tabPage_Khohang.Text = "Thêm mới kho";
            this.tabPage_Khohang.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupThongtinthemmoikho);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 212);
            this.panel1.TabIndex = 1;
            // 
            // groupThongtinthemmoikho
            // 
            this.groupThongtinthemmoikho.Controls.Add(this.txtSoDienThoai);
            this.groupThongtinthemmoikho.Controls.Add(this.txtDiaChi);
            this.groupThongtinthemmoikho.Controls.Add(this.cbxMaNhanVien);
            this.groupThongtinthemmoikho.Controls.Add(this.label5);
            this.groupThongtinthemmoikho.Controls.Add(this.label6);
            this.groupThongtinthemmoikho.Controls.Add(this.txtTenKho);
            this.groupThongtinthemmoikho.Controls.Add(this.txtGhiChu);
            this.groupThongtinthemmoikho.Controls.Add(this.label4);
            this.groupThongtinthemmoikho.Controls.Add(this.label7);
            this.groupThongtinthemmoikho.Controls.Add(this.txtMaKho);
            this.groupThongtinthemmoikho.Controls.Add(this.label1);
            this.groupThongtinthemmoikho.Controls.Add(this.label3);
            this.groupThongtinthemmoikho.Controls.Add(this.label8);
            this.groupThongtinthemmoikho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupThongtinthemmoikho.Location = new System.Drawing.Point(0, 0);
            this.groupThongtinthemmoikho.Name = "groupThongtinthemmoikho";
            this.groupThongtinthemmoikho.Size = new System.Drawing.Size(510, 212);
            this.groupThongtinthemmoikho.TabIndex = 17;
            this.groupThongtinthemmoikho.TabStop = false;
            this.groupThongtinthemmoikho.Text = "Thông tin tạo mới kho hàng";
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoDienThoai.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDienThoai.Location = new System.Drawing.Point(90, 75);
            this.txtSoDienThoai.MaxLength = 20;
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(360, 20);
            this.txtSoDienThoai.TabIndex = 2;
            this.txtSoDienThoai.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoDienThoai_KeyPress);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiaChi.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(90, 132);
            this.txtDiaChi.MaxLength = 200;
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(360, 20);
            this.txtDiaChi.TabIndex = 4;
            // 
            // cbxMaNhanVien
            // 
            this.cbxMaNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMaNhanVien.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMaNhanVien.FormattingEnabled = true;
            this.cbxMaNhanVien.Location = new System.Drawing.Point(90, 103);
            this.cbxMaNhanVien.Name = "cbxMaNhanVien";
            this.cbxMaNhanVien.Size = new System.Drawing.Size(360, 22);
            this.cbxMaNhanVien.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Địa chỉ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "Số điện thoại:";
            // 
            // txtTenKho
            // 
            this.txtTenKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTenKho.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKho.Location = new System.Drawing.Point(90, 47);
            this.txtTenKho.MaxLength = 200;
            this.txtTenKho.Name = "txtTenKho";
            this.txtTenKho.Size = new System.Drawing.Size(360, 20);
            this.txtTenKho.TabIndex = 1;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGhiChu.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(90, 160);
            this.txtGhiChu.MaxLength = 200;
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGhiChu.Size = new System.Drawing.Size(360, 51);
            this.txtGhiChu.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên kho:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 14);
            this.label7.TabIndex = 10;
            this.label7.Text = "Thủ kho:";
            // 
            // txtMaKho
            // 
            this.txtMaKho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMaKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaKho.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKho.Location = new System.Drawing.Point(90, 19);
            this.txtMaKho.MaxLength = 20;
            this.txtMaKho.Name = "txtMaKho";
            this.txtMaKho.ReadOnly = true;
            this.txtMaKho.Size = new System.Drawing.Size(149, 20);
            this.txtMaKho.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã kho:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã kho:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(39, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 14);
            this.label8.TabIndex = 12;
            this.label8.Text = "Ghi chú:";
            // 
            // tabPage_Hanghoa
            // 
            this.tabPage_Hanghoa.Controls.Add(this.groupThongtinhanghoatrongkho);
            this.tabPage_Hanghoa.Location = new System.Drawing.Point(4, 23);
            this.tabPage_Hanghoa.Name = "tabPage_Hanghoa";
            this.tabPage_Hanghoa.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Hanghoa.Size = new System.Drawing.Size(520, 222);
            this.tabPage_Hanghoa.TabIndex = 1;
            this.tabPage_Hanghoa.Text = "Hàng hóa trong kho";
            this.tabPage_Hanghoa.UseVisualStyleBackColor = true;
            // 
            // groupThongtinhanghoatrongkho
            // 
            this.groupThongtinhanghoatrongkho.Controls.Add(this.dgvHangHoa);
            this.groupThongtinhanghoatrongkho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupThongtinhanghoatrongkho.Location = new System.Drawing.Point(3, 3);
            this.groupThongtinhanghoatrongkho.Name = "groupThongtinhanghoatrongkho";
            this.groupThongtinhanghoatrongkho.Size = new System.Drawing.Size(514, 216);
            this.groupThongtinhanghoatrongkho.TabIndex = 1;
            this.groupThongtinhanghoatrongkho.TabStop = false;
            this.groupThongtinhanghoatrongkho.Text = "Tìm được 0 bản ghi";
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.AllowUserToAddRows = false;
            this.dgvHangHoa.AllowUserToDeleteRows = false;
            this.dgvHangHoa.BackgroundColor = System.Drawing.Color.White;
            this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHangHoa.Location = new System.Drawing.Point(3, 16);
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.ReadOnly = true;
            this.dgvHangHoa.RowHeadersVisible = false;
            this.dgvHangHoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHangHoa.Size = new System.Drawing.Size(508, 197);
            this.dgvHangHoa.TabIndex = 4;
            // 
            // frmXuLyKhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 271);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelBottom);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXuLyKhoHang";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmXuLyKhoHang_Load);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.statusStrip_Menu.ResumeLayout(false);
            this.statusStrip_Menu.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl_Cha.ResumeLayout(false);
            this.tabPage_Khohang.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupThongtinthemmoikho.ResumeLayout(false);
            this.groupThongtinthemmoikho.PerformLayout();
            this.tabPage_Hanghoa.ResumeLayout(false);
            this.groupThongtinhanghoatrongkho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.StatusStrip statusStrip_Menu;
        private System.Windows.Forms.ToolStripStatusLabel tssThem;
        private System.Windows.Forms.ToolStripStatusLabel tssSua;
        private System.Windows.Forms.ToolStripStatusLabel tssDong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl_Cha;
        private System.Windows.Forms.TabPage tabPage_Khohang;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupThongtinthemmoikho;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.ComboBox cbxMaNhanVien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTenKho;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaKho;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage_Hanghoa;
        private System.Windows.Forms.GroupBox groupThongtinhanghoatrongkho;
        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.Label label1;


    }
}