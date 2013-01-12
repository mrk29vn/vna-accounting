namespace GUI
{
    partial class frmSoDuKhachHang
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
            this.lbtrangthai = new System.Windows.Forms.Label();
            this.lbdoituong = new System.Windows.Forms.Label();
            this.cbbnam = new System.Windows.Forms.ComboBox();
            this.cbbthang = new System.Windows.Forms.ComboBox();
            this.cbbdoituong = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsslma = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tsslten = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tssldiachi = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.tsslsodudauky = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.lbltheonam = new System.Windows.Forms.Label();
            this.lbltheothang = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslnap = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssldong = new System.Windows.Forms.ToolStripStatusLabel();
            this.dtgvcongno = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcongno)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.lbtrangthai);
            this.panel1.Controls.Add(this.lbdoituong);
            this.panel1.Controls.Add(this.cbbnam);
            this.panel1.Controls.Add(this.cbbthang);
            this.panel1.Controls.Add(this.cbbdoituong);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.lbltheonam);
            this.panel1.Controls.Add(this.lbltheothang);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 107);
            this.panel1.TabIndex = 1;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
            // 
            // lbtrangthai
            // 
            this.lbtrangthai.AutoSize = true;
            this.lbtrangthai.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtrangthai.Location = new System.Drawing.Point(413, 44);
            this.lbtrangthai.Name = "lbtrangthai";
            this.lbtrangthai.Size = new System.Drawing.Size(59, 22);
            this.lbtrangthai.TabIndex = 49;
            this.lbtrangthai.Text = "label2";
            // 
            // lbdoituong
            // 
            this.lbdoituong.AutoSize = true;
            this.lbdoituong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdoituong.Location = new System.Drawing.Point(12, 46);
            this.lbdoituong.Name = "lbdoituong";
            this.lbdoituong.Size = new System.Drawing.Size(66, 15);
            this.lbdoituong.TabIndex = 48;
            this.lbdoituong.Text = "Đối tượng:";
            // 
            // cbbnam
            // 
            this.cbbnam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbnam.FormattingEnabled = true;
            this.cbbnam.Items.AddRange(new object[] {
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.cbbnam.Location = new System.Drawing.Point(340, 43);
            this.cbbnam.Name = "cbbnam";
            this.cbbnam.Size = new System.Drawing.Size(67, 22);
            this.cbbnam.TabIndex = 47;
            this.cbbnam.SelectedIndexChanged += new System.EventHandler(this.cbbnam_SelectedIndexChanged);
            // 
            // cbbthang
            // 
            this.cbbthang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbthang.FormattingEnabled = true;
            this.cbbthang.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbbthang.Location = new System.Drawing.Point(249, 43);
            this.cbbthang.Name = "cbbthang";
            this.cbbthang.Size = new System.Drawing.Size(47, 22);
            this.cbbthang.TabIndex = 46;
            this.cbbthang.SelectedIndexChanged += new System.EventHandler(this.cbbthang_SelectedIndexChanged);
            // 
            // cbbdoituong
            // 
            this.cbbdoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbdoituong.FormattingEnabled = true;
            this.cbbdoituong.Items.AddRange(new object[] {
            "Khách Hàng",
            "Nhà Cung Cấp"});
            this.cbbdoituong.Location = new System.Drawing.Point(79, 43);
            this.cbbdoituong.Name = "cbbdoituong";
            this.cbbdoituong.Size = new System.Drawing.Size(121, 22);
            this.cbbdoituong.TabIndex = 45;
            this.cbbdoituong.SelectedIndexChanged += new System.EventHandler(this.cbbdoituong_SelectedIndexChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsslma,
            this.toolStripLabel3,
            this.tsslten,
            this.toolStripLabel2,
            this.tssldiachi,
            this.toolStripLabel5,
            this.tsslsodudauky,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 82);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(795, 25);
            this.toolStrip1.TabIndex = 44;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel1.Text = "Mã:";
            // 
            // tsslma
            // 
            this.tsslma.BackColor = System.Drawing.Color.White;
            this.tsslma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsslma.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsslma.Name = "tsslma";
            this.tsslma.ReadOnly = true;
            this.tsslma.Size = new System.Drawing.Size(100, 25);
            this.tsslma.Text = "<F4>-Tra cứu";
            this.tsslma.ToolTipText = "Mã tài khoản kế toán";
            this.tsslma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsslma_KeyUp);
            this.tsslma.Click += new System.EventHandler(this.tsslma_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel3.Text = "Tên:";
            // 
            // tsslten
            // 
            this.tsslten.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tsslten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsslten.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslten.Name = "tsslten";
            this.tsslten.ReadOnly = true;
            this.tsslten.Size = new System.Drawing.Size(150, 25);
            this.tsslten.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tsslten.ToolTipText = "Tên tài khoản kế toán";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(47, 22);
            this.toolStripLabel2.Text = "Địa chỉ:";
            // 
            // tssldiachi
            // 
            this.tssldiachi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tssldiachi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tssldiachi.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tssldiachi.Name = "tssldiachi";
            this.tssldiachi.ReadOnly = true;
            this.tssldiachi.Size = new System.Drawing.Size(140, 25);
            this.tssldiachi.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tssldiachi.ToolTipText = "Tên tài khoản kế toán";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(80, 22);
            this.toolStripLabel5.Text = "Số dư đầu kỳ:";
            // 
            // tsslsodudauky
            // 
            this.tsslsodudauky.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsslsodudauky.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsslsodudauky.Name = "tsslsodudauky";
            this.tsslsodudauky.Size = new System.Drawing.Size(130, 25);
            this.tsslsodudauky.Text = "0";
            this.tsslsodudauky.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tsslsodudauky.ToolTipText = "Số dư đầu kỳ";
            this.tsslsodudauky.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tsslsodudauky_KeyDown);
            this.tsslsodudauky.Click += new System.EventHandler(this.tsslsodudauky_Click);
            this.tsslsodudauky.TextChanged += new System.EventHandler(this.tsslsodudauky_TextChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Checked = true;
            this.toolStripButton1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(47, 22);
            this.toolStripButton1.Text = "Thêm  ";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // lbltheonam
            // 
            this.lbltheonam.AutoSize = true;
            this.lbltheonam.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltheonam.Location = new System.Drawing.Point(302, 46);
            this.lbltheonam.Name = "lbltheonam";
            this.lbltheonam.Size = new System.Drawing.Size(36, 15);
            this.lbltheonam.TabIndex = 33;
            this.lbltheonam.Text = "Năm:";
            // 
            // lbltheothang
            // 
            this.lbltheothang.AutoSize = true;
            this.lbltheothang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltheothang.Location = new System.Drawing.Point(202, 46);
            this.lbltheothang.Name = "lbltheothang";
            this.lbltheothang.Size = new System.Drawing.Size(46, 15);
            this.lbltheothang.TabIndex = 25;
            this.lbltheothang.Text = "Tháng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập Số Dư Đầu Kỳ Công Nợ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslnap,
            this.tssldong});
            this.statusStrip1.Location = new System.Drawing.Point(0, 425);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(795, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslnap
            // 
            this.tsslnap.Image = global::GUI.Properties.Resources.refresh;
            this.tsslnap.Name = "tsslnap";
            this.tsslnap.Size = new System.Drawing.Size(390, 21);
            this.tsslnap.Spring = true;
            this.tsslnap.Text = "Nạp lại";
            this.tsslnap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslnap.Click += new System.EventHandler(this.tsslnap_Click);
            this.tsslnap.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslnap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssldong
            // 
            this.tssldong.Image = global::GUI.Properties.Resources.Xoa;
            this.tssldong.Name = "tssldong";
            this.tssldong.Size = new System.Drawing.Size(390, 21);
            this.tssldong.Spring = true;
            this.tssldong.Text = "Đóng";
            this.tssldong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssldong.Click += new System.EventHandler(this.tssldong_Click);
            this.tssldong.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssldong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // dtgvcongno
            // 
            this.dtgvcongno.BackgroundColor = System.Drawing.Color.White;
            this.dtgvcongno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvcongno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvcongno.Location = new System.Drawing.Point(0, 107);
            this.dtgvcongno.Name = "dtgvcongno";
            this.dtgvcongno.Size = new System.Drawing.Size(795, 318);
            this.dtgvcongno.TabIndex = 4;
            this.dtgvcongno.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvcongno_CellDoubleClick);
            // 
            // frmSoDuKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 451);
            this.Controls.Add(this.dtgvcongno);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSoDuKhachHang";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmSoDuKhachHang_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcongno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tsslma;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox tsslten;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox tsslsodudauky;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label lbltheonam;
        private System.Windows.Forms.Label lbltheothang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tssldong;
        private System.Windows.Forms.ComboBox cbbnam;
        private System.Windows.Forms.ComboBox cbbthang;
        private System.Windows.Forms.ComboBox cbbdoituong;
        private System.Windows.Forms.DataGridView dtgvcongno;
        private System.Windows.Forms.Label lbdoituong;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tssldiachi;
        private System.Windows.Forms.Label lbtrangthai;
        private System.Windows.Forms.ToolStripStatusLabel tsslnap;


    }
}