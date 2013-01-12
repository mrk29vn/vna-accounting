namespace GUI
{
    partial class frmXuLy_DieuChuyenKhoNoiBo
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
            this.palXem = new System.Windows.Forms.Panel();
            this.grbDataGridview = new System.Windows.Forms.GroupBox();
            this.dgvInsertOrder = new System.Windows.Forms.DataGridView();
            this.palThem = new System.Windows.Forms.Panel();
            this.toolStrip_Insert = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_txtTracuu = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_txtTen = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip_txtSoluong = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip_btnThem = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslthemmoi = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSua = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSochungtu = new System.Windows.Forms.Label();
            this.txtSochungtu = new System.Windows.Forms.TextBox();
            this.lblNgaychungtu = new System.Windows.Forms.Label();
            this.makNgaychungtu = new System.Windows.Forms.MaskedTextBox();
            this.lblDinhdangngay = new System.Windows.Forms.LinkLabel();
            this.lblKhohang = new System.Windows.Forms.Label();
            this.cbxTukho = new System.Windows.Forms.ComboBox();
            this.txtDiengiai = new System.Windows.Forms.TextBox();
            this.lblDiengiai = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDenkho = new System.Windows.Forms.ComboBox();
            this.check_Xacnhan = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxTaikhoan = new System.Windows.Forms.Panel();
            this.palXem.SuspendLayout();
            this.grbDataGridview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsertOrder)).BeginInit();
            this.palThem.SuspendLayout();
            this.toolStrip_Insert.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.cbxTaikhoan.SuspendLayout();
            this.SuspendLayout();
            // 
            // palXem
            // 
            this.palXem.Controls.Add(this.grbDataGridview);
            this.palXem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.palXem.Location = new System.Drawing.Point(0, 130);
            this.palXem.Name = "palXem";
            this.palXem.Size = new System.Drawing.Size(758, 316);
            this.palXem.TabIndex = 2;
            // 
            // grbDataGridview
            // 
            this.grbDataGridview.Controls.Add(this.dgvInsertOrder);
            this.grbDataGridview.Controls.Add(this.palThem);
            this.grbDataGridview.Dock = System.Windows.Forms.DockStyle.Top;
            this.grbDataGridview.Location = new System.Drawing.Point(0, 0);
            this.grbDataGridview.Name = "grbDataGridview";
            this.grbDataGridview.Size = new System.Drawing.Size(758, 235);
            this.grbDataGridview.TabIndex = 0;
            this.grbDataGridview.TabStop = false;
            // 
            // dgvInsertOrder
            // 
            this.dgvInsertOrder.BackgroundColor = System.Drawing.Color.White;
            this.dgvInsertOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInsertOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInsertOrder.Location = new System.Drawing.Point(3, 44);
            this.dgvInsertOrder.Name = "dgvInsertOrder";
            this.dgvInsertOrder.Size = new System.Drawing.Size(752, 188);
            this.dgvInsertOrder.TabIndex = 0;
            this.dgvInsertOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInsertOrder_CellDoubleClick);
            // 
            // palThem
            // 
            this.palThem.Controls.Add(this.toolStrip_Insert);
            this.palThem.Dock = System.Windows.Forms.DockStyle.Top;
            this.palThem.Location = new System.Drawing.Point(3, 16);
            this.palThem.Name = "palThem";
            this.palThem.Size = new System.Drawing.Size(752, 28);
            this.palThem.TabIndex = 3;
            // 
            // toolStrip_Insert
            // 
            this.toolStrip_Insert.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_Insert.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStrip_txtTracuu,
            this.toolStripLabel1,
            this.toolStrip_txtTen,
            this.toolStripLabel2,
            this.toolStrip_txtSoluong,
            this.toolStrip_btnThem});
            this.toolStrip_Insert.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Insert.Name = "toolStrip_Insert";
            this.toolStrip_Insert.Size = new System.Drawing.Size(752, 25);
            this.toolStrip_Insert.TabIndex = 2;
            this.toolStrip_Insert.Text = "toolStrip1";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(87, 22);
            this.toolStripLabel3.Text = "Mã Hàng Hóa: ";
            // 
            // toolStrip_txtTracuu
            // 
            this.toolStrip_txtTracuu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip_txtTracuu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtTracuu.Name = "toolStrip_txtTracuu";
            this.toolStrip_txtTracuu.Size = new System.Drawing.Size(100, 25);
            this.toolStrip_txtTracuu.Text = "<F4-Tra cứu>";
            this.toolStrip_txtTracuu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStrip_txtTracuu_KeyDown);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(90, 22);
            this.toolStripLabel1.Text = "Tên Hàng Hóa: ";
            // 
            // toolStrip_txtTen
            // 
            this.toolStrip_txtTen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStrip_txtTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtTen.Name = "toolStrip_txtTen";
            this.toolStrip_txtTen.ReadOnly = true;
            this.toolStrip_txtTen.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(63, 22);
            this.toolStripLabel2.Text = "Số Lượng: ";
            // 
            // toolStrip_txtSoluong
            // 
            this.toolStrip_txtSoluong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStrip_txtSoluong.MaxLength = 5;
            this.toolStrip_txtSoluong.Name = "toolStrip_txtSoluong";
            this.toolStrip_txtSoluong.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip_txtSoluong.Size = new System.Drawing.Size(60, 25);
            this.toolStrip_txtSoluong.Text = "1";
            this.toolStrip_txtSoluong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStrip_txtSoluong_KeyPress);
            this.toolStrip_txtSoluong.TextChanged += new System.EventHandler(this.toolStrip_txtSoluong_TextChanged);
            // 
            // toolStrip_btnThem
            // 
            this.toolStrip_btnThem.Image = global::GUI.Properties.Resources.Them;
            this.toolStrip_btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_btnThem.Name = "toolStrip_btnThem";
            this.toolStrip_btnThem.Size = new System.Drawing.Size(58, 22);
            this.toolStrip_btnThem.Text = "Thêm";
            this.toolStrip_btnThem.Click += new System.EventHandler(this.toolStrip_btnThem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslthemmoi,
            this.tssSua,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 446);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(758, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslthemmoi
            // 
            this.tsslthemmoi.Image = global::GUI.Properties.Resources.Them;
            this.tsslthemmoi.Name = "tsslthemmoi";
            this.tsslthemmoi.Size = new System.Drawing.Size(185, 21);
            this.tsslthemmoi.Spring = true;
            this.tsslthemmoi.Text = "Thêm";
            this.tsslthemmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslthemmoi.Click += new System.EventHandler(this.tsslthemmoi_Click);
            this.tsslthemmoi.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslthemmoi.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssSua
            // 
            this.tssSua.Image = global::GUI.Properties.Resources.Sua;
            this.tssSua.Name = "tssSua";
            this.tssSua.Size = new System.Drawing.Size(185, 21);
            this.tssSua.Spring = true;
            this.tssSua.Text = "Sửa";
            this.tssSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssSua.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            this.tssSua.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssSua.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Image = global::GUI.Properties.Resources.In;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(185, 21);
            this.toolStripStatusLabel3.Spring = true;
            this.toolStripStatusLabel3.Text = "In";
            this.toolStripStatusLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel3.Click += new System.EventHandler(this.toolStripStatusLabel3_Click);
            this.toolStripStatusLabel3.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Image = global::GUI.Properties.Resources.Tro_ve;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(185, 21);
            this.toolStripStatusLabel4.Spring = true;
            this.toolStripStatusLabel4.Text = "Trở Về";
            this.toolStripStatusLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel4.Click += new System.EventHandler(this.toolStripStatusLabel4_Click);
            this.toolStripStatusLabel4.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // lblSochungtu
            // 
            this.lblSochungtu.AutoSize = true;
            this.lblSochungtu.Location = new System.Drawing.Point(42, 16);
            this.lblSochungtu.Name = "lblSochungtu";
            this.lblSochungtu.Size = new System.Drawing.Size(65, 14);
            this.lblSochungtu.TabIndex = 0;
            this.lblSochungtu.Text = "Số chứng từ:";
            // 
            // txtSochungtu
            // 
            this.txtSochungtu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSochungtu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSochungtu.Location = new System.Drawing.Point(113, 14);
            this.txtSochungtu.Name = "txtSochungtu";
            this.txtSochungtu.Size = new System.Drawing.Size(100, 20);
            this.txtSochungtu.TabIndex = 1;
            // 
            // lblNgaychungtu
            // 
            this.lblNgaychungtu.AutoSize = true;
            this.lblNgaychungtu.Location = new System.Drawing.Point(271, 16);
            this.lblNgaychungtu.Name = "lblNgaychungtu";
            this.lblNgaychungtu.Size = new System.Drawing.Size(78, 14);
            this.lblNgaychungtu.TabIndex = 5;
            this.lblNgaychungtu.Text = "Ngày chứng từ:";
            // 
            // makNgaychungtu
            // 
            this.makNgaychungtu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.makNgaychungtu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.makNgaychungtu.Location = new System.Drawing.Point(355, 13);
            this.makNgaychungtu.Mask = "00/00/0000";
            this.makNgaychungtu.Name = "makNgaychungtu";
            this.makNgaychungtu.ReadOnly = true;
            this.makNgaychungtu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.makNgaychungtu.Size = new System.Drawing.Size(100, 20);
            this.makNgaychungtu.TabIndex = 2;
            this.makNgaychungtu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDinhdangngay
            // 
            this.lblDinhdangngay.AutoSize = true;
            this.lblDinhdangngay.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblDinhdangngay.Location = new System.Drawing.Point(461, 15);
            this.lblDinhdangngay.Name = "lblDinhdangngay";
            this.lblDinhdangngay.Size = new System.Drawing.Size(73, 14);
            this.lblDinhdangngay.TabIndex = 7;
            this.lblDinhdangngay.TabStop = true;
            this.lblDinhdangngay.Text = "(dd/mm/yyyy)";
            // 
            // lblKhohang
            // 
            this.lblKhohang.AutoSize = true;
            this.lblKhohang.Location = new System.Drawing.Point(62, 45);
            this.lblKhohang.Name = "lblKhohang";
            this.lblKhohang.Size = new System.Drawing.Size(45, 14);
            this.lblKhohang.TabIndex = 12;
            this.lblKhohang.Text = "Từ kho:";
            // 
            // cbxTukho
            // 
            this.cbxTukho.BackColor = System.Drawing.Color.White;
            this.cbxTukho.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbxTukho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTukho.Location = new System.Drawing.Point(113, 42);
            this.cbxTukho.Name = "cbxTukho";
            this.cbxTukho.Size = new System.Drawing.Size(255, 22);
            this.cbxTukho.TabIndex = 3;
            this.cbxTukho.SelectedIndexChanged += new System.EventHandler(this.cbxTukho_SelectedIndexChanged);
            // 
            // txtDiengiai
            // 
            this.txtDiengiai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiengiai.Location = new System.Drawing.Point(113, 95);
            this.txtDiengiai.MaxLength = 100;
            this.txtDiengiai.Name = "txtDiengiai";
            this.txtDiengiai.Size = new System.Drawing.Size(633, 20);
            this.txtDiengiai.TabIndex = 6;
            // 
            // lblDiengiai
            // 
            this.lblDiengiai.AutoSize = true;
            this.lblDiengiai.Location = new System.Drawing.Point(56, 97);
            this.lblDiengiai.Name = "lblDiengiai";
            this.lblDiengiai.Size = new System.Drawing.Size(51, 14);
            this.lblDiengiai.TabIndex = 30;
            this.lblDiengiai.Text = "Diễn giải:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 43;
            this.label1.Text = "Đến kho:";
            // 
            // cbxDenkho
            // 
            this.cbxDenkho.BackColor = System.Drawing.Color.White;
            this.cbxDenkho.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbxDenkho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDenkho.Location = new System.Drawing.Point(491, 42);
            this.cbxDenkho.Name = "cbxDenkho";
            this.cbxDenkho.Size = new System.Drawing.Size(255, 22);
            this.cbxDenkho.TabIndex = 4;
            this.cbxDenkho.SelectedIndexChanged += new System.EventHandler(this.cbxDenkho_SelectedIndexChanged);
            // 
            // check_Xacnhan
            // 
            this.check_Xacnhan.AutoSize = true;
            this.check_Xacnhan.Location = new System.Drawing.Point(113, 73);
            this.check_Xacnhan.Name = "check_Xacnhan";
            this.check_Xacnhan.Size = new System.Drawing.Size(15, 14);
            this.check_Xacnhan.TabIndex = 48;
            this.check_Xacnhan.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 14);
            this.label3.TabIndex = 49;
            this.label3.Text = "Xác nhận:";
            // 
            // cbxTaikhoan
            // 
            this.cbxTaikhoan.Controls.Add(this.label3);
            this.cbxTaikhoan.Controls.Add(this.check_Xacnhan);
            this.cbxTaikhoan.Controls.Add(this.cbxDenkho);
            this.cbxTaikhoan.Controls.Add(this.label1);
            this.cbxTaikhoan.Controls.Add(this.lblDiengiai);
            this.cbxTaikhoan.Controls.Add(this.txtDiengiai);
            this.cbxTaikhoan.Controls.Add(this.cbxTukho);
            this.cbxTaikhoan.Controls.Add(this.lblKhohang);
            this.cbxTaikhoan.Controls.Add(this.lblDinhdangngay);
            this.cbxTaikhoan.Controls.Add(this.makNgaychungtu);
            this.cbxTaikhoan.Controls.Add(this.lblNgaychungtu);
            this.cbxTaikhoan.Controls.Add(this.txtSochungtu);
            this.cbxTaikhoan.Controls.Add(this.lblSochungtu);
            this.cbxTaikhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxTaikhoan.Location = new System.Drawing.Point(0, 0);
            this.cbxTaikhoan.Name = "cbxTaikhoan";
            this.cbxTaikhoan.Size = new System.Drawing.Size(758, 130);
            this.cbxTaikhoan.TabIndex = 1;
            // 
            // frmXuLy_DieuChuyenKhoNoiBo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 472);
            this.Controls.Add(this.palXem);
            this.Controls.Add(this.cbxTaikhoan);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmXuLy_DieuChuyenKhoNoiBo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điều chuyển kho nội bộ";
            this.palXem.ResumeLayout(false);
            this.grbDataGridview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInsertOrder)).EndInit();
            this.palThem.ResumeLayout(false);
            this.palThem.PerformLayout();
            this.toolStrip_Insert.ResumeLayout(false);
            this.toolStrip_Insert.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cbxTaikhoan.ResumeLayout(false);
            this.cbxTaikhoan.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel palXem;
        private System.Windows.Forms.GroupBox grbDataGridview;
        private System.Windows.Forms.Panel palThem;
        private System.Windows.Forms.ToolStrip toolStrip_Insert;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTracuu;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtSoluong;
        private System.Windows.Forms.ToolStripButton toolStrip_btnThem;
        private System.Windows.Forms.ToolStripStatusLabel tsslthemmoi;
        private System.Windows.Forms.ToolStripStatusLabel tssSua;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lblSochungtu;
        private System.Windows.Forms.TextBox txtSochungtu;
        private System.Windows.Forms.Label lblNgaychungtu;
        private System.Windows.Forms.MaskedTextBox makNgaychungtu;
        private System.Windows.Forms.LinkLabel lblDinhdangngay;
        private System.Windows.Forms.Label lblKhohang;
        private System.Windows.Forms.ComboBox cbxTukho;
        private System.Windows.Forms.TextBox txtDiengiai;
        private System.Windows.Forms.Label lblDiengiai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxDenkho;
        private System.Windows.Forms.CheckBox check_Xacnhan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel cbxTaikhoan;
        private System.Windows.Forms.DataGridView dgvInsertOrder;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStrip_txtTen;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;

    }
}