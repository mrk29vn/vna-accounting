namespace GUI
{
    partial class frmtg
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
            this.rdoTheoThang = new System.Windows.Forms.RadioButton();
            this.rdoTheoNam = new System.Windows.Forms.RadioButton();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.rdoTheoNgay = new System.Windows.Forms.RadioButton();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslchitiet = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslPdf = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslWord = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslexcel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslthoat = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoTheoThang
            // 
            this.rdoTheoThang.AutoSize = true;
            this.rdoTheoThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTheoThang.Location = new System.Drawing.Point(50, 48);
            this.rdoTheoThang.Name = "rdoTheoThang";
            this.rdoTheoThang.Size = new System.Drawing.Size(94, 17);
            this.rdoTheoThang.TabIndex = 1;
            this.rdoTheoThang.Text = "Theo tháng:";
            this.rdoTheoThang.UseVisualStyleBackColor = true;
            this.rdoTheoThang.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rdoTheoNam
            // 
            this.rdoTheoNam.AutoSize = true;
            this.rdoTheoNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTheoNam.Location = new System.Drawing.Point(50, 73);
            this.rdoTheoNam.Name = "rdoTheoNam";
            this.rdoTheoNam.Size = new System.Drawing.Size(125, 17);
            this.rdoTheoNam.TabIndex = 2;
            this.rdoTheoNam.Text = "Khoảng thời gian:";
            this.rdoTheoNam.UseVisualStyleBackColor = true;
            this.rdoTheoNam.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBox2.Location = new System.Drawing.Point(185, 72);
            this.maskedTextBox2.Mask = "00/00/0000";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(83, 20);
            this.maskedTextBox2.TabIndex = 5;
            this.maskedTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maskedTextBox2.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox2.Visible = false;
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBox3.Location = new System.Drawing.Point(318, 73);
            this.maskedTextBox3.Mask = "00/00/0000";
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.Size = new System.Drawing.Size(83, 20);
            this.maskedTextBox3.TabIndex = 6;
            this.maskedTextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maskedTextBox3.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(282, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tới";
            this.label1.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
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
            this.comboBox1.Location = new System.Drawing.Point(231, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(37, 22);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(182, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tháng";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(280, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Năm";
            this.label3.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(318, 45);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(52, 20);
            this.dateTimePicker1.TabIndex = 9;
            this.dateTimePicker1.Visible = false;
            // 
            // rdoTheoNgay
            // 
            this.rdoTheoNgay.AutoSize = true;
            this.rdoTheoNgay.Checked = true;
            this.rdoTheoNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoTheoNgay.Location = new System.Drawing.Point(50, 23);
            this.rdoTheoNgay.Name = "rdoTheoNgay";
            this.rdoTheoNgay.Size = new System.Drawing.Size(89, 17);
            this.rdoTheoNgay.TabIndex = 0;
            this.rdoTheoNgay.TabStop = true;
            this.rdoTheoNgay.Text = "Theo ngày:";
            this.rdoTheoNgay.UseVisualStyleBackColor = true;
            this.rdoTheoNgay.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBox1.Location = new System.Drawing.Point(185, 20);
            this.maskedTextBox1.Mask = "00/00/0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(216, 20);
            this.maskedTextBox1.TabIndex = 3;
            this.maskedTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslchitiet,
            this.tsslPdf,
            this.tsslWord,
            this.tsslexcel,
            this.tsslthoat});
            this.statusStrip1.Location = new System.Drawing.Point(0, 124);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(455, 26);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Image = global::GUI.Properties.Resources.refresh;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(73, 21);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "Nạp lại";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripStatusLabel1.Visible = false;
            // 
            // tsslchitiet
            // 
            this.tsslchitiet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tsslchitiet.Image = global::GUI.Properties.Resources.In;
            this.tsslchitiet.Name = "tsslchitiet";
            this.tsslchitiet.Size = new System.Drawing.Size(88, 21);
            this.tsslchitiet.Spring = true;
            this.tsslchitiet.Text = "Xem";
            this.tsslchitiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslchitiet.Click += new System.EventHandler(this.tsslchitiet_Click);
            // 
            // tsslPdf
            // 
            this.tsslPdf.Image = global::GUI.Properties.Resources.icon_pdf;
            this.tsslPdf.Name = "tsslPdf";
            this.tsslPdf.Size = new System.Drawing.Size(68, 21);
            this.tsslPdf.Spring = true;
            this.tsslPdf.Text = "PDF";
            this.tsslPdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslPdf.Click += new System.EventHandler(this.tsslPdf_Click);
            // 
            // tsslWord
            // 
            this.tsslWord.Image = global::GUI.Properties.Resources.DocX_Viewer_icon;
            this.tsslWord.Name = "tsslWord";
            this.tsslWord.Size = new System.Drawing.Size(68, 21);
            this.tsslWord.Spring = true;
            this.tsslWord.Text = "Word";
            this.tsslWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslWord.Click += new System.EventHandler(this.tsslWord_Click);
            // 
            // tsslexcel
            // 
            this.tsslexcel.Image = global::GUI.Properties.Resources.excel_icon4;
            this.tsslexcel.Name = "tsslexcel";
            this.tsslexcel.Size = new System.Drawing.Size(68, 21);
            this.tsslexcel.Spring = true;
            this.tsslexcel.Text = "Excel";
            this.tsslexcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslexcel.Click += new System.EventHandler(this.tsslexcel_Click);
            // 
            // tsslthoat
            // 
            this.tsslthoat.Image = global::GUI.Properties.Resources.Xoa;
            this.tsslthoat.Name = "tsslthoat";
            this.tsslthoat.Size = new System.Drawing.Size(88, 21);
            this.tsslthoat.Spring = true;
            this.tsslthoat.Text = "Thoát";
            this.tsslthoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslthoat.Click += new System.EventHandler(this.tsslthoat_Click);
            // 
            // frmtg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 150);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox3);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.rdoTheoNam);
            this.Controls.Add(this.rdoTheoThang);
            this.Controls.Add(this.rdoTheoNgay);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmtg";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lập Báo Cáo Theo Thời Gian";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoTheoThang;
        private System.Windows.Forms.RadioButton rdoTheoNam;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource phieuThuBindingSource;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton rdoTheoNgay;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslchitiet;
        private System.Windows.Forms.ToolStripStatusLabel tsslPdf;
        private System.Windows.Forms.ToolStripStatusLabel tsslWord;
        private System.Windows.Forms.ToolStripStatusLabel tsslexcel;
        private System.Windows.Forms.ToolStripStatusLabel tsslthoat;

    }
}