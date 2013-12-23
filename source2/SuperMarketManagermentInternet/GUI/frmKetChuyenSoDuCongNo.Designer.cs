namespace GUI
{
    partial class frmKetChuyenSoDuCongNo
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
            this.lbtrangthai = new System.Windows.Forms.Label();
            this.cbbnam = new System.Windows.Forms.ComboBox();
            this.cbbthang = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbdoituong = new System.Windows.Forms.ComboBox();
            this.lbdoituong = new System.Windows.Forms.Label();
            this.lbltheonam = new System.Windows.Forms.Label();
            this.lbltheothang = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslthuchien = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssltrove = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbtrangthai
            // 
            this.lbtrangthai.AutoSize = true;
            this.lbtrangthai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtrangthai.Location = new System.Drawing.Point(247, 39);
            this.lbtrangthai.Name = "lbtrangthai";
            this.lbtrangthai.Size = new System.Drawing.Size(52, 17);
            this.lbtrangthai.TabIndex = 56;
            this.lbtrangthai.Text = "label2";
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
            this.cbbnam.Location = new System.Drawing.Point(174, 36);
            this.cbbnam.Name = "cbbnam";
            this.cbbnam.Size = new System.Drawing.Size(67, 22);
            this.cbbnam.TabIndex = 55;
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
            this.cbbthang.Location = new System.Drawing.Point(83, 36);
            this.cbbthang.Name = "cbbthang";
            this.cbbthang.Size = new System.Drawing.Size(47, 22);
            this.cbbthang.TabIndex = 54;
            this.cbbthang.SelectedIndexChanged += new System.EventHandler(this.cbbthang_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbbdoituong);
            this.panel2.Controls.Add(this.lbdoituong);
            this.panel2.Controls.Add(this.lbtrangthai);
            this.panel2.Controls.Add(this.cbbnam);
            this.panel2.Controls.Add(this.cbbthang);
            this.panel2.Controls.Add(this.lbltheonam);
            this.panel2.Controls.Add(this.lbltheothang);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 105);
            this.panel2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(68, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(350, 34);
            this.label3.TabIndex = 60;
            this.label3.Text = "Hãy chắc chắn hôm nay là ngày giao dịch cuối \r\ncùng trong kỳ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(3, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 59;
            this.label2.Text = "Chú ý:";
            // 
            // cbbdoituong
            // 
            this.cbbdoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbdoituong.FormattingEnabled = true;
            this.cbbdoituong.Items.AddRange(new object[] {
            "Khách Hàng",
            "Nhà Cung Cấp"});
            this.cbbdoituong.Location = new System.Drawing.Point(83, 6);
            this.cbbdoituong.Name = "cbbdoituong";
            this.cbbdoituong.Size = new System.Drawing.Size(158, 22);
            this.cbbdoituong.TabIndex = 58;
            this.cbbdoituong.SelectedIndexChanged += new System.EventHandler(this.cbbdoituong_SelectedIndexChanged);
            // 
            // lbdoituong
            // 
            this.lbdoituong.AutoSize = true;
            this.lbdoituong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbdoituong.Location = new System.Drawing.Point(11, 9);
            this.lbdoituong.Name = "lbdoituong";
            this.lbdoituong.Size = new System.Drawing.Size(66, 13);
            this.lbdoituong.TabIndex = 57;
            this.lbdoituong.Text = "Đối tượng:";
            // 
            // lbltheonam
            // 
            this.lbltheonam.AutoSize = true;
            this.lbltheonam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltheonam.Location = new System.Drawing.Point(136, 39);
            this.lbltheonam.Name = "lbltheonam";
            this.lbltheonam.Size = new System.Drawing.Size(36, 13);
            this.lbltheonam.TabIndex = 53;
            this.lbltheonam.Text = "Năm:";
            // 
            // lbltheothang
            // 
            this.lbltheothang.AutoSize = true;
            this.lbltheothang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltheothang.Location = new System.Drawing.Point(30, 41);
            this.lbltheothang.Name = "lbltheothang";
            this.lbltheothang.Size = new System.Drawing.Size(47, 13);
            this.lbltheothang.TabIndex = 52;
            this.lbltheothang.Text = "Tháng:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslthuchien,
            this.tssltrove});
            this.statusStrip1.Location = new System.Drawing.Point(0, 148);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(427, 26);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslthuchien
            // 
            this.tsslthuchien.Image = global::GUI.Properties.Resources.Them;
            this.tsslthuchien.Name = "tsslthuchien";
            this.tsslthuchien.Size = new System.Drawing.Size(190, 21);
            this.tsslthuchien.Spring = true;
            this.tsslthuchien.Text = "Thực hiện";
            this.tsslthuchien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslthuchien.Click += new System.EventHandler(this.tsslthuchien_Click);
            this.tsslthuchien.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslthuchien.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tssltrove
            // 
            this.tssltrove.Image = global::GUI.Properties.Resources.Xoa;
            this.tssltrove.Name = "tssltrove";
            this.tssltrove.Size = new System.Drawing.Size(190, 21);
            this.tssltrove.Spring = true;
            this.tssltrove.Text = "Đóng";
            this.tssltrove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tssltrove.Click += new System.EventHandler(this.tssltrove_Click);
            this.tssltrove.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tssltrove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kết Chuyển Số Dư Công Nợ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 43);
            this.panel1.TabIndex = 3;
            // 
            // frmKetChuyenSoDuCongNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 174);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmKetChuyenSoDuCongNo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmKetChuyenSoDuCongNo_Load);
            this.Resize += new System.EventHandler(this.frmKetChuyenSoDuCongNo_Resize);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbtrangthai;
        private System.Windows.Forms.ComboBox cbbnam;
        private System.Windows.Forms.ComboBox cbbthang;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbltheonam;
        private System.Windows.Forms.Label lbltheothang;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslthuchien;
        private System.Windows.Forms.ToolStripStatusLabel tssltrove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbbdoituong;
        private System.Windows.Forms.Label lbdoituong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;

    }
}