namespace GUI
{
    partial class frmLocDieuKien
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
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbbnamquy = new System.Windows.Forms.ComboBox();
            this.lbnamtheoquy = new System.Windows.Forms.Label();
            this.lbquy = new System.Windows.Forms.Label();
            this.cbbquy = new System.Windows.Forms.ComboBox();
            this.rdbtimkiem2 = new System.Windows.Forms.RadioButton();
            this.lbloi = new System.Windows.Forms.Label();
            this.cbbnam = new System.Windows.Forms.ComboBox();
            this.lbthang = new System.Windows.Forms.Label();
            this.lbnam = new System.Windows.Forms.Label();
            this.cbbthang = new System.Windows.Forms.ComboBox();
            this.lbtoi = new System.Windows.Forms.Label();
            this.mskdenngay = new System.Windows.Forms.MaskedTextBox();
            this.msktungay = new System.Windows.Forms.MaskedTextBox();
            this.rdbtimkiem3 = new System.Windows.Forms.RadioButton();
            this.rdbtimkiem1 = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 132);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(376, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::GUI.Properties.Resources.Xem_chi_tiet;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(180, 21);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Xem";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            this.toolStripStatusLabel1.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Image = global::GUI.Properties.Resources.Xoa;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(180, 21);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "Thoát";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            this.toolStripStatusLabel2.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.toolStripStatusLabel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbbnamquy);
            this.panel2.Controls.Add(this.lbnamtheoquy);
            this.panel2.Controls.Add(this.lbquy);
            this.panel2.Controls.Add(this.cbbquy);
            this.panel2.Controls.Add(this.rdbtimkiem2);
            this.panel2.Controls.Add(this.lbloi);
            this.panel2.Controls.Add(this.cbbnam);
            this.panel2.Controls.Add(this.lbthang);
            this.panel2.Controls.Add(this.lbnam);
            this.panel2.Controls.Add(this.cbbthang);
            this.panel2.Controls.Add(this.lbtoi);
            this.panel2.Controls.Add(this.mskdenngay);
            this.panel2.Controls.Add(this.msktungay);
            this.panel2.Controls.Add(this.rdbtimkiem3);
            this.panel2.Controls.Add(this.rdbtimkiem1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 132);
            this.panel2.TabIndex = 2;
            // 
            // cbbnamquy
            // 
            this.cbbnamquy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbnamquy.FormattingEnabled = true;
            this.cbbnamquy.Items.AddRange(new object[] {
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
            this.cbbnamquy.Location = new System.Drawing.Point(280, 48);
            this.cbbnamquy.Name = "cbbnamquy";
            this.cbbnamquy.Size = new System.Drawing.Size(83, 21);
            this.cbbnamquy.TabIndex = 77;
            this.cbbnamquy.Visible = false;
            // 
            // lbnamtheoquy
            // 
            this.lbnamtheoquy.AutoSize = true;
            this.lbnamtheoquy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnamtheoquy.Location = new System.Drawing.Point(238, 52);
            this.lbnamtheoquy.Name = "lbnamtheoquy";
            this.lbnamtheoquy.Size = new System.Drawing.Size(36, 13);
            this.lbnamtheoquy.TabIndex = 76;
            this.lbnamtheoquy.Text = "Năm:";
            this.lbnamtheoquy.Visible = false;
            // 
            // lbquy
            // 
            this.lbquy.AutoSize = true;
            this.lbquy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbquy.Location = new System.Drawing.Point(134, 53);
            this.lbquy.Name = "lbquy";
            this.lbquy.Size = new System.Drawing.Size(33, 13);
            this.lbquy.TabIndex = 75;
            this.lbquy.Text = "Quý:";
            this.lbquy.Visible = false;
            // 
            // cbbquy
            // 
            this.cbbquy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbquy.FormattingEnabled = true;
            this.cbbquy.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbbquy.Location = new System.Drawing.Point(187, 48);
            this.cbbquy.Name = "cbbquy";
            this.cbbquy.Size = new System.Drawing.Size(42, 21);
            this.cbbquy.TabIndex = 74;
            this.cbbquy.Visible = false;
            // 
            // rdbtimkiem2
            // 
            this.rdbtimkiem2.AutoSize = true;
            this.rdbtimkiem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtimkiem2.Location = new System.Drawing.Point(15, 49);
            this.rdbtimkiem2.Name = "rdbtimkiem2";
            this.rdbtimkiem2.Size = new System.Drawing.Size(82, 17);
            this.rdbtimkiem2.TabIndex = 73;
            this.rdbtimkiem2.TabStop = true;
            this.rdbtimkiem2.Text = "Theo quý:";
            this.rdbtimkiem2.UseVisualStyleBackColor = true;
            this.rdbtimkiem2.CheckedChanged += new System.EventHandler(this.rdbtimkiem_CheckedChanged);
            // 
            // lbloi
            // 
            this.lbloi.AutoSize = true;
            this.lbloi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbloi.ForeColor = System.Drawing.Color.Red;
            this.lbloi.Location = new System.Drawing.Point(148, 115);
            this.lbloi.Name = "lbloi";
            this.lbloi.Size = new System.Drawing.Size(0, 13);
            this.lbloi.TabIndex = 72;
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
            this.cbbnam.Location = new System.Drawing.Point(280, 14);
            this.cbbnam.Name = "cbbnam";
            this.cbbnam.Size = new System.Drawing.Size(83, 21);
            this.cbbnam.TabIndex = 71;
            this.cbbnam.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp_Chung);
            // 
            // lbthang
            // 
            this.lbthang.AutoSize = true;
            this.lbthang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbthang.Location = new System.Drawing.Point(238, 18);
            this.lbthang.Name = "lbthang";
            this.lbthang.Size = new System.Drawing.Size(36, 13);
            this.lbthang.TabIndex = 70;
            this.lbthang.Text = "Năm:";
            // 
            // lbnam
            // 
            this.lbnam.AutoSize = true;
            this.lbnam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbnam.Location = new System.Drawing.Point(134, 18);
            this.lbnam.Name = "lbnam";
            this.lbnam.Size = new System.Drawing.Size(47, 13);
            this.lbnam.TabIndex = 69;
            this.lbnam.Text = "Tháng:";
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
            this.cbbthang.Location = new System.Drawing.Point(187, 14);
            this.cbbthang.Name = "cbbthang";
            this.cbbthang.Size = new System.Drawing.Size(42, 21);
            this.cbbthang.TabIndex = 68;
            this.cbbthang.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp_Chung);
            // 
            // lbtoi
            // 
            this.lbtoi.AutoSize = true;
            this.lbtoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtoi.Location = new System.Drawing.Point(245, 91);
            this.lbtoi.Name = "lbtoi";
            this.lbtoi.Size = new System.Drawing.Size(29, 13);
            this.lbtoi.TabIndex = 67;
            this.lbtoi.Text = "Tới:";
            this.lbtoi.Visible = false;
            // 
            // mskdenngay
            // 
            this.mskdenngay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mskdenngay.Location = new System.Drawing.Point(281, 87);
            this.mskdenngay.Mask = "00/00/0000";
            this.mskdenngay.Name = "mskdenngay";
            this.mskdenngay.Size = new System.Drawing.Size(83, 20);
            this.mskdenngay.TabIndex = 66;
            this.mskdenngay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mskdenngay.ValidatingType = typeof(System.DateTime);
            this.mskdenngay.Visible = false;
            this.mskdenngay.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp_Chung);
            // 
            // msktungay
            // 
            this.msktungay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msktungay.Location = new System.Drawing.Point(146, 87);
            this.msktungay.Mask = "00/00/0000";
            this.msktungay.Name = "msktungay";
            this.msktungay.Size = new System.Drawing.Size(83, 20);
            this.msktungay.TabIndex = 65;
            this.msktungay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.msktungay.ValidatingType = typeof(System.DateTime);
            this.msktungay.Visible = false;
            this.msktungay.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyUp_Chung);
            // 
            // rdbtimkiem3
            // 
            this.rdbtimkiem3.AutoSize = true;
            this.rdbtimkiem3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtimkiem3.Location = new System.Drawing.Point(15, 87);
            this.rdbtimkiem3.Name = "rdbtimkiem3";
            this.rdbtimkiem3.Size = new System.Drawing.Size(125, 17);
            this.rdbtimkiem3.TabIndex = 64;
            this.rdbtimkiem3.Text = "Khoảng thời gian:";
            this.rdbtimkiem3.UseVisualStyleBackColor = true;
            this.rdbtimkiem3.CheckedChanged += new System.EventHandler(this.rdbtimkiem_CheckedChanged);
            // 
            // rdbtimkiem1
            // 
            this.rdbtimkiem1.AutoSize = true;
            this.rdbtimkiem1.Checked = true;
            this.rdbtimkiem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtimkiem1.Location = new System.Drawing.Point(15, 15);
            this.rdbtimkiem1.Name = "rdbtimkiem1";
            this.rdbtimkiem1.Size = new System.Drawing.Size(94, 17);
            this.rdbtimkiem1.TabIndex = 63;
            this.rdbtimkiem1.TabStop = true;
            this.rdbtimkiem1.Text = "Theo tháng:";
            this.rdbtimkiem1.UseVisualStyleBackColor = true;
            this.rdbtimkiem1.CheckedChanged += new System.EventHandler(this.rdbtimkiem_CheckedChanged);
            // 
            // frmLocDieuKien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 158);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmLocDieuKien";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Lọc Điều Kiện Theo Thời Gian";
            this.Load += new System.EventHandler(this.frmLocDieuKien_Load);
            this.Resize += new System.EventHandler(this.frmLocDieuKien_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbbnam;
        private System.Windows.Forms.Label lbthang;
        private System.Windows.Forms.Label lbnam;
        private System.Windows.Forms.ComboBox cbbthang;
        private System.Windows.Forms.Label lbtoi;
        private System.Windows.Forms.MaskedTextBox mskdenngay;
        private System.Windows.Forms.MaskedTextBox msktungay;
        private System.Windows.Forms.RadioButton rdbtimkiem3;
        private System.Windows.Forms.RadioButton rdbtimkiem1;
        private System.Windows.Forms.Label lbloi;
        private System.Windows.Forms.RadioButton rdbtimkiem2;
        private System.Windows.Forms.ComboBox cbbnamquy;
        private System.Windows.Forms.Label lbnamtheoquy;
        private System.Windows.Forms.Label lbquy;
        private System.Windows.Forms.ComboBox cbbquy;
    }
}