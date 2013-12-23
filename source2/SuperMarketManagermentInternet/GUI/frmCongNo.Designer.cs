namespace GUI
{
    partial class frmCongNo
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
            this.cbbnam = new System.Windows.Forms.ComboBox();
            this.cbbthang = new System.Windows.Forms.ComboBox();
            this.lbltheonam = new System.Windows.Forms.Label();
            this.lbltheothang = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbdoituong = new System.Windows.Forms.ComboBox();
            this.lbltonghopsodutaikhoan = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslnap = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslblchitiet = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslbltrove = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgvcongno = new System.Windows.Forms.DataGridView();
            this.btnPDF = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnXem = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnExcel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnWord = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcongno)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.cbbnam);
            this.panel1.Controls.Add(this.cbbthang);
            this.panel1.Controls.Add(this.lbltheonam);
            this.panel1.Controls.Add(this.lbltheothang);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbbdoituong);
            this.panel1.Controls.Add(this.lbltonghopsodutaikhoan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 69);
            this.panel1.TabIndex = 1;
            this.panel1.DoubleClick += new System.EventHandler(this.panel1_DoubleClick);
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
            this.cbbnam.Location = new System.Drawing.Point(345, 40);
            this.cbbnam.Name = "cbbnam";
            this.cbbnam.Size = new System.Drawing.Size(67, 22);
            this.cbbnam.TabIndex = 59;
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
            this.cbbthang.Location = new System.Drawing.Point(254, 40);
            this.cbbthang.Name = "cbbthang";
            this.cbbthang.Size = new System.Drawing.Size(47, 22);
            this.cbbthang.TabIndex = 58;
            this.cbbthang.SelectedIndexChanged += new System.EventHandler(this.cbbthang_SelectedIndexChanged);
            // 
            // lbltheonam
            // 
            this.lbltheonam.AutoSize = true;
            this.lbltheonam.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltheonam.Location = new System.Drawing.Point(307, 43);
            this.lbltheonam.Name = "lbltheonam";
            this.lbltheonam.Size = new System.Drawing.Size(36, 15);
            this.lbltheonam.TabIndex = 57;
            this.lbltheonam.Text = "Năm:";
            // 
            // lbltheothang
            // 
            this.lbltheothang.AutoSize = true;
            this.lbltheothang.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltheothang.Location = new System.Drawing.Point(207, 43);
            this.lbltheothang.Name = "lbltheothang";
            this.lbltheothang.Size = new System.Drawing.Size(45, 15);
            this.lbltheothang.TabIndex = 56;
            this.lbltheothang.Text = "Tháng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Đối tượng";
            // 
            // cbbdoituong
            // 
            this.cbbdoituong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbdoituong.FormattingEnabled = true;
            this.cbbdoituong.Items.AddRange(new object[] {
            "Khách Hàng",
            "Nhà Cung Cấp"});
            this.cbbdoituong.Location = new System.Drawing.Point(80, 40);
            this.cbbdoituong.Name = "cbbdoituong";
            this.cbbdoituong.Size = new System.Drawing.Size(121, 22);
            this.cbbdoituong.TabIndex = 1;
            this.cbbdoituong.SelectedIndexChanged += new System.EventHandler(this.cbbdoituong_SelectedIndexChanged);
            // 
            // lbltonghopsodutaikhoan
            // 
            this.lbltonghopsodutaikhoan.AutoSize = true;
            this.lbltonghopsodutaikhoan.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltonghopsodutaikhoan.ForeColor = System.Drawing.SystemColors.Info;
            this.lbltonghopsodutaikhoan.Location = new System.Drawing.Point(3, 3);
            this.lbltonghopsodutaikhoan.Name = "lbltonghopsodutaikhoan";
            this.lbltonghopsodutaikhoan.Size = new System.Drawing.Size(136, 17);
            this.lbltonghopsodutaikhoan.TabIndex = 0;
            this.lbltonghopsodutaikhoan.Text = "Tổng Hợp Công Nợ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.statusStrip1.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslnap,
            this.tsslblchitiet,
            this.btnXem,
            this.btnExcel,
            this.btnWord,
            this.btnPDF,
            this.tsslbltrove});
            this.statusStrip1.Location = new System.Drawing.Point(0, 461);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslnap
            // 
            this.tsslnap.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsslnap.Image = global::GUI.Properties.Resources.refresh;
            this.tsslnap.Name = "tsslnap";
            this.tsslnap.Size = new System.Drawing.Size(112, 21);
            this.tsslnap.Spring = true;
            this.tsslnap.Text = "Nạp lại";
            this.tsslnap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslnap.Click += new System.EventHandler(this.tsslnap_Click);
            this.tsslnap.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslnap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslblchitiet
            // 
            this.tsslblchitiet.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsslblchitiet.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tsslblchitiet.Image = global::GUI.Properties.Resources.Xem_chi_tiet;
            this.tsslblchitiet.Name = "tsslblchitiet";
            this.tsslblchitiet.Size = new System.Drawing.Size(112, 21);
            this.tsslblchitiet.Spring = true;
            this.tsslblchitiet.Text = "Chi tiết";
            this.tsslblchitiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslblchitiet.Click += new System.EventHandler(this.tsslblchitiet_Click);
            this.tsslblchitiet.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslblchitiet.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // tsslbltrove
            // 
            this.tsslbltrove.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tsslbltrove.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.tsslbltrove.Image = global::GUI.Properties.Resources.Xoa;
            this.tsslbltrove.Name = "tsslbltrove";
            this.tsslbltrove.Size = new System.Drawing.Size(112, 21);
            this.tsslbltrove.Spring = true;
            this.tsslbltrove.Text = "Đóng";
            this.tsslbltrove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsslbltrove.Click += new System.EventHandler(this.tsslbltrove_Click);
            this.tsslbltrove.MouseLeave += new System.EventHandler(this.MouseLeave);
            this.tsslbltrove.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvcongno);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(834, 392);
            this.panel2.TabIndex = 3;
            // 
            // dtgvcongno
            // 
            this.dtgvcongno.BackgroundColor = System.Drawing.Color.White;
            this.dtgvcongno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvcongno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvcongno.Location = new System.Drawing.Point(0, 0);
            this.dtgvcongno.Name = "dtgvcongno";
            this.dtgvcongno.Size = new System.Drawing.Size(834, 392);
            this.dtgvcongno.TabIndex = 0;
            this.dtgvcongno.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvcongno_CellClick);
            this.dtgvcongno.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvcongno_CellDoubleClick);
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPDF.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.btnPDF.Image = global::GUI.Properties.Resources.icon_pdf;
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(112, 21);
            this.btnPDF.Spring = true;
            this.btnPDF.Text = "PDF";
            this.btnPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnXem
            // 
            this.btnXem.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnXem.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.btnXem.Image = global::GUI.Properties.Resources.In;
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(112, 21);
            this.btnXem.Spring = true;
            this.btnXem.Text = "Xem";
            this.btnXem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnExcel.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.btnExcel.Image = global::GUI.Properties.Resources.excel_icon4;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(112, 21);
            this.btnExcel.Spring = true;
            this.btnExcel.Text = "Excel";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnWord
            // 
            this.btnWord.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnWord.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.btnWord.Image = global::GUI.Properties.Resources.DocX_Viewer_icon;
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(112, 21);
            this.btnWord.Spring = true;
            this.btnWord.Text = "Word";
            this.btnWord.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // frmCongNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 487);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCongNo";
            this.ShowIcon = false;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCongNo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvcongno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltonghopsodutaikhoan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbdoituong;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslblchitiet;
        private System.Windows.Forms.ToolStripStatusLabel tsslbltrove;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgvcongno;
        private System.Windows.Forms.ComboBox cbbnam;
        private System.Windows.Forms.ComboBox cbbthang;
        private System.Windows.Forms.Label lbltheonam;
        private System.Windows.Forms.Label lbltheothang;
        private System.Windows.Forms.ToolStripStatusLabel tsslnap;
        private System.Windows.Forms.ToolStripStatusLabel btnXem;
        private System.Windows.Forms.ToolStripStatusLabel btnExcel;
        private System.Windows.Forms.ToolStripStatusLabel btnWord;
        private System.Windows.Forms.ToolStripStatusLabel btnPDF;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

    }
}